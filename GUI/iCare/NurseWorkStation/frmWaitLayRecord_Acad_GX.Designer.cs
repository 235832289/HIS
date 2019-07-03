namespace iCare
{
    partial class frmWaitLayRecord_Acad_GX
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWaitLayRecord_Acad_GX));
            this.m_dtpLayDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker();
            this.m_txtLayTimes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_dtcRecordDate_chr = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcTime_chr = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcBloodPressure = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcEmbryoHeart_chr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcIntermission_chr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcPersist_chr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcIntensity_chr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcPalaceMouth_chr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcShow_chr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcAnusCheck_chr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcRemark_chr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcScrutator_chr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcCaul_chr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRecordDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtbRecords)).BeginInit();
            this.m_pnlNewBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgtsStyles
            // 
            this.dgtsStyles.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																										 this.m_dtcRecordDate_chr,
																										 this.m_dtcTime_chr,
																										 this.m_dtcBloodPressure,
																										 this.m_dtcEmbryoHeart_chr,
																										 this.m_dtcIntermission_chr,
																										 this.m_dtcPersist_chr,
																										 this.m_dtcIntensity_chr,
																										 this.m_dtcPalaceMouth_chr,
																										 this.m_dtcShow_chr,
																										 this.m_dtcCaul_chr,
																										 this.m_dtcAnusCheck_chr,
																										 this.m_dtcRemark_chr,
                                                                                                         this.m_dtcScrutator_chr});
            this.dgtsStyles.RowHeaderWidth = 15;
            // 
            // m_dtgRecordDetail
            // 
            this.m_dtgRecordDetail.BackgroundColor = System.Drawing.SystemColors.AppWorkspace;
            this.m_dtgRecordDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_dtgRecordDetail.CaptionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.m_dtgRecordDetail.DataSource = this.m_dtbRecords;
            this.m_dtgRecordDetail.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_dtgRecordDetail.HeaderForeColor = System.Drawing.SystemColors.Window;
            this.m_dtgRecordDetail.Location = new System.Drawing.Point(12, 99);
            this.m_dtgRecordDetail.Size = new System.Drawing.Size(804, 506);
            // 
            // mniAppend
            // 
            this.mniAppend.Click += new System.EventHandler(this.mniAppend_Click);
            // 
            // m_trvInPatientDate
            // 
            this.m_trvInPatientDate.BackColor = System.Drawing.Color.White;
            this.m_trvInPatientDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_trvInPatientDate.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_trvInPatientDate.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_trvInPatientDate.LineColor = System.Drawing.Color.Black;
            this.m_trvInPatientDate.Location = new System.Drawing.Point(171, 167);
            this.m_trvInPatientDate.Size = new System.Drawing.Size(176, 75);
            this.m_trvInPatientDate.Visible = false;
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(533, 156);
            this.lblSex.Size = new System.Drawing.Size(56, 22);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(475, 169);
            this.lblAge.Size = new System.Drawing.Size(61, 22);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(389, 173);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(375, 190);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(460, 167);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(533, 147);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(507, 147);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(183, 138);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(1027, 135);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(135, 121);
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(386, 187);
            this.txtInPatientID.Size = new System.Drawing.Size(111, 23);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(478, 138);
            this.m_txtPatientName.Size = new System.Drawing.Size(135, 23);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(378, 181);
            this.m_txtBedNO.Size = new System.Drawing.Size(76, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(240, 138);
            this.m_cboArea.Size = new System.Drawing.Size(146, 23);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(555, 140);
            this.m_lsvPatientName.Size = new System.Drawing.Size(135, 121);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(392, 140);
            this.m_lsvBedNO.Size = new System.Drawing.Size(135, 121);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(234, 164);
            this.m_cboDept.Size = new System.Drawing.Size(146, 23);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(206, 164);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(491, 205);
            this.m_cmdNewTemplate.Size = new System.Drawing.Size(98, 37);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.m_cmdNext.Location = new System.Drawing.Point(426, 164);
            this.m_cmdNext.Size = new System.Drawing.Size(28, 24);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(136, 128);
            this.m_cmdPre.Size = new System.Drawing.Size(28, 24);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(209, 186);
            this.m_lblForTitle.Size = new System.Drawing.Size(19, 27);
            this.m_lblForTitle.Visible = false;
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(95, 167);
            this.chkModifyWithoutMatk.Size = new System.Drawing.Size(103, 28);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(730, 37);
            this.m_cmdModifyPatientInfo.Size = new System.Drawing.Size(69, 28);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Size = new System.Drawing.Size(805, 60);
            this.m_pnlNewBase.Visible = true;
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(803, 29);
            // 
            // m_dtpLayDate
            // 
            this.m_dtpLayDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_dtpLayDate.Location = new System.Drawing.Point(72, 70);
            this.m_dtpLayDate.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日;
            this.m_dtpLayDate.Mask = "0000年90月90日";
            this.m_dtpLayDate.Name = "m_dtpLayDate";
            this.m_dtpLayDate.Size = new System.Drawing.Size(146, 23);
            this.m_dtpLayDate.TabIndex = 10000005;
            this.m_dtpLayDate.ValidatingType = typeof(System.DateTime);
            // 
            // m_txtLayTimes
            // 
            this.m_txtLayTimes.Location = new System.Drawing.Point(312, 70);
            this.m_txtLayTimes.MaxLength = 25;
            this.m_txtLayTimes.Name = "m_txtLayTimes";
            this.m_txtLayTimes.Size = new System.Drawing.Size(111, 23);
            this.m_txtLayTimes.TabIndex = 10000042;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(245, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 10000040;
            this.label1.Text = "孕/产次:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 14);
            this.label2.TabIndex = 10000041;
            this.label2.Text = "预产期:";
            // 
            // m_dtcRecordDate_chr
            // 
            this.m_dtcRecordDate_chr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcRecordDate_chr.Format = "";
            this.m_dtcRecordDate_chr.FormatInfo = null;
            this.m_dtcRecordDate_chr.MappingName = "RecordDate_Day";
            this.m_dtcRecordDate_chr.Width = 80;
            // 
            // m_dtcTime_chr
            // 
            this.m_dtcTime_chr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcTime_chr.Format = "";
            this.m_dtcTime_chr.FormatInfo = null;
            this.m_dtcTime_chr.MappingName = "RecordDate_Time";
            this.m_dtcTime_chr.Width = 60;
            // 
            // m_dtcBloodPressure
            // 
            this.m_dtcBloodPressure.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcBloodPressure.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcBloodPressure.m_BlnGobleSet = true;
            this.m_dtcBloodPressure.m_BlnUnderLineDST = false;
            this.m_dtcBloodPressure.MappingName = "BloodPressure";
            this.m_dtcBloodPressure.Width = -1;
            // 
            // m_dtcEmbryoHeart_chr
            // 
            this.m_dtcEmbryoHeart_chr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcEmbryoHeart_chr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcEmbryoHeart_chr.m_BlnGobleSet = true;
            this.m_dtcEmbryoHeart_chr.m_BlnUnderLineDST = false;
            this.m_dtcEmbryoHeart_chr.MappingName = "EmbryoHeart_chr";
            this.m_dtcEmbryoHeart_chr.Width = 50;
            // 
            // m_dtcIntermission_chr
            // 
            this.m_dtcIntermission_chr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcIntermission_chr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcIntermission_chr.m_BlnGobleSet = true;
            this.m_dtcIntermission_chr.m_BlnUnderLineDST = false;
            this.m_dtcIntermission_chr.MappingName = "Intermission_chr";
            this.m_dtcIntermission_chr.Width = 50;
            // 
            // m_dtcPersist_chr
            // 
            this.m_dtcPersist_chr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcPersist_chr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcPersist_chr.m_BlnGobleSet = true;
            this.m_dtcPersist_chr.m_BlnUnderLineDST = false;
            this.m_dtcPersist_chr.MappingName = "Persist_chr";
            this.m_dtcPersist_chr.Width = 50;
            // 
            // m_dtcIntensity_chr
            // 
            this.m_dtcIntensity_chr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcIntensity_chr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcIntensity_chr.m_BlnGobleSet = true;
            this.m_dtcIntensity_chr.m_BlnUnderLineDST = false;
            this.m_dtcIntensity_chr.MappingName = "Intensity_chr";
            this.m_dtcIntensity_chr.Width = 50;
            // 
            // m_dtcPalaceMouth_chr
            // 
            this.m_dtcPalaceMouth_chr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcPalaceMouth_chr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcPalaceMouth_chr.m_BlnGobleSet = true;
            this.m_dtcPalaceMouth_chr.m_BlnUnderLineDST = false;
            this.m_dtcPalaceMouth_chr.MappingName = "PalaceMouth_chr";
            this.m_dtcPalaceMouth_chr.Width = 50;
            // 
            // m_dtcShow_chr
            // 
            this.m_dtcShow_chr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcShow_chr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcShow_chr.m_BlnGobleSet = true;
            this.m_dtcShow_chr.m_BlnUnderLineDST = false;
            this.m_dtcShow_chr.MappingName = "Show_chr";
            this.m_dtcShow_chr.Width = 50;
            // 
            // m_dtcAnusCheck_chr
            // 
            this.m_dtcAnusCheck_chr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcAnusCheck_chr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcAnusCheck_chr.m_BlnGobleSet = true;
            this.m_dtcAnusCheck_chr.m_BlnUnderLineDST = false;
            this.m_dtcAnusCheck_chr.MappingName = "AnusCheck_chr";
            this.m_dtcAnusCheck_chr.Width = 50;
            // 
            // m_dtcRemark_chr
            // 
            this.m_dtcRemark_chr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcRemark_chr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcRemark_chr.m_BlnGobleSet = true;
            this.m_dtcRemark_chr.m_BlnUnderLineDST = false;
            this.m_dtcRemark_chr.MappingName = "Remark_chr";
            this.m_dtcRemark_chr.Width = 200;
            // 
            // m_dtcScrutator_chr
            // 
            this.m_dtcScrutator_chr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcScrutator_chr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcScrutator_chr.m_BlnGobleSet = true;
            this.m_dtcScrutator_chr.m_BlnUnderLineDST = false;
            this.m_dtcScrutator_chr.MappingName = "Scrutator_chr";
            this.m_dtcScrutator_chr.Width = 200;
            // 
            // m_dtcCaul_chr
            // 
            this.m_dtcCaul_chr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcCaul_chr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcCaul_chr.m_BlnGobleSet = true;
            this.m_dtcCaul_chr.m_BlnUnderLineDST = false;
            this.m_dtcCaul_chr.MappingName = "Caul_chr";
            this.m_dtcCaul_chr.Width = 50;
            // 
            // frmWaitLayRecord_Acad_GX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 633);
            this.Controls.Add(this.m_dtpLayDate);
            this.Controls.Add(this.m_txtLayTimes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmWaitLayRecord_Acad_GX";
            this.Text = "产程记录";
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.m_dtgRecordDetail, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.m_txtLayTimes, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_trvInPatientDate, 0);
            this.Controls.SetChildIndex(this.m_dtpLayDate, 0);
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRecordDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtbRecords)).EndInit();
            this.m_pnlNewBase.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected com.digitalwave.Controls.ctlMaskedDateTimePicker m_dtpLayDate;
        private System.Windows.Forms.TextBox m_txtLayTimes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcBloodPressure;
        private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcEmbryoHeart_chr;
        private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcIntermission_chr;
        private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcPersist_chr;
        private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcIntensity_chr;
        private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcPalaceMouth_chr;
        private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcShow_chr;
        private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcAnusCheck_chr;
        private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcRemark_chr;
        private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcScrutator_chr;
        private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcCaul_chr;
        private System.Windows.Forms.DataGridTextBoxColumn m_dtcRecordDate_chr;
        private System.Windows.Forms.DataGridTextBoxColumn m_dtcTime_chr;
    }
}