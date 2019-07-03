using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmPayTypeMana 的摘要说明。
	/// </summary>
	public class frmPayTypeMana : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		internal System.Windows.Forms.Panel panel1;
		internal System.Windows.Forms.GroupBox groupBox2;
		internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric m_txtTQY;
		internal System.Windows.Forms.TextBox m_txtFindTtem;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		internal System.Windows.Forms.TextBox m_txtUnprir;
		private System.Windows.Forms.Label label9;
		internal System.Windows.Forms.TextBox m_txtunit;
		private System.Windows.Forms.Label label5;
		internal System.Windows.Forms.TextBox m_txtType;
		private System.Windows.Forms.Label label6;
		internal System.Windows.Forms.TextBox m_txtSpace;
		private System.Windows.Forms.Label label7;
		internal System.Windows.Forms.TextBox m_txtItemName;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.GroupBox groupBox3;
		internal PinkieControls.ButtonXP btnDele;
		internal PinkieControls.ButtonXP buttonXP2;
		internal PinkieControls.ButtonXP m_btnSave;
		internal com.digitalwave.controls.datagrid.ctlDataGrid m_DgPayType;
		internal com.digitalwave.controls.datagrid.ctlDataGrid m_DgItemDe;
		internal com.digitalwave.controls.datagrid.ctlDataGrid m_DgItem;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		internal PinkieControls.ButtonXP btnClear;
		internal System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		internal System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.Label label3;
		internal System.Windows.Forms.ComboBox comboBox3;
		private System.Windows.Forms.Panel panel2;
		internal System.Windows.Forms.Panel pnldg;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmPayTypeMana()
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
			com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo9 = new com.digitalwave.controls.datagrid.clsColumnInfo();
			com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo10 = new com.digitalwave.controls.datagrid.clsColumnInfo();
			com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo11 = new com.digitalwave.controls.datagrid.clsColumnInfo();
			com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo12 = new com.digitalwave.controls.datagrid.clsColumnInfo();
			com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo13 = new com.digitalwave.controls.datagrid.clsColumnInfo();
			com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo14 = new com.digitalwave.controls.datagrid.clsColumnInfo();
			com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo15 = new com.digitalwave.controls.datagrid.clsColumnInfo();
			com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo16 = new com.digitalwave.controls.datagrid.clsColumnInfo();
			com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo17 = new com.digitalwave.controls.datagrid.clsColumnInfo();
			com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo18 = new com.digitalwave.controls.datagrid.clsColumnInfo();
			com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo19 = new com.digitalwave.controls.datagrid.clsColumnInfo();
			com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo20 = new com.digitalwave.controls.datagrid.clsColumnInfo();
			com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo21 = new com.digitalwave.controls.datagrid.clsColumnInfo();
			com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo22 = new com.digitalwave.controls.datagrid.clsColumnInfo();
			com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo23 = new com.digitalwave.controls.datagrid.clsColumnInfo();
			com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo24 = new com.digitalwave.controls.datagrid.clsColumnInfo();
			this.m_DgPayType = new com.digitalwave.controls.datagrid.ctlDataGrid();
			this.panel1 = new System.Windows.Forms.Panel();
			this.m_DgItemDe = new com.digitalwave.controls.datagrid.ctlDataGrid();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.comboBox3 = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.m_txtTQY = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
			this.m_txtFindTtem = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.m_txtUnprir = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.m_txtunit = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.m_txtType = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.m_txtSpace = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.m_txtItemName = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.btnClear = new PinkieControls.ButtonXP();
			this.btnDele = new PinkieControls.ButtonXP();
			this.buttonXP2 = new PinkieControls.ButtonXP();
			this.m_btnSave = new PinkieControls.ButtonXP();
			this.m_DgItem = new com.digitalwave.controls.datagrid.ctlDataGrid();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider();
			this.panel2 = new System.Windows.Forms.Panel();
			this.pnldg = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.m_DgPayType)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_DgItemDe)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_DgItem)).BeginInit();
			this.panel2.SuspendLayout();
			this.pnldg.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_DgPayType
			// 
			this.m_DgPayType.AllowAddNew = false;
			this.m_DgPayType.AllowDelete = false;
			this.m_DgPayType.AutoAppendRow = false;
			this.m_DgPayType.AutoScroll = true;
			this.m_DgPayType.BackgroundColor = System.Drawing.SystemColors.Window;
			this.m_DgPayType.CaptionText = "";
			this.m_DgPayType.CaptionVisible = false;
			this.m_DgPayType.ColumnHeadersVisible = true;
			clsColumnInfo1.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo1.BackColor = System.Drawing.Color.White;
			clsColumnInfo1.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo1.ColumnIndex = 0;
			clsColumnInfo1.ColumnName = "PAYTYPENO_VCHR";
			clsColumnInfo1.ColumnWidth = 100;
			clsColumnInfo1.Enabled = false;
			clsColumnInfo1.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo1.HeadText = "助记码";
			clsColumnInfo1.ReadOnly = true;
			clsColumnInfo1.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo2.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo2.BackColor = System.Drawing.Color.White;
			clsColumnInfo2.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo2.ColumnIndex = 1;
			clsColumnInfo2.ColumnName = "PAYTYPENAME_VCHR";
			clsColumnInfo2.ColumnWidth = 100;
			clsColumnInfo2.Enabled = false;
			clsColumnInfo2.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo2.HeadText = "类型名称";
			clsColumnInfo2.ReadOnly = true;
			clsColumnInfo2.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo3.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo3.BackColor = System.Drawing.Color.White;
			clsColumnInfo3.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo3.ColumnIndex = 2;
			clsColumnInfo3.ColumnName = "strISUSING";
			clsColumnInfo3.ColumnWidth = 50;
			clsColumnInfo3.Enabled = false;
			clsColumnInfo3.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo3.HeadText = "状态";
			clsColumnInfo3.ReadOnly = true;
			clsColumnInfo3.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo4.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo4.BackColor = System.Drawing.Color.White;
			clsColumnInfo4.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo4.ColumnIndex = 3;
			clsColumnInfo4.ColumnName = "MEMO_VCHR";
			clsColumnInfo4.ColumnWidth = 120;
			clsColumnInfo4.Enabled = false;
			clsColumnInfo4.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo4.HeadText = "备注";
			clsColumnInfo4.ReadOnly = true;
			clsColumnInfo4.TextFont = new System.Drawing.Font("宋体", 10F);
			this.m_DgPayType.Columns.Add(clsColumnInfo1);
			this.m_DgPayType.Columns.Add(clsColumnInfo2);
			this.m_DgPayType.Columns.Add(clsColumnInfo3);
			this.m_DgPayType.Columns.Add(clsColumnInfo4);
			this.m_DgPayType.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_DgPayType.FullRowSelect = true;
			this.m_DgPayType.Location = new System.Drawing.Point(0, 0);
			this.m_DgPayType.MultiSelect = false;
			this.m_DgPayType.Name = "m_DgPayType";
			this.m_DgPayType.ReadOnly = false;
			this.m_DgPayType.RowHeadersVisible = false;
			this.m_DgPayType.RowHeaderWidth = 35;
			this.m_DgPayType.SelectedRowBackColor = System.Drawing.SystemColors.Desktop;
			this.m_DgPayType.SelectedRowForeColor = System.Drawing.Color.White;
			this.m_DgPayType.Size = new System.Drawing.Size(374, 531);
			this.m_DgPayType.TabIndex = 0;
			this.m_DgPayType.m_evtCurrentCellChanged += new System.EventHandler(this.m_DgPayType_m_evtCurrentCellChanged);
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.m_DgItemDe);
			this.panel1.Location = new System.Drawing.Point(384, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(648, 344);
			this.panel1.TabIndex = 80;
			// 
			// m_DgItemDe
			// 
			this.m_DgItemDe.AllowAddNew = false;
			this.m_DgItemDe.AllowDelete = false;
			this.m_DgItemDe.AutoAppendRow = false;
			this.m_DgItemDe.AutoScroll = true;
			this.m_DgItemDe.BackgroundColor = System.Drawing.SystemColors.Window;
			this.m_DgItemDe.CaptionText = "";
			this.m_DgItemDe.CaptionVisible = false;
			this.m_DgItemDe.ColumnHeadersVisible = true;
			clsColumnInfo5.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo5.BackColor = System.Drawing.Color.White;
			clsColumnInfo5.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo5.ColumnIndex = 0;
			clsColumnInfo5.ColumnName = "ITEMCODE_VCHR";
			clsColumnInfo5.ColumnWidth = 75;
			clsColumnInfo5.Enabled = false;
			clsColumnInfo5.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo5.HeadText = "项目编码";
			clsColumnInfo5.ReadOnly = true;
			clsColumnInfo5.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo6.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo6.BackColor = System.Drawing.Color.White;
			clsColumnInfo6.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo6.ColumnIndex = 1;
			clsColumnInfo6.ColumnName = "ITEMNAME_VCHR";
			clsColumnInfo6.ColumnWidth = 100;
			clsColumnInfo6.Enabled = false;
			clsColumnInfo6.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo6.HeadText = "项目名称";
			clsColumnInfo6.ReadOnly = true;
			clsColumnInfo6.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo7.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo7.BackColor = System.Drawing.Color.White;
			clsColumnInfo7.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo7.ColumnIndex = 2;
			clsColumnInfo7.ColumnName = "ITEMSPEC_VCHR";
			clsColumnInfo7.ColumnWidth = 120;
			clsColumnInfo7.Enabled = false;
			clsColumnInfo7.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo7.HeadText = "项目规格";
			clsColumnInfo7.ReadOnly = true;
			clsColumnInfo7.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo8.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo8.BackColor = System.Drawing.Color.White;
			clsColumnInfo8.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo8.ColumnIndex = 3;
			clsColumnInfo8.ColumnName = "ItemType";
			clsColumnInfo8.ColumnWidth = 50;
			clsColumnInfo8.Enabled = false;
			clsColumnInfo8.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo8.HeadText = "类型";
			clsColumnInfo8.ReadOnly = true;
			clsColumnInfo8.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo9.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo9.BackColor = System.Drawing.Color.White;
			clsColumnInfo9.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo9.ColumnIndex = 4;
			clsColumnInfo9.ColumnName = "ITEMOPUNIT_CHR";
			clsColumnInfo9.ColumnWidth = 40;
			clsColumnInfo9.Enabled = false;
			clsColumnInfo9.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo9.HeadText = "单位";
			clsColumnInfo9.ReadOnly = true;
			clsColumnInfo9.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo10.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo10.BackColor = System.Drawing.Color.White;
			clsColumnInfo10.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo10.ColumnIndex = 5;
			clsColumnInfo10.ColumnName = "ITEMPRICE_MNY";
			clsColumnInfo10.ColumnWidth = 40;
			clsColumnInfo10.Enabled = false;
			clsColumnInfo10.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo10.HeadText = "价格";
			clsColumnInfo10.ReadOnly = true;
			clsColumnInfo10.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo11.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo11.BackColor = System.Drawing.Color.White;
			clsColumnInfo11.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo11.ColumnIndex = 6;
			clsColumnInfo11.ColumnName = "QTY_DEC";
			clsColumnInfo11.ColumnWidth = 50;
			clsColumnInfo11.Enabled = false;
			clsColumnInfo11.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo11.HeadText = "数量";
			clsColumnInfo11.ReadOnly = true;
			clsColumnInfo11.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo12.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo12.BackColor = System.Drawing.Color.White;
			clsColumnInfo12.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo12.ColumnIndex = 7;
			clsColumnInfo12.ColumnName = "ITEMID_CHR";
			clsColumnInfo12.ColumnWidth = 0;
			clsColumnInfo12.Enabled = false;
			clsColumnInfo12.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo12.HeadText = "项目ID";
			clsColumnInfo12.ReadOnly = true;
			clsColumnInfo12.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo13.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo13.BackColor = System.Drawing.Color.White;
			clsColumnInfo13.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo13.ColumnIndex = 8;
			clsColumnInfo13.ColumnName = "strISRICH";
			clsColumnInfo13.ColumnWidth = 70;
			clsColumnInfo13.Enabled = false;
			clsColumnInfo13.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo13.HeadText = "贵重药品";
			clsColumnInfo13.ReadOnly = true;
			clsColumnInfo13.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo14.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo14.BackColor = System.Drawing.Color.White;
			clsColumnInfo14.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo14.ColumnIndex = 9;
			clsColumnInfo14.ColumnName = "REGISTER";
			clsColumnInfo14.ColumnWidth = 75;
			clsColumnInfo14.Enabled = false;
			clsColumnInfo14.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo14.HeadText = "是否挂号";
			clsColumnInfo14.ReadOnly = true;
			clsColumnInfo14.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo15.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo15.BackColor = System.Drawing.Color.White;
			clsColumnInfo15.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo15.ColumnIndex = 10;
			clsColumnInfo15.ColumnName = "RECIPEFLAG";
			clsColumnInfo15.ColumnWidth = 75;
			clsColumnInfo15.Enabled = false;
			clsColumnInfo15.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo15.HeadText = "处方类型";
			clsColumnInfo15.ReadOnly = true;
			clsColumnInfo15.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo16.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo16.BackColor = System.Drawing.Color.White;
			clsColumnInfo16.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo16.ColumnIndex = 11;
			clsColumnInfo16.ColumnName = "EXPERT";
			clsColumnInfo16.ColumnWidth = 75;
			clsColumnInfo16.Enabled = false;
			clsColumnInfo16.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo16.HeadText = "是否专家";
			clsColumnInfo16.ReadOnly = true;
			clsColumnInfo16.TextFont = new System.Drawing.Font("宋体", 10F);
			this.m_DgItemDe.Columns.Add(clsColumnInfo5);
			this.m_DgItemDe.Columns.Add(clsColumnInfo6);
			this.m_DgItemDe.Columns.Add(clsColumnInfo7);
			this.m_DgItemDe.Columns.Add(clsColumnInfo8);
			this.m_DgItemDe.Columns.Add(clsColumnInfo9);
			this.m_DgItemDe.Columns.Add(clsColumnInfo10);
			this.m_DgItemDe.Columns.Add(clsColumnInfo11);
			this.m_DgItemDe.Columns.Add(clsColumnInfo12);
			this.m_DgItemDe.Columns.Add(clsColumnInfo13);
			this.m_DgItemDe.Columns.Add(clsColumnInfo14);
			this.m_DgItemDe.Columns.Add(clsColumnInfo15);
			this.m_DgItemDe.Columns.Add(clsColumnInfo16);
			this.m_DgItemDe.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_DgItemDe.FullRowSelect = true;
			this.m_DgItemDe.Location = new System.Drawing.Point(0, 0);
			this.m_DgItemDe.MultiSelect = false;
			this.m_DgItemDe.Name = "m_DgItemDe";
			this.m_DgItemDe.ReadOnly = false;
			this.m_DgItemDe.RowHeadersVisible = false;
			this.m_DgItemDe.RowHeaderWidth = 35;
			this.m_DgItemDe.SelectedRowBackColor = System.Drawing.Color.Silver;
			this.m_DgItemDe.SelectedRowForeColor = System.Drawing.Color.White;
			this.m_DgItemDe.Size = new System.Drawing.Size(644, 340);
			this.m_DgItemDe.TabIndex = 0;
			this.m_DgItemDe.m_evtDoubleClickCell += new com.digitalwave.controls.datagrid.clsDGTextMouseClickEventHandler(this.m_DgItemDe_m_evtDoubleClickCell);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.comboBox3);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.comboBox2);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.comboBox1);
			this.groupBox2.Controls.Add(this.m_txtTQY);
			this.groupBox2.Controls.Add(this.m_txtFindTtem);
			this.groupBox2.Controls.Add(this.label13);
			this.groupBox2.Controls.Add(this.label12);
			this.groupBox2.Controls.Add(this.m_txtUnprir);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.m_txtunit);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.m_txtType);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.m_txtSpace);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.m_txtItemName);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Location = new System.Drawing.Point(384, 344);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(640, 128);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(440, 96);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 23);
			this.label3.TabIndex = 34;
			this.label3.Text = "是否专家";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// comboBox3
			// 
			this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox3.Items.AddRange(new object[] {
														   "全部",
														   "专家",
														   "普通"});
			this.comboBox3.Location = new System.Drawing.Point(520, 96);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(112, 22);
			this.comboBox3.TabIndex = 33;
			this.comboBox3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox3_KeyDown);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(224, 96);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 23);
			this.label2.TabIndex = 32;
			this.label2.Text = "处方类型";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// comboBox2
			// 
			this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox2.Items.AddRange(new object[] {
														   "全部",
														   "正方",
														   "副方"});
			this.comboBox2.Location = new System.Drawing.Point(312, 96);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(112, 22);
			this.comboBox2.TabIndex = 31;
			this.comboBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox2_KeyDown);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 96);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 23);
			this.label1.TabIndex = 30;
			this.label1.Text = "是否挂号";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.Items.AddRange(new object[] {
														   "全部",
														   "已挂号",
														   "未挂号"});
			this.comboBox1.Location = new System.Drawing.Point(80, 96);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(128, 22);
			this.comboBox1.TabIndex = 29;
			this.comboBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox1_KeyDown);
			// 
			// m_txtTQY
			// 
			this.m_txtTQY.EnableAutoValidation = false;
			this.m_txtTQY.EnableEnterKeyValidate = true;
			this.m_txtTQY.EnableEscapeKeyUndo = true;
			this.m_txtTQY.EnableLastValidValue = true;
			this.m_txtTQY.ErrorProvider = null;
			this.m_txtTQY.ErrorProviderMessage = "Invalid value";
			this.m_txtTQY.ForceFormatText = true;
			this.m_txtTQY.Location = new System.Drawing.Point(520, 64);
			this.m_txtTQY.Name = "m_txtTQY";
			this.m_txtTQY.NumericCharStyle = ((SourceLibrary.Windows.Forms.NumericCharStyle)((SourceLibrary.Windows.Forms.NumericCharStyle.DecimalSeparator | SourceLibrary.Windows.Forms.NumericCharStyle.NegativeSymbol)));
			this.m_txtTQY.Size = new System.Drawing.Size(112, 23);
			this.m_txtTQY.TabIndex = 28;
			this.m_txtTQY.Text = "";
			this.m_txtTQY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_txtTQY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtTQY_KeyDown);
			this.m_txtTQY.TextChanged += new System.EventHandler(this.m_txtTQY_TextChanged);
			// 
			// m_txtFindTtem
			// 
			this.m_txtFindTtem.Location = new System.Drawing.Point(80, 21);
			this.m_txtFindTtem.Name = "m_txtFindTtem";
			this.m_txtFindTtem.Size = new System.Drawing.Size(88, 23);
			this.m_txtFindTtem.TabIndex = 0;
			this.m_txtFindTtem.Text = "";
			this.m_txtFindTtem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtFindTtem_KeyDown);
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(8, 21);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(64, 23);
			this.label13.TabIndex = 26;
			this.label13.Text = "查找项目";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(480, 64);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(40, 23);
			this.label12.TabIndex = 18;
			this.label12.Text = "数量";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label12.Click += new System.EventHandler(this.label12_Click);
			// 
			// m_txtUnprir
			// 
			this.m_txtUnprir.Location = new System.Drawing.Point(400, 64);
			this.m_txtUnprir.Name = "m_txtUnprir";
			this.m_txtUnprir.ReadOnly = true;
			this.m_txtUnprir.Size = new System.Drawing.Size(72, 23);
			this.m_txtUnprir.TabIndex = 17;
			this.m_txtUnprir.Text = "";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(360, 64);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(40, 23);
			this.label9.TabIndex = 16;
			this.label9.Text = "单价";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_txtunit
			// 
			this.m_txtunit.Location = new System.Drawing.Point(208, 64);
			this.m_txtunit.Name = "m_txtunit";
			this.m_txtunit.ReadOnly = true;
			this.m_txtunit.Size = new System.Drawing.Size(152, 23);
			this.m_txtunit.TabIndex = 15;
			this.m_txtunit.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(168, 64);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(48, 23);
			this.label5.TabIndex = 14;
			this.label5.Text = "单位";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_txtType
			// 
			this.m_txtType.Location = new System.Drawing.Point(80, 64);
			this.m_txtType.Name = "m_txtType";
			this.m_txtType.ReadOnly = true;
			this.m_txtType.Size = new System.Drawing.Size(88, 23);
			this.m_txtType.TabIndex = 13;
			this.m_txtType.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 64);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(72, 23);
			this.label6.TabIndex = 12;
			this.label6.Text = "类    型";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_txtSpace
			// 
			this.m_txtSpace.Location = new System.Drawing.Point(440, 21);
			this.m_txtSpace.Name = "m_txtSpace";
			this.m_txtSpace.ReadOnly = true;
			this.m_txtSpace.Size = new System.Drawing.Size(192, 23);
			this.m_txtSpace.TabIndex = 11;
			this.m_txtSpace.Text = "";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(400, 21);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(40, 23);
			this.label7.TabIndex = 10;
			this.label7.Text = "规格";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_txtItemName
			// 
			this.m_txtItemName.Location = new System.Drawing.Point(208, 21);
			this.m_txtItemName.Name = "m_txtItemName";
			this.m_txtItemName.ReadOnly = true;
			this.m_txtItemName.Size = new System.Drawing.Size(184, 23);
			this.m_txtItemName.TabIndex = 9;
			this.m_txtItemName.Text = "";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(168, 21);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(48, 23);
			this.label8.TabIndex = 8;
			this.label8.Text = "名称";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox3.Controls.Add(this.btnClear);
			this.groupBox3.Controls.Add(this.btnDele);
			this.groupBox3.Controls.Add(this.buttonXP2);
			this.groupBox3.Controls.Add(this.m_btnSave);
			this.groupBox3.Location = new System.Drawing.Point(384, 472);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(640, 56);
			this.groupBox3.TabIndex = 60;
			this.groupBox3.TabStop = false;
			// 
			// btnClear
			// 
			this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnClear.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btnClear.DefaultScheme = true;
			this.btnClear.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btnClear.Hint = "";
			this.btnClear.Location = new System.Drawing.Point(40, 16);
			this.btnClear.Name = "btnClear";
			this.btnClear.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btnClear.Size = new System.Drawing.Size(84, 32);
			this.btnClear.TabIndex = 18;
			this.btnClear.Text = "清空(&C)";
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// btnDele
			// 
			this.btnDele.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnDele.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btnDele.DefaultScheme = true;
			this.btnDele.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btnDele.Hint = "";
			this.btnDele.Location = new System.Drawing.Point(288, 16);
			this.btnDele.Name = "btnDele";
			this.btnDele.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btnDele.Size = new System.Drawing.Size(88, 32);
			this.btnDele.TabIndex = 17;
			this.btnDele.Text = "删除(&D)";
			this.btnDele.Click += new System.EventHandler(this.btnDele_Click);
			// 
			// buttonXP2
			// 
			this.buttonXP2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonXP2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.buttonXP2.DefaultScheme = true;
			this.buttonXP2.DialogResult = System.Windows.Forms.DialogResult.None;
			this.buttonXP2.Hint = "";
			this.buttonXP2.Location = new System.Drawing.Point(424, 16);
			this.buttonXP2.Name = "buttonXP2";
			this.buttonXP2.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.buttonXP2.Size = new System.Drawing.Size(88, 32);
			this.buttonXP2.TabIndex = 15;
			this.buttonXP2.Text = "退出(ESC)";
			this.buttonXP2.Click += new System.EventHandler(this.buttonXP2_Click);
			// 
			// m_btnSave
			// 
			this.m_btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_btnSave.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnSave.DefaultScheme = true;
			this.m_btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnSave.Hint = "";
			this.m_btnSave.Location = new System.Drawing.Point(168, 16);
			this.m_btnSave.Name = "m_btnSave";
			this.m_btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnSave.Size = new System.Drawing.Size(84, 32);
			this.m_btnSave.TabIndex = 14;
			this.m_btnSave.Text = "新增(&A)";
			this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
			// 
			// m_DgItem
			// 
			this.m_DgItem.AllowAddNew = false;
			this.m_DgItem.AllowDelete = false;
			this.m_DgItem.AutoAppendRow = false;
			this.m_DgItem.AutoScroll = true;
			this.m_DgItem.BackgroundColor = System.Drawing.SystemColors.Window;
			this.m_DgItem.CaptionText = "";
			this.m_DgItem.CaptionVisible = false;
			this.m_DgItem.ColumnHeadersVisible = true;
			clsColumnInfo17.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo17.BackColor = System.Drawing.Color.White;
			clsColumnInfo17.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo17.ColumnIndex = 0;
			clsColumnInfo17.ColumnName = "ITEMCODE_VCHR";
			clsColumnInfo17.ColumnWidth = 70;
			clsColumnInfo17.Enabled = false;
			clsColumnInfo17.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo17.HeadText = "项目代码";
			clsColumnInfo17.ReadOnly = true;
			clsColumnInfo17.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo18.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo18.BackColor = System.Drawing.Color.White;
			clsColumnInfo18.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo18.ColumnIndex = 1;
			clsColumnInfo18.ColumnName = "ITEMNAME_VCHR";
			clsColumnInfo18.ColumnWidth = 100;
			clsColumnInfo18.Enabled = false;
			clsColumnInfo18.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo18.HeadText = "项目名称";
			clsColumnInfo18.ReadOnly = true;
			clsColumnInfo18.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo19.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo19.BackColor = System.Drawing.Color.White;
			clsColumnInfo19.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo19.ColumnIndex = 2;
			clsColumnInfo19.ColumnName = "ItemType";
			clsColumnInfo19.ColumnWidth = 40;
			clsColumnInfo19.Enabled = false;
			clsColumnInfo19.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo19.HeadText = "类型";
			clsColumnInfo19.ReadOnly = true;
			clsColumnInfo19.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo20.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo20.BackColor = System.Drawing.Color.White;
			clsColumnInfo20.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo20.ColumnIndex = 3;
			clsColumnInfo20.ColumnName = "ITEMSPEC_VCHR";
			clsColumnInfo20.ColumnWidth = 130;
			clsColumnInfo20.Enabled = false;
			clsColumnInfo20.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo20.HeadText = "规格";
			clsColumnInfo20.ReadOnly = true;
			clsColumnInfo20.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo21.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo21.BackColor = System.Drawing.Color.White;
			clsColumnInfo21.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo21.ColumnIndex = 4;
			clsColumnInfo21.ColumnName = "ITEMOPUNIT";
			clsColumnInfo21.ColumnWidth = 50;
			clsColumnInfo21.Enabled = false;
			clsColumnInfo21.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo21.HeadText = "单位";
			clsColumnInfo21.ReadOnly = true;
			clsColumnInfo21.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo22.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo22.BackColor = System.Drawing.Color.White;
			clsColumnInfo22.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo22.ColumnIndex = 5;
			clsColumnInfo22.ColumnName = "ITEMPRICE_MNY";
			clsColumnInfo22.ColumnWidth = 50;
			clsColumnInfo22.Enabled = false;
			clsColumnInfo22.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo22.HeadText = "单价";
			clsColumnInfo22.ReadOnly = true;
			clsColumnInfo22.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo23.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo23.BackColor = System.Drawing.Color.White;
			clsColumnInfo23.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo23.ColumnIndex = 6;
			clsColumnInfo23.ColumnName = "ITEMPYCODE_CHR";
			clsColumnInfo23.ColumnWidth = 50;
			clsColumnInfo23.Enabled = false;
			clsColumnInfo23.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo23.HeadText = "拼音码";
			clsColumnInfo23.ReadOnly = true;
			clsColumnInfo23.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo24.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo24.BackColor = System.Drawing.Color.White;
			clsColumnInfo24.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo24.ColumnIndex = 7;
			clsColumnInfo24.ColumnName = "ITEMWBCODE_CHR";
			clsColumnInfo24.ColumnWidth = 50;
			clsColumnInfo24.Enabled = false;
			clsColumnInfo24.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo24.HeadText = "五笔码";
			clsColumnInfo24.ReadOnly = true;
			clsColumnInfo24.TextFont = new System.Drawing.Font("宋体", 10F);
			this.m_DgItem.Columns.Add(clsColumnInfo17);
			this.m_DgItem.Columns.Add(clsColumnInfo18);
			this.m_DgItem.Columns.Add(clsColumnInfo19);
			this.m_DgItem.Columns.Add(clsColumnInfo20);
			this.m_DgItem.Columns.Add(clsColumnInfo21);
			this.m_DgItem.Columns.Add(clsColumnInfo22);
			this.m_DgItem.Columns.Add(clsColumnInfo23);
			this.m_DgItem.Columns.Add(clsColumnInfo24);
			this.m_DgItem.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_DgItem.FullRowSelect = true;
			this.m_DgItem.Location = new System.Drawing.Point(0, 0);
			this.m_DgItem.MultiSelect = false;
			this.m_DgItem.Name = "m_DgItem";
			this.m_DgItem.ReadOnly = false;
			this.m_DgItem.RowHeadersVisible = false;
			this.m_DgItem.RowHeaderWidth = 35;
			this.m_DgItem.SelectedRowBackColor = System.Drawing.SystemColors.Desktop;
			this.m_DgItem.SelectedRowForeColor = System.Drawing.Color.White;
			this.m_DgItem.Size = new System.Drawing.Size(550, 214);
			this.m_DgItem.TabIndex = 50;
			this.m_DgItem.m_evtDataGridKeyDown += new System.Windows.Forms.KeyEventHandler(this.m_DgItem_m_evtDataGridKeyDown);
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.m_DgPayType);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(376, 533);
			this.panel2.TabIndex = 81;
			// 
			// pnldg
			// 
			this.pnldg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnldg.Controls.Add(this.m_DgItem);
			this.pnldg.Location = new System.Drawing.Point(408, 64);
			this.pnldg.Name = "pnldg";
			this.pnldg.Size = new System.Drawing.Size(552, 216);
			this.pnldg.TabIndex = 82;
			this.pnldg.Visible = false;
			this.pnldg.Leave += new System.EventHandler(this.pnldg_Leave_1);
			// 
			// frmPayTypeMana
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(1028, 533);
			this.Controls.Add(this.pnldg);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.Name = "frmPayTypeMana";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "病人类型收费项目维护";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPayTypeMana_KeyDown);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmPayTypeMana_Closing);
			this.Load += new System.EventHandler(this.frmPayTypeMana_Load);
			((System.ComponentModel.ISupportInitialize)(this.m_DgPayType)).EndInit();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_DgItemDe)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_DgItem)).EndInit();
			this.panel2.ResumeLayout(false);
			this.pnldg.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void CreateController()
		{
			this.objController = new com.digitalwave.iCare.gui.HIS.clsControlPayTypeMana();
			this.objController.Set_GUI_Apperance(this);
		}

		private void m_txtTQY_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void label12_Click(object sender, System.EventArgs e)
		{
		
		}

		private void frmPayTypeMana_Load(object sender, System.EventArgs e)
		{
			((clsControlPayTypeMana)this.objController).m_lngFrmLoad();
		}

		private void m_DgPayType_m_evtCurrentCellChanged(object sender, System.EventArgs e)
		{
			((clsControlPayTypeMana)this.objController).m_lngGetAndShowItem();
		}

		private void m_txtFindTtem_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				if(pnldg.Visible==false)
					((clsControlPayTypeMana)this.objController).FindItemData();
			}
		}

		private void m_DgItem_m_evtDataGridKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				((clsControlPayTypeMana)this.objController).seleItem();
		}

		private void pnldg_Leave(object sender, System.EventArgs e)
		{
			panel1.Height=495;
			pnldg.Visible=false;
		
		}

		private void m_btnSave_Click(object sender, System.EventArgs e)
		{
			if(m_DgPayType.CurrentCell.RowNumber==-1)
			{
				MessageBox.Show("请先选择病人类型！","系统提示");
				return;
			}
			if(m_txtItemName.Text=="")
			{
				errorProvider1.SetError(m_txtItemName,"必需输入项目名称");
				return;
			}
			if(m_txtTQY.Text=="")
			{
				errorProvider1.SetError(m_txtTQY,"必需输入数量");
				return;
			}
			((clsControlPayTypeMana)this.objController).m_lngSave();
			errorProvider1.SetError(m_txtTQY,"");
			errorProvider1.SetError(m_txtItemName,"");
			m_txtFindTtem.Focus();

		}

		private void btnClear_Click(object sender, System.EventArgs e)
		{
			((clsControlPayTypeMana)this.objController).m_lngClear();
			errorProvider1.SetError(m_txtTQY,"");
			errorProvider1.SetError(m_txtItemName,"");
		}

		private void m_DgItemDe_m_evtDoubleClickCell(object sender, com.digitalwave.controls.datagrid.clsDGTextMouseClickEventArgs e)
		{
			((clsControlPayTypeMana)this.objController).ModifyfillToTxtBox();
		}

		private void btnDele_Click(object sender, System.EventArgs e)
		{
			((clsControlPayTypeMana)this.objController).m_lngDeleItem();
		}

		private void buttonXP2_Click(object sender, System.EventArgs e)
		{
			if(MessageBox.Show("是否确定要退出系统？","系统提示",MessageBoxButtons.YesNo)==DialogResult.Yes)
				this.Close();
		}

		private void frmPayTypeMana_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Escape)
			{
				if(pnldg.Visible==false)
				{
					if(MessageBox.Show("是否确定要退出系统？","Icare",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
					{
						this.Close();
					}
				}
				else
				{
					this.panel1.Height=442;
					this.pnldg.Visible=false;
					m_txtFindTtem.Focus();
				}
			}
		}

		private void m_txtTQY_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				comboBox1.Focus();

		}

		private void frmPayTypeMana_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			m_DgPayType.m_mthDeleteAllRow();
			m_DgItemDe.m_mthDeleteAllRow();
			m_btnSave.Focus();
		}

		private void comboBox2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				comboBox3.Focus();
		}

		private void comboBox3_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				m_btnSave.Focus();
		}

		private void comboBox1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				comboBox2.Focus();
		}

		private void pnldg_Leave_1(object sender, System.EventArgs e)
		{
			panel1.Height=442;
			pnldg.Visible=false;
		}
	}
}
