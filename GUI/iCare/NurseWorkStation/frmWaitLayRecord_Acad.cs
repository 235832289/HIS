
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
using com.digitalwave.clsGeneralNurseRecord_GXService;

namespace iCare
{
	/// <summary>
	/// 候产记录
	/// </summary>
	public class frmWaitLayRecord_Acad : iCare.frmRecordsBase
	{
		#region system define
		private System.Windows.Forms.Label label1;		
		private string m_strCurrentOpenDate = "";
		private string m_strCreateUserID = "";
		protected com.digitalwave.Utility.Controls.ctlTimePicker m_dtpCreateDate;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox m_txtDiseaseID;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcBloodPressure_chr;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcEmbryoLocation_chr;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcEmbryoHeart_chr;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcIntermission_chr;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcPersist_chr;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcIntensity_chr;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcPalaceMouth_chr;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcShow_chr;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcAnusCheck_chr;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcOther_chr;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcScrutator_chr;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcCaul_chr;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcBloodPressure2_chr;

		private System.Windows.Forms.DataGridTextBoxColumn m_dtcRecordDate_chr;
		private System.Windows.Forms.DataGridTextBoxColumn m_dtcTime_chr;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
			#endregion


		#region constructor
		public frmWaitLayRecord_Acad()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}
		#endregion

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWaitLayRecord_Acad));
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtDiseaseID = new System.Windows.Forms.TextBox();
            this.m_dtpCreateDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.m_dtcRecordDate_chr = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcTime_chr = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcBloodPressure_chr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcEmbryoLocation_chr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcEmbryoHeart_chr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcIntermission_chr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcPersist_chr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcIntensity_chr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcPalaceMouth_chr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcShow_chr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcAnusCheck_chr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcOther_chr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcScrutator_chr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcCaul_chr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcBloodPressure2_chr = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
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
																										 this.m_dtcBloodPressure_chr,
																										 this.m_dtcBloodPressure2_chr,
																										 this.m_dtcEmbryoLocation_chr,
																										 this.m_dtcEmbryoHeart_chr,
																										 this.m_dtcIntermission_chr,
																										 this.m_dtcPersist_chr,
																										 this.m_dtcIntensity_chr,
																										 this.m_dtcPalaceMouth_chr,
																										 this.m_dtcShow_chr,
																										 this.m_dtcCaul_chr,
																										 this.m_dtcAnusCheck_chr,
																										 this.m_dtcOther_chr,
																										 this.m_dtcScrutator_chr});
            this.dgtsStyles.RowHeaderWidth = 15;
            // 
            // m_dtgRecordDetail
            // 
            this.m_dtgRecordDetail.BackgroundColor = System.Drawing.SystemColors.AppWorkspace;
            this.m_dtgRecordDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_dtgRecordDetail.CaptionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.m_dtgRecordDetail.DataSource = this.m_dtbRecords;
            this.m_dtgRecordDetail.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_dtgRecordDetail.HeaderForeColor = System.Drawing.SystemColors.Window;
            this.m_dtgRecordDetail.Location = new System.Drawing.Point(10, 69);
            this.m_dtgRecordDetail.Size = new System.Drawing.Size(797, 547);
            this.m_dtgRecordDetail.Navigate += new System.Windows.Forms.NavigateEventHandler(this.m_dtgRecordDetail_Navigate);
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
            this.m_trvInPatientDate.Location = new System.Drawing.Point(169, 200);
            this.m_trvInPatientDate.Size = new System.Drawing.Size(176, 60);
            this.m_trvInPatientDate.Visible = false;
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(369, 256);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(290, 263);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(391, 256);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(391, 256);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(369, 260);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(391, 265);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(290, 266);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(358, 256);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(415, 230);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(351, 257);
            this.txtInPatientID.Size = new System.Drawing.Size(96, 23);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(317, 260);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(351, 257);
            this.m_txtBedNO.Size = new System.Drawing.Size(72, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(309, 257);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(279, 256);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(358, 266);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(279, 254);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.m_cmdNext.Location = new System.Drawing.Point(399, 256);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(361, 256);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(428, 259);
            this.m_lblForTitle.Size = new System.Drawing.Size(8, 23);
            this.m_lblForTitle.Visible = false;
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(359, 261);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(733, 36);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Controls.Add(this.label1);
            this.m_pnlNewBase.Controls.Add(this.m_txtDiseaseID);
            this.m_pnlNewBase.Controls.Add(this.m_dtpCreateDate);
            this.m_pnlNewBase.Controls.Add(this.label2);
            this.m_pnlNewBase.Size = new System.Drawing.Size(797, 60);
            this.m_pnlNewBase.Visible = true;
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_ctlPatientInfo, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.label2, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_dtpCreateDate, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_txtDiseaseID, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.label1, 0);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(795, 29);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(533, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 23);
            this.label1.TabIndex = 10000004;
            this.label1.Text = "孕/产次:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtDiseaseID
            // 
            this.m_txtDiseaseID.Location = new System.Drawing.Point(596, 32);
            this.m_txtDiseaseID.Name = "m_txtDiseaseID";
            this.m_txtDiseaseID.Size = new System.Drawing.Size(122, 23);
            this.m_txtDiseaseID.TabIndex = 10000005;
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.BorderColor = System.Drawing.Color.Black;
            this.m_dtpCreateDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpCreateDate.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_dtpCreateDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpCreateDate.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpCreateDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpCreateDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_dtpCreateDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpCreateDate.Location = new System.Drawing.Point(384, 32);
            this.m_dtpCreateDate.m_BlnOnlyTime = false;
            this.m_dtpCreateDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpCreateDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpCreateDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpCreateDate.Name = "m_dtpCreateDate";
            this.m_dtpCreateDate.ReadOnly = false;
            this.m_dtpCreateDate.Size = new System.Drawing.Size(144, 22);
            this.m_dtpCreateDate.TabIndex = 10000039;
            this.m_dtpCreateDate.TextBackColor = System.Drawing.Color.White;
            this.m_dtpCreateDate.TextForeColor = System.Drawing.Color.Black;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(326, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 10000004;
            this.label2.Text = "预产期:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_dtcRecordDate_chr
            // 
            this.m_dtcRecordDate_chr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcRecordDate_chr.Format = "";
            this.m_dtcRecordDate_chr.FormatInfo = null;
            this.m_dtcRecordDate_chr.MappingName = "RecordDate_chr";
            this.m_dtcRecordDate_chr.Width = 80;
            // 
            // m_dtcTime_chr
            // 
            this.m_dtcTime_chr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcTime_chr.Format = "";
            this.m_dtcTime_chr.FormatInfo = null;
            this.m_dtcTime_chr.MappingName = "Time_chr";
            this.m_dtcTime_chr.Width = 60;
            // 
            // m_dtcBloodPressure_chr
            // 
            this.m_dtcBloodPressure_chr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcBloodPressure_chr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcBloodPressure_chr.m_BlnGobleSet = true;
            this.m_dtcBloodPressure_chr.m_BlnUnderLineDST = false;
            this.m_dtcBloodPressure_chr.MappingName = "BloodPressure_chr";
            this.m_dtcBloodPressure_chr.Width = 75;
            // 
            // m_dtcEmbryoLocation_chr
            // 
            this.m_dtcEmbryoLocation_chr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcEmbryoLocation_chr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcEmbryoLocation_chr.m_BlnGobleSet = true;
            this.m_dtcEmbryoLocation_chr.m_BlnUnderLineDST = false;
            this.m_dtcEmbryoLocation_chr.MappingName = "EmbryoLocation_chr";
            this.m_dtcEmbryoLocation_chr.Width = 50;
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
            this.m_dtcShow_chr.Width = 80;
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
            // m_dtcOther_chr
            // 
            this.m_dtcOther_chr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcOther_chr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcOther_chr.m_BlnGobleSet = true;
            this.m_dtcOther_chr.m_BlnUnderLineDST = false;
            this.m_dtcOther_chr.MappingName = "Other_chr";
            this.m_dtcOther_chr.Width = 75;
            // 
            // m_dtcScrutator_chr
            // 
            this.m_dtcScrutator_chr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcScrutator_chr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcScrutator_chr.m_BlnGobleSet = true;
            this.m_dtcScrutator_chr.m_BlnUnderLineDST = false;
            this.m_dtcScrutator_chr.MappingName = "Scrutator_chr";
            this.m_dtcScrutator_chr.Width = 75;
            // 
            // m_dtcCaul_chr
            // 
            this.m_dtcCaul_chr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcCaul_chr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcCaul_chr.m_BlnGobleSet = true;
            this.m_dtcCaul_chr.m_BlnUnderLineDST = false;
            this.m_dtcCaul_chr.MappingName = "Caul_chr";
            this.m_dtcCaul_chr.Width = 75;
            // 
            // m_dtcBloodPressure2_chr
            // 
            this.m_dtcBloodPressure2_chr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcBloodPressure2_chr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcBloodPressure2_chr.m_BlnGobleSet = true;
            this.m_dtcBloodPressure2_chr.m_BlnUnderLineDST = false;
            this.m_dtcBloodPressure2_chr.MappingName = "BloodPressure2_chr";
            this.m_dtcBloodPressure2_chr.Width = 75;
            // 
            // frmWaitLayRecord_Acad
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(818, 657);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmWaitLayRecord_Acad";
            this.Text = "候产记录";
            this.Load += new System.EventHandler(this.frmWaitLayRecord_Acad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRecordDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtbRecords)).EndInit();
            this.m_pnlNewBase.ResumeLayout(false);
            this.m_pnlNewBase.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		protected override Font m_FntHeaderFont
		{
			get
			{
				return new System.Drawing.Font("SimSun", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			}
		}

		// 初始化具体表单的DataTable。(需要改动)
		// 注意，DataTable的第一个Column必须是存放记录时间的字符串，第二个Column必须是存放记录类型的int值，第三个Column必须是存放记录的OpenDate
		protected override void m_mthInitDataTable(DataTable p_dtbRecordTable)
		{

			//存放记录时间的字符串
			p_dtbRecordTable.Columns.Add("RecordDate");//0
			//存放记录类型的int值
			DataColumn dcRecordType = new DataColumn("RecordType",typeof(int));
			p_dtbRecordTable.Columns.Add(dcRecordType);//1
			//存放记录的OpenDate字符串
			p_dtbRecordTable.Columns.Add("OpenDate");  //2
			//存放记录的ModifyDate字符串
			p_dtbRecordTable.Columns.Add("ModifyDate"); //3

			DataColumn dc1 = p_dtbRecordTable.Columns.Add("RecordDate_chr");//4
			dc1.DefaultValue = "";
			DataColumn dc2 = p_dtbRecordTable.Columns.Add("Time_chr");//5
			dc2.DefaultValue = "";


//			p_dtbRecordTable.Columns.Add("RecordDate_chr",typeof(clsDSTRichTextBoxValue));//4
//			p_dtbRecordTable.Columns.Add("Time_chr",typeof(clsDSTRichTextBoxValue));//5
			p_dtbRecordTable.Columns.Add("BloodPressure_chr",typeof(clsDSTRichTextBoxValue));//6
					
			p_dtbRecordTable.Columns.Add("BloodPressure2_chr",typeof(clsDSTRichTextBoxValue));//6

			p_dtbRecordTable.Columns.Add("EmbryoLocation_chr",typeof(clsDSTRichTextBoxValue));//7
			p_dtbRecordTable.Columns.Add("EmbryoHeart_chr",typeof(clsDSTRichTextBoxValue));//8
			p_dtbRecordTable.Columns.Add("Intermission_chr",typeof(clsDSTRichTextBoxValue));//9
			p_dtbRecordTable.Columns.Add("Persist_chr",typeof(clsDSTRichTextBoxValue));//10
			p_dtbRecordTable.Columns.Add("Intensity_chr",typeof(clsDSTRichTextBoxValue));//11	
			p_dtbRecordTable.Columns.Add("PalaceMouth_chr",typeof(clsDSTRichTextBoxValue));//12
			p_dtbRecordTable.Columns.Add("Show_chr",typeof(clsDSTRichTextBoxValue));//13
			p_dtbRecordTable.Columns.Add("Caul_chr",typeof(clsDSTRichTextBoxValue));//14
			p_dtbRecordTable.Columns.Add("AnusCheck_chr",typeof(clsDSTRichTextBoxValue));//15
			p_dtbRecordTable.Columns.Add("Other_chr",typeof(clsDSTRichTextBoxValue));//16
			p_dtbRecordTable.Columns.Add("Scrutator_chr",typeof(clsDSTRichTextBoxValue));//17
			p_dtbRecordTable.Columns.Add("RecordSignID");


//			m_dtcGenaralInstance.m_RtbBase.m_BlnReadOnly = true;
			m_mthSetControl(m_dtcRecordDate_chr);
			m_mthSetControl(m_dtcTime_chr);

			m_mthSetControl(m_dtcBloodPressure_chr);
			m_mthSetControl(m_dtcBloodPressure2_chr);

			m_mthSetControl(m_dtcEmbryoLocation_chr);
			m_mthSetControl(m_dtcEmbryoHeart_chr);
			m_mthSetControl(m_dtcIntermission_chr);
			m_mthSetControl(m_dtcPersist_chr);
			m_mthSetControl(m_dtcIntensity_chr);
			m_mthSetControl(m_dtcPalaceMouth_chr);
			m_mthSetControl(m_dtcShow_chr);
			m_mthSetControl(m_dtcCaul_chr);
			m_mthSetControl(m_dtcAnusCheck_chr);
			m_mthSetControl(m_dtcOther_chr);
			m_mthSetControl(m_dtcScrutator_chr);
			//设置文字栏
			this.m_dtcRecordDate_chr.HeaderText = "日\r\n\r\n\r\n\r\n\r\n\r\n期";
			this.m_dtcTime_chr.HeaderText = "时\r\n\r\n\r\n\r\n\r\n\r\n间";
			this.m_dtcBloodPressure_chr.HeaderText = "舒\r\n张\r\n压\r\n\r\nmmHg";

			this.m_dtcBloodPressure2_chr.HeaderText = "收\r\n缩\r\n压\r\n\r\nmmHg";


			this.m_dtcEmbryoLocation_chr.HeaderText = "胎\r\n\r\n\r\n\r\n\r\n\r\n位";
			this.m_dtcEmbryoHeart_chr.HeaderText = "胎\r\n\r\n\r\n\r\n心\r\n\r\n(次/分)";
			this.m_dtcIntermission_chr.HeaderText = "宫\r\n\r\n缩\r\n\r\n间\r\n\r\n歇";
			this.m_dtcPersist_chr.HeaderText = "宫\r\n\r\n缩\r\n\r\n持\r\n\r\n续";
			this.m_dtcIntensity_chr.HeaderText = "宫\r\n\r\n缩\r\n\r\n强\r\n\r\n度";
			this.m_dtcPalaceMouth_chr.HeaderText = "宫\r\n\r\n\r\n\r\n\r\n\r\n口";
			this.m_dtcShow_chr.HeaderText = "先\r\n\r\n\r\n\r\n\r\n\r\n露";
			this.m_dtcCaul_chr.HeaderText = "胎\r\n\r\n\r\n\r\n\r\n\r\n膜";
			this.m_dtcAnusCheck_chr.HeaderText = "肛\r\n\r\n\r\n\r\n\r\n\r\n查";
			this.m_dtcOther_chr.HeaderText = "其\r\n\r\n\r\n\r\n\r\n\r\n它";
			this.m_dtcScrutator_chr.HeaderText = "检\r\n\r\n查\r\n\r\n者";
		

		}

		#region 属性
		/// <summary>
		/// 当前入院时间
		/// </summary>
		protected override string m_StrCurrentOpenDate
		{
			get
			{
				if(m_strCurrentOpenDate=="")
				{
					clsPublicFunction.ShowInformationMessageBox("请先选择记录");
					return "";
				}
				return m_strCurrentOpenDate;
			}
		}

		//(需要改动)
		protected override enmApproveType m_EnmAppType
		{
			get{return enmApproveType.Nurses;}
		}
		/// <summary>
		/// 记录者ID?
		/// </summary>
		protected override string m_StrRecorder_ID
		{
			get
			{
				return m_strCreateUserID;
			}
		}
		#endregion 属性

		//设置初始的比较日期
		private DateTime m_dtmPreRecordDate;
		// 清空特殊记录信息，并重置记录控制状态为不控制。
		protected override void m_mthClearRecordInfo()
		{			
			m_dtmPreRecordDate=DateTime.MinValue;
			m_dtgRecordDetail.CurrentRowIndex=0;
			m_dtbRecords.Rows.Clear();
		}

		/// <summary>
		/// 获取痕迹保留
		/// </summary>
		/// <param name="p_strText"></param>
		/// <param name="p_strModifyUserID"></param>
		/// <param name="p_strModifyUserName"></param>
		/// <returns></returns>
		private string m_strGetDSTTextXML(string p_strText,string p_strModifyUserID,string p_strModifyUserName)
		{
			return com.digitalwave.controls.ctlRichTextBox.clsXmlTool.s_strMakeDSTXml(p_strText,p_strModifyUserID,p_strModifyUserName,Color.Black,Color.White);
		}

		// 获取病程记录的领域层实例(需要改动)
		protected override clsRecordsDomain m_objGetRecordsDomain()
		{
            return new clsRecordsDomain(enmRecordsType.WaitLayRecord_Acad);
		}

		// 获取记录的主要信息（必须获取的是CreateDate,OpenDate,LastModifyDate）
		protected override clsTrackRecordContent m_objGetRecordMainContent(int p_intRecordType,
			object[] p_objDataArr)
		{
			//根据 p_intRecordType 获取对应的 clsTrackRecordContent
			clsTrackRecordContent objContent = null;
			//(需要改动)
			switch((enmDiseaseTrackType)p_intRecordType)
			{ 
				case enmDiseaseTrackType.WaitLayRecord_Acad:
					objContent = new clsIcuAcad_WaitLayRecord();//(需要改动)
					break;
			}

			if(objContent == null)
				objContent=new clsIcuAcad_WaitLayRecord();	//(需要改动)
		
			if(m_objCurrentPatient !=null)
				objContent.m_strInPatientID=m_objCurrentPatient.m_StrInPatientID;
			else 
			{
				clsPublicFunction.ShowInformationMessageBox("当前病人为空!");
				return null;
			}
			int intSelectedRecordStartRow =m_dtgRecordDetail.CurrentCell.RowNumber;
			objContent.m_strCreateUserID = (m_dtbRecords.Rows[intSelectedRecordStartRow][19]).ToString();
			objContent.m_dtmInPatientDate=m_objCurrentPatient.m_DtmSelectedInDate;
			objContent.m_dtmCreateDate = DateTime.Parse((string)p_objDataArr[0]);
			objContent.m_dtmOpenDate = DateTime.Parse((string)p_objDataArr[2]);
			objContent.m_dtmModifyDate = DateTime.Parse((string)p_objDataArr[3]);     

			
		
			return objContent;
		}

		private void frmWaitLayRecord_Acad_Load(object sender, System.EventArgs e)
		{
			m_dtmPreRecordDate = DateTime.MinValue;
			m_dtgRecordDetail.Focus();
			m_mniAddBlank.Visible=false;
			m_mniDeleteBlank.Visible=false;

            m_txtDiseaseID.ReadOnly = true;
            m_dtpCreateDate.ReadOnly = true;
		
		}

		#region 对产期与产次的处理

		private void m_mthget()
		{
			string p_strBEFOREHAND_CHR = "";
			string p_strLAYCOUNT_CHR = "";
			if(this.m_trvInPatientDate.SelectedNode != null)
			{
                string date = m_objCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss");
                string InPatientID = m_objCurrentPatient.m_StrEMRInPatientID;
                if (InPatientID != "")
                {
                    com.digitalwave.clsRecordsService.clsWaitLayRecord_AcadService domin =
                (com.digitalwave.clsRecordsService.clsWaitLayRecord_AcadService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsRecordsService.clsWaitLayRecord_AcadService));

                    domin.m_lngGetBEFOREHAND_CHR_LAYCOUNT_CHR(InPatientID, date, out p_strBEFOREHAND_CHR, out p_strLAYCOUNT_CHR);
                    m_txtDiseaseID.Text = p_strLAYCOUNT_CHR;  //产次
                    m_dtpCreateDate.Value = Convert.ToDateTime(p_strBEFOREHAND_CHR);
                }
			}
		}
		#endregion 
		// 获取处理（添加和修改）记录的窗体。
		protected override frmDiseaseTrackBase m_frmGetRecordForm(int p_intRecordType)
		{
			switch((enmDiseaseTrackType)p_intRecordType)
			{
				case enmDiseaseTrackType.WaitLayRecord_Acad://(需要改动)
					
				{
					frmWaitLayRecord_AcadCon frmwcon = new frmWaitLayRecord_AcadCon();
					frmwcon.m_dtmBEFOREHAND_CHR = m_dtpCreateDate.Value;
					frmwcon.m_strLAYCOUNT_CHR =  m_txtDiseaseID.Text;//产次
					frmwcon.m_setLaycout();
					return  frmwcon;//(需要改动)
					break;
				}
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
		protected override void m_mthGetDeactiveContent(DateTime p_dtmRecordDate,int p_intFormID)
		{			
			m_mthGetDeletedRecord(p_intFormID,p_dtmRecordDate);
		}

		protected override void m_mthModifyRecord(int p_intRecordType,
			DateTime p_dtmCreateRecordTime)
		{
			PrivilegeData.enmPrivilegeSF enmSF = (PrivilegeData.enmPrivilegeSF)Enum.Parse(typeof(PrivilegeData.enmPrivilegeSF),this.GetType().Name);
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(enmSF,PrivilegeData.enmPrivilegeOperation.AddOrModify))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return;
			}			
#endif
			//获取添加记录的窗体
			frmDiseaseTrackBase frmAddNewForm = m_frmGetRecordForm(p_intRecordType); 
			frmAddNewForm.m_mthSetDiseaseTrackInfo(m_objCurrentPatient,p_dtmCreateRecordTime);
		
			m_mthShowSubForm(frmAddNewForm,p_intRecordType,true);
		}

		protected override void m_mthClearPatientRecordInfo()
		{
			m_mthSetDataGridFirstRowFocus();
			m_dtgRecordDetail.CurrentRowIndex = 0;
			m_dtbRecords.Rows.Clear();
			//清空记录内容                       
			m_mthClearRecordInfo();
		}

		private void mniAppend_Click(object sender, System.EventArgs e)
		{
			PrivilegeData.enmPrivilegeSF enmSF = (PrivilegeData.enmPrivilegeSF)Enum.Parse(typeof(PrivilegeData.enmPrivilegeSF),this.GetType().Name);
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(enmSF,PrivilegeData.enmPrivilegeOperation.AddOrModify))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return;
			}			                 
#endif
			m_mthAddNewRecord((int)enmDiseaseTrackType.WaitLayRecord_Acad);//(需要改动)
		}

		protected override infPrintRecord m_objGetPrintTool()
		{			
			clsWaitLayRecord_AcadPrintTool pt = new clsWaitLayRecord_AcadPrintTool();
            //pt.m_strLaycount = m_txtDiseaseID.Text ;//产次
            //pt.m_strBirthDate = m_dtpCreateDate.Value.Date.ToShortDateString();
			return pt;
		}

		protected override object[][] m_objGetRecordsValueArr(clsTransDataInfo p_objTransDataInfo)
		{
			#region 显示记录到DataGrid
			try
			{

				#region 处理产次
				m_txtDiseaseID.Text = "";				
				m_dtpCreateDate.Value = System.DateTime.Now;
				#endregion

				if(p_objTransDataInfo == null)
					return null;

				object[] objData;
				ArrayList objReturnData=new ArrayList();

				clsIcuAcad_WaitLayContentDataInfo objICUInfo=new clsIcuAcad_WaitLayContentDataInfo();	//(需要改动)		
				clsDSTRichTextBoxValue objclsDSTRichTextBoxValue;
				string strText,strXml;

				objICUInfo = (clsIcuAcad_WaitLayContentDataInfo)p_objTransDataInfo;//(需要改动)

				if(objICUInfo.m_objRecordArr == null)
					return null;

				int intRecordCount = objICUInfo.m_objRecordArr.Length;
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

				for(int i=0; i<intRecordCount; i++)
				{
					objData = new object[20];   //(需要改动) DataTable的列数
					clsIcuAcad_WaitLayRecord objCurrent = objICUInfo.m_objRecordArr[i];//(需要改动)
					clsIcuAcad_WaitLayRecord objNext = new clsIcuAcad_WaitLayRecord();//下一条记录//(需要改动)
					if(i < intRecordCount-1)
						objNext = objICUInfo.m_objRecordArr[i+1];

					//如果该护理记录是修改前的记录且是在指定时间内修改的，修改者与创建者为同一人，则不显示
                    //if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strModifyUserID.Trim()==objCurrent.m_strCreateUserID.Trim())
                    //{
                    //    TimeSpan tsModify =  objNext.m_dtmModifyDate-objCurrent.m_dtmModifyDate;
                    //    if((int)tsModify.TotalHours < intCanModifyTime)
                    //        continue;
                    //}

                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                       && objNext.m_strModifyUserID.Trim() == objCurrent.m_strCreateUserID.Trim()
                       && objNext.m_dtmOpenDate == objCurrent.m_dtmOpenDate)
                    {
                        TimeSpan tsModify = objNext.m_dtmModifyDate - objCurrent.m_dtmModifyDate;
                        if ((int)tsModify.TotalHours < intCanModifyTime)
                        {
                            //blnPreIsHide = true;
                            continue;
                        }
                    }

					#region 存放关键字段
					if(objCurrent.m_dtmCreateDate!=DateTime.MinValue)
					{
						objData[0] = objCurrent.m_dtmCreateDate;//存放记录时间的字符串
						objData[1] = (int)enmRecordsType.WaitLayRecord_Acad;//存放记录类型的int值  //(需要改动)
						objData[2] = objCurrent.m_dtmOpenDate;//存放记录的OpenDate字符串
						objData[3] = objICUInfo.m_objRecordArr[objICUInfo.m_objRecordArr.Length-1].m_dtmModifyDate;//存放记录的ModifyDate字符串   
						
						 
						//同一个则只在第一行显示日期
						if(objCurrent.m_dtmRecordDate.Date.ToString() != m_dtmPreRecordDate.Date.ToString())//m_dtmRECORDDATE
						{
							objData[4] = objCurrent.m_dtmRecordDate.Date.ToString("yyyy-MM-dd") ;//日期字符串
						}
						//修改后带有痕迹的记录不再显示时间
						if(m_dtmPreRecordDate != objCurrent.m_dtmRecordDate)
							objData[5] = objCurrent.m_dtmRecordDate.ToString("HH:mm");//时间字符串
	
					}
					m_dtmPreRecordDate = objCurrent.m_dtmCreateDate;	
					#endregion ;

					
					//产次处理
					m_txtDiseaseID.Text = objCurrent.m_strLayCount_chr_RIGHT;
					if(objCurrent.m_strBeforehand_chr.Trim() != "")
					m_dtpCreateDate.Value = Convert.ToDateTime(objCurrent.m_strBeforehand_chr.ToString().Trim());
					//

					#region 存放单项信息
					//血压1
					strText = objCurrent.m_strBloodPressure_chr_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strBloodPressure_chr_RIGHT != objCurrent.m_strBloodPressure_chr_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strBloodPressure_chr_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[6] = objclsDSTRichTextBoxValue;//血压

					//血压2
					strText = objCurrent.m_strBloodPressure2_chr_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strBloodPressure2_chr_RIGHT != objCurrent.m_strBloodPressure2_chr_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strBloodPressure2_chr_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[7] = objclsDSTRichTextBoxValue;//血压

			
					//胎位
					strText = objCurrent.m_strEmbryoLocation_chr_RIGHT ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strEmbryoLocation_chr_RIGHT != objCurrent.m_strEmbryoLocation_chr_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strEmbryoLocation_chr_RIGHT,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[8] = objclsDSTRichTextBoxValue;//胎位

					//胎心
					strText = objCurrent.m_strEmbryoHeart_chr_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strEmbryoHeart_chr_RIGHT != objCurrent.m_strEmbryoHeart_chr_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strEmbryoHeart_chr_RIGHT,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[9] = objclsDSTRichTextBoxValue;//胎心

			
					//间歇
					strText = objCurrent.m_strIntermission_chr_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strIntermission_chr_RIGHT != objCurrent.m_strIntermission_chr_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strIntermission_chr_RIGHT,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[10] = objclsDSTRichTextBoxValue;//间歇
			
					//持续
					strText = objCurrent.m_strPersist_chr_RIGHT ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strPersist_chr_RIGHT != objCurrent.m_strPersist_chr_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strPersist_chr_RIGHT,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[11] = objclsDSTRichTextBoxValue;//持续

					//强度
					strText = objCurrent.m_strIntensity_RIGHT ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strIntensity_RIGHT != objCurrent.m_strIntensity_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strIntensity_RIGHT,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[12] = objclsDSTRichTextBoxValue;//

					//宫口
					strText = objCurrent.m_strPalaceMouth_chr_RIGHT ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strPalaceMouth_chr_RIGHT != objCurrent.m_strPalaceMouth_chr_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strPalaceMouth_chr_RIGHT,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[13] = objclsDSTRichTextBoxValue;//宫口

					//先露
					strText = objCurrent.m_strShow_chr_RIGHT  ;
					string strNextText = objNext.m_strShow_chr_RIGHT  ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && strNextText != strText)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(strText,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[14] = objclsDSTRichTextBoxValue;//

					//胎膜
					strText = objCurrent.m_strCaul_chr_RIGHT  ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strCaul_chr_RIGHT != objCurrent.m_strCaul_chr_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strCaul_chr_RIGHT,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[15] = objclsDSTRichTextBoxValue;//

					//肛查
					strText = objCurrent.m_strAnusCheck_chr_RIGHT ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strAnusCheck_chr_RIGHT != objCurrent.m_strAnusCheck_chr_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strAnusCheck_chr_RIGHT,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[16] = objclsDSTRichTextBoxValue;//

//					//其它
                    strText = objCurrent.m_strOther_chr_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strOther_chr_RIGHT != objCurrent.m_strOther_chr_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strOther_chr_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[17] = objclsDSTRichTextBoxValue;//

                    #region //其它
                    //string[] strGeneralInstanceArr = null;
                    //string[] strGeneralInstanceXMLArr = null;
                    //if(objCurrent.m_strOther_chr_RIGHT != null ||objCurrent.m_strOther_chr_RIGHT != "")
                    //{
                    //    string strGeneralInstance = objCurrent.m_strOther_chr_RIGHT;
                    //    string strGeneralInstanceXML = objCurrent.m_strOther_chrXML;
                    //    string[] strGeneralInstanceArrTemp;
                    //    string[] strGeneralInstanceXMLArrTemp;
                    //    //将病情记录分为20个字符一行。因第一行要空两格，故添加空字符串
                    //    com.digitalwave.controls.ctlRichTextBox.m_mthSplitXml(""+strGeneralInstance,strGeneralInstanceXML,4,out strGeneralInstanceArrTemp,out strGeneralInstanceXMLArrTemp);
						
                    //    if(objCurrent.m_strCreateUserID != null && objCurrent.m_strCreateUserID != "")
                    //    {
                    //        //							strGeneralInstanceArr = new string[strGeneralInstanceArrTemp.Length + 1];
                    //        //							strGeneralInstanceXMLArr = new string[strGeneralInstanceXMLArrTemp.Length + 1];
                    //        strGeneralInstanceArr = new string[strGeneralInstanceArrTemp.Length ];
                    //        strGeneralInstanceXMLArr = new string[strGeneralInstanceXMLArrTemp.Length ];
                    //        //							for(int j=0; j<strGeneralInstanceArr.Length-1; j++)
                    //        for(int j=0; j<strGeneralInstanceArr.Length; j++)
                    //        {
                    //            strGeneralInstanceArr[j] = strGeneralInstanceArrTemp[j];
                    //        }
                    //        //							strGeneralInstanceArr[strGeneralInstanceArr.Length-1] = "";//objCurrent.m_dtmCreateDate.ToString("yyyy-MM-dd")+"    "+objCurrent.m_strCreateUserName;
                    //        //							
                    //        //							strGeneralInstanceXMLArr[strGeneralInstanceXMLArr.Length-1] = "";
                    //        //							for(int j=0; j<strGeneralInstanceXMLArr.Length-1; j++)
                    //        for(int j=0; j<strGeneralInstanceXMLArr.Length; j++)
                    //        {
                    //            strGeneralInstanceXMLArr[j] = strGeneralInstanceXMLArrTemp[j];
                    //        }
                    //    }
                    //    else
                    //    {
                    //        strGeneralInstanceArr = strGeneralInstanceArrTemp;
                    //        strGeneralInstanceXMLArr = strGeneralInstanceXMLArrTemp;
                    //    }

                    //    strText = strGeneralInstanceArr[0];
                    //    strXml = strGeneralInstanceXMLArr[0];
                    //    objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
                    //    objclsDSTRichTextBoxValue.m_strText=strText;						
                    //    objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
                    //    objData[17] = objclsDSTRichTextBoxValue;
                    //}
                    #endregion 
                    // 检查着
					strText = objCurrent.m_strScrutator_chr_RIGHT ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strScrutator_chr_RIGHT != objCurrent.m_strScrutator_chr_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strScrutator_chr_RIGHT,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[18] = objclsDSTRichTextBoxValue;//

					#region bak
					//一般情况
//					string[] strGeneralInstanceArr = null;
//					string[] strGeneralInstanceXMLArr = null;
//					if(objCurrent.m_strGENERALINSTANCE_RIGHT != null ||objCurrent.m_strGENERALINSTANCE_RIGHT != "")
//					{
//						string strGeneralInstance = objCurrent.m_strGENERALINSTANCE_RIGHT;
//						string strGeneralInstanceXML = objCurrent.m_strGENERALINSTANCEXML;
//						string[] strGeneralInstanceArrTemp;
//						string[] strGeneralInstanceXMLArrTemp;
//						//将病情记录分为20个字符一行。因第一行要空两格，故添加空字符串
//						com.digitalwave.controls.ctlRichTextBox.m_mthSplitXml("    "+strGeneralInstance,strGeneralInstanceXML,16,out strGeneralInstanceArrTemp,out strGeneralInstanceXMLArrTemp);
//						
//						if(objCurrent.m_strCreateUserName != null && objCurrent.m_strCreateUserName != "")
//						{
//							strGeneralInstanceArr = new string[strGeneralInstanceArrTemp.Length + 1];
//							strGeneralInstanceXMLArr = new string[strGeneralInstanceXMLArrTemp.Length + 1];
//
//							for(int j=0; j<strGeneralInstanceArr.Length-1; j++)
//							{
//								strGeneralInstanceArr[j] = strGeneralInstanceArrTemp[j];
//							}
//							strGeneralInstanceArr[strGeneralInstanceArr.Length-1] = objCurrent.m_dtmCreateDate.ToString("yyyy-MM-dd")+"    "+objCurrent.m_strCreateUserName;
//							
//							strGeneralInstanceXMLArr[strGeneralInstanceXMLArr.Length-1] = "";
//							for(int j=0; j<strGeneralInstanceXMLArr.Length-1; j++)
//							{
//								strGeneralInstanceXMLArr[j] = strGeneralInstanceXMLArrTemp[j];
//							}
//						}
//						else
//						{
//							strGeneralInstanceArr = strGeneralInstanceArrTemp;
//							strGeneralInstanceXMLArr = strGeneralInstanceXMLArrTemp;
//						}
//
//						strText = strGeneralInstanceArr[0];
//						strXml = strGeneralInstanceXMLArr[0];
//						objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
//						objclsDSTRichTextBoxValue.m_strText=strText;						
//						objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
//						objData[16] = objclsDSTRichTextBoxValue;
//					}

//					objReturnData.Add(objData);
//					
//					if(strGeneralInstanceArr.Length > 1)
//					{
//						object[] objInstance = null;
//						for(int j=1; j<strGeneralInstanceArr.Length; j++)
//						{
//							objInstance = new object[17];
//							strText = strGeneralInstanceArr[j];
//							strXml = strGeneralInstanceXMLArr[j];
//							objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
//							objclsDSTRichTextBoxValue.m_strText=strText;						
//							objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
//							objInstance[16] = objclsDSTRichTextBoxValue;
//							objReturnData.Add(objInstance);
//						}
//					}
					#endregion
					objData[19] = objCurrent.m_strCreateUserID;
					objReturnData.Add(objData);

                    //if(strGeneralInstanceArr.Length > 1)
                    //{
                    //    object[] objInstance = null;
                    //    for(int j=1; j<strGeneralInstanceArr.Length; j++)
                    //    {
                    //        objInstance = new object[20];
                    //        strText = strGeneralInstanceArr[j];
                    //        strXml = strGeneralInstanceXMLArr[j];
                    //        objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
                    //        objclsDSTRichTextBoxValue.m_strText=strText;						
                    //        objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
                    //        objInstance[17] = objclsDSTRichTextBoxValue;
                    //        objData[19] = objCurrent.m_strCreateUserID;
                    //        objReturnData.Add(objInstance);
                    //    }
                    //}

					#endregion
				}
				object[][] m_objRe=new object[objReturnData.Count][];

				for(int m=0;m<objReturnData.Count ;m++)
					m_objRe[m]=(object[])objReturnData[m];
				return m_objRe;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message );
				return null;
			}
			#endregion
		}

		private void m_dtgRecordDetail_Navigate(object sender, System.Windows.Forms.NavigateEventArgs ne)
		{
		
		}
		protected override void m_trvInPatientDate_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			base.m_trvInPatientDate_AfterSelect(sender,e);
			if(m_trvInPatientDate.SelectedNode!=null)
			{
				if(m_trvInPatientDate.SelectedNode.Text.Trim() =="入院时间")
				{
					m_dtpCreateDate.Value = System.DateTime.Now;
					m_txtDiseaseID.Text = "";
				}
			}
		}
	}
}

