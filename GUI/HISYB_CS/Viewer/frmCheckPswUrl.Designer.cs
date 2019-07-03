namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmCheckPswUrl
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
            this.WebUrl = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // WebUrl
            // 
            this.WebUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WebUrl.Location = new System.Drawing.Point(0, 0);
            this.WebUrl.MinimumSize = new System.Drawing.Size(20, 20);
            this.WebUrl.Name = "WebUrl";
            this.WebUrl.Size = new System.Drawing.Size(831, 561);
            this.WebUrl.TabIndex = 0;
            // 
            // frmCheckPswUrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 561);
            this.Controls.Add(this.WebUrl);
            this.Name = "frmCheckPswUrl";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "社保卡密码验证";
            this.Load += new System.EventHandler(this.frmCheckPswUrl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser WebUrl;
    }
}