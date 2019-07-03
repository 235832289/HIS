using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.Security;
using System.Text;
using System.Reflection;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmCheckOutRegReport 的摘要说明。
	/// </summary>
	public class frmCheckOutRegReport: com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
//		delegate void dlgPrintReport(string p_strDat,string p_strNO);
		private System.Windows.Forms.DateTimePicker m_dtpdate;
		private System.Windows.Forms.Label label1;
		private PinkieControls.ButtonXP m_btnRef;
		private PinkieControls.ButtonXP m_btnCheckOut;
		private PinkieControls.ButtonXP m_btnPrint;
		private PinkieControls.ButtonXP m_btnClose;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox m_txtRegisterp;
		clsDomainControl_Register clsDomain = new clsDomainControl_Register();
		clsPatientRegister_VO clsRegister = new clsPatientRegister_VO();
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		internal System.Windows.Forms.Panel m_pnlAllPlan;
		internal System.Windows.Forms.ListView m_lsvAllplan;
		private PinkieControls.ButtonXP m_btnqul;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer cryReportViewer;
		internal System.Drawing.Printing.PrintDocument PritDoc;
		internal System.Windows.Forms.PrintPreviewControl Showprint;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		internal System.Windows.Forms.DateTimePicker EndDate;
		internal System.Windows.Forms.DateTimePicker starDate;
		internal com.digitalwave.controls.datagrid.ctlDataGrid ctlDgFind;
		private System.Windows.Forms.GroupBox groupBox2;
		internal com.digitalwave.iCare.gui.HIS.exComboBox m_cboCheckMan;
		private System.Windows.Forms.Label label5;
		internal PinkieControls.ButtonXP btnCheck;
        private Panel panel2;
        private Panel panel3;
        private PageSetupDialog pageSetupDialog1;

		clsDomainConrol_Print m_clsDcrl = new clsDomainConrol_Print();
		public frmCheckOutRegReport()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			this.FillDoc();

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
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo1 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo2 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCheckOutRegReport));
            this.m_dtpdate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.m_btnRef = new PinkieControls.ButtonXP();
            this.m_btnCheckOut = new PinkieControls.ButtonXP();
            this.m_btnPrint = new PinkieControls.ButtonXP();
            this.m_btnClose = new PinkieControls.ButtonXP();
            this.m_txtRegisterp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_pnlAllPlan = new System.Windows.Forms.Panel();
            this.m_lsvAllplan = new System.Windows.Forms.ListView();
            this.m_btnqul = new PinkieControls.ButtonXP();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cryReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.PritDoc = new System.Drawing.Printing.PrintDocument();
            this.Showprint = new System.Windows.Forms.PrintPreviewControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCheck = new PinkieControls.ButtonXP();
            this.label5 = new System.Windows.Forms.Label();
            this.m_cboCheckMan = new com.digitalwave.iCare.gui.HIS.exComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.EndDate = new System.Windows.Forms.DateTimePicker();
            this.starDate = new System.Windows.Forms.DateTimePicker();
            this.ctlDgFind = new com.digitalwave.controls.datagrid.ctlDataGrid();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.m_pnlAllPlan.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDgFind)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_dtpdate
            // 
            this.m_dtpdate.Enabled = false;
            this.m_dtpdate.Location = new System.Drawing.Point(272, 17);
            this.m_dtpdate.Name = "m_dtpdate";
            this.m_dtpdate.Size = new System.Drawing.Size(120, 23);
            this.m_dtpdate.TabIndex = 0;
            this.m_dtpdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_dtpdate_KeyDown);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(192, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "截止日期：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_btnRef
            // 
            this.m_btnRef.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnRef.DefaultScheme = true;
            this.m_btnRef.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnRef.Hint = "";
            this.m_btnRef.Location = new System.Drawing.Point(-72, 0);
            this.m_btnRef.Name = "m_btnRef";
            this.m_btnRef.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnRef.Size = new System.Drawing.Size(80, 24);
            this.m_btnRef.TabIndex = 43;
            this.m_btnRef.Text = "刷新 F5";
            this.m_btnRef.Visible = false;
            this.m_btnRef.Click += new System.EventHandler(this.m_btnRef_Click);
            // 
            // m_btnCheckOut
            // 
            this.m_btnCheckOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnCheckOut.DefaultScheme = true;
            this.m_btnCheckOut.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnCheckOut.Hint = "";
            this.m_btnCheckOut.Location = new System.Drawing.Point(648, 12);
            this.m_btnCheckOut.Name = "m_btnCheckOut";
            this.m_btnCheckOut.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnCheckOut.Size = new System.Drawing.Size(104, 32);
            this.m_btnCheckOut.TabIndex = 2;
            this.m_btnCheckOut.Text = "结帐 F10";
            this.m_btnCheckOut.Click += new System.EventHandler(this.m_btnCheckOut_Click);
            // 
            // m_btnPrint
            // 
            this.m_btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnPrint.DefaultScheme = true;
            this.m_btnPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnPrint.Enabled = false;
            this.m_btnPrint.Hint = "";
            this.m_btnPrint.Location = new System.Drawing.Point(776, 12);
            this.m_btnPrint.Name = "m_btnPrint";
            this.m_btnPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnPrint.Size = new System.Drawing.Size(104, 32);
            this.m_btnPrint.TabIndex = 6;
            this.m_btnPrint.Text = "打印 F9";
            this.m_btnPrint.Click += new System.EventHandler(this.m_btnPrint_Click);
            // 
            // m_btnClose
            // 
            this.m_btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnClose.DefaultScheme = true;
            this.m_btnClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnClose.Hint = "";
            this.m_btnClose.Location = new System.Drawing.Point(904, 12);
            this.m_btnClose.Name = "m_btnClose";
            this.m_btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnClose.Size = new System.Drawing.Size(104, 32);
            this.m_btnClose.TabIndex = 40;
            this.m_btnClose.Text = "退出 F6";
            this.m_btnClose.Click += new System.EventHandler(this.m_btnClose_Click);
            // 
            // m_txtRegisterp
            // 
            this.m_txtRegisterp.Location = new System.Drawing.Point(88, 17);
            this.m_txtRegisterp.Name = "m_txtRegisterp";
            this.m_txtRegisterp.Size = new System.Drawing.Size(80, 23);
            this.m_txtRegisterp.TabIndex = 1;
            this.m_txtRegisterp.Enter += new System.EventHandler(this.m_txtRegisterp_Enter);
            this.m_txtRegisterp.Leave += new System.EventHandler(this.m_txtRegType_Leave);
            this.m_txtRegisterp.TextChanged += new System.EventHandler(this.m_txtPatType_TextChanged);
            this.m_txtRegisterp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtRegisterp_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 10;
            this.label2.Text = "挂号员：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_pnlAllPlan
            // 
            this.m_pnlAllPlan.Controls.Add(this.m_lsvAllplan);
            this.m_pnlAllPlan.Location = new System.Drawing.Point(-144, 114);
            this.m_pnlAllPlan.Name = "m_pnlAllPlan";
            this.m_pnlAllPlan.Size = new System.Drawing.Size(152, 216);
            this.m_pnlAllPlan.TabIndex = 39;
            this.m_pnlAllPlan.Visible = false;
            // 
            // m_lsvAllplan
            // 
            this.m_lsvAllplan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvAllplan.FullRowSelect = true;
            this.m_lsvAllplan.GridLines = true;
            this.m_lsvAllplan.HideSelection = false;
            this.m_lsvAllplan.Location = new System.Drawing.Point(0, 0);
            this.m_lsvAllplan.MultiSelect = false;
            this.m_lsvAllplan.Name = "m_lsvAllplan";
            this.m_lsvAllplan.Size = new System.Drawing.Size(152, 216);
            this.m_lsvAllplan.TabIndex = 3;
            this.m_lsvAllplan.TabStop = false;
            this.m_lsvAllplan.UseCompatibleStateImageBehavior = false;
            this.m_lsvAllplan.View = System.Windows.Forms.View.Details;
            this.m_lsvAllplan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_lsvAllplan_KeyPress);
            this.m_lsvAllplan.Click += new System.EventHandler(this.m_lsvAllplan_Click);
            // 
            // m_btnqul
            // 
            this.m_btnqul.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnqul.DefaultScheme = true;
            this.m_btnqul.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnqul.Hint = "";
            this.m_btnqul.Location = new System.Drawing.Point(424, 12);
            this.m_btnqul.Name = "m_btnqul";
            this.m_btnqul.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnqul.Size = new System.Drawing.Size(200, 32);
            this.m_btnqul.TabIndex = 4;
            this.m_btnqul.Text = "获取当前未结帐的数据 F7";
            this.m_btnqul.Click += new System.EventHandler(this.m_btnqul_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(-936, 40);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1016, 672);
            this.tabControl1.TabIndex = 44;
            this.tabControl1.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cryReportViewer);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1008, 645);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "挂号日报";
            // 
            // cryReportViewer
            // 
            this.cryReportViewer.ActiveViewIndex = -1;
            this.cryReportViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cryReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cryReportViewer.DisplayGroupTree = false;
            this.cryReportViewer.Location = new System.Drawing.Point(0, 0);
            this.cryReportViewer.Name = "cryReportViewer";
            this.cryReportViewer.SelectionFormula = "";
            this.cryReportViewer.Size = new System.Drawing.Size(1008, 630);
            this.cryReportViewer.TabIndex = 2;
            this.cryReportViewer.ViewTimeSelectionFormula = "";
            // 
            // PritDoc
            // 
            this.PritDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PritDoc_PrintPage);
            this.PritDoc.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.PritDoc_BeginPrint);
            // 
            // Showprint
            // 
            this.Showprint.AutoZoom = false;
            this.Showprint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Showprint.Document = this.PritDoc;
            this.Showprint.Location = new System.Drawing.Point(0, 0);
            this.Showprint.Name = "Showprint";
            this.Showprint.Size = new System.Drawing.Size(780, 637);
            this.Showprint.TabIndex = 45;
            this.Showprint.Zoom = 1;
            this.Showprint.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Showprint_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCheck);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.m_cboCheckMan);
            this.panel1.Controls.Add(this.m_btnCheckOut);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.m_dtpdate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.m_txtRegisterp);
            this.panel1.Controls.Add(this.m_btnqul);
            this.panel1.Controls.Add(this.m_btnClose);
            this.panel1.Controls.Add(this.m_btnPrint);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 52);
            this.panel1.TabIndex = 46;
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnCheck.DefaultScheme = true;
            this.btnCheck.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCheck.Hint = "";
            this.btnCheck.Location = new System.Drawing.Point(280, 12);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnCheck.Size = new System.Drawing.Size(104, 32);
            this.btnCheck.TabIndex = 49;
            this.btnCheck.Text = "查看 F2";
            this.btnCheck.Visible = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(24, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 23);
            this.label5.TabIndex = 48;
            this.label5.Text = "收 费 员：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Visible = false;
            // 
            // m_cboCheckMan
            // 
            this.m_cboCheckMan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboCheckMan.Location = new System.Drawing.Point(112, 17);
            this.m_cboCheckMan.Name = "m_cboCheckMan";
            this.m_cboCheckMan.Size = new System.Drawing.Size(120, 22);
            this.m_cboCheckMan.TabIndex = 48;
            this.m_cboCheckMan.Visible = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(8, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "结束时间：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(8, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "开始时间：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EndDate
            // 
            this.EndDate.CustomFormat = "yyyy年MM月dd日";
            this.EndDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EndDate.Location = new System.Drawing.Point(88, 48);
            this.EndDate.Name = "EndDate";
            this.EndDate.Size = new System.Drawing.Size(120, 23);
            this.EndDate.TabIndex = 2;
            this.EndDate.Value = new System.DateTime(2005, 5, 14, 11, 42, 5, 468);
            this.EndDate.ValueChanged += new System.EventHandler(this.EndDate_ValueChanged);
            // 
            // starDate
            // 
            this.starDate.CustomFormat = "yyyy年MM月dd日";
            this.starDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.starDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.starDate.Location = new System.Drawing.Point(88, 16);
            this.starDate.Name = "starDate";
            this.starDate.Size = new System.Drawing.Size(120, 23);
            this.starDate.TabIndex = 1;
            this.starDate.Value = new System.DateTime(2005, 5, 14, 11, 42, 5, 468);
            this.starDate.ValueChanged += new System.EventHandler(this.starDate_ValueChanged);
            // 
            // ctlDgFind
            // 
            this.ctlDgFind.AllowAddNew = false;
            this.ctlDgFind.AllowDelete = false;
            this.ctlDgFind.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlDgFind.AutoAppendRow = false;
            this.ctlDgFind.AutoScroll = true;
            this.ctlDgFind.BackgroundColor = System.Drawing.SystemColors.Window;
            this.ctlDgFind.CaptionText = "";
            this.ctlDgFind.CaptionVisible = false;
            this.ctlDgFind.ColumnHeadersVisible = true;
            clsColumnInfo1.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo1.BackColor = System.Drawing.Color.White;
            clsColumnInfo1.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo1.ColumnIndex = 0;
            clsColumnInfo1.ColumnName = "Column1";
            clsColumnInfo1.ColumnWidth = 0;
            clsColumnInfo1.Enabled = true;
            clsColumnInfo1.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo1.HeadText = "Column1";
            clsColumnInfo1.ReadOnly = false;
            clsColumnInfo1.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo2.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo2.BackColor = System.Drawing.Color.White;
            clsColumnInfo2.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo2.ColumnIndex = 1;
            clsColumnInfo2.ColumnName = "BALANCE_DAT";
            clsColumnInfo2.ColumnWidth = 150;
            clsColumnInfo2.Enabled = false;
            clsColumnInfo2.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo2.HeadText = "结帐时间";
            clsColumnInfo2.ReadOnly = true;
            clsColumnInfo2.TextFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ctlDgFind.Columns.Add(clsColumnInfo1);
            this.ctlDgFind.Columns.Add(clsColumnInfo2);
            this.ctlDgFind.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ctlDgFind.ForeColor = System.Drawing.Color.OrangeRed;
            this.ctlDgFind.FullRowSelect = true;
            this.ctlDgFind.Location = new System.Drawing.Point(3, 80);
            this.ctlDgFind.MultiSelect = false;
            this.ctlDgFind.Name = "ctlDgFind";
            this.ctlDgFind.ReadOnly = false;
            this.ctlDgFind.RowHeadersVisible = true;
            this.ctlDgFind.RowHeaderWidth = 35;
            this.ctlDgFind.SelectedRowBackColor = System.Drawing.Color.Purple;
            this.ctlDgFind.SelectedRowForeColor = System.Drawing.Color.White;
            this.ctlDgFind.Size = new System.Drawing.Size(210, 557);
            this.ctlDgFind.TabIndex = 0;
            this.ctlDgFind.m_evtDoubleClickCell += new com.digitalwave.controls.datagrid.clsDGTextMouseClickEventHandler(this.ctlDgFind_m_evtDoubleClickCell);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.EndDate);
            this.groupBox2.Controls.Add(this.starDate);
            this.groupBox2.Controls.Add(this.ctlDgFind);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.ForeColor = System.Drawing.Color.OrangeRed;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(216, 641);
            this.groupBox2.TabIndex = 47;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "已结帐历史记录";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1000, 641);
            this.panel2.TabIndex = 48;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.Showprint);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(216, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(784, 641);
            this.panel3.TabIndex = 48;
            // 
            // frmCheckOutRegReport
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(1000, 693);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.m_pnlAllPlan);
            this.Controls.Add(this.m_btnRef);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmCheckOutRegReport";
            this.Text = "挂号结帐";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCheckOutRegReport_KeyDown);
            this.Load += new System.EventHandler(this.frmCheckOutRegReport_Load);
            this.m_pnlAllPlan.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDgFind)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region 获取挂号员结帐数据
	    DataTable dtTolSource=new DataTable();
		DataTable dtRestoreDetail1=new DataTable();

        /// <summary>
        /// 发票号DataTable
        /// </summary>
        DataTable dtInvoNo;

		/// <summary>
		/// 标志要查找的数据，0-未结帐数据，1-历史数据
		/// </summary>
		int isHistory=0;
		string checkMan="";
		public void m_lngGetData(System.Drawing.Printing.PrintPageEventArgs e)
		{
			string strDate="";
			string checkManName="";
			if(isDoctorDean==true)
			{
				isHistory=1;
				if(m_cboCheckMan.SelectItemValue!=null)
				{
					checkMan=m_cboCheckMan.SelectItemValue.ToString();
					checkManName=m_cboCheckMan.SelectItemText;
				}
				else
				{
					checkMan="";
					checkManName="";
				}
			}
			else
			{
				checkMan=this.LoginInfo.m_strEmpID;
				checkManName=this.LoginInfo.m_strEmpName;
			}
			long lngRes;
			if(isHistory==0)
			{
				strDate=m_dtpdate.Value.ToShortDateString();
				lngRes=m_clsDcrl.m_lngEndReport(out dtTolSource,strDate,checkMan,out dtRestoreDetail1);
				if(lngRes>0)
				{
                    lngRes = m_clsDcrl.m_lngGetRegisterInvoInfo(checkMan, strDate, 0, out dtInvoNo);
                    if (lngRes > 0)
                    {                        
                        m_lngPrint(e, strDate, dtTolSource, dtRestoreDetail1, false, checkManName);
                    }
                    else
                    {
                        MessageBox.Show("获取结帐数据出错！", "icare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
				}
				else
				{
					MessageBox.Show("获取结帐数据出错！","icare",MessageBoxButtons.OK,MessageBoxIcon.Information);
				}
			}
			else
			{
				strDate=ctlDgFind[ctlDgFind.CurrentCell.RowNumber,1].ToString();
				lngRes=m_clsDcrl.m_lngHistoryReport(out dtTolSource, strDate,checkMan,out  dtRestoreDetail1);
				if(lngRes>0)
				{
                    lngRes = m_clsDcrl.m_lngGetRegisterInvoInfo(checkMan, strDate, 1, out dtInvoNo);
                    if (lngRes > 0)
                    {                        
                        m_lngPrint(e, strDate, dtTolSource, dtRestoreDetail1, true, checkManName);
                    }
                    else
                    {
                        MessageBox.Show("获取结帐数据出错！", "icare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
				}
				else
				{
					MessageBox.Show("获取结帐数据出错！","icare",MessageBoxButtons.OK,MessageBoxIcon.Information);
				}
			}

		}

		#endregion

		#region 获得历史数据
		/// <summary>
		/// 获得历史数据
		/// </summary>
		DataTable dtHistory=new DataTable();
		private void m_getHistoryData()
		{
			string strDateStart=this.starDate.Value.ToShortDateString();
			string strDateEnd=this.EndDate.Value.ToShortDateString();
			string strCurrCheckManID="";
			if(isDoctorDean==false)
				strCurrCheckManID=this.LoginInfo.m_strEmpID;
			else
			{
				if(m_cboCheckMan.SelectItemValue!=null)
					strCurrCheckManID=m_cboCheckMan.SelectItemValue.ToString();
			}
			this.m_clsDcrl.m_lngGetHistory(strDateStart,strDateEnd,strCurrCheckManID,out dtHistory);
			dtHistory.Columns.Add("Column1");
			ctlDgFind.m_mthSetDataTable(dtHistory);

		}
		#endregion

		#region 挂号报表(新)
        /// <summary>
        /// 挂号报表(新)
        /// </summary>
        /// <param name="e"></param>
        /// <param name="strDate"></param>
        /// <param name="dtTolSource"></param>
        /// <param name="dtRestoreDetail"></param>
        /// <param name="isHisstroy"></param>
        /// <param name="checkMan"></param>
		public void m_lngPrint(System.Drawing.Printing.PrintPageEventArgs e,string strDate,DataTable dtTolSource,DataTable dtRestoreDetail,bool isHisstroy,string checkMan)
		{
			float m_lngWidthPage;//打印页的宽度
	        float m_lngY=60;//当前Y方向坐标
			float m_lngX;//当前X方向坐标
	        float m_fltLeftIndentProp=60;//左缩进比例
		    float m_fltRightIndentProp=48;//右缩进比例
			float m_fltRectangleH=30;//每个方格的高度
			float m_fltRectangleW=80;//每个方格的宽度
			System.Drawing.Font m_fntTitle=new Font("宋体",18);//标题使用的字体
			System.Drawing.Font TextFont=new Font("宋体",11);//文字使用的字体
			SizeF szPerWord = e.Graphics.MeasureString("三",TextFont);//获取一个字符的宽度
			Pen blackPen = new Pen(Color.Black, 1);
			m_lngWidthPage=e.PageBounds.Width;//获取页面的长度
			int EndWidth=580;//己结帐三个字的显示位置

			#region 挂号人员日结账报表
			string m_strTitle = "挂号员日结帐报表";
			SizeF szTitle = e.Graphics.MeasureString(m_strTitle,m_fntTitle);
            float fltCurrentX = (e.PageBounds.Width - szTitle.Width) / 2;
			e.Graphics.DrawString(m_strTitle,m_fntTitle,Brushes.Black,fltCurrentX,m_lngY);
			m_lngX=m_fltLeftIndentProp;
			m_lngY+=50;
			e.Graphics.DrawString("结帐日期：",TextFont,Brushes.Black,m_lngX,m_lngY);
			e.Graphics.DrawString(strDate,TextFont,Brushes.Black,m_lngX+szPerWord.Width*4,m_lngY);

            if (isHisstroy)
            {               
                if (dtTolSource.Rows.Count > 0)
                {
                    e.Graphics.DrawString("发票日期：", TextFont, Brushes.Black, m_lngX + 300, m_lngY);
                    SizeF zf = e.Graphics.MeasureString("发票日期：", TextFont);

                    DataView dvInvo = new DataView(dtTolSource);
                    dvInvo.Sort = "invodate asc";

                    e.Graphics.DrawString(dvInvo[0]["invodate"].ToString() + "～" + dvInvo[dvInvo.Count - 1]["invodate"].ToString(), TextFont, Brushes.Black, m_lngX + 300 + zf.Width + 2, m_lngY);                    
                }

                e.Graphics.DrawString("【己结帐】", TextFont, Brushes.Black, m_lngX + szPerWord.Width * 4 + EndWidth - 20, m_lngY - 65);
            }

			m_lngY+=20;
			#region 画表格（结帐总表）
			float courrX=m_lngX;
			float courrY=m_lngY;
			for(int i1=0;i1<4;i1++)
			{
				e.Graphics.DrawLine(blackPen,courrX,courrY+m_fltRectangleH*i1,m_lngWidthPage-m_fltRightIndentProp,courrY+m_fltRectangleH*i1);
			}
			for(int i1=0;i1<10;i1++)
			{
				if(i1>0&&i1<9)
				    e.Graphics.DrawLine(blackPen,courrX+m_fltRectangleW*i1,courrY,courrX+m_fltRectangleW*i1,courrY+m_fltRectangleH*2);
				else
					e.Graphics.DrawLine(blackPen,courrX+m_fltRectangleW*i1,courrY,courrX+m_fltRectangleW*i1,courrY+m_fltRectangleH*3);
			}
			#endregion
			#region 统计数据
			int tolCont=0;//开票数
			double tolMoney=0;//开票金额
			int reCont=0;//退票数
			double reMoney=0;//退票金额
			int backCont=0;//恢复票数
			double backMoney=0;//恢复金额
			int availabilityCont=0;//有效票数
			double availabilityMoney=0;//实收金额
			double K001=0;//正常挂号费
			double R001=0;//退票挂号费
			double B001=0;//恢复挂号费

			double K002=0;//正常诊疗费
			double R002=0;//退票诊疗费
			double B002=0;//恢复诊疗费

			double K003=0;//正常工本费
			double R003=0;//退票工本费
			double B003=0;//恢复工本费

			double K004=0;//正常磁卡
			double R004=0;//退票磁卡
			double B004=0;//恢复磁卡
			string mixNO="";//最小发票号
			string maxNO="";//最大发票号
			ArrayList arrList=new ArrayList();
			clsMain.m_Detach(dtTolSource,"INVNO_CHR",out arrList);

			DataTable backTabel=new DataTable();
			backTabel=dtTolSource.Clone();
			if(dtTolSource.Rows.Count>0)
			{
				mixNO=dtTolSource.Rows[0]["INVNO_CHR"].ToString();
				maxNO=dtTolSource.Rows[dtTolSource.Rows.Count-1]["INVNO_CHR"].ToString();
				for(int i1=0;i1<dtTolSource.Rows.Count;i1++)
				{
					if(dtTolSource.Rows[i1]["FLAG_INT"].ToString()=="4")
					{
						DataRow newRow=backTabel.NewRow();
						newRow["REGISTERID_CHR"]=dtTolSource.Rows[i1]["REGISTERID_CHR"];
						newRow["REGISTERDATE_DAT"]=dtTolSource.Rows[i1]["REGISTERDATE_DAT"];
						newRow["REGISTERNO_CHR"]=dtTolSource.Rows[i1]["REGISTERNO_CHR"];
						newRow["INVNO_CHR"]=dtTolSource.Rows[i1]["INVNO_CHR"];
						newRow["PatientName"]=dtTolSource.Rows[i1]["PatientName"];
						newRow["PAYTYPENAME_VCHR"]=dtTolSource.Rows[i1]["PAYTYPENAME_VCHR"];
						newRow["LASTNAME_VCHR"]=dtTolSource.Rows[i1]["LASTNAME_VCHR"];
						newRow["DEPTNAME_VCHR"]=dtTolSource.Rows[i1]["DEPTNAME_VCHR"];
						newRow["rcharge"]=dtTolSource.Rows[i1]["rcharge"];
						newRow["dcharge"]=dtTolSource.Rows[i1]["dcharge"];
						newRow["gcharge"]=dtTolSource.Rows[i1]["gcharge"];
						newRow["ccharge"]=dtTolSource.Rows[i1]["ccharge"];
						backTabel.Rows.Add(newRow);
						backCont++;
						if(dtTolSource.Rows[i1]["rcharge"].ToString()!=""&&dtTolSource.Rows[i1]["rcharge"].ToString()!=null)
						{
							backMoney+=Convert.ToDouble(dtTolSource.Rows[i1]["rcharge"].ToString());
							B001+=Convert.ToDouble(dtTolSource.Rows[i1]["rcharge"].ToString());
						}
						if(dtTolSource.Rows[i1]["dcharge"].ToString()!=""&&dtTolSource.Rows[i1]["dcharge"].ToString()!=null)
						{
							backMoney+=Convert.ToDouble(dtTolSource.Rows[i1]["dcharge"].ToString());
							B002+=Convert.ToDouble(dtTolSource.Rows[i1]["dcharge"].ToString());
						}
						if(dtTolSource.Rows[i1]["gcharge"].ToString()!=""&&dtTolSource.Rows[i1]["gcharge"].ToString()!=null)
						{
							backMoney+=Convert.ToDouble(dtTolSource.Rows[i1]["gcharge"].ToString());
							B003+=Convert.ToDouble(dtTolSource.Rows[i1]["gcharge"].ToString());
						}
						if(dtTolSource.Rows[i1]["ccharge"].ToString()!=""&&dtTolSource.Rows[i1]["ccharge"].ToString()!=null)
						{
							backMoney+=Convert.ToDouble(dtTolSource.Rows[i1]["ccharge"].ToString());
							B004+=Convert.ToDouble(dtTolSource.Rows[i1]["ccharge"].ToString());
						}
					}
					else
					{
						if(dtTolSource.Rows[i1]["rcharge"].ToString()!=""&&dtTolSource.Rows[i1]["rcharge"].ToString()!=null)
						{
							tolMoney+=Convert.ToDouble(dtTolSource.Rows[i1]["rcharge"].ToString());
							K001+=Convert.ToDouble(dtTolSource.Rows[i1]["rcharge"].ToString());
						}
						if(dtTolSource.Rows[i1]["dcharge"].ToString()!=""&&dtTolSource.Rows[i1]["dcharge"].ToString()!=null)
						{
							tolMoney+=Convert.ToDouble(dtTolSource.Rows[i1]["dcharge"].ToString());
							K002+=Convert.ToDouble(dtTolSource.Rows[i1]["dcharge"].ToString());
						}
						if(dtTolSource.Rows[i1]["gcharge"].ToString()!=""&&dtTolSource.Rows[i1]["gcharge"].ToString()!=null)
						{
							tolMoney+=Convert.ToDouble(dtTolSource.Rows[i1]["gcharge"].ToString());
							K003+=Convert.ToDouble(dtTolSource.Rows[i1]["gcharge"].ToString());

						}
						if(dtTolSource.Rows[i1]["ccharge"].ToString()!=""&&dtTolSource.Rows[i1]["ccharge"].ToString()!=null)
						{
							tolMoney+=Convert.ToDouble(dtTolSource.Rows[i1]["ccharge"].ToString());
							K004+=Convert.ToDouble(dtTolSource.Rows[i1]["ccharge"].ToString());
						}
						tolCont++;
					}
				}
			}
			if(dtRestoreDetail.Rows.Count>0)
			{
				for(int i1=0;i1<dtRestoreDetail.Rows.Count;i1++)
				{
					if(dtRestoreDetail.Rows[i1]["rcharge"].ToString()!=""&&dtRestoreDetail.Rows[i1]["rcharge"].ToString()!=null)
					{
						reMoney+=Convert.ToDouble(dtRestoreDetail.Rows[i1]["rcharge"].ToString());
						R001+=Convert.ToDouble(dtRestoreDetail.Rows[i1]["rcharge"].ToString());
					}
					if(dtRestoreDetail.Rows[i1]["dcharge"].ToString()!=""&&dtRestoreDetail.Rows[i1]["dcharge"].ToString()!=null)
					{
						reMoney+=Convert.ToDouble(dtRestoreDetail.Rows[i1]["dcharge"].ToString());
						R002+=Convert.ToDouble(dtRestoreDetail.Rows[i1]["dcharge"].ToString());
					}
					if(dtRestoreDetail.Rows[i1]["gcharge"].ToString()!=""&&dtRestoreDetail.Rows[i1]["gcharge"].ToString()!=null)
					{
						reMoney+=Convert.ToDouble(dtRestoreDetail.Rows[i1]["gcharge"].ToString());
						R003+=Convert.ToDouble(dtRestoreDetail.Rows[i1]["gcharge"].ToString());
					}
					if(dtRestoreDetail.Rows[i1]["ccharge"].ToString()!=""&&dtRestoreDetail.Rows[i1]["ccharge"].ToString()!=null)
					{
						reMoney+=Convert.ToDouble(dtRestoreDetail.Rows[i1]["ccharge"].ToString());
						R004+=Convert.ToDouble(dtRestoreDetail.Rows[i1]["ccharge"].ToString());
					}
					reCont++;
				}
			}
			availabilityCont=tolCont+backCont-reCont;
			availabilityMoney=tolMoney+backMoney-reMoney;
			double T001=K001+B001-R001;//有效挂号费
			double T002=K002+B002-R002;//有诊疗费
			double T003=K003+B003-R003;//有效工本费
			double T004=K004+B004-R004;//有效磁卡费
			#endregion
			#region 填充数据（结帐总表）
			m_lngX+=10;
			m_lngY+=10;
			e.Graphics.DrawString("操作员",TextFont,Brushes.Black,m_lngX,m_lngY);
			m_lngX-=5;
			e.Graphics.DrawString(checkMan,TextFont,Brushes.Black,m_lngX,m_lngY+25);
			e.Graphics.DrawString("开票数",TextFont,Brushes.Black,m_lngX+80,m_lngY);
			e.Graphics.DrawString(tolCont.ToString(),TextFont,Brushes.Black,m_lngX+80,m_lngY+25);
			e.Graphics.DrawString("开票金额",TextFont,Brushes.Black,m_lngX+80*2,m_lngY);
			e.Graphics.DrawString(tolMoney.ToString("0.00"),TextFont,Brushes.Black,m_lngX+80*2,m_lngY+25);
			e.Graphics.DrawString("退票数",TextFont,Brushes.Black,m_lngX+80*3,m_lngY);
			e.Graphics.DrawString(reCont.ToString(),TextFont,Brushes.Black,m_lngX+80*3,m_lngY+25);
			e.Graphics.DrawString("退票金额",TextFont,Brushes.Black,m_lngX+80*4,m_lngY);
			e.Graphics.DrawString(reMoney.ToString("0.00"),TextFont,Brushes.Black,m_lngX+80*4,m_lngY+25);
			e.Graphics.DrawString("恢复票数",TextFont,Brushes.Black,m_lngX+80*5,m_lngY);
			e.Graphics.DrawString(backCont.ToString(),TextFont,Brushes.Black,m_lngX+80*5,m_lngY+25);
			e.Graphics.DrawString("恢复金额",TextFont,Brushes.Black,m_lngX+80*6,m_lngY);
			e.Graphics.DrawString(backMoney.ToString("0.00"),TextFont,Brushes.Black,m_lngX+80*6,m_lngY+25);
			e.Graphics.DrawString("有效票数",TextFont,Brushes.Black,m_lngX+80*7,m_lngY);
			e.Graphics.DrawString(availabilityCont.ToString(),TextFont,Brushes.Black,m_lngX+80*7,m_lngY+25);
			e.Graphics.DrawString("实收金额",TextFont,Brushes.Black,m_lngX+80*8,m_lngY);
			e.Graphics.DrawString(availabilityMoney.ToString("0.00"),TextFont,Brushes.Black,m_lngX+80*8,m_lngY+25);
			m_lngY+=60;
			e.Graphics.DrawString("挂号费：",TextFont,Brushes.Black,m_lngX,m_lngY);
			e.Graphics.DrawString(T001.ToString("0.00"),TextFont,Brushes.Black,m_lngX+szPerWord.Width*5,m_lngY);

			e.Graphics.DrawString("诊疗费：",TextFont,Brushes.Black,m_lngX+szPerWord.Width*10,m_lngY);
			e.Graphics.DrawString(T002.ToString("0.00"),TextFont,Brushes.Black,m_lngX+szPerWord.Width*15,m_lngY);

			e.Graphics.DrawString("工本费：",TextFont,Brushes.Black,m_lngX+szPerWord.Width*20,m_lngY);
			e.Graphics.DrawString(T003.ToString("0.00"),TextFont,Brushes.Black,m_lngX+szPerWord.Width*25,m_lngY);
			m_lngX-=5;
			e.Graphics.DrawString("发票号:",TextFont,Brushes.Black,m_lngX,m_lngY+40);
            SizeF fontWith = e.Graphics.MeasureString("发票号:", TextFont);
            m_lngX += fontWith.Width;
            int intCount = 0;
            float fltWith = 40;
            if (arrList.Count > 0)
            {
                e.Graphics.DrawString(arrList[0].ToString().Trim(), TextFont, Brushes.Black, m_lngX, m_lngY + fltWith);
                for (int i1 = 0; i1 < arrList.Count; i1++)
                {
                    if (arrList[i1].ToString() == ",")
                    {
                        fontWith = e.Graphics.MeasureString(arrList[i1 - 1].ToString().Trim(), TextFont);
                        m_lngX += fontWith.Width;
                        e.Graphics.DrawString("-" + arrList[i1 - 1].ToString().Trim() + ",", TextFont, Brushes.Black, m_lngX, m_lngY + fltWith);
                        intCount++;
                        if (intCount % 4 == 0 && intCount > 0)
                        {
                            //fltWith += 15 * (intCount / 4);
                            fltWith += 40;
                            fontWith = e.Graphics.MeasureString("发票号:", TextFont);
                            m_lngX = m_fltLeftIndentProp;
                        }
                       
                        if (i1 != arrList.Count - 1)
                        {
                            if (m_lngX == m_fltLeftIndentProp)
                            {
                                fontWith = e.Graphics.MeasureString("发票号:", TextFont);
                            }
                            else
                            {
                                fontWith = e.Graphics.MeasureString(arrList[i1 - 1].ToString().Trim() + ",", TextFont);
                            }
                            m_lngX += fontWith.Width;
                            e.Graphics.DrawString(arrList[i1 + 1].ToString().Trim(), TextFont, Brushes.Black, m_lngX, m_lngY + fltWith);
                           
                        }
                    }
                }
                fontWith = e.Graphics.MeasureString(arrList[0].ToString().Trim(), TextFont);
                m_lngX += fontWith.Width;
                e.Graphics.DrawString("-" + arrList[arrList.Count - 1].ToString().Trim(), TextFont, Brushes.Black, m_lngX, m_lngY + fltWith);
            }   
            
            //发票号DATAVIEW
            DataView dv = new DataView(dtInvoNo);

            #region 退票发票
            m_lngX = m_fltLeftIndentProp;
            m_lngY = m_lngY + fltWith + 40;
            e.Graphics.DrawString("退票发票：", TextFont, Brushes.Black, m_lngX, m_lngY);

            fontWith = e.Graphics.MeasureString("退票发票：", TextFont);
            float m_StartPos = m_lngX + fontWith.Width + 2;
            m_lngX = m_StartPos;

            dv.RowFilter = "flag = 3";
            dv.Sort = "invono asc";

            intCount = 0;
            foreach (DataRowView drv in dv)
            {                
                e.Graphics.DrawString(drv["invono"].ToString().Trim() + " ", TextFont, Brushes.Black, m_lngX, m_lngY);
                fontWith = e.Graphics.MeasureString(drv["invono"].ToString().Trim(), TextFont);
                m_lngX += fontWith.Width;

                intCount++;
                if (intCount % 7 == 0)
                {
                    m_lngX = m_StartPos;
                    m_lngY += 40;                    
                }
            }
            #endregion

            #region 恢复发票
            m_lngX = m_fltLeftIndentProp;
            if (intCount == 0 || intCount % 7 != 0)
            {
                m_lngY += 40;
            }
            e.Graphics.DrawString("恢复发票：", TextFont, Brushes.Black, m_lngX, m_lngY);
            
            m_lngX = m_StartPos;

            dv.RowFilter = "flag = 4";
            dv.Sort = "invono asc";

            intCount = 0;
            foreach (DataRowView drv in dv)
            {
                e.Graphics.DrawString(drv["invono"].ToString().Trim() + " ", TextFont, Brushes.Black, m_lngX, m_lngY);
                fontWith = e.Graphics.MeasureString(drv["invono"].ToString().Trim(), TextFont);
                m_lngX += fontWith.Width;

                intCount++;
                if (intCount % 7 == 0)
                {
                    m_lngX = m_StartPos;
                    m_lngY += 40;
                }
            }
            #endregion

            #region 重打发票
            m_lngX = m_fltLeftIndentProp;
            if (intCount == 0 || intCount % 7 != 0)
            {
                m_lngY += 40;
            }
            e.Graphics.DrawString("重打发票：", TextFont, Brushes.Black, m_lngX, m_lngY);

            m_lngX = m_StartPos;

            dv.RowFilter = "flag = 9";
            dv.Sort = "invono asc";

            intCount = 0;
            foreach (DataRowView drv in dv)
            {
                e.Graphics.DrawString(drv["invono"].ToString().Trim() + " ", TextFont, Brushes.Black, m_lngX, m_lngY);
                fontWith = e.Graphics.MeasureString(drv["invono"].ToString().Trim(), TextFont);
                m_lngX += fontWith.Width;

                intCount++;
                if (intCount % 7 == 0)
                {
                    m_lngX = m_StartPos;
                    m_lngY += 40;
                }
            }
            #endregion

            //打印时间
            m_lngX = m_StartPos + 400;
            m_lngY += 50;
            e.Graphics.DrawString("打印时间：", TextFont, Brushes.Black, m_lngX, m_lngY);
            fontWith = e.Graphics.MeasureString("打印时间：", TextFont);
            e.Graphics.DrawString(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), TextFont, Brushes.Black, m_lngX + fontWith.Width + 3, m_lngY);
            m_lngY += 50;
            m_lngX -= 400;
            e.Graphics.DrawString("主管：", TextFont, Brushes.Black, m_lngX-70, m_lngY);
            e.Graphics.DrawString("会计审核：", TextFont, Brushes.Black, m_lngX+100, m_lngY);
            e.Graphics.DrawString("出纳：", TextFont, Brushes.Black, m_lngX + 300, m_lngY);
            e.Graphics.DrawString("缴款人：" + checkMan, TextFont, Brushes.Black, m_lngX + 450, m_lngY);

            #endregion
            #endregion

            #region 退票明细
            /***
			float courrX1;
			float courrY1;
			if(dtRestoreDetail.Rows.Count>0)
			{
			m_lngY+=60;
			string m_strTitle1 = "挂号人员当日退票明细";
			SizeF szTitle1 = e.Graphics.MeasureString(m_strTitle1,m_fntTitle);			
			float fltCurrentX1 = m_lngWidthPage*(float)1.3/3-(long)szTitle.Width/2;//标题文本左上角的X轴坐标
			e.Graphics.DrawString(m_strTitle1,m_fntTitle,Brushes.Black,fltCurrentX1,m_lngY);
			m_lngY+=50;
			m_lngX=m_fltLeftIndentProp;
			e.Graphics.DrawString("结帐日期：",TextFont,Brushes.Black,m_lngX,m_lngY);
			e.Graphics.DrawString(strDate,TextFont,Brushes.Black,m_lngX+szPerWord.Width*4,m_lngY);
				if(isHisstroy)
					e.Graphics.DrawString("己结帐",TextFont,Brushes.Black,m_lngX+szPerWord.Width*4+EndWidth,m_lngY);
			#region 画表格（退票明细）
			m_lngY+=20;
			courrX1=m_lngX;
			courrY1=m_lngY;//courrY1保存表格开始显示位置
				int Showline=dtRestoreDetail.Rows.Count+3;//要显示的线条数
				int ShowRow=dtRestoreDetail.Rows.Count+2;//要显示的行数
				for(int i1=0;i1<Showline;i1++)
				{
					m_lngY+=m_fltRectangleH*(i1-1);//m_lngY保存表格结束显示位置
					e.Graphics.DrawLine(blackPen,courrX1,courrY1+m_fltRectangleH*i1,m_lngWidthPage-m_fltRightIndentProp,courrY1+m_fltRectangleH*i1);
				}

				for(int i1=0;i1<10;i1++)
				{
						switch(i1)
						{
							case 0:
								e.Graphics.DrawLine(blackPen,courrX1+m_fltRectangleW*i1,courrY1,courrX1+m_fltRectangleW*i1,courrY1+m_fltRectangleH*ShowRow);
								e.Graphics.DrawString("流水号",TextFont,Brushes.Black,m_lngX+10,courrY1+10);
								break;
							case 1:
								courrX1+=30;
                                e.Graphics.DrawLine(blackPen, courrX1 + m_fltRectangleW * i1, courrY1, courrX1 + m_fltRectangleW * i1, courrY1 + m_fltRectangleH * (ShowRow - 1));
								e.Graphics.DrawString("发票号",TextFont,Brushes.Black,m_lngX+120,courrY1+10);
								break;
							case 2:
								e.Graphics.DrawLine(blackPen,courrX1+m_fltRectangleW*i1,courrY1,courrX1+m_fltRectangleW*i1,courrY1+m_fltRectangleH*(ShowRow-1));
								e.Graphics.DrawString("姓名",TextFont,Brushes.Black,m_lngX+80*2+50,courrY1+10);
								break;
							case 3:
								e.Graphics.DrawLine(blackPen,courrX1+m_fltRectangleW*i1-10,courrY1,courrX1+m_fltRectangleW*i1-10,courrY1+m_fltRectangleH*(ShowRow-1));
								e.Graphics.DrawString("身份",TextFont,Brushes.Black,m_lngX+80*3+30,courrY1+10);
								break;
							case 4:
								courrX1+=20;
								e.Graphics.DrawLine(blackPen,courrX1+m_fltRectangleW*i1-10,courrY1,courrX1+m_fltRectangleW*i1-10,courrY1+m_fltRectangleH*(ShowRow-1));
								e.Graphics.DrawString("挂号费",TextFont,Brushes.Black,m_lngX+80*4+45,courrY1+10);
								break;
							case 5:
								e.Graphics.DrawLine(blackPen,courrX1+m_fltRectangleW*i1-25,courrY1,courrX1+m_fltRectangleW*i1-25,courrY1+m_fltRectangleH*(ShowRow-1));
								e.Graphics.DrawString("诊疗费",TextFont,Brushes.Black,m_lngX+80*5+30,courrY1+10);
								break;
							case 6:
								e.Graphics.DrawLine(blackPen,courrX1+m_fltRectangleW*i1-30,courrY1,courrX1+m_fltRectangleW*i1-30,courrY1+m_fltRectangleH*(ShowRow-1));
								e.Graphics.DrawString("工本费",TextFont,Brushes.Black,m_lngX+80*6+30,courrY1+10);
								break;
							case 7:
								e.Graphics.DrawLine(blackPen,courrX1+m_fltRectangleW*i1-40,courrY1,courrX1+m_fltRectangleW*i1-40,courrY1+m_fltRectangleH*(ShowRow-1));
								e.Graphics.DrawString("挂号人",TextFont,Brushes.Black,m_lngX+80*7+20,courrY1+10);
								break;
							case 8:
								e.Graphics.DrawLine(blackPen,courrX1+m_fltRectangleW*i1-50,courrY1,courrX1+m_fltRectangleW*i1-50,courrY1+m_fltRectangleH*(ShowRow-1));
								e.Graphics.DrawString("挂号日期",TextFont,Brushes.Black,m_lngX+80*8+10,courrY1+10);
								break;
							case 9:
								e.Graphics.DrawLine(blackPen,courrX1+m_fltRectangleW*i1-50,courrY1,courrX1+m_fltRectangleW*i1-50,courrY1+m_fltRectangleH*ShowRow);
								break;
						}
				}
				courrX1-=50;
				courrY1+=m_fltRectangleH+5;
				double dlrcharge=0;
				courrX1+=50;
				m_lngY=courrY1+m_fltRectangleH*(dtRestoreDetail.Rows.Count-1);//m_lngY当前数据最后一项
				for(int i1=0;i1<dtRestoreDetail.Rows.Count;i1++)
				{
					for(int f2=0;f2<9;f2++)
					{
						switch(f2)
						{
							case 0:
								e.Graphics.DrawString(dtRestoreDetail.Rows[i1]["REGISTERNO_CHR"].ToString(),TextFont,Brushes.Black,m_lngX,courrY1+m_fltRectangleH*i1);
								break;
							case 1:
								courrX1-=20;
								e.Graphics.DrawString(dtRestoreDetail.Rows[i1]["INVNO_CHR"].ToString(),TextFont,Brushes.Black,courrX1+80,courrY1+m_fltRectangleH*i1);
								break;
							case 2:
                                e.Graphics.DrawString(dtRestoreDetail.Rows[i1]["PatientName"].ToString(), TextFont, Brushes.Black, courrX1 + 80 * 2, courrY1 + m_fltRectangleH * i1);
								break;
							case 3:
								e.Graphics.DrawString(dtRestoreDetail.Rows[i1]["PAYTYPENAME_VCHR"].ToString(),TextFont,Brushes.Black,courrX1+80*3-10,courrY1+m_fltRectangleH*i1);
								break;
							case 4:
								courrX1+=20;
                                if (dtRestoreDetail.Rows[i1]["rcharge"] != null && dtRestoreDetail.Rows[i1]["rcharge"].ToString() != "")
                                {
                                    dlrcharge = Convert.ToDouble(dtRestoreDetail.Rows[i1]["rcharge"].ToString());
                                    e.Graphics.DrawString(dlrcharge.ToString("0.00"), TextFont, Brushes.Black, courrX1 + 80 * 4 - 10, courrY1 + m_fltRectangleH * i1);
                                }
                                else
                                {
                                    e.Graphics.DrawString("0.00", TextFont, Brushes.Black, courrX1 + 80 * 4 - 10, courrY1 + m_fltRectangleH * i1);
                                }
                             
								break;
							case 5:
								if(dtRestoreDetail.Rows[i1]["dcharge"]!=null&&dtRestoreDetail.Rows[i1]["dcharge"].ToString()!="")
								{
									dlrcharge=Convert.ToDouble(dtRestoreDetail.Rows[i1]["dcharge"].ToString());
                                    e.Graphics.DrawString(dlrcharge.ToString("0.00"), TextFont, Brushes.Black, courrX1 + 80 * 5 - 25, courrY1 + m_fltRectangleH * i1);
								}
                                else
                                {
                                    e.Graphics.DrawString("0.00", TextFont, Brushes.Black, courrX1 + 80 * 5 - 25, courrY1 + m_fltRectangleH * i1);
                                }

								break;
							case 6:
                                if (dtRestoreDetail.Rows[i1]["gcharge"] != null && dtRestoreDetail.Rows[i1]["gcharge"].ToString() != "")
                                {
                                    dlrcharge = Convert.ToDouble(dtRestoreDetail.Rows[i1]["gcharge"].ToString());
                                    e.Graphics.DrawString(dlrcharge.ToString("0.00"), TextFont, Brushes.Black, courrX1 + 80 * 6 - 30, courrY1 + m_fltRectangleH * i1);
                                }
                                else
                                {
                                    e.Graphics.DrawString("0.00", TextFont, Brushes.Black, courrX1 + 80 * 6 - 30, courrY1 + m_fltRectangleH * i1);
                                }
								break;
							case 7:
								e.Graphics.DrawString(dtRestoreDetail.Rows[i1]["LASTNAME_VCHR"].ToString(),TextFont,Brushes.Black,courrX1+80*7-40,courrY1+m_fltRectangleH*i1);
								break;
							case 8:
								DateTime reGister=Convert.ToDateTime(dtRestoreDetail.Rows[i1]["REGISTERDATE_DAT"].ToString());
								e.Graphics.DrawString(reGister.ToShortDateString(),TextFont,Brushes.Black,courrX1+80*8-50,courrY1+m_fltRectangleH*i1);
								break;
						}
					}

				}
				e.Graphics.DrawString("挂号费：",TextFont,Brushes.Black,m_lngX,m_lngY+m_fltRectangleH+5);
				e.Graphics.DrawString(R001.ToString("0.00"),TextFont,Brushes.Black,m_lngX+szPerWord.Width*5,m_lngY+m_fltRectangleH+5);
				e.Graphics.DrawString("诊疗费：",TextFont,Brushes.Black,m_lngX+szPerWord.Width*10,m_lngY+m_fltRectangleH+5);
				e.Graphics.DrawString(R002.ToString("0.00"),TextFont,Brushes.Black,m_lngX+szPerWord.Width*15,m_lngY+m_fltRectangleH+5);
				e.Graphics.DrawString("工本费：",TextFont,Brushes.Black,m_lngX+szPerWord.Width*20,m_lngY+m_fltRectangleH+5);
				e.Graphics.DrawString(R003.ToString("0.00"),TextFont,Brushes.Black,m_lngX+szPerWord.Width*25,m_lngY+m_fltRectangleH+5);

			}            
			#endregion
            ***/
            #endregion

            #region 还原明细
            /***
            if (backTabel.Rows.Count>0)
			{
			m_lngY+=m_fltRectangleH+65;//m_lngY当前数据最后一项的Y坐标

			string m_strTitle2 = "挂号人员当日恢复票数据明细";
			SizeF szTitle2 = e.Graphics.MeasureString(m_strTitle2,m_fntTitle);			
			float fltCurrentX2 = m_lngWidthPage*(float)1.3/3-(long)szTitle.Width/2;//标题文本左上角的X轴坐标
			e.Graphics.DrawString(m_strTitle2,m_fntTitle,Brushes.Black,fltCurrentX2,m_lngY);
			m_lngY+=50;
			e.Graphics.DrawString("结帐日期：",TextFont,Brushes.Black,m_lngX,m_lngY);
			e.Graphics.DrawString(strDate,TextFont,Brushes.Black,m_lngX+szPerWord.Width*4,m_lngY);
				if(isHisstroy)
					e.Graphics.DrawString("己结帐",TextFont,Brushes.Black,m_lngX+szPerWord.Width*4+EndWidth,m_lngY);
			m_lngX=m_fltLeftIndentProp;
			#region 画表格（还原明细）
			m_lngY+=20;
			courrX1=m_lngX;
			courrY1=m_lngY;//courrY1保存表格开始显示位置
				int Showline=backTabel.Rows.Count+3;//要显示的线条数
				int ShowRow=backTabel.Rows.Count+2;//要显示的行数
				for(int i1=0;i1<Showline;i1++)
				{
					m_lngY+=m_fltRectangleH*(i1-1);//m_lngY保存表格结束显示位置
					e.Graphics.DrawLine(blackPen,courrX1,courrY1+m_fltRectangleH*i1,m_lngWidthPage-m_fltRightIndentProp,courrY1+m_fltRectangleH*i1);
				}

				for(int i1=0;i1<10;i1++)
				{
					switch(i1)
					{
						case 0:
							e.Graphics.DrawLine(blackPen,courrX1+m_fltRectangleW*i1,courrY1,courrX1+m_fltRectangleW*i1,courrY1+m_fltRectangleH*ShowRow);
							e.Graphics.DrawString("流水号",TextFont,Brushes.Black,m_lngX+10,courrY1+10);
							break;
						case 1:
							courrX1+=30;
							e.Graphics.DrawLine(blackPen,courrX1+m_fltRectangleW*i1,courrY1,courrX1+m_fltRectangleW*i1,courrY1+m_fltRectangleH*(ShowRow-1));
							e.Graphics.DrawString("发票号",TextFont,Brushes.Black,m_lngX+120,courrY1+10);
							break;
						case 2:
							e.Graphics.DrawLine(blackPen,courrX1+m_fltRectangleW*i1,courrY1,courrX1+m_fltRectangleW*i1,courrY1+m_fltRectangleH*(ShowRow-1));
							e.Graphics.DrawString("姓名",TextFont,Brushes.Black,m_lngX+80*2+50,courrY1+10);
							break;
						case 3:
							e.Graphics.DrawLine(blackPen,courrX1+m_fltRectangleW*i1-10,courrY1,courrX1+m_fltRectangleW*i1-10,courrY1+m_fltRectangleH*(ShowRow-1));
							e.Graphics.DrawString("身份",TextFont,Brushes.Black,m_lngX+80*3+30,courrY1+10);
							break;
						case 4:
							courrX1+=20;
							e.Graphics.DrawLine(blackPen,courrX1+m_fltRectangleW*i1-10,courrY1,courrX1+m_fltRectangleW*i1-10,courrY1+m_fltRectangleH*(ShowRow-1));
							e.Graphics.DrawString("挂号费",TextFont,Brushes.Black,m_lngX+80*4+45,courrY1+10);
							break;
						case 5:
							e.Graphics.DrawLine(blackPen,courrX1+m_fltRectangleW*i1-25,courrY1,courrX1+m_fltRectangleW*i1-25,courrY1+m_fltRectangleH*(ShowRow-1));
							e.Graphics.DrawString("诊疗费",TextFont,Brushes.Black,m_lngX+80*5+30,courrY1+10);
							break;
						case 6:
							e.Graphics.DrawLine(blackPen,courrX1+m_fltRectangleW*i1-40,courrY1,courrX1+m_fltRectangleW*i1-40,courrY1+m_fltRectangleH*(ShowRow-1));
							e.Graphics.DrawString("工本费",TextFont,Brushes.Black,m_lngX+80*6+20,courrY1+10);
							break;
						case 7:
							e.Graphics.DrawLine(blackPen,courrX1+m_fltRectangleW*i1-40,courrY1,courrX1+m_fltRectangleW*i1-40,courrY1+m_fltRectangleH*(ShowRow-1));
							e.Graphics.DrawString("挂号人",TextFont,Brushes.Black,m_lngX+80*7+20,courrY1+10);
							break;
						case 8:
							e.Graphics.DrawLine(blackPen,courrX1+m_fltRectangleW*i1-50,courrY1,courrX1+m_fltRectangleW*i1-50,courrY1+m_fltRectangleH*(ShowRow-1));
							e.Graphics.DrawString("挂号日期",TextFont,Brushes.Black,m_lngX+80*8+10,courrY1+10);
							break;
						case 9:
							e.Graphics.DrawLine(blackPen,courrX1+m_fltRectangleW*i1-50,courrY1,courrX1+m_fltRectangleW*i1-50,courrY1+m_fltRectangleH*ShowRow);
							break;
					}
				}
				courrX1-=50;
				courrY1+=m_fltRectangleH+5;
				double dlrcharge=0;
				courrX1+=50;
				m_lngY=courrY1+m_fltRectangleH*(backTabel.Rows.Count-1);//m_lngY当前数据最后一项
				for(int i1=0;i1<backTabel.Rows.Count;i1++)
				{
					for(int f2=0;f2<9;f2++)
					{
						switch(f2)
						{
							case 0:
								e.Graphics.DrawString(backTabel.Rows[i1]["REGISTERNO_CHR"].ToString(),TextFont,Brushes.Black,m_lngX,courrY1+m_fltRectangleH*i1);
								break;
							case 1:
								courrX1-=20;
								e.Graphics.DrawString(backTabel.Rows[i1]["INVNO_CHR"].ToString(),TextFont,Brushes.Black,courrX1+80,courrY1+m_fltRectangleH*i1);
								break;
							case 2:
								e.Graphics.DrawString(backTabel.Rows[i1]["PatientName"].ToString(),TextFont,Brushes.Black,courrX1+80*2,courrY1+m_fltRectangleH*i1);
								break;
							case 3:
								e.Graphics.DrawString(backTabel.Rows[i1]["PAYTYPENAME_VCHR"].ToString(),TextFont,Brushes.Black,courrX1+80*3-10,courrY1+m_fltRectangleH*i1);
								break;
							case 4:
								courrX1+=20;
                                if (backTabel.Rows[i1]["rcharge"] != null && backTabel.Rows[i1]["rcharge"].ToString() != "")
                                {
                                    dlrcharge = Convert.ToDouble(backTabel.Rows[i1]["rcharge"].ToString());
                                    e.Graphics.DrawString(dlrcharge.ToString("0.00"), TextFont, Brushes.Black, courrX1 + 80 * 4 - 10, courrY1 + m_fltRectangleH * i1);
                                }
                                else
                                {
                                    e.Graphics.DrawString("0.00", TextFont, Brushes.Black, courrX1 + 80 * 4 - 10, courrY1 + m_fltRectangleH * i1);
                                }
								break;
							case 5:
                                if (backTabel.Rows[i1]["dcharge"] != null && backTabel.Rows[i1]["dcharge"].ToString() != "")
                                {
                                    dlrcharge = Convert.ToDouble(backTabel.Rows[i1]["dcharge"].ToString());
                                    e.Graphics.DrawString(dlrcharge.ToString("0.00"), TextFont, Brushes.Black, courrX1 + 80 * 5 - 25, courrY1 + m_fltRectangleH * i1);
                                }
                                else
                                {
                                    e.Graphics.DrawString("0.00", TextFont, Brushes.Black, courrX1 + 80 * 5 - 25, courrY1 + m_fltRectangleH * i1);
                                }
								
								break;
							case 6:
                                if (backTabel.Rows[i1]["gcharge"] != null && backTabel.Rows[i1]["gcharge"].ToString() != "")
                                {
                                    dlrcharge = Convert.ToDouble(backTabel.Rows[i1]["gcharge"].ToString());
                                    e.Graphics.DrawString(dlrcharge.ToString("0.00"), TextFont, Brushes.Black, courrX1 + 80 * 6 - 40, courrY1 + m_fltRectangleH * i1);
                                }
                                else
                                {
                                    e.Graphics.DrawString("0.00", TextFont, Brushes.Black, courrX1 + 80 * 6 - 40, courrY1 + m_fltRectangleH * i1);
                                }
								
								break;
							case 7:
								e.Graphics.DrawString(this.LoginInfo.m_strEmpName,TextFont,Brushes.Black,courrX1+80*7-40,courrY1+m_fltRectangleH*i1);
								break;
							case 8:
								DateTime reGister=Convert.ToDateTime(backTabel.Rows[i1]["REGISTERDATE_DAT"].ToString());
								e.Graphics.DrawString(reGister.ToShortDateString(),TextFont,Brushes.Black,courrX1+80*8-50,courrY1+m_fltRectangleH*i1);
								break;

//							case 0:
//								e.Graphics.DrawString(backTabel.Rows[i1]["REGISTERNO_CHR"].ToString(),TextFont,Brushes.Black,m_lngX,courrY1+m_fltRectangleH*i1);
//								break;
//							case 1:
//								e.Graphics.DrawString(backTabel.Rows[i1]["INVNO_CHR"].ToString(),TextFont,Brushes.Black,courrX1+80,courrY1+m_fltRectangleH*i1);
//								break;
//							case 2:
//								e.Graphics.DrawString(backTabel.Rows[i1]["PatientName"].ToString(),TextFont,Brushes.Black,courrX1+80*2,courrY1+m_fltRectangleH*i1);
//								break;
//							case 3:
//								e.Graphics.DrawString(backTabel.Rows[i1]["PAYTYPENAME_VCHR"].ToString(),TextFont,Brushes.Black,courrX1+80*3,courrY1+m_fltRectangleH*i1);
//								break;
//							case 4:
//								if(backTabel.Rows[i1]["rcharge"].ToString()!="")
//								{
//									dlrcharge=Convert.ToDouble(backTabel.Rows[i1]["rcharge"].ToString());
//								}
//								e.Graphics.DrawString(dlrcharge.ToString("0.00"),TextFont,Brushes.Black,courrX1+80*4-30,courrY1+m_fltRectangleH*i1);
//								break;
//							case 5:
//								if(backTabel.Rows[i1]["dcharge"].ToString()!="")
//								{
//									dlrcharge=Convert.ToDouble(backTabel.Rows[i1]["dcharge"].ToString());
//								}
//								e.Graphics.DrawString(dlrcharge.ToString("0.00"),TextFont,Brushes.Black,courrX1+80*5-40,courrY1+m_fltRectangleH*i1);
//								break;
//							case 6:
//								if(backTabel.Rows[i1]["gcharge"].ToString()!="")
//								{
//									dlrcharge=Convert.ToDouble(backTabel.Rows[i1]["gcharge"].ToString());
//								}
//								e.Graphics.DrawString(dlrcharge.ToString("0.00"),TextFont,Brushes.Black,courrX1+80*6-40,courrY1+m_fltRectangleH*i1);
//								break;
//							case 7:
//								e.Graphics.DrawString(this.LoginInfo.m_strEmpName,TextFont,Brushes.Black,courrX1+80*7-40,courrY1+m_fltRectangleH*i1);
//								break;
//							case 8:
//								DateTime reGister=Convert.ToDateTime(backTabel.Rows[i1]["REGISTERDATE_DAT"].ToString());
//								e.Graphics.DrawString(reGister.ToShortDateString(),TextFont,Brushes.Black,courrX1+80*8-50,courrY1+m_fltRectangleH*i1);
//								break;
						}
					}

				}
				e.Graphics.DrawString("挂号费：",TextFont,Brushes.Black,m_lngX,m_lngY+m_fltRectangleH+5);
				e.Graphics.DrawString(B001.ToString("0.00"),TextFont,Brushes.Black,m_lngX+szPerWord.Width*5,m_lngY+m_fltRectangleH+5);
				e.Graphics.DrawString("诊疗费：",TextFont,Brushes.Black,m_lngX+szPerWord.Width*10,m_lngY+m_fltRectangleH+5);
				e.Graphics.DrawString(B002.ToString("0.00"),TextFont,Brushes.Black,m_lngX+szPerWord.Width*15,m_lngY+m_fltRectangleH+5);
				e.Graphics.DrawString("工本费：",TextFont,Brushes.Black,m_lngX+szPerWord.Width*20,m_lngY+m_fltRectangleH+5);
				e.Graphics.DrawString(B003.ToString("0.00"),TextFont,Brushes.Black,m_lngX+szPerWord.Width*25,m_lngY+m_fltRectangleH+5);

			}
			#endregion
            ***/
			#endregion
            
		}
		#endregion

		#region 挂号结帐报表
		private string minno="";
		private string maxno="";
		private string regempno="";
		private string regdate="";
		private string checkdate="";
		private string checkempno="";
		public void m_CheckOutReg()
		{
			System.Data.DataTable dtSource= new DataTable();
			System.Data.DataTable dtSourcedetail= new DataTable();
			string strregno = "";
			if(this.m_txtRegisterp.Text.Trim() == "")
			{
				m_clsDcrl.m_lngGetCheckOutSource("",out dtSource,this.m_dtpdate.Value.ToShortDateString(),out dtSourcedetail,out strregno);
			}
			else
			{
				m_clsDcrl.m_lngGetCheckOutSourceP("",out dtSource,this.m_dtpdate.Value.ToShortDateString(),(string)m_txtRegisterp.Tag,out dtSourcedetail,out strregno);
				this.regempno = (string)m_txtRegisterp.Tag;
			}
			this.minno = strregno;
			this.regdate = this.m_dtpdate.Value.ToShortDateString();

			if(dtSource .Rows.Count == 0) return;
			System.Data.DataTable dt = this.SetTable(dtSource);
			System.Data.DataTable dt1 = this.SetTable(dtSourcedetail);
			if(dt1.Columns.Count != 0)
			{
				dt1.Columns[dt1.Columns.Count-1].ColumnName = "decimal22";
			}
			com.digitalwave.iCare.gui.HIS.Print.CryCheckoutReg CryCheckoutReg = new com.digitalwave.iCare.gui.HIS.Print.CryCheckoutReg();
			com.digitalwave.iCare.gui.HIS.Print.Cryreturnreg Cryreturnreg = new com.digitalwave.iCare.gui.HIS.Print.Cryreturnreg();
			CryCheckoutReg.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.DefaultPaperOrientation;
			CryCheckoutReg.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
			CryCheckoutReg.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Auto;
			CryCheckoutReg.PrintOptions.PrinterDuplex = CrystalDecisions.Shared.PrinterDuplex.Default;

			Cryreturnreg.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.DefaultPaperOrientation;
			Cryreturnreg.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
			Cryreturnreg.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Auto;
			Cryreturnreg.PrintOptions.PrinterDuplex = CrystalDecisions.Shared.PrinterDuplex.Default;

			((TextObject)CryCheckoutReg.ReportDefinition.ReportObjects["date"]).Text ="统计截止日期：" + this.m_dtpdate.Value.ToShortDateString();
			((TextObject)CryCheckoutReg.ReportDefinition.ReportObjects["empNO"]).Text =this.m_txtRegisterp.Text.Trim();
			int tolcount=0;
			for(int i1=0;i1<dt.Rows.Count;i1++)
			{
					tolcount+=Convert.ToInt32(dt.Rows[i1][1]);
			}
						((TextObject)CryCheckoutReg.ReportDefinition.ReportObjects["txtavailabilitycount"]).Text =tolcount.ToString()+"张";

			int retolcount=0;
			for(int i1=0;i1<dt.Rows.Count;i1++)
			{
					retolcount+=Convert.ToInt32(dt.Rows[i1][7]);
			}
			((TextObject)CryCheckoutReg.ReportDefinition.ReportObjects["txtrecount"]).Text =retolcount.ToString()+"张";
			((TextObject)CryCheckoutReg.ReportDefinition.ReportObjects["txttolcount"]).Text =tolcount.ToString()+"张";
			CryCheckoutReg.SetDataSource(dt);
			this.cryReportViewer.ReportSource = CryCheckoutReg;
			Cryreturnreg.SetDataSource(dt1);
		}

		#region 设置表列名
		/// <summary>
		/// 设置表列名
		/// </summary>
		/// <param name="dt1"></param>
		/// <returns></returns>
		private System.Data.DataTable SetTable(System.Data.DataTable dt1)
		{
			System.Data.DataTable dt = dt1.Clone();
			foreach(DataRow dr in dt1.Rows)
			{
				//if(dr["摘要"].ToString() != "合计")
				dt.ImportRow(dr);
			}
			
			int i1=1;
			int i2=1;
			int i3=1;
			foreach(DataColumn dc in dt.Columns)
			{
				if(dc.DataType.ToString() == "System.Int32" ||
					dc.DataType.ToString() == "System.String")
				{
					dc.ColumnName="VarChar"+i1.ToString();
					i1 ++;
				}
				if(dc.DataType.ToString() == "System.Decimal")
				{
					dc.ColumnName="Decimal"+i2.ToString();
					i2 ++;
					if(i2 == 11) i2 = 12;
				}
				if(dc.DataType.ToString() == "System.DateTime")
				{
					dc.ColumnName="DateTime"+i3.ToString();
					i3 ++;
				}
			}
			dt.TableName="temp";
			return dt;
		}
		#endregion

		private void m_SetCheckoutData()
		{
			if(this.minno.IndexOf("-")>=0)
			{
				this.maxno = this.minno.Substring(this.minno.IndexOf("-")+1);
				this.minno = this.minno.Substring(0,this.maxno.Length);
			}
			this.checkdate = this.m_GetServTime().ToShortDateString();
			checkempno= this.LoginInfo.m_strEmpID;
		}
		#region 取得服务器的当前时间
		public DateTime m_GetServTime()
		{
			DateTime DTR;
			com.digitalwave.iCare.middletier.HIS.clsGetServerDate objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsGetServerDate)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsGetServerDate));
			DTR=objSvc.m_GetServerDate();
			//com.digitalwave.iCare.middletier.HIS.clsInvoiceManageSvc aa = new com.digitalwave.iCare.middletier.HIS.clsInvoiceManageSvc();
			//aa.
			return DTR;
		}
		#endregion
		private void m_btnRef_Click(object sender, System.EventArgs e)
		{
			this.m_btnCheckOut.Enabled = true;
			try
			{
				if((string)m_txtRegisterp.Tag== "" || m_txtRegisterp.Tag == null)
				{
					MessageBox.Show("请填挂号员!","提示！");
					return;
				}
			}
			catch
			{
				MessageBox.Show("请填挂号员!","提示！");
				return;
			}
			this.Cursor = Cursors.WaitCursor;
			m_CheckOutReg();
			this.Cursor = Cursors.Default;
			
		}
		#endregion

		#region 显示没有处方权的员工列表
		/// <summary>
		///显示没有处方权的员工列表 
		/// </summary>
		/// <param name="sender"></param>
		public void m_ShowDept(object sender)
		{
			
			
			this.m_pnlAllPlan.Left=((TextBox)sender).Left;
			this.m_pnlAllPlan.Top= ((TextBox)sender).Top+((TextBox)sender).Height;
			
			this.m_pnlAllPlan.Visible=true;
			this.Controls.Add(this.m_pnlAllPlan);
			this.m_pnlAllPlan.Tag = ((TextBox)sender).Name;
			this.m_pnlAllPlan.Controls.Add(this.m_lsvAllplan);
			this.m_pnlAllPlan.BringToFront();
		}
		public clsEmployeeVO[] m_clsEmployeeVo = null;
		private void FillDoc()
		{
			if(this.m_lsvAllplan.Columns.Count >0)
				return;
			clsEmployeeVO[] objResultArr=m_clsEmployeeVo;
			this.m_lsvAllplan.Columns.Clear();
			this.m_lsvAllplan.Columns.Add("",50,HorizontalAlignment.Center);
			this.m_lsvAllplan.Columns.Add("医生姓名",100,HorizontalAlignment.Center);
			this.m_lsvAllplan.Columns.Add("拼音码",70,HorizontalAlignment.Center);
			this.m_lsvAllplan.ResumeLayout(false);
			this.m_lsvAllplan.Items.Clear();
			string strDate=clsMain.IsNullToString(clsRegister.m_strRegisterDate,null);
			long lngRes=0;
			
			if(objResultArr == null)
			{
				lngRes = clsDomain.m_lngGetOPDoctorList("",out objResultArr);
				m_clsEmployeeVo = objResultArr;
			}
			else
			{
				lngRes=1;
			}
			if((lngRes>0)&&(objResultArr != null))
			{
				if (objResultArr.Length > 0)
				{
					ListViewItem lvw=null;
					for(int i1=0; i1<objResultArr.Length;i1++)
					{
						lvw=new ListViewItem(objResultArr[i1].strEmpNO);
						lvw.SubItems.Add(objResultArr[i1].strName);
						lvw.SubItems.Add(objResultArr[i1].strPYCode);
						lvw.Tag=objResultArr[i1];
						this.m_lsvAllplan.Items.Add(lvw);
						
					}
				}
			}
			this.m_lsvAllplan.Items[0].Selected = true;
		}

//		#region 填充没有开处方权的员工到列表
//		/// <summary>
//		/// 填充没有开处方权的员工到列表
//		/// </summary>
//		public void m_lngFillToList()
//		{
//			DataTable objResultArrNo = null;
//			clsDomain.m_lngGetEmployeeNo(out objResultArrNo);
//			if(objResultArrNo.Rows.Count>0)
//			{
//				for(int i1=0;i1<objResultArrNo.Rows.Count;i1++)
//				{
//					ListViewItem LisTemp=null;
//					LisTemp=new ListViewItem(objResultArrNo.Rows[i1]["EMPID_CHR"].ToString());
//					LisTemp.SubItems.Add(objResultArrNo.Rows[i1]["LASTNAME_VCHR"].ToString());
//					LisTemp.Tag=objResultArrNo.Rows[i1];
//					m_lsvAllplan.Items.Add(LisTemp);
//				}
//			}
//
//		}
//		#endregion

		public long m_FindLvw(string strValues)
		{
			for(int i = 0;i<this.m_lsvAllplan.Items.Count;i++)
			{
				if(this.m_lsvAllplan.Items[i].SubItems[0].Text.IndexOf(strValues)>=0
					|| this.m_lsvAllplan.Items[i].SubItems[1].Text.IndexOf(strValues)>=0)
				{
					this.m_lsvAllplan.Items[i].Selected = true;
				}
				else
				{
					this.m_lsvAllplan.Items[i].Selected = false;
				}
				if(this.m_lsvAllplan.Items[i].SubItems[0].Text.Trim() == strValues.Trim()
					|| this.m_lsvAllplan.Items[i].SubItems[1].Text.Trim() == strValues.Trim())
				{
					this.m_lsvAllplan.Items[i].Selected = true;
					clsRegister.m_objDiagDoctor=(clsEmployeeVO)this.m_lsvAllplan.Items[i].Tag;
					this.m_txtRegisterp.Text=clsRegister.m_objDiagDoctor.strName;
					this.m_pnlAllPlan.Visible = false;
					this.m_btnRef.Focus();
					return 1;
				}
			}
			return 0;
		}

		private bool FilltxtByDoc()
		{
			long lngRes=0;
			if(this.m_lsvAllplan.SelectedItems.Count == 0) return false;
			clsOPDoctorPlan_VO objResult=new clsOPDoctorPlan_VO();
			clsRegister.m_objDiagDoctor=(clsEmployeeVO)this.m_lsvAllplan.SelectedItems[0].Tag;
			int lngLimitNo=clsRegister.m_objDiagDoctor.intStatus;
			
			this.m_txtRegisterp.Text=clsRegister.m_objDiagDoctor.strName;
			this.m_pnlAllPlan.Visible = false;
			this.m_btnRef.Focus();
			return true;
		}
		#endregion

		private void m_txtRegType_Leave(object sender, System.EventArgs e)
		{
			try
			{
				if(this.ActiveControl.Name != "m_lsvAllplan")
					this.m_pnlAllPlan.Visible = false;			
				
			}
			catch{}
		}

		private void m_txtRegisterp_Enter(object sender, System.EventArgs e)
		{

		}

		private void m_lvItem_Click(object sender, System.EventArgs e)
		{
			this.FilltxtByDoc();
		}
		private void m_txtRegisterp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				if(!this.m_lsvAllplan.Visible)
				{
					if(this.m_txtRegisterp.Text.Trim() != "")
					{
						if(this.m_FindLvw(this.m_txtRegisterp.Text.Trim())==0)
						{
							this.m_ShowDept((object)this.m_txtRegisterp);
						}
						else
						{
							this.m_lsvAllplan.Visible = false;
						}
					}
					return;
				}
				if(m_lsvAllplan.Items.Count !=0 && this.m_pnlAllPlan.Visible == true)
				{
					if(!this.FilltxtByDoc())
					{
						return;
					}
				}
				else if(m_lsvAllplan.Items.Count ==0)
				{
					((TextBox)sender).Text = "";
				}
				this.m_pnlAllPlan.Visible = false;
				this.m_btnRef.Focus();
			}
			if(e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
			{
				int index = 0;
				for(int i=0;i<this.m_lsvAllplan.Items.Count;i++)
				{
					if(this.m_lsvAllplan.Items[i].Selected)
					{
						index = i;
					}
				}
				this.m_UpDown(index,e,(object)this.m_lsvAllplan);
			}
		}
		public void m_UpDown(int index,System.Windows.Forms.KeyEventArgs e,object sender)
		{
			if(((ListView)sender).Items.Count>0)
			{
				if(index == ((ListView)sender).Items.Count-1 && e.KeyCode == Keys.Down)
				{
					((ListView)sender).Items[index].Selected = false;
					((ListView)sender).Items[0].Selected = true;
					((ListView)sender).Items[0].EnsureVisible();
				}
				if(index == 0 && e.KeyCode == Keys.Up)
				{
					((ListView)sender).Items[0].Selected = false;
					((ListView)sender).Items[((ListView)sender).Items.Count-1].Selected = true;
					((ListView)sender).Items[((ListView)sender).Items.Count-1].EnsureVisible();
				}
				if(index>0 && index<=((ListView)sender).Items.Count-1 && e.KeyCode == Keys.Up)
				{
					((ListView)sender).Items[index].Selected = false;
					((ListView)sender).Items[index-1].Selected = true;
					((ListView)sender).Items[index-1].EnsureVisible();
				}
				if(index>=0 && index<((ListView)sender).Items.Count-1 && e.KeyCode == Keys.Down)
				{
					((ListView)sender).Items[index].Selected = false;
					((ListView)sender).Items[index+1].Selected = true;
					((ListView)sender).Items[index+1].EnsureVisible();
				}
			}
		}
		
		private void m_txtPatType_TextChanged(object sender, System.EventArgs e)
		{
			if(((TextBox)sender).Text == "")
			{
				clsRegister.m_objDiagDoctor = new clsEmployeeVO();
			}
			
			
		}	
		
		private void m_lsvAllplan_Click(object sender, System.EventArgs e)
		{
			this.FilltxtByDoc();
		}

		private void m_lsvAllplan_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar == (char)13)
			this.FilltxtByDoc();
		}

		private void m_btnCheckOut_Click(object sender, System.EventArgs e)
		{
			if(dtTolSource.Rows.Count==0&&dtRestoreDetail1.Rows.Count==0)
			{
				MessageBox.Show("当前没有可结帐的数据","icare",MessageBoxButtons.OK,MessageBoxIcon.Stop);
				return;
			}
			string strDate=DateTime.Now.ToShortDateString();

            long lngRes = 0;

            //long lngRes=m_clsDcrl.m_lngCheckEnd(this.LoginInfo.m_strEmpID,strDate);
            //if(lngRes==3)
            //{
            //    MessageBox.Show("你今天己经结了帐，不可以再结帐！","icare",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            //    return;
            //}
			if(MessageBox.Show("是否要结帐？结帐后数据不能再修改","icare",MessageBoxButtons
				.YesNo,MessageBoxIcon.Question)==DialogResult
				.No)
				return;
            com.digitalwave.iCare.middletier.HIS.clsHisBase HisBase = (com.digitalwave.iCare.middletier.HIS.clsHisBase)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsHisBase));
			this.m_SetCheckoutData();
			this.Cursor = Cursors.WaitCursor;
            //string checknowdate=HisBase.s_GetServerDate().ToString("yyyy-MM-dd HH:mm:ss");
            //lngRes = m_clsDcrl.m_lngGetCheckOutReg(checknowdate, this.LoginInfo.m_strEmpID, dtTolSource, dtRestoreDetail1);

            string checknowdate = "";

            lngRes = m_clsDcrl.m_lngGetCheckOutReg(this.LoginInfo.m_strEmpID, out checknowdate);
			if(lngRes==1)
			{
				DataRow newRow=dtHistory.NewRow();
				newRow["Column1"]="";
				newRow["BALANCE_DAT"]=checknowdate;
				dtHistory.Rows.Add(newRow);
				//this.Showprint.Document=this.PritDoc;
				this.ctlDgFind.m_mthSelectARow(dtHistory.Rows.Count-1);
                //this.m_btnCheckOut.Enabled = false;

                /***新增***/
                isHistory = 1;
                m_btnCheckOut.Enabled = false;
                m_btnPrint.Enabled = true;
                this.Showprint.Document = this.PritDoc;                
                Showprint.InvalidatePreview();
                /*********/
            }
			this.Cursor = Cursors.Default;
            //m_CheckOutReg();
		}
		#region 获取当前未结帐数据
		private void m_btnqul_Click(object sender, System.EventArgs e)
		{
			isHistory=0;
			m_btnPrint.Enabled=false;
			m_btnCheckOut.Enabled=true;
			Showprint.Document=this.PritDoc;
            Showprint.InvalidatePreview();
		}
		#endregion

		private void objPrintDoc_PrintPage(object sender,System.Drawing.Printing.PrintPageEventArgs e)
		{
			m_mthQueryReport(e);
		}

		#region 加载历史查询数据
		System.Data.DataTable dtHistoryDetail= new DataTable();
		string strempno;
		System.Data.DataTable dtRestoreDetail= new DataTable();
		string m_checkoutreg="";
		private void m_mthQueryReport(System.Drawing.Printing.PrintPageEventArgs e)
		{
			long lngRes=1;
			if(ClickInt!=1)//叛断是不是用户点击“打印按钮引发的事件”还是点击“历史查询按钮引发的事件”
			{
				frmHistoryCheckOut m_frmHistoryCheckOut = new frmHistoryCheckOut((string)m_txtRegisterp.Tag,this.LoginInfo.m_strEmpNo);
				m_checkoutreg=m_frmHistoryCheckOut.m_mthSelectItem();
				strempno=this.LoginInfo.m_strEmpID;
				lngRes=m_clsDcrl.m_lngHistoryReport(out dtHistoryDetail, m_checkoutreg,strempno,out  dtRestoreDetail);
				ClickInt=1;
			}
			if(lngRes>0)
			{
//				m_lngPrint(e,m_checkoutreg,dtHistoryDetail,dtRestoreDetail,true);
			}
			else
			{
				MessageBox.Show("获取历史数据失败！","系统提示");
			}
			m_btnCheckOut.Enabled=false;
			dtTolSource=null;
		}
		#endregion

		int   ClickInt=0;//标识用户点击的是什么按钮
		private void m_btnPrint_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(dtTolSource.Rows.Count==0&&dtRestoreDetail1.Rows.Count==0)
				{
					MessageBox.Show("当前没有可打印数据！","Icare",MessageBoxButtons.OK,MessageBoxIcon.Stop);
				}
				else
				{
                    this.pageSetupDialog1.Document = this.PritDoc;
                    if (this.pageSetupDialog1.ShowDialog() == DialogResult.OK)
                    {
                        this.PritDoc.PrinterSettings.PrinterName = this.pageSetupDialog1.PrinterSettings.PrinterName;
                        this.PritDoc.Print();
                    }
                    else
                    {
                        return;
                    }
				}
			}
			catch
			{
				MessageBox.Show("连接打印机失败！","Icare",MessageBoxButtons.OK,MessageBoxIcon.Stop);
			}
		}

		private void m_btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void frmCheckOutRegReport_Load(object sender, System.EventArgs e)
		{
			starDate.Value=DateTime.Now;
			EndDate.Value=DateTime.Now;
			m_txtRegisterp.Text=this.LoginInfo.m_strEmpName;
			m_txtRegisterp.Tag=this.LoginInfo.m_strEmpID;
			m_txtRegisterp.Enabled=false;
			starDate.Value=Convert.ToDateTime(starDate.Value.Year.ToString()+"-"+starDate.Value.Month.ToString()+"-"+"01");
			DataTable dtCheckMan=new DataTable();
			this.m_clsDcrl.m_lngGetCheckMan(out dtCheckMan);
			if(dtCheckMan.Rows.Count>0)
			{
				for(int i1=0;i1<dtCheckMan.Rows.Count;i1++)
				{
					m_cboCheckMan.Item.Add(dtCheckMan.Rows[i1]["lastname_vchr"].ToString(),dtCheckMan.Rows[i1]["BALANCEEMP_CHR"].ToString());
				}
			}
		}
		bool blisDoctorDean=false;
		public bool isDoctorDean
		{
			set
			{
				blisDoctorDean=value;
			}
			get
			{
				return blisDoctorDean;
			}
		}

		public void m_isDoctorDean(string strYes)
		{
			if(strYes=="1")
			{
				label2.Visible=false;
				m_txtRegisterp.Visible=false;
				label1.Visible=false;
				m_dtpdate.Visible=false;
				m_btnqul.Enabled=false;
				m_btnCheckOut.Enabled=false;
				label5.Visible=true;
				m_cboCheckMan.Visible=true;
				m_btnPrint.Enabled=true;
				isDoctorDean=true;
				btnCheck.Visible=true;

			}
			else
			{
				isDoctorDean=false;
			}
			this.Show();
			

		}


		private void frmCheckOutRegReport_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
				if(e.KeyCode==Keys.F10)
					m_btnCheckOut_Click(sender,e);
				if(e.KeyCode==Keys.F7)
					m_btnqul_Click(sender,e);
				if(e.KeyCode==Keys.F9)
				{
					m_btnPrint_Click(sender,e);
				}
				if(e.KeyCode==Keys.F6)
					this.Close();
			if(e.KeyCode==Keys.F2)
			{
				m_getHistoryData();
			}
		}

		private void tabControl1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.F5)
				m_btnRef_Click(sender,e);
			if(e.KeyCode==Keys.F10)
				m_btnCheckOut_Click(sender,e);
			if(e.KeyCode==Keys.F7)
				m_btnqul_Click(sender,e);
			if(e.KeyCode==Keys.F9)
			{
				this.cryReportViewer.PrintReport();
//				this.cryReturnRegView.PrintReport();
			}
			if(e.KeyCode==Keys.F6)
				this.Close();
		}

		private void m_dtpdate_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.F5)
				m_btnRef_Click(sender,e);
			if(e.KeyCode==Keys.F10)
				m_btnCheckOut_Click(sender,e);
			if(e.KeyCode==Keys.F7)
				m_btnqul_Click(sender,e);
			if(e.KeyCode==Keys.F9)
			{
				this.cryReportViewer.PrintReport();
//				this.cryReturnRegView.PrintReport();
			}
			if(e.KeyCode==Keys.F6)
				this.Close();
		
		}

		private void PritDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			m_lngGetData(e);
		
		}

		private void Showprint_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.F5)
				m_btnRef_Click(sender,e);
			if(e.KeyCode==Keys.F10)
				m_btnCheckOut_Click(sender,e);
			if(e.KeyCode==Keys.F7)
				m_btnqul_Click(sender,e);
			if(e.KeyCode==Keys.F9)
			{
				this.cryReportViewer.PrintReport();
				//				this.cryReturnRegView.PrintReport();
			}
			if(e.KeyCode==Keys.F6)
				this.Close();
		}

		private void textBox1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.F5)
				m_btnRef_Click(sender,e);
			if(e.KeyCode==Keys.F10)
				m_btnCheckOut_Click(sender,e);
			if(e.KeyCode==Keys.F7)
				m_btnqul_Click(sender,e);
			if(e.KeyCode==Keys.F9)
			{
				this.cryReportViewer.PrintReport();
				//				this.cryReturnRegView.PrintReport();
			}
			if(e.KeyCode==Keys.F6)
				this.Close();
		}

		private void starDate_ValueChanged(object sender, System.EventArgs e)
		{
			m_getHistoryData();
		}

		private void EndDate_ValueChanged(object sender, System.EventArgs e)
		{
			m_getHistoryData();
		}

		private void ctlDgFind_m_evtDoubleClickCell(object sender, com.digitalwave.controls.datagrid.clsDGTextMouseClickEventArgs e)
		{
			isHistory=1;
			m_btnCheckOut.Enabled=false;
			m_btnPrint.Enabled=true;
			this.Showprint.Document=this.PritDoc;
            //Type type = Showprint.GetType();
            //BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly;
            //FieldInfo[] fields = type.GetFields(flags);
            //PrintPreviewControl printCtrl = null;
            //foreach (FieldInfo field in fields)
            //{
            //    object t = field.GetValue(Showprint);
            //    if (t is PrintPreviewControl)
            //    {
            //        printCtrl = (PrintPreviewControl)t;
            //        break;
            //    }
            //}
            //if (printCtrl != null)
            Showprint.InvalidatePreview();
		}

		private void btnCheck_Click(object sender, System.EventArgs e)
		{
			m_getHistoryData();
		}

        private void PritDoc_BeginPrint(object sender, PrintEventArgs e)
        {
            this.PritDoc.DefaultPageSettings.Landscape = false;
            System.Drawing.Printing.PaperSize ps = new System.Drawing.Printing.PaperSize("日结算报表", 828, 700);
            this.PritDoc.DefaultPageSettings.PaperSize = ps;
        }
		
	}
}
