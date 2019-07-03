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
	public class frmFeeType : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private PinkieControls.ButtonXP m_btnNew;
		private PinkieControls.ButtonXP m_btnSave;
		private PinkieControls.ButtonXP m_btnExit;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtName;
		private System.Windows.Forms.GroupBox groupBox1;
		internal System.Windows.Forms.ListView m_lvw;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		internal System.Windows.Forms.RadioButton ra4;
		internal System.Windows.Forms.RadioButton ra3;
		internal System.Windows.Forms.RadioButton ra2;
		internal System.Windows.Forms.RadioButton ra1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_textUSERCODE;
		internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric m_txtSORTCODE;
		private PinkieControls.ButtonXP m_btnDel;
		private System.Windows.Forms.Label label4;
		internal SourceLibrary.Windows.Forms.TextBoxTyped txtID;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric txtLimit;
		private System.Windows.Forms.Label label5;
		internal System.Windows.Forms.RadioButton ra5;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmFeeType()
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
			this.m_btnNew = new PinkieControls.ButtonXP();
			this.m_btnSave = new PinkieControls.ButtonXP();
			this.m_btnExit = new PinkieControls.ButtonXP();
			this.m_txtName = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.ra4 = new System.Windows.Forms.RadioButton();
			this.ra3 = new System.Windows.Forms.RadioButton();
			this.ra2 = new System.Windows.Forms.RadioButton();
			this.ra1 = new System.Windows.Forms.RadioButton();
			this.m_lvw = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.label2 = new System.Windows.Forms.Label();
			this.m_textUSERCODE = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.m_txtSORTCODE = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.m_btnDel = new PinkieControls.ButtonXP();
			this.label4 = new System.Windows.Forms.Label();
			this.txtID = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.txtLimit = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
			this.label5 = new System.Windows.Forms.Label();
			this.ra5 = new System.Windows.Forms.RadioButton();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_btnNew
			// 
			this.m_btnNew.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnNew.DefaultScheme = true;
			this.m_btnNew.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnNew.Hint = "";
			this.m_btnNew.Location = new System.Drawing.Point(544, 264);
			this.m_btnNew.Name = "m_btnNew";
			this.m_btnNew.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnNew.Size = new System.Drawing.Size(112, 40);
			this.m_btnNew.TabIndex = 16;
			this.m_btnNew.Text = "新增(&A)";
			this.m_btnNew.Click += new System.EventHandler(this.m_btnNew_Click);
			// 
			// m_btnSave
			// 
			this.m_btnSave.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnSave.DefaultScheme = true;
			this.m_btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnSave.Hint = "";
			this.m_btnSave.Location = new System.Drawing.Point(544, 322);
			this.m_btnSave.Name = "m_btnSave";
			this.m_btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnSave.Size = new System.Drawing.Size(112, 40);
			this.m_btnSave.TabIndex = 17;
			this.m_btnSave.Text = "保存(&S)";
			this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
			// 
			// m_btnExit
			// 
			this.m_btnExit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnExit.DefaultScheme = true;
			this.m_btnExit.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnExit.Hint = "";
			this.m_btnExit.Location = new System.Drawing.Point(544, 438);
			this.m_btnExit.Name = "m_btnExit";
			this.m_btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnExit.Size = new System.Drawing.Size(112, 40);
			this.m_btnExit.TabIndex = 21;
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
			this.m_txtName.Location = new System.Drawing.Point(528, 152);
			this.m_txtName.MaxLength = 50;
			this.m_txtName.Name = "m_txtName";
			this.m_txtName.Size = new System.Drawing.Size(144, 23);
			this.m_txtName.TabIndex = 10;
			this.m_txtName.Text = "";
			this.m_txtName.TextChanged += new System.EventHandler(this.m_txtName_TextChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.ra5);
			this.groupBox1.Controls.Add(this.ra4);
			this.groupBox1.Controls.Add(this.ra3);
			this.groupBox1.Controls.Add(this.ra2);
			this.groupBox1.Controls.Add(this.ra1);
			this.groupBox1.Location = new System.Drawing.Point(0, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(720, 64);
			this.groupBox1.TabIndex = 25;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "费用类型";
			// 
			// ra4
			// 
			this.ra4.Location = new System.Drawing.Point(440, 24);
			this.ra4.Name = "ra4";
			this.ra4.Size = new System.Drawing.Size(88, 32);
			this.ra4.TabIndex = 3;
			this.ra4.Text = "住院发票";
			this.ra4.CheckedChanged += new System.EventHandler(this.ra1_CheckedChanged);
			// 
			// ra3
			// 
			this.ra3.Location = new System.Drawing.Point(288, 24);
			this.ra3.Name = "ra3";
			this.ra3.Size = new System.Drawing.Size(88, 32);
			this.ra3.TabIndex = 2;
			this.ra3.Text = "住院核算";
			this.ra3.CheckedChanged += new System.EventHandler(this.ra1_CheckedChanged);
			// 
			// ra2
			// 
			this.ra2.Location = new System.Drawing.Point(152, 24);
			this.ra2.Name = "ra2";
			this.ra2.Size = new System.Drawing.Size(88, 32);
			this.ra2.TabIndex = 1;
			this.ra2.Text = "门诊发票";
			this.ra2.CheckedChanged += new System.EventHandler(this.ra1_CheckedChanged);
			// 
			// ra1
			// 
			this.ra1.Location = new System.Drawing.Point(24, 24);
			this.ra1.Name = "ra1";
			this.ra1.Size = new System.Drawing.Size(88, 32);
			this.ra1.TabIndex = 0;
			this.ra1.Text = "门诊核算";
			this.ra1.CheckedChanged += new System.EventHandler(this.ra1_CheckedChanged);
			// 
			// m_lvw
			// 
			this.m_lvw.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_lvw.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					this.columnHeader1,
																					this.columnHeader2,
																					this.columnHeader3,
																					this.columnHeader4,
																					this.columnHeader5});
			this.m_lvw.FullRowSelect = true;
			this.m_lvw.GridLines = true;
			this.m_lvw.HideSelection = false;
			this.m_lvw.Location = new System.Drawing.Point(0, 80);
			this.m_lvw.Name = "m_lvw";
			this.m_lvw.Size = new System.Drawing.Size(424, 432);
			this.m_lvw.TabIndex = 50;
			this.m_lvw.View = System.Windows.Forms.View.Details;
			this.m_lvw.Click += new System.EventHandler(this.m_lvw_SelectedIndexChanged);
			this.m_lvw.SelectedIndexChanged += new System.EventHandler(this.m_lvw_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "类型ID";
			this.columnHeader1.Width = 55;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "排序号";
			this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader2.Width = 62;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "类别名称";
			this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader3.Width = 117;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "项目代码";
			this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader4.Width = 96;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "公费上限";
			this.columnHeader5.Width = 84;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(456, 190);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 19);
			this.label2.TabIndex = 2;
			this.label2.Text = "项目代码:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_textUSERCODE
			// 
			this.m_textUSERCODE.EnableAutoValidation = true;
			this.m_textUSERCODE.EnableEnterKeyValidate = true;
			this.m_textUSERCODE.EnableEscapeKeyUndo = true;
			this.m_textUSERCODE.EnableLastValidValue = true;
			this.m_textUSERCODE.ErrorProvider = null;
			this.m_textUSERCODE.ErrorProviderMessage = "Invalid value";
			this.m_textUSERCODE.ForceFormatText = true;
			this.m_textUSERCODE.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.m_textUSERCODE.Location = new System.Drawing.Point(528, 184);
			this.m_textUSERCODE.MaxLength = 10;
			this.m_textUSERCODE.Name = "m_textUSERCODE";
			this.m_textUSERCODE.Size = new System.Drawing.Size(144, 23);
			this.m_textUSERCODE.TabIndex = 15;
			this.m_textUSERCODE.Text = "";
			// 
			// m_txtSORTCODE
			// 
			this.m_txtSORTCODE.EnableAutoValidation = false;
			this.m_txtSORTCODE.EnableEnterKeyValidate = false;
			this.m_txtSORTCODE.EnableEscapeKeyUndo = true;
			this.m_txtSORTCODE.EnableLastValidValue = true;
			this.m_txtSORTCODE.ErrorProvider = null;
			this.m_txtSORTCODE.ErrorProviderMessage = "Invalid value";
			this.m_txtSORTCODE.ForceFormatText = true;
			this.m_txtSORTCODE.Location = new System.Drawing.Point(528, 120);
			this.m_txtSORTCODE.MaxLength = 2;
			this.m_txtSORTCODE.Name = "m_txtSORTCODE";
			this.m_txtSORTCODE.NumericCharStyle = SourceLibrary.Windows.Forms.NumericCharStyle.NegativeSymbol;
			this.m_txtSORTCODE.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.m_txtSORTCODE.Size = new System.Drawing.Size(144, 23);
			this.m_txtSORTCODE.TabIndex = 5;
			this.m_txtSORTCODE.Text = "";
			this.m_txtSORTCODE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(456, 125);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(70, 19);
			this.label3.TabIndex = 14;
			this.label3.Text = "排 序 号:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(456, 156);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 19);
			this.label1.TabIndex = 2;
			this.label1.Text = "名    称:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_btnDel
			// 
			this.m_btnDel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnDel.DefaultScheme = true;
			this.m_btnDel.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnDel.Hint = "";
			this.m_btnDel.Location = new System.Drawing.Point(544, 380);
			this.m_btnDel.Name = "m_btnDel";
			this.m_btnDel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnDel.Size = new System.Drawing.Size(112, 40);
			this.m_btnDel.TabIndex = 19;
			this.m_btnDel.Text = "删除(&D)";
			this.m_btnDel.Click += new System.EventHandler(this.m_btnDel_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(456, 92);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(63, 19);
			this.label4.TabIndex = 16;
			this.label4.Text = "类型 ID:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtID
			// 
			this.txtID.EnableAutoValidation = true;
			this.txtID.EnableEnterKeyValidate = true;
			this.txtID.EnableEscapeKeyUndo = true;
			this.txtID.EnableLastValidValue = true;
			this.txtID.ErrorProvider = null;
			this.txtID.ErrorProviderMessage = "Invalid value";
			this.txtID.ForceFormatText = true;
			this.txtID.Location = new System.Drawing.Point(528, 88);
			this.txtID.MaxLength = 4;
			this.txtID.Name = "txtID";
			this.txtID.Size = new System.Drawing.Size(144, 23);
			this.txtID.TabIndex = 0;
			this.txtID.Text = "";
			// 
			// txtLimit
			// 
			this.txtLimit.EnableAutoValidation = false;
			this.txtLimit.EnableEnterKeyValidate = false;
			this.txtLimit.EnableEscapeKeyUndo = true;
			this.txtLimit.EnableLastValidValue = true;
			this.txtLimit.ErrorProvider = null;
			this.txtLimit.ErrorProviderMessage = "Invalid value";
			this.txtLimit.ForceFormatText = true;
			this.txtLimit.Location = new System.Drawing.Point(528, 216);
			this.txtLimit.MaxLength = 10;
			this.txtLimit.Name = "txtLimit";
			this.txtLimit.NumericCharStyle = SourceLibrary.Windows.Forms.NumericCharStyle.NegativeSymbol;
			this.txtLimit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtLimit.Size = new System.Drawing.Size(144, 23);
			this.txtLimit.TabIndex = 20;
			this.txtLimit.Text = "";
			this.txtLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(456, 216);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(70, 19);
			this.label5.TabIndex = 52;
			this.label5.Text = "公费上限:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ra5
			// 
			this.ra5.Location = new System.Drawing.Point(584, 24);
			this.ra5.Name = "ra5";
			this.ra5.Size = new System.Drawing.Size(120, 32);
			this.ra5.TabIndex = 4;
			this.ra5.Text = "病案核算分类";
			this.ra5.CheckedChanged += new System.EventHandler(this.ra1_CheckedChanged);
			// 
			// frmFeeType
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(722, 511);
			this.Controls.Add(this.txtLimit);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtID);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.m_txtSORTCODE);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.m_txtName);
			this.Controls.Add(this.m_btnExit);
			this.Controls.Add(this.m_btnSave);
			this.Controls.Add(this.m_btnNew);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.m_textUSERCODE);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.m_btnDel);
			this.Controls.Add(this.m_lvw);
			this.Controls.Add(this.groupBox1);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.Name = "frmFeeType";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "收费项目类型";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmFeeType_KeyDown);
			this.Load += new System.EventHandler(this.frmChargeCat_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void CreateController()
		{
			this.objController=new com.digitalwave.iCare.gui.HIS.clsControlFeeType();
			objController.Set_GUI_Apperance(this);
		}
		public override void Show_MDI_Child(Form frmMDI_Parent)
		{
//			this.MdiParent = frmMDI_Parent;
//			this.WindowState = FormWindowState.Normal;
			this.ShowDialog();
		}

		private void m_btnExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void m_lvw_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_lvw.SelectedIndices.Count>0)
			{
				txtID.Text=m_lvw.SelectedItems[0].SubItems[0].Text;
				m_txtSORTCODE.Text=m_lvw.SelectedItems[0].SubItems[1].Text;
				m_txtName.Text=m_lvw.SelectedItems[0].SubItems[2].Text;
				m_textUSERCODE.Text=m_lvw.SelectedItems[0].SubItems[3].Text;
				txtLimit.Text=m_lvw.SelectedItems[0].SubItems[4].Text;
				m_txtName.Tag=m_lvw.SelectedItems[0].Tag;
			}
		}

		private void frmChargeCat_Load(object sender, System.EventArgs e)
		{
			ra1.Checked=true;
		}

		private void m_btnNew_Click(object sender, System.EventArgs e)
		{
			m_txtSORTCODE.Text="";
			m_txtName.Text="";
			m_textUSERCODE.Text="";
			m_txtName.Tag=null;
			txtID.Text="";
			txtLimit.Text="0";
			txtID.Focus();
		}

		private void m_btnSave_Click(object sender, System.EventArgs e)
		{
			((clsControlFeeType)this.objController).m_lngSave();
		}

		private void m_btnDel_Click(object sender, System.EventArgs e)
		{
			((clsControlFeeType)this.objController).m_Del();
		}

		private void ra1_CheckedChanged(object sender, System.EventArgs e)
		{
            if (((RadioButton)sender).Checked)
            {
                ((clsControlFeeType)this.objController).m_GetFeeTypeList();
            }
		}        

		private void m_txtName_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void frmFeeType_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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
