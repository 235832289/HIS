namespace com.digitalwave.iCare.gui.HIS.Reports
{
    partial class frmCheckOutOfDayGY
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
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo3 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReset = new PinkieControls.ButtonXP();
            this.buttonXP4 = new PinkieControls.ButtonXP();
            this.buttonXP3 = new PinkieControls.ButtonXP();
            this.buttonXP2 = new PinkieControls.ButtonXP();
            this.btnEsc = new PinkieControls.ButtonXP();
            this.btnPrint = new PinkieControls.ButtonXP();
            this.btnCheck = new PinkieControls.ButtonXP();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.EndDate = new System.Windows.Forms.DateTimePicker();
            this.starDate = new System.Windows.Forms.DateTimePicker();
            this.ctlDgFind = new com.digitalwave.controls.datagrid.ctlDataGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_dwShow = new Sybase.DataWindow.DataWindowControl();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDgFind)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.buttonXP4);
            this.groupBox1.Controls.Add(this.buttonXP3);
            this.groupBox1.Controls.Add(this.buttonXP2);
            this.groupBox1.Controls.Add(this.btnEsc);
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.btnCheck);
            this.groupBox1.Location = new System.Drawing.Point(0, -5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1000, 53);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnReset.DefaultScheme = true;
            this.btnReset.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnReset.Hint = "";
            this.btnReset.Location = new System.Drawing.Point(13, 13);
            this.btnReset.Name = "btnReset";
            this.btnReset.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnReset.Size = new System.Drawing.Size(180, 32);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "获取未结帐数据(&S)  ";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // buttonXP4
            // 
            this.buttonXP4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP4.DefaultScheme = true;
            this.buttonXP4.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP4.Enabled = false;
            this.buttonXP4.Hint = "";
            this.buttonXP4.Location = new System.Drawing.Point(606, 13);
            this.buttonXP4.Name = "buttonXP4";
            this.buttonXP4.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP4.Size = new System.Drawing.Size(131, 32);
            this.buttonXP4.TabIndex = 55;
            this.buttonXP4.Text = "合并分类(&U) ";
            // 
            // buttonXP3
            // 
            this.buttonXP3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP3.DefaultScheme = true;
            this.buttonXP3.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP3.Enabled = false;
            this.buttonXP3.Hint = "";
            this.buttonXP3.Location = new System.Drawing.Point(334, 13);
            this.buttonXP3.Name = "buttonXP3";
            this.buttonXP3.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP3.Size = new System.Drawing.Size(131, 32);
            this.buttonXP3.TabIndex = 54;
            this.buttonXP3.Text = "分类发票(&D) ";
            // 
            // buttonXP2
            // 
            this.buttonXP2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP2.DefaultScheme = true;
            this.buttonXP2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP2.Enabled = false;
            this.buttonXP2.Hint = "";
            this.buttonXP2.Location = new System.Drawing.Point(470, 13);
            this.buttonXP2.Name = "buttonXP2";
            this.buttonXP2.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP2.Size = new System.Drawing.Size(131, 32);
            this.buttonXP2.TabIndex = 53;
            this.buttonXP2.Text = "分类收费(&F) ";
            // 
            // btnEsc
            // 
            this.btnEsc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnEsc.DefaultScheme = true;
            this.btnEsc.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnEsc.Hint = "";
            this.btnEsc.Location = new System.Drawing.Point(878, 13);
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
            this.btnPrint.Location = new System.Drawing.Point(742, 13);
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
            this.btnCheck.Location = new System.Drawing.Point(198, 13);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnCheck.Size = new System.Drawing.Size(131, 32);
            this.btnCheck.TabIndex = 1;
            this.btnCheck.Text = "结帐(&A)";
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.EndDate);
            this.groupBox2.Controls.Add(this.starDate);
            this.groupBox2.Controls.Add(this.ctlDgFind);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.ForeColor = System.Drawing.Color.OrangeRed;
            this.groupBox2.Location = new System.Drawing.Point(0, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(216, 376);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "已结帐历史记录";
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
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(8, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "开始时间：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EndDate
            // 
            this.EndDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EndDate.Location = new System.Drawing.Point(88, 48);
            this.EndDate.Name = "EndDate";
            this.EndDate.Size = new System.Drawing.Size(120, 23);
            this.EndDate.TabIndex = 2;
            this.EndDate.ValueChanged += new System.EventHandler(this.EndDate_ValueChanged);
            // 
            // starDate
            // 
            this.starDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.starDate.Location = new System.Drawing.Point(88, 16);
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
            clsColumnInfo3.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo3.BackColor = System.Drawing.Color.White;
            clsColumnInfo3.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo3.ColumnIndex = 0;
            clsColumnInfo3.ColumnName = "BALANCE_DAT";
            clsColumnInfo3.ColumnWidth = 150;
            clsColumnInfo3.Enabled = false;
            clsColumnInfo3.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo3.HeadText = "结帐时间";
            clsColumnInfo3.ReadOnly = true;
            clsColumnInfo3.TextFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ctlDgFind.Columns.Add(clsColumnInfo3);
            this.ctlDgFind.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ctlDgFind.FullRowSelect = true;
            this.ctlDgFind.Location = new System.Drawing.Point(3, 80);
            this.ctlDgFind.MultiSelect = false;
            this.ctlDgFind.Name = "ctlDgFind";
            this.ctlDgFind.ReadOnly = false;
            this.ctlDgFind.RowHeadersVisible = true;
            this.ctlDgFind.RowHeaderWidth = 35;
            this.ctlDgFind.SelectedRowBackColor = System.Drawing.Color.Purple;
            this.ctlDgFind.SelectedRowForeColor = System.Drawing.Color.White;
            this.ctlDgFind.Size = new System.Drawing.Size(210, 288);
            this.ctlDgFind.TabIndex = 0;
            this.ctlDgFind.m_evtCurrentCellChanged += new System.EventHandler(this.ctlDgFind_m_evtCurrentCellChanged);
            this.ctlDgFind.m_evtClickCell += new com.digitalwave.controls.datagrid.clsDGTextMouseClickEventHandler(this.ctlDgFind_m_evtClickCell);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.m_dwShow);
            this.panel1.Location = new System.Drawing.Point(224, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 368);
            this.panel1.TabIndex = 5;
            // 
            // m_dwShow
            // 
            this.m_dwShow.BorderStyle = Sybase.DataWindow.DataWindowBorderStyle.None;
            this.m_dwShow.DataWindowObject = "d_opdoctorworkloadnew";
            this.m_dwShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dwShow.LibraryList = "";
            this.m_dwShow.Location = new System.Drawing.Point(0, 0);
            this.m_dwShow.Name = "m_dwShow";
            this.m_dwShow.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.m_dwShow.Size = new System.Drawing.Size(772, 364);
            this.m_dwShow.TabIndex = 3;
            this.m_dwShow.Text = "dataWindowControl1";
            // 
            // frmCheckOutOfDayGY
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 429);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmCheckOutOfDayGY";
            this.Text = "收款员日结报表窗口";
            this.Load += new System.EventHandler(this.frmCheckOutOfDayGY_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ctlDgFind)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        internal PinkieControls.ButtonXP btnReset;
        internal PinkieControls.ButtonXP buttonXP4;
        internal PinkieControls.ButtonXP buttonXP3;
        internal PinkieControls.ButtonXP buttonXP2;
        private PinkieControls.ButtonXP btnEsc;
        internal PinkieControls.ButtonXP btnPrint;
        internal PinkieControls.ButtonXP btnCheck;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.DateTimePicker EndDate;
        internal System.Windows.Forms.DateTimePicker starDate;
        internal com.digitalwave.controls.datagrid.ctlDataGrid ctlDgFind;
        private System.Windows.Forms.Panel panel1;
        internal Sybase.DataWindow.DataWindowControl m_dwShow;

    }
}