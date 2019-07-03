namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmIPInvoiceinput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIPInvoiceinput));
            this.btOk = new PinkieControls.ButtonXP();
            this.btnCancel = new PinkieControls.ButtonXP();
            this.txtInvono = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btOk
            // 
            this.btOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btOk.DefaultScheme = true;
            this.btOk.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btOk.Font = new System.Drawing.Font("宋体", 10F);
            this.btOk.Hint = "";
            this.btOk.Location = new System.Drawing.Point(101, 109);
            this.btOk.Name = "btOk";
            this.btOk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btOk.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btOk.Size = new System.Drawing.Size(96, 32);
            this.btOk.TabIndex = 1;
            this.btOk.Text = "确定(&O)";
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnCancel.DefaultScheme = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 10F);
            this.btnCancel.Hint = "";
            this.btnCancel.Location = new System.Drawing.Point(221, 109);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnCancel.Size = new System.Drawing.Size(96, 32);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "放弃(&C)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtInvono
            // 
            this.txtInvono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInvono.Font = new System.Drawing.Font("Times New Roman", 50.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvono.Location = new System.Drawing.Point(7, 8);
            this.txtInvono.MaxLength = 10;
            this.txtInvono.Name = "txtInvono";
            this.txtInvono.Size = new System.Drawing.Size(398, 85);
            this.txtInvono.TabIndex = 0;
            this.txtInvono.Text = "DW91236583";
            this.txtInvono.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInvono_KeyDown);
            // 
            // frmIPInvoiceinput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 155);
            this.Controls.Add(this.txtInvono);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmIPInvoiceinput";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " 请输入发票号(同当前打印发票号)";
            this.Load += new System.EventHandler(this.frmIPInvoiceinput_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmIPInvoiceinput_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal PinkieControls.ButtonXP btOk;
        internal PinkieControls.ButtonXP btnCancel;
        public System.Windows.Forms.TextBox txtInvono;
    }
}