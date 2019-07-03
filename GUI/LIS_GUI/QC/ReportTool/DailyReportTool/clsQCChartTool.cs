using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using com.digitalwave.iCare.ValueObject;
using ZedGraph;


namespace com.digitalwave.iCare.gui.LIS
{
    public class clsQCChartTool : infPrintRecord
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

        string m_strTitle = "室内质控记录";
        ZedGraph.ZedGraphControl m_zedGraph;
        /// <summary>
        /// 预设浓度
        /// </summary>
        clsLisQCConcentrationVO m_objQCCon;
        /// <summary>
        /// 实测浓度
        /// </summary>
        clsLisQCConcentrationVO m_objQCConReal;
        /// <summary>
        /// 质控样本结果
        /// </summary>
        List<clsLisQCDataVO> m_lstQCDatas;
        /// <summary>
        /// 质控报告列表
        /// </summary>
        List<clsLisQCReportVO> m_lstQCReports;
        /// <summary>
        /// 开始时间
        /// </summary>
        DateTime m_dtStartDate;
        /// <summary>
        /// 结束时间
        /// </summary>
        DateTime m_dtEndDate;

        string m_strWorkGroup;
        string m_strDevice;
        string m_strItem;
        /// <summary>
        /// 质控品批号
        /// </summary>
        string m_strQCSampleLotNO;
        /// <summary>
        /// 质控品厂家
        /// </summary>
        string m_strQCSampleVendor;
        /// <summary>
        /// 试剂批号
        /// </summary>
        string m_strReagentLotNO;
        /// <summary>
        /// 试剂厂家
        /// </summary>
        string m_strReagentVendor;
        /// <summary>
        /// 质控状态
        /// </summary>
        string m_strQCStatus;
        /// <summary>
        /// 违背的质控规则
        /// </summary>
        string m_strBrokeRules;
        ///// <summary>
        ///// 失控原因
        ///// </summary>
        //string m_strResson;
        ///// <summary>
        ///// 处理方法
        ///// </summary>
        //string m_strProcess;
        /// <summary>
        /// 报告人员
        /// </summary>
        string m_strOperator;
        /// <summary>
        /// 报告日期
        /// </summary>
        string m_strReportDate;
        #endregion

        #region 定位

        #endregion

        #region 打印报告的标题及基本信息
        private void m_mthPrintChartTop(System.Drawing.Printing.PrintPageEventArgs p_objPrintArgs)
        {
            m_lngY = m_lngTitleTop;

            m_strTitle = GlobalParm.HospitalName + "室内质控记录";  // com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalName + m_strTitle;
            SizeF sfTitle = p_objPrintArgs.Graphics.MeasureString(m_strTitle, m_fntTitle);
            float fltCurrentX = (p_objPrintArgs.PageBounds.Width - sfTitle.Width) / 2;

            p_objPrintArgs.Graphics.DrawString(m_strTitle, m_fntTitle, Brushes.Black, fltCurrentX, m_lngTitleTop);

            //沉降系数
            float fltInY = p_objPrintArgs.Graphics.MeasureString("控制日期", m_fntMidleBold).Height - p_objPrintArgs.Graphics.MeasureString("控制日期", m_fntSmallNotBold).Height;
            //工作室
            m_lngY = m_lngY + (long)sfTitle.Height + 10;
            fltCurrentX = m_fltPrintWidth * 0.08f;

            p_objPrintArgs.Graphics.DrawString("控制日期:", m_fntMidleBold, Brushes.Black, fltCurrentX, m_lngY);

            SizeF sfWords = p_objPrintArgs.Graphics.MeasureString("控制日期:", m_fntMidleBold);
            fltCurrentX += sfWords.Width;

            p_objPrintArgs.Graphics.DrawString(m_dtStartDate.ToString("yyyy-MM-dd") + " -- " + m_dtEndDate.ToString("yyyy-MM-dd"), m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY + fltInY);

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

            //预设浓度
            m_lngY += (long)sfWords.Height + 10;
            fltCurrentX = m_fltPrintWidth * 0.08f;
            p_objPrintArgs.Graphics.DrawString("均值: ", m_fntMidleBold, Brushes.Black, fltCurrentX, m_lngY);

            // SD
            fltCurrentX = m_fltPrintWidth * 0.4f;
            p_objPrintArgs.Graphics.DrawString("SD: ", m_fntMidleBold, Brushes.Black, fltCurrentX, m_lngY);

            // CV
            fltCurrentX = m_fltPrintWidth * 0.6f;
            p_objPrintArgs.Graphics.DrawString("CV: ", m_fntMidleBold, Brushes.Black, fltCurrentX, m_lngY);

            if (m_objQCCon != null)
            {
                fltCurrentX = m_fltPrintWidth * 0.08f;
                sfWords = p_objPrintArgs.Graphics.MeasureString("均值: ", m_fntMidleBold);
                fltCurrentX += sfWords.Width;
                p_objPrintArgs.Graphics.DrawString(m_objQCCon.m_dblAVG.ToString(), m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY + fltInY);

                // SD
                fltCurrentX = m_fltPrintWidth * 0.4f;
                sfWords = p_objPrintArgs.Graphics.MeasureString("SD: ", m_fntMidleBold);
                fltCurrentX += sfWords.Width;
                p_objPrintArgs.Graphics.DrawString(m_objQCCon.m_dblSD.ToString(), m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY + fltInY);

                // CV
                fltCurrentX = m_fltPrintWidth * 0.6f;
                sfWords = p_objPrintArgs.Graphics.MeasureString("CV: ", m_fntMidleBold);
                fltCurrentX += sfWords.Width;
                p_objPrintArgs.Graphics.DrawString(m_objQCCon.m_dblCV.ToString(), m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY + fltInY);
            }

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
            m_lngY += 30;
            SizeF sfWords = p_objPrintPageArgs.Graphics.MeasureString("质控状态:", m_fntMidleBold);

            p_objPrintPageArgs.Graphics.DrawString("质控状态:", m_fntMidleBold, Brushes.Black, fltCurrentX, m_lngY);
            //m_lngY += (long)(sfWords.Height+5);
            RectangleF rectF = new RectangleF(fltCurrentX + sfWords.Width + 10, m_lngY, m_fltPrintWidth * 0.7f, sfWords.Height);

            p_objPrintPageArgs.Graphics.DrawString("  " + m_strQCStatus, m_fntMidleBold, Brushes.Red, rectF);

            //违背的质控规则
            m_lngY += (long)sfWords.Height + 5;
            sfWords = p_objPrintPageArgs.Graphics.MeasureString("违背的质控规则:", m_fntMidleBold);

            p_objPrintPageArgs.Graphics.DrawString("违背的质控规则:", m_fntMidleBold, Brushes.Black, fltCurrentX, m_lngY);
            m_lngY += (long)(sfWords.Height + 5);
            rectF = new RectangleF(fltCurrentX + 40, m_lngY, m_fltPrintWidth * 0.86f, 2 * sfWords.Height);
            p_objPrintPageArgs.Graphics.DrawString(m_strBrokeRules, m_fntSmallNotBold, Brushes.Black, rectF);


            ////原因
            //m_lngY += (long)(2*sfWords.Height + 5);
            //sfWords = p_objPrintPageArgs.Graphics.MeasureString("原因:", m_fntMidleBold);

            //p_objPrintPageArgs.Graphics.DrawString("原因:", m_fntMidleBold, Brushes.Black, fltCurrentX, m_lngY);

            //m_lngY += (long)(sfWords.Height + 5);
            //rectF = new RectangleF(fltCurrentX, m_lngY, m_fltPrintWidth * 0.86f, 2*sfWords.Height);
            //p_objPrintPageArgs.Graphics.DrawString(m_strResson, m_fntSmallNotBold, Brushes.Black, rectF);

            ////处理方法
            //m_lngY += (long)(2*sfWords.Height + 5);
            //sfWords = p_objPrintPageArgs.Graphics.MeasureString("处理方法:", m_fntMidleBold);
            //p_objPrintPageArgs.Graphics.DrawString("处理方法:", m_fntMidleBold, Brushes.Black, fltCurrentX, m_lngY);

            //m_lngY += (long)(sfWords.Height + 5);
            //rectF = new RectangleF(fltCurrentX, m_lngY, m_fltPrintWidth * 0.86f,3*sfWords.Height);
            //p_objPrintPageArgs.Graphics.DrawString(m_strProcess, m_fntSmallNotBold, Brushes.Black, rectF);


            m_lngY += (long)(3 * sfWords.Height);
        }
        #endregion

        #region 打印报告单底部的线

        private void m_mthPrintBottomLine(System.Drawing.Printing.PrintPageEventArgs p_objPrintPageArgs)
        {
            m_lngY = (long)(m_fltPrintHeight - 80);
            m_lngVerticalLineEnd = m_lngY;
            p_objPrintPageArgs.Graphics.DrawLine(m_GridPen, m_fltPrintWidth * 0.08f, m_lngY, p_objPrintPageArgs.PageBounds.Width * 0.96f, m_lngY);
        }
        #endregion

        #region 打印报告单底部信息

        private void m_mthPrintChartBotton(System.Drawing.Printing.PrintPageEventArgs p_objPrintPageArgs)
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

        #region 打印图片和数据
        /// <summary>
        /// 打印图片和数据
        /// </summary>
        /// <param name="p_objPrintPageArgs"></param>
        private void m_mthPrintChart(System.Drawing.Printing.PrintPageEventArgs p_objPrintPageArgs)
        {
            Graphics g = p_objPrintPageArgs.Graphics;
            int chartHeight = 300;
            Rectangle rect = new Rectangle((int)(m_fltPrintWidth * 0.10f), (int)m_lngY + 10, (int)(m_fltPrintWidth * 0.8), chartHeight);
            m_zedGraph.DrawNoFontChart(g, rect);
            m_lngY += (long)chartHeight + 8;

            #region 本室浓度
            //本室浓度
            float fltStartX = m_fltPrintWidth * 0.125f;
            float fltCurrentX = fltStartX;
            SizeF sfWords = g.MeasureString("本室均值: ", m_fntMidleBold);
            g.DrawString("本室均值: ", m_fntMidleBold, Brushes.Black, fltCurrentX, m_lngY);

            // SD
            fltCurrentX = m_fltPrintWidth * 0.4f;
            g.DrawString("SD: ", m_fntMidleBold, Brushes.Black, fltCurrentX, m_lngY);

            // CV
            fltCurrentX = m_fltPrintWidth * 0.6f;
            g.DrawString("CV: ", m_fntMidleBold, Brushes.Black, fltCurrentX, m_lngY);
            if (m_lstQCDatas != null && m_lstQCDatas.Count > 0)
            {
                double[] dblDataArr = new double[m_lstQCDatas.Count];
                for (int index = 0; index < m_lstQCDatas.Count; index++)
                {
                    dblDataArr[index] = m_lstQCDatas[index].m_dlbResult;
                }

                double dblX = 0;
                double dblSD = 0;
                double dblCV = 0;
                long lngRes = clsLISPublic.m_lngCalculateSDXCV(dblDataArr, out dblX, out dblSD, out dblCV);

                if (lngRes > 0)
                {
                    float fltInY = g.MeasureString("本室均值", m_fntMidleBold).Height - g.MeasureString("本室均值", m_fntSmallNotBold).Height;

                    fltCurrentX = fltStartX;
                    sfWords = g.MeasureString("本室均值: ", m_fntMidleBold);
                    fltCurrentX += sfWords.Width;
                    g.DrawString(dblX.ToString("0.00"), m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY + fltInY);

                    // SD
                    fltCurrentX = m_fltPrintWidth * 0.4f;
                    sfWords = g.MeasureString("SD: ", m_fntMidleBold);
                    fltCurrentX += sfWords.Width;
                    g.DrawString(dblSD.ToString("0.00"), m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY + fltInY);

                    // CV
                    fltCurrentX = m_fltPrintWidth * 0.6f;
                    sfWords = g.MeasureString("CV: ", m_fntMidleBold);
                    fltCurrentX += sfWords.Width;
                    g.DrawString(dblCV.ToString("0.0"), m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY + fltInY);

                }
            }

            m_lngY += Convert.ToInt64(sfWords.Height) + 3;
            #endregion

            #region 本室浓度数据

            fltCurrentX = fltStartX;
            SizeF sizef = g.MeasureString("12.50", m_fntSmallNotBold);
            float width = sizef.Width;
            float height = sizef.Height + 2;
            int widSpace = 2;
            int heiSpace = 2;

            float xStep = width + widSpace;
            float yStep = height + heiSpace;
            float fltCurrentY = m_lngY;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            clsLisQCDataVO objTemp = null;
            int iOneRowCount = 16;
            int iRowCount = m_lstQCDatas.Count / iOneRowCount;
            if (m_lstQCDatas.Count % iOneRowCount > 0)
            {
                iRowCount += 1;
            }
            int idxResult = 0;
            int fltCurPrintWidth = Convert.ToInt32(fltCurrentX + xStep * iOneRowCount);
            RectangleF recgF = new RectangleF(fltCurrentX, fltCurrentY, xStep, yStep);
            // 每行打印16个数据
            if (iRowCount > 0)
            {
                g.DrawLine(m_GridPen, fltCurrentX, fltCurrentY, fltCurPrintWidth, fltCurrentY);

                for (int iRow = 0; iRow < iRowCount; iRow++)
                {
                    fltCurrentX = fltStartX;
                    g.DrawLine(m_GridPen, fltCurrentX, fltCurrentY + yStep, fltCurPrintWidth, fltCurrentY + yStep);
                    g.DrawLine(m_GridPen, fltCurrentX, fltCurrentY + 2 * yStep, fltCurPrintWidth, fltCurrentY + 2 * yStep);

                    g.DrawLine(m_GridPen, fltCurrentX, fltCurrentY, fltCurrentX, fltCurrentY + 2 * yStep);
                    for (int index = 0; index < iOneRowCount; index++)
                    {
                        g.DrawLine(m_GridPen, fltCurrentX + xStep, fltCurrentY, fltCurrentX + xStep, fltCurrentY + 2 * yStep);

                        if (idxResult < m_lstQCDatas.Count)
                        {
                            objTemp = m_lstQCDatas[idxResult];
                            recgF = new RectangleF(fltCurrentX, fltCurrentY, xStep, yStep);
                            g.DrawString(objTemp.m_datQCDate.ToString("M.d"), m_fntSmallNotBold, Brushes.Black, recgF, sf);
                            recgF.Y = fltCurrentY + yStep;
                            g.DrawString(objTemp.m_dlbResult.ToString(), m_fntSmallNotBold, Brushes.Black, recgF, sf);

                            idxResult += 1;
                        }

                        fltCurrentX += xStep;
                    }

                    fltCurrentY += 2 * yStep;
                }
            }
            #endregion
            m_lngY += Convert.ToInt64(yStep * 2 * iRowCount) + 10;
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
            m_mthInitalPrintInfo((clsLISQCChartPrintVO)p_objPrintArg);
        }
        public void m_mthPrintPage(object p_objPrintArg)
        {
            m_mthPrintChartTop((PrintPageEventArgs)p_objPrintArg);
            m_mthPrintTopLine((PrintPageEventArgs)p_objPrintArg);
            //chart
            m_mthPrintChart((PrintPageEventArgs)p_objPrintArg);
            m_mthPrintReport((PrintPageEventArgs)p_objPrintArg);
            m_mthPrintBottomLine((PrintPageEventArgs)p_objPrintArg);
            m_mthPrintChartBotton((PrintPageEventArgs)p_objPrintArg);
        }

        public void m_mthEndPrint(object p_objPrintArg)
        {
            // TODO:  添加 clsLisApplyReportPrint.m_mthEndPrint 实现
        }

        public SizeF m_SFGetPrintSize(int p_intPrintWidth, DataTable p_dtSample, DataTable p_dtResult)
        {
            return new SizeF(0f, 0f);
        }

        #endregion

        #region 初始化打印数据

        public void m_mthInitalPrintInfo(clsLISQCChartPrintVO objChartVO)
        {
            if (objChartVO == null || objChartVO.objBatch == null || objChartVO.zedChart == null)
                return;

            m_zedGraph = objChartVO.zedChart;
            m_objQCCon = objChartVO.objSelectQCCon;
            m_lstQCDatas = objChartVO.objBatch.GetDatas();
            if (m_lstQCDatas != null && m_lstQCDatas.Count > 0)
            {
                m_lstQCDatas.Sort(clsLisQCDataVO.CompareVO);
            }

            m_lstQCReports = objChartVO.objBatch.GetReports();

            m_strBrokeRules = objChartVO.objBatch.BrokenRules;
            m_strQCStatus = "在控";
            if (string.IsNullOrEmpty(m_strBrokeRules))
            {
                if (m_lstQCReports != null || m_lstQCReports.Count > 0)
                {
                    foreach (clsLisQCReportVO objQCReport in m_lstQCReports)
                    {
                        if (objQCReport.m_enmQCControlStatus == enmQCControlStatus.UnControl)
                        {
                            m_strQCStatus = "失控";
                            m_strBrokeRules = objQCReport.m_strUnmatchedRule;
                            break;
                        }
                    }
                }
            }
            else
            {
                m_strQCStatus = "失控";
            }

            m_dtStartDate = objChartVO.objBatch.DateBegin;
            m_dtEndDate = objChartVO.objBatch.DateEnd;

            clsLisQCBatchVO objTemp = objChartVO.objBatch[0];

            m_strWorkGroup = objTemp.m_strWorkGroupName;
            m_strDevice = objTemp.m_strDeviceModel;
            m_strItem = objTemp.m_strCheckItemName;
            m_strQCSampleLotNO = objTemp.m_strSampleLotNo;
            m_strQCSampleVendor = objTemp.m_strSampleVendor;
            m_strReagentLotNO = objTemp.m_strReagentBatch;
            m_strReagentVendor = objTemp.m_strReagent;
        }
        #endregion
    }
}
