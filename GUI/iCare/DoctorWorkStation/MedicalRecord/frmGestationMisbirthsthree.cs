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
using com.digitalwave.Emr.Signature_gui;
namespace iCare
{
    /// <summary>
    /// 中期妊娠引产记录、中期妊娠引产分娩记录、中期妊娠引产后观察记录三合一
    /// </summary>
    public partial class frmGestationMisbirthsthree : iCare.frmBaseCaseHistory
    {
        #region 定义
        protected System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn clmRecordDateofDay;
        private System.Windows.Forms.DataGridTextBoxColumn clmCreateTime;
        private cltDataGridDSTRichTextBox m_dtcBLOODPRESSURE;
        private cltDataGridDSTRichTextBox m_dtcTEMPERATURE;
        private cltDataGridDSTRichTextBox m_dtcPULSE;
        private cltDataGridDSTRichTextBox m_dtcCONTRACTIONS;
        private cltDataGridDSTRichTextBox m_dtcBLEEDING;
        private cltDataGridDSTRichTextBox m_dtcBROKENWATER;
        private cltDataGridDSTRichTextBox m_dtcFETAL;
        private cltDataGridDSTRichTextBox m_dtcMIYAGUCHISIZE;
        private System.Windows.Forms.DataGridTextBoxColumn clmExecuteSign;
        private System.Windows.Forms.ContextMenu m_ctmRecordControl;
        private System.Windows.Forms.MenuItem m_mniAddBabyCircsRecord;
        private System.Windows.Forms.MenuItem m_mmiModifyBabyCircsRecord;
        private System.Windows.Forms.MenuItem m_mmiDelBabyCircsRecord;
        private DataTable m_dtbRecords;
        private bool m_blnCanShowNewForm = true;
        private new clsGestationMisbirthsthreeDomain m_objDomain;
        private new clsGestationMisbirthsthreeRelationVO m_objCurrentRecordContent;
        private string m_strCurrentOpenDate = "";
        private clsEmrSignToolCollection m_objSign;
        #endregion

        #region 构造函数

        public frmGestationMisbirthsthree()
        {
            InitializeComponent();
            m_dtbRecords = new DataTable("RecordDetail");
            m_objDomain = new clsGestationMisbirthsthreeDomain();
            m_objSign = new clsEmrSignToolCollection();
            m_objSign.m_mthBindEmployeeSign(m_cmdSurgeryer, lsvSign1, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdDealer, lsvSign2, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdSign, lsvSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
        }
        #endregion

        #region 设置字体
        protected virtual Font m_FntHeaderFont
        {
            get
            {
                return new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
            }
        }
        #endregion

        #region 初始化具体表单的DataTable
        // 初始化具体表单的DataTable。
        // 注意，DataTable的第一个Column必须是存放记录时间的字符串，第二个Column必须是存放记录类型的int值，第三个Column必须是存放记录的OpenDate
        private void m_mthInitDataTable(DataTable p_dtbRecordTable)
        {

            //存放记录时间的字符串
            p_dtbRecordTable.Columns.Add("CreateDate");//0
            //存放记录的OpenDate字符串
            p_dtbRecordTable.Columns.Add("OpenDate");  //1
            //存放记录的ModifyDate字符串
            p_dtbRecordTable.Columns.Add("ModifyDate"); //2


            //存放记录时间的字符串
            //p_dtbRecordTable.Columns.Add("RecordDate");//0

            DataColumn dc1 = p_dtbRecordTable.Columns.Add("RecordDateofDay");//4
            dc1.DefaultValue = "";
            DataColumn dc2 = p_dtbRecordTable.Columns.Add("RecordTime");//5
            dc2.DefaultValue = "";
            p_dtbRecordTable.Columns.Add("BLOODPRESSURE", typeof(clsDSTRichTextBoxValue));//9
            p_dtbRecordTable.Columns.Add("TEMPERATURE", typeof(clsDSTRichTextBoxValue));//9
            p_dtbRecordTable.Columns.Add("PULSE", typeof(clsDSTRichTextBoxValue));//9
            p_dtbRecordTable.Columns.Add("CONTRACTIONS", typeof(clsDSTRichTextBoxValue));//10
            p_dtbRecordTable.Columns.Add("BLEEDING", typeof(clsDSTRichTextBoxValue));//12
            p_dtbRecordTable.Columns.Add("BROKENWATER", typeof(clsDSTRichTextBoxValue));//13
            p_dtbRecordTable.Columns.Add("FETAL", typeof(clsDSTRichTextBoxValue));//14
            p_dtbRecordTable.Columns.Add("MIYAGUCHISIZE", typeof(clsDSTRichTextBoxValue));//15
            DataColumn dc3 = p_dtbRecordTable.Columns.Add("ExecuseSign");//17
            dc3.DefaultValue = "";
            //存放记录创建者ID
            p_dtbRecordTable.Columns.Add("CreateUserID");//21

            //m_dtcContent.m_RtbBase.m_BlnReadOnly = true;
            m_mthSetControl(clmRecordDateofDay);
            m_mthSetControl(clmCreateTime);
            m_mthSetControl(m_dtcBLOODPRESSURE);
            m_mthSetControl(m_dtcTEMPERATURE);
            m_mthSetControl(m_dtcPULSE);
            m_mthSetControl(m_dtcCONTRACTIONS);
            m_mthSetControl(m_dtcBLEEDING);
            m_mthSetControl(m_dtcBROKENWATER);
            m_mthSetControl(m_dtcFETAL);
            m_mthSetControl(m_dtcMIYAGUCHISIZE);
            m_mthSetControl(clmExecuteSign);
            //设置文字栏
            this.clmRecordDateofDay.HeaderText = "\r\n   日期";
            this.clmCreateTime.HeaderText = "\r\n  时间";
            this.m_dtcBLOODPRESSURE.HeaderText = "   血\r\n\r\n   压";
            this.m_dtcTEMPERATURE.HeaderText = "   体\r\n\r\n   温";
            this.m_dtcPULSE.HeaderText = "   脉\r\n\r\n   搏";
            this.m_dtcCONTRACTIONS.HeaderText = "   宫\r\n\r\n   缩";
            this.m_dtcBLEEDING.HeaderText = "   出\r\n\r\n   血";
            this.m_dtcBROKENWATER.HeaderText = "   破\r\n\r\n   水";
            this.m_dtcFETAL.HeaderText = "   胎\r\n\r\n   心";
            this.m_dtcMIYAGUCHISIZE.HeaderText = " 宫口\r\n\r\n 大小";
            this.clmExecuteSign.HeaderText = "    签\r\n\r\n    名";
        }
        #endregion

        #region 清空
        //设置初始的比较日期
        private DateTime m_dtmPreRecordDate;
        protected override void m_mthClearRecordInfo()
        {
            m_dtbRecords.Rows.Clear();
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            m_dtpCreateDate.Value = DateTime.Now;
            m_cboSurgeryTime.Text = "";
            m_cboPrepareTime.Text = "";
            m_chkBirthMedicine.Checked = false;
            m_chkBirthWater.Checked = false;
            m_cboMedicineName.Text = "";
            m_cboMedicineWeight.Text = "";
            m_cboDiluentMount.Text = "";
            m_cboMedicineNumber.Text = "";
            m_cboFbccbw.Text = "";
            m_cboAbdomenNumber.Text = "";
            m_cboAbdomenTime.Text = "";
            m_cboAbdomenWater.Text = "";
            m_cboAbdomenColor.Text = "";
            m_cboAbdomenOther.Text = "";
            m_cboWaterBursa.Text = "";
            m_cboWaterBursaLength.Text = "";
            m_cboWaterBursaMedia.Text = "";
            m_cboWaterBursaPaper.Text = "";
            m_cboWaterBursaTime.Text = "";
            m_cboWaterBursaCondition.Text = "";
            m_rdbSurgeryFluency.Checked = false;
            m_rdbSurgeryHard.Checked = false;
            m_rdbSurgeryDifficult.Checked = false;
            m_cboBloodMount.Text = "";
            m_txtRemark.Text = "";
            m_cboEmbryoShrinkTime.Text = "";
            m_cboEmbryoWaterTime.Text = "";
            m_cboEmbryoOutTime.Text = "";
            m_rdbEmbryoOutNature.Checked = false;
            m_rdbEmbryoOutMenMake.Checked = false;
            m_rdbEmbryoNew.Checked = false;
            m_rdbEmbryoSofe.Checked = false;
            m_rdbEmbryoDead.Checked = false;
            m_rdbEmbryoOther.Checked = false;
            length.Text = "";
            weight.Text = "";
            m_rdbEmbryoComplete.Checked = false;
            m_rdbEmbryoDisComplete.Checked = false;
            m_rdbEmbryoClearNo.Checked = false;
            m_rdbEmbryoClearYes.Checked = false;
            m_cboEmbryoReason.Text = "";
            m_txtAfterBlood.Text = "";
            m_cboAfterMedia.Text = "";
            m_cboAfterMount.Text = "";
            m_radCHRCDYES.Checked = false;
            m_radCHRCDNO.Checked = false;
            m_txtBedNO.Focus();
        }
        #endregion 

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
        
        #region 上载
        private void frmGestationMisbirthsthree_Load(object sender, EventArgs e)
        {
        m_mthInitDataTable(m_dtbRecords);
            m_dtgRecord.DataSource = m_dtbRecords;
            m_mthSetAllDataGridTextBoxColum();
        }
        #endregion

        #region 获取当前病人的作废内容
        /// <summary>
        /// 获取当前病人的作废内容
        /// </summary>
        /// <param name="p_dtmRecordDate">记录日期</param>
        /// <param name="p_intFormID">窗体ID</param>
        protected override void m_mthGetDeactiveContent(DateTime p_dtmRecordDate, int p_intFormID)
        {
            clsGestationMisbirthsthreeRelationVO objContent = new clsGestationMisbirthsthreeRelationVO();
            if (m_objBaseCurrentPatient == null || m_objBaseCurrentPatient.m_StrInPatientID == null || m_objBaseCurrentPatient.m_DtmSelectedInDate == DateTime.MinValue)
            {
                return;
            }

            long lngRes = m_objDomain.m_lngGetDeleteRecordContent(m_objBaseCurrentPatient.m_StrInPatientID, m_objBaseCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"), p_dtmRecordDate.ToString("yyyy-MM-dd HH:mm:ss"), out objContent);
            if (lngRes <= 0 || objContent == null)
            {
                switch (lngRes)
                {
                    case (long)(iCareData.enmOperationResult.Not_permission):
                        m_mthShowNotPermitted(); break;
                    case (long)(iCareData.enmOperationResult.DB_Fail):
                        m_mthShowDBError(); break;
                }
                return;
            }
            m_txtBedNO.Focus();
        }
        #endregion

        #region m_mthSetSelectedRecord
        protected new void m_mthSetSelectedRecord(clsPatient p_objPatient,
            string p_strRecordTime)
        {
            //检查参数
            if (p_objPatient == null || m_ObjCurrentEmrPatientSession == null)
            {
                m_objCurrentRecordContent = null;
                return;
            }
            clsBaseCaseHistoryInfo objContent = null;
            clsPictureBoxValue[] objPicValueArr = null;
            //获取记录
            long lngRes = m_objDomain.m_lngGetRecordContent(p_objPatient.m_StrInPatientID, m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"),/*p_strRecordTime ,*/ out objContent, out objPicValueArr);
            if (lngRes <= 0 || objContent == null)
            {
                m_objCurrentRecordContent = null;
                return;
            }
            //设置记录时间     
            m_objCurrentRecordContent = (clsGestationMisbirthsthreeRelationVO)objContent;
            m_mthSetGUIFromContent((clsGestationMisbirthsthreeRelationVO)objContent);
            m_mthEnableModify(false);
            m_mthSetModifyControl((clsGestationMisbirthsthreeRelationVO)objContent, false);
        }
        // 把选择时间记录内容重新整理为完全正确的内容。
        protected override void m_mthReAddNewRecord(clsInPatientCaseHistoryContent p_objRecordContent)
        {

        }
        #endregion

        #region 设置是否控制修改（修改留痕迹）
        /// <summary>
        /// 设置是否控制修改（修改留痕迹）。
        /// </summary>
        /// <param name="p_objRecordContent"></param>
        /// <param name="p_blnReset"></param>
        protected void m_mthSetModifyControl(clsGestationMisbirthsthreeRelationVO p_objRecordContent,
            bool p_blnReset)
        {
            //根据书写规范设置具体窗体的书写控制，由子窗体重载实现
            if (p_blnReset == true)
            {
                m_mthSetRichTextModifyColor(this, clsHRPColor.s_ClrInputFore);
                m_mthSetRichTextCanModifyLast(this, true);
            }
            else if (p_objRecordContent != null)
            {
                m_mthSetRichTextModifyColor(this, Color.Red);
                m_mthSetRichTextCanModifyLast(this, m_blnGetCanModifyLast(p_objRecordContent.m_strModifyUserID));
            }

        }
        /// <summary>
        /// 设置窗体中控件输入文本的颜色
        /// </summary>
        /// <param name="p_ctlControl"></param>
        /// <param name="p_clrColor"></param>
        private void m_mthSetRichTextModifyColor(Control p_ctlControl, System.Drawing.Color p_clrColor)
        {
            #region 设置控件输入文本的颜色,Jacky-2003-3-24
            string strTypeName = p_ctlControl.GetType().FullName;
            if (strTypeName == "com.digitalwave.Utility.Controls.ctlRichTextBox")
                ((com.digitalwave.Utility.Controls.ctlRichTextBox)p_ctlControl).m_ClrOldPartInsertText = p_clrColor;
            else if (strTypeName == "com.digitalwave.controls.ctlRichTextBox")
                ((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_ClrOldPartInsertText = p_clrColor;

            if (p_ctlControl.HasChildren && strTypeName != "System.Windows.Forms.DataGrid")
            {
                foreach (Control subcontrol in p_ctlControl.Controls)
                {
                    m_mthSetRichTextModifyColor(subcontrol, p_clrColor);
                }
            }
            #endregion
        }

        private void m_mthSetRichTextCanModifyLast(Control p_ctlControl, bool p_blnCanModifyLast)
        {
            #region 设置控件输入文本的是否最后修改,Jacky-2003-3-24
            string strTypeName = p_ctlControl.GetType().FullName;
            if (strTypeName == "com.digitalwave.Utility.Controls.ctlRichTextBox")
            {
                ((com.digitalwave.Utility.Controls.ctlRichTextBox)p_ctlControl).m_BlnCanModifyLast = p_blnCanModifyLast;
            }
            else if (strTypeName == "com.digitalwave.controls.ctlRichTextBox")
            {
                ((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_BlnCanModifyLast = p_blnCanModifyLast;
            }

            if (p_ctlControl.HasChildren && strTypeName != "System.Windows.Forms.DataGrid")
            {
                foreach (Control subcontrol in p_ctlControl.Controls)
                {
                    m_mthSetRichTextCanModifyLast(subcontrol, p_blnCanModifyLast);
                }
            }
            #endregion
        }	
        #endregion

        #region trvTime_AfterSelect
        protected override void trvTime_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            if (!m_blnCanTreeAfterSelect)
                return;
            m_mthRecordChangedToSave();
            try
            {
                DateTime dtInDate = DateTime.Parse(trvTime.SelectedNode.Text);
                m_mthClearRecordInfo();
                txtInPatientID.Text = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(trvTime.Nodes[0].Nodes.Count - trvTime.SelectedNode.Index - 1).m_StrHISInPatientID;
                DateTime dtmEMRInDate = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(trvTime.Nodes[0].Nodes.Count - trvTime.SelectedNode.Index - 1).m_DtmEMRInDate;
                string strEMRInPatientID = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(trvTime.Nodes[0].Nodes.Count - trvTime.SelectedNode.Index - 1).m_StrEMRInPatientID;
                m_objCurrentPatient.m_StrHISInPatientID = txtInPatientID.Text;
                m_objCurrentPatient.m_DtmSelectedHISInDate = Convert.ToDateTime(trvTime.SelectedNode.Text);
                m_objCurrentPatient.m_DtmSelectedInDate = dtmEMRInDate;
                m_objBaseCurrentPatient.m_DtmSelectedInDate = dtmEMRInDate;
                if (string.IsNullOrEmpty(m_objBaseCurrentPatient.m_StrRegisterId))
                {
                    string strRegisterID = string.Empty;
                    long lngRes = new clsPublicDomain().m_lngGetRegisterID(m_objCurrentPatient.m_StrPatientID, Convert.ToDateTime(trvTime.SelectedNode.Text).ToString("yyyy-MM-dd HH:mm:ss"), out strRegisterID);
                    m_objBaseCurrentPatient.m_StrRegisterId = strRegisterID;
                    m_objCurrentPatient.m_StrRegisterId = strRegisterID;
                }
                m_mthIsReadOnly();
                if (!m_blnCanShowRecordContent())
                {
                    clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                    return;
                }
                m_mthEnableRichTextBox();
                //m_dtpInHospitalDate.Value = dtInDate;
                m_mthSetSelectedRecord(m_objCurrentPatient, (string)this.trvTime.SelectedNode.Tag);
                if (m_objCurrentRecordContent != null)
                {
                    this.m_dtpCreateDate.Enabled = true;
                    //当前处于修改记录状态
                    MDIParent.m_mthChangeFormText(this, MDIParent.enmFormEditStatus.Modify);
                }
                else
                {
                    m_mthSetNewRecord();
                    //当前处于新增记录状态
                    MDIParent.m_mthChangeFormText(this, MDIParent.enmFormEditStatus.AddNew);
                }
            }
            catch (Exception exp)
            {
                string strtemp = exp.Message;
                m_mthClearRecordInfo();
                m_mthUnEnableRichTextBox();
                m_objCurrentRecordContent = null;
                m_mthEnableModify(true);
                this.m_dtpCreateDate.Enabled = true;
                this.m_dtpCreateDate.Text = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");
                m_mthSetNullPrintContext();
                //当前处于禁止输入状态
                MDIParent.m_mthChangeFormText(this, MDIParent.enmFormEditStatus.None);
            }
            finally
            {
                m_mthDoAfterSelect();
                m_mthAddFormStatusForClosingSave();
            }
        }
        #endregion

        #region 选择树节点后的操作
        // 控制是否可以选择病人和记录时间列表。在从病程记录窗体调用时需要使用。
        protected override void m_mthEnablePatientSelectSub(bool p_blnEnable)
        {

        }
        // 获取选择已经删除记录的窗体标题
        public override void m_strReloadFormTitle()
        {

        }
        /// <summary>
        /// 选择树节点后的操作
        /// </summary>
        protected override void m_mthDoAfterSelect()
        {
            object[][] objDataArr;
            clsGestationMisbirthsthreeVO[] objCircsRecordArr;
            DateTime dtSelectedInPatientDate = DateTime.MinValue;
            if (m_ObjCurrentEmrPatientSession != null)
            {
                dtSelectedInPatientDate = m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate;
            }
            else
            {
                m_dtbRecords.Clear();
                return;
            }
            long lngRes = m_objDomain.m_lngGetAllCircsRecordContent(m_objCurrentPatient.m_StrInPatientID, dtSelectedInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), m_dtpCreateDate.Text, out objCircsRecordArr);
            objDataArr = m_objGetRecordsValueArr(objCircsRecordArr);
            m_dtbRecords.Clear();
            if (objDataArr == null)
                return;
            for (int j2 = 0; j2 < objDataArr.Length; j2++)
            {
                m_dtbRecords.Rows.Add(objDataArr[j2]);
            }
        }
        #endregion

        #region 获取添加记录的窗体
        private frmGestationMisbirthsthree_Con m_frmCurrentSub = null;
        private void m_mthSubFormClosed(object p_objSender, EventArgs p_objArg)
        {
            frmGestationMisbirthsthree_Con frmAddNewForm = (frmGestationMisbirthsthree_Con)p_objSender;

            m_blnCanShowNewForm = true;
            m_frmCurrentSub = null;
        }
        protected void m_mthShowSubForm(Form p_frmSubForm)
        {
            p_frmSubForm.Closed += new EventHandler(m_mthSubFormClosed);
            m_blnCanShowNewForm = false;
            m_frmCurrentSub = (frmGestationMisbirthsthree_Con)p_frmSubForm;

            p_frmSubForm.TopMost = true;
            p_frmSubForm.Show();
        }
        protected void m_mthModifyRecord(DateTime p_dtmOpenRecordTime)
        {
            if (!m_blnCanShowNewForm)
                return;
            
            DateTime dtSelectedInPatientDate = DateTime.MinValue;
        
            if (m_ObjCurrentEmrPatientSession != null)
            {
                dtSelectedInPatientDate = m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate;
            }
            else
            {
                m_dtbRecords.Clear();
            }
            //获取添加记录的窗体
            string strOpenDate = p_dtmOpenRecordTime.ToString("yyyy-MM-dd HH:mm:ss");
            frmGestationMisbirthsthree_Con frmAddNewForm = new frmGestationMisbirthsthree_Con(false, m_objCurrentPatient.m_StrInPatientID, dtSelectedInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), m_dtpCreateDate.Text, ref strOpenDate);

            m_mthShowSubForm(frmAddNewForm);

            MDIParent.s_ObjSaveCue.m_mthAddFormStatus(frmAddNewForm);
        }
        
        #endregion

        #region 清空记录内容
        protected override long m_lngSubDelete()
        {
            //检查当前病人变量是否为null  
            if (m_objCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
            {
                clsPublicFunction.ShowInformationMessageBox("未选定病人,无法删除!");//崔汉瑜，2003-5-27
                return (long)enmOperationResult.Parameter_Error;
            }
            //检查当前记录是否为null
            if (m_objCurrentRecordContent == null)
            {
                clsPublicFunction.ShowInformationMessageBox("当前记录内容为空,无法删除!");//崔汉瑜，2003-5-27
                return (long)enmOperationResult.Parameter_Error;
            }
            //获取服务器时间      
            clsPublicDomain m_objPDomain = new clsPublicDomain();

            //删除记录
            clsGestationMisbirthsthreeRelationVO objContent = m_objGetContentFromGUI();
            objContent.m_bytStatus = 0;
            objContent.m_dtmCreateDate = m_objCurrentRecordContent.m_dtmCreateDate;
            objContent.m_dtmInPatientDate = m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate;
            objContent.m_strInPatientID = m_objCurrentPatient.m_StrInPatientID;
            objContent.m_strDeActivedOperatorID = MDIParent.OperatorID;
            objContent.m_dtmOpenDate = m_objCurrentRecordContent.m_dtmOpenDate;

            //设置 m_objCurrentRecordContent 的信息（使用服务器时间设置m_dtmDeActivedDate）
            objContent.m_dtmDeActivedDate = DateTime.Parse(m_objPDomain.m_strGetServerTime());

            clsPreModifyInfo m_objModifyInfo = null;

            long lngRes = m_objDomain.m_lngDeleteRecord(objContent, out m_objModifyInfo);

            //根据结果做不同的处理
            switch ((enmOperationResult)lngRes)
            {
                case enmOperationResult.DB_Succeed:
                    //清空记录信息   

                    m_objCurrentRecordContent = null;
                    m_mthClearPatientRecordInfo();
                    //选中根节点
                    m_blnCanTreeAfterSelect = false;
                    m_mthUnEnableRichTextBox();
                    m_blnCanTreeAfterSelect = true;

                    m_mthPerformSessionChanged(m_ObjCurrentEmrPatientSession, 0);
                    break;
                //...
            }

            //返回结果
            return lngRes;
        }
        #endregion

        #region 右键单击
        private void ctmRecordControl_Popup(object sender, System.EventArgs e)
        {
            bool blnEnable = true;
            m_mniAddBabyCircsRecord.Enabled = blnEnable;
            m_mmiModifyBabyCircsRecord.Enabled = blnEnable;
            m_mmiDelBabyCircsRecord.Enabled = blnEnable;
        }
        private void m_mniAddBabyCircsRecord_Click(object sender, System.EventArgs e)
        {
            DateTime dtSelectedInPatientDate = DateTime.MinValue;
            if (m_ObjCurrentEmrPatientSession != null)
            {
                dtSelectedInPatientDate = m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate;
            }
            else
            {
                m_dtbRecords.Clear();
                return;
            }
            if (m_objCurrentPatient == null)
                return;
            string strOpenDate = "";
            frmGestationMisbirthsthree_Con frm = new frmGestationMisbirthsthree_Con(true, m_objCurrentPatient.m_StrInPatientID, dtSelectedInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), m_dtpCreateDate.Text, ref strOpenDate);
            frm.StartPosition = FormStartPosition.CenterParent;
            if (frm.ShowDialog() == DialogResult.Yes)
            {
                clsGestationMisbirthsthreeVO[] objCircsRecordArr;
                long lngRes = m_objDomain.m_lngGetAllCircsRecordContent(m_objCurrentPatient.m_StrInPatientID, dtSelectedInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), m_dtpCreateDate.Text, out objCircsRecordArr);
                //设置内容到DataTable
                object[][] objDataArr = m_objGetRecordsValueArr(objCircsRecordArr);
                //添加内容到DataTable
                if (strOpenDate == "")
                    strOpenDate = "1900-01-01 00:00:00";
                m_mthAddDataToDataTable(objDataArr, DateTime.Parse(strOpenDate));
            }
        }

        /// <summary>
        /// 添加数据到DataTable
        /// </summary>
        /// <param name="p_objDataArr"></param>
        /// <param name="p_dtmCreateRecordTime"></param>
        protected void m_mthAddDataToDataTable(object[][] p_objDataArr,
            DateTime p_dtmCreateRecordTime)
        {
            //查找插入点
            //循环DataTable的记录，获取记录的日期（第一字段）
            //如果有记录日期
            //比较已有日期与p_dtmCreateDate
            //如果已有日期比p_dtmCreateDate大
            //在这行记录前添加记录（数组），返回
            //没有找到比p_dtmCreateDate大的日期，往DataTable后添加	
            if (p_objDataArr == null)
                return;
            m_dtbRecords.Clear();
            int m_intInsertIndex = -1;
            string m_strRecordTime = null;
            DataRow m_dtrNewRow;
            for (int i1 = 0; i1 < m_dtbRecords.Rows.Count; i1++)
            {
                if (m_dtbRecords.Rows[i1][0].ToString() != "")
                {
                    m_strRecordTime = m_dtbRecords.Rows[i1][0].ToString();
                    if (DateTime.Parse(m_strRecordTime) > p_dtmCreateRecordTime)
                    {
                        m_intInsertIndex = i1;
                        break;
                    }
                }
            }
            if (m_intInsertIndex < 0)//没有找到比p_dtmOpenRecordTime大的日期，往DataTable后添加		
            {
                for (int i1 = 0; i1 < p_objDataArr.Length; i1++)
                {
                    m_dtbRecords.Rows.Add(p_objDataArr[i1]);
                }
            }
            else//否则，将p_dtmCreateDate 之后的记录放到内存中,先添加新增的记录，然后把内存中的记录，再添加回去
            {
                if (m_dtbTempTable == null)
                {
                    m_dtbTempTable = m_dtbRecords.Clone();
                }
                while ((m_intInsertIndex < m_dtbRecords.Rows.Count))//将p_dtmCreateDate 之后的记录放到内存中
                {
                    m_mthSetDataGridFirstRowFocus();
                    m_dtrNewRow = m_dtbTempTable.NewRow();
                    m_dtrNewRow.ItemArray = m_dtbRecords.Rows[m_intInsertIndex].ItemArray;
                    m_dtbTempTable.Rows.Add(m_dtrNewRow);
                    m_dtbRecords.Rows.RemoveAt(m_intInsertIndex);
                }
                for (int i1 = 0; i1 < p_objDataArr.Length; i1++)//新增的记录
                {
                    m_dtrNewRow = m_dtbRecords.NewRow();
                    m_dtrNewRow.ItemArray = p_objDataArr[i1];
                    m_dtbRecords.Rows.Add(m_dtrNewRow);
                }
                for (int i1 = 0; i1 < m_dtbTempTable.Rows.Count; i1++)//把内存中的记录，再添加回去
                {
                    m_dtrNewRow = m_dtbRecords.NewRow();
                    m_dtrNewRow.ItemArray = m_dtbTempTable.Rows[i1].ItemArray;
                    m_dtbRecords.Rows.Add(m_dtrNewRow);
                }
                if (m_dtbTempTable != null)
                {
                    m_dtbTempTable.Rows.Clear();
                }
            }
        }
        /// <summary>
        /// 使得DataGrid的第一行获得焦点
        /// </summary>
        protected void m_mthSetDataGridFirstRowFocus()
        {
            m_dtgRecord.CurrentCell = new DataGridCell(m_dtbRecords.Rows.Count, m_dtgRecord.CurrentCell.ColumnNumber);
        }
        private void m_mmiDelBabyCircsRecord_Click(object sender, System.EventArgs e)
        {
            DateTime dtSelectedInPatientDate = DateTime.MinValue;
            DateTime dtOpen = DateTime.MinValue;
            DateTime dtModify = DateTime.MinValue;
            if (m_ObjCurrentEmrPatientSession != null)
            {
                dtSelectedInPatientDate = m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate;
            }
            else
            {
                m_dtbRecords.Clear();
                return;
            }
            try
            {
                dtOpen = Convert.ToDateTime(m_dtbRecords.Rows[m_dtgRecord.CurrentRowIndex][1]);
                dtModify = Convert.ToDateTime(m_dtbRecords.Rows[m_dtgRecord.CurrentRowIndex][2]);
            }
            catch
            {
                MDIParent.ShowInformationMessageBox("请先选择一条记录");
                return;
            }
            //传递参数
            int intSelectedRecordStartRow = m_dtgRecord.CurrentCell.RowNumber;
            //确认
            if (MessageBox.Show("确认要删除选中的病情记录内容？", "删除提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                return;
            //打开窗体
            //删除
            clsGestationMisbirthsthreeVO objDelRecord = new clsGestationMisbirthsthreeVO();
            objDelRecord.m_dtmInPatientDate = m_objCurrentPatient.m_DtmSelectedInDate;
            objDelRecord.m_dtmOpenDate = dtOpen;
            objDelRecord.m_strRegisterID = m_ObjCurrentEmrPatientSession.m_strRegisterId;
            objDelRecord.m_strInPatientID = m_objCurrentPatient.m_StrInPatientID;
            objDelRecord.m_strDeActivedOperatorID = MDIParent.OperatorID;
            objDelRecord.m_dtmDeActivedDate = DateTime.Now;
            objDelRecord.m_dtmModifyDate = dtModify;

            long lngRes = m_objDomain.m_lngDeleteCircsRecord(objDelRecord);
            //更新
            if (lngRes > 0)
            {
                clsGestationMisbirthsthreeVO[] objCircsRecordArr;
                lngRes = m_objDomain.m_lngGetAllCircsRecordContent(m_objCurrentPatient.m_StrInPatientID, dtSelectedInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), m_dtpCreateDate.Text, out objCircsRecordArr);

                //设置内容到DataTable
                object[][] objDataArr = m_objGetRecordsValueArr(objCircsRecordArr);

                //添加内容到DataTable
                m_dtbRecords.Clear();
                m_mthAddDataToDataTable(objDataArr, DateTime.Parse("1900-01-01 00:00:00"));
            }
        }

        private void m_mmiModifyBabyCircsRecord_Click(object sender, System.EventArgs e)
        {
            DateTime dtSelectedInPatientDate = DateTime.MinValue;
            if (m_ObjCurrentEmrPatientSession != null)
            {
                dtSelectedInPatientDate = m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate;
            }
            else
            {
                m_dtbRecords.Clear();
                return;
            }
            if (m_objCurrentPatient == null)
                return;
            DateTime dtOpen = DateTime.MinValue;
            DateTime dtModify = DateTime.MinValue;
            try
            {
                dtOpen = Convert.ToDateTime(m_dtbRecords.Rows[m_dtgRecord.CurrentRowIndex][1]);
                dtModify = Convert.ToDateTime(m_dtbRecords.Rows[m_dtgRecord.CurrentRowIndex][2]);
            }
            catch
            {
                MDIParent.ShowInformationMessageBox("请先选择一条记录");
                return;
            }
            //dtSelectedInPatientDate = m_objCurrentPatient.m_DtmSelectedInDate;
            string strOpenDate = m_dtbRecords.Rows[m_dtgRecord.CurrentRowIndex][1].ToString(); ;
            frmGestationMisbirthsthree_Con frm = new frmGestationMisbirthsthree_Con(false, m_objCurrentPatient.m_StrInPatientID, dtSelectedInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), m_dtpCreateDate.Text, ref strOpenDate);
            frm.StartPosition = FormStartPosition.CenterParent;
            if (frm.ShowDialog() == DialogResult.Yes)
            {
                clsGestationMisbirthsthreeVO[] objCircsRecordArr;
                long lngRes = m_objDomain.m_lngGetAllCircsRecordContent(m_objCurrentPatient.m_StrInPatientID, dtSelectedInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), m_dtpCreateDate.Text, out objCircsRecordArr);

                //设置内容到DataTable
                object[][] objDataArr = m_objGetRecordsValueArr(objCircsRecordArr);

                //添加内容到DataTable
                m_mthAddDataToDataTable(objDataArr, DateTime.Parse("1900-01-01 00:00:00"));

                //TreeNode trvTemp=trvTime.SelectedNode;
                //trvTime.SelectedNode=null;
                //trvTime.SelectedNode=trvTemp;
            }
            m_mthSetDataGridFirstRowFocus();
        }
        #endregion

        #region 显示记录到DataGrid
        private DataTable m_dtbTempTable;
        private object[][] m_objGetRecordsValueArr(clsGestationMisbirthsthreeVO[] p_objTransDataInfo)
        {
            #region 显示记录到DataGrid
            try
            {
                object[] objData;
                ArrayList objReturnData = new ArrayList();
                m_dtmPreRecordDate = DateTime.MinValue;

                com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue objclsDSTRichTextBoxValue;
                string strText, strXml;

                if (p_objTransDataInfo == null)
                    return null;

                int intRecordCount = p_objTransDataInfo.Length;

                for (int i = 0; i < intRecordCount; i++)
                {
                    clsGestationMisbirthsthreeVO objCurrent = p_objTransDataInfo[i];
                    clsGestationMisbirthsthreeVO objNext = new clsGestationMisbirthsthreeVO();//下一条记录
                    if (i < intRecordCount - 1)
                        objNext = p_objTransDataInfo[i + 1];
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate)
                    {
                        continue;
                    }

                    #region 存放关键字段
                    objData = new object[14];
                    if (objCurrent.m_dtmCreateDate != DateTime.MinValue)
                    {
                        objData[0] = objCurrent.m_dtmCreateDate;//存放记录时间的字符串
                        objData[1] = objCurrent.m_dtmOpenDate;//存放记录的OpenDate字符串
                        objData[2] = objCurrent.m_dtmModifyDate;//存放记录的ModifyDate字符串   
                       
                        if (objCurrent.m_dtmRecordDate.ToString("yyyy-MM-dd") != m_dtmPreRecordDate.ToString("yyyy-MM-dd"))
                        {
                            objData[3] = objCurrent.m_dtmRecordDate.ToString("yyyy-MM-dd");//日期字符串
                            
                        }
                        objData[4] = objCurrent.m_dtmRecordDate.ToString("HH:mm");
                    }
                    m_dtmPreRecordDate = objCurrent.m_dtmRecordDate;
                    #endregion ;

                    #region 存放单项信息
                    
                    //血压
                    strText = objCurrent.m_strBLOODPRESSURE_VCHR;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strBLOODPRESSURE_VCHR != objCurrent.m_strBLOODPRESSURE_VCHR)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strBLOODPRESSURE_VCHR, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[5] = objclsDSTRichTextBoxValue;

                    //体温
                    strText = objCurrent.m_strTEMPERATURE_VCHR;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strTEMPERATURE_VCHR != objCurrent.m_strTEMPERATURE_VCHR)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strTEMPERATURE_VCHR, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[6] = objclsDSTRichTextBoxValue;

                    //脉搏
                    strText = objCurrent.m_strPULSE_VCHR;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strPULSE_VCHR != objCurrent.m_strPULSE_VCHR)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strPULSE_VCHR, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[7] = objclsDSTRichTextBoxValue;

                    //宫缩
                    strText = objCurrent.m_strCONTRACTIONS_VCHR;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strCONTRACTIONS_VCHR != objCurrent.m_strCONTRACTIONS_VCHR)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strCONTRACTIONS_VCHR, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[8] = objclsDSTRichTextBoxValue;

                    //出血
                    strText = objCurrent.m_strBLEEDING_VCHR;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strBLEEDING_VCHR != objCurrent.m_strBLEEDING_VCHR)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strBLEEDING_VCHR, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[9] = objclsDSTRichTextBoxValue;

                    //破水
                    strText = objCurrent.m_strBROKENWATER_VCHR;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strBROKENWATER_VCHR != objCurrent.m_strBROKENWATER_VCHR)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strBROKENWATER_VCHR, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[10] = objclsDSTRichTextBoxValue;

                    //胎心
                    strText = objCurrent.m_strFETAL_VCHR;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strFETAL_VCHR != objCurrent.m_strFETAL_VCHR)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strFETAL_VCHR, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[11] = objclsDSTRichTextBoxValue;

                    //宫口大小
                    strText = objCurrent.m_strMIYAGUCHISIZE_VCHR;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strMIYAGUCHISIZE_VCHR != objCurrent.m_strMIYAGUCHISIZE_VCHR)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strMIYAGUCHISIZE_VCHR, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[12] = objclsDSTRichTextBoxValue;

                    //签名	
                    objData[13] = objCurrent.m_strSignUserName;

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
        #endregion

        #region datagrid事件
        /// <summary>
        /// 双击DataGrid内的控件触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cltDataGridDSTRichTextBox_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (!m_blnCheckDataGridCurrentRow())
                return;
            try
            {
                if (e.Clicks > 1)
                {
                    int intSelectedRecordStartRow = m_intGetRecordStartRow(m_dtgRecord.CurrentCell.RowNumber);
                    if (intSelectedRecordStartRow < 0)
                        return;
                    string strOpenDate = m_dtbRecords.Rows[intSelectedRecordStartRow][1].ToString();
                    //m_mthModifyRecord(DateTime.Parse(strOpenDate));
                    DateTime dtSelectedInPatientDate = DateTime.MinValue;
                    if (m_ObjCurrentEmrPatientSession != null)
                    {
                        dtSelectedInPatientDate = m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate;
                    }
                    else
                    {
                        m_dtbRecords.Clear();
                        return;
                    }
                    frmGestationMisbirthsthree_Con frm = new frmGestationMisbirthsthree_Con(false, m_objCurrentPatient.m_StrInPatientID, dtSelectedInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), m_dtpCreateDate.Text, ref strOpenDate);
                    frm.StartPosition = FormStartPosition.CenterParent;
                    if (frm.ShowDialog() == DialogResult.Yes)
                    {
                        clsGestationMisbirthsthreeVO[] objCircsRecordArr;
                        long lngRes = m_objDomain.m_lngGetAllCircsRecordContent(m_objCurrentPatient.m_StrInPatientID, dtSelectedInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), m_dtpCreateDate.Text, out objCircsRecordArr);

                        //设置内容到DataTable
                        object[][] objDataArr = m_objGetRecordsValueArr(objCircsRecordArr);

                        //添加内容到DataTable
                        m_mthAddDataToDataTable(objDataArr, DateTime.Parse("1900-01-01 00:00:00"));
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 处理之前判断DataGrid与DataTable的关系
        /// </summary>
        /// <returns></returns>
        protected virtual bool m_blnCheckDataGridCurrentRow()
        {
            try
            {
                if (m_dtbRecords.Rows.Count <= 0)
                    return false;
                if (m_dtgRecord.CurrentCell.RowNumber >= m_dtbRecords.Rows.Count)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }

        }
        /// <summary>
        ///  获取用户选择的记录的开始行位置
        /// </summary>
        /// <param name="p_intSelectRowIndex">返回索引</param>
        /// <returns></returns>
        protected virtual int m_intGetRecordStartRow(int p_intSelectRowIndex)
        {
            //以p_intSelectRow开始，从后往前循环DataTable
            //如果当前记录的第一个字段不为空
            //返回索引
            for (int i1 = p_intSelectRowIndex; i1 >= 0; i1--)
            {
                if (m_dtbRecords.Rows[i1][1].ToString() != "")
                {
                    return i1;
                }
            }

            return -1;
        }
        /// <summary>
        /// 双击DataGrid内的控件触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_mthTxtDoubleClick(object sender, EventArgs e)
        {
            if (!m_blnCheckDataGridCurrentRow())
                return;
            try
            {
                int intSelectedRecordStartRow = m_intGetRecordStartRow(m_dtgRecord.CurrentCell.RowNumber);
                if (intSelectedRecordStartRow < 0)
                    return;
                string strOpenDate = m_dtbRecords.Rows[intSelectedRecordStartRow][1].ToString();
                m_mthModifyRecord(DateTime.Parse(strOpenDate));
            }
            catch (Exception exp)
            {
                string strErrorMessage = exp.Message;
            }
        }
        /// <summary>
        /// 设置DataGrid内的控件触发的事件和右键菜单
        /// </summary>
        /// <param name="p_objControl"></param>
        private void m_mthSetControl(DataGridTextBoxColumn p_objControl)
        {
            Control m_objControl;
            m_objControl = (DataGridTextBox)p_objControl.TextBox;
            m_objControl.ContextMenu = m_ctmRecordControl;
            m_objControl.DoubleClick += new EventHandler(m_mthTxtDoubleClick);
        }
        /// <summary>
        /// 设置DataGrid内的控件触发的事件和右键菜单
        /// </summary>
        /// <param name="p_objControl"></param>
        private void m_mthSetControl(com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox p_objControl)
        {
            p_objControl.m_RtbBase.ContextMenu = m_ctmRecordControl;
            p_objControl.m_RtbBase.MouseDown += new MouseEventHandler(cltDataGridDSTRichTextBox_MouseDown);
        }
        private void m_mthSetAllDataGridTextBoxColum()
        {
            m_mthSetControl(clmRecordDateofDay);
            m_mthSetControl(clmCreateTime);
            m_mthSetControl(m_dtcBLOODPRESSURE);
            m_mthSetControl(m_dtcTEMPERATURE);
            m_mthSetControl(m_dtcPULSE);
            m_mthSetControl(m_dtcCONTRACTIONS);
            m_mthSetControl(m_dtcBLEEDING);
            m_mthSetControl(m_dtcBROKENWATER);
            m_mthSetControl(m_dtcFETAL);
            m_mthSetControl(m_dtcMIYAGUCHISIZE);
            m_mthSetControl(clmExecuteSign);
        }
        protected override DialogResult m_dlgHandleSaveBeforePrint()
        {
            return DialogResult.None;
        }
        #endregion

        #region 属性
        protected override enmApproveType m_EnmAppType
        {
            get { return enmApproveType.CaseHistory; }
        }
        protected override string m_StrRecorder_ID
        {
            get
            {
                //if (m_txtCheckDocSign.Tag != null)
                //    return m_txtCheckDocSign.Tag.ToString();
                return "";
            }
        }
        #endregion 属性

        #region m_lngAddNewRecord
        /// <summary>
        /// 添加记录
        /// </summary>
        /// <returns></returns>
        protected override long m_lngSubAddNew()
        {
            if (m_objReAddNewOld != null)
                return m_lngReAddNew();
            else
                return m_lngAddNewRecord();
        }
        protected override void m_mthHandleAddRecordSucceed()
        {
            if (trvTime.SelectedNode != null)
                trvTime.SelectedNode.Tag = (string)m_objCurrentRecordContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss");
        }
        protected new long m_lngAddNewRecord()
        {
            //检查当前病人变量是否为null
            if (m_objCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
                return (long)enmOperationResult.Parameter_Error;
            //if (lsvSign1.Items.Count < 1) 
            //{
            //    MessageBox.Show("请医生签名！");
            //    return 0;
            //}
            //if (lsvSign2.Items.Count < 1)
            //{
            //    MessageBox.Show("请请接生者签名！");
            //    return 0;
            //}
            //获取服务器时间
            clsPublicDomain m_objPDomain = new clsPublicDomain();
            //从界面获取记录信息
            clsGestationMisbirthsthreeRelationVO objContent = m_objGetContentFromGUI();
            //获取画图信息
            clsPictureBoxValue[] objPicValueArr = m_objGetPicContentFromGUI();
            string strDiseaseID = "";
            //界面输入值出错
            if (objContent == null)
                return (long)enmOperationResult.Parameter_Error;
            //设置 clsInPatientCaseHistoryContent 的信息（使用服务器时间设置m_dtmOpenDate和m_dtmModifyDate）
            string strNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            objContent.m_bytIfConfirm = 0;
            objContent.m_bytStatus = 0;
            objContent.m_dtmInPatientDate = m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate;
            objContent.m_dtmModifyDate = DateTime.Parse(strNow);
            objContent.m_dtmOpenDate = DateTime.Parse(strNow);
            objContent.m_strCreateUserID = MDIParent.strOperatorID;
            objContent.m_strInPatientID = m_objCurrentPatient.m_StrInPatientID;
            objContent.m_strModifyUserID = MDIParent.strOperatorID;
            objContent.m_dtmCreateDate = DateTime.Parse(strNow);
            //保存记录
            clsPreModifyInfo p_objModifyInfo = null;
            long lngRes = m_objDomain.m_lngAddNewRecord(objContent, objPicValueArr, strDiseaseID, out p_objModifyInfo);
            //根据结果做不同的处理
            switch ((enmOperationResult)lngRes)
            {
                case enmOperationResult.DB_Succeed:
                    if ((enmOperationResult)lngRes == enmOperationResult.DB_Succeed)
                    {
                        m_objCurrentRecordContent = objContent;
                        m_mthHandleAddRecordSucceed();
                    }
                    break;
                //...
                case enmOperationResult.Record_Already_Exist:
                    m_mthShowRecordTimeDouble();
                    return lngRes;
            }
            this.trvTime.ExpandAll();
            //返回结果
            return lngRes;
        }
        // 是否允许修改特殊记录的记录信息。
        protected override void m_mthEnableModifySub(bool p_blnEnable)
        {

        }
        #endregion

        #region m_lngSubModify
        /// <summary>
        /// 是否是添加新记录的操作。true，添加新记录；false,修改记录
        /// </summary>
        protected override bool m_BlnIsAddNew
        {
            get
            {
                return m_objCurrentRecordContent == null;
            }
        }
        protected override long m_lngSubModify()
        {
            //if (trvTime.Nodes[0].Nodes.Count > 0 && trvTime.SelectedNode != trvTime.Nodes[0].FirstNode)
            //    return 1;//窗体只读。
            //检查当前病人变量是否为null
            if (m_objCurrentPatient == null)
                return (long)enmOperationResult.Parameter_Error;
            //获取服务器时间
            clsPublicDomain m_objPDomain = new clsPublicDomain();
            //从界面获取记录信息
            clsGestationMisbirthsthreeRelationVO objContent = m_objGetContentFromGUI();
            //获取画图信息
            clsPictureBoxValue[] objPicValueArr = m_objGetPicContentFromGUI();
            //获取病名
            string strDiseaseID = "";
            //界面输入值出错           
            if (objContent == null)
                return (long)enmOperationResult.Parameter_Error;
            //设置 clsInPatientCaseHistoryContent 的信息（使用服务器时间设置m_dtmModifyDate）
            objContent.m_bytIfConfirm = 0;
            objContent.m_bytStatus = 0;
            objContent.m_dtmInPatientDate = m_objCurrentPatient.m_DtmSelectedInDate;
            objContent.m_dtmModifyDate = DateTime.Parse(m_objPDomain.m_strGetServerTime());
            objContent.m_dtmCreateDate = m_objCurrentRecordContent.m_dtmCreateDate;
            objContent.m_strCreateUserID = MDIParent.strOperatorID;
            objContent.m_strInPatientID = m_objCurrentPatient.m_StrInPatientID;
            objContent.m_strModifyUserID = MDIParent.strOperatorID;
            //设置已有记录的开始使用时间
            objContent.m_dtmOpenDate = m_objCurrentRecordContent.m_dtmOpenDate;
            clsPreModifyInfo m_objModifyInfo;
            long lngRes = m_objDomain.m_lngModifyRecord(m_objCurrentRecordContent, objContent, objPicValueArr, strDiseaseID, m_ObjCurrentEmrPatientSession.m_strDeptId, out m_objModifyInfo);
            //根据结果做不同的处理
            switch ((enmOperationResult)lngRes)
            {
                case enmOperationResult.DB_Succeed:
                    if ((enmOperationResult)lngRes == enmOperationResult.DB_Succeed)
                    {
                        m_objCurrentRecordContent = objContent;
                    }
                    break;
                //...
            }
            //展开树显示所有时间节点。
            //			trvTime.ExpandAll();
            //返回结果
            return lngRes;
        }
        #endregion

        #region 作废重做的数据库保存。
        protected new long m_lngReAddNew()
        {
            //检查当前病人变量是否为null
            //获取服务器时间
            //从界面获取记录信息
            clsGestationMisbirthsthreeRelationVO objContent = m_objGetContentFromGUI();
            //界面输入值出错           
            if (objContent == null)
                return -1;
            clsPreModifyInfo m_objModifyInfo = null;
            long lngRes = m_objDomain.m_lngReAddNewRecord(m_objReAddNewOld, objContent, out m_objModifyInfo);

            //根据结果做不同的处理
            switch ((enmOperationResult)lngRes)
            {
                case enmOperationResult.DB_Succeed:
                    m_objCurrentRecordContent = objContent;
                    m_objReAddNewOld = null;
                    break;
                //...
            }
            //返回结果
            return lngRes;
        }
        #endregion

        #region 获取界面值
        protected clsGestationMisbirthsthreeRelationVO m_objGetContentFromGUI()
        {
            clsGestationMisbirthsthreeRelationVO objContent = new clsGestationMisbirthsthreeRelationVO();
            objContent.m_strOPERATIONDATE = m_cboSurgeryTime.Text;
            objContent.m_strOPERATIONREADY = m_cboPrepareTime.Text.Trim();
            if (m_chkBirthMedicine.Checked && m_chkBirthWater.Checked) objContent.m_strLABORINDUCTION = "12";
            else if (m_chkBirthMedicine.Checked) objContent.m_strLABORINDUCTION = "1";
            else if (m_chkBirthWater.Checked) objContent.m_strLABORINDUCTION = "2";
            else objContent.m_strLABORINDUCTION = "-1";
            objContent.m_strMEDICNAME = m_cboMedicineName.Text;
            objContent.m_strMEDICDOSE = m_cboMedicineWeight.Text;
            objContent.m_strDILUENTDOSE = m_cboDiluentMount.Text.Trim();
            objContent.m_strMEDICLOT = m_cboMedicineNumber.Text;
            objContent.m_strABDOMINALPUNCTURE = m_cboFbccbw.Text;
            objContent.m_strNONEEDLE = m_cboAbdomenNumber.Text.Trim();
            objContent.m_strPUNCTURESIZE = m_cboAbdomenTime.Text;
            objContent.m_strAMNIOTIC = m_cboAbdomenWater.Text;
            objContent.m_strAMNIOTICCOLOR = m_cboAbdomenColor.Text.Trim();
            objContent.m_strAMNIOTICOTHER = m_cboAbdomenOther.Text.Trim();
            objContent.m_strVAGINALCERVIX = m_cboWaterBursa.Text.Trim();
            objContent.m_strINSERTIONDEPTH = m_cboWaterBursaLength.Text.Trim();
            objContent.m_strMEILAN = m_cboWaterBursaMedia.Text.Trim();
            objContent.m_strVAGINALGAUZE = m_cboWaterBursaPaper.Text.Trim();
            objContent.m_strCYSTICTIME = m_cboWaterBursaTime.Text.Trim();
            objContent.m_strOUTOF = m_cboWaterBursaCondition.Text.Trim();
            if (m_rdbSurgeryFluency.Checked) objContent.m_strAFTERSURGERY = "1";
            else if (m_rdbSurgeryHard.Checked) objContent.m_strAFTERSURGERY = "2";
            else if (m_rdbSurgeryDifficult.Checked) objContent.m_strAFTERSURGERY = "3";
            else objContent.m_strAFTERSURGERY = "-1";
            objContent.m_strSURGICALBLEEDING = m_cboBloodMount.Text.Trim();
            objContent.m_strNOTES = m_txtRemark.Text.Trim();
            objContent.m_strNOTES_RIGHT = m_txtRemark.m_strGetRightText();
            objContent.m_strNOTES_XML = m_txtRemark.m_strGetXmlText();
            objContent.m_strCONTRACTIONSTIME = m_cboEmbryoShrinkTime.Text.Trim();
            objContent.m_strBROKENWATERTIME = m_cboEmbryoWaterTime.Text.Trim();
            objContent.m_strFETALDITIME = m_cboEmbryoOutTime.Text.Trim();
            if (m_rdbEmbryoOutNature.Checked) objContent.m_strFETALDIMETHOD = "1";
            else if (m_rdbEmbryoOutMenMake.Checked) objContent.m_strFETALDIMETHOD = "2";
            else objContent.m_strFETALDIMETHOD = "-1";
            if (m_rdbEmbryoNew.Checked) objContent.m_strFETAL = "1";
            else if (m_rdbEmbryoSofe.Checked) objContent.m_strFETAL = "2";
            else if (m_rdbEmbryoDead.Checked) objContent.m_strFETAL = "3";
            else if (m_rdbEmbryoOther.Checked) objContent.m_strFETAL = "4";
            else objContent.m_strFETAL = "-1";
            objContent.m_strFETALLENGTH = length.Text.Trim();
            objContent.m_strFETALWEIGHT = weight.Text.Trim();
            if (m_rdbEmbryoComplete.Checked) objContent.m_strPLACENTA = "1";
            else if (m_rdbEmbryoDisComplete.Checked) objContent.m_strPLACENTA = "2";
            else objContent.m_strPLACENTA = "-1";
            if (m_rdbEmbryoClearNo.Checked) objContent.m_strPALACE = "1";
            else if (m_rdbEmbryoClearYes.Checked) objContent.m_strPALACE = "2";
            else objContent.m_strPALACE = "-1";
            objContent.m_strPALACECONTENT = m_cboEmbryoReason.Text.Trim();
            objContent.m_strPOSTPARTUMBLEEDING = m_txtAfterBlood.Text.Trim();
            objContent.m_strCONTRACTIONSAGENT = m_cboAfterMedia.Text.Trim();
            objContent.m_strDOSE = m_cboAfterMount.Text.Trim();
            if (m_radCHRCDYES.Checked) objContent.m_strBIRTHCHECK = "1";
            else if (m_radCHRCDNO.Checked) objContent.m_strBIRTHCHECK = "2";
            else objContent.m_strBIRTHCHECK = "-1";
            objContent.m_strSHEXIANG = m_txtCheckText.Text.Trim();
            objContent.m_strSHEXIANG_RIGHT = m_txtCheckText.m_strGetRightText();
            objContent.m_strSHEXIANG_XML = m_txtCheckText.m_strGetXmlText();
            objContent.m_strTREATMENT = m_txtDelText.Text.Trim();
            objContent.m_strTREATMENT_RIGHT = m_txtDelText.m_strGetRightText();
            objContent.m_strTREATMENT_XML = m_txtDelText.m_strGetXmlText();
            objContent.m_dtmCreateDate = m_dtpCreateDate.Value;
            #region 获取签名集合
            int intSignCount = 0;
            intSignCount = lsvSign1.Items.Count + 1;
            intSignCount += lsvSign2.Items.Count + 1;
            intSignCount += lsvSign.Items.Count + 1;
            objContent.objSignerArr = new clsEmrSigns_VO[intSignCount];
            strUserIDList = "";
            strUserNameList = "";
            m_mthGetSignArr(new Control[] { lsvSign1, lsvSign2,lsvSign }, ref objContent.objSignerArr, ref strUserIDList, ref strUserNameList);
            #endregion
            return objContent;
        }
        #endregion

        #region 把特殊记录的值显示到界面上
        protected void m_mthSetGUIFromContent(clsGestationMisbirthsthreeRelationVO objContent)
        {
            #region 签名集合
            if (objContent.objSignerArr != null)
            {
                m_mthAddSignToListView(new ListView[] { lsvSign1, lsvSign2,lsvSign }, objContent.objSignerArr);
            }
            #endregion

            if (objContent.m_strInPatientID != null && objContent.m_strInPatientID != "")
            {
                m_strCurrentOpenDate = objContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss");
            }
            m_cboSurgeryTime.Text = objContent.m_strOPERATIONDATE;
            m_cboPrepareTime.Text = objContent.m_strOPERATIONREADY;
            if (objContent.m_strLABORINDUCTION == "1") m_chkBirthMedicine.Checked = true;
            if (objContent.m_strLABORINDUCTION == "2") m_chkBirthWater.Checked = true;
            if (objContent.m_strLABORINDUCTION == "12")
            {
                m_chkBirthMedicine.Checked = true; 
                m_chkBirthWater.Checked = true;
            }
            m_cboMedicineName.Text = objContent.m_strMEDICNAME;
            m_cboMedicineWeight.Text = objContent.m_strMEDICDOSE;
            m_cboDiluentMount.Text = objContent.m_strDILUENTDOSE;
            m_cboMedicineNumber.Text = objContent.m_strMEDICLOT;
            m_cboFbccbw.Text = objContent.m_strABDOMINALPUNCTURE;
            m_cboAbdomenNumber.Text = objContent.m_strNONEEDLE;
            m_cboAbdomenTime.Text = objContent.m_strPUNCTURESIZE;
            m_cboAbdomenWater.Text = objContent.m_strAMNIOTIC;
            m_cboAbdomenColor.Text = objContent.m_strAMNIOTICCOLOR;
            m_cboAbdomenOther.Text = objContent.m_strAMNIOTICOTHER;
            m_cboWaterBursa.Text = objContent.m_strVAGINALCERVIX;
            m_cboWaterBursaLength.Text = objContent.m_strINSERTIONDEPTH;
            m_cboWaterBursaMedia.Text = objContent.m_strMEILAN;
            m_cboWaterBursaPaper.Text = objContent.m_strVAGINALGAUZE;
            m_cboWaterBursaTime.Text = objContent.m_strCYSTICTIME;
            m_cboWaterBursaCondition.Text = objContent.m_strOUTOF;
            if (objContent.m_strAFTERSURGERY == "1") m_rdbSurgeryFluency.Checked = true;
            if (objContent.m_strAFTERSURGERY == "2") m_rdbSurgeryHard.Checked = true;
            if (objContent.m_strAFTERSURGERY == "3") m_rdbSurgeryDifficult.Checked = true;
            m_cboBloodMount.Text = objContent.m_strSURGICALBLEEDING;
            //m_txtRemark.Text = objContent.m_strNOTES;
            m_txtRemark.m_mthSetNewText(objContent.m_strNOTES, objContent.m_strNOTES_XML);
            m_cboEmbryoShrinkTime.Text = objContent.m_strCONTRACTIONSTIME;
            m_cboEmbryoWaterTime.Text = objContent.m_strBROKENWATERTIME;
            m_cboEmbryoOutTime.Text = objContent.m_strFETALDITIME;
            if (objContent.m_strFETALDIMETHOD == "1") m_rdbEmbryoOutNature.Checked = true;
            if (objContent.m_strFETALDIMETHOD == "2") m_rdbEmbryoOutMenMake.Checked = true;
            if (objContent.m_strFETAL == "1") m_rdbEmbryoNew.Checked = true;
            if (objContent.m_strFETAL == "2") m_rdbEmbryoSofe.Checked = true;
            if (objContent.m_strFETAL == "3") m_rdbEmbryoDead.Checked = true;
            if (objContent.m_strFETAL == "4") m_rdbEmbryoOther.Checked = true;
            length.Text = objContent.m_strFETALLENGTH;
            weight.Text = objContent.m_strFETALWEIGHT;
            if (objContent.m_strPLACENTA == "1") m_rdbEmbryoComplete.Checked = true;
            if (objContent.m_strPLACENTA == "2") m_rdbEmbryoDisComplete.Checked = true;
            if (objContent.m_strPALACE == "1") m_rdbEmbryoClearNo.Checked = true;
            if (objContent.m_strPALACE == "2") m_rdbEmbryoClearYes.Checked = true;
            m_cboEmbryoReason.Text = objContent.m_strPALACECONTENT;
            m_txtAfterBlood.Text = objContent.m_strPOSTPARTUMBLEEDING;
            m_cboAfterMedia.Text = objContent.m_strCONTRACTIONSAGENT;
            m_cboAfterMount.Text = objContent.m_strDOSE;
            if (objContent.m_strBIRTHCHECK == "1") m_radCHRCDYES.Checked = true;
            if (objContent.m_strBIRTHCHECK == "2") m_radCHRCDNO.Checked = true;
            //m_txtCheckText.Text = objContent.m_strSHEXIANG;
            m_txtCheckText.m_mthSetNewText(objContent.m_strSHEXIANG, objContent.m_strSHEXIANG_XML);
            //m_txtDelText.Text = objContent.m_strTREATMENT;
            m_txtDelText.m_mthSetNewText(objContent.m_strTREATMENT, objContent.m_strTREATMENT_XML);
            m_dtpCreateDate.Value = objContent.m_dtmCreateDate;
            m_objCurrentRecordContent = objContent;
            m_txtBedNO.Focus();
        }
        //审核
        protected override string m_StrCurrentOpenDate
        {
            get
            {
                if (string.IsNullOrEmpty(m_strCurrentOpenDate))
                {
                    clsPublicFunction.ShowInformationMessageBox("请先选择记录");
                    return string.Empty;
                }
                return m_strCurrentOpenDate;
            }
        }
        protected override bool m_BlnCanApprove
        {
            get
            {
                return true;
            }
        }
        protected override void m_mthSetNewRecord()
        {
            if (m_objCurrentPatient != null)
            {
                //签名默认值
                //MDIParent.m_mthSetDefaulEmployee(m_txtDoctorSign);
                //MDIParent.m_mthSetDefaulEmployee(m_txtCheckDocSign);

                //默认值 m_IntCurCase
                new clsDefaultValueTool(this, m_objCurrentPatient).m_mthSetDefaultValue();

                //设完默认值后回到光标床号
                m_txtBedNO.Focus();

            }
        }
        protected override void m_mthUnEnableRichTextBox()
        {

        }

        protected override void m_mthEnableRichTextBox()
        {

        }
        #endregion

        #region  获取病程记录的领域层实例
        protected override clsBaseCaseHistoryDomain m_objGetDomain()
        {
            return new clsBaseCaseHistoryDomain(enmBaseCaseHistoryTypeInfo.GestationMisbirthsthreeRec_CS);
        }
        #endregion

        #region m_mthPerformSessionChanged
        protected override void m_mthPerformSessionChanged(clsEmrPatientSessionInfo_VO p_objSelectedSession, int p_intIndex)
        {
            if (p_objSelectedSession == null)
                return;
            m_mthRecordChangedToSave();
            try
            {
                DateTime dtInDate = p_objSelectedSession.m_dtmHISInpatientDate;
                m_mthClearRecordInfo();
                DateTime dtmEMRInDate = p_objSelectedSession.m_dtmEMRInpatientDate;
                string strEMRInPatientID = p_objSelectedSession.m_strEMRInpatientId;
                m_objCurrentPatient.m_StrHISInPatientID = p_objSelectedSession.m_strHISInpatientId;
                m_objCurrentPatient.m_DtmSelectedHISInDate = dtInDate;
                m_objCurrentPatient.m_DtmSelectedInDate = dtmEMRInDate;
                m_objBaseCurrentPatient.m_DtmSelectedInDate = dtmEMRInDate;
                m_objBaseCurrentPatient.m_StrRegisterId = p_objSelectedSession.m_strRegisterId;
                m_objCurrentPatient.m_StrRegisterId = p_objSelectedSession.m_strRegisterId;
                m_mthIsReadOnly();
                if (!m_blnCanShowRecordContent())
                {
                    clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                    return;
                }
                m_mthEnableRichTextBox();
                //m_dtpInHospitalDate.Value = dtInDate;
                m_mthSetSelectedRecord(m_objCurrentPatient, string.Empty);
                if (m_objCurrentRecordContent != null)
                {
                    this.m_dtpCreateDate.Enabled = true;

                    //当前处于修改记录状态
                    MDIParent.m_mthChangeFormText(this, MDIParent.enmFormEditStatus.Modify);
                }
                else
                {
                    m_mthSetNewRecord();
                    //当前处于新增记录状态
                    MDIParent.m_mthChangeFormText(this, MDIParent.enmFormEditStatus.AddNew);
                }
            }
            catch (Exception exp)
            {
                string strtemp = exp.Message;
                m_mthClearRecordInfo();
                m_mthUnEnableRichTextBox();
                m_objCurrentRecordContent = null;
                m_mthEnableModify(true);
                this.m_dtpCreateDate.Enabled = true;
                this.m_dtpCreateDate.Text = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");
                m_mthSetNullPrintContext();
                //当前处于禁止输入状态
                MDIParent.m_mthChangeFormText(this, MDIParent.enmFormEditStatus.None);
            }
            finally
            {
                m_mthDoAfterSelect();
                m_mthAddFormStatusForClosingSave();
            }
        }
        #endregion

        #region 打印
        protected override long m_lngSubPrint()
        {
            m_mthPrintRecord();
            return 1;
        }

        private clsGestationMisbirthsthreePrintTool objPrintTool;
        private void m_mthPrintRecord()
        {
            objPrintTool = new clsGestationMisbirthsthreePrintTool();
            objPrintTool.m_mthInitPrintTool(null);
            if (m_objBaseCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
                objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, DateTime.MinValue, DateTime.MinValue);
            else
            {
                m_objBaseCurrentPatient.m_StrHISInPatientID = m_ObjCurrentEmrPatientSession.m_strHISInpatientId;
                m_objBaseCurrentPatient.m_DtmSelectedHISInDate = m_ObjCurrentEmrPatientSession.m_dtmHISInpatientDate;
                DateTime dtmTemp = DateTime.MinValue;
                if (!DateTime.TryParse(m_strCurrentOpenDate, out dtmTemp))
                    objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, m_ObjLastEmrPatientSession.m_dtmEMRInpatientDate, DateTime.MinValue);
                else
                    objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate, DateTime.Parse(m_strCurrentOpenDate));
            }
            objPrintTool.m_mthInitPrintContent();

            m_mthStartPrint();
        }

        protected override void m_pdcPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            objPrintTool.m_mthPrintPage(e);

            if (ppdPrintPreview != null)
                while (!ppdPrintPreview.m_blnHandlePrint(e))
                    objPrintTool.m_mthPrintPage(e);
        }

        protected override void m_pdcPrintDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            objPrintTool.m_mthBeginPrint(e);
        }

        protected override void m_pdcPrintDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            objPrintTool.m_mthEndPrint(e);
        }
        #endregion

        #region 复选框事件
        private void m_chkBirthMedicine_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkBirthMedicine.Checked)
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = false;
            }
            else
            {
                groupBox1.Enabled = false;
                m_cboMedicineName.Text = "";
                m_cboMedicineWeight.Text = "";
                m_cboDiluentMount.Text = "";
                m_cboMedicineNumber.Text = "";
                m_cboFbccbw.Text = "";
                m_cboAbdomenNumber.Text = "";
                m_cboAbdomenTime.Text = "";
                m_cboAbdomenWater.Text = "";
                m_cboAbdomenColor.Text = "";
                m_cboAbdomenOther.Text = "";
            }
            if (m_chkBirthWater.Checked)
            { groupBox2.Enabled = true; }
        }

        private void m_chkBirthWater_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkBirthWater.Checked)
            {
                groupBox2.Enabled = true;
                groupBox1.Enabled = false;
            }
            else
            {
                groupBox2.Enabled = false;
                m_cboWaterBursa.Text = "";
                m_cboWaterBursaLength.Text = "";
                m_cboWaterBursaMedia.Text = "";
                m_cboWaterBursaPaper.Text = "";
                m_cboWaterBursaTime.Text = "";
                m_cboWaterBursaCondition.Text = "";
            }
            if (m_chkBirthMedicine.Checked)
            { groupBox1.Enabled = true; }
        }
        private void m_radCHRCDYES_CheckedChanged(object sender, EventArgs e)
        {
            if (m_radCHRCDYES.Checked)
            {
                m_txtCheckText.Enabled = false;
                m_txtCheckText.Text = "";
            }
        }

        private void m_radCHRCDNO_CheckedChanged(object sender, EventArgs e)
        {
            if (m_radCHRCDNO.Checked)
            {
                m_txtCheckText.Enabled = true;
            }
        }
        #endregion
    }
}