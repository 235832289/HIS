using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Xml;
using System.Collections.Generic;
using System.Collections;

namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// 住院检验申请列表具体实现
    /// </summary>
    public class clsBIHApplyListPrintTool : infPrintRecord
    {
        #region inital
        private Font m_fntTitle;
        private Font m_fntSmallBold;
        private Font m_fntSmallNotBold;
        private Font m_fntSmall2NotBold;
        private Font m_fntMiddleNotBold;

        //边框画笔
        private Pen m_GridPen;

        float m_fltPrintWidth;      //打印的宽度
        float m_fltPrintHeight;     //打印的高度

        long m_lngTitleTop = 20;    //打印标题的高度
        long m_lngY;                //打印时的高度定位
        long m_lngVerticalLineStart; //竖线打印的起始位置
        long m_lngVerticalLineEnd;   //竖线打印的结束位置
        #endregion

        #region 打印数据

        //string m_strOutPatientNO = "";
        //string m_strPatientInHospitalNO;// = "00000001";
        //string m_strApplicationNO;// = "00000001";
        //string m_strPatientName;// = "小李子";
        //string m_strSex;// = "男";
        //string m_strAge;// = "20";
        //string m_strSampleType;// = "血液";
        //string m_strCollector;// = "陈笑";
        //string m_strCollectDat;// = "2004-10-06";
        //string m_strApplyer;// = "王军";
        //string m_strApplyDat;// = "2004-10-06";
        //string m_strApplyDept;// = "内科";
        //string m_strBedNO;// = "12-12";
        //string m_strCheckItem;// = "血常规";
        //string m_strChargeInfo;// = "血常规 10,血型 20.5"
        //string m_strDiagnose;// = "脑梗";
        //string m_strChargeState;
        //string m_strBarCode = ""; //xing.chen add for print barcode

        string m_strTitle = "检验样本采集信息清单";
        string m_strApplyDept;// = "心内三病区";
        string m_strStatTime;//="2006-9-15 00:00－2006-9-15 23:59"
        string m_strApplTotal;//="4项";
        string m_strPrintTime;//="2006-9-15 12:00"
        private int curRow = 0;
        clsBIHLisPrintVO m_objPrint;
        List<clsDictReportPrintVO> m_objDictRptArr;

        #endregion

        #region 打印报告的标题及基本信息
        private void m_mthPrintReportTop(System.Drawing.Printing.PrintPageEventArgs p_objPrintArgs)
        {
            m_lngY = m_lngTitleTop;
            if (m_fltPrintWidth == 0)
                m_fltPrintWidth = p_objPrintArgs.PageBounds.Width * 0.8f;
            SizeF sfTitle = p_objPrintArgs.Graphics.MeasureString(m_strTitle, m_fntTitle);
            float fltCurrentX = (p_objPrintArgs.PageBounds.Width - sfTitle.Width) / 2;

            p_objPrintArgs.Graphics.DrawString(m_strTitle, m_fntTitle, Brushes.Black, fltCurrentX, m_lngTitleTop);

            //申请科室
            SizeF sfWords = p_objPrintArgs.Graphics.MeasureString("申请科室：", m_fntSmallNotBold);
            m_lngY = m_lngY + (long)sfTitle.Height + (long)sfWords.Height;
            fltCurrentX = m_fltPrintWidth * 0.08f;

            p_objPrintArgs.Graphics.DrawString("申请科室：", m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY);
            fltCurrentX += sfWords.Width;
            p_objPrintArgs.Graphics.DrawString(m_strApplyDept, m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY);

            //统计时间
            fltCurrentX += m_fltPrintWidth * 0.2f;

            p_objPrintArgs.Graphics.DrawString("统计时间：", m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY);
            fltCurrentX += sfWords.Width;
            p_objPrintArgs.Graphics.DrawString(m_strStatTime, m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY);

            //底端的Y坐标
            m_lngY += (long)sfWords.Height;
        }

        //画表头
        private void m_mthPrintTopLine(System.Drawing.Printing.PrintPageEventArgs p_objPrintArgs)
        {
            m_lngVerticalLineStart = m_lngY;
            p_objPrintArgs.Graphics.DrawLine(m_GridPen, m_fltPrintWidth * 0.08f, m_lngY, p_objPrintArgs.PageBounds.Width * 0.96f, m_lngY);

            SizeF sfWords = p_objPrintArgs.Graphics.MeasureString("床位", m_fntSmallNotBold);
            m_lngY += (long)sfWords.Height;

            float fltCurrentX = m_fltPrintWidth * 0.08f;
            sfWords = p_objPrintArgs.Graphics.MeasureString("床位", m_fntSmallNotBold);
            p_objPrintArgs.Graphics.DrawString("床位", m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY);

            fltCurrentX += 50;
            sfWords = p_objPrintArgs.Graphics.MeasureString("姓名", m_fntSmallNotBold);
            p_objPrintArgs.Graphics.DrawString("姓名", m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY);

            fltCurrentX += 80;
            sfWords = p_objPrintArgs.Graphics.MeasureString("试管条码", m_fntSmallNotBold);
            p_objPrintArgs.Graphics.DrawString("试管条码", m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY);

            fltCurrentX += 120;
            sfWords = p_objPrintArgs.Graphics.MeasureString("样本", m_fntSmallNotBold);
            p_objPrintArgs.Graphics.DrawString("样本", m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY);

            fltCurrentX += 80;
            sfWords = p_objPrintArgs.Graphics.MeasureString("检验目的", m_fntSmallNotBold);
            p_objPrintArgs.Graphics.DrawString("检验目的", m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY);

            fltCurrentX += 180;
            sfWords = p_objPrintArgs.Graphics.MeasureString("住院号", m_fntSmallNotBold);
            p_objPrintArgs.Graphics.DrawString("住院号", m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY);

            fltCurrentX += 80;
            sfWords = p_objPrintArgs.Graphics.MeasureString("采样者", m_fntSmallNotBold);
            p_objPrintArgs.Graphics.DrawString("采样者", m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY);

            fltCurrentX += 60;
            sfWords = p_objPrintArgs.Graphics.MeasureString("采样时间", m_fntSmallNotBold);
            p_objPrintArgs.Graphics.DrawString("采样时间", m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY);

            m_lngY += (long)sfWords.Height + 5;
            p_objPrintArgs.Graphics.DrawLine(m_GridPen, m_fltPrintWidth * 0.08f, m_lngY, p_objPrintArgs.PageBounds.Width * 0.96f, m_lngY);
            m_lngY += 2;
        }
        #endregion

        #region 打印报告中间内容
        private void m_mthPrintReportCenter(System.Drawing.Printing.PrintPageEventArgs p_objPrintArgs)
        {
            SizeF sfWords = p_objPrintArgs.Graphics.MeasureString("床位", m_fntSmallNotBold);
            //foreach (KeyValuePair<clsLisApplMainVO,string> dic in this.m_objPrint.dictReportPrint)
            //{
            //    clsLisApplMainVO applMain = dic.Key;
            //    string barcode=dic.Value;
            for (int i1 = curRow; i1 < m_objDictRptArr.Count; i1++, curRow++)
            {
                clsLisApplMainVO applMain = m_objDictRptArr[i1].m_objLisApplMainVO;
                string barcode = m_objDictRptArr[i1].barcode;

                m_lngY += (long)sfWords.Height;
                float fltCurrentX = m_fltPrintWidth * 0.08f;

                sfWords = p_objPrintArgs.Graphics.MeasureString("床位", m_fntSmallBold);
                p_objPrintArgs.Graphics.DrawString(applMain.m_strBedNO, m_fntSmallBold, Brushes.Black, new RectangleF(fltCurrentX, m_lngY, 50, sfWords.Height));

                fltCurrentX += 50;
                sfWords = p_objPrintArgs.Graphics.MeasureString("姓名", m_fntSmallBold);
                p_objPrintArgs.Graphics.DrawString(applMain.m_strPatient_Name, m_fntSmallBold, Brushes.Black, new RectangleF(fltCurrentX, m_lngY, 80, sfWords.Height));

                fltCurrentX += 80;
                sfWords = p_objPrintArgs.Graphics.MeasureString("试管条码", m_fntSmallBold);
                p_objPrintArgs.Graphics.DrawString(barcode, m_fntSmallBold, Brushes.Black, fltCurrentX, m_lngY);


                fltCurrentX += 120;
                sfWords = p_objPrintArgs.Graphics.MeasureString("样本", m_fntSmallNotBold);
                p_objPrintArgs.Graphics.DrawString(applMain.m_strSampleType, m_fntSmallNotBold, Brushes.Black, new RectangleF(fltCurrentX, m_lngY, 120, sfWords.Height));


                float intPosContent = fltCurrentX + 80;
                sfWords = p_objPrintArgs.Graphics.MeasureString("检验项目", m_fntSmallNotBold);

                int rowCheckContentNum = (int)Math.Ceiling((double)(applMain.m_strCheckContent.Length * 1.0 / 12 * 1.0));
                float intPos = fltCurrentX;

                fltCurrentX += 260;
                sfWords = p_objPrintArgs.Graphics.MeasureString("住院号", m_fntSmallNotBold);
                p_objPrintArgs.Graphics.DrawString(applMain.m_strPatient_inhospitalno_chr, m_fntSmallNotBold, Brushes.Black, new RectangleF(fltCurrentX, m_lngY, 80, sfWords.Height));


                string strCheckContent = string.Empty;
                for (int i = 0; i < rowCheckContentNum; i++)
                {
                    if (i != 0)
                    {
                        m_lngY += (long)sfWords.Height;
                    }

                    if (i < rowCheckContentNum - 1)
                    {
                        strCheckContent = applMain.m_strCheckContent.Substring(12 * i, 12);
                        p_objPrintArgs.Graphics.DrawString(strCheckContent, m_fntSmallNotBold, Brushes.Black, new RectangleF(intPosContent, m_lngY, 170, sfWords.Height));
                    }
                    if (i == rowCheckContentNum - 1)
                    {
                        strCheckContent = applMain.m_strCheckContent.Substring(12 * (rowCheckContentNum - 1), applMain.m_strCheckContent.Length - 12 * (rowCheckContentNum - 1));
                        p_objPrintArgs.Graphics.DrawString(strCheckContent, m_fntSmallNotBold, Brushes.Black, new RectangleF(intPosContent, m_lngY, 170, sfWords.Height));
                    }
                }
                if (m_lngY > 1062)   //行距21
                {
                    curRow++;
                    m_lngY += (long)sfWords.Height;
                    p_objPrintArgs.HasMorePages = true;
                    return;
                }
            }
            m_lngY += (long)sfWords.Height;
        }
        #endregion

        #region 打印报告单底部的线
        private void m_mthPrintBottomLine(System.Drawing.Printing.PrintPageEventArgs p_objPrintPageArgs)
        {
            m_lngY += 5;
            m_lngVerticalLineEnd = m_lngY;
            p_objPrintPageArgs.Graphics.DrawLine(m_GridPen, m_fltPrintWidth * 0.08f, m_lngY, p_objPrintPageArgs.PageBounds.Width * 0.96f, m_lngY);
        }
        #endregion

        #region 打印报告单底部信息
        private void m_mthPrintReportBotton(System.Drawing.Printing.PrintPageEventArgs p_objPrintPageArgs)
        {
            m_lngY += 5;
            float fltCurrentX = m_fltPrintWidth * 0.08f;

            //送检时间
            SizeF sfWords = p_objPrintPageArgs.Graphics.MeasureString("合计总数：", m_fntSmallNotBold);
            p_objPrintPageArgs.Graphics.DrawString("合计总数：", m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY);
            p_objPrintPageArgs.Graphics.DrawString(m_strApplTotal + " 项", m_fntSmallNotBold, Brushes.Black, fltCurrentX + sfWords.Width, m_lngY);

            //送检医生
            fltCurrentX = m_fltPrintWidth * 0.7f;
            sfWords = p_objPrintPageArgs.Graphics.MeasureString("打印时间：", m_fntSmallNotBold);
            p_objPrintPageArgs.Graphics.DrawString("打印时间：", m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY);
            p_objPrintPageArgs.Graphics.DrawString(DateTime.Now.ToString("yyyy-MM-dd HH:mm"), m_fntSmallNotBold, Brushes.Black, fltCurrentX + sfWords.Width, m_lngY);
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
            m_fntSmallBold = new Font("SimSun", 12, FontStyle.Bold);
            m_fntSmallNotBold = new Font("SimSun", 12f, FontStyle.Regular);
            m_fntSmall2NotBold = new Font("SimSun", 9f, FontStyle.Regular);
            m_fntMiddleNotBold = new Font("SimSun", 11f, FontStyle.Regular);

            m_GridPen = new Pen(Color.Black, 1);

            #region 打印设置
            try
            {
                PaperSize ps = null;
                foreach (PaperSize objPs in ((System.Drawing.Printing.PrintDocument)p_objArg).PrinterSettings.PaperSizes)
                {
                    if (objPs.PaperName == "LIS_Apply_Report")
                    {
                        ps = objPs;
                        break;
                    }
                }
                if (ps != null)
                {
                    ((System.Drawing.Printing.PrintDocument)p_objArg).DefaultPageSettings.PaperSize = ps;
                    m_fltPrintWidth = ps.Width * 0.8f;
                    m_fltPrintHeight = ps.Height;
                }
            }
            catch
            {
                MessageBox.Show("打印机故障！", "iCare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            #endregion
        }

        public void m_mthDisposePrintTools(object p_objArg)
        {
            // TODO:  添加 clsLisApplyReportPrint.m_mthDisposePrintTools 实现
        }

        public void m_mthBeginPrint(object p_objPrintArg)
        {
            // TODO:  添加 clsLisApplyReportPrint.m_mthBeginPrint 实现
            m_mthInitalPrintInfo((clsBIHLisPrintVO)p_objPrintArg);
        }

        public void m_mthPrintPage(object p_objPrintArg)
        {
            m_mthPrintReportTop((PrintPageEventArgs)p_objPrintArg);
            m_mthPrintTopLine((PrintPageEventArgs)p_objPrintArg);
            m_mthPrintReportCenter((PrintPageEventArgs)p_objPrintArg);
            m_mthPrintBottomLine((PrintPageEventArgs)p_objPrintArg);
            m_mthPrintReportBotton((PrintPageEventArgs)p_objPrintArg);
        }

        public void m_mthEndPrint(object p_objPrintArg)
        {
            // TODO:  添加 clsLisApplyReportPrint.m_mthEndPrint 实现
            this.curRow = 0;
        }

        #endregion

        #region 初始化打印数据
        public void m_mthInitalPrintInfo(clsBIHLisPrintVO objReportInfo)
        {
            if (objReportInfo == null)
                return;
            m_objPrint = objReportInfo;
            m_objDictRptArr = new List<clsDictReportPrintVO>();
            clsDictReportPrintVO m_objTemp_Vo;
            foreach (KeyValuePair<clsLisApplMainVO, string> dic in this.m_objPrint.dictReportPrint)
            {
                m_objTemp_Vo = new clsDictReportPrintVO();
                m_objTemp_Vo.m_objLisApplMainVO = dic.Key;
                m_objTemp_Vo.barcode = dic.Value;
                m_objDictRptArr.Add(m_objTemp_Vo);
            }
            m_strStatTime = objReportInfo.m_dtStart.ToString("yy-MM-dd HH") + " - " + objReportInfo.m_dtEnd.ToString("yy-MM-dd HH");
            m_strApplyDept = objReportInfo.m_strApplDept;
            m_strApplTotal = objReportInfo.dictReportPrint.Count.ToString();
        }
        #endregion

        /// <summary>
        /// 根据部门ID获取部门名称
        /// </summary>
        /// <param name="deptID">部门ID</param>
        /// <returns>部门名称</returns>
        private string GetDeptName(string deptID)
        {
            com.digitalwave.Utility.ctlDeptTextBox deptTextbox = new com.digitalwave.Utility.ctlDeptTextBox();
            deptTextbox.m_StrDeptID = deptID;
            return deptTextbox.m_StrDeptName;
        }
    }

    /// <summary>
    /// 打印表头列列样式
    /// </summary>
    public class clsPrintHeaderColumn
    {
        private string headColumnName;

        public string HeadColumnName
        {
            get { return headColumnName; }
            set { headColumnName = value; }
        }

        private double headColumnWidth;

        public double HeadColumnWidth
        {
            get { return headColumnWidth; }
            set { headColumnWidth = value; }
        }

        private bool isNewLine;

        public bool IsNewLine
        {
            get { return isNewLine; }
            set { isNewLine = value; }
        }
    }

}



