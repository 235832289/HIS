using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 药房出药窗口
	/// Create by kong 2004-07-08
	/// </summary>
	public class frmMedStoreOutOrd : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		internal System.Windows.Forms.ToolBarButton tbrNew;
		internal System.Windows.Forms.ToolBarButton tbrAduit;
		internal System.Windows.Forms.ToolBarButton tbrSave;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		internal System.Windows.Forms.ToolBarButton tbrAdd;
		internal System.Windows.Forms.ToolBarButton tbrInsert;
		internal System.Windows.Forms.ToolBarButton tbrDelete;
		internal System.Windows.Forms.ToolBarButton toolBarButton2;
		internal System.Windows.Forms.ToolBarButton tbrPreView;
		internal System.Windows.Forms.ToolBarButton tbrPrint;
		private System.Windows.Forms.ToolBarButton tbrClose;
		private System.Windows.Forms.Label label1;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtCurPeriod;
		internal System.Windows.Forms.Label m_lblTitle;
		internal System.Windows.Forms.ComboBox m_cboOrdType;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		internal System.Windows.Forms.ToolBarButton tbrFind;
		internal System.Windows.Forms.ToolBarButton tbrImp;
		private System.Windows.Forms.ToolBarButton toolBarButton3;
		internal System.Windows.Forms.ComboBox m_cboSelPeriod;
		private System.Windows.Forms.Label label7;
		internal System.Windows.Forms.ListView m_lsvUnAduit;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		internal System.Windows.Forms.ListView m_lsvEnAduit;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		internal System.Windows.Forms.ListView m_lsvDetail;
		private System.Windows.Forms.ColumnHeader m_clhRowNO;
		private System.Windows.Forms.ColumnHeader m_clhMedID;
		private System.Windows.Forms.ColumnHeader m_clhMedName;
		private System.Windows.Forms.ColumnHeader m_clhMedSpec;
		private System.Windows.Forms.ColumnHeader m_clhMedUnit;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ColumnHeader m_clhSalePrice;
		private System.Windows.Forms.ColumnHeader m_clhTolSalePrice;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtMedName;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtMedSpec;
		internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric m_txtQty;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtUnit;
		internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric m_txtSalePrice;
		internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric m_txtTolSalePrice;
		internal PinkieControls.ButtonXP m_cmdConfirm;
		private System.Windows.Forms.GroupBox groupBox1;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtPeriod;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtOrdID;
		internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric m_txtTolMoney;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtMemo;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtAduit;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtMedStore;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ColumnHeader m_clhQty;
		internal com.digitalwave.iCare.gui.HIS.ctlMedStoreDetail m_txtMedID;
		private System.Windows.Forms.ToolBar m_tbr;
		internal System.Windows.Forms.ListView m_lsvPopUnit;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.ColumnHeader columnHeader12;
		private System.Windows.Forms.ColumnHeader columnHeader13;
		private System.Windows.Forms.ColumnHeader columnHeader14;
		internal System.Windows.Forms.DateTimePicker m_dtpCreateDate;
		internal com.digitalwave.controls.datagrid.ctlDataGrid DgMedicine;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// 
		/// </summary>
		public frmMedStoreOutOrd()
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
			com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo1 = new com.digitalwave.controls.datagrid.clsColumnInfo();
			com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo2 = new com.digitalwave.controls.datagrid.clsColumnInfo();
			com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo3 = new com.digitalwave.controls.datagrid.clsColumnInfo();
			com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo4 = new com.digitalwave.controls.datagrid.clsColumnInfo();
			this.m_tbr = new System.Windows.Forms.ToolBar();
			this.tbrNew = new System.Windows.Forms.ToolBarButton();
			this.tbrSave = new System.Windows.Forms.ToolBarButton();
			this.tbrAduit = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.tbrFind = new System.Windows.Forms.ToolBarButton();
			this.tbrImp = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
			this.tbrAdd = new System.Windows.Forms.ToolBarButton();
			this.tbrInsert = new System.Windows.Forms.ToolBarButton();
			this.tbrDelete = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
			this.tbrPreView = new System.Windows.Forms.ToolBarButton();
			this.tbrPrint = new System.Windows.Forms.ToolBarButton();
			this.tbrClose = new System.Windows.Forms.ToolBarButton();
			this.label1 = new System.Windows.Forms.Label();
			this.m_txtCurPeriod = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.m_lblTitle = new System.Windows.Forms.Label();
			this.m_cboOrdType = new System.Windows.Forms.ComboBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.m_lsvUnAduit = new System.Windows.Forms.ListView();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.m_lsvEnAduit = new System.Windows.Forms.ListView();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
			this.m_cboSelPeriod = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.m_lsvDetail = new System.Windows.Forms.ListView();
			this.m_clhRowNO = new System.Windows.Forms.ColumnHeader();
			this.m_clhMedID = new System.Windows.Forms.ColumnHeader();
			this.m_clhMedName = new System.Windows.Forms.ColumnHeader();
			this.m_clhMedSpec = new System.Windows.Forms.ColumnHeader();
			this.m_clhMedUnit = new System.Windows.Forms.ColumnHeader();
			this.m_clhQty = new System.Windows.Forms.ColumnHeader();
			this.m_clhSalePrice = new System.Windows.Forms.ColumnHeader();
			this.m_clhTolSalePrice = new System.Windows.Forms.ColumnHeader();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.DgMedicine = new com.digitalwave.controls.datagrid.ctlDataGrid();
			this.m_lsvPopUnit = new System.Windows.Forms.ListView();
			this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
			this.m_txtMedID = new com.digitalwave.iCare.gui.HIS.ctlMedStoreDetail();
			this.m_cmdConfirm = new PinkieControls.ButtonXP();
			this.m_txtTolSalePrice = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
			this.m_txtSalePrice = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
			this.m_txtUnit = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.m_txtMedSpec = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.m_txtMedName = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.label16 = new System.Windows.Forms.Label();
			this.m_txtQty = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
			this.label15 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.m_txtPeriod = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.m_txtOrdID = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.m_txtTolMoney = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
			this.m_txtMemo = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.m_txtAduit = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.m_dtpCreateDate = new System.Windows.Forms.DateTimePicker();
			this.m_txtMedStore = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DgMedicine)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_tbr
			// 
			this.m_tbr.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.m_tbr.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																					 this.tbrNew,
																					 this.tbrSave,
																					 this.tbrAduit,
																					 this.toolBarButton1,
																					 this.tbrFind,
																					 this.tbrImp,
																					 this.toolBarButton3,
																					 this.tbrAdd,
																					 this.tbrInsert,
																					 this.tbrDelete,
																					 this.toolBarButton2,
																					 this.tbrPreView,
																					 this.tbrPrint,
																					 this.tbrClose});
			this.m_tbr.DropDownArrows = true;
			this.m_tbr.Location = new System.Drawing.Point(0, 0);
			this.m_tbr.Name = "m_tbr";
			this.m_tbr.ShowToolTips = true;
			this.m_tbr.Size = new System.Drawing.Size(864, 43);
			this.m_tbr.TabIndex = 0;
			this.m_tbr.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.m_tbr_ButtonClick);
			// 
			// tbrNew
			// 
			this.tbrNew.Text = "新建";
			this.tbrNew.ToolTipText = "新建单据";
			// 
			// tbrSave
			// 
			this.tbrSave.Text = "保存";
			this.tbrSave.ToolTipText = "保存单据";
			// 
			// tbrAduit
			// 
			this.tbrAduit.Text = "审核";
			this.tbrAduit.ToolTipText = "审核单据";
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbrFind
			// 
			this.tbrFind.Text = "查找";
			this.tbrFind.ToolTipText = "查找单据";
			// 
			// tbrImp
			// 
			this.tbrImp.Text = "导入";
			this.tbrImp.ToolTipText = "导入单据";
			// 
			// toolBarButton3
			// 
			this.toolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbrAdd
			// 
			this.tbrAdd.Text = "增加";
			this.tbrAdd.ToolTipText = "增加一条记录";
			// 
			// tbrInsert
			// 
			this.tbrInsert.Text = "插入";
			this.tbrInsert.ToolTipText = "插入一条记录";
			// 
			// tbrDelete
			// 
			this.tbrDelete.Text = "删除";
			this.tbrDelete.ToolTipText = "删除一条记录";
			// 
			// toolBarButton2
			// 
			this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbrPreView
			// 
			this.tbrPreView.Text = "预览";
			this.tbrPreView.ToolTipText = "预览单据";
			// 
			// tbrPrint
			// 
			this.tbrPrint.Text = "打印";
			this.tbrPrint.ToolTipText = "打印单据";
			this.tbrPrint.Visible = false;
			// 
			// tbrClose
			// 
			this.tbrClose.Text = "关闭";
			this.tbrClose.ToolTipText = "关闭窗口";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(92, 19);
			this.label1.TabIndex = 1;
			this.label1.Text = "当前帐务期：";
			// 
			// m_txtCurPeriod
			// 
			this.m_txtCurPeriod.EnableAutoValidation = false;
			this.m_txtCurPeriod.Enabled = false;
			this.m_txtCurPeriod.EnableEnterKeyValidate = true;
			this.m_txtCurPeriod.EnableEscapeKeyUndo = true;
			this.m_txtCurPeriod.EnableLastValidValue = true;
			this.m_txtCurPeriod.ErrorProvider = null;
			this.m_txtCurPeriod.ErrorProviderMessage = "Invalid value";
			this.m_txtCurPeriod.ForceFormatText = true;
			this.m_txtCurPeriod.Location = new System.Drawing.Point(8, 72);
			this.m_txtCurPeriod.Name = "m_txtCurPeriod";
			this.m_txtCurPeriod.Size = new System.Drawing.Size(152, 23);
			this.m_txtCurPeriod.TabIndex = 2;
			this.m_txtCurPeriod.Text = "";
			// 
			// m_lblTitle
			// 
			this.m_lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lblTitle.Font = new System.Drawing.Font("楷体_GB2312", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lblTitle.Location = new System.Drawing.Point(176, 64);
			this.m_lblTitle.Name = "m_lblTitle";
			this.m_lblTitle.Size = new System.Drawing.Size(544, 24);
			this.m_lblTitle.TabIndex = 3;
			this.m_lblTitle.Text = "药房出药";
			this.m_lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_cboOrdType
			// 
			this.m_cboOrdType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_cboOrdType.Location = new System.Drawing.Point(728, 64);
			this.m_cboOrdType.Name = "m_cboOrdType";
			this.m_cboOrdType.Size = new System.Drawing.Size(128, 22);
			this.m_cboOrdType.TabIndex = 1;
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(0, 192);
			this.tabControl1.Multiline = true;
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(208, 408);
			this.tabControl1.TabIndex = 20;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.m_lsvUnAduit);
			this.tabPage1.Location = new System.Drawing.Point(4, 26);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(200, 378);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "未审核";
			// 
			// m_lsvUnAduit
			// 
			this.m_lsvUnAduit.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						   this.columnHeader5,
																						   this.columnHeader7,
																						   this.columnHeader6});
			this.m_lsvUnAduit.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_lsvUnAduit.FullRowSelect = true;
			this.m_lsvUnAduit.GridLines = true;
			this.m_lsvUnAduit.Location = new System.Drawing.Point(0, 0);
			this.m_lsvUnAduit.Name = "m_lsvUnAduit";
			this.m_lsvUnAduit.Size = new System.Drawing.Size(200, 378);
			this.m_lsvUnAduit.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.m_lsvUnAduit.TabIndex = 1;
			this.m_lsvUnAduit.View = System.Windows.Forms.View.Details;
			this.m_lsvUnAduit.DoubleClick += new System.EventHandler(this.m_lsvUnAduit_DoubleClick);
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "单据号";
			this.columnHeader5.Width = 80;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "单据类型";
			this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader7.Width = 100;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "创建时间";
			this.columnHeader6.Width = 120;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.m_lsvEnAduit);
			this.tabPage2.Location = new System.Drawing.Point(4, 24);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(200, 380);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "审核";
			// 
			// m_lsvEnAduit
			// 
			this.m_lsvEnAduit.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						   this.columnHeader8,
																						   this.columnHeader9,
																						   this.columnHeader10});
			this.m_lsvEnAduit.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_lsvEnAduit.ForeColor = System.Drawing.SystemColors.WindowText;
			this.m_lsvEnAduit.FullRowSelect = true;
			this.m_lsvEnAduit.GridLines = true;
			this.m_lsvEnAduit.Location = new System.Drawing.Point(0, 0);
			this.m_lsvEnAduit.Name = "m_lsvEnAduit";
			this.m_lsvEnAduit.Size = new System.Drawing.Size(200, 380);
			this.m_lsvEnAduit.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.m_lsvEnAduit.TabIndex = 1;
			this.m_lsvEnAduit.View = System.Windows.Forms.View.Details;
			this.m_lsvEnAduit.DoubleClick += new System.EventHandler(this.m_lsvEnAduit_DoubleClick);
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "单据号";
			this.columnHeader8.Width = 80;
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "单据类型";
			this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader9.Width = 100;
			// 
			// columnHeader10
			// 
			this.columnHeader10.Text = "创建时间";
			this.columnHeader10.Width = 120;
			// 
			// m_cboSelPeriod
			// 
			this.m_cboSelPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_cboSelPeriod.Location = new System.Drawing.Point(8, 624);
			this.m_cboSelPeriod.Name = "m_cboSelPeriod";
			this.m_cboSelPeriod.Size = new System.Drawing.Size(200, 22);
			this.m_cboSelPeriod.TabIndex = 19;
			this.m_cboSelPeriod.SelectedIndexChanged += new System.EventHandler(this.m_cboSelPeriod_SelectedIndexChanged);
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label7.Location = new System.Drawing.Point(24, 608);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(80, 16);
			this.label7.TabIndex = 11;
			this.label7.Text = "选择帐务期";
			// 
			// m_lsvDetail
			// 
			this.m_lsvDetail.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
			this.m_lsvDetail.AllowColumnReorder = true;
			this.m_lsvDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lsvDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						  this.m_clhRowNO,
																						  this.m_clhMedID,
																						  this.m_clhMedName,
																						  this.m_clhMedSpec,
																						  this.m_clhMedUnit,
																						  this.m_clhQty,
																						  this.m_clhSalePrice,
																						  this.m_clhTolSalePrice});
			this.m_lsvDetail.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lsvDetail.FullRowSelect = true;
			this.m_lsvDetail.GridLines = true;
			this.m_lsvDetail.HoverSelection = true;
			this.m_lsvDetail.Location = new System.Drawing.Point(216, 192);
			this.m_lsvDetail.Name = "m_lsvDetail";
			this.m_lsvDetail.Size = new System.Drawing.Size(640, 304);
			this.m_lsvDetail.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.m_lsvDetail.TabIndex = 12;
			this.m_lsvDetail.View = System.Windows.Forms.View.Details;
			this.m_lsvDetail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_lsvDetail_KeyDown);
			this.m_lsvDetail.DoubleClick += new System.EventHandler(this.m_lsvDetail_DoubleClick);
			// 
			// m_clhRowNO
			// 
			this.m_clhRowNO.Text = "行号";
			this.m_clhRowNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// m_clhMedID
			// 
			this.m_clhMedID.Text = "代码";
			this.m_clhMedID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// m_clhMedName
			// 
			this.m_clhMedName.Text = "名称";
			this.m_clhMedName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.m_clhMedName.Width = 150;
			// 
			// m_clhMedSpec
			// 
			this.m_clhMedSpec.Text = "规格";
			this.m_clhMedSpec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.m_clhMedSpec.Width = 120;
			// 
			// m_clhMedUnit
			// 
			this.m_clhMedUnit.Text = "单位";
			this.m_clhMedUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.m_clhMedUnit.Width = 100;
			// 
			// m_clhQty
			// 
			this.m_clhQty.Text = "数量";
			this.m_clhQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.m_clhQty.Width = 80;
			// 
			// m_clhSalePrice
			// 
			this.m_clhSalePrice.Text = "零售价";
			this.m_clhSalePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.m_clhSalePrice.Width = 100;
			// 
			// m_clhTolSalePrice
			// 
			this.m_clhTolSalePrice.Text = "零售总额";
			this.m_clhTolSalePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.m_clhTolSalePrice.Width = 100;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.DgMedicine);
			this.groupBox2.Controls.Add(this.m_lsvPopUnit);
			this.groupBox2.Controls.Add(this.m_txtMedID);
			this.groupBox2.Controls.Add(this.m_cmdConfirm);
			this.groupBox2.Controls.Add(this.m_txtTolSalePrice);
			this.groupBox2.Controls.Add(this.m_txtSalePrice);
			this.groupBox2.Controls.Add(this.m_txtUnit);
			this.groupBox2.Controls.Add(this.m_txtMedSpec);
			this.groupBox2.Controls.Add(this.m_txtMedName);
			this.groupBox2.Controls.Add(this.label16);
			this.groupBox2.Controls.Add(this.m_txtQty);
			this.groupBox2.Controls.Add(this.label15);
			this.groupBox2.Controls.Add(this.label14);
			this.groupBox2.Controls.Add(this.label13);
			this.groupBox2.Controls.Add(this.label12);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Location = new System.Drawing.Point(216, 496);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(648, 144);
			this.groupBox2.TabIndex = 13;
			this.groupBox2.TabStop = false;
			// 
			// DgMedicine
			// 
			this.DgMedicine.AllowAddNew = false;
			this.DgMedicine.AllowDelete = false;
			this.DgMedicine.AutoAppendRow = false;
			this.DgMedicine.AutoScroll = true;
			this.DgMedicine.CaptionText = "";
			this.DgMedicine.CaptionVisible = false;
			this.DgMedicine.ColumnHeadersVisible = true;
			clsColumnInfo1.BackColor = System.Drawing.Color.White;
			clsColumnInfo1.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo1.ColumnIndex = 0;
			clsColumnInfo1.ColumnName = "MEDICINEID_CHR";
			clsColumnInfo1.ColumnWidth = 75;
			clsColumnInfo1.Enabled = false;
			clsColumnInfo1.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo1.HeadText = "药品代码";
			clsColumnInfo1.ReadOnly = true;
			clsColumnInfo1.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo2.BackColor = System.Drawing.Color.White;
			clsColumnInfo2.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo2.ColumnIndex = 1;
			clsColumnInfo2.ColumnName = "MEDICINENAME_VCHR";
			clsColumnInfo2.ColumnWidth = 75;
			clsColumnInfo2.Enabled = false;
			clsColumnInfo2.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo2.HeadText = "药品名称";
			clsColumnInfo2.ReadOnly = true;
			clsColumnInfo2.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo3.BackColor = System.Drawing.Color.White;
			clsColumnInfo3.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo3.ColumnIndex = 2;
			clsColumnInfo3.ColumnName = "MEDSPEC_VCHR";
			clsColumnInfo3.ColumnWidth = 75;
			clsColumnInfo3.Enabled = false;
			clsColumnInfo3.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo3.HeadText = "规格";
			clsColumnInfo3.ReadOnly = true;
			clsColumnInfo3.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo4.BackColor = System.Drawing.Color.White;
			clsColumnInfo4.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo4.ColumnIndex = 3;
			clsColumnInfo4.ColumnName = "OPUNIT_CHR";
			clsColumnInfo4.ColumnWidth = 75;
			clsColumnInfo4.Enabled = false;
			clsColumnInfo4.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo4.HeadText = "单位";
			clsColumnInfo4.ReadOnly = true;
			clsColumnInfo4.TextFont = new System.Drawing.Font("宋体", 10F);
			this.DgMedicine.Columns.Add(clsColumnInfo1);
			this.DgMedicine.Columns.Add(clsColumnInfo2);
			this.DgMedicine.Columns.Add(clsColumnInfo3);
			this.DgMedicine.Columns.Add(clsColumnInfo4);
			this.DgMedicine.FullRowSelect = true;
			this.DgMedicine.Location = new System.Drawing.Point(80, 48);
			this.DgMedicine.Name = "DgMedicine";
			this.DgMedicine.ReadOnly = false;
			this.DgMedicine.RowHeadersVisible = true;
			this.DgMedicine.RowHeaderWidth = 35;
			this.DgMedicine.Size = new System.Drawing.Size(336, 128);
			this.DgMedicine.TabIndex = 46;
			this.DgMedicine.Visible = false;
			this.DgMedicine.VisibleChanged += new System.EventHandler(this.DgMedicine_VisibleChanged);
			this.DgMedicine.m_evtDoubleClickCell += new com.digitalwave.controls.datagrid.clsDGTextMouseClickEventHandler(this.DgMedicine_m_evtDoubleClickCell);
			// 
			// m_lsvPopUnit
			// 
			this.m_lsvPopUnit.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						   this.columnHeader11,
																						   this.columnHeader12,
																						   this.columnHeader13,
																						   this.columnHeader14});
			this.m_lsvPopUnit.FullRowSelect = true;
			this.m_lsvPopUnit.GridLines = true;
			this.m_lsvPopUnit.Location = new System.Drawing.Point(88, 88);
			this.m_lsvPopUnit.Name = "m_lsvPopUnit";
			this.m_lsvPopUnit.Size = new System.Drawing.Size(304, 54);
			this.m_lsvPopUnit.TabIndex = 45;
			this.m_lsvPopUnit.View = System.Windows.Forms.View.Details;
			this.m_lsvPopUnit.Visible = false;
			this.m_lsvPopUnit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_lsvPopUnit_KeyDown);
			this.m_lsvPopUnit.DoubleClick += new System.EventHandler(this.m_lsvPopUnit_DoubleClick);
			// 
			// columnHeader11
			// 
			this.columnHeader11.Text = "单位代码";
			this.columnHeader11.Width = 80;
			// 
			// columnHeader12
			// 
			this.columnHeader12.Text = "单位名称";
			this.columnHeader12.Width = 80;
			// 
			// columnHeader13
			// 
			this.columnHeader13.Text = "比例关系";
			this.columnHeader13.Width = 80;
			// 
			// columnHeader14
			// 
			this.columnHeader14.Text = "级别";
			// 
			// m_txtMedID
			// 
			this.m_txtMedID.EnableAutoValidation = false;
			this.m_txtMedID.EnableEnterKeyValidate = true;
			this.m_txtMedID.EnableEscapeKeyUndo = true;
			this.m_txtMedID.EnableLastValidValue = true;
			this.m_txtMedID.ErrorProvider = null;
			this.m_txtMedID.ErrorProviderMessage = "Invalid value";
			this.m_txtMedID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtMedID.ForceFormatText = true;
			this.m_txtMedID.ListViewHeight = 120;
			this.m_txtMedID.ListViewWidth = 450;
			this.m_txtMedID.Location = new System.Drawing.Point(80, 24);
			this.m_txtMedID.Name = "m_txtMedID";
			this.m_txtMedID.Size = new System.Drawing.Size(112, 23);
			this.m_txtMedID.strStorageID = "";
			this.m_txtMedID.TabIndex = 5;
			this.m_txtMedID.Text = "";
			this.m_txtMedID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtMedID_KeyDown);
			this.m_txtMedID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtMedID_KeyPress);
			// 
			// m_cmdConfirm
			// 
			this.m_cmdConfirm.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdConfirm.DefaultScheme = true;
			this.m_cmdConfirm.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdConfirm.Hint = "";
			this.m_cmdConfirm.Location = new System.Drawing.Point(496, 104);
			this.m_cmdConfirm.Name = "m_cmdConfirm";
			this.m_cmdConfirm.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdConfirm.Size = new System.Drawing.Size(120, 32);
			this.m_cmdConfirm.TabIndex = 8;
			this.m_cmdConfirm.Text = "确定(&S)";
			this.m_cmdConfirm.Click += new System.EventHandler(this.m_cmdConfirm_Click);
			// 
			// m_txtTolSalePrice
			// 
			this.m_txtTolSalePrice.EnableAutoValidation = false;
			this.m_txtTolSalePrice.Enabled = false;
			this.m_txtTolSalePrice.EnableEnterKeyValidate = true;
			this.m_txtTolSalePrice.EnableEscapeKeyUndo = true;
			this.m_txtTolSalePrice.EnableLastValidValue = true;
			this.m_txtTolSalePrice.ErrorProvider = null;
			this.m_txtTolSalePrice.ErrorProviderMessage = "Invalid value";
			this.m_txtTolSalePrice.ForceFormatText = true;
			this.m_txtTolSalePrice.Location = new System.Drawing.Point(80, 118);
			this.m_txtTolSalePrice.Name = "m_txtTolSalePrice";
			this.m_txtTolSalePrice.NumericCharStyle = ((SourceLibrary.Windows.Forms.NumericCharStyle)((SourceLibrary.Windows.Forms.NumericCharStyle.DecimalSeparator | SourceLibrary.Windows.Forms.NumericCharStyle.NegativeSymbol)));
			this.m_txtTolSalePrice.TabIndex = 13;
			this.m_txtTolSalePrice.Text = "";
			this.m_txtTolSalePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_txtSalePrice
			// 
			this.m_txtSalePrice.EnableAutoValidation = false;
			this.m_txtSalePrice.EnableEnterKeyValidate = true;
			this.m_txtSalePrice.EnableEscapeKeyUndo = true;
			this.m_txtSalePrice.EnableLastValidValue = true;
			this.m_txtSalePrice.ErrorProvider = null;
			this.m_txtSalePrice.ErrorProviderMessage = "Invalid value";
			this.m_txtSalePrice.ForceFormatText = true;
			this.m_txtSalePrice.Location = new System.Drawing.Point(288, 68);
			this.m_txtSalePrice.Name = "m_txtSalePrice";
			this.m_txtSalePrice.NumericCharStyle = ((SourceLibrary.Windows.Forms.NumericCharStyle)((SourceLibrary.Windows.Forms.NumericCharStyle.DecimalSeparator | SourceLibrary.Windows.Forms.NumericCharStyle.NegativeSymbol)));
			this.m_txtSalePrice.TabIndex = 6;
			this.m_txtSalePrice.Text = "";
			this.m_txtSalePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_txtSalePrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_Calc_KeyDown);
			// 
			// m_txtUnit
			// 
			this.m_txtUnit.EnableAutoValidation = false;
			this.m_txtUnit.EnableEnterKeyValidate = true;
			this.m_txtUnit.EnableEscapeKeyUndo = true;
			this.m_txtUnit.EnableLastValidValue = true;
			this.m_txtUnit.ErrorProvider = null;
			this.m_txtUnit.ErrorProviderMessage = "Invalid value";
			this.m_txtUnit.ForceFormatText = true;
			this.m_txtUnit.Location = new System.Drawing.Point(80, 68);
			this.m_txtUnit.Name = "m_txtUnit";
			this.m_txtUnit.TabIndex = 9;
			this.m_txtUnit.Text = "";
			this.m_txtUnit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtUnit_KeyDown);
			// 
			// m_txtMedSpec
			// 
			this.m_txtMedSpec.EnableAutoValidation = false;
			this.m_txtMedSpec.Enabled = false;
			this.m_txtMedSpec.EnableEnterKeyValidate = true;
			this.m_txtMedSpec.EnableEscapeKeyUndo = true;
			this.m_txtMedSpec.EnableLastValidValue = true;
			this.m_txtMedSpec.ErrorProvider = null;
			this.m_txtMedSpec.ErrorProviderMessage = "Invalid value";
			this.m_txtMedSpec.ForceFormatText = true;
			this.m_txtMedSpec.Location = new System.Drawing.Point(512, 24);
			this.m_txtMedSpec.Name = "m_txtMedSpec";
			this.m_txtMedSpec.TabIndex = 10;
			this.m_txtMedSpec.Text = "";
			// 
			// m_txtMedName
			// 
			this.m_txtMedName.EnableAutoValidation = false;
			this.m_txtMedName.Enabled = false;
			this.m_txtMedName.EnableEnterKeyValidate = true;
			this.m_txtMedName.EnableEscapeKeyUndo = true;
			this.m_txtMedName.EnableLastValidValue = true;
			this.m_txtMedName.ErrorProvider = null;
			this.m_txtMedName.ErrorProviderMessage = "Invalid value";
			this.m_txtMedName.ForceFormatText = true;
			this.m_txtMedName.Location = new System.Drawing.Point(288, 24);
			this.m_txtMedName.Name = "m_txtMedName";
			this.m_txtMedName.Size = new System.Drawing.Size(120, 23);
			this.m_txtMedName.TabIndex = 9;
			this.m_txtMedName.Text = "";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(472, 66);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(34, 19);
			this.label16.TabIndex = 7;
			this.label16.Text = "数量";
			// 
			// m_txtQty
			// 
			this.m_txtQty.EnableAutoValidation = false;
			this.m_txtQty.EnableEnterKeyValidate = true;
			this.m_txtQty.EnableEscapeKeyUndo = true;
			this.m_txtQty.EnableLastValidValue = true;
			this.m_txtQty.ErrorProvider = null;
			this.m_txtQty.ErrorProviderMessage = "Invalid value";
			this.m_txtQty.ForceFormatText = true;
			this.m_txtQty.Location = new System.Drawing.Point(512, 64);
			this.m_txtQty.Name = "m_txtQty";
			this.m_txtQty.NumericCharStyle = ((SourceLibrary.Windows.Forms.NumericCharStyle)((SourceLibrary.Windows.Forms.NumericCharStyle.DecimalSeparator | SourceLibrary.Windows.Forms.NumericCharStyle.NegativeSymbol)));
			this.m_txtQty.TabIndex = 7;
			this.m_txtQty.Text = "";
			this.m_txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_txtQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_Calc_KeyDown);
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(8, 120);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(63, 19);
			this.label15.TabIndex = 5;
			this.label15.Text = "零售总额";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(232, 72);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(48, 19);
			this.label14.TabIndex = 4;
			this.label14.Text = "零售价";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(37, 72);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(34, 19);
			this.label13.TabIndex = 3;
			this.label13.Text = "单位";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(440, 28);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(63, 19);
			this.label12.TabIndex = 2;
			this.label12.Text = "药品规格";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(217, 28);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(63, 19);
			this.label11.TabIndex = 1;
			this.label11.Text = "药品名称";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(8, 28);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(63, 19);
			this.label10.TabIndex = 0;
			this.label10.Text = "药品代码";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.m_txtPeriod);
			this.groupBox1.Controls.Add(this.m_txtOrdID);
			this.groupBox1.Controls.Add(this.m_txtTolMoney);
			this.groupBox1.Controls.Add(this.m_txtMemo);
			this.groupBox1.Controls.Add(this.m_txtAduit);
			this.groupBox1.Controls.Add(this.m_dtpCreateDate);
			this.groupBox1.Controls.Add(this.m_txtMedStore);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Location = new System.Drawing.Point(0, 96);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(864, 80);
			this.groupBox1.TabIndex = 14;
			this.groupBox1.TabStop = false;
			// 
			// m_txtPeriod
			// 
			this.m_txtPeriod.EnableAutoValidation = false;
			this.m_txtPeriod.Enabled = false;
			this.m_txtPeriod.EnableEnterKeyValidate = true;
			this.m_txtPeriod.EnableEscapeKeyUndo = true;
			this.m_txtPeriod.EnableLastValidValue = true;
			this.m_txtPeriod.ErrorProvider = null;
			this.m_txtPeriod.ErrorProviderMessage = "Invalid value";
			this.m_txtPeriod.ForceFormatText = true;
			this.m_txtPeriod.Location = new System.Drawing.Point(176, 48);
			this.m_txtPeriod.Name = "m_txtPeriod";
			this.m_txtPeriod.Size = new System.Drawing.Size(24, 23);
			this.m_txtPeriod.TabIndex = 14;
			this.m_txtPeriod.Text = "";
			this.m_txtPeriod.Visible = false;
			// 
			// m_txtOrdID
			// 
			this.m_txtOrdID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtOrdID.EnableAutoValidation = false;
			this.m_txtOrdID.EnableEnterKeyValidate = true;
			this.m_txtOrdID.EnableEscapeKeyUndo = true;
			this.m_txtOrdID.EnableLastValidValue = true;
			this.m_txtOrdID.ErrorProvider = null;
			this.m_txtOrdID.ErrorProviderMessage = "Invalid value";
			this.m_txtOrdID.ForceFormatText = true;
			this.m_txtOrdID.Location = new System.Drawing.Point(520, 20);
			this.m_txtOrdID.Name = "m_txtOrdID";
			this.m_txtOrdID.Size = new System.Drawing.Size(320, 23);
			this.m_txtOrdID.TabIndex = 3;
			this.m_txtOrdID.Text = "";
			// 
			// m_txtTolMoney
			// 
			this.m_txtTolMoney.EnableAutoValidation = false;
			this.m_txtTolMoney.Enabled = false;
			this.m_txtTolMoney.EnableEnterKeyValidate = true;
			this.m_txtTolMoney.EnableEscapeKeyUndo = true;
			this.m_txtTolMoney.EnableLastValidValue = true;
			this.m_txtTolMoney.ErrorProvider = null;
			this.m_txtTolMoney.ErrorProviderMessage = "Invalid value";
			this.m_txtTolMoney.ForceFormatText = true;
			this.m_txtTolMoney.Location = new System.Drawing.Point(272, 48);
			this.m_txtTolMoney.Name = "m_txtTolMoney";
			this.m_txtTolMoney.NumericCharStyle = ((SourceLibrary.Windows.Forms.NumericCharStyle)((SourceLibrary.Windows.Forms.NumericCharStyle.DecimalSeparator | SourceLibrary.Windows.Forms.NumericCharStyle.NegativeSymbol)));
			this.m_txtTolMoney.TabIndex = 12;
			this.m_txtTolMoney.Text = "";
			this.m_txtTolMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_txtMemo
			// 
			this.m_txtMemo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtMemo.EnableAutoValidation = false;
			this.m_txtMemo.EnableEnterKeyValidate = true;
			this.m_txtMemo.EnableEscapeKeyUndo = true;
			this.m_txtMemo.EnableLastValidValue = true;
			this.m_txtMemo.ErrorProvider = null;
			this.m_txtMemo.ErrorProviderMessage = "Invalid value";
			this.m_txtMemo.ForceFormatText = true;
			this.m_txtMemo.Location = new System.Drawing.Point(520, 52);
			this.m_txtMemo.Name = "m_txtMemo";
			this.m_txtMemo.Size = new System.Drawing.Size(320, 23);
			this.m_txtMemo.TabIndex = 4;
			this.m_txtMemo.Text = "";
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
			this.m_txtAduit.Location = new System.Drawing.Point(48, 48);
			this.m_txtAduit.Name = "m_txtAduit";
			this.m_txtAduit.TabIndex = 10;
			this.m_txtAduit.Text = "";
			// 
			// m_dtpCreateDate
			// 
			this.m_dtpCreateDate.CustomFormat = "";
			this.m_dtpCreateDate.Location = new System.Drawing.Point(272, 16);
			this.m_dtpCreateDate.MaxDate = new System.DateTime(2059, 12, 31, 0, 0, 0, 0);
			this.m_dtpCreateDate.MinDate = new System.DateTime(2004, 1, 1, 0, 0, 0, 0);
			this.m_dtpCreateDate.Name = "m_dtpCreateDate";
			this.m_dtpCreateDate.Size = new System.Drawing.Size(128, 23);
			this.m_dtpCreateDate.TabIndex = 2;
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
			this.m_txtMedStore.Location = new System.Drawing.Point(48, 16);
			this.m_txtMedStore.Name = "m_txtMedStore";
			this.m_txtMedStore.Size = new System.Drawing.Size(136, 23);
			this.m_txtMedStore.TabIndex = 8;
			this.m_txtMedStore.Text = "";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(464, 20);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(48, 19);
			this.label9.TabIndex = 6;
			this.label9.Text = "单据号";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(478, 52);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(34, 19);
			this.label8.TabIndex = 5;
			this.label8.Text = "备注";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(218, 52);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(48, 19);
			this.label6.TabIndex = 4;
			this.label6.Text = "总金额";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(8, 52);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(34, 19);
			this.label5.TabIndex = 3;
			this.label5.Text = "审核";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(232, 20);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(34, 19);
			this.label4.TabIndex = 2;
			this.label4.Text = "日期";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(8, 20);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(34, 19);
			this.label3.TabIndex = 1;
			this.label3.Text = "药房";
			// 
			// frmMedStoreOutOrd
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(864, 653);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.m_lsvDetail);
			this.Controls.Add(this.m_cboSelPeriod);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.m_cboOrdType);
			this.Controls.Add(this.m_lblTitle);
			this.Controls.Add(this.m_txtCurPeriod);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.m_tbr);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.Name = "frmMedStoreOutOrd";
			this.Text = "药房出药";
			this.Load += new System.EventHandler(this.frmMedStoreOutOrd_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DgMedicine)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 
		/// </summary>
		public override void CreateController()
		{
			this.objController = new clsControlMedStoreOutOrd();
			this.objController.Set_GUI_Apperance(this);
		}

		private void frmMedStoreOutOrd_Load(object sender, System.EventArgs e)
		{
			base.m_mthSetFormControlCanBeNull(this);
			((com.digitalwave.iCare.gui.HIS.clsControlMedStoreOutOrd)this.objController).m_mthInit();

		}

		private void m_tbr_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch(this.m_tbr.Buttons.IndexOf(e.Button))
			{
				case 0:	//新建一记录单
					((com.digitalwave.iCare.gui.HIS.clsControlMedStoreOutOrd)this.objController).m_mthNewOrd();
					break; 
				case 1:	//保存记录单
					((com.digitalwave.iCare.gui.HIS.clsControlMedStoreOutOrd)this.objController).m_mthSave();
					break; 
				case 2:	//审核记录单
					((com.digitalwave.iCare.gui.HIS.clsControlMedStoreOutOrd)this.objController).m_mthAduit();
					break; 
				case 4:	//查找记录单
					((com.digitalwave.iCare.gui.HIS.clsControlMedStoreOutOrd)this.objController).m_mthFind();
					break;
				case 5:	//导入记录单
					((com.digitalwave.iCare.gui.HIS.clsControlMedStoreOutOrd)this.objController).m_mthImp();
					break;
				case 7:	//增加一条记录
					((com.digitalwave.iCare.gui.HIS.clsControlMedStoreOutOrd)this.objController).m_mthAdd();
					break;
				case 8:	//插入一记录
					((com.digitalwave.iCare.gui.HIS.clsControlMedStoreOutOrd)this.objController).m_mthInsert();
					break;
				case 9:	//删除记录
					((com.digitalwave.iCare.gui.HIS.clsControlMedStoreOutOrd)this.objController).m_mthDelete();					
					break;
				case 11:	//预览
					((com.digitalwave.iCare.gui.HIS.clsControlMedStoreOutOrd)this.objController).m_mthPreView();
					break;
				case 12:	//打印
					((com.digitalwave.iCare.gui.HIS.clsControlMedStoreOutOrd)this.objController).m_mthPrint();
					break;
				case 13:	//关闭
					this.Close();
					break;
			}

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void m_lsvDetail_DoubleClick(object sender, System.EventArgs e)
		{
			((com.digitalwave.iCare.gui.HIS.clsControlMedStoreOutOrd)this.objController).m_mthSelectDetailList();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void m_lsvDetail_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				((com.digitalwave.iCare.gui.HIS.clsControlMedStoreOutOrd)this.objController).m_mthSelectDetailList();
			}
		}

		/// <summary>
		/// 填充药品信息框
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FillTextBox(object sender, com.digitalwave.Utility.clsExValueChangedEventArgs e)
		{
			((clsControlMedStoreOutOrd)this.objController).m_mthSelMedicine();
		}

		private void m_txtMedID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
//			if(e.KeyChar == (char)13)
//			{
//				//				this.m_txtMedID.evtLostFocus += new EventHandler(this.FillTextBox);
//				this.m_txtMedID.evtValueChanged += new com.digitalwave.Utility.dlgExValueChangedEventHandler(FillTextBox);
//			}
		}

		private void m_cmdConfirm_Click(object sender, System.EventArgs e)
		{
			((clsControlMedStoreOutOrd)this.objController).m_mthOkButtonClick();
		}

		private void m_cboSelPeriod_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			((clsControlMedStoreOutOrd)this.objController).m_mthSelectPeriod();
		}

		private void m_lsvUnAduit_DoubleClick(object sender, System.EventArgs e)
		{
			((clsControlMedStoreOutOrd)this.objController).m_mthSelectUnAduitList();
		}

		private void m_lsvEnAduit_DoubleClick(object sender, System.EventArgs e)
		{
			((clsControlMedStoreOutOrd)this.objController).m_mthSelectEnAduitList();
		}

		private void m_Calc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				((com.digitalwave.iCare.gui.HIS.clsControlMedStoreOutOrd)this.objController).m_mthCalcTolBuyMonay();
			}
		}

		private void m_txtUnit_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				((com.digitalwave.iCare.gui.HIS.clsControlMedStoreOutOrd)this.objController).m_mthEnablePopUnitList();
			}
		}

		private void m_lsvPopUnit_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				((com.digitalwave.iCare.gui.HIS.clsControlMedStoreOutOrd)this.objController).m_mthSelUnit();
			}
		}

		private void m_lsvPopUnit_DoubleClick(object sender, System.EventArgs e)
		{
			((com.digitalwave.iCare.gui.HIS.clsControlMedStoreOutOrd)this.objController).m_mthSelUnit();
		}
		private void DgMedicine_VisibleChanged(object sender, System.EventArgs e)
		{
				((com.digitalwave.iCare.gui.HIS.clsControlMedStoreOutOrd)this.objController).m_lngFillToDgList();
		}

		private void m_txtMedID_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				DgMedicine.Visible=true;
			}
		}

		private void DgMedicine_m_evtDoubleClickCell(object sender, com.digitalwave.controls.datagrid.clsDGTextMouseClickEventArgs e)
		{
		((com.digitalwave.iCare.gui.HIS.clsControlMedStoreOutOrd)this.objController).m_lngSeleMed();
		}

	}
}
