using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.iCare.Template.Client;//TemplateLib.dll(模板)
//using medicineStandard.Viewer;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmOPDoctor 的摘要说明。
	/// </summary>
	public class frmOPDoctor :com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private clsTemplateClient m_objTemplate=null;
		private System.Windows.Forms.TabPage tabWait;
		private System.Windows.Forms.TabPage tabTake;
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
		private System.Windows.Forms.TabPage tabPatHis;
		internal System.Windows.Forms.Timer m_timer;
		private System.Windows.Forms.ToolBarButton Save;
		internal exDataGridSour.exDataGrid dgWait;
		internal exDataGridSour.exDataGrid dgTake;
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
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
		internal System.Windows.Forms.TextBox m_txtDiseDesc;
		internal System.Windows.Forms.TextBox m_txtCureDesc;
		internal System.Windows.Forms.TextBox m_txtCureResult;
		internal System.Windows.Forms.StatusBar m_sb;
		internal com.digitalwave.controls.ctlCooking m_Cooking;
		private System.Windows.Forms.Label m_lbRec;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.TabPage tabCure;
		private System.Windows.Forms.GroupBox groupBox2;
		internal System.Windows.Forms.TextBox m_txtDefend;
		internal System.Windows.Forms.TextBox m_txtCureSTD;
		internal System.Windows.Forms.TextBox m_txtCurePrin;
		internal System.Windows.Forms.TextBox m_txtDiagSTD;
		internal System.Windows.Forms.TextBox m_txtDiagDesc;
		internal System.Windows.Forms.TextBox m_txtDiagPort;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label lb;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		internal com.digitalwave.controls.ctlRichTextBox txtReMark;
		internal com.digitalwave.controls.ctlRichTextBox txtTreatment;
		internal com.digitalwave.controls.ctlRichTextBox txtDiag;
		internal com.digitalwave.controls.ctlRichTextBox txtAidCheck;
		internal com.digitalwave.controls.ctlRichTextBox txtDiagHis;
		internal com.digitalwave.controls.ctlRichTextBox txtDiagCurr;
		internal com.digitalwave.controls.ctlRichTextBox txtDiagMain;
		internal com.digitalwave.controls.ctlRichTextBox txtAnaphylaxis;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.ContextMenu mnuRichTextBox;
		private System.Windows.Forms.MenuItem mnuRichTextBoxDelete;
		internal com.digitalwave.controls.ctlDepartment ctlDep;
		private PinkieControls.ButtonXP m_BtCreatTem;
		private PinkieControls.ButtonXP m_btVindicateTem;
		private System.ComponentModel.IContainer components;

		public frmOPDoctor()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
//			((clsOPDoctor)this.objController).m_SetWaitGrid(false);
//			((clsOPDoctor)this.objController).m_SetWaitGrid(true);
			((clsOPDoctor)this.objController).m_FillPatRec(null);
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			m_objTemplate=new clsTemplateClient(this,"0001","001");
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
			this.tabWait = new System.Windows.Forms.TabPage();
			this.dgWait = new exDataGridSour.exDataGrid();
			this.m_Menu1 = new System.Windows.Forms.ContextMenu();
			this.m_muCall = new System.Windows.Forms.MenuItem();
			this.m_muTake = new System.Windows.Forms.MenuItem();
			this.tabTake = new System.Windows.Forms.TabPage();
			this.dgTake = new exDataGridSour.exDataGrid();
			this.m_Menu2 = new System.Windows.Forms.ContextMenu();
			this.m_muUnDo = new System.Windows.Forms.MenuItem();
			this.m_muRec = new System.Windows.Forms.MenuItem();
			this.tabPatHis = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtAnaphylaxis = new com.digitalwave.controls.ctlRichTextBox();
			this.mnuRichTextBox = new System.Windows.Forms.ContextMenu();
			this.mnuRichTextBoxDelete = new System.Windows.Forms.MenuItem();
			this.label20 = new System.Windows.Forms.Label();
			this.txtReMark = new com.digitalwave.controls.ctlRichTextBox();
			this.txtTreatment = new com.digitalwave.controls.ctlRichTextBox();
			this.txtDiag = new com.digitalwave.controls.ctlRichTextBox();
			this.txtAidCheck = new com.digitalwave.controls.ctlRichTextBox();
			this.txtDiagHis = new com.digitalwave.controls.ctlRichTextBox();
			this.txtDiagCurr = new com.digitalwave.controls.ctlRichTextBox();
			this.txtDiagMain = new com.digitalwave.controls.ctlRichTextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.m_txtCureResult = new System.Windows.Forms.TextBox();
			this.m_txtCureDesc = new System.Windows.Forms.TextBox();
			this.m_txtDiseDesc = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.tabCure = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.m_btVindicateTem = new PinkieControls.ButtonXP();
			this.m_BtCreatTem = new PinkieControls.ButtonXP();
			this.m_txtDefend = new System.Windows.Forms.TextBox();
			this.m_txtCureSTD = new System.Windows.Forms.TextBox();
			this.m_txtCurePrin = new System.Windows.Forms.TextBox();
			this.m_txtDiagSTD = new System.Windows.Forms.TextBox();
			this.m_txtDiagDesc = new System.Windows.Forms.TextBox();
			this.m_txtDiagPort = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.lb = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
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
			this.ctlDep = new com.digitalwave.controls.ctlDepartment();
			this.m_tab.SuspendLayout();
			this.tabWait.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgWait)).BeginInit();
			this.tabTake.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgTake)).BeginInit();
			this.tabPatHis.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabCure.SuspendLayout();
			this.groupBox2.SuspendLayout();
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
			this.SuspendLayout();
			// 
			// m_tab
			// 
			this.m_tab.Appearance = System.Windows.Forms.TabAppearance.Buttons;
			this.m_tab.Controls.Add(this.tabWait);
			this.m_tab.Controls.Add(this.tabTake);
			this.m_tab.Controls.Add(this.tabPatHis);
			this.m_tab.Controls.Add(this.tabCure);
			this.m_tab.Controls.Add(this.tabWest);
			this.m_tab.Controls.Add(this.tabCM);
			this.m_tab.Controls.Add(this.tabChk);
			this.m_tab.Controls.Add(this.tabTest);
			this.m_tab.Controls.Add(this.tabOPS);
			this.m_tab.Controls.Add(this.tabOther);
			this.m_tab.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_tab.Location = new System.Drawing.Point(0, 56);
			this.m_tab.Multiline = true;
			this.m_tab.Name = "m_tab";
			this.m_tab.SelectedIndex = 0;
			this.m_tab.Size = new System.Drawing.Size(836, 637);
			this.m_tab.TabIndex = 0;
			this.m_tab.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
			// 
			// tabWait
			// 
			this.tabWait.Controls.Add(this.dgWait);
			this.tabWait.Location = new System.Drawing.Point(4, 26);
			this.tabWait.Name = "tabWait";
			this.tabWait.Size = new System.Drawing.Size(828, 607);
			this.tabWait.TabIndex = 0;
			this.tabWait.Text = "(0)候诊";
			this.tabWait.ToolTipText = "候诊对列（Alt+0）";
			// 
			// dgWait
			// 
			this.dgWait.aFormatString = "";
			this.dgWait.aRowHeight = 0;
			this.dgWait.CaptionVisible = false;
			this.dgWait.Col = 0;
			this.dgWait.ColHeader = true;
			this.dgWait.ContextMenu = this.m_Menu1;
			this.dgWait.corrDataBase = exDataGridSour.BingType.None;
			this.dgWait.DataMember = "";
			this.dgWait.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgWait.goEnter = false;
			this.dgWait.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgWait.IsList = true;
			this.dgWait.Location = new System.Drawing.Point(0, 0);
			this.dgWait.Name = "dgWait";
			this.dgWait.PreferredRowHeight = 0;
			this.dgWait.ReadOnly = true;
			this.dgWait.Row = -1;
			this.dgWait.RowHeader = true;
			this.dgWait.Rows = 0;
			this.dgWait.Size = new System.Drawing.Size(828, 607);
			this.dgWait.TabIndex = 0;
			this.dgWait.toolTip = "";
			this.dgWait.tsAlternatingBackColor = System.Drawing.Color.White;
			this.dgWait.tsGridLineColor = System.Drawing.SystemColors.Control;
			this.dgWait.DoubleClick += new System.EventHandler(this.dgWait_DoubleClick);
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
			// tabTake
			// 
			this.tabTake.Controls.Add(this.dgTake);
			this.tabTake.Location = new System.Drawing.Point(4, 26);
			this.tabTake.Name = "tabTake";
			this.tabTake.Size = new System.Drawing.Size(828, 607);
			this.tabTake.TabIndex = 1;
			this.tabTake.Text = "(1)就诊";
			this.tabTake.ToolTipText = "就诊对列（Alt+1）";
			// 
			// dgTake
			// 
			this.dgTake.aFormatString = "";
			this.dgTake.aRowHeight = 0;
			this.dgTake.CaptionVisible = false;
			this.dgTake.Col = 0;
			this.dgTake.ColHeader = true;
			this.dgTake.ContextMenu = this.m_Menu2;
			this.dgTake.corrDataBase = exDataGridSour.BingType.None;
			this.dgTake.DataMember = "";
			this.dgTake.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgTake.goEnter = false;
			this.dgTake.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgTake.IsList = true;
			this.dgTake.Location = new System.Drawing.Point(0, 0);
			this.dgTake.Name = "dgTake";
			this.dgTake.PreferredRowHeight = 0;
			this.dgTake.ReadOnly = true;
			this.dgTake.Row = -1;
			this.dgTake.RowHeader = true;
			this.dgTake.Rows = 0;
			this.dgTake.Size = new System.Drawing.Size(828, 607);
			this.dgTake.TabIndex = 0;
			this.dgTake.toolTip = "";
			this.dgTake.tsAlternatingBackColor = System.Drawing.Color.White;
			this.dgTake.tsGridLineColor = System.Drawing.SystemColors.Control;
			this.dgTake.DoubleClick += new System.EventHandler(this.dgTake_DoubleClick);
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
			// tabPatHis
			// 
			this.tabPatHis.AutoScroll = true;
			this.tabPatHis.Controls.Add(this.groupBox1);
			this.tabPatHis.Location = new System.Drawing.Point(4, 26);
			this.tabPatHis.Name = "tabPatHis";
			this.tabPatHis.Size = new System.Drawing.Size(828, 607);
			this.tabPatHis.TabIndex = 7;
			this.tabPatHis.Text = "(2)病历";
			this.tabPatHis.ToolTipText = "病历（Alt+2）";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.m_txtDiseDesc);
			this.groupBox1.Controls.Add(this.m_txtCureDesc);
			this.groupBox1.Controls.Add(this.txtAnaphylaxis);
			this.groupBox1.Controls.Add(this.label20);
			this.groupBox1.Controls.Add(this.txtReMark);
			this.groupBox1.Controls.Add(this.txtTreatment);
			this.groupBox1.Controls.Add(this.txtDiag);
			this.groupBox1.Controls.Add(this.txtAidCheck);
			this.groupBox1.Controls.Add(this.txtDiagHis);
			this.groupBox1.Controls.Add(this.txtDiagCurr);
			this.groupBox1.Controls.Add(this.txtDiagMain);
			this.groupBox1.Controls.Add(this.label19);
			this.groupBox1.Controls.Add(this.label18);
			this.groupBox1.Controls.Add(this.label17);
			this.groupBox1.Controls.Add(this.label16);
			this.groupBox1.Controls.Add(this.label15);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.m_txtCureResult);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Location = new System.Drawing.Point(8, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(808, 504);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "病历";
			// 
			// txtAnaphylaxis
			// 
			this.txtAnaphylaxis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtAnaphylaxis.ContextMenu = this.mnuRichTextBox;
			this.txtAnaphylaxis.Location = new System.Drawing.Point(104, 306);
			this.txtAnaphylaxis.m_BlnIgnoreUserInfo = true;
			this.txtAnaphylaxis.m_BlnPartControl = false;
			this.txtAnaphylaxis.m_BlnReadOnly = false;
			this.txtAnaphylaxis.m_BlnUnderLineDST = false;
			this.txtAnaphylaxis.m_ClrDST = System.Drawing.Color.Red;
			this.txtAnaphylaxis.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.txtAnaphylaxis.m_IntCanModifyTime = 6;
			this.txtAnaphylaxis.m_IntPartControlLength = 0;
			this.txtAnaphylaxis.m_IntPartControlStartIndex = 0;
			this.txtAnaphylaxis.m_StrUserID = "";
			this.txtAnaphylaxis.m_StrUserName = "";
			this.txtAnaphylaxis.Name = "txtAnaphylaxis";
			this.txtAnaphylaxis.Size = new System.Drawing.Size(688, 40);
			this.txtAnaphylaxis.TabIndex = 21;
			this.txtAnaphylaxis.Text = "";
			this.txtAnaphylaxis.TextChanged += new System.EventHandler(this.m_txtCureDesc_TextChanged);
			// 
			// mnuRichTextBox
			// 
			this.mnuRichTextBox.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						   this.mnuRichTextBoxDelete});
			// 
			// mnuRichTextBoxDelete
			// 
			this.mnuRichTextBoxDelete.Index = 0;
			this.mnuRichTextBoxDelete.Text = "删除(&D)";
			this.mnuRichTextBoxDelete.Click += new System.EventHandler(this.mnuRichTextBoxDelete_Click);
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(32, 312);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(48, 19);
			this.label20.TabIndex = 20;
			this.label20.Text = "过敏源";
			this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtReMark
			// 
			this.txtReMark.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtReMark.ContextMenu = this.mnuRichTextBox;
			this.txtReMark.Location = new System.Drawing.Point(104, 418);
			this.txtReMark.m_BlnIgnoreUserInfo = true;
			this.txtReMark.m_BlnPartControl = false;
			this.txtReMark.m_BlnReadOnly = false;
			this.txtReMark.m_BlnUnderLineDST = false;
			this.txtReMark.m_ClrDST = System.Drawing.Color.Red;
			this.txtReMark.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.txtReMark.m_IntCanModifyTime = 6;
			this.txtReMark.m_IntPartControlLength = 0;
			this.txtReMark.m_IntPartControlStartIndex = 0;
			this.txtReMark.m_StrUserID = "";
			this.txtReMark.m_StrUserName = "";
			this.txtReMark.Name = "txtReMark";
			this.txtReMark.Size = new System.Drawing.Size(688, 40);
			this.txtReMark.TabIndex = 19;
			this.txtReMark.Text = "";
			this.txtReMark.TextChanged += new System.EventHandler(this.m_txtCureDesc_TextChanged);
			// 
			// txtTreatment
			// 
			this.txtTreatment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtTreatment.ContextMenu = this.mnuRichTextBox;
			this.txtTreatment.Location = new System.Drawing.Point(104, 362);
			this.txtTreatment.m_BlnIgnoreUserInfo = true;
			this.txtTreatment.m_BlnPartControl = false;
			this.txtTreatment.m_BlnReadOnly = false;
			this.txtTreatment.m_BlnUnderLineDST = false;
			this.txtTreatment.m_ClrDST = System.Drawing.Color.Red;
			this.txtTreatment.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.txtTreatment.m_IntCanModifyTime = 6;
			this.txtTreatment.m_IntPartControlLength = 0;
			this.txtTreatment.m_IntPartControlStartIndex = 0;
			this.txtTreatment.m_StrUserID = "";
			this.txtTreatment.m_StrUserName = "";
			this.txtTreatment.Name = "txtTreatment";
			this.txtTreatment.Size = new System.Drawing.Size(688, 40);
			this.txtTreatment.TabIndex = 18;
			this.txtTreatment.Text = "";
			this.txtTreatment.TextChanged += new System.EventHandler(this.m_txtCureDesc_TextChanged);
			// 
			// txtDiag
			// 
			this.txtDiag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtDiag.ContextMenu = this.mnuRichTextBox;
			this.txtDiag.Location = new System.Drawing.Point(104, 250);
			this.txtDiag.m_BlnIgnoreUserInfo = true;
			this.txtDiag.m_BlnPartControl = false;
			this.txtDiag.m_BlnReadOnly = false;
			this.txtDiag.m_BlnUnderLineDST = false;
			this.txtDiag.m_ClrDST = System.Drawing.Color.Red;
			this.txtDiag.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.txtDiag.m_IntCanModifyTime = 6;
			this.txtDiag.m_IntPartControlLength = 0;
			this.txtDiag.m_IntPartControlStartIndex = 0;
			this.txtDiag.m_StrUserID = "";
			this.txtDiag.m_StrUserName = "";
			this.txtDiag.Name = "txtDiag";
			this.txtDiag.Size = new System.Drawing.Size(688, 40);
			this.txtDiag.TabIndex = 17;
			this.txtDiag.Text = "";
			this.txtDiag.TextChanged += new System.EventHandler(this.m_txtCureDesc_TextChanged);
			// 
			// txtAidCheck
			// 
			this.txtAidCheck.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtAidCheck.ContextMenu = this.mnuRichTextBox;
			this.txtAidCheck.Location = new System.Drawing.Point(104, 194);
			this.txtAidCheck.m_BlnIgnoreUserInfo = true;
			this.txtAidCheck.m_BlnPartControl = false;
			this.txtAidCheck.m_BlnReadOnly = false;
			this.txtAidCheck.m_BlnUnderLineDST = false;
			this.txtAidCheck.m_ClrDST = System.Drawing.Color.Red;
			this.txtAidCheck.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.txtAidCheck.m_IntCanModifyTime = 6;
			this.txtAidCheck.m_IntPartControlLength = 0;
			this.txtAidCheck.m_IntPartControlStartIndex = 0;
			this.txtAidCheck.m_StrUserID = "";
			this.txtAidCheck.m_StrUserName = "";
			this.txtAidCheck.Name = "txtAidCheck";
			this.txtAidCheck.Size = new System.Drawing.Size(688, 40);
			this.txtAidCheck.TabIndex = 16;
			this.txtAidCheck.Text = "";
			this.txtAidCheck.TextChanged += new System.EventHandler(this.m_txtCureDesc_TextChanged);
			// 
			// txtDiagHis
			// 
			this.txtDiagHis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtDiagHis.ContextMenu = this.mnuRichTextBox;
			this.txtDiagHis.Location = new System.Drawing.Point(104, 138);
			this.txtDiagHis.m_BlnIgnoreUserInfo = true;
			this.txtDiagHis.m_BlnPartControl = false;
			this.txtDiagHis.m_BlnReadOnly = false;
			this.txtDiagHis.m_BlnUnderLineDST = false;
			this.txtDiagHis.m_ClrDST = System.Drawing.Color.Red;
			this.txtDiagHis.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.txtDiagHis.m_IntCanModifyTime = 6;
			this.txtDiagHis.m_IntPartControlLength = 0;
			this.txtDiagHis.m_IntPartControlStartIndex = 0;
			this.txtDiagHis.m_StrUserID = "";
			this.txtDiagHis.m_StrUserName = "";
			this.txtDiagHis.Name = "txtDiagHis";
			this.txtDiagHis.Size = new System.Drawing.Size(688, 40);
			this.txtDiagHis.TabIndex = 15;
			this.txtDiagHis.Text = "";
			this.txtDiagHis.TextChanged += new System.EventHandler(this.m_txtCureDesc_TextChanged);
			// 
			// txtDiagCurr
			// 
			this.txtDiagCurr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtDiagCurr.ContextMenu = this.mnuRichTextBox;
			this.txtDiagCurr.Location = new System.Drawing.Point(104, 82);
			this.txtDiagCurr.m_BlnIgnoreUserInfo = true;
			this.txtDiagCurr.m_BlnPartControl = false;
			this.txtDiagCurr.m_BlnReadOnly = false;
			this.txtDiagCurr.m_BlnUnderLineDST = false;
			this.txtDiagCurr.m_ClrDST = System.Drawing.Color.Red;
			this.txtDiagCurr.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.txtDiagCurr.m_IntCanModifyTime = 6;
			this.txtDiagCurr.m_IntPartControlLength = 0;
			this.txtDiagCurr.m_IntPartControlStartIndex = 0;
			this.txtDiagCurr.m_StrUserID = "";
			this.txtDiagCurr.m_StrUserName = "";
			this.txtDiagCurr.Name = "txtDiagCurr";
			this.txtDiagCurr.Size = new System.Drawing.Size(688, 40);
			this.txtDiagCurr.TabIndex = 14;
			this.txtDiagCurr.Text = "";
			this.txtDiagCurr.TextChanged += new System.EventHandler(this.m_txtCureDesc_TextChanged);
			// 
			// txtDiagMain
			// 
			this.txtDiagMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtDiagMain.ContextMenu = this.mnuRichTextBox;
			this.txtDiagMain.Location = new System.Drawing.Point(104, 26);
			this.txtDiagMain.m_BlnIgnoreUserInfo = true;
			this.txtDiagMain.m_BlnPartControl = false;
			this.txtDiagMain.m_BlnReadOnly = false;
			this.txtDiagMain.m_BlnUnderLineDST = false;
			this.txtDiagMain.m_ClrDST = System.Drawing.Color.Red;
			this.txtDiagMain.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.txtDiagMain.m_IntCanModifyTime = 6;
			this.txtDiagMain.m_IntPartControlLength = 0;
			this.txtDiagMain.m_IntPartControlStartIndex = 0;
			this.txtDiagMain.m_StrUserID = "";
			this.txtDiagMain.m_StrUserName = "";
			this.txtDiagMain.Name = "txtDiagMain";
			this.txtDiagMain.Size = new System.Drawing.Size(688, 40);
			this.txtDiagMain.TabIndex = 13;
			this.txtDiagMain.Text = "";
			this.txtDiagMain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDiagMain_KeyDown);
			this.txtDiagMain.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiagMain_KeyPress);
			this.txtDiagMain.TextChanged += new System.EventHandler(this.m_txtCureDesc_TextChanged);
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(32, 424);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(34, 19);
			this.label19.TabIndex = 12;
			this.label19.Text = "备注";
			this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(32, 368);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(34, 19);
			this.label18.TabIndex = 11;
			this.label18.Text = "处置";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(32, 256);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(34, 19);
			this.label17.TabIndex = 10;
			this.label17.Text = "诊断";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(32, 200);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(63, 19);
			this.label16.TabIndex = 9;
			this.label16.Text = "辅助检查";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(32, 144);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(48, 19);
			this.label15.TabIndex = 8;
			this.label15.Text = "既往史";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(32, 88);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(48, 19);
			this.label10.TabIndex = 7;
			this.label10.Text = "现病史";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(32, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 19);
			this.label1.TabIndex = 6;
			this.label1.Text = "主述";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_txtCureResult
			// 
			this.m_txtCureResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtCureResult.Location = new System.Drawing.Point(416, 138);
			this.m_txtCureResult.Multiline = true;
			this.m_txtCureResult.Name = "m_txtCureResult";
			this.m_txtCureResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.m_txtCureResult.Size = new System.Drawing.Size(688, 40);
			this.m_txtCureResult.TabIndex = 5;
			this.m_txtCureResult.Text = "";
			this.m_txtCureResult.Visible = false;
			this.m_txtCureResult.TextChanged += new System.EventHandler(this.m_txtCureDesc_TextChanged);
			// 
			// m_txtCureDesc
			// 
			this.m_txtCureDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtCureDesc.Location = new System.Drawing.Point(416, 91);
			this.m_txtCureDesc.Multiline = true;
			this.m_txtCureDesc.Name = "m_txtCureDesc";
			this.m_txtCureDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.m_txtCureDesc.Size = new System.Drawing.Size(688, 40);
			this.m_txtCureDesc.TabIndex = 4;
			this.m_txtCureDesc.Text = "";
			this.m_txtCureDesc.Visible = false;
			this.m_txtCureDesc.TextChanged += new System.EventHandler(this.m_txtCureDesc_TextChanged);
			// 
			// m_txtDiseDesc
			// 
			this.m_txtDiseDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtDiseDesc.Location = new System.Drawing.Point(416, 44);
			this.m_txtDiseDesc.Multiline = true;
			this.m_txtDiseDesc.Name = "m_txtDiseDesc";
			this.m_txtDiseDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.m_txtDiseDesc.Size = new System.Drawing.Size(688, 40);
			this.m_txtDiseDesc.TabIndex = 3;
			this.m_txtDiseDesc.Text = "";
			this.m_txtDiseDesc.Visible = false;
			this.m_txtDiseDesc.TextChanged += new System.EventHandler(this.m_txtCureDesc_TextChanged);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(328, 129);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(92, 19);
			this.label8.TabIndex = 2;
			this.label8.Text = "治疗结果描述";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label8.Visible = false;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(328, 82);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(63, 19);
			this.label6.TabIndex = 1;
			this.label6.Text = "治疗描述";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label6.Visible = false;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(328, 35);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(63, 19);
			this.label5.TabIndex = 0;
			this.label5.Text = "疾病描述";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label5.Visible = false;
			// 
			// tabCure
			// 
			this.tabCure.Controls.Add(this.groupBox2);
			this.tabCure.Location = new System.Drawing.Point(4, 26);
			this.tabCure.Name = "tabCure";
			this.tabCure.Size = new System.Drawing.Size(828, 607);
			this.tabCure.TabIndex = 9;
			this.tabCure.Text = "(3)诊断";
			this.tabCure.ToolTipText = "诊断描述（Alt+3）";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.m_btVindicateTem);
			this.groupBox2.Controls.Add(this.m_BtCreatTem);
			this.groupBox2.Controls.Add(this.m_txtDefend);
			this.groupBox2.Controls.Add(this.m_txtCureSTD);
			this.groupBox2.Controls.Add(this.m_txtCurePrin);
			this.groupBox2.Controls.Add(this.m_txtDiagSTD);
			this.groupBox2.Controls.Add(this.m_txtDiagDesc);
			this.groupBox2.Controls.Add(this.m_txtDiagPort);
			this.groupBox2.Controls.Add(this.label12);
			this.groupBox2.Controls.Add(this.label13);
			this.groupBox2.Controls.Add(this.label14);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.lb);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Location = new System.Drawing.Point(8, 8);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(808, 496);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "治疗记录";
			// 
			// m_btVindicateTem
			// 
			this.m_btVindicateTem.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btVindicateTem.DefaultScheme = true;
			this.m_btVindicateTem.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btVindicateTem.Hint = "";
			this.m_btVindicateTem.Location = new System.Drawing.Point(272, 432);
			this.m_btVindicateTem.Name = "m_btVindicateTem";
			this.m_btVindicateTem.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btVindicateTem.Size = new System.Drawing.Size(112, 32);
			this.m_btVindicateTem.TabIndex = 16;
			this.m_btVindicateTem.Text = "维护模板";
			this.m_btVindicateTem.Click += new System.EventHandler(this.m_btVindicateTem_Click);
			// 
			// m_BtCreatTem
			// 
			this.m_BtCreatTem.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_BtCreatTem.DefaultScheme = true;
			this.m_BtCreatTem.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_BtCreatTem.Hint = "";
			this.m_BtCreatTem.Location = new System.Drawing.Point(128, 432);
			this.m_BtCreatTem.Name = "m_BtCreatTem";
			this.m_BtCreatTem.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_BtCreatTem.Size = new System.Drawing.Size(112, 32);
			this.m_BtCreatTem.TabIndex = 15;
			this.m_BtCreatTem.Text = "生成模板";
			this.m_BtCreatTem.Click += new System.EventHandler(this.m_BtCreatTem_Click);
			// 
			// m_txtDefend
			// 
			this.m_txtDefend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtDefend.Location = new System.Drawing.Point(96, 364);
			this.m_txtDefend.Multiline = true;
			this.m_txtDefend.Name = "m_txtDefend";
			this.m_txtDefend.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.m_txtDefend.Size = new System.Drawing.Size(696, 52);
			this.m_txtDefend.TabIndex = 14;
			this.m_txtDefend.Text = "";
			// 
			// m_txtCureSTD
			// 
			this.m_txtCureSTD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtCureSTD.Location = new System.Drawing.Point(96, 300);
			this.m_txtCureSTD.Multiline = true;
			this.m_txtCureSTD.Name = "m_txtCureSTD";
			this.m_txtCureSTD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.m_txtCureSTD.Size = new System.Drawing.Size(696, 52);
			this.m_txtCureSTD.TabIndex = 13;
			this.m_txtCureSTD.Text = "";
			// 
			// m_txtCurePrin
			// 
			this.m_txtCurePrin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtCurePrin.Location = new System.Drawing.Point(96, 236);
			this.m_txtCurePrin.Multiline = true;
			this.m_txtCurePrin.Name = "m_txtCurePrin";
			this.m_txtCurePrin.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.m_txtCurePrin.Size = new System.Drawing.Size(696, 52);
			this.m_txtCurePrin.TabIndex = 12;
			this.m_txtCurePrin.Text = "";
			// 
			// m_txtDiagSTD
			// 
			this.m_txtDiagSTD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtDiagSTD.Location = new System.Drawing.Point(96, 172);
			this.m_txtDiagSTD.Multiline = true;
			this.m_txtDiagSTD.Name = "m_txtDiagSTD";
			this.m_txtDiagSTD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.m_txtDiagSTD.Size = new System.Drawing.Size(696, 52);
			this.m_txtDiagSTD.TabIndex = 11;
			this.m_txtDiagSTD.Text = "";
			// 
			// m_txtDiagDesc
			// 
			this.m_txtDiagDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtDiagDesc.Location = new System.Drawing.Point(96, 108);
			this.m_txtDiagDesc.Multiline = true;
			this.m_txtDiagDesc.Name = "m_txtDiagDesc";
			this.m_txtDiagDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.m_txtDiagDesc.Size = new System.Drawing.Size(696, 52);
			this.m_txtDiagDesc.TabIndex = 10;
			this.m_txtDiagDesc.Text = "";
			// 
			// m_txtDiagPort
			// 
			this.m_txtDiagPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtDiagPort.Location = new System.Drawing.Point(96, 44);
			this.m_txtDiagPort.Multiline = true;
			this.m_txtDiagPort.Name = "m_txtDiagPort";
			this.m_txtDiagPort.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.m_txtDiagPort.Size = new System.Drawing.Size(696, 52);
			this.m_txtDiagPort.TabIndex = 9;
			this.m_txtDiagPort.Text = "";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(17, 360);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(34, 19);
			this.label12.TabIndex = 8;
			this.label12.Text = "预防";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(17, 296);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(63, 19);
			this.label13.TabIndex = 7;
			this.label13.Text = "治愈标准";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(17, 232);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(63, 19);
			this.label14.TabIndex = 6;
			this.label14.Text = "治疗原则";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(17, 168);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(63, 19);
			this.label9.TabIndex = 5;
			this.label9.Text = "确诊标准";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lb
			// 
			this.lb.AutoSize = true;
			this.lb.Location = new System.Drawing.Point(17, 104);
			this.lb.Name = "lb";
			this.lb.Size = new System.Drawing.Size(63, 19);
			this.lb.TabIndex = 4;
			this.lb.Text = "诊断描述";
			this.lb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(17, 48);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(63, 19);
			this.label11.TabIndex = 3;
			this.label11.Text = "诊断重点";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tabWest
			// 
			this.tabWest.Controls.Add(this.dgWest);
			this.tabWest.Location = new System.Drawing.Point(4, 26);
			this.tabWest.Name = "tabWest";
			this.tabWest.Size = new System.Drawing.Size(828, 607);
			this.tabWest.TabIndex = 2;
			this.tabWest.Text = "(4)西药";
			this.tabWest.ToolTipText = "西药处方（Alt+4）";
			// 
			// dgWest
			// 
			this.dgWest.aFormatString = "";
			this.dgWest.AllowSorting = false;
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
			this.dgWest.Size = new System.Drawing.Size(828, 607);
			this.dgWest.TabIndex = 0;
			this.dgWest.toolTip = "";
			this.dgWest.tsAlternatingBackColor = System.Drawing.Color.White;
			this.dgWest.tsGridLineColor = System.Drawing.SystemColors.Control;
			this.dgWest.KeyDowns += new exDataGridSour.KeyDownEventHandler(this.dgWest_KeyDowns);
			// 
			// tabCM
			// 
			this.tabCM.Controls.Add(this.dgCM);
			this.tabCM.Location = new System.Drawing.Point(4, 26);
			this.tabCM.Name = "tabCM";
			this.tabCM.Size = new System.Drawing.Size(828, 607);
			this.tabCM.TabIndex = 3;
			this.tabCM.Text = "(5)中药";
			this.tabCM.ToolTipText = "中药处方（Alt+5）";
			// 
			// dgCM
			// 
			this.dgCM.aFormatString = "";
			this.dgCM.AllowSorting = false;
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
			this.dgCM.Size = new System.Drawing.Size(828, 607);
			this.dgCM.TabIndex = 0;
			this.dgCM.toolTip = "";
			this.dgCM.tsAlternatingBackColor = System.Drawing.Color.White;
			this.dgCM.tsGridLineColor = System.Drawing.SystemColors.Control;
			this.dgCM.KeyDowns += new exDataGridSour.KeyDownEventHandler(this.dgWest_KeyDowns);
			// 
			// tabChk
			// 
			this.tabChk.Controls.Add(this.dgChk);
			this.tabChk.Location = new System.Drawing.Point(4, 26);
			this.tabChk.Name = "tabChk";
			this.tabChk.Size = new System.Drawing.Size(828, 607);
			this.tabChk.TabIndex = 5;
			this.tabChk.Text = "(6)检验";
			this.tabChk.ToolTipText = "检验申请单（Alt+6）";
			// 
			// dgChk
			// 
			this.dgChk.aFormatString = "";
			this.dgChk.AllowSorting = false;
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
			this.dgChk.Size = new System.Drawing.Size(828, 607);
			this.dgChk.TabIndex = 0;
			this.dgChk.toolTip = "";
			this.dgChk.tsAlternatingBackColor = System.Drawing.Color.White;
			this.dgChk.tsGridLineColor = System.Drawing.SystemColors.Control;
			this.dgChk.KeyDowns += new exDataGridSour.KeyDownEventHandler(this.dgWest_KeyDowns);
			// 
			// tabTest
			// 
			this.tabTest.Controls.Add(this.dgTest);
			this.tabTest.Location = new System.Drawing.Point(4, 26);
			this.tabTest.Name = "tabTest";
			this.tabTest.Size = new System.Drawing.Size(828, 607);
			this.tabTest.TabIndex = 4;
			this.tabTest.Text = "(7)检查";
			this.tabTest.ToolTipText = "检查申请单（Alt+7）";
			// 
			// dgTest
			// 
			this.dgTest.aFormatString = "";
			this.dgTest.AllowSorting = false;
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
			this.dgTest.Size = new System.Drawing.Size(828, 607);
			this.dgTest.TabIndex = 0;
			this.dgTest.toolTip = "";
			this.dgTest.tsAlternatingBackColor = System.Drawing.Color.White;
			this.dgTest.tsGridLineColor = System.Drawing.SystemColors.Control;
			this.dgTest.KeyDowns += new exDataGridSour.KeyDownEventHandler(this.dgWest_KeyDowns);
			// 
			// tabOPS
			// 
			this.tabOPS.Controls.Add(this.dgOPS);
			this.tabOPS.Location = new System.Drawing.Point(4, 26);
			this.tabOPS.Name = "tabOPS";
			this.tabOPS.Size = new System.Drawing.Size(828, 607);
			this.tabOPS.TabIndex = 6;
			this.tabOPS.Text = "(8)手术/治疗";
			this.tabOPS.ToolTipText = "手术/治疗申请单（Alt+8）";
			// 
			// dgOPS
			// 
			this.dgOPS.aFormatString = "";
			this.dgOPS.AllowSorting = false;
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
			this.dgOPS.Size = new System.Drawing.Size(828, 607);
			this.dgOPS.TabIndex = 0;
			this.dgOPS.toolTip = "";
			this.dgOPS.tsAlternatingBackColor = System.Drawing.Color.White;
			this.dgOPS.tsGridLineColor = System.Drawing.SystemColors.Control;
			this.dgOPS.KeyDowns += new exDataGridSour.KeyDownEventHandler(this.dgWest_KeyDowns);
			// 
			// tabOther
			// 
			this.tabOther.Controls.Add(this.dgOther);
			this.tabOther.Location = new System.Drawing.Point(4, 26);
			this.tabOther.Name = "tabOther";
			this.tabOther.Size = new System.Drawing.Size(828, 607);
			this.tabOther.TabIndex = 8;
			this.tabOther.Text = "(9)其它";
			this.tabOther.ToolTipText = "其它（Alt+9）";
			// 
			// dgOther
			// 
			this.dgOther.aFormatString = "";
			this.dgOther.AllowSorting = false;
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
			this.dgOther.Size = new System.Drawing.Size(828, 607);
			this.dgOther.TabIndex = 0;
			this.dgOther.toolTip = "";
			this.dgOther.tsAlternatingBackColor = System.Drawing.Color.White;
			this.dgOther.tsGridLineColor = System.Drawing.SystemColors.Control;
			this.dgOther.KeyDowns += new exDataGridSour.KeyDownEventHandler(this.dgWest_KeyDowns);
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
			this.panel3.Controls.Add(this.label4);
			this.panel3.Controls.Add(this.m_tb);
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
			this.m_tb.Size = new System.Drawing.Size(872, 43);
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
			this.m_panHide.Location = new System.Drawing.Point(836, 48);
			this.m_panHide.Name = "m_panHide";
			this.m_panHide.Size = new System.Drawing.Size(192, 645);
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
			this.m_Cooking.SelectedValueChanged += new System.EventHandler(this.m_Memo_TextChanged);
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
			this.label7.Location = new System.Drawing.Point(0, 48);
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
			// ctlDep
			// 
			this.ctlDep.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.ctlDep.Cursor = System.Windows.Forms.Cursors.Default;
			this.ctlDep.DepartType = com.digitalwave.controls.sDepartType.All;
			this.ctlDep.DepID = "";
			this.ctlDep.DocID = "";
			this.ctlDep.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.ctlDep.Location = new System.Drawing.Point(584, 128);
			this.ctlDep.Name = "ctlDep";
			this.ctlDep.ShowType = com.digitalwave.controls.sShowType.OnlyDep;
			this.ctlDep.Size = new System.Drawing.Size(96, 23);
			this.ctlDep.TabIndex = 29;
			this.ctlDep.Visible = false;
			this.ctlDep.ReturnVal += new com.digitalwave.controls.ReturnDepEvent(this.ctlDep_ReturnVal);
			// 
			// frmOPDoctor
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(1028, 717);
			this.Controls.Add(this.ctlDep);
			this.Controls.Add(this.lbHide);
			this.Controls.Add(this.m_tab);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.m_panHide);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel3);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.KeyPreview = true;
			this.Name = "frmOPDoctor";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "门诊医生工作站";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmOPDoctor_KeyDown);
			this.Resize += new System.EventHandler(this.frmOPDoctor_Resize);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmOPDoctor_KeyPress);
			this.Load += new System.EventHandler(this.frmOPDoctor_Load);
			this.m_tab.ResumeLayout(false);
			this.tabWait.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgWait)).EndInit();
			this.tabTake.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgTake)).EndInit();
			this.tabPatHis.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tabCure.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
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
			this.ResumeLayout(false);

		}
		#endregion
        
		public override void CreateController()
		{
			this.objController=new com.digitalwave.iCare.gui.HIS.clsOPDoctor();
			objController.Set_GUI_Apperance(this);
		}

		private void dgWait_DoubleClick(object sender, System.EventArgs e)
		{
			((clsOPDoctor)this.objController).m_TakeDiag();
		}

		private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			((clsOPDoctor)this.objController).m_currRecindexChange(m_tab.SelectedTab.Name);
		}

		private void m_cboUsage_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			((clsOPDoctor)this.objController).m_FillUsage(m_tab.SelectedTab.Name);
		}

		private void m_tb_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch(this.m_tb.Buttons.IndexOf(e.Button))
			{
				case 0: //新增
					((clsOPDoctor)this.objController).m_AddRec();
					break;
				case 1: //新增明细
					((clsOPDoctor)this.objController).m_AddRecDetail();
					break;
				case 2://删除
					((clsOPDoctor)this.objController).m_Del();
					break;
				case 3: //保存
					((clsOPDoctor)this.objController).m_SaveRec(this.m_tab.SelectedTab.Name);
					break; 
				case 4: //刷新
					((clsOPDoctor)this.objController).m_FillPatRec(null);
					break;
				case 5: //退出
					this.Close();
					break;
     
			}
		}
		private void dgWest_KeyDowns(object sender, System.Windows.Forms.Keys e)
		{
			if(e==Keys.Delete)
				((clsOPDoctor)this.objController).m_Del();
			else if(e==Keys.Enter)
			{
				((clsOPDoctor)this.objController).SendNextCell(m_tab.SelectedTab.Name);
			}
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			((clsOPDoctor)this.objController).RefreshWait(true);
			GC.Collect();
		}

		private void dgTake_DoubleClick(object sender, System.EventArgs e)
		{
		   if(dgTake.Rows==0)
			   return;
		   string strID=dgTake.Get_TextMatrix(dgTake.Row,dgTake.ColIndex("RegID"));
           this.m_PatInfo.FindInfoByRegID(strID);
			//((clsOPDoctor)this.objController).m_FillPatRec(strID);
		}

		private void frmOPDoctor_Load(object sender, System.EventArgs e)
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
			this.ctlDep.LoadData();
		}

		private void m_InWest_ReturnVal(object sender, com.digitalwave.controls.ReturnItem ReturnItem)
		{
			((clsOPDoctor)this.objController).m_FillInputItem(ReturnItem,dgWest);
		}
 
		private void m_InCM_ReturnVal(object sender, com.digitalwave.controls.ReturnItem ReturnItem)
		{
			((clsOPDoctor)this.objController).m_FillInputItem(ReturnItem,dgCM);
		}

		private void m_InChk_ReturnVal(object sender, com.digitalwave.controls.ReturnItem ReturnItem)
		{
			((clsOPDoctor)this.objController).m_FillInputItem(ReturnItem,dgChk);
		}

		private void m_InTest_ReturnVal(object sender, com.digitalwave.controls.ReturnItem ReturnItem)
		{
			((clsOPDoctor)this.objController).m_FillInputItem(ReturnItem,dgTest);
		}

		private void m_InOPS_ReturnVal(object sender, com.digitalwave.controls.ReturnItem ReturnItem)
		{
			((clsOPDoctor)this.objController).m_FillInputItem(ReturnItem,dgOPS);
		}

		private void m_PatInfo_PatientChanged(object sender, string RegID)
		{
		   ((clsOPDoctor)this.objController).m_lngCheckReg(RegID);
		}

		private void m_InOther_ReturnVal(object sender, com.digitalwave.controls.ReturnItem ReturnItem)
		{
		    ((clsOPDoctor)this.objController).m_FillInputItem(ReturnItem,dgOther);
		}

		private void m_muTake_Click(object sender, System.EventArgs e)
		{
		   ((clsOPDoctor)this.objController).m_TakeDiag();
		}

		private void m_muUnDo_Click(object sender, System.EventArgs e)
		{
		    ((clsOPDoctor)this.objController).m_UndoTake();
		}

		private void m_muRec_Click(object sender, System.EventArgs e)
		{
		   dgTake_DoubleClick(null,null);
		}

		private void m_RecNo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		   this.Cursor=Cursors.WaitCursor;
		   ((clsOPDoctor)this.objController).FilterRec(m_RecNo.SelectItemValue);
		   this.Cursor=Cursors.Default;
		}

		private void m_Memo_TextChanged(object sender, System.EventArgs e)
		{
		    ((clsOPDoctor)this.objController).m_SaveDescToVO();
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

		private void frmOPDoctor_Resize(object sender, System.EventArgs e)
		{
			lbHide.Left=this.Width-lbHide.Width;
		}

		private void m_ctlFre_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			((clsOPDoctor)this.objController).m_FillFre();
		}

		private void m_txtCureDesc_TextChanged(object sender, System.EventArgs e)
		{
			m_txtCureDesc.Tag="Yes";
		}

		private void frmOPDoctor_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled=(e.KeyChar==(char)32 || e.KeyChar=="'".ToCharArray()[0]);
		}

		private void frmOPDoctor_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.Alt)
				{
					switch(e.KeyCode)
					{
						case Keys.D0:
							m_tab.SelectedIndex=0;
							break;
						case Keys.D1:
							m_tab.SelectedIndex=1;
							break;
						case Keys.D2:
							m_tab.SelectedIndex=2;
							break;
						case Keys.D3:
							m_tab.SelectedIndex=3;
							break;
						case Keys.D4:
							m_tab.SelectedIndex=4;
							break;
						case Keys.D5:
							m_tab.SelectedIndex=5;
							break;
						case Keys.D6:
							m_tab.SelectedIndex=6;
							break;
						case Keys.D7:
							m_tab.SelectedIndex=7;
							break;
						case Keys.D8:
							m_tab.SelectedIndex=8;
							break;
						case Keys.D9:
							m_tab.SelectedIndex=9;
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
			catch(Exception ex)
			{
//				MessageBox.Show(ex.Message);
			}
		}
		private void m_currRecA_TextChanged(object sender, System.EventArgs e)
		{
			this.m_sb.Panels[0].Text=m_lbRec.Text+m_lbRecA.Text+"  "+m_currRec.Text+m_currRecA.Text;
		}

		private void mnuRichTextBoxDelete_Click(object sender, System.EventArgs e)
		{
			
			if(this.ActiveControl is com.digitalwave.controls.ctlRichTextBox)
			{
				if(this.ActiveControl.Name=="txtAnaphylaxis")
                   return;
				else
				  ((com.digitalwave.controls.ctlRichTextBox)(this.ActiveControl)).m_mthSelectionDoubleStrikeThough(true);
				m_txtCureDesc_TextChanged(null,null);
			}
			
		}

		private void ctlDep_ReturnVal(object sender, string ID, string Name)
		{
		    ((clsOPDoctor)this.objController).m_FillDep(this.m_tab.SelectedTab.Name);
		}

		private void txtDiagMain_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Left || e.KeyCode==Keys.Right || e.KeyCode==Keys.Up || e.KeyCode==Keys.Down)
				return;
			if(e.KeyCode==Keys.Back || e.KeyCode==Keys.Delete)
			  e.Handled=true;
		}

		private void txtDiagMain_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(txtDiagMain.SelectionLength>0 )
				e.Handled=true;
		}

		private void m_BtCreatTem_Click(object sender, System.EventArgs e)
		{
		m_objTemplate.m_mthCreateTemplate();
		}

		private void m_btVindicateTem_Click(object sender, System.EventArgs e)
		{
		m_objTemplate.m_mthManageTemplate();
		}

		}
}
