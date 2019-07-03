using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;
using System.Windows.Forms;
namespace iCare
{
    /// <summary>
    /// 妊娠糖尿病治疗表打印工具类 
    /// </summary>
    public class clsEMR_GestationDiabetesCure_PrintTool_1 : infPrintRecord
    {
        private bool m_blnIsFromDataSource = true;//表明是从数据库读取还是从文件直接提取信息
        private bool m_blnWantInit = true;


        private clsEMR_GestationDiabetesCureDataInfo m_objResult = null;
        private clsPatient m_objPatient = null;
        private clsTransDataInfo[] objAr = null;
        /// <summary>
        /// 构造函数
        /// </summary>
        public clsEMR_GestationDiabetesCure_PrintTool_1()
        {
            //设置标题
            m_strTitle = "妊娠糖尿病治疗记录";

        }

        ///<summary>
        ///变量：控制打印记录人，只能打印一次。
        ///</summary>
        bool m_blnOnlyPrintOnceHadPrintedPerson;
        ///<summary>
        ///变量：控制打印附注，只能打印一次。
        ///</summary>
        bool m_blnOnlyPrintOnceHadPrinted;

        ///<summary>
        ///变量：特殊记录数组下际
        ///</summary>
        int m_intRecordIndex = 0;

        #region 设置打印列宽与每列的横坐标变量

        ///<summary>
        ///变量：第1列宽度
        ///</summary>
        float m_fltCol1; //第1列宽度
        ///<summary>
        ///变量：第2列宽度
        ///</summary>
        float m_fltCol2; //第2列宽度
        ///<summary>
        ///变量：第3列宽度
        ///</summary>
        float m_fltCol3; //第3列宽度
        ///<summary>
        ///变量：第4列宽度
        ///</summary>
        float m_fltCol4; //第4列宽度
        ///<summary>
        ///变量：第5列宽度
        ///</summary>
        float m_fltCol5; //第5列宽度
        ///<summary>
        ///变量：第6列宽度
        ///</summary>
        float m_fltCol6; //第6列宽度
        ///<summary>
        ///变量：第7列宽度
        ///</summary>
        float m_fltCol7; //第7列宽度
        ///<summary>
        ///变量：第8列宽度
        ///</summary>
        float m_fltCol8; //第8列宽度
        ///<summary>
        ///变量：第9列宽度
        ///</summary>
        float m_fltCol9;
        ///<summary>
        ///变量：第10列宽度
        ///</summary>
        float m_fltCol10;
        ///<summary>
        ///变量：第11列宽度
        ///</summary>
        float m_fltCol11;
        ///<summary>
        ///变量：第12列宽度
        ///</summary>
        float m_fltCol12;
        ///<summary>
        ///变量：第13列宽度
        ///</summary>
        float m_fltCol13;
        ///<summary>
        ///变量：第14列宽度
        ///</summary>
        float m_fltCol14;
        ///<summary>
        ///变量：第15列宽度
        ///</summary>
        float m_fltCol15;
        ///<summary>
        ///变量：第16列宽度
        ///</summary>
        float m_fltCol16;
        ///<summary>
        ///变量：第17列宽度
        ///</summary>
        float m_fltCol17;

        ///<summary>
        ///变量：第1列Left坐际
        ///</summary>
        float m_fltColLeft1; //第1列Left坐际
        ///<summary>
        ///变量：第2列Left坐际
        ///</summary>
        float m_fltColLeft2; //第2列Left坐际
        ///<summary>
        ///变量：第3列Left坐际
        ///</summary>
        float m_fltColLeft3; //第3列Left坐际
        ///<summary>
        ///变量：第4列Left坐际
        ///</summary>
        float m_fltColLeft4; //第4列Left坐际
        ///<summary>
        ///变量：第5列Left坐际
        ///</summary>
        float m_fltColLeft5; //第5列Left坐际
        ///<summary>
        ///变量：第6列Left坐际
        ///</summary>
        float m_fltColLeft6; //第6列Left坐际
        ///<summary>
        ///变量：第7列Left坐际
        ///</summary>
        float m_fltColLeft7; //第7列Left坐际
        ///<summary>
        ///变量：第8列Left坐际
        ///</summary>
        float m_fltColLeft8; //第8列Left坐际
        ///<summary>
        ///变量：第9列Left坐际
        ///</summary>
        float m_fltColLeft9; //第9列Left坐际
        ///<summary>
        ///变量：第10列Left坐际
        ///</summary>
        float m_fltColLeft10;
        ///<summary>
        ///变量：第11列Left坐际
        ///</summary>
        float m_fltColLeft11;
        ///<summary>
        ///变量：第12列Left坐际
        ///</summary>
        float m_fltColLeft12;
        ///<summary>
        ///变量：第13列Left坐际
        ///</summary>
        float m_fltColLeft13;
        ///<summary>
        ///变量：第14列Left坐际
        ///</summary>
        float m_fltColLeft14;
        ///<summary>
        ///变量：第15列Left坐标
        ///</summary>
        float m_fltColLeft15;
        ///<summary>
        ///变量：第16列Left坐际
        ///</summary>
        float m_fltColLeft16;
        ///<summary>
        ///变量：第17列Left坐际
        ///</summary>
        float m_fltColLeft17;
        #endregion


        #region 打印设置变量
        /// <summary>
        /// 打印标题的字体
        /// </summary>	
        private System.Drawing.Font m_fontTitle = new System.Drawing.Font("宋体", 18, FontStyle.Bold);
        /// <summary>
        /// 打印的标题目
        /// </summary>	
        public string m_strTitle;
        /// <summary>
        /// Pen对象
        /// </summary>
        private Pen m_objPen = new Pen(Color.Black);
        /// <summary>
        /// brush
        /// </summary>	
        private System.Drawing.Brush m_objBrush = System.Drawing.Brushes.Black;
        /// <summary>
        /// 打印正文的字体
        /// </summary>	
        private System.Drawing.Font m_fontBody = new System.Drawing.Font("宋体", 10.5f);
        /// <summary>
        /// 记录打印的高度落点位
        /// </summary>	
        public float m_fltLocationY = 0;
        ///<summary>
        ///变量：字与线间的位置高 ：间距
        ///</summary>
        private float m_fltZijiHeight = 6; //字与线间的位置高 ：间距
        ///<summary>
        ///变量：打印的当前页数
        ///</summary>
        private int m_intCurrentPageIndex = 1;
        ///<summary>
        ///变量：正本字体的高度
        ///</summary>
        private SizeF m_objsize;
        ///<summary>
        ///变量：字高
        ///</summary>
        private float m_fltZiHeight;
        ///<summary>
        ///变量：字宽
        ///</summary>
        private float m_fltZiWidth;
        ///<summary>
        ///变量：字与表格的左距离：间距
        ///</summary>
        private float m_fltZiJiWide = 0;// 字与表格的左距离：间距
        ///<summary>
        ///变量：行高
        ///</summary>
        private float m_ftlRowHeight;
        ///<summary>
        ///变量：行宽
        ///</summary>
        private float m_fltAvgCol;

        #endregion

        #region 方法:初始化每一列的位置
        /// <summary>
        /// 方法:初始化每一列的位置
        /// </summary>		
        private void mthInitColLocation(PrintPageEventArgs e)
        {
            #region 设置打印列宽与每列的横坐标

            m_fltAvgCol = 60;

            float fltCol = 60;
            m_fltCol1 = 70; //第1列宽度  日期

            m_fltCol2 = 30; //第2列宽度  孕周

            m_fltCol3 = 45; //第3列宽度  体重

            m_fltCol4 = 45; //第4列宽度  主食量

            m_fltCol5 = 40; //第5列宽度  胰岛素用量IU（长效）

            m_fltCol6 = 40; //第6列宽度  胰岛素用量IU（短效） 早

            m_fltCol7 = 40; //第7列宽度  胰岛素用量IU（短效） 中

            m_fltCol8 = 40; //第8列宽度  胰岛素用量IU（短效） 晚

            m_fltCol9 = 40; //第9列宽度  血糖定量 mmol/L（空腹）

            m_fltCol10 = 40; //第10列宽度  血糖定量 mmol/L（早饭  前）

            m_fltCol11 = 40; //第11列宽度  血糖定量 mmol/L（早饭  后）

            m_fltCol12 = 40; //第12列宽度  血糖定量 mmol/L（午饭  前）

            m_fltCol13 = 40; //第13列宽度  血糖定量 mmol/L（午饭  后）

            m_fltCol14 = 40; //第14列宽度  血糖定量 mmol/L（晚饭  前）

            m_fltCol15 = 40; //第15列宽度  血糖定量 mmol/L（晚饭  后）

            m_fltCol16 = 40;  //第16列宽度  尿酮

            m_fltCol17 = 100;  //第17列宽度  签名


            //m_fltColLeft1 = e.MarginBounds.Left - 90  ; //第1列Left坐际
            m_fltColLeft1 = e.PageBounds.Left + 30; //第1列Left坐际
            m_fltColLeft2 = m_fltColLeft1 + m_fltCol1; //第2列Left坐际
            m_fltColLeft3 = m_fltColLeft2 + m_fltCol2; //第3列Left坐际
            m_fltColLeft4 = m_fltColLeft3 + m_fltCol3; //第4列Left坐际
            m_fltColLeft5 = m_fltColLeft4 + m_fltCol4; //第5列Left坐际
            m_fltColLeft6 = m_fltColLeft5 + m_fltCol5; //第6列Left坐际
            m_fltColLeft7 = m_fltColLeft6 + m_fltCol6; //第7列Left坐际
            m_fltColLeft8 = m_fltColLeft7 + m_fltCol7; //第8列Left坐际
            m_fltColLeft9 = m_fltColLeft8 + m_fltCol9; //第9列Left坐际
            m_fltColLeft10 = m_fltColLeft9 + m_fltCol9;  //第10列Left坐际
            m_fltColLeft11 = m_fltColLeft10 + m_fltCol10; //第11列Left坐际
            m_fltColLeft12 = m_fltColLeft11 + m_fltCol11; //第12列Left坐际
            m_fltColLeft13 = m_fltColLeft12 + m_fltCol12;  //第13列Left坐际
            m_fltColLeft14 = m_fltColLeft13 + m_fltCol13;  //第14列Left坐际
            m_fltColLeft15 = m_fltColLeft14 + m_fltCol14;  //第15列Left坐际
            m_fltColLeft16 = m_fltColLeft15 + m_fltCol15;  //第16列Left坐际
            m_fltColLeft17 = m_fltColLeft16 + m_fltCol16;  //第17列Left坐际
            #endregion

            m_objsize = e.Graphics.MeasureString("测试", this.m_fontBody);
            m_fltZiHeight = m_objsize.Height;// 字高
            m_ftlRowHeight = m_fltZijiHeight + m_fltZiHeight;//行高

        }
        #endregion

        #region 设置打印信息(当从数据库读取时要首先调用.
        /// <summary>
        /// 设置打印信息(当从数据库读取时要首先调用.)
        /// </summary>
        /// <param name="p_objPatient">病人</param>
        /// <param name="p_dtmInPatientDate">入院日期</param>
        /// <param name="p_dtmOpenDate">OpenDate，如果是一次打印多次记录表单的类型（如病案记录），忽略OpenDate</param>
        public void m_mthSetPrintInfo(clsPatient p_objPatient, DateTime p_dtmInPatientDate, DateTime p_dtmOpenDate)
        {
            m_objPatient = p_objPatient;
            //m_dtInHos = p_dtmInPatientDate;
            com.digitalwave.clsRecordsService.clsEMR_GestationDiabetesCureMainServ objServ =
                (com.digitalwave.clsRecordsService.clsEMR_GestationDiabetesCureMainServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsRecordsService.clsEMR_GestationDiabetesCureMainServ));

            //从主表中获取所有没删除的数据
            
                objServ.m_lngGetTransDataInfoArr(null, p_objPatient.m_StrRegisterId, out objAr);
                if (objAr != null)
                {
                    m_mthSetPrintContent(objAr[0]);
                }
           
        }
        #endregion

        #region 从数据库初始化打印内容。如果没有记录，打印空报表。(当从数据库读取时要调用.)
        /// <summary>
        /// 从数据库初始化打印内容。如果没有记录，打印空报表。(当从数据库读取时要调用.)
        /// </summary>
        public void m_mthInitPrintContent()
        {
        }
        #endregion

        #region 设置打印内容。(当数据已经存在时使用。)
        /// <summary>
        /// 设置打印内容。(当数据已经存在时使用。)
        /// </summary>
        /// <param name="p_objPrintContent">打印内容</param>
        public void m_mthSetPrintContent(object p_objPrintContent)
        {
            m_objResult = p_objPrintContent as clsEMR_GestationDiabetesCureDataInfo;
        }
        #endregion

        #region 获取打印内容,(当从数据库读取时,调用本函数之前请首先调用m_mthSetPrintInfo函数)
        /// <summary>
        /// 获取打印内容,(当从数据库读取时,调用本函数之前请首先调用m_mthSetPrintInfo函数)
        /// </summary>
        /// <returns>打印内容</returns>
        public object m_objGetPrintInfo()
        {
            if (m_blnIsFromDataSource)
            {
                if (m_objResult == null)
                {
                    MDIParent.ShowInformationMessageBox("当从数据库读取时,调用m_objGetPrintInfo之前请首先调用m_mthSetPrintInfo函数");
                    return null;
                }
                return m_objResult;
            }
            return null;
        }

        #endregion

        #region 初始化打印变量,本例传入空对象即可.

        /// <summary>
        /// 初始化打印变量,本例传入空对象即可.
        /// </summary>
        public void m_mthInitPrintTool(object p_objArg)
        {

        }

        #endregion

        #region 释放打印变量
        /// <summary>
        /// 释放打印变量
        /// </summary>
        public void m_mthDisposePrintTools(object p_objArg)
        {

        }
        #endregion

        #region 打印

        #region  打印开始
        /// <summary>
        /// 打印开始
        /// </summary>
        /// <param name="p_objPrintArg">此处p_objPrintArg要求为PrintEventArgs类型的对象</param>
        public void m_mthBeginPrint(object p_objPrintArg)
        {
            reset();
            //			m_mthBeginPrintSub((PrintEventArgs)p_objPrintArg);
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
            //			e.PageSettings.Landscape = true;
            //			e.PageSettings.Margins.Left = 0;
            //			e.PageSettings.Margins.Right = 0;
            //测试
            //	e.Graphics.DrawRectangle(this.m_objPen,m_fltColLeft1,e.MarginBounds.Top,15*this.m_fltAvgCol,e.MarginBounds.Height);
            //


            m_mthPrintTitleInfo(e);
            m_mthPrintFormTitleInfo(e, this.m_objPatient, ref this.m_fltLocationY);
            mthInitColLocation(e);
            if (m_intCurrentPageIndex == 1)
            {
                m_mthPrintFormHeader(e, ref this.m_fltLocationY);
            }
            m_mthPrintAllPage(e, ref this.m_fltLocationY);
        }

        #endregion

        #region 打印每页
        /// <summary>
        /// 重置
        /// </summary>
        private void reset()
        {
            m_intRecordIndex = 0;
            m_blnOnlyPrintOnceHadPrintedPerson = false;
            m_blnOnlyPrintOnceHadPrinted = false;
            m_intCurrentPageIndex = 1;
            this.m_fltLocationY = 0;
            intSub = 0;
            m_blnIsPrint1 = false;
            m_blnIsPrint2 = false;

        }
        private int i = 0;
        private int intSub = 0;
        private bool m_blnIsPrint1 = false;
        private bool m_blnIsPrint2 = false;
        /// <summary>
        /// 打印全部页面
        /// </summary>
        /// <param name="e"></param>
        /// <param name="p_objLocationY"></param>
        private void m_mthPrintAllPage(System.Drawing.Printing.PrintPageEventArgs e, ref float p_objLocationY)
        {
            if (m_objResult == null)
            {
                return;
            }
            
            string print = "";

            if (m_objResult.m_objRecordArr.Length > 0)
            {
                if (m_intCurrentPageIndex == 1)
                {
                    string strTemp = null;
                    for (i = 0; i < m_objResult.m_objRecordArr.Length; i++)
                    {
                        
                            #region 逐行输出
                            /////逐行输出
                            float fltRealHeight = 0f;
                            //日期 1
                            if (strTemp == m_objResult.m_objRecordArr[i].m_dtmRecordDate.Date.ToString("yy/MM/dd")) 
                            {
                                print = " ";
                            }
                            else
                            {
                                print = m_objResult.m_objRecordArr[i].m_dtmRecordDate.Date.ToString("yy/MM/dd");
                                strTemp = m_objResult.m_objRecordArr[i].m_dtmRecordDate.Date.ToString("yy/MM/dd");
                            }
                            
                            float fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft1, this.m_fltColLeft2, print, p_objLocationY, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);
                            //孕周 2
                            print = m_objResult.m_objRecordArr[i].m_strGestationWeeks_right;
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft2, this.m_fltColLeft3, print, p_objLocationY, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);
                            //体重 3
                            print = m_objResult.m_objRecordArr[i].m_strAvoirdupois_right;
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft3, this.m_fltColLeft4, print, p_objLocationY, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);
                            //主食量 4
                            print = m_objResult.m_objRecordArr[i].m_strStapleMeasure_right;
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft4, this.m_fltColLeft5, print, p_objLocationY, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);
                            //胰岛素用量IU（长效） 5
                            print = m_objResult.m_objRecordArr[i].m_strInsulinLong_right;
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft5, this.m_fltColLeft6, print, p_objLocationY, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);
                            //胰岛素用量IU（短效） 早 6
                            print = m_objResult.m_objRecordArr[i].m_strInsulinShortMorning_right;
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft6, this.m_fltColLeft7, print, p_objLocationY, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);
                            //胰岛素用量IU（短效） 中 7
                            print = m_objResult.m_objRecordArr[i].m_strInsulinShortNoon_right;
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft7, this.m_fltColLeft8, print, p_objLocationY, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);
                            //胰岛素用量IU（短效） 晚 8
                            print = m_objResult.m_objRecordArr[i].m_strInsulinShortNight_right;
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft8, this.m_fltColLeft9, print, p_objLocationY, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);
                            //血糖定量 mmol/L（空腹） 9
                            print = m_objResult.m_objRecordArr[i].m_strBloodSugarLimosis_right;
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft9, this.m_fltColLeft10, print, p_objLocationY, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);
                            //血糖定量 mmol/L（早饭  前） 10
                            print = m_objResult.m_objRecordArr[i].m_strBloodSugarBe_BF_right;
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft10, this.m_fltColLeft11, print, p_objLocationY, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);
                            //血糖定量 mmol/L（早饭  后）11
                            print = m_objResult.m_objRecordArr[i].m_strBloodSugarAf_BF_right;
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft11, this.m_fltColLeft12, print, p_objLocationY, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);
                            //血糖定量 mmol/L（午饭  前） 12
                            print = m_objResult.m_objRecordArr[i].m_strBloodSugarBe_Lun_right;
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft12, this.m_fltColLeft13, print, p_objLocationY, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);
                            //血糖定量 mmol/L（午饭  后） 13
                            print = m_objResult.m_objRecordArr[i].m_strBloodSugarAf_Lun_right;
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft13, this.m_fltColLeft14, print, p_objLocationY, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);
                            //血糖定量 mmol/L（晚饭  前） 14
                            print = m_objResult.m_objRecordArr[i].m_strBloodSugarBe_Sup_right;
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft14, this.m_fltColLeft15, print, p_objLocationY, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);
                            //血糖定量 mmol/L（晚饭  后） 15
                            print = m_objResult.m_objRecordArr[i].m_strBloodSugarAf_Sup_right;
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft15, this.m_fltColLeft16, print, p_objLocationY, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);
                            //尿酮 16
                            print = m_objResult.m_objRecordArr[i].m_strUreaketone_right;
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft16, this.m_fltColLeft17, print, p_objLocationY, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);
                            print = "";
                            //签名 17
                            for (int w1 = 0; w1 < m_objResult.m_objRecordArr[i].objSignerArr.Length; w1++)
                            {
                                if (m_objResult.m_objRecordArr[i].objSignerArr.Length == 1)
                                {
                                    print += m_objResult.m_objRecordArr[i].objSignerArr[w1].objEmployee.m_strGetTechnicalRankAndName;
                                }
                                else
                                {
                                    print +=";"+ m_objResult.m_objRecordArr[i].objSignerArr[w1].objEmployee.m_strGetTechnicalRankAndName;
                                }
                            }
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft17, this.m_fltColLeft17 + m_fltCol17, print, p_objLocationY, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, m_ftlRowHeight);


                            print = "";
                            //if (m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].objSignerArr != null && m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].objSignerArr.Length > 0)
                            //{
                            //    print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].objSignerArr[0].objEmployee.m_strGetTechnicalRankAndName;
                            //    for (int w1 = 1; w1 < m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].objSignerArr.Length; w1++)
                            //    {
                            //        print += ";" + m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].objSignerArr[w1].objEmployee.m_strGetTechnicalRankAndName;
                            //    }
                            //}
                            //fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft15, this.m_fltColLeft15 + m_fltCol15, print, p_objLocationY, e);
                            //fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);
                            //fltRealHeight = m_fltGetMaxValue(fltRealHeight, m_ftlRowHeight);

                            m_mthDrawLines(e, fltRealHeight);
                            m_mthPrintHLine(e.Graphics, p_objLocationY, fltRealHeight);
                            p_objLocationY += fltRealHeight;
                            #endregion

                            //判断是否多页
                            if (Convert.ToInt32(p_objLocationY) >= e.MarginBounds.Bottom)
                            {
                                m_intCurrentPageIndex++;
                                e.HasMorePages = true;
                                m_mthPrintFoot(e);
                                return;
                            }
                        
                        intSub = 0;
                    }
                }
                //else
                //{
                //    int temp = i;

                //    #region draw one row

                //    for (; i < m_objResult.m_objPostPartumValues.Length; i++)
                //    {
                //        for (intSub = 0; intSub < m_objResult.m_objPostPartumValues[i].m_objRecordArr.Length; intSub++)
                //        {
                //            #region draw one row
                //            float fltRealHeight = 0f;
                //            print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].m_dtmCreateDate.Date.ToString("yy/MM/dd");
                //            float fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft1, this.m_fltColLeft2, print, p_objLocationY, e);
                //            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                //            print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].m_strPOSTPORTUM_NUM_CHR_RIGHT;
                //            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft2, this.m_fltColLeft3, print, p_objLocationY, e);
                //            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                //            print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].m_strUTERUSBOTTOM_CHR_RIGHT;
                //            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft3, this.m_fltColLeft4, print, p_objLocationY, e);
                //            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                //            print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].m_strUTERUSPINCH_CHR_RIGHT;
                //            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft4, this.m_fltColLeft5, print, p_objLocationY, e);
                //            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                //            print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].m_strMILKNUM_CHR_RIGHT;
                //            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft5, this.m_fltColLeft6, print, p_objLocationY, e);
                //            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                //            print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].m_strBREASTBULGE_CHR_RIGHT;
                //            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft6, this.m_fltColLeft7, print, p_objLocationY, e);
                //            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                //            print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].m_strNIPPLE_CHR_RIGHT;
                //            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft7, this.m_fltColLeft8, print, p_objLocationY, e);
                //            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                //            print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].m_strDEWNUM_CHR_RIGHT;
                //            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft8, this.m_fltColLeft9, print, p_objLocationY, e);
                //            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                //            print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].m_strDEWCOLOR_CHR_RIGHT;
                //            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft9, this.m_fltColLeft10, print, p_objLocationY, e);
                //            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                //            print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].m_strDEWFUCK_CHR_RIGHT;
                //            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft10, this.m_fltColLeft11, print, p_objLocationY, e);
                //            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                //            print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].m_strPERINEUM_CHR_RIGHT;
                //            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft11, this.m_fltColLeft12, print, p_objLocationY, e);
                //            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                //            print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].m_strBP_CHR_RIGHT;
                //            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft12, this.m_fltColLeft13, print, p_objLocationY, e);
                //            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                //            print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].m_strURINE_CHR_RIGHT;
                //            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft13, this.m_fltColLeft14, print, p_objLocationY, e);
                //            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                //            print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].m_strANNOTATIONS_CHR_RIGHT;
                //            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft14, this.m_fltColLeft15, print, p_objLocationY, e);
                //            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                //            print = "";
                //            if (m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].objSignerArr != null && m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].objSignerArr.Length > 0)
                //            {
                //                print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].objSignerArr[0].objEmployee.m_strGetTechnicalRankAndName;
                //                for (int w1 = 1; w1 < m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].objSignerArr.Length; w1++)
                //                {
                //                    print += ";" + m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].objSignerArr[w1].objEmployee.m_strGetTechnicalRankAndName;
                //                }
                //            }
                //            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft15, this.m_fltColLeft15 + m_fltCol15, print, p_objLocationY, e);
                //            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);
                //            fltRealHeight = m_fltGetMaxValue(fltRealHeight, m_ftlRowHeight);
                //            #endregion

                //            m_mthDrawLines(e, fltRealHeight);
                //            m_mthPrintHLine(e.Graphics, p_objLocationY, fltRealHeight);

                //            p_objLocationY += fltRealHeight;
                //            //判断是否多页
                //            if (Convert.ToInt32(p_objLocationY) >= e.MarginBounds.Bottom)
                //            {
                //                m_intCurrentPageIndex++;
                //                e.HasMorePages = true;
                //                m_mthPrintFoot(e);
                //                return;
                //            }
                //        }
                //        intSub = 0;
                //    }

                //    #endregion
                //}
            }
            p_objLocationY += 20;
            #region
            //if (m_objResult.m_objMannoValue != null)
            //{
            //    if (!m_blnIsPrint1)
            //    {
            //        //判断是否多页
            //        if ((Convert.ToInt32(p_objLocationY) + m_ftlRowHeight * 2) >= e.MarginBounds.Bottom)
            //        {
            //            m_intCurrentPageIndex++;
            //            e.HasMorePages = true;
            //            m_mthPrintFoot(e);
            //            return;
            //        }
            //        string str = "附注：记录时间："+m_objResult.m_objMannoValue.m_dtmRecordDate.ToString("yyyy年MM月dd日 HH:mm:ss")+Environment.NewLine
            //            + "      产后24小时总出血量：" + m_objResult.m_objMannoValue.m_strTOTALBLOODNUM_CHR_RIGHT + "ml" + Environment.NewLine + "      会阴伤口拆线：外缝"
            //            + m_objResult.m_objMannoValue.m_strSEWPIN_CHR_RIGHT + "针，愈合级别：" + m_objResult.m_objMannoValue.m_strPERIOD_CHR_RIGHT + "期";
            //        e.Graphics.DrawString(str, this.m_fontBody, this.m_objBrush, this.m_fltColLeft1, p_objLocationY + 5);
            //        m_blnIsPrint1 = true;
            //        p_objLocationY += this.m_ftlRowHeight * 3;
            //    }
            //    if (!m_blnIsPrint2)
            //    {
            //        string str = "特殊记录：(记录出院时情况或正常产后突发情况)" + Environment.NewLine + "    " + m_objResult.m_objMannoValue.m_strESPECIALRECORD_CHR_RIGHT;
            //        RectangleF rect = new RectangleF(e.PageBounds.Left + 50, p_objLocationY, e.PageBounds.Right - (e.PageBounds.Left + 60), m_ftlRowHeight * 2);
            //        SizeF sz = e.Graphics.MeasureString(str, this.m_fontBody, Convert.ToInt32(rect.Width));
            //        //判断是否多页
            //        if ((Convert.ToInt32(p_objLocationY) + Convert.ToInt32(sz.Height)) >= e.MarginBounds.Bottom)
            //        {
            //            m_intCurrentPageIndex++;
            //            e.HasMorePages = true;
            //            m_mthPrintFoot(e);
            //            return;
            //        }
            //        if (sz.Height > rect.Height)
            //            rect.Height = sz.Height;
            //        e.Graphics.DrawString(str, this.m_fontBody, this.m_objBrush, rect);
            //        m_blnIsPrint2 = true;
            //        p_objLocationY += rect.Height + 10;
            //    }

            //    string m_strPrint = "记录人：";
            //    e.Graphics.DrawString(m_strPrint, this.m_fontBody, this.m_objBrush, e.PageBounds.Left + 500, p_objLocationY);
            //    if (m_objResult.m_objMannoValue.objSignerArr != null && m_objResult.m_objMannoValue.objSignerArr.Length > 0)
            //    {
            //        clsEmrSigns_VO[] m_objSignArr = m_objResult.m_objMannoValue.objSignerArr;
            //        m_strPrint = "";
            //        for (int i = 0; i < m_objSignArr.Length; i++)
            //        {
            //            if (i < m_objSignArr.Length - 1)
            //            {
            //                m_strPrint += m_objSignArr[i].objEmployee.m_strLASTNAME_VCHR + "、\n";
            //            }
            //            else
            //            {
            //                m_strPrint += m_objSignArr[i].objEmployee.m_strLASTNAME_VCHR;
            //            }
            //        }
            //        e.Graphics.DrawString(m_strPrint, m_fontBody, m_objBrush, e.PageBounds.Left + 560, p_objLocationY);
            //    }

            //    m_mthPrintFoot(e);
            //}
            #endregion

        }

        #endregion

        #region 画线
        /// <summary>
        /// 画线
        /// </summary>
        /// <param name="e"></param>
        /// <param name="p_fltHeight"></param>
        private void m_mthDrawLines(PrintPageEventArgs e, float p_fltHeight)
        {
            e.Graphics.DrawLine(this.m_objPen, this.m_fltColLeft1, this.m_fltLocationY + p_fltHeight, this.m_fltColLeft17 + m_fltCol17, this.m_fltLocationY + p_fltHeight);
        }
        #endregion

        
        /// <summary>
        /// 打印页脚
        /// </summary>
        /// <param name="e"></param>
        private void m_mthPrintFoot(PrintPageEventArgs e)
        {
            string str = "第" + this.m_intCurrentPageIndex.ToString() + "页";
            SizeF s = e.Graphics.MeasureString(str, this.m_fontBody);
            float with = float.Parse(e.PageBounds.Width.ToString()) - s.Width;

            e.Graphics.DrawString(str, this.m_fontBody, this.m_objBrush, with / 2, float.Parse(e.MarginBounds.Bottom.ToString()));
        }
        /// <summary>
        /// 打印结束。一般使用它来更新数据库信息。
        /// </summary>
        /// <param name="p_objPrintArg">此处p_objPrintArg要求为PrintEventArgs类型的对象</param>
        public void m_mthEndPrint(object p_objPrintArg)
        {
            if (this.m_objPatient != null)
            {
                //m_objInRoomSvc.m_lngUpdateALLFirstPrintDate(m_objPatient.m_StrInPatientID,m_dtInHos.ToString(),System.DateTime.Now);
            }
        }

        #endregion
        
        /// <summary>
        /// 打印开始后，在打印页之前的操作
        /// </summary>
        /// <param name="p_objPrintArg"></param>
        private void m_mthBeginPrintSub(PrintEventArgs p_objPrintArg)
        {

        }

         
        /// <summary>
        /// 打印页
        /// </summary>
        /// <param name="p_objPrintPageArg"></param>
        private void m_mthPrintPageSub(PrintPageEventArgs p_objPrintPageArg)
        {

        }

        /// <summary>
        /// 设置打印内容
        /// </summary>
        /// <param name="p_objContent"></param>
        /// <param name="p_objCircsContentArr"></param>
        /// <param name="p_dtmFirstPrintDate"></param>
        private void m_mthSetPrintContent(clsNewBabyInRoomRecord p_objContent, clsNewBabyCircsRecord[] p_objCircsContentArr, DateTime p_dtmFirstPrintDate)
        {

        }

        /// <summary>
        /// 改变打印文档颜色
        /// </summary>
        /// <param name="p_objclsInPatientCase"></param>
        /// <returns></returns>
        private clsNewBabyInRoomRecord m_objChangePrintTextColor(clsNewBabyInRoomRecord p_objclsInPatientCase)
        {
            if (p_objclsInPatientCase == null)
                return null;

            return p_objclsInPatientCase;
        }

        #region  标题文字部分
        /// <summary>
        /// 标题文字部分
        /// </summary>
        /// <param name="e"></param>
        private void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
        {
            System.Drawing.Graphics g = e.Graphics;
            SizeF objSize = g.MeasureString(this.m_strTitle, this.m_fontTitle);
            g.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, new Font("宋体", 15, FontStyle.Bold), m_objBrush, 320,70);
            g.DrawString(this.m_strTitle, this.m_fontTitle, m_objBrush, e.MarginBounds.Left + (e.MarginBounds.Width - objSize.Width) / 2, e.MarginBounds.Top);
            this.m_fltLocationY = e.MarginBounds.Top + objSize.Height;

        }
        #endregion

        #region  表格上面文字部分
        /// <summary>
        /// 表格上面文字部分
        /// </summary>
        /// <param name="e"></param>
        private void m_mthPrintFormTitleInfo(System.Drawing.Printing.PrintPageEventArgs e, clsPatient p_objPatient, ref float p_fltLocationY)
        {
            string strPrint = "";
            int col = e.MarginBounds.Width / 6;
            float fltCol = float.Parse(col.ToString());//打印姓名此列的列宽
            System.Drawing.Graphics g = e.Graphics;
            g.DrawLine(this.m_objPen, m_fltColLeft1, p_fltLocationY, m_fltColLeft15 + m_fltCol15, p_fltLocationY);
            
            p_fltLocationY += m_ftlRowHeight;
            //姓名
            strPrint = "姓名:" + p_objPatient.m_StrName.Trim();
            g.DrawString(strPrint, m_fontBody, m_objBrush, e.MarginBounds.Left, p_fltLocationY);
            //性別
            strPrint = "性別:"+p_objPatient.m_StrSex.Trim();
            g.DrawString(strPrint, m_fontBody, m_objBrush, e.MarginBounds.Left + fltCol * 1-20, p_fltLocationY);
            //年龄
            strPrint = "年龄:" + p_objPatient.m_ObjPeopleInfo.m_IntAge.ToString().Trim();
            g.DrawString(strPrint, m_fontBody, m_objBrush, e.MarginBounds.Left + fltCol * 2-30, p_fltLocationY);
            //病区clsPatientInBedInfo
            strPrint = "病区号:" + p_objPatient.m_strAreaNewID.ToString().Trim();
            g.DrawString(strPrint, m_fontBody, m_objBrush, e.MarginBounds.Left + fltCol * 3-40, p_fltLocationY);
            //床号
            strPrint = "床号:" + p_objPatient.m_strBedCode.Trim();
            g.DrawString(strPrint, m_fontBody, m_objBrush, e.MarginBounds.Left + fltCol * 4-20, p_fltLocationY);
            //住院号
            strPrint = "住院号:" + p_objPatient.m_StrHISInPatientID.Trim();
            g.DrawString(strPrint, m_fontBody, m_objBrush, e.MarginBounds.Left + fltCol * 5-20, p_fltLocationY);

            p_fltLocationY += m_ftlRowHeight;
            //this.m_fltLocationY = p_fltLocationY;// +m_ftlRowHeight;

        }
        #endregion

        #region 打表头
        /// <summary>
        /// 打表头
        /// </summary>
        /// <param name="e"></param>
        /// <param name="p_objLocationY"></param>
        private void m_mthPrintFormHeader(System.Drawing.Printing.PrintPageEventArgs e, ref float p_objLocationY)
        {
            p_objLocationY += m_ftlRowHeight;
            e.Graphics.DrawLine(this.m_objPen, m_fltColLeft1, p_objLocationY, m_fltColLeft17 + m_fltCol17, p_objLocationY);
            //日期 1
            e.Graphics.DrawLine(this.m_objPen, m_fltColLeft1, p_objLocationY, m_fltColLeft1, p_objLocationY + m_ftlRowHeight * 3);
            m_fltDrawStrAtRectangle(true, this.m_fltColLeft1, this.m_fltColLeft2, "日", p_objLocationY + 15, e);
            m_fltDrawStrAtRectangle(true, this.m_fltColLeft1, this.m_fltColLeft2, "期", p_objLocationY + 40, e);

            //孕周 2
            e.Graphics.DrawLine(this.m_objPen, m_fltColLeft2, p_objLocationY, m_fltColLeft2, p_objLocationY + m_ftlRowHeight * 3);
            m_fltDrawStrAtRectangle(true, this.m_fltColLeft2, this.m_fltColLeft3, "孕", p_objLocationY + 15, e);
            m_fltDrawStrAtRectangle(true, this.m_fltColLeft2, this.m_fltColLeft3, "周", p_objLocationY + 40, e);
            //体重 3
            e.Graphics.DrawLine(this.m_objPen, m_fltColLeft3, p_objLocationY, m_fltColLeft3, p_objLocationY + m_ftlRowHeight * 3);
            m_fltDrawStrAtRectangle(true, this.m_fltColLeft3, this.m_fltColLeft4, "体", p_objLocationY + 10, e);
            m_fltDrawStrAtRectangle(true, this.m_fltColLeft3, this.m_fltColLeft4, "重", p_objLocationY + 30, e);
            m_fltDrawStrAtRectangle(true, this.m_fltColLeft3, this.m_fltColLeft4, "kg", p_objLocationY + 50, e);
            //主食量 4
            e.Graphics.DrawLine(this.m_objPen, m_fltColLeft4, p_objLocationY, m_fltColLeft4, p_objLocationY + m_ftlRowHeight * 3);
            m_fltDrawStrAtRectangle(false, this.m_fltColLeft4, this.m_fltColLeft5, "主", p_objLocationY + 5, e);
            m_fltDrawStrAtRectangle(false, this.m_fltColLeft4, this.m_fltColLeft5, "食", p_objLocationY + 20, e);
            m_fltDrawStrAtRectangle(false, this.m_fltColLeft4, this.m_fltColLeft5, "量", p_objLocationY + 35, e);
            m_fltDrawStrAtRectangle(false, this.m_fltColLeft4, this.m_fltColLeft5, "(两)", p_objLocationY + 50, e);
            //胰岛素用量IU 5 - 8
            e.Graphics.DrawLine(this.m_objPen, m_fltColLeft5, p_objLocationY, m_fltColLeft5, p_objLocationY + m_ftlRowHeight * 3);
            m_fltDrawStrAtRectangle(false, this.m_fltColLeft5, this.m_fltColLeft9, "胰岛素用量IU", p_objLocationY + 4, e);
            m_fltDrawStrAtRectangle(true, this.m_fltColLeft5, this.m_fltColLeft6, "长", p_objLocationY + m_ftlRowHeight + 10, e);
            m_fltDrawStrAtRectangle(true, this.m_fltColLeft5, this.m_fltColLeft6, "效", p_objLocationY + m_ftlRowHeight + 30, e);
            e.Graphics.DrawLine(this.m_objPen, m_fltColLeft6, p_objLocationY + m_ftlRowHeight, m_fltColLeft6, p_objLocationY + m_ftlRowHeight * 3);
            m_fltDrawStrAtRectangle(false, this.m_fltColLeft6, this.m_fltColLeft9, "短  效", p_objLocationY + m_ftlRowHeight + 3, e);

            m_fltDrawStrAtRectangle(false, this.m_fltColLeft6, this.m_fltColLeft7, "早", p_objLocationY + m_ftlRowHeight * 2, e);
            e.Graphics.DrawLine(this.m_objPen, m_fltColLeft7, p_objLocationY + m_ftlRowHeight*2, m_fltColLeft7, p_objLocationY + m_ftlRowHeight * 3);
            m_fltDrawStrAtRectangle(false, this.m_fltColLeft7, this.m_fltColLeft8, "午", p_objLocationY + m_ftlRowHeight * 2, e);

            e.Graphics.DrawLine(this.m_objPen, m_fltColLeft8, p_objLocationY + m_ftlRowHeight*2, m_fltColLeft8, p_objLocationY + m_ftlRowHeight * 3);
            m_fltDrawStrAtRectangle(false, this.m_fltColLeft8, this.m_fltColLeft9, "晚", p_objLocationY + m_ftlRowHeight * 2, e);
            e.Graphics.DrawLine(this.m_objPen, m_fltColLeft5, p_objLocationY + m_ftlRowHeight, m_fltColLeft9, p_objLocationY + m_ftlRowHeight);
            e.Graphics.DrawLine(this.m_objPen, m_fltColLeft6, p_objLocationY + m_ftlRowHeight * 2, m_fltColLeft9, p_objLocationY + m_ftlRowHeight*2);

            //血糖定量 9 - 15
            e.Graphics.DrawLine(this.m_objPen, m_fltColLeft9, p_objLocationY, m_fltColLeft9, p_objLocationY + m_ftlRowHeight * 3);
            m_fltDrawStrAtRectangle(false, this.m_fltColLeft9, this.m_fltColLeft16, "血糖定量 mmol/L", p_objLocationY + 4, e);
            m_fltDrawStrAtRectangle(true, this.m_fltColLeft9, this.m_fltColLeft10, "空", p_objLocationY + m_ftlRowHeight + 10, e);
            m_fltDrawStrAtRectangle(true, this.m_fltColLeft9, this.m_fltColLeft10, "腹", p_objLocationY + m_ftlRowHeight + 30, e); 
            e.Graphics.DrawLine(this.m_objPen, m_fltColLeft10, p_objLocationY + m_ftlRowHeight, m_fltColLeft10, p_objLocationY + m_ftlRowHeight * 3);
            m_fltDrawStrAtRectangle(false, this.m_fltColLeft10, this.m_fltColLeft12, "早 饭", p_objLocationY + m_ftlRowHeight + 3, e);
            m_fltDrawStrAtRectangle(false, this.m_fltColLeft10, this.m_fltColLeft11, "前", p_objLocationY + m_ftlRowHeight * 2, e);
            e.Graphics.DrawLine(this.m_objPen, m_fltColLeft11, p_objLocationY + m_ftlRowHeight * 2, m_fltColLeft11, p_objLocationY + m_ftlRowHeight * 3);
            m_fltDrawStrAtRectangle(false, this.m_fltColLeft11, this.m_fltColLeft12, "后", p_objLocationY + m_ftlRowHeight * 2, e);
            e.Graphics.DrawLine(this.m_objPen, m_fltColLeft12, p_objLocationY + m_ftlRowHeight, m_fltColLeft12, p_objLocationY + m_ftlRowHeight * 3);
            m_fltDrawStrAtRectangle(false, this.m_fltColLeft12, this.m_fltColLeft14, "午 饭", p_objLocationY + m_ftlRowHeight + 3, e);
            m_fltDrawStrAtRectangle(false, this.m_fltColLeft12, this.m_fltColLeft13, "前", p_objLocationY + m_ftlRowHeight * 2, e);
            e.Graphics.DrawLine(this.m_objPen, m_fltColLeft13, p_objLocationY + m_ftlRowHeight * 2, m_fltColLeft13, p_objLocationY + m_ftlRowHeight * 3);
            m_fltDrawStrAtRectangle(false, this.m_fltColLeft13, this.m_fltColLeft14, "后", p_objLocationY + m_ftlRowHeight * 2, e);
            e.Graphics.DrawLine(this.m_objPen, m_fltColLeft14, p_objLocationY + m_ftlRowHeight, m_fltColLeft14, p_objLocationY + m_ftlRowHeight * 3);
            m_fltDrawStrAtRectangle(false, this.m_fltColLeft14, this.m_fltColLeft16, "晚 饭", p_objLocationY + m_ftlRowHeight + 3, e);
            m_fltDrawStrAtRectangle(false, this.m_fltColLeft14, this.m_fltColLeft15, "前", p_objLocationY + m_ftlRowHeight * 2, e);
            e.Graphics.DrawLine(this.m_objPen, m_fltColLeft15, p_objLocationY + m_ftlRowHeight * 2, m_fltColLeft15, p_objLocationY + m_ftlRowHeight * 3);
            m_fltDrawStrAtRectangle(false, this.m_fltColLeft15, this.m_fltColLeft16, "后", p_objLocationY + m_ftlRowHeight * 2, e);
            e.Graphics.DrawLine(this.m_objPen, m_fltColLeft9, p_objLocationY + m_ftlRowHeight, m_fltColLeft16, p_objLocationY + m_ftlRowHeight);
            e.Graphics.DrawLine(this.m_objPen, m_fltColLeft10, p_objLocationY + m_ftlRowHeight * 2, m_fltColLeft16, p_objLocationY + m_ftlRowHeight * 2);
            


            //尿酮
            e.Graphics.DrawLine(this.m_objPen, m_fltColLeft16, p_objLocationY, m_fltColLeft16, p_objLocationY + m_ftlRowHeight * 3);
            m_fltDrawStrAtRectangle(true, this.m_fltColLeft16, this.m_fltColLeft17, "尿", p_objLocationY + 15, e);
            m_fltDrawStrAtRectangle(true, this.m_fltColLeft16, this.m_fltColLeft17, "酮", p_objLocationY + 40, e);
            ////签名
            e.Graphics.DrawLine(this.m_objPen, m_fltColLeft17, p_objLocationY, m_fltColLeft17, p_objLocationY + m_ftlRowHeight * 3);
            m_fltDrawStrAtRectangle(true, this.m_fltColLeft17, this.m_fltColLeft17 + this.m_fltCol17, "签", p_objLocationY + 15, e);
            m_fltDrawStrAtRectangle(true, this.m_fltColLeft17, this.m_fltColLeft17 + this.m_fltCol17, "名", p_objLocationY + 40, e);
            e.Graphics.DrawLine(this.m_objPen, m_fltColLeft17 + m_fltCol17, p_objLocationY, m_fltColLeft17 + m_fltCol17, p_objLocationY + m_ftlRowHeight * 3);

           
            p_objLocationY += m_ftlRowHeight * 3;
            e.Graphics.DrawLine(this.m_objPen, m_fltColLeft1, p_objLocationY, m_fltColLeft17 + m_fltCol17, p_objLocationY);


        }
        /// <summary>
        /// 画H线
        /// </summary>
        /// <param name="g"></param>
        /// <param name="p_objLocationY"></param>
        /// <param name="fltRealHeight"></param>
        void m_mthPrintHLine(System.Drawing.Graphics g, float p_objLocationY, float fltRealHeight)
        {
            g.DrawLine(this.m_objPen, m_fltColLeft1, p_objLocationY, m_fltColLeft1, p_objLocationY + fltRealHeight);
            g.DrawLine(this.m_objPen, m_fltColLeft2, p_objLocationY, m_fltColLeft2, p_objLocationY + fltRealHeight);
            g.DrawLine(this.m_objPen, m_fltColLeft3, p_objLocationY, m_fltColLeft3, p_objLocationY + fltRealHeight);
            g.DrawLine(this.m_objPen, m_fltColLeft4, p_objLocationY, m_fltColLeft4, p_objLocationY + fltRealHeight);
            g.DrawLine(this.m_objPen, m_fltColLeft5, p_objLocationY, m_fltColLeft5, p_objLocationY + fltRealHeight);
            g.DrawLine(this.m_objPen, m_fltColLeft6, p_objLocationY, m_fltColLeft6, p_objLocationY + fltRealHeight);
            g.DrawLine(this.m_objPen, m_fltColLeft7, p_objLocationY, m_fltColLeft7, p_objLocationY + fltRealHeight);
            g.DrawLine(this.m_objPen, m_fltColLeft8, p_objLocationY, m_fltColLeft8, p_objLocationY + fltRealHeight);
            g.DrawLine(this.m_objPen, m_fltColLeft9, p_objLocationY, m_fltColLeft9, p_objLocationY + fltRealHeight);
            g.DrawLine(this.m_objPen, m_fltColLeft10, p_objLocationY, m_fltColLeft10, p_objLocationY + fltRealHeight);
            g.DrawLine(this.m_objPen, m_fltColLeft11, p_objLocationY, m_fltColLeft11, p_objLocationY + fltRealHeight);
            g.DrawLine(this.m_objPen, m_fltColLeft12, p_objLocationY, m_fltColLeft12, p_objLocationY + fltRealHeight);
            g.DrawLine(this.m_objPen, m_fltColLeft13, p_objLocationY, m_fltColLeft13, p_objLocationY + fltRealHeight);
            g.DrawLine(this.m_objPen, m_fltColLeft14, p_objLocationY, m_fltColLeft14, p_objLocationY + fltRealHeight);
            g.DrawLine(this.m_objPen, m_fltColLeft15, p_objLocationY, m_fltColLeft15, p_objLocationY + fltRealHeight);
            g.DrawLine(this.m_objPen, m_fltColLeft16, p_objLocationY, m_fltColLeft16, p_objLocationY + fltRealHeight);
            g.DrawLine(this.m_objPen, m_fltColLeft17, p_objLocationY, m_fltColLeft17, p_objLocationY + fltRealHeight);

            g.DrawLine(this.m_objPen, m_fltColLeft17 + m_fltCol17, p_objLocationY, m_fltColLeft17 + m_fltCol17, p_objLocationY + fltRealHeight);
        }
        #endregion

        /// <summary>
        /// 打印方格
        /// </summary>
        /// <param name="p_blnIsMeasureH"></param>
        /// <param name="col1"></param>
        /// <param name="col2"></param>
        /// <param name="strPrint"></param>
        /// <param name="LocationY"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private float m_fltDrawStrAtRectangle(bool p_blnIsMeasureH, float col1, float col2, string strPrint, float LocationY, System.Drawing.Printing.PrintPageEventArgs e)
        {
            RectangleF rect = new RectangleF(col1, LocationY + 2, col2 - col1, m_ftlRowHeight);
            System.Drawing.Font m_font = this.m_fontBody;
            SizeF s = e.Graphics.MeasureString(strPrint, m_font, Convert.ToInt32(rect.Width));//字宽
            if (s.Height > rect.Height && p_blnIsMeasureH)
            {
                m_font = new System.Drawing.Font("宋体", 9);
                s = e.Graphics.MeasureString(strPrint, m_font, Convert.ToInt32(rect.Width));
                if (s.Height > rect.Height)
                    rect.Height = s.Height + 6;
            }
            else if (s.Height > rect.Height)
            {
                rect.Height = s.Height + 6;
            }
            StringFormat sf = new StringFormat(StringFormatFlags.FitBlackBox);
            sf.Alignment = StringAlignment.Center;
            e.Graphics.DrawString(strPrint, m_font, this.m_objBrush, rect, sf);
            return rect.Height;
        }


        /// <summary>
        /// 打印结束时的操作
        /// </summary>
        /// <param name="p_objPrintArg"></param>
        private void m_mthEndPrintSub(PrintEventArgs p_objPrintArg)
        {
            m_mthResetWhenEndPrint();
        }

        /// <summary>
        /// 每次打印结束之后的复位,无论是打印当前页或者打印全部.
        /// </summary>
        private void m_mthResetWhenEndPrint()
        {

        }
        /// <summary>
        /// 取最大值
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private float m_fltGetMaxValue(float a, float b)
        {
            return a > b ? a : b;
        }

    }
}
