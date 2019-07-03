namespace com.digitalwave.iCare.gui.LIS
{
    partial class frmWorkStatstic
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
            this.dwResult = new Sybase.DataWindow.DataWindowControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCondition = new com.digitalwave.Utility.ctlEmpTextBox();
            this.lblNotice = new System.Windows.Forms.Label();
            this.cboDept = new System.Windows.Forms.ComboBox();
            this.cboCondition = new System.Windows.Forms.ComboBox();
            this.lblQueryCondition = new System.Windows.Forms.Label();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.m_dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.m_dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.cmdExit = new PinkieControls.ButtonXP();
            this.cmdPrint = new PinkieControls.ButtonXP();
            this.cmdQuery = new PinkieControls.ButtonXP();
            this.cmdExport = new PinkieControls.ButtonXP();
            this.panel2 = new System.Windows.Forms.Panel();
            this.sfdSave = new System.Windows.Forms.SaveFileDialog();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_rdbConfig = new System.Windows.Forms.RadioButton();
            this.m_rdbAppDat = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dwResult
            // 
            this.dwResult.DataWindowObject = "";
            this.dwResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwResult.LibraryList = "";
            this.dwResult.Location = new System.Drawing.Point(0, 0);
            this.dwResult.Name = "dwResult";
            this.dwResult.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwResult.Size = new System.Drawing.Size(1028, 511);
            this.dwResult.TabIndex = 0;
            this.dwResult.Text = "dataWindowControl1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.txtCondition);
            this.panel1.Controls.Add(this.lblNotice);
            this.panel1.Controls.Add(this.cboDept);
            this.panel1.Controls.Add(this.cboCondition);
            this.panel1.Controls.Add(this.lblQueryCondition);
            this.panel1.Controls.Add(this.lblDateFrom);
            this.panel1.Controls.Add(this.lblDateTo);
            this.panel1.Controls.Add(this.m_dtpFromDate);
            this.panel1.Controls.Add(this.m_dtpToDate);
            this.panel1.Controls.Add(this.cmdExit);
            this.panel1.Controls.Add(this.cmdPrint);
            this.panel1.Controls.Add(this.cmdQuery);
            this.panel1.Controls.Add(this.cmdExport);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1028, 87);
            this.panel1.TabIndex = 1;
            // 
            // txtCondition
            // 
            this.txtCondition.EnableAutoValidation = true;
            this.txtCondition.EnableEnterKeyValidate = true;
            this.txtCondition.EnableEscapeKeyUndo = true;
            this.txtCondition.EnableLastValidValue = true;
            this.txtCondition.ErrorProvider = null;
            this.txtCondition.ErrorProviderMessage = "Invalid value";
            this.txtCondition.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCondition.ForceFormatText = true;
            this.txtCondition.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCondition.Location = new System.Drawing.Point(155, 38);
            this.txtCondition.m_intShowOtherEmp = 0;
            this.txtCondition.m_StrDeptID = "*";
            this.txtCondition.m_StrEmployeeID = null;
            this.txtCondition.m_StrEmployeeName = null;
            this.txtCondition.MaxLength = 20;
            this.txtCondition.Name = "txtCondition";
            this.txtCondition.Size = new System.Drawing.Size(120, 23);
            this.txtCondition.TabIndex = 159;
            // 
            // lblNotice
            // 
            this.lblNotice.AutoSize = true;
            this.lblNotice.Location = new System.Drawing.Point(152, 65);
            this.lblNotice.Name = "lblNotice";
            this.lblNotice.Size = new System.Drawing.Size(119, 14);
            this.lblNotice.TabIndex = 158;
            this.lblNotice.Text = "(输入工号或拼音)";
            this.lblNotice.Visible = false;
            // 
            // cboDept
            // 
            this.cboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDept.FormattingEnabled = true;
            this.cboDept.Location = new System.Drawing.Point(155, 39);
            this.cboDept.Name = "cboDept";
            this.cboDept.Size = new System.Drawing.Size(121, 22);
            this.cboDept.TabIndex = 156;
            this.cboDept.Visible = false;
            // 
            // cboCondition
            // 
            this.cboCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCondition.FormattingEnabled = true;
            this.cboCondition.Location = new System.Drawing.Point(22, 39);
            this.cboCondition.Name = "cboCondition";
            this.cboCondition.Size = new System.Drawing.Size(125, 22);
            this.cboCondition.TabIndex = 155;
            this.cboCondition.SelectedIndexChanged += new System.EventHandler(this.cboCondition_SelectedIndexChanged);
            // 
            // lblQueryCondition
            // 
            this.lblQueryCondition.AutoSize = true;
            this.lblQueryCondition.Location = new System.Drawing.Point(11, 11);
            this.lblQueryCondition.Name = "lblQueryCondition";
            this.lblQueryCondition.Size = new System.Drawing.Size(98, 14);
            this.lblQueryCondition.TabIndex = 154;
            this.lblQueryCondition.Text = "查询条件 按：";
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(287, 41);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(63, 14);
            this.lblDateFrom.TabIndex = 153;
            this.lblDateFrom.Text = "审核日期";
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Location = new System.Drawing.Point(460, 41);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(21, 14);
            this.lblDateTo.TabIndex = 152;
            this.lblDateTo.Text = "至";
            // 
            // m_dtpFromDate
            // 
            this.m_dtpFromDate.CustomFormat = "yyyy-MM-dd";
            this.m_dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpFromDate.Location = new System.Drawing.Point(355, 37);
            this.m_dtpFromDate.Name = "m_dtpFromDate";
            this.m_dtpFromDate.Size = new System.Drawing.Size(96, 23);
            this.m_dtpFromDate.TabIndex = 150;
            this.m_dtpFromDate.Value = new System.DateTime(2009, 1, 21, 0, 0, 0, 0);
            // 
            // m_dtpToDate
            // 
            this.m_dtpToDate.CustomFormat = "yyyy-MM-dd";
            this.m_dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpToDate.Location = new System.Drawing.Point(489, 37);
            this.m_dtpToDate.Name = "m_dtpToDate";
            this.m_dtpToDate.Size = new System.Drawing.Size(96, 23);
            this.m_dtpToDate.TabIndex = 151;
            // 
            // cmdExit
            // 
            this.cmdExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.cmdExit.DefaultScheme = true;
            this.cmdExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdExit.Hint = "";
            this.cmdExit.Location = new System.Drawing.Point(907, 25);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdExit.Size = new System.Drawing.Size(76, 36);
            this.cmdExit.TabIndex = 149;
            this.cmdExit.Text = "退出(RSC)";
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // cmdPrint
            // 
            this.cmdPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.cmdPrint.DefaultScheme = true;
            this.cmdPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdPrint.Hint = "";
            this.cmdPrint.Location = new System.Drawing.Point(709, 25);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdPrint.Size = new System.Drawing.Size(75, 36);
            this.cmdPrint.TabIndex = 148;
            this.cmdPrint.Text = "打印(F4)";
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // cmdQuery
            // 
            this.cmdQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.cmdQuery.DefaultScheme = true;
            this.cmdQuery.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdQuery.Hint = "";
            this.cmdQuery.Location = new System.Drawing.Point(600, 25);
            this.cmdQuery.Name = "cmdQuery";
            this.cmdQuery.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdQuery.Size = new System.Drawing.Size(85, 36);
            this.cmdQuery.TabIndex = 147;
            this.cmdQuery.Text = "查询(F3)";
            this.cmdQuery.Click += new System.EventHandler(this.cmdQuery_Click);
            // 
            // cmdExport
            // 
            this.cmdExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.cmdExport.DefaultScheme = true;
            this.cmdExport.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdExport.Hint = "";
            this.cmdExport.Location = new System.Drawing.Point(813, 25);
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdExport.Size = new System.Drawing.Size(73, 36);
            this.cmdExport.TabIndex = 146;
            this.cmdExport.Text = "导出(F5)";
            this.cmdExport.Click += new System.EventHandler(this.cmdExport_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dwResult);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 87);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1028, 511);
            this.panel2.TabIndex = 2;
            // 
            // sfdSave
            // 
            this.sfdSave.DefaultExt = "xls";
            this.sfdSave.Filter = "excel文件|*.xls";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "EMPNO_CHR";
            this.dataGridViewTextBoxColumn1.HeaderText = "工号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 65;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "LASTNAME_VCHR";
            this.dataGridViewTextBoxColumn2.HeaderText = "姓名";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 60;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.m_rdbAppDat);
            this.panel3.Controls.Add(this.m_rdbConfig);
            this.panel3.Location = new System.Drawing.Point(290, 7);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(295, 26);
            this.panel3.TabIndex = 160;
            // 
            // m_rdbConfig
            // 
            this.m_rdbConfig.AutoSize = true;
            this.m_rdbConfig.Checked = true;
            this.m_rdbConfig.Location = new System.Drawing.Point(27, 5);
            this.m_rdbConfig.Name = "m_rdbConfig";
            this.m_rdbConfig.Size = new System.Drawing.Size(95, 18);
            this.m_rdbConfig.TabIndex = 0;
            this.m_rdbConfig.TabStop = true;
            this.m_rdbConfig.Text = "按审核日期";
            this.m_rdbConfig.UseVisualStyleBackColor = true;
            this.m_rdbConfig.CheckedChanged += new System.EventHandler(this.m_rdbConfig_CheckedChanged);
            // 
            // m_rdbAppDat
            // 
            this.m_rdbAppDat.AutoSize = true;
            this.m_rdbAppDat.Location = new System.Drawing.Point(169, 4);
            this.m_rdbAppDat.Name = "m_rdbAppDat";
            this.m_rdbAppDat.Size = new System.Drawing.Size(95, 18);
            this.m_rdbAppDat.TabIndex = 0;
            this.m_rdbAppDat.Text = "按申请日期";
            this.m_rdbAppDat.UseVisualStyleBackColor = true;
            this.m_rdbAppDat.CheckedChanged += new System.EventHandler(this.m_rdbAppDat_CheckedChanged);
            // 
            // frmWorkStatstic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 598);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KeyPreview = true;
            this.Name = "frmWorkStatstic";
            this.Text = "统计工作量";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmWorkStatstic_KeyDown);
            this.Load += new System.EventHandler(this.frmWorkStatstic_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        internal PinkieControls.ButtonXP cmdExport;
        internal PinkieControls.ButtonXP cmdPrint;
        internal PinkieControls.ButtonXP cmdQuery;
        internal PinkieControls.ButtonXP cmdExit;
        internal System.Windows.Forms.Label lblDateFrom;
        internal System.Windows.Forms.Label lblDateTo;
        internal System.Windows.Forms.DateTimePicker m_dtpFromDate;
        internal System.Windows.Forms.DateTimePicker m_dtpToDate;
        internal System.Windows.Forms.ComboBox cboDept;
        internal System.Windows.Forms.ComboBox cboCondition;
        internal System.Windows.Forms.Label lblQueryCondition;
        private System.Windows.Forms.Label lblNotice;
        internal Sybase.DataWindow.DataWindowControl dwResult;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SaveFileDialog sfdSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        internal com.digitalwave.Utility.ctlEmpTextBox txtCondition;
        private System.Windows.Forms.Panel panel3;
        internal System.Windows.Forms.RadioButton m_rdbAppDat;
        internal System.Windows.Forms.RadioButton m_rdbConfig;
    }
}