namespace com.digitalwave.iCare.gui.LIS
{
    partial class frmMBY2010
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
            this.components = new System.ComponentModel.Container();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvwColumnSorter = new ListViewColumnSorter();
            this.m_lsvResult = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.datReportDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.btnFilter = new PinkieControls.ButtonXP();
            this.btnExit = new PinkieControls.ButtonXP();
            this.txtMachineCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnUpdate = new PinkieControls.ButtonXP();
            this.btnReflesh = new PinkieControls.ButtonXP();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQueryRange = new System.Windows.Forms.TextBox();
            this.txtInitNum = new System.Windows.Forms.TextBox();
            this.cboItem = new System.Windows.Forms.ComboBox();
            this.m_dtpQueryDate = new NullableDateControls.MaskDateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lsvPatList = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.panel2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(0, 91);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1012, 541);
            this.panel2.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(1012, 541);
            this.splitContainer1.SplitterDistance = 499;
            this.splitContainer1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lsvPatList);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(499, 541);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "样本列表";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_lsvResult);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(509, 541);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "检验结果";
            // 
            // m_lsvResult
            // 
            this.m_lsvResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lsvResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_lsvResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.m_lsvResult.FullRowSelect = true;
            this.m_lsvResult.GridLines = true;
            this.m_lsvResult.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.m_lsvResult.HideSelection = false;
            this.m_lsvResult.Location = new System.Drawing.Point(3, 15);
            this.m_lsvResult.Name = "m_lsvResult";
            this.m_lsvResult.Size = new System.Drawing.Size(502, 522);
            this.m_lsvResult.TabIndex = 0;
            this.m_lsvResult.UseCompatibleStateImageBehavior = false;
            this.m_lsvResult.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "序号";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "样本号";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 130;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "项目名称";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 190;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "结果";
            this.columnHeader4.Width = 130;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(1012, 541);
            this.label7.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_dtpQueryDate);
            this.panel1.Controls.Add(this.datReportDate);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.btnFilter);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.txtMachineCode);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnReflesh);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtQueryRange);
            this.panel1.Controls.Add(this.txtInitNum);
            this.panel1.Controls.Add(this.cboItem);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1012, 88);
            this.panel1.TabIndex = 0;
            // 
            // datReportDate
            // 
            this.datReportDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.datReportDate.Location = new System.Drawing.Point(655, 14);
            this.datReportDate.Name = "datReportDate";
            this.datReportDate.Size = new System.Drawing.Size(120, 23);
            this.datReportDate.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(585, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 14);
            this.label8.TabIndex = 23;
            this.label8.Text = "报告日期：";
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnFilter.DefaultScheme = true;
            this.btnFilter.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFilter.Hint = "";
            this.btnFilter.Location = new System.Drawing.Point(792, 48);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Scheme = PinkieControls.ButtonXP.Schemes.Silver;
            this.btnFilter.Size = new System.Drawing.Size(94, 34);
            this.btnFilter.TabIndex = 22;
            this.btnFilter.Text = "过滤(&F)";
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnExit.DefaultScheme = true;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExit.Hint = "";
            this.btnExit.Location = new System.Drawing.Point(898, 48);
            this.btnExit.Name = "btnExit";
            this.btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Silver;
            this.btnExit.Size = new System.Drawing.Size(94, 34);
            this.btnExit.TabIndex = 21;
            this.btnExit.Text = "关闭(&C)";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtMachineCode
            // 
            this.txtMachineCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMachineCode.Location = new System.Drawing.Point(655, 51);
            this.txtMachineCode.MaxLength = 25;
            this.txtMachineCode.Name = "txtMachineCode";
            this.txtMachineCode.Size = new System.Drawing.Size(120, 23);
            this.txtMachineCode.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(585, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 19;
            this.label6.Text = "仪器代号：";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnUpdate.DefaultScheme = true;
            this.btnUpdate.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnUpdate.Hint = "";
            this.btnUpdate.Location = new System.Drawing.Point(898, 7);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Scheme = PinkieControls.ButtonXP.Schemes.Silver;
            this.btnUpdate.Size = new System.Drawing.Size(94, 34);
            this.btnUpdate.TabIndex = 18;
            this.btnUpdate.Text = "插入报告单";
            this.toolTip1.SetToolTip(this.btnUpdate, "插入报告单前先输入酶标仪的仪器代号(检验编号 = 仪器代号 + 标本号)");
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnReflesh
            // 
            this.btnReflesh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReflesh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnReflesh.DefaultScheme = true;
            this.btnReflesh.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnReflesh.Hint = "";
            this.btnReflesh.Location = new System.Drawing.Point(792, 7);
            this.btnReflesh.Name = "btnReflesh";
            this.btnReflesh.Scheme = PinkieControls.ButtonXP.Schemes.Silver;
            this.btnReflesh.Size = new System.Drawing.Size(94, 34);
            this.btnReflesh.TabIndex = 17;
            this.btnReflesh.Text = "接收结果";
            this.btnReflesh.Click += new System.EventHandler(this.btnReflesh_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 14);
            this.label5.TabIndex = 16;
            this.label5.Text = "请输入要插入的样本号段：";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(413, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 15;
            this.label4.Text = "前缀：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(220, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 14;
            this.label3.Text = "项目：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 13;
            this.label2.Text = "接收日期：";
            // 
            // txtQueryRange
            // 
            this.txtQueryRange.AccessibleName = "5";
            this.txtQueryRange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQueryRange.Location = new System.Drawing.Point(215, 51);
            this.txtQueryRange.MaxLength = 255;
            this.txtQueryRange.Name = "txtQueryRange";
            this.txtQueryRange.Size = new System.Drawing.Size(364, 23);
            this.txtQueryRange.TabIndex = 12;
            this.toolTip1.SetToolTip(this.txtQueryRange, "样本号段之前用\"-\"，不同样本号段用\";\"隔开");
            // 
            // txtInitNum
            // 
            this.txtInitNum.AccessibleName = "5";
            this.txtInitNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInitNum.Location = new System.Drawing.Point(465, 14);
            this.txtInitNum.MaxLength = 10;
            this.txtInitNum.Name = "txtInitNum";
            this.txtInitNum.Size = new System.Drawing.Size(114, 23);
            this.txtInitNum.TabIndex = 11;
            // 
            // cboItem
            // 
            this.cboItem.AccessibleName = "5";
            this.cboItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboItem.FormattingEnabled = true;
            this.cboItem.Location = new System.Drawing.Point(272, 15);
            this.cboItem.Name = "cboItem";
            this.cboItem.Size = new System.Drawing.Size(136, 22);
            this.cboItem.TabIndex = 10;
            this.cboItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboItem_KeyPress);
            // 
            // m_dtpQueryDate
            // 
            this.m_dtpQueryDate.AccessibleName = "5";
            this.m_dtpQueryDate.BackColor = System.Drawing.SystemColors.HighlightText;
            this.m_dtpQueryDate.Location = new System.Drawing.Point(94, 14);
            this.m_dtpQueryDate.Mask = "yyyy年MM月dd日";
            this.m_dtpQueryDate.Name = "m_dtpQueryDate";
            this.m_dtpQueryDate.Size = new System.Drawing.Size(120, 23);
            this.m_dtpQueryDate.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1012, 88);
            this.label1.TabIndex = 0;
            // 
            // lsvPatList
            // 
            this.lsvPatList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvPatList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lsvPatList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lsvPatList.FullRowSelect = true;
            this.lsvPatList.GridLines = true;
            this.lsvPatList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvPatList.HideSelection = false;
            this.lsvPatList.Location = new System.Drawing.Point(3, 15);
            this.lsvPatList.Name = "lsvPatList";
            this.lsvPatList.Size = new System.Drawing.Size(492, 522);
            this.lsvPatList.TabIndex = 1;
            this.lsvPatList.UseCompatibleStateImageBehavior = false;
            this.lsvPatList.View = System.Windows.Forms.View.Details;
            this.lsvPatList.ListViewItemSorter = this.lvwColumnSorter;
            this.lsvPatList.SelectedIndexChanged += new System.EventHandler(this.lsvPatList_SelectedIndexChanged);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "序号";
            this.columnHeader5.Width = 0;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "送检时间";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 210;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "检验仪器";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 130;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "检验样本号";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader8.Width = 136;
            // 
            // frmMBY2010
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 632);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KeyPreview = true;
            this.Name = "frmMBY2010";
            this.ShowInTaskbar = false;
            this.Text = "酶标仪2010结果接收";
            this.Load += new System.EventHandler(this.frmMBY2010_Load);
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        internal NullableDateControls.MaskDateEdit m_dtpQueryDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtQueryRange;
        internal System.Windows.Forms.TextBox txtInitNum;
        internal System.Windows.Forms.ComboBox cboItem;
        internal PinkieControls.ButtonXP btnUpdate;
        internal PinkieControls.ButtonXP btnReflesh;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        internal System.Windows.Forms.ListView m_lsvResult;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolTip toolTip1;
        internal System.Windows.Forms.TextBox txtMachineCode;
        private PinkieControls.ButtonXP btnExit;
        private System.Windows.Forms.Label label7;
        internal ListViewColumnSorter lvwColumnSorter;
        internal PinkieControls.ButtonXP btnFilter;
        private System.Windows.Forms.SplitContainer splitContainer1;
        internal System.Windows.Forms.ListView lsvPatList;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.DateTimePicker datReportDate;
    }
}