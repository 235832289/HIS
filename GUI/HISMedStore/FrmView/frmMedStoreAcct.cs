using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 药房登帐窗口
	/// Create kong by 2004-06-16
	/// </summary>
	public class frmMedStoreAcct : com.digitalwave.GUI_Base.frmMDI_Child_Base	//GUI_Base.dll
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtOrdType;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtCreator;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtAduit;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtOrdID;
		internal System.Windows.Forms.DateTimePicker m_dtbCreateDate;
		private System.Windows.Forms.Label label9;
		internal System.Windows.Forms.ComboBox m_cboSelPeriod;
		private System.Windows.Forms.TabControl tabAcct;
		private System.Windows.Forms.TabPage tabPageUnAcct;
		private System.Windows.Forms.TabPage tabPageEnAcct;
		private System.Windows.Forms.GroupBox groupBox2;
		internal System.Windows.Forms.ListView m_lsvDetail;
		internal PinkieControls.ButtonXP m_cmdAcct;
		internal PinkieControls.ButtonXP m_cmdPrint;
		internal PinkieControls.ButtonXP m_cmdClose;
		private System.Windows.Forms.ColumnHeader clhRowNo;
		private System.Windows.Forms.ColumnHeader clhMedID;
		private System.Windows.Forms.ColumnHeader clhMedName;
		private System.Windows.Forms.ColumnHeader clhMedSpec;
		private System.Windows.Forms.ColumnHeader clhUnit;
		internal System.Windows.Forms.ColumnHeader clhQty;
		internal System.Windows.Forms.ColumnHeader clhBuyPrice;
		internal System.Windows.Forms.ColumnHeader clhSalePrice;
		internal System.Windows.Forms.ColumnHeader clhDiff;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtCurPeriod;
		private System.Windows.Forms.ColumnHeader clhUnFlag;
		private System.Windows.Forms.ColumnHeader clhUnID;
		private System.Windows.Forms.ColumnHeader clhUnType;
		private System.Windows.Forms.ColumnHeader clhUnCreateDate;
		private System.Windows.Forms.ColumnHeader clhUnCreator;
		private System.Windows.Forms.ColumnHeader clhUnAduit;
		private System.Windows.Forms.ColumnHeader clhEnFlag;
		private System.Windows.Forms.ColumnHeader clhEnID;
		private System.Windows.Forms.ColumnHeader clhEnType;
		private System.Windows.Forms.ColumnHeader clhEnCreateDate;
		private System.Windows.Forms.ColumnHeader clhEnCreator;
		private System.Windows.Forms.ColumnHeader clhEnAduit;
		internal System.Windows.Forms.ListView m_lsvUnAcct;
		internal System.Windows.Forms.ListView m_lsvEnAcct;
		private System.Windows.Forms.ColumnHeader clhUnRow;
		private System.Windows.Forms.ColumnHeader clhEnRow;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtBuyTolMoney;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtSaleTolMoney;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.ColumnHeader clhUnSign;
		private System.Windows.Forms.ColumnHeader clhEnSign;
		internal System.Windows.Forms.ColumnHeader clhOther;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtMedStore;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// 药房登帐窗口
		/// </summary>
		public frmMedStoreAcct()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label11 = new System.Windows.Forms.Label();
			this.m_txtSaleTolMoney = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.m_txtBuyTolMoney = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.m_dtbCreateDate = new System.Windows.Forms.DateTimePicker();
			this.m_txtOrdID = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.m_txtAduit = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.m_txtCreator = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.m_txtOrdType = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.m_txtMedStore = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.label8 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.m_txtCurPeriod = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.tabAcct = new System.Windows.Forms.TabControl();
			this.tabPageUnAcct = new System.Windows.Forms.TabPage();
			this.m_lsvUnAcct = new System.Windows.Forms.ListView();
			this.clhUnRow = new System.Windows.Forms.ColumnHeader();
			this.clhUnFlag = new System.Windows.Forms.ColumnHeader();
			this.clhUnID = new System.Windows.Forms.ColumnHeader();
			this.clhUnType = new System.Windows.Forms.ColumnHeader();
			this.clhUnCreateDate = new System.Windows.Forms.ColumnHeader();
			this.clhUnCreator = new System.Windows.Forms.ColumnHeader();
			this.clhUnAduit = new System.Windows.Forms.ColumnHeader();
			this.clhUnSign = new System.Windows.Forms.ColumnHeader();
			this.tabPageEnAcct = new System.Windows.Forms.TabPage();
			this.m_lsvEnAcct = new System.Windows.Forms.ListView();
			this.clhEnRow = new System.Windows.Forms.ColumnHeader();
			this.clhEnFlag = new System.Windows.Forms.ColumnHeader();
			this.clhEnID = new System.Windows.Forms.ColumnHeader();
			this.clhEnType = new System.Windows.Forms.ColumnHeader();
			this.clhEnCreateDate = new System.Windows.Forms.ColumnHeader();
			this.clhEnCreator = new System.Windows.Forms.ColumnHeader();
			this.clhEnAduit = new System.Windows.Forms.ColumnHeader();
			this.clhEnSign = new System.Windows.Forms.ColumnHeader();
			this.label9 = new System.Windows.Forms.Label();
			this.m_cboSelPeriod = new System.Windows.Forms.ComboBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.m_cmdClose = new PinkieControls.ButtonXP();
			this.m_cmdPrint = new PinkieControls.ButtonXP();
			this.m_cmdAcct = new PinkieControls.ButtonXP();
			this.m_lsvDetail = new System.Windows.Forms.ListView();
			this.clhRowNo = new System.Windows.Forms.ColumnHeader();
			this.clhMedID = new System.Windows.Forms.ColumnHeader();
			this.clhMedName = new System.Windows.Forms.ColumnHeader();
			this.clhMedSpec = new System.Windows.Forms.ColumnHeader();
			this.clhUnit = new System.Windows.Forms.ColumnHeader();
			this.clhQty = new System.Windows.Forms.ColumnHeader();
			this.clhBuyPrice = new System.Windows.Forms.ColumnHeader();
			this.clhSalePrice = new System.Windows.Forms.ColumnHeader();
			this.clhDiff = new System.Windows.Forms.ColumnHeader();
			this.clhOther = new System.Windows.Forms.ColumnHeader();
			this.groupBox1.SuspendLayout();
			this.tabAcct.SuspendLayout();
			this.tabPageUnAcct.SuspendLayout();
			this.tabPageEnAcct.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.m_txtSaleTolMoney);
			this.groupBox1.Controls.Add(this.m_txtBuyTolMoney);
			this.groupBox1.Controls.Add(this.m_dtbCreateDate);
			this.groupBox1.Controls.Add(this.m_txtOrdID);
			this.groupBox1.Controls.Add(this.m_txtAduit);
			this.groupBox1.Controls.Add(this.m_txtCreator);
			this.groupBox1.Controls.Add(this.m_txtOrdType);
			this.groupBox1.Controls.Add(this.m_txtMedStore);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(0, 40);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(792, 80);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(568, 54);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(63, 19);
			this.label11.TabIndex = 15;
			this.label11.Text = "零售金额";
			// 
			// m_txtSaleTolMoney
			// 
			this.m_txtSaleTolMoney.EnableAutoValidation = true;
			this.m_txtSaleTolMoney.Enabled = false;
			this.m_txtSaleTolMoney.EnableEnterKeyValidate = true;
			this.m_txtSaleTolMoney.EnableEscapeKeyUndo = true;
			this.m_txtSaleTolMoney.EnableLastValidValue = true;
			this.m_txtSaleTolMoney.ErrorProvider = null;
			this.m_txtSaleTolMoney.ErrorProviderMessage = "Invalid value";
			this.m_txtSaleTolMoney.ForceFormatText = true;
			this.m_txtSaleTolMoney.Location = new System.Drawing.Point(632, 48);
			this.m_txtSaleTolMoney.Name = "m_txtSaleTolMoney";
			this.m_txtSaleTolMoney.TabIndex = 14;
			this.m_txtSaleTolMoney.Text = "";
			// 
			// m_txtBuyTolMoney
			// 
			this.m_txtBuyTolMoney.EnableAutoValidation = false;
			this.m_txtBuyTolMoney.Enabled = false;
			this.m_txtBuyTolMoney.EnableEnterKeyValidate = true;
			this.m_txtBuyTolMoney.EnableEscapeKeyUndo = true;
			this.m_txtBuyTolMoney.EnableLastValidValue = true;
			this.m_txtBuyTolMoney.ErrorProvider = null;
			this.m_txtBuyTolMoney.ErrorProviderMessage = "Invalid value";
			this.m_txtBuyTolMoney.ForceFormatText = true;
			this.m_txtBuyTolMoney.Location = new System.Drawing.Point(448, 48);
			this.m_txtBuyTolMoney.Name = "m_txtBuyTolMoney";
			this.m_txtBuyTolMoney.TabIndex = 13;
			this.m_txtBuyTolMoney.Text = "";
			// 
			// m_dtbCreateDate
			// 
			this.m_dtbCreateDate.Enabled = false;
			this.m_dtbCreateDate.Location = new System.Drawing.Point(240, 48);
			this.m_dtbCreateDate.Name = "m_dtbCreateDate";
			this.m_dtbCreateDate.Size = new System.Drawing.Size(128, 23);
			this.m_dtbCreateDate.TabIndex = 12;
			// 
			// m_txtOrdID
			// 
			this.m_txtOrdID.EnableAutoValidation = false;
			this.m_txtOrdID.Enabled = false;
			this.m_txtOrdID.EnableEnterKeyValidate = true;
			this.m_txtOrdID.EnableEscapeKeyUndo = true;
			this.m_txtOrdID.EnableLastValidValue = true;
			this.m_txtOrdID.ErrorProvider = null;
			this.m_txtOrdID.ErrorProviderMessage = "Invalid value";
			this.m_txtOrdID.ForceFormatText = true;
			this.m_txtOrdID.Location = new System.Drawing.Point(56, 48);
			this.m_txtOrdID.Name = "m_txtOrdID";
			this.m_txtOrdID.TabIndex = 11;
			this.m_txtOrdID.Text = "";
			// 
			// m_txtAduit
			// 
			this.m_txtAduit.EnableAutoValidation = false;
			this.m_txtAduit.Enabled = false;
			this.m_txtAduit.EnableEnterKeyValidate = true;
			this.m_txtAduit.EnableEscapeKeyUndo = true;
			this.m_txtAduit.EnableLastValidValue = true;
			this.m_txtAduit.ErrorProvider = null;
			this.m_txtAduit.ErrorProviderMessage = "Invalid value";
			this.m_txtAduit.ForceFormatText = true;
			this.m_txtAduit.Location = new System.Drawing.Point(632, 16);
			this.m_txtAduit.Name = "m_txtAduit";
			this.m_txtAduit.TabIndex = 10;
			this.m_txtAduit.Text = "";
			// 
			// m_txtCreator
			// 
			this.m_txtCreator.EnableAutoValidation = false;
			this.m_txtCreator.Enabled = false;
			this.m_txtCreator.EnableEnterKeyValidate = true;
			this.m_txtCreator.EnableEscapeKeyUndo = true;
			this.m_txtCreator.EnableLastValidValue = true;
			this.m_txtCreator.ErrorProvider = null;
			this.m_txtCreator.ErrorProviderMessage = "Invalid value";
			this.m_txtCreator.ForceFormatText = true;
			this.m_txtCreator.Location = new System.Drawing.Point(448, 16);
			this.m_txtCreator.Name = "m_txtCreator";
			this.m_txtCreator.TabIndex = 9;
			this.m_txtCreator.Text = "";
			// 
			// m_txtOrdType
			// 
			this.m_txtOrdType.EnableAutoValidation = false;
			this.m_txtOrdType.Enabled = false;
			this.m_txtOrdType.EnableEnterKeyValidate = true;
			this.m_txtOrdType.EnableEscapeKeyUndo = true;
			this.m_txtOrdType.EnableLastValidValue = true;
			this.m_txtOrdType.ErrorProvider = null;
			this.m_txtOrdType.ErrorProviderMessage = "Invalid value";
			this.m_txtOrdType.ForceFormatText = true;
			this.m_txtOrdType.Location = new System.Drawing.Point(240, 16);
			this.m_txtOrdType.Name = "m_txtOrdType";
			this.m_txtOrdType.Size = new System.Drawing.Size(128, 23);
			this.m_txtOrdType.TabIndex = 8;
			this.m_txtOrdType.Text = "";
			// 
			// m_txtMedStore
			// 
			this.m_txtMedStore.EnableAutoValidation = false;
			this.m_txtMedStore.Enabled = false;
			this.m_txtMedStore.EnableEnterKeyValidate = true;
			this.m_txtMedStore.EnableEscapeKeyUndo = true;
			this.m_txtMedStore.EnableLastValidValue = true;
			this.m_txtMedStore.ErrorProvider = null;
			this.m_txtMedStore.ErrorProviderMessage = "Invalid value";
			this.m_txtMedStore.ForceFormatText = true;
			this.m_txtMedStore.Location = new System.Drawing.Point(56, 16);
			this.m_txtMedStore.Name = "m_txtMedStore";
			this.m_txtMedStore.TabIndex = 7;
			this.m_txtMedStore.Text = "";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(8, 54);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(48, 19);
			this.label8.TabIndex = 6;
			this.label8.Text = "单据号";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(384, 54);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(63, 19);
			this.label6.TabIndex = 5;
			this.label6.Text = "购进金额";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(176, 54);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(63, 19);
			this.label5.TabIndex = 4;
			this.label5.Text = "创建时间";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(584, 22);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 19);
			this.label4.TabIndex = 3;
			this.label4.Text = "审核员";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(176, 22);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(63, 19);
			this.label3.TabIndex = 2;
			this.label3.Text = "单据类型";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(400, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 19);
			this.label2.TabIndex = 1;
			this.label2.Text = "制单员";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(22, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 19);
			this.label1.TabIndex = 0;
			this.label1.Text = "制单";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(8, 8);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(92, 19);
			this.label7.TabIndex = 1;
			this.label7.Text = "当前帐务期：";
			// 
			// m_txtCurPeriod
			// 
			this.m_txtCurPeriod.BackColor = System.Drawing.Color.White;
			this.m_txtCurPeriod.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtCurPeriod.EnableAutoValidation = true;
			this.m_txtCurPeriod.Enabled = false;
			this.m_txtCurPeriod.EnableEnterKeyValidate = true;
			this.m_txtCurPeriod.EnableEscapeKeyUndo = true;
			this.m_txtCurPeriod.EnableLastValidValue = true;
			this.m_txtCurPeriod.ErrorProvider = null;
			this.m_txtCurPeriod.ErrorProviderMessage = "Invalid value";
			this.m_txtCurPeriod.ForceFormatText = true;
			this.m_txtCurPeriod.Location = new System.Drawing.Point(8, 24);
			this.m_txtCurPeriod.Name = "m_txtCurPeriod";
			this.m_txtCurPeriod.Size = new System.Drawing.Size(168, 16);
			this.m_txtCurPeriod.TabIndex = 2;
			this.m_txtCurPeriod.Text = "";
			// 
			// tabAcct
			// 
			this.tabAcct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.tabAcct.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
			this.tabAcct.Controls.Add(this.tabPageUnAcct);
			this.tabAcct.Controls.Add(this.tabPageEnAcct);
			this.tabAcct.Location = new System.Drawing.Point(0, 128);
			this.tabAcct.Name = "tabAcct";
			this.tabAcct.SelectedIndex = 0;
			this.tabAcct.Size = new System.Drawing.Size(216, 312);
			this.tabAcct.TabIndex = 3;
			// 
			// tabPageUnAcct
			// 
			this.tabPageUnAcct.Controls.Add(this.m_lsvUnAcct);
			this.tabPageUnAcct.Location = new System.Drawing.Point(4, 26);
			this.tabPageUnAcct.Name = "tabPageUnAcct";
			this.tabPageUnAcct.Size = new System.Drawing.Size(208, 282);
			this.tabPageUnAcct.TabIndex = 0;
			this.tabPageUnAcct.Text = "未登帐";
			// 
			// m_lsvUnAcct
			// 
			this.m_lsvUnAcct.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						  this.clhUnRow,
																						  this.clhUnFlag,
																						  this.clhUnID,
																						  this.clhUnType,
																						  this.clhUnCreateDate,
																						  this.clhUnCreator,
																						  this.clhUnAduit,
																						  this.clhUnSign});
			this.m_lsvUnAcct.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_lsvUnAcct.FullRowSelect = true;
			this.m_lsvUnAcct.GridLines = true;
			this.m_lsvUnAcct.Location = new System.Drawing.Point(0, 0);
			this.m_lsvUnAcct.Name = "m_lsvUnAcct";
			this.m_lsvUnAcct.Size = new System.Drawing.Size(208, 282);
			this.m_lsvUnAcct.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.m_lsvUnAcct.TabIndex = 0;
			this.m_lsvUnAcct.View = System.Windows.Forms.View.Details;
			this.m_lsvUnAcct.DoubleClick += new System.EventHandler(this.m_lsvUnAcct_DoubleClick);
			// 
			// clhUnRow
			// 
			this.clhUnRow.Text = "序号";
			this.clhUnRow.Width = 50;
			// 
			// clhUnFlag
			// 
			this.clhUnFlag.Text = "类别";
			this.clhUnFlag.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// clhUnID
			// 
			this.clhUnID.Text = "单据号";
			this.clhUnID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.clhUnID.Width = 100;
			// 
			// clhUnType
			// 
			this.clhUnType.Text = "单据类型";
			this.clhUnType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.clhUnType.Width = 120;
			// 
			// clhUnCreateDate
			// 
			this.clhUnCreateDate.Text = "建单时间";
			this.clhUnCreateDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.clhUnCreateDate.Width = 120;
			// 
			// clhUnCreator
			// 
			this.clhUnCreator.Text = "制单人";
			this.clhUnCreator.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.clhUnCreator.Width = 80;
			// 
			// clhUnAduit
			// 
			this.clhUnAduit.Text = "审核员";
			this.clhUnAduit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.clhUnAduit.Width = 80;
			// 
			// clhUnSign
			// 
			this.clhUnSign.Text = "类别";
			this.clhUnSign.Width = 0;
			// 
			// tabPageEnAcct
			// 
			this.tabPageEnAcct.Controls.Add(this.m_lsvEnAcct);
			this.tabPageEnAcct.Location = new System.Drawing.Point(4, 24);
			this.tabPageEnAcct.Name = "tabPageEnAcct";
			this.tabPageEnAcct.Size = new System.Drawing.Size(208, 284);
			this.tabPageEnAcct.TabIndex = 1;
			this.tabPageEnAcct.Text = "已登帐";
			// 
			// m_lsvEnAcct
			// 
			this.m_lsvEnAcct.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						  this.clhEnRow,
																						  this.clhEnFlag,
																						  this.clhEnID,
																						  this.clhEnType,
																						  this.clhEnCreateDate,
																						  this.clhEnCreator,
																						  this.clhEnAduit,
																						  this.clhEnSign});
			this.m_lsvEnAcct.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_lsvEnAcct.FullRowSelect = true;
			this.m_lsvEnAcct.GridLines = true;
			this.m_lsvEnAcct.Location = new System.Drawing.Point(0, 0);
			this.m_lsvEnAcct.Name = "m_lsvEnAcct";
			this.m_lsvEnAcct.Size = new System.Drawing.Size(208, 284);
			this.m_lsvEnAcct.TabIndex = 0;
			this.m_lsvEnAcct.View = System.Windows.Forms.View.Details;
			this.m_lsvEnAcct.DoubleClick += new System.EventHandler(this.m_lsvEnAcct_DoubleClick);
			// 
			// clhEnRow
			// 
			this.clhEnRow.Text = "序号";
			this.clhEnRow.Width = 50;
			// 
			// clhEnFlag
			// 
			this.clhEnFlag.Text = "类别";
			this.clhEnFlag.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// clhEnID
			// 
			this.clhEnID.Text = "单据号";
			this.clhEnID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.clhEnID.Width = 100;
			// 
			// clhEnType
			// 
			this.clhEnType.Text = "单据类型";
			this.clhEnType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.clhEnType.Width = 120;
			// 
			// clhEnCreateDate
			// 
			this.clhEnCreateDate.Text = "建单时间";
			this.clhEnCreateDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.clhEnCreateDate.Width = 120;
			// 
			// clhEnCreator
			// 
			this.clhEnCreator.Text = "制单人";
			this.clhEnCreator.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.clhEnCreator.Width = 80;
			// 
			// clhEnAduit
			// 
			this.clhEnAduit.Text = "审核员";
			this.clhEnAduit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.clhEnAduit.Width = 80;
			// 
			// clhEnSign
			// 
			this.clhEnSign.Text = "类别";
			this.clhEnSign.Width = 0;
			// 
			// label9
			// 
			this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(16, 448);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(77, 19);
			this.label9.TabIndex = 4;
			this.label9.Text = "选择帐务期";
			// 
			// m_cboSelPeriod
			// 
			this.m_cboSelPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_cboSelPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboSelPeriod.Location = new System.Drawing.Point(16, 472);
			this.m_cboSelPeriod.Name = "m_cboSelPeriod";
			this.m_cboSelPeriod.Size = new System.Drawing.Size(192, 22);
			this.m_cboSelPeriod.TabIndex = 0;
			this.m_cboSelPeriod.SelectedIndexChanged += new System.EventHandler(this.m_cboSelPeriod_SelectedIndexChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.m_cmdClose);
			this.groupBox2.Controls.Add(this.m_cmdPrint);
			this.groupBox2.Controls.Add(this.m_cmdAcct);
			this.groupBox2.Location = new System.Drawing.Point(224, 400);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(568, 112);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
			// 
			// m_cmdClose
			// 
			this.m_cmdClose.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdClose.DefaultScheme = true;
			this.m_cmdClose.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdClose.Hint = "";
			this.m_cmdClose.Location = new System.Drawing.Point(224, 48);
			this.m_cmdClose.Name = "m_cmdClose";
			this.m_cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdClose.Size = new System.Drawing.Size(88, 32);
			this.m_cmdClose.TabIndex = 2;
			this.m_cmdClose.Text = "关闭(&C)";
			this.m_cmdClose.Click += new System.EventHandler(this.m_cmdClose_Click);
			// 
			// m_cmdPrint
			// 
			this.m_cmdPrint.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdPrint.DefaultScheme = true;
			this.m_cmdPrint.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdPrint.Hint = "";
			this.m_cmdPrint.Location = new System.Drawing.Point(112, 48);
			this.m_cmdPrint.Name = "m_cmdPrint";
			this.m_cmdPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdPrint.Size = new System.Drawing.Size(88, 32);
			this.m_cmdPrint.TabIndex = 1;
			this.m_cmdPrint.Text = "打印(&P)";
			// 
			// m_cmdAcct
			// 
			this.m_cmdAcct.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdAcct.DefaultScheme = true;
			this.m_cmdAcct.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdAcct.Hint = "";
			this.m_cmdAcct.Location = new System.Drawing.Point(8, 48);
			this.m_cmdAcct.Name = "m_cmdAcct";
			this.m_cmdAcct.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdAcct.Size = new System.Drawing.Size(88, 32);
			this.m_cmdAcct.TabIndex = 0;
			this.m_cmdAcct.Text = "登帐(&A)";
			this.m_cmdAcct.Click += new System.EventHandler(this.m_cmdAcct_Click);
			// 
			// m_lsvDetail
			// 
			this.m_lsvDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lsvDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						  this.clhRowNo,
																						  this.clhMedID,
																						  this.clhMedName,
																						  this.clhMedSpec,
																						  this.clhUnit,
																						  this.clhQty,
																						  this.clhBuyPrice,
																						  this.clhSalePrice,
																						  this.clhDiff,
																						  this.clhOther});
			this.m_lsvDetail.FullRowSelect = true;
			this.m_lsvDetail.GridLines = true;
			this.m_lsvDetail.Location = new System.Drawing.Point(224, 128);
			this.m_lsvDetail.Name = "m_lsvDetail";
			this.m_lsvDetail.Size = new System.Drawing.Size(568, 272);
			this.m_lsvDetail.TabIndex = 7;
			this.m_lsvDetail.View = System.Windows.Forms.View.Details;
			// 
			// clhRowNo
			// 
			this.clhRowNo.Text = "行号";
			// 
			// clhMedID
			// 
			this.clhMedID.Text = "药品代码";
			this.clhMedID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.clhMedID.Width = 80;
			// 
			// clhMedName
			// 
			this.clhMedName.Text = "药品名称";
			this.clhMedName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.clhMedName.Width = 100;
			// 
			// clhMedSpec
			// 
			this.clhMedSpec.Text = "药品规格";
			this.clhMedSpec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.clhMedSpec.Width = 100;
			// 
			// clhUnit
			// 
			this.clhUnit.Text = "单位";
			this.clhUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.clhUnit.Width = 100;
			// 
			// clhQty
			// 
			this.clhQty.Text = "数量";
			this.clhQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.clhQty.Width = 80;
			// 
			// clhBuyPrice
			// 
			this.clhBuyPrice.Text = "购进价";
			this.clhBuyPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.clhBuyPrice.Width = 80;
			// 
			// clhSalePrice
			// 
			this.clhSalePrice.Text = "零售价";
			this.clhSalePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.clhSalePrice.Width = 80;
			// 
			// clhDiff
			// 
			this.clhDiff.Text = "差额";
			this.clhDiff.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.clhDiff.Width = 80;
			// 
			// clhOther
			// 
			this.clhOther.Text = "";
			this.clhOther.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.clhOther.Width = 0;
			// 
			// frmMedStoreAcct
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(792, 517);
			this.Controls.Add(this.m_lsvDetail);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.m_cboSelPeriod);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.m_txtCurPeriod);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.tabAcct);
			this.Controls.Add(this.groupBox1);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.Name = "frmMedStoreAcct";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "登帐";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmStorageAcct_Load);
			this.groupBox1.ResumeLayout(false);
			this.tabAcct.ResumeLayout(false);
			this.tabPageUnAcct.ResumeLayout(false);
			this.tabPageEnAcct.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		public override void CreateController()
		{
			// TODO:  添加 frmStorageAcct.CreateController 实现
			this.objController = new clsControlMedStoreAcct();
			this.objController.Set_GUI_Apperance(this);
		}

		private void frmStorageAcct_Load(object sender, System.EventArgs e)
		{
			base.m_mthSetFormControlCanBeNull(this);
			((clsControlMedStoreAcct)this.objController).m_mthInit();
		}


		private void m_cboSelPeriod_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			((clsControlMedStoreAcct)this.objController).m_mthPeriodSel();
		}

		private void m_cmdAcct_Click(object sender, System.EventArgs e)
		{
			((clsControlMedStoreAcct)this.objController).m_mthAcct();
		}

		private void m_cmdClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void m_lsvUnAcct_DoubleClick(object sender, System.EventArgs e)
		{
			((clsControlMedStoreAcct)this.objController).m_mthAcctListSel(true);
		}

		private void m_lsvEnAcct_DoubleClick(object sender, System.EventArgs e)
		{
			((clsControlMedStoreAcct)this.objController).m_mthAcctListSel(false);
		
		}

		private void groupBox2_Enter(object sender, System.EventArgs e)
		{
		
		}
	}
}
