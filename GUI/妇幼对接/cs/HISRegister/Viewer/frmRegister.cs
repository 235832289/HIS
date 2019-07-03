using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmRegister 的摘要说明。
	/// </summary>
	public class frmRegister :com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		internal com.digitalwave.controls.Control.DateText m_txtAge;
		internal System.Windows.Forms.Panel panel1;
		internal System.Windows.Forms.GroupBox groupBox1;
		#region 定义

		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		internal System.Windows.Forms.GroupBox groupBox2;
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
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtDept;
		internal System.Windows.Forms.Label m_lbStart;
		internal System.Windows.Forms.Label m_lbEnd;
		internal System.Windows.Forms.Label m_lbRoom;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtName;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtDoc;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtRegType;
		internal System.Windows.Forms.ComboBox m_cboSex;
		internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric m_txtAmount;
		internal System.Windows.Forms.ErrorProvider errorProvider1;
		internal PinkieControls.ButtonXP m_btnSave;
		private PinkieControls.ButtonXP m_btnExit;
		private PinkieControls.ButtonXP m_btnClear;
		private System.Windows.Forms.Label m_lbPre;
		internal System.Windows.Forms.StatusBar m_stb;
		internal System.Windows.Forms.ComboBox m_cobSetPrint;
		internal System.Windows.Forms.ListView m_lsvRegDetail;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label10;
		#endregion
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.ColumnHeader columnHeader12;
		internal System.Windows.Forms.CheckBox m_chkNeedNotCard;
		internal System.Windows.Forms.CheckBox m_chkNeedNotfalill;
		internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric m_txtChangeCharge;
		internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric m_txtChangeDisCount;
		internal PinkieControls.ButtonXP m_btnQul;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.ColumnHeader columnHeader13;
		internal System.Windows.Forms.Label m_lblOptimes;
		internal System.Windows.Forms.Panel m_pnlAllPlan;
		internal System.Windows.Forms.ListView m_lsvAllplan;
		internal System.Windows.Forms.ListView m_lsvAllpay;
		internal System.Windows.Forms.ListView m_lsvAlldept;
		internal System.Windows.Forms.ListView m_lsvAlldoc;
		internal System.Windows.Forms.ListView m_lsvAllregtype;
		internal PinkieControls.ButtonXP m_btnReLoadPlan;
		internal System.Windows.Forms.Label m_lblRecount;
		internal PinkieControls.ButtonXP m_btnQulReg;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtRegisterNo;
		internal System.Windows.Forms.DateTimePicker m_dtpBirth;
		internal System.Windows.Forms.Label m_lblRegisterNo;
		internal System.Windows.Forms.CheckBox m_cobModify;
		internal System.Windows.Forms.RadioButton m_radAge;
		internal System.Windows.Forms.RadioButton m_radbirth;
		internal System.Windows.Forms.ComboBox m_paytypename;
		private System.Windows.Forms.Label label13;
		internal PinkieControls.ButtonXP m_btnReturnReg;
		internal System.Windows.Forms.Label m_txtRegFee;
		internal System.Windows.Forms.Label m_txtDiagFee;
		private System.Windows.Forms.Label label19;
		internal System.Windows.Forms.TextBox intAeg;
        private System.Windows.Forms.Label label20;
		internal System.Windows.Forms.TextBox m_txtCardID;
		internal System.Windows.Forms.Label label21;
		private PinkieControls.ButtonXP buttonXP1;
		internal System.Windows.Forms.TextBox txtCheckNO;
		private PinkieControls.ButtonXP buttonXP2;
        private IContainer components;
        internal PrintPreviewDialog m_objPreviewDialog;
        internal System.Drawing.Printing.PrintDocument m_objPrintDocment;
        internal TextBox textBox1;
        public com.digitalwave.controls.clsCardTextBox m_txtCard;
        //		private bool NoChange=false;
		/// <summary>
		/// 是否允许不登记直接挂号
		/// </summary>
		public bool isRegist=false;
		public frmRegister()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			this.m_radAge.Checked = true;
			isRegist=clsMain.m_blGetCollocate("0035");
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegister));
            this.m_lsvAllplan = new System.Windows.Forms.ListView();
            this.m_objPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.m_objPrintDocment = new System.Drawing.Printing.PrintDocument();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonXP2 = new PinkieControls.ButtonXP();
            this.txtCheckNO = new System.Windows.Forms.TextBox();
            this.buttonXP1 = new PinkieControls.ButtonXP();
            this.label20 = new System.Windows.Forms.Label();
            this.m_btnReturnReg = new PinkieControls.ButtonXP();
            this.m_lblRegisterNo = new System.Windows.Forms.Label();
            this.m_txtRegisterNo = new SourceLibrary.Windows.Forms.TextBoxTyped();
            this.m_cobModify = new System.Windows.Forms.CheckBox();
            this.m_btnQulReg = new PinkieControls.ButtonXP();
            this.m_btnReLoadPlan = new PinkieControls.ButtonXP();
            this.m_pnlAllPlan = new System.Windows.Forms.Panel();
            this.m_lsvAllpay = new System.Windows.Forms.ListView();
            this.m_lsvAlldoc = new System.Windows.Forms.ListView();
            this.m_lsvAlldept = new System.Windows.Forms.ListView();
            this.m_lsvAllregtype = new System.Windows.Forms.ListView();
            this.m_btnQul = new PinkieControls.ButtonXP();
            this.m_cobSetPrint = new System.Windows.Forms.ComboBox();
            this.m_btnClear = new PinkieControls.ButtonXP();
            this.m_btnExit = new PinkieControls.ButtonXP();
            this.m_btnSave = new PinkieControls.ButtonXP();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_lvItem = new System.Windows.Forms.ListView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_txtDiagFee = new System.Windows.Forms.Label();
            this.m_txtRegFee = new System.Windows.Forms.Label();
            this.m_chkNeedNotCard = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.m_chkNeedNotfalill = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.m_lsvRegDetail = new System.Windows.Forms.ListView();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.m_txtAmount = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.m_txtChangeCharge = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
            this.m_txtChangeDisCount = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_txtCard = new com.digitalwave.controls.clsCardTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.m_txtAge = new com.digitalwave.controls.Control.DateText();
            this.m_txtCardID = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.intAeg = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txtName = new SourceLibrary.Windows.Forms.TextBoxTyped();
            this.m_cboSex = new System.Windows.Forms.ComboBox();
            this.m_dtpBirth = new System.Windows.Forms.DateTimePicker();
            this.m_radbirth = new System.Windows.Forms.RadioButton();
            this.m_radAge = new System.Windows.Forms.RadioButton();
            this.m_lblOptimes = new System.Windows.Forms.Label();
            this.m_txtPatType = new SourceLibrary.Windows.Forms.TextBoxTyped();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.m_txtDoc = new SourceLibrary.Windows.Forms.TextBoxTyped();
            this.m_lblRecount = new System.Windows.Forms.Label();
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
            this.m_txtRegType = new SourceLibrary.Windows.Forms.TextBoxTyped();
            this.label13 = new System.Windows.Forms.Label();
            this.m_paytypename = new System.Windows.Forms.ComboBox();
            this.m_stb = new System.Windows.Forms.StatusBar();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.m_pnlAllPlan.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
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
            this.m_lsvAllplan.Size = new System.Drawing.Size(232, 216);
            this.m_lsvAllplan.TabIndex = 3;
            this.m_lsvAllplan.TabStop = false;
            this.m_lsvAllplan.UseCompatibleStateImageBehavior = false;
            this.m_lsvAllplan.View = System.Windows.Forms.View.Details;
            this.m_lsvAllplan.SelectedIndexChanged += new System.EventHandler(this.m_lsvAllplan_SelectedIndexChanged);
            this.m_lsvAllplan.Leave += new System.EventHandler(this.m_lsvAllplan_Leave);
            this.m_lsvAllplan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_lvItem_KeyDown_1);
            this.m_lsvAllplan.Click += new System.EventHandler(this.m_lvItem_Click);
            // 
            // m_objPreviewDialog
            // 
            this.m_objPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.m_objPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.m_objPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.m_objPreviewDialog.Document = this.m_objPrintDocment;
            this.m_objPreviewDialog.Enabled = true;
            this.m_objPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("m_objPreviewDialog.Icon")));
            this.m_objPreviewDialog.Name = "m_objPreviewDialog";
            this.m_objPreviewDialog.Visible = false;
            // 
            // m_objPrintDocment
            // 
            this.m_objPrintDocment.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.m_objPrintDocment_PrintPage);
            this.m_objPrintDocment.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.m_objPrintDocment_BeginPrint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonXP2);
            this.panel1.Controls.Add(this.txtCheckNO);
            this.panel1.Controls.Add(this.buttonXP1);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.m_btnReturnReg);
            this.panel1.Controls.Add(this.m_lblRegisterNo);
            this.panel1.Controls.Add(this.m_txtRegisterNo);
            this.panel1.Controls.Add(this.m_cobModify);
            this.panel1.Controls.Add(this.m_btnQulReg);
            this.panel1.Controls.Add(this.m_btnReLoadPlan);
            this.panel1.Controls.Add(this.m_pnlAllPlan);
            this.panel1.Controls.Add(this.m_btnQul);
            this.panel1.Controls.Add(this.m_cobSetPrint);
            this.panel1.Controls.Add(this.m_btnClear);
            this.panel1.Controls.Add(this.m_btnExit);
            this.panel1.Controls.Add(this.m_btnSave);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.m_paytypename);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 587);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // buttonXP2
            // 
            this.buttonXP2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.buttonXP2.DefaultScheme = true;
            this.buttonXP2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP2.Hint = "";
            this.buttonXP2.Location = new System.Drawing.Point(521, 584);
            this.buttonXP2.Name = "buttonXP2";
            this.buttonXP2.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP2.Size = new System.Drawing.Size(108, 24);
            this.buttonXP2.TabIndex = 52;
            this.buttonXP2.Text = "详细资料(F4)";
            this.buttonXP2.Click += new System.EventHandler(this.buttonXP2_Click);
            // 
            // txtCheckNO
            // 
            this.txtCheckNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCheckNO.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCheckNO.Location = new System.Drawing.Point(80, 0);
            this.txtCheckNO.MaxLength = 10;
            this.txtCheckNO.Name = "txtCheckNO";
            this.txtCheckNO.Size = new System.Drawing.Size(88, 23);
            this.txtCheckNO.TabIndex = 51;
            this.txtCheckNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCheckNO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCheckNO_KeyDown_2);
            this.txtCheckNO.Leave += new System.EventHandler(this.txtCheckNO_Leave);
            // 
            // buttonXP1
            // 
            this.buttonXP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.buttonXP1.DefaultScheme = true;
            this.buttonXP1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP1.Hint = "";
            this.buttonXP1.Location = new System.Drawing.Point(404, 584);
            this.buttonXP1.Name = "buttonXP1";
            this.buttonXP1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP1.Size = new System.Drawing.Size(108, 24);
            this.buttonXP1.TabIndex = 50;
            this.buttonXP1.Text = "查找(F11)";
            this.buttonXP1.Click += new System.EventHandler(this.buttonXP1_Click_1);
            // 
            // label20
            // 
            this.label20.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label20.Location = new System.Drawing.Point(5, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(80, 23);
            this.label20.TabIndex = 46;
            this.label20.Text = "当前发票号";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_btnReturnReg
            // 
            this.m_btnReturnReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_btnReturnReg.DefaultScheme = true;
            this.m_btnReturnReg.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnReturnReg.Hint = "";
            this.m_btnReturnReg.Location = new System.Drawing.Point(776, 614);
            this.m_btnReturnReg.Name = "m_btnReturnReg";
            this.m_btnReturnReg.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnReturnReg.Size = new System.Drawing.Size(104, 24);
            this.m_btnReturnReg.TabIndex = 45;
            this.m_btnReturnReg.Text = "退号(F7)";
            this.m_btnReturnReg.Visible = false;
            this.m_btnReturnReg.Click += new System.EventHandler(this.buttonXP1_Click);
            // 
            // m_lblRegisterNo
            // 
            this.m_lblRegisterNo.AutoSize = true;
            this.m_lblRegisterNo.Enabled = false;
            this.m_lblRegisterNo.ForeColor = System.Drawing.SystemColors.Highlight;
            this.m_lblRegisterNo.Location = new System.Drawing.Point(112, -24);
            this.m_lblRegisterNo.Name = "m_lblRegisterNo";
            this.m_lblRegisterNo.Size = new System.Drawing.Size(49, 14);
            this.m_lblRegisterNo.TabIndex = 43;
            this.m_lblRegisterNo.Text = "流水号";
            this.m_lblRegisterNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lblRegisterNo.Visible = false;
            // 
            // m_txtRegisterNo
            // 
            this.m_txtRegisterNo.EnableAutoValidation = false;
            this.m_txtRegisterNo.Enabled = false;
            this.m_txtRegisterNo.EnableEnterKeyValidate = true;
            this.m_txtRegisterNo.EnableEscapeKeyUndo = true;
            this.m_txtRegisterNo.EnableLastValidValue = true;
            this.m_txtRegisterNo.ErrorProvider = null;
            this.m_txtRegisterNo.ErrorProviderMessage = "Invalid value";
            this.m_txtRegisterNo.ForceFormatText = true;
            this.m_txtRegisterNo.Location = new System.Drawing.Point(160, -24);
            this.m_txtRegisterNo.MaxLength = 13;
            this.m_txtRegisterNo.Name = "m_txtRegisterNo";
            this.m_txtRegisterNo.Size = new System.Drawing.Size(157, 23);
            this.m_txtRegisterNo.TabIndex = 42;
            this.m_txtRegisterNo.Visible = false;
            this.m_txtRegisterNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtRegisterNo_KeyPress);
            // 
            // m_cobModify
            // 
            this.m_cobModify.Enabled = false;
            this.m_cobModify.ForeColor = System.Drawing.SystemColors.Highlight;
            this.m_cobModify.Location = new System.Drawing.Point(8, -24);
            this.m_cobModify.Name = "m_cobModify";
            this.m_cobModify.Size = new System.Drawing.Size(83, 24);
            this.m_cobModify.TabIndex = 44;
            this.m_cobModify.Text = "修改(&G)";
            this.m_cobModify.Visible = false;
            this.m_cobModify.CheckedChanged += new System.EventHandler(this.m_cobModify_CheckedChanged);
            // 
            // m_btnQulReg
            // 
            this.m_btnQulReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_btnQulReg.DefaultScheme = true;
            this.m_btnQulReg.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnQulReg.Hint = "";
            this.m_btnQulReg.Location = new System.Drawing.Point(776, 56);
            this.m_btnQulReg.Name = "m_btnQulReg";
            this.m_btnQulReg.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnQulReg.Size = new System.Drawing.Size(122, 24);
            this.m_btnQulReg.TabIndex = 41;
            this.m_btnQulReg.Text = "查询当天挂号";
            this.m_btnQulReg.Visible = false;
            // 
            // m_btnReLoadPlan
            // 
            this.m_btnReLoadPlan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_btnReLoadPlan.DefaultScheme = true;
            this.m_btnReLoadPlan.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnReLoadPlan.Hint = "";
            this.m_btnReLoadPlan.Location = new System.Drawing.Point(638, 584);
            this.m_btnReLoadPlan.Name = "m_btnReLoadPlan";
            this.m_btnReLoadPlan.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnReLoadPlan.Size = new System.Drawing.Size(108, 24);
            this.m_btnReLoadPlan.TabIndex = 6;
            this.m_btnReLoadPlan.Text = "刷新排班(F5)";
            this.m_btnReLoadPlan.Click += new System.EventHandler(this.m_btnReLoadPlan_Click);
            // 
            // m_pnlAllPlan
            // 
            this.m_pnlAllPlan.Controls.Add(this.m_lsvAllpay);
            this.m_pnlAllPlan.Controls.Add(this.m_lsvAlldoc);
            this.m_pnlAllPlan.Controls.Add(this.m_lsvAlldept);
            this.m_pnlAllPlan.Controls.Add(this.m_lsvAllregtype);
            this.m_pnlAllPlan.Location = new System.Drawing.Point(528, 152);
            this.m_pnlAllPlan.Name = "m_pnlAllPlan";
            this.m_pnlAllPlan.Size = new System.Drawing.Size(232, 216);
            this.m_pnlAllPlan.TabIndex = 38;
            this.m_pnlAllPlan.Visible = false;
            // 
            // m_lsvAllpay
            // 
            this.m_lsvAllpay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvAllpay.FullRowSelect = true;
            this.m_lsvAllpay.GridLines = true;
            this.m_lsvAllpay.HideSelection = false;
            this.m_lsvAllpay.Location = new System.Drawing.Point(0, 0);
            this.m_lsvAllpay.MultiSelect = false;
            this.m_lsvAllpay.Name = "m_lsvAllpay";
            this.m_lsvAllpay.Size = new System.Drawing.Size(232, 216);
            this.m_lsvAllpay.TabIndex = 3;
            this.m_lsvAllpay.TabStop = false;
            this.m_lsvAllpay.UseCompatibleStateImageBehavior = false;
            this.m_lsvAllpay.View = System.Windows.Forms.View.Details;
            this.m_lsvAllpay.SelectedIndexChanged += new System.EventHandler(this.m_lsvAllplan_SelectedIndexChanged);
            this.m_lsvAllpay.Leave += new System.EventHandler(this.m_lsvAllplan_Leave);
            this.m_lsvAllpay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_lvItem_KeyDown_1);
            this.m_lsvAllpay.Click += new System.EventHandler(this.m_lvItem_Click);
            // 
            // m_lsvAlldoc
            // 
            this.m_lsvAlldoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvAlldoc.FullRowSelect = true;
            this.m_lsvAlldoc.GridLines = true;
            this.m_lsvAlldoc.HideSelection = false;
            this.m_lsvAlldoc.Location = new System.Drawing.Point(0, 0);
            this.m_lsvAlldoc.MultiSelect = false;
            this.m_lsvAlldoc.Name = "m_lsvAlldoc";
            this.m_lsvAlldoc.Size = new System.Drawing.Size(232, 216);
            this.m_lsvAlldoc.TabIndex = 3;
            this.m_lsvAlldoc.TabStop = false;
            this.m_lsvAlldoc.UseCompatibleStateImageBehavior = false;
            this.m_lsvAlldoc.View = System.Windows.Forms.View.Details;
            this.m_lsvAlldoc.SelectedIndexChanged += new System.EventHandler(this.m_lsvAllplan_SelectedIndexChanged);
            this.m_lsvAlldoc.Leave += new System.EventHandler(this.m_lsvAllplan_Leave);
            this.m_lsvAlldoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_lvItem_KeyDown_1);
            this.m_lsvAlldoc.Click += new System.EventHandler(this.m_lvItem_Click);
            // 
            // m_lsvAlldept
            // 
            this.m_lsvAlldept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvAlldept.FullRowSelect = true;
            this.m_lsvAlldept.GridLines = true;
            this.m_lsvAlldept.HideSelection = false;
            this.m_lsvAlldept.Location = new System.Drawing.Point(0, 0);
            this.m_lsvAlldept.MultiSelect = false;
            this.m_lsvAlldept.Name = "m_lsvAlldept";
            this.m_lsvAlldept.Size = new System.Drawing.Size(232, 216);
            this.m_lsvAlldept.TabIndex = 3;
            this.m_lsvAlldept.TabStop = false;
            this.m_lsvAlldept.UseCompatibleStateImageBehavior = false;
            this.m_lsvAlldept.View = System.Windows.Forms.View.Details;
            this.m_lsvAlldept.SelectedIndexChanged += new System.EventHandler(this.m_lsvAllplan_SelectedIndexChanged);
            this.m_lsvAlldept.Leave += new System.EventHandler(this.m_lsvAllplan_Leave);
            this.m_lsvAlldept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_lvItem_KeyDown_1);
            this.m_lsvAlldept.Click += new System.EventHandler(this.m_lvItem_Click);
            // 
            // m_lsvAllregtype
            // 
            this.m_lsvAllregtype.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvAllregtype.FullRowSelect = true;
            this.m_lsvAllregtype.GridLines = true;
            this.m_lsvAllregtype.HideSelection = false;
            this.m_lsvAllregtype.Location = new System.Drawing.Point(0, 0);
            this.m_lsvAllregtype.MultiSelect = false;
            this.m_lsvAllregtype.Name = "m_lsvAllregtype";
            this.m_lsvAllregtype.Size = new System.Drawing.Size(232, 216);
            this.m_lsvAllregtype.TabIndex = 3;
            this.m_lsvAllregtype.TabStop = false;
            this.m_lsvAllregtype.UseCompatibleStateImageBehavior = false;
            this.m_lsvAllregtype.View = System.Windows.Forms.View.Details;
            this.m_lsvAllregtype.SelectedIndexChanged += new System.EventHandler(this.m_lsvAllplan_SelectedIndexChanged);
            this.m_lsvAllregtype.Leave += new System.EventHandler(this.m_lsvAllplan_Leave);
            this.m_lsvAllregtype.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_lvItem_KeyDown_1);
            this.m_lsvAllregtype.Click += new System.EventHandler(this.m_lvItem_Click);
            // 
            // m_btnQul
            // 
            this.m_btnQul.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_btnQul.DefaultScheme = true;
            this.m_btnQul.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnQul.Hint = "";
            this.m_btnQul.Location = new System.Drawing.Point(755, 584);
            this.m_btnQul.Name = "m_btnQul";
            this.m_btnQul.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnQul.Size = new System.Drawing.Size(108, 24);
            this.m_btnQul.TabIndex = 37;
            this.m_btnQul.Text = "查询(F6)";
            this.m_btnQul.Click += new System.EventHandler(this.m_btnQul_Click);
            // 
            // m_cobSetPrint
            // 
            this.m_cobSetPrint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cobSetPrint.Items.AddRange(new object[] {
            "挂号确认后打印",
            "挂号确认后预览",
            "挂号确认后不打印"});
            this.m_cobSetPrint.Location = new System.Drawing.Point(24, 584);
            this.m_cobSetPrint.Name = "m_cobSetPrint";
            this.m_cobSetPrint.Size = new System.Drawing.Size(144, 22);
            this.m_cobSetPrint.TabIndex = 36;
            // 
            // m_btnClear
            // 
            this.m_btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_btnClear.DefaultScheme = true;
            this.m_btnClear.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnClear.Hint = "";
            this.m_btnClear.Location = new System.Drawing.Point(287, 584);
            this.m_btnClear.Name = "m_btnClear";
            this.m_btnClear.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnClear.Size = new System.Drawing.Size(108, 24);
            this.m_btnClear.TabIndex = 4;
            this.m_btnClear.Text = "清空(F3)";
            this.m_btnClear.Click += new System.EventHandler(this.m_btnClear_Click);
            // 
            // m_btnExit
            // 
            this.m_btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_btnExit.DefaultScheme = true;
            this.m_btnExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnExit.Hint = "";
            this.m_btnExit.Location = new System.Drawing.Point(872, 584);
            this.m_btnExit.Name = "m_btnExit";
            this.m_btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnExit.Size = new System.Drawing.Size(108, 24);
            this.m_btnExit.TabIndex = 5;
            this.m_btnExit.Text = "退出(Esc)";
            this.m_btnExit.Click += new System.EventHandler(this.m_btnExit_Click);
            // 
            // m_btnSave
            // 
            this.m_btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_btnSave.DefaultScheme = true;
            this.m_btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnSave.Hint = "";
            this.m_btnSave.Location = new System.Drawing.Point(170, 584);
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnSave.Size = new System.Drawing.Size(108, 24);
            this.m_btnSave.TabIndex = 3;
            this.m_btnSave.Text = "挂号确认(F2)";
            this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.m_lvItem);
            this.panel2.Location = new System.Drawing.Point(448, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(528, 575);
            this.panel2.TabIndex = 24;
            // 
            // m_lvItem
            // 
            this.m_lvItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lvItem.FullRowSelect = true;
            this.m_lvItem.GridLines = true;
            this.m_lvItem.Location = new System.Drawing.Point(0, 0);
            this.m_lvItem.MultiSelect = false;
            this.m_lvItem.Name = "m_lvItem";
            this.m_lvItem.Size = new System.Drawing.Size(528, 575);
            this.m_lvItem.TabIndex = 200;
            this.m_lvItem.TabStop = false;
            this.m_lvItem.UseCompatibleStateImageBehavior = false;
            this.m_lvItem.View = System.Windows.Forms.View.Details;
            this.m_lvItem.SelectedIndexChanged += new System.EventHandler(this.m_lvItem_SelectedIndexChanged);
            this.m_lvItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_lvItem_KeyPress);
            this.m_lvItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_lvItem_KeyDown_2);
            this.m_lvItem.Click += new System.EventHandler(this.m_lvItem_Click_1);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.m_txtDiagFee);
            this.groupBox3.Controls.Add(this.m_txtRegFee);
            this.groupBox3.Controls.Add(this.m_chkNeedNotCard);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.m_chkNeedNotfalill);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.m_lsvRegDetail);
            this.groupBox3.Controls.Add(this.m_txtAmount);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.m_txtChangeCharge);
            this.groupBox3.Controls.Add(this.m_txtChangeDisCount);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox3.Location = new System.Drawing.Point(8, 344);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(432, 232);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "费用信息";
            // 
            // m_txtDiagFee
            // 
            this.m_txtDiagFee.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.m_txtDiagFee.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_txtDiagFee.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDiagFee.ForeColor = System.Drawing.Color.Brown;
            this.m_txtDiagFee.Location = new System.Drawing.Point(320, 156);
            this.m_txtDiagFee.Name = "m_txtDiagFee";
            this.m_txtDiagFee.Size = new System.Drawing.Size(104, 32);
            this.m_txtDiagFee.TabIndex = 39;
            this.m_txtDiagFee.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtRegFee
            // 
            this.m_txtRegFee.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.m_txtRegFee.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_txtRegFee.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtRegFee.ForeColor = System.Drawing.Color.Brown;
            this.m_txtRegFee.Location = new System.Drawing.Point(88, 156);
            this.m_txtRegFee.Name = "m_txtRegFee";
            this.m_txtRegFee.Size = new System.Drawing.Size(136, 32);
            this.m_txtRegFee.TabIndex = 38;
            this.m_txtRegFee.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_chkNeedNotCard
            // 
            this.m_chkNeedNotCard.Checked = true;
            this.m_chkNeedNotCard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkNeedNotCard.Location = new System.Drawing.Point(120, 127);
            this.m_chkNeedNotCard.Name = "m_chkNeedNotCard";
            this.m_chkNeedNotCard.Size = new System.Drawing.Size(115, 24);
            this.m_chkNeedNotCard.TabIndex = 36;
            this.m_chkNeedNotCard.TabStop = false;
            this.m_chkNeedNotCard.Text = "不需发卡(&Q)";
            this.m_chkNeedNotCard.CheckedChanged += new System.EventHandler(this.m_chkNotofalill_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(392, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 14);
            this.label8.TabIndex = 33;
            this.label8.Text = "金额";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label8.Visible = false;
            // 
            // m_chkNeedNotfalill
            // 
            this.m_chkNeedNotfalill.Checked = true;
            this.m_chkNeedNotfalill.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkNeedNotfalill.Location = new System.Drawing.Point(9, 127);
            this.m_chkNeedNotfalill.Name = "m_chkNeedNotfalill";
            this.m_chkNeedNotfalill.Size = new System.Drawing.Size(112, 24);
            this.m_chkNeedNotfalill.TabIndex = 35;
            this.m_chkNeedNotfalill.TabStop = false;
            this.m_chkNeedNotfalill.Text = "不需病历(&S)";
            this.m_chkNeedNotfalill.CheckedChanged += new System.EventHandler(this.m_chkNotofalill_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(392, 164);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 14);
            this.label10.TabIndex = 34;
            this.label10.Text = "优惠";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.Visible = false;
            // 
            // m_lsvRegDetail
            // 
            this.m_lsvRegDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13});
            this.m_lsvRegDetail.FullRowSelect = true;
            this.m_lsvRegDetail.GridLines = true;
            this.m_lsvRegDetail.HideSelection = false;
            this.m_lsvRegDetail.Location = new System.Drawing.Point(8, 15);
            this.m_lsvRegDetail.Name = "m_lsvRegDetail";
            this.m_lsvRegDetail.Size = new System.Drawing.Size(416, 104);
            this.m_lsvRegDetail.TabIndex = 29;
            this.m_lsvRegDetail.UseCompatibleStateImageBehavior = false;
            this.m_lsvRegDetail.View = System.Windows.Forms.View.Details;
            this.m_lsvRegDetail.SelectedIndexChanged += new System.EventHandler(this.m_lsvRegDetail_SelectedIndexChanged);
            this.m_lsvRegDetail.Click += new System.EventHandler(this.m_lsvRegDetail_Click);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "挂号编号";
            this.columnHeader7.Width = 0;
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
            this.columnHeader12.Text = "收费比例";
            this.columnHeader12.Width = 100;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "备注";
            this.columnHeader13.Width = 94;
            // 
            // m_txtAmount
            // 
            this.m_txtAmount.EnableAutoValidation = true;
            this.m_txtAmount.EnableEnterKeyValidate = true;
            this.m_txtAmount.EnableEscapeKeyUndo = true;
            this.m_txtAmount.EnableLastValidValue = true;
            this.m_txtAmount.ErrorProvider = null;
            this.m_txtAmount.ErrorProviderMessage = "Invalid value";
            this.m_txtAmount.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtAmount.ForceFormatText = true;
            this.m_txtAmount.ForeColor = System.Drawing.Color.Brown;
            this.m_txtAmount.Location = new System.Drawing.Point(89, 196);
            this.m_txtAmount.MaxLength = 15;
            this.m_txtAmount.Name = "m_txtAmount";
            this.m_txtAmount.NumericCharStyle = SourceLibrary.Windows.Forms.NumericCharStyle.DecimalSeparator;
            this.m_txtAmount.Size = new System.Drawing.Size(335, 26);
            this.m_txtAmount.TabIndex = 0;
            this.m_txtAmount.Text = "textBoxTypedNumeric3";
            this.m_txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtAmount.TextChanged += new System.EventHandler(this.m_txtAmount_TextChanged);
            this.m_txtAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtAmount_KeyDown);
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(4, 201);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(94, 19);
            this.label17.TabIndex = 28;
            this.label17.Text = "实收金额:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(230, 164);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(96, 19);
            this.label15.TabIndex = 27;
            this.label15.Text = "找余金额：";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(6, 160);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(90, 23);
            this.label16.TabIndex = 25;
            this.label16.Text = "共计金额：";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.m_txtChangeCharge.Location = new System.Drawing.Point(432, 174);
            this.m_txtChangeCharge.Name = "m_txtChangeCharge";
            this.m_txtChangeCharge.NumericCharStyle = SourceLibrary.Windows.Forms.NumericCharStyle.DecimalSeparator;
            this.m_txtChangeCharge.Size = new System.Drawing.Size(96, 23);
            this.m_txtChangeCharge.TabIndex = 10;
            this.m_txtChangeCharge.Text = "0";
            this.m_txtChangeCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtChangeCharge.Visible = false;
            this.m_txtChangeCharge.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtChangeDisCount_KeyDown);
            this.m_txtChangeCharge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtChangeCharge_KeyPress);
            this.m_txtChangeCharge.Validating += new System.ComponentModel.CancelEventHandler(this.m_txtChangeCharge_Validating);
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
            this.m_txtChangeDisCount.Location = new System.Drawing.Point(432, 204);
            this.m_txtChangeDisCount.Name = "m_txtChangeDisCount";
            this.m_txtChangeDisCount.NumericCharStyle = SourceLibrary.Windows.Forms.NumericCharStyle.DecimalSeparator;
            this.m_txtChangeDisCount.Size = new System.Drawing.Size(96, 23);
            this.m_txtChangeDisCount.TabIndex = 10;
            this.m_txtChangeDisCount.Text = "0";
            this.m_txtChangeDisCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtChangeDisCount.Visible = false;
            this.m_txtChangeDisCount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtChangeDisCount_KeyDown);
            this.m_txtChangeDisCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtChangeDisCount_KeyPress);
            this.m_txtChangeDisCount.Validating += new System.ComponentModel.CancelEventHandler(this.m_txtChangeCharge_Validating);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(408, 132);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(144, 40);
            this.label11.TabIndex = 37;
            this.label11.Text = "按F12将当前费别的金额优惠比例置零";
            this.label11.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_txtCard);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.m_txtAge);
            this.groupBox1.Controls.Add(this.m_txtCardID);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.intAeg);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.m_txtName);
            this.groupBox1.Controls.Add(this.m_cboSex);
            this.groupBox1.Controls.Add(this.m_dtpBirth);
            this.groupBox1.Controls.Add(this.m_radbirth);
            this.groupBox1.Controls.Add(this.m_radAge);
            this.groupBox1.Controls.Add(this.m_lblOptimes);
            this.groupBox1.Controls.Add(this.m_txtPatType);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox1.Location = new System.Drawing.Point(8, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(432, 128);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "病人基本信息";
            // 
            // m_txtCard
            // 
            this.m_txtCard.Location = new System.Drawing.Point(66, 24);
            this.m_txtCard.MaxLength = 18;
            this.m_txtCard.Name = "m_txtCard";
            this.m_txtCard.PatientCard = "";
            this.m_txtCard.Size = new System.Drawing.Size(88, 23);
            this.m_txtCard.TabIndex = 34;
            this.m_txtCard.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtCard.YBCardText = "";
            this.m_txtCard.CardLeave += new com.digitalwave.controls.clsCardTextBox.TxtLeaveHandle(this.m_txtCard1_CardLeave);
            this.m_txtCard.CardKeyDown += new com.digitalwave.controls.clsCardTextBox.TxtKeyDownHandle(this.m_txtCard1_CardKeyDown);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(192, 94);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 33;
            this.textBox1.Visible = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // m_txtAge
            // 
            this.m_txtAge.Location = new System.Drawing.Point(192, 93);
            this.m_txtAge.MaxLength = 2;
            this.m_txtAge.Name = "m_txtAge";
            this.m_txtAge.Size = new System.Drawing.Size(101, 23);
            this.m_txtAge.TabIndex = 4;
            this.m_txtAge.Text = "12.7.14";
            this.m_txtAge.Value = new System.DateTime(2000, 9, 5, 16, 33, 41, 494);
            this.m_txtAge.TextChanged += new System.EventHandler(this.m_txtAge_TextChanged);
            this.m_txtAge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtAge_KeyPress);
            // 
            // m_txtCardID
            // 
            this.m_txtCardID.Enabled = false;
            this.m_txtCardID.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.m_txtCardID.Location = new System.Drawing.Point(205, 58);
            this.m_txtCardID.MaxLength = 20;
            this.m_txtCardID.Name = "m_txtCardID";
            this.m_txtCardID.Size = new System.Drawing.Size(219, 23);
            this.m_txtCardID.TabIndex = 4;
            this.m_txtCardID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtCardID_KeyDown);
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(158, 60);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(48, 19);
            this.label21.TabIndex = 32;
            this.label21.Text = "普通";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // intAeg
            // 
            this.intAeg.Location = new System.Drawing.Point(192, 93);
            this.intAeg.MaxLength = 2;
            this.intAeg.Name = "intAeg";
            this.intAeg.Size = new System.Drawing.Size(101, 23);
            this.intAeg.TabIndex = 30;
            this.intAeg.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(432, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 22;
            this.label4.Text = "出生年月";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Visible = false;
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
            this.m_txtName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtName.Location = new System.Drawing.Point(205, 24);
            this.m_txtName.MaxLength = 20;
            this.m_txtName.Name = "m_txtName";
            this.m_txtName.Size = new System.Drawing.Size(86, 23);
            this.m_txtName.TabIndex = 1;
            this.m_txtName.Text = "textBoxTyped2";
            this.m_txtName.TextChanged += new System.EventHandler(this.m_txtName_TextChanged);
            this.m_txtName.Validated += new System.EventHandler(this.m_txtName_Validated);
            this.m_txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtName_KeyDown);
            this.m_txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtPatType_KeyPress);
            // 
            // m_cboSex
            // 
            this.m_cboSex.Location = new System.Drawing.Point(336, 24);
            this.m_cboSex.Name = "m_cboSex";
            this.m_cboSex.Size = new System.Drawing.Size(86, 22);
            this.m_cboSex.TabIndex = 2;
            this.m_cboSex.Text = "comboBox2";
            this.m_cboSex.SelectedIndexChanged += new System.EventHandler(this.m_cboSex_SelectedIndexChanged);
            this.m_cboSex.Enter += new System.EventHandler(this.m_cboSex_Enter);
            this.m_cboSex.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtPatType_KeyPress);
            this.m_cboSex.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cboSex_KeyDown);
            // 
            // m_dtpBirth
            // 
            this.m_dtpBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.m_dtpBirth.Location = new System.Drawing.Point(192, 93);
            this.m_dtpBirth.Name = "m_dtpBirth";
            this.m_dtpBirth.Size = new System.Drawing.Size(101, 23);
            this.m_dtpBirth.TabIndex = 5;
            this.m_dtpBirth.Visible = false;
            this.m_dtpBirth.ValueChanged += new System.EventHandler(this.m_dtpBirth_ValueChanged);
            this.m_dtpBirth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_dtpBirth_KeyPress);
            // 
            // m_radbirth
            // 
            this.m_radbirth.Location = new System.Drawing.Point(85, 94);
            this.m_radbirth.Name = "m_radbirth";
            this.m_radbirth.Size = new System.Drawing.Size(115, 24);
            this.m_radbirth.TabIndex = 27;
            this.m_radbirth.Text = "出生年月(&A)";
            this.m_radbirth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_radAge_KeyPress);
            this.m_radbirth.CheckedChanged += new System.EventHandler(this.m_radbirth_CheckedChanged);
            // 
            // m_radAge
            // 
            this.m_radAge.Location = new System.Drawing.Point(7, 93);
            this.m_radAge.Name = "m_radAge";
            this.m_radAge.Size = new System.Drawing.Size(81, 24);
            this.m_radAge.TabIndex = 26;
            this.m_radAge.Text = "岁数(&A)";
            this.m_radAge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_radAge_KeyPress);
            this.m_radAge.CheckedChanged += new System.EventHandler(this.m_radbirth_CheckedChanged);
            // 
            // m_lblOptimes
            // 
            this.m_lblOptimes.Location = new System.Drawing.Point(312, 88);
            this.m_lblOptimes.Name = "m_lblOptimes";
            this.m_lblOptimes.Size = new System.Drawing.Size(112, 32);
            this.m_lblOptimes.TabIndex = 25;
            this.m_lblOptimes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.m_txtPatType.Location = new System.Drawing.Point(66, 58);
            this.m_txtPatType.Name = "m_txtPatType";
            this.m_txtPatType.Size = new System.Drawing.Size(86, 23);
            this.m_txtPatType.TabIndex = 3;
            this.m_txtPatType.Text = "textBoxTyped5";
            this.m_txtPatType.TextChanged += new System.EventHandler(this.m_txtPatType_TextChanged);
            this.m_txtPatType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtPatType_KeyDown);
            this.m_txtPatType.Leave += new System.EventHandler(this.m_txtRegType_Leave);
            this.m_txtPatType.Enter += new System.EventHandler(this.m_txtPatType_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 24;
            this.label5.Text = "病人类别";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 19;
            this.label2.Text = "姓名";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 15;
            this.label1.Text = "诊疗卡号";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(304, 26);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 14);
            this.label18.TabIndex = 20;
            this.label18.Text = "性别";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.m_txtDoc);
            this.groupBox2.Controls.Add(this.m_lblRecount);
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
            this.groupBox2.Controls.Add(this.m_txtRegType);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox2.Location = new System.Drawing.Point(8, 152);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(432, 183);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "挂号信息";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Enabled = false;
            this.label19.Location = new System.Drawing.Point(252, 26);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(49, 14);
            this.label19.TabIndex = 37;
            this.label19.Text = "时间段";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.m_txtDoc.Location = new System.Drawing.Point(302, 86);
            this.m_txtDoc.Name = "m_txtDoc";
            this.m_txtDoc.Size = new System.Drawing.Size(122, 23);
            this.m_txtDoc.TabIndex = 2;
            this.m_txtDoc.Text = "textBoxTyped8";
            this.m_txtDoc.TextChanged += new System.EventHandler(this.m_txtPatType_TextChanged);
            this.m_txtDoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtDoc_KeyDown);
            this.m_txtDoc.Leave += new System.EventHandler(this.m_txtRegType_Leave);
            this.m_txtDoc.Enter += new System.EventHandler(this.m_txtDoc_Enter);
            // 
            // m_lblRecount
            // 
            this.m_lblRecount.ForeColor = System.Drawing.Color.Red;
            this.m_lblRecount.Location = new System.Drawing.Point(232, 54);
            this.m_lblRecount.Name = "m_lblRecount";
            this.m_lblRecount.Size = new System.Drawing.Size(192, 32);
            this.m_lblRecount.TabIndex = 36;
            this.m_lblRecount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_cboSeg
            // 
            this.m_cboSeg.Enabled = false;
            this.m_cboSeg.Location = new System.Drawing.Point(304, 23);
            this.m_cboSeg.Name = "m_cboSeg";
            this.m_cboSeg.Size = new System.Drawing.Size(120, 22);
            this.m_cboSeg.TabIndex = 35;
            this.m_cboSeg.Text = "comboBox1";
            this.m_cboSeg.SelectedIndexChanged += new System.EventHandler(this.m_cboSeg_SelectedIndexChanged);
            this.m_cboSeg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cboSeg_KeyDown);
            // 
            // m_dtpPreTime
            // 
            this.m_dtpPreTime.Enabled = false;
            this.m_dtpPreTime.Location = new System.Drawing.Point(80, 23);
            this.m_dtpPreTime.Name = "m_dtpPreTime";
            this.m_dtpPreTime.Size = new System.Drawing.Size(144, 23);
            this.m_dtpPreTime.TabIndex = 34;
            this.m_dtpPreTime.ValueChanged += new System.EventHandler(this.m_dtpPreTime_ValueChanged);
            this.m_dtpPreTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_dtpPreTime_KeyPress);
            this.m_dtpPreTime.CloseUp += new System.EventHandler(this.m_dtpPreTime_CloseUp);
            // 
            // m_lbPre
            // 
            this.m_lbPre.AutoSize = true;
            this.m_lbPre.Enabled = false;
            this.m_lbPre.Location = new System.Drawing.Point(32, 25);
            this.m_lbPre.Name = "m_lbPre";
            this.m_lbPre.Size = new System.Drawing.Size(49, 14);
            this.m_lbPre.TabIndex = 33;
            this.m_lbPre.Text = "预约F9";
            this.m_lbPre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_chkPre
            // 
            this.m_chkPre.Location = new System.Drawing.Point(13, 22);
            this.m_chkPre.Name = "m_chkPre";
            this.m_chkPre.Size = new System.Drawing.Size(56, 24);
            this.m_chkPre.TabIndex = 32;
            this.m_chkPre.TabStop = false;
            this.m_chkPre.CheckedChanged += new System.EventHandler(this.m_chkPre_CheckedChanged);
            // 
            // m_lbRoom
            // 
            this.m_lbRoom.BackColor = System.Drawing.SystemColors.Window;
            this.m_lbRoom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lbRoom.Location = new System.Drawing.Point(83, 148);
            this.m_lbRoom.Name = "m_lbRoom";
            this.m_lbRoom.Size = new System.Drawing.Size(341, 23);
            this.m_lbRoom.TabIndex = 31;
            this.m_lbRoom.Text = "label13";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 150);
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
            this.m_lbEnd.Location = new System.Drawing.Point(304, 116);
            this.m_lbEnd.Name = "m_lbEnd";
            this.m_lbEnd.Size = new System.Drawing.Size(120, 23);
            this.m_lbEnd.TabIndex = 29;
            this.m_lbEnd.Text = "label11";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(240, 118);
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
            this.m_lbStart.Location = new System.Drawing.Point(82, 116);
            this.m_lbStart.Name = "m_lbStart";
            this.m_lbStart.Size = new System.Drawing.Size(142, 23);
            this.m_lbStart.TabIndex = 27;
            this.m_lbStart.Text = "label10";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 118);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 14);
            this.label9.TabIndex = 26;
            this.label9.Text = "开诊时间";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 23;
            this.label7.Text = "挂号类型";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 58);
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
            this.m_txtDept.Location = new System.Drawing.Point(81, 56);
            this.m_txtDept.Name = "m_txtDept";
            this.m_txtDept.Size = new System.Drawing.Size(143, 23);
            this.m_txtDept.TabIndex = 0;
            this.m_txtDept.Text = "textBoxTyped6";
            this.m_txtDept.TextChanged += new System.EventHandler(this.m_txtPatType_TextChanged);
            this.m_txtDept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtDept_KeyDown);
            this.m_txtDept.Leave += new System.EventHandler(this.m_txtRegType_Leave);
            this.m_txtDept.Enter += new System.EventHandler(this.m_txtDept_Enter);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(240, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 19);
            this.label3.TabIndex = 25;
            this.label3.Text = "接诊医生";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.m_txtRegType.Location = new System.Drawing.Point(81, 86);
            this.m_txtRegType.Name = "m_txtRegType";
            this.m_txtRegType.Size = new System.Drawing.Size(143, 23);
            this.m_txtRegType.TabIndex = 1;
            this.m_txtRegType.Text = "textBoxTyped7";
            this.m_txtRegType.TextChanged += new System.EventHandler(this.m_txtPatType_TextChanged);
            this.m_txtRegType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtRegType_KeyDown);
            this.m_txtRegType.Leave += new System.EventHandler(this.m_txtRegType_Leave);
            this.m_txtRegType.Enter += new System.EventHandler(this.m_txtRegType_Enter);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label13.Location = new System.Drawing.Point(184, 2);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 14);
            this.label13.TabIndex = 29;
            this.label13.Text = "支付方式";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_paytypename
            // 
            this.m_paytypename.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_paytypename.Enabled = false;
            this.m_paytypename.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.m_paytypename.Items.AddRange(new object[] {
            "现金",
            "记帐",
            "支票"});
            this.m_paytypename.Location = new System.Drawing.Point(256, 0);
            this.m_paytypename.Name = "m_paytypename";
            this.m_paytypename.Size = new System.Drawing.Size(80, 22);
            this.m_paytypename.TabIndex = 28;
            this.m_paytypename.TabStop = false;
            this.m_paytypename.SelectedIndexChanged += new System.EventHandler(this.m_paytypename_SelectedIndexChanged);
            // 
            // m_stb
            // 
            this.m_stb.Location = new System.Drawing.Point(0, 587);
            this.m_stb.Name = "m_stb";
            this.m_stb.Size = new System.Drawing.Size(984, 22);
            this.m_stb.TabIndex = 2;
            this.m_stb.Text = "挂号 F1-修改发票号  F2-挂号确认 F3-清空 F4-调出病人登记窗口  F5-刷新排班 F6查询 F7-退号 ESC-退出 F9-预约 F10-输入金额 " +
                "→-选择排班 ←-返回焦点";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmRegister
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(984, 609);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_stb);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmRegister";
            this.Text = "门诊挂号";
            this.Deactivate += new System.EventHandler(this.frmRegister_Deactivate);
            this.Load += new System.EventHandler(this.frmRegister_Load);
            this.Activated += new System.EventHandler(this.frmRegister_Activated);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmRegister_Closing);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmRegister_KeyPress);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRegister_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.m_pnlAllPlan.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
		public override void CreateController()
		{
			this.objController=new com.digitalwave.iCare.gui.HIS.clsControlRegister();
			objController.Set_GUI_Apperance(this);
		}
        private bool CardNo11Flag = false;
        StatusBar objBar=null;
		private void frmRegister_Load(object sender, System.EventArgs e)
		{	
			if(!isRegist)
			{
				m_txtName.Enabled=false;
				m_cboSex.Enabled=false;
				m_txtAge.Enabled=false;
				m_txtPatType.Enabled=false;
				m_radAge.Enabled=false;
				m_radbirth.Enabled=false;
			}
			System.Windows.Forms.Form objParentForm= this.MdiParent;
			foreach(System.Windows.Forms.Control c in objParentForm.Controls)
			{
				if(c is StatusBar)
				{
					objBar =(StatusBar)c;
				}
			}
			objBar.Panels[2].Width-=20;
			m_mthSetFormControlCanBeNull(this);
			((clsControlRegister)this.objController).m_FillComboBox();
			((clsControlRegister)this.objController).m_Clear(sender);
			((clsControlRegister)this.objController).m_CheckPlan();
			((clsControlRegister)this.objController).m_GetPay();
			((clsControlRegister)this.objController).m_FillDoctorPlan();
            ((clsControlRegister)this.objController).m_mthGetAvailDays();

			clsDomainControl_Register Domain=new clsDomainControl_Register();
			int statusint;
			long lngRes=Domain.m_lngPrint("0002",out statusint);
			if(lngRes==1&&statusint!=-2)
			{
				if(statusint==0)
					this.m_cobSetPrint.SelectedIndex = 0;
				else
					this.m_cobSetPrint.SelectedIndex = 2;
			}

          //  clsPublic.CardNo11Init(((clsControlRegister)this.objController).m_objComInfo.m_strGetHospitalTitle(), this.m_txtCard, ref this.CardNo11Flag);

			((clsControlRegister)this.objController).m_lngReadXML();
			MessageBox.Show("请检查发票号是否正确！","Icare",MessageBoxButtons.OK,MessageBoxIcon.Warning);
			
		}

		private void m_chkPre_CheckedChanged(object sender, System.EventArgs e)
		{
			if(m_chkPre.Checked==true)
			{
				this.m_dtpPreTime.Enabled = true;
				((clsControlRegister)this.objController).m_FillDoctorPlan();
				this.m_cboSeg.Enabled = true;
				m_lbPre.Enabled = true;
				m_dtpPreTime.Focus();
			}
			else
			{
				((clsControlRegister)this.objController).m_FillDoctorPlan();
				this.m_dtpPreTime.Enabled = false;
				this.m_cboSeg.Enabled = false;
				m_lbPre.Enabled = false;
			}
		}

		private void m_dtpPreTime_ValueChanged(object sender, System.EventArgs e)
		{
			bool bnlCheck=((clsControlRegister)this.objController).bnlCheckDate();
			if(!bnlCheck)
			{
//				MessageBox.Show("不能挂当前时间前的号","提示");
//                m_dtpPreTime.Value=((clsControlRegister)this.objController).m_ServDate();
				
				m_dtpPreTime.Focus();
				return;
			}
			((clsControlRegister)this.objController).m_FillDoctorPlanDate();
		}

		private void m_cboSeg_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			bool bnlCheck=((clsControlRegister)this.objController).bnlCheckDate();
			if(!bnlCheck)
			{
//				MessageBox.Show("不能挂当前时间前的号","提示");
//				m_cboSeg.SelectedIndex=((clsControlRegister)this.objController).m_GetSerPerio();
			}
			else if(this.m_cboSeg.Focused)
				this.m_txtDept.Focus();
		}

		private void m_txtPatType_Enter(object sender, System.EventArgs e)
		{
			this.m_pnlAllPlan.Width =180;
			((clsControlRegister)this.objController).m_ShowDept(sender);
			
		   ((clsControlRegister)this.objController).m_GetlvwItem(this.m_lsvAllpay);	
			if(this.m_lsvAllpay.SelectedItems.Count>0)
			this.m_lsvAllpay.SelectedItems[0].EnsureVisible();
			this.m_lsvAllpay.BringToFront();			
			if(this.m_txtPatType.Text.Trim() != "")
			{
				((clsControlRegister)this.objController).m_FindLvw(this.m_txtDept.Text.Trim(),this.m_lsvAllpay);
			}
			 
		}

		private void m_txtDept_Enter(object sender, System.EventArgs e)
		{			
//			if(!this.m_pnlAllPlan.Visible || this.m_pnlAllPlan.Tag.ToString() != "m_txtDept")
//			{
			this.m_pnlAllPlan.Width =300;
				((clsControlRegister)this.objController).m_ShowDept(sender);
//			}
			((clsControlRegister)this.objController).m_GetlvwItem(this.m_lsvAlldept);
			
			this.m_lsvAlldept.SelectedItems[0].EnsureVisible();
			
			this.m_lsvAlldept.BringToFront();
			
//			if(this.m_txtDept.Text.Trim() != "")
//			{
//				((clsControlRegister)this.objController).m_FindLvw(this.m_txtDept.Text.Trim(),this.m_lsvAlldept);
//			}
		}

		private void m_txtRegType_Enter(object sender, System.EventArgs e)
		{
			
//			if(!this.m_pnlAllPlan.Visible || this.m_pnlAllPlan.Tag.ToString() != "m_txtRegType")
//			{
			this.m_pnlAllPlan.Width =170;
				((clsControlRegister)this.objController).m_ShowDept(sender);
//			}

			((clsControlRegister)this.objController).m_GetlvwItem(this.m_lsvAllregtype);
			this.m_lsvAllregtype.BringToFront();
			if(this.m_lsvAllregtype.SelectedItems.Count>0)
			this.m_lsvAllregtype.SelectedItems[0].EnsureVisible();
			if(this.m_txtRegType.Text.Trim() != "")
			{
				((clsControlRegister)this.objController).m_FindLvw(this.m_txtRegType.Text.Trim(),this.m_lsvAllregtype);
			}
		}

		private void m_txtDoc_Enter(object sender, System.EventArgs e)
		{
//			if(!this.m_pnlAllPlan.Visible || this.m_pnlAllPlan.Tag.ToString() != "m_txtDoc")
//			{
			this.m_pnlAllPlan.Width =150;
				((clsControlRegister)this.objController).m_ShowDept(sender);
//			}
			((clsControlRegister)this.objController).m_GetlvwItem(this.m_lsvAlldoc);
			this.m_lsvAlldoc.BringToFront();
			if(this.m_lsvAlldoc.Items.Count > 0)
			this.m_lsvAlldoc.SelectedItems[0].EnsureVisible();
			if(((clsControlRegister)this.objController).clsRegister.m_strRegisterType.m_decRegPay == 0)
			{
				this.m_lsvAlldoc.SelectedItems[0].Selected = false;
			}
			
			if(this.m_txtDoc.Text.Trim() != "")
			{
				((clsControlRegister)this.objController).m_FindLvw(this.m_txtDoc.Text.Trim(),this.m_lsvAlldoc);
			}
		}

		private void m_txtPatType_TextChanged(object sender, System.EventArgs e)
		{	
			try
			{
				if(this.ActiveControl.Name != "")
				{
					((clsControlRegister)this.objController).m_txtChange();
				}
				if(((TextBox)sender).Text == "")
				{
					((TextBox)sender).Tag = "";
				}
				
			}
			catch{}
		}

		private void m_btnExit_Click(object sender, System.EventArgs e)
		{
				this.Close();
		}
		private void m_btnClear_Click(object sender, System.EventArgs e)
		{
		   ((clsControlRegister)this.objController).m_Clear(sender);
			this.m_cobModify.Checked = false;
		}

		private void frmRegister_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled=(e.KeyChar==(char)32 || e.KeyChar=="'".ToCharArray()[0]);
		}

		private void frmRegister_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.Control)
			{
				if(e.KeyCode==Keys.Q)
				{
                    m_mthChangeRegister();
				}
			}

			switch (e.KeyCode)
			{
				case Keys.Escape:
					if(MessageBox.Show("是否退出门诊挂号系统？","系统提示",MessageBoxButtons.YesNo)==DialogResult.Yes)
					    this.Close();
					else
						isKeyDown=1;
					break;
				case Keys.F1:
					this.txtCheckNO.Focus();
					break;
				case Keys.F2:
					this.m_btnSave_Click(sender,e);
					break;
				case Keys.F3:
					this.m_btnClear_Click(sender,e);
					break;
				case Keys.F5:
					((clsControlRegister)this.objController).m_FillDoctorPlan();
					break;
				case Keys.F6:
					//new frmCancelRegister(this.LoginInfo).ShowDialog();
                    this.m_btnQul_Click(sender, e);                    
					break;
				case Keys.F7:
					new frmReturnReg(this.LoginInfo).ShowDialog();
					break;
				case Keys.F8:
					m_paytypename.Focus();
					break;
				case Keys.F10:
					this.m_txtAmount.Focus();
					break;
				case Keys.F11:
					buttonXP1_Click_1(null,null);
					break;
				case Keys.F12:
                    frmReWorkCard ReWork = new frmReWorkCard();
                    ReWork.m_FindPatien(m_txtCard.Text);
                    string getnewcard = "";
                    if (ReWork.ShowDialog()==DialogResult.OK)
                    {
                        getnewcard = ReWork.strNewCard;
                        ReWork.Close();
                        m_txtCard.Text = getnewcard;
                    }
                    
					break;

				case Keys.F9:
					if(this.m_chkPre.Checked)
					{
						this.m_chkPre.Checked = false;
					}
					else
					{
						this.m_chkPre.Checked = true;
					}
					break;
                case Keys.F4:
                    ((clsControlRegister)this.objController).m_NewCard();
                    break;
				case Keys.Right:
					if(m_dtpPreTime.Focused==true||m_dtpBirth.Focused==true)
					   return;
					try
					{
						if(this.ActiveControl.Name!="m_lvItem" && this.ActiveControl.Name!="m_lvPat" && this.ActiveControl.Name!="m_dtpBirth")
							if(m_lvItem.Items.Count>0)
							{
								string strTime=m_cboSeg.Text.Trim();
								for(int i1=0;i1<m_lvItem.Items.Count;i1++)
								{
									if(m_lvItem.Items[i1].SubItems[5].Text.Trim()==strTime)
									{
										if(m_txtDept.Text!="")
										{
											for(int f2=i1;f2<m_lvItem.Items.Count;f2++)
											{
												if(m_lvItem.Items[f2].SubItems[6].Text.Trim()==m_txtDept.Text.Trim()&&m_lvItem.Items[f2].SubItems[5].Text.Trim()==strTime)
												{
													m_lvItem.Items[0].Selected = false;
													m_lvItem.Focus();
													m_lvItem.Items[f2].Selected = true;
													m_lvItem.Items[f2].Focused = true;
													m_lvItem.Items[f2].EnsureVisible();
													return;
												}
											}
											m_lvItem.Items[0].Selected = false;
											m_lvItem.Focus();
											m_lvItem.Items[i1].Selected = true;
											m_lvItem.Items[i1].Focused = true;
											m_lvItem.Items[i1].EnsureVisible();
											return;
										}
										else
										{
											m_lvItem.Items[0].Selected = false;
											m_lvItem.Focus();
											m_lvItem.Items[i1].Selected = true;
											m_lvItem.Items[i1].Focused = true;
											m_lvItem.Items[i1].EnsureVisible();
											return;
										}
									}
									else
									{
										if(i1==m_lvItem.Items.Count-1)
										{
											m_lvItem.Items[0].Selected = false;
											m_lvItem.Focus();
											m_lvItem.Items[0].Selected = true;
											m_lvItem.Items[0].Focused = true;
											m_lvItem.Items[0].EnsureVisible();
											return;
										}
									}
								}
							}
					}
					catch
					{
					}
					break;
				case Keys.Left:
                    if(this.ActiveControl.Name=="m_lvItem")
                       ((clsControlRegister)this.objController).m_txtFocus((ListView)this.m_pnlAllPlan.Controls[0]);
					break;
			}
		}

		private void m_btnSave_Click(object sender, System.EventArgs e)
		{
			if(!((clsControlRegister)this.objController).m_mthInvoiceExpression())
			{
				MessageBox.Show("发票号不正确","Icare");
				txtCheckNO.Focus();
				return;
			}
			this.m_btnSave.Enabled = false;
			if(this.m_btnSave.Text=="挂号确认 F2")
			{
				long lngarr=0;
				if(this.m_txtCard.Text.Length<10 && this.m_txtCard.Text.Length>0)
				{
					string strCardID = "";
					strCardID = "0000000000"+this.m_txtCard.Text;
					this.m_txtCard.Text = strCardID.Substring(strCardID.Length-10);
				}
				if(label21.Text=="特困号"&&m_txtCardID.Text=="")
				{
					MessageBox.Show("特困号不能为空！","Icare",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
					m_txtCardID.Focus();
					this.m_btnSave.Enabled =true;
					return;
				}
                if (label21.Text == "离休" && m_txtCardID.Text == "")
                {
                    MessageBox.Show("离休编号不能为空！", "Icare", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    m_txtCardID.Focus();
                    this.m_btnSave.Enabled = true;
                    return;
                }
				if(label21.Text=="医疗证号"&&m_txtCardID.Text=="")
				{
					MessageBox.Show("医疗证号不能为空！","Icare",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
					m_txtCardID.Focus();
					this.m_btnSave.Enabled =true;
					return;
				}
				if(m_mthCheckNo())
				{
					return;
				}
				lngarr = ((clsControlRegister)this.objController).m_lngAddRegister();

				if(lngarr==-2)
				{
					MessageBox.Show("卡号已经被占用，请换另外一张卡再挂号！","Icare",MessageBoxButtons.OK,MessageBoxIcon.Stop);
					m_txtCard.Focus();
					m_btnSave.Enabled=true;
					return;
				}
				if(lngarr==1)
				{
					objBar.Panels[4].Text="上一个病人："+this.m_txtName.Text+" 卡号："+this.m_txtCard.Text;
					objBar.Panels[3].Text="";
					objBar.Panels[4].ToolTipText="";
                    try
                    {
						((clsControlRegister)this.objController).m_PrintRegister(sender);	
                    }
                    catch(Exception ex)
                    {
                        if(MessageBox.Show("打印期间发生"+ex.ToString()+"错误,检查后是否要重打该挂号发票？","Icare",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                        {
                            this.m_btnSave.Text="挂号重打F2";
                        }
                        else
                        {
                            ((clsControlRegister)this.objController).m_Clear(sender);
                        }
                    }
				}
			}
			else
			{
				try
				{
					((clsControlRegister)this.objController).m_PrintRegister(sender);	
				}
                catch (Exception objEx)
				{
                    if (MessageBox.Show(objEx.ToString()+"错误,否要重打该挂号发票？", "Icare", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						this.m_btnSave.Text="挂号重打F2";
					}
					else
					{
						((clsControlRegister)this.objController).m_Clear(sender);
						
					}
				}
				
			}
			this.m_btnSave.Enabled = true;
            this.m_chkPre.Checked = false;
		}

		#region 检查发票号是否重复
		/// <summary>
		/// 检查发票号是否重复
		/// </summary>
		/// <returns></returns>
		private bool m_mthCheckNo()
		{
			clsDomainControl_Register domain =new clsDomainControl_Register();
			if(!domain.m_mthIsCanDo("0008"))
			{
				System.Data.DataTable dt=null;
				long lngarr=domain.m_lngCheckNO(txtCheckNO.Text.Trim(),out dt);
				if(dt!=null&&dt.Rows.Count>0)
				{
					MessageBox.Show("该发票号"+txtCheckNO.Text.Trim()+"已于"+DateTime.Parse(dt.Rows[dt.Rows.Count-1]["REGISTERDATE_DAT"].ToString()).ToString("yyyy-MM-dd")+"被"+dt.Rows[dt.Rows.Count-1]["EMPNO_CHR"].ToString().Trim()+"使用","icare",MessageBoxButtons.OK,MessageBoxIcon.Information);
					txtCheckNO.Focus();
					this.m_btnSave.Enabled =true;
					return true;
				}
			}
			return false;
		}

		#endregion

		private void m_lvItem_Click(object sender, System.EventArgs e)
		{
		  ((clsControlRegister)this.objController).m_lvwItemClick((ListView)sender);
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

		}

		private void m_cboSex_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Escape:
					this.Close();
					break;
				case Keys.F1:
					this.txtCheckNO.Focus();
					break;
				case Keys.F2:
					this.m_btnSave_Click(sender,e);
					break;
				case Keys.F3:
					this.m_btnClear_Click(sender,e);
					break;
				case Keys.F5:
					((clsControlRegister)this.objController).m_FillDoctorPlan();
					break;
				case Keys.F6:
					//new frmCancelRegister(this.LoginInfo).ShowDialog();
                    this.m_btnQul_Click(sender, e);                    
					break;
				case Keys.F7:
					new frmReturnReg(this.LoginInfo).ShowDialog();
					break;
				case Keys.F8:
					m_paytypename.Focus();
					break;
				case Keys.F10:
					this.m_txtAmount.Focus();
					break;

				case Keys.F9:
					if(this.m_chkPre.Checked)
					{
						this.m_chkPre.Checked = false;
					}
					else
					{
						this.m_chkPre.Checked = true;
					}
					break;

				case Keys.Right:
					if(m_dtpPreTime.Focused==true||m_dtpBirth.Focused==true)
						return;
					if(this.ActiveControl.Name!="m_lvItem" && this.ActiveControl.Name!="m_lvPat" && this.ActiveControl.Name!="m_dtpBirth")
						if(m_lvItem.Items.Count>0)
						{
							string strTime=m_cboSeg.Text.Trim();
							for(int i1=0;i1<m_lvItem.Items.Count;i1++)
							{
								if(m_lvItem.Items[i1].SubItems[5].Text.Trim()==strTime)
								{
									if(m_txtDept.Text!="")
									{
										for(int f2=i1;f2<m_lvItem.Items.Count;f2++)
										{
											if(m_lvItem.Items[f2].SubItems[6].Text.Trim()==m_txtDept.Text.Trim()&&m_lvItem.Items[f2].SubItems[5].Text.Trim()==strTime)
											{
												m_lvItem.Items[0].Selected = false;
												m_lvItem.Focus();
												m_lvItem.Items[f2].Selected = true;
												m_lvItem.Items[f2].Focused = true;
												m_lvItem.Items[f2].EnsureVisible();
												return;
											}
										}
										m_lvItem.Items[0].Selected = false;
										m_lvItem.Focus();
										m_lvItem.Items[i1].Selected = true;
										m_lvItem.Items[i1].Focused = true;
										m_lvItem.Items[i1].EnsureVisible();
										return;
									}
									else
									{
										m_lvItem.Items[0].Selected = false;
										m_lvItem.Focus();
										m_lvItem.Items[i1].Selected = true;
										m_lvItem.Items[i1].Focused = true;
										m_lvItem.Items[i1].EnsureVisible();
										return;
									}
								}
								else
								{
									if(i1==m_lvItem.Items.Count-1)
									{
										m_lvItem.Items[0].Selected = false;
										m_lvItem.Focus();
										m_lvItem.Items[0].Selected = true;
										m_lvItem.Items[0].Focused = true;
										m_lvItem.Items[0].EnsureVisible();
										return;
									}
								}
							}
						}
					break;
				case Keys.Left:
					if(this.ActiveControl.Name=="m_lvItem")
						((clsControlRegister)this.objController).m_txtFocus((ListView)this.m_pnlAllPlan.Controls[0]);
					break;
			}
		}

		private void m_txtPatType_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				
				if(m_lsvAllpay.Items.Count !=0)
				{
					this.m_lvItem_Click(this.m_lsvAllpay,e);
				}
				else
				{
					((TextBox)sender).Text = "";
				}
				this.m_pnlAllPlan.Visible = false;
				
			}
			if(e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
			{
				int index = 0;
				for(int i=0;i<this.m_lsvAllpay.Items.Count;i++)
				{
					if(this.m_lsvAllpay.Items[i].Selected)
					{
						index = i;
					}
				}
				((clsControlRegister)this.objController).m_UpDown(index,e,(object)this.m_lsvAllpay);
			}
		}

		private void m_txtDept_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				if(m_lsvAlldept.Items.Count !=0 )
				{
					this.m_lvItem_Click(this.m_lsvAlldept,e);
				}
				else
				{
					((TextBox)sender).Text = "";
				}
				this.m_txtRegType.Focus();
			}
			if(e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
			{
				int index = 0;
				for(int i=0;i<this.m_lsvAlldept.Items.Count;i++)
				{
					if(this.m_lsvAlldept.Items[i].Selected)
					{
						index = i;
					}
				}
				((clsControlRegister)this.objController).m_UpDown(index,e,(object)this.m_lsvAlldept);
			}
		}

		private void m_txtRegType_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				if(m_lsvAllregtype.Items.Count !=0)
				{
					this.m_lvItem_Click(this.m_lsvAllregtype,e);
				}
				else
				{
					((TextBox)sender).Text = "";
				}
				this.m_txtDoc.Focus();
				
			}
			if(e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
			{
				int index = 0;
				for(int i=0;i<this.m_lsvAllregtype.Items.Count;i++)
				{
					if(this.m_lsvAllregtype.Items[i].Selected)
					{
						index = i;
					}
				}
				((clsControlRegister)this.objController).m_UpDown(index,e,(object)this.m_lsvAllregtype);
			}
		}

		private void m_txtDoc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Space)
			{
				if(m_lblRecount.Text=="医生必填"&&m_txtDoc.Text=="")
				{
					m_txtDoc.Focus();
					return;
				}
				m_txtAmount.Focus();
			}
			if(e.KeyCode==Keys.Enter)
			{

				if(m_lsvAlldoc.SelectedItems.Count!=0)
				{
					this.m_lvItem_Click(this.m_lsvAlldoc,e);
				}
				else
				{
					((TextBox)sender).Text = "";
				}
				this.m_pnlAllPlan.Visible = false;
				this.m_txtAmount.Focus();
				if(m_lblRecount.Text=="医生必填"&&m_txtDoc.Text=="")
				{
					m_txtDoc.Focus();
					return;
				}
			}
			if(e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
			{
				int index = -1;
				for(int i=0;i<this.m_lsvAlldoc.Items.Count;i++)
				{
					if(this.m_lsvAlldoc.Items[i].Selected)
					{
						index = i;
					}
				}
				((clsControlRegister)this.objController).m_UpDown(index,e,(object)this.m_lsvAlldoc);
			}
		}

		private void m_lvItem_KeyDown_1(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				this.m_lvItem_Click(sender,e);
			}
		}
		int isKeyDown;
		private void m_txtCard_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
                //if (CardNo11Flag)
                //{
                //    this.m_txtCard.Text = clsPublic.CardNo11Value(this.m_txtCard.Text.Trim());
                //}
				this.m_txtName.Focus();
                if (this.m_txtCard.Text.Length < 10 && this.m_txtCard.Text.Length > 0)
                {
                    string strCardID = "";
                    strCardID = "0000000000" + this.m_txtCard.Text;
                    this.m_txtCard.Text = strCardID.Substring(strCardID.Length - 10);
                }
			}
		}

		private void m_dtpBirth_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				this.m_txtDept.Focus();
			}
		}

		private void m_txtName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
		}

		private void m_dtpBirth_ValueChanged(object sender, System.EventArgs e)
		{
			if(((clsControlRegister)this.objController).bnlChekcBirth())
			{
				if(this.m_radbirth.Checked)
				{
					this.m_txtAge.Value = this.m_dtpBirth.Value.Date;
				}
			}
		}

		private void m_txtCard_Leave(object sender, System.EventArgs e)
		{
            if (m_txtCard.Text == "")
            {
                ((clsControlRegister)this.objController).m_NewOrModefy = 1;
                return;
            }
            if (this.m_txtCard.Text.Length < 10 && this.m_txtCard.Text.Length > 0)
            {
                string strCardID = "";
                strCardID = "0000000000" + this.m_txtCard.Text;
                this.m_txtCard.Text = strCardID.Substring(strCardID.Length - 10);
            }
            m_txtDept.Clear();
            m_txtRegType.Clear();
            m_txtDoc.Clear();
            m_lbStart.Text = "";
            m_lbEnd.Text = "";
            m_lbRoom.Text = "";
            m_lsvRegDetail.Items.Clear();
            m_txtAmount.Clear();
            m_txtRegFee.Text = "";
            m_txtDiagFee.Text = "";
            if (this.Tag != null && this.Tag.ToString() == "Y")
                return;
            if (this.ActiveControl == null || this.ActiveControl.Name == "m_btnClear" ||
                this.Visible == false || this.ActiveControl.Name == "m_btnExit" || this.ActiveControl.Name == "m_cobModify")
                return;
            string DepName = null;
            string doctorName = null;
            string registerDate = null;
            ((clsControlRegister)this.objController).m_FindPat(out DepName, out doctorName, out registerDate);
            if (DepName != null)
            {
                objBar.Panels[3].Text = "今天已挂号：" + registerDate + "," + DepName + "," + doctorName;
            }
            else
            {
                objBar.Panels[3].Text = "";
            }
		}

		private void frmRegister_Activated(object sender, System.EventArgs e)
		{
			this.Tag=null;
			this.Select();
		}

		private void frmRegister_Deactivate(object sender, System.EventArgs e)
		{
			this.Tag="Y";
		}

		private void m_txtAmount_TextChanged(object sender, System.EventArgs e)
		{
			this.m_txtAmount.Text = System.Text.RegularExpressions.Regex.Replace(this.m_txtAmount.Text,"[^0-9,.]","");
			((clsControlRegister)this.objController).m_Calculate();
		}

		private void m_chkNotofalill_CheckedChanged(object sender, System.EventArgs e)
		{
			((clsControlRegister)this.objController).m_GetCurPay();
			if(this.m_txtRegType.Text.Trim()!= "" && this.m_txtPatType.Text.Trim() != "" && this.ActiveControl.Name != "m_txtDept")
			{
				this.m_txtAmount.Focus();
			}
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
				index = ((clsControlRegister)this.objController).m_intModifyPrice();
				((clsControlRegister)this.objController).m_UpDown(index,e,(object)this.m_lsvRegDetail);
			}
		}

		private void m_lsvRegDetail_Click(object sender, System.EventArgs e)
		{
			((clsControlRegister)this.objController).m_getCurPrice();
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
			index = ((clsControlRegister)this.objController).m_intModifyPrice();
		}

		private void m_btnQul_Click(object sender, System.EventArgs e)
		{
            frmCancelRegister f = new frmCancelRegister(this.LoginInfo);
            f.Scope = "1";
            f.ShowDialog();
			//new frmCancelRegister(this.LoginInfo).ShowDialog();
		}

		private void m_txtCard_TextChanged(object sender, System.EventArgs e)
		{
            //try
            //{
            //    if(isKeyDown==1&&this.m_txtCard.Text=="0")
            //    {
            //        this.m_txtCard.Text="";
            //        isKeyDown=0;
            //        return;
            //    }
            //    isKeyDown=0;
            //    if(this.m_txtCard.Text.Length==5&&Convert.ToInt64(this.m_txtCard.Text.Trim())==99999)
            //    {
            //        string Pattern1 = "[^0-8]";
            //        this.m_txtCard.Text= System.Text.RegularExpressions.Regex.Replace(this.m_txtCard.Text.TrimEnd(),Pattern1,"");
            //    }
            //    ((TextBox)sender).Text = System.Text.RegularExpressions.Regex.Replace(((TextBox)sender).Text,"%","");	
            //}
            //catch
            //{
            //}
		}

		private void m_lvItem_Click_1(object sender, System.EventArgs e)
		{
			((clsControlRegister)this.objController).m_SelectPlan();
			this.m_lblRecount.Text = "";
			
		}

		private void m_txtRegType_Leave(object sender, System.EventArgs e)
		{
			try
			{
				if(this.ActiveControl.Name != "m_lsvAllplan")
					this.m_pnlAllPlan.Visible = false;
				if(((TextBox)sender).Text == "" && this.ActiveControl.Name != "m_lsvAllplan")
				{
					this.m_lblRecount.Text = "";
				}
			}
			catch{}
		}

		private void m_lvItem_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar == (char)13)
			{
				this.m_lvItem_Click_1(null,null);
				this.m_txtAmount.Focus();
			}
		}

		private void m_btnReLoadPlan_Click(object sender, System.EventArgs e)
		{
			((clsControlRegister)this.objController).m_FillDoctorPlanByDate();
		}

		private void m_lsvAllplan_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				
			}
			catch{}
		}

		private void m_lsvAllplan_Leave(object sender, System.EventArgs e)
		{
			try
			{
				this.m_pnlAllPlan.Visible = false;
			}
			catch{}
		}

		private void m_txtName_TextChanged(object sender, System.EventArgs e)
		{
			if(this.m_txtName.Text.Trim() == "0")
			{
				this.m_txtName.Text="";
			
			}
		}

		private void m_cobModify_CheckedChanged(object sender, System.EventArgs e)
		{
			((clsControlRegister)this.objController).m_SetReadOnly(m_cobModify.Checked);
		}

		private void m_txtRegisterNo_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar == (char)13)
			{
				((clsControlRegister)this.objController).m_GetRegByRegNo(sender);
			}
		}

		private void m_radbirth_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.m_radAge.Checked)
			{
                this.textBox1.Visible = true;
                this.textBox1.Focus();
                this.m_txtAge.Visible = false;
                //this.m_txtAge.Focus();
				this.m_dtpBirth.Visible = false;
				this.intAeg.Visible=false;
			}
			if(this.m_radbirth.Checked)
			{
				this.m_txtAge.Visible = false;
                this.textBox1.Visible = false;
				this.m_dtpBirth.Visible = true;
				this.m_dtpBirth.Focus();
				this.intAeg.Visible=false;
			}
		}

		private void m_txtAge_TextChanged(object sender, System.EventArgs e)
		{
            try
            {
                if (this.m_radAge.Checked)
                {
                    this.m_dtpBirth.Value = this.m_txtAge.Value;
                }
            }
            catch { }
		}

		private void m_txtPatType_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar == (char)13)
			{
				SendKeys.Send("{TAB}");
			}
		}

		private void m_radAge_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar == (char)13)
			{
                //this.m_txtAge.Focus();
                this.textBox1.Focus();
				this.m_dtpBirth.Focus();
			}
		}

		private void m_cboSex_Enter(object sender, System.EventArgs e)
		{
			this.m_cboSex.SelectedIndex = 0;
			this.m_cboSex.DroppedDown = true;
		}

		private void m_txtAge_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
            try
            {
                if (m_txtAge.Text == "" || Convert.ToInt32(m_txtAge.Text) > 150)
                {
                    m_txtAge.Focus();
                    return;
                }
            }
            catch
            {
            }
            if (e.KeyChar == (char)13)
            {
                if (this.m_txtDept.Enabled)
                {
                    this.m_txtDept.Focus();
                }
                else
                {
                    this.m_txtAmount.Focus();
                }
            }
		}

		private void buttonXP1_Click(object sender, System.EventArgs e)
		{
			new frmReturnReg(this.LoginInfo).ShowDialog();
		}

		private void m_paytypename_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.m_txtDept.Enabled)
			{
				this.m_txtDept.Focus();
			}
			else
			{
				this.m_txtAmount.Focus();
			}
		}

		private void m_txtName_Validated(object sender, System.EventArgs e)
		{
			if(this.m_txtCard.Text.Trim() == "" && this.m_txtName.Text.Trim() != "")
			{
				this.m_lblOptimes.Text = "第1次挂号！";
			}
		}

        private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }

		private void m_lvItem_KeyDown_2(object sender, System.Windows.Forms.KeyEventArgs e)
		{

		}

		private void txtCheckNO_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				m_txtCard.Focus();
			}
		}

		private void txtCheckNO_KeyDown_1(object sender, System.Windows.Forms.KeyEventArgs e)
		{

		}

		private void m_lvItem_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
		int count=0;
		private void m_dtpPreTime_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar == (char)13)
			{
				SendKeys.Send("{Right}");
				count++;
				if(count>2)
				{
					SendKeys.Send("{TAB}");
					count=0;
				}
			}
		}

		private void m_cboSeg_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				m_txtDept.Focus();
			switch (e.KeyCode)
			{
				case Keys.Escape:
					this.Close();
					break;
				case Keys.F1:
					this.txtCheckNO.Focus();
					break;
				case Keys.F2:
					this.m_btnSave_Click(sender,e);
					break;
				case Keys.F3:
					this.m_btnClear_Click(sender,e);
					break;
				case Keys.F5:
					((clsControlRegister)this.objController).m_FillDoctorPlan();
					break;
				case Keys.F6:
					new frmCancelRegister(this.LoginInfo).ShowDialog();                    
					break;
				case Keys.F7:
					new frmReturnReg(this.LoginInfo).ShowDialog();
					break;
				case Keys.F8:
					m_paytypename.Focus();
					break;
				case Keys.F10:
					this.m_txtAmount.Focus();
					break;

				case Keys.F9:
					if(this.m_chkPre.Checked)
					{
						this.m_chkPre.Checked = false;
					}
					else
					{
						this.m_chkPre.Checked = true;
					}
					break;

				case Keys.Right:
					if(m_dtpPreTime.Focused==true||m_dtpBirth.Focused==true)
						return;
					if(this.ActiveControl.Name!="m_lvItem" && this.ActiveControl.Name!="m_lvPat" && this.ActiveControl.Name!="m_dtpBirth")
						if(m_lvItem.Items.Count>0)
						{
							string strTime=m_cboSeg.Text.Trim();
							for(int i1=0;i1<m_lvItem.Items.Count;i1++)
							{
								if(m_lvItem.Items[i1].SubItems[5].Text.Trim()==strTime)
								{
									if(m_txtDept.Text!="")
									{
										for(int f2=i1;f2<m_lvItem.Items.Count;f2++)
										{
											if(m_lvItem.Items[f2].SubItems[6].Text.Trim()==m_txtDept.Text.Trim()&&m_lvItem.Items[f2].SubItems[5].Text.Trim()==strTime)
											{
												m_lvItem.Items[0].Selected = false;
												m_lvItem.Focus();
												m_lvItem.Items[f2].Selected = true;
												m_lvItem.Items[f2].Focused = true;
												m_lvItem.Items[f2].EnsureVisible();
												return;
											}
										}
										m_lvItem.Items[0].Selected = false;
										m_lvItem.Focus();
										m_lvItem.Items[i1].Selected = true;
										m_lvItem.Items[i1].Focused = true;
										m_lvItem.Items[i1].EnsureVisible();
										return;
									}
									else
									{
										m_lvItem.Items[0].Selected = false;
										m_lvItem.Focus();
										m_lvItem.Items[i1].Selected = true;
										m_lvItem.Items[i1].Focused = true;
										m_lvItem.Items[i1].EnsureVisible();
										return;
									}
								}
								else
								{
									if(i1==m_lvItem.Items.Count-1)
									{
										m_lvItem.Items[0].Selected = false;
										m_lvItem.Focus();
										m_lvItem.Items[0].Selected = true;
										m_lvItem.Items[0].Focused = true;
										m_lvItem.Items[0].EnsureVisible();
										return;
									}
								}
							}
						}
					break;
				case Keys.Left:
					if(this.ActiveControl.Name=="m_lvItem")
						((clsControlRegister)this.objController).m_txtFocus((ListView)this.m_pnlAllPlan.Controls[0]);
					break;
			}
		}

		private void m_dtpBirth_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar == (char)13)
			{
				SendKeys.Send("{Right}");
				count++;
				if(count>2)
				{
					count=0;
					this.m_chkPre.Focus();
				}
			}
		}
		private void button1_Click(object sender, System.EventArgs e)
		{
		}
		#region 转挂号
		private void m_mthChangeRegister()
		{
			if(this.FindWindow("frmOPCharge"))
			{
				return;
			}
            frmOPCharge frmRegister = new frmOPCharge();
            frmRegister.Show();
            frmRegister.MdiParent = this.MdiParent;
			frmRegister.TextBoxPatientCard.Focus();
            
		}
		private bool FindWindow(string strText)
		{
			for(int i=0;i<this.MdiParent.MdiChildren.Length;i++)
			{
				string muText=this.MdiParent.MdiChildren[i].Name;
				if(strText==muText)
				{
					this.MdiParent.MdiChildren[i].Activate();
					frmOPCharge frmTemp = this.MdiParent.MdiChildren[i] as frmOPCharge;
					if(frmTemp!=null)
					{
					frmTemp.TextBoxPatientCard.Focus();
					}
					return true;
				}
			}
			return false;
		}
		#endregion

		private void btnclick_Click(object sender, System.EventArgs e)
		{
			for(int i1=0;i1<this.MdiParent.Menu.MenuItems.Count;i1++)
			{
				if(this.MdiParent.Menu.MenuItems[i1].Text=="收费系统")
				{
					for(int f2=0;f2<this.MdiParent.Menu.MenuItems[i1].MenuItems.Count;f2++)
					{
						if(this.MdiParent.Menu.MenuItems[i1].MenuItems[f2].Text=="门诊划价收费")
						{
							this.MdiParent.Menu.MenuItems[i1].MenuItems[f2].MenuItems[0].PerformClick();
							return;
						}

					}
				}
			}
		}
		private void m_txtCardID_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				m_txtAge.Focus();
		}

		private void buttonXP1_Click_1(object sender, System.EventArgs e)
		{
			if(((clsControlRegister)this.objController).m_NewOrModefy==1&&m_txtName.Text!="")
			{
				frmShowPatient Show=new frmShowPatient();
				Show.m_SetPatientName=m_txtName.Text;
				Show.m_SetSex=m_cboSex.Text;
				try
				{
					if(m_radbirth.Checked==true)
					{
						Show.m_SetPatientBirth=this.m_txtAge.Value.Date.ToString();
					}
					else if(intAeg.Text.Trim()!="")
					{
						int brith=DateTime.Now.Year-int.Parse(intAeg.Text);
						Show.m_SetPatientBirth=brith+"-01-01";
					}
					else
					{
						Show.m_SetPatientBirth="";
					}
				}
				catch
				{
					Show.m_SetPatientBirth="";
				}
				
				if(Show.ShowDialog()==DialogResult.OK)
				{
					m_txtCard.Text=Show.m_GetCardID;
					m_txtCard.Focus();
					SendKeys.Send("{enter}");
				}

			}
		}

		private void frmRegister_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{

			objBar.Panels[3].Text="";
			objBar.Panels[4].Text="";
		}

		private void txtCheckNO_KeyDown_2(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				if(this.txtCheckNO.Text.Length<7 && this.txtCheckNO.Text.Length>0)
				{
					string strCardID = "";
					strCardID = "0000000000"+this.txtCheckNO.Text;
					this.txtCheckNO.Text = strCardID.Substring(strCardID.Length-7);
				}
				m_txtCard.Focus();
			}
		}

		private void buttonXP2_Click(object sender, System.EventArgs e)
		{
			com.digitalwave.iCare.gui.Patient.frmPatient frm=new com.digitalwave.iCare.gui.Patient.frmPatient();
			frm.LoginInfo=this.LoginInfo;
			frm.btnParticular_Click(null,null);
            //com.digitalwave.iCare.ValueObject.clsPatient_VO patientVO = new clsPatient_VO();
            //patientVO.strPatientCardID = this.m_txtCard.Text;
            //patientVO.objPatType = new clsPatientType_VO();
            //patientVO.objPatType.m_strPayTypeName = m_txtPatType.Text;
            //patientVO.strInsuranceID = m_txtCardID.Text;
            //patientVO.strSex = this.m_cboSex.Text;
            //patientVO.m_strNAME_VCHR = this.m_txtName.Text;
            //if (m_radbirth.Checked == true)
            //    patientVO.strBirthDate = Convert.ToString(this.m_dtpBirth.Value);
            //else if (m_txtAge.Text != "")
            //{
            //    string[] ArrChar = m_txtAge.Text.Split(new char[] { '.' }, 2);
            //    if (ArrChar.Length > 2)
            //    {
            //        MessageBox.Show("错误的岁数！", "Icare", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        m_txtAge.Focus();
            //        return;
            //    }
            //    int nowDate;
            //    int month;
            //    string strNowDate = "";
            //    if (ArrChar.Length == 2)
            //    {
            //        nowDate = DateTime.Now.Year - Convert.ToInt32(ArrChar[0].ToString());
            //        month = DateTime.Now.Month - 6;
            //        if (month < 0)
            //        {
            //            nowDate--;
            //            month = DateTime.Now.Month - 6 + 12;
            //            strNowDate = nowDate.ToString() + "-" + month.ToString() + "-01";
            //        }
            //        else
            //        {
            //            month = DateTime.Now.Month - 6 - 12;
            //            strNowDate = nowDate.ToString() + "-" + month.ToString() + "-01";
            //        }
            //    }
            //    else
            //    {
            //        nowDate = DateTime.Now.Year - Convert.ToInt32(ArrChar[0].ToString());
            //        strNowDate = nowDate.ToString() + "-01-01";
            //    }
            //    patientVO.strBirthDate = strNowDate;
            //}
            //else
            //{
            //    patientVO.strBirthDate = "1900-01-01";
            //}
            //frm.m_mthGetPatientData(patientVO);
			DialogResult drt =frm.ShowDialog();
			if(drt==DialogResult.OK)
			{
				this.m_txtCard.Text=frm.m_strCardID;
				this.m_txtCard.Focus();
				SendKeys.Send("{Enter}");
			}
			if(drt ==DialogResult.No)
			{
				this.m_txtCard.Focus();
			}
			frm.Close();
		}

		private void txtCheckNO_Leave(object sender, System.EventArgs e)
		{
			m_mthCheckNo();
		}

        private void m_objPrintDocment_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((clsControlRegister)this.objController).m_mthBeginInitial();
        }

        private void m_objPrintDocment_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            ((clsControlRegister)this.objController).m_mthPrintPage(e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (this.textBox1.Text == "" || Convert.ToInt32(textBox1.Text) > 150)
                {
                    textBox1.Focus();
                    return;
                }
            }
            catch
            {
            }
            if (e.KeyChar == (char)13)
            {
                if (this.m_txtDept.Enabled)
                {
                    this.m_txtDept.Focus();
                }
                else
                {
                    this.m_txtAmount.Focus();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          try
          {
              if (this.m_radAge.Checked)
              {
                  this.m_dtpBirth.Value = ((clsControlRegister)this.objController).birthDate;
              }
          }
          catch { }
        }

        private void m_txtCard1_CardKeyDown(object sender, EventArgs e)
        {
            this.m_txtName.Focus();
            if (this.m_txtCard.Text.Length < 10 && this.m_txtCard.Text.Length > 0)
            {
                string strCardID = "";
                strCardID = "0000000000" + this.m_txtCard.Text;
                this.m_txtCard.Text = strCardID.Substring(strCardID.Length - 10);
            }
        }

        private void m_txtCard1_CardLeave(object sender, EventArgs e)
        {
            if (m_txtCard.Text == "")
            {
                ((clsControlRegister)this.objController).m_NewOrModefy = 1;
                return;
            }
            if (this.m_txtCard.Text.Length < 10 && this.m_txtCard.Text.Length > 0)
            {
                string strCardID = "";
                strCardID = "0000000000" + this.m_txtCard.Text;
                this.m_txtCard.Text = strCardID.Substring(strCardID.Length - 10);
            }
            m_txtDept.Clear();
            m_txtRegType.Clear();
            m_txtDoc.Clear();
            m_lbStart.Text = "";
            m_lbEnd.Text = "";
            m_lbRoom.Text = "";
            m_lsvRegDetail.Items.Clear();
            m_txtAmount.Clear();
            m_txtRegFee.Text = "";
            m_txtDiagFee.Text = "";
            if (this.Tag != null && this.Tag.ToString() == "Y")
                return;
            if (this.ActiveControl == null || this.ActiveControl.Name == "m_btnClear" ||
                this.Visible == false || this.ActiveControl.Name == "m_btnExit" || this.ActiveControl.Name == "m_cobModify")
                return;
            string DepName = null;
            string doctorName = null;
            string registerDate = null;
            ((clsControlRegister)this.objController).m_FindPat(out DepName, out doctorName, out registerDate);
            if (DepName != null)
            {
                objBar.Panels[3].Text = "今天已挂号：" + registerDate + "," + DepName + "," + doctorName;
            }
            else
            {
                objBar.Panels[3].Text = "";
            }
        }
	}
}
