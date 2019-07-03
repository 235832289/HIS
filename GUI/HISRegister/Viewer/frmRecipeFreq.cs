using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmRecipeFreq 的摘要说明。
	/// </summary>
	public class frmRecipeFreq : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		internal System.Windows.Forms.ListView m_lvw;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private PinkieControls.ButtonXP m_btnDel;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtName;
		private PinkieControls.ButtonXP m_btnExit;
		private PinkieControls.ButtonXP m_btnSave;
		private PinkieControls.ButtonXP m_btnNew;
		private System.Windows.Forms.Label labelFreqName;
		private System.Windows.Forms.Label labelMemo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric m_txtTIMES_INT;
		internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric tex_DAYS_INT;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtUSERCODE_CHR;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ColumnHeader columnHeader7;
        private Label label3;
        internal TextBox m_txtDesc;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmRecipeFreq()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecipeFreq));
            this.m_btnExit = new PinkieControls.ButtonXP();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_txtUSERCODE_CHR = new SourceLibrary.Windows.Forms.TextBoxTyped();
            this.tex_DAYS_INT = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
            this.m_txtTIMES_INT = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
            this.m_btnDel = new PinkieControls.ButtonXP();
            this.m_txtName = new SourceLibrary.Windows.Forms.TextBoxTyped();
            this.m_btnNew = new PinkieControls.ButtonXP();
            this.m_btnSave = new PinkieControls.ButtonXP();
            this.label3 = new System.Windows.Forms.Label();
            this.labelMemo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelFreqName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_lvw = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.m_txtDesc = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnExit
            // 
            this.m_btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnExit.DefaultScheme = true;
            this.m_btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnExit.Hint = "";
            this.m_btnExit.Location = new System.Drawing.Point(86, 362);
            this.m_btnExit.Name = "m_btnExit";
            this.m_btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnExit.Size = new System.Drawing.Size(112, 32);
            this.m_btnExit.TabIndex = 27;
            this.m_btnExit.Text = "退出(Esc)";
            this.m_btnExit.Click += new System.EventHandler(this.m_btnExit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_txtDesc);
            this.groupBox2.Controls.Add(this.m_txtUSERCODE_CHR);
            this.groupBox2.Controls.Add(this.tex_DAYS_INT);
            this.groupBox2.Controls.Add(this.m_txtTIMES_INT);
            this.groupBox2.Controls.Add(this.m_btnDel);
            this.groupBox2.Controls.Add(this.m_txtName);
            this.groupBox2.Controls.Add(this.m_btnNew);
            this.groupBox2.Controls.Add(this.m_btnExit);
            this.groupBox2.Controls.Add(this.m_btnSave);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.labelMemo);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.labelFreqName);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(640, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(253, 408);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "编辑区域：";
            // 
            // m_txtUSERCODE_CHR
            // 
            this.m_txtUSERCODE_CHR.EnableAutoValidation = true;
            this.m_txtUSERCODE_CHR.EnableEnterKeyValidate = true;
            this.m_txtUSERCODE_CHR.EnableEscapeKeyUndo = true;
            this.m_txtUSERCODE_CHR.EnableLastValidValue = true;
            this.m_txtUSERCODE_CHR.ErrorProvider = null;
            this.m_txtUSERCODE_CHR.ErrorProviderMessage = "Invalid value";
            this.m_txtUSERCODE_CHR.ForceFormatText = true;
            this.m_txtUSERCODE_CHR.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.m_txtUSERCODE_CHR.Location = new System.Drawing.Point(107, 63);
            this.m_txtUSERCODE_CHR.MaxLength = 2;
            this.m_txtUSERCODE_CHR.Name = "m_txtUSERCODE_CHR";
            this.m_txtUSERCODE_CHR.Size = new System.Drawing.Size(117, 23);
            this.m_txtUSERCODE_CHR.TabIndex = 1;
            this.m_txtUSERCODE_CHR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtUSERCODE_CHR_KeyDown);
            // 
            // tex_DAYS_INT
            // 
            this.tex_DAYS_INT.EnableAutoValidation = false;
            this.tex_DAYS_INT.EnableEnterKeyValidate = false;
            this.tex_DAYS_INT.EnableEscapeKeyUndo = true;
            this.tex_DAYS_INT.EnableLastValidValue = true;
            this.tex_DAYS_INT.ErrorProvider = null;
            this.tex_DAYS_INT.ErrorProviderMessage = "Invalid value";
            this.tex_DAYS_INT.ForceFormatText = true;
            this.tex_DAYS_INT.Location = new System.Drawing.Point(105, 137);
            this.tex_DAYS_INT.MaxLength = 1;
            this.tex_DAYS_INT.Name = "tex_DAYS_INT";
            this.tex_DAYS_INT.NumericCharStyle = SourceLibrary.Windows.Forms.NumericCharStyle.NegativeSymbol;
            this.tex_DAYS_INT.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tex_DAYS_INT.Size = new System.Drawing.Size(119, 23);
            this.tex_DAYS_INT.TabIndex = 3;
            this.tex_DAYS_INT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tex_DAYS_INT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex_DAYS_INT_KeyDown);
            // 
            // m_txtTIMES_INT
            // 
            this.m_txtTIMES_INT.EnableAutoValidation = false;
            this.m_txtTIMES_INT.EnableEnterKeyValidate = false;
            this.m_txtTIMES_INT.EnableEscapeKeyUndo = true;
            this.m_txtTIMES_INT.EnableLastValidValue = true;
            this.m_txtTIMES_INT.ErrorProvider = null;
            this.m_txtTIMES_INT.ErrorProviderMessage = "Invalid value";
            this.m_txtTIMES_INT.ForceFormatText = true;
            this.m_txtTIMES_INT.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.m_txtTIMES_INT.Location = new System.Drawing.Point(106, 100);
            this.m_txtTIMES_INT.MaxLength = 1;
            this.m_txtTIMES_INT.Name = "m_txtTIMES_INT";
            this.m_txtTIMES_INT.NumericCharStyle = SourceLibrary.Windows.Forms.NumericCharStyle.NegativeSymbol;
            this.m_txtTIMES_INT.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.m_txtTIMES_INT.Size = new System.Drawing.Size(118, 23);
            this.m_txtTIMES_INT.TabIndex = 2;
            this.m_txtTIMES_INT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtTIMES_INT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtTIMES_INT_KeyDown);
            // 
            // m_btnDel
            // 
            this.m_btnDel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnDel.DefaultScheme = true;
            this.m_btnDel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnDel.Hint = "";
            this.m_btnDel.Location = new System.Drawing.Point(86, 321);
            this.m_btnDel.Name = "m_btnDel";
            this.m_btnDel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnDel.Size = new System.Drawing.Size(112, 32);
            this.m_btnDel.TabIndex = 28;
            this.m_btnDel.Text = "删除(&D)";
            this.m_btnDel.Click += new System.EventHandler(this.m_btnDel_Click);
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
            this.m_txtName.Location = new System.Drawing.Point(107, 27);
            this.m_txtName.MaxLength = 10;
            this.m_txtName.Name = "m_txtName";
            this.m_txtName.Size = new System.Drawing.Size(117, 23);
            this.m_txtName.TabIndex = 0;
            this.m_txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtName_KeyDown);
            // 
            // m_btnNew
            // 
            this.m_btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnNew.DefaultScheme = true;
            this.m_btnNew.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnNew.Hint = "";
            this.m_btnNew.Location = new System.Drawing.Point(86, 240);
            this.m_btnNew.Name = "m_btnNew";
            this.m_btnNew.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnNew.Size = new System.Drawing.Size(112, 32);
            this.m_btnNew.TabIndex = 6;
            this.m_btnNew.Text = "新增(&A)";
            this.m_btnNew.Click += new System.EventHandler(this.m_btnNew_Click);
            // 
            // m_btnSave
            // 
            this.m_btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnSave.DefaultScheme = true;
            this.m_btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnSave.Hint = "";
            this.m_btnSave.Location = new System.Drawing.Point(86, 281);
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnSave.Size = new System.Drawing.Size(112, 32);
            this.m_btnSave.TabIndex = 5;
            this.m_btnSave.Text = "保存(&S)";
            this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(27, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 14);
            this.label3.TabIndex = 30;
            this.label3.Text = "描　  述：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelMemo
            // 
            this.labelMemo.AutoSize = true;
            this.labelMemo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelMemo.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.labelMemo.Location = new System.Drawing.Point(27, 108);
            this.labelMemo.Name = "labelMemo";
            this.labelMemo.Size = new System.Drawing.Size(76, 14);
            this.labelMemo.TabIndex = 25;
            this.labelMemo.Text = "次　  数:";
            this.labelMemo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(27, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 14);
            this.label2.TabIndex = 25;
            this.label2.Text = "天　  数:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(27, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 14);
            this.label1.TabIndex = 25;
            this.label1.Text = "助 记 码：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelFreqName
            // 
            this.labelFreqName.AutoSize = true;
            this.labelFreqName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelFreqName.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.labelFreqName.Location = new System.Drawing.Point(27, 33);
            this.labelFreqName.Name = "labelFreqName";
            this.labelFreqName.Size = new System.Drawing.Size(83, 14);
            this.labelFreqName.TabIndex = 26;
            this.labelFreqName.Text = "名　  称：";
            this.labelFreqName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_lvw);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(640, 408);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "频率信息：";
            // 
            // m_lvw
            // 
            this.m_lvw.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.m_lvw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lvw.FullRowSelect = true;
            this.m_lvw.GridLines = true;
            this.m_lvw.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.m_lvw.HideSelection = false;
            this.m_lvw.Location = new System.Drawing.Point(3, 19);
            this.m_lvw.MultiSelect = false;
            this.m_lvw.Name = "m_lvw";
            this.m_lvw.Size = new System.Drawing.Size(634, 386);
            this.m_lvw.TabIndex = 15;
            this.m_lvw.UseCompatibleStateImageBehavior = false;
            this.m_lvw.View = System.Windows.Forms.View.Details;
            this.m_lvw.SelectedIndexChanged += new System.EventHandler(this.m_lvw_SelectedIndexChanged);
            this.m_lvw.Click += new System.EventHandler(this.m_lvw_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "columnHeader1";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "频率编号";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 110;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "频率名称";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 110;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "助记码";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 110;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "次数";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "天数";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "描述";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 180;
            // 
            // m_txtDesc
            // 
            this.m_txtDesc.Location = new System.Drawing.Point(104, 176);
            this.m_txtDesc.Multiline = true;
            this.m_txtDesc.Name = "m_txtDesc";
            this.m_txtDesc.Size = new System.Drawing.Size(120, 56);
            this.m_txtDesc.TabIndex = 4;
            this.m_txtDesc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtDesc_KeyDown);
            // 
            // frmRecipeFreq
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(893, 408);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmRecipeFreq";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "用药频率维护界面";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRecipeFreq_KeyDown);
            this.Load += new System.EventHandler(this.frmRecipeFreq_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		public override void CreateController()
		{
			this.objController=new com.digitalwave.iCare.gui.HIS.clsControlRecipeFreq();
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
			m_txtUSERCODE_CHR.Text="";
			m_txtTIMES_INT.Text="";
			tex_DAYS_INT.Text="";
			m_txtName.Tag=null;
            this.m_txtDesc.Clear();
			this.m_txtName.Focus();
		}

		private void frmRecipeFreq_Load(object sender, System.EventArgs e)
		{
			((clsControlRecipeFreq)this.objController).m_GetItemRecipeFequencyType();
		}

		private void m_lvw_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_lvw.SelectedIndices.Count>0)
			{
				m_txtName.Text=m_lvw.SelectedItems[0].SubItems[2].Text;
				this.m_txtUSERCODE_CHR.Text = m_lvw.SelectedItems[0].SubItems[3].Text;
				this.m_txtTIMES_INT.Text = m_lvw.SelectedItems[0].SubItems[4].Text;
				this.tex_DAYS_INT.Text = m_lvw.SelectedItems[0].SubItems[5].Text;
                this.m_txtDesc.Text = m_lvw.SelectedItems[0].SubItems[6].Text;
				m_txtName.Tag=m_lvw.SelectedItems[0].Tag;
			}
		}

		private void m_btnSave_Click(object sender, System.EventArgs e)
		{
			((clsControlRecipeFreq)this.objController).m_lngSaveRecipeFequencyType();
			
		}

		private void m_btnDel_Click(object sender, System.EventArgs e)
		{
			((clsControlRecipeFreq)this.objController).m_DelRecipeFequencyType();
		}

		private void m_btnExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

	
		
		private void frmRegChargeType_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			base.m_mthSetKeyTab(e);
		}

		private void frmRecipeFreq_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Escape)
			{
				if(MessageBox.Show("确认退出吗?","iCare",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
					return;
				m_btnExit_Click(sender,e);
			}
			this.m_mthSetEnter2Tab(new System.Windows.Forms.Control[] {});
		}

		private void m_txtName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.m_mthSetKeyTab(e);
		}

		private void m_txtUSERCODE_CHR_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.m_mthSetKeyTab(e);
		}

		private void m_txtTIMES_INT_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.m_mthSetKeyTab(e);
		}

		private void tex_DAYS_INT_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.m_mthSetKeyTab(e);
		}

        private void m_txtDesc_KeyDown(object sender, KeyEventArgs e)
        {
            this.m_mthSetKeyTab(e);
        }

		
		
	}
}
