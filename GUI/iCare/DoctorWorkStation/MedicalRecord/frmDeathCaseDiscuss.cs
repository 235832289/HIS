using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using com.digitalwave.emr.BEDExplorer;
using System.Windows.Forms;
using iCareData;
using com.digitalwave.Utility.Controls;
using System.Data;
using HRP;
using com.digitalwave.Emr.Signature_gui;
using com.digitalwave.emr.AssistModuleVO;


namespace iCare
{
	/// <summary>
	/// 死亡病例讨论（独立版）
	/// </summary>
	public class frmDeathCaseDiscuss : iCare.frmDiseaseTrackBase
	{
		protected com.digitalwave.Utility.Controls.ctlTimePicker m_dtpDeadDate;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox m_txtDiscussAddress;
		private System.Windows.Forms.Label m_lblInHospitalTime;
		private PinkieControls.ButtonXP m_cmdAddress;
        private PinkieControls.ButtonXP m_cmdCompere;
		private PinkieControls.ButtonXP m_cmdAttendee;
		private System.Windows.Forms.ColumnHeader clmEmployeeName;
		private System.Windows.Forms.ColumnHeader clmEmployyID;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label2;
		private com.digitalwave.controls.ctlRichTextBox m_txtSpeakRecord;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private com.digitalwave.controls.ctlRichTextBox m_txtVerdict;
		private com.digitalwave.controls.ctlRichTextBox m_txtDeadDiagnose;
		private com.digitalwave.controls.ctlRichTextBox m_txtDeadReason;
		private com.digitalwave.controls.ctlRichTextBox m_txtExperience;
		private com.digitalwave.controls.ctlRichTextBox m_txtInHospitalDiagnose;
		private TextBox m_txtRecorder;

		protected System.Windows.Forms.ListView m_lsvAttendeeList;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		protected com.digitalwave.Utility.Controls.ctlTimePicker m_dtpDiscussTime;

		private PinkieControls.ButtonXP m_cmdRecord;
		private PinkieControls.ButtonXP m_cmdCompereSign;
		private TextBox m_txtCompere;
		private TextBox m_txtCompereSign;
        private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
        //定义签名类
        private clsEmrSignToolCollection m_objSign;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
        private Label label10;

		public frmDeathCaseDiscuss()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
            //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{	m_lsvAttendeeList });

			m_mthSetRichTextBoxAttribInControl(this);
            //指明医生工作站表单
            intFormType = 1;
			this.Text="死亡病例讨论记录";			
			this.m_lblForTitle.Text=this.Text;		

            m_objSign = new clsEmrSignToolCollection();
            //主持
            m_objSign.m_mthBindEmployeeSign(m_cmdCompere, m_txtCompere, 1, false, clsEMRLogin.LoginInfo.m_strEmpID);
            //记录者
            m_objSign.m_mthBindEmployeeSign(m_cmdRecord, m_txtRecorder, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            //参加人员
            m_objSign.m_mthBindEmployeeSign(m_cmdAttendee, m_lsvAttendeeList, 0, false, clsEMRLogin.LoginInfo.m_strEmpID);
            //主持人审阅签名
            m_objSign.m_mthBindEmployeeSign(m_cmdCompereSign, m_txtCompereSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
		}

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDeathCaseDiscuss));
            this.m_dtpDeadDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_dtpDiscussTime = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtDiscussAddress = new System.Windows.Forms.TextBox();
            this.m_lblInHospitalTime = new System.Windows.Forms.Label();
            this.m_cmdAddress = new PinkieControls.ButtonXP();
            this.m_cmdCompere = new PinkieControls.ButtonXP();
            this.m_cmdAttendee = new PinkieControls.ButtonXP();
            this.m_lsvAttendeeList = new System.Windows.Forms.ListView();
            this.clmEmployeeName = new System.Windows.Forms.ColumnHeader();
            this.clmEmployyID = new System.Windows.Forms.ColumnHeader();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtSpeakRecord = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtVerdict = new com.digitalwave.controls.ctlRichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_txtDeadDiagnose = new com.digitalwave.controls.ctlRichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.m_txtDeadReason = new com.digitalwave.controls.ctlRichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.m_txtExperience = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtInHospitalDiagnose = new com.digitalwave.controls.ctlRichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.m_txtRecorder = new System.Windows.Forms.TextBox();
            this.m_cmdRecord = new PinkieControls.ButtonXP();
            this.m_cmdCompereSign = new PinkieControls.ButtonXP();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.m_txtCompere = new System.Windows.Forms.TextBox();
            this.m_txtCompereSign = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.m_pnlNewBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_trvCreateDate
            // 
            this.m_trvCreateDate.LineColor = System.Drawing.Color.Black;
            this.m_trvCreateDate.Location = new System.Drawing.Point(4, 38);
            this.m_trvCreateDate.Size = new System.Drawing.Size(192, 59);
            // 
            // lblCreateDateTitle
            // 
            this.lblCreateDateTitle.Location = new System.Drawing.Point(202, 72);
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.Location = new System.Drawing.Point(278, 69);
            this.m_dtpCreateDate.TabIndex = 1300;
            // 
            // m_dtpGetDataTime
            // 
            this.m_dtpGetDataTime.Location = new System.Drawing.Point(108, 552);
            this.m_dtpGetDataTime.TabIndex = 2000;
            // 
            // m_lblGetDataTime
            // 
            this.m_lblGetDataTime.Location = new System.Drawing.Point(8, 556);
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(301, 224);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(307, 229);
            this.lblAge.TabIndex = 500;
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(326, 224);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(297, 229);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(307, 243);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(307, 229);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(312, 224);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(312, 229);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(300, 212);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(32, 26);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(300, 220);
            this.txtInPatientID.Size = new System.Drawing.Size(32, 23);
            this.txtInPatientID.TabIndex = 600;
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(304, 232);
            this.m_txtPatientName.Size = new System.Drawing.Size(16, 23);
            this.m_txtPatientName.TabIndex = 400;
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(310, 220);
            this.m_txtBedNO.Size = new System.Drawing.Size(22, 23);
            this.m_txtBedNO.TabIndex = 300;
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(300, 220);
            this.m_cboArea.Size = new System.Drawing.Size(20, 23);
            this.m_cboArea.TabIndex = 200;
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(304, 212);
            this.m_lsvPatientName.Size = new System.Drawing.Size(16, 14);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(338, 212);
            this.m_lsvBedNO.Size = new System.Drawing.Size(16, 14);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(300, 229);
            this.m_cboDept.Size = new System.Drawing.Size(20, 23);
            this.m_cboDept.TabIndex = 100;
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(312, 229);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(304, 216);
            this.m_cmdNewTemplate.Size = new System.Drawing.Size(28, 32);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.m_cmdNext.Location = new System.Drawing.Point(330, 222);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(300, 221);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(15, 124);
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(108, 224);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(723, 37);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Controls.Add(this.m_dtpDeadDate);
            this.m_pnlNewBase.Controls.Add(this.label4);
            this.m_pnlNewBase.Location = new System.Drawing.Point(2, 6);
            this.m_pnlNewBase.Size = new System.Drawing.Size(795, 92);
            this.m_pnlNewBase.Visible = true;
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_ctlPatientInfo, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.label4, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_dtpDeadDate, 0);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ctlPatientInfo.Dock = System.Windows.Forms.DockStyle.None;
            this.m_ctlPatientInfo.Location = new System.Drawing.Point(194, 29);
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(600, 62);
            // 
            // m_dtpDeadDate
            // 
            this.m_dtpDeadDate.AccessibleDescription = "死亡日期";
            this.m_dtpDeadDate.BorderColor = System.Drawing.Color.Black;
            this.m_dtpDeadDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpDeadDate.DropButtonBackColor = System.Drawing.Color.Gainsboro;
            this.m_dtpDeadDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpDeadDate.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpDeadDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpDeadDate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpDeadDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpDeadDate.Location = new System.Drawing.Point(573, 61);
            this.m_dtpDeadDate.m_BlnOnlyTime = false;
            this.m_dtpDeadDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpDeadDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpDeadDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpDeadDate.Name = "m_dtpDeadDate";
            this.m_dtpDeadDate.ReadOnly = false;
            this.m_dtpDeadDate.Size = new System.Drawing.Size(212, 22);
            this.m_dtpDeadDate.TabIndex = 800;
            this.m_dtpDeadDate.TextBackColor = System.Drawing.Color.White;
            this.m_dtpDeadDate.TextForeColor = System.Drawing.Color.Black;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(231, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 10000006;
            this.label3.Text = "入院时间:";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(494, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 10000006;
            this.label4.Text = "死亡时间:";
            // 
            // m_dtpDiscussTime
            // 
            this.m_dtpDiscussTime.AccessibleDescription = "死亡日期";
            this.m_dtpDiscussTime.BorderColor = System.Drawing.Color.Black;
            this.m_dtpDiscussTime.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpDiscussTime.DropButtonBackColor = System.Drawing.Color.Gainsboro;
            this.m_dtpDiscussTime.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpDiscussTime.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpDiscussTime.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpDiscussTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpDiscussTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpDiscussTime.Location = new System.Drawing.Point(84, 104);
            this.m_dtpDiscussTime.m_BlnOnlyTime = false;
            this.m_dtpDiscussTime.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpDiscussTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpDiscussTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpDiscussTime.Name = "m_dtpDiscussTime";
            this.m_dtpDiscussTime.ReadOnly = false;
            this.m_dtpDiscussTime.Size = new System.Drawing.Size(212, 22);
            this.m_dtpDiscussTime.TabIndex = 900;
            this.m_dtpDiscussTime.TextBackColor = System.Drawing.Color.White;
            this.m_dtpDiscussTime.TextForeColor = System.Drawing.Color.Black;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 10000006;
            this.label1.Text = "讨论时间:";
            // 
            // m_txtDiscussAddress
            // 
            this.m_txtDiscussAddress.AccessibleDescription = "讨论地点";
            this.m_txtDiscussAddress.AccessibleName = "";
            this.m_txtDiscussAddress.Location = new System.Drawing.Point(398, 108);
            this.m_txtDiscussAddress.Name = "m_txtDiscussAddress";
            this.m_txtDiscussAddress.Size = new System.Drawing.Size(392, 23);
            this.m_txtDiscussAddress.TabIndex = 1000;
            // 
            // m_lblInHospitalTime
            // 
            this.m_lblInHospitalTime.Location = new System.Drawing.Point(260, 223);
            this.m_lblInHospitalTime.Name = "m_lblInHospitalTime";
            this.m_lblInHospitalTime.Size = new System.Drawing.Size(31, 23);
            this.m_lblInHospitalTime.TabIndex = 700;
            this.m_lblInHospitalTime.Visible = false;
            // 
            // m_cmdAddress
            // 
            this.m_cmdAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdAddress.DefaultScheme = true;
            this.m_cmdAddress.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAddress.Enabled = false;
            this.m_cmdAddress.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdAddress.ForeColor = System.Drawing.Color.Black;
            this.m_cmdAddress.Hint = "";
            this.m_cmdAddress.Location = new System.Drawing.Point(310, 104);
            this.m_cmdAddress.Name = "m_cmdAddress";
            this.m_cmdAddress.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAddress.Size = new System.Drawing.Size(84, 30);
            this.m_cmdAddress.TabIndex = 10000011;
            this.m_cmdAddress.Text = "讨论地点:";
            // 
            // m_cmdCompere
            // 
            this.m_cmdCompere.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdCompere.DefaultScheme = true;
            this.m_cmdCompere.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdCompere.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdCompere.ForeColor = System.Drawing.Color.Black;
            this.m_cmdCompere.Hint = "";
            this.m_cmdCompere.Location = new System.Drawing.Point(12, 136);
            this.m_cmdCompere.Name = "m_cmdCompere";
            this.m_cmdCompere.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCompere.Size = new System.Drawing.Size(84, 30);
            this.m_cmdCompere.TabIndex = 1050;
            this.m_cmdCompere.Text = "主 持 人:";
            // 
            // m_cmdAttendee
            // 
            this.m_cmdAttendee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdAttendee.DefaultScheme = true;
            this.m_cmdAttendee.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAttendee.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdAttendee.ForeColor = System.Drawing.Color.Black;
            this.m_cmdAttendee.Hint = "";
            this.m_cmdAttendee.Location = new System.Drawing.Point(210, 137);
            this.m_cmdAttendee.Name = "m_cmdAttendee";
            this.m_cmdAttendee.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAttendee.Size = new System.Drawing.Size(84, 30);
            this.m_cmdAttendee.TabIndex = 1150;
            this.m_cmdAttendee.Text = "参加人员:";
            // 
            // m_lsvAttendeeList
            // 
            this.m_lsvAttendeeList.AccessibleDescription = "参加人员";
            this.m_lsvAttendeeList.AccessibleName = "";
            this.m_lsvAttendeeList.BackColor = System.Drawing.Color.White;
            this.m_lsvAttendeeList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmEmployeeName,
            this.clmEmployyID});
            this.m_lsvAttendeeList.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvAttendeeList.ForeColor = System.Drawing.Color.Black;
            this.m_lsvAttendeeList.FullRowSelect = true;
            this.m_lsvAttendeeList.GridLines = true;
            this.m_lsvAttendeeList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_lsvAttendeeList.Location = new System.Drawing.Point(300, 138);
            this.m_lsvAttendeeList.Name = "m_lsvAttendeeList";
            this.m_lsvAttendeeList.Size = new System.Drawing.Size(490, 65);
            this.m_lsvAttendeeList.TabIndex = 10000083;
            this.m_lsvAttendeeList.UseCompatibleStateImageBehavior = false;
            this.m_lsvAttendeeList.View = System.Windows.Forms.View.SmallIcon;
            // 
            // clmEmployeeName
            // 
            this.clmEmployeeName.Width = 70;
            // 
            // clmEmployyID
            // 
            this.clmEmployyID.Width = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(8, 268);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(782, 12);
            this.groupBox2.TabIndex = 10000086;
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 288);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 10000087;
            this.label2.Text = "发言记录:";
            // 
            // m_txtSpeakRecord
            // 
            this.m_txtSpeakRecord.AccessibleDescription = "发言记录";
            this.m_txtSpeakRecord.BackColor = System.Drawing.Color.White;
            this.m_txtSpeakRecord.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSpeakRecord.ForeColor = System.Drawing.Color.Black;
            this.m_txtSpeakRecord.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSpeakRecord.Location = new System.Drawing.Point(80, 284);
            this.m_txtSpeakRecord.m_BlnIgnoreUserInfo = false;
            this.m_txtSpeakRecord.m_BlnPartControl = false;
            this.m_txtSpeakRecord.m_BlnReadOnly = false;
            this.m_txtSpeakRecord.m_BlnUnderLineDST = false;
            this.m_txtSpeakRecord.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSpeakRecord.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSpeakRecord.m_IntCanModifyTime = 6;
            this.m_txtSpeakRecord.m_IntPartControlLength = 0;
            this.m_txtSpeakRecord.m_IntPartControlStartIndex = 0;
            this.m_txtSpeakRecord.m_StrUserID = "";
            this.m_txtSpeakRecord.m_StrUserName = "";
            this.m_txtSpeakRecord.MaxLength = 2000;
            this.m_txtSpeakRecord.Name = "m_txtSpeakRecord";
            this.m_txtSpeakRecord.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtSpeakRecord.Size = new System.Drawing.Size(710, 96);
            this.m_txtSpeakRecord.TabIndex = 1500;
            this.m_txtSpeakRecord.Text = "";
            // 
            // m_txtVerdict
            // 
            this.m_txtVerdict.AccessibleDescription = "结论";
            this.m_txtVerdict.BackColor = System.Drawing.Color.White;
            this.m_txtVerdict.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtVerdict.ForeColor = System.Drawing.Color.Black;
            this.m_txtVerdict.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtVerdict.Location = new System.Drawing.Point(80, 388);
            this.m_txtVerdict.m_BlnIgnoreUserInfo = false;
            this.m_txtVerdict.m_BlnPartControl = false;
            this.m_txtVerdict.m_BlnReadOnly = false;
            this.m_txtVerdict.m_BlnUnderLineDST = false;
            this.m_txtVerdict.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtVerdict.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtVerdict.m_IntCanModifyTime = 6;
            this.m_txtVerdict.m_IntPartControlLength = 0;
            this.m_txtVerdict.m_IntPartControlStartIndex = 0;
            this.m_txtVerdict.m_StrUserID = "";
            this.m_txtVerdict.m_StrUserName = "";
            this.m_txtVerdict.MaxLength = 2000;
            this.m_txtVerdict.Name = "m_txtVerdict";
            this.m_txtVerdict.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtVerdict.Size = new System.Drawing.Size(710, 36);
            this.m_txtVerdict.TabIndex = 1600;
            this.m_txtVerdict.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 388);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 14);
            this.label5.TabIndex = 10000089;
            this.label5.Text = "结    论:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 436);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 14);
            this.label6.TabIndex = 10000089;
            this.label6.Text = "死亡诊断:";
            // 
            // m_txtDeadDiagnose
            // 
            this.m_txtDeadDiagnose.AccessibleDescription = "死亡诊断";
            this.m_txtDeadDiagnose.BackColor = System.Drawing.Color.White;
            this.m_txtDeadDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDeadDiagnose.ForeColor = System.Drawing.Color.Black;
            this.m_txtDeadDiagnose.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDeadDiagnose.Location = new System.Drawing.Point(80, 432);
            this.m_txtDeadDiagnose.m_BlnIgnoreUserInfo = false;
            this.m_txtDeadDiagnose.m_BlnPartControl = false;
            this.m_txtDeadDiagnose.m_BlnReadOnly = false;
            this.m_txtDeadDiagnose.m_BlnUnderLineDST = false;
            this.m_txtDeadDiagnose.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDeadDiagnose.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDeadDiagnose.m_IntCanModifyTime = 6;
            this.m_txtDeadDiagnose.m_IntPartControlLength = 0;
            this.m_txtDeadDiagnose.m_IntPartControlStartIndex = 0;
            this.m_txtDeadDiagnose.m_StrUserID = "";
            this.m_txtDeadDiagnose.m_StrUserName = "";
            this.m_txtDeadDiagnose.MaxLength = 2000;
            this.m_txtDeadDiagnose.Name = "m_txtDeadDiagnose";
            this.m_txtDeadDiagnose.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtDeadDiagnose.Size = new System.Drawing.Size(710, 56);
            this.m_txtDeadDiagnose.TabIndex = 1700;
            this.m_txtDeadDiagnose.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 500);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 14);
            this.label7.TabIndex = 10000089;
            this.label7.Text = "死亡原因:";
            // 
            // m_txtDeadReason
            // 
            this.m_txtDeadReason.AccessibleDescription = "死亡原因";
            this.m_txtDeadReason.BackColor = System.Drawing.Color.White;
            this.m_txtDeadReason.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDeadReason.ForeColor = System.Drawing.Color.Black;
            this.m_txtDeadReason.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDeadReason.Location = new System.Drawing.Point(80, 496);
            this.m_txtDeadReason.m_BlnIgnoreUserInfo = false;
            this.m_txtDeadReason.m_BlnPartControl = false;
            this.m_txtDeadReason.m_BlnReadOnly = false;
            this.m_txtDeadReason.m_BlnUnderLineDST = false;
            this.m_txtDeadReason.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDeadReason.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDeadReason.m_IntCanModifyTime = 6;
            this.m_txtDeadReason.m_IntPartControlLength = 0;
            this.m_txtDeadReason.m_IntPartControlStartIndex = 0;
            this.m_txtDeadReason.m_StrUserID = "";
            this.m_txtDeadReason.m_StrUserName = "";
            this.m_txtDeadReason.MaxLength = 2000;
            this.m_txtDeadReason.Name = "m_txtDeadReason";
            this.m_txtDeadReason.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtDeadReason.Size = new System.Drawing.Size(710, 48);
            this.m_txtDeadReason.TabIndex = 1800;
            this.m_txtDeadReason.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 556);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 14);
            this.label8.TabIndex = 10000089;
            this.label8.Text = "经验教训:";
            this.label8.Visible = false;
            // 
            // m_txtExperience
            // 
            this.m_txtExperience.AccessibleDescription = "经验教训";
            this.m_txtExperience.BackColor = System.Drawing.Color.White;
            this.m_txtExperience.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtExperience.ForeColor = System.Drawing.Color.Black;
            this.m_txtExperience.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtExperience.Location = new System.Drawing.Point(80, 552);
            this.m_txtExperience.m_BlnIgnoreUserInfo = false;
            this.m_txtExperience.m_BlnPartControl = false;
            this.m_txtExperience.m_BlnReadOnly = false;
            this.m_txtExperience.m_BlnUnderLineDST = false;
            this.m_txtExperience.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtExperience.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtExperience.m_IntCanModifyTime = 6;
            this.m_txtExperience.m_IntPartControlLength = 0;
            this.m_txtExperience.m_IntPartControlStartIndex = 0;
            this.m_txtExperience.m_StrUserID = "";
            this.m_txtExperience.m_StrUserName = "";
            this.m_txtExperience.MaxLength = 2000;
            this.m_txtExperience.Name = "m_txtExperience";
            this.m_txtExperience.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtExperience.Size = new System.Drawing.Size(710, 36);
            this.m_txtExperience.TabIndex = 1900;
            this.m_txtExperience.Text = "";
            this.m_txtExperience.Visible = false;
            // 
            // m_txtInHospitalDiagnose
            // 
            this.m_txtInHospitalDiagnose.AccessibleDescription = "入院诊断";
            this.m_txtInHospitalDiagnose.BackColor = System.Drawing.Color.White;
            this.m_txtInHospitalDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtInHospitalDiagnose.ForeColor = System.Drawing.Color.Black;
            this.m_txtInHospitalDiagnose.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtInHospitalDiagnose.Location = new System.Drawing.Point(80, 209);
            this.m_txtInHospitalDiagnose.m_BlnIgnoreUserInfo = false;
            this.m_txtInHospitalDiagnose.m_BlnPartControl = false;
            this.m_txtInHospitalDiagnose.m_BlnReadOnly = false;
            this.m_txtInHospitalDiagnose.m_BlnUnderLineDST = false;
            this.m_txtInHospitalDiagnose.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtInHospitalDiagnose.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtInHospitalDiagnose.m_IntCanModifyTime = 6;
            this.m_txtInHospitalDiagnose.m_IntPartControlLength = 0;
            this.m_txtInHospitalDiagnose.m_IntPartControlStartIndex = 0;
            this.m_txtInHospitalDiagnose.m_StrUserID = "";
            this.m_txtInHospitalDiagnose.m_StrUserName = "";
            this.m_txtInHospitalDiagnose.MaxLength = 2000;
            this.m_txtInHospitalDiagnose.Name = "m_txtInHospitalDiagnose";
            this.m_txtInHospitalDiagnose.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtInHospitalDiagnose.Size = new System.Drawing.Size(710, 64);
            this.m_txtInHospitalDiagnose.TabIndex = 1400;
            this.m_txtInHospitalDiagnose.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 212);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 14);
            this.label9.TabIndex = 10000087;
            this.label9.Text = "入院诊断:";
            // 
            // m_txtRecorder
            // 
            this.m_txtRecorder.AccessibleDescription = "记录者";
            this.m_txtRecorder.AccessibleName = "";
            this.m_txtRecorder.BackColor = System.Drawing.Color.White;
            this.m_txtRecorder.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtRecorder.ForeColor = System.Drawing.Color.Black;
            this.m_txtRecorder.Location = new System.Drawing.Point(424, 556);
            this.m_txtRecorder.Name = "m_txtRecorder";
            this.m_txtRecorder.ReadOnly = true;
            this.m_txtRecorder.Size = new System.Drawing.Size(100, 23);
            this.m_txtRecorder.TabIndex = 2100;
            this.m_txtRecorder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthEvent_KeyDown);
            // 
            // m_cmdRecord
            // 
            this.m_cmdRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdRecord.DefaultScheme = true;
            this.m_cmdRecord.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdRecord.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdRecord.ForeColor = System.Drawing.Color.Black;
            this.m_cmdRecord.Hint = "";
            this.m_cmdRecord.Location = new System.Drawing.Point(352, 552);
            this.m_cmdRecord.Name = "m_cmdRecord";
            this.m_cmdRecord.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdRecord.Size = new System.Drawing.Size(68, 30);
            this.m_cmdRecord.TabIndex = 2050;
            this.m_cmdRecord.Text = "记录者:";
            // 
            // m_cmdCompereSign
            // 
            this.m_cmdCompereSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdCompereSign.DefaultScheme = true;
            this.m_cmdCompereSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdCompereSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdCompereSign.ForeColor = System.Drawing.Color.Black;
            this.m_cmdCompereSign.Hint = "";
            this.m_cmdCompereSign.Location = new System.Drawing.Point(548, 552);
            this.m_cmdCompereSign.Name = "m_cmdCompereSign";
            this.m_cmdCompereSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCompereSign.Size = new System.Drawing.Size(120, 30);
            this.m_cmdCompereSign.TabIndex = 2150;
            this.m_cmdCompereSign.Text = "主持人审阅签名:";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Width = 0;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Width = 0;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Width = 100;
            // 
            // m_txtCompere
            // 
            this.m_txtCompere.AccessibleDescription = "主持人";
            this.m_txtCompere.AccessibleName = "";
            this.m_txtCompere.BackColor = System.Drawing.Color.White;
            this.m_txtCompere.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCompere.ForeColor = System.Drawing.Color.Black;
            this.m_txtCompere.Location = new System.Drawing.Point(100, 140);
            this.m_txtCompere.Name = "m_txtCompere";
            this.m_txtCompere.ReadOnly = true;
            this.m_txtCompere.Size = new System.Drawing.Size(100, 23);
            this.m_txtCompere.TabIndex = 1100;
            // 
            // m_txtCompereSign
            // 
            this.m_txtCompereSign.AccessibleDescription = "主持人审阅签名";
            this.m_txtCompereSign.AccessibleName = "";
            this.m_txtCompereSign.BackColor = System.Drawing.Color.White;
            this.m_txtCompereSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCompereSign.ForeColor = System.Drawing.Color.Black;
            this.m_txtCompereSign.Location = new System.Drawing.Point(672, 556);
            this.m_txtCompereSign.Name = "m_txtCompereSign";
            this.m_txtCompereSign.ReadOnly = true;
            this.m_txtCompereSign.Size = new System.Drawing.Size(100, 23);
            this.m_txtCompereSign.TabIndex = 2200;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(379, 110);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 14);
            this.label10.TabIndex = 10000094;
            this.label10.Text = "讨论地点:";
            this.label10.Visible = false;
            // 
            // frmDeathCaseDiscuss
            // 
            this.ClientSize = new System.Drawing.Size(799, 653);
            this.Controls.Add(this.m_txtCompere);
            this.Controls.Add(this.m_txtRecorder);
            this.Controls.Add(this.m_cmdRecord);
            this.Controls.Add(this.m_txtInHospitalDiagnose);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.m_txtSpeakRecord);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.m_cmdAttendee);
            this.Controls.Add(this.m_lsvAttendeeList);
            this.Controls.Add(this.m_cmdCompere);
            this.Controls.Add(this.m_cmdAddress);
            this.Controls.Add(this.m_lblInHospitalTime);
            this.Controls.Add(this.m_txtDiscussAddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_dtpDiscussTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_txtVerdict);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.m_txtDeadDiagnose);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.m_txtDeadReason);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.m_cmdCompereSign);
            this.Controls.Add(this.m_txtCompereSign);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.m_txtExperience);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDeathCaseDiscuss";
            this.Text = "死亡病例讨论记录";
            this.Load += new System.EventHandler(this.frmDeathCaseDiscuss_Load);
            this.Controls.SetChildIndex(this.m_txtExperience, 0);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_txtCompereSign, 0);
            this.Controls.SetChildIndex(this.m_cmdCompereSign, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.m_txtDeadReason, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.m_txtDeadDiagnose, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.m_txtVerdict, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.m_dtpDiscussTime, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.m_lblGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_dtpCreateDate, 0);
            this.Controls.SetChildIndex(this.m_trvCreateDate, 0);
            this.Controls.SetChildIndex(this.lblCreateDateTitle, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_dtpGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.m_txtDiscussAddress, 0);
            this.Controls.SetChildIndex(this.m_lblInHospitalTime, 0);
            this.Controls.SetChildIndex(this.m_cmdAddress, 0);
            this.Controls.SetChildIndex(this.m_cmdCompere, 0);
            this.Controls.SetChildIndex(this.m_lsvAttendeeList, 0);
            this.Controls.SetChildIndex(this.m_cmdAttendee, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.m_txtSpeakRecord, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.m_txtInHospitalDiagnose, 0);
            this.Controls.SetChildIndex(this.m_cmdRecord, 0);
            this.Controls.SetChildIndex(this.m_txtRecorder, 0);
            this.Controls.SetChildIndex(this.m_txtCompere, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.m_pnlNewBase.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// 获取当前的特殊病程记录信息
		/// </summary>
		/// <returns></returns>
		public override clsDiseaseTrackInfo m_objGetDiseaseTrackInfo()
		{
			clsDeathCaseDiscussInfo objTrackInfo = new clsDeathCaseDiscussInfo();

			objTrackInfo.m_ObjRecordContent = m_objCurrentRecordContent;
			//设置m_strTitle和m_dtmRecordTime
			objTrackInfo.m_DtmRecordTime = m_dtpCreateDate.Value;
			objTrackInfo.m_StrTitle = "死亡病例讨论记录";			
			
			return objTrackInfo;		
		}

		/// <summary>
		/// 清空特殊记录信息，并重置记录控制状态为不控制。
		/// </summary>
		protected override void m_mthClearRecordInfo()
		{
			//清空具体记录内容	
			m_strCurrentOpenDate = "";

			m_txtDiscussAddress.Text = "";;

			m_txtInHospitalDiagnose.m_mthClearText();
			m_txtSpeakRecord.m_mthClearText();
			m_txtVerdict.m_mthClearText();
			m_txtDeadDiagnose.m_mthClearText();
			m_txtDeadReason.m_mthClearText();
			m_txtExperience.m_mthClearText();
			m_lsvAttendeeList.Items.Clear();

            m_txtCompere.Clear();
            m_txtCompere.Tag = null;
            m_txtCompereSign.Clear();
            m_txtCompereSign.Tag = null;
            m_txtRecorder.Clear();
            m_txtRecorder.Tag = null;
		}

		/// <summary>
		/// 设置是否控制修改（修改留痕迹）。
		/// </summary>
		/// <param name="p_objRecordContent"></param>
		/// <param name="p_blnReset">是否重置控制修改（修改留痕迹）。
		///如果为true，忽略记录内容，把界面控制设置为不控制；
		///否则根据记录内容进行设置。
		///</param>
		protected override void m_mthSetModifyControlSub(clsTrackRecordContent p_objRecordContent,
			bool p_blnReset)
		{
			//根据书写规范设置具体窗体的书写控制
			
		}

		/// <summary>
		/// 提示没有该病人
		/// </summary>
		protected override void m_mthShowNoPatient()
		{
			clsPublicFunction.ShowInformationMessageBox("对不起，没有此病人！");
		}

		protected override void m_mthSetPatientBaseInfo(clsPatient p_objSelectedPatient)
		{
			if(p_objSelectedPatient.m_ObjPeopleInfo == null)
			{
				m_mthShowNoPatient();
				return;
			}  
			//这个开关的作用是以防对m_cboArea赋值后触发其SelectedIndexChanged事件
			m_blnCanTextChanged = false;

			if(p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastSessionInfo != null)
			{			
//				m_cboDept.ClearItem();
//				m_cboArea.ClearItem();
//				m_cboDept.AddItem(p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastDeptInfo.m_ObjDept);
//				m_cboDept.SelectedIndex=0;
//				clsInPatientArea objInPatientArea =new clsInPatientArea(p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastAreaInfo.m_ObjArea.m_StrAreaID,p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastAreaInfo.m_ObjArea.m_StrAreaName);
//				m_cboArea.AddItem(objInPatientArea);
//				m_cboArea.SelectedIndex=0;
//				m_txtBedNO.Text = p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName;				
				//使用新表 modified by tfzhang at 2005年10月17日 16:02:29
				//清空
				m_cboDept.ClearItem();
				 
				//获取科室
				string str1=p_objSelectedPatient.m_strDeptNewID;
				string str2;
				clsHospitalManagerDomain objDomain =new clsHospitalManagerDomain();
				clsEmrDept_VO objDeptNew;
				objDomain.m_lngGetSpecialDeptInfo(str1,out objDeptNew);
				str1=objDeptNew.m_strSHORTNO_CHR.Trim();
				str2=objDeptNew.m_strDEPTNAME_VCHR.Trim();
				string str11=objDeptNew.m_strDEPTID_CHR.Trim();
				clsDepartment objDeptTemp= new clsDepartment(str1,str2);
				//转换使用，新表的shortno＝旧表的ID，所以新加一个字段保存新表ID
				objDeptTemp.m_strDeptNewID=str11;
				m_cboDept.AddItem(objDeptTemp);
				m_cboDept.SelectedIndex=0;

				//获取病区
				m_cboArea.ClearItem();
				string str3=p_objSelectedPatient.m_strAreaNewID;
				if (str3.Trim().Length!=0)//病区不为空
				{
					string str4;
					clsEmrDept_VO objAreNew;
					objDomain.m_lngGetSpecialAreaInfo(str3,out objAreNew);
					str3=objAreNew.m_strSHORTNO_CHR;
					str4=objAreNew.m_strDEPTNAME_VCHR;
					clsInPatientArea objInPatientArea =new clsInPatientArea(str3,str4,str3);
					//转换使用，新表的shortno＝旧表的ID，所以新加一个字段保存新表ID
					objInPatientArea.m_strAreaNewID=objAreNew.m_strDEPTID_CHR;
					m_cboArea.AddItem(objInPatientArea);
					m_cboArea.SelectedIndex=0;
				}
							
				m_txtBedNO.Text =p_objSelectedPatient.m_strBedCode;
			}
			else
			{				
				m_txtBedNO.Text = "";
			}

			m_objCurrentPatient = p_objSelectedPatient;

			txtInPatientID.Text = m_objCurrentPatient.m_StrHISInPatientID;
			m_txtPatientName.Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrFirstName;
			lblSex.Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrSex;
			lblAge.Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrAge;
			m_blnCanTextChanged = true;
		}

		/// <summary>
		/// 从界面获取特殊记录的值。如果界面值出错，返回null。
		/// </summary>
		/// <returns></returns>
		protected override clsTrackRecordContent m_objGetContentFromGUI()
		{
			//界面参数校验
			if(m_objCurrentPatient==null || m_ObjCurrentEmrPatientSession == null)				
				return null;
            
			//从界面获取表单值
			clsDeadCaseDiscussRecord_VO objContent=new clsDeadCaseDiscussRecord_VO();
			objContent.m_dtmCreateDate=m_dtpCreateDate.Value;
			objContent.m_strModifyUserID=clsEMRLogin.LoginInfo.m_strEmpNo;
			#region 是否可以无痕迹修改
            if (chkModifyWithoutMatk.Checked)
                objContent.m_intMarkStatus = 0;
            else
                objContent.m_intMarkStatus = 1;
            #endregion
			objContent.m_dtmDeadDate = m_dtpDeadDate.Value;
			objContent.m_dtmDiscussDate = m_dtpDiscussTime.Value;

			objContent.m_strDiscussAddress = m_txtDiscussAddress.Text;
			objContent.m_strInHospitalDiagnose = m_txtInHospitalDiagnose.Text;
			objContent.m_strInHospitalDiagnoseXML = m_txtInHospitalDiagnose.m_strGetXmlText();
			objContent.m_strSpeakRecord = m_txtSpeakRecord.Text;
			objContent.m_strSpeakRecordXML = m_txtSpeakRecord.m_strGetXmlText();
			objContent.m_strVerdict = m_txtVerdict.Text;
			objContent.m_strVerdictXML = m_txtVerdict.m_strGetXmlText();
			objContent.m_strDeadDiagnose = m_txtDeadDiagnose.Text;
			objContent.m_strDeadDiagnoseXML = m_txtDeadDiagnose.m_strGetXmlText();
            objContent.m_strDeadReason = m_txtDeadReason.Text; 
            objContent.m_strDeadReasonXML = m_txtDeadReason.m_strGetXmlText();
			objContent.m_strExperience = m_txtExperience.Text;
			objContent.m_strExperienceXML = m_txtExperience.m_strGetXmlText();

			if(m_lsvAttendeeList.Items.Count>0)
			{			
				objContent.m_strAttendeeIDArr=new string[m_lsvAttendeeList.Items.Count];
				objContent.m_strAttendeeNameArr=new string[m_lsvAttendeeList.Items.Count];
				for(int i=0;i<m_lsvAttendeeList.Items.Count;i++)
				{
					objContent.m_strAttendeeIDArr[i]=((clsEmrEmployeeBase_VO)m_lsvAttendeeList.Items[i].Tag).m_strEMPNO_CHR.Trim();
                    objContent.m_strAttendeeNameArr[i] = ((clsEmrEmployeeBase_VO)m_lsvAttendeeList.Items[i].Tag).m_strLASTNAME_VCHR.Trim() + ((clsEmrEmployeeBase_VO)m_lsvAttendeeList.Items[i].Tag).m_strTECHNICALRANK_CHR.Trim();
				}
			}
			else
			{
				clsPublicFunction.ShowInformationMessageBox("请至少一个参加人员签名!");
				return null;
			}

			if(m_txtCompere.Tag !=null && m_txtCompere.Text.Trim()!="")
			{
				objContent.m_strCompereID=((clsEmrEmployeeBase_VO)m_txtCompere.Tag).m_strEMPNO_CHR;

                clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
                objEmployeeSign.m_lngGetEmpByNO(objContent.m_strCompereID, out objEmpVO);
                // m_txtDoctorSign.Text = objEmpVO.ToString();
                objContent.m_strCompereName = objEmpVO.ToString();

				// objContent.m_strCompereName=m_txtCompere.Text;
			}
			else
			{
				clsPublicFunction.ShowInformationMessageBox("请主持人签名!");
				return null;
			}

			if(m_txtRecorder.Tag!=null && m_txtRecorder.Text.Trim()!="")
			{
				objContent.m_strRecorderID = ((clsEmrEmployeeBase_VO)m_txtRecorder.Tag).m_strEMPNO_CHR.Trim();
                clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
                objEmployeeSign.m_lngGetEmpByNO(objContent.m_strRecorderID, out objEmpVO);
                // m_txtDoctorSign.Text = objEmpVO.ToString();
                objContent.m_strRecorderName = objEmpVO.ToString();

				//objContent.m_strRecorderName = m_txtRecorder.Text.Trim();
			}
			else
			{
				clsPublicFunction.ShowInformationMessageBox("请记录者签名!");
				return null;
			}

			
			if(m_txtCompereSign.Tag!=null && m_txtCompereSign.Text.Trim()!="")
			{
                objContent.m_strCompereSignID = ((clsEmrEmployeeBase_VO)m_txtCompereSign.Tag).m_strEMPNO_CHR;
				objContent.m_strCompereSignName = m_txtCompereSign.Text.Trim();
			}
			else
			{
                if (!m_BlnIsAddNew)
                {
                    clsPublicFunction.ShowInformationMessageBox("必须主持人审阅签名!");
                    return null;
                }
			}

            if (!string.IsNullOrEmpty(objContent.m_strCompereSignID) 
                && objContent.m_strCompereSignID.Trim() != objContent.m_strCompereID.Trim())
			{
				if(clsPublicFunction.ShowInformationMessageBox("填写的主持人与主持人审阅签名不同，是否继续保存？",MessageBoxButtons.YesNo)==DialogResult.No)
				{
					return null;
				}
			}
			return objContent;	
		}

		/// <summary>
		/// 把特殊记录的值显示到界面上。
		/// </summary>
		/// <param name="p_objContent"></param>
		protected override void m_mthSetGUIFromContent(clsTrackRecordContent p_objContent)
		{
			if(p_objContent ==null)
				return;
			clsDeadCaseDiscussRecord_VO objContent=(clsDeadCaseDiscussRecord_VO)p_objContent;
			//把表单值赋值到界面，由子窗体重载实现
			m_strCurrentOpenDate =objContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss");

			m_dtpDeadDate.Value = objContent.m_dtmDeadDate;
			m_dtpDiscussTime.Value = objContent.m_dtmDiscussDate;
			m_txtDiscussAddress.Text = objContent.m_strDiscussAddress;
	
			m_txtInHospitalDiagnose.m_mthSetNewText(objContent.m_strInHospitalDiagnose,objContent.m_strInHospitalDiagnoseXML);		
			m_txtSpeakRecord.m_mthSetNewText(objContent.m_strSpeakRecord,objContent.m_strSpeakRecordXML);		
			m_txtVerdict.m_mthSetNewText(objContent.m_strVerdict,objContent.m_strVerdictXML);		
			m_txtDeadDiagnose.m_mthSetNewText(objContent.m_strDeadDiagnose,objContent.m_strDeadDiagnoseXML);		
			m_txtDeadReason.m_mthSetNewText(objContent.m_strDeadReason,objContent.m_strDeadReasonXML);
			m_txtExperience.m_mthSetNewText(objContent.m_strExperience,objContent.m_strExperienceXML);

			#region 签名
            clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
			if(objContent.m_strAttendeeIDArr !=null)
			{
				for(int i=0;i<objContent.m_strAttendeeIDArr.Length;i++)
				{
                    ListViewItem lviNewItem = new ListViewItem(new string[] { objContent.m_strAttendeeNameArr[i].Trim(), objContent.m_strAttendeeIDArr[i].Trim() });
                    //tag均为对象
                    objEmployeeSign.m_lngGetEmpByNO(objContent.m_strAttendeeIDArr[i].Trim(), out objEmpVO);
                    lviNewItem.SubItems.Add(objEmpVO.m_strLEVEL_CHR);
                    lviNewItem.Text = objEmpVO.m_strLASTNAME_VCHR + " " + objEmpVO.m_strTechnicalRank;
                    lviNewItem.Tag = objEmpVO;
                    //是按顺序保存故获取顺序也一样
                    m_lsvAttendeeList.Items.Add(lviNewItem);
                    //m_lsvAttendeeList.Items.Add(objEmpVO.m_strLASTNAME_VCHR + " " + objEmpVO.m_strTechnicalRank);
				}
			}

            objEmployeeSign.m_lngGetEmpByNO(objContent.m_strCompereID, out objEmpVO);
            if (objEmpVO != null)
            {
                m_txtCompere.Tag = objEmpVO;
              //  m_txtCompere.Text = objContent..m_strCompereName;
                m_txtCompere.Text = objEmpVO.m_strLASTNAME_VCHR + " " + objEmpVO.m_strTECHNICALRANK_CHR;
            }

            objEmployeeSign.m_lngGetEmpByNO(objContent.m_strRecorderID, out objEmpVO);
            if (objEmpVO != null)
            {
                m_txtRecorder.Tag = objEmpVO;
              //  m_txtRecorder.Text = objContent.m_strRecorderName;
                m_txtRecorder.Text = objEmpVO.m_strLASTNAME_VCHR + " " + objEmpVO.m_strTECHNICALRANK_CHR;
            }

            objEmployeeSign.m_lngGetEmpByNO(objContent.m_strCompereSignID, out objEmpVO);
            if (objEmpVO != null)
            {
                m_txtCompereSign.Tag = objEmpVO;
              //  m_txtCompereSign.Text = objContent.m_strCompereSignName;
                m_txtCompereSign.Text = objEmpVO.m_strLASTNAME_VCHR + " " + objEmpVO.m_strTECHNICALRANK_CHR;
            }
			#endregion 签名
		}

		/// <summary>
		/// 获取当前病人的作废内容
		/// </summary>
		/// <param name="p_dtmRecordDate">记录日期，此处表示CreateDate</param>
		/// <param name="p_intFormID">窗体ID</param>
		protected override void m_mthGetDeactiveContent(DateTime p_dtmRecordDate,int p_intFormID)
		{
			if(m_objBaseCurrentPatient==null || m_objBaseCurrentPatient.m_StrInPatientID==null || m_objBaseCurrentPatient.m_DtmSelectedInDate==DateTime.MinValue|| p_dtmRecordDate==DateTime.MinValue )
			{
				clsPublicFunction.ShowInformationMessageBox("参数错误！");
				return ;
			}			
		
			clsTrackRecordContent objContent=null;
			long lngRes=m_objDiseaseTrackDomain.m_lngGetDeleteRecordContent(m_objBaseCurrentPatient.m_StrInPatientID,m_objBaseCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"),p_dtmRecordDate.ToString("yyyy-MM-dd HH:mm:ss"),out objContent);
			if(lngRes>0 && objContent!=null)
			{
				m_mthSetDeletedGUIFromContent(objContent);			
			}		
				
		}

		public override int m_IntFormID
		{
			get
			{
				return 58;
			}
		}

		protected override void m_mthSetDeletedGUIFromContent(clsTrackRecordContent p_objContent)
		{
			if(p_objContent ==null)
				return;
			clsDeadCaseDiscussRecord_VO objContent=(clsDeadCaseDiscussRecord_VO)p_objContent;
			//把表单值赋值到界面，由子窗体重载实现
			m_dtpDeadDate.Value = objContent.m_dtmDeadDate;
			m_dtpDiscussTime.Value = objContent.m_dtmDiscussDate;
			m_txtDiscussAddress.Text = objContent.m_strDiscussAddress;

			m_txtInHospitalDiagnose.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strInHospitalDiagnose,objContent.m_strInHospitalDiagnoseXML);		
			m_txtSpeakRecord.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strSpeakRecord,objContent.m_strSpeakRecordXML);		
			m_txtDeadDiagnose.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDeadDiagnose,objContent.m_strDeadDiagnoseXML);		
			m_txtDeadReason.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDeadReason,objContent.m_strDeadReasonXML);		
			m_txtVerdict.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strVerdict,objContent.m_strVerdictXML);	
			m_txtExperience.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strExperience,objContent.m_strExperienceXML);
			
		}

		/// <summary>
		/// 获取病程记录的领域层实例
		/// </summary>
		/// <returns></returns>
		protected override clsDiseaseTrackDomain m_objGetDiseaseTrackDomain()
		{
			//获取病程记录的领域层实例
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.DeathCaseDiscuss);					
		}

		/// <summary>
		/// 把选择时间记录内容重新整理为完全正确的内容。
		/// </summary>
		/// <param name="p_objRecordContent"></param>
		protected override void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
		{
			//把选择时间记录内容重新整理为完全正确的内容，由子窗体重载实现。
			clsDeadCaseDiscussRecord_VO objContent=(clsDeadCaseDiscussRecord_VO)p_objRecordContent;
			//把表单值赋值到界面，由子窗体重载实现
			m_dtpDeadDate.Value = objContent.m_dtmDeadDate;
			m_dtpDiscussTime.Value = objContent.m_dtmDiscussDate;
			m_txtDiscussAddress.Text = objContent.m_strDiscussAddress;

			m_txtInHospitalDiagnose.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strInHospitalDiagnose,objContent.m_strInHospitalDiagnoseXML);		
			m_txtSpeakRecord.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strSpeakRecord,objContent.m_strSpeakRecordXML);		
			m_txtDeadDiagnose.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDeadDiagnose,objContent.m_strDeadDiagnoseXML);		
			m_txtDeadReason.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDeadReason,objContent.m_strDeadReasonXML);		
			m_txtVerdict.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strVerdict,objContent.m_strVerdictXML);	
			m_txtExperience.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strExperience,objContent.m_strExperienceXML);	

			#region 签名
            clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
            if (objContent.m_strAttendeeIDArr != null)
            {
                for (int i = 0; i < objContent.m_strAttendeeIDArr.Length; i++)
                {
                    ListViewItem lviNewItem = new ListViewItem(new string[] { objContent.m_strAttendeeNameArr[i].Trim(), objContent.m_strAttendeeIDArr[i] });
                    //tag均为对象
                    objEmployeeSign.m_lngGetEmpByNO(objContent.m_strAttendeeIDArr[i], out objEmpVO);
                    lviNewItem.SubItems.Add(objEmpVO.m_strLEVEL_CHR);
                    lviNewItem.Tag = objEmpVO;
                    //是按顺序保存故获取顺序也一样
                    m_lsvAttendeeList.Items.Add(lviNewItem);
                }
            }

            objEmployeeSign.m_lngGetEmpByNO(objContent.m_strCompereID, out objEmpVO);
            if (objEmpVO != null)
            {
                m_txtCompere.Tag = objEmpVO;
                m_txtCompere.Text = objContent.m_strCompereName;
            }

            objEmployeeSign.m_lngGetEmpByNO(objContent.m_strRecorderID, out objEmpVO);
            if (objEmpVO != null)
            {
                m_txtRecorder.Tag = objEmpVO;
                m_txtRecorder.Text = objContent.m_strRecorderName;
            }

            objEmployeeSign.m_lngGetEmpByNO(objContent.m_strCompereSignID, out objEmpVO);
            if (objEmpVO != null)
            {
                m_txtCompereSign.Tag = objEmpVO;
                m_txtCompereSign.Text = objContent.m_strCompereSignName;
            }
			#endregion 签名
		}

		// 获取选择已经删除记录的窗体标题
		public override string m_strReloadFormTitle()
		{
			//由子窗体重载实现
			return	"死亡病例讨论记录";
		}	
	
		/// <summary>
		/// 当选择根节点时,设置特殊的默认值(若子窗体需要,则重载实现)
		/// </summary>
		protected override void m_mthSelectRootNode()
		{
			if(m_objCurrentPatient != null)
			{
				clsInPatientCaseHisoryDefaultValue[] objInPatientCaseHisoryDefaultValueArr= new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(m_objCurrentPatient.m_StrInPatientID,m_objCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"));
				if(objInPatientCaseHisoryDefaultValueArr !=null && objInPatientCaseHisoryDefaultValueArr.Length>0)
				{
					m_txtInHospitalDiagnose.Text=objInPatientCaseHisoryDefaultValueArr[0].m_strPrimaryDiagnose;
				}
			}	
		}

		#region 签名		
		private void m_mthEvent_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch(e.KeyValue)
			{
				case 13:// enter
					break;

				case 38:
				case 40:				
					break;			
				case 46://Keys.Delete
					break;
			}	
		}

		#endregion 签名

		#region 添加键盘快捷键
		private void m_mthSetQuickKeys()
		{			
			m_mthSetControlEvent(this);			
		}
		
		private void m_mthSetControlEvent(Control p_ctlControl)
		{
			#region 利用递归调用，读取并设置所有界面事件,Jacky-2003-2-21	
			string strTypeName = p_ctlControl.GetType().Name;
			if(strTypeName != "Lable" && strTypeName != "Button")
			{
				p_ctlControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthEvent_KeyDown);
				if(p_ctlControl.HasChildren && strTypeName !="DataGrid" && strTypeName !="DateTimePicker" && strTypeName !="ctlComboBox")
				{									
					foreach(Control subcontrol in p_ctlControl.Controls)
					{										
						m_mthSetControlEvent(subcontrol);						
					} 	
				}				
			}			
			#endregion
		}
		#endregion

		/// <summary>
		/// 清空除当前控件以外的所有窗体内容,(可覆盖提供新的实现)
		/// </summary>
		/// <param name="p_ctlControl"></param>
		/// <param name="p_blnReadOnly"></param>
		protected override void m_mthClearAllInfo(Control p_ctlControl)
		{
            if (p_ctlControl == null || m_lblInHospitalTime == null) return;
			string strTypeName = p_ctlControl.GetType().Name;			
			if(strTypeName=="ctlRichTextBox")
			{
				if(p_ctlControl is iCare.CustomForm.ctlRichTextBox)//自定义表单中的cltRichTextBox
					((iCare.CustomForm.ctlRichTextBox)p_ctlControl).Text = "";
				else
					((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_mthClearText();	
			}
			else if(strTypeName=="ctlBorderTextBox" && p_ctlControl.Name != "txtInPatientID" && p_ctlControl.Name != "m_txtPatientName" && p_ctlControl.Name != "m_txtBedNO" && p_ctlControl.Name != "m_txtRecorder")
				((ctlBorderTextBox)p_ctlControl).Text="";	
			else if(strTypeName=="TreeView")
			{
				if( ((TreeView)p_ctlControl).Nodes.Count>0 )
					((TreeView)p_ctlControl).Nodes[0].Nodes.Clear();
			}
			else if(strTypeName=="ListView")
				((ListView)p_ctlControl).Items.Clear();	
			else if(strTypeName=="DateTimePicker")
				((DateTimePicker)p_ctlControl).Value=DateTime.Now;
			m_lblInHospitalTime.Text = "";
			if(p_ctlControl.HasChildren && strTypeName !="DataGrid" && strTypeName !="DateTimePicker" )
			{									
				foreach(Control subcontrol in p_ctlControl.Controls)
				{										
					m_mthClearAllInfo(subcontrol);						
				} 	
			}			
		}


		
		private void frmDeathCaseDiscuss_Load(object sender, System.EventArgs e)
		{
			m_mthfrmLoad();
            //if(m_objCurrentPatient !=null)
            //{
            //    m_lblInHospitalTime.Text=m_objCurrentPatient.m_DtmSelectedHISInDate.ToString("yyyy年MM月dd日");
            //}
			this.m_dtpCreateDate.m_EnmVisibleFlag=MDIParent.s_ObjRecordDateTimeInfo.m_enmGetRecordTimeFlag(this.Name);
			this.m_dtpCreateDate.m_mthResetSize();

			m_trvCreateDate.Focus();
		}

		protected override void m_mthSetPatientInHospitalDate(clsPatient p_objSelectedPatient)
		{
			//判断病人信息是否为null，如果是，直接返回。
			if(p_objSelectedPatient == null)
				return;   

			//记录病人信息
			m_objCurrentPatient = p_objSelectedPatient;
            //m_lblInHospitalTime.Text=m_objCurrentPatient.m_DtmSelectedHISInDate.ToString("yyyy年MM月dd日");

		}

		
		
		/// <summary>
		/// 数据复用
		/// </summary>
		/// <param name="p_objSelectedPatient"></param>
		protected override void m_mthDataShare(clsPatient p_objSelectedPatient)
		{
			clsInPatientCaseHisoryDefaultValue [] objInPatientCaseDefaultValue = new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(p_objSelectedPatient.m_StrInPatientID,p_objSelectedPatient.m_DtmSelectedInDate.ToString());
			if(objInPatientCaseDefaultValue !=null && objInPatientCaseDefaultValue.Length >0)
			{
				this.m_txtInHospitalDiagnose.Text=objInPatientCaseDefaultValue[0].m_strPrimaryDiagnose;
			}
		}

		#region 审核
		private string m_strCurrentOpenDate = "";
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

		protected override bool m_BlnCanApprove
		{
			get
			{
				return true;
			}
		}		
		#endregion 
		
		#region 属性
		protected override enmApproveType m_EnmAppType
		{
			get{return enmApproveType.CaseHistory;}
		}
		protected override string m_StrRecorder_ID
		{
			get
			{
				if(m_txtRecorder.Tag != null)
					return ((clsEmrEmployeeBase_VO)m_txtRecorder.Tag).m_strEMPNO_CHR.Trim();
				return "";
			}
		}

		#endregion 属性
		
		#region 外部打印.	
				
		//System.Drawing.Printing.PrintDocument m_pdcPrintDocument;
		private void m_mthfrmLoad()
		{	
			if(m_pdcPrintDocument==null)
				this.m_pdcPrintDocument = new System.Drawing.Printing.PrintDocument();
			this.m_pdcPrintDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_BeginPrint);
			this.m_pdcPrintDocument.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_EndPrint);
			this.m_pdcPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.m_pdcPrintDocument_PrintPage);		
		}
		private void m_pdcPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{			
			objPrintTool.m_mthPrintPage(e);
		}
		
		private void m_pdcPrintDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			objPrintTool.m_mthBeginPrint(e);				
		}
		
		private void m_pdcPrintDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			objPrintTool.m_mthEndPrint(e);
		}
		
		//		private bool m_blnHasInitPrintTool=false;
		clsDeathDiscussPrintTool objPrintTool;
		private void m_mthDemoPrint_FromDataSource()
		{	
			//			if(m_blnHasInitPrintTool==false)
			//			{
			objPrintTool=new clsDeathDiscussPrintTool();
			objPrintTool.m_mthInitPrintTool(null);	
			//				m_blnHasInitPrintTool=true;
			//			}
			if(m_objBaseCurrentPatient==null || m_ObjCurrentEmrPatientSession == null)
				objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,DateTime.MinValue,DateTime.MinValue);
			else
            {
                m_objBaseCurrentPatient.m_StrHISInPatientID = m_ObjCurrentEmrPatientSession.m_strHISInpatientId;
                m_objBaseCurrentPatient.m_DtmSelectedHISInDate = m_ObjCurrentEmrPatientSession.m_dtmHISInpatientDate;
				if(m_objCurrentRecordContent ==null)
					objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,m_objBaseCurrentPatient.m_DtmSelectedInDate,DateTime.MinValue);
				else
                    objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, m_objBaseCurrentPatient.m_DtmSelectedInDate, m_objCurrentRecordContent.m_dtmOpenDate);
			}
			objPrintTool.m_mthInitPrintContent();						
						
			m_mthStartPrint_this();
		}
				
		private void m_mthStartPrint_this()
		{			
			if(m_blnDirectPrint)
			{
				m_pdcPrintDocument.Print();
			}
			else
			{
				PrintTool.frmPrintPreviewDialog ppdPrintPreview = new PrintTool.frmPrintPreviewDialog();
				ppdPrintPreview.Document = m_pdcPrintDocument;
				ppdPrintPreview.ShowDialog();
			}
		}
				
		protected override long m_lngSubPrint()//代替原窗体中的同名打印函数
		{				
			m_mthDemoPrint_FromDataSource();				
			return 1;
		}
		#endregion 外部打印.


        #region 作废重做

        protected override bool m_blnSubReuse(clsInactiveRecordInfo_VO p_objSelectedValue)
        {
            bool blnIsOK = false;
            if (p_objSelectedValue != null)
            {
                clsTrackRecordContent m_objContent = new clsDeadCaseDiscussRecord_VO();

                long lngRes = m_objGetDiseaseTrackDomain().m_lngGetDeleteRecordContent(p_objSelectedValue.m_StrInpatientId, p_objSelectedValue.m_DtmInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"), p_objSelectedValue.m_DtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"), out m_objContent);
                if (lngRes <= 0 || m_objContent == null)
                {
                    switch (lngRes)
                    {
                        case (long)(iCareData.enmOperationResult.Not_permission):
                            m_mthShowNotPermitted(); break;
                        case (long)(iCareData.enmOperationResult.DB_Fail):
                            m_mthShowDBError(); break;
                    }
                    return blnIsOK;
                }
                clsDeadCaseDiscussRecord_VO p_objContent = (clsDeadCaseDiscussRecord_VO)m_objContent;

                this.m_dtpDiscussTime.Text = p_objContent.m_dtmDiscussDate.ToString("yyyy-MM-dd hh:mm:ss");
                this.m_txtDiscussAddress.Text = p_objContent.m_strDiscussAddress;
                this.m_txtCompere.Text = p_objContent.m_strCompereName;
                //this.m_lsvAttendeeList= p_objContent.m_strAttendeeNameArr
                this.m_lsvAttendeeList.Items.Clear();
                string[] strAttendeeName = p_objContent.m_strAttendeeNameArr;
                ListViewItem lviAttendeeName = null;
                foreach(string i in strAttendeeName)
                {
                    lviAttendeeName = new ListViewItem();
                    lviAttendeeName.Text = i.ToString();
                    this.m_lsvAttendeeList.Items.Add(lviAttendeeName);
                }
                this.m_txtInHospitalDiagnose.Text = p_objContent.m_strInHospitalDiagnose;
                this.m_txtSpeakRecord.Text = p_objContent.m_strSpeakRecord;
                this.m_txtVerdict.Text = p_objContent.m_strVerdict;
                this.m_txtDeadDiagnose.Text = p_objContent.m_strDeadDiagnose;
                this.m_txtDeadReason.Text = p_objContent.m_strDeadReason;
                this.m_txtExperience.Text = p_objContent.m_strExperience;
                this.m_txtRecorder.Text = p_objContent.m_strRecorderName;
                this.m_txtCompereSign.Text = p_objContent.m_strCompereSignName;

                //clsEmrSignToolCollection m_objSign = new clsEmrSignToolCollection();


                blnIsOK = true;
            }
            return blnIsOK;
        }

        //infPrintRecord objPrintTool;
        protected override void m_mthSubPreviewInactiveRecord(IWin32Window p_infOwner, clsInactiveRecordInfo_VO p_objSelectedValue)
        {
            if (p_objSelectedValue == null) return;
            objPrintTool = new clsDeathDiscussPrintTool();

            if (m_objBaseCurrentPatient != null)
            {
                objPrintTool.m_mthInitPrintTool(null);
                objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,
                    p_objSelectedValue.m_DtmInpatientDate,
                    p_objSelectedValue.m_DtmOpenDate);
                clsPrintInfo_DeathCaseDiscussRecord objPrintInfo = new clsPrintInfo_DeathCaseDiscussRecord();


                //objPrintInfo.m_dtmHISInDate = p_objSelectedValue.m_DtmInpatientDate;  //???
                objPrintInfo.m_dtmInPatientDate = p_objSelectedValue.m_DtmInpatientDate;
                objPrintInfo.m_dtmOpenDate = p_objSelectedValue.m_DtmOpenDate;
                //objPrintInfo.m_strAge = p_objSelectedValue;           
                //objPrintInfo.m_strAreaName
                //objPrintInfo.m_strBedName
                //objPrintInfo.m_strDeptName=
                //objPrintInfo.m_strHISInPatientID=
                objPrintInfo.m_strInPatentID = p_objSelectedValue.m_StrInpatientId;
                //objPrintInfo.m_strPatientName =
                //objPrintInfo.m_strSex=


                clsTrackRecordContent p_objContent = new clsDeadCaseDiscussRecord_VO();
                long lngRes = m_objGetDiseaseTrackDomain().m_lngGetDeleteRecordContent(p_objSelectedValue.m_StrInpatientId, p_objSelectedValue.m_DtmInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"), p_objSelectedValue.m_DtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"), out p_objContent);
                clsDeadCaseDiscussRecord_VO objContent = (clsDeadCaseDiscussRecord_VO)p_objContent;
                //objPrintInfo.m_objContent = objContent;
                objPrintInfo.m_objRecordContent = objContent;
                //objPrintInfo.m_blnIsFirstPrint = false;

                objPrintTool.m_mthSetPrintContent(objPrintInfo);



                m_mthStartPrint();
                //ppdPrintPreview.Document = m_pdcPrintDocument;
                //ppdPrintPreview.ShowDialog(p_infOwner);
            }
        }

        protected override clsInactiveRecordInfo_VO[] m_objSubGetAllInactiveInfo(clsInactiveRecordInfo_VO p_objSelectedValue)
        {
            clsInactiveRecordInfo_VO[] objArr = null;

            new clsInPatientCaseHistoryDomain().m_lngGetAllInactiveInfo(p_objSelectedValue.m_StrInpatientId, p_objSelectedValue.m_DtmInpatientDate, out objArr);
            return objArr;
        }
        public override bool m_blnIsNewSetInactiveForm
        {
            get { return true; }
        }
        #endregion 作废重做

	}
}
