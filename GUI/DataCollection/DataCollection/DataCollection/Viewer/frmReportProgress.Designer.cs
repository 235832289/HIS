namespace com.digitalwave.iCare.gui.DataCollection
{
    partial class frmReportProgress
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
            this.m_txtProgressInfo = new System.Windows.Forms.Label();
            this.m_pgbProgress = new System.Windows.Forms.ProgressBar();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.m_tmrProgress = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // m_txtProgressInfo
            // 
            this.m_txtProgressInfo.AutoSize = true;
            this.m_txtProgressInfo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtProgressInfo.ForeColor = System.Drawing.Color.Teal;
            this.m_txtProgressInfo.Location = new System.Drawing.Point(2, 45);
            this.m_txtProgressInfo.Name = "m_txtProgressInfo";
            this.m_txtProgressInfo.Size = new System.Drawing.Size(281, 12);
            this.m_txtProgressInfo.TabIndex = 3;
            this.m_txtProgressInfo.Text = "正在上报第 0 条记录，共 0 条记录。已完成 0.00%";
            // 
            // m_pgbProgress
            // 
            this.m_pgbProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_pgbProgress.Location = new System.Drawing.Point(2, 5);
            this.m_pgbProgress.Name = "m_pgbProgress";
            this.m_pgbProgress.Size = new System.Drawing.Size(424, 30);
            this.m_pgbProgress.Step = 1;
            this.m_pgbProgress.TabIndex = 2;
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnCancel.Location = new System.Drawing.Point(366, 38);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(60, 25);
            this.m_btnCancel.TabIndex = 5;
            this.m_btnCancel.Text = "取消";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // m_tmrProgress
            // 
            this.m_tmrProgress.Enabled = true;
            this.m_tmrProgress.Interval = 1000;
            this.m_tmrProgress.Tick += new System.EventHandler(this.m_tmrProgress_Tick);
            // 
            // frmReportProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 63);
            this.ControlBox = false;
            this.Controls.Add(this.m_btnCancel);
            this.Controls.Add(this.m_txtProgressInfo);
            this.Controls.Add(this.m_pgbProgress);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmReportProgress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据上报进度";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label m_txtProgressInfo;
        internal System.Windows.Forms.ProgressBar m_pgbProgress;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.Timer m_tmrProgress;
    }
}