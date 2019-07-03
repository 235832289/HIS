using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmMedStoreOut 的摘要说明。
	/// </summary>
	public class frmMedStoreOut : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.ColumnHeader ROWNO_CHR;
		private System.Windows.Forms.ColumnHeader MEDICINEID_CHR;
		private System.Windows.Forms.ColumnHeader MEDICINENAME_CHR;
		private System.Windows.Forms.ColumnHeader space;
		private System.Windows.Forms.ColumnHeader UNITID_CHR;
		private System.Windows.Forms.ColumnHeader QTY_DEC;
		private System.Windows.Forms.ColumnHeader CURPRICE_MNY;
		private System.Windows.Forms.ColumnHeader col7;
		internal System.Windows.Forms.Panel panel6;
		internal SourceLibrary.Windows.Forms.TextBoxTyped APPLDATE;
		internal SourceLibrary.Windows.Forms.TextBoxTyped txtType;
		internal SourceLibrary.Windows.Forms.TextBoxTyped txtfindstroage;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label17;
		internal PinkieControls.ButtonXP btnColes;
		internal PinkieControls.ButtonXP btnFinddata;
		internal SourceLibrary.Windows.Forms.TextBoxTyped TextID;
		private System.Windows.Forms.Label label13;
		internal SourceLibrary.Windows.Forms.TextBoxTyped GrearNAME;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Panel panel1;
		internal com.digitalwave.controls.datagrid.ctlDataGrid dgrMedicine;
		internal System.Windows.Forms.Panel panel4;
		internal SourceLibrary.Windows.Forms.TextBoxTyped txtGrearMan;
		private System.Windows.Forms.Label label25;
		internal System.Windows.Forms.TextBox comboType;
		private System.Windows.Forms.Label label24;
		internal System.Windows.Forms.ComboBox comboStroage;
		private System.Windows.Forms.Label label14;
		internal SourceLibrary.Windows.Forms.TextBoxTyped txtTolmoney;
		private System.Windows.Forms.Label label8;
		internal SourceLibrary.Windows.Forms.TextBoxTyped txtInOrdID;
		private System.Windows.Forms.Label label2;
		internal System.Windows.Forms.DateTimePicker dateTime;
		private System.Windows.Forms.Label label12;
		internal System.Windows.Forms.TextBox m_txtMemo;
		private System.Windows.Forms.Label label4;
		protected internal System.Windows.Forms.Panel panel3;
		internal System.Windows.Forms.Label label3;
		internal SourceLibrary.Windows.Forms.TextBoxTyped txtSpace;
		private System.Windows.Forms.Label label5;
		internal System.Windows.Forms.Label lblfind;
		internal PinkieControls.ButtonXP btnClear;
		internal PinkieControls.ButtonXP btnAdd;
		internal SourceLibrary.Windows.Forms.TextBoxTyped txtTolPrice;
		private System.Windows.Forms.Label label27;
		internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric txttol;
		private System.Windows.Forms.Label label26;
		internal SourceLibrary.Windows.Forms.TextBoxTyped txtbuyprice;
		internal SourceLibrary.Windows.Forms.TextBoxTyped txtmedicine;
		internal SourceLibrary.Windows.Forms.TextBoxTyped txtfind;
		private System.Windows.Forms.Label label30;
		internal SourceLibrary.Windows.Forms.TextBoxTyped txtUnti;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label7;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtUNIT;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox3;
		internal PinkieControls.ButtonXP dntEmp;
		internal PinkieControls.ButtonXP btnesc;
		internal PinkieControls.ButtonXP btnDelect;
		internal PinkieControls.ButtonXP btnFind;
		internal PinkieControls.ButtonXP btnSave;
		internal PinkieControls.ButtonXP m_btnNew;
		internal System.Windows.Forms.ListView LSVInOrdDe;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Panel panel5;
		internal System.Windows.Forms.TabControl tabInOrd;
		private System.Windows.Forms.TabPage tab1;
		internal System.Windows.Forms.ListView LSVInord;
		private System.Windows.Forms.TabPage tab2;
		internal System.Windows.Forms.ListView LSVInOrdEmp;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.Label label6;
		internal SourceLibrary.Windows.Forms.TextBoxTyped txtStorage;
		internal System.Windows.Forms.ComboBox m_cboSelPeriod;
		internal System.Windows.Forms.ErrorProvider errorProvider1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMedStoreOut()
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
			com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo5 = new com.digitalwave.controls.datagrid.clsColumnInfo();
			com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo6 = new com.digitalwave.controls.datagrid.clsColumnInfo();
			com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo7 = new com.digitalwave.controls.datagrid.clsColumnInfo();
			com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo8 = new com.digitalwave.controls.datagrid.clsColumnInfo();
			this.ROWNO_CHR = new System.Windows.Forms.ColumnHeader();
			this.MEDICINEID_CHR = new System.Windows.Forms.ColumnHeader();
			this.MEDICINENAME_CHR = new System.Windows.Forms.ColumnHeader();
			this.space = new System.Windows.Forms.ColumnHeader();
			this.UNITID_CHR = new System.Windows.Forms.ColumnHeader();
			this.QTY_DEC = new System.Windows.Forms.ColumnHeader();
			this.CURPRICE_MNY = new System.Windows.Forms.ColumnHeader();
			this.col7 = new System.Windows.Forms.ColumnHeader();
			this.panel6 = new System.Windows.Forms.Panel();
			this.APPLDATE = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.txtType = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.txtfindstroage = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.label11 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.btnColes = new PinkieControls.ButtonXP();
			this.btnFinddata = new PinkieControls.ButtonXP();
			this.TextID = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.label13 = new System.Windows.Forms.Label();
			this.GrearNAME = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.dgrMedicine = new com.digitalwave.controls.datagrid.ctlDataGrid();
			this.panel5 = new System.Windows.Forms.Panel();
			this.m_cboSelPeriod = new System.Windows.Forms.ComboBox();
			this.tabInOrd = new System.Windows.Forms.TabControl();
			this.tab1 = new System.Windows.Forms.TabPage();
			this.LSVInord = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.tab2 = new System.Windows.Forms.TabPage();
			this.LSVInOrdEmp = new System.Windows.Forms.ListView();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.panel4 = new System.Windows.Forms.Panel();
			this.txtGrearMan = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.label25 = new System.Windows.Forms.Label();
			this.comboType = new System.Windows.Forms.TextBox();
			this.label24 = new System.Windows.Forms.Label();
			this.comboStroage = new System.Windows.Forms.ComboBox();
			this.label14 = new System.Windows.Forms.Label();
			this.txtTolmoney = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.label8 = new System.Windows.Forms.Label();
			this.txtInOrdID = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.label2 = new System.Windows.Forms.Label();
			this.dateTime = new System.Windows.Forms.DateTimePicker();
			this.label12 = new System.Windows.Forms.Label();
			this.m_txtMemo = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label6 = new System.Windows.Forms.Label();
			this.txtStorage = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.label3 = new System.Windows.Forms.Label();
			this.txtSpace = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.label5 = new System.Windows.Forms.Label();
			this.lblfind = new System.Windows.Forms.Label();
			this.btnClear = new PinkieControls.ButtonXP();
			this.btnAdd = new PinkieControls.ButtonXP();
			this.txtTolPrice = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.label27 = new System.Windows.Forms.Label();
			this.txttol = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
			this.label26 = new System.Windows.Forms.Label();
			this.txtbuyprice = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.txtmedicine = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.txtfind = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.label30 = new System.Windows.Forms.Label();
			this.txtUnti = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.label31 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.m_txtUNIT = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.dntEmp = new PinkieControls.ButtonXP();
			this.btnesc = new PinkieControls.ButtonXP();
			this.btnDelect = new PinkieControls.ButtonXP();
			this.btnFind = new PinkieControls.ButtonXP();
			this.btnSave = new PinkieControls.ButtonXP();
			this.m_btnNew = new PinkieControls.ButtonXP();
			this.LSVInOrdDe = new System.Windows.Forms.ListView();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label23 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider();
			this.panel6.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrMedicine)).BeginInit();
			this.panel5.SuspendLayout();
			this.tabInOrd.SuspendLayout();
			this.tab1.SuspendLayout();
			this.tab2.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// ROWNO_CHR
			// 
			this.ROWNO_CHR.Text = "行号";
			this.ROWNO_CHR.Width = 55;
			// 
			// MEDICINEID_CHR
			// 
			this.MEDICINEID_CHR.Text = "药品代码";
			this.MEDICINEID_CHR.Width = 100;
			// 
			// MEDICINENAME_CHR
			// 
			this.MEDICINENAME_CHR.Text = "药品名称";
			this.MEDICINENAME_CHR.Width = 121;
			// 
			// space
			// 
			this.space.Text = "规格";
			this.space.Width = 110;
			// 
			// UNITID_CHR
			// 
			this.UNITID_CHR.Text = "单位";
			this.UNITID_CHR.Width = 50;
			// 
			// QTY_DEC
			// 
			this.QTY_DEC.Text = "药品数量";
			this.QTY_DEC.Width = 81;
			// 
			// CURPRICE_MNY
			// 
			this.CURPRICE_MNY.Text = "零售价格";
			this.CURPRICE_MNY.Width = 79;
			// 
			// col7
			// 
			this.col7.Text = "零售总额";
			this.col7.Width = 91;
			// 
			// panel6
			// 
			this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel6.Controls.Add(this.APPLDATE);
			this.panel6.Controls.Add(this.txtType);
			this.panel6.Controls.Add(this.txtfindstroage);
			this.panel6.Controls.Add(this.label11);
			this.panel6.Controls.Add(this.label17);
			this.panel6.Controls.Add(this.btnColes);
			this.panel6.Controls.Add(this.btnFinddata);
			this.panel6.Controls.Add(this.TextID);
			this.panel6.Controls.Add(this.label13);
			this.panel6.Controls.Add(this.GrearNAME);
			this.panel6.Controls.Add(this.label15);
			this.panel6.Controls.Add(this.label16);
			this.panel6.Location = new System.Drawing.Point(344, 290);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(684, 80);
			this.panel6.TabIndex = 152;
			this.panel6.Visible = false;
			// 
			// APPLDATE
			// 
			this.APPLDATE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.APPLDATE.EnableAutoValidation = true;
			this.APPLDATE.EnableEnterKeyValidate = true;
			this.APPLDATE.EnableEscapeKeyUndo = true;
			this.APPLDATE.EnableLastValidValue = true;
			this.APPLDATE.ErrorProvider = null;
			this.APPLDATE.ErrorProviderMessage = "Invalid value";
			this.APPLDATE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.APPLDATE.ForceFormatText = true;
			this.APPLDATE.Location = new System.Drawing.Point(544, 8);
			this.APPLDATE.Name = "APPLDATE";
			this.APPLDATE.Size = new System.Drawing.Size(136, 23);
			this.APPLDATE.TabIndex = 12;
			this.APPLDATE.Text = "";
			this.APPLDATE.KeyDown += new System.Windows.Forms.KeyEventHandler(this.APPLDATE_KeyDown);
			// 
			// txtType
			// 
			this.txtType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtType.EnableAutoValidation = true;
			this.txtType.EnableEnterKeyValidate = true;
			this.txtType.EnableEscapeKeyUndo = true;
			this.txtType.EnableLastValidValue = true;
			this.txtType.ErrorProvider = null;
			this.txtType.ErrorProviderMessage = "Invalid value";
			this.txtType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtType.ForceFormatText = true;
			this.txtType.Location = new System.Drawing.Point(304, 48);
			this.txtType.Name = "txtType";
			this.txtType.Size = new System.Drawing.Size(136, 23);
			this.txtType.TabIndex = 14;
			this.txtType.Text = "";
			this.txtType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtType_KeyDown);
			// 
			// txtfindstroage
			// 
			this.txtfindstroage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtfindstroage.EnableAutoValidation = true;
			this.txtfindstroage.EnableEnterKeyValidate = true;
			this.txtfindstroage.EnableEscapeKeyUndo = true;
			this.txtfindstroage.EnableLastValidValue = true;
			this.txtfindstroage.ErrorProvider = null;
			this.txtfindstroage.ErrorProviderMessage = "Invalid value";
			this.txtfindstroage.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtfindstroage.ForceFormatText = true;
			this.txtfindstroage.Location = new System.Drawing.Point(80, 48);
			this.txtfindstroage.Name = "txtfindstroage";
			this.txtfindstroage.Size = new System.Drawing.Size(136, 23);
			this.txtfindstroage.TabIndex = 13;
			this.txtfindstroage.Text = "";
			this.txtfindstroage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtfindstroage_KeyDown);
			// 
			// label11
			// 
			this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label11.Location = new System.Drawing.Point(16, 48);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(64, 16);
			this.label11.TabIndex = 150;
			this.label11.Text = "仓    库";
			// 
			// label17
			// 
			this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label17.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label17.Location = new System.Drawing.Point(232, 48);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(64, 16);
			this.label17.TabIndex = 149;
			this.label17.Text = "出药类型";
			// 
			// btnColes
			// 
			this.btnColes.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btnColes.DefaultScheme = true;
			this.btnColes.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btnColes.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnColes.Hint = "";
			this.btnColes.Location = new System.Drawing.Point(592, 48);
			this.btnColes.Name = "btnColes";
			this.btnColes.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btnColes.Size = new System.Drawing.Size(72, 24);
			this.btnColes.TabIndex = 16;
			this.btnColes.TabStop = false;
			this.btnColes.Text = "返回(&R)";
			this.btnColes.Click += new System.EventHandler(this.btnColes_Click);
			// 
			// btnFinddata
			// 
			this.btnFinddata.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btnFinddata.DefaultScheme = true;
			this.btnFinddata.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btnFinddata.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnFinddata.Hint = "";
			this.btnFinddata.Location = new System.Drawing.Point(480, 48);
			this.btnFinddata.Name = "btnFinddata";
			this.btnFinddata.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btnFinddata.Size = new System.Drawing.Size(72, 24);
			this.btnFinddata.TabIndex = 15;
			this.btnFinddata.TabStop = false;
			this.btnFinddata.Text = "查找(&F)";
			this.btnFinddata.Click += new System.EventHandler(this.btnFinddata_Click);
			// 
			// TextID
			// 
			this.TextID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.TextID.EnableAutoValidation = true;
			this.TextID.EnableEnterKeyValidate = true;
			this.TextID.EnableEscapeKeyUndo = true;
			this.TextID.EnableLastValidValue = true;
			this.TextID.ErrorProvider = null;
			this.TextID.ErrorProviderMessage = "Invalid value";
			this.TextID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.TextID.ForceFormatText = true;
			this.TextID.Location = new System.Drawing.Point(80, 8);
			this.TextID.Name = "TextID";
			this.TextID.Size = new System.Drawing.Size(136, 23);
			this.TextID.TabIndex = 10;
			this.TextID.Text = "";
			this.TextID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextID_KeyDown);
			// 
			// label13
			// 
			this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label13.Location = new System.Drawing.Point(16, 10);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(64, 16);
			this.label13.TabIndex = 128;
			this.label13.Text = "单 号 ID";
			// 
			// GrearNAME
			// 
			this.GrearNAME.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.GrearNAME.EnableAutoValidation = true;
			this.GrearNAME.EnableEnterKeyValidate = true;
			this.GrearNAME.EnableEscapeKeyUndo = true;
			this.GrearNAME.EnableLastValidValue = true;
			this.GrearNAME.ErrorProvider = null;
			this.GrearNAME.ErrorProviderMessage = "Invalid value";
			this.GrearNAME.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.GrearNAME.ForceFormatText = true;
			this.GrearNAME.Location = new System.Drawing.Point(304, 8);
			this.GrearNAME.Name = "GrearNAME";
			this.GrearNAME.Size = new System.Drawing.Size(136, 23);
			this.GrearNAME.TabIndex = 11;
			this.GrearNAME.Text = "";
			this.GrearNAME.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GrearNAME_KeyDown);
			// 
			// label15
			// 
			this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label15.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label15.Location = new System.Drawing.Point(472, 10);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(64, 16);
			this.label15.TabIndex = 118;
			this.label15.Text = "单据日期";
			// 
			// label16
			// 
			this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label16.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label16.Location = new System.Drawing.Point(232, 10);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(64, 16);
			this.label16.TabIndex = 116;
			this.label16.Text = "创 建 人";
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.dgrMedicine);
			this.panel1.Controls.Add(this.panel5);
			this.panel1.Controls.Add(this.panel4);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.groupBox3);
			this.panel1.Controls.Add(this.LSVInOrdDe);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Location = new System.Drawing.Point(0, -8);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1028, 744);
			this.panel1.TabIndex = 151;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			// 
			// dgrMedicine
			// 
			this.dgrMedicine.AllowAddNew = false;
			this.dgrMedicine.AllowDelete = false;
			this.dgrMedicine.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dgrMedicine.AutoAppendRow = false;
			this.dgrMedicine.AutoScroll = true;
			this.dgrMedicine.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgrMedicine.CaptionText = "";
			this.dgrMedicine.CaptionVisible = false;
			this.dgrMedicine.ColumnHeadersVisible = true;
			clsColumnInfo1.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo1.BackColor = System.Drawing.Color.White;
			clsColumnInfo1.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo1.ColumnIndex = 0;
			clsColumnInfo1.ColumnName = "ASSISTCODE_CHR";
			clsColumnInfo1.ColumnWidth = 75;
			clsColumnInfo1.Enabled = false;
			clsColumnInfo1.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo1.HeadText = "药品助记码";
			clsColumnInfo1.ReadOnly = true;
			clsColumnInfo1.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo2.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo2.BackColor = System.Drawing.Color.White;
			clsColumnInfo2.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo2.ColumnIndex = 1;
			clsColumnInfo2.ColumnName = "MEDICINENAME_VCHR";
			clsColumnInfo2.ColumnWidth = 130;
			clsColumnInfo2.Enabled = false;
			clsColumnInfo2.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo2.HeadText = "药品名称";
			clsColumnInfo2.ReadOnly = true;
			clsColumnInfo2.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo3.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo3.BackColor = System.Drawing.Color.White;
			clsColumnInfo3.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo3.ColumnIndex = 2;
			clsColumnInfo3.ColumnName = "MEDSPEC_VCHR";
			clsColumnInfo3.ColumnWidth = 110;
			clsColumnInfo3.Enabled = false;
			clsColumnInfo3.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo3.HeadText = "药品规格";
			clsColumnInfo3.ReadOnly = true;
			clsColumnInfo3.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo4.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo4.BackColor = System.Drawing.Color.White;
			clsColumnInfo4.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo4.ColumnIndex = 3;
			clsColumnInfo4.ColumnName = "IPUNIT_CHR";
			clsColumnInfo4.ColumnWidth = 75;
			clsColumnInfo4.Enabled = false;
			clsColumnInfo4.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo4.HeadText = "单位";
			clsColumnInfo4.ReadOnly = true;
			clsColumnInfo4.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo5.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo5.BackColor = System.Drawing.Color.White;
			clsColumnInfo5.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo5.ColumnIndex = 4;
			clsColumnInfo5.ColumnName = "UNITPRICE_MNY";
			clsColumnInfo5.ColumnWidth = 75;
			clsColumnInfo5.Enabled = false;
			clsColumnInfo5.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo5.HeadText = "现在价格";
			clsColumnInfo5.ReadOnly = true;
			clsColumnInfo5.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo6.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo6.BackColor = System.Drawing.Color.White;
			clsColumnInfo6.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo6.ColumnIndex = 5;
			clsColumnInfo6.ColumnName = "AMOUNT_DEC";
			clsColumnInfo6.ColumnWidth = 75;
			clsColumnInfo6.Enabled = true;
			clsColumnInfo6.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo6.HeadText = "现库存";
			clsColumnInfo6.ReadOnly = false;
			clsColumnInfo6.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo7.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo7.BackColor = System.Drawing.Color.White;
			clsColumnInfo7.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo7.ColumnIndex = 6;
			clsColumnInfo7.ColumnName = "PYCODE_CHR";
			clsColumnInfo7.ColumnWidth = 75;
			clsColumnInfo7.Enabled = false;
			clsColumnInfo7.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo7.HeadText = "拼音码";
			clsColumnInfo7.ReadOnly = true;
			clsColumnInfo7.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo8.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo8.BackColor = System.Drawing.Color.White;
			clsColumnInfo8.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo8.ColumnIndex = 7;
			clsColumnInfo8.ColumnName = "WBCODE_CHR";
			clsColumnInfo8.ColumnWidth = 75;
			clsColumnInfo8.Enabled = false;
			clsColumnInfo8.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo8.HeadText = "五笔码";
			clsColumnInfo8.ReadOnly = true;
			clsColumnInfo8.TextFont = new System.Drawing.Font("宋体", 10F);
			this.dgrMedicine.Columns.Add(clsColumnInfo1);
			this.dgrMedicine.Columns.Add(clsColumnInfo2);
			this.dgrMedicine.Columns.Add(clsColumnInfo3);
			this.dgrMedicine.Columns.Add(clsColumnInfo4);
			this.dgrMedicine.Columns.Add(clsColumnInfo5);
			this.dgrMedicine.Columns.Add(clsColumnInfo6);
			this.dgrMedicine.Columns.Add(clsColumnInfo7);
			this.dgrMedicine.Columns.Add(clsColumnInfo8);
			this.dgrMedicine.FullRowSelect = true;
			this.dgrMedicine.Location = new System.Drawing.Point(144, 728);
			this.dgrMedicine.MultiSelect = false;
			this.dgrMedicine.Name = "dgrMedicine";
			this.dgrMedicine.ReadOnly = true;
			this.dgrMedicine.RowHeadersVisible = true;
			this.dgrMedicine.RowHeaderWidth = 35;
			this.dgrMedicine.SelectedRowBackColor = System.Drawing.Color.Purple;
			this.dgrMedicine.SelectedRowForeColor = System.Drawing.Color.White;
			this.dgrMedicine.Size = new System.Drawing.Size(688, 488);
			this.dgrMedicine.TabIndex = 149;
			this.dgrMedicine.Visible = false;
			// 
			// panel5
			// 
			this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel5.Controls.Add(this.m_cboSelPeriod);
			this.panel5.Controls.Add(this.tabInOrd);
			this.panel5.Location = new System.Drawing.Point(0, 8);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(336, 680);
			this.panel5.TabIndex = 148;
			this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
			// 
			// m_cboSelPeriod
			// 
			this.m_cboSelPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_cboSelPeriod.Location = new System.Drawing.Point(129, 655);
			this.m_cboSelPeriod.Name = "m_cboSelPeriod";
			this.m_cboSelPeriod.Size = new System.Drawing.Size(200, 22);
			this.m_cboSelPeriod.TabIndex = 61;
			this.m_cboSelPeriod.SelectedIndexChanged += new System.EventHandler(this.m_cboSelPeriod_SelectedIndexChanged);
			this.m_cboSelPeriod.Enter += new System.EventHandler(this.m_cboSelPeriod_Enter);
			// 
			// tabInOrd
			// 
			this.tabInOrd.Alignment = System.Windows.Forms.TabAlignment.Bottom;
			this.tabInOrd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tabInOrd.Controls.Add(this.tab1);
			this.tabInOrd.Controls.Add(this.tab2);
			this.tabInOrd.ItemSize = new System.Drawing.Size(48, 17);
			this.tabInOrd.Location = new System.Drawing.Point(0, -6);
			this.tabInOrd.Name = "tabInOrd";
			this.tabInOrd.SelectedIndex = 0;
			this.tabInOrd.Size = new System.Drawing.Size(328, 680);
			this.tabInOrd.TabIndex = 21;
			this.tabInOrd.TabStop = false;
			this.tabInOrd.Enter += new System.EventHandler(this.tabInOrd_Enter);
			this.tabInOrd.SelectedIndexChanged += new System.EventHandler(this.tabInOrd_SelectedIndexChanged);
			// 
			// tab1
			// 
			this.tab1.Controls.Add(this.LSVInord);
			this.tab1.Location = new System.Drawing.Point(4, 4);
			this.tab1.Name = "tab1";
			this.tab1.Size = new System.Drawing.Size(320, 655);
			this.tab1.TabIndex = 0;
			this.tab1.Text = "未审核";
			// 
			// LSVInord
			// 
			this.LSVInord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.LSVInord.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					   this.columnHeader1,
																					   this.columnHeader2,
																					   this.columnHeader3,
																					   this.columnHeader4});
			this.LSVInord.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.LSVInord.FullRowSelect = true;
			this.LSVInord.GridLines = true;
			this.LSVInord.HideSelection = false;
			this.LSVInord.Location = new System.Drawing.Point(0, 0);
			this.LSVInord.Name = "LSVInord";
			this.LSVInord.Size = new System.Drawing.Size(328, 656);
			this.LSVInord.TabIndex = 24;
			this.LSVInord.TabStop = false;
			this.LSVInord.View = System.Windows.Forms.View.Details;
			this.LSVInord.Click += new System.EventHandler(this.LSVInord_Click);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "单据号";
			this.columnHeader1.Width = 135;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "经手人";
			this.columnHeader2.Width = 90;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "录入日期";
			this.columnHeader3.Width = 150;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "总金额";
			this.columnHeader4.Width = 70;
			// 
			// tab2
			// 
			this.tab2.Controls.Add(this.LSVInOrdEmp);
			this.tab2.Location = new System.Drawing.Point(4, 4);
			this.tab2.Name = "tab2";
			this.tab2.Size = new System.Drawing.Size(320, 655);
			this.tab2.TabIndex = 1;
			this.tab2.Text = "已审核";
			this.tab2.Visible = false;
			// 
			// LSVInOrdEmp
			// 
			this.LSVInOrdEmp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.LSVInOrdEmp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						  this.columnHeader5,
																						  this.columnHeader7,
																						  this.columnHeader8,
																						  this.columnHeader6});
			this.LSVInOrdEmp.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.LSVInOrdEmp.FullRowSelect = true;
			this.LSVInOrdEmp.GridLines = true;
			this.LSVInOrdEmp.HideSelection = false;
			this.LSVInOrdEmp.Location = new System.Drawing.Point(0, 0);
			this.LSVInOrdEmp.Name = "LSVInOrdEmp";
			this.LSVInOrdEmp.Size = new System.Drawing.Size(328, 656);
			this.LSVInOrdEmp.TabIndex = 23;
			this.LSVInOrdEmp.TabStop = false;
			this.LSVInOrdEmp.View = System.Windows.Forms.View.Details;
			this.LSVInOrdEmp.Click += new System.EventHandler(this.LSVInOrdEmp_Click);
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "单据号";
			this.columnHeader5.Width = 135;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "审核人";
			this.columnHeader7.Width = 90;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "审核日期";
			this.columnHeader8.Width = 150;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "总金额";
			this.columnHeader6.Width = 70;
			// 
			// panel4
			// 
			this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel4.Controls.Add(this.txtGrearMan);
			this.panel4.Controls.Add(this.label25);
			this.panel4.Controls.Add(this.comboType);
			this.panel4.Controls.Add(this.label24);
			this.panel4.Controls.Add(this.comboStroage);
			this.panel4.Controls.Add(this.label14);
			this.panel4.Controls.Add(this.txtTolmoney);
			this.panel4.Controls.Add(this.label8);
			this.panel4.Controls.Add(this.txtInOrdID);
			this.panel4.Controls.Add(this.label2);
			this.panel4.Controls.Add(this.dateTime);
			this.panel4.Controls.Add(this.label12);
			this.panel4.Controls.Add(this.m_txtMemo);
			this.panel4.Controls.Add(this.label4);
			this.panel4.Location = new System.Drawing.Point(336, 384);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(684, 112);
			this.panel4.TabIndex = 0;
			// 
			// txtGrearMan
			// 
			this.txtGrearMan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtGrearMan.EnableAutoValidation = true;
			this.txtGrearMan.EnableEnterKeyValidate = true;
			this.txtGrearMan.EnableEscapeKeyUndo = true;
			this.txtGrearMan.EnableLastValidValue = true;
			this.txtGrearMan.ErrorProvider = null;
			this.txtGrearMan.ErrorProviderMessage = "Invalid value";
			this.txtGrearMan.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtGrearMan.ForceFormatText = true;
			this.txtGrearMan.Location = new System.Drawing.Point(80, 48);
			this.txtGrearMan.Name = "txtGrearMan";
			this.txtGrearMan.ReadOnly = true;
			this.txtGrearMan.Size = new System.Drawing.Size(136, 23);
			this.txtGrearMan.TabIndex = 137;
			this.txtGrearMan.Text = "";
			// 
			// label25
			// 
			this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label25.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label25.Location = new System.Drawing.Point(16, 50);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(72, 16);
			this.label25.TabIndex = 136;
			this.label25.Text = "创 建 人";
			// 
			// comboType
			// 
			this.comboType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.comboType.Location = new System.Drawing.Point(304, 6);
			this.comboType.Name = "comboType";
			this.comboType.ReadOnly = true;
			this.comboType.Size = new System.Drawing.Size(136, 23);
			this.comboType.TabIndex = 138;
			this.comboType.Text = "";
			this.comboType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboType_KeyDown);
			// 
			// label24
			// 
			this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label24.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label24.Location = new System.Drawing.Point(240, 8);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(64, 16);
			this.label24.TabIndex = 134;
			this.label24.Text = "出药类型";
			// 
			// comboStroage
			// 
			this.comboStroage.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.comboStroage.Location = new System.Drawing.Point(528, 6);
			this.comboStroage.Name = "comboStroage";
			this.comboStroage.Size = new System.Drawing.Size(136, 22);
			this.comboStroage.TabIndex = 1;
			this.comboStroage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboStroage_KeyDown);
			this.comboStroage.SelectedIndexChanged += new System.EventHandler(this.comboStroage_SelectedIndexChanged);
			// 
			// label14
			// 
			this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label14.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label14.Location = new System.Drawing.Point(464, 8);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(64, 16);
			this.label14.TabIndex = 132;
			this.label14.Text = "药    房";
			// 
			// txtTolmoney
			// 
			this.txtTolmoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtTolmoney.EnableAutoValidation = true;
			this.txtTolmoney.EnableEnterKeyValidate = true;
			this.txtTolmoney.EnableEscapeKeyUndo = true;
			this.txtTolmoney.EnableLastValidValue = true;
			this.txtTolmoney.ErrorProvider = null;
			this.txtTolmoney.ErrorProviderMessage = "Invalid value";
			this.txtTolmoney.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtTolmoney.ForceFormatText = true;
			this.txtTolmoney.Location = new System.Drawing.Point(528, 48);
			this.txtTolmoney.Name = "txtTolmoney";
			this.txtTolmoney.ReadOnly = true;
			this.txtTolmoney.Size = new System.Drawing.Size(136, 23);
			this.txtTolmoney.TabIndex = 131;
			this.txtTolmoney.Text = "0.00";
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label8.Location = new System.Drawing.Point(464, 50);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(64, 16);
			this.label8.TabIndex = 130;
			this.label8.Text = "金    额";
			// 
			// txtInOrdID
			// 
			this.txtInOrdID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtInOrdID.EnableAutoValidation = true;
			this.txtInOrdID.EnableEnterKeyValidate = true;
			this.txtInOrdID.EnableEscapeKeyUndo = true;
			this.txtInOrdID.EnableLastValidValue = true;
			this.txtInOrdID.ErrorProvider = null;
			this.txtInOrdID.ErrorProviderMessage = "Invalid value";
			this.txtInOrdID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtInOrdID.ForceFormatText = true;
			this.txtInOrdID.Location = new System.Drawing.Point(80, 6);
			this.txtInOrdID.Name = "txtInOrdID";
			this.txtInOrdID.ReadOnly = true;
			this.txtInOrdID.Size = new System.Drawing.Size(136, 23);
			this.txtInOrdID.TabIndex = 129;
			this.txtInOrdID.Text = "";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(16, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 128;
			this.label2.Text = "单 号 ID";
			// 
			// dateTime
			// 
			this.dateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.dateTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.dateTime.Location = new System.Drawing.Point(304, 48);
			this.dateTime.MaxDate = new System.DateTime(2049, 12, 31, 0, 0, 0, 0);
			this.dateTime.MinDate = new System.DateTime(2004, 1, 1, 0, 0, 0, 0);
			this.dateTime.Name = "dateTime";
			this.dateTime.Size = new System.Drawing.Size(136, 23);
			this.dateTime.TabIndex = 2;
			this.dateTime.Value = new System.DateTime(2004, 9, 19, 23, 27, 57, 453);
			this.dateTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dateTime_KeyPress);
			// 
			// label12
			// 
			this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label12.Location = new System.Drawing.Point(240, 50);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(64, 16);
			this.label12.TabIndex = 118;
			this.label12.Text = "日    期";
			// 
			// m_txtMemo
			// 
			this.m_txtMemo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_txtMemo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtMemo.Location = new System.Drawing.Point(80, 80);
			this.m_txtMemo.Name = "m_txtMemo";
			this.m_txtMemo.Size = new System.Drawing.Size(584, 23);
			this.m_txtMemo.TabIndex = 3;
			this.m_txtMemo.Text = "";
			this.m_txtMemo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtMemo_KeyDown);
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label4.Location = new System.Drawing.Point(16, 80);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 16);
			this.label4.TabIndex = 117;
			this.label4.Text = "备    注";
			// 
			// panel3
			// 
			this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel3.Controls.Add(this.label6);
			this.panel3.Controls.Add(this.txtStorage);
			this.panel3.Controls.Add(this.label3);
			this.panel3.Controls.Add(this.txtSpace);
			this.panel3.Controls.Add(this.label5);
			this.panel3.Controls.Add(this.lblfind);
			this.panel3.Controls.Add(this.btnClear);
			this.panel3.Controls.Add(this.btnAdd);
			this.panel3.Controls.Add(this.txtTolPrice);
			this.panel3.Controls.Add(this.label27);
			this.panel3.Controls.Add(this.txttol);
			this.panel3.Controls.Add(this.label26);
			this.panel3.Controls.Add(this.txtbuyprice);
			this.panel3.Controls.Add(this.txtmedicine);
			this.panel3.Controls.Add(this.txtfind);
			this.panel3.Controls.Add(this.label30);
			this.panel3.Controls.Add(this.txtUnti);
			this.panel3.Controls.Add(this.label31);
			this.panel3.Controls.Add(this.label7);
			this.panel3.Controls.Add(this.m_txtUNIT);
			this.panel3.Controls.Add(this.label1);
			this.panel3.Location = new System.Drawing.Point(336, 504);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(684, 128);
			this.panel3.TabIndex = 1;
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label6.Location = new System.Drawing.Point(464, 58);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 16);
			this.label6.TabIndex = 166;
			this.label6.Text = "现 库 存";
			// 
			// txtStorage
			// 
			this.txtStorage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtStorage.EnableAutoValidation = false;
			this.txtStorage.EnableEnterKeyValidate = true;
			this.txtStorage.EnableEscapeKeyUndo = true;
			this.txtStorage.EnableLastValidValue = true;
			this.txtStorage.ErrorProvider = null;
			this.txtStorage.ErrorProviderMessage = "Invalid value";
			this.txtStorage.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtStorage.ForceFormatText = true;
			this.txtStorage.Location = new System.Drawing.Point(528, 56);
			this.txtStorage.Name = "txtStorage";
			this.txtStorage.ReadOnly = true;
			this.txtStorage.Size = new System.Drawing.Size(136, 23);
			this.txtStorage.TabIndex = 165;
			this.txtStorage.Text = "0.00";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.Location = new System.Drawing.Point(464, 18);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 164;
			this.label3.Text = "规    格";
			// 
			// txtSpace
			// 
			this.txtSpace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtSpace.EnableAutoValidation = true;
			this.txtSpace.EnableEnterKeyValidate = true;
			this.txtSpace.EnableEscapeKeyUndo = true;
			this.txtSpace.EnableLastValidValue = true;
			this.txtSpace.ErrorProvider = null;
			this.txtSpace.ErrorProviderMessage = "Invalid value";
			this.txtSpace.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtSpace.ForceFormatText = true;
			this.txtSpace.Location = new System.Drawing.Point(528, 16);
			this.txtSpace.Name = "txtSpace";
			this.txtSpace.ReadOnly = true;
			this.txtSpace.Size = new System.Drawing.Size(136, 23);
			this.txtSpace.TabIndex = 163;
			this.txtSpace.Text = "";
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label5.Location = new System.Drawing.Point(240, 98);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 16);
			this.label5.TabIndex = 162;
			this.label5.Text = "零售总额";
			// 
			// lblfind
			// 
			this.lblfind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblfind.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblfind.Location = new System.Drawing.Point(16, 16);
			this.lblfind.Name = "lblfind";
			this.lblfind.Size = new System.Drawing.Size(64, 16);
			this.lblfind.TabIndex = 161;
			this.lblfind.Text = "查找药品";
			// 
			// btnClear
			// 
			this.btnClear.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btnClear.DefaultScheme = true;
			this.btnClear.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btnClear.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnClear.Hint = "";
			this.btnClear.Location = new System.Drawing.Point(592, 92);
			this.btnClear.Name = "btnClear";
			this.btnClear.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btnClear.Size = new System.Drawing.Size(72, 24);
			this.btnClear.TabIndex = 160;
			this.btnClear.TabStop = false;
			this.btnClear.Text = "清空(&C)";
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btnAdd.DefaultScheme = true;
			this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btnAdd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnAdd.Hint = "";
			this.btnAdd.Location = new System.Drawing.Point(480, 92);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btnAdd.Size = new System.Drawing.Size(72, 24);
			this.btnAdd.TabIndex = 7;
			this.btnAdd.TabStop = false;
			this.btnAdd.Text = "增加(&S)";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// txtTolPrice
			// 
			this.txtTolPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtTolPrice.EnableAutoValidation = true;
			this.txtTolPrice.EnableEnterKeyValidate = true;
			this.txtTolPrice.EnableEscapeKeyUndo = true;
			this.txtTolPrice.EnableLastValidValue = true;
			this.txtTolPrice.ErrorProvider = null;
			this.txtTolPrice.ErrorProviderMessage = "Invalid value";
			this.txtTolPrice.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtTolPrice.ForceFormatText = true;
			this.txtTolPrice.Location = new System.Drawing.Point(304, 96);
			this.txtTolPrice.Name = "txtTolPrice";
			this.txtTolPrice.ReadOnly = true;
			this.txtTolPrice.Size = new System.Drawing.Size(136, 23);
			this.txtTolPrice.TabIndex = 157;
			this.txtTolPrice.Text = "0.00";
			// 
			// label27
			// 
			this.label27.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label27.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label27.Location = new System.Drawing.Point(240, 58);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(64, 16);
			this.label27.TabIndex = 156;
			this.label27.Text = "数    量";
			// 
			// txttol
			// 
			this.txttol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txttol.EnableAutoValidation = false;
			this.txttol.EnableEnterKeyValidate = true;
			this.txttol.EnableEscapeKeyUndo = true;
			this.txttol.EnableLastValidValue = true;
			this.txttol.ErrorProvider = null;
			this.txttol.ErrorProviderMessage = "Invalid value";
			this.txttol.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txttol.ForceFormatText = true;
			this.txttol.Location = new System.Drawing.Point(304, 56);
			this.txttol.Name = "txttol";
			this.txttol.NumericCharStyle = ((SourceLibrary.Windows.Forms.NumericCharStyle)((SourceLibrary.Windows.Forms.NumericCharStyle.DecimalSeparator | SourceLibrary.Windows.Forms.NumericCharStyle.NegativeSymbol)));
			this.txttol.Size = new System.Drawing.Size(136, 23);
			this.txttol.TabIndex = 109;
			this.txttol.Text = "0";
			this.txttol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txttol.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txttol_KeyDown);
			this.txttol.TextChanged += new System.EventHandler(this.txttol_TextChanged);
			this.txttol.Enter += new System.EventHandler(this.txttol_Enter);
			// 
			// label26
			// 
			this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label26.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label26.Location = new System.Drawing.Point(16, 98);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(64, 16);
			this.label26.TabIndex = 154;
			this.label26.Text = "零售价格";
			// 
			// txtbuyprice
			// 
			this.txtbuyprice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtbuyprice.EnableAutoValidation = false;
			this.txtbuyprice.EnableEnterKeyValidate = true;
			this.txtbuyprice.EnableEscapeKeyUndo = true;
			this.txtbuyprice.EnableLastValidValue = true;
			this.txtbuyprice.ErrorProvider = null;
			this.txtbuyprice.ErrorProviderMessage = "Invalid value";
			this.txtbuyprice.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtbuyprice.ForceFormatText = true;
			this.txtbuyprice.Location = new System.Drawing.Point(80, 96);
			this.txtbuyprice.Name = "txtbuyprice";
			this.txtbuyprice.ReadOnly = true;
			this.txtbuyprice.Size = new System.Drawing.Size(136, 23);
			this.txtbuyprice.TabIndex = 153;
			this.txtbuyprice.Text = "0.00";
			// 
			// txtmedicine
			// 
			this.txtmedicine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtmedicine.EnableAutoValidation = true;
			this.txtmedicine.EnableEnterKeyValidate = true;
			this.txtmedicine.EnableEscapeKeyUndo = true;
			this.txtmedicine.EnableLastValidValue = true;
			this.txtmedicine.ErrorProvider = null;
			this.txtmedicine.ErrorProviderMessage = "Invalid value";
			this.txtmedicine.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtmedicine.ForceFormatText = true;
			this.txtmedicine.Location = new System.Drawing.Point(304, 16);
			this.txtmedicine.Name = "txtmedicine";
			this.txtmedicine.ReadOnly = true;
			this.txtmedicine.Size = new System.Drawing.Size(136, 23);
			this.txtmedicine.TabIndex = 150;
			this.txtmedicine.Text = "";
			// 
			// txtfind
			// 
			this.txtfind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtfind.EnableAutoValidation = true;
			this.txtfind.EnableEnterKeyValidate = true;
			this.txtfind.EnableEscapeKeyUndo = true;
			this.txtfind.EnableLastValidValue = true;
			this.txtfind.ErrorProvider = null;
			this.txtfind.ErrorProviderMessage = "Invalid value";
			this.txtfind.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtfind.ForceFormatText = true;
			this.txtfind.Location = new System.Drawing.Point(80, 16);
			this.txtfind.Name = "txtfind";
			this.txtfind.Size = new System.Drawing.Size(136, 23);
			this.txtfind.TabIndex = 1000;
			this.txtfind.Text = "";
			this.txtfind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtfind_KeyDown);
			// 
			// label30
			// 
			this.label30.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label30.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label30.Location = new System.Drawing.Point(240, 18);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(64, 16);
			this.label30.TabIndex = 148;
			this.label30.Text = "药品名称";
			// 
			// txtUnti
			// 
			this.txtUnti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtUnti.EnableAutoValidation = true;
			this.txtUnti.EnableEnterKeyValidate = true;
			this.txtUnti.EnableEscapeKeyUndo = true;
			this.txtUnti.EnableLastValidValue = true;
			this.txtUnti.ErrorProvider = null;
			this.txtUnti.ErrorProviderMessage = "Invalid value";
			this.txtUnti.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtUnti.ForceFormatText = true;
			this.txtUnti.Location = new System.Drawing.Point(80, 56);
			this.txtUnti.Name = "txtUnti";
			this.txtUnti.ReadOnly = true;
			this.txtUnti.Size = new System.Drawing.Size(136, 23);
			this.txtUnti.TabIndex = 146;
			this.txtUnti.Text = "";
			// 
			// label31
			// 
			this.label31.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label31.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label31.Location = new System.Drawing.Point(16, 58);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(64, 16);
			this.label31.TabIndex = 147;
			this.label31.Text = "单    位";
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label7.Location = new System.Drawing.Point(232, 128);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(56, 16);
			this.label7.TabIndex = 123;
			this.label7.Text = "药品名称";
			// 
			// m_txtUNIT
			// 
			this.m_txtUNIT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_txtUNIT.EnableAutoValidation = true;
			this.m_txtUNIT.Enabled = false;
			this.m_txtUNIT.EnableEnterKeyValidate = true;
			this.m_txtUNIT.EnableEscapeKeyUndo = true;
			this.m_txtUNIT.EnableLastValidValue = true;
			this.m_txtUNIT.ErrorProvider = null;
			this.m_txtUNIT.ErrorProviderMessage = "Invalid value";
			this.m_txtUNIT.ForceFormatText = true;
			this.m_txtUNIT.Location = new System.Drawing.Point(80, 168);
			this.m_txtUNIT.Name = "m_txtUNIT";
			this.m_txtUNIT.Size = new System.Drawing.Size(104, 23);
			this.m_txtUNIT.TabIndex = 5;
			this.m_txtUNIT.Text = "";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.Location = new System.Drawing.Point(16, 168);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 116;
			this.label1.Text = "单    位";
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.dntEmp);
			this.groupBox3.Controls.Add(this.btnesc);
			this.groupBox3.Controls.Add(this.btnDelect);
			this.groupBox3.Controls.Add(this.btnFind);
			this.groupBox3.Controls.Add(this.btnSave);
			this.groupBox3.Controls.Add(this.m_btnNew);
			this.groupBox3.Location = new System.Drawing.Point(336, 640);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(684, 48);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
			// 
			// dntEmp
			// 
			this.dntEmp.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.dntEmp.DefaultScheme = true;
			this.dntEmp.DialogResult = System.Windows.Forms.DialogResult.None;
			this.dntEmp.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.dntEmp.Hint = "";
			this.dntEmp.Location = new System.Drawing.Point(272, 16);
			this.dntEmp.Name = "dntEmp";
			this.dntEmp.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.dntEmp.Size = new System.Drawing.Size(72, 24);
			this.dntEmp.TabIndex = 54;
			this.dntEmp.TabStop = false;
			this.dntEmp.Text = "审核(F3)";
			this.dntEmp.Click += new System.EventHandler(this.dntEmp_Click);
			// 
			// btnesc
			// 
			this.btnesc.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btnesc.DefaultScheme = true;
			this.btnesc.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btnesc.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnesc.Hint = "";
			this.btnesc.Location = new System.Drawing.Point(592, 16);
			this.btnesc.Name = "btnesc";
			this.btnesc.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btnesc.Size = new System.Drawing.Size(72, 24);
			this.btnesc.TabIndex = 53;
			this.btnesc.TabStop = false;
			this.btnesc.Text = "退出(ESE)";
			this.btnesc.Click += new System.EventHandler(this.btnesc_Click);
			// 
			// btnDelect
			// 
			this.btnDelect.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btnDelect.DefaultScheme = true;
			this.btnDelect.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btnDelect.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnDelect.Hint = "";
			this.btnDelect.Location = new System.Drawing.Point(480, 16);
			this.btnDelect.Name = "btnDelect";
			this.btnDelect.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btnDelect.Size = new System.Drawing.Size(72, 24);
			this.btnDelect.TabIndex = 52;
			this.btnDelect.TabStop = false;
			this.btnDelect.Text = "删除(F5)";
			this.btnDelect.Click += new System.EventHandler(this.btnDelect_Click);
			// 
			// btnFind
			// 
			this.btnFind.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btnFind.DefaultScheme = true;
			this.btnFind.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btnFind.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnFind.Hint = "";
			this.btnFind.Location = new System.Drawing.Point(376, 16);
			this.btnFind.Name = "btnFind";
			this.btnFind.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btnFind.Size = new System.Drawing.Size(72, 24);
			this.btnFind.TabIndex = 51;
			this.btnFind.TabStop = false;
			this.btnFind.Text = "查找(F4)";
			this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
			// 
			// btnSave
			// 
			this.btnSave.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btnSave.DefaultScheme = true;
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btnSave.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnSave.Hint = "";
			this.btnSave.Location = new System.Drawing.Point(168, 16);
			this.btnSave.Name = "btnSave";
			this.btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btnSave.Size = new System.Drawing.Size(72, 24);
			this.btnSave.TabIndex = 17;
			this.btnSave.TabStop = false;
			this.btnSave.Text = "保存(F2)";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// m_btnNew
			// 
			this.m_btnNew.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnNew.DefaultScheme = true;
			this.m_btnNew.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnNew.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_btnNew.Hint = "";
			this.m_btnNew.Location = new System.Drawing.Point(64, 16);
			this.m_btnNew.Name = "m_btnNew";
			this.m_btnNew.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnNew.Size = new System.Drawing.Size(72, 24);
			this.m_btnNew.TabIndex = 49;
			this.m_btnNew.TabStop = false;
			this.m_btnNew.Text = "新建(F1)";
			this.m_btnNew.Click += new System.EventHandler(this.m_btnNew_Click);
			// 
			// LSVInOrdDe
			// 
			this.LSVInOrdDe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.LSVInOrdDe.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						 this.ROWNO_CHR,
																						 this.MEDICINEID_CHR,
																						 this.MEDICINENAME_CHR,
																						 this.space,
																						 this.UNITID_CHR,
																						 this.QTY_DEC,
																						 this.CURPRICE_MNY,
																						 this.col7});
			this.LSVInOrdDe.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.LSVInOrdDe.FullRowSelect = true;
			this.LSVInOrdDe.GridLines = true;
			this.LSVInOrdDe.HideSelection = false;
			this.LSVInOrdDe.Location = new System.Drawing.Point(336, 8);
			this.LSVInOrdDe.Name = "LSVInOrdDe";
			this.LSVInOrdDe.Size = new System.Drawing.Size(684, 368);
			this.LSVInOrdDe.TabIndex = 21;
			this.LSVInOrdDe.TabStop = false;
			this.LSVInOrdDe.View = System.Windows.Forms.View.Details;
			this.LSVInOrdDe.Click += new System.EventHandler(this.LSVInOrdDe_Click);
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel2.Controls.Add(this.label23);
			this.panel2.Controls.Add(this.label22);
			this.panel2.Controls.Add(this.label21);
			this.panel2.Controls.Add(this.label20);
			this.panel2.Controls.Add(this.label19);
			this.panel2.Controls.Add(this.label18);
			this.panel2.Location = new System.Drawing.Point(0, 696);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1028, 32);
			this.panel2.TabIndex = 100;
			// 
			// label23
			// 
			this.label23.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label23.ForeColor = System.Drawing.SystemColors.Desktop;
			this.label23.Location = new System.Drawing.Point(823, 0);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(176, 23);
			this.label23.TabIndex = 105;
			this.label23.Text = "F10使查找具有输入焦点";
			this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label22
			// 
			this.label22.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label22.ForeColor = System.Drawing.SystemColors.Desktop;
			this.label22.Location = new System.Drawing.Point(592, 0);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(216, 23);
			this.label22.TabIndex = 101;
			this.label22.Text = "F9使药品查找输入框具有焦点";
			this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label21
			// 
			this.label21.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label21.ForeColor = System.Drawing.SystemColors.Desktop;
			this.label21.Location = new System.Drawing.Point(441, 0);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(136, 23);
			this.label21.TabIndex = 106;
			this.label21.Text = "F8选中明细窗体";
			this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label20
			// 
			this.label20.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label20.ForeColor = System.Drawing.SystemColors.Desktop;
			this.label20.Location = new System.Drawing.Point(274, 0);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(152, 23);
			this.label20.TabIndex = 107;
			this.label20.Text = "F7选中己审核窗体";
			this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label19
			// 
			this.label19.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label19.ForeColor = System.Drawing.SystemColors.Desktop;
			this.label19.Location = new System.Drawing.Point(123, 0);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(136, 23);
			this.label19.TabIndex = 107;
			this.label19.Text = "F6选中未审核窗体";
			this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label18
			// 
			this.label18.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label18.ForeColor = System.Drawing.SystemColors.Desktop;
			this.label18.Location = new System.Drawing.Point(8, 0);
			this.label18.Name = "label18";
			this.label18.TabIndex = 108;
			this.label18.Text = "快捷键提示:";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			// 
			// frmMedStoreOut
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(1028, 729);
			this.Controls.Add(this.panel6);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.KeyPreview = true;
			this.Name = "frmMedStoreOut";
			this.Text = "药房出药";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMedStoreOut_KeyDown);
			this.Load += new System.EventHandler(this.frmMedStoreOut_Load);
			this.panel6.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrMedicine)).EndInit();
			this.panel5.ResumeLayout(false);
			this.tabInOrd.ResumeLayout(false);
			this.tab1.ResumeLayout(false);
			this.tab2.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void CreateController()
		{
			this.objController = new clsControlMedStoreOut();
			this.objController.Set_GUI_Apperance(this);
		}
		public void SendOrdType(string ordType)
		{
			clsDomainControlMedStore Domain=new clsDomainControlMedStore();
			DataTable dtbStorage=new DataTable();
			string strTypeName="";
			Domain.m_lngGetTypeAndStorageOut(ordType,out strTypeName,out dtbStorage);
			if(strTypeName!="")
			{
				comboType.Tag=ordType;
				comboType.Text=strTypeName;
				this.Text=strTypeName;
			}
			else
			{
				MessageBox.Show("输入的进药类型ID不正确！","icare",MessageBoxButtons.OK,MessageBoxIcon.Stop);
				return;
			}
			this.Show();
		}
		private void frmMedStoreOut_Load(object sender, System.EventArgs e)
		{
			this.m_mthSetEnter2Tab(new System.Windows.Forms.Control[] {});
			((clsControlMedStoreOut)this.objController).m_lngFrmLoad();
			this.comboType.Focus();
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			if(txtmedicine.Text==""||txtmedicine.Tag==null)
			{
				errorProvider1.SetError(txtmedicine,"不能为空");
				txtfind.Focus();
				return;
			}
			else
			{
				errorProvider1.SetError(txtmedicine,"");
			}
			if(this.txttol.Text=="0")
			{
				errorProvider1.SetError(txttol,"不能为空");
				txttol.Focus();
				return;
			}
			else
			{
				errorProvider1.SetError(txttol,"");
			}

			if(Convert.ToDouble(this.txttol.Text)>Convert.ToDouble(txtStorage.Text))
			{
				MessageBox.Show("出药数量不可以大于库存数量","提示");
				this.txttol.Focus();
			}
			else
			{
				((clsControlMedStoreOut)this.objController).m_lngAddClickOut();
				txtfind.Focus();
			}
		}

		private void txtfind_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Up&&dgrMedicine.RowCount>0)
			{
				if(dgrMedicine.CurrentCell.RowNumber==0)
				{
					dgrMedicine.CurrentCell=new DataGridCell(dgrMedicine.RowCount,0);
				}
				if(dgrMedicine.CurrentCell.RowNumber>0)
				{
					dgrMedicine.CurrentCell=new DataGridCell(dgrMedicine.CurrentCell.RowNumber-1,0);
				}
			}
			if(e.KeyCode==Keys.Down&&dgrMedicine.RowCount>0)
			{
				if(dgrMedicine.CurrentCell.RowNumber<dgrMedicine.RowCount)
				{
					dgrMedicine.CurrentCell=new DataGridCell(dgrMedicine.CurrentCell.RowNumber+1,0);
				}
				if(dgrMedicine.CurrentCell.RowNumber==dgrMedicine.RowCount)
				{
					dgrMedicine.CurrentCell=new DataGridCell(0,0);
				}
			}
			Application.DoEvents();
			if(e.KeyCode!=Keys.F1&&e.KeyCode!=Keys.F2)
			txtfind.Focus();

			if(e.KeyCode==Keys.Enter)
			{
				if(dgrMedicine.Visible==true)
				{
					((clsControlMedStoreOut)this.objController).m_lngSeleMed();
				}
				else
				{
					((clsControlMedStoreOut)this.objController).m_lngFind();
				}
			}
		}

		private void comboType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			((clsControlMedStoreOut)this.objController).m_lngSeleChangOut(1);
		}

		private void comboStroage_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			((clsControlMedStoreOut)this.objController).m_lngSeleChangOut(2);
		}

		private void txttol_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				if(Convert.ToDouble(this.txttol.Text)>Convert.ToDouble(txtStorage.Text))
				{
					MessageBox.Show("出药数量不可以大于库存数量","提示");
					this.txttol.Focus();
				}
				else
				{
					double tolmoney=Convert.ToDouble(this.txtbuyprice.Text.Trim())*Convert.ToInt32(this.txttol.Text.Trim());
					this.txtTolPrice.Text=tolmoney.ToString();
					this.btnAdd.Focus();
				}
			}
		}

		private void txttol_Enter(object sender, System.EventArgs e)
		{
			if(this.dgrMedicine.Visible==true)
				this.dgrMedicine.Visible=false;
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			((clsControlMedStoreOut)this.objController).m_lngSaveClickOut();
			comboStroage.Focus();
		}

		private void LSVInord_Click(object sender, System.EventArgs e)
		{
			if(this.dgrMedicine.Visible==true)
				this.dgrMedicine.Visible=false;
			((clsControlMedStoreOut)this.objController).m_lngShowDeBySelete();
		}

		private void LSVInOrdDe_Click(object sender, System.EventArgs e)
		{
			((clsControlMedStoreOut)this.objController).m_lngFillTxtboxOrdDe();
		}

		private void btnesc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void m_btnNew_Click(object sender, System.EventArgs e)
		{
			((clsControlMedStoreOut)this.objController).m_lngClearOut(2);
		}

		private void btnClear_Click(object sender, System.EventArgs e)
		{
			((clsControlMedStoreOut)this.objController).m_lngClearOut(1);
		}

		private void btnDelect_Click(object sender, System.EventArgs e)
		{
			((clsControlMedStoreOut)this.objController).m_lngDeleClick();
		}

		private void dntEmp_Click(object sender, System.EventArgs e)
		{
			((clsControlMedStoreOut)this.objController).m_lngAduiClickOut();
		}

		private void txttol_TextChanged(object sender, System.EventArgs e)
		{
		}

		private void btnFind_Click(object sender, System.EventArgs e)
		{
			this.panel6.Top=this.panel4.Top-this.panel6.Height-15;
			this.panel6.Left=this.panel4.Left+3;
			LSVInOrdDe.Height=LSVInOrdDe.Height-this.panel6.Height;
			this.panel6.Visible=true;
		}

		private void btnFinddata_Click(object sender, System.EventArgs e)
		{
			((clsControlMedStoreOut)this.objController).m_lngFindClick();
		}

		private void btnColes_Click(object sender, System.EventArgs e)
		{
			LSVInOrdDe.Height=LSVInOrdDe.Height+this.panel6.Height+10;
			((clsControlMedStoreOut)this.objController).m_lngReturnClick();
		}

		private void comboType_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.m_mthSetKeyTab(e);
			if(e.KeyCode==Keys.F1)
			{
				if(this.dgrMedicine.Visible==true)
					this.dgrMedicine.Visible=false;
				((clsControlMedStoreOut)this.objController).m_lngClearOut(2);
			}
			if(e.KeyCode==Keys.F2)
			{
				((clsControlMedStoreOut)this.objController).m_lngSaveClickOut();
			}
			if(e.KeyCode==Keys.F3)
			{
				((clsControlMedStoreOut)this.objController).m_lngAduiClickOut();
			}
			if(e.KeyCode==Keys.F4)
			{
				this.panel6.Top=this.panel4.Top-this.panel6.Height-13;
				this.panel6.Left=this.panel4.Left+2;
				this.panel6.Visible=true;
			}

			if(e.KeyCode==Keys.F5)
			{
				if(this.dgrMedicine.Visible==true)
					this.dgrMedicine.Visible=false;
				((clsControlMedStoreOut)this.objController).m_lngDeleClick();
			}
			if(e.KeyCode==Keys.Escape)
			{
				this.Close();
			}

			if(e.KeyCode==Keys.F6)
			{
				this.tabInOrd.SelectedIndex=0;
				if(this.LSVInord.Items.Count>0)
				{
					this.LSVInord.Items[0].Selected=true;
				}
			}
			if(e.KeyCode==Keys.F7)
			{
				this.tabInOrd.SelectedIndex=1;
				if(this.LSVInOrdEmp.Items.Count>0)
				{
					this.LSVInOrdEmp.Items[0].Selected=true;
				}
			}

			if(e.KeyCode==Keys.F8)
			{
				if(this.LSVInOrdDe.Items.Count>0)
				{
					this.LSVInOrdDe.Items[0].Selected=true;
				}
			}
			if(e.KeyCode==Keys.F9)
			{
				txtfind.Focus();
			}
			if(e.KeyCode==Keys.F10)
			{
				TextID.Focus();
			}
		}

		private void tabInOrd_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.dgrMedicine.Visible==true)
				this.dgrMedicine.Visible=false;

			if(tabInOrd.SelectedIndex==1)
			{
				this.panel4.Enabled=false;
				this.panel3.Enabled=false;
				this.m_btnNew.Enabled=false;
				this.btnSave.Enabled=false;
				this.dntEmp.Enabled=false;
				this.btnDelect.Enabled=false;
			}
			else
			{
				this.panel4.Enabled=true;
				this.panel3.Enabled=true;
				this.m_btnNew.Enabled=true;
				this.btnSave.Enabled=true;
				this.dntEmp.Enabled=true;
				this.btnDelect.Enabled=true;
			}
		}

		private void LSVInOrdEmp_Click(object sender, System.EventArgs e)
		{
			((clsControlMedStoreOut)this.objController).m_lngShowDeBySelete();
		}

		private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}

		private void panel5_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}

		private void frmMedStoreOut_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.F1)
			{
				((clsControlMedStoreOut)this.objController).m_lngClearOut(2);
			}
			if(e.KeyCode==Keys.F2)
			{
				((clsControlMedStoreOut)this.objController).m_lngSaveClickOut();
			}
			if(e.KeyCode==Keys.F3)
			{
				((clsControlMedStoreOut)this.objController).m_lngAduiClickOut();
			}
			if(e.KeyCode==Keys.F4)
			{
				this.panel6.Top=this.panel4.Top-this.panel6.Height-13;
				this.panel6.Left=this.panel4.Left+2;
				this.panel6.Visible=true;
			}

			if(e.KeyCode==Keys.F5)
			{
				((clsControlMedStoreOut)this.objController).m_lngDeleClick();
			}
			if(e.KeyCode==Keys.Escape)
			{
				this.Close();
			}

			if(e.KeyCode==Keys.F6)
			{
				this.tabInOrd.SelectedIndex=0;
				if(this.LSVInord.Items.Count>0)
				{
					this.LSVInord.Items[0].Selected=true;
				}
			}
			if(e.KeyCode==Keys.F7)
			{
				this.tabInOrd.SelectedIndex=1;
				if(this.LSVInOrdEmp.Items.Count>0)
				{
					this.LSVInOrdEmp.Items[0].Selected=true;
				}
			}

			if(e.KeyCode==Keys.F8)
			{
				if(this.LSVInOrdDe.Items.Count>0)
				{
					this.LSVInOrdDe.Items[0].Selected=true;
				}
			}
			if(e.KeyCode==Keys.F9)
			{
				txtfind.Focus();
			}
			if(e.KeyCode==Keys.F10)
			{
				TextID.Focus();
			}
		}

		private void m_txtMemo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				this.txtfind.Focus();
		}

		private void TextID_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.m_mthSetKeyTab(e);
		}

		private void GrearNAME_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.m_mthSetKeyTab(e);
		}

		private void APPLDATE_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.m_mthSetKeyTab(e);
		}

		private void txtfindstroage_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.m_mthSetKeyTab(e);
		}

		private void txtType_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				this.btnFinddata.Focus();
		}

		private void comboStroage_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.F1)
			{
				if(this.dgrMedicine.Visible==true)
					this.dgrMedicine.Visible=false;
				((clsControlMedStoreOut)this.objController).m_lngClearOut(2);
			}
			if(e.KeyCode==Keys.F2)
			{
				((clsControlMedStoreOut)this.objController).m_lngSaveClickOut();
			}
			if(e.KeyCode==Keys.F3)
			{
				((clsControlMedStoreOut)this.objController).m_lngAduiClickOut();
			}
			if(e.KeyCode==Keys.F4)
			{
				this.panel6.Top=this.panel4.Top-this.panel6.Height-13;
				this.panel6.Left=this.panel4.Left+2;
				this.panel6.Visible=true;
			}

			if(e.KeyCode==Keys.F5)
			{
				if(this.dgrMedicine.Visible==true)
					this.dgrMedicine.Visible=false;
				((clsControlMedStoreOut)this.objController).m_lngDeleClick();
			}
			if(e.KeyCode==Keys.Escape)
			{
				this.Close();
			}

			if(e.KeyCode==Keys.F6)
			{
				this.tabInOrd.SelectedIndex=0;
				if(this.LSVInord.Items.Count>0)
				{
					this.LSVInord.Items[0].Selected=true;
				}
			}
			if(e.KeyCode==Keys.F7)
			{
				this.tabInOrd.SelectedIndex=1;
				if(this.LSVInOrdEmp.Items.Count>0)
				{
					this.LSVInOrdEmp.Items[0].Selected=true;
				}
			}

			if(e.KeyCode==Keys.F8)
			{
				if(this.LSVInOrdDe.Items.Count>0)
				{
					this.LSVInOrdDe.Items[0].Selected=true;
				}
			}
			if(e.KeyCode==Keys.F9)
			{
				txtfind.Focus();
			}
			if(e.KeyCode==Keys.F10)
			{
				TextID.Focus();
			}
			this.m_mthSetKeyTab(e);
		}

		private void dateTime_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.m_mthSetKeyTab(e);
		}

		private void m_cboSelPeriod_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			((clsControlMedStoreOut)this.objController).m_lngPriodchang();
		}
		int count=0;
		private void dateTime_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
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

		private void tabInOrd_Enter(object sender, System.EventArgs e)
		{
			if(dgrMedicine.Visible==true)
				dgrMedicine.Visible=false;
		}

		private void m_cboSelPeriod_Enter(object sender, System.EventArgs e)
		{
			if(dgrMedicine.Visible==true)
				dgrMedicine.Visible=false;
		}

		private void groupBox3_Enter(object sender, System.EventArgs e)
		{
			if(dgrMedicine.Visible==true)
				dgrMedicine.Visible=false;
		}
	}
}
