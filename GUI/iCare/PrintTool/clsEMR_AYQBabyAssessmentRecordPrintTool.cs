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
    ///  爱婴区婴儿评估表打印类
    /// </summary>
    public class clsEMR_AYQBabyAssessmentRecordPrintTool : infPrintRecord
    {
        #region 变量
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
        ///// <summary>
        ///// 当前病人
        ///// </summary>
        //private clsPatient m_objPatient;
        /// <summary>
        /// 打印信息。
        /// </summary>
        private clsPrintInfo_clsAYQBabyAssessmentRecord m_objPrintMainInfo;
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
        /// 保存打印范围，20*27
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
            RightX = 80,

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
        private int m_intCurrentPageIndex;

        /// <summary>
        /// 保存每一列的宽度
        /// </summary>
        float[] m_floatColWidth;

        /// <summary>
        /// 保存每一列的LeftX值
        /// </summary>
        float[] m_floatColLeftX;
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

        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        public clsEMR_AYQBabyAssessmentRecordPrintTool()
        {
            m_objPrintMainInfo = new clsPrintInfo_clsAYQBabyAssessmentRecord();
            // 获取打印修改痕迹设置
            m_mthGetPrintMarkConfig();

            // 初始化修改限定时间
            m_mthInitCanModifyTime();

        }

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

            m_intCurrentPageIndex = 1;
            m_intPosY = (int)m_objPrintSize.TopY;
            m_intPrintWidth = e.PageBounds.Width - (int)m_objPrintSize.LeftX - (int)m_objPrintSize.RightX;
            m_intPrintHeight = e.PageBounds.Height - (int)m_objPrintSize.TopY - (int)m_objPrintSize.BottomY;
            m_intWordHeight = e.Graphics.MeasureString("测高", m_fontBody).Height;
            m_intRowHeight = m_intWordHeight + 2 * m_fltZijiHeight;

            // 初始化每列宽度和每列LeftX值
            m_mthInitFloatCol(); 
        }
        /// <summary>
        /// 初始化每列宽度和每列LeftX值
        /// </summary>
        private void m_mthInitFloatCol()
        {
            if (m_floatColWidth == null)
                m_floatColWidth = new float[13];
            if (m_floatColLeftX == null)
                m_floatColLeftX = new float[13];


            m_floatColWidth[0] = 80f;
            //m_floatColWidth[1] = 50f;
            //m_floatColWidth[2] = 110f;
            //m_floatColWidth[3] = 70f;
            //m_floatColWidth[4] = 50f;
            //m_floatColWidth[5] = 50f;
            //m_floatColWidth[6] = 60f;
            //m_floatColWidth[7] = 60f;
            //m_floatColWidth[8] = 50f;
            //m_floatColWidth[9] = 90f;
            //m_floatColWidth[10] = 70f;

            int m_intTempWidth = (m_intPrintWidth - m_floatColWidth[0])/12;
            for (int i = 1; i < m_floatColWidth.Length; i++)
            {
                m_floatColWidth[i] = m_intTempWidth;
            }

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

        #region 打印标题
        /// <summary>
        /// 打印标题
        /// </summary>
        /// <param name="e"></param>
        protected void m_mthPrintTitle(PrintPageEventArgs e)
        {
            System.Drawing.Graphics p_objGrp = e.Graphics;
            RectangleF m_rtgF = new RectangleF((float)m_objPrintSize.LeftX, (float)m_intPosY, m_intPrintWidth, 30);
            StringFormat m_strFormat = new StringFormat();
            m_strFormat.Alignment = StringAlignment.Center;
            m_strFormat.LineAlignment = StringAlignment.Center;

            p_objGrp.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, new Font("SimSun", 12), m_objBrush, m_rtgF, m_strFormat);
            m_intPosY += 30;
            m_rtgF.Y = m_intPosY;
            m_rtgF.Height = 40;
            p_objGrp.DrawString("爱婴区婴儿评估表", new Font("SimSun", 18, FontStyle.Bold), m_objBrush, m_rtgF, m_strFormat);
            m_intPosY += 40;

            string m_strPrint = "姓名：" + m_objPrintMainInfo.m_strPatientName;
            p_objGrp.DrawString(m_strPrint, m_fontBody, m_objBrush, (float)(m_objPrintSize.LeftX + 30), (float)m_intPosY);
            m_strPrint = "性别：" + m_objPrintMainInfo.m_strSex;
            p_objGrp.DrawString(m_strPrint, m_fontBody, m_objBrush, (float)(m_objPrintSize.LeftX) + (float)m_intPrintWidth / 4 + 30, (float)m_intPosY);
            m_strPrint = "床号：" + m_objPrintMainInfo.m_strBedName;
            p_objGrp.DrawString(m_strPrint, m_fontBody, m_objBrush, (float)(m_objPrintSize.LeftX) + (float)m_intPrintWidth / 2 + 30, (float)m_intPosY);
            m_strPrint = "住院号：" + m_objPrintMainInfo.m_strHISInPatientID;
            p_objGrp.DrawString(m_strPrint, m_fontBody, m_objBrush, (float)(m_objPrintSize.LeftX) + Convert.ToSingle(m_intPrintWidth * 0.75), (float)m_intPosY);

            m_intPosY += 25;

            m_strFormat.Dispose();
        }

        #endregion

        #region 爱婴区婴儿评估记录
        /// <summary>
        /// 爱婴区婴儿评估记录
        /// </summary>
        /// <param name="e"></param>
        protected void m_mthPrintAYQBabyConnect(PrintPageEventArgs e)
        {
            System.Drawing.Graphics p_objGrp = e.Graphics;
            StringFormat m_strFormat = new StringFormat();
            RectangleF m_rtF = new RectangleF();

            p_objGrp.DrawRectangle(m_objPen, (float)m_objPrintSize.LeftX, m_intPosY, m_intPrintWidth, m_intRowHeight * 2);

            for (int iCol = 1; iCol < m_floatColLeftX.Length -1; iCol++)
            {
                p_objGrp.DrawLine(m_objPen, m_floatColLeftX[iCol], m_intPosY, m_floatColLeftX[iCol], m_intPosY + m_intRowHeight * 2);
            }
            p_objGrp.DrawLine(m_objPen, (float)m_objPrintSize.LeftX, m_intPosY, (float)m_objPrintSize.LeftX + m_floatColWidth[0], m_intPosY + m_intRowHeight * 2);

            m_rtF.X = (float)m_objPrintSize.LeftX;
            m_rtF.Y = m_intPosY;
            m_rtF.Width = m_floatColWidth[0];
            m_rtF.Height = m_intRowHeight;
            m_strFormat.Alignment = StringAlignment.Far;
            p_objGrp.DrawString("评估内容", m_fontBody, m_objBrush, m_rtF, m_strFormat);

            m_rtF.Y = m_intPosY + m_intRowHeight;
            m_strFormat.Alignment = StringAlignment.Near;
            p_objGrp.DrawString(" 日期", m_fontBody, m_objBrush, m_rtF, m_strFormat);


            m_rtF.Y = m_intPosY;
            m_rtF.Height = m_intRowHeight * 2;
            m_strFormat.Alignment = StringAlignment.Center;
            m_strFormat.LineAlignment = StringAlignment.Center;
            string[] m_strNameArr = new string[] { "面色", "呼吸", "反应", "进食", "腋湿", "皮肤", "黄疸", "脐部", "四肢活动", "大便", "小便", "签名"};
            for (int iCol = 1; iCol < m_floatColLeftX.Length; iCol++)
            {
                m_rtF.X = m_floatColLeftX[iCol];
                m_rtF.Width = m_floatColWidth[iCol];
                p_objGrp.DrawString(m_strNameArr[iCol - 1], m_fontBody, m_objBrush, m_rtF, m_strFormat);
            }
            m_intPosY += m_intRowHeight * 2;

            #region 打印记录
            if (m_objPrintMainInfo == null)
                return;
            // 
            int m_intRowCount = 0;
            if (m_objPrintMainInfo.m_objAYQBabyContent != null)
                m_intRowCount = m_objPrintMainInfo.m_objAYQBabyContent.Length;
            clsAYQBabyAssessmentContent m_objAYQContent;
            m_rtF.Height = m_intRowHeight;
            for (int iRow = 0; iRow < m_intRowCount; iRow++)
            {
                m_objAYQContent = m_objPrintMainInfo.m_objAYQBabyContent[iRow];
                // 日期
                m_rtF.Y = m_intPosY;
                m_rtF.X = m_floatColLeftX[0];
                m_rtF.Width = m_floatColWidth[0];
                p_objGrp.DrawRectangle(m_objPen, m_rtF.X, m_rtF.Y, m_rtF.Width, m_rtF.Height);
                p_objGrp.DrawString(m_objAYQContent.m_dtmRecordDate.ToString("yyyy-MM-dd hh:mm"), m_fontInBody, m_objBrush, m_rtF, m_strFormat);

                // 面色
                m_rtF.X = m_floatColLeftX[1];
                m_rtF.Width = m_floatColWidth[1];
                p_objGrp.DrawRectangle(m_objPen, m_rtF.X, m_rtF.Y, m_rtF.Width, m_rtF.Height);
                p_objGrp.DrawString(m_objAYQContent.m_strFacecolor, m_fontInBody, m_objBrush, m_rtF, m_strFormat);
                // 呼吸
                m_rtF.X = m_floatColLeftX[2];
                m_rtF.Width = m_floatColWidth[2];
                p_objGrp.DrawRectangle(m_objPen, m_rtF.X, m_rtF.Y, m_rtF.Width, m_rtF.Height);
                p_objGrp.DrawString(m_objAYQContent.m_strRespiration, m_fontInBody, m_objBrush, m_rtF, m_strFormat);
                // 反应
                m_rtF.X = m_floatColLeftX[3];
                m_rtF.Width = m_floatColWidth[3];
                p_objGrp.DrawRectangle(m_objPen, m_rtF.X, m_rtF.Y, m_rtF.Width, m_rtF.Height);
                p_objGrp.DrawString(m_objAYQContent.m_strReaction, m_fontInBody, m_objBrush, m_rtF, m_strFormat);
                // 进食
                m_rtF.X = m_floatColLeftX[4];
                m_rtF.Width = m_floatColWidth[4];
                p_objGrp.DrawRectangle(m_objPen, m_rtF.X, m_rtF.Y, m_rtF.Width, m_rtF.Height);
                p_objGrp.DrawString(m_objAYQContent.m_strTakeFood, m_fontInBody, m_objBrush, m_rtF, m_strFormat);
                // 腋湿
                m_rtF.X = m_floatColLeftX[5];
                m_rtF.Width = m_floatColWidth[5];
                p_objGrp.DrawRectangle(m_objPen, m_rtF.X, m_rtF.Y, m_rtF.Width, m_rtF.Height);
                p_objGrp.DrawString(m_objAYQContent.m_strArmpitWet, m_fontInBody, m_objBrush, m_rtF, m_strFormat);
                // 皮肤
                m_rtF.X = m_floatColLeftX[6];
                m_rtF.Width = m_floatColWidth[6];
                p_objGrp.DrawRectangle(m_objPen, m_rtF.X, m_rtF.Y, m_rtF.Width, m_rtF.Height);
                p_objGrp.DrawString(m_objAYQContent.m_strDerm, m_fontInBody, m_objBrush, m_rtF, m_strFormat);
                // 黄疸
                m_rtF.X = m_floatColLeftX[7];
                m_rtF.Width = m_floatColWidth[7];
                p_objGrp.DrawRectangle(m_objPen, m_rtF.X, m_rtF.Y, m_rtF.Width, m_rtF.Height);
                p_objGrp.DrawString(m_objAYQContent.m_strAurigo, m_fontInBody, m_objBrush, m_rtF, m_strFormat);
                // 脐部
                m_rtF.X = m_floatColLeftX[8];
                m_rtF.Width = m_floatColWidth[8];
                p_objGrp.DrawRectangle(m_objPen, m_rtF.X, m_rtF.Y, m_rtF.Width, m_rtF.Height);
                p_objGrp.DrawString(m_objAYQContent.m_strUmbilicalRegion, m_fontInBody, m_objBrush, m_rtF, m_strFormat);
                // 四肢活动
                m_rtF.X = m_floatColLeftX[9];
                m_rtF.Width = m_floatColWidth[9];
                p_objGrp.DrawRectangle(m_objPen, m_rtF.X, m_rtF.Y, m_rtF.Width, m_rtF.Height);
                p_objGrp.DrawString(m_objAYQContent.m_strLimbActivity, m_fontInBody, m_objBrush, m_rtF, m_strFormat);
                // 大便
                m_rtF.X = m_floatColLeftX[10];
                m_rtF.Width = m_floatColWidth[10];
                p_objGrp.DrawRectangle(m_objPen, m_rtF.X, m_rtF.Y, m_rtF.Width, m_rtF.Height);
                p_objGrp.DrawString(m_objAYQContent.m_strStool, m_fontInBody, m_objBrush, m_rtF, m_strFormat);
                // 小便
                m_rtF.X = m_floatColLeftX[11];
                m_rtF.Width = m_floatColWidth[11];
                p_objGrp.DrawRectangle(m_objPen, m_rtF.X, m_rtF.Y, m_rtF.Width, m_rtF.Height);
                p_objGrp.DrawString(m_objAYQContent.m_strUrine, m_fontInBody, m_objBrush, m_rtF, m_strFormat);
                // 签名
                m_rtF.X = m_floatColLeftX[12];
                m_rtF.Width = m_floatColWidth[12];
                p_objGrp.DrawRectangle(m_objPen, m_rtF.X, m_rtF.Y, m_rtF.Width, m_rtF.Height);
                p_objGrp.DrawString(m_objAYQContent.m_strRecordSign, m_fontInBody, m_objBrush, m_rtF, m_strFormat);

                m_intPosY += m_intRowHeight;

            }
            #endregion

            if (m_intRowCount < 8)
            {
                for (; m_intRowCount < 8; m_intRowCount++)
                {
                    for (int i = 0; i < m_floatColLeftX.Length; i++)
                    {
                        p_objGrp.DrawRectangle(m_objPen, m_floatColLeftX[i], m_intPosY, m_floatColWidth[i], m_intRowHeight);
                    }
                    m_intPosY += m_intRowHeight;
                }
            }

        }

        #endregion

        #region 爱婴区婴儿评估表-特殊记录
        /// <summary>
        /// 爱婴区婴儿评估表-特殊记录
        /// </summary>
        /// <param name="e"></param>
        private void m_mthPrintAYQBabyEspRecord(PrintPageEventArgs e)
        {
            System.Drawing.Graphics p_objGrp = e.Graphics;
            com.digitalwave.controls.clsPrintRichTextContext m_objPrintContext = new com.digitalwave.controls.clsPrintRichTextContext(Color.Black, m_fontBody);

            RectangleF m_rtgF = new RectangleF((float)m_objPrintSize.LeftX + 20, m_intPosY, m_intPrintWidth, m_intRowHeight);

            // 打印格式
            StringFormat m_strFormat = new StringFormat();
            m_strFormat.LineAlignment = StringAlignment.Center;
            m_strFormat.Alignment = StringAlignment.Near;

            p_objGrp.DrawString("特殊记录", m_fontBody, m_objBrush, m_rtgF, m_strFormat);
            m_intPosY += m_intRowHeight;

            if (m_objPrintMainInfo == null || m_objPrintMainInfo.m_objAYQEspRecord == null)
                return;

            m_objPrintContext.m_mthSetContextWithCorrectBefore(m_objPrintMainInfo.m_objAYQEspRecord.m_strEspRecord, m_objPrintMainInfo.m_objAYQEspRecord.m_strEspRecordXML, DateTime.Now);

            
            int m_intRealHeight = m_objPrintContext.m_intMeasureBlockHeightBySimSun(m_fontBody.Size, m_intPrintWidth - 50, p_objGrp);

            if (m_intPosY + m_intRealHeight > m_intPrintHeight + (int)m_objPrintSize.TopY)
            {
                e.HasMorePages = true;
                // 打印页脚
                m_mthPrintFoot(e);
                return;
            }

            Rectangle m_rtg = new Rectangle((int)m_objPrintSize.LeftX + 50, m_intPosY, m_intPrintWidth - 50, m_intRowHeight);
            m_objPrintContext.m_blnPrintAllBySimSun(m_fontBody.Size, m_rtg, p_objGrp, out m_intRealHeight, false);

            if (m_intRealHeight > m_intRowHeight)
                m_intPosY += m_intRealHeight;
            else
                m_intPosY += m_intRowHeight;

            // 打印页脚
            m_mthPrintFoot(e);

            m_strFormat.Dispose();

            e.HasMorePages = false;
        }
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
            RectangleF m_rtf = new RectangleF((float)m_objPrintSize.LeftX, e.PageBounds.Height - (int)m_objPrintSize.BottomY + m_intRowHeight, m_intPrintWidth, m_intRowHeight);
            g.DrawString("第 " + m_intCurrentPageIndex.ToString() + " 页", m_fontBody, m_objBrush, m_rtf, m_sf);
        }
        #endregion




        #region infPrintRecord 成员

        public void m_mthSetPrintInfo(clsPatient p_objPatient, DateTime p_dtmInPatientDate, DateTime p_dtmOpenDate)
        {
            if (m_objPrintMainInfo == null)
                m_objPrintMainInfo = new clsPrintInfo_clsAYQBabyAssessmentRecord();

            m_objPrintMainInfo.m_strHISInPatientID = p_objPatient.m_StrHISInPatientID;
            m_objPrintMainInfo.m_strInPatentID = p_objPatient.m_StrInPatientID;
            m_objPrintMainInfo.m_strPatientName = p_objPatient.m_StrName;
            m_objPrintMainInfo.m_dtmHISInPatientDate = p_dtmInPatientDate;
            m_objPrintMainInfo.m_strAge = p_objPatient.m_ObjPeopleInfo.m_StrAge;
            m_objPrintMainInfo.m_strSex = p_objPatient.m_StrSex;
            m_objPrintMainInfo.m_strBedName = p_objPatient.m_strBedCode;
            m_objPrintMainInfo.m_dtmOpenDate = p_dtmOpenDate;
        }

        public void m_mthInitPrintContent()
        {
            if (m_blnIsFromDataSource)
            {
                clsAYQBabyAssessmentContentDomain objServ = new clsAYQBabyAssessmentContentDomain();

                clsAYQBabyAssessmentContent[] m_objAYQContent = null;
                if (objServ.m_lngGetAllCircsRecordContent(m_objPrintMainInfo.m_strHISInPatientID, m_objPrintMainInfo.m_dtmHISInPatientDate.ToString("yyyy-MM-dd hh:mm:ss"), out m_objAYQContent) > 0)
                    if (m_objAYQContent != null)
                        m_objPrintMainInfo.m_objAYQBabyContent = m_objAYQContent;



                clsTransDataInfo[] m_objTempArr = null;
                if (m_objServ.m_lngGetTransDataInfoArr(m_objPatient.m_StrRegisterId, out m_objTempArr) > 0 && m_objTempArr != null && m_objTempArr.Length > 0)
                {
                    m_objPrintMainInfo = m_objTempArr[0] as clsEMR_OXTIntravenousDripDataInfo;
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

        public void m_mthSetPrintContent(object p_objPrintContent)
        {
            
        }

        public object m_objGetPrintInfo()
        {
            return null;
        }

        public void m_mthInitPrintTool(object p_objArg)
        {
            
        }

        public void m_mthDisposePrintTools(object p_objArg)
        {
            
        }

        public void m_mthBeginPrint(object p_objPrintArg)
        {
            
        }

        public void m_mthPrintPage(object p_objPrintArg)
        {
            PrintPageEventArgs e = (PrintPageEventArgs)p_objPrintArg;

            // 初始化打印变量
            m_mthInitPrintInfo(e);
            // 打印标题
            m_mthPrintTitle(e);
            // 爱婴区婴儿评估记录
            m_mthPrintAYQBabyConnect(e);
            // 爱婴区婴儿评估表-特殊记录
            m_mthPrintAYQBabyEspRecord(e);
            
        }

        public void m_mthEndPrint(object p_objPrintArg)
        {
            
        }

        #endregion
    }
}
