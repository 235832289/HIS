namespace com.digitalwave.iCare.gui.DataCollection
{
    partial class frmAnimation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAnimation));
            this.axAnimation = new AxMSComCtl2.AxAnimation();
            this.btnButtom = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.axAnimation)).BeginInit();
            this.SuspendLayout();
            // 
            // axAnimation
            // 
            this.axAnimation.Location = new System.Drawing.Point(5, 6);
            this.axAnimation.Name = "axAnimation";
            this.axAnimation.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAnimation.OcxState")));
            this.axAnimation.Size = new System.Drawing.Size(72, 64);
            this.axAnimation.TabIndex = 0;
            // 
            // btnButtom
            // 
            this.btnButtom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnButtom.Enabled = false;
            this.btnButtom.Location = new System.Drawing.Point(0, 0);
            this.btnButtom.Name = "btnButtom";
            this.btnButtom.Size = new System.Drawing.Size(363, 73);
            this.btnButtom.TabIndex = 2;
            this.btnButtom.UseVisualStyleBackColor = true;
            // 
            // lblInfo
            // 
            this.lblInfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInfo.Location = new System.Drawing.Point(79, 29);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(278, 25);
            this.lblInfo.TabIndex = 3;
            this.lblInfo.Text = "请稍候...";
            // 
            // frmAnimation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 73);
            this.ControlBox = false;
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.axAnimation);
            this.Controls.Add(this.btnButtom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAnimation";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAnimation";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmAnimation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axAnimation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxMSComCtl2.AxAnimation axAnimation;
        private System.Windows.Forms.Button btnButtom;
        private System.Windows.Forms.Label lblInfo;
    }
}