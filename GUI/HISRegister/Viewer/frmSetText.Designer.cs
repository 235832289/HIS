namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmSetText
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetText));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNO = new PinkieControls.ButtonXP();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new PinkieControls.ButtonXP();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Controls.Add(this.btnNO);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.txtContent);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(302, 139);
            this.panel1.TabIndex = 0;
            // 
            // btnNO
            // 
            this.btnNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnNO.DefaultScheme = true;
            this.btnNO.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNO.Hint = "";
            this.btnNO.Location = new System.Drawing.Point(220, 107);
            this.btnNO.Name = "btnNO";
            this.btnNO.Scheme = PinkieControls.ButtonXP.Schemes.Silver;
            this.btnNO.Size = new System.Drawing.Size(67, 27);
            this.btnNO.TabIndex = 7;
            this.btnNO.Text = "取消";
            this.btnNO.Click += new System.EventHandler(this.btnNO_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(18, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "最多可输入100汉字";
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnOK.DefaultScheme = true;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnOK.Hint = "";
            this.btnOK.Location = new System.Drawing.Point(151, 107);
            this.btnOK.Name = "btnOK";
            this.btnOK.Scheme = PinkieControls.ButtonXP.Schemes.Silver;
            this.btnOK.Size = new System.Drawing.Size(67, 27);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtContent
            // 
            this.txtContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContent.Location = new System.Drawing.Point(19, 12);
            this.txtContent.MaxLength = 100;
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(266, 90);
            this.txtContent.TabIndex = 0;
            // 
            // frmSetText
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnNO;
            this.ClientSize = new System.Drawing.Size(302, 139);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSetText";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtContent;
        private PinkieControls.ButtonXP btnOK;
        private PinkieControls.ButtonXP btnNO;
        private System.Windows.Forms.Label label1;
    }
}