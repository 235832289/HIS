using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 药房窗口设置
	/// Create by kong 2004-07-06
	/// </summary>
	public class frmMedStoreWin : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		internal System.Windows.Forms.ComboBox m_cboMedStore;
		private System.Windows.Forms.Label label2;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtWinName;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ColumnHeader clhWinName;
		internal System.Windows.Forms.ListView m_lsvDetail;
		private PinkieControls.ButtonXP m_cmdSave;
		private PinkieControls.ButtonXP m_cmdNew;
		private PinkieControls.ButtonXP m_cmdDelete;
		private PinkieControls.ButtonXP m_cmdRefersh;
		private PinkieControls.ButtonXP m_cmdClose;
		private System.Windows.Forms.ColumnHeader clhMedStoreName;
		private System.Windows.Forms.ColumnHeader clhMedStoreWindowID;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		internal System.Windows.Forms.ComboBox m_cboWindowType;
		internal System.Windows.Forms.ComboBox m_cboWorkStatus;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
        private GroupBox groupBox3;
        internal ComboBox m_cboWinStyle;
        private Label label5;
        internal ComboBox cboWinprop;
        private Label label6;
        private ColumnHeader columnHeader3;
        private PinkieControls.ButtonXP btnPrivate;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// 
		/// </summary>
		public frmMedStoreWin()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMedStoreWin));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_cboWindowType = new System.Windows.Forms.ComboBox();
            this.m_lsvDetail = new System.Windows.Forms.ListView();
            this.clhMedStoreWindowID = new System.Windows.Forms.ColumnHeader();
            this.clhMedStoreName = new System.Windows.Forms.ColumnHeader();
            this.clhWinName = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPrivate = new PinkieControls.ButtonXP();
            this.m_cmdClose = new PinkieControls.ButtonXP();
            this.m_cmdRefersh = new PinkieControls.ButtonXP();
            this.m_cmdDelete = new PinkieControls.ButtonXP();
            this.m_cmdNew = new PinkieControls.ButtonXP();
            this.m_cmdSave = new PinkieControls.ButtonXP();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboWinprop = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_cboWinStyle = new System.Windows.Forms.ComboBox();
            this.m_cboWorkStatus = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtWinName = new SourceLibrary.Windows.Forms.TextBoxTyped();
            this.label2 = new System.Windows.Forms.Label();
            this.m_cboMedStore = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.m_cboWindowType);
            this.groupBox3.Location = new System.Drawing.Point(8, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(208, 47);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 5;
            this.label5.Text = "窗口分类";
            // 
            // m_cboWindowType
            // 
            this.m_cboWindowType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboWindowType.Items.AddRange(new object[] {
            "发药窗口",
            "配药窗口",
            "全部"});
            this.m_cboWindowType.Location = new System.Drawing.Point(72, 17);
            this.m_cboWindowType.Name = "m_cboWindowType";
            this.m_cboWindowType.Size = new System.Drawing.Size(120, 22);
            this.m_cboWindowType.TabIndex = 3;
            this.m_cboWindowType.SelectedIndexChanged += new System.EventHandler(this.m_cboWindowType_SelectedIndexChanged);
            this.m_cboWindowType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cboWindowType_KeyDown);
            // 
            // m_lsvDetail
            // 
            this.m_lsvDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lsvDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clhMedStoreWindowID,
            this.clhMedStoreName,
            this.clhWinName,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.m_lsvDetail.FullRowSelect = true;
            this.m_lsvDetail.GridLines = true;
            this.m_lsvDetail.HideSelection = false;
            this.m_lsvDetail.Location = new System.Drawing.Point(224, 8);
            this.m_lsvDetail.MultiSelect = false;
            this.m_lsvDetail.Name = "m_lsvDetail";
            this.m_lsvDetail.Size = new System.Drawing.Size(712, 648);
            this.m_lsvDetail.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.m_lsvDetail.TabIndex = 2;
            this.m_lsvDetail.UseCompatibleStateImageBehavior = false;
            this.m_lsvDetail.View = System.Windows.Forms.View.Details;
            this.m_lsvDetail.DoubleClick += new System.EventHandler(this.m_lsvDetail_DoubleClick);
            // 
            // clhMedStoreWindowID
            // 
            this.clhMedStoreWindowID.Text = "窗口ID";
            this.clhMedStoreWindowID.Width = 75;
            // 
            // clhMedStoreName
            // 
            this.clhMedStoreName.Text = "药房名称";
            this.clhMedStoreName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clhMedStoreName.Width = 179;
            // 
            // clhWinName
            // 
            this.clhWinName.Text = "窗口名";
            this.clhWinName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clhWinName.Width = 143;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "窗口类型";
            this.columnHeader1.Width = 94;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "工作状态";
            this.columnHeader2.Width = 81;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "窗口属性";
            this.columnHeader3.Width = 90;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.btnPrivate);
            this.groupBox2.Controls.Add(this.m_cmdClose);
            this.groupBox2.Controls.Add(this.m_cmdRefersh);
            this.groupBox2.Controls.Add(this.m_cmdDelete);
            this.groupBox2.Controls.Add(this.m_cmdNew);
            this.groupBox2.Controls.Add(this.m_cmdSave);
            this.groupBox2.Location = new System.Drawing.Point(8, 284);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(208, 372);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnPrivate
            // 
            this.btnPrivate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnPrivate.DefaultScheme = true;
            this.btnPrivate.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPrivate.Hint = "";
            this.btnPrivate.Location = new System.Drawing.Point(38, 242);
            this.btnPrivate.Name = "btnPrivate";
            this.btnPrivate.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnPrivate.Size = new System.Drawing.Size(128, 32);
            this.btnPrivate.TabIndex = 5;
            this.btnPrivate.Text = "专用窗口设置(&P)";
            this.btnPrivate.Click += new System.EventHandler(this.btnPrivate_Click);
            // 
            // m_cmdClose
            // 
            this.m_cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdClose.DefaultScheme = true;
            this.m_cmdClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdClose.Hint = "";
            this.m_cmdClose.Location = new System.Drawing.Point(38, 297);
            this.m_cmdClose.Name = "m_cmdClose";
            this.m_cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClose.Size = new System.Drawing.Size(128, 32);
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
            this.m_cmdRefersh.Location = new System.Drawing.Point(38, 187);
            this.m_cmdRefersh.Name = "m_cmdRefersh";
            this.m_cmdRefersh.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdRefersh.Size = new System.Drawing.Size(128, 32);
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
            this.m_cmdDelete.Location = new System.Drawing.Point(38, 132);
            this.m_cmdDelete.Name = "m_cmdDelete";
            this.m_cmdDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDelete.Size = new System.Drawing.Size(128, 32);
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
            this.m_cmdNew.Location = new System.Drawing.Point(38, 22);
            this.m_cmdNew.Name = "m_cmdNew";
            this.m_cmdNew.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdNew.Size = new System.Drawing.Size(128, 32);
            this.m_cmdNew.TabIndex = 1;
            this.m_cmdNew.Text = "新增(&A)";
            this.m_cmdNew.Click += new System.EventHandler(this.m_cmdNew_Click);
            this.m_cmdNew.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cmdNew_KeyDown);
            // 
            // m_cmdSave
            // 
            this.m_cmdSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdSave.DefaultScheme = true;
            this.m_cmdSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSave.Hint = "";
            this.m_cmdSave.Location = new System.Drawing.Point(38, 77);
            this.m_cmdSave.Name = "m_cmdSave";
            this.m_cmdSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSave.Size = new System.Drawing.Size(128, 32);
            this.m_cmdSave.TabIndex = 0;
            this.m_cmdSave.Text = "保存(&S)";
            this.m_cmdSave.Click += new System.EventHandler(this.m_cmdSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboWinprop);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.m_cboWinStyle);
            this.groupBox1.Controls.Add(this.m_cboWorkStatus);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.m_txtWinName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.m_cboMedStore);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 238);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cboWinprop
            // 
            this.cboWinprop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWinprop.Items.AddRange(new object[] {
            "普通",
            "专用"});
            this.cboWinprop.Location = new System.Drawing.Point(72, 195);
            this.cboWinprop.Name = "cboWinprop";
            this.cboWinprop.Size = new System.Drawing.Size(120, 22);
            this.cboWinprop.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 6;
            this.label6.Text = "窗口属性";
            // 
            // m_cboWinStyle
            // 
            this.m_cboWinStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboWinStyle.Items.AddRange(new object[] {
            "发药窗口",
            "配药窗口"});
            this.m_cboWinStyle.Location = new System.Drawing.Point(72, 113);
            this.m_cboWinStyle.Name = "m_cboWinStyle";
            this.m_cboWinStyle.Size = new System.Drawing.Size(120, 22);
            this.m_cboWinStyle.TabIndex = 3;
            this.m_cboWinStyle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cboWinStyle_KeyDown);
            // 
            // m_cboWorkStatus
            // 
            this.m_cboWorkStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboWorkStatus.Items.AddRange(new object[] {
            "停止中",
            "工作中"});
            this.m_cboWorkStatus.Location = new System.Drawing.Point(72, 154);
            this.m_cboWorkStatus.Name = "m_cboWorkStatus";
            this.m_cboWorkStatus.Size = new System.Drawing.Size(120, 22);
            this.m_cboWorkStatus.TabIndex = 4;
            this.m_cboWorkStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cboWorkStatus_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 5;
            this.label4.Text = "工作状态";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "窗口类型";
            // 
            // m_txtWinName
            // 
            this.m_txtWinName.EnableAutoValidation = false;
            this.m_txtWinName.EnableEnterKeyValidate = true;
            this.m_txtWinName.EnableEscapeKeyUndo = true;
            this.m_txtWinName.EnableLastValidValue = true;
            this.m_txtWinName.ErrorProvider = null;
            this.m_txtWinName.ErrorProviderMessage = "Invalid value";
            this.m_txtWinName.ForceFormatText = true;
            this.m_txtWinName.Location = new System.Drawing.Point(72, 71);
            this.m_txtWinName.Name = "m_txtWinName";
            this.m_txtWinName.Size = new System.Drawing.Size(120, 23);
            this.m_txtWinName.TabIndex = 2;
            this.m_txtWinName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtWinName_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "药房";
            // 
            // m_cboMedStore
            // 
            this.m_cboMedStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboMedStore.Location = new System.Drawing.Point(72, 30);
            this.m_cboMedStore.Name = "m_cboMedStore";
            this.m_cboMedStore.Size = new System.Drawing.Size(120, 22);
            this.m_cboMedStore.TabIndex = 1;
            this.m_cboMedStore.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cboMedStore_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "窗口名";
            // 
            // frmMedStoreWin
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(946, 665);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.m_lsvDetail);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMedStoreWin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "药房窗口设置";
            this.Load += new System.EventHandler(this.frmMedStoreWin_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 
		/// </summary>
		public override void CreateController()
		{
			this.objController = new clsControlMedStoreWin();
			this.objController.Set_GUI_Apperance(this);
		}

		private void frmMedStoreWin_Load(object sender, System.EventArgs e)
		{
			base.m_mthSetFormControlCanBeNull(this);
			this.m_cboWindowType.SelectedIndex=2;
            ((clsControlMedStoreWin)this.objController).m_mthInit();
            this.m_cboWindowType.Focus();
		}

		private void m_lsvDetail_DoubleClick(object sender, System.EventArgs e)
		{
			((clsControlMedStoreWin)this.objController).m_mthDetailSel();
		}

		private void m_cmdSave_Click(object sender, System.EventArgs e)
		{
			((clsControlMedStoreWin)this.objController).m_mthSave();
		}

		private void m_cmdNew_Click(object sender, System.EventArgs e)
		{
			((clsControlMedStoreWin)this.objController).m_mthSetViewInfo(null);
		}

		private void m_cmdDelete_Click(object sender, System.EventArgs e)
		{
			((clsControlMedStoreWin)this.objController).m_mthDoDelete();
		}

		private void m_cmdRefersh_Click(object sender, System.EventArgs e)
		{
			((clsControlMedStoreWin)this.objController).m_mthGetDetailList();
		}

		private void m_cmdClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void m_cboWindowType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            if (this.m_cboWindowType.SelectedIndex != 2)
            {
                this.m_cboWinStyle.SelectedIndex = this.m_cboWindowType.SelectedIndex;
                this.m_cboWinStyle.Enabled = false;
            }
            else
            {
                this.m_cboWinStyle.Enabled = true;
                this.m_cboWinStyle.SelectedIndex = -1;
            }
            ((clsControlMedStoreWin)this.objController).m_objItem = null;
			((clsControlMedStoreWin)this.objController).m_mthGetDetailList();
            this.m_cboMedStore.SelectedIndex = -1;
            this.m_cboWorkStatus.SelectedIndex = -1;
            this.m_txtWinName.Text = "";


		}

		private void m_cboMedStore_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
			 SendKeys.Send("{Tab}");
			}
		}

		private void m_txtWinName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{     
                    SendKeys.Send("{Tab}");

			}
		}

		private void m_cboWindowType_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{

                this.m_cboMedStore.Focus();
                this.m_cboMedStore.SelectedIndex = 0;
                
			}
		}

		private void m_cboWorkStatus_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				this.m_cmdSave.Focus();
			}
		}

        private void m_cboWinStyle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_cboWorkStatus.SelectedIndex = 1;
                SendKeys.Send("{Tab}");

            }
        }

        private void m_cmdNew_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.m_cboMedStore.Focus();
            }
        }

        private void btnPrivate_Click(object sender, EventArgs e)
        {
            frmMedprivatewinset fs = new frmMedprivatewinset();
            fs.ShowDialog();
        }

	}
}
