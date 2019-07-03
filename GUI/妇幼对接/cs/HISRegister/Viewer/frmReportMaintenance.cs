using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.iCare.middletier.HI;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmReportMaintenance 的摘要说明。
	/// </summary>
	public class frmReportMaintenance  : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.Panel panel1;
		internal System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Label label1;
		internal System.Windows.Forms.TextBox textBox1;
		internal System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		internal System.Windows.Forms.ListView listView2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.Label label5;
		internal System.Windows.Forms.TextBox textBox3;
		internal System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		internal System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.Label label9;
		internal System.Windows.Forms.RadioButton ra4;
		internal System.Windows.Forms.RadioButton ra3;
		internal System.Windows.Forms.RadioButton ra2;
		internal System.Windows.Forms.RadioButton ra1;
		private PinkieControls.ButtonXP btOK;
		private PinkieControls.ButtonXP btExit;
		private PinkieControls.ButtonXP btSaveB;
		private PinkieControls.ButtonXP btSaveA;
		private PinkieControls.ButtonXP btDelB;
		internal PinkieControls.ButtonXP btChangeB;
		private PinkieControls.ButtonXP btDelA;
        internal PinkieControls.ButtonXP btChangeA;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel7;
        private Panel panel6;
        private Panel panel8;
        private Panel panel10;
        private Panel panel9;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmReportMaintenance()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}
		public override void CreateController()
		{
			this.objController=new com.digitalwave.iCare.gui.HIS.clsCtl_ReportMaintenance();
			objController.Set_GUI_Apperance(this);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportMaintenance));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btSaveB = new PinkieControls.ButtonXP();
            this.btSaveA = new PinkieControls.ButtonXP();
            this.btExit = new PinkieControls.ButtonXP();
            this.btOK = new PinkieControls.ButtonXP();
            this.ra4 = new System.Windows.Forms.RadioButton();
            this.ra3 = new System.Windows.Forms.RadioButton();
            this.ra2 = new System.Windows.Forms.RadioButton();
            this.ra1 = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.listView3 = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.btDelB = new PinkieControls.ButtonXP();
            this.btChangeB = new PinkieControls.ButtonXP();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.btDelA = new PinkieControls.ButtonXP();
            this.btChangeA = new PinkieControls.ButtonXP();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(938, 615);
            this.panel1.TabIndex = 0;
            // 
            // btSaveB
            // 
            this.btSaveB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSaveB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btSaveB.DefaultScheme = true;
            this.btSaveB.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btSaveB.Hint = "";
            this.btSaveB.Location = new System.Drawing.Point(112, 76);
            this.btSaveB.Name = "btSaveB";
            this.btSaveB.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btSaveB.Size = new System.Drawing.Size(68, 32);
            this.btSaveB.TabIndex = 29;
            this.btSaveB.Text = "添加";
            this.btSaveB.Click += new System.EventHandler(this.btSaveB_Click);
            // 
            // btSaveA
            // 
            this.btSaveA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSaveA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btSaveA.DefaultScheme = true;
            this.btSaveA.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btSaveA.Hint = "";
            this.btSaveA.Location = new System.Drawing.Point(208, 76);
            this.btSaveA.Name = "btSaveA";
            this.btSaveA.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btSaveA.Size = new System.Drawing.Size(68, 32);
            this.btSaveA.TabIndex = 28;
            this.btSaveA.Text = "添加";
            this.btSaveA.Click += new System.EventHandler(this.btSaveA_Click);
            // 
            // btExit
            // 
            this.btExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btExit.DefaultScheme = true;
            this.btExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btExit.Hint = "";
            this.btExit.Location = new System.Drawing.Point(168, 15);
            this.btExit.Name = "btExit";
            this.btExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btExit.Size = new System.Drawing.Size(80, 32);
            this.btExit.TabIndex = 27;
            this.btExit.Text = "退出 Esc";
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btOK
            // 
            this.btOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btOK.DefaultScheme = true;
            this.btOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btOK.Hint = "";
            this.btOK.Location = new System.Drawing.Point(56, 15);
            this.btOK.Name = "btOK";
            this.btOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btOK.Size = new System.Drawing.Size(80, 32);
            this.btOK.TabIndex = 26;
            this.btOK.Text = "保存(&S)";
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // ra4
            // 
            this.ra4.Appearance = System.Windows.Forms.Appearance.Button;
            this.ra4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ra4.Font = new System.Drawing.Font("宋体", 9F);
            this.ra4.Location = new System.Drawing.Point(152, 55);
            this.ra4.Name = "ra4";
            this.ra4.Size = new System.Drawing.Size(144, 24);
            this.ra4.TabIndex = 25;
            this.ra4.Text = "住院发票";
            this.ra4.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // ra3
            // 
            this.ra3.Appearance = System.Windows.Forms.Appearance.Button;
            this.ra3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ra3.Font = new System.Drawing.Font("宋体", 9F);
            this.ra3.Location = new System.Drawing.Point(3, 55);
            this.ra3.Name = "ra3";
            this.ra3.Size = new System.Drawing.Size(152, 24);
            this.ra3.TabIndex = 24;
            this.ra3.Text = "住院核算";
            this.ra3.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // ra2
            // 
            this.ra2.Appearance = System.Windows.Forms.Appearance.Button;
            this.ra2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ra2.Font = new System.Drawing.Font("宋体", 9F);
            this.ra2.Location = new System.Drawing.Point(152, 28);
            this.ra2.Name = "ra2";
            this.ra2.Size = new System.Drawing.Size(144, 24);
            this.ra2.TabIndex = 23;
            this.ra2.Text = "门诊发票";
            this.ra2.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // ra1
            // 
            this.ra1.Appearance = System.Windows.Forms.Appearance.Button;
            this.ra1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ra1.Font = new System.Drawing.Font("宋体", 9F);
            this.ra1.Location = new System.Drawing.Point(3, 28);
            this.ra1.Name = "ra1";
            this.ra1.Size = new System.Drawing.Size(152, 24);
            this.ra1.TabIndex = 22;
            this.ra1.Text = "门诊核算";
            this.ra1.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(46, 4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(212, 24);
            this.label9.TabIndex = 21;
            this.label9.Text = "字段所属分类维护";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listView3
            // 
            this.listView3.BackColor = System.Drawing.Color.Honeydew;
            this.listView3.CheckBoxes = true;
            this.listView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5});
            this.listView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView3.FullRowSelect = true;
            this.listView3.GridLines = true;
            this.listView3.HideSelection = false;
            this.listView3.Location = new System.Drawing.Point(0, 84);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(298, 476);
            this.listView3.TabIndex = 19;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.Details;
            this.listView3.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listView3_ItemCheck);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "分类列表";
            this.columnHeader5.Width = 259;
            // 
            // btDelB
            // 
            this.btDelB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDelB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btDelB.DefaultScheme = true;
            this.btDelB.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btDelB.Hint = "";
            this.btDelB.Location = new System.Drawing.Point(192, 76);
            this.btDelB.Name = "btDelB";
            this.btDelB.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btDelB.Size = new System.Drawing.Size(68, 32);
            this.btDelB.TabIndex = 18;
            this.btDelB.Text = "删除";
            this.btDelB.Click += new System.EventHandler(this.btDelB_Click);
            // 
            // btChangeB
            // 
            this.btChangeB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btChangeB.DefaultScheme = true;
            this.btChangeB.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btChangeB.Hint = "";
            this.btChangeB.Location = new System.Drawing.Point(56, 76);
            this.btChangeB.Name = "btChangeB";
            this.btChangeB.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btChangeB.Size = new System.Drawing.Size(68, 32);
            this.btChangeB.TabIndex = 17;
            this.btChangeB.Text = "修改";
            this.btChangeB.Click += new System.EventHandler(this.btChangeB_Click);
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(56, 12);
            this.textBox3.MaxLength = 4;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(204, 23);
            this.textBox3.TabIndex = 14;
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Location = new System.Drawing.Point(56, 44);
            this.textBox4.MaxLength = 15;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(204, 23);
            this.textBox4.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 19);
            this.label6.TabIndex = 16;
            this.label6.Text = "名称:";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 19);
            this.label7.TabIndex = 15;
            this.label7.Text = "ID:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(5, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "报表字段维护";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listView2
            // 
            this.listView2.BackColor = System.Drawing.Color.White;
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(0, 28);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(272, 472);
            this.listView2.TabIndex = 10;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "字段ID";
            this.columnHeader3.Width = 63;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "字段名称";
            this.columnHeader4.Width = 244;
            // 
            // btDelA
            // 
            this.btDelA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDelA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btDelA.DefaultScheme = true;
            this.btDelA.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btDelA.Hint = "";
            this.btDelA.Location = new System.Drawing.Point(288, 76);
            this.btDelA.Name = "btDelA";
            this.btDelA.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btDelA.Size = new System.Drawing.Size(68, 32);
            this.btDelA.TabIndex = 9;
            this.btDelA.Text = "删除";
            this.btDelA.Click += new System.EventHandler(this.btDelA_Click);
            // 
            // btChangeA
            // 
            this.btChangeA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btChangeA.DefaultScheme = true;
            this.btChangeA.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btChangeA.Hint = "";
            this.btChangeA.Location = new System.Drawing.Point(68, 76);
            this.btChangeA.Name = "btChangeA";
            this.btChangeA.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btChangeA.Size = new System.Drawing.Size(68, 32);
            this.btChangeA.TabIndex = 8;
            this.btChangeA.Text = "修改";
            this.btChangeA.Click += new System.EventHandler(this.btChangeA_Click);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(68, 44);
            this.textBox2.MaxLength = 15;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(288, 23);
            this.textBox2.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(68, 12);
            this.textBox1.MaxLength = 4;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(288, 23);
            this.textBox1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "名称:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "ID:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "报表维护";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.White;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 28);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(368, 587);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "报表ID";
            this.columnHeader1.Width = 64;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "报表名称";
            this.columnHeader2.Width = 281;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listView3);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(640, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(298, 615);
            this.panel2.TabIndex = 30;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btOK);
            this.panel3.Controls.Add(this.btExit);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 560);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(298, 55);
            this.panel3.TabIndex = 28;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.ra4);
            this.panel4.Controls.Add(this.ra3);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.ra2);
            this.panel4.Controls.Add(this.ra1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(298, 84);
            this.panel4.TabIndex = 29;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.listView1);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(368, 615);
            this.panel5.TabIndex = 31;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(368, 28);
            this.panel6.TabIndex = 32;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label2);
            this.panel7.Controls.Add(this.textBox1);
            this.panel7.Controls.Add(this.label3);
            this.panel7.Controls.Add(this.btSaveA);
            this.panel7.Controls.Add(this.textBox2);
            this.panel7.Controls.Add(this.btChangeA);
            this.panel7.Controls.Add(this.btDelA);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 500);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(368, 115);
            this.panel7.TabIndex = 33;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.listView2);
            this.panel8.Controls.Add(this.panel10);
            this.panel8.Controls.Add(this.panel9);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(368, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(272, 615);
            this.panel8.TabIndex = 32;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.label5);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(272, 28);
            this.panel9.TabIndex = 0;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.label7);
            this.panel10.Controls.Add(this.textBox3);
            this.panel10.Controls.Add(this.label6);
            this.panel10.Controls.Add(this.btChangeB);
            this.panel10.Controls.Add(this.btSaveB);
            this.panel10.Controls.Add(this.textBox4);
            this.panel10.Controls.Add(this.btDelB);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel10.Location = new System.Drawing.Point(0, 500);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(272, 115);
            this.panel10.TabIndex = 11;
            // 
            // frmReportMaintenance
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(938, 615);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmReportMaintenance";
            this.Text = "报表字段维护";
            this.Resize += new System.EventHandler(this.frmReportMaintenance_Resize);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmReportMaintenance_KeyDown);
            this.Load += new System.EventHandler(this.frmReportMaintenance_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void RadioButton_CheckedChanged(object sender, System.EventArgs e)
		{
			RadioButton  radio = sender as RadioButton;
			radio.BackColor = SystemColors.Control;
			if(radio.Checked)
			{
				radio.BackColor =Color.Blue;				
				((clsCtl_ReportMaintenance)this.objController).m_mthRadioButtonChange();
				((clsCtl_ReportMaintenance)this.objController).m_mthGetCat();
			}
		}
		private void frmReportMaintenance_Load(object sender, System.EventArgs e)
		{
		((clsCtl_ReportMaintenance)this.objController).m_mthInit();
		}

		private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			((clsCtl_ReportMaintenance)this.objController).m_mthChange1();
		}

		private void btExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btChangeA_Click(object sender, System.EventArgs e)
		{
		((clsCtl_ReportMaintenance)this.objController).m_mthUpdateReportInfo();
		}

		private void btSaveA_Click(object sender, System.EventArgs e)
		{
		((clsCtl_ReportMaintenance)this.objController).m_mthAddNewReportInfo();
		}

		private void btDelA_Click(object sender, System.EventArgs e)
		{
			((clsCtl_ReportMaintenance)this.objController).m_mthDeleteReportByID();
		}

		private void btChangeB_Click(object sender, System.EventArgs e)
		{
			((clsCtl_ReportMaintenance)this.objController).m_mthUpdateReportInfo2();
		}

		private void btSaveB_Click(object sender, System.EventArgs e)
		{
		((clsCtl_ReportMaintenance)this.objController).m_mthAddNewReportInfo2();
		}

		private void btDelB_Click(object sender, System.EventArgs e)
		{
		((clsCtl_ReportMaintenance)this.objController).m_mthDeleteReportByID2();
		}

		private void btOK_Click(object sender, System.EventArgs e)
		{
		((clsCtl_ReportMaintenance)this.objController).m_mthSaveGroupDetail();
		}

		private void listView2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		((clsCtl_ReportMaintenance)this.objController).m_mthChange2();
		}

		private void frmReportMaintenance_Resize(object sender, System.EventArgs e)
		{
			this.panel1.Left=(this.Width-this.panel1.Width)/2;
			this.panel1.Top=(this.Height-this.panel1.Height)/2;
		}

		private void frmReportMaintenance_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Escape)
			{
				if(MessageBox.Show("确认退出吗?","iCare",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
					return;
				this.Close();
			}
		}

		private void listView3_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
		{
//			if(this.listView3.CheckedItems.Count==1&&e.NewValue == CheckState.Unchecked)
//			{
//				m_mthSetEnable(true);
//			}
//			else
//			{
//				m_mthSetEnable(false);
//			}
		}
		private void m_mthSetEnable(bool EnableFlag)
		{
			if(ra1.Checked)
			{
					ra2.Enabled =EnableFlag;
					ra3.Enabled =EnableFlag;
					ra4.Enabled =EnableFlag;
			}
			if(ra2.Checked)
			{
					ra1.Enabled =EnableFlag;
					ra3.Enabled =EnableFlag;
					ra4.Enabled =EnableFlag;
			}
			if(ra3.Checked)
			{
					ra2.Enabled =EnableFlag;
					ra1.Enabled =EnableFlag;
					ra4.Enabled =EnableFlag;
			}
			if(ra4.Checked)
			{
					ra2.Enabled =EnableFlag;
					ra3.Enabled =EnableFlag;
					ra1.Enabled =EnableFlag;
			}

		}
		

		
	}
}
