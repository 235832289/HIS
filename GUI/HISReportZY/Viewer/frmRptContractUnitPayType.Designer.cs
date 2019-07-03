namespace com.digitalwave.iCare.gui.HIS.Reports
{
    partial class frmRptContractUnitPayType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptContractUnitPayType));
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.m_dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_cmdSelect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.m_cmdExeport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.m_cmdPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_cmdExit = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_dwreport = new Sybase.DataWindow.DataWindowControl();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_dtpEndDate);
            this.panel1.Controls.Add(this.m_dtpStartDate);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(877, 45);
            this.panel1.TabIndex = 0;
            // 
            // m_dtpEndDate
            // 
            this.m_dtpEndDate.Location = new System.Drawing.Point(227, 14);
            this.m_dtpEndDate.Name = "m_dtpEndDate";
            this.m_dtpEndDate.Size = new System.Drawing.Size(122, 23);
            this.m_dtpEndDate.TabIndex = 2;
            // 
            // m_dtpStartDate
            // 
            this.m_dtpStartDate.Location = new System.Drawing.Point(82, 14);
            this.m_dtpStartDate.Name = "m_dtpStartDate";
            this.m_dtpStartDate.Size = new System.Drawing.Size(122, 23);
            this.m_dtpStartDate.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.m_cmdSelect,
            this.toolStripSeparator3,
            this.m_cmdExeport,
            this.toolStripSeparator4,
            this.m_cmdPrint,
            this.toolStripSeparator2,
            this.m_cmdExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(877, 45);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.AutoSize = false;
            this.toolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(350, 44);
            this.toolStripLabel1.Text = "入院日期：                       至";
            this.toolStripLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 45);
            // 
            // m_cmdSelect
            // 
            this.m_cmdSelect.AutoSize = false;
            this.m_cmdSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_cmdSelect.Font = new System.Drawing.Font("宋体", 10F);
            this.m_cmdSelect.Image = ((System.Drawing.Image)(resources.GetObject("m_cmdSelect.Image")));
            this.m_cmdSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_cmdSelect.Name = "m_cmdSelect";
            this.m_cmdSelect.Size = new System.Drawing.Size(70, 44);
            this.m_cmdSelect.Text = "查询(&S)";
            this.m_cmdSelect.Click += new System.EventHandler(this.m_cmdSelect_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 45);
            // 
            // m_cmdExeport
            // 
            this.m_cmdExeport.AutoSize = false;
            this.m_cmdExeport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_cmdExeport.Font = new System.Drawing.Font("宋体", 10F);
            this.m_cmdExeport.Image = ((System.Drawing.Image)(resources.GetObject("m_cmdExeport.Image")));
            this.m_cmdExeport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_cmdExeport.Name = "m_cmdExeport";
            this.m_cmdExeport.Size = new System.Drawing.Size(70, 44);
            this.m_cmdExeport.Text = "导出(&E)";
            this.m_cmdExeport.Click += new System.EventHandler(this.m_cmdExeport_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 45);
            // 
            // m_cmdPrint
            // 
            this.m_cmdPrint.AutoSize = false;
            this.m_cmdPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_cmdPrint.Font = new System.Drawing.Font("宋体", 10F);
            this.m_cmdPrint.Image = ((System.Drawing.Image)(resources.GetObject("m_cmdPrint.Image")));
            this.m_cmdPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_cmdPrint.Name = "m_cmdPrint";
            this.m_cmdPrint.Size = new System.Drawing.Size(70, 44);
            this.m_cmdPrint.Text = "打印(&P)";
            this.m_cmdPrint.Click += new System.EventHandler(this.m_cmdPrint_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 45);
            // 
            // m_cmdExit
            // 
            this.m_cmdExit.AutoSize = false;
            this.m_cmdExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_cmdExit.Font = new System.Drawing.Font("宋体", 10F);
            this.m_cmdExit.Image = ((System.Drawing.Image)(resources.GetObject("m_cmdExit.Image")));
            this.m_cmdExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_cmdExit.Name = "m_cmdExit";
            this.m_cmdExit.Size = new System.Drawing.Size(70, 44);
            this.m_cmdExit.Text = "退出(&C)";
            this.m_cmdExit.Click += new System.EventHandler(this.m_cmdExit_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_dwreport);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(877, 434);
            this.panel2.TabIndex = 1;
            // 
            // m_dwreport
            // 
            this.m_dwreport.BorderStyle = Sybase.DataWindow.DataWindowBorderStyle.None;
            this.m_dwreport.DataWindowObject = "";
            this.m_dwreport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dwreport.LibraryList = "";
            this.m_dwreport.Location = new System.Drawing.Point(0, 0);
            this.m_dwreport.Name = "m_dwreport";
            this.m_dwreport.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.m_dwreport.Size = new System.Drawing.Size(877, 434);
            this.m_dwreport.TabIndex = 1;
            this.m_dwreport.Text = "dataWindowControl1";
            // 
            // frmRptContractUnitPayType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 479);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRptContractUnitPayType";
            this.Text = "住院协议单位查询统计报表";
            this.Load += new System.EventHandler(this.frmRptContractUnitPayType_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton m_cmdExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        internal System.Windows.Forms.DateTimePicker m_dtpStartDate;
        internal System.Windows.Forms.DateTimePicker m_dtpEndDate;
        internal System.Windows.Forms.ToolStripButton m_cmdSelect;
        internal System.Windows.Forms.ToolStripButton m_cmdExeport;
        internal System.Windows.Forms.ToolStripButton m_cmdPrint;
        internal Sybase.DataWindow.DataWindowControl m_dwreport;
    }
}