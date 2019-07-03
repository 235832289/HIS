namespace iCare
{
    partial class frmSubDiseaseTrack_XJ
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        //private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        //private void InitializeComponent()
        //{
        //    this.components = new System.ComponentModel.Container();
        //    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        //    this.Text = "frmSubDiseaseTrack_XJ";
        //}

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSubDiseaseTrack_XJ));
            this.clmContent = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
          //  this.mniGeneralDisease = new System.Windows.Forms.MenuItem();
            this.mniHandOver = new System.Windows.Forms.MenuItem();
            this.mniTakeOver = new System.Windows.Forms.MenuItem();
           // this.mniConsultation = new System.Windows.Forms.MenuItem();
            this.mniConvey = new System.Windows.Forms.MenuItem();
            this.mniTurnIn = new System.Windows.Forms.MenuItem();
            this.mniDiseaseSummary = new System.Windows.Forms.MenuItem();
            //this.mniCheckRoom = new System.Windows.Forms.MenuItem();
            //this.mniCaseDiscuss = new System.Windows.Forms.MenuItem();
           // this.mniBeforeOperationDiscuss = new System.Windows.Forms.MenuItem();
           // this.mniDeadCaseDiscuss = new System.Windows.Forms.MenuItem();
           // this.mniDead = new System.Windows.Forms.MenuItem();
            //this.mniOutHospital = new System.Windows.Forms.MenuItem();
            //this.mniAfterOperation = new System.Windows.Forms.MenuItem();
            //this.mniSave = new System.Windows.Forms.MenuItem();
            this.mniFirstIllnessNote = new System.Windows.Forms.MenuItem();
           // this.mniSummaryBeforeOP = new System.Windows.Forms.MenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRecordDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtbRecords)).BeginInit();
            this.m_pnlNewBase.SuspendLayout();
            this.SuspendLayout();
            // dgtsStyles
            // 
            this.dgtsStyles.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																										 this.clmContent});
            this.dgtsStyles.RowHeaderWidth = 30;
            // 
            // 
            // m_dtgRecordDetail
            // 
            this.m_dtgRecordDetail.AccessibleName = "DataGrid";
            this.m_dtgRecordDetail.AccessibleRole = System.Windows.Forms.AccessibleRole.Table;
            this.m_dtgRecordDetail.AllowSorting = false;
            this.m_dtgRecordDetail.BackgroundColor = System.Drawing.SystemColors.Control;
            this.m_dtgRecordDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_dtgRecordDetail.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.m_dtgRecordDetail.DataSource = this.m_dtbRecords;
            this.m_dtgRecordDetail.GridLineColor = System.Drawing.Color.Black;
            this.m_dtgRecordDetail.Location = new System.Drawing.Point(5, 70);
            this.m_dtgRecordDetail.Size = new System.Drawing.Size(796, 562);
            // 
            // mniAppend
            // 
            this.mniAppend.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mniFirstIllnessNote,
            //this.mniGeneralDisease,
            this.mniTakeOver,
            this.mniHandOver,            
            //this.mniConsultation,
            this.mniConvey,
            this.mniTurnIn,
            this.mniDiseaseSummary});
           // this.mniCheckRoom,
           // this.mniCaseDiscuss,
            //this.mniBeforeOperationDiscuss,
           // this.mniDeadCaseDiscuss,
           // this.mniAfterOperation,
            //this.mniDead,
            //this.mniOutHospital,
           // this.mniSave,
            //this.mniSummaryBeforeOP
            //});
            // 
            // m_trvInPatientDate
            // 
            this.m_trvInPatientDate.BackColor = System.Drawing.Color.White;
            this.m_trvInPatientDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_trvInPatientDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_trvInPatientDate.ForeColor = System.Drawing.Color.Black;
            this.m_trvInPatientDate.ItemHeight = 18;
            this.m_trvInPatientDate.LineColor = System.Drawing.Color.Black;
            this.m_trvInPatientDate.Location = new System.Drawing.Point(232, 166);
            this.m_trvInPatientDate.Size = new System.Drawing.Size(164, 60);
            this.m_trvInPatientDate.Visible = false;
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(274, 161);
            this.lblSex.Size = new System.Drawing.Size(32, 19);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(309, 166);
            this.lblAge.Size = new System.Drawing.Size(40, 19);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(250, 166);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(250, 180);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(239, 159);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(309, 157);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(309, 195);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(229, 166);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(211, 166);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(92, 104);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(232, 150);
            this.txtInPatientID.Size = new System.Drawing.Size(92, 23);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(221, 154);
            this.m_txtPatientName.Size = new System.Drawing.Size(72, 23);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(203, 152);
            this.m_txtBedNO.Size = new System.Drawing.Size(68, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(221, 157);
            this.m_cboArea.Size = new System.Drawing.Size(116, 23);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(242, 130);
            this.m_lsvPatientName.Size = new System.Drawing.Size(72, 104);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(211, 130);
            this.m_lsvBedNO.Size = new System.Drawing.Size(92, 104);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(253, 186);
            this.m_cboDept.Size = new System.Drawing.Size(116, 23);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(208, 176);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(253, 166);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.m_cmdNext.Location = new System.Drawing.Point(256, 159);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(242, 152);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(253, 183);
            this.m_lblForTitle.Visible = false;
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(548, 41);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(722, 34);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Location = new System.Drawing.Point(4, 5);
            this.m_pnlNewBase.Size = new System.Drawing.Size(798, 60);
            this.m_pnlNewBase.Visible = true;
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(796, 29);
            // 
            // clmContent
            // 
            this.clmContent.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.clmContent.HeaderText = "记录内容";
            this.clmContent.m_BlnGobleSet = true;
            this.clmContent.m_BlnUnderLineDST = false;
            this.clmContent.MappingName = "clmContent";
            this.clmContent.NullText = "";
            this.clmContent.Width = 750;
            // 
            // mniGeneralDisease
            // 
            //this.mniGeneralDisease.Index = 1;
            //this.mniGeneralDisease.Text = "病程记录";
            //this.mniGeneralDisease.Click += new System.EventHandler(this.mniGeneralDisease_Click);
            // 
            // mniHandOver
            // 
            this.mniHandOver.Index = 1;
            this.mniHandOver.Text = "接班记录";
            this.mniHandOver.Click += new System.EventHandler(this.mniHandOver_Click);
            // 
            // mniTakeOver
            // 
            this.mniTakeOver.Index = 2;
            this.mniTakeOver.Text = "交班记录";
            this.mniTakeOver.Click += new System.EventHandler(this.mniTakeOver_Click);
            // 
            // mniConsultation
            // 
            //this.mniConsultation.Index = 4;
            //this.mniConsultation.Text = "会诊记录";
            //this.mniConsultation.Visible = false;
            //this.mniConsultation.Click += new System.EventHandler(this.mniConsultation_Click);
            // 
            // mniConvey
            // 
            this.mniConvey.Index = 3;
            this.mniConvey.Text = "转出记录";
            this.mniConvey.Click += new System.EventHandler(this.mniConvey_Click);
            // 
            // mniTurnIn
            // 
            this.mniTurnIn.Index = 4;
            this.mniTurnIn.Text = "转入记录";
            this.mniTurnIn.Click += new System.EventHandler(this.mniTurnIn_Click);
            // 
            // mniDiseaseSummary
            // 
            this.mniDiseaseSummary.Index = 5;
            this.mniDiseaseSummary.Text = "阶段小结";
            this.mniDiseaseSummary.Click += new System.EventHandler(this.mniDiseaseSummary_Click);
            // 
            // mniCheckRoom
            // 
            //this.mniCheckRoom.Index = 8;
            //this.mniCheckRoom.Text = "查房记录";
            //this.mniCheckRoom.Click += new System.EventHandler(this.menuCheckRoom_Click);
            // 
            // mniCaseDiscuss
            // 
            //this.mniCaseDiscuss.Index = 9;
            //this.mniCaseDiscuss.Text = "疑难病例讨论";
            //this.mniCaseDiscuss.Click += new System.EventHandler(this.mniCaseDiscuss_Click);
            // 
            // mniBeforeOperationDiscuss
            // 
            //this.mniBeforeOperationDiscuss.Index = 10;
            //this.mniBeforeOperationDiscuss.Text = "术前讨论";
            //this.mniBeforeOperationDiscuss.Click += new System.EventHandler(this.mniBeforeOperationDiscuss_Click);
            // 
            // mniDeadCaseDiscuss
            // 
            //this.mnideadcasediscuss.index = 11;
            //this.mnideadcasediscuss.text = "死亡病例讨论";
            //this.mniDeadCaseDiscuss.Click += new System.EventHandler(this.mniDeadCaseDiscuss_Click);
            // 
            // mniDead
            // 
            //this.mniDead.Index = 13;
            //this.mniDead.Text = "死亡记录";
            //this.mniDead.Click += new System.EventHandler(this.mniDead_Click);
            // 
            // mniOutHospital
            // 
            //this.mniOutHospital.Index = 14;
            //this.mniOutHospital.Text = "出院记录";
            //this.mniOutHospital.Visible = false;
            //this.mniOutHospital.Click += new System.EventHandler(this.mniOutHospital_Click);
            // 
            // mniAfterOperation
            // 
            //this.mniAfterOperation.Index = 12;
            //this.mniAfterOperation.Text = "手术后病程记录";
            //this.mniAfterOperation.Click += new System.EventHandler(this.mniAfterOperation_Click);
            // 
            // mniSave
            // 
            //this.mniSave.Index = 15;
            //this.mniSave.Text = "抢救记录";
            //this.mniSave.Click += new System.EventHandler(this.mniSave_Click);
            // 
            // mniFirstIllnessNote
            // 
            this.mniFirstIllnessNote.Index = 0;
            this.mniFirstIllnessNote.Text = "首次病程记录";
            this.mniFirstIllnessNote.Click += new System.EventHandler(this.mniFirstIllnessNote_Click);
            // 
            // mniSummaryBeforeOP
            // 
            //this.mniSummaryBeforeOP.Index = 16;
            //this.mniSummaryBeforeOP.Text = "术前小结";
            //this.mniSummaryBeforeOP.Click += new System.EventHandler(this.mniSummaryBeforeOP_Click);
            // 
            // frmSubDiseaseTrack
            // 
            this.AccessibleDescription = "主病程记录";
            this.AutoScroll = false;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(814, 673);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSubDiseaseTrack_XJ";
            this.Text = "病程记录";
            this.Load += new System.EventHandler(this.frmSubDiseaseTrack_XJ_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRecordDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtbRecords)).EndInit();
            this.m_pnlNewBase.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
    }
}