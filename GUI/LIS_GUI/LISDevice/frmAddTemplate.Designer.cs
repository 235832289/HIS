namespace com.digitalwave.iCare.gui.LIS
{
    partial class frmAddTemplate
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
            this.m_txtTemplateName = new System.Windows.Forms.TextBox();
            this.m_cmdSubmit = new PinkieControls.ButtonXP();
            this.m_cmdCancel = new PinkieControls.ButtonXP();
            this.SuspendLayout();
            // 
            // m_txtTemplateName
            // 
            this.m_txtTemplateName.Location = new System.Drawing.Point(14, 14);
            this.m_txtTemplateName.Name = "m_txtTemplateName";
            this.m_txtTemplateName.Size = new System.Drawing.Size(278, 23);
            this.m_txtTemplateName.TabIndex = 0;
            // 
            // m_cmdSubmit
            // 
            this.m_cmdSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdSubmit.DefaultScheme = true;
            this.m_cmdSubmit.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.m_cmdSubmit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdSubmit.Hint = "";
            this.m_cmdSubmit.Location = new System.Drawing.Point(43, 56);
            this.m_cmdSubmit.Name = "m_cmdSubmit";
            this.m_cmdSubmit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSubmit.Size = new System.Drawing.Size(86, 28);
            this.m_cmdSubmit.TabIndex = 30;
            this.m_cmdSubmit.Text = "确  定";
            this.m_cmdSubmit.Click += new System.EventHandler(this.m_cmdSubmit_Click);
            // 
            // m_cmdCancel
            // 
            this.m_cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdCancel.DefaultScheme = true;
            this.m_cmdCancel.DialogResult = System.Windows.Forms.DialogResult.No;
            this.m_cmdCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdCancel.Hint = "";
            this.m_cmdCancel.Location = new System.Drawing.Point(164, 56);
            this.m_cmdCancel.Name = "m_cmdCancel";
            this.m_cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCancel.Size = new System.Drawing.Size(86, 28);
            this.m_cmdCancel.TabIndex = 31;
            this.m_cmdCancel.Text = "取　消";
            this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
            // 
            // frmAddTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 96);
            this.Controls.Add(this.m_cmdCancel);
            this.Controls.Add(this.m_cmdSubmit);
            this.Controls.Add(this.m_txtTemplateName);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Name = "frmAddTemplate";
            this.Text = "添加模板";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox m_txtTemplateName;
        internal PinkieControls.ButtonXP m_cmdSubmit;
        internal PinkieControls.ButtonXP m_cmdCancel;
    }
}