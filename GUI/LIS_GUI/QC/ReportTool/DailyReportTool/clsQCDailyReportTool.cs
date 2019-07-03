using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Xml;

namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// clsApplyReportPrint 的摘要说明。
    /// </summary>
    public class clsQCDailyReportTool : infPrintRecord
    {
        #region inital
        private Font m_fntTitle;
        private Font m_fntSmallBold;
        private Font m_fntSmallNotBold;
        private Font m_fntMidleBold;
        private Font m_fntMiddleNotBold;

        //边框画笔
        private Pen m_GridPen;

        float m_fltPrintWidth;      //打印的宽度
        float m_fltPrintHeight;     //打印的高度

        long m_lngTitleTop = 30;    //打印标题的高度
        long m_lngY;                //打印时的高度定位
        long m_lngVerticalLineStart; //竖线打印的起始位置
        long m_lngVerticalLineEnd;   //竖线打印的结束位置
        #endregion

        #region 打印数据
        string m_strTitle = "检验科室内质控日报告";
        string m_strWorkGroup;// = "临检室";
        string m_strDevice;// = "雅培1700A";
        string m_strItem;// = "血红蛋白";
        string m_strQCSampleLotNO;// = "T13052";
        string m_strQCSampleVendor;// = "北京中生";
        string m_strReagentLotNO;// = "200606143";
        string m_strReagentVendor;// = "雅培";

        string m_strQCStatus;// = "失控";
        string m_strBrokeRules;// = "13S";
        string m_strResson;// = "试剂";
        string m_strProcess;// = "更换试剂";

        string m_strOperator;// = "陈明";
        string m_strReportDate;// = "2006-06-20";
        #endregion

        #region 定位

        #endregion

        #region 打印报告的标题及基本信息
        private void m_mthPrintReportTop(System.Drawing.Printing.PrintPageEventArgs p_objPrintArgs)
        {
            m_lngY = m_lngTitleTop;

            SizeF sfTitle = p_objPrintArgs.Graphics.MeasureString(m_strTitle, m_fntTitle);
            float fltCurrentX = (p_objPrintArgs.PageBounds.Width - sfTitle.Width) / 2;

            p_objPrintArgs.Graphics.DrawString(m_strTitle, m_fntTitle, Brushes.Black, fltCurrentX, m_lngTitleTop);

            //沉降系数
            float fltInY = p_objPrintArgs.Graphics.MeasureString("工作室", m_fntMidleBold).Height - p_objPrintArgs.Graphics.MeasureString("工作室", m_fntSmallNotBold).Height;
            //工作室
            m_lngY = m_lngY + (long)sfTitle.Height + 10;
            fltCurrentX = m_fltPrintWidth * 0.08f;

            p_objPrintArgs.Graphics.DrawString("工作室:", m_fntMidleBold, Brushes.Black, fltCurrentX, m_lngY);

            SizeF sfWords = p_objPrintArgs.Graphics.MeasureString("工作室:", m_fntMidleBold);
            fltCurrentX += sfWords.Width;

            p_objPrintArgs.Graphics.DrawString(m_strWorkGroup, m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY + fltInY);

            //仪器
            fltCurrentX = m_fltPrintWidth * 0.4f;

            p_objPrintArgs.Graphics.DrawString("仪器:", m_fntMidleBold, Brushes.Black, fltCurrentX, m_lngY);

            sfWords = p_objPrintArgs.Graphics.MeasureString("仪器:", m_fntMidleBold);
            fltCurrentX += sfWords.Width;

            p_objPrintArgs.Graphics.DrawString(m_strDevice, m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY + fltInY);

            //项目
            fltCurrentX = m_fltPrintWidth * 0.6f;

            p_objPrintArgs.Graphics.DrawString("项目:", m_fntMidleBold, Brushes.Black, fltCurrentX, m_lngY);

            sfWords = p_objPrintArgs.Graphics.MeasureString("项目:", m_fntMidleBold);
            fltCurrentX += sfWords.Width;

            p_objPrintArgs.Graphics.DrawString(m_strItem, m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY + fltInY);

            //质控品批号及厂家
            m_lngY += (long)sfWords.Height + 10;
            fltCurrentX = m_fltPrintWidth * 0.08f;

            p_objPrintArgs.Graphics.DrawString("质控品批号及厂家:", m_fntMidleBold, Brushes.Black, fltCurrentX, m_lngY);

            sfWords = p_objPrintArgs.Graphics.MeasureString("质控品批号及厂家:", m_fntMidleBold);
            fltCurrentX += sfWords.Width;

            p_objPrintArgs.Graphics.DrawString(m_strQCSampleLotNO + "-" + m_strQCSampleVendor, m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY + fltInY);

            //试剂批号及厂家
            fltCurrentX = m_fltPrintWidth * 0.54f;

            p_objPrintArgs.Graphics.DrawString("试剂批号及厂家:", m_fntMidleBold, Brushes.Black, fltCurrentX, m_lngY);

            sfWords = p_objPrintArgs.Graphics.MeasureString("试剂批号及厂家:", m_fntMidleBold);
            fltCurrentX += sfWords.Width;

            p_objPrintArgs.Graphics.DrawString(m_strReagentLotNO + "-" + m_strReagentVendor, m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY + fltInY);

            //底端的Y坐标
            m_lngY += (long)sfWords.Height;
        }

        //画横线
        private void m_mthPrintTopLine(System.Drawing.Printing.PrintPageEventArgs p_objPrintArgs)
        {
            m_lngY += 3;
            m_lngVerticalLineStart = m_lngY;
            p_objPrintArgs.Graphics.DrawLine(m_GridPen, m_fltPrintWidth * 0.08f, m_lngY, p_objPrintArgs.PageBounds.Width * 0.96f, m_lngY);
        }
        #endregion

        #region 打印报告单正文
        public void m_mthPrintReport(System.Drawing.Printing.PrintPageEventArgs p_objPrintPageArgs)
        {
            //沉降系数
            float fltInY = p_objPrintPageArgs.Graphics.MeasureString("XXX", m_fntMidleBold).Height - p_objPrintPageArgs.Graphics.MeasureString("XXX", m_fntSmallNotBold).Height;

            float fltCurrentX = m_fltPrintWidth * 0.08f;

            //质控状态
            m_lngY += 10;
            SizeF sfWords = p_objPrintPageArgs.Graphics.MeasureString("质控状态:", m_fntMidleBold);

            p_objPrintPageArgs.Graphics.DrawString("质控状态:", m_fntMidleBold, Brushes.Black, fltCurrentX, m_lngY);
            p_objPrintPageArgs.Graphics.DrawString(m_strQCStatus, m_fntSmallNotBold, Brushes.Black, fltCurrentX + sfWords.Width, m_lngY + fltInY);

            //违背的质控规则
            m_lngY += (long)sfWords.Height + 10;
            sfWords = p_objPrintPageArgs.Graphics.MeasureString("违背的质控规则:", m_fntMidleBold);

            p_objPrintPageArgs.Graphics.DrawString("违背的质控规则:", m_fntMidleBold, Brushes.Black, fltCurrentX, m_lngY);
            p_objPrintPageArgs.Graphics.DrawString(m_strBrokeRules, m_fntSmallNotBold, Brushes.Black, fltCurrentX + sfWords.Width, m_lngY + fltInY);

            //原因
            m_lngY += (long)sfWords.Height + 10;
            sfWords = p_objPrintPageArgs.Graphics.MeasureString("原因:", m_fntMidleBold);

            p_objPrintPageArgs.Graphics.DrawString("原因:", m_fntMidleBold, Brushes.Black, fltCurrentX, m_lngY);

            m_lngY += (long)(sfWords.Height + 5);
            RectangleF rectF = new RectangleF(fltCurrentX, m_lngY, m_fltPrintWidth * 0.86f, 5 * sfWords.Height);
            p_objPrintPageArgs.Graphics.DrawString(m_strResson, m_fntSmallNotBold, Brushes.Black, rectF);

            //处理方法
            m_lngY += (long)(5 * sfWords.Height + 10);
            sfWords = p_objPrintPageArgs.Graphics.MeasureString("处理方法:", m_fntMidleBold);
            p_objPrintPageArgs.Graphics.DrawString("处理方法:", m_fntMidleBold, Brushes.Black, fltCurrentX, m_lngY);

            m_lngY += (long)(sfWords.Height + 5);
            rectF = new RectangleF(fltCurrentX, m_lngY, m_fltPrintWidth * 0.86f, 5 * sfWords.Height);
            p_objPrintPageArgs.Graphics.DrawString(m_strProcess, m_fntSmallNotBold, Brushes.Black, rectF);

            m_lngY += (long)(5 * sfWords.Height);
        }
        #endregion

        #region 打印报告单底部的线
        private void m_mthPrintBottomLine(System.Drawing.Printing.PrintPageEventArgs p_objPrintPageArgs)
        {
            m_lngY = (long)(m_fltPrintHeight -80);
            m_lngVerticalLineEnd = m_lngY;
            p_objPrintPageArgs.Graphics.DrawLine(m_GridPen, m_fltPrintWidth * 0.08f, m_lngY, p_objPrintPageArgs.PageBounds.Width * 0.96f, m_lngY);
        }
        #endregion

        #region 打印报告单底部信息
        private void m_mthPrintReportBotton(System.Drawing.Printing.PrintPageEventArgs p_objPrintPageArgs)
        {
            m_lngY += 5;
            float fltCurrentX = m_fltPrintWidth * 0.3f;

            //报告日期
            SizeF sfWords = p_objPrintPageArgs.Graphics.MeasureString("报告日期:", m_fntMidleBold);
            p_objPrintPageArgs.Graphics.DrawString("报告日期:", m_fntMidleBold, Brushes.Black, fltCurrentX, m_lngY);
            p_objPrintPageArgs.Graphics.DrawString(m_strReportDate, m_fntSmallNotBold, Brushes.Black, fltCurrentX + sfWords.Width, m_lngY);

            //报告人员
            fltCurrentX = m_fltPrintWidth * 0.6f;
            sfWords = p_objPrintPageArgs.Graphics.MeasureString("报告人员:", m_fntMidleBold);
            p_objPrintPageArgs.Graphics.DrawString("报告人员:", m_fntMidleBold, Brushes.Black, fltCurrentX, m_lngY);
            p_objPrintPageArgs.Graphics.DrawString(m_strOperator, m_fntSmallNotBold, Brushes.Black, fltCurrentX + sfWords.Width, m_lngY);
        }
        #endregion

        #region infPrintRecord 成员

        public void m_mthInitPrintContent()
        {
            // TODO:  添加 clsLisApplyReportPrint.m_mthInitPrintContent 实现
        }

        /// <summary>
        /// 初始化打印变量
        /// </summary>
        /// <param name="p_objArg"></param>
        public void m_mthInitPrintTool(object p_objArg)
        {
            m_fntTitle = new Font("SimSun", 16, FontStyle.Bold);
            m_fntSmallBold = new Font("SimSun", 9, FontStyle.Bold);
            m_fntSmallNotBold = new Font("SimSun", 9f, FontStyle.Regular);
            m_fntMidleBold = new Font("SimSun", 11f, FontStyle.Bold);
            m_fntMiddleNotBold = new Font("SimSun", 11f, FontStyle.Regular);

            m_GridPen = new Pen(Color.Black, 1);


            m_fltPrintWidth = ((PrintDocument)p_objArg).DefaultPageSettings.Bounds.Width;
            m_fltPrintHeight = ((PrintDocument)p_objArg).DefaultPageSettings.Bounds.Height;

        }

        public void m_mthDisposePrintTools(object p_objArg)
        {
            // TODO:  添加 clsLisApplyReportPrint.m_mthDisposePrintTools 实现
        }

        public void m_mthBeginPrint(object p_objPrintArg)
        {
            // TODO:  添加 clsLisApplyReportPrint.m_mthBeginPrint 实现
            m_mthInitalPrintInfo((clsLISQCDailyReportPrintVO)p_objPrintArg);
        }
        public void m_mthPrintPage(object p_objPrintArg)
        {
            m_mthPrintReportTop((PrintPageEventArgs)p_objPrintArg);
            m_mthPrintTopLine((PrintPageEventArgs)p_objPrintArg);
            m_mthPrintReport((PrintPageEventArgs)p_objPrintArg);
            m_mthPrintBottomLine((PrintPageEventArgs)p_objPrintArg);
            m_mthPrintReportBotton((PrintPageEventArgs)p_objPrintArg);
        }

        public void m_mthEndPrint(object p_objPrintArg)
        {
            // TODO:  添加 clsLisApplyReportPrint.m_mthEndPrint 实现
        }

        #endregion

        #region 初始化打印数据
        public void m_mthInitalPrintInfo(clsLISQCDailyReportPrintVO objReportVO)
        {
            if (objReportVO == null || objReportVO.objReportInfo == null || objReportVO.objBaseInfo == null)
                return;
            m_strWorkGroup = objReportVO.objBaseInfo.m_strWorkGroupName;// = "临检室";
            m_strDevice = objReportVO.objBaseInfo.m_strDeviceModel;// = "雅培1700A";
            m_strItem = objReportVO.objBaseInfo.m_strCheckItemName;// = "血红蛋白";
            m_strQCSampleLotNO = objReportVO.objBaseInfo.m_strSampleLotNo;// = "T13052";
            m_strQCSampleVendor = objReportVO.objBaseInfo.m_strSampleVendor;// = "北京中生";
            m_strReagentLotNO = objReportVO.objBaseInfo.m_strReagentBatch;// = "200606143";
            m_strReagentVendor = objReportVO.objBaseInfo.m_strReagent;// = "雅培";

            m_strQCStatus = objReportVO.objReportInfo.m_enmQCControlStatus == enmQCControlStatus.Control ? "在控" : "失控";// = "失控";
            m_strBrokeRules = objReportVO.objReportInfo.m_strUnmatchedRule;// = "13S";
            m_strResson = objReportVO.objReportInfo.m_strReason;// = "试剂";
            m_strProcess = objReportVO.objReportInfo.m_strProcess;// = "更换试剂";

            m_strOperator = objReportVO.objReportInfo.m_strReportorName;// = "陈明";
            m_strReportDate = objReportVO.objReportInfo.m_dtReport.ToString("yyyy-MM-dd");// = "2006-06-20";
        }
        #endregion
    }
}
