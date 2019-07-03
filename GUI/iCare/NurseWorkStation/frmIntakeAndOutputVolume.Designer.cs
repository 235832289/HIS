namespace iCare
{
    partial class frmIntakeAndOutputVolume
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIntakeAndOutputVolume));
            this.m_dtcRecordDate_chr = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcSign_chr = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcRecordTime_vchr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcStool_vchr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcUrine_vchr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcGastricJuice_vchr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcBile_vchr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcIntestinalJuice_vchr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcChestFluid_vchr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcOtherOutput_vchr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcDrinkingWater_vchr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcFood_vchr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcTransfusion_vchr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcSugarWater_vchr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcSalineWater_vchr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcOtherIntake_vchr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRecordDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtbRecords)).BeginInit();
            this.m_pnlNewBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_dtgRecordDetail
            // 
            this.m_dtgRecordDetail.BackgroundColor = System.Drawing.SystemColors.AppWorkspace;
            this.m_dtgRecordDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_dtgRecordDetail.CaptionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.m_dtgRecordDetail.DataSource = this.m_dtbRecords;
            this.m_dtgRecordDetail.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_dtgRecordDetail.HeaderForeColor = System.Drawing.SystemColors.Window;
            this.m_dtgRecordDetail.Location = new System.Drawing.Point(6, 73);
            this.m_dtgRecordDetail.Size = new System.Drawing.Size(820, 528);
            this.m_dtgRecordDetail.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_dtgRecordDetail_MouseDown);
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
            this.m_trvInPatientDate.Location = new System.Drawing.Point(155, 170);
            this.m_trvInPatientDate.Size = new System.Drawing.Size(176, 75);
            this.m_trvInPatientDate.Visible = false;
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(254, 169);
            this.lblSex.Size = new System.Drawing.Size(56, 22);
            this.lblSex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(182, 174);
            this.lblAge.Size = new System.Drawing.Size(91, 22);
            this.lblAge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(193, 196);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(217, 189);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(568, 84);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(213, 211);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(206, 189);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(193, 218);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(1027, 135);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(135, 121);
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(155, 170);
            this.txtInPatientID.Size = new System.Drawing.Size(111, 23);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(613, 79);
            this.m_txtPatientName.Size = new System.Drawing.Size(118, 23);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(178, 196);
            this.m_txtBedNO.Size = new System.Drawing.Size(77, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(196, 235);
            this.m_cboArea.Size = new System.Drawing.Size(153, 23);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(196, 170);
            this.m_lsvPatientName.Size = new System.Drawing.Size(135, 121);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(196, 170);
            this.m_lsvBedNO.Size = new System.Drawing.Size(135, 121);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(178, 209);
            this.m_cboDept.Size = new System.Drawing.Size(153, 23);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(182, 206);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(316, 183);
            this.m_cmdNewTemplate.Size = new System.Drawing.Size(98, 37);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.m_cmdNext.Location = new System.Drawing.Point(238, 162);
            this.m_cmdNext.Size = new System.Drawing.Size(28, 24);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(196, 206);
            this.m_cmdPre.Size = new System.Drawing.Size(28, 24);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(237, 218);
            this.m_lblForTitle.Size = new System.Drawing.Size(19, 27);
            this.m_lblForTitle.Visible = false;
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(50, 23);
            this.chkModifyWithoutMatk.Size = new System.Drawing.Size(103, 28);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(731, 36);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Location = new System.Drawing.Point(6, 7);
            this.m_pnlNewBase.Size = new System.Drawing.Size(820, 60);
            this.m_pnlNewBase.Visible = true;
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(818, 29);
            // 
            // m_dtcRecordDate_chr
            // 
            this.m_dtcRecordDate_chr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcRecordDate_chr.Format = "";
            this.m_dtcRecordDate_chr.FormatInfo = null;
            this.m_dtcRecordDate_chr.MappingName = "RecordDate_Day";
            this.m_dtcRecordDate_chr.Width = 80;
            // 
            // m_dtcSign_chr
            // 
            this.m_dtcSign_chr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcSign_chr.Format = "";
            this.m_dtcSign_chr.FormatInfo = null;
            this.m_dtcSign_chr.MappingName = "Sign_chr";
            this.m_dtcSign_chr.Width = 120;
            // 
            // m_dtcRecordTime_vchr
            // 
            this.m_dtcRecordTime_vchr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcRecordTime_vchr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcRecordTime_vchr.m_BlnGobleSet = true;
            this.m_dtcRecordTime_vchr.m_BlnUnderLineDST = false;
            this.m_dtcRecordTime_vchr.MappingName = "RecordTime_vchr";
            this.m_dtcRecordTime_vchr.Width = 150;
            // 
            // m_dtcStool_vchr
            // 
            this.m_dtcStool_vchr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcStool_vchr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcStool_vchr.m_BlnGobleSet = true;
            this.m_dtcStool_vchr.m_BlnUnderLineDST = false;
            this.m_dtcStool_vchr.MappingName = "Stool_vchr";
            this.m_dtcStool_vchr.Width = 50;
            // 
            // m_dtcUrine_vchr
            // 
            this.m_dtcUrine_vchr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcUrine_vchr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcUrine_vchr.m_BlnGobleSet = true;
            this.m_dtcUrine_vchr.m_BlnUnderLineDST = false;
            this.m_dtcUrine_vchr.MappingName = "Urine_vchr";
            this.m_dtcUrine_vchr.Width = 50;
            // 
            // m_dtcGastricJuice_vchr
            // 
            this.m_dtcGastricJuice_vchr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcGastricJuice_vchr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcGastricJuice_vchr.m_BlnGobleSet = true;
            this.m_dtcGastricJuice_vchr.m_BlnUnderLineDST = false;
            this.m_dtcGastricJuice_vchr.MappingName = "GastricJuice_vchr";
            this.m_dtcGastricJuice_vchr.Width = 50;
            // 
            // m_dtcBile_vchr
            // 
            this.m_dtcBile_vchr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcBile_vchr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcBile_vchr.m_BlnGobleSet = true;
            this.m_dtcBile_vchr.m_BlnUnderLineDST = false;
            this.m_dtcBile_vchr.MappingName = "Bile_vchr";
            this.m_dtcBile_vchr.Width = 50;
            // 
            // m_dtcIntestinalJuice_vchr
            // 
            this.m_dtcIntestinalJuice_vchr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcIntestinalJuice_vchr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcIntestinalJuice_vchr.m_BlnGobleSet = true;
            this.m_dtcIntestinalJuice_vchr.m_BlnUnderLineDST = false;
            this.m_dtcIntestinalJuice_vchr.MappingName = "IntestinalJuice_vchr";
            this.m_dtcIntestinalJuice_vchr.Width = 50;
            // 
            // m_dtcChestFluid_vchr
            // 
            this.m_dtcChestFluid_vchr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcChestFluid_vchr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcChestFluid_vchr.m_BlnGobleSet = true;
            this.m_dtcChestFluid_vchr.m_BlnUnderLineDST = false;
            this.m_dtcChestFluid_vchr.MappingName = "ChestFluid_vchr";
            this.m_dtcChestFluid_vchr.Width = 50;
            // 
            // m_dtcOtherOutput_vchr
            // 
            this.m_dtcOtherOutput_vchr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcOtherOutput_vchr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcOtherOutput_vchr.m_BlnGobleSet = true;
            this.m_dtcOtherOutput_vchr.m_BlnUnderLineDST = false;
            this.m_dtcOtherOutput_vchr.MappingName = "OtherOutput_vchr";
            this.m_dtcOtherOutput_vchr.Width = 50;
            // 
            // m_dtcDrinkingWater_vchr
            // 
            this.m_dtcDrinkingWater_vchr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcDrinkingWater_vchr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcDrinkingWater_vchr.m_BlnGobleSet = true;
            this.m_dtcDrinkingWater_vchr.m_BlnUnderLineDST = false;
            this.m_dtcDrinkingWater_vchr.MappingName = "DrinkingWater_vchr";
            this.m_dtcDrinkingWater_vchr.Width = 50;
            // 
            // m_dtcFood_vchr
            // 
            this.m_dtcFood_vchr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcFood_vchr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcFood_vchr.m_BlnGobleSet = true;
            this.m_dtcFood_vchr.m_BlnUnderLineDST = false;
            this.m_dtcFood_vchr.MappingName = "Food_vchr";
            this.m_dtcFood_vchr.Width = 50;
            // 
            // m_dtcTransfusion_vchr
            // 
            this.m_dtcTransfusion_vchr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcTransfusion_vchr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcTransfusion_vchr.m_BlnGobleSet = true;
            this.m_dtcTransfusion_vchr.m_BlnUnderLineDST = false;
            this.m_dtcTransfusion_vchr.MappingName = "Transfusion_vchr";
            this.m_dtcTransfusion_vchr.Width = 50;
            // 
            // m_dtcSugarWater_vchr
            // 
            this.m_dtcSugarWater_vchr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcSugarWater_vchr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcSugarWater_vchr.m_BlnGobleSet = true;
            this.m_dtcSugarWater_vchr.m_BlnUnderLineDST = false;
            this.m_dtcSugarWater_vchr.MappingName = "SugarWater_vchr";
            this.m_dtcSugarWater_vchr.Width = 50;
            // 
            // m_dtcSalineWater_vchr
            // 
            this.m_dtcSalineWater_vchr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcSalineWater_vchr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcSalineWater_vchr.m_BlnGobleSet = true;
            this.m_dtcSalineWater_vchr.m_BlnUnderLineDST = false;
            this.m_dtcSalineWater_vchr.MappingName = "SalineWater_vchr";
            this.m_dtcSalineWater_vchr.Width = 50;
            // 
            // m_dtcOtherIntake_vchr
            // 
            this.m_dtcOtherIntake_vchr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcOtherIntake_vchr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcOtherIntake_vchr.m_BlnGobleSet = true;
            this.m_dtcOtherIntake_vchr.m_BlnUnderLineDST = false;
            this.m_dtcOtherIntake_vchr.MappingName = "OtherIntake_vchr";
            this.m_dtcOtherIntake_vchr.Width = 50;
            // 
            // frmIntakeAndOutputVolume
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 649);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmIntakeAndOutputVolume";
            this.Text = "出入量登记表";
            this.Load += new System.EventHandler(this.frmIntakeAndOutputVolume_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRecordDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtbRecords)).EndInit();
            this.m_pnlNewBase.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcRecordTime_vchr;
        private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcStool_vchr;
        private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcUrine_vchr;
        private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcGastricJuice_vchr;
        private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcBile_vchr;
        private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcIntestinalJuice_vchr;
        private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcChestFluid_vchr;
        private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcOtherOutput_vchr;
        private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcDrinkingWater_vchr;
        private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcFood_vchr;
        private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcTransfusion_vchr;
        private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcSugarWater_vchr;
        private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcSalineWater_vchr;
        private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcOtherIntake_vchr;
        private System.Windows.Forms.DataGridTextBoxColumn m_dtcRecordDate_chr;
        private System.Windows.Forms.DataGridTextBoxColumn m_dtcSign_chr;
        #endregion
    }
}