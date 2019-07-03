using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Data;
using com.digitalwave.iCare.middletier.BIHOrderServer;

namespace com.digitalwave.iCare.BIHOrder
{
	/// <summary>
	/// 执行医嘱	界面表示层
	/// 作者： 徐斌辉
	/// 创建时间： 2005-02-15
	/// </summary>
	public class frmBIHOrderExecute : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		#region 控件申明
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.ColumnHeader BedNo;
		private System.Windows.Forms.ColumnHeader PatientName;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.ColumnHeader columnHeader12;
		private System.Windows.Forms.ColumnHeader columnHeader13;
		private System.Windows.Forms.ColumnHeader columnHeader14;
		private System.Windows.Forms.ColumnHeader columnHeader15;
		private System.Windows.Forms.ColumnHeader columnHeader16;
		private System.Windows.Forms.ColumnHeader SumMoney;
		private System.Windows.Forms.ColumnHeader BalanceMoney;
		private System.Windows.Forms.ColumnHeader LowerLimitMoney;
		internal System.Windows.Forms.ListView m_lsvOrderBaseInfo;
		internal System.Windows.Forms.ListView m_lsvPatientChargeInfo;
		private System.Windows.Forms.Panel panel1;
		private PinkieControls.ButtonXP cmdPrintOrder;
		internal PinkieControls.ButtonXP m_cmdExecute;
		internal com.digitalwave.controls.ctlTimePicker m_dtpStartExecute;
		internal System.Windows.Forms.CheckBox chkSelectAll;
		internal System.Windows.Forms.CheckBox m_chkNeedFeel;
		private PinkieControls.ButtonXP m_cmdExecOrder;
		internal com.digitalwave.iCare.BIHOrder.Control.clsDoctorTextBox m_txtDoctor;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private PinkieControls.ButtonXP m_cmdShow;
		private System.Windows.Forms.Label label7;
		internal com.digitalwave.controls.ctlTimePicker m_dtpEndExecute;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Panel panel3;
		internal System.Windows.Forms.Label m_lblDoctor;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		internal System.Windows.Forms.Label m_lblExecute;
		private System.Windows.Forms.Label label8;
		internal System.Windows.Forms.Label m_lblNotExecute;
		internal System.Windows.Forms.Label m_lblTemp;
		internal System.Windows.Forms.Label m_lblLong;
		private System.Windows.Forms.Label label10;
		internal System.Windows.Forms.ProgressBar m_ctlProgressBar;
		internal System.Windows.Forms.Label m_lblCanNotExecute;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label label17;
		internal System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Label label28;
		internal System.Windows.Forms.Label m_lblLowerLimitBackColor;
		internal System.Windows.Forms.Label m_lblDoctor1;
		private System.ComponentModel.IContainer components;
		internal System.Windows.Forms.TabControl m_tabMain;
		internal PinkieControls.ButtonXP cmdOnceAgain;
		internal PinkieControls.ButtonXP cmdEditFeel;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.ColumnHeader columnHeader17;
		private System.Windows.Forms.ColumnHeader ExecuteType;
		private System.Windows.Forms.ColumnHeader AddBills;
		private System.Windows.Forms.ColumnHeader columnHeader18;
		internal System.Windows.Forms.Label m_lblStopExecute;
		internal com.digitalwave.controls.ctlFindTextBox m_txtArea;
        internal System.Windows.Forms.TextBox m_txtBed;
		private System.Windows.Forms.Splitter splitter1;
		internal System.Windows.Forms.CheckBox m_chkStatus2;
		internal System.Windows.Forms.CheckBox m_chkStatus3;
		internal System.Windows.Forms.CheckBox m_chkStatus1;
		internal System.Windows.Forms.CheckBox m_chkTemp;
		internal System.Windows.Forms.CheckBox m_chkLong;
		internal System.Windows.Forms.CheckBox m_chktakeMedicine;
		private System.Windows.Forms.GroupBox groupBox1;
		internal System.Windows.Forms.ComboBox m_cobOrderCate;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Panel panel6;
		internal System.Windows.Forms.RadioButton m_rbutWork1;
		internal System.Windows.Forms.RadioButton m_rbutWork2;
		internal System.Windows.Forms.RadioButton m_rbutWork3;
		internal System.Windows.Forms.RadioButton m_rbutWork4;
		internal System.Windows.Forms.ListView m_lsvToolTip;
		private System.Windows.Forms.ColumnHeader seq;
		private System.Windows.Forms.ColumnHeader chargeName;
		private System.Windows.Forms.ColumnHeader ChargeClass;
		private System.Windows.Forms.ColumnHeader get_count;
		private System.Windows.Forms.ColumnHeader ChargePrice;
		private System.Windows.Forms.ColumnHeader countSum;
		private System.Windows.Forms.Panel panel7;
		internal System.Windows.Forms.CheckBox m_chkOnlyToday;
		internal System.Windows.Forms.CheckBox m_chkStatus6;
		internal System.Windows.Forms.CheckBox m_chkStatus5;
		private PinkieControls.ButtonXP m_cmdRef;
		private PinkieControls.ButtonXP m_cmdExit;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label18;
		internal System.Windows.Forms.Label m_lblAuditingStop;
		internal System.Windows.Forms.Label m_lblAuditingExecute;
		internal PinkieControls.ButtonXP m_btnAddBills;
		private System.Windows.Forms.ColumnHeader xuClass;
		private System.Windows.Forms.MenuItem muiSendBackOrder;
		internal System.Windows.Forms.ContextMenu ctuMenu;
		internal System.Windows.Forms.PictureBox pictureBox6;
		internal System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.ColumnHeader YB;
        private System.Windows.Forms.ColumnHeader YBClass;
        private ColumnHeader columnHeader30;
        internal ListView m_lsvSelectBed;
        private ColumnHeader columnHeader19;
        private ColumnHeader columnHeader22;
        private ColumnHeader columnHeader29;
        private ColumnHeader excuteDept;
        private Panel panel8;
        private PinkieControls.ButtonXP buttonXP3;
        private PinkieControls.ButtonXP buttonXP2;
        private PinkieControls.ButtonXP buttonXP1;
		com.digitalwave.iCare.ValueObject.clsLoginInfo m_objLoginInfo=null;

		

		#endregion
		#region 构造函数
		public frmBIHOrderExecute()
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

		#endregion
		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBIHOrderExecute));
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_tabMain = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.m_lsvOrderBaseInfo = new System.Windows.Forms.ListView();
            this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.ExecuteType = new System.Windows.Forms.ColumnHeader();
            this.AddBills = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader30 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader18 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
            this.ctuMenu = new System.Windows.Forms.ContextMenu();
            this.muiSendBackOrder = new System.Windows.Forms.MenuItem();
            this.panel8 = new System.Windows.Forms.Panel();
            this.buttonXP3 = new PinkieControls.ButtonXP();
            this.buttonXP2 = new PinkieControls.ButtonXP();
            this.buttonXP1 = new PinkieControls.ButtonXP();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_lsvToolTip = new System.Windows.Forms.ListView();
            this.seq = new System.Windows.Forms.ColumnHeader();
            this.chargeName = new System.Windows.Forms.ColumnHeader();
            this.ChargeClass = new System.Windows.Forms.ColumnHeader();
            this.ChargePrice = new System.Windows.Forms.ColumnHeader();
            this.get_count = new System.Windows.Forms.ColumnHeader();
            this.countSum = new System.Windows.Forms.ColumnHeader();
            this.xuClass = new System.Windows.Forms.ColumnHeader();
            this.excuteDept = new System.Windows.Forms.ColumnHeader();
            this.YB = new System.Windows.Forms.ColumnHeader();
            this.YBClass = new System.Windows.Forms.ColumnHeader();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_lblCanNotExecute = new System.Windows.Forms.Label();
            this.m_lblAuditingStop = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.m_lblExecute = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_lblAuditingExecute = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.m_lblStopExecute = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.m_lblLong = new System.Windows.Forms.Label();
            this.m_lblDoctor = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_lblNotExecute = new System.Windows.Forms.Label();
            this.m_lblTemp = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.m_ctlProgressBar = new System.Windows.Forms.ProgressBar();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.m_lsvPatientChargeInfo = new System.Windows.Forms.ListView();
            this.BedNo = new System.Windows.Forms.ColumnHeader();
            this.PatientName = new System.Windows.Forms.ColumnHeader();
            this.LowerLimitMoney = new System.Windows.Forms.ColumnHeader();
            this.SumMoney = new System.Windows.Forms.ColumnHeader();
            this.BalanceMoney = new System.Windows.Forms.ColumnHeader();
            this.panel4 = new System.Windows.Forms.Panel();
            this.m_lblDoctor1 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.m_lblLowerLimitBackColor = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label28 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.m_txtBed = new System.Windows.Forms.TextBox();
            this.m_txtArea = new com.digitalwave.controls.ctlFindTextBox();
            this.m_dtpStartExecute = new com.digitalwave.controls.ctlTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.m_dtpEndExecute = new com.digitalwave.controls.ctlTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.m_chkOnlyToday = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.m_chkStatus6 = new System.Windows.Forms.CheckBox();
            this.m_chkStatus3 = new System.Windows.Forms.CheckBox();
            this.m_chkStatus2 = new System.Windows.Forms.CheckBox();
            this.m_chkStatus5 = new System.Windows.Forms.CheckBox();
            this.m_chkLong = new System.Windows.Forms.CheckBox();
            this.m_chkNeedFeel = new System.Windows.Forms.CheckBox();
            this.m_chkStatus1 = new System.Windows.Forms.CheckBox();
            this.m_chktakeMedicine = new System.Windows.Forms.CheckBox();
            this.m_chkTemp = new System.Windows.Forms.CheckBox();
            this.m_cobOrderCate = new System.Windows.Forms.ComboBox();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_rbutWork1 = new System.Windows.Forms.RadioButton();
            this.m_rbutWork2 = new System.Windows.Forms.RadioButton();
            this.m_rbutWork3 = new System.Windows.Forms.RadioButton();
            this.m_rbutWork4 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_btnAddBills = new PinkieControls.ButtonXP();
            this.cmdEditFeel = new PinkieControls.ButtonXP();
            this.cmdOnceAgain = new PinkieControls.ButtonXP();
            this.m_cmdShow = new PinkieControls.ButtonXP();
            this.cmdPrintOrder = new PinkieControls.ButtonXP();
            this.m_cmdExecOrder = new PinkieControls.ButtonXP();
            this.m_cmdExecute = new PinkieControls.ButtonXP();
            this.m_cmdRef = new PinkieControls.ButtonXP();
            this.m_cmdExit = new PinkieControls.ButtonXP();
            this.m_lsvSelectBed = new System.Windows.Forms.ListView();
            this.columnHeader19 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader22 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader29 = new System.Windows.Forms.ColumnHeader();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.m_txtDoctor = new com.digitalwave.iCare.BIHOrder.Control.clsDoctorTextBox();
            this.panel2.SuspendLayout();
            this.m_tabMain.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.m_tabMain);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 124);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1016, 497);
            this.panel2.TabIndex = 22;
            // 
            // m_tabMain
            // 
            this.m_tabMain.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.m_tabMain.Controls.Add(this.tabPage2);
            this.m_tabMain.Controls.Add(this.tabPage1);
            this.m_tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tabMain.HotTrack = true;
            this.m_tabMain.Location = new System.Drawing.Point(0, 0);
            this.m_tabMain.Name = "m_tabMain";
            this.m_tabMain.SelectedIndex = 0;
            this.m_tabMain.Size = new System.Drawing.Size(1014, 495);
            this.m_tabMain.TabIndex = 100;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel5);
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1006, 465);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "   医嘱信息   ";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.m_lsvOrderBaseInfo);
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Controls.Add(this.splitter1);
            this.panel5.Controls.Add(this.m_lsvToolTip);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1006, 432);
            this.panel5.TabIndex = 37;
            // 
            // m_lsvOrderBaseInfo
            // 
            this.m_lsvOrderBaseInfo.BackColor = System.Drawing.SystemColors.Window;
            this.m_lsvOrderBaseInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lsvOrderBaseInfo.CheckBoxes = true;
            this.m_lsvOrderBaseInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader17,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.ExecuteType,
            this.AddBills,
            this.columnHeader5,
            this.columnHeader7,
            this.columnHeader30,
            this.columnHeader6,
            this.columnHeader8,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader4,
            this.columnHeader15,
            this.columnHeader18,
            this.columnHeader16});
            this.m_lsvOrderBaseInfo.ContextMenu = this.ctuMenu;
            this.m_lsvOrderBaseInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvOrderBaseInfo.FullRowSelect = true;
            this.m_lsvOrderBaseInfo.GridLines = true;
            this.m_lsvOrderBaseInfo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.m_lsvOrderBaseInfo.HideSelection = false;
            this.m_lsvOrderBaseInfo.Location = new System.Drawing.Point(0, 0);
            this.m_lsvOrderBaseInfo.MultiSelect = false;
            this.m_lsvOrderBaseInfo.Name = "m_lsvOrderBaseInfo";
            this.m_lsvOrderBaseInfo.Size = new System.Drawing.Size(1006, 304);
            this.m_lsvOrderBaseInfo.TabIndex = 101;
            this.m_lsvOrderBaseInfo.UseCompatibleStateImageBehavior = false;
            this.m_lsvOrderBaseInfo.View = System.Windows.Forms.View.Details;
            this.m_lsvOrderBaseInfo.ItemActivate += new System.EventHandler(this.m_lsvOrderBaseInfo_ItemActivate);
            this.m_lsvOrderBaseInfo.SelectedIndexChanged += new System.EventHandler(this.m_lsvOrderBaseInfo_SelectedIndexChanged);
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "序号";
            this.columnHeader17.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader17.Width = 40;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "床号";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = " 姓 名";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "方号";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 40;
            // 
            // ExecuteType
            // 
            this.ExecuteType.Text = "长/临";
            this.ExecuteType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ExecuteType.Width = 50;
            // 
            // AddBills
            // 
            this.AddBills.Text = "附";
            this.AddBills.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AddBills.Width = 30;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "   医嘱名称";
            this.columnHeader5.Width = 120;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "嘱托";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader7.Width = 70;
            // 
            // columnHeader30
            // 
            this.columnHeader30.Text = "规格";
            this.columnHeader30.Width = 90;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = " 剂量  ";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader6.Width = 70;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "领量";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader8.Width = 40;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "执行频率";
            this.columnHeader10.Width = 70;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "用药方式";
            this.columnHeader11.Width = 70;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "补次";
            this.columnHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader12.Width = 40;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "皮试";
            this.columnHeader13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader13.Width = 40;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "皮试结果";
            this.columnHeader14.Width = 70;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "   父级医嘱";
            this.columnHeader4.Width = 120;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "  开始时间";
            this.columnHeader15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader15.Width = 90;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = " 停止人";
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "  停止时间";
            this.columnHeader16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader16.Width = 90;
            // 
            // ctuMenu
            // 
            this.ctuMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.muiSendBackOrder});
            this.ctuMenu.Popup += new System.EventHandler(this.ctuMenu_Popup);
            // 
            // muiSendBackOrder
            // 
            this.muiSendBackOrder.Index = 0;
            this.muiSendBackOrder.Text = "退回";
            this.muiSendBackOrder.Click += new System.EventHandler(this.muiSendBackOrder_Click);
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.buttonXP3);
            this.panel8.Controls.Add(this.buttonXP2);
            this.panel8.Controls.Add(this.buttonXP1);
            this.panel8.Cursor = System.Windows.Forms.Cursors.NoMoveVert;
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(0, 304);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1006, 27);
            this.panel8.TabIndex = 91;
            this.panel8.Click += new System.EventHandler(this.splitter1_DoubleClick);
            // 
            // buttonXP3
            // 
            this.buttonXP3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP3.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonXP3.DefaultScheme = true;
            this.buttonXP3.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP3.Hint = "";
            this.buttonXP3.Location = new System.Drawing.Point(925, -1);
            this.buttonXP3.Name = "buttonXP3";
            this.buttonXP3.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP3.Size = new System.Drawing.Size(79, 28);
            this.buttonXP3.TabIndex = 23;
            this.buttonXP3.Text = "删 除";
            this.buttonXP3.Click += new System.EventHandler(this.buttonXP3_Click);
            // 
            // buttonXP2
            // 
            this.buttonXP2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP2.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonXP2.DefaultScheme = true;
            this.buttonXP2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP2.Hint = "";
            this.buttonXP2.Location = new System.Drawing.Point(838, -1);
            this.buttonXP2.Name = "buttonXP2";
            this.buttonXP2.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP2.Size = new System.Drawing.Size(79, 28);
            this.buttonXP2.TabIndex = 22;
            this.buttonXP2.Text = "修 改";
            this.buttonXP2.Click += new System.EventHandler(this.buttonXP2_Click);
            // 
            // buttonXP1
            // 
            this.buttonXP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP1.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonXP1.DefaultScheme = true;
            this.buttonXP1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP1.Hint = "";
            this.buttonXP1.Location = new System.Drawing.Point(752, -1);
            this.buttonXP1.Name = "buttonXP1";
            this.buttonXP1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP1.Size = new System.Drawing.Size(79, 28);
            this.buttonXP1.TabIndex = 21;
            this.buttonXP1.Text = "新 增";
            this.buttonXP1.Click += new System.EventHandler(this.buttonXP1_Click);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 331);
            this.splitter1.MinExtra = 150;
            this.splitter1.MinSize = 50;
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1006, 4);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            this.splitter1.DoubleClick += new System.EventHandler(this.splitter1_DoubleClick);
            // 
            // m_lsvToolTip
            // 
            this.m_lsvToolTip.BackColor = System.Drawing.SystemColors.Window;
            this.m_lsvToolTip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lsvToolTip.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.seq,
            this.chargeName,
            this.ChargeClass,
            this.ChargePrice,
            this.get_count,
            this.countSum,
            this.xuClass,
            this.excuteDept,
            this.YB,
            this.YBClass});
            this.m_lsvToolTip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_lsvToolTip.FullRowSelect = true;
            this.m_lsvToolTip.GridLines = true;
            this.m_lsvToolTip.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.m_lsvToolTip.Location = new System.Drawing.Point(0, 335);
            this.m_lsvToolTip.Name = "m_lsvToolTip";
            this.m_lsvToolTip.Size = new System.Drawing.Size(1006, 97);
            this.m_lsvToolTip.TabIndex = 61;
            this.m_lsvToolTip.UseCompatibleStateImageBehavior = false;
            this.m_lsvToolTip.View = System.Windows.Forms.View.Details;
            this.m_lsvToolTip.DoubleClick += new System.EventHandler(this.m_lsvToolTip_DoubleClick);
            // 
            // seq
            // 
            this.seq.Text = "序号";
            this.seq.Width = 40;
            // 
            // chargeName
            // 
            this.chargeName.Text = "项目名称";
            this.chargeName.Width = 300;
            // 
            // ChargeClass
            // 
            this.ChargeClass.Text = "费用类型";
            this.ChargeClass.Width = 70;
            // 
            // ChargePrice
            // 
            this.ChargePrice.Text = "单价";
            this.ChargePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ChargePrice.Width = 70;
            // 
            // get_count
            // 
            this.get_count.Text = "数量";
            this.get_count.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.get_count.Width = 70;
            // 
            // countSum
            // 
            this.countSum.Text = "总金额";
            this.countSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.countSum.Width = 70;
            // 
            // xuClass
            // 
            this.xuClass.Text = "续用类型";
            this.xuClass.Width = 70;
            // 
            // excuteDept
            // 
            this.excuteDept.Text = "执行科室";
            this.excuteDept.Width = 96;
            // 
            // YB
            // 
            this.YB.Text = "医保";
            this.YB.Width = 70;
            // 
            // YBClass
            // 
            this.YBClass.Text = "医保类型";
            this.YBClass.Width = 70;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.m_lblCanNotExecute);
            this.panel3.Controls.Add(this.m_lblAuditingStop);
            this.panel3.Controls.Add(this.label18);
            this.panel3.Controls.Add(this.m_lblExecute);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.m_lblAuditingExecute);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.m_lblStopExecute);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.m_lblLong);
            this.panel3.Controls.Add(this.m_lblDoctor);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.m_lblNotExecute);
            this.panel3.Controls.Add(this.m_lblTemp);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.m_ctlProgressBar);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 432);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1006, 33);
            this.panel3.TabIndex = 36;
            // 
            // m_lblCanNotExecute
            // 
            this.m_lblCanNotExecute.BackColor = System.Drawing.SystemColors.ControlText;
            this.m_lblCanNotExecute.Location = new System.Drawing.Point(460, 8);
            this.m_lblCanNotExecute.Name = "m_lblCanNotExecute";
            this.m_lblCanNotExecute.Size = new System.Drawing.Size(10, 10);
            this.m_lblCanNotExecute.TabIndex = 31;
            this.m_lblCanNotExecute.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lblCanNotExecute.Visible = false;
            // 
            // m_lblAuditingStop
            // 
            this.m_lblAuditingStop.BackColor = System.Drawing.SystemColors.ControlText;
            this.m_lblAuditingStop.Location = new System.Drawing.Point(366, 8);
            this.m_lblAuditingStop.Name = "m_lblAuditingStop";
            this.m_lblAuditingStop.Size = new System.Drawing.Size(10, 10);
            this.m_lblAuditingStop.TabIndex = 29;
            this.m_lblAuditingStop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(378, 4);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(77, 14);
            this.label18.TabIndex = 26;
            this.label18.Text = "已审核停止";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblExecute
            // 
            this.m_lblExecute.BackColor = System.Drawing.SystemColors.ControlText;
            this.m_lblExecute.Location = new System.Drawing.Point(251, 8);
            this.m_lblExecute.Name = "m_lblExecute";
            this.m_lblExecute.Size = new System.Drawing.Size(10, 10);
            this.m_lblExecute.TabIndex = 31;
            this.m_lblExecute.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(175, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 30;
            this.label3.Text = "已审核提交";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblAuditingExecute
            // 
            this.m_lblAuditingExecute.BackColor = System.Drawing.SystemColors.ControlText;
            this.m_lblAuditingExecute.Location = new System.Drawing.Point(164, 8);
            this.m_lblAuditingExecute.Name = "m_lblAuditingExecute";
            this.m_lblAuditingExecute.Size = new System.Drawing.Size(10, 10);
            this.m_lblAuditingExecute.TabIndex = 31;
            this.m_lblAuditingExecute.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(261, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 14);
            this.label8.TabIndex = 30;
            this.label8.Text = "执行过";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblStopExecute
            // 
            this.m_lblStopExecute.BackColor = System.Drawing.SystemColors.ControlText;
            this.m_lblStopExecute.Location = new System.Drawing.Point(308, 8);
            this.m_lblStopExecute.Name = "m_lblStopExecute";
            this.m_lblStopExecute.Size = new System.Drawing.Size(10, 10);
            this.m_lblStopExecute.TabIndex = 29;
            this.m_lblStopExecute.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(320, 4);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 14);
            this.label16.TabIndex = 26;
            this.label16.Text = "已停止";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblLong
            // 
            this.m_lblLong.BackColor = System.Drawing.SystemColors.ControlText;
            this.m_lblLong.Location = new System.Drawing.Point(8, 8);
            this.m_lblLong.Name = "m_lblLong";
            this.m_lblLong.Size = new System.Drawing.Size(10, 10);
            this.m_lblLong.TabIndex = 27;
            this.m_lblLong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblDoctor
            // 
            this.m_lblDoctor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lblDoctor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lblDoctor.Location = new System.Drawing.Point(532, 0);
            this.m_lblDoctor.Name = "m_lblDoctor";
            this.m_lblDoctor.Size = new System.Drawing.Size(182, 29);
            this.m_lblDoctor.TabIndex = 33;
            this.m_lblDoctor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(63, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 14);
            this.label6.TabIndex = 25;
            this.label6.Text = "临时";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 14);
            this.label5.TabIndex = 24;
            this.label5.Text = "长期";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblNotExecute
            // 
            this.m_lblNotExecute.BackColor = System.Drawing.SystemColors.ControlText;
            this.m_lblNotExecute.Location = new System.Drawing.Point(108, 8);
            this.m_lblNotExecute.Name = "m_lblNotExecute";
            this.m_lblNotExecute.Size = new System.Drawing.Size(10, 10);
            this.m_lblNotExecute.TabIndex = 29;
            this.m_lblNotExecute.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblTemp
            // 
            this.m_lblTemp.BackColor = System.Drawing.SystemColors.ControlText;
            this.m_lblTemp.Location = new System.Drawing.Point(52, 8);
            this.m_lblTemp.Name = "m_lblTemp";
            this.m_lblTemp.Size = new System.Drawing.Size(10, 10);
            this.m_lblTemp.TabIndex = 28;
            this.m_lblTemp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(117, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 14);
            this.label10.TabIndex = 26;
            this.label10.Text = "已提交";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_ctlProgressBar
            // 
            this.m_ctlProgressBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_ctlProgressBar.Location = new System.Drawing.Point(714, 0);
            this.m_ctlProgressBar.Name = "m_ctlProgressBar";
            this.m_ctlProgressBar.Size = new System.Drawing.Size(288, 29);
            this.m_ctlProgressBar.TabIndex = 22;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(472, 5);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 14);
            this.label14.TabIndex = 30;
            this.label14.Text = "不可执行";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label14.Visible = false;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Dock = System.Windows.Forms.DockStyle.Left;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(532, 29);
            this.label9.TabIndex = 32;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.m_lsvPatientChargeInfo);
            this.tabPage1.Controls.Add(this.panel4);
            this.tabPage1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1006, 467);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "   费用信息   ";
            // 
            // m_lsvPatientChargeInfo
            // 
            this.m_lsvPatientChargeInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lsvPatientChargeInfo.CheckBoxes = true;
            this.m_lsvPatientChargeInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.BedNo,
            this.PatientName,
            this.LowerLimitMoney,
            this.SumMoney,
            this.BalanceMoney});
            this.m_lsvPatientChargeInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvPatientChargeInfo.FullRowSelect = true;
            this.m_lsvPatientChargeInfo.GridLines = true;
            this.m_lsvPatientChargeInfo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.m_lsvPatientChargeInfo.Location = new System.Drawing.Point(0, 0);
            this.m_lsvPatientChargeInfo.Name = "m_lsvPatientChargeInfo";
            this.m_lsvPatientChargeInfo.Size = new System.Drawing.Size(1006, 434);
            this.m_lsvPatientChargeInfo.TabIndex = 0;
            this.m_lsvPatientChargeInfo.UseCompatibleStateImageBehavior = false;
            this.m_lsvPatientChargeInfo.View = System.Windows.Forms.View.Details;
            this.m_lsvPatientChargeInfo.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.m_lsvPatientChargeInfo_ItemCheck);
            // 
            // BedNo
            // 
            this.BedNo.Text = "床号";
            this.BedNo.Width = 40;
            // 
            // PatientName
            // 
            this.PatientName.Text = "    姓 名";
            this.PatientName.Width = 150;
            // 
            // LowerLimitMoney
            // 
            this.LowerLimitMoney.Text = "费用下限";
            this.LowerLimitMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.LowerLimitMoney.Width = 150;
            // 
            // SumMoney
            // 
            this.SumMoney.Text = "累计费用 ";
            this.SumMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.SumMoney.Width = 150;
            // 
            // BalanceMoney
            // 
            this.BalanceMoney.Text = "余  额  ";
            this.BalanceMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.BalanceMoney.Width = 150;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.m_lblDoctor1);
            this.panel4.Controls.Add(this.label17);
            this.panel4.Controls.Add(this.m_lblLowerLimitBackColor);
            this.panel4.Controls.Add(this.progressBar1);
            this.panel4.Controls.Add(this.label28);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 434);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1006, 33);
            this.panel4.TabIndex = 37;
            // 
            // m_lblDoctor1
            // 
            this.m_lblDoctor1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lblDoctor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lblDoctor1.Location = new System.Drawing.Point(408, 0);
            this.m_lblDoctor1.Name = "m_lblDoctor1";
            this.m_lblDoctor1.Size = new System.Drawing.Size(306, 29);
            this.m_lblDoctor1.TabIndex = 33;
            this.m_lblDoctor1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(40, 8);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(119, 14);
            this.label17.TabIndex = 24;
            this.label17.Text = "费用超过费用下限";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblLowerLimitBackColor
            // 
            this.m_lblLowerLimitBackColor.BackColor = System.Drawing.Color.Red;
            this.m_lblLowerLimitBackColor.Location = new System.Drawing.Point(24, 10);
            this.m_lblLowerLimitBackColor.Name = "m_lblLowerLimitBackColor";
            this.m_lblLowerLimitBackColor.Size = new System.Drawing.Size(10, 10);
            this.m_lblLowerLimitBackColor.TabIndex = 27;
            this.m_lblLowerLimitBackColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.progressBar1.Location = new System.Drawing.Point(714, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(288, 29);
            this.progressBar1.TabIndex = 22;
            // 
            // label28
            // 
            this.label28.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label28.Dock = System.Windows.Forms.DockStyle.Left;
            this.label28.Location = new System.Drawing.Point(0, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(408, 29);
            this.label28.TabIndex = 32;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 124);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.m_txtBed);
            this.panel7.Controls.Add(this.m_txtArea);
            this.panel7.Controls.Add(this.m_dtpStartExecute);
            this.panel7.Controls.Add(this.m_txtDoctor);
            this.panel7.Controls.Add(this.label4);
            this.panel7.Controls.Add(this.label2);
            this.panel7.Controls.Add(this.label1);
            this.panel7.Controls.Add(this.label7);
            this.panel7.Controls.Add(this.m_dtpEndExecute);
            this.panel7.Controls.Add(this.label11);
            this.panel7.Location = new System.Drawing.Point(4, 4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(584, 60);
            this.panel7.TabIndex = 1;
            // 
            // m_txtBed
            // 
            this.m_txtBed.BackColor = System.Drawing.Color.LightCyan;
            this.m_txtBed.Location = new System.Drawing.Point(273, 4);
            this.m_txtBed.Name = "m_txtBed";
            this.m_txtBed.ReadOnly = true;
            this.m_txtBed.Size = new System.Drawing.Size(303, 23);
            this.m_txtBed.TabIndex = 0;
            this.m_txtBed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtBed_KeyDown);
            // 
            // m_txtArea
            // 
            this.m_txtArea.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtArea.Location = new System.Drawing.Point(69, 4);
            this.m_txtArea.Name = "m_txtArea";
            this.m_txtArea.Size = new System.Drawing.Size(140, 23);
            this.m_txtArea.TabIndex = 1;
            this.m_txtArea.m_evtFindItem += new com.digitalwave.controls.EventHandler_OnFindItem(this.m_txtArea_m_evtFindItem);
            this.m_txtArea.m_evtInitListView += new com.digitalwave.controls.EventHandler_InitListView(this.m_txtArea_m_evtInitListView);
            this.m_txtArea.m_evtSelectItem += new com.digitalwave.controls.EventHandler_OnSelectItem(this.m_txtArea_m_evtSelectItem);
            // 
            // m_dtpStartExecute
            // 
            this.m_dtpStartExecute.BorderColor = System.Drawing.Color.DimGray;
            this.m_dtpStartExecute.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpStartExecute.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_dtpStartExecute.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpStartExecute.DropButtonForeColor = System.Drawing.SystemColors.ControlText;
            this.m_dtpStartExecute.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpStartExecute.Font = new System.Drawing.Font("宋体", 12F);
            this.m_dtpStartExecute.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpStartExecute.Location = new System.Drawing.Point(69, 32);
            this.m_dtpStartExecute.m_BlnOnlyTime = false;
            this.m_dtpStartExecute.m_EnmVisibleFlag = com.digitalwave.controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpStartExecute.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpStartExecute.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpStartExecute.Name = "m_dtpStartExecute";
            this.m_dtpStartExecute.ReadOnly = false;
            this.m_dtpStartExecute.Size = new System.Drawing.Size(140, 22);
            this.m_dtpStartExecute.TabIndex = 59;
            this.m_dtpStartExecute.TextBackColor = System.Drawing.Color.White;
            this.m_dtpStartExecute.TextForeColor = System.Drawing.Color.Black;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(370, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "录入医生:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "床号:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 51;
            this.label1.Text = "病区名称:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 14);
            this.label7.TabIndex = 17;
            this.label7.Text = "执行日期:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_dtpEndExecute
            // 
            this.m_dtpEndExecute.BorderColor = System.Drawing.Color.DimGray;
            this.m_dtpEndExecute.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpEndExecute.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_dtpEndExecute.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpEndExecute.DropButtonForeColor = System.Drawing.SystemColors.ControlText;
            this.m_dtpEndExecute.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpEndExecute.Font = new System.Drawing.Font("宋体", 12F);
            this.m_dtpEndExecute.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpEndExecute.Location = new System.Drawing.Point(227, 32);
            this.m_dtpEndExecute.m_BlnOnlyTime = false;
            this.m_dtpEndExecute.m_EnmVisibleFlag = com.digitalwave.controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpEndExecute.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpEndExecute.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpEndExecute.Name = "m_dtpEndExecute";
            this.m_dtpEndExecute.ReadOnly = false;
            this.m_dtpEndExecute.Size = new System.Drawing.Size(140, 22);
            this.m_dtpEndExecute.TabIndex = 60;
            this.m_dtpEndExecute.TextBackColor = System.Drawing.Color.White;
            this.m_dtpEndExecute.TextForeColor = System.Drawing.Color.Black;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(209, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 14);
            this.label11.TabIndex = 6;
            this.label11.Text = "～";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.pictureBox6);
            this.panel6.Controls.Add(this.pictureBox3);
            this.panel6.Controls.Add(this.m_chkOnlyToday);
            this.panel6.Controls.Add(this.label15);
            this.panel6.Controls.Add(this.m_chkStatus6);
            this.panel6.Controls.Add(this.m_chkStatus3);
            this.panel6.Controls.Add(this.m_chkStatus2);
            this.panel6.Controls.Add(this.m_chkStatus5);
            this.panel6.Controls.Add(this.m_chkLong);
            this.panel6.Controls.Add(this.m_chkNeedFeel);
            this.panel6.Controls.Add(this.m_chkStatus1);
            this.panel6.Controls.Add(this.m_chktakeMedicine);
            this.panel6.Controls.Add(this.m_chkTemp);
            this.panel6.Controls.Add(this.m_cobOrderCate);
            this.panel6.Controls.Add(this.chkSelectAll);
            this.panel6.Location = new System.Drawing.Point(4, 68);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(584, 52);
            this.panel6.TabIndex = 109;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(460, 29);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(20, 24);
            this.pictureBox6.TabIndex = 115;
            this.pictureBox6.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox6, "有新医嘱 请注意刷新 ！！");
            this.pictureBox6.Visible = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(441, 29);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(20, 24);
            this.pictureBox3.TabIndex = 114;
            this.pictureBox3.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox3, "有新医嘱 请注意刷新 ！！");
            this.pictureBox3.Visible = false;
            // 
            // m_chkOnlyToday
            // 
            this.m_chkOnlyToday.Location = new System.Drawing.Point(316, 30);
            this.m_chkOnlyToday.Name = "m_chkOnlyToday";
            this.m_chkOnlyToday.Size = new System.Drawing.Size(112, 24);
            this.m_chkOnlyToday.TabIndex = 85;
            this.m_chkOnlyToday.Text = "仅当天提交";
            this.m_chkOnlyToday.CheckedChanged += new System.EventHandler(this.m_cmdRef_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(407, 7);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 14);
            this.label15.TabIndex = 105;
            this.label15.Text = "类型:";
            // 
            // m_chkStatus6
            // 
            this.m_chkStatus6.Checked = true;
            this.m_chkStatus6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkStatus6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkStatus6.Location = new System.Drawing.Point(316, 2);
            this.m_chkStatus6.Name = "m_chkStatus6";
            this.m_chkStatus6.Size = new System.Drawing.Size(96, 24);
            this.m_chkStatus6.TabIndex = 65;
            this.m_chkStatus6.Text = "已审核停止";
            this.m_chkStatus6.CheckedChanged += new System.EventHandler(this.m_cmdRef_Click);
            // 
            // m_chkStatus3
            // 
            this.m_chkStatus3.Checked = true;
            this.m_chkStatus3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkStatus3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkStatus3.Location = new System.Drawing.Point(236, 2);
            this.m_chkStatus3.Name = "m_chkStatus3";
            this.m_chkStatus3.Size = new System.Drawing.Size(96, 24);
            this.m_chkStatus3.TabIndex = 64;
            this.m_chkStatus3.Text = "已停止";
            this.m_chkStatus3.CheckedChanged += new System.EventHandler(this.m_cmdRef_Click);
            // 
            // m_chkStatus2
            // 
            this.m_chkStatus2.Checked = true;
            this.m_chkStatus2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkStatus2.Location = new System.Drawing.Point(164, 2);
            this.m_chkStatus2.Name = "m_chkStatus2";
            this.m_chkStatus2.Size = new System.Drawing.Size(96, 24);
            this.m_chkStatus2.TabIndex = 63;
            this.m_chkStatus2.Text = "已执行";
            this.m_chkStatus2.CheckedChanged += new System.EventHandler(this.m_cmdRef_Click);
            // 
            // m_chkStatus5
            // 
            this.m_chkStatus5.Checked = true;
            this.m_chkStatus5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkStatus5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkStatus5.Location = new System.Drawing.Point(72, 2);
            this.m_chkStatus5.Name = "m_chkStatus5";
            this.m_chkStatus5.Size = new System.Drawing.Size(96, 24);
            this.m_chkStatus5.TabIndex = 63;
            this.m_chkStatus5.Text = "已审核提交";
            this.m_chkStatus5.CheckedChanged += new System.EventHandler(this.m_cmdRef_Click);
            // 
            // m_chkLong
            // 
            this.m_chkLong.Location = new System.Drawing.Point(4, 30);
            this.m_chkLong.Name = "m_chkLong";
            this.m_chkLong.Size = new System.Drawing.Size(64, 24);
            this.m_chkLong.TabIndex = 81;
            this.m_chkLong.Text = "长嘱";
            this.m_chkLong.CheckedChanged += new System.EventHandler(this.m_cmdRef_Click);
            // 
            // m_chkNeedFeel
            // 
            this.m_chkNeedFeel.Location = new System.Drawing.Point(236, 30);
            this.m_chkNeedFeel.Name = "m_chkNeedFeel";
            this.m_chkNeedFeel.Size = new System.Drawing.Size(92, 24);
            this.m_chkNeedFeel.TabIndex = 84;
            this.m_chkNeedFeel.Text = "仅皮试";
            this.m_chkNeedFeel.CheckedChanged += new System.EventHandler(this.m_cmdRef_Click);
            // 
            // m_chkStatus1
            // 
            this.m_chkStatus1.Checked = true;
            this.m_chkStatus1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkStatus1.Location = new System.Drawing.Point(4, 2);
            this.m_chkStatus1.Name = "m_chkStatus1";
            this.m_chkStatus1.Size = new System.Drawing.Size(96, 24);
            this.m_chkStatus1.TabIndex = 62;
            this.m_chkStatus1.Text = "已提交";
            this.m_chkStatus1.CheckedChanged += new System.EventHandler(this.m_cmdRef_Click);
            // 
            // m_chktakeMedicine
            // 
            this.m_chktakeMedicine.Location = new System.Drawing.Point(140, 30);
            this.m_chktakeMedicine.Name = "m_chktakeMedicine";
            this.m_chktakeMedicine.Size = new System.Drawing.Size(96, 24);
            this.m_chktakeMedicine.TabIndex = 83;
            this.m_chktakeMedicine.Text = "仅出院带药";
            this.m_chktakeMedicine.CheckedChanged += new System.EventHandler(this.m_cmdRef_Click);
            // 
            // m_chkTemp
            // 
            this.m_chkTemp.Location = new System.Drawing.Point(72, 30);
            this.m_chkTemp.Name = "m_chkTemp";
            this.m_chkTemp.Size = new System.Drawing.Size(64, 24);
            this.m_chkTemp.TabIndex = 82;
            this.m_chkTemp.Text = "临嘱";
            this.m_chkTemp.CheckedChanged += new System.EventHandler(this.m_cmdRef_Click);
            // 
            // m_cobOrderCate
            // 
            this.m_cobOrderCate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cobOrderCate.Location = new System.Drawing.Point(448, 4);
            this.m_cobOrderCate.Name = "m_cobOrderCate";
            this.m_cobOrderCate.Size = new System.Drawing.Size(128, 22);
            this.m_cobOrderCate.TabIndex = 66;
            this.m_cobOrderCate.SelectionChangeCommitted += new System.EventHandler(this.m_cmdRef_Click);
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.BackColor = System.Drawing.SystemColors.Control;
            this.chkSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSelectAll.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.chkSelectAll.ForeColor = System.Drawing.Color.Maroon;
            this.chkSelectAll.Location = new System.Drawing.Point(525, 30);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(60, 24);
            this.chkSelectAll.TabIndex = 91;
            this.chkSelectAll.Text = "全选";
            this.chkSelectAll.UseVisualStyleBackColor = false;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_rbutWork1);
            this.groupBox2.Controls.Add(this.m_rbutWork2);
            this.groupBox2.Controls.Add(this.m_rbutWork3);
            this.groupBox2.Controls.Add(this.m_rbutWork4);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.Location = new System.Drawing.Point(593, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(100, 120);
            this.groupBox2.TabIndex = 107;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "任务区：";
            // 
            // m_rbutWork1
            // 
            this.m_rbutWork1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rbutWork1.Location = new System.Drawing.Point(10, 17);
            this.m_rbutWork1.Name = "m_rbutWork1";
            this.m_rbutWork1.Size = new System.Drawing.Size(84, 24);
            this.m_rbutWork1.TabIndex = 110;
            this.m_rbutWork1.Text = "查看医嘱";
            this.m_rbutWork1.CheckedChanged += new System.EventHandler(this.Work_Changed);
            // 
            // m_rbutWork2
            // 
            this.m_rbutWork2.Checked = true;
            this.m_rbutWork2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rbutWork2.Location = new System.Drawing.Point(10, 41);
            this.m_rbutWork2.Name = "m_rbutWork2";
            this.m_rbutWork2.Size = new System.Drawing.Size(84, 24);
            this.m_rbutWork2.TabIndex = 111;
            this.m_rbutWork2.TabStop = true;
            this.m_rbutWork2.Text = "审核提交";
            this.m_rbutWork2.CheckedChanged += new System.EventHandler(this.Work_Changed);
            // 
            // m_rbutWork3
            // 
            this.m_rbutWork3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rbutWork3.Location = new System.Drawing.Point(10, 65);
            this.m_rbutWork3.Name = "m_rbutWork3";
            this.m_rbutWork3.Size = new System.Drawing.Size(84, 24);
            this.m_rbutWork3.TabIndex = 112;
            this.m_rbutWork3.Text = "执行医嘱";
            this.m_rbutWork3.CheckedChanged += new System.EventHandler(this.Work_Changed);
            // 
            // m_rbutWork4
            // 
            this.m_rbutWork4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rbutWork4.Location = new System.Drawing.Point(10, 89);
            this.m_rbutWork4.Name = "m_rbutWork4";
            this.m_rbutWork4.Size = new System.Drawing.Size(84, 24);
            this.m_rbutWork4.TabIndex = 113;
            this.m_rbutWork4.Text = "审核停止";
            this.m_rbutWork4.CheckedChanged += new System.EventHandler(this.Work_Changed);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_btnAddBills);
            this.groupBox1.Controls.Add(this.cmdEditFeel);
            this.groupBox1.Controls.Add(this.cmdOnceAgain);
            this.groupBox1.Controls.Add(this.m_cmdShow);
            this.groupBox1.Controls.Add(this.cmdPrintOrder);
            this.groupBox1.Controls.Add(this.m_cmdExecOrder);
            this.groupBox1.Controls.Add(this.m_cmdExecute);
            this.groupBox1.Controls.Add(this.m_cmdRef);
            this.groupBox1.Controls.Add(this.m_cmdExit);
            this.groupBox1.Location = new System.Drawing.Point(696, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 120);
            this.groupBox1.TabIndex = 108;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作区：";
            // 
            // m_btnAddBills
            // 
            this.m_btnAddBills.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnAddBills.DefaultScheme = true;
            this.m_btnAddBills.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnAddBills.Enabled = false;
            this.m_btnAddBills.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_btnAddBills.Hint = "";
            this.m_btnAddBills.Location = new System.Drawing.Point(4, 84);
            this.m_btnAddBills.Name = "m_btnAddBills";
            this.m_btnAddBills.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnAddBills.Size = new System.Drawing.Size(104, 32);
            this.m_btnAddBills.TabIndex = 100;
            this.m_btnAddBills.Text = "附加单据(F7)";
            this.m_btnAddBills.Click += new System.EventHandler(this.m_btnAddBills_Click);
            // 
            // cmdEditFeel
            // 
            this.cmdEditFeel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdEditFeel.DefaultScheme = true;
            this.cmdEditFeel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdEditFeel.Enabled = false;
            this.cmdEditFeel.Hint = "";
            this.cmdEditFeel.Location = new System.Drawing.Point(212, 16);
            this.cmdEditFeel.Name = "cmdEditFeel";
            this.cmdEditFeel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdEditFeel.Size = new System.Drawing.Size(104, 32);
            this.cmdEditFeel.TabIndex = 92;
            this.cmdEditFeel.Text = "编辑皮试(F4)";
            this.cmdEditFeel.Click += new System.EventHandler(this.cmdEditFeel_Click);
            // 
            // cmdOnceAgain
            // 
            this.cmdOnceAgain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdOnceAgain.DefaultScheme = true;
            this.cmdOnceAgain.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdOnceAgain.Enabled = false;
            this.cmdOnceAgain.Hint = "";
            this.cmdOnceAgain.Location = new System.Drawing.Point(108, 16);
            this.cmdOnceAgain.Name = "cmdOnceAgain";
            this.cmdOnceAgain.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdOnceAgain.Size = new System.Drawing.Size(104, 32);
            this.cmdOnceAgain.TabIndex = 91;
            this.cmdOnceAgain.Text = "编辑补次(F3)";
            this.cmdOnceAgain.Click += new System.EventHandler(this.cmdOnceAgain_Click);
            // 
            // m_cmdShow
            // 
            this.m_cmdShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdShow.DefaultScheme = true;
            this.m_cmdShow.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdShow.Hint = "";
            this.m_cmdShow.Location = new System.Drawing.Point(4, 16);
            this.m_cmdShow.Name = "m_cmdShow";
            this.m_cmdShow.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdShow.Size = new System.Drawing.Size(104, 32);
            this.m_cmdShow.TabIndex = 90;
            this.m_cmdShow.Text = "查询(F2)";
            this.m_cmdShow.Click += new System.EventHandler(this.m_cmdShow_Click);
            // 
            // cmdPrintOrder
            // 
            this.cmdPrintOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdPrintOrder.DefaultScheme = true;
            this.cmdPrintOrder.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdPrintOrder.Hint = "";
            this.cmdPrintOrder.Location = new System.Drawing.Point(212, 50);
            this.cmdPrintOrder.Name = "cmdPrintOrder";
            this.cmdPrintOrder.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdPrintOrder.Size = new System.Drawing.Size(104, 32);
            this.cmdPrintOrder.TabIndex = 97;
            this.cmdPrintOrder.Text = "打印(F9)";
            this.cmdPrintOrder.Click += new System.EventHandler(this.cmdPrintOrder_Click);
            // 
            // m_cmdExecOrder
            // 
            this.m_cmdExecOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdExecOrder.DefaultScheme = true;
            this.m_cmdExecOrder.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdExecOrder.Hint = "";
            this.m_cmdExecOrder.Location = new System.Drawing.Point(108, 50);
            this.m_cmdExecOrder.Name = "m_cmdExecOrder";
            this.m_cmdExecOrder.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdExecOrder.Size = new System.Drawing.Size(104, 32);
            this.m_cmdExecOrder.TabIndex = 96;
            this.m_cmdExecOrder.Text = "看执行单(F6)";
            this.m_cmdExecOrder.Click += new System.EventHandler(this.m_cmdExecOrder_Click);
            // 
            // m_cmdExecute
            // 
            this.m_cmdExecute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdExecute.DefaultScheme = true;
            this.m_cmdExecute.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdExecute.Hint = "";
            this.m_cmdExecute.Location = new System.Drawing.Point(4, 50);
            this.m_cmdExecute.Name = "m_cmdExecute";
            this.m_cmdExecute.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdExecute.Size = new System.Drawing.Size(104, 32);
            this.m_cmdExecute.TabIndex = 95;
            this.m_cmdExecute.Text = "审核提交(F5)";
            this.m_cmdExecute.Click += new System.EventHandler(this.m_cmdExecute_Click);
            // 
            // m_cmdRef
            // 
            this.m_cmdRef.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdRef.DefaultScheme = true;
            this.m_cmdRef.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdRef.Hint = "";
            this.m_cmdRef.Location = new System.Drawing.Point(108, 84);
            this.m_cmdRef.Name = "m_cmdRef";
            this.m_cmdRef.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdRef.Size = new System.Drawing.Size(104, 32);
            this.m_cmdRef.TabIndex = 101;
            this.m_cmdRef.Text = "刷新(F8)";
            this.m_cmdRef.Click += new System.EventHandler(this.m_cmdRef_Click2);
            // 
            // m_cmdExit
            // 
            this.m_cmdExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdExit.DefaultScheme = true;
            this.m_cmdExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdExit.Hint = "";
            this.m_cmdExit.Location = new System.Drawing.Point(212, 84);
            this.m_cmdExit.Name = "m_cmdExit";
            this.m_cmdExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdExit.Size = new System.Drawing.Size(104, 32);
            this.m_cmdExit.TabIndex = 102;
            this.m_cmdExit.Text = "退出(Esc)";
            this.m_cmdExit.Click += new System.EventHandler(this.m_cmdExit_Click_1);
            // 
            // m_lsvSelectBed
            // 
            this.m_lsvSelectBed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lsvSelectBed.CheckBoxes = true;
            this.m_lsvSelectBed.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader19,
            this.columnHeader22,
            this.columnHeader29});
            this.m_lsvSelectBed.FullRowSelect = true;
            this.m_lsvSelectBed.GridLines = true;
            this.m_lsvSelectBed.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_lsvSelectBed.Location = new System.Drawing.Point(278, 32);
            this.m_lsvSelectBed.Name = "m_lsvSelectBed";
            this.m_lsvSelectBed.Size = new System.Drawing.Size(306, 208);
            this.m_lsvSelectBed.TabIndex = 88;
            this.m_lsvSelectBed.UseCompatibleStateImageBehavior = false;
            this.m_lsvSelectBed.View = System.Windows.Forms.View.Details;
            this.m_lsvSelectBed.Visible = false;
            this.m_lsvSelectBed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_lsvSelectBed_KeyDown);
            this.m_lsvSelectBed.Leave += new System.EventHandler(this.m_lsvSelectBed_Leave);
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "床号";
            this.columnHeader19.Width = 50;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "姓名";
            this.columnHeader22.Width = 100;
            // 
            // columnHeader29
            // 
            this.columnHeader29.Text = "性别";
            // 
            // m_txtDoctor
            // 
            this.m_txtDoctor.DoctorID = "";
            this.m_txtDoctor.DoctorName = "";
            this.m_txtDoctor.Location = new System.Drawing.Point(436, 31);
            this.m_txtDoctor.Name = "m_txtDoctor";
            this.m_txtDoctor.Size = new System.Drawing.Size(140, 23);
            this.m_txtDoctor.TabIndex = 61;
            this.m_txtDoctor.Tag = "";
            // 
            // frmBIHOrderExecute
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(1016, 621);
            this.Controls.Add(this.m_lsvSelectBed);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.KeyPreview = true;
            this.Name = "frmBIHOrderExecute";
            this.Text = "医嘱护士工作站";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBIHOrderExecute_KeyDown);
            this.Load += new System.EventHandler(this.frmBIHOrderExecute_Load);
            this.panel2.ResumeLayout(false);
            this.m_tabMain.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		public override void CreateController()
		{
			this.objController = new com.digitalwave.iCare.BIHOrder.clsCtl_BIHOrderExecute();
			objController.Set_GUI_Apperance(this);
		}

		#region 窗体事件
		private void frmBIHOrderExecute_Load(object sender, System.EventArgs e)
		{
			//m_mthSetEnter2Tab(new System.Windows.Forms.Control[]{});
			m_objLoginInfo = this.LoginInfo;
			m_lblDoctor.Text="操作员:" + m_objLoginInfo.m_strEmpName;
			m_lblDoctor1.Text="操作员:" + m_objLoginInfo.m_strEmpName;
			((clsCtl_BIHOrderExecute)this.objController).m_strOperatorID =m_objLoginInfo.m_strEmpID;
			((clsCtl_BIHOrderExecute)this.objController).m_strOperatorName =m_objLoginInfo.m_strEmpName;
			((clsCtl_BIHOrderExecute)this.objController).m_LoadInitialization();
			Work =2;//默认审核提交
            //在导入时默认科室为当前员工所在科室  
            m_txtArea.Tag = this.LoginInfo.m_strInpatientAreaID;
            m_txtArea.Text = this.LoginInfo.m_strInpatientAreaName; 

			#region 初始化计时器	glzhang 2005.08.1
			((clsCtl_BIHOrderExecute)this.objController).m_mthInitAlert();
			((clsCtl_BIHOrderExecute)this.objController).m_mthAlert(sender ,e);
            m_txtArea.Focus();
			#endregion
		}
		private void frmBIHOrderExecute_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			m_mthSetKeyTab(e);
			switch (e.KeyCode)
			{
				case Keys.Escape:
					if(MessageBox.Show("是否确定退出","提示",MessageBoxButtons.YesNo,MessageBoxIcon.None)==DialogResult.Yes)
					{
						this.Close();
					}
					break;
				case Keys.F2://查询
					if(m_cmdShow.Enabled)
					{
						m_cmdShow_Click(sender,e);
					}
					break;
				case Keys.F3://补次
					if(cmdOnceAgain.Enabled)
					{
						cmdOnceAgain_Click(sender,e);
					}
					break;
				case Keys.F4://编辑皮试
					if(cmdEditFeel.Enabled)
					{
						cmdEditFeel_Click(sender,e);
					}
					break;
				case Keys.F5://执行
					if(m_cmdExecute.Enabled)
					{
						m_cmdExecute_Click(sender,e);
					}
					break;
				case Keys.F6://查看执行单
					if(m_cmdExecute.Enabled)
					{
						m_cmdExecOrder_Click(sender,e);
					}
					break;
				case Keys.F8://刷新(F8)
					if(m_cmdRef.Enabled)
					{
						m_cmdRef_Click2(sender,e);
					}
					break;
				case Keys.F9://打印医嘱(F9)
					if(cmdPrintOrder.Enabled)
					{
						cmdPrintOrder_Click(sender,e);
					}
					break;
			}
		}
		#endregion
		#region 按钮事件
		private void m_cmdShow_Click(object sender, System.EventArgs e)
		{
			this.Cursor =Cursors.WaitCursor;
			((clsCtl_BIHOrderExecute)this.objController).m_FindOrder();
			this.Cursor =Cursors.Default;
		}

		private void m_cmdExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void m_cmdExecOrder_Click(object sender, System.EventArgs e)
		{
			((clsCtl_BIHOrderExecute)this.objController).m_ViewExecOrder();
		}

		private void m_cmdExecute_Click(object sender, System.EventArgs e)
		{
			this.Cursor =Cursors.WaitCursor;
			((clsCtl_BIHOrderExecute)this.objController).m_WorkExecute();

			#region	设置提示灯状态 
			((clsCtl_BIHOrderExecute)this.objController).m_mthAlert(sender ,e);
			#endregion

			this.Cursor =Cursors.Default;
		}

		private void cmdPrintOrder_Click(object sender, System.EventArgs e)
		{
			((clsCtl_BIHOrderExecute)this.objController).m_PrintOrder();
		}

		private void cmdOnceAgain_Click(object sender, System.EventArgs e)
		{
			((clsCtl_BIHOrderExecute)this.objController).m_OnceAgain();
		}

		private void cmdEditFeel_Click(object sender, System.EventArgs e)
		{
			((clsCtl_BIHOrderExecute)this.objController).m_EditFeel();
		}
		private void m_cmdRef_Click(object sender, System.EventArgs e)
		{           
			((clsCtl_BIHOrderExecute)this.objController).DataBindListView();
			((clsCtl_BIHOrderExecute)this.objController).m_ClearBuffer();
		}

        private void m_cmdRef_Click2(object sender, System.EventArgs e)
        {           
            this.Cursor = Cursors.WaitCursor;
            ((clsCtl_BIHOrderExecute)this.objController).m_FindOrder();
            ((clsCtl_BIHOrderExecute)this.objController).m_ClearBuffer();
            this.Cursor = Cursors.Default;           
        }

		private void m_cmdExit_Click_1(object sender, System.EventArgs e)
		{
			this.Close();
		}
		#endregion
		#region 菜单事件
		private void ctuMenu_Popup(object sender, System.EventArgs e)
		{
			((clsCtl_BIHOrderExecute)this.objController).m_funPopup();
		}

		private void muiSendBackOrder_Click(object sender, System.EventArgs e)
		{
			((clsCtl_BIHOrderExecute)this.objController).m_funSendBackOrder();
		}
		#endregion
		#region ListView事件
		private void m_lsvOrderBaseInfo_ItemActivate(object sender, System.EventArgs e)
		{
			((clsCtl_BIHOrderExecute)this.objController).m_ItemActivateOrderBaseInfo();
		}

		private void m_lsvPatientChargeInfo_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
		{
			((clsCtl_BIHOrderExecute)this.objController).m_ItemCheckPatientChargeInfo(e);
		}	
		private void m_lsvOrderBaseInfo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			((clsCtl_BIHOrderExecute)this.objController).m_SelectedIndexChangedOrderBaseInfo();
		}	
		#endregion
		#region 其他控件事件
		private void chkSelectAll_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chkSelectAll.Checked)
			{
				for(int i=0;i<m_lsvOrderBaseInfo.Items.Count;i++)
				{
					m_lsvOrderBaseInfo.Items[i].Checked =true;
				}
				for(int i=0;i<m_lsvPatientChargeInfo.Items.Count;i++)
				{
					m_lsvPatientChargeInfo.Items[i].Checked =true;
				}
			}
			else
			{
				for(int i=0;i<m_lsvOrderBaseInfo.Items.Count;i++)
				{
					m_lsvOrderBaseInfo.Items[i].Checked =false;
				}
				for(int i=0;i<m_lsvPatientChargeInfo.Items.Count;i++)
				{
					m_lsvPatientChargeInfo.Items[i].Checked =false;
				}
			}
		}
		private void Work_Changed(object sender, System.EventArgs e)
		{
			if(m_rbutWork1.Checked) Work =1;
			if(m_rbutWork2.Checked) Work =2;
			if(m_rbutWork3.Checked) Work =3;
			if(m_rbutWork4.Checked) Work =4;
			if(m_txtArea.Tag!=null && m_txtArea.Tag.ToString().Trim()!="" && m_txtArea.Text.Trim()!="")
			{
				try
				{
					if(((RadioButton)(sender)).Checked)
						m_cmdShow_Click(sender,e);
				}
				catch{}
			}
			else
			{
				m_txtArea.Focus();
			}
		}
		private void splitter1_DoubleClick(object sender, System.EventArgs e)
		{
            //if(splitter1.SplitPosition<280)
            //    splitter1.SplitPosition =1000;
            //else
            //    splitter1.SplitPosition =splitter1.MinSize;
            if (splitter1.SplitPosition < 150)
            {
                splitter1.SplitPosition = 300;
            }
            else 
            {
                splitter1.SplitPosition = 83;
            }
		}
		#endregion
		#region 公共方法	周浩	2005-03-15
		/// <summary>
		/// 设置查询条件
		/// </summary>
		/// <param name="AreaName">病区名称</param>
		/// <param name="AreaID">病区ID</param>
		/// <param name="Doctor">操作者ID</param>
		public void SetQueryCondition(string AreaName,string AreaID,string Doctor)
		{
			this.m_txtArea.Tag = AreaID;
			this.Cursor =Cursors.WaitCursor;
			((clsCtl_BIHOrderExecute)this.objController).m_FindOrder(AreaName,AreaID,"",Doctor);
			this.Cursor =Cursors.Default;
		}
		/// <summary>
		/// 设置查询条件
		/// </summary>
		/// <param name="AreaName">病区名称</param>
		/// <param name="AreaID">病区ID</param>
		/// <param name="strBedIDs">病床ID{多条记录用逗号分隔}</param>
		/// <param name="Doctor">操作者ID</param>
		public void SetQueryCondition(string AreaName,string AreaID,string strBedIDs,string Doctor)
		{
			this.m_txtArea.Tag = AreaID;
			m_BedIDs =strBedIDs;
			this.Cursor =Cursors.WaitCursor;
			((clsCtl_BIHOrderExecute)this.objController).m_FindOrder(AreaName,AreaID,strBedIDs,Doctor);
			this.Cursor =Cursors.Default;
		}
		#endregion
		#region 病区、病床
		private void m_txtArea_m_evtInitListView(System.Windows.Forms.ListView lvwList)
		{
			((clsCtl_BIHOrderExecute)this.objController).m_txtAreaInitListView(lvwList);		
		}

		private void m_txtArea_m_evtFindItem(object sender, string strFindCode, System.Windows.Forms.ListView lvwList)
		{
			((clsCtl_BIHOrderExecute)this.objController).m_txtAreaFindItem(strFindCode,lvwList);	
		}

		private void m_txtArea_m_evtSelectItem(object sender, System.Windows.Forms.ListViewItem lviSelected)
		{
			((clsCtl_BIHOrderExecute)this.objController).m_txtAreaSelectItem(lviSelected);	
 
			((clsCtl_BIHOrderExecute)this.objController).m_mthAlert(sender ,null);		 
            
            m_txtBed.Tag = null;
            m_txtBed.Text = "";
			m_txtBed.Focus();
		}
		private void m_lsvSelectBed_Leave(object sender, System.EventArgs e)
		{
			((clsCtl_BIHOrderExecute)this.objController).m_lsvSelectBedLeave();
		}
		private void m_lsvSelectBed_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				((clsCtl_BIHOrderExecute)this.objController).m_lsvSelectBedLeave();
                m_cmdShow.Focus();
			}
            else if (e.Modifiers == Keys.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.A:
                        selectAll();
                        break;
                    case Keys.Z:
                        selectAllNo();
                        break;
                    case Keys.X:
                        ConvertSelect();
                        break;
                }

            }

		}

        #region 床位选择快捷键
        private void selectAllNo()
        {
            for (int i = 0; i < m_lsvSelectBed.Items.Count; i++)
            {
                m_lsvSelectBed.Items[i].Checked = false;
            }
        }

        private void ConvertSelect()
        {
            for (int i = 0; i < m_lsvSelectBed.Items.Count; i++)
            {
                m_lsvSelectBed.Items[i].Checked = !m_lsvSelectBed.Items[i].Checked;
            }
        }

        private void selectAll()
        {
            for (int i = 0; i < m_lsvSelectBed.Items.Count; i++)
            {
                m_lsvSelectBed.Items[i].Checked = true;
            }
        }
        #endregion

		private void m_txtBed_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				((clsCtl_BIHOrderExecute)this.objController).m_txtBedKeyDown();
			}
		}

		private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}
		/// <summary>
		///  获取或设置病床	根据ID
		/// </summary>
		public string m_BedIDs
		{
			get
			{
				if(this.m_txtBed.Tag==null) this.m_txtBed.Tag ="";
				return this.m_txtBed.Tag.ToString().Trim();
			}
			set
			{
				string strText ="";
				string strID =value;
				string[] strIDArr =strID.Split(new char[]{','});
				if(m_lsvSelectBed.Items.Count<=0)
				{
					if(this.m_txtArea.Tag!=null && this.m_txtArea.Tag.ToString().Trim()!="")
					{
						((clsCtl_BIHOrderExecute)this.objController).LoadBedListView();					
					}
					else
					{
						return;
					}
				}
				clsT_Bse_Bed_VO objItem =new clsT_Bse_Bed_VO();
				for(int i1=0;i1<m_lsvSelectBed.Items.Count;i1++)
				{
					objItem =((m_lsvSelectBed.Items[i1].Tag) as clsT_Bse_Bed_VO);
					for(int i2=0;i2<strIDArr.Length;i2++)
					{
						if(objItem.m_strBEDID_CHR.Trim()==strIDArr[i2].Trim())
						{
							if(strText.Trim()=="") 
								strText =objItem.m_strCODE_CHR.Trim();
							else
								strText +="," + objItem.m_strCODE_CHR.Trim();
						}
					}
				}
				m_txtBed.Text =strText;
				m_txtBed.Tag =strID;
			}
		}
		#endregion
		#region 属性
		/// <summary>
		/// 获取或设置操作任务	{1=查看医嘱；2=审核提交；3=执行医嘱；4=审查停止；}
		/// </summary>
		public int Work
		{
			get
			{
				int intRes =3;//默认2
				if(m_rbutWork1.Checked) intRes =1;
				if(m_rbutWork2.Checked) intRes =2;
				if(m_rbutWork3.Checked) intRes =3;
				if(m_rbutWork4.Checked) intRes =4;
				return intRes;
			}
			set
			{
				int intWork =0;
				intWork =value;
				((clsCtl_BIHOrderExecute)this.objController).EmptyListView();
				if(intWork==1) m_rbutWork1.Checked =true;
				if(intWork==2) m_rbutWork2.Checked =true;
				if(intWork==3) m_rbutWork3.Checked =true;
				if(intWork==4) m_rbutWork4.Checked =true;
				SetControlEnabled(intWork);
			}
		}
		/// <summary>
		/// 设置控件的状态	根据任务
		/// </summary>
		/// <param name="intWork">操作任务	{1=查看医嘱；2=审核提交；3=执行医嘱；4=审查停止；}</param>
		private void SetControlEnabled(int intWork)
		{
			#region 初始化	单选控件
			//已提交
			m_chkStatus1.Checked =true;
			m_chkStatus1.Enabled =true;
			//已执行
			m_chkStatus2.Checked =true;
			m_chkStatus2.Enabled =true;
			//已停止
			m_chkStatus3.Checked =true;
			m_chkStatus3.Enabled =true;
			//已审核提交
			m_chkStatus5.Checked =true;
			m_chkStatus5.Enabled =true;
			//已审核停止
			m_chkStatus6.Checked =true;
			m_chkStatus6.Enabled =true;
			//长期
			m_chkLong.Checked =true;
			m_chkLong.Enabled =true;
			//临时
			m_chkTemp.Checked =true;
			m_chkTemp.Enabled =true;
			//出院摆药
			m_chktakeMedicine.Checked =false;
			m_chktakeMedicine.Enabled =true;
			//仅显当天
			m_chkOnlyToday.Checked =false;
			m_chkOnlyToday.Enabled =true;
			//仅显皮试
			m_chkNeedFeel.Checked =false;
			m_chkNeedFeel.Enabled =true;
			#endregion
			switch(intWork)
			{	//{1=查看医嘱；2=审核提交；3=执行医嘱；4=审查停止；}
				case 1:
					#region 查看医嘱
					//日期控件
					m_dtpStartExecute.Value =System.DateTime.Now;
					m_dtpStartExecute.Enabled =true;
					//按钮控件
					m_cmdShow.Enabled =true;
					m_cmdExecute.Enabled =false;
					m_cmdExecute.Text ="执行(F5)";
					cmdOnceAgain.Enabled =false;
					cmdEditFeel.Enabled =false;
					//ListView控件
					m_lsvOrderBaseInfo.CheckBoxes =false;
					m_lsvPatientChargeInfo.CheckBoxes =false;
					#endregion
					break;
				case 2:
					#region 审核提交
					//日期控件
					m_dtpStartExecute.Value =System.DateTime.Now;
					m_dtpStartExecute.Enabled =false;
					//按钮控件
					m_cmdShow.Enabled =true;
					m_cmdExecute.Enabled =true;
					m_cmdExecute.Text ="审核提交(F5)";
					cmdOnceAgain.Enabled =false;
					cmdEditFeel.Enabled =false;
					//ListView控件
					m_lsvOrderBaseInfo.CheckBoxes =true;
					m_lsvPatientChargeInfo.CheckBoxes =true;
					//单选控件
					//已执行
					m_chkStatus2.Checked =false;
					m_chkStatus2.Enabled =false;
					//已停止
					m_chkStatus3.Checked =false;
					m_chkStatus3.Enabled =false;
					//已审核提交
					m_chkStatus5.Checked =false;
					m_chkStatus5.Enabled =false;
					//已审核停止
					m_chkStatus6.Checked =false;
					m_chkStatus6.Enabled =false;
					#endregion
					break;
				case 3:
					#region 执行医嘱
					//日期控件
					m_dtpStartExecute.Value =System.DateTime.Now;
					m_dtpStartExecute.Enabled =false;
					//按钮控件
					m_cmdShow.Enabled =true;
					m_cmdExecute.Enabled =true;
					m_cmdExecute.Text ="执行(F5)"; 
                    cmdOnceAgain.Enabled = true; 
					cmdEditFeel.Enabled =false;
					//ListView控件
					m_lsvOrderBaseInfo.CheckBoxes =true;
					m_lsvPatientChargeInfo.CheckBoxes =true;
					//单选控件
					//已提交
					m_chkStatus1.Checked =false;
					m_chkStatus1.Enabled =false;
					//已停止
					m_chkStatus3.Checked =false;
					m_chkStatus3.Enabled =false;
					//已审核停止
					m_chkStatus6.Checked =false;
					m_chkStatus6.Enabled =false;
					#endregion
					break;
				case 4:
					#region 审查停止
					//日期控件
					m_dtpStartExecute.Value =System.DateTime.Now;
					m_dtpStartExecute.Enabled =false;
					//按钮控件
					m_cmdShow.Enabled =true;
					m_cmdExecute.Enabled =true;
					m_cmdExecute.Text ="审查停止(F5)";
					cmdOnceAgain.Enabled =false;
					cmdEditFeel.Enabled =false;
					//ListView控件
					m_lsvOrderBaseInfo.CheckBoxes =true;
					m_lsvPatientChargeInfo.CheckBoxes =true;
					//单选控件
					//已提交
					m_chkStatus1.Checked =false;
					m_chkStatus1.Enabled =false;
					//已执行
					m_chkStatus2.Checked =false;
					m_chkStatus2.Enabled =false;
					//已审核提交
					m_chkStatus5.Checked =false;
					m_chkStatus5.Enabled =false;
					//已审核停止
					m_chkStatus6.Checked =false;
					m_chkStatus6.Enabled =false;
					#endregion
					break;
			}
		}

		private void m_btnAddBills_Click(object sender, System.EventArgs e)
		{
			frmAddBillsViewer _frmAddBillsViewer=new frmAddBillsViewer();
			_frmAddBillsViewer.m_frmParent=null;
			_frmAddBillsViewer.m_intOpenbType=1;
			clsBIHCanExecOrder[] OrderBaseArr=((clsCtl_BIHOrderExecute)this.objController).m_objBIHCanExecOrderArr;
			_frmAddBillsViewer.m_objOrderArr=OrderBaseArr;
			_frmAddBillsViewer.ShowDialog(this);
		}
		/// <summary>
		/// 获取选取的执行状态字符串	{用逗号分隔；如“1,2,3”}
		/// 执行状态	{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5-已审核提交;6-已审核停止;}
		/// </summary>
		public string GetOrderStatus
		{
			get
			{
				string strRes ="";
				//已提交
				if(m_chkStatus1.Checked && m_chkStatus1.Enabled) strRes +=(strRes=="")?("1"):(",1");
				//已执行
				if(m_chkStatus2.Checked && m_chkStatus2.Enabled) strRes +=(strRes=="")?("2"):(",2");
				//已停止
				if(m_chkStatus3.Checked && m_chkStatus3.Enabled) strRes +=(strRes=="")?("3"):(",3");
				//已审核提交
				if(m_chkStatus5.Checked && m_chkStatus5.Enabled) strRes +=(strRes=="")?("5"):(",5");
				//已审核停止
				if(m_chkStatus6.Checked && m_chkStatus6.Enabled) strRes +=(strRes=="")?("6"):(",6");
				return strRes;
			}
		}
		/// <summary>
		/// 获取选取的医嘱类型字符串	{用逗号分隔；如“1,2”}
		/// 医嘱类型	{1=长期;2=临时}
		/// </summary>
		public string GetOrderType
		{
			get
			{
				string strRes ="";
				//长期
				if(m_chkLong.Checked && m_chkLong.Enabled) strRes +=(strRes=="")?("1"):(",1");
				//临时
				if(m_chkTemp.Checked && m_chkTemp.Enabled) strRes +=(strRes=="")?("2"):(",2");
				return strRes;
			}
		}
		#endregion

		#region Add by jli in 2005-04-20
		/// <summary>
		/// 查询医嘱的附加单据
		/// </summary>
		/// <param name="p_strOrderID">医嘱ID</param>
		/// <param name="dtbAddBills">附加单据列表</param>
		/// <returns></returns>
		public long m_lngGetAddBillByOrderID(string p_strOrderID,out DataTable dtbCurrAddBill)
		{
			dtbCurrAddBill=new DataTable();
			try
			{
				clsRelation_DTable dtbRes=new clsRelation_DTable();
				long lngRes=dtbRes.m_lngGetRelation(" sourceitemid_vchr='"+p_strOrderID.Trim()+"'");
				dtbCurrAddBill=dtbRes.m_dtbValues;
				return lngRes;
			}
			catch
			{
				return -1;
			}
		}
		#endregion		

        private void m_lsvToolTip_DoubleClick(object sender, EventArgs e)
        {
            if(m_lsvToolTip.SelectedItems.Count==0)
            {
                return;
            }
            clsCtl_BIHOrderExecute.clsOrderBaseInfo objItem = (clsCtl_BIHOrderExecute.clsOrderBaseInfo)m_lsvOrderBaseInfo.SelectedItems[0].Tag;

            if (objItem.m_objBIHCanExecOrder.m_intStatus == 0 || objItem.m_objBIHCanExecOrder.m_intStatus == 1 || objItem.m_objBIHCanExecOrder.m_intStatus == 5)
            {



                clsChargeForDisplay chargeItem = (clsChargeForDisplay)m_lsvToolTip.SelectedItems[0].Tag;
               
                string m_intType = chargeItem.m_intType.ToString();
                //if (m_intType.Trim().Equals("2"))
                //{
                //    MessageBox.Show("主收费项目不允许修改!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}


                string m_strSeq_int = chargeItem.m_strSeq_int.Trim();

                //MessageBox.Show(strOrderID);
                frmChargeItem frmCharge = new frmChargeItem(m_strSeq_int);
                //初始化类型信息
                try
                {
                    frmCharge.m_intType = int.Parse(m_intType);
                }
                catch
                {
                }
                /*<========================*/
                if (frmCharge.ShowDialog() == DialogResult.OK)
                {
                    if (m_lsvOrderBaseInfo.SelectedItems.Count != 1) return;
                    clsCtl_BIHOrderExecute.clsOrderBaseInfo objSelectItem = (clsCtl_BIHOrderExecute.clsOrderBaseInfo)m_lsvOrderBaseInfo.SelectedItems[0].Tag;
                    //显示费用信息

                    ((clsCtl_BIHOrderExecute)this.objController).m_htbToolTip.Remove(objSelectItem.m_objBIHCanExecOrder.m_strOrderID);
                    // objSelectItem.m_objBIHCanExecOrder.m_str
                    m_lsvOrderBaseInfo_SelectedIndexChanged(null, null);
                }
            }
        }

        private void buttonXP1_Click(object sender, EventArgs e)
        {
            if (m_lsvOrderBaseInfo.SelectedItems.Count == 0)
            {
                return;
            }
            
            clsCtl_BIHOrderExecute.clsOrderBaseInfo objItem = (clsCtl_BIHOrderExecute.clsOrderBaseInfo)m_lsvOrderBaseInfo.SelectedItems[0].Tag;

            if (objItem.m_objBIHCanExecOrder.m_intStatus == 0 || objItem.m_objBIHCanExecOrder.m_intStatus == 1 || objItem.m_objBIHCanExecOrder.m_intStatus == 5)
            {

                //MessageBox.Show(strOrderID);
                frmChargeItem frmCharge = new frmChargeItem(objItem);
                if (frmCharge.ShowDialog() == DialogResult.OK)
                {
                    if (m_lsvOrderBaseInfo.SelectedItems.Count != 1) return;
                    clsCtl_BIHOrderExecute.clsOrderBaseInfo objSelectItem = (clsCtl_BIHOrderExecute.clsOrderBaseInfo)m_lsvOrderBaseInfo.SelectedItems[0].Tag;
                    //显示费用信息

                    ((clsCtl_BIHOrderExecute)this.objController).m_htbToolTip.Remove(objSelectItem.m_objBIHCanExecOrder.m_strOrderID);
                    // objSelectItem.m_objBIHCanExecOrder.m_str
                    m_lsvOrderBaseInfo_SelectedIndexChanged(null, null);
                }
            }

        }

        private void buttonXP2_Click(object sender, EventArgs e)
        {
            if (m_lsvToolTip.SelectedItems.Count == 0)
            {
                return;
            }
            clsCtl_BIHOrderExecute.clsOrderBaseInfo objItem = (clsCtl_BIHOrderExecute.clsOrderBaseInfo)m_lsvOrderBaseInfo.SelectedItems[0].Tag;

            if (objItem.m_objBIHCanExecOrder.m_intStatus == 0 || objItem.m_objBIHCanExecOrder.m_intStatus == 1 || objItem.m_objBIHCanExecOrder.m_intStatus == 5)
            {

                clsChargeForDisplay chargeItem = (clsChargeForDisplay)m_lsvToolTip.SelectedItems[0].Tag;
                string m_intType = chargeItem.m_intType.ToString();
                //if (m_intType.Trim().Equals("2"))
                //{
                //    MessageBox.Show("主收费项目不允许修改!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

                string m_strSeq_int = chargeItem.m_strSeq_int.Trim();


                //MessageBox.Show(strOrderID);
                frmChargeItem frmCharge = new frmChargeItem(m_strSeq_int);
                //初始化类型信息
                try
                {
                    frmCharge.m_intType = int.Parse(m_intType);
                }
                catch
                {
                }
                /*<========================*/
                if (frmCharge.ShowDialog() == DialogResult.OK)
                {
                    if (m_lsvOrderBaseInfo.SelectedItems.Count != 1) return;
                    clsCtl_BIHOrderExecute.clsOrderBaseInfo objSelectItem = (clsCtl_BIHOrderExecute.clsOrderBaseInfo)m_lsvOrderBaseInfo.SelectedItems[0].Tag;
                    //显示费用信息

                    ((clsCtl_BIHOrderExecute)this.objController).m_htbToolTip.Remove(objSelectItem.m_objBIHCanExecOrder.m_strOrderID);
                    // objSelectItem.m_objBIHCanExecOrder.m_str
                    m_lsvOrderBaseInfo_SelectedIndexChanged(null, null);
                }
            }
          
        }

        private void buttonXP3_Click(object sender, EventArgs e)
        {

            if (m_lsvToolTip.SelectedItems.Count == 0)
            {
                return;
            }
            clsCtl_BIHOrderExecute.clsOrderBaseInfo objItem = (clsCtl_BIHOrderExecute.clsOrderBaseInfo)m_lsvOrderBaseInfo.SelectedItems[0].Tag;

            if (objItem.m_objBIHCanExecOrder.m_intStatus == 0 || objItem.m_objBIHCanExecOrder.m_intStatus == 1 || objItem.m_objBIHCanExecOrder.m_intStatus == 5)
            {

                clsChargeForDisplay chargeItem = (clsChargeForDisplay)m_lsvToolTip.SelectedItems[0].Tag;
                if (chargeItem.m_intType == 2)
                {
                    MessageBox.Show("主收费项目不允许修改!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string m_strSeq_int = chargeItem.m_strSeq_int.Trim();
                long reg = (new clsCtl_BIHOrderExecute()).m_lngDellORDERCHARGEDEPT(m_strSeq_int);
                if (reg <= 0)
                {
                    MessageBox.Show("删除失败!");
                }
                else
                {
                    if (m_lsvOrderBaseInfo.SelectedItems.Count != 1) return;
                    clsCtl_BIHOrderExecute.clsOrderBaseInfo objSelectItem = (clsCtl_BIHOrderExecute.clsOrderBaseInfo)m_lsvOrderBaseInfo.SelectedItems[0].Tag;
                    //显示费用信息

                    ((clsCtl_BIHOrderExecute)this.objController).m_htbToolTip.Remove(objSelectItem.m_objBIHCanExecOrder.m_strOrderID);
                    // objSelectItem.m_objBIHCanExecOrder.m_str
                    m_lsvOrderBaseInfo_SelectedIndexChanged(null, null);
                }
            }
           
        }
	}
}
