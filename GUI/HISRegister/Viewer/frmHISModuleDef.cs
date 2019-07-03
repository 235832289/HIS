using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 应用管理系统窗体
	/// </summary>
	public class frmHISModuleDef : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		internal System.Windows.Forms.ListView m_lsv;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private PinkieControls.ButtonXP m_btnAddNew;
		private PinkieControls.ButtonXP m_btnSave;
		private PinkieControls.ButtonXP m_btnDelete;
		internal System.Windows.Forms.TextBox m_txtModuleName;
		internal System.Windows.Forms.TextBox m_txtEngName;
		internal System.Windows.Forms.TextBox m_txtPYCode;
		internal System.Windows.Forms.TextBox m_txtWBCode;
		private PinkieControls.ButtonXP m_btnExit;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmHISModuleDef()
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.m_lsv = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.m_btnExit = new PinkieControls.ButtonXP();
			this.m_btnDelete = new PinkieControls.ButtonXP();
			this.m_btnSave = new PinkieControls.ButtonXP();
			this.m_btnAddNew = new PinkieControls.ButtonXP();
			this.m_txtWBCode = new System.Windows.Forms.TextBox();
			this.m_txtPYCode = new System.Windows.Forms.TextBox();
			this.m_txtEngName = new System.Windows.Forms.TextBox();
			this.m_txtModuleName = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.m_lsv);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(568, 317);
			this.panel1.TabIndex = 0;
			// 
			// m_lsv
			// 
			this.m_lsv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					this.columnHeader1,
																					this.columnHeader2,
																					this.columnHeader3,
																					this.columnHeader4,
																					this.columnHeader5,
																					this.columnHeader6});
			this.m_lsv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_lsv.FullRowSelect = true;
			this.m_lsv.HideSelection = false;
			this.m_lsv.Location = new System.Drawing.Point(0, 0);
			this.m_lsv.Name = "m_lsv";
			this.m_lsv.Size = new System.Drawing.Size(568, 317);
			this.m_lsv.TabIndex = 0;
			this.m_lsv.View = System.Windows.Forms.View.Details;
			this.m_lsv.SelectedIndexChanged += new System.EventHandler(this.m_lsv_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Width = 0;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "分系统ID";
			this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader2.Width = 69;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "分系统名称";
			this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader3.Width = 141;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "分系统英文名称";
			this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader4.Width = 201;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "拼音码";
			this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader5.Width = 85;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "五笔码";
			this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader6.Width = 68;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.label5);
			this.panel2.Controls.Add(this.label4);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.m_btnExit);
			this.panel2.Controls.Add(this.m_btnDelete);
			this.panel2.Controls.Add(this.m_btnSave);
			this.panel2.Controls.Add(this.m_btnAddNew);
			this.panel2.Controls.Add(this.m_txtWBCode);
			this.panel2.Controls.Add(this.m_txtPYCode);
			this.panel2.Controls.Add(this.m_txtEngName);
			this.panel2.Controls.Add(this.m_txtModuleName);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 317);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(568, 104);
			this.panel2.TabIndex = 0;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(480, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 16);
			this.label5.TabIndex = 13;
			this.label5.Text = "五笔码:";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(376, 8);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 16);
			this.label4.TabIndex = 12;
			this.label4.Text = "拼音码:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(176, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(120, 16);
			this.label3.TabIndex = 11;
			this.label3.Text = "分系统英文名称:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 16);
			this.label2.TabIndex = 10;
			this.label2.Text = "分系统名称:";
			// 
			// m_btnExit
			// 
			this.m_btnExit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnExit.DefaultScheme = true;
			this.m_btnExit.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnExit.Hint = "";
			this.m_btnExit.Location = new System.Drawing.Point(424, 64);
			this.m_btnExit.Name = "m_btnExit";
			this.m_btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnExit.Size = new System.Drawing.Size(104, 32);
			this.m_btnExit.TabIndex = 9;
			this.m_btnExit.Text = "退出";
			this.m_btnExit.Click += new System.EventHandler(this.m_btnExit_Click);
			// 
			// m_btnDelete
			// 
			this.m_btnDelete.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnDelete.DefaultScheme = true;
			this.m_btnDelete.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnDelete.Hint = "";
			this.m_btnDelete.Location = new System.Drawing.Point(296, 64);
			this.m_btnDelete.Name = "m_btnDelete";
			this.m_btnDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnDelete.Size = new System.Drawing.Size(104, 32);
			this.m_btnDelete.TabIndex = 8;
			this.m_btnDelete.Text = "删除";
			this.m_btnDelete.Click += new System.EventHandler(this.m_btnDelete_Click);
			// 
			// m_btnSave
			// 
			this.m_btnSave.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnSave.DefaultScheme = true;
			this.m_btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnSave.Hint = "";
			this.m_btnSave.Location = new System.Drawing.Point(168, 64);
			this.m_btnSave.Name = "m_btnSave";
			this.m_btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnSave.Size = new System.Drawing.Size(104, 32);
			this.m_btnSave.TabIndex = 7;
			this.m_btnSave.Text = "保存";
			this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
			// 
			// m_btnAddNew
			// 
			this.m_btnAddNew.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnAddNew.DefaultScheme = true;
			this.m_btnAddNew.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnAddNew.Hint = "";
			this.m_btnAddNew.Location = new System.Drawing.Point(40, 64);
			this.m_btnAddNew.Name = "m_btnAddNew";
			this.m_btnAddNew.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnAddNew.Size = new System.Drawing.Size(104, 32);
			this.m_btnAddNew.TabIndex = 6;
			this.m_btnAddNew.Text = "新增";
			this.m_btnAddNew.Click += new System.EventHandler(this.m_btnAddNew_Click);
			// 
			// m_txtWBCode
			// 
			this.m_txtWBCode.Location = new System.Drawing.Point(480, 32);
			this.m_txtWBCode.MaxLength = 10;
			this.m_txtWBCode.Name = "m_txtWBCode";
			this.m_txtWBCode.Size = new System.Drawing.Size(72, 23);
			this.m_txtWBCode.TabIndex = 4;
			this.m_txtWBCode.Text = "";
			// 
			// m_txtPYCode
			// 
			this.m_txtPYCode.Location = new System.Drawing.Point(376, 32);
			this.m_txtPYCode.MaxLength = 10;
			this.m_txtPYCode.Name = "m_txtPYCode";
			this.m_txtPYCode.Size = new System.Drawing.Size(88, 23);
			this.m_txtPYCode.TabIndex = 3;
			this.m_txtPYCode.Text = "";
			// 
			// m_txtEngName
			// 
			this.m_txtEngName.Location = new System.Drawing.Point(176, 32);
			this.m_txtEngName.MaxLength = 20;
			this.m_txtEngName.Name = "m_txtEngName";
			this.m_txtEngName.Size = new System.Drawing.Size(184, 23);
			this.m_txtEngName.TabIndex = 2;
			this.m_txtEngName.Text = "";
			// 
			// m_txtModuleName
			// 
			this.m_txtModuleName.Location = new System.Drawing.Point(16, 32);
			this.m_txtModuleName.MaxLength = 20;
			this.m_txtModuleName.Name = "m_txtModuleName";
			this.m_txtModuleName.Size = new System.Drawing.Size(144, 23);
			this.m_txtModuleName.TabIndex = 1;
			this.m_txtModuleName.Text = "";
			// 
			// frmHISModuleDef
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(568, 421);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel2);
			this.Font = new System.Drawing.Font("宋体", 10.5F);
			this.MinimumSize = new System.Drawing.Size(576, 448);
			this.Name = "frmHISModuleDef";
			this.Text = "应用系统管理";
			this.Load += new System.EventHandler(this.frmHISModuleDef_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void Show_MDI_Child(Form frmMDI_Parent)
		{
			this.ShowDialog();
		}

		public override void CreateController()
		{
			this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_HISModuleDef();
			this.objController.Set_GUI_Apperance(this);
		}

		private void m_btnExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void m_btnAddNew_Click(object sender, System.EventArgs e)
		{
			m_txtModuleName.Text = "";
			m_txtEngName.Text = "";
			m_txtPYCode.Text = "";
			m_txtWBCode.Text = "";
			m_txtModuleName.Tag = null;
			m_txtModuleName.Focus();
		}

		private void m_btnSave_Click(object sender, System.EventArgs e)
		{
			((clsCtl_HISModuleDef)this.objController).m_lngSave();
			this.frmHISModuleDef_Load(this, null);
		}

		private void frmHISModuleDef_Load(object sender, System.EventArgs e)
		{
			((clsCtl_HISModuleDef)this.objController).m_GetModule();
		}

		private void m_btnDelete_Click(object sender, System.EventArgs e)
		{
			((clsCtl_HISModuleDef)this.objController).m_Delete();
			this.frmHISModuleDef_Load(this, null);
		}

		private void m_lsv_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (m_lsv.SelectedIndices.Count > 0)
			{
				m_txtModuleName.Text = m_lsv.SelectedItems[0].SubItems[2].Text;
				m_txtEngName.Text = m_lsv.SelectedItems[0].SubItems[3].Text;
				m_txtPYCode.Text = m_lsv.SelectedItems[0].SubItems[4].Text;
				m_txtWBCode.Text = m_lsv.SelectedItems[0].SubItems[5].Text;
				m_txtModuleName.Tag = m_lsv.SelectedItems[0].Tag;
			}
		}
	}
}
