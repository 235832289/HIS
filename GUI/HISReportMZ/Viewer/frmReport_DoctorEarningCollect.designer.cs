namespace com.digitalwave.iCare.gui.HIS.Reports
{
    partial class frmReport_DoctorEarningCollect
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
            this.dw_doctorearning = new Sybase.DataWindow.DataWindowControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonXP2 = new PinkieControls.ButtonXP();
            this.buttonXP1 = new PinkieControls.ButtonXP();
            this.m_cmdPrint = new PinkieControls.ButtonXP();
            this.m_cmdQuery = new PinkieControls.ButtonXP();
            this.label1 = new System.Windows.Forms.Label();
            this.m_dtpBeginDat = new System.Windows.Forms.DateTimePicker();
            this.m_dtpEndDat = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonXP3 = new PinkieControls.ButtonXP();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dw_doctorearning);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1028, 512);
            this.panel1.TabIndex = 14;
            // 
            // dw_doctorearning
            // 
            this.dw_doctorearning.DataWindowObject = "";
            this.dw_doctorearning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dw_doctorearning.LibraryList = "";
            this.dw_doctorearning.Location = new System.Drawing.Point(0, 0);
            this.dw_doctorearning.Name = "dw_doctorearning";
            this.dw_doctorearning.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dw_doctorearning.Size = new System.Drawing.Size(1028, 512);
            this.dw_doctorearning.TabIndex = 19;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonXP3);
            this.panel2.Controls.Add(this.buttonXP2);
            this.panel2.Controls.Add(this.buttonXP1);
            this.panel2.Controls.Add(this.m_cmdPrint);
            this.panel2.Controls.Add(this.m_cmdQuery);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.m_dtpBeginDat);
            this.panel2.Controls.Add(this.m_dtpEndDat);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1028, 49);
            this.panel2.TabIndex = 16;
            // 
            // buttonXP2
            // 
            this.buttonXP2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP2.DefaultScheme = true;
            this.buttonXP2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP2.Hint = "";
            this.buttonXP2.Location = new System.Drawing.Point(686, 10);
            this.buttonXP2.Name = "buttonXP2";
            this.buttonXP2.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP2.Size = new System.Drawing.Size(77, 30);
            this.buttonXP2.TabIndex = 58;
            this.buttonXP2.Text = "预览(&V)";
            this.buttonXP2.Click += new System.EventHandler(this.buttonXP2_Click);
            // 
            // buttonXP1
            // 
            this.buttonXP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP1.DefaultScheme = true;
            this.buttonXP1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP1.Hint = "";
            this.buttonXP1.Location = new System.Drawing.Point(855, 10);
            this.buttonXP1.Name = "buttonXP1";
            this.buttonXP1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP1.Size = new System.Drawing.Size(77, 30);
            this.buttonXP1.TabIndex = 57;
            this.buttonXP1.Text = "退出(&X)";
            this.buttonXP1.Click += new System.EventHandler(this.buttonXP1_Click);
            // 
            // m_cmdPrint
            // 
            this.m_cmdPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdPrint.DefaultScheme = true;
            this.m_cmdPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdPrint.Hint = "";
            this.m_cmdPrint.Location = new System.Drawing.Point(601, 10);
            this.m_cmdPrint.Name = "m_cmdPrint";
            this.m_cmdPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdPrint.Size = new System.Drawing.Size(77, 30);
            this.m_cmdPrint.TabIndex = 56;
            this.m_cmdPrint.Text = "打印(&P)";
            this.m_cmdPrint.Click += new System.EventHandler(this.m_cmdPrint_Click);
            // 
            // m_cmdQuery
            // 
            this.m_cmdQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdQuery.DefaultScheme = true;
            this.m_cmdQuery.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdQuery.Hint = "";
            this.m_cmdQuery.Location = new System.Drawing.Point(516, 10);
            this.m_cmdQuery.Name = "m_cmdQuery";
            this.m_cmdQuery.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdQuery.Size = new System.Drawing.Size(77, 30);
            this.m_cmdQuery.TabIndex = 55;
            this.m_cmdQuery.Text = "查询(&F)";
            this.m_cmdQuery.Click += new System.EventHandler(this.m_cmdQuery_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "统计时间:  开始";
            // 
            // m_dtpBeginDat
            // 
            this.m_dtpBeginDat.Location = new System.Drawing.Point(127, 12);
            this.m_dtpBeginDat.Name = "m_dtpBeginDat";
            this.m_dtpBeginDat.Size = new System.Drawing.Size(124, 23);
            this.m_dtpBeginDat.TabIndex = 8;
            this.m_dtpBeginDat.Value = new System.DateTime(2007, 1, 1, 0, 0, 0, 0);
            // 
            // m_dtpEndDat
            // 
            this.m_dtpEndDat.Location = new System.Drawing.Point(283, 12);
            this.m_dtpEndDat.Name = "m_dtpEndDat";
            this.m_dtpEndDat.Size = new System.Drawing.Size(125, 23);
            this.m_dtpEndDat.TabIndex = 11;
            this.m_dtpEndDat.Value = new System.DateTime(2007, 4, 2, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(257, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 14);
            this.label3.TabIndex = 12;
            this.label3.Text = "至";
            // 
            // buttonXP3
            // 
            this.buttonXP3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP3.DefaultScheme = true;
            this.buttonXP3.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP3.Hint = "";
            this.buttonXP3.Location = new System.Drawing.Point(772, 10);
            this.buttonXP3.Name = "buttonXP3";
            this.buttonXP3.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP3.Size = new System.Drawing.Size(77, 30);
            this.buttonXP3.TabIndex = 60;
            this.buttonXP3.Text = "导出(&E)";
            this.buttonXP3.Click += new System.EventHandler(this.buttonXP3_Click);
            // 
            // frmReport_DoctorEarningCollect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 561);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmReport_DoctorEarningCollect";
            this.Text = "医生挂号费及诊金汇总表";
            this.Load += new System.EventHandler(this.frmReport_DoctorEarning_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.DateTimePicker m_dtpEndDat;
        internal System.Windows.Forms.DateTimePicker m_dtpBeginDat;
        internal Sybase.DataWindow.DataWindowControl dw_doctorearning;
        private System.Windows.Forms.Panel panel2;
        public PinkieControls.ButtonXP m_cmdQuery;
        public PinkieControls.ButtonXP m_cmdPrint;
        public PinkieControls.ButtonXP buttonXP1;
        public PinkieControls.ButtonXP buttonXP2;
        public PinkieControls.ButtonXP buttonXP3;

    }
}