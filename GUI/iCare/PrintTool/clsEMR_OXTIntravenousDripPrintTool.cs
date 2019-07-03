using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Printing;
using System.Drawing;
//using com.digitalwave.controls;
using com.digitalwave.Utility.Controls;
using System.Windows.Forms;
using com.digitalwave.clsRecordsService;
using iCareData;

namespace iCare
{
    /// <summary>
    /// 催产素静脉点滴观察表打印类.
    /// </summary>
    public class clsEMR_OXTIntravenousDripPrintTool : infPrintRecord
    {
        private bool m_blnWantInit = true;
        private int m_intRowCount = 0;//当前可以打印的行数
        private int m_intPrintedCounts = 0;
        /// <summary>
        /// 表明是从数据库读取还是从文件直接提取信息
        /// </summary>
        private bool m_blnIsFromDataSource = true;

        /// <summary>
        /// 是否打印修改痕迹
        /// </summary>
        public static bool m_blnIsPrintMark = true;



        /// <summary>
        /// 首次打印时间
        /// </summary>
        private DateTime m_dtmFirstPrintDat;

        /// <summary>
        /// 当前病人
        /// </summary>
        private clsPatient m_objPatient;

        /// <summary>
        /// 打印信息。
        /// </summary>
        private clsEMR_OXTIntravenousDripDataInfo m_objPrintMainInfo;

        /// <summary>
        /// 当前打印高度.
        /// </summary>
        private int m_intPosY;



        /// <summary>
        /// 获取打印修改痕迹设置
        /// </summary>
        private void m_mthGetPrintMarkConfig()
        {
            int intConfig = com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_intGetEmrSettingValue("3012");
            if (intConfig == 0)
            {
                m_blnIsPrintMark = false;
            }
            else
            {
                m_blnIsPrintMark = true;
            }
        }

        public clsEMR_OXTIntravenousDripPrintTool()
        {
            
            // 获取打印修改痕迹设置
            m_mthGetPrintMarkConfig();
            
            // 初始化修改限定时间
            m_mthInitCanModifyTime();
        }

        
        /// <summary>
        /// 是否第一次打印该类中的内容
        /// </summary>
        protected bool m_blnIsFirstPrint = true;

        /// <summary>
        /// Pen对象
        /// </summary>
        protected Pen m_objPen;

        /// <summary>
        /// brush
        /// </summary>	
        protected System.Drawing.Brush m_objBrush;

        /// <summary>
        /// 打印正文的字体
        /// </summary>	
        protected System.Drawing.Font m_fontBody;

        /// <summary>
        /// 打印格子里面的字体。
        /// </summary>
        protected System.Drawing.Font m_fontInBody;

        /// <summary>
        /// 保存打印范围，域默认为(x,y,w,h:40,100,787 or 1109,1049 or 707)
        /// </summary>
        protected enum m_objPrintSize
        {
            /// <summary>
            /// 顶端
            /// </summary>
            TopY = 100,
            ///<summary>
            /// 左端
            /// </summary>
            LeftX = 60,

            /// <summary>
            /// 右端
            /// </summary>
            RightX = 40,

            /// <summary>
            /// 底端
            /// </summary>
            BottomY = 100
        }

        /// <summary>
        /// 打印宽度
        /// </summary>
        private int m_intPrintWidth;
        /// <summary>
        /// 打印高度
        /// </summary>
        private int m_intPrintHeight;

        ///<summary>
        ///变量：字与线间的位置高 ：间距
        ///</summary>
        private float m_fltZijiHeight = 5; //字与线间的位置高 ：间距

        /// <summary>
        /// 每一行高度
        /// </summary>
        private float m_intRowHeight;

        /// <summary>
        /// 格子内字体高度
        /// </summary>
        private float m_intWordHeight;

        /// <summary>
        /// 当前页
        /// </summary>
        private int m_intCurrentPageIndex = 1;

        /// <summary>
        /// 初始化打印变量
        /// </summary>
        /// <param name="e"></param>
        private void m_mthInitPrintInfo(PrintPageEventArgs e)
        {
            m_objPen = new Pen(Color.Black);
            m_objBrush = System.Drawing.Brushes.Black;
            m_fontBody = new System.Drawing.Font("simsun", 12);
            m_fontInBody = new Font("simsun", 10);

        
            m_intPosY = (int)m_objPrintSize.TopY;
            m_intPrintWidth = e.PageBounds.Width - (int)m_objPrintSize.LeftX - (int)m_objPrintSize.RightX;
            m_intPrintHeight = e.PageBounds.Height - (int)m_objPrintSize.TopY - (int)m_objPrintSize.BottomY;
            m_intWordHeight = e.Graphics.MeasureString("测高", m_fontBody).Height;
            m_intRowHeight = m_intWordHeight + 2 * m_fltZijiHeight;

            // 初始化每列宽度和每列LeftX值
            m_mthInitFloatCol();
            
        }

        #region 打印标题
        /// <summary>
        /// 打印标题
        /// </summary>
        /// <param name="e"></param>
        protected void m_mthPrintTitle(PrintPageEventArgs e)
        {
            System.Drawing.Graphics p_objGrp = e.Graphics;
            p_objGrp.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, new Font("SimSun", 12), m_objBrush, 320, m_intPosY);
            m_intPosY += 30;
            p_objGrp.DrawString("催产素静脉点滴观察表", new Font("SimSun", 18, FontStyle.Bold), m_objBrush, 250, m_intPosY);
            m_intPosY += 40;

            string m_strPrint = "姓名：" + m_objPatient.m_StrName;
            p_objGrp.DrawString(m_strPrint, m_fontBody, m_objBrush, (float)(m_objPrintSize.LeftX + 30), (float)m_intPosY);
            m_strPrint = "年龄：" + m_objPatient.m_ObjPeopleInfo.m_IntAge.ToString();
            p_objGrp.DrawString(m_strPrint, m_fontBody, m_objBrush, (float)(m_objPrintSize.LeftX) + (float)m_intPrintWidth / 4 + 30, (float)m_intPosY);
            m_strPrint = "床号：" + m_objPatient.m_strBedCode;
            p_objGrp.DrawString(m_strPrint, m_fontBody, m_objBrush, (float)(m_objPrintSize.LeftX) + (float)m_intPrintWidth / 2 + 30, (float)m_intPosY);
            m_strPrint = "住院号：" + m_objPatient.m_StrHISInPatientID;
            p_objGrp.DrawString(m_strPrint, m_fontBody, m_objBrush, (float)(m_objPrintSize.LeftX) + Convert.ToSingle(m_intPrintWidth * 0.75), (float)m_intPosY);

            m_intPosY += 25;
            p_objGrp.DrawLine(m_objPen, (int)m_objPrintSize.LeftX, m_intPosY, (int)m_objPrintSize.LeftX + m_intPrintWidth, m_intPosY);
            m_intPosY += 1;
            p_objGrp.DrawLine(m_objPen, (int)m_objPrintSize.LeftX, m_intPosY, (int)m_objPrintSize.LeftX + m_intPrintWidth, m_intPosY);

            m_intPosY += 10;
        }

        #endregion

        #region 打印宫颈成熟度评分
        /// <summary>
        /// 打印宫颈成熟度评分
        /// </summary>
        /// <param name="e"></param>
        protected void m_mthPrintBiShop(PrintPageEventArgs e)
        {
            System.Drawing.Graphics p_objGrp = e.Graphics;
            p_objGrp.DrawString("BiShop 宫颈成熟度评分：", m_fontBody, m_objBrush, (float)m_objPrintSize.LeftX + 30, (float)m_intPosY);
            string m_strPrintTxt;
            if (m_objPrintMainInfo != null && m_objPrintMainInfo.m_objBaseInfo != null && !string.IsNullOrEmpty(m_objPrintMainInfo.m_objBaseInfo.m_strBISHOPCOUNT))
                m_strPrintTxt = m_objPrintMainInfo.m_objBaseInfo.m_strBISHOPCOUNT;
            else
                m_strPrintTxt = "      ";

            p_objGrp.DrawString("累积评分共计：  " + m_strPrintTxt + "  分", m_fontBody, m_objBrush, (float)m_objPrintSize.LeftX + (float)m_intPrintWidth / 2 + 30, (float)m_intPosY);
            m_intPosY += 25;

            // 打印表格
            
            // 每列宽
            int m_intRowWidth = m_intPrintWidth / 5;
            // 画行
            for (int iRow1 = 0; iRow1 < 8; iRow1++)
            {
                p_objGrp.DrawLine(m_objPen, (int)m_objPrintSize.LeftX, m_intPosY + Convert.ToInt32(m_intRowHeight * iRow1), (int)m_objPrintSize.LeftX + m_intPrintWidth, m_intPosY + Convert.ToInt32(m_intRowHeight * iRow1));
            }
            // 画两边的列
            p_objGrp.DrawLine(m_objPen, (int)m_objPrintSize.LeftX, m_intPosY, (int)m_objPrintSize.LeftX, m_intPosY + 7 * m_intRowHeight);
            p_objGrp.DrawLine(m_objPen, (int)m_objPrintSize.LeftX + m_intPrintWidth, m_intPosY, (int)m_objPrintSize.LeftX + m_intPrintWidth, m_intPosY + 7 * m_intRowHeight);

            // 画中间较长的列
            for (int iRow = 1; iRow < 5; iRow++)
            {
                int x1 = (int)m_objPrintSize.LeftX + iRow * m_intRowWidth;
                p_objGrp.DrawLine(m_objPen, x1, m_intPosY, x1, m_intPosY + 6 * m_intRowHeight);
            }
            // 画中间较短的列
            for (int iRow = 1; iRow < 5; iRow++)
            {
                int x1 = (int)m_objPrintSize.LeftX + m_intRowWidth * iRow + m_intRowWidth / 2;
                p_objGrp.DrawLine(m_objPen, x1, m_intPosY + m_intRowHeight, x1, m_intPosY + m_intRowHeight * 6);
            }

            StringFormat m_strFormat = new StringFormat();
            m_strFormat.Alignment = StringAlignment.Center;
            m_strFormat.LineAlignment = StringAlignment.Center;
            // 画格子固定内容
            RectangleF m_rtgF = new RectangleF();
            // 第一行
            for (int iRow = 1; iRow < 5; iRow++)
            {
                m_rtgF.X = (float)m_objPrintSize.LeftX + iRow * m_intRowWidth;
                m_rtgF.Y = (float)m_intPosY;
                m_rtgF.Width = (float)m_intRowWidth;
                m_rtgF.Height = (float)m_intRowHeight;
                p_objGrp.DrawString(Convert.ToString(iRow - 1), m_fontInBody, m_objBrush, m_rtgF, m_strFormat);
            }

            // p_intPosY的值在第二行开始.
            m_intPosY += Convert.ToInt32(m_intRowHeight);
            // 第二行-----第六行 一列
            m_strFormat.Alignment = StringAlignment.Near;
            m_rtgF.X = (float)m_objPrintSize.LeftX;
            m_rtgF.Y = (float)m_intPosY;
            m_rtgF.Width = m_intRowWidth;
            m_rtgF.Height = m_intRowHeight;
            p_objGrp.DrawString("宫颈扩张（cm）", m_fontBody, m_objBrush, m_rtgF, m_strFormat);
            m_rtgF.Y = (float)m_intPosY + m_intRowHeight;
            p_objGrp.DrawString("宫颈管消失（%）", m_fontBody, m_objBrush, m_rtgF, m_strFormat);
            m_rtgF.Y = (float)m_intPosY + m_intRowHeight * 2;
            p_objGrp.DrawString("先露高低（cm）", m_fontBody, m_objBrush, m_rtgF, m_strFormat);
            m_rtgF.Y = (float)m_intPosY + m_intRowHeight * 3;
            p_objGrp.DrawString("宫颈软硬度", m_fontBody, m_objBrush, m_rtgF, m_strFormat);
            m_rtgF.Y = (float)m_intPosY + m_intRowHeight * 4;
            p_objGrp.DrawString("宫颈位置", m_fontBody, m_objBrush, m_rtgF, m_strFormat);

            // 第二行-----第六行 二列
            m_rtgF.X = (float)m_objPrintSize.LeftX + m_intRowWidth;
            m_rtgF.Y = (float)m_intPosY;
            m_rtgF.Width = m_intRowWidth / 2;
            m_rtgF.Height = m_intRowHeight;
            p_objGrp.DrawString("未开", m_fontBody, m_objBrush, m_rtgF, m_strFormat);
            m_rtgF.Y = (float)m_intPosY + m_intRowHeight;
            p_objGrp.DrawString("0-30", m_fontBody, m_objBrush, m_rtgF, m_strFormat);
            m_rtgF.Y = m_intPosY + m_intRowHeight * 2;
            p_objGrp.DrawString("-3", m_fontBody, m_objBrush, m_rtgF, m_strFormat);
            m_rtgF.Y = m_intPosY + m_intRowHeight * 3;
            p_objGrp.DrawString("硬", m_fontBody, m_objBrush, m_rtgF, m_strFormat);
            m_rtgF.Y = m_intPosY + m_intRowHeight * 4;
            p_objGrp.DrawString("后位", m_fontBody, m_objBrush, m_rtgF, m_strFormat);

            //  第二行-----第六行 三列

            m_rtgF.X = (float)m_objPrintSize.LeftX + m_intRowWidth * 2;
            m_rtgF.Y = (float)m_intPosY;
            m_rtgF.Width = m_intRowWidth / 2;
            m_rtgF.Height = m_intRowHeight;
            p_objGrp.DrawString("1-2", m_fontBody, m_objBrush, m_rtgF, m_strFormat);
            m_rtgF.Y = m_intPosY + m_intRowHeight;
            p_objGrp.DrawString("40-50", m_fontBody, m_objBrush, m_rtgF, m_strFormat);
            m_rtgF.Y = m_intPosY + m_intRowHeight * 2;
            p_objGrp.DrawString("-2", m_fontBody, m_objBrush, m_rtgF, m_strFormat);
            m_rtgF.Y = m_intPosY + m_intRowHeight * 3;
            p_objGrp.DrawString("中等", m_fontBody, m_objBrush, m_rtgF, m_strFormat);
            m_rtgF.Y = m_intPosY + m_intRowHeight * 4;
            p_objGrp.DrawString("中位", m_fontBody, m_objBrush, m_rtgF, m_strFormat);

            //  第二行-----第六行 四列
            m_rtgF.X = (float)m_objPrintSize.LeftX + m_intRowWidth * 3;
            m_rtgF.Y = (float)m_intPosY;
            m_rtgF.Width = m_intRowWidth / 2;
            m_rtgF.Height = m_intRowHeight;
            p_objGrp.DrawString("3-4", m_fontBody, m_objBrush, m_rtgF, m_strFormat);
            m_rtgF.Y = m_intPosY + m_intRowHeight;
            p_objGrp.DrawString("40-50", m_fontBody, m_objBrush, m_rtgF, m_strFormat);
            m_rtgF.Y = m_intPosY + m_intRowHeight * 2;
            p_objGrp.DrawString("-1或0", m_fontBody, m_objBrush, m_rtgF, m_strFormat);
            m_rtgF.Y = m_intPosY + m_intRowHeight * 3;
            p_objGrp.DrawString("软", m_fontBody, m_objBrush, m_rtgF, m_strFormat);
            m_rtgF.Y = m_intPosY + m_intRowHeight * 4;
            p_objGrp.DrawString("前位", m_fontBody, m_objBrush, m_rtgF, m_strFormat);

            //  第二行-----第六行 五列
            m_rtgF.X = (float)m_objPrintSize.LeftX + m_intRowWidth * 4;
            m_rtgF.Y = (float)m_intPosY;
            m_rtgF.Width = m_intRowWidth / 2;
            m_rtgF.Height = m_intRowHeight;
            p_objGrp.DrawString("≥5", m_fontBody, m_objBrush, m_rtgF, m_strFormat);
            m_rtgF.Y = m_intPosY + m_intRowHeight;
            p_objGrp.DrawString("≥80", m_fontBody, m_objBrush, m_rtgF, m_strFormat);
            m_rtgF.Y = m_intPosY + m_intRowHeight * 2;
            p_objGrp.DrawString("-1或+2", m_fontBody, m_objBrush, m_rtgF, m_strFormat);

            // 最后一行
            m_rtgF.X = (float)m_objPrintSize.LeftX;
            m_rtgF.Y = (float)m_intPosY + m_intRowHeight * 5;
            m_rtgF.Width = (float)m_intPrintWidth;
            m_rtgF.Height = m_intRowHeight;
            p_objGrp.DrawString(@"将检查结果在相应栏内划“√”，累积宫颈评分。", m_fontBody, m_objBrush, m_rtgF, m_strFormat);

            // 画小格
            m_strFormat.LineAlignment = StringAlignment.Center;
            m_strFormat.Alignment = StringAlignment.Center;

            m_rtgF.Height = m_intRowHeight;
            m_rtgF.Width = m_intRowWidth / 2;

            for (int col = 0; col < 4; col++)
            {
                m_rtgF.X = (float)m_objPrintSize.LeftX + Convert.ToSingle((col + 1.5) * m_intRowWidth);
                for (int iRow = 0; iRow < 5; iRow++)
                {
                    if (col == 3 && iRow > 2)
                        continue;
                    m_rtgF.Y = m_intPosY + Convert.ToInt32(m_intRowHeight) * iRow + 2;
                    p_objGrp.DrawString("口", m_fontBody, m_objBrush, m_rtgF, m_strFormat);
                }
            }

            // 画内容, 从第二行开始
            if (m_objPrintMainInfo != null && m_objPrintMainInfo.m_objBaseInfo != null)
            {
                int[] indexArr = new int[5];
                indexArr[0] = m_objPrintMainInfo.m_objBaseInfo.m_strBISHOP0.IndexOf("1");
                indexArr[1] = m_objPrintMainInfo.m_objBaseInfo.m_strBISHOP1.IndexOf("1");
                indexArr[2] = m_objPrintMainInfo.m_objBaseInfo.m_strBISHOP2.IndexOf("1");
                indexArr[3] = m_objPrintMainInfo.m_objBaseInfo.m_strBISHOP3.IndexOf("1");
                indexArr[4] = m_objPrintMainInfo.m_objBaseInfo.m_strBISHOP4.IndexOf("1");

                m_strFormat.Alignment = StringAlignment.Center;
                m_strFormat.LineAlignment = StringAlignment.Center;
                Font m_fontBodyBlod = new Font(m_fontBody, FontStyle.Bold);
                for (int index = 0; index < indexArr.Length; index++)
                {
                    int iRow = indexArr[index];
                    if (iRow >= 0)
                    {
                        m_rtgF.X = (float)m_objPrintSize.LeftX + Convert.ToSingle((iRow + 1.5) * m_intRowWidth);
                        m_rtgF.Y = (float)m_intPosY;
                        m_rtgF.Height = m_intRowHeight;
                        m_rtgF.Width = m_intRowWidth / 2;
                        p_objGrp.DrawString("√", m_fontBodyBlod, m_objBrush, m_rtgF, m_strFormat);
                    }
                    m_intPosY += Convert.ToInt32(m_intRowHeight);
                }
                m_fontBodyBlod.Dispose();
            }
            m_intPosY += Convert.ToInt32(m_intRowHeight);
        }

        #endregion

        #region 打印催产素静脉点滴概况
        /// <summary>
        /// 打印催产素静脉点滴概况
        /// </summary>
        /// <param name="e"></param>
        private void m_mthPrintOxInfo(PrintPageEventArgs e)
        {
            System.Drawing.Graphics p_objGrp = e.Graphics;
            com.digitalwave.controls.clsPrintRichTextContext m_objPrintContext = new com.digitalwave.controls.clsPrintRichTextContext(Color.Black, m_fontBody);

            RectangleF m_rtgF = new RectangleF();

            // 打印格式
            StringFormat m_strFormat = new StringFormat();
            m_strFormat.LineAlignment = StringAlignment.Center;
            m_strFormat.Alignment = StringAlignment.Near;

            int m_intRowHeight = 30;
            int m_intRowWidth = m_intPrintWidth / 2;

            if (m_blnIsFirstPrint)
            {
                // 先打印固定内容
                m_rtgF.X = (float)m_objPrintSize.LeftX;
                m_rtgF.Y = (float)m_intPosY;
                m_rtgF.Width = m_intRowWidth;
                m_rtgF.Height = m_intRowHeight;
                p_objGrp.DrawString(" 催产素静脉点滴情况：", m_fontBody, m_objBrush, m_rtgF, m_strFormat);

                m_rtgF.X = (float)m_objPrintSize.LeftX + m_intRowWidth;
                p_objGrp.DrawString(" 孕/产：", m_fontBody, m_objBrush, m_rtgF, m_strFormat);

                m_rtgF.X = (float)m_objPrintSize.LeftX;
                m_rtgF.Y = (float)m_intPosY + m_intRowHeight;
                p_objGrp.DrawString("     静滴催产素指征：", m_fontBody, m_objBrush, m_rtgF, m_strFormat);

                m_rtgF.X = (float)m_objPrintSize.LeftX + m_intRowWidth;
                p_objGrp.DrawString("  孕周：", m_fontBody, m_objBrush, m_rtgF, m_strFormat);

                
            }

            if (m_objPrintMainInfo != null && m_objPrintMainInfo.m_objBaseInfo != null)
            {
                Rectangle m_rtg = new Rectangle();
                m_objPrintContext.m_mthSetContextWithCorrectBefore(m_objPrintMainInfo.m_objBaseInfo.m_strOXTINTRAVENOUSDRIPINFO, m_objPrintMainInfo.m_objBaseInfo.m_strOXTINTRAVENOUSDRIPINFOXML, m_objPrintMainInfo.m_objBaseInfo.m_dtmFirstPrintDate);
                int m_intWidth;
                m_intWidth = Convert.ToInt32(p_objGrp.MeasureString(" 催产素静脉点滴情况：", m_fontBody).Width);
                m_rtg.X = (int)m_objPrintSize.LeftX + m_intWidth + 10;
                m_rtg.Y = m_intPosY;
                m_rtg.Width = m_intRowWidth - m_intWidth;
                m_rtg.Height = m_intRowHeight;
                m_objPrintContext.m_mthPrintText(m_objPrintMainInfo.m_objBaseInfo.m_strOXTINTRAVENOUSDRIPINFO, m_objPrintMainInfo.m_objBaseInfo.m_strOXTINTRAVENOUSDRIPINFOXML, m_fontBody, Color.Black, m_rtg, p_objGrp);

                m_intWidth = Convert.ToInt32(p_objGrp.MeasureString(" 孕/产：", m_fontBody).Width);
                m_rtg.X = (int)m_objPrintSize.LeftX + m_intRowWidth + m_intWidth + 10;
                m_rtg.Width = m_intRowWidth - m_intWidth;
                m_objPrintContext.m_mthPrintText(m_objPrintMainInfo.m_objBaseInfo.m_strLAYCOUNT_CHR, m_objPrintMainInfo.m_objBaseInfo.m_strLAYCOUNT_CHRXML, m_fontBody, Color.Black, m_rtg, p_objGrp);

                m_intWidth = Convert.ToInt32(p_objGrp.MeasureString("     静滴催产素指征：", m_fontBody).Width);
                m_rtg.X = (int)m_objPrintSize.LeftX + m_intWidth + 10;
                m_rtg.Width = m_intRowWidth - m_intWidth;
                m_rtg.Y = m_intPosY + m_intRowHeight;
                m_objPrintContext.m_mthPrintText(m_objPrintMainInfo.m_objBaseInfo.m_strOXTINDICATION, m_objPrintMainInfo.m_objBaseInfo.m_strOXTINDICATIONXML, m_fontBody, Color.Black, m_rtg, p_objGrp);

                m_intWidth = Convert.ToInt32(p_objGrp.MeasureString("  孕周：", m_fontBody).Width);
                m_rtg.X = (int)m_objPrintSize.LeftX + m_intRowWidth + m_intWidth + 10;
                m_rtg.Width = m_intRowWidth - m_intWidth;
                m_objPrintContext.m_mthPrintText(m_objPrintMainInfo.m_objBaseInfo.m_strGESTATIONALPERIOD, m_objPrintMainInfo.m_objBaseInfo.m_strGESTATIONALPERIODXML, m_fontBody, Color.Black, m_rtg, p_objGrp);
            }
            m_intPosY += 2 * m_intRowHeight;
        }
        #endregion

        #region 打印催产素静脉点滴情况

        /// <summary>
        /// 保存每一列的宽度
        /// </summary>
        float[] m_floatColWidth;

        /// <summary>
        /// 保存每一列的LeftX值
        /// </summary>
        float[] m_floatColLeftX;

        /// <summary>
        /// 初始化每列宽度和每列LeftX值
        /// </summary>
        private void m_mthInitFloatCol()
        {
            if (m_floatColWidth == null)
                m_floatColWidth = new float[11];
            if (m_floatColLeftX == null)
                m_floatColLeftX = new float[11];
            

            m_floatColWidth[0] = 70f;
            m_floatColWidth[1] = 50f;
            m_floatColWidth[2] = 110f;
            m_floatColWidth[3] = 70f;
            m_floatColWidth[4] = 50f;
            m_floatColWidth[5] = 50f;
            m_floatColWidth[6] = 60f;
            m_floatColWidth[7] = 60f;
            m_floatColWidth[8] = 50f;
            m_floatColWidth[9] = 90f;
            m_floatColWidth[10] = 70f;
            for (int index = 0; index < m_floatColLeftX.Length; index++)
            {
                if (index == 0)
                {
                    m_floatColLeftX[index] = (float)m_objPrintSize.LeftX;
                }
                else
                {
                    m_floatColLeftX[index] = m_floatColLeftX[index - 1] + m_floatColWidth[index - 1];
                }
            }
        }

        /// <summary>
        /// 过滤后的打印内容。
        /// </summary>
        ArrayList m_objReturnData;

        /// <summary>
        /// 打印工具
        /// </summary>
        com.digitalwave.controls.clsPrintRichTextContext m_objPrintContext;

        /// <summary>
        /// 修改限定时间
        /// </summary>
        int m_intCanModifyTiem;

        /// <summary>
        /// 初始化修改限定时间
        /// </summary>
        private void m_mthInitCanModifyTime()
        {
            try
            {
                m_intCanModifyTiem = int.Parse(clsEMRLogin.StrCanModifyTime);
            }
            catch
            {
                m_intCanModifyTiem = 6;
            }
        }

        /// <summary>
        /// 设置过滤后的打印内容。
        /// </summary>
        private void m_mthSetPrintValue()
        {
            if (m_objPrintMainInfo.m_objRecordArr == null && m_objPrintMainInfo.m_objRecordArr.Length <= 0)
                return;
            //if (m_objReturnData == null)
                m_objReturnData = new ArrayList();

            int intRecordCount = m_objPrintMainInfo.m_objRecordArr.Length;
            string strText, strXml;
            object[] objData = null;
            DateTime m_dtmPreRecordDate = DateTime.MinValue;
            clsDSTRichTextBoxValue objclsDSTRichTextBoxValue;
            try
            {
                for (int i = m_intPrintedCounts; i < intRecordCount; i++)
                {
                    clsEMR_OXTIntravenousDripCon objCurrent = m_objPrintMainInfo.m_objRecordArr[i];
                    clsEMR_OXTIntravenousDripCon objNext = new clsEMR_OXTIntravenousDripCon();//下一条记录

                    if (i < intRecordCount - 1)
                        objNext = m_objPrintMainInfo.m_objRecordArr[i + 1];

                    //如果该护理记录是修改前的记录且是在指定时间内修改的，修改者与创建者为同一人，则不显示
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strModifyUserID.Trim() == objCurrent.m_strCreateUserID.Trim())
                    {
                        TimeSpan tsModify = objNext.m_dtmModifyDate - objCurrent.m_dtmModifyDate;
                        if ((int)tsModify.TotalHours < m_intCanModifyTiem)
                        {
                            continue;
                        }
                    }

                    #region 存放关键字段

                    objData = new object[11];
                    
                    if (objCurrent.m_dtmCreateDate != DateTime.MinValue)
                    {
                        //同一个则只在第一行显示日期
                        if (objCurrent.m_dtmRecordDate.Date.ToString() != m_dtmPreRecordDate.Date.ToString())
                        {
                            objData[0] = objCurrent.m_dtmRecordDate.Date.ToString("yyyy-MM-dd");//日期字符串
                        }
                        else
                        {
                            objData[0] = "";
                        }
                        //修改后带有痕迹的记录不再显示时间
                        if (m_dtmPreRecordDate != objCurrent.m_dtmRecordDate)
                            objData[1] = objCurrent.m_dtmRecordDate.ToString("HH:mm");//时间字符串
                        else
                            objData[1] = "";
                    }
                    m_dtmPreRecordDate = objCurrent.m_dtmRecordDate;
                    #endregion ;

                    #region 存放单项信息

                    //催产素浓度
                    strText = objCurrent.m_strOXTDENSITY_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strOXTDENSITY_RIGHT != objCurrent.m_strOXTDENSITY_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(strText, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[2] = objclsDSTRichTextBoxValue;

                    //滴数
                    strText = objCurrent.m_strOXTDROPCOUNT_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strOXTDROPCOUNT_RIGHT != objCurrent.m_strOXTDROPCOUNT_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strOXTDROPCOUNT_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[3] = objclsDSTRichTextBoxValue;

                    //宫缩
                    strText = objCurrent.m_strUTERINECONTRACTION_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strUTERINECONTRACTION_RIGHT != objCurrent.m_strUTERINECONTRACTION_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strUTERINECONTRACTION_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[4] = objclsDSTRichTextBoxValue;

                    //胎心
                    strText = objCurrent.m_strFETALHEART_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strFETALHEART_RIGHT != objCurrent.m_strFETALHEART_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strFETALHEART_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[5] = objclsDSTRichTextBoxValue;

                    //宫口扩张
                    strText = objCurrent.m_strMETREURYNT_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strMETREURYNT_RIGHT != objCurrent.m_strMETREURYNT_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strMETREURYNT_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[6] = objclsDSTRichTextBoxValue;

                    //先露高低
                    strText = objCurrent.m_strPRESENTATION_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strPRESENTATION_RIGHT != objCurrent.m_strPRESENTATION_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strPRESENTATION_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[7] = objclsDSTRichTextBoxValue;

                    //血压
                    strText = objCurrent.m_strBP_S_RIGHT + "/" + objCurrent.m_strBP_A_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && (objNext.m_strBP_S_RIGHT + "/" + objNext.m_strBP_A_RIGHT) != (objCurrent.m_strBP_S_RIGHT + "/" + objCurrent.m_strBP_A_RIGHT))/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(strText, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[8] = objclsDSTRichTextBoxValue;

                    //特殊情况及处理
                    strText = objCurrent.m_strSPECIALINFO_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strSPECIALINFO_RIGHT != objCurrent.m_strSPECIALINFO_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strSPECIALINFO_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[9] = objclsDSTRichTextBoxValue;

                    if (objCurrent.objSignerArr != null)
                    {
                        //签名
                        strText = string.Empty;
                        for (int j = 0; j < objCurrent.objSignerArr.Length; j++)
                        {
                            strText += objCurrent.objSignerArr[j].objEmployee.m_strLASTNAME_VCHR + " ";
                        }
                        strXml = "<root />";
                        objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                        objclsDSTRichTextBoxValue.m_strText = strText;
                        objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                        objData[10] = objclsDSTRichTextBoxValue;
                    }
                    #endregion
                    m_objReturnData.Add(objData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        /// <summary>
        /// 打印表头
        /// </summary>
        /// <param name="e"></param>
        private void m_mthPrintTableHead(PrintPageEventArgs e)
        {
            if (m_floatColWidth == null || m_floatColLeftX == null)
                m_mthInitFloatCol();

            System.Drawing.Graphics g = e.Graphics;
            int m_intPrintTableHeadHeight = 60;
            StringFormat m_sf = new StringFormat();
            m_sf.Alignment = StringAlignment.Center;
            m_sf.LineAlignment = StringAlignment.Center;

            g.DrawLine(m_objPen, m_floatColLeftX[0], m_intPosY, m_floatColLeftX[10] + m_floatColWidth[10], m_intPosY);

            string[] m_strTitleNameArr = new string[] { "日期", "时间", "催产素浓度(U/500ml)", "滴数(滴/分)", "宫缩", "胎心", "宫口抗张", "先露高底", "血压", "特殊情况及处理", "签名" };
            RectangleF m_rtf = new RectangleF(m_floatColLeftX[0], m_intPosY, m_floatColWidth[0], m_intPrintTableHeadHeight);
            for (int i = 0; i < m_floatColWidth.Length; i++)
            {
                g.DrawLine(m_objPen, m_floatColLeftX[i], m_intPosY, m_floatColLeftX[i], m_intPosY + m_intPrintTableHeadHeight);
                m_rtf.X = m_floatColLeftX[i];
                m_rtf.Width = m_floatColWidth[i];
                g.DrawString(m_strTitleNameArr[i], m_fontBody, m_objBrush, m_rtf, m_sf);
            }
            g.DrawLine(m_objPen, m_floatColLeftX[m_floatColLeftX.Length -1] + m_floatColWidth[m_floatColWidth.Length -1], m_intPosY, m_floatColLeftX[m_floatColLeftX.Length -1] + m_floatColWidth[m_floatColWidth.Length -1], m_intPosY + m_intPrintTableHeadHeight); 
            m_intPosY += m_intPrintTableHeadHeight;
            g.DrawLine(m_objPen, m_floatColLeftX[0], m_intPosY, m_floatColLeftX[10] + m_floatColWidth[10], m_intPosY);
            
        }
        /// <summary>
        /// 打印催产素静脉点滴情况
        /// </summary>
        /// <param name="e"></param>
        private void m_mthPrintOxtInfoDetal(PrintPageEventArgs e)
        {
            if(m_objReturnData.Count <= 0)
                return;

            m_objPrintContext = new com.digitalwave.controls.clsPrintRichTextContext(Color.Black, m_fontInBody);
            // 当前页可以打印的行数
            m_intRowCount = Convert.ToInt32((e.PageBounds.Height - (int)m_objPrintSize.BottomY - m_intPosY) / m_intRowHeight);
            // 因为留出一行位置来打印页脚 ，所以显示总行数为减1
            m_intRowCount--;
            
            System.Drawing.Graphics g = e.Graphics;
            clsDSTRichTextBoxValue m_objDSTBoxValue;
            RectangleF m_rtf = new RectangleF();
            Rectangle m_rtg = new Rectangle();

            int m_intRealHeight;

            StringFormat m_sf = new StringFormat();
            m_sf.LineAlignment = StringAlignment.Center;
            m_sf.Alignment = StringAlignment.Center;

            int i = 0;
            m_intPrintedCounts += m_intRowCount;
            for (; i < m_intRowCount && i < m_objReturnData.Count; i++)
            {
                m_rtf.Y = m_intPosY;
                m_rtf.Height = m_intRowHeight;

                object[] m_objData = (object[])m_objReturnData[i];
                for (int index = 0; index < m_floatColLeftX.Length; index++)
                {
                    m_rtf.X = m_floatColLeftX[index];
                    m_rtf.Width = m_floatColWidth[index];

                    if (m_objData[index].GetType().Name == "clsDSTRichTextBoxValue")
                    {
                        m_rtg.X = Convert.ToInt32(m_rtf.X);
                        m_rtg.Y = Convert.ToInt32(m_rtf.Y);
                        m_rtg.Height = Convert.ToInt32(m_rtf.Height);
                        m_rtg.Width = Convert.ToInt32(m_rtf.Width);

                        m_objDSTBoxValue = (clsDSTRichTextBoxValue)m_objData[index];
                        if (m_objDSTBoxValue != null)
                        {
                            m_objPrintContext.m_mthSetContextWithCorrectBefore(m_objDSTBoxValue.m_strText, m_objDSTBoxValue.m_strDSTXml, DateTime.Now);
                            m_objPrintContext.m_blnPrintInBlock(m_fontInBody.Name, m_fontInBody.Size, m_rtg, g, false, out m_intRealHeight, false, true);
                        }
                    }
                    else
                    {
                        g.DrawString(Convert.ToString(m_objData[index]), m_fontInBody, m_objBrush, m_rtf, m_sf);
                    }
                    g.DrawLine(m_objPen, m_floatColLeftX[index], m_intPosY, m_floatColLeftX[index], m_intPosY + m_intRowHeight);
                }
                g.DrawLine(m_objPen, m_floatColLeftX[m_floatColLeftX.Length -1] + m_floatColWidth[m_floatColWidth.Length -1], m_intPosY, m_floatColLeftX[m_floatColLeftX.Length -1] + m_floatColWidth[m_floatColWidth.Length -1], m_intPosY + m_intRowHeight);
                m_intPosY += Convert.ToInt32(m_intRowHeight);
                g.DrawLine(m_objPen, m_floatColLeftX[0], m_intPosY, m_floatColLeftX[m_floatColLeftX.Length-1] + m_floatColWidth[m_floatColWidth.Length-1], m_intPosY);
                
            }
           
            m_mthPrintFoot(e);
            //判断是否多页
            if (i < this.m_objReturnData.Count)
            {
                m_intCurrentPageIndex++;
                e.HasMorePages = true;
                m_intPosY = (int)m_objPrintSize.TopY;
                return;
            }			

        }

        #region 获取痕迹保留
        /// <summary>
        /// 获取痕迹保留
        /// </summary>
        /// <param name="p_strText"></param>
        /// <param name="p_strModifyUserID"></param>
        /// <param name="p_strModifyUserName"></param>
        /// <returns></returns>
        private string m_strGetDSTTextXML(string p_strText, string p_strModifyUserID, string p_strModifyUserName)
        {
            return com.digitalwave.controls.ctlRichTextBox.clsXmlTool.s_strMakeDSTXml(p_strText, p_strModifyUserID, p_strModifyUserName, Color.Black, Color.White);
        }
        #endregion
        #endregion

        #region 打印页脚
        /// <summary>
        /// 打印页脚
        /// </summary>
        /// <param name="e"></param>
        private void m_mthPrintFoot(PrintPageEventArgs e)
        {
            System.Drawing.Graphics g = e.Graphics;
            StringFormat m_sf = new StringFormat();
            m_sf.Alignment = StringAlignment.Center;
            m_sf.LineAlignment = StringAlignment.Center;
            RectangleF m_rtf = new RectangleF((float)m_objPrintSize.LeftX, e.PageBounds.Height - (int)m_objPrintSize.BottomY - 30, m_intPrintWidth, m_intRowHeight);
            g.DrawString("第 " + m_intCurrentPageIndex.ToString() + " 页", m_fontBody, m_objBrush, m_rtf, m_sf);
        }
        #endregion

        #region infPrintRecord 成员

        /// <summary>
        /// 设置打印信息(当从数据库读取时要首先调用.
        /// </summary>
        /// <param name="p_objPatient">病人</param>
        /// <param name="p_dtmInPatientDate">入院日期</param>
        /// <param name="p_dtmOpenDate">OpenDate，如果是一次打印多次记录表单的类型（如病案记录），忽略OpenDate</param>
        public void m_mthSetPrintInfo(clsPatient p_objPatient, DateTime p_dtmInPatientDate, DateTime p_dtmOpenDate)
        {
            m_objPatient = p_objPatient;
            m_objPatient.m_ObjPeopleInfo.m_dtInpatient = p_dtmInPatientDate;

        }

        /// <summary>
        /// 从数据库初始化打印内容。如果没有记录，打印空报表。(当从数据库读取时要调用.)
        /// </summary>
        public void m_mthInitPrintContent()
            {
                if (this.m_objPatient == null)
                {
                    clsPublicFunction.ShowInformationMessageBox("在执行m_mthInitPrintContent之前请先执行m_mthSetPrintInfo函数");
                    return;
                }

                if (m_blnIsFromDataSource)
                {
                    clsRecordsDomain m_objServ = new clsRecordsDomain(enmRecordsType.EMR_OXTIntravenousDrip);

                    clsTransDataInfo[] m_objTempArr = null;
                    if (m_objServ.m_lngGetTransDataInfoArr(m_objPatient.m_StrRegisterId, out m_objTempArr) > 0 && m_objTempArr != null && m_objTempArr.Length > 0)
                    {
                        m_objPrintMainInfo = m_objTempArr[0] as clsEMR_OXTIntravenousDripDataInfo;
                        if (m_objPrintMainInfo.m_objBaseInfo != null)
                        {
                            if (m_objPrintMainInfo.m_objBaseInfo.m_dtmFirstPrintDate != DateTime.MinValue)
                            {
                                m_blnIsFirstPrint = true;
                            }
                            else
                            {
                                m_dtmFirstPrintDat = m_objPrintMainInfo.m_objBaseInfo.m_dtmFirstPrintDate;
                            }
                        }
                    }
                }
            }
        /// <summary>
        /// 设置打印内容。
        /// </summary>
        /// <param name="p_objPrintContent"></param>
        public void m_mthSetPrintContent(object p_objPrintContent)
        {
            m_blnWantInit = false;
            if (p_objPrintContent.GetType().Name != "clsEMR_OXTIntravenousDripDataInfo")
            {
                MDIParent.ShowInformationMessageBox("参数错误");
            }
            m_blnIsFromDataSource = false;//表明是从文件直接提取信息
            m_objPrintMainInfo = (clsEMR_OXTIntravenousDripDataInfo)p_objPrintContent;

            //m_mthSetPrintContent((clsEMR_OXTIntravenousDrip_BASE)m_objPrintMainInfo.m_objBaseInfo, (clsEMR_OXTIntravenousDripCon)m_objPrintMainInfo.m_objBaseInfo, DateTime.Now );
        }

        public object m_objGetPrintInfo()
        {
            if (m_blnIsFromDataSource)
            {
                if (m_objPrintMainInfo == null)
                {
                    //MDIParent.ShowInformationMessageBox("当从数据库读取时,调用m_objGetPrintInfo之前请首先调用m_mthSetPrintInfo函数");
                    return null;
                }

                if (m_blnWantInit)
                    m_mthInitPrintContent();
            }

            //没有记录内容时，返回空
            if (m_objPrintMainInfo.m_objBaseInfo == null)
                return null;
            else
                return m_objPrintMainInfo;
        }

        /// <summary>
        /// 初始化打印工具类的一些属性，如：打印过程中所使用的字体、画刷等
        /// </summary>
        /// <param name="p_objArg"></param>
        public void m_mthInitPrintTool(object p_objArg)
        {
           
        }

        /// <summary>
        /// 垃圾回收
        /// </summary>
        /// <param name="p_objArg"></param>
        public void m_mthDisposePrintTools(object p_objArg)
        {

        }

        /// <summary>
        /// 开始打印
        /// </summary>
        /// <param name="p_objPrintArg"></param>
        public void m_mthBeginPrint(object p_objPrintArg)
        {
            
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="p_objPrintArg"></param>
        public void m_mthPrintPage(object p_objPrintArg)
        {
            PrintPageEventArgs e = (PrintPageEventArgs)p_objPrintArg;

            // 初始化打印变量
            m_mthInitPrintInfo(e);
            // 打印标题
            m_mthPrintTitle(e);
            if (m_intCurrentPageIndex == 1)
            {
                // 打印宫颈成熟度评分
                m_mthPrintBiShop(e);
                // 打印催产素静脉点滴概况
                m_mthPrintOxInfo(e);

            }
            // 打印表头
            m_mthPrintTableHead(e);
            

            //设置过滤后的打印内容。
            m_mthSetPrintValue();

            // 打印催产素静脉点滴情况
            m_mthPrintOxtInfoDetal(e);

        }

        public void m_mthEndPrint(object p_objPrintArg)
        {
            if (m_blnIsFromDataSource == false || m_objPatient.m_StrEMRInPatientID == "") return;

            ArrayList arlRecordType = new ArrayList();
            ArrayList arlOpenDate = new ArrayList();

            m_intRowCount = 0;
            m_intCurrentPageIndex = 1;
            m_intPrintedCounts = 0;
            //如果打印成功，查找有无需要更新的时间，如果有，更新时间。 
            if (!((PrintEventArgs)p_objPrintArg).Cancel && m_blnIsFirstPrint != null)
            {
                int intUpdateIndex = -1;//若没有任何记录

                if (m_blnIsFirstPrint)
                {
                    //更新记录，只需使用新的首次打印时间作为有效的输入参数。


                    //存放记录类型
                    arlRecordType.Add(m_objPrintMainInfo.m_intFlag);
                    //存放记录的OpenDate
                    arlOpenDate.Add(m_objPrintMainInfo.m_objBaseInfo.m_dtmOpenDate);

                }
            }

            clsRecordsDomain m_objServ = new clsRecordsDomain(enmRecordsType.EMR_OXTIntravenousDrip);
            m_objServ.m_lngUpdateFirstPrintDate(m_objPatient.m_StrEMRInPatientID, m_objPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"), (int[])arlRecordType.ToArray(typeof(int)), (DateTime[])arlOpenDate.ToArray(typeof(DateTime)), m_dtmFirstPrintDat);

        }

        #endregion
        
    }
}
