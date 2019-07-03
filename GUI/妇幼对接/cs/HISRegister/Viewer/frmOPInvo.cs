using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmOPInvo 的摘要说明。
	/// </summary>
	public class frmOPInvo :com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.TabPage tabWest;
		private System.Windows.Forms.TabPage tabCM;
		private System.Windows.Forms.TabPage tabTest;
		private System.Windows.Forms.TabPage tabChk;
		private System.Windows.Forms.TabPage tabOPS;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ToolBar m_tb;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolBarButton Add;
		private System.Windows.Forms.ToolBarButton AddDetail;
		private System.Windows.Forms.ToolBarButton Del;
		private System.Windows.Forms.ToolBarButton ReNew;
		private System.Windows.Forms.ToolBarButton Esc;
		internal System.Windows.Forms.TabControl m_tab;
		internal System.Windows.Forms.Timer m_timer;
		private System.Windows.Forms.ToolBarButton Save;
		internal exDataGridSour.exDataGrid dgWest;
		internal exDataGridSour.exDataGrid dgCM;
		internal exDataGridSour.exDataGrid dgChk;
		internal exDataGridSour.exDataGrid dgTest;
		internal exDataGridSour.exDataGrid dgOPS;
		internal com.digitalwave.controls.HIS_MedInPut m_InWest;
		internal com.digitalwave.controls.HIS_MedInPut m_InCM;
		internal com.digitalwave.controls.HIS_MedInPut m_InChk;
		internal com.digitalwave.controls.HIS_MedInPut m_InTest;
		internal com.digitalwave.controls.HIS_MedInPut m_InOPS;
		private System.Windows.Forms.TabPage tabOther;
		internal exDataGridSour.exDataGrid dgOther;
		internal com.digitalwave.controls.HIS_MedInPut m_InOther;
		internal com.digitalwave.controls.ctlPatientBasicInfo m_PatInfo;
		internal com.digitalwave.controls.ctlFreq m_ctlFre;
		internal com.digitalwave.controls.ctlUsageComboBox m_cboUsage;
		private System.Windows.Forms.ContextMenu m_Menu1;
		private System.Windows.Forms.ContextMenu m_Menu2;
		private System.Windows.Forms.MenuItem m_muCall;
		private System.Windows.Forms.MenuItem m_muTake;
		private System.Windows.Forms.MenuItem m_muUnDo;
		private System.Windows.Forms.MenuItem m_muRec;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		internal System.Windows.Forms.Label m_lbRecA;
		internal System.Windows.Forms.Label m_currRec;
		internal System.Windows.Forms.Label m_currRecA;
		internal System.Windows.Forms.TextBox m_Memo;
		internal exDataGridSour.exComboBox m_RecNo;
		internal System.Windows.Forms.TextBox m_Dosage;
		private System.Windows.Forms.ToolTip toolTip1;
		internal System.Windows.Forms.Label m_lbCook;
		internal System.Windows.Forms.Label m_lbDosage;
		private System.Windows.Forms.Label label7;
		internal System.Windows.Forms.Panel m_panHide;
		internal System.Windows.Forms.Label lbHide;
		internal System.Windows.Forms.StatusBar m_sb;
		internal com.digitalwave.controls.ctlCooking m_Cooking;
		private System.Windows.Forms.Label m_lbRec;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.Panel panel2;
		internal com.digitalwave.controls.ctlDepartment ctlDep;
		private exDataGridSour.exDataGrid exDataGrid1;
		private exDataGridSour.exColumn exColumn1;
		private exDataGridSour.exColumn exColumn2;
		internal System.Windows.Forms.TextBox m_txtInvoice;
		internal System.Windows.Forms.CheckBox m_chkModefyInvCode;
		private System.ComponentModel.IContainer components;

		public frmOPInvo()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			//			((clsControlOPInvo)this.objController).m_SetWaitGrid(false);
			//			((clsControlOPInvo)this.objController).m_SetWaitGrid(true);
			((clsControlOPInvo)this.objController).m_FillPatRec(null);
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
			this.components = new System.ComponentModel.Container();
			this.m_tab = new System.Windows.Forms.TabControl();
			this.tabWest = new System.Windows.Forms.TabPage();
			this.dgWest = new exDataGridSour.exDataGrid();
			this.tabCM = new System.Windows.Forms.TabPage();
			this.dgCM = new exDataGridSour.exDataGrid();
			this.tabChk = new System.Windows.Forms.TabPage();
			this.dgChk = new exDataGridSour.exDataGrid();
			this.tabTest = new System.Windows.Forms.TabPage();
			this.dgTest = new exDataGridSour.exDataGrid();
			this.tabOPS = new System.Windows.Forms.TabPage();
			this.dgOPS = new exDataGridSour.exDataGrid();
			this.tabOther = new System.Windows.Forms.TabPage();
			this.dgOther = new exDataGridSour.exDataGrid();
			this.m_Menu1 = new System.Windows.Forms.ContextMenu();
			this.m_muCall = new System.Windows.Forms.MenuItem();
			this.m_muTake = new System.Windows.Forms.MenuItem();
			this.m_Menu2 = new System.Windows.Forms.ContextMenu();
			this.m_muUnDo = new System.Windows.Forms.MenuItem();
			this.m_muRec = new System.Windows.Forms.MenuItem();
			this.Add = new System.Windows.Forms.ToolBarButton();
			this.AddDetail = new System.Windows.Forms.ToolBarButton();
			this.Del = new System.Windows.Forms.ToolBarButton();
			this.ReNew = new System.Windows.Forms.ToolBarButton();
			this.Esc = new System.Windows.Forms.ToolBarButton();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label4 = new System.Windows.Forms.Label();
			this.m_tb = new System.Windows.Forms.ToolBar();
			this.Save = new System.Windows.Forms.ToolBarButton();
			this.panel1 = new System.Windows.Forms.Panel();
			this.m_sb = new System.Windows.Forms.StatusBar();
			this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
			this.m_timer = new System.Windows.Forms.Timer(this.components);
			this.m_PatInfo = new com.digitalwave.controls.ctlPatientBasicInfo();
			this.m_panHide = new System.Windows.Forms.Panel();
			this.m_Cooking = new com.digitalwave.controls.ctlCooking();
			this.m_lbCook = new System.Windows.Forms.Label();
			this.m_Dosage = new System.Windows.Forms.TextBox();
			this.m_RecNo = new exDataGridSour.exComboBox();
			this.m_lbDosage = new System.Windows.Forms.Label();
			this.m_Memo = new System.Windows.Forms.TextBox();
			this.m_currRecA = new System.Windows.Forms.Label();
			this.m_currRec = new System.Windows.Forms.Label();
			this.m_lbRecA = new System.Windows.Forms.Label();
			this.m_lbRec = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.lbHide = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.m_InWest = new com.digitalwave.controls.HIS_MedInPut();
			this.m_InCM = new com.digitalwave.controls.HIS_MedInPut();
			this.m_InChk = new com.digitalwave.controls.HIS_MedInPut();
			this.m_InTest = new com.digitalwave.controls.HIS_MedInPut();
			this.m_InOPS = new com.digitalwave.controls.HIS_MedInPut();
			this.m_InOther = new com.digitalwave.controls.HIS_MedInPut();
			this.m_cboUsage = new com.digitalwave.controls.ctlUsageComboBox();
			this.m_ctlFre = new com.digitalwave.controls.ctlFreq();
			this.panel2 = new System.Windows.Forms.Panel();
			this.exDataGrid1 = new exDataGridSour.exDataGrid();
			this.exColumn1 = new exDataGridSour.exColumn();
			this.exColumn2 = new exDataGridSour.exColumn();
			this.ctlDep = new com.digitalwave.controls.ctlDepartment();
			this.m_txtInvoice = new System.Windows.Forms.TextBox();
			this.m_chkModefyInvCode = new System.Windows.Forms.CheckBox();
			this.m_tab.SuspendLayout();
			this.tabWest.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgWest)).BeginInit();
			this.tabCM.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgCM)).BeginInit();
			this.tabChk.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgChk)).BeginInit();
			this.tabTest.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgTest)).BeginInit();
			this.tabOPS.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgOPS)).BeginInit();
			this.tabOther.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgOther)).BeginInit();
			this.panel3.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
			this.m_panHide.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.exDataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// m_tab
			// 
			this.m_tab.Appearance = System.Windows.Forms.TabAppearance.Buttons;
			this.m_tab.Controls.Add(this.tabWest);
			this.m_tab.Controls.Add(this.tabCM);
			this.m_tab.Controls.Add(this.tabChk);
			this.m_tab.Controls.Add(this.tabTest);
			this.m_tab.Controls.Add(this.tabOPS);
			this.m_tab.Controls.Add(this.tabOther);
			this.m_tab.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_tab.Enabled = false;
			this.m_tab.Location = new System.Drawing.Point(224, 152);
			this.m_tab.Multiline = true;
			this.m_tab.Name = "m_tab";
			this.m_tab.SelectedIndex = 0;
			this.m_tab.Size = new System.Drawing.Size(612, 541);
			this.m_tab.TabIndex = 0;
			this.m_tab.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
			// 
			// tabWest
			// 
			this.tabWest.Controls.Add(this.dgWest);
			this.tabWest.Location = new System.Drawing.Point(4, 26);
			this.tabWest.Name = "tabWest";
			this.tabWest.Size = new System.Drawing.Size(604, 511);
			this.tabWest.TabIndex = 2;
			this.tabWest.Text = "① 西药处方";
			// 
			// dgWest
			// 
			this.dgWest.aFormatString = "";
			this.dgWest.aRowHeight = 27;
			this.dgWest.CaptionVisible = false;
			this.dgWest.Col = 0;
			this.dgWest.ColHeader = true;
			this.dgWest.corrDataBase = exDataGridSour.BingType.None;
			this.dgWest.DataMember = "";
			this.dgWest.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgWest.goEnter = false;
			this.dgWest.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgWest.IsList = false;
			this.dgWest.Location = new System.Drawing.Point(0, 0);
			this.dgWest.Name = "dgWest";
			this.dgWest.PreferredRowHeight = 27;
			this.dgWest.ReadOnly = true;
			this.dgWest.Row = -1;
			this.dgWest.RowHeader = true;
			this.dgWest.Rows = 0;
			this.dgWest.Size = new System.Drawing.Size(604, 511);
			this.dgWest.TabIndex = 0;
			this.dgWest.toolTip = "";
			this.dgWest.tsAlternatingBackColor = System.Drawing.Color.White;
			this.dgWest.tsGridLineColor = System.Drawing.Color.BlanchedAlmond;
			this.dgWest.KeyDowns += new exDataGridSour.KeyDownEventHandler(this.dgWest_KeyDowns);
			// 
			// tabCM
			// 
			this.tabCM.Controls.Add(this.dgCM);
			this.tabCM.Location = new System.Drawing.Point(4, 26);
			this.tabCM.Name = "tabCM";
			this.tabCM.Size = new System.Drawing.Size(604, 511);
			this.tabCM.TabIndex = 3;
			this.tabCM.Text = "② 中药处方";
			// 
			// dgCM
			// 
			this.dgCM.aFormatString = "";
			this.dgCM.aRowHeight = 27;
			this.dgCM.CaptionVisible = false;
			this.dgCM.Col = 0;
			this.dgCM.ColHeader = true;
			this.dgCM.corrDataBase = exDataGridSour.BingType.None;
			this.dgCM.DataMember = "";
			this.dgCM.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgCM.goEnter = false;
			this.dgCM.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgCM.IsList = false;
			this.dgCM.Location = new System.Drawing.Point(0, 0);
			this.dgCM.Name = "dgCM";
			this.dgCM.PreferredRowHeight = 27;
			this.dgCM.ReadOnly = true;
			this.dgCM.Row = -1;
			this.dgCM.RowHeader = true;
			this.dgCM.Rows = 0;
			this.dgCM.Size = new System.Drawing.Size(604, 511);
			this.dgCM.TabIndex = 0;
			this.dgCM.toolTip = "";
			this.dgCM.tsAlternatingBackColor = System.Drawing.Color.White;
			this.dgCM.tsGridLineColor = System.Drawing.Color.BlanchedAlmond;
			this.dgCM.KeyDowns += new exDataGridSour.KeyDownEventHandler(this.dgWest_KeyDowns);
			// 
			// tabChk
			// 
			this.tabChk.Controls.Add(this.dgChk);
			this.tabChk.Location = new System.Drawing.Point(4, 26);
			this.tabChk.Name = "tabChk";
			this.tabChk.Size = new System.Drawing.Size(604, 511);
			this.tabChk.TabIndex = 5;
			this.tabChk.Text = "③ 检验申请单";
			// 
			// dgChk
			// 
			this.dgChk.aFormatString = "";
			this.dgChk.aRowHeight = 27;
			this.dgChk.CaptionVisible = false;
			this.dgChk.Col = 0;
			this.dgChk.ColHeader = true;
			this.dgChk.corrDataBase = exDataGridSour.BingType.None;
			this.dgChk.DataMember = "";
			this.dgChk.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgChk.goEnter = false;
			this.dgChk.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgChk.IsList = false;
			this.dgChk.Location = new System.Drawing.Point(0, 0);
			this.dgChk.Name = "dgChk";
			this.dgChk.PreferredRowHeight = 27;
			this.dgChk.ReadOnly = true;
			this.dgChk.Row = -1;
			this.dgChk.RowHeader = true;
			this.dgChk.Rows = 0;
			this.dgChk.Size = new System.Drawing.Size(604, 511);
			this.dgChk.TabIndex = 0;
			this.dgChk.toolTip = "";
			this.dgChk.tsAlternatingBackColor = System.Drawing.Color.White;
			this.dgChk.tsGridLineColor = System.Drawing.Color.BlanchedAlmond;
			this.dgChk.KeyDowns += new exDataGridSour.KeyDownEventHandler(this.dgWest_KeyDowns);
			// 
			// tabTest
			// 
			this.tabTest.Controls.Add(this.dgTest);
			this.tabTest.Location = new System.Drawing.Point(4, 26);
			this.tabTest.Name = "tabTest";
			this.tabTest.Size = new System.Drawing.Size(604, 511);
			this.tabTest.TabIndex = 4;
			this.tabTest.Text = "④ 检查申请单";
			// 
			// dgTest
			// 
			this.dgTest.aFormatString = "";
			this.dgTest.aRowHeight = 27;
			this.dgTest.CaptionVisible = false;
			this.dgTest.Col = 0;
			this.dgTest.ColHeader = true;
			this.dgTest.corrDataBase = exDataGridSour.BingType.None;
			this.dgTest.DataMember = "";
			this.dgTest.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgTest.goEnter = false;
			this.dgTest.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgTest.IsList = false;
			this.dgTest.Location = new System.Drawing.Point(0, 0);
			this.dgTest.Name = "dgTest";
			this.dgTest.PreferredRowHeight = 27;
			this.dgTest.ReadOnly = true;
			this.dgTest.Row = -1;
			this.dgTest.RowHeader = true;
			this.dgTest.Rows = 0;
			this.dgTest.Size = new System.Drawing.Size(604, 511);
			this.dgTest.TabIndex = 0;
			this.dgTest.toolTip = "";
			this.dgTest.tsAlternatingBackColor = System.Drawing.Color.White;
			this.dgTest.tsGridLineColor = System.Drawing.Color.BlanchedAlmond;
			this.dgTest.KeyDowns += new exDataGridSour.KeyDownEventHandler(this.dgWest_KeyDowns);
			// 
			// tabOPS
			// 
			this.tabOPS.Controls.Add(this.dgOPS);
			this.tabOPS.Location = new System.Drawing.Point(4, 26);
			this.tabOPS.Name = "tabOPS";
			this.tabOPS.Size = new System.Drawing.Size(604, 511);
			this.tabOPS.TabIndex = 6;
			this.tabOPS.Text = "⑤ 手术/治疗申请单";
			// 
			// dgOPS
			// 
			this.dgOPS.aFormatString = "";
			this.dgOPS.aRowHeight = 27;
			this.dgOPS.CaptionVisible = false;
			this.dgOPS.Col = 0;
			this.dgOPS.ColHeader = true;
			this.dgOPS.corrDataBase = exDataGridSour.BingType.None;
			this.dgOPS.DataMember = "";
			this.dgOPS.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgOPS.goEnter = false;
			this.dgOPS.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgOPS.IsList = false;
			this.dgOPS.Location = new System.Drawing.Point(0, 0);
			this.dgOPS.Name = "dgOPS";
			this.dgOPS.PreferredRowHeight = 27;
			this.dgOPS.ReadOnly = true;
			this.dgOPS.Row = -1;
			this.dgOPS.RowHeader = true;
			this.dgOPS.Rows = 0;
			this.dgOPS.Size = new System.Drawing.Size(604, 511);
			this.dgOPS.TabIndex = 0;
			this.dgOPS.toolTip = "";
			this.dgOPS.tsAlternatingBackColor = System.Drawing.Color.White;
			this.dgOPS.tsGridLineColor = System.Drawing.Color.BlanchedAlmond;
			this.dgOPS.KeyDowns += new exDataGridSour.KeyDownEventHandler(this.dgWest_KeyDowns);
			// 
			// tabOther
			// 
			this.tabOther.Controls.Add(this.dgOther);
			this.tabOther.Location = new System.Drawing.Point(4, 26);
			this.tabOther.Name = "tabOther";
			this.tabOther.Size = new System.Drawing.Size(604, 511);
			this.tabOther.TabIndex = 8;
			this.tabOther.Text = "⑥ 其它";
			// 
			// dgOther
			// 
			this.dgOther.aFormatString = "";
			this.dgOther.aRowHeight = 27;
			this.dgOther.CaptionVisible = false;
			this.dgOther.Col = 0;
			this.dgOther.ColHeader = true;
			this.dgOther.corrDataBase = exDataGridSour.BingType.None;
			this.dgOther.DataMember = "";
			this.dgOther.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgOther.goEnter = false;
			this.dgOther.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgOther.IsList = false;
			this.dgOther.Location = new System.Drawing.Point(0, 0);
			this.dgOther.Name = "dgOther";
			this.dgOther.PreferredRowHeight = 27;
			this.dgOther.ReadOnly = true;
			this.dgOther.Row = -1;
			this.dgOther.RowHeader = true;
			this.dgOther.Rows = 0;
			this.dgOther.Size = new System.Drawing.Size(604, 511);
			this.dgOther.TabIndex = 0;
			this.dgOther.toolTip = "";
			this.dgOther.tsAlternatingBackColor = System.Drawing.Color.White;
			this.dgOther.tsGridLineColor = System.Drawing.Color.BlanchedAlmond;
			this.dgOther.KeyDowns += new exDataGridSour.KeyDownEventHandler(this.dgWest_KeyDowns);
			// 
			// m_Menu1
			// 
			this.m_Menu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.m_muCall,
																					this.m_muTake});
			// 
			// m_muCall
			// 
			this.m_muCall.Index = 0;
			this.m_muCall.Text = "叫号";
			// 
			// m_muTake
			// 
			this.m_muTake.Index = 1;
			this.m_muTake.Text = "接诊";
			this.m_muTake.Click += new System.EventHandler(this.m_muTake_Click);
			// 
			// m_Menu2
			// 
			this.m_Menu2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.m_muUnDo,
																					this.m_muRec});
			// 
			// m_muUnDo
			// 
			this.m_muUnDo.Index = 0;
			this.m_muUnDo.Text = "取消接诊";
			this.m_muUnDo.Click += new System.EventHandler(this.m_muUnDo_Click);
			// 
			// m_muRec
			// 
			this.m_muRec.Index = 1;
			this.m_muRec.Text = "开处方";
			this.m_muRec.Click += new System.EventHandler(this.m_muRec_Click);
			// 
			// Add
			// 
			this.Add.Text = "新增";
			this.Add.ToolTipText = "新增处方 F3";
			// 
			// AddDetail
			// 
			this.AddDetail.Text = "新增明细";
			this.AddDetail.ToolTipText = "新增当前处方的明细 F4";
			// 
			// Del
			// 
			this.Del.Text = "删除";
			this.Del.ToolTipText = "删除明细 F6";
			// 
			// ReNew
			// 
			this.ReNew.Text = "刷新";
			this.ReNew.ToolTipText = "刷新 F8";
			// 
			// Esc
			// 
			this.Esc.Text = " 关闭 ";
			this.Esc.ToolTipText = "关闭 Esc";
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.m_txtInvoice);
			this.panel3.Controls.Add(this.m_chkModefyInvCode);
			this.panel3.Controls.Add(this.label4);
			this.panel3.Controls.Add(this.m_tb);
			this.panel3.Controls.Add(this.ctlDep);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(1028, 48);
			this.panel3.TabIndex = 19;
			// 
			// label4
			// 
			this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label4.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.label4.Location = new System.Drawing.Point(0, 46);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(1028, 2);
			this.label4.TabIndex = 25;
			this.label4.Text = "label4";
			// 
			// m_tb
			// 
			this.m_tb.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.m_tb.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																					this.Add,
																					this.AddDetail,
																					this.Del,
																					this.Save,
																					this.ReNew,
																					this.Esc});
			this.m_tb.ButtonSize = new System.Drawing.Size(60, 37);
			this.m_tb.Dock = System.Windows.Forms.DockStyle.None;
			this.m_tb.DropDownArrows = true;
			this.m_tb.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_tb.Location = new System.Drawing.Point(0, 0);
			this.m_tb.Name = "m_tb";
			this.m_tb.ShowToolTips = true;
			this.m_tb.Size = new System.Drawing.Size(376, 43);
			this.m_tb.TabIndex = 24;
			this.m_tb.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.m_tb_ButtonClick);
			// 
			// Save
			// 
			this.Save.Text = "保存";
			this.Save.ToolTipText = "保存处方 F7";
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.m_sb);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 693);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1028, 24);
			this.panel1.TabIndex = 20;
			// 
			// m_sb
			// 
			this.m_sb.Location = new System.Drawing.Point(0, -2);
			this.m_sb.Name = "m_sb";
			this.m_sb.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																					this.statusBarPanel1,
																					this.statusBarPanel2});
			this.m_sb.ShowPanels = true;
			this.m_sb.Size = new System.Drawing.Size(1024, 22);
			this.m_sb.TabIndex = 0;
			// 
			// statusBarPanel1
			// 
			this.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.statusBarPanel1.Width = 908;
			// 
			// m_timer
			// 
			this.m_timer.Enabled = true;
			this.m_timer.Interval = 2000;
			this.m_timer.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// m_PatInfo
			// 
			this.m_PatInfo.Charge = new System.Decimal(new int[] {
																	 0,
																	 0,
																	 0,
																	 0});
			this.m_PatInfo.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_PatInfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_PatInfo.Location = new System.Drawing.Point(0, 48);
			this.m_PatInfo.Name = "m_PatInfo";
			this.m_PatInfo.Size = new System.Drawing.Size(1028, 96);
			this.m_PatInfo.TabIndex = 23;
			this.m_PatInfo.PatientChanged += new com.digitalwave.controls.TextChangeEvent(this.m_PatInfo_PatientChanged);
			// 
			// m_panHide
			// 
			this.m_panHide.Controls.Add(this.m_Cooking);
			this.m_panHide.Controls.Add(this.m_lbCook);
			this.m_panHide.Controls.Add(this.m_Dosage);
			this.m_panHide.Controls.Add(this.m_RecNo);
			this.m_panHide.Controls.Add(this.m_lbDosage);
			this.m_panHide.Controls.Add(this.m_Memo);
			this.m_panHide.Controls.Add(this.m_currRecA);
			this.m_panHide.Controls.Add(this.m_currRec);
			this.m_panHide.Controls.Add(this.m_lbRecA);
			this.m_panHide.Controls.Add(this.m_lbRec);
			this.m_panHide.Controls.Add(this.label3);
			this.m_panHide.Controls.Add(this.label2);
			this.m_panHide.Dock = System.Windows.Forms.DockStyle.Right;
			this.m_panHide.Location = new System.Drawing.Point(836, 144);
			this.m_panHide.Name = "m_panHide";
			this.m_panHide.Size = new System.Drawing.Size(192, 549);
			this.m_panHide.TabIndex = 25;
			this.m_panHide.Visible = false;
			// 
			// m_Cooking
			// 
			this.m_Cooking.CookID = "";
			this.m_Cooking.CookName = "";
			this.m_Cooking.Location = new System.Drawing.Point(64, 238);
			this.m_Cooking.Name = "m_Cooking";
			this.m_Cooking.Size = new System.Drawing.Size(104, 22);
			this.m_Cooking.TabIndex = 12;
			this.toolTip1.SetToolTip(this.m_Cooking, "中药处方的煎法");
			this.m_Cooking.Visible = false;
			// 
			// m_lbCook
			// 
			this.m_lbCook.AutoSize = true;
			this.m_lbCook.Location = new System.Drawing.Point(16, 240);
			this.m_lbCook.Name = "m_lbCook";
			this.m_lbCook.Size = new System.Drawing.Size(34, 19);
			this.m_lbCook.TabIndex = 10;
			this.m_lbCook.Text = "煎法";
			this.m_lbCook.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.m_lbCook.Visible = false;
			// 
			// m_Dosage
			// 
			this.m_Dosage.Location = new System.Drawing.Point(64, 272);
			this.m_Dosage.MaxLength = 3;
			this.m_Dosage.Name = "m_Dosage";
			this.m_Dosage.Size = new System.Drawing.Size(104, 23);
			this.m_Dosage.TabIndex = 9;
			this.m_Dosage.Text = "";
			this.toolTip1.SetToolTip(this.m_Dosage, "中药处方的剂数");
			this.m_Dosage.Visible = false;
			this.m_Dosage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_Dosage_KeyPress);
			this.m_Dosage.TextChanged += new System.EventHandler(this.m_Memo_TextChanged);
			// 
			// m_RecNo
			// 
			this.m_RecNo.Location = new System.Drawing.Point(64, 22);
			this.m_RecNo.Name = "m_RecNo";
			this.m_RecNo.Size = new System.Drawing.Size(112, 22);
			this.m_RecNo.TabIndex = 8;
			this.m_RecNo.SelectedIndexChanged += new System.EventHandler(this.m_RecNo_SelectedIndexChanged);
			// 
			// m_lbDosage
			// 
			this.m_lbDosage.AutoSize = true;
			this.m_lbDosage.Location = new System.Drawing.Point(16, 280);
			this.m_lbDosage.Name = "m_lbDosage";
			this.m_lbDosage.Size = new System.Drawing.Size(34, 19);
			this.m_lbDosage.TabIndex = 7;
			this.m_lbDosage.Text = "剂数";
			this.m_lbDosage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.m_lbDosage.Visible = false;
			// 
			// m_Memo
			// 
			this.m_Memo.Location = new System.Drawing.Point(16, 88);
			this.m_Memo.MaxLength = 200;
			this.m_Memo.Multiline = true;
			this.m_Memo.Name = "m_Memo";
			this.m_Memo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.m_Memo.Size = new System.Drawing.Size(168, 128);
			this.m_Memo.TabIndex = 6;
			this.m_Memo.Text = "";
			this.m_Memo.TextChanged += new System.EventHandler(this.m_Memo_TextChanged);
			// 
			// m_currRecA
			// 
			this.m_currRecA.AutoSize = true;
			this.m_currRecA.Location = new System.Drawing.Point(104, 384);
			this.m_currRecA.Name = "m_currRecA";
			this.m_currRecA.Size = new System.Drawing.Size(12, 19);
			this.m_currRecA.TabIndex = 5;
			this.m_currRecA.Text = "0";
			this.m_currRecA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.m_currRecA.TextChanged += new System.EventHandler(this.m_currRecA_TextChanged);
			// 
			// m_currRec
			// 
			this.m_currRec.AutoSize = true;
			this.m_currRec.Location = new System.Drawing.Point(16, 384);
			this.m_currRec.Name = "m_currRec";
			this.m_currRec.Size = new System.Drawing.Size(77, 19);
			this.m_currRec.TabIndex = 4;
			this.m_currRec.Text = "处方总额：";
			this.m_currRec.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lbRecA
			// 
			this.m_lbRecA.AutoSize = true;
			this.m_lbRecA.Location = new System.Drawing.Point(104, 336);
			this.m_lbRecA.Name = "m_lbRecA";
			this.m_lbRecA.Size = new System.Drawing.Size(12, 19);
			this.m_lbRecA.TabIndex = 3;
			this.m_lbRecA.Text = "0";
			this.m_lbRecA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lbRec
			// 
			this.m_lbRec.AutoSize = true;
			this.m_lbRec.Location = new System.Drawing.Point(16, 336);
			this.m_lbRec.Name = "m_lbRec";
			this.m_lbRec.Size = new System.Drawing.Size(77, 19);
			this.m_lbRec.TabIndex = 2;
			this.m_lbRec.Text = "处方总额：";
			this.m_lbRec.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 56);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(63, 19);
			this.label3.TabIndex = 1;
			this.label3.Text = "处方备注";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 19);
			this.label2.TabIndex = 0;
			this.label2.Text = "处方号";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbHide
			// 
			this.lbHide.Location = new System.Drawing.Point(848, 144);
			this.lbHide.Name = "lbHide";
			this.lbHide.Size = new System.Drawing.Size(23, 16);
			this.lbHide.TabIndex = 28;
			this.lbHide.Tag = "False";
			this.lbHide.Text = "<-";
			this.toolTip1.SetToolTip(this.lbHide, "隐藏主处方描述");
			this.lbHide.Visible = false;
			this.lbHide.Click += new System.EventHandler(this.lbHide_Click);
			// 
			// label7
			// 
			this.label7.Dock = System.Windows.Forms.DockStyle.Top;
			this.label7.Location = new System.Drawing.Point(0, 144);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(836, 8);
			this.label7.TabIndex = 26;
			// 
			// m_InWest
			// 
			this.m_InWest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_InWest.ControlType = com.digitalwave.controls.sControlType.OP;
			this.m_InWest.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_InWest.ItemType = com.digitalwave.controls.sItemType.West;
			this.m_InWest.Location = new System.Drawing.Point(275, 175);
			this.m_InWest.Name = "m_InWest";
			this.m_InWest.ShowCode = true;
			this.m_InWest.Size = new System.Drawing.Size(176, 23);
			this.m_InWest.TabIndex = 2;
			this.m_InWest.Visible = false;
			this.m_InWest.ReturnVal += new com.digitalwave.controls.ReturnEvent(this.m_InWest_ReturnVal);
			// 
			// m_InCM
			// 
			this.m_InCM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_InCM.ControlType = com.digitalwave.controls.sControlType.OP;
			this.m_InCM.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_InCM.ItemType = com.digitalwave.controls.sItemType.CM;
			this.m_InCM.Location = new System.Drawing.Point(275, 175);
			this.m_InCM.Name = "m_InCM";
			this.m_InCM.ShowCode = true;
			this.m_InCM.Size = new System.Drawing.Size(176, 23);
			this.m_InCM.TabIndex = 3;
			this.m_InCM.Visible = false;
			this.m_InCM.ReturnVal += new com.digitalwave.controls.ReturnEvent(this.m_InCM_ReturnVal);
			// 
			// m_InChk
			// 
			this.m_InChk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_InChk.ControlType = com.digitalwave.controls.sControlType.OP;
			this.m_InChk.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_InChk.ItemType = com.digitalwave.controls.sItemType.Chk;
			this.m_InChk.Location = new System.Drawing.Point(275, 175);
			this.m_InChk.Name = "m_InChk";
			this.m_InChk.ShowCode = true;
			this.m_InChk.Size = new System.Drawing.Size(176, 23);
			this.m_InChk.TabIndex = 3;
			this.m_InChk.Visible = false;
			this.m_InChk.ReturnVal += new com.digitalwave.controls.ReturnEvent(this.m_InChk_ReturnVal);
			// 
			// m_InTest
			// 
			this.m_InTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_InTest.ControlType = com.digitalwave.controls.sControlType.OP;
			this.m_InTest.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_InTest.ItemType = com.digitalwave.controls.sItemType.Test;
			this.m_InTest.Location = new System.Drawing.Point(275, 175);
			this.m_InTest.Name = "m_InTest";
			this.m_InTest.ShowCode = true;
			this.m_InTest.Size = new System.Drawing.Size(176, 23);
			this.m_InTest.TabIndex = 3;
			this.m_InTest.Visible = false;
			this.m_InTest.ReturnVal += new com.digitalwave.controls.ReturnEvent(this.m_InTest_ReturnVal);
			// 
			// m_InOPS
			// 
			this.m_InOPS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_InOPS.ControlType = com.digitalwave.controls.sControlType.OP;
			this.m_InOPS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_InOPS.ItemType = com.digitalwave.controls.sItemType.OPS;
			this.m_InOPS.Location = new System.Drawing.Point(275, 175);
			this.m_InOPS.Name = "m_InOPS";
			this.m_InOPS.ShowCode = true;
			this.m_InOPS.Size = new System.Drawing.Size(176, 23);
			this.m_InOPS.TabIndex = 3;
			this.m_InOPS.Visible = false;
			this.m_InOPS.ReturnVal += new com.digitalwave.controls.ReturnEvent(this.m_InOPS_ReturnVal);
			// 
			// m_InOther
			// 
			this.m_InOther.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_InOther.ControlType = com.digitalwave.controls.sControlType.OP;
			this.m_InOther.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_InOther.ItemType = com.digitalwave.controls.sItemType.Other;
			this.m_InOther.Location = new System.Drawing.Point(275, 175);
			this.m_InOther.Name = "m_InOther";
			this.m_InOther.ShowCode = true;
			this.m_InOther.Size = new System.Drawing.Size(176, 23);
			this.m_InOther.TabIndex = 4;
			this.m_InOther.Visible = false;
			this.m_InOther.ReturnVal += new com.digitalwave.controls.ReturnEvent(this.m_InOther_ReturnVal);
			// 
			// m_cboUsage
			// 
			this.m_cboUsage.Location = new System.Drawing.Point(352, 144);
			this.m_cboUsage.Name = "m_cboUsage";
			this.m_cboUsage.Size = new System.Drawing.Size(104, 22);
			this.m_cboUsage.TabIndex = 24;
			this.m_cboUsage.UsageID = "";
			this.m_cboUsage.UsageName = "";
			this.m_cboUsage.Visible = false;
			this.m_cboUsage.SelectedIndexChanged += new System.EventHandler(this.m_cboUsage_SelectedIndexChanged);
			// 
			// m_ctlFre
			// 
			this.m_ctlFre.FreqID = "";
			this.m_ctlFre.FreqName = "";
			this.m_ctlFre.Location = new System.Drawing.Point(312, 88);
			this.m_ctlFre.Name = "m_ctlFre";
			this.m_ctlFre.Size = new System.Drawing.Size(128, 22);
			this.m_ctlFre.TabIndex = 3;
			this.m_ctlFre.Visible = false;
			this.m_ctlFre.SelectedIndexChanged += new System.EventHandler(this.m_ctlFre_SelectedIndexChanged);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.exDataGrid1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel2.Location = new System.Drawing.Point(0, 152);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(224, 541);
			this.panel2.TabIndex = 29;
			// 
			// exDataGrid1
			// 
			this.exDataGrid1.aFormatString = "";
			this.exDataGrid1.aRowHeight = 0;
			this.exDataGrid1.CaptionVisible = false;
			this.exDataGrid1.Col = 0;
			this.exDataGrid1.ColHeader = true;
			this.exDataGrid1.corrDataBase = exDataGridSour.BingType.None;
			this.exDataGrid1.DataMember = "";
			this.exDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.exDataGrid1.goEnter = false;
			this.exDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.exDataGrid1.IsList = true;
			this.exDataGrid1.Location = new System.Drawing.Point(0, 0);
			this.exDataGrid1.Name = "exDataGrid1";
			this.exDataGrid1.PreferredRowHeight = 0;
			this.exDataGrid1.ReadOnly = true;
			this.exDataGrid1.Row = -1;
			this.exDataGrid1.RowHeader = false;
			this.exDataGrid1.Rows = 0;
			this.exDataGrid1.Size = new System.Drawing.Size(224, 541);
			this.exDataGrid1.TabIndex = 0;
			this.exDataGrid1.toolTip = "";
			this.exDataGrid1.tsAlternatingBackColor = System.Drawing.Color.White;
			this.exDataGrid1.tsGridLineColor = System.Drawing.Color.Silver;
			// 
			// exColumn1
			// 
			this.exColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.exColumn1.AutoSize = false;
			this.exColumn1.BackColor = System.Drawing.Color.White;
			this.exColumn1.CanEdit = true;
			this.exColumn1.ForeColor = System.Drawing.Color.Black;
			this.exColumn1.Format = "";
			this.exColumn1.FormatInfo = null;
			this.exColumn1.HeaderText = "费用类型";
			this.exColumn1.Hide = false;
			this.exColumn1.indexKey = "";
			this.exColumn1.IsNum = false;
			this.exColumn1.IsNumAndOption = false;
			this.exColumn1.MappingName = "0";
			this.exColumn1.NullText = "";
			// 
			// exColumn2
			// 
			this.exColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.exColumn2.AutoSize = false;
			this.exColumn2.BackColor = System.Drawing.Color.White;
			this.exColumn2.CanEdit = true;
			this.exColumn2.ForeColor = System.Drawing.Color.Black;
			this.exColumn2.Format = "";
			this.exColumn2.FormatInfo = null;
			this.exColumn2.HeaderText = "金额";
			this.exColumn2.Hide = false;
			this.exColumn2.indexKey = "";
			this.exColumn2.IsNum = false;
			this.exColumn2.IsNumAndOption = false;
			this.exColumn2.MappingName = "1";
			this.exColumn2.NullText = "";
			this.exColumn2.Width = 60;
			// 
			// ctlDep
			// 
			this.ctlDep.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.ctlDep.Cursor = System.Windows.Forms.Cursors.Default;
			this.ctlDep.DepartType = com.digitalwave.controls.sDepartType.All;
			this.ctlDep.DepID = "";
			this.ctlDep.DocID = "";
			this.ctlDep.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.ctlDep.Location = new System.Drawing.Point(448, 16);
			this.ctlDep.Name = "ctlDep";
			this.ctlDep.ShowType = com.digitalwave.controls.sShowType.OnlyDep;
			this.ctlDep.Size = new System.Drawing.Size(112, 23);
			this.ctlDep.TabIndex = 32;
			this.ctlDep.Visible = false;
			// 
			// m_txtInvoice
			// 
			this.m_txtInvoice.Enabled = false;
			this.m_txtInvoice.Location = new System.Drawing.Point(667, 16);
			this.m_txtInvoice.Name = "m_txtInvoice";
			this.m_txtInvoice.Size = new System.Drawing.Size(136, 23);
			this.m_txtInvoice.TabIndex = 33;
			this.m_txtInvoice.Text = "";
			// 
			// m_chkModefyInvCode
			// 
			this.m_chkModefyInvCode.Location = new System.Drawing.Point(535, 17);
			this.m_chkModefyInvCode.Name = "m_chkModefyInvCode";
			this.m_chkModefyInvCode.Size = new System.Drawing.Size(129, 24);
			this.m_chkModefyInvCode.TabIndex = 34;
			this.m_chkModefyInvCode.Text = "编辑发票号(&M)";
			this.m_chkModefyInvCode.CheckedChanged += new System.EventHandler(this.m_chkModefyInvCode_CheckedChanged);
			// 
			// frmOPInvo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(1028, 717);
			this.Controls.Add(this.m_tab);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.lbHide);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.m_panHide);
			this.Controls.Add(this.m_PatInfo);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel3);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.KeyPreview = true;
			this.Name = "frmOPInvo";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "门诊医生工作站";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmOPInvo_KeyDown);
			this.Resize += new System.EventHandler(this.frmOPInvo_Resize);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmOPInvo_KeyPress);
			this.Load += new System.EventHandler(this.frmOPInvo_Load);
			this.m_tab.ResumeLayout(false);
			this.tabWest.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgWest)).EndInit();
			this.tabCM.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgCM)).EndInit();
			this.tabChk.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgChk)).EndInit();
			this.tabTest.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgTest)).EndInit();
			this.tabOPS.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgOPS)).EndInit();
			this.tabOther.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgOther)).EndInit();
			this.panel3.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
			this.m_panHide.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.exDataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
        
		public override void CreateController()
		{
			this.objController=new com.digitalwave.iCare.gui.HIS.clsControlOPInvo();
			objController.Set_GUI_Apperance(this);
		}

		private void dgWait_DoubleClick(object sender, System.EventArgs e)
		{
//			((clsControlOPInvo)this.objController).m_TakeDiag();
		}

		private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			((clsControlOPInvo)this.objController).m_currRecindexChange(m_tab.SelectedTab.Name);
		}

		private void m_cboUsage_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			((clsControlOPInvo)this.objController).m_FillUsage(m_tab.SelectedTab.Name);
		}

		private void m_tb_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch(this.m_tb.Buttons.IndexOf(e.Button))
			{
				case 0: //新增
					((clsControlOPInvo)this.objController).m_AddRec();
					break;
				case 1: //新增明细
					((clsControlOPInvo)this.objController).m_AddRecDetail();
					break;
				case 2://删除
					((clsControlOPInvo)this.objController).m_Del();
					break;
				case 3: //保存
					((clsControlOPInvo)this.objController).m_SaveRec(this.m_tab.SelectedTab.Name);
					break; 
				case 4: //刷新
					((clsControlOPInvo)this.objController).m_FillPatRec(null);
					break;
				case 5: //退出
					this.Close();
					break;
     
			}
		}
		private void dgWest_KeyDowns(object sender, System.Windows.Forms.Keys e)
		{
			if(e==Keys.Delete)
				((clsControlOPInvo)this.objController).m_Del();
			else if(e==Keys.Enter)
			{
				((clsControlOPInvo)this.objController).SendNextCell(m_tab.SelectedTab.Name);
			}
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
//			((clsControlOPInvo)this.objController).RefreshWait(true);
		}

		private void dgTake_DoubleClick(object sender, System.EventArgs e)
		{
//			if(dgTake.Rows==0)
//				return;
//			string strID=dgTake.Get_TextMatrix(dgTake.Row,dgTake.ColIndex("RegID"));
//			((clsControlOPInvo)this.objController).m_FillPatRec(strID);
		}

		private void frmOPInvo_Load(object sender, System.EventArgs e)
		{
			this.m_InWest.LoadData();
			this.m_InCM.LoadData();
			this.m_InChk.LoadData();
			this.m_InTest.LoadData();
			this.m_InOPS.LoadData();
			this.m_InOther.LoadData();
			this.m_cboUsage.LoadData();
			this.m_ctlFre.LoadData();
			this.m_Cooking.LoadData();
			((clsControlOPInvo)this.objController).m_ReadInvFromXML();
			((clsControlOPInvo)this.objController).m_CheckInv();
		}

		private void m_InWest_ReturnVal(object sender, com.digitalwave.controls.ReturnItem ReturnItem)
		{
			((clsControlOPInvo)this.objController).m_FillInputItem(ReturnItem,dgWest);
		}
 
		private void m_InCM_ReturnVal(object sender, com.digitalwave.controls.ReturnItem ReturnItem)
		{
			((clsControlOPInvo)this.objController).m_FillInputItem(ReturnItem,dgCM);
		}

		private void m_InChk_ReturnVal(object sender, com.digitalwave.controls.ReturnItem ReturnItem)
		{
			((clsControlOPInvo)this.objController).m_FillInputItem(ReturnItem,dgChk);
		}

		private void m_InTest_ReturnVal(object sender, com.digitalwave.controls.ReturnItem ReturnItem)
		{
			((clsControlOPInvo)this.objController).m_FillInputItem(ReturnItem,dgTest);
		}

		private void m_InOPS_ReturnVal(object sender, com.digitalwave.controls.ReturnItem ReturnItem)
		{
			((clsControlOPInvo)this.objController).m_FillInputItem(ReturnItem,dgOPS);
		}

		private void m_PatInfo_PatientChanged(object sender, string RegID)
		{
			((clsControlOPInvo)this.objController).m_lngCheckReg(RegID);
		}

		private void m_InOther_ReturnVal(object sender, com.digitalwave.controls.ReturnItem ReturnItem)
		{
			((clsControlOPInvo)this.objController).m_FillInputItem(ReturnItem,dgOther);
		}

		private void m_muTake_Click(object sender, System.EventArgs e)
		{
//			((clsControlOPInvo)this.objController).m_TakeDiag();
		}

		private void m_muUnDo_Click(object sender, System.EventArgs e)
		{
			((clsControlOPInvo)this.objController).m_UndoTake();
		}

		private void m_muRec_Click(object sender, System.EventArgs e)
		{
			dgTake_DoubleClick(null,null);
		}

		private void m_RecNo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.Cursor=Cursors.WaitCursor;
			((clsControlOPInvo)this.objController).FilterRec(m_RecNo.SelectItemValue);
			this.Cursor=Cursors.Default;
		}

		private void m_Memo_TextChanged(object sender, System.EventArgs e)
		{
			((clsControlOPInvo)this.objController).m_SaveDescToVO();
		}

		private void m_Dosage_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled=!clsMain.ValNumer(e.KeyChar,null);
		}

		internal void lbHide_Click(object sender, System.EventArgs e)
		{
			if(this.m_panHide.Visible)
			{
				this.m_panHide.Hide();
				lbHide.Text="<-";
				toolTip1.SetToolTip(lbHide,"显示主处方描述");
			}
			else
			{
				this.m_panHide.Show();
				lbHide.Text="->";  
				toolTip1.SetToolTip(lbHide,"隐藏主处方描述");
			}
		}

		private void frmOPInvo_Resize(object sender, System.EventArgs e)
		{
			lbHide.Left=this.Width-lbHide.Width;
		}

		private void m_ctlFre_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			((clsControlOPInvo)this.objController).m_FillFre();
		}

		private void m_txtCureDesc_TextChanged(object sender, System.EventArgs e)
		{
//			m_txtCureDesc.Tag="Yes";
		}

		private void frmOPInvo_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled=(e.KeyChar==(char)32 || e.KeyChar=="'".ToCharArray()[0]);
		}

		private void frmOPInvo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.Alt)
			{
				switch(e.KeyCode)
				{
					case Keys.D1:
						m_tab.SelectedIndex=0;
						break;
					case Keys.D2:
						m_tab.SelectedIndex=1;
						break;
					case Keys.D3:
						m_tab.SelectedIndex=2;
						break;
					case Keys.D4:
						m_tab.SelectedIndex=3;
						break;
					case Keys.D5:
						m_tab.SelectedIndex=4;
						break;
					case Keys.D6:
						m_tab.SelectedIndex=5;
						break;
					case Keys.D7:
						m_tab.SelectedIndex=6;
						break;
					case Keys.D8:
						m_tab.SelectedIndex=7;
						break;
					case Keys.D9:
						m_tab.SelectedIndex=8;
						break;
				}
				return;
			}
			System.Windows.Forms.ToolBarButtonClickEventArgs ex;
			switch(e.KeyCode)
			{
				case Keys.F3:
					ex=new ToolBarButtonClickEventArgs(this.Add);
					m_tb_ButtonClick(null,ex);
					break;
				case Keys.F4:
					ex=new ToolBarButtonClickEventArgs(this.AddDetail);
					m_tb_ButtonClick(null,ex);
					break;
				case Keys.F8:
					ex=new ToolBarButtonClickEventArgs(this.ReNew);
					m_tb_ButtonClick(null,ex);
					break;
				case Keys.F6:
					ex=new ToolBarButtonClickEventArgs(this.Del);
					m_tb_ButtonClick(null,ex);
					break;
				case Keys.F7:
					ex=new ToolBarButtonClickEventArgs(this.Save);
					m_tb_ButtonClick(null,ex);
					break;
				case Keys.Escape:
					ex=new ToolBarButtonClickEventArgs(this.Esc);
					m_tb_ButtonClick(null,ex);
					break;
			}
		}
		private void m_currRecA_TextChanged(object sender, System.EventArgs e)
		{
			this.m_sb.Panels[0].Text=m_lbRec.Text+m_lbRecA.Text+"  "+m_currRec.Text+m_currRecA.Text;
		}

		private void m_chkModefyInvCode_CheckedChanged(object sender, System.EventArgs e)
		{
			this.m_txtInvoice.Enabled = this.m_chkModefyInvCode.Checked;
		}
	}
}
