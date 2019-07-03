using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;
using com.digitalwave.PatientManagerService;

namespace iCare
{
    class clsEMR_OutHospitalIn24HoursPrintToolCS : infPrintRecord
    {

        private bool m_blnIsFromDataSource = true;//表明是从数据库读取还是从文件直接提取信息
        private bool m_blnWantInit = true;

        private clsOutHospitalIn24HoursDomain m_objRecordsDomain;

        private clsPrintInfo_OutHospitalIn24Hours m_objPrintInfo;

        private clsEMR_OutHospitalIn24HoursValue m_objRecordContentOutIn24 = null;

        /// <summary>
        /// 是否打印修改痕迹
        /// </summary>
        public static bool m_blnIsPrintMark = true;
        //private clsBaseCaseHistoryDomain m_objRecordsDomain;
        //private clsPrintInfo_InPatientCaseHistory m_objPrintInfo;

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
            m_objPrintInfo = new clsPrintInfo_OutHospitalIn24Hours();
            m_objPrintInfo.m_strInPatentID = m_objPatient != null ? m_objPatient.m_StrInPatientID : "";
            m_objPrintInfo.m_strPatientName = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrFirstName : "";
            m_objPrintInfo.m_strSex = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrSex : "";
            m_objPrintInfo.m_strAge = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrAge : "";
            m_objPrintInfo.m_strBedName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName : "";
            m_objPrintInfo.m_strDeptName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjDept.m_StrDeptName : "";
            m_objPrintInfo.m_strAreaName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjLastArea.m_ObjArea.m_StrAreaName : "";
            m_objPrintInfo.m_dtmInPatientDate = p_dtmInPatientDate;
            m_objPrintInfo.m_dtmOpenDate = p_dtmOpenDate;

            m_objPrintInfo.m_strNative = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrNativePlace : "";//籍贯
            m_objPrintInfo.m_strOccupation = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrOccupation : "";//职业
            m_objPrintInfo.m_strIsMarried = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrMarried : "";//婚否
            //m_objPrintInfo.m_StrLinkManFirstName = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrLinkManFirstName : "";//联系人





            m_objPrintInfo.m_strFolk = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrNation : "";//民族
            //m_objPrintInfo. = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrLinkManPhone : "";//电话
            m_objPrintInfo.m_strAddress = m_objPatient != null ? (m_objPatient.m_ObjPeopleInfo.m_StrHomeAddress) : "";//地址

            m_objPrintInfo.m_strHISInPatientID = p_objPatient != null ? p_objPatient.m_StrHISInPatientID : "";


            m_mthGetPrintMarkConfig();
        }

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
        /// 从数据库初始化打印内容。如果没有记录，打印空报表。(当从数据库读取时要调用.)
        /// </summary>
        public void m_mthInitPrintContent()
        {
            m_blnWantInit = false;

            if (m_objPrintInfo == null)
            {
                MDIParent.ShowInformationMessageBox("调用m_mthInitPrintContent之前请首先调用m_mthSetPrintInfo函数");
                return;
            }

            //if (m_objPrintInfo.m_strInPatentID != "")
            //{
            //    m_objRecordsDomain = new clsOutHospitalIn24HoursDomain();
            //    long lngRes = m_objRecordsDomain.m_lngGetRecordContent(m_objPrintInfo.m_strInPatentID, m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), m_objPrintInfo.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"), out m_objPrintInfo.m_objRecordContent);

            //}
            if (m_objPrintInfo.m_strInPatentID == "" || m_objPrintInfo.m_dtmOpenDate == DateTime.MinValue)
                m_objRecordContentOutIn24 = null;
            else
            {
                m_objRecordsDomain = new clsOutHospitalIn24HoursDomain();
                clsTrackRecordContent objContent = new clsTrackRecordContent();
                long lngRes = m_objRecordsDomain.m_lngGetRecordContent(m_objPrintInfo.m_strInPatentID, m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), m_objPrintInfo.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"), out objContent);
                if (lngRes <= 0)
                    return;
                m_objRecordContentOutIn24 = (clsEMR_OutHospitalIn24HoursValue)objContent;
            }
            //设置表单内容到打印中,即使是打印空白单,此行也必须执行.(即:在本函数内部,此行之上不准有return语句,除非出错跳出.)
            //m_mthSetPrintContent(m_objRecordContentOutIn24,DateTime.MinValue);
            m_mthSetPrintContent(m_objRecordContentOutIn24, m_objPrintInfo.m_dtmInPatientDate);

        }
        
        /// <summary>
        /// 设置打印内容。(当数据已经存在时使用。)
        /// </summary>
        /// <param name="p_objPrintContent">打印内容</param>
        public void m_mthSetPrintContent(object p_objPrintContent)
        {
            m_blnWantInit = false;
            if (p_objPrintContent.GetType().Name != "clsPrintInfo_OutHospitalIn24Hours")
            {
                MDIParent.ShowInformationMessageBox("参数错误");
            }
            m_blnIsFromDataSource = false;//表明是从文件直接提取信息
            //m_objPrintInfo = (clsEMR_OutHospitalIn24HoursValue)p_objPrintContent;
            //m_mthSetPrintContent(m_objPrintInfo);
            m_objPrintInfo = (clsPrintInfo_OutHospitalIn24Hours)p_objPrintContent;

            //m_mthSetPrintContent(m_objRecordContentOutIn24,DateTime.MinValue);
            m_mthSetPrintContent((clsEMR_OutHospitalIn24HoursValue)m_objPrintInfo.m_objRecordContent, m_objPrintInfo.m_dtmInPatientDate);

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


            //			m_fotTitleFont = new Font("SimSun", 16,FontStyle.Bold);
            m_fotTitleFont = new Font("SimSun", 15.75F, FontStyle.Bold);//宋体三号加粗
            //			m_fotHeaderFont = new Font("SimSun", 18,FontStyle.Bold);
            m_fotHeaderFont = new Font("SimSun", 10.5F);//宋体五号
            m_fotItemHead = new Font("", 13, FontStyle.Bold);
            m_fotSmallFont = new Font("SimSun", 12);
            m_fotHospitalFont = new Font("宋体", 15, FontStyle.Bold);
            m_fotChildFont = new Font("黑体", 18);
            //m_fotSmallFont = new Font("SimSun", 14.25F);//宋体四号
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
            //m_mthEndPrintSub((PrintEventArgs)p_objPrintArg);
            //if (m_blnIsFromDataSource == false || m_objPrintInfo.m_strInPatentID == "") return;
            ////如果打印成功，查找有无需要更新的时间，如果有，更新时间。 
            //if (!((PrintEventArgs)p_objPrintArg).Cancel)// && m_objPrintInfo.m_blnIsFirstPrint)
            //{
            //    m_objRecordsDomain.m_lngUpdateFirstPrintDate(m_objPrintInfo.m_strInPatentID, m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), m_objPrintInfo.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"), m_objPrintInfo.m_dtmOpenDate);
            //}

            m_mthEndPrintSub((PrintEventArgs)p_objPrintArg);
            if (m_blnIsFromDataSource == false || m_objPrintInfo.m_strInPatentID == "" || m_objPrintInfo.m_objRecordContent == null) return;
            //如果打印成功，查找有无需要更新的时间，如果有，更新时间。 
            if (!((PrintEventArgs)p_objPrintArg).Cancel && m_objPrintInfo.m_objRecordContent.m_dtmFirstPrintDate == DateTime.MinValue)
            {
                m_objRecordsDomain.m_lngUpdateFirstPrintDate(m_objPrintInfo.m_strInPatentID, m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), m_objPrintInfo.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"), m_objPrintInfo.m_objRecordContent.m_dtmFirstPrintDate);
            }
            
        }


        #region 打印

        // 设置打印内容。





        private void m_mthSetPrintContent(clsEMR_OutHospitalIn24HoursValue p_objContent, DateTime p_dtmFirstPrintDate)
        {
            m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
                new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
																		   new clsPrintPatientFixInfo(),
																		   new clsPrintInPatientCaseMain(),
																		   new clsPrintInPatientCaseCurrent(),
																		   new clsPrintInPatientBeforetimeStatus(),
																		   new clsPrintInPatientOwenStatus(),
																		   new clsPrintInPatientMarriageStatus(),
																		   new clsPrintInPatientFamilyStatus(),
																		   new clsPrintInPatientLabStatus(),
                                                                           new clsPrintSign(),

			});
            m_objPrintLineContext.m_ObjPrintSign = new com.digitalwave.Utility.Controls.clsPrintRecordSign();

            object[] objData = new Object[2];
            objData[0] = m_objChangePrintTextColor(p_objContent);
            objData[1] = m_objPrintInfo;

            //设置打印信息，就是Set Value进去
            m_objPrintLineContext.m_ObjPrintLineInfo = objData;
            //将数据库拿出来的FirstPrintDate赋给每个打印行里面的m_DtmFirstPrintTime，在父类里做了





            m_objPrintLineContext.m_DtmFirstPrintTime = p_dtmFirstPrintDate;
        }

        private clsEMR_OutHospitalIn24HoursValue m_objChangePrintTextColor(clsEMR_OutHospitalIn24HoursValue p_objclsInPatientCase)
        {
            if (p_objclsInPatientCase == null)
                return null;
            //把白色变为黑色


            
            clsXML_DataGrid objclsXML_DataGrid = new clsXML_DataGrid();
            p_objclsInPatientCase.m_strMAINDESCRIPTIONXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strMAINDESCRIPTIONXML);
            p_objclsInPatientCase.m_strINHOSPITALINSTANCEXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strINHOSPITALINSTANCEXML);

            p_objclsInPatientCase.m_strINHOSPITALDIAGNOSE1XML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strINHOSPITALDIAGNOSE1XML);
            p_objclsInPatientCase.m_strConfirmReasonXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strConfirmReasonXML);
            p_objclsInPatientCase.m_strConfirmReasonXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strConfirmReasonXML);

            p_objclsInPatientCase.m_strDIAGNOSECORUSEXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strDIAGNOSECORUSEXML);
            p_objclsInPatientCase.m_strOUTHOSPITALINSTANCEXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strOUTHOSPITALINSTANCEXML);
            p_objclsInPatientCase.m_strOUTHOSPITALDIAGNOSE1XML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strOUTHOSPITALDIAGNOSE1XML);

            p_objclsInPatientCase.m_strOUTHOSPITALADVICE1XML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strOUTHOSPITALADVICE1XML);
            //p_objclsInPatientCase.m_strLabCheckXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strLabCheckXML);
            //p_objclsInPatientCase.m_strMainDescriptionXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strMainDescriptionXML);

            //p_objclsInPatientCase.m_strMarriageHistoryXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strMarriageHistoryXML);
            //p_objclsInPatientCase.m_strMedicalXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strMedicalXML);
            //p_objclsInPatientCase.m_strOwnHistoryXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strOwnHistoryXML);

            //p_objclsInPatientCase.m_strPrimaryDiagnoseXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strPrimaryDiagnoseXML);
            //p_objclsInPatientCase.m_strProfessionalCheckXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strProfessionalCheckXML);
            //p_objclsInPatientCase.m_strPulseXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strPulseXML);

            //p_objclsInPatientCase.m_strSummaryXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strSummaryXML);
            //p_objclsInPatientCase.m_strSysXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strSysXML);
            //p_objclsInPatientCase.m_strTemperatureXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strTemperatureXML);

            //p_objclsInPatientCase.m_strCatameniaHistoryXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strCatameniaHistoryXML);

            return p_objclsInPatientCase;
        }



        #region 有关打印的声明






        /// <summary>
        /// 打印一行的内容
        /// </summary>
        private com.digitalwave.Utility.Controls.clsPrintContext m_objPrintLineContext;

        /// <summary>
        /// 打印边框的左边距
        /// </summary>
        private const int m_intRecBaseX = clsPrintPosition.c_intLeftX - 10;
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
        /// 医院标题(宋体，加粗，小三)
        /// </summary>
        private Font m_fotHospitalFont;
        /// <summary>
        /// 副标题(黑体，小二)
        /// </summary>
        private Font m_fotChildFont;


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
        private int m_intYPos = 205;//= (int)enmRectangleInfo.TopY+5;

        /// <summary>
        /// 格子的信息 
        /// </summary>
        public enum enmRectangleInfo
        {

            /// <summary>
            /// 格子的顶端 
            /// </summary>
            TopY = 250,

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

        #region 定义打印各元素的坐标点


        protected class clsPrintPageSettingForRecord
        {
            public clsPrintPageSettingForRecord() { }

            /// <summary>
            /// 获得坐标点 
            /// </summary>
            /// <param name="p_intItemName">项目名称</param>
            /// <returns></returns>
            public PointF m_getCoordinatePoint(int p_intItemName, int m_length)
            {
                Font m_fotHospitalFont = new Font("宋体", 15);
                Font m_fotChildFont = new Font("黑体", 18);

                float fltOffsetX = 10;//X的偏移量
                PointF m_fReturnPoint;
                switch (p_intItemName)
                {

                    case (int)enmItemDefination.Page_HospitalName:
                        m_fReturnPoint = new PointF((340f - fltOffsetX), 120f);
                        break;
                    case (int)enmItemDefination.Page_Name_Title:
                        m_fReturnPoint = new PointF((340f - fltOffsetX), 150f);
                        break;
                    case (int)enmItemDefination.Name_Title:
                        m_fReturnPoint = new PointF((50f - fltOffsetX), 200f);
                        break;
                    case (int)enmItemDefination.Name:
                        m_fReturnPoint = new PointF((100f - fltOffsetX), 200f);
                        break;

                    case (int)enmItemDefination.Sex_Title:
                        m_fReturnPoint = new PointF(175f - fltOffsetX, 200f);
                        break;
                    case (int)enmItemDefination.Sex:
                        m_fReturnPoint = new PointF(230f - fltOffsetX, 200f);
                        break;

                    case (int)enmItemDefination.Age_Title:
                        m_fReturnPoint = new PointF(270f - fltOffsetX, 200f);
                        break;
                    case (int)enmItemDefination.Age:
                        m_fReturnPoint = new PointF(325f - fltOffsetX, 200f);
                        break;

                    case (int)enmItemDefination.Dept_Name_Title:
                        m_fReturnPoint = new PointF(380f, 200f);
                        break;
                    case (int)enmItemDefination.Dept_Name:
                        m_fReturnPoint = new PointF(430f, 200f);
                        break;

                    case (int)enmItemDefination.BedNo_Title:
                        m_fReturnPoint = new PointF(545f, 200f);
                        break;
                    case (int)enmItemDefination.BedNo:
                        m_fReturnPoint = new PointF(595f, 200f);
                        break;

                    case (int)enmItemDefination.InPatientID_Title:
                        m_fReturnPoint = new PointF(655f - fltOffsetX, 200f);
                        break;
                    case (int)enmItemDefination.InPatientID:
                        m_fReturnPoint = new PointF(735f - fltOffsetX, 200f);
                        break;

                    default:
                        m_fReturnPoint = new PointF(400f, 400f);
                        break;

                }
                return m_fReturnPoint;
            }
        }

        #endregion

        /// <summary>
        /// 格子的信息 
        /// </summary>
        private enum enmRectangleInfoInPatientCaseInfo
        {
            /// <summary>
            /// 格子的顶端 
            /// </summary>
            TopY = 300,

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

            PrintWidth = 657,
            PrintWidth2 = 710,

        }


        // 打印开始后，在打印页之前的操作
        private void m_mthBeginPrintSub(PrintEventArgs p_objPrintArg)
        {

        }

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

                if (m_intYPos > p_objPrintPageArg.PageBounds.Height - 200
                    && m_objPrintLineContext.m_BlnHaveMoreLine)
                {
                    //还有数据打印，但需要换页



                    m_mthPrintFoot(p_objPrintPageArg);

                    p_objPrintPageArg.HasMorePages = true;

                    m_intYPos = 235;

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

            //m_intYPos += 30;
            //p_objPrintPageArg.Graphics.DrawString("医师签名:", new Font("SimSun", 12), Brushes.Black, (int)enmRectangleInfo.LeftX + 440, m_intYPos);

            //if (m_objRecordContentOutIn24 != null)
            //{
            //    com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
            //    clsEmrEmployeeBase_VO objEmpVO = null;
            //    objEmployeeSign.m_lngGetEmpByNO(m_objRecordContentOutIn24.m_strDOCTORSIGN, out objEmpVO);
            //    if (objEmpVO != null)
            //        if (!(string.IsNullOrEmpty(objEmpVO.m_strGetTechnicalRankAndName)))
            //            p_objPrintPageArg.Graphics.DrawString(objEmpVO.m_strGetTechnicalRankAndName, new Font("SimSun", 12), Brushes.Black, (int)enmRectangleInfo.LeftX + 440 + (int)(5f * 17.5f), m_intYPos);
            //}



        }


        #region PrintClasses
        private abstract class clsPrintInPatientCaseInfo : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            public clsEMR_OutHospitalIn24HoursValue m_objContent;
            /// <summary>
            /// 文字距离左边的边距 
            /// </summary>
            protected int m_intRecBaseX = clsPrintPosition.c_intLeftX + 20;
            protected int m_intPatientInfoX = 70;
            protected clsPrintInfo_OutHospitalIn24Hours m_objPrintInfo;
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
                    object[] objData = (object[])value;
                    m_objContent = (clsEMR_OutHospitalIn24HoursValue)objData[0];
                    m_objPrintInfo = (clsPrintInfo_OutHospitalIn24Hours)objData[1];
                }
            }
        }

        /// <summary>
        /// 打印第一页的固定内容
        /// </summary>
        private class clsPrintPatientFixInfo : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                p_intPosY += 30;
                p_objGrp.DrawString("                " + m_objPrintInfo.m_strPatientName, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                p_objGrp.DrawString("姓名：", m_fotItemHead, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                p_objGrp.DrawString("                     " + m_objPrintInfo.m_strNative, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);
                p_objGrp.DrawString("出生地：", m_fotItemHead, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

                p_intPosY += 20;
                p_objGrp.DrawString("                " + m_objPrintInfo.m_strSex, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                p_objGrp.DrawString("性别：  ", m_fotItemHead, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);

                p_objGrp.DrawString("                " + m_objPrintInfo.m_strFolk, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);
                p_objGrp.DrawString("民族：", m_fotItemHead, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

                p_intPosY += 20;
                p_objGrp.DrawString("                 " + (m_objPrintInfo == null ? "" : m_objPrintInfo.m_strAge), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                p_objGrp.DrawString("年龄：", m_fotItemHead, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);

                if (m_objPrintInfo.m_dtmInPatientDate != DateTime.MinValue)
                {
                    p_objGrp.DrawString("                             " + m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy年MM月dd日 HH:mm"), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);
                    p_objGrp.DrawString("入院日期：", m_fotItemHead, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

                }
                else
                {

                    p_objGrp.DrawString("入院日期：", m_fotItemHead, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);
                }

                p_intPosY += 20;
                p_objGrp.DrawString("                " + m_objPrintInfo.m_strIsMarried, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                p_objGrp.DrawString("                              " + (m_objContent == null ? "" : m_objContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmInPatientCaseHistory"))), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);
                p_objGrp.DrawString("婚否：", m_fotItemHead, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                p_objGrp.DrawString("记录日期：", m_fotItemHead, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

                p_intPosY += 20;
                p_objGrp.DrawString("                " + m_objPrintInfo.m_strOccupation, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                //p_objGrp.DrawString("                               " + ((m_objContent == null || string.IsNullOrEmpty(m_objContent.m_strRepresentor)) ? "  " : m_objContent.m_strRepresentor) + "                                 " + (m_objContent == null ? "" : m_objContent.m_strCredibility), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);
                p_objGrp.DrawString("职业：", m_fotItemHead, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                p_objGrp.DrawString("病史陈述人：", m_fotItemHead, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);
                //p_objGrp.DrawString("可靠程度：", m_fotItemHead, Brushes.Black, m_intPatientInfoX + 530, p_intPosY);
                string strRepresentor = (m_objContent == null || string.IsNullOrEmpty(m_objContent.m_strREPRESENTOR)) ? "  " : m_objContent.m_strREPRESENTOR;
                if (strRepresentor.Length > 4)
                {
                    p_objGrp.DrawString(strRepresentor.Substring(0, 4), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 470, p_intPosY);
                    p_objGrp.DrawString(strRepresentor.Substring(4), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 470, p_intPosY + 20);
                }
                else
                    p_objGrp.DrawString(strRepresentor, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 470, p_intPosY);
                //p_objGrp.DrawString(m_objContent == null ? "" : m_objContent., p_fntNormalText, Brushes.Black, m_intPatientInfoX + 630, p_intPosY);
                int intRealHeight;
                Rectangle rtgBlock = new Rectangle(m_intPatientInfoX + 350, p_intPosY, (int)enmRectangleInfo.RightX - (m_intPatientInfoX + 350), 30);
                m_objPrintContext.m_blnPrintAllBySimSun(11, rtgBlock, p_objGrp, out intRealHeight, false);

                p_intPosY += 35;
                m_blnHaveMoreLine = false;
                m_blnHasPrintPic = false;
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;
            }
        }


        /// <summary>
        /// 主诉
        /// </summary>
        private class clsPrintInPatientCaseMain : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            int intLine = 0;

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_strMAINDESCRIPTION == "")
                {
                    m_blnHaveMoreLine = false;

                    return;
                }

                if (m_blnIsFirstPrint)
                {
                    //					p_intPosY += 20;

                    p_objGrp.DrawString("主诉：", m_fotItemHead, Brushes.Black, m_intRecBaseX - 10, p_intPosY);
                    if (m_objContent != null)
                    {
                        if (m_objContent.m_strMAINDESCRIPTION.Length == 0)
                        {
                            //							p_intPosY += 30;

                            m_blnHaveMoreLine = false;

                            return;
                        }
                    }

                    if (clsInPatientCaseHistory_F2PrintTool.m_blnIsPrintMark)
                    {
                        m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objContent == null ? "" : m_objContent.m_strMAINDESCRIPTION), (m_objContent == null ? "<root />" : (m_objContent.m_strMAINDESCRIPTIONXML)), m_dtmFirstPrintTime, m_objContent != null);
                        m_mthAddSign2("主诉：", m_objPrintContext.m_ObjModifyUserArr);
                    }
                    else
                    {
                        m_objPrintContext.m_mthSetContextWithAllCorrect((m_objContent == null ? "" : m_objContent.m_strMAINDESCRIPTION), (m_objContent == null ? "<root />" : (m_objContent.m_strMAINDESCRIPTIONXML)));
                    }

                    m_blnIsFirstPrint = false;
                }

                

                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    if (intLine == 0)
                    {
                        m_objPrintContext.m_mthPrintLine((int)(int)enmRectangleInfoInPatientCaseInfo.PrintWidth - 15, m_intRecBaseX + 50, p_intPosY, p_objGrp);
                    }
                    else
                    {
                        m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth+20, m_intRecBaseX + 30, p_intPosY, p_objGrp);

                    }

                    p_intPosY += 25;

                    intLine++;
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

                m_blnHaveMoreLine = true;

                m_blnIsFirstPrint = true;
                intLine = 0;
            }
        }

        /// <summary>
        /// 入院情况 
        /// </summary>
        private class clsPrintInPatientCaseCurrent : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            int intLine = 0;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_strINHOSPITALINSTANCE == "")
                {
                    m_blnHaveMoreLine = false;

                    return;
                }

                if (m_blnIsFirstPrint)
                {

                    p_objGrp.DrawString("入院情况： ", m_fotItemHead, Brushes.Black, m_intRecBaseX - 10, p_intPosY);

                    // p_intPosY += 20;

                    if (m_objContent != null)
                    {
                        if (m_objContent.m_strINHOSPITALINSTANCE.Length == 0)
                        {
                            //							p_intPosY += 30;

                            m_blnHaveMoreLine = false;

                            return;
                        }
                    }

                    if (clsInPatientCaseHistory_F2PrintTool.m_blnIsPrintMark)
                    {
                        m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objContent == null ? "" : m_objContent.m_strINHOSPITALINSTANCE), (m_objContent == null ? "<root />" : m_objContent.m_strINHOSPITALINSTANCEXML), m_dtmFirstPrintTime, m_objContent != null);
                        m_mthAddSign2("入院情况： ", m_objPrintContext.m_ObjModifyUserArr);
                    }
                    else
                    {
                        m_objPrintContext.m_mthSetContextWithAllCorrect((m_objContent == null ? "" : m_objContent.m_strINHOSPITALINSTANCE), (m_objContent == null ? "<root />" : m_objContent.m_strINHOSPITALINSTANCEXML));
                    }

                    m_blnIsFirstPrint = false;
                }


                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    if (intLine == 0)
                    {
                        m_objPrintContext.m_mthPrintLine((int)(int)enmRectangleInfoInPatientCaseInfo.PrintWidth - 50, m_intRecBaseX + 90, p_intPosY, p_objGrp);
                    }
                    else
                    {
                        m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth+20, m_intRecBaseX + 30, p_intPosY, p_objGrp);

                    }
                    p_intPosY += 25;

                    intLine++;
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

                m_blnHaveMoreLine = true;

                m_blnIsFirstPrint = true;
                intLine = 0;

            }
        }

        /// <summary>
        /// 入院诊断 
        /// </summary>
        private class clsPrintInPatientBeforetimeStatus : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;

            private int m_intTimes = 0;

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_strINHOSPITALDIAGNOSE1 == "")
                {
                    m_blnHaveMoreLine = false;

                    return;
                }

                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("入院诊断： ", m_fotItemHead, Brushes.Black, m_intRecBaseX - 10, p_intPosY);

                    //p_intPosY += 20;

                    if (m_objContent != null)
                    {
                        if (m_objContent.m_strINHOSPITALDIAGNOSE1.Length == 0)
                        {
                            //							p_intPosY += 30;

                            m_blnHaveMoreLine = false;

                            return;
                        }
                    }
                    else
                    {
                        //						p_intPosY += 30;

                        m_blnHaveMoreLine = false;

                        return;
                    }

                    if (clsInPatientCaseHistory_F2PrintTool.m_blnIsPrintMark)
                    {
                        m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objContent == null ? "" : m_objContent.m_strINHOSPITALDIAGNOSE1), (m_objContent == null ? "<root />" : m_objContent.m_strINHOSPITALDIAGNOSE1XML), m_dtmFirstPrintTime, m_objContent != null);
                        m_mthAddSign2("入院诊断： ", m_objPrintContext.m_ObjModifyUserArr);
                    }
                    else
                    {
                        m_objPrintContext.m_mthSetContextWithAllCorrect((m_objContent == null ? "" : m_objContent.m_strINHOSPITALDIAGNOSE1), (m_objContent == null ? "<root />" : m_objContent.m_strINHOSPITALDIAGNOSE1XML));
                    }

                    m_blnIsFirstPrint = false;

                }


                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    if (m_intTimes == 0)
                    {
                        m_objPrintContext.m_mthPrintLine((int)(int)enmRectangleInfoInPatientCaseInfo.PrintWidth - 50, m_intRecBaseX + 90, p_intPosY, p_objGrp);
                    }
                    else
                    {
                        m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth + 20, m_intRecBaseX + 30, p_intPosY, p_objGrp);

                    }
                    p_intPosY += 25;

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

        /// <summary>
        /// 个人史 
        /// </summary>
        private class clsPrintInPatientOwenStatus : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;

            private int m_intTimes = 0;

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_strDIAGNOSECORUSE == "" || MDIParent.m_EnmCaseType == frmInPatientCaseHistory.enmCaseType.产科)
                {
                    m_blnHaveMoreLine = false;

                    return;
                }

                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("诊疗经过： ", m_fotItemHead, Brushes.Black, m_intRecBaseX - 10, p_intPosY);

                    //p_intPosY += 20;

                    if (m_objContent != null)
                    {
                        if (m_objContent.m_strDIAGNOSECORUSE.Length == 0)
                        {
                            //							p_intPosY += 60;

                            m_blnHaveMoreLine = false;

                            return;
                        }
                    }
                    else
                    {
                        //						p_intPosY += 60;

                        m_blnHaveMoreLine = false;

                        return;
                    }
                    if (clsInPatientCaseHistory_F2PrintTool.m_blnIsPrintMark)
                    {
                        m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objContent == null ? "" : m_objContent.m_strDIAGNOSECORUSE), (m_objContent == null ? "<root />" : m_objContent.m_strDIAGNOSECORUSEXML), m_dtmFirstPrintTime, m_objContent != null);
                        m_mthAddSign2("诊疗经过： ", m_objPrintContext.m_ObjModifyUserArr);
                    }
                    else
                    {
                        m_objPrintContext.m_mthSetContextWithAllCorrect((m_objContent == null ? "" : m_objContent.m_strDIAGNOSECORUSE), (m_objContent == null ? "<root />" : m_objContent.m_strDIAGNOSECORUSEXML));
                    }

                    m_blnIsFirstPrint = false;

                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    if (m_intTimes == 0)
                    {
                        m_objPrintContext.m_mthPrintLine((int)(int)enmRectangleInfoInPatientCaseInfo.PrintWidth - 50, m_intRecBaseX + 90, p_intPosY, p_objGrp);
                    }
                    else
                    {
                        m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth + 20, m_intRecBaseX + 30, p_intPosY, p_objGrp);

                    }
                    p_intPosY += 25;

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
        /// <summary>
        /// 出院情况 
        /// </summary>
        private class clsPrintInPatientMarriageStatus : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;

            private int m_intTimes = 0;

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_strOUTHOSPITALINSTANCE == "")
                {
                    m_blnHaveMoreLine = false;

                    return;
                }

                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("出院情况： ", m_fotItemHead, Brushes.Black, m_intRecBaseX - 10, p_intPosY);

                    // p_intPosY += 20;

                    if (m_objContent != null)
                    {
                        if (m_objContent.m_strOUTHOSPITALINSTANCE.Length == 0)
                        {
                            //							p_intPosY += 60;

                            m_blnHaveMoreLine = false;

                            return;
                        }
                    }
                    else
                    {
                        //						p_intPosY += 60;

                        m_blnHaveMoreLine = false;

                        return;
                    }
                    if (clsInPatientCaseHistory_F2PrintTool.m_blnIsPrintMark)
                    {
                        m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objContent == null ? "" : m_objContent.m_strOUTHOSPITALINSTANCE), (m_objContent == null ? "<root />" : m_objContent.m_strOUTHOSPITALINSTANCEXML), m_dtmFirstPrintTime, m_objContent != null);
                        m_mthAddSign2("出院情况： ", m_objPrintContext.m_ObjModifyUserArr);
                    }
                    else
                    {
                        m_objPrintContext.m_mthSetContextWithAllCorrect((m_objContent == null ? "" : m_objContent.m_strOUTHOSPITALINSTANCE), (m_objContent == null ? "<root />" : m_objContent.m_strOUTHOSPITALINSTANCEXML));
                    }

                    m_blnIsFirstPrint = false;

                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    if (m_intTimes == 0)
                    {
                        m_objPrintContext.m_mthPrintLine((int)(int)enmRectangleInfoInPatientCaseInfo.PrintWidth - 50, m_intRecBaseX + 90, p_intPosY, p_objGrp);
                    }
                    else
                    {
                        m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth + 20, m_intRecBaseX + 30, p_intPosY, p_objGrp);

                    }
                    p_intPosY += 25;

                    m_intTimes++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    m_blnHaveMoreLine = false;
                    //if (p_intPosY > (int)enmRectangleInfo.BottomY - 100)//避免下一个打印内容超出底线




                    //    p_intPosY += 20;
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


        /// <summary>
        ///出院诊断 
        /// </summary>
        private class clsPrintInPatientFamilyStatus : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private bool m_blnIsFirstPrint = true;

            private int m_intTimes = 0;

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_strOUTHOSPITALDIAGNOSE1 == "")
                {
                    m_blnHaveMoreLine = false;

                    return;
                }

                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("出院诊断： ", m_fotItemHead, Brushes.Black, m_intRecBaseX - 10, p_intPosY);

                    //p_intPosY += 20;

                    if (m_objContent != null)
                    {
                        if (m_objContent.m_strOUTHOSPITALDIAGNOSE1.Length == 0)
                        {
                            //							p_intPosY += 60;

                            m_blnHaveMoreLine = false;

                            return;
                        }
                    }
                    else
                    {
                        //						p_intPosY += 60;

                        m_blnHaveMoreLine = false;

                        return;
                    }
                    if (clsInPatientCaseHistory_F2PrintTool.m_blnIsPrintMark)
                    {
                        m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objContent == null ? "" : m_objContent.m_strOUTHOSPITALDIAGNOSE1), (m_objContent == null ? "<root />" : m_objContent.m_strOUTHOSPITALDIAGNOSE1XML), m_dtmFirstPrintTime, m_objContent != null);
                       // m_mthAddSign2("出院诊断： ", m_objPrintContext.m_ObjModifyUserArr);
                    }
                    else
                    {
                        m_objPrintContext.m_mthSetContextWithAllCorrect((m_objContent == null ? "" : m_objContent.m_strOUTHOSPITALDIAGNOSE1), (m_objContent == null ? "<root />" : m_objContent.m_strOUTHOSPITALDIAGNOSE1XML));
                    }


                    m_blnIsFirstPrint = false;

                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    if (m_intTimes == 0)
                    {
                        m_objPrintContext.m_mthPrintLine((int)(int)enmRectangleInfoInPatientCaseInfo.PrintWidth - 50, m_intRecBaseX + 90, p_intPosY, p_objGrp);
                    }
                    else
                    {
                        m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth + 20, m_intRecBaseX + 30, p_intPosY, p_objGrp);

                    }
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

        /// <summary>
        /// 出院医嘱 
        /// </summary>
        private class clsPrintInPatientLabStatus : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private bool m_blnIsFirstPrint = true;

            private int m_intTimes = 0;

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_strOUTHOSPITALADVICE1 == "")
                {
                    m_blnHaveMoreLine = false;

                    return;
                }

                if (m_blnIsFirstPrint)
                {
                    p_intPosY += 20;
                    p_objGrp.DrawString("出院医嘱： ", m_fotItemHead, Brushes.Black, m_intRecBaseX - 10, p_intPosY);

                    //p_intPosY += 20;
                    if (m_objContent != null)
                    {
                        if (m_objContent.m_strOUTHOSPITALADVICE1.Length == 0)
                        {
                            //							p_intPosY += 30;

                            m_blnHaveMoreLine = false;

                            return;
                        }
                    }
                    else
                    {
                        p_intPosY += 30;

                        m_blnHaveMoreLine = false;

                        return;
                    }
                    if (clsInPatientCaseHistory_F2PrintTool.m_blnIsPrintMark)
                    {
                        m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objContent == null ? "" : m_objContent.m_strOUTHOSPITALADVICE1), (m_objContent == null ? "<root />" : m_objContent.m_strOUTHOSPITALADVICE1XML), m_dtmFirstPrintTime, m_objContent != null);
                        m_mthAddSign2("出院医嘱： ", m_objPrintContext.m_ObjModifyUserArr);
                    }
                    else
                    {
                        m_objPrintContext.m_mthSetContextWithAllCorrect((m_objContent == null ? "" : m_objContent.m_strOUTHOSPITALADVICE1), (m_objContent == null ? "<root />" : m_objContent.m_strOUTHOSPITALADVICE1XML));
                    }

                    m_blnIsFirstPrint = false;

                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    if (m_intTimes == 0)
                    {
                        m_objPrintContext.m_mthPrintLine((int)(int)enmRectangleInfoInPatientCaseInfo.PrintWidth - 50, m_intRecBaseX + 90, p_intPosY, p_objGrp);
                    }
                    else
                    {
                        m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 30, p_intPosY, p_objGrp);

                    }
                    p_intPosY += 25;

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

        /// <summary>
        ///签名
        /// </summary>
        private class clsPrintSign : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null )
                {
                    m_blnHaveMoreLine = false;

                    return;
                }
                if (p_intPosY + 80 > (int)enmRectangleInfo.BottomY)
                {
                    m_blnHaveMoreLine = true;
                    p_intPosY += 500;
                    return;
                }
                p_intPosY += 25;
                if (m_objContent != null)
                {
                    com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
                    clsEmrEmployeeBase_VO objEmpVO = null;
                    objEmployeeSign.m_lngGetEmpByNO(m_objContent.m_strDOCTORSIGN, out objEmpVO);
                    if (objEmpVO != null)
                    {
                        Image imgEmpSig = ImageSignature.GetEmpSigImage(objEmpVO.m_strLASTNAME_VCHR);
                        if (imgEmpSig != null)
                        {
                            //imgEmpSig = ImageSignature.pictureProcess(imgEmpSig, 579, 268);
                            p_objGrp.DrawString(objEmpVO.m_strTechnicalRank, new Font("SimSun", 12, FontStyle.Bold), Brushes.Black, (int)enmRectangleInfo.LeftX + 440, p_intPosY);
                            p_objGrp.DrawImage(imgEmpSig, (int)enmRectangleInfo.LeftX + 540, p_intPosY - 7, 70, 30);
                        }
                        else
                        {
                            if (!(string.IsNullOrEmpty(objEmpVO.m_strGetTechnicalRankAndName)))
                                p_objGrp.DrawString(objEmpVO.m_strGetTechnicalRankAndName, new Font("SimSun", 12, FontStyle.Bold), Brushes.Black, (int)enmRectangleInfo.LeftX + 440, p_intPosY);
                        }
                    }
                }

                p_intPosY += 30;
                p_objGrp.DrawString("记录日期：", new Font("SimSun", 12), Brushes.Black, (int)enmRectangleInfo.LeftX + 440, p_intPosY);
                if (m_objContent != null)
                    p_objGrp.DrawString(m_objContent.m_dtmRECORDDATE.ToString("yyyy年MM月dd日HH时mm分"), new Font("SimSun", 12), Brushes.Black, (int)enmRectangleInfo.LeftX + 440 + (int)(5f * 17.5f), p_intPosY);
                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;

                //打印预览或者打印后都得重置
                m_intCurrentPic = 0;
            }
        }



        #region 标题文字部分
        /// <summary>
        /// 打印页脚
        /// </summary>
        /// <param name="e"></param>
        private void m_mthPrintFoot(System.Drawing.Printing.PrintPageEventArgs e)
        {
            float fltOffsetX = 20;//X的偏移量
            Font fntHeader = new Font("SimSun", 12);

            e.Graphics.DrawString("第      页", fntHeader, Brushes.Black, 385 - fltOffsetX, e.PageBounds.Height - 165);
            e.Graphics.DrawString(m_intCurrentPage.ToString(), fntHeader, Brushes.Black, 425 - fltOffsetX, e.PageBounds.Height - 165);
        }
        //打印边框
        private void m_mthPrintHeader(System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font fntTitle = new Font("SimSun", 18);//, FontStyle.Bold
            Font fntHeader = new Font("SimSun", 12);

            e.Graphics.DrawRectangle(Pens.Black, m_intRecBaseX + 10, 225, (int)enmRectangleInfo.RightX - (int)enmRectangleInfo.LeftX - 15, e.PageBounds.Height - 400);

        }
        /// <summary>
        /// 标题文字部分
        /// </summary>
        /// <param name="e"></param>
        private void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
        {
            SizeF m_szfHospitalTitle = e.Graphics.MeasureString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, m_fotHospitalFont);
            SizeF m_szfChildTitle = e.Graphics.MeasureString("24小时内入出院记录", m_fotChildFont);
            int m_intChildTitleNameOffSetX = (int)(m_szfHospitalTitle.Width / 2 + m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_HospitalName, 0).X - m_szfChildTitle.Width / 2 + 4);
            e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, m_fotHospitalFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_HospitalName, clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle.Length));

            e.Graphics.DrawString("24小时内入出院记录", m_fotChildFont, m_slbBrush, m_intChildTitleNameOffSetX, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_Name_Title, 0).Y);

            e.Graphics.DrawString("姓名：    ", m_fotItemHead, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name_Title, 0));
            e.Graphics.DrawString(m_objPrintInfo.m_strPatientName, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name, 0));

            e.Graphics.DrawString("性别：     ", m_fotItemHead, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex_Title, 0));
            e.Graphics.DrawString(m_objPrintInfo.m_strSex, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex, 0));

            e.Graphics.DrawString("年龄：     ", m_fotItemHead, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age_Title, 0));
            e.Graphics.DrawString(m_objPrintInfo.m_strAge, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age, 0));

            e.Graphics.DrawString("病区：     ", m_fotItemHead, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name_Title, 0));
            e.Graphics.DrawString(m_objPrintInfo.m_strDeptName, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name, 0));

            e.Graphics.DrawString("床号：     ", m_fotItemHead, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNo_Title, 0));
            e.Graphics.DrawString(m_objPrintInfo.m_strBedName, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNo, 0));

            e.Graphics.DrawString("住院号：     ", m_fotItemHead, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID_Title, 0));
            e.Graphics.DrawString(m_objPrintInfo.m_strHISInPatientID, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID, 0));

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

            m_intYPos = 200;

            m_intCurrentPage = 1;
        }



        #endregion
        #endregion


    }
}
