using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS 
{
	/// <summary>
	/// frmCMCookMethod 的摘要说明。
	/// </summary>
	public class frmCMCookMethod : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.Panel m_pnlViewList;
		private System.Windows.Forms.Panel m_pnlControls;
		private System.Windows.Forms.ColumnHeader colMNemonic;
		private System.Windows.Forms.Label m_blbMNemonic;
		public System.Windows.Forms.TextBox m_txtMNemonic;
		private PinkieControls.ButtonXP m_btnAddNew;
		private PinkieControls.ButtonXP m_btnSave;
		private PinkieControls.ButtonXP m_btnDelete;
		private PinkieControls.ButtonXP m_btnExit;
		private System.Windows.Forms.ColumnHeader colCookMethodName;
		private System.Windows.Forms.Label m_lblCookMethodName;
		public System.Windows.Forms.TextBox m_txtCookMethodName;
		internal System.Windows.Forms.ListView m_lst;
		private System.Windows.Forms.ColumnHeader colCookMethod;
		private System.Windows.Forms.ColumnHeader colCookMethodID;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCMCookMethod()
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
			this.m_pnlViewList = new System.Windows.Forms.Panel();
			this.m_lst = new System.Windows.Forms.ListView();
			this.colCookMethod = new System.Windows.Forms.ColumnHeader();
			this.colCookMethodID = new System.Windows.Forms.ColumnHeader();
			this.colCookMethodName = new System.Windows.Forms.ColumnHeader();
			this.colMNemonic = new System.Windows.Forms.ColumnHeader();
			this.m_pnlControls = new System.Windows.Forms.Panel();
			this.m_btnExit = new PinkieControls.ButtonXP();
			this.m_btnDelete = new PinkieControls.ButtonXP();
			this.m_btnSave = new PinkieControls.ButtonXP();
			this.m_btnAddNew = new PinkieControls.ButtonXP();
			this.m_blbMNemonic = new System.Windows.Forms.Label();
			this.m_lblCookMethodName = new System.Windows.Forms.Label();
			this.m_txtMNemonic = new System.Windows.Forms.TextBox();
			this.m_txtCookMethodName = new System.Windows.Forms.TextBox();
			this.m_pnlViewList.SuspendLayout();
			this.m_pnlControls.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_pnlViewList
			// 
			this.m_pnlViewList.Controls.Add(this.m_lst);
			this.m_pnlViewList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_pnlViewList.Location = new System.Drawing.Point(0, 0);
			this.m_pnlViewList.Name = "m_pnlViewList";
			this.m_pnlViewList.Size = new System.Drawing.Size(666, 383);
			this.m_pnlViewList.TabIndex = 0;
			// 
			// m_lst
			// 
			this.m_lst.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					this.colCookMethod,
																					this.colCookMethodID,
																					this.colCookMethodName,
																					this.colMNemonic});
			this.m_lst.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_lst.FullRowSelect = true;
			this.m_lst.GridLines = true;
			this.m_lst.HideSelection = false;
			this.m_lst.Location = new System.Drawing.Point(0, 0);
			this.m_lst.Name = "m_lst";
			this.m_lst.Size = new System.Drawing.Size(666, 383);
			this.m_lst.TabIndex = 0;
			this.m_lst.View = System.Windows.Forms.View.Details;
			this.m_lst.Click += new System.EventHandler(this.m_lst_SelectedIndexChanged);
			this.m_lst.SelectedIndexChanged += new System.EventHandler(this.m_lst_SelectedIndexChanged);
			// 
			// colCookMethod
			// 
			this.colCookMethod.Text = "";
			this.colCookMethod.Width = 0;
			// 
			// colCookMethodID
			// 
			this.colCookMethodID.Text = "编号";
			this.colCookMethodID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.colCookMethodID.Width = 67;
			// 
			// colCookMethodName
			// 
			this.colCookMethodName.Text = "煎制方法";
			this.colCookMethodName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.colCookMethodName.Width = 210;
			// 
			// colMNemonic
			// 
			this.colMNemonic.Text = "缩写";
			this.colMNemonic.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.colMNemonic.Width = 105;
			// 
			// m_pnlControls
			// 
			this.m_pnlControls.Controls.Add(this.m_btnExit);
			this.m_pnlControls.Controls.Add(this.m_btnDelete);
			this.m_pnlControls.Controls.Add(this.m_btnSave);
			this.m_pnlControls.Controls.Add(this.m_btnAddNew);
			this.m_pnlControls.Controls.Add(this.m_blbMNemonic);
			this.m_pnlControls.Controls.Add(this.m_lblCookMethodName);
			this.m_pnlControls.Controls.Add(this.m_txtMNemonic);
			this.m_pnlControls.Controls.Add(this.m_txtCookMethodName);
			this.m_pnlControls.Dock = System.Windows.Forms.DockStyle.Right;
			this.m_pnlControls.Location = new System.Drawing.Point(386, 0);
			this.m_pnlControls.Name = "m_pnlControls";
			this.m_pnlControls.Size = new System.Drawing.Size(280, 383);
			this.m_pnlControls.TabIndex = 1;
			this.m_pnlControls.Paint += new System.Windows.Forms.PaintEventHandler(this.m_pnlControls_Paint);
			// 
			// m_btnExit
			// 
			this.m_btnExit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnExit.DefaultScheme = true;
			this.m_btnExit.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnExit.Hint = "";
			this.m_btnExit.Location = new System.Drawing.Point(88, 264);
			this.m_btnExit.Name = "m_btnExit";
			this.m_btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnExit.Size = new System.Drawing.Size(120, 32);
			this.m_btnExit.TabIndex = 7;
			this.m_btnExit.Text = "退出(Esc)";
			this.m_btnExit.Click += new System.EventHandler(this.m_btnExit_Click);
			// 
			// m_btnDelete
			// 
			this.m_btnDelete.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnDelete.DefaultScheme = true;
			this.m_btnDelete.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnDelete.Hint = "";
			this.m_btnDelete.Location = new System.Drawing.Point(88, 224);
			this.m_btnDelete.Name = "m_btnDelete";
			this.m_btnDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnDelete.Size = new System.Drawing.Size(120, 32);
			this.m_btnDelete.TabIndex = 6;
			this.m_btnDelete.Text = "删除(&D)";
			this.m_btnDelete.Click += new System.EventHandler(this.m_btnDelete_Click);
			// 
			// m_btnSave
			// 
			this.m_btnSave.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnSave.DefaultScheme = true;
			this.m_btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnSave.Hint = "";
			this.m_btnSave.Location = new System.Drawing.Point(88, 184);
			this.m_btnSave.Name = "m_btnSave";
			this.m_btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnSave.Size = new System.Drawing.Size(120, 32);
			this.m_btnSave.TabIndex = 5;
			this.m_btnSave.Text = "保存(&S)";
			this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
			// 
			// m_btnAddNew
			// 
			this.m_btnAddNew.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnAddNew.DefaultScheme = true;
			this.m_btnAddNew.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnAddNew.Hint = "";
			this.m_btnAddNew.Location = new System.Drawing.Point(88, 144);
			this.m_btnAddNew.Name = "m_btnAddNew";
			this.m_btnAddNew.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnAddNew.Size = new System.Drawing.Size(120, 32);
			this.m_btnAddNew.TabIndex = 4;
			this.m_btnAddNew.Text = "新增(&A)";
			this.m_btnAddNew.Click += new System.EventHandler(this.m_btnAddNew_Click);
			// 
			// m_blbMNemonic
			// 
			this.m_blbMNemonic.Location = new System.Drawing.Point(32, 96);
			this.m_blbMNemonic.Name = "m_blbMNemonic";
			this.m_blbMNemonic.Size = new System.Drawing.Size(48, 23);
			this.m_blbMNemonic.TabIndex = 3;
			this.m_blbMNemonic.Text = "缩写：";
			this.m_blbMNemonic.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_lblCookMethodName
			// 
			this.m_lblCookMethodName.Location = new System.Drawing.Point(8, 40);
			this.m_lblCookMethodName.Name = "m_lblCookMethodName";
			this.m_lblCookMethodName.Size = new System.Drawing.Size(80, 23);
			this.m_lblCookMethodName.TabIndex = 2;
			this.m_lblCookMethodName.Text = "煎制方法：";
			this.m_lblCookMethodName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_txtMNemonic
			// 
			this.m_txtMNemonic.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.m_txtMNemonic.Location = new System.Drawing.Point(88, 96);
			this.m_txtMNemonic.MaxLength = 4;
			this.m_txtMNemonic.Name = "m_txtMNemonic";
			this.m_txtMNemonic.Size = new System.Drawing.Size(128, 23);
			this.m_txtMNemonic.TabIndex = 1;
			this.m_txtMNemonic.Text = "";
			this.m_txtMNemonic.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtMNemonic_KeyDown);
			this.m_txtMNemonic.TextChanged += new System.EventHandler(this.m_txtMNemonic_TextChanged);
			// 
			// m_txtCookMethodName
			// 
			this.m_txtCookMethodName.Location = new System.Drawing.Point(88, 40);
			this.m_txtCookMethodName.MaxLength = 50;
			this.m_txtCookMethodName.Name = "m_txtCookMethodName";
			this.m_txtCookMethodName.Size = new System.Drawing.Size(128, 23);
			this.m_txtCookMethodName.TabIndex = 0;
			this.m_txtCookMethodName.Text = "";
			this.m_txtCookMethodName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtCookMethodName_KeyDown);
			// 
			// frmCMCookMethod
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(666, 383);
			this.Controls.Add(this.m_pnlControls);
			this.Controls.Add(this.m_pnlViewList);
			this.Font = new System.Drawing.Font("宋体", 10.5F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(300, 408);
			this.Name = "frmCMCookMethod";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "煎制方法";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCMCookMethod_KeyDown);
			this.Load += new System.EventHandler(this.frmCMCookMethod_Load);
			this.m_pnlViewList.ResumeLayout(false);
			this.m_pnlControls.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmCMCookMethod_Load(object sender, System.EventArgs e)
		{
			((clsControlCMCookMethod)this.objController).m_GetCookMethod();
			this.m_mthSetEnter2Tab(new System.Windows.Forms.Control[] {});
		}

		public override void Show_MDI_Child(Form frmMDI_Parent)
		{
			this.ShowDialog();
		}

		public override void CreateController()
		{
			this.objController = new com.digitalwave.iCare.gui.HIS.clsControlCMCookMethod();
			this.objController.Set_GUI_Apperance(this);
		}

		private void m_btnExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void m_lst_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (m_lst.SelectedIndices.Count > 0)
			{
				m_txtCookMethodName.Text = m_lst.SelectedItems[0].SubItems[2].Text;
				m_txtMNemonic.Text = m_lst.SelectedItems[0].SubItems[3].Text;
				m_txtCookMethodName.Tag = m_lst.SelectedItems[0].Tag;
			}
		}

		private void m_btnAddNew_Click(object sender, System.EventArgs e)
		{
			m_txtCookMethodName.Text = "";
			m_txtCookMethodName.Tag = null;
			m_txtMNemonic.Text = "";
			m_txtMNemonic.Tag = null;
			m_txtCookMethodName.Focus();
		}

		private void m_btnSave_Click(object sender, System.EventArgs e)
		{
			((clsControlCMCookMethod)this.objController).m_lngSave();
//			this.frmCMCookMethod_Load(this, null);
		}

		private void m_btnDelete_Click(object sender, System.EventArgs e)
		{
			((clsControlCMCookMethod)this.objController).m_Delete();
//			this.frmCMCookMethod_Load(this, null);
		}

		private void m_pnlControls_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}

		private void m_txtCookMethodName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.m_mthSetKeyTab(e);
		}

		private void m_txtMNemonic_TextChanged(object sender, System.EventArgs e)
		{
			
		}

		private void m_txtMNemonic_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.m_mthSetKeyTab(e);
		}

		private void frmCMCookMethod_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Escape)
			{
				if(MessageBox.Show("确认退出吗?","iCare",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
					return;
				m_btnExit_Click(sender,e);

			}
		}

	}
}
