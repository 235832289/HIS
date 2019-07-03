namespace com.digitalwave.iCare.gui.LIS
{
    partial class frmMicReport
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgv_mic = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_rdbMic = new System.Windows.Forms.RadioButton();
            this.m_rdbAllMic = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgv_anti = new System.Windows.Forms.DataGridView();
            this.antiID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anti_cname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anti_ename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_rdbAnti = new System.Windows.Forms.RadioButton();
            this.m_rdbAll = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxTestMethod = new System.Windows.Forms.ComboBox();
            this.txtAgeTo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAgeFrom = new System.Windows.Forms.TextBox();
            this.cbxSex = new System.Windows.Forms.ComboBox();
            this.cbxDistrict = new System.Windows.Forms.ComboBox();
            this.cbxSampleType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_dtpDatTo = new System.Windows.Forms.DateTimePicker();
            this.m_dtpDatFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCount = new PinkieControls.ButtonXP();
            this.m_cboCondition = new System.Windows.Forms.ComboBox();
            this.dwResult = new Sybase.DataWindow.DataWindowControl();
            this.cmdExit = new PinkieControls.ButtonXP();
            this.cmdPrint = new PinkieControls.ButtonXP();
            this.cmdExport = new PinkieControls.ButtonXP();
            this.sfdSave = new System.Windows.Forms.SaveFileDialog();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvItem = new System.Windows.Forms.DataGridView();
            this.tabContorl = new System.Windows.Forms.TabControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPreview = new PinkieControls.ButtonXP();
            this.MyPrintDocument = new System.Drawing.Printing.PrintDocument();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_mic)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_anti)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).BeginInit();
            this.tabContorl.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnCount);
            this.panel1.Controls.Add(this.m_cboCondition);
            this.panel1.Location = new System.Drawing.Point(7, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(364, 589);
            this.panel1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgv_mic);
            this.groupBox4.Controls.Add(this.m_rdbMic);
            this.groupBox4.Controls.Add(this.m_rdbAllMic);
            this.groupBox4.Font = new System.Drawing.Font("宋体", 10.5F);
            this.groupBox4.Location = new System.Drawing.Point(9, 427);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(343, 129);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "统计的细菌";
            // 
            // dgv_mic
            // 
            this.dgv_mic.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_mic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_mic.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.cname,
            this.ename});
            this.dgv_mic.Location = new System.Drawing.Point(2, 56);
            this.dgv_mic.Name = "dgv_mic";
            this.dgv_mic.ReadOnly = true;
            this.dgv_mic.RowHeadersVisible = false;
            this.dgv_mic.RowTemplate.Height = 23;
            this.dgv_mic.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_mic.Size = new System.Drawing.Size(335, 68);
            this.dgv_mic.TabIndex = 1;
            // 
            // ID
            // 
            this.ID.HeaderText = "细菌ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // cname
            // 
            this.cname.HeaderText = "细菌名称";
            this.cname.Name = "cname";
            this.cname.ReadOnly = true;
            // 
            // ename
            // 
            this.ename.HeaderText = "英文名称";
            this.ename.Name = "ename";
            this.ename.ReadOnly = true;
            // 
            // m_rdbMic
            // 
            this.m_rdbMic.AutoSize = true;
            this.m_rdbMic.Location = new System.Drawing.Point(170, 25);
            this.m_rdbMic.Name = "m_rdbMic";
            this.m_rdbMic.Size = new System.Drawing.Size(81, 18);
            this.m_rdbMic.TabIndex = 0;
            this.m_rdbMic.TabStop = true;
            this.m_rdbMic.Text = "选择细菌";
            this.m_rdbMic.UseVisualStyleBackColor = true;
            this.m_rdbMic.Click += new System.EventHandler(this.m_rdbMic_Click);
            this.m_rdbMic.CheckedChanged += new System.EventHandler(this.m_rdbMic_CheckedChanged);
            // 
            // m_rdbAllMic
            // 
            this.m_rdbAllMic.AutoSize = true;
            this.m_rdbAllMic.Location = new System.Drawing.Point(40, 26);
            this.m_rdbAllMic.Name = "m_rdbAllMic";
            this.m_rdbAllMic.Size = new System.Drawing.Size(81, 18);
            this.m_rdbAllMic.TabIndex = 0;
            this.m_rdbAllMic.TabStop = true;
            this.m_rdbAllMic.Text = "全部细菌";
            this.m_rdbAllMic.UseVisualStyleBackColor = true;
            this.m_rdbAllMic.CheckedChanged += new System.EventHandler(this.m_rdbAllMic_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgv_anti);
            this.groupBox3.Controls.Add(this.m_rdbAnti);
            this.groupBox3.Controls.Add(this.m_rdbAll);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 10.5F);
            this.groupBox3.Location = new System.Drawing.Point(11, 279);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(343, 134);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "统计的抗生素";
            // 
            // dgv_anti
            // 
            this.dgv_anti.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_anti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_anti.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.antiID,
            this.anti_cname,
            this.anti_ename});
            this.dgv_anti.Location = new System.Drawing.Point(2, 52);
            this.dgv_anti.Name = "dgv_anti";
            this.dgv_anti.ReadOnly = true;
            this.dgv_anti.RowHeadersVisible = false;
            this.dgv_anti.RowTemplate.Height = 23;
            this.dgv_anti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_anti.Size = new System.Drawing.Size(335, 61);
            this.dgv_anti.TabIndex = 1;
            // 
            // antiID
            // 
            this.antiID.HeaderText = "抗生素ID";
            this.antiID.Name = "antiID";
            this.antiID.ReadOnly = true;
            // 
            // anti_cname
            // 
            this.anti_cname.HeaderText = "抗生素名称";
            this.anti_cname.Name = "anti_cname";
            this.anti_cname.ReadOnly = true;
            this.anti_cname.Width = 120;
            // 
            // anti_ename
            // 
            this.anti_ename.HeaderText = "英文名称";
            this.anti_ename.Name = "anti_ename";
            this.anti_ename.ReadOnly = true;
            // 
            // m_rdbAnti
            // 
            this.m_rdbAnti.AutoSize = true;
            this.m_rdbAnti.Location = new System.Drawing.Point(165, 27);
            this.m_rdbAnti.Name = "m_rdbAnti";
            this.m_rdbAnti.Size = new System.Drawing.Size(95, 18);
            this.m_rdbAnti.TabIndex = 0;
            this.m_rdbAnti.TabStop = true;
            this.m_rdbAnti.Text = "选择抗生素";
            this.m_rdbAnti.UseVisualStyleBackColor = true;
            this.m_rdbAnti.Click += new System.EventHandler(this.m_rdbAnti_Click);
            this.m_rdbAnti.CheckedChanged += new System.EventHandler(this.m_rdbAnti_CheckedChanged);
            // 
            // m_rdbAll
            // 
            this.m_rdbAll.AutoSize = true;
            this.m_rdbAll.Location = new System.Drawing.Point(30, 28);
            this.m_rdbAll.Name = "m_rdbAll";
            this.m_rdbAll.Size = new System.Drawing.Size(95, 18);
            this.m_rdbAll.TabIndex = 0;
            this.m_rdbAll.TabStop = true;
            this.m_rdbAll.Text = "全部抗生素";
            this.m_rdbAll.UseVisualStyleBackColor = true;
            this.m_rdbAll.CheckedChanged += new System.EventHandler(this.m_rdbAll_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxTestMethod);
            this.groupBox1.Controls.Add(this.txtAgeTo);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtAgeFrom);
            this.groupBox1.Controls.Add(this.cbxSex);
            this.groupBox1.Controls.Add(this.cbxDistrict);
            this.groupBox1.Controls.Add(this.cbxSampleType);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.m_dtpDatTo);
            this.groupBox1.Controls.Add(this.m_dtpDatFrom);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.groupBox1.Location = new System.Drawing.Point(8, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 212);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "统计条件";
            // 
            // cbxTestMethod
            // 
            this.cbxTestMethod.FormattingEnabled = true;
            this.cbxTestMethod.Items.AddRange(new object[] {
            "ALL",
            "MIC"});
            this.cbxTestMethod.Location = new System.Drawing.Point(77, 181);
            this.cbxTestMethod.Name = "cbxTestMethod";
            this.cbxTestMethod.Size = new System.Drawing.Size(145, 22);
            this.cbxTestMethod.TabIndex = 21;
            // 
            // txtAgeTo
            // 
            this.txtAgeTo.Location = new System.Drawing.Point(178, 148);
            this.txtAgeTo.Name = "txtAgeTo";
            this.txtAgeTo.Size = new System.Drawing.Size(68, 23);
            this.txtAgeTo.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(151, 152);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 14);
            this.label10.TabIndex = 19;
            this.label10.Text = "至";
            // 
            // txtAgeFrom
            // 
            this.txtAgeFrom.Location = new System.Drawing.Point(77, 148);
            this.txtAgeFrom.Name = "txtAgeFrom";
            this.txtAgeFrom.Size = new System.Drawing.Size(68, 23);
            this.txtAgeFrom.TabIndex = 18;
            // 
            // cbxSex
            // 
            this.cbxSex.FormattingEnabled = true;
            this.cbxSex.Items.AddRange(new object[] {
            "",
            "男",
            "女",
            "不详"});
            this.cbxSex.Location = new System.Drawing.Point(77, 117);
            this.cbxSex.Name = "cbxSex";
            this.cbxSex.Size = new System.Drawing.Size(145, 22);
            this.cbxSex.TabIndex = 17;
            // 
            // cbxDistrict
            // 
            this.cbxDistrict.FormattingEnabled = true;
            this.cbxDistrict.Items.AddRange(new object[] {
            ""});
            this.cbxDistrict.Location = new System.Drawing.Point(78, 86);
            this.cbxDistrict.Name = "cbxDistrict";
            this.cbxDistrict.Size = new System.Drawing.Size(145, 22);
            this.cbxDistrict.TabIndex = 16;
            // 
            // cbxSampleType
            // 
            this.cbxSampleType.FormattingEnabled = true;
            this.cbxSampleType.Items.AddRange(new object[] {
            ""});
            this.cbxSampleType.Location = new System.Drawing.Point(78, 54);
            this.cbxSampleType.Name = "cbxSampleType";
            this.cbxSampleType.Size = new System.Drawing.Size(145, 22);
            this.cbxSampleType.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label9.Location = new System.Drawing.Point(7, 152);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 14);
            this.label9.TabIndex = 14;
            this.label9.Text = "年    龄：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label8.Location = new System.Drawing.Point(6, 186);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 14);
            this.label8.TabIndex = 13;
            this.label8.Text = "实验方法：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label7.Location = new System.Drawing.Point(7, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 14);
            this.label7.TabIndex = 12;
            this.label7.Text = "性    别：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label6.Location = new System.Drawing.Point(7, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 11;
            this.label6.Text = "病人类型：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label5.Location = new System.Drawing.Point(6, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 14);
            this.label5.TabIndex = 10;
            this.label5.Text = "标本类型：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(195, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "至";
            // 
            // m_dtpDatTo
            // 
            this.m_dtpDatTo.CustomFormat = "yyyy-MM-dd";
            this.m_dtpDatTo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpDatTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpDatTo.Location = new System.Drawing.Point(220, 24);
            this.m_dtpDatTo.Name = "m_dtpDatTo";
            this.m_dtpDatTo.Size = new System.Drawing.Size(101, 23);
            this.m_dtpDatTo.TabIndex = 8;
            // 
            // m_dtpDatFrom
            // 
            this.m_dtpDatFrom.CustomFormat = "yyyy-MM-dd";
            this.m_dtpDatFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpDatFrom.Location = new System.Drawing.Point(79, 24);
            this.m_dtpDatFrom.Name = "m_dtpDatFrom";
            this.m_dtpDatFrom.Size = new System.Drawing.Size(111, 23);
            this.m_dtpDatFrom.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label2.Location = new System.Drawing.Point(6, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "送检日期：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "条件类型:";
            // 
            // btnCount
            // 
            this.btnCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnCount.DefaultScheme = true;
            this.btnCount.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCount.Font = new System.Drawing.Font("宋体", 10.5F);
            this.btnCount.Hint = "";
            this.btnCount.Location = new System.Drawing.Point(276, 11);
            this.btnCount.Name = "btnCount";
            this.btnCount.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnCount.Size = new System.Drawing.Size(74, 27);
            this.btnCount.TabIndex = 148;
            this.btnCount.Text = "统计";
            this.btnCount.Click += new System.EventHandler(this.btnCount_Click);
            // 
            // m_cboCondition
            // 
            this.m_cboCondition.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_cboCondition.FormattingEnabled = true;
            this.m_cboCondition.Location = new System.Drawing.Point(91, 13);
            this.m_cboCondition.Name = "m_cboCondition";
            this.m_cboCondition.Size = new System.Drawing.Size(177, 22);
            this.m_cboCondition.TabIndex = 0;
            this.m_cboCondition.SelectedIndexChanged += new System.EventHandler(this.m_cboCondition_SelectedIndexChanged);
            // 
            // dwResult
            // 
            this.dwResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dwResult.DataWindowObject = "";
            this.dwResult.LibraryList = "";
            this.dwResult.Location = new System.Drawing.Point(5, 6);
            this.dwResult.Name = "dwResult";
            this.dwResult.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwResult.Size = new System.Drawing.Size(631, 638);
            this.dwResult.TabIndex = 1;
            this.dwResult.Text = "dataWindowControl1";
            // 
            // cmdExit
            // 
            this.cmdExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.cmdExit.DefaultScheme = true;
            this.cmdExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdExit.Hint = "";
            this.cmdExit.Location = new System.Drawing.Point(281, 16);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdExit.Size = new System.Drawing.Size(76, 27);
            this.cmdExit.TabIndex = 150;
            this.cmdExit.Text = "退出";
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // cmdPrint
            // 
            this.cmdPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.cmdPrint.DefaultScheme = true;
            this.cmdPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdPrint.Hint = "";
            this.cmdPrint.Location = new System.Drawing.Point(96, 16);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdPrint.Size = new System.Drawing.Size(75, 27);
            this.cmdPrint.TabIndex = 151;
            this.cmdPrint.Text = "打印";
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // cmdExport
            // 
            this.cmdExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.cmdExport.DefaultScheme = true;
            this.cmdExport.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdExport.Hint = "";
            this.cmdExport.Location = new System.Drawing.Point(187, 16);
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdExport.Size = new System.Drawing.Size(73, 27);
            this.cmdExport.TabIndex = 152;
            this.cmdExport.Text = "导出";
            this.cmdExport.Click += new System.EventHandler(this.cmdExport_Click);
            // 
            // sfdSave
            // 
            this.sfdSave.DefaultExt = "xls";
            this.sfdSave.Filter = "excel文件|*.xls";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnClose);
            this.tabPage1.Controls.Add(this.txtSearchName);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.dgvItem);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(495, 472);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(427, 442);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(61, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtSearchName
            // 
            this.txtSearchName.Font = new System.Drawing.Font("宋体", 10.5F);
            this.txtSearchName.Location = new System.Drawing.Point(129, 443);
            this.txtSearchName.MaxLength = 50;
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(290, 23);
            this.txtSearchName.TabIndex = 2;
            this.txtSearchName.TextChanged += new System.EventHandler(this.txtSearchName_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label4.Location = new System.Drawing.Point(6, 446);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 14);
            this.label4.TabIndex = 1;
            this.label4.Text = "中/英文检索名称:";
            // 
            // dgvItem
            // 
            this.dgvItem.AllowUserToAddRows = false;
            this.dgvItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvItem.Location = new System.Drawing.Point(3, 3);
            this.dgvItem.Name = "dgvItem";
            this.dgvItem.ReadOnly = true;
            this.dgvItem.RowTemplate.Height = 23;
            this.dgvItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItem.Size = new System.Drawing.Size(489, 433);
            this.dgvItem.TabIndex = 0;
            this.dgvItem.DoubleClick += new System.EventHandler(this.dgvItem_DoubleClick);
            // 
            // tabContorl
            // 
            this.tabContorl.Controls.Add(this.tabPage1);
            this.tabContorl.Location = new System.Drawing.Point(382, 75);
            this.tabContorl.Name = "tabContorl";
            this.tabContorl.SelectedIndex = 0;
            this.tabContorl.Size = new System.Drawing.Size(503, 497);
            this.tabContorl.TabIndex = 153;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.dwResult);
            this.panel2.Location = new System.Drawing.Point(377, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(639, 641);
            this.panel2.TabIndex = 155;
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnPreview.DefaultScheme = true;
            this.btnPreview.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPreview.Hint = "";
            this.btnPreview.Location = new System.Drawing.Point(9, 16);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnPreview.Size = new System.Drawing.Size(71, 27);
            this.btnPreview.TabIndex = 156;
            this.btnPreview.Text = "预览";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "细菌ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "细菌名称";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "英文名称";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "抗生素ID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "抗生素名称";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 120;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "英文名称";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // frmMicReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 643);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.tabContorl);
            this.Controls.Add(this.cmdExport);
            this.Controls.Add(this.cmdPrint);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frmMicReport";
            this.Text = "细菌统计报表";
            this.Load += new System.EventHandler(this.frmMicReport_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_mic)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_anti)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).EndInit();
            this.tabContorl.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        internal Sybase.DataWindow.DataWindowControl dwResult;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox m_cboCondition;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.DateTimePicker m_dtpDatFrom;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.DateTimePicker m_dtpDatTo;
        private System.Windows.Forms.RadioButton m_rdbMic;
        private System.Windows.Forms.RadioButton m_rdbAllMic;
        private System.Windows.Forms.RadioButton m_rdbAnti;
        private System.Windows.Forms.RadioButton m_rdbAll;
        internal System.Windows.Forms.DataGridView dgv_anti;
        internal System.Windows.Forms.DataGridView dgv_mic;
        internal PinkieControls.ButtonXP btnCount;
        internal PinkieControls.ButtonXP cmdExit;
        internal PinkieControls.ButtonXP cmdPrint;
        internal PinkieControls.ButtonXP cmdExport;
        private System.Windows.Forms.SaveFileDialog sfdSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cname;
        private System.Windows.Forms.DataGridViewTextBoxColumn ename;
        private System.Windows.Forms.TabPage tabPage1;
        internal System.Windows.Forms.DataGridView dgvItem;
        internal System.Windows.Forms.TabControl tabContorl;
        private System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn antiID;
        private System.Windows.Forms.DataGridViewTextBoxColumn anti_cname;
        private System.Windows.Forms.DataGridViewTextBoxColumn anti_ename;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Panel panel2;
        internal PinkieControls.ButtonXP btnPreview;
        private System.Drawing.Printing.PrintDocument MyPrintDocument;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.ComboBox cbxTestMethod;
        internal System.Windows.Forms.TextBox txtAgeTo;
        private System.Windows.Forms.Label label10;
        internal System.Windows.Forms.TextBox txtAgeFrom;
        internal System.Windows.Forms.ComboBox cbxSex;
        internal System.Windows.Forms.ComboBox cbxDistrict;
        internal System.Windows.Forms.ComboBox cbxSampleType;
    }
}