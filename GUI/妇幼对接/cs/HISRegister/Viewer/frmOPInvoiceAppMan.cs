using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 门诊发票管理
	/// 作者： 徐斌辉
	/// 时间： Aug 23, 2004
	/// </summary>
	public class frmOPInvoiceAppMan: com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		#region 控件申明

        private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
		internal System.Windows.Forms.TextBox m_txtAPPUSERID_CHR2;
		internal System.Windows.Forms.DateTimePicker m_dtpEndAPPLY_DAT;
        internal System.Windows.Forms.DateTimePicker m_dtpStartAPPLY_DAT;
		internal System.Windows.Forms.ListView m_lstApplyInvoiceMan;
		private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
		private PinkieControls.ButtonXP cmdFind;
		private PinkieControls.ButtonXP cmdCancellation;
		private PinkieControls.ButtonXP cmdPrint;
		private PinkieControls.ButtonXP cmdClose;
        private System.Windows.Forms.Label label8;
		#endregion

        private ColumnHeader columnHeader1;
        private GradientPanel gradientPanel1;
        private TableLayoutPanel tableLayoutPanel1;
        internal Label label10;
        internal TextBox m_txtINVOICENUMBET_INT;
        internal TextBox m_txtINVOICENOTO_VCHR;
        internal TextBox m_txtINVOICENOFROM_VCHR;
        private Label label9;
        internal PinkieControls.ButtonXP cmdConfirm;
        internal DateTimePicker m_dtpAPPLY_DAT;
        internal TextBox m_txtAPPUSERID_CHR;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        internal TextBox m_txtAPPUSERNAME_CHR;
        private PinkieControls.ButtonXP cmdEmpty;
        private ComboBox cboType;
        private Label label11;

		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmOPInvoiceAppMan()
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_txtAPPUSERID_CHR2 = new System.Windows.Forms.TextBox();
            this.m_dtpStartAPPLY_DAT = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.cmdClose = new PinkieControls.ButtonXP();
            this.cmdPrint = new PinkieControls.ButtonXP();
            this.cmdCancellation = new PinkieControls.ButtonXP();
            this.cmdFind = new PinkieControls.ButtonXP();
            this.m_dtpEndAPPLY_DAT = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.m_lstApplyInvoiceMan = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.gradientPanel1 = new com.digitalwave.iCare.gui.HIS.GradientPanel();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.m_txtINVOICENUMBET_INT = new System.Windows.Forms.TextBox();
            this.m_txtINVOICENOTO_VCHR = new System.Windows.Forms.TextBox();
            this.m_txtINVOICENOFROM_VCHR = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmdConfirm = new PinkieControls.ButtonXP();
            this.m_dtpAPPLY_DAT = new System.Windows.Forms.DateTimePicker();
            this.m_txtAPPUSERID_CHR = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtAPPUSERNAME_CHR = new System.Windows.Forms.TextBox();
            this.cmdEmpty = new PinkieControls.ButtonXP();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.gradientPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.m_lstApplyInvoiceMan);
            this.panel2.Location = new System.Drawing.Point(0, 112);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(992, 500);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.m_txtAPPUSERID_CHR2);
            this.panel3.Controls.Add(this.m_dtpStartAPPLY_DAT);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.cmdClose);
            this.panel3.Controls.Add(this.cmdPrint);
            this.panel3.Controls.Add(this.cmdCancellation);
            this.panel3.Controls.Add(this.cmdFind);
            this.panel3.Controls.Add(this.m_dtpEndAPPLY_DAT);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(0, 448);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(988, 48);
            this.panel3.TabIndex = 1;
            // 
            // m_txtAPPUSERID_CHR2
            // 
            this.m_txtAPPUSERID_CHR2.Location = new System.Drawing.Point(560, 14);
            this.m_txtAPPUSERID_CHR2.MaxLength = 7;
            this.m_txtAPPUSERID_CHR2.Name = "m_txtAPPUSERID_CHR2";
            this.m_txtAPPUSERID_CHR2.Size = new System.Drawing.Size(106, 23);
            this.m_txtAPPUSERID_CHR2.TabIndex = 2;
            this.m_txtAPPUSERID_CHR2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.m_txtAPPUSERID_CHR2_KeyUp);
            // 
            // m_dtpStartAPPLY_DAT
            // 
            this.m_dtpStartAPPLY_DAT.Location = new System.Drawing.Point(272, 14);
            this.m_dtpStartAPPLY_DAT.Name = "m_dtpStartAPPLY_DAT";
            this.m_dtpStartAPPLY_DAT.Size = new System.Drawing.Size(120, 23);
            this.m_dtpStartAPPLY_DAT.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(384, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 14);
            this.label8.TabIndex = 15;
            this.label8.Text = "-";
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdClose.DefaultScheme = true;
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdClose.Hint = "";
            this.cmdClose.Location = new System.Drawing.Point(880, 8);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdClose.Size = new System.Drawing.Size(104, 32);
            this.cmdClose.TabIndex = 14;
            this.cmdClose.Text = "关  闭[Esc]";
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdPrint
            // 
            this.cmdPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdPrint.DefaultScheme = true;
            this.cmdPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdPrint.Hint = "";
            this.cmdPrint.Location = new System.Drawing.Point(776, 8);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdPrint.Size = new System.Drawing.Size(104, 32);
            this.cmdPrint.TabIndex = 12;
            this.cmdPrint.Text = "打  印[F6]";
            // 
            // cmdCancellation
            // 
            this.cmdCancellation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdCancellation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdCancellation.DefaultScheme = true;
            this.cmdCancellation.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdCancellation.Hint = "";
            this.cmdCancellation.Location = new System.Drawing.Point(10, 8);
            this.cmdCancellation.Name = "cmdCancellation";
            this.cmdCancellation.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdCancellation.Size = new System.Drawing.Size(158, 32);
            this.cmdCancellation.TabIndex = 11;
            this.cmdCancellation.Text = "作废当前项发票[F4]";
            this.cmdCancellation.Click += new System.EventHandler(this.cmdCancellation_Click);
            // 
            // cmdFind
            // 
            this.cmdFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdFind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdFind.DefaultScheme = true;
            this.cmdFind.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdFind.Hint = "";
            this.cmdFind.Location = new System.Drawing.Point(672, 8);
            this.cmdFind.Name = "cmdFind";
            this.cmdFind.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdFind.Size = new System.Drawing.Size(104, 32);
            this.cmdFind.TabIndex = 10;
            this.cmdFind.Text = "查  询[F5]";
            this.cmdFind.Click += new System.EventHandler(this.cmdFind_Click);
            // 
            // m_dtpEndAPPLY_DAT
            // 
            this.m_dtpEndAPPLY_DAT.Location = new System.Drawing.Point(400, 14);
            this.m_dtpEndAPPLY_DAT.Name = "m_dtpEndAPPLY_DAT";
            this.m_dtpEndAPPLY_DAT.Size = new System.Drawing.Size(120, 23);
            this.m_dtpEndAPPLY_DAT.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(208, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 1;
            this.label6.Text = "请领日期：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(520, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 14);
            this.label7.TabIndex = 1;
            this.label7.Text = "工号：";
            // 
            // m_lstApplyInvoiceMan
            // 
            this.m_lstApplyInvoiceMan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lstApplyInvoiceMan.BackColor = System.Drawing.SystemColors.Window;
            this.m_lstApplyInvoiceMan.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader1});
            this.m_lstApplyInvoiceMan.FullRowSelect = true;
            this.m_lstApplyInvoiceMan.GridLines = true;
            this.m_lstApplyInvoiceMan.HideSelection = false;
            this.m_lstApplyInvoiceMan.Location = new System.Drawing.Point(0, 0);
            this.m_lstApplyInvoiceMan.Name = "m_lstApplyInvoiceMan";
            this.m_lstApplyInvoiceMan.Size = new System.Drawing.Size(988, 440);
            this.m_lstApplyInvoiceMan.TabIndex = 0;
            this.m_lstApplyInvoiceMan.UseCompatibleStateImageBehavior = false;
            this.m_lstApplyInvoiceMan.View = System.Windows.Forms.View.Details;
            this.m_lstApplyInvoiceMan.ItemActivate += new System.EventHandler(this.m_lstApplyInvoiceMan_ItemActivate);
            this.m_lstApplyInvoiceMan.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.m_lstApplyInvoiceMan_ColumnClick);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "请领人 ";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "开始发票号";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "终止发票号";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "发票张数";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "请领日期";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader8.Width = 150;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "作废人";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader9.Width = 100;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "作废日期";
            this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader10.Width = 150;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "发票类型";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader1.Width = 150;
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Controls.Add(this.cboType);
            this.gradientPanel1.Controls.Add(this.label11);
            this.gradientPanel1.Controls.Add(this.label10);
            this.gradientPanel1.Controls.Add(this.m_txtINVOICENUMBET_INT);
            this.gradientPanel1.Controls.Add(this.m_txtINVOICENOTO_VCHR);
            this.gradientPanel1.Controls.Add(this.m_txtINVOICENOFROM_VCHR);
            this.gradientPanel1.Controls.Add(this.label9);
            this.gradientPanel1.Controls.Add(this.cmdConfirm);
            this.gradientPanel1.Controls.Add(this.m_dtpAPPLY_DAT);
            this.gradientPanel1.Controls.Add(this.m_txtAPPUSERID_CHR);
            this.gradientPanel1.Controls.Add(this.label5);
            this.gradientPanel1.Controls.Add(this.label4);
            this.gradientPanel1.Controls.Add(this.label3);
            this.gradientPanel1.Controls.Add(this.label2);
            this.gradientPanel1.Controls.Add(this.label1);
            this.gradientPanel1.Controls.Add(this.m_txtAPPUSERNAME_CHR);
            this.gradientPanel1.Controls.Add(this.cmdEmpty);
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel1.Flip = false;
            this.gradientPanel1.FloatingImage = null;
            this.gradientPanel1.GradientAngle = 90;
            this.gradientPanel1.GradientEndColor = System.Drawing.Color.WhiteSmoke;
            this.gradientPanel1.GradientStartColor = System.Drawing.SystemColors.Control;
            this.gradientPanel1.HorizontalFillPercent = 100F;
            this.gradientPanel1.imageXOffset = 0;
            this.gradientPanel1.imageYOffset = 0;
            this.gradientPanel1.Location = new System.Drawing.Point(2, 2);
            this.gradientPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(985, 104);
            this.gradientPanel1.TabIndex = 2;
            this.gradientPanel1.VerticalFillPercent = 100F;
            // 
            // cboType
            // 
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FormattingEnabled = true;
            this.cboType.Items.AddRange(new object[] {
            "广东省行政事业单位往来结算票据",
            "广东省行政事业性收费统一票据"});
            this.cboType.Location = new System.Drawing.Point(173, 70);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(233, 22);
            this.cboType.TabIndex = 27;
            this.cboType.Visible = false;
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(107, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 14);
            this.label11.TabIndex = 28;
            this.label11.Text = "票据类型：";
            this.label11.Visible = false;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.OrangeRed;
            this.label10.Location = new System.Drawing.Point(645, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(232, 80);
            this.label10.TabIndex = 26;
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtINVOICENUMBET_INT
            // 
            this.m_txtINVOICENUMBET_INT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.m_txtINVOICENUMBET_INT.Location = new System.Drawing.Point(555, 37);
            this.m_txtINVOICENUMBET_INT.Name = "m_txtINVOICENUMBET_INT";
            this.m_txtINVOICENUMBET_INT.ReadOnly = true;
            this.m_txtINVOICENUMBET_INT.Size = new System.Drawing.Size(71, 23);
            this.m_txtINVOICENUMBET_INT.TabIndex = 18;
            this.m_txtINVOICENUMBET_INT.TabStop = false;
            this.m_txtINVOICENUMBET_INT.KeyUp += new System.Windows.Forms.KeyEventHandler(this.m_txtINVOICENUMBET_INT_KeyUp);
            // 
            // m_txtINVOICENOTO_VCHR
            // 
            this.m_txtINVOICENOTO_VCHR.Location = new System.Drawing.Point(364, 37);
            this.m_txtINVOICENOTO_VCHR.MaxLength = 20;
            this.m_txtINVOICENOTO_VCHR.Name = "m_txtINVOICENOTO_VCHR";
            this.m_txtINVOICENOTO_VCHR.Size = new System.Drawing.Size(120, 23);
            this.m_txtINVOICENOTO_VCHR.TabIndex = 20;
            this.m_txtINVOICENOTO_VCHR.Leave += new System.EventHandler(this.m_txtINVOICENOTO_VCHR_Leave);
            this.m_txtINVOICENOTO_VCHR.KeyUp += new System.Windows.Forms.KeyEventHandler(this.m_txtINVOICENOTO_VCHR_KeyUp);
            // 
            // m_txtINVOICENOFROM_VCHR
            // 
            this.m_txtINVOICENOFROM_VCHR.Location = new System.Drawing.Point(173, 37);
            this.m_txtINVOICENOFROM_VCHR.MaxLength = 20;
            this.m_txtINVOICENOFROM_VCHR.Name = "m_txtINVOICENOFROM_VCHR";
            this.m_txtINVOICENOFROM_VCHR.Size = new System.Drawing.Size(100, 23);
            this.m_txtINVOICENOFROM_VCHR.TabIndex = 21;
            this.m_txtINVOICENOFROM_VCHR.Leave += new System.EventHandler(this.m_txtINVOICENOFROM_VCHR_Leave);
            this.m_txtINVOICENOFROM_VCHR.KeyUp += new System.Windows.Forms.KeyEventHandler(this.m_txtINVOICENOFROM_VCHR_KeyUp);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(273, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 14);
            this.label9.TabIndex = 25;
            this.label9.Text = "-";
            // 
            // cmdConfirm
            // 
            this.cmdConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdConfirm.DefaultScheme = true;
            this.cmdConfirm.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdConfirm.Hint = "";
            this.cmdConfirm.Location = new System.Drawing.Point(423, 68);
            this.cmdConfirm.Name = "cmdConfirm";
            this.cmdConfirm.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdConfirm.Size = new System.Drawing.Size(99, 30);
            this.cmdConfirm.TabIndex = 24;
            this.cmdConfirm.Text = "确  定[F2]";
            this.cmdConfirm.Click += new System.EventHandler(this.cmdConfirm_Click);
            // 
            // m_dtpAPPLY_DAT
            // 
            this.m_dtpAPPLY_DAT.Location = new System.Drawing.Point(509, 5);
            this.m_dtpAPPLY_DAT.Name = "m_dtpAPPLY_DAT";
            this.m_dtpAPPLY_DAT.Size = new System.Drawing.Size(120, 23);
            this.m_dtpAPPLY_DAT.TabIndex = 22;
            // 
            // m_txtAPPUSERID_CHR
            // 
            this.m_txtAPPUSERID_CHR.Location = new System.Drawing.Point(173, 5);
            this.m_txtAPPUSERID_CHR.MaxLength = 7;
            this.m_txtAPPUSERID_CHR.Name = "m_txtAPPUSERID_CHR";
            this.m_txtAPPUSERID_CHR.Size = new System.Drawing.Size(100, 23);
            this.m_txtAPPUSERID_CHR.TabIndex = 14;
            this.m_txtAPPUSERID_CHR.Leave += new System.EventHandler(this.m_txtAPPUSERID_CHR_Leave);
            this.m_txtAPPUSERID_CHR.KeyUp += new System.Windows.Forms.KeyEventHandler(this.m_txtAPPUSERID_CHR_KeyUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(284, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 14);
            this.label5.TabIndex = 17;
            this.label5.Text = "终止发票号：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(444, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 16;
            this.label4.Text = "请领日期：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(490, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 15;
            this.label3.Text = "发票张数：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(93, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 14);
            this.label2.TabIndex = 13;
            this.label2.Text = "起始发票号：";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(137, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 12;
            this.label1.Text = "工号：";
            // 
            // m_txtAPPUSERNAME_CHR
            // 
            this.m_txtAPPUSERNAME_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.m_txtAPPUSERNAME_CHR.Location = new System.Drawing.Point(287, 5);
            this.m_txtAPPUSERNAME_CHR.Name = "m_txtAPPUSERNAME_CHR";
            this.m_txtAPPUSERNAME_CHR.ReadOnly = true;
            this.m_txtAPPUSERNAME_CHR.Size = new System.Drawing.Size(100, 23);
            this.m_txtAPPUSERNAME_CHR.TabIndex = 19;
            // 
            // cmdEmpty
            // 
            this.cmdEmpty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdEmpty.DefaultScheme = true;
            this.cmdEmpty.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdEmpty.Hint = "";
            this.cmdEmpty.Location = new System.Drawing.Point(527, 68);
            this.cmdEmpty.Name = "cmdEmpty";
            this.cmdEmpty.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdEmpty.Size = new System.Drawing.Size(99, 30);
            this.cmdEmpty.TabIndex = 23;
            this.cmdEmpty.Text = "清  空[F3]";
            this.cmdEmpty.Click += new System.EventHandler(this.cmdEmpty_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.gradientPanel1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(989, 108);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // frmOPInvoiceAppMan
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(992, 613);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.KeyPreview = true;
            this.Name = "frmOPInvoiceAppMan";
            this.Text = "门诊发票管理";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmOPInvoiceAppMan_KeyDown);
            this.Load += new System.EventHandler(this.frmOPInvoiceAppMan_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		public override void CreateController()
		{
			this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_OPInvoiceAppMan();
			this.objController.Set_GUI_Apperance(this);
		}

		#region 按钮事件
        /// <summary>
        /// 发票类型 0-普通发票(默认) 1-行政票据
        /// </summary>
        internal int intTypeFlag = 0;
        /// <summary>
        /// 以参数方式打开
        /// </summary>
        /// <param name="strParameter">发票类型</param>
        public void ShowWithParm(string strParameter)
        {
            int n = 0;
            int.TryParse(strParameter, out n);
            intTypeFlag = n;
            this.label11.Visible = true;
            this.cboType.Visible = true;
            this.cboType.SelectedIndex = 0;
            this.Show();
        }
		private void frmOPInvoiceAppMan_Load(object sender, System.EventArgs e)
		{
            ((clsCtl_OPInvoiceAppMan)this.objController).intInvType = intTypeFlag;
			((clsCtl_OPInvoiceAppMan)this.objController).m_FillListView();
			m_txtAPPUSERID_CHR.Focus();
		}

		private void cmdConfirm_Click(object sender, System.EventArgs e)
		{
			((clsCtl_OPInvoiceAppMan)this.objController).m_lngDoAddNewT_opr_opinvoiceman();
		}

		private void cmdCancellation_Click(object sender, System.EventArgs e)
		{
			((clsCtl_OPInvoiceAppMan)this.objController).m_lngModifyT_opr_opinvoiceman();
		}

		private void cmdFind_Click(object sender, System.EventArgs e)
		{
			((clsCtl_OPInvoiceAppMan)this.objController).m_lngGetApplyInvoice();
		}

		private void cmdClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private bool IsAsc = true;
		private void m_lstApplyInvoiceMan_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			this.m_lstApplyInvoiceMan.ListViewItemSorter = new ListViewItemComparer(e.Column, IsAsc, this.m_lstApplyInvoiceMan);
			IsAsc = !IsAsc;
			this.m_lstApplyInvoiceMan.Sort();
		}

		private void cmdEmpty_Click(object sender, System.EventArgs e)
		{
			((clsCtl_OPInvoiceAppMan)this.objController).m_EmptyInput();
		}
		private void frmOPInvoiceAppMan_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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
				case Keys.F2://确定				
					this.cmdConfirm_Click(sender,e);
					break;
				case Keys.F3://清空
					this.cmdEmpty_Click(sender,e);
					break;
				case Keys.F4://作废当前项发票[D]
					this.cmdCancellation_Click(sender,e);
					break;
				case Keys.F5://查  询[F]
					this.cmdFind_Click(sender,e);
					break;
				case Keys.F6://打  印[P]

					break;
			}
		}
		#endregion 

		#region 焦点和按键事件
		private void m_txtAPPUSERID_CHR_Leave(object sender, System.EventArgs e)
		{
			((clsCtl_OPInvoiceAppMan)this.objController).m_GetEmployeeName();
		}

		private void m_txtINVOICENOFROM_VCHR_Leave(object sender, System.EventArgs e)
		{
			((clsCtl_OPInvoiceAppMan)this.objController).m_GetInvoiceNumber(m_txtINVOICENOFROM_VCHR.Text.Trim(),m_txtINVOICENOTO_VCHR.Text.Trim());
		}

		private void m_txtINVOICENOTO_VCHR_Leave(object sender, System.EventArgs e)
		{
			((clsCtl_OPInvoiceAppMan)this.objController).m_GetInvoiceNumber(m_txtINVOICENOFROM_VCHR.Text.Trim(),m_txtINVOICENOTO_VCHR.Text.Trim());
			cmdConfirm.Focus();
		}
		private void m_lstApplyInvoiceMan_ItemActivate(object sender, System.EventArgs e)
		{
			//作废操作
			((clsCtl_OPInvoiceAppMan)this.objController).m_lngModifyT_opr_opinvoiceman();
		}

		private void m_txtAPPUSERID_CHR_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				m_txtINVOICENOFROM_VCHR.Focus();
		}

		private void m_txtINVOICENOFROM_VCHR_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				m_txtINVOICENOTO_VCHR.Focus();
		}

		private void m_txtINVOICENOTO_VCHR_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				((clsCtl_OPInvoiceAppMan)this.objController).m_GetInvoiceNumber(m_txtINVOICENOFROM_VCHR.Text.Trim(),m_txtINVOICENOTO_VCHR.Text.Trim());
				m_txtINVOICENUMBET_INT.Focus();
			}
		}

		private void m_txtAPPUSERID_CHR2_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				((clsCtl_OPInvoiceAppMan)this.objController).m_lngGetApplyInvoice();
			}
		}

		private void m_txtINVOICENUMBET_INT_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				((clsCtl_OPInvoiceAppMan)this.objController).m_lngDoAddNewT_opr_opinvoiceman();	
				m_txtAPPUSERID_CHR.Focus();
			}
		}
		#endregion 				

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((clsCtl_OPInvoiceAppMan)this.objController).intInvType = this.cboType.SelectedIndex + 1;
        }
	}
}
