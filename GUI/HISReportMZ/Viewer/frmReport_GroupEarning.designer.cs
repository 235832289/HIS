namespace com.digitalwave.iCare.gui.HIS.Reports
{
    partial class frmReport_GroupEarning
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
            this.dw_groupearning = new Sybase.DataWindow.DataWindowControl();
            this.m_dtpEndDat = new System.Windows.Forms.DateTimePicker();
            this.m_dtpBeginDat = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cmdQuery = new PinkieControls.ButtonXP();
            this.m_cmdPrint = new PinkieControls.ButtonXP();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonXP1 = new PinkieControls.ButtonXP();
            this.m_cmdExit = new PinkieControls.ButtonXP();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonXP3 = new PinkieControls.ButtonXP();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dw_groupearning);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(875, 507);
            this.panel1.TabIndex = 14;
            // 
            // dw_groupearning
            // 
            this.dw_groupearning.DataWindowObject = "d_bih_reportgroupearning";
            this.dw_groupearning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dw_groupearning.LibraryList = "D:\\icare_ver2\\Code\\bin\\Debug\\PB_OP.pbl";
            this.dw_groupearning.Location = new System.Drawing.Point(0, 0);
            this.dw_groupearning.Name = "dw_groupearning";
            this.dw_groupearning.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dw_groupearning.Size = new System.Drawing.Size(875, 507);
            this.dw_groupearning.TabIndex = 19;
            // 
            // m_dtpEndDat
            // 
            this.m_dtpEndDat.Location = new System.Drawing.Point(282, 13);
            this.m_dtpEndDat.Name = "m_dtpEndDat";
            this.m_dtpEndDat.Size = new System.Drawing.Size(125, 23);
            this.m_dtpEndDat.TabIndex = 11;
            this.m_dtpEndDat.Value = new System.DateTime(2007, 4, 2, 0, 0, 0, 0);
            // 
            // m_dtpBeginDat
            // 
            this.m_dtpBeginDat.Location = new System.Drawing.Point(128, 13);
            this.m_dtpBeginDat.Name = "m_dtpBeginDat";
            this.m_dtpBeginDat.Size = new System.Drawing.Size(124, 23);
            this.m_dtpBeginDat.TabIndex = 8;
            this.m_dtpBeginDat.Value = new System.DateTime(2007, 1, 1, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 19);
            this.label1.TabIndex = 9;
            this.label1.Text = "统计时间:  开始";
            // 
            // m_cmdQuery
            // 
            this.m_cmdQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdQuery.DefaultScheme = true;
            this.m_cmdQuery.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdQuery.Hint = "";
            this.m_cmdQuery.Location = new System.Drawing.Point(445, 10);
            this.m_cmdQuery.Name = "m_cmdQuery";
            this.m_cmdQuery.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdQuery.Size = new System.Drawing.Size(79, 31);
            this.m_cmdQuery.TabIndex = 55;
            this.m_cmdQuery.Text = "查询(&F)";
            this.m_cmdQuery.Click += new System.EventHandler(this.m_cmdQuery_Click);
            // 
            // m_cmdPrint
            // 
            this.m_cmdPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdPrint.DefaultScheme = true;
            this.m_cmdPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdPrint.Hint = "";
            this.m_cmdPrint.Location = new System.Drawing.Point(532, 10);
            this.m_cmdPrint.Name = "m_cmdPrint";
            this.m_cmdPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdPrint.Size = new System.Drawing.Size(79, 31);
            this.m_cmdPrint.TabIndex = 56;
            this.m_cmdPrint.Text = "打印(&P)";
            this.m_cmdPrint.Click += new System.EventHandler(this.m_cmdPrint_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonXP3);
            this.panel2.Controls.Add(this.buttonXP1);
            this.panel2.Controls.Add(this.m_cmdExit);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.m_cmdPrint);
            this.panel2.Controls.Add(this.m_cmdQuery);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.m_dtpBeginDat);
            this.panel2.Controls.Add(this.m_dtpEndDat);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(875, 51);
            this.panel2.TabIndex = 16;
            // 
            // buttonXP1
            // 
            this.buttonXP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP1.DefaultScheme = true;
            this.buttonXP1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP1.Hint = "";
            this.buttonXP1.Location = new System.Drawing.Point(619, 10);
            this.buttonXP1.Name = "buttonXP1";
            this.buttonXP1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP1.Size = new System.Drawing.Size(79, 31);
            this.buttonXP1.TabIndex = 59;
            this.buttonXP1.Text = "预览(&V)";
            this.buttonXP1.Click += new System.EventHandler(this.buttonXP1_Click);
            // 
            // m_cmdExit
            // 
            this.m_cmdExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdExit.DefaultScheme = true;
            this.m_cmdExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdExit.Hint = "";
            this.m_cmdExit.Location = new System.Drawing.Point(787, 10);
            this.m_cmdExit.Name = "m_cmdExit";
            this.m_cmdExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdExit.Size = new System.Drawing.Size(79, 31);
            this.m_cmdExit.TabIndex = 58;
            this.m_cmdExit.Text = "退出(&X)";
            this.m_cmdExit.Click += new System.EventHandler(this.m_cmdExit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(257, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 57;
            this.label2.Text = "至";
            // 
            // buttonXP3
            // 
            this.buttonXP3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP3.DefaultScheme = true;
            this.buttonXP3.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonXP3.Hint = "";
            this.buttonXP3.Location = new System.Drawing.Point(704, 10);
            this.buttonXP3.Name = "buttonXP3";
            this.buttonXP3.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP3.Size = new System.Drawing.Size(77, 30);
            this.buttonXP3.TabIndex = 77;
            this.buttonXP3.Text = "导出(&E)";
            this.buttonXP3.Click += new System.EventHandler(this.buttonXP3_Click);
            // 
            // frmReport_GroupEarning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 558);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmReport_GroupEarning";
            this.Text = "按组统计门诊挂号费及诊金报表";
            this.Load += new System.EventHandler(this.frmReport_GroupEarning_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        internal Sybase.DataWindow.DataWindowControl dw_groupearning;
        internal System.Windows.Forms.DateTimePicker m_dtpEndDat;
        internal System.Windows.Forms.DateTimePicker m_dtpBeginDat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        internal PinkieControls.ButtonXP m_cmdQuery;
        internal PinkieControls.ButtonXP m_cmdPrint;
        internal PinkieControls.ButtonXP m_cmdExit;
        private System.Windows.Forms.Label label2;
        internal PinkieControls.ButtonXP buttonXP1;
        public PinkieControls.ButtonXP buttonXP3;

    }
}