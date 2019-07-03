namespace iCare
{
    partial class frmAYQBabyAssessmentRecord
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
            if (disposing)
            {
                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        /// 
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.clmRecordDateofDay = new System.Windows.Forms.DataGridTextBoxColumn();
            this.clmCreateTime = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcFacecolor = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcRespiration = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcReaction = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcTakeFood = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcArmpitWet = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcDerm = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcAurigo = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcUmbilicalRegion = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcLimbActivity = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcStool = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcUrine = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.clmRecordSign = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_rboEspRecord = new com.digitalwave.controls.ctlRichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRecordDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtbRecords)).BeginInit();
            this.m_pnlNewBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgtsStyles
            // 
            this.dgtsStyles.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																										 this.clmRecordDateofDay,
																										 this.clmCreateTime,
																										 this.m_dtcFacecolor,
																										 this.m_dtcRespiration,
																										 this.m_dtcReaction,
																										 this.m_dtcTakeFood,
																										 this.m_dtcArmpitWet,
																										 this.m_dtcDerm,
                                                                                                         this.m_dtcAurigo,
                                                                                                         this.m_dtcUmbilicalRegion,
                                                                                                         this.m_dtcLimbActivity,
																										 this.m_dtcStool,
																										 this.m_dtcUrine,
																										 this.clmRecordSign,
																										 });
            this.dgtsStyles.RowHeaderWidth = 15;
            // 
            // m_dtgRecordDetail
            // 
            this.m_dtgRecordDetail.BackgroundColor = System.Drawing.SystemColors.AppWorkspace;
            this.m_dtgRecordDetail.DataSource = this.m_dtbRecords;
            this.m_dtgRecordDetail.Location = new System.Drawing.Point(15, 78);
            this.m_dtgRecordDetail.Size = new System.Drawing.Size(786, 344);
            // 
            // mniAppend
            // 
            this.mniAppend.Click += new System.EventHandler(this.mniAppend_Click);
            // 
            // m_trvInPatientDate
            // 
            this.m_trvInPatientDate.LineColor = System.Drawing.Color.Black;
            this.m_trvInPatientDate.Location = new System.Drawing.Point(80, 72);
            this.m_trvInPatientDate.Size = new System.Drawing.Size(228, 10);
            this.m_trvInPatientDate.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(90, 120);
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(544, 271);
            // 
            // m_cboDept
            // 
            this.m_cboDept.Visible = false;
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Location = new System.Drawing.Point(-12, 174);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(-12, 174);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(-1, 172);
            this.m_lblForTitle.Visible = false;
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(723, 37);
            this.m_cmdModifyPatientInfo.Size = new System.Drawing.Size(69, 26);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Size = new System.Drawing.Size(794, 60);
            this.m_pnlNewBase.Visible = true;
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(792, 29);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(10, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(795, 357);
            this.panel1.TabIndex = 10000006;
            // 
            // clmRecordDateofDay
            // 
            this.clmRecordDateofDay.Format = "";
            this.clmRecordDateofDay.FormatInfo = null;
            this.clmRecordDateofDay.MappingName = "RecordDateofDay";
            this.clmRecordDateofDay.Width = 80;
            // 
            // clmCreateTime
            // 
            this.clmCreateTime.Format = "";
            this.clmCreateTime.FormatInfo = null;
            this.clmCreateTime.MappingName = "RecordTime";
            this.clmCreateTime.Width = 60;
            // 
            // m_dtcFacecolor
            // 
            this.m_dtcFacecolor.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcFacecolor.m_BlnGobleSet = true;
            this.m_dtcFacecolor.m_BlnUnderLineDST = false;
            this.m_dtcFacecolor.MappingName = "Facecolor";
            this.m_dtcFacecolor.Width = 60;
            // 
            // m_dtcRespiration
            // 
            this.m_dtcRespiration.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcRespiration.m_BlnGobleSet = true;
            this.m_dtcRespiration.m_BlnUnderLineDST = false;
            this.m_dtcRespiration.MappingName = "Respiration";
            this.m_dtcRespiration.Width = 60;
            // 
            // m_dtcReaction
            // 
            this.m_dtcReaction.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcReaction.m_BlnGobleSet = true;
            this.m_dtcReaction.m_BlnUnderLineDST = false;
            this.m_dtcReaction.MappingName = "Reaction";
            this.m_dtcReaction.Width = 60;
            // 
            // m_dtcTakeFood
            // 
            this.m_dtcTakeFood.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcTakeFood.m_BlnGobleSet = true;
            this.m_dtcTakeFood.m_BlnUnderLineDST = false;
            this.m_dtcTakeFood.MappingName = "TakeFood";
            this.m_dtcTakeFood.Width = 60;
            // 
            // m_dtcArmpitWet
            // 
            this.m_dtcArmpitWet.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcArmpitWet.m_BlnGobleSet = true;
            this.m_dtcArmpitWet.m_BlnUnderLineDST = false;
            this.m_dtcArmpitWet.MappingName = "ArmpitWet";
            this.m_dtcArmpitWet.Width = 60;
            // 
            // m_dtcDerm
            // 
            this.m_dtcDerm.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcDerm.m_BlnGobleSet = true;
            this.m_dtcDerm.m_BlnUnderLineDST = false;
            this.m_dtcDerm.MappingName = "Derm";
            this.m_dtcDerm.Width = 60;
            // 
            // m_dtcAurigo
            // 
            this.m_dtcAurigo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcAurigo.m_BlnGobleSet = true;
            this.m_dtcAurigo.m_BlnUnderLineDST = false;
            this.m_dtcAurigo.MappingName = "Aurigo";
            this.m_dtcAurigo.Width = 60;
            // 
            // m_dtcUmbilicalRegion
            // 
            this.m_dtcUmbilicalRegion.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcUmbilicalRegion.m_BlnGobleSet = true;
            this.m_dtcUmbilicalRegion.m_BlnUnderLineDST = false;
            this.m_dtcUmbilicalRegion.MappingName = "UmbilicalRegion";
            this.m_dtcUmbilicalRegion.Width = 60;
            // 
            // m_dtcLimbActivity
            // 
            this.m_dtcLimbActivity.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcLimbActivity.m_BlnGobleSet = true;
            this.m_dtcLimbActivity.m_BlnUnderLineDST = false;
            this.m_dtcLimbActivity.MappingName = "LimbActivity";
            this.m_dtcLimbActivity.Width = 60;
            // 
            // m_dtcStool
            // 
            this.m_dtcStool.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcStool.m_BlnGobleSet = true;
            this.m_dtcStool.m_BlnUnderLineDST = false;
            this.m_dtcStool.MappingName = "Stool";
            this.m_dtcStool.Width = 60;
            // 
            // m_dtcUrine
            // 
            this.m_dtcUrine.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcUrine.m_BlnGobleSet = true;
            this.m_dtcUrine.m_BlnUnderLineDST = false;
            this.m_dtcUrine.MappingName = "Urine";
            this.m_dtcUrine.Width = 60;
            // 
            // clmRecordSign
            // 
            this.clmRecordSign.Format = "";
            this.clmRecordSign.FormatInfo = null;
            this.clmRecordSign.MappingName = "RecordSign";
            this.clmRecordSign.Width = 130;
            // 
            // m_rboEspRecord
            // 
            this.m_rboEspRecord.AccessibleDescription = "特殊记录";
            this.m_rboEspRecord.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_rboEspRecord.Location = new System.Drawing.Point(10, 457);
            this.m_rboEspRecord.m_BlnIgnoreUserInfo = true;
            this.m_rboEspRecord.m_BlnPartControl = false;
            this.m_rboEspRecord.m_BlnReadOnly = false;
            this.m_rboEspRecord.m_BlnUnderLineDST = false;
            this.m_rboEspRecord.m_ClrDST = System.Drawing.Color.Red;
            this.m_rboEspRecord.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_rboEspRecord.m_IntCanModifyTime = 500;
            this.m_rboEspRecord.m_IntPartControlLength = 0;
            this.m_rboEspRecord.m_IntPartControlStartIndex = 0;
            this.m_rboEspRecord.m_StrUserID = "";
            this.m_rboEspRecord.m_StrUserName = "";
            this.m_rboEspRecord.Name = "m_rboEspRecord";
            this.m_rboEspRecord.Size = new System.Drawing.Size(791, 129);
            this.m_rboEspRecord.TabIndex = 10000007;
            this.m_rboEspRecord.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 436);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 10000008;
            this.label1.Text = "特殊记录：";
            // 
            // frmAYQBabyAssessmentRecord
            // 
            this.ClientSize = new System.Drawing.Size(849, 645);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_rboEspRecord);
            this.Name = "frmAYQBabyAssessmentRecord";
            this.Text = "爱婴区婴儿评估表";
            this.Load += new System.EventHandler(this.frmAYQBabyAssessmentRecord_Load);
            this.Controls.SetChildIndex(this.m_rboEspRecord, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_trvInPatientDate, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_dtgRecordDetail, 0);
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRecordDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtbRecords)).EndInit();
            this.m_pnlNewBase.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private com.digitalwave.controls.ctlRichTextBox m_rboEspRecord;
        private System.Windows.Forms.Label label1;
    }
}
