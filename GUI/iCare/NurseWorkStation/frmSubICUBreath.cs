using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using iCareData;
using com.digitalwave.Emr.Signature_gui;
using System.Windows.Forms;


namespace iCare
{
	public class frmSubICUBreath : iCare.frmDiseaseTrackBase
	{
		#region 窗体自定义控件
		private System.Windows.Forms.Button m_cmdBreathLeft;
		private com.digitalwave.controls.ctlRichTextBox m_txtBreathSoundLeft;
		private com.digitalwave.controls.ctlRichTextBox m_txtBreathSoundRight;
		private com.digitalwave.controls.ctlRichTextBox m_txtMachineMode;
		private System.Windows.Forms.Button m_cmdBreathRight;
		private com.digitalwave.controls.ctlRichTextBox m_txtInLength;
		private com.digitalwave.controls.ctlRichTextBox m_txtGasbagPress;
        private System.Windows.Forms.Label lblBreathSound;
		private System.Windows.Forms.Label m_lblSign;
		private PinkieControls.ButtonXP m_cmdOK;
		private PinkieControls.ButtonXP m_cmdCancel;
		private System.Windows.Forms.Button m_cmdMachineMode;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button m_cmdInLength;
		private System.Windows.Forms.Button m_cmdGasbagPress;
		private System.Windows.Forms.GroupBox groupBox2;
		private com.digitalwave.controls.ctlRichTextBox m_txtPEEP;
		private System.Windows.Forms.Label lblPEEP;
		private com.digitalwave.controls.ctlRichTextBox m_txtPRESSURE_SLOPE;
		private System.Windows.Forms.Label lblPRESSURE_SLOPE;
		private com.digitalwave.controls.ctlRichTextBox m_txtFLOW_TRIGGER;
		private System.Windows.Forms.Label lblFLOW_TRIGGER;
		private com.digitalwave.controls.ctlRichTextBox m_txtBASE_FLOW;
		private System.Windows.Forms.Label lblBASE_FLOW;
		private com.digitalwave.controls.ctlRichTextBox m_txtINSPIRATORY_PRESSURE;
		private System.Windows.Forms.Label lblINSPIRATORY_PRESSURE;
		private com.digitalwave.controls.ctlRichTextBox m_txtINSPIRATORY_TIME;
		private System.Windows.Forms.Label lblINSPIRATORY_TIME;
		private com.digitalwave.controls.ctlRichTextBox m_txtCOMPLIANCE_COMP;
		private System.Windows.Forms.Label lblCOMPLIANCE_COMP;
		private com.digitalwave.controls.ctlRichTextBox m_txtMMV_LEVEL;
		private System.Windows.Forms.Label lblMMV_LEVEL;
		private com.digitalwave.controls.ctlRichTextBox m_txtINSPIRATORY_PAUSE;
		private System.Windows.Forms.Label lblINSPIRATORY_PAUSE;
		private com.digitalwave.controls.ctlRichTextBox m_txtASSIST_SENSITIVITY;
		private System.Windows.Forms.Label lblASSIST_SENSITIVITY;
		private com.digitalwave.controls.ctlRichTextBox m_txtPS;
		private System.Windows.Forms.Label lblPS;
		private com.digitalwave.controls.ctlRichTextBox m_txtO2;
		private System.Windows.Forms.Label lblO2;
		private com.digitalwave.controls.ctlRichTextBox m_txtPEAK_FLOW;
		private System.Windows.Forms.Label lblPEAK_FLOW;
		private com.digitalwave.controls.ctlRichTextBox m_txtRATE;
		private System.Windows.Forms.Label lblRATE;
		private com.digitalwave.controls.ctlRichTextBox m_txtTIDAL_VOLUME;
		private System.Windows.Forms.Label lblTIDAL_VOLUME;
		private System.Windows.Forms.GroupBox groupBox3;
		private com.digitalwave.controls.ctlRichTextBox m_txtPLATEAU;
		private System.Windows.Forms.Label lblPLATEAU;
		private com.digitalwave.controls.ctlRichTextBox m_txtMEAN;
		private System.Windows.Forms.Label lblMEAN;
		private com.digitalwave.controls.ctlRichTextBox m_txtPEAR;
		private System.Windows.Forms.Label lblPEAR;
		private com.digitalwave.controls.ctlRichTextBox m_txtMMV;
		private System.Windows.Forms.Label lblMMV;
		private com.digitalwave.controls.ctlRichTextBox m_txtTi;
		private System.Windows.Forms.Label lblTi;
		private com.digitalwave.controls.ctlRichTextBox m_txtI_E_RATIO;
		private System.Windows.Forms.Label lblI_E_RATIO;
		private com.digitalwave.controls.ctlRichTextBox m_txtSPONT;
		private System.Windows.Forms.Label lblSPONT;
		private com.digitalwave.controls.ctlRichTextBox m_txtTOTAL;
		private System.Windows.Forms.Label lblTOTAL;
		private com.digitalwave.controls.ctlRichTextBox m_txtSPONT_MV;
		private System.Windows.Forms.Label lblSPONT_MV;
		private com.digitalwave.controls.ctlRichTextBox m_txtTOTAL_MV;
		private System.Windows.Forms.Label lblTOTAL_MV;
		private com.digitalwave.controls.ctlRichTextBox m_txtTIDAL_VOL;
		private System.Windows.Forms.Label lblTIDAL_VOL;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblcmH2O;
        private System.Windows.Forms.Label lblcm;
		private System.ComponentModel.IContainer components = null;
		#endregion 窗体自定义控件

        private clsEmployeeSignTool m_objSignTool;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
        private TextBox txtSign;
        private PinkieControls.ButtonXP m_cmbsign;
		private clsCommonUseToolCollection m_objCUTC;
        //定义签名类
        private clsEmrSignToolCollection m_objSign;

		public frmSubICUBreath()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
            //指明护士工作站表单
            intFormType = 2;
            //m_objSignTool = new clsEmployeeSignTool(m_lsvEmployee);
            //m_objSignTool.m_mthAddControl(m_txtSign);

			// TODO: Add any initialization after the InitializeComponent call
			m_lblSign.Text=MDIParent.OperatorName;
			m_mthSetRichTextBoxAttribInControl(this);
			this.m_lblForTitle.Text="中心ICU呼吸机治疗监护记录单";

			m_objCUTC = new clsCommonUseToolCollection(this);
			m_objCUTC.m_mthBindControl(
				new Control[]{m_cmdMachineMode,m_cmdBreathLeft,m_cmdBreathRight,m_cmdInLength,m_cmdGasbagPress},
				new Control[]{m_txtMachineMode,m_txtBreathSoundLeft,m_txtBreathSoundRight,m_txtInLength,m_txtGasbagPress},
				new enmCommonUseValue[]{enmCommonUseValue.MachineMode,enmCommonUseValue.BreathSound,enmCommonUseValue.BreathSound,enmCommonUseValue.InLength,enmCommonUseValue.GasbagPres}
				);
            ////签名常用值
            //m_objCUTC.m_mthBindEmployeeSign(new Control[]{m_cmdSign},
            //    new Control[]{m_txtSign},new int[]{1});

            //签名常用值
            m_objSign = new clsEmrSignToolCollection();

            //可以指定员工ID如
            m_objSign.m_mthBindEmployeeSign(m_cmbsign, txtSign, 2, true, clsEMRLogin.LoginInfo.m_strEmpID);

		}

		clsICUBreathContent m_objICUBreathContent=null;

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
            this.m_cmdBreathLeft = new System.Windows.Forms.Button();
            this.m_txtBreathSoundLeft = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtBreathSoundRight = new com.digitalwave.controls.ctlRichTextBox();
            this.lblBreathSound = new System.Windows.Forms.Label();
            this.m_txtMachineMode = new com.digitalwave.controls.ctlRichTextBox();
            this.m_cmdBreathRight = new System.Windows.Forms.Button();
            this.m_cmdCancel = new PinkieControls.ButtonXP();
            this.m_cmdOK = new PinkieControls.ButtonXP();
            this.m_txtInLength = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtGasbagPress = new com.digitalwave.controls.ctlRichTextBox();
            this.m_lblSign = new System.Windows.Forms.Label();
            this.m_cmdMachineMode = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblcm = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblcmH2O = new System.Windows.Forms.Label();
            this.m_cmdGasbagPress = new System.Windows.Forms.Button();
            this.m_cmdInLength = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.m_txtPEEP = new com.digitalwave.controls.ctlRichTextBox();
            this.lblPEEP = new System.Windows.Forms.Label();
            this.m_txtPRESSURE_SLOPE = new com.digitalwave.controls.ctlRichTextBox();
            this.lblPRESSURE_SLOPE = new System.Windows.Forms.Label();
            this.m_txtFLOW_TRIGGER = new com.digitalwave.controls.ctlRichTextBox();
            this.lblFLOW_TRIGGER = new System.Windows.Forms.Label();
            this.m_txtBASE_FLOW = new com.digitalwave.controls.ctlRichTextBox();
            this.lblBASE_FLOW = new System.Windows.Forms.Label();
            this.m_txtINSPIRATORY_PRESSURE = new com.digitalwave.controls.ctlRichTextBox();
            this.lblINSPIRATORY_PRESSURE = new System.Windows.Forms.Label();
            this.m_txtINSPIRATORY_TIME = new com.digitalwave.controls.ctlRichTextBox();
            this.lblINSPIRATORY_TIME = new System.Windows.Forms.Label();
            this.m_txtCOMPLIANCE_COMP = new com.digitalwave.controls.ctlRichTextBox();
            this.lblCOMPLIANCE_COMP = new System.Windows.Forms.Label();
            this.m_txtMMV_LEVEL = new com.digitalwave.controls.ctlRichTextBox();
            this.lblMMV_LEVEL = new System.Windows.Forms.Label();
            this.m_txtINSPIRATORY_PAUSE = new com.digitalwave.controls.ctlRichTextBox();
            this.lblINSPIRATORY_PAUSE = new System.Windows.Forms.Label();
            this.m_txtASSIST_SENSITIVITY = new com.digitalwave.controls.ctlRichTextBox();
            this.lblASSIST_SENSITIVITY = new System.Windows.Forms.Label();
            this.m_txtPS = new com.digitalwave.controls.ctlRichTextBox();
            this.lblPS = new System.Windows.Forms.Label();
            this.m_txtO2 = new com.digitalwave.controls.ctlRichTextBox();
            this.lblO2 = new System.Windows.Forms.Label();
            this.m_txtPEAK_FLOW = new com.digitalwave.controls.ctlRichTextBox();
            this.lblPEAK_FLOW = new System.Windows.Forms.Label();
            this.m_txtRATE = new com.digitalwave.controls.ctlRichTextBox();
            this.lblRATE = new System.Windows.Forms.Label();
            this.m_txtTIDAL_VOLUME = new com.digitalwave.controls.ctlRichTextBox();
            this.lblTIDAL_VOLUME = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_txtTi = new com.digitalwave.controls.ctlRichTextBox();
            this.lblTi = new System.Windows.Forms.Label();
            this.m_txtI_E_RATIO = new com.digitalwave.controls.ctlRichTextBox();
            this.lblI_E_RATIO = new System.Windows.Forms.Label();
            this.m_txtSPONT = new com.digitalwave.controls.ctlRichTextBox();
            this.lblSPONT = new System.Windows.Forms.Label();
            this.m_txtTOTAL = new com.digitalwave.controls.ctlRichTextBox();
            this.lblTOTAL = new System.Windows.Forms.Label();
            this.m_txtSPONT_MV = new com.digitalwave.controls.ctlRichTextBox();
            this.lblSPONT_MV = new System.Windows.Forms.Label();
            this.m_txtTOTAL_MV = new com.digitalwave.controls.ctlRichTextBox();
            this.lblTOTAL_MV = new System.Windows.Forms.Label();
            this.m_txtTIDAL_VOL = new com.digitalwave.controls.ctlRichTextBox();
            this.lblTIDAL_VOL = new System.Windows.Forms.Label();
            this.lblMMV = new System.Windows.Forms.Label();
            this.m_txtMMV = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtPEAR = new com.digitalwave.controls.ctlRichTextBox();
            this.lblPEAR = new System.Windows.Forms.Label();
            this.m_txtMEAN = new com.digitalwave.controls.ctlRichTextBox();
            this.lblMEAN = new System.Windows.Forms.Label();
            this.m_txtPLATEAU = new com.digitalwave.controls.ctlRichTextBox();
            this.lblPLATEAU = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtSign = new System.Windows.Forms.TextBox();
            this.m_cmbsign = new PinkieControls.ButtonXP();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_trvCreateDate
            // 
            this.m_trvCreateDate.LineColor = System.Drawing.Color.Black;
            this.m_trvCreateDate.Location = new System.Drawing.Point(528, 112);
            this.m_trvCreateDate.Size = new System.Drawing.Size(224, 32);
            // 
            // lblCreateDateTitle
            // 
            this.lblCreateDateTitle.Location = new System.Drawing.Point(12, 140);
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.Location = new System.Drawing.Point(92, 136);
            // 
            // m_dtpGetDataTime
            // 
            this.m_dtpGetDataTime.Location = new System.Drawing.Point(532, 112);
            // 
            // m_lblGetDataTime
            // 
            this.m_lblGetDataTime.Location = new System.Drawing.Point(174, 144);
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Size = new System.Drawing.Size(84, 23);
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Size = new System.Drawing.Size(100, 23);
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Visible = true;
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(543, -27);
            // 
            // m_cmdBreathLeft
            // 
            this.m_cmdBreathLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdBreathLeft.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdBreathLeft.Location = new System.Drawing.Point(88, 28);
            this.m_cmdBreathLeft.Name = "m_cmdBreathLeft";
            this.m_cmdBreathLeft.Size = new System.Drawing.Size(40, 28);
            this.m_cmdBreathLeft.TabIndex = 10000001;
            this.m_cmdBreathLeft.Text = "左:";
            // 
            // m_txtBreathSoundLeft
            // 
            this.m_txtBreathSoundLeft.BackColor = System.Drawing.Color.White;
            this.m_txtBreathSoundLeft.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBreathSoundLeft.ForeColor = System.Drawing.Color.Black;
            this.m_txtBreathSoundLeft.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBreathSoundLeft.Location = new System.Drawing.Point(273, 19);
            this.m_txtBreathSoundLeft.m_BlnIgnoreUserInfo = false;
            this.m_txtBreathSoundLeft.m_BlnPartControl = false;
            this.m_txtBreathSoundLeft.m_BlnReadOnly = false;
            this.m_txtBreathSoundLeft.m_BlnUnderLineDST = false;
            this.m_txtBreathSoundLeft.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBreathSoundLeft.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBreathSoundLeft.m_IntCanModifyTime = 6;
            this.m_txtBreathSoundLeft.m_IntPartControlLength = 0;
            this.m_txtBreathSoundLeft.m_IntPartControlStartIndex = 0;
            this.m_txtBreathSoundLeft.m_StrUserID = "";
            this.m_txtBreathSoundLeft.m_StrUserName = "";
            this.m_txtBreathSoundLeft.Multiline = false;
            this.m_txtBreathSoundLeft.Name = "m_txtBreathSoundLeft";
            this.m_txtBreathSoundLeft.Size = new System.Drawing.Size(72, 21);
            this.m_txtBreathSoundLeft.TabIndex = 10000002;
            this.m_txtBreathSoundLeft.Text = "";
            // 
            // m_txtBreathSoundRight
            // 
            this.m_txtBreathSoundRight.BackColor = System.Drawing.Color.White;
            this.m_txtBreathSoundRight.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBreathSoundRight.ForeColor = System.Drawing.Color.Black;
            this.m_txtBreathSoundRight.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBreathSoundRight.Location = new System.Drawing.Point(382, 19);
            this.m_txtBreathSoundRight.m_BlnIgnoreUserInfo = false;
            this.m_txtBreathSoundRight.m_BlnPartControl = false;
            this.m_txtBreathSoundRight.m_BlnReadOnly = false;
            this.m_txtBreathSoundRight.m_BlnUnderLineDST = false;
            this.m_txtBreathSoundRight.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBreathSoundRight.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBreathSoundRight.m_IntCanModifyTime = 6;
            this.m_txtBreathSoundRight.m_IntPartControlLength = 0;
            this.m_txtBreathSoundRight.m_IntPartControlStartIndex = 0;
            this.m_txtBreathSoundRight.m_StrUserID = "";
            this.m_txtBreathSoundRight.m_StrUserName = "";
            this.m_txtBreathSoundRight.Multiline = false;
            this.m_txtBreathSoundRight.Name = "m_txtBreathSoundRight";
            this.m_txtBreathSoundRight.Size = new System.Drawing.Size(72, 21);
            this.m_txtBreathSoundRight.TabIndex = 10000004;
            this.m_txtBreathSoundRight.Text = "";
            // 
            // lblBreathSound
            // 
            this.lblBreathSound.AutoSize = true;
            this.lblBreathSound.Location = new System.Drawing.Point(184, 20);
            this.lblBreathSound.Name = "lblBreathSound";
            this.lblBreathSound.Size = new System.Drawing.Size(84, 14);
            this.lblBreathSound.TabIndex = 10000006;
            this.lblBreathSound.Text = "呼吸音  左:";
            // 
            // m_txtMachineMode
            // 
            this.m_txtMachineMode.BackColor = System.Drawing.Color.White;
            this.m_txtMachineMode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtMachineMode.ForeColor = System.Drawing.Color.Black;
            this.m_txtMachineMode.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtMachineMode.Location = new System.Drawing.Point(87, 19);
            this.m_txtMachineMode.m_BlnIgnoreUserInfo = false;
            this.m_txtMachineMode.m_BlnPartControl = false;
            this.m_txtMachineMode.m_BlnReadOnly = false;
            this.m_txtMachineMode.m_BlnUnderLineDST = false;
            this.m_txtMachineMode.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtMachineMode.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtMachineMode.m_IntCanModifyTime = 6;
            this.m_txtMachineMode.m_IntPartControlLength = 0;
            this.m_txtMachineMode.m_IntPartControlStartIndex = 0;
            this.m_txtMachineMode.m_StrUserID = "";
            this.m_txtMachineMode.m_StrUserName = "";
            this.m_txtMachineMode.Multiline = false;
            this.m_txtMachineMode.Name = "m_txtMachineMode";
            this.m_txtMachineMode.Size = new System.Drawing.Size(92, 21);
            this.m_txtMachineMode.TabIndex = 10000000;
            this.m_txtMachineMode.Text = "";
            // 
            // m_cmdBreathRight
            // 
            this.m_cmdBreathRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdBreathRight.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdBreathRight.Location = new System.Drawing.Point(128, 28);
            this.m_cmdBreathRight.Name = "m_cmdBreathRight";
            this.m_cmdBreathRight.Size = new System.Drawing.Size(40, 28);
            this.m_cmdBreathRight.TabIndex = 10000003;
            this.m_cmdBreathRight.Text = "右:";
            // 
            // m_cmdCancel
            // 
            this.m_cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdCancel.DefaultScheme = true;
            this.m_cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdCancel.Hint = "";
            this.m_cmdCancel.Location = new System.Drawing.Point(744, 472);
            this.m_cmdCancel.Name = "m_cmdCancel";
            this.m_cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCancel.Size = new System.Drawing.Size(64, 28);
            this.m_cmdCancel.TabIndex = 10000008;
            this.m_cmdCancel.Text = "取消";
            this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
            // 
            // m_cmdOK
            // 
            this.m_cmdOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdOK.DefaultScheme = true;
            this.m_cmdOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdOK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdOK.Hint = "";
            this.m_cmdOK.Location = new System.Drawing.Point(660, 472);
            this.m_cmdOK.Name = "m_cmdOK";
            this.m_cmdOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdOK.Size = new System.Drawing.Size(64, 28);
            this.m_cmdOK.TabIndex = 10000007;
            this.m_cmdOK.Text = "确定";
            this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
            // 
            // m_txtInLength
            // 
            this.m_txtInLength.BackColor = System.Drawing.Color.White;
            this.m_txtInLength.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtInLength.ForeColor = System.Drawing.Color.Black;
            this.m_txtInLength.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtInLength.Location = new System.Drawing.Point(534, 19);
            this.m_txtInLength.m_BlnIgnoreUserInfo = false;
            this.m_txtInLength.m_BlnPartControl = false;
            this.m_txtInLength.m_BlnReadOnly = false;
            this.m_txtInLength.m_BlnUnderLineDST = false;
            this.m_txtInLength.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtInLength.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtInLength.m_IntCanModifyTime = 6;
            this.m_txtInLength.m_IntPartControlLength = 0;
            this.m_txtInLength.m_IntPartControlStartIndex = 0;
            this.m_txtInLength.m_StrUserID = "";
            this.m_txtInLength.m_StrUserName = "";
            this.m_txtInLength.Multiline = false;
            this.m_txtInLength.Name = "m_txtInLength";
            this.m_txtInLength.Size = new System.Drawing.Size(36, 21);
            this.m_txtInLength.TabIndex = 10000009;
            this.m_txtInLength.Text = "";
            // 
            // m_txtGasbagPress
            // 
            this.m_txtGasbagPress.BackColor = System.Drawing.Color.White;
            this.m_txtGasbagPress.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtGasbagPress.ForeColor = System.Drawing.Color.Black;
            this.m_txtGasbagPress.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtGasbagPress.Location = new System.Drawing.Point(675, 19);
            this.m_txtGasbagPress.m_BlnIgnoreUserInfo = false;
            this.m_txtGasbagPress.m_BlnPartControl = false;
            this.m_txtGasbagPress.m_BlnReadOnly = false;
            this.m_txtGasbagPress.m_BlnUnderLineDST = false;
            this.m_txtGasbagPress.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtGasbagPress.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtGasbagPress.m_IntCanModifyTime = 6;
            this.m_txtGasbagPress.m_IntPartControlLength = 0;
            this.m_txtGasbagPress.m_IntPartControlStartIndex = 0;
            this.m_txtGasbagPress.m_StrUserID = "";
            this.m_txtGasbagPress.m_StrUserName = "";
            this.m_txtGasbagPress.Multiline = false;
            this.m_txtGasbagPress.Name = "m_txtGasbagPress";
            this.m_txtGasbagPress.Size = new System.Drawing.Size(56, 21);
            this.m_txtGasbagPress.TabIndex = 10000011;
            this.m_txtGasbagPress.Text = "";
            // 
            // m_lblSign
            // 
            this.m_lblSign.BackColor = System.Drawing.SystemColors.Control;
            this.m_lblSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblSign.ForeColor = System.Drawing.Color.Black;
            this.m_lblSign.Location = new System.Drawing.Point(516, 478);
            this.m_lblSign.Name = "m_lblSign";
            this.m_lblSign.Size = new System.Drawing.Size(120, 19);
            this.m_lblSign.TabIndex = 10000072;
            this.m_lblSign.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lblSign.Visible = false;
            // 
            // m_cmdMachineMode
            // 
            this.m_cmdMachineMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdMachineMode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdMachineMode.Location = new System.Drawing.Point(8, 28);
            this.m_cmdMachineMode.Name = "m_cmdMachineMode";
            this.m_cmdMachineMode.Size = new System.Drawing.Size(80, 28);
            this.m_cmdMachineMode.TabIndex = 10000073;
            this.m_cmdMachineMode.Text = "通气方式:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblcm);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblcmH2O);
            this.groupBox1.Controls.Add(this.m_txtInLength);
            this.groupBox1.Controls.Add(this.m_txtBreathSoundLeft);
            this.groupBox1.Controls.Add(this.m_txtGasbagPress);
            this.groupBox1.Controls.Add(this.lblBreathSound);
            this.groupBox1.Controls.Add(this.m_txtMachineMode);
            this.groupBox1.Controls.Add(this.m_txtBreathSoundRight);
            this.groupBox1.Location = new System.Drawing.Point(16, 156);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(804, 44);
            this.groupBox1.TabIndex = 10000074;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(600, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 14);
            this.label5.TabIndex = 10000082;
            this.label5.Text = "气囊压力:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(459, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 10000081;
            this.label4.Text = "插管深度:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(350, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 14);
            this.label3.TabIndex = 10000080;
            this.label3.Text = "右:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 10000079;
            this.label1.Text = "通气方式:";
            // 
            // lblcm
            // 
            this.lblcm.AutoSize = true;
            this.lblcm.Location = new System.Drawing.Point(575, 20);
            this.lblcm.Name = "lblcm";
            this.lblcm.Size = new System.Drawing.Size(21, 14);
            this.lblcm.TabIndex = 10000078;
            this.lblcm.Text = "cm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(784, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 9);
            this.label2.TabIndex = 10000077;
            this.label2.Text = "2";
            // 
            // lblcmH2O
            // 
            this.lblcmH2O.AutoSize = true;
            this.lblcmH2O.Location = new System.Drawing.Point(736, 20);
            this.lblcmH2O.Name = "lblcmH2O";
            this.lblcmH2O.Size = new System.Drawing.Size(42, 14);
            this.lblcmH2O.TabIndex = 10000076;
            this.lblcmH2O.Text = "cmH O";
            // 
            // m_cmdGasbagPress
            // 
            this.m_cmdGasbagPress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdGasbagPress.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdGasbagPress.Location = new System.Drawing.Point(252, 28);
            this.m_cmdGasbagPress.Name = "m_cmdGasbagPress";
            this.m_cmdGasbagPress.Size = new System.Drawing.Size(80, 28);
            this.m_cmdGasbagPress.TabIndex = 10000075;
            this.m_cmdGasbagPress.Text = "气囊压力:";
            // 
            // m_cmdInLength
            // 
            this.m_cmdInLength.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdInLength.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdInLength.Location = new System.Drawing.Point(172, 28);
            this.m_cmdInLength.Name = "m_cmdInLength";
            this.m_cmdInLength.Size = new System.Drawing.Size(80, 28);
            this.m_cmdInLength.TabIndex = 10000074;
            this.m_cmdInLength.Text = "插管深度:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.m_txtPEEP);
            this.groupBox2.Controls.Add(this.lblPEEP);
            this.groupBox2.Controls.Add(this.m_txtPRESSURE_SLOPE);
            this.groupBox2.Controls.Add(this.lblPRESSURE_SLOPE);
            this.groupBox2.Controls.Add(this.m_txtFLOW_TRIGGER);
            this.groupBox2.Controls.Add(this.lblFLOW_TRIGGER);
            this.groupBox2.Controls.Add(this.m_txtBASE_FLOW);
            this.groupBox2.Controls.Add(this.lblBASE_FLOW);
            this.groupBox2.Controls.Add(this.m_txtINSPIRATORY_PRESSURE);
            this.groupBox2.Controls.Add(this.lblINSPIRATORY_PRESSURE);
            this.groupBox2.Controls.Add(this.m_txtINSPIRATORY_TIME);
            this.groupBox2.Controls.Add(this.lblINSPIRATORY_TIME);
            this.groupBox2.Controls.Add(this.m_txtCOMPLIANCE_COMP);
            this.groupBox2.Controls.Add(this.lblCOMPLIANCE_COMP);
            this.groupBox2.Controls.Add(this.m_txtMMV_LEVEL);
            this.groupBox2.Controls.Add(this.lblMMV_LEVEL);
            this.groupBox2.Controls.Add(this.m_txtINSPIRATORY_PAUSE);
            this.groupBox2.Controls.Add(this.lblINSPIRATORY_PAUSE);
            this.groupBox2.Controls.Add(this.m_txtASSIST_SENSITIVITY);
            this.groupBox2.Controls.Add(this.lblASSIST_SENSITIVITY);
            this.groupBox2.Controls.Add(this.m_txtPS);
            this.groupBox2.Controls.Add(this.lblPS);
            this.groupBox2.Controls.Add(this.m_txtO2);
            this.groupBox2.Controls.Add(this.lblO2);
            this.groupBox2.Controls.Add(this.m_txtPEAK_FLOW);
            this.groupBox2.Controls.Add(this.lblPEAK_FLOW);
            this.groupBox2.Controls.Add(this.m_txtRATE);
            this.groupBox2.Controls.Add(this.lblRATE);
            this.groupBox2.Controls.Add(this.m_txtTIDAL_VOLUME);
            this.groupBox2.Controls.Add(this.lblTIDAL_VOLUME);
            this.groupBox2.Location = new System.Drawing.Point(16, 204);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(804, 140);
            this.groupBox2.TabIndex = 10000075;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "设定参数";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(660, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(10, 9);
            this.label12.TabIndex = 10000076;
            this.label12.Text = "2";
            // 
            // m_txtPEEP
            // 
            this.m_txtPEEP.BackColor = System.Drawing.Color.White;
            this.m_txtPEEP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPEEP.ForeColor = System.Drawing.Color.Black;
            this.m_txtPEEP.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPEEP.Location = new System.Drawing.Point(740, 114);
            this.m_txtPEEP.m_BlnIgnoreUserInfo = false;
            this.m_txtPEEP.m_BlnPartControl = false;
            this.m_txtPEEP.m_BlnReadOnly = false;
            this.m_txtPEEP.m_BlnUnderLineDST = false;
            this.m_txtPEEP.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPEEP.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPEEP.m_IntCanModifyTime = 6;
            this.m_txtPEEP.m_IntPartControlLength = 0;
            this.m_txtPEEP.m_IntPartControlStartIndex = 0;
            this.m_txtPEEP.m_StrUserID = "";
            this.m_txtPEEP.m_StrUserName = "";
            this.m_txtPEEP.Multiline = false;
            this.m_txtPEEP.Name = "m_txtPEEP";
            this.m_txtPEEP.Size = new System.Drawing.Size(56, 21);
            this.m_txtPEEP.TabIndex = 10000074;
            this.m_txtPEEP.Text = "";
            // 
            // lblPEEP
            // 
            this.lblPEEP.AutoSize = true;
            this.lblPEEP.Location = new System.Drawing.Point(540, 116);
            this.lblPEEP.Name = "lblPEEP";
            this.lblPEEP.Size = new System.Drawing.Size(42, 14);
            this.lblPEEP.TabIndex = 10000075;
            this.lblPEEP.Text = "PEEP:";
            // 
            // m_txtPRESSURE_SLOPE
            // 
            this.m_txtPRESSURE_SLOPE.BackColor = System.Drawing.Color.White;
            this.m_txtPRESSURE_SLOPE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPRESSURE_SLOPE.ForeColor = System.Drawing.Color.Black;
            this.m_txtPRESSURE_SLOPE.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPRESSURE_SLOPE.Location = new System.Drawing.Point(480, 114);
            this.m_txtPRESSURE_SLOPE.m_BlnIgnoreUserInfo = false;
            this.m_txtPRESSURE_SLOPE.m_BlnPartControl = false;
            this.m_txtPRESSURE_SLOPE.m_BlnReadOnly = false;
            this.m_txtPRESSURE_SLOPE.m_BlnUnderLineDST = false;
            this.m_txtPRESSURE_SLOPE.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPRESSURE_SLOPE.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPRESSURE_SLOPE.m_IntCanModifyTime = 6;
            this.m_txtPRESSURE_SLOPE.m_IntPartControlLength = 0;
            this.m_txtPRESSURE_SLOPE.m_IntPartControlStartIndex = 0;
            this.m_txtPRESSURE_SLOPE.m_StrUserID = "";
            this.m_txtPRESSURE_SLOPE.m_StrUserName = "";
            this.m_txtPRESSURE_SLOPE.Multiline = false;
            this.m_txtPRESSURE_SLOPE.Name = "m_txtPRESSURE_SLOPE";
            this.m_txtPRESSURE_SLOPE.Size = new System.Drawing.Size(56, 21);
            this.m_txtPRESSURE_SLOPE.TabIndex = 10000072;
            this.m_txtPRESSURE_SLOPE.Text = "";
            // 
            // lblPRESSURE_SLOPE
            // 
            this.lblPRESSURE_SLOPE.AutoSize = true;
            this.lblPRESSURE_SLOPE.Location = new System.Drawing.Point(264, 116);
            this.lblPRESSURE_SLOPE.Name = "lblPRESSURE_SLOPE";
            this.lblPRESSURE_SLOPE.Size = new System.Drawing.Size(182, 14);
            this.lblPRESSURE_SLOPE.TabIndex = 10000073;
            this.lblPRESSURE_SLOPE.Text = "压力斜坡(Pressure Slope):";
            // 
            // m_txtFLOW_TRIGGER
            // 
            this.m_txtFLOW_TRIGGER.BackColor = System.Drawing.Color.White;
            this.m_txtFLOW_TRIGGER.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtFLOW_TRIGGER.ForeColor = System.Drawing.Color.Black;
            this.m_txtFLOW_TRIGGER.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtFLOW_TRIGGER.Location = new System.Drawing.Point(740, 90);
            this.m_txtFLOW_TRIGGER.m_BlnIgnoreUserInfo = false;
            this.m_txtFLOW_TRIGGER.m_BlnPartControl = false;
            this.m_txtFLOW_TRIGGER.m_BlnReadOnly = false;
            this.m_txtFLOW_TRIGGER.m_BlnUnderLineDST = false;
            this.m_txtFLOW_TRIGGER.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtFLOW_TRIGGER.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtFLOW_TRIGGER.m_IntCanModifyTime = 6;
            this.m_txtFLOW_TRIGGER.m_IntPartControlLength = 0;
            this.m_txtFLOW_TRIGGER.m_IntPartControlStartIndex = 0;
            this.m_txtFLOW_TRIGGER.m_StrUserID = "";
            this.m_txtFLOW_TRIGGER.m_StrUserName = "";
            this.m_txtFLOW_TRIGGER.Multiline = false;
            this.m_txtFLOW_TRIGGER.Name = "m_txtFLOW_TRIGGER";
            this.m_txtFLOW_TRIGGER.Size = new System.Drawing.Size(56, 21);
            this.m_txtFLOW_TRIGGER.TabIndex = 10000070;
            this.m_txtFLOW_TRIGGER.Text = "";
            // 
            // lblFLOW_TRIGGER
            // 
            this.lblFLOW_TRIGGER.AutoSize = true;
            this.lblFLOW_TRIGGER.Location = new System.Drawing.Point(540, 90);
            this.lblFLOW_TRIGGER.Name = "lblFLOW_TRIGGER";
            this.lblFLOW_TRIGGER.Size = new System.Drawing.Size(196, 14);
            this.lblFLOW_TRIGGER.TabIndex = 10000071;
            this.lblFLOW_TRIGGER.Text = "流 量 触 发 (Flow Trigger):";
            // 
            // m_txtBASE_FLOW
            // 
            this.m_txtBASE_FLOW.BackColor = System.Drawing.Color.White;
            this.m_txtBASE_FLOW.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBASE_FLOW.ForeColor = System.Drawing.Color.Black;
            this.m_txtBASE_FLOW.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBASE_FLOW.Location = new System.Drawing.Point(480, 90);
            this.m_txtBASE_FLOW.m_BlnIgnoreUserInfo = false;
            this.m_txtBASE_FLOW.m_BlnPartControl = false;
            this.m_txtBASE_FLOW.m_BlnReadOnly = false;
            this.m_txtBASE_FLOW.m_BlnUnderLineDST = false;
            this.m_txtBASE_FLOW.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBASE_FLOW.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBASE_FLOW.m_IntCanModifyTime = 6;
            this.m_txtBASE_FLOW.m_IntPartControlLength = 0;
            this.m_txtBASE_FLOW.m_IntPartControlStartIndex = 0;
            this.m_txtBASE_FLOW.m_StrUserID = "";
            this.m_txtBASE_FLOW.m_StrUserName = "";
            this.m_txtBASE_FLOW.Multiline = false;
            this.m_txtBASE_FLOW.Name = "m_txtBASE_FLOW";
            this.m_txtBASE_FLOW.Size = new System.Drawing.Size(56, 21);
            this.m_txtBASE_FLOW.TabIndex = 10000068;
            this.m_txtBASE_FLOW.Text = "";
            // 
            // lblBASE_FLOW
            // 
            this.lblBASE_FLOW.AutoSize = true;
            this.lblBASE_FLOW.Location = new System.Drawing.Point(264, 90);
            this.lblBASE_FLOW.Name = "lblBASE_FLOW";
            this.lblBASE_FLOW.Size = new System.Drawing.Size(182, 14);
            this.lblBASE_FLOW.TabIndex = 10000069;
            this.lblBASE_FLOW.Text = "基 础 气 流 (Base Flow) :";
            // 
            // m_txtINSPIRATORY_PRESSURE
            // 
            this.m_txtINSPIRATORY_PRESSURE.BackColor = System.Drawing.Color.White;
            this.m_txtINSPIRATORY_PRESSURE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtINSPIRATORY_PRESSURE.ForeColor = System.Drawing.Color.Black;
            this.m_txtINSPIRATORY_PRESSURE.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtINSPIRATORY_PRESSURE.Location = new System.Drawing.Point(200, 90);
            this.m_txtINSPIRATORY_PRESSURE.m_BlnIgnoreUserInfo = false;
            this.m_txtINSPIRATORY_PRESSURE.m_BlnPartControl = false;
            this.m_txtINSPIRATORY_PRESSURE.m_BlnReadOnly = false;
            this.m_txtINSPIRATORY_PRESSURE.m_BlnUnderLineDST = false;
            this.m_txtINSPIRATORY_PRESSURE.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtINSPIRATORY_PRESSURE.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtINSPIRATORY_PRESSURE.m_IntCanModifyTime = 6;
            this.m_txtINSPIRATORY_PRESSURE.m_IntPartControlLength = 0;
            this.m_txtINSPIRATORY_PRESSURE.m_IntPartControlStartIndex = 0;
            this.m_txtINSPIRATORY_PRESSURE.m_StrUserID = "";
            this.m_txtINSPIRATORY_PRESSURE.m_StrUserName = "";
            this.m_txtINSPIRATORY_PRESSURE.Multiline = false;
            this.m_txtINSPIRATORY_PRESSURE.Name = "m_txtINSPIRATORY_PRESSURE";
            this.m_txtINSPIRATORY_PRESSURE.Size = new System.Drawing.Size(56, 21);
            this.m_txtINSPIRATORY_PRESSURE.TabIndex = 10000066;
            this.m_txtINSPIRATORY_PRESSURE.Text = "";
            // 
            // lblINSPIRATORY_PRESSURE
            // 
            this.lblINSPIRATORY_PRESSURE.Location = new System.Drawing.Point(8, 90);
            this.lblINSPIRATORY_PRESSURE.Name = "lblINSPIRATORY_PRESSURE";
            this.lblINSPIRATORY_PRESSURE.Size = new System.Drawing.Size(196, 40);
            this.lblINSPIRATORY_PRESSURE.TabIndex = 10000067;
            this.lblINSPIRATORY_PRESSURE.Text = "吸气压力(Inspiratory Pressure):";
            // 
            // m_txtINSPIRATORY_TIME
            // 
            this.m_txtINSPIRATORY_TIME.BackColor = System.Drawing.Color.White;
            this.m_txtINSPIRATORY_TIME.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtINSPIRATORY_TIME.ForeColor = System.Drawing.Color.Black;
            this.m_txtINSPIRATORY_TIME.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtINSPIRATORY_TIME.Location = new System.Drawing.Point(740, 66);
            this.m_txtINSPIRATORY_TIME.m_BlnIgnoreUserInfo = false;
            this.m_txtINSPIRATORY_TIME.m_BlnPartControl = false;
            this.m_txtINSPIRATORY_TIME.m_BlnReadOnly = false;
            this.m_txtINSPIRATORY_TIME.m_BlnUnderLineDST = false;
            this.m_txtINSPIRATORY_TIME.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtINSPIRATORY_TIME.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtINSPIRATORY_TIME.m_IntCanModifyTime = 6;
            this.m_txtINSPIRATORY_TIME.m_IntPartControlLength = 0;
            this.m_txtINSPIRATORY_TIME.m_IntPartControlStartIndex = 0;
            this.m_txtINSPIRATORY_TIME.m_StrUserID = "";
            this.m_txtINSPIRATORY_TIME.m_StrUserName = "";
            this.m_txtINSPIRATORY_TIME.Multiline = false;
            this.m_txtINSPIRATORY_TIME.Name = "m_txtINSPIRATORY_TIME";
            this.m_txtINSPIRATORY_TIME.Size = new System.Drawing.Size(56, 21);
            this.m_txtINSPIRATORY_TIME.TabIndex = 10000064;
            this.m_txtINSPIRATORY_TIME.Text = "";
            // 
            // lblINSPIRATORY_TIME
            // 
            this.lblINSPIRATORY_TIME.AutoSize = true;
            this.lblINSPIRATORY_TIME.Location = new System.Drawing.Point(540, 68);
            this.lblINSPIRATORY_TIME.Name = "lblINSPIRATORY_TIME";
            this.lblINSPIRATORY_TIME.Size = new System.Drawing.Size(196, 14);
            this.lblINSPIRATORY_TIME.TabIndex = 10000065;
            this.lblINSPIRATORY_TIME.Text = "吸气时间(Inspiratory Time):";
            // 
            // m_txtCOMPLIANCE_COMP
            // 
            this.m_txtCOMPLIANCE_COMP.BackColor = System.Drawing.Color.White;
            this.m_txtCOMPLIANCE_COMP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCOMPLIANCE_COMP.ForeColor = System.Drawing.Color.Black;
            this.m_txtCOMPLIANCE_COMP.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCOMPLIANCE_COMP.Location = new System.Drawing.Point(480, 66);
            this.m_txtCOMPLIANCE_COMP.m_BlnIgnoreUserInfo = false;
            this.m_txtCOMPLIANCE_COMP.m_BlnPartControl = false;
            this.m_txtCOMPLIANCE_COMP.m_BlnReadOnly = false;
            this.m_txtCOMPLIANCE_COMP.m_BlnUnderLineDST = false;
            this.m_txtCOMPLIANCE_COMP.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCOMPLIANCE_COMP.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCOMPLIANCE_COMP.m_IntCanModifyTime = 6;
            this.m_txtCOMPLIANCE_COMP.m_IntPartControlLength = 0;
            this.m_txtCOMPLIANCE_COMP.m_IntPartControlStartIndex = 0;
            this.m_txtCOMPLIANCE_COMP.m_StrUserID = "";
            this.m_txtCOMPLIANCE_COMP.m_StrUserName = "";
            this.m_txtCOMPLIANCE_COMP.Multiline = false;
            this.m_txtCOMPLIANCE_COMP.Name = "m_txtCOMPLIANCE_COMP";
            this.m_txtCOMPLIANCE_COMP.Size = new System.Drawing.Size(56, 21);
            this.m_txtCOMPLIANCE_COMP.TabIndex = 10000062;
            this.m_txtCOMPLIANCE_COMP.Text = "";
            // 
            // lblCOMPLIANCE_COMP
            // 
            this.lblCOMPLIANCE_COMP.AutoSize = true;
            this.lblCOMPLIANCE_COMP.Location = new System.Drawing.Point(264, 68);
            this.lblCOMPLIANCE_COMP.Name = "lblCOMPLIANCE_COMP";
            this.lblCOMPLIANCE_COMP.Size = new System.Drawing.Size(203, 14);
            this.lblCOMPLIANCE_COMP.TabIndex = 10000063;
            this.lblCOMPLIANCE_COMP.Text = "顺应性补偿(Compliance Comp):";
            // 
            // m_txtMMV_LEVEL
            // 
            this.m_txtMMV_LEVEL.BackColor = System.Drawing.Color.White;
            this.m_txtMMV_LEVEL.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtMMV_LEVEL.ForeColor = System.Drawing.Color.Black;
            this.m_txtMMV_LEVEL.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtMMV_LEVEL.Location = new System.Drawing.Point(200, 66);
            this.m_txtMMV_LEVEL.m_BlnIgnoreUserInfo = false;
            this.m_txtMMV_LEVEL.m_BlnPartControl = false;
            this.m_txtMMV_LEVEL.m_BlnReadOnly = false;
            this.m_txtMMV_LEVEL.m_BlnUnderLineDST = false;
            this.m_txtMMV_LEVEL.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtMMV_LEVEL.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtMMV_LEVEL.m_IntCanModifyTime = 6;
            this.m_txtMMV_LEVEL.m_IntPartControlLength = 0;
            this.m_txtMMV_LEVEL.m_IntPartControlStartIndex = 0;
            this.m_txtMMV_LEVEL.m_StrUserID = "";
            this.m_txtMMV_LEVEL.m_StrUserName = "";
            this.m_txtMMV_LEVEL.Multiline = false;
            this.m_txtMMV_LEVEL.Name = "m_txtMMV_LEVEL";
            this.m_txtMMV_LEVEL.Size = new System.Drawing.Size(56, 21);
            this.m_txtMMV_LEVEL.TabIndex = 10000060;
            this.m_txtMMV_LEVEL.Text = "";
            // 
            // lblMMV_LEVEL
            // 
            this.lblMMV_LEVEL.AutoSize = true;
            this.lblMMV_LEVEL.Location = new System.Drawing.Point(8, 68);
            this.lblMMV_LEVEL.Name = "lblMMV_LEVEL";
            this.lblMMV_LEVEL.Size = new System.Drawing.Size(175, 14);
            this.lblMMV_LEVEL.TabIndex = 10000061;
            this.lblMMV_LEVEL.Text = "水平设置(MMV Level MMV):";
            // 
            // m_txtINSPIRATORY_PAUSE
            // 
            this.m_txtINSPIRATORY_PAUSE.BackColor = System.Drawing.Color.White;
            this.m_txtINSPIRATORY_PAUSE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtINSPIRATORY_PAUSE.ForeColor = System.Drawing.Color.Black;
            this.m_txtINSPIRATORY_PAUSE.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtINSPIRATORY_PAUSE.Location = new System.Drawing.Point(740, 42);
            this.m_txtINSPIRATORY_PAUSE.m_BlnIgnoreUserInfo = false;
            this.m_txtINSPIRATORY_PAUSE.m_BlnPartControl = false;
            this.m_txtINSPIRATORY_PAUSE.m_BlnReadOnly = false;
            this.m_txtINSPIRATORY_PAUSE.m_BlnUnderLineDST = false;
            this.m_txtINSPIRATORY_PAUSE.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtINSPIRATORY_PAUSE.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtINSPIRATORY_PAUSE.m_IntCanModifyTime = 6;
            this.m_txtINSPIRATORY_PAUSE.m_IntPartControlLength = 0;
            this.m_txtINSPIRATORY_PAUSE.m_IntPartControlStartIndex = 0;
            this.m_txtINSPIRATORY_PAUSE.m_StrUserID = "";
            this.m_txtINSPIRATORY_PAUSE.m_StrUserName = "";
            this.m_txtINSPIRATORY_PAUSE.Multiline = false;
            this.m_txtINSPIRATORY_PAUSE.Name = "m_txtINSPIRATORY_PAUSE";
            this.m_txtINSPIRATORY_PAUSE.Size = new System.Drawing.Size(56, 21);
            this.m_txtINSPIRATORY_PAUSE.TabIndex = 10000058;
            this.m_txtINSPIRATORY_PAUSE.Text = "";
            // 
            // lblINSPIRATORY_PAUSE
            // 
            this.lblINSPIRATORY_PAUSE.AutoSize = true;
            this.lblINSPIRATORY_PAUSE.Location = new System.Drawing.Point(540, 44);
            this.lblINSPIRATORY_PAUSE.Name = "lblINSPIRATORY_PAUSE";
            this.lblINSPIRATORY_PAUSE.Size = new System.Drawing.Size(203, 14);
            this.lblINSPIRATORY_PAUSE.TabIndex = 10000059;
            this.lblINSPIRATORY_PAUSE.Text = "吸气暂停(Inspiratory Pause):";
            // 
            // m_txtASSIST_SENSITIVITY
            // 
            this.m_txtASSIST_SENSITIVITY.BackColor = System.Drawing.Color.White;
            this.m_txtASSIST_SENSITIVITY.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtASSIST_SENSITIVITY.ForeColor = System.Drawing.Color.Black;
            this.m_txtASSIST_SENSITIVITY.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtASSIST_SENSITIVITY.Location = new System.Drawing.Point(480, 42);
            this.m_txtASSIST_SENSITIVITY.m_BlnIgnoreUserInfo = false;
            this.m_txtASSIST_SENSITIVITY.m_BlnPartControl = false;
            this.m_txtASSIST_SENSITIVITY.m_BlnReadOnly = false;
            this.m_txtASSIST_SENSITIVITY.m_BlnUnderLineDST = false;
            this.m_txtASSIST_SENSITIVITY.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtASSIST_SENSITIVITY.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtASSIST_SENSITIVITY.m_IntCanModifyTime = 6;
            this.m_txtASSIST_SENSITIVITY.m_IntPartControlLength = 0;
            this.m_txtASSIST_SENSITIVITY.m_IntPartControlStartIndex = 0;
            this.m_txtASSIST_SENSITIVITY.m_StrUserID = "";
            this.m_txtASSIST_SENSITIVITY.m_StrUserName = "";
            this.m_txtASSIST_SENSITIVITY.Multiline = false;
            this.m_txtASSIST_SENSITIVITY.Name = "m_txtASSIST_SENSITIVITY";
            this.m_txtASSIST_SENSITIVITY.Size = new System.Drawing.Size(56, 21);
            this.m_txtASSIST_SENSITIVITY.TabIndex = 10000056;
            this.m_txtASSIST_SENSITIVITY.Text = "";
            // 
            // lblASSIST_SENSITIVITY
            // 
            this.lblASSIST_SENSITIVITY.AutoSize = true;
            this.lblASSIST_SENSITIVITY.Location = new System.Drawing.Point(264, 44);
            this.lblASSIST_SENSITIVITY.Name = "lblASSIST_SENSITIVITY";
            this.lblASSIST_SENSITIVITY.Size = new System.Drawing.Size(224, 14);
            this.lblASSIST_SENSITIVITY.TabIndex = 10000057;
            this.lblASSIST_SENSITIVITY.Text = "辅助灵敏度(Assist Sensitivity):";
            // 
            // m_txtPS
            // 
            this.m_txtPS.BackColor = System.Drawing.Color.White;
            this.m_txtPS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPS.ForeColor = System.Drawing.Color.Black;
            this.m_txtPS.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPS.Location = new System.Drawing.Point(200, 42);
            this.m_txtPS.m_BlnIgnoreUserInfo = false;
            this.m_txtPS.m_BlnPartControl = false;
            this.m_txtPS.m_BlnReadOnly = false;
            this.m_txtPS.m_BlnUnderLineDST = false;
            this.m_txtPS.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPS.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPS.m_IntCanModifyTime = 6;
            this.m_txtPS.m_IntPartControlLength = 0;
            this.m_txtPS.m_IntPartControlStartIndex = 0;
            this.m_txtPS.m_StrUserID = "";
            this.m_txtPS.m_StrUserName = "";
            this.m_txtPS.Multiline = false;
            this.m_txtPS.Name = "m_txtPS";
            this.m_txtPS.Size = new System.Drawing.Size(56, 21);
            this.m_txtPS.TabIndex = 10000054;
            this.m_txtPS.Text = "";
            // 
            // lblPS
            // 
            this.lblPS.AutoSize = true;
            this.lblPS.Location = new System.Drawing.Point(8, 44);
            this.lblPS.Name = "lblPS";
            this.lblPS.Size = new System.Drawing.Size(196, 14);
            this.lblPS.TabIndex = 10000055;
            this.lblPS.Text = "压力支持(Pressure Support):";
            // 
            // m_txtO2
            // 
            this.m_txtO2.BackColor = System.Drawing.Color.White;
            this.m_txtO2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtO2.ForeColor = System.Drawing.Color.Black;
            this.m_txtO2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtO2.Location = new System.Drawing.Point(740, 20);
            this.m_txtO2.m_BlnIgnoreUserInfo = false;
            this.m_txtO2.m_BlnPartControl = false;
            this.m_txtO2.m_BlnReadOnly = false;
            this.m_txtO2.m_BlnUnderLineDST = false;
            this.m_txtO2.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtO2.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtO2.m_IntCanModifyTime = 6;
            this.m_txtO2.m_IntPartControlLength = 0;
            this.m_txtO2.m_IntPartControlStartIndex = 0;
            this.m_txtO2.m_StrUserID = "";
            this.m_txtO2.m_StrUserName = "";
            this.m_txtO2.Multiline = false;
            this.m_txtO2.Name = "m_txtO2";
            this.m_txtO2.Size = new System.Drawing.Size(56, 21);
            this.m_txtO2.TabIndex = 10000052;
            this.m_txtO2.Text = "";
            // 
            // lblO2
            // 
            this.lblO2.AutoSize = true;
            this.lblO2.Location = new System.Drawing.Point(648, 20);
            this.lblO2.Name = "lblO2";
            this.lblO2.Size = new System.Drawing.Size(77, 14);
            this.lblO2.TabIndex = 10000053;
            this.lblO2.Text = "O %氧浓度:";
            // 
            // m_txtPEAK_FLOW
            // 
            this.m_txtPEAK_FLOW.BackColor = System.Drawing.Color.White;
            this.m_txtPEAK_FLOW.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPEAK_FLOW.ForeColor = System.Drawing.Color.Black;
            this.m_txtPEAK_FLOW.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPEAK_FLOW.Location = new System.Drawing.Point(572, 20);
            this.m_txtPEAK_FLOW.m_BlnIgnoreUserInfo = false;
            this.m_txtPEAK_FLOW.m_BlnPartControl = false;
            this.m_txtPEAK_FLOW.m_BlnReadOnly = false;
            this.m_txtPEAK_FLOW.m_BlnUnderLineDST = false;
            this.m_txtPEAK_FLOW.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPEAK_FLOW.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPEAK_FLOW.m_IntCanModifyTime = 6;
            this.m_txtPEAK_FLOW.m_IntPartControlLength = 0;
            this.m_txtPEAK_FLOW.m_IntPartControlStartIndex = 0;
            this.m_txtPEAK_FLOW.m_StrUserID = "";
            this.m_txtPEAK_FLOW.m_StrUserName = "";
            this.m_txtPEAK_FLOW.Multiline = false;
            this.m_txtPEAK_FLOW.Name = "m_txtPEAK_FLOW";
            this.m_txtPEAK_FLOW.Size = new System.Drawing.Size(56, 21);
            this.m_txtPEAK_FLOW.TabIndex = 10000050;
            this.m_txtPEAK_FLOW.Text = "";
            // 
            // lblPEAK_FLOW
            // 
            this.lblPEAK_FLOW.AutoSize = true;
            this.lblPEAK_FLOW.Location = new System.Drawing.Point(416, 20);
            this.lblPEAK_FLOW.Name = "lblPEAK_FLOW";
            this.lblPEAK_FLOW.Size = new System.Drawing.Size(147, 14);
            this.lblPEAK_FLOW.TabIndex = 10000051;
            this.lblPEAK_FLOW.Text = "峰值流速(Peak Flow):";
            // 
            // m_txtRATE
            // 
            this.m_txtRATE.BackColor = System.Drawing.Color.White;
            this.m_txtRATE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtRATE.ForeColor = System.Drawing.Color.Black;
            this.m_txtRATE.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtRATE.Location = new System.Drawing.Point(356, 20);
            this.m_txtRATE.m_BlnIgnoreUserInfo = false;
            this.m_txtRATE.m_BlnPartControl = false;
            this.m_txtRATE.m_BlnReadOnly = false;
            this.m_txtRATE.m_BlnUnderLineDST = false;
            this.m_txtRATE.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtRATE.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtRATE.m_IntCanModifyTime = 6;
            this.m_txtRATE.m_IntPartControlLength = 0;
            this.m_txtRATE.m_IntPartControlStartIndex = 0;
            this.m_txtRATE.m_StrUserID = "";
            this.m_txtRATE.m_StrUserName = "";
            this.m_txtRATE.Multiline = false;
            this.m_txtRATE.Name = "m_txtRATE";
            this.m_txtRATE.Size = new System.Drawing.Size(56, 21);
            this.m_txtRATE.TabIndex = 10000048;
            this.m_txtRATE.Text = "";
            // 
            // lblRATE
            // 
            this.lblRATE.AutoSize = true;
            this.lblRATE.Location = new System.Drawing.Point(264, 20);
            this.lblRATE.Name = "lblRATE";
            this.lblRATE.Size = new System.Drawing.Size(91, 14);
            this.lblRATE.TabIndex = 10000049;
            this.lblRATE.Text = "频 率(Rate):";
            // 
            // m_txtTIDAL_VOLUME
            // 
            this.m_txtTIDAL_VOLUME.BackColor = System.Drawing.Color.White;
            this.m_txtTIDAL_VOLUME.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtTIDAL_VOLUME.ForeColor = System.Drawing.Color.Black;
            this.m_txtTIDAL_VOLUME.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtTIDAL_VOLUME.Location = new System.Drawing.Point(200, 20);
            this.m_txtTIDAL_VOLUME.m_BlnIgnoreUserInfo = false;
            this.m_txtTIDAL_VOLUME.m_BlnPartControl = false;
            this.m_txtTIDAL_VOLUME.m_BlnReadOnly = false;
            this.m_txtTIDAL_VOLUME.m_BlnUnderLineDST = false;
            this.m_txtTIDAL_VOLUME.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtTIDAL_VOLUME.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtTIDAL_VOLUME.m_IntCanModifyTime = 6;
            this.m_txtTIDAL_VOLUME.m_IntPartControlLength = 0;
            this.m_txtTIDAL_VOLUME.m_IntPartControlStartIndex = 0;
            this.m_txtTIDAL_VOLUME.m_StrUserID = "";
            this.m_txtTIDAL_VOLUME.m_StrUserName = "";
            this.m_txtTIDAL_VOLUME.Name = "m_txtTIDAL_VOLUME";
            this.m_txtTIDAL_VOLUME.Size = new System.Drawing.Size(56, 21);
            this.m_txtTIDAL_VOLUME.TabIndex = 10000046;
            this.m_txtTIDAL_VOLUME.Text = "";
            // 
            // lblTIDAL_VOLUME
            // 
            this.lblTIDAL_VOLUME.AutoSize = true;
            this.lblTIDAL_VOLUME.Location = new System.Drawing.Point(8, 20);
            this.lblTIDAL_VOLUME.Name = "lblTIDAL_VOLUME";
            this.lblTIDAL_VOLUME.Size = new System.Drawing.Size(182, 14);
            this.lblTIDAL_VOLUME.TabIndex = 10000047;
            this.lblTIDAL_VOLUME.Text = "潮 气 量 (Tidal Volume) :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.m_txtTi);
            this.groupBox3.Controls.Add(this.lblTi);
            this.groupBox3.Controls.Add(this.m_txtI_E_RATIO);
            this.groupBox3.Controls.Add(this.lblI_E_RATIO);
            this.groupBox3.Controls.Add(this.m_txtSPONT);
            this.groupBox3.Controls.Add(this.lblSPONT);
            this.groupBox3.Controls.Add(this.m_txtTOTAL);
            this.groupBox3.Controls.Add(this.lblTOTAL);
            this.groupBox3.Controls.Add(this.m_txtSPONT_MV);
            this.groupBox3.Controls.Add(this.lblSPONT_MV);
            this.groupBox3.Controls.Add(this.m_txtTOTAL_MV);
            this.groupBox3.Controls.Add(this.lblTOTAL_MV);
            this.groupBox3.Controls.Add(this.m_txtTIDAL_VOL);
            this.groupBox3.Controls.Add(this.lblTIDAL_VOL);
            this.groupBox3.Controls.Add(this.lblMMV);
            this.groupBox3.Controls.Add(this.m_txtMMV);
            this.groupBox3.Controls.Add(this.m_txtPEAR);
            this.groupBox3.Controls.Add(this.lblPEAR);
            this.groupBox3.Controls.Add(this.m_txtMEAN);
            this.groupBox3.Controls.Add(this.lblMEAN);
            this.groupBox3.Controls.Add(this.m_txtPLATEAU);
            this.groupBox3.Controls.Add(this.lblPLATEAU);
            this.groupBox3.Location = new System.Drawing.Point(16, 348);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(804, 116);
            this.groupBox3.TabIndex = 10000076;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "监测数值";
            // 
            // m_txtTi
            // 
            this.m_txtTi.BackColor = System.Drawing.Color.White;
            this.m_txtTi.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtTi.ForeColor = System.Drawing.Color.Black;
            this.m_txtTi.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtTi.Location = new System.Drawing.Point(404, 64);
            this.m_txtTi.m_BlnIgnoreUserInfo = false;
            this.m_txtTi.m_BlnPartControl = false;
            this.m_txtTi.m_BlnReadOnly = false;
            this.m_txtTi.m_BlnUnderLineDST = false;
            this.m_txtTi.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtTi.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtTi.m_IntCanModifyTime = 6;
            this.m_txtTi.m_IntPartControlLength = 0;
            this.m_txtTi.m_IntPartControlStartIndex = 0;
            this.m_txtTi.m_StrUserID = "";
            this.m_txtTi.m_StrUserName = "";
            this.m_txtTi.Multiline = false;
            this.m_txtTi.Name = "m_txtTi";
            this.m_txtTi.Size = new System.Drawing.Size(56, 21);
            this.m_txtTi.TabIndex = 10000104;
            this.m_txtTi.Text = "";
            // 
            // lblTi
            // 
            this.lblTi.AutoSize = true;
            this.lblTi.Location = new System.Drawing.Point(256, 66);
            this.lblTi.Name = "lblTi";
            this.lblTi.Size = new System.Drawing.Size(70, 14);
            this.lblTi.TabIndex = 10000105;
            this.lblTi.Text = "吸气时间:";
            // 
            // m_txtI_E_RATIO
            // 
            this.m_txtI_E_RATIO.BackColor = System.Drawing.Color.White;
            this.m_txtI_E_RATIO.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtI_E_RATIO.ForeColor = System.Drawing.Color.Black;
            this.m_txtI_E_RATIO.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtI_E_RATIO.Location = new System.Drawing.Point(688, 40);
            this.m_txtI_E_RATIO.m_BlnIgnoreUserInfo = false;
            this.m_txtI_E_RATIO.m_BlnPartControl = false;
            this.m_txtI_E_RATIO.m_BlnReadOnly = false;
            this.m_txtI_E_RATIO.m_BlnUnderLineDST = false;
            this.m_txtI_E_RATIO.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtI_E_RATIO.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtI_E_RATIO.m_IntCanModifyTime = 6;
            this.m_txtI_E_RATIO.m_IntPartControlLength = 0;
            this.m_txtI_E_RATIO.m_IntPartControlStartIndex = 0;
            this.m_txtI_E_RATIO.m_StrUserID = "";
            this.m_txtI_E_RATIO.m_StrUserName = "";
            this.m_txtI_E_RATIO.Multiline = false;
            this.m_txtI_E_RATIO.Name = "m_txtI_E_RATIO";
            this.m_txtI_E_RATIO.Size = new System.Drawing.Size(56, 21);
            this.m_txtI_E_RATIO.TabIndex = 10000102;
            this.m_txtI_E_RATIO.Text = "";
            // 
            // lblI_E_RATIO
            // 
            this.lblI_E_RATIO.AutoSize = true;
            this.lblI_E_RATIO.Location = new System.Drawing.Point(464, 42);
            this.lblI_E_RATIO.Name = "lblI_E_RATIO";
            this.lblI_E_RATIO.Size = new System.Drawing.Size(161, 14);
            this.lblI_E_RATIO.TabIndex = 10000103;
            this.lblI_E_RATIO.Text = "吸：呼比率(I E RATIO):";
            // 
            // m_txtSPONT
            // 
            this.m_txtSPONT.BackColor = System.Drawing.Color.White;
            this.m_txtSPONT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSPONT.ForeColor = System.Drawing.Color.Black;
            this.m_txtSPONT.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSPONT.Location = new System.Drawing.Point(404, 40);
            this.m_txtSPONT.m_BlnIgnoreUserInfo = false;
            this.m_txtSPONT.m_BlnPartControl = false;
            this.m_txtSPONT.m_BlnReadOnly = false;
            this.m_txtSPONT.m_BlnUnderLineDST = false;
            this.m_txtSPONT.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSPONT.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSPONT.m_IntCanModifyTime = 6;
            this.m_txtSPONT.m_IntPartControlLength = 0;
            this.m_txtSPONT.m_IntPartControlStartIndex = 0;
            this.m_txtSPONT.m_StrUserID = "";
            this.m_txtSPONT.m_StrUserName = "";
            this.m_txtSPONT.Multiline = false;
            this.m_txtSPONT.Name = "m_txtSPONT";
            this.m_txtSPONT.Size = new System.Drawing.Size(56, 21);
            this.m_txtSPONT.TabIndex = 10000100;
            this.m_txtSPONT.Text = "";
            // 
            // lblSPONT
            // 
            this.lblSPONT.AutoSize = true;
            this.lblSPONT.Location = new System.Drawing.Point(256, 42);
            this.lblSPONT.Name = "lblSPONT";
            this.lblSPONT.Size = new System.Drawing.Size(147, 14);
            this.lblSPONT.TabIndex = 10000101;
            this.lblSPONT.Text = "自主呼吸频率(STONT):";
            // 
            // m_txtTOTAL
            // 
            this.m_txtTOTAL.BackColor = System.Drawing.Color.White;
            this.m_txtTOTAL.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtTOTAL.ForeColor = System.Drawing.Color.Black;
            this.m_txtTOTAL.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtTOTAL.Location = new System.Drawing.Point(196, 40);
            this.m_txtTOTAL.m_BlnIgnoreUserInfo = false;
            this.m_txtTOTAL.m_BlnPartControl = false;
            this.m_txtTOTAL.m_BlnReadOnly = false;
            this.m_txtTOTAL.m_BlnUnderLineDST = false;
            this.m_txtTOTAL.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtTOTAL.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtTOTAL.m_IntCanModifyTime = 6;
            this.m_txtTOTAL.m_IntPartControlLength = 0;
            this.m_txtTOTAL.m_IntPartControlStartIndex = 0;
            this.m_txtTOTAL.m_StrUserID = "";
            this.m_txtTOTAL.m_StrUserName = "";
            this.m_txtTOTAL.Multiline = false;
            this.m_txtTOTAL.Name = "m_txtTOTAL";
            this.m_txtTOTAL.Size = new System.Drawing.Size(56, 21);
            this.m_txtTOTAL.TabIndex = 10000098;
            this.m_txtTOTAL.Text = "";
            // 
            // lblTOTAL
            // 
            this.lblTOTAL.AutoSize = true;
            this.lblTOTAL.Location = new System.Drawing.Point(8, 42);
            this.lblTOTAL.Name = "lblTOTAL";
            this.lblTOTAL.Size = new System.Drawing.Size(105, 14);
            this.lblTOTAL.TabIndex = 10000099;
            this.lblTOTAL.Text = "总频率(TOTAL):";
            // 
            // m_txtSPONT_MV
            // 
            this.m_txtSPONT_MV.BackColor = System.Drawing.Color.White;
            this.m_txtSPONT_MV.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSPONT_MV.ForeColor = System.Drawing.Color.Black;
            this.m_txtSPONT_MV.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSPONT_MV.Location = new System.Drawing.Point(688, 16);
            this.m_txtSPONT_MV.m_BlnIgnoreUserInfo = false;
            this.m_txtSPONT_MV.m_BlnPartControl = false;
            this.m_txtSPONT_MV.m_BlnReadOnly = false;
            this.m_txtSPONT_MV.m_BlnUnderLineDST = false;
            this.m_txtSPONT_MV.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSPONT_MV.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSPONT_MV.m_IntCanModifyTime = 6;
            this.m_txtSPONT_MV.m_IntPartControlLength = 0;
            this.m_txtSPONT_MV.m_IntPartControlStartIndex = 0;
            this.m_txtSPONT_MV.m_StrUserID = "";
            this.m_txtSPONT_MV.m_StrUserName = "";
            this.m_txtSPONT_MV.Multiline = false;
            this.m_txtSPONT_MV.Name = "m_txtSPONT_MV";
            this.m_txtSPONT_MV.Size = new System.Drawing.Size(56, 21);
            this.m_txtSPONT_MV.TabIndex = 10000096;
            this.m_txtSPONT_MV.Text = "";
            // 
            // lblSPONT_MV
            // 
            this.lblSPONT_MV.AutoSize = true;
            this.lblSPONT_MV.Location = new System.Drawing.Point(464, 18);
            this.lblSPONT_MV.Name = "lblSPONT_MV";
            this.lblSPONT_MV.Size = new System.Drawing.Size(210, 14);
            this.lblSPONT_MV.TabIndex = 10000097;
            this.lblSPONT_MV.Text = "自主呼吸分钟通气量(SPONT MV):";
            // 
            // m_txtTOTAL_MV
            // 
            this.m_txtTOTAL_MV.BackColor = System.Drawing.Color.White;
            this.m_txtTOTAL_MV.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtTOTAL_MV.ForeColor = System.Drawing.Color.Black;
            this.m_txtTOTAL_MV.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtTOTAL_MV.Location = new System.Drawing.Point(404, 16);
            this.m_txtTOTAL_MV.m_BlnIgnoreUserInfo = false;
            this.m_txtTOTAL_MV.m_BlnPartControl = false;
            this.m_txtTOTAL_MV.m_BlnReadOnly = false;
            this.m_txtTOTAL_MV.m_BlnUnderLineDST = false;
            this.m_txtTOTAL_MV.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtTOTAL_MV.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtTOTAL_MV.m_IntCanModifyTime = 6;
            this.m_txtTOTAL_MV.m_IntPartControlLength = 0;
            this.m_txtTOTAL_MV.m_IntPartControlStartIndex = 0;
            this.m_txtTOTAL_MV.m_StrUserID = "";
            this.m_txtTOTAL_MV.m_StrUserName = "";
            this.m_txtTOTAL_MV.Multiline = false;
            this.m_txtTOTAL_MV.Name = "m_txtTOTAL_MV";
            this.m_txtTOTAL_MV.Size = new System.Drawing.Size(56, 21);
            this.m_txtTOTAL_MV.TabIndex = 10000094;
            this.m_txtTOTAL_MV.Text = "";
            // 
            // lblTOTAL_MV
            // 
            this.lblTOTAL_MV.AutoSize = true;
            this.lblTOTAL_MV.Location = new System.Drawing.Point(256, 18);
            this.lblTOTAL_MV.Name = "lblTOTAL_MV";
            this.lblTOTAL_MV.Size = new System.Drawing.Size(140, 14);
            this.lblTOTAL_MV.TabIndex = 10000095;
            this.lblTOTAL_MV.Text = "总分钟通气量(总MV):";
            // 
            // m_txtTIDAL_VOL
            // 
            this.m_txtTIDAL_VOL.BackColor = System.Drawing.Color.White;
            this.m_txtTIDAL_VOL.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtTIDAL_VOL.ForeColor = System.Drawing.Color.Black;
            this.m_txtTIDAL_VOL.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtTIDAL_VOL.Location = new System.Drawing.Point(196, 16);
            this.m_txtTIDAL_VOL.m_BlnIgnoreUserInfo = false;
            this.m_txtTIDAL_VOL.m_BlnPartControl = false;
            this.m_txtTIDAL_VOL.m_BlnReadOnly = false;
            this.m_txtTIDAL_VOL.m_BlnUnderLineDST = false;
            this.m_txtTIDAL_VOL.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtTIDAL_VOL.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtTIDAL_VOL.m_IntCanModifyTime = 6;
            this.m_txtTIDAL_VOL.m_IntPartControlLength = 0;
            this.m_txtTIDAL_VOL.m_IntPartControlStartIndex = 0;
            this.m_txtTIDAL_VOL.m_StrUserID = "";
            this.m_txtTIDAL_VOL.m_StrUserName = "";
            this.m_txtTIDAL_VOL.Multiline = false;
            this.m_txtTIDAL_VOL.Name = "m_txtTIDAL_VOL";
            this.m_txtTIDAL_VOL.Size = new System.Drawing.Size(56, 21);
            this.m_txtTIDAL_VOL.TabIndex = 10000092;
            this.m_txtTIDAL_VOL.Text = "";
            // 
            // lblTIDAL_VOL
            // 
            this.lblTIDAL_VOL.AutoSize = true;
            this.lblTIDAL_VOL.Location = new System.Drawing.Point(8, 18);
            this.lblTIDAL_VOL.Name = "lblTIDAL_VOL";
            this.lblTIDAL_VOL.Size = new System.Drawing.Size(182, 14);
            this.lblTIDAL_VOL.TabIndex = 10000093;
            this.lblTIDAL_VOL.Text = "潮 气 量 (Tidal Volume) :";
            // 
            // lblMMV
            // 
            this.lblMMV.AutoSize = true;
            this.lblMMV.Location = new System.Drawing.Point(8, 66);
            this.lblMMV.Name = "lblMMV";
            this.lblMMV.Size = new System.Drawing.Size(182, 14);
            this.lblMMV.TabIndex = 10000107;
            this.lblMMV.Text = "最小分钟通气量通气百分比:";
            // 
            // m_txtMMV
            // 
            this.m_txtMMV.BackColor = System.Drawing.Color.White;
            this.m_txtMMV.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtMMV.ForeColor = System.Drawing.Color.Black;
            this.m_txtMMV.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtMMV.Location = new System.Drawing.Point(196, 64);
            this.m_txtMMV.m_BlnIgnoreUserInfo = false;
            this.m_txtMMV.m_BlnPartControl = false;
            this.m_txtMMV.m_BlnReadOnly = false;
            this.m_txtMMV.m_BlnUnderLineDST = false;
            this.m_txtMMV.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtMMV.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtMMV.m_IntCanModifyTime = 6;
            this.m_txtMMV.m_IntPartControlLength = 0;
            this.m_txtMMV.m_IntPartControlStartIndex = 0;
            this.m_txtMMV.m_StrUserID = "";
            this.m_txtMMV.m_StrUserName = "";
            this.m_txtMMV.Multiline = false;
            this.m_txtMMV.Name = "m_txtMMV";
            this.m_txtMMV.Size = new System.Drawing.Size(56, 21);
            this.m_txtMMV.TabIndex = 10000106;
            this.m_txtMMV.Text = "";
            // 
            // m_txtPEAR
            // 
            this.m_txtPEAR.BackColor = System.Drawing.Color.White;
            this.m_txtPEAR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPEAR.ForeColor = System.Drawing.Color.Black;
            this.m_txtPEAR.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPEAR.Location = new System.Drawing.Point(688, 64);
            this.m_txtPEAR.m_BlnIgnoreUserInfo = false;
            this.m_txtPEAR.m_BlnPartControl = false;
            this.m_txtPEAR.m_BlnReadOnly = false;
            this.m_txtPEAR.m_BlnUnderLineDST = false;
            this.m_txtPEAR.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPEAR.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPEAR.m_IntCanModifyTime = 6;
            this.m_txtPEAR.m_IntPartControlLength = 0;
            this.m_txtPEAR.m_IntPartControlStartIndex = 0;
            this.m_txtPEAR.m_StrUserID = "";
            this.m_txtPEAR.m_StrUserName = "";
            this.m_txtPEAR.Multiline = false;
            this.m_txtPEAR.Name = "m_txtPEAR";
            this.m_txtPEAR.Size = new System.Drawing.Size(56, 21);
            this.m_txtPEAR.TabIndex = 10000108;
            this.m_txtPEAR.Text = "";
            // 
            // lblPEAR
            // 
            this.lblPEAR.AutoSize = true;
            this.lblPEAR.Location = new System.Drawing.Point(464, 66);
            this.lblPEAR.Name = "lblPEAR";
            this.lblPEAR.Size = new System.Drawing.Size(84, 14);
            this.lblPEAR.TabIndex = 10000109;
            this.lblPEAR.Text = "峰压(PEAK):";
            // 
            // m_txtMEAN
            // 
            this.m_txtMEAN.BackColor = System.Drawing.Color.White;
            this.m_txtMEAN.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtMEAN.ForeColor = System.Drawing.Color.Black;
            this.m_txtMEAN.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtMEAN.Location = new System.Drawing.Point(196, 88);
            this.m_txtMEAN.m_BlnIgnoreUserInfo = false;
            this.m_txtMEAN.m_BlnPartControl = false;
            this.m_txtMEAN.m_BlnReadOnly = false;
            this.m_txtMEAN.m_BlnUnderLineDST = false;
            this.m_txtMEAN.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtMEAN.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtMEAN.m_IntCanModifyTime = 6;
            this.m_txtMEAN.m_IntPartControlLength = 0;
            this.m_txtMEAN.m_IntPartControlStartIndex = 0;
            this.m_txtMEAN.m_StrUserID = "";
            this.m_txtMEAN.m_StrUserName = "";
            this.m_txtMEAN.Multiline = false;
            this.m_txtMEAN.Name = "m_txtMEAN";
            this.m_txtMEAN.Size = new System.Drawing.Size(56, 21);
            this.m_txtMEAN.TabIndex = 10000110;
            this.m_txtMEAN.Text = "";
            // 
            // lblMEAN
            // 
            this.lblMEAN.AutoSize = true;
            this.lblMEAN.Location = new System.Drawing.Point(8, 90);
            this.lblMEAN.Name = "lblMEAN";
            this.lblMEAN.Size = new System.Drawing.Size(98, 14);
            this.lblMEAN.TabIndex = 10000111;
            this.lblMEAN.Text = "平均压(MEAN):";
            // 
            // m_txtPLATEAU
            // 
            this.m_txtPLATEAU.BackColor = System.Drawing.Color.White;
            this.m_txtPLATEAU.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPLATEAU.ForeColor = System.Drawing.Color.Black;
            this.m_txtPLATEAU.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPLATEAU.Location = new System.Drawing.Point(404, 88);
            this.m_txtPLATEAU.m_BlnIgnoreUserInfo = false;
            this.m_txtPLATEAU.m_BlnPartControl = false;
            this.m_txtPLATEAU.m_BlnReadOnly = false;
            this.m_txtPLATEAU.m_BlnUnderLineDST = false;
            this.m_txtPLATEAU.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPLATEAU.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPLATEAU.m_IntCanModifyTime = 6;
            this.m_txtPLATEAU.m_IntPartControlLength = 0;
            this.m_txtPLATEAU.m_IntPartControlStartIndex = 0;
            this.m_txtPLATEAU.m_StrUserID = "";
            this.m_txtPLATEAU.m_StrUserName = "";
            this.m_txtPLATEAU.Multiline = false;
            this.m_txtPLATEAU.Name = "m_txtPLATEAU";
            this.m_txtPLATEAU.Size = new System.Drawing.Size(56, 21);
            this.m_txtPLATEAU.TabIndex = 10000112;
            this.m_txtPLATEAU.Text = "";
            // 
            // lblPLATEAU
            // 
            this.lblPLATEAU.AutoSize = true;
            this.lblPLATEAU.Location = new System.Drawing.Point(256, 90);
            this.lblPLATEAU.Name = "lblPLATEAU";
            this.lblPLATEAU.Size = new System.Drawing.Size(119, 14);
            this.lblPLATEAU.TabIndex = 10000113;
            this.lblPLATEAU.Text = "平台压(PLATEAU):";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.m_cmdMachineMode);
            this.groupBox4.Controls.Add(this.m_cmdBreathLeft);
            this.groupBox4.Controls.Add(this.m_cmdBreathRight);
            this.groupBox4.Controls.Add(this.m_cmdInLength);
            this.groupBox4.Controls.Add(this.m_cmdGasbagPress);
            this.groupBox4.Location = new System.Drawing.Point(20, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(76, 20);
            this.groupBox4.TabIndex = 1000000001;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "no use";
            this.groupBox4.Visible = false;
            // 
            // txtSign
            // 
            this.txtSign.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSign.Enabled = false;
            this.txtSign.Location = new System.Drawing.Point(82, 478);
            this.txtSign.Name = "txtSign";
            this.txtSign.Size = new System.Drawing.Size(106, 23);
            this.txtSign.TabIndex = 1000000003;
            // 
            // m_cmbsign
            // 
            this.m_cmbsign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmbsign.DefaultScheme = true;
            this.m_cmbsign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmbsign.Hint = "";
            this.m_cmbsign.Location = new System.Drawing.Point(14, 469);
            this.m_cmbsign.Name = "m_cmbsign";
            this.m_cmbsign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmbsign.Size = new System.Drawing.Size(64, 32);
            this.m_cmbsign.TabIndex = 1000000002;
            this.m_cmbsign.Text = "签名";
            // 
            // frmSubICUBreath
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.CancelButton = this.m_cmdCancel;
            this.ClientSize = new System.Drawing.Size(830, 515);
            this.Controls.Add(this.txtSign);
            this.Controls.Add(this.m_cmbsign);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_lblSign);
            this.Controls.Add(this.m_cmdCancel);
            this.Controls.Add(this.m_cmdOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSubICUBreath";
            this.Text = "中心ICU呼吸机治疗监护记录单";
            this.Load += new System.EventHandler(this.frmSubICUBreath_Load);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_lblGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_dtpGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_cmdOK, 0);
            this.Controls.SetChildIndex(this.m_cmdCancel, 0);
            this.Controls.SetChildIndex(this.m_lblSign, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
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
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.Controls.SetChildIndex(this.m_cmbsign, 0);
            this.Controls.SetChildIndex(this.txtSign, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmSubICUBreath_Load(object sender, System.EventArgs e)
		{
//			m_cmdNewTemplate.Left=m_cmdOK.Left-m_cmdNewTemplate.Width+(m_cmdOK.Right-m_cmdCancel.Left);
//			m_cmdNewTemplate.Top=m_cmdOK.Top;
//			m_cmdNewTemplate.Visible=true;	

			this.m_dtpCreateDate.m_EnmVisibleFlag=MDIParent.s_ObjRecordDateTimeInfo.m_enmGetRecordTimeFlag(this.Name);
			this.m_dtpCreateDate.m_mthResetSize();

			m_txtMachineMode.Focus();
		}

		public override iCare.clsDiseaseTrackInfo m_objGetDiseaseTrackInfo()
		{
			clsICUBreathInfo objTrackInfo = new clsICUBreathInfo();

			objTrackInfo.m_ObjRecordContent = m_objICUBreathContent;//m_objGetContentFromGUI();
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
			m_lblSign.Text = "";
			//清空具体记录内容			
			m_mthClearUp2();
            //默认签名
            MDIParent.m_mthSetDefaulEmployee(txtSign);
            //m_objSignTool.m_mthSetDefaulEmployee();
		}

		private void m_mthClearUp2()
		{
			m_txtMachineMode.m_mthClearText();
			m_txtBreathSoundLeft.m_mthClearText();
			m_txtBreathSoundRight.m_mthClearText();
			m_txtInLength.m_mthClearText();
			m_txtGasbagPress.m_mthClearText();
			m_txtTIDAL_VOLUME.m_mthClearText();
			m_txtRATE.m_mthClearText();
			m_txtPEAK_FLOW.m_mthClearText();
			m_txtO2.m_mthClearText();
			m_txtPS.m_mthClearText();
			m_txtASSIST_SENSITIVITY.m_mthClearText();
			m_txtINSPIRATORY_PAUSE.m_mthClearText();
			m_txtMMV_LEVEL.m_mthClearText();
			m_txtCOMPLIANCE_COMP.m_mthClearText();
			m_txtINSPIRATORY_TIME.m_mthClearText();
			m_txtINSPIRATORY_PRESSURE.m_mthClearText();
			m_txtBASE_FLOW.m_mthClearText();
			m_txtFLOW_TRIGGER.m_mthClearText();
			m_txtPRESSURE_SLOPE.m_mthClearText();
			m_txtPEEP.m_mthClearText();
			m_txtTIDAL_VOL.m_mthClearText();
			m_txtTOTAL_MV.m_mthClearText();
			m_txtSPONT_MV.m_mthClearText();
			m_txtTOTAL.m_mthClearText();
			m_txtSPONT.m_mthClearText();
			m_txtI_E_RATIO.m_mthClearText();
			m_txtTi.m_mthClearText();
			m_txtMMV.m_mthClearText();
			m_txtPEAR.m_mthClearText();
			m_txtMEAN.m_mthClearText();
			m_txtPLATEAU.m_mthClearText();

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
					control.Top=control.Top-135;			
				}
			
				m_cmdOK.Visible=true;
				m_cmdCancel.Visible=true;
				
				this.Size=new Size(this.Size.Width, this.Size.Height-135);
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
			clsICUBreathContent objContent=(clsICUBreathContent )p_objContent;
			//把表单值赋值到界面，由子窗体重载实现			
			m_mthClearUp2();
			
			m_txtMachineMode.m_mthSetNewText(objContent.m_strMachineMode,objContent.m_strMachineModeXML);
			m_txtBreathSoundLeft.m_mthSetNewText(objContent.m_strBreathSoundLeft,objContent.m_strBreathSoundLeftXML);
			m_txtBreathSoundRight.m_mthSetNewText(objContent.m_strBreathSoundRight,objContent.m_strBreathSoundRightXML);
			m_txtInLength.m_mthSetNewText(objContent.m_strInLength,objContent.m_strInLengthXML);
			m_txtGasbagPress.m_mthSetNewText(objContent.m_strGasbagPress,objContent.m_strGasbagPressXML);
			m_txtTIDAL_VOLUME.m_mthSetNewText(objContent.m_strTIDAL_VOLUME,objContent.m_strTIDAL_VOLUMEXML);
			m_txtRATE.m_mthSetNewText(objContent.m_strRATE,objContent.m_strRATEXML);
			m_txtPEAK_FLOW.m_mthSetNewText(objContent.m_strPEAK_FLOW,objContent.m_strPEAK_FLOWXML);
			m_txtO2.m_mthSetNewText(objContent.m_strO2,objContent.m_strO2XML);
			m_txtPS.m_mthSetNewText(objContent.m_strPS,objContent.m_strPSXML);
			m_txtASSIST_SENSITIVITY.m_mthSetNewText(objContent.m_strASSIST_SENSITIVITY,objContent.m_strASSIST_SENSITIVITYXML);
			m_txtINSPIRATORY_PAUSE.m_mthSetNewText(objContent.m_strINSPIRATORY_PAUSE,objContent.m_strINSPIRATORY_PAUSEXML);
			m_txtMMV_LEVEL.m_mthSetNewText(objContent.m_strMMV_LEVEL,objContent.m_strMMV_LEVELXML);
			m_txtCOMPLIANCE_COMP.m_mthSetNewText(objContent.m_strCOMPLIANCE_COMP,objContent.m_strCOMPLIANCE_COMPXML);
			m_txtINSPIRATORY_TIME.m_mthSetNewText(objContent.m_strINSPIRATORY_TIME,objContent.m_strINSPIRATORY_TIMEXML);
			m_txtINSPIRATORY_PRESSURE.m_mthSetNewText(objContent.m_strINSPIRATORY_PRESSURE,objContent.m_strINSPIRATORY_PRESSUREXML);
			m_txtBASE_FLOW.m_mthSetNewText(objContent.m_strBASE_FLOW,objContent.m_strBASE_FLOWXML);
			m_txtFLOW_TRIGGER.m_mthSetNewText(objContent.m_strFLOW_TRIGGER,objContent.m_strFLOW_TRIGGERXML);
			m_txtPRESSURE_SLOPE.m_mthSetNewText(objContent.m_strPRESSURE_SLOPE,objContent.m_strPRESSURE_SLOPEXML);
			m_txtPEEP.m_mthSetNewText(objContent.m_strPEEP,objContent.m_strPEEPXML);
			m_txtTIDAL_VOL.m_mthSetNewText(objContent.m_strTIDAL_VOL,objContent.m_strTIDAL_VOLXML);
			m_txtTOTAL_MV.m_mthSetNewText(objContent.m_strTOTAL_MV,objContent.m_strTOTAL_MVXML);
			m_txtSPONT_MV.m_mthSetNewText(objContent.m_strSPONT_MV,objContent.m_strSPONT_MVXML);
			m_txtTOTAL.m_mthSetNewText(objContent.m_strTOTAL,objContent.m_strTOTALXML);
			m_txtSPONT.m_mthSetNewText(objContent.m_strSPONT,objContent.m_strSPONTXML);
			m_txtI_E_RATIO.m_mthSetNewText(objContent.m_strI_E_RATIO,objContent.m_strI_E_RATIOXML);
			m_txtTi.m_mthSetNewText(objContent.m_strTi,objContent.m_strTiXML);
			m_txtMMV.m_mthSetNewText(objContent.m_strMMV,objContent.m_strMMVXML);
			m_txtPEAR.m_mthSetNewText(objContent.m_strPEAR,objContent.m_strPEARXML);
			m_txtMEAN.m_mthSetNewText(objContent.m_strMEAN,objContent.m_strMEANXML);
			m_txtPLATEAU.m_mthSetNewText(objContent.m_strPLATEAU,objContent.m_strPLATEAUXML);
            m_mthAddSignToTextBoxByEmpNo(new TextBoxBase[] { txtSign, }, new string[] { objContent.m_strCreateUserID }, new bool[] { false });
            //根据工号获取签名信息
            //出于兼容考虑，过渡使用 tfzhang 2006-03-12
            //com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
            //clsEmrEmployeeBase_VO objSign = new clsEmrEmployeeBase_VO();
            //objEmployeeSign.m_lngGetEmpByNO(objContent.m_strCreateUserID.Trim(), out objSign);
            //if (objSign != null)
            //{
            //    txtSign.Text = objSign.m_strLASTNAME_VCHR;
            //    txtSign.Tag = objSign;
            //}
            //this.txtSign.Enabled = false;
		}

		protected override void m_mthSetDeletedGUIFromContent(iCareData.clsTrackRecordContent p_objContent)
		{
			
		}

		public void m_mthSetGUIFromContentOfLast(iCareData.clsTrackRecordContent p_objContent)
		{
			if(p_objContent==null)return;
			clsICUBreathContent objContent=(clsICUBreathContent )p_objContent;
			//把表单值赋值到界面，由子窗体重载实现			
			m_mthClearUp2();
			
			m_txtMachineMode.m_mthSetNewText(objContent.m_strMachineMode_Last,"");
			m_txtBreathSoundLeft.m_mthSetNewText(objContent.m_strBreathSoundLeft_Last,"");
			m_txtBreathSoundRight.m_mthSetNewText(objContent.m_strBreathSoundRight_Last,"");
			m_txtInLength.m_mthSetNewText(objContent.m_strInLength_Last,"");
			m_txtGasbagPress.m_mthSetNewText(objContent.m_strGasbagPress_Last,"");
			m_txtTIDAL_VOLUME.m_mthSetNewText(objContent.m_strTIDAL_VOLUME_Last,"");
			m_txtRATE.m_mthSetNewText(objContent.m_strRATE_Last,"");
			m_txtPEAK_FLOW.m_mthSetNewText(objContent.m_strPEAK_FLOW_Last,"");
			m_txtO2.m_mthSetNewText(objContent.m_strO2_Last,"");
			m_txtPS.m_mthSetNewText(objContent.m_strPS_Last,"");
			m_txtASSIST_SENSITIVITY.m_mthSetNewText(objContent.m_strASSIST_SENSITIVITY_Last,"");
			m_txtINSPIRATORY_PAUSE.m_mthSetNewText(objContent.m_strINSPIRATORY_PAUSE_Last,"");
			m_txtMMV_LEVEL.m_mthSetNewText(objContent.m_strMMV_LEVEL_Last,"");
			m_txtCOMPLIANCE_COMP.m_mthSetNewText(objContent.m_strCOMPLIANCE_COMP_Last,"");
			m_txtINSPIRATORY_TIME.m_mthSetNewText(objContent.m_strINSPIRATORY_TIME_Last,"");
			m_txtINSPIRATORY_PRESSURE.m_mthSetNewText(objContent.m_strINSPIRATORY_PRESSURE_Last,"");
			m_txtBASE_FLOW.m_mthSetNewText(objContent.m_strBASE_FLOW_Last,"");
			m_txtFLOW_TRIGGER.m_mthSetNewText(objContent.m_strFLOW_TRIGGER_Last,"");
			m_txtPRESSURE_SLOPE.m_mthSetNewText(objContent.m_strPRESSURE_SLOPE_Last,"");
			m_txtPEEP.m_mthSetNewText(objContent.m_strPEEP_Last,"");
			m_txtTIDAL_VOL.m_mthSetNewText(objContent.m_strTIDAL_VOL_Last,"");
			m_txtTOTAL_MV.m_mthSetNewText(objContent.m_strTOTAL_MV_Last,"");
			m_txtSPONT_MV.m_mthSetNewText(objContent.m_strSPONT_MV_Last,"");
			m_txtTOTAL.m_mthSetNewText(objContent.m_strTOTAL_Last,"");
			m_txtSPONT.m_mthSetNewText(objContent.m_strSPONT_Last,"");
			m_txtI_E_RATIO.m_mthSetNewText(objContent.m_strI_E_RATIO_Last,"");
			m_txtTi.m_mthSetNewText(objContent.m_strTi_Last,"");
			m_txtMMV.m_mthSetNewText(objContent.m_strMMV_Last,"");
			m_txtPEAR.m_mthSetNewText(objContent.m_strPEAR_Last,"");
			m_txtMEAN.m_mthSetNewText(objContent.m_strMEAN_Last,"");
			m_txtPLATEAU.m_mthSetNewText(objContent.m_strPLATEAU_Last,"");	
		
			m_lblSign.Text = MDIParent.OperatorName;
		}
		
		protected override iCareData.clsTrackRecordContent m_objGetContentFromGUI()
		{
			//界面参数校验
			if(m_objCurrentPatient==null || m_ObjCurrentEmrPatientSession == null)				
				return null;

			//从界面获取表单值			
			m_objICUBreathContent=new clsICUBreathContent();			
			m_objICUBreathContent.m_dtmCreateDate =m_dtpCreateDate.Value ;
            //m_objICUBreathContent.m_strModifyUserName=this.m_lblSign.Text;
            //m_objICUBreathContent.m_strModifyUserID=MDIParent.strOperatorID;
            //m_objICUBreathContent.m_strModifyUserName = ((clsEmrEmployeeBase_VO)txtSign.Tag).m_strLASTNAME_VCHR;
            //m_objICUBreathContent.m_strModifyUserID = ((clsEmrEmployeeBase_VO)txtSign.Tag).m_strEMPNO_CHR;
            m_objICUBreathContent.m_strModifyUserID = clsEMRLogin.LoginInfo.m_strEmpNo;
            m_objICUBreathContent.m_strModifyUserName = clsEMRLogin.LoginInfo.m_strEmpName;
            //获取签名
            strUserIDList = "";
            strUserNameList = "";
            m_mthGetSignArr(new Control[] { txtSign }, ref m_objICUBreathContent.objSignerArr, ref strUserIDList, ref strUserNameList);
            //m_objICUBreathContent.objSignerArr = new clsEmrSigns_VO[1];
            //m_objICUBreathContent.objSignerArr[0] = new clsEmrSigns_VO();
            //m_objICUBreathContent.objSignerArr[0].objEmployee = new clsEmrEmployeeBase_VO();
            //m_objICUBreathContent.objSignerArr[0].objEmployee = (clsEmrEmployeeBase_VO)(txtSign.Tag);
            //m_objICUBreathContent.objSignerArr[0].controlName = "txtSign";
            //m_objICUBreathContent.objSignerArr[0].m_strFORMID_VCHR = "frmGeneralNurseRecord_GXRec";//注意大小写
            //m_objICUBreathContent.objSignerArr[0].m_strREGISTERID_CHR = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;


			m_objICUBreathContent. m_strMachineMode=m_txtMachineMode.Text;
			m_objICUBreathContent. m_strBreathSoundLeft=m_txtBreathSoundLeft.Text;
			m_objICUBreathContent. m_strBreathSoundRight=m_txtBreathSoundRight.Text;
			m_objICUBreathContent. m_strInLength=m_txtInLength.Text;
			m_objICUBreathContent. m_strGasbagPress=m_txtGasbagPress.Text;
			m_objICUBreathContent. m_strTIDAL_VOLUME=m_txtTIDAL_VOLUME.Text;
			m_objICUBreathContent. m_strRATE=m_txtRATE.Text;
			m_objICUBreathContent. m_strPEAK_FLOW=m_txtPEAK_FLOW.Text;
			m_objICUBreathContent. m_strO2=m_txtO2.Text;
			m_objICUBreathContent. m_strPS=m_txtPS.Text;
			m_objICUBreathContent. m_strASSIST_SENSITIVITY=m_txtASSIST_SENSITIVITY.Text;
			m_objICUBreathContent. m_strINSPIRATORY_PAUSE=m_txtINSPIRATORY_PAUSE.Text;
			m_objICUBreathContent. m_strMMV_LEVEL=m_txtMMV_LEVEL.Text;
			m_objICUBreathContent. m_strCOMPLIANCE_COMP=m_txtCOMPLIANCE_COMP.Text;
			m_objICUBreathContent. m_strINSPIRATORY_TIME=m_txtINSPIRATORY_TIME.Text;
			m_objICUBreathContent. m_strINSPIRATORY_PRESSURE=m_txtINSPIRATORY_PRESSURE.Text;
			m_objICUBreathContent. m_strBASE_FLOW=m_txtBASE_FLOW.Text;
			m_objICUBreathContent. m_strFLOW_TRIGGER=m_txtFLOW_TRIGGER.Text;
			m_objICUBreathContent. m_strPRESSURE_SLOPE=m_txtPRESSURE_SLOPE.Text;
			m_objICUBreathContent. m_strPEEP=m_txtPEEP.Text;
			m_objICUBreathContent. m_strTIDAL_VOL=m_txtTIDAL_VOL.Text;
			m_objICUBreathContent. m_strTOTAL_MV=m_txtTOTAL_MV.Text;
			m_objICUBreathContent. m_strSPONT_MV=m_txtSPONT_MV.Text;
			m_objICUBreathContent. m_strTOTAL=m_txtTOTAL.Text;
			m_objICUBreathContent. m_strSPONT=m_txtSPONT.Text;
			m_objICUBreathContent. m_strI_E_RATIO=m_txtI_E_RATIO.Text;
			m_objICUBreathContent. m_strTi=m_txtTi.Text;
			m_objICUBreathContent. m_strMMV=m_txtMMV.Text;
			m_objICUBreathContent. m_strPEAR=m_txtPEAR.Text;
			m_objICUBreathContent. m_strMEAN=m_txtMEAN.Text;
			m_objICUBreathContent. m_strPLATEAU=m_txtPLATEAU.Text;

			m_objICUBreathContent. m_strMachineModeXML=m_txtMachineMode.m_strGetXmlText();
			m_objICUBreathContent. m_strBreathSoundLeftXML=m_txtBreathSoundLeft.m_strGetXmlText();
			m_objICUBreathContent. m_strBreathSoundRightXML=m_txtBreathSoundRight.m_strGetXmlText();
			m_objICUBreathContent. m_strInLengthXML=m_txtInLength.m_strGetXmlText();
			m_objICUBreathContent. m_strGasbagPressXML=m_txtGasbagPress.m_strGetXmlText();
			m_objICUBreathContent. m_strTIDAL_VOLUMEXML=m_txtTIDAL_VOLUME.m_strGetXmlText();
			m_objICUBreathContent. m_strRATEXML=m_txtRATE.m_strGetXmlText();
			m_objICUBreathContent. m_strPEAK_FLOWXML=m_txtPEAK_FLOW.m_strGetXmlText();
			m_objICUBreathContent. m_strO2XML=m_txtO2.m_strGetXmlText();
			m_objICUBreathContent. m_strPSXML=m_txtPS.m_strGetXmlText();
			m_objICUBreathContent. m_strASSIST_SENSITIVITYXML=m_txtASSIST_SENSITIVITY.m_strGetXmlText();
			m_objICUBreathContent. m_strINSPIRATORY_PAUSEXML=m_txtINSPIRATORY_PAUSE.m_strGetXmlText();
			m_objICUBreathContent. m_strMMV_LEVELXML=m_txtMMV_LEVEL.m_strGetXmlText();
			m_objICUBreathContent. m_strCOMPLIANCE_COMPXML=m_txtCOMPLIANCE_COMP.m_strGetXmlText();
			m_objICUBreathContent. m_strINSPIRATORY_TIMEXML=m_txtINSPIRATORY_TIME.m_strGetXmlText();
			m_objICUBreathContent. m_strINSPIRATORY_PRESSUREXML=m_txtINSPIRATORY_PRESSURE.m_strGetXmlText();
			m_objICUBreathContent. m_strBASE_FLOWXML=m_txtBASE_FLOW.m_strGetXmlText();
			m_objICUBreathContent. m_strFLOW_TRIGGERXML=m_txtFLOW_TRIGGER.m_strGetXmlText();
			m_objICUBreathContent. m_strPRESSURE_SLOPEXML=m_txtPRESSURE_SLOPE.m_strGetXmlText();
			m_objICUBreathContent. m_strPEEPXML=m_txtPEEP.m_strGetXmlText();
			m_objICUBreathContent. m_strTIDAL_VOLXML=m_txtTIDAL_VOL.m_strGetXmlText();
			m_objICUBreathContent. m_strTOTAL_MVXML=m_txtTOTAL_MV.m_strGetXmlText();
			m_objICUBreathContent. m_strSPONT_MVXML=m_txtSPONT_MV.m_strGetXmlText();
			m_objICUBreathContent. m_strTOTALXML=m_txtTOTAL.m_strGetXmlText();
			m_objICUBreathContent. m_strSPONTXML=m_txtSPONT.m_strGetXmlText();
			m_objICUBreathContent. m_strI_E_RATIOXML=m_txtI_E_RATIO.m_strGetXmlText();
			m_objICUBreathContent. m_strTiXML=m_txtTi.m_strGetXmlText();
			m_objICUBreathContent. m_strMMVXML=m_txtMMV.m_strGetXmlText();
			m_objICUBreathContent. m_strPEARXML=m_txtPEAR.m_strGetXmlText();
			m_objICUBreathContent. m_strMEANXML=m_txtMEAN.m_strGetXmlText();
			m_objICUBreathContent. m_strPLATEAUXML=m_txtPLATEAU.m_strGetXmlText();

			m_objICUBreathContent. m_strMachineMode_Last=m_txtMachineMode.m_strGetRightText().Trim();
			m_objICUBreathContent. m_strBreathSoundLeft_Last=m_txtBreathSoundLeft.m_strGetRightText().Trim();
			m_objICUBreathContent. m_strBreathSoundRight_Last=m_txtBreathSoundRight.m_strGetRightText().Trim();
			m_objICUBreathContent. m_strInLength_Last=m_txtInLength.m_strGetRightText().Trim();
			m_objICUBreathContent. m_strGasbagPress_Last=m_txtGasbagPress.m_strGetRightText().Trim();
			m_objICUBreathContent. m_strTIDAL_VOLUME_Last=m_txtTIDAL_VOLUME.m_strGetRightText().Trim();
			m_objICUBreathContent. m_strRATE_Last=m_txtRATE.m_strGetRightText().Trim();
			m_objICUBreathContent. m_strPEAK_FLOW_Last=m_txtPEAK_FLOW.m_strGetRightText().Trim();
			m_objICUBreathContent. m_strO2_Last=m_txtO2.m_strGetRightText().Trim();
			m_objICUBreathContent. m_strPS_Last=m_txtPS.m_strGetRightText().Trim();
			m_objICUBreathContent. m_strASSIST_SENSITIVITY_Last=m_txtASSIST_SENSITIVITY.m_strGetRightText().Trim();
			m_objICUBreathContent. m_strINSPIRATORY_PAUSE_Last=m_txtINSPIRATORY_PAUSE.m_strGetRightText().Trim();
			m_objICUBreathContent. m_strMMV_LEVEL_Last=m_txtMMV_LEVEL.m_strGetRightText().Trim();
			m_objICUBreathContent. m_strCOMPLIANCE_COMP_Last=m_txtCOMPLIANCE_COMP.m_strGetRightText().Trim();
			m_objICUBreathContent. m_strINSPIRATORY_TIME_Last=m_txtINSPIRATORY_TIME.m_strGetRightText().Trim();
			m_objICUBreathContent. m_strINSPIRATORY_PRESSURE_Last=m_txtINSPIRATORY_PRESSURE.m_strGetRightText().Trim();
			m_objICUBreathContent. m_strBASE_FLOW_Last=m_txtBASE_FLOW.m_strGetRightText().Trim();
			m_objICUBreathContent. m_strFLOW_TRIGGER_Last=m_txtFLOW_TRIGGER.m_strGetRightText().Trim();
			m_objICUBreathContent. m_strPRESSURE_SLOPE_Last=m_txtPRESSURE_SLOPE.m_strGetRightText().Trim();
			m_objICUBreathContent. m_strPEEP_Last=m_txtPEEP.m_strGetRightText().Trim();
			m_objICUBreathContent. m_strTIDAL_VOL_Last=m_txtTIDAL_VOL.m_strGetRightText().Trim();
			m_objICUBreathContent. m_strTOTAL_MV_Last=m_txtTOTAL_MV.m_strGetRightText().Trim();
			m_objICUBreathContent. m_strSPONT_MV_Last=m_txtSPONT_MV.m_strGetRightText().Trim();
			m_objICUBreathContent. m_strTOTAL_Last=m_txtTOTAL.m_strGetRightText().Trim();
			m_objICUBreathContent. m_strSPONT_Last=m_txtSPONT.m_strGetRightText().Trim();
			m_objICUBreathContent. m_strI_E_RATIO_Last=m_txtI_E_RATIO.m_strGetRightText().Trim();
			m_objICUBreathContent. m_strTi_Last=m_txtTi.m_strGetRightText().Trim();
			m_objICUBreathContent. m_strMMV_Last=m_txtMMV.m_strGetRightText().Trim();
			m_objICUBreathContent. m_strPEAR_Last=m_txtPEAR.m_strGetRightText().Trim();
			m_objICUBreathContent. m_strMEAN_Last=m_txtMEAN.m_strGetRightText().Trim();
			m_objICUBreathContent. m_strPLATEAU_Last=m_txtPLATEAU.m_strGetRightText().Trim();

			return(m_objICUBreathContent );
		}

		protected override iCare.clsDiseaseTrackDomain m_objGetDiseaseTrackDomain()
		{
			//获取护理记录的领域层实例，由子窗体重载实现
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.ICUBreath);					
		}

		/// <summary>
		/// 把选择时间记录内容重新整理为完全正确的内容。
		/// </summary>
		/// <param name="p_objRecordContent"></param>
		protected override void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
		{
			
		}

		public override string m_strReloadFormTitle()
		{
			//由子窗体重载实现

			return	"中心ICU呼吸机治疗监护记录单";
		}

		private void frmIntensiveTend_Load(object sender, System.EventArgs e)
		{
			
			this.m_dtpCreateDate.m_EnmVisibleFlag=MDIParent.s_ObjRecordDateTimeInfo.m_enmGetRecordTimeFlag(this.Name);
			this.m_dtpCreateDate.m_mthResetSize();

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
	}
}

