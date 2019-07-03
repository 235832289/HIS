using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.Utility;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmChargeCat 的摘要说明。
	/// </summary>
	public class frmUsage : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.Label label1;
		private PinkieControls.ButtonXP m_btnNew;
		private PinkieControls.ButtonXP m_btnSave;
		private PinkieControls.ButtonXP m_btnExit;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtName;
		private System.Windows.Forms.Label label2;
		internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric m_txtCode;
		private PinkieControls.ButtonXP m_btnDel;
        internal System.Windows.Forms.ListView m_lvw;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		internal System.Windows.Forms.TextBox m_txtPYCODE;
		internal System.Windows.Forms.TextBox m_txtWBCODE;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
        private Label label5;
        private ColumnHeader columnHeader6;
        internal ComboBox cboScope;
        private ColumnHeader columnHeader1;
        internal ComboBox m_cboPutMed_INT;
        private Label label6;
        internal ComboBox m_cboTest;
        private Label label7;
        private ColumnHeader columnHeader7;
        internal TextBox m_txtOPUsageDesc;
        private Label label8;
        private ColumnHeader columnHeader8;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmUsage()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsage));
            this.m_lvw = new System.Windows.Forms.ListView();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_cboTest = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.m_cboPutMed_INT = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_txtPYCODE = new System.Windows.Forms.TextBox();
            this.m_btnExit = new PinkieControls.ButtonXP();
            this.label2 = new System.Windows.Forms.Label();
            this.m_btnDel = new PinkieControls.ButtonXP();
            this.m_btnSave = new PinkieControls.ButtonXP();
            this.m_txtCode = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
            this.m_btnNew = new PinkieControls.ButtonXP();
            this.cboScope = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtName = new SourceLibrary.Windows.Forms.TextBoxTyped();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtWBCODE = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.m_txtOPUsageDesc = new System.Windows.Forms.TextBox();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_lvw
            // 
            this.m_lvw.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader1,
            this.columnHeader7,
            this.columnHeader8});
            this.m_lvw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lvw.FullRowSelect = true;
            this.m_lvw.GridLines = true;
            this.m_lvw.HideSelection = false;
            this.m_lvw.Location = new System.Drawing.Point(0, 0);
            this.m_lvw.MultiSelect = false;
            this.m_lvw.Name = "m_lvw";
            this.m_lvw.Size = new System.Drawing.Size(726, 531);
            this.m_lvw.TabIndex = 9;
            this.m_lvw.UseCompatibleStateImageBehavior = false;
            this.m_lvw.View = System.Windows.Forms.View.Details;
            this.m_lvw.SelectedIndexChanged += new System.EventHandler(this.m_lvw_SelectedIndexChanged_1);
            this.m_lvw.Click += new System.EventHandler(this.m_lvw_SelectedIndexChanged_1);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "类型范围";
            this.columnHeader6.Width = 74;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "助记码";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 74;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "用法名称";
            this.columnHeader3.Width = 118;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "拼音码";
            this.columnHeader4.Width = 81;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "五笔码";
            this.columnHeader5.Width = 94;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "用法类别";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "是否皮试";
            this.columnHeader7.Width = 80;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_txtOPUsageDesc);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.m_cboTest);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.m_cboPutMed_INT);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.m_txtPYCODE);
            this.groupBox1.Controls.Add(this.m_btnExit);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.m_btnDel);
            this.groupBox1.Controls.Add(this.m_btnSave);
            this.groupBox1.Controls.Add(this.m_txtCode);
            this.groupBox1.Controls.Add(this.m_btnNew);
            this.groupBox1.Controls.Add(this.cboScope);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.m_txtName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.m_txtWBCODE);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(726, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 531);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // m_cboTest
            // 
            this.m_cboTest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboTest.FormattingEnabled = true;
            this.m_cboTest.Items.AddRange(new object[] {
            "非皮试",
            "皮试"});
            this.m_cboTest.Location = new System.Drawing.Point(82, 286);
            this.m_cboTest.Name = "m_cboTest";
            this.m_cboTest.Size = new System.Drawing.Size(126, 22);
            this.m_cboTest.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 291);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 14);
            this.label7.TabIndex = 18;
            this.label7.Text = "是否皮试:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cboPutMed_INT
            // 
            this.m_cboPutMed_INT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboPutMed_INT.FormattingEnabled = true;
            this.m_cboPutMed_INT.Items.AddRange(new object[] {
            "注射",
            "非注射"});
            this.m_cboPutMed_INT.Location = new System.Drawing.Point(82, 247);
            this.m_cboPutMed_INT.Name = "m_cboPutMed_INT";
            this.m_cboPutMed_INT.Size = new System.Drawing.Size(126, 22);
            this.m_cboPutMed_INT.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 252);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 14);
            this.label6.TabIndex = 16;
            this.label6.Text = "用法类别:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtPYCODE
            // 
            this.m_txtPYCODE.Location = new System.Drawing.Point(82, 123);
            this.m_txtPYCODE.MaxLength = 20;
            this.m_txtPYCODE.Name = "m_txtPYCODE";
            this.m_txtPYCODE.Size = new System.Drawing.Size(126, 23);
            this.m_txtPYCODE.TabIndex = 2;
            // 
            // m_btnExit
            // 
            this.m_btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnExit.DefaultScheme = true;
            this.m_btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnExit.Hint = "";
            this.m_btnExit.Location = new System.Drawing.Point(60, 489);
            this.m_btnExit.Name = "m_btnExit";
            this.m_btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnExit.Size = new System.Drawing.Size(112, 32);
            this.m_btnExit.TabIndex = 9;
            this.m_btnExit.Text = "退出(Esc)";
            this.m_btnExit.Click += new System.EventHandler(this.m_btnExit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "助 记 码:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // m_btnDel
            // 
            this.m_btnDel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnDel.DefaultScheme = true;
            this.m_btnDel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnDel.Hint = "";
            this.m_btnDel.Location = new System.Drawing.Point(60, 448);
            this.m_btnDel.Name = "m_btnDel";
            this.m_btnDel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnDel.Size = new System.Drawing.Size(112, 32);
            this.m_btnDel.TabIndex = 10;
            this.m_btnDel.Text = "删除(&D)";
            this.m_btnDel.Click += new System.EventHandler(this.m_btnDel_Click_1);
            // 
            // m_btnSave
            // 
            this.m_btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnSave.DefaultScheme = true;
            this.m_btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnSave.Hint = "";
            this.m_btnSave.Location = new System.Drawing.Point(60, 406);
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnSave.Size = new System.Drawing.Size(112, 32);
            this.m_btnSave.TabIndex = 8;
            this.m_btnSave.Text = "保存(&S)";
            this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
            // 
            // m_txtCode
            // 
            this.m_txtCode.EnableAutoValidation = false;
            this.m_txtCode.EnableEnterKeyValidate = false;
            this.m_txtCode.EnableEscapeKeyUndo = true;
            this.m_txtCode.EnableLastValidValue = true;
            this.m_txtCode.ErrorProvider = null;
            this.m_txtCode.ErrorProviderMessage = "Invalid value";
            this.m_txtCode.ForceFormatText = true;
            this.m_txtCode.Location = new System.Drawing.Point(82, 40);
            this.m_txtCode.MaxLength = 3;
            this.m_txtCode.Name = "m_txtCode";
            this.m_txtCode.NumericCharStyle = SourceLibrary.Windows.Forms.NumericCharStyle.NegativeSymbol;
            this.m_txtCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.m_txtCode.Size = new System.Drawing.Size(126, 23);
            this.m_txtCode.TabIndex = 0;
            this.m_txtCode.Text = "0";
            this.m_txtCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtCode.Validating += new System.ComponentModel.CancelEventHandler(this.m_txtCode_Validating);
            // 
            // m_btnNew
            // 
            this.m_btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnNew.DefaultScheme = true;
            this.m_btnNew.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnNew.Hint = "";
            this.m_btnNew.Location = new System.Drawing.Point(60, 364);
            this.m_btnNew.Name = "m_btnNew";
            this.m_btnNew.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnNew.Size = new System.Drawing.Size(112, 32);
            this.m_btnNew.TabIndex = 9;
            this.m_btnNew.Text = "新增(&A)";
            this.m_btnNew.Click += new System.EventHandler(this.m_btnNew_Click);
            // 
            // cboScope
            // 
            this.cboScope.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboScope.FormattingEnabled = true;
            this.cboScope.Items.AddRange(new object[] {
            "公用类",
            "西药类",
            "中药类"});
            this.cboScope.Location = new System.Drawing.Point(82, 208);
            this.cboScope.Name = "cboScope";
            this.cboScope.Size = new System.Drawing.Size(126, 22);
            this.cboScope.TabIndex = 4;
            this.cboScope.SelectedIndexChanged += new System.EventHandler(this.cboScope_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "名    称:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 14);
            this.label5.TabIndex = 14;
            this.label5.Text = "范　　围:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // m_txtName
            // 
            this.m_txtName.EnableAutoValidation = false;
            this.m_txtName.EnableEnterKeyValidate = false;
            this.m_txtName.EnableEscapeKeyUndo = true;
            this.m_txtName.EnableLastValidValue = true;
            this.m_txtName.ErrorProvider = null;
            this.m_txtName.ErrorProviderMessage = "Invalid value";
            this.m_txtName.ForceFormatText = true;
            this.m_txtName.Location = new System.Drawing.Point(82, 81);
            this.m_txtName.MaxLength = 50;
            this.m_txtName.Name = "m_txtName";
            this.m_txtName.Size = new System.Drawing.Size(126, 23);
            this.m_txtName.TabIndex = 1;
            this.m_txtName.Leave += new System.EventHandler(this.m_txtName_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 13;
            this.label4.Text = "五 笔 码:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "拼 音 码:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtWBCODE
            // 
            this.m_txtWBCODE.Location = new System.Drawing.Point(82, 165);
            this.m_txtWBCODE.MaxLength = 20;
            this.m_txtWBCODE.Name = "m_txtWBCODE";
            this.m_txtWBCODE.Size = new System.Drawing.Size(126, 23);
            this.m_txtWBCODE.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 329);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 14);
            this.label8.TabIndex = 19;
            this.label8.Text = "用法描述:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtOPUsageDesc
            // 
            this.m_txtOPUsageDesc.Location = new System.Drawing.Point(82, 325);
            this.m_txtOPUsageDesc.MaxLength = 20;
            this.m_txtOPUsageDesc.Name = "m_txtOPUsageDesc";
            this.m_txtOPUsageDesc.Size = new System.Drawing.Size(126, 23);
            this.m_txtOPUsageDesc.TabIndex = 7;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "用法描述";
            this.columnHeader8.Width = 118;
            // 
            // frmUsage
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(942, 531);
            this.Controls.Add(this.m_lvw);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmUsage";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "项目用法维护";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmUsage_KeyDown);
            this.Load += new System.EventHandler(this.frmChargeCat_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		public override void CreateController()
		{
			this.objController=new com.digitalwave.iCare.gui.HIS.clsControlUsage();
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
				
				m_txtCode.Text=m_lvw.SelectedItems[0].SubItems[1].Text;
				m_txtName.Text=m_lvw.SelectedItems[0].SubItems[2].Text;
				m_txtName.Tag=m_lvw.SelectedItems[0].Tag;
			}
		}

		private void frmChargeCat_Load(object sender, System.EventArgs e)
		{
			((clsControlUsage)this.objController).m_GetUsage();
			base.m_mthSetFormControlCanBeNull(this);
		}

		private void m_btnNew_Click(object sender, System.EventArgs e)
		{
			m_txtCode.Text="";
			m_txtName.Text="";
			m_txtPYCODE.Text="";
			m_txtWBCODE.Text="";
            m_txtOPUsageDesc.Clear();
            cboScope.SelectedIndex = 0;
            m_cboPutMed_INT.SelectedIndex = 0;
            m_cboTest.SelectedIndex = 0;
			m_txtName.Tag=null;
			m_txtCode.Focus();
		}

		private void m_btnSave_Click(object sender, System.EventArgs e)
		{
			
            ((clsControlUsage)this.objController).m_lngSave();
		}

		private void frmUsage_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Escape)
			{
				if(MessageBox.Show("确认退出吗?","iCare",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
					return;
				m_btnExit_Click(sender,e);
			}
			base.m_mthSetKeyTab(e);
			

		}

		private void m_txtCode_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
		   ((clsControlUsage)this.objController).m_FillTextByCode();
		}

		private void m_lvw_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			bool IsAsc=false;//是否为升序
			if(m_lvw.Sorting==SortOrder.Ascending)
				m_lvw.Sorting=SortOrder.Descending;
			else
			{
				m_lvw.Sorting=SortOrder.Ascending;
				IsAsc=true;
			}
			m_lvw.ListViewItemSorter=new ListViewItemComparer(e.Column,IsAsc,m_lvw);
			m_lvw.Sort();
		}

		private void m_btnDel_Click_1(object sender, System.EventArgs e)
		{
			((clsControlUsage)this.objController).m_Del();
		}

		private void m_lvw_SelectedIndexChanged_1(object sender, System.EventArgs e)
		{
			if(m_lvw.SelectedIndices.Count>0)
			{
                cboScope.Text = m_lvw.SelectedItems[0].SubItems[0].Text;
				m_txtCode.Text=m_lvw.SelectedItems[0].SubItems[1].Text;
				m_txtName.Text=m_lvw.SelectedItems[0].SubItems[2].Text;
				m_txtPYCODE.Text=m_lvw.SelectedItems[0].SubItems[3].Text;
				m_txtWBCODE.Text=m_lvw.SelectedItems[0].SubItems[4].Text;
                if (m_lvw.SelectedItems[0].SubItems[5].Text.Trim() == "非注射")
                {
                    m_cboPutMed_INT.SelectedIndex = 1;
                }
                else
                {
                    m_cboPutMed_INT.SelectedIndex = 0;
                }
                if (m_lvw.SelectedItems[0].SubItems[6].Text.Trim() == "皮试")
                {
                    m_cboTest.SelectedIndex = 1;
                }
                else
                {
                    m_cboTest.SelectedIndex = 0;
                }
                m_txtOPUsageDesc.Text = m_lvw.SelectedItems[0].SubItems[7].Text;
				m_txtName.Tag=m_lvw.SelectedItems[0].Tag;
			}
		}

		private void m_txtName_Leave(object sender, System.EventArgs e)
		{
			clsCreateChinaCode getChinaCode=new clsCreateChinaCode();
			this.m_txtPYCODE.Text=getChinaCode.m_strCreateChinaCode(this.m_txtName.Text,ChinaCode.PY).Trim();
			this.m_txtWBCODE.Text=getChinaCode.m_strCreateChinaCode(this.m_txtName.Text,ChinaCode.WB).Trim();
		}

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cboScope_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



	}
}
