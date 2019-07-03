using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using com.digitalwave.clsRecordsService;
namespace iCare
{
    /// <summary>
    ///  静脉特殊化疗用药观察记录表
    /// </summary>
    public class clsVeinSpecialUseDrugPrintTool : infPrintRecord
    {
        private bool m_blnIsFromDataSource = true;//表明是从数据库读取还是从文件直接提取信息
        private bool m_blnWantInit = true;
        private clsBaseCaseHistoryDomain m_objRecordsDomain;
        //private com.digitalwave.clsRecordsService.clsVeinSpecialUseDrug_MainService m_objMainSvc;
        private clsVeinSpecialUseDrugValue[] m_objResultArr = null;
        private clsPatient m_objPatient = null;
        DateTime m_dtInHos;
        //是否外部打印
        public bool isOutPrint = false;
        public string m_strDept = "";//科室
        public string m_strBegNo = "";//床号
        public string m_strName = "";//姓名
        public string m_strAge = "";//Age
        public string m_strInHosNo = "";//住院号
        public string m_strBeginTime = "";//输液开始时间
        public string m_strEndTime = "";//输液end时间
        public string m_strID_CHR = "";//ID_CHR
        public clsVeinSpecialUseDrugPrintTool()
        {
            //m_objMainSvc = new com.digitalwave.clsRecordsService.clsVeinSpecialUseDrug_MainService();
        }
        ///<summary>
        ///变量：特殊记录数组下际
        ///</summary>
        int m_intRecordIndex = 0;

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
            if (isOutPrint == true)
            {
                //从主表中获取指定CheckDate的记录
                com.digitalwave.clsRecordsService.clsVeinSpecialUseDrug_MainService m_objMainSvc =
                    (com.digitalwave.clsRecordsService.clsVeinSpecialUseDrug_MainService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsRecordsService.clsVeinSpecialUseDrug_MainService));

                m_objMainSvc.m_lngGetCheckDateRecord(p_objPatient.m_StrInPatientID, p_dtmInPatientDate.ToString(), p_dtmOpenDate, out m_objResultArr);
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
        public void m_mthSetPrintContent(object p_objPrintRecord)
        {
            
            m_mthInitDataSource((clsVeinSpecialUseDrugValue[])p_objPrintRecord);
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
                if (m_objResultArr == null)
                {
                    clsPublicFunction.ShowInformationMessageBox("当从数据库读取时,调用m_objGetPrintInfo之前请首先调用m_mthSetPrintInfo函数");
                    return null;
                }

                if (m_blnWantInit)
                    m_mthInitPrintContent();
            }

            return m_objResultArr;
           
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
            m_intCurrentPageIndex = 1;
            if (this.Source != null)
                m_strTitle = Source.TableName;//默认标题为"表名"

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
            m_mthInitClientSize(e);
            mthInitColLocation(e, this.m_objRectangle);
            mthPrintTitle(e, this.m_objRectangle);
            mthPrintFormTitle(e);
            m_mthPrintAllPage(e, ref this.m_fltLocationY, this.m_dtSource);
        }

        #endregion

        #region 打印每页

        private void m_mthPrintAllPage(System.Drawing.Printing.PrintPageEventArgs e, ref float p_objLocationY)
        {



        }

        #endregion

        /// <summary>
        /// 打印结束。一般使用它来更新数据库信息。
        /// </summary>
        /// <param name="p_objPrintArg">此处p_objPrintArg要求为PrintEventArgs类型的对象</param>
        public void m_mthEndPrint(object p_objPrintArg)
        {
            if (m_strID_CHR != "")
                if (!((PrintEventArgs)p_objPrintArg).Cancel)
                {
                    clsVeinSpecialUseDrug_MainService objServ =
                        (clsVeinSpecialUseDrug_MainService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsVeinSpecialUseDrug_MainService));

                    objServ.m_lngUpdateFirstPrintDateNew(this.m_strID_CHR, DateTime.Now);
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

        // 打印结束时的操作
        private void m_mthEndPrintSub(PrintEventArgs p_objPrintArg)
        {
            //如果打印成功，查找有无需要更新的时间，如果有，更新时间。 

            m_mthResetWhenEndPrint();
        }

        /// <summary>
        /// 每次打印结束之后的复位,无论是打印当前页或者打印全部.
        /// </summary>
        private void m_mthResetWhenEndPrint()
        {

        }


        #region user print define

        #region 属性
        /// <summary>
        ///  获取或设置一个值，该值指示是横向还是纵向打印该页。 
        /// </summary>
        public bool Landscape
        {
            get
            {
                return this.printDocument1.DefaultPageSettings.Landscape;
            }
            set
            {
                this.printDocument1.DefaultPageSettings.Landscape = value;
            }
        }
        /// <summary>
        /// 数据源
        /// </summary>
        public DataTable Source
        {
            get
            {
                return m_dtSource;
            }
            set
            {
                m_dtSource = value;

            }
        }
        /// <summary>
        /// 打印的标题目
        /// </summary>
        public string Title
        {
            get
            {
                return m_strTitle;
            }
            set
            {
                m_strTitle = value;
            }
        }
        /// <summary>
        /// 打印的日期(string)
        /// </summary>
        public string PrintDate
        {
            get
            {
                return m_strPrintDate;
            }
            set
            {
                m_strPrintDate = value;
            }
        }
        /// <summary>
        /// 记录打印的高度落点位
        /// </summary>
        public float LocationY
        {
            get
            {
                return m_fltLocationY;
            }
            set
            {
                m_fltLocationY = value;
            }
        }
        /// <summary>
        /// 暂存每列的显示宽度%(百分比)
        /// </summary>
        public float[] ColumnPercentArr
        {
            get
            {
                return m_fltColumnPercentArr;
            }
            set
            {
                m_fltColumnPercentArr = value;
                m_blnUseColumnPercent = false;
            }
        }
        /// <summary>
        /// 显示总宽度
        /// </summary>
        public float ColumnTotalWidth
        {
            get
            {
                return m_fltColumnTotalWidth;
            }
            set
            {
                m_fltColumnTotalWidth = value;
                m_blnUseDefaultTotalWidth = false;
            }
        }

        /// <summary>
        /// 打印区域默认为(x,y,w,h:20,100,787 or 1109,1049 or 707)
        /// </summary>
        public Rectangle RectangleSize
        {
            get
            {
                return m_objRectangle;
            }
            set
            {
                m_objRectangle = value;
                m_blnUseDefaultjRectangle = false;
            }
        }
        #endregion

        #region 变量
        /// <summary>
        /// 用于全屏显示预览
        /// </summary>
        private Form frm = new Form();
        /// <summary>
        /// 是否使用默认打印区域Rectangle
        /// </summary>
        private bool m_blnUseDefaultjRectangle = true;
        /// <summary>
        /// 存起打印区域
        /// </summary>
        private Rectangle m_objRectangle;
        /// <summary>
        /// 存起每列的相应宽度
        /// </summary>
        private float[] m_fltEachColWidth;
        /// <summary>
        /// 存起每列的相应Left坐标
        /// </summary>
        private float[] m_fltEachColLeft;
        /// <summary>
        /// 平均宽度
        /// </summary>
        private float m_fltAvgColWidth;
        /// <summary>
        /// 显示总宽度
        /// </summary>
        private float m_fltColumnTotalWidth;
        /// <summary>
        /// 是否使用默认总宽度
        /// </summary>
        private bool m_blnUseDefaultTotalWidth = true;
        /// <summary>
        /// 暂存每列的显示宽度%(百分比)
        /// </summary>
        private float[] m_fltColumnPercentArr;
        /// <summary>
        /// 是否使用默认的设置每列的显示宽度%(百分比)
        /// </summary>
        private bool m_blnUseColumnPercent = true;
        /// <summary>
        /// 数据源
        /// </summary>	
        private DataTable m_dtSource;

        /// <summary>
        /// 打印预览对象
        /// </summary>	
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;

        /// <summary>
        /// 打印文档对象
        /// </summary>	
        private System.Drawing.Printing.PrintDocument printDocument1;

        #region 打印设置相关的变量

        /// <summary>
        /// 打印的标题目
        /// </summary>	
        private string m_strTitle;

        /// <summary>
        /// 打印的日期
        /// </summary>	
        private string m_strPrintDate;

        /// <summary>
        /// 记录打印的高度落点位
        /// </summary>	
        private float m_fltLocationY;

        ///<summary>
        ///变量：打印的当前页数
        ///</summary>
        private int m_intCurrentPageIndex = 0;

        ///<summary>
        ///变量：打印的总页数
        ///</summary>
        private int m_intPageTotal = 0;

        ///<summary>
        ///变量：要打印的字
        ///</summary>
        private string m_strPrint = "";//要打印的字
        ///<summary>
        ///变量：字与线间的位置高 ：间距
        ///</summary>
        private float m_fltZijiHeight = 3; //字与线间的位置高 ：间距
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
        private float m_fltZiJiWide = 1;// 字与表格的左距离：间距
        ///<summary>
        ///变量：行高
        ///</summary>
        private float m_ftlRowHeight;
        ///<summary>
        ///变量：字符串的格式化
        ///</summary>
        private StringFormat m_sf = new StringFormat();

        #region 设置打印列宽与每列的横坐标变量

        ///<summary>
        ///变量：第1列宽度
        ///</summary>
        float m_fltFirstColLeft; //第1列LEFT

        #endregion

        /// <summary>
        /// Pen对象
        /// </summary>
        private Pen m_objPen = new Pen(Color.Black);
        /// <summary>
        /// brush
        /// </summary>	
        private System.Drawing.Brush m_objBrush = System.Drawing.Brushes.Black;

        /// <summary>
        /// 打印标题的字体
        /// </summary>	
        private System.Drawing.Font m_fontTitle = new System.Drawing.Font("simsun", 20,FontStyle.Bold);

        /// <summary>
        /// 打印正文的字体
        /// </summary>	
        private System.Drawing.Font m_fontBody = new System.Drawing.Font("simsun", 12);

        #endregion

        #endregion

        #region 方法:打印标题
        /// <summary>
        /// 打印标题
        /// </summary>
        /// <param name="e">PrintPageEventArgs</param>
        /// <param name="p_objRectangle">打印区域</param>
        private void mthPrintTitle(PrintPageEventArgs e, Rectangle p_objRectangle)
        {
            System.Drawing.Graphics g = e.Graphics;
            e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, new Font("SimSun", 12), m_objBrush, 320, 30);
            e.Graphics.DrawString("静脉特殊化疗用药观察记录表", new Font("SimSun", 18, FontStyle.Bold), m_objBrush, 225,70);
            string strPrint = "";
            //com.digitalwave.iCare.common.clsCommmonInfo com = new com.digitalwave.iCare.common.clsCommmonInfo();
            //string HospitalTitle = "";
            //HospitalTitle = com.m_strGetHospitalTitle();
            
            //strPrint = HospitalTitle + this.m_strTitle;
            SizeF objSize = g.MeasureString(strPrint, this.m_fontTitle);
            //g.DrawString(strPrint, this.m_fontTitle, m_objBrush, p_objRectangle.Left + (p_objRectangle.Width - objSize.Width) / 2, p_objRectangle.Top);
            this.m_fltLocationY = p_objRectangle.Top + objSize.Height+30;


            int col = e.MarginBounds.Width / 4;
            float fltCol = float.Parse(col.ToString());//打印姓名此列的列宽		

            strPrint = "科室:" + m_strDept.Trim();
            objSize = g.MeasureString(strPrint, this.m_fontBody);
            g.DrawString(strPrint, m_fontBody, m_objBrush, e.MarginBounds.Left -30, m_fltLocationY);

            strPrint = "床号:" + m_objPatient.m_strBedCode.Trim();
            objSize = g.MeasureString(strPrint, this.m_fontBody);
            g.DrawString(strPrint, m_fontBody, m_objBrush, e.MarginBounds.Left + fltCol * 1 + 40, m_fltLocationY);

            strPrint = "姓名:" + m_objPatient.m_StrName.Trim();
            objSize = g.MeasureString(strPrint, this.m_fontBody);
            g.DrawString(strPrint, m_fontBody, m_objBrush, e.MarginBounds.Left + fltCol * 2 + 30, m_fltLocationY);
            strPrint = "年龄:" + m_objPatient.m_ObjPeopleInfo.m_StrAgeLong.Trim();
            objSize = g.MeasureString(strPrint, this.m_fontBody);
            g.DrawString(strPrint, m_fontBody, m_objBrush, e.MarginBounds.Left + fltCol * 3 + 25, m_fltLocationY);
            this.m_fltLocationY += this.m_ftlRowHeight;

            strPrint = "住院号:" + m_objPatient.m_StrHISInPatientID.Trim();
            objSize = g.MeasureString(strPrint, this.m_fontBody);
            g.DrawString(strPrint, m_fontBody, m_objBrush, e.MarginBounds.Left-30, m_fltLocationY);

            strPrint = "输液开始时间:" + m_strBeginTime.Trim();
            objSize = g.MeasureString(strPrint, this.m_fontBody);
            g.DrawString(strPrint, m_fontBody, m_objBrush, e.MarginBounds.Left + fltCol * 1 - 55, m_fltLocationY);

            strPrint = "输液结束时间:" + m_strEndTime.Trim();
            objSize = g.MeasureString(strPrint, this.m_fontBody);
            g.DrawString(strPrint, m_fontBody, m_objBrush, e.MarginBounds.Left + fltCol * 2 + 70, m_fltLocationY);

            this.m_fltLocationY += this.m_ftlRowHeight;
        }
        #endregion

        #region 方法:打印页脚
        /// <summary>
        /// 方法:打印页脚
        /// </summary>		
        private void mthPrintFoot(PrintPageEventArgs e)
        {
            m_strPrint = string.Format("第{0}页/共{1}页", this.m_intCurrentPageIndex, this.m_intPageTotal);
            float fltWith = e.Graphics.MeasureString(m_strPrint, this.m_fontBody).Width;
            fltWith = float.Parse(this.m_objRectangle.Width.ToString()) - fltWith;
            e.Graphics.DrawString(m_strPrint, this.m_fontBody, this.m_objBrush, fltWith / 2, this.m_fltLocationY + 5);

        }
        #endregion

        #region 初始化每一列显示的宽度百分比值
        /// <summary>
        ///初始化每一列显示的宽度百分比值(默认平均分)
        /// </summary>
        private void m_mthInitEachColumnAvgWithPercent(int p_intColumnCount)
        {
            m_fltColumnPercentArr = new float[p_intColumnCount];
        }
        #endregion

        #region 方法:初始化每一列的位置
        /// <summary>
        /// 方法:初始化每一列的位置(p_objRectangle打印区域)
        /// </summary>		
        private void mthInitColLocation(PrintPageEventArgs e, Rectangle p_objRectangle)
        {
            #region 设置打印列宽与每列的横坐标
            if (ColumnPercentArr == null)
            {
                float[] fltArrColumnPercent = new float[9];

                fltArrColumnPercent[0] = 0.055555556F; // -0.055555556F
                fltArrColumnPercent[1] = 0.111111112F;
                fltArrColumnPercent[2] = 0.055555556F;// -0.055555556F
                fltArrColumnPercent[3] = 0.111111112F;//
                fltArrColumnPercent[4] = 0.111111112F;
                fltArrColumnPercent[5] = 0.111111112F;
                fltArrColumnPercent[6] = 0.111111112F;//
                fltArrColumnPercent[7] = 0.111111112F + 0.055555556F + 0.055555556F + 0.022222226F;//+0.111111112F
                fltArrColumnPercent[8] = 0.111111112F - 0.022222226F;
                ColumnPercentArr = fltArrColumnPercent;
            }
            float dblColumnCount = float.Parse(m_fltColumnPercentArr.Length.ToString());
            float dblAvg = 0;
            //			if(m_blnUseDefaultTotalWidth)
            //			{
            m_fltColumnTotalWidth = float.Parse(Convert.ToString(p_objRectangle.Width));

            //			}						
            dblAvg = m_fltColumnTotalWidth / dblColumnCount;
            float dblPercent = dblAvg / m_fltColumnTotalWidth;
            if (m_blnUseColumnPercent)
            {
                for (int i = 0; i < m_fltColumnPercentArr.Length; ++i)
                {
                    m_fltColumnPercentArr[i] = dblPercent;
                }
            }

            m_fltEachColWidth = new float[m_fltColumnPercentArr.Length];
            m_fltEachColLeft = new float[m_fltColumnPercentArr.Length];
            m_fltFirstColLeft = p_objRectangle.Left; //第1列Left坐际
            for (int j = 0; j < m_fltColumnPercentArr.Length; ++j)
            {
                m_fltEachColWidth[j] = m_fltColumnPercentArr[j] * m_fltColumnTotalWidth;
                if (j == 0)
                    m_fltEachColLeft[j] = m_fltFirstColLeft;
                else
                    m_fltEachColLeft[j] = m_fltEachColLeft[j - 1] + m_fltEachColWidth[j - 1];
            }
            #endregion

            m_objsize = e.Graphics.MeasureString("测试", this.m_fontBody);
            m_fltZiHeight = m_objsize.Height;// 字高
            //			m_ftlRowHeight =  m_fltZiHeight+10 ;//行高
            m_ftlRowHeight = m_fltZijiHeight * 2 + m_fltZiHeight;//行高

        }
        #endregion

        #region 画线
        /// <summary>
        /// 画一行线
        /// </summary>
        /// <param name="p_intColumnCount">列总数</param>
        private void m_mthDrawLines(PrintPageEventArgs e, int p_intColumnCount)
        {
            Graphics g = e.Graphics;
            for (int i1 = 0; i1 < p_intColumnCount; i1++)
            {
                g.DrawLine(this.m_objPen, m_fltEachColLeft[i1], m_fltLocationY, m_fltEachColLeft[i1], m_fltLocationY + this.m_ftlRowHeight);
            }
            g.DrawLine(this.m_objPen, m_fltEachColLeft[p_intColumnCount - 1] + m_fltEachColWidth[p_intColumnCount - 1], m_fltLocationY, m_fltEachColLeft[p_intColumnCount - 1] + m_fltEachColWidth[p_intColumnCount - 1], m_fltLocationY + this.m_ftlRowHeight);
            g.DrawLine(this.m_objPen, m_fltEachColLeft[0], this.m_fltLocationY + this.m_ftlRowHeight, m_fltEachColLeft[p_intColumnCount - 1] + m_fltEachColWidth[p_intColumnCount - 1], this.m_fltLocationY + this.m_ftlRowHeight);

        }
        #endregion

        #region 在两个X坐标区域中.画"字符"
        /// <summary>
        /// 在两个X坐标区域中.画"字符"
        /// </summary>
        /// <param name="col1">x1</param>
        /// <param name="col2">x2</param>
        /// <param name="strPrint">字符</param>
        /// <param name="LocationY">y</param>
        /// <param name="e"></param>
        private void m_mthDrawStrAtRectangle(float col1, float col2, string strPrint, float LocationY, System.Drawing.Printing.PrintPageEventArgs e)
        {
            System.Drawing.Graphics g = e.Graphics;
            System.Drawing.Font objfont = new System.Drawing.Font("宋体", 10);
            SizeF s = g.MeasureString(strPrint, objfont);
            if (s.Width >= col2 - col1)
            {
                objfont = new System.Drawing.Font("宋体", 8);
                s = g.MeasureString(strPrint, objfont);

            }
            float ji = col2 - col1;
            float X = col1 + ji / 2 - s.Width / 2;
            //			float Y = LocationY + this.m_fltZijiHeight;	
            float Y = LocationY + m_ftlRowHeight / 2 - s.Height / 2;
            if (s.Width > ji)
            {
                objfont = new System.Drawing.Font("宋体", 8);
                float flt = ji / g.MeasureString("测", objfont).Width;
                int intcharCount = Convert.ToInt32(flt) + 1;
                float y1 = LocationY + m_ftlRowHeight / 4 - s.Height / 2 + 2;
                float y2 = LocationY + 3 * m_ftlRowHeight / 4 - s.Height / 2;
                string strPrint1 = strPrint.Substring(0, intcharCount);
                float x1 = col1 + ji / 2 - g.MeasureString(strPrint1, objfont).Width / 2;
                g.DrawString(strPrint1, objfont, this.m_objBrush, x1, y1);

                string strPrint2 = "";
                if (strPrint.Length - intcharCount <= intcharCount)
                    strPrint2 = strPrint.Substring(intcharCount);
                else
                    strPrint2 = strPrint.Substring(intcharCount, intcharCount);
                //				x1 =  col1 + ji/2 - g.MeasureString(strPrint2,objfont).Width/2;
                x1 = col1 + 3;
                g.DrawString(strPrint2, objfont, this.m_objBrush, x1, y2);

            }
            else
            {
                g.DrawString(strPrint, objfont, this.m_objBrush, X, Y);
            }

        }
        #endregion

        #region 方法:打印表头
        /// <summary>
        /// 方法:打印表头
        /// </summary>		
        private void mthPrintFormTitle(PrintPageEventArgs e)
        {
            string objStr = "";
            int intColumnCount = this.m_dtSource.Columns.Count;
            System.Drawing.Graphics g = e.Graphics;
            g.DrawLine(this.m_objPen, m_fltEachColLeft[0], m_fltLocationY, m_fltEachColLeft[intColumnCount - 1] + m_fltEachColWidth[intColumnCount - 1], m_fltLocationY);
            for (int i1 = 0; i1 < intColumnCount; i1++)
            {
                objStr = this.m_dtSource.Columns[i1].ColumnName;
                if (i1 == intColumnCount - 1)
                {
                    m_mthDrawStrAtRectangle(m_fltEachColLeft[i1], m_fltEachColLeft[i1] + m_fltEachColWidth[i1], objStr, m_fltLocationY, e);
                }
                else
                {
                    m_mthDrawStrAtRectangle(m_fltEachColLeft[i1], m_fltEachColLeft[i1 + 1], objStr, m_fltLocationY, e);
                }
            }
            m_mthDrawLines(e, intColumnCount);
            m_fltLocationY += this.m_ftlRowHeight;

        }
        #endregion

        #region 初始化可打印区域x,y,width,height
        /// <summary>
        /// 初始化可打印区域x,y,width,height
        /// </summary>
        /// <param name="e"></param>
        private void m_mthInitClientSize(PrintPageEventArgs e)
        {
            if (m_blnUseDefaultjRectangle)
            {
                //				e.PageSettings.Margins.Left = 5;
                //				e.PageSettings.Margins.Right = 5;
                int d = e.MarginBounds.Bottom;
                int d2 = e.MarginBounds.Right;
                int d3 = e.MarginBounds.Width;
                int d4 = e.MarginBounds.Left;
                this.m_objRectangle.X = e.PageBounds.Left + 20; //第1列Left坐际20
                this.m_objRectangle.Y = e.MarginBounds.Top;  //100
                this.m_objRectangle.Width = e.PageBounds.Width - 60;//787 or 1109
                this.m_objRectangle.Height = e.MarginBounds.Height + 80;//1049 or 707
            }
        }
        #endregion

        #region 打印每页
        private int i = 0;
        /// <summary>
        /// 打印每页
        /// </summary>
        /// <param name="e">PrintPageEventArgs</param>
        /// <param name="p_objLocationY">Y</param>
        /// <param name="p_dt">数据源</param>
        private void m_mthPrintAllPage(System.Drawing.Printing.PrintPageEventArgs e, ref float p_objLocationY, DataTable p_dt)
        {
            int p_intRowsCount = p_dt.Rows.Count;

            string strPrint = "";
            //计算第一页还能打印出多少条
            int intRowCount = Convert.ToInt32((float.Parse(this.m_objRectangle.Height.ToString()) - p_objLocationY) / m_ftlRowHeight);
            #region 若没有数据,则打印空表格
            if (p_intRowsCount == 0)
            {
                for (int k = 0; k < intRowCount; ++k)
                {
                    m_mthDrawLines(e, p_dt.Columns.Count);
                    p_objLocationY += this.m_ftlRowHeight;
                }
                return;

            };
            #endregion
            if (p_intRowsCount % intRowCount > 0)
                m_intPageTotal = p_intRowsCount / intRowCount + 1;
            else
                m_intPageTotal = p_intRowsCount / intRowCount;

            if (m_intCurrentPageIndex == 1)//第一页
            {
                for (i = 0; i < p_intRowsCount && i < intRowCount; i++)
                {
                    #region draw one row
                    for (int j = 0; j < p_dt.Columns.Count; ++j)
                    {
                        strPrint = p_dt.Rows[i][j].ToString();
                        if (j == p_dt.Columns.Count - 1)
                        {
                            m_mthDrawStrAtRectangle(m_fltEachColLeft[j], m_fltEachColLeft[j] + m_fltEachColWidth[j], strPrint, p_objLocationY, e);
                        }
                        else
                        {
                            m_mthDrawStrAtRectangle(m_fltEachColLeft[j], m_fltEachColLeft[j + 1], strPrint, p_objLocationY, e);
                        }
                    }
                    #endregion
                    m_mthDrawLines(e, p_dt.Columns.Count);
                    p_objLocationY += this.m_ftlRowHeight;
                }
                mthPrintFoot(e);
                //判断是否多页
                if (i < p_intRowsCount)
                {
                    m_intCurrentPageIndex++;
                    e.HasMorePages = true;
                    return;
                }
            }
            else
            {
                int temp = i;
                #region draw one row
                for (; i < p_intRowsCount && i < intRowCount + temp; i++)
                {
                    #region draw one row
                    for (int j = 0; j < p_dt.Columns.Count; ++j)
                    {
                        strPrint = p_dt.Rows[i][j].ToString();
                        if (j == p_dt.Columns.Count - 1)
                        {
                            m_mthDrawStrAtRectangle(m_fltEachColLeft[j], m_fltEachColLeft[j] + m_fltEachColWidth[j], strPrint, p_objLocationY, e);
                        }
                        else
                        {
                            m_mthDrawStrAtRectangle(m_fltEachColLeft[j], m_fltEachColLeft[j + 1], strPrint, p_objLocationY, e);
                        }
                    }
                    #endregion
                    m_mthDrawLines(e, p_dt.Columns.Count);
                    p_objLocationY += this.m_ftlRowHeight;
                }
                #endregion
                mthPrintFoot(e);
                //判断是否多页
                if (i < p_intRowsCount)
                {
                    m_intCurrentPageIndex++;
                    e.HasMorePages = true;
                    return;
                }
                else
                {
                    m_intCurrentPageIndex = 1;
                }

            }
        }
        #endregion

        #region 初始化数据源
        /// <summary>
        /// 初始化数据源
        /// </summary>			
        /// <param name="p_dt">打印的数据源</param>
        public void m_mthSetDataSource(DataTable p_dt)
        {
            Source = p_dt;
            m_strTitle = p_dt.TableName;//默认标题为"表名"
            m_fltColumnPercentArr = new float[p_dt.Columns.Count];

        }

        /// <summary>
        /// 初始化数据源
        /// </summary>
        /// <param name="p_dt">打印的数据源</param>
        /// <param name="p_fltColumnPercentArr">每列显示宽度百分比</param>
        public void m_mthSetDataSource(DataTable p_dt, float[] p_fltColumnPercentArr)
        {
            Source = p_dt;
            m_strTitle = p_dt.TableName; //默认标题为"表名"
            ColumnPercentArr = p_fltColumnPercentArr;

        }
        #endregion

        #region 生成导出报表要用到的DataTable
        /// <summary>
        /// 方法：生成导出报表要用到的DataTable
        /// </summary>
        private DataTable m_mthCreateTable()
        {
            DataTable dt = new DataTable("静脉特殊化疗用药观察记录表");
            System.Data.DataColumn dc = new DataColumn("日期");
            dt.Columns.Add(dc);
            dc = new DataColumn("药名");
            dt.Columns.Add(dc);
            dc = new DataColumn("滴/分");
            dt.Columns.Add(dc);
            dc = new DataColumn("巡视时间");
            dt.Columns.Add(dc);
            dc = new DataColumn("穿刺点正常");
            dt.Columns.Add(dc);
            dc = new DataColumn("穿刺点异常");
            dt.Columns.Add(dc);
            dc = new DataColumn("是否解决");
            dt.Columns.Add(dc);
            dc = new DataColumn("备注");
            dt.Columns.Add(dc);
            dc = new DataColumn("签名");
            dt.Columns.Add(dc);
            return dt;
        }
        #endregion

        #region 初始化数据源：外部打引用
        /// <summary>
        /// 初始化数据源：外部打引用
        /// </summary>
        /// <param name="p_objPatient"></param>
        protected void m_mthInitDataSource(clsVeinSpecialUseDrugValue[] p_objPrintRecordArr)
        {
            //isOutPrint = true;//外部打印
            DataTable dtSouce = m_mthCreateTable();
            //给数据源添加数据
            m_mthSetDataSource(dtSouce, p_objPrintRecordArr);

            float[] fltArrColumnPercent = new float[9];
            fltArrColumnPercent[0] = 0.055555556F; // -0.055555556F
            fltArrColumnPercent[1] = 0.111111112F;
            fltArrColumnPercent[2] = 0.055555556F;// -0.055555556F
            fltArrColumnPercent[3] = 0.111111112F;//
            fltArrColumnPercent[4] = 0.111111112F;
            fltArrColumnPercent[5] = 0.111111112F;
            fltArrColumnPercent[6] = 0.111111112F;//
            fltArrColumnPercent[7] = 0.111111112F + 0.055555556F + 0.055555556F + 0.022222226F;//+0.111111112F
            fltArrColumnPercent[8] = 0.111111112F - 0.022222226F;
            this.Source = dtSouce;
            this.ColumnPercentArr = fltArrColumnPercent;
            if (m_objPatient != null)
            {
                m_strDept = m_objPatient.m_ObjInBedInfo.m_ObjLastDeptInfo.m_ObjDept.m_StrDeptName;//科室
                m_strBegNo = m_objPatient.m_strBedCode;//床号
                m_strName = m_objPatient.m_StrName;//姓名
                m_strAge = m_objPatient.m_ObjPeopleInfo.m_StrAge;//Age
                m_strInHosNo = m_objPatient.m_StrHISInPatientID;//住院号
            }
            else
            {
                m_strDept = string.Empty;//科室
                m_strBegNo = string.Empty;//床号
                m_strName = string.Empty;//姓名
                m_strAge = string.Empty;//Age
                m_strInHosNo = string.Empty;//住院号
            }

            m_strBeginTime = p_objPrintRecordArr[0].m_dtmFluidBEGINTIME_DATE.ToString("yyyy-MM-dd HH:mm:ss");//输液开始时间
            m_strEndTime = p_objPrintRecordArr[0].m_dtmfluidEndTIME_DATE.ToString("yyyy-MM-dd HH:mm:ss");//输液结束时间
        }
        #endregion

        #region 给数据源添加数据
        private void m_mthSetDataSource(DataTable p_dt, clsVeinSpecialUseDrugValue[] p_objPrintRecordArr)
        {
            if (m_objPatient == null) return;

            try
            {
                if (p_objPrintRecordArr == null)
                {
                    return;
                }
                string strConvert="";
                for (int i1 = 0; i1 < p_objPrintRecordArr.Length; i1++)
                {
                    clsVeinSpecialUseDrugValue m_objRecord = p_objPrintRecordArr[i1];
                    if (m_objRecord.m_strBEGINTIME_DATE != null)
                    {
                        object[] objDataArr = new object[9];
                        //如果下条记录的日期与上条一样则不显示
                        if (strConvert != Convert.ToDateTime(m_objRecord.m_strBEGINTIME_DATE).Day.ToString() + "/" + Convert.ToDateTime(m_objRecord.m_strBEGINTIME_DATE).Month.ToString())
                        {
                            strConvert = Convert.ToDateTime(m_objRecord.m_strBEGINTIME_DATE).Day.ToString() + "/" + Convert.ToDateTime(m_objRecord.m_strBEGINTIME_DATE).Month.ToString();
                            objDataArr[0] = strConvert;
                        }
                        else
                        {
                            objDataArr[0] = null;//日期
                        }
                        objDataArr[1] = m_objRecord.m_strMEDICINENAME_CHR;//药名
                        objDataArr[2] = m_objRecord.m_strDROP_CHR;//滴/分
                        objDataArr[3] = Convert.ToDateTime(m_objRecord.m_strBEGINTIME_DATE).ToString("HH:mm");//巡视时间
                        objDataArr[4] = m_objRecord.m_strINGEAR_CHR;//穿刺点正常
                        objDataArr[5] = m_objRecord.m_strABNORMITY_CHR;//穿刺点异常
                        objDataArr[6] = m_objRecord.m_strSOLVE_CHR;//是否解决
                        objDataArr[7] = m_objRecord.m_strREMARK_CHR;//备注
                        objDataArr[8] = m_objRecord.m_strUNDERWRITE_CHR;//签名
                        //备注栏每行显示12个字符
                        if (m_objRecord.m_strREMARK_CHR.Length > 12)
                        {
                            objDataArr[7] = m_objRecord.m_strREMARK_CHR.Substring(0, 12);
                            p_dt.BeginLoadData();
                            p_dt.LoadDataRow(objDataArr, true);
                            p_dt.EndLoadData();

                            objDataArr[0] = null;
                            objDataArr[1] = null;
                            objDataArr[2] = null;
                            objDataArr[3] = null;
                            objDataArr[4] = null;
                            objDataArr[5] = null;
                            objDataArr[6] = null;
                            //objDataArr[7] = null;
                            objDataArr[8] = null;

                            m_objRecord.m_strREMARK_CHR = m_objRecord.m_strREMARK_CHR.Substring(12);
                            while (m_objRecord.m_strREMARK_CHR.Length > 12)
                            {
                                string strTem = m_objRecord.m_strREMARK_CHR.Substring(0,12);
                                objDataArr[7] = strTem;
                                p_dt.BeginLoadData();
                                p_dt.LoadDataRow(objDataArr, true);
                                p_dt.EndLoadData();
                                m_objRecord.m_strREMARK_CHR = m_objRecord.m_strREMARK_CHR.Substring(12);
                            }
                            objDataArr[7] = m_objRecord.m_strREMARK_CHR;
                            p_dt.BeginLoadData();
                            p_dt.LoadDataRow(objDataArr, true);
                            p_dt.EndLoadData();
                        }
                        else
                        {
                            p_dt.BeginLoadData();
                            p_dt.LoadDataRow(objDataArr, true);
                            p_dt.EndLoadData();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }

        }
        #endregion
        #endregion

    }
}

