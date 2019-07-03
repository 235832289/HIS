namespace com.digitalwave.iCare.gui.HIS.Reports
{
    partial class frmCheckOutOfDay_BM
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo2 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReset = new PinkieControls.ButtonXP();
            this.btnEsc = new PinkieControls.ButtonXP();
            this.btnPrint = new PinkieControls.ButtonXP();
            this.btnCheck = new PinkieControls.ButtonXP();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.EndDate = new System.Windows.Forms.DateTimePicker();
            this.starDate = new System.Windows.Forms.DateTimePicker();
            this.ctlDgFind = new com.digitalwave.controls.datagrid.ctlDataGrid();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_dwShow = new Sybase.DataWindow.DataWindowControl();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.m_cboStatDateType = new System.Windows.Forms.ComboBox();
            this.m_btnPreview = new PinkieControls.ButtonXP();
            this.m_datEndTime = new System.Windows.Forms.DateTimePicker();
            this.labTo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_btnExport = new PinkieControls.ButtonXP();
            this.m_btnStat = new PinkieControls.ButtonXP();
            this.m_cboCheckMan = new com.digitalwave.iCare.gui.HIS.exComboBox();
            this.m_datBeginTime = new System.Windows.Forms.DateTimePicker();
            this.m_btnPrint = new PinkieControls.ButtonXP();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDgFind)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnEsc);
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.btnCheck);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1028, 62);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnReset.DefaultScheme = true;
            this.btnReset.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnReset.Hint = "";
            this.btnReset.Location = new System.Drawing.Point(423, 15);
            this.btnReset.Name = "btnReset";
            this.btnReset.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnReset.Size = new System.Drawing.Size(180, 32);
            this.btnReset.TabIndex = 9;
            this.btnReset.Text = "获取未结帐数据(&S)  ";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnEsc
            // 
            this.btnEsc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnEsc.DefaultScheme = true;
            this.btnEsc.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnEsc.Hint = "";
            this.btnEsc.Location = new System.Drawing.Point(881, 15);
            this.btnEsc.Name = "btnEsc";
            this.btnEsc.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnEsc.Size = new System.Drawing.Size(131, 32);
            this.btnEsc.TabIndex = 8;
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
            this.btnPrint.Location = new System.Drawing.Point(745, 15);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnPrint.Size = new System.Drawing.Size(131, 32);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnCheck.DefaultScheme = true;
            this.btnCheck.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCheck.Hint = "";
            this.btnCheck.Location = new System.Drawing.Point(608, 15);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnCheck.Size = new System.Drawing.Size(131, 32);
            this.btnCheck.TabIndex = 6;
            this.btnCheck.Text = "结帐(&A)";
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.EndDate);
            this.groupBox2.Controls.Add(this.starDate);
            this.groupBox2.Controls.Add(this.ctlDgFind);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(0, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(220, 528);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "已结账历史记录";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(9, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "结束时间：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(9, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "开始时间：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EndDate
            // 
            this.EndDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EndDate.Location = new System.Drawing.Point(89, 55);
            this.EndDate.Name = "EndDate";
            this.EndDate.Size = new System.Drawing.Size(120, 23);
            this.EndDate.TabIndex = 7;
            this.EndDate.ValueChanged += new System.EventHandler(this.EndDate_ValueChanged);
            // 
            // starDate
            // 
            this.starDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.starDate.Location = new System.Drawing.Point(89, 23);
            this.starDate.Name = "starDate";
            this.starDate.Size = new System.Drawing.Size(120, 23);
            this.starDate.TabIndex = 6;
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
            clsColumnInfo2.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo2.BackColor = System.Drawing.Color.White;
            clsColumnInfo2.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo2.ColumnIndex = 0;
            clsColumnInfo2.ColumnName = "BALANCE_DAT";
            clsColumnInfo2.ColumnWidth = 150;
            clsColumnInfo2.Enabled = false;
            clsColumnInfo2.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo2.HeadText = "结帐时间";
            clsColumnInfo2.ReadOnly = true;
            clsColumnInfo2.TextFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ctlDgFind.Columns.Add(clsColumnInfo2);
            this.ctlDgFind.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ctlDgFind.FullRowSelect = true;
            this.ctlDgFind.Location = new System.Drawing.Point(4, 87);
            this.ctlDgFind.MultiSelect = false;
            this.ctlDgFind.Name = "ctlDgFind";
            this.ctlDgFind.ReadOnly = false;
            this.ctlDgFind.RowHeadersVisible = true;
            this.ctlDgFind.RowHeaderWidth = 35;
            this.ctlDgFind.SelectedRowBackColor = System.Drawing.Color.Purple;
            this.ctlDgFind.SelectedRowForeColor = System.Drawing.Color.White;
            this.ctlDgFind.Size = new System.Drawing.Size(210, 435);
            this.ctlDgFind.TabIndex = 5;
            this.ctlDgFind.m_evtCurrentCellChanged += new System.EventHandler(this.ctlDgFind_m_evtCurrentCellChanged);
            this.ctlDgFind.m_evtClickCell += new com.digitalwave.controls.datagrid.clsDGTextMouseClickEventHandler(this.ctlDgFind_m_evtClickCell);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.m_dwShow);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(220, 118);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(808, 528);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // m_dwShow
            // 
            this.m_dwShow.DataWindowObject = "d_invoice_checkout_bm";
            this.m_dwShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dwShow.LibraryList = "D:\\dev\\icare_ver2\\Code\\bin\\Debug\\PB_OP.pbl";
            this.m_dwShow.Location = new System.Drawing.Point(3, 19);
            this.m_dwShow.Name = "m_dwShow";
            this.m_dwShow.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.m_dwShow.Size = new System.Drawing.Size(802, 506);
            this.m_dwShow.TabIndex = 0;
            this.m_dwShow.Text = "dataWindowControl1";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.m_cboStatDateType);
            this.groupBox4.Controls.Add(this.m_btnPreview);
            this.groupBox4.Controls.Add(this.m_datEndTime);
            this.groupBox4.Controls.Add(this.labTo);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.m_btnExport);
            this.groupBox4.Controls.Add(this.m_btnStat);
            this.groupBox4.Controls.Add(this.m_cboCheckMan);
            this.groupBox4.Controls.Add(this.m_datBeginTime);
            this.groupBox4.Controls.Add(this.m_btnPrint);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(0, 62);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1028, 56);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            // 
            // m_cboStatDateType
            // 
            this.m_cboStatDateType.BackColor = System.Drawing.SystemColors.Info;
            this.m_cboStatDateType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cboStatDateType.FormattingEnabled = true;
            this.m_cboStatDateType.Items.AddRange(new object[] {
            "按发票时间",
            "按结算时间"});
            this.m_cboStatDateType.Location = new System.Drawing.Point(11, 19);
            this.m_cboStatDateType.Name = "m_cboStatDateType";
            this.m_cboStatDateType.Size = new System.Drawing.Size(92, 22);
            this.m_cboStatDateType.TabIndex = 50;
            // 
            // m_btnPreview
            // 
            this.m_btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnPreview.DefaultScheme = true;
            this.m_btnPreview.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnPreview.Hint = "";
            this.m_btnPreview.Location = new System.Drawing.Point(763, 16);
            this.m_btnPreview.Name = "m_btnPreview";
            this.m_btnPreview.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnPreview.Size = new System.Drawing.Size(87, 31);
            this.m_btnPreview.TabIndex = 49;
            this.m_btnPreview.Text = "预览(&Pre)";
            // 
            // m_datEndTime
            // 
            this.m_datEndTime.CustomFormat = "yyyy年MM月dd日";
            this.m_datEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_datEndTime.Location = new System.Drawing.Point(273, 20);
            this.m_datEndTime.Name = "m_datEndTime";
            this.m_datEndTime.Size = new System.Drawing.Size(125, 23);
            this.m_datEndTime.TabIndex = 47;
            // 
            // labTo
            // 
            this.labTo.Location = new System.Drawing.Point(252, 25);
            this.labTo.Name = "labTo";
            this.labTo.Size = new System.Drawing.Size(28, 22);
            this.labTo.TabIndex = 46;
            this.labTo.Text = "到";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 14);
            this.label1.TabIndex = 45;
            this.label1.Text = "从";
            // 
            // m_btnExport
            // 
            this.m_btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnExport.DefaultScheme = true;
            this.m_btnExport.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnExport.Hint = "";
            this.m_btnExport.Location = new System.Drawing.Point(852, 16);
            this.m_btnExport.Name = "m_btnExport";
            this.m_btnExport.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnExport.Size = new System.Drawing.Size(87, 31);
            this.m_btnExport.TabIndex = 42;
            this.m_btnExport.Text = "导出(&Exp)";
            // 
            // m_btnStat
            // 
            this.m_btnStat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnStat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnStat.DefaultScheme = true;
            this.m_btnStat.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnStat.Hint = "";
            this.m_btnStat.Location = new System.Drawing.Point(585, 16);
            this.m_btnStat.Name = "m_btnStat";
            this.m_btnStat.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnStat.Size = new System.Drawing.Size(87, 31);
            this.m_btnStat.TabIndex = 41;
            this.m_btnStat.Text = "统计(&S)";
            this.m_btnStat.Click += new System.EventHandler(this.m_btnStat_Click);
            // 
            // m_cboCheckMan
            // 
            this.m_cboCheckMan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboCheckMan.Location = new System.Drawing.Point(451, 20);
            this.m_cboCheckMan.Name = "m_cboCheckMan";
            this.m_cboCheckMan.Size = new System.Drawing.Size(125, 22);
            this.m_cboCheckMan.TabIndex = 44;
            // 
            // m_datBeginTime
            // 
            this.m_datBeginTime.CustomFormat = "yyyy年MM月dd日";
            this.m_datBeginTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_datBeginTime.Location = new System.Drawing.Point(124, 20);
            this.m_datBeginTime.Name = "m_datBeginTime";
            this.m_datBeginTime.Size = new System.Drawing.Size(125, 23);
            this.m_datBeginTime.TabIndex = 40;
            // 
            // m_btnPrint
            // 
            this.m_btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnPrint.DefaultScheme = true;
            this.m_btnPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnPrint.Hint = "";
            this.m_btnPrint.Location = new System.Drawing.Point(674, 16);
            this.m_btnPrint.Name = "m_btnPrint";
            this.m_btnPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnPrint.Size = new System.Drawing.Size(87, 31);
            this.m_btnPrint.TabIndex = 43;
            this.m_btnPrint.Text = "打印(&P)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(398, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 48;
            this.label4.Text = "收费员：";
            // 
            // frmCheckOutOfDay_BM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 646);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmCheckOutOfDay_BM";
            this.Text = "便民药房收费员日结报表";
            this.Load += new System.EventHandler(this.frmCheckOutOfDayNew_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ctlDgFind)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.DateTimePicker EndDate;
        internal System.Windows.Forms.DateTimePicker starDate;
        internal com.digitalwave.controls.datagrid.ctlDataGrid ctlDgFind;
        internal PinkieControls.ButtonXP btnReset;
        private PinkieControls.ButtonXP btnEsc;
        internal PinkieControls.ButtonXP btnPrint;
        internal PinkieControls.ButtonXP btnCheck;
        internal Sybase.DataWindow.DataWindowControl m_dwShow;
        private System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.ComboBox m_cboStatDateType;
        private PinkieControls.ButtonXP m_btnPreview;
        internal System.Windows.Forms.DateTimePicker m_datEndTime;
        internal System.Windows.Forms.Label labTo;
        private System.Windows.Forms.Label label1;
        private PinkieControls.ButtonXP m_btnExport;
        private PinkieControls.ButtonXP m_btnStat;
        internal exComboBox m_cboCheckMan;
        internal System.Windows.Forms.DateTimePicker m_datBeginTime;
        private PinkieControls.ButtonXP m_btnPrint;
        internal System.Windows.Forms.Label label4;
    }
}