using System;
using System.Drawing;

using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
namespace  com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmItemCatMapping 的摘要说明。
	/// </summary>
	public class frmItemCatMapping :com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.Panel panel1;
		internal System.Windows.Forms.ListView listView1;
		internal System.Windows.Forms.ListView listView2;
		internal PinkieControls.ButtonXP btOK;
		private PinkieControls.ButtonXP btExit;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		internal System.Windows.Forms.ComboBox cmbCatType;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmItemCatMapping()
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
			System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("西药");
			System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("中药");
			System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("检验");
			System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("检查");
			System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("其他");
			System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("手术\\治疗");
			this.panel1 = new System.Windows.Forms.Panel();
			this.cmbCatType = new System.Windows.Forms.ComboBox();
			this.btExit = new PinkieControls.ButtonXP();
			this.btOK = new PinkieControls.ButtonXP();
			this.listView2 = new System.Windows.Forms.ListView();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.panel1.Controls.Add(this.cmbCatType);
			this.panel1.Controls.Add(this.btExit);
			this.panel1.Controls.Add(this.btOK);
			this.panel1.Controls.Add(this.listView2);
			this.panel1.Controls.Add(this.listView1);
			this.panel1.Location = new System.Drawing.Point(12, 8);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(536, 472);
			this.panel1.TabIndex = 0;
			// 
			// cmbCatType
			// 
			this.cmbCatType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCatType.Items.AddRange(new object[] {
															"医生工作站使用",
															"门诊收费使用"});
			this.cmbCatType.Location = new System.Drawing.Point(56, 8);
			this.cmbCatType.Name = "cmbCatType";
			this.cmbCatType.Size = new System.Drawing.Size(176, 22);
			this.cmbCatType.TabIndex = 4;
			this.cmbCatType.SelectedIndexChanged += new System.EventHandler(this.cmbCatType_SelectedIndexChanged);
			// 
			// btExit
			// 
			this.btExit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btExit.DefaultScheme = true;
			this.btExit.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btExit.Hint = "";
			this.btExit.Location = new System.Drawing.Point(312, 416);
			this.btExit.Name = "btExit";
			this.btExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btExit.Size = new System.Drawing.Size(96, 32);
			this.btExit.TabIndex = 3;
			this.btExit.Text = "退出(Esc)";
			this.btExit.Click += new System.EventHandler(this.btExit_Click);
			// 
			// btOK
			// 
			this.btOK.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btOK.DefaultScheme = true;
			this.btOK.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btOK.Hint = "";
			this.btOK.Location = new System.Drawing.Point(80, 416);
			this.btOK.Name = "btOK";
			this.btOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btOK.Size = new System.Drawing.Size(96, 32);
			this.btOK.TabIndex = 2;
			this.btOK.TabStop = false;
			this.btOK.Text = "保存(&S)";
			this.btOK.Click += new System.EventHandler(this.btOK_Click);
			// 
			// listView2
			// 
			this.listView2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listView2.CheckBoxes = true;
			this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader2});
			this.listView2.Font = new System.Drawing.Font("宋体", 11F);
			this.listView2.FullRowSelect = true;
			this.listView2.GridLines = true;
			this.listView2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView2.Location = new System.Drawing.Point(280, 40);
			this.listView2.Name = "listView2";
			this.listView2.Size = new System.Drawing.Size(176, 360);
			this.listView2.TabIndex = 1;
			this.listView2.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "隶属分类";
			this.columnHeader2.Width = 152;
			// 
			// listView1
			// 
			this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1});
			this.listView1.Font = new System.Drawing.Font("宋体", 11F);
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView1.HideSelection = false;
			listViewItem1.Tag = "0001";
			listViewItem2.Tag = "0002";
			listViewItem3.Tag = "0003";
			listViewItem4.Tag = "0004";
			listViewItem5.Tag = "0005";
			listViewItem6.Tag = "0006";
			this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
																					  listViewItem1,
																					  listViewItem2,
																					  listViewItem3,
																					  listViewItem4,
																					  listViewItem5,
																					  listViewItem6});
			this.listView1.Location = new System.Drawing.Point(56, 40);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(176, 360);
			this.listView1.TabIndex = 0;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "分类名称";
			this.columnHeader1.Width = 138;
			// 
			// frmItemCatMapping
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(568, 485);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("宋体", 10.5F);
			this.KeyPreview = true;
			this.Name = "frmItemCatMapping";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "项目分类关系维护";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmItemCatMapping_KeyDown);
			this.Resize += new System.EventHandler(this.frmItemCatMapping_Resize);
			this.Load += new System.EventHandler(this.frmItemCatMapping_Load);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		public override void CreateController()
		{
			this.objController=new com.digitalwave.iCare.gui.HIS.clsCtl_ItemCatMapping();
			objController.Set_GUI_Apperance(this);
		}
		private void frmItemCatMapping_Load(object sender, System.EventArgs e)
		{
		this.cmbCatType.SelectedIndex=0;
		((clsCtl_ItemCatMapping)this.objController).m_mthLoadMainListViewItem();
		}

		private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.listView1.SelectedItems.Count>0)
			{
				this.btOK.Tag=this.listView1.SelectedItems[0].Tag;
				((clsCtl_ItemCatMapping)this.objController).m_mthGetSubjectionCat();
			}
		}

		private void btExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btOK_Click(object sender, System.EventArgs e)
		{
			((clsCtl_ItemCatMapping)this.objController).m_mthSaveData();
		}

		private void frmItemCatMapping_Resize(object sender, System.EventArgs e)
		{
			this.panel1.Left=(this.Width-this.panel1.Width)/2;
			this.panel1.Top=(this.Height-this.panel1.Height)/2;
		}

		private void frmItemCatMapping_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Escape)
			{
				if(MessageBox.Show("确认退出吗?","iCare",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
					return;btExit_Click(sender,e);
			}

		}

		private void cmbCatType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		((clsCtl_ItemCatMapping)this.objController).m_mthGetSubjectionCat();
		}
		
	}
}
