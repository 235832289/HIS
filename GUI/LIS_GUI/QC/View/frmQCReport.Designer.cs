namespace com.digitalwave.iCare.gui.LIS
{
    partial class frmQCReport
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_lblSeq = new System.Windows.Forms.Label();
            this.m_dtpReport = new System.Windows.Forms.DateTimePicker();
            this.m_chkLost = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtAppDoct = new com.digitalwave.Utility.ctlEmpTextBox();
            this.m_txtUnmatchedRule = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.m_lblBatchNO = new System.Windows.Forms.Label();
            this.m_txtReason = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtProcess = new System.Windows.Forms.TextBox();
            this.m_txtSummary = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_btnCancel = new PinkieControls.ButtonXP();
            this.m_btnSave = new PinkieControls.ButtonXP();
            this.m_cmdAddBrokenRules = new PinkieControls.ButtonXP();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(431, 368);
            this.panel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_cmdAddBrokenRules);
            this.groupBox1.Controls.Add(this.m_lblSeq);
            this.groupBox1.Controls.Add(this.m_dtpReport);
            this.groupBox1.Controls.Add(this.m_chkLost);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.m_txtAppDoct);
            this.groupBox1.Controls.Add(this.m_txtUnmatchedRule);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.m_lblBatchNO);
            this.groupBox1.Controls.Add(this.m_txtReason);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.m_txtProcess);
            this.groupBox1.Controls.Add(this.m_txtSummary);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(431, 368);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.m_lblSeq.AutoSize = true;
            this.m_lblSeq.Location = new System.Drawing.Point(40, 22);
            this.m_lblSeq.Name = "m_lblSeq";
            this.m_lblSeq.Size = new System.Drawing.Size(84, 14);
            this.m_lblSeq.TabIndex = 0;
            this.m_lblSeq.Text = "质控批序号:";

            // 
            // m_dtpReport
            // 
            this.m_dtpReport.CustomFormat = "yyyy-MM-dd";
            this.m_dtpReport.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpReport.Location = new System.Drawing.Point(289, 328);
            this.m_dtpReport.Name = "m_dtpReport";
            this.m_dtpReport.Size = new System.Drawing.Size(101, 23);
            this.m_dtpReport.TabIndex = 6;
            // 
            // m_chkLost
            // 
            this.m_chkLost.AutoSize = true;
            this.m_chkLost.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_chkLost.Location = new System.Drawing.Point(51, 54);
            this.m_chkLost.Name = "m_chkLost";
            this.m_chkLost.Size = new System.Drawing.Size(89, 18);
            this.m_chkLost.TabIndex = 0;
            this.m_chkLost.Text = "失    控:";
            this.m_chkLost.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "违反的质控规则:";
            // 
            // m_txtAppDoct
            // 
            this.m_txtAppDoct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_txtAppDoct.EnableAutoValidation = true;
            this.m_txtAppDoct.EnableEnterKeyValidate = true;
            this.m_txtAppDoct.EnableEscapeKeyUndo = true;
            this.m_txtAppDoct.EnableLastValidValue = true;
            this.m_txtAppDoct.ErrorProvider = null;
            this.m_txtAppDoct.ErrorProviderMessage = "Invalid value";
            this.m_txtAppDoct.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtAppDoct.ForceFormatText = true;
            this.m_txtAppDoct.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtAppDoct.Location = new System.Drawing.Point(289, 302);
            this.m_txtAppDoct.m_intShowOtherEmp = 0;
            this.m_txtAppDoct.m_StrDeptID = "*";
            this.m_txtAppDoct.m_StrEmployeeID = null;
            this.m_txtAppDoct.m_StrEmployeeName = null;
            this.m_txtAppDoct.MaxLength = 20;
            this.m_txtAppDoct.Name = "m_txtAppDoct";
            this.m_txtAppDoct.Size = new System.Drawing.Size(101, 23);
            this.m_txtAppDoct.TabIndex = 5;
            // 
            // m_txtUnmatchedRule
            // 
            this.m_txtUnmatchedRule.Location = new System.Drawing.Point(125, 78);
            this.m_txtUnmatchedRule.MaxLength = 50;
            this.m_txtUnmatchedRule.Multiline = true;
            this.m_txtUnmatchedRule.Name = "m_txtUnmatchedRule";
            this.m_txtUnmatchedRule.Size = new System.Drawing.Size(296, 37);
            this.m_txtUnmatchedRule.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(219, 332);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 14);
            this.label8.TabIndex = 17;
            this.label8.Text = "报告日期:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "失控原因:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(232, 308);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 14);
            this.label7.TabIndex = 15;
            this.label7.Text = "报告人:";
            // 
            // m_lblBatchNO
            // 
            this.m_lblBatchNO.AutoSize = true;
            this.m_lblBatchNO.ForeColor = System.Drawing.Color.Blue;
            this.m_lblBatchNO.Location = new System.Drawing.Point(126, 23);
            this.m_lblBatchNO.Name = "m_lblBatchNO";
            this.m_lblBatchNO.Size = new System.Drawing.Size(0, 14);
            this.m_lblBatchNO.TabIndex = 18;
            // 
            // m_txtReason
            // 
            this.m_txtReason.Location = new System.Drawing.Point(125, 123);
            this.m_txtReason.MaxLength = 250;
            this.m_txtReason.Multiline = true;
            this.m_txtReason.Name = "m_txtReason";
            this.m_txtReason.Size = new System.Drawing.Size(296, 48);
            this.m_txtReason.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "失控处理:";
            // 
            // m_txtProcess
            // 
            this.m_txtProcess.Location = new System.Drawing.Point(125, 181);
            this.m_txtProcess.MaxLength = 250;
            this.m_txtProcess.Multiline = true;
            this.m_txtProcess.Name = "m_txtProcess";
            this.m_txtProcess.Size = new System.Drawing.Size(296, 46);
            this.m_txtProcess.TabIndex = 3;
            // 
            // m_txtSummary
            // 
            this.m_txtSummary.Location = new System.Drawing.Point(125, 237);
            this.m_txtSummary.MaxLength = 250;
            this.m_txtSummary.Multiline = true;
            this.m_txtSummary.Name = "m_txtSummary";
            this.m_txtSummary.Size = new System.Drawing.Size(296, 46);
            this.m_txtSummary.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(81, 247);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 14);
            this.label6.TabIndex = 10;
            this.label6.Text = "备注:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_btnCancel);
            this.panel1.Controls.Add(this.m_btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 368);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(431, 64);
            this.panel1.TabIndex = 2;
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnCancel.DefaultScheme = true;
            this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnCancel.Hint = "";
            this.m_btnCancel.Location = new System.Drawing.Point(315, 12);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnCancel.Size = new System.Drawing.Size(103, 37);
            this.m_btnCancel.TabIndex = 1;
            this.m_btnCancel.Text = "取消(ESC)";
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // m_btnSave
            // 
            this.m_btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnSave.DefaultScheme = true;
            this.m_btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnSave.Hint = "";
            this.m_btnSave.Location = new System.Drawing.Point(207, 12);
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnSave.Size = new System.Drawing.Size(103, 37);
            this.m_btnSave.TabIndex = 0;
            this.m_btnSave.Text = "确定";
            this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
            // 
            // m_cmdAddBrokenRules
            // 
            this.m_cmdAddBrokenRules.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdAddBrokenRules.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdAddBrokenRules.DefaultScheme = true;
            this.m_cmdAddBrokenRules.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAddBrokenRules.Hint = "";
            this.m_cmdAddBrokenRules.Location = new System.Drawing.Point(296, 46);
            this.m_cmdAddBrokenRules.Name = "m_cmdAddBrokenRules";
            this.m_cmdAddBrokenRules.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAddBrokenRules.Size = new System.Drawing.Size(127, 29);
            this.m_cmdAddBrokenRules.TabIndex = 7;
            this.m_cmdAddBrokenRules.Text = "复用分析结果";
            this.m_cmdAddBrokenRules.Click += new System.EventHandler(this.m_cmdAddBrokenRules_Click);
            // 
            // frmQCReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 432);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQCReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "质控报告";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmQCReport_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_KeyDown);
            this.Load += new System.EventHandler(this.frmQCReport_Load);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox m_txtReason;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox m_txtUnmatchedRule;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label m_lblSeq;
        private System.Windows.Forms.TextBox m_txtSummary;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox m_txtProcess;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private PinkieControls.ButtonXP m_btnSave;
        private PinkieControls.ButtonXP m_btnCancel;
        private System.Windows.Forms.Label m_lblBatchNO;
        private System.Windows.Forms.Label label8;
        internal com.digitalwave.Utility.ctlEmpTextBox m_txtAppDoct;
        private System.Windows.Forms.DateTimePicker m_dtpReport;
        private System.Windows.Forms.CheckBox m_chkLost;
        private System.Windows.Forms.GroupBox groupBox1;
        private PinkieControls.ButtonXP m_cmdAddBrokenRules;
        //internal System.Windows.Forms.Label m_lblSeq;

    }
}