using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using iCareData;
using com.digitalwave.Utility.Controls;
using System.Data;
using HRP;
using System.Drawing.Printing;
using System.Xml;
using iCare.ICU.Espial;

namespace iCare
{
	/// <summary>
	/// 观察项目记录编辑窗体的实现。
	/// Alex 2003-5-13
	/// </summary>
	public class frmSubWatchItemRecord : iCare.frmDiseaseTrackBase
	{
		private System.Windows.Forms.Label lblTemperatureTitle;
		private System.Windows.Forms.Label lblHeartRhythmTitle;
		private com.digitalwave.controls.ctlRichTextBox m_txtTemperature;
		private com.digitalwave.controls.ctlRichTextBox m_txtHeartRhythm;
		private System.Windows.Forms.Label lblBreathTitle;
		private System.Windows.Forms.Label lblPulseTitle;
		private System.Windows.Forms.Label lblHeartFrequencyTitle;
		private com.digitalwave.controls.ctlRichTextBox m_txtPulse;
		private com.digitalwave.controls.ctlRichTextBox m_txtBreath;
		private com.digitalwave.controls.ctlRichTextBox m_txtHeartFrequency;
		private System.Windows.Forms.Label lblBedsideBloodSugarTitle;
		private System.Windows.Forms.Label lblBloodPressureTitle;
		private System.Windows.Forms.Label lblBloodOxygenSaturationTitle;
		private com.digitalwave.controls.ctlRichTextBox m_txtBedsideBloodSugar;
		private System.Windows.Forms.GroupBox m_gpbOut;
		private System.Windows.Forms.Label lblOutVTitle;
		private com.digitalwave.controls.ctlRichTextBox m_txtOutV;
		private System.Windows.Forms.Label lblOutSTitle;
		private com.digitalwave.controls.ctlRichTextBox m_txtOutS;
		private System.Windows.Forms.Label lblOutUTitle;
		private System.Windows.Forms.Label lblOutETitle;
		private com.digitalwave.controls.ctlRichTextBox m_txtOutE;
		private com.digitalwave.controls.ctlRichTextBox m_txtOutU;
		private System.Windows.Forms.GroupBox m_gpbIn;
		private com.digitalwave.controls.ctlRichTextBox m_txtInD;
		private System.Windows.Forms.Label lblInDTitle;
		private com.digitalwave.controls.ctlRichTextBox m_txtInI;
		private System.Windows.Forms.Label lblInITitle;
		private System.Windows.Forms.GroupBox m_gpbPupil;
		private System.Windows.Forms.GroupBox m_gpbPupil_Echo;
		private com.digitalwave.controls.ctlRichTextBox m_txtEchoLeft;
		private System.Windows.Forms.Label lblLeft1;
		private com.digitalwave.controls.ctlRichTextBox m_txtEchoRight;
		private System.Windows.Forms.Label lblRight1;
		private System.Windows.Forms.GroupBox m_gpbPupil_Size;
		private com.digitalwave.controls.ctlRichTextBox m_txtPupilLeft;
		private System.Windows.Forms.Label lblPupilLeftTitle;
		private com.digitalwave.controls.ctlRichTextBox m_txtPupilRight;
		private System.Windows.Forms.Label lblPupilRightTitle;
		private com.digitalwave.controls.ctlRichTextBox m_txtBloodPressureS;
		private com.digitalwave.controls.ctlRichTextBox m_txtBloodPressureA;
		private System.Windows.Forms.Label lblBloodPressureTitle2;
		private com.digitalwave.controls.ctlRichTextBox m_txtBloodOxygenSaturation;
		private PinkieControls.ButtonXP cmdConfirm;
		private System.Windows.Forms.Label lblSignTitle;
		private System.Windows.Forms.Label m_lblSign;
		private PinkieControls.ButtonXP m_cmdClose;
		private PinkieControls.ButtonXP m_cmdGetDovueData;
		private PinkieControls.ButtonXP m_cmdGetGEData;
		private System.Windows.Forms.Label lblEmployeeSign;
		protected System.Windows.Forms.ListView m_lsvEmployee;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtSign;
		private System.ComponentModel.IContainer components = null;

		private clsEmployeeSignTool m_objSignTool;

		/// <summary>
		/// 接收数据类
		/// </summary>
		protected clsICUGESimulateGetData m_objICUGESimulateGetData;




		public frmSubWatchItemRecord()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
            //指明护士工作站表单
            intFormType = 2;
			// TODO: Add any initialization after the InitializeComponent call
			m_mthSetRichTextBoxAttribInControl(this);

			m_objSignTool = new clsEmployeeSignTool(m_lsvEmployee);

			m_objSignTool.m_mthAddControl(m_txtSign);
			
			m_objICUGESimulateGetData=new clsICUGESimulateGetData(this);

		}

		public override int m_IntFormID
		{
			get
			{
				return 3;
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.lblTemperatureTitle = new System.Windows.Forms.Label();
            this.lblHeartRhythmTitle = new System.Windows.Forms.Label();
            this.m_txtTemperature = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtHeartRhythm = new com.digitalwave.controls.ctlRichTextBox();
            this.lblBreathTitle = new System.Windows.Forms.Label();
            this.lblPulseTitle = new System.Windows.Forms.Label();
            this.lblHeartFrequencyTitle = new System.Windows.Forms.Label();
            this.m_txtPulse = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtBreath = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtHeartFrequency = new com.digitalwave.controls.ctlRichTextBox();
            this.lblBedsideBloodSugarTitle = new System.Windows.Forms.Label();
            this.lblBloodPressureTitle = new System.Windows.Forms.Label();
            this.lblBloodOxygenSaturationTitle = new System.Windows.Forms.Label();
            this.m_txtBedsideBloodSugar = new com.digitalwave.controls.ctlRichTextBox();
            this.m_gpbOut = new System.Windows.Forms.GroupBox();
            this.lblOutVTitle = new System.Windows.Forms.Label();
            this.m_txtOutV = new com.digitalwave.controls.ctlRichTextBox();
            this.lblOutSTitle = new System.Windows.Forms.Label();
            this.m_txtOutS = new com.digitalwave.controls.ctlRichTextBox();
            this.lblOutUTitle = new System.Windows.Forms.Label();
            this.lblOutETitle = new System.Windows.Forms.Label();
            this.m_txtOutE = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtOutU = new com.digitalwave.controls.ctlRichTextBox();
            this.m_gpbIn = new System.Windows.Forms.GroupBox();
            this.m_txtInD = new com.digitalwave.controls.ctlRichTextBox();
            this.lblInDTitle = new System.Windows.Forms.Label();
            this.m_txtInI = new com.digitalwave.controls.ctlRichTextBox();
            this.lblInITitle = new System.Windows.Forms.Label();
            this.m_gpbPupil = new System.Windows.Forms.GroupBox();
            this.m_gpbPupil_Echo = new System.Windows.Forms.GroupBox();
            this.m_txtEchoLeft = new com.digitalwave.controls.ctlRichTextBox();
            this.lblLeft1 = new System.Windows.Forms.Label();
            this.m_txtEchoRight = new com.digitalwave.controls.ctlRichTextBox();
            this.lblRight1 = new System.Windows.Forms.Label();
            this.m_gpbPupil_Size = new System.Windows.Forms.GroupBox();
            this.m_txtPupilLeft = new com.digitalwave.controls.ctlRichTextBox();
            this.lblPupilLeftTitle = new System.Windows.Forms.Label();
            this.m_txtPupilRight = new com.digitalwave.controls.ctlRichTextBox();
            this.lblPupilRightTitle = new System.Windows.Forms.Label();
            this.m_txtBloodPressureS = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtBloodPressureA = new com.digitalwave.controls.ctlRichTextBox();
            this.lblBloodPressureTitle2 = new System.Windows.Forms.Label();
            this.m_txtBloodOxygenSaturation = new com.digitalwave.controls.ctlRichTextBox();
            this.cmdConfirm = new PinkieControls.ButtonXP();
            this.lblSignTitle = new System.Windows.Forms.Label();
            this.m_lblSign = new System.Windows.Forms.Label();
            this.m_cmdClose = new PinkieControls.ButtonXP();
            this.m_cmdGetDovueData = new PinkieControls.ButtonXP();
            this.m_cmdGetGEData = new PinkieControls.ButtonXP();
            this.lblEmployeeSign = new System.Windows.Forms.Label();
            this.m_lsvEmployee = new System.Windows.Forms.ListView();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.m_txtSign = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_gpbOut.SuspendLayout();
            this.m_gpbIn.SuspendLayout();
            this.m_gpbPupil.SuspendLayout();
            this.m_gpbPupil_Echo.SuspendLayout();
            this.m_gpbPupil_Size.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_trvCreateDate
            // 
            this.m_trvCreateDate.LineColor = System.Drawing.Color.Black;
            this.m_trvCreateDate.Size = new System.Drawing.Size(212, 40);
            // 
            // lblCreateDateTitle
            // 
            this.lblCreateDateTitle.Location = new System.Drawing.Point(16, 184);
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.Location = new System.Drawing.Point(96, 180);
            // 
            // m_dtpGetDataTime
            // 
            this.m_dtpGetDataTime.Location = new System.Drawing.Point(96, 208);
            this.m_dtpGetDataTime.Visible = true;
            // 
            // m_lblGetDataTime
            // 
            this.m_lblGetDataTime.Location = new System.Drawing.Point(0, 212);
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(344, 116);
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(276, 48);
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(288, 116);
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.BackColor = System.Drawing.SystemColors.Control;
            this.m_lsvInPatientID.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_lsvInPatientID.Location = new System.Drawing.Point(616, 136);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(108, 72);
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(348, 44);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Visible = true;
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(416, -29);
            // 
            // lblTemperatureTitle
            // 
            this.lblTemperatureTitle.AutoSize = true;
            this.lblTemperatureTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblTemperatureTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTemperatureTitle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblTemperatureTitle.Location = new System.Drawing.Point(320, 184);
            this.lblTemperatureTitle.Name = "lblTemperatureTitle";
            this.lblTemperatureTitle.Size = new System.Drawing.Size(70, 14);
            this.lblTemperatureTitle.TabIndex = 6074;
            this.lblTemperatureTitle.Text = "体温(℃):";
            // 
            // lblHeartRhythmTitle
            // 
            this.lblHeartRhythmTitle.AutoSize = true;
            this.lblHeartRhythmTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblHeartRhythmTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHeartRhythmTitle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblHeartRhythmTitle.Location = new System.Drawing.Point(516, 180);
            this.lblHeartRhythmTitle.Name = "lblHeartRhythmTitle";
            this.lblHeartRhythmTitle.Size = new System.Drawing.Size(42, 14);
            this.lblHeartRhythmTitle.TabIndex = 6073;
            this.lblHeartRhythmTitle.Text = "心律:";
            // 
            // m_txtTemperature
            // 
            this.m_txtTemperature.BackColor = System.Drawing.Color.White;
            this.m_txtTemperature.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtTemperature.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtTemperature.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtTemperature.Location = new System.Drawing.Point(416, 180);
            this.m_txtTemperature.m_BlnIgnoreUserInfo = false;
            this.m_txtTemperature.m_BlnPartControl = false;
            this.m_txtTemperature.m_BlnReadOnly = false;
            this.m_txtTemperature.m_BlnUnderLineDST = false;
            this.m_txtTemperature.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtTemperature.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtTemperature.m_IntCanModifyTime = 6;
            this.m_txtTemperature.m_IntPartControlLength = 0;
            this.m_txtTemperature.m_IntPartControlStartIndex = 0;
            this.m_txtTemperature.m_StrUserID = "";
            this.m_txtTemperature.m_StrUserName = "";
            this.m_txtTemperature.Multiline = false;
            this.m_txtTemperature.Name = "m_txtTemperature";
            this.m_txtTemperature.Size = new System.Drawing.Size(88, 21);
            this.m_txtTemperature.TabIndex = 0;
            this.m_txtTemperature.Text = "";
            // 
            // m_txtHeartRhythm
            // 
            this.m_txtHeartRhythm.BackColor = System.Drawing.Color.White;
            this.m_txtHeartRhythm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtHeartRhythm.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtHeartRhythm.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtHeartRhythm.Location = new System.Drawing.Point(616, 180);
            this.m_txtHeartRhythm.m_BlnIgnoreUserInfo = false;
            this.m_txtHeartRhythm.m_BlnPartControl = false;
            this.m_txtHeartRhythm.m_BlnReadOnly = false;
            this.m_txtHeartRhythm.m_BlnUnderLineDST = false;
            this.m_txtHeartRhythm.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtHeartRhythm.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtHeartRhythm.m_IntCanModifyTime = 6;
            this.m_txtHeartRhythm.m_IntPartControlLength = 0;
            this.m_txtHeartRhythm.m_IntPartControlStartIndex = 0;
            this.m_txtHeartRhythm.m_StrUserID = "";
            this.m_txtHeartRhythm.m_StrUserName = "";
            this.m_txtHeartRhythm.Multiline = false;
            this.m_txtHeartRhythm.Name = "m_txtHeartRhythm";
            this.m_txtHeartRhythm.Size = new System.Drawing.Size(92, 21);
            this.m_txtHeartRhythm.TabIndex = 1;
            this.m_txtHeartRhythm.Text = "";
            // 
            // lblBreathTitle
            // 
            this.lblBreathTitle.AutoSize = true;
            this.lblBreathTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblBreathTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBreathTitle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblBreathTitle.Location = new System.Drawing.Point(516, 208);
            this.lblBreathTitle.Name = "lblBreathTitle";
            this.lblBreathTitle.Size = new System.Drawing.Size(91, 14);
            this.lblBreathTitle.TabIndex = 6078;
            this.lblBreathTitle.Text = "呼吸(次/分):";
            // 
            // lblPulseTitle
            // 
            this.lblPulseTitle.AutoSize = true;
            this.lblPulseTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblPulseTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPulseTitle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblPulseTitle.Location = new System.Drawing.Point(320, 208);
            this.lblPulseTitle.Name = "lblPulseTitle";
            this.lblPulseTitle.Size = new System.Drawing.Size(91, 14);
            this.lblPulseTitle.TabIndex = 6080;
            this.lblPulseTitle.Text = "脉搏(次/分):";
            // 
            // lblHeartFrequencyTitle
            // 
            this.lblHeartFrequencyTitle.AutoSize = true;
            this.lblHeartFrequencyTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblHeartFrequencyTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHeartFrequencyTitle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblHeartFrequencyTitle.Location = new System.Drawing.Point(16, 244);
            this.lblHeartFrequencyTitle.Name = "lblHeartFrequencyTitle";
            this.lblHeartFrequencyTitle.Size = new System.Drawing.Size(91, 14);
            this.lblHeartFrequencyTitle.TabIndex = 6079;
            this.lblHeartFrequencyTitle.Text = "心率(次/分):";
            // 
            // m_txtPulse
            // 
            this.m_txtPulse.BackColor = System.Drawing.Color.White;
            this.m_txtPulse.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPulse.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtPulse.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPulse.Location = new System.Drawing.Point(416, 208);
            this.m_txtPulse.m_BlnIgnoreUserInfo = false;
            this.m_txtPulse.m_BlnPartControl = false;
            this.m_txtPulse.m_BlnReadOnly = false;
            this.m_txtPulse.m_BlnUnderLineDST = false;
            this.m_txtPulse.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPulse.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPulse.m_IntCanModifyTime = 6;
            this.m_txtPulse.m_IntPartControlLength = 0;
            this.m_txtPulse.m_IntPartControlStartIndex = 0;
            this.m_txtPulse.m_StrUserID = "";
            this.m_txtPulse.m_StrUserName = "";
            this.m_txtPulse.Multiline = false;
            this.m_txtPulse.Name = "m_txtPulse";
            this.m_txtPulse.Size = new System.Drawing.Size(88, 21);
            this.m_txtPulse.TabIndex = 2;
            this.m_txtPulse.Text = "";
            // 
            // m_txtBreath
            // 
            this.m_txtBreath.BackColor = System.Drawing.Color.White;
            this.m_txtBreath.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBreath.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBreath.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBreath.Location = new System.Drawing.Point(616, 208);
            this.m_txtBreath.m_BlnIgnoreUserInfo = false;
            this.m_txtBreath.m_BlnPartControl = false;
            this.m_txtBreath.m_BlnReadOnly = false;
            this.m_txtBreath.m_BlnUnderLineDST = false;
            this.m_txtBreath.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBreath.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBreath.m_IntCanModifyTime = 6;
            this.m_txtBreath.m_IntPartControlLength = 0;
            this.m_txtBreath.m_IntPartControlStartIndex = 0;
            this.m_txtBreath.m_StrUserID = "";
            this.m_txtBreath.m_StrUserName = "";
            this.m_txtBreath.Multiline = false;
            this.m_txtBreath.Name = "m_txtBreath";
            this.m_txtBreath.Size = new System.Drawing.Size(92, 21);
            this.m_txtBreath.TabIndex = 3;
            this.m_txtBreath.Text = "";
            // 
            // m_txtHeartFrequency
            // 
            this.m_txtHeartFrequency.BackColor = System.Drawing.Color.White;
            this.m_txtHeartFrequency.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtHeartFrequency.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtHeartFrequency.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtHeartFrequency.Location = new System.Drawing.Point(128, 244);
            this.m_txtHeartFrequency.m_BlnIgnoreUserInfo = false;
            this.m_txtHeartFrequency.m_BlnPartControl = false;
            this.m_txtHeartFrequency.m_BlnReadOnly = false;
            this.m_txtHeartFrequency.m_BlnUnderLineDST = false;
            this.m_txtHeartFrequency.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtHeartFrequency.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtHeartFrequency.m_IntCanModifyTime = 6;
            this.m_txtHeartFrequency.m_IntPartControlLength = 0;
            this.m_txtHeartFrequency.m_IntPartControlStartIndex = 0;
            this.m_txtHeartFrequency.m_StrUserID = "";
            this.m_txtHeartFrequency.m_StrUserName = "";
            this.m_txtHeartFrequency.Multiline = false;
            this.m_txtHeartFrequency.Name = "m_txtHeartFrequency";
            this.m_txtHeartFrequency.Size = new System.Drawing.Size(44, 21);
            this.m_txtHeartFrequency.TabIndex = 4;
            this.m_txtHeartFrequency.Text = "";
            // 
            // lblBedsideBloodSugarTitle
            // 
            this.lblBedsideBloodSugarTitle.AutoSize = true;
            this.lblBedsideBloodSugarTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblBedsideBloodSugarTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBedsideBloodSugarTitle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblBedsideBloodSugarTitle.Location = new System.Drawing.Point(16, 316);
            this.lblBedsideBloodSugarTitle.Name = "lblBedsideBloodSugarTitle";
            this.lblBedsideBloodSugarTitle.Size = new System.Drawing.Size(126, 14);
            this.lblBedsideBloodSugarTitle.TabIndex = 6091;
            this.lblBedsideBloodSugarTitle.Text = "床边血糖(mmol/L):";
            // 
            // lblBloodPressureTitle
            // 
            this.lblBloodPressureTitle.AutoSize = true;
            this.lblBloodPressureTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblBloodPressureTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBloodPressureTitle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblBloodPressureTitle.Location = new System.Drawing.Point(16, 268);
            this.lblBloodPressureTitle.Name = "lblBloodPressureTitle";
            this.lblBloodPressureTitle.Size = new System.Drawing.Size(84, 14);
            this.lblBloodPressureTitle.TabIndex = 6089;
            this.lblBloodPressureTitle.Text = "血压(mmHg):";
            // 
            // lblBloodOxygenSaturationTitle
            // 
            this.lblBloodOxygenSaturationTitle.AutoSize = true;
            this.lblBloodOxygenSaturationTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblBloodOxygenSaturationTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBloodOxygenSaturationTitle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblBloodOxygenSaturationTitle.Location = new System.Drawing.Point(16, 296);
            this.lblBloodOxygenSaturationTitle.Name = "lblBloodOxygenSaturationTitle";
            this.lblBloodOxygenSaturationTitle.Size = new System.Drawing.Size(105, 14);
            this.lblBloodOxygenSaturationTitle.TabIndex = 6088;
            this.lblBloodOxygenSaturationTitle.Text = "血氧饱和度(%):";
            // 
            // m_txtBedsideBloodSugar
            // 
            this.m_txtBedsideBloodSugar.BackColor = System.Drawing.Color.White;
            this.m_txtBedsideBloodSugar.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBedsideBloodSugar.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBedsideBloodSugar.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBedsideBloodSugar.Location = new System.Drawing.Point(168, 316);
            this.m_txtBedsideBloodSugar.m_BlnIgnoreUserInfo = false;
            this.m_txtBedsideBloodSugar.m_BlnPartControl = false;
            this.m_txtBedsideBloodSugar.m_BlnReadOnly = false;
            this.m_txtBedsideBloodSugar.m_BlnUnderLineDST = false;
            this.m_txtBedsideBloodSugar.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBedsideBloodSugar.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBedsideBloodSugar.m_IntCanModifyTime = 6;
            this.m_txtBedsideBloodSugar.m_IntPartControlLength = 0;
            this.m_txtBedsideBloodSugar.m_IntPartControlStartIndex = 0;
            this.m_txtBedsideBloodSugar.m_StrUserID = "";
            this.m_txtBedsideBloodSugar.m_StrUserName = "";
            this.m_txtBedsideBloodSugar.Multiline = false;
            this.m_txtBedsideBloodSugar.Name = "m_txtBedsideBloodSugar";
            this.m_txtBedsideBloodSugar.Size = new System.Drawing.Size(136, 21);
            this.m_txtBedsideBloodSugar.TabIndex = 8;
            this.m_txtBedsideBloodSugar.Text = "";
            // 
            // m_gpbOut
            // 
            this.m_gpbOut.BackColor = System.Drawing.SystemColors.Control;
            this.m_gpbOut.Controls.Add(this.lblOutVTitle);
            this.m_gpbOut.Controls.Add(this.m_txtOutV);
            this.m_gpbOut.Controls.Add(this.lblOutSTitle);
            this.m_gpbOut.Controls.Add(this.m_txtOutS);
            this.m_gpbOut.Controls.Add(this.lblOutUTitle);
            this.m_gpbOut.Controls.Add(this.lblOutETitle);
            this.m_gpbOut.Controls.Add(this.m_txtOutE);
            this.m_gpbOut.Controls.Add(this.m_txtOutU);
            this.m_gpbOut.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_gpbOut.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_gpbOut.Location = new System.Drawing.Point(316, 348);
            this.m_gpbOut.Name = "m_gpbOut";
            this.m_gpbOut.Size = new System.Drawing.Size(392, 100);
            this.m_gpbOut.TabIndex = 11;
            this.m_gpbOut.TabStop = false;
            this.m_gpbOut.Text = "排出量(ml)";
            // 
            // lblOutVTitle
            // 
            this.lblOutVTitle.AutoSize = true;
            this.lblOutVTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblOutVTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOutVTitle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblOutVTitle.Location = new System.Drawing.Point(192, 68);
            this.lblOutVTitle.Name = "lblOutVTitle";
            this.lblOutVTitle.Size = new System.Drawing.Size(56, 14);
            this.lblOutVTitle.TabIndex = 1145;
            this.lblOutVTitle.Text = "呕吐物:";
            // 
            // m_txtOutV
            // 
            this.m_txtOutV.BackColor = System.Drawing.Color.White;
            this.m_txtOutV.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOutV.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtOutV.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOutV.Location = new System.Drawing.Point(260, 64);
            this.m_txtOutV.m_BlnIgnoreUserInfo = false;
            this.m_txtOutV.m_BlnPartControl = false;
            this.m_txtOutV.m_BlnReadOnly = false;
            this.m_txtOutV.m_BlnUnderLineDST = false;
            this.m_txtOutV.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOutV.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOutV.m_IntCanModifyTime = 6;
            this.m_txtOutV.m_IntPartControlLength = 0;
            this.m_txtOutV.m_IntPartControlStartIndex = 0;
            this.m_txtOutV.m_StrUserID = "";
            this.m_txtOutV.m_StrUserName = "";
            this.m_txtOutV.Multiline = false;
            this.m_txtOutV.Name = "m_txtOutV";
            this.m_txtOutV.Size = new System.Drawing.Size(100, 21);
            this.m_txtOutV.TabIndex = 3;
            this.m_txtOutV.Text = "";
            // 
            // lblOutSTitle
            // 
            this.lblOutSTitle.AutoSize = true;
            this.lblOutSTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblOutSTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOutSTitle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblOutSTitle.Location = new System.Drawing.Point(192, 32);
            this.lblOutSTitle.Name = "lblOutSTitle";
            this.lblOutSTitle.Size = new System.Drawing.Size(42, 14);
            this.lblOutSTitle.TabIndex = 1143;
            this.lblOutSTitle.Text = "大便:";
            // 
            // m_txtOutS
            // 
            this.m_txtOutS.BackColor = System.Drawing.Color.White;
            this.m_txtOutS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOutS.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtOutS.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOutS.Location = new System.Drawing.Point(260, 32);
            this.m_txtOutS.m_BlnIgnoreUserInfo = false;
            this.m_txtOutS.m_BlnPartControl = false;
            this.m_txtOutS.m_BlnReadOnly = false;
            this.m_txtOutS.m_BlnUnderLineDST = false;
            this.m_txtOutS.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOutS.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOutS.m_IntCanModifyTime = 6;
            this.m_txtOutS.m_IntPartControlLength = 0;
            this.m_txtOutS.m_IntPartControlStartIndex = 0;
            this.m_txtOutS.m_StrUserID = "";
            this.m_txtOutS.m_StrUserName = "";
            this.m_txtOutS.Multiline = false;
            this.m_txtOutS.Name = "m_txtOutS";
            this.m_txtOutS.Size = new System.Drawing.Size(100, 21);
            this.m_txtOutS.TabIndex = 1;
            this.m_txtOutS.Text = "";
            // 
            // lblOutUTitle
            // 
            this.lblOutUTitle.AutoSize = true;
            this.lblOutUTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblOutUTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOutUTitle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblOutUTitle.Location = new System.Drawing.Point(20, 32);
            this.lblOutUTitle.Name = "lblOutUTitle";
            this.lblOutUTitle.Size = new System.Drawing.Size(28, 14);
            this.lblOutUTitle.TabIndex = 507;
            this.lblOutUTitle.Text = "尿:";
            // 
            // lblOutETitle
            // 
            this.lblOutETitle.AutoSize = true;
            this.lblOutETitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblOutETitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOutETitle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblOutETitle.Location = new System.Drawing.Point(20, 68);
            this.lblOutETitle.Name = "lblOutETitle";
            this.lblOutETitle.Size = new System.Drawing.Size(56, 14);
            this.lblOutETitle.TabIndex = 507;
            this.lblOutETitle.Text = "引流液:";
            // 
            // m_txtOutE
            // 
            this.m_txtOutE.BackColor = System.Drawing.Color.White;
            this.m_txtOutE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOutE.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtOutE.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOutE.Location = new System.Drawing.Point(80, 68);
            this.m_txtOutE.m_BlnIgnoreUserInfo = false;
            this.m_txtOutE.m_BlnPartControl = false;
            this.m_txtOutE.m_BlnReadOnly = false;
            this.m_txtOutE.m_BlnUnderLineDST = false;
            this.m_txtOutE.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOutE.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOutE.m_IntCanModifyTime = 6;
            this.m_txtOutE.m_IntPartControlLength = 0;
            this.m_txtOutE.m_IntPartControlStartIndex = 0;
            this.m_txtOutE.m_StrUserID = "";
            this.m_txtOutE.m_StrUserName = "";
            this.m_txtOutE.Multiline = false;
            this.m_txtOutE.Name = "m_txtOutE";
            this.m_txtOutE.Size = new System.Drawing.Size(104, 21);
            this.m_txtOutE.TabIndex = 2;
            this.m_txtOutE.Text = "";
            // 
            // m_txtOutU
            // 
            this.m_txtOutU.BackColor = System.Drawing.Color.White;
            this.m_txtOutU.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOutU.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtOutU.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOutU.Location = new System.Drawing.Point(80, 32);
            this.m_txtOutU.m_BlnIgnoreUserInfo = false;
            this.m_txtOutU.m_BlnPartControl = false;
            this.m_txtOutU.m_BlnReadOnly = false;
            this.m_txtOutU.m_BlnUnderLineDST = false;
            this.m_txtOutU.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOutU.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOutU.m_IntCanModifyTime = 6;
            this.m_txtOutU.m_IntPartControlLength = 0;
            this.m_txtOutU.m_IntPartControlStartIndex = 0;
            this.m_txtOutU.m_StrUserID = "";
            this.m_txtOutU.m_StrUserName = "";
            this.m_txtOutU.Multiline = false;
            this.m_txtOutU.Name = "m_txtOutU";
            this.m_txtOutU.Size = new System.Drawing.Size(104, 21);
            this.m_txtOutU.TabIndex = 0;
            this.m_txtOutU.Text = "";
            // 
            // m_gpbIn
            // 
            this.m_gpbIn.BackColor = System.Drawing.SystemColors.Control;
            this.m_gpbIn.Controls.Add(this.m_txtInD);
            this.m_gpbIn.Controls.Add(this.lblInDTitle);
            this.m_gpbIn.Controls.Add(this.m_txtInI);
            this.m_gpbIn.Controls.Add(this.lblInITitle);
            this.m_gpbIn.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_gpbIn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_gpbIn.Location = new System.Drawing.Point(16, 348);
            this.m_gpbIn.Name = "m_gpbIn";
            this.m_gpbIn.Size = new System.Drawing.Size(288, 100);
            this.m_gpbIn.TabIndex = 10;
            this.m_gpbIn.TabStop = false;
            this.m_gpbIn.Text = "摄入量(ml)";
            // 
            // m_txtInD
            // 
            this.m_txtInD.BackColor = System.Drawing.Color.White;
            this.m_txtInD.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtInD.ForeColor = System.Drawing.Color.White;
            this.m_txtInD.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtInD.Location = new System.Drawing.Point(76, 32);
            this.m_txtInD.m_BlnIgnoreUserInfo = false;
            this.m_txtInD.m_BlnPartControl = false;
            this.m_txtInD.m_BlnReadOnly = false;
            this.m_txtInD.m_BlnUnderLineDST = false;
            this.m_txtInD.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtInD.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtInD.m_IntCanModifyTime = 6;
            this.m_txtInD.m_IntPartControlLength = 0;
            this.m_txtInD.m_IntPartControlStartIndex = 0;
            this.m_txtInD.m_StrUserID = "";
            this.m_txtInD.m_StrUserName = "";
            this.m_txtInD.Multiline = false;
            this.m_txtInD.Name = "m_txtInD";
            this.m_txtInD.Size = new System.Drawing.Size(136, 21);
            this.m_txtInD.TabIndex = 0;
            this.m_txtInD.Text = "";
            // 
            // lblInDTitle
            // 
            this.lblInDTitle.AutoSize = true;
            this.lblInDTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblInDTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInDTitle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblInDTitle.Location = new System.Drawing.Point(24, 32);
            this.lblInDTitle.Name = "lblInDTitle";
            this.lblInDTitle.Size = new System.Drawing.Size(42, 14);
            this.lblInDTitle.TabIndex = 507;
            this.lblInDTitle.Text = "进食:";
            // 
            // m_txtInI
            // 
            this.m_txtInI.BackColor = System.Drawing.Color.White;
            this.m_txtInI.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtInI.ForeColor = System.Drawing.Color.White;
            this.m_txtInI.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtInI.Location = new System.Drawing.Point(76, 68);
            this.m_txtInI.m_BlnIgnoreUserInfo = false;
            this.m_txtInI.m_BlnPartControl = false;
            this.m_txtInI.m_BlnReadOnly = false;
            this.m_txtInI.m_BlnUnderLineDST = false;
            this.m_txtInI.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtInI.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtInI.m_IntCanModifyTime = 6;
            this.m_txtInI.m_IntPartControlLength = 0;
            this.m_txtInI.m_IntPartControlStartIndex = 0;
            this.m_txtInI.m_StrUserID = "";
            this.m_txtInI.m_StrUserName = "";
            this.m_txtInI.Multiline = false;
            this.m_txtInI.Name = "m_txtInI";
            this.m_txtInI.Size = new System.Drawing.Size(136, 21);
            this.m_txtInI.TabIndex = 1;
            this.m_txtInI.Text = "";
            // 
            // lblInITitle
            // 
            this.lblInITitle.AutoSize = true;
            this.lblInITitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblInITitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInITitle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblInITitle.Location = new System.Drawing.Point(24, 68);
            this.lblInITitle.Name = "lblInITitle";
            this.lblInITitle.Size = new System.Drawing.Size(42, 14);
            this.lblInITitle.TabIndex = 507;
            this.lblInITitle.Text = "输液:";
            // 
            // m_gpbPupil
            // 
            this.m_gpbPupil.BackColor = System.Drawing.SystemColors.Control;
            this.m_gpbPupil.Controls.Add(this.m_gpbPupil_Echo);
            this.m_gpbPupil.Controls.Add(this.m_gpbPupil_Size);
            this.m_gpbPupil.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_gpbPupil.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_gpbPupil.Location = new System.Drawing.Point(316, 232);
            this.m_gpbPupil.Name = "m_gpbPupil";
            this.m_gpbPupil.Size = new System.Drawing.Size(392, 112);
            this.m_gpbPupil.TabIndex = 9;
            this.m_gpbPupil.TabStop = false;
            this.m_gpbPupil.Text = "瞳孔";
            // 
            // m_gpbPupil_Echo
            // 
            this.m_gpbPupil_Echo.BackColor = System.Drawing.SystemColors.Control;
            this.m_gpbPupil_Echo.Controls.Add(this.m_txtEchoLeft);
            this.m_gpbPupil_Echo.Controls.Add(this.lblLeft1);
            this.m_gpbPupil_Echo.Controls.Add(this.m_txtEchoRight);
            this.m_gpbPupil_Echo.Controls.Add(this.lblRight1);
            this.m_gpbPupil_Echo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_gpbPupil_Echo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_gpbPupil_Echo.Location = new System.Drawing.Point(212, 24);
            this.m_gpbPupil_Echo.Name = "m_gpbPupil_Echo";
            this.m_gpbPupil_Echo.Size = new System.Drawing.Size(156, 80);
            this.m_gpbPupil_Echo.TabIndex = 1;
            this.m_gpbPupil_Echo.TabStop = false;
            this.m_gpbPupil_Echo.Text = "反射";
            // 
            // m_txtEchoLeft
            // 
            this.m_txtEchoLeft.BackColor = System.Drawing.Color.White;
            this.m_txtEchoLeft.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtEchoLeft.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtEchoLeft.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtEchoLeft.Location = new System.Drawing.Point(48, 24);
            this.m_txtEchoLeft.m_BlnIgnoreUserInfo = false;
            this.m_txtEchoLeft.m_BlnPartControl = false;
            this.m_txtEchoLeft.m_BlnReadOnly = false;
            this.m_txtEchoLeft.m_BlnUnderLineDST = false;
            this.m_txtEchoLeft.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtEchoLeft.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtEchoLeft.m_IntCanModifyTime = 6;
            this.m_txtEchoLeft.m_IntPartControlLength = 0;
            this.m_txtEchoLeft.m_IntPartControlStartIndex = 0;
            this.m_txtEchoLeft.m_StrUserID = "";
            this.m_txtEchoLeft.m_StrUserName = "";
            this.m_txtEchoLeft.Multiline = false;
            this.m_txtEchoLeft.Name = "m_txtEchoLeft";
            this.m_txtEchoLeft.Size = new System.Drawing.Size(88, 21);
            this.m_txtEchoLeft.TabIndex = 0;
            this.m_txtEchoLeft.Text = "";
            // 
            // lblLeft1
            // 
            this.lblLeft1.AutoSize = true;
            this.lblLeft1.BackColor = System.Drawing.SystemColors.Control;
            this.lblLeft1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLeft1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblLeft1.Location = new System.Drawing.Point(8, 24);
            this.lblLeft1.Name = "lblLeft1";
            this.lblLeft1.Size = new System.Drawing.Size(28, 14);
            this.lblLeft1.TabIndex = 507;
            this.lblLeft1.Text = "左:";
            // 
            // m_txtEchoRight
            // 
            this.m_txtEchoRight.BackColor = System.Drawing.Color.White;
            this.m_txtEchoRight.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtEchoRight.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtEchoRight.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtEchoRight.Location = new System.Drawing.Point(48, 52);
            this.m_txtEchoRight.m_BlnIgnoreUserInfo = false;
            this.m_txtEchoRight.m_BlnPartControl = false;
            this.m_txtEchoRight.m_BlnReadOnly = false;
            this.m_txtEchoRight.m_BlnUnderLineDST = false;
            this.m_txtEchoRight.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtEchoRight.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtEchoRight.m_IntCanModifyTime = 6;
            this.m_txtEchoRight.m_IntPartControlLength = 0;
            this.m_txtEchoRight.m_IntPartControlStartIndex = 0;
            this.m_txtEchoRight.m_StrUserID = "";
            this.m_txtEchoRight.m_StrUserName = "";
            this.m_txtEchoRight.Multiline = false;
            this.m_txtEchoRight.Name = "m_txtEchoRight";
            this.m_txtEchoRight.Size = new System.Drawing.Size(88, 21);
            this.m_txtEchoRight.TabIndex = 1;
            this.m_txtEchoRight.Text = "";
            // 
            // lblRight1
            // 
            this.lblRight1.AutoSize = true;
            this.lblRight1.BackColor = System.Drawing.SystemColors.Control;
            this.lblRight1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRight1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblRight1.Location = new System.Drawing.Point(8, 52);
            this.lblRight1.Name = "lblRight1";
            this.lblRight1.Size = new System.Drawing.Size(28, 14);
            this.lblRight1.TabIndex = 507;
            this.lblRight1.Text = "右:";
            // 
            // m_gpbPupil_Size
            // 
            this.m_gpbPupil_Size.BackColor = System.Drawing.SystemColors.Control;
            this.m_gpbPupil_Size.Controls.Add(this.m_txtPupilLeft);
            this.m_gpbPupil_Size.Controls.Add(this.lblPupilLeftTitle);
            this.m_gpbPupil_Size.Controls.Add(this.m_txtPupilRight);
            this.m_gpbPupil_Size.Controls.Add(this.lblPupilRightTitle);
            this.m_gpbPupil_Size.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_gpbPupil_Size.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_gpbPupil_Size.Location = new System.Drawing.Point(16, 24);
            this.m_gpbPupil_Size.Name = "m_gpbPupil_Size";
            this.m_gpbPupil_Size.Size = new System.Drawing.Size(188, 80);
            this.m_gpbPupil_Size.TabIndex = 0;
            this.m_gpbPupil_Size.TabStop = false;
            this.m_gpbPupil_Size.Text = "大小(mm)";
            // 
            // m_txtPupilLeft
            // 
            this.m_txtPupilLeft.BackColor = System.Drawing.Color.White;
            this.m_txtPupilLeft.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPupilLeft.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtPupilLeft.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPupilLeft.Location = new System.Drawing.Point(48, 24);
            this.m_txtPupilLeft.m_BlnIgnoreUserInfo = false;
            this.m_txtPupilLeft.m_BlnPartControl = false;
            this.m_txtPupilLeft.m_BlnReadOnly = false;
            this.m_txtPupilLeft.m_BlnUnderLineDST = false;
            this.m_txtPupilLeft.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPupilLeft.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPupilLeft.m_IntCanModifyTime = 6;
            this.m_txtPupilLeft.m_IntPartControlLength = 0;
            this.m_txtPupilLeft.m_IntPartControlStartIndex = 0;
            this.m_txtPupilLeft.m_StrUserID = "";
            this.m_txtPupilLeft.m_StrUserName = "";
            this.m_txtPupilLeft.Multiline = false;
            this.m_txtPupilLeft.Name = "m_txtPupilLeft";
            this.m_txtPupilLeft.Size = new System.Drawing.Size(88, 21);
            this.m_txtPupilLeft.TabIndex = 0;
            this.m_txtPupilLeft.Text = "";
            // 
            // lblPupilLeftTitle
            // 
            this.lblPupilLeftTitle.AutoSize = true;
            this.lblPupilLeftTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblPupilLeftTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPupilLeftTitle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblPupilLeftTitle.Location = new System.Drawing.Point(8, 24);
            this.lblPupilLeftTitle.Name = "lblPupilLeftTitle";
            this.lblPupilLeftTitle.Size = new System.Drawing.Size(28, 14);
            this.lblPupilLeftTitle.TabIndex = 507;
            this.lblPupilLeftTitle.Text = "左:";
            // 
            // m_txtPupilRight
            // 
            this.m_txtPupilRight.BackColor = System.Drawing.Color.White;
            this.m_txtPupilRight.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPupilRight.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtPupilRight.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPupilRight.Location = new System.Drawing.Point(48, 52);
            this.m_txtPupilRight.m_BlnIgnoreUserInfo = false;
            this.m_txtPupilRight.m_BlnPartControl = false;
            this.m_txtPupilRight.m_BlnReadOnly = false;
            this.m_txtPupilRight.m_BlnUnderLineDST = false;
            this.m_txtPupilRight.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPupilRight.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPupilRight.m_IntCanModifyTime = 6;
            this.m_txtPupilRight.m_IntPartControlLength = 0;
            this.m_txtPupilRight.m_IntPartControlStartIndex = 0;
            this.m_txtPupilRight.m_StrUserID = "";
            this.m_txtPupilRight.m_StrUserName = "";
            this.m_txtPupilRight.Multiline = false;
            this.m_txtPupilRight.Name = "m_txtPupilRight";
            this.m_txtPupilRight.Size = new System.Drawing.Size(88, 21);
            this.m_txtPupilRight.TabIndex = 1;
            this.m_txtPupilRight.Text = "";
            // 
            // lblPupilRightTitle
            // 
            this.lblPupilRightTitle.AutoSize = true;
            this.lblPupilRightTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblPupilRightTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPupilRightTitle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblPupilRightTitle.Location = new System.Drawing.Point(8, 52);
            this.lblPupilRightTitle.Name = "lblPupilRightTitle";
            this.lblPupilRightTitle.Size = new System.Drawing.Size(28, 14);
            this.lblPupilRightTitle.TabIndex = 507;
            this.lblPupilRightTitle.Text = "右:";
            // 
            // m_txtBloodPressureS
            // 
            this.m_txtBloodPressureS.BackColor = System.Drawing.Color.White;
            this.m_txtBloodPressureS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBloodPressureS.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBloodPressureS.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBloodPressureS.Location = new System.Drawing.Point(128, 268);
            this.m_txtBloodPressureS.m_BlnIgnoreUserInfo = false;
            this.m_txtBloodPressureS.m_BlnPartControl = false;
            this.m_txtBloodPressureS.m_BlnReadOnly = false;
            this.m_txtBloodPressureS.m_BlnUnderLineDST = false;
            this.m_txtBloodPressureS.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBloodPressureS.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBloodPressureS.m_IntCanModifyTime = 6;
            this.m_txtBloodPressureS.m_IntPartControlLength = 0;
            this.m_txtBloodPressureS.m_IntPartControlStartIndex = 0;
            this.m_txtBloodPressureS.m_StrUserID = "";
            this.m_txtBloodPressureS.m_StrUserName = "";
            this.m_txtBloodPressureS.Multiline = false;
            this.m_txtBloodPressureS.Name = "m_txtBloodPressureS";
            this.m_txtBloodPressureS.Size = new System.Drawing.Size(72, 21);
            this.m_txtBloodPressureS.TabIndex = 5;
            this.m_txtBloodPressureS.Text = "";
            // 
            // m_txtBloodPressureA
            // 
            this.m_txtBloodPressureA.BackColor = System.Drawing.Color.White;
            this.m_txtBloodPressureA.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBloodPressureA.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBloodPressureA.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBloodPressureA.Location = new System.Drawing.Point(228, 268);
            this.m_txtBloodPressureA.m_BlnIgnoreUserInfo = false;
            this.m_txtBloodPressureA.m_BlnPartControl = false;
            this.m_txtBloodPressureA.m_BlnReadOnly = false;
            this.m_txtBloodPressureA.m_BlnUnderLineDST = false;
            this.m_txtBloodPressureA.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBloodPressureA.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBloodPressureA.m_IntCanModifyTime = 6;
            this.m_txtBloodPressureA.m_IntPartControlLength = 0;
            this.m_txtBloodPressureA.m_IntPartControlStartIndex = 0;
            this.m_txtBloodPressureA.m_StrUserID = "";
            this.m_txtBloodPressureA.m_StrUserName = "";
            this.m_txtBloodPressureA.Multiline = false;
            this.m_txtBloodPressureA.Name = "m_txtBloodPressureA";
            this.m_txtBloodPressureA.Size = new System.Drawing.Size(76, 21);
            this.m_txtBloodPressureA.TabIndex = 6;
            this.m_txtBloodPressureA.Text = "";
            // 
            // lblBloodPressureTitle2
            // 
            this.lblBloodPressureTitle2.BackColor = System.Drawing.SystemColors.Control;
            this.lblBloodPressureTitle2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBloodPressureTitle2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblBloodPressureTitle2.Location = new System.Drawing.Point(204, 268);
            this.lblBloodPressureTitle2.Name = "lblBloodPressureTitle2";
            this.lblBloodPressureTitle2.Size = new System.Drawing.Size(20, 24);
            this.lblBloodPressureTitle2.TabIndex = 6090;
            this.lblBloodPressureTitle2.Text = "/";
            // 
            // m_txtBloodOxygenSaturation
            // 
            this.m_txtBloodOxygenSaturation.BackColor = System.Drawing.Color.White;
            this.m_txtBloodOxygenSaturation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBloodOxygenSaturation.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBloodOxygenSaturation.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBloodOxygenSaturation.Location = new System.Drawing.Point(140, 292);
            this.m_txtBloodOxygenSaturation.m_BlnIgnoreUserInfo = false;
            this.m_txtBloodOxygenSaturation.m_BlnPartControl = false;
            this.m_txtBloodOxygenSaturation.m_BlnReadOnly = false;
            this.m_txtBloodOxygenSaturation.m_BlnUnderLineDST = false;
            this.m_txtBloodOxygenSaturation.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBloodOxygenSaturation.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBloodOxygenSaturation.m_IntCanModifyTime = 6;
            this.m_txtBloodOxygenSaturation.m_IntPartControlLength = 0;
            this.m_txtBloodOxygenSaturation.m_IntPartControlStartIndex = 0;
            this.m_txtBloodOxygenSaturation.m_StrUserID = "";
            this.m_txtBloodOxygenSaturation.m_StrUserName = "";
            this.m_txtBloodOxygenSaturation.Multiline = false;
            this.m_txtBloodOxygenSaturation.Name = "m_txtBloodOxygenSaturation";
            this.m_txtBloodOxygenSaturation.Size = new System.Drawing.Size(164, 21);
            this.m_txtBloodOxygenSaturation.TabIndex = 7;
            this.m_txtBloodOxygenSaturation.Text = "";
            // 
            // cmdConfirm
            // 
            this.cmdConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdConfirm.DefaultScheme = true;
            this.cmdConfirm.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdConfirm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdConfirm.Hint = "";
            this.cmdConfirm.Location = new System.Drawing.Point(552, 456);
            this.cmdConfirm.Name = "cmdConfirm";
            this.cmdConfirm.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdConfirm.Size = new System.Drawing.Size(72, 32);
            this.cmdConfirm.TabIndex = 14;
            this.cmdConfirm.Text = "确定";
            this.cmdConfirm.Click += new System.EventHandler(this.cmdConfirm_Click);
            // 
            // lblSignTitle
            // 
            this.lblSignTitle.AutoSize = true;
            this.lblSignTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblSignTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSignTitle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblSignTitle.Location = new System.Drawing.Point(368, 464);
            this.lblSignTitle.Name = "lblSignTitle";
            this.lblSignTitle.Size = new System.Drawing.Size(42, 14);
            this.lblSignTitle.TabIndex = 6093;
            this.lblSignTitle.Text = "签名:";
            this.lblSignTitle.Visible = false;
            // 
            // m_lblSign
            // 
            this.m_lblSign.BackColor = System.Drawing.SystemColors.Control;
            this.m_lblSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblSign.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_lblSign.Location = new System.Drawing.Point(424, 464);
            this.m_lblSign.Name = "m_lblSign";
            this.m_lblSign.Size = new System.Drawing.Size(120, 19);
            this.m_lblSign.TabIndex = 6094;
            this.m_lblSign.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lblSign.Visible = false;
            // 
            // m_cmdClose
            // 
            this.m_cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdClose.DefaultScheme = true;
            this.m_cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdClose.Hint = "";
            this.m_cmdClose.Location = new System.Drawing.Point(632, 456);
            this.m_cmdClose.Name = "m_cmdClose";
            this.m_cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClose.Size = new System.Drawing.Size(76, 32);
            this.m_cmdClose.TabIndex = 10001;
            this.m_cmdClose.Text = "取消";
            this.m_cmdClose.Click += new System.EventHandler(this.m_cmdClose_Click);
            // 
            // m_cmdGetDovueData
            // 
            this.m_cmdGetDovueData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdGetDovueData.DefaultScheme = true;
            this.m_cmdGetDovueData.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdGetDovueData.Hint = "";
            this.m_cmdGetDovueData.Location = new System.Drawing.Point(176, 232);
            this.m_cmdGetDovueData.Name = "m_cmdGetDovueData";
            this.m_cmdGetDovueData.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdGetDovueData.Size = new System.Drawing.Size(132, 32);
            this.m_cmdGetDovueData.TabIndex = 10000001;
            this.m_cmdGetDovueData.Text = "监护仪最新结果";
            this.m_cmdGetDovueData.Click += new System.EventHandler(this.m_cmdGetDovueData_Click);
            // 
            // m_cmdGetGEData
            // 
            this.m_cmdGetGEData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdGetGEData.DefaultScheme = true;
            this.m_cmdGetGEData.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdGetGEData.Hint = "";
            this.m_cmdGetGEData.Location = new System.Drawing.Point(176, 232);
            this.m_cmdGetGEData.Name = "m_cmdGetGEData";
            this.m_cmdGetGEData.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdGetGEData.Size = new System.Drawing.Size(132, 32);
            this.m_cmdGetGEData.TabIndex = 10000002;
            this.m_cmdGetGEData.Text = "GE监护仪最新结果";
            this.m_cmdGetGEData.Visible = false;
            this.m_cmdGetGEData.Click += new System.EventHandler(this.m_cmdGetGEData_Click);
            // 
            // lblEmployeeSign
            // 
            this.lblEmployeeSign.AutoSize = true;
            this.lblEmployeeSign.BackColor = System.Drawing.SystemColors.Control;
            this.lblEmployeeSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEmployeeSign.Location = new System.Drawing.Point(16, 460);
            this.lblEmployeeSign.Name = "lblEmployeeSign";
            this.lblEmployeeSign.Size = new System.Drawing.Size(42, 14);
            this.lblEmployeeSign.TabIndex = 12;
            this.lblEmployeeSign.Text = "签名:";
            // 
            // m_lsvEmployee
            // 
            this.m_lsvEmployee.BackColor = System.Drawing.Color.White;
            this.m_lsvEmployee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lsvEmployee.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7});
            this.m_lsvEmployee.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvEmployee.ForeColor = System.Drawing.Color.White;
            this.m_lsvEmployee.FullRowSelect = true;
            this.m_lsvEmployee.GridLines = true;
            this.m_lsvEmployee.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_lsvEmployee.Location = new System.Drawing.Point(80, 356);
            this.m_lsvEmployee.Name = "m_lsvEmployee";
            this.m_lsvEmployee.Size = new System.Drawing.Size(102, 105);
            this.m_lsvEmployee.TabIndex = 10000017;
            this.m_lsvEmployee.UseCompatibleStateImageBehavior = false;
            this.m_lsvEmployee.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Width = 0;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Width = 100;
            // 
            // m_txtSign
            // 
            this.m_txtSign.AccessibleName = "NoDefault";
            this.m_txtSign.BackColor = System.Drawing.Color.White;
            this.m_txtSign.BorderColor = System.Drawing.Color.White;
            this.m_txtSign.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSign.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtSign.Location = new System.Drawing.Point(80, 460);
            this.m_txtSign.Name = "m_txtSign";
            this.m_txtSign.Size = new System.Drawing.Size(100, 21);
            this.m_txtSign.TabIndex = 13;
            // 
            // frmSubWatchItemRecord
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.CancelButton = this.m_cmdClose;
            this.ClientSize = new System.Drawing.Size(718, 499);
            this.Controls.Add(this.lblEmployeeSign);
            this.Controls.Add(this.m_txtSign);
            this.Controls.Add(this.lblSignTitle);
            this.Controls.Add(this.lblBedsideBloodSugarTitle);
            this.Controls.Add(this.lblBloodPressureTitle);
            this.Controls.Add(this.lblBloodOxygenSaturationTitle);
            this.Controls.Add(this.lblBreathTitle);
            this.Controls.Add(this.lblPulseTitle);
            this.Controls.Add(this.lblHeartFrequencyTitle);
            this.Controls.Add(this.lblTemperatureTitle);
            this.Controls.Add(this.lblHeartRhythmTitle);
            this.Controls.Add(this.m_lsvEmployee);
            this.Controls.Add(this.m_cmdGetGEData);
            this.Controls.Add(this.m_cmdGetDovueData);
            this.Controls.Add(this.m_cmdClose);
            this.Controls.Add(this.m_lblSign);
            this.Controls.Add(this.cmdConfirm);
            this.Controls.Add(this.m_txtBedsideBloodSugar);
            this.Controls.Add(this.m_gpbOut);
            this.Controls.Add(this.m_gpbIn);
            this.Controls.Add(this.m_gpbPupil);
            this.Controls.Add(this.m_txtBloodPressureS);
            this.Controls.Add(this.m_txtBloodPressureA);
            this.Controls.Add(this.lblBloodPressureTitle2);
            this.Controls.Add(this.m_txtBloodOxygenSaturation);
            this.Controls.Add(this.m_txtPulse);
            this.Controls.Add(this.m_txtBreath);
            this.Controls.Add(this.m_txtHeartFrequency);
            this.Controls.Add(this.m_txtTemperature);
            this.Controls.Add(this.m_txtHeartRhythm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmSubWatchItemRecord";
            this.Text = "观察项目记录";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmSubWatchItemRecord_Closing);
            this.Load += new System.EventHandler(this.frmSubWatchItemRecord_Load);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_lblGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_dtpGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_txtHeartRhythm, 0);
            this.Controls.SetChildIndex(this.m_txtTemperature, 0);
            this.Controls.SetChildIndex(this.m_txtHeartFrequency, 0);
            this.Controls.SetChildIndex(this.m_txtBreath, 0);
            this.Controls.SetChildIndex(this.m_txtPulse, 0);
            this.Controls.SetChildIndex(this.m_txtBloodOxygenSaturation, 0);
            this.Controls.SetChildIndex(this.lblBloodPressureTitle2, 0);
            this.Controls.SetChildIndex(this.m_txtBloodPressureA, 0);
            this.Controls.SetChildIndex(this.m_txtBloodPressureS, 0);
            this.Controls.SetChildIndex(this.m_gpbPupil, 0);
            this.Controls.SetChildIndex(this.m_gpbIn, 0);
            this.Controls.SetChildIndex(this.m_gpbOut, 0);
            this.Controls.SetChildIndex(this.m_txtBedsideBloodSugar, 0);
            this.Controls.SetChildIndex(this.cmdConfirm, 0);
            this.Controls.SetChildIndex(this.m_lblSign, 0);
            this.Controls.SetChildIndex(this.m_cmdClose, 0);
            this.Controls.SetChildIndex(this.m_cmdGetDovueData, 0);
            this.Controls.SetChildIndex(this.m_cmdGetGEData, 0);
            this.Controls.SetChildIndex(this.m_lsvEmployee, 0);
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
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.lblHeartRhythmTitle, 0);
            this.Controls.SetChildIndex(this.lblTemperatureTitle, 0);
            this.Controls.SetChildIndex(this.lblHeartFrequencyTitle, 0);
            this.Controls.SetChildIndex(this.lblPulseTitle, 0);
            this.Controls.SetChildIndex(this.lblBreathTitle, 0);
            this.Controls.SetChildIndex(this.lblBloodOxygenSaturationTitle, 0);
            this.Controls.SetChildIndex(this.lblBloodPressureTitle, 0);
            this.Controls.SetChildIndex(this.lblBedsideBloodSugarTitle, 0);
            this.Controls.SetChildIndex(this.lblSignTitle, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_txtSign, 0);
            this.Controls.SetChildIndex(this.lblEmployeeSign, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.m_gpbOut.ResumeLayout(false);
            this.m_gpbOut.PerformLayout();
            this.m_gpbIn.ResumeLayout(false);
            this.m_gpbIn.PerformLayout();
            this.m_gpbPupil.ResumeLayout(false);
            this.m_gpbPupil_Echo.ResumeLayout(false);
            this.m_gpbPupil_Echo.PerformLayout();
            this.m_gpbPupil_Size.ResumeLayout(false);
            this.m_gpbPupil_Size.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmSubWatchItemRecord_Load(object sender, System.EventArgs e)
		{
//			m_cmdNewTemplate.Left=cmdConfirm.Left-m_cmdNewTemplate.Width+(cmdConfirm.Right-m_cmdClose.Left);
//			m_cmdNewTemplate.Top=cmdConfirm.Top;
//			m_cmdNewTemplate.Visible=true;

			m_lblSign.Text = MDIParent.OperatorName;
			#region 判断GE监护仪数据接口是否已经打开 Alex 2003-9-15
//			if(MDIParent.m_objGEMonitor != null)
//			{
//				m_cmdGetDovueData.Visible = false;
//				m_cmdGetGEData.Visible = true;
//			}
			#endregion

			this.m_dtpCreateDate.m_EnmVisibleFlag=MDIParent.s_ObjRecordDateTimeInfo.m_enmGetRecordTimeFlag(this.Name);
			this.m_dtpCreateDate.m_mthResetSize();

			m_txtTemperature.Focus();
		}

		/// <summary>
		///  获取当前的特殊病程记录信息
		/// </summary>
		/// <returns></returns>
		public override clsDiseaseTrackInfo m_objGetDiseaseTrackInfo()
		{
			clsWatchItemRecordInfo objTrackInfo = new clsWatchItemRecordInfo();
		
			objTrackInfo.m_ObjRecordContent = m_objCurrentRecordContent;//m_objGetContentFromGUI();
			objTrackInfo.m_DtmRecordTime = m_dtpCreateDate.Value;
			objTrackInfo.m_StrTitle = m_lblForTitle.Text;

			//设置m_strTitle和m_dtmRecordTime
			if(objTrackInfo.m_ObjRecordContent !=null)
			{
//				m_txtRecordTitle.Text=((clsWatchItemRecordContent)m_objCurrentRecordContent).m_strRecordTitle;//objTrackInfo.m_StrTitle;
				m_dtpCreateDate.Value=objTrackInfo.m_ObjRecordContent.m_dtmCreateDate;
			}
		
			return objTrackInfo;
		}

		// 获取选择已经删除记录的窗体标题
		public override string m_strReloadFormTitle()
		{
			return "观察项目记录单";
		}

		/// <summary>
		/// 清空特殊记录信息，并重置记录控制状态为不控制。
		/// </summary>
		protected override void m_mthClearRecordInfo()
		{
			//清空病程记录标题
		
			//清空病程记录标题类型
		
			//清空病程记录的内容
		
			//清空医师签名
			m_lblSign.Text = "";
			m_mthClearUp2();

			m_objSignTool.m_mthSetDefaulEmployee();
		}

		/// <summary>
		/// 删除所有本条记录内容，但不删除统计信息
		/// </summary>
		private void m_mthClearUp2()
		{
			m_txtBloodPressureA.m_mthClearText();
			m_txtBloodPressureS.m_mthClearText();
			m_txtBreath.m_mthClearText();
			m_txtInD.m_mthClearText();
			m_txtInI.m_mthClearText();
			m_txtOutU.m_mthClearText();
			m_txtOutS.m_mthClearText();
			m_txtOutV.m_mthClearText();
			m_txtOutE.m_mthClearText();
			
			m_txtEchoLeft.m_mthClearText();
			m_txtEchoRight.m_mthClearText();
			m_txtPulse.m_mthClearText();
			m_txtPupilLeft.m_mthClearText();
			m_txtPupilRight.m_mthClearText();
			m_txtTemperature.m_mthClearText();	

			m_txtHeartRhythm.m_mthClearText();
			m_txtHeartFrequency.m_mthClearText();
			m_txtBloodOxygenSaturation.m_mthClearText();
			m_txtBedsideBloodSugar.m_mthClearText();
		}
//		private void m_mthClearUpFormInfo()
//		{			
//			m_trvTime.Nodes[0].Nodes.Clear();
//			m_mthClearUp2();
//			m_lblTotalIn.Text="0";
//			m_lblTotalInD.Text="0";
//			m_lblTotalInI.Text="0";
//			m_lblTotalOut.Text="0";
//			m_lblTotalOutE.Text="0";
//			m_lblTotalOutS.Text="0";
//			m_lblTotalOutU.Text="0";
//			m_lblTotalOutV.Text="0";
//		}


		/// <summary>
		/// 控制是否可以选择病人和记录时间列表。在从病程记录窗体调用时需要使用。
		/// </summary>
		/// <param name="p_blnEnable"></param>
		protected override void m_mthEnablePatientSelectSub(bool p_blnEnable)
		{
			if(p_blnEnable==false)
			{
				foreach(Control control in this.Controls)
				{					
					control.Top=control.Top-165;				
				}
			
				cmdConfirm.Visible=true;
				
				this.Size=new Size(this.Size.Width, this.Size.Height-165);
				this.CenterToParent();				
			}
			this.MaximizeBox=false;
		}


		/// <summary>
		/// 是否允许修改特殊记录的记录信息。
		/// </summary>
		/// <param name="p_blnEnable"></param>
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
			//根据ModifyUserID和当前用户，设置修改是否留痕迹。
		}

		/// <summary>
		///  从界面获取特殊记录的值。如果界面值出错，返回null。
		/// </summary>
		/// <returns></returns>
		protected override clsTrackRecordContent m_objGetContentFromGUI()
		{
			//界面参数校验
			if(m_objCurrentPatient==null || m_ObjCurrentEmrPatientSession == null)				
				return null;

			clsSubWatchItemRecordContent objRecordContent = new clsSubWatchItemRecordContent();
            #region 是否可以无痕迹修改
            if (chkModifyWithoutMatk.Checked)
                objRecordContent.m_intMarkStatus = 0;
            else
                objRecordContent.m_intMarkStatus = 1;
            #endregion
			//把界面的值赋到变量。
			objRecordContent.m_strModifyUserID = clsEMRLogin.LoginInfo.m_strEmpNo;
			objRecordContent.m_dtmCreateDate=m_dtpCreateDate.Value;
			objRecordContent.m_strTemperature=m_txtTemperature.m_strGetRightText();
			objRecordContent.m_strTemperatureAll=m_txtTemperature.Text;
			objRecordContent.m_strTemperatureXML=m_txtTemperature.m_strGetXmlText();
			objRecordContent.m_strHeartRhythm=m_txtHeartRhythm.m_strGetRightText();
			objRecordContent.m_strHeartRhythmAll=m_txtHeartRhythm.Text;
			objRecordContent.m_strHeartRhythmXML=m_txtHeartRhythm.m_strGetXmlText();
			objRecordContent.m_strHeartFrequency=m_txtHeartFrequency.m_strGetRightText();
			objRecordContent.m_strHeartFrequencyAll=m_txtHeartFrequency.Text;
			objRecordContent.m_strHeartFrequencyXML=m_txtHeartFrequency.m_strGetXmlText();
			objRecordContent.m_strBloodOxygenSaturation=m_txtBloodOxygenSaturation.m_strGetRightText();
			objRecordContent.m_strBloodOxygenSaturationAll=m_txtBloodOxygenSaturation.Text;
			objRecordContent.m_strBloodOxygenSaturationXML=m_txtBloodOxygenSaturation.m_strGetXmlText();
			objRecordContent.m_strBedsideBloodSugar=m_txtBedsideBloodSugar.m_strGetRightText();
			objRecordContent.m_strBedsideBloodSugarAll=m_txtBedsideBloodSugar.Text;
			objRecordContent.m_strBedsideBloodSugarXML=m_txtBedsideBloodSugar.m_strGetXmlText();
			objRecordContent.m_strBreath=m_txtBreath.m_strGetRightText();
			objRecordContent.m_strBreathAll=m_txtBreath.Text;
			objRecordContent.m_strBreathXML=m_txtBreath.m_strGetXmlText();
			objRecordContent.m_strPulse=m_txtPulse.m_strGetRightText();
			objRecordContent.m_strPulseAll=m_txtPulse.Text;
			objRecordContent.m_strPulseXML=m_txtPulse.m_strGetXmlText();
			objRecordContent.m_strBloodPressureS=m_txtBloodPressureS.m_strGetRightText();
			objRecordContent.m_strBloodPressureSAll=m_txtBloodPressureS.Text;
			objRecordContent.m_strBloodPressureSXML=m_txtBloodPressureS.m_strGetXmlText();
			objRecordContent.m_strBloodPressureA=m_txtBloodPressureA.m_strGetRightText();
			objRecordContent.m_strBloodPressureAAll=m_txtBloodPressureA.Text;
			objRecordContent.m_strBloodPressureAXML=m_txtBloodPressureA.m_strGetXmlText();
			objRecordContent.m_strPupilLeft=m_txtPupilLeft.m_strGetRightText();
			objRecordContent.m_strPupilLeftAll=m_txtPupilLeft.Text;
			objRecordContent.m_strPupilLeftXML=m_txtPupilLeft.m_strGetXmlText();
			objRecordContent.m_strPupilRight=m_txtPupilRight.m_strGetRightText();
			objRecordContent.m_strPupilRightAll=m_txtPupilRight.Text;
			objRecordContent.m_strPupilRightXML=m_txtPupilRight.m_strGetXmlText();
			objRecordContent.m_strEchoLeft=m_txtEchoLeft.m_strGetRightText();
			objRecordContent.m_strEchoLeftAll=m_txtEchoLeft.Text;
			objRecordContent.m_strEchoLeftXML=m_txtEchoLeft.m_strGetXmlText();
			objRecordContent.m_strEchoRight=m_txtEchoRight.m_strGetRightText();
			objRecordContent.m_strEchoRightAll=m_txtEchoRight.Text;
			objRecordContent.m_strEchoRightXML=m_txtEchoRight.m_strGetXmlText();

//			objRecordContent.m_intInD=Convert.ToInt32(m_txtInD.m_strGetRightText());
			try
			{
				if(m_txtInD.m_strGetRightText().Trim()!="")
					int.Parse(m_txtInD.m_strGetRightText().Trim());
				objRecordContent.m_intInD=m_txtInD.m_strGetRightText().Trim()==""? 0:int.Parse(m_txtInD.m_strGetRightText().Trim());
			}
			catch
			{
				m_mthShowErrorMessage(-111);
				return null;
			}
			objRecordContent.m_strInDAll=m_txtInD.Text;
			objRecordContent.m_strInDXML=m_txtInD.m_strGetXmlText();
//			objRecordContent.m_intInI=Convert.ToInt32(m_txtInI.m_strGetRightText());
			try
			{
				if(m_txtInI.m_strGetRightText().Trim()!="")
					int.Parse(m_txtInI.m_strGetRightText().Trim());
				objRecordContent.m_intInI=m_txtInI.m_strGetRightText().Trim()==""? 0:int.Parse(m_txtInI.m_strGetRightText().Trim());
			}			
			catch
			{
				m_mthShowErrorMessage(-112);
				return null;
			}
			objRecordContent.m_strInIAll=m_txtInI.Text;
			objRecordContent.m_strInIXML=m_txtInI.m_strGetXmlText();
//			objRecordContent.m_intOutU=Convert.ToInt32(m_txtOutU.m_strGetRightText());
			try
			{
				if(m_txtOutU.m_strGetRightText().Trim()!="")
					int.Parse(m_txtOutU.m_strGetRightText().Trim());
				objRecordContent.m_intOutU=m_txtOutU.m_strGetRightText().Trim()==""? 0:int.Parse(m_txtOutU.m_strGetRightText().Trim());
			}
			catch
			{
				m_mthShowErrorMessage(-113);
				return null;
			}
			objRecordContent.m_strOutUAll=m_txtOutU.Text;
			objRecordContent.m_strOutUXML=m_txtOutU.m_strGetXmlText();
//			objRecordContent.m_intOutS=Convert.ToInt32(m_txtOutS.m_strGetRightText());
			try
			{
				if(m_txtOutS.m_strGetRightText().Trim()!="")
					int.Parse(m_txtOutS.m_strGetRightText().Trim());
				objRecordContent.m_intOutS=m_txtOutS.m_strGetRightText().Trim()==""? 0:int.Parse(m_txtOutS.m_strGetRightText().Trim());
			}
			catch
			{
				m_mthShowErrorMessage(-114);
				return null;
			}
			objRecordContent.m_strOutSAll=m_txtOutS.Text;
			objRecordContent.m_strOutSXML=m_txtOutS.m_strGetXmlText();
//			objRecordContent.m_intOutV=Convert.ToInt32(m_txtOutV.m_strGetRightText());
			try
			{
				if(m_txtOutV.m_strGetRightText().Trim()!="")
					int.Parse(m_txtOutV.m_strGetRightText().Trim());
				objRecordContent.m_intOutV=m_txtOutV.m_strGetRightText().Trim()==""? 0:int.Parse(m_txtOutV.m_strGetRightText().Trim());
			}
			catch
			{				
				m_mthShowErrorMessage(-115);
				return null;
			}
			objRecordContent.m_strOutVAll=m_txtOutV.Text;
			objRecordContent.m_strOutVXML=m_txtOutV.m_strGetXmlText();
			try
			{
				if(m_txtOutE.m_strGetRightText().Trim()!="")
					int.Parse(m_txtOutE.m_strGetRightText().Trim());
				objRecordContent.m_intOutE=m_txtOutE.m_strGetRightText().Trim()==""? 0:int.Parse(m_txtOutE.m_strGetRightText().Trim());
			}
			catch
			{
				m_mthShowErrorMessage(-116);
				return null;
			}
			objRecordContent.m_strOutEAll=m_txtOutE.Text;
			objRecordContent.m_strOutEXML=m_txtOutE.m_strGetXmlText();

			return objRecordContent;
		}

		private void m_mthShowErrorMessage(int p_intErrorNum)
		{
			switch(p_intErrorNum)
			{
				case -111:
				m_txtInD.Focus();break;
				case -112:
				m_txtInI.Focus();break;
				case -113:
				m_txtOutU.Focus();break;
				case -114:
				m_txtOutS.Focus();break;
				case -115:
				m_txtOutV.Focus();break;
				case -116:
				m_txtOutE.Focus();break;
			}
			clsPublicFunction.ShowInformationMessageBox("出入量只能输入数字！");
		}
		/// <summary>
		/// 把特殊记录的值显示到界面上。
		/// </summary>
		/// <param name="p_objContent"></param>
		protected override void m_mthSetGUIFromContent(clsTrackRecordContent p_objContent)
		{
			clsSubWatchItemRecordContent objContent = (clsSubWatchItemRecordContent)p_objContent;
		
			//把表单值赋值到界面，由子窗体重载实现
			m_mthClearUp2();

			m_txtBloodPressureA.m_mthSetNewText(objContent.m_strBloodPressureAAll,objContent.m_strBloodPressureAXML);	
			m_txtBloodPressureS.m_mthSetNewText(objContent.m_strBloodPressureSAll,objContent.m_strBloodPressureSXML);	
			m_txtBreath.m_mthSetNewText(objContent.m_strBreathAll,objContent.m_strBreathXML);	
			m_txtInD.m_mthSetNewText(objContent.m_strInDAll,objContent.m_strInDXML);	
			m_txtInI.m_mthSetNewText(objContent.m_strInIAll,objContent.m_strInIXML);	
			m_txtOutU.m_mthSetNewText(objContent.m_strOutUAll,objContent.m_strOutUXML);	
			m_txtOutS.m_mthSetNewText(objContent.m_strOutSAll,objContent.m_strOutSXML);	
			m_txtOutV.m_mthSetNewText(objContent.m_strOutVAll,objContent.m_strOutVXML);	
			m_txtOutE.m_mthSetNewText(objContent.m_strOutEAll,objContent.m_strOutEXML);	
			
			m_txtEchoLeft.m_mthSetNewText(objContent.m_strEchoLeftAll,objContent.m_strEchoLeftXML);	
			m_txtEchoRight.m_mthSetNewText(objContent.m_strEchoRightAll,objContent.m_strEchoRightXML);
			m_txtPulse.m_mthSetNewText(objContent.m_strPulseAll,objContent.m_strPulseXML);
			m_txtPupilLeft.m_mthSetNewText(objContent.m_strPupilLeftAll,objContent.m_strPupilLeftXML);	
			m_txtPupilRight.m_mthSetNewText(objContent.m_strPupilRightAll,objContent.m_strPupilRightXML);	
			m_txtTemperature.m_mthSetNewText(objContent.m_strTemperatureAll,objContent.m_strTemperatureXML);	

			m_txtHeartRhythm.m_mthSetNewText(objContent.m_strHeartRhythmAll,objContent.m_strHeartRhythmXML);	
			m_txtHeartFrequency.m_mthSetNewText(objContent.m_strHeartFrequencyAll,objContent.m_strHeartFrequencyXML);	
			m_txtBloodOxygenSaturation.m_mthSetNewText(objContent.m_strBloodOxygenSaturationAll,objContent.m_strBloodOxygenSaturationXML);	
			m_txtBedsideBloodSugar.m_mthSetNewText(objContent.m_strBedsideBloodSugarAll,objContent.m_strBedsideBloodSugarXML);	
		}

		protected override void m_mthSetDeletedGUIFromContent(clsTrackRecordContent p_objContent)
		{
			clsSubWatchItemRecordContent objContent = (clsSubWatchItemRecordContent)p_objContent;
		
			//把表单值赋值到界面，由子窗体重载实现
			m_mthClearUp2();			
			
			m_txtBloodPressureA.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strBloodPressureAAll,objContent.m_strBloodPressureAXML);	
			m_txtBloodPressureS.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strBloodPressureSAll,objContent.m_strBloodPressureSXML);	
			m_txtBreath.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strBreathAll,objContent.m_strBreathXML);	
			m_txtInD.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strInDAll,objContent.m_strInDXML);	
			m_txtInI.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strInIAll,objContent.m_strInIXML);	
			m_txtOutU.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOutUAll,objContent.m_strOutUXML);	
			m_txtOutS.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOutSAll,objContent.m_strOutSXML);	
			m_txtOutV.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOutVAll,objContent.m_strOutVXML);	
			m_txtOutE.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOutEAll,objContent.m_strOutEXML);	
			
			m_txtEchoLeft.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strEchoLeftAll,objContent.m_strEchoLeftXML);	
			m_txtEchoRight.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strEchoRightAll,objContent.m_strEchoRightXML);
			m_txtPulse.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strPulseAll,objContent.m_strPulseXML);
			m_txtPupilLeft.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strPupilLeftAll,objContent.m_strPupilLeftXML);	
			m_txtPupilRight.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strPupilRightAll,objContent.m_strPupilRightXML);	
			m_txtTemperature.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strTemperatureAll,objContent.m_strTemperatureXML);	

			m_txtHeartRhythm.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strHeartRhythmAll,objContent.m_strHeartRhythmXML);	
			m_txtHeartFrequency.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strHeartFrequencyAll,objContent.m_strHeartFrequencyXML);	
			m_txtBloodOxygenSaturation.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strBloodOxygenSaturationAll,objContent.m_strBloodOxygenSaturationXML);	
			m_txtBedsideBloodSugar.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strBedsideBloodSugarAll,objContent.m_strBedsideBloodSugarXML);	
		}

		/// <summary>
		///  获取病程记录的领域层实例
		/// </summary>
		/// <returns></returns>
		protected override clsDiseaseTrackDomain m_objGetDiseaseTrackDomain()
		{
			//获取病程记录的领域层实例，由子窗体重载实现
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.WatchItem);					
		}

		/// <summary>
		///  把选择时间记录内容重新整理为完全正确的内容。
		/// </summary>
		/// <param name="p_objRecordContent"></param>
		protected override void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
		{
			//把选择时间记录内容重新整理为完全正确的内容，由子窗体重载实现。
			clsSubWatchItemRecordContent objContent=(clsSubWatchItemRecordContent)p_objRecordContent;
			//把表单值赋值到界面，由子窗体重载实现
//			m_txtRecordTitle.Text=objContent.m_strRecordTitle;
//			m_cboRecordTitleType.SelectedIndex=objContent.m_intRecordTitleType;	
//			m_txtRecordContent.m_mthClearText();
//			m_txtRecordContent.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strRecordContent,objContent.m_strRecordContentXml);		
		}

		#region 打印
		// 设置打印内容。
		protected override void m_mthSetPrintContent(clsTrackRecordContent p_objContent,
			DateTime p_dtmFirstPrintDate)
		{
			
		}

		// 初始化打印变量
		protected override void m_mthInitPrintTool()
		{
		
		}

		// 释放打印变量
		protected override void m_mthDisposePrintTools()
		{
		
		}

		// 打印页
		/// <summary>
		/// 打印页
		/// </summary>
		/// <param name="p_objPrintPageArg"></param>
		protected override void m_mthPrintPageSub(PrintPageEventArgs p_objPrintPageArg)
		{
		
		}
		#endregion 打印

		private void cmdConfirm_Click(object sender, System.EventArgs e)
		{
			if(m_lngSave()>0)
			{
				this.DialogResult=DialogResult.Yes;
				this.Close();
			}
		}

		private void m_cmdClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void m_cmdGetDovueData_Click(object sender, System.EventArgs e)
		{
			if(m_objBaseCurrentPatient==null)return;

			this.m_txtTemperature.Text="";
			this.m_txtHeartFrequency.Text="";
			this.m_txtPulse.Text="";
			this.m_txtBreath.Text="";
			this.m_txtBloodPressureS.Text="";
			this.m_txtBloodPressureA.Text="";
			this.m_txtBloodOxygenSaturation.Text="";
			this.m_txtBedsideBloodSugar.Text="";

			GetData();

			#region Old
//			this.m_txtTemperature.Text="";
//			this.m_txtHeartFrequency.Text="";
//			this.m_txtPulse.Text="";
//			this.m_txtBreath.Text="";
//			this.m_txtBloodPressureS.Text="";
//			this.m_txtBloodPressureA.Text="";
//			this.m_txtBloodOxygenSaturation.Text="";
//			this.m_txtBedsideBloodSugar.Text="";
//
//			clsTrendDomain objDomain=new clsTrendDomain();
//			string[] strEMFC_IDArr=new string[]{"100","40","40","92","89","90","-1","-1"};//体温，心率，脉搏，呼吸,收缩压，舒张压,-1代表还没有找到的编号
//			string[] strResultArr;
//			long lngRes=objDomain.m_lngGetDocvueResultArr(this.m_objBaseCurrentPatient.m_StrInPatientID,this.m_objBaseCurrentPatient.m_DtmLastInDate,strEMFC_IDArr,m_dtpCreateDate.Value,out strResultArr);
//			if(lngRes<=0)
//			{
//				switch(lngRes)
//				{
//					case (long)(iCareData.enmOperationResult.Not_permission) :
//						m_mthShowNotPermitted();break;
//					case (long)(iCareData.enmOperationResult.DB_Fail) :
//						m_mthShowDBError();break;
//				}
//			}
//			else 
//			{
//				this.m_txtTemperature.Text=strResultArr[0];
//				this.m_txtHeartFrequency.Text=strResultArr[1];
//				this.m_txtPulse.Text=strResultArr[2];
//				this.m_txtBreath.Text=strResultArr[3];
//				this.m_txtBloodPressureS.Text=strResultArr[4];
//				this.m_txtBloodPressureA.Text=strResultArr[5];
//				this.m_txtBloodOxygenSaturation.Text=strResultArr[6];
//				this.m_txtBedsideBloodSugar.Text=strResultArr[7];
//			}
			#endregion Old
		}

		protected override void GetData()
		{
			try
			{
				bool blnIsGE=m_blnCurrApparatus();

				clsCMSData objCMSData=null;
				clsVentilatorData objVentilatorData=null;

				//if(m_strInPatientID==null || m_strInPatientID=="" || m_strInPatientDate==null|| m_strInPatientDate=="")return;
				//获取参数的数组(【HEARTRATE】心律，【PULSERATE】脉搏，【NPB】无创血压，【NPBSYSTOLIC】无创收缩压，【NPB_DIASTOLIC】无创舒张压，【SPO21】血氧饱和度，【TEMP1】体温，【RESPRATE】呼吸频率，【O2CONCENTRATION】，【ENDEXPPRESSURE】，【EXPTIDALVOLUME】，【PEAKPRESSURE】，【BLOODNUM1】)
				string[] strTypeArry=new string[]{"PULSERATE","HEARTRATE","TEMP1","NPBSYSTOLIC","NPB_DIASTOLIC","RESPDETECTNUM","SPO21"};//

				m_mthGetICUDataByTime(m_dtpGetDataTime.Value.ToString(),out objCMSData,out objVentilatorData,strTypeArry);

				if (!blnIsGE)
				{
					if (objCMSData != null)
					{
						//脉搏
						if(objCMSData.m_strPulseRate == null || objCMSData.m_strPulseRate.Trim().Length == 0)
							m_txtPulse.Text = "";
						else
							m_txtPulse.Text = objCMSData.m_strPulseRate.Trim().Substring(0,objCMSData.m_strPulseRate.IndexOf("."));
						
						//心率
						if(objCMSData.m_strHeartRate == null || objCMSData.m_strHeartRate.Trim().Length == 0)
						{
							m_txtHeartFrequency.Text = "";
							m_txtHeartRhythm.Text="";
						}
						else
						{
							m_txtHeartFrequency.Text = objCMSData.m_strHeartRate.Trim().Substring(0,objCMSData.m_strHeartRate.Trim().Length-3);
							m_txtHeartRhythm.Text = objCMSData.m_strHeartRate.Trim().Substring(0,objCMSData.m_strHeartRate.Trim().Length-3);
						}

						//体温
						if(objCMSData.m_strTemp1 == null || objCMSData.m_strTemp1.Trim().Length == 0)
							m_txtTemperature.Text="";
						else
							m_txtTemperature.Text=objCMSData.m_strTemp1.Trim();

						//收缩压
						if(objCMSData.m_strNPBSYSTOLIC == null || objCMSData.m_strNPBSYSTOLIC.Trim().Length == 0)
							m_txtBloodPressureS.Text="";
						else
							m_txtBloodPressureS.Text=objCMSData.m_strNPBSYSTOLIC;

						//舒张压
						if(objCMSData.m_strNPBDIASTOLIC == null || objCMSData.m_strNPBDIASTOLIC.Trim().Length == 0)
							m_txtBloodPressureA.Text="";
						else
							m_txtBloodPressureA.Text=objCMSData.m_strNPBDIASTOLIC;
						
						//呼吸
						if(objCMSData.m_strRespDetectNum == null || objCMSData.m_strRespDetectNum.Trim().Length == 0)
							m_txtBreath.Text="";
						else
							m_txtBreath.Text=objCMSData.m_strRespDetectNum.Trim().Substring(0,objCMSData.m_strRespDetectNum.Trim().IndexOf("."));

						//血氧饱和度
						if(objCMSData.m_strOxygenSatur1 == null || objCMSData.m_strOxygenSatur1.Trim().Length == 0)
							m_txtBloodOxygenSaturation.Text="";
						else
							m_txtBloodOxygenSaturation.Text=objCMSData.m_strOxygenSatur1;

						//m_txtBloodOxygenSaturation

					}
				}
				else
				{
					clsGECMSData objGECMSData=null;
					objGECMSData=m_objICUGESimulateGetData.M_objNumericParam;
					if (objGECMSData==null)
						m_mthGetICUGEDataByTime(m_dtpGetDataTime.Value.ToString(),out objGECMSData);

					if (objGECMSData != null)
					{
						//脉搏
						if(objGECMSData.m_strPluse == null || objGECMSData.m_strPluse.Trim().Length == 0)
							m_txtPulse.Text = "";
						else
							m_txtPulse.Text = objGECMSData.m_strPluse;
						
						//心率
						if(objGECMSData.m_strHR  == null || objGECMSData.m_strHR.Trim().Length == 0)
						{
							m_txtHeartFrequency.Text = "";
							m_txtHeartRhythm.Text="";
						}
						else
						{
							m_txtHeartFrequency.Text = objGECMSData.m_strHR;
							m_txtHeartRhythm.Text=objGECMSData.m_strHR;
						}

						//体温
						if(objGECMSData.m_strTEMP1 == null || objGECMSData.m_strTEMP1.Trim().Length == 0)
							m_txtTemperature.Text="";
						else
							m_txtTemperature.Text=objGECMSData.m_strTEMP1;

						//收缩压
						if(objGECMSData.m_strNBPSystolic == null || objGECMSData.m_strNBPSystolic.Trim().Length == 0)
							m_txtBloodPressureS.Text="";
						else
							m_txtBloodPressureS.Text=objGECMSData.m_strNBPSystolic;

						//舒张压
						if(objGECMSData.m_strNBPDiastolic == null || objGECMSData.m_strNBPDiastolic.Trim().Length == 0)
							m_txtBloodPressureA.Text="";
						else
							m_txtBloodPressureA.Text=objGECMSData.m_strNBPDiastolic;
						
						//呼吸
						if(objGECMSData.m_strRR == null || objGECMSData.m_strRR.Trim().Length == 0)
							m_txtBreath.Text="";
						else
							m_txtBreath.Text=objGECMSData.m_strRR;

						//血氧饱和度
						if(objGECMSData.m_strSpO2 == null || objGECMSData.m_strSpO2.Trim().Length == 0)
							m_txtBloodOxygenSaturation.Text="";
						else
							m_txtBloodOxygenSaturation.Text=objGECMSData.m_strSpO2;

					}
				}
			}
			catch
			{
			}
		}


		#region 获得GE监护仪数据 Alex 2003-9-15

		private void m_cmdGetGEData_Click(object sender, System.EventArgs e)
		{
			GetData();
//			if(m_objBaseCurrentPatient==null)return;
//
//			this.m_txtTemperature.Text="";
//			this.m_txtHeartFrequency.Text="";
//			this.m_txtPulse.Text="";
//			this.m_txtBreath.Text="";
//			this.m_txtBloodPressureS.Text="";
//			this.m_txtBloodPressureA.Text="";
//			this.m_txtBloodOxygenSaturation.Text="";
//
//			this.m_txtHeartFrequency.Text=MDIParent.m_objGEMonitor.m_lngGetBodyParameter(enmMonitorParameter.HR).ToString();
//			this.m_txtPulse.Text=MDIParent.m_objGEMonitor.m_lngGetBodyParameter(enmMonitorParameter.PPR).ToString();
//
//			this.m_txtBloodPressureS.Text=MDIParent.m_objGEMonitor.m_lngGetBodyParameter(enmMonitorParameter.SYSTOLIC).ToString();
//			this.m_txtBloodPressureA.Text=MDIParent.m_objGEMonitor.m_lngGetBodyParameter(enmMonitorParameter.DIASTOLIC).ToString();
//			this.m_txtBloodOxygenSaturation.Text=MDIParent.m_objGEMonitor.m_lngGetBodyParameter(enmMonitorParameter.SAT).ToString();

		}
		#endregion

		private void frmSubWatchItemRecord_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			m_objICUGESimulateGetData.m_mthStopReceiveData();
		}
		#region Jump Control
		protected override void m_mthInitJump(clsJumpControl p_objJump)
		{
			p_objJump=new clsJumpControl(this,
				new Control[]{m_txtTemperature,m_txtHeartRhythm,m_txtPulse,m_txtBreath,m_txtHeartFrequency,m_txtBloodPressureS
								 ,m_txtBloodPressureA,m_txtBloodOxygenSaturation,m_txtBedsideBloodSugar,m_txtPupilLeft,m_txtPupilRight
							 ,m_txtEchoLeft,m_txtEchoRight,m_txtInD,m_txtInI,m_txtOutU,m_txtOutS,m_txtOutE,m_txtOutV,m_txtSign},Keys.Enter);
		}
		#endregion

	}
}

