using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.controls.datagrid;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmConcertrecipe 的摘要说明。
	/// </summary>
	public class frmConcertrecipe : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		internal com.digitalwave.controls.datagrid.ctlDataGrid m_dtgConcertrecipe;
		internal com.digitalwave.controls.datagrid.ctlDataGrid m_dtgConcertrecipeDetail;
		internal System.Windows.Forms.ListView m_lsvDept;
		internal PinkieControls.ButtonXP m_btnSaveConcertrecipe;
		internal System.Windows.Forms.ColumnHeader dept;
		internal PinkieControls.ButtonXP m_btnDeleteConcertrecipe;
		private PinkieControls.ButtonXP m_btndeleteDetail;
		private PinkieControls.ButtonXP m_btnSaveDetail;
		private System.Windows.Forms.Label label1;
		internal System.Windows.Forms.TextBox m_txtDept;
		internal System.Windows.Forms.Panel m_pnlDept;
		internal System.Windows.Forms.ListView m_lsvSelectDept;
		internal PinkieControls.ButtonXP m_btnSaveDept;
		internal PinkieControls.ButtonXP m_btnDeleteDept;
		internal System.Windows.Forms.Panel m_pnlCharge;
		internal System.Windows.Forms.ListView m_lsvCharge;
		internal System.Windows.Forms.ComboBox m_cmbFind;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.Label label2;
		internal System.Windows.Forms.Label m_lblP;
		internal System.Windows.Forms.ToolTip m_tip;
		internal System.Windows.Forms.Label m_lblUser;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Splitter splitter1;
		internal System.Windows.Forms.ListView listView3;
		private System.Windows.Forms.ColumnHeader columnHeader14;
		private System.Windows.Forms.ColumnHeader columnHeader15;
		private System.Windows.Forms.ColumnHeader columnHeader16;
		private System.Windows.Forms.ColumnHeader columnHeader17;
		private System.Windows.Forms.ColumnHeader columnHeader18;
		internal System.Windows.Forms.ListView listView2;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.ComponentModel.IContainer components;

		public frmConcertrecipe()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			((clsControlConcertreCipe)this.objController).FillDept();
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
//		internal 
//		internal 
//		internal 
//		internal 
//		internal 
//		internal 
//		internal 
//		internal 
//		internal 
//		internal 
//		internal 
//		internal 
//		internal 
//		internal 
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
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
			this.m_dtgConcertrecipe = new com.digitalwave.controls.datagrid.ctlDataGrid();
			this.m_dtgConcertrecipeDetail = new com.digitalwave.controls.datagrid.ctlDataGrid();
			this.m_lsvDept = new System.Windows.Forms.ListView();
			this.dept = new System.Windows.Forms.ColumnHeader();
			this.m_btnSaveConcertrecipe = new PinkieControls.ButtonXP();
			this.m_btnDeleteConcertrecipe = new PinkieControls.ButtonXP();
			this.m_btndeleteDetail = new PinkieControls.ButtonXP();
			this.m_btnSaveDetail = new PinkieControls.ButtonXP();
			this.m_txtDept = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.m_pnlDept = new System.Windows.Forms.Panel();
			this.m_lsvSelectDept = new System.Windows.Forms.ListView();
			this.m_btnSaveDept = new PinkieControls.ButtonXP();
			this.m_btnDeleteDept = new PinkieControls.ButtonXP();
			this.m_pnlCharge = new System.Windows.Forms.Panel();
			this.listView3 = new System.Windows.Forms.ListView();
			this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader18 = new System.Windows.Forms.ColumnHeader();
			this.listView2 = new System.Windows.Forms.ListView();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.m_lsvCharge = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.m_cmbFind = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.m_lblP = new System.Windows.Forms.Label();
			this.m_tip = new System.Windows.Forms.ToolTip(this.components);
			this.m_lblUser = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.m_dtgConcertrecipe)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.m_dtgConcertrecipeDetail)).BeginInit();
			this.m_pnlDept.SuspendLayout();
			this.m_pnlCharge.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_dtgConcertrecipe
			// 
			this.m_dtgConcertrecipe.AllowAddNew = true;
			this.m_dtgConcertrecipe.AllowDelete = false;
			this.m_dtgConcertrecipe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_dtgConcertrecipe.AutoAppendRow = true;
			this.m_dtgConcertrecipe.AutoScroll = true;
			this.m_dtgConcertrecipe.BackColor = System.Drawing.Color.White;
			this.m_dtgConcertrecipe.BackgroundColor = System.Drawing.SystemColors.Window;
			this.m_dtgConcertrecipe.CaptionText = "";
			this.m_dtgConcertrecipe.CaptionVisible = false;
			this.m_dtgConcertrecipe.ColumnHeadersVisible = true;
			clsColumnInfo1.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo1.BackColor = System.Drawing.Color.White;
			clsColumnInfo1.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo1.ColumnIndex = 0;
			clsColumnInfo1.ColumnName = "RECIPEID_CHR";
			clsColumnInfo1.ColumnWidth = 0;
			clsColumnInfo1.Enabled = false;
			clsColumnInfo1.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo1.HeadText = "处方编号";
			clsColumnInfo1.ReadOnly = true;
			clsColumnInfo1.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo2.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo2.BackColor = System.Drawing.Color.White;
			clsColumnInfo2.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo2.ColumnIndex = 1;
			clsColumnInfo2.ColumnName = "RECIPENAME_CHR";
			clsColumnInfo2.ColumnWidth = 75;
			clsColumnInfo2.Enabled = true;
			clsColumnInfo2.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo2.HeadText = "处方名称";
			clsColumnInfo2.ReadOnly = false;
			clsColumnInfo2.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo3.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo3.BackColor = System.Drawing.Color.White;
			clsColumnInfo3.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo3.ColumnIndex = 2;
			clsColumnInfo3.ColumnName = "PRIVILEGE_INT";
			clsColumnInfo3.ColumnWidth = 75;
			clsColumnInfo3.Enabled = true;
			clsColumnInfo3.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo3.HeadText = "使用权限";
			clsColumnInfo3.ReadOnly = false;
			clsColumnInfo3.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo4.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo4.BackColor = System.Drawing.Color.White;
			clsColumnInfo4.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo4.ColumnIndex = 3;
			clsColumnInfo4.ColumnName = "USERCODE_CHR";
			clsColumnInfo4.ColumnWidth = 60;
			clsColumnInfo4.Enabled = true;
			clsColumnInfo4.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo4.HeadText = "助记码";
			clsColumnInfo4.ReadOnly = false;
			clsColumnInfo4.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo5.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo5.BackColor = System.Drawing.Color.White;
			clsColumnInfo5.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo5.ColumnIndex = 4;
			clsColumnInfo5.ColumnName = "WBCODE_CHR";
			clsColumnInfo5.ColumnWidth = 60;
			clsColumnInfo5.Enabled = true;
			clsColumnInfo5.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo5.HeadText = "五笔码";
			clsColumnInfo5.ReadOnly = false;
			clsColumnInfo5.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo6.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo6.BackColor = System.Drawing.Color.White;
			clsColumnInfo6.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo6.ColumnIndex = 5;
			clsColumnInfo6.ColumnName = "PYCODE_CHR";
			clsColumnInfo6.ColumnWidth = 60;
			clsColumnInfo6.Enabled = true;
			clsColumnInfo6.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo6.HeadText = "拼音码";
			clsColumnInfo6.ReadOnly = false;
			clsColumnInfo6.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo7.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo7.BackColor = System.Drawing.Color.White;
			clsColumnInfo7.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo7.ColumnIndex = 6;
			clsColumnInfo7.ColumnName = "CREATERID_CHR";
			clsColumnInfo7.ColumnWidth = 0;
			clsColumnInfo7.Enabled = false;
			clsColumnInfo7.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo7.HeadText = "创建人编号";
			clsColumnInfo7.ReadOnly = true;
			clsColumnInfo7.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo8.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo8.BackColor = System.Drawing.Color.White;
			clsColumnInfo8.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo8.ColumnIndex = 7;
			clsColumnInfo8.ColumnName = "CREATERNAME_VCHR";
			clsColumnInfo8.ColumnWidth = 0;
			clsColumnInfo8.Enabled = false;
			clsColumnInfo8.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo8.HeadText = "创建人名称";
			clsColumnInfo8.ReadOnly = true;
			clsColumnInfo8.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo9.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo9.BackColor = System.Drawing.Color.White;
			clsColumnInfo9.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo9.ColumnIndex = 8;
			clsColumnInfo9.ColumnName = "STATUS_INT";
			clsColumnInfo9.ColumnWidth = 0;
			clsColumnInfo9.Enabled = false;
			clsColumnInfo9.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo9.HeadText = "状态";
			clsColumnInfo9.ReadOnly = true;
			clsColumnInfo9.TextFont = new System.Drawing.Font("宋体", 10F);
			this.m_dtgConcertrecipe.Columns.Add(clsColumnInfo1);
			this.m_dtgConcertrecipe.Columns.Add(clsColumnInfo2);
			this.m_dtgConcertrecipe.Columns.Add(clsColumnInfo3);
			this.m_dtgConcertrecipe.Columns.Add(clsColumnInfo4);
			this.m_dtgConcertrecipe.Columns.Add(clsColumnInfo5);
			this.m_dtgConcertrecipe.Columns.Add(clsColumnInfo6);
			this.m_dtgConcertrecipe.Columns.Add(clsColumnInfo7);
			this.m_dtgConcertrecipe.Columns.Add(clsColumnInfo8);
			this.m_dtgConcertrecipe.Columns.Add(clsColumnInfo9);
			this.m_dtgConcertrecipe.FullRowSelect = false;
			this.m_dtgConcertrecipe.Location = new System.Drawing.Point(8, 8);
			this.m_dtgConcertrecipe.MultiSelect = false;
			this.m_dtgConcertrecipe.Name = "m_dtgConcertrecipe";
			this.m_dtgConcertrecipe.ReadOnly = false;
			this.m_dtgConcertrecipe.RowHeadersVisible = true;
			this.m_dtgConcertrecipe.RowHeaderWidth = 35;
			this.m_dtgConcertrecipe.SelectedRowBackColor = System.Drawing.Color.Purple;
			this.m_dtgConcertrecipe.SelectedRowForeColor = System.Drawing.Color.White;
			this.m_dtgConcertrecipe.Size = new System.Drawing.Size(376, 248);
			this.m_dtgConcertrecipe.TabIndex = 0;
			this.m_dtgConcertrecipe.m_evtCurrentCellChanged += new System.EventHandler(this.m_dtgConcertrecipe_m_evtCurrentCellChanged);
			this.m_dtgConcertrecipe.Validating += new System.ComponentModel.CancelEventHandler(this.m_dtgConcertrecipe_Validating);
			this.m_dtgConcertrecipe.m_evtDataGridTextBoxKeyDown += new com.digitalwave.controls.datagrid.clsDGTextKeyEventHandler(this.m_dtgConcertrecipe_m_evtDataGridTextBoxKeyDown);
			this.m_dtgConcertrecipe.m_evtDataGridTextBoxKeyPress += new com.digitalwave.controls.datagrid.clsDGTextKeyPressEventHandler(this.m_dtgConcertrecipe_m_evtDataGridTextBoxKeyPress);
			this.m_dtgConcertrecipe.Enter += new System.EventHandler(this.m_dtgConcertrecipe_Enter);
			// 
			// m_dtgConcertrecipeDetail
			// 
			this.m_dtgConcertrecipeDetail.AllowAddNew = true;
			this.m_dtgConcertrecipeDetail.AllowDelete = false;
			this.m_dtgConcertrecipeDetail.AutoAppendRow = true;
			this.m_dtgConcertrecipeDetail.AutoScroll = true;
			this.m_dtgConcertrecipeDetail.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.m_dtgConcertrecipeDetail.BackgroundColor = System.Drawing.SystemColors.Window;
			this.m_dtgConcertrecipeDetail.CaptionText = "";
			this.m_dtgConcertrecipeDetail.CaptionVisible = false;
			this.m_dtgConcertrecipeDetail.ColumnHeadersVisible = true;
			clsColumnInfo10.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo10.BackColor = System.Drawing.Color.White;
			clsColumnInfo10.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo10.ColumnIndex = 0;
			clsColumnInfo10.ColumnName = "RECIPEID_CHR";
			clsColumnInfo10.ColumnWidth = 0;
			clsColumnInfo10.Enabled = true;
			clsColumnInfo10.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo10.HeadText = "处方编号";
			clsColumnInfo10.ReadOnly = true;
			clsColumnInfo10.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo11.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo11.BackColor = System.Drawing.Color.White;
			clsColumnInfo11.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo11.ColumnIndex = 1;
			clsColumnInfo11.ColumnName = "DETAILID_CHR";
			clsColumnInfo11.ColumnWidth = 0;
			clsColumnInfo11.Enabled = true;
			clsColumnInfo11.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo11.HeadText = "处方明细编号";
			clsColumnInfo11.ReadOnly = true;
			clsColumnInfo11.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo12.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo12.BackColor = System.Drawing.Color.White;
			clsColumnInfo12.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo12.ColumnIndex = 2;
			clsColumnInfo12.ColumnName = "ITEMID_CHR";
			clsColumnInfo12.ColumnWidth = 0;
			clsColumnInfo12.Enabled = true;
			clsColumnInfo12.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo12.HeadText = "项目编号";
			clsColumnInfo12.ReadOnly = true;
			clsColumnInfo12.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo13.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo13.BackColor = System.Drawing.Color.White;
			clsColumnInfo13.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo13.ColumnIndex = 3;
			clsColumnInfo13.ColumnName = "ITEMNAME_VCHR";
			clsColumnInfo13.ColumnWidth = 150;
			clsColumnInfo13.Enabled = true;
			clsColumnInfo13.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo13.HeadText = "项目名称";
			clsColumnInfo13.ReadOnly = false;
			clsColumnInfo13.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo14.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo14.BackColor = System.Drawing.Color.White;
			clsColumnInfo14.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
			clsColumnInfo14.ColumnIndex = 4;
			clsColumnInfo14.ColumnName = "QTY_DEC";
			clsColumnInfo14.ColumnWidth = 50;
			clsColumnInfo14.Enabled = true;
			clsColumnInfo14.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo14.HeadText = "数量";
			clsColumnInfo14.ReadOnly = false;
			clsColumnInfo14.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo15.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo15.BackColor = System.Drawing.Color.White;
			clsColumnInfo15.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo15.ColumnIndex = 5;
			clsColumnInfo15.ColumnName = "Column5";
			clsColumnInfo15.ColumnWidth = 40;
			clsColumnInfo15.Enabled = false;
			clsColumnInfo15.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo15.HeadText = "类型";
			clsColumnInfo15.ReadOnly = true;
			clsColumnInfo15.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo16.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo16.BackColor = System.Drawing.Color.White;
			clsColumnInfo16.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo16.ColumnIndex = 6;
			clsColumnInfo16.ColumnName = "Column1";
			clsColumnInfo16.ColumnWidth = 75;
			clsColumnInfo16.Enabled = false;
			clsColumnInfo16.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo16.HeadText = "规格";
			clsColumnInfo16.ReadOnly = true;
			clsColumnInfo16.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo17.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo17.BackColor = System.Drawing.Color.White;
			clsColumnInfo17.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo17.ColumnIndex = 7;
			clsColumnInfo17.ColumnName = "Column2";
			clsColumnInfo17.ColumnWidth = 40;
			clsColumnInfo17.Enabled = false;
			clsColumnInfo17.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo17.HeadText = "单位";
			clsColumnInfo17.ReadOnly = true;
			clsColumnInfo17.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo18.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo18.BackColor = System.Drawing.Color.White;
			clsColumnInfo18.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo18.ColumnIndex = 8;
			clsColumnInfo18.ColumnName = "Column6";
			clsColumnInfo18.ColumnWidth = 75;
			clsColumnInfo18.Enabled = true;
			clsColumnInfo18.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo18.HeadText = "用法";
			clsColumnInfo18.ReadOnly = false;
			clsColumnInfo18.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo19.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo19.BackColor = System.Drawing.Color.White;
			clsColumnInfo19.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo19.ColumnIndex = 9;
			clsColumnInfo19.ColumnName = "Column8";
			clsColumnInfo19.ColumnWidth = 0;
			clsColumnInfo19.Enabled = true;
			clsColumnInfo19.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo19.HeadText = "用法ID";
			clsColumnInfo19.ReadOnly = true;
			clsColumnInfo19.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo20.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo20.BackColor = System.Drawing.Color.White;
			clsColumnInfo20.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo20.ColumnIndex = 10;
			clsColumnInfo20.ColumnName = "Column7";
			clsColumnInfo20.ColumnWidth = 75;
			clsColumnInfo20.Enabled = true;
			clsColumnInfo20.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo20.HeadText = "频率";
			clsColumnInfo20.ReadOnly = false;
			clsColumnInfo20.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo21.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo21.BackColor = System.Drawing.Color.White;
			clsColumnInfo21.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo21.ColumnIndex = 11;
			clsColumnInfo21.ColumnName = "Column9";
			clsColumnInfo21.ColumnWidth = 0;
			clsColumnInfo21.Enabled = true;
			clsColumnInfo21.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo21.HeadText = "频率ID";
			clsColumnInfo21.ReadOnly = true;
			clsColumnInfo21.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo22.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo22.BackColor = System.Drawing.Color.White;
			clsColumnInfo22.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
			clsColumnInfo22.ColumnIndex = 12;
			clsColumnInfo22.ColumnName = "Column3";
			clsColumnInfo22.ColumnWidth = 75;
			clsColumnInfo22.Enabled = false;
			clsColumnInfo22.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo22.HeadText = "单价";
			clsColumnInfo22.ReadOnly = true;
			clsColumnInfo22.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo23.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo23.BackColor = System.Drawing.Color.White;
			clsColumnInfo23.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
			clsColumnInfo23.ColumnIndex = 13;
			clsColumnInfo23.ColumnName = "Column4";
			clsColumnInfo23.ColumnWidth = 75;
			clsColumnInfo23.Enabled = true;
			clsColumnInfo23.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo23.HeadText = "总价";
			clsColumnInfo23.ReadOnly = true;
			clsColumnInfo23.TextFont = new System.Drawing.Font("宋体", 10F);
			this.m_dtgConcertrecipeDetail.Columns.Add(clsColumnInfo10);
			this.m_dtgConcertrecipeDetail.Columns.Add(clsColumnInfo11);
			this.m_dtgConcertrecipeDetail.Columns.Add(clsColumnInfo12);
			this.m_dtgConcertrecipeDetail.Columns.Add(clsColumnInfo13);
			this.m_dtgConcertrecipeDetail.Columns.Add(clsColumnInfo14);
			this.m_dtgConcertrecipeDetail.Columns.Add(clsColumnInfo15);
			this.m_dtgConcertrecipeDetail.Columns.Add(clsColumnInfo16);
			this.m_dtgConcertrecipeDetail.Columns.Add(clsColumnInfo17);
			this.m_dtgConcertrecipeDetail.Columns.Add(clsColumnInfo18);
			this.m_dtgConcertrecipeDetail.Columns.Add(clsColumnInfo19);
			this.m_dtgConcertrecipeDetail.Columns.Add(clsColumnInfo20);
			this.m_dtgConcertrecipeDetail.Columns.Add(clsColumnInfo21);
			this.m_dtgConcertrecipeDetail.Columns.Add(clsColumnInfo22);
			this.m_dtgConcertrecipeDetail.Columns.Add(clsColumnInfo23);
			this.m_dtgConcertrecipeDetail.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_dtgConcertrecipeDetail.FullRowSelect = false;
			this.m_dtgConcertrecipeDetail.Location = new System.Drawing.Point(0, 0);
			this.m_dtgConcertrecipeDetail.MultiSelect = false;
			this.m_dtgConcertrecipeDetail.Name = "m_dtgConcertrecipeDetail";
			this.m_dtgConcertrecipeDetail.ReadOnly = false;
			this.m_dtgConcertrecipeDetail.RowHeadersVisible = true;
			this.m_dtgConcertrecipeDetail.RowHeaderWidth = 35;
			this.m_dtgConcertrecipeDetail.SelectedRowBackColor = System.Drawing.Color.Purple;
			this.m_dtgConcertrecipeDetail.SelectedRowForeColor = System.Drawing.Color.White;
			this.m_dtgConcertrecipeDetail.Size = new System.Drawing.Size(588, 452);
			this.m_dtgConcertrecipeDetail.TabIndex = 1;
			this.m_dtgConcertrecipeDetail.m_evtDataGridKeyDown += new System.Windows.Forms.KeyEventHandler(this.m_dtgConcertrecipeDetail_m_evtDataGridKeyDown);
			this.m_dtgConcertrecipeDetail.m_evtDataGridTextBoxKeyDown += new com.digitalwave.controls.datagrid.clsDGTextKeyEventHandler(this.m_dtgConcertrecipeDetail_m_evtDataGridTextBoxKeyDown);
			this.m_dtgConcertrecipeDetail.m_evtDataGridTextBoxKeyPress += new com.digitalwave.controls.datagrid.clsDGTextKeyPressEventHandler(this.m_dtgConcertrecipeDetail_m_evtDataGridTextBoxKeyPress);
			// 
			// m_lsvDept
			// 
			this.m_lsvDept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_lsvDept.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.dept});
			this.m_lsvDept.FullRowSelect = true;
			this.m_lsvDept.GridLines = true;
			this.m_lsvDept.HideSelection = false;
			this.m_lsvDept.Location = new System.Drawing.Point(8, 304);
			this.m_lsvDept.MultiSelect = false;
			this.m_lsvDept.Name = "m_lsvDept";
			this.m_lsvDept.Size = new System.Drawing.Size(376, 160);
			this.m_lsvDept.TabIndex = 4;
			this.m_lsvDept.TabStop = false;
			this.m_lsvDept.View = System.Windows.Forms.View.Details;
			// 
			// dept
			// 
			this.dept.Text = "部门名称";
			this.dept.Width = 165;
			// 
			// m_btnSaveConcertrecipe
			// 
			this.m_btnSaveConcertrecipe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_btnSaveConcertrecipe.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnSaveConcertrecipe.DefaultScheme = true;
			this.m_btnSaveConcertrecipe.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnSaveConcertrecipe.Hint = "";
			this.m_btnSaveConcertrecipe.Location = new System.Drawing.Point(16, 264);
			this.m_btnSaveConcertrecipe.Name = "m_btnSaveConcertrecipe";
			this.m_btnSaveConcertrecipe.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnSaveConcertrecipe.Size = new System.Drawing.Size(104, 32);
			this.m_btnSaveConcertrecipe.TabIndex = 5;
			this.m_btnSaveConcertrecipe.Text = "保存处方(F2)";
			this.m_btnSaveConcertrecipe.Click += new System.EventHandler(this.m_btnSaveConcertrecipe_Click);
			// 
			// m_btnDeleteConcertrecipe
			// 
			this.m_btnDeleteConcertrecipe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_btnDeleteConcertrecipe.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnDeleteConcertrecipe.DefaultScheme = true;
			this.m_btnDeleteConcertrecipe.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnDeleteConcertrecipe.Hint = "";
			this.m_btnDeleteConcertrecipe.Location = new System.Drawing.Point(136, 264);
			this.m_btnDeleteConcertrecipe.Name = "m_btnDeleteConcertrecipe";
			this.m_btnDeleteConcertrecipe.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnDeleteConcertrecipe.Size = new System.Drawing.Size(104, 32);
			this.m_btnDeleteConcertrecipe.TabIndex = 6;
			this.m_btnDeleteConcertrecipe.Text = "删除处方(F3)";
			this.m_btnDeleteConcertrecipe.Click += new System.EventHandler(this.m_btnDeleteConcertrecipe_Click);
			// 
			// m_btndeleteDetail
			// 
			this.m_btndeleteDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_btndeleteDetail.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btndeleteDetail.DefaultScheme = true;
			this.m_btndeleteDetail.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btndeleteDetail.Hint = "";
			this.m_btndeleteDetail.Location = new System.Drawing.Point(552, 10);
			this.m_btndeleteDetail.Name = "m_btndeleteDetail";
			this.m_btndeleteDetail.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btndeleteDetail.Size = new System.Drawing.Size(104, 32);
			this.m_btndeleteDetail.TabIndex = 8;
			this.m_btndeleteDetail.Text = "删除明细(F7)";
			this.m_btndeleteDetail.Click += new System.EventHandler(this.m_btndeleteDetail_Click);
			// 
			// m_btnSaveDetail
			// 
			this.m_btnSaveDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_btnSaveDetail.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnSaveDetail.DefaultScheme = true;
			this.m_btnSaveDetail.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnSaveDetail.Hint = "";
			this.m_btnSaveDetail.Location = new System.Drawing.Point(440, 10);
			this.m_btnSaveDetail.Name = "m_btnSaveDetail";
			this.m_btnSaveDetail.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnSaveDetail.Size = new System.Drawing.Size(104, 32);
			this.m_btnSaveDetail.TabIndex = 7;
			this.m_btnSaveDetail.Text = "保存明细(F6)";
			this.m_btnSaveDetail.Click += new System.EventHandler(this.m_btnSaveDetail_Click);
			// 
			// m_txtDept
			// 
			this.m_txtDept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_txtDept.Location = new System.Drawing.Point(304, 16);
			this.m_txtDept.Name = "m_txtDept";
			this.m_txtDept.Size = new System.Drawing.Size(120, 23);
			this.m_txtDept.TabIndex = 9;
			this.m_txtDept.Text = "";
			this.m_txtDept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtDept_KeyDown);
			this.m_txtDept.TextChanged += new System.EventHandler(this.m_txtDept_TextChanged);
			this.m_txtDept.Leave += new System.EventHandler(this.m_txtDept_Leave);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.Location = new System.Drawing.Point(232, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 16);
			this.label1.TabIndex = 10;
			this.label1.Text = "选择部门:";
			// 
			// m_pnlDept
			// 
			this.m_pnlDept.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_pnlDept.Controls.Add(this.m_lsvSelectDept);
			this.m_pnlDept.Location = new System.Drawing.Point(-176, 304);
			this.m_pnlDept.Name = "m_pnlDept";
			this.m_pnlDept.Size = new System.Drawing.Size(184, 184);
			this.m_pnlDept.TabIndex = 40;
			this.m_pnlDept.Visible = false;
			// 
			// m_lsvSelectDept
			// 
			this.m_lsvSelectDept.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_lsvSelectDept.FullRowSelect = true;
			this.m_lsvSelectDept.GridLines = true;
			this.m_lsvSelectDept.HideSelection = false;
			this.m_lsvSelectDept.Location = new System.Drawing.Point(0, 0);
			this.m_lsvSelectDept.MultiSelect = false;
			this.m_lsvSelectDept.Name = "m_lsvSelectDept";
			this.m_lsvSelectDept.Size = new System.Drawing.Size(184, 184);
			this.m_lsvSelectDept.TabIndex = 3;
			this.m_lsvSelectDept.TabStop = false;
			this.m_lsvSelectDept.View = System.Windows.Forms.View.Details;
			this.m_lsvSelectDept.DoubleClick += new System.EventHandler(this.m_lsvSelectDept_DoubleClick);
			// 
			// m_btnSaveDept
			// 
			this.m_btnSaveDept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_btnSaveDept.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnSaveDept.DefaultScheme = true;
			this.m_btnSaveDept.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnSaveDept.Hint = "";
			this.m_btnSaveDept.Location = new System.Drawing.Point(8, 10);
			this.m_btnSaveDept.Name = "m_btnSaveDept";
			this.m_btnSaveDept.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnSaveDept.Size = new System.Drawing.Size(104, 32);
			this.m_btnSaveDept.TabIndex = 41;
			this.m_btnSaveDept.Text = "增加部门(F4)";
			this.m_btnSaveDept.Click += new System.EventHandler(this.m_btnSaveDept_Click);
			// 
			// m_btnDeleteDept
			// 
			this.m_btnDeleteDept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_btnDeleteDept.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnDeleteDept.DefaultScheme = true;
			this.m_btnDeleteDept.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnDeleteDept.Hint = "";
			this.m_btnDeleteDept.Location = new System.Drawing.Point(120, 10);
			this.m_btnDeleteDept.Name = "m_btnDeleteDept";
			this.m_btnDeleteDept.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnDeleteDept.Size = new System.Drawing.Size(104, 32);
			this.m_btnDeleteDept.TabIndex = 42;
			this.m_btnDeleteDept.Text = "删除部门(F5)";
			this.m_btnDeleteDept.Click += new System.EventHandler(this.m_btnDeleteDept_Click);
			// 
			// m_pnlCharge
			// 
			this.m_pnlCharge.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_pnlCharge.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.m_pnlCharge.Controls.Add(this.listView3);
			this.m_pnlCharge.Controls.Add(this.listView2);
			this.m_pnlCharge.Controls.Add(this.splitter1);
			this.m_pnlCharge.Controls.Add(this.m_lsvCharge);
			this.m_pnlCharge.Controls.Add(this.m_dtgConcertrecipeDetail);
			this.m_pnlCharge.Location = new System.Drawing.Point(392, 8);
			this.m_pnlCharge.Name = "m_pnlCharge";
			this.m_pnlCharge.Size = new System.Drawing.Size(592, 456);
			this.m_pnlCharge.TabIndex = 43;
			// 
			// listView3
			// 
			this.listView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader14,
																						this.columnHeader15,
																						this.columnHeader16,
																						this.columnHeader17,
																						this.columnHeader18});
			this.listView3.FullRowSelect = true;
			this.listView3.GridLines = true;
			this.listView3.Location = new System.Drawing.Point(258, 162);
			this.listView3.MultiSelect = false;
			this.listView3.Name = "listView3";
			this.listView3.Size = new System.Drawing.Size(184, 128);
			this.listView3.TabIndex = 37;
			this.listView3.View = System.Windows.Forms.View.Details;
			this.listView3.Visible = false;
			this.listView3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView3_KeyDown);
			this.listView3.DoubleClick += new System.EventHandler(this.listView3_DoubleClick);
			this.listView3.Leave += new System.EventHandler(this.listView3_Leave);
			// 
			// columnHeader14
			// 
			this.columnHeader14.Text = "频率ID";
			this.columnHeader14.Width = 0;
			// 
			// columnHeader15
			// 
			this.columnHeader15.Text = "助记码";
			// 
			// columnHeader16
			// 
			this.columnHeader16.Text = "名称";
			this.columnHeader16.Width = 120;
			// 
			// columnHeader17
			// 
			this.columnHeader17.Text = "次数";
			this.columnHeader17.Width = 0;
			// 
			// columnHeader18
			// 
			this.columnHeader18.Text = "天数";
			this.columnHeader18.Width = 0;
			// 
			// listView2
			// 
			this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader8,
																						this.columnHeader9,
																						this.columnHeader11});
			this.listView2.FullRowSelect = true;
			this.listView2.GridLines = true;
			this.listView2.Location = new System.Drawing.Point(42, 162);
			this.listView2.MultiSelect = false;
			this.listView2.Name = "listView2";
			this.listView2.Size = new System.Drawing.Size(184, 128);
			this.listView2.TabIndex = 36;
			this.listView2.View = System.Windows.Forms.View.Details;
			this.listView2.Visible = false;
			this.listView2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView2_KeyDown);
			this.listView2.DoubleClick += new System.EventHandler(this.listView2_DoubleClick);
			this.listView2.Leave += new System.EventHandler(this.listView2_Leave);
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "频率ID";
			this.columnHeader8.Width = 0;
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "助记码";
			// 
			// columnHeader11
			// 
			this.columnHeader11.Text = "名称";
			this.columnHeader11.Width = 120;
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splitter1.Location = new System.Drawing.Point(0, 451);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(588, 1);
			this.splitter1.TabIndex = 4;
			this.splitter1.TabStop = false;
			// 
			// m_lsvCharge
			// 
			this.m_lsvCharge.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						  this.columnHeader1,
																						  this.columnHeader2,
																						  this.columnHeader3,
																						  this.columnHeader4,
																						  this.columnHeader5,
																						  this.columnHeader6,
																						  this.columnHeader7});
			this.m_lsvCharge.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.m_lsvCharge.FullRowSelect = true;
			this.m_lsvCharge.GridLines = true;
			this.m_lsvCharge.HideSelection = false;
			this.m_lsvCharge.Location = new System.Drawing.Point(0, 452);
			this.m_lsvCharge.MultiSelect = false;
			this.m_lsvCharge.Name = "m_lsvCharge";
			this.m_lsvCharge.Size = new System.Drawing.Size(588, 0);
			this.m_lsvCharge.TabIndex = 3;
			this.m_lsvCharge.TabStop = false;
			this.m_lsvCharge.View = System.Windows.Forms.View.Details;
			this.m_lsvCharge.Visible = false;
			this.m_lsvCharge.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_lsvCharge_KeyDown);
			this.m_lsvCharge.DoubleClick += new System.EventHandler(this.m_lsvCharge_DoubleClick);
			this.m_lsvCharge.Leave += new System.EventHandler(this.m_lsvCharge_Leave);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "项目ID";
			this.columnHeader1.Width = 0;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "";
			this.columnHeader2.Width = 67;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "项目名称";
			this.columnHeader3.Width = 136;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "类型";
			this.columnHeader4.Width = 45;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "规格";
			this.columnHeader5.Width = 139;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "单位";
			this.columnHeader6.Width = 42;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "单价";
			// 
			// m_cmbFind
			// 
			this.m_cmbFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_cmbFind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cmbFind.Font = new System.Drawing.Font("宋体", 11F);
			this.m_cmbFind.Items.AddRange(new object[] {
														   "编号",
														   "药品名称",
														   "拼音码",
														   "五笔码",
														   "英文名"});
			this.m_cmbFind.Location = new System.Drawing.Point(704, 13);
			this.m_cmbFind.Name = "m_cmbFind";
			this.m_cmbFind.Size = new System.Drawing.Size(120, 23);
			this.m_cmbFind.TabIndex = 44;
			this.m_cmbFind.SelectedIndexChanged += new System.EventHandler(this.m_cmbFind_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(664, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 19);
			this.label2.TabIndex = 45;
			this.label2.Text = "查询:";
			// 
			// m_lblP
			// 
			this.m_lblP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lblP.AutoSize = true;
			this.m_lblP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lblP.ForeColor = System.Drawing.Color.Red;
			this.m_lblP.Location = new System.Drawing.Point(840, 488);
			this.m_lblP.Name = "m_lblP";
			this.m_lblP.Size = new System.Drawing.Size(0, 19);
			this.m_lblP.TabIndex = 46;
			// 
			// m_lblUser
			// 
			this.m_lblUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_lblUser.ForeColor = System.Drawing.Color.Red;
			this.m_lblUser.Location = new System.Drawing.Point(240, 264);
			this.m_lblUser.Name = "m_lblUser";
			this.m_lblUser.Size = new System.Drawing.Size(152, 23);
			this.m_lblUser.TabIndex = 47;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.m_btndeleteDetail);
			this.panel1.Controls.Add(this.m_cmbFind);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.m_btnSaveDetail);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.m_txtDept);
			this.panel1.Controls.Add(this.m_btnSaveDept);
			this.panel1.Controls.Add(this.m_btnDeleteDept);
			this.panel1.Location = new System.Drawing.Point(8, 472);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(976, 56);
			this.panel1.TabIndex = 48;
			// 
			// frmConcertrecipe
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(992, 533);
			this.Controls.Add(this.m_lblP);
			this.Controls.Add(this.m_pnlDept);
			this.Controls.Add(this.m_lblUser);
			this.Controls.Add(this.m_btnDeleteConcertrecipe);
			this.Controls.Add(this.m_btnSaveConcertrecipe);
			this.Controls.Add(this.m_pnlCharge);
			this.Controls.Add(this.m_lsvDept);
			this.Controls.Add(this.m_dtgConcertrecipe);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("宋体", 10.5F);
			this.Name = "frmConcertrecipe";
			this.Text = "协定处方维护";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmConcertrecipe_KeyDown);
			this.Load += new System.EventHandler(this.frmConcertrecipe_Load);
			((System.ComponentModel.ISupportInitialize)(this.m_dtgConcertrecipe)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.m_dtgConcertrecipeDetail)).EndInit();
			this.m_pnlDept.ResumeLayout(false);
			this.m_pnlCharge.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void CreateController()
		{
			this.objController = new com.digitalwave.iCare.gui.HIS.clsControlConcertreCipe();
			this.objController.Set_GUI_Apperance(this);
		}

		private void m_btnSaveConcertrecipe_Click(object sender, System.EventArgs e)
		{
			((clsControlConcertreCipe)this.objController).m_lngAddNewConcertreCipe();
			((clsControlConcertreCipe)this.objController).m_lngConcertreCipeModify();
		}

		private void m_btnDeleteConcertrecipe_Click(object sender, System.EventArgs e)
		{
			((clsControlConcertreCipe)this.objController).m_lngDeleteConcertrecipe();
		}

		private void m_btnSaveDept_Click(object sender, System.EventArgs e)
		{
			((clsControlConcertreCipe)this.objController).m_lngAddNewConcertreCipe();
			((clsControlConcertreCipe)this.objController).m_lngConcertreCipeModify();
			((clsControlConcertreCipe)this.objController).m_lngAddNewConcertreCipeDept();
		}

		private void m_btnDeleteDept_Click(object sender, System.EventArgs e)
		{
			((clsControlConcertreCipe)this.objController).m_lngDeleteConcertrecipeDept();
		}

		private void m_btnSaveDetail_Click(object sender, System.EventArgs e)
		{
			((clsControlConcertreCipe)this.objController).m_lngAddNewConcertreCipe();
			((clsControlConcertreCipe)this.objController).m_lngConcertreCipeModify();
			((clsControlConcertreCipe)this.objController).m_lngAddNewConcertreCipeDetail();
			((clsControlConcertreCipe)this.objController).m_lngConcertreCipeDetailModify();
		}

		private void m_btndeleteDetail_Click(object sender, System.EventArgs e)
		{
			((clsControlConcertreCipe)this.objController).m_lngDeleteConcertrecipeDetail();
		}

		private void m_txtDept_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				((clsControlConcertreCipe)this.objController).m_txtDeptKeyDown(sender);
			}
			if(e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
			{
				((clsControlConcertreCipe)this.objController).m_locklsv(e);
				
			}
		}

		private void m_txtDept_Leave(object sender, System.EventArgs e)
		{
			try
			{
				if(this.ActiveControl.Name != "m_lsvSelectDept")
					this.m_pnlDept.Visible = false;			
				
			}
			catch{}
		}

		private void m_txtDept_TextChanged(object sender, System.EventArgs e)
		{
			if(((TextBox)sender).Text == "")
			{
				((TextBox)sender).Tag = "";
			}
		}

		private void m_dtgConcertrecipe_m_evtCurrentCellChanged(object sender, System.EventArgs e)
		{
			((clsControlConcertreCipe)this.objController).m_dtgConcertrecipe_m_evtCurrentCellChanged(sender,e);
		}

		private void m_dtgConcertrecipe_m_evtDataGridTextBoxKeyDown(object sender, com.digitalwave.controls.datagrid.clsDGTextKeyEventArgs e)
		{
			
			if(e.m_intColNumber == 1 && e.KeyCode == Keys.Enter)
			{
				for(int i=0;i<this.m_dtgConcertrecipe.RowCount;i++)
				{
					if(m_dtgConcertrecipe[i,1].ToString().Trim()==e.m_strText.Trim()
						&& e.m_intRowNumber != i)
					{
						MessageBox.Show("该名称已经存在!","提示");
						this.m_dtgConcertrecipe[e.m_intRowNumber,1] = "";
						return;
					}
				}
				this.m_dtgConcertrecipe.CurrentCell = new DataGridCell(e.m_intRowNumber,2);
				com.digitalwave.Utility.clsCreateChinaCode Ccode = new com.digitalwave.Utility.clsCreateChinaCode();
				try
				{
					string wb = Ccode.m_strCreateChinaCode(e.m_strText,ChinaCode.WB);
					string py = Ccode.m_strCreateChinaCode(e.m_strText,ChinaCode.PY);
					this.m_dtgConcertrecipe[e.m_intRowNumber,4]=wb;
					this.m_dtgConcertrecipe[e.m_intRowNumber,5]=py;
				}
				catch{}
				this.m_dtgConcertrecipe[e.m_intRowNumber,6]=this.LoginInfo.m_strEmpID;
				this.m_dtgConcertrecipe[e.m_intRowNumber,7]=this.LoginInfo.m_strEmpName;
			}
			if(e.m_intColNumber == 3 && e.KeyCode == Keys.Enter)
			{
				if(this.m_dtgConcertrecipe[e.m_intRowNumber,1].ToString().Trim() != ""
					&& this.m_dtgConcertrecipe[e.m_intRowNumber,2].ToString().Trim() != "")
				{
					this.m_dtgConcertrecipe.AllowAddNew = true;
					this.m_dtgConcertrecipe.CurrentCell = new DataGridCell(e.m_intRowNumber+1,1);
				}
				else
				{
					this.m_dtgConcertrecipe.AllowAddNew = false;
					this.m_dtgConcertrecipe.CurrentCell = new DataGridCell(e.m_intRowNumber,e.m_intColNumber);
				}
			}
			if(e.m_intColNumber == 2 && e.KeyCode == Keys.Enter)
			{
				this.m_dtgConcertrecipe.CurrentCell = new DataGridCell(e.m_intRowNumber,3);
				com.digitalwave.Utility.clsCreateChinaCode Ccode = new com.digitalwave.Utility.clsCreateChinaCode();
				try
				{
					if(((com.digitalwave.controls.datagrid.clsColumnInfo)this.m_dtgConcertrecipe.Columns[2]).ReadOnly == false)
					{
						switch(e.m_strText)
						{
							case "0":
							case "公用":
								this.m_dtgConcertrecipe[e.m_intRowNumber,2]="公用";
								break;
							case "1":
							case "私用":
								this.m_dtgConcertrecipe[e.m_intRowNumber,2]="私用";
								break;
							case "科室":
							case "2":
								this.m_dtgConcertrecipe[e.m_intRowNumber,2]="科室";
								break;
							default:
								this.m_dtgConcertrecipe[e.m_intRowNumber,2]="私用";
								break;
						}

					}
					
					//this.m_dtgConcertrecipe[e.m_intRowNumber,2]=wb;					
				}
				catch{}
			}
			
		}

		private void m_dtgConcertrecipeDetail_m_evtDataGridTextBoxKeyDown(object sender, com.digitalwave.controls.datagrid.clsDGTextKeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter&&e.m_intColNumber==8)//用法
			{
				if(((clsControlConcertreCipe)this.objController).m_mthFindUsage(e.m_strText,e.m_intRowNumber)>0)
				{
					this.listView2.Location=e.m_ptPositionInDataGrid;
					this.listView2.Top+=e.m_szTextBoxSize.Height;
					this.listView2.Show();
					this.listView2.BringToFront();
					this.listView2.Items[0].Selected=true;
					this.listView2.Select();
					this.listView2.Focus();
				}
			return;
			}
			if(e.KeyCode==Keys.Enter&&e.m_intColNumber==10)//频率
			{
				if(((clsControlConcertreCipe)this.objController).m_mthFindFrequency(e.m_strText,e.m_intRowNumber)>0)
				{
					this.listView3.Location=e.m_ptPositionInDataGrid;
					this.listView3.Top+=e.m_szTextBoxSize.Height;
					this.listView3.Show();
					this.listView3.BringToFront();
					this.listView3.Items[0].Selected=true;
					this.listView3.Select();
					this.listView3.Focus();
				}
			return;
			}
			if(e.KeyCode == Keys.Enter && e.m_intColNumber == 3)
			{
				((clsControlConcertreCipe)this.objController).m_mthFindMedicineByID(m_cmbFind.Tag.ToString().Trim(),e.m_strText);
			}
			if(e.m_intColNumber == 4)
			{
				if(e.KeyCode == Keys.D0 ||
					e.KeyCode == Keys.D1 ||
					e.KeyCode == Keys.D2 ||
					e.KeyCode == Keys.D3 ||
					e.KeyCode == Keys.D4 ||
					e.KeyCode == Keys.D5 ||
					e.KeyCode == Keys.D6 ||
					e.KeyCode == Keys.D7 ||
					e.KeyCode == Keys.D8 ||
					e.KeyCode == Keys.D9 ||
					e.KeyCode == Keys.NumPad0 ||
					e.KeyCode == Keys.NumPad1 ||
					e.KeyCode == Keys.NumPad2 ||
					e.KeyCode == Keys.NumPad3 ||
					e.KeyCode == Keys.NumPad4 ||
					e.KeyCode == Keys.NumPad5 ||
					e.KeyCode == Keys.NumPad6 ||
					e.KeyCode == Keys.NumPad7 ||
					e.KeyCode == Keys.NumPad8 ||
					e.KeyCode == Keys.NumPad9 ||
					e.KeyCode == Keys.Decimal ||
					e.KeyCode == Keys.OemPeriod ||
					e.KeyCode == Keys.Back ||
					e.KeyCode == Keys.Delete)
				{
					if((e.KeyCode == Keys.Decimal ||
						e.KeyCode == Keys.OemPeriod) && e.m_strText.IndexOf(".")>=0)
					{
						((clsColumnInfo)this.m_dtgConcertrecipeDetail.Columns[e.m_intColNumber]).DataGridTextBoxColumn.TextBox.ReadOnly = true;
						return;
					}
				
					((clsColumnInfo)this.m_dtgConcertrecipeDetail.Columns[e.m_intColNumber]).DataGridTextBoxColumn.TextBox.ReadOnly = false;
				}
				else
				{
					((clsColumnInfo)this.m_dtgConcertrecipeDetail.Columns[e.m_intColNumber]).DataGridTextBoxColumn.TextBox.ReadOnly = true;
				}
				
				if(e.KeyCode == Keys.Enter)
				{
					this.m_dtgConcertrecipeDetail.AllowAddNew = false;	
					if(this.m_dtgConcertrecipeDetail[e.m_intRowNumber,3].ToString().Trim() == ""
						|| this.m_dtgConcertrecipeDetail[e.m_intRowNumber,4].ToString().Trim() == "")
					{
						this.m_dtgConcertrecipeDetail.CurrentCell = new DataGridCell(e.m_intRowNumber,4);
					}
					else
					{					
						this.m_dtgConcertrecipeDetail.AllowAddNew = true;
						this.m_dtgConcertrecipeDetail[e.m_intRowNumber,13] = float.Parse(e.m_strText)*float.Parse(this.m_dtgConcertrecipeDetail[e.m_intRowNumber,12].ToString());
						((clsControlConcertreCipe)this.objController).m_sumMoney();
//						this.m_dtgConcertrecipeDetail.CurrentCell = new DataGridCell(e.m_intRowNumber+1,3);
						this.m_dtgConcertrecipeDetail.CurrentCell = new DataGridCell(e.m_intRowNumber,8);
					}
				}
			}
		}

		private void m_cmbFind_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			switch(m_cmbFind.SelectedIndex)
			{
				case 0://项目编码
					m_cmbFind.Tag="ITEMCODE_VCHR";
					break;
				case 1://项目名称
					m_cmbFind.Tag="ITEMNAME_VCHR";
					break;
				case 2://项目拼音
					m_cmbFind.Tag="ITEMPYCODE_CHR";
					break;
				case 3://项目五笔
					m_cmbFind.Tag="ITEMWBCODE_CHR";
					break;
				case 4:
					m_cmbFind.Tag="ITEMENGNAME_VCHR";
					break;
			}
		}

		private void m_dtgConcertrecipeDetail_m_evtDataGridKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch(e.KeyCode)
			{
				case Keys.F2:
					this.m_btnSaveConcertrecipe_Click(null,null);
					break;
				case Keys.F3:
					this.m_btnDeleteConcertrecipe_Click(null,null);
					break;
				case Keys.F4:
					this.m_btnSaveDept_Click(null,null);
					break;
				case Keys.F5:
					this.m_btnDeleteDept_Click(null,null);
					break;
				case Keys.F6:
					this.m_btnSaveDetail_Click(null,null);
					break;
				case Keys.F7:
					this.m_btndeleteDetail_Click(null,null);
					break;
			}
		}

		private void frmConcertrecipe_Load(object sender, System.EventArgs e)
		{
			this.m_dtgConcertrecipeDetail.m_mthAddEnterToSpaceColumn(3);
			this.m_dtgConcertrecipeDetail.m_mthAddEnterToSpaceColumn(4);
			this.m_dtgConcertrecipeDetail.m_mthAddEnterToSpaceColumn(8);
			this.m_dtgConcertrecipeDetail.m_mthAddEnterToSpaceColumn(10);
			this.m_dtgConcertrecipe.m_mthAddEnterToSpaceColumn(1);
			this.m_dtgConcertrecipe.m_mthAddEnterToSpaceColumn(2);
			this.m_dtgConcertrecipe.m_mthAddEnterToSpaceColumn(3);
			m_cmbFind.SelectedIndex = 0;
			((clsControlConcertreCipe)this.objController).m_ClearCipe();
			((clsControlConcertreCipe)this.objController).m_ClearDept();
			((clsControlConcertreCipe)this.objController).m_ClearDetail();
			((clsControlConcertreCipe)this.objController).m_lngGetConcertreCipeByEmpID();
			((clsControlConcertreCipe)this.objController).m_lngGetConcertreCipeDeptByID();
			((clsControlConcertreCipe)this.objController).m_lngGetConcertreCipeDetailByID();
		}

		private void m_lsvCharge_DoubleClick(object sender, System.EventArgs e)
		{
			((clsControlConcertreCipe)this.objController).m_mthListViewDoubleClick();
		}

		private void m_lsvCharge_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			((clsControlConcertreCipe)this.objController).m_mthListViewDoubleClick();
		}

		private void m_dtgConcertrecipe_m_evtDataGridTextBoxKeyPress(object sender, com.digitalwave.controls.datagrid.clsDGTextKeyPressEventArgs e)
		{
			if(this.m_dtgConcertrecipe[e.m_intRowNumber,0] != Convert.DBNull && e.KeyChar != (char)13)
			{
				((clsControlConcertreCipe)this.objController).m_Modefy("0");
			}
		}

		private void m_dtgConcertrecipeDetail_m_evtDataGridTextBoxKeyPress(object sender, com.digitalwave.controls.datagrid.clsDGTextKeyPressEventArgs e)
		{
			if(this.m_dtgConcertrecipeDetail[e.m_intRowNumber,0] != Convert.DBNull && e.KeyChar != (char)13)
			{
				((clsControlConcertreCipe)this.objController).m_Modefy("1");
			}
		}

		

		private void m_dtgConcertrecipe_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				this.m_dtgConcertrecipe_m_evtCurrentCellChanged(null,null);
			}
			catch{}
		}

		private void m_dtgConcertrecipe_Enter(object sender, System.EventArgs e)
		{
			this.m_dtgConcertrecipe_m_evtCurrentCellChanged(null,null);
		}

		private void frmConcertrecipe_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch(e.KeyCode)
			{
				case Keys.F2:
					this.m_btnSaveConcertrecipe_Click(null,null);
					break;
				case Keys.F3:
					this.m_btnDeleteConcertrecipe_Click(null,null);
					break;
				case Keys.F4:
					this.m_btnSaveDept_Click(null,null);
					break;
				case Keys.F5:
					this.m_btnDeleteDept_Click(null,null);
					break;
				case Keys.F6:
					this.m_btnSaveDetail_Click(null,null);
					break;
				case Keys.F7:
					this.m_btndeleteDetail_Click(null,null);
					break;
			}
		}

		private void m_lsvSelectDept_DoubleClick(object sender, System.EventArgs e)
		{
			((clsControlConcertreCipe)this.objController).m_txtDeptKeyDown((object)this.m_txtDept);
		}

		private void listView2_Leave(object sender, System.EventArgs e)
		{
		this.listView2.Hide();
		}

		private void listView3_Leave(object sender, System.EventArgs e)
		{
		this.listView3.Hide();
		}

		private void listView2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
		((clsControlConcertreCipe)this.objController).m_mthListViewKeyDown2(e);
		}

		private void listView3_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
		((clsControlConcertreCipe)this.objController).m_mthListViewKeyDown3(e);
		}

		private void listView2_DoubleClick(object sender, System.EventArgs e)
		{
		((clsControlConcertreCipe)this.objController).m_mthListViewDoubleClick2();
		}

		private void listView3_DoubleClick(object sender, System.EventArgs e)
		{
		((clsControlConcertreCipe)this.objController).m_mthListViewDoubleClick3();
		}

		private void m_lsvCharge_Leave(object sender, System.EventArgs e)
		{
			this.m_lsvCharge.Items.Clear();
			this.m_lsvCharge.Height=0;
			this.m_lsvCharge.Visible=false;
		}
	}
}
