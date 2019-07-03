namespace com.digitalwave.iCare.gui.LIS
{
    partial class frmDeviceCheckStatis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDeviceCheckStatis));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPreview = new PinkieControls.ButtonXP();
            this.btnPrint = new PinkieControls.ButtonXP();
            this.m_dtpEndDat = new System.Windows.Forms.DateTimePicker();
            this.m_dtpStartDat = new System.Windows.Forms.DateTimePicker();
            this.m_cboStatisType = new System.Windows.Forms.ComboBox();
            this.btnClose = new PinkieControls.ButtonXP();
            this.btnQuery = new PinkieControls.ButtonXP();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dwReport = new Sybase.DataWindow.DataWindowControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnPreview);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.m_dtpEndDat);
            this.panel1.Controls.Add(this.m_dtpStartDat);
            this.panel1.Controls.Add(this.m_cboStatisType);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnQuery);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1010, 79);
            this.panel1.TabIndex = 0;
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnPreview.DefaultScheme = true;
            this.btnPreview.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPreview.Hint = "";
            this.btnPreview.Location = new System.Drawing.Point(778, 41);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Scheme = PinkieControls.ButtonXP.Schemes.Silver;
            this.btnPreview.Size = new System.Drawing.Size(93, 33);
            this.btnPreview.TabIndex = 10;
            this.btnPreview.Text = "预览(&V)";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnPrint.DefaultScheme = true;
            this.btnPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPrint.Hint = "";
            this.btnPrint.Location = new System.Drawing.Point(896, 6);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Scheme = PinkieControls.ButtonXP.Schemes.Silver;
            this.btnPrint.Size = new System.Drawing.Size(93, 33);
            this.btnPrint.TabIndex = 9;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // m_dtpEndDat
            // 
            this.m_dtpEndDat.AccessibleName = "11";
            this.m_dtpEndDat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_dtpEndDat.Location = new System.Drawing.Point(590, 29);
            this.m_dtpEndDat.Name = "m_dtpEndDat";
            this.m_dtpEndDat.Size = new System.Drawing.Size(141, 23);
            this.m_dtpEndDat.TabIndex = 6;
            // 
            // m_dtpStartDat
            // 
            this.m_dtpStartDat.AccessibleName = "11";
            this.m_dtpStartDat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_dtpStartDat.Location = new System.Drawing.Point(365, 29);
            this.m_dtpStartDat.Name = "m_dtpStartDat";
            this.m_dtpStartDat.Size = new System.Drawing.Size(141, 23);
            this.m_dtpStartDat.TabIndex = 4;
            // 
            // m_cboStatisType
            // 
            this.m_cboStatisType.AccessibleName = "11";
            this.m_cboStatisType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cboStatisType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboStatisType.FormattingEnabled = true;
            this.m_cboStatisType.Items.AddRange(new object[] {
            "仪器工作量统计"});
            this.m_cboStatisType.Location = new System.Drawing.Point(93, 29);
            this.m_cboStatisType.Name = "m_cboStatisType";
            this.m_cboStatisType.Size = new System.Drawing.Size(188, 22);
            this.m_cboStatisType.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnClose.DefaultScheme = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClose.Hint = "";
            this.btnClose.Location = new System.Drawing.Point(896, 41);
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Silver;
            this.btnClose.Size = new System.Drawing.Size(93, 33);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnQuery.DefaultScheme = true;
            this.btnQuery.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnQuery.Hint = "";
            this.btnQuery.Location = new System.Drawing.Point(778, 6);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Scheme = PinkieControls.ButtonXP.Schemes.Silver;
            this.btnQuery.Size = new System.Drawing.Size(93, 33);
            this.btnQuery.TabIndex = 7;
            this.btnQuery.Text = "查询(&F)";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(521, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 5;
            this.label4.Text = "结束日期";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(296, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "开始日期";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "统计报表";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1010, 79);
            this.label1.TabIndex = 0;
            // 
            // dwReport
            // 
            this.dwReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dwReport.DataWindowObject = "";
            this.dwReport.Icon = ((System.Drawing.Icon)(resources.GetObject("dwReport.Icon")));
            this.dwReport.LibraryList = "";
            this.dwReport.Location = new System.Drawing.Point(1, 83);
            this.dwReport.Name = "dwReport";
            this.dwReport.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwReport.Size = new System.Drawing.Size(1010, 549);
            this.dwReport.TabIndex = 1;
            // 
            // frmDeviceCheckStatis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1012, 632);
            this.Controls.Add(this.dwReport);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmDeviceCheckStatis";
            this.Text = "仪器工作量统计";
            this.Load += new System.EventHandler(this.frmDeviceCheckStatis_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker m_dtpEndDat;
        private System.Windows.Forms.DateTimePicker m_dtpStartDat;
        private PinkieControls.ButtonXP btnClose;
        private PinkieControls.ButtonXP btnQuery;
        internal Sybase.DataWindow.DataWindowControl dwReport;
        internal System.Windows.Forms.ComboBox m_cboStatisType;
        private PinkieControls.ButtonXP btnPrint;
        private PinkieControls.ButtonXP btnPreview;
    }
}