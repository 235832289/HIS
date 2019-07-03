using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.controls;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmRegister 的摘要说明。
	/// </summary>
	public class frmReturnReg :com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		#region 定义
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Panel panel2;
		internal System.Windows.Forms.ListView m_lvItem;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label3;
		internal System.Windows.Forms.CheckBox m_chkPre;
		internal System.Windows.Forms.DateTimePicker m_dtpPreTime;
		internal System.Windows.Forms.ComboBox m_cboSeg;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtPatType;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtCard;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtDept;
		internal System.Windows.Forms.Label m_lbStart;
		internal System.Windows.Forms.Label m_lbEnd;
		internal System.Windows.Forms.Label m_lbRoom;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtName;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtDoc;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtRegType;
		internal System.Windows.Forms.DateTimePicker m_dtpBirth;
		internal System.Windows.Forms.ComboBox m_cboSex;
		internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric m_txtDiagFee;
		internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric m_txtRegFee;
		internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric m_txtAmount;
		internal System.Windows.Forms.ErrorProvider errorProvider1;
		internal PinkieControls.ButtonXP m_btnSave;
		private PinkieControls.ButtonXP m_btnExit;
		private PinkieControls.ButtonXP m_btnClear;
		private System.Windows.Forms.Label m_lbPre;
		private System.Windows.Forms.Panel panel3;
		internal System.Windows.Forms.StatusBar m_stb;
		internal System.Windows.Forms.ComboBox m_cobSetPrint;
		internal System.Windows.Forms.ListView m_lsvRegDetail;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label10;
		#endregion

		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.ColumnHeader columnHeader12;
		internal System.Windows.Forms.CheckBox m_chkNeedNotCard;
		internal System.Windows.Forms.CheckBox m_chkNeedNotfalill;
		internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric m_txtChangeCharge;
		internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric m_txtChangeDisCount;
		internal PinkieControls.ButtonXP buttonXP1;
		internal ctlDataGridView m_dtgRegister;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label13;
		internal System.Windows.Forms.DateTimePicker m_datFirstdate;
		internal System.Windows.Forms.DateTimePicker m_datLastdate;
		internal PinkieControls.ButtonXP m_btnQulReg;
		private System.Windows.Forms.Label label19;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtRegisterNo;
		internal PinkieControls.ButtonXP m_b;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader13;
		internal System.Windows.Forms.Panel m_pnlAllPlan;
		internal System.Windows.Forms.ListView m_lsvAllplan;

		internal com.digitalwave.controls.OmnipotenceQul m_OmnipotenceQul;
		internal System.Windows.Forms.ComboBox m_cmbQulType;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.RadioButton m_radCardID;
		private System.Windows.Forms.RadioButton m_radRegNo;
		private System.Windows.Forms.RadioButton m_radPatName;
        private IContainer components;
        //		private bool NoChange=false;

		public frmReturnReg()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			
			//	this.m_OmnipotenceQul.TabIndex = 38;
			InitializeComponent();
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		public frmReturnReg(com.digitalwave.iCare.ValueObject.clsLoginInfo loginInfo)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			
			//	this.m_OmnipotenceQul.TabIndex = 38;
			InitializeComponent();
			m_radCardID.Checked = true;
			this.LoginInfo = loginInfo;
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReturnReg));
            this.m_OmnipotenceQul = new com.digitalwave.controls.OmnipotenceQul();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_cmbQulType = new System.Windows.Forms.ComboBox();
            this.m_pnlAllPlan = new System.Windows.Forms.Panel();
            this.m_lsvAllplan = new System.Windows.Forms.ListView();
            this.m_btnQulReg = new PinkieControls.ButtonXP();
            this.m_datLastdate = new System.Windows.Forms.DateTimePicker();
            this.m_datFirstdate = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_lvItem = new System.Windows.Forms.ListView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_chkNeedNotCard = new System.Windows.Forms.CheckBox();
            this.m_chkNeedNotfalill = new System.Windows.Forms.CheckBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.m_txtAmount = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
            this.m_txtDiagFee = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.m_txtChangeCharge = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
            this.m_txtChangeDisCount = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_cboSeg = new System.Windows.Forms.ComboBox();
            this.m_dtpPreTime = new System.Windows.Forms.DateTimePicker();
            this.m_lbPre = new System.Windows.Forms.Label();
            this.m_chkPre = new System.Windows.Forms.CheckBox();
            this.m_lbRoom = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.m_lbEnd = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.m_lbStart = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_txtDept = new SourceLibrary.Windows.Forms.TextBoxTyped();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtDoc = new SourceLibrary.Windows.Forms.TextBoxTyped();
            this.m_txtRegType = new SourceLibrary.Windows.Forms.TextBoxTyped();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_radPatName = new System.Windows.Forms.RadioButton();
            this.m_radRegNo = new System.Windows.Forms.RadioButton();
            this.m_radCardID = new System.Windows.Forms.RadioButton();
            this.label19 = new System.Windows.Forms.Label();
            this.m_txtRegisterNo = new SourceLibrary.Windows.Forms.TextBoxTyped();
            this.m_txtPatType = new SourceLibrary.Windows.Forms.TextBoxTyped();
            this.m_cboSex = new System.Windows.Forms.ComboBox();
            this.m_dtpBirth = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtCard = new SourceLibrary.Windows.Forms.TextBoxTyped();
            this.label1 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.m_txtName = new SourceLibrary.Windows.Forms.TextBoxTyped();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.m_txtRegFee = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
            this.m_lsvRegDetail = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.label16 = new System.Windows.Forms.Label();
            this.m_b = new PinkieControls.ButtonXP();
            this.buttonXP1 = new PinkieControls.ButtonXP();
            this.m_cobSetPrint = new System.Windows.Forms.ComboBox();
            this.m_btnClear = new PinkieControls.ButtonXP();
            this.m_btnExit = new PinkieControls.ButtonXP();
            this.m_btnSave = new PinkieControls.ButtonXP();
            this.m_stb = new System.Windows.Forms.StatusBar();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_dtgRegister = new com.digitalwave.controls.ctlDataGridView();
            this.panel1.SuspendLayout();
            this.m_pnlAllPlan.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRegister)).BeginInit();
            this.SuspendLayout();
            // 
            // m_OmnipotenceQul
            // 
            this.m_OmnipotenceQul.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_OmnipotenceQul.ForeColor = System.Drawing.SystemColors.Highlight;
            this.m_OmnipotenceQul.Location = new System.Drawing.Point(672, 200);
            this.m_OmnipotenceQul.Name = "m_OmnipotenceQul";
            this.m_OmnipotenceQul.Size = new System.Drawing.Size(320, 16);
            this.m_OmnipotenceQul.TabIndex = 45;
            this.m_OmnipotenceQul.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_cmbQulType);
            this.panel1.Controls.Add(this.m_OmnipotenceQul);
            this.panel1.Controls.Add(this.m_pnlAllPlan);
            this.panel1.Controls.Add(this.m_btnQulReg);
            this.panel1.Controls.Add(this.m_datLastdate);
            this.panel1.Controls.Add(this.m_datFirstdate);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 311);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 192);
            this.panel1.TabIndex = 1;
            // 
            // m_cmbQulType
            // 
            this.m_cmbQulType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbQulType.Items.AddRange(new object[] {
            "全部",
            "退号",
            "候诊",
            "预约",
            "未结帐",
            "已结帐",
            "已就诊"});
            this.m_cmbQulType.Location = new System.Drawing.Point(640, 200);
            this.m_cmbQulType.Name = "m_cmbQulType";
            this.m_cmbQulType.Size = new System.Drawing.Size(88, 22);
            this.m_cmbQulType.TabIndex = 46;
            this.m_cmbQulType.Visible = false;
            this.m_cmbQulType.SelectedIndexChanged += new System.EventHandler(this.m_cmbQulType_SelectedIndexChanged);
            // 
            // m_pnlAllPlan
            // 
            this.m_pnlAllPlan.Controls.Add(this.m_lsvAllplan);
            this.m_pnlAllPlan.Location = new System.Drawing.Point(616, 200);
            this.m_pnlAllPlan.Name = "m_pnlAllPlan";
            this.m_pnlAllPlan.Size = new System.Drawing.Size(176, 216);
            this.m_pnlAllPlan.TabIndex = 44;
            this.m_pnlAllPlan.Visible = false;
            // 
            // m_lsvAllplan
            // 
            this.m_lsvAllplan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvAllplan.FullRowSelect = true;
            this.m_lsvAllplan.GridLines = true;
            this.m_lsvAllplan.HideSelection = false;
            this.m_lsvAllplan.Location = new System.Drawing.Point(0, 0);
            this.m_lsvAllplan.MultiSelect = false;
            this.m_lsvAllplan.Name = "m_lsvAllplan";
            this.m_lsvAllplan.Size = new System.Drawing.Size(176, 216);
            this.m_lsvAllplan.TabIndex = 3;
            this.m_lsvAllplan.UseCompatibleStateImageBehavior = false;
            this.m_lsvAllplan.View = System.Windows.Forms.View.Details;
            this.m_lsvAllplan.Visible = false;
            // 
            // m_btnQulReg
            // 
            this.m_btnQulReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnQulReg.DefaultScheme = true;
            this.m_btnQulReg.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnQulReg.Hint = "";
            this.m_btnQulReg.Location = new System.Drawing.Point(400, 208);
            this.m_btnQulReg.Name = "m_btnQulReg";
            this.m_btnQulReg.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnQulReg.Size = new System.Drawing.Size(104, 24);
            this.m_btnQulReg.TabIndex = 40;
            this.m_btnQulReg.Text = "查询";
            this.m_btnQulReg.Visible = false;
            this.m_btnQulReg.Click += new System.EventHandler(this.m_btnQulReg_Click);
            // 
            // m_datLastdate
            // 
            this.m_datLastdate.Location = new System.Drawing.Point(271, 208);
            this.m_datLastdate.Name = "m_datLastdate";
            this.m_datLastdate.Size = new System.Drawing.Size(128, 23);
            this.m_datLastdate.TabIndex = 39;
            this.m_datLastdate.Visible = false;
            // 
            // m_datFirstdate
            // 
            this.m_datFirstdate.Location = new System.Drawing.Point(80, 208);
            this.m_datFirstdate.Name = "m_datFirstdate";
            this.m_datFirstdate.Size = new System.Drawing.Size(128, 23);
            this.m_datFirstdate.TabIndex = 38;
            this.m_datFirstdate.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.m_lvItem);
            this.panel2.Location = new System.Drawing.Point(584, 232);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(208, 0);
            this.panel2.TabIndex = 24;
            // 
            // m_lvItem
            // 
            this.m_lvItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lvItem.FullRowSelect = true;
            this.m_lvItem.GridLines = true;
            this.m_lvItem.HideSelection = false;
            this.m_lvItem.Location = new System.Drawing.Point(0, 0);
            this.m_lvItem.Name = "m_lvItem";
            this.m_lvItem.Size = new System.Drawing.Size(208, 0);
            this.m_lvItem.TabIndex = 2;
            this.m_lvItem.UseCompatibleStateImageBehavior = false;
            this.m_lvItem.View = System.Windows.Forms.View.Details;
            this.m_lvItem.Visible = false;
            this.m_lvItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_lvItem_KeyDown_1);
            this.m_lvItem.Click += new System.EventHandler(this.m_lvItem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.m_chkNeedNotCard);
            this.groupBox3.Controls.Add(this.m_chkNeedNotfalill);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.m_txtAmount);
            this.groupBox3.Controls.Add(this.m_txtDiagFee);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.m_txtChangeCharge);
            this.groupBox3.Controls.Add(this.m_txtChangeDisCount);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox3.Location = new System.Drawing.Point(16, 264);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(560, 176);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "费用信息";
            this.groupBox3.Visible = false;
            // 
            // m_chkNeedNotCard
            // 
            this.m_chkNeedNotCard.Location = new System.Drawing.Point(440, 144);
            this.m_chkNeedNotCard.Name = "m_chkNeedNotCard";
            this.m_chkNeedNotCard.Size = new System.Drawing.Size(112, 24);
            this.m_chkNeedNotCard.TabIndex = 36;
            this.m_chkNeedNotCard.Text = "不需发卡(&Q)";
            this.m_chkNeedNotCard.Visible = false;
            this.m_chkNeedNotCard.CheckedChanged += new System.EventHandler(this.m_chkNotofalill_CheckedChanged);
            // 
            // m_chkNeedNotfalill
            // 
            this.m_chkNeedNotfalill.Location = new System.Drawing.Point(440, 112);
            this.m_chkNeedNotfalill.Name = "m_chkNeedNotfalill";
            this.m_chkNeedNotfalill.Size = new System.Drawing.Size(112, 24);
            this.m_chkNeedNotfalill.TabIndex = 35;
            this.m_chkNeedNotfalill.Text = "不需病历(&S)";
            this.m_chkNeedNotfalill.Visible = false;
            this.m_chkNeedNotfalill.CheckedChanged += new System.EventHandler(this.m_chkNotofalill_CheckedChanged);
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(408, 123);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(144, 40);
            this.label20.TabIndex = 38;
            this.label20.Text = "按F12将当前费别的金额优惠比例置零";
            this.label20.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(405, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 14);
            this.label8.TabIndex = 33;
            this.label8.Text = "金额";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(405, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 14);
            this.label10.TabIndex = 34;
            this.label10.Text = "优惠";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtAmount
            // 
            this.m_txtAmount.EnableAutoValidation = true;
            this.m_txtAmount.EnableEnterKeyValidate = true;
            this.m_txtAmount.EnableEscapeKeyUndo = true;
            this.m_txtAmount.EnableLastValidValue = true;
            this.m_txtAmount.ErrorProvider = null;
            this.m_txtAmount.ErrorProviderMessage = "Invalid value";
            this.m_txtAmount.ForceFormatText = true;
            this.m_txtAmount.Location = new System.Drawing.Point(256, 22);
            this.m_txtAmount.Name = "m_txtAmount";
            this.m_txtAmount.NumericCharStyle = SourceLibrary.Windows.Forms.NumericCharStyle.DecimalSeparator;
            this.m_txtAmount.Size = new System.Drawing.Size(120, 23);
            this.m_txtAmount.TabIndex = 10;
            this.m_txtAmount.Text = "textBoxTypedNumeric3";
            this.m_txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtAmount.Visible = false;
            this.m_txtAmount.TextChanged += new System.EventHandler(this.m_txtAmount_TextChanged);
            this.m_txtAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtAmount_KeyDown);
            // 
            // m_txtDiagFee
            // 
            this.m_txtDiagFee.EnableAutoValidation = true;
            this.m_txtDiagFee.EnableEnterKeyValidate = true;
            this.m_txtDiagFee.EnableEscapeKeyUndo = true;
            this.m_txtDiagFee.EnableLastValidValue = true;
            this.m_txtDiagFee.ErrorProvider = null;
            this.m_txtDiagFee.ErrorProviderMessage = "Invalid value";
            this.m_txtDiagFee.ForceFormatText = true;
            this.m_txtDiagFee.Location = new System.Drawing.Point(448, 22);
            this.m_txtDiagFee.Name = "m_txtDiagFee";
            this.m_txtDiagFee.NumericCharStyle = SourceLibrary.Windows.Forms.NumericCharStyle.DecimalSeparator;
            this.m_txtDiagFee.Size = new System.Drawing.Size(96, 23);
            this.m_txtDiagFee.TabIndex = 9;
            this.m_txtDiagFee.Text = "textBoxTypedNumeric1";
            this.m_txtDiagFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtDiagFee.Visible = false;
            this.m_txtDiagFee.TextChanged += new System.EventHandler(this.m_txtPatType_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(192, 24);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 14);
            this.label17.TabIndex = 28;
            this.label17.Text = "实收金额";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label17.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(384, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 14);
            this.label15.TabIndex = 27;
            this.label15.Text = "找余金额";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label15.Visible = false;
            // 
            // m_txtChangeCharge
            // 
            this.m_txtChangeCharge.EnableAutoValidation = true;
            this.m_txtChangeCharge.EnableEnterKeyValidate = true;
            this.m_txtChangeCharge.EnableEscapeKeyUndo = true;
            this.m_txtChangeCharge.EnableLastValidValue = true;
            this.m_txtChangeCharge.ErrorProvider = null;
            this.m_txtChangeCharge.ErrorProviderMessage = "Invalid value";
            this.m_txtChangeCharge.ForceFormatText = true;
            this.m_txtChangeCharge.Location = new System.Drawing.Point(448, 54);
            this.m_txtChangeCharge.Name = "m_txtChangeCharge";
            this.m_txtChangeCharge.NumericCharStyle = SourceLibrary.Windows.Forms.NumericCharStyle.DecimalSeparator;
            this.m_txtChangeCharge.Size = new System.Drawing.Size(96, 23);
            this.m_txtChangeCharge.TabIndex = 10;
            this.m_txtChangeCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtChangeCharge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtChangeCharge_KeyPress);
            this.m_txtChangeCharge.Validating += new System.ComponentModel.CancelEventHandler(this.m_txtChangeCharge_Validating);
            this.m_txtChangeCharge.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtChangeDisCount_KeyDown);
            // 
            // m_txtChangeDisCount
            // 
            this.m_txtChangeDisCount.EnableAutoValidation = true;
            this.m_txtChangeDisCount.EnableEnterKeyValidate = true;
            this.m_txtChangeDisCount.EnableEscapeKeyUndo = true;
            this.m_txtChangeDisCount.EnableLastValidValue = true;
            this.m_txtChangeDisCount.ErrorProvider = null;
            this.m_txtChangeDisCount.ErrorProviderMessage = "Invalid value";
            this.m_txtChangeDisCount.ForceFormatText = true;
            this.m_txtChangeDisCount.Location = new System.Drawing.Point(448, 86);
            this.m_txtChangeDisCount.Name = "m_txtChangeDisCount";
            this.m_txtChangeDisCount.NumericCharStyle = SourceLibrary.Windows.Forms.NumericCharStyle.DecimalSeparator;
            this.m_txtChangeDisCount.Size = new System.Drawing.Size(96, 23);
            this.m_txtChangeDisCount.TabIndex = 10;
            this.m_txtChangeDisCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtChangeDisCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtChangeDisCount_KeyPress);
            this.m_txtChangeDisCount.Validating += new System.ComponentModel.CancelEventHandler(this.m_txtChangeCharge_Validating);
            this.m_txtChangeDisCount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtChangeDisCount_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_cboSeg);
            this.groupBox2.Controls.Add(this.m_dtpPreTime);
            this.groupBox2.Controls.Add(this.m_lbPre);
            this.groupBox2.Controls.Add(this.m_chkPre);
            this.groupBox2.Controls.Add(this.m_lbRoom);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.m_lbEnd);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.m_lbStart);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.m_txtDept);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.m_txtDoc);
            this.groupBox2.Controls.Add(this.m_txtRegType);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox2.Location = new System.Drawing.Point(16, 248);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(560, 88);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "挂号信息";
            this.groupBox2.Visible = false;
            // 
            // m_cboSeg
            // 
            this.m_cboSeg.Location = new System.Drawing.Point(320, 22);
            this.m_cboSeg.Name = "m_cboSeg";
            this.m_cboSeg.Size = new System.Drawing.Size(64, 22);
            this.m_cboSeg.TabIndex = 35;
            this.m_cboSeg.Text = "comboBox1";
            this.m_cboSeg.Visible = false;
            this.m_cboSeg.SelectedIndexChanged += new System.EventHandler(this.m_cboSeg_SelectedIndexChanged);
            // 
            // m_dtpPreTime
            // 
            this.m_dtpPreTime.Location = new System.Drawing.Point(176, 20);
            this.m_dtpPreTime.Name = "m_dtpPreTime";
            this.m_dtpPreTime.Size = new System.Drawing.Size(128, 23);
            this.m_dtpPreTime.TabIndex = 34;
            this.m_dtpPreTime.Visible = false;
            this.m_dtpPreTime.ValueChanged += new System.EventHandler(this.m_dtpPreTime_ValueChanged);
            this.m_dtpPreTime.CloseUp += new System.EventHandler(this.m_dtpPreTime_CloseUp);
            // 
            // m_lbPre
            // 
            this.m_lbPre.AutoSize = true;
            this.m_lbPre.Location = new System.Drawing.Point(104, 24);
            this.m_lbPre.Name = "m_lbPre";
            this.m_lbPre.Size = new System.Drawing.Size(63, 14);
            this.m_lbPre.TabIndex = 33;
            this.m_lbPre.Text = "预约时间";
            this.m_lbPre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lbPre.Visible = false;
            // 
            // m_chkPre
            // 
            this.m_chkPre.Location = new System.Drawing.Point(17, 22);
            this.m_chkPre.Name = "m_chkPre";
            this.m_chkPre.Size = new System.Drawing.Size(80, 24);
            this.m_chkPre.TabIndex = 32;
            this.m_chkPre.Text = "预约";
            this.m_chkPre.Visible = false;
            this.m_chkPre.CheckedChanged += new System.EventHandler(this.m_chkPre_CheckedChanged);
            // 
            // m_lbRoom
            // 
            this.m_lbRoom.BackColor = System.Drawing.SystemColors.Window;
            this.m_lbRoom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lbRoom.Location = new System.Drawing.Point(424, 88);
            this.m_lbRoom.Name = "m_lbRoom";
            this.m_lbRoom.Size = new System.Drawing.Size(112, 23);
            this.m_lbRoom.TabIndex = 31;
            this.m_lbRoom.Text = "label13";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(360, 90);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 14);
            this.label14.TabIndex = 30;
            this.label14.Text = "就诊地点";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lbEnd
            // 
            this.m_lbEnd.BackColor = System.Drawing.SystemColors.Window;
            this.m_lbEnd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lbEnd.Location = new System.Drawing.Point(256, 88);
            this.m_lbEnd.Name = "m_lbEnd";
            this.m_lbEnd.Size = new System.Drawing.Size(88, 23);
            this.m_lbEnd.TabIndex = 29;
            this.m_lbEnd.Text = "label11";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(192, 90);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 14);
            this.label12.TabIndex = 28;
            this.label12.Text = "结束时间";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lbStart
            // 
            this.m_lbStart.BackColor = System.Drawing.SystemColors.Window;
            this.m_lbStart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lbStart.Location = new System.Drawing.Point(88, 88);
            this.m_lbStart.Name = "m_lbStart";
            this.m_lbStart.Size = new System.Drawing.Size(88, 23);
            this.m_lbStart.TabIndex = 27;
            this.m_lbStart.Text = "label10";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 14);
            this.label9.TabIndex = 26;
            this.label9.Text = "开诊时间";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(188, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 23;
            this.label7.Text = "挂号类型";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 21;
            this.label6.Text = "挂号科室";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtDept
            // 
            this.m_txtDept.EnableAutoValidation = false;
            this.m_txtDept.EnableEnterKeyValidate = true;
            this.m_txtDept.EnableEscapeKeyUndo = true;
            this.m_txtDept.EnableLastValidValue = true;
            this.m_txtDept.ErrorProvider = null;
            this.m_txtDept.ErrorProviderMessage = "Invalid value";
            this.m_txtDept.ForceFormatText = true;
            this.m_txtDept.Location = new System.Drawing.Point(88, 56);
            this.m_txtDept.Name = "m_txtDept";
            this.m_txtDept.Size = new System.Drawing.Size(88, 23);
            this.m_txtDept.TabIndex = 5;
            this.m_txtDept.Text = "textBoxTyped6";
            this.m_txtDept.Enter += new System.EventHandler(this.m_txtDept_Enter);
            this.m_txtDept.TextChanged += new System.EventHandler(this.m_txtPatType_TextChanged);
            this.m_txtDept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtDept_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(383, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 25;
            this.label3.Text = "医生";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtDoc
            // 
            this.m_txtDoc.EnableAutoValidation = false;
            this.m_txtDoc.EnableEnterKeyValidate = true;
            this.m_txtDoc.EnableEscapeKeyUndo = true;
            this.m_txtDoc.EnableLastValidValue = true;
            this.m_txtDoc.ErrorProvider = null;
            this.m_txtDoc.ErrorProviderMessage = "Invalid value";
            this.m_txtDoc.ForceFormatText = true;
            this.m_txtDoc.Location = new System.Drawing.Point(424, 56);
            this.m_txtDoc.Name = "m_txtDoc";
            this.m_txtDoc.Size = new System.Drawing.Size(112, 23);
            this.m_txtDoc.TabIndex = 7;
            this.m_txtDoc.Text = "textBoxTyped8";
            this.m_txtDoc.Enter += new System.EventHandler(this.m_txtDoc_Enter);
            this.m_txtDoc.TextChanged += new System.EventHandler(this.m_txtPatType_TextChanged);
            this.m_txtDoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtDoc_KeyDown);
            // 
            // m_txtRegType
            // 
            this.m_txtRegType.EnableAutoValidation = false;
            this.m_txtRegType.EnableEnterKeyValidate = true;
            this.m_txtRegType.EnableEscapeKeyUndo = true;
            this.m_txtRegType.EnableLastValidValue = true;
            this.m_txtRegType.ErrorProvider = null;
            this.m_txtRegType.ErrorProviderMessage = "Invalid value";
            this.m_txtRegType.ForceFormatText = true;
            this.m_txtRegType.Location = new System.Drawing.Point(256, 56);
            this.m_txtRegType.Name = "m_txtRegType";
            this.m_txtRegType.Size = new System.Drawing.Size(88, 23);
            this.m_txtRegType.TabIndex = 6;
            this.m_txtRegType.Text = "textBoxTyped7";
            this.m_txtRegType.Enter += new System.EventHandler(this.m_txtRegType_Enter);
            this.m_txtRegType.TextChanged += new System.EventHandler(this.m_txtPatType_TextChanged);
            this.m_txtRegType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtRegType_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_radPatName);
            this.groupBox1.Controls.Add(this.m_radRegNo);
            this.groupBox1.Controls.Add(this.m_radCardID);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.m_txtRegisterNo);
            this.groupBox1.Controls.Add(this.m_txtPatType);
            this.groupBox1.Controls.Add(this.m_cboSex);
            this.groupBox1.Controls.Add(this.m_dtpBirth);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.m_txtCard);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.m_txtName);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox1.Location = new System.Drawing.Point(432, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 136);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "病人基本信息查找";
            // 
            // m_radPatName
            // 
            this.m_radPatName.Location = new System.Drawing.Point(249, 102);
            this.m_radPatName.Name = "m_radPatName";
            this.m_radPatName.Size = new System.Drawing.Size(104, 24);
            this.m_radPatName.TabIndex = 29;
            this.m_radPatName.Text = "查询 F8";
            this.m_radPatName.CheckedChanged += new System.EventHandler(this.m_chkPatName_CheckedChanged);
            // 
            // m_radRegNo
            // 
            this.m_radRegNo.Location = new System.Drawing.Point(248, 61);
            this.m_radRegNo.Name = "m_radRegNo";
            this.m_radRegNo.Size = new System.Drawing.Size(104, 24);
            this.m_radRegNo.TabIndex = 28;
            this.m_radRegNo.Text = "查询 F7";
            this.m_radRegNo.CheckedChanged += new System.EventHandler(this.m_chkRegNo_CheckedChanged);
            // 
            // m_radCardID
            // 
            this.m_radCardID.Location = new System.Drawing.Point(248, 22);
            this.m_radCardID.Name = "m_radCardID";
            this.m_radCardID.Size = new System.Drawing.Size(104, 24);
            this.m_radCardID.TabIndex = 27;
            this.m_radCardID.Text = "查询 F6";
            this.m_radCardID.CheckedChanged += new System.EventHandler(this.m_chkCardID_CheckedChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(28, 62);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(49, 14);
            this.label19.TabIndex = 26;
            this.label19.Text = "流水号";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtRegisterNo
            // 
            this.m_txtRegisterNo.EnableAutoValidation = false;
            this.m_txtRegisterNo.EnableEnterKeyValidate = true;
            this.m_txtRegisterNo.EnableEscapeKeyUndo = true;
            this.m_txtRegisterNo.EnableLastValidValue = true;
            this.m_txtRegisterNo.ErrorProvider = null;
            this.m_txtRegisterNo.ErrorProviderMessage = "Invalid value";
            this.m_txtRegisterNo.ForceFormatText = true;
            this.m_txtRegisterNo.Location = new System.Drawing.Point(80, 59);
            this.m_txtRegisterNo.Name = "m_txtRegisterNo";
            this.m_txtRegisterNo.Size = new System.Drawing.Size(160, 23);
            this.m_txtRegisterNo.TabIndex = 1;
            this.m_txtRegisterNo.Enter += new System.EventHandler(this.m_txtRegisterNo_Enter);
            this.m_txtRegisterNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtName_KeyPress);
            // 
            // m_txtPatType
            // 
            this.m_txtPatType.EnableAutoValidation = false;
            this.m_txtPatType.EnableEnterKeyValidate = true;
            this.m_txtPatType.EnableEscapeKeyUndo = true;
            this.m_txtPatType.EnableLastValidValue = true;
            this.m_txtPatType.ErrorProvider = null;
            this.m_txtPatType.ErrorProviderMessage = "Invalid value";
            this.m_txtPatType.ForceFormatText = true;
            this.m_txtPatType.Location = new System.Drawing.Point(440, 104);
            this.m_txtPatType.Name = "m_txtPatType";
            this.m_txtPatType.Size = new System.Drawing.Size(104, 23);
            this.m_txtPatType.TabIndex = 4;
            this.m_txtPatType.Text = "textBoxTyped5";
            this.m_txtPatType.Visible = false;
            this.m_txtPatType.Enter += new System.EventHandler(this.m_txtPatType_Enter);
            this.m_txtPatType.TextChanged += new System.EventHandler(this.m_txtPatType_TextChanged);
            this.m_txtPatType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtPatType_KeyDown);
            // 
            // m_cboSex
            // 
            this.m_cboSex.Location = new System.Drawing.Point(72, 144);
            this.m_cboSex.Name = "m_cboSex";
            this.m_cboSex.Size = new System.Drawing.Size(64, 22);
            this.m_cboSex.TabIndex = 2;
            this.m_cboSex.Text = "comboBox2";
            this.m_cboSex.Visible = false;
            this.m_cboSex.SelectedIndexChanged += new System.EventHandler(this.m_cboSex_SelectedIndexChanged);
            this.m_cboSex.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cboSex_KeyDown);
            // 
            // m_dtpBirth
            // 
            this.m_dtpBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.m_dtpBirth.Location = new System.Drawing.Point(242, 160);
            this.m_dtpBirth.Name = "m_dtpBirth";
            this.m_dtpBirth.Size = new System.Drawing.Size(96, 23);
            this.m_dtpBirth.TabIndex = 3;
            this.m_dtpBirth.Visible = false;
            this.m_dtpBirth.ValueChanged += new System.EventHandler(this.m_dtpBirth_ValueChanged);
            this.m_dtpBirth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_dtpBirth_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(376, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 14);
            this.label5.TabIndex = 24;
            this.label5.Text = "病人类别(&E)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(154, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 14);
            this.label4.TabIndex = 22;
            this.label4.Text = "出生日期(&D)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 19;
            this.label2.Text = "姓名";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtCard
            // 
            this.m_txtCard.EnableAutoValidation = false;
            this.m_txtCard.EnableEnterKeyValidate = false;
            this.m_txtCard.EnableEscapeKeyUndo = true;
            this.m_txtCard.EnableLastValidValue = true;
            this.m_txtCard.ErrorProvider = null;
            this.m_txtCard.ErrorProviderMessage = "Invalid value";
            this.m_txtCard.ForceFormatText = true;
            this.m_txtCard.Location = new System.Drawing.Point(80, 19);
            this.m_txtCard.MaxLength = 10;
            this.m_txtCard.Name = "m_txtCard";
            this.m_txtCard.Size = new System.Drawing.Size(160, 23);
            this.m_txtCard.TabIndex = 0;
            this.m_txtCard.Text = "textBoxTyped1";
            this.m_txtCard.Enter += new System.EventHandler(this.m_txtCard_Enter);
            this.m_txtCard.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtName_KeyPress);
            this.m_txtCard.TextChanged += new System.EventHandler(this.m_txtCard_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 15;
            this.label1.Text = "诊疗卡号";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(16, 144);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 14);
            this.label18.TabIndex = 20;
            this.label18.Text = "性别(&C)";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label18.Visible = false;
            // 
            // m_txtName
            // 
            this.m_txtName.EnableAutoValidation = false;
            this.m_txtName.EnableEnterKeyValidate = true;
            this.m_txtName.EnableEscapeKeyUndo = true;
            this.m_txtName.EnableLastValidValue = true;
            this.m_txtName.ErrorProvider = null;
            this.m_txtName.ErrorProviderMessage = "Invalid value";
            this.m_txtName.ForceFormatText = true;
            this.m_txtName.Location = new System.Drawing.Point(80, 100);
            this.m_txtName.Name = "m_txtName";
            this.m_txtName.Size = new System.Drawing.Size(160, 23);
            this.m_txtName.TabIndex = 2;
            this.m_txtName.Text = "textBoxTyped2";
            this.m_txtName.Enter += new System.EventHandler(this.m_txtName_Enter);
            this.m_txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtName_KeyPress);
            // 
            // label11
            // 
            this.label11.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label11.Location = new System.Drawing.Point(16, 216);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 23);
            this.label11.TabIndex = 41;
            this.label11.Text = "开始日期";
            this.label11.Visible = false;
            // 
            // label13
            // 
            this.label13.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label13.Location = new System.Drawing.Point(211, 216);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 23);
            this.label13.TabIndex = 42;
            this.label13.Text = "截止日期";
            this.label13.Visible = false;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(600, 200);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(35, 14);
            this.label21.TabIndex = 27;
            this.label21.Text = "筛选";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label21.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.m_txtRegFee);
            this.groupBox4.Controls.Add(this.m_lsvRegDetail);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Location = new System.Drawing.Point(9, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(416, 176);
            this.groupBox4.TabIndex = 47;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "挂号费用";
            // 
            // m_txtRegFee
            // 
            this.m_txtRegFee.EnableAutoValidation = true;
            this.m_txtRegFee.EnableEnterKeyValidate = true;
            this.m_txtRegFee.EnableEscapeKeyUndo = true;
            this.m_txtRegFee.EnableLastValidValue = true;
            this.m_txtRegFee.ErrorProvider = null;
            this.m_txtRegFee.ErrorProviderMessage = "Invalid value";
            this.m_txtRegFee.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtRegFee.ForceFormatText = true;
            this.m_txtRegFee.ForeColor = System.Drawing.Color.Red;
            this.m_txtRegFee.Location = new System.Drawing.Point(92, 141);
            this.m_txtRegFee.Name = "m_txtRegFee";
            this.m_txtRegFee.NumericCharStyle = SourceLibrary.Windows.Forms.NumericCharStyle.DecimalSeparator;
            this.m_txtRegFee.ReadOnly = true;
            this.m_txtRegFee.Size = new System.Drawing.Size(312, 26);
            this.m_txtRegFee.TabIndex = 8;
            this.m_txtRegFee.Text = "textBoxTypedNumeric2";
            this.m_txtRegFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtRegFee.TextChanged += new System.EventHandler(this.m_txtPatType_TextChanged);
            // 
            // m_lsvRegDetail
            // 
            this.m_lsvRegDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13});
            this.m_lsvRegDetail.ForeColor = System.Drawing.SystemColors.Highlight;
            this.m_lsvRegDetail.FullRowSelect = true;
            this.m_lsvRegDetail.GridLines = true;
            this.m_lsvRegDetail.HideSelection = false;
            this.m_lsvRegDetail.Location = new System.Drawing.Point(11, 22);
            this.m_lsvRegDetail.Name = "m_lsvRegDetail";
            this.m_lsvRegDetail.Size = new System.Drawing.Size(392, 112);
            this.m_lsvRegDetail.TabIndex = 29;
            this.m_lsvRegDetail.UseCompatibleStateImageBehavior = false;
            this.m_lsvRegDetail.View = System.Windows.Forms.View.Details;
            this.m_lsvRegDetail.SelectedIndexChanged += new System.EventHandler(this.m_lsvRegDetail_SelectedIndexChanged);
            this.m_lsvRegDetail.Click += new System.EventHandler(this.m_lsvRegDetail_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "columnHeader1";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "费别编号";
            this.columnHeader9.Width = 0;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "费别名称";
            this.columnHeader10.Width = 100;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "金额";
            this.columnHeader11.Width = 92;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "优惠比例";
            this.columnHeader12.Width = 100;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "备注";
            this.columnHeader13.Width = 100;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(6, 144);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(93, 16);
            this.label16.TabIndex = 25;
            this.label16.Text = "共计金额：";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_b
            // 
            this.m_b.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_b.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_b.DefaultScheme = true;
            this.m_b.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_b.Hint = "";
            this.m_b.Location = new System.Drawing.Point(136, 552);
            this.m_b.Name = "m_b";
            this.m_b.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_b.Size = new System.Drawing.Size(122, 24);
            this.m_b.TabIndex = 43;
            this.m_b.Text = "打印 F2";
            this.m_b.Visible = false;
            this.m_b.Click += new System.EventHandler(this.m_b_Click);
            // 
            // buttonXP1
            // 
            this.buttonXP1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonXP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP1.DefaultScheme = true;
            this.buttonXP1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP1.Hint = "";
            this.buttonXP1.Location = new System.Drawing.Point(552, 472);
            this.buttonXP1.Name = "buttonXP1";
            this.buttonXP1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP1.Size = new System.Drawing.Size(122, 24);
            this.buttonXP1.TabIndex = 37;
            this.buttonXP1.Text = "退号 F5";
            this.buttonXP1.Click += new System.EventHandler(this.buttonXP1_Click);
            // 
            // m_cobSetPrint
            // 
            this.m_cobSetPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_cobSetPrint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cobSetPrint.Items.AddRange(new object[] {
            "打印",
            "预览"});
            this.m_cobSetPrint.Location = new System.Drawing.Point(473, 552);
            this.m_cobSetPrint.Name = "m_cobSetPrint";
            this.m_cobSetPrint.Size = new System.Drawing.Size(87, 22);
            this.m_cobSetPrint.TabIndex = 36;
            // 
            // m_btnClear
            // 
            this.m_btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnClear.DefaultScheme = true;
            this.m_btnClear.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnClear.Hint = "";
            this.m_btnClear.Location = new System.Drawing.Point(432, 472);
            this.m_btnClear.Name = "m_btnClear";
            this.m_btnClear.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnClear.Size = new System.Drawing.Size(104, 24);
            this.m_btnClear.TabIndex = 29;
            this.m_btnClear.Text = "清空 F3";
            this.m_btnClear.Click += new System.EventHandler(this.m_btnClear_Click);
            // 
            // m_btnExit
            // 
            this.m_btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnExit.DefaultScheme = true;
            this.m_btnExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnExit.Hint = "";
            this.m_btnExit.Location = new System.Drawing.Point(688, 472);
            this.m_btnExit.Name = "m_btnExit";
            this.m_btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnExit.Size = new System.Drawing.Size(104, 24);
            this.m_btnExit.TabIndex = 28;
            this.m_btnExit.Text = "退出 Esc";
            this.m_btnExit.Click += new System.EventHandler(this.m_btnExit_Click);
            // 
            // m_btnSave
            // 
            this.m_btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnSave.DefaultScheme = true;
            this.m_btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnSave.Hint = "";
            this.m_btnSave.Location = new System.Drawing.Point(7, 536);
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnSave.Size = new System.Drawing.Size(122, 24);
            this.m_btnSave.TabIndex = 25;
            this.m_btnSave.Text = "还原 F2";
            this.m_btnSave.Visible = false;
            this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
            // 
            // m_stb
            // 
            this.m_stb.Location = new System.Drawing.Point(0, 503);
            this.m_stb.Name = "m_stb";
            this.m_stb.Size = new System.Drawing.Size(800, 22);
            this.m_stb.TabIndex = 2;
            this.m_stb.Text = "挂号";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.m_dtgRegister);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 311);
            this.panel3.TabIndex = 3;
            // 
            // m_dtgRegister
            // 
            this.m_dtgRegister.CaptionVisible = false;
            this.m_dtgRegister.DataMember = "";
            this.m_dtgRegister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dtgRegister.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.m_dtgRegister.Location = new System.Drawing.Point(0, 0);
            this.m_dtgRegister.m_clrBack = System.Drawing.Color.White;
            this.m_dtgRegister.m_clrBackB = System.Drawing.Color.WhiteSmoke;
            this.m_dtgRegister.m_clrFore = System.Drawing.Color.Black;
            this.m_dtgRegister.m_clrForeB = System.Drawing.Color.Black;
            this.m_dtgRegister.Name = "m_dtgRegister";
            this.m_dtgRegister.ReadOnly = true;
            this.m_dtgRegister.Size = new System.Drawing.Size(796, 307);
            this.m_dtgRegister.TabIndex = 0;
            // 
            // frmReturnReg
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(800, 525);
            this.Controls.Add(this.m_btnSave);
            this.Controls.Add(this.buttonXP1);
            this.Controls.Add(this.m_cobSetPrint);
            this.Controls.Add(this.m_btnClear);
            this.Controls.Add(this.m_btnExit);
            this.Controls.Add(this.m_b);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_stb);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmReturnReg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "门诊挂号退号";
            this.Deactivate += new System.EventHandler(this.frmRegister_Deactivate);
            this.Activated += new System.EventHandler(this.frmRegister_Activated);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmRegister_KeyPress);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRegister_KeyDown);
            this.Load += new System.EventHandler(this.frmRegister_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.m_pnlAllPlan.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRegister)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
		public override void CreateController()
		{
			this.objController=new com.digitalwave.iCare.gui.HIS.clsControlReturnReg();
			objController.Set_GUI_Apperance(this);
		}

		private void frmRegister_Load(object sender, System.EventArgs e)
		{
			m_mthSetFormControlCanBeNull(this);
			((clsControlReturnReg)this.objController).m_FillComboBox();
			((clsControlReturnReg)this.objController).m_Clear();
//			((clsControlReturnReg)this.objController).m_CheckPlan();
			((clsControlReturnReg)this.objController).m_GetPay();
			this.m_cobSetPrint.SelectedIndex = 0;
		}

		private void m_chkPre_CheckedChanged(object sender, System.EventArgs e)
		{
			if(m_chkPre.Checked==true)
			{
				this.m_dtpPreTime.Show();
				this.m_cboSeg.Show();
				m_lbPre.Show();
				m_dtpPreTime.Focus();
			}
			else
			{
				this.m_dtpPreTime.Hide();
				this.m_cboSeg.Hide();
				m_lbPre.Hide();
			}
		}

		private void m_dtpPreTime_ValueChanged(object sender, System.EventArgs e)
		{
			bool bnlCheck=((clsControlReturnReg)this.objController).bnlCheckDate();
			if(!bnlCheck)
			{
				//				MessageBox.Show("不能挂当前时间前的号","提示");
				//                m_dtpPreTime.Value=((clsControlReturnReg)this.objController).m_ServDate();
				m_dtpPreTime.Focus();
			}
		}

		private void m_cboSeg_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			bool bnlCheck=((clsControlReturnReg)this.objController).bnlCheckDate();
			if(!bnlCheck)
			{
				//				MessageBox.Show("不能挂当前时间前的号","提示");
				//				m_cboSeg.SelectedIndex=((clsControlReturnReg)this.objController).m_GetSerPerio();
			}
			else
				this.m_txtDept.Focus();
		}

		private void m_txtPatType_Enter(object sender, System.EventArgs e)
		{
			((clsControlReturnReg)this.objController).m_GetlvwItem();
		}

		private void m_txtDept_Enter(object sender, System.EventArgs e)
		{
			((clsControlReturnReg)this.objController).m_GetlvwItem();
		}

		private void m_txtRegType_Enter(object sender, System.EventArgs e)
		{
			((clsControlReturnReg)this.objController).m_GetlvwItem();
		}

		private void m_txtDoc_Enter(object sender, System.EventArgs e)
		{
			((clsControlReturnReg)this.objController).m_GetlvwItem();
		}

		private void m_txtPatType_TextChanged(object sender, System.EventArgs e)
		{
			
			((clsControlReturnReg)this.objController).m_txtChange();
		}

		private void m_btnExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		private void m_btnClear_Click(object sender, System.EventArgs e)
		{
			((clsControlReturnReg)this.objController).m_Clear();
			try
			{
				((clsControlReturnReg)this.objController).m_dvRegister.Table.Rows.Clear();
			}
			catch{}
		}

		private void frmRegister_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled=(e.KeyChar==(char)32 || e.KeyChar=="'".ToCharArray()[0]);
		}

		private void frmRegister_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Escape:
					this.Close();
					break;
				case Keys.F2:
				//	this.m_btnSave_Click(sender,e);
					break;
				case Keys.F3:
					this.m_btnClear_Click(sender,e);
					break;
				case Keys.F5:
					this.buttonXP1_Click(null,null);
					break;
				case Keys.F6:
					this.m_radCardID.Checked = true;
					break;
				case Keys.F7:
					this.m_radRegNo.Checked = true;
					break;
				case Keys.F8:
					this.m_radPatName.Checked = true;
					break;
				case Keys.F12:
//					bool bl = false;
//					for(int i=0;i<this.m_lsvRegDetail.Items.Count;i++)
//					{
//						if(this.m_lsvRegDetail.Items[i].Selected)
//						{
//							if(this.m_lsvRegDetail.Items[i].SubItems[5].Text.IndexOf("不可修改")>=0)
//								bl = true;
//						}
//					}
//					if(bl) break;
//					this.m_txtChangeCharge.Text = "0";
//					this.m_txtChangeDisCount.Text = "0";
//					((clsControlReturnReg)this.objController).m_intModifyPrice();
					//this.m_txtChangeCharge.Focus();
					break;
					//				case Keys.Enter:
					//					if(this.ActiveControl.Name=="m_lvItem")
					//                        this.m_lvItem_Click(sender,e);
					//					else
					//						SendKeys.SendWait("{Tab}");
					//					break;
				case Keys.Right:
					if(this.ActiveControl.Name!="m_lvItem" && this.ActiveControl.Name!="m_lvPat")
						if(m_lvItem.Items.Count>0)
							m_lvItem.Focus();
					break;
				case Keys.Left:
					if(this.ActiveControl.Name=="m_lvItem")
						((clsControlReturnReg)this.objController).m_txtFocus();
					break;
			}
		}

		private void m_btnSave_Click(object sender, System.EventArgs e)
		{
			((clsControlReturnReg)this.objController).m_ResetReg();
		}

		private void m_lvItem_Click(object sender, System.EventArgs e)
		{
			((clsControlReturnReg)this.objController).m_lvwItemClick();
		}

		private void m_lvItem_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				this.m_lvItem_Click(sender,e);
		}

		private void m_dtpPreTime_CloseUp(object sender, System.EventArgs e)
		{
			this.m_cboSeg.Focus();
		}

		private void m_cboSex_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_cboSex.SelectedIndex>-1)
				this.errorProvider1.SetError(m_cboSex,"");
		}

		private void m_cboSex_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				this.m_dtpBirth.Focus();
		}

		private void m_txtPatType_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				this.m_lvItem_Click(sender,e);
				//				this.m_txtDept.Focus();
			}
		}

		private void m_txtDept_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				this.m_lvItem_Click(sender,e);
				//				this.m_txtRegType.Focus();
			}
		}

		private void m_txtRegType_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				this.m_lvItem_Click(sender,e);
				//				this.m_txtDoc.Focus();
			}
		}

		private void m_txtDoc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				this.m_lvItem_Click(sender,e);
				this.m_txtAmount.Focus();
			}
		}

		private void m_lvItem_KeyDown_1(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				this.m_lvItem_Click(sender,e);
			}
		}

		private void m_txtCard_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				this.m_txtName.Focus();
			}
			if(e.KeyCode == Keys.F4)
			{
				//((clsControlReturnReg)this.objController).m_NewCard();
			}
		}

		private void m_dtpBirth_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				this.m_txtPatType.Focus();
			}
		}

		private void m_txtName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				this.m_cboSex.Focus();
			}
		}

		private void m_dtpBirth_ValueChanged(object sender, System.EventArgs e)
		{
			((clsControlReturnReg)this.objController).bnlChekcBirth();
		}

		private void m_txtCard_Leave(object sender, System.EventArgs e)
		{
			if(this.Tag !=null && this.Tag.ToString()=="Y")
				return;
			if(this.ActiveControl==null || this.ActiveControl.Name=="m_btnClear" || 
				this.Visible==false || this.ActiveControl.Name=="m_btnExit")
				return;
			((clsControlReturnReg)this.objController).m_FindPat();
		}

		private void frmRegister_Activated(object sender, System.EventArgs e)
		{
			this.Tag=null;
		}

		private void frmRegister_Deactivate(object sender, System.EventArgs e)
		{
			this.Tag="Y";
		}

		private void m_txtAmount_TextChanged(object sender, System.EventArgs e)
		{
			((clsControlReturnReg)this.objController).m_Calculate();
		}

		private void m_chkNotofalill_CheckedChanged(object sender, System.EventArgs e)
		{
			
		}

		private void m_txtAmount_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				this.m_btnSave.Focus();
			}
		}

		private void m_txtChangeDisCount_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
			{
				int index = 0;
				index = ((clsControlReturnReg)this.objController).m_intModifyPrice();
				((clsControlReturnReg)this.objController).m_UpDown(index,e);
			}
		}

		private void m_lsvRegDetail_Click(object sender, System.EventArgs e)
		{
			((clsControlReturnReg)this.objController).m_getCurPrice();
		}

		private void m_lsvRegDetail_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_lsvRegDetail_Click(null,null);
		}

		private void m_txtChangeCharge_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar == (char)13)
			{
				this.m_txtChangeDisCount.Focus();
			}
		}

		private void m_txtChangeDisCount_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar == (char)13)
			{
				this.m_btnSave.Focus();
			}
		}

		

		private void m_txtChangeCharge_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			int index = 0;
			index = ((clsControlReturnReg)this.objController).m_intModifyPrice();
		}

		private void m_btnQulReg_Click(object sender, System.EventArgs e)
		{
			((clsControlReturnReg)this.objController).m_QulReg();
		}

		private void m_dtgRegister_CurrentCellChanged(object sender, System.EventArgs e)
		{
			SendKeys.Send("+^ ");
		}

		private void m_txtName_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar == (char)13)
			{
				if(this.m_txtCard.Text.Length<10 && this.m_txtCard.Text.Length>0 && ((TextBox)sender).Name == "m_txtCard")
				{
					string strCardID = "";
					strCardID = "0000000000"+this.m_txtCard.Text;
					this.m_txtCard.Text = strCardID.Substring(strCardID.Length-10);
				}
				((clsControlReturnReg)this.objController).m_FindRegCol(sender);
			}
		}

		private void buttonXP1_Click(object sender, System.EventArgs e)
		{
			((clsControlReturnReg)this.objController).m_CancelReg();
		}

		private void m_b_Click(object sender, System.EventArgs e)
		{
			((clsControlReturnReg)this.objController).m_PrintRegister();		
		}

		private void m_txtCard_TextChanged(object sender, System.EventArgs e)
		{
			((TextBox)sender).Text = System.Text.RegularExpressions.Regex.Replace(((TextBox)sender).Text,"%","");	
		}

		private void m_cmbQulType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				((clsControlReturnReg)this.objController).m_Filter();
			}
			catch
			{
			}
		}

		private void m_chkCardID_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.m_radCardID.Checked)
			{
				this.m_txtCard.Focus();
			}
		}

		private void m_chkRegNo_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.m_radRegNo.Checked)
			{
				this.m_txtRegisterNo.Focus();
			}
		}

		private void m_chkPatName_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.m_radPatName.Checked)
			{
				this.m_txtName.Focus();
			}
		}

		private void m_txtCard_Enter(object sender, System.EventArgs e)
		{
			if(!this.m_radCardID.Checked)
			{
				this.m_radCardID.Checked = true;
			}
		}

		private void m_txtRegisterNo_Enter(object sender, System.EventArgs e)
		{
			if(!this.m_radRegNo.Checked)
			{
				this.m_radRegNo.Checked = true;
			}
		}

		private void m_txtName_Enter(object sender, System.EventArgs e)
		{
			if(!this.m_radPatName.Checked)
			{
				this.m_radPatName.Checked = true;
			}
		}	

	}
}
