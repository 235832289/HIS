using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;
using iCareData;

namespace iCare
{
    /// <summary>
    /// 手术护理记录(广西)打印工具类
    /// </summary>
    public class clsEMR_OPNurseRecordPrintTool : infPrintRecord
    {
        private bool m_blnIsFromDataSource = true;//表明是从数据库读取还是从文件直接提取信息
        private bool m_blnWantInit = true;
        private clsPrintInfo_EMR_OPNurseRecord m_objPrintInfo;

        /// <summary>
        /// 设置打印信息(当从数据库读取时要首先调用.)
        /// </summary>
        /// <param name="p_objPatient">病人</param>
        /// <param name="p_dtmInPatientDate">入院日期</param>
        /// <param name="p_dtmOpenDate">OpenDate，如果是一次打印多次记录表单的类型（如病案记录），忽略OpenDate</param>
        public void m_mthSetPrintInfo(clsPatient p_objPatient, DateTime p_dtmInPatientDate, DateTime p_dtmOpenDate)
        {
            m_blnIsFromDataSource = true;//表明是从数据库读取
            clsPatient m_objPatient = p_objPatient;
            m_objPrintInfo = new clsPrintInfo_EMR_OPNurseRecord();
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
            m_objPrintInfo.m_dtmHISInPatientDate = m_objPatient != null ? m_objPatient.m_DtmSelectedHISInDate : DateTime.MinValue;
        }

        /// <summary>
        /// 从数据库初始化打印内容。如果没有记录，打印空报表。(当从数据库读取时要调用.)
        /// </summary>
        public void m_mthInitPrintContent()
        {
            m_blnWantInit = false;//
            if (m_objPrintInfo == null)
            {
                clsPublicFunction.ShowInformationMessageBox("调用m_mthInitPrintContent之前请首先调用m_mthSetPrintInfo函数");
                return;
            }

            clsDiseaseTrackDomain m_objRecordsDomain = new clsDiseaseTrackDomain(enmDiseaseTrackType.EMR_OPNurseRecord);
            
            if (m_objPrintInfo.m_strInPatentID != "" && m_objPrintInfo.m_dtmOpenDate != DateTime.MinValue)
            {
                clsTrackRecordContent objContent = new clsTrackRecordContent();
                long lngRes = m_objRecordsDomain.m_lngGetRecordContent(m_objPrintInfo.m_strInPatentID, m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), m_objPrintInfo.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"), out objContent);
                m_objPrintInfo.m_objRecordContent = objContent as clsEMR_OperationRecord_GX;
                if (lngRes <= 0)
                    return;
            }
            m_objRecordsDomain = null;
            //设置表单内容到打印中			
            m_mthSetPrintContent((clsEMR_OperationRecord_GX)m_objPrintInfo.m_objRecordContent, m_objPrintInfo.m_dtmFirstPrintDate);
        }

        /// <summary>
        /// 设置打印内容。(当数据已经存在时使用。)
        /// </summary>
        /// <param name="p_objPrintContent">打印内容</param>
        public void m_mthSetPrintContent(object p_objPrintContent)
        {
            m_blnWantInit = false;
            if (p_objPrintContent.GetType().Name != "clsPrintInfo_EMR_OPNurseRecord")
            {
                MDIParent.ShowInformationMessageBox("参数错误");
            }
            m_blnIsFromDataSource = false;//表明是从文件直接提取信息
            m_objPrintInfo.m_objRecordContent = (clsEMR_OperationRecord_GX)p_objPrintContent;

            m_mthSetPrintContent(m_objPrintInfo.m_objRecordContent, m_objPrintInfo.m_dtmFirstPrintDate);
        }

        /// <summary>
        /// 获取打印内容,(当从数据库读取时,调用本函数之前请首先调用m_mthSetPrintInfo函数)
        /// </summary>
        /// <returns>打印内容</returns>
        public object m_objGetPrintInfo()
        {
            if (m_blnIsFromDataSource)
            {
                if (m_objPrintInfo == null)
                {
                    MDIParent.ShowInformationMessageBox("当从数据库读取时,调用m_objGetPrintInfo之前请首先调用m_mthSetPrintInfo函数");
                    return null;
                }

                if (m_blnWantInit)
                    m_mthInitPrintContent();
            }

            //没有记录内容时，返回空
            if (m_objPrintInfo.m_objRecordContent == null)
                return null;
            else
                return m_objPrintInfo;
        }

        /// <summary>
        /// 初始化打印变量,本例传入空对象即可.
        /// </summary>
        public void m_mthInitPrintTool(object p_objArg)
        {
            #region 有关打印初始化
            m_fotTitleFont = new Font("SimSun", 15.75f, FontStyle.Bold);//宋体三号
            m_fotHeaderFont = new Font("SimSun", 10.5F);//宋体五号
            m_fotItemHead = new Font("", 13, FontStyle.Bold);
            m_fotSmallFont = new Font("SimSun", 11);
            m_GridPen = new Pen(Color.Black, 2);
            m_slbBrush = new SolidBrush(Color.Black);
            m_objPageSetting = new clsPrintPageSettingForRecord();
            #endregion 有关打印初始化
        }

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
        }

        /// <summary>
        /// 打印开始
        /// </summary>
        /// <param name="p_objPrintArg">此处p_objPrintArg要求为PrintEventArgs类型的对象</param>
        public void m_mthBeginPrint(object p_objPrintArg)
        {
            m_mthBeginPrintSub((PrintEventArgs)p_objPrintArg);
        }

        /// <summary>
        /// 打印中
        /// </summary>
        /// <param name="p_objPrintArg">此处p_objPrintArg要求为PrintPageEventArgs类型的对象</param>
        public void m_mthPrintPage(object p_objPrintArg)
        {
            m_mthPrintPageSub((PrintPageEventArgs)p_objPrintArg);
        }

        /// <summary>
        /// 打印结束。一般使用它来更新数据库信息。
        /// </summary>
        /// <param name="p_objPrintArg">此处p_objPrintArg要求为PrintEventArgs类型的对象</param>
        public void m_mthEndPrint(object p_objPrintArg)
        {
            m_mthEndPrintSub((PrintEventArgs)p_objPrintArg);
            if (m_blnIsFromDataSource == false || m_objPrintInfo.m_strInPatentID == "") return;
            //如果打印成功，查找有无需要更新的时间，如果有，更新时间。 
            if (!((PrintEventArgs)p_objPrintArg).Cancel && m_objPrintInfo.m_blnIsFirstPrint)
            {
                clsDiseaseTrackDomain m_objRecordsDomain = new clsDiseaseTrackDomain(enmDiseaseTrackType.EMR_OPNurseRecord);
                m_objRecordsDomain.m_lngUpdateFirstPrintDate(m_objPrintInfo.m_strInPatentID, 
                    m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), 
                    m_objPrintInfo.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"), m_objPrintInfo.m_dtmFirstPrintDate);
            }
        }

        /// <summary>
        /// 设置打印内容
        /// </summary>
        /// <param name="p_objContent"></param>
        /// <param name="p_dtmFirstPrintDate"></param>
        private void m_mthSetPrintContent(clsEMR_OperationRecord_GX p_objContent, DateTime p_dtmFirstPrintDate)
        {
            m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
                new com.digitalwave.Utility.Controls.clsPrintLineBase[] { new  clsPrintInstanceBeforeOP(),
                                                                          new  clsPrintNurseInOP(),
                                                                          new  clsPrintNurseAfterOP(),
                                                                          new  clsPrintNurseRecordContent(),
                                                                          new  clsPrintNurseSign()});
            m_objPrintLineContext.m_ObjPrintSign = new com.digitalwave.Utility.Controls.clsPrintRecordSign();

            //设置打印信息，就是Set Value进去
            m_objPrintLineContext.m_ObjPrintLineInfo = m_objPrintInfo;
            //将数据库拿出来的FirstPrintDate赋给每个打印行里面的m_DtmFirstPrintTime，在父类里做了
            m_objPrintLineContext.m_DtmFirstPrintTime = p_dtmFirstPrintDate;
        }

        #region 有关打印的声明

        /// <summary>
        /// 打印一行的内容
        /// </summary>
        private com.digitalwave.Utility.Controls.clsPrintContext m_objPrintLineContext;

        /// <summary>
        /// 打印边框的左边距
        /// </summary>
        private const int m_intRecBaseX = clsPrintPosition.c_intLeftX;
        private int m_intCurrentPage = 1;
        /// <summary>
        /// 标题的字体(20 bold)
        /// </summary>
        private Font m_fotTitleFont;
        /// <summary>
        /// 表头的字体(14 )
        /// </summary>
        private Font m_fotHeaderFont;
        /// <summary>
        /// 大项目的标题，如体格检查
        /// </summary>
        public static Font m_fotItemHead;
        /// <summary>
        /// 表内容的字体(11)
        /// </summary>
        private Font m_fotSmallFont;
        /// <summary>
        /// 边框画笔
        /// </summary>
        private Pen m_GridPen;
        /// <summary>
        /// 刷子
        /// </summary>
        private SolidBrush m_slbBrush;
        /// <summary>
        /// 当前打印位置（Y）
        /// </summary>
        private int m_intYPos = 155;

        /// <summary>
        /// 格子的信息
        /// </summary>
        public enum enmRectangleInfo
        {
            /// <summary>
            /// 格子的顶端
            /// </summary>
            TopY = 150,
            ///<summary>
            /// 格子的左端
            /// </summary>
            LeftX = clsPrintPosition.c_intLeftX,
            /// <summary>
            /// 格子的右端
            /// </summary>
            RightX = clsPrintPosition.c_intRightX,
            /// <summary>
            /// 格子每行的步长
            /// </summary>
            RowStep = 25,
            SmallRowStep = 25,
            /// <summary>
            /// 格子的行数
            /// </summary>
            RowLinesNum = 32,

            ColumnsMark1 = 35,

            /// <summary>
            /// CheckBox偏移右边文本的距离
            /// </summary>
            CheckShift = 15,

            /// <summary>
            /// 底划线偏移文本顶点的距离
            /// </summary>
            BottomLineShift = 15,

            BottomY = 1025
        }
        #endregion
        /// <summary>
		/// 获取坐标的类
		/// </summary>
        private clsPrintPageSettingForRecord m_objPageSetting;
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
                        m_fReturnPoint = new PointF(310f - fltOffsetX, 70f);
                        break;
                    case (int)enmItemDefination.Name_Title:
                        m_fReturnPoint = new PointF(55f - fltOffsetX, 105f);
                        break;
                    case (int)enmItemDefination.Name:
                        m_fReturnPoint = new PointF(95f - fltOffsetX, 105f);
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
        #endregion

        #region 格子的信息
        /// <summary>
        /// 格子的信息
        /// </summary>
        private enum enmRectangleInfoInPatientCaseInfo
        {
            /// <summary>
            /// 格子的顶端
            /// </summary>
            TopY = 140,
            ///<summary>
            /// 格子的左端
            /// </summary>
            LeftX = 16,
            /// <summary>
            /// 格子的右端
            /// </summary>
            RightX = 180 + 17,
            /// <summary>
            /// 格子每行的步长
            /// </summary>
            RowStep = 7,
            SmallRowStep = 20,
            /// <summary>
            /// 格子的行数
            /// </summary>
            RowLinesNum = 32,

            ColumnsMark1 = 35,
            /// <summary>
            /// CheckBox偏移右边文本的距离
            /// </summary>
            CheckShift = 15,
            /// <summary>
            /// 底划线偏移文本顶点的距离
            /// </summary>
            BottomLineShift = 15,

            BottomY = 1024,

            PrintWidth = 690,
            PrintWidth2 = 710,
        } 
        #endregion

        #region 打印开始后，在打印页之前的操作
        // 打印开始后，在打印页之前的操作
        private void m_mthBeginPrintSub(PrintEventArgs p_objPrintArg)
        {

        } 
        #endregion

        #region 打印页
        // 打印页
        private void m_mthPrintPageSub(PrintPageEventArgs p_objPrintPageArg)
        {
            m_mthPrintTitleInfo(p_objPrintPageArg);
            m_mthPrintHeader(p_objPrintPageArg);

            Font fntNormal = new Font("", 10);

            while (m_objPrintLineContext.m_BlnHaveMoreLine)
            {
                //还有数据打印
                m_objPrintLineContext.m_mthPrintNextLine(ref m_intYPos, p_objPrintPageArg.Graphics, fntNormal);

                if (m_intYPos > p_objPrintPageArg.PageBounds.Height - 85
                    && m_objPrintLineContext.m_BlnHaveMoreLine)
                {
                    //还有数据打印，但需要换页

                    m_mthPrintFoot(p_objPrintPageArg);

                    p_objPrintPageArg.HasMorePages = true;

                    m_intYPos = 155;

                    m_intCurrentPage++;

                    return;
                }
            }

            m_intYPos += 30;
            Font fntSign = new Font("", 6);
            while (m_objPrintLineContext.m_BlnHaveMoreSign)
            {
                m_objPrintLineContext.m_mthPrintNextSign(30 + 10, m_intYPos, p_objPrintPageArg.Graphics, fntSign);

                m_intYPos += (int)enmRectangleInfo.RowStep - 10;
            }
            //全部打完	
            m_mthPrintFoot(p_objPrintPageArg);
        } 
        #endregion

        #region PrintClasses
        #region 打印抽象类
        /// <summary>
        /// 打印抽象类
        /// </summary>
        private abstract class clsPrintInPatientCaseInfo : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            protected clsEMR_OperationRecord_GX m_objContent;
            /// <summary>
            /// 文字距离左边的边距
            /// </summary>
            protected int m_intRecBaseX = clsPrintPosition.c_intLeftX;
            protected int m_intPatientInfoX = clsPrintPosition.c_intLeftX + 45;
            protected clsPrintInfo_EMR_OPNurseRecord m_objPrintInfo;
            /// <summary>
            /// 是否已打印图片
            /// </summary>
            public static bool m_blnHasPrintPic = false;
            /// <summary>
            /// 当前图片
            /// </summary>
            public int m_intCurrentPic = 0;

            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return base.m_blnHaveMoreLine;
                }
                set
                {
                    if (value == null) return;
                    object objData = value;
                    m_objPrintInfo = (clsPrintInfo_EMR_OPNurseRecord)objData;
                }
            }

            public string m_strGetSingArr(string p_strControlName, clsEmrSigns_VO[] p_objSignArr)
            {
                if (p_objSignArr == null || string.IsNullOrEmpty(p_strControlName))
                    return string.Empty;
                string strSigns = "";
                for (int i = 0; i < p_objSignArr.Length; i++)
                {
                    if (p_objSignArr[i].controlName == p_strControlName.Trim())
                    {
                        strSigns += p_objSignArr[i].objEmployee.m_strGetTechnicalRankAndName + "  ";
                    }
                }
                return strSigns;
            }
        } 
        #endregion

        #region 术前情况
        /// <summary>
        /// 术前情况
        /// </summary>
        private class clsPrintInstanceBeforeOP : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private bool m_blnIsFirstPrint = true;
            private int m_intTimes = 0;
            private Font fntCheck = new Font("SimSun", 18);
            private clsPublicControlPaint m_objCPaint = new clsPublicControlPaint();

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_blnIsFirstPrint)
                {
                    bool blnIsNull = false;
                    if (m_objPrintInfo == null || m_objPrintInfo.m_objRecordContent == null)
                    {
                        blnIsNull = true;
                    }
                    p_intPosY -= 10;

                    #region 手术
                    p_objGrp.DrawString("手术名称：" + (blnIsNull ? "" : m_objPrintInfo.m_objRecordContent.m_strOPNAME_RIGHT), p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    p_objGrp.DrawString("手术医生：" + (blnIsNull ? "" : m_strGetSingArr("m_lsvOperationer", m_objPrintInfo.m_objRecordContent.objSignerArr)), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 450, p_intPosY); 
                    #endregion

                    p_intPosY += 30;
                    #region 麻醉
                    p_objGrp.DrawString("麻醉方式：" + (blnIsNull ? "" : m_objPrintInfo.m_objRecordContent.m_strANANAME_RIGHT), p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    p_objGrp.DrawString("麻醉医生：" + (blnIsNull ? "" : m_strGetSingArr("m_lsvAnaDocSign", m_objPrintInfo.m_objRecordContent.objSignerArr)), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 450, p_intPosY); 
                    #endregion

                    p_intPosY += 30;
                    #region 手术体位
                    p_objGrp.DrawString("手术体位：", p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 90, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("仰卧位  ", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 105, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 180, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("侧卧位  ", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 195, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 270, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("截肢位  ", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 285, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 360, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("颈仰卧位  ", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 375, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 460, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("其它：" + (blnIsNull ? "" : m_objPrintInfo.m_objRecordContent.m_strOTHERPOSTURE_RIGHT), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 475, p_intPosY);

                    if (!blnIsNull)
                    {
                        if (m_objPrintInfo.m_objRecordContent.m_strPOSTURE[0].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 80, p_intPosY - 8);
                        if (m_objPrintInfo.m_objRecordContent.m_strPOSTURE[1].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 170, p_intPosY - 8);
                        if (m_objPrintInfo.m_objRecordContent.m_strPOSTURE[2].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 260, p_intPosY - 8);
                        if (m_objPrintInfo.m_objRecordContent.m_strPOSTURE[3].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 350, p_intPosY - 8);
                        if (m_objPrintInfo.m_objRecordContent.m_strPOSTURE[4].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 450, p_intPosY - 8);
                    } 
                    #endregion

                    p_intPosY += 30;
                    p_objGrp.DrawLine(Pens.Black, m_intRecBaseX, p_intPosY, m_intRecBaseX + (int)enmRectangleInfo.RightX - (int)enmRectangleInfo.LeftX + 10, p_intPosY);
                    p_objGrp.DrawString("术前护理", p_fntNormalText, Brushes.Black, new RectangleF(m_intRecBaseX + 10, p_intPosY - 90, 20, 120));
                                        
                    m_blnIsFirstPrint = false;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2, m_intPatientInfoX, p_intPosY, p_objGrp);

                    p_intPosY += 30;

                    m_intTimes++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    m_blnHaveMoreLine = false;
                }
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnIsFirstPrint = true;

                m_blnHaveMoreLine = true;

                m_intTimes = 0;
            }
        } 
        #endregion

        #region 术中护理
        /// <summary>
        /// 术中护理
        /// </summary>
        private class clsPrintNurseInOP : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private bool m_blnIsFirstPrint = true;
            private int m_intTimes = 0;
            private Font fntCheck = new Font("SimSun", 18);
            private clsPublicControlPaint m_objCPaint = new clsPublicControlPaint();

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_blnIsFirstPrint)
                {
                    bool blnIsNull = false;
                    if (m_objPrintInfo == null || m_objPrintInfo.m_objRecordContent == null)
                    {
                        blnIsNull = true;
                    }
                    p_intPosY += 5;
                    #region 止血带
                    p_objGrp.DrawString("止血带：", p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 80, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("驱血橡皮带  ", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 95, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 195, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("气压止血仪  ", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 210, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 310, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("自动止血带  ", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 325, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 425, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("无  ", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 440, p_intPosY);

                    if (!blnIsNull)
                    {
                        if (m_objPrintInfo.m_objRecordContent.m_strSTANCHSTRAP[0].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 70, p_intPosY - 8);
                        if (m_objPrintInfo.m_objRecordContent.m_strSTANCHSTRAP[1].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 185, p_intPosY - 8);
                        if (m_objPrintInfo.m_objRecordContent.m_strSTANCHSTRAP[2].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 300, p_intPosY - 8);
                        if (m_objPrintInfo.m_objRecordContent.m_strSTANCHSTRAP[3].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 415, p_intPosY - 8);
                    }
                    #endregion

                    p_intPosY += 25;
                    #region 肢体充、放气及压力情况
                    int intGridLines = 7;
                    if (!blnIsNull)
                    {
                        if (m_objPrintInfo.m_objRecordContent.m_objLimbInfoArr != null)
                        {
                            intGridLines = m_objPrintInfo.m_objRecordContent.m_objLimbInfoArr.Length + 2;
                        }
                    }
                    for (int i = 0; i < intGridLines; i++)
                    {
                        p_objGrp.DrawLine(Pens.Black, m_intRecBaseX + 40, p_intPosY + i * 20, m_intRecBaseX + (int)enmRectangleInfo.RightX - (int)enmRectangleInfo.LeftX + 10, p_intPosY + i * 20);
                        if (i == 0)
                        {
                            p_objGrp.DrawString("肢  体", p_fntNormalText, Brushes.Black, m_intRecBaseX + 40 + 80, p_intPosY + 4);
                            p_objGrp.DrawString("充气时间", p_fntNormalText, Brushes.Black, m_intRecBaseX + 40 + 220, p_intPosY + 4);
                            p_objGrp.DrawString("放气时间", p_fntNormalText, Brushes.Black, m_intRecBaseX + 40 + 353, p_intPosY + 4);
                            p_objGrp.DrawString("总时间(分)", p_fntNormalText, Brushes.Black, m_intRecBaseX + 40 + 486, p_intPosY + 4);
                            p_objGrp.DrawString("压  力", p_fntNormalText, Brushes.Black, m_intRecBaseX + 40 + 620, p_intPosY + 4);
                        }
                        else if (i < intGridLines - 1)
                        {
                            System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX, p_intPosY + 4 + i * 20), System.Windows.Forms.ButtonState.Flat);
                            p_objGrp.DrawString("上肢", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 15, p_intPosY + 4 + i * 20);
                            System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 60, p_intPosY + 4 + i * 20), System.Windows.Forms.ButtonState.Flat);
                            p_objGrp.DrawString("下肢", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 75, p_intPosY + 4 + i * 20);
                            System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 120, p_intPosY + 4 + i * 20), System.Windows.Forms.ButtonState.Flat);
                            p_objGrp.DrawString("左", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 135, p_intPosY + 4 + i * 20);
                            System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 155, p_intPosY + 4 + i * 20), System.Windows.Forms.ButtonState.Flat);
                            p_objGrp.DrawString("右", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 170, p_intPosY + 4 + i * 20);
                            p_objGrp.DrawString("mmHg", p_fntNormalText, Brushes.Black, m_intRecBaseX + (int)enmRectangleInfo.RightX - (int)enmRectangleInfo.LeftX - 35, p_intPosY + 2 + i * 20);

                            if (!blnIsNull && m_objPrintInfo.m_objRecordContent.m_objLimbInfoArr != null)
                            {
                                if (m_objPrintInfo.m_objRecordContent.m_objLimbInfoArr[i - 1].m_strCUBITUS == "1")
                                    p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX - 10, p_intPosY + i * 20 - 4);
                                if (m_objPrintInfo.m_objRecordContent.m_objLimbInfoArr[i - 1].m_strLEG == "1")
                                    p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 50, p_intPosY + i * 20 - 4);
                                if (m_objPrintInfo.m_objRecordContent.m_objLimbInfoArr[i - 1].m_strLEFT == "1")
                                    p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 110, p_intPosY + i * 20 - 4);
                                if (m_objPrintInfo.m_objRecordContent.m_objLimbInfoArr[i - 1].m_strRIGHT == "1")
                                    p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 145, p_intPosY + i * 20 - 4);

                                p_objGrp.DrawString(m_objPrintInfo.m_objRecordContent.m_objLimbInfoArr[i - 1].m_strCHARGETIME, p_fntNormalText, Brushes.Black, m_intRecBaseX + 40 + 210, p_intPosY + 4 + i * 20);
                                p_objGrp.DrawString(m_objPrintInfo.m_objRecordContent.m_objLimbInfoArr[i - 1].m_strDEFLATETIME, p_fntNormalText, Brushes.Black, m_intRecBaseX + 40 + 338, p_intPosY + 4 + i * 20);
                                p_objGrp.DrawString(m_objPrintInfo.m_objRecordContent.m_objLimbInfoArr[i - 1].m_strALLTIME, p_fntNormalText, Brushes.Black, m_intRecBaseX + 40 + 466, p_intPosY + 4 + i * 20);
                                p_objGrp.DrawString(m_objPrintInfo.m_objRecordContent.m_objLimbInfoArr[i - 1].m_strPRESS, p_fntNormalText, Brushes.Black, m_intRecBaseX + 40 + 594, p_intPosY + 4 + i * 20);
                            }
                        }
                    }
                    p_objGrp.DrawLine(Pens.Black, m_intRecBaseX + 40 + 200, p_intPosY, m_intRecBaseX + 40 + 200, p_intPosY + (intGridLines - 1) * 20);
                    p_objGrp.DrawLine(Pens.Black, m_intRecBaseX + 40 + 328, p_intPosY, m_intRecBaseX + 40 + 328, p_intPosY + (intGridLines - 1) * 20);
                    p_objGrp.DrawLine(Pens.Black, m_intRecBaseX + 40 + 456, p_intPosY, m_intRecBaseX + 40 + 456, p_intPosY + (intGridLines - 1) * 20);
                    p_objGrp.DrawLine(Pens.Black, m_intRecBaseX + 40 + 584, p_intPosY, m_intRecBaseX + 40 + 584, p_intPosY + (intGridLines - 1) * 20);
                    #endregion

                    p_intPosY += (intGridLines - 1) * 20 + 8;
                    #region 留置Foley氏尿管
                    p_objGrp.DrawString("留置Foley氏尿管：", p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 140, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("无", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 155, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 185, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("病房带来", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 200, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 275, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("手术室", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 290, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 350, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("双腔", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 365, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 410, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("三腔", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 425, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 470, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("其它：", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 485, p_intPosY);

                    if (!blnIsNull)
                    {
                        if (m_objPrintInfo.m_objRecordContent.m_strFOLEY[0].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 130, p_intPosY - 8);
                        if (m_objPrintInfo.m_objRecordContent.m_strFOLEY[1].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 175, p_intPosY - 8);
                        if (m_objPrintInfo.m_objRecordContent.m_strFOLEY[2].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 265, p_intPosY - 8);
                        if (m_objPrintInfo.m_objRecordContent.m_strFOLEY[3].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 370, p_intPosY - 8);
                        if (m_objPrintInfo.m_objRecordContent.m_strFOLEY[4].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 400, p_intPosY - 8);
                        if (m_objPrintInfo.m_objRecordContent.m_strFOLEY[5].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 460, p_intPosY - 8);
                        p_objGrp.DrawString(m_objPrintInfo.m_objRecordContent.m_strOTHERFOLEY_RIGHT, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 530, p_intPosY);
                    }
                    #endregion

                    p_intPosY += 25;
                    #region 皮肤、粘膜消毒
                    p_objGrp.DrawString("皮肤、粘膜消毒：", p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 140, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("2%碘酊", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 155, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 215, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("4%碘酊", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 230, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 290, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("75%酒精", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 305, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 375, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("碘伏原液", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 390, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 465, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("碘伏稀释液", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 480, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 570, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("0.1%洗必泰液", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 585, p_intPosY);

                    if (!blnIsNull)
                    {
                        if (m_objPrintInfo.m_objRecordContent.m_strSKINANTISEPSIS[0].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 130, p_intPosY - 8);
                        if (m_objPrintInfo.m_objRecordContent.m_strSKINANTISEPSIS[1].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 205, p_intPosY - 8);
                        if (m_objPrintInfo.m_objRecordContent.m_strSKINANTISEPSIS[2].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 280, p_intPosY - 8);
                        if (m_objPrintInfo.m_objRecordContent.m_strSKINANTISEPSIS[3].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 365, p_intPosY - 8);
                        if (m_objPrintInfo.m_objRecordContent.m_strSKINANTISEPSIS[4].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 455, p_intPosY - 8);
                        if (m_objPrintInfo.m_objRecordContent.m_strSKINANTISEPSIS[5].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 560, p_intPosY - 8);
                    }

                    p_intPosY += 25;
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 140, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("其它：", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 155, p_intPosY);
                    if (!blnIsNull)
                    {
                        if (m_objPrintInfo.m_objRecordContent.m_strSKINANTISEPSIS[6].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 130, p_intPosY - 8);
                        p_objGrp.DrawString(m_objPrintInfo.m_objRecordContent.m_strOTHERSKINANTISEPSIS_RIGHT, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 200, p_intPosY);
                    } 
                    #endregion

                    p_intPosY += 25;
                    #region 血制品
                    p_objGrp.DrawString("血制品：", p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 70, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("全血 " + (blnIsNull ? "" : m_objPrintInfo.m_objRecordContent.m_strWHOLEBLOOD_RIGHT), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 85, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 185, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("ml", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 160, p_intPosY);
                    p_objGrp.DrawString("红细胞" + (blnIsNull ? "" : m_objPrintInfo.m_objRecordContent.m_strREDCELL_RIGHT), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 200, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 320, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("单位", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 280, p_intPosY);
                    p_objGrp.DrawString("血浆 " + (blnIsNull ? "" : m_objPrintInfo.m_objRecordContent.m_strPLASM_RIGHT), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 335, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 435, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("ml", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 410, p_intPosY);
                    p_objGrp.DrawString("输自体血 " + (blnIsNull ? "" : m_objPrintInfo.m_objRecordContent.m_strSELFBLOOD_RIGHT), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 450, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 575, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("ml", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 555, p_intPosY);
                    p_objGrp.DrawString("血小板 " + (blnIsNull ? "" : m_objPrintInfo.m_objRecordContent.m_strPLATELET_RIGHT), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 590, p_intPosY);

                    p_intPosY += 25;
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 70, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("冷沉淀 " + (blnIsNull ? "" : m_objPrintInfo.m_objRecordContent.m_strCOLDDEPOSIT_RIGHT), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 85, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 210, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("其它：" + (blnIsNull ? "" : m_objPrintInfo.m_objRecordContent.m_strOTHERBLOOD_RIGHT), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 225, p_intPosY); 
                    #endregion

                    p_intPosY += 25;
                    #region 输入液体量及术中尿量
                    p_objGrp.DrawString("输入液体量: " + (blnIsNull ? "      " : m_objPrintInfo.m_objRecordContent.m_strINLIQUID_RIGHT) + "ml", p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    p_objGrp.DrawString("术中尿量：" + (blnIsNull ? "      " : m_objPrintInfo.m_objRecordContent.m_strPISS_RIGHT) + "ml", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 280, p_intPosY); 
                    #endregion

                    p_intPosY += 25;
                    #region 伤口引流管情况
                    p_objGrp.DrawString("伤口引流管情况：", p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 150, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("无", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 165, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 205, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("有", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 220, p_intPosY);

                    if (!blnIsNull)
                    {
                        if (m_objPrintInfo.m_objRecordContent.m_strDRAIN[0].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 140, p_intPosY - 8);
                        if (m_objPrintInfo.m_objRecordContent.m_strDRAIN[1].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 195, p_intPosY - 8);
                    }
                    #endregion

                    p_intPosY += 25;
                    #region 全身皮肤情况
                    p_objGrp.DrawString("全身皮肤情况：", p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    p_objGrp.DrawString("手术前：", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 140, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 210, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("正常", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 225, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 275, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("异常", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 290, p_intPosY);
                    p_objGrp.DrawString("皮肤情况描述：" + (blnIsNull ? "" : m_objPrintInfo.m_objRecordContent.m_strSKINBEFOREOP_DESC_RIGHT + "    " + m_objPrintInfo.m_objRecordContent.m_strSKINBEFOREOP_DESC2_RIGHT),
                        p_fntNormalText, Brushes.Black, m_intPatientInfoX + 340, p_intPosY);

                    if (!blnIsNull)
                    {
                        if (m_objPrintInfo.m_objRecordContent.m_strSKINBEFOREOP[0].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 200, p_intPosY - 8);
                        if (m_objPrintInfo.m_objRecordContent.m_strSKINBEFOREOP[1].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 265, p_intPosY - 8);
                    }

                    p_intPosY += 25;
                    p_objGrp.DrawString("手术后：", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 140, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 210, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("正常", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 225, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 275, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("异常", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 290, p_intPosY);
                    p_objGrp.DrawString("皮肤情况描述：", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 340, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 445, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("同术前", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 460, p_intPosY);
                    p_objGrp.DrawString((blnIsNull ? "" : m_objPrintInfo.m_objRecordContent.m_strSKINAFTEROP_DESC_RIGHT), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 525, p_intPosY);

                    if (!blnIsNull)
                    {
                        if (m_objPrintInfo.m_objRecordContent.m_strSKINAFTEROP[0].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 200, p_intPosY - 8);
                        if (m_objPrintInfo.m_objRecordContent.m_strSKINAFTEROP[1].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 265, p_intPosY - 8);
                        if (m_objPrintInfo.m_objRecordContent.m_strSKINAFTEROP[2].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 435, p_intPosY - 8);
                    }
                    #endregion

                    p_intPosY += 25;
                    #region 标本
                    p_objGrp.DrawString("标本：", p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 50, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("常规病理检查", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 65, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 175, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("冰冻切片", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 190, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 265, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("细菌培养", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 280, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 355, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("无", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 370, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 400, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("其它: " + (blnIsNull ? "" : m_objPrintInfo.m_objRecordContent.m_strOTHERSAMPLE_RIGHT), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 415, p_intPosY);

                    if (!blnIsNull)
                    {
                        if (m_objPrintInfo.m_objRecordContent.m_strSAMPLE[0].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 40, p_intPosY - 8);
                        if (m_objPrintInfo.m_objRecordContent.m_strSAMPLE[1].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 165, p_intPosY - 8);
                        if (m_objPrintInfo.m_objRecordContent.m_strSAMPLE[2].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 255, p_intPosY - 8);
                        if (m_objPrintInfo.m_objRecordContent.m_strSAMPLE[3].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 345, p_intPosY - 8);
                        if (m_objPrintInfo.m_objRecordContent.m_strSAMPLE[4].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 390, p_intPosY - 8);
                    } 
                    #endregion

                    p_intPosY += 25;
                    p_objGrp.DrawString("无菌包检测：" + (blnIsNull ? "" : m_objPrintInfo.m_objRecordContent.m_strAXENICBAG_RIGHT), p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    p_intPosY += 25;
                    p_objGrp.DrawString("植入物标示：" + (blnIsNull ? "" : m_objPrintInfo.m_objRecordContent.m_strEMBEDDED_RIGHT), p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);

                    p_intPosY += 25;
                    p_objGrp.DrawLine(Pens.Black, m_intRecBaseX, p_intPosY, m_intRecBaseX + (int)enmRectangleInfo.RightX - (int)enmRectangleInfo.LeftX + 10, p_intPosY);
                    p_objGrp.DrawString("术  中  护  理", p_fntNormalText, Brushes.Black, new RectangleF(m_intRecBaseX + 10, p_intPosY - 310, 20, 120));

                    m_blnIsFirstPrint = false;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2, m_intPatientInfoX, p_intPosY, p_objGrp);

                    p_intPosY += 30;

                    m_intTimes++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    m_blnHaveMoreLine = false;
                }
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnIsFirstPrint = true;

                m_blnHaveMoreLine = true;

                m_intTimes = 0;
            }
        } 
        #endregion

        #region 术后护理
        /// <summary>
        /// 术后护理
        /// </summary>
        private class clsPrintNurseAfterOP : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private bool m_blnIsFirstPrint = true;
            private int m_intTimes = 0;
            private Font fntCheck = new Font("SimSun", 18);
            private clsPublicControlPaint m_objCPaint = new clsPublicControlPaint();

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_blnIsFirstPrint)
                {
                    bool blnIsNull = false;
                    if (m_objPrintInfo == null || m_objPrintInfo.m_objRecordContent == null)
                    {
                        blnIsNull = true;
                    }
                    p_intPosY += 5;
                    #region 术后送回
                    p_objGrp.DrawString("术后送回：", p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 80, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("麻醉复苏室", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 95, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 195, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("ICU", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 210, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 250, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("病房", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 265, p_intPosY);

                    if (!blnIsNull)
                    {
                        if (m_objPrintInfo.m_objRecordContent.m_strAFTEROPSEND[0].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 70, p_intPosY - 8);
                        if (m_objPrintInfo.m_objRecordContent.m_strAFTEROPSEND[1].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 185, p_intPosY - 8);
                        if (m_objPrintInfo.m_objRecordContent.m_strAFTEROPSEND[2].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 240, p_intPosY - 8);
                    } 
                    #endregion

                    p_intPosY += 25;
                    #region 手术受压部位
                    p_objGrp.DrawString("手术受压部位：", p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    p_intPosY += 25;
                    p_objGrp.DrawString("皮肤完整性：", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 40, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 150, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("有", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 165, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 195, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("无", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 215, p_intPosY);
                    p_objGrp.DrawString("伤口渗血：", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 270, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 350, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("有", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 365, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 395, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("无", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 415, p_intPosY);

                    if (!blnIsNull)
                    {
                        if (m_objPrintInfo.m_objRecordContent.m_strSKINFULL[0].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 140, p_intPosY - 8);
                        if (m_objPrintInfo.m_objRecordContent.m_strSKINFULL[1].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 185, p_intPosY - 8);

                        if (m_objPrintInfo.m_objRecordContent.m_strSEEPBLOOD[0].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 340, p_intPosY - 8);
                        if (m_objPrintInfo.m_objRecordContent.m_strSEEPBLOOD[1].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 385, p_intPosY - 8);
                    }  
                    #endregion

                    p_intPosY += 25;
                    #region 术后访视
                    p_objGrp.DrawString("术后访视：", p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    p_intPosY += 25;
                    p_objGrp.DrawString("生命体征：", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 40, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 120, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("平稳", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 135, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 175, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("异常", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 190, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 230, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("焦虑", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 245, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 285, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("恐惧（", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 300, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 350, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("轻", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 365, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 395, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("中", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 410, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 440, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("重）", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 455, p_intPosY);

                    if (!blnIsNull)
                    {
                        if (m_objPrintInfo.m_objRecordContent.m_strLIFTSIGNAFTEROP[0].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 110, p_intPosY - 8);
                        if (m_objPrintInfo.m_objRecordContent.m_strLIFTSIGNAFTEROP[1].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 165, p_intPosY - 8);
                        if (m_objPrintInfo.m_objRecordContent.m_strLIFTSIGNAFTEROP[2].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 220, p_intPosY - 8);
                        if (m_objPrintInfo.m_objRecordContent.m_strLIFTSIGNAFTEROP[3].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 275, p_intPosY - 8);
                        if (m_objPrintInfo.m_objRecordContent.m_strLIFTSIGNAFTEROP[4].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 340, p_intPosY - 8);
                        if (m_objPrintInfo.m_objRecordContent.m_strLIFTSIGNAFTEROP[5].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 385, p_intPosY - 8);
                        if (m_objPrintInfo.m_objRecordContent.m_strLIFTSIGNAFTEROP[6].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 430, p_intPosY - 8);
                    } 
                    #endregion

                    p_intPosY += 25;
                    #region 引流管
                    p_objGrp.DrawString("引流管：", p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 70, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("有", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 85, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 125, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("无", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 140, p_intPosY);

                    if (!blnIsNull)
                    {
                        if (m_objPrintInfo.m_objRecordContent.m_strGUIDING[0].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 60, p_intPosY - 8);
                        if (m_objPrintInfo.m_objRecordContent.m_strGUIDING[1].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 115, p_intPosY - 8);
                    } 
                    #endregion

                    p_intPosY += 25;
                    #region 健康教育
                    p_objGrp.DrawString("健康教育：", p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 80, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("已做", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 95, p_intPosY);
                    System.Windows.Forms.ControlPaint.DrawCheckBox(p_objGrp, m_objCPaint.m_rtgGetControlPaint(m_intPatientInfoX + 145, p_intPosY), System.Windows.Forms.ButtonState.Flat);
                    p_objGrp.DrawString("未做", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 160, p_intPosY);

                    if (!blnIsNull)
                    {
                        if (m_objPrintInfo.m_objRecordContent.m_strHEALTHEDU[0].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 70, p_intPosY - 8);
                        if (m_objPrintInfo.m_objRecordContent.m_strHEALTHEDU[1].ToString() == "1")
                            p_objGrp.DrawString("√", fntCheck, Brushes.Black, m_intPatientInfoX + 135, p_intPosY - 8);
                    }  
                    #endregion

                    m_blnIsFirstPrint = false;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2, m_intPatientInfoX, p_intPosY, p_objGrp);

                    p_intPosY += 30;

                    m_intTimes++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    m_blnHaveMoreLine = false;
                }
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnIsFirstPrint = true;

                m_blnHaveMoreLine = true;

                m_intTimes = 0;
            }
        } 
        #endregion

        #region 护理记录
        /// <summary>
        /// 护理记录
        /// </summary>
        private class clsPrintNurseRecordContent : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private bool m_blnIsFirstPrint = true;

            private int m_intTimes = 0;

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                bool blnIsNull = false;
                if (m_objPrintInfo == null || m_objPrintInfo.m_objRecordContent == null)
                {
                    blnIsNull = true;
                }

                if (m_blnIsFirstPrint)
                {
                    p_intPosY += 25;

                    p_objGrp.DrawString("护理记录：", p_fntNormalText, Brushes.Black, m_intPatientInfoX, p_intPosY);

                    p_intPosY += 25;

                    if (!blnIsNull)
                    {
                        if (string.IsNullOrEmpty(m_objPrintInfo.m_objRecordContent.m_strOPRECORD))
                        {
                            m_blnHaveMoreLine = false;
                            return;
                        }
                    }
                    else
                    {
                        m_blnHaveMoreLine = false;
                        return;
                    }
                    m_objPrintContext.m_mthSetContextWithCorrectBefore((blnIsNull ? "" : m_objPrintInfo.m_objRecordContent.m_strOPRECORD), (blnIsNull ? "<root />" : m_objPrintInfo.m_objRecordContent.m_strOPRECORDXML), m_dtmFirstPrintTime, !blnIsNull);
                    m_mthAddSign2("护理记录：", m_objPrintContext.m_ObjModifyUserArr);

                    m_blnIsFirstPrint = false;

                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intPatientInfoX, p_intPosY, p_objGrp);

                    p_intPosY += 20;

                    m_intTimes++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    m_blnHaveMoreLine = false;
                }
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnIsFirstPrint = true;

                m_blnHaveMoreLine = true;

                m_intTimes = 0;
            }
        } 
        #endregion

        #region 护士签名
        /// <summary>
        /// 护士签名
        /// </summary>
        private class clsPrintNurseSign : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private bool m_blnIsFirstPrint = true;
            private int m_intTimes = 0;
            private Font fntCheck = new Font("SimSun", 18);
            private clsPublicControlPaint m_objCPaint = new clsPublicControlPaint();

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_blnIsFirstPrint)
                {
                    bool blnIsNull = false;
                    if (m_objPrintInfo == null || m_objPrintInfo.m_objRecordContent == null)
                    {
                        blnIsNull = true;
                    }

                    p_intPosY = (int)enmRectangleInfo.BottomY + 30;
                    p_objGrp.DrawLine(Pens.Black, m_intRecBaseX, p_intPosY, m_intRecBaseX + (int)enmRectangleInfo.RightX - (int)enmRectangleInfo.LeftX + 10, p_intPosY);
                    p_objGrp.DrawString("术  后  护  理", p_fntNormalText, Brushes.Black, new RectangleF(m_intRecBaseX + 10, p_intPosY - 250, 20, 120));

                    p_intPosY += 5;
                    p_objGrp.DrawString("洗手护士签名:" + (blnIsNull ? "" : m_strGetSingArr("m_lsvWashNurseSign", m_objPrintInfo.m_objRecordContent.objSignerArr)), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 30, p_intPosY);
                    p_objGrp.DrawString("巡回护士签名:" + (blnIsNull ? "" : m_strGetSingArr("m_lsvCircuitNurseSign", m_objPrintInfo.m_objRecordContent.objSignerArr)), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 340, p_intPosY);
                    m_blnIsFirstPrint = false;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2, m_intPatientInfoX, p_intPosY, p_objGrp);

                    p_intPosY += 30;

                    m_intTimes++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    m_blnHaveMoreLine = false;
                }
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnIsFirstPrint = true;

                m_blnHaveMoreLine = true;

                m_intTimes = 0;
            }
        } 
        #endregion
        #endregion

        #region 标题文字部分
        /// <summary>
        /// 打印页脚
        /// </summary>
        /// <param name="e"></param>
        private void m_mthPrintFoot(System.Drawing.Printing.PrintPageEventArgs e)
        {
            float fltOffsetX = 20;//X的偏移量
            Font fntHeader = new Font("SimSun", 12);

            e.Graphics.DrawString("第      页", fntHeader, Brushes.Black, 385 - fltOffsetX, e.PageBounds.Height - 70);
            e.Graphics.DrawString(m_intCurrentPage.ToString(), fntHeader, Brushes.Black, 425 - fltOffsetX, e.PageBounds.Height - 70);
        }
        //打印边框
        private void m_mthPrintHeader(System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font fntTitle = new Font("SimSun", 18, FontStyle.Bold);
            Font fntHeader = new Font("SimSun", 12);

            e.Graphics.DrawRectangle(Pens.Black, m_intRecBaseX, 135, (int)enmRectangleInfo.RightX - (int)enmRectangleInfo.LeftX + 10, e.PageBounds.Height - 220);
            e.Graphics.DrawLine(Pens.Black, m_intRecBaseX + 40, 135, m_intRecBaseX + 40, 135 + e.PageBounds.Height - 220);
        }
        /// <summary>
        /// 标题文字部分
        /// </summary>
        /// <param name="e"></param>
        private void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, m_fotHeaderFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_HospitalName));

            e.Graphics.DrawString("手  术  护  理  记  录", m_fotTitleFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_Name_Title));

            e.Graphics.DrawString("姓名：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name_Title));
            e.Graphics.DrawString(m_objPrintInfo.m_strPatientName, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name));

            e.Graphics.DrawString("性别：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex_Title));
            e.Graphics.DrawString(m_objPrintInfo.m_strSex, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex));

            e.Graphics.DrawString("年龄：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age_Title));
            e.Graphics.DrawString(m_objPrintInfo.m_strAge, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age));

            e.Graphics.DrawString("科室：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name_Title));
            e.Graphics.DrawString(m_objPrintInfo.m_strDeptName, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name));

            e.Graphics.DrawString("床号：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNo_Title));
            e.Graphics.DrawString(m_objPrintInfo.m_strBedName, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNo));	

            e.Graphics.DrawString("住院号：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID_Title));
            e.Graphics.DrawString(m_objPrintInfo.m_strHISInPatientID, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID));
        }
        #endregion

        // 打印结束时的操作
        private void m_mthEndPrintSub(PrintEventArgs p_objPrintArg)
        {
            m_mthResetWhenEndPrint();
        }

        /// <summary>
        /// 每次打印结束之后的复位,无论是打印当前页或者打印全部.
        /// </summary>
        private void m_mthResetWhenEndPrint()
        {
            m_objPrintLineContext.m_mthReset();

            m_intYPos = 155;

            m_intCurrentPage = 1;
        }
    }
}
