namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmShowRegister
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
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.ctlprintShow1 = new com.digitalwave.controls.Control.ctlprintShow();
            this.SuspendLayout();
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            // 
            // ctlprintShow1
            // 
            this.ctlprintShow1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlprintShow1.Location = new System.Drawing.Point(0, 0);
            this.ctlprintShow1.Name = "ctlprintShow1";
            this.ctlprintShow1.Size = new System.Drawing.Size(694, 370);
            this.ctlprintShow1.TabIndex = 1;
            this.ctlprintShow1.Zoom = 1;
            // 
            // frmShowRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 370);
            this.Controls.Add(this.ctlprintShow1);
            this.Name = "frmShowRegister";
            this.Text = "挂号发票";
            this.Load += new System.EventHandler(this.frmShowRegister_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Drawing.Printing.PrintDocument printDocument1;
        private com.digitalwave.controls.Control.ctlprintShow ctlprintShow1;
    }
}