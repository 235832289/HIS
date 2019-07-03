namespace com.digitalwave.iCare.gui.LIS
{
    partial class frmADVIA2120
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExit = new PinkieControls.ButtonXP();
            this.rdbAll = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.rdbUncheck = new System.Windows.Forms.RadioButton();
            this.rdbCheckd = new System.Windows.Forms.RadioButton();
            this.m_dtpCheckDate = new NullableDateControls.MaskDateEdit();
            this.txtSampleIDTo = new System.Windows.Forms.TextBox();
            this.cboDept = new System.Windows.Forms.ComboBox();
            this.cboPatientType = new System.Windows.Forms.ComboBox();
            this.txtSampleIDFrom = new System.Windows.Forms.TextBox();
            this.cmdInsertReport = new PinkieControls.ButtonXP();
            this.cmdConfig = new PinkieControls.ButtonXP();
            this.cmdQuery = new PinkieControls.ButtonXP();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(0, 120);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1012, 512);
            this.panel2.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.listView2);
            this.groupBox2.Location = new System.Drawing.Point(504, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(508, 483);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "检验结果表：";
            // 
            // listView2
            // 
            this.listView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17});
            this.listView2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView2.Location = new System.Drawing.Point(3, 14);
            this.listView2.MultiSelect = false;
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(502, 466);
            this.listView2.TabIndex = 1;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "序号";
            this.columnHeader10.Width = 40;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "项目代号";
            this.columnHeader11.Width = 90;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "OD值";
            this.columnHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader12.Width = 42;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "测值";
            this.columnHeader13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader13.Width = 50;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "字符测值";
            this.columnHeader14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader14.Width = 72;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "检查状态";
            this.columnHeader15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader15.Width = 72;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "检测日期";
            this.columnHeader16.Width = 92;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "有图";
            this.columnHeader17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader17.Width = 42;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Location = new System.Drawing.Point(0, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(506, 483);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "样本列表：";
            // 
            // listView1
            // 
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 14);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(500, 466);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "样本号";
            this.columnHeader1.Width = 57;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "病员号";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 62;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "姓名";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 70;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "性别";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 42;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "采样日期";
            this.columnHeader5.Width = 145;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "送检医生";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 70;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "送检日期";
            this.columnHeader7.Width = 145;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "标识号";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader8.Width = 120;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "检查状态";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader9.Width = 68;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1012, 512);
            this.label2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.rdbAll);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.rdbUncheck);
            this.panel1.Controls.Add(this.rdbCheckd);
            this.panel1.Controls.Add(this.m_dtpCheckDate);
            this.panel1.Controls.Add(this.txtSampleIDTo);
            this.panel1.Controls.Add(this.cboDept);
            this.panel1.Controls.Add(this.cboPatientType);
            this.panel1.Controls.Add(this.txtSampleIDFrom);
            this.panel1.Controls.Add(this.cmdInsertReport);
            this.panel1.Controls.Add(this.cmdConfig);
            this.panel1.Controls.Add(this.cmdQuery);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1012, 117);
            this.panel1.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnExit.DefaultScheme = true;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExit.Hint = "";
            this.btnExit.Location = new System.Drawing.Point(877, 65);
            this.btnExit.Name = "btnExit";
            this.btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnExit.Size = new System.Drawing.Size(90, 32);
            this.btnExit.TabIndex = 18;
            this.btnExit.Text = "关闭(&C)";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // rdbAll
            // 
            this.rdbAll.AccessibleName = "11";
            this.rdbAll.AutoSize = true;
            this.rdbAll.Checked = true;
            this.rdbAll.Location = new System.Drawing.Point(664, 70);
            this.rdbAll.Name = "rdbAll";
            this.rdbAll.Size = new System.Drawing.Size(53, 18);
            this.rdbAll.TabIndex = 13;
            this.rdbAll.TabStop = true;
            this.rdbAll.Text = "全部";
            this.rdbAll.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(247, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 14);
            this.label3.TabIndex = 16;
            this.label3.Text = "~";
            // 
            // rdbUncheck
            // 
            this.rdbUncheck.AccessibleName = "11";
            this.rdbUncheck.AutoSize = true;
            this.rdbUncheck.Location = new System.Drawing.Point(505, 70);
            this.rdbUncheck.Name = "rdbUncheck";
            this.rdbUncheck.Size = new System.Drawing.Size(67, 18);
            this.rdbUncheck.TabIndex = 11;
            this.rdbUncheck.TabStop = true;
            this.rdbUncheck.Text = "未检查";
            this.rdbUncheck.UseVisualStyleBackColor = true;
            // 
            // rdbCheckd
            // 
            this.rdbCheckd.AccessibleName = "11";
            this.rdbCheckd.AutoSize = true;
            this.rdbCheckd.Location = new System.Drawing.Point(582, 70);
            this.rdbCheckd.Name = "rdbCheckd";
            this.rdbCheckd.Size = new System.Drawing.Size(67, 18);
            this.rdbCheckd.TabIndex = 12;
            this.rdbCheckd.TabStop = true;
            this.rdbCheckd.Text = "已检查";
            this.rdbCheckd.UseVisualStyleBackColor = true;
            // 
            // m_dtpCheckDate
            // 
            this.m_dtpCheckDate.AccessibleName = "11";
            this.m_dtpCheckDate.BackColor = System.Drawing.SystemColors.HighlightText;
            this.m_dtpCheckDate.Location = new System.Drawing.Point(98, 26);
            this.m_dtpCheckDate.Mask = "yyyy年MM月dd日";
            this.m_dtpCheckDate.Name = "m_dtpCheckDate";
            this.m_dtpCheckDate.Size = new System.Drawing.Size(147, 23);
            this.m_dtpCheckDate.TabIndex = 2;
            // 
            // txtSampleIDTo
            // 
            this.txtSampleIDTo.AccessibleName = "11";
            this.txtSampleIDTo.Location = new System.Drawing.Point(267, 69);
            this.txtSampleIDTo.Name = "txtSampleIDTo";
            this.txtSampleIDTo.Size = new System.Drawing.Size(147, 23);
            this.txtSampleIDTo.TabIndex = 10;
            // 
            // cboDept
            // 
            this.cboDept.AccessibleName = "11";
            this.cboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDept.FormattingEnabled = true;
            this.cboDept.Location = new System.Drawing.Point(503, 26);
            this.cboDept.Name = "cboDept";
            this.cboDept.Size = new System.Drawing.Size(208, 22);
            this.cboDept.TabIndex = 8;
            this.cboDept.Leave += new System.EventHandler(this.cboDept_Leave);
            this.cboDept.Enter += new System.EventHandler(this.cboDept_Enter);
            this.cboDept.SelectedIndexChanged += new System.EventHandler(this.cboDept_SelectedIndexChanged);
            // 
            // cboPatientType
            // 
            this.cboPatientType.AccessibleName = "11";
            this.cboPatientType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPatientType.FormattingEnabled = true;
            this.cboPatientType.Location = new System.Drawing.Point(337, 26);
            this.cboPatientType.Name = "cboPatientType";
            this.cboPatientType.Size = new System.Drawing.Size(77, 22);
            this.cboPatientType.TabIndex = 7;
            this.cboPatientType.Leave += new System.EventHandler(this.cboPatientType_Leave);
            this.cboPatientType.Enter += new System.EventHandler(this.cboPatientType_Enter);
            this.cboPatientType.SelectedIndexChanged += new System.EventHandler(this.cboPatientType_SelectedIndexChanged);
            // 
            // txtSampleIDFrom
            // 
            this.txtSampleIDFrom.AccessibleName = "11";
            this.txtSampleIDFrom.Location = new System.Drawing.Point(98, 69);
            this.txtSampleIDFrom.Name = "txtSampleIDFrom";
            this.txtSampleIDFrom.Size = new System.Drawing.Size(147, 23);
            this.txtSampleIDFrom.TabIndex = 9;
            // 
            // cmdInsertReport
            // 
            this.cmdInsertReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdInsertReport.DefaultScheme = true;
            this.cmdInsertReport.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdInsertReport.Hint = "";
            this.cmdInsertReport.Location = new System.Drawing.Point(768, 65);
            this.cmdInsertReport.Name = "cmdInsertReport";
            this.cmdInsertReport.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdInsertReport.Size = new System.Drawing.Size(90, 32);
            this.cmdInsertReport.TabIndex = 17;
            this.cmdInsertReport.Text = "插入报告单";
            this.cmdInsertReport.Click += new System.EventHandler(this.cmdInsertReport_Click);
            // 
            // cmdConfig
            // 
            this.cmdConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdConfig.DefaultScheme = true;
            this.cmdConfig.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdConfig.Hint = "";
            this.cmdConfig.Location = new System.Drawing.Point(877, 23);
            this.cmdConfig.Name = "cmdConfig";
            this.cmdConfig.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdConfig.Size = new System.Drawing.Size(90, 32);
            this.cmdConfig.TabIndex = 15;
            this.cmdConfig.Text = "设置";
            this.cmdConfig.Click += new System.EventHandler(this.cmdConfig_Click);
            // 
            // cmdQuery
            // 
            this.cmdQuery.AccessibleName = "11";
            this.cmdQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdQuery.DefaultScheme = true;
            this.cmdQuery.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdQuery.Hint = "";
            this.cmdQuery.Location = new System.Drawing.Point(768, 23);
            this.cmdQuery.Name = "cmdQuery";
            this.cmdQuery.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdQuery.Size = new System.Drawing.Size(90, 32);
            this.cmdQuery.TabIndex = 14;
            this.cmdQuery.Text = "查找";
            this.cmdQuery.Click += new System.EventHandler(this.cmdQuery_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(429, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 14);
            this.label8.TabIndex = 6;
            this.label8.Text = "科室：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(429, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 14);
            this.label7.TabIndex = 5;
            this.label7.Text = "检查状态：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 4;
            this.label6.Text = "样本号：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 14);
            this.label5.TabIndex = 3;
            this.label5.Text = "检验日期：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(264, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 2;
            this.label4.Text = "病人类型：";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1012, 117);
            this.label1.TabIndex = 0;
            // 
            // frmADVIA2120
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 632);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmADVIA2120";
            this.Text = "血球仪Advia2120数据接口";
            this.Load += new System.EventHandler(this.frmADVIA2120_Load);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        internal NullableDateControls.MaskDateEdit m_dtpCheckDate;
        internal System.Windows.Forms.ListView listView1;
        internal System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        internal PinkieControls.ButtonXP cmdInsertReport;
        internal PinkieControls.ButtonXP cmdConfig;
        internal PinkieControls.ButtonXP cmdQuery;
        internal System.Windows.Forms.TextBox txtSampleIDTo;
        internal System.Windows.Forms.ComboBox cboDept;
        internal System.Windows.Forms.ComboBox cboPatientType;
        internal System.Windows.Forms.TextBox txtSampleIDFrom;
        internal System.Windows.Forms.RadioButton rdbUncheck;
        internal System.Windows.Forms.RadioButton rdbCheckd;
        internal System.Windows.Forms.RadioButton rdbAll;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private PinkieControls.ButtonXP btnExit;
    }
}