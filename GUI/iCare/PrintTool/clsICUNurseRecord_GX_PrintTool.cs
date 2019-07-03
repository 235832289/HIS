using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using com.digitalwave.clsRecordsService;
//using com.digitalwave.iCare.middletier.HRPService;
namespace iCare
{
    /// <summary>
    ///  ICU护理记录打印类
    /// </summary>
    public class clsICUNurseRecord_GX_PrintTool : frmICUNurseRecord_GX,infPrintRecord
    {
        private bool m_blnIsFromDataSource = true;//表明是从数据库读取还是从文件直接提取信息
        private bool m_blnWantInit = true;
        private  clsRecordsDomain m_objRecordsDomain;
        //private com.digitalwave.clsRecordsService.clsICUNurseRecord_GXMainService m_objInRoomSvc;
        clsPatient m_objPatient = null;
        //private com.digitalwave.clsRecordsService.clsVeinSpecialUseDrug_ConService m_objInRoomSvc;
        private clsICUNurseRecordContentGX[] m_objValue;
        DateTime m_dtInHos;
        #region  有用的数据字段
        public string m_strInPatientID = "";
        public string m_strInPatientDate = "";
        public string m_strName = "";
        public string m_strSex = "";
        public string m_strAge = "";
        public string m_strBedCode = "";
        public DateTime m_dtmPrintOpenDate;
        /// <summary>
        /// 病案号
        /// </summary>
        public string m_strDiseaseID = "";
        /// <summary>
        /// 打印第 页 X
        /// </summary>
        public float m_fltPageIndexX;
        /// <summary>
        /// 打印第 页 Y
        /// </summary>
        public float m_fltPageIndexY;
        public DateTime m_dtmCreateDate;
        public clsPatient m_objPatientTemp;
        public string m_strCustomColumn1 = "";//自定义列名1
        public string m_strCustomColumn2 = "";
        public string m_strCustomColumn3 = "";
        public string m_strCustomColumn4 = "";
        public string m_strTempColumnName = "";
        #endregion
        public clsICUNurseRecord_GX_PrintTool()
        {
            //m_objInRoomSvc = new com.digitalwave.clsRecordsService.clsICUNurseRecord_GXMainService();
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
        /// <param 	name="p_dtmOpenDate">OpenDate，如果是一次打印多次记录表单的类型（如病案记录），忽略OpenDate</param>
        public void m_mthSetPrintInfo(clsPatient p_objPatient, DateTime p_dtmInPatientDate, DateTime p_dtmOpenDate)
        {
            
            m_objPatient = p_objPatient;
            m_dtInHos = p_dtmInPatientDate;
            //获取所有没删除的数据
            com.digitalwave.clsRecordsService.clsICUNurseRecord_GXMainService m_objInRoomSvc =
                (com.digitalwave.clsRecordsService.clsICUNurseRecord_GXMainService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsRecordsService.clsICUNurseRecord_GXMainService));

            m_objInRoomSvc.m_lngGetAllMainRecord(m_objPatient.m_StrInPatientID, p_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), out m_objValue);
            m_blnIsFromDataSource = true;//表明是从数据库读取
            //clsPatient m_objPatient = p_objPatient;
            //m_objPrintInfo = new clsPrintInfo_ICUNurseRecord();
            //m_objPrintInfo.m_strInPatentID = m_objPatient != null ? m_objPatient.m_StrInPatientID : "";
            //m_objPrintInfo.m_strPatientName = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrFirstName : "";
            //m_objPrintInfo.m_strSex = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrSex : "";
            //m_objPrintInfo.m_strAge = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrAge : "";
            //m_objPrintInfo.m_strBedName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName : "";
            //m_objPrintInfo.m_strDeptName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_ObjLastDeptInfo.m_ObjDept.m_StrDeptName : "";
            //m_objPrintInfo.m_dtmInPatientDate = p_dtmInPatientDate;
            //m_objPrintInfo.m_strHISInPatientID = m_objPatient != null ? m_objPatient.m_StrHISInPatientID : "";
            //m_objPrintInfo.m_dtmHISInDate = m_objPatient != null ? m_objPatient.m_DtmSelectedHISInDate : DateTime.MinValue;
            

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
        }
        #endregion

        #region 获取打印内容,(当从数据库读取时,调用本函数之前请首先调用m_mthSetPrintInfo函数)
        /// <summary>
        /// 获取打印内容,(当从数据库读取时,调用本函数之前请首先调用m_mthSetPrintInfo函数)
        /// </summary>
        /// <returns>打印内容</returns>
        public object m_objGetPrintInfo()
        {

            return m_objValue;
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
            m_strTitle = "ICU护理记录";//默认标题为"表名"

        }
        #endregion

        #region 打印中
        /// <summary>
        /// 打印中
        /// </summary>
        /// <param name="p_objPrintArg">此处p_objPrintArg要求为PrintPageEventArgs类型的对象</param>
        public void m_mthPrintPage(object p_objPrintArg)
        {
            if (Source==null)
            {
                m_mthInitPrintData(this, m_objPatient);
            }
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

            if (!((PrintEventArgs)p_objPrintArg).Cancel)
            {
                com.digitalwave.clsICUNurseRecord_GXService.clsICUNurseRecord_GXService service =
                    (com.digitalwave.clsICUNurseRecord_GXService.clsICUNurseRecord_GXService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsICUNurseRecord_GXService.clsICUNurseRecord_GXService));

                service.m_lngUpdateFirstPrintDate(m_strInPatientID, m_strInPatientDate, m_dtmPrintOpenDate.ToString(), System.DateTime.Now);
                //new 

                //clsVeinSpecialUseDrug_MainService().m_lngUpdateFirstPrintDateNew(this.m_strID_CHR,DateTime.Now);
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
        private void m_mthSetPrintContent(clsNewBabyInRoomRecord p_objContent, clsNewBabyCircsRecord[]

            p_objCircsContentArr, DateTime p_dtmFirstPrintDate)
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

        #region 表头的坐标获取
        private RectangleF m_mthgetPointRectangle(int p_strFormNameIndex)
        {
            float fltRowHeiht = m_ftlRowHeight;
            fltRowHeiht += 5F;
            float fltY = this.m_fltLocationY;
            fltY += 5F;
            RectangleF rec = new RectangleF(0, 0, 0, 0);
            switch (p_strFormNameIndex)
            {
                case 0: //时
                    rec = new RectangleF(
                                 m_fltEachColLeft[0],
                                fltY,
                                m_fltEachColWidth[0],
                                fltRowHeiht);
                    break;

                case 1://入量 (占5倍的单元格)
                    rec = new RectangleF(m_fltEachColLeft[1],
                                            fltY + 2F,
                                            m_fltEachColLeft[4] - m_fltEachColLeft[1],
                                            fltRowHeiht);
                    break;
                case 2://项目(3倍)
                    rec = new RectangleF(m_fltEachColLeft[1],
                    fltY + fltRowHeiht,
                    m_fltEachColWidth[1],
                    fltRowHeiht);
                    break;
                case 3://备用量
                    rec = new RectangleF(m_fltEachColLeft[2],
                        fltY + fltRowHeiht - 6F,
                        m_fltEachColWidth[2],
                        fltRowHeiht);
                    break;
                case 4://实入量
                    rec = new RectangleF(m_fltEachColLeft[3],
                        fltY + fltRowHeiht - 6F,
                        m_fltEachColWidth[3],
                        fltRowHeiht);
                    break;
                case 5://出量
                    rec = new RectangleF(m_fltEachColLeft[4],
                        fltY + 2F,
                        m_fltEachColLeft[7] - m_fltEachColLeft[4],
                        fltRowHeiht);
                    break;
                case 6://尿
                    rec = new RectangleF(m_fltEachColLeft[4],
                        fltY + fltRowHeiht,
                        m_fltEachColWidth[4],
                        fltRowHeiht);
                    break;
                case 7://自定义列一
                    rec = new RectangleF(m_fltEachColLeft[5],
                        fltY + fltRowHeiht,
                        m_fltEachColWidth[5],
                        fltRowHeiht);
                    break;
                case 8://自定义列2
                    rec = new RectangleF(m_fltEachColLeft[6],
                        fltY + fltRowHeiht,
                        m_fltEachColWidth[6],
                        fltRowHeiht);
                    break;
                case 9://T
                    rec = new RectangleF(m_fltEachColLeft[7],
                        fltY + fltRowHeiht,
                        m_fltEachColWidth[7],
                        fltRowHeiht);
                    break;
                case 10://HR
                    rec = new RectangleF(m_fltEachColLeft[8],
                        fltY + fltRowHeiht,
                        m_fltEachColWidth[8],
                        fltRowHeiht);
                    break;
                case 11://R
                    rec = new RectangleF(m_fltEachColLeft[9],
                        fltY + fltRowHeiht,
                        m_fltEachColWidth[9],
                        fltRowHeiht);
                    break;
                case 12://BP
                    rec = new RectangleF(m_fltEachColLeft[10],
                        fltY + fltRowHeiht,
                        m_fltEachColWidth[10],
                        fltRowHeiht);
                    break;
                case 13://A-
                    rec = new RectangleF(m_fltEachColLeft[11],
                        fltY + fltRowHeiht,
                        m_fltEachColWidth[11],
                        fltRowHeiht);
                    break;
                case 14://SPO2
                    rec = new RectangleF(m_fltEachColLeft[12],
                        fltY + fltRowHeiht,
                        m_fltEachColWidth[12],
                        fltRowHeiht);
                    break;
                case 15://一般情况
                    rec = new RectangleF(m_fltEachColLeft[13],
                        fltY + fltRowHeiht,
                        m_fltEachColWidth[13],
                        fltRowHeiht);
                    break;
                case 16://小结
                    rec = new RectangleF(m_fltEachColLeft[13],
                        fltY + fltRowHeiht,
                        m_fltEachColWidth[13],
                        fltRowHeiht);
                    break;
                case 17://观察病情
                    rec = new RectangleF(m_fltEachColLeft[7],
                        fltY + 2F,
                        m_fltEachColLeft[13] + m_fltEachColWidth[13] - m_fltEachColLeft[7],
                        fltRowHeiht);
                    break;
                case 18: //间
                    rec = new RectangleF(
                        m_fltEachColLeft[0],
                        fltY + fltRowHeiht,
                        m_fltEachColWidth[0],
                        fltRowHeiht);
                    break;
            }
            return rec;
        }
        #endregion

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
        private float m_fltZijiHeight = 8; //字与线间的位置高 ：间距
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

        #region 设置打印列宽与每列的横坐标变量		///<summary>
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
        private System.Drawing.Font m_fontTitle = new System.Drawing.Font("SimSun", 20, FontStyle.Bold);

        /// <summary>
        /// 打印正文的字体
        /// </summary>	
        private System.Drawing.Font m_fontBody = new System.Drawing.Font("SimSun", 12);

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

            string strPrint = "";
            //com.digitalwave.iCare.common.clsCommmonInfo com = new com.digitalwave.iCare.common.clsCommmonInfo();
            //string HospitalTitle = "";
            //HospitalTitle = com.m_strGetHospitalTitle();
            System.Drawing.Graphics g = e.Graphics;
            e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, new Font("simsun", 12), m_objBrush, 320,30);

            e.Graphics.DrawString("ICU   护   理   记   录", new Font("simsun", 20, FontStyle.Bold), m_objBrush, 260,70);
            //strPrint = HospitalTitle;
            SizeF objSize = g.MeasureString(strPrint, new System.Drawing.Font("SimSun", 12));

            //g.DrawString(strPrint, new System.Drawing.Font("SimSun", 12), m_objBrush, e.MarginBounds.Left + (e.MarginBounds.Width - objSize.Width) / 2, p_objRectangle.Top - 50);
            this.m_fltLocationY = p_objRectangle.Top + objSize.Height;

            //strPrint = this.m_strTitle;
            objSize = g.MeasureString(strPrint, this.m_fontTitle);
            //g.DrawString(strPrint, this.m_fontTitle, m_objBrush, e.MarginBounds.Left + (e.MarginBounds.Width - objSize.Width) / 2, m_fltLocationY);

            this.m_fltLocationY += objSize.Height+20;

            int col = p_objRectangle.Width / 7;
            float fltCol = float.Parse(col.ToString());//打印姓名此列的列宽		

            strPrint = "姓名:" + (m_objPatient == null ? m_strName.Trim() : m_objPatient.m_StrName);
            objSize = g.MeasureString(strPrint, this.m_fontBody);
            g.DrawString(strPrint, m_fontBody, m_objBrush, p_objRectangle.Left, m_fltLocationY);

            strPrint = "性别:" + (m_objPatient == null ?m_strSex.Trim():m_objPatient.m_ObjPeopleInfo.m_StrSex);
            objSize = g.MeasureString(strPrint, this.m_fontBody);
            g.DrawString(strPrint, m_fontBody, m_objBrush, p_objRectangle.Left + fltCol * 1 + 20, m_fltLocationY);

            strPrint = "年龄:" + (m_objPatient == null ?m_strAge.Trim():m_objPatient.m_ObjPeopleInfo.m_IntAge.ToString());
            objSize = g.MeasureString(strPrint, this.m_fontBody);
            g.DrawString(strPrint, m_fontBody, m_objBrush, p_objRectangle.Left + fltCol * 2, m_fltLocationY);
            strPrint = "床号:" + (m_objPatient == null ?m_strBedCode.Trim():m_objPatient.m_strBedCode);
            objSize = g.MeasureString(strPrint, this.m_fontBody);
            g.DrawString(strPrint, m_fontBody, m_objBrush, p_objRectangle.Left + fltCol * 3, m_fltLocationY);

            strPrint = "病案号:" + (m_objPatient == null ? m_strDiseaseID.Trim() : m_objPatient.m_StrInPatientID);
            objSize = g.MeasureString(strPrint, this.m_fontBody);
            g.DrawString(strPrint, m_fontBody, m_objBrush, p_objRectangle.Left + fltCol * 4, m_fltLocationY);

            strPrint = "日期:" + m_dtmCreateDate.ToString("yyyy年MM月");
            objSize = g.MeasureString(strPrint, this.m_fontBody);
            g.DrawString(strPrint, m_fontBody, m_objBrush, p_objRectangle.Left + fltCol * 5+30, m_fltLocationY);

            m_fltPageIndexY = m_fltLocationY;
            this.m_fltLocationY += this.m_ftlRowHeight - 5F;
        }
        #endregion

        #region 方法:打印页脚
        /// <summary>
        /// 方法:打印页脚
        /// </summary>		
        private void mthPrintFoot(PrintPageEventArgs e)
        {
            m_strPrint = string.Format("第{0}页", this.m_intCurrentPageIndex);
            float fltWith = e.Graphics.MeasureString(m_strPrint, this.m_fontBody).Width;
            fltWith = float.Parse(this.m_objRectangle.Right.ToString()) - fltWith;
            e.Graphics.DrawString(m_strPrint, this.m_fontBody, this.m_objBrush, fltWith, m_fltPageIndexY);

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
            if (m_fltColumnPercentArr==null)
            {
                float[] fltArrColumnPercent = new float[14];
			    fltArrColumnPercent[0] = 0.04761905F; 
			    fltArrColumnPercent[1] = 0.04761905F * 3;
			    fltArrColumnPercent[2] = 0.04761905F;
			    fltArrColumnPercent[3] = 0.04761905F;
			    fltArrColumnPercent[4] = 0.04761905F;
			    fltArrColumnPercent[5] = 0.04761905F;
			    fltArrColumnPercent[6] = 0.04761905F;
			    fltArrColumnPercent[7] = 0.04761905F;
			    fltArrColumnPercent[8] = 0.04761905F;
			    fltArrColumnPercent[9] = 0.04761905F;
			    fltArrColumnPercent[10] = 0.04761905F;
			    fltArrColumnPercent[11] = 0.04761905F;
			    fltArrColumnPercent[12] = 0.04761905F;
			    fltArrColumnPercent[13] = 0.04761905F * 3+0.04761905F * 3;
                ColumnPercentArr = fltArrColumnPercent;
            }
            float dblColumnCount = float.Parse(m_fltColumnPercentArr.Length.ToString());
            float dblAvg = 0;
            m_fltColumnTotalWidth = float.Parse(Convert.ToString(p_objRectangle.Width));
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
                g.DrawLine(this.m_objPen, m_fltEachColLeft[i1], m_fltLocationY, m_fltEachColLeft[i1]

                    , m_fltLocationY + this.m_ftlRowHeight);
            }
            g.DrawLine(this.m_objPen, m_fltEachColLeft[p_intColumnCount - 1] + m_fltEachColWidth[p_intColumnCount

                - 1], m_fltLocationY, m_fltEachColLeft[p_intColumnCount - 1] + m_fltEachColWidth[p_intColumnCount - 1], m_fltLocationY +

                this.m_ftlRowHeight);
            g.DrawLine(this.m_objPen, m_fltEachColLeft[0], this.m_fltLocationY + this.m_ftlRowHeight,

                m_fltEachColLeft[p_intColumnCount - 1] + m_fltEachColWidth[p_intColumnCount - 1], this.m_fltLocationY + this.m_ftlRowHeight);

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
        private void m_mthDrawStrAtRectangle(float col1, float col2, string strPrint, float

            LocationY, System.Drawing.Printing.PrintPageEventArgs e)
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
            //float X =  col1 + ji/2 - s.Width/2;
            float X = col1 + 3;
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
                //float x1 =  col1 + ji/2 - g.MeasureString(strPrint1,objfont).Width/2;
                float x1 = col1 + 3;
                g.DrawString(strPrint1, objfont, this.m_objBrush, x1, y1);

                string strPrint2 = "";
                if (strPrint.Length - intcharCount <= intcharCount)
                    strPrint2 = strPrint.Substring(intcharCount);
                else
                    strPrint2 = strPrint.Substring(intcharCount, intcharCount);
                //	x1 =  col1 + ji/2 - g.MeasureString(strPrint2,objfont).Width/2;
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
            string strPrint = "";
            RectangleF rec;
            StringFormat m_sfm = new StringFormat(StringFormatFlags.FitBlackBox);
            m_sfm.Alignment = StringAlignment.Center;
            int intColumnCount = m_dtSource==null?m_fltColumnPercentArr.Length:this.m_dtSource.Columns.Count;
            System.Drawing.Graphics g = e.Graphics;
            g.DrawLine(this.m_objPen, m_fltEachColLeft[0], m_fltLocationY, m_fltEachColLeft[intColumnCount - 1] + m_fltEachColWidth[intColumnCount - 1], m_fltLocationY);
            //时间
            rec = m_mthgetPointRectangle(0);
            strPrint = "时";
            g.DrawString(strPrint, this.m_fontBody, this.m_objBrush, rec, m_sfm);
            g.DrawLine(this.m_objPen, rec.X, m_fltLocationY, rec.X, m_fltLocationY + this.m_ftlRowHeight * 2);
            g.DrawLine(this.m_objPen, rec.Right, m_fltLocationY, rec.Right, m_fltLocationY + this.m_ftlRowHeight * 2);
            //间
            rec = m_mthgetPointRectangle(18);
            g.DrawString("间", this.m_fontBody, this.m_objBrush, rec, m_sfm);

            //入量
            rec = m_mthgetPointRectangle(1);
            strPrint = "入    量";
            g.DrawString(strPrint, this.m_fontBody, this.m_objBrush, rec, m_sfm);
            //m_mthDrawStrAtRectangle(rec.Left,rec.Right,strPrint,this.m_fltLocationY,e);
            g.DrawLine(this.m_objPen, rec.Left, m_fltLocationY + this.m_ftlRowHeight, rec.Right, m_fltLocationY + this.m_ftlRowHeight);

            //出量
            rec = m_mthgetPointRectangle(5);
            strPrint = "出   量";
            g.DrawString(strPrint, this.m_fontBody, this.m_objBrush, rec, m_sfm);
            g.DrawLine(this.m_objPen, rec.Left, m_fltLocationY + this.m_ftlRowHeight, rec.Right, m_fltLocationY + this.m_ftlRowHeight);
            g.DrawLine(this.m_objPen, rec.X, m_fltLocationY, rec.X, m_fltLocationY + this.m_ftlRowHeight * 2);
            g.DrawLine(this.m_objPen, rec.Right, m_fltLocationY, rec.Right, m_fltLocationY + this.m_ftlRowHeight * 2);

            //观察病情
            rec = m_mthgetPointRectangle(17);
            strPrint = "观     察     病     情";
            g.DrawString(strPrint, this.m_fontBody, this.m_objBrush, rec, m_sfm);
            g.DrawLine(this.m_objPen, rec.Left, m_fltLocationY + this.m_ftlRowHeight, rec.Right, m_fltLocationY + this.m_ftlRowHeight);

            //项目
            rec = m_mthgetPointRectangle(2);
            strPrint = "项   目";
            g.DrawString(strPrint, this.m_fontBody, this.m_objBrush, rec, m_sfm);

            //备用量
            rec = m_mthgetPointRectangle(3);
            strPrint = "备用量";
            g.DrawString(strPrint, this.m_fontBody, this.m_objBrush, rec, m_sfm);
            //m_mthDrawStrAtRectangle(rec.Left,rec.Right,strPrint,this.m_fltLocationY + this.m_ftlRowHeight,e);

            g.DrawLine(this.m_objPen, rec.Left, m_fltLocationY + m_ftlRowHeight, rec.Left, m_fltLocationY + m_ftlRowHeight * 2);

            //备用量
            rec = m_mthgetPointRectangle(4);
            strPrint = "实入量";
            g.DrawString(strPrint, this.m_fontBody, this.m_objBrush, rec, m_sfm);
            //m_mthDrawStrAtRectangle(rec.Left,rec.Right,strPrint,this.m_fltLocationY + this.m_ftlRowHeight,e);
            g.DrawLine(this.m_objPen, rec.Left, m_fltLocationY + m_ftlRowHeight, rec.Left, m_fltLocationY + m_ftlRowHeight * 2);
            //尿
            rec = m_mthgetPointRectangle(6);
            strPrint = "尿";
            g.DrawString(strPrint, this.m_fontBody, this.m_objBrush, rec, m_sfm);

            //自定义列一
            rec = m_mthgetPointRectangle(7);
            strPrint = this.m_strCustomColumn1.Replace("\r\n", "");
            System.Drawing.Font m_fontCustom = new System.Drawing.Font("宋体", 10);
            if (strPrint.Length > 2)
            {
                rec.Y -= 6F;
                if (strPrint.Length > 4)
                {
                    m_fontCustom = new System.Drawing.Font("宋体", 8);
                }
            }
            g.DrawString(strPrint, m_fontCustom, this.m_objBrush, rec, m_sfm);
            //m_mthDrawStrAtRectangle(rec.Left,rec.Right,strPrint,this.m_fltLocationY,e);
            g.DrawLine(this.m_objPen, rec.Left, m_fltLocationY + m_ftlRowHeight, rec.Left, m_fltLocationY + m_ftlRowHeight * 2);
            //自定义列2
            rec = m_mthgetPointRectangle(8);
            strPrint = this.m_strCustomColumn2.Replace("\r\n", "");
            m_fontCustom = new System.Drawing.Font("宋体", 10);
            if (strPrint.Length > 2)
            {
                rec.Y -= 6F;
                if (strPrint.Length > 4)
                {
                    m_fontCustom = new System.Drawing.Font("宋体", 8);
                }
            }
            g.DrawString(strPrint, m_fontCustom, this.m_objBrush, rec, m_sfm);
            g.DrawLine(this.m_objPen, rec.Left, m_fltLocationY + m_ftlRowHeight, rec.Left, m_fltLocationY + m_ftlRowHeight * 2);
            //T
            rec = m_mthgetPointRectangle(9);
            strPrint = "T";
            g.DrawString(strPrint, this.m_fontBody, this.m_objBrush, rec, m_sfm);
            g.DrawLine(this.m_objPen, rec.Left, m_fltLocationY + m_ftlRowHeight, rec.Left, m_fltLocationY + m_ftlRowHeight * 2);
            //HR
            rec = m_mthgetPointRectangle(10);
            strPrint = "HR";
            g.DrawString(strPrint, this.m_fontBody, this.m_objBrush, rec, m_sfm);
            g.DrawLine(this.m_objPen, rec.Left, m_fltLocationY + m_ftlRowHeight, rec.Left, m_fltLocationY + m_ftlRowHeight * 2);
            //R
            rec = m_mthgetPointRectangle(11);
            strPrint = "R";
            g.DrawString(strPrint, this.m_fontBody, this.m_objBrush, rec, m_sfm);
            g.DrawLine(this.m_objPen, rec.Left, m_fltLocationY + m_ftlRowHeight, rec.Left, m_fltLocationY + m_ftlRowHeight * 2);
            //BP
            rec = m_mthgetPointRectangle(12);
            strPrint = "BP";
            g.DrawString(strPrint, this.m_fontBody, this.m_objBrush, rec, m_sfm);
            g.DrawLine(this.m_objPen, rec.Left, m_fltLocationY + m_ftlRowHeight, rec.Left, m_fltLocationY + m_ftlRowHeight * 2);
            //A-
            rec = m_mthgetPointRectangle(13);
            strPrint = this.m_strCustomColumn3.Replace("\r\n", "");
            m_fontCustom = new System.Drawing.Font("宋体", 10);
            if (strPrint.Length > 2)
            {
                rec.Y -= 6F;
                if (strPrint.Length > 4)
                {
                    m_fontCustom = new System.Drawing.Font("宋体", 8);
                }
            }
            g.DrawString(strPrint, m_fontCustom, this.m_objBrush, rec, m_sfm);
            g.DrawLine(this.m_objPen, rec.Left, m_fltLocationY + m_ftlRowHeight, rec.Left, m_fltLocationY + m_ftlRowHeight * 2);
            //spo2
            rec = m_mthgetPointRectangle(14);
            strPrint = m_strCustomColumn4.Replace("\r\n", "");
            m_fontCustom = new System.Drawing.Font("宋体", 10);
            if (strPrint.Length > 2)
            {
                rec.Y -= 6F;
                if (strPrint.Length > 4)
                {
                    m_fontCustom = new System.Drawing.Font("宋体", 8);
                }
            }
            g.DrawString(strPrint, m_fontCustom, this.m_objBrush, rec, m_sfm);
            g.DrawLine(this.m_objPen, rec.Left, m_fltLocationY + m_ftlRowHeight, rec.Left, m_fltLocationY + m_ftlRowHeight * 2);
            //一般情况
            rec = m_mthgetPointRectangle(15);
            strPrint = "一般情况";
            g.DrawString(strPrint, this.m_fontBody, this.m_objBrush, rec, m_sfm);
            g.DrawLine(this.m_objPen, rec.Left, m_fltLocationY + m_ftlRowHeight, rec.Left, m_fltLocationY + m_ftlRowHeight * 2);
            //小结
            rec = m_mthgetPointRectangle(16);
            //strPrint = "小    结";
            //g.DrawString(strPrint,this.m_fontBody,this.m_objBrush,rec,m_sfm);
            g.DrawLine(this.m_objPen, rec.Left, m_fltLocationY + m_ftlRowHeight, rec.Left, m_fltLocationY + m_ftlRowHeight * 2);
            g.DrawLine(this.m_objPen, rec.Right, m_fltLocationY, rec.Right, m_fltLocationY + this.m_ftlRowHeight * 2);

            m_fltLocationY += this.m_ftlRowHeight * 2;

            g.DrawLine(this.m_objPen, m_fltEachColLeft[0], m_fltLocationY, m_fltEachColLeft[intColumnCount - 1] + m_fltEachColWidth[intColumnCount - 1], m_fltLocationY);

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
        private void m_mthPrintAllPage(System.Drawing.Printing.PrintPageEventArgs e, ref float

            p_objLocationY, DataTable p_dt)
        {
            int p_intRowsCount = p_dt.Rows.Count;

            string strPrint = "";
            //计算第一页还能打印出多少条
            int intRowCount = Convert.ToInt32((float.Parse(this.m_objRectangle.Height.ToString()) -

                p_objLocationY) / m_ftlRowHeight);
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
                            m_mthDrawStrAtRectangle(m_fltEachColLeft[j], m_fltEachColLeft[j] +

                                m_fltEachColWidth[j], strPrint, p_objLocationY, e);
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
                            m_mthDrawStrAtRectangle(m_fltEachColLeft[j], m_fltEachColLeft[j] +

                                m_fltEachColWidth[j], strPrint, p_objLocationY, e);
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
        #endregion

    }
}

