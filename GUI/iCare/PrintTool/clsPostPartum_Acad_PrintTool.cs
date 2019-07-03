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
    /// 产后记录打印工具类 
    /// </summary>
    public class clsPostPartum_Acad_PrintTool : infPrintRecord
    {
        private bool m_blnIsFromDataSource = true;//表明是从数据库读取还是从文件直接提取信息
        private bool m_blnWantInit = true;


        private clsIcuAcad_PostPartumContentValueContentDataInfo m_objResult = null;
        private clsPatient m_objPatient = null;
        private clsTransDataInfo[] objAr = null;

        public clsPostPartum_Acad_PrintTool()
        {
            m_strTitle = "产 后 记 录";

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
        float m_fltFirstCol; //第1列宽度
        ///<summary>
        ///变量：第2列宽度
        ///</summary>
        float m_fltSeconCol; //第2列宽度
        ///<summary>
        ///变量：第3列宽度
        ///</summary>
        float m_fltthCol; //第3列宽度
        ///<summary>
        ///变量：第4列宽度
        ///</summary>
        float m_fltthirCol; //第4列宽度
        ///<summary>
        ///变量：第5列宽度
        ///</summary>
        float m_fltFiveCol; //第5列宽度
        ///<summary>
        ///变量：第6列宽度
        ///</summary>
        float m_fltSixCol; //第6列宽度
        ///<summary>
        ///变量：第7列宽度
        ///</summary>
        float m_fltSenCol; //第7列宽度
        ///<summary>
        ///变量：第8列宽度
        ///</summary>
        float m_fltNigCol; //第8列宽度
        ///<summary>
        ///变量：第9列宽度
        ///</summary>
        float m_fltNiNeCol;
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
        ///变量：第1列Left坐际
        ///</summary>
        float m_fltFirstColLeft; //第1列Left坐际
        ///<summary>
        ///变量：第2列Left坐际
        ///</summary>
        float m_fltSeconColLeft; //第2列Left坐际
        ///<summary>
        ///变量：第3列Left坐际
        ///</summary>
        float m_fltthColLeft; //第3列Left坐际
        ///<summary>
        ///变量：第4列Left坐际
        ///</summary>
        float m_fltthirColLeft; //第4列Left坐际
        ///<summary>
        ///变量：第5列Left坐际
        ///</summary>
        float m_fltFiveColLeft; //第5列Left坐际
        ///<summary>
        ///变量：第6列Left坐际
        ///</summary>
        float m_fltSixColLeft; //第6列Left坐际
        ///<summary>
        ///变量：第7列Left坐际
        ///</summary>
        float m_fltSenColLeft; //第7列Left坐际
        ///<summary>
        ///变量：第8列Left坐际
        ///</summary>
        float m_fltNigColLeft; //第8列Left坐际
        ///<summary>
        ///变量：第9列Left坐际
        ///</summary>
        float m_fltNiNeColLeft; //第9列Left坐际
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
        ///变量：第14列rigth坐际,第15列的左坐标
        ///</summary>
        float m_fltColLeft15;
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
            m_fltFirstCol = 70; //第1列宽度日期

            m_fltSeconCol = 30; //第2列宽度产后日数

            m_fltthCol = 30; //第3列宽度宫低

            m_fltthirCol = 60; //第4列宽度收缩情况

            m_fltFiveCol = 40; //第5列宽度乳量

            m_fltSixCol = 40; //第6列宽度乳胀

            m_fltSenCol = 40; //第7列宽度乳头

            m_fltNigCol = 40; //第8列宽度量

            m_fltNiNeCol = 40; //第9列宽度色

            this.m_fltCol10 = 40;//臭味
            this.m_fltCol11 = 80;//会阴情况
            this.m_fltCol12 = 40;//BP
            this.m_fltCol13 = 40;//尿
            this.m_fltCol14 = 105;//附注
            this.m_fltCol15 = 65;//检查者


            m_fltFirstColLeft = e.PageBounds.Left + 30; //第1列Left坐际
            //			m_fltFirstColLeft = e.MarginBounds.Left - 90  ; //第1列Left坐际
            m_fltSeconColLeft = m_fltFirstCol + m_fltFirstColLeft; //第2列Left坐际
            m_fltthColLeft = m_fltSeconColLeft + m_fltSeconCol; //第3列Left坐际
            m_fltthirColLeft = m_fltthColLeft + m_fltthCol; //第4列Left坐际
            m_fltFiveColLeft = m_fltthirColLeft + m_fltthirCol; //第5列Left坐际
            m_fltSixColLeft = m_fltFiveColLeft + m_fltFiveCol; //第6列Left坐际
            m_fltSenColLeft = m_fltSixColLeft + m_fltSixCol; //第7列Left坐际
            m_fltNigColLeft = m_fltSenColLeft + m_fltSenCol; //第8列Left坐际
            m_fltNiNeColLeft = m_fltNigColLeft + m_fltNiNeCol; //第9列Left坐际
            this.m_fltColLeft10 = m_fltNiNeColLeft + m_fltNiNeCol;
            this.m_fltColLeft11 = m_fltColLeft10 + m_fltCol10;
            this.m_fltColLeft12 = m_fltColLeft11 + m_fltCol11;
            this.m_fltColLeft13 = m_fltColLeft12 + m_fltCol12;
            this.m_fltColLeft14 = m_fltColLeft13 + m_fltCol13;
            this.m_fltColLeft15 = m_fltColLeft14 + m_fltCol14;

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
            com.digitalwave.clsRecordsService.clsPostPartumRecord_MainService objServ =
                (com.digitalwave.clsRecordsService.clsPostPartumRecord_MainService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsRecordsService.clsPostPartumRecord_MainService));

            //从主表中获取所有没删除的数据

            objServ.m_lngGetTransDataInfoArr(null, p_objPatient.m_StrRegisterId, out objAr);
            if (objAr != null)
                m_mthSetPrintContent(objAr[0]);
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
            m_objResult = p_objPrintContent as clsIcuAcad_PostPartumContentValueContentDataInfo;
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
            //	e.Graphics.DrawRectangle(this.m_objPen,m_fltFirstColLeft,e.MarginBounds.Top,15*this.m_fltAvgCol,e.MarginBounds.Height);
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

        private void m_mthPrintAllPage(System.Drawing.Printing.PrintPageEventArgs e, ref float p_objLocationY)
        {
            if (m_objResult == null)
                return;
            if (m_objResult.m_objPostPartumValues == null && m_objResult.m_objMannoValue == null)
                return;
            string print = "";

            if (m_objResult.m_objPostPartumValues != null && m_objResult.m_objPostPartumValues.Length > 0)
            {
                if (m_intCurrentPageIndex == 1)
                {

                    for (i = 0; i < m_objResult.m_objPostPartumValues.Length; i++)
                    {
                        for (intSub = 0; intSub < m_objResult.m_objPostPartumValues[i].m_objRecordArr.Length; intSub++)
                        {
                            #region draw one row
                            float fltRealHeight = 0f;
                            print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].m_dtmRecordDate.Date.ToString("yy/MM/dd");
                            float fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltFirstColLeft, this.m_fltSeconColLeft, print, p_objLocationY, 0, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                            print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].m_strPOSTPORTUM_NUM_CHR_RIGHT;
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltSeconColLeft, this.m_fltthColLeft, print, p_objLocationY, 0, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                            print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].m_strUTERUSBOTTOM_CHR_RIGHT;
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltthColLeft, this.m_fltthirColLeft, print, p_objLocationY, 0, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                            print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].m_strUTERUSPINCH_CHR_RIGHT;
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltthirColLeft, this.m_fltFiveColLeft, print, p_objLocationY, 0, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                            print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].m_strMILKNUM_CHR_RIGHT;
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltFiveColLeft, this.m_fltSixColLeft, print, p_objLocationY, 0, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                            print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].m_strBREASTBULGE_CHR_RIGHT;
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltSixColLeft, this.m_fltSenColLeft, print, p_objLocationY, 0, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                            print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].m_strNIPPLE_CHR_RIGHT;
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltSenColLeft, this.m_fltNigColLeft, print, p_objLocationY, 0, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                            print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].m_strDEWNUM_CHR_RIGHT;
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltNigColLeft, this.m_fltNiNeColLeft, print, p_objLocationY, 0, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                            print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].m_strDEWCOLOR_CHR_RIGHT;
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltNiNeColLeft, this.m_fltColLeft10, print, p_objLocationY, 0, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                            print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].m_strDEWFUCK_CHR_RIGHT;
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft10, this.m_fltColLeft11, print, p_objLocationY, 0, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                            print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].m_strPERINEUM_CHR_RIGHT;
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft11, this.m_fltColLeft12, print, p_objLocationY, 0, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                            print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].m_strBP_CHR_RIGHT;
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft12, this.m_fltColLeft13, print, p_objLocationY, 0, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                            print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].m_strURINE_CHR_RIGHT;
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft13, this.m_fltColLeft14, print, p_objLocationY, 0, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                            print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].m_strANNOTATIONS_CHR_RIGHT;
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft14, this.m_fltColLeft15, print, p_objLocationY, 0, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                            print = "";
                            if (m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].objSignerArr != null && m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].objSignerArr.Length > 0)
                            {
                                //print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].objSignerArr[0].objEmployee.m_strGetTechnicalRankAndName;
                                print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].objSignerArr[0].objEmployee.m_strLASTNAME_VCHR;
                                for (int w1 = 1; w1 < m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].objSignerArr.Length; w1++)
                                {
                                    //print += ";" + m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].objSignerArr[w1].objEmployee.m_strGetTechnicalRankAndName;
                                    print += ";" + m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].objSignerArr[w1].objEmployee.m_strLASTNAME_VCHR;
                                }
                            }
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft15, this.m_fltColLeft15 + m_fltCol15, print, p_objLocationY, 1, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, m_ftlRowHeight);

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
                        }
                        intSub = 0;
                    }
                }
                else
                {
                    int temp = i;

                    #region draw one row

                    for (; i < m_objResult.m_objPostPartumValues.Length; i++)
                    {
                        for (intSub = 0; intSub < m_objResult.m_objPostPartumValues[i].m_objRecordArr.Length; intSub++)
                        {
                            #region draw one row
                            float fltRealHeight = 0f;
                            print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].m_dtmCreateDate.Date.ToString("yy/MM/dd");
                            float fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltFirstColLeft, this.m_fltSeconColLeft, print, p_objLocationY, 0, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                            print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].m_strPOSTPORTUM_NUM_CHR_RIGHT;
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltSeconColLeft, this.m_fltthColLeft, print, p_objLocationY, 0, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                            print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].m_strUTERUSBOTTOM_CHR_RIGHT;
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltthColLeft, this.m_fltthirColLeft, print, p_objLocationY, 0, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                            print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].m_strUTERUSPINCH_CHR_RIGHT;
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltthirColLeft, this.m_fltFiveColLeft, print, p_objLocationY, 0, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                            print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].m_strMILKNUM_CHR_RIGHT;
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltFiveColLeft, this.m_fltSixColLeft, print, p_objLocationY, 0, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                            print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].m_strBREASTBULGE_CHR_RIGHT;
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltSixColLeft, this.m_fltSenColLeft, print, p_objLocationY, 0, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                            print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].m_strNIPPLE_CHR_RIGHT;
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltSenColLeft, this.m_fltNigColLeft, print, p_objLocationY, 0, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                            print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].m_strDEWNUM_CHR_RIGHT;
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltNigColLeft, this.m_fltNiNeColLeft, print, p_objLocationY, 0, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                            print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].m_strDEWCOLOR_CHR_RIGHT;
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltNiNeColLeft, this.m_fltColLeft10, print, p_objLocationY, 0, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                            print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].m_strDEWFUCK_CHR_RIGHT;
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft10, this.m_fltColLeft11, print, p_objLocationY, 0, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                            print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].m_strPERINEUM_CHR_RIGHT;
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft11, this.m_fltColLeft12, print, p_objLocationY, 0, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                            print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].m_strBP_CHR_RIGHT;
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft12, this.m_fltColLeft13, print, p_objLocationY, 0, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                            print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].m_strURINE_CHR_RIGHT;
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft13, this.m_fltColLeft14, print, p_objLocationY, 0, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                            print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].m_strANNOTATIONS_CHR_RIGHT;
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft14, this.m_fltColLeft15, print, p_objLocationY, 0, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                            print = "";
                            if (m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].objSignerArr != null && m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].objSignerArr.Length > 0)
                            {
                                //print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].objSignerArr[0].objEmployee.m_strGetTechnicalRankAndName;
                                print = m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].objSignerArr[0].objEmployee.m_strLASTNAME_VCHR;
                                for (int w1 = 1; w1 < m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].objSignerArr.Length; w1++)
                                {
                                    //print += ";" + m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].objSignerArr[w1].objEmployee.m_strGetTechnicalRankAndName;
                                    print += ";" + m_objResult.m_objPostPartumValues[i].m_objRecordArr[intSub].objSignerArr[w1].objEmployee.m_strLASTNAME_VCHR;
                                }
                            }
                            fltHeight = m_fltDrawStrAtRectangle(true, this.m_fltColLeft15, this.m_fltColLeft15 + m_fltCol15, print, p_objLocationY, 1, e);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);
                            fltRealHeight = m_fltGetMaxValue(fltRealHeight, m_ftlRowHeight);
                            #endregion

                            m_mthDrawLines(e, fltRealHeight);
                            m_mthPrintHLine(e.Graphics, p_objLocationY, fltRealHeight);

                            p_objLocationY += fltRealHeight;
                            //判断是否多页
                            if (Convert.ToInt32(p_objLocationY) >= e.MarginBounds.Bottom)
                            {
                                m_intCurrentPageIndex++;
                                e.HasMorePages = true;
                                m_mthPrintFoot(e);
                                return;
                            }
                        }
                        intSub = 0;
                    }

                    #endregion
                }
            }
            p_objLocationY += 20;
            #region
            if (m_objResult.m_objMannoValue != null)
            {
                if (!m_blnIsPrint1)
                {
                    //判断是否多页
                    if ((Convert.ToInt32(p_objLocationY) + m_ftlRowHeight * 2) >= e.MarginBounds.Bottom)
                    {
                        m_intCurrentPageIndex++;
                        e.HasMorePages = true;
                        m_mthPrintFoot(e);
                        return;
                    }
                    //string str = "附注：记录时间："+m_objResult.m_objMannoValue.m_dtmRecordDate.ToString("yyyy年MM月dd日 HH:mm:ss")+Environment.NewLine
                    //    + "      产后24小时总出血量：" + m_objResult.m_objMannoValue.m_strTOTALBLOODNUM_CHR_RIGHT + "ml" + Environment.NewLine + "      会阴伤口拆线：外缝"
                    //    + m_objResult.m_objMannoValue.m_strSEWPIN_CHR_RIGHT + "针，愈合级别：" + m_objResult.m_objMannoValue.m_strPERIOD_CHR_RIGHT + "期";
                    string str = "附注：记录时间：" + m_objResult.m_objMannoValue.m_dtmRecordDate.ToString("yyyy年MM月dd日 HH:mm:ss") + Environment.NewLine
                        + "      产后24小时总出血量：" + m_objResult.m_objMannoValue.m_strTOTALBLOODNUM_CHR_RIGHT + "ml" + Environment.NewLine
                        + "      会阴情况：" + m_objResult.m_objMannoValue.m_strPERIOD_CHR_RIGHT;

                    e.Graphics.DrawString(str, this.m_fontBody, this.m_objBrush, this.m_fltFirstColLeft, p_objLocationY + 5);
                    m_blnIsPrint1 = true;
                    p_objLocationY += this.m_ftlRowHeight * 3;
                }
                if (!m_blnIsPrint2)
                {
                    string str = "特殊记录：(记录出院时情况或正常产后突发情况)" + Environment.NewLine + "    " + m_objResult.m_objMannoValue.m_strESPECIALRECORD_CHR_RIGHT;
                    RectangleF rect = new RectangleF(e.PageBounds.Left + 50, p_objLocationY, e.PageBounds.Right - (e.PageBounds.Left + 60), m_ftlRowHeight * 2);
                    SizeF sz = e.Graphics.MeasureString(str, this.m_fontBody, Convert.ToInt32(rect.Width));
                    //判断是否多页
                    if ((Convert.ToInt32(p_objLocationY) + Convert.ToInt32(sz.Height)) >= e.MarginBounds.Bottom)
                    {
                        m_intCurrentPageIndex++;
                        e.HasMorePages = true;
                        m_mthPrintFoot(e);
                        return;
                    }
                    if (sz.Height > rect.Height)
                        rect.Height = sz.Height;
                    e.Graphics.DrawString(str, this.m_fontBody, this.m_objBrush, rect);
                    m_blnIsPrint2 = true;
                    p_objLocationY += rect.Height + 10;
                }

                string m_strPrint = "记录人：";
                e.Graphics.DrawString(m_strPrint, this.m_fontBody, this.m_objBrush, e.PageBounds.Left + 500, p_objLocationY);
                if (m_objResult.m_objMannoValue.objSignerArr != null && m_objResult.m_objMannoValue.objSignerArr.Length > 0)
                {
                    clsEmrSigns_VO[] m_objSignArr = m_objResult.m_objMannoValue.objSignerArr;
                    m_strPrint = "";
                    int x = e.PageBounds.Left + 560;
                    for (int i = 0; i < m_objSignArr.Length; i++)
                    {
                        if (i < m_objSignArr.Length - 1)
                        {
                            Image imgEmpSig = ImageSignature.GetEmpSigImage(m_objSignArr[i].objEmployee.m_strLASTNAME_VCHR);
                            if (imgEmpSig != null)
                            {
                                e.Graphics.DrawImage(imgEmpSig, e.PageBounds.Left + 560, p_objLocationY - 2, 70, 30);
                            }
                            else
                            {
                                e.Graphics.DrawString(m_objSignArr[i].objEmployee.m_strLASTNAME_VCHR, m_fontBody, m_objBrush, e.PageBounds.Left + 560, p_objLocationY);
                            }
                        }
                        else
                        {
                            Image imgEmpSig = ImageSignature.GetEmpSigImage(m_objSignArr[i].objEmployee.m_strLASTNAME_VCHR);
                            if (imgEmpSig != null)
                            {
                                e.Graphics.DrawImage(imgEmpSig, e.PageBounds.Left + 560, p_objLocationY - 2, 70, 30);
                            }
                            else
                            {
                                e.Graphics.DrawString(m_objSignArr[i].objEmployee.m_strLASTNAME_VCHR, m_fontBody, m_objBrush, e.PageBounds.Left + 560, p_objLocationY - 2);
                            }
                        }
                        x += 80;
                    }



                    //e.Graphics.DrawString(m_strPrint, m_fontBody, m_objBrush, e.PageBounds.Left + 560, p_objLocationY);
                }

                m_mthPrintFoot(e);
            }
            #endregion

        }

        #endregion

        #region 画线
        private void m_mthDrawLines(PrintPageEventArgs e, float p_fltHeight)
        {
            e.Graphics.DrawLine(this.m_objPen, this.m_fltFirstColLeft, this.m_fltLocationY + p_fltHeight, this.m_fltColLeft15 + m_fltCol15, this.m_fltLocationY + p_fltHeight);
        }
        #endregion

        //打印页脚
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
        // 打印开始后，在打印页之前的操作
        private void m_mthBeginPrintSub(PrintEventArgs p_objPrintArg)
        {

        }

        // 打印页
        private void m_mthPrintPageSub(PrintPageEventArgs p_objPrintPageArg)
        {

        }

        // 设置打印内容。
        private void m_mthSetPrintContent(clsNewBabyInRoomRecord p_objContent, clsNewBabyCircsRecord[] p_objCircsContentArr, DateTime p_dtmFirstPrintDate)
        {

        }

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
            g.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, new Font("宋体", 15, FontStyle.Bold), m_objBrush, 320, 70);
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
            int col = e.MarginBounds.Width / 4;
            float fltCol = float.Parse(col.ToString());//打印姓名此列的列宽
            System.Drawing.Graphics g = e.Graphics;
            g.DrawLine(this.m_objPen, m_fltFirstColLeft, p_fltLocationY, m_fltColLeft15 + m_fltCol15, p_fltLocationY);

            p_fltLocationY += m_ftlRowHeight;
            strPrint = "姓名:" + p_objPatient.m_StrName.Trim();

            g.DrawString(strPrint, m_fontBody, m_objBrush, e.MarginBounds.Left, p_fltLocationY);


            strPrint = "分娩日期:";
            if (m_objResult != null && m_objResult.m_objMannoValue != null)
                strPrint += m_objResult.m_objMannoValue.m_dtmChildBirthingDate.ToString("yyyy年MM月dd日");

            g.DrawString(strPrint, m_fontBody, m_objBrush, e.MarginBounds.Left + fltCol * 1 - 20, p_fltLocationY);

            strPrint = "床号:" + p_objPatient.m_strBedCode.Trim();

            g.DrawString(strPrint, m_fontBody, m_objBrush, e.MarginBounds.Left + fltCol * 2 + 50, p_fltLocationY);

            strPrint = "住院号:" + p_objPatient.m_StrHISInPatientID.Trim();

            g.DrawString(strPrint, m_fontBody, m_objBrush, e.MarginBounds.Left + fltCol * 3, p_fltLocationY);

            p_fltLocationY += m_ftlRowHeight;
            //this.m_fltLocationY = p_fltLocationY;// +m_ftlRowHeight;

        }
        #endregion

        #region 打表头
        private void m_mthPrintFormHeader(System.Drawing.Printing.PrintPageEventArgs e, ref float p_objLocationY)
        {
            p_objLocationY += m_ftlRowHeight;
            e.Graphics.DrawLine(this.m_objPen, m_fltFirstColLeft, p_objLocationY, m_fltColLeft15 + m_fltCol15, p_objLocationY);

            e.Graphics.DrawLine(this.m_objPen, m_fltFirstColLeft, p_objLocationY, m_fltFirstColLeft, p_objLocationY + m_ftlRowHeight * 2);
            m_fltDrawStrAtRectangle(false, this.m_fltFirstColLeft, this.m_fltSeconColLeft, "日期", p_objLocationY + 15, 0, e);

            e.Graphics.DrawLine(this.m_objPen, m_fltSeconColLeft, p_objLocationY, m_fltSeconColLeft, p_objLocationY + m_ftlRowHeight * 2);
            m_fltDrawStrAtRectangle(true, this.m_fltSeconColLeft, this.m_fltthColLeft, "产后", p_objLocationY, 0, e);
            m_fltDrawStrAtRectangle(true, this.m_fltSeconColLeft, this.m_fltthColLeft, "日数", p_objLocationY + m_ftlRowHeight, 0, e);

            e.Graphics.DrawLine(this.m_objPen, m_fltthColLeft, p_objLocationY, m_fltthColLeft, p_objLocationY + m_ftlRowHeight * 2);
            m_fltDrawStrAtRectangle(false, this.m_fltthColLeft, this.m_fltFiveColLeft, "子宫", p_objLocationY + 3, 0, e);
            m_fltDrawStrAtRectangle(true, this.m_fltthColLeft, this.m_fltthirColLeft, "宫底", p_objLocationY + m_ftlRowHeight, 0, e);
            m_fltDrawStrAtRectangle(true, this.m_fltthColLeft, this.m_fltthirColLeft, "cm", p_objLocationY + m_ftlRowHeight + 7, 0, e);
            e.Graphics.DrawLine(this.m_objPen, m_fltthirColLeft, p_objLocationY + m_ftlRowHeight, m_fltthirColLeft, p_objLocationY + m_ftlRowHeight * 2);
            m_fltDrawStrAtRectangle(true, this.m_fltthirColLeft, this.m_fltFiveColLeft, "收缩情况", p_objLocationY + m_ftlRowHeight + 2, 0, e);
            e.Graphics.DrawLine(this.m_objPen, m_fltthColLeft, p_objLocationY + m_ftlRowHeight, m_fltFiveColLeft, p_objLocationY + m_ftlRowHeight);

            e.Graphics.DrawLine(this.m_objPen, m_fltFiveColLeft, p_objLocationY, m_fltFiveColLeft, p_objLocationY + m_ftlRowHeight * 2);
            m_fltDrawStrAtRectangle(false, this.m_fltFiveColLeft, this.m_fltNigColLeft, "乳腺", p_objLocationY + 3, 0, e);
            m_fltDrawStrAtRectangle(false, this.m_fltFiveColLeft, this.m_fltSixColLeft, "乳量", p_objLocationY + m_ftlRowHeight + 2, 0, e);

            e.Graphics.DrawLine(this.m_objPen, m_fltSixColLeft, p_objLocationY + m_ftlRowHeight, m_fltSixColLeft, p_objLocationY + m_ftlRowHeight * 2);
            m_fltDrawStrAtRectangle(false, this.m_fltSixColLeft, this.m_fltSenColLeft, "乳胀", p_objLocationY + m_ftlRowHeight + 2, 0, e);

            e.Graphics.DrawLine(this.m_objPen, m_fltSenColLeft, p_objLocationY + m_ftlRowHeight, m_fltSenColLeft, p_objLocationY + m_ftlRowHeight * 2);
            m_fltDrawStrAtRectangle(false, this.m_fltSenColLeft, this.m_fltNigColLeft, "乳头", p_objLocationY + m_ftlRowHeight + 2, 0, e);
            e.Graphics.DrawLine(this.m_objPen, m_fltFiveColLeft, p_objLocationY + m_ftlRowHeight, m_fltNigColLeft, p_objLocationY + m_ftlRowHeight);


            e.Graphics.DrawLine(this.m_objPen, m_fltNigColLeft, p_objLocationY, m_fltNigColLeft, p_objLocationY + m_ftlRowHeight * 2);
            m_fltDrawStrAtRectangle(false, this.m_fltNigColLeft, this.m_fltColLeft11, "恶露", p_objLocationY + 3, 0, e);
            m_fltDrawStrAtRectangle(false, this.m_fltNigColLeft, this.m_fltNiNeColLeft, "量", p_objLocationY + m_ftlRowHeight + 2, 0, e);

            e.Graphics.DrawLine(this.m_objPen, m_fltNiNeColLeft, p_objLocationY + m_ftlRowHeight, m_fltNiNeColLeft, p_objLocationY + m_ftlRowHeight * 2);
            m_fltDrawStrAtRectangle(false, this.m_fltNiNeColLeft, this.m_fltColLeft10, "色", p_objLocationY + m_ftlRowHeight + 2, 0, e);

            e.Graphics.DrawLine(this.m_objPen, m_fltColLeft10, p_objLocationY + m_ftlRowHeight, m_fltColLeft10, p_objLocationY + m_ftlRowHeight * 2);
            m_fltDrawStrAtRectangle(false, this.m_fltColLeft10, this.m_fltColLeft11, "臭味", p_objLocationY + m_ftlRowHeight + 2, 0, e);
            e.Graphics.DrawLine(this.m_objPen, m_fltNigColLeft, p_objLocationY + m_ftlRowHeight, m_fltColLeft11, p_objLocationY + m_ftlRowHeight);

            e.Graphics.DrawLine(this.m_objPen, m_fltColLeft11, p_objLocationY, m_fltColLeft11, p_objLocationY + m_ftlRowHeight * 2);
            m_fltDrawStrAtRectangle(false, this.m_fltColLeft11, this.m_fltColLeft12, "会阴", p_objLocationY + 2, 0, e);
            m_fltDrawStrAtRectangle(false, this.m_fltColLeft11, this.m_fltColLeft12, "情形", p_objLocationY + m_ftlRowHeight, 0, e);

            e.Graphics.DrawLine(this.m_objPen, m_fltColLeft12, p_objLocationY, m_fltColLeft12, p_objLocationY + m_ftlRowHeight * 2);
            m_fltDrawStrAtRectangle(false, this.m_fltColLeft12, this.m_fltColLeft13, "BP", p_objLocationY + 2, 0, e);
            m_fltDrawStrAtRectangle(false, this.m_fltColLeft12, this.m_fltColLeft13, "mmHg", p_objLocationY + m_ftlRowHeight, 0, e);

            e.Graphics.DrawLine(this.m_objPen, m_fltColLeft13, p_objLocationY, m_fltColLeft13, p_objLocationY + m_ftlRowHeight * 2);
            m_fltDrawStrAtRectangle(false, this.m_fltColLeft13, this.m_fltColLeft14, "尿", p_objLocationY + 15, 0, e);

            e.Graphics.DrawLine(this.m_objPen, m_fltColLeft14, p_objLocationY, m_fltColLeft14, p_objLocationY + m_ftlRowHeight * 2);
            m_fltDrawStrAtRectangle(false, this.m_fltColLeft14, this.m_fltColLeft15, "附注", p_objLocationY + 15, 0, e);

            e.Graphics.DrawLine(this.m_objPen, m_fltColLeft15, p_objLocationY, m_fltColLeft15, p_objLocationY + m_ftlRowHeight * 2);
            m_fltDrawStrAtRectangle(false, this.m_fltColLeft15, this.m_fltColLeft15 + this.m_fltCol15, "检查者", p_objLocationY + 15, 0, e);
            e.Graphics.DrawLine(this.m_objPen, m_fltColLeft15 + m_fltCol15, p_objLocationY, m_fltColLeft15 + m_fltCol15, p_objLocationY + m_ftlRowHeight * 2);

            p_objLocationY += m_ftlRowHeight * 2;
            e.Graphics.DrawLine(this.m_objPen, m_fltFirstColLeft, p_objLocationY, m_fltColLeft15 + m_fltCol15, p_objLocationY);


        }

        void m_mthPrintHLine(System.Drawing.Graphics g, float p_objLocationY, float fltRealHeight)
        {
            g.DrawLine(this.m_objPen, m_fltFirstColLeft, p_objLocationY, m_fltFirstColLeft, p_objLocationY + fltRealHeight);
            g.DrawLine(this.m_objPen, m_fltSeconColLeft, p_objLocationY, m_fltSeconColLeft, p_objLocationY + fltRealHeight);
            g.DrawLine(this.m_objPen, m_fltthColLeft, p_objLocationY, m_fltthColLeft, p_objLocationY + fltRealHeight);
            g.DrawLine(this.m_objPen, m_fltthirColLeft, p_objLocationY, m_fltthirColLeft, p_objLocationY + fltRealHeight);
            g.DrawLine(this.m_objPen, m_fltFiveColLeft, p_objLocationY, m_fltFiveColLeft, p_objLocationY + fltRealHeight);
            g.DrawLine(this.m_objPen, m_fltSixColLeft, p_objLocationY, m_fltSixColLeft, p_objLocationY + fltRealHeight);
            g.DrawLine(this.m_objPen, m_fltSenColLeft, p_objLocationY, m_fltSenColLeft, p_objLocationY + fltRealHeight);
            g.DrawLine(this.m_objPen, m_fltNigColLeft, p_objLocationY, m_fltNigColLeft, p_objLocationY + fltRealHeight);
            g.DrawLine(this.m_objPen, m_fltNiNeColLeft, p_objLocationY, m_fltNiNeColLeft, p_objLocationY + fltRealHeight);
            g.DrawLine(this.m_objPen, m_fltColLeft10, p_objLocationY, m_fltColLeft10, p_objLocationY + fltRealHeight);
            g.DrawLine(this.m_objPen, m_fltColLeft11, p_objLocationY, m_fltColLeft11, p_objLocationY + fltRealHeight);
            g.DrawLine(this.m_objPen, m_fltColLeft12, p_objLocationY, m_fltColLeft12, p_objLocationY + fltRealHeight);
            g.DrawLine(this.m_objPen, m_fltColLeft13, p_objLocationY, m_fltColLeft13, p_objLocationY + fltRealHeight);
            g.DrawLine(this.m_objPen, m_fltColLeft14, p_objLocationY, m_fltColLeft14, p_objLocationY + fltRealHeight);
            g.DrawLine(this.m_objPen, m_fltColLeft15, p_objLocationY, m_fltColLeft15, p_objLocationY + fltRealHeight);
            g.DrawLine(this.m_objPen, m_fltColLeft15 + m_fltCol15, p_objLocationY, m_fltColLeft15 + m_fltCol15, p_objLocationY + fltRealHeight);
        }
        #endregion


        private float m_fltDrawStrAtRectangle(bool p_blnIsMeasureH, float col1, float col2, string strPrint, float LocationY, int signflg, System.Drawing.Printing.PrintPageEventArgs e)
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
                rect.Height = s.Height + 6;
            StringFormat sf = new StringFormat(StringFormatFlags.FitBlackBox);
            sf.Alignment = StringAlignment.Center;
            if (signflg == 1)
            {
                Image imgEmpSig = ImageSignature.GetEmpSigImage(strPrint);
                if (imgEmpSig != null)
                {
                    e.Graphics.DrawImage(imgEmpSig, (int)enmRectangleInfo.LeftX + 690, LocationY+2, 60, 26);
                }
                else
                {
                    e.Graphics.DrawString(strPrint, m_font, this.m_objBrush, rect, sf);
                }
            }
            else
                e.Graphics.DrawString(strPrint, m_font, this.m_objBrush, rect, sf);
            return rect.Height;
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

        }
        private float m_fltGetMaxValue(float a, float b)
        {
            return a > b ? a : b;
        }

    }
}
