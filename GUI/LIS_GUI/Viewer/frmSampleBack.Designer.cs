namespace com.digitalwave.iCare.gui.LIS
{
    partial class frmSampleBack
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSampleBack));
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_btnExprot = new PinkieControls.ButtonXP();
            this.m_txtInHospitalNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_btnPrint = new PinkieControls.ButtonXP();
            this.m_btnQuery = new PinkieControls.ButtonXP();
            this.m_txtAppDept = new com.digitalwave.Utility.ctlDeptTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txtPatientName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_dtToDate = new System.Windows.Forms.DateTimePicker();
            this.m_dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_dgSampleBack = new System.Windows.Forms.DataGridView();
            this.m_colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_colInHospitalNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_colBedNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_colAppDept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_colReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dwPrint = new Sybase.DataWindow.DataWindowControl();
            this.m_sfExport = new System.Windows.Forms.SaveFileDialog();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgSampleBack)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_btnExprot);
            this.panel1.Controls.Add(this.m_txtInHospitalNo);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.m_btnPrint);
            this.panel1.Controls.Add(this.m_btnQuery);
            this.panel1.Controls.Add(this.m_txtAppDept);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.m_txtPatientName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.m_dtToDate);
            this.panel1.Controls.Add(this.m_dtFromDate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(184, 609);
            this.panel1.TabIndex = 0;
            // 
            // m_btnExprot
            // 
            this.m_btnExprot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnExprot.DefaultScheme = true;
            this.m_btnExprot.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnExprot.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_btnExprot.Hint = "";
            this.m_btnExprot.Location = new System.Drawing.Point(14, 304);
            this.m_btnExprot.Name = "m_btnExprot";
            this.m_btnExprot.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnExprot.Size = new System.Drawing.Size(77, 28);
            this.m_btnExprot.TabIndex = 89;
            this.m_btnExprot.Text = "导出";
            this.m_btnExprot.Click += new System.EventHandler(this.m_btnExprot_Click);
            // 
            // m_txtInHospitalNo
            // 
            this.m_txtInHospitalNo.Location = new System.Drawing.Point(67, 206);
            this.m_txtInHospitalNo.Name = "m_txtInHospitalNo";
            this.m_txtInHospitalNo.Size = new System.Drawing.Size(109, 23);
            this.m_txtInHospitalNo.TabIndex = 88;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 14);
            this.label5.TabIndex = 87;
            this.label5.Text = "住院号";
            // 
            // m_btnPrint
            // 
            this.m_btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnPrint.DefaultScheme = true;
            this.m_btnPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnPrint.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_btnPrint.Hint = "";
            this.m_btnPrint.Location = new System.Drawing.Point(99, 256);
            this.m_btnPrint.Name = "m_btnPrint";
            this.m_btnPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnPrint.Size = new System.Drawing.Size(77, 28);
            this.m_btnPrint.TabIndex = 86;
            this.m_btnPrint.Text = "打印";
            this.m_btnPrint.Click += new System.EventHandler(this.m_btnPrint_Click);
            // 
            // m_btnQuery
            // 
            this.m_btnQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnQuery.DefaultScheme = true;
            this.m_btnQuery.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnQuery.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_btnQuery.Hint = "";
            this.m_btnQuery.Location = new System.Drawing.Point(14, 256);
            this.m_btnQuery.Name = "m_btnQuery";
            this.m_btnQuery.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnQuery.Size = new System.Drawing.Size(77, 28);
            this.m_btnQuery.TabIndex = 85;
            this.m_btnQuery.Text = "查询";
            this.m_btnQuery.Click += new System.EventHandler(this.m_btnQuery_Click);
            // 
            // m_txtAppDept
            // 
            this.m_txtAppDept.BackColor = System.Drawing.Color.White;
            this.m_txtAppDept.EnableAutoValidation = true;
            this.m_txtAppDept.EnableEnterKeyValidate = true;
            this.m_txtAppDept.EnableEscapeKeyUndo = true;
            this.m_txtAppDept.EnableLastValidValue = true;
            this.m_txtAppDept.ErrorProvider = null;
            this.m_txtAppDept.ErrorProviderMessage = "Invalid value";
            this.m_txtAppDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtAppDept.ForceFormatText = true;
            this.m_txtAppDept.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtAppDept.Location = new System.Drawing.Point(67, 159);
            this.m_txtAppDept.m_StrDeptID = null;
            this.m_txtAppDept.m_StrDeptName = null;
            this.m_txtAppDept.MaxLength = 20;
            this.m_txtAppDept.Name = "m_txtAppDept";
            this.m_txtAppDept.SetDepartment = com.digitalwave.Utility.ctlDeptTextBox.eDeptArea.All;
            this.m_txtAppDept.Size = new System.Drawing.Size(109, 23);
            this.m_txtAppDept.TabIndex = 84;
            this.m_txtAppDept.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "申请科室";
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(67, 109);
            this.m_txtPatientName.Name = "m_txtPatientName";
            this.m_txtPatientName.Size = new System.Drawing.Size(109, 23);
            this.m_txtPatientName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "病人姓名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "至";
            // 
            // m_dtToDate
            // 
            this.m_dtToDate.CustomFormat = "yyyy-MM-dd";
            this.m_dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtToDate.Location = new System.Drawing.Point(67, 60);
            this.m_dtToDate.Name = "m_dtToDate";
            this.m_dtToDate.Size = new System.Drawing.Size(109, 23);
            this.m_dtToDate.TabIndex = 2;
            // 
            // m_dtFromDate
            // 
            this.m_dtFromDate.CustomFormat = "yyyy-MM-dd";
            this.m_dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtFromDate.Location = new System.Drawing.Point(67, 11);
            this.m_dtFromDate.Name = "m_dtFromDate";
            this.m_dtFromDate.Size = new System.Drawing.Size(109, 23);
            this.m_dtFromDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "日期";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_dgSampleBack);
            this.panel2.Controls.Add(this.m_dwPrint);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(184, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1184, 609);
            this.panel2.TabIndex = 1;
            // 
            // m_dgSampleBack
            // 
            this.m_dgSampleBack.AllowUserToAddRows = false;
            this.m_dgSampleBack.AllowUserToResizeRows = false;
            this.m_dgSampleBack.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgSampleBack.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.m_dgSampleBack.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_colDate,
            this.m_colName,
            this.m_colInHospitalNO,
            this.m_colBedNO,
            this.m_colAppDept,
            this.barCode,
            this.checkContent,
            this.m_colReason});
            this.m_dgSampleBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgSampleBack.Location = new System.Drawing.Point(0, 0);
            this.m_dgSampleBack.MultiSelect = false;
            this.m_dgSampleBack.Name = "m_dgSampleBack";
            this.m_dgSampleBack.ReadOnly = true;
            this.m_dgSampleBack.RowHeadersVisible = false;
            this.m_dgSampleBack.RowTemplate.Height = 23;
            this.m_dgSampleBack.Size = new System.Drawing.Size(1184, 609);
            this.m_dgSampleBack.TabIndex = 0;
            // 
            // m_colDate
            // 
            this.m_colDate.DataPropertyName = "feedback_date_date";
            this.m_colDate.HeaderText = "日期";
            this.m_colDate.Name = "m_colDate";
            this.m_colDate.ReadOnly = true;
            this.m_colDate.Width = 125;
            // 
            // m_colName
            // 
            this.m_colName.DataPropertyName = "patient_name_vchr";
            this.m_colName.HeaderText = "姓名";
            this.m_colName.Name = "m_colName";
            this.m_colName.ReadOnly = true;
            this.m_colName.Width = 80;
            // 
            // m_colInHospitalNO
            // 
            this.m_colInHospitalNO.DataPropertyName = "patient_inhospitalno_vchr";
            this.m_colInHospitalNO.HeaderText = "住院号";
            this.m_colInHospitalNO.Name = "m_colInHospitalNO";
            this.m_colInHospitalNO.ReadOnly = true;
            this.m_colInHospitalNO.Width = 70;
            // 
            // m_colBedNO
            // 
            this.m_colBedNO.DataPropertyName = "bedno_chr";
            this.m_colBedNO.HeaderText = "床号";
            this.m_colBedNO.Name = "m_colBedNO";
            this.m_colBedNO.ReadOnly = true;
            this.m_colBedNO.Width = 70;
            // 
            // m_colAppDept
            // 
            this.m_colAppDept.DataPropertyName = "deptname_vchr";
            this.m_colAppDept.HeaderText = "科室";
            this.m_colAppDept.Name = "m_colAppDept";
            this.m_colAppDept.ReadOnly = true;
            // 
            // barCode
            // 
            this.barCode.DataPropertyName = "barCode";
            this.barCode.HeaderText = "条码号";
            this.barCode.Name = "barCode";
            this.barCode.ReadOnly = true;
            this.barCode.Width = 95;
            // 
            // checkContent
            // 
            this.checkContent.DataPropertyName = "checkContent";
            this.checkContent.HeaderText = "检验内容";
            this.checkContent.Name = "checkContent";
            this.checkContent.ReadOnly = true;
            this.checkContent.Width = 250;
            // 
            // m_colReason
            // 
            this.m_colReason.DataPropertyName = "sample_back_reason_vchr";
            this.m_colReason.HeaderText = "拒收标本原因";
            this.m_colReason.Name = "m_colReason";
            this.m_colReason.ReadOnly = true;
            this.m_colReason.Width = 300;
            // 
            // m_dwPrint
            // 
            this.m_dwPrint.DataWindowObject = "";
            this.m_dwPrint.LibraryList = "";
            this.m_dwPrint.Location = new System.Drawing.Point(32, 168);
            this.m_dwPrint.Name = "m_dwPrint";
            this.m_dwPrint.Size = new System.Drawing.Size(240, 284);
            this.m_dwPrint.TabIndex = 1;
            this.m_dwPrint.Text = "dataWindowControl1";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "feedback_date_date";
            this.dataGridViewTextBoxColumn1.HeaderText = "日期";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "patient_name_vchr";
            this.dataGridViewTextBoxColumn2.HeaderText = "姓名";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "patient_inhospitalno_vchr";
            this.dataGridViewTextBoxColumn3.HeaderText = "住院号";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 70;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "bedno_chr";
            this.dataGridViewTextBoxColumn4.HeaderText = "床号";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 70;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "deptname_vchr";
            this.dataGridViewTextBoxColumn5.HeaderText = "科室";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "sample_back_reason_vchr";
            this.dataGridViewTextBoxColumn6.HeaderText = "拒收标本原因";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 150;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "checkContent";
            this.dataGridViewTextBoxColumn7.HeaderText = "检验内容";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 250;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "sample_back_reason_vchr";
            this.dataGridViewTextBoxColumn8.HeaderText = "拒收标本原因";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 300;
            // 
            // frmSampleBack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1368, 609);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSampleBack";
            this.Text = "标本反馈查询";
            this.Load += new System.EventHandler(this.frmSampleBack_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgSampleBack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView m_dgSampleBack;
        private System.Windows.Forms.DateTimePicker m_dtToDate;
        private System.Windows.Forms.DateTimePicker m_dtFromDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox m_txtPatientName;
        internal com.digitalwave.Utility.ctlDeptTextBox m_txtAppDept;
        private PinkieControls.ButtonXP m_btnPrint;
        private PinkieControls.ButtonXP m_btnQuery;
        private System.Windows.Forms.TextBox m_txtInHospitalNo;
        private System.Windows.Forms.Label label5;
        private Sybase.DataWindow.DataWindowControl m_dwPrint;
        private PinkieControls.ButtonXP m_btnExprot;
        private System.Windows.Forms.SaveFileDialog m_sfExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_colInHospitalNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_colBedNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_colAppDept;
        private System.Windows.Forms.DataGridViewTextBoxColumn barCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_colReason;
    }
}