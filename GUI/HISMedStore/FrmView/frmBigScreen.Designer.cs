namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmBigScreen
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBigScreen));
            this.m_CallTimer = new System.Windows.Forms.Timer(this.components);
            this.m_PbBigScreen = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.m_PbBigScreen)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_CallTimer
            // 
            this.m_CallTimer.Tick += new System.EventHandler(this.m_CallTimer_Tick);
            // 
            // m_PbBigScreen
            // 
            this.m_PbBigScreen.BackColor = System.Drawing.Color.Black;
            this.m_PbBigScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_PbBigScreen.Location = new System.Drawing.Point(0, 0);
            this.m_PbBigScreen.Name = "m_PbBigScreen";
            this.m_PbBigScreen.Size = new System.Drawing.Size(390, 141);
            this.m_PbBigScreen.TabIndex = 5;
            this.m_PbBigScreen.TabStop = false;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_Exit});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(113, 26);
            // 
            // MenuItem_Exit
            // 
            this.MenuItem_Exit.Image = global::com.digitalwave.iCare.gui.HIS.Properties.Resources.退;
            this.MenuItem_Exit.Name = "MenuItem_Exit";
            this.MenuItem_Exit.Size = new System.Drawing.Size(112, 22);
            this.MenuItem_Exit.Text = "退出(&E)";
            this.MenuItem_Exit.Click += new System.EventHandler(this.MenuItem_Exit_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "药房电子大显示屏";
            this.notifyIcon.Visible = true;
            // 
            // frmBigScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 141);
            this.Controls.Add(this.m_PbBigScreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmBigScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "药房电子大显示屏";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBigScreen_FormClosing);
            this.Load += new System.EventHandler(this.frmBigScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_PbBigScreen)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer m_CallTimer;
        internal System.Windows.Forms.PictureBox m_PbBigScreen;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Exit;
        private System.Windows.Forms.NotifyIcon notifyIcon;
    }
}