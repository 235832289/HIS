namespace iCare
{
    partial class frmCaseHistorySearch_OutReg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCaseHistorySearch_OutReg));
            this.m_dtpOutDate1 = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_cboOutDept = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_lblSearchNums = new System.Windows.Forms.Label();
            this.m_lsvResultList = new System.Windows.Forms.ListView();
            this.m_clmInPatientID = new System.Windows.Forms.ColumnHeader();
            this.m_clmPatientName = new System.Windows.Forms.ColumnHeader();
            this.m_clmPatientAge = new System.Windows.Forms.ColumnHeader();
            this.m_cmdClose = new PinkieControls.ButtonXP();
            this.m_cmdClear = new PinkieControls.ButtonXP();
            this.m_cmdQuery = new PinkieControls.ButtonXP();
            this.m_clmPatientSex = new System.Windows.Forms.ColumnHeader();
            this.m_clmInPatientDate = new System.Windows.Forms.ColumnHeader();
            this.m_clmOutDept = new System.Windows.Forms.ColumnHeader();
            this.m_clmOutDate = new System.Windows.Forms.ColumnHeader();
            this.m_clmPayType = new System.Windows.Forms.ColumnHeader();
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
            this.m_dtpOutDate1.Location = new System.Drawing.Point(112, 16);
            this.m_dtpOutDate1.m_BlnOnlyTime = false;
            this.m_dtpOutDate1.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Day;
            this.m_dtpOutDate1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpOutDate1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpOutDate1.Name = "m_dtpOutDate1";
            this.m_dtpOutDate1.ReadOnly = false;
            this.m_dtpOutDate1.Size = new System.Drawing.Size(141, 22);
            this.m_dtpOutDate1.TabIndex = 14;
            this.m_dtpOutDate1.Tag = "1";
            this.m_dtpOutDate1.TextBackColor = System.Drawing.Color.White;
            this.m_dtpOutDate1.TextForeColor = System.Drawing.Color.Black;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 15;
            this.label1.Text = "出院日期";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(504, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 18818;
            this.label4.Text = "出院科室";
            // 
            // m_cboOutDept
            // 
            this.m_cboOutDept.AccessibleDescription = "出院科室";
            this.m_cboOutDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboOutDept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cboOutDept.FormattingEnabled = true;
            this.m_cboOutDept.Location = new System.Drawing.Point(569, 16);
            this.m_cboOutDept.Name = "m_cboOutDept";
            this.m_cboOutDept.Size = new System.Drawing.Size(180, 22);
            this.m_cboOutDept.TabIndex = 18816;
            this.m_cboOutDept.SelectedIndexChanged += new System.EventHandler(this.m_cboOutDept_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(568, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(182, 24);
            this.panel1.TabIndex = 18817;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_lblSearchNums);
            this.groupBox1.Controls.Add(this.m_lsvResultList);
            this.groupBox1.Location = new System.Drawing.Point(12, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(804, 520);
            this.groupBox1.TabIndex = 18819;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "结果";
            // 
            // m_lblSearchNums
            // 
            this.m_lblSearchNums.AutoSize = true;
            this.m_lblSearchNums.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.m_lblSearchNums.Location = new System.Drawing.Point(558, 497);
            this.m_lblSearchNums.Name = "m_lblSearchNums";
            this.m_lblSearchNums.Size = new System.Drawing.Size(112, 14);
            this.m_lblSearchNums.TabIndex = 1;
            this.m_lblSearchNums.Text = "共计0个出院病人";
            // 
            // m_lsvResultList
            // 
            this.m_lsvResultList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lsvResultList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_clmInPatientID,
            this.m_clmPatientName,
            this.m_clmPatientAge,
            this.m_clmPatientSex,
            this.m_clmInPatientDate,
            this.m_clmOutDept,
            this.m_clmOutDate,
            this.m_clmPayType});
            this.m_lsvResultList.FullRowSelect = true;
            this.m_lsvResultList.GridLines = true;
            this.m_lsvResultList.Location = new System.Drawing.Point(6, 22);
            this.m_lsvResultList.Name = "m_lsvResultList";
            this.m_lsvResultList.Size = new System.Drawing.Size(792, 466);
            this.m_lsvResultList.TabIndex = 0;
            this.m_lsvResultList.UseCompatibleStateImageBehavior = false;
            this.m_lsvResultList.View = System.Windows.Forms.View.Details;
            // 
            // m_clmInPatientID
            // 
            this.m_clmInPatientID.Text = "住院号";
            this.m_clmInPatientID.Width = 90;
            // 
            // m_clmPatientName
            // 
            this.m_clmPatientName.Text = "姓名";
            this.m_clmPatientName.Width = 120;
            // 
            // m_clmPatientAge
            // 
            this.m_clmPatientAge.Text = "年龄";
            // 
            // m_cmdClose
            // 
            this.m_cmdClose.AccessibleDescription = "关闭";
            this.m_cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdClose.DefaultScheme = true;
            this.m_cmdClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdClose.Hint = "";
            this.m_cmdClose.Location = new System.Drawing.Point(738, 570);
            this.m_cmdClose.Name = "m_cmdClose";
            this.m_cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClose.Size = new System.Drawing.Size(71, 33);
            this.m_cmdClose.TabIndex = 18822;
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
            this.m_cmdClear.Location = new System.Drawing.Point(660, 570);
            this.m_cmdClear.Name = "m_cmdClear";
            this.m_cmdClear.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClear.Size = new System.Drawing.Size(71, 33);
            this.m_cmdClear.TabIndex = 18821;
            this.m_cmdClear.Text = "清屏";
            this.m_cmdClear.Click += new System.EventHandler(this.m_cmdClear_Click);
            // 
            // m_cmdQuery
            // 
            this.m_cmdQuery.AccessibleDescription = "查询";
            this.m_cmdQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdQuery.DefaultScheme = true;
            this.m_cmdQuery.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdQuery.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdQuery.Hint = "";
            this.m_cmdQuery.Location = new System.Drawing.Point(582, 570);
            this.m_cmdQuery.Name = "m_cmdQuery";
            this.m_cmdQuery.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdQuery.Size = new System.Drawing.Size(71, 33);
            this.m_cmdQuery.TabIndex = 18820;
            this.m_cmdQuery.Text = "查询";
            this.m_cmdQuery.Click += new System.EventHandler(this.m_cmdQuery_Click);
            // 
            // m_clmPatientSex
            // 
            this.m_clmPatientSex.Text = "性别";
            // 
            // m_clmInPatientDate
            // 
            this.m_clmInPatientDate.Text = "入院时间";
            this.m_clmInPatientDate.Width = 100;
            // 
            // m_clmOutDept
            // 
            this.m_clmOutDept.Text = "出院科室";
            this.m_clmOutDept.Width = 160;
            // 
            // m_clmOutDate
            // 
            this.m_clmOutDate.Text = "出院时间";
            this.m_clmOutDate.Width = 100;
            // 
            // m_clmPayType
            // 
            this.m_clmPayType.Text = "费别";
            this.m_clmPayType.Width = 80;
            // 
            // frmCaseHistorySearch_OutReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 623);
            this.Controls.Add(this.m_cmdClose);
            this.Controls.Add(this.m_cmdClear);
            this.Controls.Add(this.m_cmdQuery);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_cboOutDept);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_dtpOutDate1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCaseHistorySearch_OutReg";
            this.Text = "出院病人登记表";
            this.Load += new System.EventHandler(this.frmCaseHistorySearch_OutReg_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private com.digitalwave.Utility.Controls.ctlTimePicker m_dtpOutDate1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox m_cboOutDept;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label m_lblSearchNums;
        private System.Windows.Forms.ListView m_lsvResultList;
        private System.Windows.Forms.ColumnHeader m_clmInPatientID;
        private System.Windows.Forms.ColumnHeader m_clmPatientName;
        private System.Windows.Forms.ColumnHeader m_clmPatientAge;
        private System.Windows.Forms.ColumnHeader m_clmPatientSex;
        private System.Windows.Forms.ColumnHeader m_clmInPatientDate;
        private System.Windows.Forms.ColumnHeader m_clmOutDept;
        private System.Windows.Forms.ColumnHeader m_clmOutDate;
        private PinkieControls.ButtonXP m_cmdClose;
        private PinkieControls.ButtonXP m_cmdClear;
        private PinkieControls.ButtonXP m_cmdQuery;
        private System.Windows.Forms.ColumnHeader m_clmPayType;
    }
}