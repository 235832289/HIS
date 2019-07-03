namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmQueryNavigator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQueryNavigator));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.m_btnFirst = new System.Windows.Forms.ToolStripButton();
            this.m_btnPrev = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_txtMedicine = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnNext = new System.Windows.Forms.ToolStripButton();
            this.m_btnLast = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnClose = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 10.5F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_btnFirst,
            this.m_btnPrev,
            this.toolStripSeparator1,
            this.m_txtMedicine,
            this.toolStripSeparator2,
            this.m_btnNext,
            this.m_btnLast,
            this.toolStripSeparator3,
            this.m_btnClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(344, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // m_btnFirst
            // 
            this.m_btnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_btnFirst.Image = ((System.Drawing.Image)(resources.GetObject("m_btnFirst.Image")));
            this.m_btnFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_btnFirst.Name = "m_btnFirst";
            this.m_btnFirst.Size = new System.Drawing.Size(23, 22);
            this.m_btnFirst.ToolTipText = "最前一个";
            this.m_btnFirst.Click += new System.EventHandler(this.m_btnFirst_Click);
            // 
            // m_btnPrev
            // 
            this.m_btnPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_btnPrev.Image = ((System.Drawing.Image)(resources.GetObject("m_btnPrev.Image")));
            this.m_btnPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_btnPrev.Name = "m_btnPrev";
            this.m_btnPrev.Size = new System.Drawing.Size(23, 22);
            this.m_btnPrev.ToolTipText = "前一个";
            this.m_btnPrev.Click += new System.EventHandler(this.m_btnPrev_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // m_txtMedicine
            // 
            this.m_txtMedicine.BackColor = System.Drawing.Color.OldLace;
            this.m_txtMedicine.Font = new System.Drawing.Font("Tahoma", 10.5F);
            this.m_txtMedicine.Name = "m_txtMedicine";
            this.m_txtMedicine.Size = new System.Drawing.Size(200, 25);
            this.m_txtMedicine.ToolTipText = "根据药品代码、名称、拼音码、五笔码进行筛选";
            this.m_txtMedicine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtMedicine_KeyDown);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // m_btnNext
            // 
            this.m_btnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_btnNext.Image = ((System.Drawing.Image)(resources.GetObject("m_btnNext.Image")));
            this.m_btnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_btnNext.Name = "m_btnNext";
            this.m_btnNext.Size = new System.Drawing.Size(23, 22);
            this.m_btnNext.ToolTipText = "后一个";
            this.m_btnNext.Click += new System.EventHandler(this.m_btnNext_Click);
            // 
            // m_btnLast
            // 
            this.m_btnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_btnLast.Image = ((System.Drawing.Image)(resources.GetObject("m_btnLast.Image")));
            this.m_btnLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_btnLast.Name = "m_btnLast";
            this.m_btnLast.Size = new System.Drawing.Size(23, 22);
            this.m_btnLast.ToolTipText = "最后一个";
            this.m_btnLast.Click += new System.EventHandler(this.m_btnLast_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // m_btnClose
            // 
            this.m_btnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_btnClose.Image = ((System.Drawing.Image)(resources.GetObject("m_btnClose.Image")));
            this.m_btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_btnClose.Name = "m_btnClose";
            this.m_btnClose.Size = new System.Drawing.Size(23, 20);
            this.m_btnClose.ToolTipText = "关闭定位";
            this.m_btnClose.Click += new System.EventHandler(this.m_btnClose_Click);
            // 
            // frmQueryNavigator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 24);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQueryNavigator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "定位";
            this.Load += new System.EventHandler(this.frmQueryNavigator_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton m_btnFirst;
        private System.Windows.Forms.ToolStripButton m_btnPrev;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton m_btnNext;
        private System.Windows.Forms.ToolStripButton m_btnLast;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton m_btnClose;
        public System.Windows.Forms.ToolStripTextBox m_txtMedicine;
    }
}