using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmMedCommonUse 的摘要说明。
	/// </summary>
	public class frmMedCommonUse : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		internal System.Windows.Forms.ComboBox m_cmbMedSort;
		internal System.Windows.Forms.ComboBox m_cmbShape;
		internal System.Windows.Forms.TextBox m_txtMedName;
		private PinkieControls.ButtonXP m_BtnSearch;
		private PinkieControls.ButtonXP m_BtnSetPersonal;
		private PinkieControls.ButtonXP m_BtnSetDept;
		private PinkieControls.ButtonXP m_BtnDel;
		internal com.digitalwave.controls.datagrid.ctlDataGrid m_dgMedBse;
		internal com.digitalwave.controls.datagrid.ctlDataGrid m_dgCommonUse;
		private PinkieControls.ButtonXP buttonXP2;
		private PinkieControls.ButtonXP m_BtnReresh;
		private PinkieControls.ButtonXP m_BtnSave;
		internal System.Windows.Forms.ComboBox m_cmbCondition;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMedCommonUse()
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
		public override void CreateController()
		{
			this.objController=new com.digitalwave.iCare.gui.HIS.clsControlMedCommonUse();
			objController.Set_GUI_Apperance(this);
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.m_dgMedBse = new com.digitalwave.controls.datagrid.ctlDataGrid();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.m_dgCommonUse = new com.digitalwave.controls.datagrid.ctlDataGrid();
			this.m_cmbMedSort = new System.Windows.Forms.ComboBox();
			this.m_cmbShape = new System.Windows.Forms.ComboBox();
			this.m_txtMedName = new System.Windows.Forms.TextBox();
			this.m_BtnSearch = new PinkieControls.ButtonXP();
			this.m_BtnSetPersonal = new PinkieControls.ButtonXP();
			this.m_BtnSetDept = new PinkieControls.ButtonXP();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.m_BtnDel = new PinkieControls.ButtonXP();
			this.m_BtnSave = new PinkieControls.ButtonXP();
			this.buttonXP2 = new PinkieControls.ButtonXP();
			this.m_BtnReresh = new PinkieControls.ButtonXP();
			this.m_cmbCondition = new System.Windows.Forms.ComboBox();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_dgMedBse)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_dgCommonUse)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox1.Controls.Add(this.m_dgMedBse);
			this.groupBox1.Location = new System.Drawing.Point(4, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(372, 540);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "项目信息";
			// 
			// m_dgMedBse
			// 
			this.m_dgMedBse.AllowAddNew = false;
			this.m_dgMedBse.AllowDelete = false;
			this.m_dgMedBse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_dgMedBse.AutoAppendRow = true;
			this.m_dgMedBse.AutoScroll = true;
			this.m_dgMedBse.BackgroundColor = System.Drawing.SystemColors.Window;
			this.m_dgMedBse.CaptionText = "";
			this.m_dgMedBse.CaptionVisible = false;
			this.m_dgMedBse.ColumnHeadersVisible = true;
			clsColumnInfo1.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo1.BackColor = System.Drawing.Color.White;
			clsColumnInfo1.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo1.ColumnIndex = 0;
			clsColumnInfo1.ColumnName = "itemcode_vchr";
			clsColumnInfo1.ColumnWidth = 75;
			clsColumnInfo1.Enabled = false;
			clsColumnInfo1.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo1.HeadText = "编号";
			clsColumnInfo1.ReadOnly = true;
			clsColumnInfo1.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo2.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo2.BackColor = System.Drawing.Color.White;
			clsColumnInfo2.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo2.ColumnIndex = 1;
			clsColumnInfo2.ColumnName = "itemname_vchr";
			clsColumnInfo2.ColumnWidth = 150;
			clsColumnInfo2.Enabled = false;
			clsColumnInfo2.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo2.HeadText = "药品名称";
			clsColumnInfo2.ReadOnly = true;
			clsColumnInfo2.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo3.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo3.BackColor = System.Drawing.Color.White;
			clsColumnInfo3.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo3.ColumnIndex = 2;
			clsColumnInfo3.ColumnName = "itemspec_vchr";
			clsColumnInfo3.ColumnWidth = 150;
			clsColumnInfo3.Enabled = false;
			clsColumnInfo3.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo3.HeadText = "药品规格";
			clsColumnInfo3.ReadOnly = true;
			clsColumnInfo3.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo4.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo4.BackColor = System.Drawing.Color.White;
			clsColumnInfo4.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo4.ColumnIndex = 3;
			clsColumnInfo4.ColumnName = "itemid_chr";
			clsColumnInfo4.ColumnWidth = 0;
			clsColumnInfo4.Enabled = false;
			clsColumnInfo4.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo4.HeadText = "itemid_chr";
			clsColumnInfo4.ReadOnly = true;
			clsColumnInfo4.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo5.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo5.BackColor = System.Drawing.Color.White;
			clsColumnInfo5.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo5.ColumnIndex = 4;
			clsColumnInfo5.ColumnName = "itemsrctypename_vchr";
			clsColumnInfo5.ColumnWidth = 0;
			clsColumnInfo5.Enabled = true;
			clsColumnInfo5.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo5.HeadText = "itemsrctypename_vchr";
			clsColumnInfo5.ReadOnly = false;
			clsColumnInfo5.TextFont = new System.Drawing.Font("宋体", 10F);
			this.m_dgMedBse.Columns.Add(clsColumnInfo1);
			this.m_dgMedBse.Columns.Add(clsColumnInfo2);
			this.m_dgMedBse.Columns.Add(clsColumnInfo3);
			this.m_dgMedBse.Columns.Add(clsColumnInfo4);
			this.m_dgMedBse.Columns.Add(clsColumnInfo5);
			this.m_dgMedBse.FullRowSelect = true;
			this.m_dgMedBse.Location = new System.Drawing.Point(4, 28);
			this.m_dgMedBse.MultiSelect = true;
			this.m_dgMedBse.Name = "m_dgMedBse";
			this.m_dgMedBse.ReadOnly = false;
			this.m_dgMedBse.RowHeadersVisible = false;
			this.m_dgMedBse.RowHeaderWidth = 35;
			this.m_dgMedBse.SelectedRowBackColor = System.Drawing.Color.Purple;
			this.m_dgMedBse.SelectedRowForeColor = System.Drawing.Color.White;
			this.m_dgMedBse.Size = new System.Drawing.Size(364, 508);
			this.m_dgMedBse.TabIndex = 20;
			this.m_dgMedBse.m_evtDataGridKeyDown += new System.Windows.Forms.KeyEventHandler(this.m_dgMedBse_m_evtDataGridKeyDown);
			this.m_dgMedBse.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_dgMedBse_KeyDown);
			this.m_dgMedBse.m_evtDoubleClickCell += new com.digitalwave.controls.datagrid.clsDGTextMouseClickEventHandler(this.m_dgMedBse_m_evtDoubleClickCell);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.m_dgCommonUse);
			this.groupBox2.Location = new System.Drawing.Point(580, 4);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(408, 540);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "常用项目";
			// 
			// m_dgCommonUse
			// 
			this.m_dgCommonUse.AllowAddNew = false;
			this.m_dgCommonUse.AllowDelete = false;
			this.m_dgCommonUse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_dgCommonUse.AutoAppendRow = true;
			this.m_dgCommonUse.AutoScroll = true;
			this.m_dgCommonUse.BackgroundColor = System.Drawing.SystemColors.Window;
			this.m_dgCommonUse.CaptionText = "";
			this.m_dgCommonUse.CaptionVisible = false;
			this.m_dgCommonUse.ColumnHeadersVisible = true;
			clsColumnInfo6.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo6.BackColor = System.Drawing.Color.White;
			clsColumnInfo6.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo6.ColumnIndex = 0;
			clsColumnInfo6.ColumnName = "itemcode_vchr";
			clsColumnInfo6.ColumnWidth = 75;
			clsColumnInfo6.Enabled = false;
			clsColumnInfo6.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo6.HeadText = "编号";
			clsColumnInfo6.ReadOnly = true;
			clsColumnInfo6.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo7.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo7.BackColor = System.Drawing.Color.White;
			clsColumnInfo7.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo7.ColumnIndex = 1;
			clsColumnInfo7.ColumnName = "itemname_vchr";
			clsColumnInfo7.ColumnWidth = 150;
			clsColumnInfo7.Enabled = false;
			clsColumnInfo7.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo7.HeadText = "药品名称";
			clsColumnInfo7.ReadOnly = true;
			clsColumnInfo7.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo8.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo8.BackColor = System.Drawing.Color.White;
			clsColumnInfo8.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo8.ColumnIndex = 2;
			clsColumnInfo8.ColumnName = "itemspec_vchr";
			clsColumnInfo8.ColumnWidth = 150;
			clsColumnInfo8.Enabled = false;
			clsColumnInfo8.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo8.HeadText = "药品规格";
			clsColumnInfo8.ReadOnly = true;
			clsColumnInfo8.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo9.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo9.BackColor = System.Drawing.Color.White;
			clsColumnInfo9.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo9.ColumnIndex = 3;
			clsColumnInfo9.ColumnName = "deptname_vchr";
			clsColumnInfo9.ColumnWidth = 75;
			clsColumnInfo9.Enabled = true;
			clsColumnInfo9.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo9.HeadText = "科室名称";
			clsColumnInfo9.ReadOnly = false;
			clsColumnInfo9.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo10.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo10.BackColor = System.Drawing.Color.White;
			clsColumnInfo10.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo10.ColumnIndex = 4;
			clsColumnInfo10.ColumnName = "privilege_name";
			clsColumnInfo10.ColumnWidth = 75;
			clsColumnInfo10.Enabled = true;
			clsColumnInfo10.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo10.HeadText = "个人/科室";
			clsColumnInfo10.ReadOnly = false;
			clsColumnInfo10.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo11.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo11.BackColor = System.Drawing.Color.White;
			clsColumnInfo11.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo11.ColumnIndex = 5;
			clsColumnInfo11.ColumnName = "privilege_int";
			clsColumnInfo11.ColumnWidth = 0;
			clsColumnInfo11.Enabled = true;
			clsColumnInfo11.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo11.HeadText = "privilege_int";
			clsColumnInfo11.ReadOnly = false;
			clsColumnInfo11.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo12.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo12.BackColor = System.Drawing.Color.White;
			clsColumnInfo12.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo12.ColumnIndex = 6;
			clsColumnInfo12.ColumnName = "deptid_chr";
			clsColumnInfo12.ColumnWidth = 0;
			clsColumnInfo12.Enabled = true;
			clsColumnInfo12.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo12.HeadText = "deptid_chr";
			clsColumnInfo12.ReadOnly = false;
			clsColumnInfo12.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo13.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo13.BackColor = System.Drawing.Color.White;
			clsColumnInfo13.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo13.ColumnIndex = 7;
			clsColumnInfo13.ColumnName = "itemid_chr";
			clsColumnInfo13.ColumnWidth = 0;
			clsColumnInfo13.Enabled = false;
			clsColumnInfo13.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo13.HeadText = "itemid_chr";
			clsColumnInfo13.ReadOnly = true;
			clsColumnInfo13.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo14.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo14.BackColor = System.Drawing.Color.White;
			clsColumnInfo14.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo14.ColumnIndex = 8;
			clsColumnInfo14.ColumnName = "createrid_chr";
			clsColumnInfo14.ColumnWidth = 0;
			clsColumnInfo14.Enabled = true;
			clsColumnInfo14.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo14.HeadText = "createrid_chr";
			clsColumnInfo14.ReadOnly = false;
			clsColumnInfo14.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo15.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo15.BackColor = System.Drawing.Color.White;
			clsColumnInfo15.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo15.ColumnIndex = 9;
			clsColumnInfo15.ColumnName = "SEQID_CHR";
			clsColumnInfo15.ColumnWidth = 0;
			clsColumnInfo15.Enabled = true;
			clsColumnInfo15.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo15.HeadText = "SEQID_CHR";
			clsColumnInfo15.ReadOnly = false;
			clsColumnInfo15.TextFont = new System.Drawing.Font("宋体", 10F);
			this.m_dgCommonUse.Columns.Add(clsColumnInfo6);
			this.m_dgCommonUse.Columns.Add(clsColumnInfo7);
			this.m_dgCommonUse.Columns.Add(clsColumnInfo8);
			this.m_dgCommonUse.Columns.Add(clsColumnInfo9);
			this.m_dgCommonUse.Columns.Add(clsColumnInfo10);
			this.m_dgCommonUse.Columns.Add(clsColumnInfo11);
			this.m_dgCommonUse.Columns.Add(clsColumnInfo12);
			this.m_dgCommonUse.Columns.Add(clsColumnInfo13);
			this.m_dgCommonUse.Columns.Add(clsColumnInfo14);
			this.m_dgCommonUse.Columns.Add(clsColumnInfo15);
			this.m_dgCommonUse.FullRowSelect = true;
			this.m_dgCommonUse.Location = new System.Drawing.Point(4, 28);
			this.m_dgCommonUse.MultiSelect = true;
			this.m_dgCommonUse.Name = "m_dgCommonUse";
			this.m_dgCommonUse.ReadOnly = false;
			this.m_dgCommonUse.RowHeadersVisible = false;
			this.m_dgCommonUse.RowHeaderWidth = 35;
			this.m_dgCommonUse.SelectedRowBackColor = System.Drawing.Color.Purple;
			this.m_dgCommonUse.SelectedRowForeColor = System.Drawing.Color.White;
			this.m_dgCommonUse.Size = new System.Drawing.Size(400, 508);
			this.m_dgCommonUse.TabIndex = 0;
			this.m_dgCommonUse.m_evtDataGridKeyDown += new System.Windows.Forms.KeyEventHandler(this.m_dgCommonUse_m_evtDataGridKeyDown);
			this.m_dgCommonUse.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_dgCommonUse_KeyDown);
			this.m_dgCommonUse.m_evtDoubleClickCell += new com.digitalwave.controls.datagrid.clsDGTextMouseClickEventHandler(this.m_dgCommonUse_m_evtDoubleClickCell);
			// 
			// m_cmbMedSort
			// 
			this.m_cmbMedSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cmbMedSort.Items.AddRange(new object[] {
															  "西药",
															  "成药",
															  "中药"});
			this.m_cmbMedSort.Location = new System.Drawing.Point(452, 56);
			this.m_cmbMedSort.Name = "m_cmbMedSort";
			this.m_cmbMedSort.Size = new System.Drawing.Size(121, 22);
			this.m_cmbMedSort.TabIndex = 4;
			// 
			// m_cmbShape
			// 
			this.m_cmbShape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cmbShape.Location = new System.Drawing.Point(452, 100);
			this.m_cmbShape.Name = "m_cmbShape";
			this.m_cmbShape.Size = new System.Drawing.Size(121, 22);
			this.m_cmbShape.TabIndex = 3;
			// 
			// m_txtMedName
			// 
			this.m_txtMedName.Location = new System.Drawing.Point(452, 236);
			this.m_txtMedName.Name = "m_txtMedName";
			this.m_txtMedName.Size = new System.Drawing.Size(120, 23);
			this.m_txtMedName.TabIndex = 0;
			this.m_txtMedName.Text = "";
			this.m_txtMedName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtMedName_KeyDown);
			this.m_txtMedName.Leave += new System.EventHandler(this.m_txtMedName_Leave);
			// 
			// m_BtnSearch
			// 
			this.m_BtnSearch.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_BtnSearch.DefaultScheme = true;
			this.m_BtnSearch.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_BtnSearch.Hint = "";
			this.m_BtnSearch.Location = new System.Drawing.Point(404, 272);
			this.m_BtnSearch.Name = "m_BtnSearch";
			this.m_BtnSearch.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_BtnSearch.Size = new System.Drawing.Size(144, 36);
			this.m_BtnSearch.TabIndex = 1;
			this.m_BtnSearch.Text = "查找(&F)";
			this.m_BtnSearch.Click += new System.EventHandler(this.m_BtnSearch_Click);
			// 
			// m_BtnSetPersonal
			// 
			this.m_BtnSetPersonal.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_BtnSetPersonal.DefaultScheme = true;
			this.m_BtnSetPersonal.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_BtnSetPersonal.Hint = "";
			this.m_BtnSetPersonal.Location = new System.Drawing.Point(404, 328);
			this.m_BtnSetPersonal.Name = "m_BtnSetPersonal";
			this.m_BtnSetPersonal.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_BtnSetPersonal.Size = new System.Drawing.Size(144, 36);
			this.m_BtnSetPersonal.TabIndex = 6;
			this.m_BtnSetPersonal.Text = "设为个人常用项目";
			this.m_BtnSetPersonal.Click += new System.EventHandler(this.m_BtnSetPersonal_Click);
			// 
			// m_BtnSetDept
			// 
			this.m_BtnSetDept.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_BtnSetDept.DefaultScheme = true;
			this.m_BtnSetDept.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_BtnSetDept.Hint = "";
			this.m_BtnSetDept.Location = new System.Drawing.Point(404, 368);
			this.m_BtnSetDept.Name = "m_BtnSetDept";
			this.m_BtnSetDept.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_BtnSetDept.Size = new System.Drawing.Size(144, 36);
			this.m_BtnSetDept.TabIndex = 7;
			this.m_BtnSetDept.Text = "设为科室常用药";
			this.m_BtnSetDept.Visible = false;
			this.m_BtnSetDept.Click += new System.EventHandler(this.m_BtnSetDept_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(380, 60);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 16);
			this.label1.TabIndex = 13;
			this.label1.Text = "药品类型";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(380, 104);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 13;
			this.label2.Text = "剂    型";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(380, 196);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 23);
			this.label3.TabIndex = 13;
			this.label3.Text = "查询条件";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(380, 240);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(68, 23);
			this.label4.TabIndex = 13;
			this.label4.Text = "查询内容";
			// 
			// m_BtnDel
			// 
			this.m_BtnDel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_BtnDel.DefaultScheme = true;
			this.m_BtnDel.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_BtnDel.Hint = "";
			this.m_BtnDel.Location = new System.Drawing.Point(404, 384);
			this.m_BtnDel.Name = "m_BtnDel";
			this.m_BtnDel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_BtnDel.Size = new System.Drawing.Size(144, 36);
			this.m_BtnDel.TabIndex = 8;
			this.m_BtnDel.Text = "删除常用项目";
			this.m_BtnDel.Click += new System.EventHandler(this.m_BtnDel_Click);
			// 
			// m_BtnSave
			// 
			this.m_BtnSave.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_BtnSave.DefaultScheme = true;
			this.m_BtnSave.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_BtnSave.Hint = "";
			this.m_BtnSave.Location = new System.Drawing.Point(404, 440);
			this.m_BtnSave.Name = "m_BtnSave";
			this.m_BtnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_BtnSave.Size = new System.Drawing.Size(144, 36);
			this.m_BtnSave.TabIndex = 9;
			this.m_BtnSave.Text = "保存(&S)";
			this.m_BtnSave.Click += new System.EventHandler(this.m_BtnSave_Click);
			// 
			// buttonXP2
			// 
			this.buttonXP2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.buttonXP2.DefaultScheme = true;
			this.buttonXP2.DialogResult = System.Windows.Forms.DialogResult.None;
			this.buttonXP2.Hint = "";
			this.buttonXP2.Location = new System.Drawing.Point(404, 496);
			this.buttonXP2.Name = "buttonXP2";
			this.buttonXP2.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.buttonXP2.Size = new System.Drawing.Size(144, 36);
			this.buttonXP2.TabIndex = 10;
			this.buttonXP2.Text = "退出(&E)";
			this.buttonXP2.Click += new System.EventHandler(this.buttonXP2_Click);
			// 
			// m_BtnReresh
			// 
			this.m_BtnReresh.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_BtnReresh.DefaultScheme = true;
			this.m_BtnReresh.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_BtnReresh.Hint = "";
			this.m_BtnReresh.Location = new System.Drawing.Point(404, 136);
			this.m_BtnReresh.Name = "m_BtnReresh";
			this.m_BtnReresh.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_BtnReresh.Size = new System.Drawing.Size(144, 36);
			this.m_BtnReresh.TabIndex = 2;
			this.m_BtnReresh.Text = "刷新(&R)";
			this.m_BtnReresh.Click += new System.EventHandler(this.m_BtnReresh_Click);
			// 
			// m_cmbCondition
			// 
			this.m_cmbCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cmbCondition.Items.AddRange(new object[] {
																"药品编码",
																"药品名称",
																"拼音码",
																"五笔码",
																"英文名称"});
			this.m_cmbCondition.Location = new System.Drawing.Point(452, 188);
			this.m_cmbCondition.Name = "m_cmbCondition";
			this.m_cmbCondition.Size = new System.Drawing.Size(121, 22);
			this.m_cmbCondition.TabIndex = 14;
			this.m_cmbCondition.SelectedIndexChanged += new System.EventHandler(this.m_cmbCondition_SelectedIndexChanged);
			// 
			// frmMedCommonUse
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(992, 549);
			this.Controls.Add(this.m_cmbCondition);
			this.Controls.Add(this.m_BtnReresh);
			this.Controls.Add(this.buttonXP2);
			this.Controls.Add(this.m_BtnSave);
			this.Controls.Add(this.m_BtnDel);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.m_BtnSearch);
			this.Controls.Add(this.m_txtMedName);
			this.Controls.Add(this.m_cmbShape);
			this.Controls.Add(this.m_cmbMedSort);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.m_BtnSetPersonal);
			this.Controls.Add(this.m_BtnSetDept);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label4);
			this.Font = new System.Drawing.Font("宋体", 10.5F);
			this.KeyPreview = true;
			this.Name = "frmMedCommonUse";
			this.Text = "常用药设置";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMedCommonUse_KeyDown);
			this.Load += new System.EventHandler(this.frmMedCommonUse_Load);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_dgMedBse)).EndInit();
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_dgCommonUse)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void frmMedCommonUse_Load(object sender, System.EventArgs e)
		{
			((clsControlMedCommonUse)this.objController).InitFrm();			
			SkipFocus(this);
			this.m_cmbCondition.SelectedIndex=2;
			this.m_txtMedName.Focus();		}
		System.Data.DataTable dtFind=new System.Data.DataTable();	
		private void m_BtnSearch_Click(object sender, System.EventArgs e)
		{			
			((clsControlMedCommonUse)this.objController).m_mthFind();
		}
		

		private void m_BtnSetPersonal_Click(object sender, System.EventArgs e)
		{
			if(this.m_dgMedBse.m_arrSelectRows().Length > 0)
			{
				((clsControlMedCommonUse)this.objController).Add(false);
			}
		}

		private void m_BtnSetDept_Click(object sender, System.EventArgs e)
		{
			if(this.m_dgMedBse.m_arrSelectRows().Length > 0)
			{
				((clsControlMedCommonUse)this.objController).Add(true);
			}
		}

		private void m_BtnDel_Click(object sender, System.EventArgs e)
		{
			if(this.m_dgCommonUse.m_arrSelectRows().Length > 0)
			{
				((clsControlMedCommonUse)this.objController).Del();
			}
		}

		private void buttonXP2_Click(object sender, System.EventArgs e)
		{
			//判断是否保存
			if(((clsControlMedCommonUse)this.objController).m_bChangeState())
			{
				if(MessageBox.Show("你改的内容未保存,是否保存退出?","提示",MessageBoxButtons.YesNo)==DialogResult.Yes)
				{
					if(((clsControlMedCommonUse)this.objController).m_lngSaveMedCommonUse() > 0)
					{
						MessageBox.Show("保存成功");
						this.Close();
					}
					else
					{
						MessageBox.Show("保存失败");
					}
				}
			}
			else
			{
				this.Close();
			}
		}

		private void m_BtnReresh_Click(object sender, System.EventArgs e)
		{
			((clsControlMedCommonUse)this.objController).InitMedBse(this.m_cmbMedSort.SelectedValue.ToString(),this.m_cmbShape.SelectedValue.ToString());
		}

		private void m_BtnSave_Click(object sender, System.EventArgs e)
		{
			if(((clsControlMedCommonUse)this.objController).m_lngSaveMedCommonUse() > 0)
			{
				MessageBox.Show("保存成功");
			}
			else
			{
				MessageBox.Show("保存失败");
			}
		}

		private void SkipFocus(System.Windows.Forms.Control obj)
		{
			if(obj.HasChildren)
			{
				for(int i1 = 0; i1 < obj.Controls.Count; i1 ++)
				{
					SkipFocus(obj.Controls[i1]);
				}
			}
			else
			{
				if(obj.Name!="m_txtMedName")
				{
					obj.KeyDown -=new KeyEventHandler(obj_KeyDown);
					obj.KeyDown +=new KeyEventHandler(obj_KeyDown);
				}
			}
		}

		private void obj_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				SendKeys.Send("{TAB}");
			}
		}

		private void frmMedCommonUse_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.F5)
			{
				if(this.m_cmbCondition.SelectedIndex==this.m_cmbCondition.Items.Count-1)
				{
					this.m_cmbCondition.SelectedIndex=0;
				}
				else
				{
					this.m_cmbCondition.SelectedIndex+=1;
				}
			}
		}

		private void m_dgMedBse_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.F5)
			{
				if(this.m_cmbCondition.SelectedIndex==this.m_cmbCondition.Items.Count-1)
				{
					this.m_cmbCondition.SelectedIndex=0;
				}
				else
				{
					this.m_cmbCondition.SelectedIndex+=1;
				}
			}
		}

		private void m_dgCommonUse_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			
		}

		private void m_dgMedBse_m_evtDataGridKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.F5)
			{
				if(this.m_cmbCondition.SelectedIndex==this.m_cmbCondition.Items.Count-1)
				{
					this.m_cmbCondition.SelectedIndex=0;
				}
				else
				{
					this.m_cmbCondition.SelectedIndex+=1;
				}
			}
		}

		private void m_dgCommonUse_m_evtDataGridKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.F5)
			{
				if(this.m_cmbCondition.SelectedIndex==this.m_cmbCondition.Items.Count-1)
				{
					this.m_cmbCondition.SelectedIndex=0;
				}
				else
				{
					this.m_cmbCondition.SelectedIndex+=1;
				}
			}
		}

		private void m_cmbCondition_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_txtMedName.Focus();
		}

		private void m_txtMedName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				((clsControlMedCommonUse)this.objController).m_mthFind();
				this.m_txtMedName.Focus();
				m_txtMedName.SelectAll();
			}
		}

		private void m_dgMedBse_m_evtDoubleClickCell(object sender, com.digitalwave.controls.datagrid.clsDGTextMouseClickEventArgs e)
		{
			if(this.m_dgMedBse.m_arrSelectRows().Length > 0)
			{
				((clsControlMedCommonUse)this.objController).Add(false);
				this.m_txtMedName.Focus();
				m_txtMedName.SelectAll();
			}
		}

		private void m_dgCommonUse_m_evtDoubleClickCell(object sender, com.digitalwave.controls.datagrid.clsDGTextMouseClickEventArgs e)
		{
			if(this.m_dgCommonUse.m_arrSelectRows().Length > 0)
			{
				((clsControlMedCommonUse)this.objController).Del();
				this.m_txtMedName.Focus();
				m_txtMedName.SelectAll();
			}
		}

		private void m_txtMedName_Leave(object sender, System.EventArgs e)
		{

		}
	}
}
