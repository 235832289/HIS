namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmModifyOutDate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModifyOutDate));
            this.label13 = new System.Windows.Forms.Label();
            this.m_cmdfind = new PinkieControls.ButtonXP();
            this.m_cmdSave = new PinkieControls.ButtonXP();
            this.m_txtRemark = new System.Windows.Forms.TextBox();
            this.buttonXP1 = new PinkieControls.ButtonXP();
            this.buttonXP2 = new PinkieControls.ButtonXP();
            this.m_ucPatientInfo = new com.digitalwave.iCare.gui.HIS.ucPatientInfo();
            this.m_cmdExit = new PinkieControls.ButtonXP();
            this.m_lbOldOutDate = new System.Windows.Forms.Label();
            this.m_dtpOldDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.m_dtpNewDate = new System.Windows.Forms.DateTimePicker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 197);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 14);
            this.label13.TabIndex = 63;
            this.label13.Text = "备注信息:";
            // 
            // m_cmdfind
            // 
            this.m_cmdfind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdfind.DefaultScheme = true;
            this.m_cmdfind.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdfind.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdfind.Hint = "";
            this.m_cmdfind.Location = new System.Drawing.Point(405, 5);
            this.m_cmdfind.Name = "m_cmdfind";
            this.m_cmdfind.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdfind.Size = new System.Drawing.Size(91, 30);
            this.m_cmdfind.TabIndex = 61;
            this.m_cmdfind.Text = "查找病人(&F)";
            this.m_cmdfind.Visible = false;
            // 
            // m_cmdSave
            // 
            this.m_cmdSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdSave.DefaultScheme = true;
            this.m_cmdSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSave.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdSave.Hint = "";
            this.m_cmdSave.Location = new System.Drawing.Point(605, 37);
            this.m_cmdSave.Name = "m_cmdSave";
            this.m_cmdSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSave.Size = new System.Drawing.Size(105, 38);
            this.m_cmdSave.TabIndex = 61;
            this.m_cmdSave.Text = "保存(&S)";
            this.m_cmdSave.Click += new System.EventHandler(this.m_cmdSave_Click);
            // 
            // m_txtRemark
            // 
            this.m_txtRemark.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtRemark.Location = new System.Drawing.Point(3, 223);
            this.m_txtRemark.MaxLength = 100;
            this.m_txtRemark.Multiline = true;
            this.m_txtRemark.Name = "m_txtRemark";
            this.m_txtRemark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.m_txtRemark.Size = new System.Drawing.Size(735, 404);
            this.m_txtRemark.TabIndex = 1;
            // 
            // buttonXP1
            // 
            this.buttonXP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP1.DefaultScheme = true;
            this.buttonXP1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP1.Hint = "";
            this.buttonXP1.Location = new System.Drawing.Point(0, 0);
            this.buttonXP1.Name = "buttonXP1";
            this.buttonXP1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP1.Size = new System.Drawing.Size(10, 10);
            this.buttonXP1.TabIndex = 75;
            // 
            // buttonXP2
            // 
            this.buttonXP2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP2.DefaultScheme = true;
            this.buttonXP2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP2.Hint = "";
            this.buttonXP2.Location = new System.Drawing.Point(0, 0);
            this.buttonXP2.Name = "buttonXP2";
            this.buttonXP2.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP2.Size = new System.Drawing.Size(10, 10);
            this.buttonXP2.TabIndex = 74;
            // 
            // m_ucPatientInfo
            // 
            this.m_ucPatientInfo.BackColor = System.Drawing.SystemColors.Control;
            this.m_ucPatientInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_ucPatientInfo.IsChanged = false;
            this.m_ucPatientInfo.Location = new System.Drawing.Point(0, 0);
            this.m_ucPatientInfo.Name = "m_ucPatientInfo";
            this.m_ucPatientInfo.Size = new System.Drawing.Size(259, 630);
            this.m_ucPatientInfo.Status = 0;
            this.m_ucPatientInfo.TabIndex = 68;
            this.m_ucPatientInfo.ZyhChanged += new com.digitalwave.iCare.gui.HIS.TextZyhChanged(this.m_ucPatientInfo_ZyhChanged);
            this.m_ucPatientInfo.CardNOChanged += new com.digitalwave.iCare.gui.HIS.TextCardNOChanged(this.m_ucPatientInfo_CardNOChanged);
            // 
            // m_cmdExit
            // 
            this.m_cmdExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdExit.DefaultScheme = true;
            this.m_cmdExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdExit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdExit.Hint = "";
            this.m_cmdExit.Location = new System.Drawing.Point(607, 96);
            this.m_cmdExit.Name = "m_cmdExit";
            this.m_cmdExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdExit.Size = new System.Drawing.Size(105, 38);
            this.m_cmdExit.TabIndex = 69;
            this.m_cmdExit.Text = "关闭(&Esc)";
            this.m_cmdExit.Click += new System.EventHandler(this.m_cmdExit_Click);
            // 
            // m_lbOldOutDate
            // 
            this.m_lbOldOutDate.AutoSize = true;
            this.m_lbOldOutDate.Location = new System.Drawing.Point(8, 17);
            this.m_lbOldOutDate.Name = "m_lbOldOutDate";
            this.m_lbOldOutDate.Size = new System.Drawing.Size(91, 14);
            this.m_lbOldOutDate.TabIndex = 70;
            this.m_lbOldOutDate.Text = "原出院日期：";
            // 
            // m_dtpOldDate
            // 
            this.m_dtpOldDate.CalendarFont = new System.Drawing.Font("宋体", 10.5F);
            this.m_dtpOldDate.CustomFormat = "yyyy年MM月dd日 HH时mm分ss秒";
            this.m_dtpOldDate.Enabled = false;
            this.m_dtpOldDate.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpOldDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpOldDate.Location = new System.Drawing.Point(9, 39);
            this.m_dtpOldDate.Name = "m_dtpOldDate";
            this.m_dtpOldDate.Size = new System.Drawing.Size(433, 41);
            this.m_dtpOldDate.TabIndex = 71;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 14);
            this.label1.TabIndex = 72;
            this.label1.Text = "新出院日期：";
            // 
            // m_dtpNewDate
            // 
            this.m_dtpNewDate.CustomFormat = "yyyy年MM月dd日 HH时mm分ss秒";
            this.m_dtpNewDate.Font = new System.Drawing.Font("宋体", 21.75F);
            this.m_dtpNewDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpNewDate.Location = new System.Drawing.Point(9, 125);
            this.m_dtpNewDate.Name = "m_dtpNewDate";
            this.m_dtpNewDate.Size = new System.Drawing.Size(433, 41);
            this.m_dtpNewDate.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(1014, 634);
            this.splitContainer1.SplitterDistance = 263;
            this.splitContainer1.TabIndex = 76;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.m_ucPatientInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(263, 634);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.m_cmdExit);
            this.panel2.Controls.Add(this.m_txtRemark);
            this.panel2.Controls.Add(this.m_lbOldOutDate);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.m_cmdSave);
            this.panel2.Controls.Add(this.m_dtpNewDate);
            this.panel2.Controls.Add(this.m_dtpOldDate);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(747, 634);
            this.panel2.TabIndex = 73;
            // 
            // frmModifyOutDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 634);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.buttonXP2);
            this.Controls.Add(this.buttonXP1);
            this.Controls.Add(this.m_cmdfind);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmModifyOutDate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改预出院时间";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal PinkieControls.ButtonXP m_cmdSave;
        internal PinkieControls.ButtonXP m_cmdfind;
        internal System.Windows.Forms.TextBox m_txtRemark;
        private System.Windows.Forms.Label label13;
        internal PinkieControls.ButtonXP buttonXP1;
        internal PinkieControls.ButtonXP buttonXP2;
        internal PinkieControls.ButtonXP m_cmdExit;
        internal ucPatientInfo m_ucPatientInfo;
        private System.Windows.Forms.Label m_lbOldOutDate;
        internal System.Windows.Forms.DateTimePicker m_dtpOldDate;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.DateTimePicker m_dtpNewDate;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}