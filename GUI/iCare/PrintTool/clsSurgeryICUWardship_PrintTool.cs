using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.Utility.Controls;
using System.Drawing;
using System.Data;
using System.IO;
namespace iCare
{
    /// <summary>
    /// clsSurgeryICUWardship_PrintTool 的摘要说明。
    /// </summary>
    public class clsSurgeryICUWardship_PrintTool : frmSurgeryICUWardship,infPrintRecord
    {
        private  System.Data.DataTable printTable = new System.Data.DataTable();
        //病人基本信息
        protected clsPatient m_objCurrentPatient;
        protected clsRecordsDomain m_objRecordsDomain;
        //病人ICU信息
        private ArrayList personMessageArr = new ArrayList();
        //总页数统计
        public int pageCount = 0;
        //当前打印的页面
        int CurrentCount = 0;
        //当前打印的数据集行标
        int CurrentDTRow = 0;
        //当前页打印的数据集行标头
        int CurrentPageDTRow = 0;
        //当前打印的格子开始列
        int CurrentPrintColumn = 3;
        //当前打印数据的最大长度
        int RowLength = 0;
        //特殊记录
        string SpecString = "";
        //左右数组
        string[] value_arry;
        /// <summary>
        /// 预览标志 TRUE表示预览
        /// </summary>
        public bool printView = false;

        SolidBrush brush1 = new SolidBrush(Color.Black);
        Font font_title = new Font("Arial", 14, System.Drawing.FontStyle.Bold);
        Font font1 = new Font("Arial", 11);
        Font font2 = new Font("Arial", 9);
        Font font3 = new Font("Arial", 6);
        int height_add = 5;
        int right_add = 10;
        int table_x, table_y, table_width, table_height;
        System.Drawing.RectangleF rec;
        System.Drawing.StringFormat format = new StringFormat();


        public clsSurgeryICUWardship_PrintTool()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        public clsSurgeryICUWardship_PrintTool(System.Data.DataTable table1, clsPatient Patient, ArrayList pMessageArr)
        {
            this.printTable = table1;
            this.m_objCurrentPatient = Patient;
            this.pageCount = 2;
            personMessageArr = pMessageArr;
        }

        /// <summary>
        /// 设置打印信息
        /// </summary>
        /// <param name="p_objPatient">病人</param>
        /// <param name="p_dtmInPatientDate">入院日期</param>
        /// <param name="p_dtmOpenDate">OpenDate，如果是一次打印多次记录表单的类型（如病案记录），忽略OpenDate</param>
        public void m_mthSetPrintInfo(clsPatient p_objPatient, DateTime p_dtmInPatientDate, DateTime p_dtmOpenDate)
        {
            m_objCurrentPatient = p_objPatient;
            
        }

        /// <summary>
        /// 从数据库初始化打印内容。如果没有记录，打印空报表。
        /// </summary>
        public void m_mthInitPrintContent()
        {
            
        }

        /// <summary>
        /// 设置打印内容。当数据已经存在时使用。
        /// </summary>
        /// <param name="p_objPrintContent">打印内容</param>
        public void m_mthSetPrintContent(object p_objPrintContent)
        {
        }

        /// <summary>
        /// 获取打印内容
        /// </summary>
        /// <returns>打印内容</returns>
        public object m_objGetPrintInfo()
        {
            printTable = m_objGetPrintTable(m_objCurrentPatient);
            if (this.printTable.Rows.Count > 0)
                return printTable;
            else
                return null;
            //return printTable;
        }

        /// <summary>
        /// 初始化打印变量
        /// </summary>
        /// <param name="p_objArg">外部需要初始化的变量，根据不同的实现使用</param>
        public void m_mthInitPrintTool(object p_objArg)
        {
        }

        /// <summary>
        /// 释放打印变量
        /// </summary>
        /// <param name="p_objArg">外部使用到的变量，根据不同的实现使用</param>
        public void m_mthDisposePrintTools(object p_objArg)
        {
        }

        /// <summary>
        /// 打印开始
        /// </summary>
        /// <param name="p_objPrintArg"></param>
        public void m_mthBeginPrint(object p_objPrintArg)
        {


        }

        /// <summary>
        /// 打印中
        /// </summary>
        /// <param name="p_objPrintArg"></param>
        public void m_mthPrintPage(object p_objPrintArg)
        {
            PrintPageEventArgs e = (PrintPageEventArgs)p_objPrintArg;
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            Font drawFont = new Font("Arial", 16);
            this.CurrentCount++;
            if (this.CurrentCount % 2 != 0)
            {
                printTheFront(e);
                if (!this.printView)
                    clsPublicFunction.ShowInformationMessageBox("请翻转页面继续打印！");
                //MessageBox.Show("请翻转页面继续打印！","提示框",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                printTheBack(e);
            }
            
            if (this.CurrentCount < this.pageCount)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
            return;


        }
        public void m_mthPrintPage(PageSettings p_pstDefault, System.Data.DataTable table1, clsPatient Patient, ArrayList pMessageArr)
        {

            //frmPrintPreviewDialogPF frmPreview = new frmPrintPreviewDialogPF();
            //frmPreview.m_evtBeginPrint += new PrintEventHandler(frmPreview_m_evtBeginPrint);
            //frmPreview.m_evtEndPrint += new PrintEventHandler(frmPreview_m_evtEndPrint);
            //frmPreview.m_evtPrintContent += new PrintPageEventHandler(frmPreview_m_evtPrintContent);
            //frmPreview.m_evtPrintFrame += new PrintPageEventHandler(frmPreview_m_evtPrintFrame);
            //frmPreview.m_pstDefaultPageSettings = p_pstDefault;
            //frmPreview.ShowDialog();
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
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            Font drawFont = new Font("Arial", 16);
            this.CurrentCount++;
            if (this.CurrentCount % 2 != 0)
            {
                printTheFront(e);
                clsPublicFunction.ShowInformationMessageBox("请翻转页面继续打印！");
                //MessageBox.Show("请翻转页面继续打印！","提示框",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                printTheBack(e);
            }
            if (this.CurrentCount < this.pageCount)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
            return;


        }
        private void frmPreview_m_evtPrintFrame(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //			m_mthPrintTitleInfo(e);	
            //			m_mthPrintRectangleInfo(e);	
            //			m_mthPrintHeaderInfo(e);
        }
        #endregion
        /// <summary>
        /// 打印结束。一般使用它来更新数据库信息。
        /// </summary>
        /// <param name="p_objPrintArg"></param>
        public void m_mthEndPrint(object p_objPrintArg)
        {
        }




        #region 正面打印
        /// <summary>
        /// 正面打印
        /// </summary>
        public void printTheFront(System.Drawing.Printing.PrintPageEventArgs e)
        {

            #region 画标题
            this.table_x = 10;
            this.table_y = 0;
            this.table_width = 1600;
            this.table_height = 100;

            PrintTable title_table = new PrintTable(this.table_x, this.table_y, this.table_width, this.table_height, 3, 2);
            //广西壮族自治区人民医院
            rec = new System.Drawing.RectangleF(title_table.Cell(0, 0).x, (title_table.Cell(0, 0).y), title_table.td_width, title_table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Far;
            e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, font1, brush1, rec, format);
            rec = new System.Drawing.RectangleF(title_table.Cell(0, 0).x, (title_table.Cell(0, 0).y + 2), title_table.td_width, title_table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Far;
            e.Graphics.DrawString("________________________________________", font1, brush1, rec, format);
            //外科 ICU 监护记录
            rec = new System.Drawing.RectangleF(title_table.Cell(1, 0).x, (title_table.Cell(1, 0).y), title_table.td_width, title_table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Near;
            e.Graphics.DrawString("外科 ICU 监护记录", font_title, brush1, rec, format);

            #endregion

            #region 画表头
            this.table_x = 10;
            this.table_y = 70;
            this.table_width = 1600;
            this.table_height = 30;

            if (this.m_objCurrentPatient != null)
            {
                PrintTable head_table = new PrintTable(this.table_x, this.table_y, this.table_width, this.table_height, 1, 28);
                //姓名
                rec = new System.Drawing.RectangleF(head_table.Cell(0, 0).x, (head_table.Cell(0, 0).y), head_table.td_width * 2+20, head_table.td_height);
                format.Alignment = System.Drawing.StringAlignment.Near;
                format.LineAlignment = System.Drawing.StringAlignment.Center;
                e.Graphics.DrawString("姓名 " + m_objCurrentPatient.m_StrName.ToString().Trim(), font1, brush1, rec, format);

                //姓别
                rec = new System.Drawing.RectangleF(head_table.Cell(0, 2).x+20, (head_table.Cell(0, 2).y), head_table.td_width * 2, head_table.td_height);
                format.Alignment = System.Drawing.StringAlignment.Near;
                format.LineAlignment = System.Drawing.StringAlignment.Center;
                e.Graphics.DrawString("姓别 " + m_objCurrentPatient.m_StrSex.ToString().Trim(), font1, brush1, rec, format);
                //年龄
                rec = new System.Drawing.RectangleF(head_table.Cell(0, 4).x, (head_table.Cell(0, 4).y), head_table.td_width * 2, head_table.td_height);
                format.Alignment = System.Drawing.StringAlignment.Near;
                format.LineAlignment = System.Drawing.StringAlignment.Center;
                e.Graphics.DrawString("年龄 " + m_objCurrentPatient.m_ObjPeopleInfo.m_IntAge, font1, brush1, rec, format);
                //床号
                rec = new System.Drawing.RectangleF(head_table.Cell(0, 6).x, (head_table.Cell(0, 6).y), head_table.td_width * 2, head_table.td_height);
                format.Alignment = System.Drawing.StringAlignment.Near;
                format.LineAlignment = System.Drawing.StringAlignment.Center;
                e.Graphics.DrawString("床号 " + m_objCurrentPatient.m_strBedCode.ToString().Trim(), font1, brush1, rec, format);
                //体重
                rec = new System.Drawing.RectangleF(head_table.Cell(0, 8).x, (head_table.Cell(0, 8).y), head_table.td_width * 2, head_table.td_height);
                format.Alignment = System.Drawing.StringAlignment.Near;
                format.LineAlignment = System.Drawing.StringAlignment.Center;
                //
                if (this.personMessageArr.Count > 0)
                {
                    e.Graphics.DrawString("体重 " + personMessageArr[0].ToString().Trim(), font1, brush1, rec, format);
                }
                else
                {
                    e.Graphics.DrawString("体重 ", font1, brush1, rec, format);

                }
                //ID号
                rec = new System.Drawing.RectangleF(head_table.Cell(0, 10).x, (head_table.Cell(0, 10).y), head_table.td_width * 2, head_table.td_height);
                format.Alignment = System.Drawing.StringAlignment.Near;
                format.LineAlignment = System.Drawing.StringAlignment.Center;
                if (this.personMessageArr.Count > 1)
                {
                    e.Graphics.DrawString("ID号 " + personMessageArr[1].ToString().Trim(), font1, brush1, rec, format);
                }
                else
                {
                    e.Graphics.DrawString("ID号 ", font1, brush1, rec, format);

                }
                //诊断/手术名称
                rec = new System.Drawing.RectangleF(head_table.Cell(0, 12).x, (head_table.Cell(0, 12).y), head_table.td_width * 2+100, head_table.td_height);
                format.Alignment = System.Drawing.StringAlignment.Near;
                format.LineAlignment = System.Drawing.StringAlignment.Center;
                if (this.personMessageArr.Count > 2)
                {
                    e.Graphics.DrawString("诊断/手术名称 " + personMessageArr[2].ToString().Trim(), font1, brush1, rec, format);
                }
                else
                {
                    e.Graphics.DrawString("诊断/手术名称 ", font1, brush1, rec, format);

                }
                //手术日期
                rec = new System.Drawing.RectangleF(head_table.Cell(0, 18).x, (head_table.Cell(0, 18).y), head_table.td_width * 4, head_table.td_height);
                format.Alignment = System.Drawing.StringAlignment.Near;
                format.LineAlignment = System.Drawing.StringAlignment.Center;
                if (this.personMessageArr.Count > 3)
                {
                    e.Graphics.DrawString("手术日期 " + personMessageArr[3].ToString().Trim(), font1, brush1, rec, format);
                }
                else
                {
                    e.Graphics.DrawString("手术日期 ", font1, brush1, rec, format);

                }
                //术后/入 ICU 第
                rec = new System.Drawing.RectangleF(head_table.Cell(0, 22).x, (head_table.Cell(0, 22).y), head_table.td_width * 3, head_table.td_height);
                format.Alignment = System.Drawing.StringAlignment.Near;
                format.LineAlignment = System.Drawing.StringAlignment.Center;
                if (this.personMessageArr.Count > 4)
                {
                    e.Graphics.DrawString("术后/入 ICU 第 " + personMessageArr[4].ToString().Trim(), font1, brush1, rec, format);
                }
                else
                {
                    e.Graphics.DrawString("术后/入 ICU 第 ", font1, brush1, rec, format);

                }
                //天
                rec = new System.Drawing.RectangleF(head_table.Cell(0, 25).x, (head_table.Cell(0, 25).y), head_table.td_width * 2, head_table.td_height);
                format.Alignment = System.Drawing.StringAlignment.Near;
                format.LineAlignment = System.Drawing.StringAlignment.Center;
                e.Graphics.DrawString("天", font1, brush1, rec, format);
                //第
                rec = new System.Drawing.RectangleF(head_table.Cell(0, 25).x, (head_table.Cell(0, 25).y), head_table.td_width * 2, head_table.td_height);
                format.Alignment = System.Drawing.StringAlignment.Far;
                format.LineAlignment = System.Drawing.StringAlignment.Center;
                e.Graphics.DrawString("第 " + ((this.CurrentCount + 1) / 2), font1, brush1, rec, format);
                //页
                rec = new System.Drawing.RectangleF(head_table.Cell(0, 27).x, (head_table.Cell(0, 27).y), head_table.td_width, head_table.td_height);
                format.Alignment = System.Drawing.StringAlignment.Near;
                format.LineAlignment = System.Drawing.StringAlignment.Center;
                e.Graphics.DrawString("页", font1, brush1, rec, format);
            }
            else
            {
                PrintTable head_table = new PrintTable(this.table_x, this.table_y, this.table_width, this.table_height, 1, 28);
                //姓名
                rec = new System.Drawing.RectangleF(head_table.Cell(0, 0).x, (head_table.Cell(0, 0).y), head_table.td_width * 2, head_table.td_height);
                format.Alignment = System.Drawing.StringAlignment.Near;
                format.LineAlignment = System.Drawing.StringAlignment.Center;
                e.Graphics.DrawString("姓名 ", font1, brush1, rec, format);

                //姓别
                rec = new System.Drawing.RectangleF(head_table.Cell(0, 2).x, (head_table.Cell(0, 2).y), head_table.td_width * 2, head_table.td_height);
                format.Alignment = System.Drawing.StringAlignment.Near;
                format.LineAlignment = System.Drawing.StringAlignment.Center;
                e.Graphics.DrawString("姓别 ", font1, brush1, rec, format);
                //年龄
                rec = new System.Drawing.RectangleF(head_table.Cell(0, 4).x, (head_table.Cell(0, 4).y), head_table.td_width * 2, head_table.td_height);
                format.Alignment = System.Drawing.StringAlignment.Near;
                format.LineAlignment = System.Drawing.StringAlignment.Center;
                e.Graphics.DrawString("年龄 ", font1, brush1, rec, format);
                //床号
                rec = new System.Drawing.RectangleF(head_table.Cell(0, 6).x, (head_table.Cell(0, 6).y), head_table.td_width * 2, head_table.td_height);
                format.Alignment = System.Drawing.StringAlignment.Near;
                format.LineAlignment = System.Drawing.StringAlignment.Center;
                e.Graphics.DrawString("床号 ", font1, brush1, rec, format);
                //体重
                rec = new System.Drawing.RectangleF(head_table.Cell(0, 8).x, (head_table.Cell(0, 8).y), head_table.td_width * 2, head_table.td_height);
                format.Alignment = System.Drawing.StringAlignment.Near;
                format.LineAlignment = System.Drawing.StringAlignment.Center;
                e.Graphics.DrawString("体重 ", font1, brush1, rec, format);
                //ID号
                rec = new System.Drawing.RectangleF(head_table.Cell(0, 10).x, (head_table.Cell(0, 10).y), head_table.td_width * 2, head_table.td_height);
                format.Alignment = System.Drawing.StringAlignment.Near;
                format.LineAlignment = System.Drawing.StringAlignment.Center;
                e.Graphics.DrawString("ID号 ", font1, brush1, rec, format);
                //诊断/手术名称
                rec = new System.Drawing.RectangleF(head_table.Cell(0, 12).x, (head_table.Cell(0, 12).y), head_table.td_width * 2, head_table.td_height);
                format.Alignment = System.Drawing.StringAlignment.Near;
                format.LineAlignment = System.Drawing.StringAlignment.Center;
                e.Graphics.DrawString("诊断/手术名称 ", font1, brush1, rec, format);
                //手术日期
                rec = new System.Drawing.RectangleF(head_table.Cell(0, 18).x, (head_table.Cell(0, 18).y), head_table.td_width * 4, head_table.td_height);
                format.Alignment = System.Drawing.StringAlignment.Near;
                format.LineAlignment = System.Drawing.StringAlignment.Center;
                e.Graphics.DrawString("手术日期 ", font1, brush1, rec, format);
                //术后/入 ICU 第
                rec = new System.Drawing.RectangleF(head_table.Cell(0, 22).x, (head_table.Cell(0, 22).y), head_table.td_width * 3, head_table.td_height);
                format.Alignment = System.Drawing.StringAlignment.Near;
                format.LineAlignment = System.Drawing.StringAlignment.Center;
                e.Graphics.DrawString("术后/入 ICU 第 ", font1, brush1, rec, format);
                //天
                rec = new System.Drawing.RectangleF(head_table.Cell(0, 25).x, (head_table.Cell(0, 25).y), head_table.td_width * 2, head_table.td_height);
                format.Alignment = System.Drawing.StringAlignment.Near;
                format.LineAlignment = System.Drawing.StringAlignment.Center;
                e.Graphics.DrawString("天", font1, brush1, rec, format);
                //第
                rec = new System.Drawing.RectangleF(head_table.Cell(0, 25).x, (head_table.Cell(0, 25).y), head_table.td_width * 2, head_table.td_height);
                format.Alignment = System.Drawing.StringAlignment.Far;
                format.LineAlignment = System.Drawing.StringAlignment.Center;
                e.Graphics.DrawString("第 " + ((this.CurrentCount + 1) / 2), font1, brush1, rec, format);
                //页
                rec = new System.Drawing.RectangleF(head_table.Cell(0, 27).x, (head_table.Cell(0, 27).y), head_table.td_width, head_table.td_height);
                format.Alignment = System.Drawing.StringAlignment.Near;
                format.LineAlignment = System.Drawing.StringAlignment.Center;
                e.Graphics.DrawString("页", font1, brush1, rec, format);
            }

            #endregion

            #region 画格式

            this.table_y = 100;
            this.table_width = 1600;
            this.table_height = 1150 - 100;

            PrintTable table = new PrintTable(this.table_x, this.table_y, this.table_width, this.table_height, 39, 28);
            //表的左边
            e.Graphics.DrawLine(new System.Drawing.Pen(Color.Black), table.Cell(0, 0).x, table.Cell(0, 0).y, table.Cell(table.row_count, 0).x, table.Cell(table.row_count, 0).y);
            //表的上边
            e.Graphics.DrawLine(new System.Drawing.Pen(Color.Black), table.Cell(0, 0).x, table.Cell(0, 0).y, table.Cell(0, table.column_count).x, table.Cell(0, table.column_count).y);

            //画中间的表格
            for (int i = 0; i < table.row_count; i++)
            {
                if (i > 6 && i < 36)
                {
                    if (i == 13 || i == 21 || i == 29)
                    {
                        e.Graphics.DrawLine(new System.Drawing.Pen(Color.Black), table.Cell(i, 0).x, table.Cell(i, 0).y, table.Cell(i, table.column_count).x, table.Cell(i, table.column_count).y);
                    }
                    else
                    {
                        e.Graphics.DrawLine(new System.Drawing.Pen(Color.Black), table.Cell(i, 1).x, table.Cell(i, 1).y, table.Cell(i, table.column_count).x, table.Cell(i, table.column_count).y);
                    }
                }
                else if (i > 36 && i < 39)
                {
                    e.Graphics.DrawLine(new System.Drawing.Pen(Color.Black), table.Cell(i, 3).x, table.Cell(i, 3).y, table.Cell(i, table.column_count).x, table.Cell(i, table.column_count).y);
                }
                else
                {
                    e.Graphics.DrawLine(new System.Drawing.Pen(Color.Black), table.Cell(i, 0).x, table.Cell(i, 0).y, table.Cell(i, table.column_count).x, table.Cell(i, table.column_count).y);
                }
                //	e.Graphics.DrawString(((int)(i)).ToString(),drawFont,drawBrush,float.Parse(table.Cell(0,i).x.ToString()),float.Parse(table.Cell(0,i).y.ToString()));
            }
            for (int i = 0; i < table.column_count; i++)
            {
                if (i == 1)
                {
                    e.Graphics.DrawLine(new System.Drawing.Pen(Color.Black), table.Cell(6, 1).x, table.Cell(6, 1).y, table.Cell(36, 1).x, table.Cell(36, 1).y);
                }
                else if (i == 2)
                {
                    continue;
                }
                else if (i == 3)
                {
                    e.Graphics.DrawLine(new System.Drawing.Pen(Color.Black), table.Cell(0, i).x, table.Cell(0, i).y, table.Cell(39, i).x, table.Cell(39, i).y);

                }
                else
                {
                    e.Graphics.DrawLine(new System.Drawing.Pen(Color.Black), table.Cell(0, i).x, table.Cell(0, i).y, table.Cell(table.column_count, i).x, table.Cell(36, i).y);
                }
            }
            //表的右边
            e.Graphics.DrawLine(new System.Drawing.Pen(Color.Black), table.Cell(0, table.column_count).x, table.Cell(0, table.column_count).y, table.Cell(table.row_count, table.column_count).x, table.Cell(table.row_count, table.column_count).y);
            //表的下边
            e.Graphics.DrawLine(new System.Drawing.Pen(Color.Black), table.Cell(table.row_count, 0).x, table.Cell(table.row_count, 0).y, table.Cell(table.row_count, table.column_count).x, table.Cell(table.row_count, table.column_count).y);

            int n1;
            //画第一行的格子连线	
            e.Graphics.DrawLine(new System.Drawing.Pen(Color.Black), table.Cell(0, 0).x, table.Cell(0, 0).y, table.Cell(1, 3).x, table.Cell(1, 3).y);
            //画第十行的格子连线	
            e.Graphics.DrawLine(new System.Drawing.Pen(Color.Black), table.Cell(11, 1).x, table.Cell(11, 1).y, table.Cell(10, 3).x, table.Cell(10, 3).y);
            //画第四行的格子连线
            n1 = 4;
            for (int i = 3; i < table.column_count; i++)
            {
                e.Graphics.DrawLine(new System.Drawing.Pen(Color.Black), table.Cell(n1, i).x, table.Cell(n1, i).y, table.Cell(n1 - 1, i + 1).x, table.Cell(n1 - 1, i + 1).y);
            }
            //画第五行的格子连线
            n1 = 5;
            for (int i = 3; i < table.column_count; i++)
            {
                e.Graphics.DrawLine(new System.Drawing.Pen(Color.Black), table.Cell(n1, i).x, table.Cell(n1, i).y, table.Cell(n1 - 1, i + 1).x, table.Cell(n1 - 1, i + 1).y);
            }
            //画第22行的格子连线
            n1 = 22;
            e.Graphics.DrawLine(new System.Drawing.Pen(Color.Black), table.Cell(22, 1).x, table.Cell(22, 1).y, table.Cell(21, 3).x, table.Cell(21, 3).y);
            for (int i = 3; i < table.column_count; i++)
            {
                e.Graphics.DrawLine(new System.Drawing.Pen(Color.Black), table.Cell(n1, i).x, table.Cell(n1, i).y, table.Cell(n1 - 1, i + 1).x, table.Cell(n1 - 1, i + 1).y);
            }
            #endregion

            #region 填数据


            //项目
            rec = new System.Drawing.RectangleF(table.Cell(0, 0).x, (table.Cell(0, 0).y + height_add), table.td_width * 3, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Near;
            e.Graphics.DrawString("项目", font1, brush1, rec, format);
            //时间
            rec = new System.Drawing.RectangleF(table.Cell(0, 0).x, (table.Cell(0, 0).y), table.td_width * 3, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Far;
            e.Graphics.DrawString("时间", font1, brush1, rec, format);
            //体位
            rec = new System.Drawing.RectangleF(table.Cell(1, 0).x, (table.Cell(1, 0).y), table.td_width * 3, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("体    位", font1, brush1, rec, format);
            //意识
            rec = new System.Drawing.RectangleF(table.Cell(2, 0).x, (table.Cell(2, 0).y), table.td_width * 3, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("意    识", font1, brush1, rec, format);
            //瞳孔(左/右)
            rec = new System.Drawing.RectangleF(table.Cell(3, 0).x, (table.Cell(3, 0).y), table.td_width * 3, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("瞳孔(左/右)", font1, brush1, rec, format);
            //对光反射(左/右)
            rec = new System.Drawing.RectangleF(table.Cell(4, 0).x, (table.Cell(4, 0).y), table.td_width * 3, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("对光反射(左/右)", font1, brush1, rec, format);
            //体温
            rec = new System.Drawing.RectangleF(table.Cell(6, 1).x, (table.Cell(6, 1).y), table.td_width * 2, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("体  温", font1, brush1, rec, format);
            //未稍温
            rec = new System.Drawing.RectangleF(table.Cell(7, 1).x, (table.Cell(7, 1).y), table.td_width * 2, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("未稍温", font1, brush1, rec, format);
            //心  率
            rec = new System.Drawing.RectangleF(table.Cell(8, 1).x, (table.Cell(8, 1).y), table.td_width * 2, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("心  率", font1, brush1, rec, format);
            //心 律
            rec = new System.Drawing.RectangleF(table.Cell(9, 1).x, (table.Cell(9, 1).y), table.td_width * 2, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("心 律", font1, brush1, rec, format);
            //CVP
            rec = new System.Drawing.RectangleF(table.Cell(12, 1).x, (table.Cell(12, 1).y), table.td_width * 2, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("CVP", font1, brush1, rec, format);
            //GS
            rec = new System.Drawing.RectangleF(table.Cell(22, 1).x, (table.Cell(22, 1).y), table.td_width * 2, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("GS", font1, brush1, rec, format);
            //NS
            rec = new System.Drawing.RectangleF(table.Cell(23, 1).x, (table.Cell(23, 1).y), table.td_width * 2, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("NS", font1, brush1, rec, format);
            //累  计
            rec = new System.Drawing.RectangleF(table.Cell(28, 1).x, (table.Cell(28, 1).y), table.td_width * 2, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("累  计", font1, brush1, rec, format);
            //累  计
            rec = new System.Drawing.RectangleF(table.Cell(29, 1).x, (table.Cell(29, 1).y), table.td_width * 2, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("累  计", font1, brush1, rec, format);
            //尿  量
            rec = new System.Drawing.RectangleF(table.Cell(31, 1).x, (table.Cell(31, 1).y), table.td_width * 2, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("尿  量", font1, brush1, rec, format);
            //胃  液
            rec = new System.Drawing.RectangleF(table.Cell(33, 1).x, (table.Cell(33, 1).y), table.td_width * 2, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("胃  液", font1, brush1, rec, format);
            //S
            rec = new System.Drawing.RectangleF(table.Cell(10, 1).x, (table.Cell(10, 1).y), table.td_width * 2, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Near;
            e.Graphics.DrawString("S", font1, brush1, rec, format);
            //D
            rec = new System.Drawing.RectangleF(table.Cell(10, 1).x, (table.Cell(10, 1).y + this.height_add), table.td_width * 2, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Far;
            e.Graphics.DrawString("D", font1, brush1, rec, format);
            //自制品
            rec = new System.Drawing.RectangleF(table.Cell(21, 1).x, (table.Cell(21, 1).y), table.td_width * 2, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Near;
            e.Graphics.DrawString("自制品", font2, brush1, rec, format);
            //累计量
            rec = new System.Drawing.RectangleF(table.Cell(21, 1).x, (table.Cell(21, 1).y + this.height_add), table.td_width * 2, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Far;
            e.Graphics.DrawString("累计量", font2, brush1, rec, format);
            //循环系统
            rec = new System.Drawing.RectangleF(table.Cell(6, 0).x, (table.Cell(6, 0).y), table.td_width, table.td_height * 7);
            format = new StringFormat(System.Drawing.StringFormatFlags.DirectionVertical);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("循  环  系  统", font1, brush1, rec, format);
            //用药及治疗
            rec = new System.Drawing.RectangleF(table.Cell(13, 0).x, (table.Cell(13, 0).y), table.td_width, table.td_height * 8);
            format = new StringFormat(System.Drawing.StringFormatFlags.DirectionVertical);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("用  药  及  治  疗", font1, brush1, rec, format);
            //入量
            rec = new System.Drawing.RectangleF(table.Cell(21, 0).x, (table.Cell(21, 0).y), table.td_width, table.td_height * 8);
            format = new StringFormat(System.Drawing.StringFormatFlags.DirectionVertical);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("入   量", font1, brush1, rec, format);
            //出量
            rec = new System.Drawing.RectangleF(table.Cell(29, 0).x, (table.Cell(29, 0).y), table.td_width, table.td_height * 7);
            format = new StringFormat(System.Drawing.StringFormatFlags.DirectionVertical);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("出   量", font1, brush1, rec, format);
            //特殊记录
            rec = new System.Drawing.RectangleF(table.Cell(36, 0).x, (table.Cell(36, 0).y), table.td_width * 3, table.td_height * 3);
            format = new StringFormat(System.Drawing.StringFormatFlags.DirectionVertical);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("特殊记录", font1, brush1, rec, format);

            #endregion

            #region 填内容
            if (this.printTable.Rows.Count < 0)
                return;
            this.RowLength = 0;
            int cell_count = 1;
            this.CurrentPrintColumn = 3;
            string cell_value = "";
            this.CurrentDTRow = this.CurrentPageDTRow;
            while (this.CurrentDTRow < this.printTable.Rows.Count)
            {

                for (int i = 0; i < this.printTable.Columns.Count; i++)
                {
                    if (this.printTable.Rows[this.CurrentDTRow][i].ToString().Trim().Length > this.RowLength)
                    {
                        this.RowLength = this.printTable.Rows[this.CurrentDTRow][i].ToString().Trim().Length;
                        //占用的格位
                        cell_count = (int)this.RowLength / 6;
                    }
                }
                if ((this.CurrentPrintColumn + cell_count) > 28)
                {

                    break;
                }
                format = new StringFormat();
                rec = new System.Drawing.RectangleF(table.Cell(0, this.CurrentPrintColumn).x, (table.Cell(0, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);
                format.Alignment = System.Drawing.StringAlignment.Near;
                format.LineAlignment = System.Drawing.StringAlignment.Center;
                //时间
                if (this.printTable.Columns.Contains("RecordDateofDay") && this.printTable.Columns.Contains("RecordTime"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["RecordDateofDay"].ToString().Trim() + " " + this.printTable.Rows[this.CurrentDTRow]["RecordTime"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                //体位
                rec = new System.Drawing.RectangleF(table.Cell(1, this.CurrentPrintColumn).x, (table.Cell(1, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("PBODYPART"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["PBODYPART"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                //意识
                rec = new System.Drawing.RectangleF(table.Cell(2, this.CurrentPrintColumn).x, (table.Cell(2, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("PCONSCIOUSNESS"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["PCONSCIOUSNESS"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                //瞳孔
                rec = new System.Drawing.RectangleF(table.Cell(3, this.CurrentPrintColumn).x, (table.Cell(3, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("PPUPIL"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["PPUPIL"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }

                this.value_arry = cell_value.Split("/".ToCharArray());
                //左
                if (this.value_arry.Length > 0)
                {
                    cell_value = value_arry[0].ToString().Trim();


                    rec = new System.Drawing.RectangleF(table.Cell(3, this.CurrentPrintColumn).x, (table.Cell(3, this.CurrentPrintColumn).y), table.td_width, table.td_height);
                    format.Alignment = System.Drawing.StringAlignment.Near;
                    e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                }
                //右
                if (this.value_arry.Length > 1)
                {
                    cell_value = value_arry[1].ToString().Trim();

                    rec = new System.Drawing.RectangleF(table.Cell(3, this.CurrentPrintColumn).x, (table.Cell(3, this.CurrentPrintColumn).y + this.height_add), table.td_width, table.td_height);
                    format.Alignment = System.Drawing.StringAlignment.Far;
                    e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                }

                format.Alignment = System.Drawing.StringAlignment.Near;
                //对光反射
                rec = new System.Drawing.RectangleF(table.Cell(4, this.CurrentPrintColumn).x, (table.Cell(4, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("PREFLECT"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["PREFLECT"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                this.value_arry = cell_value.Split("/".ToCharArray());
                //左
                if (this.value_arry.Length > 0)
                {
                    cell_value = value_arry[0].ToString().Trim();


                    rec = new System.Drawing.RectangleF(table.Cell(4, this.CurrentPrintColumn).x, (table.Cell(4, this.CurrentPrintColumn).y), table.td_width, table.td_height);
                    format.Alignment = System.Drawing.StringAlignment.Near;
                    e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                }
                //右
                if (this.value_arry.Length > 1)
                {
                    cell_value = value_arry[1].ToString().Trim();

                    rec = new System.Drawing.RectangleF(table.Cell(4, this.CurrentPrintColumn).x, (table.Cell(4, this.CurrentPrintColumn).y + this.height_add), table.td_width, table.td_height);
                    format.Alignment = System.Drawing.StringAlignment.Far;
                    e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                }

                format.Alignment = System.Drawing.StringAlignment.Near;
                //体温
                rec = new System.Drawing.RectangleF(table.Cell(6, this.CurrentPrintColumn).x, (table.Cell(6, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("CTEMPERATURE"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["CTEMPERATURE"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                //未稍温
                rec = new System.Drawing.RectangleF(table.Cell(7, this.CurrentPrintColumn).x, (table.Cell(7, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("CSMALLTEMPERATURE"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["CSMALLTEMPERATURE"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                //心率
                rec = new System.Drawing.RectangleF(table.Cell(8, this.CurrentPrintColumn).x, (table.Cell(8, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("CHEARTRATE"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["CHEARTRATE"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                //心律
                rec = new System.Drawing.RectangleF(table.Cell(9, this.CurrentPrintColumn).x, (table.Cell(9, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("CHEARTRHYTHM"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["CHEARTRHYTHM"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                //S/D
                rec = new System.Drawing.RectangleF(table.Cell(10, this.CurrentPrintColumn).x, (table.Cell(10, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("CSD"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["CSD"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);

                //CVP
                rec = new System.Drawing.RectangleF(table.Cell(12, this.CurrentPrintColumn).x, (table.Cell(12, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("CCVP"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["CCVP"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                //用药1-8   1
                rec = new System.Drawing.RectangleF(table.Cell(13, this.CurrentPrintColumn).x, (table.Cell(13, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("DPHYSIC1"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["DPHYSIC1"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                //用药1-8  2
                rec = new System.Drawing.RectangleF(table.Cell(14, this.CurrentPrintColumn).x, (table.Cell(14, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("DPHYSIC2"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["DPHYSIC2"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                //用药1-8  3
                rec = new System.Drawing.RectangleF(table.Cell(15, this.CurrentPrintColumn).x, (table.Cell(15, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("DPHYSIC3"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["DPHYSIC3"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                //用药1-8  4
                rec = new System.Drawing.RectangleF(table.Cell(16, this.CurrentPrintColumn).x, (table.Cell(16, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("DPHYSIC4"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["DPHYSIC4"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                //用药1-8  5
                rec = new System.Drawing.RectangleF(table.Cell(17, this.CurrentPrintColumn).x, (table.Cell(17, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("DPHYSIC5"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["DPHYSIC5"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                //用药1-8  6
                rec = new System.Drawing.RectangleF(table.Cell(18, this.CurrentPrintColumn).x, (table.Cell(18, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("DPHYSIC6"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["DPHYSIC6"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                //用药1-8  7
                rec = new System.Drawing.RectangleF(table.Cell(19, this.CurrentPrintColumn).x, (table.Cell(19, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("DPHYSIC7"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["DPHYSIC7"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                //用药1-8  8
                rec = new System.Drawing.RectangleF(table.Cell(20, this.CurrentPrintColumn).x, (table.Cell(20, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("DPHYSIC8"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["DPHYSIC8"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                //自制品/累计量
                rec = new System.Drawing.RectangleF(table.Cell(21, this.CurrentPrintColumn).x, (table.Cell(21, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("IBLOODPRODUCE"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["IBLOODPRODUCE"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                this.value_arry = cell_value.Split("/".ToCharArray());
                //左
                if (this.value_arry.Length > 0)
                {
                    cell_value = value_arry[0].ToString().Trim();


                    rec = new System.Drawing.RectangleF(table.Cell(21, this.CurrentPrintColumn).x, (table.Cell(21, this.CurrentPrintColumn).y), table.td_width, table.td_height);
                    format.Alignment = System.Drawing.StringAlignment.Near;
                    e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                }
                //右
                if (this.value_arry.Length > 1)
                {
                    cell_value = value_arry[1].ToString().Trim();

                    rec = new System.Drawing.RectangleF(table.Cell(21, this.CurrentPrintColumn).x, (table.Cell(21, this.CurrentPrintColumn).y + this.height_add), table.td_width, table.td_height);
                    format.Alignment = System.Drawing.StringAlignment.Far;
                    e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                }

                format.Alignment = System.Drawing.StringAlignment.Near;
                //GS
                rec = new System.Drawing.RectangleF(table.Cell(22, this.CurrentPrintColumn).x, (table.Cell(22, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("IGS"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["IGS"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                //NS
                rec = new System.Drawing.RectangleF(table.Cell(23, this.CurrentPrintColumn).x, (table.Cell(23, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("INS"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["INS"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                //入量1-4
                rec = new System.Drawing.RectangleF(table.Cell(24, this.CurrentPrintColumn).x, (table.Cell(24, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);


                if (this.printTable.Columns.Contains("INNAME1"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["INNAME1"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                //入量1-4
                rec = new System.Drawing.RectangleF(table.Cell(25, this.CurrentPrintColumn).x, (table.Cell(25, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("INNAME2"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["INNAME2"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                //入量1-4
                rec = new System.Drawing.RectangleF(table.Cell(26, this.CurrentPrintColumn).x, (table.Cell(26, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("INNAME3"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["INNAME3"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                //入量1-4
                rec = new System.Drawing.RectangleF(table.Cell(27, this.CurrentPrintColumn).x, (table.Cell(27, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("INNAME4"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["INNAME4"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                //入量累计
                rec = new System.Drawing.RectangleF(table.Cell(28, this.CurrentPrintColumn).x, (table.Cell(28, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("OTATAL"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["OTATAL"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                //出量累计
                rec = new System.Drawing.RectangleF(table.Cell(29, this.CurrentPrintColumn).x, (table.Cell(29, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("OEMIEMCTION"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["OEMIEMCTION"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);

                //特殊记录
                rec = new System.Drawing.RectangleF(table.Cell(36, 3).x, (table.Cell(36, 3).y), table.td_width * 28, table.td_height * 3);

                if (this.printTable.Columns.Contains("SESPECIALLYNOTE"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["SESPECIALLYNOTE"].ToString().Trim();

                }
                else
                {
                    cell_value = "";
                }
                SpecString += cell_value;
                e.Graphics.DrawString(SpecString, font2, brush1, rec, format);

                //下一条记录

                this.CurrentDTRow++;

                //跳位
                this.CurrentPrintColumn += cell_count;
                cell_count = 1;
                this.RowLength = 0;
            }
            #endregion
        }

        #endregion

        #region 反面打印
        /// <summary>
        /// 反面打印
        /// </summary>
        public void printTheBack(System.Drawing.Printing.PrintPageEventArgs e)
        {


            #region 画格式
            PrintTable table = new PrintTable(10, 10, 1600, 1130, 33, 28);
            //表的左边
            e.Graphics.DrawLine(new System.Drawing.Pen(Color.Black), table.Cell(0, 0).x, table.Cell(0, 0).y, table.Cell(table.row_count, 0).x, table.Cell(table.row_count, 0).y);
            //表的上边
            e.Graphics.DrawLine(new System.Drawing.Pen(Color.Black), table.Cell(0, 0).x, table.Cell(0, 0).y, table.Cell(0, table.column_count).x, table.Cell(0, table.column_count).y);

            //画中间的表格
            for (int i = 0; i < table.row_count; i++)
            {

                if (i == 1 || i == 13 || i == 22 || i == 28)
                {
                    e.Graphics.DrawLine(new System.Drawing.Pen(Color.Black), table.Cell(i, 0).x, table.Cell(i, 0).y, table.Cell(i, table.column_count).x, table.Cell(i, table.column_count).y);
                }
                else if (i == 24 || i == 25)
                {
                    e.Graphics.DrawLine(new System.Drawing.Pen(Color.Black), table.Cell(i, 2).x, table.Cell(i, 2).y, table.Cell(i, table.column_count).x, table.Cell(i, table.column_count).y);
                }
                else
                {
                    e.Graphics.DrawLine(new System.Drawing.Pen(Color.Black), table.Cell(i, 1).x, table.Cell(i, 1).y, table.Cell(i, table.column_count).x, table.Cell(i, table.column_count).y);
                }

            }
            for (int i = 0; i < table.column_count; i++)
            {
                if (i == 1)
                {
                    e.Graphics.DrawLine(new System.Drawing.Pen(Color.Black), table.Cell(1, i).x, table.Cell(1, i).y, table.Cell(table.row_count, i).x, table.Cell(table.row_count, i).y);
                }
                else if (i == 2)
                {
                    e.Graphics.DrawLine(new System.Drawing.Pen(Color.Black), table.Cell(22, i).x, table.Cell(22, i).y, table.Cell(26, i).x, table.Cell(26, i).y);
                }
                else
                {
                    e.Graphics.DrawLine(new System.Drawing.Pen(Color.Black), table.Cell(0, i).x, table.Cell(0, i).y, table.Cell(table.row_count, i).x, table.Cell(table.row_count, i).y);
                }
            }
            //表的右边
            e.Graphics.DrawLine(new System.Drawing.Pen(Color.Black), table.Cell(0, table.column_count).x, table.Cell(0, table.column_count).y, table.Cell(table.row_count, table.column_count).x, table.Cell(table.row_count, table.column_count).y);
            //表的下边
            e.Graphics.DrawLine(new System.Drawing.Pen(Color.Black), table.Cell(table.row_count, 0).x, table.Cell(table.row_count, 0).y, table.Cell(table.row_count, table.column_count).x, table.Cell(table.row_count, table.column_count).y);

            int n1;
            //画第一行的格子连线	
            e.Graphics.DrawLine(new System.Drawing.Pen(Color.Black), table.Cell(0, 0).x, table.Cell(0, 0).y, table.Cell(1, 3).x, table.Cell(1, 3).y);
            //画第二十四行的格子连线	
            e.Graphics.DrawLine(new System.Drawing.Pen(Color.Black), table.Cell(24, 2).x, table.Cell(24, 2).y, table.Cell(23, 3).x, table.Cell(23, 3).y);
            //画第九行的格子连线
            n1 = 9;
            e.Graphics.DrawLine(new System.Drawing.Pen(Color.Black), table.Cell(9, 1).x, table.Cell(9, 1).y, table.Cell(8, 3).x, table.Cell(8, 3).y);
            for (int i = 3; i < table.column_count; i++)
            {
                e.Graphics.DrawLine(new System.Drawing.Pen(Color.Black), table.Cell(n1, i).x, table.Cell(n1, i).y, table.Cell(n1 - 1, i + 1).x, table.Cell(n1 - 1, i + 1).y);
            }
            //画第十二行的格子连线
            n1 = 12;
            e.Graphics.DrawLine(new System.Drawing.Pen(Color.Black), table.Cell(12, 1).x, table.Cell(12, 1).y, table.Cell(11, 3).x, table.Cell(11, 3).y);
            for (int i = 3; i < table.column_count; i++)
            {
                e.Graphics.DrawLine(new System.Drawing.Pen(Color.Black), table.Cell(n1, i).x, table.Cell(n1, i).y, table.Cell(n1 - 1, i + 1).x, table.Cell(n1 - 1, i + 1).y);
            }


            #endregion

            #region 填数据
            format = new StringFormat();

            //项目
            rec = new System.Drawing.RectangleF(table.Cell(0, 0).x, (table.Cell(0, 0).y + height_add), table.td_width * 3, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Near;
            e.Graphics.DrawString("项目", font1, brush1, rec, format);
            //时间
            rec = new System.Drawing.RectangleF(table.Cell(0, 0).x, (table.Cell(0, 0).y), table.td_width * 3, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Far;
            e.Graphics.DrawString("时间", font1, brush1, rec, format);
            //插管时间
            rec = new System.Drawing.RectangleF(table.Cell(1, 1).x, (table.Cell(1, 1).y), table.td_width * 2, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("插管时间", font1, brush1, rec, format);
            //呼吸机型号
            rec = new System.Drawing.RectangleF(table.Cell(2, 1).x, (table.Cell(2, 1).y), table.td_width * 2, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("呼吸机型号", font1, brush1, rec, format);
            //呼吸方式
            rec = new System.Drawing.RectangleF(table.Cell(3, 1).x, (table.Cell(3, 1).y), table.td_width * 2, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("呼吸方式", font1, brush1, rec, format);

            //Vt*************
            rec = new System.Drawing.RectangleF(table.Cell(4, 1).x, (table.Cell(4, 1).y), table.td_width, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Far;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("V", font1, brush1, rec, format);

            rec = new System.Drawing.RectangleF(table.Cell(4, 2).x, (table.Cell(4, 2).y + this.height_add), table.td_width, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Near;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("T", font3, brush1, rec, format);
            /*-------------------------------------------*/
            //Expried MV************************8
            rec = new System.Drawing.RectangleF(table.Cell(5, 1).x, (table.Cell(5, 1).y), table.td_width * 2, table.td_height / 2);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Far;
            e.Graphics.DrawString("Expried", font2, brush1, rec, format);

            rec = new System.Drawing.RectangleF(table.Cell(5, 1).x, (table.Cell(5, 1).y + table.td_height / 2), table.td_width * 2, table.td_height / 2);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Near;
            e.Graphics.DrawString("MV", font2, brush1, rec, format);
            /*----------------------------------------------*/
            /*-------------------------------------------*/
            //SO2(%)************************8
            rec = new System.Drawing.RectangleF(table.Cell(12, 1).x, (table.Cell(12, 1).y), table.td_width, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Far;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("SO", font1, brush1, rec, format);

            rec = new System.Drawing.RectangleF(table.Cell(12, 1).x + table.td_width / 4, (table.Cell(12, 1).y), table.td_width - table.td_width / 5, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Far;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("2", font3, brush1, rec, format);

            rec = new System.Drawing.RectangleF(table.Cell(12, 2).x, (table.Cell(12, 2).y), table.td_width, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Near;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("(%)", font1, brush1, rec, format);
            /*----------------------------------------------*/

            //PCO2(K+)************************8
            rec = new System.Drawing.RectangleF(table.Cell(15, 1).x, (table.Cell(15, 1).y), table.td_width, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Far;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("PCO", font1, brush1, rec, format);

            rec = new System.Drawing.RectangleF(table.Cell(15, 1).x + table.td_width / 4, (table.Cell(15, 1).y), table.td_width - table.td_width / 5, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Far;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("2", font3, brush1, rec, format);

            rec = new System.Drawing.RectangleF(table.Cell(15, 2).x, (table.Cell(15, 2).y), table.td_width, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Near;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("(K", font1, brush1, rec, format);

            rec = new System.Drawing.RectangleF(table.Cell(15, 2).x + table.td_width / 3, (table.Cell(15, 2).y + table.td_height / 4), table.td_width - table.td_width / 5, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Near;
            format.LineAlignment = System.Drawing.StringAlignment.Near;
            e.Graphics.DrawString("+", font3, brush1, rec, format);

            rec = new System.Drawing.RectangleF(table.Cell(15, 2).x, (table.Cell(15, 2).y), table.td_width, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString(")", font1, brush1, rec, format);
            /*----------------------------------------------*/

            //PO2(Na+)************************
            rec = new System.Drawing.RectangleF(table.Cell(16, 1).x, (table.Cell(16, 1).y), table.td_width, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Far;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("PO", font1, brush1, rec, format);

            rec = new System.Drawing.RectangleF(table.Cell(16, 1).x + table.td_width / 4, (table.Cell(16, 1).y), table.td_width - table.td_width / 5, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Far;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("2", font3, brush1, rec, format);

            rec = new System.Drawing.RectangleF(table.Cell(16, 2).x, (table.Cell(16, 2).y), table.td_width, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Near;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("(Na", font1, brush1, rec, format);

            rec = new System.Drawing.RectangleF(table.Cell(16, 2).x + table.td_width / 2, (table.Cell(16, 2).y + table.td_height / 4), table.td_width - table.td_width / 5, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Near;
            format.LineAlignment = System.Drawing.StringAlignment.Near;
            e.Graphics.DrawString("+", font3, brush1, rec, format);

            rec = new System.Drawing.RectangleF(table.Cell(16, 2).x, (table.Cell(16, 2).y), table.td_width - table.td_width / 4, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Far;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString(")", font1, brush1, rec, format);
            /*----------------------------------------------*/

            //HCO3(Cl+)************************
            rec = new System.Drawing.RectangleF(table.Cell(17, 1).x, (table.Cell(17, 1).y), table.td_width, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Far;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("HCO", font1, brush1, rec, format);

            rec = new System.Drawing.RectangleF(table.Cell(17, 1).x + table.td_width / 4, (table.Cell(17, 1).y), table.td_width - table.td_width / 5, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Far;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("3", font3, brush1, rec, format);

            rec = new System.Drawing.RectangleF(table.Cell(17, 2).x, (table.Cell(17, 2).y), table.td_width, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Near;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("(Cl", font1, brush1, rec, format);

            rec = new System.Drawing.RectangleF(table.Cell(17, 2).x + table.td_width / 2, (table.Cell(17, 2).y + table.td_height / 4), table.td_width - table.td_width / 5, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Near;
            format.LineAlignment = System.Drawing.StringAlignment.Near;
            e.Graphics.DrawString("+", font3, brush1, rec, format);

            rec = new System.Drawing.RectangleF(table.Cell(17, 2).x, (table.Cell(17, 2).y), table.td_width - table.td_width / 4, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Far;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString(")", font1, brush1, rec, format);
            /*----------------------------------------------*/
            //TCO2(Ca++)************************
            rec = new System.Drawing.RectangleF(table.Cell(18, 1).x, (table.Cell(18, 1).y), table.td_width, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Far;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("TCO", font1, brush1, rec, format);

            rec = new System.Drawing.RectangleF(table.Cell(18, 1).x + table.td_width / 4, (table.Cell(18, 1).y), table.td_width - table.td_width / 5, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Far;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("2", font3, brush1, rec, format);

            rec = new System.Drawing.RectangleF(table.Cell(18, 2).x, (table.Cell(18, 2).y), table.td_width, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Near;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("(Ca", font1, brush1, rec, format);

            rec = new System.Drawing.RectangleF(table.Cell(18, 2).x + table.td_width / 2, (table.Cell(18, 2).y + table.td_height / 4), table.td_width - table.td_width / 5, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Near;
            format.LineAlignment = System.Drawing.StringAlignment.Near;
            e.Graphics.DrawString("++", font3, brush1, rec, format);

            rec = new System.Drawing.RectangleF(table.Cell(18, 2).x, (table.Cell(18, 2).y), table.td_width, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Far;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString(")", font1, brush1, rec, format);
            /*----------------------------------------------*/
            //O2CT************************
            rec = new System.Drawing.RectangleF(table.Cell(21, 1).x, (table.Cell(21, 1).y), table.td_width, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Far;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("O", font1, brush1, rec, format);

            rec = new System.Drawing.RectangleF(table.Cell(21, 1).x + table.td_width / 4, (table.Cell(21, 1).y), table.td_width - table.td_width / 5, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Far;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("2", font3, brush1, rec, format);

            rec = new System.Drawing.RectangleF(table.Cell(21, 2).x, (table.Cell(21, 2).y), table.td_width, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Near;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("CT", font1, brush1, rec, format);


            /*----------------------------------------------*/


            //气道压力
            rec = new System.Drawing.RectangleF(table.Cell(6, 1).x, (table.Cell(6, 1).y), table.td_width * 2, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("气道压力", font1, brush1, rec, format);
            //呼吸次数
            rec = new System.Drawing.RectangleF(table.Cell(7, 1).x, (table.Cell(7, 1).y), table.td_width * 2, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("呼吸次数", font1, brush1, rec, format);
            //Max.I.P
            rec = new System.Drawing.RectangleF(table.Cell(9, 1).x, (table.Cell(9, 1).y), table.td_width * 2, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("Max.I.P", font1, brush1, rec, format);
            //呼吸音
            rec = new System.Drawing.RectangleF(table.Cell(10, 1).x, (table.Cell(10, 1).y), table.td_width * 2, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("呼吸音", font1, brush1, rec, format);
            //采血点
            rec = new System.Drawing.RectangleF(table.Cell(13, 1).x, (table.Cell(13, 1).y), table.td_width * 2, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("采血点", font1, brush1, rec, format);
            //PH
            rec = new System.Drawing.RectangleF(table.Cell(14, 1).x, (table.Cell(14, 1).y), table.td_width * 2, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("PH", font1, brush1, rec, format);
            //BE(Bun)
            rec = new System.Drawing.RectangleF(table.Cell(19, 1).x, (table.Cell(19, 1).y), table.td_width * 2, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("BE(Bun)", font1, brush1, rec, format);
            //SAT(Cr)
            rec = new System.Drawing.RectangleF(table.Cell(20, 1).x, (table.Cell(20, 1).y), table.td_width * 2, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("SAT(Cr)", font1, brush1, rec, format);
            //RA
            rec = new System.Drawing.RectangleF(table.Cell(22, 1).x, (table.Cell(22, 1).y), table.td_width, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("RA", font1, brush1, rec, format);
            //PA
            rec = new System.Drawing.RectangleF(table.Cell(23, 1).x, (table.Cell(23, 1).y), table.td_width, table.td_height * 3);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("PA", font1, brush1, rec, format);

            //CmH2O
            rec = new System.Drawing.RectangleF(table.Cell(22, 2).x, (table.Cell(22, 2).y), table.td_width, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Near;
            format.LineAlignment = System.Drawing.StringAlignment.Near;
            e.Graphics.DrawString("CmH", font2, brush1, rec, format);

            rec = new System.Drawing.RectangleF(table.Cell(22, 2).x + table.td_width / 2, (table.Cell(22, 2).y + this.height_add), table.td_width - table.td_width / 2, table.td_height - table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Near;
            e.Graphics.DrawString("2", font3, brush1, rec, format);

            rec = new System.Drawing.RectangleF(table.Cell(22, 2).x, (table.Cell(22, 2).y), table.td_width, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Far;
            format.LineAlignment = System.Drawing.StringAlignment.Near;
            e.Graphics.DrawString("0", font2, brush1, rec, format);

            //mmHg
            rec = new System.Drawing.RectangleF(table.Cell(22, 2).x, (table.Cell(22, 2).y), table.td_width, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Far;
            e.Graphics.DrawString("mmHg", font2, brush1, rec, format);

            //Mean
            rec = new System.Drawing.RectangleF(table.Cell(24, 2).x, (table.Cell(24, 2).y), table.td_width, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("Mean", font1, brush1, rec, format);
            //Wedge
            rec = new System.Drawing.RectangleF(table.Cell(25, 2).x, (table.Cell(25, 2).y), table.td_width, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("Wedge", font1, brush1, rec, format);
            //CO/CI
            rec = new System.Drawing.RectangleF(table.Cell(26, 1).x, (table.Cell(26, 1).y), table.td_width * 2, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("CO/CI", font1, brush1, rec, format);
            //S
            rec = new System.Drawing.RectangleF(table.Cell(23, 2).x, (table.Cell(23, 2).y), table.td_width, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Near;
            e.Graphics.DrawString("S", font1, brush1, rec, format);
            //D
            rec = new System.Drawing.RectangleF(table.Cell(23, 2).x, (table.Cell(23, 2).y + this.height_add), table.td_width, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Far;
            e.Graphics.DrawString("D", font1, brush1, rec, format);

            //FIO2
            rec = new System.Drawing.RectangleF(table.Cell(8, 1).x, (table.Cell(8, 1).y), table.td_width, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Near;
            e.Graphics.DrawString("FIO", font1, brush1, rec, format);

            rec = new System.Drawing.RectangleF(table.Cell(8, 1).x + table.td_width / 2, (table.Cell(8, 1).y), table.td_width - table.td_width / 5, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Near;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("2", font3, brush1, rec, format);

            rec = new System.Drawing.RectangleF(table.Cell(8, 1).x + table.td_width / 2 + 2, (table.Cell(8, 1).y), table.td_width, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Near;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("(%)", font2, brush1, rec, format);


            /*----------------------------------------------*/
            //PEEP
            rec = new System.Drawing.RectangleF(table.Cell(8, 2).x, (table.Cell(8, 2).y + this.height_add), table.td_width, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Far;
            e.Graphics.DrawString("PEEP", font1, brush1, rec, format);

            rec = new System.Drawing.RectangleF(table.Cell(21, 1).x, (table.Cell(21, 1).y), table.td_width, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Far;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("O", font1, brush1, rec, format);

            rec = new System.Drawing.RectangleF(table.Cell(21, 1).x + table.td_width / 4, (table.Cell(21, 1).y), table.td_width - table.td_width / 5, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Far;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("2", font3, brush1, rec, format);

            rec = new System.Drawing.RectangleF(table.Cell(21, 2).x, (table.Cell(21, 2).y), table.td_width, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Near;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("CT", font1, brush1, rec, format);


            /*----------------------------------------------*/

            //痰色
            rec = new System.Drawing.RectangleF(table.Cell(11, 1).x, (table.Cell(11, 1).y), table.td_width, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Near;
            e.Graphics.DrawString("痰色", font1, brush1, rec, format);
            //痰量
            rec = new System.Drawing.RectangleF(table.Cell(11, 2).x, (table.Cell(11, 2).y + this.height_add), table.td_width, table.td_height);
            format.Alignment = System.Drawing.StringAlignment.Far;
            e.Graphics.DrawString("痰量", font1, brush1, rec, format);

            //呼吸系统
            rec = new System.Drawing.RectangleF(table.Cell(1, 0).x, (table.Cell(1, 0).y), table.td_width, table.td_height * 12);
            format = new StringFormat(System.Drawing.StringFormatFlags.DirectionVertical);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("呼  吸  系  统", font1, brush1, rec, format);
            //实验室检查
            rec = new System.Drawing.RectangleF(table.Cell(13, 0).x, (table.Cell(13, 0).y), table.td_width, table.td_height * 9);
            format = new StringFormat(System.Drawing.StringFormatFlags.DirectionVertical);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("实  验  室  检  查", font1, brush1, rec, format);

            //S-G Cath
            rec = new System.Drawing.RectangleF(table.Cell(22, 0).x, (table.Cell(22, 0).y), table.td_width, table.td_height * 6);
            format = new StringFormat(System.Drawing.StringFormatFlags.DirectionVertical);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.FormatFlags = System.Drawing.StringFormatFlags.DirectionVertical;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("S-G Cath", font1, brush1, rec, format);
            //Pressures
            rec = new System.Drawing.RectangleF(table.Cell(22, 0).x, (table.Cell(22, 0).y), table.td_width - table.td_width / 2, table.td_height * 6);
            format = new StringFormat(System.Drawing.StringFormatFlags.DirectionVertical);
            format.Alignment = System.Drawing.StringAlignment.Center;
            format.FormatFlags = System.Drawing.StringFormatFlags.DirectionVertical;
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString("Pressures", font2, brush1, rec, format);




            #endregion

            #region 填内容
            if (this.printTable.Rows.Count < 0)
                return;
            this.RowLength = 0;
            int cell_count = 1;
            this.CurrentPrintColumn = 3;
            string cell_value = "";
            this.CurrentDTRow = this.CurrentPageDTRow;


            while (this.CurrentDTRow < this.printTable.Rows.Count)
            {

                for (int i = 0; i < this.printTable.Columns.Count; i++)
                {
                    if (this.printTable.Rows[this.CurrentDTRow][i].ToString().Trim().Length > this.RowLength)
                    {
                        this.RowLength = this.printTable.Rows[this.CurrentDTRow][i].ToString().Trim().Length;
                        //占用的格位
                        cell_count = (int)this.RowLength / 6;
                    }
                }
                if ((this.CurrentPrintColumn + cell_count) > 28)
                {
                    this.pageCount += 2;
                    break;
                }
                format = new StringFormat();
                rec = new System.Drawing.RectangleF(table.Cell(0, this.CurrentPrintColumn).x, (table.Cell(0, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);
                format.Alignment = System.Drawing.StringAlignment.Near;
                format.LineAlignment = System.Drawing.StringAlignment.Center;
                //时间
                if (this.printTable.Columns.Contains("RecordDateofDay") && this.printTable.Columns.Contains("RecordTime"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["RecordDateofDay"].ToString().Trim() + " " + this.printTable.Rows[this.CurrentDTRow]["RecordTime"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                //插管时间
                rec = new System.Drawing.RectangleF(table.Cell(1, this.CurrentPrintColumn).x, (table.Cell(1, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("BBLUSETIME"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["BBLUSETIME"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                //呼吸机型号
                rec = new System.Drawing.RectangleF(table.Cell(2, this.CurrentPrintColumn).x, (table.Cell(2, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("BBLUSEMACHINETYPE"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["BBLUSEMACHINETYPE"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                //呼吸方式
                rec = new System.Drawing.RectangleF(table.Cell(3, this.CurrentPrintColumn).x, (table.Cell(3, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("BBLUSEMODE"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["BBLUSEMODE"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);



                //VT
                rec = new System.Drawing.RectangleF(table.Cell(4, this.CurrentPrintColumn).x, (table.Cell(4, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("BVT"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["BVT"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                //EXPIRED MV
                rec = new System.Drawing.RectangleF(table.Cell(5, this.CurrentPrintColumn).x, (table.Cell(5, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("BEXPIREDMV"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["BEXPIREDMV"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                //气道压力
                rec = new System.Drawing.RectangleF(table.Cell(6, this.CurrentPrintColumn).x, (table.Cell(6, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("BBLUESPRESSURE"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["BBLUESPRESSURE"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                //呼吸次数
                rec = new System.Drawing.RectangleF(table.Cell(7, this.CurrentPrintColumn).x, (table.Cell(7, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("BBLUSENUM"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["BBLUSENUM"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                //FIO2(%)  PEEP
                rec = new System.Drawing.RectangleF(table.Cell(8, this.CurrentPrintColumn).x, (table.Cell(8, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("BFIO2PEEP"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["BFIO2PEEP"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                this.value_arry = cell_value.Split("/".ToCharArray());
                //FIO2(%)
                if (this.value_arry.Length > 0)
                {
                    cell_value = value_arry[0].ToString().Trim();


                    rec = new System.Drawing.RectangleF(table.Cell(8, this.CurrentPrintColumn).x, (table.Cell(8, this.CurrentPrintColumn).y), table.td_width, table.td_height);
                    format.Alignment = System.Drawing.StringAlignment.Near;
                    e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                }
                //PEEP
                if (this.value_arry.Length > 1)
                {
                    cell_value = value_arry[1].ToString().Trim();

                    rec = new System.Drawing.RectangleF(table.Cell(8, this.CurrentPrintColumn).x, (table.Cell(8, this.CurrentPrintColumn).y + this.height_add), table.td_width, table.td_height);
                    format.Alignment = System.Drawing.StringAlignment.Far;
                    e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                }

                format.Alignment = System.Drawing.StringAlignment.Near;
                //MAX.IP
                rec = new System.Drawing.RectangleF(table.Cell(9, this.CurrentPrintColumn).x, (table.Cell(9, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("BMAXIP"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["BMAXIP"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                //呼吸音
                rec = new System.Drawing.RectangleF(table.Cell(10, this.CurrentPrintColumn).x, (table.Cell(10, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("BBLUSESOUND"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["BBLUSESOUND"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                //痰色  痰量
                rec = new System.Drawing.RectangleF(table.Cell(11, this.CurrentPrintColumn).x, (table.Cell(11, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("BPHLEGMCOLOR"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["BPHLEGMCOLOR"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                this.value_arry = cell_value.Split("/".ToCharArray());
                //痰色
                if (this.value_arry.Length > 0)
                {
                    cell_value = value_arry[0].ToString().Trim();


                    rec = new System.Drawing.RectangleF(table.Cell(11, this.CurrentPrintColumn).x, (table.Cell(11, this.CurrentPrintColumn).y), table.td_width, table.td_height);
                    format.Alignment = System.Drawing.StringAlignment.Near;
                    e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                }
                //痰量
                if (this.value_arry.Length > 1)
                {
                    cell_value = value_arry[1].ToString().Trim();

                    rec = new System.Drawing.RectangleF(table.Cell(11, this.CurrentPrintColumn).x, (table.Cell(11, this.CurrentPrintColumn).y + this.height_add), table.td_width, table.td_height);
                    format.Alignment = System.Drawing.StringAlignment.Far;
                    e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                }

                format.Alignment = System.Drawing.StringAlignment.Near;
                //SO2(%)
                rec = new System.Drawing.RectangleF(table.Cell(12, this.CurrentPrintColumn).x, (table.Cell(12, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("BSQ2"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["BSQ2"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                //采血点
                rec = new System.Drawing.RectangleF(table.Cell(13, this.CurrentPrintColumn).x, (table.Cell(13, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("TCOLLECTBLOODPOINT"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["TCOLLECTBLOODPOINT"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                //PH
                rec = new System.Drawing.RectangleF(table.Cell(14, this.CurrentPrintColumn).x, (table.Cell(14, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("TPH"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["TPH"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                //PC02(K+)
                rec = new System.Drawing.RectangleF(table.Cell(15, this.CurrentPrintColumn).x, (table.Cell(15, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("TPCO2"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["TPCO2"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                //PO2(NA+)
                rec = new System.Drawing.RectangleF(table.Cell(16, this.CurrentPrintColumn).x, (table.Cell(16, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("TP02"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["TP02"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                //HCO3(CL-)
                rec = new System.Drawing.RectangleF(table.Cell(17, this.CurrentPrintColumn).x, (table.Cell(17, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("THCO3"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["THCO3"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                //TCO2(CA++)
                rec = new System.Drawing.RectangleF(table.Cell(18, this.CurrentPrintColumn).x, (table.Cell(18, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("TTCO2"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["TTCO2"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);

                //BE(BUN)
                rec = new System.Drawing.RectangleF(table.Cell(19, this.CurrentPrintColumn).x, (table.Cell(19, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("TBE"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["TBE"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                //SAT(CR)
                rec = new System.Drawing.RectangleF(table.Cell(20, this.CurrentPrintColumn).x, (table.Cell(20, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("TSAT"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["TSAT"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                //O2CT
                rec = new System.Drawing.RectangleF(table.Cell(21, this.CurrentPrintColumn).x, (table.Cell(21, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);


                if (this.printTable.Columns.Contains("TO2CT"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["TO2CT"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                //CMH20MMHG
                rec = new System.Drawing.RectangleF(table.Cell(22, this.CurrentPrintColumn).x, (table.Cell(22, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("SCMH2O"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["SCMH2O"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                //S/D
                rec = new System.Drawing.RectangleF(table.Cell(23, this.CurrentPrintColumn).x, (table.Cell(23, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("SSD"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["SSD"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                //MEAN
                rec = new System.Drawing.RectangleF(table.Cell(24, this.CurrentPrintColumn).x, (table.Cell(24, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("SMEAN"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["SMEAN"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                //WEDGE
                rec = new System.Drawing.RectangleF(table.Cell(25, this.CurrentPrintColumn).x, (table.Cell(25, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("SWEDGE"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["SWEDGE"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);
                //CO/CI
                rec = new System.Drawing.RectangleF(table.Cell(26, this.CurrentPrintColumn).x, (table.Cell(26, this.CurrentPrintColumn).y), table.td_width * cell_count, table.td_height);

                if (this.printTable.Columns.Contains("SCOCI"))
                {
                    cell_value = this.printTable.Rows[this.CurrentDTRow]["SCOCI"].ToString().Trim();
                }
                else
                {
                    cell_value = "";
                }
                e.Graphics.DrawString(cell_value, font2, brush1, rec, format);



                //下一条记录

                this.CurrentDTRow++;
                this.CurrentPageDTRow = this.CurrentDTRow;
                //跳位
                this.CurrentPrintColumn += cell_count;
                cell_count = 1;
                this.RowLength = 0;


            }

            #endregion
        }
        #endregion


        #region 自定义打印类
        public class PrintTable
        {
            /// <summary>
            /// //表头x
            /// </summary>
            public int table_x = 0;
            /// <summary>
            /// //表头y
            /// </summary>
            public int table_y = 0;
            /// <summary>
            /// 表宽度
            /// </summary>
            public int table_width = 0;
            /// <summary>
            /// 表高度
            /// </summary>
            public int table_height = 0;
            /// <summary>
            /// 行数目
            /// </summary>
            public int row_count = 0;
            /// <summary>
            /// 列数目
            /// </summary>
            public int column_count = 0;
            /// <summary>
            /// 格宽度
            /// </summary>
            public int td_width = 0;
            /// <summary>
            /// 格高度
            /// </summary>
            public int td_height = 0;


            /// <summary>
            /// 构造函数 初始化表格式
            /// </summary>
            /// <param name="table_x">开头x</param>
            /// <param name="table_y">开头y</param>
            /// <param name="table_width">表宽width</param>
            /// <param name="table_height">表高height</param>
            public PrintTable(int table_x, int table_y, int table_width, int table_height, int row_count, int column_count)
            {
                //初始化表的整体大小
                this.table_x = table_x;
                this.table_y = table_y;
                this.table_width = table_width;
                this.table_height = table_height;

                //根据行和列的数目定义格子的大小                
                this.row_count = row_count;
                this.column_count = column_count;
                this.td_width = (int)this.table_width / this.column_count;
                this.td_height = (int)this.table_height / this.row_count;
            }

            /// <summary>
            /// 得到当前行的(x,y),(x2,y2);
            /// </summary>
            /// <param name="num">座标</param>
            /// <returns></returns>
            public _row Row(int num)
            {
                int x = this.table_x;
                int y = this.table_x + num * this.td_height + this.table_y;
                int y2 = this.table_x + num * this.td_height + this.table_y;
                int x2 = this.table_x + this.table_width;
                return new _row(x, y, x2, y2);
            }

            /// <summary>
            /// 得到当前列的(x,y),(x2,y2);
            /// </summary>
            /// <param name="num">座标</param>
            /// <returns></returns>
            public _column Column(int num)
            {
                int x = this.table_x + num * this.td_width;
                int y = this.table_x;
                int y2 = this.table_x + this.column_count * this.td_width;
                int x2 = this.table_x + num * this.td_width;
                return new _column(x, y, x2, y2);
            }

            #region 自定义结构类
            /// <summary>
            /// 得到当前格子的(x,y),(x2,y2);
            /// </summary>
            /// <param name="num">座标</param>
            /// <returns></returns>
            public _cell Cell(int x, int y)
            {
                _row row1 = Row(x);
                _column column1 = Column(y);

                return new _cell(column1.x, row1.y);
            }


            /// <summary>
            /// 行结构
            /// </summary>
            public struct _row
            {
                public int x, y, x2, y2;

                public _row(int x, int y, int x2, int y2)
                {
                    this.x = x;
                    this.y = y;
                    this.x2 = x2;
                    this.y2 = y2;
                }
            }

            /// <summary>
            /// 列结构
            /// </summary>
            public struct _column
            {
                public int x, y, x2, y2;

                public _column(int x, int y, int x2, int y2)
                {
                    this.x = x;
                    this.y = y;
                    this.x2 = x2;
                    this.y2 = y2;
                }
            }

            /// <summary>
            /// 格子结构
            /// </summary>
            public struct _cell
            {
                public int x, y;

                public _cell(int x, int y)
                {
                    this.x = x;
                    this.y = y;

                }
            }
            #endregion

        }
        #endregion
        //protected override  void m_mthGetTransDataInfoArr(out clsTransDataInfo[] p_objTansDataInfoArr)
        //{
        //    //string m_strInPatientID = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(m_trvInPatientDate.Nodes[0].Nodes.Count - m_trvInPatientDate.SelectedNode.Index - 1).m_StrEMRInPatientID;
        //    //string m_strInPatientDate = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(m_trvInPatientDate.Nodes[0].Nodes.Count - m_trvInPatientDate.SelectedNode.Index - 1).m_DtmEMRInDate.ToString("yyyy-MM-dd HH:mm:ss");
        //    m_objRecordsDomain = new clsRecordsDomain(enmRecordsType.SURGERYICUWARDSHIP);
        //    p_objTansDataInfoArr = null;
        //    if (m_objCurrentPatient == null)
        //    {
        //        return;
        //    }
        //    m_objRecordsDomain.m_lngGetTransDataInfoArr(m_objCurrentPatient.m_StrInPatientID, m_objCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"), out p_objTansDataInfoArr);

        //}

        private  void m_mthInitDataTable(DataTable p_dtbRecordTable)
        {
            try
            {
                //存放记录时间的字符串
                p_dtbRecordTable.Columns.Add("RecordDate");//0
                //存放记录类型的int值
                DataColumn dcRecordType = new DataColumn("RecordType", typeof(int));
                p_dtbRecordTable.Columns.Add(dcRecordType);//1
                //存放记录的OpenDate字符串
                p_dtbRecordTable.Columns.Add("OpenDate");  //2
                //存放记录的ModifyDate字符串
                p_dtbRecordTable.Columns.Add("ModifyDate"); //3
                DataColumn dc1 = p_dtbRecordTable.Columns.Add("RecordDateofDay");//4
                dc1.DefaultValue = "";
                DataColumn dc2 = p_dtbRecordTable.Columns.Add("RecordTime");//5
                dc2.DefaultValue = "";

                p_dtbRecordTable.Columns.Add("PBODYPART", typeof(clsDSTRichTextBoxValue));//6
                p_dtbRecordTable.Columns.Add("PCONSCIOUSNESS", typeof(clsDSTRichTextBoxValue));//7
                p_dtbRecordTable.Columns.Add("PPUPIL", typeof(clsDSTRichTextBoxValue));//8
                //p_dtbRecordTable.Columns.Add("PPUPLRIGHT",typeof(clsDSTRichTextBoxValue));//8
                p_dtbRecordTable.Columns.Add("PREFLECT", typeof(clsDSTRichTextBoxValue));//9
                //p_dtbRecordTable.Columns.Add("PREFLECTRIGHT",typeof(clsDSTRichTextBoxValue));//9
                DataColumn dc3 = p_dtbRecordTable.Columns.Add("Sign");//10
                dc3.DefaultValue = "";
                p_dtbRecordTable.Columns.Add("CTEMPERATURE", typeof(clsDSTRichTextBoxValue));//11
                p_dtbRecordTable.Columns.Add("CSMALLTEMPERATURE", typeof(clsDSTRichTextBoxValue));//12

                p_dtbRecordTable.Columns.Add("CHEARTRATE", typeof(clsDSTRichTextBoxValue));//13
                p_dtbRecordTable.Columns.Add("CHEARTRHYTHM", typeof(clsDSTRichTextBoxValue));//14
                p_dtbRecordTable.Columns.Add("CSD", typeof(clsDSTRichTextBoxValue));//15
                p_dtbRecordTable.Columns.Add("CCVP", typeof(clsDSTRichTextBoxValue));//16

                p_dtbRecordTable.Columns.Add("DPHYSIC1", typeof(clsDSTRichTextBoxValue));//17
                p_dtbRecordTable.Columns.Add("DPHYSIC2", typeof(clsDSTRichTextBoxValue));//18
                p_dtbRecordTable.Columns.Add("DPHYSIC3", typeof(clsDSTRichTextBoxValue));//19
                p_dtbRecordTable.Columns.Add("DPHYSIC4", typeof(clsDSTRichTextBoxValue));//20
                p_dtbRecordTable.Columns.Add("DPHYSIC5", typeof(clsDSTRichTextBoxValue));//21
                p_dtbRecordTable.Columns.Add("DPHYSIC6", typeof(clsDSTRichTextBoxValue));//22
                p_dtbRecordTable.Columns.Add("DPHYSIC7", typeof(clsDSTRichTextBoxValue));//23
                p_dtbRecordTable.Columns.Add("DPHYSIC8", typeof(clsDSTRichTextBoxValue));//24

                p_dtbRecordTable.Columns.Add("IBLOODPRODUCE", typeof(clsDSTRichTextBoxValue));//25
                //p_dtbRecordTable.Columns.Add("IBLOODPRODUCEADD",typeof(clsDSTRichTextBoxValue));//26
                p_dtbRecordTable.Columns.Add("IGS", typeof(clsDSTRichTextBoxValue));//27
                p_dtbRecordTable.Columns.Add("INS", typeof(clsDSTRichTextBoxValue));//28
                p_dtbRecordTable.Columns.Add("INNAME1", typeof(clsDSTRichTextBoxValue));//29
                p_dtbRecordTable.Columns.Add("INNAME2", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("INNAME3", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("INNAME4", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("INTATAL", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("OTATAL", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("OEMIEMCTION", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("OGASTRICJUICE", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("OUTNAME1", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("OUTNAME2", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("OUTNAME3", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("OUTNAME4", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("SESPECIALLYNOTE", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("BBLUSETIME", typeof(clsDSTRichTextBoxValue));//9

                p_dtbRecordTable.Columns.Add("BBLUSEMACHINETYPE", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("BBLUSEMODE", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("BVT", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("BEXPIREDMV", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("BBLUESPRESSURE", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("BBLUSENUM", typeof(clsDSTRichTextBoxValue));//9

                p_dtbRecordTable.Columns.Add("BFIO2PEEP", typeof(clsDSTRichTextBoxValue));//9
                //p_dtbRecordTable.Columns.Add("BFI02PEEPRIGHT",typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("BMAXIP", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("BBLUSESOUND", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("BPHLEGMCOLOR", typeof(clsDSTRichTextBoxValue));//9
                //p_dtbRecordTable.Columns.Add("BPHLEGMAMOUNT",typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("BSQ2", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("TCOLLECTBLOODPOINT", typeof(clsDSTRichTextBoxValue));//9

                p_dtbRecordTable.Columns.Add("TPH", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("TPCO2", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("TP02", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("THCO3", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("TTCO2", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("TBE", typeof(clsDSTRichTextBoxValue));//9

                p_dtbRecordTable.Columns.Add("TSAT", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("TO2CT", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("SCMH2O", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("SSD", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("SMEAN", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("SWEDGE", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("SCOCI", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("CreateUserID");//9

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }
        private  void m_mthGetRecord()
        {
            if (m_objCurrentPatient == null) return;
            //获取病人记录列表
            clsTransDataInfo[] objTansDataInfoArr;
            m_objRecordsDomain.m_lngGetTransDataInfoArr(m_objCurrentPatient.m_StrEMRInPatientID, m_objCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"), out objTansDataInfoArr);

            if (objTansDataInfoArr == null)
            {
                return;
            }

            //按记录时间(CreateDate)排序
            //modified by  thfzhang 2005-11-12 危重护理不需要排序
            //if (this.Name != "frmIntensiveTendMain_FC")
            //    m_mthSortTransData(ref objTansDataInfoArr);

            DataTable dtbAddBlank;
            clsDiseaseTrackAddBlankDomain objAddBlankDomain = new clsDiseaseTrackAddBlankDomain();
            objAddBlankDomain.m_lngGetBlankRecordContent(m_objCurrentPatient.m_StrInPatientID, m_objCurrentPatient.m_DtmSelectedInDate, out dtbAddBlank);

            //添加记录到的DataTable
            object[][] objDataArr;
            for (int i1 = 0; i1 < objTansDataInfoArr.Length; i1++)
            {
                if (dtbAddBlank != null && dtbAddBlank.Rows.Count > 0)
                {
                    //查找记录之前有否空行记录,有插入空行
                    foreach (DataRow drtAdd in dtbAddBlank.Rows)
                    {
                        if (objTansDataInfoArr[i1].m_objRecordContent != null)
                        {
                            if (objTansDataInfoArr[i1].m_objRecordContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss") == DateTime.Parse(drtAdd["opendate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss"))
                            {
                                object[] objBlank = new object[5];
                                objBlank[1] = 100;
                                objBlank[2] = drtAdd[2].ToString();
                                printTable.Rows.Add(objBlank);
                                for (int k3 = 0; k3 < (Int32.Parse(drtAdd[3].ToString()) - 1); k3++)
                                {
                                    printTable.Rows.Add(new object[] { });
                                }
                                break;
                            }
                        }
                    }
                }

                //objDataArr = m_objGetRecordsValueArr(objTansDataInfoArr[i1]);

                //if (objDataArr == null)
                //    continue;

                //printTable.BeginLoadData();
                //for (int j2 = 0; j2 < objDataArr.Length; j2++)
                //{
                //    printTable.LoadDataRow(objDataArr[j2], true);
                //}
                //printTable.EndLoadData();
                
            }
        }
    }
}