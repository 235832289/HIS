using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 药房单据类型设置窗口
	/// </summary>
	public class frmMedStoreOrdType : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		internal System.Windows.Forms.ListView m_lsvDetail;
		private System.Windows.Forms.ColumnHeader clhID;
		private System.Windows.Forms.ColumnHeader clhName;
		private System.Windows.Forms.ColumnHeader clhSign;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric m_txtID;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtName;
		internal System.Windows.Forms.ComboBox m_cboSign;
		internal PinkieControls.ButtonXP m_cmdSave;
		internal PinkieControls.ButtonXP m_cmdNew;
		internal PinkieControls.ButtonXP m_cmdDelete;
		internal PinkieControls.ButtonXP m_cmdRefersh;
		internal PinkieControls.ButtonXP m_cmdClose;
        internal TextBox textBox1;
        private Label label5;
        internal CheckBox checkBox1;
        private Label label1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// 
		/// </summary>
		public frmMedStoreOrdType()
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cboSign = new System.Windows.Forms.ComboBox();
            this.m_txtName = new SourceLibrary.Windows.Forms.TextBoxTyped();
            this.m_txtID = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_cmdClose = new PinkieControls.ButtonXP();
            this.m_cmdRefersh = new PinkieControls.ButtonXP();
            this.m_cmdDelete = new PinkieControls.ButtonXP();
            this.m_cmdNew = new PinkieControls.ButtonXP();
            this.m_cmdSave = new PinkieControls.ButtonXP();
            this.m_lsvDetail = new System.Windows.Forms.ListView();
            this.clhID = new System.Windows.Forms.ColumnHeader();
            this.clhName = new System.Windows.Forms.ColumnHeader();
            this.clhSign = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.m_cboSign);
            this.groupBox1.Controls.Add(this.m_txtName);
            this.groupBox1.Controls.Add(this.m_txtID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 191);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(104, 112);
            this.textBox1.MaxLength = 2;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(38, 23);
            this.textBox1.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.DarkOrange;
            this.label5.Location = new System.Drawing.Point(150, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 23);
            this.label5.TabIndex = 18;
            this.label5.Text = "[两位英文字母]";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(104, 154);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(152, 18);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "药库出药给药房使用";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 23);
            this.label1.TabIndex = 17;
            this.label1.Text = "单据号标识:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_cboSign
            // 
            this.m_cboSign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboSign.Items.AddRange(new object[] {
            "药房进药",
            "药房出药",
            "调拔入库",
            "调拔出库"});
            this.m_cboSign.Location = new System.Drawing.Point(104, 72);
            this.m_cboSign.Name = "m_cboSign";
            this.m_cboSign.Size = new System.Drawing.Size(121, 22);
            this.m_cboSign.TabIndex = 5;
            // 
            // m_txtName
            // 
            this.m_txtName.EnableAutoValidation = false;
            this.m_txtName.EnableEnterKeyValidate = true;
            this.m_txtName.EnableEscapeKeyUndo = true;
            this.m_txtName.EnableLastValidValue = true;
            this.m_txtName.ErrorProvider = null;
            this.m_txtName.ErrorProviderMessage = "Invalid value";
            this.m_txtName.ForceFormatText = true;
            this.m_txtName.Location = new System.Drawing.Point(104, 32);
            this.m_txtName.Name = "m_txtName";
            this.m_txtName.Size = new System.Drawing.Size(121, 23);
            this.m_txtName.TabIndex = 4;
            // 
            // m_txtID
            // 
            this.m_txtID.EnableAutoValidation = false;
            this.m_txtID.EnableEnterKeyValidate = true;
            this.m_txtID.EnableEscapeKeyUndo = true;
            this.m_txtID.EnableLastValidValue = true;
            this.m_txtID.ErrorProvider = null;
            this.m_txtID.ErrorProviderMessage = "Invalid value";
            this.m_txtID.ForceFormatText = true;
            this.m_txtID.Location = new System.Drawing.Point(104, 22);
            this.m_txtID.Name = "m_txtID";
            this.m_txtID.NumericCharStyle = ((SourceLibrary.Windows.Forms.NumericCharStyle)((SourceLibrary.Windows.Forms.NumericCharStyle.DecimalSeparator | SourceLibrary.Windows.Forms.NumericCharStyle.NegativeSymbol)));
            this.m_txtID.Size = new System.Drawing.Size(121, 23);
            this.m_txtID.TabIndex = 3;
            this.m_txtID.Text = "0";
            this.m_txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtID.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "标识:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "单据类型名称:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.m_cmdClose);
            this.groupBox2.Controls.Add(this.m_cmdRefersh);
            this.groupBox2.Controls.Add(this.m_cmdDelete);
            this.groupBox2.Controls.Add(this.m_cmdNew);
            this.groupBox2.Controls.Add(this.m_cmdSave);
            this.groupBox2.Location = new System.Drawing.Point(0, 220);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(272, 292);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // m_cmdClose
            // 
            this.m_cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdClose.DefaultScheme = true;
            this.m_cmdClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdClose.Hint = "";
            this.m_cmdClose.Location = new System.Drawing.Point(69, 219);
            this.m_cmdClose.Name = "m_cmdClose";
            this.m_cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClose.Size = new System.Drawing.Size(152, 32);
            this.m_cmdClose.TabIndex = 4;
            this.m_cmdClose.Text = "退出(&E)";
            this.m_cmdClose.Click += new System.EventHandler(this.m_cmdClose_Click);
            // 
            // m_cmdRefersh
            // 
            this.m_cmdRefersh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdRefersh.DefaultScheme = true;
            this.m_cmdRefersh.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdRefersh.Hint = "";
            this.m_cmdRefersh.Location = new System.Drawing.Point(69, 171);
            this.m_cmdRefersh.Name = "m_cmdRefersh";
            this.m_cmdRefersh.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdRefersh.Size = new System.Drawing.Size(152, 32);
            this.m_cmdRefersh.TabIndex = 3;
            this.m_cmdRefersh.Text = "刷新(&R)";
            this.m_cmdRefersh.Click += new System.EventHandler(this.m_cmdRefersh_Click);
            // 
            // m_cmdDelete
            // 
            this.m_cmdDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdDelete.DefaultScheme = true;
            this.m_cmdDelete.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdDelete.Hint = "";
            this.m_cmdDelete.Location = new System.Drawing.Point(69, 123);
            this.m_cmdDelete.Name = "m_cmdDelete";
            this.m_cmdDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDelete.Size = new System.Drawing.Size(152, 32);
            this.m_cmdDelete.TabIndex = 2;
            this.m_cmdDelete.Text = "删除(&D)";
            this.m_cmdDelete.Click += new System.EventHandler(this.m_cmdDelete_Click);
            // 
            // m_cmdNew
            // 
            this.m_cmdNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdNew.DefaultScheme = true;
            this.m_cmdNew.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdNew.Hint = "";
            this.m_cmdNew.Location = new System.Drawing.Point(69, 75);
            this.m_cmdNew.Name = "m_cmdNew";
            this.m_cmdNew.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdNew.Size = new System.Drawing.Size(152, 32);
            this.m_cmdNew.TabIndex = 1;
            this.m_cmdNew.Text = "新增(&A)";
            this.m_cmdNew.Click += new System.EventHandler(this.m_cmdNew_Click);
            // 
            // m_cmdSave
            // 
            this.m_cmdSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdSave.DefaultScheme = true;
            this.m_cmdSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSave.Hint = "";
            this.m_cmdSave.Location = new System.Drawing.Point(69, 27);
            this.m_cmdSave.Name = "m_cmdSave";
            this.m_cmdSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSave.Size = new System.Drawing.Size(152, 32);
            this.m_cmdSave.TabIndex = 0;
            this.m_cmdSave.Text = "保存(&S)";
            this.m_cmdSave.Click += new System.EventHandler(this.m_cmdSave_Click);
            // 
            // m_lsvDetail
            // 
            this.m_lsvDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lsvDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clhID,
            this.clhName,
            this.clhSign,
            this.columnHeader1,
            this.columnHeader2});
            this.m_lsvDetail.FullRowSelect = true;
            this.m_lsvDetail.GridLines = true;
            this.m_lsvDetail.Location = new System.Drawing.Point(280, 8);
            this.m_lsvDetail.Name = "m_lsvDetail";
            this.m_lsvDetail.Size = new System.Drawing.Size(672, 504);
            this.m_lsvDetail.TabIndex = 2;
            this.m_lsvDetail.UseCompatibleStateImageBehavior = false;
            this.m_lsvDetail.View = System.Windows.Forms.View.Details;
            this.m_lsvDetail.DoubleClick += new System.EventHandler(this.m_lsvDetail_DoubleClick);
            // 
            // clhID
            // 
            this.clhID.Text = "单据类型ID";
            this.clhID.Width = 89;
            // 
            // clhName
            // 
            this.clhName.Text = "单据类型名称";
            this.clhName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clhName.Width = 106;
            // 
            // clhSign
            // 
            this.clhSign.Text = "标识";
            this.clhSign.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clhSign.Width = 80;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "单据号标识";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "药库对药房";
            this.columnHeader2.Width = 91;
            // 
            // frmMedStoreOrdType
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(962, 519);
            this.Controls.Add(this.m_lsvDetail);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMedStoreOrdType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "药房单据类型设置";
            this.Load += new System.EventHandler(this.frmMedStoreOrdType_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 
		/// </summary>
		public override void CreateController()
		{
			this.objController = new clsControlMedStoreOrdType();
			this.objController.Set_GUI_Apperance(this);
		}

		private void frmMedStoreOrdType_Load(object sender, System.EventArgs e)
		{
			base.m_mthSetFormControlCanBeNull(this);
			((clsControlMedStoreOrdType)this.objController).m_mthInit();
		}

		private void m_cmdSave_Click(object sender, System.EventArgs e)
		{
			((clsControlMedStoreOrdType)this.objController).m_mthSave();
		}

		private void m_cmdNew_Click(object sender, System.EventArgs e)
		{
			((clsControlMedStoreOrdType)this.objController).m_mthSetViewInfo(null);
		}

		private void m_cmdDelete_Click(object sender, System.EventArgs e)
		{
			((clsControlMedStoreOrdType)this.objController).m_mthDoDelete();
		}

		private void m_cmdRefersh_Click(object sender, System.EventArgs e)
		{
			((clsControlMedStoreOrdType)this.objController).m_mthGetDetailList();
		}

		private void m_cmdClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void m_lsvDetail_DoubleClick(object sender, System.EventArgs e)
		{
			((clsControlMedStoreOrdType)this.objController).m_mthDetailSel();
		}

	}
}
