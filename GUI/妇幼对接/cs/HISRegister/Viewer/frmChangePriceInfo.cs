using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmChangePriceInfo 的摘要说明。
	/// </summary>
	public class frmChangePriceInfo  : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private clsDcl_DoctorWorkstation objSvc=null;
		private com.digitalwave.controls.datagrid.ctlDataGrid ctlDataGrid1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmChangePriceInfo()
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
			this.ctlDataGrid1 = new com.digitalwave.controls.datagrid.ctlDataGrid();
			((System.ComponentModel.ISupportInitialize)(this.ctlDataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// ctlDataGrid1
			// 
			this.ctlDataGrid1.AllowAddNew = false;
			this.ctlDataGrid1.AllowDelete = true;
			this.ctlDataGrid1.AutoAppendRow = false;
			this.ctlDataGrid1.AutoScroll = true;
			this.ctlDataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
			this.ctlDataGrid1.CaptionText = "";
			this.ctlDataGrid1.CaptionVisible = false;
			this.ctlDataGrid1.ColumnHeadersVisible = true;
			clsColumnInfo1.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo1.BackColor = System.Drawing.Color.White;
			clsColumnInfo1.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo1.ColumnIndex = 0;
			clsColumnInfo1.ColumnName = "ITEMCODE_VCHR";
			clsColumnInfo1.ColumnWidth = 75;
			clsColumnInfo1.Enabled = false;
			clsColumnInfo1.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo1.HeadText = "助记码";
			clsColumnInfo1.ReadOnly = true;
			clsColumnInfo1.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo2.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo2.BackColor = System.Drawing.Color.White;
			clsColumnInfo2.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo2.ColumnIndex = 1;
			clsColumnInfo2.ColumnName = "ITEMNAME_VCHR";
			clsColumnInfo2.ColumnWidth = 170;
			clsColumnInfo2.Enabled = false;
			clsColumnInfo2.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo2.HeadText = "项目名称";
			clsColumnInfo2.ReadOnly = true;
			clsColumnInfo2.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo3.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo3.BackColor = System.Drawing.Color.White;
			clsColumnInfo3.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo3.ColumnIndex = 2;
			clsColumnInfo3.ColumnName = "PREPRICE_MNY";
			clsColumnInfo3.ColumnWidth = 75;
			clsColumnInfo3.Enabled = false;
			clsColumnInfo3.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo3.HeadText = "原价";
			clsColumnInfo3.ReadOnly = true;
			clsColumnInfo3.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo4.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo4.BackColor = System.Drawing.Color.White;
			clsColumnInfo4.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo4.ColumnIndex = 3;
			clsColumnInfo4.ColumnName = "CURPRICE_MNY";
			clsColumnInfo4.ColumnWidth = 75;
			clsColumnInfo4.Enabled = false;
			clsColumnInfo4.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo4.HeadText = "现价";
			clsColumnInfo4.ReadOnly = true;
			clsColumnInfo4.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo5.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo5.BackColor = System.Drawing.Color.White;
			clsColumnInfo5.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo5.ColumnIndex = 4;
			clsColumnInfo5.ColumnName = "EFFECT_DAT";
			clsColumnInfo5.ColumnWidth = 120;
			clsColumnInfo5.Enabled = false;
			clsColumnInfo5.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo5.HeadText = "调价日期";
			clsColumnInfo5.ReadOnly = true;
			clsColumnInfo5.TextFont = new System.Drawing.Font("宋体", 10F);
			this.ctlDataGrid1.Columns.Add(clsColumnInfo1);
			this.ctlDataGrid1.Columns.Add(clsColumnInfo2);
			this.ctlDataGrid1.Columns.Add(clsColumnInfo3);
			this.ctlDataGrid1.Columns.Add(clsColumnInfo4);
			this.ctlDataGrid1.Columns.Add(clsColumnInfo5);
			this.ctlDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ctlDataGrid1.FullRowSelect = true;
			this.ctlDataGrid1.Location = new System.Drawing.Point(0, 0);
			this.ctlDataGrid1.MultiSelect = false;
			this.ctlDataGrid1.Name = "ctlDataGrid1";
			this.ctlDataGrid1.ReadOnly = true;
			this.ctlDataGrid1.RowHeadersVisible = true;
			this.ctlDataGrid1.RowHeaderWidth = 35;
			this.ctlDataGrid1.SelectedRowBackColor = System.Drawing.Color.Blue;
			this.ctlDataGrid1.SelectedRowForeColor = System.Drawing.Color.White;
			this.ctlDataGrid1.Size = new System.Drawing.Size(600, 397);
			this.ctlDataGrid1.TabIndex = 0;
			// 
			// frmChangePriceInfo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(600, 397);
			this.Controls.Add(this.ctlDataGrid1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.Name = "frmChangePriceInfo";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "调价信息 ---按任意键退出";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChangePriceInfo_KeyDown);
			this.Load += new System.EventHandler(this.frmChangePriceInfo_Load);
			((System.ComponentModel.ISupportInitialize)(this.ctlDataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void frmChangePriceInfo_Load(object sender, System.EventArgs e)
		{
			
			this.GetData();
		}
		public clsDcl_DoctorWorkstation DataServer
		{
			set
			{
			this.objSvc =value;
			}
		}
		private string _ItemID ="";
		public string ItemID
		{
			set
			{
			_ItemID =value;
			}
		}
		private string _ItemCode ="";
		public string ItemCode
		{
			set
			{
				_ItemCode =value;
			}
		}
		private string _ItemName ="";
		public string ItemName
		{
			set
			{
				_ItemName =value;
			}
		}
		private string _ItemPrice ="";
		public string ItemPrice
		{
			set
			{
				_ItemPrice =value;
			}
		}
		private void GetData()
		{
			if(this._ItemID.Trim()=="")
			{
			return;
			}
			DataTable dt;
			if(this.objSvc ==null)
			{
			this.objSvc =new clsDcl_DoctorWorkstation();
			}
			long ret =objSvc.m_mthGetChangePriceInfo(_ItemID,out dt,"");
			if(dt.Rows.Count==0)
			{
			DataRow dr =dt.NewRow();
			dr["ITEMNAME_VCHR"] =_ItemName;
			dr["ITEMCODE_VCHR"] =_ItemCode;
			dr["CURPRICE_MNY"] =_ItemPrice;
			dr["PREPRICE_MNY"] ="无调价信息";
			dt.Rows.Add(dr);
			}
			this.ctlDataGrid1.m_mthSetDataTable(dt);
		}

		private void frmChangePriceInfo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.Close();
		}
	

	}
}
