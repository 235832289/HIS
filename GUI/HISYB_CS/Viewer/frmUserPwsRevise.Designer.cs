namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmUserPwsRevise
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
            this.txtpws = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmb_UserType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblqrxkl = new System.Windows.Forms.Label();
            this.lblxkl = new System.Windows.Forms.Label();
            this.lblykl = new System.Windows.Forms.Label();
            this.txtCfNewpws = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNewpws = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdExit = new PinkieControls.ButtonXP();
            this.btnOK = new PinkieControls.ButtonXP();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtpws
            // 
            this.txtpws.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtpws.Location = new System.Drawing.Point(115, 70);
            this.txtpws.MaxLength = 16;
            this.txtpws.Name = "txtpws";
            this.txtpws.PasswordChar = '*';
            this.txtpws.Size = new System.Drawing.Size(177, 23);
            this.txtpws.TabIndex = 0;
            this.txtpws.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpws_KeyDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmb_UserType);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblqrxkl);
            this.panel1.Controls.Add(this.lblxkl);
            this.panel1.Controls.Add(this.lblykl);
            this.panel1.Controls.Add(this.txtCfNewpws);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtNewpws);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmdExit);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.txtpws);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(412, 248);
            this.panel1.TabIndex = 7;
            // 
            // cmb_UserType
            // 
            this.cmb_UserType.AutoCompleteCustomSource.AddRange(new string[] {
            "门诊部",
            "住院部"});
            this.cmb_UserType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_UserType.FormattingEnabled = true;
            this.cmb_UserType.Items.AddRange(new object[] {
            "门诊部",
            "住院部"});
            this.cmb_UserType.Location = new System.Drawing.Point(115, 35);
            this.cmb_UserType.Name = "cmb_UserType";
            this.cmb_UserType.Size = new System.Drawing.Size(76, 22);
            this.cmb_UserType.TabIndex = 27;
            this.cmb_UserType.Text = "门诊部";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(25, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 14);
            this.label5.TabIndex = 26;
            this.label5.Text = "用户类型:";
            // 
            // lblqrxkl
            // 
            this.lblqrxkl.AutoSize = true;
            this.lblqrxkl.ForeColor = System.Drawing.Color.Red;
            this.lblqrxkl.Location = new System.Drawing.Point(309, 160);
            this.lblqrxkl.Name = "lblqrxkl";
            this.lblqrxkl.Size = new System.Drawing.Size(0, 12);
            this.lblqrxkl.TabIndex = 25;
            // 
            // lblxkl
            // 
            this.lblxkl.AutoSize = true;
            this.lblxkl.ForeColor = System.Drawing.Color.Red;
            this.lblxkl.Location = new System.Drawing.Point(309, 116);
            this.lblxkl.Name = "lblxkl";
            this.lblxkl.Size = new System.Drawing.Size(0, 12);
            this.lblxkl.TabIndex = 24;
            // 
            // lblykl
            // 
            this.lblykl.AutoSize = true;
            this.lblykl.ForeColor = System.Drawing.Color.Red;
            this.lblykl.Location = new System.Drawing.Point(309, 77);
            this.lblykl.Name = "lblykl";
            this.lblykl.Size = new System.Drawing.Size(0, 12);
            this.lblykl.TabIndex = 23;
            // 
            // txtCfNewpws
            // 
            this.txtCfNewpws.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCfNewpws.Location = new System.Drawing.Point(115, 152);
            this.txtCfNewpws.MaxLength = 16;
            this.txtCfNewpws.Name = "txtCfNewpws";
            this.txtCfNewpws.PasswordChar = '*';
            this.txtCfNewpws.Size = new System.Drawing.Size(177, 23);
            this.txtCfNewpws.TabIndex = 2;
            this.txtCfNewpws.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCfNewpws_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(25, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 14);
            this.label4.TabIndex = 22;
            this.label4.Text = "确认新口令:";
            // 
            // txtNewpws
            // 
            this.txtNewpws.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNewpws.Location = new System.Drawing.Point(115, 108);
            this.txtNewpws.MaxLength = 16;
            this.txtNewpws.Name = "txtNewpws";
            this.txtNewpws.PasswordChar = '*';
            this.txtNewpws.Size = new System.Drawing.Size(177, 23);
            this.txtNewpws.TabIndex = 1;
            this.txtNewpws.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNewpws_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(25, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 20;
            this.label3.Text = "新 口 令:";
            // 
            // cmdExit
            // 
            this.cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmdExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdExit.DefaultScheme = true;
            this.cmdExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdExit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdExit.Hint = "";
            this.cmdExit.Location = new System.Drawing.Point(197, 201);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdExit.Size = new System.Drawing.Size(76, 32);
            this.cmdExit.TabIndex = 4;
            this.cmdExit.Text = "取消";
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.DefaultScheme = true;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnOK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Hint = "";
            this.btnOK.Location = new System.Drawing.Point(104, 201);
            this.btnOK.Name = "btnOK";
            this.btnOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnOK.Size = new System.Drawing.Size(76, 32);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(25, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 16;
            this.label2.Text = "原 口 令:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(153, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "医院口令修改";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(162)))), ((int)(((byte)(247)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(412, 28);
            this.panel2.TabIndex = 6;
            // 
            // frmUserPwsRevise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 248);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserPwsRevise";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUser";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TextBox txtpws;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        internal PinkieControls.ButtonXP cmdExit;
        internal PinkieControls.ButtonXP btnOK;
        internal System.Windows.Forms.TextBox txtCfNewpws;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtNewpws;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblqrxkl;
        private System.Windows.Forms.Label lblxkl;
        private System.Windows.Forms.Label lblykl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_UserType;
    }
}