namespace iCare
{
    partial class frmCaseHistorySearch_unList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCaseHistorySearch_unList));
            this.m_dtpOutDate1 = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.m_cmdQuery = new PinkieControls.ButtonXP();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_dtpOutDate2 = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_lsvRecordList = new System.Windows.Forms.ListView();
            this.m_clmPatientID = new System.Windows.Forms.ColumnHeader();
            this.m_clmInPatientID = new System.Windows.Forms.ColumnHeader();
            this.m_clmPatientName = new System.Windows.Forms.ColumnHeader();
            this.m_clmOutHospitalDate = new System.Windows.Forms.ColumnHeader();
            this.m_clmOutDept = new System.Windows.Forms.ColumnHeader();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_cmdClear = new PinkieControls.ButtonXP();
            this.m_cmdClose = new PinkieControls.ButtonXP();
            this.m_cboOutDept = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_dtpOutDate1
            // 
            this.m_dtpOutDate1.AccessibleDescription = "出院日期1";
            this.m_dtpOutDate1.BackColor = System.Drawing.Color.White;
            this.m_dtpOutDate1.BorderColor = System.Drawing.Color.Black;
            this.m_dtpOutDate1.CustomFormat = "yyyy年MM月dd日         ";
            this.m_dtpOutDate1.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_dtpOutDate1.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpOutDate1.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpOutDate1.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpOutDate1.Font = new System.Drawing.Font("宋体", 12F);
            this.m_dtpOutDate1.ForeColor = System.Drawing.Color.White;
            this.m_dtpOutDate1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpOutDate1.Location = new System.Drawing.Point(110, 19);
            this.m_dtpOutDate1.m_BlnOnlyTime = false;
            this.m_dtpOutDate1.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Day;
            this.m_dtpOutDate1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpOutDate1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpOutDate1.Name = "m_dtpOutDate1";
            this.m_dtpOutDate1.ReadOnly = false;
            this.m_dtpOutDate1.Size = new System.Drawing.Size(141, 22);
            this.m_dtpOutDate1.TabIndex = 0;
            this.m_dtpOutDate1.Tag = "1";
            this.m_dtpOutDate1.TextBackColor = System.Drawing.Color.White;
            this.m_dtpOutDate1.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cmdQuery
            // 
            this.m_cmdQuery.AccessibleDescription = "查询";
            this.m_cmdQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdQuery.DefaultScheme = true;
            this.m_cmdQuery.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdQuery.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdQuery.Hint = "";
            this.m_cmdQuery.Location = new System.Drawing.Point(546, 528);
            this.m_cmdQuery.Name = "m_cmdQuery";
            this.m_cmdQuery.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdQuery.Size = new System.Drawing.Size(71, 33);
            this.m_cmdQuery.TabIndex = 18801;
            this.m_cmdQuery.Text = "查询";
            this.m_cmdQuery.Click += new System.EventHandler(this.m_cmdQuery_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 18802;
            this.label1.Text = "出院日期";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 18F);
            this.label2.Location = new System.Drawing.Point(257, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 24);
            this.label2.TabIndex = 18803;
            this.label2.Text = "~";
            // 
            // m_dtpOutDate2
            // 
            this.m_dtpOutDate2.AccessibleDescription = "出院日期2";
            this.m_dtpOutDate2.BackColor = System.Drawing.Color.White;
            this.m_dtpOutDate2.BorderColor = System.Drawing.Color.Black;
            this.m_dtpOutDate2.CustomFormat = "yyyy年MM月dd日         ";
            this.m_dtpOutDate2.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_dtpOutDate2.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpOutDate2.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpOutDate2.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpOutDate2.Font = new System.Drawing.Font("宋体", 12F);
            this.m_dtpOutDate2.ForeColor = System.Drawing.Color.White;
            this.m_dtpOutDate2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpOutDate2.Location = new System.Drawing.Point(285, 19);
            this.m_dtpOutDate2.m_BlnOnlyTime = false;
            this.m_dtpOutDate2.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Day;
            this.m_dtpOutDate2.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpOutDate2.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpOutDate2.Name = "m_dtpOutDate2";
            this.m_dtpOutDate2.ReadOnly = false;
            this.m_dtpOutDate2.Size = new System.Drawing.Size(141, 22);
            this.m_dtpOutDate2.TabIndex = 0;
            this.m_dtpOutDate2.Tag = "1";
            this.m_dtpOutDate2.TextBackColor = System.Drawing.Color.White;
            this.m_dtpOutDate2.TextForeColor = System.Drawing.Color.Black;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(528, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 18802;
            this.label3.Text = "出院科室";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.m_lsvRecordList);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(30, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(741, 468);
            this.groupBox1.TabIndex = 18804;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "结果";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(513, 444);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 14);
            this.label6.TabIndex = 18806;
            // 
            // m_lsvRecordList
            // 
            this.m_lsvRecordList.BackColor = System.Drawing.SystemColors.Window;
            this.m_lsvRecordList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lsvRecordList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_clmPatientID,
            this.m_clmInPatientID,
            this.m_clmPatientName,
            this.m_clmOutHospitalDate,
            this.m_clmOutDept});
            this.m_lsvRecordList.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_lsvRecordList.FullRowSelect = true;
            this.m_lsvRecordList.GridLines = true;
            this.m_lsvRecordList.Location = new System.Drawing.Point(15, 37);
            this.m_lsvRecordList.MultiSelect = false;
            this.m_lsvRecordList.Name = "m_lsvRecordList";
            this.m_lsvRecordList.Size = new System.Drawing.Size(711, 400);
            this.m_lsvRecordList.TabIndex = 0;
            this.m_lsvRecordList.UseCompatibleStateImageBehavior = false;
            this.m_lsvRecordList.View = System.Windows.Forms.View.Details;
            this.m_lsvRecordList.DoubleClick += new System.EventHandler(this.m_lsvRecordList_DoubleClick);
            // 
            // m_clmPatientID
            // 
            this.m_clmPatientID.Text = "病人ID";
            this.m_clmPatientID.Width = 100;
            // 
            // m_clmInPatientID
            // 
            this.m_clmInPatientID.Text = "住院号";
            this.m_clmInPatientID.Width = 100;
            // 
            // m_clmPatientName
            // 
            this.m_clmPatientName.Text = "姓名";
            this.m_clmPatientName.Width = 120;
            // 
            // m_clmOutHospitalDate
            // 
            this.m_clmOutHospitalDate.Text = "出院日期";
            this.m_clmOutHospitalDate.Width = 160;
            // 
            // m_clmOutDept
            // 
            this.m_clmOutDept.Text = "出院科室";
            this.m_clmOutDept.Width = 200;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(12, 444);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(273, 14);
            this.label5.TabIndex = 18805;
            this.label5.Text = "红色表示超过7天、黄色表示超过3天未编目";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 14F);
            this.label4.Location = new System.Drawing.Point(254, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(256, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "病案首页尚未编目的出院病人";
            // 
            // m_cmdClear
            // 
            this.m_cmdClear.AccessibleDescription = "清空";
            this.m_cmdClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdClear.DefaultScheme = true;
            this.m_cmdClear.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdClear.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdClear.Hint = "";
            this.m_cmdClear.Location = new System.Drawing.Point(623, 528);
            this.m_cmdClear.Name = "m_cmdClear";
            this.m_cmdClear.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClear.Size = new System.Drawing.Size(71, 33);
            this.m_cmdClear.TabIndex = 18801;
            this.m_cmdClear.Text = "清空";
            this.m_cmdClear.Click += new System.EventHandler(this.m_cmdClear_Click);
            // 
            // m_cmdClose
            // 
            this.m_cmdClose.AccessibleDescription = "关闭";
            this.m_cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdClose.DefaultScheme = true;
            this.m_cmdClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdClose.Hint = "";
            this.m_cmdClose.Location = new System.Drawing.Point(700, 528);
            this.m_cmdClose.Name = "m_cmdClose";
            this.m_cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClose.Size = new System.Drawing.Size(71, 33);
            this.m_cmdClose.TabIndex = 18801;
            this.m_cmdClose.Text = "关闭";
            this.m_cmdClose.Click += new System.EventHandler(this.m_cmdClose_Click);
            // 
            // m_cboOutDept
            // 
            this.m_cboOutDept.AccessibleDescription = "出院科室";
            this.m_cboOutDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboOutDept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cboOutDept.FormattingEnabled = true;
            this.m_cboOutDept.Location = new System.Drawing.Point(591, 20);
            this.m_cboOutDept.Name = "m_cboOutDept";
            this.m_cboOutDept.Size = new System.Drawing.Size(180, 22);
            this.m_cboOutDept.TabIndex = 18805;
            this.m_cboOutDept.SelectedIndexChanged += new System.EventHandler(this.m_cboOutDept_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(590, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(182, 24);
            this.panel1.TabIndex = 18806;
            // 
            // frmCaseHistorySearch_unList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.m_cboOutDept);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_cmdClose);
            this.Controls.Add(this.m_cmdClear);
            this.Controls.Add(this.m_cmdQuery);
            this.Controls.Add(this.m_dtpOutDate2);
            this.Controls.Add(this.m_dtpOutDate1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCaseHistorySearch_unList";
            this.Text = "查询尚未编目的出院病人";
            this.Load += new System.EventHandler(this.frmCaseHistorySearch_unList_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private com.digitalwave.Utility.Controls.ctlTimePicker m_dtpOutDate1;
        private PinkieControls.ButtonXP m_cmdQuery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private com.digitalwave.Utility.Controls.ctlTimePicker m_dtpOutDate2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView m_lsvRecordList;
        private System.Windows.Forms.ColumnHeader m_clmPatientID;
        private System.Windows.Forms.ColumnHeader m_clmInPatientID;
        private System.Windows.Forms.ColumnHeader m_clmPatientName;
        private System.Windows.Forms.ColumnHeader m_clmOutHospitalDate;
        private System.Windows.Forms.ColumnHeader m_clmOutDept;
        private System.Windows.Forms.Label label5;
        private PinkieControls.ButtonXP m_cmdClear;
        private PinkieControls.ButtonXP m_cmdClose;
        private System.Windows.Forms.ComboBox m_cboOutDept;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;

    }
}