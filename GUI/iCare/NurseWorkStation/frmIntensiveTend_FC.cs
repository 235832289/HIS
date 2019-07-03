using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using com.digitalwave.Emr.Signature_gui;
using System.Windows.Forms;
using iCareData;
using com.digitalwave.Utility.Controls;
using System.Data;
using HRP;
using iCare.ICU.Espial;
using System.Xml;

namespace iCare 
{
	/// <summary>
	/// frmIntensiveTend_FC 的摘要说明。
	/// </summary>
	public class frmIntensiveTend_FC : frmDiseaseTrackBase
	{
		#region 窗体自定义控件
		private System.Windows.Forms.Label lblSignTitle;
		private System.Windows.Forms.Label m_lblSign;
		private PinkieControls.ButtonXP m_cmdOK;
		private System.Windows.Forms.Label lblBreathTitle;
		private System.Windows.Forms.Label lblBloodPressureTitle;
		private System.Windows.Forms.Label lblTemperatureTitle;
		private System.Windows.Forms.Label lblPulseTitle;
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
		private System.Windows.Forms.GroupBox m_gpbOut;
		private System.Windows.Forms.Label lblOutUTitle;
		private com.digitalwave.controls.ctlRichTextBox m_txtOutS;
		private System.Windows.Forms.Label lblOutSTitle;
		private System.Windows.Forms.Label lblOutVTitle;
		private System.Windows.Forms.Label lblOutETitle;
		private com.digitalwave.controls.ctlRichTextBox m_txtOutV;
		private com.digitalwave.controls.ctlRichTextBox m_txtOutE;
		private com.digitalwave.controls.ctlRichTextBox m_txtOutU;
		private System.Windows.Forms.GroupBox m_gpbInOutTotal;
		private System.Windows.Forms.Label lblTotalOutUTitle;
		private System.Windows.Forms.Label m_lblTotalOutU;
		private System.Windows.Forms.Label lblTotalOutSTitle;
		private System.Windows.Forms.Label m_lblTotalOutS;
		private System.Windows.Forms.Label m_lblTotalOutV;
		private System.Windows.Forms.Label lblTotalOutVTitle;
		private System.Windows.Forms.Label lblTotalOutETitle;
		private System.Windows.Forms.Label m_lblTotalOutE;
		private System.Windows.Forms.Label lblTotalInITitle;
		private System.Windows.Forms.Label m_lblTotalInI;
		private System.Windows.Forms.Label m_lblTotalInD;
		private System.Windows.Forms.Label lblTotalInDTitle;
		private System.Windows.Forms.Label m_lblTotalOut;
		private System.Windows.Forms.Label lblTotalOutTitle;
		private System.Windows.Forms.Label lblTotalInTitle;
		private System.Windows.Forms.Label m_lblTotalIn;
		private System.Windows.Forms.Label lblImportantTitle0;
		private System.Windows.Forms.Label lblImportantTitle1;
		private System.Windows.Forms.Label lblImportantTitle2;
		private System.Windows.Forms.Label lblImportantTitle3;
		private System.Windows.Forms.Label lblImportantTitle4;
		private System.Windows.Forms.Label lblImportantTitle5;
		private System.Windows.Forms.Label lblImportantTitle6;
		private System.Windows.Forms.Label lblImportantTitle7;
		private System.Windows.Forms.GroupBox m_gpbIn;
		private com.digitalwave.controls.ctlRichTextBox m_txtInD;
		private System.Windows.Forms.Label lblInDTitle;
		private com.digitalwave.controls.ctlRichTextBox m_txtInI;
		private System.Windows.Forms.Label lblInITitle;
		private com.digitalwave.controls.ctlRichTextBox m_txtBloodPressureS;
		private com.digitalwave.controls.ctlRichTextBox m_txtTemperature;
		private com.digitalwave.controls.ctlRichTextBox m_txtBloodPressureA;
		private System.Windows.Forms.Label lblBloodPressureTitle2;
		private com.digitalwave.controls.ctlRichTextBox m_txtPulse;
		private com.digitalwave.controls.ctlRichTextBox m_txtBreath;
		private PinkieControls.ButtonXP m_cmdCancel;
		private System.Windows.Forms.Label lblEmployeeSign;
		protected System.Windows.Forms.ListView m_lsvEmployee;
		private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.ComponentModel.IContainer components = null;
		private string strClass;                                    //班次
		private bool blnCreateDateEvent=false;                      //防止记录时间事件发生
		#endregion 窗体自定义控件
		private PinkieControls.ButtonXP m_cmdGetGEData;


		private clsEmployeeSignTool m_objSignTool;
		private System.Windows.Forms.Label lblMind;
        private com.digitalwave.controls.ctlRichTextBox m_txtMind1;
        private ctlComboBox m_cboEchoRight;
        private ctlComboBox m_cboEchoLeft;
        private ctlComboBox m_cboMind;
        private com.digitalwave.controls.ctlRichTextBox m_txtBloodOxygenSaturation;
        private Label label1;
        private PinkieControls.ButtonXP cmdSign;
        //定义签名类
        private clsEmrSignToolCollection m_objSign;
        private TextBox txtSign;
		/// <summary>
		/// 接收数据类
		/// </summary>
		protected clsICUGESimulateGetData m_objICUGESimulateGetData;

		public frmIntensiveTend_FC()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

            m_objSign = new clsEmrSignToolCollection();
            m_objSign.m_mthBindEmployeeSign(cmdSign, txtSign, 2, true, clsEMRLogin.LoginInfo.m_strEmpID);
            
			m_lblSign.Text=MDIParent.OperatorName;
			m_mthSetRichTextBoxAttribInControl(this);

            //m_objSignTool = new clsEmployeeSignTool(m_lsvEmployee);
            //m_objSignTool.m_mthAddControl(m_txtSign);
			m_objICUGESimulateGetData=new clsICUGESimulateGetData(this);
		}
		
		public override int m_IntFormID
		{
			get
			{
				return 86;
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
            this.lblSignTitle = new System.Windows.Forms.Label();
            this.m_lblSign = new System.Windows.Forms.Label();
            this.m_cmdOK = new PinkieControls.ButtonXP();
            this.lblBreathTitle = new System.Windows.Forms.Label();
            this.lblBloodPressureTitle = new System.Windows.Forms.Label();
            this.lblTemperatureTitle = new System.Windows.Forms.Label();
            this.lblPulseTitle = new System.Windows.Forms.Label();
            this.m_gpbPupil = new System.Windows.Forms.GroupBox();
            this.m_gpbPupil_Echo = new System.Windows.Forms.GroupBox();
            this.m_cboEchoRight = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboEchoLeft = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.lblLeft1 = new System.Windows.Forms.Label();
            this.lblRight1 = new System.Windows.Forms.Label();
            this.m_gpbPupil_Size = new System.Windows.Forms.GroupBox();
            this.m_txtPupilLeft = new com.digitalwave.controls.ctlRichTextBox();
            this.lblPupilLeftTitle = new System.Windows.Forms.Label();
            this.m_txtPupilRight = new com.digitalwave.controls.ctlRichTextBox();
            this.lblPupilRightTitle = new System.Windows.Forms.Label();
            this.m_txtEchoLeft = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtEchoRight = new com.digitalwave.controls.ctlRichTextBox();
            this.m_gpbOut = new System.Windows.Forms.GroupBox();
            this.lblOutUTitle = new System.Windows.Forms.Label();
            this.m_txtOutS = new com.digitalwave.controls.ctlRichTextBox();
            this.lblOutSTitle = new System.Windows.Forms.Label();
            this.lblOutVTitle = new System.Windows.Forms.Label();
            this.lblOutETitle = new System.Windows.Forms.Label();
            this.m_txtOutV = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtOutE = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtOutU = new com.digitalwave.controls.ctlRichTextBox();
            this.m_gpbInOutTotal = new System.Windows.Forms.GroupBox();
            this.lblTotalOutUTitle = new System.Windows.Forms.Label();
            this.m_lblTotalOutU = new System.Windows.Forms.Label();
            this.lblTotalOutSTitle = new System.Windows.Forms.Label();
            this.m_lblTotalOutS = new System.Windows.Forms.Label();
            this.m_lblTotalOutV = new System.Windows.Forms.Label();
            this.lblTotalOutVTitle = new System.Windows.Forms.Label();
            this.lblTotalOutETitle = new System.Windows.Forms.Label();
            this.m_lblTotalOutE = new System.Windows.Forms.Label();
            this.lblTotalInITitle = new System.Windows.Forms.Label();
            this.m_lblTotalInI = new System.Windows.Forms.Label();
            this.m_lblTotalInD = new System.Windows.Forms.Label();
            this.lblTotalInDTitle = new System.Windows.Forms.Label();
            this.m_lblTotalOut = new System.Windows.Forms.Label();
            this.lblTotalOutTitle = new System.Windows.Forms.Label();
            this.lblTotalInTitle = new System.Windows.Forms.Label();
            this.m_lblTotalIn = new System.Windows.Forms.Label();
            this.lblImportantTitle0 = new System.Windows.Forms.Label();
            this.lblImportantTitle1 = new System.Windows.Forms.Label();
            this.lblImportantTitle2 = new System.Windows.Forms.Label();
            this.lblImportantTitle3 = new System.Windows.Forms.Label();
            this.lblImportantTitle4 = new System.Windows.Forms.Label();
            this.lblImportantTitle5 = new System.Windows.Forms.Label();
            this.lblImportantTitle6 = new System.Windows.Forms.Label();
            this.lblImportantTitle7 = new System.Windows.Forms.Label();
            this.m_gpbIn = new System.Windows.Forms.GroupBox();
            this.m_txtInD = new com.digitalwave.controls.ctlRichTextBox();
            this.lblInDTitle = new System.Windows.Forms.Label();
            this.m_txtInI = new com.digitalwave.controls.ctlRichTextBox();
            this.lblInITitle = new System.Windows.Forms.Label();
            this.m_txtBloodPressureS = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtTemperature = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtBloodPressureA = new com.digitalwave.controls.ctlRichTextBox();
            this.lblBloodPressureTitle2 = new System.Windows.Forms.Label();
            this.m_txtPulse = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtBreath = new com.digitalwave.controls.ctlRichTextBox();
            this.m_cmdCancel = new PinkieControls.ButtonXP();
            this.lblEmployeeSign = new System.Windows.Forms.Label();
            this.m_lsvEmployee = new System.Windows.Forms.ListView();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.m_cmdGetGEData = new PinkieControls.ButtonXP();
            this.lblMind = new System.Windows.Forms.Label();
            this.m_txtMind1 = new com.digitalwave.controls.ctlRichTextBox();
            this.m_cboMind = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_txtBloodOxygenSaturation = new com.digitalwave.controls.ctlRichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdSign = new PinkieControls.ButtonXP();
            this.txtSign = new System.Windows.Forms.TextBox();
            this.m_pnlNewBase.SuspendLayout();
            this.m_gpbPupil.SuspendLayout();
            this.m_gpbPupil_Echo.SuspendLayout();
            this.m_gpbPupil_Size.SuspendLayout();
            this.m_gpbOut.SuspendLayout();
            this.m_gpbInOutTotal.SuspendLayout();
            this.m_gpbIn.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_trvCreateDate
            // 
            this.m_trvCreateDate.LineColor = System.Drawing.Color.Black;
            this.m_trvCreateDate.Location = new System.Drawing.Point(36, 108);
            this.m_trvCreateDate.Size = new System.Drawing.Size(212, 80);
            // 
            // lblCreateDateTitle
            // 
            this.lblCreateDateTitle.Location = new System.Drawing.Point(268, 148);
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.Location = new System.Drawing.Point(348, 144);
            this.m_dtpCreateDate.evtValueChanged += new System.EventHandler(this.m_dtpCreateDate_evtValueChanged);
            // 
            // m_dtpGetDataTime
            // 
            this.m_dtpGetDataTime.Location = new System.Drawing.Point(348, 168);
            this.m_dtpGetDataTime.Visible = true;
            // 
            // m_lblGetDataTime
            // 
            this.m_lblGetDataTime.Location = new System.Drawing.Point(239, 172);
            this.m_lblGetDataTime.Visible = true;
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(320, 116);
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(444, 116);
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(516, 80);
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(268, 116);
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(392, 116);
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(36, 80);
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(588, 104);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(116, 68);
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(588, 80);
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(84, 76);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblForTitle.Location = new System.Drawing.Point(188, 16);
            this.m_lblForTitle.Size = new System.Drawing.Size(456, 48);
            this.m_lblForTitle.Text = "危 重 护 理 记 录";
            this.m_lblForTitle.Visible = true;
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(569, -34);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            // 
            // lblSignTitle
            // 
            this.lblSignTitle.AutoSize = true;
            this.lblSignTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblSignTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSignTitle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblSignTitle.Location = new System.Drawing.Point(239, 427);
            this.lblSignTitle.Name = "lblSignTitle";
            this.lblSignTitle.Size = new System.Drawing.Size(42, 14);
            this.lblSignTitle.TabIndex = 6083;
            this.lblSignTitle.Text = "签名:";
            this.lblSignTitle.Visible = false;
            this.lblSignTitle.Click += new System.EventHandler(this.lblSignTitle_Click);
            // 
            // m_lblSign
            // 
            this.m_lblSign.BackColor = System.Drawing.SystemColors.Control;
            this.m_lblSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblSign.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_lblSign.Location = new System.Drawing.Point(288, 427);
            this.m_lblSign.Name = "m_lblSign";
            this.m_lblSign.Size = new System.Drawing.Size(100, 19);
            this.m_lblSign.TabIndex = 6082;
            this.m_lblSign.Visible = false;
            this.m_lblSign.Click += new System.EventHandler(this.m_lblSign_Click);
            // 
            // m_cmdOK
            // 
            this.m_cmdOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdOK.DefaultScheme = true;
            this.m_cmdOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdOK.Hint = "";
            this.m_cmdOK.Location = new System.Drawing.Point(584, 419);
            this.m_cmdOK.Name = "m_cmdOK";
            this.m_cmdOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdOK.Size = new System.Drawing.Size(64, 32);
            this.m_cmdOK.TabIndex = 6089;
            this.m_cmdOK.Text = "确定";
            this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
            // 
            // lblBreathTitle
            // 
            this.lblBreathTitle.AutoSize = true;
            this.lblBreathTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblBreathTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBreathTitle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblBreathTitle.Location = new System.Drawing.Point(43, 236);
            this.lblBreathTitle.Name = "lblBreathTitle";
            this.lblBreathTitle.Size = new System.Drawing.Size(91, 14);
            this.lblBreathTitle.TabIndex = 6099;
            this.lblBreathTitle.Text = "呼吸(次/分):";
            // 
            // lblBloodPressureTitle
            // 
            this.lblBloodPressureTitle.AutoSize = true;
            this.lblBloodPressureTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblBloodPressureTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBloodPressureTitle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblBloodPressureTitle.Location = new System.Drawing.Point(47, 264);
            this.lblBloodPressureTitle.Name = "lblBloodPressureTitle";
            this.lblBloodPressureTitle.Size = new System.Drawing.Size(84, 14);
            this.lblBloodPressureTitle.TabIndex = 6100;
            this.lblBloodPressureTitle.Text = "血压(mmHg):";
            // 
            // lblTemperatureTitle
            // 
            this.lblTemperatureTitle.AutoSize = true;
            this.lblTemperatureTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblTemperatureTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTemperatureTitle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblTemperatureTitle.Location = new System.Drawing.Point(63, 204);
            this.lblTemperatureTitle.Name = "lblTemperatureTitle";
            this.lblTemperatureTitle.Size = new System.Drawing.Size(70, 14);
            this.lblTemperatureTitle.TabIndex = 6103;
            this.lblTemperatureTitle.Text = "体温(℃):";
            // 
            // lblPulseTitle
            // 
            this.lblPulseTitle.AutoSize = true;
            this.lblPulseTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblPulseTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPulseTitle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblPulseTitle.Location = new System.Drawing.Point(191, 204);
            this.lblPulseTitle.Name = "lblPulseTitle";
            this.lblPulseTitle.Size = new System.Drawing.Size(91, 14);
            this.lblPulseTitle.TabIndex = 6101;
            this.lblPulseTitle.Text = "脉搏(次/分):";
            // 
            // m_gpbPupil
            // 
            this.m_gpbPupil.BackColor = System.Drawing.SystemColors.Control;
            this.m_gpbPupil.Controls.Add(this.m_gpbPupil_Echo);
            this.m_gpbPupil.Controls.Add(this.m_gpbPupil_Size);
            this.m_gpbPupil.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_gpbPupil.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_gpbPupil.Location = new System.Drawing.Point(363, 196);
            this.m_gpbPupil.Name = "m_gpbPupil";
            this.m_gpbPupil.Size = new System.Drawing.Size(360, 121);
            this.m_gpbPupil.TabIndex = 600;
            this.m_gpbPupil.TabStop = false;
            this.m_gpbPupil.Text = "瞳孔";
            // 
            // m_gpbPupil_Echo
            // 
            this.m_gpbPupil_Echo.BackColor = System.Drawing.SystemColors.Control;
            this.m_gpbPupil_Echo.Controls.Add(this.m_cboEchoRight);
            this.m_gpbPupil_Echo.Controls.Add(this.m_cboEchoLeft);
            this.m_gpbPupil_Echo.Controls.Add(this.lblLeft1);
            this.m_gpbPupil_Echo.Controls.Add(this.lblRight1);
            this.m_gpbPupil_Echo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_gpbPupil_Echo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_gpbPupil_Echo.Location = new System.Drawing.Point(185, 24);
            this.m_gpbPupil_Echo.Name = "m_gpbPupil_Echo";
            this.m_gpbPupil_Echo.Size = new System.Drawing.Size(157, 80);
            this.m_gpbPupil_Echo.TabIndex = 313;
            this.m_gpbPupil_Echo.TabStop = false;
            this.m_gpbPupil_Echo.Text = "反射";
            // 
            // m_cboEchoRight
            // 
            this.m_cboEchoRight.AccessibleDescription = "瞳孔>>反射>>右";
            this.m_cboEchoRight.BackColor = System.Drawing.Color.White;
            this.m_cboEchoRight.BorderColor = System.Drawing.Color.Black;
            this.m_cboEchoRight.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboEchoRight.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboEchoRight.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboEchoRight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboEchoRight.flatFont = new System.Drawing.Font("宋体", 10.5F);
            this.m_cboEchoRight.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_cboEchoRight.ForeColor = System.Drawing.Color.Black;
            this.m_cboEchoRight.ListBackColor = System.Drawing.Color.White;
            this.m_cboEchoRight.ListForeColor = System.Drawing.Color.Black;
            this.m_cboEchoRight.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboEchoRight.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboEchoRight.Location = new System.Drawing.Point(40, 48);
            this.m_cboEchoRight.m_BlnEnableItemEventMenu = true;
            this.m_cboEchoRight.Name = "m_cboEchoRight";
            this.m_cboEchoRight.SelectedIndex = -1;
            this.m_cboEchoRight.SelectedItem = null;
            this.m_cboEchoRight.SelectionStart = 0;
            this.m_cboEchoRight.Size = new System.Drawing.Size(104, 23);
            this.m_cboEchoRight.TabIndex = 10000292;
            this.m_cboEchoRight.TextBackColor = System.Drawing.Color.White;
            this.m_cboEchoRight.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboEchoLeft
            // 
            this.m_cboEchoLeft.AccessibleDescription = "瞳孔>>反射>>左";
            this.m_cboEchoLeft.BackColor = System.Drawing.Color.White;
            this.m_cboEchoLeft.BorderColor = System.Drawing.Color.Black;
            this.m_cboEchoLeft.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboEchoLeft.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboEchoLeft.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboEchoLeft.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboEchoLeft.flatFont = new System.Drawing.Font("宋体", 10.5F);
            this.m_cboEchoLeft.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_cboEchoLeft.ForeColor = System.Drawing.Color.Black;
            this.m_cboEchoLeft.ListBackColor = System.Drawing.Color.White;
            this.m_cboEchoLeft.ListForeColor = System.Drawing.Color.Black;
            this.m_cboEchoLeft.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboEchoLeft.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboEchoLeft.Location = new System.Drawing.Point(40, 19);
            this.m_cboEchoLeft.m_BlnEnableItemEventMenu = true;
            this.m_cboEchoLeft.Name = "m_cboEchoLeft";
            this.m_cboEchoLeft.SelectedIndex = -1;
            this.m_cboEchoLeft.SelectedItem = null;
            this.m_cboEchoLeft.SelectionStart = 0;
            this.m_cboEchoLeft.Size = new System.Drawing.Size(104, 23);
            this.m_cboEchoLeft.TabIndex = 10000292;
            this.m_cboEchoLeft.TextBackColor = System.Drawing.Color.White;
            this.m_cboEchoLeft.TextForeColor = System.Drawing.Color.Black;
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
            this.m_gpbPupil_Size.Size = new System.Drawing.Size(156, 80);
            this.m_gpbPupil_Size.TabIndex = 210;
            this.m_gpbPupil_Size.TabStop = false;
            this.m_gpbPupil_Size.Text = "大小(mm)";
            // 
            // m_txtPupilLeft
            // 
            this.m_txtPupilLeft.AccessibleDescription = "瞳孔>>大小>>左";
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
            this.m_txtPupilLeft.MaxLength = 8000;
            this.m_txtPupilLeft.Multiline = false;
            this.m_txtPupilLeft.Name = "m_txtPupilLeft";
            this.m_txtPupilLeft.Size = new System.Drawing.Size(90, 22);
            this.m_txtPupilLeft.TabIndex = 2100;
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
            this.m_txtPupilRight.AccessibleDescription = "瞳孔>>大小>>右";
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
            this.m_txtPupilRight.MaxLength = 8000;
            this.m_txtPupilRight.Multiline = false;
            this.m_txtPupilRight.Name = "m_txtPupilRight";
            this.m_txtPupilRight.Size = new System.Drawing.Size(88, 22);
            this.m_txtPupilRight.TabIndex = 2200;
            this.m_txtPupilRight.Text = "";
            // 
            // lblPupilRightTitle
            // 
            this.lblPupilRightTitle.AutoSize = true;
            this.lblPupilRightTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblPupilRightTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPupilRightTitle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblPupilRightTitle.Location = new System.Drawing.Point(8, 52);
            this.lblPupilRightTitle.Name = "lblPupilRightTitle";
            this.lblPupilRightTitle.Size = new System.Drawing.Size(32, 16);
            this.lblPupilRightTitle.TabIndex = 507;
            this.lblPupilRightTitle.Text = "右:";
            // 
            // m_txtEchoLeft
            // 
            this.m_txtEchoLeft.AccessibleDescription = "瞳孔>>反射>>左";
            this.m_txtEchoLeft.BackColor = System.Drawing.Color.White;
            this.m_txtEchoLeft.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtEchoLeft.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtEchoLeft.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtEchoLeft.Location = new System.Drawing.Point(580, 113);
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
            this.m_txtEchoLeft.MaxLength = 8000;
            this.m_txtEchoLeft.Multiline = false;
            this.m_txtEchoLeft.Name = "m_txtEchoLeft";
            this.m_txtEchoLeft.Size = new System.Drawing.Size(124, 22);
            this.m_txtEchoLeft.TabIndex = 2300;
            this.m_txtEchoLeft.Text = "";
            this.m_txtEchoLeft.Visible = false;
            // 
            // m_txtEchoRight
            // 
            this.m_txtEchoRight.AccessibleDescription = "瞳孔>>反射>>左";
            this.m_txtEchoRight.BackColor = System.Drawing.Color.White;
            this.m_txtEchoRight.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtEchoRight.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtEchoRight.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtEchoRight.Location = new System.Drawing.Point(580, 136);
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
            this.m_txtEchoRight.MaxLength = 8000;
            this.m_txtEchoRight.Multiline = false;
            this.m_txtEchoRight.Name = "m_txtEchoRight";
            this.m_txtEchoRight.Size = new System.Drawing.Size(124, 22);
            this.m_txtEchoRight.TabIndex = 2400;
            this.m_txtEchoRight.Text = "";
            this.m_txtEchoRight.Visible = false;
            // 
            // m_gpbOut
            // 
            this.m_gpbOut.BackColor = System.Drawing.SystemColors.Control;
            this.m_gpbOut.Controls.Add(this.lblOutUTitle);
            this.m_gpbOut.Controls.Add(this.m_txtOutS);
            this.m_gpbOut.Controls.Add(this.lblOutSTitle);
            this.m_gpbOut.Controls.Add(this.lblOutVTitle);
            this.m_gpbOut.Controls.Add(this.lblOutETitle);
            this.m_gpbOut.Controls.Add(this.m_txtOutV);
            this.m_gpbOut.Controls.Add(this.m_txtOutE);
            this.m_gpbOut.Controls.Add(this.m_txtOutU);
            this.m_gpbOut.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_gpbOut.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_gpbOut.Location = new System.Drawing.Point(296, 323);
            this.m_gpbOut.Name = "m_gpbOut";
            this.m_gpbOut.Size = new System.Drawing.Size(428, 84);
            this.m_gpbOut.TabIndex = 800;
            this.m_gpbOut.TabStop = false;
            this.m_gpbOut.Text = "排出量(ml)";
            // 
            // lblOutUTitle
            // 
            this.lblOutUTitle.AutoSize = true;
            this.lblOutUTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblOutUTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOutUTitle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblOutUTitle.Location = new System.Drawing.Point(12, 20);
            this.lblOutUTitle.Name = "lblOutUTitle";
            this.lblOutUTitle.Size = new System.Drawing.Size(28, 14);
            this.lblOutUTitle.TabIndex = 507;
            this.lblOutUTitle.Text = "尿:";
            // 
            // m_txtOutS
            // 
            this.m_txtOutS.AccessibleDescription = "大便";
            this.m_txtOutS.BackColor = System.Drawing.Color.White;
            this.m_txtOutS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOutS.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtOutS.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOutS.Location = new System.Drawing.Point(64, 56);
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
            this.m_txtOutS.MaxLength = 8000;
            this.m_txtOutS.Multiline = false;
            this.m_txtOutS.Name = "m_txtOutS";
            this.m_txtOutS.Size = new System.Drawing.Size(136, 22);
            this.m_txtOutS.TabIndex = 2900;
            this.m_txtOutS.Text = "";
            // 
            // lblOutSTitle
            // 
            this.lblOutSTitle.AutoSize = true;
            this.lblOutSTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblOutSTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOutSTitle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblOutSTitle.Location = new System.Drawing.Point(12, 56);
            this.lblOutSTitle.Name = "lblOutSTitle";
            this.lblOutSTitle.Size = new System.Drawing.Size(42, 14);
            this.lblOutSTitle.TabIndex = 507;
            this.lblOutSTitle.Text = "大便:";
            // 
            // lblOutVTitle
            // 
            this.lblOutVTitle.AutoSize = true;
            this.lblOutVTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblOutVTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOutVTitle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblOutVTitle.Location = new System.Drawing.Point(212, 20);
            this.lblOutVTitle.Name = "lblOutVTitle";
            this.lblOutVTitle.Size = new System.Drawing.Size(56, 14);
            this.lblOutVTitle.TabIndex = 507;
            this.lblOutVTitle.Text = "呕吐物:";
            // 
            // lblOutETitle
            // 
            this.lblOutETitle.AutoSize = true;
            this.lblOutETitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblOutETitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOutETitle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblOutETitle.Location = new System.Drawing.Point(212, 56);
            this.lblOutETitle.Name = "lblOutETitle";
            this.lblOutETitle.Size = new System.Drawing.Size(56, 14);
            this.lblOutETitle.TabIndex = 507;
            this.lblOutETitle.Text = "引流液:";
            // 
            // m_txtOutV
            // 
            this.m_txtOutV.AccessibleDescription = "呕吐物";
            this.m_txtOutV.BackColor = System.Drawing.Color.White;
            this.m_txtOutV.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOutV.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtOutV.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOutV.Location = new System.Drawing.Point(284, 20);
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
            this.m_txtOutV.MaxLength = 8000;
            this.m_txtOutV.Multiline = false;
            this.m_txtOutV.Name = "m_txtOutV";
            this.m_txtOutV.Size = new System.Drawing.Size(136, 22);
            this.m_txtOutV.TabIndex = 2800;
            this.m_txtOutV.Text = "";
            // 
            // m_txtOutE
            // 
            this.m_txtOutE.AccessibleDescription = "引流液";
            this.m_txtOutE.BackColor = System.Drawing.Color.White;
            this.m_txtOutE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOutE.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtOutE.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOutE.Location = new System.Drawing.Point(284, 56);
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
            this.m_txtOutE.MaxLength = 8000;
            this.m_txtOutE.Multiline = false;
            this.m_txtOutE.Name = "m_txtOutE";
            this.m_txtOutE.Size = new System.Drawing.Size(136, 22);
            this.m_txtOutE.TabIndex = 3000;
            this.m_txtOutE.Text = "";
            // 
            // m_txtOutU
            // 
            this.m_txtOutU.AccessibleDescription = "尿";
            this.m_txtOutU.BackColor = System.Drawing.Color.White;
            this.m_txtOutU.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOutU.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtOutU.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOutU.Location = new System.Drawing.Point(64, 20);
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
            this.m_txtOutU.MaxLength = 8000;
            this.m_txtOutU.Multiline = false;
            this.m_txtOutU.Name = "m_txtOutU";
            this.m_txtOutU.Size = new System.Drawing.Size(136, 22);
            this.m_txtOutU.TabIndex = 2700;
            this.m_txtOutU.Text = "";
            // 
            // m_gpbInOutTotal
            // 
            this.m_gpbInOutTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_gpbInOutTotal.Controls.Add(this.lblTotalOutUTitle);
            this.m_gpbInOutTotal.Controls.Add(this.m_lblTotalOutU);
            this.m_gpbInOutTotal.Controls.Add(this.lblTotalOutSTitle);
            this.m_gpbInOutTotal.Controls.Add(this.m_lblTotalOutS);
            this.m_gpbInOutTotal.Controls.Add(this.m_lblTotalOutV);
            this.m_gpbInOutTotal.Controls.Add(this.lblTotalOutVTitle);
            this.m_gpbInOutTotal.Controls.Add(this.lblTotalOutETitle);
            this.m_gpbInOutTotal.Controls.Add(this.m_lblTotalOutE);
            this.m_gpbInOutTotal.Controls.Add(this.lblTotalInITitle);
            this.m_gpbInOutTotal.Controls.Add(this.m_lblTotalInI);
            this.m_gpbInOutTotal.Controls.Add(this.m_lblTotalInD);
            this.m_gpbInOutTotal.Controls.Add(this.lblTotalInDTitle);
            this.m_gpbInOutTotal.Controls.Add(this.m_lblTotalOut);
            this.m_gpbInOutTotal.Controls.Add(this.lblTotalOutTitle);
            this.m_gpbInOutTotal.Controls.Add(this.lblTotalInTitle);
            this.m_gpbInOutTotal.Controls.Add(this.m_lblTotalIn);
            this.m_gpbInOutTotal.Controls.Add(this.lblImportantTitle0);
            this.m_gpbInOutTotal.Controls.Add(this.lblImportantTitle1);
            this.m_gpbInOutTotal.Controls.Add(this.lblImportantTitle2);
            this.m_gpbInOutTotal.Controls.Add(this.lblImportantTitle3);
            this.m_gpbInOutTotal.Controls.Add(this.lblImportantTitle4);
            this.m_gpbInOutTotal.Controls.Add(this.lblImportantTitle5);
            this.m_gpbInOutTotal.Controls.Add(this.lblImportantTitle6);
            this.m_gpbInOutTotal.Controls.Add(this.lblImportantTitle7);
            this.m_gpbInOutTotal.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_gpbInOutTotal.ForeColor = System.Drawing.SystemColors.Window;
            this.m_gpbInOutTotal.Location = new System.Drawing.Point(8, 136);
            this.m_gpbInOutTotal.Name = "m_gpbInOutTotal";
            this.m_gpbInOutTotal.Size = new System.Drawing.Size(20, 20);
            this.m_gpbInOutTotal.TabIndex = 6098;
            this.m_gpbInOutTotal.TabStop = false;
            this.m_gpbInOutTotal.Text = "统计(ml)------出入量代码:U--尿 S--大便 V--呕吐物 E--引流液 D--进食 I--输液";
            this.m_gpbInOutTotal.Visible = false;
            // 
            // lblTotalOutUTitle
            // 
            this.lblTotalOutUTitle.AutoSize = true;
            this.lblTotalOutUTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblTotalOutUTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalOutUTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblTotalOutUTitle.Location = new System.Drawing.Point(8, 60);
            this.lblTotalOutUTitle.Name = "lblTotalOutUTitle";
            this.lblTotalOutUTitle.Size = new System.Drawing.Size(72, 16);
            this.lblTotalOutUTitle.TabIndex = 520;
            this.lblTotalOutUTitle.Text = "总出量U:";
            // 
            // m_lblTotalOutU
            // 
            this.m_lblTotalOutU.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_lblTotalOutU.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblTotalOutU.ForeColor = System.Drawing.SystemColors.Window;
            this.m_lblTotalOutU.Location = new System.Drawing.Point(84, 60);
            this.m_lblTotalOutU.Name = "m_lblTotalOutU";
            this.m_lblTotalOutU.Size = new System.Drawing.Size(62, 19);
            this.m_lblTotalOutU.TabIndex = 517;
            this.m_lblTotalOutU.Text = "0";
            // 
            // lblTotalOutSTitle
            // 
            this.lblTotalOutSTitle.AutoSize = true;
            this.lblTotalOutSTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblTotalOutSTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalOutSTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblTotalOutSTitle.Location = new System.Drawing.Point(156, 60);
            this.lblTotalOutSTitle.Name = "lblTotalOutSTitle";
            this.lblTotalOutSTitle.Size = new System.Drawing.Size(72, 16);
            this.lblTotalOutSTitle.TabIndex = 518;
            this.lblTotalOutSTitle.Text = "总出量S:";
            // 
            // m_lblTotalOutS
            // 
            this.m_lblTotalOutS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_lblTotalOutS.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblTotalOutS.ForeColor = System.Drawing.SystemColors.Window;
            this.m_lblTotalOutS.Location = new System.Drawing.Point(232, 60);
            this.m_lblTotalOutS.Name = "m_lblTotalOutS";
            this.m_lblTotalOutS.Size = new System.Drawing.Size(62, 19);
            this.m_lblTotalOutS.TabIndex = 523;
            this.m_lblTotalOutS.Text = "0";
            // 
            // m_lblTotalOutV
            // 
            this.m_lblTotalOutV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_lblTotalOutV.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblTotalOutV.ForeColor = System.Drawing.SystemColors.Window;
            this.m_lblTotalOutV.Location = new System.Drawing.Point(380, 60);
            this.m_lblTotalOutV.Name = "m_lblTotalOutV";
            this.m_lblTotalOutV.Size = new System.Drawing.Size(62, 19);
            this.m_lblTotalOutV.TabIndex = 524;
            this.m_lblTotalOutV.Text = "0";
            // 
            // lblTotalOutVTitle
            // 
            this.lblTotalOutVTitle.AutoSize = true;
            this.lblTotalOutVTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblTotalOutVTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalOutVTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblTotalOutVTitle.Location = new System.Drawing.Point(304, 60);
            this.lblTotalOutVTitle.Name = "lblTotalOutVTitle";
            this.lblTotalOutVTitle.Size = new System.Drawing.Size(72, 16);
            this.lblTotalOutVTitle.TabIndex = 521;
            this.lblTotalOutVTitle.Text = "总出量V:";
            // 
            // lblTotalOutETitle
            // 
            this.lblTotalOutETitle.AutoSize = true;
            this.lblTotalOutETitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblTotalOutETitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalOutETitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblTotalOutETitle.Location = new System.Drawing.Point(452, 60);
            this.lblTotalOutETitle.Name = "lblTotalOutETitle";
            this.lblTotalOutETitle.Size = new System.Drawing.Size(72, 16);
            this.lblTotalOutETitle.TabIndex = 522;
            this.lblTotalOutETitle.Text = "总出量E:";
            // 
            // m_lblTotalOutE
            // 
            this.m_lblTotalOutE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_lblTotalOutE.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblTotalOutE.ForeColor = System.Drawing.SystemColors.Window;
            this.m_lblTotalOutE.Location = new System.Drawing.Point(528, 60);
            this.m_lblTotalOutE.Name = "m_lblTotalOutE";
            this.m_lblTotalOutE.Size = new System.Drawing.Size(62, 19);
            this.m_lblTotalOutE.TabIndex = 516;
            this.m_lblTotalOutE.Text = "0";
            // 
            // lblTotalInITitle
            // 
            this.lblTotalInITitle.AutoSize = true;
            this.lblTotalInITitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblTotalInITitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalInITitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblTotalInITitle.Location = new System.Drawing.Point(156, 24);
            this.lblTotalInITitle.Name = "lblTotalInITitle";
            this.lblTotalInITitle.Size = new System.Drawing.Size(72, 16);
            this.lblTotalInITitle.TabIndex = 510;
            this.lblTotalInITitle.Text = "总入量I:";
            // 
            // m_lblTotalInI
            // 
            this.m_lblTotalInI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_lblTotalInI.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblTotalInI.ForeColor = System.Drawing.SystemColors.Window;
            this.m_lblTotalInI.Location = new System.Drawing.Point(232, 24);
            this.m_lblTotalInI.Name = "m_lblTotalInI";
            this.m_lblTotalInI.Size = new System.Drawing.Size(62, 19);
            this.m_lblTotalInI.TabIndex = 511;
            this.m_lblTotalInI.Text = "0";
            // 
            // m_lblTotalInD
            // 
            this.m_lblTotalInD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_lblTotalInD.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblTotalInD.ForeColor = System.Drawing.SystemColors.Window;
            this.m_lblTotalInD.Location = new System.Drawing.Point(84, 24);
            this.m_lblTotalInD.Name = "m_lblTotalInD";
            this.m_lblTotalInD.Size = new System.Drawing.Size(62, 19);
            this.m_lblTotalInD.TabIndex = 508;
            this.m_lblTotalInD.Text = "0";
            // 
            // lblTotalInDTitle
            // 
            this.lblTotalInDTitle.AutoSize = true;
            this.lblTotalInDTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblTotalInDTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalInDTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblTotalInDTitle.Location = new System.Drawing.Point(8, 24);
            this.lblTotalInDTitle.Name = "lblTotalInDTitle";
            this.lblTotalInDTitle.Size = new System.Drawing.Size(72, 16);
            this.lblTotalInDTitle.TabIndex = 509;
            this.lblTotalInDTitle.Text = "总入量D:";
            // 
            // m_lblTotalOut
            // 
            this.m_lblTotalOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_lblTotalOut.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblTotalOut.ForeColor = System.Drawing.SystemColors.Window;
            this.m_lblTotalOut.Location = new System.Drawing.Point(668, 60);
            this.m_lblTotalOut.Name = "m_lblTotalOut";
            this.m_lblTotalOut.Size = new System.Drawing.Size(72, 19);
            this.m_lblTotalOut.TabIndex = 514;
            this.m_lblTotalOut.Text = "0";
            // 
            // lblTotalOutTitle
            // 
            this.lblTotalOutTitle.AutoSize = true;
            this.lblTotalOutTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblTotalOutTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalOutTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblTotalOutTitle.Location = new System.Drawing.Point(600, 60);
            this.lblTotalOutTitle.Name = "lblTotalOutTitle";
            this.lblTotalOutTitle.Size = new System.Drawing.Size(64, 16);
            this.lblTotalOutTitle.TabIndex = 515;
            this.lblTotalOutTitle.Text = "总出量:";
            // 
            // lblTotalInTitle
            // 
            this.lblTotalInTitle.AutoSize = true;
            this.lblTotalInTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblTotalInTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalInTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblTotalInTitle.Location = new System.Drawing.Point(304, 24);
            this.lblTotalInTitle.Name = "lblTotalInTitle";
            this.lblTotalInTitle.Size = new System.Drawing.Size(64, 16);
            this.lblTotalInTitle.TabIndex = 512;
            this.lblTotalInTitle.Text = "总入量:";
            // 
            // m_lblTotalIn
            // 
            this.m_lblTotalIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_lblTotalIn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblTotalIn.ForeColor = System.Drawing.SystemColors.Window;
            this.m_lblTotalIn.Location = new System.Drawing.Point(372, 24);
            this.m_lblTotalIn.Name = "m_lblTotalIn";
            this.m_lblTotalIn.Size = new System.Drawing.Size(70, 19);
            this.m_lblTotalIn.TabIndex = 513;
            this.m_lblTotalIn.Text = "0";
            // 
            // lblImportantTitle0
            // 
            this.lblImportantTitle0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblImportantTitle0.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblImportantTitle0.ForeColor = System.Drawing.Color.Red;
            this.lblImportantTitle0.Location = new System.Drawing.Point(76, 36);
            this.lblImportantTitle0.Name = "lblImportantTitle0";
            this.lblImportantTitle0.Size = new System.Drawing.Size(72, 20);
            this.lblImportantTitle0.TabIndex = 525;
            this.lblImportantTitle0.Text = "=====";
            // 
            // lblImportantTitle1
            // 
            this.lblImportantTitle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblImportantTitle1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblImportantTitle1.ForeColor = System.Drawing.Color.Red;
            this.lblImportantTitle1.Location = new System.Drawing.Point(224, 36);
            this.lblImportantTitle1.Name = "lblImportantTitle1";
            this.lblImportantTitle1.Size = new System.Drawing.Size(72, 20);
            this.lblImportantTitle1.TabIndex = 525;
            this.lblImportantTitle1.Text = "======";
            // 
            // lblImportantTitle2
            // 
            this.lblImportantTitle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblImportantTitle2.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblImportantTitle2.ForeColor = System.Drawing.Color.Red;
            this.lblImportantTitle2.Location = new System.Drawing.Point(368, 36);
            this.lblImportantTitle2.Name = "lblImportantTitle2";
            this.lblImportantTitle2.Size = new System.Drawing.Size(72, 20);
            this.lblImportantTitle2.TabIndex = 525;
            this.lblImportantTitle2.Text = "======";
            // 
            // lblImportantTitle3
            // 
            this.lblImportantTitle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblImportantTitle3.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblImportantTitle3.ForeColor = System.Drawing.Color.Red;
            this.lblImportantTitle3.Location = new System.Drawing.Point(80, 72);
            this.lblImportantTitle3.Name = "lblImportantTitle3";
            this.lblImportantTitle3.Size = new System.Drawing.Size(72, 20);
            this.lblImportantTitle3.TabIndex = 525;
            this.lblImportantTitle3.Text = "======";
            // 
            // lblImportantTitle4
            // 
            this.lblImportantTitle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblImportantTitle4.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblImportantTitle4.ForeColor = System.Drawing.Color.Red;
            this.lblImportantTitle4.Location = new System.Drawing.Point(224, 72);
            this.lblImportantTitle4.Name = "lblImportantTitle4";
            this.lblImportantTitle4.Size = new System.Drawing.Size(72, 20);
            this.lblImportantTitle4.TabIndex = 525;
            this.lblImportantTitle4.Text = "======";
            // 
            // lblImportantTitle5
            // 
            this.lblImportantTitle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblImportantTitle5.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblImportantTitle5.ForeColor = System.Drawing.Color.Red;
            this.lblImportantTitle5.Location = new System.Drawing.Point(368, 72);
            this.lblImportantTitle5.Name = "lblImportantTitle5";
            this.lblImportantTitle5.Size = new System.Drawing.Size(72, 20);
            this.lblImportantTitle5.TabIndex = 525;
            this.lblImportantTitle5.Text = "======";
            // 
            // lblImportantTitle6
            // 
            this.lblImportantTitle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblImportantTitle6.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblImportantTitle6.ForeColor = System.Drawing.Color.Red;
            this.lblImportantTitle6.Location = new System.Drawing.Point(524, 72);
            this.lblImportantTitle6.Name = "lblImportantTitle6";
            this.lblImportantTitle6.Size = new System.Drawing.Size(72, 20);
            this.lblImportantTitle6.TabIndex = 525;
            this.lblImportantTitle6.Text = "======";
            // 
            // lblImportantTitle7
            // 
            this.lblImportantTitle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblImportantTitle7.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblImportantTitle7.ForeColor = System.Drawing.Color.Red;
            this.lblImportantTitle7.Location = new System.Drawing.Point(664, 72);
            this.lblImportantTitle7.Name = "lblImportantTitle7";
            this.lblImportantTitle7.Size = new System.Drawing.Size(72, 20);
            this.lblImportantTitle7.TabIndex = 525;
            this.lblImportantTitle7.Text = "======";
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
            this.m_gpbIn.Location = new System.Drawing.Point(8, 323);
            this.m_gpbIn.Name = "m_gpbIn";
            this.m_gpbIn.Size = new System.Drawing.Size(284, 84);
            this.m_gpbIn.TabIndex = 700;
            this.m_gpbIn.TabStop = false;
            this.m_gpbIn.Text = "摄入量(ml)";
            // 
            // m_txtInD
            // 
            this.m_txtInD.AccessibleDescription = "进食";
            this.m_txtInD.BackColor = System.Drawing.Color.White;
            this.m_txtInD.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtInD.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtInD.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtInD.Location = new System.Drawing.Point(104, 20);
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
            this.m_txtInD.MaxLength = 8000;
            this.m_txtInD.Multiline = false;
            this.m_txtInD.Name = "m_txtInD";
            this.m_txtInD.Size = new System.Drawing.Size(136, 22);
            this.m_txtInD.TabIndex = 2500;
            this.m_txtInD.Text = "";
            // 
            // lblInDTitle
            // 
            this.lblInDTitle.AutoSize = true;
            this.lblInDTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblInDTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInDTitle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblInDTitle.Location = new System.Drawing.Point(52, 20);
            this.lblInDTitle.Name = "lblInDTitle";
            this.lblInDTitle.Size = new System.Drawing.Size(42, 14);
            this.lblInDTitle.TabIndex = 507;
            this.lblInDTitle.Text = "进食:";
            // 
            // m_txtInI
            // 
            this.m_txtInI.AccessibleDescription = "输液";
            this.m_txtInI.BackColor = System.Drawing.Color.White;
            this.m_txtInI.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtInI.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtInI.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtInI.Location = new System.Drawing.Point(104, 56);
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
            this.m_txtInI.MaxLength = 8000;
            this.m_txtInI.Multiline = false;
            this.m_txtInI.Name = "m_txtInI";
            this.m_txtInI.Size = new System.Drawing.Size(136, 22);
            this.m_txtInI.TabIndex = 2600;
            this.m_txtInI.Text = "";
            // 
            // lblInITitle
            // 
            this.lblInITitle.AutoSize = true;
            this.lblInITitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblInITitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInITitle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblInITitle.Location = new System.Drawing.Point(52, 56);
            this.lblInITitle.Name = "lblInITitle";
            this.lblInITitle.Size = new System.Drawing.Size(42, 14);
            this.lblInITitle.TabIndex = 507;
            this.lblInITitle.Text = "输液:";
            // 
            // m_txtBloodPressureS
            // 
            this.m_txtBloodPressureS.AccessibleDescription = "收缩压";
            this.m_txtBloodPressureS.BackColor = System.Drawing.Color.White;
            this.m_txtBloodPressureS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBloodPressureS.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBloodPressureS.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBloodPressureS.Location = new System.Drawing.Point(135, 260);
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
            this.m_txtBloodPressureS.MaxLength = 8000;
            this.m_txtBloodPressureS.Multiline = false;
            this.m_txtBloodPressureS.Name = "m_txtBloodPressureS";
            this.m_txtBloodPressureS.Size = new System.Drawing.Size(76, 22);
            this.m_txtBloodPressureS.TabIndex = 400;
            this.m_txtBloodPressureS.Text = "";
            // 
            // m_txtTemperature
            // 
            this.m_txtTemperature.AccessibleDescription = "体温";
            this.m_txtTemperature.BackColor = System.Drawing.Color.White;
            this.m_txtTemperature.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtTemperature.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtTemperature.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtTemperature.Location = new System.Drawing.Point(135, 204);
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
            this.m_txtTemperature.MaxLength = 8000;
            this.m_txtTemperature.Multiline = false;
            this.m_txtTemperature.Name = "m_txtTemperature";
            this.m_txtTemperature.Size = new System.Drawing.Size(52, 22);
            this.m_txtTemperature.TabIndex = 100;
            this.m_txtTemperature.Text = "";
            // 
            // m_txtBloodPressureA
            // 
            this.m_txtBloodPressureA.AccessibleDescription = "舒张压";
            this.m_txtBloodPressureA.BackColor = System.Drawing.Color.White;
            this.m_txtBloodPressureA.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBloodPressureA.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBloodPressureA.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBloodPressureA.Location = new System.Drawing.Point(231, 260);
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
            this.m_txtBloodPressureA.MaxLength = 8000;
            this.m_txtBloodPressureA.Multiline = false;
            this.m_txtBloodPressureA.Name = "m_txtBloodPressureA";
            this.m_txtBloodPressureA.Size = new System.Drawing.Size(76, 22);
            this.m_txtBloodPressureA.TabIndex = 500;
            this.m_txtBloodPressureA.Text = "";
            // 
            // lblBloodPressureTitle2
            // 
            this.lblBloodPressureTitle2.BackColor = System.Drawing.SystemColors.Control;
            this.lblBloodPressureTitle2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBloodPressureTitle2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblBloodPressureTitle2.Location = new System.Drawing.Point(211, 260);
            this.lblBloodPressureTitle2.Name = "lblBloodPressureTitle2";
            this.lblBloodPressureTitle2.Size = new System.Drawing.Size(20, 24);
            this.lblBloodPressureTitle2.TabIndex = 6102;
            this.lblBloodPressureTitle2.Text = "/";
            // 
            // m_txtPulse
            // 
            this.m_txtPulse.AccessibleDescription = "脉搏";
            this.m_txtPulse.BackColor = System.Drawing.Color.White;
            this.m_txtPulse.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPulse.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtPulse.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPulse.Location = new System.Drawing.Point(283, 204);
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
            this.m_txtPulse.MaxLength = 8000;
            this.m_txtPulse.Multiline = false;
            this.m_txtPulse.Name = "m_txtPulse";
            this.m_txtPulse.Size = new System.Drawing.Size(44, 22);
            this.m_txtPulse.TabIndex = 200;
            this.m_txtPulse.Text = "";
            // 
            // m_txtBreath
            // 
            this.m_txtBreath.AccessibleDescription = "呼吸";
            this.m_txtBreath.BackColor = System.Drawing.Color.White;
            this.m_txtBreath.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBreath.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBreath.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBreath.Location = new System.Drawing.Point(135, 232);
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
            this.m_txtBreath.MaxLength = 8000;
            this.m_txtBreath.Multiline = false;
            this.m_txtBreath.Name = "m_txtBreath";
            this.m_txtBreath.Size = new System.Drawing.Size(52, 22);
            this.m_txtBreath.TabIndex = 300;
            this.m_txtBreath.Text = "";
            // 
            // m_cmdCancel
            // 
            this.m_cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdCancel.DefaultScheme = true;
            this.m_cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdCancel.Hint = "";
            this.m_cmdCancel.Location = new System.Drawing.Point(664, 419);
            this.m_cmdCancel.Name = "m_cmdCancel";
            this.m_cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCancel.Size = new System.Drawing.Size(64, 32);
            this.m_cmdCancel.TabIndex = 6089;
            this.m_cmdCancel.Text = "取消";
            this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
            // 
            // lblEmployeeSign
            // 
            this.lblEmployeeSign.AutoSize = true;
            this.lblEmployeeSign.BackColor = System.Drawing.SystemColors.Control;
            this.lblEmployeeSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEmployeeSign.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblEmployeeSign.Location = new System.Drawing.Point(257, 427);
            this.lblEmployeeSign.Name = "lblEmployeeSign";
            this.lblEmployeeSign.Size = new System.Drawing.Size(42, 14);
            this.lblEmployeeSign.TabIndex = 10000021;
            this.lblEmployeeSign.Text = "签名:";
            this.lblEmployeeSign.Visible = false;
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
            this.m_lsvEmployee.Location = new System.Drawing.Point(72, 313);
            this.m_lsvEmployee.Name = "m_lsvEmployee";
            this.m_lsvEmployee.Size = new System.Drawing.Size(102, 105);
            this.m_lsvEmployee.TabIndex = 10000020;
            this.m_lsvEmployee.UseCompatibleStateImageBehavior = false;
            this.m_lsvEmployee.View = System.Windows.Forms.View.Details;
            this.m_lsvEmployee.Visible = false;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Width = 0;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Width = 100;
            // 
            // m_cmdGetGEData
            // 
            this.m_cmdGetGEData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdGetGEData.DefaultScheme = true;
            this.m_cmdGetGEData.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdGetGEData.Hint = "";
            this.m_cmdGetGEData.Location = new System.Drawing.Point(568, 160);
            this.m_cmdGetGEData.Name = "m_cmdGetGEData";
            this.m_cmdGetGEData.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdGetGEData.Size = new System.Drawing.Size(88, 32);
            this.m_cmdGetGEData.TabIndex = 10000022;
            this.m_cmdGetGEData.Text = "监护仪结果";
            this.m_cmdGetGEData.Click += new System.EventHandler(this.m_cmdGetGEData_Click);
            // 
            // lblMind
            // 
            this.lblMind.AutoSize = true;
            this.lblMind.BackColor = System.Drawing.SystemColors.Control;
            this.lblMind.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMind.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblMind.Location = new System.Drawing.Point(191, 232);
            this.lblMind.Name = "lblMind";
            this.lblMind.Size = new System.Drawing.Size(42, 14);
            this.lblMind.TabIndex = 10000050;
            this.lblMind.Text = "神志:";
            // 
            // m_txtMind1
            // 
            this.m_txtMind1.AccessibleDescription = "神志";
            this.m_txtMind1.BackColor = System.Drawing.Color.White;
            this.m_txtMind1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtMind1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtMind1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtMind1.Location = new System.Drawing.Point(39, 134);
            this.m_txtMind1.m_BlnIgnoreUserInfo = false;
            this.m_txtMind1.m_BlnPartControl = false;
            this.m_txtMind1.m_BlnReadOnly = false;
            this.m_txtMind1.m_BlnUnderLineDST = false;
            this.m_txtMind1.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtMind1.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtMind1.m_IntCanModifyTime = 6;
            this.m_txtMind1.m_IntPartControlLength = 0;
            this.m_txtMind1.m_IntPartControlStartIndex = 0;
            this.m_txtMind1.m_StrUserID = "";
            this.m_txtMind1.m_StrUserName = "";
            this.m_txtMind1.MaxLength = 10;
            this.m_txtMind1.Multiline = false;
            this.m_txtMind1.Name = "m_txtMind1";
            this.m_txtMind1.Size = new System.Drawing.Size(76, 22);
            this.m_txtMind1.TabIndex = 310;
            this.m_txtMind1.Text = "";
            this.m_txtMind1.Visible = false;
            // 
            // m_cboMind
            // 
            this.m_cboMind.AccessibleDescription = "神志";
            this.m_cboMind.BackColor = System.Drawing.Color.White;
            this.m_cboMind.BorderColor = System.Drawing.Color.Black;
            this.m_cboMind.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboMind.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboMind.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboMind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboMind.flatFont = new System.Drawing.Font("宋体", 10.5F);
            this.m_cboMind.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_cboMind.ForeColor = System.Drawing.Color.Black;
            this.m_cboMind.ListBackColor = System.Drawing.Color.White;
            this.m_cboMind.ListForeColor = System.Drawing.Color.Black;
            this.m_cboMind.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboMind.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboMind.Location = new System.Drawing.Point(231, 229);
            this.m_cboMind.m_BlnEnableItemEventMenu = true;
            this.m_cboMind.Name = "m_cboMind";
            this.m_cboMind.SelectedIndex = -1;
            this.m_cboMind.SelectedItem = null;
            this.m_cboMind.SelectionStart = 0;
            this.m_cboMind.Size = new System.Drawing.Size(96, 23);
            this.m_cboMind.TabIndex = 10000292;
            this.m_cboMind.TextBackColor = System.Drawing.Color.White;
            this.m_cboMind.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_txtBloodOxygenSaturation
            // 
            this.m_txtBloodOxygenSaturation.AccessibleDescription = "血氧饱和度";
            this.m_txtBloodOxygenSaturation.BackColor = System.Drawing.Color.White;
            this.m_txtBloodOxygenSaturation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBloodOxygenSaturation.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBloodOxygenSaturation.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBloodOxygenSaturation.Location = new System.Drawing.Point(135, 289);
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
            this.m_txtBloodOxygenSaturation.MaxLength = 8000;
            this.m_txtBloodOxygenSaturation.Multiline = false;
            this.m_txtBloodOxygenSaturation.Name = "m_txtBloodOxygenSaturation";
            this.m_txtBloodOxygenSaturation.Size = new System.Drawing.Size(76, 22);
            this.m_txtBloodOxygenSaturation.TabIndex = 400;
            this.m_txtBloodOxygenSaturation.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(26, 293);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 14);
            this.label1.TabIndex = 6100;
            this.label1.Text = "血氧饱和度(%):";
            // 
            // cmdSign
            // 
            this.cmdSign.AccessibleDescription = "签名";
            this.cmdSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.cmdSign.DefaultScheme = true;
            this.cmdSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdSign.Hint = "";
            this.cmdSign.Location = new System.Drawing.Point(12, 422);
            this.cmdSign.Name = "cmdSign";
            this.cmdSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdSign.Size = new System.Drawing.Size(64, 27);
            this.cmdSign.TabIndex = 6089;
            this.cmdSign.Text = " 签名：";
            // 
            // txtSign
            // 
            this.txtSign.AccessibleDescription = "签名";
            this.txtSign.Location = new System.Drawing.Point(80, 423);
            this.txtSign.Name = "txtSign";
            this.txtSign.Size = new System.Drawing.Size(168, 23);
            this.txtSign.TabIndex = 10000293;
            // 
            // frmIntensiveTend_FC
            // 
            this.AccessibleDescription = "危重护理记录";
            this.CancelButton = this.m_cmdCancel;
            this.ClientSize = new System.Drawing.Size(738, 472);
            this.Controls.Add(this.txtSign);
            this.Controls.Add(this.m_cboMind);
            this.Controls.Add(this.m_txtEchoLeft);
            this.Controls.Add(this.m_txtEchoRight);
            this.Controls.Add(this.lblMind);
            this.Controls.Add(this.m_txtMind1);
            this.Controls.Add(this.m_cmdGetGEData);
            this.Controls.Add(this.lblEmployeeSign);
            this.Controls.Add(this.lblSignTitle);
            this.Controls.Add(this.m_lsvEmployee);
            this.Controls.Add(this.m_lblSign);
            this.Controls.Add(this.m_txtPulse);
            this.Controls.Add(this.lblBreathTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblBloodPressureTitle);
            this.Controls.Add(this.lblTemperatureTitle);
            this.Controls.Add(this.lblPulseTitle);
            this.Controls.Add(this.m_txtBloodOxygenSaturation);
            this.Controls.Add(this.m_txtBloodPressureS);
            this.Controls.Add(this.m_txtTemperature);
            this.Controls.Add(this.m_txtBloodPressureA);
            this.Controls.Add(this.m_txtBreath);
            this.Controls.Add(this.m_gpbPupil);
            this.Controls.Add(this.m_gpbOut);
            this.Controls.Add(this.m_gpbInOutTotal);
            this.Controls.Add(this.m_gpbIn);
            this.Controls.Add(this.lblBloodPressureTitle2);
            this.Controls.Add(this.cmdSign);
            this.Controls.Add(this.m_cmdOK);
            this.Controls.Add(this.m_cmdCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmIntensiveTend_FC";
            this.Text = "危重护理记录";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmIntensiveTend_Closing);
            this.Load += new System.EventHandler(this.frmIntensiveTend_Load);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_lblGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_dtpGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_cmdCancel, 0);
            this.Controls.SetChildIndex(this.m_cmdOK, 0);
            this.Controls.SetChildIndex(this.cmdSign, 0);
            this.Controls.SetChildIndex(this.lblBloodPressureTitle2, 0);
            this.Controls.SetChildIndex(this.m_gpbIn, 0);
            this.Controls.SetChildIndex(this.m_gpbInOutTotal, 0);
            this.Controls.SetChildIndex(this.m_gpbOut, 0);
            this.Controls.SetChildIndex(this.m_gpbPupil, 0);
            this.Controls.SetChildIndex(this.m_txtBreath, 0);
            this.Controls.SetChildIndex(this.m_txtBloodPressureA, 0);
            this.Controls.SetChildIndex(this.m_txtTemperature, 0);
            this.Controls.SetChildIndex(this.m_txtBloodPressureS, 0);
            this.Controls.SetChildIndex(this.m_dtpCreateDate, 0);
            this.Controls.SetChildIndex(this.m_txtBloodOxygenSaturation, 0);
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
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.lblPulseTitle, 0);
            this.Controls.SetChildIndex(this.lblTemperatureTitle, 0);
            this.Controls.SetChildIndex(this.lblBloodPressureTitle, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblBreathTitle, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_txtPulse, 0);
            this.Controls.SetChildIndex(this.m_lblSign, 0);
            this.Controls.SetChildIndex(this.m_lsvEmployee, 0);
            this.Controls.SetChildIndex(this.lblSignTitle, 0);
            this.Controls.SetChildIndex(this.lblEmployeeSign, 0);
            this.Controls.SetChildIndex(this.m_cmdGetGEData, 0);
            this.Controls.SetChildIndex(this.m_txtMind1, 0);
            this.Controls.SetChildIndex(this.lblMind, 0);
            this.Controls.SetChildIndex(this.m_txtEchoRight, 0);
            this.Controls.SetChildIndex(this.m_txtEchoLeft, 0);
            this.Controls.SetChildIndex(this.m_cboMind, 0);
            this.Controls.SetChildIndex(this.txtSign, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.m_gpbPupil.ResumeLayout(false);
            this.m_gpbPupil_Echo.ResumeLayout(false);
            this.m_gpbPupil_Echo.PerformLayout();
            this.m_gpbPupil_Size.ResumeLayout(false);
            this.m_gpbPupil_Size.PerformLayout();
            this.m_gpbOut.ResumeLayout(false);
            this.m_gpbOut.PerformLayout();
            this.m_gpbInOutTotal.ResumeLayout(false);
            this.m_gpbInOutTotal.PerformLayout();
            this.m_gpbIn.ResumeLayout(false);
            this.m_gpbIn.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
		

		public override iCare.clsDiseaseTrackInfo m_objGetDiseaseTrackInfo()
		{
			clsIntensiveRecordInfo objTrackInfo = new clsIntensiveRecordInfo();

			objTrackInfo.m_ObjRecordContent = m_objCurrentRecordContent;//m_objGetContentFromGUI();
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
//			m_txtRecordContent.m_mthClearText();	
            MDIParent.m_mthSetDefaulEmployee(txtSign);
			this.m_txtTemperature.m_mthClearText();
			this.m_txtPulse.m_mthClearText();
			this.m_txtBreath.m_mthClearText();
			this.m_txtBloodPressureS.m_mthClearText();
			this.m_txtBloodPressureA.m_mthClearText();
			this.m_txtInD.m_mthClearText();
			this.m_txtInI.m_mthClearText();
			this.m_txtPupilLeft.m_mthClearText();
			this.m_txtPupilRight.m_mthClearText();
			this.m_txtEchoLeft.m_mthClearText();
			this.m_txtEchoRight.m_mthClearText();
			this.m_txtOutU.m_mthClearText();
			this.m_txtOutV.m_mthClearText();
			this.m_txtOutS.m_mthClearText();
			this.m_txtOutE.m_mthClearText();

			//m_objSignTool.m_mthSetDefaulEmployee();
		}

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
					if(control.Name!="m_dtpCreateDate")
						control.Top=control.Top-165;				
				}
			
				m_cmdOK.Visible=true;
				
				this.Size=new Size(this.Size.Width, this.Size.Height-165);
				this.CenterToParent();	

				lblCreateDateTitle.Left=m_gpbIn.Left;
				lblCreateDateTitle.Top=6;	
				m_dtpCreateDate.Left=lblCreateDateTitle.Right+5;
				m_dtpCreateDate.Top=lblCreateDateTitle.Top;	
				m_lblGetDataTime.Top=lblCreateDateTitle.Top;
				m_lblGetDataTime.Left=m_dtpCreateDate.Right+5;
				m_dtpGetDataTime.Top=m_lblGetDataTime.Top;
				m_dtpGetDataTime.Left=m_lblGetDataTime.Right+5;
				m_cmdGetGEData.Top=m_dtpGetDataTime.Top;
				m_cmdGetGEData.Left=m_dtpGetDataTime.Right+5;
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
			clsIntensiveTendRecordContent1 objContent=(clsIntensiveTendRecordContent1 )p_objContent;
			//把表单值赋值到界面，由子窗体重载实现			
			this.m_mthClearRecordInfo();

			this.m_txtTemperature.m_mthSetNewText(objContent.m_strTemperatureAll,objContent.m_strTemperatureXML);
			this.m_txtPulse.m_mthSetNewText(objContent.m_strPulseAll,objContent.m_strPulseXML);
			this.m_txtBreath.m_mthSetNewText(objContent.m_strBreathAll,objContent.m_strBreathXML);
			//神志
            this.m_cboMind.Text = objContent.m_strMind;
			//this.m_txtMind1.m_mthSetNewText(objContent.m_strMindAll,objContent.m_strMindXML);
			this.m_txtBloodPressureA.m_mthSetNewText(objContent.m_strBloodPressureAAll,objContent.m_strBloodPressureAXML);
			this.m_txtBloodPressureS.m_mthSetNewText(objContent.m_strBloodPressureSAll,objContent.m_strBloodPressureSXML);
			this.m_txtInD.m_mthSetNewText(objContent.m_strInDAll,objContent.m_strInDXML);
			this.m_txtInI.m_mthSetNewText(objContent.m_strInIAll,objContent.m_strInIXML);
			this.m_txtPupilLeft.m_mthSetNewText(objContent.m_strPupilLeftAll,objContent.m_strPupilLeftXML);
			this.m_txtPupilRight.m_mthSetNewText(objContent.m_strPupilRightAll,objContent.m_strPupilRightXML);
            //this.m_txtEchoLeft.m_mthSetNewText(objContent.m_strEchoLeftAll,objContent.m_strEchoLeftXML);
            //this.m_txtEchoRight.m_mthSetNewText(objContent.m_strEchoRightAll,objContent.m_strEchoRightXML);
            this.m_cboEchoLeft.Text = objContent.m_strEchoLeft;
            this.m_cboEchoRight.Text = objContent.m_strEchoRight;
			this.m_txtOutU.m_mthSetNewText(objContent.m_strOutUAll ,objContent.m_strOutUXML);
			this.m_txtOutV.m_mthSetNewText(objContent.m_strOutVAll,objContent.m_strOutVXML);
			this.m_txtOutS.m_mthSetNewText(objContent.m_strOutSAll,objContent.m_strOutSXML);
			this.m_txtOutE.m_mthSetNewText(objContent.m_strOutEAll,objContent.m_strOutEXML);
			strClass=objContent.m_strClass;
            this.m_txtBloodOxygenSaturation.m_mthSetNewText(objContent.m_strBloodOxygenSaturationAll, objContent.m_strBloodOxygenSaturationXML);
//			m_txtRecordContent.m_mthSetNewText(objContent.m_strRecordContent,objContent.m_strRecordContentXml);	
			strClass=objContent.m_strClass;
            m_mthAddSignToTextBoxByEmpNo(new TextBoxBase[] { txtSign, }, new string[] { objContent.m_strCreateUserID }, new bool[] { false });
            
		}

		protected override void m_mthSetDeletedGUIFromContent(iCareData.clsTrackRecordContent p_objContent)
		{
			clsIntensiveTendRecordContent1 objContent=(clsIntensiveTendRecordContent1 )p_objContent;
			//把表单值赋值到界面，由子窗体重载实现			

			this.m_mthClearRecordInfo();
            
//			m_txtRecordContent.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strRecordContent,objContent.m_strRecordContentXml);			
			m_txtTemperature.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strTemperatureAll ,objContent.m_strTemperatureXML);

			this.m_txtPulse.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strPulseAll  ,objContent.m_strPulseXML );
			this.m_txtBreath.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strBreathAll  ,objContent.m_strBreathXML  );
			//神志
            this.m_cboMind.Text = objContent.m_strMind;
			//this.m_txtMind1.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strMindAll,objContent.m_strMindXML);
			this.m_txtBloodPressureA.Text =com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strBloodPressureAAll  ,objContent.m_strBloodPressureAXML );
			this.m_txtBloodPressureS.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strBloodPressureSAll ,objContent.m_strBloodPressureSXML );
			this.m_txtInD.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strInDAll ,objContent.m_strInDXML );
			this.m_txtInI.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strInIAll ,objContent.m_strInIXML );
			
			this.m_txtPupilLeft.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strPupilLeftAll ,objContent.m_strPupilLeftXML);
			this.m_txtPupilRight.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strPupilRightAll ,objContent.m_strPupilRightXML);

            //this.m_txtEchoLeft.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strEchoLeftAll,objContent.m_strEchoLeftXML  );
            //this.m_txtEchoRight.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strEchoRightAll,objContent.m_strEchoRightXML );
            this.m_cboEchoLeft.Text = objContent.m_strEchoLeft;
            this.m_cboEchoRight.Text = objContent.m_strEchoRight;

			this.m_txtOutU.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOutUAll ,objContent.m_strOutUXML);
			this.m_txtOutV.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOutVAll  ,objContent.m_strOutVXML);
			this.m_txtOutS.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOutSAll,objContent.m_strOutSXML);
			this.m_txtOutE.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOutEAll,objContent.m_strOutEXML);
            this.m_txtBloodOxygenSaturation.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strBloodOxygenSaturationAll, objContent.m_strBloodOxygenSaturationXML);

            m_mthAddSignToTextBoxByEmpNo(new TextBoxBase[] { txtSign, }, new string[] { objContent.m_strCreateUserID }, new bool[] { false });
				
            //clsEmployee objEmployee=new clsEmployee(objContent.m_strCreateUserID);
            //if(objEmployee !=null)
            //    m_lblSign.Text=objEmployee.m_StrLastName;
		}

		protected override iCareData.clsTrackRecordContent m_objGetContentFromGUI()
		{
			
			//界面参数校验
			if(m_objCurrentPatient==null || m_ObjCurrentEmrPatientSession == null)				
				return null;

			//从界面获取表单值		
			clsIntensiveTendRecordContent1 objContent=new clsIntensiveTendRecordContent1 ();
			try
			{
                objContent.m_dtmRecordDate = m_dtpCreateDate.Value;
				objContent.m_dtmCreateDate =DateTime.Now;
//				objContent.m_strRecordContent_Right = m_txtRecordContent.m_strGetRightText () ;
//				objContent.m_strRecordContent =m_txtRecordContent.Text ;
//				objContent.m_strRecordContentXml =m_txtRecordContent.m_strGetXmlText ();

				objContent.m_strTemperature=this.m_txtTemperature.m_strGetRightText();
				objContent.m_strTemperatureAll=this.m_txtTemperature.Text;
				objContent.m_strTemperatureXML=this.m_txtTemperature.m_strGetXmlText();
		
				objContent.m_strPulse=this.m_txtPulse.m_strGetRightText();
				objContent.m_strPulseAll=this.m_txtPulse.Text;
				objContent.m_strPulseXML=this.m_txtPulse.m_strGetXmlText();

				objContent.m_strBreath=this.m_txtBreath.m_strGetRightText();
				objContent.m_strBreathAll=this.m_txtBreath.Text;
				objContent.m_strBreathXML=this.m_txtBreath.m_strGetXmlText();
				//神志
                //objContent.m_strMind=this.m_txtMind1.m_strGetRightText();
                //objContent.m_strMindAll=this.m_txtMind1.Text;
                //objContent.m_strMindXML=this.m_txtMind1.m_strGetXmlText();
                objContent.m_strMind = this.m_cboMind.Text.Trim();
            			
				objContent.m_strBloodPressureA=this.m_txtBloodPressureA.m_strGetRightText();
				objContent.m_strBloodPressureAAll=this.m_txtBloodPressureA.Text;
				objContent.m_strBloodPressureAXML=this.m_txtBloodPressureA.m_strGetXmlText();

				objContent.m_strBloodPressureS=this.m_txtBloodPressureS.m_strGetRightText();
				objContent.m_strBloodPressureSAll=this.m_txtBloodPressureS.Text ;
				objContent.m_strBloodPressureSXML=this.m_txtBloodPressureS.m_strGetXmlText();
			
				objContent.m_intInD=m_txtInD.m_strGetRightText()!="" ? int.Parse(m_txtInD.m_strGetRightText()) : 0;
				objContent.m_strInDAll=this.m_txtInD.Text;
				objContent.m_strInDXML=this.m_txtInD.m_strGetXmlText();

				objContent.m_intInI=m_txtInI.m_strGetRightText()!="" ? int.Parse(m_txtInI.m_strGetRightText()) : 0;
				objContent.m_strInIAll=this.m_txtInI.Text;
				objContent.m_strInIXML=this.m_txtInI.m_strGetXmlText();

				objContent.m_strPupilLeft=this.m_txtPupilLeft.m_strGetRightText();
				objContent.m_strPupilLeftAll=this.m_txtPupilLeft.Text;
				objContent.m_strPupilLeftXML=this.m_txtPupilLeft.m_strGetXmlText();

				objContent.m_strPupilRight=this.m_txtPupilRight.m_strGetRightText();
				objContent.m_strPupilRightAll=this.m_txtPupilRight.Text;
				objContent.m_strPupilRightXML=this.m_txtPupilRight.m_strGetXmlText();

                objContent.m_strBloodOxygenSaturation = this.m_txtBloodOxygenSaturation.m_strGetRightText();
                objContent.m_strBloodOxygenSaturationAll = this.m_txtBloodOxygenSaturation.Text;
                objContent.m_strBloodOxygenSaturationXML = this.m_txtBloodOxygenSaturation.m_strGetXmlText();

                //objContent.m_strEchoLeft=this.m_txtEchoLeft.m_strGetRightText();
                //objContent.m_strEchoLeftAll=this.m_txtEchoLeft.Text;
                //objContent.m_strEchoLeftXML=this.m_txtEchoLeft.m_strGetXmlText();
			
                //objContent.m_strEchoRight=this.m_txtEchoRight.m_strGetRightText();
                //objContent.m_strEchoRightAll=this.m_txtEchoRight.Text;
                //objContent.m_strEchoRightXML=this.m_txtEchoRight.m_strGetXmlText();
                objContent.m_strEchoLeft = this.m_cboEchoLeft.Text;
                objContent.m_strEchoRight = this.m_cboEchoRight.Text;

				objContent.m_intOutU=m_txtOutU.m_strGetRightText()!="" ? int.Parse(m_txtOutU.m_strGetRightText()) : 0;
				objContent.m_strOutUAll=this.m_txtOutU.Text ;
				objContent.m_strOutUXML=this.m_txtOutU.m_strGetXmlText();
		
				objContent.m_intOutV=m_txtOutV.m_strGetRightText()!="" ? int.Parse(m_txtOutV.m_strGetRightText()) : 0;
				objContent.m_strOutVAll=this.m_txtOutV.Text;
				objContent.m_strOutVXML=this.m_txtOutV.m_strGetXmlText();

				objContent.m_intOutS=m_txtOutS.m_strGetRightText()!="" ? int.Parse(m_txtOutS.m_strGetRightText()) : 0;
				objContent.m_strOutSAll=this.m_txtOutS.Text;
				objContent.m_strOutSXML=this.m_txtOutS.m_strGetXmlText();
		
				objContent.m_intOutE=m_txtOutE.m_strGetRightText()!="" ? int.Parse(m_txtOutE.m_strGetRightText()) : 0;
				objContent.m_strOutEAll=this.m_txtOutE.Text;
				objContent.m_strOutEXML=this.m_txtOutE.m_strGetXmlText();

				//获取班次
				objContent.m_strClass=GetClassWith(m_dtpCreateDate.Value);
                //获取签名
                strUserIDList = "";
                strUserNameList = "";
                m_mthGetSignArr(new Control[] { txtSign }, ref objContent.objSignerArr, ref strUserIDList, ref strUserNameList);
                objContent.m_strCreateUserID = ((clsEmrEmployeeBase_VO)txtSign.Tag).m_strEMPNO_CHR;
                objContent.m_dtmModifyDate = DateTime.Now;
                objContent.m_strModifyUserID = ((clsEmrEmployeeBase_VO)txtSign.Tag).m_strEMPNO_CHR; ;
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
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.IntensiveTend);					
		}

		/// <summary>
		/// 把选择时间记录内容重新整理为完全正确的内容。
		/// </summary>
		/// <param name="p_objRecordContent"></param>
		protected override void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
		{
			//把选择时间记录内容重新整理为完全正确的内容，由子窗体重载实现。
			clsIntensiveTendRecordContent1 objContent=(clsIntensiveTendRecordContent1)p_objRecordContent;
			//把表单值赋值到界面，由子窗体重载实现
//			m_txtRecordContent.m_mthClearText();
//			m_txtRecordContent.Text=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContent.m_strRecordContent,objContent.m_strRecordContentXml);		
			
		}

		public override string m_strReloadFormTitle()
		{
			//由子窗体重载实现

			return	"危重护理记录";
		}

		private void frmIntensiveTend_Load(object sender, System.EventArgs e)
		{
			//			m_cmdNewTemplate.Left=m_cmdOK.Left-m_cmdNewTemplate.Width+(m_cmdOK.Right-m_cmdCancel.Left);
			//			m_cmdNewTemplate.Top=m_cmdOK.Top;
			//			m_cmdNewTemplate.Visible=true;	
			this.m_dtpCreateDate.m_EnmVisibleFlag=MDIParent.s_ObjRecordDateTimeInfo.m_enmGetRecordTimeFlag(this.Name);
			this.m_dtpCreateDate.m_mthResetSize();

//			if (m_BlnIsAddNew==true)
//			{
//				//获取班次记录病程记录
//				string strTempClass=GetClass();
//				strClass=strTempClass;
//				string strTempRecordConment,strTempRecordConmentXML;
//				com.digitalwave.IntensiveTendRecordService.clsIntensiveTendRecordService obj=new com.digitalwave.IntensiveTendRecordService.clsIntensiveTendRecordService();
//				
//				long lngRes=obj.m_lngGetRecordContentWithSame(strTempClass,MDIParent.s_ObjCurrentPatient.m_StrInPatientID,out strTempRecordConment,out strTempRecordConmentXML);
//				if (lngRes>0)
//				{
//					this.m_txtRecordContent.m_mthSetNewText(strTempRecordConment,strTempRecordConmentXML);			
//				}
//			}
			blnCreateDateEvent=true;
			m_txtTemperature.Focus();
		}

		#region 打印
		/// <summary>
		///  设置打印内容。
		/// </summary>
		/// <param name="p_objContent"></param>
		protected override void m_mthSetPrintContent(clsTrackRecordContent p_objContent,DateTime p_dtmFirstPrintDate)
		{
			//缺省不做任何动作，子窗体重载以提供操作。
		}

		/// <summary>
		/// 初始化打印变量
		/// </summary>
		protected override void m_mthInitPrintTool()
		{
			//缺省不做任何动作，子窗体重载以提供操作
			//初始化内容包括所有打印使用到的变量：字体、画笔、画刷、打印类等。
		}

		/// <summary>
		/// 释放打印变量
		/// </summary>
		protected override void m_mthDisposePrintTools()
		{
			//缺省不做任何动作，子窗体重载以提供操作
			//释放内容包括打印使用到的字体、画笔、画刷等使用系统资源的变量。
		}

		/// <summary>
		/// 开始打印。
		/// </summary>
		protected override void m_mthStartPrint()
		{
			//缺省使用打印预览，子窗体重载提供新的实现
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

		/// <summary>
		/// 打印开始后，在打印页之前的操作
		/// </summary>
		/// <param name="p_objPrintArg"></param>
		protected override void m_mthBeginPrintSub(PrintEventArgs p_objPrintArg)
		{
			//缺省不做任何动作，子窗体重载以提供操作
		}

		/// <summary>
		/// 打印页
		/// </summary>
		/// <param name="p_objPrintPageArg"></param>
		protected override void m_mthPrintPageSub(PrintPageEventArgs p_objPrintPageArg)
		{
		
		}

		/// <summary>
		/// 打印结束时的操作
		/// </summary>
		/// <param name="p_objPrintArg"></param>
		protected override void m_mthEndPrintSub(PrintEventArgs p_objPrintArg)
		{
			//由子窗体重载以提供操作
		}
		#endregion 打印

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

		private void lblSignTitle_Click(object sender, System.EventArgs e)
		{
		
		}

		private void m_lblSign_Click(object sender, System.EventArgs e)
		{
		
		}

		#region 获取监护仪数据
		protected override void GetData()
		{
			try
			{
				bool blnIsGE=m_blnCurrApparatus();

				clsCMSData objCMSData=null;
				clsVentilatorData objVentilatorData=null;

				//if(m_strInPatientID==null || m_strInPatientID=="" || m_strInPatientDate==null|| m_strInPatientDate=="")return;
				//获取参数的数组(【HEARTRATE】心律，【PULSERATE】脉搏，【NPB】无创血压，【NPBSYSTOLIC】无创收缩压，【NPB_DIASTOLIC】无创舒张压，【SPO21】血氧饱和度，【TEMP1】体温，【RESPRATE】呼吸频率，【O2CONCENTRATION】，【ENDEXPPRESSURE】，【EXPTIDALVOLUME】，【PEAKPRESSURE】，【BLOODNUM1】)
				string[] strTypeArry=new string[]{"PULSERATE","TEMP1","NPBSYSTOLIC","NPB_DIASTOLIC","RESPDETECTNUM"};//

				m_mthGetICUDataByTime(m_dtpGetDataTime.Value.ToString(),out objCMSData,out objVentilatorData,strTypeArry);

				if (!blnIsGE)
				{
					if (objCMSData != null)
					{
						//脉搏
						if(objCMSData.m_strPulseRate == null || objCMSData.m_strPulseRate.Trim().Length == 0)
							m_txtPulse.Text = "";
						else
							m_txtPulse.Text = objCMSData.m_strPulseRate.Trim().Substring(0,objCMSData.m_strPulseRate.Trim().Length-3);
						
						//心率
						//						if(objCMSData.m_strHeartRate == null || objCMSData.m_strHeartRate.Trim().Length == 0)
						//							m_txtHeartFrequency.Text = "";
						//						else
						//							m_txtHeartFrequency.Text = objCMSData.m_strHeartRate.Trim().Substring(0,objCMSData.m_strHeartRate.Trim().Length-3);

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
							m_txtBreath.Text=objCMSData.m_strRespDetectNum.Trim().Substring(0,objCMSData.m_strRespDetectNum.Trim().Length-3);

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
						
						//						//心率
						//						if(objGECMSData.m_strHR  == null || objGECMSData.m_strHR.Trim().Length == 0)
						//							m_txtHeartFrequency.Text = "";
						//						else
						//							m_txtHeartFrequency.Text = objGECMSData.m_strHR;

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
					}
				}
			}
			catch
			{
			}
		}
		#endregion 获取监护仪数据

		private void m_cmdGetGEData_Click(object sender, System.EventArgs e)
		{
			GetData();
		}

		private void frmIntensiveTend_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			m_objICUGESimulateGetData.m_mthStopReceiveData();
		}

		#region Jump Control
		protected override void m_mthInitJump(clsJumpControl p_objJump)
		{
			p_objJump=new clsJumpControl(this,
				new Control[]{m_txtTemperature,m_txtPulse,m_txtBreath,m_cboMind, m_txtBloodPressureS,m_txtBloodPressureA,m_txtPupilLeft,m_txtPupilRight,m_cboEchoLeft
								 ,m_cboEchoRight,m_txtInD,m_txtInI,m_txtOutU,m_txtOutV,m_txtOutS,m_txtOutE,txtSign},Keys.Enter);
		}
		#endregion

		#region 按班统计方法
		private string GetClass()
		{
            //佛二每天早上8:00统计（全天统计一次，不分班次）--wf20080116
            DateTime dt = DateTime.Now;
            DateTime dtClass = DateTime.Parse(dt.ToString("yyyy-MM-dd HH:mm:00"));
            DateTime dt0 = DateTime.Parse(dtClass.ToString("yyyy-MM-dd 08:00:00"));//每天早8点开始统计
            if (dtClass > dt0)
                return dtClass.ToString("yyyy-MM-dd");
            else
                return dtClass.AddDays(-1).ToString("yyyy-MM-dd");
            #region 屏蔽
            /*
			try
			{
				DateTime dt= DateTime.Now;
				DateTime dtClass= DateTime.Parse(dt.ToString("yyyy-MM-dd HH:mm:00"));
				DateTime dt0=DateTime.Parse(dtClass.ToString("yyyy-MM-dd 00:00:00"));
				DateTime dt1=dt0.AddHours(1);
				DateTime dt2=dt0.AddHours(8);
				DateTime dt3=dt0.AddHours(12);
				DateTime dt4=dt0.AddHours(18);
				DateTime dt5=dt0.AddHours(25);
				if (dtClass>=dt1 && dtClass<=dt2)
					return dt1.ToString("yyyy-MM-dd")+"-3";//下夜班
				else if (dtClass>dt2 && dtClass<=dt3)
					return dt2.ToString("yyyy-MM-dd")+"-0";//白班
				else if (dtClass>dt3 && dtClass<=dt4)
					return dt3.ToString("yyyy-MM-dd")+"-1";//中班
                else if (dtClass>dt4 && dtClass<=dt5)
                    return dt4.ToString("yyyy-MM-dd")+"-2";//上夜班
                else
                    return dtClass.AddDays(-1).ToString("yyyy-MM-dd") + "-3";//零点到一点属于前一天上夜班
			
			}
			catch (Exception exp)
			{
				string strError=exp.Message;
				return "";
			}
             */
            #endregion	
		}
		private string GetClassWith(DateTime dt)
        {
            //佛二每天早上8:00统计（全天统计一次，不分班次）--wf20080116
            DateTime dtClass = DateTime.Parse(dt.ToString("yyyy-MM-dd HH:mm:00"));
            DateTime dt0 = DateTime.Parse(dtClass.ToString("yyyy-MM-dd 08:00:00"));//每天早8点开始统计
            if (dtClass > dt0)
                return dtClass.ToString("yyyy-MM-dd");
            else
                return dtClass.AddDays(-1).ToString("yyyy-MM-dd");
            #region 屏蔽
            /*
			try
			{
				DateTime dtClass= DateTime.Parse(dt.ToString("yyyy-MM-dd HH:mm:00"));
				DateTime dt0=DateTime.Parse(dtClass.ToString("yyyy-MM-dd 00:00:00"));
				DateTime dt1=dt0.AddHours(1);
				DateTime dt2=dt0.AddHours(8);
				DateTime dt3=dt0.AddHours(18);
				DateTime dt4=dt0.AddHours(25);
				DateTime dt5=dt0.AddHours(31);
				if (dtClass>dt1 && dtClass<=dt2)
					return dt1.AddDays(-1).ToString("yyy-MM-dd")+"-2";
				if (dtClass>dt2 && dtClass<=dt3)
					return dt2.ToString("yyy-MM-dd")+"-0";
				if (dtClass>dt3 && dtClass<=dt4)
					return dt3.ToString("yyy-MM-dd")+"-1";
			
			}
			catch (Exception exp)
			{
				string strError=exp.Message;
				return "";
			}
             */
            #endregion
		
		}
		private void m_dtpCreateDate_evtValueChanged(object sender, System.EventArgs e)
		{
//			if (blnCreateDateEvent==false)
//				return;
//			//根据时间获取病程记录
//			strClass=GetClassWith(m_dtpCreateDate.Value);
//			string strTempRecordConment,strTempRecordConmentXML;
//			com.digitalwave.IntensiveTendRecordService.clsIntensiveTendRecordService obj=new com.digitalwave.IntensiveTendRecordService.clsIntensiveTendRecordService();
//			long lngRes=obj.m_lngGetRecordContentWithSame(strClass,MDIParent.s_ObjCurrentPatient.m_StrInPatientID, out strTempRecordConment,out strTempRecordConmentXML);
//			if (lngRes>0)
//			{
//				this.m_txtRecordContent.m_mthClearText();
//				this.m_txtRecordContent.m_mthSetNewText(strTempRecordConment,strTempRecordConmentXML);			
//			}

		
		}
		
		#endregion ;





	}
}
