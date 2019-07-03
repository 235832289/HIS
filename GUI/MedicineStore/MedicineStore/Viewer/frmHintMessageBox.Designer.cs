namespace com.digitalwave.iCare.gui.MedicineStore
{
    partial class frmHintMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHintMessageBox));
            this.m_txtMessage = new System.Windows.Forms.TextBox();
            this.m_cmdYes = new System.Windows.Forms.Button();
            this.m_cmdNo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_txtMessage
            // 
            this.m_txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtMessage.Location = new System.Drawing.Point(-1, 0);
            this.m_txtMessage.Multiline = true;
            this.m_txtMessage.Name = "m_txtMessage";
            this.m_txtMessage.Size = new System.Drawing.Size(414, 204);
            this.m_txtMessage.TabIndex = 100;
            // 
            // m_cmdYes
            // 
            this.m_cmdYes.Location = new System.Drawing.Point(104, 206);
            this.m_cmdYes.Name = "m_cmdYes";
            this.m_cmdYes.Size = new System.Drawing.Size(75, 30);
            this.m_cmdYes.TabIndex = 5;
            this.m_cmdYes.Text = "是";
            this.m_cmdYes.UseVisualStyleBackColor = true;
            this.m_cmdYes.Click += new System.EventHandler(this.m_cmdYes_Click);
            // 
            // m_cmdNo
            // 
            this.m_cmdNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdNo.Location = new System.Drawing.Point(221, 206);
            this.m_cmdNo.Name = "m_cmdNo";
            this.m_cmdNo.Size = new System.Drawing.Size(75, 30);
            this.m_cmdNo.TabIndex = 10;
            this.m_cmdNo.Text = "否";
            this.m_cmdNo.UseVisualStyleBackColor = true;
            this.m_cmdNo.Click += new System.EventHandler(this.m_cmdNo_Click);
            // 
            // frmHintMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_cmdNo;
            this.ClientSize = new System.Drawing.Size(412, 239);
            this.Controls.Add(this.m_cmdNo);
            this.Controls.Add(this.m_cmdYes);
            this.Controls.Add(this.m_txtMessage);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHintMessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "提示信息";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_cmdYes;
        private System.Windows.Forms.Button m_cmdNo;
        private System.Windows.Forms.TextBox m_txtMessage;
    }
}