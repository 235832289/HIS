namespace com.digitalwave.iCare.gui.HIS.Reports
{
    partial class frmGLReport
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
            this.btnDocWork = new System.Windows.Forms.Button();
            this.btnMZ = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDocWork
            // 
            this.btnDocWork.Location = new System.Drawing.Point(278, 153);
            this.btnDocWork.Name = "btnDocWork";
            this.btnDocWork.Size = new System.Drawing.Size(429, 59);
            this.btnDocWork.TabIndex = 0;
            this.btnDocWork.Text = "茶山医院医生工作量统计报表";
            this.btnDocWork.UseVisualStyleBackColor = true;
            this.btnDocWork.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnMZ
            // 
            this.btnMZ.Location = new System.Drawing.Point(278, 312);
            this.btnMZ.Name = "btnMZ";
            this.btnMZ.Size = new System.Drawing.Size(429, 49);
            this.btnMZ.TabIndex = 1;
            this.btnMZ.Text = "茶山医院门诊收入分组统计表";
            this.btnMZ.UseVisualStyleBackColor = true;
            this.btnMZ.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmGLReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 646);
            this.Controls.Add(this.btnMZ);
            this.Controls.Add(this.btnDocWork);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmGLReport";
            this.Text = "web报表";
            this.Load += new System.EventHandler(this.frmGLReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDocWork;
        private System.Windows.Forms.Button btnMZ;
    }
}