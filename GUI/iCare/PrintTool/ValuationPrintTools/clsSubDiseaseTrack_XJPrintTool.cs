using System;
using iCareData;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;


namespace iCare
{
    /// <summary>
    /// Summary description for clsSubDiseaseTrackPrintTool. 病程记录---新疆
    /// </summary>
    public class clsSubDiseaseTrack_XJPrintTool : infPrintRecord
    {

        #region Members
        private bool m_blnIsFromDataSource = true;//表明是从数据库读取还是从文件直接提取信息
        private bool m_blnWantInit = true;
        /// <summary>
        /// 是否打印修改痕迹
        /// </summary>
        public static bool m_blnIsPrintMark = true;
        private clsRecordsDomain m_objRecordsDomain;
        private clsPrintInfo_SubDiseaseTrack m_objPrintInfo;
        private string m_strServerTime;
        /// <summary>
        /// 空行记录表
        /// </summary>
        private System.Data.DataTable m_dtbBlankRecord;
        private static List<string> m_lstNewPagePrintTitle = new List<string>();
        #endregion

        #region 实现接口的函数
        static clsSubDiseaseTrack_XJPrintTool()
        {
            if (m_lstNewPagePrintTitle.Count == 0)
            {
                m_lstNewPagePrintTitle = com.digitalwave.Emr.StaticObject.clsConfigTools.s_lstGetEmrConfigValue("/EMR/DiseaseTrack/NewPage/*[name()='Title']");
                if (m_lstNewPagePrintTitle.Count == 0)
                    m_lstNewPagePrintTitle.Add("");
            }
        }
        public clsSubDiseaseTrack_XJPrintTool()
        {
        }
        clsPatient m_objCurrentPatient = null;
        /// <summary>
        /// 设置打印信息
        /// </summary>
        /// <param name="p_objPatient">病人</param>
        /// <param name="p_dtmInPatientDate">入院日期</param>
        /// <param name="p_dtmOpenDate">OpenDate，如果是一次打印多次记录表单的类型（如病案记录），忽略OpenDate</param>
        public void m_mthSetPrintInfo(clsPatient p_objPatient, DateTime p_dtmInPatientDate, DateTime p_dtmOpenDate)
        {
            m_blnIsFromDataSource = true;//表明是从数据库读取
            clsPatient m_objPatient = p_objPatient;
            m_objCurrentPatient = p_objPatient;
            m_objPrintInfo = new clsPrintInfo_SubDiseaseTrack();
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
            m_intGetBlankRecord();
            m_blnWantInit = true;

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
        /// 从数据库初始化打印内容。如果没有记录，打印空报表。
        /// </summary>
        public void m_mthInitPrintContent()
        {
            if (m_objPrintInfo.m_strInPatentID == "")
                return;
            m_strServerTime = new clsPublicDomain().m_strGetServerTime();

            m_objRecordsDomain = new clsRecordsDomain(enmRecordsType.SubDiseaseTrack_XJ);

            long lngRes = m_objRecordsDomain.m_lngGetPrintInfo(m_objPrintInfo.m_strInPatentID, m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), out m_objPrintInfo.m_objTransDataArr, out m_objPrintInfo.m_dtmFirstPrintDateArr, out m_objPrintInfo.m_blnIsFirstPrintArr);
            if (lngRes <= 0) return;
            //按记录时间(CreateDate)排序 
            m_mthSortTransData(ref m_objPrintInfo.m_objTransDataArr, ref m_objPrintInfo.m_dtmFirstPrintDateArr, ref m_objPrintInfo.m_blnIsFirstPrintArr);
            //设置表单内容到打印中
            m_mthSetPrintContent(m_objPrintInfo.m_objTransDataArr, m_objPrintInfo.m_dtmFirstPrintDateArr);
            m_objPrintInfo.m_objPrintDataArr = m_objPrintDataArr;

            m_blnWantInit = false;
        }


        /// <summary>
        /// 按记录顺序(CreateDate)把输入的p_objTansDataInfoArr排序
        /// </summary>
        /// <param name="p_objTansDataInfoArr"></param>
        protected void m_mthSortTransData(ref clsTransDataInfo[] p_objTansDataInfoArr, ref DateTime[] p_dtmFirstPrintDateArr, ref bool[] p_blnIsFirstPrintArr)
        {
            clsTransDataSort[] objDataSort = new clsTransDataSort[p_objTansDataInfoArr.Length];

            for (int i = 0; i < objDataSort.Length; i++)
            {
                objDataSort[i] = new clsTransDataSort();
                objDataSort[i].m_intIndex = i;
                objDataSort[i].m_Data = p_objTansDataInfoArr[i];
            }

            ArrayList m_arlSort = new ArrayList(objDataSort);
            m_arlSort.Sort();
            objDataSort = (clsTransDataSort[])m_arlSort.ToArray(typeof(clsTransDataSort));

            p_objTansDataInfoArr = new clsTransDataInfo[objDataSort.Length];
            DateTime[] dtmNewFirstPrintDateArr = new DateTime[objDataSort.Length];
            bool[] blnNewIsFirstPrintArr = new bool[objDataSort.Length];

            for (int i = 0; i < objDataSort.Length; i++)
            {
                p_objTansDataInfoArr[i] = objDataSort[i].m_Data;
                dtmNewFirstPrintDateArr[i] = p_dtmFirstPrintDateArr[objDataSort[i].m_intIndex];
                blnNewIsFirstPrintArr[i] = p_blnIsFirstPrintArr[objDataSort[i].m_intIndex];
            }

            p_dtmFirstPrintDateArr = dtmNewFirstPrintDateArr;
            p_blnIsFirstPrintArr = blnNewIsFirstPrintArr;
        }

        private class clsTransDataSort : IComparable
        {
            public int m_intIndex;

            public clsTransDataInfo m_Data;

            public int CompareTo(object p_objValue)
            {
                clsTransDataSort objDiff = (clsTransDataSort)p_objValue;

                return this.m_Data.CompareTo(objDiff.m_Data);
            }
        }

        /// <summary>
        /// 设置打印内容。当数据已经存在时使用。
        /// </summary>
        /// <param name="p_objPrintContent">打印内容</param>
        public void m_mthSetPrintContent(object p_objPrintContent)
        {
            if (p_objPrintContent.GetType().Name != "clsPrintInfo_SubDiseaseTrack")
            {
                MDIParent.ShowInformationMessageBox("参数错误");
            }
            m_blnIsFromDataSource = false;//表明是从文件直接提取信息
            m_objPrintInfo = (clsPrintInfo_SubDiseaseTrack)p_objPrintContent;
            m_objPrintDataArr = m_objPrintInfo.m_objPrintDataArr;
            m_strServerTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            m_blnWantInit = false;
        }

        /// <summary>
        /// 获取打印内容
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
            if (m_objPrintInfo.m_objPrintDataArr == null || m_objPrintInfo.m_objPrintDataArr.Length == 0)
                return null;
            else
                return m_objPrintInfo;
        }

        /// <summary>
        /// 初始化打印变量
        /// </summary>
        /// <param name="p_objArg">外部需要初始化的变量，根据不同的实现使用</param>
        public void m_mthInitPrintTool(object p_objArg)
        {
            //			m_fotTitleFont = new Font("SimSun", 20,FontStyle.Bold );
            m_fotTitleFont = new Font("SimSun", 15.75F, FontStyle.Bold);//宋体三号加粗
            //			m_fotHeaderFont = new Font("SimSun", 18);
            m_fotHeaderFont = new Font("SimSun", 15.5F);//宋体五号
            m_fotSmallFont = new Font("SimSun", 12);

            m_GridPen = new Pen(Color.Black, 1);
            m_slbBrush = new SolidBrush(Color.Black);

            m_objPageSetting = new clsPrintPageSettingForRecord();

            m_objPrintContext = new clsPrintRichTextContext(Color.Black, m_fotSmallFont);

            intCurrentRecord = 0;
            intNowPage = 0;
            blnBeginPrintNewRecord = true;
        }

        /// <summary>
        /// 释放打印变量
        /// </summary>
        /// <param name="p_objArg">外部使用到的变量，根据不同的实现使用</param>
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
        /// <param name="p_objPrintArg"></param>
        public void m_mthBeginPrint(object p_objPrintArg)
        {
            m_mthBeginPrintSub((PrintEventArgs)p_objPrintArg);
        }

        /// <summary>
        /// 打印中
        /// </summary>
        /// <param name="p_objPrintArg"></param>
        public void m_mthPrintPage(object p_objPrintArg)
        {
            m_mthPrintPageSub((PrintPageEventArgs)p_objPrintArg);
        }
        public void m_mthPrintPage()
        {
            frmPrintPreviewDialogPF frmPreview = new frmPrintPreviewDialogPF();
            frmPreview.m_evtBeginPrint += new PrintEventHandler(frmPreview_m_evtBeginPrint);
            frmPreview.m_evtEndPrint += new PrintEventHandler(frmPreview_m_evtEndPrint);
            frmPreview.m_evtPrintContent += new PrintPageEventHandler(frmPreview_m_evtPrintContent);
            frmPreview.m_evtPrintFrame += new PrintPageEventHandler(frmPreview_m_evtPrintFrame);
            frmPreview.ShowDialog();
        }

        /// <summary>
        /// 打印结束。一般使用它来更新数据库信息。
        /// </summary>
        /// <param name="p_objPrintArg"></param>
        public void m_mthEndPrint(object p_objPrintArg)
        {
            if (m_blnIsFromDataSource == false || m_objPrintInfo.m_strInPatentID == "") return;
            //如果打印成功，查找有无需要更新的时间，如果有，更新时间。 
            if (!((PrintEventArgs)p_objPrintArg).Cancel && m_objPrintInfo.m_blnIsFirstPrintArr != null)
            {
                ArrayList arlRecordType = new ArrayList();
                ArrayList arlOpenDate = new ArrayList();
                int intUpdateIndex = -1;//若没有任何记录
                for (int i = 0; i < m_objPrintInfo.m_blnIsFirstPrintArr.Length; i++)
                {
                    if (m_objPrintInfo.m_blnIsFirstPrintArr[i])
                    {
                        //更新记录，只需使用新的首次打印时间作为有效的输入参数。
                        //存放记录类型
                        arlRecordType.Add(m_objPrintInfo.m_objTransDataArr[i].m_intFlag);
                        //存放记录的OpenDate
                        arlOpenDate.Add(m_objPrintInfo.m_objTransDataArr[i].m_objRecordContent.m_dtmOpenDate);
                        intUpdateIndex = i;
                    }
                }

                if (intUpdateIndex >= 0)
                {
                    m_objRecordsDomain.m_lngUpdateFirstPrintDate(m_objPrintInfo.m_strInPatentID, m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), (int[])arlRecordType.ToArray(typeof(int)), (DateTime[])arlOpenDate.ToArray(typeof(DateTime)), m_objPrintInfo.m_dtmFirstPrintDateArr[intUpdateIndex]);
                }
                m_objPrintInfo.m_objTransDataArr = null;
                m_objPrintInfo.m_blnIsFirstPrintArr = null;
            }
            m_mthEndPrintSub((PrintEventArgs)p_objPrintArg);
        }

        #endregion


        #region 打印
        // 设置打印内容。
        private void m_mthSetPrintContent(clsTransDataInfo[] p_objTransDataArr,
            DateTime[] p_dtmFirstPrintDate)
        {
            if (p_objTransDataArr == null || p_dtmFirstPrintDate == null || p_objTransDataArr.Length != p_dtmFirstPrintDate.Length)
            {
                MDIParent.ShowInformationMessageBox("打印数据有误!");
                return;
            }
            int intBlankCount = 0;
            System.Data.DataTable dtbBlankRecord = null;
            new clsDiseaseTrackAddBlankDomain().m_lngGetBlankRecordContent(m_objPrintInfo.m_strInPatentID, m_objPrintInfo.m_dtmInPatientDate, out dtbBlankRecord);
            //根据不同的表单类型，获取对应的clsDiseaseTrackInfo
            clsDiseaseTrackInfo objTrackInfo = null;
            m_objPrintDataArr = new clsPrintData_SubDiseaseTrack[p_objTransDataArr.Length];

            for (int i = 0; i < p_objTransDataArr.Length; i++)
            {
                #region
                switch ((enmDiseaseTrackType)p_objTransDataArr[i].m_intFlag)
                {
                    case enmDiseaseTrackType.GeneralDisease:
                        objTrackInfo = new clsGeneralDiseaseInfo();
                        break;
                    case enmDiseaseTrackType.HandOver_XJ:
                        objTrackInfo = new clsHandOverInfo_XJ(m_objCurrentPatient);
                        break;
                    case enmDiseaseTrackType.TakeOver_XJ:
                        objTrackInfo = new clsTakeOverInfo_XJ(m_objCurrentPatient);
                        break;
                    case enmDiseaseTrackType.Consultation:
                        objTrackInfo = new clsConsultationInfo();
                        break;
                    case enmDiseaseTrackType.Convey_XJ:
                        objTrackInfo = new clsConveyInfo_XJ(m_objCurrentPatient);
                        break;
                    case enmDiseaseTrackType.TurnIn_XJ:
                        objTrackInfo = new clsTurnInInfo_XJ(m_objCurrentPatient);
                        break;
                    case enmDiseaseTrackType.DiseaseSummary_XJ:
                        objTrackInfo = new clsDiseaseSummaryInfo_XJ(m_objCurrentPatient);
                        break;
                    case enmDiseaseTrackType.CheckRoom:
                        objTrackInfo = new clsCheckRoomInfo();
                        break;
                    case enmDiseaseTrackType.CaseDiscuss:
                        objTrackInfo = new clsCaseDiscussInfo();
                        break;
                    case enmDiseaseTrackType.BeforeOperationDiscuss:
                        objTrackInfo = new clsBeforeOperationDiscussInfo();
                        break;
                    case enmDiseaseTrackType.DeadCaseDiscuss:
                        objTrackInfo = new clsDeadCaseDiscussInfo();
                        break;
                    case enmDiseaseTrackType.DeathCaseDiscuss:
                        objTrackInfo = new clsDeathCaseDiscussInfo();
                        break;
                    case enmDiseaseTrackType.AfterOperation:
                        objTrackInfo = new clsAfterOperationInfo();
                        break;
                    case enmDiseaseTrackType.Dead:
                        objTrackInfo = new clsDeadRecordInfo(m_objCurrentPatient);
                        break;
                    case enmDiseaseTrackType.Death:
                        objTrackInfo = new clsDeathRecordInfo();
                        break;
                    case enmDiseaseTrackType.OutHospital:
                        objTrackInfo = new clsOutHospitalInfo();
                        break;
                    case enmDiseaseTrackType.Save:
                        objTrackInfo = new clsSaveRecordInfo();
                        break;
                    case enmDiseaseTrackType.FirstIllnessNote:
                        if (com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalNO == "450101001")//佛二
                        {
                            objTrackInfo = new clsFirstIllnessNoteInfo();
                        }
                        else
                        {
                            objTrackInfo = new clsFirstIllnessNoteInfo_F2();
                            p_objTransDataArr[i].m_intFlag = (int)enmDiseaseTrackType.FirstIllnessNote_F2;
                        }
                        break;
                    case enmDiseaseTrackType.FirstIllnessNote_ZY:
                        objTrackInfo = new clsFirstIllnessNote_ZYInfo();
                        break;
                    case enmDiseaseTrackType.FirstIllnessNote_XJ:
                        objTrackInfo = new clsFirstIllnessNoteInfo_XJ();
                        break;
                    case enmDiseaseTrackType.EMR_SummaryBeforeOP:
                        objTrackInfo = new clsEMR_SummaryBeforeOPInfo();
                        break;
                #endregion
                }

                //设置clsDiseaseTrackInfo的内容
                objTrackInfo.m_ObjRecordContent = p_objTransDataArr[i].m_objRecordContent;

                m_objPrintDataArr[i] = new clsPrintData_SubDiseaseTrack();

                int intCharPerLine = (int)((float)enmRecordRectangleInfo.RecordLineLength / 17.5) + 1; /*每行显示的汉字的数目*/

                //根据 clsDiseaseTrackInfo 获得的文本和Xml
                string strText = "";
                string strXML = "";

                if ((enmDiseaseTrackType)p_objTransDataArr[i].m_intFlag == enmDiseaseTrackType.CaseDiscuss)
                {
                    DateTime dtmFlagTime;
                    if (p_objTransDataArr[i].m_objRecordContent.m_dtmFirstPrintDate == DateTime.MinValue)
                        dtmFlagTime = DateTime.Parse(m_strServerTime);
                    else
                        dtmFlagTime = p_objTransDataArr[i].m_objRecordContent.m_dtmFirstPrintDate;

                    ((clsCaseDiscussInfo)objTrackInfo).m_mthGetFormatTrackInfo(30, true, dtmFlagTime, out strText, out strXML);
                }
                else if ((enmDiseaseTrackType)p_objTransDataArr[i].m_intFlag == enmDiseaseTrackType.DeadCaseDiscuss)
                {
                    DateTime dtmFlagTime;
                    if (p_objTransDataArr[i].m_objRecordContent.m_dtmFirstPrintDate == DateTime.MinValue)
                        dtmFlagTime = DateTime.Parse(m_strServerTime);
                    else
                        dtmFlagTime = p_objTransDataArr[i].m_objRecordContent.m_dtmFirstPrintDate;

                    ((clsDeadCaseDiscussInfo)objTrackInfo).m_mthGetFormatTrackInfo(30, true, dtmFlagTime, out strText, out strXML);
                }
                else
                {
                    strText = objTrackInfo.m_strGetTrackText();
                    strXML = objTrackInfo.m_strGetTrackXml();
                }

                m_objPrintDataArr[i].m_strContent = strText;
                m_objPrintDataArr[i].m_strContentXml = strXML;

                string strSignText = objTrackInfo.m_strGetSignText();
                string strBlanks = "";
                for (int j2 = 0; j2 < intCharPerLine - strSignText.Length - 1; j2++)
                {
                    strBlanks += "　";//注意：此处填充的空格是全角占一个汉字的空格				
                }

                #region   Add blank to print
                int intBlankLine = 0;

                if (m_dtbBlankRecord != null && m_dtbBlankRecord.Rows.Count > 0)
                {
                    foreach (System.Data.DataRow drtAdd in m_dtbBlankRecord.Rows)
                    {
                        if (DateTime.Parse(drtAdd[2].ToString()).ToString("yyyy-MM-dd HH:mm:ss") == objTrackInfo.m_ObjRecordContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"))
                        {
                            intBlankLine = Int32.Parse(drtAdd[3].ToString());
                            break;
                        }
                    }
                }
                #endregion

                m_objPrintDataArr[i].m_strSign = strBlanks + strSignText;
                for (int k1 = 0; k1 < intBlankLine; k1++)
                    m_objPrintDataArr[i].m_strContent = "\n" + m_objPrintDataArr[i].m_strContent;
                m_objPrintDataArr[i].m_strSignXml = objTrackInfo.m_strGetSignXml();
                m_objPrintDataArr[i].m_dtmFirstPrintDate = p_dtmFirstPrintDate[i];


                //设置分页标志
                if (objTrackInfo.m_ObjRecordContent.m_StrPagination != null)
                    m_objPrintDataArr[i].m_strPagiNation = objTrackInfo.m_ObjRecordContent.m_StrPagination.ToString();
                if (dtbBlankRecord != null && dtbBlankRecord.Rows.Count > 0)
                {
                    foreach (System.Data.DataRow drtAdd in dtbBlankRecord.Rows)
                    {
                        if (DateTime.Parse(drtAdd[2].ToString()).ToString("yyyy-MM-dd HH:mm:ss") == objTrackInfo.m_ObjRecordContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"))
                        {
                            int intBlankLine2 = Int32.Parse(drtAdd[3].ToString());
                            intBlankCount = intBlankLine;
                            m_objPrintDataArr[i].m_intBlankCount = intBlankLine;
                            for (int j2 = 0; j2 < intBlankLine2; j2++)
                            {
                                m_objPrintDataArr[i].m_strContent = "\n" + m_objPrintDataArr[i].m_strContent;
                            }
                            break;
                        }
                    }
                }
            }
        }

        /*
        // 释放打印变量
        protected override void m_mthDisposePrintTools()
        {
            m_fotTitleFont.Dispose();
            m_fotHeaderFont.Dispose();
            m_fotSmallFont.Dispose();
            m_GridPen.Dispose();
            m_slbBrush.Dispose();
        }*/

        /// <summary>
        ///  开始打印。
        /// </summary>
        /*	private void m_mthStartPrint()
            {
                base.m_mthStartPrint();
            }*/


        // 打印开始后，在打印页之前的操作
        private void m_mthBeginPrintSub(PrintEventArgs p_objPrintArg)
        {

        }

        // 打印页
        private void m_mthPrintPageSub(PrintPageEventArgs p_objPrintPageArg)
        {
            try
            {
                p_objPrintPageArg.HasMorePages = false;
                m_mthPrintTitleInfo(p_objPrintPageArg);
                m_mthAddDataToGrid(p_objPrintPageArg);
                m_mthPrintRectangleInfo(p_objPrintPageArg);
            }
            catch (Exception err)
            {
                MDIParent.ShowInformationMessageBox(err.Message + "\r\n" + err.StackTrace);

            }
        }
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

        // 打印结束时的操作
        private void m_mthEndPrintSub(PrintEventArgs p_objPrintArg)
        {
            //			m_mthSavePrintToRecord(m_objPrintDataArr.Length);

            m_mthResetWhenEndPrint();
        }

        /// <summary>
        /// 每次打印结束之后的复位,无论是打印当前页或者打印全部.
        /// </summary>
        private void m_mthResetWhenEndPrint()
        {
            intCurrentRecord = 0;
            blnBeginPrintNewRecord = true;
            intNowPage = 0;
        }

        #region debug
        //		public long m_lngSavePrintToRecord(string p_strInPatientID,string p_strInPatientDate,string p_strFormName,
        //			int p_intToRecord)
        //		{
        //			com.digitalwave.H`  RPService.clsHRPTableService objServ = new com.digitalwave.HRPService.clsHRPTableService();
        //			string strSql = @"SELECT *
        //FROM ContinuePrintRecord
        //WHERE (InPatientID = '"+p_strInPatientID+"') AND (InPatientDate = '"+p_strInPatientDate+"') AND (FormName = '"+p_strFormName+"')";
        //			System.Data.DataTable dtResult = new System.Data.DataTable();
        //			long lngRes = objServ.DoGetDataTable(strSql,ref dtResult);
        //			if(lngRes > 0 && dtResult.Rows.Count > 0)
        //			{
        //				strSql = @"DELETE FROM ContinuePrintRecord
        //WHERE (InPatientID = '"+p_strInPatientID+"') AND (InPatientDate = '"+p_strInPatientDate+"') AND (FormName = '"+p_strFormName+"')";
        //			}
        //			strSql = @"INSERT INTO ContinuePrintRecord
        //      (InPatientID, InPatientDate, FormName, Record)
        //VALUES ('"+p_strInPatientID+"', '"+p_strInPatientDate+"', '"+p_strFormName+"', '"+p_intToRecord+"')";			
        //			return objServ.DoExcute(strSql);
        //		}
        #endregion

        #region 标题文字部分
        /// <summary>
        /// 标题文字部分
        /// </summary>
        /// <param name="e"></param>
        private void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
        {
            clsEveryRecordPageInfo objEveryRecordPageInfo = new clsEveryRecordPageInfo();
            //************************************************
            objEveryRecordPageInfo.strAge = m_objPrintInfo.m_strAge;
            objEveryRecordPageInfo.strPatientName = m_objPrintInfo.m_strPatientName;
            objEveryRecordPageInfo.strBedNo = m_objPrintInfo.m_strBedName;
            objEveryRecordPageInfo.strDeptName = m_objPrintInfo.m_strAreaName;
            objEveryRecordPageInfo.strSex = m_objPrintInfo.m_strSex;
            objEveryRecordPageInfo.strInPatientID = m_objPrintInfo.m_strHISInPatientID;
            //objEveryRecordPageInfo.strPrintDate=m_objCurrentPatient!=null? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") :"";		

            StringFormat sf = new StringFormat(StringFormatFlags.FitBlackBox);
            sf.Alignment = StringAlignment.Center;
            e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, m_fotHeaderFont, m_slbBrush, clsPrintPosition.m_rtgHospitalTitlePos, sf);

            e.Graphics.DrawString("病     程     记     录", m_fotTitleFont, m_slbBrush, clsPrintPosition.m_rtgFormTitlePos, sf);


            e.Graphics.DrawString("姓名：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name_Title));
            e.Graphics.DrawString(objEveryRecordPageInfo.strPatientName, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name));

            e.Graphics.DrawString("性别：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex_Title));
            e.Graphics.DrawString(objEveryRecordPageInfo.strSex, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex));

            e.Graphics.DrawString("年龄：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age_Title));
            e.Graphics.DrawString(objEveryRecordPageInfo.strAge, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age));

            e.Graphics.DrawString("病区：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name_Title));
            e.Graphics.DrawString(m_objPrintInfo.m_strAreaName, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name));

            e.Graphics.DrawString("床号：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNo_Title));
            e.Graphics.DrawString(objEveryRecordPageInfo.strBedNo, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNo));

            e.Graphics.DrawString("住院号：", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID_Title));
            e.Graphics.DrawString(objEveryRecordPageInfo.strInPatientID, m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID));
            sf.Dispose();
        }
        #endregion

        #region 画格子
        /// <summary>
        ///  画格子
        /// </summary>
        /// <param name="e"></param>
        private void m_mthPrintRectangleInfo(System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX - 10,
                (int)enmRecordRectangleInfo.TopY,
                (int)enmRecordRectangleInfo.RightX,
                (int)enmRecordRectangleInfo.TopY);

            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX - 10,
                (int)enmRecordRectangleInfo.BottomLine,
                (int)enmRecordRectangleInfo.RightX,
                (int)enmRecordRectangleInfo.BottomLine);

            //画格子竖线

            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX - 10, (int)enmRecordRectangleInfo.TopY,
                (int)enmRecordRectangleInfo.LeftX - 10, (int)enmRecordRectangleInfo.BottomLine);
            e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.RightX, (int)enmRecordRectangleInfo.TopY,
                (int)enmRecordRectangleInfo.RightX, (int)enmRecordRectangleInfo.BottomLine);


            //页脚//////////////////////////////////////////////////////////////
            e.Graphics.DrawString("（第" + intNowPage.ToString() + "页）", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + (int)enmRecordRectangleInfo.ColumnsMark2,
                (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * ((int)enmRecordRectangleInfo.RowLinesNum + 1) + 10);
        }


        #endregion

        #region 填充数据到表格

        /// <summary>
        /// 填充数据到表格
        /// </summary>
        /// <param name="e"></param>
        private void m_mthAddDataToGrid(System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                int intPrintLenth = (int)((float)enmRecordRectangleInfo.RecordLineLength / 17.5) + 1; /*每行显示的汉字的数目*/
                string strRecord = "";
                string strRecordXML = "";
                DateTime dtmFlagTime;

                int intNowRow = 1; /*记录该页当前的打印的行*/


                if (m_objPrintInfo.m_strInPatentID == "" || m_objPrintDataArr == null) return;
                for (; intCurrentRecord < m_objPrintDataArr.Length; intCurrentRecord++)
                {
                    #region 如果是新记录，打印日期，设置打印数据值
                    if (blnBeginPrintNewRecord)
                    {
                        blnBeginPrintNewRecord = false;

                        strRecord = m_objPrintDataArr[intCurrentRecord].m_strContent;
                        strRecordXML = m_objPrintDataArr[intCurrentRecord].m_strContentXml;

                        //打印一条记录/////////////////////////////////////////////////////////////////////
                        /*修改打印内容方式（以第一次打印时间为分割，该时间后的所有修改的痕迹都要保留，如从未打印过则显示正确的记录）*/
                        if (m_objPrintDataArr[intCurrentRecord].m_dtmFirstPrintDate == DateTime.MinValue)
                            dtmFlagTime = DateTime.Parse(m_strServerTime);
                        else
                            dtmFlagTime = m_objPrintDataArr[intCurrentRecord].m_dtmFirstPrintDate;

                        if (clsSubDiseaseTrackPrintTool.m_blnIsPrintMark)
                        {
                            m_objPrintContext.m_mthSetContextWithCorrectBefore(strRecord, strRecordXML, dtmFlagTime, m_objPrintDataArr != null);

                            ctlRichTextBox.clsModifyUserInfo[] m_objModifyUserArr = m_objPrintContext.m_ObjModifyUserArr;

                            for (int i = 0; i < m_objModifyUserArr.Length; i++)
                            {
                                if (m_objModifyUserArr[i].m_clrText.ToArgb() == Color.White.ToArgb())
                                {
                                    m_objModifyUserArr[i].m_clrText = Color.Black;
                                }
                            }
                        }
                        else
                        {
                            m_objPrintContext.m_mthSetContextWithAllCorrect(strRecord, strRecordXML);
                        }


                        #region 控制分页,通过XML配置的方式实现
                        if (m_blnIsContainsForNewPage(strRecord) && intNowRow != 1)
                            intNowRow = (int)enmRecordRectangleInfo.RowLinesNum + 1;
                        #endregion
                    }
                    #endregion

                    #region 将当前记录除签名外全部打完或中途换页跳出
                    while (m_objPrintContext.m_BlnHaveNextLine())//判断该条记录是否还有下一行
                    {
                        /* 
                         * 如果最后一行打印的刚好是一条记录的标题，
                         * 则从新的一页开始打
                         */
                        if (intNowRow == (int)enmRecordRectangleInfo.RowLinesNum)
                        {
                            if (m_objPrintContext.m_IntCurrentIndex == 0)
                            {
                                e.HasMorePages = true;
                                intNowPage++;
                                return;
                            }
                        }

                        if (m_blnCheckPageChange(intNowRow, e) == true) //每打印一行之前都要检查是否换页
                        {
                            //如果还没打到指定记录，清空。注意：该记录还没打完
                            //							if(intCurrentRecord < m_intFromRecord)
                            //							{
                            //								e.Graphics.Clear(Color.White);
                            //								m_mthPrintTitleInfo(e);
                            //								m_mthPrintRectangleInfo(e);
                            //								m_mthAddDataToGrid(e);
                            //							}
                            return;
                        }
                        m_objPrintContext.m_mthPrintLine((int)enmRecordRectangleInfo.RecordLineLength, (int)enmRecordRectangleInfo.LeftX,
                            (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * (intNowRow - 1) + 10, e.Graphics);

                        intNowRow++;//每打印一行都要向下滚行
                    }
                    #endregion

                    #region 签名
                    string[] strTextArr_Sign, strXmlArr_Sign;
                    com.digitalwave.controls.ctlRichTextBox.m_mthSplitXml(m_objPrintDataArr[intCurrentRecord].m_strSign, m_objPrintDataArr[intCurrentRecord].m_strSignXml, intPrintLenth, out strTextArr_Sign, out strXmlArr_Sign);

                    if (m_blnCheckPageChange(intNowRow + strTextArr_Sign.Length - 1, e) == true) //每打印一行之前都要检查是否换页
                        return;//此处签名若当前页打不完，就一起放在下一页
                    for (int k3 = 0; k3 < strTextArr_Sign.Length; k3++)
                    {
                        e.Graphics.DrawString(strTextArr_Sign[k3], m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX,
                            (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowStep * (intNowRow - 1) + 10);
                        intNowRow++;//每打印一行都要向下滚行
                    }

                    blnBeginPrintNewRecord = true; //签名打印完毕，当前记录打完				
                    intNowRow++;//空一行
                    #endregion

                    #region 如果还没打印到指定记录，将之前的清空
                    //					if(intCurrentRecord < m_intFromRecord)
                    //					{
                    //						e.Graphics.Clear(Color.White);//清空
                    //
                    //						//如果这条记录刚好占一页
                    //						if(intNowRow>(int)enmRecordRectangleInfo.RowLinesNum)
                    //						{
                    //							//如果是指定记录的前一条，则先打印一空页（因为用户塞的是之前打印的那张纸）
                    //							if(intCurrentRecord == m_intFromRecord - 1)
                    //							{
                    //								intCurrentRecord++;
                    //								e.HasMorePages = true;
                    //								return;
                    //							}
                    //
                    //							//如果不是，则从这一页的顶端继续打，并且需要打页头和页脚
                    //							m_mthPrintTitleInfo(e);
                    //							m_mthPrintRectangleInfo(e);
                    //							intNowRow = 1;
                    //							//页脚//////////////////////////////////////////////////////////////
                    //							e.Graphics.DrawString("（第"+intNowPage.ToString()+"页）",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2 ,
                    //								(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep*((int)enmRecordRectangleInfo.RowLinesNum+1)+10 );
                    //						}						
                    //					}
                    #endregion


                    //检查下一页是否设置分页标志，如果设置分页则换页打印
                    if (intCurrentRecord < m_objPrintDataArr.Length)
                    {
                        if (intCurrentRecord == m_objPrintDataArr.Length - 1)
                        {
                            if (m_objPrintDataArr[intCurrentRecord].m_strPagiNation == "1")
                            {
                                intNowRow += (int)enmRecordRectangleInfo.RowLinesNum;
                                e.HasMorePages = true;
                                //								intNowPage ++;
                            }
                        }
                        else
                        {
                            if (m_objPrintDataArr[intCurrentRecord + 1].m_strPagiNation == "1")
                            {
                                intNowRow += (int)enmRecordRectangleInfo.RowLinesNum;
                                e.HasMorePages = true;
                                //								intNowPage ++;
                            }
                        }
                    }
                }

                //打印完成，没下页了。因为在for循环中e.HasMorePages的值可能已被改为true
                e.HasMorePages = false;
                intNowPage++;
            }
            catch (Exception err)
            {
                MDIParent.ShowInformationMessageBox(err.Message + "\r\n" + err.StackTrace);
            }
        }

        /// <summary>
        /// 检查是否换页,true:换页，false:不换页
        /// </summary>
        /// <param name="p_intNowRow">当前打印行，第p_intNowRow行</param>
        /// <param name="e"></param>
        /// <returns></returns>
        private bool m_blnCheckPageChange(int p_intNowRow, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //当当前行超过最后一行（即 >页总行数）时换页
            if (p_intNowRow > (int)enmRecordRectangleInfo.RowLinesNum)
            {
                e.HasMorePages = true;
                intNowPage++;

                return true;
            }
            else return false;
        }

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
                        m_fReturnPoint = new PointF(320f - fltOffsetX, 115f);
                        break;
                    case (int)enmItemDefination.Page_Name_Title:
                        m_fReturnPoint = new PointF(255f - fltOffsetX, 145f);
                        break;
                    case (int)enmItemDefination.Name_Title:
                        m_fReturnPoint = new PointF(50f - fltOffsetX, (float)clsPrintPosition.c_intA3TopTitleY);
                        break;
                    case (int)enmItemDefination.Name:
                        m_fReturnPoint = new PointF(100f - fltOffsetX, (float)clsPrintPosition.c_intA3TopTitleY);
                        break;

                    case (int)enmItemDefination.Sex_Title:
                        m_fReturnPoint = new PointF(185f - fltOffsetX, (float)clsPrintPosition.c_intA3TopTitleY);
                        break;
                    case (int)enmItemDefination.Sex:
                        m_fReturnPoint = new PointF(230f - fltOffsetX, (float)clsPrintPosition.c_intA3TopTitleY);
                        break;

                    case (int)enmItemDefination.Age_Title:
                        m_fReturnPoint = new PointF(260f - fltOffsetX, (float)clsPrintPosition.c_intA3TopTitleY);
                        break;
                    case (int)enmItemDefination.Age:
                        m_fReturnPoint = new PointF(305f - fltOffsetX, (float)clsPrintPosition.c_intA3TopTitleY);
                        break;

                    case (int)enmItemDefination.Dept_Name_Title:
                        m_fReturnPoint = new PointF(360f - fltOffsetX, (float)clsPrintPosition.c_intA3TopTitleY);
                        break;
                    case (int)enmItemDefination.Dept_Name:
                        m_fReturnPoint = new PointF(410f - fltOffsetX, (float)clsPrintPosition.c_intA3TopTitleY);
                        break;

                    case (int)enmItemDefination.BedNo_Title:
                        m_fReturnPoint = new PointF(555 - fltOffsetX, (float)clsPrintPosition.c_intA3TopTitleY);
                        break;
                    case (int)enmItemDefination.BedNo:
                        m_fReturnPoint = new PointF(605 - fltOffsetX, (float)clsPrintPosition.c_intA3TopTitleY);
                        break;

                    case (int)enmItemDefination.InPatientID_Title:
                        m_fReturnPoint = new PointF(655f - fltOffsetX, (float)clsPrintPosition.c_intA3TopTitleY);
                        break;
                    case (int)enmItemDefination.InPatientID:
                        m_fReturnPoint = new PointF(715f - fltOffsetX, (float)clsPrintPosition.c_intA3TopTitleY);
                        break;

                    default:
                        m_fReturnPoint = new PointF(400f, 400f);
                        break;

                }
                return m_fReturnPoint;
            }
        }

        #endregion
        #endregion 打印

        #region 有关打印的声明
        /// <summary>
        /// 所有打印的数据
        /// </summary>
        private clsPrintData_SubDiseaseTrack[] m_objPrintDataArr;
        //		[Serializable]
        //		private class clsPrintData
        //		{
        //			public string m_strContent;
        //			public string m_strContentXml;
        //			public string m_strSign;
        //			public string m_strSignXml;
        //			public DateTime m_dtmFirstPrintDate;
        //		}

        /// <summary>
        /// 病程记录内容打印上下文
        /// </summary>
        private clsPrintRichTextContext m_objPrintContext;

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
        /// 边框画笔
        /// </summary>
        private Pen m_GridPen;
        /// <summary>
        /// 刷子
        /// </summary>
        private SolidBrush m_slbBrush;
        /// <summary>
        /// 记录打印到第几页
        /// </summary>
        private int intNowPage;
        /// <summary>
        /// 当前打印的护理记录
        /// </summary>
        private int intCurrentRecord;
        /// <summary>
        /// 准备打印一条新记录(若存在上条记录,则上条记录打完)
        /// </summary>
        private bool blnBeginPrintNewRecord = true;
        /// <summary>
        /// 获取坐标的类
        /// </summary>
        private clsPrintPageSettingForRecord m_objPageSetting;
        /// <summary>
        /// 打印的病人基本信息类
        /// </summary>
        private class clsEveryRecordPageInfo
        {
            public string strPatientName;
            public string strSex;
            public string strAge;
            public string strBedNo;
            public string strDeptName;
            public string strInPatientID;
            //			public int intCurrentPage;
            //			public int intTotalPages;
            //			public string strPrintDate;
        }

        /// <summary>
        /// 格子的信息
        /// </summary>
        private enum enmRecordRectangleInfo
        {
            /// <summary>
            /// 格子的顶端
            /// </summary>
            TopY = clsPrintPosition.c_intA3TopLineY,
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
            RowStep = 23,
            /// <summary>
            /// 格子的行数
            /// </summary>
            RowLinesNum = 36,
            /// <summary>
            /// 病案记录每行的pixel长度
            /// </summary>
            RecordLineLength = RightX - LeftX,//750,
            /// <summary>
            /// 列的数目
            /// </summary>
            ColumnsNum = 3,
            /// <summary>
            /// 第一条间隔线(X)
            /// </summary>
            ColumnsMark1 = 160,
            /// <summary>
            /// 第二条间隔线(X)
            /// </summary>
            ColumnsMark2 = 650,

            /// <summary>
            /// 底线
            /// </summary>
            BottomLine = (int)TopY + ((int)RowLinesNum) * (int)RowStep + 15

        }

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


        #endregion

        #region 在外部测试本打印的演示实例.
        //		System.Drawing.Printing.PrintDocument m_pdcPrintDocument;
        //		private void m_mthfrmLoad()
        //		{	
        //			this.m_pdcPrintDocument = new System.Drawing.Printing.PrintDocument();
        //			this.m_pdcPrintDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_BeginPrint);
        //			this.m_pdcPrintDocument.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_EndPrint);
        //			this.m_pdcPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.m_pdcPrintDocument_PrintPage);		
        //		}
        //		private void m_pdcPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        //		{			
        //			objPrintTool.m_mthPrintPage(e);
        //		}
        //
        //		private void m_pdcPrintDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        //		{
        //			objPrintTool.m_mthBeginPrint(e);				
        //		}
        //
        //		private void m_pdcPrintDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        //		{
        //			objPrintTool.m_mthEndPrint(e);
        //		}
        //
        //		clsIntensiveTendMainPrintTool objPrintTool;
        //		private void m_mthDemoPrint_FromDataSource()
        //		{	
        //			objPrintTool=new clsIntensiveTendMainPrintTool();
        //			objPrintTool.m_mthInitPrintTool(null);	
        //			if(m_objBaseCurrentPatient==null)
        //				objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,DateTime.MinValue,DateTime.MinValue);
        //			else 
        //				objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,m_objBaseCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate,DateTime.MinValue);
        //						
        //			objPrintTool.m_mthInitPrintContent();	

        //			//保存到文件
        //			object objtemp=objPrintTool.m_objGetPrintInfo();
        //			IFormatter objForm = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        //
        //			Stream objStream = new System.IO.FileStream("d:\\code\\Tese.bin",FileMode.Create);
        //
        //			objForm.Serialize(objStream,objtemp);
        //
        //			objStream.Flush();
        //			objStream.Close();
        //		
        //			m_mthStartPrint();
        //		}
        //		private void m_mthDemoPrint_FromFile()
        //		{	
        //			objPrintTool=new clsIntensiveTendMainPrintTool();
        //			objPrintTool.m_mthInitPrintTool(null);	
        //
        //			IFormatter objForm = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        //			Stream objStream = new System.IO.FileStream("d:\\code\\Tese.bin",FileMode.Open);
        //			object objtemp = objForm.Deserialize(objStream);//
        //			objStream.Close();
        //		
        //			objPrintTool.m_mthSetPrintContent(objtemp);		
        //
        //			m_mthStartPrint();
        //		}
        //		private void m_mthStartPrint()
        //		{			
        //			PrintPreviewDialog ppdPrintPreview = new PrintPreviewDialog();
        //			ppdPrintPreview.Document = m_pdcPrintDocument;
        //			ppdPrintPreview.ShowDialog();
        //		}
        #endregion 在外部测试本打印的演示实例.

        #region  增加空行打印设置
        private void m_intGetBlankRecord()
        {
            clsDiseaseTrackAddBlankDomain objAddBlankDomain = new clsDiseaseTrackAddBlankDomain();
            objAddBlankDomain.m_lngGetBlankRecordContent(m_objPrintInfo.m_strInPatentID, m_objPrintInfo.m_dtmInPatientDate, out m_dtbBlankRecord);
        }
        #endregion

        private bool m_blnIsContainsForNewPage(string p_strTitle)
        {
            if (m_lstNewPagePrintTitle.Count == 0) return false;
            foreach (string str in m_lstNewPagePrintTitle)
            {
                if (p_strTitle.Contains(str) && str != string.Empty) return true;
            }
            return false;
        }
    }


}
