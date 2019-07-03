using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmChargeCat 的摘要说明。
	/// </summary>
	public class frmChargeCat : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.Label label1;
		private PinkieControls.ButtonXP m_btnNew;
		private PinkieControls.ButtonXP m_btnSave;
		private PinkieControls.ButtonXP m_btnExit;
		internal System.Windows.Forms.ListView m_lvw;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtName;
		private PinkieControls.ButtonXP m_btnDel;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel1;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtID;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmChargeCat()
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
			this.label1 = new System.Windows.Forms.Label();
			this.m_btnNew = new PinkieControls.ButtonXP();
			this.m_btnSave = new PinkieControls.ButtonXP();
			this.m_btnExit = new PinkieControls.ButtonXP();
			this.m_txtName = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.m_btnDel = new PinkieControls.ButtonXP();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.m_txtID = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_lvw
			// 
			this.m_lvw.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					this.columnHeader1,
																					this.columnHeader2,
																					this.columnHeader3});
			this.m_lvw.FullRowSelect = true;
			this.m_lvw.GridLines = true;
			this.m_lvw.HideSelection = false;
			this.m_lvw.Location = new System.Drawing.Point(8, 8);
			this.m_lvw.MultiSelect = false;
			this.m_lvw.Name = "m_lvw";
			this.m_lvw.Size = new System.Drawing.Size(216, 320);
			this.m_lvw.TabIndex = 5;
			this.m_lvw.View = System.Windows.Forms.View.Details;
			this.m_lvw.SelectedIndexChanged += new System.EventHandler(this.m_lvw_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "ID";
			this.columnHeader1.Width = 0;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "ID";
			this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader2.Width = 98;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "类别名称";
			this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader3.Width = 113;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(40, 58);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 19);
			this.label1.TabIndex = 8;
			this.label1.Text = "名称:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_btnNew
			// 
			this.m_btnNew.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnNew.DefaultScheme = true;
			this.m_btnNew.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnNew.Hint = "";
			this.m_btnNew.Location = new System.Drawing.Point(88, 104);
			this.m_btnNew.Name = "m_btnNew";
			this.m_btnNew.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnNew.Size = new System.Drawing.Size(96, 32);
			this.m_btnNew.TabIndex = 2;
			this.m_btnNew.Text = "新增(&A)";
			this.m_btnNew.Click += new System.EventHandler(this.m_btnNew_Click);
			// 
			// m_btnSave
			// 
			this.m_btnSave.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnSave.DefaultScheme = true;
			this.m_btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnSave.Hint = "";
			this.m_btnSave.Location = new System.Drawing.Point(88, 144);
			this.m_btnSave.Name = "m_btnSave";
			this.m_btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnSave.Size = new System.Drawing.Size(96, 32);
			this.m_btnSave.TabIndex = 3;
			this.m_btnSave.Text = "保存(&S)";
			this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
			// 
			// m_btnExit
			// 
			this.m_btnExit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnExit.DefaultScheme = true;
			this.m_btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnExit.Hint = "";
			this.m_btnExit.Location = new System.Drawing.Point(88, 224);
			this.m_btnExit.Name = "m_btnExit";
			this.m_btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnExit.Size = new System.Drawing.Size(96, 32);
			this.m_btnExit.TabIndex = 6;
			this.m_btnExit.Text = "退出(Esc)";
			this.m_btnExit.Click += new System.EventHandler(this.m_btnExit_Click);
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
			this.m_txtName.Location = new System.Drawing.Point(88, 56);
			this.m_txtName.MaxLength = 10;
			this.m_txtName.Name = "m_txtName";
			this.m_txtName.Size = new System.Drawing.Size(112, 23);
			this.m_txtName.TabIndex = 1;
			this.m_txtName.Text = "";
			// 
			// m_btnDel
			// 
			this.m_btnDel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnDel.DefaultScheme = true;
			this.m_btnDel.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnDel.Hint = "";
			this.m_btnDel.Location = new System.Drawing.Point(88, 184);
			this.m_btnDel.Name = "m_btnDel";
			this.m_btnDel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnDel.Size = new System.Drawing.Size(96, 32);
			this.m_btnDel.TabIndex = 4;
			this.m_btnDel.Text = "删除(&D)";
			this.m_btnDel.Click += new System.EventHandler(this.m_btnDel_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(56, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(27, 19);
			this.label2.TabIndex = 7;
			this.label2.Text = "ID:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.m_txtID);
			this.panel1.Controls.Add(this.m_btnExit);
			this.panel1.Controls.Add(this.m_btnDel);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.m_btnSave);
			this.panel1.Controls.Add(this.m_btnNew);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.m_txtName);
			this.panel1.Location = new System.Drawing.Point(256, 8);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(240, 320);
			this.panel1.TabIndex = 8;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			// 
			// m_txtID
			// 
			this.m_txtID.EnableAutoValidation = true;
			this.m_txtID.EnableEnterKeyValidate = true;
			this.m_txtID.EnableEscapeKeyUndo = true;
			this.m_txtID.EnableLastValidValue = true;
			this.m_txtID.ErrorProvider = null;
			this.m_txtID.ErrorProviderMessage = "Invalid value";
			this.m_txtID.ForceFormatText = true;
			this.m_txtID.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.m_txtID.Location = new System.Drawing.Point(88, 16);
			this.m_txtID.MaxLength = 4;
			this.m_txtID.Name = "m_txtID";
			this.m_txtID.Size = new System.Drawing.Size(112, 23);
			this.m_txtID.TabIndex = 34;
			this.m_txtID.Text = "";
			// 
			// frmChargeCat
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(514, 343);
			this.Controls.Add(this.m_lvw);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.Name = "frmChargeCat";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "收费项目类型";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChargeCat_KeyDown);
			this.Load += new System.EventHandler(this.frmChargeCat_Load);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void CreateController()
		{
			this.objController=new com.digitalwave.iCare.gui.HIS.clsControlChargeCat();
			objController.Set_GUI_Apperance(this);
		}
		public new void Show_MDI_Child(Form frmMDI_Parent)
		{
//			this.MdiParent = frmMDI_Parent;
			//this.WindowState = FormWindowState.Normal;
			this.ShowDialog();
//			this.WindowState = FormWindowState.Normal;
		}

		private void m_btnExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void m_lvw_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_lvw.SelectedItems.Count>0)
			{
				m_txtID.Text=m_lvw.SelectedItems[0].SubItems[1].Text;
				m_txtName.Text=m_lvw.SelectedItems[0].SubItems[2].Text;
				m_txtName.Tag=m_lvw.SelectedItems[0].SubItems[1].Text;
			}
		}

		private void frmChargeCat_Load(object sender, System.EventArgs e)
		{
			((clsControlChargeCat)this.objController).m_GetItemCat();
		}

		private void m_btnNew_Click(object sender, System.EventArgs e)
		{
			m_txtName.Text="";
			m_txtName.Tag=null;
			m_txtID.Text="";
			m_txtID.Select();
			
		}

		private void m_btnSave_Click(object sender, System.EventArgs e)
		{
		   ((clsControlChargeCat)this.objController).m_lngSave();
		}

		private void m_btnDel_Click(object sender, System.EventArgs e)
		{
			((clsControlChargeCat)this.objController).m_Del();
		}

		private void frmChargeCat_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Escape)
			{
				if(MessageBox.Show("确认退出吗?","iCare",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
					return;
				m_btnExit_Click(sender,e);

			}
			base.m_mthSetKeyTab(e);
		}

		private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}

	}
}
