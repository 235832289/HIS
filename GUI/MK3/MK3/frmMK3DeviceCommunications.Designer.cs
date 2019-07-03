namespace com.digitalwave.iCare.gui.LIS
{
    partial class frmMK3DeviceCommunications
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMK3DeviceCommunications));
            this.m_chAirBlank = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cboJinPlateWay = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_cboShockSpeed = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_chWavelength = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_cboFilter = new System.Windows.Forms.ComboBox();
            this.m_btnSave = new System.Windows.Forms.Button();
            this.m_btnExit = new System.Windows.Forms.Button();
            this.m_txtShockTime = new System.Windows.Forms.TextBox();
            this.m_blnDelete = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.m_cboDeputyFilter = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // m_chAirBlank
            // 
            this.m_chAirBlank.AutoSize = true;
            this.m_chAirBlank.Location = new System.Drawing.Point(39, 31);
            this.m_chAirBlank.Name = "m_chAirBlank";
            this.m_chAirBlank.Size = new System.Drawing.Size(82, 18);
            this.m_chAirBlank.TabIndex = 0;
            this.m_chAirBlank.Text = "空气空白";
            this.m_chAirBlank.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "进板方式";
            // 
            // m_cboJinPlateWay
            // 
            this.m_cboJinPlateWay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboJinPlateWay.FormattingEnabled = true;
            this.m_cboJinPlateWay.Items.AddRange(new object[] {
            "持续进板",
            "逐步进板"});
            this.m_cboJinPlateWay.Location = new System.Drawing.Point(114, 82);
            this.m_cboJinPlateWay.Name = "m_cboJinPlateWay";
            this.m_cboJinPlateWay.Size = new System.Drawing.Size(121, 22);
            this.m_cboJinPlateWay.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(259, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "震荡速度";
            // 
            // m_cboShockSpeed
            // 
            this.m_cboShockSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboShockSpeed.FormattingEnabled = true;
            this.m_cboShockSpeed.Items.AddRange(new object[] {
            "快速震荡",
            "中速震荡",
            "慢速震荡"});
            this.m_cboShockSpeed.Location = new System.Drawing.Point(341, 79);
            this.m_cboShockSpeed.Name = "m_cboShockSpeed";
            this.m_cboShockSpeed.Size = new System.Drawing.Size(121, 22);
            this.m_cboShockSpeed.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(259, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "震荡时间";
            // 
            // m_chWavelength
            // 
            this.m_chWavelength.AutoSize = true;
            this.m_chWavelength.Location = new System.Drawing.Point(39, 173);
            this.m_chWavelength.Name = "m_chWavelength";
            this.m_chWavelength.Size = new System.Drawing.Size(68, 18);
            this.m_chWavelength.TabIndex = 7;
            this.m_chWavelength.Text = "双波长";
            this.m_chWavelength.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "滤光片";
            // 
            // m_cboFilter
            // 
            this.m_cboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboFilter.FormattingEnabled = true;
            this.m_cboFilter.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.m_cboFilter.Location = new System.Drawing.Point(105, 220);
            this.m_cboFilter.Name = "m_cboFilter";
            this.m_cboFilter.Size = new System.Drawing.Size(121, 22);
            this.m_cboFilter.TabIndex = 9;
            // 
            // m_btnSave
            // 
            this.m_btnSave.Location = new System.Drawing.Point(55, 281);
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Size = new System.Drawing.Size(76, 39);
            this.m_btnSave.TabIndex = 23;
            this.m_btnSave.Text = "保存";
            this.m_btnSave.UseVisualStyleBackColor = true;
            this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
            // 
            // m_btnExit
            // 
            this.m_btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnExit.Location = new System.Drawing.Point(325, 281);
            this.m_btnExit.Name = "m_btnExit";
            this.m_btnExit.Size = new System.Drawing.Size(76, 39);
            this.m_btnExit.TabIndex = 24;
            this.m_btnExit.Text = "退出";
            this.m_btnExit.UseVisualStyleBackColor = true;
            this.m_btnExit.Click += new System.EventHandler(this.m_btnExit_Click);
            // 
            // m_txtShockTime
            // 
            this.m_txtShockTime.Location = new System.Drawing.Point(341, 134);
            this.m_txtShockTime.Name = "m_txtShockTime";
            this.m_txtShockTime.Size = new System.Drawing.Size(121, 23);
            this.m_txtShockTime.TabIndex = 25;
            // 
            // m_blnDelete
            // 
            this.m_blnDelete.Location = new System.Drawing.Point(190, 281);
            this.m_blnDelete.Name = "m_blnDelete";
            this.m_blnDelete.Size = new System.Drawing.Size(76, 39);
            this.m_blnDelete.TabIndex = 26;
            this.m_blnDelete.Text = "删除";
            this.m_blnDelete.UseVisualStyleBackColor = true;
            this.m_blnDelete.Click += new System.EventHandler(this.m_blnDelete_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(259, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 27;
            this.label5.Text = "副滤光片";
            // 
            // m_cboDeputyFilter
            // 
            this.m_cboDeputyFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboDeputyFilter.FormattingEnabled = true;
            this.m_cboDeputyFilter.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.m_cboDeputyFilter.Location = new System.Drawing.Point(341, 220);
            this.m_cboDeputyFilter.Name = "m_cboDeputyFilter";
            this.m_cboDeputyFilter.Size = new System.Drawing.Size(121, 22);
            this.m_cboDeputyFilter.TabIndex = 28;
            // 
            // frmMK3DeviceCommunications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 332);
            this.Controls.Add(this.m_cboDeputyFilter);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.m_blnDelete);
            this.Controls.Add(this.m_txtShockTime);
            this.Controls.Add(this.m_btnExit);
            this.Controls.Add(this.m_btnSave);
            this.Controls.Add(this.m_cboFilter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_chWavelength);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_cboShockSpeed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_cboJinPlateWay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_chAirBlank);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMK3DeviceCommunications";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MK3酶标仪项目仪器通讯设置";
            this.Load += new System.EventHandler(this.frmMK3DeviceCommunications_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button m_btnSave;
        private System.Windows.Forms.Button m_btnExit;
        internal System.Windows.Forms.CheckBox m_chAirBlank;
        internal System.Windows.Forms.ComboBox m_cboJinPlateWay;
        internal System.Windows.Forms.ComboBox m_cboShockSpeed;
        internal System.Windows.Forms.CheckBox m_chWavelength;
        internal System.Windows.Forms.ComboBox m_cboFilter;
        internal System.Windows.Forms.TextBox m_txtShockTime;
        private System.Windows.Forms.Button m_blnDelete;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.ComboBox m_cboDeputyFilter;
    }
}