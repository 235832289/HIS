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
using com.digitalwave.emr.BEDExplorer;
using com.digitalwave.Emr.Signature_gui;

namespace iCare
{
	/// <summary>
	/// 候产记录(增加，修改窗体)
	/// </summary>
	public class frmWaitLayRecord_AcadCon : frmDiseaseTrackBase
	{
		#region define
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
		private PinkieControls.ButtonXP m_cmdOK;
        private PinkieControls.ButtonXP m_cmdCancel;
		private clsEmployeeSignTool m_objSignTool;
		private clsCommonUseToolCollection m_objCUTC;
		private PinkieControls.ButtonXP m_cmdSign;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private com.digitalwave.controls.ctlRichTextBox m_txtEmbryoLocation_chr;
		private com.digitalwave.controls.ctlRichTextBox m_txtEmbryoHeart_chr;
		private com.digitalwave.controls.ctlRichTextBox m_txtBloodPressure_chr1;
		private com.digitalwave.controls.ctlRichTextBox m_txtBloodPressure_chr2;
		private com.digitalwave.controls.ctlRichTextBox m_txtPalaceMouth_chr;
		private com.digitalwave.controls.ctlRichTextBox m_txtShow_chr;
		private com.digitalwave.controls.ctlRichTextBox m_txtOther_chr;
		private com.digitalwave.controls.ctlRichTextBox m_txtCaul_chr;
		private com.digitalwave.controls.ctlRichTextBox m_txtAnusCheck_chr;
		private com.digitalwave.controls.ctlRichTextBox m_txtLayCount_chr;
		private com.digitalwave.controls.ctlRichTextBox m_txtBeforehand_chr;
		private com.digitalwave.controls.ctlRichTextBox m_txtIntermission_chr;
		private com.digitalwave.controls.ctlRichTextBox m_txtPersist_chr;
		private com.digitalwave.controls.ctlRichTextBox m_txtIntensity_chr;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		#endregion

		public System.DateTime m_dtmBEFOREHAND_CHR = System.DateTime.Now;
		public string m_strLAYCOUNT_CHR = "";
		private System.Windows.Forms.DateTimePicker dateTimePicker1;//产次
		public string m_strFlag = "0";
        private TextBox txtSign;//是否新增
        /// <summary>
        /// 定义签名类
        /// </summary>
        private clsEmrSignToolCollection m_objSign = null;
        private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();

		public frmWaitLayRecord_AcadCon()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			m_mthSetRichTextBoxAttribInControl(this);
            //m_objSignTool = new clsEmployeeSignTool(m_lsvEmployee);
            //m_objSignTool.m_mthAddControl(new Control[]{m_txtSign},false);
            //m_objCUTC = new clsCommonUseToolCollection(this);
            //m_objCUTC.m_mthBindEmployeeSign(new Control[]{m_cmdSign},new Control[]{m_txtSign},new int[]{1});

            m_objSign = new clsEmrSignToolCollection();
            m_objSign.m_mthBindEmployeeSign(m_cmdSign, txtSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
		}

		public void m_setLaycout()
		{
			if(m_strFlag == "0")
			{
				dateTimePicker1.Value =  System.DateTime.Now;
				dateTimePicker1.Value =  m_dtmBEFOREHAND_CHR;
				this.m_txtLayCount_chr.Text =  m_strLAYCOUNT_CHR;
				this.m_txtBeforehand_chr.Text = m_dtmBEFOREHAND_CHR.ToString();


			}
		}
		public override int m_IntFormID
		{
			get
			{
				return 90;
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
            this.m_txtCaul_chr = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtEmbryoHeart_chr = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtPalaceMouth_chr = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtEmbryoLocation_chr = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtShow_chr = new com.digitalwave.controls.ctlRichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_txtIntensity_chr = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtPersist_chr = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtIntermission_chr = new com.digitalwave.controls.ctlRichTextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txtLayCount_chr = new com.digitalwave.controls.ctlRichTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.m_txtAnusCheck_chr = new com.digitalwave.controls.ctlRichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_txtBloodPressure_chr1 = new com.digitalwave.controls.ctlRichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.m_txtBloodPressure_chr2 = new com.digitalwave.controls.ctlRichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.m_txtOther_chr = new com.digitalwave.controls.ctlRichTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.m_txtBeforehand_chr = new com.digitalwave.controls.ctlRichTextBox();
            this.m_cmdOK = new PinkieControls.ButtonXP();
            this.m_cmdCancel = new PinkieControls.ButtonXP();
            this.m_cmdSign = new PinkieControls.ButtonXP();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtSign = new System.Windows.Forms.TextBox();
            this.m_pnlNewBase.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.lblSex.Size = new System.Drawing.Size(48, 29);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(736, -120);
            this.lblAge.Size = new System.Drawing.Size(52, 29);
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
            this.m_lsvInPatientID.Size = new System.Drawing.Size(116, 114);
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
            this.m_cmdNewTemplate.Size = new System.Drawing.Size(84, 42);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Location = new System.Drawing.Point(196, -120);
            this.m_cmdNext.Size = new System.Drawing.Size(24, 31);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(156, -120);
            this.m_cmdPre.Size = new System.Drawing.Size(24, 31);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(272, -112);
            this.m_lblForTitle.Size = new System.Drawing.Size(16, 33);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(544, -32);
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
            this.groupBox3.Controls.Add(this.m_txtCaul_chr);
            this.groupBox3.Controls.Add(this.m_txtEmbryoHeart_chr);
            this.groupBox3.Controls.Add(this.m_txtPalaceMouth_chr);
            this.groupBox3.Controls.Add(this.m_txtEmbryoLocation_chr);
            this.groupBox3.Controls.Add(this.m_txtShow_chr);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.m_txtLayCount_chr);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.m_txtAnusCheck_chr);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.m_txtBloodPressure_chr1);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.m_txtBloodPressure_chr2);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.m_txtOther_chr);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Location = new System.Drawing.Point(8, 40);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(752, 224);
            this.groupBox3.TabIndex = 10000007;
            this.groupBox3.TabStop = false;
            // 
            // m_txtCaul_chr
            // 
            this.m_txtCaul_chr.AccessibleDescription = "胎膜";
            this.m_txtCaul_chr.BackColor = System.Drawing.Color.White;
            this.m_txtCaul_chr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCaul_chr.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtCaul_chr.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCaul_chr.Location = new System.Drawing.Point(376, 56);
            this.m_txtCaul_chr.m_BlnIgnoreUserInfo = false;
            this.m_txtCaul_chr.m_BlnPartControl = false;
            this.m_txtCaul_chr.m_BlnReadOnly = false;
            this.m_txtCaul_chr.m_BlnUnderLineDST = false;
            this.m_txtCaul_chr.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCaul_chr.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCaul_chr.m_IntCanModifyTime = 6;
            this.m_txtCaul_chr.m_IntPartControlLength = 0;
            this.m_txtCaul_chr.m_IntPartControlStartIndex = 0;
            this.m_txtCaul_chr.m_StrUserID = "";
            this.m_txtCaul_chr.m_StrUserName = "";
            this.m_txtCaul_chr.MaxLength = 8000;
            this.m_txtCaul_chr.Multiline = false;
            this.m_txtCaul_chr.Name = "m_txtCaul_chr";
            this.m_txtCaul_chr.Size = new System.Drawing.Size(56, 22);
            this.m_txtCaul_chr.TabIndex = 1107;
            this.m_txtCaul_chr.Text = "";
            // 
            // m_txtEmbryoHeart_chr
            // 
            this.m_txtEmbryoHeart_chr.AccessibleDescription = "胎心";
            this.m_txtEmbryoHeart_chr.BackColor = System.Drawing.Color.White;
            this.m_txtEmbryoHeart_chr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtEmbryoHeart_chr.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtEmbryoHeart_chr.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtEmbryoHeart_chr.Location = new System.Drawing.Point(376, 24);
            this.m_txtEmbryoHeart_chr.m_BlnIgnoreUserInfo = false;
            this.m_txtEmbryoHeart_chr.m_BlnPartControl = false;
            this.m_txtEmbryoHeart_chr.m_BlnReadOnly = false;
            this.m_txtEmbryoHeart_chr.m_BlnUnderLineDST = false;
            this.m_txtEmbryoHeart_chr.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtEmbryoHeart_chr.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtEmbryoHeart_chr.m_IntCanModifyTime = 6;
            this.m_txtEmbryoHeart_chr.m_IntPartControlLength = 0;
            this.m_txtEmbryoHeart_chr.m_IntPartControlStartIndex = 0;
            this.m_txtEmbryoHeart_chr.m_StrUserID = "";
            this.m_txtEmbryoHeart_chr.m_StrUserName = "";
            this.m_txtEmbryoHeart_chr.MaxLength = 8000;
            this.m_txtEmbryoHeart_chr.Multiline = false;
            this.m_txtEmbryoHeart_chr.Name = "m_txtEmbryoHeart_chr";
            this.m_txtEmbryoHeart_chr.Size = new System.Drawing.Size(56, 22);
            this.m_txtEmbryoHeart_chr.TabIndex = 600;
            this.m_txtEmbryoHeart_chr.Text = "";
            // 
            // m_txtPalaceMouth_chr
            // 
            this.m_txtPalaceMouth_chr.AccessibleDescription = "宫口";
            this.m_txtPalaceMouth_chr.BackColor = System.Drawing.Color.White;
            this.m_txtPalaceMouth_chr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPalaceMouth_chr.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtPalaceMouth_chr.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPalaceMouth_chr.Location = new System.Drawing.Point(96, 56);
            this.m_txtPalaceMouth_chr.m_BlnIgnoreUserInfo = false;
            this.m_txtPalaceMouth_chr.m_BlnPartControl = false;
            this.m_txtPalaceMouth_chr.m_BlnReadOnly = false;
            this.m_txtPalaceMouth_chr.m_BlnUnderLineDST = false;
            this.m_txtPalaceMouth_chr.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPalaceMouth_chr.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPalaceMouth_chr.m_IntCanModifyTime = 6;
            this.m_txtPalaceMouth_chr.m_IntPartControlLength = 0;
            this.m_txtPalaceMouth_chr.m_IntPartControlStartIndex = 0;
            this.m_txtPalaceMouth_chr.m_StrUserID = "";
            this.m_txtPalaceMouth_chr.m_StrUserName = "";
            this.m_txtPalaceMouth_chr.MaxLength = 8000;
            this.m_txtPalaceMouth_chr.Multiline = false;
            this.m_txtPalaceMouth_chr.Name = "m_txtPalaceMouth_chr";
            this.m_txtPalaceMouth_chr.Size = new System.Drawing.Size(56, 22);
            this.m_txtPalaceMouth_chr.TabIndex = 900;
            this.m_txtPalaceMouth_chr.Text = "";
            // 
            // m_txtEmbryoLocation_chr
            // 
            this.m_txtEmbryoLocation_chr.AccessibleDescription = "胎位";
            this.m_txtEmbryoLocation_chr.BackColor = System.Drawing.Color.White;
            this.m_txtEmbryoLocation_chr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtEmbryoLocation_chr.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtEmbryoLocation_chr.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtEmbryoLocation_chr.Location = new System.Drawing.Point(240, 24);
            this.m_txtEmbryoLocation_chr.m_BlnIgnoreUserInfo = false;
            this.m_txtEmbryoLocation_chr.m_BlnPartControl = false;
            this.m_txtEmbryoLocation_chr.m_BlnReadOnly = false;
            this.m_txtEmbryoLocation_chr.m_BlnUnderLineDST = false;
            this.m_txtEmbryoLocation_chr.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtEmbryoLocation_chr.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtEmbryoLocation_chr.m_IntCanModifyTime = 6;
            this.m_txtEmbryoLocation_chr.m_IntPartControlLength = 0;
            this.m_txtEmbryoLocation_chr.m_IntPartControlStartIndex = 0;
            this.m_txtEmbryoLocation_chr.m_StrUserID = "";
            this.m_txtEmbryoLocation_chr.m_StrUserName = "";
            this.m_txtEmbryoLocation_chr.MaxLength = 8000;
            this.m_txtEmbryoLocation_chr.Multiline = false;
            this.m_txtEmbryoLocation_chr.Name = "m_txtEmbryoLocation_chr";
            this.m_txtEmbryoLocation_chr.Size = new System.Drawing.Size(56, 22);
            this.m_txtEmbryoLocation_chr.TabIndex = 500;
            this.m_txtEmbryoLocation_chr.Text = "";
            // 
            // m_txtShow_chr
            // 
            this.m_txtShow_chr.AccessibleDescription = "先露";
            this.m_txtShow_chr.BackColor = System.Drawing.Color.White;
            this.m_txtShow_chr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtShow_chr.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtShow_chr.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtShow_chr.Location = new System.Drawing.Point(240, 56);
            this.m_txtShow_chr.m_BlnIgnoreUserInfo = false;
            this.m_txtShow_chr.m_BlnPartControl = false;
            this.m_txtShow_chr.m_BlnReadOnly = false;
            this.m_txtShow_chr.m_BlnUnderLineDST = false;
            this.m_txtShow_chr.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtShow_chr.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtShow_chr.m_IntCanModifyTime = 6;
            this.m_txtShow_chr.m_IntPartControlLength = 0;
            this.m_txtShow_chr.m_IntPartControlStartIndex = 0;
            this.m_txtShow_chr.m_StrUserID = "";
            this.m_txtShow_chr.m_StrUserName = "";
            this.m_txtShow_chr.MaxLength = 8000;
            this.m_txtShow_chr.Multiline = false;
            this.m_txtShow_chr.Name = "m_txtShow_chr";
            this.m_txtShow_chr.Size = new System.Drawing.Size(56, 22);
            this.m_txtShow_chr.TabIndex = 1000;
            this.m_txtShow_chr.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_txtIntensity_chr);
            this.groupBox1.Controls.Add(this.m_txtPersist_chr);
            this.groupBox1.Controls.Add(this.m_txtIntermission_chr);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Location = new System.Drawing.Point(16, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 120);
            this.groupBox1.TabIndex = 1114;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "宫缩";
            // 
            // m_txtIntensity_chr
            // 
            this.m_txtIntensity_chr.AccessibleDescription = "宫缩>>强度";
            this.m_txtIntensity_chr.BackColor = System.Drawing.Color.White;
            this.m_txtIntensity_chr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtIntensity_chr.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtIntensity_chr.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtIntensity_chr.Location = new System.Drawing.Point(64, 88);
            this.m_txtIntensity_chr.m_BlnIgnoreUserInfo = false;
            this.m_txtIntensity_chr.m_BlnPartControl = false;
            this.m_txtIntensity_chr.m_BlnReadOnly = false;
            this.m_txtIntensity_chr.m_BlnUnderLineDST = false;
            this.m_txtIntensity_chr.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtIntensity_chr.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtIntensity_chr.m_IntCanModifyTime = 6;
            this.m_txtIntensity_chr.m_IntPartControlLength = 0;
            this.m_txtIntensity_chr.m_IntPartControlStartIndex = 0;
            this.m_txtIntensity_chr.m_StrUserID = "";
            this.m_txtIntensity_chr.m_StrUserName = "";
            this.m_txtIntensity_chr.MaxLength = 8000;
            this.m_txtIntensity_chr.Multiline = false;
            this.m_txtIntensity_chr.Name = "m_txtIntensity_chr";
            this.m_txtIntensity_chr.Size = new System.Drawing.Size(112, 22);
            this.m_txtIntensity_chr.TabIndex = 909;
            this.m_txtIntensity_chr.Text = "";
            // 
            // m_txtPersist_chr
            // 
            this.m_txtPersist_chr.AccessibleDescription = "宫缩>>持续";
            this.m_txtPersist_chr.BackColor = System.Drawing.Color.White;
            this.m_txtPersist_chr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPersist_chr.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtPersist_chr.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPersist_chr.Location = new System.Drawing.Point(64, 56);
            this.m_txtPersist_chr.m_BlnIgnoreUserInfo = false;
            this.m_txtPersist_chr.m_BlnPartControl = false;
            this.m_txtPersist_chr.m_BlnReadOnly = false;
            this.m_txtPersist_chr.m_BlnUnderLineDST = false;
            this.m_txtPersist_chr.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPersist_chr.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPersist_chr.m_IntCanModifyTime = 6;
            this.m_txtPersist_chr.m_IntPartControlLength = 0;
            this.m_txtPersist_chr.m_IntPartControlStartIndex = 0;
            this.m_txtPersist_chr.m_StrUserID = "";
            this.m_txtPersist_chr.m_StrUserName = "";
            this.m_txtPersist_chr.MaxLength = 8000;
            this.m_txtPersist_chr.Multiline = false;
            this.m_txtPersist_chr.Name = "m_txtPersist_chr";
            this.m_txtPersist_chr.Size = new System.Drawing.Size(112, 22);
            this.m_txtPersist_chr.TabIndex = 906;
            this.m_txtPersist_chr.Text = "";
            // 
            // m_txtIntermission_chr
            // 
            this.m_txtIntermission_chr.AccessibleDescription = "宫缩>>间歇";
            this.m_txtIntermission_chr.BackColor = System.Drawing.Color.White;
            this.m_txtIntermission_chr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtIntermission_chr.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtIntermission_chr.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtIntermission_chr.Location = new System.Drawing.Point(64, 24);
            this.m_txtIntermission_chr.m_BlnIgnoreUserInfo = false;
            this.m_txtIntermission_chr.m_BlnPartControl = false;
            this.m_txtIntermission_chr.m_BlnReadOnly = false;
            this.m_txtIntermission_chr.m_BlnUnderLineDST = false;
            this.m_txtIntermission_chr.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtIntermission_chr.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtIntermission_chr.m_IntCanModifyTime = 6;
            this.m_txtIntermission_chr.m_IntPartControlLength = 0;
            this.m_txtIntermission_chr.m_IntPartControlStartIndex = 0;
            this.m_txtIntermission_chr.m_StrUserID = "";
            this.m_txtIntermission_chr.m_StrUserName = "";
            this.m_txtIntermission_chr.MaxLength = 8000;
            this.m_txtIntermission_chr.Multiline = false;
            this.m_txtIntermission_chr.Name = "m_txtIntermission_chr";
            this.m_txtIntermission_chr.Size = new System.Drawing.Size(112, 22);
            this.m_txtIntermission_chr.TabIndex = 903;
            this.m_txtIntermission_chr.Text = "";
            this.m_txtIntermission_chr.TextChanged += new System.EventHandler(this.m_txtIntermission_chr_TextChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(24, 88);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(42, 14);
            this.label23.TabIndex = 908;
            this.label23.Text = "强度:";
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(16, 80);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(24, 19);
            this.label24.TabIndex = 907;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(24, 56);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(42, 14);
            this.label21.TabIndex = 905;
            this.label21.Text = "持续:";
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(16, 48);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(24, 19);
            this.label22.TabIndex = 904;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(24, 24);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(42, 14);
            this.label19.TabIndex = 902;
            this.label19.Text = "间歇:";
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(16, 16);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(24, 19);
            this.label20.TabIndex = 901;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 1111;
            this.label4.Text = "孕/产次:";
            // 
            // m_txtLayCount_chr
            // 
            this.m_txtLayCount_chr.AccessibleDescription = "孕/产次";
            this.m_txtLayCount_chr.BackColor = System.Drawing.Color.White;
            this.m_txtLayCount_chr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtLayCount_chr.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtLayCount_chr.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtLayCount_chr.Location = new System.Drawing.Point(96, 24);
            this.m_txtLayCount_chr.m_BlnIgnoreUserInfo = false;
            this.m_txtLayCount_chr.m_BlnPartControl = false;
            this.m_txtLayCount_chr.m_BlnReadOnly = false;
            this.m_txtLayCount_chr.m_BlnUnderLineDST = false;
            this.m_txtLayCount_chr.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtLayCount_chr.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtLayCount_chr.m_IntCanModifyTime = 6;
            this.m_txtLayCount_chr.m_IntPartControlLength = 0;
            this.m_txtLayCount_chr.m_IntPartControlStartIndex = 0;
            this.m_txtLayCount_chr.m_StrUserID = "";
            this.m_txtLayCount_chr.m_StrUserName = "";
            this.m_txtLayCount_chr.MaxLength = 8000;
            this.m_txtLayCount_chr.Multiline = false;
            this.m_txtLayCount_chr.Name = "m_txtLayCount_chr";
            this.m_txtLayCount_chr.Size = new System.Drawing.Size(56, 22);
            this.m_txtLayCount_chr.TabIndex = 1112;
            this.m_txtLayCount_chr.Text = "";
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
            this.label15.Location = new System.Drawing.Point(336, 56);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 14);
            this.label15.TabIndex = 1104;
            this.label15.Text = "胎膜:";
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(336, 48);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(24, 19);
            this.label16.TabIndex = 1105;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(456, 56);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 14);
            this.label17.TabIndex = 1106;
            this.label17.Text = "肛(阴)查 :";
            // 
            // m_txtAnusCheck_chr
            // 
            this.m_txtAnusCheck_chr.AccessibleDescription = "肛(阴)查";
            this.m_txtAnusCheck_chr.BackColor = System.Drawing.Color.White;
            this.m_txtAnusCheck_chr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtAnusCheck_chr.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtAnusCheck_chr.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtAnusCheck_chr.Location = new System.Drawing.Point(536, 56);
            this.m_txtAnusCheck_chr.m_BlnIgnoreUserInfo = false;
            this.m_txtAnusCheck_chr.m_BlnPartControl = false;
            this.m_txtAnusCheck_chr.m_BlnReadOnly = false;
            this.m_txtAnusCheck_chr.m_BlnUnderLineDST = false;
            this.m_txtAnusCheck_chr.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtAnusCheck_chr.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtAnusCheck_chr.m_IntCanModifyTime = 6;
            this.m_txtAnusCheck_chr.m_IntPartControlLength = 0;
            this.m_txtAnusCheck_chr.m_IntPartControlStartIndex = 0;
            this.m_txtAnusCheck_chr.m_StrUserID = "";
            this.m_txtAnusCheck_chr.m_StrUserName = "";
            this.m_txtAnusCheck_chr.MaxLength = 8000;
            this.m_txtAnusCheck_chr.Multiline = false;
            this.m_txtAnusCheck_chr.Name = "m_txtAnusCheck_chr";
            this.m_txtAnusCheck_chr.Size = new System.Drawing.Size(136, 22);
            this.m_txtAnusCheck_chr.TabIndex = 1108;
            this.m_txtAnusCheck_chr.Text = "";
            this.m_txtAnusCheck_chr.TextChanged += new System.EventHandler(this.m_txtAnusCheck_chr_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(304, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 14);
            this.label3.TabIndex = 1103;
            this.label3.Text = "S";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 1102;
            this.label2.Text = "cm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(440, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 1101;
            this.label1.Text = "次/分";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(200, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "胎位:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(328, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 14);
            this.label6.TabIndex = 0;
            this.label6.Text = "胎心:";
            // 
            // m_txtBloodPressure_chr1
            // 
            this.m_txtBloodPressure_chr1.AccessibleDescription = "血压1";
            this.m_txtBloodPressure_chr1.BackColor = System.Drawing.Color.White;
            this.m_txtBloodPressure_chr1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBloodPressure_chr1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBloodPressure_chr1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBloodPressure_chr1.Location = new System.Drawing.Point(536, 24);
            this.m_txtBloodPressure_chr1.m_BlnIgnoreUserInfo = false;
            this.m_txtBloodPressure_chr1.m_BlnPartControl = false;
            this.m_txtBloodPressure_chr1.m_BlnReadOnly = false;
            this.m_txtBloodPressure_chr1.m_BlnUnderLineDST = false;
            this.m_txtBloodPressure_chr1.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBloodPressure_chr1.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBloodPressure_chr1.m_IntCanModifyTime = 6;
            this.m_txtBloodPressure_chr1.m_IntPartControlLength = 0;
            this.m_txtBloodPressure_chr1.m_IntPartControlStartIndex = 0;
            this.m_txtBloodPressure_chr1.m_StrUserID = "";
            this.m_txtBloodPressure_chr1.m_StrUserName = "";
            this.m_txtBloodPressure_chr1.MaxLength = 8000;
            this.m_txtBloodPressure_chr1.Multiline = false;
            this.m_txtBloodPressure_chr1.Name = "m_txtBloodPressure_chr1";
            this.m_txtBloodPressure_chr1.Size = new System.Drawing.Size(56, 22);
            this.m_txtBloodPressure_chr1.TabIndex = 800;
            this.m_txtBloodPressure_chr1.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(496, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 14);
            this.label8.TabIndex = 0;
            this.label8.Text = "血压:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(592, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 24);
            this.label9.TabIndex = 0;
            this.label9.Text = "/";
            // 
            // m_txtBloodPressure_chr2
            // 
            this.m_txtBloodPressure_chr2.AccessibleDescription = "血压2";
            this.m_txtBloodPressure_chr2.BackColor = System.Drawing.Color.White;
            this.m_txtBloodPressure_chr2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBloodPressure_chr2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBloodPressure_chr2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBloodPressure_chr2.Location = new System.Drawing.Point(616, 24);
            this.m_txtBloodPressure_chr2.m_BlnIgnoreUserInfo = false;
            this.m_txtBloodPressure_chr2.m_BlnPartControl = false;
            this.m_txtBloodPressure_chr2.m_BlnReadOnly = false;
            this.m_txtBloodPressure_chr2.m_BlnUnderLineDST = false;
            this.m_txtBloodPressure_chr2.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBloodPressure_chr2.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBloodPressure_chr2.m_IntCanModifyTime = 6;
            this.m_txtBloodPressure_chr2.m_IntPartControlLength = 0;
            this.m_txtBloodPressure_chr2.m_IntPartControlStartIndex = 0;
            this.m_txtBloodPressure_chr2.m_StrUserID = "";
            this.m_txtBloodPressure_chr2.m_StrUserName = "";
            this.m_txtBloodPressure_chr2.MaxLength = 8000;
            this.m_txtBloodPressure_chr2.Multiline = false;
            this.m_txtBloodPressure_chr2.Name = "m_txtBloodPressure_chr2";
            this.m_txtBloodPressure_chr2.Size = new System.Drawing.Size(56, 22);
            this.m_txtBloodPressure_chr2.TabIndex = 850;
            this.m_txtBloodPressure_chr2.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(56, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 14);
            this.label10.TabIndex = 0;
            this.label10.Text = "宫口:";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(48, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 19);
            this.label11.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(192, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 14);
            this.label12.TabIndex = 0;
            this.label12.Text = "先露 :";
            // 
            // m_txtOther_chr
            // 
            this.m_txtOther_chr.AccessibleDescription = "其它";
            this.m_txtOther_chr.BackColor = System.Drawing.Color.White;
            this.m_txtOther_chr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOther_chr.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtOther_chr.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOther_chr.Location = new System.Drawing.Point(264, 104);
            this.m_txtOther_chr.m_BlnIgnoreUserInfo = false;
            this.m_txtOther_chr.m_BlnPartControl = false;
            this.m_txtOther_chr.m_BlnReadOnly = false;
            this.m_txtOther_chr.m_BlnUnderLineDST = false;
            this.m_txtOther_chr.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOther_chr.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOther_chr.m_IntCanModifyTime = 6;
            this.m_txtOther_chr.m_IntPartControlLength = 0;
            this.m_txtOther_chr.m_IntPartControlStartIndex = 0;
            this.m_txtOther_chr.m_StrUserID = "";
            this.m_txtOther_chr.m_StrUserName = "";
            this.m_txtOther_chr.MaxLength = 8000;
            this.m_txtOther_chr.Name = "m_txtOther_chr";
            this.m_txtOther_chr.Size = new System.Drawing.Size(472, 104);
            this.m_txtOther_chr.TabIndex = 1100;
            this.m_txtOther_chr.Text = "";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(264, 88);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 14);
            this.label14.TabIndex = 0;
            this.label14.Text = "其他:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(320, 8);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 14);
            this.label13.TabIndex = 1109;
            this.label13.Text = "预产期:";
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
            this.m_cmdSign.Location = new System.Drawing.Point(24, 272);
            this.m_cmdSign.Name = "m_cmdSign";
            this.m_cmdSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSign.Size = new System.Drawing.Size(64, 32);
            this.m_cmdSign.TabIndex = 10000022;
            this.m_cmdSign.Text = "签名:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(384, 5);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(127, 23);
            this.dateTimePicker1.TabIndex = 10000025;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // txtSign
            // 
            this.txtSign.AccessibleDescription = "签名";
            this.txtSign.Location = new System.Drawing.Point(93, 276);
            this.txtSign.Name = "txtSign";
            this.txtSign.ReadOnly = true;
            this.txtSign.Size = new System.Drawing.Size(104, 23);
            this.txtSign.TabIndex = 10000026;
            // 
            // frmWaitLayRecord_AcadCon
            // 
            this.ClientSize = new System.Drawing.Size(800, 317);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.m_cmdOK);
            this.Controls.Add(this.m_cmdCancel);
            this.Controls.Add(this.m_cmdSign);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.m_txtBeforehand_chr);
            this.Controls.Add(this.txtSign);
            this.Name = "frmWaitLayRecord_AcadCon";
            this.Text = "候产记录";
            this.Load += new System.EventHandler(this.frmICUNurseRecord_GXCon_Load);
            this.Controls.SetChildIndex(this.txtSign, 0);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_txtBeforehand_chr, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.dateTimePicker1, 0);
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
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
			this.m_txtEmbryoLocation_chr.m_mthClearText();
			this.m_txtEmbryoHeart_chr.m_mthClearText();
			this.m_txtBloodPressure_chr1.m_mthClearText();
			this.m_txtBloodPressure_chr2.m_mthClearText();
		//	this.m_txtBeforehand_chr.m_mthClearText();
			this.m_txtPalaceMouth_chr.m_mthClearText();
			this.m_txtShow_chr.m_mthClearText();
			this.m_txtCaul_chr.m_mthClearText();
			this.m_txtAnusCheck_chr.m_mthClearText();
			this.m_txtIntermission_chr.m_mthClearText();
			this.m_txtPersist_chr.m_mthClearText();
			this.m_txtIntensity_chr.m_mthClearText();
			this.m_txtOther_chr.m_mthClearText();
            //this.m_txtSign.m_mthClearText();
            MDIParent.m_mthSetDefaulEmployee(txtSign);
            //m_objSignTool.m_mthSetDefaulEmployee();
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
			clsIcuAcad_WaitLayRecord objContent=(clsIcuAcad_WaitLayRecord )p_objContent;
			//把表单值赋值到界面，由子窗体重载实现			
			this.m_mthClearRecordInfo();


			this.m_txtLayCount_chr.m_mthSetNewText(objContent.m_strLayCount_chr,objContent.m_strLayCount_chrXML);
			this.m_txtEmbryoLocation_chr.m_mthSetNewText(objContent.m_strEmbryoLocation_chr,objContent.m_strEmbryoLocation_chrXML);
			this.m_txtEmbryoHeart_chr.m_mthSetNewText(objContent.m_strEmbryoHeart_chr,objContent.m_strEmbryoHeart_chrXML);
			this.m_txtBloodPressure_chr1.m_mthSetNewText(objContent.m_strBloodPressure_chr,objContent.m_strBloodPressure_chrXML);
			this.m_txtBloodPressure_chr2.m_mthSetNewText(objContent.m_strBloodPressure2_chr,objContent.m_strBloodPressure2_chrXML);
            this.dateTimePicker1.Value = Convert.ToDateTime(objContent.m_strBeforehand_chr);
			this.m_txtPalaceMouth_chr.m_mthSetNewText(objContent.m_strPalaceMouth_chr,objContent.m_strPalaceMouth_chrXML);
			this.m_txtShow_chr.m_mthSetNewText(objContent.m_strShow_chr,objContent.m_strShow_chrXML);
			this.m_txtCaul_chr.m_mthSetNewText(objContent.m_strCaul_chr,objContent.m_strCaul_chrXML);
			this.m_txtAnusCheck_chr.m_mthSetNewText(objContent.m_strAnusCheck_chr,objContent.m_strAnusCheck_chrXML);
			this.m_txtIntermission_chr.m_mthSetNewText(objContent.m_strIntermission_chr,objContent.m_strIntermission_chrXML);
			this.m_txtPersist_chr.m_mthSetNewText(objContent.m_strPersist_chr,objContent.m_strPersist_chrXML);
			this.m_txtIntensity_chr.m_mthSetNewText(objContent.m_strIntensity_chr,objContent.m_strIntensity_chrXML);
			this.m_txtOther_chr.m_mthSetNewText(objContent.m_strOther_chr,objContent.m_strOther_chrXML);
			
			clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
            objEmployeeSign.m_lngGetEmpByID(objContent.m_strScrutator_chr, out objEmpVO);
            if (objEmpVO != null)
            {
                txtSign.Text = objEmpVO.m_strLASTNAME_VCHR;
                txtSign.Tag = objEmpVO;
            }
            //if(objContent.m_strScrutator_chr !=null &&objContent.m_strScrutator_chr != "")
            //    m_txtSign.Text=objContent.m_strScrutator_chr;
			this.txtSign.Enabled = false;
            this.m_dtpCreateDate.Value = objContent.m_dtmRecordDate;
		}

		protected override void m_mthSetDeletedGUIFromContent(iCareData.clsTrackRecordContent p_objContent)
		{
			clsIcuAcad_WaitLayRecord objContent=(clsIcuAcad_WaitLayRecord )p_objContent;
			//把表单值赋值到界面，由子窗体重载实现			

			this.m_mthClearRecordInfo();
		

			this.m_txtLayCount_chr.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strLayCount_chr,objContent.m_strLayCount_chrXML);
			this.m_txtEmbryoLocation_chr.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strEmbryoLocation_chr,objContent.m_strEmbryoLocation_chrXML);
			this.m_txtEmbryoHeart_chr.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strEmbryoHeart_chr,objContent.m_strEmbryoHeart_chrXML);
			
			this.m_txtBloodPressure_chr1.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strBloodPressure_chr,objContent.m_strBloodPressure_chrXML);
			
			this.m_txtBloodPressure_chr2.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strBloodPressure2_chr,objContent.m_strBloodPressure2_chrXML);
			
			this.dateTimePicker1.Value=Convert.ToDateTime(objContent.m_strBeforehand_chr);
			this.m_txtPalaceMouth_chr.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strPalaceMouth_chr,objContent.m_strPalaceMouth_chrXML);
			this.m_txtShow_chr.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strShow_chr,objContent.m_strShow_chrXML);
			this.m_txtCaul_chr.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strCaul_chr,objContent.m_strCaul_chrXML);
			this.m_txtAnusCheck_chr.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strAnusCheck_chr,objContent.m_strAnusCheck_chrXML);
			this.m_txtIntermission_chr.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strIntermission_chr,objContent.m_strIntermission_chrXML);
			this.m_txtPersist_chr.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strPersist_chr,objContent.m_strPersist_chrXML);
			this.m_txtIntensity_chr.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strIntensity_chr,objContent.m_strIntensity_chrXML);
			this.m_txtOther_chr.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strOther_chr,objContent.m_strOther_chrXML);
            this.m_dtpCreateDate.Value = objContent.m_dtmRecordDate;
            clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
            objEmployeeSign.m_lngGetEmpByID(objContent.m_strCreateUserID, out objEmpVO);
            if (objEmpVO != null)
            {
                txtSign.Text = objEmpVO.m_strLASTNAME_VCHR;
                txtSign.Tag = objEmpVO;
            }
            //if(objContent.m_strScrutator_chr !=null &&objContent.m_strScrutator_chr != "")
            //    m_txtSign.Text=objContent.m_strScrutator_chr;
			this.txtSign.Enabled = false;
			this.m_dtpCreateDate.Enabled = false;


		
		}

		protected override iCareData.clsTrackRecordContent m_objGetContentFromGUI()
		{
			
			//界面参数校验
			if(m_objCurrentPatient==null)// || this.txtInPatientID.Text!=this.m_objCurrentPatient.m_StrHISInPatientID || txtInPatientID.Text=="")				
				return null;

			//从界面获取表单值		
			clsIcuAcad_WaitLayRecord objContent=new clsIcuAcad_WaitLayRecord ();
			try
			{
				
//				objContent.m_strINAMOUNTITEM_RIGHT=this.m_txtItem.m_strGetRightText();
				objContent.m_strLayCount_chr=this.m_txtLayCount_chr.Text;
				objContent.m_strLayCount_chr_RIGHT=this.m_txtLayCount_chr.m_strGetRightText();
				objContent.m_strLayCount_chrXML=this.m_txtLayCount_chr.m_strGetXmlText();

				objContent.m_strEmbryoLocation_chr_RIGHT=this.m_txtEmbryoLocation_chr.m_strGetRightText();
				objContent.m_strEmbryoLocation_chr=this.m_txtEmbryoLocation_chr.Text;
				objContent.m_strEmbryoLocation_chrXML=this.m_txtEmbryoLocation_chr.m_strGetXmlText();

				objContent.m_strEmbryoHeart_chr_RIGHT=this.m_txtEmbryoHeart_chr.m_strGetRightText();
				objContent.m_strEmbryoHeart_chr=this.m_txtEmbryoHeart_chr.Text;
				objContent.m_strEmbryoHeart_chrXML=this.m_txtEmbryoHeart_chr.m_strGetXmlText();

                
                objContent.m_strBeforehand_chr = this.dateTimePicker1.Value.ToString("yyyy年MM月dd日");
                

				objContent.m_strPalaceMouth_chr_RIGHT=this.m_txtPalaceMouth_chr.m_strGetRightText();
				objContent.m_strPalaceMouth_chr=this.m_txtPalaceMouth_chr.Text;
				objContent.m_strPalaceMouth_chrXML=this.m_txtPalaceMouth_chr.m_strGetXmlText();

				objContent.m_strShow_chr_RIGHT=this.m_txtShow_chr.m_strGetRightText();
				objContent.m_strShow_chr=this.m_txtShow_chr.Text;
				objContent.m_strShow_chrXML=this.m_txtShow_chr.m_strGetXmlText();

				objContent.m_strCaul_chr_RIGHT=this.m_txtCaul_chr.m_strGetRightText();
				objContent.m_strCaul_chr=this.m_txtCaul_chr.Text;
				objContent.m_strCaul_chrXML=this.m_txtCaul_chr.m_strGetXmlText();
            			
				objContent.m_strAnusCheck_chr_RIGHT=this.m_txtAnusCheck_chr.m_strGetRightText();
				objContent.m_strAnusCheck_chr=this.m_txtAnusCheck_chr.Text;
				objContent.m_strAnusCheck_chrXML=this.m_txtAnusCheck_chr.m_strGetXmlText();

				objContent.m_strIntermission_chr_RIGHT=this.m_txtIntermission_chr.m_strGetRightText();
				objContent.m_strIntermission_chr=this.m_txtIntermission_chr.Text ;
				objContent.m_strIntermission_chrXML=this.m_txtIntermission_chr.m_strGetXmlText();

				objContent.m_strPersist_chr_RIGHT=this.m_txtPersist_chr.m_strGetRightText();
				objContent.m_strPersist_chr=this.m_txtPersist_chr.Text;
				objContent.m_strPersist_chrXML=this.m_txtPersist_chr.m_strGetXmlText();

				objContent.m_strIntensity_RIGHT=this.m_txtIntensity_chr.m_strGetRightText();
				objContent.m_strIntensity_chr=this.m_txtIntensity_chr.Text;
				objContent.m_strIntensity_chrXML=this.m_txtIntensity_chr.m_strGetXmlText();

				objContent.m_strOther_chr_RIGHT=this.m_txtOther_chr.m_strGetRightText();
				objContent.m_strOther_chr=this.m_txtOther_chr.Text;
				objContent.m_strOther_chrXML=this.m_txtOther_chr.m_strGetXmlText();

				objContent.m_strBloodPressure_chr_RIGHT=this.m_txtBloodPressure_chr1.m_strGetRightText();
				objContent.m_strBloodPressure_chr=this.m_txtBloodPressure_chr1.Text;
				objContent.m_strBloodPressure_chrXML=this.m_txtBloodPressure_chr1.m_strGetXmlText();

				objContent.m_strBloodPressure2_chr_RIGHT=this.m_txtBloodPressure_chr2.m_strGetRightText();
				objContent.m_strBloodPressure2_chr=this.m_txtBloodPressure_chr2.Text;
				objContent.m_strBloodPressure2_chrXML=this.m_txtBloodPressure_chr2.m_strGetXmlText();

                if (txtSign.Tag != null && txtSign.Text.Trim() != "")
                {
                    objContent.m_strScrutatorID = ((clsEmrEmployeeBase_VO)txtSign.Tag).m_strEMPNO_CHR;

                    clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
                    objEmployeeSign.m_lngGetEmpByNO(objContent.m_strScrutatorID, out objEmpVO);
                    // m_txtDoctorSign.Text = objEmpVO.ToString();
                   // objContent.m_strCompereName = objEmpVO.ToString();

                    // objContent.m_strCompereName=m_txtCompere.Text;

                    objContent.m_strScrutator_chr_RIGHT = objEmpVO.m_strLASTNAME_VCHR;
                    objContent.m_strScrutator_chr = ((clsEmrEmployeeBase_VO)txtSign.Tag).m_strEMPID_CHR;
                }

               
                //objContent.m_strScrutator_chrXML = m_txtSign.m_strGetXmlText();
                objContent.m_strCreateUserID = ((clsEmrEmployeeBase_VO)txtSign.Tag).m_strEMPID_CHR;
				objContent.m_dtmModifyDate = DateTime.Now;
				objContent.m_strModifyUserID = clsEMRLogin.LoginEmployee.m_strEMPID_CHR;
                objContent.m_dtmRecordDate = m_dtpCreateDate.Value;
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
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.WaitLayRecord_Acad);	
			//(需要改动)				
		}

		/// <summary>
		/// 把选择时间记录内容重新整理为完全正确的内容。
		/// </summary>
		/// <param name="p_objRecordContent"></param>
		protected override void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
		{
			//把选择时间记录内容重新整理为完全正确的内容，由子窗体重载实现。
			clsIcuAcad_WaitLayRecord objContent=(clsIcuAcad_WaitLayRecord)p_objRecordContent; //(需要改动)
		}

		public override string m_strReloadFormTitle()
		{
			//由子窗体重载实现
	//(需要改动)	
			return	"候产记录";
		}

		
		#region Jump Control
		protected override void m_mthInitJump(clsJumpControl p_objJump)
		{	//(需要改动)	
			p_objJump=new clsJumpControl(this,
				new Control[]{m_txtLayCount_chr,m_txtEmbryoLocation_chr,m_txtEmbryoHeart_chr,m_txtBloodPressure_chr1,m_txtBloodPressure_chr2,m_txtBeforehand_chr,
								 m_txtPalaceMouth_chr,m_txtShow_chr,m_txtCaul_chr,m_txtAnusCheck_chr,m_txtIntermission_chr,m_txtPersist_chr,m_txtIntensity_chr,m_txtOther_chr,txtSign,m_cmdOK},Keys.Enter);
		}
		#endregion

		private void frmICUNurseRecord_GXCon_Load(object sender, System.EventArgs e)
		{
			m_txtLayCount_chr.Focus();
		}

		private void m_cmdOK_Click(object sender, System.EventArgs e)
		{
            if (txtSign.Tag == null)
            {
                clsPublicFunction.ShowInformationMessageBox("请医师签名");
                return;
            }
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
            //if(m_lsvEmployee.Items.Count!=0)
            //    if(m_lsvEmployee.SelectedItems.Count>0)
            //m_txtSign.Text = 	m_lsvEmployee.SelectedItems[0].Text;
			
		}

		private void dateTimePicker1_ValueChanged(object sender, System.EventArgs e)
		{
			m_txtBeforehand_chr.Text = this.dateTimePicker1.Value.ToString();
		}

		private void m_txtBeforehand_chr_TextChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}

