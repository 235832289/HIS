using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using com.digitalwave.GUI_Base;	//GUI_Base.dll
using com.digitalwave.iCare.middletier.HIS;	//his_svc.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.common;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmCheckOutOfDay 的摘要说明。
	/// </summary>
	public class frmCheckOutOfDay : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		internal System.Drawing.Printing.PrintDocument printDocument1;
		private System.Windows.Forms.GroupBox groupBox1;
		internal PinkieControls.ButtonXP btnPrint;
		private PinkieControls.ButtonXP btnEsc;
		internal System.Windows.Forms.DateTimePicker DateCheckOut;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		internal System.Windows.Forms.DateTimePicker EndDate;
		internal System.Windows.Forms.DateTimePicker starDate;
		internal com.digitalwave.controls.datagrid.ctlDataGrid ctlDgFind;
		internal PinkieControls.ButtonXP btnCheck;
		internal PinkieControls.ButtonXP btnReset;
		internal PinkieControls.ButtonXP buttonXP1;
		private System.Windows.Forms.Label label5;
		internal com.digitalwave.iCare.gui.HIS.exComboBox m_cboCheckMan;
		internal PinkieControls.ButtonXP buttonXP2;
		internal System.Drawing.Printing.PrintDocument printDocument2;
		private System.Drawing.Printing.PrintDocument printDocument3;
		internal PinkieControls.ButtonXP buttonXP3;
		private System.Drawing.Printing.PrintDocument printDocument4;
		internal PinkieControls.ButtonXP buttonXP4;
		private System.Windows.Forms.Panel panel2;
		internal com.digitalwave.controls.Control.ctlprintShow ctlprintShow2;

        /// <summary>
        /// 医院编号
        /// </summary>
        internal string Hospital_No = "";
        private PageSetupDialog pageSetupDialog1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCheckOutOfDay()
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

		/// <summary>
		/// 设置窗体对象
		/// </summary>
		public override void CreateController()
		{
			this.objController =new clsControlCheckOutOfDay();
			this.objController.Set_GUI_Apperance(this);
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo1 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCheckOutOfDay));
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReset = new PinkieControls.ButtonXP();
            this.buttonXP1 = new PinkieControls.ButtonXP();
            this.m_cboCheckMan = new com.digitalwave.iCare.gui.HIS.exComboBox();
            this.buttonXP4 = new PinkieControls.ButtonXP();
            this.buttonXP3 = new PinkieControls.ButtonXP();
            this.buttonXP2 = new PinkieControls.ButtonXP();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEsc = new PinkieControls.ButtonXP();
            this.btnPrint = new PinkieControls.ButtonXP();
            this.btnCheck = new PinkieControls.ButtonXP();
            this.DateCheckOut = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ctlprintShow2 = new com.digitalwave.controls.Control.ctlprintShow();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.EndDate = new System.Windows.Forms.DateTimePicker();
            this.starDate = new System.Windows.Forms.DateTimePicker();
            this.ctlDgFind = new com.digitalwave.controls.datagrid.ctlDataGrid();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.printDocument2 = new System.Drawing.Printing.PrintDocument();
            this.printDocument3 = new System.Drawing.Printing.PrintDocument();
            this.printDocument4 = new System.Drawing.Printing.PrintDocument();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDgFind)).BeginInit();
            this.SuspendLayout();
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.buttonXP1);
            this.groupBox1.Controls.Add(this.m_cboCheckMan);
            this.groupBox1.Controls.Add(this.buttonXP4);
            this.groupBox1.Controls.Add(this.buttonXP3);
            this.groupBox1.Controls.Add(this.buttonXP2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnEsc);
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.btnCheck);
            this.groupBox1.Controls.Add(this.DateCheckOut);
            this.groupBox1.Location = new System.Drawing.Point(0, -5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1000, 53);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnReset.DefaultScheme = true;
            this.btnReset.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnReset.Hint = "";
            this.btnReset.Location = new System.Drawing.Point(4, 12);
            this.btnReset.Name = "btnReset";
            this.btnReset.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnReset.Size = new System.Drawing.Size(180, 32);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "获取未结帐数据(&S)  ";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // buttonXP1
            // 
            this.buttonXP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP1.DefaultScheme = true;
            this.buttonXP1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP1.Hint = "";
            this.buttonXP1.Location = new System.Drawing.Point(92, 13);
            this.buttonXP1.Name = "buttonXP1";
            this.buttonXP1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP1.Size = new System.Drawing.Size(92, 32);
            this.buttonXP1.TabIndex = 52;
            this.buttonXP1.Text = "查看(&L)";
            this.buttonXP1.Visible = false;
            this.buttonXP1.Click += new System.EventHandler(this.buttonXP1_Click);
            // 
            // m_cboCheckMan
            // 
            this.m_cboCheckMan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboCheckMan.Location = new System.Drawing.Point(60, 17);
            this.m_cboCheckMan.Name = "m_cboCheckMan";
            this.m_cboCheckMan.Size = new System.Drawing.Size(84, 22);
            this.m_cboCheckMan.TabIndex = 50;
            this.m_cboCheckMan.Visible = false;
            // 
            // buttonXP4
            // 
            this.buttonXP4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP4.DefaultScheme = true;
            this.buttonXP4.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP4.Enabled = false;
            this.buttonXP4.Hint = "";
            this.buttonXP4.Location = new System.Drawing.Point(597, 13);
            this.buttonXP4.Name = "buttonXP4";
            this.buttonXP4.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP4.Size = new System.Drawing.Size(131, 32);
            this.buttonXP4.TabIndex = 55;
            this.buttonXP4.Text = "合并分类(&U) ";
            this.buttonXP4.Click += new System.EventHandler(this.buttonXP4_Click);
            // 
            // buttonXP3
            // 
            this.buttonXP3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP3.DefaultScheme = true;
            this.buttonXP3.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP3.Enabled = false;
            this.buttonXP3.Hint = "";
            this.buttonXP3.Location = new System.Drawing.Point(325, 13);
            this.buttonXP3.Name = "buttonXP3";
            this.buttonXP3.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP3.Size = new System.Drawing.Size(131, 32);
            this.buttonXP3.TabIndex = 54;
            this.buttonXP3.Text = "分类发票(&D) ";
            this.buttonXP3.Click += new System.EventHandler(this.buttonXP3_Click);
            // 
            // buttonXP2
            // 
            this.buttonXP2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP2.DefaultScheme = true;
            this.buttonXP2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP2.Enabled = false;
            this.buttonXP2.Hint = "";
            this.buttonXP2.Location = new System.Drawing.Point(461, 13);
            this.buttonXP2.Name = "buttonXP2";
            this.buttonXP2.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP2.Size = new System.Drawing.Size(131, 32);
            this.buttonXP2.TabIndex = 53;
            this.buttonXP2.Text = "分类收费(&F) ";
            this.buttonXP2.Click += new System.EventHandler(this.buttonXP2_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(4, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 23);
            this.label5.TabIndex = 51;
            this.label5.Text = "收费员：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(80, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "载止日期：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // btnEsc
            // 
            this.btnEsc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnEsc.DefaultScheme = true;
            this.btnEsc.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnEsc.Hint = "";
            this.btnEsc.Location = new System.Drawing.Point(867, 13);
            this.btnEsc.Name = "btnEsc";
            this.btnEsc.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnEsc.Size = new System.Drawing.Size(131, 32);
            this.btnEsc.TabIndex = 3;
            this.btnEsc.Text = "退出(&E)";
            this.btnEsc.Click += new System.EventHandler(this.btnEsc_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnPrint.DefaultScheme = true;
            this.btnPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPrint.Enabled = false;
            this.btnPrint.Hint = "";
            this.btnPrint.Location = new System.Drawing.Point(733, 13);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnPrint.Size = new System.Drawing.Size(131, 32);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnCheck.DefaultScheme = true;
            this.btnCheck.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCheck.Hint = "";
            this.btnCheck.Location = new System.Drawing.Point(189, 13);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnCheck.Size = new System.Drawing.Size(131, 32);
            this.btnCheck.TabIndex = 1;
            this.btnCheck.Text = "结帐(&A)";
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // DateCheckOut
            // 
            this.DateCheckOut.Enabled = false;
            this.DateCheckOut.Location = new System.Drawing.Point(36, 17);
            this.DateCheckOut.Name = "DateCheckOut";
            this.DateCheckOut.Size = new System.Drawing.Size(120, 23);
            this.DateCheckOut.TabIndex = 0;
            this.DateCheckOut.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(204, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(796, 368);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ctlprintShow2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(792, 364);
            this.panel2.TabIndex = 4;
            // 
            // ctlprintShow2
            // 
            this.ctlprintShow2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlprintShow2.Location = new System.Drawing.Point(0, 0);
            this.ctlprintShow2.Name = "ctlprintShow2";
            this.ctlprintShow2.Size = new System.Drawing.Size(792, 364);
            this.ctlprintShow2.TabIndex = 0;
            this.ctlprintShow2.Zoom = 1;
            this.ctlprintShow2.Load += new System.EventHandler(this.ctlprintShow2_Load);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.EndDate);
            this.groupBox2.Controls.Add(this.starDate);
            this.groupBox2.Controls.Add(this.ctlDgFind);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox2.Location = new System.Drawing.Point(0, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(201, 376);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "已结帐历史记录";
            // 
            // EndDate
            // 
            this.EndDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EndDate.Location = new System.Drawing.Point(76, 48);
            this.EndDate.Name = "EndDate";
            this.EndDate.Size = new System.Drawing.Size(120, 23);
            this.EndDate.TabIndex = 2;
            this.EndDate.ValueChanged += new System.EventHandler(this.EndDate_ValueChanged);
            // 
            // starDate
            // 
            this.starDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.starDate.Location = new System.Drawing.Point(76, 19);
            this.starDate.Name = "starDate";
            this.starDate.Size = new System.Drawing.Size(120, 23);
            this.starDate.TabIndex = 1;
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
            clsColumnInfo1.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            clsColumnInfo1.BackColor = System.Drawing.Color.White;
            clsColumnInfo1.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo1.ColumnIndex = 0;
            clsColumnInfo1.ColumnName = "BALANCE_DAT";
            clsColumnInfo1.ColumnWidth = 180;
            clsColumnInfo1.Enabled = false;
            clsColumnInfo1.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo1.HeadText = "结帐时间";
            clsColumnInfo1.ReadOnly = true;
            clsColumnInfo1.TextFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ctlDgFind.Columns.Add(clsColumnInfo1);
            this.ctlDgFind.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ctlDgFind.FullRowSelect = true;
            this.ctlDgFind.Location = new System.Drawing.Point(3, 80);
            this.ctlDgFind.MultiSelect = false;
            this.ctlDgFind.Name = "ctlDgFind";
            this.ctlDgFind.ReadOnly = false;
            this.ctlDgFind.RowHeadersVisible = true;
            this.ctlDgFind.RowHeaderWidth = 15;
            this.ctlDgFind.SelectedRowBackColor = System.Drawing.Color.Purple;
            this.ctlDgFind.SelectedRowForeColor = System.Drawing.Color.White;
            this.ctlDgFind.Size = new System.Drawing.Size(195, 288);
            this.ctlDgFind.TabIndex = 0;
            this.ctlDgFind.m_evtCurrentCellChanged += new System.EventHandler(this.ctlDgFind_m_evtCurrentCellChanged);
            this.ctlDgFind.m_evtDataGridKeyDown += new System.Windows.Forms.KeyEventHandler(this.ctlDgFind_m_evtDataGridKeyDown);
            this.ctlDgFind.m_evtClickCell += new com.digitalwave.controls.datagrid.clsDGTextMouseClickEventHandler(this.ctlDgFind_m_evtClickCell);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "结束时间：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "开始时间：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // printDocument2
            // 
            this.printDocument2.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument2_PrintPage);
            this.printDocument2.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument2_EndPrint);
            this.printDocument2.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument2_BeginPrint);
            // 
            // printDocument3
            // 
            this.printDocument3.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument3_PrintPage);
            this.printDocument3.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument3_BeginPrint);
            // 
            // printDocument4
            // 
            this.printDocument4.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument4_PrintPage);
            this.printDocument4.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument4_BeginPrint);
            // 
            // frmCheckOutOfDay
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(1000, 429);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCheckOutOfDay";
            this.Text = "收款员日结报表窗口";
            this.Load += new System.EventHandler(this.frmCheckOutOfDay_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ctlDgFind)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmCheckOutOfDay_Load(object sender, System.EventArgs e)
		{
            this.Cursor = Cursors.WaitCursor;
			starDate.Value=Convert.ToDateTime(starDate.Value.Year.ToString()+"-"+starDate.Value.Month.ToString()+"-"+"01");
			if(isDoctorDean==true)
			{
				DataTable dtBalanceemp=new DataTable();
				clsDomainControl_Register domain=new clsDomainControl_Register();
				domain.m_lngReturnAllBALANCEEMP(out dtBalanceemp);
				if(dtBalanceemp.Rows.Count>0)
				{
					for(int i1=0;i1<dtBalanceemp.Rows.Count;i1++)
					{
						m_cboCheckMan.Item.Add(dtBalanceemp.Rows[i1]["LASTNAME_VCHR"].ToString(),dtBalanceemp.Rows[i1]["BALANCEEMP_CHR"].ToString());
					}
				}
			}
            Hospital_No = this.objController.m_objComInfo.m_mthGetHospitalNo();

            this.ctlprintShow2.IsShowClose = false;
			ctlprintShow2.setDocument=printDocument1;
            this.Cursor = Cursors.Default;
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
				label1.Visible=false;
				DateCheckOut.Visible=false;
				btnReset.Enabled =false;
				btnCheck.Enabled=false;
				label5.Visible=true;
				m_cboCheckMan.Visible=true;
				btnPrint.Enabled=true;
				buttonXP3.Enabled=true;
				buttonXP2.Enabled=true;
				isDoctorDean=true;
				buttonXP1.Visible=true;

			}
			else
			{
				isDoctorDean=false;
			}
			this.Show();
		}

		private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{            
		    ((clsControlCheckOutOfDay)this.objController).printPageFS(e);			
		}

		private void btnEsc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
            //frmSelectPrinter selectPrinter=new frmSelectPrinter();
            //if(selectPrinter.ShowDialog()==DialogResult.OK)
            //{
            //    printDocument1.PrinterSettings.PrinterName=selectPrinter.PrinterName;
            //    printDocument3.PrinterSettings.PrinterName=selectPrinter.PrinterName;
            //    printDocument2.PrinterSettings.PrinterName=selectPrinter.PrinterName;
            //}
            //else
            //{
            //    return;
            //}
            if ((string)ctlprintShow2.Tag == "printDocument1")
                this.pageSetupDialog1.Document = this.printDocument1;
            if ((string)ctlprintShow2.Tag == "printDocument2")
                this.pageSetupDialog1.Document = this.printDocument2;
            if ((string)ctlprintShow2.Tag == "printDocument3")
                this.pageSetupDialog1.Document = this.printDocument3;
            if ((string)ctlprintShow2.Tag == "printDocument4")
                this.pageSetupDialog1.Document = this.printDocument4;
            if (this.pageSetupDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.PrinterSettings.PrinterName =this.pageSetupDialog1.PrinterSettings.PrinterName;
                printDocument3.PrinterSettings.PrinterName = this.pageSetupDialog1.PrinterSettings.PrinterName;
                printDocument2.PrinterSettings.PrinterName = this.pageSetupDialog1.PrinterSettings.PrinterName;
                printDocument4.PrinterSettings.PrinterName = this.pageSetupDialog1.PrinterSettings.PrinterName;
            }
            else
            {
                return;
            }

            try
            {
				
				if((string)ctlprintShow2.Tag=="printDocument1")
					printDocument1.Print();
				if((string)ctlprintShow2.Tag=="printDocument2")
					printDocument2.Print();
				if((string)ctlprintShow2.Tag=="printDocument3")
					printDocument3.Print();
				if((string)ctlprintShow2.Tag=="printDocument4")
					printDocument4.Print();
            }
            catch
            {
                MessageBox.Show("因为打印机没有设置打印所需的纸张，导致打印失败！", "icare", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
		}

		private void btnCheck_Click(object sender, System.EventArgs e)
		{
			if(MessageBox.Show("注意：结帐后不能修改数据，是否要结帐？","Icare",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
			{
				((clsControlCheckOutOfDay)this.objController).CheckData();
			}
			
		}

		private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
		     ((clsControlCheckOutOfDay)this.objController).getData();
		}

		private void starDate_ValueChanged(object sender, System.EventArgs e)
		{
			((clsControlCheckOutOfDay)this.objController).findhistory();
		}

		private void EndDate_ValueChanged(object sender, System.EventArgs e)
		{
		    ((clsControlCheckOutOfDay)this.objController).findhistory();
		}

		private void ctlDgFind_m_evtCurrentCellChanged(object sender, System.EventArgs e)
		{
			 ((clsControlCheckOutOfDay)this.objController).dgSelect();
		}

		private void btnReset_Click(object sender, System.EventArgs e)
		{
			((clsControlCheckOutOfDay)this.objController).Reset();
			ctlprintShow2.Tag="printDocument1";
		}

		private void ctlDgFind_m_evtDataGridKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			
		}

		private void ctlDgFind_m_evtClickCell(object sender, com.digitalwave.controls.datagrid.clsDGTextMouseClickEventArgs e)
		{
            if (ctlDgFind.CurrentCell.RowNumber == e.m_intRowNumber)
            {
                ((clsControlCheckOutOfDay)this.objController).dgSelect();
            }
            //if(ctlDgFind.RowCount==1)
            // ((clsControlCheckOutOfDay)this.objController).dgSelect();
			ctlprintShow2.Tag="printDocument1";
		}

		private void buttonXP1_Click(object sender, System.EventArgs e)
		{
			((clsControlCheckOutOfDay)this.objController).findhistory();
		}

		private void printDocument2_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			((clsControlCheckOutOfDay)this.objController).m_mthGetData();
		}

		private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			((clsControlCheckOutOfDay)this.objController).printPageCheckMB(e);
		}

		private void buttonXP2_Click(object sender, System.EventArgs e)
		{
			ctlprintShow2.setDocument=printDocument2;
			ctlprintShow2.Tag="printDocument2";
		}

		private void printDocument3_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			#region 设置打印
			this.printDocument3.DefaultPageSettings.Landscape=false;
			foreach(System.Drawing.Printing.PaperSize  ps in this.printDocument3.PrinterSettings.PaperSizes)
			{
				if(ps.PaperName=="A4")
				{
					this.printDocument3.DefaultPageSettings.PaperSize=ps;
					break;
				}
			}
			#endregion
		}

		private void printDocument3_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			((clsControlCheckOutOfDay)this.objController).printPageCheckNoMB(e);
		}

		private void buttonXP3_Click(object sender, System.EventArgs e)
		{
			ctlprintShow2.setDocument=printDocument3;
			ctlprintShow2.Tag="printDocument3";
		}

		private void printDocument4_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			((clsControlCheckOutOfDay)this.objController).m_mthGetData();
		}

		private void printDocument4_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			((clsControlCheckOutOfDay)this.objController).printPageCheckUnit(e);
		}

		private void buttonXP4_Click(object sender, System.EventArgs e)
		{
			ctlprintShow2.setDocument=printDocument4;
			ctlprintShow2.Tag="printDocument4";
		}

		private void ctlprintShow2_Load(object sender, System.EventArgs e)
		{
		
		}

        private void printDocument2_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((clsControlCheckOutOfDay)this.objController).m_mthEndPrint();
        }
	}
}
