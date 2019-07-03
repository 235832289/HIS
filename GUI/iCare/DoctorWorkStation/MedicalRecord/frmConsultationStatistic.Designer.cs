namespace iCare
{
    partial class frmConsultationStatistic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultationStatistic));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_cmdSearch = new PinkieControls.ButtonXP();
            this.m_dtpSearchEndTime = new System.Windows.Forms.DateTimePicker();
            this.m_dtpSearchStartTime = new System.Windows.Forms.DateTimePicker();
            this.m_cmdShowAllDept = new System.Windows.Forms.Button();
            this.m_txtApplyConsultationDept = new System.Windows.Forms.TextBox();
            this.m_chkSelectAllDept = new System.Windows.Forms.CheckBox();
            this.m_chkSelectOneDept = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_chkUnReply = new System.Windows.Forms.CheckBox();
            this.m_chkHasReply = new System.Windows.Forms.CheckBox();
            this.m_chkAllResult = new System.Windows.Forms.CheckBox();
            this.m_lblAllResult = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_lblUnReplyResult = new System.Windows.Forms.Label();
            this.m_lblHasReplyResult = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_lsvResult = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.m_pnlSearchWindow = new System.Windows.Forms.Panel();
            this.m_lsvDeptList = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.m_txtSearchDept = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.m_lblWarning = new System.Windows.Forms.Label();
            this.m_cboSendOrReceive = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.m_pnlSearchWindow.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_cboSendOrReceive);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.m_cmdSearch);
            this.groupBox1.Controls.Add(this.m_dtpSearchEndTime);
            this.groupBox1.Controls.Add(this.m_dtpSearchStartTime);
            this.groupBox1.Controls.Add(this.m_cmdShowAllDept);
            this.groupBox1.Controls.Add(this.m_txtApplyConsultationDept);
            this.groupBox1.Controls.Add(this.m_chkSelectAllDept);
            this.groupBox1.Controls.Add(this.m_chkSelectOneDept);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(8, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(840, 73);
            this.groupBox1.TabIndex = 10000043;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(195, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 10000047;
            this.label4.Text = "开始日期:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(442, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 14);
            this.label3.TabIndex = 10000047;
            this.label3.Text = "结束日期:";
            // 
            // m_cmdSearch
            // 
            this.m_cmdSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.m_cmdSearch.DefaultScheme = true;
            this.m_cmdSearch.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSearch.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdSearch.Hint = "";
            this.m_cmdSearch.Location = new System.Drawing.Point(743, 44);
            this.m_cmdSearch.Name = "m_cmdSearch";
            this.m_cmdSearch.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSearch.Size = new System.Drawing.Size(82, 24);
            this.m_cmdSearch.TabIndex = 10000046;
            this.m_cmdSearch.Tag = "1";
            this.m_cmdSearch.Text = "查询";
            this.m_cmdSearch.Click += new System.EventHandler(this.m_cmdSearch_Click);
            // 
            // m_dtpSearchEndTime
            // 
            this.m_dtpSearchEndTime.AccessibleDescription = "查询结束时间";
            this.m_dtpSearchEndTime.Location = new System.Drawing.Point(518, 44);
            this.m_dtpSearchEndTime.Name = "m_dtpSearchEndTime";
            this.m_dtpSearchEndTime.Size = new System.Drawing.Size(128, 23);
            this.m_dtpSearchEndTime.TabIndex = 10000045;
            // 
            // m_dtpSearchStartTime
            // 
            this.m_dtpSearchStartTime.AccessibleDescription = "查询开始时间";
            this.m_dtpSearchStartTime.Location = new System.Drawing.Point(278, 44);
            this.m_dtpSearchStartTime.Name = "m_dtpSearchStartTime";
            this.m_dtpSearchStartTime.Size = new System.Drawing.Size(128, 23);
            this.m_dtpSearchStartTime.TabIndex = 10000045;
            // 
            // m_cmdShowAllDept
            // 
            this.m_cmdShowAllDept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdShowAllDept.Location = new System.Drawing.Point(477, 17);
            this.m_cmdShowAllDept.Name = "m_cmdShowAllDept";
            this.m_cmdShowAllDept.Size = new System.Drawing.Size(23, 23);
            this.m_cmdShowAllDept.TabIndex = 10000044;
            this.m_cmdShowAllDept.Text = "↓";
            this.m_cmdShowAllDept.UseVisualStyleBackColor = true;
            this.m_cmdShowAllDept.Click += new System.EventHandler(this.m_cmdShowAllDept_Click);
            // 
            // m_txtApplyConsultationDept
            // 
            this.m_txtApplyConsultationDept.AccessibleDescription = "申请会诊科室";
            this.m_txtApplyConsultationDept.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtApplyConsultationDept.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtApplyConsultationDept.Location = new System.Drawing.Point(279, 17);
            this.m_txtApplyConsultationDept.Name = "m_txtApplyConsultationDept";
            this.m_txtApplyConsultationDept.ReadOnly = true;
            this.m_txtApplyConsultationDept.Size = new System.Drawing.Size(201, 23);
            this.m_txtApplyConsultationDept.TabIndex = 10000043;
            this.m_txtApplyConsultationDept.Leave += new System.EventHandler(this.m_txtApplyConsultationDept_Leave);
            // 
            // m_chkSelectAllDept
            // 
            this.m_chkSelectAllDept.AccessibleDescription = "选择全部科室";
            this.m_chkSelectAllDept.AutoSize = true;
            this.m_chkSelectAllDept.Location = new System.Drawing.Point(519, 20);
            this.m_chkSelectAllDept.Name = "m_chkSelectAllDept";
            this.m_chkSelectAllDept.Size = new System.Drawing.Size(82, 18);
            this.m_chkSelectAllDept.TabIndex = 1;
            this.m_chkSelectAllDept.Text = "全部科室";
            this.m_chkSelectAllDept.UseVisualStyleBackColor = true;
            this.m_chkSelectAllDept.CheckedChanged += new System.EventHandler(this.m_chkSelectAllDept_CheckedChanged);
            // 
            // m_chkSelectOneDept
            // 
            this.m_chkSelectOneDept.AccessibleDescription = "选择一个科室";
            this.m_chkSelectOneDept.AutoSize = true;
            this.m_chkSelectOneDept.Checked = true;
            this.m_chkSelectOneDept.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkSelectOneDept.Location = new System.Drawing.Point(254, 22);
            this.m_chkSelectOneDept.Name = "m_chkSelectOneDept";
            this.m_chkSelectOneDept.Size = new System.Drawing.Size(15, 14);
            this.m_chkSelectOneDept.TabIndex = 1;
            this.m_chkSelectOneDept.UseVisualStyleBackColor = true;
            this.m_chkSelectOneDept.CheckedChanged += new System.EventHandler(this.m_chkSelectOneDept_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "会诊申请发送日期范围:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "会诊申请        科室范围:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_chkUnReply);
            this.groupBox2.Controls.Add(this.m_chkHasReply);
            this.groupBox2.Controls.Add(this.m_chkAllResult);
            this.groupBox2.Controls.Add(this.m_lblAllResult);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.m_lblUnReplyResult);
            this.groupBox2.Controls.Add(this.m_lblHasReplyResult);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.m_lsvResult);
            this.groupBox2.Location = new System.Drawing.Point(8, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(840, 530);
            this.groupBox2.TabIndex = 10000047;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查询结果";
            // 
            // m_chkUnReply
            // 
            this.m_chkUnReply.AutoSize = true;
            this.m_chkUnReply.Location = new System.Drawing.Point(762, 16);
            this.m_chkUnReply.Name = "m_chkUnReply";
            this.m_chkUnReply.Size = new System.Drawing.Size(68, 18);
            this.m_chkUnReply.TabIndex = 3;
            this.m_chkUnReply.Text = "未回复";
            this.m_chkUnReply.UseVisualStyleBackColor = true;
            this.m_chkUnReply.CheckedChanged += new System.EventHandler(this.m_chkUnReply_CheckedChanged);
            // 
            // m_chkHasReply
            // 
            this.m_chkHasReply.AutoSize = true;
            this.m_chkHasReply.Location = new System.Drawing.Point(688, 16);
            this.m_chkHasReply.Name = "m_chkHasReply";
            this.m_chkHasReply.Size = new System.Drawing.Size(68, 18);
            this.m_chkHasReply.TabIndex = 3;
            this.m_chkHasReply.Text = "已回复";
            this.m_chkHasReply.UseVisualStyleBackColor = true;
            this.m_chkHasReply.CheckedChanged += new System.EventHandler(this.m_chkHasReply_CheckedChanged);
            // 
            // m_chkAllResult
            // 
            this.m_chkAllResult.AutoSize = true;
            this.m_chkAllResult.Checked = true;
            this.m_chkAllResult.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkAllResult.Location = new System.Drawing.Point(617, 16);
            this.m_chkAllResult.Name = "m_chkAllResult";
            this.m_chkAllResult.Size = new System.Drawing.Size(54, 18);
            this.m_chkAllResult.TabIndex = 3;
            this.m_chkAllResult.Text = "全部";
            this.m_chkAllResult.UseVisualStyleBackColor = true;
            this.m_chkAllResult.CheckedChanged += new System.EventHandler(this.m_chkAllResult_CheckedChanged);
            // 
            // m_lblAllResult
            // 
            this.m_lblAllResult.AccessibleDescription = "查询结果总数";
            this.m_lblAllResult.Location = new System.Drawing.Point(128, 17);
            this.m_lblAllResult.Name = "m_lblAllResult";
            this.m_lblAllResult.Size = new System.Drawing.Size(58, 18);
            this.m_lblAllResult.TabIndex = 2;
            this.m_lblAllResult.Text = "0";
            this.m_lblAllResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(7, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 14);
            this.label5.TabIndex = 1;
            this.label5.Text = "共发送会诊申请";
            // 
            // m_lblUnReplyResult
            // 
            this.m_lblUnReplyResult.AccessibleDescription = "查询未回复总数";
            this.m_lblUnReplyResult.Location = new System.Drawing.Point(422, 18);
            this.m_lblUnReplyResult.Name = "m_lblUnReplyResult";
            this.m_lblUnReplyResult.Size = new System.Drawing.Size(66, 18);
            this.m_lblUnReplyResult.TabIndex = 2;
            this.m_lblUnReplyResult.Text = "0";
            this.m_lblUnReplyResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_lblHasReplyResult
            // 
            this.m_lblHasReplyResult.AccessibleDescription = "查询结果已回复数";
            this.m_lblHasReplyResult.Location = new System.Drawing.Point(270, 17);
            this.m_lblHasReplyResult.Name = "m_lblHasReplyResult";
            this.m_lblHasReplyResult.Size = new System.Drawing.Size(66, 18);
            this.m_lblHasReplyResult.TabIndex = 2;
            this.m_lblHasReplyResult.Text = "0";
            this.m_lblHasReplyResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(490, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 14);
            this.label7.TabIndex = 1;
            this.label7.Text = "条。";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(347, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 14);
            this.label9.TabIndex = 1;
            this.label9.Text = "条，未回复";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(192, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 1;
            this.label6.Text = "条，已回复";
            // 
            // m_lsvResult
            // 
            this.m_lsvResult.AccessibleDescription = "查询结果";
            this.m_lsvResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader11,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.m_lsvResult.FullRowSelect = true;
            this.m_lsvResult.GridLines = true;
            this.m_lsvResult.Location = new System.Drawing.Point(8, 38);
            this.m_lsvResult.MultiSelect = false;
            this.m_lsvResult.Name = "m_lsvResult";
            this.m_lsvResult.Size = new System.Drawing.Size(826, 484);
            this.m_lsvResult.TabIndex = 0;
            this.m_lsvResult.UseCompatibleStateImageBehavior = false;
            this.m_lsvResult.View = System.Windows.Forms.View.Details;
            this.m_lsvResult.DoubleClick += new System.EventHandler(this.m_lsvResult_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "住院号";
            this.columnHeader1.Width = 70;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "病人姓名";
            this.columnHeader9.Width = 70;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "性别";
            this.columnHeader10.Width = 40;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "入院日期";
            this.columnHeader3.Width = 125;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "发送会诊科室";
            this.columnHeader4.Width = 125;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "发送医师";
            this.columnHeader11.Width = 70;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "发送会诊时间";
            this.columnHeader5.Width = 125;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "申请会诊科室";
            this.columnHeader6.Width = 125;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "状态";
            // 
            // m_pnlSearchWindow
            // 
            this.m_pnlSearchWindow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_pnlSearchWindow.Controls.Add(this.m_lsvDeptList);
            this.m_pnlSearchWindow.Controls.Add(this.m_txtSearchDept);
            this.m_pnlSearchWindow.Controls.Add(this.label8);
            this.m_pnlSearchWindow.Location = new System.Drawing.Point(239, 174);
            this.m_pnlSearchWindow.Name = "m_pnlSearchWindow";
            this.m_pnlSearchWindow.Size = new System.Drawing.Size(223, 192);
            this.m_pnlSearchWindow.TabIndex = 10000048;
            this.m_pnlSearchWindow.Visible = false;
            // 
            // m_lsvDeptList
            // 
            this.m_lsvDeptList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader8});
            this.m_lsvDeptList.FullRowSelect = true;
            this.m_lsvDeptList.GridLines = true;
            this.m_lsvDeptList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_lsvDeptList.Location = new System.Drawing.Point(-1, 21);
            this.m_lsvDeptList.MultiSelect = false;
            this.m_lsvDeptList.Name = "m_lsvDeptList";
            this.m_lsvDeptList.Size = new System.Drawing.Size(223, 170);
            this.m_lsvDeptList.TabIndex = 2;
            this.m_lsvDeptList.UseCompatibleStateImageBehavior = false;
            this.m_lsvDeptList.View = System.Windows.Forms.View.Details;
            this.m_lsvDeptList.DoubleClick += new System.EventHandler(this.m_lsvDeptList_DoubleClick);
            this.m_lsvDeptList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_lsvDeptList_KeyDown);
            this.m_lsvDeptList.Leave += new System.EventHandler(this.m_lsvDeptList_Leave);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 70;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Width = 132;
            // 
            // m_txtSearchDept
            // 
            this.m_txtSearchDept.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtSearchDept.Location = new System.Drawing.Point(31, -1);
            this.m_txtSearchDept.Name = "m_txtSearchDept";
            this.m_txtSearchDept.Size = new System.Drawing.Size(191, 23);
            this.m_txtSearchDept.TabIndex = 0;
            this.m_txtSearchDept.Leave += new System.EventHandler(this.m_txtSearchDept_Leave);
            this.m_txtSearchDept.TextChanged += new System.EventHandler(this.m_txtSearchDept_TextChanged);
            this.m_txtSearchDept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtSearchDept_KeyDown);
            // 
            // label8
            // 
            this.label8.ImageIndex = 0;
            this.label8.ImageList = this.imageList1;
            this.label8.Location = new System.Drawing.Point(-1, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 22);
            this.label8.TabIndex = 1;
            // 
            // m_lblWarning
            // 
            this.m_lblWarning.AutoSize = true;
            this.m_lblWarning.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblWarning.ForeColor = System.Drawing.Color.Red;
            this.m_lblWarning.Location = new System.Drawing.Point(648, 24);
            this.m_lblWarning.Name = "m_lblWarning";
            this.m_lblWarning.Size = new System.Drawing.Size(187, 14);
            this.m_lblWarning.TabIndex = 10000049;
            this.m_lblWarning.Text = "当前用户没有查询会诊权限";
            this.m_lblWarning.Visible = false;
            // 
            // m_cboSendOrReceive
            // 
            this.m_cboSendOrReceive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboSendOrReceive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cboSendOrReceive.FormattingEnabled = true;
            this.m_cboSendOrReceive.Items.AddRange(new object[] {
            "发送",
            "接收"});
            this.m_cboSendOrReceive.Location = new System.Drawing.Point(75, 18);
            this.m_cboSendOrReceive.Name = "m_cboSendOrReceive";
            this.m_cboSendOrReceive.Size = new System.Drawing.Size(51, 22);
            this.m_cboSendOrReceive.TabIndex = 10000048;
            this.m_cboSendOrReceive.SelectedIndexChanged += new System.EventHandler(this.m_cboSendOrReceive_SelectedIndexChanged);
            // 
            // frmConsultationStatistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 621);
            this.Controls.Add(this.m_lblWarning);
            this.Controls.Add(this.m_pnlSearchWindow);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConsultationStatistic";
            this.Text = "会诊记录查询";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.m_pnlSearchWindow.ResumeLayout(false);
            this.m_pnlSearchWindow.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker m_dtpSearchEndTime;
        private System.Windows.Forms.DateTimePicker m_dtpSearchStartTime;
        private System.Windows.Forms.Button m_cmdShowAllDept;
        private System.Windows.Forms.TextBox m_txtApplyConsultationDept;
        private System.Windows.Forms.CheckBox m_chkSelectAllDept;
        private System.Windows.Forms.CheckBox m_chkSelectOneDept;
        private System.Windows.Forms.Label label2;
        private PinkieControls.ButtonXP m_cmdSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label m_lblAllResult;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView m_lsvResult;
        private System.Windows.Forms.Label m_lblUnReplyResult;
        private System.Windows.Forms.Label m_lblHasReplyResult;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.Panel m_pnlSearchWindow;
        private System.Windows.Forms.ListView m_lsvDeptList;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.TextBox m_txtSearchDept;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label m_lblWarning;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.CheckBox m_chkUnReply;
        private System.Windows.Forms.CheckBox m_chkHasReply;
        private System.Windows.Forms.CheckBox m_chkAllResult;
        private System.Windows.Forms.ComboBox m_cboSendOrReceive;
    }
}