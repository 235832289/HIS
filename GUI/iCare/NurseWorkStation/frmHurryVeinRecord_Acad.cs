
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
    /// 催产素静脉点滴观察表
	/// </summary>
	public class frmHurryVeinRecord_Acad : iCare.frmRecordsBase
	{
		#region system define
		private System.Windows.Forms.Label label1;		
		private string m_strCurrentOpenDate = "";
		private string m_strCreateUserID = "";
		private System.Windows.Forms.Label label2;

		private System.Windows.Forms.DataGridTextBoxColumn m_dtcRecordDate_chr;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DataGridTextBoxColumn m_dtcTime_chr;
		private PinkieControls.ButtonXP m_cmdSave;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.Label label45;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.Label label47;
		private System.Windows.Forms.Label label48;
		private System.Windows.Forms.Label label49;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.RadioButton m_rdb00;
		private System.Windows.Forms.RadioButton m_rdb10;
		private System.Windows.Forms.RadioButton m_rdb20;
		private System.Windows.Forms.RadioButton m_rdb30;
		private System.Windows.Forms.RadioButton m_rdb40;
		private System.Windows.Forms.RadioButton m_rdb01;
		private System.Windows.Forms.RadioButton m_rdb02;
		private System.Windows.Forms.RadioButton m_rdb03;
		private System.Windows.Forms.RadioButton m_rdb11;
		private System.Windows.Forms.RadioButton m_rdb21;
		private System.Windows.Forms.RadioButton m_rdb31;
		private System.Windows.Forms.RadioButton m_rdb41;
		private System.Windows.Forms.RadioButton m_rdb12;
		private System.Windows.Forms.RadioButton m_rdb22;
		private System.Windows.Forms.RadioButton m_rdb32;
		private System.Windows.Forms.RadioButton m_rdb42;
		private System.Windows.Forms.RadioButton m_rdb13;
		private System.Windows.Forms.RadioButton m_rdb23;
		private System.Windows.Forms.RadioButton m_rdb33;
		private System.Windows.Forms.RadioButton m_rdb43;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.TextBox m_txtLAYCOUNT_CHR;
		private System.Windows.Forms.TextBox m_txtPREGNANTWEEK_CHR;
		private System.Windows.Forms.TextBox m_txtSCORECOUNT_CHR;
		private System.Windows.Forms.TextBox m_txtUSECOUNT_CHR;
		private System.Windows.Forms.TextBox m_txtLAYWAY_CHR;
		private System.Windows.Forms.TextBox m_txtINDICATE_CHR;
		private System.Windows.Forms.TextBox m_txtDROPPINGCASE_CHR;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcCHROMA_CHR;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcDROPCOUNT_CHR;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcEMBRYOHEART_CHR;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcEXPAND_CHR;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcPRESENTATION_CHR;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcBLOODPRESSURE_CHR;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcSPECIALRECORD_CHR;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcSIGNATURE_CHR;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcPALACESHRINK_CHR;
		private System.Windows.Forms.GroupBox groupBox1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region constructor
		public frmHurryVeinRecord_Acad()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
	
	
		}
		#endregion


		#region 孕产等变量
		string date ;
		string InPatientID ;

		string	p_strlaycount_chr = "";
		string	p_strPregnantweek_chr = "";
		string	p_strScorecount_chr = "";
		string	p_strRdbneckexpand_chr = "";
		string	p_strRdbneckshink_chr = "";
		string	p_strRdbhighlow_chr = "";
		string	p_strRdbneckhard_chr = "";
		string	p_strDroppingcase_chr = "";
		string	p_strIndicate_chr = "";
		string	p_strUsecount_chr = "";
		string	p_strLayway_chr = "";
		string	p_strRdbnecklocation_chr = "";
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
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtUSECOUNT_CHR = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_dtcRecordDate_chr = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcCHROMA_CHR = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcDROPCOUNT_CHR = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcEMBRYOHEART_CHR = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcEXPAND_CHR = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcPRESENTATION_CHR = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcBLOODPRESSURE_CHR = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcSPECIALRECORD_CHR = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcSIGNATURE_CHR = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcPALACESHRINK_CHR = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_cmdSave = new PinkieControls.ButtonXP();
            this.m_txtLAYWAY_CHR = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_dtcTime_chr = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_txtLAYCOUNT_CHR = new System.Windows.Forms.TextBox();
            this.m_txtPREGNANTWEEK_CHR = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_txtSCORECOUNT_CHR = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_rdb00 = new System.Windows.Forms.RadioButton();
            this.m_rdb03 = new System.Windows.Forms.RadioButton();
            this.m_rdb02 = new System.Windows.Forms.RadioButton();
            this.m_rdb01 = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_rdb13 = new System.Windows.Forms.RadioButton();
            this.m_rdb12 = new System.Windows.Forms.RadioButton();
            this.m_rdb11 = new System.Windows.Forms.RadioButton();
            this.m_rdb10 = new System.Windows.Forms.RadioButton();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_rdb23 = new System.Windows.Forms.RadioButton();
            this.m_rdb22 = new System.Windows.Forms.RadioButton();
            this.m_rdb21 = new System.Windows.Forms.RadioButton();
            this.m_rdb20 = new System.Windows.Forms.RadioButton();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.m_rdb33 = new System.Windows.Forms.RadioButton();
            this.m_rdb32 = new System.Windows.Forms.RadioButton();
            this.m_rdb31 = new System.Windows.Forms.RadioButton();
            this.m_rdb30 = new System.Windows.Forms.RadioButton();
            this.label46 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.m_rdb43 = new System.Windows.Forms.RadioButton();
            this.m_rdb42 = new System.Windows.Forms.RadioButton();
            this.m_rdb41 = new System.Windows.Forms.RadioButton();
            this.m_rdb40 = new System.Windows.Forms.RadioButton();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.m_txtINDICATE_CHR = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.m_txtDROPPINGCASE_CHR = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRecordDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtbRecords)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgtsStyles
            // 
            this.dgtsStyles.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																										 this.m_dtcRecordDate_chr,
																										 this.m_dtcTime_chr,
																										 this.m_dtcCHROMA_CHR,
																										 this.m_dtcDROPCOUNT_CHR,
																										 this.m_dtcPALACESHRINK_CHR,
																										 this.m_dtcEMBRYOHEART_CHR,
																										 this.m_dtcEXPAND_CHR,
																										 this.m_dtcPRESENTATION_CHR,
																										 this.m_dtcBLOODPRESSURE_CHR,
																										 this.m_dtcSPECIALRECORD_CHR,
																										 this.m_dtcSIGNATURE_CHR});
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
            this.m_dtgRecordDetail.Location = new System.Drawing.Point(8, 341);
            this.m_dtgRecordDetail.RowHeaderWidth = 15;
            this.m_dtgRecordDetail.Size = new System.Drawing.Size(752, 283);
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
            this.m_trvInPatientDate.Location = new System.Drawing.Point(8, 8);
            this.m_trvInPatientDate.Size = new System.Drawing.Size(176, 60);
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(580, 50);
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(676, 50);
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(401, 20);
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(386, 52);
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(540, 20);
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(540, 52);
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(636, 52);
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(189, 52);
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(442, 48);
            this.txtInPatientID.Size = new System.Drawing.Size(96, 23);
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(588, 16);
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(442, 16);
            this.m_txtBedNO.Size = new System.Drawing.Size(72, 23);
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(237, 48);
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(237, 16);
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(189, 20);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.m_cmdNext.Location = new System.Drawing.Point(514, 17);
            this.m_cmdNext.Visible = true;
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(434, 16);
            this.m_lblForTitle.Size = new System.Drawing.Size(8, 23);
            this.m_lblForTitle.Visible = false;
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(552, 47);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(714, 8);
            this.m_cmdModifyPatientInfo.Size = new System.Drawing.Size(34, 38);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(40, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 10000004;
            this.label1.Text = "催产素使用总量:";
            // 
            // m_txtUSECOUNT_CHR
            // 
            this.m_txtUSECOUNT_CHR.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtUSECOUNT_CHR.Location = new System.Drawing.Point(148, 232);
            this.m_txtUSECOUNT_CHR.MaxLength = 10;
            this.m_txtUSECOUNT_CHR.Name = "m_txtUSECOUNT_CHR";
            this.m_txtUSECOUNT_CHR.Size = new System.Drawing.Size(120, 21);
            this.m_txtUSECOUNT_CHR.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(492, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 10000004;
            this.label2.Text = "孕/产:";
            // 
            // m_dtcRecordDate_chr
            // 
            this.m_dtcRecordDate_chr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcRecordDate_chr.Format = "";
            this.m_dtcRecordDate_chr.FormatInfo = null;
            this.m_dtcRecordDate_chr.MappingName = "RecordDate_chr";
            this.m_dtcRecordDate_chr.Width = 80;
            // 
            // m_dtcCHROMA_CHR
            // 
            this.m_dtcCHROMA_CHR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcCHROMA_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcCHROMA_CHR.m_BlnGobleSet = true;
            this.m_dtcCHROMA_CHR.m_BlnUnderLineDST = false;
            this.m_dtcCHROMA_CHR.MappingName = "CHROMA_CHR";
            this.m_dtcCHROMA_CHR.Width = 60;
            // 
            // m_dtcDROPCOUNT_CHR
            // 
            this.m_dtcDROPCOUNT_CHR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcDROPCOUNT_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcDROPCOUNT_CHR.m_BlnGobleSet = true;
            this.m_dtcDROPCOUNT_CHR.m_BlnUnderLineDST = false;
            this.m_dtcDROPCOUNT_CHR.MappingName = "DROPCOUNT_CHR";
            this.m_dtcDROPCOUNT_CHR.Width = 60;
            // 
            // m_dtcEMBRYOHEART_CHR
            // 
            this.m_dtcEMBRYOHEART_CHR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcEMBRYOHEART_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcEMBRYOHEART_CHR.m_BlnGobleSet = true;
            this.m_dtcEMBRYOHEART_CHR.m_BlnUnderLineDST = false;
            this.m_dtcEMBRYOHEART_CHR.MappingName = "EMBRYOHEART_CHR";
            this.m_dtcEMBRYOHEART_CHR.Width = 60;
            // 
            // m_dtcEXPAND_CHR
            // 
            this.m_dtcEXPAND_CHR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcEXPAND_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcEXPAND_CHR.m_BlnGobleSet = true;
            this.m_dtcEXPAND_CHR.m_BlnUnderLineDST = false;
            this.m_dtcEXPAND_CHR.MappingName = "EXPAND_CHR";
            this.m_dtcEXPAND_CHR.Width = 60;
            // 
            // m_dtcPRESENTATION_CHR
            // 
            this.m_dtcPRESENTATION_CHR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcPRESENTATION_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcPRESENTATION_CHR.m_BlnGobleSet = true;
            this.m_dtcPRESENTATION_CHR.m_BlnUnderLineDST = false;
            this.m_dtcPRESENTATION_CHR.MappingName = "PRESENTATION_CHR";
            this.m_dtcPRESENTATION_CHR.Width = 60;
            // 
            // m_dtcBLOODPRESSURE_CHR
            // 
            this.m_dtcBLOODPRESSURE_CHR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcBLOODPRESSURE_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcBLOODPRESSURE_CHR.m_BlnGobleSet = true;
            this.m_dtcBLOODPRESSURE_CHR.m_BlnUnderLineDST = false;
            this.m_dtcBLOODPRESSURE_CHR.MappingName = "BLOODPRESSURE_CHR";
            this.m_dtcBLOODPRESSURE_CHR.Width = 60;
            // 
            // m_dtcSPECIALRECORD_CHR
            // 
            this.m_dtcSPECIALRECORD_CHR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcSPECIALRECORD_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcSPECIALRECORD_CHR.m_BlnGobleSet = true;
            this.m_dtcSPECIALRECORD_CHR.m_BlnUnderLineDST = false;
            this.m_dtcSPECIALRECORD_CHR.MappingName = "SPECIALRECORD_CHR";
            this.m_dtcSPECIALRECORD_CHR.Width = 110;
            // 
            // m_dtcSIGNATURE_CHR
            // 
            this.m_dtcSIGNATURE_CHR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcSIGNATURE_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcSIGNATURE_CHR.m_BlnGobleSet = true;
            this.m_dtcSIGNATURE_CHR.m_BlnUnderLineDST = false;
            this.m_dtcSIGNATURE_CHR.MappingName = "SIGNATURE_CHR";
            this.m_dtcSIGNATURE_CHR.Width = 80;
            // 
            // m_dtcPALACESHRINK_CHR
            // 
            this.m_dtcPALACESHRINK_CHR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcPALACESHRINK_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcPALACESHRINK_CHR.m_BlnGobleSet = true;
            this.m_dtcPALACESHRINK_CHR.m_BlnUnderLineDST = false;
            this.m_dtcPALACESHRINK_CHR.MappingName = "PALACESHRINK_CHR";
            this.m_dtcPALACESHRINK_CHR.Width = 75;
            // 
            // m_cmdSave
            // 
            this.m_cmdSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdSave.DefaultScheme = true;
            this.m_cmdSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSave.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdSave.Hint = "";
            this.m_cmdSave.Location = new System.Drawing.Point(664, 236);
            this.m_cmdSave.Name = "m_cmdSave";
            this.m_cmdSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSave.Size = new System.Drawing.Size(80, 28);
            this.m_cmdSave.TabIndex = 10000042;
            this.m_cmdSave.Tag = "1";
            this.m_cmdSave.Text = "保存";
            this.m_cmdSave.Click += new System.EventHandler(this.m_cmdSave_Click);
            // 
            // m_txtLAYWAY_CHR
            // 
            this.m_txtLAYWAY_CHR.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtLAYWAY_CHR.Location = new System.Drawing.Point(364, 232);
            this.m_txtLAYWAY_CHR.MaxLength = 100;
            this.m_txtLAYWAY_CHR.Name = "m_txtLAYWAY_CHR";
            this.m_txtLAYWAY_CHR.Size = new System.Drawing.Size(120, 21);
            this.m_txtLAYWAY_CHR.TabIndex = 30;
            this.m_txtLAYWAY_CHR.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(272, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 10000008;
            this.label4.Text = "分娩方式:";
            // 
            // m_dtcTime_chr
            // 
            this.m_dtcTime_chr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcTime_chr.Format = "";
            this.m_dtcTime_chr.FormatInfo = null;
            this.m_dtcTime_chr.MappingName = "Time_chr";
            this.m_dtcTime_chr.Width = 45;
            // 
            // m_txtLAYCOUNT_CHR
            // 
            this.m_txtLAYCOUNT_CHR.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtLAYCOUNT_CHR.Location = new System.Drawing.Point(536, 212);
            this.m_txtLAYCOUNT_CHR.MaxLength = 50;
            this.m_txtLAYCOUNT_CHR.Name = "m_txtLAYCOUNT_CHR";
            this.m_txtLAYCOUNT_CHR.Size = new System.Drawing.Size(120, 21);
            this.m_txtLAYCOUNT_CHR.TabIndex = 10000005;
            // 
            // m_txtPREGNANTWEEK_CHR
            // 
            this.m_txtPREGNANTWEEK_CHR.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPREGNANTWEEK_CHR.Location = new System.Drawing.Point(536, 240);
            this.m_txtPREGNANTWEEK_CHR.MaxLength = 50;
            this.m_txtPREGNANTWEEK_CHR.Name = "m_txtPREGNANTWEEK_CHR";
            this.m_txtPREGNANTWEEK_CHR.Size = new System.Drawing.Size(120, 21);
            this.m_txtPREGNANTWEEK_CHR.TabIndex = 10000007;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(496, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 10000006;
            this.label3.Text = "孕周:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(32, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 12);
            this.label5.TabIndex = 10000008;
            this.label5.Text = "BiShop宫颈成熟度评分:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(548, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 12);
            this.label6.TabIndex = 10000009;
            this.label6.Text = "累积评分共计:";
            // 
            // m_txtSCORECOUNT_CHR
            // 
            this.m_txtSCORECOUNT_CHR.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSCORECOUNT_CHR.Location = new System.Drawing.Point(644, 12);
            this.m_txtSCORECOUNT_CHR.MaxLength = 10;
            this.m_txtSCORECOUNT_CHR.Name = "m_txtSCORECOUNT_CHR";
            this.m_txtSCORECOUNT_CHR.Size = new System.Drawing.Size(72, 21);
            this.m_txtSCORECOUNT_CHR.TabIndex = 10000010;
            this.m_txtSCORECOUNT_CHR.Text = "0";
            this.m_txtSCORECOUNT_CHR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(720, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 10000011;
            this.label7.Text = "分";
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Location = new System.Drawing.Point(16, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(152, 24);
            this.label8.TabIndex = 10000012;
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label16.Location = new System.Drawing.Point(164, 36);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(144, 24);
            this.label16.TabIndex = 10000020;
            this.label16.Text = "0";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label17.Location = new System.Drawing.Point(308, 36);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(144, 24);
            this.label17.TabIndex = 10000021;
            this.label17.Text = "1";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label18.Location = new System.Drawing.Point(452, 36);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(144, 24);
            this.label18.TabIndex = 10000022;
            this.label18.Text = "2";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label19.Location = new System.Drawing.Point(596, 36);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(144, 24);
            this.label19.TabIndex = 10000023;
            this.label19.Text = "3";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(16, 60);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(152, 30);
            this.label13.TabIndex = 10000024;
            this.label13.Text = "宫颈张(CM)";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label22.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.Location = new System.Drawing.Point(16, 88);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(152, 30);
            this.label22.TabIndex = 10000029;
            this.label22.Text = "宫颈缩(%)";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label27
            // 
            this.label27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label27.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label27.Location = new System.Drawing.Point(16, 116);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(152, 30);
            this.label27.TabIndex = 10000034;
            this.label27.Text = "先露高低(CM)";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label32
            // 
            this.label32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label32.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label32.Location = new System.Drawing.Point(16, 144);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(152, 30);
            this.label32.TabIndex = 10000039;
            this.label32.Text = "宫颈硬度";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label37
            // 
            this.label37.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label37.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label37.Location = new System.Drawing.Point(16, 172);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(152, 30);
            this.label37.TabIndex = 10000044;
            this.label37.Text = "宫颈位置";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_rdb00);
            this.panel1.Controls.Add(this.m_rdb03);
            this.panel1.Controls.Add(this.m_rdb02);
            this.panel1.Controls.Add(this.m_rdb01);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Location = new System.Drawing.Point(164, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(576, 32);
            this.panel1.TabIndex = 10000050;
            // 
            // m_rdb00
            // 
            this.m_rdb00.Checked = true;
            this.m_rdb00.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_rdb00.Location = new System.Drawing.Point(48, 4);
            this.m_rdb00.Name = "m_rdb00";
            this.m_rdb00.Size = new System.Drawing.Size(56, 24);
            this.m_rdb00.TabIndex = 10000053;
            this.m_rdb00.TabStop = true;
            this.m_rdb00.Tag = "0";
            this.m_rdb00.Text = "未开";
            // 
            // m_rdb03
            // 
            this.m_rdb03.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_rdb03.Location = new System.Drawing.Point(480, 8);
            this.m_rdb03.Name = "m_rdb03";
            this.m_rdb03.Size = new System.Drawing.Size(56, 16);
            this.m_rdb03.TabIndex = 10000056;
            this.m_rdb03.Tag = "3";
            this.m_rdb03.Text = ">=5";
            this.m_rdb03.CheckedChanged += new System.EventHandler(this.m_rdbBodyRuddy_CheckedChanged);
            // 
            // m_rdb02
            // 
            this.m_rdb02.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_rdb02.Location = new System.Drawing.Point(336, 8);
            this.m_rdb02.Name = "m_rdb02";
            this.m_rdb02.Size = new System.Drawing.Size(56, 16);
            this.m_rdb02.TabIndex = 10000055;
            this.m_rdb02.Tag = "2";
            this.m_rdb02.Text = "3-4";
            this.m_rdb02.CheckedChanged += new System.EventHandler(this.m_rdbBodyRuddy_CheckedChanged);
            // 
            // m_rdb01
            // 
            this.m_rdb01.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_rdb01.Location = new System.Drawing.Point(200, 8);
            this.m_rdb01.Name = "m_rdb01";
            this.m_rdb01.Size = new System.Drawing.Size(56, 16);
            this.m_rdb01.TabIndex = 10000054;
            this.m_rdb01.Tag = "1";
            this.m_rdb01.Text = "1-2";
            this.m_rdb01.CheckedChanged += new System.EventHandler(this.m_rdbBodyRuddy_CheckedChanged);
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(144, 30);
            this.label12.TabIndex = 10000050;
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Location = new System.Drawing.Point(144, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(144, 30);
            this.label11.TabIndex = 10000026;
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Location = new System.Drawing.Point(288, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(144, 30);
            this.label10.TabIndex = 10000027;
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Location = new System.Drawing.Point(432, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(144, 30);
            this.label9.TabIndex = 10000028;
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_rdb13);
            this.panel2.Controls.Add(this.m_rdb12);
            this.panel2.Controls.Add(this.m_rdb11);
            this.panel2.Controls.Add(this.m_rdb10);
            this.panel2.Controls.Add(this.label38);
            this.panel2.Controls.Add(this.label39);
            this.panel2.Controls.Add(this.label40);
            this.panel2.Controls.Add(this.label41);
            this.panel2.Location = new System.Drawing.Point(164, 88);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(576, 32);
            this.panel2.TabIndex = 10000051;
            // 
            // m_rdb13
            // 
            this.m_rdb13.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_rdb13.Location = new System.Drawing.Point(480, 8);
            this.m_rdb13.Name = "m_rdb13";
            this.m_rdb13.Size = new System.Drawing.Size(56, 16);
            this.m_rdb13.TabIndex = 10000057;
            this.m_rdb13.Tag = "3";
            this.m_rdb13.Text = ">=80";
            this.m_rdb13.CheckedChanged += new System.EventHandler(this.m_rdbBodyRuddy_CheckedChanged);
            // 
            // m_rdb12
            // 
            this.m_rdb12.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_rdb12.Location = new System.Drawing.Point(336, 8);
            this.m_rdb12.Name = "m_rdb12";
            this.m_rdb12.Size = new System.Drawing.Size(64, 16);
            this.m_rdb12.TabIndex = 10000056;
            this.m_rdb12.Tag = "2";
            this.m_rdb12.Text = "40-50";
            this.m_rdb12.CheckedChanged += new System.EventHandler(this.m_rdbBodyRuddy_CheckedChanged);
            // 
            // m_rdb11
            // 
            this.m_rdb11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_rdb11.Location = new System.Drawing.Point(200, 8);
            this.m_rdb11.Name = "m_rdb11";
            this.m_rdb11.Size = new System.Drawing.Size(64, 16);
            this.m_rdb11.TabIndex = 10000055;
            this.m_rdb11.Tag = "1";
            this.m_rdb11.Text = "40-50";
            this.m_rdb11.CheckedChanged += new System.EventHandler(this.m_rdbBodyRuddy_CheckedChanged);
            // 
            // m_rdb10
            // 
            this.m_rdb10.Checked = true;
            this.m_rdb10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_rdb10.Location = new System.Drawing.Point(48, 8);
            this.m_rdb10.Name = "m_rdb10";
            this.m_rdb10.Size = new System.Drawing.Size(56, 16);
            this.m_rdb10.TabIndex = 10000053;
            this.m_rdb10.TabStop = true;
            this.m_rdb10.Tag = "0";
            this.m_rdb10.Text = "0-30";
            // 
            // label38
            // 
            this.label38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label38.Location = new System.Drawing.Point(0, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(144, 30);
            this.label38.TabIndex = 10000050;
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label39
            // 
            this.label39.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label39.Location = new System.Drawing.Point(144, 0);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(144, 30);
            this.label39.TabIndex = 10000026;
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label40
            // 
            this.label40.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label40.Location = new System.Drawing.Point(288, 0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(144, 30);
            this.label40.TabIndex = 10000027;
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label41
            // 
            this.label41.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label41.Location = new System.Drawing.Point(432, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(144, 30);
            this.label41.TabIndex = 10000028;
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.m_rdb23);
            this.panel3.Controls.Add(this.m_rdb22);
            this.panel3.Controls.Add(this.m_rdb21);
            this.panel3.Controls.Add(this.m_rdb20);
            this.panel3.Controls.Add(this.label42);
            this.panel3.Controls.Add(this.label43);
            this.panel3.Controls.Add(this.label44);
            this.panel3.Controls.Add(this.label45);
            this.panel3.Location = new System.Drawing.Point(164, 116);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(576, 32);
            this.panel3.TabIndex = 10000052;
            // 
            // m_rdb23
            // 
            this.m_rdb23.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_rdb23.Location = new System.Drawing.Point(480, 8);
            this.m_rdb23.Name = "m_rdb23";
            this.m_rdb23.Size = new System.Drawing.Size(80, 16);
            this.m_rdb23.TabIndex = 10000057;
            this.m_rdb23.Tag = "3";
            this.m_rdb23.Text = "-1或+2";
            this.m_rdb23.CheckedChanged += new System.EventHandler(this.m_rdbBodyRuddy_CheckedChanged);
            // 
            // m_rdb22
            // 
            this.m_rdb22.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_rdb22.Location = new System.Drawing.Point(336, 8);
            this.m_rdb22.Name = "m_rdb22";
            this.m_rdb22.Size = new System.Drawing.Size(80, 16);
            this.m_rdb22.TabIndex = 10000056;
            this.m_rdb22.Tag = "2";
            this.m_rdb22.Text = "-1或者0";
            this.m_rdb22.CheckedChanged += new System.EventHandler(this.m_rdbBodyRuddy_CheckedChanged);
            // 
            // m_rdb21
            // 
            this.m_rdb21.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_rdb21.Location = new System.Drawing.Point(200, 8);
            this.m_rdb21.Name = "m_rdb21";
            this.m_rdb21.Size = new System.Drawing.Size(56, 16);
            this.m_rdb21.TabIndex = 10000055;
            this.m_rdb21.Tag = "1";
            this.m_rdb21.Text = "-2";
            this.m_rdb21.CheckedChanged += new System.EventHandler(this.m_rdbBodyRuddy_CheckedChanged);
            // 
            // m_rdb20
            // 
            this.m_rdb20.Checked = true;
            this.m_rdb20.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_rdb20.Location = new System.Drawing.Point(48, 8);
            this.m_rdb20.Name = "m_rdb20";
            this.m_rdb20.Size = new System.Drawing.Size(56, 16);
            this.m_rdb20.TabIndex = 10000053;
            this.m_rdb20.TabStop = true;
            this.m_rdb20.Tag = "0";
            this.m_rdb20.Text = "-3";
            // 
            // label42
            // 
            this.label42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label42.Location = new System.Drawing.Point(0, 0);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(144, 30);
            this.label42.TabIndex = 10000050;
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label43
            // 
            this.label43.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label43.Location = new System.Drawing.Point(144, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(144, 30);
            this.label43.TabIndex = 10000026;
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label44
            // 
            this.label44.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label44.Location = new System.Drawing.Point(288, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(144, 30);
            this.label44.TabIndex = 10000027;
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label45
            // 
            this.label45.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label45.Location = new System.Drawing.Point(432, 0);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(144, 30);
            this.label45.TabIndex = 10000028;
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.m_rdb33);
            this.panel4.Controls.Add(this.m_rdb32);
            this.panel4.Controls.Add(this.m_rdb31);
            this.panel4.Controls.Add(this.m_rdb30);
            this.panel4.Controls.Add(this.label46);
            this.panel4.Controls.Add(this.label47);
            this.panel4.Controls.Add(this.label48);
            this.panel4.Controls.Add(this.label49);
            this.panel4.Location = new System.Drawing.Point(164, 144);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(576, 32);
            this.panel4.TabIndex = 10000053;
            // 
            // m_rdb33
            // 
            this.m_rdb33.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_rdb33.Location = new System.Drawing.Point(464, 8);
            this.m_rdb33.Name = "m_rdb33";
            this.m_rdb33.Size = new System.Drawing.Size(96, 16);
            this.m_rdb33.TabIndex = 10000058;
            this.m_rdb33.Tag = "3";
            this.m_rdb33.Text = "辅助隐藏";
            this.m_rdb33.Visible = false;
            // 
            // m_rdb32
            // 
            this.m_rdb32.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_rdb32.Location = new System.Drawing.Point(336, 8);
            this.m_rdb32.Name = "m_rdb32";
            this.m_rdb32.Size = new System.Drawing.Size(56, 16);
            this.m_rdb32.TabIndex = 10000056;
            this.m_rdb32.Tag = "2";
            this.m_rdb32.Text = "软";
            this.m_rdb32.CheckedChanged += new System.EventHandler(this.m_rdbBodyRuddy_CheckedChanged);
            // 
            // m_rdb31
            // 
            this.m_rdb31.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_rdb31.Location = new System.Drawing.Point(200, 8);
            this.m_rdb31.Name = "m_rdb31";
            this.m_rdb31.Size = new System.Drawing.Size(56, 16);
            this.m_rdb31.TabIndex = 10000055;
            this.m_rdb31.Tag = "1";
            this.m_rdb31.Text = "中等";
            this.m_rdb31.CheckedChanged += new System.EventHandler(this.m_rdbBodyRuddy_CheckedChanged);
            // 
            // m_rdb30
            // 
            this.m_rdb30.Checked = true;
            this.m_rdb30.Font = new System.Drawing.Font("宋体", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_rdb30.Location = new System.Drawing.Point(48, 8);
            this.m_rdb30.Name = "m_rdb30";
            this.m_rdb30.Size = new System.Drawing.Size(56, 16);
            this.m_rdb30.TabIndex = 10000053;
            this.m_rdb30.TabStop = true;
            this.m_rdb30.Tag = "0";
            this.m_rdb30.Text = "硬";
            // 
            // label46
            // 
            this.label46.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label46.Location = new System.Drawing.Point(0, 0);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(144, 30);
            this.label46.TabIndex = 10000050;
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label47
            // 
            this.label47.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label47.Location = new System.Drawing.Point(144, 0);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(144, 30);
            this.label47.TabIndex = 10000026;
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label48
            // 
            this.label48.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label48.Location = new System.Drawing.Point(288, 0);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(144, 30);
            this.label48.TabIndex = 10000027;
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label49
            // 
            this.label49.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label49.Location = new System.Drawing.Point(432, 0);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(144, 30);
            this.label49.TabIndex = 10000028;
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.m_rdb43);
            this.panel5.Controls.Add(this.m_rdb42);
            this.panel5.Controls.Add(this.m_rdb41);
            this.panel5.Controls.Add(this.m_rdb40);
            this.panel5.Controls.Add(this.label14);
            this.panel5.Controls.Add(this.label15);
            this.panel5.Controls.Add(this.label20);
            this.panel5.Controls.Add(this.label21);
            this.panel5.Location = new System.Drawing.Point(164, 172);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(576, 32);
            this.panel5.TabIndex = 10000054;
            // 
            // m_rdb43
            // 
            this.m_rdb43.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_rdb43.Location = new System.Drawing.Point(464, 8);
            this.m_rdb43.Name = "m_rdb43";
            this.m_rdb43.Size = new System.Drawing.Size(88, 16);
            this.m_rdb43.TabIndex = 10000058;
            this.m_rdb43.Tag = "3";
            this.m_rdb43.Text = "辅助隐藏";
            this.m_rdb43.Visible = false;
            // 
            // m_rdb42
            // 
            this.m_rdb42.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_rdb42.Location = new System.Drawing.Point(336, 8);
            this.m_rdb42.Name = "m_rdb42";
            this.m_rdb42.Size = new System.Drawing.Size(56, 16);
            this.m_rdb42.TabIndex = 10000056;
            this.m_rdb42.Tag = "2";
            this.m_rdb42.Text = "前位";
            this.m_rdb42.CheckedChanged += new System.EventHandler(this.m_rdbBodyRuddy_CheckedChanged);
            // 
            // m_rdb41
            // 
            this.m_rdb41.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_rdb41.Location = new System.Drawing.Point(200, 8);
            this.m_rdb41.Name = "m_rdb41";
            this.m_rdb41.Size = new System.Drawing.Size(56, 16);
            this.m_rdb41.TabIndex = 10000055;
            this.m_rdb41.Tag = "1";
            this.m_rdb41.Text = "中位";
            this.m_rdb41.CheckedChanged += new System.EventHandler(this.m_rdbBodyRuddy_CheckedChanged);
            // 
            // m_rdb40
            // 
            this.m_rdb40.Checked = true;
            this.m_rdb40.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_rdb40.Location = new System.Drawing.Point(48, 8);
            this.m_rdb40.Name = "m_rdb40";
            this.m_rdb40.Size = new System.Drawing.Size(56, 16);
            this.m_rdb40.TabIndex = 10000053;
            this.m_rdb40.TabStop = true;
            this.m_rdb40.Tag = "0";
            this.m_rdb40.Text = "后位";
            // 
            // label14
            // 
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Location = new System.Drawing.Point(0, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(144, 30);
            this.label14.TabIndex = 10000050;
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Location = new System.Drawing.Point(144, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(144, 30);
            this.label15.TabIndex = 10000026;
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label20.Location = new System.Drawing.Point(288, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(144, 30);
            this.label20.TabIndex = 10000027;
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label21.Location = new System.Drawing.Point(432, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(144, 30);
            this.label21.TabIndex = 10000028;
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtINDICATE_CHR
            // 
            this.m_txtINDICATE_CHR.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtINDICATE_CHR.Location = new System.Drawing.Point(364, 208);
            this.m_txtINDICATE_CHR.MaxLength = 200;
            this.m_txtINDICATE_CHR.Name = "m_txtINDICATE_CHR";
            this.m_txtINDICATE_CHR.Size = new System.Drawing.Size(120, 21);
            this.m_txtINDICATE_CHR.TabIndex = 10000056;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.Location = new System.Drawing.Point(272, 212);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(95, 12);
            this.label23.TabIndex = 10000058;
            this.label23.Text = "静滴催产素指征:";
            // 
            // m_txtDROPPINGCASE_CHR
            // 
            this.m_txtDROPPINGCASE_CHR.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDROPPINGCASE_CHR.Location = new System.Drawing.Point(148, 208);
            this.m_txtDROPPINGCASE_CHR.MaxLength = 200;
            this.m_txtDROPPINGCASE_CHR.Name = "m_txtDROPPINGCASE_CHR";
            this.m_txtDROPPINGCASE_CHR.Size = new System.Drawing.Size(120, 21);
            this.m_txtDROPPINGCASE_CHR.TabIndex = 10000055;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.Location = new System.Drawing.Point(20, 212);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(119, 12);
            this.label24.TabIndex = 10000057;
            this.label24.Text = "催产素静脉点滴情况:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_txtLAYCOUNT_CHR);
            this.groupBox1.Controls.Add(this.m_txtPREGNANTWEEK_CHR);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.m_txtSCORECOUNT_CHR);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label32);
            this.groupBox1.Controls.Add(this.label37);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.m_txtUSECOUNT_CHR);
            this.groupBox1.Controls.Add(this.m_cmdSave);
            this.groupBox1.Controls.Add(this.m_txtLAYWAY_CHR);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.m_txtINDICATE_CHR);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.m_txtDROPPINGCASE_CHR);
            this.groupBox1.Location = new System.Drawing.Point(4, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(752, 264);
            this.groupBox1.TabIndex = 10000059;
            this.groupBox1.TabStop = false;
            // 
            // frmHurryVeinRecord_Acad
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(784, 625);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmHurryVeinRecord_Acad";
            this.Text = "催产素静脉点滴观察表";
            this.Load += new System.EventHandler(this.frmHurryVeinRecord_Acad_Load);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_dtgRecordDetail, 0);
            this.Controls.SetChildIndex(this.m_trvInPatientDate, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRecordDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtbRecords)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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


			p_dtbRecordTable.Columns.Add("CHROMA_CHR",typeof(clsDSTRichTextBoxValue));//6
					
			p_dtbRecordTable.Columns.Add("DROPCOUNT_CHR",typeof(clsDSTRichTextBoxValue));//6

			p_dtbRecordTable.Columns.Add("PALACESHRINK_CHR",typeof(clsDSTRichTextBoxValue));//7
			p_dtbRecordTable.Columns.Add("EMBRYOHEART_CHR",typeof(clsDSTRichTextBoxValue));//8
			p_dtbRecordTable.Columns.Add("EXPAND_CHR",typeof(clsDSTRichTextBoxValue));//9
			p_dtbRecordTable.Columns.Add("PRESENTATION_CHR",typeof(clsDSTRichTextBoxValue));//10
			p_dtbRecordTable.Columns.Add("BLOODPRESSURE_CHR",typeof(clsDSTRichTextBoxValue));//11	
			p_dtbRecordTable.Columns.Add("SPECIALRECORD_CHR",typeof(clsDSTRichTextBoxValue));//12
			p_dtbRecordTable.Columns.Add("SIGNATURE_CHR",typeof(clsDSTRichTextBoxValue));//13
//			p_dtbRecordTable.Columns.Add("PERINEUM_CHR",typeof(clsDSTRichTextBoxValue));//14
//			p_dtbRecordTable.Columns.Add("BP_CHR",typeof(clsDSTRichTextBoxValue));//15
//			p_dtbRecordTable.Columns.Add("URINE_CHR",typeof(clsDSTRichTextBoxValue));//16
//			p_dtbRecordTable.Columns.Add("ANNOTATIONS_CHR",typeof(clsDSTRichTextBoxValue));//17
//			p_dtbRecordTable.Columns.Add("SCRTATOR_CHR",typeof(clsDSTRichTextBoxValue));//17
			p_dtbRecordTable.Columns.Add("RecordSignID");


			//			m_dtcGenaralInstance.m_RtbBase.m_BlnReadOnly = true;
			m_mthSetControl(m_dtcRecordDate_chr);
			m_mthSetControl(m_dtcTime_chr);

			m_mthSetControl(m_dtcCHROMA_CHR);
			m_mthSetControl(m_dtcDROPCOUNT_CHR);
			m_mthSetControl(m_dtcPALACESHRINK_CHR);
			m_mthSetControl(m_dtcEMBRYOHEART_CHR);
			m_mthSetControl(m_dtcEXPAND_CHR);
			m_mthSetControl(m_dtcPRESENTATION_CHR);
			m_mthSetControl(m_dtcBLOODPRESSURE_CHR);
			m_mthSetControl(m_dtcSPECIALRECORD_CHR);
			m_mthSetControl(m_dtcSIGNATURE_CHR);
	

			
			//设置文字栏
			this.m_dtcRecordDate_chr.HeaderText = "日\r\n\r\n期";
			this.m_dtcTime_chr.HeaderText = "时\r\n\r\n间";

			this.m_dtcCHROMA_CHR.HeaderText = "催产素\r\n浓度\r\nu/500ml";
			this.m_dtcDROPCOUNT_CHR.HeaderText = "滴数\r\n滴/分";

			this.m_dtcPALACESHRINK_CHR.HeaderText = "宫\r\n\r\n缩";

			this.m_dtcEMBRYOHEART_CHR.HeaderText = "胎\r\n\r\n心";
			this.m_dtcEXPAND_CHR.HeaderText = "宫口\r\n\r\n扩张";
			this.m_dtcPRESENTATION_CHR.HeaderText = "先露\r\n\r\n高低";
			this.m_dtcBLOODPRESSURE_CHR.HeaderText = "血\r\n\r\n压";
			this.m_dtcSPECIALRECORD_CHR.HeaderText =  "特殊\r\n情况\r\n及处理";

			this.m_dtcSIGNATURE_CHR.HeaderText =  "签\r\n\r\n名";
		

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
            return new clsRecordsDomain(enmRecordsType.HurryVeinRecord);
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
				case enmDiseaseTrackType.HurryVeinRecord:
					objContent = new clsHurryVeinRecord();//(需要改动)
					break;
			}

			if(objContent == null)
				objContent=new clsHurryVeinRecord();	//(需要改动)
		
			if(m_objCurrentPatient !=null)
				objContent.m_strInPatientID=m_objCurrentPatient.m_StrInPatientID;
			else 
			{
				clsPublicFunction.ShowInformationMessageBox("当前病人为空!");
				return null;
			}
			int intSelectedRecordStartRow =m_dtgRecordDetail.CurrentCell.RowNumber;
			objContent.m_strCreateUserID = (m_dtbRecords.Rows[intSelectedRecordStartRow][15]).ToString();
			objContent.m_dtmInPatientDate=m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmEMRInDate;
			objContent.m_dtmCreateDate = DateTime.Parse((string)p_objDataArr[0]);
			objContent.m_dtmOpenDate = DateTime.Parse((string)p_objDataArr[2]);
			objContent.m_dtmModifyDate = DateTime.Parse((string)p_objDataArr[3]);     
			return objContent;
		}

		private void frmHurryVeinRecord_Acad_Load(object sender, System.EventArgs e)
		{
			m_dtmPreRecordDate = DateTime.MinValue;
			m_dtgRecordDetail.Focus();
			m_mniAddBlank.Visible=false;
			m_mniDeleteBlank.Visible=false;	
		
		
		}

		#region 对孕产等的处理

		private void m_mthUpdateOther()
		{
			if(this.m_trvInPatientDate.SelectedNode != null)
			{
				 date = m_objCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss");
                 InPatientID = m_objCurrentPatient.m_StrEMRInPatientID;
				if(InPatientID != "")
				{

				string p_strRdbneckexpand_chr = "0";
				string p_strRdbneckshink_chr = "0";
				string p_strRdbhighlow_chr = "0";
				string p_strRdbneckhard_chr = "0";
				string p_strRdbnecklocation_chr = "0";
				if(m_rdb01.Checked)
					p_strRdbneckexpand_chr = "1";
					else if(m_rdb02.Checked)
					p_strRdbneckexpand_chr = "2";
				else if(m_rdb03.Checked)
					p_strRdbneckexpand_chr = "3";

					if(m_rdb11.Checked)
						p_strRdbneckshink_chr = "1";
					else if(m_rdb12.Checked)
						p_strRdbneckshink_chr = "2";
					else if(m_rdb13.Checked)
						p_strRdbneckshink_chr = "3";

					if(m_rdb21.Checked)
						p_strRdbhighlow_chr = "1";
					else if(m_rdb22.Checked)
						p_strRdbhighlow_chr = "2";
					else if(m_rdb23.Checked)
						p_strRdbhighlow_chr = "3";

					if(m_rdb31.Checked)
						p_strRdbneckhard_chr = "1";
					else if(m_rdb32.Checked)
						p_strRdbneckhard_chr = "2";
					else if(m_rdb33.Checked)
						p_strRdbneckhard_chr = "3";

					if(m_rdb41.Checked)
						p_strRdbnecklocation_chr = "1";
					else if(m_rdb42.Checked)
						p_strRdbnecklocation_chr = "2";
					else if(m_rdb43.Checked)
						p_strRdbnecklocation_chr = "3";

                    com.digitalwave.clsRecordsService.clsHurryVeinRecord_ContentService domin =
                        (com.digitalwave.clsRecordsService.clsHurryVeinRecord_ContentService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsRecordsService.clsHurryVeinRecord_ContentService));

					long res = 0;
					res = domin.m_lngGetUpdateOther(InPatientID,date, m_txtLAYCOUNT_CHR.Text.Trim(),  m_txtPREGNANTWEEK_CHR.Text.Trim()
						,  m_txtSCORECOUNT_CHR.Text.Trim(),  p_strRdbneckexpand_chr, p_strRdbneckshink_chr,p_strRdbhighlow_chr,p_strRdbneckhard_chr ,m_txtDROPPINGCASE_CHR.Text.Trim(),m_txtINDICATE_CHR.Text.Trim(),
						m_txtUSECOUNT_CHR.Text.Trim(),m_txtLAYWAY_CHR.Text.Trim(),p_strRdbnecklocation_chr);

					if(res <0)
					{
						MessageBox.Show("保存失败");
					}
				}
			}			
			
		}
		private void m_mthget()
		{

			if(this.m_trvInPatientDate.SelectedNode != null)
			{
				if(this.m_trvInPatientDate.SelectedNode.Text != "入院时间")
				{
					date = m_objCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss");
                    InPatientID = m_objCurrentPatient.m_StrEMRInPatientID;
					if(InPatientID != "")
					{
						#region shink

                        com.digitalwave.clsRecordsService.clsHurryVeinRecord_ContentService domin =
                            (com.digitalwave.clsRecordsService.clsHurryVeinRecord_ContentService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsRecordsService.clsHurryVeinRecord_ContentService));

						domin.m_lngGetOther(InPatientID,date,
							out p_strlaycount_chr, 
							out p_strPregnantweek_chr, 
							out p_strScorecount_chr,
							out p_strRdbneckexpand_chr, 
							out p_strRdbneckshink_chr,
							out p_strRdbhighlow_chr,
							out p_strRdbneckhard_chr,
							out p_strDroppingcase_chr,
							out p_strIndicate_chr,
							out p_strUsecount_chr,
							out p_strLayway_chr,
							out p_strRdbnecklocation_chr
							);

						m_txtLAYCOUNT_CHR.Text = p_strlaycount_chr;  
						m_txtPREGNANTWEEK_CHR.Text = p_strPregnantweek_chr; 
						m_txtSCORECOUNT_CHR.Text= p_strScorecount_chr;
						if(p_strRdbneckexpand_chr=="0")
							m_rdb00.Checked = true;
						else if (p_strRdbneckexpand_chr=="1")
							m_rdb01.Checked = true;
						else if (p_strRdbneckexpand_chr=="2")
							m_rdb02.Checked = true;
						else if (p_strRdbneckexpand_chr=="3")
							m_rdb03.Checked = true;

						if(p_strRdbneckshink_chr=="0")
							m_rdb10.Checked = true;
						else if (p_strRdbneckshink_chr=="1")
							m_rdb11.Checked = true;
						else if (p_strRdbneckshink_chr=="2")
							m_rdb12.Checked = true;
						else if (p_strRdbneckshink_chr=="3")
							m_rdb13.Checked = true;
					
						if(p_strRdbhighlow_chr=="0")
							m_rdb20.Checked = true;
						else if (p_strRdbhighlow_chr=="1")
							m_rdb21.Checked = true;
						else if (p_strRdbhighlow_chr=="2")
							m_rdb22.Checked = true;
						else if (p_strRdbhighlow_chr=="3")
							m_rdb23.Checked = true;

						if(p_strRdbneckhard_chr=="0")
							m_rdb30.Checked = true;
						else if (p_strRdbneckhard_chr=="1")
							m_rdb31.Checked = true;
						else if (p_strRdbneckhard_chr=="2")
							m_rdb32.Checked = true;
						else if (p_strRdbneckhard_chr=="3")
							m_rdb33.Checked = true;
							
						m_txtDROPPINGCASE_CHR.Text=	 p_strDroppingcase_chr;
						m_txtINDICATE_CHR.Text= p_strIndicate_chr;
						m_txtUSECOUNT_CHR.Text= p_strUsecount_chr;
						m_txtLAYWAY_CHR.Text=	 p_strLayway_chr;
							
						if(p_strRdbnecklocation_chr=="0")
							m_rdb40.Checked = true;
						else if (p_strRdbnecklocation_chr=="1")
							m_rdb41.Checked = true;
						else if (p_strRdbnecklocation_chr=="2")
							m_rdb42.Checked = true;
						else if (p_strRdbnecklocation_chr=="3")
							m_rdb43.Checked = true;
						#endregion
					}
				}
				else
				{
					#region shink
					m_txtLAYCOUNT_CHR.Text = p_strlaycount_chr ="";  
					m_txtPREGNANTWEEK_CHR.Text = p_strPregnantweek_chr=""; 
					m_txtSCORECOUNT_CHR.Text= p_strScorecount_chr="";
					p_strRdbneckexpand_chr="0";
						m_rdb00.Checked = true;

					p_strRdbneckshink_chr="0";
						m_rdb10.Checked = true;
					
					p_strRdbhighlow_chr="0";
						m_rdb20.Checked = true;
					

					p_strRdbneckhard_chr="0";
						m_rdb30.Checked = true;
					
							
					m_txtDROPPINGCASE_CHR.Text=	 p_strDroppingcase_chr="";
					m_txtINDICATE_CHR.Text= p_strIndicate_chr="";
					m_txtUSECOUNT_CHR.Text= p_strUsecount_chr="";
					m_txtLAYWAY_CHR.Text=	 p_strLayway_chr="";
							
					p_strRdbnecklocation_chr="0";
						m_rdb40.Checked = true;					
					#endregion
				}
			}
		}
		#endregion 
		// 获取处理（添加和修改）记录的窗体。
		protected override frmDiseaseTrackBase m_frmGetRecordForm(int p_intRecordType)
		{
			switch((enmDiseaseTrackType)p_intRecordType)
			{
				case enmDiseaseTrackType.HurryVeinRecord://(需要改动)
					
				{
					frmHurryVeinRecord_AcadCon frmwcon = new frmHurryVeinRecord_AcadCon();
		
					frmwcon.date  = date;
					frmwcon.InPatientID  = InPatientID;
					frmwcon.p_strlaycount_chr = p_strlaycount_chr;
					frmwcon.p_strPregnantweek_chr =p_strPregnantweek_chr;
					frmwcon.p_strScorecount_chr = p_strScorecount_chr;
					frmwcon.p_strRdbneckexpand_chr = p_strRdbneckexpand_chr;
					frmwcon.p_strRdbneckshink_chr =p_strRdbneckshink_chr;
					frmwcon.p_strRdbhighlow_chr = p_strRdbhighlow_chr;
					frmwcon.p_strRdbneckhard_chr = p_strRdbneckhard_chr;
					frmwcon.p_strDroppingcase_chr = p_strDroppingcase_chr;
					frmwcon.p_strIndicate_chr = p_strIndicate_chr;
					frmwcon.p_strUsecount_chr = p_strUsecount_chr;
					frmwcon.p_strLayway_chr = p_strLayway_chr;
					frmwcon.p_strRdbnecklocation_chr = p_strRdbnecklocation_chr;


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
			m_mthSetPatientFormInfo(m_objCurrentPatient);
		}
		/// <summary>
		/// 从Table删除数据
		/// </summary>
		/// <param name="p_intRecordType"></param>
		/// <param name="p_dtmCreateRecordTime"></param>
		protected override void m_mthRemoveDataFromDataTable(int p_intRecordType,
			DateTime p_dtmCreateRecordTime)
		{
			m_mthSetPatientFormInfo(m_objCurrentPatient);
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
			m_mthAddNewRecord((int)enmDiseaseTrackType.HurryVeinRecord);//(需要改动)
		}

		protected override infPrintRecord m_objGetPrintTool()
		{			
			clsHurryVeinRecord_AcadPrintTool frmwcon = new clsHurryVeinRecord_AcadPrintTool();
		frmwcon.p_strlaycount_chr = p_strlaycount_chr;
		frmwcon.p_strPregnantweek_chr = p_strPregnantweek_chr;
		frmwcon.p_strScorecount_chr = p_strScorecount_chr;
		frmwcon.p_strRdbneckexpand_chr = p_strRdbneckexpand_chr;
		frmwcon.p_strRdbneckshink_chr = p_strRdbneckshink_chr;
		frmwcon.p_strRdbhighlow_chr = p_strRdbhighlow_chr;
		frmwcon.p_strRdbneckhard_chr = p_strRdbneckhard_chr;
		frmwcon.p_strDroppingcase_chr = p_strDroppingcase_chr;
		frmwcon.p_strIndicate_chr = p_strIndicate_chr;
		frmwcon.p_strUsecount_chr = p_strUsecount_chr;
		frmwcon.p_strLayway_chr = p_strLayway_chr;
		frmwcon.p_strRdbnecklocation_chr =p_strRdbnecklocation_chr;
	
			return frmwcon;
		}

		protected override object[][] m_objGetRecordsValueArr(clsTransDataInfo p_objTransDataInfo)
		{
			#region 显示记录到DataGrid
			try
			{

				#region 清空孕周等等。
					
				m_txtLAYCOUNT_CHR.Text = "";  
				m_txtPREGNANTWEEK_CHR.Text = ""; 
				m_txtSCORECOUNT_CHR.Text= "0";
				m_rdb00.Checked = true;				
				m_rdb10.Checked = true;						
				m_rdb20.Checked = true;	
				m_rdb30.Checked = true;
				m_rdb40.Checked = true;							
				m_txtDROPPINGCASE_CHR.Text=	 "";
				m_txtINDICATE_CHR.Text= "";
				m_txtUSECOUNT_CHR.Text= "";
				m_txtLAYWAY_CHR.Text=	 "";
							
				#endregion
				m_mthget();

				if(p_objTransDataInfo == null)
					return null;

				object[] objData;
				ArrayList objReturnData=new ArrayList();

				clsHurryVeinRecordContentDataInfo objICUInfo=new clsHurryVeinRecordContentDataInfo();	//(需要改动)		
				clsDSTRichTextBoxValue objclsDSTRichTextBoxValue;
				string strText,strXml;

				objICUInfo = (clsHurryVeinRecordContentDataInfo)p_objTransDataInfo;//(需要改动)

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
					objData = new object[16];   //(需要改动) DataTable的列数
					clsHurryVeinRecord objCurrent = objICUInfo.m_objRecordArr[i];//(需要改动)
					clsHurryVeinRecord objNext = new clsHurryVeinRecord();//下一条记录//(需要改动)
					if(i < intRecordCount-1)
						objNext = objICUInfo.m_objRecordArr[i+1];

					//如果该护理记录是修改前的记录且是在指定时间内修改的，修改者与创建者为同一人，则不显示
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strModifyUserID.Trim()==objCurrent.m_strCreateUserID.Trim())
					{
						TimeSpan tsModify =  objNext.m_dtmModifyDate-objCurrent.m_dtmModifyDate;
						if((int)tsModify.TotalHours < intCanModifyTime)
							continue;
					}

					#region 存放关键字段
					if(objCurrent.m_dtmCreateDate!=DateTime.MinValue)
					{
						objData[0] = objCurrent.m_dtmCreateDate;//存放记录时间的字符串
						objData[1] = (int)enmRecordsType.HurryVeinRecord;//存放记录类型的int值  //(需要改动)
						objData[2] = objCurrent.m_dtmOpenDate;//存放记录的OpenDate字符串
						objData[3] = objICUInfo.m_objRecordArr[objICUInfo.m_objRecordArr.Length-1].m_dtmModifyDate;//存放记录的ModifyDate字符串   
						
						
						//同一个则只在第一行显示日期
						if(objCurrent.m_dtmCreateDate.Date.ToString() != m_dtmPreRecordDate.Date.ToString())
						{
							objData[4] = objCurrent.m_dtmCreateDate.Date.ToString("yyyy-MM-dd") ;//日期字符串
						}
						//修改后带有痕迹的记录不再显示时间
						if(m_dtmPreRecordDate != objCurrent.m_dtmCreateDate)
							objData[5] = objCurrent.m_dtmCreateDate.ToString("HH:mm");//时间字符串
	
					}
					m_dtmPreRecordDate = objCurrent.m_dtmCreateDate;	
					#endregion 					
					
					#region 存放单项信息
					//浓度
					strText = objCurrent.m_strCHROMA_CHR_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strCHROMA_CHR_RIGHT != objCurrent.m_strCHROMA_CHR_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strCHROMA_CHR_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[6] = objclsDSTRichTextBoxValue;//

					//滴数
					strText = objCurrent.m_strDROPCOUNT_CHR_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strDROPCOUNT_CHR_RIGHT != objCurrent.m_strDROPCOUNT_CHR_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strDROPCOUNT_CHR_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[7] = objclsDSTRichTextBoxValue;//

			
					//宫缩
					strText = objCurrent.m_strPALACESHRINK_CHR_RIGHT ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strPALACESHRINK_CHR_RIGHT != objCurrent.m_strPALACESHRINK_CHR_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strPALACESHRINK_CHR_RIGHT,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[8] = objclsDSTRichTextBoxValue;

					//胎心
					strText = objCurrent.m_strEMBRYOHEART_CHR_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strEMBRYOHEART_CHR_RIGHT != objCurrent.m_strEMBRYOHEART_CHR_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strEMBRYOHEART_CHR_RIGHT,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[9] = objclsDSTRichTextBoxValue;//

			
					//宫口扩张
					strText = objCurrent.m_strEXPAND_CHR_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strEXPAND_CHR_RIGHT != objCurrent.m_strEXPAND_CHR_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strEXPAND_CHR_RIGHT,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[10] = objclsDSTRichTextBoxValue;//乳腺>>乳胀
			
					//先露
					strText = objCurrent.m_strPRESENTATION_CHR_RIGHT ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strPRESENTATION_CHR_RIGHT != objCurrent.m_strPRESENTATION_CHR_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strPRESENTATION_CHR_RIGHT,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[11] = objclsDSTRichTextBoxValue;//

					//血压
					strText = objCurrent.m_strBLOODPRESSURE_CHR_RIGHT ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strBLOODPRESSURE_CHR_RIGHT != objCurrent.m_strBLOODPRESSURE_CHR_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strBLOODPRESSURE_CHR_RIGHT,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[12] = objclsDSTRichTextBoxValue;//

//					//特殊记录
//					strText = objCurrent.m_strSPECIALRECORD_CHR_RIGHT ;
//					strXml = "<root />";
//					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strSPECIALRECORD_CHR_RIGHT != objCurrent.m_strSPECIALRECORD_CHR_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
//					{
//						strXml = m_strGetDSTTextXML(objCurrent.m_strSPECIALRECORD_CHR_RIGHT,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
//					}
//					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
//					objclsDSTRichTextBoxValue.m_strText=strText;						
//					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
//					objData[13] = objclsDSTRichTextBoxValue;//

					//特殊记录
					string[] strGeneralInstanceArr = null;
					string[] strGeneralInstanceXMLArr = null;
					if(objCurrent.m_strSPECIALRECORD_CHR_RIGHT != null ||objCurrent.m_strSPECIALRECORD_CHR_RIGHT != "")
					{
						string strGeneralInstance = objCurrent.m_strSPECIALRECORD_CHR_RIGHT;
						string strGeneralInstanceXML = objCurrent.m_strSPECIALRECORD_CHRXML;
						string[] strGeneralInstanceArrTemp;
						string[] strGeneralInstanceXMLArrTemp;
						//将病情记录分为20个字符一行。
						com.digitalwave.controls.ctlRichTextBox.m_mthSplitXml(strGeneralInstance,strGeneralInstanceXML,6,out strGeneralInstanceArrTemp,out strGeneralInstanceXMLArrTemp);
						
						if(objCurrent.m_strCreateUserID != null && objCurrent.m_strCreateUserID != "")
						{
							//							strGeneralInstanceArr = new string[strGeneralInstanceArrTemp.Length + 1];
							//							strGeneralInstanceXMLArr = new string[strGeneralInstanceXMLArrTemp.Length + 1];
							strGeneralInstanceArr = new string[strGeneralInstanceArrTemp.Length ];
							strGeneralInstanceXMLArr = new string[strGeneralInstanceXMLArrTemp.Length ];
							//							for(int j=0; j<strGeneralInstanceArr.Length-1; j++)
							for(int j=0; j<strGeneralInstanceArr.Length; j++)
							{
								strGeneralInstanceArr[j] = strGeneralInstanceArrTemp[j];
							}
							//							strGeneralInstanceArr[strGeneralInstanceArr.Length-1] = "";//objCurrent.m_dtmCreateDate.ToString("yyyy-MM-dd")+"    "+objCurrent.m_strCreateUserName;
							//							
							//							strGeneralInstanceXMLArr[strGeneralInstanceXMLArr.Length-1] = "";
							//							for(int j=0; j<strGeneralInstanceXMLArr.Length-1; j++)
							for(int j=0; j<strGeneralInstanceXMLArr.Length; j++)
							{
								strGeneralInstanceXMLArr[j] = strGeneralInstanceXMLArrTemp[j];
							}
						}
						else
						{
							strGeneralInstanceArr = strGeneralInstanceArrTemp;
							strGeneralInstanceXMLArr = strGeneralInstanceXMLArrTemp;
						}

						strText = strGeneralInstanceArr[0];
						strXml = strGeneralInstanceXMLArr[0];
						objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
						objclsDSTRichTextBoxValue.m_strText=strText;						
						objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
						objData[13] = objclsDSTRichTextBoxValue;
					}

					//签名
					strText = objCurrent.m_strSIGNATURE_CHR_RIGHT  ;
					string strNextText = objNext.m_strSIGNATURE_CHR_RIGHT  ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && strNextText != strText)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(strText,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[14] = objclsDSTRichTextBoxValue;//
					objData[15] = objCurrent.m_strCreateUserID;

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
					objReturnData.Add(objData);

					if(strGeneralInstanceArr.Length > 1)
					{
						object[] objInstance = null;
						for(int j=1; j<strGeneralInstanceArr.Length; j++)
						{
							objInstance = new object[16];
							strText = strGeneralInstanceArr[j];
							strXml = strGeneralInstanceXMLArr[j];
							objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
							objclsDSTRichTextBoxValue.m_strText=strText;						
							objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
							objInstance[13] = objclsDSTRichTextBoxValue;
							objInstance[15] = objCurrent.m_strCreateUserID;
							objReturnData.Add(objInstance);
						}
					}
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

		private void textBox2_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void groupBox1_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void m_cmdSave_Click(object sender, System.EventArgs e)
		{
			m_mthUpdateOther();
			m_mthget();
		}



		int sum= 0;
		private void m_rdbBodyRuddy_CheckedChanged(object sender, System.EventArgs e)
		{
			RadioButton rb = (RadioButton)sender;
			
			if(rb.Checked)
			{
				sum += int.Parse(rb.Tag.ToString());
			}
			else
			{
				sum -= int.Parse(rb.Tag.ToString());
			}
			this.m_txtSCORECOUNT_CHR.Text = sum.ToString() ;
		}


		protected override void m_trvInPatientDate_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			base.m_trvInPatientDate_AfterSelect(sender,e);
			m_mthget();
		}

	}
}


