namespace iCare
{
    partial class frmCaseHistorySearch_In
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCaseHistorySearch_In));
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtPatientID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_lblPatientName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_lblPatientSex = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_dtpBirthDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_lsvInHospitalDesc = new System.Windows.Forms.ListView();
            this.m_clmInDate = new System.Windows.Forms.ColumnHeader();
            this.m_clmInDept = new System.Windows.Forms.ColumnHeader();
            this.m_clmOutDate = new System.Windows.Forms.ColumnHeader();
            this.m_clmOutDept = new System.Windows.Forms.ColumnHeader();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_lsvOpDesc = new System.Windows.Forms.ListView();
            this.m_clmOpName = new System.Windows.Forms.ColumnHeader();
            this.m_clmAnaMethod = new System.Windows.Forms.ColumnHeader();
            this.m_clmOpDoc = new System.Windows.Forms.ColumnHeader();
            this.m_clmOpDate = new System.Windows.Forms.ColumnHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_lsvDiagnoseDesc = new System.Windows.Forms.ListView();
            this.m_clmDiagnoseName = new System.Windows.Forms.ColumnHeader();
            this.m_clmDiagnoseDesc = new System.Windows.Forms.ColumnHeader();
            this.m_clmDiagnoseResult = new System.Windows.Forms.ColumnHeader();
            this.m_clmDiagnoseDays = new System.Windows.Forms.ColumnHeader();
            this.m_clmDiagnoseDate = new System.Windows.Forms.ColumnHeader();
            this.m_cmdClose = new PinkieControls.ButtonXP();
            this.m_cmdClear = new PinkieControls.ButtonXP();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label1.Location = new System.Drawing.Point(26, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "病人标识";
            // 
            // m_txtPatientID
            // 
            this.m_txtPatientID.Location = new System.Drawing.Point(91, 30);
            this.m_txtPatientID.Name = "m_txtPatientID";
            this.m_txtPatientID.Size = new System.Drawing.Size(100, 23);
            this.m_txtPatientID.TabIndex = 1;
            this.m_txtPatientID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtPatientID_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label2.Location = new System.Drawing.Point(206, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "姓名";
            // 
            // m_lblPatientName
            // 
            this.m_lblPatientName.AutoSize = true;
            this.m_lblPatientName.Location = new System.Drawing.Point(238, 33);
            this.m_lblPatientName.Name = "m_lblPatientName";
            this.m_lblPatientName.Size = new System.Drawing.Size(119, 14);
            this.m_lblPatientName.TabIndex = 2;
            this.m_lblPatientName.Text = "m_lblPatientName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label3.Location = new System.Drawing.Point(384, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "性别";
            // 
            // m_lblPatientSex
            // 
            this.m_lblPatientSex.AutoSize = true;
            this.m_lblPatientSex.Location = new System.Drawing.Point(417, 33);
            this.m_lblPatientSex.Name = "m_lblPatientSex";
            this.m_lblPatientSex.Size = new System.Drawing.Size(112, 14);
            this.m_lblPatientSex.TabIndex = 2;
            this.m_lblPatientSex.Text = "m_lblPatientSex";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label4.Location = new System.Drawing.Point(533, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "出生日期";
            // 
            // m_dtpBirthDate
            // 
            this.m_dtpBirthDate.AccessibleDescription = "出生日期";
            this.m_dtpBirthDate.BackColor = System.Drawing.Color.White;
            this.m_dtpBirthDate.BorderColor = System.Drawing.Color.Black;
            this.m_dtpBirthDate.CustomFormat = "yyyy年MM月dd日         ";
            this.m_dtpBirthDate.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_dtpBirthDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpBirthDate.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpBirthDate.Enabled = false;
            this.m_dtpBirthDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpBirthDate.Font = new System.Drawing.Font("宋体", 12F);
            this.m_dtpBirthDate.ForeColor = System.Drawing.Color.White;
            this.m_dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpBirthDate.Location = new System.Drawing.Point(602, 31);
            this.m_dtpBirthDate.m_BlnOnlyTime = false;
            this.m_dtpBirthDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Day;
            this.m_dtpBirthDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpBirthDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpBirthDate.Name = "m_dtpBirthDate";
            this.m_dtpBirthDate.ReadOnly = false;
            this.m_dtpBirthDate.Size = new System.Drawing.Size(141, 22);
            this.m_dtpBirthDate.TabIndex = 3;
            this.m_dtpBirthDate.Tag = "1";
            this.m_dtpBirthDate.TextBackColor = System.Drawing.Color.White;
            this.m_dtpBirthDate.TextForeColor = System.Drawing.Color.Black;
            this.m_dtpBirthDate.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_lsvInHospitalDesc);
            this.groupBox1.Location = new System.Drawing.Point(29, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(714, 112);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // m_lsvInHospitalDesc
            // 
            this.m_lsvInHospitalDesc.AccessibleDescription = "入院情况";
            this.m_lsvInHospitalDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lsvInHospitalDesc.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_clmInDate,
            this.m_clmInDept,
            this.m_clmOutDate,
            this.m_clmOutDept});
            this.m_lsvInHospitalDesc.FullRowSelect = true;
            this.m_lsvInHospitalDesc.GridLines = true;
            this.m_lsvInHospitalDesc.Location = new System.Drawing.Point(6, 15);
            this.m_lsvInHospitalDesc.MultiSelect = false;
            this.m_lsvInHospitalDesc.Name = "m_lsvInHospitalDesc";
            this.m_lsvInHospitalDesc.Size = new System.Drawing.Size(702, 91);
            this.m_lsvInHospitalDesc.TabIndex = 0;
            this.m_lsvInHospitalDesc.UseCompatibleStateImageBehavior = false;
            this.m_lsvInHospitalDesc.View = System.Windows.Forms.View.Details;
            this.m_lsvInHospitalDesc.SelectedIndexChanged += new System.EventHandler(this.m_lsvInHospitalDesc_SelectedIndexChanged);
            // 
            // m_clmInDate
            // 
            this.m_clmInDate.Text = "入院日期";
            this.m_clmInDate.Width = 140;
            // 
            // m_clmInDept
            // 
            this.m_clmInDept.Text = "入院科室";
            this.m_clmInDept.Width = 200;
            // 
            // m_clmOutDate
            // 
            this.m_clmOutDate.Text = "出院日期";
            this.m_clmOutDate.Width = 140;
            // 
            // m_clmOutDept
            // 
            this.m_clmOutDept.Text = "出院科室";
            this.m_clmOutDept.Width = 200;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_lsvOpDesc);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.m_lsvDiagnoseDesc);
            this.groupBox2.Location = new System.Drawing.Point(29, 175);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(714, 345);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // m_lsvOpDesc
            // 
            this.m_lsvOpDesc.AccessibleDescription = "手术情况";
            this.m_lsvOpDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lsvOpDesc.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_clmOpName,
            this.m_clmAnaMethod,
            this.m_clmOpDoc,
            this.m_clmOpDate});
            this.m_lsvOpDesc.FullRowSelect = true;
            this.m_lsvOpDesc.GridLines = true;
            this.m_lsvOpDesc.Location = new System.Drawing.Point(6, 232);
            this.m_lsvOpDesc.Name = "m_lsvOpDesc";
            this.m_lsvOpDesc.Size = new System.Drawing.Size(702, 106);
            this.m_lsvOpDesc.TabIndex = 2;
            this.m_lsvOpDesc.UseCompatibleStateImageBehavior = false;
            this.m_lsvOpDesc.View = System.Windows.Forms.View.Details;
            // 
            // m_clmOpName
            // 
            this.m_clmOpName.Text = "手术名称";
            this.m_clmOpName.Width = 380;
            // 
            // m_clmAnaMethod
            // 
            this.m_clmAnaMethod.Text = "麻醉方法";
            this.m_clmAnaMethod.Width = 80;
            // 
            // m_clmOpDoc
            // 
            this.m_clmOpDoc.Text = "手术医师";
            this.m_clmOpDoc.Width = 80;
            // 
            // m_clmOpDate
            // 
            this.m_clmOpDate.Text = "手术日期";
            this.m_clmOpDate.Width = 140;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(6, 221);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(702, 2);
            this.panel1.TabIndex = 1;
            // 
            // m_lsvDiagnoseDesc
            // 
            this.m_lsvDiagnoseDesc.AccessibleDescription = "诊断情况";
            this.m_lsvDiagnoseDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lsvDiagnoseDesc.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_clmDiagnoseName,
            this.m_clmDiagnoseDesc,
            this.m_clmDiagnoseResult,
            this.m_clmDiagnoseDays,
            this.m_clmDiagnoseDate});
            this.m_lsvDiagnoseDesc.FullRowSelect = true;
            this.m_lsvDiagnoseDesc.GridLines = true;
            this.m_lsvDiagnoseDesc.Location = new System.Drawing.Point(6, 13);
            this.m_lsvDiagnoseDesc.MultiSelect = false;
            this.m_lsvDiagnoseDesc.Name = "m_lsvDiagnoseDesc";
            this.m_lsvDiagnoseDesc.Size = new System.Drawing.Size(702, 200);
            this.m_lsvDiagnoseDesc.TabIndex = 0;
            this.m_lsvDiagnoseDesc.UseCompatibleStateImageBehavior = false;
            this.m_lsvDiagnoseDesc.View = System.Windows.Forms.View.Details;
            // 
            // m_clmDiagnoseName
            // 
            this.m_clmDiagnoseName.Text = "诊断类别";
            this.m_clmDiagnoseName.Width = 140;
            // 
            // m_clmDiagnoseDesc
            // 
            this.m_clmDiagnoseDesc.Text = "诊断描述";
            this.m_clmDiagnoseDesc.Width = 240;
            // 
            // m_clmDiagnoseResult
            // 
            this.m_clmDiagnoseResult.Text = "治疗结果";
            this.m_clmDiagnoseResult.Width = 80;
            // 
            // m_clmDiagnoseDays
            // 
            this.m_clmDiagnoseDays.Text = "治疗天数";
            this.m_clmDiagnoseDays.Width = 80;
            // 
            // m_clmDiagnoseDate
            // 
            this.m_clmDiagnoseDate.Text = "诊断日期";
            this.m_clmDiagnoseDate.Width = 140;
            // 
            // m_cmdClose
            // 
            this.m_cmdClose.AccessibleDescription = "关闭";
            this.m_cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdClose.DefaultScheme = true;
            this.m_cmdClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdClose.Hint = "";
            this.m_cmdClose.Location = new System.Drawing.Point(673, 528);
            this.m_cmdClose.Name = "m_cmdClose";
            this.m_cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClose.Size = new System.Drawing.Size(71, 33);
            this.m_cmdClose.TabIndex = 18803;
            this.m_cmdClose.Text = "关闭";
            this.m_cmdClose.Click += new System.EventHandler(this.m_cmdClose_Click);
            // 
            // m_cmdClear
            // 
            this.m_cmdClear.AccessibleDescription = "清空";
            this.m_cmdClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdClear.DefaultScheme = true;
            this.m_cmdClear.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdClear.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdClear.Hint = "";
            this.m_cmdClear.Location = new System.Drawing.Point(596, 528);
            this.m_cmdClear.Name = "m_cmdClear";
            this.m_cmdClear.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClear.Size = new System.Drawing.Size(71, 33);
            this.m_cmdClear.TabIndex = 18802;
            this.m_cmdClear.Text = "清空";
            this.m_cmdClear.Click += new System.EventHandler(this.m_cmdClear_Click);
            // 
            // frmCaseHistorySearch_In
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.m_lblPatientName);
            this.Controls.Add(this.m_cmdClose);
            this.Controls.Add(this.m_cmdClear);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_dtpBirthDate);
            this.Controls.Add(this.m_lblPatientSex);
            this.Controls.Add(this.m_txtPatientID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCaseHistorySearch_In";
            this.Text = "病人住院史查询";
            this.Load += new System.EventHandler(this.frmCaseHistorySearch_In_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox m_txtPatientID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label m_lblPatientName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label m_lblPatientSex;
        private System.Windows.Forms.Label label4;
        private com.digitalwave.Utility.Controls.ctlTimePicker m_dtpBirthDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView m_lsvInHospitalDesc;
        private System.Windows.Forms.ColumnHeader m_clmInDate;
        private System.Windows.Forms.ColumnHeader m_clmInDept;
        private System.Windows.Forms.ColumnHeader m_clmOutDate;
        private System.Windows.Forms.ColumnHeader m_clmOutDept;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView m_lsvDiagnoseDesc;
        private System.Windows.Forms.ColumnHeader m_clmDiagnoseName;
        private System.Windows.Forms.ColumnHeader m_clmDiagnoseDesc;
        private System.Windows.Forms.ColumnHeader m_clmDiagnoseResult;
        private System.Windows.Forms.ColumnHeader m_clmDiagnoseDays;
        private System.Windows.Forms.ColumnHeader m_clmDiagnoseDate;
        private System.Windows.Forms.ListView m_lsvOpDesc;
        private System.Windows.Forms.ColumnHeader m_clmOpName;
        private System.Windows.Forms.ColumnHeader m_clmAnaMethod;
        private System.Windows.Forms.ColumnHeader m_clmOpDoc;
        private System.Windows.Forms.ColumnHeader m_clmOpDate;
        private System.Windows.Forms.Panel panel1;
        private PinkieControls.ButtonXP m_cmdClose;
        private PinkieControls.ButtonXP m_cmdClear;
    }
}