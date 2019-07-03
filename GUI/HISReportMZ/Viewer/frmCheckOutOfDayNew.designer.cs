namespace com.digitalwave.iCare.gui.HIS.Reports
{
    partial class frmCheckOutOfDayNew
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
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo4 = new com.digitalwave.controls.datagrid.clsColumnInfo();
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
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDgFind)).BeginInit();
            this.groupBox3.SuspendLayout();
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
            this.groupBox2.Location = new System.Drawing.Point(0, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(220, 584);
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
            clsColumnInfo4.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo4.BackColor = System.Drawing.Color.White;
            clsColumnInfo4.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo4.ColumnIndex = 0;
            clsColumnInfo4.ColumnName = "BALANCE_DAT";
            clsColumnInfo4.ColumnWidth = 150;
            clsColumnInfo4.Enabled = false;
            clsColumnInfo4.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo4.HeadText = "结帐时间";
            clsColumnInfo4.ReadOnly = true;
            clsColumnInfo4.TextFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ctlDgFind.Columns.Add(clsColumnInfo4);
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
            this.ctlDgFind.Size = new System.Drawing.Size(210, 491);
            this.ctlDgFind.TabIndex = 5;
            this.ctlDgFind.m_evtCurrentCellChanged += new System.EventHandler(this.ctlDgFind_m_evtCurrentCellChanged);
            this.ctlDgFind.m_evtClickCell += new com.digitalwave.controls.datagrid.clsDGTextMouseClickEventHandler(this.ctlDgFind_m_evtClickCell);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.m_dwShow);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(220, 62);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(808, 584);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // m_dwShow
            // 
            this.m_dwShow.DataWindowObject = "d_invoice_checkout";
            this.m_dwShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dwShow.LibraryList = "D:\\dev\\icare_ver2\\Code\\bin\\Debug\\PB_OP.pbl";
            this.m_dwShow.Location = new System.Drawing.Point(3, 19);
            this.m_dwShow.Name = "m_dwShow";
            this.m_dwShow.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.m_dwShow.Size = new System.Drawing.Size(802, 562);
            this.m_dwShow.TabIndex = 0;
            this.m_dwShow.Text = "dataWindowControl1";
            // 
            // frmCheckOutOfDayNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 646);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmCheckOutOfDayNew";
            this.Text = "门诊收费员日结报表";
            this.Load += new System.EventHandler(this.frmCheckOutOfDayNew_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ctlDgFind)).EndInit();
            this.groupBox3.ResumeLayout(false);
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
    }
}