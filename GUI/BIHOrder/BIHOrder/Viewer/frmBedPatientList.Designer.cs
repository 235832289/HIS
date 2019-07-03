namespace com.digitalwave.iCare.BIHOrder
{
    partial class frmBedPatientList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBedPatientList));
            this.m_dtvPersonList = new System.Windows.Forms.DataGridView();
            this.dtv_bedcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dtvLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sex_chr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inpatientid_chr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISINCEPT_INT = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dtv_DEPTNAME_VCHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_cmdToCommit = new PinkieControls.ButtonXP();
            this.buttonXP2 = new PinkieControls.ButtonXP();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_chkSelectAll = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtvPersonList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_dtvPersonList
            // 
            this.m_dtvPersonList.AllowUserToAddRows = false;
            this.m_dtvPersonList.BackgroundColor = System.Drawing.Color.White;
            this.m_dtvPersonList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_dtvPersonList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dtvPersonList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtv_bedcode,
            this.m_dtvLastName,
            this.sex_chr,
            this.inpatientid_chr,
            this.ISINCEPT_INT,
            this.dtv_DEPTNAME_VCHR});
            this.m_dtvPersonList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dtvPersonList.Location = new System.Drawing.Point(0, 0);
            this.m_dtvPersonList.MultiSelect = false;
            this.m_dtvPersonList.Name = "m_dtvPersonList";
            this.m_dtvPersonList.ReadOnly = true;
            this.m_dtvPersonList.RowHeadersWidth = 10;
            this.m_dtvPersonList.RowTemplate.Height = 23;
            this.m_dtvPersonList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dtvPersonList.Size = new System.Drawing.Size(481, 419);
            this.m_dtvPersonList.TabIndex = 63;
            this.m_dtvPersonList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dtvPersonList_CellClick);
            this.m_dtvPersonList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dtvPersonList_CellDoubleClick);
            // 
            // dtv_bedcode
            // 
            this.dtv_bedcode.HeaderText = "床号";
            this.dtv_bedcode.Name = "dtv_bedcode";
            this.dtv_bedcode.ReadOnly = true;
            this.dtv_bedcode.Width = 75;
            // 
            // m_dtvLastName
            // 
            this.m_dtvLastName.HeaderText = "姓名";
            this.m_dtvLastName.Name = "m_dtvLastName";
            this.m_dtvLastName.ReadOnly = true;
            this.m_dtvLastName.Width = 200;
            // 
            // sex_chr
            // 
            this.sex_chr.HeaderText = "性别";
            this.sex_chr.Name = "sex_chr";
            this.sex_chr.ReadOnly = true;
            this.sex_chr.Width = 75;
            // 
            // inpatientid_chr
            // 
            this.inpatientid_chr.HeaderText = "住院号";
            this.inpatientid_chr.Name = "inpatientid_chr";
            this.inpatientid_chr.ReadOnly = true;
            this.inpatientid_chr.Visible = false;
            // 
            // ISINCEPT_INT
            // 
            this.ISINCEPT_INT.FalseValue = "0";
            this.ISINCEPT_INT.HeaderText = "选择";
            this.ISINCEPT_INT.IndeterminateValue = "";
            this.ISINCEPT_INT.Name = "ISINCEPT_INT";
            this.ISINCEPT_INT.ReadOnly = true;
            this.ISINCEPT_INT.TrueValue = "1";
            // 
            // dtv_DEPTNAME_VCHR
            // 
            this.dtv_DEPTNAME_VCHR.HeaderText = "病区名称";
            this.dtv_DEPTNAME_VCHR.Name = "dtv_DEPTNAME_VCHR";
            this.dtv_DEPTNAME_VCHR.ReadOnly = true;
            this.dtv_DEPTNAME_VCHR.Visible = false;
            this.dtv_DEPTNAME_VCHR.Width = 120;
            // 
            // m_cmdToCommit
            // 
            this.m_cmdToCommit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdToCommit.DefaultScheme = true;
            this.m_cmdToCommit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdToCommit.Hint = "";
            this.m_cmdToCommit.Location = new System.Drawing.Point(265, 14);
            this.m_cmdToCommit.Name = "m_cmdToCommit";
            this.m_cmdToCommit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdToCommit.Size = new System.Drawing.Size(85, 31);
            this.m_cmdToCommit.TabIndex = 104;
            this.m_cmdToCommit.Text = "确定(&S)";
            this.m_cmdToCommit.Click += new System.EventHandler(this.m_cmdToCommit_Click);
            // 
            // buttonXP2
            // 
            this.buttonXP2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP2.DefaultScheme = true;
            this.buttonXP2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP2.Hint = "";
            this.buttonXP2.Location = new System.Drawing.Point(375, 14);
            this.buttonXP2.Name = "buttonXP2";
            this.buttonXP2.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP2.Size = new System.Drawing.Size(85, 31);
            this.buttonXP2.TabIndex = 105;
            this.buttonXP2.Text = "退出(&X)";
            this.buttonXP2.Click += new System.EventHandler(this.buttonXP2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_chkSelectAll);
            this.groupBox1.Controls.Add(this.m_cmdToCommit);
            this.groupBox1.Controls.Add(this.buttonXP2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 419);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(481, 51);
            this.groupBox1.TabIndex = 108;
            this.groupBox1.TabStop = false;
            // 
            // m_chkSelectAll
            // 
            this.m_chkSelectAll.BackColor = System.Drawing.SystemColors.Control;
            this.m_chkSelectAll.Checked = true;
            this.m_chkSelectAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_chkSelectAll.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.m_chkSelectAll.ForeColor = System.Drawing.Color.Maroon;
            this.m_chkSelectAll.Location = new System.Drawing.Point(19, 19);
            this.m_chkSelectAll.Name = "m_chkSelectAll";
            this.m_chkSelectAll.Size = new System.Drawing.Size(60, 24);
            this.m_chkSelectAll.TabIndex = 108;
            this.m_chkSelectAll.Text = "全选";
            this.m_chkSelectAll.UseVisualStyleBackColor = false;
            this.m_chkSelectAll.CheckedChanged += new System.EventHandler(this.m_chkSelectAll_CheckedChanged);
            // 
            // frmBedPatientList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 470);
            this.Controls.Add(this.m_dtvPersonList);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBedPatientList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "病人床位列表";
            this.Load += new System.EventHandler(this.frmOrderExecedPatientList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_dtvPersonList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal PinkieControls.ButtonXP m_cmdToCommit;
        internal PinkieControls.ButtonXP buttonXP2;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.DataGridView m_dtvPersonList;
        internal System.Windows.Forms.CheckBox m_chkSelectAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtv_bedcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dtvLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn sex_chr;
        private System.Windows.Forms.DataGridViewTextBoxColumn inpatientid_chr;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ISINCEPT_INT;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtv_DEPTNAME_VCHR;
    }
}