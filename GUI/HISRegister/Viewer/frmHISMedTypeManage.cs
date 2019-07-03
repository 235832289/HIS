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
	/// 药理分类维护窗口
	/// Create 黄伟灵 by 2005-09-8
	/// </summary>
	public class frmHISMedTypeManage: com.digitalwave.GUI_Base.frmMDI_Child_Base	//GUI_Base.dll
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.GroupBox groupBox1;
		internal System.Windows.Forms.TreeView m_trvMedType;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label2;
		internal com.digitalwave.controls.exTextBox m_txtMedName;
		internal com.digitalwave.controls.exTextBox m_txtMedZhuJi;
		internal com.digitalwave.controls.exTextBox m_txtMedWb;
		internal com.digitalwave.controls.exTextBox m_txtMedPy;
		private PinkieControls.ButtonXP m_cmdAddMainNode;
		private PinkieControls.ButtonXP m_cmdAddSubNode;
		private PinkieControls.ButtonXP m_cmdSaveNode;
		private PinkieControls.ButtonXP m_cmdDelNode;
		private PinkieControls.ButtonXP m_cmdExit;
		private PinkieControls.ButtonXP m_btnAddTop;
		private PinkieControls.ButtonXP m_btnAddSub;
		private PinkieControls.ButtonXP m_btnSave;
		private PinkieControls.ButtonXP m_btnDelete;
		private PinkieControls.ButtonXP m_btnEsc;
		internal System.Windows.Forms.Label m_lbeType;
		private PinkieControls.ButtonXP m_cmdAlter;



		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmHISMedTypeManage()
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
		///  确认用户的操作标志：增加主结点为：AddTop,增加子结点为:AddSub,修改为：Save
		///  默认为Save
		/// </summary>
		public string m_strUserOp = "Save";


		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.m_trvMedType = new System.Windows.Forms.TreeView();
			this.panel2 = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.m_lbeType = new System.Windows.Forms.Label();
			this.m_txtMedPy = new com.digitalwave.controls.exTextBox();
			this.m_txtMedWb = new com.digitalwave.controls.exTextBox();
			this.m_txtMedZhuJi = new com.digitalwave.controls.exTextBox();
			this.m_txtMedName = new com.digitalwave.controls.exTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.m_btnEsc = new PinkieControls.ButtonXP();
			this.m_btnDelete = new PinkieControls.ButtonXP();
			this.m_btnSave = new PinkieControls.ButtonXP();
			this.m_btnAddSub = new PinkieControls.ButtonXP();
			this.m_btnAddTop = new PinkieControls.ButtonXP();
			this.m_cmdExit = new PinkieControls.ButtonXP();
			this.m_cmdDelNode = new PinkieControls.ButtonXP();
			this.m_cmdSaveNode = new PinkieControls.ButtonXP();
			this.m_cmdAddSubNode = new PinkieControls.ButtonXP();
			this.m_cmdAddMainNode = new PinkieControls.ButtonXP();
			this.m_cmdAlter = new PinkieControls.ButtonXP();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.m_trvMedType);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(256, 525);
			this.panel1.TabIndex = 0;
			// 
			// m_trvMedType
			// 
			this.m_trvMedType.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_trvMedType.FullRowSelect = true;
			this.m_trvMedType.HideSelection = false;
			this.m_trvMedType.ImageIndex = -1;
			this.m_trvMedType.Location = new System.Drawing.Point(0, 0);
			this.m_trvMedType.Name = "m_trvMedType";
			this.m_trvMedType.SelectedImageIndex = -1;
			this.m_trvMedType.Size = new System.Drawing.Size(252, 521);
			this.m_trvMedType.TabIndex = 12;
			this.m_trvMedType.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_trvMedType_AfterSelect);
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel2.Controls.Add(this.groupBox1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(256, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(424, 336);
			this.panel2.TabIndex = 1;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.m_lbeType);
			this.groupBox1.Controls.Add(this.m_txtMedPy);
			this.groupBox1.Controls.Add(this.m_txtMedWb);
			this.groupBox1.Controls.Add(this.m_txtMedZhuJi);
			this.groupBox1.Controls.Add(this.m_txtMedName);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(420, 332);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "药理分类维护基本信息";
			// 
			// m_lbeType
			// 
			this.m_lbeType.AutoSize = true;
			this.m_lbeType.Location = new System.Drawing.Point(152, 32);
			this.m_lbeType.Name = "m_lbeType";
			this.m_lbeType.Size = new System.Drawing.Size(0, 19);
			this.m_lbeType.TabIndex = 12;
			// 
			// m_txtMedPy
			// 
			this.m_txtMedPy.Location = new System.Drawing.Point(152, 168);
			this.m_txtMedPy.MaxLength = 20;
			this.m_txtMedPy.Name = "m_txtMedPy";
			this.m_txtMedPy.SendTabKey = true;
			this.m_txtMedPy.SetFocusColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.m_txtMedPy.Size = new System.Drawing.Size(168, 23);
			this.m_txtMedPy.TabIndex = 2;
			this.m_txtMedPy.Text = "";
			// 
			// m_txtMedWb
			// 
			this.m_txtMedWb.Location = new System.Drawing.Point(152, 224);
			this.m_txtMedWb.MaxLength = 20;
			this.m_txtMedWb.Name = "m_txtMedWb";
			this.m_txtMedWb.SendTabKey = true;
			this.m_txtMedWb.SetFocusColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.m_txtMedWb.Size = new System.Drawing.Size(168, 23);
			this.m_txtMedWb.TabIndex = 3;
			this.m_txtMedWb.Text = "";
			// 
			// m_txtMedZhuJi
			// 
			this.m_txtMedZhuJi.Location = new System.Drawing.Point(152, 116);
			this.m_txtMedZhuJi.MaxLength = 20;
			this.m_txtMedZhuJi.Name = "m_txtMedZhuJi";
			this.m_txtMedZhuJi.SendTabKey = true;
			this.m_txtMedZhuJi.SetFocusColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.m_txtMedZhuJi.Size = new System.Drawing.Size(168, 23);
			this.m_txtMedZhuJi.TabIndex = 1;
			this.m_txtMedZhuJi.Text = "";
			// 
			// m_txtMedName
			// 
			this.m_txtMedName.Location = new System.Drawing.Point(152, 68);
			this.m_txtMedName.MaxLength = 50;
			this.m_txtMedName.Name = "m_txtMedName";
			this.m_txtMedName.SendTabKey = true;
			this.m_txtMedName.SetFocusColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.m_txtMedName.Size = new System.Drawing.Size(168, 23);
			this.m_txtMedName.TabIndex = 0;
			this.m_txtMedName.Text = "";
			this.m_txtMedName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtMedName_KeyDown);
			this.m_txtMedName.Leave += new System.EventHandler(this.m_txtMedName_Leave);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(72, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(77, 19);
			this.label2.TabIndex = 11;
			this.label2.Text = "药理名称：";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(72, 226);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(70, 19);
			this.label5.TabIndex = 10;
			this.label5.Text = "拼 音 码:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(72, 172);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(70, 19);
			this.label4.TabIndex = 8;
			this.label4.Text = "五 笔 码:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(72, 120);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(77, 19);
			this.label3.TabIndex = 6;
			this.label3.Text = "助 记 码：";
			// 
			// panel3
			// 
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel3.Controls.Add(this.groupBox2);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(256, 336);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(424, 189);
			this.panel3.TabIndex = 2;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.m_cmdAlter);
			this.groupBox2.Controls.Add(this.m_btnEsc);
			this.groupBox2.Controls.Add(this.m_btnDelete);
			this.groupBox2.Controls.Add(this.m_btnSave);
			this.groupBox2.Controls.Add(this.m_btnAddSub);
			this.groupBox2.Controls.Add(this.m_btnAddTop);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.groupBox2.Location = new System.Drawing.Point(0, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(420, 185);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "相关维护操作";
			// 
			// m_btnEsc
			// 
			this.m_btnEsc.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnEsc.DefaultScheme = true;
			this.m_btnEsc.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnEsc.Hint = "";
			this.m_btnEsc.Location = new System.Drawing.Point(288, 104);
			this.m_btnEsc.Name = "m_btnEsc";
			this.m_btnEsc.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnEsc.Size = new System.Drawing.Size(96, 40);
			this.m_btnEsc.TabIndex = 4;
			this.m_btnEsc.Text = "退出(&ESC)";
			this.m_btnEsc.Click += new System.EventHandler(this.m_btnEsc_Click);
			// 
			// m_btnDelete
			// 
			this.m_btnDelete.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnDelete.DefaultScheme = true;
			this.m_btnDelete.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnDelete.Hint = "";
			this.m_btnDelete.Location = new System.Drawing.Point(48, 104);
			this.m_btnDelete.Name = "m_btnDelete";
			this.m_btnDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnDelete.Size = new System.Drawing.Size(96, 40);
			this.m_btnDelete.TabIndex = 3;
			this.m_btnDelete.Text = "删除(&D)";
			this.m_btnDelete.Click += new System.EventHandler(this.m_btnDelete_Click);
			// 
			// m_btnSave
			// 
			this.m_btnSave.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnSave.DefaultScheme = true;
			this.m_btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnSave.Hint = "";
			this.m_btnSave.Location = new System.Drawing.Point(288, 40);
			this.m_btnSave.Name = "m_btnSave";
			this.m_btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnSave.Size = new System.Drawing.Size(96, 40);
			this.m_btnSave.TabIndex = 2;
			this.m_btnSave.Text = "保存(&S)";
			this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
			// 
			// m_btnAddSub
			// 
			this.m_btnAddSub.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnAddSub.DefaultScheme = true;
			this.m_btnAddSub.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnAddSub.Hint = "";
			this.m_btnAddSub.Location = new System.Drawing.Point(168, 40);
			this.m_btnAddSub.Name = "m_btnAddSub";
			this.m_btnAddSub.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnAddSub.Size = new System.Drawing.Size(96, 40);
			this.m_btnAddSub.TabIndex = 1;
			this.m_btnAddSub.Text = "增加子分类";
			this.m_btnAddSub.Click += new System.EventHandler(this.m_btnAddSub_Click);
			// 
			// m_btnAddTop
			// 
			this.m_btnAddTop.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnAddTop.DefaultScheme = true;
			this.m_btnAddTop.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnAddTop.Hint = "";
			this.m_btnAddTop.Location = new System.Drawing.Point(48, 40);
			this.m_btnAddTop.Name = "m_btnAddTop";
			this.m_btnAddTop.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnAddTop.Size = new System.Drawing.Size(96, 40);
			this.m_btnAddTop.TabIndex = 0;
			this.m_btnAddTop.Text = "增加顶级分类";
			this.m_btnAddTop.Click += new System.EventHandler(this.m_btnAddTop_Click);
			// 
			// m_cmdExit
			// 
			this.m_cmdExit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdExit.DefaultScheme = true;
			this.m_cmdExit.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdExit.Hint = "";
			this.m_cmdExit.Location = new System.Drawing.Point(288, 112);
			this.m_cmdExit.Name = "m_cmdExit";
			this.m_cmdExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdExit.Size = new System.Drawing.Size(10, 10);
			this.m_cmdExit.TabIndex = 0;
			// 
			// m_cmdDelNode
			// 
			this.m_cmdDelNode.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdDelNode.DefaultScheme = true;
			this.m_cmdDelNode.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdDelNode.Hint = "";
			this.m_cmdDelNode.Location = new System.Drawing.Point(40, 112);
			this.m_cmdDelNode.Name = "m_cmdDelNode";
			this.m_cmdDelNode.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdDelNode.Size = new System.Drawing.Size(10, 10);
			this.m_cmdDelNode.TabIndex = 0;
			// 
			// m_cmdSaveNode
			// 
			this.m_cmdSaveNode.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdSaveNode.DefaultScheme = true;
			this.m_cmdSaveNode.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdSaveNode.Hint = "";
			this.m_cmdSaveNode.Location = new System.Drawing.Point(288, 48);
			this.m_cmdSaveNode.Name = "m_cmdSaveNode";
			this.m_cmdSaveNode.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdSaveNode.Size = new System.Drawing.Size(10, 10);
			this.m_cmdSaveNode.TabIndex = 0;
			// 
			// m_cmdAddSubNode
			// 
			this.m_cmdAddSubNode.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdAddSubNode.DefaultScheme = true;
			this.m_cmdAddSubNode.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdAddSubNode.Hint = "";
			this.m_cmdAddSubNode.Location = new System.Drawing.Point(168, 48);
			this.m_cmdAddSubNode.Name = "m_cmdAddSubNode";
			this.m_cmdAddSubNode.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdAddSubNode.Size = new System.Drawing.Size(10, 10);
			this.m_cmdAddSubNode.TabIndex = 0;
			// 
			// m_cmdAddMainNode
			// 
			this.m_cmdAddMainNode.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdAddMainNode.DefaultScheme = true;
			this.m_cmdAddMainNode.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdAddMainNode.Hint = "";
			this.m_cmdAddMainNode.Location = new System.Drawing.Point(40, 48);
			this.m_cmdAddMainNode.Name = "m_cmdAddMainNode";
			this.m_cmdAddMainNode.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdAddMainNode.Size = new System.Drawing.Size(10, 10);
			this.m_cmdAddMainNode.TabIndex = 0;
			// 
			// m_cmdAlter
			// 
			this.m_cmdAlter.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdAlter.DefaultScheme = true;
			this.m_cmdAlter.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdAlter.Hint = "";
			this.m_cmdAlter.Location = new System.Drawing.Point(168, 104);
			this.m_cmdAlter.Name = "m_cmdAlter";
			this.m_cmdAlter.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdAlter.Size = new System.Drawing.Size(96, 40);
			this.m_cmdAlter.TabIndex = 5;
			this.m_cmdAlter.Text = "修  改";
			this.m_cmdAlter.Click += new System.EventHandler(this.m_cmdAlter_Click);
			// 
			// frmHISMedTypeManage
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(680, 525);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "frmHISMedTypeManage";
			this.Text = "药理分类维护模块";
			this.Load += new System.EventHandler(this.frmHISMedTypeManage_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region 重载CreateController
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		public override void CreateController()
		{			
			this.objController = new clsControlHISMedTypeManage();
			this.objController.Set_GUI_Apperance(this);
		}
		#endregion




		private void frmHISMedTypeManage_Load(object sender, System.EventArgs e)
		{
			((clsControlHISMedTypeManage)objController).m_mthGetMainItem();
			((clsControlHISMedTypeManage)objController).m_mthSetFirstFocus();
	
		}
	

		private void m_txtMedName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			//获取拼音码与五笔码
			if(e.KeyCode==Keys.Enter)
			{
				com.digitalwave.Utility.clsCreateChinaCode Ccode = new com.digitalwave.Utility.clsCreateChinaCode();				
				
				m_txtMedPy.Text = Ccode.m_strCreateChinaCode(this.m_txtMedName.Text.Trim(),ChinaCode.WB);
				
				m_txtMedWb.Text = Ccode.m_strCreateChinaCode(m_txtMedName.Text.Trim(),ChinaCode.PY);
				
			}
		}
		private void m_btnEsc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		
		}

		private void m_trvMedType_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			((clsControlHISMedTypeManage)objController).m_mthSelectNode(e.Node);
			
		}

		private void m_btnDelete_Click(object sender, System.EventArgs e)
		{
			((clsControlHISMedTypeManage)objController).m_mthDelete();
		
		}

		private void m_btnAddTop_Click(object sender, System.EventArgs e)
		{
			//修改用户操作标志为：AddTop
			this.m_strUserOp = "AddTop";
			((clsControlHISMedTypeManage)objController).m_mthAddMain();
		
		}

		private void m_btnAddSub_Click(object sender, System.EventArgs e)
		{
			
			//修改用户操作标志为：AddSub
			this.m_strUserOp = "AddSub";

			((clsControlHISMedTypeManage)objController).m_mthAddSub();
		
		}

		private void m_btnSave_Click(object sender, System.EventArgs e)
		{
			((clsControlHISMedTypeManage)objController).m_mthSave(m_strUserOp);
			//修改用户操作标志为：Save
			//			this.m_strUserOp = "Save";
		
		}

		private void m_txtMedName_Leave(object sender, System.EventArgs e)
		{
			//获取拼码与五笔码			
			com.digitalwave.Utility.clsCreateChinaCode Ccode = new com.digitalwave.Utility.clsCreateChinaCode();				
				
			m_txtMedPy.Text = Ccode.m_strCreateChinaCode(this.m_txtMedName.Text.Trim(),ChinaCode.WB);
				
			m_txtMedWb.Text = Ccode.m_strCreateChinaCode(m_txtMedName.Text.Trim(),ChinaCode.PY);
						
		}

		private void m_cmdAlter_Click(object sender, System.EventArgs e)
		{
			((clsControlHISMedTypeManage)objController).m_mthAlter();
			
		}


	}
}
