using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DigitalWave;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.GLS_WS.UI
{
	/// <summary>
	/// frmDictManage 的摘要说明。
	/// </summary>
	public class frmDictManage : BaseForm
	{
		#region Control Declaration
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.GroupBox groupBox3;
        private IContainer components;
		private System.Windows.Forms.ListView lvType;
		private System.Windows.Forms.ColumnHeader id;
		private System.Windows.Forms.ColumnHeader TypeName;
		private PinkieControls.ButtonXP btnExit;
		private PinkieControls.ButtonXP btnSave;
		private PinkieControls.ButtonXP btnAddType;
		private PinkieControls.ButtonXP btnDelType;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle3;
		private System.Windows.Forms.ContextMenu cmCheckType;
		private System.Windows.Forms.ContextMenu cmPart;
		private System.Windows.Forms.ContextMenu cmAim;
		private System.Windows.Forms.MenuItem miNewType;
		private System.Windows.Forms.MenuItem miDelType;
		private System.Windows.Forms.MenuItem miDelPart;
		private System.Windows.Forms.MenuItem miDelAim;

		#endregion

        private System.Windows.Forms.ListView m_lsvAimList;
		private System.Windows.Forms.ColumnHeader AimText;
		private System.Windows.Forms.ColumnHeader AimID;
		private System.Windows.Forms.ColumnHeader TypeID;
		private System.Windows.Forms.ColumnHeader PartName;
		private System.Windows.Forms.ColumnHeader AssistCode_chr;
		private System.Windows.Forms.ColumnHeader PartID;
		private System.Windows.Forms.ColumnHeader TypeID_;
		private System.Windows.Forms.TextBox m_txtPart;
		private System.Windows.Forms.TextBox m_txtAssCode;
		private System.Windows.Forms.TextBox m_txtAim;
		private PinkieControls.ButtonXP m_cmdAddPart;
		private PinkieControls.ButtonXP m_cmdDelPart;
		private PinkieControls.ButtonXP m_cmdModifyPart;
		private PinkieControls.ButtonXP m_cmdAddAim;
		private PinkieControls.ButtonXP m_cmdDelAim;
		private PinkieControls.ButtonXP m_cmdModifyAim;
        private ColumnHeader PinYinCode;
        private ColumnHeader WuBiCode;
        private TextBox m_txtWuBiCode;
        private TextBox m_txtPinYinCode;
        private ToolTip toolTip1;
        private ListView m_lsvPartList;
        private Label label1;

		
		private Logic.DictEditor Editor = null;

		public frmDictManage()
		{
			InitializeComponent();
			Editor = new com.digitalwave.GLS_WS.Logic.DictEditor(this);
		}        


		#region Windows 窗体设计器生成的代码

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


		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.btnAddType = new PinkieControls.ButtonXP();
            this.btnDelType = new PinkieControls.ButtonXP();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvType = new System.Windows.Forms.ListView();
            this.TypeName = new System.Windows.Forms.ColumnHeader();
            this.id = new System.Windows.Forms.ColumnHeader();
            this.cmCheckType = new System.Windows.Forms.ContextMenu();
            this.miNewType = new System.Windows.Forms.MenuItem();
            this.miDelType = new System.Windows.Forms.MenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_lsvAimList = new System.Windows.Forms.ListView();
            this.AimText = new System.Windows.Forms.ColumnHeader();
            this.AimID = new System.Windows.Forms.ColumnHeader();
            this.TypeID = new System.Windows.Forms.ColumnHeader();
            this.m_txtAim = new System.Windows.Forms.TextBox();
            this.m_cmdAddAim = new PinkieControls.ButtonXP();
            this.m_cmdDelAim = new PinkieControls.ButtonXP();
            this.m_cmdModifyAim = new PinkieControls.ButtonXP();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_cmdAddPart = new PinkieControls.ButtonXP();
            this.m_txtPart = new System.Windows.Forms.TextBox();
            this.m_lsvPartList = new System.Windows.Forms.ListView();
            this.PartName = new System.Windows.Forms.ColumnHeader();
            this.AssistCode_chr = new System.Windows.Forms.ColumnHeader();
            this.PartID = new System.Windows.Forms.ColumnHeader();
            this.TypeID_ = new System.Windows.Forms.ColumnHeader();
            this.m_txtAssCode = new System.Windows.Forms.TextBox();
            this.m_cmdDelPart = new PinkieControls.ButtonXP();
            this.m_cmdModifyPart = new PinkieControls.ButtonXP();
            this.cmAim = new System.Windows.Forms.ContextMenu();
            this.miDelAim = new System.Windows.Forms.MenuItem();
            this.cmPart = new System.Windows.Forms.ContextMenu();
            this.miDelPart = new System.Windows.Forms.MenuItem();
            this.btnExit = new PinkieControls.ButtonXP();
            this.btnSave = new PinkieControls.ButtonXP();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTableStyle3 = new System.Windows.Forms.DataGridTableStyle();
            this.PinYinCode = new System.Windows.Forms.ColumnHeader();
            this.WuBiCode = new System.Windows.Forms.ColumnHeader();
            this.m_txtPinYinCode = new System.Windows.Forms.TextBox();
            this.m_txtWuBiCode = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddType
            // 
            this.btnAddType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnAddType.DefaultScheme = true;
            this.btnAddType.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAddType.Hint = "";
            this.btnAddType.Location = new System.Drawing.Point(16, 461);
            this.btnAddType.Name = "btnAddType";
            this.btnAddType.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnAddType.Size = new System.Drawing.Size(80, 32);
            this.btnAddType.TabIndex = 0;
            this.btnAddType.Text = "新增(&A)";
            // 
            // btnDelType
            // 
            this.btnDelType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnDelType.DefaultScheme = true;
            this.btnDelType.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDelType.Hint = "";
            this.btnDelType.Location = new System.Drawing.Point(112, 461);
            this.btnDelType.Name = "btnDelType";
            this.btnDelType.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnDelType.Size = new System.Drawing.Size(80, 32);
            this.btnDelType.TabIndex = 0;
            this.btnDelType.Text = "删除(&D)";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.lvType);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(204, 440);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "检查类型";
            // 
            // lvType
            // 
            this.lvType.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TypeName,
            this.id});
            this.lvType.ContextMenu = this.cmCheckType;
            this.lvType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvType.FullRowSelect = true;
            this.lvType.GridLines = true;
            this.lvType.Location = new System.Drawing.Point(3, 19);
            this.lvType.MultiSelect = false;
            this.lvType.Name = "lvType";
            this.lvType.Size = new System.Drawing.Size(198, 418);
            this.lvType.TabIndex = 0;
            this.lvType.UseCompatibleStateImageBehavior = false;
            this.lvType.View = System.Windows.Forms.View.Details;
            // 
            // TypeName
            // 
            this.TypeName.Text = "检查类型";
            this.TypeName.Width = 195;
            // 
            // id
            // 
            this.id.Text = "ID";
            this.id.Width = 0;
            // 
            // cmCheckType
            // 
            this.cmCheckType.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miNewType,
            this.miDelType});
            // 
            // miNewType
            // 
            this.miNewType.Index = 0;
            this.miNewType.Text = "新增";
            // 
            // miDelType
            // 
            this.miDelType.Index = 1;
            this.miDelType.Text = "删除";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.splitter2);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Location = new System.Drawing.Point(216, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(772, 440);
            this.panel1.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.m_lsvAimList);
            this.groupBox3.Controls.Add(this.m_txtAim);
            this.groupBox3.Controls.Add(this.m_cmdAddAim);
            this.groupBox3.Controls.Add(this.m_cmdDelAim);
            this.groupBox3.Controls.Add(this.m_cmdModifyAim);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 213);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(772, 227);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "检查目的或其它要求";
            // 
            // m_lsvAimList
            // 
            this.m_lsvAimList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lsvAimList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AimText,
            this.AimID,
            this.TypeID});
            this.m_lsvAimList.FullRowSelect = true;
            this.m_lsvAimList.GridLines = true;
            this.m_lsvAimList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.m_lsvAimList.Location = new System.Drawing.Point(8, 24);
            this.m_lsvAimList.MultiSelect = false;
            this.m_lsvAimList.Name = "m_lsvAimList";
            this.m_lsvAimList.Size = new System.Drawing.Size(758, 152);
            this.m_lsvAimList.TabIndex = 0;
            this.m_lsvAimList.UseCompatibleStateImageBehavior = false;
            this.m_lsvAimList.View = System.Windows.Forms.View.Details;
            this.m_lsvAimList.SelectedIndexChanged += new System.EventHandler(this.m_lsvAimList_SelectedIndexChanged);
            // 
            // AimText
            // 
            this.AimText.Text = "目的或要求";
            this.AimText.Width = 760;
            // 
            // AimID
            // 
            this.AimID.Text = "AimID";
            this.AimID.Width = 0;
            // 
            // TypeID
            // 
            this.TypeID.Text = "TypeID";
            this.TypeID.Width = 0;
            // 
            // m_txtAim
            // 
            this.m_txtAim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_txtAim.Location = new System.Drawing.Point(91, 191);
            this.m_txtAim.Name = "m_txtAim";
            this.m_txtAim.Size = new System.Drawing.Size(384, 23);
            this.m_txtAim.TabIndex = 1;
            this.toolTip1.SetToolTip(this.m_txtAim, "目的或要数");
            // 
            // m_cmdAddAim
            // 
            this.m_cmdAddAim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdAddAim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdAddAim.DefaultScheme = true;
            this.m_cmdAddAim.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAddAim.Hint = "";
            this.m_cmdAddAim.Location = new System.Drawing.Point(508, 186);
            this.m_cmdAddAim.Name = "m_cmdAddAim";
            this.m_cmdAddAim.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAddAim.Size = new System.Drawing.Size(80, 32);
            this.m_cmdAddAim.TabIndex = 2;
            this.m_cmdAddAim.Text = "添加";
            this.m_cmdAddAim.Click += new System.EventHandler(this.m_cmdAddAim_Click);
            // 
            // m_cmdDelAim
            // 
            this.m_cmdDelAim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdDelAim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdDelAim.DefaultScheme = true;
            this.m_cmdDelAim.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdDelAim.Hint = "";
            this.m_cmdDelAim.Location = new System.Drawing.Point(680, 186);
            this.m_cmdDelAim.Name = "m_cmdDelAim";
            this.m_cmdDelAim.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDelAim.Size = new System.Drawing.Size(80, 32);
            this.m_cmdDelAim.TabIndex = 2;
            this.m_cmdDelAim.Text = "删除";
            this.m_cmdDelAim.Click += new System.EventHandler(this.m_cmdDelAim_Click);
            // 
            // m_cmdModifyAim
            // 
            this.m_cmdModifyAim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdModifyAim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdModifyAim.DefaultScheme = true;
            this.m_cmdModifyAim.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdModifyAim.Hint = "";
            this.m_cmdModifyAim.Location = new System.Drawing.Point(594, 186);
            this.m_cmdModifyAim.Name = "m_cmdModifyAim";
            this.m_cmdModifyAim.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdModifyAim.Size = new System.Drawing.Size(80, 32);
            this.m_cmdModifyAim.TabIndex = 2;
            this.m_cmdModifyAim.Text = "修改";
            this.m_cmdModifyAim.Click += new System.EventHandler(this.m_cmdModifyAim_Click);
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 208);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(772, 5);
            this.splitter2.TabIndex = 1;
            this.splitter2.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_txtWuBiCode);
            this.groupBox2.Controls.Add(this.m_txtPinYinCode);
            this.groupBox2.Controls.Add(this.m_cmdAddPart);
            this.groupBox2.Controls.Add(this.m_txtPart);
            this.groupBox2.Controls.Add(this.m_lsvPartList);
            this.groupBox2.Controls.Add(this.m_txtAssCode);
            this.groupBox2.Controls.Add(this.m_cmdDelPart);
            this.groupBox2.Controls.Add(this.m_cmdModifyPart);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(772, 208);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "检查部位或送检组织";
            // 
            // m_cmdAddPart
            // 
            this.m_cmdAddPart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdAddPart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdAddPart.DefaultScheme = true;
            this.m_cmdAddPart.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAddPart.Hint = "";
            this.m_cmdAddPart.Location = new System.Drawing.Point(676, 39);
            this.m_cmdAddPart.Name = "m_cmdAddPart";
            this.m_cmdAddPart.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAddPart.Size = new System.Drawing.Size(80, 32);
            this.m_cmdAddPart.TabIndex = 5;
            this.m_cmdAddPart.Text = "添加";
            this.m_cmdAddPart.Click += new System.EventHandler(this.m_cmdAddPart_Click);
            // 
            // m_txtPart
            // 
            this.m_txtPart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_txtPart.Location = new System.Drawing.Point(8, 176);
            this.m_txtPart.Name = "m_txtPart";
            this.m_txtPart.Size = new System.Drawing.Size(264, 23);
            this.m_txtPart.TabIndex = 1;
            this.toolTip1.SetToolTip(this.m_txtPart, "部位或组织");
            this.m_txtPart.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtPart_KeyDown);
            // 
            // m_lsvPartList
            // 
            this.m_lsvPartList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lsvPartList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PartName,
            this.AssistCode_chr,
            this.PartID,
            this.TypeID_,
            this.PinYinCode,
            this.WuBiCode});
            this.m_lsvPartList.FullRowSelect = true;
            this.m_lsvPartList.GridLines = true;
            this.m_lsvPartList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.m_lsvPartList.Location = new System.Drawing.Point(8, 24);
            this.m_lsvPartList.MultiSelect = false;
            this.m_lsvPartList.Name = "m_lsvPartList";
            this.m_lsvPartList.Size = new System.Drawing.Size(660, 144);
            this.m_lsvPartList.TabIndex = 0;
            this.m_lsvPartList.UseCompatibleStateImageBehavior = false;
            this.m_lsvPartList.View = System.Windows.Forms.View.Details;
            this.m_lsvPartList.SelectedIndexChanged += new System.EventHandler(this.m_lsvPartList_SelectedIndexChanged);
            // 
            // PartName
            // 
            this.PartName.Text = "部位或组织";
            this.PartName.Width = 360;
            // 
            // AssistCode_chr
            // 
            this.AssistCode_chr.Text = "助记码";
            this.AssistCode_chr.Width = 100;
            // 
            // PartID
            // 
            this.PartID.Width = 0;
            // 
            // TypeID_
            // 
            this.TypeID_.Width = 0;
            // 
            // m_txtAssCode
            // 
            this.m_txtAssCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_txtAssCode.Location = new System.Drawing.Point(280, 176);
            this.m_txtAssCode.Name = "m_txtAssCode";
            this.m_txtAssCode.Size = new System.Drawing.Size(112, 23);
            this.m_txtAssCode.TabIndex = 2;
            this.toolTip1.SetToolTip(this.m_txtAssCode, "助记码");
            // 
            // m_cmdDelPart
            // 
            this.m_cmdDelPart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdDelPart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdDelPart.DefaultScheme = true;
            this.m_cmdDelPart.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdDelPart.Hint = "";
            this.m_cmdDelPart.Location = new System.Drawing.Point(676, 79);
            this.m_cmdDelPart.Name = "m_cmdDelPart";
            this.m_cmdDelPart.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDelPart.Size = new System.Drawing.Size(80, 32);
            this.m_cmdDelPart.TabIndex = 6;
            this.m_cmdDelPart.Text = "删除";
            this.m_cmdDelPart.Click += new System.EventHandler(this.m_cmdDelPart_Click);
            // 
            // m_cmdModifyPart
            // 
            this.m_cmdModifyPart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdModifyPart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdModifyPart.DefaultScheme = true;
            this.m_cmdModifyPart.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdModifyPart.Hint = "";
            this.m_cmdModifyPart.Location = new System.Drawing.Point(676, 119);
            this.m_cmdModifyPart.Name = "m_cmdModifyPart";
            this.m_cmdModifyPart.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdModifyPart.Size = new System.Drawing.Size(80, 32);
            this.m_cmdModifyPart.TabIndex = 7;
            this.m_cmdModifyPart.Text = "修改";
            this.m_cmdModifyPart.Click += new System.EventHandler(this.m_cmdModifyPart_Click);
            // 
            // cmAim
            // 
            this.cmAim.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miDelAim});
            // 
            // miDelAim
            // 
            this.miDelAim.Index = 0;
            this.miDelAim.Text = "删除行(&Delete)";
            // 
            // cmPart
            // 
            this.cmPart.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miDelPart});
            // 
            // miDelPart
            // 
            this.miDelPart.Index = 0;
            this.miDelPart.Text = "删除行(Delete)";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnExit.DefaultScheme = true;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Hint = "";
            this.btnExit.Location = new System.Drawing.Point(892, 461);
            this.btnExit.Name = "btnExit";
            this.btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnExit.Size = new System.Drawing.Size(80, 32);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "退出(&ESC)";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnSave.DefaultScheme = true;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSave.Hint = "";
            this.btnSave.Location = new System.Drawing.Point(812, 461);
            this.btnSave.Name = "btnSave";
            this.btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnSave.Size = new System.Drawing.Size(80, 32);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.Visible = false;
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = null;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = null;
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTableStyle3
            // 
            this.dataGridTableStyle3.DataGrid = null;
            this.dataGridTableStyle3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // PinYinCode
            // 
            this.PinYinCode.Text = "拼音码";
            this.PinYinCode.Width = 100;
            // 
            // WuBiCode
            // 
            this.WuBiCode.Text = "五笔码";
            this.WuBiCode.Width = 100;
            // 
            // m_txtPinYinCode
            // 
            this.m_txtPinYinCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_txtPinYinCode.Location = new System.Drawing.Point(398, 176);
            this.m_txtPinYinCode.Name = "m_txtPinYinCode";
            this.m_txtPinYinCode.Size = new System.Drawing.Size(112, 23);
            this.m_txtPinYinCode.TabIndex = 3;
            this.toolTip1.SetToolTip(this.m_txtPinYinCode, "拼音码");
            // 
            // m_txtWuBiCode
            // 
            this.m_txtWuBiCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_txtWuBiCode.Location = new System.Drawing.Point(517, 176);
            this.m_txtWuBiCode.Name = "m_txtWuBiCode";
            this.m_txtWuBiCode.Size = new System.Drawing.Size(112, 23);
            this.m_txtWuBiCode.TabIndex = 4;
            this.toolTip1.SetToolTip(this.m_txtWuBiCode, "五笔码");
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "目的或要求：";
            // 
            // frmDictManage
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(996, 501);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDelType);
            this.Controls.Add(this.btnAddType);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmDictManage";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "检查申请单字典维护";
            this.Load += new System.EventHandler(this.frmDictManage_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == Keys.Escape)
			{
				this.Close();	
				return true;
			}
			else
				return base.ProcessCmdKey (ref msg, keyData);
		}

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void m_lsvPartList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_lsvPartList.SelectedItems.Count > 0)
			{
				ListViewItem item = m_lsvPartList.SelectedItems[0];
				m_txtPart.Text = item.Text;
				m_txtAssCode.Text = item.SubItems[1].Text;
				m_txtPart.Tag = item.SubItems[2].Text;
                this.m_txtPinYinCode.Text = item.SubItems[4].Text;
                this.m_txtWuBiCode.Text = item.SubItems[5].Text;
			}
		}

		private void m_lsvAimList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_lsvAimList.SelectedItems.Count > 0)
			{
				ListViewItem item = m_lsvAimList.SelectedItems[0];
				m_txtAim.Text = item.Text;
				m_txtAim.Tag = item.SubItems[1].Text;
			}
		}

		private void m_cmdAddPart_Click(object sender, System.EventArgs e)
		{
			if (lvType.SelectedItems.Count <1)
			{
				return;
			}
			if(m_txtPart.Text.Trim() == "")
				return;
			string id  = lvType.SelectedItems[0].SubItems[1].Text;
			Editor.m_mthAddPartList(m_txtPart.Text,m_txtAssCode.Text,id,this.m_txtPinYinCode.Text,this.m_txtWuBiCode.Text);
			m_txtPart.Text = "";
			m_txtPart.Tag = null;
			m_txtAssCode.Text = "";
            this.m_txtWuBiCode.Text = "";
            this.m_txtPinYinCode.Text = "";
			Editor.m_mthGetPartList();
		}

		private void m_cmdDelPart_Click(object sender, System.EventArgs e)
		{
			if(m_txtPart.Text.Trim() == "")
				return;
			Editor.m_mthDelPartList((m_txtPart.Tag).ToString());
			if(m_lsvPartList.SelectedItems.Count >0)
				m_lsvPartList.SelectedItems[0].Remove();
			m_txtPart.Text = "";
			m_txtPart.Tag = null;
			m_txtAssCode.Text = "";
            this.m_txtPinYinCode.Text = "";
            this.m_txtWuBiCode.Text="";
			Editor.m_mthGetPartList();
		}

		private void m_cmdModifyPart_Click(object sender, System.EventArgs e)
		{
			if(m_txtPart.Text.Trim() == "")
				return;
			Editor.m_mthModifyPartList(m_txtPart.Text ,m_txtAssCode.Text,(m_txtPart.Tag).ToString(),this.m_txtPinYinCode.Text,this.m_txtWuBiCode.Text);
			m_txtPart.Text = "";
			m_txtPart.Tag = null;
			m_txtAssCode.Text = "";
            this.m_txtPinYinCode.Text = "";
            this.m_txtWuBiCode.Text = "";
			Editor.m_mthGetPartList();
		}

		private void m_cmdAddAim_Click(object sender, System.EventArgs e)
		{
			if (lvType.SelectedItems.Count <1)
			{
				return;
			}
			if(m_txtAim.Text.Trim() == "")
				return;
			string id  = lvType.SelectedItems[0].SubItems[1].Text;
			Editor.m_mthAddAimList(m_txtAim.Text,id);
			m_txtAim.Text = "";
			m_txtAim.Tag = null;
			Editor.m_mthGetAimList();
		}

		private void m_cmdDelAim_Click(object sender, System.EventArgs e)
		{
			if(m_txtAim.Text.Trim() == "")
				return;
			Editor.m_mthDelAimList((m_txtAim.Tag).ToString());
			if(m_lsvAimList.SelectedItems.Count > 0)
				m_lsvAimList.SelectedItems[0].Remove();
			m_txtAim.Text = "";
			m_txtAim.Tag = null;
			Editor.m_mthGetAimList();
		}

		private void m_cmdModifyAim_Click(object sender, System.EventArgs e)
		{
			if(m_txtAim.Text.Trim() == "")
				return;
			Editor.m_mthModifyAimList(m_txtAim.Text,(m_txtAim.Tag).ToString());
			m_txtAim.Text = "";
			m_txtAim.Tag = null;
			Editor.m_mthGetAimList();
		}

        private void m_txtPart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {

                com.digitalwave.Utility.clsCreateChinaCode Ccode = new com.digitalwave.Utility.clsCreateChinaCode();
                m_txtPinYinCode.Text = Ccode.m_strCreateChinaCode(m_txtPart.Text, ChinaCode.PY);
                m_txtWuBiCode.Text = Ccode.m_strCreateChinaCode(m_txtPart.Text, ChinaCode.WB);
                m_txtAssCode.Focus();

            }
        }

        private void frmDictManage_Load(object sender, EventArgs e)
        {

        }

	}
}
