namespace com.digitalwave.iCare.gui.LIS
{
    partial class frmLisBarcodeSort
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLisBarcodeSort));
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.m_dgBarcodeSort = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_dtToDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.m_dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_txtPatientCard = new com.digitalwave.controls.clsCardTextBox();
            this.m_txtLoginEmp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_btnExit = new PinkieControls.ButtonXP();
            this.m_btnLogin = new PinkieControls.ButtonXP();
            this.m_btnPrint = new PinkieControls.ButtonXP();
            this.label2 = new System.Windows.Forms.Label();
            this.m_btnClose = new PinkieControls.ButtonXP();
            this.m_btnRemove = new PinkieControls.ButtonXP();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtCheckContent = new System.Windows.Forms.TextBox();
            this.m_bgWorker = new System.ComponentModel.BackgroundWorker();
            this.txtWechatCode = new com.digitalwave.controls.clsCardTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPatientCard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPatientSex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgBarcodeSort)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1073, 705);
            this.panel1.TabIndex = 0;
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
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Size = new System.Drawing.Size(1073, 705);
            this.splitContainer1.SplitterDistance = 594;
            this.splitContainer1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 705);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "病人列表";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.m_dgBarcodeSort);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 68);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(588, 634);
            this.panel4.TabIndex = 2;
            // 
            // m_dgBarcodeSort
            // 
            this.m_dgBarcodeSort.AllowUserToAddRows = false;
            this.m_dgBarcodeSort.AllowUserToResizeRows = false;
            this.m_dgBarcodeSort.BackgroundColor = System.Drawing.SystemColors.Info;
            this.m_dgBarcodeSort.ColumnHeadersHeight = 25;
            this.m_dgBarcodeSort.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgBarcodeSort.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPatientCard,
            this.colPatientName,
            this.colPatientSex,
            this.colAge,
            this.colDateTime});
            this.m_dgBarcodeSort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgBarcodeSort.Location = new System.Drawing.Point(0, 0);
            this.m_dgBarcodeSort.MultiSelect = false;
            this.m_dgBarcodeSort.Name = "m_dgBarcodeSort";
            this.m_dgBarcodeSort.ReadOnly = true;
            this.m_dgBarcodeSort.RowHeadersVisible = false;
            this.m_dgBarcodeSort.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dgBarcodeSort.RowTemplate.Height = 23;
            this.m_dgBarcodeSort.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgBarcodeSort.Size = new System.Drawing.Size(588, 634);
            this.m_dgBarcodeSort.TabIndex = 0;
            this.m_dgBarcodeSort.DoubleClick += new System.EventHandler(this.m_dgBarcodeSort_DoubleClick);
            this.m_dgBarcodeSort.SelectionChanged += new System.EventHandler(this.m_dgBarcodeSort_SelectionChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_dtToDate);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.m_dtFromDate);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(588, 49);
            this.panel2.TabIndex = 1;
            // 
            // m_dtToDate
            // 
            this.m_dtToDate.CustomFormat = "yyyy-MM-dd";
            this.m_dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtToDate.Location = new System.Drawing.Point(215, 13);
            this.m_dtToDate.Name = "m_dtToDate";
            this.m_dtToDate.Size = new System.Drawing.Size(101, 23);
            this.m_dtToDate.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(185, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 14);
            this.label5.TabIndex = 2;
            this.label5.Text = "至";
            // 
            // m_dtFromDate
            // 
            this.m_dtFromDate.CustomFormat = "yyyy-MM-dd";
            this.m_dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtFromDate.Location = new System.Drawing.Point(75, 13);
            this.m_dtFromDate.Name = "m_dtFromDate";
            this.m_dtFromDate.Size = new System.Drawing.Size(101, 23);
            this.m_dtFromDate.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "查询时间";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtWechatCode);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.m_txtPatientCard);
            this.panel3.Controls.Add(this.m_txtLoginEmp);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.m_btnExit);
            this.panel3.Controls.Add(this.m_btnLogin);
            this.panel3.Controls.Add(this.m_btnPrint);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.m_btnClose);
            this.panel3.Controls.Add(this.m_btnRemove);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.m_txtCheckContent);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(475, 705);
            this.panel3.TabIndex = 1;
            // 
            // m_txtPatientCard
            // 
            this.m_txtPatientCard.BackColor = System.Drawing.Color.White;
            this.m_txtPatientCard.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtPatientCard.Location = new System.Drawing.Point(95, 124);
            this.m_txtPatientCard.MaxLength = 50;
            this.m_txtPatientCard.Name = "m_txtPatientCard";
            this.m_txtPatientCard.PatientCard = "";
            this.m_txtPatientCard.PatientFlag = 0;
            this.m_txtPatientCard.Size = new System.Drawing.Size(361, 30);
            this.m_txtPatientCard.TabIndex = 1;
            this.m_txtPatientCard.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtPatientCard.YBCardText = "";
            this.m_txtPatientCard.TextChanged += new System.EventHandler(this.m_txtPatientCard_TextChanged);
            // 
            // m_txtLoginEmp
            // 
            this.m_txtLoginEmp.Location = new System.Drawing.Point(95, 232);
            this.m_txtLoginEmp.Name = "m_txtLoginEmp";
            this.m_txtLoginEmp.ReadOnly = true;
            this.m_txtLoginEmp.Size = new System.Drawing.Size(361, 23);
            this.m_txtLoginEmp.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "采样人员：";
            // 
            // m_btnExit
            // 
            this.m_btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnExit.DefaultScheme = true;
            this.m_btnExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnExit.Hint = "";
            this.m_btnExit.Location = new System.Drawing.Point(184, 64);
            this.m_btnExit.Name = "m_btnExit";
            this.m_btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnExit.Size = new System.Drawing.Size(148, 32);
            this.m_btnExit.TabIndex = 8;
            this.m_btnExit.Text = "注销采样人";
            this.m_btnExit.Click += new System.EventHandler(this.m_btnExit_Click);
            // 
            // m_btnLogin
            // 
            this.m_btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnLogin.DefaultScheme = true;
            this.m_btnLogin.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnLogin.Hint = "";
            this.m_btnLogin.Location = new System.Drawing.Point(20, 64);
            this.m_btnLogin.Name = "m_btnLogin";
            this.m_btnLogin.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnLogin.Size = new System.Drawing.Size(148, 32);
            this.m_btnLogin.TabIndex = 7;
            this.m_btnLogin.Text = "登录采样人";
            this.m_btnLogin.Click += new System.EventHandler(this.m_btnLogin_Click);
            // 
            // m_btnPrint
            // 
            this.m_btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnPrint.DefaultScheme = true;
            this.m_btnPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnPrint.Hint = "";
            this.m_btnPrint.Location = new System.Drawing.Point(20, 16);
            this.m_btnPrint.Name = "m_btnPrint";
            this.m_btnPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnPrint.Size = new System.Drawing.Size(148, 32);
            this.m_btnPrint.TabIndex = 6;
            this.m_btnPrint.Text = "打印条码(F8)";
            this.m_btnPrint.Click += new System.EventHandler(this.m_btnPrint_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 297);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "检验内容:";
            // 
            // m_btnClose
            // 
            this.m_btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnClose.DefaultScheme = true;
            this.m_btnClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnClose.Hint = "";
            this.m_btnClose.Location = new System.Drawing.Point(348, 16);
            this.m_btnClose.Name = "m_btnClose";
            this.m_btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnClose.Size = new System.Drawing.Size(116, 32);
            this.m_btnClose.TabIndex = 3;
            this.m_btnClose.Text = "关闭窗口";
            this.m_btnClose.Click += new System.EventHandler(this.m_btnClose_Click);
            // 
            // m_btnRemove
            // 
            this.m_btnRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_btnRemove.DefaultScheme = true;
            this.m_btnRemove.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnRemove.Hint = "";
            this.m_btnRemove.Location = new System.Drawing.Point(184, 16);
            this.m_btnRemove.Name = "m_btnRemove";
            this.m_btnRemove.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnRemove.Size = new System.Drawing.Size(148, 32);
            this.m_btnRemove.TabIndex = 2;
            this.m_btnRemove.Text = "移除患者列表";
            this.m_btnRemove.Click += new System.EventHandler(this.m_btnRemove_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(19, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "病人卡号：";
            // 
            // m_txtCheckContent
            // 
            this.m_txtCheckContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_txtCheckContent.Location = new System.Drawing.Point(95, 292);
            this.m_txtCheckContent.Multiline = true;
            this.m_txtCheckContent.Name = "m_txtCheckContent";
            this.m_txtCheckContent.ReadOnly = true;
            this.m_txtCheckContent.Size = new System.Drawing.Size(361, 395);
            this.m_txtCheckContent.TabIndex = 5;
            // 
            // m_bgWorker
            // 
            this.m_bgWorker.WorkerReportsProgress = true;
            this.m_bgWorker.WorkerSupportsCancellation = true;
            this.m_bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.m_bgWorker_DoWork);
            // 
            // txtWechatCode
            // 
            this.txtWechatCode.BackColor = System.Drawing.Color.White;
            this.txtWechatCode.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWechatCode.Location = new System.Drawing.Point(95, 178);
            this.txtWechatCode.MaxLength = 50;
            this.txtWechatCode.Name = "txtWechatCode";
            this.txtWechatCode.PatientCard = "";
            this.txtWechatCode.PatientFlag = 0;
            this.txtWechatCode.Size = new System.Drawing.Size(361, 30);
            this.txtWechatCode.TabIndex = 12;
            this.txtWechatCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtWechatCode.YBCardText = "";
            this.txtWechatCode.TextChanged += new System.EventHandler(this.txtWechatCode_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(19, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 14);
            this.label6.TabIndex = 11;
            this.label6.Text = "微信条码：";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PatientCard";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn1.HeaderText = "诊疗卡号";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "PatientName";
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn2.HeaderText = "姓名";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "PatientSex";
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn3.HeaderText = "性别";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 50;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "PatientAge";
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn4.HeaderText = "年龄";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 50;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "DateTime";
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn5.HeaderText = "时间";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colPatientCard
            // 
            this.colPatientCard.DataPropertyName = "PatientCard";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.colPatientCard.DefaultCellStyle = dataGridViewCellStyle1;
            this.colPatientCard.HeaderText = "诊疗卡号";
            this.colPatientCard.MinimumWidth = 120;
            this.colPatientCard.Name = "colPatientCard";
            this.colPatientCard.ReadOnly = true;
            this.colPatientCard.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPatientCard.Width = 120;
            // 
            // colPatientName
            // 
            this.colPatientName.DataPropertyName = "PatientName";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.colPatientName.DefaultCellStyle = dataGridViewCellStyle2;
            this.colPatientName.HeaderText = "姓名";
            this.colPatientName.Name = "colPatientName";
            this.colPatientName.ReadOnly = true;
            this.colPatientName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colPatientSex
            // 
            this.colPatientSex.DataPropertyName = "PatientSex";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.colPatientSex.DefaultCellStyle = dataGridViewCellStyle3;
            this.colPatientSex.HeaderText = "性别";
            this.colPatientSex.Name = "colPatientSex";
            this.colPatientSex.ReadOnly = true;
            this.colPatientSex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPatientSex.Width = 50;
            // 
            // colAge
            // 
            this.colAge.DataPropertyName = "PatientAge";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.colAge.DefaultCellStyle = dataGridViewCellStyle4;
            this.colAge.HeaderText = "年龄";
            this.colAge.Name = "colAge";
            this.colAge.ReadOnly = true;
            this.colAge.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAge.Width = 50;
            // 
            // colDateTime
            // 
            this.colDateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDateTime.DataPropertyName = "DateTime";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.colDateTime.DefaultCellStyle = dataGridViewCellStyle5;
            this.colDateTime.HeaderText = "时间";
            this.colDateTime.Name = "colDateTime";
            this.colDateTime.ReadOnly = true;
            this.colDateTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // frmLisBarcodeSort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 705);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLisBarcodeSort";
            this.Text = "条码打印排序窗体";
            this.Load += new System.EventHandler(this.frmLisBarcodeSort_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgBarcodeSort)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private PinkieControls.ButtonXP m_btnRemove;
        private System.Windows.Forms.Label label1;
        private PinkieControls.ButtonXP m_btnClose;
        private System.Windows.Forms.Label label2;
        private PinkieControls.ButtonXP m_btnPrint;
        private System.Windows.Forms.TextBox m_txtLoginEmp;
        private System.Windows.Forms.Label label3;
        private PinkieControls.ButtonXP m_btnExit;
        private PinkieControls.ButtonXP m_btnLogin;
        internal System.Windows.Forms.DataGridView m_dgBarcodeSort;
        internal System.Windows.Forms.TextBox m_txtCheckContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.ComponentModel.BackgroundWorker m_bgWorker;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.DateTimePicker m_dtToDate;
        internal System.Windows.Forms.DateTimePicker m_dtFromDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatientCard;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatientSex;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateTime;
        internal com.digitalwave.controls.clsCardTextBox m_txtPatientCard;
        internal com.digitalwave.controls.clsCardTextBox txtWechatCode;
        private System.Windows.Forms.Label label6;
    }
}