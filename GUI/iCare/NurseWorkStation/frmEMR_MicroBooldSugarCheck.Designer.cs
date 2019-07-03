namespace iCare
{
    partial class frmEMR_MicroBooldSugarCheck
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
            this.m_dtcRecordDate_chr = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcTime_chr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcResult_chr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcSign_chr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
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
																										 this.m_dtcResult_chr,
																										 this.m_dtcSign_chr});
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
            this.m_dtgRecordDetail.Location = new System.Drawing.Point(8, 73);
            this.m_dtgRecordDetail.Size = new System.Drawing.Size(804, 526);
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
            this.m_trvInPatientDate.Location = new System.Drawing.Point(236, 168);
            this.m_trvInPatientDate.Size = new System.Drawing.Size(176, 75);
            this.m_trvInPatientDate.Visible = false;
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(283, 149);
            this.lblSex.Size = new System.Drawing.Size(56, 22);
            this.lblSex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(372, 164);
            this.lblAge.Size = new System.Drawing.Size(89, 22);
            this.lblAge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(297, 208);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(327, 178);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(359, 164);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(316, 204);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(391, 140);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(217, 164);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(375, 164);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(135, 121);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(307, 195);
            this.txtInPatientID.Size = new System.Drawing.Size(126, 23);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(387, 152);
            this.m_txtPatientName.Size = new System.Drawing.Size(109, 23);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(300, 204);
            this.m_txtBedNO.Size = new System.Drawing.Size(91, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(246, 181);
            this.m_cboArea.Size = new System.Drawing.Size(145, 23);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(389, 149);
            this.m_lsvPatientName.Size = new System.Drawing.Size(135, 121);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(246, 140);
            this.m_lsvBedNO.Size = new System.Drawing.Size(135, 121);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(236, 238);
            this.m_cboDept.Size = new System.Drawing.Size(145, 23);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(243, 178);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(285, 181);
            this.m_cmdNewTemplate.Size = new System.Drawing.Size(98, 37);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.m_cmdNext.Location = new System.Drawing.Point(319, 198);
            this.m_cmdNext.Size = new System.Drawing.Size(28, 24);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(273, 181);
            this.m_cmdPre.Size = new System.Drawing.Size(28, 24);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(291, 191);
            this.m_lblForTitle.Size = new System.Drawing.Size(19, 27);
            this.m_lblForTitle.Visible = false;
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(46, 33);
            this.chkModifyWithoutMatk.Size = new System.Drawing.Size(103, 28);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(728, 36);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Size = new System.Drawing.Size(802, 60);
            this.m_pnlNewBase.Visible = true;
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(800, 29);
            // 
            // m_dtcRecordDate_chr
            // 
            this.m_dtcRecordDate_chr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcRecordDate_chr.Format = "";
            this.m_dtcRecordDate_chr.FormatInfo = null;
            this.m_dtcRecordDate_chr.MappingName = "RecordDate_Day";
            this.m_dtcRecordDate_chr.Width = -1;
            // 
            // m_dtcTime_chr
            // 
            this.m_dtcTime_chr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcTime_chr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcTime_chr.m_BlnGobleSet = true;
            this.m_dtcTime_chr.m_BlnUnderLineDST = false;
            this.m_dtcTime_chr.MappingName = "Time_chr";
            this.m_dtcTime_chr.Width = 280;
            // 
            // m_dtcResult_chr
            // 
            this.m_dtcResult_chr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcResult_chr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcResult_chr.m_BlnGobleSet = true;
            this.m_dtcResult_chr.m_BlnUnderLineDST = false;
            this.m_dtcResult_chr.MappingName = "Result_chr";
            this.m_dtcResult_chr.Width = 250;
            // 
            // m_dtcSign_chr
            // 
            this.m_dtcSign_chr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcSign_chr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcSign_chr.m_BlnGobleSet = true;
            this.m_dtcSign_chr.m_BlnUnderLineDST = false;
            this.m_dtcSign_chr.MappingName = "Sign_chr";
            this.m_dtcSign_chr.Width = 150;
            // 
            // frmEMR_MicroBooldSugarCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 632);
            this.Name = "frmEMR_MicroBooldSugarCheck";
            this.Text = "快速微量血糖检测记录表";
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRecordDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtbRecords)).EndInit();
            this.m_pnlNewBase.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridTextBoxColumn m_dtcRecordDate_chr;
        private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcTime_chr;
        private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcResult_chr;
        private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcSign_chr;
    }
}