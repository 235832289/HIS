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
	/// FrmUsaGroup 的摘要说明。
	/// </summary>
	public class FrmUsaGroup :com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		#region 控件变量说明
		internal com.digitalwave.controls.datagrid.ctlDataGrid m_dtgUsa;
		private PinkieControls.ButtonXP m_btndeleteDetail;
		internal com.digitalwave.controls.datagrid.ctlDataGrid m_dtgGroup;
		private PinkieControls.ButtonXP m_btnRef;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel3;
		private PinkieControls.ButtonXP m_cmdAddNew;
		private PinkieControls.ButtonXP m_cmdChange;
		private PinkieControls.ButtonXP m_cmdClose;

		public string strUsageID = "";
		private clsDcl_OPCharge objSvc=new clsDcl_OPCharge();
		#endregion
		#region 构造函数
		public FrmUsaGroup()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();						
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//

			splitter1.MinExtra =m_dtgGroup.Width;
			clsDomain =new clsDomainControl_ChargeItem();
			this.m_GetUsage();
			m_dtgUsa_m_evtCurrentCellChanged(null,null);
		}
		clsDomainControl_ChargeItem clsDomain;
		//		public override void CreateController()
		//		{
		//			this.objController=new com.digitalwave.iCare.gui.HIS.clsControlUsageItem();
		//			objController.Set_GUI_Apperance(this);
		//		}
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

		#endregion
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
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo25 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo26 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo27 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo28 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_dtgGroup = new com.digitalwave.controls.datagrid.ctlDataGrid();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_dtgUsa = new com.digitalwave.controls.datagrid.ctlDataGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_btndeleteDetail = new PinkieControls.ButtonXP();
            this.m_cmdAddNew = new PinkieControls.ButtonXP();
            this.m_cmdChange = new PinkieControls.ButtonXP();
            this.m_btnRef = new PinkieControls.ButtonXP();
            this.m_cmdClose = new PinkieControls.ButtonXP();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgGroup)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgUsa)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.m_dtgGroup);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(260, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(708, 469);
            this.panel3.TabIndex = 65;
            // 
            // m_dtgGroup
            // 
            this.m_dtgGroup.AllowAddNew = false;
            this.m_dtgGroup.AllowDelete = false;
            this.m_dtgGroup.AutoAppendRow = false;
            this.m_dtgGroup.AutoScroll = true;
            this.m_dtgGroup.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.m_dtgGroup.BackgroundColor = System.Drawing.SystemColors.Window;
            this.m_dtgGroup.CaptionText = "";
            this.m_dtgGroup.CaptionVisible = false;
            this.m_dtgGroup.ColumnHeadersVisible = true;
            clsColumnInfo1.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo1.BackColor = System.Drawing.Color.White;
            clsColumnInfo1.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo1.ColumnIndex = 0;
            clsColumnInfo1.ColumnName = "NO";
            clsColumnInfo1.ColumnWidth = 0;
            clsColumnInfo1.Enabled = false;
            clsColumnInfo1.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo1.HeadText = "明细编号";
            clsColumnInfo1.ReadOnly = true;
            clsColumnInfo1.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo2.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo2.BackColor = System.Drawing.Color.White;
            clsColumnInfo2.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo2.ColumnIndex = 1;
            clsColumnInfo2.ColumnName = "ITEMID_CHR";
            clsColumnInfo2.ColumnWidth = 0;
            clsColumnInfo2.Enabled = false;
            clsColumnInfo2.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo2.HeadText = "项目编号";
            clsColumnInfo2.ReadOnly = true;
            clsColumnInfo2.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo3.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo3.BackColor = System.Drawing.Color.White;
            clsColumnInfo3.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo3.ColumnIndex = 2;
            clsColumnInfo3.ColumnName = "ITEMNAME_VCHR";
            clsColumnInfo3.ColumnWidth = 150;
            clsColumnInfo3.Enabled = false;
            clsColumnInfo3.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo3.HeadText = "项目名称";
            clsColumnInfo3.ReadOnly = true;
            clsColumnInfo3.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo4.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo4.BackColor = System.Drawing.Color.White;
            clsColumnInfo4.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo4.ColumnIndex = 3;
            clsColumnInfo4.ColumnName = "ItemType";
            clsColumnInfo4.ColumnWidth = 50;
            clsColumnInfo4.Enabled = false;
            clsColumnInfo4.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo4.HeadText = "类型";
            clsColumnInfo4.ReadOnly = true;
            clsColumnInfo4.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo5.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo5.BackColor = System.Drawing.Color.White;
            clsColumnInfo5.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo5.ColumnIndex = 4;
            clsColumnInfo5.ColumnName = "ItemSpec";
            clsColumnInfo5.ColumnWidth = 75;
            clsColumnInfo5.Enabled = false;
            clsColumnInfo5.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo5.HeadText = "规格";
            clsColumnInfo5.ReadOnly = true;
            clsColumnInfo5.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo6.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo6.BackColor = System.Drawing.Color.White;
            clsColumnInfo6.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo6.ColumnIndex = 5;
            clsColumnInfo6.ColumnName = "ItemPrice";
            clsColumnInfo6.ColumnWidth = 75;
            clsColumnInfo6.Enabled = false;
            clsColumnInfo6.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo6.HeadText = "单价";
            clsColumnInfo6.ReadOnly = true;
            clsColumnInfo6.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo7.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo7.BackColor = System.Drawing.Color.White;
            clsColumnInfo7.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo7.ColumnIndex = 6;
            clsColumnInfo7.ColumnName = "ClinicNumberUnit";
            clsColumnInfo7.ColumnWidth = 75;
            clsColumnInfo7.Enabled = false;
            clsColumnInfo7.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo7.HeadText = "门诊数量";
            clsColumnInfo7.ReadOnly = true;
            clsColumnInfo7.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo8.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            clsColumnInfo8.BackColor = System.Drawing.Color.White;
            clsColumnInfo8.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo8.ColumnIndex = 7;
            clsColumnInfo8.ColumnName = "ClinicType";
            clsColumnInfo8.ColumnWidth = 75;
            clsColumnInfo8.Enabled = false;
            clsColumnInfo8.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo8.HeadText = "门诊类型";
            clsColumnInfo8.ReadOnly = true;
            clsColumnInfo8.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo9.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo9.BackColor = System.Drawing.Color.White;
            clsColumnInfo9.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo9.ColumnIndex = 8;
            clsColumnInfo9.ColumnName = "ITEMPRICE_MNY";
            clsColumnInfo9.ColumnWidth = 100;
            clsColumnInfo9.Enabled = false;
            clsColumnInfo9.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo9.HeadText = "门诊费用合计";
            clsColumnInfo9.ReadOnly = true;
            clsColumnInfo9.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo10.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo10.BackColor = System.Drawing.Color.White;
            clsColumnInfo10.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo10.ColumnIndex = 9;
            clsColumnInfo10.ColumnName = "BihNumberUnit";
            clsColumnInfo10.ColumnWidth = 75;
            clsColumnInfo10.Enabled = false;
            clsColumnInfo10.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo10.HeadText = "住院数量";
            clsColumnInfo10.ReadOnly = true;
            clsColumnInfo10.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo11.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            clsColumnInfo11.BackColor = System.Drawing.Color.White;
            clsColumnInfo11.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo11.ColumnIndex = 10;
            clsColumnInfo11.ColumnName = "BihType";
            clsColumnInfo11.ColumnWidth = 75;
            clsColumnInfo11.Enabled = false;
            clsColumnInfo11.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo11.HeadText = "住院类型";
            clsColumnInfo11.ReadOnly = true;
            clsColumnInfo11.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo12.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo12.BackColor = System.Drawing.Color.White;
            clsColumnInfo12.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo12.ColumnIndex = 11;
            clsColumnInfo12.ColumnName = "BIHITEMPRICE_MNY";
            clsColumnInfo12.ColumnWidth = 100;
            clsColumnInfo12.Enabled = false;
            clsColumnInfo12.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo12.HeadText = "住院费用合计";
            clsColumnInfo12.ReadOnly = true;
            clsColumnInfo12.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo13.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo13.BackColor = System.Drawing.Color.White;
            clsColumnInfo13.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo13.ColumnIndex = 12;
            clsColumnInfo13.ColumnName = "CONTINUEUSETYPENAME";
            clsColumnInfo13.ColumnWidth = 70;
            clsColumnInfo13.Enabled = false;
            clsColumnInfo13.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo13.HeadText = "续用类型";
            clsColumnInfo13.ReadOnly = true;
            clsColumnInfo13.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo14.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo14.BackColor = System.Drawing.Color.White;
            clsColumnInfo14.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo14.ColumnIndex = 13;
            clsColumnInfo14.ColumnName = "DOSAGE_DEC";
            clsColumnInfo14.ColumnWidth = 0;
            clsColumnInfo14.Enabled = false;
            clsColumnInfo14.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo14.HeadText = "剂量";
            clsColumnInfo14.ReadOnly = true;
            clsColumnInfo14.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo15.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo15.BackColor = System.Drawing.Color.White;
            clsColumnInfo15.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo15.ColumnIndex = 14;
            clsColumnInfo15.ColumnName = "DOSAGEUNIT_CHR";
            clsColumnInfo15.ColumnWidth = 0;
            clsColumnInfo15.Enabled = false;
            clsColumnInfo15.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo15.HeadText = "剂量单位";
            clsColumnInfo15.ReadOnly = true;
            clsColumnInfo15.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo16.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo16.BackColor = System.Drawing.Color.White;
            clsColumnInfo16.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo16.ColumnIndex = 15;
            clsColumnInfo16.ColumnName = "GetClinicUnit";
            clsColumnInfo16.ColumnWidth = 0;
            clsColumnInfo16.Enabled = false;
            clsColumnInfo16.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo16.HeadText = "门诊领量单位";
            clsColumnInfo16.ReadOnly = true;
            clsColumnInfo16.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo17.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo17.BackColor = System.Drawing.Color.White;
            clsColumnInfo17.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo17.ColumnIndex = 16;
            clsColumnInfo17.ColumnName = "GetBihUnit";
            clsColumnInfo17.ColumnWidth = 0;
            clsColumnInfo17.Enabled = false;
            clsColumnInfo17.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo17.HeadText = "住院领量单位";
            clsColumnInfo17.ReadOnly = true;
            clsColumnInfo17.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo18.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo18.BackColor = System.Drawing.Color.White;
            clsColumnInfo18.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo18.ColumnIndex = 17;
            clsColumnInfo18.ColumnName = "ClinicNumber";
            clsColumnInfo18.ColumnWidth = 0;
            clsColumnInfo18.Enabled = false;
            clsColumnInfo18.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo18.HeadText = "门诊数量";
            clsColumnInfo18.ReadOnly = true;
            clsColumnInfo18.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo19.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo19.BackColor = System.Drawing.Color.White;
            clsColumnInfo19.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo19.ColumnIndex = 18;
            clsColumnInfo19.ColumnName = "BihNumber";
            clsColumnInfo19.ColumnWidth = 0;
            clsColumnInfo19.Enabled = false;
            clsColumnInfo19.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo19.HeadText = "住院数量";
            clsColumnInfo19.ReadOnly = true;
            clsColumnInfo19.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo20.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo20.BackColor = System.Drawing.Color.White;
            clsColumnInfo20.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Int;
            clsColumnInfo20.ColumnIndex = 19;
            clsColumnInfo20.ColumnName = "CONTINUEUSETYPE_INT";
            clsColumnInfo20.ColumnWidth = 0;
            clsColumnInfo20.Enabled = false;
            clsColumnInfo20.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo20.HeadText = "续用类型";
            clsColumnInfo20.ReadOnly = true;
            clsColumnInfo20.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo21.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo21.BackColor = System.Drawing.Color.White;
            clsColumnInfo21.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo21.ColumnIndex = 0;
            clsColumnInfo21.ColumnName = "BIHEXECDEPTFLAG_INT";
            clsColumnInfo21.ColumnWidth = 0;
            clsColumnInfo21.Enabled = true;
            clsColumnInfo21.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo21.HeadText = "住院执行科室标志";
            clsColumnInfo21.ReadOnly = true;
            clsColumnInfo21.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo22.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo22.BackColor = System.Drawing.Color.White;
            clsColumnInfo22.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo22.ColumnIndex = 0;
            clsColumnInfo22.ColumnName = "bihexecdeptid_chr";
            clsColumnInfo22.ColumnWidth = 0;
            clsColumnInfo22.Enabled = true;
            clsColumnInfo22.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo22.HeadText = "指定科室Id";
            clsColumnInfo22.ReadOnly = true;
            clsColumnInfo22.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo23.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo23.BackColor = System.Drawing.Color.White;
            clsColumnInfo23.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo23.ColumnIndex = 0;
            clsColumnInfo23.ColumnName = "deptname_vchr";
            clsColumnInfo23.ColumnWidth = 0;
            clsColumnInfo23.Enabled = true;
            clsColumnInfo23.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo23.HeadText = "指定科室名称";
            clsColumnInfo23.ReadOnly = true;
            clsColumnInfo23.TextFont = new System.Drawing.Font("宋体", 10F);
            this.m_dtgGroup.Columns.Add(clsColumnInfo1);
            this.m_dtgGroup.Columns.Add(clsColumnInfo2);
            this.m_dtgGroup.Columns.Add(clsColumnInfo3);
            this.m_dtgGroup.Columns.Add(clsColumnInfo4);
            this.m_dtgGroup.Columns.Add(clsColumnInfo5);
            this.m_dtgGroup.Columns.Add(clsColumnInfo6);
            this.m_dtgGroup.Columns.Add(clsColumnInfo7);
            this.m_dtgGroup.Columns.Add(clsColumnInfo8);
            this.m_dtgGroup.Columns.Add(clsColumnInfo9);
            this.m_dtgGroup.Columns.Add(clsColumnInfo10);
            this.m_dtgGroup.Columns.Add(clsColumnInfo11);
            this.m_dtgGroup.Columns.Add(clsColumnInfo12);
            this.m_dtgGroup.Columns.Add(clsColumnInfo13);
            this.m_dtgGroup.Columns.Add(clsColumnInfo14);
            this.m_dtgGroup.Columns.Add(clsColumnInfo15);
            this.m_dtgGroup.Columns.Add(clsColumnInfo16);
            this.m_dtgGroup.Columns.Add(clsColumnInfo17);
            this.m_dtgGroup.Columns.Add(clsColumnInfo18);
            this.m_dtgGroup.Columns.Add(clsColumnInfo19);
            this.m_dtgGroup.Columns.Add(clsColumnInfo20);
            this.m_dtgGroup.Columns.Add(clsColumnInfo21);
            this.m_dtgGroup.Columns.Add(clsColumnInfo22);
            this.m_dtgGroup.Columns.Add(clsColumnInfo23);
            this.m_dtgGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dtgGroup.FullRowSelect = true;
            this.m_dtgGroup.Location = new System.Drawing.Point(0, 0);
            this.m_dtgGroup.MultiSelect = false;
            this.m_dtgGroup.Name = "m_dtgGroup";
            this.m_dtgGroup.ReadOnly = false;
            this.m_dtgGroup.RowHeadersVisible = true;
            this.m_dtgGroup.RowHeaderWidth = 20;
            this.m_dtgGroup.SelectedRowBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.m_dtgGroup.SelectedRowForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.m_dtgGroup.Size = new System.Drawing.Size(708, 469);
            this.m_dtgGroup.TabIndex = 2;
            this.m_dtgGroup.m_evtDoubleClickCell += new com.digitalwave.controls.datagrid.clsDGTextMouseClickEventHandler(this.m_dtgGroup_m_evtDoubleClickCell);
            this.m_dtgGroup.m_evtDataGridKeyDown += new System.Windows.Forms.KeyEventHandler(this.m_dtgGroup_m_evtDataGridKeyDown);
            this.m_dtgGroup.Load += new System.EventHandler(this.m_dtgGroup_Load);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitter1.Location = new System.Drawing.Point(256, 0);
            this.splitter1.MinSize = 100;
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(4, 469);
            this.splitter1.TabIndex = 64;
            this.splitter1.TabStop = false;
            this.splitter1.DoubleClick += new System.EventHandler(this.splitter1_DoubleClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_dtgUsa);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(256, 469);
            this.panel2.TabIndex = 63;
            // 
            // m_dtgUsa
            // 
            this.m_dtgUsa.AllowAddNew = true;
            this.m_dtgUsa.AllowDelete = true;
            this.m_dtgUsa.AutoAppendRow = true;
            this.m_dtgUsa.AutoScroll = true;
            this.m_dtgUsa.BackgroundColor = System.Drawing.SystemColors.Window;
            this.m_dtgUsa.CaptionText = "";
            this.m_dtgUsa.CaptionVisible = false;
            this.m_dtgUsa.ColumnHeadersVisible = true;
            clsColumnInfo24.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo24.BackColor = System.Drawing.Color.White;
            clsColumnInfo24.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo24.ColumnIndex = 0;
            clsColumnInfo24.ColumnName = "Column3";
            clsColumnInfo24.ColumnWidth = 0;
            clsColumnInfo24.Enabled = true;
            clsColumnInfo24.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo24.HeadText = "用法ID";
            clsColumnInfo24.ReadOnly = false;
            clsColumnInfo24.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo25.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo25.BackColor = System.Drawing.Color.White;
            clsColumnInfo25.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo25.ColumnIndex = 1;
            clsColumnInfo25.ColumnName = "Column1";
            clsColumnInfo25.ColumnWidth = 60;
            clsColumnInfo25.Enabled = false;
            clsColumnInfo25.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo25.HeadText = "用法编码";
            clsColumnInfo25.ReadOnly = true;
            clsColumnInfo25.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo26.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo26.BackColor = System.Drawing.Color.White;
            clsColumnInfo26.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo26.ColumnIndex = 2;
            clsColumnInfo26.ColumnName = "Column2";
            clsColumnInfo26.ColumnWidth = 100;
            clsColumnInfo26.Enabled = false;
            clsColumnInfo26.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo26.HeadText = "用法名称";
            clsColumnInfo26.ReadOnly = true;
            clsColumnInfo26.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo27.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo27.BackColor = System.Drawing.Color.White;
            clsColumnInfo27.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo27.ColumnIndex = 3;
            clsColumnInfo27.ColumnName = "Column4";
            clsColumnInfo27.ColumnWidth = 60;
            clsColumnInfo27.Enabled = false;
            clsColumnInfo27.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo27.HeadText = "拼音码";
            clsColumnInfo27.ReadOnly = true;
            clsColumnInfo27.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo28.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo28.BackColor = System.Drawing.Color.White;
            clsColumnInfo28.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo28.ColumnIndex = 4;
            clsColumnInfo28.ColumnName = "Column5";
            clsColumnInfo28.ColumnWidth = 60;
            clsColumnInfo28.Enabled = false;
            clsColumnInfo28.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo28.HeadText = "五笔码";
            clsColumnInfo28.ReadOnly = true;
            clsColumnInfo28.TextFont = new System.Drawing.Font("宋体", 10F);
            this.m_dtgUsa.Columns.Add(clsColumnInfo24);
            this.m_dtgUsa.Columns.Add(clsColumnInfo25);
            this.m_dtgUsa.Columns.Add(clsColumnInfo26);
            this.m_dtgUsa.Columns.Add(clsColumnInfo27);
            this.m_dtgUsa.Columns.Add(clsColumnInfo28);
            this.m_dtgUsa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dtgUsa.FullRowSelect = true;
            this.m_dtgUsa.Location = new System.Drawing.Point(0, 0);
            this.m_dtgUsa.MultiSelect = false;
            this.m_dtgUsa.Name = "m_dtgUsa";
            this.m_dtgUsa.ReadOnly = false;
            this.m_dtgUsa.RowHeadersVisible = true;
            this.m_dtgUsa.RowHeaderWidth = 20;
            this.m_dtgUsa.SelectedRowBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.m_dtgUsa.SelectedRowForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.m_dtgUsa.Size = new System.Drawing.Size(256, 469);
            this.m_dtgUsa.TabIndex = 0;
            this.m_dtgUsa.m_evtCurrentCellChanged += new System.EventHandler(this.m_dtgUsa_m_evtCurrentCellChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_btndeleteDetail);
            this.panel1.Controls.Add(this.m_cmdAddNew);
            this.panel1.Controls.Add(this.m_cmdChange);
            this.panel1.Controls.Add(this.m_btnRef);
            this.panel1.Controls.Add(this.m_cmdClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 469);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(968, 48);
            this.panel1.TabIndex = 62;
            // 
            // m_btndeleteDetail
            // 
            this.m_btndeleteDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btndeleteDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btndeleteDetail.DefaultScheme = true;
            this.m_btndeleteDetail.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btndeleteDetail.Hint = "";
            this.m_btndeleteDetail.Location = new System.Drawing.Point(612, 8);
            this.m_btndeleteDetail.Name = "m_btndeleteDetail";
            this.m_btndeleteDetail.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btndeleteDetail.Size = new System.Drawing.Size(104, 32);
            this.m_btndeleteDetail.TabIndex = 46;
            this.m_btndeleteDetail.Text = "删除(F4)";
            this.m_btndeleteDetail.Click += new System.EventHandler(this.m_btndeleteDetail_Click);
            // 
            // m_cmdAddNew
            // 
            this.m_cmdAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_cmdAddNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdAddNew.DefaultScheme = true;
            this.m_cmdAddNew.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAddNew.Hint = "";
            this.m_cmdAddNew.Location = new System.Drawing.Point(352, 8);
            this.m_cmdAddNew.Name = "m_cmdAddNew";
            this.m_cmdAddNew.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAddNew.Size = new System.Drawing.Size(104, 32);
            this.m_cmdAddNew.TabIndex = 45;
            this.m_cmdAddNew.Text = "新增(F2)";
            this.m_cmdAddNew.Click += new System.EventHandler(this.m_cmdAddNew_Click);
            // 
            // m_cmdChange
            // 
            this.m_cmdChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_cmdChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdChange.DefaultScheme = true;
            this.m_cmdChange.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdChange.Hint = "";
            this.m_cmdChange.Location = new System.Drawing.Point(482, 8);
            this.m_cmdChange.Name = "m_cmdChange";
            this.m_cmdChange.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdChange.Size = new System.Drawing.Size(104, 32);
            this.m_cmdChange.TabIndex = 45;
            this.m_cmdChange.Text = "修改(F3)";
            this.m_cmdChange.Click += new System.EventHandler(this.m_cmdChange_Click);
            // 
            // m_btnRef
            // 
            this.m_btnRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnRef.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnRef.DefaultScheme = true;
            this.m_btnRef.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnRef.Hint = "";
            this.m_btnRef.Location = new System.Drawing.Point(72, 8);
            this.m_btnRef.Name = "m_btnRef";
            this.m_btnRef.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnRef.Size = new System.Drawing.Size(104, 32);
            this.m_btnRef.TabIndex = 49;
            this.m_btnRef.Text = "刷新用法(F5)";
            this.m_btnRef.Click += new System.EventHandler(this.m_btnRef_Click);
            // 
            // m_cmdClose
            // 
            this.m_cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdClose.DefaultScheme = true;
            this.m_cmdClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdClose.Hint = "";
            this.m_cmdClose.Location = new System.Drawing.Point(742, 8);
            this.m_cmdClose.Name = "m_cmdClose";
            this.m_cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClose.Size = new System.Drawing.Size(104, 32);
            this.m_cmdClose.TabIndex = 46;
            this.m_cmdClose.Text = "关闭(Esc)";
            this.m_cmdClose.Click += new System.EventHandler(this.m_cmdClose_Click);
            // 
            // FrmUsaGroup
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(968, 517);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.KeyPreview = true;
            this.Name = "FrmUsaGroup";
            this.Text = "用法项目维护";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmUsaGroup_KeyDown);
            this.Load += new System.EventHandler(this.FrmUsaGroup_Load);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgGroup)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgUsa)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region 窗体事件
		private void FrmUsaGroup_Load(object sender, System.EventArgs e)
		{
		}
		private void FrmUsaGroup_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch(e.KeyCode)
			{
				case Keys.Escape:
					if(ActiveControl.ToString()!=m_dtgGroup.ToString())
					{	//避免自定义控件的一个Bug
						this.Close();
					}
					break;
				case Keys.F2:
					if(m_cmdAddNew.Visible && m_cmdAddNew.Enabled) m_cmdAddNew_Click(null, null);
					break;
				case Keys.F3:
					if(m_cmdChange.Visible && m_cmdChange.Enabled) m_cmdChange_Click(null, null);
					break;
				case Keys.F4:
					if(m_btndeleteDetail.Visible && m_btndeleteDetail.Enabled) m_btndeleteDetail_Click(null,null);
					break;
				case Keys.F5:
					if(m_btnRef.Visible && m_btnRef.Enabled) m_btnRef_Click(null,null);
					break;
			}
		}		
		#endregion
		#region 按钮事件
		private void m_cmdAddNew_Click(object sender, System.EventArgs e)
		{

			clsBridgeForUsaEdit objItem =new clsBridgeForUsaEdit();
			objItem.m_strUsageID =this.strUsageID;
			frmUsaEdit objfrmUsaEdit =new frmUsaEdit(objItem);
			objfrmUsaEdit.ShowDialog();

			m_FillItem();
			//			switch(objfrmUsaEdit.m_intResultState)
			//			{	//操作结果状态	{0、直接关闭(默认)；1、操作成功；2、操作失败；}
			//				case 0://0、直接关闭(默认)；
			//					//return;
			//					break;
			//				case 1://1、操作成功；
			//					m_FillItem();
			//					break;
			//				case 2://2、操作失败；
			//					//return;
			//					break;
			//			}
		}

		private void m_cmdChange_Click(object sender, System.EventArgs e)
		{
			clsBridgeForUsaEdit objItem =null;
			GetCurrentObj(out objItem);
			ArrayList objArr =new ArrayList();
			int location =this.m_dtgGroup.CurrentCell.RowNumber;
			for(int i=0;i<m_dtgGroup.RowCount;i++)
			{
				if(i==location)
				{
				continue;
				}
				objArr.Add(this.m_dtgGroup[i,1].ToString().Trim());
			}
			frmUsaEdit objfrmUsaEdit =new frmUsaEdit(objItem);
			objfrmUsaEdit.CurrentItem =objArr;
			objfrmUsaEdit.ShowDialog();

			m_FillItem();
			//			switch(objfrmUsaEdit.m_intResultState)
			//			{	//操作结果状态	{0、直接关闭(默认)；1、操作成功；2、操作失败；}
			//				case 0://0、直接关闭(默认)；
			//					//return;
			//					break;
			//				case 1://1、操作成功；
			//					m_FillItem();
			//					break;
			//				case 2://2、操作失败；
			//					//return;
			//					break;
			//			}
		}
		private void m_btndeleteDetail_Click(object sender, System.EventArgs e)
		{
			this.m_Del();
		}
		private void m_btnRef_Click(object sender, System.EventArgs e)
		{
			m_GetUsage();
		}
		private void m_cmdClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		#endregion
		#region ListView事件
		private void m_dtgUsa_m_evtCurrentCellChanged(object sender, System.EventArgs e)
		{
			if(this.m_dtgUsa.RowCount == 0) return;
			if(this.m_dtgUsa[this.m_dtgUsa.CurrentCell.RowNumber,0].ToString().Trim() != this.strUsageID)
			{
				this.strUsageID=this.m_dtgUsa[this.m_dtgUsa.CurrentCell.RowNumber,0].ToString().Trim();
				m_FillItem();
			}			
		}
		private void m_dtgGroup_m_evtDataGridKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch(e.KeyCode)
			{
				case Keys.F2:
					if(m_cmdAddNew.Visible && m_cmdAddNew.Enabled) m_cmdAddNew_Click(null, null);
					break;
				case Keys.F3:
					if(m_cmdChange.Visible && m_cmdChange.Enabled) m_cmdChange_Click(null, null);
					break;
				case Keys.F4:
					if(m_btndeleteDetail.Visible && m_btndeleteDetail.Enabled) m_btndeleteDetail_Click(null,null);
					break;
				case Keys.F5:
					if(m_btnRef.Visible && m_btnRef.Enabled) m_btnRef_Click(null,null);
					break;
			}
		}
		private void m_dtgGroup_m_evtDoubleClickCell(object sender, com.digitalwave.controls.datagrid.clsDGTextMouseClickEventArgs e)
		{
			if(m_cmdChange.Visible && m_cmdChange.Enabled) m_cmdChange_Click(null, null);
		}
		#endregion
		#region 其他事件
		private void splitter1_DoubleClick(object sender, System.EventArgs e)
		{
			if(splitter1.SplitPosition<150)
				splitter1.SplitPosition =256;
			else
				splitter1.SplitPosition =splitter1.MinSize;
		}
		#endregion
		
		#region 获取用法
		public void m_GetUsage()
		{
			m_dtgUsa.m_mthDeleteAllRow();
			com.digitalwave.iCare.ValueObject.clsUsageType_VO[] objResult = new com.digitalwave.iCare.ValueObject.clsUsageType_VO[0];
			long lngRes=clsDomain.m_lngGetUsage(out objResult,"");
			if(lngRes>0 && objResult.Length>0)
			{
				for(int i=0;i<objResult.Length;i++)
				{
					this.m_dtgUsa.m_mthAppendRow(new object[] {objResult[i].m_strUsageID,objResult[i].m_strUsageCode,objResult[i].m_strUsageName,objResult[i].m_strUsagePYCODE,objResult[i].m_strUsageWBCODE}); 
				}
			}			
		}
		#endregion
		#region 获取项目
		com.digitalwave.iCare.ValueObject.clsChargeItem_VO[] m_clsChargeItem_VO = new com.digitalwave.iCare.ValueObject.clsChargeItem_VO[0];
		public void m_FillItem()
		{
			com.digitalwave.iCare.ValueObject.clsChargeItem_VO[] objResult = this.m_clsChargeItem_VO;
			if(objResult.Length > 0)
			{
				return;
			}
			long lngRes = clsDomain.m_lngFindItemByUsageID(strUsageID,out objResult);
			this.m_dtgGroup.m_mthDeleteAllRow();
			if((lngRes>0)&&(objResult != null))
			{
				double dblTem =0;
				string strClinicUnit ="",strGetBihUnit ="",strClinicNumberUnit ="",strBihNumberUnit ="";
				for(int i=0; i<objResult.Length;i++)
				{
					GetUnit(objResult[i],out strClinicUnit,out strGetBihUnit);

					if(objResult[i].m_intCLINICTYPE_INT==1)//门诊领量单位
					{
						strClinicNumberUnit =objResult[i].m_strUNITPRICE.Trim() + strClinicUnit.Trim();
					}
					else if(objResult[i].m_intCLINICTYPE_INT==2)
					{
						strClinicNumberUnit =objResult[i].m_strUNITPRICE.Trim() + objResult[i].m_DosageUnit.m_strUnitID;
					}
					if(objResult[i].m_intBIHTYPE_INT==1)//门诊领量单位
					{
						strBihNumberUnit =objResult[i].m_dblBIHQTY_DEC.ToString().Trim() + strGetBihUnit.Trim();
					}
					else if(objResult[i].m_intBIHTYPE_INT==2)
					{
						strBihNumberUnit =objResult[i].m_dblBIHQTY_DEC.ToString().Trim() + objResult[i].m_DosageUnit.m_strUnitID;
					}
					dblTem =0;
					try
					{
						dblTem = double.Parse(objResult[i].m_strTOTALPRICE);
					}
					catch{}

					this.m_dtgGroup.m_mthAppendRow(new object[] {	objResult[i].m_ItemOPInvType.m_strTypeID,
																	objResult[i].m_strItemID,
																	objResult[i].m_strItemName,
																	m_mthConvertToChType(objResult[i].m_ItemCat.m_strItemCatID),
																	objResult[i].m_strItemSpec,																	
																	objResult[i].m_fltItemPrice.ToString("0.0000"),
																	strClinicNumberUnit,
																	(objResult[i].m_intCLINICTYPE_INT==1)?"门诊领量单位":"门诊剂量单位",
																	dblTem.ToString("0.00"),
																	strBihNumberUnit,
																	(objResult[i].m_intBIHTYPE_INT==1)?"住院领量单位":"住院剂量单位",
																	"",
																	strGetContinueUseTypeName(objResult[i].m_intCONTINUEUSETYPE_INT),
																	objResult[i].m_strDosage.ToString(),
																	objResult[i].m_DosageUnit.m_strUnitID,
																	strClinicUnit,
																	strGetBihUnit,
																	objResult[i].m_strUNITPRICE,
																	objResult[i].m_dblBIHQTY_DEC,
																	objResult[i].m_intCONTINUEUSETYPE_INT,
                                                                    objResult[i].m_intBihExecDeptflag,
                                                                    objResult[i].m_strBihExecDeptID,
                                                                    objResult[i].m_strBihExecDeptName
																}); 
					this.m_dtgGroup.BeginUpdate();
					if(objResult[i].m_intStopFlag==1&&objResult[i].m_intItemSrcType==1)
					{
						for(int f2=0;f2<this.m_dtgGroup.Columns.Count;f2++)
						{
							this.m_dtgGroup.m_mthFormatCell(i,f2,m_dtgGroup.Font,System.Drawing.Color.White,System.Drawing.Color.Red);
						}

					}
					this.m_dtgGroup.EndUpdate();
					//填充门诊费用合计、住院费用合计
					m_mthCalMoney(objResult);
				}
			}
		}
		#endregion
		#region 删除项目
		/// <summary>
		/// 删除项目
		/// </summary>
		public void m_Del()
		{
			if(this.m_dtgGroup.RowCount==0)	return;	
			com.digitalwave.iCare.ValueObject.clsChargeItemUsageGroup_VO clsVO=new com.digitalwave.iCare.ValueObject.clsChargeItemUsageGroup_VO();
			clsVO.m_strItemID =this.m_dtgGroup[this.m_dtgGroup.CurrentCell.RowNumber,1].ToString();
			clsVO.m_strUsageID =this.strUsageID;
			if(strUsageID.Trim()!="" && MessageBox.Show("确定删除选中项吗?","提示框!",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
				clsVO.m_intFlag=0;
				if(MessageBox.Show("是否删除其他同法的此项目?","提示框!",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
					clsVO.m_intFlag=1;
				}
				long lngRes=clsDomain.m_lngDelUsageGroupByID(clsVO);
				if(lngRes>0)
				{			
					MessageBox.Show("操作成功!","提示框!",MessageBoxButtons.OK,MessageBoxIcon.Information);
					this.m_dtgGroup.m_mthDeleteRow(this.m_dtgGroup.CurrentCell.RowNumber);
				}
				else
				{
					MessageBox.Show("操作失败!","提示框!",MessageBoxButtons.OK,MessageBoxIcon.Information);				
				}
			}
		}
		#endregion

		#region 私有方法
		/// <summary>
		/// 获取当前选中行的对象
		/// </summary>
		/// <param name="p_objResult"></param>
		/// <returns>返回是否获取成功</returns>
		private void GetCurrentObj(out clsBridgeForUsaEdit p_objResult)
		{
			p_objResult =new clsBridgeForUsaEdit();
			//用法ID
			p_objResult.m_strUsageID =this.strUsageID;
			if(m_dtgGroup.CurrentCell.RowNumber<0 || m_dtgGroup.CurrentCell.RowNumber>=m_dtgGroup.RowCount)
			{
				return;
			}
			int intRow =m_dtgGroup.CurrentCell.RowNumber;
			//填充值
			//项目ID
			p_objResult.m_strItemID =this.m_dtgGroup[intRow,"ITEMID_CHR"].ToString();
			//项目名称
			p_objResult.m_strItemName =this.m_dtgGroup[intRow,"ITEMNAME_VCHR"].ToString();
			//项目类型
			p_objResult.m_strItemType =this.m_dtgGroup[intRow,"ItemType"].ToString();
			//项目规格
			p_objResult.m_strItemSpec =this.m_dtgGroup[intRow,"ItemSpec"].ToString();
			//住院单价
			p_objResult.m_strItemPrice =this.m_dtgGroup[intRow,"ItemPrice"].ToString();
			//门诊数量	[不包括单位]
			p_objResult.m_strUNITPRICE =this.m_dtgGroup[intRow,"ClinicNumber"].ToString().Trim();
			//门诊数量单位
			string strTem =m_dtgGroup[intRow,"ClinicType"].ToString().Trim();
			if(m_dtgGroup[intRow,"ClinicType"]!=System.DBNull.Value) p_objResult.m_intCLINICTYPE_INT =(strTem=="门诊领量单位")?1:2;
			//门诊费用合计
			p_objResult.m_strTOTALPRICE=this.m_dtgGroup[intRow,"ITEMPRICE_MNY"].ToString().Trim();
			//住院数量	[不包括单位]
			if(m_dtgGroup[intRow,"BihNumber"]!=System.DBNull.Value) p_objResult.m_dblBIHQTY_DEC =double.Parse(m_dtgGroup[intRow,"BihNumber"].ToString());
			//住院数量单位
			strTem =m_dtgGroup[intRow,"BihType"].ToString().Trim();
			if(m_dtgGroup[intRow,"BihType"]!=System.DBNull.Value) p_objResult.m_intBIHTYPE_INT =(strTem=="住院领量单位")?1:2;
			//住院费用合计
			p_objResult.m_strBihOtalPrice =this.m_dtgGroup[intRow,"BIHITEMPRICE_MNY"].ToString();
			//单位剂量
			try
			{
				p_objResult.m_dblDOSAGE_DEC =Convert.ToDouble(m_dtgGroup[intRow,"DOSAGE_DEC"].ToString());
			}
			catch{}
			//剂量单位
			p_objResult.m_strDOSAGEUNIT_CHR =this.m_dtgGroup[intRow,"DOSAGEUNIT_CHR"].ToString();
			//门诊领量单位
			p_objResult.m_strGetClinicUnit =this.m_dtgGroup[intRow,"GetClinicUnit"].ToString();
			//住院领量单位
			p_objResult.m_strGetBihUnit =this.m_dtgGroup[intRow,"GetBihUnit"].ToString();
			//续用类型 {0=不续用;1=全部续用;2-长嘱续用}
			p_objResult.m_intCONTINUEUSETYPE_INT =Convert.ToInt32(this.m_dtgGroup[intRow,"CONTINUEUSETYPE_INT"].ToString());

            // 住院执行科室
            p_objResult.m_intBihExecDeptflag = (this.m_dtgGroup[intRow, "BIHEXECDEPTFLAG_INT"] == DBNull.Value ? 1 : Convert.ToInt32(this.m_dtgGroup[intRow, "BIHEXECDEPTFLAG_INT"]));
            p_objResult.m_strBihExecDeptID = this.m_dtgGroup[intRow, "bihexecdeptid_chr"].ToString();
            p_objResult.m_strBihExecDeptName = this.m_dtgGroup[intRow, "deptname_vchr"].ToString();
		}
		/// <summary>
		/// 获取领量单位
		/// </summary>
		/// <param name="p_objItem"></param>
		/// <param name="p_strClinicUnit">[out 参数] 门诊领量单位</param>
		/// <param name="p_strGetBihUnit">[out 参数] 住院领量单位</param>
		private void GetUnit(com.digitalwave.iCare.ValueObject.clsChargeItem_VO p_objItem,out string p_strClinicUnit,out string p_strGetBihUnit)
		{
			p_strClinicUnit ="";
			p_strGetBihUnit ="";
			if(p_objItem==null) return;

			int intGetType =0;
			//门诊单位
			intGetType =0;//门诊收费单位 0 －基本单位 1－最小单位
			try{intGetType =Convert.ToInt32(p_objItem.m_intOPCHARGEFLG_INT);}
			catch{}
			try
			{
				if(intGetType==0)
					p_strClinicUnit =p_objItem.m_ItemOPUnit.m_strUnitID;//基本单位
				else
					p_strClinicUnit =p_objItem.m_ItemIPUnit.m_strUnitID;//最小单位
			}
			catch{}

			//住院单位
			intGetType =0;//住院收费单位 0 －基本单位 1－最小单位
			try{intGetType =Convert.ToInt32(p_objItem.m_intIPCHARGEFLG_INT);}
			catch{}
			try
			{
				if(intGetType==0)
					p_strGetBihUnit =p_objItem.m_ItemOPUnit.m_strUnitID;//基本单位
				else
					p_strGetBihUnit =p_objItem.m_ItemIPUnit.m_strUnitID;//最小单位
			}
			catch{}
		}
		private string m_mthConvertToChType(string strTypeNo)
		{
			string strRet="西药";
			switch(strTypeNo)
			{
				case "0002":
					strRet="中药";
					break;
				case "0003":
					strRet="检验";
					break;
				case "0004":
					strRet="治疗";
					break;
				case "0005":
					strRet="其他";
					break;
				case "0006":
					strRet="手术";
					break;
				default:
					strRet="西药";
					break;
			}
			return strRet;
		}
		private void m_mthCalMoney(clsChargeItem_VO[] objResult)
		{
			clsDcl_ChargeItem objChargeItem =new clsDcl_ChargeItem();
			double dblPrice =0,dblUnitDosage =0,dblMoney =0,dblQTY =0;
			int intTIMES =1,intType =0;
			string strTem ="";
			for(int i=0;i<this.m_dtgGroup.RowCount;i++)
			{
				dblPrice =0;
				dblUnitDosage =0;
				dblMoney =0;
				dblQTY =0;
				intType =0;
				if(m_dtgGroup[i,"ItemPrice"]!=System.DBNull.Value) dblPrice =double.Parse(m_dtgGroup[i,"ItemPrice"].ToString());
				try
				{
					if(m_dtgGroup[i,"DOSAGE_DEC"]!=System.DBNull.Value) dblUnitDosage =double.Parse(m_dtgGroup[i,"DOSAGE_DEC"].ToString());
				}
				catch{}
				//求门诊费用
				if(m_dtgGroup[i,"ClinicNumber"]!=System.DBNull.Value) dblQTY =double.Parse(m_dtgGroup[i,"ClinicNumber"].ToString());
				strTem =m_dtgGroup[i,"ClinicType"].ToString().Trim();
				if(m_dtgGroup[i,"ClinicType"]!=System.DBNull.Value) intType =(strTem=="门诊领量单位")?1:2;
				objChargeItem.m_lngGetChargeClinicUsage(dblPrice,intTIMES,dblQTY,intType,dblUnitDosage,out dblMoney);
				m_dtgGroup[i,"ITEMPRICE_MNY"] =dblMoney.ToString("0.00");	

				//求住院费用
				dblQTY =0;intType =0;
				if(m_dtgGroup[i,"BihNumber"]!=System.DBNull.Value) dblQTY =double.Parse(m_dtgGroup[i,"BihNumber"].ToString());
				strTem =m_dtgGroup[i,"BihType"].ToString().Trim();
				if(m_dtgGroup[i,"BihType"]!=System.DBNull.Value) intType =(strTem=="住院领量单位")?1:2;
				objChargeItem.m_lngGetChargeBIHUsage(dblPrice,intTIMES,dblQTY,intType,dblUnitDosage,out dblMoney);
				m_dtgGroup[i,"BIHITEMPRICE_MNY"] =dblMoney.ToString("0.00");
			}
		}
		private decimal m_mthConvertToDecimal(object obj)
		{
			decimal ret=0;
			try
			{
				if(obj!=null)
				{
			
					ret=decimal.Parse(obj.ToString());
				}
			}
			catch
			{
				ret=0;
			}
			return ret;
		
		}
		/// <summary>
		/// 返回续用类型名称表示 根据续用类型
		/// </summary>
		/// <param name="p_intType">续用类型 {0=不续用;1=全部续用;2-长嘱续用}</param>
		/// <returns></returns>
		private string strGetContinueUseTypeName(int p_intType)
		{
			string strRes ="";
			switch(p_intType)
			{
				case 0:
					strRes ="连续用";
					break;
				case 1:
					strRes ="首次用";
					break;
				default:
					strRes ="";
					break;
			}
			return strRes;
		}
		#endregion

		private void m_dtgGroup_Load(object sender, System.EventArgs e)
		{
		
		}

	}
}
