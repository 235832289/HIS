namespace com.digitalwave.iCare.gui.HIS.Reports
{
    partial class frmRptStat__GroupInComeByDoctor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptStat__GroupInComeByDoctor));
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_dwRep = new Sybase.DataWindow.DataWindowControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_btnDept = new PinkieControls.ButtonXP();
            this.m_dtpSearchEndDate = new System.Windows.Forms.DateTimePicker();
            this.m_dtpSearchBeginDate = new System.Windows.Forms.DateTimePicker();
            this.m_btnPreview = new PinkieControls.ButtonXP();
            this.m_btnPrint = new PinkieControls.ButtonXP();
            this.m_btnSelect = new PinkieControls.ButtonXP();
            this.m_btnExport = new PinkieControls.ButtonXP();
            this.label2 = new System.Windows.Forms.Label();
            this.m_btnClose = new PinkieControls.ButtonXP();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.m_dwRep);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1028, 666);
            this.panel2.TabIndex = 5;
            // 
            // m_dwRep
            // 
            this.m_dwRep.BorderStyle = Sybase.DataWindow.DataWindowBorderStyle.None;
            this.m_dwRep.DataWindowObject = "";
            this.m_dwRep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dwRep.LibraryList = "";
            this.m_dwRep.Location = new System.Drawing.Point(0, 0);
            this.m_dwRep.Name = "m_dwRep";
            this.m_dwRep.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.m_dwRep.Size = new System.Drawing.Size(1024, 662);
            this.m_dwRep.TabIndex = 0;
            this.m_dwRep.Text = "dataWindowControl1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_btnDept);
            this.panel1.Controls.Add(this.m_dtpSearchEndDate);
            this.panel1.Controls.Add(this.m_dtpSearchBeginDate);
            this.panel1.Controls.Add(this.m_btnPreview);
            this.panel1.Controls.Add(this.m_btnPrint);
            this.panel1.Controls.Add(this.m_btnSelect);
            this.panel1.Controls.Add(this.m_btnExport);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.m_btnClose);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1028, 47);
            this.panel1.TabIndex = 4;
            // 
            // m_btnDept
            // 
            this.m_btnDept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_btnDept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnDept.DefaultScheme = true;
            this.m_btnDept.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnDept.Hint = "";
            this.m_btnDept.Location = new System.Drawing.Point(378, 9);
            this.m_btnDept.Name = "m_btnDept";
            this.m_btnDept.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnDept.Size = new System.Drawing.Size(97, 30);
            this.m_btnDept.TabIndex = 76;
            this.m_btnDept.Text = "选择病区▼";
            this.m_btnDept.Click += new System.EventHandler(this.m_btnDept_Click);
            // 
            // m_dtpSearchEndDate
            // 
            this.m_dtpSearchEndDate.CustomFormat = "yyyy年MM月dd日";
            this.m_dtpSearchEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpSearchEndDate.Location = new System.Drawing.Point(236, 13);
            this.m_dtpSearchEndDate.Name = "m_dtpSearchEndDate";
            this.m_dtpSearchEndDate.Size = new System.Drawing.Size(125, 23);
            this.m_dtpSearchEndDate.TabIndex = 75;
            this.m_dtpSearchEndDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_dtpSearchEndDate_KeyDown);
            // 
            // m_dtpSearchBeginDate
            // 
            this.m_dtpSearchBeginDate.CustomFormat = "yyyy年MM月dd日";
            this.m_dtpSearchBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpSearchBeginDate.Location = new System.Drawing.Point(79, 13);
            this.m_dtpSearchBeginDate.Name = "m_dtpSearchBeginDate";
            this.m_dtpSearchBeginDate.Size = new System.Drawing.Size(125, 23);
            this.m_dtpSearchBeginDate.TabIndex = 74;
            this.m_dtpSearchBeginDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_dtpSearchBeginDate_KeyDown);
            // 
            // m_btnPreview
            // 
            this.m_btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_btnPreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnPreview.DefaultScheme = true;
            this.m_btnPreview.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnPreview.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnPreview.Hint = "";
            this.m_btnPreview.Location = new System.Drawing.Point(719, 9);
            this.m_btnPreview.Name = "m_btnPreview";
            this.m_btnPreview.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnPreview.Size = new System.Drawing.Size(72, 30);
            this.m_btnPreview.TabIndex = 4;
            this.m_btnPreview.Text = "预览(&V)";
            this.m_btnPreview.Click += new System.EventHandler(this.m_btnPreview_Click);
            // 
            // m_btnPrint
            // 
            this.m_btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnPrint.DefaultScheme = true;
            this.m_btnPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnPrint.Hint = "";
            this.m_btnPrint.Location = new System.Drawing.Point(869, 9);
            this.m_btnPrint.Name = "m_btnPrint";
            this.m_btnPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnPrint.Size = new System.Drawing.Size(72, 30);
            this.m_btnPrint.TabIndex = 6;
            this.m_btnPrint.Text = "打印(&P)";
            this.m_btnPrint.Click += new System.EventHandler(this.m_btnPrint_Click);
            // 
            // m_btnSelect
            // 
            this.m_btnSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_btnSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnSelect.DefaultScheme = true;
            this.m_btnSelect.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnSelect.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnSelect.Hint = "";
            this.m_btnSelect.Location = new System.Drawing.Point(641, 9);
            this.m_btnSelect.Name = "m_btnSelect";
            this.m_btnSelect.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnSelect.Size = new System.Drawing.Size(72, 30);
            this.m_btnSelect.TabIndex = 3;
            this.m_btnSelect.Text = "检索(&S)";
            this.m_btnSelect.Click += new System.EventHandler(this.m_btnSelect_Click);
            // 
            // m_btnExport
            // 
            this.m_btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnExport.DefaultScheme = true;
            this.m_btnExport.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnExport.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnExport.Hint = "";
            this.m_btnExport.Location = new System.Drawing.Point(794, 9);
            this.m_btnExport.Name = "m_btnExport";
            this.m_btnExport.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnExport.Size = new System.Drawing.Size(72, 30);
            this.m_btnExport.TabIndex = 5;
            this.m_btnExport.Text = "导出(&E)";
            this.m_btnExport.Click += new System.EventHandler(this.m_btnExport_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(210, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 12;
            this.label2.Text = "到";
            // 
            // m_btnClose
            // 
            this.m_btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnClose.DefaultScheme = true;
            this.m_btnClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnClose.Hint = "";
            this.m_btnClose.Location = new System.Drawing.Point(944, 9);
            this.m_btnClose.Name = "m_btnClose";
            this.m_btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnClose.Size = new System.Drawing.Size(72, 30);
            this.m_btnClose.TabIndex = 7;
            this.m_btnClose.Text = "关闭(&C)";
            this.m_btnClose.Click += new System.EventHandler(this.m_btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "统计日期：";
            // 
            // frmRptStat__GroupInComeByDoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 713);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRptStat__GroupInComeByDoctor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "功能科室专业组分类报表";
            this.Shown += new System.EventHandler(this.frmRptStat__GroupInComeByDoctor_Shown);
            this.Load += new System.EventHandler(this.frmRptStat__GroupInComeByDoctor_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        internal PinkieControls.ButtonXP m_btnClose;
        internal Sybase.DataWindow.DataWindowControl m_dwRep;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        internal PinkieControls.ButtonXP m_btnPreview;
        internal PinkieControls.ButtonXP m_btnPrint;
        internal PinkieControls.ButtonXP m_btnSelect;
        private System.Windows.Forms.Panel panel1;
        internal PinkieControls.ButtonXP m_btnExport;
        private System.Windows.Forms.DateTimePicker m_dtpSearchEndDate;
        private System.Windows.Forms.DateTimePicker m_dtpSearchBeginDate;
        internal PinkieControls.ButtonXP m_btnDept;

        //internal com.digitalwave.Controls.ctlMaskedDateTimePicker m_dtpSearchEndDate;
        //internal com.digitalwave.Controls.ctlMaskedDateTimePicker m_dtpSearchBeginDate;
    }
}