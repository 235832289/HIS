using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Xml;
using System.IO;

namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// clsApplyReportPrint 的摘要说明。
    /// </summary>
    public class clsBIHApplySinglePrintTool : com.digitalwave.GUI_Base.clsController_Base, infPrintRecord
    {
        public clsBIHApplySinglePrintTool()
        {
            m_strTitle = this.m_objComInfo.m_strGetHospitalTitle();
        }
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
        string m_strTitle = ""; //"佛山市第二人民医院检验申请单";
        string m_strOutPatientNO = "";
        string m_strPatientInHospitalNO;// = "00000001";
        string m_strApplicationNO;// = "00000001";
        string m_strPatientName;// = "小李子";
        string m_strSex;// = "男";
        string m_strAge;// = "20";
        string m_strSampleType;// = "血液";
        string m_strCollector;// = "陈笑";
        string m_strCollectDat;// = "2004-10-06";
        string m_strApplyer;// = "王军";
        string m_strApplyDat;// = "2004-10-06";
        string m_strApplyDept;// = "内科";
        string m_strBedNO;// = "12-12";
        string m_strCheckItem;// = "血常规";
        string m_strChargeInfo;// = "血常规 10,血型 20.5"
        string m_strDiagnose;// = "脑梗";
        string m_strChargeState;
        string m_strBarCode = ""; //xing.chen add for print barcode
        //add by wjqin(07-3-29)
        /// <summary>
        /// 是否已打印(0:未打印,1:已打印)
        /// </summary>
        string m_strPRINTED_NUM = "0";
        /// <summary>
        /// 首次打印时间
        /// </summary>
        string m_strPRINTED_DATE = "";
        /*<===================================*/
        #endregion

        #region 打印报告的标题及基本信息
        private void m_mthPrintReportTop(System.Drawing.Printing.PrintPageEventArgs p_objPrintArgs)
        {
            m_lngY = m_lngTitleTop;
            m_fltPrintWidth = 452;
            m_fltPrintHeight = 320;
            if (m_fltPrintWidth == 0)
                m_fltPrintWidth = p_objPrintArgs.PageBounds.Width * 0.8f;
            if (m_fltPrintHeight == 0)
            {
                m_fltPrintHeight = p_objPrintArgs.PageBounds.Height;
            }

            #region 打印条型码
            float X = m_fltPrintWidth * 0.08f;
            float Y = m_fltPrintHeight * 0.02f + 45;
            string png = @"C:\IcarePNG\" + m_strBarCode + ".Png";

            SizeF sfBarCode = new SizeF(0, 0);
            if (m_strBarCode != null && m_strBarCode.Trim() != "")
            {
                System.Configuration.ConfigXmlDocument xmlConfig = new System.Configuration.ConfigXmlDocument();
                string strPath = System.AppDomain.CurrentDomain.BaseDirectory;
                strPath += "LoginFile.xml";
                xmlConfig.Load(strPath);
                string strBarCodeFont = xmlConfig["Main"]["lisBarCodeName"].Value;
                sfBarCode = p_objPrintArgs.Graphics.MeasureString(m_strBarCode, new Font(strBarCodeFont, 15.00f));
                p_objPrintArgs.Graphics.DrawString(m_strBarCode, new Font(strBarCodeFont, 15.00f), Brushes.Black, X, Y + 15);
            }

            if (File.Exists(png))
            {
                Image img = Image.FromFile(png);
                p_objPrintArgs.Graphics.DrawImage(img, X + sfBarCode.Width + 5, Y, 208, 40);
                img.Dispose();
            }

            #endregion

            SizeF sfTitle = p_objPrintArgs.Graphics.MeasureString(m_strTitle, m_fntTitle);
            float fltCurrentX = (m_fltPrintWidth - sfTitle.Width) / 2 - 150;

            p_objPrintArgs.Graphics.DrawString(m_strTitle, m_fntTitle, Brushes.Black, m_fltPrintWidth * 0.08f, m_lngTitleTop);

            //add by wjqin(07-3-29)
            //本次打印时间
            m_lngY += (long)sfTitle.Height + 5;
            string m_strPrintDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            //if (m_strPRINTED_NUM.Equals("1"))
            //{
            //    m_strPrintDate += " 重打";
            //}
            //else
            //{
            //}
            SizeF sfWords = p_objPrintArgs.Graphics.MeasureString(m_strPrintDate, m_fntSmallNotBold);
            //p_objPrintArgs.Graphics.DrawString(m_strTitle, m_fntTitle, Brushes.Black, m_fltPrintWidth * 0.08f, m_lngTitleTop);
            p_objPrintArgs.Graphics.DrawString(m_strPrintDate, m_fntSmallNotBold, Brushes.Black, m_fltPrintWidth * 0.96f - sfWords.Width, m_lngY);
            /*<=================================*/
            //change by wjqin(07-3-29)
            //if (m_strBarCode != null && m_strBarCode.Trim() != "")
            //{
            //    m_lngY += 70;
            //}
            //else
            //    m_lngY += 30;
            if (m_strBarCode != null && m_strBarCode.Trim() != "")
            {
                m_lngY += 60;
            }
            else
                m_lngY += 20;
            /*<====================================*/
        }

        //画横线
        private void m_mthPrintTopLine(System.Drawing.Printing.PrintPageEventArgs p_objPrintArgs)
        {
            m_lngY += 3;
            m_lngVerticalLineStart = m_lngY;
            p_objPrintArgs.Graphics.DrawLine(m_GridPen, m_fltPrintWidth * 0.02f, m_lngY, m_fltPrintWidth * 0.96f, m_lngY);
        }
        #endregion

        #region 打印报告单的左边信息
        public void m_mthPrintReportLeft(System.Drawing.Printing.PrintPageEventArgs p_objPrintPageArgs)
        {
            float fltCurrentX = m_fltPrintWidth * 0.02f;
            m_lngY += 5;
            SizeF sfWords = p_objPrintPageArgs.Graphics.MeasureString("姓名:", m_fntSmallNotBold);

            //姓名
            p_objPrintPageArgs.Graphics.DrawString("姓名:", m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY);
            p_objPrintPageArgs.Graphics.DrawString(m_strPatientName, m_fntSmallNotBold, Brushes.Black, fltCurrentX + sfWords.Width, m_lngY);

            //性别
            m_lngY += (long)sfWords.Height + 5;
            p_objPrintPageArgs.Graphics.DrawString("性别:", m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY);
            p_objPrintPageArgs.Graphics.DrawString(m_strSex, m_fntSmallNotBold, Brushes.Black, fltCurrentX + sfWords.Width, m_lngY);

            //年龄
            m_lngY += (long)sfWords.Height + 5;
            p_objPrintPageArgs.Graphics.DrawString("年龄:", m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY);
            p_objPrintPageArgs.Graphics.DrawString(m_strAge, m_fntSmallNotBold, Brushes.Black, fltCurrentX + sfWords.Width, m_lngY);

            //检验标本
            m_lngY += (long)sfWords.Height + 5;
            sfWords = p_objPrintPageArgs.Graphics.MeasureString("检验标本:", m_fntSmallNotBold);
            p_objPrintPageArgs.Graphics.DrawString("检验标本:", m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY);
            p_objPrintPageArgs.Graphics.DrawString(m_strSampleType, m_fntSmallNotBold, Brushes.Black, fltCurrentX + sfWords.Width, m_lngY);

            //临床诊断
            m_lngY += (long)sfWords.Height + 5;
            sfWords = p_objPrintPageArgs.Graphics.MeasureString("临床诊断:", m_fntSmallNotBold);
            p_objPrintPageArgs.Graphics.DrawString("临床诊断:", m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY);
            p_objPrintPageArgs.Graphics.DrawString(m_strDiagnose, m_fntSmallNotBold, Brushes.Black, fltCurrentX + sfWords.Width, m_lngY);

            //m_lngY += (long)sfWords.Height+5;
            //RectangleF rectF = new RectangleF(fltCurrentX,m_lngY,m_fltPrintWidth*0.12f,9*sfWords.Height);
            //p_objPrintPageArgs.Graphics.DrawString(m_strDiagnose,m_fntSmallNotBold,Brushes.Black,rectF);

            //采样人员
            m_lngY += (long)sfWords.Height + 5;
            sfWords = p_objPrintPageArgs.Graphics.MeasureString("采样人员:", m_fntSmallNotBold);
            p_objPrintPageArgs.Graphics.DrawString("采样人员:", m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY);
            //p_objPrintPageArgs.Graphics.DrawString(m_strCollector,m_fntSmallNotBold,Brushes.Black,fltCurrentX+sfWords.Width,m_lngY);

            //采样时间
            m_lngY += (long)sfWords.Height + 5;
            sfWords = p_objPrintPageArgs.Graphics.MeasureString("采样时间:", m_fntSmallNotBold);
            p_objPrintPageArgs.Graphics.DrawString("采样时间:", m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY);
            p_objPrintPageArgs.Graphics.DrawString(m_strCollectDat, m_fntSmallNotBold, Brushes.Black, fltCurrentX + sfWords.Width, m_lngY);

            //add by wjqin(07-3-29)
            //打印护士签名:
            m_lngY += (long)sfWords.Height + 5;
            sfWords = p_objPrintPageArgs.Graphics.MeasureString("打印护士签名:", m_fntSmallNotBold);
            p_objPrintPageArgs.Graphics.DrawString("打印护士签名:", m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY);


            /*<===============================*/

            m_lngY += (long)sfWords.Height;
        }
        #endregion

        #region 打印报告单底部的线
        private void m_mthPrintBottomLine(System.Drawing.Printing.PrintPageEventArgs p_objPrintPageArgs)
        {
            m_lngY += 5;
            m_lngVerticalLineEnd = m_lngY;
            p_objPrintPageArgs.Graphics.DrawLine(m_GridPen, m_fltPrintWidth * 0.02f, m_lngY, m_fltPrintWidth * 0.96f, m_lngY);
        }
        #endregion

        #region 打印报告单底部信息
        private void m_mthPrintReportBotton(System.Drawing.Printing.PrintPageEventArgs p_objPrintPageArgs)
        {
            m_lngY += 5;
            float fltCurrentX = m_fltPrintWidth * 0.02f;

            //送检时间
            SizeF sfWords = p_objPrintPageArgs.Graphics.MeasureString("送检时间:", m_fntSmallNotBold);
            p_objPrintPageArgs.Graphics.DrawString("送检时间:", m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY);
            p_objPrintPageArgs.Graphics.DrawString(m_strApplyDat, m_fntSmallNotBold, Brushes.Black, fltCurrentX + sfWords.Width, m_lngY);

            //送检医生
            fltCurrentX = m_fltPrintWidth * 0.60f;
            sfWords = p_objPrintPageArgs.Graphics.MeasureString("送检医生:", m_fntSmallNotBold);
            p_objPrintPageArgs.Graphics.DrawString("送检医生:", m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY);
            p_objPrintPageArgs.Graphics.DrawString(m_strApplyer, m_fntSmallNotBold, Brushes.Black, fltCurrentX + sfWords.Width, m_lngY);
        }
        #endregion

        #region 打印报告单的分割线
        private void m_mthPrintReportVerticalLine(System.Drawing.Printing.PrintPageEventArgs p_objPrintPageArgs)
        {
            //p_objPrintPageArgs.Graphics.DrawLine(m_GridPen,m_fltPrintWidth*0.38f,m_lngVerticalLineStart,m_fltPrintWidth*0.38f,m_lngVerticalLineEnd);
        }
        #endregion

        #region 打印报告单右边信息
        private void m_mthPrintReportRight(System.Drawing.Printing.PrintPageEventArgs p_objPrintPageArgs)
        {
            float fltCurrentX = m_fltPrintWidth * 0.46f;
            m_lngY = m_lngVerticalLineStart;
            m_lngY += 3;
            SizeF sfWords = p_objPrintPageArgs.Graphics.MeasureString("门诊住院号:", m_fntSmallNotBold);

            //门诊号
            p_objPrintPageArgs.Graphics.DrawString("门诊住院号:", m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY);
            p_objPrintPageArgs.Graphics.DrawString(m_strPatientInHospitalNO, m_fntSmallNotBold, Brushes.Black, fltCurrentX + sfWords.Width, m_lngY);

            //科室
            m_lngY += (long)sfWords.Height + 5;
            p_objPrintPageArgs.Graphics.DrawString("科室:", m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY);
            p_objPrintPageArgs.Graphics.DrawString(this.m_strApplyDept, m_fntSmallNotBold, Brushes.Black, fltCurrentX + sfWords.Width, m_lngY);

            //床号
            m_lngY += (long)sfWords.Height + 5;
            p_objPrintPageArgs.Graphics.DrawString("床号:", m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY);
            p_objPrintPageArgs.Graphics.DrawString(this.m_strBedNO, m_fntSmallNotBold, Brushes.Black, fltCurrentX + sfWords.Width, m_lngY);

            //申请单号
            m_lngY += (long)sfWords.Height + 5;
            sfWords = p_objPrintPageArgs.Graphics.MeasureString("申请单号:", m_fntSmallNotBold);
            p_objPrintPageArgs.Graphics.DrawString("申请单号:", m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY);
            p_objPrintPageArgs.Graphics.DrawString(m_strApplicationNO, m_fntSmallNotBold, Brushes.Black, fltCurrentX + sfWords.Width, m_lngY);

            //检验目的
            m_lngY += (long)sfWords.Height + 5;
            sfWords = p_objPrintPageArgs.Graphics.MeasureString("检验目的:", m_fntSmallNotBold);
            p_objPrintPageArgs.Graphics.DrawString("检验目的:", m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY);
            p_objPrintPageArgs.Graphics.DrawString(m_strCheckItem, m_fntSmallNotBold, Brushes.Black, fltCurrentX + sfWords.Width, m_lngY);

            //收费信息
            m_lngY += (long)sfWords.Height + 5;
            sfWords = p_objPrintPageArgs.Graphics.MeasureString("收费信息:", m_fntSmallNotBold);
            p_objPrintPageArgs.Graphics.DrawString("收费信息:", m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY);
            RectangleF Rect = new RectangleF(fltCurrentX + sfWords.Width, m_lngY, 2.5f * sfWords.Width, 2.0f * sfWords.Height * 2);
            p_objPrintPageArgs.Graphics.DrawString(m_strChargeInfo, m_fntSmallNotBold, Brushes.Black, Rect);
            //add by wjqin(07-3-29)
            //首次打印时间
            m_lngY += 2 * ((long)sfWords.Height + 5);
            m_strPRINTED_DATE = "首次打印时间:" + m_strPRINTED_DATE;
            sfWords = p_objPrintPageArgs.Graphics.MeasureString(m_strPRINTED_DATE, m_fntSmallNotBold);
            p_objPrintPageArgs.Graphics.DrawString(m_strPRINTED_DATE, m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY);


            /*<===============================*/


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
            m_fntSmallBold = new Font("SimSun", 11, FontStyle.Bold);
            m_fntSmallNotBold = new Font("SimSun", 10f, FontStyle.Regular);
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
            m_mthInitalPrintInfo((clsLisApplyReportInfo_VO)p_objPrintArg);
        }
        //xing.chen add for print barcode
        public void m_mthBeginPrint(object p_objPrintArg, string p_strBarCode)
        {
            // TODO:  添加 clsLisApplyReportPrint.m_mthBeginPrint 实现
            m_mthInitalPrintInfo((clsLisApplyReportInfo_VO)p_objPrintArg, p_strBarCode);
        }

        public void m_mthPrintPage(object p_objPrintArg)
        {
            m_mthPrintReportTop((PrintPageEventArgs)p_objPrintArg);
            m_mthPrintTopLine((PrintPageEventArgs)p_objPrintArg);
            m_mthPrintReportLeft((PrintPageEventArgs)p_objPrintArg);
            m_mthPrintBottomLine((PrintPageEventArgs)p_objPrintArg);
            m_mthPrintReportBotton((PrintPageEventArgs)p_objPrintArg);
            m_mthPrintReportVerticalLine((PrintPageEventArgs)p_objPrintArg);
            m_mthPrintReportRight((PrintPageEventArgs)p_objPrintArg);
        }

        public void m_mthEndPrint(object p_objPrintArg)
        {
            // TODO:  添加 clsLisApplyReportPrint.m_mthEndPrint 实现
        }

        #endregion

        #region 初始化打印数据
        public void m_mthInitalPrintInfo(clsLisApplyReportInfo_VO objReportInfo)
        {
            if (objReportInfo == null)
                return;
            m_strPatientInHospitalNO = objReportInfo.m_strPatientInHospitalNO;
            if (objReportInfo.m_strApplicationNO.Length > 8)
            {
                //取后面8位                
                m_strApplicationNO = objReportInfo.m_strApplicationNO.Substring(objReportInfo.m_strApplicationNO.Length - 8, 8);
            }
            else
            {
                m_strApplicationNO = objReportInfo.m_strApplicationNO;
            }
            m_strPatientName = objReportInfo.m_strPatientName;
            m_strSex = objReportInfo.m_strSex;
            m_strAge = objReportInfo.m_strAge;
            m_strSampleType = objReportInfo.m_strSampleType;
            m_strCollector = objReportInfo.m_strCollector;
            if (objReportInfo.m_strCollectDat != null && objReportInfo.m_strCollectDat != "")
            {
                m_strCollectDat = DateTime.Parse(objReportInfo.m_strCollectDat).ToShortDateString();
            }
            else
            {
                m_strCollectDat = objReportInfo.m_strCollectDat;
            }
            m_strApplyer = objReportInfo.m_strApplyer;
            if (objReportInfo.m_strApplyDat != null && objReportInfo.m_strApplyDat != "")
            {
                m_strApplyDat = DateTime.Parse(objReportInfo.m_strApplyDat).ToString("yyyy-MM-dd HH:mm");
            }
            else
            {
                m_strApplyDat = objReportInfo.m_strApplyDat;
            }
            m_strApplyDept = objReportInfo.m_strApplyDept;
            m_strBedNO = objReportInfo.m_strBedNO;
            m_strCheckItem = objReportInfo.m_strCheckContent;
            m_strDiagnose = objReportInfo.m_strDiagnose;
            string strChargeInfo = "";
            if (objReportInfo.m_strChargeInfo != null)
            {
                strChargeInfo = objReportInfo.m_strChargeInfo.Replace("|", ", ");
                strChargeInfo = strChargeInfo.Replace(">", " ");
            }
            m_strChargeInfo = strChargeInfo;
            m_strChargeState = objReportInfo.m_strChargeState;
            //add by wjqin(07-3-30)
            m_strPRINTED_NUM = objReportInfo.m_intPRINTED_NUM.ToString();
            m_strPRINTED_DATE = "";
            if (objReportInfo.m_dtPRINTED_DATE != null && objReportInfo.m_dtPRINTED_DATE != DateTime.MinValue && objReportInfo.m_dtPRINTED_DATE != DateTime.MaxValue)
            {
                m_strPRINTED_DATE = objReportInfo.m_dtPRINTED_DATE.ToString("yyyy-MM-dd HH:mm");
            }
            if (objReportInfo.m_intPRINTED_NUM == 0)
            {
                m_strPRINTED_DATE = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            }
            /*<====================================*/
            /*<====================================*/
        }

        //xing.chen add for print barcode
        public void m_mthInitalPrintInfo(clsLisApplyReportInfo_VO objReportInfo, string p_strBarCode)
        {
            if (objReportInfo == null)
                return;
            m_strPatientInHospitalNO = objReportInfo.m_strPatientInHospitalNO;
            if (objReportInfo.m_strApplicationNO.Length > 8)
            {
                //取后面8位
                m_strApplicationNO = objReportInfo.m_strApplicationNO.Substring(objReportInfo.m_strApplicationNO.Length - 8, 8);
            }
            else
            {
                m_strApplicationNO = objReportInfo.m_strApplicationNO;
            }
            m_strPatientName = objReportInfo.m_strPatientName;
            m_strSex = objReportInfo.m_strSex;
            m_strAge = objReportInfo.m_strAge;
            m_strSampleType = objReportInfo.m_strSampleType;
            m_strCollector = objReportInfo.m_strCollector;
            if (objReportInfo.m_strCollectDat != null && objReportInfo.m_strCollectDat != "")
            {
                m_strCollectDat = DateTime.Parse(objReportInfo.m_strCollectDat).ToShortDateString();
            }
            else
            {
                m_strCollectDat = objReportInfo.m_strCollectDat;
            }
            m_strApplyer = objReportInfo.m_strApplyer;
            if (objReportInfo.m_strApplyDat != null && objReportInfo.m_strApplyDat != "")
            {
                m_strApplyDat = DateTime.Parse(objReportInfo.m_strApplyDat).ToString("yyyy-MM-dd HH:mm");
            }
            else
            {
                m_strApplyDat = objReportInfo.m_strApplyDat;
            }
            m_strApplyDept = objReportInfo.m_strApplyDept;
            m_strBedNO = objReportInfo.m_strBedNO;
            m_strCheckItem = objReportInfo.m_strCheckContent;
            m_strDiagnose = objReportInfo.m_strDiagnose;
            string strChargeInfo = "";
            if (objReportInfo.m_strChargeInfo != null)
            {
                strChargeInfo = objReportInfo.m_strChargeInfo.Replace("|", ", ");
                strChargeInfo = strChargeInfo.Replace(">", " ");
            }
            m_strChargeInfo = strChargeInfo;
            m_strChargeState = objReportInfo.m_strChargeState;
            m_strBarCode = p_strBarCode;
            //add by wjqin(07-3-30)
            m_strPRINTED_NUM = objReportInfo.m_intPRINTED_NUM.ToString();
            m_strPRINTED_DATE = "";
            if (objReportInfo.m_dtPRINTED_DATE != null && objReportInfo.m_dtPRINTED_DATE != DateTime.MinValue && objReportInfo.m_dtPRINTED_DATE != DateTime.MaxValue)
            {
                m_strPRINTED_DATE = objReportInfo.m_dtPRINTED_DATE.ToString("yyyy-MM-dd HH:mm");
            }
            if (objReportInfo.m_intPRINTED_NUM == 0)
            {
                m_strPRINTED_DATE = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            }
            /*<====================================*/
        }
        #endregion
    }
}