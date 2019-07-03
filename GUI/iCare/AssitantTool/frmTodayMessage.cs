using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
//using com.digitalwave.iCare.middletier.HRPService;
using iCareData;
using com.digitalwave.emr.BEDExplorer;
using System.Threading;

namespace iCare
{
    /// <summary>
    /// 今日提醒表单版
    /// </summary>
    public class frmTodayMessage : iCareBaseForm.frmBaseForm
    {
        private DateTime m_dtmTemp = DateTime.Now;
        private Hashtable m_hasSelectDept;
        private System.Data.DataTable m_dtbMessages;
        private System.Data.DataTable m_dtbDeadMessages;
        DataTable m_dtbResult;
        //private com.digitalwave.emr.HospitalManagerService.clsCaseMessageServ objCaseMessage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button cmdSend;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private clsAutoHeight dataGridTextBoxColumn1;
        private clsAutoHeight dataGridTextBoxColumn2;
        private clsAutoHeight dataGridTextBoxColumn3;
        private clsAutoHeight dataGridTextBoxColumn4;
        private clsAutoHeight dataGridTextBoxColumn5;
        private clsAutoHeightScroll dataGridTextBoxColumn6;
        private clsAutoHeight dataGridTextBoxColumn7;
        private clsAutoHeight dataGridTextBoxColumn8;
        private clsAutoHeight dataGridTextBoxColumn9;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn8;
        private System.Data.DataColumn dataColumn9;
        private System.Windows.Forms.Button m_cmdSendMessage;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label label1;
        private com.digitalwave.Controls.Domain.EmrControls.ctlDeptSelected m_ctlDept;
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        public frmTodayMessage()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            m_hasSelectDept = new Hashtable(10);
            m_dtbMessages = new DataTable();
            //objCaseMessage =
            //    (com.digitalwave.emr.HospitalManagerService.clsCaseMessageServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.emr.HospitalManagerService.clsCaseMessageServ));

            m_dtbResult = new DataTable("dtResult");
            m_dtbResult.Columns.Add("messageid_int");
            m_dtbResult.Columns.Add("registerid_chr");
            m_dtbResult.Columns.Add("clmINPATIENTDATE");
            m_dtbResult.Columns.Add("bedname_vchr");
            m_dtbResult.Columns.Add("patientname_vchr");
            m_dtbResult.Columns.Add("chargedocname_vchr");
            m_dtbResult.Columns.Add("cuemessage");
            m_dtbResult.Columns.Add("clmDOCTORID");
            m_dtbResult.Columns.Add("bedid_chr");
        }

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTodayMessage));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmdExit = new System.Windows.Forms.Button();
            this.cmdSend = new System.Windows.Forms.Button();
            this.m_cmdSendMessage = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new iCare.clsAutoHeight();
            this.dataGridTextBoxColumn2 = new iCare.clsAutoHeight();
            this.dataGridTextBoxColumn3 = new iCare.clsAutoHeight();
            this.dataGridTextBoxColumn9 = new iCare.clsAutoHeight();
            this.dataGridTextBoxColumn4 = new iCare.clsAutoHeight();
            this.dataGridTextBoxColumn5 = new iCare.clsAutoHeight();
            this.dataGridTextBoxColumn6 = new iCare.clsAutoHeightScroll();
            this.dataGridTextBoxColumn7 = new iCare.clsAutoHeight();
            this.dataGridTextBoxColumn8 = new iCare.clsAutoHeight();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.dataColumn9 = new System.Data.DataColumn();
            this.m_ctlDept = new com.digitalwave.Controls.Domain.EmrControls.ctlDeptSelected();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_ctlDept);
            this.panel1.Controls.Add(this.lblMessage);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(816, 52);
            this.panel1.TabIndex = 2;
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessage.Location = new System.Drawing.Point(290, 12);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(518, 23);
            this.lblMessage.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "病区：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmdExit);
            this.panel2.Controls.Add(this.cmdSend);
            this.panel2.Controls.Add(this.m_cmdSendMessage);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 545);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(816, 60);
            this.panel2.TabIndex = 3;
            // 
            // cmdExit
            // 
            this.cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExit.Location = new System.Drawing.Point(696, 16);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(108, 32);
            this.cmdExit.TabIndex = 1;
            this.cmdExit.Text = "退出(&X)";
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // cmdSend
            // 
            this.cmdSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSend.Location = new System.Drawing.Point(548, 16);
            this.cmdSend.Name = "cmdSend";
            this.cmdSend.Size = new System.Drawing.Size(136, 32);
            this.cmdSend.TabIndex = 0;
            this.cmdSend.Text = "发送系统消息(&S)";
            this.cmdSend.Click += new System.EventHandler(this.cmdSend_Click);
            // 
            // m_cmdSendMessage
            // 
            this.m_cmdSendMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdSendMessage.Location = new System.Drawing.Point(412, 16);
            this.m_cmdSendMessage.Name = "m_cmdSendMessage";
            this.m_cmdSendMessage.Size = new System.Drawing.Size(120, 32);
            this.m_cmdSendMessage.TabIndex = 0;
            this.m_cmdSendMessage.Text = "发送短信息";
            this.m_cmdSendMessage.Click += new System.EventHandler(this.m_cmdSendMessage_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.CaptionBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.CaptionFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.CaptionForeColor = System.Drawing.Color.Black;
            this.dataGrid1.CaptionText = "今日提醒";
            this.dataGrid1.DataMember = "";
            this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(0, 52);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsVisible = false;
            this.dataGrid1.PreferredRowHeight = 20;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.Size = new System.Drawing.Size(816, 493);
            this.dataGrid1.TabIndex = 5;
            this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.dataGrid1.TabStop = false;
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.dataGrid1;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn9,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn8});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "dtResult";
            this.dataGridTableStyle1.PreferredRowHeight = 20;
            this.dataGridTableStyle1.ReadOnly = true;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "ID";
            this.dataGridTextBoxColumn1.ReadOnly = true;
            this.dataGridTextBoxColumn1.Width = 0;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "住院登记号";
            this.dataGridTextBoxColumn2.ReadOnly = true;
            this.dataGridTextBoxColumn2.Width = 0;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "INPATIENTDATE";
            this.dataGridTextBoxColumn3.ReadOnly = true;
            this.dataGridTextBoxColumn3.Width = 0;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "床号";
            this.dataGridTextBoxColumn9.MappingName = "bedname_vchr";
            this.dataGridTextBoxColumn9.ReadOnly = true;
            this.dataGridTextBoxColumn9.Width = 120;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "姓名";
            this.dataGridTextBoxColumn4.MappingName = "patientname_vchr";
            this.dataGridTextBoxColumn4.ReadOnly = true;
            this.dataGridTextBoxColumn4.Width = 120;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "管床医生";
            this.dataGridTextBoxColumn5.ReadOnly = true;
            this.dataGridTextBoxColumn5.Width = 0;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "内容";
            this.dataGridTextBoxColumn6.MappingName = "cuemessage";
            this.dataGridTextBoxColumn6.ReadOnly = true;
            this.dataGridTextBoxColumn6.Width = 600;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "DOCTORID";
            this.dataGridTextBoxColumn7.ReadOnly = true;
            this.dataGridTextBoxColumn7.Width = 0;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "BEDID";
            this.dataGridTextBoxColumn8.ReadOnly = true;
            this.dataGridTextBoxColumn8.Width = 0;
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "clmID";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "clmINPATIENTID";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "clmINPATIENTDATE";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "clmPATIENTNAME";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "clmDOCTORNAME";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "clmTODAYMESSAGE";
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "clmDOCTORID";
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "clmBEDID";
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "clmBEDNAME";
            // 
            // m_ctlDept
            // 
            this.m_ctlDept.Location = new System.Drawing.Point(55, 9);
            this.m_ctlDept.m_objTag = null;
            this.m_ctlDept.Name = "m_ctlDept";
            this.m_ctlDept.Size = new System.Drawing.Size(175, 23);
            this.m_ctlDept.TabIndex = 3;
            this.m_ctlDept.显示类型 = com.digitalwave.Controls.Domain.EmrControls.enmDeptAttributeType.全部;
            this.m_ctlDept.ItemSelectedChanged += new com.digitalwave.Controls.ItemSelectedEventHandler(this.m_ctlDept_ItemSelectedChanged);
            // 
            // frmTodayMessage
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(816, 605);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTodayMessage";
            this.Text = "Today Message";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private void Form1_Load(object sender, System.EventArgs e)
        {
            //m_mthLoadDepts();
            //if (cmbDept.Items.Count > 0)
            //{
            //    cmbDept.SelectedIndex = 0;
            //}
            m_ctlDept.m_mthInitDeptData(clsEMRLogin.LoginInfo.m_strEmpID);
        }

        private void m_mthLoadDepts()
        {
            //clsEmrDept_VO[] objDeptInfoArr = null;
            //long lngRes = new clsHospitalManagerDomain().m_lngGetDeptInfo(clsEMRLogin.LoginInfo.m_strEmpID, out objDeptInfoArr);

            //if (objDeptInfoArr != null)
            //{
            //    for (int i = 0; i < objDeptInfoArr.Length; i++)
            //    {
            //        cmbDept.Items.AddRange(objDeptInfoArr);
            //    }
            //    cmbDept.SelectedIndex = 0;
            //}
        }

        private void cmbDept_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //Cursor = Cursors.WaitCursor;
            //try
            //{
            //    if (cmbDept.SelectedItem is clsEmrDept_VO)
            //    {
            //        string strDeptID = ((clsEmrDept_VO)cmbDept.SelectedItem).m_strDEPTID_CHR;
            //        clsHospitalManagerDomain objDomain = new clsHospitalManagerDomain();
            //        clsEmrDept_VO[] objAreaInfoArr = null;
            //        long lngRes = objDomain.m_lngGetAreaInfo(strDeptID, out objAreaInfoArr);

            //        if (lngRes <= 0)
            //        {
            //            return;
            //        }
            //        m_cboArea.Items.Clear();
            //        if (objAreaInfoArr != null)
            //        {
            //            m_cboArea.Items.AddRange(objAreaInfoArr);
            //            m_cboArea.SelectedItem = objAreaInfoArr[0];
            //        }
            //        else//若不存在病区，则以科室ID去获取病床
            //        {
            //            m_mthGetMessageData(strDeptID);
            //        }

            //    }
            //}
            //catch (Exception ex)
            //{
            //    new com.digitalwave.Utility.clsLogText().LogDetailError(ex, false);
            //}
            //finally
            //{
            //    Cursor = Cursors.Default;
            //    lblMessage.Text = "";
            //}
        }

        private void m_cboArea_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //Cursor = Cursors.WaitCursor;
            //try
            //{
            //    if (m_cboArea.SelectedItem is clsEmrDept_VO)
            //    {
            //        string strDeptID = ((clsEmrDept_VO)m_cboArea.SelectedItem).m_strDEPTID_CHR;
            //        m_mthGetMessageData(strDeptID);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    new com.digitalwave.Utility.clsLogText().LogDetailError(ex, false);
            //}
            //finally
            //{
            //    Cursor = Cursors.Default;
            //    lblMessage.Text = "";
            //}

        }

        private void m_mthGetMessageData(string strDeptID)
        {
            lblMessage.Text = "正在查询数据，请稍候......";
            Application.DoEvents();
            bool blnIsProcessDepartmentNow = false;
            long lngRes = 0;
            if (m_hasSelectDept.Contains(strDeptID))
            {
                if (((DateTime)m_hasSelectDept[strDeptID]).AddHours(1) < DateTime.Now)
                {
                    blnIsProcessDepartmentNow = true;
                }
            }
            if (blnIsProcessDepartmentNow != true)
            {
                if (m_dtbMessages != null)
                {
                    m_dtbMessages.Clear();
                    m_dtbMessages.Dispose();
                    m_dtbMessages = null;
                }
                if (m_dtbDeadMessages != null)
                {
                    m_dtbDeadMessages.Clear();
                    m_dtbDeadMessages.Dispose();
                    m_dtbDeadMessages = null;
                }
                m_dtbMessages = new clsCaseMessageDomain().m_objGetMessage(strDeptID, out m_dtbDeadMessages);
            }
             m_mthProcessData(m_dtbMessages,m_dtbDeadMessages, ref m_dtbResult);
            dataGrid1.DataSource = m_dtbResult;
            m_dtmTemp = DateTime.Now;
            if (m_hasSelectDept.Contains(strDeptID))
                m_hasSelectDept[strDeptID] = m_dtmTemp;
            else
                m_hasSelectDept.Add(strDeptID, m_dtmTemp);
            lblMessage.Text = string.Empty;
            Application.DoEvents();
        }

        private void m_mthProcessData(DataTable p_dtbOrigin, DataTable p_dtbDeadOrigin,ref DataTable p_dtbResult)
        {
            p_dtbResult.Rows.Clear();
            string strMsgs = "";
            string strRegisterId = "";
            DataRow[] drArr  = null;
            DataTable dtbRegister=new DataTable();
            if(p_dtbOrigin != null)
            {
                dtbRegister = p_dtbOrigin.DefaultView.ToTable(true, new string[] { "registerid_chr"});
            }
            if (dtbRegister.Rows.Count == 0 && p_dtbDeadOrigin != null)
            {
                dtbRegister = p_dtbDeadOrigin.DefaultView.ToTable(true, new string[] { "registerid_chr" });
            }
            if (dtbRegister.Rows.Count > 0)
            {
                DataRow objRegisterRow = null;
                for (int i = 0; i < dtbRegister.Rows.Count; i++)
                {
                    string strOut = "";
                    int intOut = 1;
                    objRegisterRow = dtbRegister.Rows[i];
                    string[] strPatientInfoArr = new string[p_dtbResult.Columns.Count];
                    #region 普通提示
                    if (p_dtbOrigin != null)
                    {
                        drArr = p_dtbOrigin.Select("REGISTERID_CHR = '" + objRegisterRow["registerid_chr"].ToString() + "'", "cueid_int");
                        if (drArr.Length > 0)
                        {
                            intOut = 1;
                            DataRow objRow = null;
                            strOut = "";
                            for (int j = 0; j < drArr.Length; j++)//cuemessage_vchr
                            {
                                objRow = drArr[j];
                                if (objRow["CUESTATE_INT"].ToString() == "0")
                                {
                                    string strcuemessage = objRow["cuemessage_vchr"].ToString();
                                    string[] strCuemessageArr = strcuemessage.Split('$');

                                    DateTime dtmCreatesDate = DateTime.Parse(objRow["CREATEDTIME_DAT"].ToString());
                                    int intHour = 0;
                                    if (!int.TryParse(objRow["surplushour_int"].ToString(), out intHour))
                                        intHour = 0;

                                    if (dtmCreatesDate.AddHours(intHour) < DateTime.Now)//因为是8小时才刷新一次，所以在这8小时内要动态判断是否已经过期
                                    {
                                        if (strCuemessageArr.Length == 2)
                                        {
                                            strOut += (intOut++) + "、" + strCuemessageArr[1] + Environment.NewLine;
                                            objRow.BeginEdit();
                                            objRow["CUESTATE_INT"] = 1;
                                            objRow["cuemessage_vchr"] = strCuemessageArr[1];
                                            objRow.EndEdit();
                                        }
                                    }
                                }
                                else
                                    strOut += (intOut++) + "、" + objRow["cuemessage_vchr"].ToString() + Environment.NewLine;
                            }

                            strPatientInfoArr[0] = objRow["messageid_int"].ToString();
                            strPatientInfoArr[1] = objRow["registerid_chr"].ToString();
                            strPatientInfoArr[2] = "";//p_dtbOrigin.Rows[i-1]["INPATIENTDATE"].ToString().Trim();
                            strPatientInfoArr[3] = objRow["bedname_vchr"].ToString();
                            strPatientInfoArr[4] = objRow["patientname_vchr"].ToString();
                            strPatientInfoArr[5] = objRow["chargedocname_vchr"].ToString();
                            strPatientInfoArr[7] = "";//p_dtbOrigin.Rows[i-1]["clmDOCTORID"].ToString().Trim();
                            strPatientInfoArr[8] = objRow["bedid_chr"].ToString();
                        }
                    }
                    #endregion 普通提示
                    #region 死亡提示
                    if (p_dtbDeadOrigin != null)
                    {
                        drArr = p_dtbDeadOrigin.Select("REGISTERID_CHR = '" + objRegisterRow["registerid_chr"].ToString() + "'", "deadcueid_int");
                        if (drArr.Length > 0)
                        {
                            DataRow objRow = null;
                            for (int k2 = 0; k2 < drArr.Length; k2++)
                            {
                                objRow = drArr[k2];

                                strOut += (intOut++) + "、" + objRow["cuemessage_vchr"].ToString() + Environment.NewLine;
                            }
                            if (strPatientInfoArr[1] == null)
                            {
                                strPatientInfoArr[0] = objRow["messageid_int"].ToString();
                                strPatientInfoArr[1] = objRow["registerid_chr"].ToString();
                                strPatientInfoArr[2] = "";//p_dtbOrigin.Rows[i-1]["INPATIENTDATE"].ToString().Trim();
                                strPatientInfoArr[3] = objRow["bedname_vchr"].ToString();
                                strPatientInfoArr[4] = objRow["patientname_vchr"].ToString();
                                strPatientInfoArr[5] = objRow["chargedocname_vchr"].ToString();
                                strPatientInfoArr[7] = "";//p_dtbOrigin.Rows[i-1]["clmDOCTORID"].ToString().Trim();
                                strPatientInfoArr[8] = objRow["bedid_chr"].ToString();
                            }
                        }
                    }
                    #endregion 死亡提示
                    strPatientInfoArr[6] = strOut;
                    p_dtbResult.Rows.Add(strPatientInfoArr);
                }
            }
        }

        private void cmdExit_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void cmdSend_Click(object sender, System.EventArgs e)
        {
            //			DataTable dtb = (DataTable)dataGrid1.DataSource;
            //			if(dtb = null) return;
            //			for(int i=0;i<dtb.Rows.Count;i++)
            //			{
            //				if(dataGrid1.IsSelected(i))
            //				{
            //					long lngResult = objCaseMessage.m_lngAddMessage(dtb,i);
            //				}
            //			}
        }

        private void m_cmdSendMessage_Click(object sender, System.EventArgs e)
        {
            string strMessage = "";
            if (dataGrid1.VisibleRowCount <= 0)
                return;
            strMessage = dataGrid1[dataGrid1.CurrentRowIndex, 6].ToString();

            iCare.AssitantTool.frmSendMessage frm = new iCare.AssitantTool.frmSendMessage(strMessage);
            frm.ShowDialog();
        }

        private void m_ctlDept_ItemSelectedChanged(object sender, com.digitalwave.Controls.clsItemDataEventArg e)
        {
            m_mthGetMessageData(m_ctlDept.StrItemId);
        }

    }
}
