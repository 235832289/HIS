using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 药房领药申请窗口
	/// Create by kong 2004-07-08
	/// </summary>
	public class frmMedStoreMedAppl : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		internal System.Windows.Forms.ToolBarButton tbrNew;
		internal System.Windows.Forms.ToolBarButton tbrSave;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		internal System.Windows.Forms.ToolBarButton tbrAdd;
		internal System.Windows.Forms.ToolBarButton tbrInsert;
		internal System.Windows.Forms.ToolBarButton tbrDelete;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		internal System.Windows.Forms.ToolBarButton tbrPreView;
		internal System.Windows.Forms.ToolBarButton tbrPrint;
		internal System.Windows.Forms.ToolBarButton tbrClose;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		internal System.Windows.Forms.ToolBarButton tbrFind;
		internal System.Windows.Forms.ToolBarButton tbrImp;
		private System.Windows.Forms.ToolBarButton toolBarButton3;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader6;
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
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label16;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtMedName;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtMedSpec;
		internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric m_txtQty;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtUnit;
		internal PinkieControls.ButtonXP m_cmdConfirm;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtOrdID;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtMemo;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtMedStore;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		internal System.Windows.Forms.ComboBox m_cboStorage;
		internal System.Windows.Forms.ListView m_lsvUnAsk;
		internal System.Windows.Forms.ListView m_lsvEnAsk;
		private System.Windows.Forms.ColumnHeader m_clhQty;
		internal com.digitalwave.iCare.gui.HIS.ctlStorageMedTextBox m_txtMedID;
		internal System.Windows.Forms.ListView m_lsvPopUnit;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.ColumnHeader columnHeader12;
		private System.Windows.Forms.ColumnHeader columnHeader13;
		private System.Windows.Forms.ColumnHeader columnHeader14;
		internal System.Windows.Forms.DateTimePicker m_dtpCreateDate;
		private System.Windows.Forms.ToolBar m_tbr;
		private System.Windows.Forms.ToolBarButton tbrAutoCalc;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// 
		/// </summary>
		public frmMedStoreMedAppl()
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
			this.m_tbr = new System.Windows.Forms.ToolBar();
			this.tbrAutoCalc = new System.Windows.Forms.ToolBarButton();
			this.tbrNew = new System.Windows.Forms.ToolBarButton();
			this.tbrSave = new System.Windows.Forms.ToolBarButton();
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.m_lsvUnAsk = new System.Windows.Forms.ListView();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.m_lsvEnAsk = new System.Windows.Forms.ListView();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
			this.m_lsvDetail = new System.Windows.Forms.ListView();
			this.m_clhRowNO = new System.Windows.Forms.ColumnHeader();
			this.m_clhMedID = new System.Windows.Forms.ColumnHeader();
			this.m_clhMedName = new System.Windows.Forms.ColumnHeader();
			this.m_clhMedSpec = new System.Windows.Forms.ColumnHeader();
			this.m_clhMedUnit = new System.Windows.Forms.ColumnHeader();
			this.m_clhQty = new System.Windows.Forms.ColumnHeader();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.m_lsvPopUnit = new System.Windows.Forms.ListView();
			this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
			this.m_txtMedID = new com.digitalwave.iCare.gui.HIS.ctlStorageMedTextBox();
			this.m_cmdConfirm = new PinkieControls.ButtonXP();
			this.m_txtUnit = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.m_txtMedSpec = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.m_txtMedName = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.label16 = new System.Windows.Forms.Label();
			this.m_txtQty = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.m_txtOrdID = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.m_txtMemo = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.m_dtpCreateDate = new System.Windows.Forms.DateTimePicker();
			this.m_txtMedStore = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.m_cboStorage = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_tbr
			// 
			this.m_tbr.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.m_tbr.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																					 this.tbrAutoCalc,
																					 this.tbrNew,
																					 this.tbrSave,
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
			// tbrAutoCalc
			// 
			this.tbrAutoCalc.Text = "生成";
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
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(0, 136);
			this.tabControl1.Multiline = true;
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(208, 504);
			this.tabControl1.TabIndex = 6;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.m_lsvUnAsk);
			this.tabPage1.Location = new System.Drawing.Point(4, 26);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(200, 474);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "未处理";
			// 
			// m_lsvUnAsk
			// 
			this.m_lsvUnAsk.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						 this.columnHeader5,
																						 this.columnHeader7,
																						 this.columnHeader6});
			this.m_lsvUnAsk.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_lsvUnAsk.FullRowSelect = true;
			this.m_lsvUnAsk.GridLines = true;
			this.m_lsvUnAsk.Location = new System.Drawing.Point(0, 0);
			this.m_lsvUnAsk.Name = "m_lsvUnAsk";
			this.m_lsvUnAsk.Size = new System.Drawing.Size(200, 474);
			this.m_lsvUnAsk.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.m_lsvUnAsk.TabIndex = 1;
			this.m_lsvUnAsk.View = System.Windows.Forms.View.Details;
			this.m_lsvUnAsk.DoubleClick += new System.EventHandler(this.m_lsvUnAsk_DoubleClick);
			this.m_lsvUnAsk.SelectedIndexChanged += new System.EventHandler(this.m_lsvUnAsk_SelectedIndexChanged);
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "单据号";
			this.columnHeader5.Width = 110;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "药库";
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
			this.tabPage2.Controls.Add(this.m_lsvEnAsk);
			this.tabPage2.Location = new System.Drawing.Point(4, 24);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(200, 476);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "已处理";
			// 
			// m_lsvEnAsk
			// 
			this.m_lsvEnAsk.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						 this.columnHeader8,
																						 this.columnHeader9,
																						 this.columnHeader10});
			this.m_lsvEnAsk.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_lsvEnAsk.ForeColor = System.Drawing.SystemColors.WindowText;
			this.m_lsvEnAsk.FullRowSelect = true;
			this.m_lsvEnAsk.GridLines = true;
			this.m_lsvEnAsk.Location = new System.Drawing.Point(0, 0);
			this.m_lsvEnAsk.Name = "m_lsvEnAsk";
			this.m_lsvEnAsk.Size = new System.Drawing.Size(200, 476);
			this.m_lsvEnAsk.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.m_lsvEnAsk.TabIndex = 1;
			this.m_lsvEnAsk.View = System.Windows.Forms.View.Details;
			this.m_lsvEnAsk.DoubleClick += new System.EventHandler(this.m_lsvEnAsk_DoubleClick);
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "单据号";
			this.columnHeader8.Width = 110;
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "药库";
			this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader9.Width = 100;
			// 
			// columnHeader10
			// 
			this.columnHeader10.Text = "创建时间";
			this.columnHeader10.Width = 120;
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
																						  this.m_clhQty});
			this.m_lsvDetail.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lsvDetail.FullRowSelect = true;
			this.m_lsvDetail.GridLines = true;
			this.m_lsvDetail.HoverSelection = true;
			this.m_lsvDetail.Location = new System.Drawing.Point(216, 136);
			this.m_lsvDetail.Name = "m_lsvDetail";
			this.m_lsvDetail.Size = new System.Drawing.Size(640, 384);
			this.m_lsvDetail.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.m_lsvDetail.TabIndex = 12;
			this.m_lsvDetail.View = System.Windows.Forms.View.Details;
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
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.m_lsvPopUnit);
			this.groupBox2.Controls.Add(this.m_txtMedID);
			this.groupBox2.Controls.Add(this.m_cmdConfirm);
			this.groupBox2.Controls.Add(this.m_txtUnit);
			this.groupBox2.Controls.Add(this.m_txtMedSpec);
			this.groupBox2.Controls.Add(this.m_txtMedName);
			this.groupBox2.Controls.Add(this.label16);
			this.groupBox2.Controls.Add(this.m_txtQty);
			this.groupBox2.Controls.Add(this.label13);
			this.groupBox2.Controls.Add(this.label12);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Location = new System.Drawing.Point(216, 520);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(648, 112);
			this.groupBox2.TabIndex = 13;
			this.groupBox2.TabStop = false;
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
			this.m_lsvPopUnit.Location = new System.Drawing.Point(80, -88);
			this.m_lsvPopUnit.Name = "m_lsvPopUnit";
			this.m_lsvPopUnit.Size = new System.Drawing.Size(280, 96);
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
			this.m_txtMedID.TabIndex = 8;
			this.m_txtMedID.Text = "";
			this.m_txtMedID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtMedID_KeyPress);
			// 
			// m_cmdConfirm
			// 
			this.m_cmdConfirm.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdConfirm.DefaultScheme = true;
			this.m_cmdConfirm.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdConfirm.Hint = "";
			this.m_cmdConfirm.Location = new System.Drawing.Point(496, 64);
			this.m_cmdConfirm.Name = "m_cmdConfirm";
			this.m_cmdConfirm.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdConfirm.Size = new System.Drawing.Size(120, 32);
			this.m_cmdConfirm.TabIndex = 11;
			this.m_cmdConfirm.Text = "确定(&S)";
			this.m_cmdConfirm.Click += new System.EventHandler(this.m_cmdConfirm_Click);
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
			this.label16.Location = new System.Drawing.Point(248, 72);
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
			this.m_txtQty.Location = new System.Drawing.Point(288, 68);
			this.m_txtQty.Name = "m_txtQty";
			this.m_txtQty.NumericCharStyle = ((SourceLibrary.Windows.Forms.NumericCharStyle)((SourceLibrary.Windows.Forms.NumericCharStyle.DecimalSeparator | SourceLibrary.Windows.Forms.NumericCharStyle.NegativeSymbol)));
			this.m_txtQty.TabIndex = 10;
			this.m_txtQty.Text = "";
			this.m_txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
			this.m_txtOrdID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtOrdID.ForceFormatText = true;
			this.m_txtOrdID.Location = new System.Drawing.Point(520, 16);
			this.m_txtOrdID.Name = "m_txtOrdID";
			this.m_txtOrdID.Size = new System.Drawing.Size(320, 23);
			this.m_txtOrdID.TabIndex = 13;
			this.m_txtOrdID.Text = "";
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
			this.m_txtMemo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtMemo.ForceFormatText = true;
			this.m_txtMemo.Location = new System.Drawing.Point(272, 48);
			this.m_txtMemo.Name = "m_txtMemo";
			this.m_txtMemo.Size = new System.Drawing.Size(568, 23);
			this.m_txtMemo.TabIndex = 11;
			this.m_txtMemo.Text = "";
			// 
			// m_dtpCreateDate
			// 
			this.m_dtpCreateDate.CalendarFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_dtpCreateDate.CustomFormat = "";
			this.m_dtpCreateDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_dtpCreateDate.Location = new System.Drawing.Point(272, 16);
			this.m_dtpCreateDate.MaxDate = new System.DateTime(2059, 12, 31, 0, 0, 0, 0);
			this.m_dtpCreateDate.MinDate = new System.DateTime(2004, 1, 1, 0, 0, 0, 0);
			this.m_dtpCreateDate.Name = "m_dtpCreateDate";
			this.m_dtpCreateDate.Size = new System.Drawing.Size(128, 23);
			this.m_dtpCreateDate.TabIndex = 9;
			this.m_dtpCreateDate.Value = new System.DateTime(2004, 7, 8, 16, 15, 8, 453);
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
			this.m_txtMedStore.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtMedStore.ForceFormatText = true;
			this.m_txtMedStore.Location = new System.Drawing.Point(48, 48);
			this.m_txtMedStore.Name = "m_txtMedStore";
			this.m_txtMedStore.Size = new System.Drawing.Size(136, 23);
			this.m_txtMedStore.TabIndex = 8;
			this.m_txtMedStore.Text = "";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label9.Location = new System.Drawing.Point(464, 20);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(48, 19);
			this.label9.TabIndex = 6;
			this.label9.Text = "单据号";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label8.Location = new System.Drawing.Point(232, 52);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(34, 19);
			this.label8.TabIndex = 5;
			this.label8.Text = "备注";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label4.Location = new System.Drawing.Point(232, 20);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(34, 19);
			this.label4.TabIndex = 2;
			this.label4.Text = "日期";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.Location = new System.Drawing.Point(8, 52);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(34, 19);
			this.label3.TabIndex = 1;
			this.label3.Text = "药房";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.m_cboStorage);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.m_txtOrdID);
			this.groupBox1.Controls.Add(this.m_txtMemo);
			this.groupBox1.Controls.Add(this.m_dtpCreateDate);
			this.groupBox1.Controls.Add(this.m_txtMedStore);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.groupBox1.Location = new System.Drawing.Point(0, 48);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(864, 80);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			// 
			// m_cboStorage
			// 
			this.m_cboStorage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboStorage.Location = new System.Drawing.Point(48, 16);
			this.m_cboStorage.Name = "m_cboStorage";
			this.m_cboStorage.Size = new System.Drawing.Size(136, 22);
			this.m_cboStorage.TabIndex = 16;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 19);
			this.label1.TabIndex = 15;
			this.label1.Text = "药库";
			// 
			// frmMedStoreMedAppl
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(864, 653);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.m_lsvDetail);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.m_tbr);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.Name = "frmMedStoreMedAppl";
			this.Text = "药房领药申请";
			this.Load += new System.EventHandler(this.frmMedStoreMedAppl_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 设置窗体对象
		/// </summary>
		public override void CreateController()
		{
			this.objController = new clsControlMedStoreMedAppl();
			this.objController.Set_GUI_Apperance(this);
		}


		private void frmMedStoreMedAppl_Load(object sender, System.EventArgs e)
		{
			base.m_mthSetFormControlCanBeNull(this);
			((clsControlMedStoreMedAppl)this.objController).m_mthInit();
		}

		private void m_tbr_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch(this.m_tbr.Buttons.IndexOf(e.Button))
			{
				case 0:	//新建一记录单
					((com.digitalwave.iCare.gui.HIS.clsControlMedStoreMedAppl)this.objController).m_mthAutoCalc();
					break; 
				case 1:	//保存记录单
					((com.digitalwave.iCare.gui.HIS.clsControlMedStoreMedAppl)this.objController).m_mthNewOrd();
					break; 
				case 2:	//审核记录单
					((com.digitalwave.iCare.gui.HIS.clsControlMedStoreMedAppl)this.objController).m_mthSave();
					break; 
				case 4:	//查找记录单
					((com.digitalwave.iCare.gui.HIS.clsControlMedStoreMedAppl)this.objController).m_mthFind();
					break;
				case 5:	//导入记录单
					((com.digitalwave.iCare.gui.HIS.clsControlMedStoreMedAppl)this.objController).m_mthImp();
					break;
				case 7:	//增加一条记录
					((com.digitalwave.iCare.gui.HIS.clsControlMedStoreMedAppl)this.objController).m_mthAdd();
					break;
				case 8:	//插入一记录
					((com.digitalwave.iCare.gui.HIS.clsControlMedStoreMedAppl)this.objController).m_mthInsert();
					break;
				case 9:	//删除记录
					((com.digitalwave.iCare.gui.HIS.clsControlMedStoreMedAppl)this.objController).m_mthDelete();					
					break;
                //case 11:	//预览
                //    ((com.digitalwave.iCare.gui.HIS.clsControlMedStoreInOrd)this.objController).m_mthPreView();
                //    break;
                //case 12:	//打印
                //    ((com.digitalwave.iCare.gui.HIS.clsControlMedStoreInOrd)this.objController).m_mthPrint();
                //    break;
				case 13:	//关闭
					this.Close();
					break;
			}

		}

		/// <summary>
		/// 明细列表双击事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void m_lsvDetail_DoubleClick(object sender, System.EventArgs e)
		{
			((com.digitalwave.iCare.gui.HIS.clsControlMedStoreMedAppl)this.objController).m_mthSelectDetailList();
		}

		/// <summary>
		/// 明细列表的Enter事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void m_lsvDetail_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				((com.digitalwave.iCare.gui.HIS.clsControlMedStoreMedAppl)this.objController).m_mthSelectDetailList();
			}
		}

		/// <summary>
		/// 填充药品信息框
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FillTextBox(object sender, com.digitalwave.Utility.clsExValueChangedEventArgs e)
		{
			((clsControlMedStoreMedAppl)this.objController).m_mthSelMedicine();
		}

		private void m_txtMedID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar == (char)13)
			{
				//				this.m_txtMedID.evtLostFocus += new EventHandler(this.FillTextBox);
				this.m_txtMedID.evtValueChanged += new com.digitalwave.Utility.dlgExValueChangedEventHandler(FillTextBox);
			}
		}

		private void m_cmdConfirm_Click(object sender, System.EventArgs e)
		{
			((clsControlMedStoreMedAppl)this.objController).m_mthOkButtonClick();
		}

		private void m_lsvUnAsk_DoubleClick(object sender, System.EventArgs e)
		{
			((clsControlMedStoreMedAppl)this.objController).m_mthSelectUnAskList();
		}

		private void m_lsvEnAsk_DoubleClick(object sender, System.EventArgs e)
		{
			((clsControlMedStoreMedAppl)this.objController).m_mthSelectEnAskList();
		}

		private void m_txtUnit_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				((com.digitalwave.iCare.gui.HIS.clsControlMedStoreMedAppl)this.objController).m_mthEnablePopUnitList();
			}
		}

		private void m_lsvPopUnit_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				((com.digitalwave.iCare.gui.HIS.clsControlMedStoreMedAppl)this.objController).m_mthSelUnit();
			}
		}

		private void m_lsvPopUnit_DoubleClick(object sender, System.EventArgs e)
		{
			((com.digitalwave.iCare.gui.HIS.clsControlMedStoreMedAppl)this.objController).m_mthSelUnit();
		}

		private void m_lsvUnAsk_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
