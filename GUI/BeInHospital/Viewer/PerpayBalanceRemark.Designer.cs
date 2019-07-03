namespace com.digitalwave.iCare.gui.HIS
{
    partial class PerpayBalanceRemark
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
            this.m_rtpRemark = new System.Windows.Forms.RichTextBox();
            this.m_buttonConfirm = new PinkieControls.ButtonXP();
            this.m_buttonCancel = new PinkieControls.ButtonXP();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_rtpRemark
            // 
            this.m_rtpRemark.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_rtpRemark.Location = new System.Drawing.Point(12, 37);
            this.m_rtpRemark.Name = "m_rtpRemark";
            this.m_rtpRemark.Size = new System.Drawing.Size(524, 259);
            this.m_rtpRemark.TabIndex = 0;
            this.m_rtpRemark.Text = "";
            // 
            // m_buttonConfirm
            // 
            this.m_buttonConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_buttonConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_buttonConfirm.DefaultScheme = true;
            this.m_buttonConfirm.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_buttonConfirm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_buttonConfirm.Hint = "";
            this.m_buttonConfirm.Location = new System.Drawing.Point(379, 307);
            this.m_buttonConfirm.Name = "m_buttonConfirm";
            this.m_buttonConfirm.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_buttonConfirm.Size = new System.Drawing.Size(70, 27);
            this.m_buttonConfirm.TabIndex = 15;
            this.m_buttonConfirm.Text = "确定(&O)";
            this.m_buttonConfirm.Click += new System.EventHandler(this.m_buttonConfirm_Click);
            // 
            // m_buttonCancel
            // 
            this.m_buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_buttonCancel.DefaultScheme = true;
            this.m_buttonCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_buttonCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_buttonCancel.Hint = "";
            this.m_buttonCancel.Location = new System.Drawing.Point(458, 306);
            this.m_buttonCancel.Name = "m_buttonCancel";
            this.m_buttonCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_buttonCancel.Size = new System.Drawing.Size(70, 27);
            this.m_buttonCancel.TabIndex = 16;
            this.m_buttonCancel.Text = "取消(&C)";
            this.m_buttonCancel.Click += new System.EventHandler(this.m_buttonCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 14);
            this.label1.TabIndex = 17;
            this.label1.Text = "备注内容：";
            // 
            // PerpayBalanceRemark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 350);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_buttonCancel);
            this.Controls.Add(this.m_buttonConfirm);
            this.Controls.Add(this.m_rtpRemark);
            this.Name = "PerpayBalanceRemark";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "住院预交款结帐备注";
            this.Load += new System.EventHandler(this.PerpayBalanceRemark_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal PinkieControls.ButtonXP m_buttonConfirm;
        internal PinkieControls.ButtonXP m_buttonCancel;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.RichTextBox m_rtpRemark;
    }
}