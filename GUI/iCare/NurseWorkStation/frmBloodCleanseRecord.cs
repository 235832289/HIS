
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
using com.digitalwave.Emr.StaticObject;

namespace iCare
{
	/// <summary>
	/// 血液净化记录表
	/// </summary>
    public class frmBloodCleanseRecord : iCare.frmRecordsBase
	{
		#region system define

        private string m_strCurrentOpenDate = "";
		private string m_strCreateUserID = "";
		protected com.digitalwave.Utility.Controls.ctlTimePicker m_dtpTOUXIRIQI;
		private System.Windows.Forms.Label label2;

        private System.Windows.Forms.DataGridTextBoxColumn m_dtcRecordDate_chr;
        private System.Windows.Forms.DataGridTextBoxColumn m_dtcTOUXIYA_CHR;
        private System.Windows.Forms.DataGridTextBoxColumn m_dtcJINGMAIYA_CHR;
        private System.Windows.Forms.DataGridTextBoxColumn m_dtcGANSULIANG_CHR;
        private System.Windows.Forms.DataGridTextBoxColumn m_dtcXUELIULIANG_CHR;
        private System.Windows.Forms.DataGridTextBoxColumn m_dtcTIWEN_CHR;
        private System.Windows.Forms.DataGridTextBoxColumn m_dtcMAIBO_CHR;
        private System.Windows.Forms.DataGridTextBoxColumn m_dtcXUEYA_CHR;
        private System.Windows.Forms.DataGridTextBoxColumn m_dtcHUXI_CHR;
        private System.Windows.Forms.DataGridTextBoxColumn m_dtcFALENG_CHR;
        private System.Windows.Forms.DataGridTextBoxColumn m_dtcFARE_CHR;
        private System.Windows.Forms.DataGridTextBoxColumn m_dtcTOUTONG_CHR;
        private System.Windows.Forms.DataGridTextBoxColumn m_dtcTUOSHUILIANG_CHR;
        private System.Windows.Forms.DataGridTextBoxColumn m_dtcOUTU_CHR;
        private System.Windows.Forms.DataGridTextBoxColumn m_dtcCHOUCHU_CHR;
        private System.Windows.Forms.DataGridTextBoxColumn m_dtcXINYI_CHR;
        private System.Windows.Forms.DataGridTextBoxColumn m_dtcNANONGDU_CHR;
        private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcCHULI_CHR;
        private System.Windows.Forms.DataGridTextBoxColumn m_dtcSIGN_CHR;
        private System.Windows.Forms.DataGridTextBoxColumn m_dtcTime_chr;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion


        clsEmrSignToolCollection m_objSign;
        private ctlComboBox m_cmbTOUXICISHU;
        private ctlComboBox m_cmbTOUXIHAO;
        private Label label3;
        private Label label1;
        private ctlComboBox m_cboYOUWUGANRAN;
        private Label label15;
        private Label label5;
        private Panel panel1;
        private Panel panel2;
        private TextBox m_txtTIZHONG_HOU;
        private TextBox m_txtTIZHONG_QIAN;
        private Label label11;
        private Label label9;
        protected ListView m_txtDoctor;
        private ColumnHeader clmEmployeeName;
        private PinkieControls.ButtonXP m_cmdDOCTORS;
        private PinkieControls.ButtonXP m_cmdNURSE;
        protected ListView m_txtNurse;
        private ColumnHeader columnHeader1;
        private PinkieControls.ButtonXP m_cmdTECHNICIAN;
        protected ListView m_txtTechnician;
        private ColumnHeader columnHeader2;
        private Panel panel4;
        private Label label18;
        private Panel panel3;
        private com.digitalwave.controls.ctlRichTextBox m_txtHuLiJiLu;
        private com.digitalwave.controls.ctlRichTextBox m_rtbZHENDUAN;
        private ctlComboBox m_cboTOUXISHIJIAN_FEN;
        private Label label4;
        private ctlComboBox m_cboTOUXISHIJIAN_XIAOSHI;
        private Label label6;
        private ctlComboBox m_cboGANSUHUA;
        private Label label10;
        private ctlComboBox m_cboTOUXIZHUANGZHIXINGHAO;
        private Label label16;
        private ctlComboBox m_cboYUJINGDANBAI;
        private Label label7;
        private ctlComboBox m_cboTOUXIYEPEIFANG;
        private Label label12;
        private ctlComboBox m_cboGANSU;
        private Label label17;
        private ctlComboBox m_cboPANGDAOFANGSHI;
        private Label label8;
        private Label label13;
        private Label label14;
        bool m_blnIsAddNew = true;
		#region constructor
		public frmBloodCleanseRecord()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
            m_BlnNeedContextMenu = true;
			m_objSign = new clsEmrSignToolCollection();
            //m_mthBindEmployeeSign(按钮,签名框,医生1or护士2,身份验证trueorfalse);
            m_objSign.m_mthBindEmployeeSign(m_cmdDOCTORS, m_txtDoctor, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdNURSE, m_txtNurse, 2, true, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdTECHNICIAN, m_txtTechnician, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBloodCleanseRecord));
            this.m_dtpTOUXIRIQI = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.m_dtcRecordDate_chr = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcTOUXIYA_CHR = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcJINGMAIYA_CHR = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcGANSULIANG_CHR = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcXUELIULIANG_CHR = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcTIWEN_CHR = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcMAIBO_CHR = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcXUEYA_CHR = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcHUXI_CHR = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcFALENG_CHR = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcFARE_CHR = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcTOUTONG_CHR = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcTUOSHUILIANG_CHR = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcOUTU_CHR = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcCHOUCHU_CHR = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcXINYI_CHR = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcNANONGDU_CHR = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcCHULI_CHR = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcSIGN_CHR = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcTime_chr = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_cmbTOUXIHAO = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cmbTOUXICISHU = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_cboYOUWUGANRAN = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_txtTIZHONG_HOU = new System.Windows.Forms.TextBox();
            this.m_txtTIZHONG_QIAN = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.m_txtDoctor = new System.Windows.Forms.ListView();
            this.clmEmployeeName = new System.Windows.Forms.ColumnHeader();
            this.m_cmdDOCTORS = new PinkieControls.ButtonXP();
            this.m_cmdNURSE = new PinkieControls.ButtonXP();
            this.m_txtNurse = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.m_cmdTECHNICIAN = new PinkieControls.ButtonXP();
            this.m_txtTechnician = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.panel4 = new System.Windows.Forms.Panel();
            this.m_cboTOUXISHIJIAN_FEN = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboTOUXISHIJIAN_XIAOSHI = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboGANSUHUA = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboTOUXIZHUANGZHIXINGHAO = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboYUJINGDANBAI = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboTOUXIYEPEIFANG = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboGANSU = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboPANGDAOFANGSHI = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_rtbZHENDUAN = new com.digitalwave.controls.ctlRichTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_txtHuLiJiLu = new com.digitalwave.controls.ctlRichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRecordDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtbRecords)).BeginInit();
            this.m_pnlNewBase.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgtsStyles
            // 
            this.dgtsStyles.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																										 this.m_dtcRecordDate_chr,
																										 this.m_dtcTOUXIYA_CHR,
																										 this.m_dtcJINGMAIYA_CHR,
																										 this.m_dtcGANSULIANG_CHR,
																										 this.m_dtcXUELIULIANG_CHR,
																										 this.m_dtcTIWEN_CHR,
																										 this.m_dtcMAIBO_CHR,
																										 this.m_dtcXUEYA_CHR,
                                                                                                         this.m_dtcHUXI_CHR,
                                                                                                         this.m_dtcFALENG_CHR,
                                                                                                         this.m_dtcFARE_CHR,
																										 this.m_dtcTOUTONG_CHR,
																										 this.m_dtcTUOSHUILIANG_CHR,
																										 this.m_dtcOUTU_CHR,
																										 this.m_dtcCHOUCHU_CHR,
																										 this.m_dtcXINYI_CHR,
																										 this.m_dtcNANONGDU_CHR,
																										 this.m_dtcCHULI_CHR,
                                                                                                         this.m_dtcSIGN_CHR
																										 });
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
            this.m_dtgRecordDetail.Location = new System.Drawing.Point(27, 246);
            this.m_dtgRecordDetail.PreferredColumnWidth = 55;
            this.m_dtgRecordDetail.Size = new System.Drawing.Size(771, 257);
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
            this.m_trvInPatientDate.Location = new System.Drawing.Point(-186, 128);
            this.m_trvInPatientDate.Size = new System.Drawing.Size(192, 10);
            this.m_trvInPatientDate.TabIndex = 3000;
            this.m_trvInPatientDate.Visible = false;
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(466, 43);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(542, 41);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(355, 49);
            this.lblBedNoTitle.Size = new System.Drawing.Size(56, 14);
            this.lblBedNoTitle.Text = "床  号:";
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(466, 50);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(513, 49);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(528, 45);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(513, 43);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(480, 49);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(315, 39);
            this.txtInPatientID.Size = new System.Drawing.Size(96, 23);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(329, 35);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(329, 42);
            this.m_txtBedNO.Size = new System.Drawing.Size(72, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(280, 39);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(-39, 105);
            this.m_lsvPatientName.Size = new System.Drawing.Size(45, 17);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(275, 34);
            this.m_lsvBedNO.Size = new System.Drawing.Size(24, 25);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(280, 36);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(352, 44);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(576, 30);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.m_cmdNext.Location = new System.Drawing.Point(355, 43);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(400, 42);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(483, 53);
            this.m_lblForTitle.Size = new System.Drawing.Size(8, 23);
            this.m_lblForTitle.Visible = false;
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(512, 44);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(729, 38);
            this.m_cmdModifyPatientInfo.Size = new System.Drawing.Size(69, 26);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Controls.Add(this.m_dtpTOUXIRIQI);
            this.m_pnlNewBase.Controls.Add(this.m_cmbTOUXICISHU);
            this.m_pnlNewBase.Controls.Add(this.m_cmbTOUXIHAO);
            this.m_pnlNewBase.Controls.Add(this.label3);
            this.m_pnlNewBase.Controls.Add(this.label1);
            this.m_pnlNewBase.Controls.Add(this.label2);
            this.m_pnlNewBase.Size = new System.Drawing.Size(810, 92);
            this.m_pnlNewBase.Visible = true;
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_ctlPatientInfo, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.label2, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.label1, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.label3, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_cmbTOUXIHAO, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_cmbTOUXICISHU, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_dtpTOUXIRIQI, 0);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(808, 61);
            // 
            // m_dtpTOUXIRIQI
            // 
            this.m_dtpTOUXIRIQI.BorderColor = System.Drawing.Color.Black;
            this.m_dtpTOUXIRIQI.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpTOUXIRIQI.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_dtpTOUXIRIQI.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpTOUXIRIQI.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpTOUXIRIQI.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpTOUXIRIQI.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_dtpTOUXIRIQI.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpTOUXIRIQI.Location = new System.Drawing.Point(447, 61);
            this.m_dtpTOUXIRIQI.m_BlnOnlyTime = false;
            this.m_dtpTOUXIRIQI.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpTOUXIRIQI.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpTOUXIRIQI.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpTOUXIRIQI.Name = "m_dtpTOUXIRIQI";
            this.m_dtpTOUXIRIQI.ReadOnly = false;
            this.m_dtpTOUXIRIQI.Size = new System.Drawing.Size(149, 22);
            this.m_dtpTOUXIRIQI.TabIndex = 4000;
            this.m_dtpTOUXIRIQI.TextBackColor = System.Drawing.Color.White;
            this.m_dtpTOUXIRIQI.TextForeColor = System.Drawing.Color.Black;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(5, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 10000004;
            this.label2.Text = "透析号：";
            // 
            // m_dtcRecordDate_chr
            // 
            this.m_dtcRecordDate_chr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcRecordDate_chr.Format = "";
            this.m_dtcRecordDate_chr.FormatInfo = null;
            this.m_dtcRecordDate_chr.MappingName = "RecordDate_chr";
            this.m_dtcRecordDate_chr.Width = 80;
            // 
            // m_dtcTOUXIYA_CHR
            // 
            this.m_dtcTOUXIYA_CHR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcTOUXIYA_CHR.Format = "";
            this.m_dtcTOUXIYA_CHR.FormatInfo = null;
            this.m_dtcTOUXIYA_CHR.MappingName = "TOUXIYA_CHR";
            this.m_dtcTOUXIYA_CHR.Width = 50;
            // 
            // m_dtcJINGMAIYA_CHR
            // 
            this.m_dtcJINGMAIYA_CHR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcJINGMAIYA_CHR.Format = "";
            this.m_dtcJINGMAIYA_CHR.FormatInfo = null;
            this.m_dtcJINGMAIYA_CHR.MappingName = "JINGMAIYA_CHR";
            this.m_dtcJINGMAIYA_CHR.Width = 50;
            // 
            // m_dtcGANSULIANG_CHR
            // 
            this.m_dtcGANSULIANG_CHR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcGANSULIANG_CHR.Format = "";
            this.m_dtcGANSULIANG_CHR.FormatInfo = null;
            this.m_dtcGANSULIANG_CHR.MappingName = "GANSULIANG_CHR";
            this.m_dtcGANSULIANG_CHR.Width = 30;
            // 
            // m_dtcXUELIULIANG_CHR
            // 
            this.m_dtcXUELIULIANG_CHR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcXUELIULIANG_CHR.Format = "";
            this.m_dtcXUELIULIANG_CHR.FormatInfo = null;
            this.m_dtcXUELIULIANG_CHR.MappingName = "XUELIULIANG_CHR";
            this.m_dtcXUELIULIANG_CHR.Width = 50;
            // 
            // m_dtcTIWEN_CHR
            // 
            this.m_dtcTIWEN_CHR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcTIWEN_CHR.Format = "";
            this.m_dtcTIWEN_CHR.FormatInfo = null;
            this.m_dtcTIWEN_CHR.MappingName = "TIWEN_CHR";
            this.m_dtcTIWEN_CHR.Width = 30;
            // 
            // m_dtcMAIBO_CHR
            // 
            this.m_dtcMAIBO_CHR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcMAIBO_CHR.Format = "";
            this.m_dtcMAIBO_CHR.FormatInfo = null;
            this.m_dtcMAIBO_CHR.MappingName = "MAIBO_CHR";
            this.m_dtcMAIBO_CHR.Width = 50;
            // 
            // m_dtcXUEYA_CHR
            // 
            this.m_dtcXUEYA_CHR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcXUEYA_CHR.Format = "";
            this.m_dtcXUEYA_CHR.FormatInfo = null;
            this.m_dtcXUEYA_CHR.MappingName = "XUEYA_CHR";
            this.m_dtcXUEYA_CHR.Width = 50;
            // 
            // m_dtcHUXI_CHR
            // 
            this.m_dtcHUXI_CHR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcHUXI_CHR.Format = "";
            this.m_dtcHUXI_CHR.FormatInfo = null;
            this.m_dtcHUXI_CHR.MappingName = "HUXI_CHR";
            this.m_dtcHUXI_CHR.Width = 50;
            // 
            // m_dtcFALENG_CHR
            // 
            this.m_dtcFALENG_CHR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcFALENG_CHR.Format = "";
            this.m_dtcFALENG_CHR.FormatInfo = null;
            this.m_dtcFALENG_CHR.MappingName = "FALENG_CHR";
            this.m_dtcFALENG_CHR.Width = 40;
            // 
            // m_dtcFARE_CHR
            // 
            this.m_dtcFARE_CHR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcFARE_CHR.Format = "";
            this.m_dtcFARE_CHR.FormatInfo = null;
            this.m_dtcFARE_CHR.MappingName = "FARE_CHR";
            this.m_dtcFARE_CHR.Width = 40;
            // 
            // m_dtcTOUTONG_CHR
            // 
            this.m_dtcTOUTONG_CHR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcTOUTONG_CHR.Format = "";
            this.m_dtcTOUTONG_CHR.FormatInfo = null;
            this.m_dtcTOUTONG_CHR.MappingName = "TOUTONG_CHR";
            this.m_dtcTOUTONG_CHR.Width = 40;
            // 
            // m_dtcTUOSHUILIANG_CHR
            // 
            this.m_dtcTUOSHUILIANG_CHR.Format = "";
            this.m_dtcTUOSHUILIANG_CHR.FormatInfo = null;
            this.m_dtcTUOSHUILIANG_CHR.Width = 40;
            // 
            // m_dtcOUTU_CHR
            // 
            this.m_dtcOUTU_CHR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcOUTU_CHR.Format = "";
            this.m_dtcOUTU_CHR.FormatInfo = null;
            this.m_dtcOUTU_CHR.MappingName = "OUTU_CHR";
            this.m_dtcOUTU_CHR.Width = 40;
            // 
            // m_dtcCHOUCHU_CHR
            // 
            this.m_dtcCHOUCHU_CHR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcCHOUCHU_CHR.Format = "";
            this.m_dtcCHOUCHU_CHR.FormatInfo = null;
            this.m_dtcCHOUCHU_CHR.MappingName = "CHOUCHU_CHR";
            this.m_dtcCHOUCHU_CHR.Width = 40;
            // 
            // m_dtcXINYI_CHR
            // 
            this.m_dtcXINYI_CHR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcXINYI_CHR.Format = "";
            this.m_dtcXINYI_CHR.FormatInfo = null;
            this.m_dtcXINYI_CHR.MappingName = "XINYI_CHR";
            this.m_dtcXINYI_CHR.Width = 40;
            // 
            // m_dtcNANONGDU_CHR
            // 
            this.m_dtcNANONGDU_CHR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcNANONGDU_CHR.Format = "";
            this.m_dtcNANONGDU_CHR.FormatInfo = null;
            this.m_dtcNANONGDU_CHR.MappingName = "NANONGDU_CHR";
            this.m_dtcNANONGDU_CHR.Width = 40;
            // 
            // m_dtcCHULI_CHR
            // 
            this.m_dtcCHULI_CHR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcCHULI_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcCHULI_CHR.m_BlnGobleSet = true;
            this.m_dtcCHULI_CHR.m_BlnUnderLineDST = false;
            this.m_dtcCHULI_CHR.MappingName = "CHULI_CHR";
            this.m_dtcCHULI_CHR.Width = 175;
            // 
            // m_dtcSIGN_CHR
            // 
            this.m_dtcSIGN_CHR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcSIGN_CHR.Format = "";
            this.m_dtcSIGN_CHR.FormatInfo = null;
            this.m_dtcSIGN_CHR.MappingName = "SIGN_CHR";
            this.m_dtcSIGN_CHR.Width = 75;
            // 
            // m_dtcTime_chr
            // 
            this.m_dtcTime_chr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcTime_chr.Format = "";
            this.m_dtcTime_chr.FormatInfo = null;
            this.m_dtcTime_chr.MappingName = "Time_chr";
            this.m_dtcTime_chr.Width = 45;
            // 
            // m_cmbTOUXIHAO
            // 
            this.m_cmbTOUXIHAO.AccessibleDescription = "透析号";
            this.m_cmbTOUXIHAO.BackColor = System.Drawing.SystemColors.Window;
            this.m_cmbTOUXIHAO.BorderColor = System.Drawing.Color.Black;
            this.m_cmbTOUXIHAO.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cmbTOUXIHAO.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cmbTOUXIHAO.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cmbTOUXIHAO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cmbTOUXIHAO.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmbTOUXIHAO.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmbTOUXIHAO.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cmbTOUXIHAO.ListBackColor = System.Drawing.Color.White;
            this.m_cmbTOUXIHAO.ListForeColor = System.Drawing.Color.Black;
            this.m_cmbTOUXIHAO.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cmbTOUXIHAO.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cmbTOUXIHAO.Location = new System.Drawing.Point(65, 61);
            this.m_cmbTOUXIHAO.m_BlnEnableItemEventMenu = true;
            this.m_cmbTOUXIHAO.Name = "m_cmbTOUXIHAO";
            this.m_cmbTOUXIHAO.SelectedIndex = -1;
            this.m_cmbTOUXIHAO.SelectedItem = null;
            this.m_cmbTOUXIHAO.SelectionStart = 0;
            this.m_cmbTOUXIHAO.Size = new System.Drawing.Size(139, 23);
            this.m_cmbTOUXIHAO.TabIndex = 10001402;
            this.m_cmbTOUXIHAO.TextBackColor = System.Drawing.Color.White;
            this.m_cmbTOUXIHAO.TextForeColor = System.Drawing.Color.Black;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(227, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 15);
            this.label1.TabIndex = 10000004;
            this.label1.Text = "第";
            // 
            // m_cmbTOUXICISHU
            // 
            this.m_cmbTOUXICISHU.AccessibleDescription = "透析次数";
            this.m_cmbTOUXICISHU.BackColor = System.Drawing.SystemColors.Window;
            this.m_cmbTOUXICISHU.BorderColor = System.Drawing.Color.Black;
            this.m_cmbTOUXICISHU.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cmbTOUXICISHU.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cmbTOUXICISHU.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cmbTOUXICISHU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cmbTOUXICISHU.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmbTOUXICISHU.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmbTOUXICISHU.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cmbTOUXICISHU.ListBackColor = System.Drawing.Color.White;
            this.m_cmbTOUXICISHU.ListForeColor = System.Drawing.Color.Black;
            this.m_cmbTOUXICISHU.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cmbTOUXICISHU.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cmbTOUXICISHU.Location = new System.Drawing.Point(252, 60);
            this.m_cmbTOUXICISHU.m_BlnEnableItemEventMenu = true;
            this.m_cmbTOUXICISHU.Name = "m_cmbTOUXICISHU";
            this.m_cmbTOUXICISHU.SelectedIndex = -1;
            this.m_cmbTOUXICISHU.SelectedItem = null;
            this.m_cmbTOUXICISHU.SelectionStart = 0;
            this.m_cmbTOUXICISHU.Size = new System.Drawing.Size(53, 23);
            this.m_cmbTOUXICISHU.TabIndex = 10001402;
            this.m_cmbTOUXICISHU.TextBackColor = System.Drawing.Color.White;
            this.m_cmbTOUXICISHU.TextForeColor = System.Drawing.Color.Black;
            this.m_cmbTOUXICISHU.Load += new System.EventHandler(this.ctlComboBox2_Load);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(311, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 15);
            this.label3.TabIndex = 10000004;
            this.label3.Text = "次透析，透析日期：";
            // 
            // m_cboYOUWUGANRAN
            // 
            this.m_cboYOUWUGANRAN.AccessibleDescription = "有无感染";
            this.m_cboYOUWUGANRAN.BackColor = System.Drawing.SystemColors.Window;
            this.m_cboYOUWUGANRAN.BorderColor = System.Drawing.Color.Black;
            this.m_cboYOUWUGANRAN.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboYOUWUGANRAN.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboYOUWUGANRAN.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboYOUWUGANRAN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboYOUWUGANRAN.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboYOUWUGANRAN.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboYOUWUGANRAN.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cboYOUWUGANRAN.ListBackColor = System.Drawing.Color.White;
            this.m_cboYOUWUGANRAN.ListForeColor = System.Drawing.Color.Black;
            this.m_cboYOUWUGANRAN.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboYOUWUGANRAN.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboYOUWUGANRAN.Location = new System.Drawing.Point(358, 158);
            this.m_cboYOUWUGANRAN.m_BlnEnableItemEventMenu = true;
            this.m_cboYOUWUGANRAN.Name = "m_cboYOUWUGANRAN";
            this.m_cboYOUWUGANRAN.SelectedIndex = -1;
            this.m_cboYOUWUGANRAN.SelectedItem = null;
            this.m_cboYOUWUGANRAN.SelectionStart = 0;
            this.m_cboYOUWUGANRAN.Size = new System.Drawing.Size(139, 23);
            this.m_cboYOUWUGANRAN.TabIndex = 10001402;
            this.m_cboYOUWUGANRAN.TextBackColor = System.Drawing.Color.White;
            this.m_cboYOUWUGANRAN.TextForeColor = System.Drawing.Color.Black;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(757, 191);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(22, 15);
            this.label15.TabIndex = 10000004;
            this.label15.Text = "分";
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(-1, -1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 27);
            this.label5.TabIndex = 10001403;
            this.label5.Text = "体  重";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Location = new System.Drawing.Point(28, 506);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(140, 71);
            this.panel1.TabIndex = 10001404;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.m_txtTIZHONG_HOU);
            this.panel2.Controls.Add(this.m_txtTIZHONG_QIAN);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(-1, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(106, 71);
            this.panel2.TabIndex = 10001404;
            // 
            // m_txtTIZHONG_HOU
            // 
            this.m_txtTIZHONG_HOU.AccessibleDescription = "体重>>后";
            this.m_txtTIZHONG_HOU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtTIZHONG_HOU.Location = new System.Drawing.Point(33, 48);
            this.m_txtTIZHONG_HOU.Multiline = true;
            this.m_txtTIZHONG_HOU.Name = "m_txtTIZHONG_HOU";
            this.m_txtTIZHONG_HOU.Size = new System.Drawing.Size(72, 22);
            this.m_txtTIZHONG_HOU.TabIndex = 10001405;
            this.m_txtTIZHONG_HOU.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // m_txtTIZHONG_QIAN
            // 
            this.m_txtTIZHONG_QIAN.AccessibleDescription = "体重>>前";
            this.m_txtTIZHONG_QIAN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtTIZHONG_QIAN.Location = new System.Drawing.Point(33, 25);
            this.m_txtTIZHONG_QIAN.Multiline = true;
            this.m_txtTIZHONG_QIAN.Name = "m_txtTIZHONG_QIAN";
            this.m_txtTIZHONG_QIAN.Size = new System.Drawing.Size(72, 24);
            this.m_txtTIZHONG_QIAN.TabIndex = 10001405;
            this.m_txtTIZHONG_QIAN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(-1, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 22);
            this.label11.TabIndex = 10001403;
            this.label11.Text = "后";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(-1, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 24);
            this.label9.TabIndex = 10001403;
            this.label9.Text = "前";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtDoctor
            // 
            this.m_txtDoctor.AccessibleDescription = "医生";
            this.m_txtDoctor.BackColor = System.Drawing.Color.White;
            this.m_txtDoctor.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmEmployeeName});
            this.m_txtDoctor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDoctor.ForeColor = System.Drawing.Color.Black;
            this.m_txtDoctor.FullRowSelect = true;
            this.m_txtDoctor.GridLines = true;
            this.m_txtDoctor.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_txtDoctor.Location = new System.Drawing.Point(85, 592);
            this.m_txtDoctor.Name = "m_txtDoctor";
            this.m_txtDoctor.Size = new System.Drawing.Size(154, 28);
            this.m_txtDoctor.TabIndex = 10001406;
            this.m_txtDoctor.UseCompatibleStateImageBehavior = false;
            this.m_txtDoctor.View = System.Windows.Forms.View.SmallIcon;
            // 
            // clmEmployeeName
            // 
            this.clmEmployeeName.Width = 55;
            // 
            // m_cmdDOCTORS
            // 
            this.m_cmdDOCTORS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdDOCTORS.DefaultScheme = true;
            this.m_cmdDOCTORS.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdDOCTORS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdDOCTORS.Hint = "";
            this.m_cmdDOCTORS.Location = new System.Drawing.Point(10, 592);
            this.m_cmdDOCTORS.Name = "m_cmdDOCTORS";
            this.m_cmdDOCTORS.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDOCTORS.Size = new System.Drawing.Size(69, 28);
            this.m_cmdDOCTORS.TabIndex = 10001407;
            this.m_cmdDOCTORS.Tag = "1";
            this.m_cmdDOCTORS.Text = "医生";
            // 
            // m_cmdNURSE
            // 
            this.m_cmdNURSE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdNURSE.DefaultScheme = true;
            this.m_cmdNURSE.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdNURSE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdNURSE.Hint = "";
            this.m_cmdNURSE.Location = new System.Drawing.Point(290, 592);
            this.m_cmdNURSE.Name = "m_cmdNURSE";
            this.m_cmdNURSE.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdNURSE.Size = new System.Drawing.Size(69, 28);
            this.m_cmdNURSE.TabIndex = 10001407;
            this.m_cmdNURSE.Tag = "1";
            this.m_cmdNURSE.Text = "护士";
            // 
            // m_txtNurse
            // 
            this.m_txtNurse.AccessibleDescription = "护士";
            this.m_txtNurse.BackColor = System.Drawing.Color.White;
            this.m_txtNurse.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.m_txtNurse.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtNurse.ForeColor = System.Drawing.Color.Black;
            this.m_txtNurse.FullRowSelect = true;
            this.m_txtNurse.GridLines = true;
            this.m_txtNurse.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_txtNurse.Location = new System.Drawing.Point(365, 592);
            this.m_txtNurse.Name = "m_txtNurse";
            this.m_txtNurse.Size = new System.Drawing.Size(154, 28);
            this.m_txtNurse.TabIndex = 10001406;
            this.m_txtNurse.UseCompatibleStateImageBehavior = false;
            this.m_txtNurse.View = System.Windows.Forms.View.SmallIcon;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 55;
            // 
            // m_cmdTECHNICIAN
            // 
            this.m_cmdTECHNICIAN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdTECHNICIAN.DefaultScheme = true;
            this.m_cmdTECHNICIAN.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdTECHNICIAN.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdTECHNICIAN.Hint = "";
            this.m_cmdTECHNICIAN.Location = new System.Drawing.Point(567, 592);
            this.m_cmdTECHNICIAN.Name = "m_cmdTECHNICIAN";
            this.m_cmdTECHNICIAN.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdTECHNICIAN.Size = new System.Drawing.Size(69, 28);
            this.m_cmdTECHNICIAN.TabIndex = 10001407;
            this.m_cmdTECHNICIAN.Tag = "1";
            this.m_cmdTECHNICIAN.Text = "技术员";
            // 
            // m_txtTechnician
            // 
            this.m_txtTechnician.AccessibleDescription = "技术员";
            this.m_txtTechnician.BackColor = System.Drawing.Color.White;
            this.m_txtTechnician.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.m_txtTechnician.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtTechnician.ForeColor = System.Drawing.Color.Black;
            this.m_txtTechnician.FullRowSelect = true;
            this.m_txtTechnician.GridLines = true;
            this.m_txtTechnician.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_txtTechnician.Location = new System.Drawing.Point(642, 592);
            this.m_txtTechnician.Name = "m_txtTechnician";
            this.m_txtTechnician.Size = new System.Drawing.Size(154, 28);
            this.m_txtTechnician.TabIndex = 10001406;
            this.m_txtTechnician.UseCompatibleStateImageBehavior = false;
            this.m_txtTechnician.View = System.Windows.Forms.View.SmallIcon;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 55;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.m_cboTOUXIYEPEIFANG);
            this.panel4.Controls.Add(this.m_cboGANSU);
            this.panel4.Controls.Add(this.m_cboPANGDAOFANGSHI);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Controls.Add(this.m_rtbZHENDUAN);
            this.panel4.Controls.Add(this.m_cboTOUXISHIJIAN_FEN);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.m_cboTOUXISHIJIAN_XIAOSHI);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.m_cboGANSUHUA);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.m_cboTOUXIZHUANGZHIXINGHAO);
            this.panel4.Controls.Add(this.label16);
            this.panel4.Controls.Add(this.m_cboYUJINGDANBAI);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.label17);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Location = new System.Drawing.Point(10, 105);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(810, 481);
            this.panel4.TabIndex = 10001408;
            // 
            // m_cboTOUXISHIJIAN_FEN
            // 
            this.m_cboTOUXISHIJIAN_FEN.AccessibleDescription = "透析时间>>分钟";
            this.m_cboTOUXISHIJIAN_FEN.BackColor = System.Drawing.SystemColors.Window;
            this.m_cboTOUXISHIJIAN_FEN.BorderColor = System.Drawing.Color.Black;
            this.m_cboTOUXISHIJIAN_FEN.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboTOUXISHIJIAN_FEN.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboTOUXISHIJIAN_FEN.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboTOUXISHIJIAN_FEN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboTOUXISHIJIAN_FEN.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboTOUXISHIJIAN_FEN.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboTOUXISHIJIAN_FEN.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cboTOUXISHIJIAN_FEN.ListBackColor = System.Drawing.Color.White;
            this.m_cboTOUXISHIJIAN_FEN.ListForeColor = System.Drawing.Color.Black;
            this.m_cboTOUXISHIJIAN_FEN.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboTOUXISHIJIAN_FEN.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboTOUXISHIJIAN_FEN.Location = new System.Drawing.Point(686, 86);
            this.m_cboTOUXISHIJIAN_FEN.m_BlnEnableItemEventMenu = true;
            this.m_cboTOUXISHIJIAN_FEN.Name = "m_cboTOUXISHIJIAN_FEN";
            this.m_cboTOUXISHIJIAN_FEN.SelectedIndex = -1;
            this.m_cboTOUXISHIJIAN_FEN.SelectedItem = null;
            this.m_cboTOUXISHIJIAN_FEN.SelectionStart = 0;
            this.m_cboTOUXISHIJIAN_FEN.Size = new System.Drawing.Size(59, 23);
            this.m_cboTOUXISHIJIAN_FEN.TabIndex = 10001422;
            this.m_cboTOUXISHIJIAN_FEN.TextBackColor = System.Drawing.Color.White;
            this.m_cboTOUXISHIJIAN_FEN.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboTOUXISHIJIAN_XIAOSHI
            // 
            this.m_cboTOUXISHIJIAN_XIAOSHI.AccessibleDescription = "透析时间>>小时";
            this.m_cboTOUXISHIJIAN_XIAOSHI.BackColor = System.Drawing.SystemColors.Window;
            this.m_cboTOUXISHIJIAN_XIAOSHI.BorderColor = System.Drawing.Color.Black;
            this.m_cboTOUXISHIJIAN_XIAOSHI.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboTOUXISHIJIAN_XIAOSHI.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboTOUXISHIJIAN_XIAOSHI.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboTOUXISHIJIAN_XIAOSHI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboTOUXISHIJIAN_XIAOSHI.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboTOUXISHIJIAN_XIAOSHI.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboTOUXISHIJIAN_XIAOSHI.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cboTOUXISHIJIAN_XIAOSHI.ListBackColor = System.Drawing.Color.White;
            this.m_cboTOUXISHIJIAN_XIAOSHI.ListForeColor = System.Drawing.Color.Black;
            this.m_cboTOUXISHIJIAN_XIAOSHI.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboTOUXISHIJIAN_XIAOSHI.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboTOUXISHIJIAN_XIAOSHI.Location = new System.Drawing.Point(576, 86);
            this.m_cboTOUXISHIJIAN_XIAOSHI.m_BlnEnableItemEventMenu = true;
            this.m_cboTOUXISHIJIAN_XIAOSHI.Name = "m_cboTOUXISHIJIAN_XIAOSHI";
            this.m_cboTOUXISHIJIAN_XIAOSHI.SelectedIndex = -1;
            this.m_cboTOUXISHIJIAN_XIAOSHI.SelectedItem = null;
            this.m_cboTOUXISHIJIAN_XIAOSHI.SelectionStart = 0;
            this.m_cboTOUXISHIJIAN_XIAOSHI.Size = new System.Drawing.Size(65, 23);
            this.m_cboTOUXISHIJIAN_XIAOSHI.TabIndex = 10001423;
            this.m_cboTOUXISHIJIAN_XIAOSHI.TextBackColor = System.Drawing.Color.White;
            this.m_cboTOUXISHIJIAN_XIAOSHI.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboGANSUHUA
            // 
            this.m_cboGANSUHUA.AccessibleDescription = "肝素化";
            this.m_cboGANSUHUA.BackColor = System.Drawing.SystemColors.Window;
            this.m_cboGANSUHUA.BorderColor = System.Drawing.Color.Black;
            this.m_cboGANSUHUA.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboGANSUHUA.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboGANSUHUA.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboGANSUHUA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboGANSUHUA.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboGANSUHUA.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboGANSUHUA.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cboGANSUHUA.ListBackColor = System.Drawing.Color.White;
            this.m_cboGANSUHUA.ListForeColor = System.Drawing.Color.Black;
            this.m_cboGANSUHUA.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboGANSUHUA.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboGANSUHUA.Location = new System.Drawing.Point(564, 57);
            this.m_cboGANSUHUA.m_BlnEnableItemEventMenu = true;
            this.m_cboGANSUHUA.Name = "m_cboGANSUHUA";
            this.m_cboGANSUHUA.SelectedIndex = -1;
            this.m_cboGANSUHUA.SelectedItem = null;
            this.m_cboGANSUHUA.SelectionStart = 0;
            this.m_cboGANSUHUA.Size = new System.Drawing.Size(200, 23);
            this.m_cboGANSUHUA.TabIndex = 10001420;
            this.m_cboGANSUHUA.TextBackColor = System.Drawing.Color.White;
            this.m_cboGANSUHUA.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboTOUXIZHUANGZHIXINGHAO
            // 
            this.m_cboTOUXIZHUANGZHIXINGHAO.AccessibleDescription = "透析装置型号";
            this.m_cboTOUXIZHUANGZHIXINGHAO.BackColor = System.Drawing.SystemColors.Window;
            this.m_cboTOUXIZHUANGZHIXINGHAO.BorderColor = System.Drawing.Color.Black;
            this.m_cboTOUXIZHUANGZHIXINGHAO.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboTOUXIZHUANGZHIXINGHAO.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboTOUXIZHUANGZHIXINGHAO.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboTOUXIZHUANGZHIXINGHAO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboTOUXIZHUANGZHIXINGHAO.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboTOUXIZHUANGZHIXINGHAO.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboTOUXIZHUANGZHIXINGHAO.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cboTOUXIZHUANGZHIXINGHAO.ListBackColor = System.Drawing.Color.White;
            this.m_cboTOUXIZHUANGZHIXINGHAO.ListForeColor = System.Drawing.Color.Black;
            this.m_cboTOUXIZHUANGZHIXINGHAO.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboTOUXIZHUANGZHIXINGHAO.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboTOUXIZHUANGZHIXINGHAO.Location = new System.Drawing.Point(459, 115);
            this.m_cboTOUXIZHUANGZHIXINGHAO.m_BlnEnableItemEventMenu = true;
            this.m_cboTOUXIZHUANGZHIXINGHAO.Name = "m_cboTOUXIZHUANGZHIXINGHAO";
            this.m_cboTOUXIZHUANGZHIXINGHAO.SelectedIndex = -1;
            this.m_cboTOUXIZHUANGZHIXINGHAO.SelectedItem = null;
            this.m_cboTOUXIZHUANGZHIXINGHAO.SelectionStart = 0;
            this.m_cboTOUXIZHUANGZHIXINGHAO.Size = new System.Drawing.Size(305, 23);
            this.m_cboTOUXIZHUANGZHIXINGHAO.TabIndex = 10001421;
            this.m_cboTOUXIZHUANGZHIXINGHAO.TextBackColor = System.Drawing.Color.White;
            this.m_cboTOUXIZHUANGZHIXINGHAO.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboYUJINGDANBAI
            // 
            this.m_cboYUJINGDANBAI.AccessibleDescription = "鱼精蛋白";
            this.m_cboYUJINGDANBAI.BackColor = System.Drawing.SystemColors.Window;
            this.m_cboYUJINGDANBAI.BorderColor = System.Drawing.Color.Black;
            this.m_cboYUJINGDANBAI.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboYUJINGDANBAI.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboYUJINGDANBAI.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboYUJINGDANBAI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboYUJINGDANBAI.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboYUJINGDANBAI.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboYUJINGDANBAI.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cboYUJINGDANBAI.ListBackColor = System.Drawing.Color.White;
            this.m_cboYUJINGDANBAI.ListForeColor = System.Drawing.Color.Black;
            this.m_cboYUJINGDANBAI.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboYUJINGDANBAI.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboYUJINGDANBAI.Location = new System.Drawing.Point(346, 86);
            this.m_cboYUJINGDANBAI.m_BlnEnableItemEventMenu = true;
            this.m_cboYUJINGDANBAI.Name = "m_cboYUJINGDANBAI";
            this.m_cboYUJINGDANBAI.SelectedIndex = -1;
            this.m_cboYUJINGDANBAI.SelectedItem = null;
            this.m_cboYUJINGDANBAI.SelectionStart = 0;
            this.m_cboYUJINGDANBAI.Size = new System.Drawing.Size(139, 23);
            this.m_cboYUJINGDANBAI.TabIndex = 10001426;
            this.m_cboYUJINGDANBAI.TextBackColor = System.Drawing.Color.White;
            this.m_cboYUJINGDANBAI.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboTOUXIYEPEIFANG
            // 
            this.m_cboTOUXIYEPEIFANG.AccessibleDescription = "透析液配方";
            this.m_cboTOUXIYEPEIFANG.BackColor = System.Drawing.SystemColors.Window;
            this.m_cboTOUXIYEPEIFANG.BorderColor = System.Drawing.Color.Black;
            this.m_cboTOUXIYEPEIFANG.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboTOUXIYEPEIFANG.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboTOUXIYEPEIFANG.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboTOUXIYEPEIFANG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboTOUXIYEPEIFANG.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboTOUXIYEPEIFANG.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboTOUXIYEPEIFANG.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cboTOUXIYEPEIFANG.ListBackColor = System.Drawing.Color.White;
            this.m_cboTOUXIYEPEIFANG.ListForeColor = System.Drawing.Color.Black;
            this.m_cboTOUXIYEPEIFANG.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboTOUXIYEPEIFANG.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboTOUXIYEPEIFANG.Location = new System.Drawing.Point(116, 115);
            this.m_cboTOUXIYEPEIFANG.m_BlnEnableItemEventMenu = true;
            this.m_cboTOUXIYEPEIFANG.Name = "m_cboTOUXIYEPEIFANG";
            this.m_cboTOUXIYEPEIFANG.SelectedIndex = -1;
            this.m_cboTOUXIYEPEIFANG.SelectedItem = null;
            this.m_cboTOUXIYEPEIFANG.SelectionStart = 0;
            this.m_cboTOUXIYEPEIFANG.Size = new System.Drawing.Size(216, 23);
            this.m_cboTOUXIYEPEIFANG.TabIndex = 10001427;
            this.m_cboTOUXIYEPEIFANG.TextBackColor = System.Drawing.Color.White;
            this.m_cboTOUXIYEPEIFANG.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboGANSU
            // 
            this.m_cboGANSU.AccessibleDescription = "肝素";
            this.m_cboGANSU.BackColor = System.Drawing.SystemColors.Window;
            this.m_cboGANSU.BorderColor = System.Drawing.Color.Black;
            this.m_cboGANSU.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboGANSU.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboGANSU.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboGANSU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboGANSU.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboGANSU.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboGANSU.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cboGANSU.ListBackColor = System.Drawing.Color.White;
            this.m_cboGANSU.ListForeColor = System.Drawing.Color.Black;
            this.m_cboGANSU.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboGANSU.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboGANSU.Location = new System.Drawing.Point(116, 86);
            this.m_cboGANSU.m_BlnEnableItemEventMenu = true;
            this.m_cboGANSU.Name = "m_cboGANSU";
            this.m_cboGANSU.SelectedIndex = -1;
            this.m_cboGANSU.SelectedItem = null;
            this.m_cboGANSU.SelectionStart = 0;
            this.m_cboGANSU.Size = new System.Drawing.Size(139, 23);
            this.m_cboGANSU.TabIndex = 10001424;
            this.m_cboGANSU.TextBackColor = System.Drawing.Color.White;
            this.m_cboGANSU.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboPANGDAOFANGSHI
            // 
            this.m_cboPANGDAOFANGSHI.AccessibleDescription = "旁道方式";
            this.m_cboPANGDAOFANGSHI.BackColor = System.Drawing.SystemColors.Window;
            this.m_cboPANGDAOFANGSHI.BorderColor = System.Drawing.Color.Black;
            this.m_cboPANGDAOFANGSHI.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboPANGDAOFANGSHI.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboPANGDAOFANGSHI.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboPANGDAOFANGSHI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboPANGDAOFANGSHI.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboPANGDAOFANGSHI.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboPANGDAOFANGSHI.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cboPANGDAOFANGSHI.ListBackColor = System.Drawing.Color.White;
            this.m_cboPANGDAOFANGSHI.ListForeColor = System.Drawing.Color.Black;
            this.m_cboPANGDAOFANGSHI.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboPANGDAOFANGSHI.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboPANGDAOFANGSHI.Location = new System.Drawing.Point(116, 57);
            this.m_cboPANGDAOFANGSHI.m_BlnEnableItemEventMenu = true;
            this.m_cboPANGDAOFANGSHI.Name = "m_cboPANGDAOFANGSHI";
            this.m_cboPANGDAOFANGSHI.SelectedIndex = -1;
            this.m_cboPANGDAOFANGSHI.SelectedItem = null;
            this.m_cboPANGDAOFANGSHI.SelectionStart = 0;
            this.m_cboPANGDAOFANGSHI.Size = new System.Drawing.Size(139, 23);
            this.m_cboPANGDAOFANGSHI.TabIndex = 10001425;
            this.m_cboPANGDAOFANGSHI.TextBackColor = System.Drawing.Color.White;
            this.m_cboPANGDAOFANGSHI.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_rtbZHENDUAN
            // 
            this.m_rtbZHENDUAN.AccessibleDescription = "诊断";
            this.m_rtbZHENDUAN.BackColor = System.Drawing.Color.White;
            this.m_rtbZHENDUAN.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_rtbZHENDUAN.ForeColor = System.Drawing.Color.Black;
            this.m_rtbZHENDUAN.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_rtbZHENDUAN.Location = new System.Drawing.Point(64, 8);
            this.m_rtbZHENDUAN.m_BlnIgnoreUserInfo = false;
            this.m_rtbZHENDUAN.m_BlnPartControl = false;
            this.m_rtbZHENDUAN.m_BlnReadOnly = false;
            this.m_rtbZHENDUAN.m_BlnUnderLineDST = false;
            this.m_rtbZHENDUAN.m_ClrDST = System.Drawing.Color.Red;
            this.m_rtbZHENDUAN.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_rtbZHENDUAN.m_IntCanModifyTime = 6;
            this.m_rtbZHENDUAN.m_IntPartControlLength = 0;
            this.m_rtbZHENDUAN.m_IntPartControlStartIndex = 0;
            this.m_rtbZHENDUAN.m_StrUserID = "";
            this.m_rtbZHENDUAN.m_StrUserName = "";
            this.m_rtbZHENDUAN.Name = "m_rtbZHENDUAN";
            this.m_rtbZHENDUAN.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_rtbZHENDUAN.Size = new System.Drawing.Size(722, 45);
            this.m_rtbZHENDUAN.TabIndex = 10001419;
            this.m_rtbZHENDUAN.Text = "";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(501, 59);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 15);
            this.label14.TabIndex = 10001418;
            this.label14.Text = "肝素化：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(502, 88);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 15);
            this.label13.TabIndex = 10001411;
            this.label13.Text = "透析时间：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(643, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 15);
            this.label8.TabIndex = 10001412;
            this.label8.Text = "小时";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(350, 118);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(112, 15);
            this.label17.TabIndex = 10001409;
            this.label17.Text = "透析装置型号：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(269, 88);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 15);
            this.label12.TabIndex = 10001410;
            this.label12.Text = "鱼精蛋白：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(269, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 15);
            this.label7.TabIndex = 10001413;
            this.label7.Text = "有无感染：";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(24, 118);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(97, 15);
            this.label16.TabIndex = 10001416;
            this.label16.Text = "透析液配方：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(53, 88);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 15);
            this.label10.TabIndex = 10001417;
            this.label10.Text = "肝  素：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(39, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 10001414;
            this.label6.Text = "旁道方式：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(6, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 15);
            this.label4.TabIndex = 10001415;
            this.label4.Text = "诊  断：";
            // 
            // label18
            // 
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label18.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(104, -1);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 71);
            this.label18.TabIndex = 10001403;
            this.label18.Text = "护 理 记 录";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.m_txtHuLiJiLu);
            this.panel3.Location = new System.Drawing.Point(155, 399);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(624, 71);
            this.panel3.TabIndex = 10001428;
            // 
            // m_txtHuLiJiLu
            // 
            this.m_txtHuLiJiLu.AccessibleDescription = "护理记录";
            this.m_txtHuLiJiLu.BackColor = System.Drawing.Color.White;
            this.m_txtHuLiJiLu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtHuLiJiLu.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtHuLiJiLu.ForeColor = System.Drawing.Color.Black;
            this.m_txtHuLiJiLu.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtHuLiJiLu.Location = new System.Drawing.Point(0, 0);
            this.m_txtHuLiJiLu.m_BlnIgnoreUserInfo = false;
            this.m_txtHuLiJiLu.m_BlnPartControl = false;
            this.m_txtHuLiJiLu.m_BlnReadOnly = false;
            this.m_txtHuLiJiLu.m_BlnUnderLineDST = false;
            this.m_txtHuLiJiLu.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtHuLiJiLu.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtHuLiJiLu.m_IntCanModifyTime = 6;
            this.m_txtHuLiJiLu.m_IntPartControlLength = 0;
            this.m_txtHuLiJiLu.m_IntPartControlStartIndex = 0;
            this.m_txtHuLiJiLu.m_StrUserID = "";
            this.m_txtHuLiJiLu.m_StrUserName = "";
            this.m_txtHuLiJiLu.Name = "m_txtHuLiJiLu";
            this.m_txtHuLiJiLu.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtHuLiJiLu.Size = new System.Drawing.Size(622, 69);
            this.m_txtHuLiJiLu.TabIndex = 10001301;
            this.m_txtHuLiJiLu.Text = "";
            // 
            // frmBloodCleanseRecord
            // 
            this.AccessibleDescription = "血液净化记录表";
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(776, 643);
            this.Controls.Add(this.m_txtTechnician);
            this.Controls.Add(this.m_txtNurse);
            this.Controls.Add(this.m_txtDoctor);
            this.Controls.Add(this.m_cmdTECHNICIAN);
            this.Controls.Add(this.m_cmdNURSE);
            this.Controls.Add(this.m_cmdDOCTORS);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_cboYOUWUGANRAN);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.panel4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBloodCleanseRecord";
            this.Text = "血液净化记录表";
            this.Load += new System.EventHandler(this.frmBloodCleanseRecord_Load);
            this.Controls.SetChildIndex(this.panel4, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.m_cboYOUWUGANRAN, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.m_cmdDOCTORS, 0);
            this.Controls.SetChildIndex(this.m_cmdNURSE, 0);
            this.Controls.SetChildIndex(this.m_cmdTECHNICIAN, 0);
            this.Controls.SetChildIndex(this.m_txtDoctor, 0);
            this.Controls.SetChildIndex(this.m_txtNurse, 0);
            this.Controls.SetChildIndex(this.m_txtTechnician, 0);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_trvInPatientDate, 0);
            this.Controls.SetChildIndex(this.m_dtgRecordDetail, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRecordDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtbRecords)).EndInit();
            this.m_pnlNewBase.ResumeLayout(false);
            this.m_pnlNewBase.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
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
        // 注意，DataTable的第一个Column必须是存放记录的CreateDate时间的字符串，第二个Column必须是存放记录类型的int值，第三个Column必须是存放记录的OpenDate
		protected override void m_mthInitDataTable(DataTable p_dtbRecordTable)
		{

			//存放记录的CreateDate时间的字符串
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

            DataColumn dc3 = p_dtbRecordTable.Columns.Add("TOUXIYA_CHR");//6
            dc3.DefaultValue = "";
            DataColumn dc4 = p_dtbRecordTable.Columns.Add("JINGMAIYA_CHR");//7
            dc4.DefaultValue = "";
            DataColumn dc5 = p_dtbRecordTable.Columns.Add("GANSULIANG_CHR");//8
            dc5.DefaultValue = "";
            DataColumn dc6 = p_dtbRecordTable.Columns.Add("XUELIULIANG_CHR");//9
            dc6.DefaultValue = "";
            DataColumn dc7 = p_dtbRecordTable.Columns.Add("TIWEN_CHR");//10
            dc7.DefaultValue = "";
            DataColumn dc8 = p_dtbRecordTable.Columns.Add("MAIBO_CHR");//11
            dc8.DefaultValue = "";
            DataColumn dc9 = p_dtbRecordTable.Columns.Add("XUEYA_CHR");//12	
            dc9.DefaultValue = "";
            DataColumn dc10 = p_dtbRecordTable.Columns.Add("HUXI_CHR");//13
            dc10.DefaultValue = "";
            DataColumn dc11 = p_dtbRecordTable.Columns.Add("FALENG_CHR");//14
            dc11.DefaultValue = "";
            DataColumn dc12= p_dtbRecordTable.Columns.Add("FARE_CHR");//15
            dc12.DefaultValue = "";
            DataColumn dc13 = p_dtbRecordTable.Columns.Add("TOUTONG_CHR");//16
            dc13.DefaultValue = "";
            DataColumn dc14 = p_dtbRecordTable.Columns.Add("TUOSHUILIANG_CHR");//17
            dc14.DefaultValue = "";
            DataColumn dc15 = p_dtbRecordTable.Columns.Add("OUTU_CHR");//18
            dc15.DefaultValue = "";
            DataColumn dc16 = p_dtbRecordTable.Columns.Add("CHOUCHU_CHR");//19
            dc16.DefaultValue = "";
            DataColumn dc17 = p_dtbRecordTable.Columns.Add("XINYI_CHR");//20
            dc17.DefaultValue = "";
            DataColumn dc18 = p_dtbRecordTable.Columns.Add("NANONGDU_CHR");//21
            dc18.DefaultValue = "";
            p_dtbRecordTable.Columns.Add("CHULI_CHR", typeof(com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue));//22
            DataColumn dc19 = p_dtbRecordTable.Columns.Add("SIGN_CHR");//23
            dc19.DefaultValue = "";
            p_dtbRecordTable.Columns.Add("CreateUserID");//24

			m_mthSetControl(m_dtcRecordDate_chr);
			m_mthSetControl(m_dtcTime_chr);

            m_mthSetControl(m_dtcTOUXIYA_CHR);
            m_mthSetControl(m_dtcJINGMAIYA_CHR);
            m_mthSetControl(m_dtcGANSULIANG_CHR);
            m_mthSetControl(m_dtcXUELIULIANG_CHR);
            m_mthSetControl(m_dtcTIWEN_CHR);
            m_mthSetControl(m_dtcMAIBO_CHR);
            m_mthSetControl(m_dtcXUEYA_CHR);
            m_mthSetControl(m_dtcHUXI_CHR);
            m_mthSetControl(m_dtcFALENG_CHR);
            m_mthSetControl(m_dtcFARE_CHR);
            m_mthSetControl(m_dtcTOUTONG_CHR);
            m_mthSetControl(m_dtcTUOSHUILIANG_CHR);
            m_mthSetControl(m_dtcOUTU_CHR);
            m_mthSetControl(m_dtcCHOUCHU_CHR);
            m_mthSetControl(m_dtcXINYI_CHR);
            m_mthSetControl(m_dtcNANONGDU_CHR);
            m_mthSetControl(m_dtcCHULI_CHR);
            m_mthSetControl(m_dtcSIGN_CHR);

			//设置文字栏
            this.m_dtcRecordDate_chr.HeaderText = "\r\n日    期";
            this.m_dtcTime_chr.HeaderText = "\r\n时    间";

            this.m_dtcTOUXIYA_CHR.HeaderText = "透\r\n析\r\n压\r\nmmHg";
            this.m_dtcJINGMAIYA_CHR.HeaderText = "静\r\n脉\r\n压\r\nmmHg";

            this.m_dtcGANSULIANG_CHR.HeaderText = "肝\r\n素\r\n量\r\nmg";

            this.m_dtcXUELIULIANG_CHR.HeaderText = "血\r\n流\r\n量\r\nml/min";
            this.m_dtcTIWEN_CHR.HeaderText = "体\r\n\r\n温\r\n℃";
            this.m_dtcMAIBO_CHR.HeaderText = "脉\r\n\r\n搏\r\n次/分";
            this.m_dtcXUEYA_CHR.HeaderText = "血\r\n\r\n压\r\nkpa";
            this.m_dtcHUXI_CHR.HeaderText = "呼\r\n\r\n吸\r\n次/分";

            this.m_dtcFALENG_CHR.HeaderText = "发\r\n\r\n冷";
            this.m_dtcFARE_CHR.HeaderText = "发\r\n\r\n热";
            this.m_dtcTOUTONG_CHR.HeaderText = "头\r\n\r\n痛";
            this.m_dtcTUOSHUILIANG_CHR.HeaderText = "脱\r\n水\r\n量";
            this.m_dtcOUTU_CHR.HeaderText = "呕\r\n\r\n吐";

            this.m_dtcCHOUCHU_CHR.HeaderText = "抽\r\n\r\n搐";
            this.m_dtcXINYI_CHR.HeaderText = "心\r\n\r\n翳";
            this.m_dtcNANONGDU_CHR.HeaderText = "钠\r\n浓\r\n度";
            this.m_dtcCHULI_CHR.HeaderText = "\r\n处     理";
            this.m_dtcSIGN_CHR.HeaderText = "\r\n签     名";

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
            m_mthClearLaycountAll();
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
            return new clsRecordsDomain(enmRecordsType.frmBloodCleanseRecord);
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
				case enmDiseaseTrackType.frmBloodCleanseRecord:
                    objContent = new clsDialyseRecord_Value();//(需要改动)
					break;
			}

			if(objContent == null)
                objContent = new clsDialyseRecord_Value();	//(需要改动)
		
			if(m_objCurrentPatient !=null)
				objContent.m_strInPatientID=m_objCurrentPatient.m_StrInPatientID;
			else 
			{
				clsPublicFunction.ShowInformationMessageBox("当前病人为空!");
				return null;
			}
			objContent.m_dtmInPatientDate=m_objCurrentPatient.m_DtmSelectedInDate;
            objContent.m_dtmRecordDate = DateTime.Parse((string)p_objDataArr[0]);
			objContent.m_dtmCreateDate = DateTime.Parse((string)p_objDataArr[2]);
			objContent.m_dtmOpenDate = DateTime.Parse((string)p_objDataArr[2]);
			objContent.m_dtmModifyDate = DateTime.Parse((string)p_objDataArr[3]);

            objContent.m_strCreateUserID = (string)p_objDataArr[24];
			return objContent;
		}

		private void frmBloodCleanseRecord_Load(object sender, System.EventArgs e)
		{
            if (m_BlnNeedContextMenu)
                m_mthAddRichTemplateInContainer(this);
			m_dtmPreRecordDate = DateTime.MinValue;
			m_dtgRecordDetail.Focus();
			m_mniAddBlank.Visible=false;
			m_mniDeleteBlank.Visible=false;	
		
		}

        protected override void m_mthAddRichTemplateInContainer(Control p_ctlContainer)
        {
            m_mthSetRichTemplateInContainer(panel4);
        }
		// 获取处理（添加和修改）记录的窗体。
		protected override frmDiseaseTrackBase m_frmGetRecordForm(int p_intRecordType)
		{
			frmBloodCleanseRecordCon frmwcon = new frmBloodCleanseRecordCon();
			return  frmwcon;
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
			m_mthAddNewRecord((int)enmDiseaseTrackType.frmBloodCleanseRecord);//(需要改动)
		}

		protected override infPrintRecord m_objGetPrintTool()
		{			
			clsBloodCleanseRecordPrintTool frmwcon = new clsBloodCleanseRecordPrintTool();
			return frmwcon;
		}

		private void m_mthClearLaycountAll()
		{
            m_cmbTOUXIHAO.m_mthClearValue();
            m_cmbTOUXICISHU.m_mthClearValue();
            m_dtpTOUXIRIQI.Value = DateTime.Now;
            m_rtbZHENDUAN.Clear();
            m_cboPANGDAOFANGSHI.m_mthClearValue();
            m_cboYOUWUGANRAN.m_mthClearValue();
            m_cboGANSUHUA.m_mthClearValue();
            m_cboGANSU.m_mthClearValue();
            m_cboYUJINGDANBAI.m_mthClearValue();
            m_cboTOUXISHIJIAN_XIAOSHI.m_mthClearValue();
            m_cboTOUXISHIJIAN_FEN.m_mthClearValue();
            m_cboTOUXIYEPEIFANG.m_mthClearValue();
            m_cboTOUXIZHUANGZHIXINGHAO.m_mthClearValue();
            m_txtTIZHONG_QIAN.Text = string.Empty;
            m_txtTIZHONG_HOU.Text = string.Empty;
            m_txtHuLiJiLu.Clear();
            m_txtDoctor.Items.Clear();
            m_txtNurse.Items.Clear();
            m_txtTechnician.Items.Clear();
		}
		protected override object[][] m_objGetRecordsValueArr(clsTransDataInfo p_objTransDataInfo)
		{
            return null;
		}
		private void m_cmdSave_Click(object sender, System.EventArgs e)
		{
        }

        protected override bool m_BlnIsAddNew
        {
            get
            {
                return m_blnIsAddNew;
            }
        }	
        #region 对基本内容的处理

        protected override long m_lngSubModify()
        {
            if (/*m_trvInPatientDate.SelectedNode == null || m_trvInPatientDate.SelectedNode == m_trvInPatientDate.Nodes[0] || */m_objCurrentPatient == null)
            {
                clsPublicFunction.ShowInformationMessageBox("未选定病人或记录,无法保存!");
                return (long)enmOperationResult.Parameter_Error;
            }

            com.digitalwave.clsRecordsService.clsBloodCleanseRecord_MainService objServ =
                (com.digitalwave.clsRecordsService.clsBloodCleanseRecord_MainService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsRecordsService.clsBloodCleanseRecord_MainService));

            long lngRes = 0;
            clsBloodCleanseBaseRecord_Value objValue = m_txtHuLiJiLu.Tag as clsBloodCleanseBaseRecord_Value;
            if (objValue == null)
                return (long)enmOperationResult.DB_Fail;
                objValue.m_strModifyUserID = clsEMR_StaticObject.s_ObjCurrentEmployee.m_strEMPID_CHR;
                objValue.m_dtmModifyDate = new clsPublicDomain().m_dtmGetServerTime();

            objValue.m_dtmRecordDate = DateTime.Now;
            objValue.m_strTOUXIHAO = m_cmbTOUXIHAO.Text;
            objValue.m_strTOTALBLOODNUM_CHR = m_cmbTOUXICISHU.Text;
            objValue.m_strTOUXIRIQI_CHR = m_dtpTOUXIRIQI.Value.ToString("yyyy-MM-dd HH:mm:ss");
            objValue.m_strZHENDUAN_CHR_RIGHT = m_rtbZHENDUAN.m_strGetRightText();
            objValue.m_strZHENDUAN_CHR = m_rtbZHENDUAN.Text;
            objValue.m_strZHENDUAN_CHRXML = m_rtbZHENDUAN.m_strGetXmlText();
            objValue.m_strPANGDAOFANGSHI_CHR = m_cboPANGDAOFANGSHI.Text;
            objValue.m_strYOUWUGANRAN_CHR = m_cboYOUWUGANRAN.Text;
            objValue.m_strGANSUHUA_CHR = m_cboGANSUHUA.Text;
            objValue.m_strGANSU_CHR = m_cboGANSU.Text;
            objValue.m_strYUJINGDANBAI_CHR = m_cboYUJINGDANBAI.Text;
            objValue.m_strTOUXISHIJIAN_SHI_CHR = m_cboTOUXISHIJIAN_XIAOSHI.Text;
            objValue.m_strTOUXISHIJIAN_FEN_CHR = m_cboTOUXISHIJIAN_FEN.Text;
            objValue.m_strTOUXIYEPEIFANG_CHR = m_cboTOUXIYEPEIFANG.Text;
            objValue.m_strZHUANGZHIXINGHAO_CHR = m_cboTOUXIZHUANGZHIXINGHAO.Text;
            objValue.m_strTIZHONG_QIAN_CHR = m_txtTIZHONG_QIAN.Text;
            objValue.m_strTIZHONG_HOU_CHR = m_txtTIZHONG_HOU.Text;
            objValue.m_strHULIJILU_CHR = m_txtHuLiJiLu.Text;
            objValue.m_strHULIJILU_CHR_RIGHT = m_txtHuLiJiLu.m_strGetRightText();
            objValue.m_strHULIJILU_CHRXML = m_txtHuLiJiLu.m_strGetXmlText();

            string strUserIDList = "";
            string strUserNameList = "";
            m_mthGetSignArr(new Control[] { m_txtDoctor, m_txtNurse, m_txtTechnician }, ref objValue.objSignerArr, ref strUserIDList, ref strUserNameList);
            objValue.m_strRecordUserID = strUserIDList;

            #region 多签名时验证所有签名者 并保存

                //数字签名 
                //记录ID通常为 住院号＋住院时间 || 住院号＋记录时间 来识别唯一 格式 00000056-2005-10-10 10:20:20
                clsEmrDigitalSign_VO objSign_VO = new clsEmrDigitalSign_VO();
                objSign_VO.m_strFORMID_VCHR = this.Name;
                objSign_VO.m_strFORMRECORDID_VCHR = m_objCurrentPatient.m_StrInPatientID.Trim() + "-" + m_objCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss");
                objSign_VO.m_strSIGNIDID_VCHR = clsEMRLogin.LoginInfo.m_strEmpID;
                objSign_VO.m_strRegisterId = m_objBaseCurrentPatient.m_StrRegisterId;
            if (objValue.objSignerArr != null)
            {
                ArrayList objSignerArr = new ArrayList();
                for (int i = 0 ; i < objValue.objSignerArr.Length ; i++)
                {
                    if (objValue.objSignerArr[i].controlName == "m_txtDoctor" || objValue.objSignerArr[i].controlName == "m_txtNurse" || objValue.objSignerArr[i].controlName == "m_txtTechnician")
                        objSignerArr.Add(objValue.objSignerArr[i].objEmployee);
                }
                clsCheckSignersController objCheck = new clsCheckSignersController(objSignerArr, false);
                if (objCheck.CheckSigner(objValue, objSign_VO) == -1)
                    return -1;

            }
            else
            {
                clsCheckSignersController objCheck = new clsCheckSignersController();
                if (objCheck.m_lngSign(objValue, objSign_VO) == -1)
                    return -1;
            }
            #endregion
            lngRes = objServ.m_lngModifyRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, objValue);
            return lngRes;
        }
        protected override long m_lngSubAddNew()
        {
            if (/*m_trvInPatientDate.SelectedNode == null || m_trvInPatientDate.SelectedNode == m_trvInPatientDate.Nodes[0] || */m_objCurrentPatient == null)
            {
                clsPublicFunction.ShowInformationMessageBox("未选定病人或记录,无法保存!");
                return (long)enmOperationResult.Parameter_Error;
            }
            if (this.m_txtDoctor.Items.Count  == 0)
            {
                clsPublicFunction.ShowInformationMessageBox("记录人没有签名!");
                return (long)enmOperationResult.Parameter_Error;
            }

            com.digitalwave.clsRecordsService.clsBloodCleanseRecord_MainService objServ =
                (com.digitalwave.clsRecordsService.clsBloodCleanseRecord_MainService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsRecordsService.clsBloodCleanseRecord_MainService));

            long lngRes = 0;
            clsBloodCleanseBaseRecord_Value objValue = new clsBloodCleanseBaseRecord_Value();
            objValue.m_strRegisterID = m_objCurrentPatient.m_StrRegisterId;
            objValue.m_dtmCreateDate = new clsPublicDomain().m_dtmGetServerTime();
            objValue.m_dtmModifyDate = objValue.m_dtmCreateDate;
            objValue.m_strCreateUserID = clsEMR_StaticObject.s_ObjCurrentEmployee.m_strEMPID_CHR;
            objValue.m_strModifyUserID = objValue.m_strCreateUserID;
            objValue.m_dtmRecordDate = DateTime.Now;

            objValue.m_strTOUXIHAO = m_cmbTOUXIHAO.Text;
            objValue.m_strTOTALBLOODNUM_CHR = m_cmbTOUXICISHU.Text;
            objValue.m_strTOUXIRIQI_CHR = m_dtpTOUXIRIQI.Value.ToString("yyyy-MM-dd HH:mm:ss");
            objValue.m_strZHENDUAN_CHR_RIGHT = m_rtbZHENDUAN.m_strGetRightText();
            objValue.m_strZHENDUAN_CHR = m_rtbZHENDUAN.Text;
            objValue.m_strZHENDUAN_CHRXML = m_rtbZHENDUAN.m_strGetXmlText();
            objValue.m_strPANGDAOFANGSHI_CHR = m_cboPANGDAOFANGSHI.Text;
            objValue.m_strYOUWUGANRAN_CHR = m_cboYOUWUGANRAN.Text;
            objValue.m_strGANSUHUA_CHR = m_cboGANSUHUA.Text;
            objValue.m_strGANSU_CHR = m_cboGANSU.Text;
            objValue.m_strYUJINGDANBAI_CHR = m_cboYUJINGDANBAI.Text;
            objValue.m_strTOUXISHIJIAN_SHI_CHR = m_cboTOUXISHIJIAN_XIAOSHI.Text;
            objValue.m_strTOUXISHIJIAN_FEN_CHR = m_cboTOUXISHIJIAN_FEN.Text;
            objValue.m_strTOUXIYEPEIFANG_CHR = m_cboTOUXIYEPEIFANG.Text;
            objValue.m_strZHUANGZHIXINGHAO_CHR = m_cboTOUXIZHUANGZHIXINGHAO.Text;
            objValue.m_strTIZHONG_QIAN_CHR = m_txtTIZHONG_QIAN.Text;
            objValue.m_strTIZHONG_HOU_CHR = m_txtTIZHONG_HOU.Text;
            objValue.m_strHULIJILU_CHR = m_txtHuLiJiLu.Text;
            objValue.m_strHULIJILU_CHR_RIGHT = m_txtHuLiJiLu.m_strGetRightText();
            objValue.m_strHULIJILU_CHRXML = m_txtHuLiJiLu.m_strGetXmlText();

            string strUserIDList = "";
            string strUserNameList = "";
            m_mthGetSignArr(new Control[] { m_txtDoctor, m_txtNurse, m_txtTechnician }, ref objValue.objSignerArr, ref strUserIDList, ref strUserNameList);
            objValue.m_strRecordUserID = strUserIDList;

            #region 多签名时验证所有签名者 并保存

                //数字签名 
                //记录ID通常为 住院号＋住院时间 || 住院号＋记录时间 来识别唯一 格式 00000056-2005-10-10 10:20:20
                clsEmrDigitalSign_VO objSign_VO = new clsEmrDigitalSign_VO();
                objSign_VO.m_strFORMID_VCHR = this.Name;
                objSign_VO.m_strFORMRECORDID_VCHR = m_objCurrentPatient.m_StrInPatientID.Trim() + "-" + m_objCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss");
                objSign_VO.m_strSIGNIDID_VCHR = clsEMRLogin.LoginInfo.m_strEmpID;
                objSign_VO.m_strRegisterId = m_objBaseCurrentPatient.m_StrRegisterId;
            if (objValue.objSignerArr != null)
            {
                ArrayList objSignerArr = new ArrayList();
                for (int i = 0 ; i < objValue.objSignerArr.Length ; i++)
                {
                    if (objValue.objSignerArr[i].controlName == "m_txtDoctor" || objValue.objSignerArr[i].controlName == "m_txtNurse" || objValue.objSignerArr[i].controlName == "m_txtTechnician")
                        objSignerArr.Add(objValue.objSignerArr[i].objEmployee);
                }
                clsCheckSignersController objCheck = new clsCheckSignersController(objSignerArr, false);
                if (objCheck.CheckSigner(objValue, objSign_VO) == -1)
                    return -1;
            }
            else
            {
                clsCheckSignersController objCheck = new clsCheckSignersController();
                if (objCheck.m_lngSign(objValue, objSign_VO) == -1)
                    return -1;
            }
            #endregion
            lngRes = objServ.m_lngAddNewRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, objValue);
            return lngRes;
        }

		#endregion 
        private object[][] m_objGetRecordsValue(clsDialyseRecordArr p_objTransDataInfo)
		{
            #region 显示记录到DataGrid
            try
            {
                if (p_objTransDataInfo == null)
                    return null;

                object[] objData;
                ArrayList objReturnData = new ArrayList();

                clsDSTRichTextBoxValue objclsDSTRichTextBoxValue;
                string strText, strXml;

                clsDialyseRecordArr objICUInfo = p_objTransDataInfo;



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

                for (int i = 0 ; i < intRecordCount ; i++)
                {
                    objData = new object[25];   // DataTable的列数
                    clsDialyseRecord_Value objCurrent = objICUInfo.m_objRecordArr[i];
                    clsDialyseRecord_Value objNext = new clsDialyseRecord_Value();//下一条记录//(需要改动)
                    if (i < intRecordCount - 1)
                        objNext = objICUInfo.m_objRecordArr[i + 1];

                    //如果该护理记录是修改前的记录且是在指定时间内修改的，则不显示
                    //if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate)
                    //{
                    //    TimeSpan tsModify = objNext.m_dtmModifyDate - objCurrent.m_dtmModifyDate;
                    //    if ((int)tsModify.TotalHours < intCanModifyTime)
                    //        continue;
                    //}


                    #region 存放关键字段
                    if (objCurrent.m_dtmCreateDate != DateTime.MinValue)
                    {
                        objData[0] = objCurrent.m_dtmCreateDate;//存放记录CreateDate的时间的字符串
                        objData[1] = (int)enmRecordsType.frmBloodCleanseRecord;//存放记录类型的int值  //(需要改动)
                        objData[2] = objCurrent.m_dtmCreateDate;//存放记录的OpenDate字符串
                        objData[3] = objCurrent.m_dtmModifyDate;//存放记录的ModifyDate字符串   
                        //objData[3] = objICUInfo.m_objRecordArr[objICUInfo.m_objRecordArr.Length - 1].m_dtmModifyDate;//存放记录的ModifyDate字符串   


                        //同一个则只在第一行显示日期
                        if (objCurrent.m_dtmRecordDate.Date.ToString() != m_dtmPreRecordDate.Date.ToString())//m_dtmRECORDDATE
                        {
                            objData[4] = objCurrent.m_dtmRecordDate.Date.ToString("yyyy-MM-dd");//日期字符串
                        }
                        //修改后带有痕迹的记录不再显示时间
                        //if (m_dtmPreRecordDate != objCurrent.m_dtmCreateDate)
                        //    objData[5] = objCurrent.m_dtmCreateDate.ToString("HH:mm");//时间字符串

                    }
                    m_dtmPreRecordDate = objCurrent.m_dtmRecordDate;
                    #endregion

                    #region 存放单项信息
                    //透析压
                    objData[6] = objCurrent.m_strTOUXIYA_CHR;
                    //静脉压
                    objData[7] = objCurrent.m_strJINGMAI_CHR;
                    //肝素量
                    objData[8] = objCurrent.m_strGANSULIANG_CHR;
                    //血流量
                    objData[9] = objCurrent.m_strXUELIULIANG_CHR;
                    //体温
                    objData[10] = objCurrent.m_strTIWEN_CHR;
                    //脉搏
                    objData[11] = objCurrent.m_strMAIBO_CHR;
                    //血压
                    objData[12] = objCurrent.m_strXUEYA_CHR;
                    //呼吸
                    objData[13] = objCurrent.m_strHUXI_CHR;
                    //发冷
                    objData[14] = objCurrent.m_strFALENG_CHR;
                    //发热
                    objData[15] = objCurrent.m_strFARE_CHR;
                    //头痛
                    objData[16] = objCurrent.m_strTOUTONG_CHR;
                    //脱水量
                    objData[17] = objCurrent.m_strTUOSHUILIANG_CHR;
                    //呕吐
                    objData[18] = objCurrent.m_strOUTU_CHR;
                    //抽搐
                    objData[19] = objCurrent.m_strCHOUCHU_CHR;
                    //心翳
                    objData[20] = objCurrent.m_strXINYI_CHR;
                    //钠浓度
                    objData[21] = objCurrent.m_strNANONGDU_CHR;

                    //处理
                    strText = objCurrent.m_strCHULI_CHR_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strCHULI_CHR_RIGHT != objCurrent.m_strCHULI_CHR_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(objCurrent.m_strCHULI_CHR_RIGHT, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[22] = objclsDSTRichTextBoxValue;

                    //签名
                    objData[23] = objCurrent.m_strRECORDUSERNAME_CHR;

                    objData[24] = objCurrent.m_strCreateUserID;//

                    objReturnData.Add(objData);

                    #endregion
                }
                object[][] m_objRe = new object[objReturnData.Count][];

                for (int m = 0 ; m < objReturnData.Count ; m++)
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
        protected override void m_mthGetTransDataInfoArr(out clsTransDataInfo[] p_objTansDataInfoArr)
        {
            m_objRecordsDomain.m_lngGetTransDataInfoArr(m_objCurrentPatient.m_StrRegisterId, out p_objTansDataInfoArr);

        }
		protected override void m_trvInPatientDate_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
            try
            {
                //清空病人记录信息				
                m_mthClearPatientRecordInfo();

                if (m_trvInPatientDate.SelectedNode == null || m_trvInPatientDate.SelectedNode == m_trvInPatientDate.Nodes[0] || m_objCurrentPatient == null)
                {
                    return;
                }

                //设置病人当次住院的基本信息
                m_mthOnlySetPatientInfo(m_objCurrentPatient);
                m_objCurrentPatient.m_ObjPeopleInfo = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(m_trvInPatientDate.Nodes[0].Nodes.Count - m_trvInPatientDate.SelectedNode.Index - 1).m_ObjPeopleInfo;

                string m_strInPatientID = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(m_trvInPatientDate.Nodes[0].Nodes.Count - m_trvInPatientDate.SelectedNode.Index - 1).m_StrEMRInPatientID;
                string m_strInPatientDate = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(m_trvInPatientDate.Nodes[0].Nodes.Count - m_trvInPatientDate.SelectedNode.Index - 1).m_DtmEMRInDate.ToString("yyyy-MM-dd HH:mm:ss");

                txtInPatientID.Text = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(m_trvInPatientDate.Nodes[0].Nodes.Count - m_trvInPatientDate.SelectedNode.Index - 1).m_StrHISInPatientID;
                m_objCurrentPatient.m_DtmSelectedInDate = DateTime.Parse(m_strInPatientDate);
                m_objCurrentPatient.m_StrHISInPatientID = txtInPatientID.Text;
                m_objCurrentPatient.m_DtmSelectedHISInDate = Convert.ToDateTime(m_trvInPatientDate.SelectedNode.Text);

                #region 获取病人当次入院登记号
                string strRegisterID = "";

                com.digitalwave.PatientManagerService.clsPatientManagerService objServ =
                    (com.digitalwave.PatientManagerService.clsPatientManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.PatientManagerService.clsPatientManagerService));

                long lngRes = objServ.m_lngGetRegisterIDByPatient(m_objCurrentPatient.m_StrPatientID, m_objCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"), out strRegisterID);
                if (!string.IsNullOrEmpty(strRegisterID))
                {
                    com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR = strRegisterID;
                    m_objCurrentPatient.m_StrRegisterId = strRegisterID;
                    m_objBaseCurrentPatient.m_StrRegisterId = strRegisterID;
                }
                #endregion

                m_mthIsReadOnly();
                if (!m_blnCanShowRecordContent())
                {
                    clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                    return;
                }

                //获取病人记录列表
                clsTransDataInfo[] objTansDataInfoArr;
                m_mthGetTransDataInfoArr(out objTansDataInfoArr);
                //long lngRes = m_objRecordsDomain.m_lngGetTransDataInfoArr(m_strInPatientID,m_strInPatientDate,out objTansDataInfoArr);

                if (objTansDataInfoArr == null)
                {
                    return;
                }

                //按记录时间(CreateDate)排序
                //m_mthSortTransData(ref objTansDataInfoArr);

                DataTable dtbAddBlank;
                clsDiseaseTrackAddBlankDomain objAddBlankDomain = new clsDiseaseTrackAddBlankDomain();
                objAddBlankDomain.m_lngGetBlankRecordContent(m_objCurrentPatient.m_StrInPatientID, m_objCurrentPatient.m_DtmSelectedInDate, out dtbAddBlank);

                clsBloodCleanRecordValueContentDataInfo objICUInfo = new clsBloodCleanRecordValueContentDataInfo();

                objICUInfo = (clsBloodCleanRecordValueContentDataInfo)objTansDataInfoArr[0];

                if (objICUInfo.m_objDialyseRecordValues != null)
                {
                    //添加记录到的DataTable
                    object[][] objDataArr;
                    for (int i1 = 0; i1 < objICUInfo.m_objDialyseRecordValues.Length; i1++)
                    {
                        objDataArr = m_objGetRecordsValue(objICUInfo.m_objDialyseRecordValues[i1]);

                        if (objDataArr == null)
                            continue;
                        m_dtbRecords.BeginLoadData();
                        for (int j2 = 0 ; j2 < objDataArr.Length ; j2++)
                        {
                            m_dtbRecords.LoadDataRow(objDataArr[j2], true);
                        }
                        m_dtbRecords.EndLoadData();
                        m_dtgRecordDetail.EnsureVisible(m_dtbRecords.Rows.Count - 1);
                    }
                }
                if (objICUInfo.m_objBloodCleanseBaseRecord != null)
                {
                    m_cmbTOUXIHAO.Text = objICUInfo.m_objBloodCleanseBaseRecord.m_strTOUXIHAO;
                    m_cmbTOUXICISHU.Text = objICUInfo.m_objBloodCleanseBaseRecord.m_strTOTALBLOODNUM_CHR;
                    m_dtpTOUXIRIQI.Value = DateTime.Parse(objICUInfo.m_objBloodCleanseBaseRecord.m_strTOUXIRIQI_CHR);
                    m_rtbZHENDUAN.m_mthSetNewText(objICUInfo.m_objBloodCleanseBaseRecord.m_strZHENDUAN_CHR, objICUInfo.m_objBloodCleanseBaseRecord.m_strZHENDUAN_CHRXML);
                    m_cboPANGDAOFANGSHI.Text = objICUInfo.m_objBloodCleanseBaseRecord.m_strPANGDAOFANGSHI_CHR;
                    m_cboYOUWUGANRAN.Text = objICUInfo.m_objBloodCleanseBaseRecord.m_strYOUWUGANRAN_CHR;
                    m_cboGANSUHUA.Text = objICUInfo.m_objBloodCleanseBaseRecord.m_strGANSUHUA_CHR;
                    m_cboGANSU.Text = objICUInfo.m_objBloodCleanseBaseRecord.m_strGANSU_CHR;
                    m_cboYUJINGDANBAI.Text = objICUInfo.m_objBloodCleanseBaseRecord.m_strYUJINGDANBAI_CHR;
                    m_cboTOUXISHIJIAN_XIAOSHI.Text = objICUInfo.m_objBloodCleanseBaseRecord.m_strTOUXISHIJIAN_SHI_CHR;
                    m_cboTOUXISHIJIAN_FEN.Text = objICUInfo.m_objBloodCleanseBaseRecord.m_strTOUXISHIJIAN_FEN_CHR;
                    m_cboTOUXIYEPEIFANG.Text = objICUInfo.m_objBloodCleanseBaseRecord.m_strTOUXIYEPEIFANG_CHR;
                    m_cboTOUXIZHUANGZHIXINGHAO.Text = objICUInfo.m_objBloodCleanseBaseRecord.m_strZHUANGZHIXINGHAO_CHR;
                    m_txtTIZHONG_QIAN.Text = objICUInfo.m_objBloodCleanseBaseRecord.m_strTIZHONG_QIAN_CHR;
                    m_txtTIZHONG_HOU.Text = objICUInfo.m_objBloodCleanseBaseRecord.m_strTIZHONG_HOU_CHR;
                    m_txtHuLiJiLu.m_mthSetNewText(objICUInfo.m_objBloodCleanseBaseRecord.m_strHULIJILU_CHR, objICUInfo.m_objBloodCleanseBaseRecord.m_strHULIJILU_CHRXML);

                    m_mthAddSignToListView(m_txtDoctor, objICUInfo.m_objBloodCleanseBaseRecord.objSignerArr);
                    m_mthAddSignToListView(m_txtNurse, objICUInfo.m_objBloodCleanseBaseRecord.objSignerArr);
                    m_mthAddSignToListView(m_txtTechnician, objICUInfo.m_objBloodCleanseBaseRecord.objSignerArr);
                    m_strCurrentOpenDate = objICUInfo.m_objBloodCleanseBaseRecord.m_dtmCreateDate.ToString();
                    m_txtHuLiJiLu.Tag = objICUInfo.m_objBloodCleanseBaseRecord;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
			
		}

        private void m_cmdDelete_Click(object sender, EventArgs e)
        {
        }


        protected override long m_lngSubDelete()
        {
            //检查当前病人变量是否为null  
            if (m_objCurrentPatient == null)
            {
                clsPublicFunction.ShowInformationMessageBox("未选定病人,无法删除!");
                return (long)enmOperationResult.Parameter_Error;
            }
            //检查当前记录是否为null
            //			if(m_objCurrentRecordContent==null)
            if (m_txtHuLiJiLu.Tag == null)
            {
                clsPublicFunction.ShowInformationMessageBox("当前记录内容为空,无法删除!");
                return (long)enmOperationResult.Parameter_Error;
            }
            //获取服务器时间      
            clsPublicDomain m_objPDomain = new clsPublicDomain();

            clsBloodCleanseBaseRecord_Value objValue = m_txtHuLiJiLu.Tag as clsBloodCleanseBaseRecord_Value;
            if (objValue == null)
                return 0;
            //权限判断
            string strDeptIDTemp = m_ObjCurrentEmrPatientSession.m_strAreaId;
            bool blnIsAllow = clsPublicFunction.IsAllowDelete(strDeptIDTemp, objValue.m_strCreateUserID, clsEMRLogin.LoginEmployee, 1);
            if (!blnIsAllow)
                return -1;

            objValue.m_bytStatus = 0;
            objValue.m_dtmDeActivedDate = m_objPDomain.m_dtmGetServerTime();
            objValue.m_strDeActivedOperatorID = com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_ObjCurrentEmployee.m_strEMPID_CHR;

            com.digitalwave.clsRecordsService.clsBloodCleanseRecord_MainService objServ =
                (com.digitalwave.clsRecordsService.clsBloodCleanseRecord_MainService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsRecordsService.clsBloodCleanseRecord_MainService));

            long lngRes = objServ.m_lngDeleteRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, objValue);
            return lngRes;
            
        }


        protected override void m_mthSave()
        {
            if (m_txtHuLiJiLu.Tag == null)
                m_blnIsAddNew = true;
            else
                m_blnIsAddNew = false;
            long lngRes = m_lngSave();
            if (lngRes > 0)
            {
                com.digitalwave.clsRecordsService.clsBloodCleanseRecord_MainService objServ =
                    (com.digitalwave.clsRecordsService.clsBloodCleanseRecord_MainService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsRecordsService.clsBloodCleanseRecord_MainService));

                clsBloodCleanseBaseRecord_Value objValue = null;
                lngRes = objServ.m_lngGetRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, m_objCurrentPatient.m_StrRegisterId, out objValue);
                if (lngRes > 0 && objValue != null)
                {
                    m_cmbTOUXIHAO.Text = objValue.m_strTOUXIHAO;
                    m_cmbTOUXICISHU.Text = objValue.m_strTOTALBLOODNUM_CHR;
                    m_dtpTOUXIRIQI.Value = DateTime.Parse(objValue.m_strTOUXIRIQI_CHR);
                    m_rtbZHENDUAN.m_mthSetNewText(objValue.m_strZHENDUAN_CHR, objValue.m_strZHENDUAN_CHRXML);
                    m_cboPANGDAOFANGSHI.Text = objValue.m_strPANGDAOFANGSHI_CHR;
                    m_cboYOUWUGANRAN.Text = objValue.m_strYOUWUGANRAN_CHR;
                    m_cboGANSUHUA.Text = objValue.m_strGANSUHUA_CHR;
                    m_cboGANSU.Text = objValue.m_strGANSU_CHR;
                    m_cboYUJINGDANBAI.Text = objValue.m_strYUJINGDANBAI_CHR;
                    m_cboTOUXISHIJIAN_XIAOSHI.Text = objValue.m_strTOUXISHIJIAN_SHI_CHR;
                    m_cboTOUXISHIJIAN_FEN.Text = objValue.m_strTOUXISHIJIAN_FEN_CHR;
                    m_cboTOUXIYEPEIFANG.Text = objValue.m_strTOUXIYEPEIFANG_CHR;
                    m_cboTOUXIZHUANGZHIXINGHAO.Text = objValue.m_strZHUANGZHIXINGHAO_CHR;
                    m_txtTIZHONG_QIAN.Text = objValue.m_strTIZHONG_QIAN_CHR;
                    m_txtTIZHONG_HOU.Text = objValue.m_strTIZHONG_HOU_CHR;
                    m_txtHuLiJiLu.m_mthSetNewText(objValue.m_strHULIJILU_CHR, objValue.m_strHULIJILU_CHRXML);

                    m_mthAddSignToListView(m_txtDoctor, objValue.objSignerArr);
                    m_mthAddSignToListView(m_txtNurse, objValue.objSignerArr);
                    m_mthAddSignToListView(m_txtTechnician, objValue.objSignerArr);
                    m_strCurrentOpenDate = objValue.m_dtmCreateDate.ToString();
                    m_txtHuLiJiLu.Tag = objValue;
                }
                clsPublicFunction.ShowInformationMessageBox("保存成功！");
                //m_tipMain.Show("保存成功！", this, m_gpbAnam.Left, m_gpbAnam.Top, 2000);
            }
            else
                clsPublicFunction.ShowInformationMessageBox("保存失败！");
                //m_tipMain.Show("保存失败！", this, m_gpbAnam.Left, m_gpbAnam.Top, 2000);
        }

        protected override void m_mthDelete()
        {
            long lngRes = m_lngDelete();
            if (lngRes > 0)
            {
                clsPublicFunction.ShowInformationMessageBox("删除成功！");
                //m_tipMain.Show("删除成功！", m_gpbAnam, m_gpbAnam.Left, m_gpbAnam.Top, 2000);
                m_mthClearLaycountAll();
            }
            else
            {
                clsPublicFunction.ShowInformationMessageBox("删除失败！");
                //m_tipMain.Show("删除失败！", m_gpbAnam, m_gpbAnam.Left, m_gpbAnam.Top, 2000);
            }
        }

        protected override void m_mthPerformSessionChanged(clsEmrPatientSessionInfo_VO p_objSelectedSession, int p_intIndex)
        {
            if (p_objSelectedSession == null) return;
            try
            {
                if (m_dtgRecordDetail == null) return;

                //清空病人记录信息				
                m_mthClearPatientRecordInfo();

                if (p_objSelectedSession == null || m_objCurrentPatient == null)
                {
                    return;
                }

                m_objCurrentPatient.m_DtmSelectedInDate = p_objSelectedSession.m_dtmEMRInpatientDate;
                m_objCurrentPatient.m_StrHISInPatientID = p_objSelectedSession.m_strHISInpatientId;
                m_objCurrentPatient.m_DtmSelectedHISInDate = p_objSelectedSession.m_dtmHISInpatientDate;

                m_objCurrentPatient.m_StrRegisterId = p_objSelectedSession.m_strRegisterId;
                m_objBaseCurrentPatient.m_StrRegisterId = p_objSelectedSession.m_strRegisterId;

                //设置病人当次住院的基本信息
                m_mthOnlySetPatientInfo(m_objCurrentPatient);

                m_mthIsReadOnly();
                if (!m_blnCanShowRecordContent())
                {
                    clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                    return;
                }

                //获取病人记录列表
                clsTransDataInfo[] objTansDataInfoArr;
                m_mthGetTransDataInfoArr(out objTansDataInfoArr);
                //long lngRes = m_objRecordsDomain.m_lngGetTransDataInfoArr(m_strInPatientID,m_strInPatientDate,out objTansDataInfoArr);

                if (objTansDataInfoArr == null)
                {
                    return;
                }

                //按记录时间(CreateDate)排序
                //m_mthSortTransData(ref objTansDataInfoArr);

                DataTable dtbAddBlank;
                clsDiseaseTrackAddBlankDomain objAddBlankDomain = new clsDiseaseTrackAddBlankDomain();
                objAddBlankDomain.m_lngGetBlankRecordContent(m_objCurrentPatient.m_StrInPatientID, m_objCurrentPatient.m_DtmSelectedInDate, out dtbAddBlank);

                clsBloodCleanRecordValueContentDataInfo objICUInfo = new clsBloodCleanRecordValueContentDataInfo();

                objICUInfo = (clsBloodCleanRecordValueContentDataInfo)objTansDataInfoArr[0];

                if (objICUInfo.m_objDialyseRecordValues != null)
                {
                    //添加记录到的DataTable
                    object[][] objDataArr;
                    for (int i1 = 0; i1 < objICUInfo.m_objDialyseRecordValues.Length; i1++)
                    {
                        objDataArr = m_objGetRecordsValue(objICUInfo.m_objDialyseRecordValues[i1]);

                        if (objDataArr == null)
                            continue;
                        m_dtbRecords.BeginLoadData();
                        for (int j2 = 0; j2 < objDataArr.Length; j2++)
                        {
                            m_dtbRecords.LoadDataRow(objDataArr[j2], true);
                        }
                        m_dtbRecords.EndLoadData();
                        m_dtgRecordDetail.EnsureVisible(m_dtbRecords.Rows.Count - 1);
                    }
                }
                if (objICUInfo.m_objBloodCleanseBaseRecord != null)
                {
                    m_cmbTOUXIHAO.Text = objICUInfo.m_objBloodCleanseBaseRecord.m_strTOUXIHAO;
                    m_cmbTOUXICISHU.Text = objICUInfo.m_objBloodCleanseBaseRecord.m_strTOTALBLOODNUM_CHR;
                    m_dtpTOUXIRIQI.Value = DateTime.Parse(objICUInfo.m_objBloodCleanseBaseRecord.m_strTOUXIRIQI_CHR);
                    m_rtbZHENDUAN.m_mthSetNewText(objICUInfo.m_objBloodCleanseBaseRecord.m_strZHENDUAN_CHR, objICUInfo.m_objBloodCleanseBaseRecord.m_strZHENDUAN_CHRXML);
                    m_cboPANGDAOFANGSHI.Text = objICUInfo.m_objBloodCleanseBaseRecord.m_strPANGDAOFANGSHI_CHR;
                    m_cboYOUWUGANRAN.Text = objICUInfo.m_objBloodCleanseBaseRecord.m_strYOUWUGANRAN_CHR;
                    m_cboGANSUHUA.Text = objICUInfo.m_objBloodCleanseBaseRecord.m_strGANSUHUA_CHR;
                    m_cboGANSU.Text = objICUInfo.m_objBloodCleanseBaseRecord.m_strGANSU_CHR;
                    m_cboYUJINGDANBAI.Text = objICUInfo.m_objBloodCleanseBaseRecord.m_strYUJINGDANBAI_CHR;
                    m_cboTOUXISHIJIAN_XIAOSHI.Text = objICUInfo.m_objBloodCleanseBaseRecord.m_strTOUXISHIJIAN_SHI_CHR;
                    m_cboTOUXISHIJIAN_FEN.Text = objICUInfo.m_objBloodCleanseBaseRecord.m_strTOUXISHIJIAN_FEN_CHR;
                    m_cboTOUXIYEPEIFANG.Text = objICUInfo.m_objBloodCleanseBaseRecord.m_strTOUXIYEPEIFANG_CHR;
                    m_cboTOUXIZHUANGZHIXINGHAO.Text = objICUInfo.m_objBloodCleanseBaseRecord.m_strZHUANGZHIXINGHAO_CHR;
                    m_txtTIZHONG_QIAN.Text = objICUInfo.m_objBloodCleanseBaseRecord.m_strTIZHONG_QIAN_CHR;
                    m_txtTIZHONG_HOU.Text = objICUInfo.m_objBloodCleanseBaseRecord.m_strTIZHONG_HOU_CHR;
                    m_txtHuLiJiLu.m_mthSetNewText(objICUInfo.m_objBloodCleanseBaseRecord.m_strHULIJILU_CHR, objICUInfo.m_objBloodCleanseBaseRecord.m_strHULIJILU_CHRXML);

                    m_mthAddSignToListView(m_txtDoctor, objICUInfo.m_objBloodCleanseBaseRecord.objSignerArr);
                    m_mthAddSignToListView(m_txtNurse, objICUInfo.m_objBloodCleanseBaseRecord.objSignerArr);
                    m_mthAddSignToListView(m_txtTechnician, objICUInfo.m_objBloodCleanseBaseRecord.objSignerArr);
                    m_strCurrentOpenDate = objICUInfo.m_objBloodCleanseBaseRecord.m_dtmCreateDate.ToString();
                    m_txtHuLiJiLu.Tag = objICUInfo.m_objBloodCleanseBaseRecord;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }

        protected override void m_mthAddFormStatusForClosingSave()
        {
            //记录设置窗体当前状态
            MDIParent.s_ObjSaveCue.m_mthAddFormStatus(this);
        }

        private void ctlComboBox2_Load(object sender, EventArgs e)
        {

        }
    }
}

