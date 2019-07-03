using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmOPInvoiceRenew 的摘要说明。
	/// </summary>
	public class frmOPInvoiceRenew: com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
	{
		#region 控件申明
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		private PinkieControls.ButtonXP cmdResume;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		internal CrystalDecisions.Windows.Forms.CrystalReportViewer m_repInvoiceInfo;
		internal System.Windows.Forms.ListView m_lstItemsInfo;
		private System.Windows.Forms.TabControl tabInfo;
		#endregion

		internal com.digitalwave.controls.exTextBox txtCardID;
		internal com.digitalwave.controls.exTextBox txtInvoice;
		private System.Windows.Forms.Label label5;
		internal System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private PinkieControls.ButtonXP buttonXP1;
		internal System.Windows.Forms.Label lbeAuding;
        internal System.Windows.Forms.ComboBox cmbFind;
        internal Sybase.DataWindow.DataWindowControl dwInvoice;

		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmOPInvoiceRenew()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOPInvoiceRenew));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabInfo = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.m_repInvoiceInfo = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.m_lstItemsInfo = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbFind = new System.Windows.Forms.ComboBox();
            this.lbeAuding = new System.Windows.Forms.Label();
            this.buttonXP1 = new PinkieControls.ButtonXP();
            this.txtInvoice = new com.digitalwave.controls.exTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCardID = new com.digitalwave.controls.exTextBox();
            this.cmdResume = new PinkieControls.ButtonXP();
            this.dwInvoice = new Sybase.DataWindow.DataWindowControl();
            this.groupBox2.SuspendLayout();
            this.tabInfo.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabInfo);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox2.Location = new System.Drawing.Point(0, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(952, 469);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "项目信息";
            // 
            // tabInfo
            // 
            this.tabInfo.Controls.Add(this.tabPage1);
            this.tabInfo.Controls.Add(this.tabPage2);
            this.tabInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabInfo.Location = new System.Drawing.Point(3, 19);
            this.tabInfo.Name = "tabInfo";
            this.tabInfo.SelectedIndex = 0;
            this.tabInfo.Size = new System.Drawing.Size(946, 447);
            this.tabInfo.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dwInvoice);
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Controls.Add(this.m_repInvoiceInfo);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(938, 420);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "发票信息[F2]";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader9});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(240, 32);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(352, 152);
            this.listView1.TabIndex = 23;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.Visible = false;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            this.listView1.Leave += new System.EventHandler(this.listView1_Leave);
            this.listView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "发票号";
            this.columnHeader1.Width = 109;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "系统号";
            this.columnHeader9.Width = 217;
            // 
            // m_repInvoiceInfo
            // 
            this.m_repInvoiceInfo.ActiveViewIndex = -1;
            this.m_repInvoiceInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_repInvoiceInfo.DisplayGroupTree = false;
            this.m_repInvoiceInfo.DisplayToolbar = false;
            this.m_repInvoiceInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_repInvoiceInfo.Location = new System.Drawing.Point(0, 0);
            this.m_repInvoiceInfo.Name = "m_repInvoiceInfo";
            this.m_repInvoiceInfo.SelectionFormula = "";
            this.m_repInvoiceInfo.Size = new System.Drawing.Size(938, 420);
            this.m_repInvoiceInfo.TabIndex = 19;
            this.m_repInvoiceInfo.ViewTimeSelectionFormula = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.m_lstItemsInfo);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(938, 424);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "处方信息[F3]";
            this.tabPage2.Visible = false;
            // 
            // m_lstItemsInfo
            // 
            this.m_lstItemsInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.m_lstItemsInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lstItemsInfo.GridLines = true;
            this.m_lstItemsInfo.Location = new System.Drawing.Point(0, 0);
            this.m_lstItemsInfo.Name = "m_lstItemsInfo";
            this.m_lstItemsInfo.Size = new System.Drawing.Size(938, 424);
            this.m_lstItemsInfo.TabIndex = 0;
            this.m_lstItemsInfo.UseCompatibleStateImageBehavior = false;
            this.m_lstItemsInfo.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "项目名称";
            this.columnHeader2.Width = 159;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "规格";
            this.columnHeader3.Width = 153;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "产地";
            this.columnHeader4.Width = 113;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "单位";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "零售价";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "数量";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "医生";
            this.columnHeader8.Width = 75;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbFind);
            this.groupBox1.Controls.Add(this.lbeAuding);
            this.groupBox1.Controls.Add(this.buttonXP1);
            this.groupBox1.Controls.Add(this.txtInvoice);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtCardID);
            this.groupBox1.Controls.Add(this.cmdResume);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(952, 64);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "项目信息";
            // 
            // cmbFind
            // 
            this.cmbFind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFind.Items.AddRange(new object[] {
            "卡  号",
            "物理发票号"});
            this.cmbFind.Location = new System.Drawing.Point(24, 27);
            this.cmbFind.Name = "cmbFind";
            this.cmbFind.Size = new System.Drawing.Size(104, 22);
            this.cmbFind.TabIndex = 27;
            // 
            // lbeAuding
            // 
            this.lbeAuding.AutoSize = true;
            this.lbeAuding.ForeColor = System.Drawing.Color.Red;
            this.lbeAuding.Location = new System.Drawing.Point(512, 30);
            this.lbeAuding.Name = "lbeAuding";
            this.lbeAuding.Size = new System.Drawing.Size(0, 14);
            this.lbeAuding.TabIndex = 24;
            // 
            // buttonXP1
            // 
            this.buttonXP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.buttonXP1.DefaultScheme = true;
            this.buttonXP1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP1.Hint = "";
            this.buttonXP1.Location = new System.Drawing.Point(808, 16);
            this.buttonXP1.Name = "buttonXP1";
            this.buttonXP1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP1.Size = new System.Drawing.Size(128, 32);
            this.buttonXP1.TabIndex = 23;
            this.buttonXP1.Text = "审 核 发 票[&D]";
            this.buttonXP1.Click += new System.EventHandler(this.buttonXP1_Click);
            // 
            // txtInvoice
            // 
            this.txtInvoice.Location = new System.Drawing.Point(352, 27);
            this.txtInvoice.MaxLength = 18;
            this.txtInvoice.Name = "txtInvoice";
            this.txtInvoice.SendTabKey = false;
            this.txtInvoice.SetFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtInvoice.Size = new System.Drawing.Size(144, 23);
            this.txtInvoice.TabIndex = 1;
            this.txtInvoice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInvoice_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(264, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 14);
            this.label5.TabIndex = 22;
            this.label5.Text = "系统发票号:";
            // 
            // txtCardID
            // 
            this.txtCardID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCardID.Location = new System.Drawing.Point(136, 27);
            this.txtCardID.MaxLength = 10;
            this.txtCardID.Name = "txtCardID";
            this.txtCardID.SendTabKey = false;
            this.txtCardID.SetFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtCardID.Size = new System.Drawing.Size(120, 23);
            this.txtCardID.TabIndex = 0;
            this.txtCardID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCardID_KeyDown);
            // 
            // cmdResume
            // 
            this.cmdResume.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.cmdResume.DefaultScheme = true;
            this.cmdResume.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdResume.Hint = "";
            this.cmdResume.Location = new System.Drawing.Point(672, 16);
            this.cmdResume.Name = "cmdResume";
            this.cmdResume.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdResume.Size = new System.Drawing.Size(128, 32);
            this.cmdResume.TabIndex = 2;
            this.cmdResume.Text = "恢 复 发 票[F5]";
            this.cmdResume.Click += new System.EventHandler(this.cmdResume_Click);
            // 
            // dwInvoice
            // 
            this.dwInvoice.DataWindowObject = "";
            this.dwInvoice.LibraryList = "";
            this.dwInvoice.Location = new System.Drawing.Point(5, 0);
            this.dwInvoice.Name = "dwInvoice";
            this.dwInvoice.Size = new System.Drawing.Size(924, 397);
            this.dwInvoice.TabIndex = 24;
            this.dwInvoice.Text = "dataWindowControl1";
            // 
            // frmOPInvoiceRenew
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(952, 533);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmOPInvoiceRenew";
            this.Text = "门诊发票恢复";
            this.Load += new System.EventHandler(this.frmOPInvoiceRenew_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmOPInvoiceRenew_KeyDown);
            this.groupBox2.ResumeLayout(false);
            this.tabInfo.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		public override void CreateController()
		{
			this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_OPInvoiceRenew();
			objController.Set_GUI_Apperance(this);
		}

		#region 事件
		private void cmdResume_Click(object sender, System.EventArgs e)
		{
			if(MessageBox.Show("是否要恢复发票?","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
			{
				return;
			}
			((clsCtl_OPInvoiceRenew)this.objController).m_ResumeTicket();
		}
		private void m_txtINVOICENO_VCHR_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				cmdResume.Focus();
			}
		}

		private void m_txtSEQID_CHR_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{	
				cmdResume.Focus();
			}
		}

		private void m_txtSEQID_CHR_Leave(object sender, System.EventArgs e)
		{
			//显示发票号
			((clsCtl_OPInvoiceRenew)this.objController).DisplayInvoiceNo();
			//显示发票详细信息
			((clsCtl_OPInvoiceRenew)this.objController).m_DisplayInvoiceInfo();
		}
		#endregion 

		private void frmOPInvoiceRenew_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Escape)
			{
				if(MessageBox.Show("确认退出吗?","iCare",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
					return;
				this.Close();
			}
			switch (e.KeyCode)
			{
				case Keys.Escape:
					this.Close();
					break;
				case Keys.F2:					
					this.tabInfo.SelectedIndex =0;
					break;
				case Keys.F3:
					this.tabInfo.SelectedIndex =1;
					break;
				case Keys.F5:
					this.cmdResume_Click(sender,e);
					break;
			}
		}

		private void frmOPInvoiceRenew_Load(object sender, System.EventArgs e)
			{
			this.cmbFind.SelectedIndex=0;
			this.Controls.Add(this.listView1);
			this.listView1.Left =this.txtInvoice.Left;
			this.listView1.Top =this.txtInvoice.Top+this.txtInvoice.Height;
			((clsCtl_OPInvoiceRenew)this.objController).m_mthIsPrintInvoice();
		}

			private void txtInvoice_Enter(object sender, System.EventArgs e)
			{
				//			if(this.listView1.Items.Count>0)
				//			{
				//				this.listView1.Items[0].Selected=true;
				//				this.listView1.Show();
				//				this.listView1.Focus();
				//			}
			}

		private void listView1_Leave(object sender, System.EventArgs e)
		{
			this.listView1.Hide();
		}

		private void listView1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				listView1_DoubleClick(null,null);
			}
		}

		private void listView1_DoubleClick(object sender, System.EventArgs e)
		{
			if(this.listView1.SelectedItems.Count>0)
			{
				this.txtInvoice.Text =this.listView1.SelectedItems[0].SubItems[1].Text;
				this.txtInvoice.Focus();
			}
		}

		private void txtInvoice_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				this.Cursor =System.Windows.Forms.Cursors.WaitCursor;			
				((clsCtl_OPInvoiceRenew)this.objController).m_DisplayInvoiceInfo();
				this.cmdResume.Enabled =true;
                this.buttonXP1.Enabled = true;
				this.Cursor =System.Windows.Forms.Cursors.Default;
			}
		}

//		private void m_txtINVOICENO_VCHR_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
//		{
//			if(e.KeyCode==Keys.Enter)
//				((clsCtl_OPInvoiceRenew)this.objController).m_DisplayInvoiceInfo();
//		}

		private void txtCardID_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				if(this.cmbFind.SelectedIndex ==0)
				this.txtCardID.Text =this.txtCardID.Text.PadLeft(10,'0');
				((clsCtl_OPInvoiceRenew)this.objController).m_mthFindInvoiceByCardID();
                this.cmdResume.Enabled = false;
                this.buttonXP1.Enabled = false;
			}
		}

		private void buttonXP1_Click(object sender, System.EventArgs e)
		{
		((clsCtl_OPInvoiceRenew)this.objController).m_mthAudingInvoice();
		}

//		private void cmbInvoiceNO_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
//		{
//			if(e.KeyCode==Keys.Enter)
//			{
//				((clsCtl_OPInvoiceRenew)this.objController).m_DisplayInvoiceInfo();
//			}
//		}
	}
}
