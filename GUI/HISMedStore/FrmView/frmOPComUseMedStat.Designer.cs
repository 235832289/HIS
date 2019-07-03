namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmOPComUseMedStat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOPComUseMedStat));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonXP1 = new PinkieControls.ButtonXP();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.m_cboDept = new com.digitalwave.iCare.gui.HIS.exComboBox();
            this.m_btnPrint = new PinkieControls.ButtonXP();
            this.m_btnStat = new PinkieControls.ButtonXP();
            this.m_btnExport = new PinkieControls.ButtonXP();
            this.m_datEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new PinkieControls.ButtonXP();
            this.m_datBegin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dwMed = new Sybase.DataWindow.DataWindowControl();
            this.buttonXP2 = new PinkieControls.ButtonXP();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonXP2);
            this.panel1.Controls.Add(this.buttonXP1);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.m_cboDept);
            this.panel1.Controls.Add(this.m_btnPrint);
            this.panel1.Controls.Add(this.m_btnStat);
            this.panel1.Controls.Add(this.m_btnExport);
            this.panel1.Controls.Add(this.m_datEnd);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.m_datBegin);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1028, 45);
            this.panel1.TabIndex = 5;
            // 
            // buttonXP1
            // 
            this.buttonXP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonXP1.DefaultScheme = true;
            this.buttonXP1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonXP1.Hint = "";
            this.buttonXP1.Location = new System.Drawing.Point(528, 11);
            this.buttonXP1.Name = "buttonXP1";
            this.buttonXP1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP1.Size = new System.Drawing.Size(91, 28);
            this.buttonXP1.TabIndex = 28;
            this.buttonXP1.Text = "选择医生▼";
            this.buttonXP1.Click += new System.EventHandler(this.buttonXP1_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numericUpDown1.Location = new System.Drawing.Point(625, 13);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(40, 23);
            this.numericUpDown1.TabIndex = 27;
            this.numericUpDown1.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(371, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 14);
            this.label3.TabIndex = 26;
            this.label3.Text = "科室:";
            // 
            // m_cboDept
            // 
            this.m_cboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboDept.Location = new System.Drawing.Point(411, 13);
            this.m_cboDept.Name = "m_cboDept";
            this.m_cboDept.Size = new System.Drawing.Size(112, 22);
            this.m_cboDept.TabIndex = 25;
            // 
            // m_btnPrint
            // 
            this.m_btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnPrint.DefaultScheme = true;
            this.m_btnPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnPrint.Hint = "";
            this.m_btnPrint.Location = new System.Drawing.Point(862, 11);
            this.m_btnPrint.Name = "m_btnPrint";
            this.m_btnPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnPrint.Size = new System.Drawing.Size(79, 28);
            this.m_btnPrint.TabIndex = 8;
            this.m_btnPrint.Text = "打印(&P)";
            this.m_btnPrint.Click += new System.EventHandler(this.m_btnPrint_Click);
            // 
            // m_btnStat
            // 
            this.m_btnStat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnStat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnStat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnStat.DefaultScheme = true;
            this.m_btnStat.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnStat.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnStat.Hint = "";
            this.m_btnStat.Location = new System.Drawing.Point(678, 11);
            this.m_btnStat.Name = "m_btnStat";
            this.m_btnStat.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnStat.Size = new System.Drawing.Size(91, 28);
            this.m_btnStat.TabIndex = 6;
            this.m_btnStat.Text = "按金额统计";
            this.m_btnStat.Click += new System.EventHandler(this.m_btnStat_Click);
            // 
            // m_btnExport
            // 
            this.m_btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnExport.DefaultScheme = true;
            this.m_btnExport.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnExport.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnExport.Hint = "";
            this.m_btnExport.Location = new System.Drawing.Point(944, 11);
            this.m_btnExport.Name = "m_btnExport";
            this.m_btnExport.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnExport.Size = new System.Drawing.Size(80, 28);
            this.m_btnExport.TabIndex = 7;
            this.m_btnExport.Text = "导出(&E)";
            this.m_btnExport.Click += new System.EventHandler(this.m_btnExport_Click);
            // 
            // m_datEnd
            // 
            this.m_datEnd.CustomFormat = "yyyy年MM月dd日";
            this.m_datEnd.Font = new System.Drawing.Font("宋体", 11F);
            this.m_datEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_datEnd.Location = new System.Drawing.Point(234, 12);
            this.m_datEnd.Name = "m_datEnd";
            this.m_datEnd.Size = new System.Drawing.Size(137, 24);
            this.m_datEnd.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(213, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "到";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DefaultScheme = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Hint = "";
            this.btnClose.Location = new System.Drawing.Point(773, 11);
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnClose.Size = new System.Drawing.Size(86, 28);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "按数量统计";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // m_datBegin
            // 
            this.m_datBegin.CustomFormat = "yyyy年MM月dd日";
            this.m_datBegin.Font = new System.Drawing.Font("宋体", 11F);
            this.m_datBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_datBegin.Location = new System.Drawing.Point(75, 12);
            this.m_datBegin.Name = "m_datBegin";
            this.m_datBegin.Size = new System.Drawing.Size(133, 24);
            this.m_datBegin.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(4, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "统计日期:";
            // 
            // dwMed
            // 
            this.dwMed.DataWindowObject = "";
            this.dwMed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwMed.LibraryList = "D:\\icare_ver2\\code\\BIN\\Debug\\PB_OP.pbl";
            this.dwMed.Location = new System.Drawing.Point(0, 45);
            this.dwMed.Name = "dwMed";
            this.dwMed.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwMed.Size = new System.Drawing.Size(1028, 528);
            this.dwMed.TabIndex = 6;
            this.dwMed.Text = "dataWindowControl1";
            // 
            // buttonXP2
            // 
            this.buttonXP2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonXP2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonXP2.DefaultScheme = true;
            this.buttonXP2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonXP2.Hint = "";
            this.buttonXP2.Location = new System.Drawing.Point(755, 11);
            this.buttonXP2.Name = "buttonXP2";
            this.buttonXP2.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP2.Size = new System.Drawing.Size(104, 28);
            this.buttonXP2.TabIndex = 29;
            this.buttonXP2.Text = "查询(&Q)";
            this.buttonXP2.Click += new System.EventHandler(this.buttonXP2_Click);
            // 
            // frmOPComUseMedStat
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1028, 573);
            this.Controls.Add(this.dwMed);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOPComUseMedStat";
            this.Text = "";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmOPComUseMedStat_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal PinkieControls.ButtonXP m_btnPrint;
        internal PinkieControls.ButtonXP m_btnStat;
        internal PinkieControls.ButtonXP m_btnExport;
        internal System.Windows.Forms.DateTimePicker m_datEnd;
        private System.Windows.Forms.Label label2;
        internal PinkieControls.ButtonXP btnClose;
        internal System.Windows.Forms.DateTimePicker m_datBegin;
        private System.Windows.Forms.Label label1;
        internal exComboBox m_cboDept;
        private System.Windows.Forms.Label label3;
        internal Sybase.DataWindow.DataWindowControl dwMed;
        public System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.NumericUpDown numericUpDown1;
        internal PinkieControls.ButtonXP buttonXP1;
        internal PinkieControls.ButtonXP buttonXP2;
    }
}