namespace iCare
{
    partial class frmBugQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBugQuery));
            this.m_pdcShow = new System.Drawing.Printing.PrintDocument();
            this.pnlIsBusy = new System.Windows.Forms.Panel();
            this.picClock = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.m_trvItems = new System.Windows.Forms.TreeView();
            this.m_cmdSelectAll = new PinkieControls.ButtonXP();
            this.m_cmdClearSelect = new PinkieControls.ButtonXP();
            this.m_cmdSaveDefault = new PinkieControls.ButtonXP();
            this.m_cmdSelectDefault = new PinkieControls.ButtonXP();
            this.m_txtDept = new System.Windows.Forms.TextBox();
            this.m_rdbSurgery = new System.Windows.Forms.RadioButton();
            this.m_rdbMedical = new System.Windows.Forms.RadioButton();
            this.m_rdbSingleDept = new System.Windows.Forms.RadioButton();
            this.m_rdbAllDept = new System.Windows.Forms.RadioButton();
            this.btnprint = new PinkieControls.ButtonXP();
            this.btnQuery = new PinkieControls.ButtonXP();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_ppwShow = new com.digitalwave.controls.Control.ctlprintShow();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.m_dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.btnEsc = new PinkieControls.ButtonXP();
            this.label2 = new System.Windows.Forms.Label();
            this.m_lsvFind = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlIsBusy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClock)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_pdcShow
            // 
            this.m_pdcShow.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.m_pdcShow_PrintPage);
            this.m_pdcShow.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcShow_EndPrint);
            this.m_pdcShow.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcShow_BeginPrint);
            // 
            // pnlIsBusy
            // 
            this.pnlIsBusy.BackColor = System.Drawing.Color.White;
            this.pnlIsBusy.Controls.Add(this.picClock);
            this.pnlIsBusy.Controls.Add(this.label3);
            this.pnlIsBusy.Location = new System.Drawing.Point(343, 185);
            this.pnlIsBusy.Name = "pnlIsBusy";
            this.pnlIsBusy.Size = new System.Drawing.Size(300, 84);
            this.pnlIsBusy.TabIndex = 5;
            this.pnlIsBusy.Visible = false;
            // 
            // picClock
            // 
            this.picClock.Image = ((System.Drawing.Image)(resources.GetObject("picClock.Image")));
            this.picClock.Location = new System.Drawing.Point(12, 8);
            this.picClock.Name = "picClock";
            this.picClock.Size = new System.Drawing.Size(68, 68);
            this.picClock.TabIndex = 5;
            this.picClock.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(96, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "正在查询，请稍候......";
            // 
            // m_trvItems
            // 
            this.m_trvItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_trvItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_trvItems.CheckBoxes = true;
            this.m_trvItems.Location = new System.Drawing.Point(0, 0);
            this.m_trvItems.Name = "m_trvItems";
            this.m_trvItems.Size = new System.Drawing.Size(196, 450);
            this.m_trvItems.TabIndex = 0;
            this.toolTip1.SetToolTip(this.m_trvItems, "在需要作统计的项上打上勾");
            // 
            // m_cmdSelectAll
            // 
            this.m_cmdSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_cmdSelectAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdSelectAll.DefaultScheme = true;
            this.m_cmdSelectAll.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdSelectAll.Hint = "";
            this.m_cmdSelectAll.Location = new System.Drawing.Point(4, 452);
            this.m_cmdSelectAll.Name = "m_cmdSelectAll";
            this.m_cmdSelectAll.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSelectAll.Size = new System.Drawing.Size(92, 28);
            this.m_cmdSelectAll.TabIndex = 31;
            this.m_cmdSelectAll.Text = "全选(&A)";
            this.toolTip1.SetToolTip(this.m_cmdSelectAll, "选择全部的项目");
            this.m_cmdSelectAll.Click += new System.EventHandler(this.m_cmdSelectAll_Click);
            // 
            // m_cmdClearSelect
            // 
            this.m_cmdClearSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_cmdClearSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdClearSelect.DefaultScheme = true;
            this.m_cmdClearSelect.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdClearSelect.Hint = "";
            this.m_cmdClearSelect.Location = new System.Drawing.Point(4, 480);
            this.m_cmdClearSelect.Name = "m_cmdClearSelect";
            this.m_cmdClearSelect.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClearSelect.Size = new System.Drawing.Size(92, 28);
            this.m_cmdClearSelect.TabIndex = 31;
            this.m_cmdClearSelect.Text = "清除(&C)";
            this.toolTip1.SetToolTip(this.m_cmdClearSelect, "清除所有的选择");
            this.m_cmdClearSelect.Click += new System.EventHandler(this.m_cmdClearSelect_Click);
            // 
            // m_cmdSaveDefault
            // 
            this.m_cmdSaveDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_cmdSaveDefault.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdSaveDefault.DefaultScheme = true;
            this.m_cmdSaveDefault.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdSaveDefault.Hint = "";
            this.m_cmdSaveDefault.Location = new System.Drawing.Point(100, 452);
            this.m_cmdSaveDefault.Name = "m_cmdSaveDefault";
            this.m_cmdSaveDefault.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSaveDefault.Size = new System.Drawing.Size(92, 28);
            this.m_cmdSaveDefault.TabIndex = 31;
            this.m_cmdSaveDefault.Text = "保存默认(&S)";
            this.toolTip1.SetToolTip(this.m_cmdSaveDefault, "保存当前的选择为默认项");
            this.m_cmdSaveDefault.Click += new System.EventHandler(this.m_cmdSaveDefault_Click);
            // 
            // m_cmdSelectDefault
            // 
            this.m_cmdSelectDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_cmdSelectDefault.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdSelectDefault.DefaultScheme = true;
            this.m_cmdSelectDefault.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdSelectDefault.Hint = "";
            this.m_cmdSelectDefault.Location = new System.Drawing.Point(100, 480);
            this.m_cmdSelectDefault.Name = "m_cmdSelectDefault";
            this.m_cmdSelectDefault.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSelectDefault.Size = new System.Drawing.Size(92, 28);
            this.m_cmdSelectDefault.TabIndex = 31;
            this.m_cmdSelectDefault.Text = "默认选择(&D)";
            this.toolTip1.SetToolTip(this.m_cmdSelectDefault, "恢复选择项为上次保存的选择");
            this.m_cmdSelectDefault.Click += new System.EventHandler(this.m_cmdSelectDefault_Click);
            // 
            // m_txtDept
            // 
            this.m_txtDept.Enabled = false;
            this.m_txtDept.Location = new System.Drawing.Point(124, 12);
            this.m_txtDept.Name = "m_txtDept";
            this.m_txtDept.Size = new System.Drawing.Size(128, 23);
            this.m_txtDept.TabIndex = 42;
            this.toolTip1.SetToolTip(this.m_txtDept, "可以输入科室名称或者科室编码查询科室，必须选择查询结果才有效");
            this.m_txtDept.TextChanged += new System.EventHandler(this.m_txtDept_TextChanged);
            this.m_txtDept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtDept_KeyDown);
            // 
            // m_rdbSurgery
            // 
            this.m_rdbSurgery.Location = new System.Drawing.Point(316, 11);
            this.m_rdbSurgery.Name = "m_rdbSurgery";
            this.m_rdbSurgery.Size = new System.Drawing.Size(56, 24);
            this.m_rdbSurgery.TabIndex = 37;
            this.m_rdbSurgery.Text = "外科";
            this.toolTip1.SetToolTip(this.m_rdbSurgery, "对所有的大外科作统计");
            // 
            // m_rdbMedical
            // 
            this.m_rdbMedical.Location = new System.Drawing.Point(256, 11);
            this.m_rdbMedical.Name = "m_rdbMedical";
            this.m_rdbMedical.Size = new System.Drawing.Size(56, 24);
            this.m_rdbMedical.TabIndex = 36;
            this.m_rdbMedical.Text = "内科";
            this.toolTip1.SetToolTip(this.m_rdbMedical, "对所有的大内科作统计");
            // 
            // m_rdbSingleDept
            // 
            this.m_rdbSingleDept.Location = new System.Drawing.Point(68, 11);
            this.m_rdbSingleDept.Name = "m_rdbSingleDept";
            this.m_rdbSingleDept.Size = new System.Drawing.Size(56, 24);
            this.m_rdbSingleDept.TabIndex = 35;
            this.m_rdbSingleDept.Text = "科室";
            this.toolTip1.SetToolTip(this.m_rdbSingleDept, "对选中的科室作统计");
            this.m_rdbSingleDept.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // m_rdbAllDept
            // 
            this.m_rdbAllDept.Checked = true;
            this.m_rdbAllDept.Location = new System.Drawing.Point(8, 11);
            this.m_rdbAllDept.Name = "m_rdbAllDept";
            this.m_rdbAllDept.Size = new System.Drawing.Size(56, 24);
            this.m_rdbAllDept.TabIndex = 34;
            this.m_rdbAllDept.TabStop = true;
            this.m_rdbAllDept.Text = "全院";
            this.toolTip1.SetToolTip(this.m_rdbAllDept, "对全院所有的科室作统计，查询可能会较久");
            // 
            // btnprint
            // 
            this.btnprint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnprint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnprint.DefaultScheme = true;
            this.btnprint.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnprint.Hint = "";
            this.btnprint.Location = new System.Drawing.Point(812, 4);
            this.btnprint.Name = "btnprint";
            this.btnprint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnprint.Size = new System.Drawing.Size(80, 35);
            this.btnprint.TabIndex = 33;
            this.btnprint.Text = "打印(&P)";
            this.toolTip1.SetToolTip(this.btnprint, "打印结果");
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnQuery.DefaultScheme = true;
            this.btnQuery.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnQuery.Hint = "";
            this.btnQuery.Location = new System.Drawing.Point(724, 4);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnQuery.Size = new System.Drawing.Size(80, 35);
            this.btnQuery.TabIndex = 31;
            this.btnQuery.Text = "查询(&Q)";
            this.toolTip1.SetToolTip(this.btnQuery, "查询显示统计的结果");
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.pnlIsBusy);
            this.panel3.Controls.Add(this.m_ppwShow);
            this.panel3.Controls.Add(this.splitter1);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Location = new System.Drawing.Point(0, 56);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(988, 512);
            this.panel3.TabIndex = 8;
            // 
            // m_ppwShow
            // 
            this.m_ppwShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_ppwShow.Location = new System.Drawing.Point(201, 0);
            this.m_ppwShow.Name = "m_ppwShow";
            this.m_ppwShow.Size = new System.Drawing.Size(785, 510);
            this.m_ppwShow.TabIndex = 0;
            this.m_ppwShow.Zoom = 1;
            // 
            // splitter1
            // 
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitter1.Location = new System.Drawing.Point(196, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 510);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_trvItems);
            this.panel1.Controls.Add(this.m_cmdSelectAll);
            this.panel1.Controls.Add(this.m_cmdClearSelect);
            this.panel1.Controls.Add(this.m_cmdSaveDefault);
            this.panel1.Controls.Add(this.m_cmdSelectDefault);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(196, 510);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.m_txtDept);
            this.panel2.Controls.Add(this.m_dtpStart);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.m_dtpEnd);
            this.panel2.Controls.Add(this.m_rdbSurgery);
            this.panel2.Controls.Add(this.m_rdbMedical);
            this.panel2.Controls.Add(this.m_rdbSingleDept);
            this.panel2.Controls.Add(this.m_rdbAllDept);
            this.panel2.Controls.Add(this.btnprint);
            this.panel2.Controls.Add(this.btnEsc);
            this.panel2.Controls.Add(this.btnQuery);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(988, 48);
            this.panel2.TabIndex = 6;
            // 
            // m_dtpStart
            // 
            this.m_dtpStart.Location = new System.Drawing.Point(448, 12);
            this.m_dtpStart.Name = "m_dtpStart";
            this.m_dtpStart.Size = new System.Drawing.Size(120, 23);
            this.m_dtpStart.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(376, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 41;
            this.label1.Text = "出院时间：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_dtpEnd
            // 
            this.m_dtpEnd.Location = new System.Drawing.Point(592, 12);
            this.m_dtpEnd.Name = "m_dtpEnd";
            this.m_dtpEnd.Size = new System.Drawing.Size(120, 23);
            this.m_dtpEnd.TabIndex = 40;
            // 
            // btnEsc
            // 
            this.btnEsc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEsc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnEsc.DefaultScheme = true;
            this.btnEsc.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnEsc.Hint = "";
            this.btnEsc.Location = new System.Drawing.Point(900, 4);
            this.btnEsc.Name = "btnEsc";
            this.btnEsc.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnEsc.Size = new System.Drawing.Size(80, 35);
            this.btnEsc.TabIndex = 32;
            this.btnEsc.Text = "退出(&E)";
            this.btnEsc.Click += new System.EventHandler(this.btnEsc_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(568, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 41;
            this.label2.Text = "至";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_lsvFind
            // 
            this.m_lsvFind.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.m_lsvFind.FullRowSelect = true;
            this.m_lsvFind.GridLines = true;
            this.m_lsvFind.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.m_lsvFind.Location = new System.Drawing.Point(124, 36);
            this.m_lsvFind.MultiSelect = false;
            this.m_lsvFind.Name = "m_lsvFind";
            this.m_lsvFind.Size = new System.Drawing.Size(232, 124);
            this.m_lsvFind.TabIndex = 7;
            this.m_lsvFind.UseCompatibleStateImageBehavior = false;
            this.m_lsvFind.View = System.Windows.Forms.View.Details;
            this.m_lsvFind.Visible = false;
            this.m_lsvFind.DoubleClick += new System.EventHandler(this.m_lsvFind_DoubleClick);
            this.m_lsvFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_lsvFind_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "科室";
            this.columnHeader1.Width = 117;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "编码";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 75;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "类型";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(380, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 23);
            this.label4.TabIndex = 9;
            // 
            // frmBugQuery
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(988, 569);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.m_lsvFind);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmBugQuery";
            this.Text = "出院病历缺陷分类统计";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_trvItems_MouseDown);
            this.Load += new System.EventHandler(this.frmBugQuery_Load);
            this.pnlIsBusy.ResumeLayout(false);
            this.pnlIsBusy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClock)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private clsBugQueryDomain m_objDomain;
        private System.Drawing.Printing.PrintDocument m_pdcShow;
        internal System.Windows.Forms.Panel pnlIsBusy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel3;
        internal com.digitalwave.controls.Control.ctlprintShow m_ppwShow;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.TreeView m_trvItems;
        internal PinkieControls.ButtonXP m_cmdSelectAll;
        internal PinkieControls.ButtonXP m_cmdClearSelect;
        internal PinkieControls.ButtonXP m_cmdSaveDefault;
        internal PinkieControls.ButtonXP m_cmdSelectDefault;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.TextBox m_txtDept;
        internal System.Windows.Forms.DateTimePicker m_dtpStart;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.DateTimePicker m_dtpEnd;
        internal System.Windows.Forms.RadioButton m_rdbSurgery;
        internal System.Windows.Forms.RadioButton m_rdbMedical;
        internal System.Windows.Forms.RadioButton m_rdbSingleDept;
        internal System.Windows.Forms.RadioButton m_rdbAllDept;
        internal PinkieControls.ButtonXP btnprint;
        internal PinkieControls.ButtonXP btnEsc;
        internal PinkieControls.ButtonXP btnQuery;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ListView m_lsvFind;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.PictureBox picClock;
        private System.Windows.Forms.Label label4;
    }
}