
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using iCareData;
using com.digitalwave.Utility.Controls;
using System.Data;
using HRP;
using PrivilegeData;
using com.digitalwave.clsAYQBabyAssessmentRecord_Service;
using com.digitalwave.Emr.Signature_gui;

namespace iCare
{
    /// <summary>
    ///  爱婴区婴儿评估表主窗体
    /// </summary>
    public partial class frmAYQBabyAssessmentRecord : iCare.frmRecordsBase
    {
        private System.Windows.Forms.DataGridTextBoxColumn clmRecordDateofDay;
        private System.Windows.Forms.DataGridTextBoxColumn clmCreateTime;
        private cltDataGridDSTRichTextBox m_dtcFacecolor;
        private cltDataGridDSTRichTextBox m_dtcRespiration;
        private cltDataGridDSTRichTextBox m_dtcReaction;
        private cltDataGridDSTRichTextBox m_dtcTakeFood;
        private cltDataGridDSTRichTextBox m_dtcArmpitWet;
        private cltDataGridDSTRichTextBox m_dtcDerm;
        private cltDataGridDSTRichTextBox m_dtcAurigo;
        private cltDataGridDSTRichTextBox m_dtcUmbilicalRegion;
        private cltDataGridDSTRichTextBox m_dtcLimbActivity;
        private cltDataGridDSTRichTextBox m_dtcStool;
        private cltDataGridDSTRichTextBox m_dtcUrine;
        private System.Windows.Forms.DataGridTextBoxColumn clmRecordSign;
        private DataTable dtTempTable;
        private string m_strTempColumnName = "";
        protected clsBaseCaseHistoryDomain m_objDomain;
        public frmAYQBabyAssessmentRecord()
        {
            InitializeComponent();
            dtTempTable = new DataTable("RecordDetail");
        }
        protected override Font m_FntHeaderFont
        {
            get
            {
                return new System.Drawing.Font("SimSun", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
            }
        }
        // 初始化具体表单的DataTable。
        // 注意，DataTable的第一个Column必须是存放记录时间的字符串，第二个Column必须是存放记录类型的int值，第三个Column必须是存放记录的OpenDate
        protected override void m_mthInitDataTable(DataTable p_dtbRecordTable)
        {

            //存放记录时间的字符串
            p_dtbRecordTable.Columns.Add("RecordDate");//0
            //存放记录类型的int值
            DataColumn dcRecordType = new DataColumn("RecordType", typeof(int));
            p_dtbRecordTable.Columns.Add(dcRecordType);//1
            //存放记录的OpenDate字符串
            p_dtbRecordTable.Columns.Add("OpenDate");  //2
            //存放记录的ModifyDate字符串
            p_dtbRecordTable.Columns.Add("ModifyDate"); //3
            DataColumn dc1 = p_dtbRecordTable.Columns.Add("RecordDateofDay");//4
            dc1.DefaultValue = "";
            DataColumn dc2 = p_dtbRecordTable.Columns.Add("RecordTime");//5
            dc2.DefaultValue = "";
            p_dtbRecordTable.Columns.Add("Facecolor", typeof(clsDSTRichTextBoxValue));//6
            p_dtbRecordTable.Columns.Add("Respiration", typeof(clsDSTRichTextBoxValue));//7
            p_dtbRecordTable.Columns.Add("Reaction", typeof(clsDSTRichTextBoxValue));//8
            p_dtbRecordTable.Columns.Add("TakeFood", typeof(clsDSTRichTextBoxValue));//9
            p_dtbRecordTable.Columns.Add("ArmpitWet", typeof(clsDSTRichTextBoxValue));//10
            p_dtbRecordTable.Columns.Add("Derm", typeof(clsDSTRichTextBoxValue));//11
            p_dtbRecordTable.Columns.Add("Aurigo", typeof(clsDSTRichTextBoxValue));//12
            p_dtbRecordTable.Columns.Add("UmbilicalRegion", typeof(clsDSTRichTextBoxValue));//13
            p_dtbRecordTable.Columns.Add("LimbActivity", typeof(clsDSTRichTextBoxValue));//14
            p_dtbRecordTable.Columns.Add("Stool", typeof(clsDSTRichTextBoxValue));//15
            p_dtbRecordTable.Columns.Add("Urine", typeof(clsDSTRichTextBoxValue));//16
            p_dtbRecordTable.Columns.Add("RecordSign");//17
            //存放记录创建者ID
            p_dtbRecordTable.Columns.Add("CreateUserID");//18
            m_mthSetControl(clmRecordDateofDay);
            m_mthSetControl(clmCreateTime);
            m_mthSetControl(m_dtcFacecolor);
            m_mthSetControl(m_dtcRespiration);
            m_mthSetControl(m_dtcReaction);
            m_mthSetControl(m_dtcTakeFood);
            m_mthSetControl(m_dtcArmpitWet);
            m_mthSetControl(m_dtcDerm);
            m_mthSetControl(m_dtcAurigo);
            m_mthSetControl(m_dtcUmbilicalRegion);
            m_mthSetControl(m_dtcLimbActivity);
            m_mthSetControl(m_dtcStool);
            m_mthSetControl(m_dtcUrine);
            m_mthSetControl(clmRecordSign);
            //设置文字栏
            this.clmRecordDateofDay.HeaderText = "\r\n\r\n  日期";
            this.clmCreateTime.HeaderText = "\r\n\r\n  时间";
            this.m_dtcFacecolor.HeaderText = "  面\r\n\r\n\r\n\r\n  色";
            this.m_dtcRespiration.HeaderText = "  呼\r\n\r\n\r\n\r\n  吸";
            this.m_dtcReaction.HeaderText = "  反\r\n\r\n\r\n\r\n  应";
            this.m_dtcTakeFood.HeaderText = "  进\r\n\r\n\r\n\r\n  食";
            this.m_dtcArmpitWet.HeaderText = "  腋\r\n\r\n\r\n\r\n  湿";
            this.m_dtcDerm.HeaderText = "  皮\r\n\r\n\r\n\r\n  肤";
            this.m_dtcAurigo.HeaderText = "  黄\r\n\r\n\r\n\r\n  疸";
            this.m_dtcUmbilicalRegion.HeaderText = "  脐\r\n\r\n\r\n\r\n  部";
            this.m_dtcLimbActivity.HeaderText = " 四肢\r\n\r\n\r\n\r\n 行动";
            this.m_dtcStool.HeaderText = "  大\r\n\r\n  便\r\n\r\n /次";
            this.m_dtcUrine.HeaderText = "  小\r\n\r\n  便\r\n\r\n /次";
            this.clmRecordSign.HeaderText = "       签\r\n\r\n\r\n\r\n       名";
        }
        //设置初始的比较日期
        private DateTime m_dtmPreRecordDate;
        protected override void m_mthClearRecordInfo()
        {
            m_dtmPreRecordDate = DateTime.MinValue;
            m_dtgRecordDetail.CurrentRowIndex = 0;
            m_dtbRecords.Rows.Clear();
        }

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

        // 获取病程记录的领域层实例
        protected override clsRecordsDomain m_objGetRecordsDomain()
        {
            return new clsRecordsDomain(enmRecordsType.AYQBabyAssessmentRecordRec);
        }

        // 获取记录的主要信息（必须获取的是CreateDate,OpenDate,LastModifyDate）
        protected override clsTrackRecordContent m_objGetRecordMainContent(int p_intRecordType,
            object[] p_objDataArr)
        {
            //根据 p_intRecordType 获取对应的 clsTrackRecordContent
            clsTrackRecordContent objContent = null;
            switch ((enmDiseaseTrackType)p_intRecordType)
            {
                case enmDiseaseTrackType.AYQBabyAssessmentRecord:
                    objContent = new clsAYQBabyAssessmentContent();
                    break;
            }

            if (objContent == null)
                objContent = new clsAYQBabyAssessmentContent();

            if (m_objCurrentPatient != null)
                objContent.m_strInPatientID = m_objCurrentPatient.m_StrInPatientID;
            else
            {
                clsPublicFunction.ShowInformationMessageBox("当前病人为空!");
                return null;
            }
            //int intSelectedRecordStartRow = m_dtgRecordDetail.CurrentCell.RowNumber;
            //string strExecuteSign = (m_dtbRecords.Rows[intSelectedRecordStartRow][22]).ToString();

            //if (strExecuteSign != null && strDetailSign.Trim() != "")
            //{
            //    string[] strArr = strDetailSign.Split('★');
            //    if (strArr != null && strArr[0] != string.Empty)
            //    {
            //        objContent.m_strCreateUserID = strArr[0];
            //    }
            //}
            objContent.m_dtmInPatientDate = m_objCurrentPatient.m_DtmSelectedInDate;
            objContent.m_dtmCreateDate = DateTime.Parse((string)p_objDataArr[0]);
            objContent.m_dtmOpenDate = DateTime.Parse((string)p_objDataArr[2]);
            objContent.m_dtmModifyDate = DateTime.Parse((string)p_objDataArr[3]);
            objContent.m_strCreateUserID = (string)p_objDataArr[18];

            return objContent;
        }

        private void frmAYQBabyAssessmentRecord_Load(object sender, System.EventArgs e)
        {
            m_dtmPreRecordDate = DateTime.MinValue;
            m_dtgRecordDetail.Focus();
            m_mniAddBlank.Visible = false;
            m_mniDeleteBlank.Visible = false;
        }

        private void m_mthSubFormClosed(object p_objSender, EventArgs p_objArg)
        {

        }

        // 获取处理（添加和修改）记录的窗体。
        protected override frmDiseaseTrackBase m_frmGetRecordForm(int p_intRecordType)
        {
            switch ((enmDiseaseTrackType)p_intRecordType)
            {
                case enmDiseaseTrackType.AYQBabyAssessmentRecordRec:
                    return new frmAYQBabyAssessmentRecord_Rec();
                case enmDiseaseTrackType.AYQBabyAssessmentRecord:
                    return new frmAYQBabyAssessmentRecord_Rec();
            }

            return null;
        }

        /// <summary>
        /// 处理子窗体
        /// </summary>
        /// <param name="p_frmSubForm"></param>
        protected override void m_mthHandleSubFormClosedWithYes(frmDiseaseTrackBase p_frmSubForm)
        {
            m_mthPerformSessionChanged(m_ObjCurrentEmrPatientSession, 0);
        }
        /// <summary>
        /// 从Table删除数据
        /// </summary>
        /// <param name="p_intRecordType"></param>
        /// <param name="p_dtmCreateRecordTime"></param>
        protected override void m_mthRemoveDataFromDataTable(int p_intRecordType,
            DateTime p_dtmCreateRecordTime)
        {
            m_mthPerformSessionChanged(m_ObjCurrentEmrPatientSession, 0);
        }

        /// <summary>
        /// 获取当前病人的作废内容
        /// </summary>
        /// <param name="p_dtmRecordDate">记录日期</param>
        /// <param name="p_intFormID">窗体ID</param>
        protected override void m_mthGetDeactiveContent(DateTime p_dtmRecordDate, int p_intFormID)
        {
            m_mthGetDeletedRecord(p_intFormID, p_dtmRecordDate);
        }

        protected override void m_mthModifyRecord(int p_intRecordType,
            DateTime p_dtmCreateRecordTime)
        {
            PrivilegeData.enmPrivilegeSF enmSF = (PrivilegeData.enmPrivilegeSF)Enum.Parse(typeof(PrivilegeData.enmPrivilegeSF), this.GetType().Name);
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(enmSF,PrivilegeData.enmPrivilegeOperation.AddOrModify))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return;
			}			
#endif
            //获取添加记录的窗体
            frmDiseaseTrackBase frmAddNewForm = m_frmGetRecordForm(p_intRecordType);
            frmAddNewForm.m_mthSetDiseaseTrackInfo(m_objCurrentPatient, p_dtmCreateRecordTime);

            m_mthShowSubForm(frmAddNewForm, p_intRecordType, true);
        }

        protected override void m_mthClearPatientRecordInfo()
        {
            m_mthSetDataGridFirstRowFocus();
            m_dtgRecordDetail.CurrentRowIndex = 0;
            m_dtbRecords.Rows.Clear();
            //清空记录内容                       
            m_mthClearRecordInfo();
            dtTempTable.Rows.Clear();
        }

        private void mniAppend_Click(object sender, System.EventArgs e)
        {
            PrivilegeData.enmPrivilegeSF enmSF = (PrivilegeData.enmPrivilegeSF)Enum.Parse(typeof(PrivilegeData.enmPrivilegeSF), this.GetType().Name);
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(enmSF,PrivilegeData.enmPrivilegeOperation.AddOrModify))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return;
			}			
#endif
            m_mthAddNewRecord((int)enmDiseaseTrackType.AYQBabyAssessmentRecord);
        }

        protected override object[][] m_objGetRecordsValueArr(clsTransDataInfo p_objTransDataInfo)
        {
            #region 显示记录到DataGrid
            try
            {
                object[] objData;
                ArrayList objReturnData = new ArrayList();
                int intCurrentDetail = 0;//当前病情记录在ArrayList中的索引
                int intRecordCount = 0;
                bool blnPreIsHide = false;//判断上一条记录是否被隐藏

                clsAYQBabyAssessmentContent_DataInfo objGNRCInfo = new clsAYQBabyAssessmentContent_DataInfo();
                clsDSTRichTextBoxValue objclsDSTRichTextBoxValue;
                string strText, strXml;

                objGNRCInfo = (clsAYQBabyAssessmentContent_DataInfo)p_objTransDataInfo;

                if (objGNRCInfo.m_objRecordArr == null && objGNRCInfo.m_objDetail == null)
                    return null;
                if (objGNRCInfo.m_objRecordArr != null)
                    intRecordCount = objGNRCInfo.m_objRecordArr.Length;
                int intRowOfCurrentDetail = 0;

                #region 获取修改限定时间
                int intCanModifyTime = 0;
                try
                {
                    intCanModifyTime = int.Parse(m_strCanModifyTime);
                }
                catch
                {
                    intCanModifyTime = 6;
                }
                #endregion

                clsAYQBabyAssessmentContent objCurrent;
                clsAYQBabyAssessmentContent objNext;
                for (int i = 0; i < intRecordCount; i++)
                {
                    objData = new object[19];
                    objCurrent = objGNRCInfo.m_objRecordArr[i];
                    objNext = new clsAYQBabyAssessmentContent();//下一条护理记录
                    if (i < intRecordCount - 1)
                        objNext = objGNRCInfo.m_objRecordArr[i + 1];
                    clsAYQBabyAssessmentContent objLast = null;
                    if (i > 0)
                        objLast = objGNRCInfo.m_objRecordArr[i - 1];
                    //如果该护理记录是修改前的记录且是在指定时间内修改的，修改者与创建者为同一人，则不显示
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strModifyUserID.Trim() == objCurrent.m_strCreateUserID.Trim()
                        && objNext.m_dtmOpenDate == objCurrent.m_dtmOpenDate)
                    {
                        TimeSpan tsModify = objNext.m_dtmModifyDate - objCurrent.m_dtmModifyDate;
                        if ((int)tsModify.TotalHours < intCanModifyTime)
                        {
                            blnPreIsHide = true;
                            continue;
                        }
                    }
                    #region 存放关键字段
                    if (objCurrent.m_dtmCreateDate != DateTime.MinValue)
                    {
                        objData[0] = objCurrent.m_dtmRECORDDATE;//存放记录时间的字符串
                        objData[1] = (int)enmRecordsType.AYQBabyAssessmentRecordRec;//存放记录类型的int值
                        objData[2] = objCurrent.m_dtmOpenDate;//存放记录的OpenDate字符串
                        objData[3] = objCurrent.m_dtmModifyDate;//存放记录的ModifyDate字符串  
                        objData[4] = objCurrent.m_dtmRECORDDATE.Date.ToString("yyyy-MM-dd");//日期字符串
                        objData[5] = objCurrent.m_dtmRECORDDATE.ToString("HH:mm");//时间字符串
                        objData[18] = objCurrent.m_strCreateUserID;//存放记录的createUserid字符串   

                    }
                    #endregion ;
                    #region 存放单项信息
                    bool blnIsRed = false;
                    //面色
                    strText = objCurrent.m_strFacecolor;
                    strXml = "<root />";
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[6] = objclsDSTRichTextBoxValue;
                    //呼吸
                    strText = objCurrent.m_strRespiration;
                    strXml = "<root />";
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[7] = objclsDSTRichTextBoxValue;
                    //反应
                    strText = objCurrent.m_strReaction;
                    strXml = "<root />";
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[8] = objclsDSTRichTextBoxValue;
                    //进食
                    strText = objCurrent.m_strTakeFood;
                    strXml = "<root />";
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[9] = objclsDSTRichTextBoxValue;
                    //腋湿
                    strText = objCurrent.m_strArmpitWet;
                    strXml = "<root />";
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[10] = objclsDSTRichTextBoxValue;
                    //皮肤
                    strText = objCurrent.m_strDerm;
                    strXml = "<root />";
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[11] = objclsDSTRichTextBoxValue;
                    //黄疸
                    strText = objCurrent.m_strAurigo;
                    strXml = "<root />";
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[12] = objclsDSTRichTextBoxValue;
                    //脐部
                    strText = objCurrent.m_strUmbilicalRegion;
                    strXml = "<root />";
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[13] = objclsDSTRichTextBoxValue;
                    //四肢活动
                    strText = objCurrent.m_strLimbActivity;
                    strXml = "<root />";
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[14] = objclsDSTRichTextBoxValue;
                    //大便
                    strText = objCurrent.m_strStool;
                    strXml = "<root />";
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[15] = objclsDSTRichTextBoxValue;
                    //小便
                    strText = objCurrent.m_strUrine;
                    strXml = "<root />";
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[16] = objclsDSTRichTextBoxValue;
                    //签名
                    strText = objCurrent.m_strRecordSign;
                    objData[17] = strText;
                    objReturnData.Add(objData);
                    #endregion
                }
                object[][] m_objRe = new object[objReturnData.Count][];

                for (int m = 0; m < objReturnData.Count; m++)
                    m_objRe[m] = (object[])objReturnData[m];
                return m_objRe;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            #endregion
        }

        #region 打印
        protected override void m_mthStartPrint()
        {
            try
            {
                if (m_pdcPrintDocument.DefaultPageSettings == null)
                {
                    m_pdcPrintDocument.DefaultPageSettings = new PageSettings();
                }
                m_pdcPrintDocument.DefaultPageSettings.Landscape = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("No Printers installed") >= 0)
                    clsPublicFunction.ShowInformationMessageBox("找不到打印机！");
                else MessageBox.Show(ex.Message);
            }

            base.m_mthStartPrint();

        }

        protected override infPrintRecord m_objGetPrintTool()
        {
            return new clsAYQBabyAssessmentRecordPrintTool();
        }
        protected override void m_mthSave()
        {
            long m_lngRe = m_lngSave();
            if (m_lngRe == 99)
            {
                return;
            }
            if (m_lngRe > 0)
            {
                m_blnNeedCheckArchive = false;
                m_mthPerformSessionChanged(m_ObjCurrentEmrPatientSession, 0);
                m_blnNeedCheckArchive = true;
                clsPublicFunction.ShowInformationMessageBox("保存成功！");
            }
            else
                clsPublicFunction.ShowInformationMessageBox("保存失败！");
        }
        protected override long m_lngSubAddNew()
        {
              return m_lngAddNewRecord();
        }
        protected override long m_lngSubModify()
        { }
        protected long m_lngAddNewRecord()
        {
            //检查当前病人变量是否为null
            if (m_objCurrentPatient == null)
                return (long)enmOperationResult.Parameter_Error;

            if (m_ObjCurrentEmrPatientSession == null)
            {
    #if !Debug
                clsPublicFunction.ShowInformationMessageBox("请选择病人入院日期。");
    #endif
                return -7;
            }

            //获取服务器时间
            clsPublicDomain m_objPDomain = new clsPublicDomain();

            //从界面获取记录信息
            clsAYQBabyAssessmentContent objContent = m_objGetContentFromGUI();

            string strDiseaseID = new clsTemplateDomain().m_strGetAssociateIDBySetID(m_strGetTemplateSetID(), (int)enmAssociate.Disease);

            //界面输入值出错
            if (objContent == null)
                return (long)enmOperationResult.Parameter_Error;

            //设置 clsInPatientCaseHistoryContent 的信息（使用服务器时间设置m_dtmOpenDate和m_dtmModifyDate）
            objContent.m_bytIfConfirm = 0;
            objContent.m_bytStatus = 0;
            objContent.m_dtmInPatientDate = m_objCurrentPatient.m_DtmSelectedInDate;
            objContent.m_dtmModifyDate = DateTime.Parse(m_objPDomain.m_strGetServerTime());
            objContent.m_dtmOpenDate = DateTime.Parse(m_objPDomain.m_strGetServerTime());
            //objContent.m_strCreateUserID =MDIParent.strOperatorID;
            objContent.m_strInPatientID = m_objCurrentPatient.m_StrInPatientID;
            objContent.m_strModifyUserID = objContent.m_strModifyUserID;
            objContent.m_dtmCreateDate = DateTime.Parse(this.m_dtpCreateDate.Text);

            //保存记录
            clsPreModifyInfo p_objModifyInfo = null;

            long lngRes = m_objDomain.m_lngAddNewRecord(objContent, objPicValueArr, strDiseaseID, out p_objModifyInfo);

            //根据结果做不同的处理
            switch ((enmOperationResult)lngRes)
            {
                case enmOperationResult.DB_Succeed:
                    m_objCurrentRecordContent = objContent;
                    m_dtmCreatedDate = objContent.m_dtmOpenDate;
                    m_mthHandleAddRecordSucceed();
                    this.m_dtpCreateDate.Enabled = false;
                    break;
                case enmOperationResult.Record_Already_Exist:
                    m_mthShowRecordTimeDouble();
                    return lngRes;
            }
            //返回结果
            return lngRes;
        }
        protected clsAYQBabyAssessmentContent m_objGetContentFromGUI()
        {
            clsAYQBabyAssessmentContent m_objContent = new clsAYQBabyAssessmentContent();
            try
            {
                m_objContent.m_strEspRecord = this.m_rboEspRecord.m_strGetRightText();
                m_objContent.m_strEspRecordAll = this.m_rboEspRecord.Text;
                m_objContent.m_strEspRecordXML = this.m_rboEspRecord.m_strGetXmlText();
            }
            catch
            {
                MessageBox.Show(exp.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return m_objContent;
        }
        private string m_strGetTemplateSetID()
        {
            foreach (Control ctlSub in this.Controls)
            {
                if (ctlSub.Name == "m_lstTemplate" && ctlSub.Tag != null)
                    return ctlSub.Tag.ToString();
            }
            return "";
        }
        #endregion
    }
}
