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
using com.digitalwave.clsGeneralNurseRecord_CSObstetricNewChildService;
using com.digitalwave.Emr.Signature_gui;

namespace iCare
{
    /// <summary>
    /// 茶山一般患者护理记录(产科新生儿)主窗体
    /// </summary>
    public partial class frmGeneralNurse_ObstetricNewChild : iCare.frmRecordsBase
    {
        private System.Windows.Forms.DataGridTextBoxColumn clmRecordDateofDay;
        private System.Windows.Forms.DataGridTextBoxColumn clmCreateTime;
        private cltDataGridDSTRichTextBox m_dtcTemperature;
        private cltDataGridDSTRichTextBox m_dtcHeartRate;
        private cltDataGridDSTRichTextBox m_dtcRespiration;
        private cltDataGridDSTRichTextBox m_dtcFontanel;
        private cltDataGridDSTRichTextBox m_dtcCaputsuccedaneum;
        private cltDataGridDSTRichTextBox m_dtcBloodEdema;
        private cltDataGridDSTRichTextBox m_dtcFaceColor;
        private cltDataGridDSTRichTextBox m_dtcCry;
        private cltDataGridDSTRichTextBox m_dtcSuckPower;
        private cltDataGridDSTRichTextBox m_dtcUmbilicalRegion;
        private cltDataGridDSTRichTextBox m_dtcStool;
        private cltDataGridDSTRichTextBox m_dtcUrine;
        private System.Windows.Forms.DataGridTextBoxColumn clmExecuteSign;
        private cltDataGridDSTRichTextBox m_dtcContent;
        private System.Windows.Forms.DataGridTextBoxColumn clmRecordSign;
        private DataTable dtTempTable;
        private string m_strTempColumnName = "";
        public frmGeneralNurse_ObstetricNewChild()
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
            p_dtbRecordTable.Columns.Add("Temperature", typeof(clsDSTRichTextBoxValue));//6
            p_dtbRecordTable.Columns.Add("HeartRate", typeof(clsDSTRichTextBoxValue));//7
            p_dtbRecordTable.Columns.Add("Respiration", typeof(clsDSTRichTextBoxValue));//8
            p_dtbRecordTable.Columns.Add("Fontanel", typeof(clsDSTRichTextBoxValue));//9
            p_dtbRecordTable.Columns.Add("Caputsuccedaneum", typeof(clsDSTRichTextBoxValue));//10
            p_dtbRecordTable.Columns.Add("BloodEdema", typeof(clsDSTRichTextBoxValue));//11
            p_dtbRecordTable.Columns.Add("FaceColor", typeof(clsDSTRichTextBoxValue));//12
            p_dtbRecordTable.Columns.Add("Cry", typeof(clsDSTRichTextBoxValue));//13
            p_dtbRecordTable.Columns.Add("SuckPower", typeof(clsDSTRichTextBoxValue));//14
            p_dtbRecordTable.Columns.Add("UmbilicalRegion", typeof(clsDSTRichTextBoxValue));//15
            p_dtbRecordTable.Columns.Add("Stool", typeof(clsDSTRichTextBoxValue));//16
            p_dtbRecordTable.Columns.Add("Urine", typeof(clsDSTRichTextBoxValue));//17
            DataColumn dc3 = p_dtbRecordTable.Columns.Add("ExecuseSign");//18
            dc3.DefaultValue = "";
            p_dtbRecordTable.Columns.Add("Content", typeof(clsDSTRichTextBoxValue));//19
            p_dtbRecordTable.Columns.Add("DetailRecordTime");//20
            p_dtbRecordTable.Columns.Add("RecordAndDetailSign");//21
            //存放记录创建者ID
            p_dtbRecordTable.Columns.Add("CreateUserID");//22

            m_dtcContent.m_RtbBase.m_BlnReadOnly = true;
            m_mthSetControl(clmRecordDateofDay);
            m_mthSetControl(clmCreateTime);
            m_mthSetControl(m_dtcTemperature);
            m_mthSetControl(m_dtcHeartRate);
            m_mthSetControl(m_dtcRespiration);
            m_mthSetControl(m_dtcFontanel);
            m_mthSetControl(m_dtcCaputsuccedaneum);
            m_mthSetControl(m_dtcBloodEdema);
            m_mthSetControl(m_dtcFaceColor);
            m_mthSetControl(m_dtcCry);
            m_mthSetControl(m_dtcSuckPower);
            m_mthSetControl(m_dtcUmbilicalRegion);
            m_mthSetControl(m_dtcStool);
            m_mthSetControl(m_dtcUrine);
            m_mthSetControl(clmExecuteSign);
            m_mthSetControl(m_dtcContent);
            m_mthSetControl(clmRecordSign);
            //设置文字栏
            this.clmRecordDateofDay.HeaderText = "\r\n\r\n   日期";
            this.clmCreateTime.HeaderText = "\r\n\r\n  时间";
            this.m_dtcTemperature.HeaderText = "  体\r\n\r\n  温\r\n\r\n  ℃";
            this.m_dtcHeartRate.HeaderText = "  心\r\n\r\n  率\r\n\r\n 次/分";
            this.m_dtcRespiration.HeaderText = "  呼\r\n\r\n  吸\r\n\r\n 次/分";
            this.m_dtcFontanel.HeaderText = "  囟\r\n\r\n\r\n\r\n  门 ";
            this.m_dtcCaputsuccedaneum.HeaderText = "  产\r\n\r\n\r\n\r\n  瘤 ";
            this.m_dtcBloodEdema.HeaderText = "  血\r\n\r\n\r\n\r\n  肿 ";
            this.m_dtcFaceColor.HeaderText = "  面\r\n\r\n\r\n\r\n  色";
            this.m_dtcCry.HeaderText = "  哭\r\n\r\n\r\n\r\n  声";
            this.m_dtcSuckPower.HeaderText = "  吸\r\n\r\n  吮\r\n\r\n  力";
            this.m_dtcUmbilicalRegion.HeaderText = "  脐\r\n\r\n\r\n\r\n  部";
            this.m_dtcStool.HeaderText = "  大\r\n\r\n  便\r\n\r\n /次";
            this.m_dtcUrine.HeaderText = "  小\r\n\r\n  便\r\n\r\n /次";
            this.clmExecuteSign.HeaderText = "\r\n\r\n    执行签名";
            this.m_dtcContent.HeaderText = "\r\n\r\n    病情观察、护理措施、效果";
            this.clmRecordSign.HeaderText = "\r\n\r\n    记录签名";
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
            return new clsRecordsDomain(enmRecordsType.GeneralNurseRecord_ObstetricNewChildRec);
        }

        // 获取记录的主要信息（必须获取的是CreateDate,OpenDate,LastModifyDate）
        protected override clsTrackRecordContent m_objGetRecordMainContent(int p_intRecordType,
            object[] p_objDataArr)
        {
            //根据 p_intRecordType 获取对应的 clsTrackRecordContent
            clsTrackRecordContent objContent = null;
            switch ((enmDiseaseTrackType)p_intRecordType)
            {
                case enmDiseaseTrackType.GeneralNurseRecord_ObstetricNewChild:
                    objContent = new clsGeneralNurseRecordContent_ObstetricNewChild();
                    break;
            }

            if (objContent == null)
                objContent = new clsGeneralNurseRecordContent_ObstetricNewChild();

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
            objContent.m_strCreateUserID = (string)p_objDataArr[22];

            return objContent;
        }

        private void frmGeneralNurse_ObstetricNewChild_Load(object sender, System.EventArgs e)
        {
            #region 添加右键菜单
            System.Windows.Forms.MenuItem mniContentAdd = new System.Windows.Forms.MenuItem();
            mniContentAdd.Index = 10;
            mniContentAdd.Text = "添加病情观察、护理措施、效果";
            mniContentAdd.Click += new System.EventHandler(mniContentAdd_Click);
            System.Windows.Forms.MenuItem mniContentModify = new System.Windows.Forms.MenuItem();
            mniContentModify.Index = 11;
            mniContentModify.Text = "修改病情观察、护理措施、效果";
            mniContentModify.Click += new System.EventHandler(mniContentModify_Click);
            System.Windows.Forms.MenuItem mniContentDelete = new System.Windows.Forms.MenuItem();
            mniContentDelete.Index = 12;
            mniContentDelete.Text = "删除病情观察、护理措施、效果";
            mniContentDelete.Click += new System.EventHandler(mniContentDelete_Click);
            this.ctmRecordControl.MenuItems.Add(mniContentAdd);
            this.ctmRecordControl.MenuItems.Add(mniContentModify);
            this.ctmRecordControl.MenuItems.Add(mniContentDelete);

            #endregion ;
            m_dtmPreRecordDate = DateTime.MinValue;
            m_dtgRecordDetail.Focus();
            m_mniAddBlank.Visible = false;
            m_mniDeleteBlank.Visible = false;
            this.m_pnlNewBase.Dock = DockStyle.Top;
            this.m_dtgRecordDetail.Dock = DockStyle.Fill;
            this.panel1.Dock = DockStyle.Fill;
            //this.label1.Dock = DockStyle.Bottom;
        }

        private void m_mthSubFormClosed(object p_objSender, EventArgs p_objArg)
        {
            frmGeneralNurse_ObstetricNewChildCon frmAddNewForm = (frmGeneralNurse_ObstetricNewChildCon)p_objSender;
            //显示窗体

            if (frmAddNewForm.DialogResult == DialogResult.Yes)
            {
                m_mthPerformSessionChanged(m_ObjCurrentEmrPatientSession, 0);
            }
            m_FrmCurrentSub = null;
        }

        /// <summary>
        /// 添加病程记录内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mniContentAdd_Click(object sender, System.EventArgs e)
        {
            long lngRes = 0;
            try
            {
                //验证
                //传递参数
                //打开窗体	
                if (this.m_FrmCurrentSub != null)
                {
                    this.m_FrmCurrentSub.Activate();
                    this.m_FrmCurrentSub.WindowState = FormWindowState.Normal;
                    return;
                }
                frmGeneralNurse_ObstetricNewChildCon frm = new frmGeneralNurse_ObstetricNewChildCon(true, m_objCurrentPatient.m_StrEMRInPatientID, m_objCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"), "2005");
                frm.Closed += new EventHandler(m_mthSubFormClosed);
                //更新
                //frm.TopMost = true;
                this.m_FrmCurrentSub = frm;
                frm.Show();
                if (MDIParent.s_ObjCurrentPatient != null)
                    frm.m_mthSetPatient(MDIParent.s_ObjCurrentPatient);
            }
            catch (Exception ex)
            {
                string strMsg = ex.Message;
            }
        }
        /// <summary>
        /// 修改病程记录内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mniContentModify_Click(object sender, System.EventArgs e)
        {
            long lngRes = 0;
            try
            {
                if (this.m_FrmCurrentSub != null)
                {
                    this.m_FrmCurrentSub.Activate();
                    this.m_FrmCurrentSub.WindowState = FormWindowState.Normal;
                    return;
                }
                //验证
                if (m_dtgRecordDetail.CurrentCell.ColumnNumber != 15)
                {
                    MessageBox.Show("请选中一条病情观察、护理措施、效果的内容！");
                    return;
                }

                //传递参数
                int intSelectedRecordStartRow = m_dtgRecordDetail.CurrentCell.RowNumber;
                string strRecordTime = (m_dtbRecords.Rows[intSelectedRecordStartRow][20]).ToString();
                if (strRecordTime.Trim().Length == 0)
                    return;
                //打开窗体
                frmGeneralNurse_ObstetricNewChildCon frm = new frmGeneralNurse_ObstetricNewChildCon(false, m_objCurrentPatient.m_StrEMRInPatientID, m_objCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"), strRecordTime);
                frm.Closed += new EventHandler(m_mthSubFormClosed);
                //更新
                //frm.TopMost = true;
                this.m_FrmCurrentSub = frm;
                frm.Show();
                if (MDIParent.s_ObjCurrentPatient != null)
                    frm.m_strSetRegisterId = MDIParent.s_ObjCurrentPatient.m_StrRegisterId;
                //frm.m_mthSetPatient(MDIParent.s_ObjCurrentPatient);
            }
            catch (Exception ex)
            {
                string strMsg = ex.Message;
            }
        }
        /// <summary>
        /// 删除病程记录内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mniContentDelete_Click(object sender, System.EventArgs e)
        {
            long lngRes = 0;
            try
            {
                //验证
                if (m_dtgRecordDetail.CurrentCell.ColumnNumber != 15)
                {
                    MessageBox.Show("请选中一条病情观察、护理措施、效果的内容！");
                    return;
                }
                ////验证删除
                //clsDeleteVerify objDeleteVerify = new clsDeleteVerify();
                //if (objDeleteVerify.m_mthIsDelete(null, null) == false)
                //{
                //    clsPublicFunction.ShowInformationMessageBox("验证失败不能删除！");
                //    return;
                //}
                //传递参数
                int intSelectedRecordStartRow = m_dtgRecordDetail.CurrentCell.RowNumber;

                string strDetailSign = (m_dtbRecords.Rows[intSelectedRecordStartRow][22]).ToString();

                //屏蔽 by tfzhang 2006-02-24
                if (strDetailSign != null && strDetailSign.Trim() != "")
                {
                    string[] strArr = strDetailSign.Split(',');
                    //if (strArr != null && strArr.Length > 1 && strArr[1] != string.Empty && strArr[1].Trim() != MDIParent.OperatorID.Trim())
                    //{
                    //    MDIParent.ShowInformationMessageBox("非记录创建者不能删除记录！");
                    //    return;
                    //}
                    //权限判断
                    if (strArr.Length > 1)
                    {
                        string strDeptIDTemp = m_ObjCurrentEmrPatientSession.m_strAreaId;// ((clsDepartment)m_cboDept.SelectedItem).m_strDeptNewID; 
                        bool blnIsAllow = clsPublicFunction.IsAllowDelete(strDeptIDTemp, strArr[1], clsEMRLogin.LoginEmployee, intFormType);
                        if (!blnIsAllow)
                            return;
                    }
                }


                string strRecordTime = (m_dtbRecords.Rows[intSelectedRecordStartRow][20]).ToString();
                if (strRecordTime.Trim().Length == 0)
                    return;
                //确认
                if (MessageBox.Show("确认要删除选中的病情观察、护理措施、效果的内容？", "删除提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    return;

                //打开窗体
                //删除

                clsGeneralNurseRecord_CSObstetricNewChildService objserv =
                    (clsGeneralNurseRecord_CSObstetricNewChildService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsGeneralNurseRecord_CSObstetricNewChildService));

                string strDelTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string strDelID = MDIParent.OperatorID;
                lngRes = objserv.m_lngDeleteDetail(m_objCurrentPatient.m_StrEMRInPatientID, m_objCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"), strRecordTime, strDelTime, strDelID);
                //更新
                if (lngRes > 0)
                {
                    m_mthPerformSessionChanged(m_ObjCurrentEmrPatientSession, 0);
                }

            }
            catch (Exception ex)
            {
                string strMsg = ex.Message;
            }
        }

        // 获取处理（添加和修改）记录的窗体。
        protected override frmDiseaseTrackBase m_frmGetRecordForm(int p_intRecordType)
        {
            switch ((enmDiseaseTrackType)p_intRecordType)
            {
                case enmDiseaseTrackType.GeneralNurseRecord_ObstetricNewChildRec:
                    return new frmGeneralNurse_ObstetricNewChildRec();
                case enmDiseaseTrackType.GeneralNurseRecord_ObstetricNewChild:
                    return new frmGeneralNurse_ObstetricNewChildRec();
                case enmDiseaseTrackType.GeneralNurseRecord_ObstetricNewChildCon:
                    return new frmGeneralNurse_ObstetricNewChildCon(false, m_objCurrentPatient.m_StrEMRInPatientID, m_objCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"), "");
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
            m_mthAddNewRecord((int)enmDiseaseTrackType.GeneralNurseRecord_ObstetricNewChild);
        }

        protected override object[][] m_objGetRecordsValueArr(clsTransDataInfo p_objTransDataInfo)
        {
            #region 显示记录到DataGrid
            try
            {
                object[] objData;
                ArrayList objReturnData = new ArrayList();
                ArrayList arlDetail = new ArrayList();//存放病情记录
                int intCurrentDetail = 0;//当前病情记录在ArrayList中的索引
                int intRecordCount = 0;
                bool blnPreIsHide = false;//判断上一条记录是否被隐藏
                int intCurrentSignIndex = 0;//记录签名索引
                bool blnMark = false;
                clsGeneralNurseRecordContent_ObstetricNewChildDataInfo objGNRCInfo = new clsGeneralNurseRecordContent_ObstetricNewChildDataInfo();
                clsDSTRichTextBoxValue objclsDSTRichTextBoxValue;
                string strText, strXml;

                objGNRCInfo = (clsGeneralNurseRecordContent_ObstetricNewChildDataInfo)p_objTransDataInfo;

                if (objGNRCInfo.m_objRecordArr == null && objGNRCInfo.m_objDetailArr == null)
                    return null;

                #region 对病情观察、护理措施、效果进行处理
                if (objGNRCInfo.m_objDetailArr != null)
                {
                    string strDetail = "";
                    string strDetailXML = "";
                    for (int n = 0; n < objGNRCInfo.m_objDetailArr.Length; n++)
                    {
                        clsGeneralNurseRecordContent_ObstetricNewChildDetail objDetail = objGNRCInfo.m_objDetailArr[n];
                        object[] objTemp = new object[7];
                        strDetail = objDetail.m_strRECORDCONTENTAll;
                        strDetailXML = objDetail.m_strRECORDCONTENTXML;
                        string[] strDetailArr;
                        string[] strDetailXMLArr;
                        //将病情记录分为行。
                        com.digitalwave.controls.ctlRichTextBox.m_mthSplitXmlByBytes(strDetail, strDetailXML, 42, out strDetailArr, out strDetailXMLArr);

                        if (strDetail != string.Empty)
                        {
                            objTemp[0] = strDetailArr;
                            objTemp[1] = strDetailXMLArr;
                            objTemp[2] = strDetailArr.Length;
                            objTemp[3] = objDetail.m_dtmRECORDDATE;
                            objTemp[4] = objDetail.objSignerArr;
                            objTemp[5] = objDetail.m_strDetailCreateUserName;
                            objTemp[6] = objDetail.m_strCREATERECORDUSERID;
                            arlDetail.Add(objTemp);
                        }
                    }
                }
                #endregion

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

                clsGeneralNurseRecordContent_ObstetricNewChild objCurrent;
                clsGeneralNurseRecordContent_ObstetricNewChild objNext;
                for (int i = 0; i < intRecordCount; i++)
                {
                    blnMark = false;
                    objData = new object[23];
                    objCurrent = objGNRCInfo.m_objRecordArr[i];
                    objNext = new clsGeneralNurseRecordContent_ObstetricNewChild();//下一条护理记录
                    if (i < intRecordCount - 1)
                        objNext = objGNRCInfo.m_objRecordArr[i + 1];
                    clsGeneralNurseRecordContent_ObstetricNewChild objLast = null;
                    if (i > 0)
                        objLast = objGNRCInfo.m_objRecordArr[i - 1];
                    //如果该护理记录是修改前的记录且是在指定时间内修改的，修改者与创建者为同一人，则不显示
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                      //  && objNext.m_strModifyUserID.Trim() == objCurrent.m_strCreateUserID.Trim()
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
                        objData[1] = (int)enmRecordsType.GeneralNurseRecord_ObstetricNewChildRec;//存放记录类型的int值
                        objData[2] = objCurrent.m_dtmOpenDate;//存放记录的OpenDate字符串
                        objData[3] = objCurrent.m_dtmModifyDate;//存放记录的ModifyDate字符串   
                        objData[22] = objCurrent.m_strCreateUserID;//存放记录的createUserid字符串   
                        //同一个则只在第一行显示日期
                        if (objCurrent.m_dtmRECORDDATE.Date.ToString() != m_dtmPreRecordDate.Date.ToString())
                        {
                            objData[4] = objCurrent.m_dtmRECORDDATE.Date.ToString("yyyy-MM-dd");//日期字符串
                        }
                        //修改后带有痕迹的记录不再显示时间
                        if (m_dtmPreRecordDate != objCurrent.m_dtmRECORDDATE)
                            objData[5] = objCurrent.m_dtmRECORDDATE.ToString("HH:mm");//时间字符串
                    }
                    #endregion ;
                    #region 存放单项信息
                    bool blnIsRed = false;
                    //体温
                    strText = objCurrent.m_strTEMPERATURE_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_dtmOpenDate == objCurrent.m_dtmOpenDate
                        && objNext.m_strTEMPERATURE_RIGHT != objCurrent.m_strTEMPERATURE_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strTEMPERATURE_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    if (objLast != null && objLast.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objLast.m_dtmOpenDate == objLast.m_dtmOpenDate
                        && string.IsNullOrEmpty(objLast.m_strTEMPERATURE_RIGHT) && !blnPreIsHide)
                    {
                        blnIsRed = true;
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    if (blnIsRed)
                    {
                        objclsDSTRichTextBoxValue.m_clrTextColor = Color.Red;
                        blnIsRed = false;
                    }
                    objData[6] = objclsDSTRichTextBoxValue;//T

                    //心率
                    strText = objCurrent.m_strHEARTRATE_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_dtmOpenDate == objCurrent.m_dtmOpenDate
                        && objNext.m_strHEARTRATE_RIGHT != objCurrent.m_strHEARTRATE_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strHEARTRATE_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    if (objLast != null && objLast.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objLast.m_dtmOpenDate == objCurrent.m_dtmOpenDate
                        && string.IsNullOrEmpty(objLast.m_strHEARTRATE_RIGHT) && !blnPreIsHide)
                    {
                        blnIsRed = true;
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    if (blnIsRed)
                    {
                        objclsDSTRichTextBoxValue.m_clrTextColor = Color.Red;
                        blnIsRed = false;
                    }
                    objData[7] = objclsDSTRichTextBoxValue;//HR
                    //呼吸
                    strText = objCurrent.m_strRESPIRATION_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_dtmOpenDate == objCurrent.m_dtmOpenDate
                        && objNext.m_strRESPIRATION_RIGHT != objCurrent.m_strRESPIRATION_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strRESPIRATION_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    if (objLast != null && objLast.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objLast.m_dtmOpenDate == objCurrent.m_dtmOpenDate
                        && string.IsNullOrEmpty(objLast.m_strRESPIRATION_RIGHT) && !blnPreIsHide)
                    {
                        blnIsRed = true;
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    if (blnIsRed)
                    {
                        objclsDSTRichTextBoxValue.m_clrTextColor = Color.Red;
                        blnIsRed = false;
                    }
                    objData[8] = objclsDSTRichTextBoxValue;//P

                    //囟门
                    strText = objCurrent.m_strFONTANEL;
                    strXml = "<root />";
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[9] = objclsDSTRichTextBoxValue;
                    //产瘤
                    strText = objCurrent.m_strCAPUTSUCCEDANEUM;
                    strXml = "<root />";
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[10] = objclsDSTRichTextBoxValue;
                    //血肿
                    strText = objCurrent.m_strBLOODEDEMA;
                    strXml = "<root />";
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[11] = objclsDSTRichTextBoxValue;
                    //面色
                    strText = objCurrent.m_strFACECOLOR;
                    strXml = "<root />";
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[12] = objclsDSTRichTextBoxValue;
                    //哭声
                    strText = objCurrent.m_strCRY;
                    strXml = "<root />";
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[13] = objclsDSTRichTextBoxValue;
                    //吸吮力
                    strText = objCurrent.m_strSUCKPOWER;
                    strXml = "<root />";
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[14] = objclsDSTRichTextBoxValue;
                    //脐部
                    strText = objCurrent.m_strUMBILICALREGION;
                    strXml = "<root />";
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[15] = objclsDSTRichTextBoxValue;
                    //大便
                    strText = objCurrent.m_strSTOOL_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_dtmOpenDate == objCurrent.m_dtmOpenDate
                        && objNext.m_strSTOOL_RIGHT != objCurrent.m_strSTOOL_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strSTOOL_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    if (objLast != null && objLast.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objLast.m_dtmOpenDate == objCurrent.m_dtmOpenDate
                        && string.IsNullOrEmpty(objLast.m_strSTOOL_RIGHT) && !blnPreIsHide)
                    {
                        blnIsRed = true;
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    if (blnIsRed)
                    {
                        objclsDSTRichTextBoxValue.m_clrTextColor = Color.Red;
                        blnIsRed = false;
                    }
                    objData[16] = objclsDSTRichTextBoxValue;//
                    //小便
                    strText = objCurrent.m_strURINE_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_dtmOpenDate == objCurrent.m_dtmOpenDate
                        && objNext.m_strURINE_RIGHT != objCurrent.m_strURINE_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strURINE_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    if (objLast != null && objLast.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objLast.m_dtmOpenDate == objCurrent.m_dtmOpenDate
                        && string.IsNullOrEmpty(objLast.m_strURINE_RIGHT) && !blnPreIsHide)
                    {
                        blnIsRed = true;
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    if (blnIsRed)
                    {
                        objclsDSTRichTextBoxValue.m_clrTextColor = Color.Red;
                        blnIsRed = false;
                    }
                    objData[17] = objclsDSTRichTextBoxValue;//
                   
                    #endregion
                    #region 病情观察、护理措施、效果
                    for (; intCurrentDetail < arlDetail.Count; intCurrentDetail++)
                    {//循环检查所有病情记录
                        if ((DateTime)((object[])arlDetail[intCurrentDetail])[3] == objCurrent.m_dtmRECORDDATE)
                        {//若当前记录日期与病情观察记录日期相同，先输出当前记录，再输出病情观察记录
                            #region 执行签名
                            int m_intMax = Math.Max(objCurrent.objSignerArr == null ? 0 : objCurrent.objSignerArr.Length, ((string[])(((object[])arlDetail[intCurrentDetail])[0])).Length + ((clsEmrSigns_VO[])(((object[])arlDetail[intCurrentDetail])[4])).Length - 1);
                            for (int m = 0; m < m_intMax; m++)
                            {
                                if (objCurrent.objSignerArr != null && m < objCurrent.objSignerArr.Length)
                                {
                                    strText = objCurrent.objSignerArr[m].objEmployee.m_strLASTNAME_VCHR;
                                    objData[18] = strText;
                                }
                                if (m < ((string[])(((object[])arlDetail[intCurrentDetail])[0])).Length)
                                {
                                    strText = ((string[])(((object[])arlDetail[intCurrentDetail])[0]))[m];
                                    strXml = ((string[])(((object[])arlDetail[intCurrentDetail])[1]))[m];
                                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                                    objclsDSTRichTextBoxValue.m_strText = strText;
                                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                                    objData[19] = objclsDSTRichTextBoxValue;
                                    objData[20] = (DateTime)((object[])arlDetail[intCurrentDetail])[3];
                                }
                                if (m >= ((string[])(((object[])arlDetail[intCurrentDetail])[0])).Length - 1 && m < ((string[])(((object[])arlDetail[intCurrentDetail])[0])).Length)
                                {
                                    objData[21] = ((clsEmrSigns_VO[])(((object[])arlDetail[intCurrentDetail])[4]))[intCurrentSignIndex++].objEmployee.m_strLASTNAME_VCHR;
                                }
                                else
                                {
                                    objData[21] = "";
                                }
                                objReturnData.Add(objData);
                                objData = new object[23];
                            }

                            m_dtmPreRecordDate = objCurrent.m_dtmRECORDDATE;
                            intCurrentSignIndex = 0;
                            intCurrentDetail++;
                            blnMark = true;
                            break;
                            #endregion
                        }
                        else if ((DateTime)(((object[])arlDetail[intCurrentDetail])[3]) < objCurrent.m_dtmRECORDDATE)
                        {//若当前记录日期大于病情观察记录日期，则输出病情观察记录，循环下一条病情观察记录
                            for (int j = intRowOfCurrentDetail; j < ((string[])(((object[])arlDetail[intCurrentDetail])[0])).Length; j++)
                            {
                                object[] objOtherDetail = new object[23];
                                m_mthSetOtherDetail(((object[])arlDetail[intCurrentDetail]), intCurrentDetail, j, objCurrent, out objOtherDetail);
                                if (j == 0)
                                {
                                    //同一个则只在第一行显示日期
                                    if (((DateTime)((object[])arlDetail[intCurrentDetail])[3]).ToString("yyyyMMdd") != m_dtmPreRecordDate.Date.ToString("yyyyMMdd") || m_dtmPreRecordDate == DateTime.MinValue)
                                    {
                                        objOtherDetail[4] = ((DateTime)((object[])arlDetail[intCurrentDetail])[3]).ToString("yyyy-MM-dd");
                                    }
                                    objOtherDetail[5] = ((DateTime)((object[])arlDetail[intCurrentDetail])[3]).ToString("HH:mm");
                                }
                                if ((clsEmrSigns_VO[])((object[])arlDetail[intCurrentDetail])[4] != null && j == ((string[])(((object[])arlDetail[intCurrentDetail])[0])).Length - 1)
                                {
                                    if (((clsEmrSigns_VO[])(((object[])arlDetail[intCurrentDetail])[4])) != null)
                                    {
                                        for (int h = 0; h < ((clsEmrSigns_VO[])(((object[])arlDetail[intCurrentDetail])[4])).Length; h++)
                                        {
                                            objOtherDetail[21] = ((clsEmrSigns_VO[])(((object[])arlDetail[intCurrentDetail])[4]))[h].objEmployee.m_strLASTNAME_VCHR;
                                            objReturnData.Add(objOtherDetail);
                                            objOtherDetail = new object[23];
                                        }
                                    }
                                    else
                                    {
                                        objOtherDetail[21] = "";
                                        objReturnData.Add(objOtherDetail);
                                        objOtherDetail = new object[23];
                                    }
                                }
                                else
                                {
                                    objOtherDetail[21] = "";
                                    objReturnData.Add(objOtherDetail);
                                }

                            }
                            m_dtmPreRecordDate = (DateTime)(((object[])arlDetail[intCurrentDetail])[3]);
                            intRowOfCurrentDetail = 0;

                        }
                        else
                        {//若当前记录日期小于病情观察记录日期，则输出当前记录，循环下一条当前记录
                            #region 执行签名、记录签名
                            //同一个则只在第一行显示日期
                            if (objCurrent.m_dtmRECORDDATE.Date.ToString("yyyyMMdd") != m_dtmPreRecordDate.Date.ToString("yyyyMMdd"))
                            {
                                objData[4] = objCurrent.m_dtmRECORDDATE.Date.ToString("yyyy-MM-dd");//日期字符串
                            }
                            if (objCurrent.objSignerArr != null)
                            {
                                for (int m = 0; m < objCurrent.objSignerArr.Length; m++)
                                {
                                    objData[18] = objCurrent.objSignerArr[m].objEmployee.m_strLASTNAME_VCHR;
                                    objData[21] = "";
                                    objReturnData.Add(objData);
                                    objData = new object[23];
                                }
                            }
                            m_dtmPreRecordDate = objCurrent.m_dtmRECORDDATE;
                            #endregion
                            break;
                        }
                    }
                    #endregion
                    if (!blnMark && intCurrentDetail == arlDetail.Count)
                    {
                        #region 执行签名、记录签名
                        //同一个则只在第一行显示日期
                        if (objCurrent.m_dtmRECORDDATE.Date.ToString("yyyyMMdd") != m_dtmPreRecordDate.Date.ToString("yyyyMMdd"))
                        {
                            objData[4] = objCurrent.m_dtmRECORDDATE.Date.ToString("yyyy-MM-dd");//日期字符串
                        }
                        if (objCurrent.objSignerArr != null)
                        {
                            for (int m = 0; m < objCurrent.objSignerArr.Length; m++)
                            {
                                objData[18] = objCurrent.objSignerArr[m].objEmployee.m_strLASTNAME_VCHR;
                                objData[21] = "";
                                objReturnData.Add(objData);
                                objData = new object[23];
                            }
                        }
                        m_dtmPreRecordDate = objCurrent.m_dtmRECORDDATE;
                        #endregion
                    }
                }

                #region 如果病情观察、护理措施、效果未显示完而其它护理记录已全部显示完，则继续输出剩余部分
                while (arlDetail != null && intCurrentDetail < arlDetail.Count && arlDetail.Count > 0)
                {
                    if (intRowOfCurrentDetail < ((string[])(((object[])arlDetail[intCurrentDetail])[0])).Length)
                    {
                        for (int m = intRowOfCurrentDetail; m < ((string[])(((object[])arlDetail[intCurrentDetail])[0])).Length; m++)
                        {
                            object[] objOtherDetail = new object[23];
                            m_mthSetOtherDetail(((object[])arlDetail[intCurrentDetail]), intCurrentDetail, m, null, out objOtherDetail);
                            if (m == 0)
                            {
                                //同一个则只在第一行显示日期
                                if (((DateTime)((object[])arlDetail[intCurrentDetail])[3]).ToString("yyyyMMdd") != m_dtmPreRecordDate.Date.ToString("yyyyMMdd"))
                                {
                                    objOtherDetail[4] = ((DateTime)((object[])arlDetail[intCurrentDetail])[3]).ToString("yyyy-MM-dd");
                                }
                                objOtherDetail[5] = ((DateTime)((object[])arlDetail[intCurrentDetail])[3]).ToString("HH:mm");
                            }
                            if ((clsEmrSigns_VO[])((object[])arlDetail[intCurrentDetail])[4] != null && m == ((string[])(((object[])arlDetail[intCurrentDetail])[0])).Length - 1)
                            {
                                if (((clsEmrSigns_VO[])(((object[])arlDetail[intCurrentDetail])[4])) != null)
                                {
                                    for (int h = 0; h < ((clsEmrSigns_VO[])(((object[])arlDetail[intCurrentDetail])[4])).Length; h++)
                                    {
                                        objOtherDetail[21] = ((clsEmrSigns_VO[])(((object[])arlDetail[intCurrentDetail])[4]))[h].objEmployee.m_strLASTNAME_VCHR;
                                        objReturnData.Add(objOtherDetail);
                                        objOtherDetail = new object[23];
                                    }
                                }
                                else
                                {
                                    objOtherDetail[21] = "";
                                    objReturnData.Add(objOtherDetail);
                                    objOtherDetail = new object[23];
                                }
                            }
                            else
                            {
                                objOtherDetail[21] = "";
                                objReturnData.Add(objOtherDetail);
                            }
                        }
                        m_dtmPreRecordDate = (DateTime)((object[])arlDetail[intCurrentDetail])[3];
                        intCurrentDetail++;
                        intRowOfCurrentDetail = 0;
                    }
                }
                object[][] m_objRe = new object[objReturnData.Count][];

                for (int m = 0; m < objReturnData.Count; m++)
                    m_objRe[m] = (object[])objReturnData[m];
                return m_objRe;
            }
                #endregion
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            #endregion
        }

        private void m_mthSetOtherDetail(object[] objDetail, int intCurrentDetail, int intRowOfCurrentDetail, clsGeneralNurseRecordContent_ObstetricNewChild objCurrent, out object[] objOtherDetail)
        {
            objOtherDetail = new object[23];
            string strText = ((string[])(objDetail[0]))[intRowOfCurrentDetail];
            string strXml = ((string[])(objDetail[1]))[intRowOfCurrentDetail];
            clsDSTRichTextBoxValue objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
            objclsDSTRichTextBoxValue.m_strText = strText;
            objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
            objOtherDetail[19] = objclsDSTRichTextBoxValue;
            objOtherDetail[20] = (DateTime)objDetail[3];
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
            return new clsGeneralNurseRecord_ObstetricNewChildPrintTool();
        }
        #endregion

        private void m_dtgRecordDetail_MouseUp(object sender, MouseEventArgs e)
        {
            //Point pt = new Point(e.X, e.Y);
            //DataGrid.HitTestInfo hit = this.m_dtgRecordDetail.HitTest(pt);
            //if (hit.Type == DataGrid.HitTestType.Cell)
            //{
            //    this.m_dtgRecordDetail.SelectionBackColor = Color.Blue;
            //    this.m_dtgRecordDetail.Select(hit.Row);
            //}
        }

        private void m_dtgRecordDetail_CurrentCellChanged(object sender, EventArgs e)
        {
            this.m_dtgRecordDetail.Select(m_dtgRecordDetail.CurrentCell.RowNumber);
        }
    }
}
