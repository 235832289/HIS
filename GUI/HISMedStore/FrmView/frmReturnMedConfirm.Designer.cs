namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmReturnMedConfirm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReturnMedConfirm));
            this.gradientPanel1 = new com.digitalwave.iCare.gui.HIS.GradientPanel();
            this.m_txtPwd = new System.Windows.Forms.TextBox();
            this.m_txtConfirmid = new System.Windows.Forms.TextBox();
            this.m_btnConfirm = new PinkieControls.ButtonXP();
            this.label3 = new System.Windows.Forms.Label();
            this.m_btnCancel = new PinkieControls.ButtonXP();
            this.label2 = new System.Windows.Forms.Label();
            this.gradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Controls.Add(this.m_txtPwd);
            this.gradientPanel1.Controls.Add(this.m_txtConfirmid);
            this.gradientPanel1.Controls.Add(this.m_btnConfirm);
            this.gradientPanel1.Controls.Add(this.label3);
            this.gradientPanel1.Controls.Add(this.m_btnCancel);
            this.gradientPanel1.Controls.Add(this.label2);
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel1.Flip = false;
            this.gradientPanel1.FloatingImage = null;
            this.gradientPanel1.GradientAngle = 90;
            this.gradientPanel1.GradientEndColor = System.Drawing.Color.DarkGray;
            this.gradientPanel1.GradientStartColor = System.Drawing.Color.White;
            this.gradientPanel1.HorizontalFillPercent = 100F;
            this.gradientPanel1.imageXOffset = 0;
            this.gradientPanel1.imageYOffset = 0;
            this.gradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(283, 165);
            this.gradientPanel1.TabIndex = 14;
            this.gradientPanel1.VerticalFillPercent = 100F;
            // 
            // m_txtPwd
            // 
            this.m_txtPwd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPwd.Location = new System.Drawing.Point(122, 74);
            this.m_txtPwd.MaxLength = 100;
            this.m_txtPwd.Name = "m_txtPwd";
            this.m_txtPwd.PasswordChar = '*';
            this.m_txtPwd.Size = new System.Drawing.Size(120, 23);
            this.m_txtPwd.TabIndex = 2;
            this.m_txtPwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtConfirmid_KeyDown);
            // 
            // m_txtConfirmid
            // 
            this.m_txtConfirmid.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtConfirmid.Location = new System.Drawing.Point(122, 29);
            this.m_txtConfirmid.MaxLength = 4;
            this.m_txtConfirmid.Name = "m_txtConfirmid";
            this.m_txtConfirmid.Size = new System.Drawing.Size(120, 23);
            this.m_txtConfirmid.TabIndex = 1;
            this.m_txtConfirmid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtConfirmid_KeyDown);
            // 
            // m_btnConfirm
            // 
            this.m_btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnConfirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.m_btnConfirm.DefaultScheme = true;
            this.m_btnConfirm.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnConfirm.Hint = "";
            this.m_btnConfirm.Location = new System.Drawing.Point(59, 117);
            this.m_btnConfirm.Name = "m_btnConfirm";
            this.m_btnConfirm.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnConfirm.Size = new System.Drawing.Size(86, 28);
            this.m_btnConfirm.TabIndex = 3;
            this.m_btnConfirm.Text = "确定(&D)";
            this.m_btnConfirm.Click += new System.EventHandler(this.m_btnConfirm_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(34, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 14);
            this.label3.TabIndex = 12;
            this.label3.Text = "确认人密码：";
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnCancel.DefaultScheme = true;
            this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnCancel.Hint = "";
            this.m_btnCancel.Location = new System.Drawing.Point(153, 117);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnCancel.Size = new System.Drawing.Size(86, 28);
            this.m_btnCancel.TabIndex = 4;
            this.m_btnCancel.Text = "取消(&C)";
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(34, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 14);
            this.label2.TabIndex = 11;
            this.label2.Text = "确认人工号：";
            // 
            // frmReturnMedConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 165);
            this.Controls.Add(this.gradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmReturnMedConfirm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "门诊药房退药确认窗口";
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TextBox m_txtPwd;
        internal System.Windows.Forms.TextBox m_txtConfirmid;
        internal PinkieControls.ButtonXP m_btnConfirm;
        private System.Windows.Forms.Label label3;
        internal PinkieControls.ButtonXP m_btnCancel;
        private System.Windows.Forms.Label label2;
        internal GradientPanel gradientPanel1;
    }
}