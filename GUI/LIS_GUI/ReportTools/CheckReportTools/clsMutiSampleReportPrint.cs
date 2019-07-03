using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Data;
using System.Windows.Forms;
using System.Collections;

namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// clsMutiSampleReportPrint 的摘要说明。
    /// </summary>
    public class clsMutiSampleReportPrint : com.digitalwave.GUI_Base.clsController_Base, infPrintRecord
    {
        #region 变量声名
        private long m_lngWidthPage;//打印页的宽度
        private long m_lngY;//当前Y方向坐标

        private float m_fltLeftIndentProp;//左缩进比例
        private float m_fltRightIndentProp;//右缩进比例

        private Font m_fntTitle;
        private Font m_fntSmallBold;
        private Font m_fntSmallNotBold;
        private Font m_fntSmall2NotBold;

        /// 边框画笔
        /// </summary>
        private Pen m_GridPen;

        public System.Data.DataTable m_dtbSample = null;//基本信息及评语
        public System.Data.DataTable m_dtbResult;//检验结果
        public string m_strTitle = "";//报告单标题

        public bool m_blnFinishPrint = false;//打印结束标志
        #endregion

        #region 构造函数
        public clsMutiSampleReportPrint()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            m_strTitle = this.m_objComInfo.m_strGetHospitalTitle();
        }
        #endregion

        #region 打印报告起始部分
        /// <summary>
        /// 打印报告起始部分
        /// </summary>
        /// <param name="p_objPrintArg"></param>
        private void m_mthPrintStart(System.Drawing.Printing.PrintPageEventArgs p_objPrintArg)
        {
            m_lngWidthPage = p_objPrintArg.PageBounds.Width;

            //m_strTitle="佛山市第二人民医院检验报告单";
            SizeF szTitle = p_objPrintArg.Graphics.MeasureString(m_strTitle, m_fntTitle);
            float fltCurrentX = m_lngWidthPage / 2 - (long)szTitle.Width / 2;//标题文本左上角的X轴坐标
            m_lngY = 10;//标题文本左上角Y轴坐标
            p_objPrintArg.Graphics.DrawString(m_strTitle, m_fntTitle, Brushes.Black, fltCurrentX, m_lngY);

            //1
            m_lngY = 20 + (int)szTitle.Height;
            SizeF szTmp = p_objPrintArg.Graphics.MeasureString("姓名:", m_fntSmallBold);
            fltCurrentX = m_lngWidthPage * m_fltLeftIndentProp;
            p_objPrintArg.Graphics.DrawString("姓名:", m_fntSmallBold, Brushes.Black, fltCurrentX, m_lngY);
            fltCurrentX += szTmp.Width + 4;
            p_objPrintArg.Graphics.DrawString(m_dtbSample.Rows[0]["patient_name_vchr"].ToString().Trim(), m_fntSmallNotBold, Brushes.Black,
                fltCurrentX, m_lngY);

            szTmp = p_objPrintArg.Graphics.MeasureString("科室:", m_fntSmallBold);
            fltCurrentX = m_lngWidthPage * (m_fltLeftIndentProp + (1 - m_fltLeftIndentProp - m_fltRightIndentProp) * 0.8f / 4);
            p_objPrintArg.Graphics.DrawString("科室:", m_fntSmallBold, Brushes.Black, fltCurrentX, m_lngY);
            fltCurrentX += szTmp.Width + 4;
            p_objPrintArg.Graphics.DrawString(m_dtbSample.Rows[0]["deptname_vchr"].ToString().Trim(), m_fntSmallNotBold, Brushes.Black,
                fltCurrentX, m_lngY);


            szTmp = p_objPrintArg.Graphics.MeasureString("住院号:", m_fntSmallBold);
            fltCurrentX = m_lngWidthPage * (m_fltLeftIndentProp + (1 - m_fltLeftIndentProp - m_fltRightIndentProp) * 0.82f / 2);
            p_objPrintArg.Graphics.DrawString("住院号:", m_fntSmallBold, Brushes.Black, fltCurrentX, m_lngY);
            fltCurrentX += szTmp.Width + 4;
            p_objPrintArg.Graphics.DrawString(m_dtbSample.Rows[0]["PATIENT_INHOSPITALNO_CHR"].ToString().Trim(), m_fntSmallNotBold, Brushes.Black,
                fltCurrentX, m_lngY);


            szTmp = p_objPrintArg.Graphics.MeasureString("送检医生:", m_fntSmallBold);
            fltCurrentX = m_lngWidthPage * (m_fltLeftIndentProp + (1 - m_fltLeftIndentProp - m_fltRightIndentProp) * 2.8f / 4);
            p_objPrintArg.Graphics.DrawString("送检医生:", m_fntSmallBold, Brushes.Black, fltCurrentX, m_lngY);
            fltCurrentX += szTmp.Width + 4;
            p_objPrintArg.Graphics.DrawString(m_dtbSample.Rows[0]["applyer"].ToString().Trim(), m_fntSmallNotBold, Brushes.Black,
                fltCurrentX, m_lngY);


            //2
            m_lngY = 25 + (int)szTitle.Height + (int)m_fntSmallBold.Height;
            szTmp = p_objPrintArg.Graphics.MeasureString("性别:", m_fntSmallBold);
            fltCurrentX = m_lngWidthPage * m_fltLeftIndentProp;
            p_objPrintArg.Graphics.DrawString("性别:", m_fntSmallBold, Brushes.Black, fltCurrentX, m_lngY);
            fltCurrentX += szTmp.Width + 4;
            p_objPrintArg.Graphics.DrawString(m_dtbSample.Rows[0]["sex_chr"].ToString().Trim(), m_fntSmallNotBold, Brushes.Black,
                fltCurrentX, m_lngY);


            szTmp = p_objPrintArg.Graphics.MeasureString("年龄:", m_fntSmallBold);
            fltCurrentX = m_lngWidthPage * (m_fltLeftIndentProp + (1 - m_fltLeftIndentProp - m_fltRightIndentProp) * 0.8f / 4);
            p_objPrintArg.Graphics.DrawString("年龄:", m_fntSmallBold, Brushes.Black, fltCurrentX, m_lngY);
            fltCurrentX += szTmp.Width + 4;
            p_objPrintArg.Graphics.DrawString(m_dtbSample.Rows[0]["age_chr"].ToString().Trim(), m_fntSmallNotBold, Brushes.Black,
                fltCurrentX, m_lngY);

            szTmp = p_objPrintArg.Graphics.MeasureString("床号:", m_fntSmallBold);
            fltCurrentX = m_lngWidthPage * (m_fltLeftIndentProp + (1 - m_fltLeftIndentProp - m_fltRightIndentProp) * 0.82f / 2);
            p_objPrintArg.Graphics.DrawString("床号:", m_fntSmallBold, Brushes.Black, fltCurrentX, m_lngY);
            fltCurrentX += szTmp.Width + 4;
            p_objPrintArg.Graphics.DrawString(m_dtbSample.Rows[0]["bedno_chr"].ToString().Trim(), m_fntSmallNotBold, Brushes.Black,
                fltCurrentX, m_lngY);

            szTmp = p_objPrintArg.Graphics.MeasureString("送检时间:", m_fntSmallBold);
            fltCurrentX = m_lngWidthPage * (m_fltLeftIndentProp + (1 - m_fltLeftIndentProp - m_fltRightIndentProp) * 2.8f / 4);
            p_objPrintArg.Graphics.DrawString("送检时间:", m_fntSmallBold, Brushes.Black, fltCurrentX, m_lngY);
            fltCurrentX += szTmp.Width + 4;
            p_objPrintArg.Graphics.DrawString(DateTime.Parse(m_dtbSample.Rows[0]["accept_dat"].ToString().Trim()).ToString("yyyy-MM-dd"),
                m_fntSmallNotBold, Brushes.Black, fltCurrentX, m_lngY);


            //3
            m_lngY = 30 + (int)szTitle.Height + (int)m_fntSmallBold.Height * 2;
            szTmp = p_objPrintArg.Graphics.MeasureString("临床诊断:", m_fntSmallBold);
            fltCurrentX = m_lngWidthPage * m_fltLeftIndentProp;
            p_objPrintArg.Graphics.DrawString("临床诊断:", m_fntSmallBold, Brushes.Black, fltCurrentX, m_lngY);
            fltCurrentX += szTmp.Width + 4;
            p_objPrintArg.Graphics.DrawString(m_dtbSample.Rows[0]["diagnose_vchr"].ToString().Trim(), m_fntSmallNotBold, Brushes.Black,
                fltCurrentX, m_lngY);

        }

        private void m_mthPrintLine(System.Drawing.Printing.PrintPageEventArgs p_objPrintArg)
        {
            m_lngY += 2 + m_fntSmallBold.Height;
            long intYStart = m_lngY;

            //画横线
            p_objPrintArg.Graphics.DrawLine(m_GridPen, m_lngWidthPage * 0.08f, intYStart, m_lngWidthPage * 0.92f, intYStart);

        }
        #endregion

        #region 打印正文
        /// <summary>
        /// 打印报告单中间部分
        /// </summary>
        /// <param name="p_objPrintArg"></param>
        private void m_mthPrintMiddle(System.Drawing.Printing.PrintPageEventArgs p_objPrintArg)
        {

            try
            {
                ArrayList arlTempLeft = new ArrayList();//存放打印在左栏的Group
                ArrayList arlTempRight = new ArrayList();//存放打印在右栏的Group


                #region 根据GROUPID_CHR从结果集表中得到各个Group并暂时放在 arlTempLeft 中
                ArrayList arlGroupID = new ArrayList();
                //获取所有的报告组标题
                for (int i = 0; i < m_dtbResult.Rows.Count; i++)
                {
                    bool blnHasSameGroup = false;
                    for (int j = 0; j < arlGroupID.Count; j++)
                    {
                        if (m_dtbResult.Rows[i]["GROUPID_CHR"].ToString().Trim() == arlGroupID[j].ToString().Trim())
                        {
                            blnHasSameGroup = true;
                            break;
                        }
                    }
                    if (!blnHasSameGroup)
                    {
                        string strGroupID = m_dtbResult.Rows[i]["GROUPID_CHR"].ToString().Trim();
                        arlGroupID.Add(strGroupID);
                    }
                }
                //存放各报告组
                for (int i = 0; i < arlGroupID.Count; i++)
                {
                    DataView dtvGroupData = new DataView(this.m_dtbResult);

                    dtvGroupData.RowFilter = "GROUPID_CHR = '" + arlGroupID[i].ToString().Trim() + "'";
                    if (dtvGroupData.Count > 0)
                    {
                        clsGroup objGroup = new clsGroup();
                        objGroup.m_dtvGroupData = dtvGroupData;
                        objGroup.m_dtvGroupData.Sort = "REPORT_PRINT_SEQ_INT ASC,SAMPLE_PRINT_SEQ_INT ";
                        objGroup.m_strGroupName = arlGroupID[i].ToString().Trim();
                        arlTempLeft.Add(objGroup);
                    }
                }
                #endregion

                //				this.m_mthDistributeGroup(ref arlTempLeft,ref arlTempRight);

                float fltLeftX = m_lngWidthPage * m_fltLeftIndentProp - 10f;//左栏打印的 X 起始点
                float fltRightX = m_lngWidthPage * 0.43f;//右栏打印的 X 起始点
                float fltLeftY = m_lngY;//左栏打印的 Y 起始点
                float fltRightY = m_lngY;//右栏打印的 Y 起始点
                float fltWidth = m_lngWidthPage * (1 - m_fltLeftIndentProp * 2) / 2 + 10f;// 分栏的宽度 
                string strGroupName;

                #region 打印标本信息
                float fltEndSampleInfoY;
                this.m_mthPrintSampleInfo(p_objPrintArg, fltLeftX, fltLeftY, fltWidth, out fltEndSampleInfoY);
                fltLeftY = fltEndSampleInfoY;
                #endregion

                #region 打印Group
                for (int i = 0; i < arlTempLeft.Count; i++)
                {
                    clsGroup objGroup = (clsGroup)arlTempLeft[i];
                    float fltEndY;
                    strGroupName = objGroup.m_dtvGroupData[0].Row["PRINT_TITLE_VCHR"].ToString().Trim();
                    this.m_mthPrintGroup(p_objPrintArg, objGroup.m_dtvGroupData, strGroupName, fltRightX, fltRightY, fltWidth, out fltEndY);
                    fltRightY = fltEndY;
                }
                #endregion

                float fltBodyEndY = 0;
                if (fltLeftY >= fltRightY)
                {
                    fltBodyEndY = fltLeftY;
                }
                else
                {
                    fltBodyEndY = fltRightY;
                }

                this.m_lngY = (long)fltBodyEndY;
            }
            catch { }
        }

        /// <summary>
        /// 打印标本信息
        /// </summary>
        /// <param name="p_objPrintArg"></param>
        /// <param name="p_fltX"></param>
        /// <param name="p_fltY"></param>
        /// <param name="p_fltWidth"></param>
        /// <param name="p_fltEndY"></param>
        private void m_mthPrintSampleInfo(System.Drawing.Printing.PrintPageEventArgs p_objPrintArg, float p_fltX, float p_fltY, float p_fltWidth, out float p_fltEndY)
        {
            p_fltEndY = 0;
            try
            {
                p_fltY += 6;
                float[] fltColumnXArr = new float[3];
                fltColumnXArr[0] = p_fltX + 8f;
                p_objPrintArg.Graphics.DrawString("样本号", m_fntSmallBold, Brushes.Black, fltColumnXArr[0], p_fltY);

                fltColumnXArr[1] = p_fltX + p_fltWidth * 0.25f + 8f;
                p_objPrintArg.Graphics.DrawString("仪器样本号", m_fntSmallBold, Brushes.Black, fltColumnXArr[1], p_fltY);

                fltColumnXArr[2] = p_fltX + p_fltWidth * 0.58f;
                p_objPrintArg.Graphics.DrawString("样本类型", m_fntSmallBold, Brushes.Black, fltColumnXArr[2], p_fltY);

                //定位Y轴坐标
                float fltCurrentY = p_fltY + 2;
                for (int i = 0; i < m_dtbSample.Rows.Count; i++)
                {
                    fltCurrentY += 1 + m_fntSmall2NotBold.Height;
                    p_objPrintArg.Graphics.DrawString(m_dtbSample.Rows[i]["sample_id_chr"].ToString().Trim(), m_fntSmall2NotBold, Brushes.Black,
                        fltColumnXArr[0], fltCurrentY);
                    p_objPrintArg.Graphics.DrawString(m_dtbSample.Rows[i]["device_sampleid_chr"].ToString().Trim(), m_fntSmall2NotBold, Brushes.Black,
                        fltColumnXArr[1], fltCurrentY);
                    p_objPrintArg.Graphics.DrawString(m_dtbSample.Rows[i]["SAMPLE_TYPE_DESC_VCHR"].ToString().Trim(), m_fntSmall2NotBold, Brushes.Black,
                        fltColumnXArr[2], fltCurrentY);
                }
                fltCurrentY += 4 + m_fntSmallBold.Height;
                p_fltEndY = fltCurrentY;
            }
            catch { }
        }

        /// <summary>
        /// 打印 Group
        /// </summary>
        /// <param name="p_objPrintArg"></param>
        /// <param name="p_dtvGroupData"></param>
        /// <param name="p_strGroupName"></param>
        /// <param name="p_fltX"></param>
        /// <param name="p_fltY"></param>
        /// <param name="p_fltWidth"></param>
        /// <param name="p_fltEndY"></param>
        private void m_mthPrintGroup(System.Drawing.Printing.PrintPageEventArgs p_objPrintArg, System.Data.DataView p_dtvGroupData, string p_strGroupName, float p_fltX, float p_fltY, float p_fltWidth, out float p_fltEndY)
        {
            p_fltEndY = 0;
            try
            {
                p_fltY += 6;
                float[] fltColumnXArr = new float[3];
                fltColumnXArr[0] = p_fltX + 8f;
                p_objPrintArg.Graphics.DrawString(p_strGroupName, m_fntSmallBold, Brushes.Black, fltColumnXArr[0], p_fltY);

                fltColumnXArr[1] = p_fltX + p_fltWidth * 0.32f + 8f;
                p_objPrintArg.Graphics.DrawString(" 结果", m_fntSmallBold, Brushes.Black, fltColumnXArr[1], p_fltY);

                fltColumnXArr[2] = p_fltX + p_fltWidth * 0.6f + 15f;
                p_objPrintArg.Graphics.DrawString("参考范围", m_fntSmallBold, Brushes.Black, fltColumnXArr[2], p_fltY);


                //打印标本项目排序 2004.06.03
                p_dtvGroupData.Sort = "REPORT_PRINT_SEQ_INT ASC,SAMPLE_PRINT_SEQ_INT ";

                //定位Y轴坐标
                float fltCurrentY = p_fltY + 2;
                #region 逐条打印记录
                for (int i = 0; i < p_dtvGroupData.Count; i++)
                {
                    string strResult = p_dtvGroupData[i].Row["result_vchr"].ToString().Trim();
                    string strAbnormal = p_dtvGroupData[i].Row["ABNORMAL_FLAG_CHR"].ToString().Trim();
                    string strUnit = p_dtvGroupData[i].Row["UNIT_VCHR"].ToString().Trim();
                    string strRefRange = p_dtvGroupData[i].Row["refrange_vchr"].ToString() + " " + strUnit;
                    string strMinVal = p_dtvGroupData[i].Row["MIN_VAL_DEC"].ToString().Trim();
                    string strMaxVal = p_dtvGroupData[i].Row["MAX_VAL_DEC"].ToString().Trim();
                    string strCheckItemName = p_dtvGroupData[i].Row["RPTNO_CHR"].ToString().Trim();


                    fltCurrentY += 1 + m_fntSmall2NotBold.Height;
                    p_objPrintArg.Graphics.DrawString(strCheckItemName, m_fntSmall2NotBold, Brushes.Black, fltColumnXArr[0], fltCurrentY);
                    //打印结果X轴的位置
                    fltColumnXArr[1] = p_fltX + p_fltWidth * 0.32f - 10f;
                    #region 打印 指示箭头
                    //1.根据异常标志判断,此处认为异常标志只有"H"(高)和"L"(低)两种情况
                    if (strAbnormal != null)
                    {
                        System.Drawing.Font objBoldFont = new Font("SimSun", 9, FontStyle.Bold);
                        string strPR;
                        if (strAbnormal == "H")
                        {
                            strPR = strResult + " " + "↑";
                            strPR = strPR.PadLeft(10);
                            p_objPrintArg.Graphics.DrawString(strPR, objBoldFont, Brushes.Black, fltColumnXArr[1], fltCurrentY);
                        }
                        else if (strAbnormal == "L")
                        {
                            if (strResult.Contains(">") || strResult.Contains("<"))
                                strPR = strResult + " " + "↑";
                            else
                                strPR = strResult + " " + "↓";
                            strPR = strPR.PadLeft(10);
                            p_objPrintArg.Graphics.DrawString(strPR, objBoldFont, Brushes.Black, fltColumnXArr[1], fltCurrentY);
                        }
                        else
                        {
                            strPR = strResult + " " + " ";
                            strPR = strPR.PadLeft(10);

                            p_objPrintArg.Graphics.DrawString(strPR, m_fntSmall2NotBold, Brushes.Black, fltColumnXArr[1], fltCurrentY);
                        }
                    }
                    #endregion

                    p_objPrintArg.Graphics.DrawString(strRefRange, m_fntSmallNotBold, Brushes.Black, fltColumnXArr[2], fltCurrentY);

                }
                #endregion
                fltCurrentY += 4 + m_fntSmallBold.Height;
                p_fltEndY = fltCurrentY;
            }
            catch { }
        }
        #endregion

        #region 评语部分
        //评语部分
        private void m_mthPrintSummary(System.Drawing.Printing.PrintPageEventArgs p_objPrintArg)
        {
            SizeF szPerWord = p_objPrintArg.Graphics.MeasureString("三", m_fntSmallNotBold);//获取一个字符的宽度;


            p_objPrintArg.Graphics.DrawString("实验室提示：", m_fntSmallBold, Brushes.Black, m_lngWidthPage * 0.08f, m_lngY + 4);
            m_lngY = m_lngY + m_fntSmallBold.Height + 4;
            long CurrentY = m_lngY;
            if (m_dtbSample.Rows[0]["SUMMARY_VCHR"] != null && m_dtbSample.Rows[0]["SUMMARY_VCHR"].ToString().Trim() != "")
            {
                float fltLeftX = m_lngWidthPage * m_fltLeftIndentProp + szPerWord.Width + 8;
                float fltRightX = m_lngWidthPage * 0.92f - fltLeftX;
                CurrentY += 4;
                long lngEndY = CurrentY + m_fntSmallNotBold.Height * 2 + 3;
                Rectangle rectSummary = new Rectangle((int)fltLeftX, (int)CurrentY, (int)fltRightX, (int)lngEndY);
                new com.digitalwave.controls.clsPrintRichTextContext(Color.Black, m_fntSmallNotBold).m_mthPrintText(m_dtbSample.Rows[0]["SUMMARY_VCHR"].ToString().Trim(),
                    m_dtbSample.Rows[0]["XML_SUMMARY_VCHR"].ToString().Trim(), m_fntSmallNotBold, Color.Black, rectSummary, p_objPrintArg.Graphics);
                CurrentY = lngEndY;
            }
            m_lngY += m_fntSmallNotBold.Height * 2 + 4;
        }
        #endregion

        #region 打印报告单结尾部分
        /// <summary>
        /// 打印报告单结尾部分
        /// </summary>
        /// <param name="p_objPrintArg"></param>
        private void m_mthPrintEnd(System.Drawing.Printing.PrintPageEventArgs p_objPrintArg)
        {
            // 检验医生
            string strCheckEmp = m_dtbSample.Rows[0]["reportor"].ToString().Trim();
            // 审核医生 （暂时是检验医生）
            string strConfirmEmp = m_dtbSample.Rows[0]["reportor"].ToString().Trim();

            m_lngY += 10;

            float fltCurrent = m_lngWidthPage * m_fltLeftIndentProp;
            p_objPrintArg.Graphics.DrawString("(检验结果仅供临床诊疗参考，只对该检测的标本负责!)", m_fntSmallNotBold, Brushes.Black, fltCurrent, m_lngY);
            m_lngY += m_fntSmallNotBold.Height + 6;
            //画线
            p_objPrintArg.Graphics.DrawLine(m_GridPen, m_lngWidthPage * 0.08f, m_lngY, m_lngWidthPage * 0.92f, m_lngY);

            m_lngY += 6;
            p_objPrintArg.Graphics.DrawString("报告日期:", m_fntSmallBold, Brushes.Black, fltCurrent, m_lngY);
            string strReportDate = "";
            if (Microsoft.VisualBasic.Information.IsDate(m_dtbSample.Rows[0]["report_dat"]))
            {
                strReportDate = ((DateTime)m_dtbSample.Rows[0]["report_dat"]).ToString("yyyy-MM-dd").Trim();
            }
            SizeF szTmp = p_objPrintArg.Graphics.MeasureString("报告日期:", m_fntSmallBold);
            fltCurrent += szTmp.Width + 4;
            p_objPrintArg.Graphics.DrawString(strReportDate, m_fntSmallBold, Brushes.Black, fltCurrent, m_lngY);


            p_objPrintArg.Graphics.DrawString("检验医生:", m_fntSmallBold, Brushes.Black, m_lngWidthPage * (m_fltLeftIndentProp + (1 - m_fltLeftIndentProp - m_fltRightIndentProp) / 3), m_lngY);

            fltCurrent = m_lngWidthPage * (m_fltLeftIndentProp + (1 - m_fltLeftIndentProp - m_fltRightIndentProp) / 3) + szTmp.Width + 4;
            p_objPrintArg.Graphics.DrawString(strCheckEmp, m_fntSmallBold, Brushes.Black, fltCurrent, m_lngY);

            fltCurrent = m_lngWidthPage * (m_fltLeftIndentProp + (1 - m_fltLeftIndentProp - m_fltRightIndentProp) * 2 / 3) + szTmp.Width * 3 / 4 + 4;
            p_objPrintArg.Graphics.DrawString("审核者:", m_fntSmallBold, Brushes.Black, fltCurrent, m_lngY);
            szTmp = p_objPrintArg.Graphics.MeasureString("审核者:", m_fntSmallBold);
            fltCurrent = fltCurrent + szTmp.Width + 4;
            p_objPrintArg.Graphics.DrawString(strCheckEmp, m_fntSmallBold, Brushes.Black, fltCurrent, m_lngY);


        }
        #endregion

        #region 打印报告单
        private void m_mthPrintPageSub(System.Drawing.Printing.PrintPageEventArgs p_objPrintArg)
        {
            m_mthPrintStart(p_objPrintArg);
            m_mthPrintLine(p_objPrintArg);
            m_mthPrintMiddle(p_objPrintArg);
            m_mthPrintSummary(p_objPrintArg);
            m_mthPrintEnd(p_objPrintArg);
            m_blnFinishPrint = true;
        }
        #endregion

        #region 继承打印接口
        /// <summary>
        /// 初始化打印变量
        /// </summary>
        /// <param name="p_objArg">外部需要初始化的变量，根据不同的实现使用</param>
        public void m_mthInitPrintTool(object p_objArg)
        {
            m_fntTitle = new Font("SimSun", 18, FontStyle.Bold);
            m_fntSmallBold = new Font("SimSun", 11, FontStyle.Bold);
            m_fntSmallNotBold = new Font("SimSun", 10f, FontStyle.Regular);
            m_fntSmall2NotBold = new Font("SimSun", 9f, FontStyle.Regular);

            m_GridPen = new Pen(Color.Black, 1);

            m_fltLeftIndentProp = 0.1f;
            m_fltRightIndentProp = 0.1f;

            #region 打印设置
            try
            {
                PaperSize ps = null;
                foreach (PaperSize objPs in ((System.Drawing.Printing.PrintDocument)p_objArg).PrinterSettings.PaperSizes)
                {
                    if (objPs.PaperName == "LIS_Report")
                    {
                        ps = objPs;
                        break;
                    }
                }
                if (ps != null)
                {
                    ((System.Drawing.Printing.PrintDocument)p_objArg).DefaultPageSettings.PaperSize = ps;
                }

            }
            catch
            {
                MessageBox.Show("打印机故障！", "iCare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            #endregion

        }

        /// <summary>
        /// 从数据库初始化打印内容。如果没有记录，打印空报表。
        /// </summary>
        public void m_mthInitPrintContent()
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
        /// <param name="p_objPrintArg">打印文档</param>
        public void m_mthBeginPrint(object p_objPrintArg)
        {
            #region 初始化打印数据
            m_dtbSample = ((clsPrintValuePara)p_objPrintArg).m_dtbBaseInfo;
            m_dtbResult = ((clsPrintValuePara)p_objPrintArg).m_dtbResult;
            m_strTitle = ((clsPrintValuePara)p_objPrintArg).m_strTitle;
            #endregion
        }

        /// <summary>
        /// 打印中
        /// </summary>
        /// <param name="p_objPrintArg"></param>
        public void m_mthPrintPage(object p_objPrintArg)
        {
            m_mthPrintPageSub((PrintPageEventArgs)p_objPrintArg);
        }

        /// <summary>
        /// 打印结束。一般使用它来更新数据库信息。
        /// </summary>
        /// <param name="p_objPrintArg"></param>
        public void m_mthEndPrint(object p_objPrintArg)
        {

        }
        #endregion
    }
}
