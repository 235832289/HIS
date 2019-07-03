namespace com.digitalwave.iCare.gui.HIS.Reports
{
    partial class frmRptNOCheckOutInvoice
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
            this.btnClose = new PinkieControls.ButtonXP();
            this.btnPrint = new PinkieControls.ButtonXP();
            this.btnFind = new PinkieControls.ButtonXP();
            this.dataWindowControl1 = new Sybase.DataWindow.DataWindowControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExcel = new PinkieControls.ButtonXP();
            this.btnPreview = new PinkieControls.ButtonXP();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtm_end = new System.Windows.Forms.DateTimePicker();
            this.dtm_start = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnClose.DefaultScheme = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClose.Hint = "";
            this.btnClose.Location = new System.Drawing.Point(878, 20);
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnClose.Size = new System.Drawing.Size(103, 43);
            this.btnClose.TabIndex = 60;
            this.btnClose.Text = "退出(&E)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnPrint.DefaultScheme = true;
            this.btnPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPrint.Hint = "";
            this.btnPrint.Location = new System.Drawing.Point(660, 20);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnPrint.Size = new System.Drawing.Size(103, 43);
            this.btnPrint.TabIndex = 59;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnFind.DefaultScheme = true;
            this.btnFind.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnFind.Hint = "";
            this.btnFind.Location = new System.Drawing.Point(444, 20);
            this.btnFind.Name = "btnFind";
            this.btnFind.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnFind.Size = new System.Drawing.Size(101, 43);
            this.btnFind.TabIndex = 58;
            this.btnFind.Text = "查询(&F)";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // dataWindowControl1
            // 
            this.dataWindowControl1.DataWindowObject = "";
            this.dataWindowControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataWindowControl1.LibraryList = "";
            this.dataWindowControl1.Location = new System.Drawing.Point(0, 84);
            this.dataWindowControl1.Name = "dataWindowControl1";
            this.dataWindowControl1.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dataWindowControl1.Size = new System.Drawing.Size(1028, 581);
            this.dataWindowControl1.TabIndex = 5;
            this.dataWindowControl1.Text = "dataWindowControl1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtm_end);
            this.panel1.Controls.Add(this.dtm_start);
            this.panel1.Controls.Add(this.btnExcel);
            this.panel1.Controls.Add(this.btnPreview);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnFind);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1028, 84);
            this.panel1.TabIndex = 6;
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnExcel.DefaultScheme = true;
            this.btnExcel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExcel.Hint = "";
            this.btnExcel.Location = new System.Drawing.Point(769, 20);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnExcel.Size = new System.Drawing.Size(103, 43);
            this.btnExcel.TabIndex = 62;
            this.btnExcel.Text = "导出(&D)";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnPreview.DefaultScheme = true;
            this.btnPreview.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPreview.Hint = "";
            this.btnPreview.Location = new System.Drawing.Point(551, 20);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnPreview.Size = new System.Drawing.Size(103, 43);
            this.btnPreview.TabIndex = 61;
            this.btnPreview.Text = "预览(&R)";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 66;
            this.label2.Text = "时间段：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(208, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 14);
            this.label1.TabIndex = 65;
            this.label1.Text = "～";
            // 
            // dtm_end
            // 
            this.dtm_end.CustomFormat = "yyyy年MM月dd日";
            this.dtm_end.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtm_end.Location = new System.Drawing.Point(234, 29);
            this.dtm_end.Name = "dtm_end";
            this.dtm_end.Size = new System.Drawing.Size(122, 23);
            this.dtm_end.TabIndex = 64;
            // 
            // dtm_start
            // 
            this.dtm_start.CustomFormat = "yyyy年MM月dd日";
            this.dtm_start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtm_start.Location = new System.Drawing.Point(86, 29);
            this.dtm_start.Name = "dtm_start";
            this.dtm_start.Size = new System.Drawing.Size(120, 23);
            this.dtm_start.TabIndex = 63;
            this.dtm_start.Value = new System.DateTime(2009, 12, 8, 11, 48, 0, 0);
            // 
            // frmRptNOCheckOutInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 665);
            this.Controls.Add(this.dataWindowControl1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmRptNOCheckOutInvoice";
            this.Text = "收费员未结算报表";
            this.Load += new System.EventHandler(this.frmRptNOCheckOutInvoice_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public PinkieControls.ButtonXP btnClose;
        public PinkieControls.ButtonXP btnPrint;
        public PinkieControls.ButtonXP btnFind;
        public Sybase.DataWindow.DataWindowControl dataWindowControl1;
        private System.Windows.Forms.Panel panel1;
        public PinkieControls.ButtonXP btnPreview;
        public PinkieControls.ButtonXP btnExcel;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DateTimePicker dtm_end;
        public System.Windows.Forms.DateTimePicker dtm_start;
        private System.Windows.Forms.Label label2;
    }
}