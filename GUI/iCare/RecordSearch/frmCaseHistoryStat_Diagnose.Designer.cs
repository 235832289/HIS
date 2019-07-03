namespace iCare
{
    partial class frmCaseHistoryStat_Diagnose
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCaseHistoryStat_Diagnose));
            this.m_dtpOutDate2 = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.m_dtpOutDate1 = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_chkIsFirst = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_cboOutDept = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_lblSearchNums = new System.Windows.Forms.Label();
            this.m_lsvResultList = new System.Windows.Forms.ListView();
            this.m_clmDiseaseName = new System.Windows.Forms.ColumnHeader();
            this.m_clmDiseaseCode = new System.Windows.Forms.ColumnHeader();
            this.m_clmCount = new System.Windows.Forms.ColumnHeader();
            this.m_cmdClose = new PinkieControls.ButtonXP();
            this.m_cmdClear = new PinkieControls.ButtonXP();
            this.m_cmdStat = new PinkieControls.ButtonXP();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.m_dtpOutDate2.Location = new System.Drawing.Point(228, 13);
            this.m_dtpOutDate2.m_BlnOnlyTime = false;
            this.m_dtpOutDate2.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Day;
            this.m_dtpOutDate2.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpOutDate2.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpOutDate2.Name = "m_dtpOutDate2";
            this.m_dtpOutDate2.ReadOnly = false;
            this.m_dtpOutDate2.Size = new System.Drawing.Size(141, 22);
            this.m_dtpOutDate2.TabIndex = 10;
            this.m_dtpOutDate2.Tag = "1";
            this.m_dtpOutDate2.TextBackColor = System.Drawing.Color.White;
            this.m_dtpOutDate2.TextForeColor = System.Drawing.Color.Black;
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
            this.m_dtpOutDate1.Location = new System.Drawing.Point(72, 13);
            this.m_dtpOutDate1.m_BlnOnlyTime = false;
            this.m_dtpOutDate1.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Day;
            this.m_dtpOutDate1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpOutDate1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpOutDate1.Name = "m_dtpOutDate1";
            this.m_dtpOutDate1.ReadOnly = false;
            this.m_dtpOutDate1.Size = new System.Drawing.Size(141, 22);
            this.m_dtpOutDate1.TabIndex = 8;
            this.m_dtpOutDate1.Tag = "1";
            this.m_dtpOutDate1.TextBackColor = System.Drawing.Color.White;
            this.m_dtpOutDate1.TextForeColor = System.Drawing.Color.Black;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F);
            this.label2.Location = new System.Drawing.Point(210, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "~";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "出院日期";
            // 
            // m_chkIsFirst
            // 
            this.m_chkIsFirst.AutoSize = true;
            this.m_chkIsFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_chkIsFirst.Location = new System.Drawing.Point(418, 15);
            this.m_chkIsFirst.Name = "m_chkIsFirst";
            this.m_chkIsFirst.Size = new System.Drawing.Size(93, 18);
            this.m_chkIsFirst.TabIndex = 12;
            this.m_chkIsFirst.Text = "限第一诊断";
            this.m_chkIsFirst.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(566, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 18812;
            this.label4.Text = "出院科室";
            // 
            // m_cboOutDept
            // 
            this.m_cboOutDept.AccessibleDescription = "出院科室";
            this.m_cboOutDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboOutDept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cboOutDept.FormattingEnabled = true;
            this.m_cboOutDept.Location = new System.Drawing.Point(631, 13);
            this.m_cboOutDept.Name = "m_cboOutDept";
            this.m_cboOutDept.Size = new System.Drawing.Size(180, 22);
            this.m_cboOutDept.TabIndex = 18810;
            this.m_cboOutDept.SelectedIndexChanged += new System.EventHandler(this.m_cboOutDept_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(630, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(182, 24);
            this.panel1.TabIndex = 18811;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_lblSearchNums);
            this.groupBox1.Controls.Add(this.m_lsvResultList);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(804, 520);
            this.groupBox1.TabIndex = 18813;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "结果";
            // 
            // m_lblSearchNums
            // 
            this.m_lblSearchNums.AutoSize = true;
            this.m_lblSearchNums.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.m_lblSearchNums.Location = new System.Drawing.Point(558, 497);
            this.m_lblSearchNums.Name = "m_lblSearchNums";
            this.m_lblSearchNums.Size = new System.Drawing.Size(175, 14);
            this.m_lblSearchNums.TabIndex = 1;
            this.m_lblSearchNums.Text = "共检索出0种疾病，0例诊断";
            // 
            // m_lsvResultList
            // 
            this.m_lsvResultList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lsvResultList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_clmDiseaseName,
            this.m_clmDiseaseCode,
            this.m_clmCount});
            this.m_lsvResultList.FullRowSelect = true;
            this.m_lsvResultList.GridLines = true;
            this.m_lsvResultList.Location = new System.Drawing.Point(23, 22);
            this.m_lsvResultList.Name = "m_lsvResultList";
            this.m_lsvResultList.Size = new System.Drawing.Size(754, 466);
            this.m_lsvResultList.TabIndex = 0;
            this.m_lsvResultList.UseCompatibleStateImageBehavior = false;
            this.m_lsvResultList.View = System.Windows.Forms.View.Details;
            // 
            // m_clmDiseaseName
            // 
            this.m_clmDiseaseName.Text = "疾病名称";
            this.m_clmDiseaseName.Width = 500;
            // 
            // m_clmDiseaseCode
            // 
            this.m_clmDiseaseCode.Text = "疾病编码";
            this.m_clmDiseaseCode.Width = 140;
            // 
            // m_clmCount
            // 
            this.m_clmCount.Text = "例数";
            this.m_clmCount.Width = 90;
            // 
            // m_cmdClose
            // 
            this.m_cmdClose.AccessibleDescription = "关闭";
            this.m_cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.m_cmdClose.DefaultScheme = true;
            this.m_cmdClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdClose.Hint = "";
            this.m_cmdClose.Location = new System.Drawing.Point(743, 578);
            this.m_cmdClose.Name = "m_cmdClose";
            this.m_cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClose.Size = new System.Drawing.Size(71, 33);
            this.m_cmdClose.TabIndex = 18816;
            this.m_cmdClose.Text = "关闭";
            this.m_cmdClose.Click += new System.EventHandler(this.m_cmdClose_Click);
            // 
            // m_cmdClear
            // 
            this.m_cmdClear.AccessibleDescription = "清空";
            this.m_cmdClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.m_cmdClear.DefaultScheme = true;
            this.m_cmdClear.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdClear.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdClear.Hint = "";
            this.m_cmdClear.Location = new System.Drawing.Point(665, 578);
            this.m_cmdClear.Name = "m_cmdClear";
            this.m_cmdClear.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClear.Size = new System.Drawing.Size(71, 33);
            this.m_cmdClear.TabIndex = 18815;
            this.m_cmdClear.Text = "清屏";
            this.m_cmdClear.Click += new System.EventHandler(this.m_cmdClear_Click);
            // 
            // m_cmdStat
            // 
            this.m_cmdStat.AccessibleDescription = "统计";
            this.m_cmdStat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.m_cmdStat.DefaultScheme = true;
            this.m_cmdStat.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdStat.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdStat.Hint = "";
            this.m_cmdStat.Location = new System.Drawing.Point(587, 578);
            this.m_cmdStat.Name = "m_cmdStat";
            this.m_cmdStat.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdStat.Size = new System.Drawing.Size(71, 33);
            this.m_cmdStat.TabIndex = 18814;
            this.m_cmdStat.Text = "统计";
            this.m_cmdStat.Click += new System.EventHandler(this.m_cmdStat_Click);
            // 
            // frmCaseHistoryStat_Diagnose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 623);
            this.Controls.Add(this.m_cmdClose);
            this.Controls.Add(this.m_cmdClear);
            this.Controls.Add(this.m_cmdStat);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_cboOutDept);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_chkIsFirst);
            this.Controls.Add(this.m_dtpOutDate2);
            this.Controls.Add(this.m_dtpOutDate1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCaseHistoryStat_Diagnose";
            this.Text = "疾病谱统计";
            this.Load += new System.EventHandler(this.frmCaseHistoryStat_Diagnose_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private com.digitalwave.Utility.Controls.ctlTimePicker m_dtpOutDate2;
        private com.digitalwave.Utility.Controls.ctlTimePicker m_dtpOutDate1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox m_chkIsFirst;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox m_cboOutDept;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView m_lsvResultList;
        private System.Windows.Forms.ColumnHeader m_clmDiseaseName;
        private System.Windows.Forms.ColumnHeader m_clmDiseaseCode;
        private System.Windows.Forms.ColumnHeader m_clmCount;
        private System.Windows.Forms.Label m_lblSearchNums;
        private PinkieControls.ButtonXP m_cmdClose;
        private PinkieControls.ButtonXP m_cmdClear;
        private PinkieControls.ButtonXP m_cmdStat;
    }
}