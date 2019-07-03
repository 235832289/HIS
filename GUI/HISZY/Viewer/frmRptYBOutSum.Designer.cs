namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmRptYBOutSum
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptYBOutSum));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdYB = new PinkieControls.ButtonXP();
            this.btnDept = new System.Windows.Forms.Button();
            this.cboDept = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboDiseaseType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dteRq2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dteRq1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSelect = new PinkieControls.ButtonXP();
            this.btnPreview = new PinkieControls.ButtonXP();
            this.btnPrint = new PinkieControls.ButtonXP();
            this.btnExport = new PinkieControls.ButtonXP();
            this.btnClose = new PinkieControls.ButtonXP();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lsvYB = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.dwRep = new Sybase.DataWindow.DataWindowControl();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdYB);
            this.panel1.Controls.Add(this.btnDept);
            this.panel1.Controls.Add(this.cboDept);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboDiseaseType);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dteRq2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dteRq1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnSelect);
            this.panel1.Controls.Add(this.btnPreview);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1012, 40);
            this.panel1.TabIndex = 0;
            // 
            // cmdYB
            // 
            this.cmdYB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdYB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cmdYB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdYB.DefaultScheme = true;
            this.cmdYB.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdYB.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdYB.Hint = "";
            this.cmdYB.Location = new System.Drawing.Point(641, 5);
            this.cmdYB.Name = "cmdYB";
            this.cmdYB.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdYB.Size = new System.Drawing.Size(59, 32);
            this.cmdYB.TabIndex = 23;
            this.cmdYB.Text = "医保分类";
            this.cmdYB.Click += new System.EventHandler(this.cmdYB_Click);
            // 
            // btnDept
            // 
            this.btnDept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDept.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDept.Location = new System.Drawing.Point(490, 9);
            this.btnDept.Name = "btnDept";
            this.btnDept.Size = new System.Drawing.Size(20, 23);
            this.btnDept.TabIndex = 22;
            this.btnDept.Text = "…";
            this.btnDept.UseVisualStyleBackColor = true;
            this.btnDept.Click += new System.EventHandler(this.btnDept_Click);
            // 
            // cboDept
            // 
            this.cboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDept.Font = new System.Drawing.Font("宋体", 11.5F);
            this.cboDept.FormattingEnabled = true;
            this.cboDept.Items.AddRange(new object[] {
            "全部",
            "选择》"});
            this.cboDept.Location = new System.Drawing.Point(429, 9);
            this.cboDept.Name = "cboDept";
            this.cboDept.Size = new System.Drawing.Size(59, 23);
            this.cboDept.TabIndex = 21;
            this.cboDept.SelectedIndexChanged += new System.EventHandler(this.cboDept_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(388, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 20;
            this.label1.Text = "科室：";
            // 
            // cboDiseaseType
            // 
            this.cboDiseaseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDiseaseType.Font = new System.Drawing.Font("宋体", 11.5F);
            this.cboDiseaseType.FormattingEnabled = true;
            this.cboDiseaseType.Items.AddRange(new object[] {
            "全部",
            "普通",
            "特殊"});
            this.cboDiseaseType.Location = new System.Drawing.Point(556, 9);
            this.cboDiseaseType.Name = "cboDiseaseType";
            this.cboDiseaseType.Size = new System.Drawing.Size(59, 23);
            this.cboDiseaseType.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(512, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 18;
            this.label4.Text = "病种：";
            // 
            // dteRq2
            // 
            this.dteRq2.CustomFormat = "yyyy年MM月dd日";
            this.dteRq2.Font = new System.Drawing.Font("宋体", 11F);
            this.dteRq2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dteRq2.Location = new System.Drawing.Point(253, 8);
            this.dteRq2.Name = "dteRq2";
            this.dteRq2.Size = new System.Drawing.Size(133, 24);
            this.dteRq2.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(232, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 17;
            this.label2.Text = "到";
            // 
            // dteRq1
            // 
            this.dteRq1.CustomFormat = "yyyy年MM月dd日";
            this.dteRq1.Font = new System.Drawing.Font("宋体", 11F);
            this.dteRq1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dteRq1.Location = new System.Drawing.Point(96, 8);
            this.dteRq1.Name = "dteRq1";
            this.dteRq1.Size = new System.Drawing.Size(133, 24);
            this.dteRq1.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(4, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 14);
            this.label3.TabIndex = 16;
            this.label3.Text = "统计日期：从";
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelect.DefaultScheme = true;
            this.btnSelect.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSelect.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelect.Hint = "";
            this.btnSelect.Location = new System.Drawing.Point(703, 5);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnSelect.Size = new System.Drawing.Size(59, 32);
            this.btnSelect.TabIndex = 4;
            this.btnSelect.Text = "检索(&S)";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnPreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreview.DefaultScheme = true;
            this.btnPreview.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPreview.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPreview.Hint = "";
            this.btnPreview.Location = new System.Drawing.Point(764, 5);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnPreview.Size = new System.Drawing.Size(59, 32);
            this.btnPreview.TabIndex = 13;
            this.btnPreview.Text = "预览(&V)";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.DefaultScheme = true;
            this.btnPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrint.Hint = "";
            this.btnPrint.Location = new System.Drawing.Point(886, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnPrint.Size = new System.Drawing.Size(59, 32);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.DefaultScheme = true;
            this.btnExport.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExport.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExport.Hint = "";
            this.btnExport.Location = new System.Drawing.Point(825, 5);
            this.btnExport.Name = "btnExport";
            this.btnExport.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnExport.Size = new System.Drawing.Size(59, 32);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "导出(&E)";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DefaultScheme = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Hint = "";
            this.btnClose.Location = new System.Drawing.Point(947, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnClose.Size = new System.Drawing.Size(59, 32);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lsvYB);
            this.panel2.Controls.Add(this.dwRep);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1012, 571);
            this.panel2.TabIndex = 3;
            // 
            // lsvYB
            // 
            this.lsvYB.CheckBoxes = true;
            this.lsvYB.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lsvYB.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvYB.Location = new System.Drawing.Point(639, -2);
            this.lsvYB.Name = "lsvYB";
            this.lsvYB.Size = new System.Drawing.Size(182, 270);
            this.lsvYB.TabIndex = 1;
            this.lsvYB.UseCompatibleStateImageBehavior = false;
            this.lsvYB.View = System.Windows.Forms.View.Details;
            this.lsvYB.Leave += new System.EventHandler(this.lsvYB_Leave);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "医保分类";
            this.columnHeader1.Width = 150;
            // 
            // dwRep
            // 
            this.dwRep.BorderStyle = Sybase.DataWindow.DataWindowBorderStyle.None;
            this.dwRep.DataWindowObject = "";
            this.dwRep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwRep.LibraryList = "";
            this.dwRep.Location = new System.Drawing.Point(0, 0);
            this.dwRep.Name = "dwRep";
            this.dwRep.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwRep.Size = new System.Drawing.Size(1008, 567);
            this.dwRep.TabIndex = 0;
            this.dwRep.Text = "dataWindowControl1";
            // 
            // frmRptYBOutSum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 611);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmRptYBOutSum";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "出院医保病人统计报表";
            this.Load += new System.EventHandler(this.frmRptYBOutSum_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        internal PinkieControls.ButtonXP btnClose;
        internal PinkieControls.ButtonXP btnPrint;
        internal PinkieControls.ButtonXP btnSelect;
        internal PinkieControls.ButtonXP btnExport;
        internal PinkieControls.ButtonXP btnPreview;
        private System.Windows.Forms.Panel panel2;
        internal Sybase.DataWindow.DataWindowControl dwRep;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.DateTimePicker dteRq2;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.DateTimePicker dteRq1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboDiseaseType;
        private System.Windows.Forms.Button btnDept;
        private System.Windows.Forms.ComboBox cboDept;
        private System.Windows.Forms.Label label1;
        internal PinkieControls.ButtonXP cmdYB;
        internal System.Windows.Forms.ListView lsvYB;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}