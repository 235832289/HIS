using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmMedicineSource 的摘要说明。
	/// </summary>
	public class frmMedicineSource : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.Panel panel1;
		internal com.digitalwave.controls.datagrid.ctlDataGrid ctlDataGrid1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel5;
		private PinkieControls.ButtonXP btExit;
		internal PinkieControls.ButtonXP btSave;
		private PinkieControls.ButtonXP btFind;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		internal System.Windows.Forms.TextBox txtSourceName;
		internal System.Windows.Forms.TextBox txtSourceID;
		internal System.Windows.Forms.TextBox m_txtFind;
		internal System.Windows.Forms.ComboBox m_cmbFind;
		private System.Windows.Forms.Panel panel3;
		internal System.Windows.Forms.TextBox m_txtFindChargItem;
		internal System.Windows.Forms.ComboBox m_cboFindCharge;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Panel panel4;
		internal com.digitalwave.controls.datagrid.ctlDataGrid ctlDataGrid2;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMedicineSource()
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
			this.objController=new com.digitalwave.iCare.gui.HIS.clsCtl_MedicineSource();
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.ctlDataGrid1 = new com.digitalwave.controls.datagrid.ctlDataGrid();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel5 = new System.Windows.Forms.Panel();
			this.btExit = new PinkieControls.ButtonXP();
			this.btSave = new PinkieControls.ButtonXP();
			this.btFind = new PinkieControls.ButtonXP();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtSourceName = new System.Windows.Forms.TextBox();
			this.txtSourceID = new System.Windows.Forms.TextBox();
			this.m_txtFind = new System.Windows.Forms.TextBox();
			this.m_cmbFind = new System.Windows.Forms.ComboBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.m_txtFindChargItem = new System.Windows.Forms.TextBox();
			this.m_cboFindCharge = new System.Windows.Forms.ComboBox();
			this.label21 = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.ctlDataGrid2 = new com.digitalwave.controls.datagrid.ctlDataGrid();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ctlDataGrid1)).BeginInit();
			this.panel2.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ctlDataGrid2)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.ctlDataGrid1);
			this.panel1.Location = new System.Drawing.Point(8, 10);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(328, 584);
			this.panel1.TabIndex = 2;
			// 
			// ctlDataGrid1
			// 
			this.ctlDataGrid1.AllowAddNew = true;
			this.ctlDataGrid1.AllowDelete = true;
			this.ctlDataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.ctlDataGrid1.AutoAppendRow = true;
			this.ctlDataGrid1.AutoScroll = true;
			this.ctlDataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
			this.ctlDataGrid1.CaptionText = "";
			this.ctlDataGrid1.CaptionVisible = false;
			this.ctlDataGrid1.ColumnHeadersVisible = true;
			clsColumnInfo1.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo1.BackColor = System.Drawing.Color.White;
			clsColumnInfo1.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo1.ColumnIndex = 0;
			clsColumnInfo1.ColumnName = "ID";
			clsColumnInfo1.ColumnWidth = 75;
			clsColumnInfo1.Enabled = false;
			clsColumnInfo1.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo1.HeadText = "药品编号";
			clsColumnInfo1.ReadOnly = true;
			clsColumnInfo1.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo2.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo2.BackColor = System.Drawing.Color.White;
			clsColumnInfo2.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo2.ColumnIndex = 1;
			clsColumnInfo2.ColumnName = "Name";
			clsColumnInfo2.ColumnWidth = 200;
			clsColumnInfo2.Enabled = false;
			clsColumnInfo2.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo2.HeadText = "药品名称";
			clsColumnInfo2.ReadOnly = true;
			clsColumnInfo2.TextFont = new System.Drawing.Font("宋体", 10F);
			this.ctlDataGrid1.Columns.Add(clsColumnInfo1);
			this.ctlDataGrid1.Columns.Add(clsColumnInfo2);
			this.ctlDataGrid1.FullRowSelect = true;
			this.ctlDataGrid1.Location = new System.Drawing.Point(0, 0);
			this.ctlDataGrid1.MultiSelect = false;
			this.ctlDataGrid1.Name = "ctlDataGrid1";
			this.ctlDataGrid1.ReadOnly = true;
			this.ctlDataGrid1.RowHeadersVisible = true;
			this.ctlDataGrid1.RowHeaderWidth = 35;
			this.ctlDataGrid1.SelectedRowBackColor = System.Drawing.Color.Navy;
			this.ctlDataGrid1.SelectedRowForeColor = System.Drawing.Color.White;
			this.ctlDataGrid1.Size = new System.Drawing.Size(322, 584);
			this.ctlDataGrid1.TabIndex = 6;
			this.ctlDataGrid1.m_evtCurrentCellChanged += new System.EventHandler(this.ctlDataGrid1_m_evtCurrentCellChanged);
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel2.Controls.Add(this.panel5);
			this.panel2.Location = new System.Drawing.Point(344, 8);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(280, 408);
			this.panel2.TabIndex = 3;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.btExit);
			this.panel5.Controls.Add(this.btSave);
			this.panel5.Controls.Add(this.btFind);
			this.panel5.Controls.Add(this.label3);
			this.panel5.Controls.Add(this.label2);
			this.panel5.Controls.Add(this.txtSourceName);
			this.panel5.Controls.Add(this.txtSourceID);
			this.panel5.Controls.Add(this.m_txtFind);
			this.panel5.Controls.Add(this.m_cmbFind);
			this.panel5.Location = new System.Drawing.Point(8, 8);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(256, 392);
			this.panel5.TabIndex = 0;
			// 
			// btExit
			// 
			this.btExit.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btExit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btExit.DefaultScheme = true;
			this.btExit.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btExit.Hint = "";
			this.btExit.Location = new System.Drawing.Point(108, 320);
			this.btExit.Name = "btExit";
			this.btExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btExit.Size = new System.Drawing.Size(112, 32);
			this.btExit.TabIndex = 31;
			this.btExit.Text = "退出";
			this.btExit.Click += new System.EventHandler(this.btExit_Click);
			// 
			// btSave
			// 
			this.btSave.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btSave.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btSave.DefaultScheme = true;
			this.btSave.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btSave.Hint = "";
			this.btSave.Location = new System.Drawing.Point(108, 256);
			this.btSave.Name = "btSave";
			this.btSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btSave.Size = new System.Drawing.Size(112, 32);
			this.btSave.TabIndex = 30;
			this.btSave.Text = "保存";
			this.btSave.Click += new System.EventHandler(this.btSave_Click);
			// 
			// btFind
			// 
			this.btFind.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btFind.DefaultScheme = true;
			this.btFind.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btFind.Hint = "";
			this.btFind.Location = new System.Drawing.Point(176, 11);
			this.btFind.Name = "btFind";
			this.btFind.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btFind.Size = new System.Drawing.Size(56, 24);
			this.btFind.TabIndex = 29;
			this.btFind.Text = "查找";
			this.btFind.Click += new System.EventHandler(this.btFind_Click);
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(20, 200);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(70, 19);
			this.label3.TabIndex = 26;
			this.label3.Text = "药典名称:";
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(20, 136);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 19);
			this.label2.TabIndex = 25;
			this.label2.Text = "药典ID:";
			// 
			// txtSourceName
			// 
			this.txtSourceName.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtSourceName.BackColor = System.Drawing.Color.White;
			this.txtSourceName.Location = new System.Drawing.Point(100, 200);
			this.txtSourceName.Name = "txtSourceName";
			this.txtSourceName.ReadOnly = true;
			this.txtSourceName.Size = new System.Drawing.Size(128, 23);
			this.txtSourceName.TabIndex = 22;
			this.txtSourceName.Text = "";
			// 
			// txtSourceID
			// 
			this.txtSourceID.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtSourceID.BackColor = System.Drawing.Color.White;
			this.txtSourceID.Location = new System.Drawing.Point(100, 137);
			this.txtSourceID.Name = "txtSourceID";
			this.txtSourceID.ReadOnly = true;
			this.txtSourceID.Size = new System.Drawing.Size(128, 23);
			this.txtSourceID.TabIndex = 21;
			this.txtSourceID.Text = "";
			// 
			// m_txtFind
			// 
			this.m_txtFind.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_txtFind.Font = new System.Drawing.Font("宋体", 10.5F);
			this.m_txtFind.Location = new System.Drawing.Point(52, 56);
			this.m_txtFind.Name = "m_txtFind";
			this.m_txtFind.Size = new System.Drawing.Size(176, 23);
			this.m_txtFind.TabIndex = 20;
			this.m_txtFind.Text = "";
			// 
			// m_cmbFind
			// 
			this.m_cmbFind.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_cmbFind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cmbFind.Font = new System.Drawing.Font("宋体", 10.5F);
			this.m_cmbFind.Items.AddRange(new object[] {
														   "按药品ID查找",
														   "按助记码查找",
														   "按药品名称查找",
														   "按拼音简码查找",
														   "按五笔简码查找"});
			this.m_cmbFind.Location = new System.Drawing.Point(52, 12);
			this.m_cmbFind.Name = "m_cmbFind";
			this.m_cmbFind.Size = new System.Drawing.Size(120, 22);
			this.m_cmbFind.TabIndex = 19;
			this.m_cmbFind.SelectedIndexChanged += new System.EventHandler(this.m_cmbFind_SelectedIndexChanged);
			// 
			// panel3
			// 
			this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel3.Controls.Add(this.m_txtFindChargItem);
			this.panel3.Controls.Add(this.m_cboFindCharge);
			this.panel3.Controls.Add(this.label21);
			this.panel3.Location = new System.Drawing.Point(344, 424);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(280, 168);
			this.panel3.TabIndex = 4;
			// 
			// m_txtFindChargItem
			// 
			this.m_txtFindChargItem.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_txtFindChargItem.Location = new System.Drawing.Point(68, 104);
			this.m_txtFindChargItem.Name = "m_txtFindChargItem";
			this.m_txtFindChargItem.Size = new System.Drawing.Size(176, 23);
			this.m_txtFindChargItem.TabIndex = 84;
			this.m_txtFindChargItem.Text = "";
			this.m_txtFindChargItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtFindChargItem_KeyDown);
			this.m_txtFindChargItem.TextChanged += new System.EventHandler(this.m_txtFindChargItem_TextChanged);
			// 
			// m_cboFindCharge
			// 
			this.m_cboFindCharge.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_cboFindCharge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboFindCharge.Items.AddRange(new object[] {
																 "按编号查找",
																 "按名称查找"});
			this.m_cboFindCharge.Location = new System.Drawing.Point(68, 56);
			this.m_cboFindCharge.Name = "m_cboFindCharge";
			this.m_cboFindCharge.Size = new System.Drawing.Size(176, 22);
			this.m_cboFindCharge.TabIndex = 83;
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Font = new System.Drawing.Font("楷体_GB2312", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label21.Location = new System.Drawing.Point(88, 16);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(94, 27);
			this.label21.TabIndex = 82;
			this.label21.Text = "查找药典";
			this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel4
			// 
			this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel4.Controls.Add(this.ctlDataGrid2);
			this.panel4.Location = new System.Drawing.Point(632, 10);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(328, 584);
			this.panel4.TabIndex = 5;
			// 
			// ctlDataGrid2
			// 
			this.ctlDataGrid2.AllowAddNew = true;
			this.ctlDataGrid2.AllowDelete = true;
			this.ctlDataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.ctlDataGrid2.AutoAppendRow = true;
			this.ctlDataGrid2.AutoScroll = true;
			this.ctlDataGrid2.BackgroundColor = System.Drawing.SystemColors.Window;
			this.ctlDataGrid2.CaptionText = "";
			this.ctlDataGrid2.CaptionVisible = false;
			this.ctlDataGrid2.ColumnHeadersVisible = true;
			clsColumnInfo3.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo3.BackColor = System.Drawing.Color.White;
			clsColumnInfo3.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo3.ColumnIndex = 0;
			clsColumnInfo3.ColumnName = "ID";
			clsColumnInfo3.ColumnWidth = 75;
			clsColumnInfo3.Enabled = false;
			clsColumnInfo3.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo3.HeadText = "药典ID";
			clsColumnInfo3.ReadOnly = true;
			clsColumnInfo3.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo4.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo4.BackColor = System.Drawing.Color.White;
			clsColumnInfo4.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo4.ColumnIndex = 1;
			clsColumnInfo4.ColumnName = "Name";
			clsColumnInfo4.ColumnWidth = 200;
			clsColumnInfo4.Enabled = false;
			clsColumnInfo4.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo4.HeadText = "药典名称";
			clsColumnInfo4.ReadOnly = true;
			clsColumnInfo4.TextFont = new System.Drawing.Font("宋体", 10F);
			this.ctlDataGrid2.Columns.Add(clsColumnInfo3);
			this.ctlDataGrid2.Columns.Add(clsColumnInfo4);
			this.ctlDataGrid2.FullRowSelect = true;
			this.ctlDataGrid2.Location = new System.Drawing.Point(0, 0);
			this.ctlDataGrid2.MultiSelect = false;
			this.ctlDataGrid2.Name = "ctlDataGrid2";
			this.ctlDataGrid2.ReadOnly = true;
			this.ctlDataGrid2.RowHeadersVisible = true;
			this.ctlDataGrid2.RowHeaderWidth = 35;
			this.ctlDataGrid2.SelectedRowBackColor = System.Drawing.Color.Navy;
			this.ctlDataGrid2.SelectedRowForeColor = System.Drawing.Color.White;
			this.ctlDataGrid2.Size = new System.Drawing.Size(322, 584);
			this.ctlDataGrid2.TabIndex = 7;
			this.ctlDataGrid2.m_evtCurrentCellChanged += new System.EventHandler(this.ctlDataGrid2_m_evtCurrentCellChanged);
			// 
			// frmMedicineSource
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(968, 605);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("宋体", 10.5F);
			this.Name = "frmMedicineSource";
			this.Text = "药品药典对应";
			this.Resize += new System.EventHandler(this.frmMedicineSource_Resize);
			this.Load += new System.EventHandler(this.frmMedicineSource_Load);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ctlDataGrid1)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ctlDataGrid2)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void frmMedicineSource_Resize(object sender, System.EventArgs e)
		{
			this.panel5.Left=(this.panel2.Width-this.panel5.Width)/2;
			this.panel5.Top=(this.panel2.Height-this.panel5.Height)/2;
			m_cboFindCharge.Left=m_txtFind.Left+(this.panel2.Width-this.panel5.Width)/2;
			m_txtFindChargItem.Left=m_txtFind.Left+(this.panel2.Width-this.panel5.Width)/2;
		}

		private void frmMedicineSource_Load(object sender, System.EventArgs e)
		{
			((clsCtl_MedicineSource)this.objController).m_mthFormLoad();
		}

		private void m_cmbFind_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		((clsCtl_MedicineSource)this.objController).m_cmbFind_SelectedIndexChanged();
		}

		private void btFind_Click(object sender, System.EventArgs e)
		{
		((clsCtl_MedicineSource)this.objController).m_mthFindChargeItem(this.m_cmbFind.Tag.ToString(),this.m_txtFind.Text.Trim());
		}

		private void m_txtFindChargItem_TextChanged(object sender, System.EventArgs e)
		{
		((clsCtl_MedicineSource)this.objController).m_mthChangeText();
		}

		private void ctlDataGrid1_m_evtCurrentCellChanged(object sender, System.EventArgs e)
		{
		((clsCtl_MedicineSource)this.objController).m_mthDataGridCellChange();
		}

		private void ctlDataGrid2_m_evtCurrentCellChanged(object sender, System.EventArgs e)
		{
			((clsCtl_MedicineSource)this.objController).m_mthDataGridCellChange2();
		}

		private void btSave_Click(object sender, System.EventArgs e)
		{
		((clsCtl_MedicineSource)this.objController).m_mthSaveData();
		}

		private void btExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void m_txtFindChargItem_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				((clsCtl_MedicineSource)this.objController).m_FillChargeItem();
			}
		}
	}
}
