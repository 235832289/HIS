namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmOrderBookingInf
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
            this.label1 = new System.Windows.Forms.Label();
            this.m_lbArea = new System.Windows.Forms.Label();
            this.m_lbBedNo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_lbName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_lbInPatientId = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_lbOrderName = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.m_txtRemark = new System.Windows.Forms.TextBox();
            this.m_cmdExit = new PinkieControls.ButtonXP();
            this.m_cmdOK = new PinkieControls.ButtonXP();
            this.m_cmbStatus = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_dtpBookDate = new NullableDateControls.MaskDateEdit();
            this.m_lbAge = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "科室";
            // 
            // m_lbArea
            // 
            this.m_lbArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lbArea.Location = new System.Drawing.Point(88, 24);
            this.m_lbArea.Name = "m_lbArea";
            this.m_lbArea.Size = new System.Drawing.Size(138, 19);
            this.m_lbArea.TabIndex = 1;
            // 
            // m_lbBedNo
            // 
            this.m_lbBedNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lbBedNo.Location = new System.Drawing.Point(306, 24);
            this.m_lbBedNo.Name = "m_lbBedNo";
            this.m_lbBedNo.Size = new System.Drawing.Size(54, 19);
            this.m_lbBedNo.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(272, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "床号";
            // 
            // m_lbName
            // 
            this.m_lbName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lbName.Location = new System.Drawing.Point(89, 69);
            this.m_lbName.Name = "m_lbName";
            this.m_lbName.Size = new System.Drawing.Size(138, 19);
            this.m_lbName.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 4;
            this.label4.Text = "姓名";
            // 
            // m_lbInPatientId
            // 
            this.m_lbInPatientId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lbInPatientId.Location = new System.Drawing.Point(307, 69);
            this.m_lbInPatientId.Name = "m_lbInPatientId";
            this.m_lbInPatientId.Size = new System.Drawing.Size(151, 19);
            this.m_lbInPatientId.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(262, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 14);
            this.label5.TabIndex = 6;
            this.label5.Text = "住院号";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 8;
            this.label6.Text = "检查项目";
            // 
            // m_lbOrderName
            // 
            this.m_lbOrderName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lbOrderName.Location = new System.Drawing.Point(89, 118);
            this.m_lbOrderName.Name = "m_lbOrderName";
            this.m_lbOrderName.Size = new System.Drawing.Size(369, 19);
            this.m_lbOrderName.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 223);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 14);
            this.label8.TabIndex = 10;
            this.label8.Text = "注意事项";
            // 
            // m_txtRemark
            // 
            this.m_txtRemark.Location = new System.Drawing.Point(88, 223);
            this.m_txtRemark.MaxLength = 100;
            this.m_txtRemark.Multiline = true;
            this.m_txtRemark.Name = "m_txtRemark";
            this.m_txtRemark.Size = new System.Drawing.Size(370, 191);
            this.m_txtRemark.TabIndex = 2;
            // 
            // m_cmdExit
            // 
            this.m_cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdExit.DefaultScheme = true;
            this.m_cmdExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdExit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdExit.Hint = "";
            this.m_cmdExit.Location = new System.Drawing.Point(394, 423);
            this.m_cmdExit.Name = "m_cmdExit";
            this.m_cmdExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdExit.Size = new System.Drawing.Size(78, 33);
            this.m_cmdExit.TabIndex = 4;
            this.m_cmdExit.Text = "关闭(&E)";
            this.m_cmdExit.Click += new System.EventHandler(this.m_cmdExit_Click);
            // 
            // m_cmdOK
            // 
            this.m_cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdOK.DefaultScheme = true;
            this.m_cmdOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdOK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdOK.Hint = "";
            this.m_cmdOK.Location = new System.Drawing.Point(285, 423);
            this.m_cmdOK.Name = "m_cmdOK";
            this.m_cmdOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdOK.Size = new System.Drawing.Size(78, 33);
            this.m_cmdOK.TabIndex = 3;
            this.m_cmdOK.Text = "确定(&O)";
            this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
            // 
            // m_cmbStatus
            // 
            this.m_cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbStatus.FormattingEnabled = true;
            this.m_cmbStatus.Items.AddRange(new object[] {
            "预约通过",
            "预约未通过"});
            this.m_cmbStatus.Location = new System.Drawing.Point(89, 170);
            this.m_cmbStatus.Name = "m_cmbStatus";
            this.m_cmbStatus.Size = new System.Drawing.Size(139, 22);
            this.m_cmbStatus.TabIndex = 0;
            this.m_cmbStatus.SelectedIndexChanged += new System.EventHandler(this.m_cmbStatus_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 40;
            this.label7.Text = "预约状态";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(244, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 41;
            this.label2.Text = "批准时间";
            // 
            // m_dtpBookDate
            // 
            this.m_dtpBookDate.Location = new System.Drawing.Point(308, 169);
            this.m_dtpBookDate.Mask = "yyyy-MM-dd HH:mm";
            this.m_dtpBookDate.Name = "m_dtpBookDate";
            this.m_dtpBookDate.Size = new System.Drawing.Size(151, 23);
            this.m_dtpBookDate.TabIndex = 1;
            // 
            // m_lbAge
            // 
            this.m_lbAge.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lbAge.Location = new System.Drawing.Point(406, 24);
            this.m_lbAge.Name = "m_lbAge";
            this.m_lbAge.Size = new System.Drawing.Size(52, 19);
            this.m_lbAge.TabIndex = 42;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(373, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 14);
            this.label9.TabIndex = 43;
            this.label9.Text = "年龄";
            // 
            // frmOrderBookingInf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 465);
            this.Controls.Add(this.m_lbAge);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.m_dtpBookDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.m_cmbStatus);
            this.Controls.Add(this.m_cmdExit);
            this.Controls.Add(this.m_cmdOK);
            this.Controls.Add(this.m_txtRemark);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.m_lbOrderName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.m_lbInPatientId);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.m_lbName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_lbBedNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_lbArea);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KeyPreview = true;
            this.Name = "frmOrderBookingInf";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "检查预约信息";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmOrderBookingInf_KeyDown);
            this.Load += new System.EventHandler(this.frmBookingInf_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label m_lbArea;
        internal System.Windows.Forms.Label m_lbBedNo;
        internal System.Windows.Forms.Label m_lbName;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label m_lbInPatientId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label m_lbOrderName;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox m_txtRemark;
        private PinkieControls.ButtonXP m_cmdExit;
        private PinkieControls.ButtonXP m_cmdOK;
        internal System.Windows.Forms.ComboBox m_cmbStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        internal NullableDateControls.MaskDateEdit m_dtpBookDate;
        internal System.Windows.Forms.Label m_lbAge;
        private System.Windows.Forms.Label label9;
    }
}