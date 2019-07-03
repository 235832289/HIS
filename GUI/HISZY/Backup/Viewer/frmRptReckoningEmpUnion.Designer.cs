namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmRptReckoningEmpUnion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptReckoningEmp));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStat = new PinkieControls.ButtonXP();
            this.txtOperCode = new System.Windows.Forms.TextBox();
            this.lblOperCode = new System.Windows.Forms.Label();
            this.btnNoReck = new PinkieControls.ButtonXP();
            this.btnReck = new PinkieControls.ButtonXP();
            this.btnRemark = new PinkieControls.ButtonXP();
            this.btnPreview = new PinkieControls.ButtonXP();
            this.btnClose = new PinkieControls.ButtonXP();
            this.btnPrint = new PinkieControls.ButtonXP();
            this.dteEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dteBegin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvHistory = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.dwRep = new Sybase.DataWindow.DataWindowControl();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnStat);
            this.panel1.Controls.Add(this.txtOperCode);
            this.panel1.Controls.Add(this.lblOperCode);
            this.panel1.Controls.Add(this.btnNoReck);
            this.panel1.Controls.Add(this.btnReck);
            this.panel1.Controls.Add(this.btnRemark);
            this.panel1.Controls.Add(this.btnPreview);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.dteEnd);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dteBegin);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1026, 45);
            this.panel1.TabIndex = 0;
            // 
            // btnStat
            // 
            this.btnStat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnStat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStat.DefaultScheme = true;
            this.btnStat.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnStat.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStat.Hint = "";
            this.btnStat.Location = new System.Drawing.Point(411, 7);
            this.btnStat.Name = "btnStat";
            this.btnStat.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnStat.Size = new System.Drawing.Size(75, 32);
            this.btnStat.TabIndex = 27;
            this.btnStat.Text = "检索(S)";
            this.btnStat.Click += new System.EventHandler(this.btnStat_Click);
            // 
            // txtOperCode
            // 
            this.txtOperCode.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOperCode.Location = new System.Drawing.Point(453, 12);
            this.txtOperCode.Name = "txtOperCode";
            this.txtOperCode.Size = new System.Drawing.Size(58, 26);
            this.txtOperCode.TabIndex = 26;
            // 
            // lblOperCode
            // 
            this.lblOperCode.AutoSize = true;
            this.lblOperCode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOperCode.Location = new System.Drawing.Point(407, 16);
            this.lblOperCode.Name = "lblOperCode";
            this.lblOperCode.Size = new System.Drawing.Size(42, 14);
            this.lblOperCode.TabIndex = 25;
            this.lblOperCode.Text = "工号:";
            // 
            // btnNoReck
            // 
            this.btnNoReck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNoReck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnNoReck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNoReck.DefaultScheme = true;
            this.btnNoReck.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnNoReck.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNoReck.Hint = "";
            this.btnNoReck.Location = new System.Drawing.Point(531, 7);
            this.btnNoReck.Name = "btnNoReck";
            this.btnNoReck.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnNoReck.Size = new System.Drawing.Size(75, 32);
            this.btnNoReck.TabIndex = 24;
            this.btnNoReck.Text = "未结费用";
            this.btnNoReck.Click += new System.EventHandler(this.btnNoReck_Click);
            // 
            // btnReck
            // 
            this.btnReck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnReck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReck.DefaultScheme = true;
            this.btnReck.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnReck.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReck.Hint = "";
            this.btnReck.Location = new System.Drawing.Point(613, 7);
            this.btnReck.Name = "btnReck";
            this.btnReck.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnReck.Size = new System.Drawing.Size(75, 32);
            this.btnReck.TabIndex = 23;
            this.btnReck.Text = "结帐(&K)";
            this.btnReck.Click += new System.EventHandler(this.btnReck_Click);
            // 
            // btnRemark
            // 
            this.btnRemark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnRemark.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemark.DefaultScheme = true;
            this.btnRemark.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnRemark.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRemark.Hint = "";
            this.btnRemark.Location = new System.Drawing.Point(859, 7);
            this.btnRemark.Name = "btnRemark";
            this.btnRemark.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnRemark.Size = new System.Drawing.Size(75, 32);
            this.btnRemark.TabIndex = 22;
            this.btnRemark.Text = "备注(&R)";
            this.btnRemark.Click += new System.EventHandler(this.btnRemark_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnPreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreview.DefaultScheme = true;
            this.btnPreview.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPreview.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPreview.Hint = "";
            this.btnPreview.Location = new System.Drawing.Point(777, 7);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnPreview.Size = new System.Drawing.Size(75, 32);
            this.btnPreview.TabIndex = 21;
            this.btnPreview.Text = "预览(&V)";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
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
            this.btnClose.Location = new System.Drawing.Point(941, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnClose.Size = new System.Drawing.Size(75, 32);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.DefaultScheme = true;
            this.btnPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrint.Hint = "";
            this.btnPrint.Location = new System.Drawing.Point(695, 7);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnPrint.Size = new System.Drawing.Size(75, 32);
            this.btnPrint.TabIndex = 19;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // dteEnd
            // 
            this.dteEnd.CustomFormat = "yyyy年MM月dd日";
            this.dteEnd.Font = new System.Drawing.Font("宋体", 11F);
            this.dteEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dteEnd.Location = new System.Drawing.Point(267, 13);
            this.dteEnd.Name = "dteEnd";
            this.dteEnd.Size = new System.Drawing.Size(133, 24);
            this.dteEnd.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(242, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 17;
            this.label2.Text = "到";
            // 
            // dteBegin
            // 
            this.dteBegin.CustomFormat = "yyyy年MM月dd日";
            this.dteBegin.Font = new System.Drawing.Font("宋体", 11F);
            this.dteBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dteBegin.Location = new System.Drawing.Point(103, 13);
            this.dteBegin.Name = "dteBegin";
            this.dteBegin.Size = new System.Drawing.Size(133, 24);
            this.dteBegin.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 14);
            this.label1.TabIndex = 15;
            this.label1.Text = "结帐日期：从";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1026, 556);
            this.panel2.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvHistory);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.dwRep);
            this.splitContainer1.Size = new System.Drawing.Size(1026, 556);
            this.splitContainer1.SplitterDistance = 201;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 0;
            // 
            // lvHistory
            // 
            this.lvHistory.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvHistory.BackColor = System.Drawing.Color.White;
            this.lvHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvHistory.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lvHistory.FullRowSelect = true;
            this.lvHistory.HideSelection = false;
            this.lvHistory.Location = new System.Drawing.Point(0, 0);
            this.lvHistory.MultiSelect = false;
            this.lvHistory.Name = "lvHistory";
            this.lvHistory.Size = new System.Drawing.Size(201, 556);
            this.lvHistory.TabIndex = 0;
            this.lvHistory.UseCompatibleStateImageBehavior = false;
            this.lvHistory.View = System.Windows.Forms.View.Details;
            this.lvHistory.SelectedIndexChanged += new System.EventHandler(this.lvHistory_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "No";
            this.columnHeader1.Width = 26;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "时间";
            this.columnHeader2.Width = 157;
            // 
            // dwRep
            // 
            this.dwRep.DataWindowObject = "";
            this.dwRep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwRep.LibraryList = "";
            this.dwRep.Location = new System.Drawing.Point(0, 0);
            this.dwRep.Name = "dwRep";
            this.dwRep.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwRep.Size = new System.Drawing.Size(823, 556);
            this.dwRep.TabIndex = 1;
            this.dwRep.Text = "dataWindowControl1";
            // 
            // frmRptReckoningEmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 601);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRptReckoningEmp";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "收费员日结帐报表";
            this.Load += new System.EventHandler(this.frmRptReckoningEmpUnion_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lvHistory;
        internal System.Windows.Forms.DateTimePicker dteEnd;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.DateTimePicker dteBegin;
        private System.Windows.Forms.Label label1;
        internal PinkieControls.ButtonXP btnRemark;
        internal PinkieControls.ButtonXP btnPreview;
        internal PinkieControls.ButtonXP btnClose;
        internal PinkieControls.ButtonXP btnPrint;
        private System.Windows.Forms.SplitContainer splitContainer1;
        internal Sybase.DataWindow.DataWindowControl dwRep;
        internal PinkieControls.ButtonXP btnNoReck;
        internal PinkieControls.ButtonXP btnReck;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        internal System.Windows.Forms.TextBox txtOperCode;
        internal System.Windows.Forms.Label lblOperCode;
        internal PinkieControls.ButtonXP btnStat;
    }
}