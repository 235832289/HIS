using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.Utility.Controls;
using com.digitalwave.Utility;
using iCareData;
using System.Drawing.Printing;
using System.Xml;
using System.IO;
using com.digitalwave.Emr.Signature_gui;
using iCare.ICU.Espial;

namespace iCare
{
	public class frmSubICUIntensiveTend : frmDiseaseTrackBase
	{
		#region Define
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.GroupBox groupBox10;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.DataGrid m_dtgInOral;
		private System.Windows.Forms.DataGrid m_dtgInLiquid;
		private System.Windows.Forms.DataGridTableStyle m_dtsInLiquid;
		private System.Windows.Forms.DataGridTableStyle m_dtsInOral;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dcmDrugName;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dcmDosage;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dcmInOral;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dcmInOralType;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dcmInOralProperty;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dcmInOralQuantity;
		private System.Windows.Forms.Button m_cmdSence;
		private System.Windows.Forms.Button m_cmdDirect1;
		private System.Windows.Forms.Button m_cmdDirect3;
		private System.Windows.Forms.Button m_cmdDirect2;
		private System.Windows.Forms.Button m_cmdSkin;
		private System.Windows.Forms.Button m_cmdBreathLeft;
		private System.Windows.Forms.Button m_cmdBreathRight;
        private com.digitalwave.controls.ctlRichTextBox m_txtConsciousness;
		private PinkieControls.ButtonXP m_cmdClose;
		private System.Windows.Forms.Label m_lblSign;
		private PinkieControls.ButtonXP cmdConfirm;
		private com.digitalwave.controls.ctlRichTextBox m_txtDirect1;
		private com.digitalwave.controls.ctlRichTextBox m_txtDirect3;
		private com.digitalwave.controls.ctlRichTextBox m_txtDirect2;
		private com.digitalwave.controls.ctlRichTextBox m_txtSkin;
		private com.digitalwave.controls.ctlRichTextBox m_txtBreathSoundLeft;
		private com.digitalwave.controls.ctlRichTextBox m_txtBreathSoundRight;
		private com.digitalwave.controls.ctlRichTextBox m_txtMachineMode;
		private System.Windows.Forms.Label lblMachineMode;
		private com.digitalwave.controls.ctlRichTextBox m_txtBp;
		private com.digitalwave.controls.ctlRichTextBox m_txtR;
		private com.digitalwave.controls.ctlRichTextBox m_txtBloodSugar;
		private com.digitalwave.controls.ctlRichTextBox m_txtP;
		private com.digitalwave.controls.ctlRichTextBox m_txtCVP;
		private com.digitalwave.controls.ctlRichTextBox m_txtT;
		private com.digitalwave.controls.ctlRichTextBox m_txtReflectRight;
		private com.digitalwave.controls.ctlRichTextBox m_txtReflectLeft;
		private com.digitalwave.controls.ctlRichTextBox m_txtPupilSizeRight;
		private com.digitalwave.controls.ctlRichTextBox m_txtPupilSizeLeft;
		private com.digitalwave.controls.ctlRichTextBox m_txtSputumQuantity;
		private com.digitalwave.controls.ctlRichTextBox m_txtSputumProperty;
//		private PinkieControls.ButtonXP cmdDrugSubmit;
		private com.digitalwave.controls.ctlRichTextBox m_txtDrugName;
		private com.digitalwave.controls.ctlRichTextBox m_txtDrugDosage;
//		private PinkieControls.ButtonXP m_cmdInOralSubmit;
		private com.digitalwave.controls.ctlRichTextBox m_txtInOral;
		private com.digitalwave.controls.ctlRichTextBox m_txtStomachQuantity;
		private com.digitalwave.controls.ctlRichTextBox m_txtStomachProperty;
		private com.digitalwave.controls.ctlRichTextBox m_txtLeadQuantity;
		private com.digitalwave.controls.ctlRichTextBox m_txtLeadProperty;
		private com.digitalwave.controls.ctlRichTextBox m_txtPeeQuantity;
		private com.digitalwave.controls.ctlRichTextBox m_txtPeeProperty;
		private com.digitalwave.controls.ctlRichTextBox m_txtDefecateQuantity;
		private com.digitalwave.controls.ctlRichTextBox m_txtDefecateProperty;
		private com.digitalwave.controls.ctlRichTextBox m_txtCaseHistory;
		private System.Windows.Forms.MenuItem mniRemove;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.ContextMenu ctmInOral;
		private System.Windows.Forms.ContextMenu ctmInLiquid;
		private System.Windows.Forms.GroupBox m_gpbInLiquid;
		private System.Windows.Forms.GroupBox m_gpbInOral;
		private PinkieControls.ButtonXP m_cmdGetDovueData;
		private com.digitalwave.controls.ctlRichTextBox m_txtHR;
		private System.Windows.Forms.Label label1;
		private com.digitalwave.controls.ctlRichTextBox m_txtBp2;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Button m_cmdReflectLeft;
		private System.Windows.Forms.Button m_cmdReflectRight;
		private com.digitalwave.controls.ctlRichTextBox m_txtPower;
		private System.Windows.Forms.Button m_cmdStomachProperty;
		private System.Windows.Forms.Button m_cmdStomachPipe;
		private System.Windows.Forms.Button m_cmdDrugName;
		private System.Windows.Forms.Button m_cmdInOral;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Button m_cmdInOralType;
		private com.digitalwave.controls.ctlRichTextBox m_txtInOralType;
		private System.Windows.Forms.Button m_cmdInOralProperty;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Button m_cmdPeeProperty;
		private System.Windows.Forms.Button m_cmdDefecateProperty;
		private System.Windows.Forms.Button m_cmdLeadProperty;
		private System.Windows.Forms.Button m_cmdLeadPipe;
		private com.digitalwave.controls.ctlRichTextBox m_txtTakeFood;
		private com.digitalwave.controls.ctlRichTextBox m_txtTransfusion;
		private com.digitalwave.controls.ctlRichTextBox m_txtInOralProperty;
		private com.digitalwave.controls.ctlRichTextBox m_txtLeadPipe;
		private com.digitalwave.controls.ctlRichTextBox m_txtInOralQuantity;
		private com.digitalwave.controls.ctlRichTextBox m_txtStomachPipe;
		private System.Windows.Forms.Label label25;
		private com.digitalwave.controls.ctlRichTextBox m_txtDefecateTimes;
		private System.Windows.Forms.MenuItem mniInsert;
		private System.Windows.Forms.MenuItem mniEdit;
		private System.Windows.Forms.MenuItem mniInsertInoral;
		private System.Windows.Forms.MenuItem mniEditInOral;
		private System.Windows.Forms.Button m_cmdPower;
		private System.Windows.Forms.Button m_cmdSputumProperty;
        private PinkieControls.ButtonXP m_cmdGetGEData;
//		private System.Windows.Forms.DataGridTextBoxColumn m_dcmInOralType;
//		private System.Windows.Forms.DataGridTextBoxColumn m_dcmInOralProperty;
//		private System.Windows.Forms.DataGridTextBoxColumn m_dcmInOralQuantity;
		private System.ComponentModel.IContainer components = null;

		#endregion

		private clsEmployeeSignTool m_objSignTool;
		private System.Windows.Forms.GroupBox groupBox11;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.Label label45;
		private PinkieControls.ButtonXP m_cmdInOralSubmit;
		private PinkieControls.ButtonXP cmdDrugSubmit;
		private clsCommonUseToolCollection m_objCUTC;
        private TextBox txtSign;
        private PinkieControls.ButtonXP m_cmbsign;

		/// <summary>
		/// 接收数据类
		/// </summary>
		protected clsICUGESimulateGetData m_objICUGESimulateGetData;

        //定义签名类
        private clsEmrSignToolCollection m_objSign;
		public frmSubICUIntensiveTend()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
			#region DataTable Init
            //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{m_dtgInLiquid,m_dtgInOral});	
			m_dtbInLiquid=new DataTable("InLiquid");
			m_dtbInOral=new DataTable("InOral");
			this.m_dtbInLiquid.Columns.Add("药名",typeof(clsDSTRichTextBoxValue));
			this.m_dtbInLiquid.Columns.Add("剂量",typeof(clsDSTRichTextBoxValue));
			this.m_dtgInLiquid.DataSource=m_dtbInLiquid ;
			this.m_dtbInOral.Columns.Add("类型",typeof(clsDSTRichTextBoxValue));
			this.m_dtbInOral.Columns.Add("药名",typeof(clsDSTRichTextBoxValue));
			this.m_dtbInOral.Columns.Add("性质",typeof(clsDSTRichTextBoxValue));
			this.m_dtbInOral.Columns.Add("量",typeof(clsDSTRichTextBoxValue));
			this.m_dtgInOral.DataSource=m_dtbInOral;
			#endregion
			m_mthSetRichTextBoxAttribInControl(this);
			m_txtTemp = new com.digitalwave.controls.ctlRichTextBox();	
		
            //m_objSignTool = new clsEmployeeSignTool(m_lsvEmployee);
            //m_objSignTool.m_mthAddControl(m_txtSign);

			m_objCUTC = new clsCommonUseToolCollection(this);
			m_objCUTC.m_mthBindControl(m_cmdCommonUseArr(),m_txtCommonUseArr(),m_enmCommonUseArr());

			m_objICUGESimulateGetData=new clsICUGESimulateGetData(this);

            //签名常用值
            m_objSign = new clsEmrSignToolCollection();

            //可以指定员工ID如
            m_objSign.m_mthBindEmployeeSign(m_cmbsign, txtSign, 2, true, clsEMRLogin.LoginInfo.m_strEmpID);

		}

		public override int m_IntFormID
		{
			get
			{
				return 18;
			}
		}

		private DataTable m_dtbInLiquid;
		private DataTable m_dtbInOral;
		private com.digitalwave.controls.ctlRichTextBox m_txtTemp;

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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_txtBreathSoundRight = new com.digitalwave.controls.ctlRichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtMachineMode = new com.digitalwave.controls.ctlRichTextBox();
            this.lblMachineMode = new System.Windows.Forms.Label();
            this.m_cmdBreathLeft = new System.Windows.Forms.Button();
            this.m_txtBreathSoundLeft = new com.digitalwave.controls.ctlRichTextBox();
            this.m_cmdBreathRight = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.m_txtBp2 = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtHR = new com.digitalwave.controls.ctlRichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.m_txtBp = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtR = new com.digitalwave.controls.ctlRichTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.m_txtBloodSugar = new com.digitalwave.controls.ctlRichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.m_txtP = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtCVP = new com.digitalwave.controls.ctlRichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtT = new com.digitalwave.controls.ctlRichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.m_txtPower = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtReflectRight = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtReflectLeft = new com.digitalwave.controls.ctlRichTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.m_txtPupilSizeRight = new com.digitalwave.controls.ctlRichTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.m_txtPupilSizeLeft = new com.digitalwave.controls.ctlRichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtConsciousness = new com.digitalwave.controls.ctlRichTextBox();
            this.m_cmdPower = new System.Windows.Forms.Button();
            this.m_cmdReflectRight = new System.Windows.Forms.Button();
            this.m_cmdReflectLeft = new System.Windows.Forms.Button();
            this.m_cmdSence = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label40 = new System.Windows.Forms.Label();
            this.m_txtSputumQuantity = new com.digitalwave.controls.ctlRichTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.m_txtSputumProperty = new com.digitalwave.controls.ctlRichTextBox();
            this.m_cmdSputumProperty = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label24 = new System.Windows.Forms.Label();
            this.m_txtTakeFood = new com.digitalwave.controls.ctlRichTextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.m_txtTransfusion = new com.digitalwave.controls.ctlRichTextBox();
            this.m_gpbInOral = new System.Windows.Forms.GroupBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.m_txtInOralType = new com.digitalwave.controls.ctlRichTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.m_txtInOralQuantity = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtInOralProperty = new com.digitalwave.controls.ctlRichTextBox();
            this.m_dtgInOral = new System.Windows.Forms.DataGrid();
            this.ctmInOral = new System.Windows.Forms.ContextMenu();
            this.mniInsertInoral = new System.Windows.Forms.MenuItem();
            this.mniEditInOral = new System.Windows.Forms.MenuItem();
            this.mniRemove = new System.Windows.Forms.MenuItem();
            this.m_dtsInOral = new System.Windows.Forms.DataGridTableStyle();
            this.m_dcmInOralType = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dcmInOral = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dcmInOralProperty = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dcmInOralQuantity = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_txtInOral = new com.digitalwave.controls.ctlRichTextBox();
            this.m_cmdInOralSubmit = new PinkieControls.ButtonXP();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.m_txtStomachPipe = new com.digitalwave.controls.ctlRichTextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.m_txtStomachQuantity = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtStomachProperty = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtDirect1 = new com.digitalwave.controls.ctlRichTextBox();
            this.m_gpbInLiquid = new System.Windows.Forms.GroupBox();
            this.m_dtgInLiquid = new System.Windows.Forms.DataGrid();
            this.m_dtsInLiquid = new System.Windows.Forms.DataGridTableStyle();
            this.m_dcmDrugName = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dcmDosage = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.m_txtDrugName = new com.digitalwave.controls.ctlRichTextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.m_txtDrugDosage = new com.digitalwave.controls.ctlRichTextBox();
            this.cmdDrugSubmit = new PinkieControls.ButtonXP();
            this.m_cmdDrugName = new System.Windows.Forms.Button();
            this.m_cmdInOralType = new System.Windows.Forms.Button();
            this.m_cmdInOralProperty = new System.Windows.Forms.Button();
            this.m_cmdInOral = new System.Windows.Forms.Button();
            this.m_cmdStomachPipe = new System.Windows.Forms.Button();
            this.m_cmdStomachProperty = new System.Windows.Forms.Button();
            this.m_cmdDirect1 = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label44 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.m_txtLeadPipe = new com.digitalwave.controls.ctlRichTextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.m_txtLeadQuantity = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtLeadProperty = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtDirect3 = new com.digitalwave.controls.ctlRichTextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label41 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.m_txtPeeQuantity = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtPeeProperty = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtDirect2 = new com.digitalwave.controls.ctlRichTextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label42 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.m_txtDefecateTimes = new com.digitalwave.controls.ctlRichTextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.m_txtDefecateQuantity = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtDefecateProperty = new com.digitalwave.controls.ctlRichTextBox();
            this.m_cmdLeadPipe = new System.Windows.Forms.Button();
            this.m_cmdLeadProperty = new System.Windows.Forms.Button();
            this.m_cmdDirect3 = new System.Windows.Forms.Button();
            this.m_cmdPeeProperty = new System.Windows.Forms.Button();
            this.m_cmdDirect2 = new System.Windows.Forms.Button();
            this.m_cmdDefecateProperty = new System.Windows.Forms.Button();
            this.m_txtSkin = new com.digitalwave.controls.ctlRichTextBox();
            this.m_cmdSkin = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.m_txtCaseHistory = new com.digitalwave.controls.ctlRichTextBox();
            this.m_cmdClose = new PinkieControls.ButtonXP();
            this.m_lblSign = new System.Windows.Forms.Label();
            this.cmdConfirm = new PinkieControls.ButtonXP();
            this.ctmInLiquid = new System.Windows.Forms.ContextMenu();
            this.mniInsert = new System.Windows.Forms.MenuItem();
            this.mniEdit = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.m_cmdGetDovueData = new PinkieControls.ButtonXP();
            this.m_cmdGetGEData = new PinkieControls.ButtonXP();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.label45 = new System.Windows.Forms.Label();
            this.txtSign = new System.Windows.Forms.TextBox();
            this.m_cmbsign = new PinkieControls.ButtonXP();
            this.m_pnlNewBase.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.m_gpbInOral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgInOral)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.m_gpbInLiquid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgInLiquid)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_trvCreateDate
            // 
            this.m_trvCreateDate.LineColor = System.Drawing.Color.Black;
            this.m_trvCreateDate.Location = new System.Drawing.Point(14, 79);
            this.m_trvCreateDate.Size = new System.Drawing.Size(212, 40);
            this.m_trvCreateDate.Visible = false;
            // 
            // lblCreateDateTitle
            // 
            this.lblCreateDateTitle.Location = new System.Drawing.Point(12, 120);
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.Location = new System.Drawing.Point(88, 116);
            this.m_dtpCreateDate.Size = new System.Drawing.Size(144, 22);
            this.m_dtpCreateDate.TabIndex = 100;
            // 
            // m_dtpGetDataTime
            // 
            this.m_dtpGetDataTime.Location = new System.Drawing.Point(88, 163);
            this.m_dtpGetDataTime.Visible = true;
            // 
            // m_lblGetDataTime
            // 
            this.m_lblGetDataTime.Location = new System.Drawing.Point(0, 163);
            this.m_lblGetDataTime.Visible = true;
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(202, 79);
            this.lblSex.Size = new System.Drawing.Size(40, 19);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(146, 64);
            this.lblAge.Size = new System.Drawing.Size(44, 19);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(188, 79);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(169, 80);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(155, 79);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(155, 81);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(140, 81);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(9, 95);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(824, 100);
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(122, 73);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(108, 72);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(110, 80);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(-6, 76);
            this.m_cboArea.Size = new System.Drawing.Size(248, 23);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(143, 67);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(120, 64);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(48, 80);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(48, 95);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(152, 67);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdNext.Location = new System.Drawing.Point(58, 75);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdPre.Location = new System.Drawing.Point(74, 82);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(218, 81);
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(472, 620);
            this.chkModifyWithoutMatk.Size = new System.Drawing.Size(96, 24);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(575, -31);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Controls.Add(this.groupBox1);
            this.m_pnlNewBase.Visible = true;
            this.m_pnlNewBase.Controls.SetChildIndex(this.groupBox1, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_ctlPatientInfo, 0);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_txtBreathSoundRight);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.m_txtMachineMode);
            this.groupBox1.Controls.Add(this.lblMachineMode);
            this.groupBox1.Location = new System.Drawing.Point(585, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 68);
            this.groupBox1.TabIndex = 110;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "呼吸机各项参数";
            this.groupBox1.Visible = false;
            // 
            // m_txtBreathSoundRight
            // 
            this.m_txtBreathSoundRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtBreathSoundRight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtBreathSoundRight.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBreathSoundRight.ForeColor = System.Drawing.Color.White;
            this.m_txtBreathSoundRight.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBreathSoundRight.Location = new System.Drawing.Point(224, 52);
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
            this.m_txtBreathSoundRight.Size = new System.Drawing.Size(96, 24);
            this.m_txtBreathSoundRight.TabIndex = 160;
            this.m_txtBreathSoundRight.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 6077;
            this.label2.Text = "呼吸音";
            // 
            // m_txtMachineMode
            // 
            this.m_txtMachineMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtMachineMode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtMachineMode.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtMachineMode.ForeColor = System.Drawing.Color.White;
            this.m_txtMachineMode.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtMachineMode.Location = new System.Drawing.Point(224, 24);
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
            this.m_txtMachineMode.Size = new System.Drawing.Size(96, 24);
            this.m_txtMachineMode.TabIndex = 120;
            this.m_txtMachineMode.Text = "";
            // 
            // lblMachineMode
            // 
            this.lblMachineMode.AutoSize = true;
            this.lblMachineMode.Location = new System.Drawing.Point(8, 28);
            this.lblMachineMode.Name = "lblMachineMode";
            this.lblMachineMode.Size = new System.Drawing.Size(182, 14);
            this.lblMachineMode.TabIndex = 6071;
            this.lblMachineMode.Text = "通气方式、插管深度、模式:";
            // 
            // m_cmdBreathLeft
            // 
            this.m_cmdBreathLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdBreathLeft.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdBreathLeft.Location = new System.Drawing.Point(132, 72);
            this.m_cmdBreathLeft.Name = "m_cmdBreathLeft";
            this.m_cmdBreathLeft.Size = new System.Drawing.Size(40, 28);
            this.m_cmdBreathLeft.TabIndex = 130;
            this.m_cmdBreathLeft.Text = "左:";
            this.m_cmdBreathLeft.Visible = false;
            // 
            // m_txtBreathSoundLeft
            // 
            this.m_txtBreathSoundLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtBreathSoundLeft.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtBreathSoundLeft.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBreathSoundLeft.ForeColor = System.Drawing.Color.White;
            this.m_txtBreathSoundLeft.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBreathSoundLeft.Location = new System.Drawing.Point(126, 98);
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
            this.m_txtBreathSoundLeft.Size = new System.Drawing.Size(72, 24);
            this.m_txtBreathSoundLeft.TabIndex = 140;
            this.m_txtBreathSoundLeft.Text = "";
            this.m_txtBreathSoundLeft.Visible = false;
            // 
            // m_cmdBreathRight
            // 
            this.m_cmdBreathRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdBreathRight.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdBreathRight.Location = new System.Drawing.Point(172, 74);
            this.m_cmdBreathRight.Name = "m_cmdBreathRight";
            this.m_cmdBreathRight.Size = new System.Drawing.Size(40, 28);
            this.m_cmdBreathRight.TabIndex = 150;
            this.m_cmdBreathRight.Text = "右:";
            this.m_cmdBreathRight.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.m_txtBp2);
            this.groupBox2.Controls.Add(this.m_txtHR);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.m_txtBp);
            this.groupBox2.Controls.Add(this.m_txtR);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.m_txtBloodSugar);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.m_txtP);
            this.groupBox2.Controls.Add(this.m_txtCVP);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.m_txtT);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(304, 116);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(508, 76);
            this.groupBox2.TabIndex = 110;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "生命体征";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(85, 52);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(14, 14);
            this.label18.TabIndex = 6093;
            this.label18.Text = "/";
            // 
            // m_txtBp2
            // 
            this.m_txtBp2.BackColor = System.Drawing.Color.White;
            this.m_txtBp2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBp2.ForeColor = System.Drawing.Color.Black;
            this.m_txtBp2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBp2.Location = new System.Drawing.Point(100, 48);
            this.m_txtBp2.m_BlnIgnoreUserInfo = false;
            this.m_txtBp2.m_BlnPartControl = false;
            this.m_txtBp2.m_BlnReadOnly = false;
            this.m_txtBp2.m_BlnUnderLineDST = false;
            this.m_txtBp2.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBp2.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBp2.m_IntCanModifyTime = 6;
            this.m_txtBp2.m_IntPartControlLength = 0;
            this.m_txtBp2.m_IntPartControlStartIndex = 0;
            this.m_txtBp2.m_StrUserID = "";
            this.m_txtBp2.m_StrUserName = "";
            this.m_txtBp2.Multiline = false;
            this.m_txtBp2.Name = "m_txtBp2";
            this.m_txtBp2.Size = new System.Drawing.Size(44, 21);
            this.m_txtBp2.TabIndex = 215;
            this.m_txtBp2.Text = "";
            // 
            // m_txtHR
            // 
            this.m_txtHR.BackColor = System.Drawing.Color.White;
            this.m_txtHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtHR.ForeColor = System.Drawing.Color.Black;
            this.m_txtHR.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtHR.Location = new System.Drawing.Point(156, 20);
            this.m_txtHR.m_BlnIgnoreUserInfo = false;
            this.m_txtHR.m_BlnPartControl = false;
            this.m_txtHR.m_BlnReadOnly = false;
            this.m_txtHR.m_BlnUnderLineDST = false;
            this.m_txtHR.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtHR.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtHR.m_IntCanModifyTime = 6;
            this.m_txtHR.m_IntPartControlLength = 0;
            this.m_txtHR.m_IntPartControlStartIndex = 0;
            this.m_txtHR.m_StrUserID = "";
            this.m_txtHR.m_StrUserName = "";
            this.m_txtHR.Multiline = false;
            this.m_txtHR.Name = "m_txtHR";
            this.m_txtHR.Size = new System.Drawing.Size(40, 21);
            this.m_txtHR.TabIndex = 185;
            this.m_txtHR.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(204, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 6091;
            this.label1.Text = "bpm    P:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(370, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(10, 9);
            this.label12.TabIndex = 6089;
            this.label12.Text = "2";
            // 
            // m_txtBp
            // 
            this.m_txtBp.BackColor = System.Drawing.Color.White;
            this.m_txtBp.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBp.ForeColor = System.Drawing.Color.Black;
            this.m_txtBp.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBp.Location = new System.Drawing.Point(38, 48);
            this.m_txtBp.m_BlnIgnoreUserInfo = false;
            this.m_txtBp.m_BlnPartControl = false;
            this.m_txtBp.m_BlnReadOnly = false;
            this.m_txtBp.m_BlnUnderLineDST = false;
            this.m_txtBp.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBp.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBp.m_IntCanModifyTime = 6;
            this.m_txtBp.m_IntPartControlLength = 0;
            this.m_txtBp.m_IntPartControlStartIndex = 0;
            this.m_txtBp.m_StrUserID = "";
            this.m_txtBp.m_StrUserName = "";
            this.m_txtBp.Multiline = false;
            this.m_txtBp.Name = "m_txtBp";
            this.m_txtBp.Size = new System.Drawing.Size(44, 21);
            this.m_txtBp.TabIndex = 210;
            this.m_txtBp.Text = "";
            // 
            // m_txtR
            // 
            this.m_txtR.BackColor = System.Drawing.Color.White;
            this.m_txtR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtR.ForeColor = System.Drawing.Color.Black;
            this.m_txtR.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtR.Location = new System.Drawing.Point(408, 20);
            this.m_txtR.m_BlnIgnoreUserInfo = false;
            this.m_txtR.m_BlnPartControl = false;
            this.m_txtR.m_BlnReadOnly = false;
            this.m_txtR.m_BlnUnderLineDST = false;
            this.m_txtR.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtR.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtR.m_IntCanModifyTime = 6;
            this.m_txtR.m_IntPartControlLength = 0;
            this.m_txtR.m_IntPartControlStartIndex = 0;
            this.m_txtR.m_StrUserID = "";
            this.m_txtR.m_StrUserName = "";
            this.m_txtR.Multiline = false;
            this.m_txtR.Name = "m_txtR";
            this.m_txtR.Size = new System.Drawing.Size(40, 21);
            this.m_txtR.TabIndex = 200;
            this.m_txtR.Text = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(456, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 14);
            this.label11.TabIndex = 6086;
            this.label11.Text = "bpm";
            // 
            // m_txtBloodSugar
            // 
            this.m_txtBloodSugar.BackColor = System.Drawing.Color.White;
            this.m_txtBloodSugar.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBloodSugar.ForeColor = System.Drawing.Color.Black;
            this.m_txtBloodSugar.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBloodSugar.Location = new System.Drawing.Point(381, 48);
            this.m_txtBloodSugar.m_BlnIgnoreUserInfo = false;
            this.m_txtBloodSugar.m_BlnPartControl = false;
            this.m_txtBloodSugar.m_BlnReadOnly = false;
            this.m_txtBloodSugar.m_BlnUnderLineDST = false;
            this.m_txtBloodSugar.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBloodSugar.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBloodSugar.m_IntCanModifyTime = 6;
            this.m_txtBloodSugar.m_IntPartControlLength = 0;
            this.m_txtBloodSugar.m_IntPartControlStartIndex = 0;
            this.m_txtBloodSugar.m_StrUserID = "";
            this.m_txtBloodSugar.m_StrUserName = "";
            this.m_txtBloodSugar.Multiline = false;
            this.m_txtBloodSugar.Name = "m_txtBloodSugar";
            this.m_txtBloodSugar.Size = new System.Drawing.Size(64, 21);
            this.m_txtBloodSugar.TabIndex = 230;
            this.m_txtBloodSugar.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(448, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 14);
            this.label10.TabIndex = 6084;
            this.label10.Text = "mmol/L";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(283, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 14);
            this.label9.TabIndex = 6083;
            this.label9.Text = "cmH O 血糖:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(147, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 14);
            this.label8.TabIndex = 6082;
            this.label8.Text = "mmHg CVP:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 14);
            this.label7.TabIndex = 6081;
            this.label7.Text = "Bp:";
            // 
            // m_txtP
            // 
            this.m_txtP.BackColor = System.Drawing.Color.White;
            this.m_txtP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtP.ForeColor = System.Drawing.Color.Black;
            this.m_txtP.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtP.Location = new System.Drawing.Point(282, 20);
            this.m_txtP.m_BlnIgnoreUserInfo = false;
            this.m_txtP.m_BlnPartControl = false;
            this.m_txtP.m_BlnReadOnly = false;
            this.m_txtP.m_BlnUnderLineDST = false;
            this.m_txtP.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtP.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtP.m_IntCanModifyTime = 6;
            this.m_txtP.m_IntPartControlLength = 0;
            this.m_txtP.m_IntPartControlStartIndex = 0;
            this.m_txtP.m_StrUserID = "";
            this.m_txtP.m_StrUserName = "";
            this.m_txtP.Multiline = false;
            this.m_txtP.Name = "m_txtP";
            this.m_txtP.Size = new System.Drawing.Size(40, 21);
            this.m_txtP.TabIndex = 190;
            this.m_txtP.Text = "";
            // 
            // m_txtCVP
            // 
            this.m_txtCVP.BackColor = System.Drawing.Color.White;
            this.m_txtCVP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCVP.ForeColor = System.Drawing.Color.Black;
            this.m_txtCVP.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCVP.Location = new System.Drawing.Point(220, 48);
            this.m_txtCVP.m_BlnIgnoreUserInfo = false;
            this.m_txtCVP.m_BlnPartControl = false;
            this.m_txtCVP.m_BlnReadOnly = false;
            this.m_txtCVP.m_BlnUnderLineDST = false;
            this.m_txtCVP.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCVP.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCVP.m_IntCanModifyTime = 6;
            this.m_txtCVP.m_IntPartControlLength = 0;
            this.m_txtCVP.m_IntPartControlStartIndex = 0;
            this.m_txtCVP.m_StrUserID = "";
            this.m_txtCVP.m_StrUserName = "";
            this.m_txtCVP.Multiline = false;
            this.m_txtCVP.Name = "m_txtCVP";
            this.m_txtCVP.Size = new System.Drawing.Size(60, 21);
            this.m_txtCVP.TabIndex = 220;
            this.m_txtCVP.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(330, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 6078;
            this.label4.Text = "bpm    R:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(92, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 14);
            this.label5.TabIndex = 6077;
            this.label5.Text = "℃  HR:";
            // 
            // m_txtT
            // 
            this.m_txtT.BackColor = System.Drawing.Color.White;
            this.m_txtT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtT.ForeColor = System.Drawing.Color.Black;
            this.m_txtT.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtT.Location = new System.Drawing.Point(40, 20);
            this.m_txtT.m_BlnIgnoreUserInfo = false;
            this.m_txtT.m_BlnPartControl = false;
            this.m_txtT.m_BlnReadOnly = false;
            this.m_txtT.m_BlnUnderLineDST = false;
            this.m_txtT.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtT.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtT.m_IntCanModifyTime = 6;
            this.m_txtT.m_IntPartControlLength = 0;
            this.m_txtT.m_IntPartControlStartIndex = 0;
            this.m_txtT.m_StrUserID = "";
            this.m_txtT.m_StrUserName = "";
            this.m_txtT.Multiline = false;
            this.m_txtT.Name = "m_txtT";
            this.m_txtT.Size = new System.Drawing.Size(44, 21);
            this.m_txtT.TabIndex = 180;
            this.m_txtT.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 14);
            this.label6.TabIndex = 6071;
            this.label6.Text = "T:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label29);
            this.groupBox3.Controls.Add(this.label28);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.m_txtPower);
            this.groupBox3.Controls.Add(this.m_txtReflectRight);
            this.groupBox3.Controls.Add(this.m_txtReflectLeft);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.m_txtPupilSizeRight);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.m_txtPupilSizeLeft);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.m_txtConsciousness);
            this.groupBox3.Location = new System.Drawing.Point(12, 224);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(800, 48);
            this.groupBox3.TabIndex = 120;
            this.groupBox3.TabStop = false;
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(613, 24);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(42, 14);
            this.label29.TabIndex = 6095;
            this.label29.Text = "肌力:";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(528, 24);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(28, 14);
            this.label28.TabIndex = 6094;
            this.label28.Text = "右:";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(443, 24);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(28, 14);
            this.label19.TabIndex = 6093;
            this.label19.Text = "左:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 14);
            this.label14.TabIndex = 6092;
            this.label14.Text = "神志:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtPower
            // 
            this.m_txtPower.BackColor = System.Drawing.Color.White;
            this.m_txtPower.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPower.ForeColor = System.Drawing.Color.Black;
            this.m_txtPower.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPower.Location = new System.Drawing.Point(657, 19);
            this.m_txtPower.m_BlnIgnoreUserInfo = false;
            this.m_txtPower.m_BlnPartControl = false;
            this.m_txtPower.m_BlnReadOnly = false;
            this.m_txtPower.m_BlnUnderLineDST = false;
            this.m_txtPower.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPower.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPower.m_IntCanModifyTime = 6;
            this.m_txtPower.m_IntPartControlLength = 0;
            this.m_txtPower.m_IntPartControlStartIndex = 0;
            this.m_txtPower.m_StrUserID = "";
            this.m_txtPower.m_StrUserName = "";
            this.m_txtPower.Multiline = false;
            this.m_txtPower.Name = "m_txtPower";
            this.m_txtPower.Size = new System.Drawing.Size(84, 21);
            this.m_txtPower.TabIndex = 310;
            this.m_txtPower.Text = "";
            // 
            // m_txtReflectRight
            // 
            this.m_txtReflectRight.BackColor = System.Drawing.Color.White;
            this.m_txtReflectRight.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtReflectRight.ForeColor = System.Drawing.Color.Black;
            this.m_txtReflectRight.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtReflectRight.Location = new System.Drawing.Point(558, 19);
            this.m_txtReflectRight.m_BlnIgnoreUserInfo = false;
            this.m_txtReflectRight.m_BlnPartControl = false;
            this.m_txtReflectRight.m_BlnReadOnly = false;
            this.m_txtReflectRight.m_BlnUnderLineDST = false;
            this.m_txtReflectRight.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtReflectRight.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtReflectRight.m_IntCanModifyTime = 6;
            this.m_txtReflectRight.m_IntPartControlLength = 0;
            this.m_txtReflectRight.m_IntPartControlStartIndex = 0;
            this.m_txtReflectRight.m_StrUserID = "";
            this.m_txtReflectRight.m_StrUserName = "";
            this.m_txtReflectRight.Multiline = false;
            this.m_txtReflectRight.Name = "m_txtReflectRight";
            this.m_txtReflectRight.Size = new System.Drawing.Size(52, 21);
            this.m_txtReflectRight.TabIndex = 300;
            this.m_txtReflectRight.Text = "";
            // 
            // m_txtReflectLeft
            // 
            this.m_txtReflectLeft.BackColor = System.Drawing.Color.White;
            this.m_txtReflectLeft.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtReflectLeft.ForeColor = System.Drawing.Color.Black;
            this.m_txtReflectLeft.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtReflectLeft.Location = new System.Drawing.Point(473, 19);
            this.m_txtReflectLeft.m_BlnIgnoreUserInfo = false;
            this.m_txtReflectLeft.m_BlnPartControl = false;
            this.m_txtReflectLeft.m_BlnReadOnly = false;
            this.m_txtReflectLeft.m_BlnUnderLineDST = false;
            this.m_txtReflectLeft.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtReflectLeft.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtReflectLeft.m_IntCanModifyTime = 6;
            this.m_txtReflectLeft.m_IntPartControlLength = 0;
            this.m_txtReflectLeft.m_IntPartControlStartIndex = 0;
            this.m_txtReflectLeft.m_StrUserID = "";
            this.m_txtReflectLeft.m_StrUserName = "";
            this.m_txtReflectLeft.Multiline = false;
            this.m_txtReflectLeft.Name = "m_txtReflectLeft";
            this.m_txtReflectLeft.Size = new System.Drawing.Size(52, 21);
            this.m_txtReflectLeft.TabIndex = 290;
            this.m_txtReflectLeft.Text = "";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(370, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 14);
            this.label15.TabIndex = 6087;
            this.label15.Text = "对光反射:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtPupilSizeRight
            // 
            this.m_txtPupilSizeRight.BackColor = System.Drawing.Color.White;
            this.m_txtPupilSizeRight.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPupilSizeRight.ForeColor = System.Drawing.Color.Black;
            this.m_txtPupilSizeRight.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPupilSizeRight.Location = new System.Drawing.Point(315, 19);
            this.m_txtPupilSizeRight.m_BlnIgnoreUserInfo = false;
            this.m_txtPupilSizeRight.m_BlnPartControl = false;
            this.m_txtPupilSizeRight.m_BlnReadOnly = false;
            this.m_txtPupilSizeRight.m_BlnUnderLineDST = false;
            this.m_txtPupilSizeRight.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPupilSizeRight.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPupilSizeRight.m_IntCanModifyTime = 6;
            this.m_txtPupilSizeRight.m_IntPartControlLength = 0;
            this.m_txtPupilSizeRight.m_IntPartControlStartIndex = 0;
            this.m_txtPupilSizeRight.m_StrUserID = "";
            this.m_txtPupilSizeRight.m_StrUserName = "";
            this.m_txtPupilSizeRight.Multiline = false;
            this.m_txtPupilSizeRight.Name = "m_txtPupilSizeRight";
            this.m_txtPupilSizeRight.Size = new System.Drawing.Size(52, 21);
            this.m_txtPupilSizeRight.TabIndex = 280;
            this.m_txtPupilSizeRight.Text = "";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(285, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(28, 14);
            this.label13.TabIndex = 6085;
            this.label13.Text = "右:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtPupilSizeLeft
            // 
            this.m_txtPupilSizeLeft.BackColor = System.Drawing.Color.White;
            this.m_txtPupilSizeLeft.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPupilSizeLeft.ForeColor = System.Drawing.Color.Black;
            this.m_txtPupilSizeLeft.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPupilSizeLeft.Location = new System.Drawing.Point(230, 19);
            this.m_txtPupilSizeLeft.m_BlnIgnoreUserInfo = false;
            this.m_txtPupilSizeLeft.m_BlnPartControl = false;
            this.m_txtPupilSizeLeft.m_BlnReadOnly = false;
            this.m_txtPupilSizeLeft.m_BlnUnderLineDST = false;
            this.m_txtPupilSizeLeft.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPupilSizeLeft.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPupilSizeLeft.m_IntCanModifyTime = 6;
            this.m_txtPupilSizeLeft.m_IntPartControlLength = 0;
            this.m_txtPupilSizeLeft.m_IntPartControlStartIndex = 0;
            this.m_txtPupilSizeLeft.m_StrUserID = "";
            this.m_txtPupilSizeLeft.m_StrUserName = "";
            this.m_txtPupilSizeLeft.Multiline = false;
            this.m_txtPupilSizeLeft.Name = "m_txtPupilSizeLeft";
            this.m_txtPupilSizeLeft.Size = new System.Drawing.Size(52, 21);
            this.m_txtPupilSizeLeft.TabIndex = 270;
            this.m_txtPupilSizeLeft.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(135, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 14);
            this.label3.TabIndex = 6083;
            this.label3.Text = "瞳孔大小 左:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtConsciousness
            // 
            this.m_txtConsciousness.BackColor = System.Drawing.Color.White;
            this.m_txtConsciousness.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtConsciousness.ForeColor = System.Drawing.Color.Black;
            this.m_txtConsciousness.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtConsciousness.Location = new System.Drawing.Point(52, 19);
            this.m_txtConsciousness.m_BlnIgnoreUserInfo = false;
            this.m_txtConsciousness.m_BlnPartControl = false;
            this.m_txtConsciousness.m_BlnReadOnly = false;
            this.m_txtConsciousness.m_BlnUnderLineDST = false;
            this.m_txtConsciousness.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtConsciousness.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtConsciousness.m_IntCanModifyTime = 6;
            this.m_txtConsciousness.m_IntPartControlLength = 0;
            this.m_txtConsciousness.m_IntPartControlStartIndex = 0;
            this.m_txtConsciousness.m_StrUserID = "";
            this.m_txtConsciousness.m_StrUserName = "";
            this.m_txtConsciousness.Multiline = false;
            this.m_txtConsciousness.Name = "m_txtConsciousness";
            this.m_txtConsciousness.Size = new System.Drawing.Size(80, 21);
            this.m_txtConsciousness.TabIndex = 260;
            this.m_txtConsciousness.Text = "";
            // 
            // m_cmdPower
            // 
            this.m_cmdPower.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdPower.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdPower.Location = new System.Drawing.Point(120, 28);
            this.m_cmdPower.Name = "m_cmdPower";
            this.m_cmdPower.Size = new System.Drawing.Size(52, 28);
            this.m_cmdPower.TabIndex = 6091;
            this.m_cmdPower.Text = "肌力:";
            // 
            // m_cmdReflectRight
            // 
            this.m_cmdReflectRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdReflectRight.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdReflectRight.Location = new System.Drawing.Point(88, 28);
            this.m_cmdReflectRight.Name = "m_cmdReflectRight";
            this.m_cmdReflectRight.Size = new System.Drawing.Size(32, 24);
            this.m_cmdReflectRight.TabIndex = 6089;
            this.m_cmdReflectRight.Text = "右:";
            // 
            // m_cmdReflectLeft
            // 
            this.m_cmdReflectLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdReflectLeft.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdReflectLeft.Location = new System.Drawing.Point(56, 28);
            this.m_cmdReflectLeft.Name = "m_cmdReflectLeft";
            this.m_cmdReflectLeft.Size = new System.Drawing.Size(32, 24);
            this.m_cmdReflectLeft.TabIndex = 6088;
            this.m_cmdReflectLeft.Text = "左:";
            // 
            // m_cmdSence
            // 
            this.m_cmdSence.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdSence.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdSence.Location = new System.Drawing.Point(4, 28);
            this.m_cmdSence.Name = "m_cmdSence";
            this.m_cmdSence.Size = new System.Drawing.Size(52, 28);
            this.m_cmdSence.TabIndex = 250;
            this.m_cmdSence.Text = "神志:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label40);
            this.groupBox4.Controls.Add(this.m_txtSputumQuantity);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.m_txtSputumProperty);
            this.groupBox4.Location = new System.Drawing.Point(496, 420);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(316, 52);
            this.groupBox4.TabIndex = 600;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "痰(ml)";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(12, 24);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(42, 14);
            this.label40.TabIndex = 6108;
            this.label40.Text = "性质:";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtSputumQuantity
            // 
            this.m_txtSputumQuantity.BackColor = System.Drawing.Color.White;
            this.m_txtSputumQuantity.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSputumQuantity.ForeColor = System.Drawing.Color.Black;
            this.m_txtSputumQuantity.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSputumQuantity.Location = new System.Drawing.Point(204, 20);
            this.m_txtSputumQuantity.m_BlnIgnoreUserInfo = false;
            this.m_txtSputumQuantity.m_BlnPartControl = false;
            this.m_txtSputumQuantity.m_BlnReadOnly = false;
            this.m_txtSputumQuantity.m_BlnUnderLineDST = false;
            this.m_txtSputumQuantity.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSputumQuantity.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSputumQuantity.m_IntCanModifyTime = 6;
            this.m_txtSputumQuantity.m_IntPartControlLength = 0;
            this.m_txtSputumQuantity.m_IntPartControlStartIndex = 0;
            this.m_txtSputumQuantity.m_StrUserID = "";
            this.m_txtSputumQuantity.m_StrUserName = "";
            this.m_txtSputumQuantity.Multiline = false;
            this.m_txtSputumQuantity.Name = "m_txtSputumQuantity";
            this.m_txtSputumQuantity.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.m_txtSputumQuantity.Size = new System.Drawing.Size(104, 21);
            this.m_txtSputumQuantity.TabIndex = 620;
            this.m_txtSputumQuantity.Text = "";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(172, 24);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(28, 14);
            this.label17.TabIndex = 6087;
            this.label17.Text = "量:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtSputumProperty
            // 
            this.m_txtSputumProperty.BackColor = System.Drawing.Color.White;
            this.m_txtSputumProperty.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSputumProperty.ForeColor = System.Drawing.Color.Black;
            this.m_txtSputumProperty.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSputumProperty.Location = new System.Drawing.Point(64, 19);
            this.m_txtSputumProperty.m_BlnIgnoreUserInfo = false;
            this.m_txtSputumProperty.m_BlnPartControl = false;
            this.m_txtSputumProperty.m_BlnReadOnly = false;
            this.m_txtSputumProperty.m_BlnUnderLineDST = false;
            this.m_txtSputumProperty.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSputumProperty.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSputumProperty.m_IntCanModifyTime = 6;
            this.m_txtSputumProperty.m_IntPartControlLength = 0;
            this.m_txtSputumProperty.m_IntPartControlStartIndex = 0;
            this.m_txtSputumProperty.m_StrUserID = "";
            this.m_txtSputumProperty.m_StrUserName = "";
            this.m_txtSputumProperty.Multiline = false;
            this.m_txtSputumProperty.Name = "m_txtSputumProperty";
            this.m_txtSputumProperty.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.m_txtSputumProperty.Size = new System.Drawing.Size(104, 21);
            this.m_txtSputumProperty.TabIndex = 610;
            this.m_txtSputumProperty.Text = "";
            // 
            // m_cmdSputumProperty
            // 
            this.m_cmdSputumProperty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdSputumProperty.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdSputumProperty.Location = new System.Drawing.Point(228, 56);
            this.m_cmdSputumProperty.Name = "m_cmdSputumProperty";
            this.m_cmdSputumProperty.Size = new System.Drawing.Size(52, 28);
            this.m_cmdSputumProperty.TabIndex = 6104;
            this.m_cmdSputumProperty.Text = "性质:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label24);
            this.groupBox5.Controls.Add(this.m_txtTakeFood);
            this.groupBox5.Controls.Add(this.label22);
            this.groupBox5.Controls.Add(this.m_txtTransfusion);
            this.groupBox5.Controls.Add(this.m_gpbInOral);
            this.groupBox5.Controls.Add(this.groupBox6);
            this.groupBox5.Controls.Add(this.m_gpbInLiquid);
            this.groupBox5.Location = new System.Drawing.Point(12, 272);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(800, 148);
            this.groupBox5.TabIndex = 130;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "入量(ml)";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(168, 120);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(70, 14);
            this.label24.TabIndex = 6101;
            this.label24.Text = "进食总量:";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtTakeFood
            // 
            this.m_txtTakeFood.BackColor = System.Drawing.Color.White;
            this.m_txtTakeFood.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtTakeFood.ForeColor = System.Drawing.Color.Black;
            this.m_txtTakeFood.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtTakeFood.Location = new System.Drawing.Point(254, 120);
            this.m_txtTakeFood.m_BlnIgnoreUserInfo = false;
            this.m_txtTakeFood.m_BlnPartControl = false;
            this.m_txtTakeFood.m_BlnReadOnly = false;
            this.m_txtTakeFood.m_BlnUnderLineDST = false;
            this.m_txtTakeFood.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtTakeFood.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtTakeFood.m_IntCanModifyTime = 6;
            this.m_txtTakeFood.m_IntPartControlLength = 0;
            this.m_txtTakeFood.m_IntPartControlStartIndex = 0;
            this.m_txtTakeFood.m_StrUserID = "";
            this.m_txtTakeFood.m_StrUserName = "";
            this.m_txtTakeFood.Multiline = false;
            this.m_txtTakeFood.Name = "m_txtTakeFood";
            this.m_txtTakeFood.Size = new System.Drawing.Size(74, 21);
            this.m_txtTakeFood.TabIndex = 6100;
            this.m_txtTakeFood.Text = "";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(8, 120);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(70, 14);
            this.label22.TabIndex = 6099;
            this.label22.Text = "输液总量:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtTransfusion
            // 
            this.m_txtTransfusion.BackColor = System.Drawing.Color.White;
            this.m_txtTransfusion.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtTransfusion.ForeColor = System.Drawing.Color.Black;
            this.m_txtTransfusion.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtTransfusion.Location = new System.Drawing.Point(84, 120);
            this.m_txtTransfusion.m_BlnIgnoreUserInfo = false;
            this.m_txtTransfusion.m_BlnPartControl = false;
            this.m_txtTransfusion.m_BlnReadOnly = false;
            this.m_txtTransfusion.m_BlnUnderLineDST = false;
            this.m_txtTransfusion.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtTransfusion.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtTransfusion.m_IntCanModifyTime = 6;
            this.m_txtTransfusion.m_IntPartControlLength = 0;
            this.m_txtTransfusion.m_IntPartControlStartIndex = 0;
            this.m_txtTransfusion.m_StrUserID = "";
            this.m_txtTransfusion.m_StrUserName = "";
            this.m_txtTransfusion.Multiline = false;
            this.m_txtTransfusion.Name = "m_txtTransfusion";
            this.m_txtTransfusion.Size = new System.Drawing.Size(76, 21);
            this.m_txtTransfusion.TabIndex = 6098;
            this.m_txtTransfusion.Text = "";
            // 
            // m_gpbInOral
            // 
            this.m_gpbInOral.Controls.Add(this.label39);
            this.m_gpbInOral.Controls.Add(this.label38);
            this.m_gpbInOral.Controls.Add(this.label37);
            this.m_gpbInOral.Controls.Add(this.m_txtInOralType);
            this.m_gpbInOral.Controls.Add(this.label16);
            this.m_gpbInOral.Controls.Add(this.m_txtInOralQuantity);
            this.m_gpbInOral.Controls.Add(this.m_txtInOralProperty);
            this.m_gpbInOral.Controls.Add(this.m_dtgInOral);
            this.m_gpbInOral.Controls.Add(this.m_txtInOral);
            this.m_gpbInOral.Controls.Add(this.m_cmdInOralSubmit);
            this.m_gpbInOral.Location = new System.Drawing.Point(484, 16);
            this.m_gpbInOral.Name = "m_gpbInOral";
            this.m_gpbInOral.Size = new System.Drawing.Size(300, 128);
            this.m_gpbInOral.TabIndex = 420;
            this.m_gpbInOral.TabStop = false;
            this.m_gpbInOral.Text = "口服";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(12, 74);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(42, 14);
            this.label39.TabIndex = 6107;
            this.label39.Text = "性质:";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(12, 50);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(42, 14);
            this.label38.TabIndex = 6106;
            this.label38.Text = "药名:";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(12, 26);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(42, 14);
            this.label37.TabIndex = 6105;
            this.label37.Text = "类型:";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtInOralType
            // 
            this.m_txtInOralType.BackColor = System.Drawing.Color.White;
            this.m_txtInOralType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtInOralType.ForeColor = System.Drawing.Color.Black;
            this.m_txtInOralType.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtInOralType.Location = new System.Drawing.Point(64, 24);
            this.m_txtInOralType.m_BlnIgnoreUserInfo = false;
            this.m_txtInOralType.m_BlnPartControl = false;
            this.m_txtInOralType.m_BlnReadOnly = false;
            this.m_txtInOralType.m_BlnUnderLineDST = false;
            this.m_txtInOralType.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtInOralType.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtInOralType.m_IntCanModifyTime = 6;
            this.m_txtInOralType.m_IntPartControlLength = 0;
            this.m_txtInOralType.m_IntPartControlStartIndex = 0;
            this.m_txtInOralType.m_StrUserID = "";
            this.m_txtInOralType.m_StrUserName = "";
            this.m_txtInOralType.Multiline = false;
            this.m_txtInOralType.Name = "m_txtInOralType";
            this.m_txtInOralType.Size = new System.Drawing.Size(72, 21);
            this.m_txtInOralType.TabIndex = 415;
            this.m_txtInOralType.Text = "";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 98);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(28, 14);
            this.label16.TabIndex = 6104;
            this.label16.Text = "量:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtInOralQuantity
            // 
            this.m_txtInOralQuantity.BackColor = System.Drawing.Color.White;
            this.m_txtInOralQuantity.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtInOralQuantity.ForeColor = System.Drawing.Color.Black;
            this.m_txtInOralQuantity.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtInOralQuantity.Location = new System.Drawing.Point(64, 96);
            this.m_txtInOralQuantity.m_BlnIgnoreUserInfo = false;
            this.m_txtInOralQuantity.m_BlnPartControl = false;
            this.m_txtInOralQuantity.m_BlnReadOnly = false;
            this.m_txtInOralQuantity.m_BlnUnderLineDST = false;
            this.m_txtInOralQuantity.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtInOralQuantity.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtInOralQuantity.m_IntCanModifyTime = 6;
            this.m_txtInOralQuantity.m_IntPartControlLength = 0;
            this.m_txtInOralQuantity.m_IntPartControlStartIndex = 0;
            this.m_txtInOralQuantity.m_StrUserID = "";
            this.m_txtInOralQuantity.m_StrUserName = "";
            this.m_txtInOralQuantity.Multiline = false;
            this.m_txtInOralQuantity.Name = "m_txtInOralQuantity";
            this.m_txtInOralQuantity.Size = new System.Drawing.Size(72, 21);
            this.m_txtInOralQuantity.TabIndex = 4438;
            this.m_txtInOralQuantity.Text = "";
            // 
            // m_txtInOralProperty
            // 
            this.m_txtInOralProperty.BackColor = System.Drawing.Color.White;
            this.m_txtInOralProperty.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtInOralProperty.ForeColor = System.Drawing.Color.Black;
            this.m_txtInOralProperty.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtInOralProperty.Location = new System.Drawing.Point(64, 72);
            this.m_txtInOralProperty.m_BlnIgnoreUserInfo = false;
            this.m_txtInOralProperty.m_BlnPartControl = false;
            this.m_txtInOralProperty.m_BlnReadOnly = false;
            this.m_txtInOralProperty.m_BlnUnderLineDST = false;
            this.m_txtInOralProperty.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtInOralProperty.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtInOralProperty.m_IntCanModifyTime = 6;
            this.m_txtInOralProperty.m_IntPartControlLength = 0;
            this.m_txtInOralProperty.m_IntPartControlStartIndex = 0;
            this.m_txtInOralProperty.m_StrUserID = "";
            this.m_txtInOralProperty.m_StrUserName = "";
            this.m_txtInOralProperty.Multiline = false;
            this.m_txtInOralProperty.Name = "m_txtInOralProperty";
            this.m_txtInOralProperty.Size = new System.Drawing.Size(72, 21);
            this.m_txtInOralProperty.TabIndex = 435;
            this.m_txtInOralProperty.Text = "";
            // 
            // m_dtgInOral
            // 
            this.m_dtgInOral.AlternatingBackColor = System.Drawing.Color.White;
            this.m_dtgInOral.BackColor = System.Drawing.Color.White;
            this.m_dtgInOral.BackgroundColor = System.Drawing.Color.White;
            this.m_dtgInOral.CaptionFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtgInOral.CaptionText = "口服";
            this.m_dtgInOral.CaptionVisible = false;
            this.m_dtgInOral.ContextMenu = this.ctmInOral;
            this.m_dtgInOral.DataMember = "";
            this.m_dtgInOral.FlatMode = true;
            this.m_dtgInOral.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtgInOral.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.m_dtgInOral.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.m_dtgInOral.Location = new System.Drawing.Point(144, 24);
            this.m_dtgInOral.Name = "m_dtgInOral";
            this.m_dtgInOral.ParentRowsForeColor = System.Drawing.Color.White;
            this.m_dtgInOral.RowHeaderWidth = 10;
            this.m_dtgInOral.Size = new System.Drawing.Size(148, 64);
            this.m_dtgInOral.TabIndex = 450;
            this.m_dtgInOral.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.m_dtsInOral});
            // 
            // ctmInOral
            // 
            this.ctmInOral.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mniInsertInoral,
            this.mniEditInOral,
            this.mniRemove});
            // 
            // mniInsertInoral
            // 
            this.mniInsertInoral.Index = 0;
            this.mniInsertInoral.Text = "插    入";
            this.mniInsertInoral.Click += new System.EventHandler(this.mniInsertInoral_Click);
            // 
            // mniEditInOral
            // 
            this.mniEditInOral.Index = 1;
            this.mniEditInOral.Text = "修    改";
            this.mniEditInOral.Click += new System.EventHandler(this.mniEditInOral_Click);
            // 
            // mniRemove
            // 
            this.mniRemove.Index = 2;
            this.mniRemove.Text = "删    除";
            this.mniRemove.Click += new System.EventHandler(this.mniRemove_Click);
            // 
            // m_dtsInOral
            // 
            this.m_dtsInOral.AllowSorting = false;
            this.m_dtsInOral.DataGrid = this.m_dtgInOral;
            this.m_dtsInOral.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.m_dcmInOralType,
            this.m_dcmInOral,
            this.m_dcmInOralProperty,
            this.m_dcmInOralQuantity});
            this.m_dtsInOral.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.m_dtsInOral.MappingName = "InOral";
            this.m_dtsInOral.ReadOnly = true;
            this.m_dtsInOral.RowHeadersVisible = false;
            // 
            // m_dcmInOralType
            // 
            this.m_dcmInOralType.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dcmInOralType.HeaderText = "类型";
            this.m_dcmInOralType.m_BlnGobleSet = true;
            this.m_dcmInOralType.m_BlnUnderLineDST = false;
            this.m_dcmInOralType.MappingName = "类型";
            this.m_dcmInOralType.NullText = "";
            this.m_dcmInOralType.Width = 50;
            // 
            // m_dcmInOral
            // 
            this.m_dcmInOral.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dcmInOral.HeaderText = "药名";
            this.m_dcmInOral.m_BlnGobleSet = true;
            this.m_dcmInOral.m_BlnUnderLineDST = false;
            this.m_dcmInOral.MappingName = "药名";
            this.m_dcmInOral.NullText = "";
            this.m_dcmInOral.Width = 75;
            // 
            // m_dcmInOralProperty
            // 
            this.m_dcmInOralProperty.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dcmInOralProperty.HeaderText = "性质";
            this.m_dcmInOralProperty.m_BlnGobleSet = true;
            this.m_dcmInOralProperty.m_BlnUnderLineDST = false;
            this.m_dcmInOralProperty.MappingName = "性质";
            this.m_dcmInOralProperty.NullText = "";
            this.m_dcmInOralProperty.Width = 75;
            // 
            // m_dcmInOralQuantity
            // 
            this.m_dcmInOralQuantity.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dcmInOralQuantity.HeaderText = "量";
            this.m_dcmInOralQuantity.m_BlnGobleSet = true;
            this.m_dcmInOralQuantity.m_BlnUnderLineDST = false;
            this.m_dcmInOralQuantity.MappingName = "量";
            this.m_dcmInOralQuantity.NullText = "";
            this.m_dcmInOralQuantity.Width = 30;
            // 
            // m_txtInOral
            // 
            this.m_txtInOral.BackColor = System.Drawing.Color.White;
            this.m_txtInOral.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtInOral.ForeColor = System.Drawing.Color.Black;
            this.m_txtInOral.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtInOral.Location = new System.Drawing.Point(64, 48);
            this.m_txtInOral.m_BlnIgnoreUserInfo = false;
            this.m_txtInOral.m_BlnPartControl = false;
            this.m_txtInOral.m_BlnReadOnly = false;
            this.m_txtInOral.m_BlnUnderLineDST = false;
            this.m_txtInOral.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtInOral.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtInOral.m_IntCanModifyTime = 6;
            this.m_txtInOral.m_IntPartControlLength = 0;
            this.m_txtInOral.m_IntPartControlStartIndex = 0;
            this.m_txtInOral.m_StrUserID = "";
            this.m_txtInOral.m_StrUserName = "";
            this.m_txtInOral.Multiline = false;
            this.m_txtInOral.Name = "m_txtInOral";
            this.m_txtInOral.Size = new System.Drawing.Size(72, 21);
            this.m_txtInOral.TabIndex = 430;
            this.m_txtInOral.Text = "";
            // 
            // m_cmdInOralSubmit
            // 
            this.m_cmdInOralSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdInOralSubmit.DefaultScheme = true;
            this.m_cmdInOralSubmit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdInOralSubmit.Hint = "";
            this.m_cmdInOralSubmit.Location = new System.Drawing.Point(144, 93);
            this.m_cmdInOralSubmit.Name = "m_cmdInOralSubmit";
            this.m_cmdInOralSubmit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdInOralSubmit.Size = new System.Drawing.Size(52, 24);
            this.m_cmdInOralSubmit.TabIndex = 10000028;
            this.m_cmdInOralSubmit.Text = "确定";
            this.m_cmdInOralSubmit.Click += new System.EventHandler(this.m_cmdInOralSubmit_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label36);
            this.groupBox6.Controls.Add(this.label33);
            this.groupBox6.Controls.Add(this.label32);
            this.groupBox6.Controls.Add(this.m_txtStomachPipe);
            this.groupBox6.Controls.Add(this.label23);
            this.groupBox6.Controls.Add(this.m_txtStomachQuantity);
            this.groupBox6.Controls.Add(this.m_txtStomachProperty);
            this.groupBox6.Controls.Add(this.m_txtDirect1);
            this.groupBox6.Location = new System.Drawing.Point(332, 16);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(148, 128);
            this.groupBox6.TabIndex = 370;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "胃管";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(8, 74);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(63, 14);
            this.label36.TabIndex = 6098;
            this.label36.Text = "胃液性质";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(8, 50);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(42, 14);
            this.label33.TabIndex = 6097;
            this.label33.Text = "通畅:";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(8, 26);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(42, 14);
            this.label32.TabIndex = 6096;
            this.label32.Text = "胃管:";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtStomachPipe
            // 
            this.m_txtStomachPipe.BackColor = System.Drawing.Color.White;
            this.m_txtStomachPipe.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtStomachPipe.ForeColor = System.Drawing.Color.Black;
            this.m_txtStomachPipe.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtStomachPipe.Location = new System.Drawing.Point(64, 24);
            this.m_txtStomachPipe.m_BlnIgnoreUserInfo = false;
            this.m_txtStomachPipe.m_BlnPartControl = false;
            this.m_txtStomachPipe.m_BlnReadOnly = false;
            this.m_txtStomachPipe.m_BlnUnderLineDST = false;
            this.m_txtStomachPipe.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtStomachPipe.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtStomachPipe.m_IntCanModifyTime = 6;
            this.m_txtStomachPipe.m_IntPartControlLength = 0;
            this.m_txtStomachPipe.m_IntPartControlStartIndex = 0;
            this.m_txtStomachPipe.m_StrUserID = "";
            this.m_txtStomachPipe.m_StrUserName = "";
            this.m_txtStomachPipe.Multiline = false;
            this.m_txtStomachPipe.Name = "m_txtStomachPipe";
            this.m_txtStomachPipe.Size = new System.Drawing.Size(80, 21);
            this.m_txtStomachPipe.TabIndex = 345;
            this.m_txtStomachPipe.Text = "";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(8, 98);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(28, 14);
            this.label23.TabIndex = 6094;
            this.label23.Text = "量:";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtStomachQuantity
            // 
            this.m_txtStomachQuantity.BackColor = System.Drawing.Color.White;
            this.m_txtStomachQuantity.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtStomachQuantity.ForeColor = System.Drawing.Color.Black;
            this.m_txtStomachQuantity.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtStomachQuantity.Location = new System.Drawing.Point(64, 96);
            this.m_txtStomachQuantity.m_BlnIgnoreUserInfo = false;
            this.m_txtStomachQuantity.m_BlnPartControl = false;
            this.m_txtStomachQuantity.m_BlnReadOnly = false;
            this.m_txtStomachQuantity.m_BlnUnderLineDST = false;
            this.m_txtStomachQuantity.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtStomachQuantity.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtStomachQuantity.m_IntCanModifyTime = 6;
            this.m_txtStomachQuantity.m_IntPartControlLength = 0;
            this.m_txtStomachQuantity.m_IntPartControlStartIndex = 0;
            this.m_txtStomachQuantity.m_StrUserID = "";
            this.m_txtStomachQuantity.m_StrUserName = "";
            this.m_txtStomachQuantity.Multiline = false;
            this.m_txtStomachQuantity.Name = "m_txtStomachQuantity";
            this.m_txtStomachQuantity.Size = new System.Drawing.Size(80, 21);
            this.m_txtStomachQuantity.TabIndex = 410;
            this.m_txtStomachQuantity.Text = "";
            // 
            // m_txtStomachProperty
            // 
            this.m_txtStomachProperty.BackColor = System.Drawing.Color.White;
            this.m_txtStomachProperty.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtStomachProperty.ForeColor = System.Drawing.Color.Black;
            this.m_txtStomachProperty.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtStomachProperty.Location = new System.Drawing.Point(84, 72);
            this.m_txtStomachProperty.m_BlnIgnoreUserInfo = false;
            this.m_txtStomachProperty.m_BlnPartControl = false;
            this.m_txtStomachProperty.m_BlnReadOnly = false;
            this.m_txtStomachProperty.m_BlnUnderLineDST = false;
            this.m_txtStomachProperty.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtStomachProperty.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtStomachProperty.m_IntCanModifyTime = 6;
            this.m_txtStomachProperty.m_IntPartControlLength = 0;
            this.m_txtStomachProperty.m_IntPartControlStartIndex = 0;
            this.m_txtStomachProperty.m_StrUserID = "";
            this.m_txtStomachProperty.m_StrUserName = "";
            this.m_txtStomachProperty.Multiline = false;
            this.m_txtStomachProperty.Name = "m_txtStomachProperty";
            this.m_txtStomachProperty.Size = new System.Drawing.Size(60, 21);
            this.m_txtStomachProperty.TabIndex = 400;
            this.m_txtStomachProperty.Text = "";
            // 
            // m_txtDirect1
            // 
            this.m_txtDirect1.BackColor = System.Drawing.Color.White;
            this.m_txtDirect1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDirect1.ForeColor = System.Drawing.Color.Black;
            this.m_txtDirect1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDirect1.Location = new System.Drawing.Point(64, 48);
            this.m_txtDirect1.m_BlnIgnoreUserInfo = false;
            this.m_txtDirect1.m_BlnPartControl = false;
            this.m_txtDirect1.m_BlnReadOnly = false;
            this.m_txtDirect1.m_BlnUnderLineDST = false;
            this.m_txtDirect1.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDirect1.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDirect1.m_IntCanModifyTime = 6;
            this.m_txtDirect1.m_IntPartControlLength = 0;
            this.m_txtDirect1.m_IntPartControlStartIndex = 0;
            this.m_txtDirect1.m_StrUserID = "";
            this.m_txtDirect1.m_StrUserName = "";
            this.m_txtDirect1.Multiline = false;
            this.m_txtDirect1.Name = "m_txtDirect1";
            this.m_txtDirect1.Size = new System.Drawing.Size(80, 21);
            this.m_txtDirect1.TabIndex = 390;
            this.m_txtDirect1.Text = "";
            // 
            // m_gpbInLiquid
            // 
            this.m_gpbInLiquid.Controls.Add(this.m_dtgInLiquid);
            this.m_gpbInLiquid.Controls.Add(this.label31);
            this.m_gpbInLiquid.Controls.Add(this.m_txtDrugName);
            this.m_gpbInLiquid.Controls.Add(this.label20);
            this.m_gpbInLiquid.Controls.Add(this.m_txtDrugDosage);
            this.m_gpbInLiquid.Controls.Add(this.cmdDrugSubmit);
            this.m_gpbInLiquid.Location = new System.Drawing.Point(4, 16);
            this.m_gpbInLiquid.Name = "m_gpbInLiquid";
            this.m_gpbInLiquid.Size = new System.Drawing.Size(324, 96);
            this.m_gpbInLiquid.TabIndex = 320;
            this.m_gpbInLiquid.TabStop = false;
            this.m_gpbInLiquid.Text = "输液(医嘱)";
            // 
            // m_dtgInLiquid
            // 
            this.m_dtgInLiquid.AlternatingBackColor = System.Drawing.Color.White;
            this.m_dtgInLiquid.BackColor = System.Drawing.Color.White;
            this.m_dtgInLiquid.BackgroundColor = System.Drawing.Color.White;
            this.m_dtgInLiquid.CaptionFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtgInLiquid.CaptionText = "输入液量";
            this.m_dtgInLiquid.CaptionVisible = false;
            this.m_dtgInLiquid.ContextMenu = this.ctmInOral;
            this.m_dtgInLiquid.DataMember = "";
            this.m_dtgInLiquid.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_dtgInLiquid.FlatMode = true;
            this.m_dtgInLiquid.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtgInLiquid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.m_dtgInLiquid.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.m_dtgInLiquid.Location = new System.Drawing.Point(157, 19);
            this.m_dtgInLiquid.Name = "m_dtgInLiquid";
            this.m_dtgInLiquid.ParentRowsForeColor = System.Drawing.Color.White;
            this.m_dtgInLiquid.RowHeaderWidth = 10;
            this.m_dtgInLiquid.Size = new System.Drawing.Size(164, 74);
            this.m_dtgInLiquid.TabIndex = 360;
            this.m_dtgInLiquid.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.m_dtsInLiquid});
            // 
            // m_dtsInLiquid
            // 
            this.m_dtsInLiquid.AllowSorting = false;
            this.m_dtsInLiquid.DataGrid = this.m_dtgInLiquid;
            this.m_dtsInLiquid.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.m_dcmDrugName,
            this.m_dcmDosage});
            this.m_dtsInLiquid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.m_dtsInLiquid.MappingName = "InLiquid";
            this.m_dtsInLiquid.ReadOnly = true;
            this.m_dtsInLiquid.RowHeadersVisible = false;
            // 
            // m_dcmDrugName
            // 
            this.m_dcmDrugName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dcmDrugName.HeaderText = "药名";
            this.m_dcmDrugName.m_BlnGobleSet = true;
            this.m_dcmDrugName.m_BlnUnderLineDST = false;
            this.m_dcmDrugName.MappingName = "药名";
            this.m_dcmDrugName.NullText = "";
            this.m_dcmDrugName.Width = 150;
            // 
            // m_dcmDosage
            // 
            this.m_dcmDosage.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dcmDosage.HeaderText = "剂量";
            this.m_dcmDosage.m_BlnGobleSet = true;
            this.m_dcmDosage.m_BlnUnderLineDST = false;
            this.m_dcmDosage.MappingName = "剂量";
            this.m_dcmDosage.NullText = "";
            this.m_dcmDosage.Width = 50;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(8, 24);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(42, 14);
            this.label31.TabIndex = 6090;
            this.label31.Text = "药名:";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtDrugName
            // 
            this.m_txtDrugName.BackColor = System.Drawing.Color.White;
            this.m_txtDrugName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDrugName.ForeColor = System.Drawing.Color.Black;
            this.m_txtDrugName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDrugName.Location = new System.Drawing.Point(60, 20);
            this.m_txtDrugName.m_BlnIgnoreUserInfo = false;
            this.m_txtDrugName.m_BlnPartControl = false;
            this.m_txtDrugName.m_BlnReadOnly = false;
            this.m_txtDrugName.m_BlnUnderLineDST = false;
            this.m_txtDrugName.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDrugName.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDrugName.m_IntCanModifyTime = 6;
            this.m_txtDrugName.m_IntPartControlLength = 0;
            this.m_txtDrugName.m_IntPartControlStartIndex = 0;
            this.m_txtDrugName.m_StrUserID = "";
            this.m_txtDrugName.m_StrUserName = "";
            this.m_txtDrugName.Multiline = false;
            this.m_txtDrugName.Name = "m_txtDrugName";
            this.m_txtDrugName.Size = new System.Drawing.Size(88, 21);
            this.m_txtDrugName.TabIndex = 330;
            this.m_txtDrugName.Text = "";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(8, 52);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(42, 14);
            this.label20.TabIndex = 6089;
            this.label20.Text = "剂量:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtDrugDosage
            // 
            this.m_txtDrugDosage.BackColor = System.Drawing.Color.White;
            this.m_txtDrugDosage.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDrugDosage.ForeColor = System.Drawing.Color.Black;
            this.m_txtDrugDosage.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDrugDosage.Location = new System.Drawing.Point(60, 48);
            this.m_txtDrugDosage.m_BlnIgnoreUserInfo = false;
            this.m_txtDrugDosage.m_BlnPartControl = false;
            this.m_txtDrugDosage.m_BlnReadOnly = false;
            this.m_txtDrugDosage.m_BlnUnderLineDST = false;
            this.m_txtDrugDosage.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDrugDosage.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDrugDosage.m_IntCanModifyTime = 6;
            this.m_txtDrugDosage.m_IntPartControlLength = 0;
            this.m_txtDrugDosage.m_IntPartControlStartIndex = 0;
            this.m_txtDrugDosage.m_StrUserID = "";
            this.m_txtDrugDosage.m_StrUserName = "";
            this.m_txtDrugDosage.Multiline = false;
            this.m_txtDrugDosage.Name = "m_txtDrugDosage";
            this.m_txtDrugDosage.Size = new System.Drawing.Size(88, 21);
            this.m_txtDrugDosage.TabIndex = 340;
            this.m_txtDrugDosage.Text = "";
            // 
            // cmdDrugSubmit
            // 
            this.cmdDrugSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.cmdDrugSubmit.DefaultScheme = true;
            this.cmdDrugSubmit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdDrugSubmit.Hint = "";
            this.cmdDrugSubmit.Location = new System.Drawing.Point(8, 72);
            this.cmdDrugSubmit.Name = "cmdDrugSubmit";
            this.cmdDrugSubmit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdDrugSubmit.Size = new System.Drawing.Size(48, 20);
            this.cmdDrugSubmit.TabIndex = 10000027;
            this.cmdDrugSubmit.Text = "确定";
            this.cmdDrugSubmit.Click += new System.EventHandler(this.cmdDrugSubmit_Click);
            // 
            // m_cmdDrugName
            // 
            this.m_cmdDrugName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdDrugName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdDrugName.Location = new System.Drawing.Point(4, 60);
            this.m_cmdDrugName.Name = "m_cmdDrugName";
            this.m_cmdDrugName.Size = new System.Drawing.Size(52, 28);
            this.m_cmdDrugName.TabIndex = 6099;
            this.m_cmdDrugName.Text = "药名:";
            // 
            // m_cmdInOralType
            // 
            this.m_cmdInOralType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdInOralType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdInOralType.Location = new System.Drawing.Point(344, 28);
            this.m_cmdInOralType.Name = "m_cmdInOralType";
            this.m_cmdInOralType.Size = new System.Drawing.Size(52, 28);
            this.m_cmdInOralType.TabIndex = 6106;
            this.m_cmdInOralType.Text = "类型:";
            // 
            // m_cmdInOralProperty
            // 
            this.m_cmdInOralProperty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdInOralProperty.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdInOralProperty.Location = new System.Drawing.Point(164, 60);
            this.m_cmdInOralProperty.Name = "m_cmdInOralProperty";
            this.m_cmdInOralProperty.Size = new System.Drawing.Size(52, 28);
            this.m_cmdInOralProperty.TabIndex = 6102;
            this.m_cmdInOralProperty.Text = "性质:";
            // 
            // m_cmdInOral
            // 
            this.m_cmdInOral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdInOral.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdInOral.Location = new System.Drawing.Point(400, 28);
            this.m_cmdInOral.Name = "m_cmdInOral";
            this.m_cmdInOral.Size = new System.Drawing.Size(52, 28);
            this.m_cmdInOral.TabIndex = 6100;
            this.m_cmdInOral.Text = "药名:";
            // 
            // m_cmdStomachPipe
            // 
            this.m_cmdStomachPipe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdStomachPipe.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdStomachPipe.Location = new System.Drawing.Point(56, 60);
            this.m_cmdStomachPipe.Name = "m_cmdStomachPipe";
            this.m_cmdStomachPipe.Size = new System.Drawing.Size(52, 28);
            this.m_cmdStomachPipe.TabIndex = 6098;
            this.m_cmdStomachPipe.Text = "胃管:";
            // 
            // m_cmdStomachProperty
            // 
            this.m_cmdStomachProperty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdStomachProperty.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdStomachProperty.Location = new System.Drawing.Point(272, 28);
            this.m_cmdStomachProperty.Name = "m_cmdStomachProperty";
            this.m_cmdStomachProperty.Size = new System.Drawing.Size(76, 28);
            this.m_cmdStomachProperty.TabIndex = 6095;
            this.m_cmdStomachProperty.Text = "胃液性质:";
            // 
            // m_cmdDirect1
            // 
            this.m_cmdDirect1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdDirect1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdDirect1.Location = new System.Drawing.Point(108, 60);
            this.m_cmdDirect1.Name = "m_cmdDirect1";
            this.m_cmdDirect1.Size = new System.Drawing.Size(52, 28);
            this.m_cmdDirect1.TabIndex = 380;
            this.m_cmdDirect1.Text = "通畅:";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.groupBox10);
            this.groupBox7.Controls.Add(this.groupBox9);
            this.groupBox7.Controls.Add(this.groupBox8);
            this.groupBox7.Location = new System.Drawing.Point(12, 420);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(484, 128);
            this.groupBox7.TabIndex = 140;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "出量(ml)";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.label44);
            this.groupBox10.Controls.Add(this.label43);
            this.groupBox10.Controls.Add(this.label34);
            this.groupBox10.Controls.Add(this.m_txtLeadPipe);
            this.groupBox10.Controls.Add(this.label27);
            this.groupBox10.Controls.Add(this.m_txtLeadQuantity);
            this.groupBox10.Controls.Add(this.m_txtLeadProperty);
            this.groupBox10.Controls.Add(this.m_txtDirect3);
            this.groupBox10.Location = new System.Drawing.Point(296, 12);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(180, 112);
            this.groupBox10.TabIndex = 550;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "引流管";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(8, 80);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(42, 14);
            this.label44.TabIndex = 6107;
            this.label44.Text = "性质:";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(8, 24);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(56, 14);
            this.label43.TabIndex = 6106;
            this.label43.Text = "引流管:";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(8, 52);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(42, 14);
            this.label34.TabIndex = 6105;
            this.label34.Text = "通畅:";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtLeadPipe
            // 
            this.m_txtLeadPipe.BackColor = System.Drawing.Color.White;
            this.m_txtLeadPipe.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtLeadPipe.ForeColor = System.Drawing.Color.Black;
            this.m_txtLeadPipe.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtLeadPipe.Location = new System.Drawing.Point(64, 24);
            this.m_txtLeadPipe.m_BlnIgnoreUserInfo = false;
            this.m_txtLeadPipe.m_BlnPartControl = false;
            this.m_txtLeadPipe.m_BlnReadOnly = false;
            this.m_txtLeadPipe.m_BlnUnderLineDST = false;
            this.m_txtLeadPipe.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtLeadPipe.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtLeadPipe.m_IntCanModifyTime = 6;
            this.m_txtLeadPipe.m_IntPartControlLength = 0;
            this.m_txtLeadPipe.m_IntPartControlStartIndex = 0;
            this.m_txtLeadPipe.m_StrUserID = "";
            this.m_txtLeadPipe.m_StrUserName = "";
            this.m_txtLeadPipe.Multiline = false;
            this.m_txtLeadPipe.Name = "m_txtLeadPipe";
            this.m_txtLeadPipe.Size = new System.Drawing.Size(112, 21);
            this.m_txtLeadPipe.TabIndex = 545;
            this.m_txtLeadPipe.Text = "";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(104, 80);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(28, 14);
            this.label27.TabIndex = 6094;
            this.label27.Text = "量:";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtLeadQuantity
            // 
            this.m_txtLeadQuantity.BackColor = System.Drawing.Color.White;
            this.m_txtLeadQuantity.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtLeadQuantity.ForeColor = System.Drawing.Color.Black;
            this.m_txtLeadQuantity.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtLeadQuantity.Location = new System.Drawing.Point(136, 80);
            this.m_txtLeadQuantity.m_BlnIgnoreUserInfo = false;
            this.m_txtLeadQuantity.m_BlnPartControl = false;
            this.m_txtLeadQuantity.m_BlnReadOnly = false;
            this.m_txtLeadQuantity.m_BlnUnderLineDST = false;
            this.m_txtLeadQuantity.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtLeadQuantity.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtLeadQuantity.m_IntCanModifyTime = 6;
            this.m_txtLeadQuantity.m_IntPartControlLength = 0;
            this.m_txtLeadQuantity.m_IntPartControlStartIndex = 0;
            this.m_txtLeadQuantity.m_StrUserID = "";
            this.m_txtLeadQuantity.m_StrUserName = "";
            this.m_txtLeadQuantity.Multiline = false;
            this.m_txtLeadQuantity.Name = "m_txtLeadQuantity";
            this.m_txtLeadQuantity.Size = new System.Drawing.Size(40, 21);
            this.m_txtLeadQuantity.TabIndex = 590;
            this.m_txtLeadQuantity.Text = "";
            // 
            // m_txtLeadProperty
            // 
            this.m_txtLeadProperty.BackColor = System.Drawing.Color.White;
            this.m_txtLeadProperty.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtLeadProperty.ForeColor = System.Drawing.Color.Black;
            this.m_txtLeadProperty.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtLeadProperty.Location = new System.Drawing.Point(52, 80);
            this.m_txtLeadProperty.m_BlnIgnoreUserInfo = false;
            this.m_txtLeadProperty.m_BlnPartControl = false;
            this.m_txtLeadProperty.m_BlnReadOnly = false;
            this.m_txtLeadProperty.m_BlnUnderLineDST = false;
            this.m_txtLeadProperty.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtLeadProperty.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtLeadProperty.m_IntCanModifyTime = 6;
            this.m_txtLeadProperty.m_IntPartControlLength = 0;
            this.m_txtLeadProperty.m_IntPartControlStartIndex = 0;
            this.m_txtLeadProperty.m_StrUserID = "";
            this.m_txtLeadProperty.m_StrUserName = "";
            this.m_txtLeadProperty.Multiline = false;
            this.m_txtLeadProperty.Name = "m_txtLeadProperty";
            this.m_txtLeadProperty.Size = new System.Drawing.Size(48, 21);
            this.m_txtLeadProperty.TabIndex = 580;
            this.m_txtLeadProperty.Text = "";
            // 
            // m_txtDirect3
            // 
            this.m_txtDirect3.BackColor = System.Drawing.Color.White;
            this.m_txtDirect3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDirect3.ForeColor = System.Drawing.Color.Black;
            this.m_txtDirect3.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDirect3.Location = new System.Drawing.Point(64, 52);
            this.m_txtDirect3.m_BlnIgnoreUserInfo = false;
            this.m_txtDirect3.m_BlnPartControl = false;
            this.m_txtDirect3.m_BlnReadOnly = false;
            this.m_txtDirect3.m_BlnUnderLineDST = false;
            this.m_txtDirect3.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDirect3.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDirect3.m_IntCanModifyTime = 6;
            this.m_txtDirect3.m_IntPartControlLength = 0;
            this.m_txtDirect3.m_IntPartControlStartIndex = 0;
            this.m_txtDirect3.m_StrUserID = "";
            this.m_txtDirect3.m_StrUserName = "";
            this.m_txtDirect3.Multiline = false;
            this.m_txtDirect3.Name = "m_txtDirect3";
            this.m_txtDirect3.Size = new System.Drawing.Size(112, 21);
            this.m_txtDirect3.TabIndex = 570;
            this.m_txtDirect3.Text = "";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label41);
            this.groupBox9.Controls.Add(this.label35);
            this.groupBox9.Controls.Add(this.label30);
            this.groupBox9.Controls.Add(this.m_txtPeeQuantity);
            this.groupBox9.Controls.Add(this.m_txtPeeProperty);
            this.groupBox9.Controls.Add(this.m_txtDirect2);
            this.groupBox9.Location = new System.Drawing.Point(0, 16);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(152, 112);
            this.groupBox9.TabIndex = 470;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "尿管";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(8, 52);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(63, 14);
            this.label41.TabIndex = 6105;
            this.label41.Text = "尿液性质";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(8, 24);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(42, 14);
            this.label35.TabIndex = 6104;
            this.label35.Text = "通畅:";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(8, 84);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(28, 14);
            this.label30.TabIndex = 6094;
            this.label30.Text = "量:";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtPeeQuantity
            // 
            this.m_txtPeeQuantity.BackColor = System.Drawing.Color.White;
            this.m_txtPeeQuantity.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPeeQuantity.ForeColor = System.Drawing.Color.Black;
            this.m_txtPeeQuantity.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPeeQuantity.Location = new System.Drawing.Point(76, 80);
            this.m_txtPeeQuantity.m_BlnIgnoreUserInfo = false;
            this.m_txtPeeQuantity.m_BlnPartControl = false;
            this.m_txtPeeQuantity.m_BlnReadOnly = false;
            this.m_txtPeeQuantity.m_BlnUnderLineDST = false;
            this.m_txtPeeQuantity.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPeeQuantity.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPeeQuantity.m_IntCanModifyTime = 6;
            this.m_txtPeeQuantity.m_IntPartControlLength = 0;
            this.m_txtPeeQuantity.m_IntPartControlStartIndex = 0;
            this.m_txtPeeQuantity.m_StrUserID = "";
            this.m_txtPeeQuantity.m_StrUserName = "";
            this.m_txtPeeQuantity.Multiline = false;
            this.m_txtPeeQuantity.Name = "m_txtPeeQuantity";
            this.m_txtPeeQuantity.Size = new System.Drawing.Size(68, 21);
            this.m_txtPeeQuantity.TabIndex = 510;
            this.m_txtPeeQuantity.Text = "";
            // 
            // m_txtPeeProperty
            // 
            this.m_txtPeeProperty.BackColor = System.Drawing.Color.White;
            this.m_txtPeeProperty.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPeeProperty.ForeColor = System.Drawing.Color.Black;
            this.m_txtPeeProperty.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPeeProperty.Location = new System.Drawing.Point(76, 48);
            this.m_txtPeeProperty.m_BlnIgnoreUserInfo = false;
            this.m_txtPeeProperty.m_BlnPartControl = false;
            this.m_txtPeeProperty.m_BlnReadOnly = false;
            this.m_txtPeeProperty.m_BlnUnderLineDST = false;
            this.m_txtPeeProperty.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPeeProperty.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPeeProperty.m_IntCanModifyTime = 6;
            this.m_txtPeeProperty.m_IntPartControlLength = 0;
            this.m_txtPeeProperty.m_IntPartControlStartIndex = 0;
            this.m_txtPeeProperty.m_StrUserID = "";
            this.m_txtPeeProperty.m_StrUserName = "";
            this.m_txtPeeProperty.Multiline = false;
            this.m_txtPeeProperty.Name = "m_txtPeeProperty";
            this.m_txtPeeProperty.Size = new System.Drawing.Size(68, 21);
            this.m_txtPeeProperty.TabIndex = 500;
            this.m_txtPeeProperty.Text = "";
            // 
            // m_txtDirect2
            // 
            this.m_txtDirect2.BackColor = System.Drawing.Color.White;
            this.m_txtDirect2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDirect2.ForeColor = System.Drawing.Color.Black;
            this.m_txtDirect2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDirect2.Location = new System.Drawing.Point(76, 20);
            this.m_txtDirect2.m_BlnIgnoreUserInfo = false;
            this.m_txtDirect2.m_BlnPartControl = false;
            this.m_txtDirect2.m_BlnReadOnly = false;
            this.m_txtDirect2.m_BlnUnderLineDST = false;
            this.m_txtDirect2.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDirect2.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDirect2.m_IntCanModifyTime = 6;
            this.m_txtDirect2.m_IntPartControlLength = 0;
            this.m_txtDirect2.m_IntPartControlStartIndex = 0;
            this.m_txtDirect2.m_StrUserID = "";
            this.m_txtDirect2.m_StrUserName = "";
            this.m_txtDirect2.Multiline = false;
            this.m_txtDirect2.Name = "m_txtDirect2";
            this.m_txtDirect2.Size = new System.Drawing.Size(68, 21);
            this.m_txtDirect2.TabIndex = 490;
            this.m_txtDirect2.Text = "";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label42);
            this.groupBox8.Controls.Add(this.label25);
            this.groupBox8.Controls.Add(this.m_txtDefecateTimes);
            this.groupBox8.Controls.Add(this.label21);
            this.groupBox8.Controls.Add(this.m_txtDefecateQuantity);
            this.groupBox8.Controls.Add(this.m_txtDefecateProperty);
            this.groupBox8.Location = new System.Drawing.Point(160, 12);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(132, 112);
            this.groupBox8.TabIndex = 520;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "大便";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(12, 24);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(42, 14);
            this.label42.TabIndex = 6108;
            this.label42.Text = "性质:";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(12, 52);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(42, 14);
            this.label25.TabIndex = 6105;
            this.label25.Text = "次数:";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtDefecateTimes
            // 
            this.m_txtDefecateTimes.BackColor = System.Drawing.Color.White;
            this.m_txtDefecateTimes.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDefecateTimes.ForeColor = System.Drawing.Color.Black;
            this.m_txtDefecateTimes.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDefecateTimes.Location = new System.Drawing.Point(56, 52);
            this.m_txtDefecateTimes.m_BlnIgnoreUserInfo = false;
            this.m_txtDefecateTimes.m_BlnPartControl = false;
            this.m_txtDefecateTimes.m_BlnReadOnly = false;
            this.m_txtDefecateTimes.m_BlnUnderLineDST = false;
            this.m_txtDefecateTimes.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDefecateTimes.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDefecateTimes.m_IntCanModifyTime = 6;
            this.m_txtDefecateTimes.m_IntPartControlLength = 0;
            this.m_txtDefecateTimes.m_IntPartControlStartIndex = 0;
            this.m_txtDefecateTimes.m_StrUserID = "";
            this.m_txtDefecateTimes.m_StrUserName = "";
            this.m_txtDefecateTimes.Multiline = false;
            this.m_txtDefecateTimes.Name = "m_txtDefecateTimes";
            this.m_txtDefecateTimes.Size = new System.Drawing.Size(68, 21);
            this.m_txtDefecateTimes.TabIndex = 535;
            this.m_txtDefecateTimes.Text = "";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(12, 80);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(28, 14);
            this.label21.TabIndex = 6094;
            this.label21.Text = "量:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtDefecateQuantity
            // 
            this.m_txtDefecateQuantity.BackColor = System.Drawing.Color.White;
            this.m_txtDefecateQuantity.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDefecateQuantity.ForeColor = System.Drawing.Color.Black;
            this.m_txtDefecateQuantity.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDefecateQuantity.Location = new System.Drawing.Point(56, 80);
            this.m_txtDefecateQuantity.m_BlnIgnoreUserInfo = false;
            this.m_txtDefecateQuantity.m_BlnPartControl = false;
            this.m_txtDefecateQuantity.m_BlnReadOnly = false;
            this.m_txtDefecateQuantity.m_BlnUnderLineDST = false;
            this.m_txtDefecateQuantity.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDefecateQuantity.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDefecateQuantity.m_IntCanModifyTime = 6;
            this.m_txtDefecateQuantity.m_IntPartControlLength = 0;
            this.m_txtDefecateQuantity.m_IntPartControlStartIndex = 0;
            this.m_txtDefecateQuantity.m_StrUserID = "";
            this.m_txtDefecateQuantity.m_StrUserName = "";
            this.m_txtDefecateQuantity.Multiline = false;
            this.m_txtDefecateQuantity.Name = "m_txtDefecateQuantity";
            this.m_txtDefecateQuantity.Size = new System.Drawing.Size(68, 21);
            this.m_txtDefecateQuantity.TabIndex = 540;
            this.m_txtDefecateQuantity.Text = "";
            // 
            // m_txtDefecateProperty
            // 
            this.m_txtDefecateProperty.BackColor = System.Drawing.Color.White;
            this.m_txtDefecateProperty.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDefecateProperty.ForeColor = System.Drawing.Color.Black;
            this.m_txtDefecateProperty.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDefecateProperty.Location = new System.Drawing.Point(56, 20);
            this.m_txtDefecateProperty.m_BlnIgnoreUserInfo = false;
            this.m_txtDefecateProperty.m_BlnPartControl = false;
            this.m_txtDefecateProperty.m_BlnReadOnly = false;
            this.m_txtDefecateProperty.m_BlnUnderLineDST = false;
            this.m_txtDefecateProperty.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDefecateProperty.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDefecateProperty.m_IntCanModifyTime = 6;
            this.m_txtDefecateProperty.m_IntPartControlLength = 0;
            this.m_txtDefecateProperty.m_IntPartControlStartIndex = 0;
            this.m_txtDefecateProperty.m_StrUserID = "";
            this.m_txtDefecateProperty.m_StrUserName = "";
            this.m_txtDefecateProperty.Multiline = false;
            this.m_txtDefecateProperty.Name = "m_txtDefecateProperty";
            this.m_txtDefecateProperty.Size = new System.Drawing.Size(68, 21);
            this.m_txtDefecateProperty.TabIndex = 530;
            this.m_txtDefecateProperty.Text = "";
            // 
            // m_cmdLeadPipe
            // 
            this.m_cmdLeadPipe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdLeadPipe.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdLeadPipe.Location = new System.Drawing.Point(416, 60);
            this.m_cmdLeadPipe.Name = "m_cmdLeadPipe";
            this.m_cmdLeadPipe.Size = new System.Drawing.Size(68, 28);
            this.m_cmdLeadPipe.TabIndex = 6104;
            this.m_cmdLeadPipe.Text = "引流管:";
            // 
            // m_cmdLeadProperty
            // 
            this.m_cmdLeadProperty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdLeadProperty.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdLeadProperty.Location = new System.Drawing.Point(452, 28);
            this.m_cmdLeadProperty.Name = "m_cmdLeadProperty";
            this.m_cmdLeadProperty.Size = new System.Drawing.Size(52, 28);
            this.m_cmdLeadProperty.TabIndex = 6103;
            this.m_cmdLeadProperty.Text = "性质:";
            // 
            // m_cmdDirect3
            // 
            this.m_cmdDirect3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdDirect3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdDirect3.Location = new System.Drawing.Point(172, 28);
            this.m_cmdDirect3.Name = "m_cmdDirect3";
            this.m_cmdDirect3.Size = new System.Drawing.Size(52, 28);
            this.m_cmdDirect3.TabIndex = 560;
            this.m_cmdDirect3.Text = "通畅:";
            // 
            // m_cmdPeeProperty
            // 
            this.m_cmdPeeProperty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdPeeProperty.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdPeeProperty.Location = new System.Drawing.Point(280, 56);
            this.m_cmdPeeProperty.Name = "m_cmdPeeProperty";
            this.m_cmdPeeProperty.Size = new System.Drawing.Size(76, 28);
            this.m_cmdPeeProperty.TabIndex = 6103;
            this.m_cmdPeeProperty.Text = "尿液性质:";
            // 
            // m_cmdDirect2
            // 
            this.m_cmdDirect2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdDirect2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdDirect2.Location = new System.Drawing.Point(220, 28);
            this.m_cmdDirect2.Name = "m_cmdDirect2";
            this.m_cmdDirect2.Size = new System.Drawing.Size(52, 28);
            this.m_cmdDirect2.TabIndex = 480;
            this.m_cmdDirect2.Text = "通畅:";
            // 
            // m_cmdDefecateProperty
            // 
            this.m_cmdDefecateProperty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdDefecateProperty.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdDefecateProperty.Location = new System.Drawing.Point(360, 60);
            this.m_cmdDefecateProperty.Name = "m_cmdDefecateProperty";
            this.m_cmdDefecateProperty.Size = new System.Drawing.Size(52, 28);
            this.m_cmdDefecateProperty.TabIndex = 6103;
            this.m_cmdDefecateProperty.Text = "性质:";
            // 
            // m_txtSkin
            // 
            this.m_txtSkin.AccessibleDescription = "皮肤情况";
            this.m_txtSkin.BackColor = System.Drawing.Color.White;
            this.m_txtSkin.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSkin.ForeColor = System.Drawing.Color.White;
            this.m_txtSkin.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSkin.Location = new System.Drawing.Point(500, 496);
            this.m_txtSkin.m_BlnIgnoreUserInfo = false;
            this.m_txtSkin.m_BlnPartControl = false;
            this.m_txtSkin.m_BlnReadOnly = false;
            this.m_txtSkin.m_BlnUnderLineDST = false;
            this.m_txtSkin.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSkin.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSkin.m_IntCanModifyTime = 6;
            this.m_txtSkin.m_IntPartControlLength = 0;
            this.m_txtSkin.m_IntPartControlStartIndex = 0;
            this.m_txtSkin.m_StrUserID = "";
            this.m_txtSkin.m_StrUserName = "";
            this.m_txtSkin.Name = "m_txtSkin";
            this.m_txtSkin.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtSkin.Size = new System.Drawing.Size(312, 48);
            this.m_txtSkin.TabIndex = 640;
            this.m_txtSkin.Text = "";
            // 
            // m_cmdSkin
            // 
            this.m_cmdSkin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdSkin.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdSkin.Location = new System.Drawing.Point(492, 64);
            this.m_cmdSkin.Name = "m_cmdSkin";
            this.m_cmdSkin.Size = new System.Drawing.Size(80, 28);
            this.m_cmdSkin.TabIndex = 630;
            this.m_cmdSkin.Text = "皮肤情况:";
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(12, 552);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(32, 64);
            this.label26.TabIndex = 6097;
            this.label26.Text = "病情记录";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtCaseHistory
            // 
            this.m_txtCaseHistory.AccessibleDescription = "病情记录";
            this.m_txtCaseHistory.BackColor = System.Drawing.Color.White;
            this.m_txtCaseHistory.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCaseHistory.ForeColor = System.Drawing.Color.White;
            this.m_txtCaseHistory.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCaseHistory.Location = new System.Drawing.Point(48, 552);
            this.m_txtCaseHistory.m_BlnIgnoreUserInfo = false;
            this.m_txtCaseHistory.m_BlnPartControl = false;
            this.m_txtCaseHistory.m_BlnReadOnly = false;
            this.m_txtCaseHistory.m_BlnUnderLineDST = false;
            this.m_txtCaseHistory.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCaseHistory.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCaseHistory.m_IntCanModifyTime = 6;
            this.m_txtCaseHistory.m_IntPartControlLength = 0;
            this.m_txtCaseHistory.m_IntPartControlStartIndex = 0;
            this.m_txtCaseHistory.m_StrUserID = "";
            this.m_txtCaseHistory.m_StrUserName = "";
            this.m_txtCaseHistory.Name = "m_txtCaseHistory";
            this.m_txtCaseHistory.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtCaseHistory.Size = new System.Drawing.Size(768, 64);
            this.m_txtCaseHistory.TabIndex = 150;
            this.m_txtCaseHistory.Text = "";
            // 
            // m_cmdClose
            // 
            this.m_cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdClose.DefaultScheme = true;
            this.m_cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdClose.Hint = "";
            this.m_cmdClose.Location = new System.Drawing.Point(752, 624);
            this.m_cmdClose.Name = "m_cmdClose";
            this.m_cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClose.Size = new System.Drawing.Size(64, 24);
            this.m_cmdClose.TabIndex = 670;
            this.m_cmdClose.Text = "取消";
            this.m_cmdClose.Click += new System.EventHandler(this.m_cmdClose_Click);
            // 
            // m_lblSign
            // 
            this.m_lblSign.BackColor = System.Drawing.SystemColors.Control;
            this.m_lblSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblSign.ForeColor = System.Drawing.Color.Black;
            this.m_lblSign.Location = new System.Drawing.Point(364, 624);
            this.m_lblSign.Name = "m_lblSign";
            this.m_lblSign.Size = new System.Drawing.Size(96, 19);
            this.m_lblSign.TabIndex = 10003;
            this.m_lblSign.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lblSign.Visible = false;
            // 
            // cmdConfirm
            // 
            this.cmdConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.cmdConfirm.DefaultScheme = true;
            this.cmdConfirm.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdConfirm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdConfirm.Hint = "";
            this.cmdConfirm.Location = new System.Drawing.Point(668, 624);
            this.cmdConfirm.Name = "cmdConfirm";
            this.cmdConfirm.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdConfirm.Size = new System.Drawing.Size(64, 24);
            this.cmdConfirm.TabIndex = 660;
            this.cmdConfirm.Text = "确定";
            this.cmdConfirm.Click += new System.EventHandler(this.cmdConfirm_Click);
            // 
            // ctmInLiquid
            // 
            this.ctmInLiquid.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mniInsert,
            this.mniEdit,
            this.menuItem1});
            // 
            // mniInsert
            // 
            this.mniInsert.Index = 0;
            this.mniInsert.Text = "插    入";
            this.mniInsert.Click += new System.EventHandler(this.mniInsert_Click);
            // 
            // mniEdit
            // 
            this.mniEdit.Index = 1;
            this.mniEdit.Text = "修    改";
            this.mniEdit.Click += new System.EventHandler(this.mniEdit_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 2;
            this.menuItem1.Text = "删    除";
            this.menuItem1.Click += new System.EventHandler(this.mniRemoveLiquid_Click);
            // 
            // m_cmdGetDovueData
            // 
            this.m_cmdGetDovueData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdGetDovueData.DefaultScheme = true;
            this.m_cmdGetDovueData.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdGetDovueData.Hint = "";
            this.m_cmdGetDovueData.Location = new System.Drawing.Point(156, 187);
            this.m_cmdGetDovueData.Name = "m_cmdGetDovueData";
            this.m_cmdGetDovueData.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdGetDovueData.Size = new System.Drawing.Size(148, 32);
            this.m_cmdGetDovueData.TabIndex = 10000002;
            this.m_cmdGetDovueData.Text = "监护仪最新结果";
            this.m_cmdGetDovueData.Click += new System.EventHandler(this.m_cmdGetDovueData_Click);
            // 
            // m_cmdGetGEData
            // 
            this.m_cmdGetGEData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdGetGEData.DefaultScheme = true;
            this.m_cmdGetGEData.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdGetGEData.Hint = "";
            this.m_cmdGetGEData.Location = new System.Drawing.Point(156, 187);
            this.m_cmdGetGEData.Name = "m_cmdGetGEData";
            this.m_cmdGetGEData.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdGetGEData.Size = new System.Drawing.Size(148, 32);
            this.m_cmdGetGEData.TabIndex = 10000003;
            this.m_cmdGetGEData.Text = "GE监护仪最新结果";
            this.m_cmdGetGEData.Visible = false;
            this.m_cmdGetGEData.Click += new System.EventHandler(this.m_cmdGetGEData_Click);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.m_cmdSence);
            this.groupBox11.Controls.Add(this.m_cmdReflectLeft);
            this.groupBox11.Controls.Add(this.m_cmdReflectRight);
            this.groupBox11.Controls.Add(this.m_cmdPower);
            this.groupBox11.Controls.Add(this.m_cmdDrugName);
            this.groupBox11.Controls.Add(this.m_cmdStomachPipe);
            this.groupBox11.Controls.Add(this.m_cmdDirect1);
            this.groupBox11.Controls.Add(this.m_cmdDirect3);
            this.groupBox11.Controls.Add(this.m_cmdDirect2);
            this.groupBox11.Controls.Add(this.m_cmdStomachProperty);
            this.groupBox11.Controls.Add(this.m_cmdInOralType);
            this.groupBox11.Controls.Add(this.m_cmdInOral);
            this.groupBox11.Controls.Add(this.m_cmdInOralProperty);
            this.groupBox11.Controls.Add(this.m_cmdSputumProperty);
            this.groupBox11.Controls.Add(this.m_cmdPeeProperty);
            this.groupBox11.Controls.Add(this.m_cmdDefecateProperty);
            this.groupBox11.Controls.Add(this.m_cmdLeadPipe);
            this.groupBox11.Controls.Add(this.m_cmdLeadProperty);
            this.groupBox11.Controls.Add(this.m_cmdSkin);
            this.groupBox11.Location = new System.Drawing.Point(70, 92);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(28, 4);
            this.groupBox11.TabIndex = 10000025;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "no use";
            this.groupBox11.Visible = false;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(500, 472);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(70, 14);
            this.label45.TabIndex = 10000026;
            this.label45.Text = "皮肤情况:";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSign
            // 
            this.txtSign.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSign.Enabled = false;
            this.txtSign.Location = new System.Drawing.Point(88, 625);
            this.txtSign.Name = "txtSign";
            this.txtSign.Size = new System.Drawing.Size(106, 23);
            this.txtSign.TabIndex = 10000028;
            // 
            // m_cmbsign
            // 
            this.m_cmbsign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmbsign.DefaultScheme = true;
            this.m_cmbsign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmbsign.Hint = "";
            this.m_cmbsign.Location = new System.Drawing.Point(20, 616);
            this.m_cmbsign.Name = "m_cmbsign";
            this.m_cmbsign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmbsign.Size = new System.Drawing.Size(64, 32);
            this.m_cmbsign.TabIndex = 10000027;
            this.m_cmbsign.Text = "签名";
            // 
            // frmSubICUIntensiveTend
            // 
            this.AccessibleDescription = "编辑危重症监护中心特护记录单";
            this.AutoScroll = false;
            this.CancelButton = this.m_cmdClose;
            this.ClientSize = new System.Drawing.Size(822, 651);
            this.Controls.Add(this.m_txtBreathSoundLeft);
            this.Controls.Add(this.m_cmdBreathLeft);
            this.Controls.Add(this.txtSign);
            this.Controls.Add(this.m_cmbsign);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.m_cmdBreathRight);
            this.Controls.Add(this.cmdConfirm);
            this.Controls.Add(this.label45);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.m_cmdGetGEData);
            this.Controls.Add(this.m_cmdGetDovueData);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.m_cmdClose);
            this.Controls.Add(this.m_lblSign);
            this.Controls.Add(this.m_txtCaseHistory);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.m_txtSkin);
            this.Controls.Add(this.groupBox5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmSubICUIntensiveTend";
            this.Text = "编辑危重症监护中心特护记录单";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmSubICUIntensiveTend_Closing);
            this.Load += new System.EventHandler(this.frmSubICUIntensiveTend_Load);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_lblGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_dtpGetDataTime, 0);
            this.Controls.SetChildIndex(this.groupBox5, 0);
            this.Controls.SetChildIndex(this.m_txtSkin, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox7, 0);
            this.Controls.SetChildIndex(this.m_txtCaseHistory, 0);
            this.Controls.SetChildIndex(this.m_lblSign, 0);
            this.Controls.SetChildIndex(this.m_cmdClose, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.Controls.SetChildIndex(this.m_cmdGetDovueData, 0);
            this.Controls.SetChildIndex(this.m_cmdGetGEData, 0);
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
            this.Controls.SetChildIndex(this.label26, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.label45, 0);
            this.Controls.SetChildIndex(this.cmdConfirm, 0);
            this.Controls.SetChildIndex(this.m_cmdBreathRight, 0);
            this.Controls.SetChildIndex(this.groupBox11, 0);
            this.Controls.SetChildIndex(this.m_cmbsign, 0);
            this.Controls.SetChildIndex(this.txtSign, 0);
            this.Controls.SetChildIndex(this.m_cmdBreathLeft, 0);
            this.Controls.SetChildIndex(this.m_txtBreathSoundLeft, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.m_gpbInOral.ResumeLayout(false);
            this.m_gpbInOral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgInOral)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.m_gpbInLiquid.ResumeLayout(false);
            this.m_gpbInLiquid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgInLiquid)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmSubICUIntensiveTend_Load(object sender, System.EventArgs e)
		{
			
//			m_cmdNewTemplate.Left=cmdConfirm.Left-m_cmdNewTemplate.Width+(cmdConfirm.Right-m_cmdClose.Left);
//			m_cmdNewTemplate.Top=cmdConfirm.Top;
//			m_cmdNewTemplate.Visible=true;
			this.TopMost = true;
			m_lblSign.Text = MDIParent.OperatorName;
			m_mthSetControlLiquid(m_dcmDosage);
			m_mthSetControlLiquid(m_dcmDrugName);
			m_mthSetControlOral(m_dcmInOral);
			m_mthSetControlOral(m_dcmInOralType);
			m_mthSetControlOral(m_dcmInOralProperty);
			m_mthSetControlOral(m_dcmInOralQuantity);
			#region 判断GE监护仪数据接口是否已经打开 Alex 2003-9-15
//			if(MDIParent.m_objGEMonitor != null)
//			{
//				m_cmdGetDovueData.Visible = false;
//				m_cmdGetGEData.Visible = true;
//			}
			#endregion
			
			this.m_dtpCreateDate.m_EnmVisibleFlag=MDIParent.s_ObjRecordDateTimeInfo.m_enmGetRecordTimeFlag(this.Name);
			this.m_dtpCreateDate.m_mthResetSize();

			m_trvCreateDate.Focus();
			
		}

		
		/// <summary>
		/// 获取选择已经删除记录的窗体标题
		/// </summary>
		/// <returns></returns>
 		public override string m_strReloadFormTitle()
		{
			return "危重症监护中心特护记录单";
		}

		/// <summary>
		/// 清空信息，并重置记录控制状态为不控制。
		/// </summary>
		protected override void m_mthClearRecordInfo()
		{
			//清空医师签名
            //m_lblSign.Text = "";
			m_mthClearUp2();
            //默认签名
            MDIParent.m_mthSetDefaulEmployee(txtSign);
            //m_objSignTool.m_mthSetDefaulEmployee();
		}

		/// <summary>
		/// 清空所有本条记录内容
		/// </summary>
		private void m_mthClearUp2()
		{
			m_txtMachineMode.m_mthClearText();
			m_txtBreathSoundLeft.m_mthClearText();
			m_txtBreathSoundRight.m_mthClearText();
			m_txtT.m_mthClearText();
			m_txtP.m_mthClearText();
			m_txtR.m_mthClearText();
			m_txtBp.m_mthClearText();
			m_txtCVP.m_mthClearText();
			m_txtBloodSugar.m_mthClearText();
			m_txtConsciousness.m_mthClearText();
			m_txtPupilSizeLeft.m_mthClearText();
			m_txtPupilSizeRight.m_mthClearText();
			m_txtReflectLeft.m_mthClearText();
			m_txtReflectRight.m_mthClearText();
			m_txtDirect1.m_mthClearText();
			m_txtStomachProperty.m_mthClearText();
			m_txtStomachQuantity.m_mthClearText();
			m_txtDirect2.m_mthClearText();
			m_txtPeeProperty.m_mthClearText();
			m_txtPeeQuantity.m_mthClearText();
			m_txtDefecateProperty.m_mthClearText();
			m_txtDefecateQuantity.m_mthClearText();
			m_txtDirect3.m_mthClearText();
			m_txtLeadProperty.m_mthClearText();
			m_txtLeadQuantity.m_mthClearText();
			m_txtSputumProperty.m_mthClearText();
			m_txtSputumQuantity.m_mthClearText();
			m_txtSkin.m_mthClearText();
			m_txtCaseHistory.m_mthClearText();
			m_txtDrugName.m_mthClearText();
			m_txtDrugDosage.m_mthClearText();
			m_txtInOral.m_mthClearText();
          
			try
			{
				m_dtbInLiquid.Rows.Clear();
				m_dtgInLiquid.CurrentRowIndex = 0;
				m_dtbInOral.Rows.Clear();
				m_dtgInOral.CurrentRowIndex = 0;
			}
			catch
			{}


		}

		/// <summary>
		/// 控制是否可以选择病人和记录时间列表。在从显示窗体调用时需要使用。
		/// </summary>
		/// <param name="p_blnEnable"></param>
		protected override void m_mthEnablePatientSelectSub(bool p_blnEnable)
		{
			p_blnEnable = false;
			if(p_blnEnable==false)
			{
				foreach(Control control in this.Controls)
				{					
					if(control.Name!="m_dtpCreateDate")
						control.Top=control.Top-115;				
				}
			
				cmdConfirm.Visible=true;
				
				this.Size=new Size(this.Size.Width, this.Size.Height-115);
				this.CenterToParent();	
		
				lblCreateDateTitle.Left=25;
				lblCreateDateTitle.Top=15;	
				m_dtpCreateDate.Left=lblCreateDateTitle.Right + 5;
				m_dtpCreateDate.Top=lblCreateDateTitle.Top;	
//				groupBox2.Left=m_dtpCreateDate.Right + 25;
//				groupBox2.Top=m_dtpCreateDate.Top - 5;

			}

			this.MaximizeBox=false;
		}

		/// <summary>
		/// 是否允许修改记录的记录信息。
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
		///  从界面获取记录的值。如果界面值出错，返回null。
		/// </summary>
		/// <returns></returns>
		protected override clsTrackRecordContent m_objGetContentFromGUI()
		{
			//界面参数校验
			if(m_objCurrentPatient==null)// || this.txtInPatientID.Text!=this.m_objCurrentPatient.m_StrHISInPatientID || txtInPatientID.Text=="")				
				return null;

			clsICUIntensiveTendContent objContent = new clsICUIntensiveTendContent();
            #region 是否可以无痕迹修改
            if (chkModifyWithoutMatk.Checked)
                objContent.m_intMarkStatus = 0;
            else
                objContent.m_intMarkStatus = 1;
            #endregion
			objContent.m_dtmCreateDate=m_dtpCreateDate.Value;					

			objContent.m_strMachineMode = m_txtMachineMode.Text;
			objContent.m_strMachineModeXML = m_txtMachineMode.m_strGetXmlText();
			objContent.m_strBreathSoundLeft = m_txtBreathSoundLeft.Text;
			objContent.m_strBreathSoundLeftXML = m_txtBreathSoundLeft.m_strGetXmlText();
			objContent.m_strBreathSoundRight = m_txtBreathSoundRight.Text;
			objContent.m_strBreathSoundRightXML = m_txtBreathSoundRight.m_strGetXmlText();
			objContent.m_strT = m_txtT.Text;
			objContent.m_strT_XML = m_txtT.m_strGetXmlText();
			objContent.m_strP = m_txtP.Text;
			objContent.m_strP_XML = m_txtP.m_strGetXmlText();
			objContent.m_strR = m_txtR.Text;
			objContent.m_strR_XML = m_txtR.m_strGetXmlText();
			objContent.m_strBp = m_txtBp.Text;
			objContent.m_strBp_XML = m_txtBp.m_strGetXmlText();
			objContent.m_strCVP = m_txtCVP.Text;
			objContent.m_strCVP_XML = m_txtCVP.m_strGetXmlText();
			objContent.m_strBloodSugar = m_txtBloodSugar.Text;
			objContent.m_strBloodSugarXML = m_txtBloodSugar.m_strGetXmlText();
			objContent.m_strConsciousness = m_txtConsciousness.Text;
			objContent.m_strConsciousnessXML = m_txtConsciousness.m_strGetXmlText();
			objContent.m_strPupilSizeLeft = m_txtPupilSizeLeft.Text;
			objContent.m_strPupilSizeLeftXML = m_txtPupilSizeLeft.m_strGetXmlText();
			objContent.m_strPupilSizeRight = m_txtPupilSizeRight.Text;
			objContent.m_strPupilSizeRightXML = m_txtPupilSizeRight.m_strGetXmlText();
			objContent.m_strReflectLeft = m_txtReflectLeft.Text;
			objContent.m_strReflectLeftXML = m_txtReflectLeft.m_strGetXmlText();
			objContent.m_strReflectRight = m_txtReflectRight.Text;
			objContent.m_strReflectRightXML = m_txtReflectRight.m_strGetXmlText();

			objContent.m_strStomachDirection = m_txtDirect1.Text;
			objContent.m_strStomachDirectionXML = m_txtDirect1.m_strGetXmlText();
			objContent.m_strStomachProperty = m_txtStomachProperty.Text;
			objContent.m_strStomachPropertyXML = m_txtStomachProperty.m_strGetXmlText();
			objContent.m_strStomachQuantity = m_txtStomachQuantity.Text;
			objContent.m_strStomachQuantityXML = m_txtStomachQuantity.m_strGetXmlText();

			objContent.m_strPeeDirection = m_txtDirect2.Text;
			objContent.m_strPeeDirectionXML = m_txtDirect2.m_strGetXmlText();
			objContent.m_strPeeProperty = m_txtPeeProperty.Text;
			objContent.m_strPeePropertyXML = m_txtPeeProperty.m_strGetXmlText();
			objContent.m_strPeeQuantity = m_txtPeeQuantity.Text;
			objContent.m_strPeeQuantityXML = m_txtPeeQuantity.m_strGetXmlText();
			objContent.m_strDefecateProperty = m_txtDefecateProperty.Text;
			objContent.m_strDefecatePropertyXML = m_txtDefecateProperty.m_strGetXmlText();
			objContent.m_strDefecateQuantity = m_txtDefecateQuantity.Text;
			objContent.m_strDefecateQuantityXML = m_txtDefecateQuantity.m_strGetXmlText();
			objContent.m_strLeadDirection = m_txtDirect3.Text;
			objContent.m_strLeadDirectionXML = m_txtDirect3.m_strGetXmlText();
			objContent.m_strLeadProperty = m_txtLeadProperty.Text;
			objContent.m_strLeadPropertyXML = m_txtLeadProperty.m_strGetXmlText();
			objContent.m_strLeadQuantity = m_txtLeadQuantity.Text;
			objContent.m_strLeadQuantityXML = m_txtLeadQuantity.m_strGetXmlText();
			objContent.m_strSputumProperty = m_txtSputumProperty.Text;
			objContent.m_strSputumPropertyXML = m_txtSputumProperty.m_strGetXmlText();
			objContent.m_strSputumQuantity = m_txtSputumQuantity.Text;
			objContent.m_strSputumQuantityXML = m_txtSputumQuantity.m_strGetXmlText();
			objContent.m_strSkin = m_txtSkin.Text;
			objContent.m_strSkinXML = m_txtSkin.m_strGetXmlText();
			objContent.m_strCaseHistory = m_txtCaseHistory.Text;
			objContent.m_strCaseHistoryXML = m_txtCaseHistory.m_strGetXmlText();

			objContent.m_strHR = m_txtHR.Text;
			objContent.m_strHR_XML = m_txtHR.m_strGetXmlText();
			objContent.m_strBp2 = m_txtBp2.Text;
			objContent.m_strBp2_XML = m_txtBp2.m_strGetXmlText();
			objContent.m_strPower = m_txtPower.Text;
			objContent.m_strPowerXML = m_txtPower.m_strGetXmlText();
			objContent.m_strStomachPipe = m_txtStomachPipe.Text;
			objContent.m_strStomachPipeXML = m_txtStomachPipe.m_strGetXmlText();
			objContent.m_strInOralType = m_txtInOralType.Text;
			objContent.m_strInOralTypeXML = m_txtInOralType.m_strGetXmlText();
			objContent.m_strInOralProperty = m_txtInOralProperty.Text;
			objContent.m_strInOralPropertyXML = m_txtInOralProperty.m_strGetXmlText();
			objContent.m_strInOralQuantity = m_txtInOralQuantity.Text;
			objContent.m_strInOralQuantityXML = m_txtInOralQuantity.m_strGetXmlText();
			objContent.m_strTransfusionTotal = m_txtTransfusion.Text;
			objContent.m_strTransfusionTotalXML = m_txtTransfusion.m_strGetXmlText();
			objContent.m_strTakeFoodTotal = m_txtTakeFood.Text;
			objContent.m_strTakeFoodTotalXML = m_txtTakeFood.m_strGetXmlText();
			objContent.m_strLeadPipe = m_txtLeadPipe.Text;
			objContent.m_strLeadPipeXML = m_txtLeadPipe.m_strGetXmlText();
			objContent.m_strDefecateTimes = m_txtDefecateTimes.Text;
			objContent.m_strDefecateTimesXML = m_txtDefecateTimes.m_strGetXmlText();

			m_mthGetInLiquidXML(out objContent.m_strDrugName,out objContent.m_strDrugNameXML,out objContent.m_strDrugDosage,out objContent.m_strDrugDosageXML);
			m_mthGetInOralXML(out objContent.m_strInOralType,out objContent.m_strInOralTypeXML,out objContent.m_strInOral,out objContent.m_strInOralXML,out objContent.m_strInOralProperty,out objContent.m_strInOralPropertyXML,out objContent.m_strInOralQuantity,out objContent.m_strInOralQuantityXML);

			objContent.m_strMachineMode_Last = m_txtMachineMode.m_strGetRightText();
			objContent.m_strBreathSoundLeft_Last = m_txtBreathSoundLeft.m_strGetRightText();
			objContent.m_strBreathSoundRight_Last = m_txtBreathSoundRight.m_strGetRightText();
			objContent.m_strT_Last = m_txtT.m_strGetRightText();
			objContent.m_strP_Last = m_txtP.m_strGetRightText();
			objContent.m_strR_Last = m_txtR.m_strGetRightText();
			objContent.m_strBp_Last = m_txtBp.m_strGetRightText();
			objContent.m_strCVP_Last = m_txtCVP.m_strGetRightText();
			objContent.m_strBloodSugar_Last = m_txtBloodSugar.m_strGetRightText();
			objContent.m_strConsciousness_Last = m_txtConsciousness.m_strGetRightText();
			objContent.m_strPupilSizeLeft_Last = m_txtPupilSizeLeft.m_strGetRightText();
			objContent.m_strPupilSizeRight_Last = m_txtPupilSizeRight.m_strGetRightText();
			objContent.m_strReflectLeft_Last = m_txtReflectLeft.m_strGetRightText();
			objContent.m_strReflectRight_Last = m_txtReflectRight.m_strGetRightText();
			objContent.m_strStomachDirection_Last = m_txtDirect1.m_strGetRightText();
			objContent.m_strStomachProperty_Last = m_txtStomachProperty.m_strGetRightText();
			objContent.m_strStomachQuantity_Last = m_txtStomachQuantity.m_strGetRightText();
			objContent.m_strPeeDirection_Last = m_txtDirect2.m_strGetRightText();
			objContent.m_strPeeProperty_Last = m_txtPeeProperty.m_strGetRightText();
			objContent.m_strPeeQuantity_Last = m_txtPeeQuantity.m_strGetRightText();
			objContent.m_strDefecateProperty_Last = m_txtDefecateProperty.m_strGetRightText();
			objContent.m_strDefecateQuantity_Last = m_txtDefecateQuantity.m_strGetRightText();
			objContent.m_strLeadDirection_Last = m_txtDirect3.m_strGetRightText();
			objContent.m_strLeadProperty_Last = m_txtLeadProperty.m_strGetRightText();
			objContent.m_strLeadQuantity_Last = m_txtLeadQuantity.m_strGetRightText();
			objContent.m_strSputumProperty_Last = m_txtSputumProperty.m_strGetRightText();
			objContent.m_strSputumQuantity_Last = m_txtSputumQuantity.m_strGetRightText();
			objContent.m_strSkin_Last = m_txtSkin.m_strGetRightText();
			objContent.m_strCaseHistory_Last = m_txtCaseHistory.m_strGetRightText();

			objContent.m_strHR_Last = m_txtHR.m_strGetRightText();
			objContent.m_strBp2_Last = m_txtBp2.m_strGetRightText();
			objContent.m_strPower_Last = m_txtPower.m_strGetRightText();
			objContent.m_strStomachPipe_Last = m_txtStomachPipe.m_strGetRightText();
			objContent.m_strTransfusionTotal_Last = m_txtTransfusion.m_strGetRightText();
			objContent.m_strTakeFoodTotal_Last = m_txtTakeFood.m_strGetRightText();
            objContent.m_strLeadPipe_Last = m_txtLeadPipe.m_strGetRightText();
			objContent.m_strDefecateTimes_Last = m_txtDefecateTimes.m_strGetRightText();

            //objContent.m_strModifyUserID = clsEMRLogin.LoginInfo.m_strEmpNo;
            objContent.m_strModifyUserID = ((clsEmrEmployeeBase_VO)txtSign.Tag).m_strEMPNO_CHR;
            //获取签名 strUserIDList = "";
            strUserNameList = "";
            m_mthGetSignArr(new Control[] { txtSign }, ref objContent.objSignerArr, ref strUserIDList, ref strUserNameList);
            //objContent.objSignerArr = new clsEmrSigns_VO[1];
            //objContent.objSignerArr[0] = new clsEmrSigns_VO();
            //objContent.objSignerArr[0].objEmployee = new clsEmrEmployeeBase_VO();
            //objContent.objSignerArr[0].objEmployee = (clsEmrEmployeeBase_VO)(txtSign.Tag);
            //objContent.objSignerArr[0].controlName = "txtSign";
            //objContent.objSignerArr[0].m_strFORMID_VCHR = "frmSubICUIntensiveTend";//注意大小写
            //objContent.objSignerArr[0].m_strREGISTERID_CHR = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;

			if(m_dtgInLiquid.Tag == null)
				objContent.m_objInLiquidArr = null;
			else
				objContent.m_objInLiquidArr = ((clsICUIntensiveTendInLiquidContent[]) m_dtgInLiquid.Tag);
			if(m_dtgInOral.Tag == null)
				objContent.m_objInOralArr = null;
			else
				objContent.m_objInOralArr = ((clsICUIntensiveTendInOralContent[])m_dtgInOral.Tag);
			return objContent;	
			
		}

		/// <summary>
		/// 把特殊记录的值显示到界面上。
		/// </summary>
		/// <param name="p_objContent"></param>
		protected override void m_mthSetGUIFromContent(clsTrackRecordContent p_objContent)
		{
			clsICUIntensiveTendContent objContent = (clsICUIntensiveTendContent)p_objContent;
		
			//把表单值赋值到界面，由子窗体重载实现
			m_mthClearUp2();

			m_txtMachineMode.m_mthSetNewText(objContent.m_strMachineMode,objContent.m_strMachineModeXML);
			m_txtBreathSoundLeft.m_mthSetNewText(objContent.m_strBreathSoundLeft,objContent.m_strBreathSoundLeftXML);
			m_txtBreathSoundRight.m_mthSetNewText(objContent.m_strBreathSoundRight,objContent.m_strBreathSoundRightXML);
			m_txtT.m_mthSetNewText(objContent.m_strT,objContent.m_strT_XML);
			m_txtP.m_mthSetNewText(objContent.m_strP,objContent.m_strP_XML);
			m_txtR.m_mthSetNewText(objContent.m_strR,objContent.m_strR_XML);
			m_txtBp.m_mthSetNewText(objContent.m_strBp,objContent.m_strBp_XML);
			m_txtCVP.m_mthSetNewText(objContent.m_strCVP,objContent.m_strCVP_XML);
			m_txtBloodSugar.m_mthSetNewText(objContent.m_strBloodSugar,objContent.m_strBloodSugarXML);
			m_txtConsciousness.m_mthSetNewText(objContent.m_strConsciousness,objContent.m_strConsciousnessXML);
			m_txtPupilSizeLeft.m_mthSetNewText(objContent.m_strPupilSizeLeft,objContent.m_strPupilSizeLeftXML);
			m_txtPupilSizeRight.m_mthSetNewText(objContent.m_strPupilSizeRight,objContent.m_strPupilSizeRightXML);
			m_txtReflectLeft.m_mthSetNewText(objContent.m_strReflectLeft,objContent.m_strReflectLeftXML);
			m_txtReflectRight.m_mthSetNewText(objContent.m_strReflectRight,objContent.m_strReflectRightXML);
			m_txtDirect1.m_mthSetNewText(objContent.m_strStomachDirection,objContent.m_strStomachDirectionXML);
			m_txtStomachProperty.m_mthSetNewText(objContent.m_strStomachProperty,objContent.m_strStomachPropertyXML);
			m_txtStomachQuantity.m_mthSetNewText(objContent.m_strStomachQuantity,objContent.m_strStomachQuantityXML);

			m_txtDirect2.m_mthSetNewText(objContent.m_strPeeDirection,objContent.m_strPeeDirectionXML);
			m_txtPeeProperty.m_mthSetNewText(objContent.m_strPeeProperty,objContent.m_strPeePropertyXML);
			m_txtPeeQuantity.m_mthSetNewText(objContent.m_strPeeQuantity,objContent.m_strPeeQuantityXML);
			m_txtDefecateProperty.m_mthSetNewText(objContent.m_strDefecateProperty,objContent.m_strDefecatePropertyXML);
			m_txtDefecateQuantity.m_mthSetNewText(objContent.m_strDefecateQuantity,objContent.m_strDefecateQuantityXML);
			m_txtDirect3.m_mthSetNewText(objContent.m_strLeadDirection,objContent.m_strLeadDirectionXML);
			m_txtLeadProperty.m_mthSetNewText(objContent.m_strLeadProperty,objContent.m_strLeadPropertyXML);
			m_txtLeadQuantity.m_mthSetNewText(objContent.m_strLeadQuantity,objContent.m_strLeadQuantityXML);
			m_txtSputumProperty.m_mthSetNewText(objContent.m_strSputumProperty,objContent.m_strSputumPropertyXML);
			m_txtSputumQuantity.m_mthSetNewText(objContent.m_strSputumQuantity,objContent.m_strSputumQuantityXML);
			m_txtSkin.m_mthSetNewText(objContent.m_strSkin,objContent.m_strSkinXML);
			m_txtCaseHistory.m_mthSetNewText(objContent.m_strCaseHistory,objContent.m_strCaseHistoryXML);

			m_txtHR.m_mthSetNewText(objContent.m_strHR,objContent.m_strHR_XML);
			m_txtBp2.m_mthSetNewText(objContent.m_strBp2,objContent.m_strBp2_XML);
			m_txtPower.m_mthSetNewText(objContent.m_strPower,objContent.m_strPowerXML);
			m_txtStomachPipe.m_mthSetNewText(objContent.m_strStomachPipe,objContent.m_strStomachPipeXML);
			m_txtTransfusion.m_mthSetNewText(objContent.m_strTransfusionTotal,objContent.m_strTransfusionTotalXML);
			m_txtTakeFood.m_mthSetNewText(objContent.m_strTakeFoodTotal,objContent.m_strTakeFoodTotalXML);
			m_txtLeadPipe.m_mthSetNewText(objContent.m_strLeadPipe,objContent.m_strLeadPipeXML);
			m_txtDefecateTimes.m_mthSetNewText(objContent.m_strDefecateTimes,objContent.m_strDefecateTimesXML);

			m_mthSetInOralInfo(objContent.m_strInOralType,objContent.m_strInOralTypeXML,objContent.m_strInOral,objContent.m_strInOralXML,objContent.m_strInOralProperty,objContent.m_strInOralPropertyXML,objContent.m_strInOralQuantity,objContent.m_strInOralQuantityXML);
			m_mthSetInLiquidInfo(objContent.m_strDrugName,objContent.m_strDrugNameXML,objContent.m_strDrugDosage,objContent.m_strDrugDosageXML);
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

		protected override void m_mthSetDeletedGUIFromContent(clsTrackRecordContent p_objContent)
		{
			clsICUIntensiveTendContent objContent = (clsICUIntensiveTendContent)p_objContent;
		
			//把表单值赋值到界面，由子窗体重载实现
			m_mthClearUp2();

			m_txtMachineMode.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strMachineMode,objContent.m_strMachineModeXML);
			m_txtBreathSoundLeft.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strBreathSoundLeft,objContent.m_strBreathSoundLeftXML);
			m_txtBreathSoundRight.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strBreathSoundRight,objContent.m_strBreathSoundRightXML);
			m_txtT.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strT,objContent.m_strT_XML);
			m_txtP.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strP,objContent.m_strP_XML);
			m_txtR.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strR,objContent.m_strR_XML);
			m_txtBp.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strBp,objContent.m_strBp_XML);
			m_txtCVP.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strCVP,objContent.m_strCVP_XML);
			m_txtBloodSugar.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strBloodSugar,objContent.m_strBloodSugarXML);
			m_txtConsciousness.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strConsciousness,objContent.m_strConsciousnessXML);
			m_txtPupilSizeLeft.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strPupilSizeLeft,objContent.m_strPupilSizeLeftXML);
			m_txtPupilSizeRight.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strPupilSizeRight,objContent.m_strPupilSizeRightXML);
			m_txtReflectLeft.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strReflectLeft,objContent.m_strReflectLeftXML);
			m_txtReflectRight.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strReflectRight,objContent.m_strReflectRightXML);
			m_txtDirect1.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strStomachDirection,objContent.m_strStomachDirectionXML);
			m_txtStomachProperty.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strStomachProperty,objContent.m_strStomachPropertyXML);
			m_txtStomachQuantity.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strStomachQuantity,objContent.m_strStomachQuantityXML);

			m_txtDirect2.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strPeeDirection,objContent.m_strPeeDirectionXML);
			m_txtPeeProperty.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strPeeProperty,objContent.m_strPeePropertyXML);
			m_txtPeeQuantity.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strPeeQuantity,objContent.m_strPeeQuantityXML);
			m_txtDefecateProperty.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDefecateProperty,objContent.m_strDefecatePropertyXML);
			m_txtDefecateQuantity.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDefecateQuantity,objContent.m_strDefecateQuantityXML);
			m_txtDirect3.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strLeadDirection,objContent.m_strLeadDirectionXML);
			m_txtLeadProperty.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strLeadProperty,objContent.m_strLeadPropertyXML);
			m_txtLeadQuantity.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strLeadQuantity,objContent.m_strLeadQuantityXML);
			m_txtSputumProperty.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strSputumProperty,objContent.m_strSputumPropertyXML);
			m_txtSputumQuantity.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strSputumQuantity,objContent.m_strSputumQuantityXML);
			m_txtSkin.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strSkin,objContent.m_strSkinXML);
			m_txtCaseHistory.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strCaseHistory,objContent.m_strCaseHistoryXML);

			m_txtHR.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strHR,objContent.m_strHR_XML);
			m_txtBp2.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strBp2,objContent.m_strBp2_XML);
			m_txtPower.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strPower,objContent.m_strPowerXML);
			m_txtStomachPipe.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strStomachPipe,objContent.m_strStomachPipeXML);
			m_txtTransfusion.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strTransfusionTotal,objContent.m_strTransfusionTotalXML);
			m_txtTakeFood.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strTakeFoodTotal,objContent.m_strTakeFoodTotalXML);
			m_txtLeadPipe.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strLeadPipe,objContent.m_strLeadPipeXML);
			m_txtDefecateTimes.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDefecateTimes,objContent.m_strDefecateTimesXML);

			m_mthSetRightInOralInfo(objContent.m_strInOralType,objContent.m_strInOralTypeXML,objContent.m_strInOral,objContent.m_strInOralXML,objContent.m_strInOralProperty,objContent.m_strInOralPropertyXML,objContent.m_strInOralQuantity,objContent.m_strInOralQuantityXML);
			m_mthSetRightInLiquidInfo(objContent.m_strDrugName,objContent.m_strDrugNameXML,objContent.m_strDrugDosage,objContent.m_strDrugDosageXML);
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

		/// <summary>
		///  获取记录的领域层实例
		/// </summary>
		/// <returns></returns>
		protected override clsDiseaseTrackDomain m_objGetDiseaseTrackDomain()
		{
			//获取记录的领域层实例，由子窗体重载实现
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.ICUIntensiveTend);					
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

		/// <summary>
		/// 用于添加记录时暂时存放输液数据所用
		/// </summary>
		private DataTable m_dtbTempTable;
		/// <summary>
		/// 用于添加记录时暂时存放口服数据所用
		/// </summary>
		private DataTable m_dtbTempTable1;

	
		private void cmdDrugSubmit_Click(object sender, System.EventArgs e)
		{
			clsICUIntensiveTendInLiquidContent objContent = new clsICUIntensiveTendInLiquidContent();
			objContent.m_strDrugName = m_txtDrugName.Text;
			objContent.m_strDrugName_Last = m_txtDrugName.m_strGetRightText();
			objContent.m_strDrugNameXML = m_txtDrugName.m_strGetXmlText();
			objContent.m_strDrugDosage = m_txtDrugDosage.Text;
			objContent.m_strDrugDosage_Last = m_txtDrugDosage.m_strGetRightText();
			objContent.m_strDrugDosageXML = m_txtDrugDosage.m_strGetXmlText();

			if(objContent.m_strDrugName_Last == null || objContent.m_strDrugName_Last == "")
			{
				clsPublicFunction.ShowInformationMessageBox("请输入药品内容！");
				return;
			}
			if(objContent.m_strDrugDosage_Last == null || objContent.m_strDrugDosage_Last == "")
			{
				clsPublicFunction.ShowInformationMessageBox("请输入药品量！");
				return;
			}
			#region 控制药口入量应该为数值，现在不用。
//			try
//			{
//				float.Parse(objContent.m_strDrugDosage_Last.ToString());
//			}
//			catch
//			{
//				clsPublicFunction.ShowInformationMessageBox("药品入量应该为数值！");
//				return;
//			}
			#endregion

			clsDSTRichTextBoxValue [] objValueArr =new clsDSTRichTextBoxValue[2];
			objValueArr[0] = new clsDSTRichTextBoxValue();
			objValueArr[0].m_strText=objContent.m_strDrugName;						
			objValueArr[0].m_strDSTXml=objContent.m_strDrugNameXML;

			objValueArr[1] = new clsDSTRichTextBoxValue();
			objValueArr[1].m_strText=objContent.m_strDrugDosage;						
			objValueArr[1].m_strDSTXml=objContent.m_strDrugDosageXML;

			if(m_dtgInLiquid.Tag == null)
				m_dtgInLiquid.Tag = new clsICUIntensiveTendInLiquidContent[] {objContent};
			else
			{
				ArrayList arlTemp = new ArrayList();
				arlTemp.AddRange(((clsICUIntensiveTendInLiquidContent[])m_dtgInLiquid.Tag));
				if(m_gpbInLiquid.Tag != null)
				{
					int intModifyIndex = Convert.ToInt16(m_gpbInLiquid.Tag);
					arlTemp.RemoveAt(intModifyIndex);
					mniRemoveLiquid_Click(null,null);
				}
				arlTemp.Add(objContent);
				m_dtgInLiquid.Tag = (clsICUIntensiveTendInLiquidContent[])arlTemp.ToArray(typeof(clsICUIntensiveTendInLiquidContent));
			}

			DataRow m_dtrNewRow;

			DataRow dtrNew = m_dtbInLiquid.NewRow();
			dtrNew.ItemArray = objValueArr;
			if(m_intInsertIndex==-1)
			{
				m_dtbInLiquid.Rows.Add(dtrNew);
			}
			else
			{
				if(m_dtbTempTable == null)
				{
					m_dtbTempTable = m_dtbInLiquid.Clone();//只是克隆表的结构
				}

				//将插入点以后的记录暂放到内存中
				//此句不可用for(int i=m_intInsertIndex;i<m_dtbInLiquid.Rows.Count;i++)
				//因为m_dtbInLiquid.Rows.Count一直在减
				while(m_intInsertIndex < m_dtbInLiquid.Rows.Count)
				{
					m_dtrNewRow = m_dtbTempTable.NewRow();
					m_dtrNewRow.ItemArray = m_dtbInLiquid.Rows[m_intInsertIndex].ItemArray;
					m_dtbTempTable.Rows.Add(m_dtrNewRow);
					m_dtbInLiquid.Rows.RemoveAt(m_intInsertIndex);
				}
				//将新的记录添加进来
				m_dtbInLiquid.Rows.Add(dtrNew);
				//把内存中的记录，再添加回去
				for(int i=0;i<m_dtbTempTable.Rows.Count;i++)
				{
					m_dtrNewRow = m_dtbInLiquid.NewRow();
					m_dtrNewRow.ItemArray = m_dtbTempTable.Rows[i].ItemArray;
					m_dtbInLiquid.Rows.Add(m_dtrNewRow);
				}

				if(m_dtbTempTable != null)
				{
					m_dtbTempTable.Rows.Clear();
				}

				m_intInsertIndex = -1;

			}
			m_gpbInLiquid.Tag = null;
			m_txtDrugName.m_mthClearText();
			m_txtDrugDosage.m_mthClearText();			
		}

		private void m_cmdInOralSubmit_Click(object sender, System.EventArgs e)
		{
			clsICUIntensiveTendInOralContent objContent = new clsICUIntensiveTendInOralContent();
			objContent.m_strInOral = m_txtInOral.Text;
			objContent.m_strInOralXML = m_txtInOral.m_strGetXmlText();
			objContent.m_strInOral_Last = m_txtInOral.m_strGetRightText();
	
			objContent.m_strInOralType = m_txtInOralType.Text;
			objContent.m_strInOralTypeXML = m_txtInOralType.m_strGetXmlText();
			objContent.m_strInOralType_Last = m_txtInOralType.m_strGetRightText();

			objContent.m_strInOralProperty = m_txtInOralProperty.Text;
			objContent.m_strInOralPropertyXML = m_txtInOralProperty.m_strGetXmlText();
			objContent.m_strInOralProperty_Last = m_txtInOralProperty.m_strGetRightText();

			objContent.m_strInOralQuantity = m_txtInOralQuantity.Text;
			objContent.m_strInOralQuantityXML = m_txtInOralQuantity.m_strGetXmlText();
			objContent.m_strInOralQuantity_Last = m_txtInOralQuantity.m_strGetRightText();

			if(objContent.m_strInOral_Last == null || objContent.m_strInOral_Last == "")
			{
				clsPublicFunction.ShowInformationMessageBox("请输入口服药！");
				return;
			}

			if(objContent.m_strInOralType_Last == null || objContent.m_strInOralType_Last == "")
			{
				clsPublicFunction.ShowInformationMessageBox("请输入口服类型！");
				return;
			}

			if(objContent.m_strInOralProperty_Last == null || objContent.m_strInOralProperty_Last == "")
			{
				clsPublicFunction.ShowInformationMessageBox("请输入口服性质！");
				return;
			}

			if(objContent.m_strInOralQuantity_Last == null || objContent.m_strInOralQuantity_Last == "")
			{
				clsPublicFunction.ShowInformationMessageBox("请输入口服量！");
				return;
			}

			clsDSTRichTextBoxValue [] objValueArr =new clsDSTRichTextBoxValue[4];
			objValueArr[1] = new clsDSTRichTextBoxValue();
			objValueArr[1].m_strText=objContent.m_strInOral;						
			objValueArr[1].m_strDSTXml=objContent.m_strInOralXML;

			objValueArr[0] = new clsDSTRichTextBoxValue();
			objValueArr[0].m_strText=objContent.m_strInOralType;						
			objValueArr[0].m_strDSTXml=objContent.m_strInOralTypeXML;

			objValueArr[2] = new clsDSTRichTextBoxValue();
			objValueArr[2].m_strText=objContent.m_strInOralProperty;						
			objValueArr[2].m_strDSTXml=objContent.m_strInOralPropertyXML;

			objValueArr[3] = new clsDSTRichTextBoxValue();
			objValueArr[3].m_strText=objContent.m_strInOralQuantity;						
			objValueArr[3].m_strDSTXml=objContent.m_strInOralQuantityXML;

			if(m_dtgInOral.Tag == null)
				m_dtgInOral.Tag = new clsICUIntensiveTendInOralContent[] {objContent};
			else
			{
				ArrayList arlTemp = new ArrayList();
				arlTemp.AddRange(((clsICUIntensiveTendInOralContent[])m_dtgInOral.Tag));
				if(m_gpbInOral.Tag != null)
				{
					int intModifyIndex = Convert.ToInt16(m_gpbInOral.Tag);
					arlTemp.RemoveAt(intModifyIndex);
					mniRemove_Click(null,null);
				}
				arlTemp.Add(objContent);
				m_dtgInOral.Tag = (clsICUIntensiveTendInOralContent[])arlTemp.ToArray(typeof(clsICUIntensiveTendInOralContent));
			}

//			m_gpbInOral.Tag = null;
//			m_dtbInOral.Rows.Add(new object[] {objValue});
//			m_txtInOral.m_mthClearText();

			DataRow m_dtrNewRow;
			DataRow dtrNew = m_dtbInOral.NewRow();
			dtrNew.ItemArray = objValueArr;

			if(m_intInsertInOralIndex==-1)
			{
				m_dtbInOral.Rows.Add(dtrNew);
			}
			else
			{
				if(m_dtbTempTable1 == null)
				{
					m_dtbTempTable1 = m_dtbInOral.Clone();//只是克隆表的结构
				}

				//将插入点以后的记录暂放到内存中
				//此句不可用for(int i=m_intInsertInOralIndex;i<m_dtbInOral.Rows.Count;i++)
				//因为m_dtbInOral.Rows.Count一直在减
				while(m_intInsertInOralIndex < m_dtbInOral.Rows.Count)
				{
					m_dtrNewRow = m_dtbTempTable1.NewRow();
					m_dtrNewRow.ItemArray = m_dtbInOral.Rows[m_intInsertInOralIndex].ItemArray;
					m_dtbTempTable1.Rows.Add(m_dtrNewRow);
					m_dtbInOral.Rows.RemoveAt(m_intInsertInOralIndex);
				}
				//将新的记录添加进来
				m_dtbInOral.Rows.Add(dtrNew);
				//把内存中的记录，再添加回去
				for(int i=0;i<m_dtbTempTable1.Rows.Count;i++)
				{
					m_dtrNewRow = m_dtbInOral.NewRow();
					m_dtrNewRow.ItemArray = m_dtbTempTable1.Rows[i].ItemArray;
					m_dtbInOral.Rows.Add(m_dtrNewRow);
				}

				if(m_dtbTempTable1 != null)
				{
					m_dtbTempTable1.Rows.Clear();
				}

				m_intInsertInOralIndex = -1;

			}
			
			m_gpbInOral.Tag = null;
			m_txtInOral.m_mthClearText();
			m_txtInOralType.m_mthClearText();
			m_txtInOralProperty.m_mthClearText();
			m_txtInOralQuantity.m_mthClearText();
		}

		private void m_mthSetInOralInfo(string p_strInOralTypeAll,string p_strInOralTypeXMLAll,string p_strInOralAll,string p_strInOralXMLAll,string p_strInOralPropertyAll,string p_strInOralPropertyXMLAll,string p_strInOralQuantityAll,string p_strInOralQuantityXMLAll)
		{
			System.Xml.XmlDocument doc1 = new System.Xml.XmlDocument();
			
			doc1.LoadXml(p_strInOralTypeAll);
			System.Xml.XmlNode root1  = doc1.FirstChild;
			doc1.LoadXml(p_strInOralTypeAll);
			System.Xml.XmlNode root2  = doc1.FirstChild;

			doc1.LoadXml(p_strInOralAll);
			System.Xml.XmlNode root3  = doc1.FirstChild;
			doc1.LoadXml(p_strInOralXMLAll);
			System.Xml.XmlNode root4  = doc1.FirstChild;

			doc1.LoadXml(p_strInOralPropertyAll);
			System.Xml.XmlNode root5  = doc1.FirstChild;
			doc1.LoadXml(p_strInOralPropertyXMLAll);
			System.Xml.XmlNode root6  = doc1.FirstChild;

			doc1.LoadXml(p_strInOralQuantityAll);
			System.Xml.XmlNode root7  = doc1.FirstChild;
			doc1.LoadXml(p_strInOralQuantityXMLAll);
			System.Xml.XmlNode root8  = doc1.FirstChild;
            
			m_dtbInOral.Rows.Clear();
			m_dtgInOral.CurrentRowIndex = 0;

			int intInOralLength = root1.ChildNodes.Count;
			if(intInOralLength <= 0)
				return;

			DataRow dtrNew;

			clsICUIntensiveTendInOralContent[] objContentArr = new clsICUIntensiveTendInOralContent[intInOralLength];
			clsDSTRichTextBoxValue[] objValueArr = null;

			for(int i1=0;i1<intInOralLength;i1++)
			{
				objContentArr[i1] = new clsICUIntensiveTendInOralContent();

				objContentArr[i1].m_strInOralType = root1.ChildNodes[i1].InnerText;
				objContentArr[i1].m_strInOralTypeXML = root2.ChildNodes[i1].InnerXml;

				objContentArr[i1].m_strInOral = root3.ChildNodes[i1].InnerText;
				objContentArr[i1].m_strInOralXML = root4.ChildNodes[i1].InnerXml;

				objContentArr[i1].m_strInOralProperty = root5.ChildNodes[i1].InnerText;
				objContentArr[i1].m_strInOralPropertyXML = root6.ChildNodes[i1].InnerXml;

				objContentArr[i1].m_strInOralQuantity = root7.ChildNodes[i1].InnerText;
				objContentArr[i1].m_strInOralQuantityXML = root8.ChildNodes[i1].InnerXml;

//				objValue=new clsDSTRichTextBoxValue();
//				objValue.m_strText=objContentArr[i1].m_strInOral;						
//				objValue.m_strDSTXml=objContentArr[i1].m_strInOralXML;
//				dtrNew = m_dtbInOral.NewRow();
//				dtrNew.ItemArray = new object []{objValue};
//				m_dtbInOral.Rows.Add(dtrNew);

				objValueArr =new clsDSTRichTextBoxValue[4];

				dtrNew = m_dtbInOral.NewRow();

				objValueArr[0] = new clsDSTRichTextBoxValue();
				objValueArr[0].m_strText=objContentArr[i1].m_strInOralType;						
				objValueArr[0].m_strDSTXml=objContentArr[i1].m_strInOralTypeXML;

				objValueArr[1] = new clsDSTRichTextBoxValue();
				objValueArr[1].m_strText=objContentArr[i1].m_strInOral;						
				objValueArr[1].m_strDSTXml=objContentArr[i1].m_strInOralXML;

				objValueArr[2] = new clsDSTRichTextBoxValue();
				objValueArr[2].m_strText=objContentArr[i1].m_strInOralProperty;						
				objValueArr[2].m_strDSTXml=objContentArr[i1].m_strInOralPropertyXML;

				objValueArr[3] = new clsDSTRichTextBoxValue();
				objValueArr[3].m_strText=objContentArr[i1].m_strInOralQuantity;						
				objValueArr[3].m_strDSTXml=objContentArr[i1].m_strInOralQuantityXML;

				dtrNew.ItemArray = objValueArr;
				m_dtbInOral.Rows.Add(dtrNew);
			}
			m_dtgInOral.Tag = objContentArr;
		}

		private void m_mthSetRightInOralInfo(string p_strInOralTypeAll,string p_strInOralTypeXMLAll,string p_strInOralAll,string p_strInOralXMLAll,string p_strInOralPropertyAll,string p_strInOralPropertyXMLAll,string p_strInOralQuantityAll,string p_strInOralQuantityXMLAll)
		{
			System.Xml.XmlDocument doc1 = new System.Xml.XmlDocument();

			doc1.LoadXml(p_strInOralTypeAll);
			System.Xml.XmlNode root1  = doc1.FirstChild;
			doc1.LoadXml(p_strInOralTypeAll);
			System.Xml.XmlNode root2  = doc1.FirstChild;

			doc1.LoadXml(p_strInOralAll);
			System.Xml.XmlNode root3  = doc1.FirstChild;
			doc1.LoadXml(p_strInOralXMLAll);
			System.Xml.XmlNode root4  = doc1.FirstChild;

			doc1.LoadXml(p_strInOralPropertyAll);
			System.Xml.XmlNode root5  = doc1.FirstChild;
			doc1.LoadXml(p_strInOralPropertyXMLAll);
			System.Xml.XmlNode root6  = doc1.FirstChild;

			doc1.LoadXml(p_strInOralQuantityAll);
			System.Xml.XmlNode root7  = doc1.FirstChild;
			doc1.LoadXml(p_strInOralQuantityXMLAll);
			System.Xml.XmlNode root8  = doc1.FirstChild;
			m_dtbInOral.Rows.Clear();
			m_dtgInOral.CurrentRowIndex = 0;

			int intInOralLength = root1.ChildNodes.Count;
			if(intInOralLength <= 0)
				return;

			DataRow dtrNew;
			clsICUIntensiveTendInOralContent[] objContentArr = new clsICUIntensiveTendInOralContent[intInOralLength];
			clsDSTRichTextBoxValue[] objValueArr = null;

			for(int i1=0;i1<intInOralLength;i1++)
			{
				objContentArr[i1] = new clsICUIntensiveTendInOralContent();

				objContentArr[i1].m_strInOralType = root1.ChildNodes[i1].InnerText;
				objContentArr[i1].m_strInOralTypeXML = root2.ChildNodes[i1].InnerXml;

				objContentArr[i1].m_strInOral = root3.ChildNodes[i1].InnerText;
				objContentArr[i1].m_strInOralXML = root4.ChildNodes[i1].InnerXml;

				objContentArr[i1].m_strInOralProperty = root5.ChildNodes[i1].InnerText;
				objContentArr[i1].m_strInOralPropertyXML = root6.ChildNodes[i1].InnerXml;

				objContentArr[i1].m_strInOralQuantity = root7.ChildNodes[i1].InnerText;
				objContentArr[i1].m_strInOralQuantityXML = root8.ChildNodes[i1].InnerXml;

				objValueArr =new clsDSTRichTextBoxValue[4];

				dtrNew = m_dtbInOral.NewRow();

				objValueArr[0] = new clsDSTRichTextBoxValue();
				objValueArr[0].m_strText=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContentArr[i1].m_strInOralType,objContentArr[i1].m_strInOralTypeXML);						
				objValueArr[0].m_strDSTXml="<root />";

				objValueArr[1] = new clsDSTRichTextBoxValue();
				objValueArr[1].m_strText=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContentArr[i1].m_strInOral,objContentArr[i1].m_strInOralXML);						
				objValueArr[1].m_strDSTXml="<root />";

				objValueArr[2] = new clsDSTRichTextBoxValue();
				objValueArr[2].m_strText=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContentArr[i1].m_strInOralProperty,objContentArr[i1].m_strInOralPropertyXML);						
				objValueArr[2].m_strDSTXml="<root />";

				objValueArr[3] = new clsDSTRichTextBoxValue();
				objValueArr[3].m_strText=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContentArr[i1].m_strInOralQuantity,objContentArr[i1].m_strInOralQuantityXML);						
				objValueArr[3].m_strDSTXml="<root />";

				dtrNew.ItemArray = objValueArr;
				m_dtbInOral.Rows.Add(dtrNew);
			}
			m_dtgInOral.Tag = objContentArr;

		}

		private void m_mthSetInLiquidInfo(string p_strDrugNameAll,string p_strDrugNameXMLAll,string p_strDrugDosageAll,string p_strDrugDosageXMLAll)
		{
			System.Xml.XmlDocument doc1 = new System.Xml.XmlDocument();
			doc1.LoadXml(p_strDrugNameAll);
			System.Xml.XmlNode root1  = doc1.FirstChild;
			doc1.LoadXml(p_strDrugNameXMLAll);
			System.Xml.XmlNode root2  = doc1.FirstChild;
			doc1.LoadXml(p_strDrugDosageAll);
			System.Xml.XmlNode root3  = doc1.FirstChild;
			doc1.LoadXml(p_strDrugDosageXMLAll);
			System.Xml.XmlNode root4  = doc1.FirstChild;
			
			m_dtbInLiquid.Rows.Clear();
			m_dtgInLiquid.CurrentRowIndex = 0;

			int intInLiquidLength = root1.ChildNodes.Count;
			if(intInLiquidLength <= 0)
				return;
			DataRow dtrNew;
			clsDSTRichTextBoxValue [] objValueArr = null;
			clsICUIntensiveTendInLiquidContent[] objContentArr = new clsICUIntensiveTendInLiquidContent[intInLiquidLength];
			for(int i1=0;i1<intInLiquidLength;i1++)
			{
				objValueArr =new clsDSTRichTextBoxValue[2];
				objContentArr[i1] = new clsICUIntensiveTendInLiquidContent();
				objContentArr[i1].m_strDrugName = root1.ChildNodes[i1].InnerText;
				objContentArr[i1].m_strDrugNameXML = root2.ChildNodes[i1].InnerXml;
				objContentArr[i1].m_strDrugDosage = root3.ChildNodes[i1].InnerText;
				objContentArr[i1].m_strDrugDosageXML = root4.ChildNodes[i1].InnerXml;

				dtrNew = m_dtbInLiquid.NewRow();
				objValueArr[0] = new clsDSTRichTextBoxValue();
				objValueArr[0].m_strText=objContentArr[i1].m_strDrugName;						
				objValueArr[0].m_strDSTXml=objContentArr[i1].m_strDrugNameXML;

				objValueArr[1] = new clsDSTRichTextBoxValue();
				objValueArr[1].m_strText=objContentArr[i1].m_strDrugDosage;						
				objValueArr[1].m_strDSTXml=objContentArr[i1].m_strDrugDosageXML;

				dtrNew.ItemArray = objValueArr;
				m_dtbInLiquid.Rows.Add(dtrNew);
			}
			m_dtgInLiquid.Tag = objContentArr;	
		}

		private void m_mthSetRightInLiquidInfo(string p_strDrugNameAll,string p_strDrugNameXMLAll,string p_strDrugDosageAll,string p_strDrugDosageXMLAll)
		{
			System.Xml.XmlDocument doc1 = new System.Xml.XmlDocument();
			doc1.LoadXml(p_strDrugNameAll);
			System.Xml.XmlNode root1  = doc1.FirstChild;
			doc1.LoadXml(p_strDrugNameXMLAll);
			System.Xml.XmlNode root2  = doc1.FirstChild;
			doc1.LoadXml(p_strDrugDosageAll);
			System.Xml.XmlNode root3  = doc1.FirstChild;
			doc1.LoadXml(p_strDrugDosageXMLAll);
			System.Xml.XmlNode root4  = doc1.FirstChild;
			
			m_dtbInLiquid.Rows.Clear();
			m_dtgInLiquid.CurrentRowIndex = 0;

			int intInLiquidLength = root1.ChildNodes.Count;
			if(intInLiquidLength <= 0)
				return;
			DataRow dtrNew;
			clsDSTRichTextBoxValue [] objValueArr = null;
			clsICUIntensiveTendInLiquidContent[] objContentArr = new clsICUIntensiveTendInLiquidContent[intInLiquidLength];
			for(int i1=0;i1<intInLiquidLength;i1++)
			{
				objValueArr =new clsDSTRichTextBoxValue[2];
				objContentArr[i1] = new clsICUIntensiveTendInLiquidContent();
				objContentArr[i1].m_strDrugName = root1.ChildNodes[i1].InnerText;
				objContentArr[i1].m_strDrugNameXML = root2.ChildNodes[i1].InnerXml;
				objContentArr[i1].m_strDrugDosage = root3.ChildNodes[i1].InnerText;
				objContentArr[i1].m_strDrugDosageXML = root4.ChildNodes[i1].InnerXml;

				dtrNew = m_dtbInLiquid.NewRow();
				objValueArr[0] = new clsDSTRichTextBoxValue();
				objValueArr[0].m_strText=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContentArr[i1].m_strDrugName,objContentArr[i1].m_strDrugNameXML);						
				objValueArr[0].m_strDSTXml="<root />";

				objValueArr[1] = new clsDSTRichTextBoxValue();
				objValueArr[1].m_strText=com.digitalwave.Utility.Controls.ctlRichTextBox.s_strGetRightText(objContentArr[i1].m_strDrugDosage,objContentArr[i1].m_strDrugDosageXML);						
				objValueArr[1].m_strDSTXml="<root />";

				dtrNew.ItemArray = objValueArr;
				m_dtbInLiquid.Rows.Add(dtrNew);
			}
			m_dtgInLiquid.Tag = objContentArr;	
		}


		/// <summary>
		/// 设置DataGrid内的控件触发的事件和右键菜单
		/// </summary>
		/// <param name="p_objControl"></param>
		protected void m_mthSetControlOral(cltDataGridDSTRichTextBox p_objControl)
		{
			p_objControl.m_RtbBase.ContextMenu = ctmInOral;
//			p_objControl.m_RtbBase.MouseDown += new MouseEventHandler(cltDataGridDSTRichTextBoxOral_MouseDown);
		}

		/// <summary>
		/// 设置DataGrid内的控件触发的事件和右键菜单
		/// </summary>
		/// <param name="p_objControl"></param>
		protected void m_mthSetControlLiquid(cltDataGridDSTRichTextBox p_objControl)
		{
			p_objControl.m_RtbBase.ContextMenu = ctmInLiquid;
//			p_objControl.m_RtbBase.MouseDown += new MouseEventHandler(cltDataGridDSTRichTextBoxLiquid_MouseDown);
		}

		/// <summary>
		/// 双击DataGrid内的控件触发的事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cltDataGridDSTRichTextBoxOral_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(!m_blnCheckOralDataGridCurrentRow())
				return;
			int intSelectedRecordStartRow = m_dtgInOral.CurrentCell.RowNumber;
			if(intSelectedRecordStartRow < 0)
				return;
			m_gpbInOral.Tag = intSelectedRecordStartRow.ToString();
			clsDSTRichTextBoxValue objValue = (clsDSTRichTextBoxValue)m_dtbInOral.Rows[intSelectedRecordStartRow][0];
			m_txtInOralType.m_mthSetNewText(objValue.m_strText,objValue.m_strDSTXml);

			clsDSTRichTextBoxValue objValue1 = (clsDSTRichTextBoxValue)m_dtbInOral.Rows[intSelectedRecordStartRow][1];
			m_txtInOral.m_mthSetNewText(objValue1.m_strText,objValue1.m_strDSTXml);

			clsDSTRichTextBoxValue objValue2 = (clsDSTRichTextBoxValue)m_dtbInOral.Rows[intSelectedRecordStartRow][2];
			m_txtInOralProperty.m_mthSetNewText(objValue2.m_strText,objValue2.m_strDSTXml);

			clsDSTRichTextBoxValue objValue3 = (clsDSTRichTextBoxValue)m_dtbInOral.Rows[intSelectedRecordStartRow][3];
			m_txtInOralQuantity.m_mthSetNewText(objValue3.m_strText,objValue3.m_strDSTXml);
		}

		/// <summary>
		/// 双击DataGrid内的控件触发的事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cltDataGridDSTRichTextBoxLiquid_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(!m_blnCheckLiquidDataGridCurrentRow())
				return;
			int intSelectedRecordStartRow = m_dtgInLiquid.CurrentCell.RowNumber;
			if(intSelectedRecordStartRow < 0)
				return;

			m_gpbInLiquid.Tag = intSelectedRecordStartRow.ToString();
			clsDSTRichTextBoxValue objValue = (clsDSTRichTextBoxValue)m_dtbInLiquid.Rows[intSelectedRecordStartRow][0];
			m_txtDrugName.m_mthSetNewText(objValue.m_strText,objValue.m_strDSTXml);

			clsDSTRichTextBoxValue objValue1 = (clsDSTRichTextBoxValue)m_dtbInLiquid.Rows[intSelectedRecordStartRow][1];
			m_txtDrugDosage.m_mthSetNewText(objValue1.m_strText,objValue1.m_strDSTXml);
		}
		/// <summary>
		/// 处理之前判断DataGrid与DataTable的关系
		/// </summary>
		/// <returns></returns>
		private bool m_blnCheckOralDataGridCurrentRow()
		{
			if(m_dtbInOral.Rows.Count <=0)
				return false;
			if(m_dtgInOral.CurrentCell.RowNumber  >= m_dtbInOral.Rows.Count)
			{
				m_gpbInOral.Tag = null;
				m_txtInOral.m_mthClearText();
				return false;
			}
			return true;
		}
		
		/// <summary>
		/// 处理之前判断DataGrid与DataTable的关系
		/// </summary>
		/// <returns></returns>
		private bool m_blnCheckLiquidDataGridCurrentRow()
		{
			if(m_dtbInLiquid.Rows.Count <=0)
				return false;
			if(m_dtgInLiquid.CurrentCell.RowNumber  >= m_dtbInLiquid.Rows.Count)
			{
				m_gpbInLiquid.Tag = null;
				m_txtDrugName.m_mthClearText();
				m_txtDrugDosage.m_mthClearText();
				return false;
			}
			return true;
		}

		private clsICUIntensiveTendInOralContent[] m_objGetInOralArr()
		{
			int m_intInOralRows = m_dtbInOral.Rows.Count;
			if(m_intInOralRows <=0)
				return null;
			
			clsICUIntensiveTendInOralContent[] objContentArr = new clsICUIntensiveTendInOralContent[m_intInOralRows];
			clsDSTRichTextBoxValue objValue = null;
			for(int i1=0;i1<m_intInOralRows;i1++)
			{
				objContentArr[i1] = new clsICUIntensiveTendInOralContent();

				objValue = (clsDSTRichTextBoxValue)m_dtbInOral.Rows[i1][0];
				m_txtTemp.m_mthSetNewText(objValue.m_strText,objValue.m_strDSTXml);
				objContentArr[i1].m_strInOralType = m_txtTemp.Text;
				objContentArr[i1].m_strInOralType_Last = m_txtTemp.m_strGetRightText();
				objContentArr[i1].m_strInOralTypeXML = m_txtTemp.m_strGetXmlText();

				objValue = (clsDSTRichTextBoxValue)m_dtbInOral.Rows[i1][1];
				m_txtTemp.m_mthSetNewText(objValue.m_strText,objValue.m_strDSTXml);
				objContentArr[i1].m_strInOral = m_txtTemp.Text;
				objContentArr[i1].m_strInOral_Last = m_txtTemp.m_strGetRightText();
				objContentArr[i1].m_strInOralXML = m_txtTemp.m_strGetXmlText();
		
				objValue = (clsDSTRichTextBoxValue)m_dtbInOral.Rows[i1][2];
				m_txtTemp.m_mthSetNewText(objValue.m_strText,objValue.m_strDSTXml);
				objContentArr[i1].m_strInOralProperty = m_txtTemp.Text;
				objContentArr[i1].m_strInOralProperty_Last = m_txtTemp.m_strGetRightText();
				objContentArr[i1].m_strInOralPropertyXML = m_txtTemp.m_strGetXmlText();

				objValue = (clsDSTRichTextBoxValue)m_dtbInOral.Rows[i1][3];
				m_txtTemp.m_mthSetNewText(objValue.m_strText,objValue.m_strDSTXml);
				objContentArr[i1].m_strInOralQuantity = m_txtTemp.Text;
				objContentArr[i1].m_strInOralQuantity_Last = m_txtTemp.m_strGetRightText();
				objContentArr[i1].m_strInOralQuantityXML = m_txtTemp.m_strGetXmlText();

			}
			return objContentArr;
		}

		private clsICUIntensiveTendInLiquidContent[] m_objGetInLiquidArr()
		{
			int m_intInLiquidRows = m_dtbInLiquid.Rows.Count;
			if(m_intInLiquidRows <=0)
				return null;
			
			clsICUIntensiveTendInLiquidContent[] objContentArr = new clsICUIntensiveTendInLiquidContent[m_intInLiquidRows];
			clsDSTRichTextBoxValue objValue = null;
			for(int i1=0;i1<m_intInLiquidRows;i1++)
			{
				objContentArr[i1] = new clsICUIntensiveTendInLiquidContent();

				objValue = (clsDSTRichTextBoxValue)m_dtbInLiquid.Rows[i1][0];
				m_txtTemp.m_mthSetNewText(objValue.m_strText,objValue.m_strDSTXml);
				objContentArr[i1].m_strDrugName = m_txtTemp.Text;
				objContentArr[i1].m_strDrugName_Last = m_txtTemp.m_strGetRightText();
				objContentArr[i1].m_strDrugNameXML = m_txtTemp.m_strGetXmlText();

				objValue = (clsDSTRichTextBoxValue)m_dtbInLiquid.Rows[i1][1];
				m_txtTemp.m_mthSetNewText(objValue.m_strText,objValue.m_strDSTXml);
				objContentArr[i1].m_strDrugDosage = m_txtTemp.Text;
				objContentArr[i1].m_strDrugDosage_Last = m_txtTemp.m_strGetRightText();
				objContentArr[i1].m_strDrugDosageXML = m_txtTemp.m_strGetXmlText();

			}
			return objContentArr;
		}

		private void m_mthGetInOralXML(out string p_strInOralTypeAll,out string p_strInOralTypeXMLAll,out string p_strInOralAll,out string p_strInOralXMLAll,out string p_strInOralPropertyAll,out string p_strInOralPropertyXMLAll,out string p_strInOralQuantityAll,out string p_strInOralQuantityXMLAll)
		{
			p_strInOralTypeAll = "<InOralType></InOralType>";
			p_strInOralTypeXMLAll = "<InOralTypeXML></InOralTypeXML>";

			p_strInOralAll = "<InOral></InOral>";
			p_strInOralXMLAll = "<InOralXML></InOralXML>";

			p_strInOralPropertyAll = "<InOralProperty></InOralProperty>";
			p_strInOralPropertyXMLAll = "<InOralPropertyXML></InOralPropertyXML>";

			p_strInOralQuantityAll = "<InOralQuantity></InOralQuantity>";
			p_strInOralQuantityXMLAll = "<InOralQuantityXML></InOralQuantityXML>";
			
			clsICUIntensiveTendInOralContent[] objContentArr = m_objGetInOralArr();
			if(objContentArr == null || objContentArr.Length <=0)
				return;

			m_dtgInOral.Tag = objContentArr;
			string strInOralType = "";
			string strInOralTypeXML = "";

			string strInOral = "";
			string strInOralXML = "";

			string strInOralProperty = "";
			string strInOralPropertyXML = "";

			string strInOralQuantity = "";
			string strInOralQuantityXML = "";
			
			for(int i1=0;i1<objContentArr.Length;i1++)
			{
				strInOralType += "<row>"+objContentArr[i1].m_strInOralType+"</row>";
				strInOralTypeXML += "<row>"+objContentArr[i1].m_strInOralTypeXML+"</row>";

				strInOral += "<row>"+objContentArr[i1].m_strInOral+"</row>";
				strInOralXML += "<row>"+objContentArr[i1].m_strInOralXML+"</row>";

				strInOralProperty += "<row>"+objContentArr[i1].m_strInOralProperty+"</row>";
				strInOralPropertyXML += "<row>"+objContentArr[i1].m_strInOralPropertyXML+"</row>";

				strInOralQuantity += "<row>"+objContentArr[i1].m_strInOralQuantity+"</row>";
				strInOralQuantityXML += "<row>"+objContentArr[i1].m_strInOralQuantityXML+"</row>";
			}

			p_strInOralTypeAll = "<InOralType>"+strInOralType+"</InOralType>";
			p_strInOralTypeXMLAll = "<InOralTypeXML>"+strInOralTypeXML+"</InOralTypeXML>";

			p_strInOralAll = "<InOral>"+strInOral+"</InOral>";
			p_strInOralXMLAll = "<InOralXML>"+strInOralXML+"</InOralXML>";

			p_strInOralPropertyAll = "<InOralProperty>"+strInOralProperty+"</InOralProperty>";
			p_strInOralPropertyXMLAll = "<InOralPropertyXML>"+strInOralPropertyXML+"</InOralPropertyXML>";

			p_strInOralQuantityAll = "<InOralQuantity>"+strInOralQuantity+"</InOralQuantity>";
			p_strInOralQuantityXMLAll = "<InOralQuantityXML>"+strInOralQuantityXML+"</InOralQuantityXML>";

		}

		private void m_mthGetInLiquidXML(out string p_strDrugNameAll,out string p_strDrugNameXMLAll,out string p_strDrugDosageAll,out string p_strDrugDosageXMLAll)
		{
			p_strDrugNameAll = "<DrugName></DrugName>";
			p_strDrugNameXMLAll = "<DrugNameXML></DrugNameXML>";
			
			p_strDrugDosageAll = "<DrugDosage></DrugDosage>";
			p_strDrugDosageXMLAll = "<DrugDosageXML></DrugDosageXML>";

			
			clsICUIntensiveTendInLiquidContent[] objContentArr = m_objGetInLiquidArr();
			if(objContentArr == null || objContentArr.Length <=0)
				return;

			m_dtgInLiquid.Tag = objContentArr;
			string strTempName = "";
			string strTempNameXML = "";
			string strTempDosage = "";
			string strTempDosageXML = "";
			
			for(int i1=0;i1<objContentArr.Length;i1++)
			{
				strTempName += "<row>"+objContentArr[i1].m_strDrugName+"</row>";
				strTempNameXML += "<row>"+objContentArr[i1].m_strDrugNameXML+"</row>";
				strTempDosage += "<row>"+objContentArr[i1].m_strDrugDosage+"</row>";
				strTempDosageXML += "<row>"+objContentArr[i1].m_strDrugDosageXML+"</row>";
			}

			p_strDrugNameAll = "<DrugName>"+strTempName+"</DrugName>";
			p_strDrugNameXMLAll = "<DrugNameXML>"+strTempNameXML+"</DrugNameXML>";
			
			p_strDrugDosageAll = "<DrugDosage>"+strTempDosage+"</DrugDosage>";
			p_strDrugDosageXMLAll = "<DrugDosageXML>"+strTempDosageXML+"</DrugDosageXML>";

		}

		private void mniRemove_Click(object sender, System.EventArgs e)
		{
			if(!m_blnCheckOralDataGridCurrentRow())
				return;
			int intSelectedRecordStartRow = m_dtgInOral.CurrentCell.RowNumber;
			if(intSelectedRecordStartRow < 0)
				return;
			m_dtgInOral.CurrentCell = new DataGridCell(m_dtbInOral.Rows.Count,0);
			m_dtbInOral.Rows.RemoveAt(intSelectedRecordStartRow);
			m_gpbInOral.Tag = null;
			m_txtInOral.m_mthClearText();
		}

		private void mniRemoveLiquid_Click(object sender, System.EventArgs e)
		{
			if(!m_blnCheckLiquidDataGridCurrentRow())
				return;
			int intSelectedRecordStartRow = m_dtgInLiquid.CurrentCell.RowNumber;
			if(intSelectedRecordStartRow < 0)
				return;
			m_dtgInLiquid.CurrentCell = new DataGridCell(m_dtbInLiquid.Rows.Count,0);
			m_dtbInLiquid.Rows.RemoveAt(intSelectedRecordStartRow);
			m_gpbInLiquid.Tag = null;
			m_txtDrugName.m_mthClearText();
			m_txtDrugDosage.m_mthClearText();
		}

		private void cmdConfirm_Click(object sender, System.EventArgs e)
		{
			if(!m_bolSubSaveCheck())
				return;
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

		private bool m_bolSubSaveCheck()
		{
			string strTemp = "";
			try
			{
				strTemp = m_txtT.m_strGetRightText();
				if(strTemp != "")
				{
					float.Parse(strTemp);
				}
			}
			catch
			{
				clsPublicFunction.ShowInformationMessageBox("温度应该为数字！");
				m_txtT.Focus();
				return false;
			}

			try
			{
				strTemp = m_txtTransfusion.m_strGetRightText();
				if(strTemp != "")
				{
					float.Parse(strTemp);
				}
			}
			catch
			{
				clsPublicFunction.ShowInformationMessageBox("输液总量应该为数字！");
				m_txtTransfusion.Focus();
				return false;
			}


			try
			{
				strTemp = m_txtTakeFood.m_strGetRightText();
				if(strTemp != "")
				{
					float.Parse(strTemp);
				}
			}
			catch
			{
				clsPublicFunction.ShowInformationMessageBox("进食总量应该为数字！");
				m_txtTakeFood.Focus();
				return false;
			}


			try
			{
				strTemp = m_txtStomachQuantity.m_strGetRightText();
				if(strTemp != "")
				{
					float.Parse(strTemp);
				}
			}
			catch
			{
				clsPublicFunction.ShowInformationMessageBox("胃管量应该为数字！");
				m_txtStomachQuantity.Focus();
				return false;
			}
			try
			{
				strTemp = m_txtPeeQuantity.m_strGetRightText();
				if(strTemp != "")
				{
					float.Parse(strTemp);
				}
			}
			catch
			{
				clsPublicFunction.ShowInformationMessageBox("尿管量应该为数字！");
				m_txtPeeQuantity.Focus();
				return false;
			}
			try
			{
				strTemp = m_txtDefecateQuantity.m_strGetRightText();
				if(strTemp != "")
				{
					float.Parse(strTemp);
				}
			}
			catch
			{
				clsPublicFunction.ShowInformationMessageBox("大便量应该为数字！");
				m_txtDefecateQuantity.Focus();
				return false;
			}
			try
			{
				strTemp = m_txtLeadQuantity.m_strGetRightText();
				if(strTemp != "")
				{
					float.Parse(strTemp);
				}
			}
			catch
			{
				clsPublicFunction.ShowInformationMessageBox("引流管应该为数字！");
				m_txtLeadQuantity.Focus();
				return false;
			}		
			try
			{
				strTemp = m_txtSputumQuantity.m_strGetRightText();
				if(strTemp != "")
				{
					float.Parse(strTemp);
				}
			}
			catch
			{
				clsPublicFunction.ShowInformationMessageBox("痰量应该为数字！");
				m_txtSputumQuantity.Focus();
				return false;
			}	
			return true;
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
				string[] strTypeArry=new string[]{"PULSERATE","HEARTRATE","TEMP1","NPBSYSTOLIC","NPB_DIASTOLIC","RESPDETECTNUM"};//

				m_mthGetICUDataByTime(m_dtpGetDataTime.Value.ToString(),out objCMSData,out objVentilatorData,strTypeArry);

				if (!blnIsGE)
				{
					if (objCMSData != null)
					{
						//脉搏
						if(objCMSData.m_strPulseRate == null || objCMSData.m_strPulseRate.Trim().Length == 0)
							m_txtP.Text = "";
						else
							m_txtP.Text = objCMSData.m_strPulseRate.Trim().Substring(0,objCMSData.m_strPulseRate.Trim().Length-3);
						
						//心率
						if(objCMSData.m_strHeartRate == null || objCMSData.m_strHeartRate.Trim().Length == 0)
							m_txtHR.Text = "";
						else
							m_txtHR.Text = objCMSData.m_strHeartRate.Trim().Substring(0,objCMSData.m_strHeartRate.Trim().Length-3);

						//体温
						if(objCMSData.m_strTemp1 == null || objCMSData.m_strTemp1.Trim().Length == 0)
							m_txtT.Text="";
						else
							m_txtT.Text=objCMSData.m_strTemp1.Trim();

						//收缩压
						if(objCMSData.m_strNPBSYSTOLIC == null || objCMSData.m_strNPBSYSTOLIC.Trim().Length == 0)
							m_txtBp.Text="";
						else
							m_txtBp.Text=objCMSData.m_strNPBSYSTOLIC;

						//舒张压
						if(objCMSData.m_strNPBDIASTOLIC == null || objCMSData.m_strNPBDIASTOLIC.Trim().Length == 0)
							m_txtBp2.Text="";
						else
							m_txtBp2.Text=objCMSData.m_strNPBDIASTOLIC;
						
						//呼吸
						if(objCMSData.m_strRespDetectNum == null || objCMSData.m_strRespDetectNum.Trim().Length == 0)
							m_txtR.Text="";
						else
							m_txtR.Text=objCMSData.m_strRespDetectNum.Trim().Substring(0,objCMSData.m_strRespDetectNum.Trim().Length-3);

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
							m_txtP.Text = "";
						else
							m_txtP.Text = objGECMSData.m_strPluse;
						
						//心率
						if(objGECMSData.m_strHR  == null || objGECMSData.m_strHR.Trim().Length == 0)
							m_txtHR.Text = "";
						else
							m_txtHR.Text = objGECMSData.m_strHR;

						//体温
						if(objGECMSData.m_strTEMP1 == null || objGECMSData.m_strTEMP1.Trim().Length == 0)
							m_txtT.Text="";
						else
							m_txtT.Text=objGECMSData.m_strTEMP1;

						//收缩压
						if(objGECMSData.m_strNBPSystolic == null || objGECMSData.m_strNBPSystolic.Trim().Length == 0)
							m_txtBp.Text="";
						else
							m_txtBp.Text=objGECMSData.m_strNBPSystolic;

						//舒张压
						if(objGECMSData.m_strNBPDiastolic == null || objGECMSData.m_strNBPDiastolic.Trim().Length == 0)
							m_txtBp2.Text="";
						else
							m_txtBp2.Text=objGECMSData.m_strNBPDiastolic;
						
						//呼吸
						if(objGECMSData.m_strRR == null || objGECMSData.m_strRR.Trim().Length == 0)
							m_txtR.Text="";
						else
							m_txtR.Text=objGECMSData.m_strRR;
					}
				}
			}
			catch
			{
			}
		}

		private void m_cmdGetDovueData_Click(object sender, System.EventArgs e)
		{//T,P,R,Bp,CVP
			if(m_objBaseCurrentPatient==null)return;

			GetData();

			#region Old
//			clsTrendDomain objDomain=new clsTrendDomain();
//			string[] strEMFC_IDArr=new string[]{"100","40","44","65","66","89","90"};//体温，心率，脉搏，ABP S,ABP D,NBP S,NBP D
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
//				if(strResultArr[0] != null)
//				{
//					this.m_txtT.Text=strResultArr[0];
//				}
//				if(strResultArr[1] != null)
//				{
//					this.m_txtHR.Text=strResultArr[1];
//				}
//				if(strResultArr[2] != null)
//				{
//					this.m_txtP.Text=strResultArr[2];
//				}
//				if(strResultArr[3] != null)
//				{
//					this.m_txtBp.Text=strResultArr[3];
//				}
//				else if(strResultArr[5] != null)
//				{
//					this.m_txtBp.Text=strResultArr[5];
//				}
//				if(strResultArr[4] != null)
//				{
//					this.m_txtBp2.Text=strResultArr[4];
//				}
//				else if(strResultArr[6] != null)
//				{
//					this.m_txtBp2.Text=strResultArr[6];
//				}
//			}
			#endregion Old
		}

		private void groupBox3_Enter(object sender, System.EventArgs e)
		{
		
		}

		private int m_intInsertIndex = -1;
		private void mniInsert_Click(object sender, System.EventArgs e)
		{
			m_intInsertIndex = m_dtgInLiquid.CurrentCell.RowNumber;
			m_txtDrugName.Focus();
		}

		private void mniEdit_Click(object sender, System.EventArgs e)
		{
			if(!m_blnCheckLiquidDataGridCurrentRow())
				return;
			int intSelectedRecordStartRow = m_dtgInLiquid.CurrentCell.RowNumber;
			if(intSelectedRecordStartRow < 0)
				return;

			m_gpbInLiquid.Tag = intSelectedRecordStartRow.ToString();
			clsDSTRichTextBoxValue objValue = (clsDSTRichTextBoxValue)m_dtbInLiquid.Rows[intSelectedRecordStartRow][0];
			m_txtDrugName.m_mthSetNewText(objValue.m_strText,objValue.m_strDSTXml);

			clsDSTRichTextBoxValue objValue1 = (clsDSTRichTextBoxValue)m_dtbInLiquid.Rows[intSelectedRecordStartRow][1];
			m_txtDrugDosage.m_mthSetNewText(objValue1.m_strText,objValue1.m_strDSTXml);

			m_intInsertIndex = m_dtgInLiquid.CurrentCell.RowNumber;
			m_txtDrugName.Focus();
		}

		private int m_intInsertInOralIndex = -1;
		private void mniInsertInoral_Click(object sender, System.EventArgs e)
		{
			m_intInsertInOralIndex = m_dtgInOral.CurrentCell.RowNumber;
			m_txtInOralType.Focus();
		}

		private void mniEditInOral_Click(object sender, System.EventArgs e)
		{
			if(!m_blnCheckOralDataGridCurrentRow())
				return;
			int intSelectedRecordStartRow = m_dtgInOral.CurrentCell.RowNumber;
			if(intSelectedRecordStartRow < 0)
				return;
			m_gpbInOral.Tag = intSelectedRecordStartRow.ToString();
			clsDSTRichTextBoxValue objValue = (clsDSTRichTextBoxValue)m_dtbInOral.Rows[intSelectedRecordStartRow][0];
			m_txtInOralType.m_mthSetNewText(objValue.m_strText,objValue.m_strDSTXml);

			clsDSTRichTextBoxValue objValue1 = (clsDSTRichTextBoxValue)m_dtbInOral.Rows[intSelectedRecordStartRow][1];
			m_txtInOral.m_mthSetNewText(objValue1.m_strText,objValue1.m_strDSTXml);

			clsDSTRichTextBoxValue objValue2 = (clsDSTRichTextBoxValue)m_dtbInOral.Rows[intSelectedRecordStartRow][2];
			m_txtInOralProperty.m_mthSetNewText(objValue2.m_strText,objValue2.m_strDSTXml);

			clsDSTRichTextBoxValue objValue3 = (clsDSTRichTextBoxValue)m_dtbInOral.Rows[intSelectedRecordStartRow][3];
			m_txtInOralQuantity.m_mthSetNewText(objValue3.m_strText,objValue3.m_strDSTXml);

			m_intInsertInOralIndex = m_dtgInOral.CurrentCell.RowNumber;
			m_txtInOralType.Focus();
		}

		#region 获得GE监护仪数据 Alex 2003-9-15
		private void m_cmdGetGEData_Click(object sender, System.EventArgs e)
		{
//			if(m_objBaseCurrentPatient==null)return;
//
//			this.m_txtHR.Text=MDIParent.m_objGEMonitor.m_lngGetBodyParameter(enmMonitorParameter.HR).ToString();
//			this.m_txtP.Text=MDIParent.m_objGEMonitor.m_lngGetBodyParameter(enmMonitorParameter.PPR).ToString();
//			this.m_txtBp.Text=MDIParent.m_objGEMonitor.m_lngGetBodyParameter(enmMonitorParameter.SYSTOLIC).ToString();
//			this.m_txtBp2.Text=MDIParent.m_objGEMonitor.m_lngGetBodyParameter(enmMonitorParameter.DIASTOLIC).ToString();
		}
		#endregion

		private Button[] m_cmdCommonUseArr()
		{
			return new Button[]{m_cmdBreathLeft,m_cmdBreathRight,m_cmdDefecateProperty,m_cmdDirect1,m_cmdDirect2,m_cmdDirect3,
			m_cmdDrugName,m_cmdInOral,m_cmdInOralProperty,m_cmdInOralType,m_cmdLeadPipe,m_cmdLeadProperty,m_cmdPeeProperty,
			m_cmdPower,m_cmdReflectLeft,m_cmdReflectRight,m_cmdSence,m_cmdSkin,m_cmdSputumProperty,m_cmdStomachPipe,m_cmdStomachProperty};
		}

		private com.digitalwave.controls.ctlRichTextBox[] m_txtCommonUseArr()
		{
			return new com.digitalwave.controls.ctlRichTextBox[]{m_txtBreathSoundLeft,m_txtBreathSoundRight,m_txtDefecateProperty,m_txtDirect1,m_txtDirect2,m_txtDirect3,
			m_txtDrugName,m_txtInOral,m_txtInOralProperty,m_txtInOralType,m_txtLeadPipe,m_txtLeadProperty,m_txtPeeProperty,
			m_txtPower,m_txtReflectLeft,m_txtReflectRight,m_txtConsciousness,m_txtSkin,m_txtSputumProperty,m_txtStomachPipe,m_txtStomachProperty};
		}

		private enmCommonUseValue[] m_enmCommonUseArr()
		{
			return new enmCommonUseValue[]{enmCommonUseValue.BreathSound,enmCommonUseValue.BreathSound,enmCommonUseValue.DefecateProperty,
			enmCommonUseValue.Direction,enmCommonUseValue.Direction,enmCommonUseValue.Direction,
			enmCommonUseValue.DrugName,enmCommonUseValue.InOral,enmCommonUseValue.InOralProperty,enmCommonUseValue.InOralType,
			enmCommonUseValue.LeadPipe,enmCommonUseValue.LeadProperty,enmCommonUseValue.PeeProperty,
			enmCommonUseValue.Power,enmCommonUseValue.ReflectLeft,enmCommonUseValue.ReflectRight,enmCommonUseValue.Consciousness,
			enmCommonUseValue.Skin,enmCommonUseValue.SputumProperty,enmCommonUseValue.StomachPipe,enmCommonUseValue.StomachProperty};
		}

		private void frmSubICUIntensiveTend_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			m_objICUGESimulateGetData.m_mthStopReceiveData();
		}
		#region Jump Control
		protected override void m_mthInitJump(clsJumpControl p_objJump)
		{
			p_objJump=new clsJumpControl(this,
				new Control[]{m_txtT,m_txtHR,m_txtP,m_txtR,m_txtBp,m_txtBp2,m_txtCVP,m_txtBloodSugar,m_txtConsciousness,m_txtPupilSizeLeft,m_txtPupilSizeRight,m_txtReflectLeft
							 ,m_txtReflectRight,m_txtPower,m_txtDrugName,m_txtDrugDosage,cmdDrugSubmit,m_txtTransfusion,m_txtTakeFood,m_txtStomachPipe,m_txtDirect1,m_txtStomachProperty
							 ,m_txtStomachQuantity,m_txtInOralType,m_txtInOral,m_txtInOralProperty,m_txtInOralQuantity,m_cmdInOralSubmit,m_txtDirect2,m_txtPeeProperty,m_txtPeeQuantity
							 ,m_txtDefecateProperty,m_txtDefecateTimes,m_txtDefecateQuantity,m_txtLeadPipe,m_txtDirect3,m_txtLeadProperty,m_txtLeadQuantity,m_txtSputumProperty
							 ,m_txtSputumQuantity,m_txtSkin,m_txtCaseHistory},Keys.Enter);
		}
		#endregion

        protected override void m_mthSetSign(string p_strUserID)
        {
            return;
        }
	}
}

