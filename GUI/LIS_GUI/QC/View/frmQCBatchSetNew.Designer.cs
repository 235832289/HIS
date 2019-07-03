namespace com.digitalwave.iCare.gui.LIS.QC.View
{
    partial class frmQCBatchSetNew
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
            this.m_cboQCSqmpleVendor = new com.digitalwave.iCare.gui.LIS.ctlVendorCombox();
            this.m_cboQCSampleSource = new com.digitalwave.iCare.gui.LIS.ctlVendorCombox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtQCSampleLotNO = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txtQCBatchSeq = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cmdConfirm = new PinkieControls.ButtonXP();
            this.m_cmdCancel = new PinkieControls.ButtonXP();
            this.SuspendLayout();
            // 
            // m_cboQCSqmpleVendor
            // 
            this.m_cboQCSqmpleVendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboQCSqmpleVendor.FormattingEnabled = true;
            this.m_cboQCSqmpleVendor.Location = new System.Drawing.Point(114, 151);
            this.m_cboQCSqmpleVendor.Name = "m_cboQCSqmpleVendor";
            this.m_cboQCSqmpleVendor.Size = new System.Drawing.Size(227, 22);
            this.m_cboQCSqmpleVendor.TabIndex = 15;
            // 
            // m_cboQCSampleSource
            // 
            this.m_cboQCSampleSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboQCSampleSource.FormattingEnabled = true;
            this.m_cboQCSampleSource.Location = new System.Drawing.Point(114, 112);
            this.m_cboQCSampleSource.Name = "m_cboQCSampleSource";
            this.m_cboQCSampleSource.Size = new System.Drawing.Size(227, 22);
            this.m_cboQCSampleSource.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 14);
            this.label6.TabIndex = 18;
            this.label6.Text = "质控品厂商：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 14);
            this.label5.TabIndex = 17;
            this.label5.Text = "质控品来源：";
            // 
            // m_txtQCSampleLotNO
            // 
            this.m_txtQCSampleLotNO.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.m_txtQCSampleLotNO.Location = new System.Drawing.Point(114, 69);
            this.m_txtQCSampleLotNO.MaxLength = 25;
            this.m_txtQCSampleLotNO.Name = "m_txtQCSampleLotNO";
            this.m_txtQCSampleLotNO.Size = new System.Drawing.Size(227, 23);
            this.m_txtQCSampleLotNO.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 14);
            this.label4.TabIndex = 16;
            this.label4.Text = "质控品批号：";
            // 
            // m_txtQCBatchSeq
            // 
            this.m_txtQCBatchSeq.BackColor = System.Drawing.SystemColors.Info;
            this.m_txtQCBatchSeq.Location = new System.Drawing.Point(114, 31);
            this.m_txtQCBatchSeq.MaxLength = 6;
            this.m_txtQCBatchSeq.Name = "m_txtQCBatchSeq";
            this.m_txtQCBatchSeq.ReadOnly = true;
            this.m_txtQCBatchSeq.Size = new System.Drawing.Size(227, 23);
            this.m_txtQCBatchSeq.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 12;
            this.label1.Text = "序号：";
            // 
            // m_cmdConfirm
            // 
            this.m_cmdConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdConfirm.DefaultScheme = true;
            this.m_cmdConfirm.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdConfirm.Hint = "";
            this.m_cmdConfirm.Location = new System.Drawing.Point(114, 206);
            this.m_cmdConfirm.Name = "m_cmdConfirm";
            this.m_cmdConfirm.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdConfirm.Size = new System.Drawing.Size(98, 33);
            this.m_cmdConfirm.TabIndex = 19;
            this.m_cmdConfirm.Text = "确定";
            // 
            // m_cmdCancel
            // 
            this.m_cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdCancel.DefaultScheme = true;
            this.m_cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdCancel.Hint = "";
            this.m_cmdCancel.Location = new System.Drawing.Point(226, 206);
            this.m_cmdCancel.Name = "m_cmdCancel";
            this.m_cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCancel.Size = new System.Drawing.Size(98, 33);
            this.m_cmdCancel.TabIndex = 20;
            this.m_cmdCancel.Text = "取消(ESC)";
            // 
            // frmQCBatchSetNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 264);
            this.Controls.Add(this.m_cmdConfirm);
            this.Controls.Add(this.m_cmdCancel);
            this.Controls.Add(this.m_cboQCSqmpleVendor);
            this.Controls.Add(this.m_cboQCSampleSource);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.m_txtQCSampleLotNO);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_txtQCBatchSeq);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQCBatchSetNew";
            this.Text = "质控批设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctlVendorCombox m_cboQCSqmpleVendor;
        private ctlVendorCombox m_cboQCSampleSource;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox m_txtQCSampleLotNO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox m_txtQCBatchSeq;
        private System.Windows.Forms.Label label1;
        private PinkieControls.ButtonXP m_cmdConfirm;
        private PinkieControls.ButtonXP m_cmdCancel;
    }
}