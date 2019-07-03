namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmUpdateHospitalInfo
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
            this.label13 = new System.Windows.Forms.Label();
            this.m_cmdfind = new PinkieControls.ButtonXP();
            this.cmdCancle = new PinkieControls.ButtonXP();
            this.m_txtRemark = new System.Windows.Forms.TextBox();
            this.buttonXP1 = new PinkieControls.ButtonXP();
            this.buttonXP2 = new PinkieControls.ButtonXP();
            this.buttonXP3 = new PinkieControls.ButtonXP();
            this.buttonXP4 = new PinkieControls.ButtonXP();
            this.m_ucPatientInfo = new com.digitalwave.iCare.gui.HIS.ucPatientInfo();
            this.m_cmdExit = new PinkieControls.ButtonXP();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(329, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 14);
            this.label13.TabIndex = 63;
            this.label13.Text = "备注:";
            // 
            // m_cmdfind
            // 
            this.m_cmdfind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdfind.DefaultScheme = true;
            this.m_cmdfind.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdfind.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdfind.Hint = "";
            this.m_cmdfind.Location = new System.Drawing.Point(528, 681);
            this.m_cmdfind.Name = "m_cmdfind";
            this.m_cmdfind.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdfind.Size = new System.Drawing.Size(91, 34);
            this.m_cmdfind.TabIndex = 61;
            this.m_cmdfind.Text = "查找病人(&F)";
            this.m_cmdfind.Click += new System.EventHandler(this.m_cmdfind_Click);
            // 
            // cmdCancle
            // 
            this.cmdCancle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdCancle.DefaultScheme = true;
            this.cmdCancle.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdCancle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdCancle.Hint = "";
            this.cmdCancle.Location = new System.Drawing.Point(431, 681);
            this.cmdCancle.Name = "cmdCancle";
            this.cmdCancle.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdCancle.Size = new System.Drawing.Size(91, 34);
            this.cmdCancle.TabIndex = 61;
            this.cmdCancle.Text = "撤消入院(&S)";
            this.cmdCancle.Click += new System.EventHandler(this.cmdCancle_Click);
            // 
            // m_txtRemark
            // 
            this.m_txtRemark.Location = new System.Drawing.Point(327, 39);
            this.m_txtRemark.MaxLength = 100;
            this.m_txtRemark.Multiline = true;
            this.m_txtRemark.Name = "m_txtRemark";
            this.m_txtRemark.Size = new System.Drawing.Size(386, 622);
            this.m_txtRemark.TabIndex = 0;
            // 
            // buttonXP1
            // 
            this.buttonXP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP1.DefaultScheme = true;
            this.buttonXP1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonXP1.Hint = "";
            this.buttonXP1.Location = new System.Drawing.Point(126, 470);
            this.buttonXP1.Name = "buttonXP1";
            this.buttonXP1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP1.Size = new System.Drawing.Size(118, 34);
            this.buttonXP1.TabIndex = 64;
            this.buttonXP1.Text = "普通号->留观号";
            this.buttonXP1.Visible = false;
            this.buttonXP1.Click += new System.EventHandler(this.buttonXP1_Click);
            // 
            // buttonXP2
            // 
            this.buttonXP2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP2.DefaultScheme = true;
            this.buttonXP2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonXP2.Hint = "";
            this.buttonXP2.Location = new System.Drawing.Point(5, 470);
            this.buttonXP2.Name = "buttonXP2";
            this.buttonXP2.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP2.Size = new System.Drawing.Size(118, 34);
            this.buttonXP2.TabIndex = 65;
            this.buttonXP2.Text = "普通号->普通号";
            this.buttonXP2.Visible = false;
            this.buttonXP2.Click += new System.EventHandler(this.buttonXP2_Click);
            // 
            // buttonXP3
            // 
            this.buttonXP3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP3.DefaultScheme = true;
            this.buttonXP3.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonXP3.Hint = "";
            this.buttonXP3.Location = new System.Drawing.Point(557, 0);
            this.buttonXP3.Name = "buttonXP3";
            this.buttonXP3.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP3.Size = new System.Drawing.Size(118, 34);
            this.buttonXP3.TabIndex = 66;
            this.buttonXP3.Text = "留观号->普通号";
            this.buttonXP3.Visible = false;
            this.buttonXP3.Click += new System.EventHandler(this.buttonXP3_Click);
            // 
            // buttonXP4
            // 
            this.buttonXP4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP4.DefaultScheme = true;
            this.buttonXP4.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonXP4.Hint = "";
            this.buttonXP4.Location = new System.Drawing.Point(433, 0);
            this.buttonXP4.Name = "buttonXP4";
            this.buttonXP4.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP4.Size = new System.Drawing.Size(118, 34);
            this.buttonXP4.TabIndex = 67;
            this.buttonXP4.Text = "留观号->留观号";
            this.buttonXP4.Visible = false;
            this.buttonXP4.Click += new System.EventHandler(this.buttonXP4_Click);
            // 
            // m_ucPatientInfo
            // 
            this.m_ucPatientInfo.BackColor = System.Drawing.SystemColors.Control;
            this.m_ucPatientInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_ucPatientInfo.IsChanged = false;
            this.m_ucPatientInfo.Location = new System.Drawing.Point(0, 0);
            this.m_ucPatientInfo.Name = "m_ucPatientInfo";
            this.m_ucPatientInfo.Size = new System.Drawing.Size(315, 755);
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
            this.m_cmdExit.Location = new System.Drawing.Point(622, 681);
            this.m_cmdExit.Name = "m_cmdExit";
            this.m_cmdExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdExit.Size = new System.Drawing.Size(91, 34);
            this.m_cmdExit.TabIndex = 69;
            this.m_cmdExit.Text = "关闭(&Esc)";
            this.m_cmdExit.Click += new System.EventHandler(this.m_cmdExit_Click);
            // 
            // frmUpdateHospitalInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 755);
            this.Controls.Add(this.m_txtRemark);
            this.Controls.Add(this.m_cmdExit);
            this.Controls.Add(this.m_ucPatientInfo);
            this.Controls.Add(this.buttonXP4);
            this.Controls.Add(this.buttonXP3);
            this.Controls.Add(this.buttonXP2);
            this.Controls.Add(this.buttonXP1);
            this.Controls.Add(this.m_cmdfind);
            this.Controls.Add(this.cmdCancle);
            this.Controls.Add(this.label13);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmUpdateHospitalInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "撤消入院";
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.frmUpdateHospitalInfo_Layout);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmUpdateHospitalInfo_KeyDown);
            this.Load += new System.EventHandler(this.frmUpdateHospitalInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal PinkieControls.ButtonXP cmdCancle;
        internal PinkieControls.ButtonXP m_cmdfind;
        internal System.Windows.Forms.TextBox m_txtRemark;
        private System.Windows.Forms.Label label13;
        internal PinkieControls.ButtonXP buttonXP1;
        internal PinkieControls.ButtonXP buttonXP2;
        internal PinkieControls.ButtonXP buttonXP3;
        internal PinkieControls.ButtonXP buttonXP4;
        internal PinkieControls.ButtonXP m_cmdExit;
        internal ucPatientInfo m_ucPatientInfo;
    }
}