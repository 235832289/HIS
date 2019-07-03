namespace com.digitalwave.iCare.BIHOrder
{
    partial class frmCpStat1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStat = new PinkieControls.ButtonXP();
            this.btnExport = new PinkieControls.ButtonXP();
            this.btnPreview = new PinkieControls.ButtonXP();
            this.btnClose = new PinkieControls.ButtonXP();
            this.btnPrint = new PinkieControls.ButtonXP();
            this.dteBegin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dwRep = new Sybase.DataWindow.DataWindowControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnStat);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnPreview);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.dteBegin);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(987, 45);
            this.panel1.TabIndex = 1;
            // 
            // btnStat
            // 
            this.btnStat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnStat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStat.DefaultScheme = true;
            this.btnStat.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnStat.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStat.Hint = "";
            this.btnStat.Location = new System.Drawing.Point(204, 7);
            this.btnStat.Name = "btnStat";
            this.btnStat.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnStat.Size = new System.Drawing.Size(84, 32);
            this.btnStat.TabIndex = 24;
            this.btnStat.Text = "统计(&S)";
            this.btnStat.Click += new System.EventHandler(this.btnStat_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.DefaultScheme = true;
            this.btnExport.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExport.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExport.Hint = "";
            this.btnExport.Location = new System.Drawing.Point(790, 7);
            this.btnExport.Name = "btnExport";
            this.btnExport.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnExport.Size = new System.Drawing.Size(84, 32);
            this.btnExport.TabIndex = 22;
            this.btnExport.Text = "导出(&E)";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
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
            this.btnPreview.Location = new System.Drawing.Point(694, 7);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnPreview.Size = new System.Drawing.Size(84, 32);
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
            this.btnClose.Location = new System.Drawing.Point(886, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnClose.Size = new System.Drawing.Size(84, 32);
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
            this.btnPrint.Location = new System.Drawing.Point(598, 7);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnPrint.Size = new System.Drawing.Size(84, 32);
            this.btnPrint.TabIndex = 19;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // dteBegin
            // 
            this.dteBegin.CustomFormat = "yyyy年MM月";
            this.dteBegin.Font = new System.Drawing.Font("宋体", 11F);
            this.dteBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dteBegin.Location = new System.Drawing.Point(86, 13);
            this.dteBegin.Name = "dteBegin";
            this.dteBegin.Size = new System.Drawing.Size(105, 24);
            this.dteBegin.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 15;
            this.label1.Text = "统计月份：";
            // 
            // dwRep
            // 
            this.dwRep.DataWindowObject = "";
            this.dwRep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwRep.LibraryList = "";
            this.dwRep.Location = new System.Drawing.Point(0, 45);
            this.dwRep.Name = "dwRep";
            this.dwRep.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwRep.Size = new System.Drawing.Size(987, 550);
            this.dwRep.TabIndex = 2;
            this.dwRep.Text = "dataWindowControl1";
            // 
            // frmCpStat1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 595);
            this.Controls.Add(this.dwRep);
            this.Controls.Add(this.panel1);
            this.Name = "frmCpStat1";
            this.Text = "临床路径全院实施统计报表";
            this.Load += new System.EventHandler(this.frmCpStat1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        internal PinkieControls.ButtonXP btnStat;
        internal PinkieControls.ButtonXP btnExport;
        internal PinkieControls.ButtonXP btnPreview;
        internal PinkieControls.ButtonXP btnClose;
        internal PinkieControls.ButtonXP btnPrint;
        internal System.Windows.Forms.DateTimePicker dteBegin;
        private System.Windows.Forms.Label label1;
        internal Sybase.DataWindow.DataWindowControl dwRep;
    }
}