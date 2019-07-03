using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using com.digitalwave.iCare.gui.TemplateUtility; 
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmOPSRoom 的摘要说明。
	/// </summary>
	public class frmOPSRoom : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		internal UtilityLibrary.WinControls.OutlookBar outlookBar;
		private UtilityLibrary.WinControls.OutlookBarBand outlookBarBand1;
		private UtilityLibrary.WinControls.OutlookBarBand outlookBarBand2;
		private com.digitalwave.Utility.Controls.CollapsibleSplitter collapsibleSplitter;
		private System.Windows.Forms.Panel panel;
		private System.Windows.Forms.Panel panel1;
		internal System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Label lblStatus;
		internal System.Windows.Forms.ListView lvApply;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		internal System.Windows.Forms.ListView lvReport;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.ImageList imageList;
		internal System.Windows.Forms.Button btnRefresh;
		internal System.Windows.Forms.Button btnSave;
		internal System.Windows.Forms.Button btnAuditing;
		internal System.Windows.Forms.Panel panelApply;
		internal System.Windows.Forms.Panel panelReport;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label42;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.Label label45;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.Label label47;
		private System.Windows.Forms.Label label48;
		private System.Windows.Forms.Label label49;
		private System.Windows.Forms.Label label50;
		private System.Windows.Forms.Label label51;
		private System.Windows.Forms.Label label52;
		private System.Windows.Forms.Label label53;
		private System.Windows.Forms.Label label54;
		private System.Windows.Forms.Label label55;
		private System.Windows.Forms.Label label56;
		private System.Windows.Forms.Label label57;
		private System.Windows.Forms.Label label58;
		private System.Windows.Forms.Label label59;
		private System.Windows.Forms.Label label60;
		private System.Windows.Forms.Label label61;
		private System.Windows.Forms.Label label62;
		private System.Windows.Forms.Label label63;
		private System.Windows.Forms.Label label64;
		private System.Windows.Forms.Label label65;
		private System.Windows.Forms.Label label66;
		private System.Windows.Forms.Label label37;
		internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Label lblRepTitle;
		internal System.Windows.Forms.TextBox txtRepOPSName;
		internal System.Windows.Forms.TextBox txtRepDiagbegin;
		internal System.Windows.Forms.TextBox txtRepDiagend;
		internal System.Windows.Forms.TextBox txtRepMaindoctor;
		internal System.Windows.Forms.TextBox txtRepAssidoctor;
        internal System.Windows.Forms.TextBox txtRepMedtool;
		internal System.Windows.Forms.TextBox txtRepAnadoctor;
		internal com.digitalwave.controls.ctlRichTextBox txtRepOPSStepandResult;
		internal System.Windows.Forms.TextBox txtRepDoctor;
        internal System.Windows.Forms.TextBox txtRepSigndate;
        internal System.Windows.Forms.Label lblAppTitle;
		internal System.Windows.Forms.Label lblRepNO;
		internal System.Windows.Forms.Label lblAppNO;
		private System.ComponentModel.IContainer components;
		private Color Defaultcolor = Color.FromArgb(255,255,255);
        internal System.Windows.Forms.Button btnFind;
		internal System.Windows.Forms.Button btnPrint;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
        internal Label lblAppDept;
        internal Label lblAppCardNo;
        internal Label lblAppAge;
        internal Label lblAppSex;
        internal Label lblAppName;
        internal Label lblAppOPSName;
        internal Label lblAppMinute;
        internal Label lblAppHour;
        internal Label lblAppDay;
        internal Label lblAppMonth;
        internal Label lblAppYear;
        internal Label lblAppDate;
        internal Label lblAppDoctor;
        internal Label lblAppHint;
        private Label label38;
        internal Label lblRepYear;
        internal Label lblRepDept;
        internal Label lblRepCardNo;
        internal Label lblRepAge;
        internal Label lblRepSex;
        internal Label lblRepName;
        internal Label lblRepDay;
        internal Label lblRepMonth;
        internal Label label39;
        internal Label label41;
        internal Label label40;
        internal Label label69;
        internal Label label68;
        internal Label label67;
        internal Label label72;
        internal Label label71;
        internal Label label70;
        internal Label lblRepsave;
        internal ComboBox cboAnamode;
        internal Label label43;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem ToolStripMenuItemApp;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem ToolStripMenuItemRep;
        private ContextMenu contextMenu1;
        private MenuItem menu_Template;
        private MenuItem menu_CreatTemplate;
        private MenuItem menu_changeTemplate;
        private MenuItem menu_Cut;
        private MenuItem menu_Copy;
        private MenuItem menuI_Paste;
        private MenuItem menuI_Undo;
        private MenuItem menuItem1;
        public CheckBox m_chkTui;
		private Color Focuscolor = Color.FromArgb(222,239,165);
		
		public frmOPSRoom()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}
        public bool m_blnCanDo = true;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOPSRoom));
            this.outlookBar = new UtilityLibrary.WinControls.OutlookBar();
            this.outlookBarBand1 = new UtilityLibrary.WinControls.OutlookBarBand();
            this.lvApply = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.outlookBarBand2 = new UtilityLibrary.WinControls.OutlookBarBand();
            this.lvReport = new System.Windows.Forms.ListView();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.collapsibleSplitter = new com.digitalwave.Utility.Controls.CollapsibleSplitter();
            this.panel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.panelReport = new System.Windows.Forms.Panel();
            this.cboAnamode = new System.Windows.Forms.ComboBox();
            this.label43 = new System.Windows.Forms.Label();
            this.lblRepsave = new System.Windows.Forms.Label();
            this.txtRepAssidoctor = new System.Windows.Forms.TextBox();
            this.label72 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.txtRepMaindoctor = new System.Windows.Forms.TextBox();
            this.label70 = new System.Windows.Forms.Label();
            this.txtRepSigndate = new System.Windows.Forms.TextBox();
            this.label69 = new System.Windows.Forms.Label();
            this.txtRepDoctor = new System.Windows.Forms.TextBox();
            this.label68 = new System.Windows.Forms.Label();
            this.txtRepAnadoctor = new System.Windows.Forms.TextBox();
            this.label67 = new System.Windows.Forms.Label();
            this.txtRepDiagend = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.txtRepDiagbegin = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.txtRepOPSName = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.lblRepDept = new System.Windows.Forms.Label();
            this.lblRepCardNo = new System.Windows.Forms.Label();
            this.lblRepAge = new System.Windows.Forms.Label();
            this.lblRepSex = new System.Windows.Forms.Label();
            this.lblRepName = new System.Windows.Forms.Label();
            this.lblRepDay = new System.Windows.Forms.Label();
            this.lblRepMonth = new System.Windows.Forms.Label();
            this.lblRepYear = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.lblRepNO = new System.Windows.Forms.Label();
            this.txtRepOPSStepandResult = new com.digitalwave.controls.ctlRichTextBox();
            this.txtRepMedtool = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.lblRepTitle = new System.Windows.Forms.Label();
            this.panelApply = new System.Windows.Forms.Panel();
            this.lblAppHint = new System.Windows.Forms.Label();
            this.lblAppDate = new System.Windows.Forms.Label();
            this.lblAppDoctor = new System.Windows.Forms.Label();
            this.lblAppMinute = new System.Windows.Forms.Label();
            this.lblAppHour = new System.Windows.Forms.Label();
            this.lblAppDay = new System.Windows.Forms.Label();
            this.lblAppMonth = new System.Windows.Forms.Label();
            this.lblAppYear = new System.Windows.Forms.Label();
            this.lblAppOPSName = new System.Windows.Forms.Label();
            this.lblAppDept = new System.Windows.Forms.Label();
            this.lblAppCardNo = new System.Windows.Forms.Label();
            this.lblAppAge = new System.Windows.Forms.Label();
            this.lblAppSex = new System.Windows.Forms.Label();
            this.lblAppName = new System.Windows.Forms.Label();
            this.lblAppNO = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_chkTui = new System.Windows.Forms.CheckBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAuditing = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemApp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemRep = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menu_Template = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menu_CreatTemplate = new System.Windows.Forms.MenuItem();
            this.menu_changeTemplate = new System.Windows.Forms.MenuItem();
            this.menu_Cut = new System.Windows.Forms.MenuItem();
            this.menu_Copy = new System.Windows.Forms.MenuItem();
            this.menuI_Paste = new System.Windows.Forms.MenuItem();
            this.menuI_Undo = new System.Windows.Forms.MenuItem();
            this.panel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panelReport.SuspendLayout();
            this.panelApply.SuspendLayout();
            this.panel3.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // outlookBar
            // 
            this.outlookBar.AnimationSpeed = 1;
            this.outlookBar.Bands.Add(this.outlookBarBand1);
            this.outlookBar.Bands.Add(this.outlookBarBand2);
            this.outlookBar.CurrentBand = 0;
            this.outlookBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.outlookBar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outlookBar.ItemsCheckStyle = UtilityLibrary.WinControls.OutlookBarCheckStyle.ItemsAsCheckBoxes;
            this.outlookBar.LeftTopColor = System.Drawing.Color.Empty;
            this.outlookBar.Location = new System.Drawing.Point(0, 0);
            this.outlookBar.Name = "outlookBar";
            this.outlookBar.QuietMode = false;
            this.outlookBar.RightBottomColor = System.Drawing.Color.Empty;
            this.outlookBar.Size = new System.Drawing.Size(222, 647);
            this.outlookBar.TabIndex = 0;
            // 
            // outlookBarBand1
            // 
            this.outlookBarBand1.Background = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(217)))), ((int)(((byte)(211)))));
            this.outlookBarBand1.ChildControl = this.lvApply;
            this.outlookBarBand1.IconView = UtilityLibrary.WinControls.IconView.Small;
            this.outlookBarBand1.Location = new System.Drawing.Point(0, 0);
            this.outlookBarBand1.Name = "outlookBarBand1";
            this.outlookBarBand1.Size = new System.Drawing.Size(0, 0);
            this.outlookBarBand1.SmallImageList = this.imageList;
            this.outlookBarBand1.TabIndex = 0;
            this.outlookBarBand1.Text = "手术申请单列表";
            this.outlookBarBand1.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // lvApply
            // 
            this.lvApply.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader11,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvApply.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvApply.FullRowSelect = true;
            this.lvApply.GridLines = true;
            this.lvApply.HideSelection = false;
            this.lvApply.Location = new System.Drawing.Point(0, 23);
            this.lvApply.Name = "lvApply";
            this.lvApply.Size = new System.Drawing.Size(222, 601);
            this.lvApply.TabIndex = 50;
            this.lvApply.UseCompatibleStateImageBehavior = false;
            this.lvApply.View = System.Windows.Forms.View.Details;
            this.lvApply.SelectedIndexChanged += new System.EventHandler(this.lvApply_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "单号";
            this.columnHeader1.Width = 41;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "手术科室";
            this.columnHeader11.Width = 88;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "姓名";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 57;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "性别";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 42;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "年龄";
            this.columnHeader4.Width = 41;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "预约时间";
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "");
            // 
            // outlookBarBand2
            // 
            this.outlookBarBand2.Background = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(217)))), ((int)(((byte)(211)))));
            this.outlookBarBand2.ChildControl = this.lvReport;
            this.outlookBarBand2.IconView = UtilityLibrary.WinControls.IconView.Small;
            this.outlookBarBand2.Location = new System.Drawing.Point(0, 0);
            this.outlookBarBand2.Name = "outlookBarBand2";
            this.outlookBarBand2.Size = new System.Drawing.Size(0, 0);
            this.outlookBarBand2.SmallImageList = this.imageList;
            this.outlookBarBand2.TabIndex = 0;
            this.outlookBarBand2.Text = "手术报告单列表";
            this.outlookBarBand2.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // lvReport
            // 
            this.lvReport.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader12,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.lvReport.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvReport.FullRowSelect = true;
            this.lvReport.GridLines = true;
            this.lvReport.HideSelection = false;
            this.lvReport.Location = new System.Drawing.Point(4, 248);
            this.lvReport.MultiSelect = false;
            this.lvReport.Name = "lvReport";
            this.lvReport.Size = new System.Drawing.Size(212, 208);
            this.lvReport.TabIndex = 51;
            this.lvReport.UseCompatibleStateImageBehavior = false;
            this.lvReport.View = System.Windows.Forms.View.Details;
            this.lvReport.SelectedIndexChanged += new System.EventHandler(this.lvReport_SelectedIndexChanged);
            this.lvReport.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvReport_MouseDown);
            this.lvReport.Click += new System.EventHandler(this.lvReport_Click);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "单号";
            this.columnHeader6.Width = 41;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "手术科室";
            this.columnHeader12.Width = 92;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "姓名";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 57;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "性别";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader8.Width = 42;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "年龄";
            this.columnHeader9.Width = 41;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "确认时间";
            // 
            // collapsibleSplitter
            // 
            this.collapsibleSplitter.AnimationDelay = 20;
            this.collapsibleSplitter.AnimationStep = 20;
            this.collapsibleSplitter.BorderStyle3D = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.collapsibleSplitter.ControlToHide = this.outlookBar;
            this.collapsibleSplitter.ExpandParentForm = false;
            this.collapsibleSplitter.Location = new System.Drawing.Point(222, 0);
            this.collapsibleSplitter.Name = "collapsibleSplitter";
            this.collapsibleSplitter.Size = new System.Drawing.Size(8, 647);
            this.collapsibleSplitter.TabIndex = 1;
            this.collapsibleSplitter.TabStop = false;
            this.collapsibleSplitter.UseAnimations = false;
            this.collapsibleSplitter.VisualStyle = com.digitalwave.Utility.Controls.VisualStyles.XP;
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.SystemColors.Control;
            this.panel.Controls.Add(this.panel2);
            this.panel.Controls.Add(this.panel3);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(230, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(786, 647);
            this.panel.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(0, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 605);
            this.panel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox);
            this.panel1.Controls.Add(this.panelReport);
            this.panel1.Controls.Add(this.panelApply);
            this.panel1.Location = new System.Drawing.Point(8, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(766, 588);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(766, 52);
            this.pictureBox.TabIndex = 21;
            this.pictureBox.TabStop = false;
            // 
            // panelReport
            // 
            this.panelReport.Controls.Add(this.cboAnamode);
            this.panelReport.Controls.Add(this.label43);
            this.panelReport.Controls.Add(this.lblRepsave);
            this.panelReport.Controls.Add(this.txtRepAssidoctor);
            this.panelReport.Controls.Add(this.label72);
            this.panelReport.Controls.Add(this.label71);
            this.panelReport.Controls.Add(this.txtRepMaindoctor);
            this.panelReport.Controls.Add(this.label70);
            this.panelReport.Controls.Add(this.txtRepSigndate);
            this.panelReport.Controls.Add(this.label69);
            this.panelReport.Controls.Add(this.txtRepDoctor);
            this.panelReport.Controls.Add(this.label68);
            this.panelReport.Controls.Add(this.txtRepAnadoctor);
            this.panelReport.Controls.Add(this.label67);
            this.panelReport.Controls.Add(this.txtRepDiagend);
            this.panelReport.Controls.Add(this.label41);
            this.panelReport.Controls.Add(this.txtRepDiagbegin);
            this.panelReport.Controls.Add(this.label40);
            this.panelReport.Controls.Add(this.txtRepOPSName);
            this.panelReport.Controls.Add(this.label39);
            this.panelReport.Controls.Add(this.lblRepDept);
            this.panelReport.Controls.Add(this.lblRepCardNo);
            this.panelReport.Controls.Add(this.lblRepAge);
            this.panelReport.Controls.Add(this.lblRepSex);
            this.panelReport.Controls.Add(this.lblRepName);
            this.panelReport.Controls.Add(this.lblRepDay);
            this.panelReport.Controls.Add(this.lblRepMonth);
            this.panelReport.Controls.Add(this.lblRepYear);
            this.panelReport.Controls.Add(this.label38);
            this.panelReport.Controls.Add(this.lblRepNO);
            this.panelReport.Controls.Add(this.txtRepOPSStepandResult);
            this.panelReport.Controls.Add(this.txtRepMedtool);
            this.panelReport.Controls.Add(this.label37);
            this.panelReport.Controls.Add(this.label66);
            this.panelReport.Controls.Add(this.label65);
            this.panelReport.Controls.Add(this.label64);
            this.panelReport.Controls.Add(this.label63);
            this.panelReport.Controls.Add(this.label62);
            this.panelReport.Controls.Add(this.label61);
            this.panelReport.Controls.Add(this.label60);
            this.panelReport.Controls.Add(this.label59);
            this.panelReport.Controls.Add(this.label58);
            this.panelReport.Controls.Add(this.label57);
            this.panelReport.Controls.Add(this.label56);
            this.panelReport.Controls.Add(this.label55);
            this.panelReport.Controls.Add(this.label54);
            this.panelReport.Controls.Add(this.label53);
            this.panelReport.Controls.Add(this.label52);
            this.panelReport.Controls.Add(this.label51);
            this.panelReport.Controls.Add(this.label50);
            this.panelReport.Controls.Add(this.label49);
            this.panelReport.Controls.Add(this.label48);
            this.panelReport.Controls.Add(this.label47);
            this.panelReport.Controls.Add(this.label46);
            this.panelReport.Controls.Add(this.label45);
            this.panelReport.Controls.Add(this.label44);
            this.panelReport.Controls.Add(this.label34);
            this.panelReport.Controls.Add(this.label42);
            this.panelReport.Controls.Add(this.label36);
            this.panelReport.Controls.Add(this.label35);
            this.panelReport.Controls.Add(this.lblRepTitle);
            this.panelReport.Location = new System.Drawing.Point(8, 32);
            this.panelReport.Name = "panelReport";
            this.panelReport.Size = new System.Drawing.Size(752, 552);
            this.panelReport.TabIndex = 23;
            // 
            // cboAnamode
            // 
            this.cboAnamode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnamode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboAnamode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboAnamode.FormattingEnabled = true;
            this.cboAnamode.Location = new System.Drawing.Point(95, 222);
            this.cboAnamode.Name = "cboAnamode";
            this.cboAnamode.Size = new System.Drawing.Size(201, 22);
            this.cboAnamode.TabIndex = 88;
            // 
            // label43
            // 
            this.label43.AccessibleName = "T";
            this.label43.Font = new System.Drawing.Font("宋体", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label43.Location = new System.Drawing.Point(92, 239);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(188, 8);
            this.label43.TabIndex = 89;
            this.label43.Text = "................................................................................." +
                "................";
            // 
            // lblRepsave
            // 
            this.lblRepsave.AutoSize = true;
            this.lblRepsave.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRepsave.ForeColor = System.Drawing.Color.Blue;
            this.lblRepsave.Location = new System.Drawing.Point(692, 4);
            this.lblRepsave.Name = "lblRepsave";
            this.lblRepsave.Size = new System.Drawing.Size(0, 16);
            this.lblRepsave.TabIndex = 87;
            // 
            // txtRepAssidoctor
            // 
            this.txtRepAssidoctor.AccessibleName = "T";
            this.txtRepAssidoctor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRepAssidoctor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRepAssidoctor.Location = new System.Drawing.Point(284, 194);
            this.txtRepAssidoctor.Name = "txtRepAssidoctor";
            this.txtRepAssidoctor.Size = new System.Drawing.Size(100, 16);
            this.txtRepAssidoctor.TabIndex = 57;
            this.txtRepAssidoctor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRepAssidoctor_KeyDown);
            // 
            // label72
            // 
            this.label72.AccessibleName = "T";
            this.label72.Font = new System.Drawing.Font("宋体", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label72.Location = new System.Drawing.Point(484, 207);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(100, 8);
            this.label72.TabIndex = 86;
            this.label72.Text = "................................................................................." +
                "................";
            // 
            // label71
            // 
            this.label71.AccessibleName = "T";
            this.label71.Font = new System.Drawing.Font("宋体", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label71.Location = new System.Drawing.Point(284, 207);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(100, 8);
            this.label71.TabIndex = 85;
            this.label71.Text = "................................................................................." +
                "................";
            // 
            // txtRepMaindoctor
            // 
            this.txtRepMaindoctor.AccessibleName = "T";
            this.txtRepMaindoctor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRepMaindoctor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRepMaindoctor.Location = new System.Drawing.Point(96, 194);
            this.txtRepMaindoctor.Name = "txtRepMaindoctor";
            this.txtRepMaindoctor.Size = new System.Drawing.Size(100, 16);
            this.txtRepMaindoctor.TabIndex = 56;
            this.txtRepMaindoctor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRepMaindoctor_KeyDown);
            // 
            // label70
            // 
            this.label70.AccessibleName = "T";
            this.label70.Font = new System.Drawing.Font("宋体", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label70.Location = new System.Drawing.Point(96, 207);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(100, 8);
            this.label70.TabIndex = 84;
            this.label70.Text = "................................................................................." +
                "................";
            // 
            // txtRepSigndate
            // 
            this.txtRepSigndate.AccessibleName = "T";
            this.txtRepSigndate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRepSigndate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRepSigndate.Location = new System.Drawing.Point(564, 501);
            this.txtRepSigndate.Name = "txtRepSigndate";
            this.txtRepSigndate.Size = new System.Drawing.Size(160, 16);
            this.txtRepSigndate.TabIndex = 63;
            // 
            // label69
            // 
            this.label69.AccessibleName = "T";
            this.label69.Font = new System.Drawing.Font("宋体", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label69.Location = new System.Drawing.Point(564, 515);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(160, 8);
            this.label69.TabIndex = 83;
            this.label69.Text = "................................................................................." +
                "................";
            // 
            // txtRepDoctor
            // 
            this.txtRepDoctor.AccessibleName = "T";
            this.txtRepDoctor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRepDoctor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRepDoctor.Location = new System.Drawing.Point(564, 477);
            this.txtRepDoctor.Name = "txtRepDoctor";
            this.txtRepDoctor.Size = new System.Drawing.Size(160, 16);
            this.txtRepDoctor.TabIndex = 62;
            this.txtRepDoctor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRepDoctor_KeyDown);
            // 
            // label68
            // 
            this.label68.AccessibleName = "T";
            this.label68.Font = new System.Drawing.Font("宋体", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label68.Location = new System.Drawing.Point(564, 491);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(160, 8);
            this.label68.TabIndex = 82;
            this.label68.Text = "................................................................................." +
                "................";
            // 
            // txtRepAnadoctor
            // 
            this.txtRepAnadoctor.AccessibleName = "T";
            this.txtRepAnadoctor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRepAnadoctor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRepAnadoctor.Location = new System.Drawing.Point(372, 225);
            this.txtRepAnadoctor.Name = "txtRepAnadoctor";
            this.txtRepAnadoctor.Size = new System.Drawing.Size(100, 16);
            this.txtRepAnadoctor.TabIndex = 60;
            this.txtRepAnadoctor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRepAnadoctor_KeyDown);
            // 
            // label67
            // 
            this.label67.AccessibleName = "T";
            this.label67.Font = new System.Drawing.Font("宋体", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label67.Location = new System.Drawing.Point(372, 239);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(100, 8);
            this.label67.TabIndex = 81;
            this.label67.Text = "................................................................................." +
                "................";
            // 
            // txtRepDiagend
            // 
            this.txtRepDiagend.AccessibleName = "T";
            this.txtRepDiagend.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRepDiagend.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRepDiagend.Location = new System.Drawing.Point(112, 161);
            this.txtRepDiagend.Name = "txtRepDiagend";
            this.txtRepDiagend.Size = new System.Drawing.Size(620, 16);
            this.txtRepDiagend.TabIndex = 55;
            this.txtRepDiagend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRepDiagend_KeyDown);
            // 
            // label41
            // 
            this.label41.AccessibleName = "T";
            this.label41.Font = new System.Drawing.Font("宋体", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label41.Location = new System.Drawing.Point(112, 175);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(620, 8);
            this.label41.TabIndex = 79;
            this.label41.Text = "................................................................................." +
                "................................................................................" +
                "........................";
            // 
            // txtRepDiagbegin
            // 
            this.txtRepDiagbegin.AccessibleName = "T";
            this.txtRepDiagbegin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRepDiagbegin.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRepDiagbegin.Location = new System.Drawing.Point(112, 129);
            this.txtRepDiagbegin.Name = "txtRepDiagbegin";
            this.txtRepDiagbegin.Size = new System.Drawing.Size(620, 16);
            this.txtRepDiagbegin.TabIndex = 54;
            this.txtRepDiagbegin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRepDiagbegin_KeyDown);
            // 
            // label40
            // 
            this.label40.AccessibleName = "T";
            this.label40.Font = new System.Drawing.Font("宋体", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label40.Location = new System.Drawing.Point(112, 143);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(620, 8);
            this.label40.TabIndex = 78;
            this.label40.Text = "................................................................................." +
                "................................................................................" +
                "........................";
            // 
            // txtRepOPSName
            // 
            this.txtRepOPSName.AccessibleName = "T";
            this.txtRepOPSName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRepOPSName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRepOPSName.Location = new System.Drawing.Point(112, 97);
            this.txtRepOPSName.Name = "txtRepOPSName";
            this.txtRepOPSName.Size = new System.Drawing.Size(620, 16);
            this.txtRepOPSName.TabIndex = 53;
            this.txtRepOPSName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRepOPSName_KeyDown);
            // 
            // label39
            // 
            this.label39.AccessibleName = "T";
            this.label39.Font = new System.Drawing.Font("宋体", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label39.Location = new System.Drawing.Point(112, 111);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(620, 8);
            this.label39.TabIndex = 77;
            this.label39.Text = "................................................................................." +
                "................................................................................" +
                "........................";
            // 
            // lblRepDept
            // 
            this.lblRepDept.AccessibleName = "T";
            this.lblRepDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRepDept.Location = new System.Drawing.Point(641, 66);
            this.lblRepDept.Name = "lblRepDept";
            this.lblRepDept.Size = new System.Drawing.Size(96, 20);
            this.lblRepDept.TabIndex = 76;
            this.lblRepDept.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRepCardNo
            // 
            this.lblRepCardNo.AccessibleName = "T";
            this.lblRepCardNo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRepCardNo.Location = new System.Drawing.Point(480, 66);
            this.lblRepCardNo.Name = "lblRepCardNo";
            this.lblRepCardNo.Size = new System.Drawing.Size(96, 20);
            this.lblRepCardNo.TabIndex = 75;
            this.lblRepCardNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRepAge
            // 
            this.lblRepAge.AccessibleName = "T";
            this.lblRepAge.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRepAge.Location = new System.Drawing.Point(248, 66);
            this.lblRepAge.Name = "lblRepAge";
            this.lblRepAge.Size = new System.Drawing.Size(44, 20);
            this.lblRepAge.TabIndex = 74;
            this.lblRepAge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRepSex
            // 
            this.lblRepSex.AccessibleName = "T";
            this.lblRepSex.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRepSex.Location = new System.Drawing.Point(168, 66);
            this.lblRepSex.Name = "lblRepSex";
            this.lblRepSex.Size = new System.Drawing.Size(40, 20);
            this.lblRepSex.TabIndex = 73;
            this.lblRepSex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRepName
            // 
            this.lblRepName.AccessibleName = "T";
            this.lblRepName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRepName.Location = new System.Drawing.Point(60, 66);
            this.lblRepName.Name = "lblRepName";
            this.lblRepName.Size = new System.Drawing.Size(64, 20);
            this.lblRepName.TabIndex = 72;
            this.lblRepName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRepDay
            // 
            this.lblRepDay.AccessibleName = "T";
            this.lblRepDay.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRepDay.Location = new System.Drawing.Point(376, 39);
            this.lblRepDay.Name = "lblRepDay";
            this.lblRepDay.Size = new System.Drawing.Size(36, 20);
            this.lblRepDay.TabIndex = 71;
            this.lblRepDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRepMonth
            // 
            this.lblRepMonth.AccessibleName = "T";
            this.lblRepMonth.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRepMonth.Location = new System.Drawing.Point(324, 39);
            this.lblRepMonth.Name = "lblRepMonth";
            this.lblRepMonth.Size = new System.Drawing.Size(36, 20);
            this.lblRepMonth.TabIndex = 70;
            this.lblRepMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRepYear
            // 
            this.lblRepYear.AccessibleName = "T";
            this.lblRepYear.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRepYear.Location = new System.Drawing.Point(256, 39);
            this.lblRepYear.Name = "lblRepYear";
            this.lblRepYear.Size = new System.Drawing.Size(52, 20);
            this.lblRepYear.TabIndex = 69;
            this.lblRepYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label38
            // 
            this.label38.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label38.Location = new System.Drawing.Point(20, 67);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(52, 20);
            this.label38.TabIndex = 68;
            this.label38.Text = "姓名：";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRepNO
            // 
            this.lblRepNO.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRepNO.ForeColor = System.Drawing.Color.Black;
            this.lblRepNO.Location = new System.Drawing.Point(8, 4);
            this.lblRepNO.Name = "lblRepNO";
            this.lblRepNO.Size = new System.Drawing.Size(120, 20);
            this.lblRepNO.TabIndex = 67;
            this.lblRepNO.Text = "NO：";
            this.lblRepNO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRepOPSStepandResult
            // 
            this.txtRepOPSStepandResult.AccessibleName = "T";
            this.txtRepOPSStepandResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRepOPSStepandResult.Location = new System.Drawing.Point(24, 280);
            this.txtRepOPSStepandResult.m_BlnIgnoreUserInfo = true;
            this.txtRepOPSStepandResult.m_BlnPartControl = false;
            this.txtRepOPSStepandResult.m_BlnReadOnly = false;
            this.txtRepOPSStepandResult.m_BlnUnderLineDST = false;
            this.txtRepOPSStepandResult.m_ClrDST = System.Drawing.Color.Red;
            this.txtRepOPSStepandResult.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtRepOPSStepandResult.m_IntCanModifyTime = 500;
            this.txtRepOPSStepandResult.m_IntPartControlLength = 0;
            this.txtRepOPSStepandResult.m_IntPartControlStartIndex = 0;
            this.txtRepOPSStepandResult.m_StrUserID = "";
            this.txtRepOPSStepandResult.m_StrUserName = "";
            this.txtRepOPSStepandResult.Name = "txtRepOPSStepandResult";
            this.txtRepOPSStepandResult.Size = new System.Drawing.Size(712, 192);
            this.txtRepOPSStepandResult.TabIndex = 61;
            this.txtRepOPSStepandResult.Text = "";
            // 
            // txtRepMedtool
            // 
            this.txtRepMedtool.AccessibleName = "T";
            this.txtRepMedtool.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRepMedtool.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRepMedtool.Location = new System.Drawing.Point(484, 194);
            this.txtRepMedtool.Name = "txtRepMedtool";
            this.txtRepMedtool.Size = new System.Drawing.Size(100, 16);
            this.txtRepMedtool.TabIndex = 58;
            this.txtRepMedtool.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRepMedtool_KeyDown);
            // 
            // label37
            // 
            this.label37.BackColor = System.Drawing.Color.Black;
            this.label37.Location = new System.Drawing.Point(14, 248);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(724, 1);
            this.label37.TabIndex = 46;
            // 
            // label66
            // 
            this.label66.BackColor = System.Drawing.Color.Black;
            this.label66.Location = new System.Drawing.Point(14, 216);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(724, 1);
            this.label66.TabIndex = 45;
            // 
            // label65
            // 
            this.label65.BackColor = System.Drawing.Color.Black;
            this.label65.Location = new System.Drawing.Point(14, 184);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(724, 1);
            this.label65.TabIndex = 44;
            // 
            // label64
            // 
            this.label64.BackColor = System.Drawing.Color.Black;
            this.label64.Location = new System.Drawing.Point(14, 152);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(724, 1);
            this.label64.TabIndex = 43;
            // 
            // label63
            // 
            this.label63.BackColor = System.Drawing.Color.Black;
            this.label63.Location = new System.Drawing.Point(738, 88);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(1, 436);
            this.label63.TabIndex = 42;
            // 
            // label62
            // 
            this.label62.BackColor = System.Drawing.Color.Black;
            this.label62.Location = new System.Drawing.Point(14, 524);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(724, 1);
            this.label62.TabIndex = 41;
            // 
            // label61
            // 
            this.label61.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label61.Location = new System.Drawing.Point(480, 500);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(80, 20);
            this.label61.TabIndex = 40;
            this.label61.Text = "签名时间：";
            this.label61.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label60
            // 
            this.label60.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label60.Location = new System.Drawing.Point(480, 476);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(80, 20);
            this.label60.TabIndex = 39;
            this.label60.Text = "医生签名：";
            this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label59
            // 
            this.label59.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label59.Location = new System.Drawing.Point(24, 256);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(120, 20);
            this.label59.TabIndex = 38;
            this.label59.Text = "手术步骤与意见：";
            this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label58
            // 
            this.label58.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label58.Location = new System.Drawing.Point(308, 224);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(64, 20);
            this.label58.TabIndex = 37;
            this.label58.Text = "麻醉者：";
            this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label57
            // 
            this.label57.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label57.Location = new System.Drawing.Point(24, 224);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(80, 20);
            this.label57.TabIndex = 36;
            this.label57.Text = "麻醉方式：";
            this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label56
            // 
            this.label56.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label56.Location = new System.Drawing.Point(428, 192);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(52, 20);
            this.label56.TabIndex = 35;
            this.label56.Text = "司械：";
            this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label55
            // 
            this.label55.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label55.Location = new System.Drawing.Point(228, 192);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(52, 20);
            this.label55.TabIndex = 34;
            this.label55.Text = "助手：";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label54
            // 
            this.label54.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label54.Location = new System.Drawing.Point(24, 192);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(64, 20);
            this.label54.TabIndex = 33;
            this.label54.Text = "手术者：";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label53
            // 
            this.label53.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label53.Location = new System.Drawing.Point(24, 160);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(92, 20);
            this.label53.TabIndex = 32;
            this.label53.Text = "手术后诊断：";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label52
            // 
            this.label52.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label52.Location = new System.Drawing.Point(24, 128);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(92, 20);
            this.label52.TabIndex = 31;
            this.label52.Text = "手术前诊断：";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label51
            // 
            this.label51.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label51.Location = new System.Drawing.Point(24, 96);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(80, 20);
            this.label51.TabIndex = 30;
            this.label51.Text = "手术名称：";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label50
            // 
            this.label50.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label50.Location = new System.Drawing.Point(573, 67);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(80, 20);
            this.label50.TabIndex = 29;
            this.label50.Text = "手术科室：";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label49
            // 
            this.label49.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label49.Location = new System.Drawing.Point(380, 67);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(108, 20);
            this.label49.TabIndex = 28;
            this.label49.Text = "门诊诊疗卡号：";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label48
            // 
            this.label48.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label48.Location = new System.Drawing.Point(296, 67);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(64, 20);
            this.label48.TabIndex = 27;
            this.label48.Text = "住院号：";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label47
            // 
            this.label47.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label47.Location = new System.Drawing.Point(208, 67);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(52, 20);
            this.label47.TabIndex = 26;
            this.label47.Text = "年龄：";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label46
            // 
            this.label46.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label46.Location = new System.Drawing.Point(128, 67);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(52, 20);
            this.label46.TabIndex = 25;
            this.label46.Text = "性别：";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label45
            // 
            this.label45.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label45.Location = new System.Drawing.Point(412, 40);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(16, 20);
            this.label45.TabIndex = 24;
            this.label45.Text = "日";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label44
            // 
            this.label44.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label44.Location = new System.Drawing.Point(360, 40);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(16, 20);
            this.label44.TabIndex = 23;
            this.label44.Text = "月";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label34
            // 
            this.label34.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label34.Location = new System.Drawing.Point(308, 40);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(16, 20);
            this.label34.TabIndex = 22;
            this.label34.Text = "年";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label42
            // 
            this.label42.BackColor = System.Drawing.Color.Black;
            this.label42.Location = new System.Drawing.Point(14, 120);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(724, 1);
            this.label42.TabIndex = 20;
            // 
            // label36
            // 
            this.label36.BackColor = System.Drawing.Color.Black;
            this.label36.Location = new System.Drawing.Point(14, 88);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(1, 436);
            this.label36.TabIndex = 14;
            // 
            // label35
            // 
            this.label35.BackColor = System.Drawing.Color.Black;
            this.label35.Location = new System.Drawing.Point(14, 88);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(724, 1);
            this.label35.TabIndex = 2;
            // 
            // lblRepTitle
            // 
            this.lblRepTitle.Font = new System.Drawing.Font("黑体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRepTitle.Location = new System.Drawing.Point(14, 4);
            this.lblRepTitle.Name = "lblRepTitle";
            this.lblRepTitle.Size = new System.Drawing.Size(724, 32);
            this.lblRepTitle.TabIndex = 1;
            this.lblRepTitle.Text = "门诊手术记录单";
            this.lblRepTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelApply
            // 
            this.panelApply.Controls.Add(this.lblAppHint);
            this.panelApply.Controls.Add(this.lblAppDate);
            this.panelApply.Controls.Add(this.lblAppDoctor);
            this.panelApply.Controls.Add(this.lblAppMinute);
            this.panelApply.Controls.Add(this.lblAppHour);
            this.panelApply.Controls.Add(this.lblAppDay);
            this.panelApply.Controls.Add(this.lblAppMonth);
            this.panelApply.Controls.Add(this.lblAppYear);
            this.panelApply.Controls.Add(this.lblAppOPSName);
            this.panelApply.Controls.Add(this.lblAppDept);
            this.panelApply.Controls.Add(this.lblAppCardNo);
            this.panelApply.Controls.Add(this.lblAppAge);
            this.panelApply.Controls.Add(this.lblAppSex);
            this.panelApply.Controls.Add(this.lblAppName);
            this.panelApply.Controls.Add(this.lblAppNO);
            this.panelApply.Controls.Add(this.lblStatus);
            this.panelApply.Controls.Add(this.label33);
            this.panelApply.Controls.Add(this.label32);
            this.panelApply.Controls.Add(this.label31);
            this.panelApply.Controls.Add(this.label30);
            this.panelApply.Controls.Add(this.label29);
            this.panelApply.Controls.Add(this.label28);
            this.panelApply.Controls.Add(this.label27);
            this.panelApply.Controls.Add(this.label26);
            this.panelApply.Controls.Add(this.label25);
            this.panelApply.Controls.Add(this.label24);
            this.panelApply.Controls.Add(this.label23);
            this.panelApply.Controls.Add(this.label22);
            this.panelApply.Controls.Add(this.label21);
            this.panelApply.Controls.Add(this.label20);
            this.panelApply.Controls.Add(this.label19);
            this.panelApply.Controls.Add(this.label18);
            this.panelApply.Controls.Add(this.label17);
            this.panelApply.Controls.Add(this.label16);
            this.panelApply.Controls.Add(this.label15);
            this.panelApply.Controls.Add(this.label14);
            this.panelApply.Controls.Add(this.label13);
            this.panelApply.Controls.Add(this.label12);
            this.panelApply.Controls.Add(this.label11);
            this.panelApply.Controls.Add(this.label10);
            this.panelApply.Controls.Add(this.label9);
            this.panelApply.Controls.Add(this.label8);
            this.panelApply.Controls.Add(this.label7);
            this.panelApply.Controls.Add(this.label6);
            this.panelApply.Controls.Add(this.label5);
            this.panelApply.Controls.Add(this.label4);
            this.panelApply.Controls.Add(this.label3);
            this.panelApply.Controls.Add(this.label2);
            this.panelApply.Controls.Add(this.label1);
            this.panelApply.Controls.Add(this.lblAppTitle);
            this.panelApply.Location = new System.Drawing.Point(5, 44);
            this.panelApply.Name = "panelApply";
            this.panelApply.Size = new System.Drawing.Size(752, 524);
            this.panelApply.TabIndex = 22;
            // 
            // lblAppHint
            // 
            this.lblAppHint.AccessibleName = "T";
            this.lblAppHint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAppHint.Location = new System.Drawing.Point(56, 304);
            this.lblAppHint.Name = "lblAppHint";
            this.lblAppHint.Size = new System.Drawing.Size(676, 108);
            this.lblAppHint.TabIndex = 82;
            // 
            // lblAppDate
            // 
            this.lblAppDate.AccessibleName = "T";
            this.lblAppDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAppDate.Location = new System.Drawing.Point(576, 476);
            this.lblAppDate.Name = "lblAppDate";
            this.lblAppDate.Size = new System.Drawing.Size(140, 20);
            this.lblAppDate.TabIndex = 81;
            this.lblAppDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAppDoctor
            // 
            this.lblAppDoctor.AccessibleName = "T";
            this.lblAppDoctor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAppDoctor.Location = new System.Drawing.Point(576, 440);
            this.lblAppDoctor.Name = "lblAppDoctor";
            this.lblAppDoctor.Size = new System.Drawing.Size(140, 20);
            this.lblAppDoctor.TabIndex = 80;
            this.lblAppDoctor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAppMinute
            // 
            this.lblAppMinute.AccessibleName = "T";
            this.lblAppMinute.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAppMinute.Location = new System.Drawing.Point(428, 228);
            this.lblAppMinute.Name = "lblAppMinute";
            this.lblAppMinute.Size = new System.Drawing.Size(44, 20);
            this.lblAppMinute.TabIndex = 79;
            this.lblAppMinute.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAppHour
            // 
            this.lblAppHour.AccessibleName = "T";
            this.lblAppHour.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAppHour.Location = new System.Drawing.Point(344, 228);
            this.lblAppHour.Name = "lblAppHour";
            this.lblAppHour.Size = new System.Drawing.Size(52, 20);
            this.lblAppHour.TabIndex = 78;
            this.lblAppHour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAppDay
            // 
            this.lblAppDay.AccessibleName = "T";
            this.lblAppDay.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAppDay.Location = new System.Drawing.Point(284, 228);
            this.lblAppDay.Name = "lblAppDay";
            this.lblAppDay.Size = new System.Drawing.Size(32, 20);
            this.lblAppDay.TabIndex = 77;
            this.lblAppDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAppMonth
            // 
            this.lblAppMonth.AccessibleName = "T";
            this.lblAppMonth.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAppMonth.Location = new System.Drawing.Point(224, 228);
            this.lblAppMonth.Name = "lblAppMonth";
            this.lblAppMonth.Size = new System.Drawing.Size(32, 20);
            this.lblAppMonth.TabIndex = 76;
            this.lblAppMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAppYear
            // 
            this.lblAppYear.AccessibleName = "T";
            this.lblAppYear.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAppYear.Location = new System.Drawing.Point(124, 228);
            this.lblAppYear.Name = "lblAppYear";
            this.lblAppYear.Size = new System.Drawing.Size(64, 20);
            this.lblAppYear.TabIndex = 75;
            this.lblAppYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAppOPSName
            // 
            this.lblAppOPSName.AccessibleName = "T";
            this.lblAppOPSName.Font = new System.Drawing.Font("楷体_GB2312", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAppOPSName.Location = new System.Drawing.Point(60, 160);
            this.lblAppOPSName.Name = "lblAppOPSName";
            this.lblAppOPSName.Size = new System.Drawing.Size(672, 44);
            this.lblAppOPSName.TabIndex = 74;
            this.lblAppOPSName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAppDept
            // 
            this.lblAppDept.AccessibleName = "T";
            this.lblAppDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAppDept.Location = new System.Drawing.Point(600, 92);
            this.lblAppDept.Name = "lblAppDept";
            this.lblAppDept.Size = new System.Drawing.Size(140, 20);
            this.lblAppDept.TabIndex = 73;
            this.lblAppDept.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAppCardNo
            // 
            this.lblAppCardNo.AccessibleName = "T";
            this.lblAppCardNo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAppCardNo.Location = new System.Drawing.Point(436, 92);
            this.lblAppCardNo.Name = "lblAppCardNo";
            this.lblAppCardNo.Size = new System.Drawing.Size(92, 20);
            this.lblAppCardNo.TabIndex = 72;
            this.lblAppCardNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAppAge
            // 
            this.lblAppAge.AccessibleName = "T";
            this.lblAppAge.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAppAge.Location = new System.Drawing.Point(308, 92);
            this.lblAppAge.Name = "lblAppAge";
            this.lblAppAge.Size = new System.Drawing.Size(56, 20);
            this.lblAppAge.TabIndex = 71;
            this.lblAppAge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAppSex
            // 
            this.lblAppSex.AccessibleName = "T";
            this.lblAppSex.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAppSex.Location = new System.Drawing.Point(224, 92);
            this.lblAppSex.Name = "lblAppSex";
            this.lblAppSex.Size = new System.Drawing.Size(40, 20);
            this.lblAppSex.TabIndex = 70;
            this.lblAppSex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAppName
            // 
            this.lblAppName.AccessibleName = "T";
            this.lblAppName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAppName.Location = new System.Drawing.Point(96, 92);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(80, 20);
            this.lblAppName.TabIndex = 69;
            this.lblAppName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAppNO
            // 
            this.lblAppNO.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppNO.ForeColor = System.Drawing.Color.Black;
            this.lblAppNO.Location = new System.Drawing.Point(8, 4);
            this.lblAppNO.Name = "lblAppNO";
            this.lblAppNO.Size = new System.Drawing.Size(132, 20);
            this.lblAppNO.TabIndex = 68;
            this.lblAppNO.Text = "NO：";
            this.lblAppNO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(676, 4);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(52, 20);
            this.lblStatus.TabIndex = 48;
            this.lblStatus.Text = "待审";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label33
            // 
            this.label33.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label33.Location = new System.Drawing.Point(504, 228);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(16, 20);
            this.label33.TabIndex = 33;
            this.label33.Text = "候";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label32
            // 
            this.label32.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label32.Location = new System.Drawing.Point(476, 228);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(16, 20);
            this.label32.TabIndex = 32;
            this.label32.Text = "分";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label31
            // 
            this.label31.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label31.Location = new System.Drawing.Point(400, 228);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(16, 20);
            this.label31.TabIndex = 31;
            this.label31.Text = "时";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label30
            // 
            this.label30.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label30.Location = new System.Drawing.Point(320, 228);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(16, 20);
            this.label30.TabIndex = 30;
            this.label30.Text = "日";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label29
            // 
            this.label29.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label29.Location = new System.Drawing.Point(260, 228);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(16, 20);
            this.label29.TabIndex = 29;
            this.label29.Text = "月";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label28.Location = new System.Drawing.Point(196, 228);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(16, 20);
            this.label28.TabIndex = 28;
            this.label28.Text = "年";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label27.Location = new System.Drawing.Point(460, 476);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(108, 20);
            this.label27.TabIndex = 27;
            this.label27.Text = "开单时间    ：";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label26.Location = new System.Drawing.Point(460, 440);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(108, 20);
            this.label26.TabIndex = 26;
            this.label26.Text = "开单医生签名：";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.Location = new System.Drawing.Point(24, 272);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(80, 20);
            this.label25.TabIndex = 25;
            this.label25.Text = "温馨提示：";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(92, 216);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(1, 40);
            this.label24.TabIndex = 24;
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.Location = new System.Drawing.Point(24, 228);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(64, 20);
            this.label23.TabIndex = 23;
            this.label23.Text = "预约时间";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.Location = new System.Drawing.Point(24, 132);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(80, 20);
            this.label22.TabIndex = 22;
            this.label22.Text = "手术名称：";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(594, 80);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(1, 40);
            this.label21.TabIndex = 21;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(528, 80);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(1, 40);
            this.label20.TabIndex = 20;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(432, 80);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(1, 40);
            this.label19.TabIndex = 19;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(364, 80);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(1, 40);
            this.label18.TabIndex = 18;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(304, 80);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(1, 40);
            this.label17.TabIndex = 17;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(264, 80);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(1, 40);
            this.label16.TabIndex = 16;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(220, 80);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(1, 40);
            this.label15.TabIndex = 15;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(180, 80);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(1, 40);
            this.label14.TabIndex = 14;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(92, 80);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(1, 40);
            this.label13.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(532, 92);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 20);
            this.label12.TabIndex = 12;
            this.label12.Text = "手术科室";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(368, 92);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 20);
            this.label11.TabIndex = 11;
            this.label11.Text = "诊疗卡号";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(268, 92);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 20);
            this.label10.TabIndex = 10;
            this.label10.Text = "年龄";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(185, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 20);
            this.label9.TabIndex = 9;
            this.label9.Text = "性别";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(24, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "姓    名";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(740, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(1, 340);
            this.label7.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(16, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(1, 340);
            this.label6.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(16, 420);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(724, 1);
            this.label5.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(16, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(724, 1);
            this.label4.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(16, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(724, 1);
            this.label3.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(16, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(724, 1);
            this.label2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(16, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(724, 1);
            this.label1.TabIndex = 1;
            // 
            // lblAppTitle
            // 
            this.lblAppTitle.Font = new System.Drawing.Font("黑体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAppTitle.Location = new System.Drawing.Point(16, 20);
            this.lblAppTitle.Name = "lblAppTitle";
            this.lblAppTitle.Size = new System.Drawing.Size(724, 40);
            this.lblAppTitle.TabIndex = 0;
            this.lblAppTitle.Text = "门诊手术申请单";
            this.lblAppTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.m_chkTui);
            this.panel3.Controls.Add(this.btnPrint);
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Controls.Add(this.btnAuditing);
            this.panel3.Controls.Add(this.btnFind);
            this.panel3.Controls.Add(this.btnRefresh);
            this.panel3.Location = new System.Drawing.Point(0, 608);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(784, 36);
            this.panel3.TabIndex = 2;
            // 
            // m_chkTui
            // 
            this.m_chkTui.AutoSize = true;
            this.m_chkTui.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkTui.Location = new System.Drawing.Point(185, 19);
            this.m_chkTui.Name = "m_chkTui";
            this.m_chkTui.Size = new System.Drawing.Size(70, 16);
            this.m_chkTui.TabIndex = 8;
            this.m_chkTui.Text = "显示退票";
            this.m_chkTui.UseVisualStyleBackColor = true;
            this.m_chkTui.CheckedChanged += new System.EventHandler(this.m_chkTui_CheckedChanged);
            // 
            // btnPrint
            // 
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPrint.Location = new System.Drawing.Point(512, 7);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(72, 28);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnClose.Location = new System.Drawing.Point(694, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 28);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSave.Location = new System.Drawing.Point(420, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(72, 28);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAuditing
            // 
            this.btnAuditing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAuditing.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAuditing.Image = ((System.Drawing.Image)(resources.GetObject("btnAuditing.Image")));
            this.btnAuditing.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAuditing.Location = new System.Drawing.Point(96, 7);
            this.btnAuditing.Name = "btnAuditing";
            this.btnAuditing.Size = new System.Drawing.Size(72, 28);
            this.btnAuditing.TabIndex = 3;
            this.btnAuditing.Text = "审核(&A)";
            this.btnAuditing.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnAuditing.Click += new System.EventHandler(this.btnAuditing_Click);
            // 
            // btnFind
            // 
            this.btnFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnFind.Location = new System.Drawing.Point(602, 7);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(72, 28);
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "查找(&F)";
            this.btnFind.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnRefresh.Location = new System.Drawing.Point(8, 7);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(72, 28);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "刷新(&R)";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemApp,
            this.toolStripMenuItem1,
            this.ToolStripMenuItemRep});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(111, 54);
            // 
            // ToolStripMenuItemApp
            // 
            this.ToolStripMenuItemApp.Name = "ToolStripMenuItemApp";
            this.ToolStripMenuItemApp.Size = new System.Drawing.Size(110, 22);
            this.ToolStripMenuItemApp.Text = "申请单";
            this.ToolStripMenuItemApp.Click += new System.EventHandler(this.ToolStripMenuItemApp_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(107, 6);
            // 
            // ToolStripMenuItemRep
            // 
            this.ToolStripMenuItemRep.Name = "ToolStripMenuItemRep";
            this.ToolStripMenuItemRep.Size = new System.Drawing.Size(110, 22);
            this.ToolStripMenuItemRep.Text = "报告单";
            this.ToolStripMenuItemRep.Click += new System.EventHandler(this.ToolStripMenuItemRep_Click);
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menu_Template,
            this.menu_Cut,
            this.menu_Copy,
            this.menuI_Paste,
            this.menuI_Undo});
            // 
            // menu_Template
            // 
            this.menu_Template.Index = 0;
            this.menu_Template.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menu_CreatTemplate,
            this.menu_changeTemplate});
            this.menu_Template.Text = "模板维护";
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "调用模板";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menu_CreatTemplate
            // 
            this.menu_CreatTemplate.Index = 1;
            this.menu_CreatTemplate.Text = "生成模板";
            this.menu_CreatTemplate.Click += new System.EventHandler(this.menu_CreatTemplate_Click);
            // 
            // menu_changeTemplate
            // 
            this.menu_changeTemplate.Index = 2;
            this.menu_changeTemplate.Text = "修改模板";
            this.menu_changeTemplate.Click += new System.EventHandler(this.menu_changeTemplate_Click);
            // 
            // menu_Cut
            // 
            this.menu_Cut.Index = 1;
            this.menu_Cut.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
            this.menu_Cut.Text = "剪切";
            this.menu_Cut.Click += new System.EventHandler(this.menu_Cut_Click);
            // 
            // menu_Copy
            // 
            this.menu_Copy.Index = 2;
            this.menu_Copy.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
            this.menu_Copy.Text = "复制";
            this.menu_Copy.Click += new System.EventHandler(this.menu_Copy_Click);
            // 
            // menuI_Paste
            // 
            this.menuI_Paste.Index = 3;
            this.menuI_Paste.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
            this.menuI_Paste.Text = "粘贴";
            this.menuI_Paste.Click += new System.EventHandler(this.menuI_Paste_Click);
            // 
            // menuI_Undo
            // 
            this.menuI_Undo.Index = 4;
            this.menuI_Undo.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
            this.menuI_Undo.Text = "撤消";
            this.menuI_Undo.Click += new System.EventHandler(this.menuI_Undo_Click);
            // 
            // frmOPSRoom
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1016, 647);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.collapsibleSplitter);
            this.Controls.Add(this.outlookBar);
            this.Controls.Add(this.lvApply);
            this.Controls.Add(this.lvReport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOPSRoom";
            this.Text = "门诊手术室管理主窗口";
            this.Deactivate += new System.EventHandler(this.frmOPSRoom_Deactivate);
            this.Load += new System.EventHandler(this.frmOPSRoom_Load);
            this.panel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panelReport.ResumeLayout(false);
            this.panelReport.PerformLayout();
            this.panelApply.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

		}

        void lvReport_Click(object sender, EventArgs e)
        {
            if (m_blnCanDo == false)
                return;
            if (lvReport.SelectedItems.Count > 0)
            {
                if (((clsCtl_OPSRoom)this.objController).m_blnCheckAlterToSave() == false)//取消
                {
                    int index = ((clsCtl_OPSRoom)this.objController).m_lsvReportPrvSelectIndex;
                    if (index != -1)
                    {
                        m_blnCanDo = false;

                        this.lvReport.Items[index].Focused = true;
                        this.lvReport.Items[index].Selected = true;


                    }
                    return;
                }
                else
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataRow dr = (DataRow)(this.lvReport.SelectedItems[0].Tag);
                    ((clsCtl_OPSRoom)this.objController).m_mthSetreportvalue(dr);
                    this.Cursor = Cursors.Default;
                }
            }
        }
		#endregion

		public override void CreateController()
		{
			this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_OPSRoom();
			objController.Set_GUI_Apperance(this);
		}
        #region 模板
        #region 生成模板
        private com.digitalwave.iCare.gui.Security.clsController_Security objController_Security = null;
        private com.digitalwave.iCare.Template.Client.clsTemplateClient m_objTemplate;
        public void m_mthCreateTemplate()
        {
            this.m_objTemplate.m_mthCreateTemplate();
        }
        #endregion

        private void btnCreateTemplate_Click(object sender, System.EventArgs e)
        {
            m_mthCreateTemplate();
        }
        #endregion
		private void frmOPSRoom_Load(object sender, System.EventArgs e)
        {
            #region 模板
            string m_strDeptID = "";
            string m_strEmpID = this.LoginInfo.m_strEmpID;
            com.digitalwave.GUI_Base.clsController_Base objCtlBase = new com.digitalwave.GUI_Base.clsController_Base();
            com.digitalwave.iCare.ValueObject.clsDepartmentVO[] objDept = null;
            objCtlBase.m_objComInfo.m_mthGetDepartmentByUserID(m_strEmpID, out objDept);
            if (objDept != null)
            {
                for (int i = 0; i < objDept.Length; i++)
                {
                    if (objDept[i].intInPatientOrOutPatient == 0)
                    {
                        m_strDeptID = objDept[i].strDeptID;
                        break;
                    }
                }
            }
            m_objTemplate = new com.digitalwave.iCare.Template.Client.clsTemplateClient(this, this.LoginInfo.m_strEmpID, m_strDeptID);
            #endregion 

            this.txtRepOPSStepandResult.ContextMenu = this.contextMenu1;

            this.Cursor = Cursors.WaitCursor;
			((clsCtl_OPSRoom)this.objController).m_mthInit();
            ((clsCtl_OPSRoom)this.objController).m_mthGetappinfo(1);
            ((clsCtl_OPSRoom)this.objController).m_mthGetappinfo(2);
            ((clsCtl_OPSRoom)this.objController).m_mthSetanamode();
            this.Cursor = Cursors.Default;
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
                this.Close();
		}

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ((clsCtl_OPSRoom)this.objController).m_mthPrint();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ((clsCtl_OPSRoom)this.objController).m_mthGetappinfo(1);
            this.Cursor = Cursors.Default;
        }

        private void lvApply_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            this.Cursor = Cursors.WaitCursor;
            ((clsCtl_OPSRoom)this.objController).m_mthSetappvalue();
            ((clsCtl_OPSRoom)this.objController).m_mthSelectBill(0);
            this.Cursor = Cursors.Default;
        }

        private void btnAuditing_Click(object sender, EventArgs e)
        {
            if (outlookBar.CurrentBand == 0)
            {
                ((clsCtl_OPSRoom)this.objController).m_mthConfirm();
            }
            else
            {
                ((clsCtl_OPSRoom)this.objController).m_mthConfirmReport();
            }
        }

        private void lvReport_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            //if (m_blnCanDo == false)
            //    return;
            //if (lvReport.SelectedItems.Count > 0)
            //{
            //    if (((clsCtl_OPSRoom)this.objController).m_blnCheckAlterToSave() == false)//取消
            //    {
            //        int index =((clsCtl_OPSRoom)this.objController).m_lsvReportPrvSelectIndex;
            //        if (index != -1)
            //        {
            //            m_blnCanDo = false;

            //            this.lvReport.Items[index].Focused = true;
            //            this.lvReport.Items[index].Selected = true;
                        
                        
            //        }
            //        return;
            //    }
            //    else
            //    {
            //        this.Cursor = Cursors.WaitCursor;
            //        DataRow dr = (DataRow)(this.lvReport.SelectedItems[0].Tag);
            //        ((clsCtl_OPSRoom)this.objController).m_mthSetreportvalue(dr);
            //        this.Cursor = Cursors.Default;
            //    }
            //}
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ((clsCtl_OPSRoom)this.objController).m_mthSave();
        }

        private void txtRepOPSName_KeyDown(object sender, KeyEventArgs e)
        {
            ((clsCtl_OPSRoom)this.objController).m_mthSetfoucs(e, "txtRepOPSName");
        }

        private void txtRepDiagbegin_KeyDown(object sender, KeyEventArgs e)
        {
            ((clsCtl_OPSRoom)this.objController).m_mthSetfoucs(e, "txtRepDiagbegin");
        }

        private void txtRepDiagend_KeyDown(object sender, KeyEventArgs e)
        {
            ((clsCtl_OPSRoom)this.objController).m_mthSetfoucs(e, "txtRepDiagend");
        }

        private void txtRepMaindoctor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                clsAssistantInput objAInput = new clsAssistantInput((System.Windows.Forms.Control)sender, this.PointToClient(this.panelReport.PointToScreen(new Point(((Control)sender).Left,((Control)sender).Bottom))));
                objAInput.m_mthSetEmployeeName();
            }
        }

        private void txtRepAssidoctor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                clsAssistantInput objAInput = new clsAssistantInput((System.Windows.Forms.Control)sender, this.PointToClient(this.panelReport.PointToScreen(new Point(((Control)sender).Left, ((Control)sender).Bottom))));
                objAInput.m_mthSetEmployeeName();
            }
        }

        private void txtRepMedtool_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                clsAssistantInput objAInput = new clsAssistantInput((System.Windows.Forms.Control)sender, this.PointToClient(this.panelReport.PointToScreen(new Point(((Control)sender).Left, ((Control)sender).Bottom))));
                objAInput.m_mthSetEmployeeName();
            }
        }

        private void txtRepAnamode_KeyDown(object sender, KeyEventArgs e)
        {
            ((clsCtl_OPSRoom)this.objController).m_mthSetfoucs(e, "txtRepAnamode");
        }

        private void txtRepAnadoctor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                clsAssistantInput objAInput = new clsAssistantInput((System.Windows.Forms.Control)sender, this.PointToClient(this.panelReport.PointToScreen(new Point(((Control)sender).Left, ((Control)sender).Bottom))));
                objAInput.m_mthSetEmployeeName();
            }
        }

        private void txtRepDoctor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                clsAssistantInput objAInput = new clsAssistantInput((System.Windows.Forms.Control)sender, this.PointToClient(this.panelReport.PointToScreen(new Point(((Control)sender).Left, ((Control)sender).Bottom))));
                objAInput.m_mthSetEmployeeName();
            }
           // ((clsCtl_OPSRoom)this.objController).m_mthSetfoucs(e, "txtRepDoctor");
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            contextMenuStrip.Show(btnFind, new Point(btnFind.Width, btnFind.Height));            
        }

        private void ToolStripMenuItemApp_Click(object sender, EventArgs e)
        {
            ((clsCtl_OPSRoom)this.objController).m_mthFind(0);
        }

        private void ToolStripMenuItemRep_Click(object sender, EventArgs e)
        {
            ((clsCtl_OPSRoom)this.objController).m_mthFind(1);
        }

        private void frmOPSRoom_Deactivate(object sender, EventArgs e)
        {

        }

        private void menu_CreatTemplate_Click(object sender, EventArgs e)
        {
            m_mthCreateTemplate();
        }

        private void menu_changeTemplate_Click(object sender, EventArgs e)
        {
            this.m_objTemplate.m_mthManageTemplate();
        }

        private void menu_Cut_Click(object sender, EventArgs e)
        {
            txtRepOPSStepandResult.Cut();
        }

        private void menu_Copy_Click(object sender, EventArgs e)
        {
            txtRepOPSStepandResult.Copy();

        }

        private void menuI_Paste_Click(object sender, EventArgs e)
        {
            txtRepOPSStepandResult.Paste();

        }

        private void menuI_Undo_Click(object sender, EventArgs e)
        {
            txtRepOPSStepandResult.m_mthUndo();

        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            m_objTemplate.m_mthUseTemplate();
        }

        private void lvReport_MouseDown(object sender, MouseEventArgs e)
        {
            if (lvReport.SelectedItems.Count > 0)
            {
                m_blnCanDo = true;
                ((clsCtl_OPSRoom)this.objController).m_lsvReportPrvSelectIndex = lvReport.SelectedIndices[0];
            }
        }

        private void m_chkTui_CheckedChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ((clsCtl_OPSRoom)this.objController).m_mthGetappinfo(1);
            this.Cursor = Cursors.Default;
        }      
        
	}
}
