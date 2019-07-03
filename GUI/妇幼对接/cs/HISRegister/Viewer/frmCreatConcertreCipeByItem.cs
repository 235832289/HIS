using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmCreatConcertreCipeByItem 的摘要说明。
	/// </summary>
	public class frmCreatConcertreCipeByItem : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.GroupBox groupBox1;
		internal com.digitalwave.controls.exTextBox txtName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		internal com.digitalwave.controls.exTextBox txtCode;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox2;
		internal PinkieControls.ButtonXP btAddDepment;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		internal System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.Label label5;
		internal System.Windows.Forms.Label lbeSumMoney;
		internal System.Windows.Forms.TextBox txtWb;
		internal System.Windows.Forms.TextBox txtPy;
		internal System.Windows.Forms.RadioButton ra_public;
		internal System.Windows.Forms.RadioButton ra_private;
		internal System.Windows.Forms.RadioButton ra_dep;
		internal PinkieControls.ButtonXP btOK;
		private System.Windows.Forms.RadioButton ra_selectAll;
		private System.Windows.Forms.RadioButton ra_selectBack;
		internal PinkieControls.ButtonXP btExit;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.ColumnHeader columnHeader12;
		private System.Windows.Forms.ColumnHeader columnHeader13;
		private System.Windows.Forms.ColumnHeader columnHeader14;
		private System.Windows.Forms.Label label6;
		internal com.digitalwave.controls.exTextBox txtRemark;
        private ColumnHeader columnHeader15;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCreatConcertreCipeByItem()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			//生成数据表，这里的只存数据是调协定处方的保存，所以生成下列表，这个界面主要工作是填充数据
			this.CreatTableDepement();
			this.CreatTableDetail();
			this.CreatTableMain();
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
		public override void CreateController()
		{
			this.objController=new com.digitalwave.iCare.gui.HIS.clsCtl_CreatConcertreCipeByItem();
			objController.Set_GUI_Apperance(this);
		}
		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRemark = new com.digitalwave.controls.exTextBox();
            this.btAddDepment = new PinkieControls.ButtonXP();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ra_dep = new System.Windows.Forms.RadioButton();
            this.ra_private = new System.Windows.Forms.RadioButton();
            this.ra_public = new System.Windows.Forms.RadioButton();
            this.txtWb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPy = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCode = new com.digitalwave.controls.exTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new com.digitalwave.controls.exTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbeSumMoney = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btExit = new PinkieControls.ButtonXP();
            this.ra_selectBack = new System.Windows.Forms.RadioButton();
            this.ra_selectAll = new System.Windows.Forms.RadioButton();
            this.btOK = new PinkieControls.ButtonXP();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtRemark);
            this.groupBox1.Controls.Add(this.btAddDepment);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtWb);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPy);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Location = new System.Drawing.Point(4, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(796, 140);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 14);
            this.label6.TabIndex = 16;
            this.label6.Text = "备    注:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(96, 88);
            this.txtRemark.MaxLength = 500;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRemark.SendTabKey = false;
            this.txtRemark.SetFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtRemark.Size = new System.Drawing.Size(688, 44);
            this.txtRemark.TabIndex = 2;
            this.txtRemark.Enter += new System.EventHandler(this.txtRemark_Enter);
            this.txtRemark.Leave += new System.EventHandler(this.txtRemark_Leave);
            this.txtRemark.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRemark_KeyDown);
            // 
            // btAddDepment
            // 
            this.btAddDepment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btAddDepment.DefaultScheme = true;
            this.btAddDepment.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btAddDepment.Font = new System.Drawing.Font("宋体", 11F);
            this.btAddDepment.Hint = "";
            this.btAddDepment.Location = new System.Drawing.Point(664, 40);
            this.btAddDepment.Name = "btAddDepment";
            this.btAddDepment.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btAddDepment.Size = new System.Drawing.Size(92, 32);
            this.btAddDepment.TabIndex = 6;
            this.btAddDepment.Text = "添加科室(&A)";
            this.btAddDepment.Click += new System.EventHandler(this.btAddDepment_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ra_dep);
            this.groupBox2.Controls.Add(this.ra_private);
            this.groupBox2.Controls.Add(this.ra_public);
            this.groupBox2.Location = new System.Drawing.Point(444, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(204, 68);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "使用范围";
            // 
            // ra_dep
            // 
            this.ra_dep.Location = new System.Drawing.Point(79, 28);
            this.ra_dep.Name = "ra_dep";
            this.ra_dep.Size = new System.Drawing.Size(52, 24);
            this.ra_dep.TabIndex = 1;
            this.ra_dep.Text = "科室";
            this.ra_dep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ra_public_KeyDown);
            // 
            // ra_private
            // 
            this.ra_private.Checked = true;
            this.ra_private.Location = new System.Drawing.Point(15, 28);
            this.ra_private.Name = "ra_private";
            this.ra_private.Size = new System.Drawing.Size(52, 24);
            this.ra_private.TabIndex = 0;
            this.ra_private.TabStop = true;
            this.ra_private.Text = "私有";
            this.ra_private.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ra_public_KeyDown);
            // 
            // ra_public
            // 
            this.ra_public.Location = new System.Drawing.Point(143, 28);
            this.ra_public.Name = "ra_public";
            this.ra_public.Size = new System.Drawing.Size(52, 24);
            this.ra_public.TabIndex = 2;
            this.ra_public.Text = "公用";
            this.ra_public.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ra_public_KeyDown);
            // 
            // txtWb
            // 
            this.txtWb.Location = new System.Drawing.Point(348, 56);
            this.txtWb.Name = "txtWb";
            this.txtWb.ReadOnly = true;
            this.txtWb.Size = new System.Drawing.Size(80, 23);
            this.txtWb.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(284, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 14);
            this.label4.TabIndex = 14;
            this.label4.Text = "五笔码:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPy
            // 
            this.txtPy.Location = new System.Drawing.Point(96, 56);
            this.txtPy.Name = "txtPy";
            this.txtPy.ReadOnly = true;
            this.txtPy.Size = new System.Drawing.Size(184, 23);
            this.txtPy.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 12;
            this.label3.Text = "拼 音 码:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCode
            // 
            this.txtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCode.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtCode.Location = new System.Drawing.Point(348, 24);
            this.txtCode.MaxLength = 10;
            this.txtCode.Name = "txtCode";
            this.txtCode.SendTabKey = false;
            this.txtCode.SetFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtCode.Size = new System.Drawing.Size(80, 23);
            this.txtCode.TabIndex = 1;
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(284, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 14);
            this.label2.TabIndex = 11;
            this.label2.Text = "助记码:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "处方名称:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(96, 24);
            this.txtName.MaxLength = 30;
            this.txtName.Name = "txtName";
            this.txtName.SendTabKey = false;
            this.txtName.SetFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtName.Size = new System.Drawing.Size(184, 23);
            this.txtName.TabIndex = 0;
            this.txtName.Leave += new System.EventHandler(this.txtName_Leave);
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lbeSumMoney);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btExit);
            this.panel1.Controls.Add(this.ra_selectBack);
            this.panel1.Controls.Add(this.ra_selectAll);
            this.panel1.Controls.Add(this.btOK);
            this.panel1.Location = new System.Drawing.Point(4, 144);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(796, 44);
            this.panel1.TabIndex = 1;
            // 
            // lbeSumMoney
            // 
            this.lbeSumMoney.AutoSize = true;
            this.lbeSumMoney.Location = new System.Drawing.Point(300, 11);
            this.lbeSumMoney.Name = "lbeSumMoney";
            this.lbeSumMoney.Size = new System.Drawing.Size(0, 14);
            this.lbeSumMoney.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(232, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 14);
            this.label5.TabIndex = 4;
            this.label5.Text = "总  价:";
            // 
            // btExit
            // 
            this.btExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btExit.DefaultScheme = true;
            this.btExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btExit.Font = new System.Drawing.Font("宋体", 11F);
            this.btExit.Hint = "";
            this.btExit.Location = new System.Drawing.Point(660, 4);
            this.btExit.Name = "btExit";
            this.btExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btExit.Size = new System.Drawing.Size(92, 32);
            this.btExit.TabIndex = 3;
            this.btExit.Text = "退出(ESC)";
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // ra_selectBack
            // 
            this.ra_selectBack.Location = new System.Drawing.Point(136, 8);
            this.ra_selectBack.Name = "ra_selectBack";
            this.ra_selectBack.Size = new System.Drawing.Size(80, 24);
            this.ra_selectBack.TabIndex = 1;
            this.ra_selectBack.Text = "反选";
            this.ra_selectBack.Click += new System.EventHandler(this.ra_selectBack_Click);
            // 
            // ra_selectAll
            // 
            this.ra_selectAll.Checked = true;
            this.ra_selectAll.Location = new System.Drawing.Point(24, 10);
            this.ra_selectAll.Name = "ra_selectAll";
            this.ra_selectAll.Size = new System.Drawing.Size(76, 20);
            this.ra_selectAll.TabIndex = 0;
            this.ra_selectAll.TabStop = true;
            this.ra_selectAll.Text = "全选";
            this.ra_selectAll.Click += new System.EventHandler(this.ra_selectAll_Click);
            // 
            // btOK
            // 
            this.btOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btOK.DefaultScheme = true;
            this.btOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btOK.Font = new System.Drawing.Font("宋体", 11F);
            this.btOK.Hint = "";
            this.btOK.Location = new System.Drawing.Point(472, 4);
            this.btOK.Name = "btOK";
            this.btOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btOK.Size = new System.Drawing.Size(92, 32);
            this.btOK.TabIndex = 2;
            this.btOK.Text = "确定(&B)";
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.listView1);
            this.panel2.Location = new System.Drawing.Point(4, 192);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(796, 336);
            this.panel2.TabIndex = 2;
            // 
            // listView1
            // 
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader14,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader15});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(792, 332);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "方号";
            this.columnHeader14.Width = 41;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "编号";
            this.columnHeader1.Width = 72;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "项目名称";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "规格";
            this.columnHeader3.Width = 116;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "类型";
            this.columnHeader4.Width = 42;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "单价";
            this.columnHeader5.Width = 42;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "剂量";
            this.columnHeader6.Width = 40;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "单位";
            this.columnHeader7.Width = 40;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "数量";
            this.columnHeader8.Width = 40;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "单位";
            this.columnHeader9.Width = 42;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "用法";
            this.columnHeader10.Width = 56;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "频率";
            this.columnHeader11.Width = 51;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "天数";
            this.columnHeader12.Width = 41;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "总额";
            this.columnHeader13.Width = 48;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "排序号";
            this.columnHeader15.Width = 0;
            // 
            // frmCreatConcertreCipeByItem
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.CancelButton = this.btExit;
            this.ClientSize = new System.Drawing.Size(804, 529);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmCreatConcertreCipeByItem";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "生成模板";
            this.Load += new System.EventHandler(this.frmCreatConcertreCipeByItem_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		#region 初始化数据表
		private void CreatTableDepement()
		{
			dtDepement =new DataTable();
			dtDepement.Columns.Add("RECIPEID_CHR");
			dtDepement.Columns.Add("DEPTID_CHR");
			dtDepement.Columns.Add("DEPTNAME_VCHR");
		
		}
		private void CreatTableMain()
		{
			dtMain =new DataTable();
			dtMain.Columns.Add("RECIPEID_CHR");
			dtMain.Columns.Add("RECIPENAME_CHR");
			dtMain.Columns.Add("PRIVILEGE_INT");
			dtMain.Columns.Add("USERCODE_CHR");
			dtMain.Columns.Add("WBCODE_CHR");
			dtMain.Columns.Add("PYCODE_CHR");
			dtMain.Columns.Add("STATUS_INT");
			dtMain.Columns.Add("CREATERID_CHR");
			dtMain.Columns.Add("strPRIVILEGE");
			dtMain.Columns.Add("DISEASENAME_VCHR");
				
		}
		#endregion

		#region 初始化数据表(明细表）
		internal DataTable dtDetail;
		internal DataTable dtMain;
		internal DataTable dtDepement;
		private void CreatTableDetail()
		{
			dtDetail =new DataTable();
			dtDetail.Columns.Add("RECIPEID_CHR");
			dtDetail.Columns.Add("DETAILID_CHR");
			dtDetail.Columns.Add("ITEMID_CHR");
			dtDetail.Columns.Add("QTY_DEC");
			dtDetail.Columns.Add("DOSETYPE_CHR");
			dtDetail.Columns.Add("FREQID_CHR");
			dtDetail.Columns.Add("ItemType");
			dtDetail.Columns.Add("ITEMSPEC_VCHR");
			dtDetail.Columns.Add("ITEMOPUNIT_CHR");
			dtDetail.Columns.Add("ITEMPRICE_MNY");
			dtDetail.Columns.Add("usagename_vchr");
			dtDetail.Columns.Add("freqname_chr");
			dtDetail.Columns.Add("ITEMNAME_VCHR");
			dtDetail.Columns.Add("tolMeny");
			dtDetail.Columns.Add("DOSAGEQTY_DEC");//剂量
			dtDetail.Columns.Add("DosageUnit");//剂量单
			dtDetail.Columns.Add("DAYS_INT");
			dtDetail.Columns.Add("Code");//编号
			dtDetail.Columns.Add("ROWNO_CHR");//方号
			dtDetail.Columns.Add("FLAG_INT");//标释
			dtDetail.Columns.Add("PARTORTYPE_VCHR");//部位ID
			dtDetail.Columns.Add("PARTORTYPENAME_VCHR");//部位名称
            dtDetail.Columns.Add("Sort_int");
		}
		#endregion
		#region 获取数据行或设置数据
		public DataRow RowData
		{
			get
			{
			return this.dtDetail.NewRow();
			}
			set
			{
			m_mthFillListView(value);
			}
		}
		private void m_mthFillListView(DataRow dr)
		{
				ListViewItem lv=new ListViewItem(dr["ROWNO_CHR"].ToString().Trim());
				lv.SubItems.Add(dr["Code"].ToString().Trim());
				lv.SubItems.Add(dr["ITEMNAME_VCHR"].ToString().Trim());
				lv.SubItems.Add(dr["ITEMSPEC_VCHR"].ToString().Trim());
				lv.SubItems.Add(dr["ItemType"].ToString().Trim());
				lv.SubItems.Add(dr["ITEMPRICE_MNY"].ToString().Trim());
				lv.SubItems.Add(dr["DOSAGEQTY_DEC"].ToString().Trim());
				lv.SubItems.Add(dr["DosageUnit"].ToString().Trim());
				lv.SubItems.Add(dr["QTY_DEC"].ToString().Trim());
			    lv.SubItems.Add(dr["ITEMOPUNIT_CHR"].ToString().Trim());
				lv.SubItems.Add(dr["usagename_vchr"].ToString().Trim());
				lv.SubItems.Add(dr["freqname_chr"].ToString().Trim());
				lv.SubItems.Add(dr["DAYS_INT"].ToString().Trim());
				lv.SubItems.Add(dr["tolMeny"].ToString().Trim());
				lv.Checked =true;
			    lv.Tag =dr;
				this.listView1.Items.Add(lv);
		
		}
		#endregion

		private void txtName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				
				this.txtCode.Focus();
			}
		}

		private void txtCode_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
			this.txtRemark.Focus();
			}
		}

		private void ra_public_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				if(ra_dep.Checked)//如果选择了科室回车就跟到科室控钮，否则就跟到保存按钮
				{
					this.btAddDepment.Focus();

				}
				else
				{
				this.btOK.Focus();
				}
			}
		}

		private void btExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btOK_Click(object sender, System.EventArgs e)
		{
//			if(txtName.Text.Trim()=="")
//			{
//				MessageBox.Show("必需输入名称");
//				txtName.Focus();
//				return;
//			}
//			if(txtCode.Text.Trim()=="")
//			{
//				MessageBox.Show("必需助记码");
//				txtCode.Focus();
//				return;
//			}
			try
			{
				((clsCtl_CreatConcertreCipeByItem)this.objController).m_mthSaveData();
			}
			catch
			{
				MessageBox.Show("输入的处方不完整，请重新输入!","Icare");
			}
//			if(((clsCtl_CreatConcertreCipeByItem)this.objController).m_mthSaveData()>0)
//			{
//				this.Close();
//			}
//			else
//			{
//			MessageBox.Show("保存失败!");
//			}
		}

		private void ra_selectAll_Click(object sender, System.EventArgs e)
		{
			((clsCtl_CreatConcertreCipeByItem)this.objController).m_mthSelectAll();
		}

		private void ra_selectBack_Click(object sender, System.EventArgs e)
		{
			((clsCtl_CreatConcertreCipeByItem)this.objController).m_mthSelectBack();
		}

		

		private void btAddDepment_Click(object sender, System.EventArgs e)
		{
			frmAddDepment objtmep  =new frmAddDepment();
			objtmep.DeparmentData  =this.dtDepement;
			objtmep.ShowDialog();
			this.dtDepement =objtmep.DeparmentData;
			objtmep.Close();
			this.btOK.Focus();

		}

		private void frmCreatConcertreCipeByItem_Load(object sender, System.EventArgs e)
		{
			bool m_blnCreat = false;
			((clsCtl_CreatConcertreCipeByItem)this.objController).m_mthCalMoney();
			clsDomainConrol_ConcertreCipe doMain = new clsDomainConrol_ConcertreCipe();
			doMain.m_lngGetPublic(this.LoginInfo.m_strEmpID,out m_blnCreat);
			if(!m_blnCreat)
			{
				ra_dep.Enabled = false;
				ra_public.Enabled = false;
			}

			Application.Idle +=new EventHandler(Application_Idle);
		}

		private void Application_Idle(object sender, EventArgs e)
		{
			if(this.ra_dep.Checked)
			{
				this.btAddDepment.Enabled =true;
			}
			else
			{
				this.btAddDepment.Enabled =false;
			}
			if(this.listView1.CheckedItems.Count==0)
			{
				this.btOK.Enabled=false;
			}
			else
			{
				this.btOK.Enabled =true;
			}
			((clsCtl_CreatConcertreCipeByItem)this.objController).m_mthCalMoney();
		}

		private void txtName_Leave(object sender, System.EventArgs e)
		{
            com.digitalwave.Utility.clsCreateChinaCode Ccode = new com.digitalwave.Utility.clsCreateChinaCode();
			this.txtWb.Text = Ccode.m_strCreateChinaCode(txtName.Text.Trim(),ChinaCode.WB);
			this.txtPy.Text = Ccode.m_strCreateChinaCode(txtName.Text.Trim(),ChinaCode.PY);
		}

		private void txtRemark_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.Control)
			{
				if(e.KeyCode==Keys.Enter)
				{
					this.ra_public.Focus();
				}
			}
		}

		private void txtRemark_Enter(object sender, System.EventArgs e)
		{
			this.Text +="   Ctrl+Enter 跳转光标";
		}

		private void txtRemark_Leave(object sender, System.EventArgs e)
		{
			this.Text ="生成模板";
		}

		
	}
}
