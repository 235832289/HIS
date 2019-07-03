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
	public class frmUsageType : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.Panel m_pnlViewList;
		private System.Windows.Forms.Panel m_pnlControls;
		private PinkieControls.ButtonXP m_btnAddNew;
		private PinkieControls.ButtonXP m_btnSave;
		private PinkieControls.ButtonXP m_btnDelete;
		private PinkieControls.ButtonXP m_btnExit;
		internal System.Windows.Forms.ListView m_lst;
		private System.Windows.Forms.ColumnHeader colUsageType;
		private System.Windows.Forms.ColumnHeader colUsageTypeID;
		private System.Windows.Forms.ColumnHeader colUsageTypeName;
		private System.Windows.Forms.ColumnHeader colUsageTypeCode;
		private System.Windows.Forms.Label m_lblUsageTypeName;
		private System.Windows.Forms.Label m_lblUsageTypeCode;
		internal System.Windows.Forms.TextBox m_txtUsageTypeName;
		internal System.Windows.Forms.TextBox m_txtUsageTypeCode;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmUsageType()
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
			this.colUsageType = new System.Windows.Forms.ColumnHeader();
			this.colUsageTypeID = new System.Windows.Forms.ColumnHeader();
			this.colUsageTypeCode = new System.Windows.Forms.ColumnHeader();
			this.colUsageTypeName = new System.Windows.Forms.ColumnHeader();
			this.m_pnlControls = new System.Windows.Forms.Panel();
			this.m_btnExit = new PinkieControls.ButtonXP();
			this.m_btnDelete = new PinkieControls.ButtonXP();
			this.m_btnSave = new PinkieControls.ButtonXP();
			this.m_btnAddNew = new PinkieControls.ButtonXP();
			this.m_lblUsageTypeName = new System.Windows.Forms.Label();
			this.m_lblUsageTypeCode = new System.Windows.Forms.Label();
			this.m_txtUsageTypeName = new System.Windows.Forms.TextBox();
			this.m_txtUsageTypeCode = new System.Windows.Forms.TextBox();
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
			this.m_pnlViewList.Size = new System.Drawing.Size(576, 383);
			this.m_pnlViewList.TabIndex = 0;
			// 
			// m_lst
			// 
			this.m_lst.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					this.colUsageType,
																					this.colUsageTypeID,
																					this.colUsageTypeCode,
																					this.colUsageTypeName});
			this.m_lst.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_lst.FullRowSelect = true;
			this.m_lst.GridLines = true;
			this.m_lst.HideSelection = false;
			this.m_lst.Location = new System.Drawing.Point(0, 0);
			this.m_lst.Name = "m_lst";
			this.m_lst.Size = new System.Drawing.Size(576, 383);
			this.m_lst.TabIndex = 0;
			this.m_lst.View = System.Windows.Forms.View.Details;
			this.m_lst.SelectedIndexChanged += new System.EventHandler(this.m_lst_SelectedIndexChanged);
			// 
			// colUsageType
			// 
			this.colUsageType.Text = "";
			this.colUsageType.Width = 0;
			// 
			// colUsageTypeID
			// 
			this.colUsageTypeID.Text = "编号";
			this.colUsageTypeID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.colUsageTypeID.Width = 0;
			// 
			// colUsageTypeCode
			// 
			this.colUsageTypeCode.Text = "用法编号";
			this.colUsageTypeCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.colUsageTypeCode.Width = 85;
			// 
			// colUsageTypeName
			// 
			this.colUsageTypeName.Text = "用法名称";
			this.colUsageTypeName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.colUsageTypeName.Width = 297;
			// 
			// m_pnlControls
			// 
			this.m_pnlControls.Controls.Add(this.m_btnExit);
			this.m_pnlControls.Controls.Add(this.m_btnDelete);
			this.m_pnlControls.Controls.Add(this.m_btnSave);
			this.m_pnlControls.Controls.Add(this.m_btnAddNew);
			this.m_pnlControls.Controls.Add(this.m_lblUsageTypeName);
			this.m_pnlControls.Controls.Add(this.m_lblUsageTypeCode);
			this.m_pnlControls.Controls.Add(this.m_txtUsageTypeName);
			this.m_pnlControls.Controls.Add(this.m_txtUsageTypeCode);
			this.m_pnlControls.Dock = System.Windows.Forms.DockStyle.Right;
			this.m_pnlControls.Location = new System.Drawing.Point(384, 0);
			this.m_pnlControls.Name = "m_pnlControls";
			this.m_pnlControls.Size = new System.Drawing.Size(192, 383);
			this.m_pnlControls.TabIndex = 1;
			// 
			// m_btnExit
			// 
			this.m_btnExit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnExit.DefaultScheme = true;
			this.m_btnExit.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnExit.Hint = "";
			this.m_btnExit.Location = new System.Drawing.Point(48, 272);
			this.m_btnExit.Name = "m_btnExit";
			this.m_btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnExit.Size = new System.Drawing.Size(104, 32);
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
			this.m_btnDelete.Location = new System.Drawing.Point(48, 232);
			this.m_btnDelete.Name = "m_btnDelete";
			this.m_btnDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnDelete.Size = new System.Drawing.Size(104, 32);
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
			this.m_btnSave.Location = new System.Drawing.Point(48, 192);
			this.m_btnSave.Name = "m_btnSave";
			this.m_btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnSave.Size = new System.Drawing.Size(104, 32);
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
			this.m_btnAddNew.Location = new System.Drawing.Point(48, 152);
			this.m_btnAddNew.Name = "m_btnAddNew";
			this.m_btnAddNew.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnAddNew.Size = new System.Drawing.Size(104, 32);
			this.m_btnAddNew.TabIndex = 4;
			this.m_btnAddNew.Text = "新增(&A)";
			this.m_btnAddNew.Click += new System.EventHandler(this.m_btnAddNew_Click);
			// 
			// m_lblUsageTypeName
			// 
			this.m_lblUsageTypeName.Location = new System.Drawing.Point(16, 80);
			this.m_lblUsageTypeName.Name = "m_lblUsageTypeName";
			this.m_lblUsageTypeName.Size = new System.Drawing.Size(88, 23);
			this.m_lblUsageTypeName.TabIndex = 3;
			this.m_lblUsageTypeName.Text = "用法名称：";
			// 
			// m_lblUsageTypeCode
			// 
			this.m_lblUsageTypeCode.Location = new System.Drawing.Point(8, 24);
			this.m_lblUsageTypeCode.Name = "m_lblUsageTypeCode";
			this.m_lblUsageTypeCode.Size = new System.Drawing.Size(80, 23);
			this.m_lblUsageTypeCode.TabIndex = 2;
			this.m_lblUsageTypeCode.Text = "用法编号：";
			// 
			// m_txtUsageTypeName
			// 
			this.m_txtUsageTypeName.Location = new System.Drawing.Point(16, 104);
			this.m_txtUsageTypeName.MaxLength = 10;
			this.m_txtUsageTypeName.Name = "m_txtUsageTypeName";
			this.m_txtUsageTypeName.Size = new System.Drawing.Size(168, 23);
			this.m_txtUsageTypeName.TabIndex = 1;
			this.m_txtUsageTypeName.Text = "";
			// 
			// m_txtUsageTypeCode
			// 
			this.m_txtUsageTypeCode.Location = new System.Drawing.Point(16, 48);
			this.m_txtUsageTypeCode.MaxLength = 50;
			this.m_txtUsageTypeCode.Name = "m_txtUsageTypeCode";
			this.m_txtUsageTypeCode.Size = new System.Drawing.Size(168, 23);
			this.m_txtUsageTypeCode.TabIndex = 0;
			this.m_txtUsageTypeCode.Text = "";
			// 
			// frmUsageType
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(576, 383);
			this.Controls.Add(this.m_pnlControls);
			this.Controls.Add(this.m_pnlViewList);
			this.Font = new System.Drawing.Font("宋体", 10.5F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(300, 408);
			this.Name = "frmUsageType";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "收费项目用法表";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmUsageType_KeyDown);
			this.Load += new System.EventHandler(this.frmUsageType_Load);
			this.m_pnlViewList.ResumeLayout(false);
			this.m_pnlControls.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmUsageType_Load(object sender, System.EventArgs e)
		{
			((clsControlUsageType)this.objController).m_GetUsageType();
		}

		public override void Show_MDI_Child(Form frmMDI_Parent)
		{
			this.ShowDialog();
		}

		public override void CreateController()
		{
			this.objController = new com.digitalwave.iCare.gui.HIS.clsControlUsageType();
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
				m_txtUsageTypeName.Text = m_lst.SelectedItems[0].SubItems[3].Text;
				m_txtUsageTypeCode.Text = m_lst.SelectedItems[0].SubItems[2].Text;
				m_txtUsageTypeName.Tag = m_lst.SelectedItems[0].Tag;
			}
		}

		private void m_btnAddNew_Click(object sender, System.EventArgs e)
		{
			m_txtUsageTypeCode.Text = "";
			m_txtUsageTypeCode.Tag = null;
			m_txtUsageTypeName.Text = "";
			m_txtUsageTypeName.Tag = null;
			m_txtUsageTypeCode.Focus();
		}

		private void m_btnSave_Click(object sender, System.EventArgs e)
		{
			((clsControlUsageType)this.objController).m_lngSave();
			this.frmUsageType_Load(this, null);
		}

		private void m_btnDelete_Click(object sender, System.EventArgs e)
		{
			((clsControlUsageType)this.objController).m_Delete();
			this.frmUsageType_Load(this, null);
		}

		private void frmUsageType_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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
