using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmRegisterDetail 的摘要说明。
	/// </summary>
	public class frmRegisterDetail :  com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		internal PinkieControls.ButtonXP buttonXP1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		internal System.Windows.Forms.ListView listView1;
		internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric m_txtPAYMENT_MNY;
		internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric m_txtDISCOUNT_DEC;
		internal PinkieControls.ButtonXP buttonXP2;
		internal com.digitalwave.controls.datagrid.ctlDataGrid m_dtgdetail;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmRegisterDetail()
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
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.buttonXP1 = new PinkieControls.ButtonXP();
			this.m_txtPAYMENT_MNY = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
			this.m_txtDISCOUNT_DEC = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
			this.buttonXP2 = new PinkieControls.ButtonXP();
			this.m_dtgdetail = new com.digitalwave.controls.datagrid.ctlDataGrid();
			
			this.SuspendLayout();
			// 
			// listView1
			// 
			this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1,
																						this.columnHeader2,
																						this.columnHeader3,
																						this.columnHeader4,
																						this.columnHeader5,
																						this.columnHeader6,
																						this.columnHeader7,
																						this.columnHeader8});
			this.listView1.Font = new System.Drawing.Font("宋体", 10.5F);
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			this.listView1.HideSelection = false;
			this.listView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.listView1.Location = new System.Drawing.Point(544, 456);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(160, 24);
			this.listView1.TabIndex = 0;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.Visible = false;
			this.listView1.Click += new System.EventHandler(this.listView1_SelectedIndexChanged);
			this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "挂号类型ID";
			this.columnHeader1.Width = 0;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "挂号类型";
			this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader2.Width = 80;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "费种ID";
			this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader3.Width = 0;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "费种名称";
			this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader4.Width = 80;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "身份ID";
			this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader5.Width = 0;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "病人身份";
			this.columnHeader6.Width = 80;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "费用";
			this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader7.Width = 80;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "优惠比例";
			this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader8.Width = 80;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.Location = new System.Drawing.Point(16, 424);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "费    用:";
			this.label1.Visible = false;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.Location = new System.Drawing.Point(16, 456);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "优惠比例:";
			this.label2.Visible = false;
			// 
			// buttonXP1
			// 
			this.buttonXP1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonXP1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.buttonXP1.DefaultScheme = true;
			this.buttonXP1.DialogResult = System.Windows.Forms.DialogResult.None;
			this.buttonXP1.Hint = "";
			this.buttonXP1.Location = new System.Drawing.Point(264, 456);
			this.buttonXP1.Name = "buttonXP1";
			this.buttonXP1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.buttonXP1.Size = new System.Drawing.Size(80, 32);
			this.buttonXP1.TabIndex = 5;
			this.buttonXP1.Text = "保存";
			this.buttonXP1.Click += new System.EventHandler(this.buttonXP1_Click);
			// 
			// m_txtPAYMENT_MNY
			// 
			this.m_txtPAYMENT_MNY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_txtPAYMENT_MNY.EnableAutoValidation = true;
			this.m_txtPAYMENT_MNY.EnableEnterKeyValidate = true;
			this.m_txtPAYMENT_MNY.EnableEscapeKeyUndo = true;
			this.m_txtPAYMENT_MNY.EnableLastValidValue = true;
			this.m_txtPAYMENT_MNY.ErrorProvider = null;
			this.m_txtPAYMENT_MNY.ErrorProviderMessage = "Invalid value";
			this.m_txtPAYMENT_MNY.ForceFormatText = true;
			this.m_txtPAYMENT_MNY.Location = new System.Drawing.Point(88, 416);
			this.m_txtPAYMENT_MNY.MaxLength = 10;
			this.m_txtPAYMENT_MNY.Name = "m_txtPAYMENT_MNY";
			this.m_txtPAYMENT_MNY.NumericCharStyle = ((SourceLibrary.Windows.Forms.NumericCharStyle)((SourceLibrary.Windows.Forms.NumericCharStyle.DecimalSeparator | SourceLibrary.Windows.Forms.NumericCharStyle.NegativeSymbol)));
			this.m_txtPAYMENT_MNY.Size = new System.Drawing.Size(144, 23);
			this.m_txtPAYMENT_MNY.TabIndex = 6;
			this.m_txtPAYMENT_MNY.Text = "";
			this.m_txtPAYMENT_MNY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_txtPAYMENT_MNY.Visible = false;
			this.m_txtPAYMENT_MNY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtPAYMENT_MNY_KeyDown);
			// 
			// m_txtDISCOUNT_DEC
			// 
			this.m_txtDISCOUNT_DEC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_txtDISCOUNT_DEC.EnableAutoValidation = true;
			this.m_txtDISCOUNT_DEC.EnableEnterKeyValidate = true;
			this.m_txtDISCOUNT_DEC.EnableEscapeKeyUndo = true;
			this.m_txtDISCOUNT_DEC.EnableLastValidValue = true;
			this.m_txtDISCOUNT_DEC.ErrorProvider = null;
			this.m_txtDISCOUNT_DEC.ErrorProviderMessage = "Invalid value";
			this.m_txtDISCOUNT_DEC.ForceFormatText = true;
			this.m_txtDISCOUNT_DEC.Location = new System.Drawing.Point(88, 456);
			this.m_txtDISCOUNT_DEC.MaxLength = 10;
			this.m_txtDISCOUNT_DEC.Name = "m_txtDISCOUNT_DEC";
			this.m_txtDISCOUNT_DEC.NumericCharStyle = ((SourceLibrary.Windows.Forms.NumericCharStyle)((SourceLibrary.Windows.Forms.NumericCharStyle.DecimalSeparator | SourceLibrary.Windows.Forms.NumericCharStyle.NegativeSymbol)));
			this.m_txtDISCOUNT_DEC.Size = new System.Drawing.Size(144, 23);
			this.m_txtDISCOUNT_DEC.TabIndex = 7;
			this.m_txtDISCOUNT_DEC.Text = "";
			this.m_txtDISCOUNT_DEC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_txtDISCOUNT_DEC.Visible = false;
			this.m_txtDISCOUNT_DEC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtDISCOUNT_DEC_KeyDown);
			// 
			// buttonXP2
			// 
			this.buttonXP2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonXP2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.buttonXP2.DefaultScheme = true;
			this.buttonXP2.DialogResult = System.Windows.Forms.DialogResult.None;
			this.buttonXP2.Hint = "";
			this.buttonXP2.Location = new System.Drawing.Point(392, 456);
			this.buttonXP2.Name = "buttonXP2";
			this.buttonXP2.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.buttonXP2.Size = new System.Drawing.Size(80, 32);
			this.buttonXP2.TabIndex = 8;
			this.buttonXP2.Text = "退出";
			this.buttonXP2.Click += new System.EventHandler(this.buttonXP2_Click);
			// 
			// m_dtgdetail
			// 
			this.m_dtgdetail.AllowAddNew = true;
			this.m_dtgdetail.AllowDelete = true;
			this.m_dtgdetail.AutoAppendRow = true;
			this.m_dtgdetail.AutoScroll = true;
			this.m_dtgdetail.CaptionText = "";
			this.m_dtgdetail.CaptionVisible = false;
			this.m_dtgdetail.ColumnHeadersVisible = true;
			this.m_dtgdetail.FullRowSelect = false;
			this.m_dtgdetail.Location = new System.Drawing.Point(0, 0);
			this.m_dtgdetail.Name = "m_dtgdetail";
			this.m_dtgdetail.ReadOnly = false;
			this.m_dtgdetail.RowHeadersVisible = true;
			this.m_dtgdetail.RowHeaderWidth = 35;
			this.m_dtgdetail.Size = new System.Drawing.Size(292, 220);
			this.m_dtgdetail.TabIndex = 0;
			// 
			// frmRegisterDetail
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(818, 495);
			this.Controls.Add(this.buttonXP2);
			this.Controls.Add(this.m_txtDISCOUNT_DEC);
			this.Controls.Add(this.m_txtPAYMENT_MNY);
			this.Controls.Add(this.buttonXP1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.listView1);
			this.Font = new System.Drawing.Font("宋体", 10.5F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "frmRegisterDetail";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "挂号费用维护";
			this.Load += new System.EventHandler(this.frmRegisterDetail_Load);
			
			this.ResumeLayout(false);

		}
		#endregion
		public override void CreateController()
		{
			this.objController=new com.digitalwave.iCare.gui.HIS.clsControlRegisterDetail();
			objController.Set_GUI_Apperance(this);
		}

		private void frmRegisterDetail_Load(object sender, System.EventArgs e)
		{
		((clsControlRegisterDetail)this.objController).m_mthLoadData();
		}

		private void buttonXP1_Click(object sender, System.EventArgs e)
		{
		((clsControlRegisterDetail)this.objController).m_mthSave();
		}

		private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
//			if(listView1.SelectedItems.Count>0)
//			{
//			this.m_txtPAYMENT_MNY.Text=listView1.SelectedItems[0].SubItems[6].Text.Trim();
//			this.m_txtDISCOUNT_DEC.Text=listView1.SelectedItems[0].SubItems[7].Text.Trim();
//			}
//			this.m_txtPAYMENT_MNY.Select();
		}

		private void m_txtPAYMENT_MNY_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
//			if(e.KeyCode==Keys.Enter)
//			{
//			m_txtDISCOUNT_DEC.Select();
//			}
		}

		private void m_txtDISCOUNT_DEC_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				this.buttonXP1_Click(null,null);
				listView1.Select();
				SendKeys.Send("{DOWN}");
				SendKeys.Send("{DOWN}");
			}
		}

		private void buttonXP2_Click(object sender, System.EventArgs e)
		{
			this.Close();
			//this.m_mthSetEnter2Tab()
		}
	
	}
	
}
