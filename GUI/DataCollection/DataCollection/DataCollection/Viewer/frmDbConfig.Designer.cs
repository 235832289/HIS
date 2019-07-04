namespace com.digitalwave.iCare.gui.DataCollection
{
    partial class frmDbConfig
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
            this.m_btnSave = new System.Windows.Forms.Button();
            this.m_btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_pnlTextContainer = new System.Windows.Forms.Panel();
            this.m_txtIp3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.m_txtIp4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_txtIp1 = new System.Windows.Forms.TextBox();
            this.m_txtIp2 = new System.Windows.Forms.TextBox();
            this.m_txtDataBase = new System.Windows.Forms.TextBox();
            this.m_txtPwd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cboType = new System.Windows.Forms.ComboBox();
            this.m_txtUser = new System.Windows.Forms.TextBox();
            this.m_btnTest = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.m_pnlTextContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnSave
            // 
            this.m_btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_btnSave.Location = new System.Drawing.Point(102, 236);
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Size = new System.Drawing.Size(75, 27);
            this.m_btnSave.TabIndex = 2;
            this.m_btnSave.Text = "保存";
            this.m_btnSave.UseVisualStyleBackColor = true;
            this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
            // 
            // m_btnClose
            // 
            this.m_btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_btnClose.Location = new System.Drawing.Point(192, 236);
            this.m_btnClose.Name = "m_btnClose";
            this.m_btnClose.Size = new System.Drawing.Size(75, 27);
            this.m_btnClose.TabIndex = 3;
            this.m_btnClose.Text = "关闭";
            this.m_btnClose.UseVisualStyleBackColor = true;
            this.m_btnClose.Click += new System.EventHandler(this.m_btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_pnlTextContainer);
            this.groupBox1.Controls.Add(this.m_txtDataBase);
            this.groupBox1.Controls.Add(this.m_txtPwd);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.m_cboType);
            this.groupBox1.Controls.Add(this.m_txtUser);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(3, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 223);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " 连接配置 ";
            // 
            // m_pnlTextContainer
            // 
            this.m_pnlTextContainer.BackColor = System.Drawing.Color.White;
            this.m_pnlTextContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_pnlTextContainer.Controls.Add(this.m_txtIp3);
            this.m_pnlTextContainer.Controls.Add(this.label7);
            this.m_pnlTextContainer.Controls.Add(this.label9);
            this.m_pnlTextContainer.Controls.Add(this.m_txtIp4);
            this.m_pnlTextContainer.Controls.Add(this.label6);
            this.m_pnlTextContainer.Controls.Add(this.m_txtIp1);
            this.m_pnlTextContainer.Controls.Add(this.m_txtIp2);
            this.m_pnlTextContainer.Location = new System.Drawing.Point(95, 65);
            this.m_pnlTextContainer.Name = "m_pnlTextContainer";
            this.m_pnlTextContainer.Size = new System.Drawing.Size(170, 23);
            this.m_pnlTextContainer.TabIndex = 16;
            // 
            // m_txtIp3
            // 
            this.m_txtIp3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtIp3.Location = new System.Drawing.Point(87, 3);
            this.m_txtIp3.Name = "m_txtIp3";
            this.m_txtIp3.Size = new System.Drawing.Size(35, 16);
            this.m_txtIp3.TabIndex = 7;
            this.m_txtIp3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtIp3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtIp_KeyDown);
            this.m_txtIp3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtIp_KeyPress);
            this.m_txtIp3.Enter += new System.EventHandler(this.m_txtIp_Enter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(121, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 14);
            this.label7.TabIndex = 8;
            this.label7.Text = ".";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(77, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 14);
            this.label9.TabIndex = 6;
            this.label9.Text = ".";
            // 
            // m_txtIp4
            // 
            this.m_txtIp4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtIp4.Location = new System.Drawing.Point(131, 3);
            this.m_txtIp4.Name = "m_txtIp4";
            this.m_txtIp4.Size = new System.Drawing.Size(35, 16);
            this.m_txtIp4.TabIndex = 9;
            this.m_txtIp4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtIp4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtIp_KeyDown);
            this.m_txtIp4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtIp_KeyPress);
            this.m_txtIp4.Enter += new System.EventHandler(this.m_txtIp_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 14);
            this.label6.TabIndex = 4;
            this.label6.Text = ".";
            // 
            // m_txtIp1
            // 
            this.m_txtIp1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtIp1.Location = new System.Drawing.Point(0, 3);
            this.m_txtIp1.Name = "m_txtIp1";
            this.m_txtIp1.Size = new System.Drawing.Size(35, 16);
            this.m_txtIp1.TabIndex = 3;
            this.m_txtIp1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtIp1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtIp_KeyDown);
            this.m_txtIp1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtIp_KeyPress);
            this.m_txtIp1.Enter += new System.EventHandler(this.m_txtIp_Enter);
            // 
            // m_txtIp2
            // 
            this.m_txtIp2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtIp2.Location = new System.Drawing.Point(43, 3);
            this.m_txtIp2.Name = "m_txtIp2";
            this.m_txtIp2.Size = new System.Drawing.Size(35, 16);
            this.m_txtIp2.TabIndex = 5;
            this.m_txtIp2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtIp2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtIp_KeyDown);
            this.m_txtIp2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtIp_KeyPress);
            this.m_txtIp2.Enter += new System.EventHandler(this.m_txtIp_Enter);
            // 
            // m_txtDataBase
            // 
            this.m_txtDataBase.Location = new System.Drawing.Point(95, 183);
            this.m_txtDataBase.Name = "m_txtDataBase";
            this.m_txtDataBase.Size = new System.Drawing.Size(170, 23);
            this.m_txtDataBase.TabIndex = 15;
            this.m_txtDataBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtDataBase.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter_KeyDown);
            // 
            // m_txtPwd
            // 
            this.m_txtPwd.Location = new System.Drawing.Point(95, 144);
            this.m_txtPwd.Name = "m_txtPwd";
            this.m_txtPwd.Size = new System.Drawing.Size(170, 23);
            this.m_txtPwd.TabIndex = 13;
            this.m_txtPwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtPwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 14);
            this.label5.TabIndex = 14;
            this.label5.Text = "数据库实例:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 14);
            this.label4.TabIndex = 12;
            this.label4.Text = "密      码:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 14);
            this.label3.TabIndex = 10;
            this.label3.Text = "用  户  名:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "目标IP地址:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据库类型:";
            // 
            // m_cboType
            // 
            this.m_cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboType.FormattingEnabled = true;
            this.m_cboType.Items.AddRange(new object[] {
            "Sql",
            "Oracle"});
            this.m_cboType.Location = new System.Drawing.Point(95, 28);
            this.m_cboType.Name = "m_cboType";
            this.m_cboType.Size = new System.Drawing.Size(170, 22);
            this.m_cboType.TabIndex = 1;
            this.m_cboType.Validating += new System.ComponentModel.CancelEventHandler(this.m_cboType_Validating);
            this.m_cboType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter_KeyDown);
            // 
            // m_txtUser
            // 
            this.m_txtUser.Location = new System.Drawing.Point(95, 105);
            this.m_txtUser.Name = "m_txtUser";
            this.m_txtUser.Size = new System.Drawing.Size(170, 23);
            this.m_txtUser.TabIndex = 11;
            this.m_txtUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter_KeyDown);
            // 
            // m_btnTest
            // 
            this.m_btnTest.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_btnTest.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnTest.Location = new System.Drawing.Point(12, 236);
            this.m_btnTest.Name = "m_btnTest";
            this.m_btnTest.Size = new System.Drawing.Size(75, 27);
            this.m_btnTest.TabIndex = 1;
            this.m_btnTest.Text = "测试连接";
            this.m_btnTest.UseVisualStyleBackColor = true;
            this.m_btnTest.Click += new System.EventHandler(this.m_btnTest_Click);
            // 
            // frmDbConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 271);
            this.Controls.Add(this.m_btnTest);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_btnClose);
            this.Controls.Add(this.m_btnSave);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDbConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "目标数据库连接配置";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.m_pnlTextContainer.ResumeLayout(false);
            this.m_pnlTextContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_btnSave;
        private System.Windows.Forms.Button m_btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox m_txtDataBase;
        private System.Windows.Forms.TextBox m_txtPwd;
        private System.Windows.Forms.TextBox m_txtUser;
        private System.Windows.Forms.TextBox m_txtIp4;
        private System.Windows.Forms.TextBox m_txtIp3;
        private System.Windows.Forms.TextBox m_txtIp2;
        private System.Windows.Forms.TextBox m_txtIp1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox m_cboType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button m_btnTest;
        private System.Windows.Forms.Panel m_pnlTextContainer;
    }
}