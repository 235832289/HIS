using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.Utility.Controls;
using System.Drawing;
using System.Windows.Forms;
using com.digitalwave.clsNewBorthBabyGeneralNurseRecord_CSService;
using com.digitalwave.DoctorRecordService;
namespace iCare
{
    /// <summary>
    ///新生儿科一般患者护理记录(茶山)打印工具类(新版)摘要说明。
    /// </summary>
    public class clsNewBorthBabyGeneralNurseRecord_CSPrintTool : infPrintRecord
    {
        private bool m_blnIsFromDataSource = true;               //表明是从数据库读取还是从文件直接提取信息
        private bool m_blnWantInit = true;	                   //是否需要初始化	
        private clsRecordsDomain m_objRecordsDomain;           //记录域
        private string m_strCanModifyTime = "";//修改限定时间
        private clsPrintInfo_GeneralNurseRecordCS m_objPrintInfo;     //打印内容
        private int intCaseRowCount;                           //当前病程记录的最大行数
        private string[] strCurrentCaseTextArr;                //当前病程记录内容数组
        private string[] strCurrentCaseXmlArr;                 //当前病程记录痕迹数组
        private string[] strCurrentCaseCreateDateArr;          //当前病程记录创建时间
        private object[][] objDataArr;
        private bool m_bSummaryRow = false;
        public clsNewBorthBabyGeneralNurseRecord_CSPrintTool()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            m_strCanModifyTime = clsEMRLogin.StrCanModifyTime;
        }

        #region 打印初始化、事件


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
            m_objPrintInfo = new clsPrintInfo_GeneralNurseRecordCS();
            m_objPrintInfo.m_strInPatentID = m_objPatient != null ? m_objPatient.m_StrInPatientID : "";
            m_objPrintInfo.m_strPatientName = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrFirstName : "";
            m_objPrintInfo.m_strSex = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrSex : "";
            m_objPrintInfo.m_strAge = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrAge : "";
            m_objPrintInfo.m_strBedName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName : "";
            m_objPrintInfo.m_strDeptName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjDept.m_StrDeptName : "";
            m_objPrintInfo.m_strAreaName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjLastArea.m_ObjArea.m_StrAreaName : "";
            m_objPrintInfo.m_dtmInPatientDate = p_dtmInPatientDate;
            m_objPrintInfo.m_dtmOpenDate = p_dtmOpenDate;
            m_objPrintInfo.m_strHISInPatientID = m_objPatient != null ? m_objPatient.m_StrHISInPatientID : "";
            m_objPrintInfo.m_dtmHISInPatientDate = m_objPatient != null ? m_objPatient.m_DtmSelectedHISInDate : DateTime.MinValue;
        }

        /// <summary>
        /// 从数据库初始化打印内容。如果没有记录，打印空报表。(当从数据库读取时要调用.)
        /// </summary>
        public void m_mthInitPrintContent()
        {	//m_objprintinfo为空表明未设置打印内容		
            if (m_objPrintInfo == null)
            {
                clsPublicFunction.ShowInformationMessageBox("调用m_mthInitPrintContent之前请首先调用m_mthSetPrintInfo函数");
                return;
            }
            //病人为空
            if (m_objPrintInfo.m_strInPatentID == "")
                return;
            //获取打印内容
            m_objRecordsDomain = new clsRecordsDomain(enmRecordsType.NewBorthBabyGeneralNurseRecord_CSRec);

            long lngRes = m_objRecordsDomain.m_lngGetPrintInfo(m_objPrintInfo.m_strInPatentID, m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), out m_objPrintInfo.m_objTransDataArr, out m_objPrintInfo.m_dtmFirstPrintDateArr, out m_objPrintInfo.m_blnIsFirstPrintArr);
            if (lngRes <= 0)
                return;

            //按记录时间(CreateDate)排序 
            //			m_mthSortTransData(ref m_objPrintInfo.m_objTransDataArr);
            //设置表单内容到打印中
            m_mthSetPrintContent(m_objPrintInfo.m_objTransDataArr, m_objPrintInfo.m_dtmFirstPrintDateArr);
            m_objPrintInfo.m_objPrintDataArr = m_objPrintDataArr;
            m_blnWantInit = false;
        }

        private DateTime m_dtmPreRecordDate;
        private string strTempDate = string.Empty;
        private int m_intCurrentPagePrintRow = 0;
        private int m_intCurrentContentRow = 0;
        private int m_intMainCurrentPagePrintRow = 0;
        private int m_intMainCurrentContentRow = 0;

        /// <summary>
        /// 设置打印内容。(当数据已经存在时使用。)
        /// </summary>
        /// <param name="p_objPrintContent">打印内容</param>
        public void m_mthSetPrintContent(object p_objPrintContent)
        {
            if (p_objPrintContent.GetType().Name != "clsPrintInfo_IntensiveTend")
            {
                clsPublicFunction.ShowInformationMessageBox("参数错误");
            }
            m_blnIsFromDataSource = false;//表明是从文件直接提取信息
            m_objPrintInfo = (clsPrintInfo_GeneralNurseRecordCS)p_objPrintContent;
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

            //没有记录内容时，返回空


            if (m_objPrintInfo.m_objPrintDataArr == null || m_objPrintInfo.m_objPrintDataArr.Length == 0)
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
            m_fotHeaderFont = new Font("SimSun", 10.5f);
            m_fotSmallFont = new Font("SimSun", 12f);
            m_fotTinyFont = new Font("SimSun", 9f);

            m_GridPen = new Pen(Color.Black, 1);
            m_slbBrush = new SolidBrush(Color.Black);

            m_objPageSetting = new clsPrintPageSettingForRecord();

            m_objPrintContext = new com.digitalwave.controls.clsPrintRichTextContext(Color.Black, m_fotSmallFont);

            m_objPrintLenth = new clsPrintLenth_GeneralNurseRecordCS();
           
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
                        arlRecordType.Add(m_objPrintInfo.m_objTransDataArr[i].m_intFlag);
                        //存放记录的OpenDate
                        arlOpenDate.Add(m_objPrintInfo.m_objTransDataArr[i].m_objRecordContent.m_dtmOpenDate);
                        intUpdateIndex = i;
                    }
                }

                if (intUpdateIndex >= 0)
                {
                    m_objRecordsDomain.m_lngUpdateFirstPrintDate(m_objPrintInfo.m_strInPatentID, m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), (int[])arlRecordType.ToArray(typeof(int)), (DateTime[])arlOpenDate.ToArray(typeof(DateTime)), m_objPrintInfo.m_dtmFirstPrintDateArr[intUpdateIndex]);
                }
            }
            m_mthEndPrintSub((PrintEventArgs)p_objPrintArg);
        }

        private void m_mthSetPrintContent(clsTransDataInfo[] p_objTransDataArr,
            DateTime[] p_dtmFirstPrintDate)
        {
            try
            {
                if (p_objTransDataArr == null || p_dtmFirstPrintDate == null || p_objTransDataArr.Length != p_dtmFirstPrintDate.Length)
                {
                    clsPublicFunction.ShowInformationMessageBox("打印数据有误!");
                    return;
                }

                //根据不同的表单类型，获取对应的clsDiseaseTrackInfo
                clsDiseaseTrackInfo objTrackInfo = null;
                m_objPrintDataArr = new clsGeneralNurseRecordContent_CSDataInfo[p_objTransDataArr.Length];
                //				m_objPrintDataArr=(clsIntensiveTendDataInfo[])(p_objTransDataArr.Clone());
                ArrayList arlTemp = new ArrayList();
                arlTemp.AddRange(p_objTransDataArr);
                m_objPrintDataArr = (clsGeneralNurseRecordContent_CSDataInfo[])arlTemp.ToArray(typeof(clsGeneralNurseRecordContent_CSDataInfo));

                //System.Data.DataTable dtbBlankRecord = null;
                //new clsDiseaseTrackAddBlankDomain().m_lngGetBlankRecordContent(m_objPrintInfo.m_strInPatentID,m_objPrintInfo.m_dtmInPatientDate,out dtbBlankRecord);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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
            if (m_objPrintInfo.m_objTransDataArr == null)
                m_mthInitPrintContent();
        }
        // 打印页


        private void m_mthPrintPageSub(PrintPageEventArgs p_objPrintPageArg)
        {
            try
            {
                p_objPrintPageArg.HasMorePages = false;
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
            blnBeginPrintNewRecord = true;
            m_intRowNumberForPrintData = 0;
            m_intCurrentContentRow = 0;
            m_intMainCurrentContentRow = 0;
            m_intCurrentPagePrintRow = 0;
            m_intPosY = (int)enmRecordRectangleInfo.TopY + 220;
        }
        #endregion

        #region 有关打印的声明


        /// <summary>
        /// 所有打印的数据
        /// </summary>
        private clsGeneralNurseRecordContent_CSDataInfo[] m_objPrintDataArr;

        /// <summary>
        /// （基于危重护理记录的）打印上下文的类
        /// </summary>		
        private com.digitalwave.controls.clsPrintRichTextContext m_objPrintContext;
        /// <summary>
        /// 每行显示的汉字（病程记录）或字母（其他）的数目
        /// </summary>
        private class clsPrintLenth_GeneralNurseRecordCS
        {
            /// <summary>
            /// 病程观察
            /// </summary>
            public int m_intPrintLenth_RecordContent;		//病程观察
            /// <summary>
            /// 箱温
            /// </summary>
            public int m_intPrintLenth_BoxTemperature;	    //箱温
            /// <summary>
            /// 体温
            /// </summary>
            public int m_intPrintLenth_Temperature;			//体温
            /// <summary>
            /// 心率
            /// </summary>
            public int m_intPrintLenth_HeartRate;			//心率
            /// <summary>
            /// 呼吸
            /// </summary>
            public int m_intPrintLenth_Breath;				//呼吸
            /// <summary>
            /// 血压
            /// </summary>
            public int m_intPrintLenth_BloodPress;		    //血压

            /// <summary>
            /// sao2
            /// </summary>
            public int m_intPrintLenth_SaO2;				    //spo2
            /// <summary>
            /// cvp
            /// </summary>
            public int m_intPrintLenth_CVP;				    //CVP
            /// <summary>
            /// 神志
            /// </summary>
            public int m_intPrintLenth_Mind;				//神志
            /// <summary>
            /// 面容
            /// </summary>
            public int m_intPrintLenth_Face;				//面容
            /// <summary>
            /// 前卤
            /// </summary>
            public int m_intPrintLenth_Qianlu;				//前卤 
            /// <summary>
            /// 瞳孔大小
            /// </summary>
            public int m_intPrintLenth_Pupil;				//瞳孔大小
            /// <summary>
            /// 瞳孔反射	
            /// </summary>
            public int m_intPrintLenth_Echo;				//瞳孔反射		
            /// <summary>
            /// 摄入
            /// </summary>
            public int m_intPrintLenth_In;					//摄入
            /// <summary>
            /// 排出
            /// </summary>
            public int m_intPrintLenth_Out;					//排出
            //public int m_intPrintLenth_Look;			    //血循环观察
            //public int m_intPrintLenth_Custom;				//自定义列
        }

        /// <summary>
        /// 当前行的Y坐标
        /// </summary>
        int m_intPosY = (int)enmRecordRectangleInfo.TopY + 130;
        /// <summary>
        /// 每行数据行的高度
        /// </summary>
        int intTempDeltaY = 40;


        private clsPrintLenth_GeneralNurseRecordCS m_objPrintLenth;
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
            inty=15,
            /// <summary>
            /// 格子的顶端
            /// </summary>
            TopY = 150-inty,

            ///<summary>
            /// 格子的左端
            /// </summary>
            LeftX = 90,

            /// <summary>
            /// 格子的右端
            /// </summary>
            RightX = 1130,

            /// <summary>
            /// 格子每行的步长
            /// </summary>
            RowStep = 30,

            /// <summary>
            /// 格子的行数
            /// </summary>
            RowLinesNum = 21,

            /// <summary>
            /// 文字在格子中相对格子顶端的垂直偏移
            /// </summary>
            VOffSet = 22,

            /// <summary>
            /// 时间
            /// </summary>
            ColumnsMark1 = 80 - inty,//时间
            /// <summary>
            /// 箱温
            /// </summary>
            ColumnsMark2 = 130 - inty,//箱温
            /// <summary>
            /// //体温
            /// </summary>
            ColumnsMark3 = 170 - inty,//体温
            /// <summary>
            /// 心率
            /// </summary>
            ColumnsMark4 = 210 - inty,//心率
            /// <summary>
            /// 呼吸
            /// </summary>
            ColumnsMark5 = 250 - inty,//呼吸
            /// <summary>
            /// SpO2
            /// </summary>
            ColumnsMark6 = 290 - inty,//SpO2
            /// <summary>
            /// 神志
            /// </summary>
            ColumnsMark7 = 330 - inty,//神志
            /// <summary>
            /// 面色
            /// </summary>
            ColumnsMark8 = 370 - inty,//面色
            /// <summary>
            /// 囟门
            /// </summary>
            ColumnsMark9 = 410 - inty,//囟门
            /// <summary>
            /// 摄入种类
            /// </summary>
            ColumnsMark10 = 450 - inty,//摄入种类
            /// <summary>
            /// 摄入量
            /// </summary>
            ColumnsMark11 = 510 - inty,//摄入量
            /// <summary>
            /// 排出种类
            /// </summary>
            ColumnsMark12 = 550 - inty,//排出种类
            /// <summary>
            /// 排出量
            /// </summary>
            ColumnsMark13 = 610 - inty,//排出量
            /// <summary>
            /// 执行签名
            /// </summary>
            ColumnsMark14 = 650 - inty,//执行签名
            /// <summary>
            /// 病情观察
            /// </summary>
            ColumnsMark15 = 710 - inty,//病情观察
            /// <summary>
            /// 记录签名 
            /// </summary>
            ColumnsMark16 = 990 - inty//记录签名
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
                int inty = 15;
                PointF m_fReturnPoint;
                switch (p_intItemName)
                {

                    case (int)enmItemDefination.Page_HospitalName:
                        m_fReturnPoint = new PointF(550f, 40f - inty+5);
                        break;
                    case (int)enmItemDefination.Page_Name_Title:
                        m_fReturnPoint = new PointF(548f, 80f - inty);
                        break;
                    case (int)enmItemDefination.Name_Title:
                        m_fReturnPoint = new PointF(180f, 120f - inty);
                        break;
                    case (int)enmItemDefination.Name:
                        m_fReturnPoint = new PointF(230f, 120f - inty);
                        break;

                    case (int)enmItemDefination.Sex_Title:
                        m_fReturnPoint = new PointF(340f, 120f - inty);
                        break;
                    case (int)enmItemDefination.Sex:
                        m_fReturnPoint = new PointF(390f, 120f - inty);
                        break;

                    case (int)enmItemDefination.Age_Title:
                        m_fReturnPoint = new PointF(450f, 120f - inty);
                        break;
                    case (int)enmItemDefination.Age:
                        m_fReturnPoint = new PointF(500f, 120f - inty);
                        break;

                    case (int)enmItemDefination.Dept_Name_Title:
                        m_fReturnPoint = new PointF(620f, 120f - inty);
                        break;
                    case (int)enmItemDefination.Dept_Name:
                        m_fReturnPoint = new PointF(670f, 120f - inty);
                        break;

                    case (int)enmItemDefination.BedNo_Title:
                        m_fReturnPoint = new PointF(810f, 120f - inty);
                        break;
                    case (int)enmItemDefination.BedNo:
                        m_fReturnPoint = new PointF(860f, 120f - inty);
                        break;

                    case (int)enmItemDefination.InPatientID_Title:
                        m_fReturnPoint = new PointF(915f, 120f - inty);
                        break;
                    case (int)enmItemDefination.InPatientID:
                        m_fReturnPoint = new PointF(980f, 120f - inty);
                        break;

                    default:
                        m_fReturnPoint = new PointF(400f, 400f - inty);
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
            objEveryRecordPageInfo.strAge = m_objPrintInfo.m_strAge;
            objEveryRecordPageInfo.strPatientName = m_objPrintInfo.m_strPatientName;
            objEveryRecordPageInfo.strBedNo = m_objPrintInfo.m_strBedName;
            objEveryRecordPageInfo.strAreaName = m_objPrintInfo.m_strAreaName;
            objEveryRecordPageInfo.strSex = m_objPrintInfo.m_strSex;
            objEveryRecordPageInfo.strInPatientID = m_objPrintInfo.m_strHISInPatientID;
            objEveryRecordPageInfo.strPrintDate = (m_objPrintInfo.m_strInPatentID != "") ? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") : "";

            e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, new Font("宋体", 15, FontStyle.Bold), m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_HospitalName));

            e.Graphics.DrawString("一般患者护理记录", new Font("黑体", 18), m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_Name_Title));

            e.Graphics.DrawString("姓名：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name_Title));
            e.Graphics.DrawString(objEveryRecordPageInfo.strPatientName, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name));

            e.Graphics.DrawString("性别：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex_Title));
            e.Graphics.DrawString(objEveryRecordPageInfo.strSex, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex));

            e.Graphics.DrawString("年龄：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age_Title));
            e.Graphics.DrawString(objEveryRecordPageInfo.strAge, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age));

            e.Graphics.DrawString("病区：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name_Title));
            e.Graphics.DrawString(objEveryRecordPageInfo.strAreaName, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name));

            e.Graphics.DrawString("床号：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNo_Title));
            e.Graphics.DrawString(objEveryRecordPageInfo.strBedNo, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNo));

            e.Graphics.DrawString("住院号：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID_Title));
            e.Graphics.DrawString(objEveryRecordPageInfo.strInPatientID, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID));

            //在最后一行下面打印说明部分


            //e.Graphics.DrawString("出入量代码:U--尿 S--大便 V--呕吐物 E--引流液 D--进食 I--输液", m_fotSmallFont, m_slbBrush,
            //    (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2,
            //    (int)enmRecordRectangleInfo.TopY + ((int)enmRecordRectangleInfo.RowStep) * ((int)enmRecordRectangleInfo.RowLinesNum + 1) - 20);

        }
        #endregion
        private void m_mthDrawMultiString(Font fotNormal, Font fotSmall, int iLimitLenth, float x, float y, float x1, float y1, float xOff, float yOff, string strContent, System.Drawing.Printing.PrintPageEventArgs e)
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
                    e.Graphics.DrawString(strContent, fotSmall, m_slbBrush, drawRect, strFormat);
                }
                else//因为字体变小，只多出一字时未超出一行，此时无需上移
                {
                    e.Graphics.DrawString(strContent, fotSmall, m_slbBrush, drawRectNormal, strFormat);
                }
            }
            else
            {
                e.Graphics.DrawString(strContent, fotNormal, m_slbBrush, drawRectNormal, strFormat);

            }

        }

        private void m_mthDrawMultiString(Font fotNormal, float x, float y, float x1, float y1, float xOff, float yOff, string strContent, System.Drawing.Printing.PrintPageEventArgs e)
        {

            RectangleF drawRect = new RectangleF(x, y + yOff, x1 - x, y1 - y);
            StringFormat strFormat = new StringFormat();
            strFormat.Alignment = System.Drawing.StringAlignment.Center;
            strFormat.FormatFlags = System.Drawing.StringFormatFlags.LineLimit;

            e.Graphics.DrawString(strContent, fotNormal, m_slbBrush, drawRect, strFormat);


        }

        private string m_strGetDSTTextXML(string p_strText, string p_strModifyUserID, string p_strModifyUserName)
        {
            return com.digitalwave.controls.ctlRichTextBox.clsXmlTool.s_strMakeDSTXml(p_strText, p_strModifyUserID, p_strModifyUserName, Color.Black, Color.White);
        }

        #region 画标题的栏目
        /// <summary>
        /// 画标题的栏目
        /// </summary>
        /// <param name="e"></param>
        private void m_mthPrintHeaderInfo(System.Drawing.Printing.PrintPageEventArgs e)
        {
            //日期
            e.Graphics.DrawString("日 期", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + 20,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep - 5);

            //时间
            e.Graphics.DrawString("时", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark1 + 15, (int)enmRecordRectangleInfo.TopY + 2);
            e.Graphics.DrawString("间", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark1 + 15, (int)enmRecordRectangleInfo.TopY + 2 * (int)enmRecordRectangleInfo.RowStep + 5);

            //箱温	
            e.Graphics.DrawString("箱", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark2 + 12, (int)enmRecordRectangleInfo.TopY + 2);
            e.Graphics.DrawString("温", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark2 + 12, (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep);
            e.Graphics.DrawString("。", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark2 + 9, (int)enmRecordRectangleInfo.TopY - 10 + 2 * (int)enmRecordRectangleInfo.RowStep);
            e.Graphics.DrawString("C", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark2 + 17, (int)enmRecordRectangleInfo.TopY + 2 * (int)enmRecordRectangleInfo.RowStep + 1);


            //体温	
            e.Graphics.DrawString("体", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark3 + 12, (int)enmRecordRectangleInfo.TopY + 2);
            e.Graphics.DrawString("温", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark3 + 12, (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep);
            e.Graphics.DrawString("。", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark3 + 9, (int)enmRecordRectangleInfo.TopY - 10 + 2 * (int)enmRecordRectangleInfo.RowStep);
            e.Graphics.DrawString("C", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark3 + 17, (int)enmRecordRectangleInfo.TopY + 2 * (int)enmRecordRectangleInfo.RowStep + 1);

            //脉搏(次/分)
            e.Graphics.DrawString("心", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark4 + 12, (int)enmRecordRectangleInfo.TopY + 2);
            e.Graphics.DrawString("率", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark4 + 12, (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep - 13);
            e.Graphics.DrawString("次", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark4 + 12, (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep + 10);
            e.Graphics.DrawString("/", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark4 + 14, (int)enmRecordRectangleInfo.TopY + 2 * (int)enmRecordRectangleInfo.RowStep - 4);
            e.Graphics.DrawString("分", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark4 + 12, (int)enmRecordRectangleInfo.TopY + 2 * (int)enmRecordRectangleInfo.RowStep + 11);

            //呼吸(次/分)
            e.Graphics.DrawString("呼", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark5 + 12, (int)enmRecordRectangleInfo.TopY + 2);
            e.Graphics.DrawString("吸", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark5 + 12, (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep - 13);
            e.Graphics.DrawString("次", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark5 + 12, (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep + 10);
            e.Graphics.DrawString("/", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark5 + 13, (int)enmRecordRectangleInfo.TopY + 2 * (int)enmRecordRectangleInfo.RowStep - 4);
            e.Graphics.DrawString("分", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark5 + 12, (int)enmRecordRectangleInfo.TopY + 2 * (int)enmRecordRectangleInfo.RowStep + 11);

            //血压(mmHg)
            //e.Graphics.DrawString("血", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
            //    (int)enmRecordRectangleInfo.ColumnsMark6 + 20, (int)enmRecordRectangleInfo.TopY + 2);
            //e.Graphics.DrawString("压", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
            //    (int)enmRecordRectangleInfo.ColumnsMark6 + 20, (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep + 2);
            //e.Graphics.DrawString("mmHg", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
            //    (int)enmRecordRectangleInfo.ColumnsMark6 + 15, (int)enmRecordRectangleInfo.TopY + 2 * (int)enmRecordRectangleInfo.RowStep + 5);

            //SpO2(%)
            e.Graphics.DrawString("Sa", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark6 + 12, (int)enmRecordRectangleInfo.TopY + 5);
            e.Graphics.DrawString("O2", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark6 + 12, (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep + 5);
            e.Graphics.DrawString("%", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark6 + 16, (int)enmRecordRectangleInfo.TopY + 2 * (int)enmRecordRectangleInfo.RowStep + 5);

            //神志
            e.Graphics.DrawString("神", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
               (int)enmRecordRectangleInfo.ColumnsMark7 + 12, (int)enmRecordRectangleInfo.TopY  + 5);
            e.Graphics.DrawString("志", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
               (int)enmRecordRectangleInfo.ColumnsMark7 + 12, (int)enmRecordRectangleInfo.TopY + 2 * (int)enmRecordRectangleInfo.RowStep + 5);

            //面  色
            e.Graphics.DrawString("面", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
              (int)enmRecordRectangleInfo.ColumnsMark8 + 12, (int)enmRecordRectangleInfo.TopY +  5);
            e.Graphics.DrawString("色", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark8 + 12, (int)enmRecordRectangleInfo.TopY + 2 * (int)enmRecordRectangleInfo.RowStep + 5);
            //囟  门
            e.Graphics.DrawString("囟", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
              (int)enmRecordRectangleInfo.ColumnsMark9 + 12, (int)enmRecordRectangleInfo.TopY +  5);
            e.Graphics.DrawString("门", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark9 + 12, (int)enmRecordRectangleInfo.TopY + 2 * (int)enmRecordRectangleInfo.RowStep + 5);

            //摄入
            e.Graphics.DrawString("摄 入", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark10 + 25, (int)enmRecordRectangleInfo.TopY + 4);
            e.Graphics.DrawString("种", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark10 + 20, (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep + 5);
            e.Graphics.DrawString("类", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark10 + 20, (int)enmRecordRectangleInfo.TopY + 2 * (int)enmRecordRectangleInfo.RowStep + 5);
            e.Graphics.DrawString("量", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark11 + 12, (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep + 5);
            e.Graphics.DrawString("ml/g", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark11 + 6, (int)enmRecordRectangleInfo.TopY + 2 * (int)enmRecordRectangleInfo.RowStep + 5);

            //排出
            e.Graphics.DrawString("排出", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark12 + 30, (int)enmRecordRectangleInfo.TopY + 4);
            e.Graphics.DrawString("种", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark12 + 20, (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep + 5);
            e.Graphics.DrawString("类", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark12 + 20, (int)enmRecordRectangleInfo.TopY + 2 * (int)enmRecordRectangleInfo.RowStep + 5);
            e.Graphics.DrawString("量", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark13 + 12, (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep + 5);
            e.Graphics.DrawString("ml/g", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark13 + 6, (int)enmRecordRectangleInfo.TopY + 2 * (int)enmRecordRectangleInfo.RowStep + 5);


            //执行签名
            e.Graphics.DrawString("执", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark14 + 18, (int)enmRecordRectangleInfo.TopY + 5);
            e.Graphics.DrawString("行", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark14 + 18, (int)enmRecordRectangleInfo.TopY + 28);
            e.Graphics.DrawString("签", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark14 + 18, (int)enmRecordRectangleInfo.TopY + 51);
            e.Graphics.DrawString("名", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark14 + 18, (int)enmRecordRectangleInfo.TopY + 74);

            //病情、护理措施、效果
            e.Graphics.DrawString("病情、护理措施、效果", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark15 + 80, (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep );

            //记录签名
            e.Graphics.DrawString("记", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark16+ 18, (int)enmRecordRectangleInfo.TopY + 5);
            e.Graphics.DrawString("录", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark16 + 18, (int)enmRecordRectangleInfo.TopY + 28);
            e.Graphics.DrawString("签", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark16 + 18, (int)enmRecordRectangleInfo.TopY + 51);
            e.Graphics.DrawString("名", m_fotHeaderFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX +
                (int)enmRecordRectangleInfo.ColumnsMark16 + 18, (int)enmRecordRectangleInfo.TopY + 74);
        }
        #endregion

        #region 画格子


        /// <summary>
        ///  画格子
        /// </summary>
        /// <param name="e"></param>
        private void m_mthPrintRectangleInfo(System.Drawing.Printing.PrintPageEventArgs e)
        {
            //画格子横线
            for (int i1 = 0; i1 <= (int)enmRecordRectangleInfo.RowLinesNum; i1++)
            {
                if (i1 != 1 && i1 != 2)
                    e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX,
                        (int)enmRecordRectangleInfo.TopY + ((int)enmRecordRectangleInfo.RowStep) * i1,
                        (int)enmRecordRectangleInfo.RightX,
                        (int)enmRecordRectangleInfo.TopY + ((int)enmRecordRectangleInfo.RowStep) * i1);
                else if(i1 != 2)
                    e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark10,
                        (int)enmRecordRectangleInfo.TopY + ((int)enmRecordRectangleInfo.RowStep) * i1 - 8,
                        (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark14,
                        (int)enmRecordRectangleInfo.TopY + ((int)enmRecordRectangleInfo.RowStep) * i1 - 8);

            }

            #region 画格子竖线


            int intHeight = ((int)enmRecordRectangleInfo.RowLinesNum) * (int)enmRecordRectangleInfo.RowStep;
            //画左边沿线
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX, (int)enmRecordRectangleInfo.TopY,
                (int)enmRecordRectangleInfo.LeftX, (int)enmRecordRectangleInfo.TopY + intHeight);
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark1, (int)enmRecordRectangleInfo.TopY,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark1, (int)enmRecordRectangleInfo.TopY + intHeight);
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2, (int)enmRecordRectangleInfo.TopY,
               (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2, (int)enmRecordRectangleInfo.TopY + intHeight);
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark3, (int)enmRecordRectangleInfo.TopY,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark3, (int)enmRecordRectangleInfo.TopY + intHeight);
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark4, (int)enmRecordRectangleInfo.TopY,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark4, (int)enmRecordRectangleInfo.TopY + intHeight);
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark5, (int)enmRecordRectangleInfo.TopY,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark5, (int)enmRecordRectangleInfo.TopY + intHeight);
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark6, (int)enmRecordRectangleInfo.TopY,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark6, (int)enmRecordRectangleInfo.TopY + intHeight);
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark7, (int)enmRecordRectangleInfo.TopY,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark7, (int)enmRecordRectangleInfo.TopY + intHeight);
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark8, (int)enmRecordRectangleInfo.TopY,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark8, (int)enmRecordRectangleInfo.TopY + intHeight);
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark9, (int)enmRecordRectangleInfo.TopY,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark9, (int)enmRecordRectangleInfo.TopY + intHeight);
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark10, (int)enmRecordRectangleInfo.TopY,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark10, (int)enmRecordRectangleInfo.TopY + intHeight);
            //摄入中间分界线
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark11, (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep - 8,
               (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark11, (int)enmRecordRectangleInfo.TopY + intHeight);
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark12, (int)enmRecordRectangleInfo.TopY,
               (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark12, (int)enmRecordRectangleInfo.TopY + intHeight);
            //排出中间分界线
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark13, (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep - 8,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark13, (int)enmRecordRectangleInfo.TopY + intHeight);
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark14, (int)enmRecordRectangleInfo.TopY,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark14, (int)enmRecordRectangleInfo.TopY + intHeight);
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark15, (int)enmRecordRectangleInfo.TopY,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark15, (int)enmRecordRectangleInfo.TopY + intHeight);
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark16, (int)enmRecordRectangleInfo.TopY,
                (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark16, (int)enmRecordRectangleInfo.TopY + intHeight);
            //右边线
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.RightX, (int)enmRecordRectangleInfo.TopY,
                (int)enmRecordRectangleInfo.RightX, (int)enmRecordRectangleInfo.TopY + intHeight);
            #endregion
            //画对角线（血压）
            //for (int i1 = 3; i1 < (int)enmRecordRectangleInfo.RowLinesNum; i1++)//斜线只需要从第四行开始到倒数第二行
            //{
            //    e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark7,
            //    (int)enmRecordRectangleInfo.TopY + ((int)enmRecordRectangleInfo.RowStep) * i1,
            //    (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark6,
            //    (int)enmRecordRectangleInfo.TopY + ((int)enmRecordRectangleInfo.RowStep) * (i1 + 1));
            //}
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
            string strRecord = "";
            string strRecordXML = "";
            DateTime dtmFlagTime;
            intNowRow = 1;
            int iTemp = (int)enmRecordRectangleInfo.TopY + ((int)enmRecordRectangleInfo.RowStep * ((int)enmRecordRectangleInfo.RowLinesNum)) + 5;
            m_mthDrawMultiString(this.m_fotSmallFont, (int)enmRecordRectangleInfo.LeftX, iTemp, (int)enmRecordRectangleInfo.RightX, iTemp + 50, 1, 1, "（第" + intNowPage.ToString() + "页）", e);
            if (m_objPrintInfo.m_strInPatentID == "") return;
            m_intCurrentRecord = 0;
            //打印主循环


            for (int i1 = m_intMainCurrentContentRow; i1 < m_objPrintInfo.m_objTransDataArr.Length; i1++)
            {
                clsGeneralNurseRecordContent_CSDataInfo clsGereralData = new clsGeneralNurseRecordContent_CSDataInfo();
                clsGereralData = (clsGeneralNurseRecordContent_CSDataInfo)m_objPrintInfo.m_objTransDataArr[i1];
                objDataArr = m_objGetRecordsValueArr(clsGereralData);
                if (objDataArr == null)
                    continue;
                for (m_intCurrentRecord = m_intCurrentContentRow; m_intCurrentRecord < objDataArr.Length; m_intCurrentRecord++)
                {
                    enmReturnValue m_enmRe = m_blnPrintOneValueCS(e, m_intPosY);
                    //根据返回值处理换页情况


                    if (m_enmRe == enmReturnValue.enmFaild)
                        e.HasMorePages = false;
                    if (m_enmRe == enmReturnValue.enmNeedNextPage)
                    {
                        m_intRowNumberForPrintData = m_intCurrentRecord;
                        m_intPosY = (int)enmRecordRectangleInfo.TopY + 130;
                        e.HasMorePages = true;
                        return;
                    }
                    if (m_enmRe == enmReturnValue.enmSuccessed)
                    {
                        e.HasMorePages = false;
                        blnBeginPrintNewRecord = true;
                    }
                }
                m_intMainCurrentContentRow++;
            }
        }

        #region 只打印一行


        /// <summary>
        /// 只打印一行


        /// </summary>
        /// <param name="e"></param>
        /// <param name="p_intBottomY"></param>
        /// <returns></returns>
        private enmReturnValue m_blnPrintOneValueCS(System.Drawing.Printing.PrintPageEventArgs e, int p_intBottomY)
        {
            enmReturnValue enmIsRecordFinish = m_blnPrintOneRowValueCS(e);
            if (enmIsRecordFinish != enmReturnValue.enmNeedNextPage)
            {
                m_intRowNumberInValueArr = 0;
                m_intRowNumberInTempArr = 0;
            }
            return enmIsRecordFinish;
        }
        #endregion

        /// <summary>
        /// 检查是否换页,true:换页，false:不换页
        /// </summary>
        /// <param name="p_intNowRow">当前打印行，第p_intNowRow行</param>
        /// <param name="e"></param>
        /// <returns></returns>
        private string m_strConvertObjectValue(object obj)
        {
            clsDSTRichTextBoxValue objclsDSTRichTextBoxValue;
            string strTemp = "";
            if (obj == null)
            {
                strTemp = "";
            }
            else
            {
                if (obj.GetType().Name == "clsDSTRichTextBoxValue")
                {
                    objclsDSTRichTextBoxValue = (clsDSTRichTextBoxValue)obj;
                    if (objclsDSTRichTextBoxValue.m_blnUnderDST == true)
                    {
                        m_bSummaryRow = true;
                    }
                    strTemp = objclsDSTRichTextBoxValue.m_strText != null ? objclsDSTRichTextBoxValue.m_strText : "";
                }
                else
                {
                    strTemp = obj.ToString();
                }
            }
            return strTemp;
        }

        private bool m_blnCheckPageChange(System.Drawing.Printing.PrintPageEventArgs e)
        {
            //当当前行超过最后一行（即 >页总行数）时换页


            if (m_intCurrentPagePrintRow > ((int)enmRecordRectangleInfo.RowLinesNum - 4)/*除去表头2行外总有效行数*/)
            {
                m_intCurrentPagePrintRow = 0;
                intNowPage++;
                return true;
            }
            else return false;
        }

        #endregion

        //以下两个变量用来与m_intRowNumberForPrintData配合起来，控制系统在换页后继续上一页的打印
        /// <summary>
        /// 记录在新的一页需要打印的第一条记录在打印数组strValueArr中的序号
        /// </summary>
        private int m_intRowNumberInValueArr = 0;
        /// <summary>
        /// 记录在新的一页需要打印的第一条记录在TempArr数中组的序号
        /// </summary>
        private int m_intRowNumberInTempArr = 0;
        private enmReturnValue m_blnPrintOneRowValueCS(System.Drawing.Printing.PrintPageEventArgs e)
        {
            string strTemp;
            CharacterRange[] rgnDSTArr = new CharacterRange[1];
            rgnDSTArr[0] = new CharacterRange(0, 0);
            RectangleF rtfText = new RectangleF(0, 0, 10000, 100);
            StringFormat stfMeasure = new StringFormat(StringFormatFlags.LineLimit);
            RectangleF rtfBounds;
            Region[] rgnDST;
            clsDSTRichTextBoxValue objclsDSTRichTextBoxValue;
            if (m_blnCheckPageChange(e) == true) //每打印一行之前都要检查是否换页
            {
                return enmReturnValue.enmNeedNextPage;
                //换页
            }
            //日期
            int m_intPosX = (int)enmRecordRectangleInfo.LeftX;//当前的X坐标
            int m_intPosX1 = 0;
            int m_intPosY = (int)enmRecordRectangleInfo.TopY + ((m_intCurrentPagePrintRow + 3) * (int)enmRecordRectangleInfo.RowStep);
            int m_intPosY1 = (int)enmRecordRectangleInfo.TopY + ((m_intCurrentPagePrintRow + 4) * (int)enmRecordRectangleInfo.RowStep); ;
            int m_intXOff = 1;
            int m_intYOff = 15;
            int intTempColumn = 4;
            strTemp = m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
            if (strTemp.Trim().Length != 0)
            {
                e.Graphics.DrawString(strTemp, m_fotTinyFont, Brushes.Black, m_intPosX + 10, m_intPosY + 15);
                strTempDate = strTemp;
            }
            //换行时第一行的日期不能省去,前数值不为空，现数值为空，且处于第一行


            if (strTempDate.Trim().Length != 0 && m_intCurrentPagePrintRow == 0 && strTemp.Trim().Length == 0)
            {
                e.Graphics.DrawString(strTempDate, m_fotTinyFont, Brushes.Black, m_intPosX + 15, m_intPosY + 15);
            }
            //时间
            m_intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark1;//当前的X坐标
            intTempColumn = 5;
            strTemp = m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
            if (strTemp.Trim().Length != 0)
            {
                e.Graphics.DrawString(strTemp, m_fotTinyFont, Brushes.Black, m_intPosX+6, m_intPosY + 15);
            }

            //箱温
            m_intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2;//当前的X坐标
            m_intPosX1 = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark3;//当前的X坐标
            intTempColumn = 6;
            strTemp = m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
            if (strTemp.Trim().Length != 0)
            {
                m_mthDrawMultiString(this.m_fotTinyFont, this.m_fotTinyFont, 6, m_intPosX, m_intPosY, m_intPosX1, m_intPosY1, m_intXOff, m_intYOff, strTemp, e);
            }

            //体温
            m_intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark3;//当前的X坐标
            m_intPosX1 = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark4;//当前的X坐标
            intTempColumn =7;
            strTemp = m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
            if (strTemp.Trim().Length != 0)
            {
                m_mthDrawMultiString(this.m_fotTinyFont, this.m_fotTinyFont, 6, m_intPosX, m_intPosY, m_intPosX1, m_intPosY1, m_intXOff, m_intYOff, strTemp, e);
            }
            //心率
            m_intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark4;//当前的X坐标
            m_intPosX1 = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark5;//当前的X坐标
            intTempColumn = 8;
            strTemp = m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
            if (strTemp.Trim().Length != 0)
            {
                m_mthDrawMultiString(this.m_fotTinyFont, this.m_fotTinyFont, 6, m_intPosX, m_intPosY, m_intPosX1, m_intPosY1, m_intXOff, m_intYOff, strTemp, e);
            }
            m_bSummaryRow = false;
            //呼吸
            m_intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark5;//当前的X坐标
            m_intPosX1 = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark6;//当前的X坐标
            intTempColumn = 9;
            strTemp = m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
            if (strTemp.Trim().Length != 0)
            {
                m_mthDrawMultiString(this.m_fotTinyFont, this.m_fotTinyFont, 6, m_intPosX, m_intPosY, m_intPosX1, m_intPosY1, m_intXOff, m_intYOff, strTemp, e);
            }

            //血压
            //m_intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark6;//当前的X坐标
            //m_intPosX1 = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark7;//当前的X坐标
            //intTempColumn = 10;
            //strTemp = m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
            //if (strTemp != "")
            //{
            //    string[] strBloodPress = strTemp.Split('/');
            //    if (strBloodPress.Length > 1)
            //    {
            //        m_mthDrawMultiString(this.m_fotTinyFont, this.m_fotTinyFont, 6, m_intPosX - 5, m_intPosY, m_intPosX1, m_intPosY1, m_intXOff - 5, m_intYOff - 10, strBloodPress[0], e);
            //        m_mthDrawMultiString(this.m_fotTinyFont, this.m_fotTinyFont, 6, m_intPosX + 1, m_intPosY, m_intPosX1, m_intPosY1, m_intXOff + 5, m_intYOff + 10, strBloodPress[1], e);
            //    }
            //    else
            //        m_mthDrawMultiString(this.m_fotTinyFont, this.m_fotTinyFont, 6, m_intPosX - 5, m_intPosY, m_intPosX1, m_intPosY1, m_intXOff - 5, m_intYOff - 10, strBloodPress[0], e);
            //}
            //SpO2
            m_intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark6;//当前的X坐标
            m_intPosX1 = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark7;//当前的X坐标
            m_intXOff = 10;
            intTempColumn = 11;
            strTemp = m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
            if (strTemp.Trim().Length != 0)
            {
                m_mthDrawMultiString(this.m_fotTinyFont, this.m_fotTinyFont, 6, m_intPosX, m_intPosY, m_intPosX1, m_intPosY1, m_intXOff, m_intYOff, strTemp, e);
            }
            //神志
            m_intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark7;//当前的X坐标
            m_intPosX1 = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark8;//当前的X坐标
            m_intXOff = 10;
            intTempColumn = 12;
            strTemp = m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
            if (strTemp.Trim().Length != 0)
            {
                //m_mthDrawMultiString(this.m_fotTinyFont, this.m_fotTinyFont, 4, m_intPosX, m_intPosY, m_intPosX1, m_intPosY1, m_intXOff, m_intYOff, strTemp, e);
                if (strTemp.Length <= 2)
                {
                    m_mthDrawMultiString(this.m_fotTinyFont, this.m_fotTinyFont, 4, m_intPosX, m_intPosY, m_intPosX1, m_intPosY1, m_intXOff, m_intYOff, strTemp, e);
                }
                else
                {
                    m_mthDrawMultiString(this.m_fotTinyFont, this.m_fotTinyFont, 4, m_intPosX, m_intPosY - 12, m_intPosX1, m_intPosY1 - 12, m_intXOff, m_intYOff, strTemp, e);
                }
            }
            //面色
            m_intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark8;//当前的X坐标
            m_intPosX1 = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark9;//当前的X坐标
            m_intXOff = 10;
            intTempColumn = 13;
            strTemp = m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
            if (strTemp.Trim().Length != 0)
            {
                if (strTemp.Length <= 2)
                {
                    m_mthDrawMultiString(this.m_fotTinyFont, this.m_fotTinyFont, 4, m_intPosX, m_intPosY, m_intPosX1, m_intPosY1, m_intXOff, m_intYOff, strTemp, e);
                }
                else
                {
                    m_mthDrawMultiString(this.m_fotTinyFont, this.m_fotTinyFont, 4, m_intPosX, m_intPosY - 12, m_intPosX1, m_intPosY1 - 12, m_intXOff, m_intYOff, strTemp, e);
                }
            }
            //囟门
            m_intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark9;//当前的X坐标
            m_intPosX1 = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark10;//当前的X坐标
            m_intXOff = 10;
            intTempColumn = 14;
            strTemp = m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
            if (strTemp.Trim().Length != 0)
            {
                //m_mthDrawMultiString(this.m_fotTinyFont, this.m_fotTinyFont, 4, m_intPosX, m_intPosY, m_intPosX1, m_intPosY1, m_intXOff, m_intYOff, strTemp, e);
                if (strTemp.Length <= 2)
                {
                    m_mthDrawMultiString(this.m_fotTinyFont, this.m_fotTinyFont, 4, m_intPosX, m_intPosY, m_intPosX1, m_intPosY1, m_intXOff, m_intYOff, strTemp, e);
                }
                else
                {
                    m_mthDrawMultiString(this.m_fotTinyFont, this.m_fotTinyFont, 4, m_intPosX, m_intPosY - 12, m_intPosX1, m_intPosY1 - 12, m_intXOff, m_intYOff, strTemp, e);
                }
            }
            //摄入种类
            m_intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark10;//当前的X坐标
            m_intPosX1 = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark11;//当前的X坐标
            m_intXOff = 10;
            intTempColumn = 15;
            strTemp = m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
            if (strTemp.Trim().Length != 0)
            {
                m_mthDrawMultiString(this.m_fotTinyFont, this.m_fotTinyFont, 6, m_intPosX, m_intPosY, m_intPosX1, m_intPosY1, m_intXOff, m_intYOff, strTemp, e);
            }
            //摄入量
            m_intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark11;//当前的X坐标
            m_intPosX1 = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark12;//当前的X坐标
            m_intXOff = 10;
            intTempColumn = 16;
            strTemp = m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
            if (strTemp.Trim().Length != 0)
            {
                m_mthDrawMultiString(this.m_fotTinyFont, this.m_fotTinyFont, 6, m_intPosX, m_intPosY, m_intPosX1, m_intPosY1, m_intXOff, m_intYOff, strTemp, e);
            }
            //排出种类
            m_intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark12;//当前的X坐标
            m_intPosX1 = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark13;//当前的X坐标
            m_intXOff = 10;
            intTempColumn = 17;
            strTemp = m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
            if (strTemp.Trim().Length != 0)
            {
                m_mthDrawMultiString(this.m_fotTinyFont, this.m_fotTinyFont, 6, m_intPosX, m_intPosY, m_intPosX1, m_intPosY1, m_intXOff, m_intYOff, strTemp, e);
            }
            //排出量
            m_intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark13;//当前的X坐标
            m_intPosX1 = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark14;//当前的X坐标
            m_intXOff = 10;
            intTempColumn = 18;
            strTemp = m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
            if (strTemp.Trim().Length != 0)
            {
                m_mthDrawMultiString(this.m_fotTinyFont, this.m_fotTinyFont, 6, m_intPosX, m_intPosY, m_intPosX1, m_intPosY1, m_intXOff, m_intYOff, strTemp, e);
            }
            //执行签名
            m_intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark14;//当前的X坐标
            m_intPosX1 = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark15;//当前的X坐标
            intTempColumn = 19;
            strTemp = m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
            if (strTemp.Trim().Length != 0)
            {
                if (strTemp.Length > 5)
                {
                    e.Graphics.DrawString(strTemp.Substring(0, 5), m_fotTinyFont, m_slbBrush, m_intPosX, m_intPosY + 5);
                    e.Graphics.DrawString(strTemp.Substring(5), m_fotTinyFont, m_slbBrush, m_intPosX, m_intPosY + 25);
                }
                else
                    e.Graphics.DrawString(strTemp, m_fotTinyFont, m_slbBrush, m_intPosX, m_intPosY + m_intYOff);
            }
            m_bSummaryRow = false;

            //病情观察
            m_intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark15;//当前的X坐标
            m_intPosX1 = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark16;//当前的X坐标
            intTempColumn = 20;
            strTemp = m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
            if (strTemp.Trim().Length != 0)
            {
                e.Graphics.DrawString(strTemp, m_fotTinyFont, m_slbBrush, m_intPosX, m_intPosY + m_intYOff);
            }
            //记录签名
            m_intPosX = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark16;//当前的X坐标
            m_intPosX1 = (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.RightX;//当前的X坐标
            intTempColumn = 22;
            strTemp = m_strConvertObjectValue(objDataArr[m_intCurrentContentRow][intTempColumn]);
            if (strTemp.Trim().Length != 0)
            {
                if (strTemp.Length > 5)
                {
                    e.Graphics.DrawString(strTemp.Substring(0, 5), m_fotTinyFont, m_slbBrush, m_intPosX, m_intPosY + 5);
                    e.Graphics.DrawString(strTemp.Substring(5), m_fotTinyFont, m_slbBrush, m_intPosX, m_intPosY + 25);
                }
                else
                    e.Graphics.DrawString(strTemp, m_fotTinyFont, m_slbBrush, m_intPosX, m_intPosY + m_intYOff);
            }
            m_intCurrentContentRow++;
            m_intCurrentPagePrintRow++;
        #endregion
            return enmReturnValue.enmSuccessed;
        }

        private void m_mthSetOtherDetail(object[] objDetail, int intCurrentDetail, int intRowOfCurrentDetail, clsGeneralNurseRecordContent_CS objCurrent, out object[] objOtherDetail)
        {
            objOtherDetail = new object[24];
            string strText = ((string[])(objDetail[0]))[intRowOfCurrentDetail];
            string strXml = ((string[])(objDetail[1]))[intRowOfCurrentDetail];
            clsDSTRichTextBoxValue objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
            objclsDSTRichTextBoxValue.m_strText = strText;
            objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
            objOtherDetail[20] = objclsDSTRichTextBoxValue;
            objOtherDetail[21] = (DateTime)objDetail[3];
        }

        private object[][] m_objGetRecordsValueArr(clsTransDataInfo p_objTransDataInfo)
        {
            #region 显示记录到DataGrid
            try
            {
                object[] objData;
                ArrayList objReturnData = new ArrayList();
                ArrayList arlDetail = new ArrayList();//存放病情记录
                int intCurrentDetail = 0;//当前病情记录在ArrayList中的索引
                int intRecordCount = 0;
                bool blnIsSameClass = false;//判断是否为同一班次
                bool blnPreIsHide = false;//判断上一条记录是否被隐藏
                int intCurrentSignIndex = 0;//记录签名索引
                bool blnMark = false;
                clsGeneralNurseRecordContent_CSDataInfo objGNRCInfo = new clsGeneralNurseRecordContent_CSDataInfo();
                clsDSTRichTextBoxValue objclsDSTRichTextBoxValue;
                string strText, strXml;

                objGNRCInfo = (clsGeneralNurseRecordContent_CSDataInfo)p_objTransDataInfo;

                if (objGNRCInfo.m_objRecordArr == null && objGNRCInfo.m_objDetailArr == null)
                    return null;

                #region 对病情观察、护理措施、效果进行处理
                if (objGNRCInfo.m_objDetailArr != null)
                {
                    string strDetail = "";
                    string strDetailXML = "";
                    for (int n = 0; n < objGNRCInfo.m_objDetailArr.Length; n++)
                    {
                        clsGeneralNurseRecordContent_CSDetail objDetail = objGNRCInfo.m_objDetailArr[n];
                        object[] objTemp = new object[7];
                        strDetail = objDetail.m_strRECORDCONTENTAll;
                        strDetailXML = objDetail.m_strRECORDCONTENTXML;
                        string[] strDetailArr;
                        string[] strDetailXMLArr;
                        //将病情记录分为行。
                        com.digitalwave.controls.ctlRichTextBox.m_mthSplitXmlByBytes(strDetail, strDetailXML, 40, out strDetailArr, out strDetailXMLArr);

                        if (strDetail != string.Empty)
                        {
                            objTemp[0] = strDetailArr;
                            objTemp[1] = strDetailXMLArr;
                            objTemp[2] = strDetailArr.Length;
                            objTemp[3] = objDetail.m_dtmRECORDDATE;
                            objTemp[4] = objDetail.objSignerArr;
                            objTemp[5] = objDetail.m_strDetailCreateUserName;
                            objTemp[6] = objDetail.m_strCREATERECORDUSERID;
                            arlDetail.Add(objTemp);
                        }
                    }
                }
                #endregion

                if (objGNRCInfo.m_objRecordArr != null)
                    intRecordCount = objGNRCInfo.m_objRecordArr.Length;
                int intRowOfCurrentDetail = 0;

                #region 获取修改限定时间
                int intCanModifyTime = 0;
                try
                {
                    intCanModifyTime = int.Parse(m_strCanModifyTime);
                }
                catch
                {
                    intCanModifyTime = 6;
                }
                #endregion

                clsGeneralNurseRecordContent_CS objCurrent;
                clsGeneralNurseRecordContent_CS objNext;
                for (int i = 0; i < intRecordCount; i++)
                {
                    blnMark = false;
                    objData = new object[24];
                    objCurrent = objGNRCInfo.m_objRecordArr[i];
                    objNext = new clsGeneralNurseRecordContent_CS();//下一条护理记录
                    if (i < intRecordCount - 1)
                        objNext = objGNRCInfo.m_objRecordArr[i + 1];
                    clsGeneralNurseRecordContent_CS objLast = null;
                    if (i > 0)
                        objLast = objGNRCInfo.m_objRecordArr[i - 1];
                    //如果该护理记录是修改前的记录且是在指定时间内修改的，修改者与创建者为同一人，则不显示
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_dtmOpenDate == objCurrent.m_dtmOpenDate)
                    {
                        TimeSpan tsModify = objNext.m_dtmModifyDate - objCurrent.m_dtmModifyDate;
                        if ((int)tsModify.TotalHours < intCanModifyTime)
                        {
                            blnPreIsHide = true;
                            continue;
                        }
                    }
                    #region 存放关键字段
                    if (objCurrent.m_dtmCreateDate != DateTime.MinValue)
                    {
                        objData[0] = objCurrent.m_dtmRECORDDATE;//存放记录时间的字符串
                        objData[1] = (int)enmRecordsType.NewBorthBabyGeneralNurseRecord_CSRec;//存放记录类型的int值
                        objData[2] = objCurrent.m_dtmOpenDate;//存放记录的OpenDate字符串
                        objData[3] = objCurrent.m_dtmModifyDate;//存放记录的ModifyDate字符串   

                        //同一个则只在第一行显示日期
                        if (objCurrent.m_dtmRECORDDATE.Date.ToString() != m_dtmPreRecordDate.Date.ToString())
                        {
                            objData[4] = objCurrent.m_dtmRECORDDATE.Date.ToString("yyyy-MM-dd");//日期字符串
                        }
                        //修改后带有痕迹的记录不再显示时间
                        if (m_dtmPreRecordDate != objCurrent.m_dtmRECORDDATE)
                            objData[5] = objCurrent.m_dtmRECORDDATE.ToString("HH:mm");//时间字符串

                        objData[23] = objCurrent.m_strCreateUserID;//存放记录的createUserid字符串   

                    }
                    #endregion ;
                    #region 存放单项信息
                    bool blnIsRed = false;
                    //箱温
                    strText = objCurrent.m_strBOXTEMPERATURE_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_dtmOpenDate == objCurrent.m_dtmOpenDate
                        && objNext.m_strBOXTEMPERATURE_RIGHT != objCurrent.m_strBOXTEMPERATURE_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strBOXTEMPERATURE_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    if (objLast != null && objLast.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objLast.m_dtmOpenDate == objLast.m_dtmOpenDate
                        && string.IsNullOrEmpty(objLast.m_strBOXTEMPERATURE_RIGHT) && !blnPreIsHide)
                    {
                        blnIsRed = true;
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    if (blnIsRed)
                    {
                        objclsDSTRichTextBoxValue.m_clrTextColor = Color.Red;
                        blnIsRed = false;
                    }
                    objData[6] = objclsDSTRichTextBoxValue;//BT

                    //体温
                    strText = objCurrent.m_strTEMPERATURE_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_dtmOpenDate == objCurrent.m_dtmOpenDate
                        && objNext.m_strTEMPERATURE_RIGHT != objCurrent.m_strTEMPERATURE_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strTEMPERATURE_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    if (objLast != null && objLast.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objLast.m_dtmOpenDate == objLast.m_dtmOpenDate
                        && string.IsNullOrEmpty(objLast.m_strTEMPERATURE_RIGHT) && !blnPreIsHide)
                    {
                        blnIsRed = true;
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    if (blnIsRed)
                    {
                        objclsDSTRichTextBoxValue.m_clrTextColor = Color.Red;
                        blnIsRed = false;
                    }
                    objData[7] = objclsDSTRichTextBoxValue;//T

                    //心率
                    strText = objCurrent.m_strHEARTRATE_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_dtmOpenDate == objCurrent.m_dtmOpenDate
                        && objNext.m_strHEARTRATE_RIGHT != objCurrent.m_strHEARTRATE_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strHEARTRATE_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    if (objLast != null && objLast.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objLast.m_dtmOpenDate == objCurrent.m_dtmOpenDate
                        && string.IsNullOrEmpty(objLast.m_strHEARTRATE_RIGHT) && !blnPreIsHide)
                    {
                        blnIsRed = true;
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    if (blnIsRed)
                    {
                        objclsDSTRichTextBoxValue.m_clrTextColor = Color.Red;
                        blnIsRed = false;
                    }
                    objData[8] = objclsDSTRichTextBoxValue;//HR
                    //呼吸
                    strText = objCurrent.m_strRESPIRATION_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_dtmOpenDate == objCurrent.m_dtmOpenDate
                        && objNext.m_strRESPIRATION_RIGHT != objCurrent.m_strRESPIRATION_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strRESPIRATION_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    if (objLast != null && objLast.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objLast.m_dtmOpenDate == objCurrent.m_dtmOpenDate
                        && string.IsNullOrEmpty(objLast.m_strRESPIRATION_RIGHT) && !blnPreIsHide)
                    {
                        blnIsRed = true;
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    if (blnIsRed)
                    {
                        objclsDSTRichTextBoxValue.m_clrTextColor = Color.Red;
                        blnIsRed = false;
                    }
                    objData[9] = objclsDSTRichTextBoxValue;//P
                    //血压
                    strText = objCurrent.m_strBLOODPRESSURES_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_dtmOpenDate == objCurrent.m_dtmOpenDate
                        && objNext.m_strBLOODPRESSURES_RIGHT != objCurrent.m_strBLOODPRESSURES_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strBLOODPRESSURES_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    if (objLast != null && objLast.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objLast.m_dtmOpenDate == objCurrent.m_dtmOpenDate
                        && string.IsNullOrEmpty(objLast.m_strBLOODPRESSURES_RIGHT) && !blnPreIsHide)
                    {
                        blnIsRed = true;
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    if (blnIsRed)
                    {
                        objclsDSTRichTextBoxValue.m_clrTextColor = Color.Red;
                        blnIsRed = false;
                    }
                    objData[10] = objclsDSTRichTextBoxValue;//
                    //sao2
                    strText = objCurrent.m_strSAO2_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_dtmOpenDate == objCurrent.m_dtmOpenDate
                        && objNext.m_strSAO2_RIGHT != objCurrent.m_strSAO2_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strSAO2_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    if (objLast != null && objLast.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objLast.m_dtmOpenDate == objCurrent.m_dtmOpenDate
                        && string.IsNullOrEmpty(objLast.m_strSAO2_RIGHT) && !blnPreIsHide)
                    {
                        blnIsRed = true;
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    if (blnIsRed)
                    {
                        objclsDSTRichTextBoxValue.m_clrTextColor = Color.Red;
                        blnIsRed = false;
                    }
                    objData[11] = objclsDSTRichTextBoxValue;//
                    //神志
                    strText = objCurrent.m_strMind;
                    strXml = "<root />";
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[12] = objclsDSTRichTextBoxValue;
                    //面色
                    strText = objCurrent.m_dtcFace;
                    strXml = "<root />";
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[13] = objclsDSTRichTextBoxValue;
                    //囟门
                    strText = objCurrent.m_dtcQianlu;
                    strXml = "<root />";
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[14] = objclsDSTRichTextBoxValue;
                    #endregion
                    #region 病情观察、护理措施、效果
                    for (; intCurrentDetail < arlDetail.Count; intCurrentDetail++)
                    {
                        if ((DateTime)((object[])arlDetail[intCurrentDetail])[3] == objCurrent.m_dtmRECORDDATE)
                        {
                            #region 执行签名、记录签名
                            int m_intMax = Math.Max(Math.Max(Math.Max(objCurrent.m_objEductionArr == null ? 0 : objCurrent.m_objEductionArr.Length, objCurrent.m_objInpectArr == null ? 0 : objCurrent.m_objInpectArr.Length), objCurrent.objSignerArr == null ? 0 : objCurrent.objSignerArr.Length), ((string[])(((object[])arlDetail[intCurrentDetail])[0])).Length + ((clsEmrSigns_VO[])(((object[])arlDetail[intCurrentDetail])[4])).Length - 1);
                            for (int m = 0; m < m_intMax; m++)
                            {
                                if (objCurrent.m_objInpectArr != null && m < objCurrent.m_objInpectArr.Length)
                                {
                                    //摄入种类
                                    strText = objCurrent.m_objInpectArr[m].m_strINPECT_KIND;
                                    strXml = "<root />";
                                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                                    objclsDSTRichTextBoxValue.m_strText = strText;
                                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                                    objData[15] = objclsDSTRichTextBoxValue;
                                    //摄入量
                                    strText = objCurrent.m_objInpectArr[m].m_strINPECT_METE;
                                    strXml = "<root />";
                                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                                    objclsDSTRichTextBoxValue.m_strText = strText;
                                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                                    if (blnIsRed)
                                    {
                                        objclsDSTRichTextBoxValue.m_clrTextColor = Color.Red;
                                        blnIsRed = false;
                                    }
                                    objData[16] = objclsDSTRichTextBoxValue;//
                                }
                                if (objCurrent.m_objEductionArr != null && m < objCurrent.m_objEductionArr.Length)
                                {
                                    //排出种类
                                    strText = objCurrent.m_objEductionArr[m].m_strEDUCTION_KIND;
                                    strXml = "<root />";
                                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                                    objclsDSTRichTextBoxValue.m_strText = strText;
                                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                                    objData[17] = objclsDSTRichTextBoxValue;
                                    //排出量
                                    strText = objCurrent.m_objEductionArr[m].m_strEDUCTION_METE;
                                    strXml = "<root />";
                                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                                    objclsDSTRichTextBoxValue.m_strText = strText;
                                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                                    if (blnIsRed)
                                    {
                                        objclsDSTRichTextBoxValue.m_clrTextColor = Color.Red;
                                        blnIsRed = false;
                                    }
                                    objData[18] = objclsDSTRichTextBoxValue;//
                                }
                                if (objCurrent.objSignerArr != null && m < Math.Max(objCurrent.m_objEductionArr == null ? 0 : objCurrent.m_objEductionArr.Length, objCurrent.m_objInpectArr == null ? 0 : objCurrent.m_objInpectArr.Length))
                                {
                                    objData[19] = objCurrent.objSignerArr[0].objEmployee.m_strLASTNAME_VCHR;
                                }
                                else objData[19] = "";
                                if (m < ((string[])(((object[])arlDetail[intCurrentDetail])[0])).Length)
                                {
                                    strText = ((string[])(((object[])arlDetail[intCurrentDetail])[0]))[m];
                                    strXml = ((string[])(((object[])arlDetail[intCurrentDetail])[1]))[m];
                                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                                    objclsDSTRichTextBoxValue.m_strText = strText;
                                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                                    objData[20] = objclsDSTRichTextBoxValue;
                                    objData[21] = (DateTime)((object[])arlDetail[intCurrentDetail])[3];
                                }
                                if (m >= ((string[])(((object[])arlDetail[intCurrentDetail])[0])).Length - 1 && m < ((string[])(((object[])arlDetail[intCurrentDetail])[0])).Length)
                                {
                                    objData[22] = ((clsEmrSigns_VO[])(((object[])arlDetail[intCurrentDetail])[4]))[intCurrentSignIndex++].objEmployee.m_strLASTNAME_VCHR;
                                }
                                else
                                {
                                    objData[22] = "";
                                }
                                objReturnData.Add(objData);
                                objData = new object[24];
                            }
                            m_dtmPreRecordDate = objCurrent.m_dtmRECORDDATE;
                            intCurrentSignIndex = 0;
                            intCurrentDetail++;
                            blnMark = true;
                            break;
                            #endregion
                        }
                        else if ((DateTime)(((object[])arlDetail[intCurrentDetail])[3]) < objCurrent.m_dtmRECORDDATE)
                        {
                            for (int j = intRowOfCurrentDetail; j < ((string[])(((object[])arlDetail[intCurrentDetail])[0])).Length; j++)
                            {
                                object[] objOtherDetail = new object[24];
                                m_mthSetOtherDetail(((object[])arlDetail[intCurrentDetail]), intCurrentDetail, j, objCurrent, out objOtherDetail);
                                if (j == 0)
                                {
                                    //同一个则只在第一行显示日期
                                    if (((DateTime)((object[])arlDetail[intCurrentDetail])[3]).ToString("yyyyMMdd") != m_dtmPreRecordDate.Date.ToString("yyyyMMdd"))
                                    {
                                        objOtherDetail[4] = ((DateTime)((object[])arlDetail[intCurrentDetail])[3]).ToString("yyyy-MM-dd");
                                    }
                                    objOtherDetail[5] = ((DateTime)((object[])arlDetail[intCurrentDetail])[3]).ToString("HH:mm");
                                }
                                if (j == ((string[])(((object[])arlDetail[intCurrentDetail])[0])).Length - 1)
                                {
                                    if (((clsEmrSigns_VO[])(((object[])arlDetail[intCurrentDetail])[4])) != null)
                                    {
                                        for (int h = 0; h < ((clsEmrSigns_VO[])(((object[])arlDetail[intCurrentDetail])[4])).Length; h++)
                                        {
                                            objOtherDetail[22] = ((clsEmrSigns_VO[])(((object[])arlDetail[intCurrentDetail])[4]))[h].objEmployee.m_strLASTNAME_VCHR;
                                            objReturnData.Add(objOtherDetail);
                                            objOtherDetail = new object[24];
                                        }
                                    }
                                    else
                                    {
                                        objOtherDetail[22] = "";
                                        objReturnData.Add(objOtherDetail);
                                        objOtherDetail = new object[24];
                                    }
                                    
                                }
                                else
                                {
                                    objOtherDetail[22] = "";
                                    objReturnData.Add(objOtherDetail);
                                }
                            }
                            m_dtmPreRecordDate = (DateTime)(((object[])arlDetail[intCurrentDetail])[3]);
                            intRowOfCurrentDetail = 0;
                        }
                        else
                        {//若当前记录日期小于病情观察记录日期，则输出当前记录，循环下一条当前记录
                            //同一个则只在第一行显示日期
                            if (objCurrent.m_dtmRECORDDATE.Date.ToString() == m_dtmPreRecordDate.Date.ToString())
                            {
                                objData[4] = null;//不显示日期部分
                            }
                            #region 执行签名、记录签名
                            int m_intMax = Math.Max(Math.Max(objCurrent.m_objEductionArr == null ? 0 : objCurrent.m_objEductionArr.Length, objCurrent.m_objInpectArr == null ? 0 : objCurrent.m_objInpectArr.Length), objCurrent.objSignerArr == null ? 0 : objCurrent.objSignerArr.Length);
                            for (int m = 0; m < m_intMax; m++)
                            {
                                if (objCurrent.m_objInpectArr != null && m < objCurrent.m_objInpectArr.Length)
                                {
                                    //摄入种类
                                    strText = objCurrent.m_objInpectArr[m].m_strINPECT_KIND;
                                    strXml = "<root />";
                                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                                    objclsDSTRichTextBoxValue.m_strText = strText;
                                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                                    objData[15] = objclsDSTRichTextBoxValue;
                                    //摄入量
                                    strText = objCurrent.m_objInpectArr[m].m_strINPECT_METE;
                                    strXml = "<root />";
                                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                                    objclsDSTRichTextBoxValue.m_strText = strText;
                                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                                    if (blnIsRed)
                                    {
                                        objclsDSTRichTextBoxValue.m_clrTextColor = Color.Red;
                                        blnIsRed = false;
                                    }
                                    objData[16] = objclsDSTRichTextBoxValue;//
                                }
                                if (objCurrent.m_objEductionArr != null && m < objCurrent.m_objEductionArr.Length)
                                {
                                    //排出种类
                                    strText = objCurrent.m_objEductionArr[m].m_strEDUCTION_KIND;
                                    strXml = "<root />";
                                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                                    objclsDSTRichTextBoxValue.m_strText = strText;
                                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                                    objData[17] = objclsDSTRichTextBoxValue;
                                    //排出量
                                    strText = objCurrent.m_objEductionArr[m].m_strEDUCTION_METE;
                                    strXml = "<root />";
                                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                                    objclsDSTRichTextBoxValue.m_strText = strText;
                                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                                    if (blnIsRed)
                                    {
                                        objclsDSTRichTextBoxValue.m_clrTextColor = Color.Red;
                                        blnIsRed = false;
                                    }
                                    objData[18] = objclsDSTRichTextBoxValue;//
                                }
                                if (objCurrent.objSignerArr != null && m < Math.Max(objCurrent.m_objEductionArr == null ? 0 : objCurrent.m_objEductionArr.Length, objCurrent.m_objInpectArr == null ? 0 : objCurrent.m_objInpectArr.Length))
                                {
                                    objData[19] = objCurrent.objSignerArr[0].objEmployee.m_strLASTNAME_VCHR;
                                }
                                else objData[19] = "";
                                objData[22] = "";
                                objReturnData.Add(objData);
                                objData = new object[24];
                            }
                            m_dtmPreRecordDate = objCurrent.m_dtmRECORDDATE;
                            #endregion
                            break;
                        }
                    }
                    #endregion
                    #region 病程记录已显示完，显示剩余护理记录
                    if (!blnMark && intCurrentDetail == arlDetail.Count)
                    {
                        #region 执行签名、记录签名
                        int m_intMax = Math.Max(Math.Max(objCurrent.m_objEductionArr == null ? 0 : objCurrent.m_objEductionArr.Length, objCurrent.m_objInpectArr == null ? 0 : objCurrent.m_objInpectArr.Length), objCurrent.objSignerArr == null ? 0 : objCurrent.objSignerArr.Length);
                        for (int m = 0; m < m_intMax; m++)
                        {
                            if (objCurrent.m_objInpectArr != null && m < objCurrent.m_objInpectArr.Length)
                            {
                                //摄入种类
                                strText = objCurrent.m_objInpectArr[m].m_strINPECT_KIND;
                                strXml = "<root />";
                                objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                                objclsDSTRichTextBoxValue.m_strText = strText;
                                objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                                objData[15] = objclsDSTRichTextBoxValue;
                                //摄入量
                                strText = objCurrent.m_objInpectArr[m].m_strINPECT_METE;
                                strXml = "<root />";
                                objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                                objclsDSTRichTextBoxValue.m_strText = strText;
                                objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                                if (blnIsRed)
                                {
                                    objclsDSTRichTextBoxValue.m_clrTextColor = Color.Red;
                                    blnIsRed = false;
                                }
                                objData[16] = objclsDSTRichTextBoxValue;//
                            }
                            if (objCurrent.m_objEductionArr != null && m < objCurrent.m_objEductionArr.Length)
                            {
                                //排出种类
                                strText = objCurrent.m_objEductionArr[m].m_strEDUCTION_KIND;
                                strXml = "<root />";
                                objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                                objclsDSTRichTextBoxValue.m_strText = strText;
                                objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                                objData[17] = objclsDSTRichTextBoxValue;
                                //排出量
                                strText = objCurrent.m_objEductionArr[m].m_strEDUCTION_METE;
                                strXml = "<root />";
                                objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                                objclsDSTRichTextBoxValue.m_strText = strText;
                                objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                                if (blnIsRed)
                                {
                                    objclsDSTRichTextBoxValue.m_clrTextColor = Color.Red;
                                    blnIsRed = false;
                                }
                                objData[18] = objclsDSTRichTextBoxValue;//
                            }
                            if (objCurrent.objSignerArr != null && m < Math.Max(objCurrent.m_objEductionArr == null ? 0 : objCurrent.m_objEductionArr.Length, objCurrent.m_objInpectArr == null ? 0 : objCurrent.m_objInpectArr.Length))
                            {
                                objData[19] = objCurrent.objSignerArr[0].objEmployee.m_strLASTNAME_VCHR;
                            }
                            else objData[19] = "";
                            objData[22] = "";
                            objReturnData.Add(objData);
                            objData = new object[24];
                        }
                        m_dtmPreRecordDate = objCurrent.m_dtmRECORDDATE;
                        #endregion
                    }
                    #endregion
                }

                #region 如果病情观察、护理措施、效果未显示完而其它护理记录已全部显示完，则继续输出剩余部分
                while (arlDetail != null && intCurrentDetail < arlDetail.Count && arlDetail.Count > 0)
                {
                    if (intRowOfCurrentDetail < ((string[])(((object[])arlDetail[intCurrentDetail])[0])).Length)
                    {
                        for (int m = intRowOfCurrentDetail; m < ((string[])(((object[])arlDetail[intCurrentDetail])[0])).Length; m++)
                        {
                            object[] objOtherDetail = new object[29];
                            m_mthSetOtherDetail(((object[])arlDetail[intCurrentDetail]), intCurrentDetail, m, null, out objOtherDetail);
                            if (m == 0)
                            {
                                //同一个则只在第一行显示日期
                                if (((DateTime)((object[])arlDetail[intCurrentDetail])[3]).ToString("yyyyMMdd") != m_dtmPreRecordDate.Date.ToString("yyyyMMdd"))
                                {
                                    objOtherDetail[4] = ((DateTime)((object[])arlDetail[intCurrentDetail])[3]).ToString("yyyy-MM-dd");
                                }
                                objOtherDetail[5] = ((DateTime)((object[])arlDetail[intCurrentDetail])[3]).ToString("HH:mm");
                            }
                            if (m == ((string[])(((object[])arlDetail[intCurrentDetail])[0])).Length - 1)
                            {
                                if (((clsEmrSigns_VO[])(((object[])arlDetail[intCurrentDetail])[4])) != null)
                                {
                                    for (int h = 0; h < ((clsEmrSigns_VO[])(((object[])arlDetail[intCurrentDetail])[4])).Length; h++)
                                    {
                                        objOtherDetail[22] = ((clsEmrSigns_VO[])(((object[])arlDetail[intCurrentDetail])[4]))[h].objEmployee.m_strLASTNAME_VCHR;
                                        objReturnData.Add(objOtherDetail);
                                        objOtherDetail = new object[24];
                                    }
                                }
                                else
                                {
                                    objOtherDetail[22] = "";
                                    objReturnData.Add(objOtherDetail);
                                    objOtherDetail = new object[24];
                                }
                                
                            }
                            else
                            {
                                objOtherDetail[22] = "";
                                objReturnData.Add(objOtherDetail);
                            }
                        }
                        m_dtmPreRecordDate = (DateTime)((object[])arlDetail[intCurrentDetail])[3];
                        intCurrentDetail++;
                        intRowOfCurrentDetail = 0;
                    }
                }
                object[][] m_objRe = new object[objReturnData.Count][];

                for (int m = 0; m < objReturnData.Count; m++)
                    m_objRe[m] = (object[])objReturnData[m];
                return m_objRe;
            }
                #endregion
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            #endregion
        }

    }
}
