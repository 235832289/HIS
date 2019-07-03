using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmRegChargeType 的摘要说明。
	/// </summary>
	public class frmRegChargeType: com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		internal System.Windows.Forms.ListView m_lvw;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtName;
		private PinkieControls.ButtonXP m_btnExit;
		private PinkieControls.ButtonXP m_btnSave;
		private PinkieControls.ButtonXP m_btnNew;
		private System.Windows.Forms.Label label1;
		private PinkieControls.ButtonXP m_btnDel;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.Label labelMemo;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtMemo;
		internal PinkieControls.ButtonXP m_btnStopUse;
		internal System.Windows.Forms.Label m_lblIsStopUse;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtREGISTERTYPENO_VCHR;
		private System.Windows.Forms.Label label3;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmRegChargeType()
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
            this.m_lvw = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.m_txtName = new SourceLibrary.Windows.Forms.TextBoxTyped();
            this.m_btnExit = new PinkieControls.ButtonXP();
            this.m_btnSave = new PinkieControls.ButtonXP();
            this.m_btnNew = new PinkieControls.ButtonXP();
            this.label1 = new System.Windows.Forms.Label();
            this.m_btnDel = new PinkieControls.ButtonXP();
            this.m_txtMemo = new SourceLibrary.Windows.Forms.TextBoxTyped();
            this.labelMemo = new System.Windows.Forms.Label();
            this.m_btnStopUse = new PinkieControls.ButtonXP();
            this.m_lblIsStopUse = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtREGISTERTYPENO_VCHR = new SourceLibrary.Windows.Forms.TextBoxTyped();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_lvw
            // 
            this.m_lvw.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.m_lvw.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lvw.FullRowSelect = true;
            this.m_lvw.GridLines = true;
            this.m_lvw.HideSelection = false;
            this.m_lvw.Location = new System.Drawing.Point(0, 0);
            this.m_lvw.MultiSelect = false;
            this.m_lvw.Name = "m_lvw";
            this.m_lvw.Size = new System.Drawing.Size(424, 439);
            this.m_lvw.TabIndex = 6;
            this.m_lvw.UseCompatibleStateImageBehavior = false;
            this.m_lvw.View = System.Windows.Forms.View.Details;
            this.m_lvw.SelectedIndexChanged += new System.EventHandler(this.m_lvw_SelectedIndexChanged);
            this.m_lvw.Click += new System.EventHandler(this.m_lvw_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "费种ID";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 110;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "费种名称";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 110;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "备注";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 110;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "费种编号";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 89;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "状态";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 0;
            // 
            // m_txtName
            // 
            this.m_txtName.EnableAutoValidation = true;
            this.m_txtName.EnableEnterKeyValidate = true;
            this.m_txtName.EnableEscapeKeyUndo = true;
            this.m_txtName.EnableLastValidValue = true;
            this.m_txtName.ErrorProvider = null;
            this.m_txtName.ErrorProviderMessage = "Invalid value";
            this.m_txtName.ForceFormatText = true;
            this.m_txtName.Location = new System.Drawing.Point(552, 40);
            this.m_txtName.MaxLength = 20;
            this.m_txtName.Name = "m_txtName";
            this.m_txtName.Size = new System.Drawing.Size(128, 23);
            this.m_txtName.TabIndex = 0;
            this.m_txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtName_KeyDown);
            // 
            // m_btnExit
            // 
            this.m_btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnExit.DefaultScheme = true;
            this.m_btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnExit.Hint = "";
            this.m_btnExit.Location = new System.Drawing.Point(552, 352);
            this.m_btnExit.Name = "m_btnExit";
            this.m_btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnExit.Size = new System.Drawing.Size(128, 32);
            this.m_btnExit.TabIndex = 12;
            this.m_btnExit.Text = "退出(Esc)";
            this.m_btnExit.Click += new System.EventHandler(this.m_btnExit_Click);
            // 
            // m_btnSave
            // 
            this.m_btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnSave.DefaultScheme = true;
            this.m_btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnSave.Hint = "";
            this.m_btnSave.Location = new System.Drawing.Point(552, 232);
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnSave.Size = new System.Drawing.Size(128, 32);
            this.m_btnSave.TabIndex = 8;
            this.m_btnSave.Text = "保存(&S)";
            this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
            // 
            // m_btnNew
            // 
            this.m_btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnNew.DefaultScheme = true;
            this.m_btnNew.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnNew.Hint = "";
            this.m_btnNew.Location = new System.Drawing.Point(552, 192);
            this.m_btnNew.Name = "m_btnNew";
            this.m_btnNew.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnNew.Size = new System.Drawing.Size(128, 32);
            this.m_btnNew.TabIndex = 3;
            this.m_btnNew.Text = "新增(&A)";
            this.m_btnNew.Click += new System.EventHandler(this.m_btnNew_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(504, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 10;
            this.label1.Text = "名称:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_btnDel
            // 
            this.m_btnDel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnDel.DefaultScheme = true;
            this.m_btnDel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnDel.Hint = "";
            this.m_btnDel.Location = new System.Drawing.Point(552, 312);
            this.m_btnDel.Name = "m_btnDel";
            this.m_btnDel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnDel.Size = new System.Drawing.Size(128, 32);
            this.m_btnDel.TabIndex = 13;
            this.m_btnDel.Text = "删除(&D)";
            this.m_btnDel.Click += new System.EventHandler(this.m_btnDel_Click_1);
            // 
            // m_txtMemo
            // 
            this.m_txtMemo.EnableAutoValidation = true;
            this.m_txtMemo.EnableEnterKeyValidate = true;
            this.m_txtMemo.EnableEscapeKeyUndo = true;
            this.m_txtMemo.EnableLastValidValue = true;
            this.m_txtMemo.ErrorProvider = null;
            this.m_txtMemo.ErrorProviderMessage = "Invalid value";
            this.m_txtMemo.ForceFormatText = true;
            this.m_txtMemo.Location = new System.Drawing.Point(552, 80);
            this.m_txtMemo.MaxLength = 20;
            this.m_txtMemo.Name = "m_txtMemo";
            this.m_txtMemo.Size = new System.Drawing.Size(128, 23);
            this.m_txtMemo.TabIndex = 1;
            this.m_txtMemo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtMemo_KeyDown);
            // 
            // labelMemo
            // 
            this.labelMemo.AutoSize = true;
            this.labelMemo.Location = new System.Drawing.Point(504, 80);
            this.labelMemo.Name = "labelMemo";
            this.labelMemo.Size = new System.Drawing.Size(42, 14);
            this.labelMemo.TabIndex = 10;
            this.labelMemo.Text = "备注:";
            this.labelMemo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_btnStopUse
            // 
            this.m_btnStopUse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnStopUse.DefaultScheme = true;
            this.m_btnStopUse.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnStopUse.Hint = "";
            this.m_btnStopUse.Location = new System.Drawing.Point(552, 274);
            this.m_btnStopUse.Name = "m_btnStopUse";
            this.m_btnStopUse.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnStopUse.Size = new System.Drawing.Size(128, 32);
            this.m_btnStopUse.TabIndex = 16;
            this.m_btnStopUse.Text = "停用";
            this.m_btnStopUse.Click += new System.EventHandler(this.m_btnStopUse_Click);
            // 
            // m_lblIsStopUse
            // 
            this.m_lblIsStopUse.Location = new System.Drawing.Point(560, 8);
            this.m_lblIsStopUse.Name = "m_lblIsStopUse";
            this.m_lblIsStopUse.Size = new System.Drawing.Size(112, 23);
            this.m_lblIsStopUse.TabIndex = 17;
            this.m_lblIsStopUse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(504, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "编号：";
            // 
            // m_txtREGISTERTYPENO_VCHR
            // 
            this.m_txtREGISTERTYPENO_VCHR.EnableAutoValidation = true;
            this.m_txtREGISTERTYPENO_VCHR.EnableEnterKeyValidate = true;
            this.m_txtREGISTERTYPENO_VCHR.EnableEscapeKeyUndo = true;
            this.m_txtREGISTERTYPENO_VCHR.EnableLastValidValue = true;
            this.m_txtREGISTERTYPENO_VCHR.ErrorProvider = null;
            this.m_txtREGISTERTYPENO_VCHR.ErrorProviderMessage = "Invalid value";
            this.m_txtREGISTERTYPENO_VCHR.ForceFormatText = true;
            this.m_txtREGISTERTYPENO_VCHR.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.m_txtREGISTERTYPENO_VCHR.Location = new System.Drawing.Point(552, 120);
            this.m_txtREGISTERTYPENO_VCHR.MaxLength = 3;
            this.m_txtREGISTERTYPENO_VCHR.Name = "m_txtREGISTERTYPENO_VCHR";
            this.m_txtREGISTERTYPENO_VCHR.Size = new System.Drawing.Size(128, 23);
            this.m_txtREGISTERTYPENO_VCHR.TabIndex = 2;
            this.m_txtREGISTERTYPENO_VCHR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtREGISTERTYPENO_VCHR_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(504, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 14);
            this.label3.TabIndex = 20;
            this.label3.Text = "状态:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmRegChargeType
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(738, 439);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_lblIsStopUse);
            this.Controls.Add(this.m_btnStopUse);
            this.Controls.Add(this.m_btnDel);
            this.Controls.Add(this.m_txtName);
            this.Controls.Add(this.m_btnExit);
            this.Controls.Add(this.m_btnSave);
            this.Controls.Add(this.m_btnNew);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_lvw);
            this.Controls.Add(this.m_txtMemo);
            this.Controls.Add(this.labelMemo);
            this.Controls.Add(this.m_txtREGISTERTYPENO_VCHR);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmRegChargeType";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "挂号费种";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRegChargeType_KeyDown_1);
            this.Load += new System.EventHandler(this.frmRegChargeType_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public override void CreateController()
		{
			this.objController=new com.digitalwave.iCare.gui.HIS.clsControlRegChargeType();
			objController.Set_GUI_Apperance(this);
		}


		public new void Show_MDI_Child(Form frmMDI_Parent)
		{
			//			this.MdiParent = frmMDI_Parent;
			//this.WindowState = FormWindowState.Normal;
			this.ShowDialog();
			//			this.WindowState = FormWindowState.Normal;
		}

		private void m_btnNew_Click(object sender, System.EventArgs e)
		{
			
			m_txtName.Text="";
			m_txtMemo.Text="";
			m_txtREGISTERTYPENO_VCHR.Text = "";
			m_lblIsStopUse.Text="正常";
			m_txtName.Tag=null;
			this.m_txtName.Focus();
		}

		private void m_btnSave_Click(object sender, System.EventArgs e)
		{
			((clsControlRegChargeType)this.objController).m_lngSave();
		
		}

		private void m_btnDel_Click(object sender, System.EventArgs e)
		{
			((clsControlRegChargeType)this.objController).m_Del();
		}

		private void m_btnExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void frmRegChargeType_Load(object sender, System.EventArgs e)
		{
			((clsControlRegChargeType)this.objController).m_GetItemType();
			
		}

		private void m_lvw_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_lvw.SelectedIndices.Count>0)
			{
				m_txtName.Text=m_lvw.SelectedItems[0].SubItems[2].Text;
				this.m_txtMemo.Text=m_lvw.SelectedItems[0].SubItems[3].Text;
				m_txtREGISTERTYPENO_VCHR.Text = m_lvw.SelectedItems[0].SubItems[4].Text;
				m_txtName.Tag=m_lvw.SelectedItems[0].Tag;

				if(m_lvw.SelectedItems[0].SubItems[5].Text.Trim()=="0")	
				{
					m_lblIsStopUse.Text="已停用";
					m_btnStopUse.Text ="恢复";
					m_btnStopUse.Tag = "1";

				}
				else if(m_lvw.SelectedItems[0].SubItems[5].Text.Trim()=="1")
				{
					m_lblIsStopUse.Text="正常";
					m_btnStopUse.Text ="停用";
					m_btnStopUse.Tag = "0";
				}

			}
		}

		private void m_btnDel_Click_1(object sender, System.EventArgs e)
		{
			((clsControlRegChargeType)this.objController).m_Del();
		}



		private void frmRegChargeType_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			base.m_mthSetKeyTab(e);
		}

		private void m_btnStopUse_Click(object sender, System.EventArgs e)
		{
			((clsControlRegChargeType)this.objController).m_mthIsUseing();
		}

		private void frmRegChargeType_KeyDown_1(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Escape)
			{
				if(MessageBox.Show("确认退出吗?","iCare",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
					return;
				m_btnExit_Click(sender,e);

			}
		}

		private void m_txtName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				m_txtMemo.Focus();
		}

		private void m_txtMemo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				m_txtREGISTERTYPENO_VCHR.Focus();
		}

		private void m_txtREGISTERTYPENO_VCHR_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				m_btnNew.Focus();
		}
	}
}
