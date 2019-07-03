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
	public class frmDayPlan :com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.ContextMenu m_Menu;
		private System.Windows.Forms.MenuItem m_muToDay;
		private System.Windows.Forms.MenuItem m_muDay;
		private System.Windows.Forms.ContextMenu mu_M;
		private System.Windows.Forms.MenuItem mu_Add;
		private System.Windows.Forms.MenuItem mu_Edit;
		private System.Windows.Forms.MenuItem mu_Del;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.ToolBar m_tb;
		private System.Windows.Forms.ToolBarButton Add;
		private System.Windows.Forms.ToolBarButton Edit;
		private System.Windows.Forms.ToolBarButton Del;
		private System.Windows.Forms.ToolBarButton Find;
		private System.Windows.Forms.ToolBarButton reNew;
		private System.Windows.Forms.ToolBarButton Re;
		private System.Windows.Forms.ToolBarButton Esc;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		internal System.Windows.Forms.TreeView m_TV;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel1;
		internal System.Windows.Forms.ListView m_lvwPlan;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label1;
		internal System.Windows.Forms.DateTimePicker m_DTP;
		private System.Windows.Forms.ColumnHeader col1;
		private System.Windows.Forms.ColumnHeader col2;
		private System.Windows.Forms.ColumnHeader col3;
		private System.Windows.Forms.ColumnHeader col4;
		private System.Windows.Forms.ColumnHeader col5;
		private System.Windows.Forms.ColumnHeader col6;
		private System.Windows.Forms.ColumnHeader col7;
		private System.Windows.Forms.ColumnHeader col8;
		private System.Windows.Forms.ColumnHeader col9;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDayPlan()
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
			this.m_muToDay = new System.Windows.Forms.MenuItem();
			this.m_muDay = new System.Windows.Forms.MenuItem();
			this.mu_M = new System.Windows.Forms.ContextMenu();
			this.mu_Add = new System.Windows.Forms.MenuItem();
			this.mu_Edit = new System.Windows.Forms.MenuItem();
			this.mu_Del = new System.Windows.Forms.MenuItem();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.m_tb = new System.Windows.Forms.ToolBar();
			this.Add = new System.Windows.Forms.ToolBarButton();
			this.Edit = new System.Windows.Forms.ToolBarButton();
			this.Del = new System.Windows.Forms.ToolBarButton();
			this.Find = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.reNew = new System.Windows.Forms.ToolBarButton();
			this.Re = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
			this.Esc = new System.Windows.Forms.ToolBarButton();
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
			this.label1 = new System.Windows.Forms.Label();
			this.m_DTP = new System.Windows.Forms.DateTimePicker();
			this.panel3.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_Menu
			// 
			this.m_Menu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				   this.m_muToDay,
																				   this.m_muDay});
			// 
			// m_muToDay
			// 
			this.m_muToDay.Index = 0;
			this.m_muToDay.Text = "当天";
			this.m_muToDay.Click += new System.EventHandler(this.m_muToDay_Click);
			// 
			// m_muDay
			// 
			this.m_muDay.Index = 1;
			this.m_muDay.Text = "指定日期";
			this.m_muDay.Click += new System.EventHandler(this.m_muDay_Click);
			// 
			// mu_M
			// 
			this.mu_M.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				 this.mu_Add,
																				 this.mu_Edit,
																				 this.mu_Del});
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
			// panel3
			// 
			this.panel3.Controls.Add(this.label2);
			this.panel3.Controls.Add(this.m_tb);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(912, 48);
			this.panel3.TabIndex = 15;
			// 
			// label2
			// 
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.label2.Location = new System.Drawing.Point(0, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(912, 2);
			this.label2.TabIndex = 13;
			this.label2.Text = "label2";
			// 
			// m_tb
			// 
			this.m_tb.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.m_tb.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																					this.Add,
																					this.Edit,
																					this.Del,
																					this.Find,
																					this.toolBarButton1,
																					this.reNew,
																					this.Re,
																					this.toolBarButton2,
																					this.Esc});
			this.m_tb.DropDownArrows = true;
			this.m_tb.Location = new System.Drawing.Point(0, 0);
			this.m_tb.Name = "m_tb";
			this.m_tb.ShowToolTips = true;
			this.m_tb.Size = new System.Drawing.Size(912, 43);
			this.m_tb.TabIndex = 12;
			this.m_tb.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.m_tb_ButtonClick);
			// 
			// Add
			// 
			this.Add.DropDownMenu = this.m_Menu;
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
			this.Find.Text = "查找";
			this.Find.ToolTipText = "查找";
			this.Find.Visible = false;
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// reNew
			// 
			this.reNew.Text = "刷新";
			this.reNew.ToolTipText = "刷新";
			// 
			// Re
			// 
			this.Re.DropDownMenu = this.m_Menu;
			this.Re.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
			this.Re.Text = "导入";
			this.Re.ToolTipText = "导入周计划";
			// 
			// toolBarButton2
			// 
			this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// Esc
			// 
			this.Esc.Text = " 关闭 ";
			this.Esc.ToolTipText = "关闭";
			// 
			// m_TV
			// 
			this.m_TV.Dock = System.Windows.Forms.DockStyle.Left;
			this.m_TV.ForeColor = System.Drawing.SystemColors.WindowText;
			this.m_TV.HideSelection = false;
			this.m_TV.HotTracking = true;
			this.m_TV.ImageIndex = -1;
			this.m_TV.Location = new System.Drawing.Point(0, 48);
			this.m_TV.Name = "m_TV";
			this.m_TV.SelectedImageIndex = -1;
			this.m_TV.Size = new System.Drawing.Size(184, 501);
			this.m_TV.TabIndex = 17;
			this.m_TV.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_TV_AfterSelect);
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(184, 48);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 501);
			this.splitter1.TabIndex = 18;
			this.splitter1.TabStop = false;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.m_lvwPlan);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(187, 48);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(725, 501);
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
			this.m_lvwPlan.ContextMenu = this.mu_M;
			this.m_lvwPlan.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_lvwPlan.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lvwPlan.FullRowSelect = true;
			this.m_lvwPlan.GridLines = true;
			this.m_lvwPlan.Location = new System.Drawing.Point(0, 32);
			this.m_lvwPlan.MultiSelect = false;
			this.m_lvwPlan.Name = "m_lvwPlan";
			this.m_lvwPlan.Size = new System.Drawing.Size(725, 469);
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
			this.col1.Text = "医生编号";
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
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.m_DTP);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(725, 32);
			this.panel2.TabIndex = 0;
			this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 21);
			this.label1.TabIndex = 1;
			this.label1.Text = "排班日期";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_DTP
			// 
			this.m_DTP.Location = new System.Drawing.Point(80, 8);
			this.m_DTP.Name = "m_DTP";
			this.m_DTP.Size = new System.Drawing.Size(120, 23);
			this.m_DTP.TabIndex = 0;
			this.m_DTP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_DTP_KeyPress);
			this.m_DTP.ValueChanged += new System.EventHandler(this.m_DTP_ValueChanged);
			// 
			// frmDayPlan
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(912, 549);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.m_TV);
			this.Controls.Add(this.panel3);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.KeyPreview = true;
			this.Name = "frmDayPlan";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "门诊日排班计划";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDayPlan_KeyDown);
			this.Load += new System.EventHandler(this.frmDayPlan_Load);
			this.panel3.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
//		[STAThread]
//		static void Main() 
//		{
//			Application.Run(new frmDayPlan());
//		}

		public override void CreateController()
		{
			this.objController=new com.digitalwave.iCare.gui.HIS.clsControlDayPlan();
			objController.Set_GUI_Apperance(this);
		}

		private void m_tb_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			
			switch(this.m_tb.Buttons.IndexOf(e.Button))
			{
				case 0: //新增
					((clsControlDayPlan)this.objController).m_SetItem(true);
//					((clsControlMedicine)this.objController).m_SetItem(true);
					break;
                case 1:
					((clsControlDayPlan)this.objController).m_SetItem(false);
					break;
                case 2://删除
					((clsControlDayPlan)this.objController).m_lngDelPlan();
					break;
				case 3://查找
					//((clsControlMedicine)this.objController).m_lngDelMedInfo();
					break;
				case 5:
                    ((clsControlDayPlan)this.objController).m_GetPlanByDepID();
					break;
				case 6:
					this.m_muToDay_Click(sender,e);
					break; 
                case 8: //退出
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

		

		private void frmDayPlan_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Escape)
			{
					if(MessageBox.Show("确认退出吗?","iCare",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
						return;
					this.Close();
			}
		}

		private void frmDayPlan_Load(object sender, System.EventArgs e)
		{
            ((clsControlDayPlan)this.objController).fillDepartTree();
			this.m_DTP.Value=DateTime.Now.Date;
		}

		private void m_TV_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			((clsControlDayPlan)this.objController).m_GetPlanByDepID();
		}

		private void m_lvwPlan_DoubleClick(object sender, System.EventArgs e)
		{
			((clsControlDayPlan)this.objController).m_SetItem(false);
		}

		private void m_DTP_ValueChanged(object sender, System.EventArgs e)
		{
 			((clsControlDayPlan)this.objController).m_GetPlanByDepID();
		}

		private void m_muToDay_Click(object sender, System.EventArgs e)
		{
			this.Cursor=Cursors.WaitCursor;
			DateTime DTP=this.m_DTP.Value;
		    clsControlCreatePlan clsPlan=new clsControlCreatePlan();
			long lngRes=clsPlan.m_lngCreatePlan(DTP,DTP);
			if(lngRes>0)
               ((clsControlDayPlan)this.objController).m_GetPlanByDepID();
			this.Cursor=Cursors.Default;
		}
		private void m_muDay_Click(object sender, System.EventArgs e)
		{
			frmCreatePlanByDate frm=new frmCreatePlanByDate();
			if(frm.ShowMe())
               ((clsControlDayPlan)this.objController).m_GetPlanByDepID();
		}

		private void m_lvwPlan_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(e.Button==MouseButtons.Right)
			{
				if(m_lvwPlan.Items.Count==0 || m_lvwPlan.SelectedItems.Count==0)
				{
					m_lvwPlan.ContextMenu.MenuItems[1].Enabled=false; //修改
					m_lvwPlan.ContextMenu.MenuItems[2].Enabled=false; //删除
				}
				else
				{
					m_lvwPlan.ContextMenu.MenuItems[1].Enabled=true; //修改
					m_lvwPlan.ContextMenu.MenuItems[2].Enabled=true; //删除
				}
			}
		}

		private void mu_Add_Click(object sender, System.EventArgs e)
		{
			((clsControlDayPlan)this.objController).m_SetItem(true);
		}

		private void mu_Edit_Click(object sender, System.EventArgs e)
		{
			((clsControlDayPlan)this.objController).m_SetItem(false);
		}

		private void mu_Del_Click(object sender, System.EventArgs e)
		{
			((clsControlDayPlan)this.objController).m_lngDelPlan();
		}

		private void panel2_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}
		int count=0;
		private void m_DTP_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar == (char)13)
			{
				SendKeys.Send("{Right}");
				count++;
				if(count>2)
				{
					SendKeys.Send("{TAB}");
					count=0;
				}
			}
		}

	}
}
