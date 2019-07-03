namespace iCare
{
    partial class frmEMR_HIS_CheckRequisition
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEMR_HIS_CheckRequisition));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_dtpRecordDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_txtAdmissionDiagnosis = new com.digitalwave.controls.ctlRichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.m_txtPhysExam = new com.digitalwave.controls.ctlRichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_txtCaseSummary = new com.digitalwave.controls.ctlRichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_cmdSave = new PinkieControls.ButtonXP();
            this.m_cmdClose = new PinkieControls.ButtonXP();
            this.m_cmdDelete = new PinkieControls.ButtonXP();
            this.m_lblInDate = new System.Windows.Forms.Label();
            this.m_bgwGetRecord = new System.ComponentModel.BackgroundWorker();
            this.m_cmdAddTemplate = new PinkieControls.ButtonXP();
            this.m_cmdAddCommonUse = new PinkieControls.ButtonXP();
            this.m_cmdSetDefault = new PinkieControls.ButtonXP();
            this.m_cmdResetDefault = new PinkieControls.ButtonXP();
            this.m_pnlNewBase.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(240, 168);
            this.lblSex.Size = new System.Drawing.Size(10, 22);
            this.lblSex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(187, 158);
            this.lblAge.Size = new System.Drawing.Size(10, 22);
            this.lblAge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(212, 163);
            this.lblBedNoTitle.Size = new System.Drawing.Size(63, 14);
            this.lblBedNoTitle.Text = "床  号：";
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(213, 172);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(212, 162);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(227, 176);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(238, 170);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(132, 168);
            this.lblAreaTitle.Size = new System.Drawing.Size(70, 14);
            this.lblAreaTitle.Text = "病    区:";
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(215, 177);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(20, 23);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Enabled = false;
            this.txtInPatientID.Location = new System.Drawing.Point(224, 158);
            this.txtInPatientID.Size = new System.Drawing.Size(10, 23);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Enabled = false;
            this.m_txtPatientName.Location = new System.Drawing.Point(224, 165);
            this.m_txtPatientName.Size = new System.Drawing.Size(10, 23);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Enabled = false;
            this.m_txtBedNO.Location = new System.Drawing.Point(203, 167);
            this.m_txtBedNO.Size = new System.Drawing.Size(29, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Enabled = false;
            this.m_cboArea.Location = new System.Drawing.Point(222, 162);
            this.m_cboArea.Size = new System.Drawing.Size(10, 23);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(275, 160);
            this.m_lsvPatientName.Size = new System.Drawing.Size(16, 16);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(199, 177);
            this.m_lsvBedNO.Size = new System.Drawing.Size(10, 10);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Enabled = false;
            this.m_cboDept.Location = new System.Drawing.Point(185, 167);
            this.m_cboDept.Size = new System.Drawing.Size(24, 23);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(205, 177);
            this.lblDept.Size = new System.Drawing.Size(70, 14);
            this.lblDept.Text = "科    室:";
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(292, 174);
            this.m_cmdNewTemplate.Size = new System.Drawing.Size(15, 10);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Location = new System.Drawing.Point(241, 160);
            this.m_cmdNext.Size = new System.Drawing.Size(28, 24);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(208, 161);
            this.m_cmdPre.Size = new System.Drawing.Size(10, 10);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(190, 165);
            this.m_lblForTitle.Size = new System.Drawing.Size(10, 10);
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(192, 178);
            this.chkModifyWithoutMatk.Size = new System.Drawing.Size(26, 10);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(771, 37);
            this.m_cmdModifyPatientInfo.Size = new System.Drawing.Size(69, 25);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Location = new System.Drawing.Point(8, 8);
            this.m_pnlNewBase.Size = new System.Drawing.Size(849, 57);
            this.m_pnlNewBase.Visible = true;
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowRace = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(847, 26);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 10000005;
            this.label2.Text = "住院日期:";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Location = new System.Drawing.Point(502, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 10000006;
            this.label3.Text = "记录时间:";
            // 
            // m_dtpRecordDate
            // 
            this.m_dtpRecordDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpRecordDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpRecordDate.Location = new System.Drawing.Point(572, 39);
            this.m_dtpRecordDate.Name = "m_dtpRecordDate";
            this.m_dtpRecordDate.Size = new System.Drawing.Size(188, 23);
            this.m_dtpRecordDate.TabIndex = 10000007;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_txtAdmissionDiagnosis);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.m_txtPhysExam);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.m_txtCaseSummary);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(8, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(849, 425);
            this.groupBox1.TabIndex = 10000009;
            this.groupBox1.TabStop = false;
            // 
            // m_txtAdmissionDiagnosis
            // 
            this.m_txtAdmissionDiagnosis.AccessibleDescription = "入院诊断";
            this.m_txtAdmissionDiagnosis.BackColor = System.Drawing.Color.White;
            this.m_txtAdmissionDiagnosis.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtAdmissionDiagnosis.ForeColor = System.Drawing.Color.Black;
            this.m_txtAdmissionDiagnosis.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtAdmissionDiagnosis.Location = new System.Drawing.Point(6, 290);
            this.m_txtAdmissionDiagnosis.m_BlnIgnoreUserInfo = false;
            this.m_txtAdmissionDiagnosis.m_BlnPartControl = false;
            this.m_txtAdmissionDiagnosis.m_BlnReadOnly = false;
            this.m_txtAdmissionDiagnosis.m_BlnUnderLineDST = false;
            this.m_txtAdmissionDiagnosis.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtAdmissionDiagnosis.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtAdmissionDiagnosis.m_IntCanModifyTime = 6;
            this.m_txtAdmissionDiagnosis.m_IntPartControlLength = 0;
            this.m_txtAdmissionDiagnosis.m_IntPartControlStartIndex = 0;
            this.m_txtAdmissionDiagnosis.m_StrUserID = "";
            this.m_txtAdmissionDiagnosis.m_StrUserName = "";
            this.m_txtAdmissionDiagnosis.MaxLength = 2000;
            this.m_txtAdmissionDiagnosis.Name = "m_txtAdmissionDiagnosis";
            this.m_txtAdmissionDiagnosis.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtAdmissionDiagnosis.Size = new System.Drawing.Size(837, 116);
            this.m_txtAdmissionDiagnosis.TabIndex = 300;
            this.m_txtAdmissionDiagnosis.Text = "";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 272);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "入院诊断:";
            // 
            // m_txtPhysExam
            // 
            this.m_txtPhysExam.AccessibleDescription = "体检";
            this.m_txtPhysExam.BackColor = System.Drawing.Color.White;
            this.m_txtPhysExam.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPhysExam.ForeColor = System.Drawing.Color.Black;
            this.m_txtPhysExam.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPhysExam.Location = new System.Drawing.Point(6, 169);
            this.m_txtPhysExam.m_BlnIgnoreUserInfo = false;
            this.m_txtPhysExam.m_BlnPartControl = false;
            this.m_txtPhysExam.m_BlnReadOnly = false;
            this.m_txtPhysExam.m_BlnUnderLineDST = false;
            this.m_txtPhysExam.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPhysExam.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPhysExam.m_IntCanModifyTime = 6;
            this.m_txtPhysExam.m_IntPartControlLength = 0;
            this.m_txtPhysExam.m_IntPartControlStartIndex = 0;
            this.m_txtPhysExam.m_StrUserID = "";
            this.m_txtPhysExam.m_StrUserName = "";
            this.m_txtPhysExam.MaxLength = 2000;
            this.m_txtPhysExam.Name = "m_txtPhysExam";
            this.m_txtPhysExam.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtPhysExam.Size = new System.Drawing.Size(837, 99);
            this.m_txtPhysExam.TabIndex = 200;
            this.m_txtPhysExam.Text = "";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(5, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(228, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "体检:";
            // 
            // m_txtCaseSummary
            // 
            this.m_txtCaseSummary.AccessibleDescription = "病历摘要";
            this.m_txtCaseSummary.BackColor = System.Drawing.Color.White;
            this.m_txtCaseSummary.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCaseSummary.ForeColor = System.Drawing.Color.Black;
            this.m_txtCaseSummary.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCaseSummary.Location = new System.Drawing.Point(6, 31);
            this.m_txtCaseSummary.m_BlnIgnoreUserInfo = false;
            this.m_txtCaseSummary.m_BlnPartControl = false;
            this.m_txtCaseSummary.m_BlnReadOnly = false;
            this.m_txtCaseSummary.m_BlnUnderLineDST = false;
            this.m_txtCaseSummary.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCaseSummary.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCaseSummary.m_IntCanModifyTime = 6;
            this.m_txtCaseSummary.m_IntPartControlLength = 0;
            this.m_txtCaseSummary.m_IntPartControlStartIndex = 0;
            this.m_txtCaseSummary.m_StrUserID = "";
            this.m_txtCaseSummary.m_StrUserName = "";
            this.m_txtCaseSummary.MaxLength = 2000;
            this.m_txtCaseSummary.Name = "m_txtCaseSummary";
            this.m_txtCaseSummary.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtCaseSummary.Size = new System.Drawing.Size(837, 117);
            this.m_txtCaseSummary.TabIndex = 100;
            this.m_txtCaseSummary.Text = "";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(7, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "病历摘要:";
            // 
            // m_cmdSave
            // 
            this.m_cmdSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdSave.DefaultScheme = true;
            this.m_cmdSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSave.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdSave.Hint = "";
            this.m_cmdSave.Location = new System.Drawing.Point(672, 501);
            this.m_cmdSave.Name = "m_cmdSave";
            this.m_cmdSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSave.Size = new System.Drawing.Size(90, 24);
            this.m_cmdSave.TabIndex = 10000049;
            this.m_cmdSave.Tag = "1";
            this.m_cmdSave.Text = "保存(&S)";
            this.m_cmdSave.Click += new System.EventHandler(this.m_cmdSave_Click);
            // 
            // m_cmdClose
            // 
            this.m_cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdClose.DefaultScheme = true;
            this.m_cmdClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdClose.Hint = "";
            this.m_cmdClose.Location = new System.Drawing.Point(764, 501);
            this.m_cmdClose.Name = "m_cmdClose";
            this.m_cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClose.Size = new System.Drawing.Size(90, 24);
            this.m_cmdClose.TabIndex = 10000049;
            this.m_cmdClose.Tag = "1";
            this.m_cmdClose.Text = "退出(&Q)";
            this.m_cmdClose.Click += new System.EventHandler(this.m_cmdClose_Click);
            // 
            // m_cmdDelete
            // 
            this.m_cmdDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdDelete.DefaultScheme = true;
            this.m_cmdDelete.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdDelete.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdDelete.Hint = "";
            this.m_cmdDelete.Location = new System.Drawing.Point(580, 501);
            this.m_cmdDelete.Name = "m_cmdDelete";
            this.m_cmdDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDelete.Size = new System.Drawing.Size(90, 24);
            this.m_cmdDelete.TabIndex = 10000049;
            this.m_cmdDelete.Tag = "1";
            this.m_cmdDelete.Text = "删除(&D)";
            this.m_cmdDelete.Click += new System.EventHandler(this.m_cmdDelete_Click);
            // 
            // m_lblInDate
            // 
            this.m_lblInDate.Location = new System.Drawing.Point(115, 150);
            this.m_lblInDate.Name = "m_lblInDate";
            this.m_lblInDate.Size = new System.Drawing.Size(11, 24);
            this.m_lblInDate.TabIndex = 10000050;
            this.m_lblInDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lblInDate.Visible = false;
            // 
            // m_bgwGetRecord
            // 
            this.m_bgwGetRecord.DoWork += new System.ComponentModel.DoWorkEventHandler(this.m_bgwGetRecord_DoWork);
            this.m_bgwGetRecord.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.m_bgwGetRecord_RunWorkerCompleted);
            // 
            // m_cmdAddTemplate
            // 
            this.m_cmdAddTemplate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdAddTemplate.DefaultScheme = true;
            this.m_cmdAddTemplate.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAddTemplate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdAddTemplate.Hint = "";
            this.m_cmdAddTemplate.Location = new System.Drawing.Point(14, 501);
            this.m_cmdAddTemplate.Name = "m_cmdAddTemplate";
            this.m_cmdAddTemplate.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAddTemplate.Size = new System.Drawing.Size(103, 24);
            this.m_cmdAddTemplate.TabIndex = 10000049;
            this.m_cmdAddTemplate.Tag = "1";
            this.m_cmdAddTemplate.Text = "生成模板(&T)";
            this.m_cmdAddTemplate.Click += new System.EventHandler(this.m_cmdAddTemplate_Click);
            // 
            // m_cmdAddCommonUse
            // 
            this.m_cmdAddCommonUse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdAddCommonUse.DefaultScheme = true;
            this.m_cmdAddCommonUse.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAddCommonUse.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdAddCommonUse.Hint = "";
            this.m_cmdAddCommonUse.Location = new System.Drawing.Point(118, 501);
            this.m_cmdAddCommonUse.Name = "m_cmdAddCommonUse";
            this.m_cmdAddCommonUse.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAddCommonUse.Size = new System.Drawing.Size(103, 24);
            this.m_cmdAddCommonUse.TabIndex = 10000049;
            this.m_cmdAddCommonUse.Tag = "1";
            this.m_cmdAddCommonUse.Text = "生成常用值(&C)";
            this.m_cmdAddCommonUse.Click += new System.EventHandler(this.m_cmdAddCommonUse_Click);
            // 
            // m_cmdSetDefault
            // 
            this.m_cmdSetDefault.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdSetDefault.DefaultScheme = true;
            this.m_cmdSetDefault.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSetDefault.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdSetDefault.Hint = "";
            this.m_cmdSetDefault.Location = new System.Drawing.Point(222, 501);
            this.m_cmdSetDefault.Name = "m_cmdSetDefault";
            this.m_cmdSetDefault.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSetDefault.Size = new System.Drawing.Size(103, 24);
            this.m_cmdSetDefault.TabIndex = 10000049;
            this.m_cmdSetDefault.Tag = "1";
            this.m_cmdSetDefault.Text = "生成默认值(&F)";
            this.m_cmdSetDefault.Click += new System.EventHandler(this.m_cmdSetDefault_Click);
            // 
            // m_cmdResetDefault
            // 
            this.m_cmdResetDefault.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdResetDefault.DefaultScheme = true;
            this.m_cmdResetDefault.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdResetDefault.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdResetDefault.Hint = "";
            this.m_cmdResetDefault.Location = new System.Drawing.Point(326, 501);
            this.m_cmdResetDefault.Name = "m_cmdResetDefault";
            this.m_cmdResetDefault.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdResetDefault.Size = new System.Drawing.Size(103, 24);
            this.m_cmdResetDefault.TabIndex = 10000049;
            this.m_cmdResetDefault.Tag = "1";
            this.m_cmdResetDefault.Text = "重置默认值(&R)";
            this.m_cmdResetDefault.Click += new System.EventHandler(this.m_cmdResetDefault_Click);
            // 
            // frmEMR_HIS_CheckRequisition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 551);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_dtpRecordDate);
            this.Controls.Add(this.m_cmdClose);
            this.Controls.Add(this.m_cmdAddTemplate);
            this.Controls.Add(this.m_cmdDelete);
            this.Controls.Add(this.m_cmdSave);
            this.Controls.Add(this.m_cmdAddCommonUse);
            this.Controls.Add(this.m_cmdSetDefault);
            this.Controls.Add(this.m_cmdResetDefault);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_lblInDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmEMR_HIS_CheckRequisition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "检查申请单";
            this.Load += new System.EventHandler(this.frmEMR_HIS_CheckRequisition_Load);
            this.Controls.SetChildIndex(this.m_lblInDate, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.m_cmdResetDefault, 0);
            this.Controls.SetChildIndex(this.m_cmdSetDefault, 0);
            this.Controls.SetChildIndex(this.m_cmdAddCommonUse, 0);
            this.Controls.SetChildIndex(this.m_cmdSave, 0);
            this.Controls.SetChildIndex(this.m_cmdDelete, 0);
            this.Controls.SetChildIndex(this.m_cmdAddTemplate, 0);
            this.Controls.SetChildIndex(this.m_cmdClose, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.m_dtpRecordDate, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker m_dtpRecordDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private com.digitalwave.controls.ctlRichTextBox m_txtAdmissionDiagnosis;
        private System.Windows.Forms.Label label7;
        private com.digitalwave.controls.ctlRichTextBox m_txtPhysExam;
        private System.Windows.Forms.Label label6;
        private com.digitalwave.controls.ctlRichTextBox m_txtCaseSummary;
        private PinkieControls.ButtonXP m_cmdSave;
        private PinkieControls.ButtonXP m_cmdClose;
        private PinkieControls.ButtonXP m_cmdDelete;
        private System.Windows.Forms.Label m_lblInDate;
        private System.ComponentModel.BackgroundWorker m_bgwGetRecord;
        private PinkieControls.ButtonXP m_cmdAddTemplate;
        private PinkieControls.ButtonXP m_cmdAddCommonUse;
        private PinkieControls.ButtonXP m_cmdSetDefault;
        private PinkieControls.ButtonXP m_cmdResetDefault;
    }
}