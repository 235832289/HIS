namespace iCare
{
    partial class frmPartogramSelected
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPartogramSelected));
            this.m_lblMessage = new System.Windows.Forms.Label();
            this.m_cmdModify = new ExternalControlsLib.XPButton();
            this.m_cmdDelete = new ExternalControlsLib.XPButton();
            this.m_cmdCancel = new ExternalControlsLib.XPButton();
            this.SuspendLayout();
            // 
            // m_lblMessage
            // 
            this.m_lblMessage.BackColor = System.Drawing.SystemColors.Control;
            this.m_lblMessage.Location = new System.Drawing.Point(12, 9);
            this.m_lblMessage.Name = "m_lblMessage";
            this.m_lblMessage.Size = new System.Drawing.Size(265, 146);
            this.m_lblMessage.TabIndex = 0;
            // 
            // m_cmdModify
            // 
            this.m_cmdModify.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmdModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdModify.BtnShape = ExternalControlsLib.emunType.BtnShape.Rectangle;
            this.m_cmdModify.BtnStyle = ExternalControlsLib.emunType.XPStyle.Silver;
            this.m_cmdModify.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.m_cmdModify.Location = new System.Drawing.Point(18, 165);
            this.m_cmdModify.Name = "m_cmdModify";
            this.m_cmdModify.Size = new System.Drawing.Size(75, 28);
            this.m_cmdModify.TabIndex = 1;
            this.m_cmdModify.Text = "修改(&M)";
            this.m_cmdModify.UseVisualStyleBackColor = true;
            this.m_cmdModify.Click += new System.EventHandler(this.m_cmdModify_Click);
            // 
            // m_cmdDelete
            // 
            this.m_cmdDelete.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmdDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdDelete.BtnShape = ExternalControlsLib.emunType.BtnShape.Rectangle;
            this.m_cmdDelete.BtnStyle = ExternalControlsLib.emunType.XPStyle.Silver;
            this.m_cmdDelete.DialogResult = System.Windows.Forms.DialogResult.No;
            this.m_cmdDelete.Location = new System.Drawing.Point(107, 165);
            this.m_cmdDelete.Name = "m_cmdDelete";
            this.m_cmdDelete.Size = new System.Drawing.Size(75, 28);
            this.m_cmdDelete.TabIndex = 1;
            this.m_cmdDelete.Text = "删除(&D)";
            this.m_cmdDelete.UseVisualStyleBackColor = true;
            this.m_cmdDelete.Click += new System.EventHandler(this.m_cmdModify_Click);
            // 
            // m_cmdCancel
            // 
            this.m_cmdCancel.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdCancel.BtnShape = ExternalControlsLib.emunType.BtnShape.Rectangle;
            this.m_cmdCancel.BtnStyle = ExternalControlsLib.emunType.XPStyle.Silver;
            this.m_cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdCancel.Location = new System.Drawing.Point(196, 165);
            this.m_cmdCancel.Name = "m_cmdCancel";
            this.m_cmdCancel.Size = new System.Drawing.Size(75, 28);
            this.m_cmdCancel.TabIndex = 1;
            this.m_cmdCancel.Text = "取消(&C)";
            this.m_cmdCancel.UseVisualStyleBackColor = true;
            this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdModify_Click);
            // 
            // frmPartogramSelected
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(291, 205);
            this.Controls.Add(this.m_cmdCancel);
            this.Controls.Add(this.m_cmdDelete);
            this.Controls.Add(this.m_cmdModify);
            this.Controls.Add(this.m_lblMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPartogramSelected";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "提示";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label m_lblMessage;
        private ExternalControlsLib.XPButton m_cmdModify;
        private ExternalControlsLib.XPButton m_cmdDelete;
        private ExternalControlsLib.XPButton m_cmdCancel;
    }
}