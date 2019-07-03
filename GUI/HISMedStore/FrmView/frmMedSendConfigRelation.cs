using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 发药窗口与配药窗口的关系 的摘要说明。
	///  Create by xgpeng 2006-02-15
	/// </summary>
	public class frmMedSendConfigRelation  : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		#region 系统定义
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox5;
		internal PinkieControls.ButtonXP buttonXP3;
		internal PinkieControls.ButtonXP buttonXP4;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		internal System.Windows.Forms.ComboBox m_cboMedStore;
		internal System.Windows.Forms.ListView m_lsvGive;
		internal System.Windows.Forms.ListView m_lsvConfigGive;
		internal System.Windows.Forms.ListView m_lsvConfig;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		internal PinkieControls.ButtonXP m_cmdDown;
		internal PinkieControls.ButtonXP m_cmdUp;
		internal PinkieControls.ButtonXP m_cmdSave;
		private System.Windows.Forms.Label label1;
		#endregion
		#region
	/// <summary>
	/// 构造函数
	/// </summary>
		public frmMedSendConfigRelation()
		{ 
			InitializeComponent();
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion

		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.m_cboMedStore = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.buttonXP4 = new PinkieControls.ButtonXP();
			this.buttonXP3 = new PinkieControls.ButtonXP();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.m_lsvGive = new System.Windows.Forms.ListView();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.m_cmdSave = new PinkieControls.ButtonXP();
			this.m_lsvConfigGive = new System.Windows.Forms.ListView();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
			this.m_cmdDown = new PinkieControls.ButtonXP();
			this.m_cmdUp = new PinkieControls.ButtonXP();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.m_lsvConfig = new System.Windows.Forms.ListView();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.m_cboMedStore);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.groupBox1.Location = new System.Drawing.Point(8, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(928, 48);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// m_cboMedStore
			// 
			this.m_cboMedStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboMedStore.Location = new System.Drawing.Point(88, 16);
			this.m_cboMedStore.Name = "m_cboMedStore";
			this.m_cboMedStore.Size = new System.Drawing.Size(120, 22);
			this.m_cboMedStore.TabIndex = 2;
			this.m_cboMedStore.SelectedIndexChanged += new System.EventHandler(this.m_cboMedStore_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(63, 19);
			this.label1.TabIndex = 0;
			this.label1.Text = "药房名称";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.buttonXP4);
			this.groupBox2.Controls.Add(this.buttonXP3);
			this.groupBox2.Controls.Add(this.groupBox5);
			this.groupBox2.Controls.Add(this.groupBox4);
			this.groupBox2.Controls.Add(this.groupBox3);
			this.groupBox2.Location = new System.Drawing.Point(8, 48);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(928, 512);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			// 
			// buttonXP4
			// 
			this.buttonXP4.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.buttonXP4.DefaultScheme = true;
			this.buttonXP4.DialogResult = System.Windows.Forms.DialogResult.None;
			this.buttonXP4.Hint = "";
			this.buttonXP4.Location = new System.Drawing.Point(608, 208);
			this.buttonXP4.Name = "buttonXP4";
			this.buttonXP4.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.buttonXP4.Size = new System.Drawing.Size(72, 24);
			this.buttonXP4.TabIndex = 5;
			this.buttonXP4.Text = "<—";
			this.buttonXP4.Click += new System.EventHandler(this.buttonXP4_Click);
			// 
			// buttonXP3
			// 
			this.buttonXP3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.buttonXP3.DefaultScheme = true;
			this.buttonXP3.DialogResult = System.Windows.Forms.DialogResult.None;
			this.buttonXP3.Hint = "";
			this.buttonXP3.Location = new System.Drawing.Point(608, 280);
			this.buttonXP3.Name = "buttonXP3";
			this.buttonXP3.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.buttonXP3.Size = new System.Drawing.Size(72, 24);
			this.buttonXP3.TabIndex = 4;
			this.buttonXP3.Text = "—>";
			this.buttonXP3.Click += new System.EventHandler(this.buttonXP3_Click);
			// 
			// groupBox5
			// 
			this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox5.Controls.Add(this.m_lsvGive);
			this.groupBox5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.groupBox5.Location = new System.Drawing.Point(680, 24);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(240, 458);
			this.groupBox5.TabIndex = 3;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "发药窗口";
			// 
			// m_lsvGive
			// 
			this.m_lsvGive.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lsvGive.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader7,
																						this.columnHeader9,
																						this.columnHeader5});
			this.m_lsvGive.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lsvGive.FullRowSelect = true;
			this.m_lsvGive.GridLines = true;
			this.m_lsvGive.HideSelection = false;
			this.m_lsvGive.Location = new System.Drawing.Point(16, 24);
			this.m_lsvGive.MultiSelect = false;
			this.m_lsvGive.Name = "m_lsvGive";
			this.m_lsvGive.Size = new System.Drawing.Size(216, 426);
			this.m_lsvGive.TabIndex = 3;
			this.m_lsvGive.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "窗口ID";
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "窗口名称";
			this.columnHeader9.Width = 75;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "工作状态";
			this.columnHeader5.Width = 71;
			// 
			// groupBox4
			// 
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox4.Controls.Add(this.m_cmdSave);
			this.groupBox4.Controls.Add(this.m_lsvConfigGive);
			this.groupBox4.Controls.Add(this.m_cmdDown);
			this.groupBox4.Controls.Add(this.m_cmdUp);
			this.groupBox4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.groupBox4.Location = new System.Drawing.Point(284, 24);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(324, 458);
			this.groupBox4.TabIndex = 2;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "配药窗口—>发药窗口";
			// 
			// m_cmdSave
			// 
			this.m_cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_cmdSave.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdSave.DefaultScheme = true;
			this.m_cmdSave.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdSave.Hint = "";
			this.m_cmdSave.Location = new System.Drawing.Point(72, 427);
			this.m_cmdSave.Name = "m_cmdSave";
			this.m_cmdSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdSave.Size = new System.Drawing.Size(160, 24);
			this.m_cmdSave.TabIndex = 3;
			this.m_cmdSave.Text = "保存(&S)";
			this.m_cmdSave.Click += new System.EventHandler(this.m_cmdSave_Click);
			// 
			// m_lsvConfigGive
			// 
			this.m_lsvConfigGive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_lsvConfigGive.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							  this.columnHeader2,
																							  this.columnHeader3,
																							  this.columnHeader10});
			this.m_lsvConfigGive.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lsvConfigGive.FullRowSelect = true;
			this.m_lsvConfigGive.GridLines = true;
			this.m_lsvConfigGive.HideSelection = false;
			this.m_lsvConfigGive.Location = new System.Drawing.Point(8, 24);
			this.m_lsvConfigGive.MultiSelect = false;
			this.m_lsvConfigGive.Name = "m_lsvConfigGive";
			this.m_lsvConfigGive.Size = new System.Drawing.Size(288, 395);
			this.m_lsvConfigGive.TabIndex = 2;
			this.m_lsvConfigGive.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "配药窗口";
			this.columnHeader2.Width = 103;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "发药窗口";
			this.columnHeader3.Width = 104;
			// 
			// columnHeader10
			// 
			this.columnHeader10.Text = "顺序号";
			this.columnHeader10.Width = 68;
			// 
			// m_cmdDown
			// 
			this.m_cmdDown.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdDown.DefaultScheme = true;
			this.m_cmdDown.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdDown.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cmdDown.Hint = "";
			this.m_cmdDown.Location = new System.Drawing.Point(304, 240);
			this.m_cmdDown.Name = "m_cmdDown";
			this.m_cmdDown.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdDown.Size = new System.Drawing.Size(16, 56);
			this.m_cmdDown.TabIndex = 1;
			this.m_cmdDown.Text = "↓";
			this.m_cmdDown.Click += new System.EventHandler(this.m_cmdDown_Click);
			// 
			// m_cmdUp
			// 
			this.m_cmdUp.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdUp.DefaultScheme = true;
			this.m_cmdUp.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdUp.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cmdUp.Hint = "";
			this.m_cmdUp.Location = new System.Drawing.Point(304, 168);
			this.m_cmdUp.Name = "m_cmdUp";
			this.m_cmdUp.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdUp.Size = new System.Drawing.Size(16, 56);
			this.m_cmdUp.TabIndex = 0;
			this.m_cmdUp.Text = "↑";
			this.m_cmdUp.Click += new System.EventHandler(this.m_cmdUp_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox3.Controls.Add(this.m_lsvConfig);
			this.groupBox3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.groupBox3.Location = new System.Drawing.Point(8, 24);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(264, 458);
			this.groupBox3.TabIndex = 0;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "配药窗口";
			// 
			// m_lsvConfig
			// 
			this.m_lsvConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_lsvConfig.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						  this.columnHeader4,
																						  this.columnHeader6,
																						  this.columnHeader11});
			this.m_lsvConfig.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lsvConfig.FullRowSelect = true;
			this.m_lsvConfig.GridLines = true;
			this.m_lsvConfig.HideSelection = false;
			this.m_lsvConfig.Location = new System.Drawing.Point(8, 24);
			this.m_lsvConfig.MultiSelect = false;
			this.m_lsvConfig.Name = "m_lsvConfig";
			this.m_lsvConfig.Size = new System.Drawing.Size(240, 426);
			this.m_lsvConfig.TabIndex = 3;
			this.m_lsvConfig.View = System.Windows.Forms.View.Details;
			this.m_lsvConfig.SelectedIndexChanged += new System.EventHandler(this.m_lsvConfig_SelectedIndexChanged);
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "窗口ID";
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "窗口名称";
			this.columnHeader6.Width = 88;
			// 
			// columnHeader11
			// 
			this.columnHeader11.Text = "工作状态";
			this.columnHeader11.Width = 80;
			// 
			// frmMedSendConfigRelation
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
			this.ClientSize = new System.Drawing.Size(944, 565);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.Name = "frmMedSendConfigRelation";
			this.Text = "药房窗口配置关系";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMedSendConfigRelation_Closing);
			this.Load += new System.EventHandler(this.frmMedSendConfigRelation_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		/// <summary>
		/// 
		/// </summary>
		public override void CreateController()
		{
			this.objController = new clsCtlMedSendConfigRelation();
			this.objController.Set_GUI_Apperance(this);
		}

		private void frmMedSendConfigRelation_Load(object sender, System.EventArgs e)
		{
		 ((clsCtlMedSendConfigRelation)this.objController).m_GetMedStoreInfo();
			((clsCtlMedSendConfigRelation)this.objController).m_GetMedWindowInfo();
			
		}

		private void m_cboMedStore_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		   ((clsCtlMedSendConfigRelation)this.objController).m_GetMedWindowInfo();
		}

		private void m_lsvConfig_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.m_lsvConfig.SelectedItems.Count==0)
			{
				//MessageBox.Show("请选择配药窗口记录","提示");
				return;
			}
			((clsCtlMedSendConfigRelation)this.objController).m_GetMedWinByID();
		}

		private void buttonXP4_Click(object sender, System.EventArgs e)
		{
			((clsCtlMedSendConfigRelation)this.objController).m_AddMedSendGiveRelation();
		}

		private void buttonXP3_Click(object sender, System.EventArgs e)
		{
			((clsCtlMedSendConfigRelation)this.objController).m_DelMedSendGiveRelation();
		}
		#region 向上移动记录
		private void m_cmdUp_Click(object sender, System.EventArgs e) 
		{
			((clsCtlMedSendConfigRelation)this.objController).m_MoveUpRecord();
            flage=false;
		}
		#endregion

		#region 向下移动记录
		private void m_cmdDown_Click(object sender, System.EventArgs e)
		{
		((clsCtlMedSendConfigRelation)this.objController).m_MoveDownRecord();
			flage=false;
		}
		#endregion
		/// <summary>
		/// 判断是否保存移动记录
		/// </summary>
       public bool flage=true; 
		private void m_cmdSave_Click(object sender, System.EventArgs e)
		{
			((clsCtlMedSendConfigRelation)this.objController).m_MovRecored();
			
		}

		private void frmMedSendConfigRelation_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{

			if(!this.flage)
			{
				if(MessageBox.Show("尚未保存修改的内容,是否保存？","系统提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
				  ((clsCtlMedSendConfigRelation)this.objController).m_MovRecored();
				}
				else
					e.Cancel=false;
			 }
			else
				e.Cancel=false;
		}
	}
}
