namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmPayReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayReport));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.EndDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.BeginDate = new System.Windows.Forms.DateTimePicker();
            this.m_btnQuery = new PinkieControls.ButtonXP();
            this.m_btnEsc = new PinkieControls.ButtonXP();
            this.m_btnPrint = new PinkieControls.ButtonXP();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ctlprintShow2 = new com.digitalwave.controls.Control.ctlprintShow();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.EndDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.BeginDate);
            this.groupBox1.Controls.Add(this.m_btnQuery);
            this.groupBox1.Controls.Add(this.m_btnEsc);
            this.groupBox1.Controls.Add(this.m_btnPrint);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(930, 52);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // EndDate
            // 
            this.EndDate.CalendarTitleBackColor = System.Drawing.Color.DimGray;
            this.EndDate.CustomFormat = "yyyy-MM-dd";
            this.EndDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EndDate.Location = new System.Drawing.Point(240, 19);
            this.EndDate.Name = "EndDate";
            this.EndDate.Size = new System.Drawing.Size(132, 23);
            this.EndDate.TabIndex = 60;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(214, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 14);
            this.label2.TabIndex = 59;
            this.label2.Text = "至";
            // 
            // BeginDate
            // 
            this.BeginDate.CalendarTitleBackColor = System.Drawing.Color.DimGray;
            this.BeginDate.CustomFormat = "yyyy-MM-dd";
            this.BeginDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BeginDate.Location = new System.Drawing.Point(78, 19);
            this.BeginDate.Name = "BeginDate";
            this.BeginDate.Size = new System.Drawing.Size(132, 23);
            this.BeginDate.TabIndex = 57;
            // 
            // m_btnQuery
            // 
            this.m_btnQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnQuery.DefaultScheme = true;
            this.m_btnQuery.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnQuery.Hint = "";
            this.m_btnQuery.Location = new System.Drawing.Point(402, 14);
            this.m_btnQuery.Name = "m_btnQuery";
            this.m_btnQuery.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnQuery.Size = new System.Drawing.Size(131, 32);
            this.m_btnQuery.TabIndex = 56;
            this.m_btnQuery.Text = "查询(&Q) ";
            this.m_btnQuery.Click += new System.EventHandler(this.m_btnQuery_Click);
            // 
            // m_btnEsc
            // 
            this.m_btnEsc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnEsc.DefaultScheme = true;
            this.m_btnEsc.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnEsc.Hint = "";
            this.m_btnEsc.Location = new System.Drawing.Point(685, 14);
            this.m_btnEsc.Name = "m_btnEsc";
            this.m_btnEsc.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnEsc.Size = new System.Drawing.Size(131, 32);
            this.m_btnEsc.TabIndex = 55;
            this.m_btnEsc.Text = "退出(&E)";
            this.m_btnEsc.Click += new System.EventHandler(this.m_btnEsc_Click);
            // 
            // m_btnPrint
            // 
            this.m_btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnPrint.DefaultScheme = true;
            this.m_btnPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnPrint.Hint = "";
            this.m_btnPrint.Location = new System.Drawing.Point(544, 14);
            this.m_btnPrint.Name = "m_btnPrint";
            this.m_btnPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnPrint.Size = new System.Drawing.Size(131, 32);
            this.m_btnPrint.TabIndex = 54;
            this.m_btnPrint.Text = "打印(&P)";
            this.m_btnPrint.Click += new System.EventHandler(this.m_btnPrint_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 14);
            this.label1.TabIndex = 58;
            this.label1.Text = "统计日期:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ctlprintShow2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 52);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(930, 668);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // ctlprintShow2
            // 
            this.ctlprintShow2.BackColor = System.Drawing.Color.DimGray;
            this.ctlprintShow2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlprintShow2.Location = new System.Drawing.Point(3, 17);
            this.ctlprintShow2.Name = "ctlprintShow2";
            this.ctlprintShow2.Size = new System.Drawing.Size(924, 648);
            this.ctlprintShow2.TabIndex = 1;
            this.ctlprintShow2.Zoom = 1;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            // 
            // frmPayReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 720);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPayReport";
            this.Text = "收费员日缴款报表";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPayReport_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        internal PinkieControls.ButtonXP m_btnQuery;
        private PinkieControls.ButtonXP m_btnEsc;
        internal PinkieControls.ButtonXP m_btnPrint;
        internal System.Windows.Forms.DateTimePicker BeginDate;
        private System.Windows.Forms.Label label1;
        internal com.digitalwave.controls.Control.ctlprintShow ctlprintShow2;
        private System.Drawing.Printing.PrintDocument printDocument1;
        internal System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.DateTimePicker EndDate;
        private System.Windows.Forms.Label label2;
    }
}