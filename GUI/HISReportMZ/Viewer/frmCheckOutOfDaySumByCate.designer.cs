namespace com.digitalwave.iCare.gui.HIS.Reports
{
    partial class frmCheckOutOfDaySumByCate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCheckOutOfDaySumByCate));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_cbodept = new com.digitalwave.iCare.gui.HIS.exComboBox();
            this.m_cboStatDateType = new System.Windows.Forms.ComboBox();
            this.m_btnPreview = new PinkieControls.ButtonXP();
            this.m_datEndTime = new System.Windows.Forms.DateTimePicker();
            this.labTo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_btnExport = new PinkieControls.ButtonXP();
            this.m_btnStat = new PinkieControls.ButtonXP();
            this.m_cboCheckMan = new com.digitalwave.iCare.gui.HIS.exComboBox();
            this.m_datBeginTime = new System.Windows.Forms.DateTimePicker();
            this.m_btnPrint = new PinkieControls.ButtonXP();
            this.m_btnClose = new PinkieControls.ButtonXP();
            this.label2 = new System.Windows.Forms.Label();
            this.m_dwShow = new Sybase.DataWindow.DataWindowControl();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1028, 61);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_cbodept);
            this.panel2.Controls.Add(this.m_cboStatDateType);
            this.panel2.Controls.Add(this.m_btnPreview);
            this.panel2.Controls.Add(this.m_datEndTime);
            this.panel2.Controls.Add(this.labTo);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.m_btnExport);
            this.panel2.Controls.Add(this.m_btnStat);
            this.panel2.Controls.Add(this.m_cboCheckMan);
            this.panel2.Controls.Add(this.m_datBeginTime);
            this.panel2.Controls.Add(this.m_btnPrint);
            this.panel2.Controls.Add(this.m_btnClose);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1028, 61);
            this.panel2.TabIndex = 1;
            // 
            // m_cbodept
            // 
            this.m_cbodept.FormattingEnabled = true;
            this.m_cbodept.Location = new System.Drawing.Point(562, 19);
            this.m_cbodept.Name = "m_cbodept";
            this.m_cbodept.Size = new System.Drawing.Size(94, 22);
            this.m_cbodept.TabIndex = 40;
            this.m_cbodept.SelectedIndexChanged += new System.EventHandler(this.m_cbodept_SelectedIndexChanged);
            // 
            // m_cboStatDateType
            // 
            this.m_cboStatDateType.BackColor = System.Drawing.SystemColors.Info;
            this.m_cboStatDateType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cboStatDateType.FormattingEnabled = true;
            this.m_cboStatDateType.Items.AddRange(new object[] {
            "按发票时间",
            "按结算时间"});
            this.m_cboStatDateType.Location = new System.Drawing.Point(5, 18);
            this.m_cboStatDateType.Name = "m_cboStatDateType";
            this.m_cboStatDateType.Size = new System.Drawing.Size(92, 22);
            this.m_cboStatDateType.TabIndex = 39;
            // 
            // m_btnPreview
            // 
            this.m_btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnPreview.DefaultScheme = true;
            this.m_btnPreview.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnPreview.Hint = "";
            this.m_btnPreview.Location = new System.Drawing.Point(809, 15);
            this.m_btnPreview.Name = "m_btnPreview";
            this.m_btnPreview.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnPreview.Size = new System.Drawing.Size(70, 31);
            this.m_btnPreview.TabIndex = 38;
            this.m_btnPreview.Text = "预览(&Pre)";
            this.m_btnPreview.Click += new System.EventHandler(this.m_btnPreview_Click);
            // 
            // m_datEndTime
            // 
            this.m_datEndTime.CustomFormat = "yyyy年MM月dd日";
            this.m_datEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_datEndTime.Location = new System.Drawing.Point(265, 19);
            this.m_datEndTime.Name = "m_datEndTime";
            this.m_datEndTime.Size = new System.Drawing.Size(119, 23);
            this.m_datEndTime.TabIndex = 36;
            // 
            // labTo
            // 
            this.labTo.Location = new System.Drawing.Point(244, 24);
            this.labTo.Name = "labTo";
            this.labTo.Size = new System.Drawing.Size(28, 22);
            this.labTo.TabIndex = 35;
            this.labTo.Text = "到";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 14);
            this.label1.TabIndex = 34;
            this.label1.Text = "从";
            // 
            // m_btnExport
            // 
            this.m_btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnExport.DefaultScheme = true;
            this.m_btnExport.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnExport.Hint = "";
            this.m_btnExport.Location = new System.Drawing.Point(882, 15);
            this.m_btnExport.Name = "m_btnExport";
            this.m_btnExport.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnExport.Size = new System.Drawing.Size(70, 31);
            this.m_btnExport.TabIndex = 30;
            this.m_btnExport.Text = "导出(&Exp)";
            this.m_btnExport.Click += new System.EventHandler(this.m_btnExport_Click);
            // 
            // m_btnStat
            // 
            this.m_btnStat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnStat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnStat.DefaultScheme = true;
            this.m_btnStat.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnStat.Hint = "";
            this.m_btnStat.Location = new System.Drawing.Point(664, 15);
            this.m_btnStat.Name = "m_btnStat";
            this.m_btnStat.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnStat.Size = new System.Drawing.Size(70, 31);
            this.m_btnStat.TabIndex = 29;
            this.m_btnStat.Text = "统计(&S)";
            this.m_btnStat.Click += new System.EventHandler(this.m_btnStat_Click);
            // 
            // m_cboCheckMan
            // 
            this.m_cboCheckMan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboCheckMan.Location = new System.Drawing.Point(438, 19);
            this.m_cboCheckMan.Name = "m_cboCheckMan";
            this.m_cboCheckMan.Size = new System.Drawing.Size(118, 22);
            this.m_cboCheckMan.TabIndex = 33;
            // 
            // m_datBeginTime
            // 
            this.m_datBeginTime.CustomFormat = "yyyy年MM月dd日";
            this.m_datBeginTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_datBeginTime.Location = new System.Drawing.Point(118, 19);
            this.m_datBeginTime.Name = "m_datBeginTime";
            this.m_datBeginTime.Size = new System.Drawing.Size(122, 23);
            this.m_datBeginTime.TabIndex = 28;
            // 
            // m_btnPrint
            // 
            this.m_btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnPrint.DefaultScheme = true;
            this.m_btnPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnPrint.Hint = "";
            this.m_btnPrint.Location = new System.Drawing.Point(737, 15);
            this.m_btnPrint.Name = "m_btnPrint";
            this.m_btnPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnPrint.Size = new System.Drawing.Size(70, 31);
            this.m_btnPrint.TabIndex = 31;
            this.m_btnPrint.Text = "打印(&P)";
            this.m_btnPrint.Click += new System.EventHandler(this.m_btnPrint_Click);
            // 
            // m_btnClose
            // 
            this.m_btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnClose.DefaultScheme = true;
            this.m_btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnClose.Hint = "";
            this.m_btnClose.Location = new System.Drawing.Point(953, 15);
            this.m_btnClose.Name = "m_btnClose";
            this.m_btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnClose.Size = new System.Drawing.Size(70, 31);
            this.m_btnClose.TabIndex = 32;
            this.m_btnClose.Text = "关闭(&C)";
            this.m_btnClose.Click += new System.EventHandler(this.m_btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(385, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 37;
            this.label2.Text = "收费员：";
            // 
            // m_dwShow
            // 
            this.m_dwShow.DataWindowObject = "d_op_checkoutofdaysumcate";
            this.m_dwShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dwShow.LibraryList = "D:\\code\\BIN\\Debug\\PB_OP.pbl";
            this.m_dwShow.Location = new System.Drawing.Point(0, 61);
            this.m_dwShow.Name = "m_dwShow";
            this.m_dwShow.Size = new System.Drawing.Size(1028, 342);
            this.m_dwShow.TabIndex = 1;
            this.m_dwShow.Text = "dataWindowControl1";
            // 
            // frmCheckOutOfDaySumByCate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 403);
            this.Controls.Add(this.m_dwShow);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCheckOutOfDaySumByCate";
            this.Text = "收费员分类汇总日报表";
            this.Load += new System.EventHandler(this.frmCheckOutOfDaySumByCate_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.DateTimePicker m_datEndTime;
        internal System.Windows.Forms.Label labTo;
        private System.Windows.Forms.Label label1;
        private PinkieControls.ButtonXP m_btnExport;
        private PinkieControls.ButtonXP m_btnStat;
        internal exComboBox m_cboCheckMan;
        internal System.Windows.Forms.DateTimePicker m_datBeginTime;
        private PinkieControls.ButtonXP m_btnPrint;
        private PinkieControls.ButtonXP m_btnClose;
        private PinkieControls.ButtonXP m_btnPreview;
        public Sybase.DataWindow.DataWindowControl m_dwShow;
        public System.Windows.Forms.ComboBox m_cboStatDateType;
        internal exComboBox m_cbodept;
    }
}