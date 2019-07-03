namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmPatientInfLog
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_txtInPatientId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.m_dtpBeginDate = new System.Windows.Forms.DateTimePicker();
            this.m_cmdReturn = new PinkieControls.ButtonXP();
            this.m_cmdPrint = new PinkieControls.ButtonXP();
            this.m_cmdSearch = new PinkieControls.ButtonXP();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_dwLog = new Sybase.DataWindow.DataWindowControl();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_txtInPatientId);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.m_dtpEndDate);
            this.panel1.Controls.Add(this.m_dtpBeginDate);
            this.panel1.Controls.Add(this.m_cmdReturn);
            this.panel1.Controls.Add(this.m_cmdPrint);
            this.panel1.Controls.Add(this.m_cmdSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(940, 53);
            this.panel1.TabIndex = 0;
            // 
            // m_txtInPatientId
            // 
            this.m_txtInPatientId.Location = new System.Drawing.Point(398, 14);
            this.m_txtInPatientId.Name = "m_txtInPatientId";
            this.m_txtInPatientId.Size = new System.Drawing.Size(117, 23);
            this.m_txtInPatientId.TabIndex = 19;
            this.m_txtInPatientId.TextChanged += new System.EventHandler(this.m_txtInPatientId_TextChanged);
            this.m_txtInPatientId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtInPatientId_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(345, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 18;
            this.label3.Text = "住院号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 14);
            this.label1.TabIndex = 16;
            this.label1.Text = "从";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(160, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 17;
            this.label2.Text = "至";
            // 
            // m_dtpEndDate
            // 
            this.m_dtpEndDate.Location = new System.Drawing.Point(182, 14);
            this.m_dtpEndDate.Name = "m_dtpEndDate";
            this.m_dtpEndDate.Size = new System.Drawing.Size(123, 23);
            this.m_dtpEndDate.TabIndex = 14;
            // 
            // m_dtpBeginDate
            // 
            this.m_dtpBeginDate.Location = new System.Drawing.Point(30, 14);
            this.m_dtpBeginDate.Name = "m_dtpBeginDate";
            this.m_dtpBeginDate.Size = new System.Drawing.Size(126, 23);
            this.m_dtpBeginDate.TabIndex = 15;
            // 
            // m_cmdReturn
            // 
            this.m_cmdReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdReturn.DefaultScheme = true;
            this.m_cmdReturn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdReturn.Hint = "";
            this.m_cmdReturn.Location = new System.Drawing.Point(844, 12);
            this.m_cmdReturn.Name = "m_cmdReturn";
            this.m_cmdReturn.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdReturn.Size = new System.Drawing.Size(86, 31);
            this.m_cmdReturn.TabIndex = 13;
            this.m_cmdReturn.Text = "返回(&R)";
            this.m_cmdReturn.Click += new System.EventHandler(this.m_cmdReturn_Click);
            // 
            // m_cmdPrint
            // 
            this.m_cmdPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdPrint.DefaultScheme = true;
            this.m_cmdPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdPrint.Hint = "";
            this.m_cmdPrint.Location = new System.Drawing.Point(751, 12);
            this.m_cmdPrint.Name = "m_cmdPrint";
            this.m_cmdPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdPrint.Size = new System.Drawing.Size(86, 31);
            this.m_cmdPrint.TabIndex = 12;
            this.m_cmdPrint.Text = "打印(&P)";
            this.m_cmdPrint.Click += new System.EventHandler(this.m_cmdPrint_Click);
            // 
            // m_cmdSearch
            // 
            this.m_cmdSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdSearch.DefaultScheme = true;
            this.m_cmdSearch.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSearch.Hint = "";
            this.m_cmdSearch.Location = new System.Drawing.Point(645, 12);
            this.m_cmdSearch.Name = "m_cmdSearch";
            this.m_cmdSearch.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSearch.Size = new System.Drawing.Size(98, 31);
            this.m_cmdSearch.TabIndex = 11;
            this.m_cmdSearch.Text = "查询(&S)";
            this.m_cmdSearch.Click += new System.EventHandler(this.m_cmdSearch_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_dwLog);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(940, 598);
            this.panel2.TabIndex = 1;
            // 
            // m_dwLog
            // 
            this.m_dwLog.DataWindowObject = "d_inflog";
            this.m_dwLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dwLog.LibraryList = "D:\\dev\\icare_ver2\\Code\\bin\\Debug\\pb_new.pbl";
            this.m_dwLog.Location = new System.Drawing.Point(0, 0);
            this.m_dwLog.Name = "m_dwLog";
            this.m_dwLog.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.m_dwLog.Size = new System.Drawing.Size(940, 598);
            this.m_dwLog.TabIndex = 0;
            this.m_dwLog.Text = "dataWindowControl1";
            // 
            // frmPatientInfLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 651);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmPatientInfLog";
            this.Text = "病人资料变动日志";
            this.Load += new System.EventHandler(this.frmPatientInfLog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private PinkieControls.ButtonXP m_cmdReturn;
        private PinkieControls.ButtonXP m_cmdPrint;
        private PinkieControls.ButtonXP m_cmdSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.DateTimePicker m_dtpEndDate;
        internal System.Windows.Forms.DateTimePicker m_dtpBeginDate;
        internal Sybase.DataWindow.DataWindowControl m_dwLog;
        internal System.Windows.Forms.TextBox m_txtInPatientId;
        private System.Windows.Forms.Label label3;
    }
}