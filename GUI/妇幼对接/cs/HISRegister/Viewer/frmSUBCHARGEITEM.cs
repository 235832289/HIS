using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Data;
using com.digitalwave.iCare.ValueObject;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmSUBCHARGEITEM 的摘要说明。
	/// </summary>
	public class frmSUBCHARGEITEM  : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
        private com.digitalwave.controls.datagrid2.ctlDataGrid ctlDataGrid1;
        internal PinkieControls.ButtonXP m_btndeleteDetail;
        internal PinkieControls.ButtonXP m_cmdSynOrderDic;
		private PinkieControls.ButtonXP m_cmdClose;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ListView listView2;
		private System.Windows.Forms.ColumnHeader 助记码;
		private System.Windows.Forms.ColumnHeader columnHeader12;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.ColumnHeader columnHeader13;
        private ListView lsvCope;
        private ColumnHeader columnHeader14;
        internal PinkieControls.ButtonXP buttonXP1;
        private ColumnHeader columnHeader15;
        private ColumnHeader columnHeader16;
        private ListView m_lsvContinueType;
        private ColumnHeader columnHeader17;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
	
		public frmSUBCHARGEITEM(string ChargeitemID,string ChargeitemName)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			strItemID=ChargeitemID;
			this.Text="编辑收费项目"+ChargeitemName+"的关联项";
            m_strItemName = ChargeitemName;
		}
        /// <summary>
        /// 项目名称
        /// </summary>
        private string m_strItemName = "";
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
            com.digitalwave.controls.datagrid2.clsColumnInfo clsColumnInfo1 = new com.digitalwave.controls.datagrid2.clsColumnInfo();
            com.digitalwave.controls.datagrid2.clsColumnInfo clsColumnInfo2 = new com.digitalwave.controls.datagrid2.clsColumnInfo();
            com.digitalwave.controls.datagrid2.clsColumnInfo clsColumnInfo3 = new com.digitalwave.controls.datagrid2.clsColumnInfo();
            com.digitalwave.controls.datagrid2.clsColumnInfo clsColumnInfo4 = new com.digitalwave.controls.datagrid2.clsColumnInfo();
            com.digitalwave.controls.datagrid2.clsColumnInfo clsColumnInfo5 = new com.digitalwave.controls.datagrid2.clsColumnInfo();
            com.digitalwave.controls.datagrid2.clsColumnInfo clsColumnInfo6 = new com.digitalwave.controls.datagrid2.clsColumnInfo();
            com.digitalwave.controls.datagrid2.clsColumnInfo clsColumnInfo7 = new com.digitalwave.controls.datagrid2.clsColumnInfo();
            com.digitalwave.controls.datagrid2.clsColumnInfo clsColumnInfo8 = new com.digitalwave.controls.datagrid2.clsColumnInfo();
            com.digitalwave.controls.datagrid2.clsColumnInfo clsColumnInfo9 = new com.digitalwave.controls.datagrid2.clsColumnInfo();
            com.digitalwave.controls.datagrid2.clsColumnInfo clsColumnInfo10 = new com.digitalwave.controls.datagrid2.clsColumnInfo();
            com.digitalwave.controls.datagrid2.clsColumnInfo clsColumnInfo11 = new com.digitalwave.controls.datagrid2.clsColumnInfo();
            com.digitalwave.controls.datagrid2.clsColumnInfo clsColumnInfo12 = new com.digitalwave.controls.datagrid2.clsColumnInfo();
            com.digitalwave.controls.datagrid2.clsColumnInfo clsColumnInfo13 = new com.digitalwave.controls.datagrid2.clsColumnInfo();
            com.digitalwave.controls.datagrid2.clsColumnInfo clsColumnInfo14 = new com.digitalwave.controls.datagrid2.clsColumnInfo();
            com.digitalwave.controls.datagrid2.clsColumnInfo clsColumnInfo15 = new com.digitalwave.controls.datagrid2.clsColumnInfo();
            com.digitalwave.controls.datagrid2.clsColumnInfo clsColumnInfo16 = new com.digitalwave.controls.datagrid2.clsColumnInfo();
            com.digitalwave.controls.datagrid2.clsColumnInfo clsColumnInfo17 = new com.digitalwave.controls.datagrid2.clsColumnInfo();
            com.digitalwave.controls.datagrid2.clsColumnInfo clsColumnInfo18 = new com.digitalwave.controls.datagrid2.clsColumnInfo();
            com.digitalwave.controls.datagrid2.clsColumnInfo clsColumnInfo19 = new com.digitalwave.controls.datagrid2.clsColumnInfo();
            com.digitalwave.controls.datagrid2.clsColumnInfo clsColumnInfo20 = new com.digitalwave.controls.datagrid2.clsColumnInfo();
            com.digitalwave.controls.datagrid2.clsColumnInfo clsColumnInfo21 = new com.digitalwave.controls.datagrid2.clsColumnInfo();
            com.digitalwave.controls.datagrid2.clsColumnInfo clsColumnInfo22 = new com.digitalwave.controls.datagrid2.clsColumnInfo();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("连续用");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("首次用");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("主项目");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("所有主项目");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSUBCHARGEITEM));
            this.ctlDataGrid1 = new com.digitalwave.controls.datagrid2.ctlDataGrid();
            this.m_btndeleteDetail = new PinkieControls.ButtonXP();
            this.m_cmdSynOrderDic = new PinkieControls.ButtonXP();
            this.m_cmdClose = new PinkieControls.ButtonXP();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonXP1 = new PinkieControls.ButtonXP();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_lsvContinueType = new System.Windows.Forms.ListView();
            this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
            this.lsvCope = new System.Windows.Forms.ListView();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
            this.listView2 = new System.Windows.Forms.ListView();
            this.助记码 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDataGrid1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctlDataGrid1
            // 
            this.ctlDataGrid1.AllowAddNew = true;
            this.ctlDataGrid1.AllowDelete = false;
            this.ctlDataGrid1.AutoAppendRow = true;
            this.ctlDataGrid1.AutoScroll = true;
            this.ctlDataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.ctlDataGrid1.CaptionText = "";
            this.ctlDataGrid1.CaptionVisible = false;
            this.ctlDataGrid1.ColumnHeadersVisible = true;
            clsColumnInfo1.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo1.BackColor = System.Drawing.Color.White;
            clsColumnInfo1.Column_Type = com.digitalwave.controls.datagrid2.enum_DataType.System_String;
            clsColumnInfo1.ColumnIndex = 0;
            clsColumnInfo1.ColumnName = "ITEMCODE_VCHR";
            clsColumnInfo1.ColumnWidth = 75;
            clsColumnInfo1.Enabled = true;
            clsColumnInfo1.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo1.HeadText = "查询";
            clsColumnInfo1.ReadOnly = false;
            clsColumnInfo1.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo2.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo2.BackColor = System.Drawing.Color.White;
            clsColumnInfo2.Column_Type = com.digitalwave.controls.datagrid2.enum_DataType.System_String;
            clsColumnInfo2.ColumnIndex = 1;
            clsColumnInfo2.ColumnName = "ITEMNAME_VCHR";
            clsColumnInfo2.ColumnWidth = 75;
            clsColumnInfo2.Enabled = false;
            clsColumnInfo2.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo2.HeadText = "项目名称";
            clsColumnInfo2.ReadOnly = true;
            clsColumnInfo2.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo3.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo3.BackColor = System.Drawing.Color.White;
            clsColumnInfo3.Column_Type = com.digitalwave.controls.datagrid2.enum_DataType.System_String;
            clsColumnInfo3.ColumnIndex = 2;
            clsColumnInfo3.ColumnName = "ITEMSPEC_VCHR";
            clsColumnInfo3.ColumnWidth = 100;
            clsColumnInfo3.Enabled = false;
            clsColumnInfo3.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo3.HeadText = "项目规格";
            clsColumnInfo3.ReadOnly = true;
            clsColumnInfo3.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo4.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo4.BackColor = System.Drawing.Color.White;
            clsColumnInfo4.Column_Type = com.digitalwave.controls.datagrid2.enum_DataType.System_String;
            clsColumnInfo4.ColumnIndex = 3;
            clsColumnInfo4.ColumnName = "usaQTY";
            clsColumnInfo4.ColumnWidth = 75;
            clsColumnInfo4.Enabled = true;
            clsColumnInfo4.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo4.HeadText = "用量";
            clsColumnInfo4.ReadOnly = false;
            clsColumnInfo4.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo5.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo5.BackColor = System.Drawing.Color.White;
            clsColumnInfo5.Column_Type = com.digitalwave.controls.datagrid2.enum_DataType.System_String;
            clsColumnInfo5.ColumnIndex = 4;
            clsColumnInfo5.ColumnName = "USAGENAME_VCHR";
            clsColumnInfo5.ColumnWidth = 75;
            clsColumnInfo5.Enabled = true;
            clsColumnInfo5.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo5.HeadText = "用法";
            clsColumnInfo5.ReadOnly = false;
            clsColumnInfo5.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo6.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo6.BackColor = System.Drawing.Color.White;
            clsColumnInfo6.Column_Type = com.digitalwave.controls.datagrid2.enum_DataType.System_String;
            clsColumnInfo6.ColumnIndex = 5;
            clsColumnInfo6.ColumnName = "FREQNAME_CHR";
            clsColumnInfo6.ColumnWidth = 75;
            clsColumnInfo6.Enabled = true;
            clsColumnInfo6.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo6.HeadText = "频率";
            clsColumnInfo6.ReadOnly = false;
            clsColumnInfo6.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo7.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo7.BackColor = System.Drawing.Color.White;
            clsColumnInfo7.Column_Type = com.digitalwave.controls.datagrid2.enum_DataType.System_String;
            clsColumnInfo7.ColumnIndex = 6;
            clsColumnInfo7.ColumnName = "DAYS_INT";
            clsColumnInfo7.ColumnWidth = 75;
            clsColumnInfo7.Enabled = true;
            clsColumnInfo7.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo7.HeadText = "天数";
            clsColumnInfo7.ReadOnly = false;
            clsColumnInfo7.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo8.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo8.BackColor = System.Drawing.Color.White;
            clsColumnInfo8.Column_Type = com.digitalwave.controls.datagrid2.enum_DataType.System_String;
            clsColumnInfo8.ColumnIndex = 7;
            clsColumnInfo8.ColumnName = "QTY_INT";
            clsColumnInfo8.ColumnWidth = 75;
            clsColumnInfo8.Enabled = true;
            clsColumnInfo8.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo8.HeadText = "数量";
            clsColumnInfo8.ReadOnly = false;
            clsColumnInfo8.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo9.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo9.BackColor = System.Drawing.Color.White;
            clsColumnInfo9.Column_Type = com.digitalwave.controls.datagrid2.enum_DataType.System_String;
            clsColumnInfo9.ColumnIndex = 8;
            clsColumnInfo9.ColumnName = "ITEMOPUNIT_CHR";
            clsColumnInfo9.ColumnWidth = 75;
            clsColumnInfo9.Enabled = false;
            clsColumnInfo9.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo9.HeadText = "单位";
            clsColumnInfo9.ReadOnly = true;
            clsColumnInfo9.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo10.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo10.BackColor = System.Drawing.Color.White;
            clsColumnInfo10.Column_Type = com.digitalwave.controls.datagrid2.enum_DataType.System_String;
            clsColumnInfo10.ColumnIndex = 9;
            clsColumnInfo10.ColumnName = "ITEMPRICE_MNY";
            clsColumnInfo10.ColumnWidth = 60;
            clsColumnInfo10.Enabled = false;
            clsColumnInfo10.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo10.HeadText = "单价";
            clsColumnInfo10.ReadOnly = true;
            clsColumnInfo10.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo11.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo11.BackColor = System.Drawing.Color.White;
            clsColumnInfo11.Column_Type = com.digitalwave.controls.datagrid2.enum_DataType.System_String;
            clsColumnInfo11.ColumnIndex = 10;
            clsColumnInfo11.ColumnName = "FREQID_CHR";
            clsColumnInfo11.ColumnWidth = 0;
            clsColumnInfo11.Enabled = false;
            clsColumnInfo11.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo11.HeadText = "FREQID_CHR";
            clsColumnInfo11.ReadOnly = true;
            clsColumnInfo11.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo12.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo12.BackColor = System.Drawing.Color.White;
            clsColumnInfo12.Column_Type = com.digitalwave.controls.datagrid2.enum_DataType.System_String;
            clsColumnInfo12.ColumnIndex = 11;
            clsColumnInfo12.ColumnName = "USAGEID_CHR";
            clsColumnInfo12.ColumnWidth = 0;
            clsColumnInfo12.Enabled = false;
            clsColumnInfo12.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo12.HeadText = "USAGEID_CHR";
            clsColumnInfo12.ReadOnly = true;
            clsColumnInfo12.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo13.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo13.BackColor = System.Drawing.Color.White;
            clsColumnInfo13.Column_Type = com.digitalwave.controls.datagrid2.enum_DataType.System_String;
            clsColumnInfo13.ColumnIndex = 12;
            clsColumnInfo13.ColumnName = "UpFlag";
            clsColumnInfo13.ColumnWidth = 0;
            clsColumnInfo13.Enabled = false;
            clsColumnInfo13.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo13.HeadText = "UpFlag";
            clsColumnInfo13.ReadOnly = true;
            clsColumnInfo13.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo14.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo14.BackColor = System.Drawing.Color.White;
            clsColumnInfo14.Column_Type = com.digitalwave.controls.datagrid2.enum_DataType.System_String;
            clsColumnInfo14.ColumnIndex = 13;
            clsColumnInfo14.ColumnName = "ITEMID_CHR";
            clsColumnInfo14.ColumnWidth = 0;
            clsColumnInfo14.Enabled = false;
            clsColumnInfo14.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo14.HeadText = "ITEMID_CHR";
            clsColumnInfo14.ReadOnly = true;
            clsColumnInfo14.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo15.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo15.BackColor = System.Drawing.Color.White;
            clsColumnInfo15.Column_Type = com.digitalwave.controls.datagrid2.enum_DataType.System_String;
            clsColumnInfo15.ColumnIndex = 14;
            clsColumnInfo15.ColumnName = "medicinetypeid_chr";
            clsColumnInfo15.ColumnWidth = 0;
            clsColumnInfo15.Enabled = false;
            clsColumnInfo15.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo15.HeadText = "medicinetypeid_chr";
            clsColumnInfo15.ReadOnly = true;
            clsColumnInfo15.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo16.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo16.BackColor = System.Drawing.Color.White;
            clsColumnInfo16.Column_Type = com.digitalwave.controls.datagrid2.enum_DataType.System_String;
            clsColumnInfo16.ColumnIndex = 15;
            clsColumnInfo16.ColumnName = "TIMES_INT";
            clsColumnInfo16.ColumnWidth = 0;
            clsColumnInfo16.Enabled = false;
            clsColumnInfo16.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo16.HeadText = "TIMES_INT";
            clsColumnInfo16.ReadOnly = true;
            clsColumnInfo16.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo17.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo17.BackColor = System.Drawing.Color.White;
            clsColumnInfo17.Column_Type = com.digitalwave.controls.datagrid2.enum_DataType.System_String;
            clsColumnInfo17.ColumnIndex = 16;
            clsColumnInfo17.ColumnName = "DAYS_INT1";
            clsColumnInfo17.ColumnWidth = 0;
            clsColumnInfo17.Enabled = false;
            clsColumnInfo17.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo17.HeadText = "DAYS_INT1";
            clsColumnInfo17.ReadOnly = true;
            clsColumnInfo17.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo18.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo18.BackColor = System.Drawing.Color.White;
            clsColumnInfo18.Column_Type = com.digitalwave.controls.datagrid2.enum_DataType.System_String;
            clsColumnInfo18.ColumnIndex = 17;
            clsColumnInfo18.ColumnName = "DOSAGE_DEC";
            clsColumnInfo18.ColumnWidth = 0;
            clsColumnInfo18.Enabled = false;
            clsColumnInfo18.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo18.HeadText = "剂量";
            clsColumnInfo18.ReadOnly = true;
            clsColumnInfo18.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo19.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo19.BackColor = System.Drawing.Color.White;
            clsColumnInfo19.Column_Type = com.digitalwave.controls.datagrid2.enum_DataType.System_String;
            clsColumnInfo19.ColumnIndex = 18;
            clsColumnInfo19.ColumnName = "IFSTOP_INT";
            clsColumnInfo19.ColumnWidth = 0;
            clsColumnInfo19.Enabled = false;
            clsColumnInfo19.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo19.HeadText = "IFSTOP_INT";
            clsColumnInfo19.ReadOnly = true;
            clsColumnInfo19.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo20.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo20.BackColor = System.Drawing.Color.White;
            clsColumnInfo20.Column_Type = com.digitalwave.controls.datagrid2.enum_DataType.System_String;
            clsColumnInfo20.ColumnIndex = 19;
            clsColumnInfo20.ColumnName = "CONTINUEUSETYPE_INT";
            clsColumnInfo20.ColumnWidth = 75;
            clsColumnInfo20.Enabled = true;
            clsColumnInfo20.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo20.HeadText = "续用类型";
            clsColumnInfo20.ReadOnly = true;
            clsColumnInfo20.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo21.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo21.BackColor = System.Drawing.Color.White;
            clsColumnInfo21.Column_Type = com.digitalwave.controls.datagrid2.enum_DataType.System_String;
            clsColumnInfo21.ColumnIndex = 20;
            clsColumnInfo21.ColumnName = "USESCOPE_INT";
            clsColumnInfo21.ColumnWidth = 75;
            clsColumnInfo21.Enabled = true;
            clsColumnInfo21.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo21.HeadText = "使用范围";
            clsColumnInfo21.ReadOnly = true;
            clsColumnInfo21.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo22.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo22.BackColor = System.Drawing.Color.White;
            clsColumnInfo22.Column_Type = com.digitalwave.controls.datagrid2.enum_DataType.System_String;
            clsColumnInfo22.ColumnIndex = 21;
            clsColumnInfo22.ColumnName = "newusescope_int";
            clsColumnInfo22.ColumnWidth = 0;
            clsColumnInfo22.Enabled = true;
            clsColumnInfo22.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo22.HeadText = "newusescope_int";
            clsColumnInfo22.ReadOnly = false;
            clsColumnInfo22.TextFont = new System.Drawing.Font("宋体", 10F);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo1);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo2);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo3);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo4);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo5);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo6);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo7);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo8);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo9);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo10);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo11);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo12);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo13);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo14);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo15);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo16);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo17);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo18);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo19);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo20);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo21);
            this.ctlDataGrid1.Columns.Add(clsColumnInfo22);
            this.ctlDataGrid1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctlDataGrid1.FullRowSelect = false;
            this.ctlDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.ctlDataGrid1.MultiSelect = false;
            this.ctlDataGrid1.Name = "ctlDataGrid1";
            this.ctlDataGrid1.ReadOnly = false;
            this.ctlDataGrid1.RowHeadersVisible = false;
            this.ctlDataGrid1.RowHeaderWidth = 35;
            this.ctlDataGrid1.SelectedRowBackColor = System.Drawing.Color.Purple;
            this.ctlDataGrid1.SelectedRowForeColor = System.Drawing.Color.White;
            this.ctlDataGrid1.Size = new System.Drawing.Size(843, 448);
            this.ctlDataGrid1.TabIndex = 0;
            this.ctlDataGrid1.m_evtDataGridTextBoxKeyDown += new com.digitalwave.controls.datagrid2.clsDGTextKeyEventHandler(this.ctlDataGrid1_m_evtDataGridTextBoxKeyDown);
            // 
            // m_btndeleteDetail
            // 
            this.m_btndeleteDetail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_btndeleteDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btndeleteDetail.DefaultScheme = true;
            this.m_btndeleteDetail.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btndeleteDetail.Hint = "";
            this.m_btndeleteDetail.Location = new System.Drawing.Point(13, 299);
            this.m_btndeleteDetail.Name = "m_btndeleteDetail";
            this.m_btndeleteDetail.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btndeleteDetail.Size = new System.Drawing.Size(112, 32);
            this.m_btndeleteDetail.TabIndex = 50;
            this.m_btndeleteDetail.Text = "删除(&D)";
            this.m_btndeleteDetail.Click += new System.EventHandler(this.m_btndeleteDetail_Click);
            // 
            // m_cmdSynOrderDic
            // 
            this.m_cmdSynOrderDic.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_cmdSynOrderDic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdSynOrderDic.DefaultScheme = true;
            this.m_cmdSynOrderDic.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSynOrderDic.Hint = "";
            this.m_cmdSynOrderDic.Location = new System.Drawing.Point(12, 186);
            this.m_cmdSynOrderDic.Name = "m_cmdSynOrderDic";
            this.m_cmdSynOrderDic.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSynOrderDic.Size = new System.Drawing.Size(112, 32);
            this.m_cmdSynOrderDic.TabIndex = 48;
            this.m_cmdSynOrderDic.Text = "保存(&S)";
            this.m_cmdSynOrderDic.Click += new System.EventHandler(this.m_cmdAddNew_Click);
            // 
            // m_cmdClose
            // 
            this.m_cmdClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdClose.DefaultScheme = true;
            this.m_cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdClose.Hint = "";
            this.m_cmdClose.Location = new System.Drawing.Point(13, 354);
            this.m_cmdClose.Name = "m_cmdClose";
            this.m_cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClose.Size = new System.Drawing.Size(112, 31);
            this.m_cmdClose.TabIndex = 49;
            this.m_cmdClose.Text = "关闭(Esc)";
            this.m_cmdClose.Click += new System.EventHandler(this.m_cmdClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonXP1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.m_cmdSynOrderDic);
            this.groupBox1.Controls.Add(this.m_btndeleteDetail);
            this.groupBox1.Controls.Add(this.m_cmdClose);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(849, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(137, 453);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // buttonXP1
            // 
            this.buttonXP1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonXP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP1.DefaultScheme = true;
            this.buttonXP1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP1.Hint = "";
            this.buttonXP1.Location = new System.Drawing.Point(13, 242);
            this.buttonXP1.Name = "buttonXP1";
            this.buttonXP1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP1.Size = new System.Drawing.Size(112, 32);
            this.buttonXP1.TabIndex = 53;
            this.buttonXP1.Text = "同步诊疗字典";
            this.buttonXP1.Click += new System.EventHandler(this.buttonXP1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Location = new System.Drawing.Point(8, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(128, 48);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查找方式";
            // 
            // comboBox1
            // 
            this.comboBox1.Items.AddRange(new object[] {
            "助记码",
            "项目名称",
            "拼音码",
            "五笔码"});
            this.comboBox1.Location = new System.Drawing.Point(8, 16);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(112, 22);
            this.comboBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 40);
            this.label1.TabIndex = 51;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_lsvContinueType);
            this.panel1.Controls.Add(this.lsvCope);
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Controls.Add(this.ctlDataGrid1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(843, 453);
            this.panel1.TabIndex = 0;
            // 
            // m_lsvContinueType
            // 
            this.m_lsvContinueType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lsvContinueType.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader17});
            this.m_lsvContinueType.FullRowSelect = true;
            this.m_lsvContinueType.GridLines = true;
            this.m_lsvContinueType.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.m_lsvContinueType.Location = new System.Drawing.Point(192, 136);
            this.m_lsvContinueType.MultiSelect = false;
            this.m_lsvContinueType.Name = "m_lsvContinueType";
            this.m_lsvContinueType.Size = new System.Drawing.Size(108, 52);
            this.m_lsvContinueType.TabIndex = 57;
            this.m_lsvContinueType.UseCompatibleStateImageBehavior = false;
            this.m_lsvContinueType.View = System.Windows.Forms.View.Details;
            this.m_lsvContinueType.Visible = false;
            this.m_lsvContinueType.DoubleClick += new System.EventHandler(this.m_lsvContinueType_DoubleClick);
            this.m_lsvContinueType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_lsvContinueType_KeyDown);
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "续用类型";
            this.columnHeader17.Width = 108;
            // 
            // lsvCope
            // 
            this.lsvCope.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lsvCope.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader14});
            this.lsvCope.FullRowSelect = true;
            this.lsvCope.GridLines = true;
            this.lsvCope.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem3,
            listViewItem4});
            this.lsvCope.Location = new System.Drawing.Point(366, 200);
            this.lsvCope.MultiSelect = false;
            this.lsvCope.Name = "lsvCope";
            this.lsvCope.Size = new System.Drawing.Size(110, 52);
            this.lsvCope.TabIndex = 56;
            this.lsvCope.UseCompatibleStateImageBehavior = false;
            this.lsvCope.View = System.Windows.Forms.View.Details;
            this.lsvCope.Visible = false;
            this.lsvCope.DoubleClick += new System.EventHandler(this.lsvCope_DoubleClick);
            this.lsvCope.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsvCope_KeyDown);
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "使用范围";
            this.columnHeader14.Width = 108;
            // 
            // listView1
            // 
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader1,
            this.columnHeader9,
            this.columnHeader3,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader6,
            this.columnHeader4,
            this.columnHeader10,
            this.columnHeader5,
            this.columnHeader11,
            this.columnHeader13,
            this.columnHeader15,
            this.columnHeader16});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(0, 320);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(843, 128);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.Visible = false;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            this.listView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyDown);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "项目编码";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "项目名称";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "类型";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "项目规格";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "常用量";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "单位";
            this.columnHeader8.Width = 40;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "单价";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "ID";
            this.columnHeader4.Width = 0;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "NOQTYFLAG_INT";
            this.columnHeader10.Width = 0;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Width = 0;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "usageid_chr";
            this.columnHeader11.Width = 0;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "usagename_vchr";
            this.columnHeader13.Width = 0;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "FREQID_CHR";
            this.columnHeader15.Width = 0;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "FREQNAME_CHR ";
            this.columnHeader16.Width = 0;
            // 
            // listView2
            // 
            this.listView2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.助记码,
            this.columnHeader12});
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.Location = new System.Drawing.Point(672, 400);
            this.listView2.MultiSelect = false;
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(184, 120);
            this.listView2.TabIndex = 53;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.Visible = false;
            this.listView2.DoubleClick += new System.EventHandler(this.listView2_DoubleClick);
            this.listView2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView2_KeyDown);
            // 
            // 助记码
            // 
            this.助记码.Text = "助记码";
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "名称";
            this.columnHeader12.Width = 100;
            // 
            // frmSUBCHARGEITEM
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.CancelButton = this.m_cmdClose;
            this.ClientSize = new System.Drawing.Size(986, 453);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSUBCHARGEITEM";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSUBCHARGEITEM";
            this.Load += new System.EventHandler(this.frmSUBCHARGEITEM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ctlDataGrid1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region 变量
		/// <summary>
		/// 保存当前的收费项目ID
		/// </summary>
		private string strItemID="";
		private clsDcl_ChargeItem domainCharge=new clsDcl_ChargeItem();
		#endregion

        System.Data.DataTable SubDt;
        Hashtable m_hTable = new Hashtable();
        Hashtable m_hTableItemName = new Hashtable();
		private void frmSUBCHARGEITEM_Load(object sender, System.EventArgs e)
		{
			comboBox1.SelectedIndex=0;
			ctlDataGrid1.m_mthAddEnterToSpaceColumn(0);
            ctlDataGrid1.m_mthAddEnterToSpaceColumn(3);
            ctlDataGrid1.m_mthAddEnterToSpaceColumn(4);
            ctlDataGrid1.m_mthAddEnterToSpaceColumn(5);
            ctlDataGrid1.m_mthAddEnterToSpaceColumn(6);
            ctlDataGrid1.m_mthAddEnterToSpaceColumn(7);
            //ctlDataGrid1.m_mthAddEnterToSpaceColumn(8);
            //ctlDataGrid1.m_mthAddEnterToSpaceColumn(9);

            ctlDataGrid1.m_mthAddEnterToSpaceColumn(19);
            ctlDataGrid1.m_mthAddEnterToSpaceColumn(20);

			((com.digitalwave.controls.datagrid2.clsColumnInfo)this.ctlDataGrid1.Columns[0]).DataGridTextBoxColumn.TextBox.Enter+=new EventHandler(TextBox_Enter);
			((com.digitalwave.controls.datagrid2.clsColumnInfo)this.ctlDataGrid1.Columns[4]).DataGridTextBoxColumn.TextBox.Enter+=new EventHandler(TextBox_Enter);
			((com.digitalwave.controls.datagrid2.clsColumnInfo)this.ctlDataGrid1.Columns[5]).DataGridTextBoxColumn.TextBox.Enter+=new EventHandler(TextBox_Enter);
			((com.digitalwave.controls.datagrid2.clsColumnInfo)this.ctlDataGrid1.Columns[6]).DataGridTextBoxColumn.TextBox.Enter+=new EventHandler(TextBox_Enter);
			((com.digitalwave.controls.datagrid2.clsColumnInfo)this.ctlDataGrid1.Columns[7]).DataGridTextBoxColumn.TextBox.Enter+=new EventHandler(TextBox_Enter);
            ((com.digitalwave.controls.datagrid2.clsColumnInfo)this.ctlDataGrid1.Columns[3]).DataGridTextBoxColumn.TextBox.Enter += new EventHandler(TextBox_Enter);
            ((com.digitalwave.controls.datagrid2.clsColumnInfo)this.ctlDataGrid1.Columns[19]).DataGridTextBoxColumn.TextBox.Enter += new EventHandler(TextBox_Enter);


			((com.digitalwave.controls.datagrid2.clsColumnInfo)this.ctlDataGrid1.Columns[3]).DataGridTextBoxColumn.TextBox.KeyPress+=new KeyPressEventHandler(TextBox_KeyPress);
			((com.digitalwave.controls.datagrid2.clsColumnInfo)this.ctlDataGrid1.Columns[4]).DataGridTextBoxColumn.TextBox.KeyPress+=new KeyPressEventHandler(TextBox_KeyPress);
			((com.digitalwave.controls.datagrid2.clsColumnInfo)this.ctlDataGrid1.Columns[5]).DataGridTextBoxColumn.TextBox.KeyPress+=new KeyPressEventHandler(TextBox_KeyPress);
			((com.digitalwave.controls.datagrid2.clsColumnInfo)this.ctlDataGrid1.Columns[6]).DataGridTextBoxColumn.TextBox.KeyPress+=new KeyPressEventHandler(TextBox_KeyPress);
            ((com.digitalwave.controls.datagrid2.clsColumnInfo)this.ctlDataGrid1.Columns[7]).DataGridTextBoxColumn.TextBox.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);

            ((com.digitalwave.controls.datagrid2.clsColumnInfo)this.ctlDataGrid1.Columns[19]).DataGridTextBoxColumn.TextBox.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);

			((com.digitalwave.controls.datagrid2.clsColumnInfo)this.ctlDataGrid1.Columns[3]).DataGridTextBoxColumn.TextBox.TextChanged+=new EventHandler(TextBox_TextChanged);
			((com.digitalwave.controls.datagrid2.clsColumnInfo)this.ctlDataGrid1.Columns[4]).DataGridTextBoxColumn.TextBox.TextChanged+=new EventHandler(TextBox_TextChanged);
			((com.digitalwave.controls.datagrid2.clsColumnInfo)this.ctlDataGrid1.Columns[5]).DataGridTextBoxColumn.TextBox.TextChanged+=new EventHandler(TextBox_TextChanged);
			((com.digitalwave.controls.datagrid2.clsColumnInfo)this.ctlDataGrid1.Columns[6]).DataGridTextBoxColumn.TextBox.TextChanged+=new EventHandler(TextBox_TextChanged);
			((com.digitalwave.controls.datagrid2.clsColumnInfo)this.ctlDataGrid1.Columns[7]).DataGridTextBoxColumn.TextBox.TextChanged+=new EventHandler(TextBox_TextChanged);
			((com.digitalwave.controls.datagrid2.clsColumnInfo)this.ctlDataGrid1.Columns[13]).DataGridTextBoxColumn.TextBox.TextChanged+=new EventHandler(TextBox_TextChanged);

			((com.digitalwave.controls.datagrid2.clsColumnInfo)this.ctlDataGrid1.Columns[6]).DataGridTextBoxColumn.TextBox.Leave+=new EventHandler(TextBox_Leave);
			((com.digitalwave.controls.datagrid2.clsColumnInfo)this.ctlDataGrid1.Columns[3]).DataGridTextBoxColumn.TextBox.Leave+=new EventHandler(TextBox_Leave);
			SubDt=new System.Data.DataTable();
			domainCharge.m_getSUBCHARGEITEM(strItemID,out SubDt);
            ctlDataGrid1.m_mthSetDataTable(SubDt);
			if(SubDt.Rows.Count>0)
			{
				for(int i1=0;i1<SubDt.Rows.Count;i1++)
				{
                    m_hTable.Add(i1,SubDt.Rows[i1]["itemid_chr"].ToString().Trim());
                    m_hTableItemName.Add(i1, SubDt.Rows[i1]["itemname_vchr"].ToString().Trim());
                    //if(SubDt.Rows[i1]["NOQTYFLAG_INT"].ToString()=="1")
                    //{
                    //    for(int f2=0;f2<14;f2++)
                    //    {
                    //        ctlDataGrid1.m_mthFormatCell(i1,f2,ctlDataGrid1.Font,System.Drawing.Color.White,System.Drawing.Color.Red);
                    //    }
                    //} 
					//else
                    if(SubDt.Rows[i1]["IFSTOP_INT"].ToString()=="1")
					{
						for(int f2=0;f2<14;f2++)
						{
							ctlDataGrid1.m_mthFormatCell(i1,f2,ctlDataGrid1.Font,System.Drawing.Color.YellowGreen,System.Drawing.Color.Yellow);
						}
					}
				}
			}
			ctlDataGrid1.CurrentCell=new DataGridCell(0,0);
			ctlDataGrid1.Focus();
			dtUp.Columns.Add("RowNO");
			dtUp.Columns.Add("ID");
			dtUp.Columns.Add("UPID");
			dtUp.Columns.Add("UPCount");
		}

		private void m_cmdClose_Click(object sender, System.EventArgs e)
		{
			if(listView1.Visible==true)
			{
				m_mthShowFindList(false);
				this.ctlDataGrid1.CurrentCell=new DataGridCell(this.ctlDataGrid1.CurrentCell.RowNumber,0);
				this.ctlDataGrid1.Focus();
			}
			else if(this.listView2.Visible==true)
			{
				this.listView2.Visible=false;
			}
			else
			{
				this.Close();
			}
		}
		/// <summary>
		/// 保存当前选中行的行号
		/// </summary>
		int seleRow=0;
		private void TextBox_Enter(object sender, EventArgs e)
		{
			((TextBox)sender).BackColor=System.Drawing.Color.DarkSeaGreen;
			seleRow=this.ctlDataGrid1.CurrentCell.RowNumber;
		}

		#region 填充查找列表
		/// <summary>
		/// 填充查找列表
		/// </summary>
		/// <param name="p_dtResult"></param>
		private void m_mthFillListView(System.Data.DataTable  p_dtResult)
		{
			for(int i1=0;i1<p_dtResult.Rows.Count;i1++)
			{

				ListViewItem newItem=new ListViewItem(p_dtResult.Rows[i1]["ITEMCODE_VCHR"].ToString());
				newItem.SubItems.Add(p_dtResult.Rows[i1]["ITEMNAME_VCHR"].ToString());
				newItem.SubItems.Add(p_dtResult.Rows[i1]["itemtype"].ToString());
				newItem.SubItems.Add(p_dtResult.Rows[i1]["ITEMSPEC_VCHR"].ToString());
				newItem.SubItems.Add(p_dtResult.Rows[i1]["DOSAGE_DEC"].ToString());
				if(p_dtResult.Rows[i1]["opchargeflg_int"].ToString()=="1")
				{
                    if (p_dtResult.Rows[i1]["itemipunit_chr"].ToString().Trim()!=string.Empty)
                    {
					  newItem.SubItems.Add(p_dtResult.Rows[i1]["itemipunit_chr"].ToString());
                    }
                    else
                    {
                        newItem.SubItems.Add(p_dtResult.Rows[i1]["ITEMUNIT_CHR"].ToString());
                    }
					newItem.SubItems.Add(p_dtResult.Rows[i1]["submoney"].ToString());
				}
				else
				{
                    if (p_dtResult.Rows[i1]["itemopunit_chr"].ToString().Trim() != string.Empty)
                    {
                        newItem.SubItems.Add(p_dtResult.Rows[i1]["itemopunit_chr"].ToString());
                    }
                    else
                    {
                        newItem.SubItems.Add(p_dtResult.Rows[i1]["ITEMUNIT_CHR"].ToString());
                    }
					newItem.SubItems.Add(p_dtResult.Rows[i1]["itemprice_mny"].ToString());
				}
				newItem.SubItems.Add(p_dtResult.Rows[i1]["ITEMID_CHR"].ToString());
				newItem.SubItems.Add(p_dtResult.Rows[i1]["NOQTYFLAG_INT"].ToString());
				newItem.SubItems.Add(p_dtResult.Rows[i1]["medicinetypeid_chr"].ToString());
				newItem.SubItems.Add(p_dtResult.Rows[i1]["usageid_chr"].ToString());
				newItem.SubItems.Add(p_dtResult.Rows[i1]["usagename_vchr"].ToString());
                newItem.SubItems.Add(p_dtResult.Rows[i1]["FREQID_CHR"].ToString());
                newItem.SubItems.Add(p_dtResult.Rows[i1]["FREQNAME_CHR"].ToString());
				listView1.Items.Add(newItem);
                //try
                //{
                //    if(p_dtResult.Rows[i1]["NOQTYFLAG_INT"].ToString()=="1")
                //    {
                //        listView1.Items[i1].ForeColor=System.Drawing.Color.Red;
                //    }
                //}
                //catch
                //{
                //}
			}
		}

		#endregion
	/// <summary>
	/// 显示查找列表
	/// </summary>
	/// <param name="blIsShow">true 显示,false-隐藏</param>
		private void m_mthShowFindList(bool blIsShow)
		{
			if(blIsShow==true)
			{
				listView1.Visible=true;
				panel1.Controls.Add(listView1);
				listView1.Height=130;
				listView1.Dock=DockStyle.Bottom;
				ctlDataGrid1.Height=320;
				ctlDataGrid1.Dock=DockStyle.Top;
				if(listView1.Items.Count>0)
				listView1.Items[0].Selected=true;
				listView1.Focus();
			}
			else
			{
				panel1.Controls.Remove(listView1);
				ctlDataGrid1.Dock=DockStyle.Fill;
				listView1.Visible=false;
			}
		}
		#region 清空一项
		/// <summary>
		/// 清空一项
		/// </summary>
		private void m_mthClearRow()
		{
			this.ctlDataGrid1[seleRow,1]=System.DBNull.Value;
			this.ctlDataGrid1[seleRow,2]=System.DBNull.Value;
			this.ctlDataGrid1[seleRow,3]=System.DBNull.Value;
			this.ctlDataGrid1[seleRow,4]=System.DBNull.Value;
			this.ctlDataGrid1[seleRow,5]=System.DBNull.Value;
			this.ctlDataGrid1[seleRow,6]=System.DBNull.Value;
			this.ctlDataGrid1[seleRow,7]=System.DBNull.Value;
			this.ctlDataGrid1[seleRow,8]=System.DBNull.Value;
			this.ctlDataGrid1[seleRow,9]=System.DBNull.Value;
			this.ctlDataGrid1[seleRow,10]=System.DBNull.Value;
			this.ctlDataGrid1[seleRow,11]=System.DBNull.Value;
			this.ctlDataGrid1[seleRow,12]=System.DBNull.Value;
			this.ctlDataGrid1[seleRow,13]=System.DBNull.Value;
			this.ctlDataGrid1[seleRow,14]=System.DBNull.Value;
			this.ctlDataGrid1[seleRow,15]=System.DBNull.Value;
			this.ctlDataGrid1[seleRow,16]=System.DBNull.Value;
			this.ctlDataGrid1[seleRow,17]=System.DBNull.Value;
			this.ctlDataGrid1[seleRow,18]=System.DBNull.Value;
		}

		#endregion
        public bool m_blnIsMedicine = false;
		#region 选择项目
		/// <summary>
		/// 选择项目
		/// </summary>
		private void m_mthSeleItem()
		{
			if(ctlDataGrid1.CurrentCell.RowNumber>-1)
			{
				this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber,0]=this.listView1.SelectedItems[0].SubItems[0].Text;
				this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber,1]=this.listView1.SelectedItems[0].SubItems[1].Text;
				this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber,2]=this.listView1.SelectedItems[0].SubItems[3].Text;
				this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber,3]=this.listView1.SelectedItems[0].SubItems[4].Text;
				this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber,8]=this.listView1.SelectedItems[0].SubItems[5].Text;
				this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber,9]=this.listView1.SelectedItems[0].SubItems[6].Text;
				this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber,13]=this.listView1.SelectedItems[0].SubItems[7].Text;
				this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber,14]=this.listView1.SelectedItems[0].SubItems[9].Text;

				this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber,17]=this.listView1.SelectedItems[0].SubItems[4].Text;


				this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber,4]=this.listView1.SelectedItems[0].SubItems[11].Text;

				this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber,5]=this.listView1.SelectedItems[0].SubItems[13].Text;

                this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber, 10] = this.listView1.SelectedItems[0].SubItems[12].Text;
                this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber, 19] = "连续用";
                this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber, 11] = this.listView1.SelectedItems[0].SubItems[10].Text;
				if(this.listView1.SelectedItems[0].SubItems[8].Text=="1")
				{
					for(int f2=0;f2<13;f2++)
					{
						ctlDataGrid1.m_mthFormatCell(this.ctlDataGrid1.CurrentCell.RowNumber,f2,ctlDataGrid1.Font,System.Drawing.Color.White,System.Drawing.Color.Red);
					}
				}
                if (this.listView1.SelectedItems[0].SubItems[2].Text.Trim() == "中草药" || this.listView1.SelectedItems[0].SubItems[2].Text.Trim() == "西药" || this.listView1.SelectedItems[0].SubItems[2].Text.Trim() == "中成中" || this.listView1.SelectedItems[0].SubItems[2].Text.Trim() == "中成西" || this.listView1.SelectedItems[0].SubItems[2].Text.Trim() == "中成药")
                {
                    this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber, 6] = 1;
                    m_blnIsMedicine = true;
                }

			}
		}
		#endregion

		#region 计算药品数量
		/// <summary>
		/// 计算药品数量
		/// </summary>
		/// <returns></returns>
		private string  m_mthCountMed(int RowNumber)
		{
			double medCount=0;
			if(this.ctlDataGrid1[RowNumber,3].ToString()!=""&&this.ctlDataGrid1[RowNumber,6].ToString()!=""&&this.ctlDataGrid1[RowNumber,15].ToString()!=""&&this.ctlDataGrid1[RowNumber,16].ToString()!=""&&this.ctlDataGrid1[RowNumber,17].ToString()!="")
			{
				medCount=Math.Ceiling(Double.Parse(this.ctlDataGrid1[RowNumber,3].ToString())/Double.Parse(this.ctlDataGrid1[RowNumber,17].ToString()))*Double.Parse(this.ctlDataGrid1[RowNumber,16].ToString())*Double.Parse(this.ctlDataGrid1[RowNumber,15].ToString())*Double.Parse(this.ctlDataGrid1[RowNumber,6].ToString());
			}
			return medCount.ToString();
		}
		#endregion

		private void ctlDataGrid1_m_evtDataGridTextBoxKeyDown(object sender, com.digitalwave.controls.datagrid2.clsDGTextKeyEventArgs e)
		{
			this.label1.Text="";
			if(e.KeyCode==Keys.Enter&&ctlDataGrid1.CurrentCell.ColumnNumber==0)
			{
				if(e.m_strText.IndexOf("\\")==0)
				{
					m_mthFindAccordRecipe(e.m_strText.Substring(1,e.m_strText.Length-1));
				}
				else if(e.m_strText.Trim().Replace("？","?").IndexOf("?")==0)
				{
					m_mthFindItemByUsage(e.m_strText.Substring(1,e.m_strText.Length-1));
				}
				else
				{
					System.Data.DataTable  p_dtResult=new System.Data.DataTable();
					string strFindFile="";
					try
					{
						int ChangType=int.Parse(((TextBox)sender).Text);
						strFindFile="itemcode_vchr";
					}
					catch
					{
						switch(comboBox1.SelectedIndex)
						{
							case 0:
								strFindFile="itemcode_vchr";
								break;
							case 1:
								strFindFile="itemname_vchr";
								break;
							case 2:
								strFindFile="ITEMPYCODE_CHR";
								break;
							case 3:
								strFindFile="ITEMWBCODE_CHR";
								break;
						}
					}
					domainCharge.m_mthFindMedicineByID(out p_dtResult,strFindFile,((TextBox)sender).Text);
					listView1.Items.Clear();
					if(p_dtResult.Rows.Count>0)
					{
						m_mthFillListView(p_dtResult);
					}
					m_mthShowFindList(true);

					if(this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber,12].ToString()=="1")
					{
						System.Data.DataRow newRow=dtUp.NewRow();
				
						newRow["RowNO"]=this.ctlDataGrid1.CurrentCell.RowNumber.ToString();
						newRow["ID"]=this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber,13].ToString();
						dtUp.Rows.Add(newRow);
					}
				}
			}
			if(e.KeyCode==Keys.Enter&&ctlDataGrid1.CurrentCell.ColumnNumber==3)
			{
				this.ctlDataGrid1.CurrentCell=new DataGridCell(this.ctlDataGrid1.CurrentCell.RowNumber,4);
				return;
			}
			if(e.KeyCode==Keys.Enter&&ctlDataGrid1.CurrentCell.ColumnNumber==4)
			{
				if(this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber,14].ToString()!=""&&int.Parse(this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber,14].ToString())<=4)
				{
					m_ShowList(1,((TextBox)sender).Text,e);
				}
				else
				{
					this.ctlDataGrid1.CurrentCell=new DataGridCell(this.ctlDataGrid1.CurrentCell.RowNumber,5);
					return;
				}
			}
			if(e.KeyCode==Keys.Enter&&ctlDataGrid1.CurrentCell.ColumnNumber==5)
			{
				if(this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber,14].ToString()!=""&&int.Parse(this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber,14].ToString())<=4)
				{
					m_ShowList(2,((TextBox)sender).Text,e);
				}
				else
				{
					this.ctlDataGrid1.CurrentCell=new DataGridCell(this.ctlDataGrid1.CurrentCell.RowNumber,6);
					return;
				}
			}
			if(e.KeyCode==Keys.Enter&&ctlDataGrid1.CurrentCell.ColumnNumber==6)
			{
				if(this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber,14].ToString()!=""&&int.Parse(this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber,14].ToString())<=4)
				{
                    this.ctlDataGrid1.CurrentCell=new DataGridCell(this.ctlDataGrid1.CurrentCell.RowNumber,19);
					if(int.Parse(ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber,14].ToString())<=4)
						this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber,7]=m_mthCountMed(this.ctlDataGrid1.CurrentCell.RowNumber);
				}
				else
				{
					this.ctlDataGrid1.CurrentCell=new DataGridCell(this.ctlDataGrid1.CurrentCell.RowNumber,7);
				}
				return;
			}
			if(e.KeyCode==Keys.Enter&&ctlDataGrid1.CurrentCell.ColumnNumber==7)
			{  
               
				this.ctlDataGrid1.CurrentCell=new DataGridCell(this.ctlDataGrid1.CurrentCell.RowNumber,19);
                return;
               
			}
            if (e.KeyCode == Keys.Enter && ctlDataGrid1.CurrentCell.ColumnNumber == 19)
            {
                m_ShowContinueUseType(e);
            }
            if (e.KeyCode == Keys.Enter && ctlDataGrid1.CurrentCell.ColumnNumber == 20)
            {
                m_ShowUseScope(e);
            }
        

		}
        #region 续用类型
        /// <summary>
        /// 续用类型 {0=连续用;1=首次用}
        /// </summary>
        private void m_ShowContinueUseType(com.digitalwave.controls.datagrid2.clsDGTextKeyEventArgs e)
        {
            if (this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber, 1].ToString() == "")
                return;
            Point p = e.m_ptPositionInScreen;
            p =this.m_lsvContinueType.FindForm().PointToClient(p);
            p.Y += 23;
            m_lsvContinueType.Location = p;
            m_lsvContinueType.Visible = true;
            m_lsvContinueType.Focus();

            m_lsvContinueType.Items[0].Focused = true;
            m_lsvContinueType.Items[0].Selected = true;
        }
        #endregion
        private void m_lsvContinueType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (m_lsvContinueType.SelectedItems.Count > 0)
                {
                    this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber, 19] = m_lsvContinueType.SelectedItems[0].Text;
                    this.ctlDataGrid1.CurrentCell = new DataGridCell(this.ctlDataGrid1.CurrentCell.RowNumber, 20);
                    m_lsvContinueType.Visible = false;
                }
            }
        }

        private void m_lsvContinueType_DoubleClick(object sender, EventArgs e)
        {
            if (m_lsvContinueType.SelectedItems.Count > 0)
            {
                this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber, 19] = m_lsvContinueType.SelectedItems[0].Text;
                m_lsvContinueType.Visible = false;

            }
        }
        #region 续用类型,使用范围 {0=用于主项目;1=用于所有关联主项目}
        /// <summary>
        /// 续用类型 使用范围 {0=用于主项目;1=用于所有关联主项目}
        /// </summary>
        private void m_ShowUseScope(com.digitalwave.controls.datagrid2.clsDGTextKeyEventArgs e)
        {
            if (this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber, 1].ToString() == "")
                return;
            Point p = e.m_ptPositionInScreen;
            p = lsvCope.FindForm().PointToClient(p);
            p.Y += 23;
            lsvCope.Location = p;
            lsvCope.Visible = true;
            lsvCope.Focus();

            lsvCope.Items[0].Focused = true;
            lsvCope.Items[0].Selected = true;
        }
        #endregion
        private void lsvCope_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (lsvCope.SelectedItems.Count > 0)
                {
                    this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber, 20] = lsvCope.SelectedItems[0].Text;
                    this.ctlDataGrid1.CurrentCell = new DataGridCell(this.ctlDataGrid1.CurrentCell.RowNumber + 1, 0);
                    lsvCope.Visible = false;
                }
            }
        }

        private void lsvCope_DoubleClick(object sender, EventArgs e)
        {
            if (lsvCope.SelectedItems.Count > 0)
            {
                this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber, 20] = lsvCope.SelectedItems[0].Text;
                lsvCope.Visible = false;

            }
        }
		#region 获取界面数据
		/// <summary>
		/// 获取界面数据
		/// </summary>
		private System.Data.DataTable m_GetData()
		{
			System.Data.DataTable dt=new System.Data.DataTable();
			dt.Columns.Add("ITEMID_CHR");
			dt.Columns.Add("SUBITEMID_CHR");
			dt.Columns.Add("QTY_INT");
			dt.Columns.Add("USAGEID_CHR");
			dt.Columns.Add("FREQID_CHR");
			dt.Columns.Add("DAYS_INT");
            dt.Columns.Add("TOTALQTY_DEC");
            dt.Columns.Add("USESCOPE_INT");
            dt.Columns.Add("CONTINUEUSETYPE_INT");
			if(this.ctlDataGrid1.RowCount>0)
			{
				for(int i1=0;i1<this.ctlDataGrid1.RowCount;i1++)
				{
					if(this.ctlDataGrid1[i1,13].ToString()!="")
					{
						System.Data.DataRow newRow=dt.NewRow();
						newRow["ITEMID_CHR"]=strItemID;
						newRow["SUBITEMID_CHR"]=this.ctlDataGrid1[i1,13].ToString();
						newRow["QTY_INT"]=this.ctlDataGrid1[i1,3].ToString();
						newRow["USAGEID_CHR"]=this.ctlDataGrid1[i1,11].ToString();
						newRow["FREQID_CHR"]=this.ctlDataGrid1[i1,10].ToString();
						newRow["DAYS_INT"]=this.ctlDataGrid1[i1,6].ToString();
						newRow["TOTALQTY_DEC"]=this.ctlDataGrid1[i1,7].ToString();
                        if (this.ctlDataGrid1[i1, "UseScope_int"].ToString().Trim() == "主项目")
                        {
                            newRow["UseScope_int"] = "0";
                        }
                        else if (this.ctlDataGrid1[i1, "UseScope_int"].ToString().Trim() == "所有主项目")
                        {
                            newRow["UseScope_int"] = "1";
                        }
                        if (this.ctlDataGrid1[i1, "CONTINUEUSETYPE_INT"].ToString().Trim() == "连续用")
                        {
                            newRow["CONTINUEUSETYPE_INT"] = "0";
                        }
                        else if (this.ctlDataGrid1[i1, "CONTINUEUSETYPE_INT"].ToString().Trim() == "首次用")
                        {
                            newRow["CONTINUEUSETYPE_INT"] = "1";
                        }
          

						dt.Rows.Add(newRow);
					}
				}
			}
			return dt;

		}


		#endregion

		#region 显示用法/频率选择列表
		/// <summary>
		/// 显示用法/频率选择列表
		/// </summary>
		/// <param name="flag">1-用法,2-频率</param>
		/// <param name="strFind">查找数据的条件</param>
		private void m_ShowList(int flag,string strFind,com.digitalwave.controls.datagrid2.clsDGTextKeyEventArgs e)
		{
			if(this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber,1].ToString()=="")
				return;
			System.Data.DataTable dt=new System.Data.DataTable();
			clsDcl_DoctorWorkstation domailclse=new clsDcl_DoctorWorkstation();
			if(flag==1)
			{
				domailclse.m_mthFindUsage(strFind, 0, out dt);
				m_fillView(this.listView2,dt,1);
			}
			else
			{
				domailclse.m_mthFindFrequency(strFind,out dt);
				m_fillView(this.listView2,dt,2);
			}
			if(this.listView2.Items.Count>0)
			{
				Point p=e.m_ptPositionInScreen;
				p=this.listView2.FindForm().PointToClient(p);
				p.Y+=23;
				this.listView2.Location=p;
				this.listView2.Visible=true;
				this.listView2.Items[0].Selected=true;
				this.listView2.Focus();
			}
		}
		#endregion

		#region 填充ListView
		/// <summary>
		/// 填充ListView
		/// </summary>
		/// <param name="objView"></param>
		/// <param name="dt"></param>
		/// <param name="flag">1-用法,2-频率</param>
		private void m_fillView(ListView objView,System.Data.DataTable dt,int flag)
		{
			objView.Tag=flag.ToString();
			objView.Items.Clear();
			if(dt.Rows.Count>0)
			{
				ListViewItem newItem=null;
				if(flag==2)
				{
					for(int i1=0;i1<dt.Rows.Count;i1++)
					{
						newItem=new ListViewItem(dt.Rows[i1]["USERCODE_CHR"].ToString());
						newItem.SubItems.Add(dt.Rows[i1]["FREQNAME_CHR"].ToString());
						newItem.Tag=dt.Rows[i1];
						objView.Items.Add(newItem);
					}
				}
				else
				{
					for(int i1=0;i1<dt.Rows.Count;i1++)
					{
						newItem=new ListViewItem(dt.Rows[i1]["USERCODE_CHR"].ToString());
						newItem.SubItems.Add(dt.Rows[i1]["USAGENAME_VCHR"].ToString());
						newItem.Tag=dt.Rows[i1];
						objView.Items.Add(newItem);
					}
				}

			}
		}
		#endregion
		#region 选择用法,频率
		/// <summary>
		/// 选择用法,频率
		/// </summary>
		private void m_mthsele()
		{
			System.Data.DataRow seleRow=(System.Data.DataRow)this.listView2.SelectedItems[0].Tag;
			if((string)this.listView2.Tag=="1")
			{
				this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber,4]=seleRow["USAGENAME_VCHR"].ToString();
				this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber,11]=seleRow["USAGEID_CHR"].ToString();
			}
			else
			{
				this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber,5]=seleRow["FREQNAME_CHR"].ToString();
				this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber,10]=seleRow["FREQID_CHR"].ToString();
				this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber,15]=seleRow["TIMES_INT"].ToString();
				this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber,16]=seleRow["DAYS_INT"].ToString();
			}
			this.listView2.Visible=false;
			this.ctlDataGrid1.CurrentCell=new DataGridCell(this.ctlDataGrid1.CurrentCell.RowNumber,this.ctlDataGrid1.CurrentCell.ColumnNumber+1);
		}
		#endregion

		private void listView1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				if(this.listView1.Items.Count==0||this.listView1.SelectedItems[0].Index==-1)
				{
					m_mthClearRow();
					m_mthShowFindList(false);
					ctlDataGrid1.Focus();
					ctlDataGrid1.CurrentCell=new DataGridCell(this.ctlDataGrid1.CurrentCell.RowNumber,0);
					return;
				}
				if(this.ctlDataGrid1.RowCount>0)
				{
					if(this.listView1.SelectedItems[0].SubItems[7].Text==strItemID)
					{
						this.label1.Text="不可以关联自身!";
						m_mthShowFindList(false);
						ctlDataGrid1.Focus();
						ctlDataGrid1.CurrentCell=new DataGridCell(this.ctlDataGrid1.CurrentCell.RowNumber,0);
						return;
					}
					for(int i1=0;i1<this.ctlDataGrid1.RowCount;i1++)
					{
						if(this.ctlDataGrid1[i1,13].ToString()==this.listView1.SelectedItems[0].SubItems[7].Text)
						{
							this.label1.Text="该收费项目已经存在!";
						m_mthShowFindList(false);
							ctlDataGrid1.Focus();
							m_mthClearRow();
							ctlDataGrid1.CurrentCell=new DataGridCell(this.ctlDataGrid1.CurrentCell.RowNumber,0);
							return;
						}
					}
				}
				m_mthSeleItem();
				m_mthShowFindList(false);
                if (this.m_blnIsMedicine == true)
                {
                   
                    
                    this.ctlDataGrid1.CurrentCell = new DataGridCell(this.ctlDataGrid1.CurrentCell.RowNumber, 5);
                    this.m_blnIsMedicine = false;
                    System.Windows.Forms.SendKeys.SendWait("{ENTER}");
                    System.Windows.Forms.SendKeys.SendWait("{ENTER}");
                    System.Windows.Forms.SendKeys.SendWait("{ENTER}");
                    this.ctlDataGrid1.Refresh();

                }
           
				if(ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber,14].ToString()!=""&&int.Parse(ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber,14].ToString())<=4)
				{
					this.ctlDataGrid1.CurrentCell=new DataGridCell(this.ctlDataGrid1.CurrentCell.RowNumber,3);
				}
				else
				{
					this.ctlDataGrid1.CurrentCell=new DataGridCell(this.ctlDataGrid1.CurrentCell.RowNumber,7);
				}
        
            

			}
		}

		public void m_mthFindItemByUsage(string strID)
		{
			frmGetItemByUsage objfrm =new frmGetItemByUsage(strID);
			if(objfrm.ShowDialog()==DialogResult.OK)
			{
				com.digitalwave.iCare.ValueObject.clsChargeItem_VO[] objResult = objfrm.ItemResult;
				if(objResult ==null)
				{
					return;
				}
				this.ctlDataGrid1.m_mthDeleteRow(this.ctlDataGrid1.RowCount-1);
				for(int i=0;i<objResult.Length;i++)
				{
					int k=0;
					for(int f2=0;f2<this.ctlDataGrid1.RowCount;f2++)
					{
						if(this.ctlDataGrid1[f2,13].ToString().Trim()==objResult[i].m_strItemID.Trim()||objResult[i].m_strItemID.Trim()==strItemID)
						{
							k=-1;
							break;
						}
					}
					if(k==0)
					{
						this.ctlDataGrid1.m_mthAppendRow(new Object[]{""});
						this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,0]=objResult[i].m_strItemCode;
						this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,1]=objResult[i].m_strItemName;
						this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,2]=objResult[i].m_strItemSpec;
						this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,3]=objResult[i].m_strDosage;
						this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,8]=objResult[i].m_ItemOPUnit.m_strUnitID;
						this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,10]="";//频率ID
			
						this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,"DOSAGEUNIT_CHR"]=objResult[i].m_DosageUnit;
                        ctlDataGrid1[this.ctlDataGrid1.RowCount - 1, 14] = objResult[i].m_strItemSrcID;
                        ctlDataGrid1[this.ctlDataGrid1.RowCount - 1, "IFSTOP_INT"] = objResult[i].m_intStopFlag.ToString();
                        ctlDataGrid1[this.ctlDataGrid1.RowCount - 1, 6] = objResult[i].m_dblBIHQTY_DEC.ToString();
			
						this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,"itemid_chr"]=objResult[i].m_strItemID;
		
						try
						{
							this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,5]="";
							
							if(objResult[i].m_intOPCHARGEFLG_INT==0)
							{
								this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,"DOSAGEQTY_DEC"]=objResult[i].m_strDosage;
								this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,"DOSETYPE_CHR"]=objResult[i].m_strOPUNIT;
							}
							else
							{
								this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,"DOSAGEQTY_DEC"]=objResult[i].m_dblBIHQTY_DEC.ToString();
								this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,"DOSETYPE_CHR"]=objResult[i].m_strIPUNIT;
							}
				
							this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,"ROWNO_CHR"]="";

						}
						catch
						{

						}
			
						try
						{

							this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,"SUBMONEY"]=objResult[i].m_strTOTALPRICE;
							this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,"PACKQTY_DEC"]=objResult[i].m_decPACKQTY_DEC.ToString();

							this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,"DOSAGE_DEC"]=objResult[i].m_strDosage;
						}
						catch
						{
						}
						//						if(objResult[i].m_intOPCHARGEFLG_INT==0)
						//						{
						//							this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,9]=objResult[i].m_strOPPRICE;
						//						}
						//						else
						//						{
						//							this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,9]=objResult[i].m_strIPPRICE;
						//						}
						this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,9]=objResult[i].m_fltItemPrice.ToString();
						this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,11]=objResult[i].m_Usage.m_strUsageID.Trim();
						this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,"ITEMOPINVTYPE_CHR"]=objResult[i].m_ItemOPInvType.m_strTypeID;
						this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,4]=objResult[i].m_Usage.m_strUsageName;
						this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,7]=objResult[i].m_strUNITPRICE;
						if(objResult[i].m_intIFSTOP_INT!=0)
						{
						}
					}
				}
				this.ctlDataGrid1.CurrentCell=new DataGridCell(this.ctlDataGrid1.RowCount-1,0);
				SendKeys.SendWait("{Down}");
			}
			else
			{
				this.ctlDataGrid1.CurrentCell=new DataGridCell(this.ctlDataGrid1.CurrentCell.RowNumber,0);
			}
		}

		#region 查找模板列表
		/// <summary>
		/// 调协定处方，传入查询条件。返回结果后填充到DataGrid
		/// </summary>
		/// <param name="strCode"></param>
		public void m_mthFindAccordRecipe(string strCode)
		{
		
			string strEmployeeID="0000001";
			if(this.LoginInfo!=null)
			{
				strEmployeeID=this.LoginInfo.m_strEmpID;
			}

			frmAccordRecipe objForm=new frmAccordRecipe();
			objForm.FindText =strCode;
			objForm.FindIndex =comboBox1.SelectedIndex;
			if(objForm.ShowDialog()==DialogResult.OK)
			{
				DataTable dtAll=objForm.GetTableAll;
				if(dtAll.Rows.Count>0)
				{
					this.ctlDataGrid1.m_mthDeleteRow(this.ctlDataGrid1.RowCount-1);
					for(int i1=0;i1<dtAll.Rows.Count;i1++)
					{
						int k=0;
						if(this.ctlDataGrid1.RowCount>0)
						{
							for(int f2=0;f2<this.ctlDataGrid1.RowCount;f2++)
							{
								if(this.ctlDataGrid1[f2,13].ToString().Trim()==dtAll.Rows[i1]["itemid_chr"].ToString().Trim()||dtAll.Rows[i1]["itemid_chr"].ToString().Trim()==strItemID)
								{
									k=-1;
									break;
									
								}
							}
						}
						if(k==-1)
							break;
						m_mthAddRow(dtAll.Rows[i1]);
					}
				}
				this.ctlDataGrid1.CurrentCell=new DataGridCell(this.ctlDataGrid1.RowCount-1,0);
//				this.m_mthFillDataGrid(objForm);
				//DataGrid的Bug,要发送虚拟键才能显示光标
//				SendKeys.SendWait("{Up}");
				SendKeys.SendWait("{Down}");
			}
			else
			{
				this.ctlDataGrid1.CurrentCell=new DataGridCell(this.ctlDataGrid1.CurrentCell.RowNumber,0);
			}

		}
		#endregion

		#region 
		private void m_mthAddRow(DataRow NewRow)
		{
		this.ctlDataGrid1.m_mthAppendRow(new Object[]{""});
		this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,0]=NewRow["ITEMCODE_VCHR"].ToString();
		this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,1]=NewRow["ITEMNAME_VCHR"].ToString();
		this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,2]=NewRow["ITEMSPEC_VCHR"].ToString();
			this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,3]=NewRow["DOSAGEQTY_DEC"].ToString();
			this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,8]=NewRow["ITEMOPUNIT_CHR"].ToString();
			this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,10]=NewRow["FREQID_CHR"].ToString();
			
		this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,"DOSAGEUNIT_CHR"]=NewRow["DOSAGEUNIT_CHR"].ToString();
        ctlDataGrid1[this.ctlDataGrid1.RowCount - 1, 14] = NewRow["MEDICINEID_CHR"].ToString();
        ctlDataGrid1[this.ctlDataGrid1.RowCount - 1, "IFSTOP_INT"] = NewRow["IFSTOP_INT"].ToString();
        
		this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,"itemid_chr"]=NewRow["itemid_chr"].ToString();
		try
		{
			this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,5]=NewRow["FREQNAME_CHR"].ToString();
			this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,"DOSETYPE_CHR"]=NewRow["DOSETYPE_CHR"].ToString();
			this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,"DOSAGEQTY_DEC"]=NewRow["DOSAGEQTY_DEC"].ToString();
			
			this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,"ROWNO_CHR"]=NewRow["ROWNO_CHR"].ToString();

		}
		catch
		{

		}
		
		try
		{

			this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,"SUBMONEY"]=NewRow["SubMoney"].ToString();
			this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,"PACKQTY_DEC"]=NewRow["PACKQTY_DEC"].ToString();
			this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,"OPCHARGEFLG_INT"]=NewRow["OPCHARGEFLG_INT"].ToString();
			this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,"DOSAGE_DEC"]=NewRow["DOSAGE_DEC"].ToString();
		}
		catch
		{
		}
		this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,1]=NewRow["itemname_vchr"].ToString();
		this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,9]=NewRow["ITEMPRICE_MNY"].ToString();

		this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,11]=NewRow["DOSETYPE_CHR"].ToString().Trim();
		this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,"ITEMOPINVTYPE_CHR"]=NewRow["ITEMOPINVTYPE_CHR"].ToString();
		this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,4]=NewRow["USAGENAME_VCHR"].ToString().Trim();
		this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,7]=NewRow["QTY_DEC"].ToString();
        ctlDataGrid1[this.ctlDataGrid1.RowCount - 1, 6] = NewRow["DAYS_INT"].ToString();
		}

		#endregion
		/// <summary>
		/// 保存修改的数据
		/// </summary>
		System.Data.DataTable dtUp=new System.Data.DataTable();
		private void m_cmdAddNew_Click(object sender, System.EventArgs e)
		{
            for (int i = 0; i < ctlDataGrid1.RowCount; i++)
            {
                if (this.ctlDataGrid1[i, "UseScope_int"].ToString().Trim() == ""&&this.ctlDataGrid1[i,0].ToString().Trim()!=string.Empty)
                {
                    MessageBox.Show("请输入使用范围");
                    return;
                }
                if (this.ctlDataGrid1[i, "CONTINUEUSETYPE_INT"].ToString().Trim() == "" && this.ctlDataGrid1[i, 0].ToString().Trim() != string.Empty)
                {
                    MessageBox.Show("请输入续用类型");
                    return;
                }
            }
			System.Data.DataTable dt=m_GetData();
			if(dtUp!=null&&dtUp.Rows.Count>0)
			{
				for(int i1=0;i1<dtUp.Rows.Count;i1++)
				{
					if(dtUp.Rows[i1][0]==System.DBNull.Value||dtUp.Rows[i1][1]==System.DBNull.Value||dtUp.Rows[i1][2]==System.DBNull.Value)
					{
						dtUp.Rows[i1].Delete();
					}
					else
					{
						dtUp.Rows[i1][3]=this.ctlDataGrid1[int.Parse(dtUp.Rows[i1][0].ToString()),3].ToString();
					}
				}
				dtUp.AcceptChanges();
			}
			if(dt.Rows.Count>0)
			{
				long lngRes=0;
                string strID = "";
                string strItemName = "";
				if(dtUp!=null&&dtUp.Rows.Count>0)
				{
                    object obj = m_hTable[ctlDataGrid1.CurrentCell.RowNumber];
                    if (obj != null)
                    {
                        strID = (string)obj;
                        strItemName = (string)m_hTableItemName[ctlDataGrid1.CurrentCell.RowNumber];
                    }
                    frmError objfrm = new frmError(strID, strItemName);
                    objfrm.m_lblContent.Text = "是否要把此修改应用到所有的收费项目?";
                    DialogResult objDiaResult = objfrm.ShowDialog();
                    if (objDiaResult == DialogResult.Yes)
					{
						lngRes=domainCharge.m_lngSaveSunItem(strItemID,dt,dtUp);
					}
                    else if (objDiaResult == DialogResult.No)
                    {
                        lngRes = domainCharge.m_lngSaveSunItem(strItemID, dt, null);
                    }
                    else if (objDiaResult == DialogResult.Cancel)
                    {
                        return;
                    }
				}
				else
				{
					lngRes=domainCharge.m_lngSaveSunItem(strItemID,dt,null);
				}
				if(lngRes>0)
				{
					MessageBox.Show("保存成功!","Icare");
                    this.m_cmdSynOrderDic.Enabled = true;
					if(dtUp.Rows.Count>0)
						dtUp.Rows.Clear();
					for(int i1=0;i1<this.ctlDataGrid1.RowCount;i1++)
					{
						if(ctlDataGrid1[i1,13].ToString()!="")
						{
							ctlDataGrid1[i1,12]="1";
						}
					}
				}
			}
		}

		private void m_btndeleteDetail_Click(object sender, System.EventArgs e)
		{
			if(seleRow>-1&&this.ctlDataGrid1[seleRow,13].ToString()!="")
			{
				long lngRes=0;
				if(MessageBox.Show("是否确定要删除此收费项目关联?","Icare",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
                    string strID = "";
                    string strItemName = "";
                    object obj = m_hTable[ctlDataGrid1.CurrentCell.RowNumber];
                    if (obj != null)
                    {
                        strID = (string)obj;
                        strItemName = (string)m_hTableItemName[ctlDataGrid1.CurrentCell.RowNumber];
                    }
                    DialogResult objDiaResult = (new frmError(strID, strItemName).ShowDialog());
                    if (objDiaResult == DialogResult.Yes)
					{
						lngRes=domainCharge.m_lngDeleteSunItem(this.strItemID,this.ctlDataGrid1[seleRow,13].ToString(),true);
					}
                    else if (objDiaResult == DialogResult.No)
					{
						lngRes=domainCharge.m_lngDeleteSunItem(this.strItemID,this.ctlDataGrid1[seleRow,13].ToString(),false);
					}
                    else if (objDiaResult == DialogResult.Cancel)
                    {
                        return;
                    }
					if(lngRes==1)
					{
						this.ctlDataGrid1.m_mthDeleteRow(seleRow);
						MessageBox.Show("删除成功!","Icare");
					}
				}
			}
		}

		private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
   
			if(ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber,14].ToString()!="")
			{
				if(this.ctlDataGrid1.CurrentCell.ColumnNumber==4||this.ctlDataGrid1.CurrentCell.ColumnNumber==5)
				{
					if((int)e.KeyChar>=46&&(int)e.KeyChar!=47||(int)e.KeyChar==8)
					{
						;
					}
					else
					{
						e.Handled=true;

					}
				}
				else
				{
					if((int)e.KeyChar>=46&&(int)e.KeyChar<=57&&(int)e.KeyChar!=47||(int)e.KeyChar==8)
					{
						;
					}
					else
					{
						e.Handled=true;

					}
				}
			}
			else
			{
				if(this.ctlDataGrid1.CurrentCell.ColumnNumber!=7)
				{
					e.Handled=true;
				}
			}
		}

		private void TextBox_TextChanged(object sender, EventArgs e)
		{
			if(this.ctlDataGrid1.CurrentCell.ColumnNumber==15||this.ctlDataGrid1.CurrentCell.ColumnNumber==16||this.ctlDataGrid1.CurrentCell.ColumnNumber==17)
			{
				if(int.Parse(ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber,14].ToString())<=4)
					this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber,7]=m_mthCountMed(this.ctlDataGrid1.CurrentCell.RowNumber);
			}
			if(this.ctlDataGrid1[seleRow,12].ToString()=="1")
			{
				if(dtUp.Rows.Count>0)
				{
					for(int i1=0;i1<dtUp.Rows.Count;i1++)
					{
						if(dtUp.Rows[i1]["RowNO"].ToString()==seleRow.ToString())
						{
							dtUp.Rows[i1]["UPID"]=this.ctlDataGrid1[seleRow,13].ToString();
						}
					}
				}
			}
		}
		private void listView1_DoubleClick(object sender, System.EventArgs e)
		{
			if(this.listView1.Items.Count==0||this.listView1.SelectedItems[0].Index==-1)
			{
				m_mthShowFindList(false);
				ctlDataGrid1.Focus();
				ctlDataGrid1.CurrentCell=new DataGridCell(this.ctlDataGrid1.CurrentCell.RowNumber,0);
				return;
			}
			if(this.ctlDataGrid1.RowCount>0)
			{
				if(this.listView1.SelectedItems[0].SubItems[3].Text==strItemID)
				{
					this.label1.Text="不可以关联自身!";
					m_mthShowFindList(false);
					ctlDataGrid1.Focus();
					ctlDataGrid1.CurrentCell=new DataGridCell(this.ctlDataGrid1.CurrentCell.RowNumber,0);
					return;
				}
				for(int i1=0;i1<this.ctlDataGrid1.RowCount;i1++)
				{
					if(this.ctlDataGrid1[i1,4].ToString()==this.listView1.SelectedItems[0].SubItems[3].Text)
					{
						this.label1.Text="该收费项目已经存在!";
						m_mthShowFindList(false);
						ctlDataGrid1.Focus();
						ctlDataGrid1.CurrentCell=new DataGridCell(this.ctlDataGrid1.CurrentCell.RowNumber,0);
						return;
					}
				}
			}
			m_mthSeleItem();
			m_mthShowFindList(false);
			this.ctlDataGrid1.CurrentCell=new DataGridCell(this.ctlDataGrid1.CurrentCell.RowNumber,3);
		}

		private void listView2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				m_mthsele();
			}
		}

		private void listView2_DoubleClick(object sender, System.EventArgs e)
		{
			m_mthsele();
		}
		private void TextBox_Leave(object sender, EventArgs e)
		{
			try
			{
				if(int.Parse(ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber,14].ToString())<=4)
					this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber,7]=m_mthCountMed(this.ctlDataGrid1.CurrentCell.RowNumber);
			}
			catch
			{

			}
		}

        private void buttonXP1_Click(object sender, EventArgs e)
        {
            long m_lngRes = -1;
            if (ctlDataGrid1.RowCount >0)
            { 
               if(DialogResult.OK==MessageBox.Show("是否同步诊疗字典？","iCare提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1))
               {
                  int m_intRowsCount=ctlDataGrid1.RowCount;
          
                  clsChargeItemSynToOrderDic[] m_objChargeItemToOrderArr=new clsChargeItemSynToOrderDic[m_intRowsCount];
                  for (int i = 0; i < m_intRowsCount; i++)
                  {
                      m_objChargeItemToOrderArr[i] = new clsChargeItemSynToOrderDic();
                      m_objChargeItemToOrderArr[i].m_strSubChargeItemID = this.ctlDataGrid1[i, "ITEMID_CHR"].ToString().Trim();
                      m_objChargeItemToOrderArr[i].m_strChargeItemID = this.strItemID.ToString().Trim();

                      if (this.ctlDataGrid1[i, "USESCOPE_INT"].ToString().Trim() == "所有主项目")
                      {
                          //默认为主项目即m_objChargeItemToOrder.m_intUseScope=0
                          m_objChargeItemToOrderArr[i].m_intUseScope = 1;
                      }
                      if (this.ctlDataGrid1[i, "CONTINUEUSETYPE_INT"].ToString().Trim() == "首次用")
                      {
                          //默认为主项目即m_objChargeItemToOrder.m_intContinueUseType=0
                          m_objChargeItemToOrderArr[i].m_intContinueUseType = 1;
                      }
                      m_objChargeItemToOrderArr[i].m_intQuality = int.Parse(this.ctlDataGrid1[i, "QTY_INT"].ToString().Trim());
                  }
                  m_lngRes = domainCharge.m_mthChargeItemSynOrderDic(m_objChargeItemToOrderArr);
                  if (m_lngRes > 0)
                  {
                      MessageBox.Show("同步诊疗字典成功！", "iCare提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  }
                  else
                  {
                      MessageBox.Show("同步诊疗字典失败！", "iCare提示信息", MessageBoxButtons.OK, MessageBoxIcon.Question);
                  }
               }
            }
            else
            {
                clsChargeItemSynToOrderDic[] m_objChargeItemToOrderArr=new clsChargeItemSynToOrderDic [1];
                m_objChargeItemToOrderArr[0] = new clsChargeItemSynToOrderDic();
                m_objChargeItemToOrderArr[0].m_strChargeItemID=this.strItemID.ToString().Trim();
                m_objChargeItemToOrderArr[0].m_intQuality=0;
                m_objChargeItemToOrderArr[0].m_intType=1;
                m_objChargeItemToOrderArr[0].m_intUseScope=0;
                m_objChargeItemToOrderArr[0].m_strSubChargeItemID=string.Empty;
                m_lngRes = domainCharge.m_mthChargeItemSynOrderDic(m_objChargeItemToOrderArr);
                if (m_lngRes > 0)
                {
                    MessageBox.Show("同步诊疗字典成功！", "iCare提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("同步诊疗字典失败！", "iCare提示信息", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
        }
	}
}
