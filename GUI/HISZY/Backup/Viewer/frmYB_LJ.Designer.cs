namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmYB_LJ
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmYB_LJ));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUpload = new PinkieControls.ButtonXP();
            this.txtZyh = new System.Windows.Forms.TextBox();
            this.btnExport = new PinkieControls.ButtonXP();
            this.btnClose = new PinkieControls.ButtonXP();
            this.btnPrint = new PinkieControls.ButtonXP();
            this.btnStat = new PinkieControls.ButtonXP();
            this.txtInvoNo = new System.Windows.Forms.TextBox();
            this.rdoZy = new System.Windows.Forms.RadioButton();
            this.rdoMz = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dwRep = new Sybase.DataWindow.DataWindowControl();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnUpload);
            this.panel1.Controls.Add(this.txtZyh);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnStat);
            this.panel1.Controls.Add(this.txtInvoNo);
            this.panel1.Controls.Add(this.rdoZy);
            this.panel1.Controls.Add(this.rdoMz);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(994, 42);
            this.panel1.TabIndex = 0;
            // 
            // btnUpload
            // 
            this.btnUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnUpload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpload.DefaultScheme = true;
            this.btnUpload.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnUpload.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUpload.Hint = "";
            this.btnUpload.Location = new System.Drawing.Point(641, 5);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnUpload.Size = new System.Drawing.Size(84, 32);
            this.btnUpload.TabIndex = 22;
            this.btnUpload.Text = "上传(&U)";
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // txtZyh
            // 
            this.txtZyh.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtZyh.Location = new System.Drawing.Point(370, 9);
            this.txtZyh.MaxLength = 8;
            this.txtZyh.Name = "txtZyh";
            this.txtZyh.Size = new System.Drawing.Size(109, 26);
            this.txtZyh.TabIndex = 21;
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
            this.btnExport.Location = new System.Drawing.Point(813, 5);
            this.btnExport.Name = "btnExport";
            this.btnExport.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnExport.Size = new System.Drawing.Size(84, 32);
            this.btnExport.TabIndex = 20;
            this.btnExport.Text = "导出(&E)";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
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
            this.btnClose.Location = new System.Drawing.Point(899, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnClose.Size = new System.Drawing.Size(84, 32);
            this.btnClose.TabIndex = 18;
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
            this.btnPrint.Location = new System.Drawing.Point(727, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnPrint.Size = new System.Drawing.Size(84, 32);
            this.btnPrint.TabIndex = 17;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnStat
            // 
            this.btnStat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnStat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStat.DefaultScheme = true;
            this.btnStat.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnStat.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStat.Hint = "";
            this.btnStat.Location = new System.Drawing.Point(489, 5);
            this.btnStat.Name = "btnStat";
            this.btnStat.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnStat.Size = new System.Drawing.Size(84, 32);
            this.btnStat.TabIndex = 16;
            this.btnStat.Text = "查找(&S)";
            this.btnStat.Click += new System.EventHandler(this.btnStat_Click);
            // 
            // txtInvoNo
            // 
            this.txtInvoNo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.txtInvoNo.Location = new System.Drawing.Point(131, 9);
            this.txtInvoNo.MaxLength = 10;
            this.txtInvoNo.Name = "txtInvoNo";
            this.txtInvoNo.Size = new System.Drawing.Size(109, 26);
            this.txtInvoNo.TabIndex = 2;
            // 
            // rdoZy
            // 
            this.rdoZy.AutoSize = true;
            this.rdoZy.Location = new System.Drawing.Point(252, 11);
            this.rdoZy.Name = "rdoZy";
            this.rdoZy.Size = new System.Drawing.Size(116, 18);
            this.rdoZy.TabIndex = 1;
            this.rdoZy.Text = "住院(住院号):";
            this.rdoZy.UseVisualStyleBackColor = true;
            this.rdoZy.CheckedChanged += new System.EventHandler(this.rdoZy_CheckedChanged);
            // 
            // rdoMz
            // 
            this.rdoMz.AutoSize = true;
            this.rdoMz.Checked = true;
            this.rdoMz.Location = new System.Drawing.Point(13, 11);
            this.rdoMz.Name = "rdoMz";
            this.rdoMz.Size = new System.Drawing.Size(116, 18);
            this.rdoMz.TabIndex = 0;
            this.rdoMz.TabStop = true;
            this.rdoMz.Text = "门诊(发票号):";
            this.rdoMz.UseVisualStyleBackColor = true;
            this.rdoMz.CheckedChanged += new System.EventHandler(this.rdoMz_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.dwRep);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(994, 467);
            this.panel2.TabIndex = 1;
            // 
            // dwRep
            // 
            this.dwRep.BorderStyle = Sybase.DataWindow.DataWindowBorderStyle.None;
            this.dwRep.DataWindowObject = "d_bih_sdyb";
            this.dwRep.Dock = System.Windows.Forms.DockStyle.Right;
            this.dwRep.LibraryList = "D:\\ICARE_VER2005\\Code\\bin\\Debug\\pbreport.pbl";
            this.dwRep.Location = new System.Drawing.Point(80, 0);
            this.dwRep.Name = "dwRep";
            this.dwRep.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwRep.Size = new System.Drawing.Size(910, 463);
            this.dwRep.TabIndex = 1;
            this.dwRep.Text = "dataWindowControl1";
            // 
            // frmYB_LJ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 509);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmYB_LJ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "门诊、住院医保费用上传窗口";
            this.Load += new System.EventHandler(this.frmYB_LJ_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdoZy;
        private System.Windows.Forms.RadioButton rdoMz;
        internal Sybase.DataWindow.DataWindowControl dwRep;
        private System.Windows.Forms.TextBox txtInvoNo;
        internal PinkieControls.ButtonXP btnExport;
        internal PinkieControls.ButtonXP btnClose;
        internal PinkieControls.ButtonXP btnPrint;
        internal PinkieControls.ButtonXP btnStat;
        private System.Windows.Forms.TextBox txtZyh;
        internal PinkieControls.ButtonXP btnUpload;
    }
}