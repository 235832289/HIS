namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmPrepayCheckout
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrepayCheckout));
            this.m_prepayPrintDocument = new System.Drawing.Printing.PrintDocument();
            this.m_txtCode = new System.Windows.Forms.TextBox();
            this.m_starDate = new System.Windows.Forms.DateTimePicker();
            this.m_endDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.m_buttonRemark = new PinkieControls.ButtonXP();
            this.m_buttonBuild = new PinkieControls.ButtonXP();
            this.m_buttonCheckout = new PinkieControls.ButtonXP();
            this.m_buttonPrint = new PinkieControls.ButtonXP();
            this.m_buttonExit = new PinkieControls.ButtonXP();
            this.m_ctlprintShow = new com.digitalwave.controls.Control.ctlprintShow();
            this.label2 = new System.Windows.Forms.Label();
            this.m_HisDataGridView = new System.Windows.Forms.DataGridView();
            this.BALANCE_DAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BALANCEID_VCHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_lbCode = new System.Windows.Forms.Label();
            this.m_cmdDetail = new PinkieControls.ButtonXP();
            this.m_dwDetail = new Sybase.DataWindow.DataWindowControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.m_HisDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_prepayPrintDocument
            // 
            this.m_prepayPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.m_prepayPrintDocument_PrintPage);
            this.m_prepayPrintDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.m_prepayPrintDocument_BeginPrint);
            // 
            // m_txtCode
            // 
            this.m_txtCode.Location = new System.Drawing.Point(413, 17);
            this.m_txtCode.Name = "m_txtCode";
            this.m_txtCode.Size = new System.Drawing.Size(100, 21);
            this.m_txtCode.TabIndex = 18;
            this.m_txtCode.Visible = false;
            // 
            // m_starDate
            // 
            this.m_starDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_starDate.Location = new System.Drawing.Point(52, 17);
            this.m_starDate.Name = "m_starDate";
            this.m_starDate.Size = new System.Drawing.Size(120, 23);
            this.m_starDate.TabIndex = 5;
            this.m_starDate.ValueChanged += new System.EventHandler(this.m_starDate_ValueChanged);
            // 
            // m_endDate
            // 
            this.m_endDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_endDate.Location = new System.Drawing.Point(201, 17);
            this.m_endDate.Name = "m_endDate";
            this.m_endDate.Size = new System.Drawing.Size(120, 23);
            this.m_endDate.TabIndex = 6;
            this.m_endDate.ValueChanged += new System.EventHandler(this.m_endDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(177, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 14);
            this.label1.TabIndex = 16;
            this.label1.Text = "至";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_buttonRemark
            // 
            this.m_buttonRemark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_buttonRemark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_buttonRemark.DefaultScheme = true;
            this.m_buttonRemark.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_buttonRemark.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_buttonRemark.Hint = "";
            this.m_buttonRemark.Location = new System.Drawing.Point(736, 12);
            this.m_buttonRemark.Name = "m_buttonRemark";
            this.m_buttonRemark.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_buttonRemark.Size = new System.Drawing.Size(72, 32);
            this.m_buttonRemark.TabIndex = 15;
            this.m_buttonRemark.Text = "备注(&R)";
            this.m_buttonRemark.Click += new System.EventHandler(this.m_buttonRemark_Click);
            // 
            // m_buttonBuild
            // 
            this.m_buttonBuild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_buttonBuild.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_buttonBuild.DefaultScheme = true;
            this.m_buttonBuild.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_buttonBuild.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_buttonBuild.Hint = "";
            this.m_buttonBuild.Location = new System.Drawing.Point(514, 12);
            this.m_buttonBuild.Name = "m_buttonBuild";
            this.m_buttonBuild.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_buttonBuild.Size = new System.Drawing.Size(72, 32);
            this.m_buttonBuild.TabIndex = 14;
            this.m_buttonBuild.Text = "生成(&B)";
            this.m_buttonBuild.Click += new System.EventHandler(this.m_buttonBuild_Click);
            // 
            // m_buttonCheckout
            // 
            this.m_buttonCheckout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_buttonCheckout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_buttonCheckout.DefaultScheme = true;
            this.m_buttonCheckout.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_buttonCheckout.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_buttonCheckout.Hint = "";
            this.m_buttonCheckout.Location = new System.Drawing.Point(588, 12);
            this.m_buttonCheckout.Name = "m_buttonCheckout";
            this.m_buttonCheckout.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_buttonCheckout.Size = new System.Drawing.Size(72, 32);
            this.m_buttonCheckout.TabIndex = 13;
            this.m_buttonCheckout.Text = "结帐(&C)";
            this.m_buttonCheckout.Click += new System.EventHandler(this.m_buttonCheckout_Click);
            // 
            // m_buttonPrint
            // 
            this.m_buttonPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_buttonPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_buttonPrint.DefaultScheme = true;
            this.m_buttonPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_buttonPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_buttonPrint.Hint = "";
            this.m_buttonPrint.Location = new System.Drawing.Point(810, 12);
            this.m_buttonPrint.Name = "m_buttonPrint";
            this.m_buttonPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_buttonPrint.Size = new System.Drawing.Size(72, 32);
            this.m_buttonPrint.TabIndex = 12;
            this.m_buttonPrint.Text = "打印(&P)";
            this.m_buttonPrint.Click += new System.EventHandler(this.m_buttonPrint_Click);
            // 
            // m_buttonExit
            // 
            this.m_buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_buttonExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_buttonExit.DefaultScheme = true;
            this.m_buttonExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_buttonExit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_buttonExit.Hint = "";
            this.m_buttonExit.Location = new System.Drawing.Point(884, 12);
            this.m_buttonExit.Name = "m_buttonExit";
            this.m_buttonExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_buttonExit.Size = new System.Drawing.Size(72, 32);
            this.m_buttonExit.TabIndex = 11;
            this.m_buttonExit.Text = "退出(&E)";
            this.m_buttonExit.Click += new System.EventHandler(this.m_buttonExit_Click);
            // 
            // m_ctlprintShow
            // 
            this.m_ctlprintShow.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.m_ctlprintShow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_ctlprintShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_ctlprintShow.Location = new System.Drawing.Point(240, 0);
            this.m_ctlprintShow.Name = "m_ctlprintShow";
            this.m_ctlprintShow.Size = new System.Drawing.Size(720, 559);
            this.m_ctlprintShow.TabIndex = 10;
            this.m_ctlprintShow.Zoom = 1;
            this.m_ctlprintShow.Click += new System.EventHandler(this.m_ctlprintShow_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(8, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "日期：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_HisDataGridView
            // 
            this.m_HisDataGridView.AllowUserToAddRows = false;
            this.m_HisDataGridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.m_HisDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_HisDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.m_HisDataGridView.ColumnHeadersHeight = 28;
            this.m_HisDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BALANCE_DAT,
            this.BALANCEID_VCHR});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.m_HisDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.m_HisDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_HisDataGridView.Location = new System.Drawing.Point(0, 0);
            this.m_HisDataGridView.MultiSelect = false;
            this.m_HisDataGridView.Name = "m_HisDataGridView";
            this.m_HisDataGridView.ReadOnly = true;
            this.m_HisDataGridView.RowTemplate.Height = 23;
            this.m_HisDataGridView.Size = new System.Drawing.Size(240, 559);
            this.m_HisDataGridView.TabIndex = 0;
            this.m_HisDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_HisDataGridView_CellClick);
            // 
            // BALANCE_DAT
            // 
            this.BALANCE_DAT.HeaderText = "结算日期";
            this.BALANCE_DAT.Name = "BALANCE_DAT";
            this.BALANCE_DAT.ReadOnly = true;
            this.BALANCE_DAT.Width = 180;
            // 
            // BALANCEID_VCHR
            // 
            this.BALANCEID_VCHR.HeaderText = "结算流水号";
            this.BALANCEID_VCHR.Name = "BALANCEID_VCHR";
            this.BALANCEID_VCHR.ReadOnly = true;
            this.BALANCEID_VCHR.Visible = false;
            // 
            // m_lbCode
            // 
            this.m_lbCode.AutoSize = true;
            this.m_lbCode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lbCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_lbCode.Location = new System.Drawing.Point(325, 20);
            this.m_lbCode.Name = "m_lbCode";
            this.m_lbCode.Size = new System.Drawing.Size(91, 14);
            this.m_lbCode.TabIndex = 17;
            this.m_lbCode.Text = "收费员工号：";
            this.m_lbCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.m_lbCode.Visible = false;
            // 
            // m_cmdDetail
            // 
            this.m_cmdDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdDetail.DefaultScheme = true;
            this.m_cmdDetail.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdDetail.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdDetail.Hint = "";
            this.m_cmdDetail.Location = new System.Drawing.Point(662, 12);
            this.m_cmdDetail.Name = "m_cmdDetail";
            this.m_cmdDetail.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDetail.Size = new System.Drawing.Size(72, 32);
            this.m_cmdDetail.TabIndex = 20;
            this.m_cmdDetail.Text = "查看明细";
            this.m_cmdDetail.Click += new System.EventHandler(this.m_cmdDetail_Click);
            // 
            // m_dwDetail
            // 
            this.m_dwDetail.DataWindowObject = "";
            this.m_dwDetail.LibraryList = "D:\\dev\\icare_ver2\\Code\\bin\\Debug\\pb_new.pbl";
            this.m_dwDetail.Location = new System.Drawing.Point(185, 495);
            this.m_dwDetail.Name = "m_dwDetail";
            this.m_dwDetail.Size = new System.Drawing.Size(106, 98);
            this.m_dwDetail.TabIndex = 21;
            this.m_dwDetail.Text = "dataWindowControl1";
            this.m_dwDetail.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_starDate);
            this.panel1.Controls.Add(this.m_endDate);
            this.panel1.Controls.Add(this.m_txtCode);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.m_cmdDetail);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.m_buttonRemark);
            this.panel1.Controls.Add(this.m_buttonBuild);
            this.panel1.Controls.Add(this.m_buttonCheckout);
            this.panel1.Controls.Add(this.m_buttonPrint);
            this.panel1.Controls.Add(this.m_buttonExit);
            this.panel1.Controls.Add(this.m_lbCode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 52);
            this.panel1.TabIndex = 22;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_ctlprintShow);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(960, 559);
            this.panel2.TabIndex = 23;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.m_HisDataGridView);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(240, 559);
            this.panel3.TabIndex = 0;
            // 
            // frmPrepayCheckout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 611);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_dwDetail);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPrepayCheckout";
            this.Text = "收款员住院预交金日结";
            this.Load += new System.EventHandler(this.frmPrepayCheckout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_HisDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.DateTimePicker m_endDate;
        internal System.Windows.Forms.DateTimePicker m_starDate;
        private PinkieControls.ButtonXP m_buttonExit;
        internal System.Drawing.Printing.PrintDocument m_prepayPrintDocument;
        internal System.Windows.Forms.DataGridView m_HisDataGridView;
        internal PinkieControls.ButtonXP m_buttonBuild;
        internal PinkieControls.ButtonXP m_buttonCheckout;
        private System.Windows.Forms.DataGridViewTextBoxColumn BALANCE_DAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn BALANCEID_VCHR;
        internal com.digitalwave.controls.Control.ctlprintShow m_ctlprintShow;
        internal PinkieControls.ButtonXP m_buttonPrint;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label m_lbCode;
        internal System.Windows.Forms.TextBox m_txtCode;
        internal PinkieControls.ButtonXP m_cmdDetail;
        internal Sybase.DataWindow.DataWindowControl m_dwDetail;
        internal PinkieControls.ButtonXP m_buttonRemark;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}