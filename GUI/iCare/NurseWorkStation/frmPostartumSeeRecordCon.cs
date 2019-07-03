using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using iCareData;
using com.digitalwave.controls;
using System.Data; 
using System.Xml;
using com.digitalwave.Emr.Signature_gui;

namespace iCare
{
	/// <summary>
	/// 中期妊娠引产后观察记录 的摘要说明。
	/// </summary>
	public class frmPostartumSeeRecordCon:  frmDiseaseTrackBase
	{
		#region define

        private PinkieControls.ButtonXP m_cmdOK;
        private PinkieControls.ButtonXP m_cmdCancel;
        //private clsEmployeeSignTool m_objSignTool;
        //private clsCommonUseToolCollection m_objCUTC;
		public System.DateTime m_dtmBEFOREHAND_CHR = System.DateTime.Now;
		public string m_strLAYCOUNT_CHR = "";
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private com.digitalwave.controls.ctlRichTextBox m_txtBlooded_chr;
		private com.digitalwave.controls.ctlRichTextBox m_txtBodyTemperature_chr;
		private com.digitalwave.controls.ctlRichTextBox m_txtPulse_chr;
		private com.digitalwave.controls.ctlRichTextBox m_txtEmbryo_chr;
		private com.digitalwave.controls.ctlRichTextBox m_txtBreakWater_chr;
		private com.digitalwave.controls.ctlRichTextBox m_txtUterusSize_chr;
		private com.digitalwave.controls.ctlRichTextBox m_txtUterus_chr;
		private com.digitalwave.controls.ctlRichTextBox m_txtBloodPressure_chr;//产次
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;


		#endregion
		private PinkieControls.ButtonXP m_cmdSign;

        public string m_strFlag = "0";
        protected ListView lsvSign;
        private ColumnHeader clmEmployeeName;//是否新增
        clsEmrSignToolCollection m_objSign;
		public frmPostartumSeeRecordCon()
		{
			InitializeComponent();
            if (com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalNO == "450101001")
                this.Text = "中期妊娠引产产程观察记录";

			m_mthSetRichTextBoxAttribInControl(this);
            m_objSign = new clsEmrSignToolCollection();
            //可以指定员工ID如
            m_objSign.m_mthBindEmployeeSign(m_cmdSign, lsvSign, 2, true, clsEMRLogin.LoginInfo.m_strEmpID);
		}
		public void m_setLaycout()
		{
			if(m_strFlag == "0")
			{
				//dateTimePicker1.Value =  System.DateTime.Now;
//				dateTimePicker1.Value =  m_dtmBEFOREHAND_CHR;
//				this.m_txtLayCount_chr.Text =  m_strLAYCOUNT_CHR;
//				this.m_txtBeforehand_chr.Text = m_dtmBEFOREHAND_CHR.ToString();


			}
		}
		public override int m_IntFormID
		{
			get
			{
				return 97;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPostartumSeeRecordCon));
            this.m_cmdOK = new PinkieControls.ButtonXP();
            this.m_cmdCancel = new PinkieControls.ButtonXP();
            this.m_cmdSign = new PinkieControls.ButtonXP();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txtBlooded_chr = new com.digitalwave.controls.ctlRichTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.m_txtEmbryo_chr = new com.digitalwave.controls.ctlRichTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.m_txtBreakWater_chr = new com.digitalwave.controls.ctlRichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtBodyTemperature_chr = new com.digitalwave.controls.ctlRichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_txtPulse_chr = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtBloodPressure_chr = new com.digitalwave.controls.ctlRichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.m_txtUterusSize_chr = new com.digitalwave.controls.ctlRichTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.m_txtUterus_chr = new com.digitalwave.controls.ctlRichTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lsvSign = new System.Windows.Forms.ListView();
            this.clmEmployeeName = new System.Windows.Forms.ColumnHeader();
            this.m_pnlNewBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_trvCreateDate
            // 
            this.m_trvCreateDate.LineColor = System.Drawing.Color.Black;
            this.m_trvCreateDate.Location = new System.Drawing.Point(340, -20);
            this.m_trvCreateDate.Size = new System.Drawing.Size(26, 10);
            this.m_trvCreateDate.Visible = false;
            // 
            // lblCreateDateTitle
            // 
            this.lblCreateDateTitle.Location = new System.Drawing.Point(31, 16);
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.Location = new System.Drawing.Point(107, 12);
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
            this.lblSex.Size = new System.Drawing.Size(48, 35);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(36, -120);
            this.lblAge.Size = new System.Drawing.Size(52, 35);
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
            this.m_lsvInPatientID.Size = new System.Drawing.Size(116, 120);
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
            this.m_cmdNewTemplate.Size = new System.Drawing.Size(84, 48);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Location = new System.Drawing.Point(196, -120);
            this.m_cmdNext.Size = new System.Drawing.Size(24, 37);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(156, -120);
            this.m_cmdPre.Size = new System.Drawing.Size(24, 37);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(272, -112);
            this.m_lblForTitle.Size = new System.Drawing.Size(16, 39);
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(3, 136);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(350, -32);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            // 
            // m_cmdOK
            // 
            this.m_cmdOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdOK.DefaultScheme = true;
            this.m_cmdOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdOK.Hint = "";
            this.m_cmdOK.Location = new System.Drawing.Point(544, 129);
            this.m_cmdOK.Name = "m_cmdOK";
            this.m_cmdOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdOK.Size = new System.Drawing.Size(88, 32);
            this.m_cmdOK.TabIndex = 10000070;
            this.m_cmdOK.Text = "保存";
            this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
            // 
            // m_cmdCancel
            // 
            this.m_cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdCancel.DefaultScheme = true;
            this.m_cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdCancel.Hint = "";
            this.m_cmdCancel.Location = new System.Drawing.Point(640, 129);
            this.m_cmdCancel.Name = "m_cmdCancel";
            this.m_cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCancel.Size = new System.Drawing.Size(88, 32);
            this.m_cmdCancel.TabIndex = 10000071;
            this.m_cmdCancel.Text = "关闭";
            this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
            // 
            // m_cmdSign
            // 
            this.m_cmdSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdSign.DefaultScheme = true;
            this.m_cmdSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSign.Hint = "";
            this.m_cmdSign.Location = new System.Drawing.Point(107, 129);
            this.m_cmdSign.Name = "m_cmdSign";
            this.m_cmdSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSign.Size = new System.Drawing.Size(64, 32);
            this.m_cmdSign.TabIndex = 10000068;
            this.m_cmdSign.Text = "签名:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(185, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 14);
            this.label7.TabIndex = 10000048;
            this.label7.Text = "ml";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 14);
            this.label4.TabIndex = 10000046;
            this.label4.Text = "出血:";
            // 
            // m_txtBlooded_chr
            // 
            this.m_txtBlooded_chr.AccessibleDescription = "出血";
            this.m_txtBlooded_chr.BackColor = System.Drawing.Color.White;
            this.m_txtBlooded_chr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBlooded_chr.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBlooded_chr.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBlooded_chr.Location = new System.Drawing.Point(107, 47);
            this.m_txtBlooded_chr.m_BlnIgnoreUserInfo = false;
            this.m_txtBlooded_chr.m_BlnPartControl = false;
            this.m_txtBlooded_chr.m_BlnReadOnly = false;
            this.m_txtBlooded_chr.m_BlnUnderLineDST = false;
            this.m_txtBlooded_chr.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBlooded_chr.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBlooded_chr.m_IntCanModifyTime = 6;
            this.m_txtBlooded_chr.m_IntPartControlLength = 0;
            this.m_txtBlooded_chr.m_IntPartControlStartIndex = 0;
            this.m_txtBlooded_chr.m_StrUserID = "";
            this.m_txtBlooded_chr.m_StrUserName = "";
            this.m_txtBlooded_chr.MaxLength = 5;
            this.m_txtBlooded_chr.Multiline = false;
            this.m_txtBlooded_chr.Name = "m_txtBlooded_chr";
            this.m_txtBlooded_chr.Size = new System.Drawing.Size(72, 22);
            this.m_txtBlooded_chr.TabIndex = 10000060;
            this.m_txtBlooded_chr.Text = "";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(377, 85);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 14);
            this.label15.TabIndex = 10000041;
            this.label15.Text = "胎心:";
            // 
            // m_txtEmbryo_chr
            // 
            this.m_txtEmbryo_chr.AccessibleDescription = "胎心";
            this.m_txtEmbryo_chr.BackColor = System.Drawing.Color.White;
            this.m_txtEmbryo_chr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtEmbryo_chr.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtEmbryo_chr.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtEmbryo_chr.Location = new System.Drawing.Point(423, 82);
            this.m_txtEmbryo_chr.m_BlnIgnoreUserInfo = false;
            this.m_txtEmbryo_chr.m_BlnPartControl = false;
            this.m_txtEmbryo_chr.m_BlnReadOnly = false;
            this.m_txtEmbryo_chr.m_BlnUnderLineDST = false;
            this.m_txtEmbryo_chr.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtEmbryo_chr.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtEmbryo_chr.m_IntCanModifyTime = 6;
            this.m_txtEmbryo_chr.m_IntPartControlLength = 0;
            this.m_txtEmbryo_chr.m_IntPartControlStartIndex = 0;
            this.m_txtEmbryo_chr.m_StrUserID = "";
            this.m_txtEmbryo_chr.m_StrUserName = "";
            this.m_txtEmbryo_chr.MaxLength = 3;
            this.m_txtEmbryo_chr.Multiline = false;
            this.m_txtEmbryo_chr.Name = "m_txtEmbryo_chr";
            this.m_txtEmbryo_chr.Size = new System.Drawing.Size(56, 22);
            this.m_txtEmbryo_chr.TabIndex = 10000066;
            this.m_txtEmbryo_chr.Text = "";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(541, 85);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(42, 14);
            this.label17.TabIndex = 10000043;
            this.label17.Text = "破水:";
            // 
            // m_txtBreakWater_chr
            // 
            this.m_txtBreakWater_chr.AccessibleDescription = "破水";
            this.m_txtBreakWater_chr.BackColor = System.Drawing.Color.White;
            this.m_txtBreakWater_chr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBreakWater_chr.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBreakWater_chr.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBreakWater_chr.Location = new System.Drawing.Point(592, 82);
            this.m_txtBreakWater_chr.m_BlnIgnoreUserInfo = false;
            this.m_txtBreakWater_chr.m_BlnPartControl = false;
            this.m_txtBreakWater_chr.m_BlnReadOnly = false;
            this.m_txtBreakWater_chr.m_BlnUnderLineDST = false;
            this.m_txtBreakWater_chr.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBreakWater_chr.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBreakWater_chr.m_IntCanModifyTime = 6;
            this.m_txtBreakWater_chr.m_IntPartControlLength = 0;
            this.m_txtBreakWater_chr.m_IntPartControlStartIndex = 0;
            this.m_txtBreakWater_chr.m_StrUserID = "";
            this.m_txtBreakWater_chr.m_StrUserName = "";
            this.m_txtBreakWater_chr.MaxLength = 200;
            this.m_txtBreakWater_chr.Multiline = false;
            this.m_txtBreakWater_chr.Name = "m_txtBreakWater_chr";
            this.m_txtBreakWater_chr.Size = new System.Drawing.Size(136, 22);
            this.m_txtBreakWater_chr.TabIndex = 10000067;
            this.m_txtBreakWater_chr.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(337, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 14);
            this.label3.TabIndex = 10000040;
            this.label3.Text = "℃";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 10000039;
            this.label2.Text = "cm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(485, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 10000038;
            this.label1.Text = "次/分";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(227, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 14);
            this.label5.TabIndex = 10000027;
            this.label5.Text = "体温:";
            // 
            // m_txtBodyTemperature_chr
            // 
            this.m_txtBodyTemperature_chr.AccessibleDescription = "体温";
            this.m_txtBodyTemperature_chr.BackColor = System.Drawing.Color.White;
            this.m_txtBodyTemperature_chr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBodyTemperature_chr.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBodyTemperature_chr.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBodyTemperature_chr.Location = new System.Drawing.Point(275, 47);
            this.m_txtBodyTemperature_chr.m_BlnIgnoreUserInfo = false;
            this.m_txtBodyTemperature_chr.m_BlnPartControl = false;
            this.m_txtBodyTemperature_chr.m_BlnReadOnly = false;
            this.m_txtBodyTemperature_chr.m_BlnUnderLineDST = false;
            this.m_txtBodyTemperature_chr.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBodyTemperature_chr.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBodyTemperature_chr.m_IntCanModifyTime = 6;
            this.m_txtBodyTemperature_chr.m_IntPartControlLength = 0;
            this.m_txtBodyTemperature_chr.m_IntPartControlStartIndex = 0;
            this.m_txtBodyTemperature_chr.m_StrUserID = "";
            this.m_txtBodyTemperature_chr.m_StrUserName = "";
            this.m_txtBodyTemperature_chr.MaxLength = 6;
            this.m_txtBodyTemperature_chr.Multiline = false;
            this.m_txtBodyTemperature_chr.Name = "m_txtBodyTemperature_chr";
            this.m_txtBodyTemperature_chr.Size = new System.Drawing.Size(56, 22);
            this.m_txtBodyTemperature_chr.TabIndex = 10000061;
            this.m_txtBodyTemperature_chr.Text = "";
            this.m_txtBodyTemperature_chr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtBodyTemperature_chr_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(377, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 14);
            this.label6.TabIndex = 10000026;
            this.label6.Text = "脉搏:";
            // 
            // m_txtPulse_chr
            // 
            this.m_txtPulse_chr.AccessibleDescription = "脉搏";
            this.m_txtPulse_chr.BackColor = System.Drawing.Color.White;
            this.m_txtPulse_chr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPulse_chr.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtPulse_chr.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPulse_chr.Location = new System.Drawing.Point(423, 47);
            this.m_txtPulse_chr.m_BlnIgnoreUserInfo = false;
            this.m_txtPulse_chr.m_BlnPartControl = false;
            this.m_txtPulse_chr.m_BlnReadOnly = false;
            this.m_txtPulse_chr.m_BlnUnderLineDST = false;
            this.m_txtPulse_chr.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPulse_chr.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPulse_chr.m_IntCanModifyTime = 6;
            this.m_txtPulse_chr.m_IntPartControlLength = 0;
            this.m_txtPulse_chr.m_IntPartControlStartIndex = 0;
            this.m_txtPulse_chr.m_StrUserID = "";
            this.m_txtPulse_chr.m_StrUserName = "";
            this.m_txtPulse_chr.MaxLength = 3;
            this.m_txtPulse_chr.Multiline = false;
            this.m_txtPulse_chr.Name = "m_txtPulse_chr";
            this.m_txtPulse_chr.Size = new System.Drawing.Size(56, 22);
            this.m_txtPulse_chr.TabIndex = 10000062;
            this.m_txtPulse_chr.Text = "";
            // 
            // m_txtBloodPressure_chr
            // 
            this.m_txtBloodPressure_chr.AccessibleDescription = "血压";
            this.m_txtBloodPressure_chr.BackColor = System.Drawing.Color.White;
            this.m_txtBloodPressure_chr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBloodPressure_chr.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBloodPressure_chr.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBloodPressure_chr.Location = new System.Drawing.Point(592, 47);
            this.m_txtBloodPressure_chr.m_BlnIgnoreUserInfo = false;
            this.m_txtBloodPressure_chr.m_BlnPartControl = false;
            this.m_txtBloodPressure_chr.m_BlnReadOnly = false;
            this.m_txtBloodPressure_chr.m_BlnUnderLineDST = false;
            this.m_txtBloodPressure_chr.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBloodPressure_chr.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBloodPressure_chr.m_IntCanModifyTime = 6;
            this.m_txtBloodPressure_chr.m_IntPartControlLength = 0;
            this.m_txtBloodPressure_chr.m_IntPartControlStartIndex = 0;
            this.m_txtBloodPressure_chr.m_StrUserID = "";
            this.m_txtBloodPressure_chr.m_StrUserName = "";
            this.m_txtBloodPressure_chr.MaxLength = 200;
            this.m_txtBloodPressure_chr.Multiline = false;
            this.m_txtBloodPressure_chr.Name = "m_txtBloodPressure_chr";
            this.m_txtBloodPressure_chr.Size = new System.Drawing.Size(136, 22);
            this.m_txtBloodPressure_chr.TabIndex = 10000063;
            this.m_txtBloodPressure_chr.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(541, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 14);
            this.label8.TabIndex = 10000025;
            this.label8.Text = "血压:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(31, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 14);
            this.label10.TabIndex = 10000031;
            this.label10.Text = "宫口大小:";
            // 
            // m_txtUterusSize_chr
            // 
            this.m_txtUterusSize_chr.AccessibleDescription = "宫口大小";
            this.m_txtUterusSize_chr.BackColor = System.Drawing.Color.White;
            this.m_txtUterusSize_chr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtUterusSize_chr.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtUterusSize_chr.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtUterusSize_chr.Location = new System.Drawing.Point(107, 82);
            this.m_txtUterusSize_chr.m_BlnIgnoreUserInfo = false;
            this.m_txtUterusSize_chr.m_BlnPartControl = false;
            this.m_txtUterusSize_chr.m_BlnReadOnly = false;
            this.m_txtUterusSize_chr.m_BlnUnderLineDST = false;
            this.m_txtUterusSize_chr.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtUterusSize_chr.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtUterusSize_chr.m_IntCanModifyTime = 6;
            this.m_txtUterusSize_chr.m_IntPartControlLength = 0;
            this.m_txtUterusSize_chr.m_IntPartControlStartIndex = 0;
            this.m_txtUterusSize_chr.m_StrUserID = "";
            this.m_txtUterusSize_chr.m_StrUserName = "";
            this.m_txtUterusSize_chr.MaxLength = 3;
            this.m_txtUterusSize_chr.Multiline = false;
            this.m_txtUterusSize_chr.Name = "m_txtUterusSize_chr";
            this.m_txtUterusSize_chr.Size = new System.Drawing.Size(72, 22);
            this.m_txtUterusSize_chr.TabIndex = 10000064;
            this.m_txtUterusSize_chr.Text = "";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(227, 85);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 14);
            this.label12.TabIndex = 10000029;
            this.label12.Text = "宫缩:";
            // 
            // m_txtUterus_chr
            // 
            this.m_txtUterus_chr.AccessibleDescription = "宫缩";
            this.m_txtUterus_chr.BackColor = System.Drawing.Color.White;
            this.m_txtUterus_chr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtUterus_chr.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtUterus_chr.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtUterus_chr.Location = new System.Drawing.Point(275, 82);
            this.m_txtUterus_chr.m_BlnIgnoreUserInfo = false;
            this.m_txtUterus_chr.m_BlnPartControl = false;
            this.m_txtUterus_chr.m_BlnReadOnly = false;
            this.m_txtUterus_chr.m_BlnUnderLineDST = false;
            this.m_txtUterus_chr.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtUterus_chr.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtUterus_chr.m_IntCanModifyTime = 6;
            this.m_txtUterus_chr.m_IntPartControlLength = 0;
            this.m_txtUterus_chr.m_IntPartControlStartIndex = 0;
            this.m_txtUterus_chr.m_StrUserID = "";
            this.m_txtUterus_chr.m_StrUserName = "";
            this.m_txtUterus_chr.MaxLength = 200;
            this.m_txtUterus_chr.Multiline = false;
            this.m_txtUterus_chr.Name = "m_txtUterus_chr";
            this.m_txtUterus_chr.Size = new System.Drawing.Size(56, 22);
            this.m_txtUterus_chr.TabIndex = 10000065;
            this.m_txtUterus_chr.Text = "";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(485, 85);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 14);
            this.label13.TabIndex = 10000049;
            this.label13.Text = "次/分";
            // 
            // lsvSign
            // 
            this.lsvSign.BackColor = System.Drawing.Color.White;
            this.lsvSign.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmEmployeeName});
            this.lsvSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvSign.ForeColor = System.Drawing.Color.Black;
            this.lsvSign.FullRowSelect = true;
            this.lsvSign.GridLines = true;
            this.lsvSign.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvSign.Location = new System.Drawing.Point(173, 132);
            this.lsvSign.Name = "lsvSign";
            this.lsvSign.Size = new System.Drawing.Size(361, 28);
            this.lsvSign.TabIndex = 10000072;
            this.lsvSign.UseCompatibleStateImageBehavior = false;
            this.lsvSign.View = System.Windows.Forms.View.SmallIcon;
            // 
            // clmEmployeeName
            // 
            this.clmEmployeeName.Width = 55;
            // 
            // frmPostartumSeeRecordCon
            // 
            this.ClientSize = new System.Drawing.Size(743, 188);
            this.Controls.Add(this.lsvSign);
            this.Controls.Add(this.m_txtPulse_chr);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_txtBlooded_chr);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.m_txtEmbryo_chr);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.m_txtBreakWater_chr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.m_txtBodyTemperature_chr);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.m_txtBloodPressure_chr);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.m_txtUterusSize_chr);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.m_txtUterus_chr);
            this.Controls.Add(this.m_cmdOK);
            this.Controls.Add(this.m_cmdCancel);
            this.Controls.Add(this.m_cmdSign);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPostartumSeeRecordCon";
            this.Text = "中期妊娠引产后观察记录";
            this.Load += new System.EventHandler(this.frmICUNurseRecord_GXCon_Load);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_cmdSign, 0);
            this.Controls.SetChildIndex(this.m_cmdCancel, 0);
            this.Controls.SetChildIndex(this.m_cmdOK, 0);
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
            this.Controls.SetChildIndex(this.m_txtUterus_chr, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.m_txtUterusSize_chr, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.m_txtBloodPressure_chr, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.m_txtBodyTemperature_chr, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.m_txtBreakWater_chr, 0);
            this.Controls.SetChildIndex(this.label17, 0);
            this.Controls.SetChildIndex(this.m_txtEmbryo_chr, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.m_txtBlooded_chr, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.m_txtPulse_chr, 0);
            this.Controls.SetChildIndex(this.lsvSign, 0);
            this.m_pnlNewBase.ResumeLayout(false);
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
	
			this.m_txtBloodPressure_chr.m_mthClearText();
			this.m_txtBodyTemperature_chr.m_mthClearText();
			this.m_txtPulse_chr.m_mthClearText();
			this.m_txtUterus_chr.m_mthClearText();
			this.m_txtUterusSize_chr.m_mthClearText();
			this.m_txtBlooded_chr.m_mthClearText();
			this.m_txtBreakWater_chr.m_mthClearText();
			this.m_txtEmbryo_chr.m_mthClearText();
            this.lsvSign.Items.Clear();

            MDIParent.m_mthSetDefaulEmployee(lsvSign);
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
            clsIcuACAD_PostPartumseeRecord_VO objContent = (clsIcuACAD_PostPartumseeRecord_VO)p_objContent;
			//把表单值赋值到界面，由子窗体重载实现			
			this.m_mthClearRecordInfo();


			this.m_txtBloodPressure_chr.m_mthSetNewText(objContent.m_strBLOODPRESSURE_CHR,objContent.m_strBLOODPRESSURE_CHRXML);
			this.m_txtBodyTemperature_chr.m_mthSetNewText(objContent.m_strBODYTEMPARTURE_CHR,objContent.m_strBODYTEMPARTURE_CHRXML);
			this.m_txtPulse_chr.m_mthSetNewText(objContent.m_strPULSE_CHR,objContent.m_strPULSE_CHRXML);
			this.m_txtUterus_chr.m_mthSetNewText(objContent.m_strUTERUS_CHR,objContent.m_strUTERUS_CHRXML);
			this.m_txtBlooded_chr.m_mthSetNewText(objContent.m_strBLOODED_CHR,objContent.m_strBLOODED_CHRXML);
			this.m_txtBreakWater_chr.m_mthSetNewText(objContent.m_strBREAKWATER_CHR,objContent.m_strBREAKWATER_CHRXML);
			this.m_txtEmbryo_chr.m_mthSetNewText(objContent.m_strEMBRYO_CHR,objContent.m_strEMBRYO_CHRXML);

			this.m_txtUterusSize_chr.m_mthSetNewText(objContent.m_strUTERUSSIZE_CHR,objContent.m_strUTERUSSIZE_CHRXML);

            #region 签名集合
            m_mthAddSignToListView(lsvSign, objContent.objSignerArr);
            #endregion 签名		
            //if (objSign != null)
            //{
            //    m_txtSign.Text = objSign.m_strLASTNAME_VCHR;
            //    m_txtSign.Tag = objSign;
            //}
            //if(objContent.m_strSIGNNAME_CHR !=null &&objContent.m_strSIGNNAME_CHR != "")
            //    m_txtSign.Text=objContent.m_strSIGNNAME_CHR;
            //this.m_txtSign.Enabled = false;
            //this.m_dtpCreateDate.Enabled = false;
            this.m_dtpCreateDate.Value = objContent.m_dtmRecordDate;
		}

		protected override void m_mthSetDeletedGUIFromContent(iCareData.clsTrackRecordContent p_objContent)
		{
            clsIcuACAD_PostPartumseeRecord_VO objContent = (clsIcuACAD_PostPartumseeRecord_VO)p_objContent;
			//把表单值赋值到界面，由子窗体重载实现			

			this.m_mthClearRecordInfo();
		

			this.m_txtBloodPressure_chr.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strBLOODPRESSURE_CHR,objContent.m_strBLOODPRESSURE_CHRXML);
			this.m_txtBodyTemperature_chr.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strBODYTEMPARTURE_CHR,objContent.m_strBODYTEMPARTURE_CHRXML);
			this.m_txtPulse_chr.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strPULSE_CHR,objContent.m_strPULSE_CHRXML);
			
			this.m_txtUterus_chr.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strUTERUS_CHR,objContent.m_strUTERUS_CHRXML);
			
			this.m_txtBlooded_chr.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strBLOODED_CHR,objContent.m_strBLOODED_CHRXML);
			
			this.m_txtBreakWater_chr.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strBREAKWATER_CHR,objContent.m_strBREAKWATER_CHRXML);
			this.m_txtEmbryo_chr.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strEMBRYO_CHR,objContent.m_strEMBRYO_CHRXML);
			this.m_txtUterusSize_chr.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strUTERUSSIZE_CHR,objContent.m_strUTERUSSIZE_CHRXML);
			
            //if(objContent.m_strSIGNNAME_CHR !=null &&objContent.m_strSIGNNAME_CHR != "")
            //    m_txtSign.Text=objContent.m_strSIGNNAME_CHR;
            //this.m_txtSign.Enabled = false;
			this.m_dtpCreateDate.Enabled = false;
            m_mthAddSignToListView(lsvSign, objContent.objSignerArr);
		
		}
        /// <summary>
        /// 设置子窗体的创建时间基类时间等，为了适合用RegisterId与新业务要求用
        /// </summary>
        /// <param name="p_objContent"></param>
        protected override void m_mthSetSubCreatedDateInfo(ref clsTrackRecordContent p_objContent, bool p_blnIsAddNew)
        {
            if (p_objContent != null)
            {
                p_objContent.m_strRegisterID = m_objCurrentPatient.m_StrRegisterId;
                p_objContent.m_bytIfConfirm = 0;
                p_objContent.m_bytStatus = 1;
                if (p_blnIsAddNew)
                {
                    p_objContent.m_dtmCreateDate = new clsPublicDomain().m_dtmGetServerTime();
                    p_objContent.m_strCreateUserID = MDIParent.OperatorID;
                }
                p_objContent.m_dtmModifyDate = p_objContent.m_dtmCreateDate;
                p_objContent.m_strConfirmReason = "";
                p_objContent.m_strConfirmReasonXML = "";
                p_objContent.m_strInPatientID = m_objCurrentPatient.m_StrInPatientID;
                p_objContent.m_dtmOpenDate = m_objCurrentPatient.m_DtmLastInDate;
                p_objContent.m_strModifyUserID = MDIParent.OperatorID;
                p_objContent.m_dtmRecordDate = DateTime.Parse(m_dtpCreateDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            }
        }
		protected override iCareData.clsTrackRecordContent m_objGetContentFromGUI()
		{
			
			//界面参数校验
			if(m_objCurrentPatient==null)// || this.txtInPatientID.Text!=this.m_objCurrentPatient.m_StrHISInPatientID || txtInPatientID.Text=="")				
				return null;

			//从界面获取表单值		
            clsIcuACAD_PostPartumseeRecord_VO objContent = new clsIcuACAD_PostPartumseeRecord_VO();
			try
			{
				objContent.m_dtmCreateDate =DateTime.Now ;
 
			

				//				objContent.m_strINAMOUNTITEM_RIGHT=this.m_txtItem.m_strGetRightText();
				objContent.m_strBLOODPRESSURE_CHR=this.m_txtBloodPressure_chr.Text;
				objContent.m_strBLOODPRESSURE_CHR_RIGHT=this.m_txtBloodPressure_chr.m_strGetRightText();
				objContent.m_strBLOODPRESSURE_CHRXML=this.m_txtBloodPressure_chr.m_strGetXmlText();

				objContent.m_strBODYTEMPARTURE_CHR_RIGHT=this.m_txtBodyTemperature_chr.m_strGetRightText();
				objContent.m_strBODYTEMPARTURE_CHR=this.m_txtBodyTemperature_chr.Text;
				objContent.m_strBODYTEMPARTURE_CHRXML=this.m_txtBodyTemperature_chr.m_strGetXmlText();

				objContent.m_strPULSE_CHR_RIGHT=this.m_txtPulse_chr.m_strGetRightText();
				objContent.m_strPULSE_CHR=this.m_txtPulse_chr.Text;
				objContent.m_strPULSE_CHRXML=this.m_txtPulse_chr.m_strGetXmlText();

				objContent.m_strUTERUS_CHR_RIGHT=this.m_txtUterus_chr.m_strGetRightText();
				objContent.m_strUTERUS_CHR=this.m_txtUterus_chr.Text;
				objContent.m_strUTERUS_CHRXML=this.m_txtUterus_chr.m_strGetXmlText();

				objContent.m_strBLOODED_CHR_RIGHT=this.m_txtBlooded_chr.m_strGetRightText();
				objContent.m_strBLOODED_CHR=this.m_txtBlooded_chr.Text;
				objContent.m_strBLOODED_CHRXML=this.m_txtBlooded_chr.m_strGetXmlText();

				objContent.m_strBREAKWATER_CHR_RIGHT=this.m_txtBreakWater_chr.m_strGetRightText();
				objContent.m_strBREAKWATER_CHR=this.m_txtBreakWater_chr.Text;
				objContent.m_strBREAKWATER_CHRXML=this.m_txtBreakWater_chr.m_strGetXmlText();

				objContent.m_strEMBRYO_CHR_RIGHT=this.m_txtEmbryo_chr.m_strGetRightText();
				objContent.m_strEMBRYO_CHR=this.m_txtEmbryo_chr.Text;
				objContent.m_strEMBRYO_CHRXML=this.m_txtEmbryo_chr.m_strGetXmlText();
            			
				objContent.m_strUTERUSSIZE_CHR_RIGHT=this.m_txtUterusSize_chr.m_strGetRightText();
				objContent.m_strUTERUSSIZE_CHR=this.m_txtUterusSize_chr.Text;
				objContent.m_strUTERUSSIZE_CHRXML=this.m_txtUterusSize_chr.m_strGetXmlText();

                string strRecordUserIdArr = string.Empty;
                string strRecordUserMame = string.Empty;
                m_mthGetSignArr(new Control[]{lsvSign},ref objContent.objSignerArr,ref strRecordUserIdArr,ref strRecordUserMame);
                objContent.m_strRecordUserID = strRecordUserIdArr;
                //objContent.m_strCreateUserID = ((clsEmployee)m_txtSign.Tag).m_StrEmployeeID;--
                //objContent.m_dtmModifyDate = DateTime.Now;
                //objContent.m_strModifyUserID = MDIParent.OperatorID;
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
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.PostartumSeeRecord);	
			//(需要改动)				
		}

		/// <summary>
		/// 把选择时间记录内容重新整理为完全正确的内容。
		/// </summary>
		/// <param name="p_objRecordContent"></param>
		protected override void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
		{
			//把选择时间记录内容重新整理为完全正确的内容，由子窗体重载实现。
            clsIcuACAD_PostPartumseeRecord_VO objContent = (clsIcuACAD_PostPartumseeRecord_VO)p_objRecordContent; //(需要改动)
		}

		public override string m_strReloadFormTitle()
		{
			//由子窗体重载实现
			//(需要改动)	
			return	"中期妊娠引产后观察记录";
		}

		
		#region Jump Control
		protected override void m_mthInitJump(clsJumpControl p_objJump)
		{	//(需要改动)	
			p_objJump=new clsJumpControl(this,
				new Control[]{m_txtBlooded_chr,m_txtBodyTemperature_chr,m_txtPulse_chr,m_txtBloodPressure_chr,this.m_txtUterusSize_chr,m_txtUterus_chr,m_txtEmbryo_chr,m_txtBreakWater_chr,
								 m_cmdOK},Keys.Enter);
		}
		#endregion

		private void frmICUNurseRecord_GXCon_Load(object sender, System.EventArgs e)
		{
			m_txtBlooded_chr.Focus();
		}

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void m_cmdOK_Click(object sender, System.EventArgs e)
		{
			if(m_lngSave() > 0)
			{
				this.DialogResult = DialogResult.Yes;
				this.Close();
			}
		}

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void m_cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.None;
			this.Close();
		}

		private void m_lsvEmployee_DoubleClick(object sender, System.EventArgs e)
		{
            //if(m_lsvEmployee.Items.Count!=0)
            //    if(m_lsvEmployee.SelectedItems.Count>0)
            //        m_txtSign.Text = 	m_lsvEmployee.SelectedItems[0].Text;
			
		}

		private void dateTimePicker1_ValueChanged(object sender, System.EventArgs e)
		{
			//m_txtBeforehand_chr.Text = this.dateTimePicker1.Value.ToString();
		}
        public override clsTrackRecordContent m_objGetRecordContent(clsPatient p_objSelectedPatient, string p_strOpenDate)
        {
            clsTrackRecordContent objContent;
            //获取记录
            m_objDiseaseTrackDomain.m_lngGetRecordContent(p_objSelectedPatient.m_StrRegisterId, p_strOpenDate, out objContent);
            return objContent;
        }

        private void m_txtBodyTemperature_chr_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if (e.KeyChar != '\b' && !Char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
    
        }
	}
}
