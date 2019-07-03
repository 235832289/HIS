namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmPrepayBalanceReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrepayBalanceReport));
            this.m_btnExit = new PinkieControls.ButtonXP();
            this.m_buttunQuery = new PinkieControls.ButtonXP();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_endDate = new System.Windows.Forms.DateTimePicker();
            this.m_startDate = new System.Windows.Forms.DateTimePicker();
            this.m_buttonPrint = new PinkieControls.ButtonXP();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dwResult = new Sybase.DataWindow.DataWindowControl();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnExit
            // 
            this.m_btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnExit.DefaultScheme = true;
            this.m_btnExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnExit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnExit.Hint = "";
            this.m_btnExit.Location = new System.Drawing.Point(693, 5);
            this.m_btnExit.Name = "m_btnExit";
            this.m_btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnExit.Size = new System.Drawing.Size(79, 34);
            this.m_btnExit.TabIndex = 68;
            this.m_btnExit.Text = "退出(&E)";
            this.m_btnExit.Click += new System.EventHandler(this.m_btnExit_Click);
            // 
            // m_buttunQuery
            // 
            this.m_buttunQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_buttunQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_buttunQuery.DefaultScheme = true;
            this.m_buttunQuery.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_buttunQuery.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_buttunQuery.Hint = "";
            this.m_buttunQuery.Location = new System.Drawing.Point(463, 5);
            this.m_buttunQuery.Name = "m_buttunQuery";
            this.m_buttunQuery.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_buttunQuery.Size = new System.Drawing.Size(79, 34);
            this.m_buttunQuery.TabIndex = 67;
            this.m_buttunQuery.Tag = "";
            this.m_buttunQuery.Text = "查询(&S)";
            this.m_buttunQuery.Click += new System.EventHandler(this.m_buttunQuery_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(225, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 14);
            this.label1.TabIndex = 70;
            this.label1.Text = "至";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(20, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 69;
            this.label2.Text = "选择日期:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_endDate
            // 
            this.m_endDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_endDate.Location = new System.Drawing.Point(249, 9);
            this.m_endDate.Name = "m_endDate";
            this.m_endDate.Size = new System.Drawing.Size(128, 23);
            this.m_endDate.TabIndex = 73;
            this.m_endDate.Tag = "";
            // 
            // m_startDate
            // 
            this.m_startDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_startDate.Location = new System.Drawing.Point(93, 9);
            this.m_startDate.Name = "m_startDate";
            this.m_startDate.Size = new System.Drawing.Size(128, 23);
            this.m_startDate.TabIndex = 72;
            this.m_startDate.Tag = "";
            // 
            // m_buttonPrint
            // 
            this.m_buttonPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_buttonPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_buttonPrint.DefaultScheme = true;
            this.m_buttonPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_buttonPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_buttonPrint.Hint = "";
            this.m_buttonPrint.Location = new System.Drawing.Point(578, 5);
            this.m_buttonPrint.Name = "m_buttonPrint";
            this.m_buttonPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_buttonPrint.Size = new System.Drawing.Size(79, 34);
            this.m_buttonPrint.TabIndex = 74;
            this.m_buttonPrint.Tag = "";
            this.m_buttonPrint.Text = "打印(&P)";
            this.m_buttonPrint.Click += new System.EventHandler(this.m_buttonPrint_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_buttunQuery);
            this.panel1.Controls.Add(this.m_buttonPrint);
            this.panel1.Controls.Add(this.m_btnExit);
            this.panel1.Controls.Add(this.m_endDate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.m_startDate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(782, 45);
            this.panel1.TabIndex = 75;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.dwResult);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(782, 520);
            this.panel2.TabIndex = 76;
            // 
            // dwResult
            // 
            this.dwResult.BorderStyle = Sybase.DataWindow.DataWindowBorderStyle.None;
            this.dwResult.DataWindowObject = "";
            this.dwResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwResult.Icon = ((System.Drawing.Icon)(resources.GetObject("dwResult.Icon")));
            this.dwResult.LibraryList = "";
            this.dwResult.Location = new System.Drawing.Point(0, 0);
            this.dwResult.Name = "dwResult";
            this.dwResult.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwResult.Size = new System.Drawing.Size(778, 516);
            this.dwResult.TabIndex = 1;
            // 
            // frmPrepayBalanceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 565);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmPrepayBalanceReport";
            this.Text = "全院预收款日结报表";
            this.Load += new System.EventHandler(this.frmPrepayReportMonth_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal PinkieControls.ButtonXP m_btnExit;
        internal PinkieControls.ButtonXP m_buttunQuery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.DateTimePicker m_endDate;
        internal System.Windows.Forms.DateTimePicker m_startDate;
        internal PinkieControls.ButtonXP m_buttonPrint;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        internal Sybase.DataWindow.DataWindowControl dwResult;
    }
}