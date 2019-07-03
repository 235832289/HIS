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
    /// 入院记录(新疆)打印工具类
    /// </summary>
    public class clsInPatientCaseHistory_XJPrintTool : infPrintRecord
    {
        private bool m_blnIsFromDataSource = true;//表明是从数据库读取还是从文件直接提取信息
        private bool m_blnWantInit = true;
        /// <summary>
        /// 是否打印修改痕迹
        /// </summary>
        public static bool m_blnIsPrintMark = true;
        private clsBaseCaseHistoryDomain m_objRecordsDomain;
        private clsPrintInfo_InPatientCaseHistory m_objPrintInfo;
        private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain m_objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();

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
            m_objPrintInfo = new clsPrintInfo_InPatientCaseHistory();
            m_objPrintInfo.m_strInPatentID = m_objPatient != null ? m_objPatient.m_StrInPatientID : "";
            m_objPrintInfo.m_strPatientName = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrFirstName : "";
            m_objPrintInfo.m_strSex = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrSex : "";
            m_objPrintInfo.m_strAge = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrAge : "";
            m_objPrintInfo.m_strBedName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName : "";
            m_objPrintInfo.m_strDeptName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjDept.m_StrDeptName : "";
            m_objPrintInfo.m_strAreaName = m_objPatient != null ? m_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjLastArea.m_ObjArea.m_StrAreaName : "";
            m_objPrintInfo.m_dtmInPatientDate = p_dtmInPatientDate;
            m_objPrintInfo.m_dtmOpenDate = p_dtmOpenDate;

            m_objPrintInfo.m_strHomeplace = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrHomeplace : "";//出生地
            m_objPrintInfo.m_strNativePlace = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrNativePlace : "";//籍贯
            m_objPrintInfo.m_strOccupation = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrOccupation : "";//职业
            m_objPrintInfo.m_strMarried = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrMarried : "";//婚否
            m_objPrintInfo.m_StrLinkManFirstName = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrLinkManFirstName : "";//联系人
            m_objPrintInfo.m_strNationality = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrNation : "";//民族
            m_objPrintInfo.m_strHomePhone = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrLinkManPhone : "";//电话
            m_objPrintInfo.m_strHomeAddress = m_objPatient != null ? (m_objPatient.m_ObjPeopleInfo.m_StrHomeAddress) : "";//地址

            m_objPrintInfo.m_strHISInPatientID = p_objPatient != null ? p_objPatient.m_StrHISInPatientID : "";
            m_objPrintInfo.m_dtmHISInPatientDate = p_objPatient != null ? p_objPatient.m_DtmSelectedHISInDate : DateTime.MinValue;

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

            if (m_objPrintInfo.m_strInPatentID != ""/* && m_objPrintInfo.m_dtmOpenDate != DateTime.MinValue*/)
            {
                m_objRecordsDomain = new clsBaseCaseHistoryDomain(enmBaseCaseHistoryTypeInfo.InPatientCaseHistory);
                long lngRes = m_objRecordsDomain.m_lngGetPrintInfo(m_objPrintInfo.m_strInPatentID, m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),/*m_objPrintInfo.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"),*/DateTime.MinValue, out m_objPrintInfo.m_objContent, out m_objPrintInfo.m_objPicValueArr, out m_objPrintInfo.m_dtmFirstPrintDate, out m_objPrintInfo.m_blnIsFirstPrint);
                //				if(lngRes <= 0)
                //					return ;
            }
            //设置表单内容到打印中,即使是打印空白单,此行也必须执行.(即:在本函数内部,此行之上不准有return语句,除非出错跳出.)
            m_mthSetPrintContent((clsInPatientCaseHistoryContent)m_objPrintInfo.m_objContent, m_objPrintInfo.m_dtmFirstPrintDate);

        }

        /// <summary>
        /// 设置打印内容。(当数据已经存在时使用。)
        /// </summary>
        /// <param name="p_objPrintContent">打印内容</param>
        public void m_mthSetPrintContent(object p_objPrintContent)
        {
            m_blnWantInit = false;
            if (p_objPrintContent.GetType().Name != "clsPrintInfo_InPatientCaseHistory")
            {
                MDIParent.ShowInformationMessageBox("参数错误");
            }
            m_blnIsFromDataSource = false;//表明是从文件直接提取信息
            m_objPrintInfo = (clsPrintInfo_InPatientCaseHistory)p_objPrintContent;

            m_mthSetPrintContent((clsInPatientCaseHistoryContent)m_objPrintInfo.m_objContent, m_objPrintInfo.m_dtmFirstPrintDate);
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
            if (m_objPrintInfo.m_objContent == null)
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
            //			m_fotSmallFont = new Font("SimSun",12);
            m_fotSmallFont = new Font("SimSun", 14.25F);//宋体四号
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
                m_objRecordsDomain.m_lngUpdateFirstPrintDate(m_objPrintInfo.m_strInPatentID, m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), m_objPrintInfo.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"), m_objPrintInfo.m_dtmFirstPrintDate);
            }
        }


        #region 打印

        // 设置打印内容。
        private void m_mthSetPrintContent(clsInPatientCaseHistoryContent p_objContent, DateTime p_dtmFirstPrintDate)
        {
            m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
                new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
																		   new clsPrintPatientFixInfo(),
                                                                           new clsPrintSolarTerms(),
																		   new clsPrintInPatientCaseMain(),
																		   new clsPrintInPatientCaseCurrent(),
																		   new clsPrintInPatientBeforetimeStatus(),
																		   new clsPrintInPatientOwenStatus(),
																		   new clsPrintInPatientMarriageStatus(),
																		   new clsPrintInPatientCaseCatameniaHistory(),
                                                                           new clsPrintInPatientCaseCatameniaHistory2(),
					  													   new clsPrintInPatientFamilyStatus(),
																		   new clsPrintInPatientBodyChekcFixStatus(),
																		   new clsPrintInPatientLabStatus(),
																		   new clsPrintPatientDiagnoseTitleInfo(),
																		   new clsPrintIniDiagnose_CHNInfo(),
																		   new clsPrintIniDiagnoseInfo(),
																		   new clsPrintIniDiagnoseName(),
																		   new clsPrintAddDiagnoseTitleInfo(),
																		   new clsPrintAddDiagnose_CHNInfo(),
																		   new clsPrintAddDiagnoseInfo(),
																		   new clsPrintAddDiagnoseNameAndDate(),
								                                           new clsPrintPic()
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

        private clsInPatientCaseHistoryContent m_objChangePrintTextColor(clsInPatientCaseHistoryContent p_objclsInPatientCase)
        {
            if (p_objclsInPatientCase == null)
                return null;
            //把白色变为黑色
            clsXML_DataGrid objclsXML_DataGrid = new clsXML_DataGrid();
            p_objclsInPatientCase.m_strBeforetimeStatusXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strBeforetimeStatusXML);
            //p_objclsInPatientCase.m_strBloodPressureUnitXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strBloodPressureUnitXML);

            //p_objclsInPatientCase.m_strBreathXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strBreathXML);
            p_objclsInPatientCase.m_strConfirmReasonXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strConfirmReasonXML);
            p_objclsInPatientCase.m_strConfirmReasonXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strConfirmReasonXML);

            p_objclsInPatientCase.m_strCurrentStatusXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strCurrentStatusXML);
            //p_objclsInPatientCase.m_strDiaXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strDiaXML);
            p_objclsInPatientCase.m_strFamilyHistoryXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strFamilyHistoryXML);

            //p_objclsInPatientCase.m_strFinallyDiagnoseXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strFinallyDiagnoseXML);
            p_objclsInPatientCase.m_strLabCheckXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strLabCheckXML);
            p_objclsInPatientCase.m_strMainDescriptionXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strMainDescriptionXML);

            p_objclsInPatientCase.m_strMarriageHistoryXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strMarriageHistoryXML);
            //p_objclsInPatientCase.m_strMedicalXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strMedicalXML);
            p_objclsInPatientCase.m_strOwnHistoryXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strOwnHistoryXML);

            //p_objclsInPatientCase.m_strPrimaryDiagnoseXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strPrimaryDiagnoseXML);
            //p_objclsInPatientCase.m_strProfessionalCheckXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strProfessionalCheckXML);
            //p_objclsInPatientCase.m_strPulseXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strPulseXML);

            //p_objclsInPatientCase.m_strSummaryXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strSummaryXML);
            //p_objclsInPatientCase.m_strSysXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strSysXML);
            //p_objclsInPatientCase.m_strTemperatureXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strTemperatureXML);

            p_objclsInPatientCase.m_strCatameniaHistoryXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strCatameniaHistoryXML);

            p_objclsInPatientCase.m_strINIDIAGNOSIS_CHNXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strINIDIAGNOSIS_CHNXML);
            p_objclsInPatientCase.m_strINIDIAGNOSISXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strINIDIAGNOSISXML);
            p_objclsInPatientCase.m_strADDDIAGNOSE_CHNXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strADDDIAGNOSE_CHNXML);
            p_objclsInPatientCase.m_strAddDiagnoseXML = objclsXML_DataGrid.m_strReplaceWhiteToBlack(p_objclsInPatientCase.m_strAddDiagnoseXML);

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
        private int m_intYPos = 155;//= (int)enmRectangleInfo.TopY+5;

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
                        m_fReturnPoint = new PointF(280f - fltOffsetX, 70f);
                        break;
                    case (int)enmItemDefination.Name_Title:
                        m_fReturnPoint = new PointF(50f - fltOffsetX, 110f);
                        break;
                    case (int)enmItemDefination.Name:
                        m_fReturnPoint = new PointF(100f - fltOffsetX, 110f);
                        break;

                    case (int)enmItemDefination.Sex_Title:
                        m_fReturnPoint = new PointF(180f - fltOffsetX, 110f);
                        break;
                    case (int)enmItemDefination.Sex:
                        m_fReturnPoint = new PointF(230f - fltOffsetX, 110f);
                        break;

                    case (int)enmItemDefination.Age_Title:
                        m_fReturnPoint = new PointF(280f - fltOffsetX, 110f);
                        break;
                    case (int)enmItemDefination.Age:
                        m_fReturnPoint = new PointF(330f - fltOffsetX, 110f);
                        break;

                    case (int)enmItemDefination.Dept_Name_Title:
                        m_fReturnPoint = new PointF(400f, 110f);
                        break;
                    case (int)enmItemDefination.Dept_Name:
                        m_fReturnPoint = new PointF(450f, 110f);
                        break;

                    case (int)enmItemDefination.BedNo_Title:
                        m_fReturnPoint = new PointF(570f, 110f);
                        break;
                    case (int)enmItemDefination.BedNo:
                        m_fReturnPoint = new PointF(620f, 110f);
                        break;

                    case (int)enmItemDefination.InPatientID_Title:
                        m_fReturnPoint = new PointF(670f - fltOffsetX, 110f);
                        break;
                    case (int)enmItemDefination.InPatientID:
                        m_fReturnPoint = new PointF(735f - fltOffsetX, 110f);
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

            PrintWidth = 670,
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

                if (m_intYPos > p_objPrintPageArg.PageBounds.Height - 225
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


        #region PrintClasses
        private abstract class clsPrintInPatientCaseInfo : com.digitalwave.Utility.Controls.clsPrintLineBase
        {
            protected clsInPatientCaseHistoryContent m_objContent;
            /// <summary>
            /// 文字距离左边的边距
            /// </summary>
            protected int m_intRecBaseX = clsPrintPosition.c_intLeftX;
            protected int m_intPatientInfoX = 70;
            protected clsPrintInfo_InPatientCaseHistory m_objPrintInfo;
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
                    m_objContent = (clsInPatientCaseHistoryContent)objData[0];
                    m_objPrintInfo = (clsPrintInfo_InPatientCaseHistory)objData[1];
                }
            }

            protected void m_mthPrintPic(System.Drawing.Graphics p_objGrp, ref int p_intPosY)
            {
                if (m_objPrintInfo.m_objPicValueArr != null && m_objPrintInfo.m_objPicValueArr.Length > 0)
                {
                    int intPicHeight = m_objPrintInfo.m_objPicValueArr[0].intHeight;
                    int intPicWidth = m_objPrintInfo.m_objPicValueArr[0].intWidth;

                    if (p_intPosY + intPicHeight > 844)
                    {
                        p_intPosY -= 20;
                        return;
                    }
                    else
                    {
                        int intLeft = m_intRecBaseX + 10;
                        for (int i = m_intCurrentPic; i < m_objPrintInfo.m_objPicValueArr.Length; i++)
                        {
                            System.IO.MemoryStream objStream = new System.IO.MemoryStream((byte[])m_objPrintInfo.m_objPicValueArr[i].m_bytImage);
                            Image imgPrint = new Bitmap(objStream);

                            p_objGrp.DrawImage(imgPrint, intLeft, p_intPosY);
                            intLeft += m_objPrintInfo.m_objPicValueArr[i].intWidth + 10;

                            //还有图片要打
                            if (i + 1 < m_objPrintInfo.m_objPicValueArr.Length && p_intPosY + intPicHeight <= 844)
                            {
                                //图片超过一行
                                if ((int)enmRectangleInfo.RightX - intLeft < intPicWidth)
                                {
                                    m_blnHaveMoreLine = true;
                                    p_intPosY += intPicHeight + 20;
                                    intLeft = m_intRecBaseX + 10;
                                    m_intCurrentPic = i + 1;
                                    return;
                                }
                            }
                            if (i + 1 == m_objPrintInfo.m_objPicValueArr.Length)
                            {
                                m_blnHasPrintPic = true;
                            }
                        }
                    }

                    p_intPosY += intPicHeight + 5;

                }
                else
                {
                    p_intPosY -= 20;
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
                #region Title

                //p_objGrp.DrawString("入 院 记 录",clsInPatientCaseHistory_XJPrintTool.m_fotItemHead,Brushes.Black,m_intRecBaseX+310,p_intPosY - 10);
                p_objGrp.DrawString("XHTCM/RD-104", p_fntNormalText, Brushes.Black, m_intPatientInfoX - 40, p_intPosY - 150);

                p_intPosY -= 10;
                p_objGrp.DrawString("姓名：" + m_objPrintInfo.m_strPatientName, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                //p_objGrp.DrawString("记录日期：" + (m_objContent == null ? "" : m_objContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmInPatientCaseHistory"))), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);
                p_objGrp.DrawString("职业：" + m_objPrintInfo.m_strOccupation, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

                p_intPosY += 20;
                p_objGrp.DrawString("性别：" + m_objPrintInfo.m_strSex, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                //p_objGrp.DrawString("病史陈述人和可靠程度：" + (m_objContent == null ? "" : m_objContent.m_strRepresentor + "," + m_objContent.m_strCredibility), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);
                p_objGrp.DrawString("出生地：" + m_objPrintInfo.m_strNativePlace, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

                p_intPosY += 20;
                p_objGrp.DrawString("年龄：" + (m_objPrintInfo == null ? "" : m_objPrintInfo.m_strAge), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                //p_objGrp.DrawString("病史记录者：" + (m_objContent == null ? "" : new clsEmployee(m_objContent.m_strModifyUserID).m_StrFirstName), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);
                if (m_objPrintInfo.m_dtmInPatientDate != DateTime.MinValue)
                {
                    p_objGrp.DrawString("入院日期：" + m_objPrintInfo.m_dtmHISInPatientDate.ToString("yyyy年MM月dd日"), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);
                }
                else
                {
                    p_objGrp.DrawString("入院日期：", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);
                }

                p_intPosY += 20;
                p_objGrp.DrawString("民族：" + m_objPrintInfo.m_strNationality, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                //p_objGrp.DrawString("床号：" + m_objPrintInfo.m_strAreaName + m_objPrintInfo.m_strBedName, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);
                p_objGrp.DrawString("记录日期：" + (m_objContent == null ? "" : m_objContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmInPatientCaseHistory"))), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

                //p_intPosY += 20;
                //p_objGrp.DrawString("职业：" + m_objPrintInfo.m_strOccupation, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                //p_objGrp.DrawString("住院号：" + m_objPrintInfo.m_strHISInPatientID, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

                p_intPosY += 20;
                p_objGrp.DrawString("婚否：" + m_objPrintInfo.m_strMarried, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                p_objGrp.DrawString("病史陈述人和可靠程度：" + (m_objContent == null ? "" : m_objContent.m_strRepresentor + "," + m_objContent.m_strCredibility), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);
                //p_objGrp.DrawString("联系人：" + m_objPrintInfo.m_StrLinkManFirstName, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

                //p_intPosY += 20;
                //p_objGrp.DrawString("民族：" + m_objPrintInfo.m_strNationality, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                //p_objGrp.DrawString("电话：" + m_objPrintInfo.m_strHomePhone, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);

                //p_intPosY += 20;
                //if (m_objPrintInfo.m_dtmInPatientDate != DateTime.MinValue)
                //{
                //    p_objGrp.DrawString("入院日期：" + m_objPrintInfo.m_dtmHISInPatientDate.ToString("yyyy年MM月dd日"), p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                //}
                //else
                //{
                //    p_objGrp.DrawString("入院日期：", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                //}
                //m_objPrintContext.m_mthSetContextWithAllCorrect("地址：" + m_objPrintInfo.m_strHomeAddress, "<root />");

                int intRealHeight;
                Rectangle rtgBlock = new Rectangle(m_intPatientInfoX + 350, p_intPosY, (int)enmRectangleInfo.RightX - (m_intPatientInfoX + 350), 30);
                m_objPrintContext.m_blnPrintAllBySimSun(11, rtgBlock, p_objGrp, out intRealHeight, false);

                p_intPosY += 20;
                m_blnHaveMoreLine = false;
                m_blnHasPrintPic = false;

                #endregion
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;
            }
        }

        /// <summary>
        /// 发病节气及医保号
        /// </summary>
        private class clsPrintSolarTerms : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext1 = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                string strSolarTerms = string.Empty;
                string strMedicareNO = string.Empty;
                if (m_objContent != null)
                {
                    strSolarTerms = m_objContent.m_strSOLARTERMS;
                    strMedicareNO = m_objContent.m_strMEDICARENO;
                }

                p_objGrp.DrawString("发病节气：" + strSolarTerms, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 50, p_intPosY);
                p_objGrp.DrawString("医保号：" + strMedicareNO, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 350, p_intPosY);
                p_intPosY += 30;
                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_objPrintContext1.m_mthRestartPrint();

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

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_strMainDescription == "")
                {
                    p_objGrp.DrawString("主诉：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY); 
                    p_intPosY += 20;
                    m_blnHaveMoreLine = false;

                    return;
                }

                if (m_blnIsFirstPrint)
                {
                    //					p_intPosY += 20;

                    p_objGrp.DrawString("主诉：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    if (m_objContent != null)
                    {
                        if (m_objContent.m_strMainDescriptionAll.Length == 0)
                        {
                            //							p_intPosY += 30;

                            m_blnHaveMoreLine = false;

                            return;
                        }
                    }

                    if (clsInPatientCaseHistory_XJPrintTool.m_blnIsPrintMark)
                    {
                        m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objContent == null ? "" : m_objContent.m_strMainDescriptionAll), (m_objContent == null ? "<root />" : m_objContent.m_strMainDescriptionXML), m_dtmFirstPrintTime, m_objContent != null);
                        m_mthAddSign2("主诉：", m_objPrintContext.m_ObjModifyUserArr);
                    }
                    else
                    {
                        m_objPrintContext.m_mthSetContextWithAllCorrect((m_objContent == null ? "" : m_objContent.m_strMainDescriptionAll), (m_objContent == null ? "<root />" : m_objContent.m_strMainDescriptionXML));
                    }

                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 60, p_intPosY, p_objGrp);

                    p_intPosY += 20;

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
            }
        }

        /// <summary>
        /// 现病史
        /// </summary>
        private class clsPrintInPatientCaseCurrent : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_strCurrentStatus == "")
                {
                    p_objGrp.DrawString("现病史：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    m_blnHaveMoreLine = false;

                    return;
                }

                if (m_blnIsFirstPrint)
                {

                    p_objGrp.DrawString("现病史：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

                    p_intPosY += 20;

                    if (m_objContent != null)
                    {
                        if (m_objContent.m_strCurrentStatusXAll.Length == 0)
                        {
                            //							p_intPosY += 30;

                            m_blnHaveMoreLine = false;

                            return;
                        }
                    }

                    if (clsInPatientCaseHistory_XJPrintTool.m_blnIsPrintMark)
                    {
                        m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objContent == null ? "" : m_objContent.m_strCurrentStatusXAll), (m_objContent == null ? "<root />" : m_objContent.m_strCurrentStatusXML), m_dtmFirstPrintTime, m_objContent != null);
                        m_mthAddSign2("现病史：", m_objPrintContext.m_ObjModifyUserArr);
                    }
                    else
                    {
                        m_objPrintContext.m_mthSetContextWithAllCorrect((m_objContent == null ? "" : m_objContent.m_strCurrentStatusXAll), (m_objContent == null ? "<root />" : m_objContent.m_strCurrentStatusXML));
                    }

                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 50, p_intPosY, p_objGrp);

                    p_intPosY += 20;

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
            }
        }

        /// <summary>
        /// 既往史
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
                if (m_objContent == null || m_objContent.m_strBeforetimeStatus == "")
                {
                    p_objGrp.DrawString("既往史：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    m_blnHaveMoreLine = false;

                    return;
                }

                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("既往史：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

                    p_intPosY += 20;

                    if (m_objContent != null)
                    {
                        if (m_objContent.m_strBeforetimeStatusAll.Length == 0)
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

                    if (clsInPatientCaseHistory_XJPrintTool.m_blnIsPrintMark)
                    {
                        m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objContent == null ? "" : m_objContent.m_strBeforetimeStatusAll), (m_objContent == null ? "<root />" : m_objContent.m_strBeforetimeStatusXML), m_dtmFirstPrintTime, m_objContent != null);
                        m_mthAddSign2("既往史：", m_objPrintContext.m_ObjModifyUserArr);
                    }
                    else
                    {
                        m_objPrintContext.m_mthSetContextWithAllCorrect((m_objContent == null ? "" : m_objContent.m_strBeforetimeStatusAll), (m_objContent == null ? "<root />" : m_objContent.m_strBeforetimeStatusXML));
                    }

                    m_blnIsFirstPrint = false;

                }


                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 50, p_intPosY, p_objGrp);

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
                if (m_objContent == null || m_objContent.m_strOwnHistory == "" || MDIParent.m_EnmCaseType == frmInPatientCaseHistory.enmCaseType.产科)
                {
                    p_objGrp.DrawString("个人史：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    m_blnHaveMoreLine = false;

                    return;
                }

                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("个人史：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

                    p_intPosY += 20;

                    if (m_objContent != null)
                    {
                        if (m_objContent.m_strOwnHistoryAll.Length == 0)
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
                    if (clsInPatientCaseHistory_XJPrintTool.m_blnIsPrintMark)
                    {
                        m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objContent == null ? "" : m_objContent.m_strOwnHistoryAll), (m_objContent == null ? "<root />" : m_objContent.m_strOwnHistoryXML), m_dtmFirstPrintTime, m_objContent != null);
                        m_mthAddSign2("个人史：", m_objPrintContext.m_ObjModifyUserArr);
                    }
                    else
                    {
                        m_objPrintContext.m_mthSetContextWithAllCorrect((m_objContent == null ? "" : m_objContent.m_strOwnHistoryAll), (m_objContent == null ? "<root />" : m_objContent.m_strOwnHistoryXML));
                    }

                    m_blnIsFirstPrint = false;

                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 50, p_intPosY, p_objGrp);

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
        /// 婚姻史
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
                if (m_objContent == null || m_objContent.m_strMarriageHistory == "" || m_objPrintInfo.m_strMarried.Trim() == "未婚")
                {
                    p_objGrp.DrawString("婚姻史：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    m_blnHaveMoreLine = false;

                    return;
                }

                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("婚姻史：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

                    p_intPosY += 20;

                    if (m_objContent != null)
                    {
                        if (m_objContent.m_strMarriageHistoryAll.Length == 0)
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
                    if (clsInPatientCaseHistory_XJPrintTool.m_blnIsPrintMark)
                    {
                        m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objContent == null ? "" : m_objContent.m_strMarriageHistoryAll), (m_objContent == null ? "<root />" : m_objContent.m_strMarriageHistoryXML), m_dtmFirstPrintTime, m_objContent != null);
                        m_mthAddSign2("婚姻史：", m_objPrintContext.m_ObjModifyUserArr);
                    }
                    else
                    {
                        m_objPrintContext.m_mthSetContextWithAllCorrect((m_objContent == null ? "" : m_objContent.m_strMarriageHistoryAll), (m_objContent == null ? "<root />" : m_objContent.m_strMarriageHistoryXML));
                    }

                    m_blnIsFirstPrint = false;

                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine(650, m_intRecBaseX + 50, p_intPosY, p_objGrp);

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
        /// 月经史
        /// </summary>
        private class clsPrintInPatientCaseCatameniaHistory : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objPrintInfo.m_strSex.Trim() == "男")
                {
                    m_blnHaveMoreLine = false;
                    return;
                }

                if (m_objContent == null || m_objContent.m_intSelectedMC == 0)
                {
                    p_objGrp.DrawString("月经生育史：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    m_blnHaveMoreLine = false;
                    return;
                }

                p_objGrp.DrawString("月经生育史：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                p_intPosY += 30;

                string strLastTime = "";
                if (m_objContent.m_strCatameniaCase != "已绝经")
                    strLastTime = m_objContent.m_dtmLastCatameniaTime.ToString("yyyy年M月d日") + "，";

                //	p_objGrp.DrawString(m_objContent.m_strFirstCatamenia+"                  "+strLastTime+m_objContent.m_strCatameniaCase+"，"+m_objContent.m_strCatameniaHistory,p_fntNormalText,Brushes.Black,m_intRecBaseX+50,p_intPosY);
                p_objGrp.DrawString(m_objContent.m_strFirstCatamenia + "                  " + strLastTime + m_objContent.m_strCatameniaCase + "。", p_fntNormalText, Brushes.Black, m_intRecBaseX + 50, p_intPosY);

                p_objGrp.DrawLine(new Pen(Brushes.Black), m_intRecBaseX + 90, p_intPosY + 10, m_intRecBaseX + 150, p_intPosY + 10);

                p_objGrp.DrawString(m_objContent.m_strCatameniaLastTime, new Font("", 8), Brushes.Black, m_intRecBaseX + 100, p_intPosY - 5);
                p_objGrp.DrawString(m_objContent.m_strCatameniaCycle, new Font("", 8), Brushes.Black, m_intRecBaseX + 100, p_intPosY + 13);

                m_blnHaveMoreLine = false;

                p_intPosY += 20;
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;

                //				m_blnIsFirstPrint = true;
            }
        }
        /// <summary>
        ///月经史情况
        /// </summary>
        private class clsPrintInPatientCaseCatameniaHistory2 : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;

            private int m_intTimes = 0;

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_strBeforetimeStatus == "")
                {
                    m_blnHaveMoreLine = false;

                    return;
                }

                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString(" ", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

                    p_intPosY += 20;

                    if (m_objContent != null)
                    {
                        if (m_objContent.m_strBeforetimeStatusAll.Length == 0)
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

                    if (clsInPatientCaseHistory_XJPrintTool.m_blnIsPrintMark)
                    {
                        m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objContent == null ? "" : m_objContent.m_strCatameniaHistory), (m_objContent == null ? "<root />" : m_objContent.m_strBeforetimeStatusXML), m_dtmFirstPrintTime, m_objContent != null);
                        m_mthAddSign2("月经史：", m_objPrintContext.m_ObjModifyUserArr);
                    }
                    else
                    {
                        m_objPrintContext.m_mthSetContextWithAllCorrect((m_objContent == null ? "" : m_objContent.m_strCatameniaHistory), (m_objContent == null ? "<root />" : m_objContent.m_strBeforetimeStatusXML));
                    }

                    m_blnIsFirstPrint = false;

                }


                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 50, p_intPosY, p_objGrp);

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
        ///家族史
        /// </summary>
        private class clsPrintInPatientFamilyStatus : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private bool m_blnIsFirstPrint = true;

            private int m_intTimes = 0;

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_strFamilyHistory == "")
                {
                    p_objGrp.DrawString("家族史：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    m_blnHaveMoreLine = false;

                    return;
                }

                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("家族史：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

                    p_intPosY += 20;

                    if (m_objContent != null)
                    {
                        if (m_objContent.m_strFamilyHistoryAll.Length == 0)
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
                    if (clsInPatientCaseHistory_XJPrintTool.m_blnIsPrintMark)
                    {
                        m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objContent == null ? "" : m_objContent.m_strFamilyHistoryAll), (m_objContent == null ? "<root />" : m_objContent.m_strFamilyHistoryXML), m_dtmFirstPrintTime, m_objContent != null);
                        m_mthAddSign2("家族史：", m_objPrintContext.m_ObjModifyUserArr);
                    }
                    else
                    {
                        m_objPrintContext.m_mthSetContextWithAllCorrect((m_objContent == null ? "" : m_objContent.m_strFamilyHistoryAll), (m_objContent == null ? "<root />" : m_objContent.m_strFamilyHistoryXML));
                    }


                    m_blnIsFirstPrint = false;

                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 50, p_intPosY, p_objGrp);

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
        /// 辅助检查 
        /// </summary>
        private class clsPrintInPatientLabStatus : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private bool m_blnIsFirstPrint = true;

            private int m_intTimes = 0;

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_strLabCheck == "")
                {
                    p_objGrp.DrawString("辅助检查：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    m_blnHaveMoreLine = false;

                    return;
                }

                if (m_blnIsFirstPrint)
                {
                    p_intPosY += 20;
                    p_objGrp.DrawString("辅助检查：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

                    p_intPosY += 20;
                    if (m_objContent != null)
                    {
                        if (m_objContent.m_strLabCheckAll.Length == 0)
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
                    if (clsInPatientCaseHistory_XJPrintTool.m_blnIsPrintMark)
                    {
                        m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objContent == null ? "" : m_objContent.m_strLabCheckAll), (m_objContent == null ? "<root />" : m_objContent.m_strLabCheckXML), m_dtmFirstPrintTime, m_objContent != null);
                        m_mthAddSign2("辅助检查：", m_objPrintContext.m_ObjModifyUserArr);
                    }
                    else
                    {
                        m_objPrintContext.m_mthSetContextWithAllCorrect((m_objContent == null ? "" : m_objContent.m_strLabCheckAll), (m_objContent == null ? "<root />" : m_objContent.m_strLabCheckXML));
                    }

                    m_blnIsFirstPrint = false;

                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 50, p_intPosY, p_objGrp);

                    p_intPosY += 30;

                    m_intTimes++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    m_blnHaveMoreLine = false;
                }

                if (m_blnHaveMoreLine == false)
                {
                    #region 打印画图
                    if (m_blnHasPrintPic)
                        return;
                    m_mthPrintPic(p_objGrp, ref p_intPosY);
                    #endregion
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
        ///体格检查内容
        /// </summary>
        private class clsPrintInPatientBodyChekcFixStatus : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private bool m_blnIsFirstPrint = true;

            private int m_intTimes = 0;

            private bool m_blnNeedNewPage = false;

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_blnIsFirstPrint)
                {
                    //					p_intPosY += 30;
                    p_objGrp.DrawString("体格检查(见后表)", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                }
                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnIsFirstPrint = true;

                m_blnNeedNewPage = true;

                m_blnHaveMoreLine = true;

                m_intTimes = 0;
            }
        }        

        /// <summary>
        /// 初步诊断(中医诊断)
        /// </summary>
        private class clsPrintIniDiagnose_CHNInfo : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext1 = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private bool m_blnIsFirstPrint = true;

            private int m_intTimes = 0;

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                if (m_objContent == null || m_objContent.m_strINIDIAGNOSIS_CHNALL == "")
                {
                    p_objGrp.DrawString("中医诊断：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 40, p_intPosY);
                    p_intPosY += 20;
                    m_blnHaveMoreLine = false;

                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("中医诊断：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 40, p_intPosY);
                    if (m_objContent.m_strINIDIAGNOSIS_CHNALL != null && m_objContent.m_strINIDIAGNOSIS_CHNALL.Trim() != "")
                    {
                        if (clsInPatientCaseHistory_XJPrintTool.m_blnIsPrintMark)
                        {
                            m_objPrintContext1.m_mthSetContextWithCorrectBefore((m_objContent == null ? "" : m_objContent.m_strINIDIAGNOSIS_CHNALL), (m_objContent == null ? "<root />" : m_objContent.m_strINIDIAGNOSIS_CHNXML), m_dtmFirstPrintTime, m_objContent != null);
                            m_mthAddSign2("初步诊断(中医诊断)：", m_objPrintContext1.m_ObjModifyUserArr);
                        }
                        else
                        {
                            m_objPrintContext1.m_mthSetContextWithAllCorrect((m_objContent == null ? "" : m_objContent.m_strINIDIAGNOSIS_CHNALL), (m_objContent == null ? "<root />" : m_objContent.m_strINIDIAGNOSIS_CHNXML));
                        }
                    }
                    m_blnIsFirstPrint = false;

                }

                if (m_objPrintContext1.m_BlnHaveNextLine())
                {
                    m_objPrintContext1.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 120, p_intPosY, p_objGrp);

                    p_intPosY += 20;

                    m_intTimes++;
                }

                if (m_objPrintContext1.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    m_blnHaveMoreLine = false;
                }

                if (!m_blnHaveMoreLine)
                {
                    #region 打印画图
                    if (m_blnHasPrintPic)
                        return;
                    m_mthPrintPic(p_objGrp, ref p_intPosY);
                    #endregion
                }

            }
            public override void m_mthReset()
            {
                m_objPrintContext1.m_mthRestartPrint();
                m_intTimes = 0;
                m_blnIsFirstPrint = true;
                m_blnHaveMoreLine = true;
            }
        }

        /// <summary>
        /// 初步诊断(西医诊断)
        /// </summary>
        private class clsPrintIniDiagnoseInfo : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext1 = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private bool m_blnIsFirstPrint = true;

            private int m_intTimes = 0;

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                if (m_objContent == null || m_objContent.m_strINIDIAGNOSISALL == "")
                {
                    p_objGrp.DrawString("西医诊断：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 40, p_intPosY);
                    p_intPosY += 20;
                    m_blnHaveMoreLine = false;

                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_intPosY += 20;
                    p_objGrp.DrawString("西医诊断：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 40, p_intPosY);
                    if (m_objContent.m_strINIDIAGNOSISALL != null && m_objContent.m_strINIDIAGNOSISALL.Trim() != "")
                    {
                        if (clsInPatientCaseHistory_XJPrintTool.m_blnIsPrintMark)
                        {
                            m_objPrintContext1.m_mthSetContextWithCorrectBefore((m_objContent == null ? "" : m_objContent.m_strINIDIAGNOSISALL), (m_objContent == null ? "<root />" : m_objContent.m_strINIDIAGNOSISXML), m_dtmFirstPrintTime, m_objContent != null);
                            m_mthAddSign2("初步诊断(西医诊断)：", m_objPrintContext1.m_ObjModifyUserArr);
                        }
                        else
                        {
                            m_objPrintContext1.m_mthSetContextWithAllCorrect((m_objContent == null ? "" : m_objContent.m_strINIDIAGNOSISALL), (m_objContent == null ? "<root />" : m_objContent.m_strINIDIAGNOSISXML));
                        }
                    }
                    m_blnIsFirstPrint = false;

                }

                if (m_objPrintContext1.m_BlnHaveNextLine())
                {
                    m_objPrintContext1.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 120, p_intPosY, p_objGrp);

                    p_intPosY += 20;

                    m_intTimes++;
                }

                if (m_objPrintContext1.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    m_blnHaveMoreLine = false;
                }

                if (!m_blnHaveMoreLine)
                {
                    #region 打印画图
                    if (m_blnHasPrintPic)
                        return;
                    m_mthPrintPic(p_objGrp, ref p_intPosY);
                    #endregion
                }

            }
            public override void m_mthReset()
            {
                m_objPrintContext1.m_mthRestartPrint();
                m_intTimes = 0;
                m_blnIsFirstPrint = true;
                m_blnHaveMoreLine = true;
            }
        }

        /// <summary>
        /// 诊断Title  //2004-06-30加上治疗计划Title
        /// </summary>
        private class clsPrintPatientDiagnoseTitleInfo : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                p_intPosY += 20;
                //if (m_objContent != null && m_objContent.m_strPrimaryDiagnoseAll != null && m_objContent.m_strPrimaryDiagnoseAll.Trim() != "")
                //{
                    p_objGrp.DrawString("初步诊断：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

                //}
                p_intPosY += 20;
                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;
            }
        }
        

        /// <summary>
        /// 补充诊断Title
        /// </summary>
        private class clsPrintAddDiagnoseTitleInfo : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                //if (m_objContent != null && m_objContent.m_strAddDiagnoseALL != null && m_objContent.m_strAddDiagnoseALL.Trim() != "")
                //{
                    p_intPosY += 20;
                    p_objGrp.DrawString("确定(补充、修正)诊断：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                //}
                p_intPosY += 20;
                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;
            }
        }

        /// <summary>
        /// 补充诊断(中医诊断)
        /// </summary>
        private class clsPrintAddDiagnose_CHNInfo : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext1;

            private bool m_blnIsFirstPrint = true;

            private int m_intTimes = 0;

            public clsPrintAddDiagnose_CHNInfo()
            {
                m_objPrintContext1 = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            }
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                if (m_objContent == null || m_objContent.m_strADDDIAGNOSE_CHNALL == "")
                {
                    p_objGrp.DrawString("中医诊断：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 40, p_intPosY);
                    p_intPosY += 20;
                    m_blnHaveMoreLine = false;

                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("中医诊断：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 40, p_intPosY);
                    if (m_objContent.m_strADDDIAGNOSE_CHNALL != null && m_objContent.m_strADDDIAGNOSE_CHNALL.Trim() != "")
                    {
                        if (clsInPatientCaseHistory_XJPrintTool.m_blnIsPrintMark)
                        {
                            m_objPrintContext1.m_mthSetContextWithCorrectBefore((m_objContent == null ? "" : m_objContent.m_strADDDIAGNOSE_CHNALL), (m_objContent == null ? "<root />" : m_objContent.m_strADDDIAGNOSE_CHNXML), m_dtmFirstPrintTime, m_objContent != null, Color.Black);
                            m_mthAddSign2("确定(补充、修正)诊断(中医诊断)：", m_objPrintContext1.m_ObjModifyUserArr);
                        }
                        else
                        {
                            m_objPrintContext1.m_mthSetContextWithAllCorrect((m_objContent == null ? "" : m_objContent.m_strADDDIAGNOSE_CHNALL), (m_objContent == null ? "<root />" : m_objContent.m_strADDDIAGNOSE_CHNXML));
                        }
                    }
                    m_blnIsFirstPrint = false;

                }
                if (m_objPrintContext1.m_BlnHaveNextLine())
                {
                    m_objPrintContext1.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 120, p_intPosY, p_objGrp);
                    p_intPosY += 20;

                    m_intTimes++;
                }

                if (m_objPrintContext1.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    m_blnHaveMoreLine = false;
                }
            }

            public override void m_mthReset()
            {
                m_objPrintContext1.m_mthRestartPrint();

                m_blnHaveMoreLine = true;
            }
        }

        /// <summary>
        /// 补充诊断(西医诊断)
        /// </summary>
        private class clsPrintAddDiagnoseInfo : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext1;

            private bool m_blnIsFirstPrint = true;

            private int m_intTimes = 0;

            public clsPrintAddDiagnoseInfo()
            {
                m_objPrintContext1 = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            }
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                if (m_objContent == null || m_objContent.m_strAddDiagnoseALL == "")
                {
                    p_objGrp.DrawString("西医诊断：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 40, p_intPosY);
                    p_intPosY += 20;
                    m_blnHaveMoreLine = false;

                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("西医诊断：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 40, p_intPosY);
                    if (m_objContent.m_strAddDiagnoseALL != null && m_objContent.m_strAddDiagnoseALL.Trim() != "")
                    {
                        if (clsInPatientCaseHistory_XJPrintTool.m_blnIsPrintMark)
                        {
                            m_objPrintContext1.m_mthSetContextWithCorrectBefore((m_objContent == null ? "" : m_objContent.m_strAddDiagnoseALL), (m_objContent == null ? "<root />" : m_objContent.m_strAddDiagnoseXML), m_dtmFirstPrintTime, m_objContent != null, Color.Black);
                            m_mthAddSign2("确定(补充、修正)诊断(西医诊断)：", m_objPrintContext1.m_ObjModifyUserArr);
                        }
                        else
                        {
                            m_objPrintContext1.m_mthSetContextWithAllCorrect((m_objContent == null ? "" : m_objContent.m_strAddDiagnoseALL), (m_objContent == null ? "<root />" : m_objContent.m_strAddDiagnoseXML));
                        }
                    }
                    m_blnIsFirstPrint = false;

                }
                if (m_objPrintContext1.m_BlnHaveNextLine())
                {
                    m_objPrintContext1.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 120, p_intPosY, p_objGrp);
                    p_intPosY += 20;

                    m_intTimes++;
                }

                if (m_objPrintContext1.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    m_blnHaveMoreLine = false;
                }
            }

            public override void m_mthReset()
            {
                m_objPrintContext1.m_mthRestartPrint();

                m_blnHaveMoreLine = true;
            }
        }

        /// <summary>
        /// 初步诊断签名、日期
        /// </summary>
        private class clsPrintIniDiagnoseName : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext1 = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain m_objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                string strDirectDocName = string.Empty;
                string strChargeDocName = string.Empty;
                clsEmrEmployeeBase_VO objEmpVO = null;
                if (m_objContent != null)
                {
                    m_objEmployeeSign.m_lngGetEmpByNO(m_objContent.m_strDiretDoctor, out objEmpVO);
                    if (objEmpVO != null)
                        strDirectDocName = objEmpVO.m_strGetTechnicalRankAndName;
                    objEmpVO = null;
                    m_objEmployeeSign.m_lngGetEmpByNO(m_objContent.m_strChargeDoctor, out objEmpVO);
                    if (objEmpVO != null)
                        strChargeDocName = objEmpVO.m_strGetTechnicalRankAndName;
                    objEmpVO = null;
                }

                p_objGrp.DrawString("住院医师：" + strDirectDocName, p_fntNormalText, Brushes.Black, m_intRecBaseX + 500, p_intPosY);
                p_intPosY += 20;
                p_objGrp.DrawString("主治医师：" + strChargeDocName, p_fntNormalText, Brushes.Black, m_intRecBaseX + 500, p_intPosY);
                p_intPosY += 20;

                m_blnHaveMoreLine = false;

                if (m_blnHaveMoreLine == false)
                {
                    #region 打印画图
                    if (m_blnHasPrintPic)
                        return;
                    m_mthPrintPic(p_objGrp, ref p_intPosY);
                    #endregion
                }
            }

            public override void m_mthReset()
            {
                m_objPrintContext1.m_mthRestartPrint();

                m_blnHaveMoreLine = true;
            }
        }

        /// <summary>
        /// 补充诊断签名、日期
        /// </summary>
        private class clsPrintAddDiagnoseNameAndDate : clsPrintInPatientCaseInfo
        {
            private clsPrintRichTextContext m_objPrintContext1 = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain m_objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                string strPrimaryDoctorName = "";
                string strSignDate = "";
                clsEmrEmployeeBase_VO objEmpVO = null;
                if (m_objContent != null)
                {
                    m_objEmployeeSign.m_lngGetEmpByNO(m_objContent.m_strAddDiagnoseDoctorID, out objEmpVO);
                    if (objEmpVO != null)
                        strPrimaryDoctorName = objEmpVO.m_strGetTechnicalRankAndName;
                    objEmpVO = null;
                    if (m_objContent.m_dtDiagnoseDate != DateTime.MinValue && m_objContent.m_dtDiagnoseDate != new DateTime(1900, 1, 1))
                        strSignDate = m_objContent.m_dtDiagnoseDate.ToString("yyyy年MM月dd日");
                }
                if (m_objContent != null && m_objContent.m_strAddDiagnoseALL != null && m_objContent.m_strAddDiagnoseALL.Trim() != "")
                {
                    p_objGrp.DrawString("日期：" + strSignDate, p_fntNormalText, Brushes.Black, m_intRecBaseX + 250, p_intPosY);
                    p_objGrp.DrawString("医师签名：" + strPrimaryDoctorName, p_fntNormalText, Brushes.Black, m_intRecBaseX + 500, p_intPosY);
                    p_intPosY += 20;
                }

                m_blnHaveMoreLine = false;

                if (m_blnHaveMoreLine == false)
                {
                    #region 查看是否还有图片
                    if (m_blnHasPrintPic)
                        return;
                    if (m_objPrintInfo.m_objPicValueArr != null && m_objPrintInfo.m_objPicValueArr.Length > 0)
                    {
                        if (p_intPosY + m_objPrintInfo.m_objPicValueArr[0].intHeight > 844)
                        {
                            p_intPosY += 1000;//如果签名后仍没有足够空间打印图片，则换页
                            return;
                        }
                    }
                    #endregion
                }
            }
            
            public override void m_mthReset()
            {
                m_objPrintContext1.m_mthRestartPrint();

                m_blnHaveMoreLine = true;
            }
        }

        private class clsPrintPic : clsPrintInPatientCaseInfo
        {
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                #region 打印画图
                if (m_blnHasPrintPic)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                m_mthPrintPic(p_objGrp, ref p_intPosY);
                m_blnHaveMoreLine = false;
                #endregion
            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }
        }

        #endregion PrintClasses

        #region 标题文字部分
        /// <summary>
        /// 打印页脚
        /// </summary>
        /// <param name="e"></param>
        private void m_mthPrintFoot(System.Drawing.Printing.PrintPageEventArgs e)
        {
            float fltOffsetX = 20;//X的偏移量
            Font fntHeader = new Font("SimSun", 12);

            e.Graphics.DrawString("第      页", fntHeader, Brushes.Black, 385 - fltOffsetX, e.PageBounds.Height - 175);
            e.Graphics.DrawString(m_intCurrentPage.ToString(), fntHeader, Brushes.Black, 425 - fltOffsetX, e.PageBounds.Height - 175);
        }
        //打印边框
        private void m_mthPrintHeader(System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font fntTitle = new Font("SimSun", 18, FontStyle.Bold);
            Font fntHeader = new Font("SimSun", 12);

            e.Graphics.DrawRectangle(Pens.Black, m_intRecBaseX - 10, 135, (int)enmRectangleInfo.RightX - (int)enmRectangleInfo.LeftX + 10, e.PageBounds.Height - 330);
        }
        /// <summary>
        /// 标题文字部分
        /// </summary>
        /// <param name="e"></param>
        private void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font p_fntNormalText = new Font("Simsun", 12);

            SizeF m_szfHospitalTitle = e.Graphics.MeasureString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle.Trim(), m_fotHeaderFont);
            SizeF m_szfChildTitle = e.Graphics.MeasureString("入 院 记 录", m_fotTitleFont);
            int m_intChildTitleNameOffSetX = (int)(m_szfHospitalTitle.Width / 2 + m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_HospitalName).X - m_szfChildTitle.Width / 2);
            e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle.Trim(), m_fotHeaderFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_HospitalName));
            e.Graphics.DrawString("入 院 记 录", m_fotTitleFont, Brushes.Black, m_intChildTitleNameOffSetX, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_Name_Title).Y);

            e.Graphics.DrawString("姓名：", p_fntNormalText, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name_Title));

            e.Graphics.DrawString(m_objPrintInfo.m_strPatientName, p_fntNormalText, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name));

            e.Graphics.DrawString("性别：", p_fntNormalText, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex_Title));

            e.Graphics.DrawString(m_objPrintInfo.m_strSex, p_fntNormalText, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex));

            e.Graphics.DrawString("年龄：", p_fntNormalText, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age_Title));

            e.Graphics.DrawString(m_objPrintInfo.m_strAge, p_fntNormalText, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age));

            e.Graphics.DrawString("病区：", p_fntNormalText, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name_Title));

            e.Graphics.DrawString(m_objPrintInfo.m_strAreaName, p_fntNormalText, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name));

            e.Graphics.DrawString("床号：", p_fntNormalText, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNo_Title));

            e.Graphics.DrawString(m_objPrintInfo.m_strBedName, p_fntNormalText, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNo));

            e.Graphics.DrawString("住院号：", p_fntNormalText, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID_Title));

            e.Graphics.DrawString(m_objPrintInfo.m_strHISInPatientID, p_fntNormalText, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID));
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

        #endregion 打印
    }
}
