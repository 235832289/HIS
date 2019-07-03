using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 药房限额设置
	/// </summary>
	public class frmMedStoreLimit : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.Label label1;
		internal System.Windows.Forms.ComboBox m_cboMedStore;
		internal System.Windows.Forms.ListView m_lsvDetail;
		private System.Windows.Forms.ColumnHeader clhMedID;
		private System.Windows.Forms.ColumnHeader clhMedName;
		private System.Windows.Forms.ColumnHeader clhUnit;
		private System.Windows.Forms.ColumnHeader clhHight;
		private System.Windows.Forms.ColumnHeader clhLow;
		private System.Windows.Forms.ColumnHeader clhPlanQty;
		private System.Windows.Forms.ColumnHeader clhPlanPercent;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtMedID;
		internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric m_txtLow;
		internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric m_txtHight;
		internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric m_txtPlanQty;
		private System.Windows.Forms.Label label8;
		internal System.Windows.Forms.NumericUpDown m_numPlanPercent;
		private PinkieControls.ButtonXP m_cmdSave;
		private PinkieControls.ButtonXP m_cmdNew;
		private PinkieControls.ButtonXP m_cmdDelete;
		private PinkieControls.ButtonXP m_cmdRefersh;
		private PinkieControls.ButtonXP m_cmdClose;
		internal System.Windows.Forms.TextBox m_txtUnit;
		internal com.digitalwave.controls.datagrid.ctlDataGrid ctlDataGridMed;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtmedName;
		private System.Windows.Forms.Label label9;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// 
		/// </summary>
		public frmMedStoreLimit()
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
			this.label1 = new System.Windows.Forms.Label();
			this.m_cboMedStore = new System.Windows.Forms.ComboBox();
			this.m_lsvDetail = new System.Windows.Forms.ListView();
			this.clhMedID = new System.Windows.Forms.ColumnHeader();
			this.clhMedName = new System.Windows.Forms.ColumnHeader();
			this.clhUnit = new System.Windows.Forms.ColumnHeader();
			this.clhLow = new System.Windows.Forms.ColumnHeader();
			this.clhHight = new System.Windows.Forms.ColumnHeader();
			this.clhPlanQty = new System.Windows.Forms.ColumnHeader();
			this.clhPlanPercent = new System.Windows.Forms.ColumnHeader();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.ctlDataGridMed = new com.digitalwave.controls.datagrid.ctlDataGrid();
			this.label9 = new System.Windows.Forms.Label();
			this.m_txtmedName = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.m_txtUnit = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.m_numPlanPercent = new System.Windows.Forms.NumericUpDown();
			this.m_txtPlanQty = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
			this.m_txtHight = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
			this.m_txtLow = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.m_txtMedID = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.m_cmdClose = new PinkieControls.ButtonXP();
			this.m_cmdRefersh = new PinkieControls.ButtonXP();
			this.m_cmdDelete = new PinkieControls.ButtonXP();
			this.m_cmdNew = new PinkieControls.ButtonXP();
			this.m_cmdSave = new PinkieControls.ButtonXP();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ctlDataGridMed)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.m_numPlanPercent)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(63, 19);
			this.label1.TabIndex = 0;
			this.label1.Text = "选择药房";
			// 
			// m_cboMedStore
			// 
			this.m_cboMedStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboMedStore.Location = new System.Drawing.Point(80, 8);
			this.m_cboMedStore.Name = "m_cboMedStore";
			this.m_cboMedStore.Size = new System.Drawing.Size(121, 22);
			this.m_cboMedStore.TabIndex = 1;
			this.m_cboMedStore.SelectedIndexChanged += new System.EventHandler(this.m_cboMedStore_SelectedIndexChanged);
			// 
			// m_lsvDetail
			// 
			this.m_lsvDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lsvDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						  this.clhMedID,
																						  this.clhMedName,
																						  this.clhUnit,
																						  this.clhLow,
																						  this.clhHight,
																						  this.clhPlanQty,
																						  this.clhPlanPercent});
			this.m_lsvDetail.FullRowSelect = true;
			this.m_lsvDetail.GridLines = true;
			this.m_lsvDetail.Location = new System.Drawing.Point(272, 40);
			this.m_lsvDetail.Name = "m_lsvDetail";
			this.m_lsvDetail.Size = new System.Drawing.Size(654, 592);
			this.m_lsvDetail.TabIndex = 2;
			this.m_lsvDetail.View = System.Windows.Forms.View.Details;
			this.m_lsvDetail.Click += new System.EventHandler(this.m_lsvDetail_Click);
			this.m_lsvDetail.DoubleClick += new System.EventHandler(this.m_lsvDetail_DoubleClick);
			this.m_lsvDetail.Enter += new System.EventHandler(this.m_lsvDetail_Enter);
			// 
			// clhMedID
			// 
			this.clhMedID.Text = "药品编号";
			this.clhMedID.Width = 82;
			// 
			// clhMedName
			// 
			this.clhMedName.Text = "药品名称";
			this.clhMedName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.clhMedName.Width = 134;
			// 
			// clhUnit
			// 
			this.clhUnit.Text = "单位";
			this.clhUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.clhUnit.Width = 82;
			// 
			// clhLow
			// 
			this.clhLow.Text = "下限";
			this.clhLow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.clhLow.Width = 80;
			// 
			// clhHight
			// 
			this.clhHight.Text = "上限";
			this.clhHight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.clhHight.Width = 82;
			// 
			// clhPlanQty
			// 
			this.clhPlanQty.Text = "领药量";
			this.clhPlanQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.clhPlanQty.Width = 87;
			// 
			// clhPlanPercent
			// 
			this.clhPlanPercent.Text = "领药比例";
			this.clhPlanPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.clhPlanPercent.Width = 101;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.ctlDataGridMed);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.m_txtmedName);
			this.groupBox1.Controls.Add(this.m_txtUnit);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.m_numPlanPercent);
			this.groupBox1.Controls.Add(this.m_txtPlanQty);
			this.groupBox1.Controls.Add(this.m_txtHight);
			this.groupBox1.Controls.Add(this.m_txtLow);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.m_txtMedID);
			this.groupBox1.Location = new System.Drawing.Point(0, 40);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(264, 320);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			// 
			// ctlDataGridMed
			// 
			this.ctlDataGridMed.AllowAddNew = true;
			this.ctlDataGridMed.AllowDelete = true;
			this.ctlDataGridMed.AutoAppendRow = true;
			this.ctlDataGridMed.AutoScroll = true;
			this.ctlDataGridMed.BackgroundColor = System.Drawing.SystemColors.Window;
			this.ctlDataGridMed.CaptionText = "";
			this.ctlDataGridMed.CaptionVisible = false;
			this.ctlDataGridMed.ColumnHeadersVisible = true;
			clsColumnInfo1.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo1.BackColor = System.Drawing.Color.White;
			clsColumnInfo1.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo1.ColumnIndex = 0;
			clsColumnInfo1.ColumnName = "MEDICINENAME_VCHR";
			clsColumnInfo1.ColumnWidth = 110;
			clsColumnInfo1.Enabled = false;
			clsColumnInfo1.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo1.HeadText = "药品名称";
			clsColumnInfo1.ReadOnly = true;
			clsColumnInfo1.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo2.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo2.BackColor = System.Drawing.Color.White;
			clsColumnInfo2.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo2.ColumnIndex = 1;
			clsColumnInfo2.ColumnName = "OPUNIT_CHR";
			clsColumnInfo2.ColumnWidth = 40;
			clsColumnInfo2.Enabled = false;
			clsColumnInfo2.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo2.HeadText = "单位";
			clsColumnInfo2.ReadOnly = true;
			clsColumnInfo2.TextFont = new System.Drawing.Font("宋体", 10F);
			this.ctlDataGridMed.Columns.Add(clsColumnInfo1);
			this.ctlDataGridMed.Columns.Add(clsColumnInfo2);
			this.ctlDataGridMed.FullRowSelect = true;
			this.ctlDataGridMed.Location = new System.Drawing.Point(80, -216);
			this.ctlDataGridMed.MultiSelect = false;
			this.ctlDataGridMed.Name = "ctlDataGridMed";
			this.ctlDataGridMed.ReadOnly = false;
			this.ctlDataGridMed.RowHeadersVisible = false;
			this.ctlDataGridMed.RowHeaderWidth = 35;
			this.ctlDataGridMed.SelectedRowBackColor = System.Drawing.Color.Purple;
			this.ctlDataGridMed.SelectedRowForeColor = System.Drawing.Color.White;
			this.ctlDataGridMed.Size = new System.Drawing.Size(176, 224);
			this.ctlDataGridMed.TabIndex = 5;
			this.ctlDataGridMed.Visible = false;
			this.ctlDataGridMed.m_evtDoubleClickCell += new com.digitalwave.controls.datagrid.clsDGTextMouseClickEventHandler(this.ctlDataGridMed_m_evtDoubleClickCell);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(40, 64);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(34, 19);
			this.label9.TabIndex = 15;
			this.label9.Text = "药品";
			// 
			// m_txtmedName
			// 
			this.m_txtmedName.EnableAutoValidation = false;
			this.m_txtmedName.EnableEnterKeyValidate = true;
			this.m_txtmedName.EnableEscapeKeyUndo = true;
			this.m_txtmedName.EnableLastValidValue = true;
			this.m_txtmedName.ErrorProvider = null;
			this.m_txtmedName.ErrorProviderMessage = "Invalid value";
			this.m_txtmedName.ForceFormatText = true;
			this.m_txtmedName.Location = new System.Drawing.Point(80, 64);
			this.m_txtmedName.Name = "m_txtmedName";
			this.m_txtmedName.Size = new System.Drawing.Size(121, 23);
			this.m_txtmedName.TabIndex = 14;
			this.m_txtmedName.Text = "";
			// 
			// m_txtUnit
			// 
			this.m_txtUnit.Enabled = false;
			this.m_txtUnit.Location = new System.Drawing.Point(80, 108);
			this.m_txtUnit.Name = "m_txtUnit";
			this.m_txtUnit.Size = new System.Drawing.Size(121, 23);
			this.m_txtUnit.TabIndex = 13;
			this.m_txtUnit.Text = "";
			this.m_txtUnit.TextChanged += new System.EventHandler(this.txtUnit_TextChanged);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label8.Location = new System.Drawing.Point(184, 288);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(13, 19);
			this.label8.TabIndex = 12;
			this.label8.Text = "%";
			// 
			// m_numPlanPercent
			// 
			this.m_numPlanPercent.Location = new System.Drawing.Point(80, 280);
			this.m_numPlanPercent.Name = "m_numPlanPercent";
			this.m_numPlanPercent.Size = new System.Drawing.Size(96, 23);
			this.m_numPlanPercent.TabIndex = 11;
			this.m_numPlanPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_numPlanPercent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_numPlanPercent_KeyDown);
			// 
			// m_txtPlanQty
			// 
			this.m_txtPlanQty.EnableAutoValidation = false;
			this.m_txtPlanQty.EnableEnterKeyValidate = true;
			this.m_txtPlanQty.EnableEscapeKeyUndo = true;
			this.m_txtPlanQty.EnableLastValidValue = true;
			this.m_txtPlanQty.ErrorProvider = null;
			this.m_txtPlanQty.ErrorProviderMessage = "Invalid value";
			this.m_txtPlanQty.ForceFormatText = true;
			this.m_txtPlanQty.Location = new System.Drawing.Point(80, 240);
			this.m_txtPlanQty.Name = "m_txtPlanQty";
			this.m_txtPlanQty.NumericCharStyle = ((SourceLibrary.Windows.Forms.NumericCharStyle)((SourceLibrary.Windows.Forms.NumericCharStyle.DecimalSeparator | SourceLibrary.Windows.Forms.NumericCharStyle.NegativeSymbol)));
			this.m_txtPlanQty.Size = new System.Drawing.Size(121, 23);
			this.m_txtPlanQty.TabIndex = 10;
			this.m_txtPlanQty.Text = "";
			this.m_txtPlanQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_txtPlanQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtPlanQty_KeyDown);
			// 
			// m_txtHight
			// 
			this.m_txtHight.EnableAutoValidation = false;
			this.m_txtHight.EnableEnterKeyValidate = true;
			this.m_txtHight.EnableEscapeKeyUndo = true;
			this.m_txtHight.EnableLastValidValue = true;
			this.m_txtHight.ErrorProvider = null;
			this.m_txtHight.ErrorProviderMessage = "Invalid value";
			this.m_txtHight.ForceFormatText = true;
			this.m_txtHight.Location = new System.Drawing.Point(80, 196);
			this.m_txtHight.Name = "m_txtHight";
			this.m_txtHight.NumericCharStyle = ((SourceLibrary.Windows.Forms.NumericCharStyle)((SourceLibrary.Windows.Forms.NumericCharStyle.DecimalSeparator | SourceLibrary.Windows.Forms.NumericCharStyle.NegativeSymbol)));
			this.m_txtHight.Size = new System.Drawing.Size(121, 23);
			this.m_txtHight.TabIndex = 9;
			this.m_txtHight.Text = "";
			this.m_txtHight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_txtHight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtHight_KeyDown);
			// 
			// m_txtLow
			// 
			this.m_txtLow.EnableAutoValidation = false;
			this.m_txtLow.EnableEnterKeyValidate = true;
			this.m_txtLow.EnableEscapeKeyUndo = true;
			this.m_txtLow.EnableLastValidValue = true;
			this.m_txtLow.ErrorProvider = null;
			this.m_txtLow.ErrorProviderMessage = "Invalid value";
			this.m_txtLow.ForceFormatText = true;
			this.m_txtLow.Location = new System.Drawing.Point(80, 152);
			this.m_txtLow.Name = "m_txtLow";
			this.m_txtLow.NumericCharStyle = ((SourceLibrary.Windows.Forms.NumericCharStyle)((SourceLibrary.Windows.Forms.NumericCharStyle.DecimalSeparator | SourceLibrary.Windows.Forms.NumericCharStyle.NegativeSymbol)));
			this.m_txtLow.Size = new System.Drawing.Size(121, 23);
			this.m_txtLow.TabIndex = 8;
			this.m_txtLow.Text = "";
			this.m_txtLow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_txtLow.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtLow_KeyDown);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(8, 288);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(63, 19);
			this.label7.TabIndex = 7;
			this.label7.Text = "领药比例";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(23, 240);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(48, 19);
			this.label6.TabIndex = 6;
			this.label6.Text = "领药量";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(37, 200);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(34, 19);
			this.label5.TabIndex = 5;
			this.label5.Text = "上限";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(37, 160);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(34, 19);
			this.label4.TabIndex = 4;
			this.label4.Text = "下限";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(37, 112);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(34, 19);
			this.label3.TabIndex = 2;
			this.label3.Text = "单位";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 19);
			this.label2.TabIndex = 1;
			this.label2.Text = "查找药品";
			// 
			// m_txtMedID
			// 
			this.m_txtMedID.EnableAutoValidation = false;
			this.m_txtMedID.EnableEnterKeyValidate = true;
			this.m_txtMedID.EnableEscapeKeyUndo = true;
			this.m_txtMedID.EnableLastValidValue = true;
			this.m_txtMedID.ErrorProvider = null;
			this.m_txtMedID.ErrorProviderMessage = "Invalid value";
			this.m_txtMedID.ForceFormatText = true;
			this.m_txtMedID.Location = new System.Drawing.Point(80, 20);
			this.m_txtMedID.Name = "m_txtMedID";
			this.m_txtMedID.Size = new System.Drawing.Size(121, 23);
			this.m_txtMedID.TabIndex = 0;
			this.m_txtMedID.Text = "";
			this.m_txtMedID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtMedID_KeyDown);
			this.m_txtMedID.Leave += new System.EventHandler(this.m_txtMedID_Leave);
			this.m_txtMedID.TextChanged += new System.EventHandler(this.m_txtMedID_TextChanged);
			this.m_txtMedID.Enter += new System.EventHandler(this.m_txtMedID_Enter);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox2.Controls.Add(this.m_cmdClose);
			this.groupBox2.Controls.Add(this.m_cmdRefersh);
			this.groupBox2.Controls.Add(this.m_cmdDelete);
			this.groupBox2.Controls.Add(this.m_cmdNew);
			this.groupBox2.Controls.Add(this.m_cmdSave);
			this.groupBox2.Location = new System.Drawing.Point(0, 368);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(264, 264);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
			// 
			// m_cmdClose
			// 
			this.m_cmdClose.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdClose.DefaultScheme = true;
			this.m_cmdClose.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdClose.Hint = "";
			this.m_cmdClose.Location = new System.Drawing.Point(40, 216);
			this.m_cmdClose.Name = "m_cmdClose";
			this.m_cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdClose.Size = new System.Drawing.Size(168, 32);
			this.m_cmdClose.TabIndex = 4;
			this.m_cmdClose.Text = "退出(&E)";
			this.m_cmdClose.Click += new System.EventHandler(this.m_cmdClose_Click);
			// 
			// m_cmdRefersh
			// 
			this.m_cmdRefersh.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdRefersh.DefaultScheme = true;
			this.m_cmdRefersh.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdRefersh.Hint = "";
			this.m_cmdRefersh.Location = new System.Drawing.Point(40, 168);
			this.m_cmdRefersh.Name = "m_cmdRefersh";
			this.m_cmdRefersh.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdRefersh.Size = new System.Drawing.Size(168, 32);
			this.m_cmdRefersh.TabIndex = 3;
			this.m_cmdRefersh.Text = "刷新(&R)";
			this.m_cmdRefersh.Click += new System.EventHandler(this.m_cmdRefersh_Click);
			// 
			// m_cmdDelete
			// 
			this.m_cmdDelete.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdDelete.DefaultScheme = true;
			this.m_cmdDelete.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdDelete.Hint = "";
			this.m_cmdDelete.Location = new System.Drawing.Point(40, 120);
			this.m_cmdDelete.Name = "m_cmdDelete";
			this.m_cmdDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdDelete.Size = new System.Drawing.Size(168, 32);
			this.m_cmdDelete.TabIndex = 2;
			this.m_cmdDelete.Text = "删除(&D)";
			this.m_cmdDelete.Click += new System.EventHandler(this.m_cmdDelete_Click);
			// 
			// m_cmdNew
			// 
			this.m_cmdNew.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdNew.DefaultScheme = true;
			this.m_cmdNew.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdNew.Hint = "";
			this.m_cmdNew.Location = new System.Drawing.Point(40, 72);
			this.m_cmdNew.Name = "m_cmdNew";
			this.m_cmdNew.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdNew.Size = new System.Drawing.Size(168, 32);
			this.m_cmdNew.TabIndex = 1;
			this.m_cmdNew.Text = "新增(&A)";
			this.m_cmdNew.Click += new System.EventHandler(this.m_cmdNew_Click);
			// 
			// m_cmdSave
			// 
			this.m_cmdSave.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdSave.DefaultScheme = true;
			this.m_cmdSave.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdSave.Hint = "";
			this.m_cmdSave.Location = new System.Drawing.Point(40, 24);
			this.m_cmdSave.Name = "m_cmdSave";
			this.m_cmdSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdSave.Size = new System.Drawing.Size(168, 32);
			this.m_cmdSave.TabIndex = 0;
			this.m_cmdSave.Text = "保存(&S)";
			this.m_cmdSave.Click += new System.EventHandler(this.m_cmdSave_Click);
			// 
			// frmMedStoreLimit
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(936, 637);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.m_lsvDetail);
			this.Controls.Add(this.m_cboMedStore);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.Name = "frmMedStoreLimit";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "药房限额管理";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmMedStoreLimit_Load);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ctlDataGridMed)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.m_numPlanPercent)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 
		/// </summary>
		public override void CreateController()
		{
			this.objController = new clsControlMedStoreLimit();
			this.objController.Set_GUI_Apperance(this);
		}

		private void frmMedStoreLimit_Load(object sender, System.EventArgs e)
		{
			base.m_mthSetFormControlCanBeNull(this);
			((clsControlMedStoreLimit)this.objController).m_mthInit();
			this.m_mthSetEnter2Tab(new System.Windows.Forms.Control[] {});
		}

		private void m_cboMedStore_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			((clsControlMedStoreLimit)this.objController).m_mthChangeMedStore();
		}

		private void m_txtMedID_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Up)
			{
				if(ctlDataGridMed.RowCount>0&&ctlDataGridMed.CurrentCell.RowNumber!=0)
				{
					ctlDataGridMed.CurrentCell=new DataGridCell(ctlDataGridMed.CurrentCell.RowNumber-1,0);
				}
			}
			if(e.KeyCode==Keys.Down)
			{
				if(ctlDataGridMed.RowCount>0&&ctlDataGridMed.CurrentCell.RowNumber<ctlDataGridMed.RowCount)
				{
					ctlDataGridMed.CurrentCell=new DataGridCell(ctlDataGridMed.CurrentCell.RowNumber+1,0);
				}
			}
			Application.DoEvents();
			m_txtMedID.Focus();

			if(e.KeyCode==Keys.Enter)
			{
				((clsControlMedStoreLimit)this.objController).m_lngSeleMed();
				this.m_txtLow.Focus();
			}
		}

		private void m_txtMedID_Leave(object sender, System.EventArgs e)
		{
//			if(this.ActiveControl.Name != "m_lsvPopMed")
//			{
//				this.m_lsvPopMed.Visible = false;
//				return;
//			}
		}

		private void m_lsvPopMed_DoubleClick(object sender, System.EventArgs e)
		{
//			((clsControlMedStoreLimit)this.objController).m_mthPopMedListSel();
		}

		private void m_lsvPopMed_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
			{
//				((clsControlMedStoreLimit)this.objController).m_mthPopMedListSel();
			}
		}

		private void m_lsvPopMed_Leave(object sender, System.EventArgs e)
		{
//			if(this.ActiveControl.Name != "m_txtMedID")
//			{
//				this.m_lsvPopMed.Visible = false;
//				return;
//			}
		}

		private void m_cmdSave_Click(object sender, System.EventArgs e)
		{
			((clsControlMedStoreLimit)this.objController).m_mthSave();
		}

		private void m_cmdNew_Click(object sender, System.EventArgs e)
		{
			((clsControlMedStoreLimit)this.objController).m_mthSetViewInfo(null);
		}

		private void m_cmdDelete_Click(object sender, System.EventArgs e)
		{
			((clsControlMedStoreLimit)this.objController).m_mthDoDelete();
		}

		private void m_cmdRefersh_Click(object sender, System.EventArgs e)
		{
			((clsControlMedStoreLimit)this.objController).m_mthGetDetailList();
		}

		private void m_cmdClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void m_lsvDetail_DoubleClick(object sender, System.EventArgs e)
		{
			((clsControlMedStoreLimit)this.objController).m_mthDetailSel();
		}

		private void m_txtMedID_TextChanged(object sender, System.EventArgs e)
		{
			((clsControlMedStoreLimit)this.objController).m_lngFind();
		}

		private void txtUnit_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void m_txtMedID_Enter(object sender, System.EventArgs e)
		{
			if(ctlDataGridMed.Visible==false)
			((clsControlMedStoreLimit)this.objController).m_mthEnablePopMed();
		}

		private void m_txtLow_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.m_mthSetKeyTab(e);
		}

		private void m_txtHight_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.m_mthSetKeyTab(e);
		}

		private void m_txtPlanQty_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.m_mthSetKeyTab(e);
		}

		private void m_numPlanPercent_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				m_cmdSave.Focus();
		}

		private void m_lsvDetail_Click(object sender, System.EventArgs e)
		{
		
		}

		private void m_lsvDetail_Enter(object sender, System.EventArgs e)
		{
			if(this.ctlDataGridMed.Visible==true)
				this.ctlDataGridMed.Visible=false;
		}

		private void ctlDataGridMed_m_evtDoubleClickCell(object sender, com.digitalwave.controls.datagrid.clsDGTextMouseClickEventArgs e)
		{
			((clsControlMedStoreLimit)this.objController).m_lngSeleMed();
			this.m_txtLow.Focus();
		}

		private void groupBox2_Enter(object sender, System.EventArgs e)
		{
			if(this.ctlDataGridMed.Visible==true)
				this.ctlDataGridMed.Visible=false;
		}

	}
}
