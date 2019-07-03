namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmHolday
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
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtBedCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_txtInPatientID = new System.Windows.Forms.TextBox();
            this.m_txtName = new System.Windows.Forms.TextBox();
            this.m_cmbDays = new System.Windows.Forms.ComboBox();
            this.m_dtStartTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txtSex = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtAge = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.m_cmdOK = new PinkieControls.ButtonXP();
            this.m_cmdCancel = new PinkieControls.ButtonXP();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(42, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 14);
            this.label3.TabIndex = 12;
            this.label3.Text = "住院号:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(56, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 11;
            this.label1.Text = "姓名:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtBedCode
            // 
            this.m_txtBedCode.Location = new System.Drawing.Point(115, 26);
            this.m_txtBedCode.Name = "m_txtBedCode";
            this.m_txtBedCode.ReadOnly = true;
            this.m_txtBedCode.Size = new System.Drawing.Size(144, 23);
            this.m_txtBedCode.TabIndex = 0;
            this.m_txtBedCode.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(42, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 14);
            this.label6.TabIndex = 13;
            this.label6.Text = "床位号:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtInPatientID
            // 
            this.m_txtInPatientID.Location = new System.Drawing.Point(115, 59);
            this.m_txtInPatientID.Name = "m_txtInPatientID";
            this.m_txtInPatientID.ReadOnly = true;
            this.m_txtInPatientID.Size = new System.Drawing.Size(144, 23);
            this.m_txtInPatientID.TabIndex = 1;
            this.m_txtInPatientID.TabStop = false;
            // 
            // m_txtName
            // 
            this.m_txtName.Location = new System.Drawing.Point(115, 92);
            this.m_txtName.Name = "m_txtName";
            this.m_txtName.ReadOnly = true;
            this.m_txtName.Size = new System.Drawing.Size(144, 23);
            this.m_txtName.TabIndex = 2;
            this.m_txtName.TabStop = false;
            // 
            // m_cmbDays
            // 
            this.m_cmbDays.FormattingEnabled = true;
            this.m_cmbDays.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.m_cmbDays.Location = new System.Drawing.Point(115, 224);
            this.m_cmbDays.MaxLength = 3;
            this.m_cmbDays.Name = "m_cmbDays";
            this.m_cmbDays.Size = new System.Drawing.Size(144, 22);
            this.m_cmbDays.TabIndex = 6;
            this.m_cmbDays.Text = "1";
            // 
            // m_dtStartTime
            // 
            this.m_dtStartTime.CustomFormat = "yyyy-MM-dd HH:mm";
            this.m_dtStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtStartTime.Location = new System.Drawing.Point(115, 191);
            this.m_dtStartTime.Name = "m_dtStartTime";
            this.m_dtStartTime.Size = new System.Drawing.Size(144, 23);
            this.m_dtStartTime.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(28, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 16;
            this.label2.Text = "请假时间:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(28, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 17;
            this.label4.Text = "请假天数:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtSex
            // 
            this.m_txtSex.Location = new System.Drawing.Point(115, 125);
            this.m_txtSex.Name = "m_txtSex";
            this.m_txtSex.ReadOnly = true;
            this.m_txtSex.Size = new System.Drawing.Size(144, 23);
            this.m_txtSex.TabIndex = 3;
            this.m_txtSex.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(56, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 14);
            this.label5.TabIndex = 19;
            this.label5.Text = "性别:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtAge
            // 
            this.m_txtAge.Location = new System.Drawing.Point(115, 158);
            this.m_txtAge.Name = "m_txtAge";
            this.m_txtAge.ReadOnly = true;
            this.m_txtAge.Size = new System.Drawing.Size(144, 23);
            this.m_txtAge.TabIndex = 4;
            this.m_txtAge.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(56, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 14);
            this.label7.TabIndex = 21;
            this.label7.Text = "年龄:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_cmdOK
            // 
            this.m_cmdOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdOK.DefaultScheme = true;
            this.m_cmdOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdOK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdOK.Hint = "";
            this.m_cmdOK.Location = new System.Drawing.Point(71, 287);
            this.m_cmdOK.Name = "m_cmdOK";
            this.m_cmdOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdOK.Size = new System.Drawing.Size(91, 31);
            this.m_cmdOK.TabIndex = 1;
            this.m_cmdOK.Text = "确定(&S)";
            this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
            // 
            // m_cmdCancel
            // 
            this.m_cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdCancel.DefaultScheme = true;
            this.m_cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdCancel.Hint = "";
            this.m_cmdCancel.Location = new System.Drawing.Point(180, 287);
            this.m_cmdCancel.Name = "m_cmdCancel";
            this.m_cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCancel.Size = new System.Drawing.Size(91, 31);
            this.m_cmdCancel.TabIndex = 2;
            this.m_cmdCancel.Text = "退出(&C)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.m_txtName);
            this.groupBox1.Controls.Add(this.m_txtInPatientID);
            this.groupBox1.Controls.Add(this.m_txtAge);
            this.groupBox1.Controls.Add(this.m_txtBedCode);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.m_txtSex);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.m_cmbDays);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.m_dtStartTime);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(20, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 280);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // frmHolday
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 330);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_cmdOK);
            this.Controls.Add(this.m_cmdCancel);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHolday";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " 病人请假";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox m_txtBedCode;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox m_txtInPatientID;
        internal System.Windows.Forms.TextBox m_txtName;
        private System.Windows.Forms.ComboBox m_cmbDays;
        private System.Windows.Forms.DateTimePicker m_dtStartTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox m_txtSex;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox m_txtAge;
        private System.Windows.Forms.Label label7;
        private PinkieControls.ButtonXP m_cmdOK;
        private PinkieControls.ButtonXP m_cmdCancel;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}