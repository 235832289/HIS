
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using iCareData;
using com.digitalwave.controls;
using System.Data;
using HRP;
using System.Xml;

namespace iCare
{
	/// <summary>
	/// 催产素脉点滴观察表(增加，修改窗体)
	/// </summary>
	public class frmHurryVeinRecord_AcadCon : frmDiseaseTrackBase
	{
		#region define
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		protected System.Windows.Forms.ListView m_lsvEmployee;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private PinkieControls.ButtonXP m_cmdOK;
		private PinkieControls.ButtonXP m_cmdCancel;
		private clsEmployeeSignTool m_objSignTool;
		private clsCommonUseToolCollection m_objCUTC;
		private PinkieControls.ButtonXP m_cmdSign;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label18;
		private com.digitalwave.controls.ctlRichTextBox m_txtBeforehand_chr;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		#endregion

		public System.DateTime m_dtmBEFOREHAND_CHR = System.DateTime.Now;
		public string m_strLAYCOUNT_CHR = "";
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private com.digitalwave.controls.ctlRichTextBox m_txtCHROMA_CHR;
		private com.digitalwave.controls.ctlRichTextBox m_txtBLOODPRESSURE_CHR;
		private com.digitalwave.controls.ctlRichTextBox m_txtDROPCOUNT_CHR;
		private com.digitalwave.controls.ctlRichTextBox m_txtPALACESHRINK_CHR;
		private com.digitalwave.controls.ctlRichTextBox m_txtEMBRYOHEART_CHR;
		private com.digitalwave.controls.ctlRichTextBox m_txtEXPAND_CHR;
		private com.digitalwave.controls.ctlRichTextBox m_txtPRESENTATION_CHR;
		private com.digitalwave.controls.ctlRichTextBox m_txtSPECIALRECORD_CHR;
		private com.digitalwave.controls.ctlRichTextBox m_txtSIGNATURE_CHR;
		public string m_strFlag = "0";//是否新增


		#region 孕产,孕周等传值等变量 。
		public string date  = "";
		public string InPatientID  = "";
		public string	p_strlaycount_chr = "";
		public string	p_strPregnantweek_chr = "";
		public string	p_strScorecount_chr = "";
		public string	p_strRdbneckexpand_chr = "";
		public string	p_strRdbneckshink_chr = "";
		public string	p_strRdbhighlow_chr = "";
		public string	p_strRdbneckhard_chr = "";
		public string	p_strDroppingcase_chr = "";
		public string	p_strIndicate_chr = "";
		public string	p_strUsecount_chr = "";
		public string	p_strLayway_chr = "";
		public string	p_strRdbnecklocation_chr = "";
		#endregion 

		public frmHurryVeinRecord_AcadCon()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			m_mthSetRichTextBoxAttribInControl(this);
			m_objSignTool = new clsEmployeeSignTool(m_lsvEmployee);
			m_objSignTool.m_mthAddControl(new Control[]{m_txtSIGNATURE_CHR},false);
			m_objCUTC = new clsCommonUseToolCollection(this);
			m_objCUTC.m_mthBindEmployeeSign(new Control[]{m_cmdSign},new Control[]{m_txtSIGNATURE_CHR},new int[]{1});

			
		}


		public override int m_IntFormID
		{
			get
			{
				return 95;
			}
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txtCHROMA_CHR = new com.digitalwave.controls.ctlRichTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.m_txtBLOODPRESSURE_CHR = new com.digitalwave.controls.ctlRichTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtDROPCOUNT_CHR = new com.digitalwave.controls.ctlRichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_txtPALACESHRINK_CHR = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtEMBRYOHEART_CHR = new com.digitalwave.controls.ctlRichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.m_txtEXPAND_CHR = new com.digitalwave.controls.ctlRichTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.m_txtPRESENTATION_CHR = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtSPECIALRECORD_CHR = new com.digitalwave.controls.ctlRichTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.m_txtBeforehand_chr = new com.digitalwave.controls.ctlRichTextBox();
            this.m_lsvEmployee = new System.Windows.Forms.ListView();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.m_cmdOK = new PinkieControls.ButtonXP();
            this.m_cmdCancel = new PinkieControls.ButtonXP();
            this.m_cmdSign = new PinkieControls.ButtonXP();
            this.m_txtSIGNATURE_CHR = new com.digitalwave.controls.ctlRichTextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.m_pnlNewBase.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_trvCreateDate
            // 
            this.m_trvCreateDate.LineColor = System.Drawing.Color.Black;
            this.m_trvCreateDate.Location = new System.Drawing.Point(32, -96);
            this.m_trvCreateDate.Size = new System.Drawing.Size(212, 96);
            this.m_trvCreateDate.Visible = false;
            // 
            // lblCreateDateTitle
            // 
            this.lblCreateDateTitle.Location = new System.Drawing.Point(16, 8);
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.Location = new System.Drawing.Point(96, 6);
            // 
            // m_dtpGetDataTime
            // 
            this.m_dtpGetDataTime.Location = new System.Drawing.Point(352, -56);
            // 
            // m_lblGetDataTime
            // 
            this.m_lblGetDataTime.Location = new System.Drawing.Point(248, -56);
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(628, -120);
            this.lblSex.Size = new System.Drawing.Size(48, 32);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(736, -120);
            this.lblAge.Size = new System.Drawing.Size(52, 32);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(236, -112);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(224, -80);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(408, -112);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(580, -120);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(688, -120);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(32, -48);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(280, -144);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(116, 117);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(280, -88);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(452, -120);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(280, -120);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(80, -56);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(452, -96);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(280, -96);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(80, -88);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(32, -80);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(704, -80);
            this.m_cmdNewTemplate.Size = new System.Drawing.Size(84, 45);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Location = new System.Drawing.Point(196, -120);
            this.m_cmdNext.Size = new System.Drawing.Size(24, 34);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(156, -120);
            this.m_cmdPre.Size = new System.Drawing.Size(24, 34);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(272, -112);
            this.m_lblForTitle.Size = new System.Drawing.Size(16, 36);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            // 
            // groupBox3
            // 
            this.groupBox3.AccessibleDescription = "ctlRichTextBox9_TextChanged";
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.m_txtCHROMA_CHR);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.m_txtBLOODPRESSURE_CHR);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.m_txtDROPCOUNT_CHR);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.m_txtPALACESHRINK_CHR);
            this.groupBox3.Controls.Add(this.m_txtEMBRYOHEART_CHR);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.m_txtEXPAND_CHR);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.m_txtPRESENTATION_CHR);
            this.groupBox3.Controls.Add(this.m_txtSPECIALRECORD_CHR);
            this.groupBox3.Location = new System.Drawing.Point(8, 40);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(752, 224);
            this.groupBox3.TabIndex = 10000007;
            this.groupBox3.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 14);
            this.label4.TabIndex = 1111;
            this.label4.Text = "催产素浓度:";
            // 
            // m_txtCHROMA_CHR
            // 
            this.m_txtCHROMA_CHR.AccessibleDescription = "孕/产次";
            this.m_txtCHROMA_CHR.BackColor = System.Drawing.Color.White;
            this.m_txtCHROMA_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCHROMA_CHR.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtCHROMA_CHR.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCHROMA_CHR.Location = new System.Drawing.Point(112, 24);
            this.m_txtCHROMA_CHR.m_BlnIgnoreUserInfo = false;
            this.m_txtCHROMA_CHR.m_BlnPartControl = false;
            this.m_txtCHROMA_CHR.m_BlnReadOnly = false;
            this.m_txtCHROMA_CHR.m_BlnUnderLineDST = false;
            this.m_txtCHROMA_CHR.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCHROMA_CHR.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCHROMA_CHR.m_IntCanModifyTime = 6;
            this.m_txtCHROMA_CHR.m_IntPartControlLength = 0;
            this.m_txtCHROMA_CHR.m_IntPartControlStartIndex = 0;
            this.m_txtCHROMA_CHR.m_StrUserID = "";
            this.m_txtCHROMA_CHR.m_StrUserName = "";
            this.m_txtCHROMA_CHR.MaxLength = 3000;
            this.m_txtCHROMA_CHR.Multiline = false;
            this.m_txtCHROMA_CHR.Name = "m_txtCHROMA_CHR";
            this.m_txtCHROMA_CHR.Size = new System.Drawing.Size(120, 22);
            this.m_txtCHROMA_CHR.TabIndex = 1112;
            this.m_txtCHROMA_CHR.Text = "";
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(16, 48);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(24, 19);
            this.label18.TabIndex = 1110;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(56, 88);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 14);
            this.label15.TabIndex = 1104;
            this.label15.Text = "血压:";
            // 
            // m_txtBLOODPRESSURE_CHR
            // 
            this.m_txtBLOODPRESSURE_CHR.AccessibleDescription = "胎膜";
            this.m_txtBLOODPRESSURE_CHR.BackColor = System.Drawing.Color.White;
            this.m_txtBLOODPRESSURE_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBLOODPRESSURE_CHR.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBLOODPRESSURE_CHR.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBLOODPRESSURE_CHR.Location = new System.Drawing.Point(112, 88);
            this.m_txtBLOODPRESSURE_CHR.m_BlnIgnoreUserInfo = false;
            this.m_txtBLOODPRESSURE_CHR.m_BlnPartControl = false;
            this.m_txtBLOODPRESSURE_CHR.m_BlnReadOnly = false;
            this.m_txtBLOODPRESSURE_CHR.m_BlnUnderLineDST = false;
            this.m_txtBLOODPRESSURE_CHR.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBLOODPRESSURE_CHR.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBLOODPRESSURE_CHR.m_IntCanModifyTime = 6;
            this.m_txtBLOODPRESSURE_CHR.m_IntPartControlLength = 0;
            this.m_txtBLOODPRESSURE_CHR.m_IntPartControlStartIndex = 0;
            this.m_txtBLOODPRESSURE_CHR.m_StrUserID = "";
            this.m_txtBLOODPRESSURE_CHR.m_StrUserName = "";
            this.m_txtBLOODPRESSURE_CHR.MaxLength = 3000;
            this.m_txtBLOODPRESSURE_CHR.Multiline = false;
            this.m_txtBLOODPRESSURE_CHR.Name = "m_txtBLOODPRESSURE_CHR";
            this.m_txtBLOODPRESSURE_CHR.Size = new System.Drawing.Size(120, 22);
            this.m_txtBLOODPRESSURE_CHR.TabIndex = 1107;
            this.m_txtBLOODPRESSURE_CHR.Text = "";
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(248, 64);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(24, 19);
            this.label16.TabIndex = 1105;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(8, 112);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(119, 14);
            this.label17.TabIndex = 1106;
            this.label17.Text = "特殊情况及处理 :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 14);
            this.label3.TabIndex = 1103;
            this.label3.Text = "U/500ml";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(480, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 1101;
            this.label1.Text = "滴/分";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(312, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "滴数:";
            // 
            // m_txtDROPCOUNT_CHR
            // 
            this.m_txtDROPCOUNT_CHR.AccessibleDescription = "胎位";
            this.m_txtDROPCOUNT_CHR.BackColor = System.Drawing.Color.White;
            this.m_txtDROPCOUNT_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDROPCOUNT_CHR.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtDROPCOUNT_CHR.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDROPCOUNT_CHR.Location = new System.Drawing.Point(352, 24);
            this.m_txtDROPCOUNT_CHR.m_BlnIgnoreUserInfo = false;
            this.m_txtDROPCOUNT_CHR.m_BlnPartControl = false;
            this.m_txtDROPCOUNT_CHR.m_BlnReadOnly = false;
            this.m_txtDROPCOUNT_CHR.m_BlnUnderLineDST = false;
            this.m_txtDROPCOUNT_CHR.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDROPCOUNT_CHR.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDROPCOUNT_CHR.m_IntCanModifyTime = 6;
            this.m_txtDROPCOUNT_CHR.m_IntPartControlLength = 0;
            this.m_txtDROPCOUNT_CHR.m_IntPartControlStartIndex = 0;
            this.m_txtDROPCOUNT_CHR.m_StrUserID = "";
            this.m_txtDROPCOUNT_CHR.m_StrUserName = "";
            this.m_txtDROPCOUNT_CHR.MaxLength = 3000;
            this.m_txtDROPCOUNT_CHR.Multiline = false;
            this.m_txtDROPCOUNT_CHR.Name = "m_txtDROPCOUNT_CHR";
            this.m_txtDROPCOUNT_CHR.Size = new System.Drawing.Size(120, 22);
            this.m_txtDROPCOUNT_CHR.TabIndex = 500;
            this.m_txtDROPCOUNT_CHR.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(552, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 14);
            this.label6.TabIndex = 0;
            this.label6.Text = "宫缩:";
            // 
            // m_txtPALACESHRINK_CHR
            // 
            this.m_txtPALACESHRINK_CHR.AccessibleDescription = "胎心";
            this.m_txtPALACESHRINK_CHR.BackColor = System.Drawing.Color.White;
            this.m_txtPALACESHRINK_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPALACESHRINK_CHR.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtPALACESHRINK_CHR.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPALACESHRINK_CHR.Location = new System.Drawing.Point(600, 24);
            this.m_txtPALACESHRINK_CHR.m_BlnIgnoreUserInfo = false;
            this.m_txtPALACESHRINK_CHR.m_BlnPartControl = false;
            this.m_txtPALACESHRINK_CHR.m_BlnReadOnly = false;
            this.m_txtPALACESHRINK_CHR.m_BlnUnderLineDST = false;
            this.m_txtPALACESHRINK_CHR.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPALACESHRINK_CHR.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPALACESHRINK_CHR.m_IntCanModifyTime = 6;
            this.m_txtPALACESHRINK_CHR.m_IntPartControlLength = 0;
            this.m_txtPALACESHRINK_CHR.m_IntPartControlStartIndex = 0;
            this.m_txtPALACESHRINK_CHR.m_StrUserID = "";
            this.m_txtPALACESHRINK_CHR.m_StrUserName = "";
            this.m_txtPALACESHRINK_CHR.MaxLength = 3000;
            this.m_txtPALACESHRINK_CHR.Multiline = false;
            this.m_txtPALACESHRINK_CHR.Name = "m_txtPALACESHRINK_CHR";
            this.m_txtPALACESHRINK_CHR.Size = new System.Drawing.Size(136, 22);
            this.m_txtPALACESHRINK_CHR.TabIndex = 600;
            this.m_txtPALACESHRINK_CHR.Text = "";
            // 
            // m_txtEMBRYOHEART_CHR
            // 
            this.m_txtEMBRYOHEART_CHR.AccessibleDescription = "血压1";
            this.m_txtEMBRYOHEART_CHR.BackColor = System.Drawing.Color.White;
            this.m_txtEMBRYOHEART_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtEMBRYOHEART_CHR.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtEMBRYOHEART_CHR.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtEMBRYOHEART_CHR.Location = new System.Drawing.Point(112, 56);
            this.m_txtEMBRYOHEART_CHR.m_BlnIgnoreUserInfo = false;
            this.m_txtEMBRYOHEART_CHR.m_BlnPartControl = false;
            this.m_txtEMBRYOHEART_CHR.m_BlnReadOnly = false;
            this.m_txtEMBRYOHEART_CHR.m_BlnUnderLineDST = false;
            this.m_txtEMBRYOHEART_CHR.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtEMBRYOHEART_CHR.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtEMBRYOHEART_CHR.m_IntCanModifyTime = 6;
            this.m_txtEMBRYOHEART_CHR.m_IntPartControlLength = 0;
            this.m_txtEMBRYOHEART_CHR.m_IntPartControlStartIndex = 0;
            this.m_txtEMBRYOHEART_CHR.m_StrUserID = "";
            this.m_txtEMBRYOHEART_CHR.m_StrUserName = "";
            this.m_txtEMBRYOHEART_CHR.MaxLength = 3000;
            this.m_txtEMBRYOHEART_CHR.Multiline = false;
            this.m_txtEMBRYOHEART_CHR.Name = "m_txtEMBRYOHEART_CHR";
            this.m_txtEMBRYOHEART_CHR.Size = new System.Drawing.Size(120, 22);
            this.m_txtEMBRYOHEART_CHR.TabIndex = 800;
            this.m_txtEMBRYOHEART_CHR.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(64, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 14);
            this.label8.TabIndex = 0;
            this.label8.Text = "胎心:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(280, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 14);
            this.label10.TabIndex = 0;
            this.label10.Text = "宫口扩张:";
            // 
            // m_txtEXPAND_CHR
            // 
            this.m_txtEXPAND_CHR.AccessibleDescription = "宫口";
            this.m_txtEXPAND_CHR.BackColor = System.Drawing.Color.White;
            this.m_txtEXPAND_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtEXPAND_CHR.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtEXPAND_CHR.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtEXPAND_CHR.Location = new System.Drawing.Point(352, 56);
            this.m_txtEXPAND_CHR.m_BlnIgnoreUserInfo = false;
            this.m_txtEXPAND_CHR.m_BlnPartControl = false;
            this.m_txtEXPAND_CHR.m_BlnReadOnly = false;
            this.m_txtEXPAND_CHR.m_BlnUnderLineDST = false;
            this.m_txtEXPAND_CHR.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtEXPAND_CHR.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtEXPAND_CHR.m_IntCanModifyTime = 6;
            this.m_txtEXPAND_CHR.m_IntPartControlLength = 0;
            this.m_txtEXPAND_CHR.m_IntPartControlStartIndex = 0;
            this.m_txtEXPAND_CHR.m_StrUserID = "";
            this.m_txtEXPAND_CHR.m_StrUserName = "";
            this.m_txtEXPAND_CHR.MaxLength = 3000;
            this.m_txtEXPAND_CHR.Multiline = false;
            this.m_txtEXPAND_CHR.Name = "m_txtEXPAND_CHR";
            this.m_txtEXPAND_CHR.Size = new System.Drawing.Size(120, 22);
            this.m_txtEXPAND_CHR.TabIndex = 900;
            this.m_txtEXPAND_CHR.Text = "";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(48, 88);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 19);
            this.label11.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(520, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 14);
            this.label12.TabIndex = 0;
            this.label12.Text = "先露高低 :";
            // 
            // m_txtPRESENTATION_CHR
            // 
            this.m_txtPRESENTATION_CHR.AccessibleDescription = "先露";
            this.m_txtPRESENTATION_CHR.BackColor = System.Drawing.Color.White;
            this.m_txtPRESENTATION_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPRESENTATION_CHR.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtPRESENTATION_CHR.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPRESENTATION_CHR.Location = new System.Drawing.Point(600, 56);
            this.m_txtPRESENTATION_CHR.m_BlnIgnoreUserInfo = false;
            this.m_txtPRESENTATION_CHR.m_BlnPartControl = false;
            this.m_txtPRESENTATION_CHR.m_BlnReadOnly = false;
            this.m_txtPRESENTATION_CHR.m_BlnUnderLineDST = false;
            this.m_txtPRESENTATION_CHR.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPRESENTATION_CHR.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPRESENTATION_CHR.m_IntCanModifyTime = 6;
            this.m_txtPRESENTATION_CHR.m_IntPartControlLength = 0;
            this.m_txtPRESENTATION_CHR.m_IntPartControlStartIndex = 0;
            this.m_txtPRESENTATION_CHR.m_StrUserID = "";
            this.m_txtPRESENTATION_CHR.m_StrUserName = "";
            this.m_txtPRESENTATION_CHR.MaxLength = 3000;
            this.m_txtPRESENTATION_CHR.Multiline = false;
            this.m_txtPRESENTATION_CHR.Name = "m_txtPRESENTATION_CHR";
            this.m_txtPRESENTATION_CHR.Size = new System.Drawing.Size(136, 22);
            this.m_txtPRESENTATION_CHR.TabIndex = 1000;
            this.m_txtPRESENTATION_CHR.Text = "";
            // 
            // m_txtSPECIALRECORD_CHR
            // 
            this.m_txtSPECIALRECORD_CHR.AccessibleDescription = "其它";
            this.m_txtSPECIALRECORD_CHR.BackColor = System.Drawing.Color.White;
            this.m_txtSPECIALRECORD_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSPECIALRECORD_CHR.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtSPECIALRECORD_CHR.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSPECIALRECORD_CHR.Location = new System.Drawing.Point(112, 136);
            this.m_txtSPECIALRECORD_CHR.m_BlnIgnoreUserInfo = false;
            this.m_txtSPECIALRECORD_CHR.m_BlnPartControl = false;
            this.m_txtSPECIALRECORD_CHR.m_BlnReadOnly = false;
            this.m_txtSPECIALRECORD_CHR.m_BlnUnderLineDST = false;
            this.m_txtSPECIALRECORD_CHR.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSPECIALRECORD_CHR.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSPECIALRECORD_CHR.m_IntCanModifyTime = 6;
            this.m_txtSPECIALRECORD_CHR.m_IntPartControlLength = 0;
            this.m_txtSPECIALRECORD_CHR.m_IntPartControlStartIndex = 0;
            this.m_txtSPECIALRECORD_CHR.m_StrUserID = "";
            this.m_txtSPECIALRECORD_CHR.m_StrUserName = "";
            this.m_txtSPECIALRECORD_CHR.MaxLength = 3000;
            this.m_txtSPECIALRECORD_CHR.Name = "m_txtSPECIALRECORD_CHR";
            this.m_txtSPECIALRECORD_CHR.Size = new System.Drawing.Size(624, 80);
            this.m_txtSPECIALRECORD_CHR.TabIndex = 1100;
            this.m_txtSPECIALRECORD_CHR.Text = "";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(320, 8);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 14);
            this.label13.TabIndex = 1109;
            this.label13.Text = "预产期:";
            this.label13.Visible = false;
            // 
            // m_txtBeforehand_chr
            // 
            this.m_txtBeforehand_chr.AccessibleDescription = "预产期";
            this.m_txtBeforehand_chr.BackColor = System.Drawing.Color.White;
            this.m_txtBeforehand_chr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBeforehand_chr.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBeforehand_chr.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBeforehand_chr.Location = new System.Drawing.Point(616, 8);
            this.m_txtBeforehand_chr.m_BlnIgnoreUserInfo = false;
            this.m_txtBeforehand_chr.m_BlnPartControl = false;
            this.m_txtBeforehand_chr.m_BlnReadOnly = false;
            this.m_txtBeforehand_chr.m_BlnUnderLineDST = false;
            this.m_txtBeforehand_chr.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBeforehand_chr.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBeforehand_chr.m_IntCanModifyTime = 6;
            this.m_txtBeforehand_chr.m_IntPartControlLength = 0;
            this.m_txtBeforehand_chr.m_IntPartControlStartIndex = 0;
            this.m_txtBeforehand_chr.m_StrUserID = "";
            this.m_txtBeforehand_chr.m_StrUserName = "";
            this.m_txtBeforehand_chr.MaxLength = 8000;
            this.m_txtBeforehand_chr.Multiline = false;
            this.m_txtBeforehand_chr.Name = "m_txtBeforehand_chr";
            this.m_txtBeforehand_chr.Size = new System.Drawing.Size(104, 22);
            this.m_txtBeforehand_chr.TabIndex = 1113;
            this.m_txtBeforehand_chr.Text = "";
            this.m_txtBeforehand_chr.Visible = false;
            this.m_txtBeforehand_chr.TextChanged += new System.EventHandler(this.m_txtBeforehand_chr_TextChanged);
            // 
            // m_lsvEmployee
            // 
            this.m_lsvEmployee.BackColor = System.Drawing.Color.White;
            this.m_lsvEmployee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lsvEmployee.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7});
            this.m_lsvEmployee.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvEmployee.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_lsvEmployee.FullRowSelect = true;
            this.m_lsvEmployee.GridLines = true;
            this.m_lsvEmployee.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_lsvEmployee.Location = new System.Drawing.Point(112, 168);
            this.m_lsvEmployee.Name = "m_lsvEmployee";
            this.m_lsvEmployee.Size = new System.Drawing.Size(102, 105);
            this.m_lsvEmployee.TabIndex = 10000024;
            this.m_lsvEmployee.UseCompatibleStateImageBehavior = false;
            this.m_lsvEmployee.View = System.Windows.Forms.View.Details;
            this.m_lsvEmployee.DoubleClick += new System.EventHandler(this.m_lsvEmployee_DoubleClick);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Width = 0;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Width = 100;
            // 
            // m_cmdOK
            // 
            this.m_cmdOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdOK.DefaultScheme = true;
            this.m_cmdOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdOK.Hint = "";
            this.m_cmdOK.Location = new System.Drawing.Point(520, 272);
            this.m_cmdOK.Name = "m_cmdOK";
            this.m_cmdOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdOK.Size = new System.Drawing.Size(64, 32);
            this.m_cmdOK.TabIndex = 10000022;
            this.m_cmdOK.Text = "保存";
            this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
            // 
            // m_cmdCancel
            // 
            this.m_cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdCancel.DefaultScheme = true;
            this.m_cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdCancel.Hint = "";
            this.m_cmdCancel.Location = new System.Drawing.Point(632, 272);
            this.m_cmdCancel.Name = "m_cmdCancel";
            this.m_cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCancel.Size = new System.Drawing.Size(64, 32);
            this.m_cmdCancel.TabIndex = 10000023;
            this.m_cmdCancel.Text = "关闭";
            this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
            // 
            // m_cmdSign
            // 
            this.m_cmdSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdSign.DefaultScheme = true;
            this.m_cmdSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSign.Hint = "";
            this.m_cmdSign.Location = new System.Drawing.Point(40, 272);
            this.m_cmdSign.Name = "m_cmdSign";
            this.m_cmdSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSign.Size = new System.Drawing.Size(64, 32);
            this.m_cmdSign.TabIndex = 10000022;
            this.m_cmdSign.Text = "签名:";
            // 
            // m_txtSIGNATURE_CHR
            // 
            this.m_txtSIGNATURE_CHR.AccessibleDescription = "签名";
            this.m_txtSIGNATURE_CHR.BackColor = System.Drawing.Color.White;
            this.m_txtSIGNATURE_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSIGNATURE_CHR.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtSIGNATURE_CHR.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSIGNATURE_CHR.Location = new System.Drawing.Point(112, 280);
            this.m_txtSIGNATURE_CHR.m_BlnIgnoreUserInfo = false;
            this.m_txtSIGNATURE_CHR.m_BlnPartControl = false;
            this.m_txtSIGNATURE_CHR.m_BlnReadOnly = false;
            this.m_txtSIGNATURE_CHR.m_BlnUnderLineDST = false;
            this.m_txtSIGNATURE_CHR.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSIGNATURE_CHR.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSIGNATURE_CHR.m_IntCanModifyTime = 6;
            this.m_txtSIGNATURE_CHR.m_IntPartControlLength = 0;
            this.m_txtSIGNATURE_CHR.m_IntPartControlStartIndex = 0;
            this.m_txtSIGNATURE_CHR.m_StrUserID = "";
            this.m_txtSIGNATURE_CHR.m_StrUserName = "";
            this.m_txtSIGNATURE_CHR.MaxLength = 8000;
            this.m_txtSIGNATURE_CHR.Multiline = false;
            this.m_txtSIGNATURE_CHR.Name = "m_txtSIGNATURE_CHR";
            this.m_txtSIGNATURE_CHR.Size = new System.Drawing.Size(104, 22);
            this.m_txtSIGNATURE_CHR.TabIndex = 1200;
            this.m_txtSIGNATURE_CHR.Text = "";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(384, 8);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker1.TabIndex = 10000025;
            this.dateTimePicker1.Visible = false;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // frmHurryVeinRecord_AcadCon
            // 
            this.ClientSize = new System.Drawing.Size(800, 317);
            this.Controls.Add(this.m_lsvEmployee);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.m_cmdOK);
            this.Controls.Add(this.m_cmdCancel);
            this.Controls.Add(this.m_cmdSign);
            this.Controls.Add(this.m_txtSIGNATURE_CHR);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.m_txtBeforehand_chr);
            this.Name = "frmHurryVeinRecord_AcadCon";
            this.Text = "催产素静脉点滴观察表";
            this.Load += new System.EventHandler(this.frmICUNurseRecord_GXCon_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmHurryVeinRecord_AcadCon_Closing);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_txtBeforehand_chr, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.dateTimePicker1, 0);
            this.Controls.SetChildIndex(this.m_txtSIGNATURE_CHR, 0);
            this.Controls.SetChildIndex(this.m_cmdSign, 0);
            this.Controls.SetChildIndex(this.m_cmdCancel, 0);
            this.Controls.SetChildIndex(this.m_cmdOK, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
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
            this.Controls.SetChildIndex(this.m_lsvEmployee, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public override iCare.clsDiseaseTrackInfo m_objGetDiseaseTrackInfo()
		{
			clsIntensiveRecordInfo objTrackInfo = new clsIntensiveRecordInfo();

			objTrackInfo.m_ObjRecordContent = m_objCurrentRecordContent;
			objTrackInfo.m_DtmRecordTime = m_dtpCreateDate.Value;
			objTrackInfo.m_StrTitle =this.m_lblForTitle.Text;

			//设置m_dtmRecordTime
			if(objTrackInfo.m_ObjRecordContent !=null)
			{
				m_dtpCreateDate.Value=objTrackInfo.m_ObjRecordContent.m_dtmCreateDate;
			}
			return objTrackInfo;	
		}

		/// <summary>
		/// 清空特殊记录信息，并重置记录控制状态为不控制。
		/// </summary>
		protected override void m_mthClearRecordInfo()
		{
			//清空具体记录内容				
	
			//	this.m_txtLayCount_chr.m_mthClearText();
			this.m_txtCHROMA_CHR.m_mthClearText();
			this.m_txtDROPCOUNT_CHR.m_mthClearText();
			this.m_txtPALACESHRINK_CHR.m_mthClearText();
			this.m_txtEMBRYOHEART_CHR.m_mthClearText();
			//	this.m_txtBeforehand_chr.m_mthClearText();
			this.m_txtEXPAND_CHR.m_mthClearText();
			this.m_txtPRESENTATION_CHR.m_mthClearText();
			this.m_txtBLOODPRESSURE_CHR.m_mthClearText();
			this.m_txtSPECIALRECORD_CHR.m_mthClearText();
			this.m_txtSIGNATURE_CHR.m_mthClearText();			
			
			m_objSignTool.m_mthSetDefaulEmployee();
		}

		/// <summary>
		/// 控制是否可以选择病人和记录时间列表。
		/// </summary>
		/// <param name="p_blnEnable"></param>
		protected override void m_mthEnablePatientSelectSub(bool p_blnEnable)
		{
			if(p_blnEnable==false)
			{
			
				m_cmdOK.Visible=true;
				
				this.CenterToParent();	
			}	
	
			this.MaximizeBox=false;
		}

		/// <summary>
		/// 具体记录的特殊控制,根据子窗体的需要重载实现
		/// </summary>
		/// <param name="p_blnEnable">是否允许修改特殊记录的记录信息。</param>
		protected override void m_mthEnableModifySub(bool p_blnEnable)
		{
		
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
		/// 把特殊记录的值显示到界面上。
		/// </summary>
		/// <param name="p_objContent"></param>
		protected override void m_mthSetGUIFromContent(iCareData.clsTrackRecordContent p_objContent)
		{
			clsHurryVeinRecord objContent=(clsHurryVeinRecord )p_objContent;
			//把表单值赋值到界面，由子窗体重载实现			
			this.m_mthClearRecordInfo();


			this.m_txtCHROMA_CHR.m_mthSetNewText(objContent.m_strCHROMA_CHR,objContent.m_strCHROMA_CHRXML);;
			this.m_txtDROPCOUNT_CHR.m_mthSetNewText(objContent.m_strDROPCOUNT_CHR,objContent.m_strDROPCOUNT_CHRXML);;
			this.m_txtPALACESHRINK_CHR.m_mthSetNewText(objContent.m_strPALACESHRINK_CHR,objContent.m_strPALACESHRINK_CHRXML);;
			this.m_txtEMBRYOHEART_CHR.m_mthSetNewText(objContent.m_strEMBRYOHEART_CHR,objContent.m_strEMBRYOHEART_CHRXML);;
			//	this.m_txtBeforehand_chr.m_mthSetNewText(objContent.m_strXXXr,objContent.m_strXML);;
			this.m_txtEXPAND_CHR.m_mthSetNewText(objContent.m_strEXPAND_CHR,objContent.m_strEXPAND_CHRXML);;
			this.m_txtPRESENTATION_CHR.m_mthSetNewText(objContent.m_strPRESENTATION_CHR,objContent.m_strPRESENTATION_CHRXML);;
			this.m_txtBLOODPRESSURE_CHR.m_mthSetNewText(objContent.m_strBLOODPRESSURE_CHR,objContent.m_strBLOODPRESSURE_CHRXML);;
			this.m_txtSPECIALRECORD_CHR.m_mthSetNewText(objContent.m_strSPECIALRECORD_CHR,objContent.m_strSPECIALRECORD_CHRXML);;
			this.m_txtSIGNATURE_CHR.m_mthSetNewText(objContent.m_strSIGNATURE_CHR,objContent.m_strSIGNATURE_CHRXML);;	
				
			
			if(objContent.m_strSIGNATURE_CHR !=null &&objContent.m_strSIGNATURE_CHR != "")
				m_txtSIGNATURE_CHR.Text=objContent.m_strSIGNATURE_CHR;
			this.m_txtSIGNATURE_CHR.Enabled = false;
			this.m_dtpCreateDate.Enabled = false;
		}

		protected override void m_mthSetDeletedGUIFromContent(iCareData.clsTrackRecordContent p_objContent)
		{
			clsHurryVeinRecord objContent=(clsHurryVeinRecord )p_objContent;
			//把表单值赋值到界面，由子窗体重载实现			

			this.m_mthClearRecordInfo();
		

			this.m_txtCHROMA_CHR.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strCHROMA_CHR,objContent.m_strCHROMA_CHRXML);;
			this.m_txtDROPCOUNT_CHR.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strDROPCOUNT_CHR,objContent.m_strDROPCOUNT_CHRXML);;
			this.m_txtPALACESHRINK_CHR.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strPALACESHRINK_CHR,objContent.m_strPALACESHRINK_CHRXML);;
			this.m_txtEMBRYOHEART_CHR.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strEMBRYOHEART_CHR,objContent.m_strEMBRYOHEART_CHRXML);;
			//	this.m_txtBeforehand_chr.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strXXXr,objContent.m_strXML);;
			this.m_txtEXPAND_CHR.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strEXPAND_CHR,objContent.m_strEXPAND_CHRXML);;
			this.m_txtPRESENTATION_CHR.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strPRESENTATION_CHR,objContent.m_strPRESENTATION_CHRXML);;
			this.m_txtBLOODPRESSURE_CHR.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strBLOODPRESSURE_CHR,objContent.m_strBLOODPRESSURE_CHRXML);;
			this.m_txtSPECIALRECORD_CHR.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strSPECIALRECORD_CHR,objContent.m_strSPECIALRECORD_CHRXML);;
			this.m_txtSIGNATURE_CHR.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strSIGNATURE_CHR,objContent.m_strSIGNATURE_CHRXML);;	
				
			if(objContent.m_strSIGNATURE_CHR !=null &&objContent.m_strSIGNATURE_CHR != "")
				m_txtSIGNATURE_CHR.Text=objContent.m_strSIGNATURE_CHR;
			this.m_txtSIGNATURE_CHR.Enabled = false;
			this.m_dtpCreateDate.Enabled = false;


		
		}

		protected override iCareData.clsTrackRecordContent m_objGetContentFromGUI()
		{
			
			//界面参数校验
			if(m_objCurrentPatient==null || this.txtInPatientID.Text!=this.m_objCurrentPatient.m_StrHISInPatientID || txtInPatientID.Text=="")				
				return null;

			//从界面获取表单值		
			clsHurryVeinRecord objContent=new clsHurryVeinRecord ();
			try
			{
				objContent.m_dtmCreateDate =DateTime.Now ;
 
			

				//				objContent.m_strINAMOUNTITEM_RIGHT=this.m_txtItem.m_strGetRightText();
				objContent.m_strCHROMA_CHR=this.m_txtCHROMA_CHR.Text;
				objContent.m_strCHROMA_CHR_RIGHT=this.m_txtCHROMA_CHR.m_strGetRightText();
				objContent.m_strCHROMA_CHRXML=this.m_txtCHROMA_CHR.m_strGetXmlText();

				objContent.m_strDROPCOUNT_CHR_RIGHT=this.m_txtDROPCOUNT_CHR.m_strGetRightText();
				objContent.m_strDROPCOUNT_CHR=this.m_txtDROPCOUNT_CHR.Text;
				objContent.m_strDROPCOUNT_CHRXML=this.m_txtDROPCOUNT_CHR.m_strGetXmlText();

				objContent.m_strPALACESHRINK_CHR_RIGHT=this.m_txtPALACESHRINK_CHR.m_strGetRightText();
				objContent.m_strPALACESHRINK_CHR=this.m_txtPALACESHRINK_CHR.Text;
				objContent.m_strPALACESHRINK_CHRXML=this.m_txtPALACESHRINK_CHR.m_strGetXmlText();

				objContent.m_strEMBRYOHEART_CHR_RIGHT=this.m_txtEMBRYOHEART_CHR.m_strGetRightText();
				objContent.m_strEMBRYOHEART_CHR=this.m_txtEMBRYOHEART_CHR.Text;
				objContent.m_strEMBRYOHEART_CHRXML=this.m_txtEMBRYOHEART_CHR.m_strGetXmlText();

				objContent.m_strEXPAND_CHR_RIGHT=this.m_txtEXPAND_CHR.m_strGetRightText();
				objContent.m_strEXPAND_CHR=this.m_txtEXPAND_CHR.Text;
				objContent.m_strEXPAND_CHRXML=this.m_txtEXPAND_CHR.m_strGetXmlText();

				objContent.m_strPRESENTATION_CHR_RIGHT=this.m_txtPRESENTATION_CHR.m_strGetRightText();
				objContent.m_strPRESENTATION_CHR=this.m_txtPRESENTATION_CHR.Text;
				objContent.m_strPRESENTATION_CHRXML=this.m_txtPRESENTATION_CHR.m_strGetXmlText();

				objContent.m_strBLOODPRESSURE_CHR_RIGHT=this.m_txtBLOODPRESSURE_CHR.m_strGetRightText();
				objContent.m_strBLOODPRESSURE_CHR=this.m_txtBLOODPRESSURE_CHR.Text;
				objContent.m_strBLOODPRESSURE_CHRXML=this.m_txtBLOODPRESSURE_CHR.m_strGetXmlText();
            			
				objContent.m_strSPECIALRECORD_CHR_RIGHT=this.m_txtSPECIALRECORD_CHR.m_strGetRightText();
				objContent.m_strSPECIALRECORD_CHR=this.m_txtSPECIALRECORD_CHR.Text;
				objContent.m_strSPECIALRECORD_CHRXML=this.m_txtSPECIALRECORD_CHR.m_strGetXmlText();

				objContent.m_strSIGNATURE_CHR_RIGHT=this.m_txtSIGNATURE_CHR.m_strGetRightText();
				objContent.m_strSIGNATURE_CHR=this.m_txtSIGNATURE_CHR.Text ;
				objContent.m_strSIGNATURE_CHRXML=this.m_txtSIGNATURE_CHR.m_strGetXmlText();

				

				objContent.m_strCreateUserID = ((clsEmployee)m_txtSIGNATURE_CHR.Tag).m_StrEmployeeID;
				objContent.m_dtmModifyDate = DateTime.Now;
				objContent.m_strModifyUserID = MDIParent.OperatorID;
			}
		
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			return(objContent );		
		}

		protected override iCare.clsDiseaseTrackDomain m_objGetDiseaseTrackDomain()
		{
			//获取护理记录的领域层实例，由子窗体重载实现
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.HurryVeinRecord);	
			//(需要改动)				
		}

		/// <summary>
		/// 把选择时间记录内容重新整理为完全正确的内容。
		/// </summary>
		/// <param name="p_objRecordContent"></param>
		protected override void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
		{
			//把选择时间记录内容重新整理为完全正确的内容，由子窗体重载实现。
			clsHurryVeinRecord objContent=(clsHurryVeinRecord)p_objRecordContent; //(需要改动)
		}

		public override string m_strReloadFormTitle()
		{
			//由子窗体重载实现
			//(需要改动)	
            return "催产素静脉点滴观察表";
		}

		
		#region Jump Control
		protected override void m_mthInitJump(clsJumpControl p_objJump)
		{	//(需要改动)	
			

			p_objJump=new clsJumpControl(this,
				new Control[]{m_txtCHROMA_CHR,m_txtDROPCOUNT_CHR,m_txtPALACESHRINK_CHR,m_txtEMBRYOHEART_CHR,m_txtEXPAND_CHR,m_txtPRESENTATION_CHR,
								 m_txtBLOODPRESSURE_CHR,m_txtSPECIALRECORD_CHR,m_txtSIGNATURE_CHR,m_cmdOK},Keys.Enter);
		}
		#endregion

		private void frmICUNurseRecord_GXCon_Load(object sender, System.EventArgs e)
		{
			m_txtCHROMA_CHR.Focus();
		}

		private void m_cmdOK_Click(object sender, System.EventArgs e)
		{
			if(m_lngSave() > 0)
			{
				this.DialogResult = DialogResult.Yes;
				this.Close();
			}
		}

		private void m_cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.None;
			this.Close();
		}

		private void m_txtAnusCheck_chr_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void m_txtIntermission_chr_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void m_lsvEmployee_DoubleClick(object sender, System.EventArgs e)
		{
			if(m_lsvEmployee.Items.Count!=0)
				if(m_lsvEmployee.SelectedItems.Count>0)
					m_txtSIGNATURE_CHR.Text = 	m_lsvEmployee.SelectedItems[0].Text;
			
		}

		private void dateTimePicker1_ValueChanged(object sender, System.EventArgs e)
		{
			m_txtBeforehand_chr.Text = this.dateTimePicker1.Value.ToString();
		}

		private void m_txtBeforehand_chr_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void frmHurryVeinRecord_AcadCon_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
		m_mthUpdateOther();
		}
		private void m_mthUpdateOther()
		{
            com.digitalwave.clsRecordsService.clsHurryVeinRecord_ContentService m_objInRoomSvc =
                (com.digitalwave.clsRecordsService.clsHurryVeinRecord_ContentService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsRecordsService.clsHurryVeinRecord_ContentService));

			 long res = 0;
			res = m_objInRoomSvc.m_lngGetUpdateOther(
				InPatientID  ,
				date  ,
				p_strlaycount_chr ,
				p_strPregnantweek_chr ,
				p_strScorecount_chr ,
				p_strRdbneckexpand_chr ,
				p_strRdbneckshink_chr ,
				p_strRdbhighlow_chr ,
				p_strRdbneckhard_chr ,
				p_strDroppingcase_chr ,
				p_strIndicate_chr ,
				p_strUsecount_chr ,
				p_strLayway_chr ,
				p_strRdbnecklocation_chr
				);
            //m_objInRoomSvc.Dispose();
			}
	}
}


