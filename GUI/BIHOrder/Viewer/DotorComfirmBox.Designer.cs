namespace com.digitalwave.iCare.BIHOrder
{
    partial class DotorComfirmBox
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdSaveBihRegister = new PinkieControls.ButtonXP();
            this.buttonXP1 = new PinkieControls.ButtonXP();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox1.Controls.Add(this.m_txtPassword);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.m_txtName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 127);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // m_txtPassword
            // 
            this.m_txtPassword.BackColor = System.Drawing.Color.White;
            this.m_txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtPassword.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPassword.ForeColor = System.Drawing.Color.Black;
            this.m_txtPassword.Location = new System.Drawing.Point(84, 66);
            this.m_txtPassword.MaxLength = 20;
            this.m_txtPassword.Name = "m_txtPassword";
            this.m_txtPassword.Size = new System.Drawing.Size(186, 30);
            this.m_txtPassword.TabIndex = 1;
            this.m_txtPassword.UseSystemPasswordChar = true;
            this.m_txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(18, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 14);
            this.label2.TabIndex = 22;
            this.label2.Text = "密 码:";
            // 
            // m_txtName
            // 
            this.m_txtName.BackColor = System.Drawing.Color.White;
            this.m_txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtName.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtName.ForeColor = System.Drawing.Color.Black;
            this.m_txtName.Location = new System.Drawing.Point(84, 28);
            this.m_txtName.MaxLength = 20;
            this.m_txtName.Name = "m_txtName";
            this.m_txtName.Size = new System.Drawing.Size(186, 30);
            this.m_txtName.TabIndex = 0;
            this.m_txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(18, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 14);
            this.label1.TabIndex = 20;
            this.label1.Text = "员工号:";
            // 
            // cmdSaveBihRegister
            // 
            this.cmdSaveBihRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdSaveBihRegister.DefaultScheme = true;
            this.cmdSaveBihRegister.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdSaveBihRegister.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdSaveBihRegister.Hint = "";
            this.cmdSaveBihRegister.Location = new System.Drawing.Point(23, 0);
            this.cmdSaveBihRegister.Name = "cmdSaveBihRegister";
            this.cmdSaveBihRegister.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdSaveBihRegister.Size = new System.Drawing.Size(85, 33);
            this.cmdSaveBihRegister.TabIndex = 3;
            this.cmdSaveBihRegister.Text = "确定(&S)";
            this.cmdSaveBihRegister.Click += new System.EventHandler(this.cmdSaveBihRegister_Click);
            // 
            // buttonXP1
            // 
            this.buttonXP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP1.DefaultScheme = true;
            this.buttonXP1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonXP1.Hint = "";
            this.buttonXP1.Location = new System.Drawing.Point(144, 0);
            this.buttonXP1.Name = "buttonXP1";
            this.buttonXP1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP1.Size = new System.Drawing.Size(85, 33);
            this.buttonXP1.TabIndex = 4;
            this.buttonXP1.Text = "取消(Esc)";
            this.buttonXP1.Click += new System.EventHandler(this.buttonXP1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdSaveBihRegister);
            this.panel1.Controls.Add(this.buttonXP1);
            this.panel1.Location = new System.Drawing.Point(22, 134);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(261, 33);
            this.panel1.TabIndex = 2;
            // 
            // DotorComfirmBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(312, 173);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DotorComfirmBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "身份确认";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DotorComfirmBox_KeyDown);
            this.Load += new System.EventHandler(this.DotorComfirmBox_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox m_txtPassword;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox m_txtName;
        private System.Windows.Forms.Label label1;
        internal PinkieControls.ButtonXP cmdSaveBihRegister;
        internal PinkieControls.ButtonXP buttonXP1;
        private System.Windows.Forms.Panel panel1;
    }
}