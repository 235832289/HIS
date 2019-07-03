using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 药品基本信息列表 Create by Sam 2004-5-24
	/// </summary>
	public class frmWeekPlan :com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.ContextMenu m_Menu;
		private System.Windows.Forms.MenuItem mu_Add;
		private System.Windows.Forms.MenuItem mu_Edit;
		private System.Windows.Forms.MenuItem mu_Del;
		private System.Windows.Forms.MenuItem mu_App;
		internal System.Windows.Forms.TreeView m_TV;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel1;
		internal System.Windows.Forms.ListView m_lvwPlan;
		private System.Windows.Forms.Panel panel2;
		internal System.Windows.Forms.TabControl m_tab;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.TabPage tabPage6;
		private System.Windows.Forms.TabPage tabPage7;
		private System.Windows.Forms.ColumnHeader col1;
		private System.Windows.Forms.ColumnHeader col2;
		private System.Windows.Forms.ColumnHeader col3;
		private System.Windows.Forms.ColumnHeader col4;
		private System.Windows.Forms.ColumnHeader col5;
		private System.Windows.Forms.ColumnHeader col6;
		private System.Windows.Forms.ColumnHeader col7;
		private System.Windows.Forms.ColumnHeader col8;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.ToolBarButton Add;
		private System.Windows.Forms.ToolBarButton Edit;
		private System.Windows.Forms.ToolBarButton Del;
		private System.Windows.Forms.ToolBarButton Find;
		private System.Windows.Forms.ToolBarButton reNew;
		private System.Windows.Forms.ToolBarButton Re;
		private System.Windows.Forms.ToolBarButton Esc;
		private System.Windows.Forms.ToolBar m_tb;
		private System.Windows.Forms.ColumnHeader col9;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmWeekPlan()
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
			this.m_Menu = new System.Windows.Forms.ContextMenu();
			this.mu_Add = new System.Windows.Forms.MenuItem();
			this.mu_Edit = new System.Windows.Forms.MenuItem();
			this.mu_Del = new System.Windows.Forms.MenuItem();
			this.mu_App = new System.Windows.Forms.MenuItem();
			this.m_TV = new System.Windows.Forms.TreeView();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel1 = new System.Windows.Forms.Panel();
			this.m_lvwPlan = new System.Windows.Forms.ListView();
			this.col9 = new System.Windows.Forms.ColumnHeader();
			this.col1 = new System.Windows.Forms.ColumnHeader();
			this.col2 = new System.Windows.Forms.ColumnHeader();
			this.col3 = new System.Windows.Forms.ColumnHeader();
			this.col4 = new System.Windows.Forms.ColumnHeader();
			this.col5 = new System.Windows.Forms.ColumnHeader();
			this.col6 = new System.Windows.Forms.ColumnHeader();
			this.col7 = new System.Windows.Forms.ColumnHeader();
			this.col8 = new System.Windows.Forms.ColumnHeader();
			this.panel2 = new System.Windows.Forms.Panel();
			this.m_tab = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.tabPage7 = new System.Windows.Forms.TabPage();
			this.label2 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.m_tb = new System.Windows.Forms.ToolBar();
			this.Add = new System.Windows.Forms.ToolBarButton();
			this.Edit = new System.Windows.Forms.ToolBarButton();
			this.Del = new System.Windows.Forms.ToolBarButton();
			this.Find = new System.Windows.Forms.ToolBarButton();
			this.reNew = new System.Windows.Forms.ToolBarButton();
			this.Re = new System.Windows.Forms.ToolBarButton();
			this.Esc = new System.Windows.Forms.ToolBarButton();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.m_tab.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_Menu
			// 
			this.m_Menu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				   this.mu_Add,
																				   this.mu_Edit,
																				   this.mu_Del,
																				   this.mu_App});
			// 
			// mu_Add
			// 
			this.mu_Add.Index = 0;
			this.mu_Add.Text = "新增";
			this.mu_Add.Click += new System.EventHandler(this.mu_Add_Click);
			// 
			// mu_Edit
			// 
			this.mu_Edit.Index = 1;
			this.mu_Edit.Text = "修改";
			this.mu_Edit.Click += new System.EventHandler(this.mu_Edit_Click);
			// 
			// mu_Del
			// 
			this.mu_Del.Index = 2;
			this.mu_Del.Text = "删除";
			this.mu_Del.Click += new System.EventHandler(this.mu_Del_Click);
			// 
			// mu_App
			// 
			this.mu_App.Index = 3;
			this.mu_App.Text = "应用到各天";
			this.mu_App.Click += new System.EventHandler(this.mu_App_Click);
			// 
			// m_TV
			// 
			this.m_TV.Dock = System.Windows.Forms.DockStyle.Left;
			this.m_TV.HideSelection = false;
			this.m_TV.HotTracking = true;
			this.m_TV.ImageIndex = -1;
			this.m_TV.Location = new System.Drawing.Point(0, 48);
			this.m_TV.Name = "m_TV";
			this.m_TV.SelectedImageIndex = -1;
			this.m_TV.Size = new System.Drawing.Size(184, 453);
			this.m_TV.TabIndex = 17;
			this.m_TV.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_TV_AfterSelect);
			// 
			// splitter1
			// 
			this.splitter1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.splitter1.Location = new System.Drawing.Point(184, 48);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 453);
			this.splitter1.TabIndex = 18;
			this.splitter1.TabStop = false;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.m_lvwPlan);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.panel1.Location = new System.Drawing.Point(187, 48);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(629, 453);
			this.panel1.TabIndex = 19;
			// 
			// m_lvwPlan
			// 
			this.m_lvwPlan.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.col9,
																						this.col1,
																						this.col2,
																						this.col3,
																						this.col4,
																						this.col5,
																						this.col6,
																						this.col7,
																						this.col8});
			this.m_lvwPlan.ContextMenu = this.m_Menu;
			this.m_lvwPlan.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_lvwPlan.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lvwPlan.FullRowSelect = true;
			this.m_lvwPlan.GridLines = true;
			this.m_lvwPlan.Location = new System.Drawing.Point(0, 24);
			this.m_lvwPlan.MultiSelect = false;
			this.m_lvwPlan.Name = "m_lvwPlan";
			this.m_lvwPlan.Size = new System.Drawing.Size(629, 429);
			this.m_lvwPlan.TabIndex = 19;
			this.m_lvwPlan.View = System.Windows.Forms.View.Details;
			this.m_lvwPlan.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_lvwPlan_MouseDown);
			this.m_lvwPlan.DoubleClick += new System.EventHandler(this.m_lvwPlan_DoubleClick);
			this.m_lvwPlan.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.m_lvwPlan_ColumnClick);
			// 
			// col9
			// 
			this.col9.Text = "门诊科室";
			this.col9.Width = 110;
			// 
			// col1
			// 
			this.col1.Text = "医生工号";
			this.col1.Width = 100;
			// 
			// col2
			// 
			this.col2.Text = "姓名";
			this.col2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.col2.Width = 100;
			// 
			// col3
			// 
			this.col3.Text = "门诊类型";
			this.col3.Width = 88;
			// 
			// col4
			// 
			this.col4.Text = "坐诊时间段";
			this.col4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.col4.Width = 100;
			// 
			// col5
			// 
			this.col5.Text = "开始时间";
			this.col5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.col5.Width = 100;
			// 
			// col6
			// 
			this.col6.Text = "结束时间";
			this.col6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.col6.Width = 100;
			// 
			// col7
			// 
			this.col7.Text = "诊间";
			// 
			// col8
			// 
			this.col8.Text = "限号";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.m_tab);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(629, 24);
			this.panel2.TabIndex = 0;
			// 
			// m_tab
			// 
			this.m_tab.Controls.Add(this.tabPage1);
			this.m_tab.Controls.Add(this.tabPage2);
			this.m_tab.Controls.Add(this.tabPage3);
			this.m_tab.Controls.Add(this.tabPage4);
			this.m_tab.Controls.Add(this.tabPage5);
			this.m_tab.Controls.Add(this.tabPage6);
			this.m_tab.Controls.Add(this.tabPage7);
			this.m_tab.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_tab.ItemSize = new System.Drawing.Size(54, 19);
			this.m_tab.Location = new System.Drawing.Point(0, 0);
			this.m_tab.Name = "m_tab";
			this.m_tab.SelectedIndex = 0;
			this.m_tab.Size = new System.Drawing.Size(629, 24);
			this.m_tab.TabIndex = 16;
			this.m_tab.SelectedIndexChanged += new System.EventHandler(this.m_tab_SelectedIndexChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.Location = new System.Drawing.Point(4, 23);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(621, 0);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "星期一";
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 23);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(621, -3);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "星期二";
			this.tabPage2.Visible = false;
			// 
			// tabPage3
			// 
			this.tabPage3.Location = new System.Drawing.Point(4, 23);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(621, -3);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "星期三";
			this.tabPage3.Visible = false;
			// 
			// tabPage4
			// 
			this.tabPage4.Location = new System.Drawing.Point(4, 23);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(621, -3);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "星期四";
			this.tabPage4.Visible = false;
			// 
			// tabPage5
			// 
			this.tabPage5.Location = new System.Drawing.Point(4, 23);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Size = new System.Drawing.Size(621, -3);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "星期五";
			this.tabPage5.Visible = false;
			// 
			// tabPage6
			// 
			this.tabPage6.Location = new System.Drawing.Point(4, 23);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Size = new System.Drawing.Size(621, -3);
			this.tabPage6.TabIndex = 5;
			this.tabPage6.Text = "星期六";
			this.tabPage6.Visible = false;
			// 
			// tabPage7
			// 
			this.tabPage7.Location = new System.Drawing.Point(4, 23);
			this.tabPage7.Name = "tabPage7";
			this.tabPage7.Size = new System.Drawing.Size(621, -3);
			this.tabPage7.TabIndex = 6;
			this.tabPage7.Text = "星期日";
			this.tabPage7.Visible = false;
			// 
			// label2
			// 
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(0, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(816, 2);
			this.label2.TabIndex = 13;
			this.label2.Text = "label2";
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.m_tb);
			this.panel3.Controls.Add(this.label2);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(816, 48);
			this.panel3.TabIndex = 16;
			// 
			// m_tb
			// 
			this.m_tb.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.m_tb.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																					this.Add,
																					this.Edit,
																					this.Del,
																					this.Find,
																					this.reNew,
																					this.Re,
																					this.Esc});
			this.m_tb.ButtonSize = new System.Drawing.Size(49, 37);
			this.m_tb.DropDownArrows = true;
			this.m_tb.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_tb.Location = new System.Drawing.Point(0, 0);
			this.m_tb.Name = "m_tb";
			this.m_tb.ShowToolTips = true;
			this.m_tb.Size = new System.Drawing.Size(816, 43);
			this.m_tb.TabIndex = 14;
			this.m_tb.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.m_tb_ButtonClick);
			// 
			// Add
			// 
			this.Add.Tag = "";
			this.Add.Text = " 新增";
			this.Add.ToolTipText = "新增";
			// 
			// Edit
			// 
			this.Edit.Text = "编辑";
			this.Edit.ToolTipText = "编辑";
			// 
			// Del
			// 
			this.Del.Tag = "";
			this.Del.Text = "删除";
			this.Del.ToolTipText = "删除";
			// 
			// Find
			// 
			this.Find.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			this.Find.Text = "查找";
			this.Find.ToolTipText = "查找";
			// 
			// reNew
			// 
			this.reNew.Text = "刷新";
			this.reNew.ToolTipText = "刷新";
			// 
			// Re
			// 
			this.Re.DropDownMenu = this.m_Menu;
			this.Re.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			this.Re.Text = "维护";
			this.Re.ToolTipText = "维护";
			// 
			// Esc
			// 
			this.Esc.Text = " 关闭 ";
			this.Esc.ToolTipText = "关闭";
			// 
			// frmWeekPlan
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(816, 501);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.m_TV);
			this.Controls.Add(this.panel3);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.KeyPreview = true;
			this.Name = "frmWeekPlan";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "门诊周排班计划";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmWeekPlan_KeyDown);
			this.Load += new System.EventHandler(this.frmWeekPlan_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.m_tab.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmWeekPlan());
		}

		public override void CreateController()
		{
			this.objController=new com.digitalwave.iCare.gui.HIS.clsControlWeekPlan();
			objController.Set_GUI_Apperance(this);
		}

		private void m_tb_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch(this.m_tb.Buttons.IndexOf(e.Button))
			{
				case 0: //新增
					((clsControlWeekPlan)this.objController).m_SetItem(true);
					//					((clsControlMedicine)this.objController).m_SetItem(true);
					break;
				case 1:
					((clsControlWeekPlan)this.objController).m_SetItem(false);
					break;
				case 2://删除
					((clsControlWeekPlan)this.objController).m_lngDelPlan();
					break;
				case 3://查找
					//((clsControlMedicine)this.objController).m_lngDelMedInfo();
					break;
				case 4:
					((clsControlWeekPlan)this.objController).m_GetPlanByDepID();
					break;
				case 6: //退出
					this.Close();
					break;
     
			}
		}

		private void m_lvwPlan_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			bool IsAsc=false;//是否为升序
			if(m_lvwPlan.Sorting==SortOrder.Ascending)
				m_lvwPlan.Sorting=SortOrder.Descending;
			else
			{
				m_lvwPlan.Sorting=SortOrder.Ascending;
				IsAsc=true;
			}
			m_lvwPlan.ListViewItemSorter=new ListViewItemComparer(e.Column,IsAsc,m_lvwPlan);
			m_lvwPlan.Sort();
		}

		

		private void frmWeekPlan_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Escape)
			{
				if(MessageBox.Show("确认退出吗?","iCare",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No) 
					return;
				this.Close();
			}
		}

		private void frmWeekPlan_Load(object sender, System.EventArgs e)
		{
			//((clsControlWeekPlan)this.objController).GetDepTV();
			((clsControlWeekPlan)this.objController).fillDepartTree();
		}

		private void m_TV_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			((clsControlWeekPlan)this.objController).m_GetPlanByDepID();
		}

		private void m_lvwPlan_DoubleClick(object sender, System.EventArgs e)
		{
			((clsControlWeekPlan)this.objController).m_SetItem(false);
		}

		private void m_tab_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		   ((clsControlWeekPlan)this.objController).m_GetPlanByDepID();
		}


		private void m_lvwPlan_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(e.Button==MouseButtons.Right)
			{
				if(m_lvwPlan.Items.Count==0 || m_lvwPlan.SelectedItems.Count==0)
				{
					m_lvwPlan.ContextMenu.MenuItems[1].Enabled=false; //修改
					m_lvwPlan.ContextMenu.MenuItems[2].Enabled=false; //删除
					m_lvwPlan.ContextMenu.MenuItems[3].Enabled=false; //应用
				}
				else
				{
					m_lvwPlan.ContextMenu.MenuItems[1].Enabled=true; //修改
					m_lvwPlan.ContextMenu.MenuItems[2].Enabled=true; //删除
					m_lvwPlan.ContextMenu.MenuItems[3].Enabled=true; //应用
				}
			}
		}

		private void mu_Add_Click(object sender, System.EventArgs e)
		{
			((clsControlWeekPlan)this.objController).m_SetItem(true);
		}

		private void mu_Edit_Click(object sender, System.EventArgs e)
		{
			((clsControlWeekPlan)this.objController).m_SetItem(false);
		}

		private void mu_Del_Click(object sender, System.EventArgs e)
		{
			((clsControlWeekPlan)this.objController).m_lngDelPlan();
		}

		private void mu_App_Click(object sender, System.EventArgs e)
		{
		  ((clsControlWeekPlan)this.objController).m_lngApp();
		}

	}
}
