using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 用户登陆信息
	/// author: Cameron Wong
	/// create time: Aug 16, 2004
	/// </summary>
	public class frmLoginInfo : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		internal System.Windows.Forms.ListView m_lsv;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel1;
		private PinkieControls.ButtonXP m_btnExit;
		private PinkieControls.ButtonXP m_btnDelete;
		private PinkieControls.ButtonXP buttonXP1;
		internal CrystalDecisions.Windows.Forms.CrystalReportViewer m_crvTemp;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmLoginInfo()
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
			this.m_lsv = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.m_crvTemp = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.buttonXP1 = new PinkieControls.ButtonXP();
			this.m_btnExit = new PinkieControls.ButtonXP();
			this.m_btnDelete = new PinkieControls.ButtonXP();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_lsv
			// 
			this.m_lsv.AllowColumnReorder = true;
			this.m_lsv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					this.columnHeader1,
																					this.columnHeader2,
																					this.columnHeader3,
																					this.columnHeader4,
																					this.columnHeader5,
																					this.columnHeader8,
																					this.columnHeader6,
																					this.columnHeader7});
			this.m_lsv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_lsv.FullRowSelect = true;
			this.m_lsv.GridLines = true;
			this.m_lsv.HideSelection = false;
			this.m_lsv.Location = new System.Drawing.Point(0, 0);
			this.m_lsv.Name = "m_lsv";
			this.m_lsv.Size = new System.Drawing.Size(1028, 445);
			this.m_lsv.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.m_lsv.TabIndex = 0;
			this.m_lsv.View = System.Windows.Forms.View.Details;
			this.m_lsv.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.m_lsv_ColumnClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Width = 0;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "序号";
			this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader2.Width = 136;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "机器名";
			this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader3.Width = 145;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "网卡地址";
			this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader4.Width = 178;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "登陆时间";
			this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader5.Width = 138;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "退出时间";
			this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader8.Width = 159;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "角色";
			this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader6.Width = 152;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "员工";
			this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader7.Width = 116;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.m_lsv);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1028, 445);
			this.panel2.TabIndex = 2;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.m_crvTemp);
			this.panel1.Controls.Add(this.buttonXP1);
			this.panel1.Controls.Add(this.m_btnExit);
			this.panel1.Controls.Add(this.m_btnDelete);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.panel1.Location = new System.Drawing.Point(0, 445);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1028, 40);
			this.panel1.TabIndex = 2;
			// 
			// m_crvTemp
			// 
			this.m_crvTemp.ActiveViewIndex = -1;
			this.m_crvTemp.Location = new System.Drawing.Point(640, 184);
			this.m_crvTemp.Name = "m_crvTemp";
			this.m_crvTemp.ReportSource = null;
			this.m_crvTemp.Size = new System.Drawing.Size(8, 8);
			this.m_crvTemp.TabIndex = 11;
			// 
			// buttonXP1
			// 
			this.buttonXP1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.buttonXP1.DefaultScheme = true;
			this.buttonXP1.DialogResult = System.Windows.Forms.DialogResult.None;
			this.buttonXP1.Hint = "";
			this.buttonXP1.Location = new System.Drawing.Point(184, 8);
			this.buttonXP1.Name = "buttonXP1";
			this.buttonXP1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.buttonXP1.Size = new System.Drawing.Size(88, 24);
			this.buttonXP1.TabIndex = 10;
			this.buttonXP1.Text = "打印(&P)";
			this.buttonXP1.Click += new System.EventHandler(this.buttonXP1_Click);
			// 
			// m_btnExit
			// 
			this.m_btnExit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnExit.DefaultScheme = true;
			this.m_btnExit.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnExit.Hint = "";
			this.m_btnExit.Location = new System.Drawing.Point(280, 8);
			this.m_btnExit.Name = "m_btnExit";
			this.m_btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnExit.Size = new System.Drawing.Size(88, 24);
			this.m_btnExit.TabIndex = 8;
			this.m_btnExit.Text = "退出(Esc)";
			this.m_btnExit.Click += new System.EventHandler(this.m_btnExit_Click_1);
			// 
			// m_btnDelete
			// 
			this.m_btnDelete.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnDelete.DefaultScheme = true;
			this.m_btnDelete.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnDelete.Hint = "";
			this.m_btnDelete.Location = new System.Drawing.Point(8, 8);
			this.m_btnDelete.Name = "m_btnDelete";
			this.m_btnDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnDelete.Size = new System.Drawing.Size(136, 24);
			this.m_btnDelete.TabIndex = 9;
			this.m_btnDelete.Text = "删除所有记录(&D)";
			this.m_btnDelete.Click += new System.EventHandler(this.m_btnDelete_Click_1);
			// 
			// frmLoginInfo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(1028, 485);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("宋体", 10.5F);
			this.KeyPreview = true;
			this.Name = "frmLoginInfo";
			this.Text = "系统错误信息记录";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLoginInfo_KeyDown);
			this.Load += new System.EventHandler(this.frmLoginInfo_Load);
			this.panel2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void CreateController()
		{
			this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_LoginInfo();
			this.objController.Set_GUI_Apperance(this);
		}


		private void frmLoginInfo_Load(object sender, System.EventArgs e)
		{
			((clsCtl_LoginInfo)this.objController).m_GetLoginInfo();
		}

		private bool IsAsc = true;
		private void m_lsv_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			// Set the ListViewItemSorter property to a new ListViewItemComparer object.
			this.m_lsv.ListViewItemSorter = new ListViewItemComparer(e.Column, IsAsc, this.m_lsv);
			IsAsc = !IsAsc;
			// Call the sort method to manually sort the column based on the ListViewItemComparer implementation.
			this.m_lsv.Sort();
		}

		private void m_btnExit_Click_1(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void m_btnDelete_Click_1(object sender, System.EventArgs e)
		{
			((clsCtl_LoginInfo)this.objController).m_DeleteAll();
			this.frmLoginInfo_Load(this, null);
		
		}

		private void buttonXP1_Click(object sender, System.EventArgs e)
		{
			((clsCtl_LoginInfo)this.objController).m_Print();
		}

		private void frmLoginInfo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Escape)
			{
				if(MessageBox.Show("确认退出吗?","iCare",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
					return;
				m_btnExit_Click_1(sender,e);
			}
		}

	}

}
