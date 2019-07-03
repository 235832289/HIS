using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Drawing.Printing;
using System.Drawing;
using iCareData;
using com.digitalwave.DiseaseTrackService;

namespace iCare
{
    /// <summary>
    /// 通用ICU护理记录打印工具类
    /// </summary>
    public class clsICUNurseRecordPrintTool : infPrintRecord
    {
        #region 全局变量
        private clsPrintInfo_ICUNurseRecord m_objPrintInfo = null;
        private DataSet ds = null;
        private DataTable m_dtbTable0 = null;
        private DataTable m_dtbTable1 = null;
        private DataTable m_dtbTable2 = null;
        private DataTable m_dtbTable3 = null;
        /// <summary>
        /// 第一页当前打印行数
        /// </summary>
        private int m_intCurrentLine1 = 0;
        /// <summary>
        /// 第二页当前打印行数
        /// </summary>
        private int m_intCurrentLine2 = 0;
        /// <summary>
        /// 第三页当前打印行数
        /// </summary>
        private int m_intCurrentLine3 = 0;
        /// <summary>
        /// 第四页当前打印行数
        /// </summary>
        private int m_intCurrentLine4 = 0;
        /// <summary>
        /// 第五页当前打印行数
        /// </summary>
        private int m_intCurrentLine5 = 0;
        /// <summary>
        /// 剩余行数
        /// </summary>
        private int m_intAllLines = 0;
        /// <summary>
        /// 记录某条记录在当页所在行
        /// </summary>
        private Hashtable m_hstDateTimeLine = new Hashtable();
        /// <summary>
        /// 第一页内容是否全部打印完
        /// </summary>
        private bool blnIsEnd1 = false;
        /// <summary>
        /// 第二页内容是否全部打印完
        /// </summary>
        private bool blnIsEnd2 = false;
        /// <summary>
        /// 第三页内容是否全部打印完
        /// </summary>
        private bool blnIsEnd3 = false;
        /// <summary>
        /// 第四页内容是否全部打印完
        /// </summary>
        private bool blnIsEnd4 = false;
        /// <summary>
        /// 第五页内容是否全部打印完
        /// </summary>
        private bool blnIsEnd5 = false;
        #endregion

        #region 设置打印信息(当从数据库读取时要首先调用.
        /// <summary>
        /// 设置打印信息(当从数据库读取时要首先调用.)
        /// </summary>
        /// <param name="p_objPatient">病人</param>
        /// <param name="p_dtmInPatientDate">入院日期</param>
        /// <param 	name="p_dtmOpenDate">OpenDate，如果是一次打印多次记录表单的类型（如病案记录），忽略OpenDate</param>
        public void m_mthSetPrintInfo(clsPatient p_objPatient, DateTime p_dtmInPatientDate, DateTime p_dtmOpenDate)
        {
            clsPatient m_objPatient = p_objPatient;
            m_objPrintInfo = new clsPrintInfo_ICUNurseRecord();
            m_objPrintInfo.m_strInPatentID = m_objPatient != null ? m_objPatient.m_StrInPatientID : "";
            m_objPrintInfo.m_strPatientName = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrFirstName : "";
            m_objPrintInfo.m_strSex = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrSex : "";
            m_objPrintInfo.m_strAge = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrAge : "";
            m_objPrintInfo.m_strBedName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName : "";
            m_objPrintInfo.m_strDeptName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjDept.m_StrDeptName : "";
            m_objPrintInfo.m_strAreaName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjLastArea.m_ObjArea.m_StrAreaName : "";
            m_objPrintInfo.m_dtmInPatientDate = p_dtmInPatientDate;
            m_objPrintInfo.m_dtmOpenDate = p_dtmOpenDate;
            m_objPrintInfo.m_strHISInPatientID = m_objPatient != null ? m_objPatient.m_StrHISInPatientID : "";
            m_objPrintInfo.m_dtmHISInDate = m_objPatient != null ? m_objPatient.m_DtmSelectedHISInDate : DateTime.MinValue;
            m_objPrintInfo.m_strRegisterID = m_objPatient != null ? m_objPatient.m_StrRegisterId : "";
            //从主表中获取所有没删除的数据
            //m_blnIsFromDataSource = true;//表明是从数据库读取	

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
            ds = p_objPrintContent as DataSet;
            m_mthIniDataTable(ds);
        }

        /// <summary>
        /// 初始化各数据表
        /// </summary>
        /// <param name="p_dsSource"></param>
        private void m_mthIniDataTable(DataSet p_dsSource)
        {
            if (p_dsSource != null && p_dsSource.Tables.Count >= 4)
            {
                m_dtbTable0 = p_dsSource.Tables[0];
                m_dtbTable1 = p_dsSource.Tables[1];
                m_dtbTable2 = p_dsSource.Tables[2];
                m_dtbTable3 = p_dsSource.Tables[3];
                m_intAllLines = m_dtbTable0.Rows.Count;
                if (m_dtbTable0.Rows.Count > 0)
                {
                    m_dtbTable0.DefaultView.Sort = "记录时间 asc";
                    m_mthAddDataToPrintInfo(Convert.ToDateTime(m_dtbTable0.Rows[0][0]), m_dtbTable3);
                }               
            }
        }

        /// <summary>
        /// 添加PrintInfo必要数据
        /// </summary>
        /// <param name="p_dtbInfo"></param>
        private void m_mthAddDataToPrintInfo(DateTime p_dtmRecordDate,DataTable p_dtbInfo)
        {
            if (p_dtbInfo != null && p_dtbInfo.Rows.Count > 0)
            {
                //预设值
                m_objPrintInfo.m_dtmRecordDate = p_dtmRecordDate;
                m_objPrintInfo.m_strWeight = p_dtbInfo.Rows[0][2].ToString();
                m_objPrintInfo.m_strOPNAME = p_dtbInfo.Rows[0][3].ToString();
                m_objPrintInfo.m_strAFTEROPDAYS = p_dtbInfo.Rows[0][1].ToString();
                //液体
                m_objPrintInfo.m_strLIQUID1D = p_dtbInfo.Rows[0][4].ToString();
                m_objPrintInfo.m_strLIQUID2D = p_dtbInfo.Rows[0][5].ToString();
                m_objPrintInfo.m_strLIQUID3D = p_dtbInfo.Rows[0][6].ToString();
                m_objPrintInfo.m_strLIQUID4D = p_dtbInfo.Rows[0][7].ToString();
                m_objPrintInfo.m_strLIQUID5D = p_dtbInfo.Rows[0][8].ToString();
                //引液
                m_objPrintInfo.m_strDRAIN1D = p_dtbInfo.Rows[0][9].ToString();
                m_objPrintInfo.m_strDRAIN2D = p_dtbInfo.Rows[0][10].ToString();
                m_objPrintInfo.m_strDRAIN3D = p_dtbInfo.Rows[0][11].ToString();
                m_objPrintInfo.m_strDRAIN4D = p_dtbInfo.Rows[0][12].ToString();
                m_objPrintInfo.m_strDRAIN5D = p_dtbInfo.Rows[0][13].ToString();
            }
        }
        #endregion

        #region 获取打印内容,(当从数据库读取时,调用本函数之前请首先调用m_mthSetPrintInfo函数)
        /// <summary>
        /// 获取打印内容,(当从数据库读取时,调用本函数之前请首先调用m_mthSetPrintInfo函数)
        /// </summary>
        /// <returns>打印内容</returns>
        public object m_objGetPrintInfo()
        {
            return null;
        }
        #endregion

        #region 初始化打印变量,本例传入空对象即可.

        /// <summary>
        /// 初始化打印变量,本例传入空对象即可.
        /// </summary>
        public void m_mthInitPrintTool(object p_objArg)
        {
            #region 有关打印初始化
            m_fotTitleFont = new Font("SimSun", 15.75f, FontStyle.Bold);//宋体三号
            m_fotHeaderFont = new Font("SimSun", 10.5F);//宋体五号
            m_fotSmallFont = new Font("SimSun", 10);
            m_fotDownFont = new Font("SimSun", 6);
            m_GridPen = new Pen(Color.Black, 0.5f);
            m_slbBrush = new SolidBrush(Color.Black);
            m_objPageSetting = new clsPrintPageSettingForRecord();
            #endregion
        }

        #endregion

        #region 释放打印变量
        /// <summary>
        /// 释放打印变量
        /// </summary>
        public void m_mthDisposePrintTools(object p_objArg)
        {
            m_fotTitleFont.Dispose();
            m_fotHeaderFont.Dispose();
            m_fotSmallFont.Dispose();
            m_GridPen.Dispose();
            m_slbBrush.Dispose();
            m_fotDownFont.Dispose();
        } 
        #endregion

        #region 打印开始
        /// <summary>
        /// 打印开始
        /// </summary>
        /// <param name="p_objPrintArg">此处p_objPrintArg要求为PrintEventArgs类型的对象</param>
        public void m_mthBeginPrint(object p_objPrintArg)
        {
        } 
        #endregion

        #region 打印中
        /// <summary>
        /// 打印中
        /// </summary>
        /// <param name="p_objPrintArg">此处p_objPrintArg要求为PrintPageEventArgs类型的对象</param>
        public void m_mthPrintPage(object p_objPrintArg)
        {
            frmPrintPreviewDialogPF frmPreview = new frmPrintPreviewDialogPF();
            frmPreview.m_evtBeginPrint += new PrintEventHandler(frmPreview_m_evtBeginPrint);
            frmPreview.m_evtEndPrint += new PrintEventHandler(frmPreview_m_evtEndPrint);
            frmPreview.m_evtPrintContent += new PrintPageEventHandler(frmPreview_m_evtPrintContent);
            frmPreview.m_evtPrintFrame += new PrintPageEventHandler(frmPreview_m_evtPrintFrame);
            frmPreview.ShowDialog();
        } 
        #endregion

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
            m_mthAddDataToGrid(e);
        }
        private void frmPreview_m_evtPrintFrame(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            m_mthPrintTitleInfo(e);
            m_mthPrintRectangleInfo(e);
        }
        #endregion

        #region 打印结束
        /// <summary>
        /// 打印结束。一般使用它来更新数据库信息。
        /// </summary>
        /// <param name="p_objPrintArg">此处p_objPrintArg要求为PrintEventArgs类型的对象</param>
        public void m_mthEndPrint(object p_objPrintArg)
        {
            m_intLines = 0;
            m_intPages = 1;
            //如果打印成功，查找有无需要更新的时间，如果有，更新时间。 
            if (!((PrintEventArgs)p_objPrintArg).Cancel)
            {
                if (m_objPrintInfo != null)
                {
                    clsICUNurseService objServ =
                (clsICUNurseService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsICUNurseService));

                    objServ.m_lngUpdateFirstPrintDate(m_objPrintInfo.m_strRegisterID);
                }
            }
        } 
        #endregion

        #region 缺省不做任何动作
        private void m_mthBeginPrintSub(PrintEventArgs p_objPrintArg)
        {
            //缺省不做任何动作
        } 
        #endregion

        #region 打印页
        // 打印页
        private void m_mthPrintPageSub(PrintPageEventArgs e)
        {
        } 
        #endregion

        #region 打印

        #region 有关打印的声明
        /// <summary>
        /// 标题的字体
        /// </summary>
        private Font m_fotTitleFont;
        /// <summary>
        /// 表头的字体
        /// </summary>
        private Font m_fotHeaderFont;
        /// <summary>
        /// 表内容的字体
        /// </summary>
        private Font m_fotSmallFont;
        /// <summary>
        /// 下标
        /// </summary>
        private Font m_fotDownFont;
        /// <summary>
        /// 边框画笔
        /// </summary>
        private Pen m_GridPen;
        /// <summary>
        /// 刷子
        /// </summary>
        private SolidBrush m_slbBrush;
        /// <summary>
        /// 当前页码
        /// </summary>
        private int m_intPages = 1;
        private int m_intLines = 0;
        private int m_intLineStep = 135;
        private string m_strDateFormat = "yyyy-MM-dd HH:mm";

        /// <summary>
        /// 打印元素
        /// </summary>
        private enum enmItemDefination
        {
            //基本元素
            InPatientID_Title,
            InPatientID,
            Name_Title,
            Name,
            Sex_Title,
            Sex,
            Age_Title,
            Age,
            Dept_Name_Title,
            Dept_Name,
            BedNo_Title,
            BedNo,

            Page_HospitalName,
            Page_Name_Title,
            Page_Title,
            Page_Num,
            Page_Of,
            Page_Count,

            Print_Date_Title,
            Print_Date,
            //填充表格元素
            RecordDate,
            RecordTime,
            RecordContent,
            RecordSign1,
            RecordSign2
        }
        /// <summary>
        /// 获取坐标的类
        /// </summary>
        private clsPrintPageSettingForRecord m_objPageSetting;
        #endregion 

        #region 定义打印各元素的坐标点
        protected class clsPrintPageSettingForRecord
        {
            public clsPrintPageSettingForRecord() { }

            /// <summary>
            /// 获得坐标点
            /// </summary>
            /// <param name="p_intItemName">项目名称</param>
            /// <returns></returns>
            public PointF m_getCoordinatePoint(int p_intItemName)
            {
                float fltOffsetX = 20;//X的偏移量
                PointF m_fReturnPoint;
                switch (p_intItemName)
                {

                    case (int)enmItemDefination.Page_HospitalName:
                        m_fReturnPoint = new PointF(340f - fltOffsetX, 40f);
                        break;
                    case (int)enmItemDefination.Page_Name_Title:
                        m_fReturnPoint = new PointF(360f - fltOffsetX, 70f);
                        break;
                    case (int)enmItemDefination.Name_Title:
                        m_fReturnPoint = new PointF(60f - fltOffsetX, 105f);
                        break;
                    case (int)enmItemDefination.Name:
                        m_fReturnPoint = new PointF(100f - fltOffsetX, 105f);
                        break;

                    case (int)enmItemDefination.Sex_Title:
                        m_fReturnPoint = new PointF(175f - fltOffsetX, 105f);
                        break;
                    case (int)enmItemDefination.Sex:
                        m_fReturnPoint = new PointF(220f - fltOffsetX, 105f);
                        break;

                    case (int)enmItemDefination.Age_Title:
                        m_fReturnPoint = new PointF(250f - fltOffsetX, 105f);
                        break;
                    case (int)enmItemDefination.Age:
                        m_fReturnPoint = new PointF(295f - fltOffsetX, 105f);
                        break;

                    case (int)enmItemDefination.Dept_Name_Title:
                        m_fReturnPoint = new PointF(365f, 105f);
                        break;
                    case (int)enmItemDefination.Dept_Name:
                        m_fReturnPoint = new PointF(415f, 105f);
                        break;

                    case (int)enmItemDefination.BedNo_Title:
                        m_fReturnPoint = new PointF(565f, 105f);
                        break;
                    case (int)enmItemDefination.BedNo:
                        m_fReturnPoint = new PointF(610f, 105f);
                        break;

                    case (int)enmItemDefination.InPatientID_Title:
                        m_fReturnPoint = new PointF(655f - fltOffsetX, 105f);
                        break;
                    case (int)enmItemDefination.InPatientID:
                        m_fReturnPoint = new PointF(720f - fltOffsetX, 105f);
                        break;

                    default:
                        m_fReturnPoint = new PointF(405f, 400f);
                        break;

                }
                return m_fReturnPoint;
            }
        }

        /// <summary>
        /// 格子的信息
        /// </summary>
        private enum enmRectangleInfo
        {
            /// <summary>
            /// 格子的顶端
            /// </summary>
            TopY = 130,
            ///<summary>
            /// 格子的左端
            /// </summary>
            LeftX = 40,
            /// <summary>
            /// 格子的右端
            /// </summary>
            RightX = 820 - 33,
            /// <summary>
            /// 格子每行的步长
            /// </summary>
            RowStep = 25,

            BottomY = 1034
        }
        #endregion

        #region 标题文字部分
        /// <summary>
        /// 标题文字部分
        /// </summary>
        /// <param name="e"></param>
        private void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, m_fotHeaderFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_HospitalName));

            e.Graphics.DrawString("ICU护理记录", m_fotTitleFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_Name_Title));


            e.Graphics.DrawString("姓名:", m_fotHeaderFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name_Title));
            e.Graphics.DrawString(m_objPrintInfo.m_strPatientName, m_fotHeaderFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name));

            e.Graphics.DrawString("性别:", m_fotHeaderFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex_Title));
            e.Graphics.DrawString(m_objPrintInfo.m_strSex, m_fotHeaderFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex));

            e.Graphics.DrawString("年龄:", m_fotHeaderFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age_Title));
            e.Graphics.DrawString(m_objPrintInfo.m_strAge, m_fotHeaderFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age));

            e.Graphics.DrawString("科室:", m_fotHeaderFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name_Title));
            e.Graphics.DrawString(m_objPrintInfo.m_strDeptName, m_fotHeaderFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name));

            e.Graphics.DrawString("床号:", m_fotHeaderFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNo_Title));
            e.Graphics.DrawString(m_objPrintInfo.m_strBedName, m_fotHeaderFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNo));

            e.Graphics.DrawString("住院号:", m_fotHeaderFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID_Title));
            e.Graphics.DrawString(m_objPrintInfo.m_strHISInPatientID, m_fotHeaderFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID));
        }
        #endregion 

        #region 框架部分
        private void m_mthPrintRectangleInfo(PrintPageEventArgs e)
        {
            int intYPos = 125;
            int intXPos = (int)enmRectangleInfo.LeftX;
            //表格X轴方向长度为747
            e.Graphics.DrawString("体重 " + (m_objPrintInfo.m_strWeight ?? "  ") + " kg", m_fotHeaderFont, m_slbBrush, intXPos, intYPos);
            e.Graphics.DrawString("诊断/手术名称" + m_objPrintInfo.m_strOPNAME ?? "", m_fotHeaderFont, m_slbBrush, intXPos + 100, intYPos);
            e.Graphics.DrawString("日期" + (m_objPrintInfo.m_dtmRecordDate == DateTime.MinValue ? "    年  月  日" : m_objPrintInfo.m_dtmRecordDate.ToString("yyyy年MM月dd日")), m_fotHeaderFont, m_slbBrush, intXPos + 460, intYPos);
            e.Graphics.DrawString("术后/入ICU第 " + m_objPrintInfo.m_strAFTEROPDAYS + " 天", m_fotHeaderFont, m_slbBrush, intXPos + 610, intYPos);

            if ((m_intPages - 1) % 5 == 0)//整套表单第一页
            {
                intYPos += 20;
                e.Graphics.DrawLine(m_GridPen, (int)enmRectangleInfo.LeftX, intYPos, (int)enmRectangleInfo.RightX, intYPos);
                e.Graphics.DrawLine(m_GridPen, (int)enmRectangleInfo.LeftX, intYPos, (int)enmRectangleInfo.LeftX, (int)enmRectangleInfo.BottomY + 10);
                e.Graphics.DrawString("时间", m_fotSmallFont, m_slbBrush, intXPos + 5, intYPos + 2);
                intXPos += 50;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 10);
                e.Graphics.DrawString("体温", m_fotSmallFont, m_slbBrush, new RectangleF(intXPos + 8, intYPos + 2, 25f, 60f));
                intXPos += 35;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 10);
                e.Graphics.DrawString("末稍温", m_fotSmallFont, m_slbBrush, new RectangleF(intXPos + 8, intYPos + 2, 25f, 60f));
                intXPos += 35;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 10);
                e.Graphics.DrawString("心率", m_fotSmallFont, m_slbBrush, new RectangleF(intXPos + 8, intYPos + 2, 25f, 60f));
                intXPos += 35;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 10);
                e.Graphics.DrawString("心律", m_fotSmallFont, m_slbBrush, new RectangleF(intXPos + 8, intYPos + 2, 25f, 60f));
                intXPos += 35;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 10);
                e.Graphics.DrawString("呼吸", m_fotSmallFont, m_slbBrush, new RectangleF(intXPos + 8, intYPos + 2, 25f, 60f));
                intXPos += 34;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 10);
                e.Graphics.DrawString("血压" + System.Environment.NewLine + "S/D", m_fotSmallFont, m_slbBrush, intXPos + 15, intYPos + 2);
                intXPos += 70;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 10);
                e.Graphics.DrawString("ABP", m_fotSmallFont, m_slbBrush, intXPos + 6, intYPos + 2);
                intXPos += 35;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 10);
                e.Graphics.DrawString("CVP", m_fotSmallFont, m_slbBrush, intXPos + 6, intYPos + 2);
                intXPos += 35;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 10);
                e.Graphics.DrawString("SpO" + System.Environment.NewLine + "(%)", m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                e.Graphics.DrawString("2", m_fotDownFont, m_slbBrush, intXPos + 25, intYPos + 8);
                intXPos += 35;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 10);
                e.Graphics.DrawString("意识", m_fotSmallFont, m_slbBrush, new RectangleF(intXPos + 8, intYPos + 2, 25f, 60f));
                intXPos += 35;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 10);
                e.Graphics.DrawString("瞳孔" + System.Environment.NewLine + "(mm)" + System.Environment.NewLine + "左/右", m_fotSmallFont, m_slbBrush, intXPos + 1, intYPos + 2);
                intXPos += 36;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 10);
                e.Graphics.DrawString("对光反射" + System.Environment.NewLine + "  左/右", m_fotSmallFont, m_slbBrush, intXPos + 8, intYPos + 2);
                intXPos += 80;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 10);
                e.Graphics.DrawString("血管活性药物" + System.Environment.NewLine + "ug/kg/min", m_fotSmallFont, m_slbBrush, intXPos + 8, intYPos + 2);
                intXPos += 97;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 10);
                e.Graphics.DrawString("强心利尿药" + System.Environment.NewLine + "及其它特殊" + System.Environment.NewLine + "药物", m_fotSmallFont, m_slbBrush, intXPos + 10, intYPos + 2);
                intXPos += 100;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 10);

                intYPos += 59;
                e.Graphics.DrawLine(m_GridPen, (int)enmRectangleInfo.LeftX, intYPos, (int)enmRectangleInfo.RightX, intYPos);
                for (int i = 0; i < 40; i++)
                {
                    intYPos += 21;
                    e.Graphics.DrawLine(m_GridPen, (int)enmRectangleInfo.LeftX, intYPos, (int)enmRectangleInfo.RightX, intYPos);
                }
                m_intPages++;
            }
            else if ((m_intPages - 2) % 5 == 0)//整套表单第二页
            {
                intYPos += 20;
                e.Graphics.DrawString("液体设定:", m_fotHeaderFont, m_slbBrush, intXPos, intYPos);
                e.Graphics.DrawString("1." + (m_objPrintInfo.m_strLIQUID1D ?? ""), m_fotHeaderFont, m_slbBrush, intXPos + 80, intYPos);
                e.Graphics.DrawString("2." + (m_objPrintInfo.m_strLIQUID2D ?? ""), m_fotHeaderFont, m_slbBrush, intXPos + 200, intYPos);
                e.Graphics.DrawString("3." + (m_objPrintInfo.m_strLIQUID3D ?? ""), m_fotHeaderFont, m_slbBrush, intXPos + 320, intYPos);
                e.Graphics.DrawString("4." + (m_objPrintInfo.m_strLIQUID4D ?? ""), m_fotHeaderFont, m_slbBrush, intXPos + 440, intYPos);
                e.Graphics.DrawString("5." + (m_objPrintInfo.m_strLIQUID5D ?? ""), m_fotHeaderFont, m_slbBrush, intXPos + 560, intYPos);
                intYPos += 20;
                e.Graphics.DrawString("引流设定:", m_fotHeaderFont, m_slbBrush, intXPos, intYPos);
                e.Graphics.DrawString("1." + (m_objPrintInfo.m_strDRAIN1D ?? ""), m_fotHeaderFont, m_slbBrush, intXPos + 80, intYPos);
                e.Graphics.DrawString("2." + (m_objPrintInfo.m_strDRAIN2D ?? ""), m_fotHeaderFont, m_slbBrush, intXPos + 200, intYPos);
                e.Graphics.DrawString("3." + (m_objPrintInfo.m_strDRAIN3D ?? ""), m_fotHeaderFont, m_slbBrush, intXPos + 320, intYPos);
                e.Graphics.DrawString("4." + (m_objPrintInfo.m_strDRAIN4D ?? ""), m_fotHeaderFont, m_slbBrush, intXPos + 440, intYPos);
                e.Graphics.DrawString("5." + (m_objPrintInfo.m_strDRAIN5D ?? ""), m_fotHeaderFont, m_slbBrush, intXPos + 560, intYPos);
                intYPos += 20;
                e.Graphics.DrawLine(m_GridPen, (int)enmRectangleInfo.LeftX, intYPos, (int)enmRectangleInfo.RightX, intYPos);
                e.Graphics.DrawLine(m_GridPen, (int)enmRectangleInfo.LeftX, intYPos, (int)enmRectangleInfo.LeftX, (int)enmRectangleInfo.BottomY + 50);
                e.Graphics.DrawString("时间", m_fotSmallFont, m_slbBrush, intXPos + 5, intYPos + 2);
                intXPos += 50;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 50);
                e.Graphics.DrawString("1", m_fotSmallFont, m_slbBrush, intXPos + 12, intYPos + 22);
                intXPos += 30;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos + 20, intXPos, (int)enmRectangleInfo.BottomY + 50);
                e.Graphics.DrawString("2", m_fotSmallFont, m_slbBrush, intXPos + 12, intYPos + 22);
                intXPos += 30;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos + 20, intXPos, (int)enmRectangleInfo.BottomY + 50);
                e.Graphics.DrawString("3", m_fotSmallFont, m_slbBrush, intXPos + 12, intYPos + 22);
                intXPos += 30;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos + 20, intXPos, (int)enmRectangleInfo.BottomY + 50);
                e.Graphics.DrawString("4", m_fotSmallFont, m_slbBrush, intXPos + 12, intYPos + 22);
                e.Graphics.DrawString("现时入量", m_fotSmallFont, m_slbBrush, intXPos + 20, intYPos + 2);
                intXPos += 30;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos + 20, intXPos, (int)enmRectangleInfo.BottomY + 50);
                e.Graphics.DrawString("5", m_fotSmallFont, m_slbBrush, intXPos + 12, intYPos + 22);
                intXPos += 30;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos + 20, intXPos, (int)enmRectangleInfo.BottomY + 50);
                e.Graphics.DrawString("全血/" + System.Environment.NewLine + "血浆", m_fotSmallFont, m_slbBrush, intXPos + 12, intYPos + 22);
                intXPos += 65;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos + 20, intXPos, (int)enmRectangleInfo.BottomY + 50);
                e.Graphics.DrawString("鼻饲/" + System.Environment.NewLine + "进饲", m_fotSmallFont, m_slbBrush, intXPos + 12, intYPos + 22);
                intXPos += 65;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 50);
                e.Graphics.DrawString("每" + System.Environment.NewLine + "时", m_fotSmallFont, m_slbBrush, intXPos + 12, intYPos + 22);
                e.Graphics.DrawString("入量累计", m_fotSmallFont, m_slbBrush, intXPos + 8, intYPos + 2);
                intXPos += 35;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos + 20, intXPos, (int)enmRectangleInfo.BottomY + 50);
                e.Graphics.DrawString("总" + System.Environment.NewLine + "量", m_fotSmallFont, m_slbBrush, intXPos + 12, intYPos + 22);
                intXPos += 36;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 50);
                e.Graphics.DrawString("大" + System.Environment.NewLine + "便", m_fotSmallFont, m_slbBrush, intXPos + 12, intYPos + 22);
                intXPos += 30;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos + 20, intXPos, (int)enmRectangleInfo.BottomY + 50);
                e.Graphics.DrawString("累" + System.Environment.NewLine + "计", m_fotSmallFont, m_slbBrush, intXPos + 12, intYPos + 22);
                intXPos += 30;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos + 20, intXPos, (int)enmRectangleInfo.BottomY + 50);
                e.Graphics.DrawString("小" + System.Environment.NewLine + "便", m_fotSmallFont, m_slbBrush, intXPos + 12, intYPos + 22);
                intXPos += 30;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos + 20, intXPos, (int)enmRectangleInfo.BottomY + 50);
                e.Graphics.DrawString("现时出量", m_fotSmallFont, m_slbBrush, intXPos + 12, intYPos + 2);
                e.Graphics.DrawString("累" + System.Environment.NewLine + "计", m_fotSmallFont, m_slbBrush, intXPos + 12, intYPos + 22);
                intXPos += 35;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos + 20, intXPos, (int)enmRectangleInfo.BottomY + 50);
                e.Graphics.DrawString("1", m_fotSmallFont, m_slbBrush, intXPos + 12, intYPos + 22);
                intXPos += 30;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos + 20, intXPos, (int)enmRectangleInfo.BottomY + 50);
                e.Graphics.DrawString("2", m_fotSmallFont, m_slbBrush, intXPos + 12, intYPos + 22);
                intXPos += 30;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos + 20, intXPos, (int)enmRectangleInfo.BottomY + 50);
                e.Graphics.DrawString("3", m_fotSmallFont, m_slbBrush, intXPos + 12, intYPos + 22);
                intXPos += 30;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos + 20, intXPos, (int)enmRectangleInfo.BottomY + 50);
                e.Graphics.DrawString("4", m_fotSmallFont, m_slbBrush, intXPos + 12, intYPos + 22);
                intXPos += 30;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos + 20, intXPos, (int)enmRectangleInfo.BottomY + 50);
                e.Graphics.DrawString("5", m_fotSmallFont, m_slbBrush, intXPos + 12, intYPos + 22);
                intXPos += 30;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 50);
                e.Graphics.DrawString("出量累计", m_fotSmallFont, m_slbBrush, intXPos + 8, intYPos + 2);
                e.Graphics.DrawString("每" + System.Environment.NewLine + "时", m_fotSmallFont, m_slbBrush, intXPos + 12, intYPos + 22);
                intXPos += 35;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos + 20, intXPos, (int)enmRectangleInfo.BottomY + 50);
                e.Graphics.DrawString("总" + System.Environment.NewLine + "量", m_fotSmallFont, m_slbBrush, intXPos + 12, intYPos + 22);
                intXPos += 36;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 50);

                intYPos += 20;
                e.Graphics.DrawLine(m_GridPen, (int)enmRectangleInfo.LeftX + 50, intYPos, (int)enmRectangleInfo.RightX, intYPos);
                intYPos += 39;
                e.Graphics.DrawLine(m_GridPen, (int)enmRectangleInfo.LeftX, intYPos, (int)enmRectangleInfo.RightX, intYPos);
                for (int i = 0; i < 40; i++)
                {
                    intYPos += 21;
                    e.Graphics.DrawLine(m_GridPen, (int)enmRectangleInfo.LeftX, intYPos, (int)enmRectangleInfo.RightX, intYPos);
                }
                m_intPages++;
            }
            else if ((m_intPages - 3) % 5 == 0)//整套表单第三页
            {
                intYPos += 20;
                e.Graphics.DrawLine(m_GridPen, (int)enmRectangleInfo.LeftX, intYPos, (int)enmRectangleInfo.RightX, intYPos);
                e.Graphics.DrawLine(m_GridPen, (int)enmRectangleInfo.LeftX, intYPos, (int)enmRectangleInfo.LeftX, (int)enmRectangleInfo.BottomY + 31);
                e.Graphics.DrawString("时间", m_fotSmallFont, m_slbBrush, intXPos + 5, intYPos + 2);
                intXPos += 50;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 31);
                e.Graphics.DrawString("体位", m_fotSmallFont, m_slbBrush, intXPos + 10, intYPos + 2);
                intXPos += 60;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 31);
                e.Graphics.DrawString("皮肤", m_fotSmallFont, m_slbBrush, intXPos + 5, intYPos + 2);
                intXPos += 50;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 31);
                e.Graphics.DrawString("痰色/量", m_fotSmallFont, m_slbBrush, intXPos + 15, intYPos + 2);
                intXPos += 72;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 31);
                e.Graphics.DrawString("吸" + System.Environment.NewLine + "痰", m_fotSmallFont, m_slbBrush, intXPos + 10, intYPos + 2);
                intXPos += 40;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 31);
                e.Graphics.DrawString("体" + System.Environment.NewLine + "疗", m_fotSmallFont, m_slbBrush, intXPos + 10, intYPos + 2);
                intXPos += 40;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 31);
                e.Graphics.DrawString("口腔护理", m_fotSmallFont, m_slbBrush, new RectangleF(intXPos + 10, intYPos + 2, 20f, 80f));
                intXPos += 40;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 31);
                e.Graphics.DrawString("会阴冲洗", m_fotSmallFont, m_slbBrush, new RectangleF(intXPos + 10, intYPos + 2, 20f, 80f));
                intXPos += 40;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 31);
                e.Graphics.DrawString("擦" + System.Environment.NewLine + "浴", m_fotSmallFont, m_slbBrush, intXPos + 10, intYPos + 2);
                intXPos += 40;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 31);
                e.Graphics.DrawString("PT", m_fotSmallFont, m_slbBrush, intXPos + 15, intYPos + 2);
                intXPos += 45;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 31);
                e.Graphics.DrawString("ACT", m_fotSmallFont, m_slbBrush, intXPos + 10, intYPos + 2);
                intXPos += 45;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 31);
                e.Graphics.DrawString("glu", m_fotSmallFont, m_slbBrush, intXPos + 10, intYPos + 2);
                intXPos += 45;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 31);
                e.Graphics.DrawString("K", m_fotSmallFont, m_slbBrush, intXPos + 10, intYPos + 2);
                e.Graphics.DrawString("+", m_fotDownFont, m_slbBrush, intXPos + 20, intYPos + 2);
                intXPos += 45;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 31);
                e.Graphics.DrawString("Na", m_fotSmallFont, m_slbBrush, intXPos + 10, intYPos + 2);
                e.Graphics.DrawString("+", m_fotDownFont, m_slbBrush, intXPos + 25, intYPos + 2);
                intXPos += 45;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 31);
                e.Graphics.DrawString("CL", m_fotSmallFont, m_slbBrush, intXPos + 10, intYPos + 2);
                e.Graphics.DrawString("-", m_fotDownFont, m_slbBrush, intXPos + 25, intYPos + 2);
                intXPos += 45;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 31);
                e.Graphics.DrawString("Ca", m_fotSmallFont, m_slbBrush, intXPos + 10, intYPos + 2);
                e.Graphics.DrawString("++", m_fotDownFont, m_slbBrush, intXPos + 25, intYPos + 2);
                intXPos += 45;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 31);

                intYPos += 80;
                e.Graphics.DrawLine(m_GridPen, (int)enmRectangleInfo.LeftX, intYPos, (int)enmRectangleInfo.RightX, intYPos);
                for (int i = 0; i < 40; i++)
                {
                    intYPos += 21;
                    e.Graphics.DrawLine(m_GridPen, (int)enmRectangleInfo.LeftX, intYPos, (int)enmRectangleInfo.RightX, intYPos);
                }
                m_intPages++;
            }
            else if ((m_intPages - 4) % 5 == 0)//整套表单第四页
            {
                intYPos += 20;
                e.Graphics.DrawLine(m_GridPen, (int)enmRectangleInfo.LeftX, intYPos, (int)enmRectangleInfo.RightX, intYPos);
                e.Graphics.DrawLine(m_GridPen, (int)enmRectangleInfo.LeftX, intYPos, (int)enmRectangleInfo.LeftX, (int)enmRectangleInfo.BottomY + 35);
                e.Graphics.DrawString("时间", m_fotSmallFont, m_slbBrush, intXPos + 5, intYPos + 2);
                intXPos += 50;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 35);
                e.Graphics.DrawString("机械通气模式", m_fotSmallFont, m_slbBrush, new RectangleF(intXPos + 12, intYPos + 2, 45f, 80f));
                intXPos += 60;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 35);
                e.Graphics.DrawString("PEEP" + System.Environment.NewLine + "/Pi", m_fotSmallFont, m_slbBrush, intXPos + 12, intYPos + 22);
                intXPos += 60;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos + 20, intXPos, (int)enmRectangleInfo.BottomY + 35);
                e.Graphics.DrawString("TV" + System.Environment.NewLine + "/Ti", m_fotSmallFont, m_slbBrush, intXPos + 18, intYPos + 22);
                e.Graphics.DrawString("预设值", m_fotSmallFont, m_slbBrush, intXPos + 50, intYPos + 2);
                intXPos += 60;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos + 20, intXPos, (int)enmRectangleInfo.BottomY + 35);
                e.Graphics.DrawString("频率", m_fotSmallFont, m_slbBrush, new RectangleF(intXPos + 8, intYPos + 22, 20f, 80f));
                intXPos += 30;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos + 20, intXPos, (int)enmRectangleInfo.BottomY + 35);
                e.Graphics.DrawString("氧浓度", m_fotSmallFont, m_slbBrush, new RectangleF(intXPos + 8, intYPos + 22, 20f, 80f));
                intXPos += 30;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos + 20, intXPos, (int)enmRectangleInfo.BottomY + 35);
                e.Graphics.DrawString("灵敏度", m_fotSmallFont, m_slbBrush, new RectangleF(intXPos + 8, intYPos + 22, 20f, 80f));
                intXPos += 30;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos + 20, intXPos, (int)enmRectangleInfo.BottomY + 35);
                e.Graphics.DrawString("流速", m_fotSmallFont, m_slbBrush, new RectangleF(intXPos + 8, intYPos + 22, 20f, 80f));
                intXPos += 30;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 35);
                e.Graphics.DrawString("I : E", m_fotSmallFont, m_slbBrush, intXPos + 18, intYPos + 22);
                intXPos += 67;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos + 20, intXPos, (int)enmRectangleInfo.BottomY + 35);
                e.Graphics.DrawString("气道压力", m_fotSmallFont, m_slbBrush, new RectangleF(intXPos + 8, intYPos + 22, 20f, 80f));
                e.Graphics.DrawString("监测", m_fotSmallFont, m_slbBrush, intXPos + 12, intYPos + 2);
                intXPos += 30;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos + 20, intXPos, (int)enmRectangleInfo.BottomY + 35);
                e.Graphics.DrawString("TV", m_fotSmallFont, m_slbBrush, intXPos + 8, intYPos + 22);
                intXPos += 30;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos + 20, intXPos, (int)enmRectangleInfo.BottomY + 35);
                e.Graphics.DrawString("MV", m_fotSmallFont, m_slbBrush, intXPos + 8, intYPos + 22);
                intXPos += 30;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 35);
                e.Graphics.DrawString("插管深度", m_fotSmallFont, m_slbBrush, new RectangleF(intXPos + 8, intYPos + 2, 20f, 80f));
                intXPos += 30;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 35);
                e.Graphics.DrawString("气囊压力", m_fotSmallFont, m_slbBrush, new RectangleF(intXPos + 8, intYPos + 2, 20f, 80f));
                intXPos += 30;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 35);
                e.Graphics.DrawString("ET" + System.Environment.NewLine + "CO", m_fotSmallFont, m_slbBrush, intXPos + 6, intYPos + 2);
                e.Graphics.DrawString("2", m_fotDownFont, m_slbBrush, intXPos + 22, intYPos + 22);
                intXPos += 30;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 35);
                e.Graphics.DrawString("PH", m_fotSmallFont, m_slbBrush, intXPos + 8, intYPos + 2);
                intXPos += 30;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 35);
                e.Graphics.DrawString("PCO", m_fotSmallFont, m_slbBrush, intXPos + 1, intYPos + 2);
                e.Graphics.DrawString("2", m_fotDownFont, m_slbBrush, intXPos + 24, intYPos + 8);
                intXPos += 30;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 35);
                e.Graphics.DrawString("PaO", m_fotSmallFont, m_slbBrush, intXPos + 1, intYPos + 2);
                e.Graphics.DrawString("2", m_fotDownFont, m_slbBrush, intXPos + 24, intYPos + 8);
                intXPos += 30;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 35);
                e.Graphics.DrawString("HCO", m_fotSmallFont, m_slbBrush, intXPos + 1, intYPos + 2);
                e.Graphics.DrawString("3", m_fotDownFont, m_slbBrush, intXPos + 24, intYPos + 8);
                intXPos += 30;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 35);
                e.Graphics.DrawString("BE", m_fotSmallFont, m_slbBrush, intXPos + 8, intYPos + 2);
                intXPos += 30;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY + 35);

                intYPos += 20;
                e.Graphics.DrawLine(m_GridPen, (int)enmRectangleInfo.LeftX + 110, intYPos, (int)enmRectangleInfo.LeftX + 507, intYPos);
                intYPos += 64;
                e.Graphics.DrawLine(m_GridPen, (int)enmRectangleInfo.LeftX, intYPos, (int)enmRectangleInfo.RightX, intYPos);
                for (int i = 0; i < 40; i++)
                {
                    intYPos += 21;
                    e.Graphics.DrawLine(m_GridPen, (int)enmRectangleInfo.LeftX, intYPos, (int)enmRectangleInfo.RightX, intYPos);
                }
                m_intPages++;
            }
            else if ((m_intPages - 5) % 5 == 0)//整套表单第五页
            {
                intYPos += 20;
                e.Graphics.DrawLine(m_GridPen, (int)enmRectangleInfo.LeftX, intYPos, (int)enmRectangleInfo.RightX, intYPos);
                e.Graphics.DrawLine(m_GridPen, (int)enmRectangleInfo.LeftX, intYPos, (int)enmRectangleInfo.LeftX, (int)enmRectangleInfo.BottomY - 20);
                e.Graphics.DrawString("时间", m_fotHeaderFont, m_slbBrush, intXPos + 10, intYPos + 12);
                intXPos += 50;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY - 20);
                e.Graphics.DrawString("护理记录", m_fotHeaderFont, m_slbBrush, intXPos + 300, intYPos + 12);
                intXPos += 697;
                e.Graphics.DrawLine(m_GridPen, intXPos, intYPos, intXPos, (int)enmRectangleInfo.BottomY - 20);

                intYPos += 29;
                for (int i = 0; i < 40; i++)
                {
                    intYPos += 21;
                    e.Graphics.DrawLine(m_GridPen, (int)enmRectangleInfo.LeftX, intYPos, (int)enmRectangleInfo.RightX, intYPos);
                }
                m_intPages++;
            }
            e.Graphics.DrawString("第 " + (m_intPages-1).ToString() + " 页", m_fotHeaderFont, m_slbBrush, (int)enmRectangleInfo.LeftX + 350, (int)enmRectangleInfo.BottomY + 60);
        } 
        #endregion

        #region 打印内容
        private void m_mthAddDataToGrid(PrintPageEventArgs e)
        {
            if (ds == null || ds.Tables.Count == 0
                || (m_dtbTable0.Rows.Count == 0 && m_dtbTable1.Rows.Count == 0 && m_dtbTable2.Rows.Count == 0))
            {
                if (m_intPages < 5)
                {
                    e.HasMorePages = true;
                    //m_intPages++;
                }
                else
                {
                    e.HasMorePages = false;
                }
                return;
            }


            //if (blnIsEnd1 && blnIsEnd2 && blnIsEnd3 && blnIsEnd4 && blnIsEnd5)
            //{
            //    e.HasMorePages = false;
            //    return;
            //}

            int intYPos = 145;
            int intXPos = (int)enmRectangleInfo.LeftX;

            if ((m_intPages - 1) % 5 == 0)//整套表单第一页
            {
                intYPos += 59;
                int intTables0Rows = m_dtbTable0.Rows.Count;
                if ((m_intCurrentLine1 > 0 && m_intCurrentLine1 >= intTables0Rows - 1) || intTables0Rows == 0)
                {
                    blnIsEnd1 = true;
                    return;
                }

                string[] strDetailArrTemp = null;
                string[] strDetailXMLArrTemp = null;
                int intRowInPage = 0;

                for (int i = m_intCurrentLine1; i < intTables0Rows; i++)
                {
                    intXPos = (int)enmRectangleInfo.LeftX;
                    if (intRowInPage > 40 )
                    {
                        intRowInPage = 0;
                    }
                    if (!m_hstDateTimeLine.Contains(m_dtbTable0.Rows[i]["记录时间"].ToString()))
                    {
                        m_hstDateTimeLine.Add(m_dtbTable0.Rows[i]["记录时间"].ToString(), intRowInPage);
                    }                    

                    e.Graphics.DrawString(Convert.ToDateTime(m_dtbTable0.Rows[i]["记录时间"]).ToString("HH:mm"), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 50;
                    e.Graphics.DrawString(m_dtbTable0.Rows[i]["体温"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 35;
                    e.Graphics.DrawString(m_dtbTable0.Rows[i]["末梢体温"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 35;
                    e.Graphics.DrawString(m_dtbTable0.Rows[i]["心率"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 35;
                    e.Graphics.DrawString(m_dtbTable0.Rows[i]["心律"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 35;
                    e.Graphics.DrawString(m_dtbTable0.Rows[i]["呼吸"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 34;
                    if (m_dtbTable0.Rows[i]["血压"] != DBNull.Value)
                    {
                        string[] strBP = m_dtbTable0.Rows[i]["血压"].ToString().Split('/');
                        e.Graphics.DrawString(strBP[0], m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                        e.Graphics.DrawString("/", m_fotSmallFont, m_slbBrush, intXPos + 32, intYPos + 2);
                        e.Graphics.DrawString(strBP[1], m_fotSmallFont, m_slbBrush, intXPos + 38, intYPos + 2);
                    }                    
                    intXPos += 70;
                    e.Graphics.DrawString(m_dtbTable0.Rows[i]["ABP"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 35;
                    e.Graphics.DrawString(m_dtbTable0.Rows[i]["CVP"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 35;
                    e.Graphics.DrawString(m_dtbTable0.Rows[i]["SpO2(%)"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 35;
                    e.Graphics.DrawString(m_dtbTable0.Rows[i]["意识"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 35;
                    if (m_dtbTable0.Rows[i]["瞳孔左/右"] != DBNull.Value)
                    {
                        string[] strPupil = m_dtbTable0.Rows[i]["瞳孔左/右"].ToString().Split('/');
                        e.Graphics.DrawString(strPupil[0], m_fotSmallFont, m_slbBrush, intXPos + 1, intYPos + 2);
                        e.Graphics.DrawString("/", m_fotSmallFont, m_slbBrush, intXPos + 15, intYPos + 2);
                        e.Graphics.DrawString(strPupil[1], m_fotSmallFont, m_slbBrush, intXPos + 21, intYPos + 2);
                    }                    
                    intXPos += 36;
                    if (m_dtbTable0.Rows[i]["对光反射左右"] != DBNull.Value)
                    {
                        string[] strLight = m_dtbTable0.Rows[i]["对光反射左右"].ToString().Split('/');
                        e.Graphics.DrawString(strLight[0], m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                        e.Graphics.DrawString("/", m_fotSmallFont, m_slbBrush, intXPos + 37, intYPos + 2);
                        e.Graphics.DrawString(strLight[1], m_fotSmallFont, m_slbBrush, intXPos + 43, intYPos + 2);
                    }                    
                    intXPos += 80;
                    int MaxCount = 1;
                    if (m_dtbTable0.Rows[i]["血管活性药物"] == DBNull.Value)
                    {
                        e.Graphics.DrawString("", m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    }
                    else
                    {
                        com.digitalwave.controls.ctlRichTextBox.m_mthSplitXmlByBytes(m_dtbTable0.Rows[i]["血管活性药物"].ToString(), "<r></r>", 13, out strDetailArrTemp, out strDetailXMLArrTemp);
                        for (int iArr = 0; iArr < strDetailArrTemp.Length; iArr++)
                        {
                            e.Graphics.DrawString(strDetailArrTemp[iArr], m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2 + iArr * 21);
                        }
                        MaxCount = strDetailArrTemp.Length;
                    }                    
                    intXPos += 97;
                    if (m_dtbTable0.Rows[i]["强心利尿药及其他特殊药物"] == DBNull.Value)
                    {
                        e.Graphics.DrawString("", m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    }
                    else
                    {
                        com.digitalwave.controls.ctlRichTextBox.m_mthSplitXmlByBytes(m_dtbTable0.Rows[i]["强心利尿药及其他特殊药物"].ToString(), "<r></r>", 13, out strDetailArrTemp, out strDetailXMLArrTemp);
                        for (int iArr = 0; iArr < strDetailArrTemp.Length; iArr++)
                        {
                            e.Graphics.DrawString(strDetailArrTemp[iArr], m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2 + iArr * 21);
                        }
                        if (MaxCount < strDetailArrTemp.Length)
                        {
                            MaxCount = strDetailArrTemp.Length;
                        }
                    }
                    intRowInPage += MaxCount;
                    intYPos += 21 * MaxCount;

                    m_intCurrentLine1 = i;

                    if (intRowInPage >= 39)
                    {
                        break;
                    }

                    if (m_intCurrentLine1 >= intTables0Rows - 1)
                    {
                        blnIsEnd1 = true;
                    }
                }
                //m_intPages++;
                e.HasMorePages = true;
                //m_intCurrentLine1 += 40;
            }
            else if ((m_intPages - 2) % 5 == 0)
            {
                intYPos += 99;
                int intTables0Rows = m_dtbTable0.Rows.Count;
                if ((m_intCurrentLine2 > 0 && m_intCurrentLine2 >= intTables0Rows - 1) || intTables0Rows == 0)
                {
                    blnIsEnd2 = true;
                    return;
                }

                int intFirstRow = intYPos;
                for (int i = m_intCurrentLine2; i < intTables0Rows; i++)
                {
                    if (m_hstDateTimeLine.Contains(m_dtbTable0.Rows[i]["记录时间"].ToString()))
                    {
                        intYPos = intFirstRow + (int)m_hstDateTimeLine[m_dtbTable0.Rows[i]["记录时间"].ToString()] * 21;
                    }
                    else
                    {
                        break;
                    }

                    intXPos = (int)enmRectangleInfo.LeftX;
                    e.Graphics.DrawString(Convert.ToDateTime(m_dtbTable0.Rows[i]["记录时间"]).ToString("HH:mm"), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 50;
                    e.Graphics.DrawString(m_dtbTable0.Rows[i]["入量1"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 30;
                    e.Graphics.DrawString(m_dtbTable0.Rows[i]["入量2"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 30;
                    e.Graphics.DrawString(m_dtbTable0.Rows[i]["入量3"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 30;
                    e.Graphics.DrawString(m_dtbTable0.Rows[i]["入量4"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 30;
                    e.Graphics.DrawString(m_dtbTable0.Rows[i]["入量5"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 30;
                    if (m_dtbTable0.Rows[i]["全血/血浆"] != DBNull.Value)
                    {
                        string[] strBlood = m_dtbTable0.Rows[i]["全血/血浆"].ToString().Split('/');
                        e.Graphics.DrawString(strBlood[0], m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                        e.Graphics.DrawString("/", m_fotSmallFont, m_slbBrush, intXPos + 29, intYPos + 2);
                        e.Graphics.DrawString(strBlood[1], m_fotSmallFont, m_slbBrush, intXPos + 35, intYPos + 2);                        
                    }                    
                    intXPos += 65;
                    if (m_dtbTable0.Rows[i]["鼻饲/进饲"] != DBNull.Value)
                    {
                        string[] strNose = m_dtbTable0.Rows[i]["鼻饲/进饲"].ToString().Split('/');
                        e.Graphics.DrawString(strNose[0], m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                        e.Graphics.DrawString("/", m_fotSmallFont, m_slbBrush, intXPos + 29, intYPos + 2);
                        e.Graphics.DrawString(strNose[1], m_fotSmallFont, m_slbBrush, intXPos + 35, intYPos + 2);
                    }                    
                    intXPos += 65;
                    e.Graphics.DrawString(m_dtbTable0.Rows[i]["每时入量累计"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 35;
                    e.Graphics.DrawString(m_dtbTable0.Rows[i]["入量总量累计"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 36;
                    e.Graphics.DrawString(m_dtbTable0.Rows[i]["大便出量"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 30;
                    e.Graphics.DrawString(m_dtbTable0.Rows[i]["大便累计"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 30;
                    e.Graphics.DrawString(m_dtbTable0.Rows[i]["小便出量"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 30;
                    e.Graphics.DrawString(m_dtbTable0.Rows[i]["小便累计"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 35;
                    e.Graphics.DrawString(m_dtbTable0.Rows[i]["出量1"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 30;
                    e.Graphics.DrawString(m_dtbTable0.Rows[i]["出量2"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 30;
                    e.Graphics.DrawString(m_dtbTable0.Rows[i]["出量3"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 30;
                    e.Graphics.DrawString(m_dtbTable0.Rows[i]["出量4"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 30;
                    e.Graphics.DrawString(m_dtbTable0.Rows[i]["出量5"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 30;
                    e.Graphics.DrawString(m_dtbTable0.Rows[i]["每时出量累计D"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 35;
                    e.Graphics.DrawString(m_dtbTable0.Rows[i]["出量总量累计"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intYPos += 21;

                    m_intCurrentLine2 = i;

                    if (m_intCurrentLine2 >= intTables0Rows - 1)
                    {
                        blnIsEnd2 = true;
                    }
                }
                //m_intPages++;
                e.HasMorePages = true;
                //m_intCurrentLine2 += 40;
            }
            else if ((m_intPages - 3) % 5 == 0)
            {
                intYPos += 80;
                int intTables0Rows = m_dtbTable0.Rows.Count;
                if ((m_intCurrentLine3 > 0 && m_intCurrentLine3 >= intTables0Rows - 1) || intTables0Rows == 0)
                {
                    blnIsEnd3 = true;
                    return;
                }

                int intFirstRow = intYPos;
                for (int i = m_intCurrentLine3; i < intTables0Rows; i++)
                {
                    if (m_hstDateTimeLine.Contains(m_dtbTable0.Rows[i]["记录时间"].ToString()))
                    {
                        intYPos = intFirstRow + (int)m_hstDateTimeLine[m_dtbTable0.Rows[i]["记录时间"].ToString()] * 21;
                    }
                    else
                    {
                        break;
                    }

                    intXPos = (int)enmRectangleInfo.LeftX;
                    e.Graphics.DrawString(Convert.ToDateTime(m_dtbTable0.Rows[i]["记录时间"]).ToString("HH:mm"), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 50;
                    e.Graphics.DrawString(m_dtbTable0.Rows[i]["体位"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 60;
                    e.Graphics.DrawString(m_dtbTable0.Rows[i]["皮肤"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 50;
                    if (m_dtbTable0.Rows[i]["痰色/痰量"] != DBNull.Value)
                    {
                        string[] strTemp = m_dtbTable0.Rows[i]["痰色/痰量"].ToString().Split('/');
                        e.Graphics.DrawString(strTemp[0], m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                        e.Graphics.DrawString("/", m_fotSmallFont, m_slbBrush, intXPos + 32, intYPos + 2);
                        e.Graphics.DrawString(strTemp[1], m_fotSmallFont, m_slbBrush, intXPos + 38, intYPos + 2);
                    }                    
                    intXPos += 72;
                    e.Graphics.DrawString(m_dtbTable0.Rows[i]["吸痰"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 40;
                    e.Graphics.DrawString(m_dtbTable0.Rows[i]["体疗"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 40;
                    e.Graphics.DrawString(m_dtbTable0.Rows[i]["口腔护理"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 40;
                    e.Graphics.DrawString(m_dtbTable0.Rows[i]["会阴冲洗"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 40;
                    e.Graphics.DrawString(m_dtbTable0.Rows[i]["擦浴"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 40;
                    e.Graphics.DrawString(m_dtbTable0.Rows[i]["PT"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 45;
                    e.Graphics.DrawString(m_dtbTable0.Rows[i]["ACT"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 45;
                    e.Graphics.DrawString(m_dtbTable0.Rows[i]["glu"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 45;
                    e.Graphics.DrawString(m_dtbTable0.Rows[i]["K"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 45;
                    e.Graphics.DrawString(m_dtbTable0.Rows[i]["Na++"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 45;
                    e.Graphics.DrawString(m_dtbTable0.Rows[i]["CL-"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 45;
                    e.Graphics.DrawString(m_dtbTable0.Rows[i]["Ca++"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intYPos += 21;

                    m_intCurrentLine3 = i;

                    if (m_intCurrentLine3 >= intTables0Rows - 1)
                    {
                        blnIsEnd3 = true;
                    }
                }
                //m_intPages++;
                e.HasMorePages = true;
                //m_intCurrentLine3 += 40;
            }
            else if ((m_intPages - 4) % 5 == 0)
            {
                intYPos += 84;
                int intTable1Rows = m_dtbTable1.Rows.Count;

                if ((m_intCurrentLine4 > 0 && m_intCurrentLine4 >= intTable1Rows - 1) || intTable1Rows == 0)
                {
                    blnIsEnd4 = true;
                    return;
                }

                int intFirstRow = intYPos;
                for (int i = m_intCurrentLine4; i < intTable1Rows; i++)
                {
                    if (m_hstDateTimeLine.Contains(m_dtbTable1.Rows[i]["记录时间"].ToString()))
                    {
                        intYPos = intFirstRow + (int)m_hstDateTimeLine[m_dtbTable1.Rows[i]["记录时间"].ToString()] * 21;
                    }
                    else
                    {
                        break;
                    }

                    intXPos = (int)enmRectangleInfo.LeftX;
                    e.Graphics.DrawString(Convert.ToDateTime(m_dtbTable1.Rows[i]["记录时间"]).ToString("HH:mm"), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 50;
                    e.Graphics.DrawString(m_dtbTable1.Rows[i]["机械通气模式"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 60;
                    e.Graphics.DrawString(m_dtbTable1.Rows[i]["PEE P/Pi"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 60;
                    e.Graphics.DrawString(m_dtbTable1.Rows[i]["TV/Ti"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 60;
                    e.Graphics.DrawString(m_dtbTable1.Rows[i]["频率"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 30;
                    e.Graphics.DrawString(m_dtbTable1.Rows[i]["氧浓度"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 30;
                    e.Graphics.DrawString(m_dtbTable1.Rows[i]["灵敏度"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 30;
                    e.Graphics.DrawString(m_dtbTable1.Rows[i]["流速"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 30;
                    e.Graphics.DrawString(m_dtbTable1.Rows[i]["I:E"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 67;
                    e.Graphics.DrawString(m_dtbTable1.Rows[i]["气道压力"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 30;
                    e.Graphics.DrawString(m_dtbTable1.Rows[i]["TV"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 30;
                    e.Graphics.DrawString(m_dtbTable1.Rows[i]["MV"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 30;
                    e.Graphics.DrawString(m_dtbTable1.Rows[i]["插管深度"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 30;
                    e.Graphics.DrawString(m_dtbTable1.Rows[i]["气囊压力"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 30;
                    e.Graphics.DrawString(m_dtbTable1.Rows[i]["ET CO2"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 30;
                    e.Graphics.DrawString(m_dtbTable1.Rows[i]["PH"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 30;
                    e.Graphics.DrawString(m_dtbTable1.Rows[i]["PCO2"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 30;
                    e.Graphics.DrawString(m_dtbTable1.Rows[i]["PaO2"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 30;
                    e.Graphics.DrawString(m_dtbTable1.Rows[i]["HCO3"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 30;
                    e.Graphics.DrawString(m_dtbTable1.Rows[i]["BE"].ToString(), m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intYPos += 21;

                    m_intCurrentLine4 = i;

                    if (m_intCurrentLine4 >= intTable1Rows - 1)
                    {
                        blnIsEnd4 = true;
                    }
                }
                //m_intPages++;
                e.HasMorePages = true;
                //m_intCurrentLine4 += 40;
            }
            else if ((m_intPages - 5) % 5 == 0)
            {
                intYPos += 29;
                int intTable2Rows = m_dtbTable2.Rows.Count;
                if ((m_intCurrentLine5 > 0 && m_intCurrentLine5 >= intTable2Rows - 1) || intTable2Rows == 0)
                {
                    blnIsEnd5 = true;
                    return;
                }

                for (int i = m_intCurrentLine5; i < intTable2Rows; i++)
                {
                    intXPos = (int)enmRectangleInfo.LeftX;
                    intYPos = 145 + 29 + 21;
                    if (m_hstDateTimeLine.Contains(m_dtbTable2.Rows[i]["记录时间"].ToString()))
                    {
                        intYPos += (int)m_hstDateTimeLine[m_dtbTable2.Rows[i]["记录时间"].ToString()] * 21;
                    }
                    else
                    {
                        break;
                    }

                    e.Graphics.DrawString(Convert.ToDateTime(m_dtbTable2.Rows[i]["记录时间"]).ToString("HH:mm"), m_fotHeaderFont, m_slbBrush, intXPos + 2, intYPos + 2);
                    intXPos += 50;
                    string[] strDetailArrTemp;
                    string[] strDetailXMLArrTemp;
                    com.digitalwave.controls.ctlRichTextBox.m_mthSplitXmlByBytes(m_dtbTable2.Rows[i]["护理内容"].ToString(), "<r><D /><S /></r>", 95, out strDetailArrTemp, out strDetailXMLArrTemp);
                    if (strDetailArrTemp != null && strDetailArrTemp.Length > 0)
                    {
                        for (int j = 0; j < strDetailArrTemp.Length; j++)
                        {
                            e.Graphics.DrawString(strDetailArrTemp[j], m_fotSmallFont, m_slbBrush, intXPos + 2, intYPos + 2);
                            intYPos += 21;
                        }                        
                    }

                    m_intCurrentLine5 = i;

                    if (m_intCurrentLine5 >= intTable2Rows - 1)
                    {
                        blnIsEnd5 = true;
                    }
                }
                //m_intPages++;
                e.HasMorePages = true;
                //m_intCurrentLine5 += 40;
            }
            if (blnIsEnd1 && blnIsEnd2 && blnIsEnd3 && blnIsEnd4 && blnIsEnd5)
            {
                e.HasMorePages = false;
                m_mthInit();
            }
            return;
        } 
        #endregion

        #region 初始化打印变量
        private void m_mthInit()
        {
            m_intCurrentLine1 = 0;
            m_intCurrentLine2 = 0;
            m_intCurrentLine3 = 0;
            m_intCurrentLine4 = 0;
            m_intCurrentLine5 = 0;

            blnIsEnd1 = false;
            blnIsEnd2 = false;
            blnIsEnd3 = false;
            blnIsEnd4 = false;
            blnIsEnd5 = false;

            m_hstDateTimeLine.Clear();
        } 
        #endregion
        #endregion
    }
}
