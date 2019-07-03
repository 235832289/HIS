namespace iCare
{
    partial class frmCaseGradePatient
    {
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox m_cboDept;
        private System.Windows.Forms.ComboBox m_cboArea;
        private System.Windows.Forms.RadioButton m_rdbInpatientId;
        private System.Windows.Forms.RadioButton m_rdbPatientName;
        private System.Windows.Forms.TextBox m_txtInpatientId;
        private System.Windows.Forms.TextBox m_txtInpatientName;
        private System.Windows.Forms.ListView m_lsvPatient;
        private PinkieControls.ButtonXP m_cmdStatistics;
        private System.Windows.Forms.RadioButton m_rdbAll;
        private System.Windows.Forms.RadioButton m_rdbInPatient;
        private System.Windows.Forms.RadioButton m_rdbOutPatient;
        private System.Windows.Forms.Button m_cmdFind;

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
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCaseGradePatient));
            this.m_cboDept = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cboArea = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtInpatientId = new System.Windows.Forms.TextBox();
            this.m_rdbInpatientId = new System.Windows.Forms.RadioButton();
            this.m_txtInpatientName = new System.Windows.Forms.TextBox();
            this.m_rdbPatientName = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.m_cmdFind = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_rdbAll = new System.Windows.Forms.RadioButton();
            this.m_rdbInPatient = new System.Windows.Forms.RadioButton();
            this.m_rdbOutPatient = new System.Windows.Forms.RadioButton();
            this.m_lsvPatient = new System.Windows.Forms.ListView();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_cmdStatistics = new PinkieControls.ButtonXP();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_mniOpenGrade = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_cboDept
            // 
            this.m_cboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboDept.Location = new System.Drawing.Point(92, 8);
            this.m_cboDept.Name = "m_cboDept";
            this.m_cboDept.Size = new System.Drawing.Size(136, 22);
            this.m_cboDept.TabIndex = 0;
            this.m_cboDept.SelectedIndexChanged += new System.EventHandler(this.m_cboDept_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "科室:";
            // 
            // m_cboArea
            // 
            this.m_cboArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboArea.Location = new System.Drawing.Point(92, 36);
            this.m_cboArea.Name = "m_cboArea";
            this.m_cboArea.Size = new System.Drawing.Size(136, 22);
            this.m_cboArea.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "病区:";
            // 
            // m_txtInpatientId
            // 
            this.m_txtInpatientId.Enabled = false;
            this.m_txtInpatientId.Location = new System.Drawing.Point(308, 8);
            this.m_txtInpatientId.Name = "m_txtInpatientId";
            this.m_txtInpatientId.Size = new System.Drawing.Size(128, 23);
            this.m_txtInpatientId.TabIndex = 4;
            this.m_txtInpatientId.TextChanged += new System.EventHandler(this.m_txtInpatientId_TextChanged);
            // 
            // m_rdbInpatientId
            // 
            this.m_rdbInpatientId.Location = new System.Drawing.Point(236, 9);
            this.m_rdbInpatientId.Name = "m_rdbInpatientId";
            this.m_rdbInpatientId.Size = new System.Drawing.Size(76, 20);
            this.m_rdbInpatientId.TabIndex = 4;
            this.m_rdbInpatientId.Text = "住院号:";
            this.m_rdbInpatientId.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.m_rdbInpatientId.CheckedChanged += new System.EventHandler(this.m_rdbInpatientId_CheckedChanged);
            // 
            // m_txtInpatientName
            // 
            this.m_txtInpatientName.Enabled = false;
            this.m_txtInpatientName.Location = new System.Drawing.Point(308, 36);
            this.m_txtInpatientName.Name = "m_txtInpatientName";
            this.m_txtInpatientName.Size = new System.Drawing.Size(128, 23);
            this.m_txtInpatientName.TabIndex = 4;
            this.m_txtInpatientName.TextChanged += new System.EventHandler(this.m_txtInpatientId_TextChanged);
            // 
            // m_rdbPatientName
            // 
            this.m_rdbPatientName.Location = new System.Drawing.Point(236, 37);
            this.m_rdbPatientName.Name = "m_rdbPatientName";
            this.m_rdbPatientName.Size = new System.Drawing.Size(76, 20);
            this.m_rdbPatientName.TabIndex = 4;
            this.m_rdbPatientName.Text = "姓  名:";
            this.m_rdbPatientName.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.m_rdbPatientName.CheckedChanged += new System.EventHandler(this.m_rdbPatientName_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.m_cboDept);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.m_cboArea);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.m_txtInpatientId);
            this.panel1.Controls.Add(this.m_txtInpatientName);
            this.panel1.Controls.Add(this.m_rdbPatientName);
            this.panel1.Controls.Add(this.m_rdbInpatientId);
            this.panel1.Controls.Add(this.m_cmdFind);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 72);
            this.panel1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 68);
            this.label3.TabIndex = 0;
            this.label3.Text = "查询选择";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_cmdFind
            // 
            this.m_cmdFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdFind.BackColor = System.Drawing.Color.LightSlateGray;
            this.m_cmdFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_cmdFind.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.m_cmdFind.FlatAppearance.BorderSize = 2;
            this.m_cmdFind.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateGray;
            this.m_cmdFind.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.m_cmdFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdFind.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.m_cmdFind.ForeColor = System.Drawing.Color.White;
            this.m_cmdFind.Location = new System.Drawing.Point(444, 8);
            this.m_cmdFind.Name = "m_cmdFind";
            this.m_cmdFind.Size = new System.Drawing.Size(108, 52);
            this.m_cmdFind.TabIndex = 7;
            this.m_cmdFind.Text = "病人查询(F3)";
            this.m_cmdFind.UseVisualStyleBackColor = false;
            this.m_cmdFind.Click += new System.EventHandler(this.m_cmdFind_Click);
            this.m_cmdFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCaseGradePatient_KeyDown);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.m_rdbAll);
            this.panel2.Controls.Add(this.m_rdbInPatient);
            this.panel2.Controls.Add(this.m_rdbOutPatient);
            this.panel2.Location = new System.Drawing.Point(568, 44);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(184, 32);
            this.panel2.TabIndex = 5;
            // 
            // m_rdbAll
            // 
            this.m_rdbAll.Checked = true;
            this.m_rdbAll.Location = new System.Drawing.Point(4, 4);
            this.m_rdbAll.Name = "m_rdbAll";
            this.m_rdbAll.Size = new System.Drawing.Size(54, 20);
            this.m_rdbAll.TabIndex = 4;
            this.m_rdbAll.TabStop = true;
            this.m_rdbAll.Text = "全部";
            this.m_rdbAll.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.m_rdbAll.Click += new System.EventHandler(this.m_rdbInPatient_CheckedChanged);
            // 
            // m_rdbInPatient
            // 
            this.m_rdbInPatient.Location = new System.Drawing.Point(64, 4);
            this.m_rdbInPatient.Name = "m_rdbInPatient";
            this.m_rdbInPatient.Size = new System.Drawing.Size(54, 20);
            this.m_rdbInPatient.TabIndex = 4;
            this.m_rdbInPatient.Text = "在院";
            this.m_rdbInPatient.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.m_rdbInPatient.Click += new System.EventHandler(this.m_rdbInPatient_CheckedChanged);
            // 
            // m_rdbOutPatient
            // 
            this.m_rdbOutPatient.Location = new System.Drawing.Point(124, 4);
            this.m_rdbOutPatient.Name = "m_rdbOutPatient";
            this.m_rdbOutPatient.Size = new System.Drawing.Size(53, 20);
            this.m_rdbOutPatient.TabIndex = 4;
            this.m_rdbOutPatient.Text = "出院";
            this.m_rdbOutPatient.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.m_rdbOutPatient.Click += new System.EventHandler(this.m_rdbInPatient_CheckedChanged);
            // 
            // m_lsvPatient
            // 
            this.m_lsvPatient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lsvPatient.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.m_lsvPatient.ContextMenuStrip = this.contextMenuStrip1;
            this.m_lsvPatient.FullRowSelect = true;
            this.m_lsvPatient.GridLines = true;
            this.m_lsvPatient.Location = new System.Drawing.Point(4, 80);
            this.m_lsvPatient.Name = "m_lsvPatient";
            this.m_lsvPatient.Size = new System.Drawing.Size(748, 428);
            this.m_lsvPatient.TabIndex = 6;
            this.m_lsvPatient.UseCompatibleStateImageBehavior = false;
            this.m_lsvPatient.View = System.Windows.Forms.View.Details;
            this.m_lsvPatient.DoubleClick += new System.EventHandler(this.m_lsvPatient_DoubleClick);
            this.m_lsvPatient.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCaseGradePatient_KeyDown);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "姓  名";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "住院号";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 110;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "住院日期";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 136;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "出院日期";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 138;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "评分时间";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 156;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "评分结果";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 87;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.m_cmdStatistics);
            this.panel3.Location = new System.Drawing.Point(568, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(184, 36);
            this.panel3.TabIndex = 5;
            // 
            // m_cmdStatistics
            // 
            this.m_cmdStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdStatistics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdStatistics.DefaultScheme = true;
            this.m_cmdStatistics.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdStatistics.Hint = "";
            this.m_cmdStatistics.Location = new System.Drawing.Point(4, 2);
            this.m_cmdStatistics.Name = "m_cmdStatistics";
            this.m_cmdStatistics.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdStatistics.Size = new System.Drawing.Size(172, 28);
            this.m_cmdStatistics.TabIndex = 3;
            this.m_cmdStatistics.Text = "评  分  统  计 (F6)";
            this.m_cmdStatistics.Click += new System.EventHandler(this.m_cmdStatistics_Click);
            this.m_cmdStatistics.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCaseGradePatient_KeyDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_mniOpenGrade});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(143, 26);
            // 
            // m_mniOpenGrade
            // 
            this.m_mniOpenGrade.Name = "m_mniOpenGrade";
            this.m_mniOpenGrade.Size = new System.Drawing.Size(142, 22);
            this.m_mniOpenGrade.Text = "填写评分(F5)";
            this.m_mniOpenGrade.Click += new System.EventHandler(this.m_mniOpenGrade_Click);
            // 
            // frmCaseGradePatient
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(756, 513);
            this.Controls.Add(this.m_lsvPatient);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCaseGradePatient";
            this.Text = "住院病历评分与统计";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem m_mniOpenGrade;
        private System.ComponentModel.IContainer components;
    }
}