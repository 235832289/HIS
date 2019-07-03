namespace com.digitalwave.iCare.BIHOrder
{
    partial class frmOrderExecedPatientList
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
            this.m_dtvPersonList = new System.Windows.Forms.DataGridView();
            this.bedname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name_vchr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sex_chr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inpatientid_chr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISINCEPT_INT = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.m_cmdToCommit = new PinkieControls.ButtonXP();
            this.buttonXP2 = new PinkieControls.ButtonXP();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_chkSelectAll = new System.Windows.Forms.CheckBox();
            this.m_txtArea = new com.digitalwave.controls.ctlFindTextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtvPersonList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_dtvPersonList
            // 
            this.m_dtvPersonList.AllowUserToAddRows = false;
            this.m_dtvPersonList.BackgroundColor = System.Drawing.Color.White;
            this.m_dtvPersonList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dtvPersonList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bedname,
            this.name_vchr,
            this.sex_chr,
            this.inpatientid_chr,
            this.ISINCEPT_INT});
            this.m_dtvPersonList.Location = new System.Drawing.Point(14, 14);
            this.m_dtvPersonList.MultiSelect = false;
            this.m_dtvPersonList.Name = "m_dtvPersonList";
            this.m_dtvPersonList.ReadOnly = true;
            this.m_dtvPersonList.RowHeadersWidth = 10;
            this.m_dtvPersonList.RowTemplate.Height = 23;
            this.m_dtvPersonList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dtvPersonList.Size = new System.Drawing.Size(468, 394);
            this.m_dtvPersonList.TabIndex = 63;
            this.m_dtvPersonList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dtvPersonList_CellClick);
            // 
            // bedname
            // 
            this.bedname.HeaderText = "床号";
            this.bedname.Name = "bedname";
            this.bedname.ReadOnly = true;
            this.bedname.Width = 75;
            // 
            // name_vchr
            // 
            this.name_vchr.HeaderText = "姓名";
            this.name_vchr.Name = "name_vchr";
            this.name_vchr.ReadOnly = true;
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
            // 
            // ISINCEPT_INT
            // 
            this.ISINCEPT_INT.FalseValue = "0";
            this.ISINCEPT_INT.HeaderText = "是否发送";
            this.ISINCEPT_INT.IndeterminateValue = "";
            this.ISINCEPT_INT.Name = "ISINCEPT_INT";
            this.ISINCEPT_INT.ReadOnly = true;
            this.ISINCEPT_INT.TrueValue = "1";
            // 
            // m_cmdToCommit
            // 
            this.m_cmdToCommit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdToCommit.DefaultScheme = true;
            this.m_cmdToCommit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdToCommit.Hint = "";
            this.m_cmdToCommit.Location = new System.Drawing.Point(239, 13);
            this.m_cmdToCommit.Name = "m_cmdToCommit";
            this.m_cmdToCommit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdToCommit.Size = new System.Drawing.Size(129, 26);
            this.m_cmdToCommit.TabIndex = 104;
            this.m_cmdToCommit.Text = "发送摆药申请(&S)";
            this.m_cmdToCommit.Click += new System.EventHandler(this.m_cmdToCommit_Click);
            // 
            // buttonXP2
            // 
            this.buttonXP2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP2.DefaultScheme = true;
            this.buttonXP2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP2.Hint = "";
            this.buttonXP2.Location = new System.Drawing.Point(374, 13);
            this.buttonXP2.Name = "buttonXP2";
            this.buttonXP2.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP2.Size = new System.Drawing.Size(87, 26);
            this.buttonXP2.TabIndex = 105;
            this.buttonXP2.Text = " 退 出(&X)";
            this.buttonXP2.Click += new System.EventHandler(this.buttonXP2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_chkSelectAll);
            this.groupBox1.Controls.Add(this.m_txtArea);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.m_cmdToCommit);
            this.groupBox1.Controls.Add(this.buttonXP2);
            this.groupBox1.Location = new System.Drawing.Point(15, 414);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(467, 45);
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
            this.m_chkSelectAll.Location = new System.Drawing.Point(179, 13);
            this.m_chkSelectAll.Name = "m_chkSelectAll";
            this.m_chkSelectAll.Size = new System.Drawing.Size(60, 24);
            this.m_chkSelectAll.TabIndex = 108;
            this.m_chkSelectAll.Text = "全选";
            this.m_chkSelectAll.UseVisualStyleBackColor = false;
            this.m_chkSelectAll.CheckedChanged += new System.EventHandler(this.m_chkSelectAll_CheckedChanged);
            // 
            // m_txtArea
            // 
            this.m_txtArea.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtArea.Location = new System.Drawing.Point(66, 15);
            this.m_txtArea.Name = "m_txtArea";
            this.m_txtArea.Size = new System.Drawing.Size(107, 23);
            this.m_txtArea.TabIndex = 106;
            this.m_txtArea.m_evtFindItem += new com.digitalwave.controls.EventHandler_OnFindItem(this.m_txtArea_m_evtFindItem);
            this.m_txtArea.m_evtInitListView += new com.digitalwave.controls.EventHandler_InitListView(this.m_txtArea_m_evtInitListView);
            this.m_txtArea.m_evtSelectItem += new com.digitalwave.controls.EventHandler_OnSelectItem(this.m_txtArea_m_evtSelectItem);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 107;
            this.label1.Text = "病区名称";
            // 
            // frmOrderExecedPatientList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 470);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_dtvPersonList);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmOrderExecedPatientList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "待发送申请病人列表";
            this.Load += new System.EventHandler(this.frmOrderExecedPatientList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_dtvPersonList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal PinkieControls.ButtonXP m_cmdToCommit;
        internal PinkieControls.ButtonXP buttonXP2;
        private System.Windows.Forms.GroupBox groupBox1;
        internal com.digitalwave.controls.ctlFindTextBox m_txtArea;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView m_dtvPersonList;
        internal System.Windows.Forms.CheckBox m_chkSelectAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn bedname;
        private System.Windows.Forms.DataGridViewTextBoxColumn name_vchr;
        private System.Windows.Forms.DataGridViewTextBoxColumn sex_chr;
        private System.Windows.Forms.DataGridViewTextBoxColumn inpatientid_chr;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ISINCEPT_INT;
    }
}