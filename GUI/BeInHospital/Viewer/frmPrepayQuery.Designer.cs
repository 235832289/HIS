namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmPrepayQuery
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_dataGridViewRs = new System.Windows.Forms.DataGridView();
            this.INPATIENTID_CHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LASTNAME_VCHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SEX_CHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEPTNAME_VCHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CREATE_DAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PREPAYINV_VCHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REPPRNBILLNO_VCHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MONEY_DEC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUYCATE_INT = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.PAYTYPE_INT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CREATER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BALANCEFLAG_INT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UPTYPE_INT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONFIRMEMP_CHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PREPAYID_CHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReprint = new PinkieControls.ButtonXP();
            this.cboPayType = new System.Windows.Forms.ComboBox();
            this.chkPayType = new System.Windows.Forms.CheckBox();
            this.m_buttonExit = new PinkieControls.ButtonXP();
            this.m_buttonPrint = new PinkieControls.ButtonXP();
            this.m_cmdArea = new PinkieControls.ButtonXP();
            this.m_buttonFind = new PinkieControls.ButtonXP();
            this.m_dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.m_dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.m_textBoxCreater = new System.Windows.Forms.TextBox();
            this.m_checkBoxArea = new System.Windows.Forms.CheckBox();
            this.m_checkBoxCreater = new System.Windows.Forms.CheckBox();
            this.m_textBoxInPatientId = new System.Windows.Forms.TextBox();
            this.m_textBoxPrepayInv = new System.Windows.Forms.TextBox();
            this.m_checkBoxInPatientId = new System.Windows.Forms.CheckBox();
            this.m_checkBoxPrepayInv = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.m_checkBoxDate = new System.Windows.Forms.CheckBox();
            this.m_labelTo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGridViewRs)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_dataGridViewRs);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1463, 533);
            this.panel1.TabIndex = 0;
            // 
            // m_dataGridViewRs
            // 
            this.m_dataGridViewRs.AllowUserToAddRows = false;
            this.m_dataGridViewRs.AllowUserToDeleteRows = false;
            this.m_dataGridViewRs.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(254)))), ((int)(((byte)(241)))));
            this.m_dataGridViewRs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dataGridViewRs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.m_dataGridViewRs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dataGridViewRs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.INPATIENTID_CHR,
            this.LASTNAME_VCHR,
            this.SEX_CHR,
            this.DEPTNAME_VCHR,
            this.CREATE_DAT,
            this.PREPAYINV_VCHR,
            this.REPPRNBILLNO_VCHR,
            this.MONEY_DEC,
            this.CUYCATE_INT,
            this.PAYTYPE_INT,
            this.CREATER,
            this.BALANCEFLAG_INT,
            this.UPTYPE_INT,
            this.CONFIRMEMP_CHR,
            this.PREPAYID_CHR});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.m_dataGridViewRs.DefaultCellStyle = dataGridViewCellStyle4;
            this.m_dataGridViewRs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dataGridViewRs.Location = new System.Drawing.Point(0, 84);
            this.m_dataGridViewRs.MultiSelect = false;
            this.m_dataGridViewRs.Name = "m_dataGridViewRs";
            this.m_dataGridViewRs.RowTemplate.Height = 23;
            this.m_dataGridViewRs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dataGridViewRs.Size = new System.Drawing.Size(1463, 449);
            this.m_dataGridViewRs.TabIndex = 0;
            this.m_dataGridViewRs.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.m_dataGridViewRs_CellBeginEdit);
            this.m_dataGridViewRs.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.m_dataGridViewRs_SortCompare);
            this.m_dataGridViewRs.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dataGridViewRs_CellEndEdit);
            // 
            // INPATIENTID_CHR
            // 
            this.INPATIENTID_CHR.HeaderText = "住院号";
            this.INPATIENTID_CHR.Name = "INPATIENTID_CHR";
            this.INPATIENTID_CHR.ReadOnly = true;
            this.INPATIENTID_CHR.Width = 98;
            // 
            // LASTNAME_VCHR
            // 
            this.LASTNAME_VCHR.HeaderText = "姓名";
            this.LASTNAME_VCHR.Name = "LASTNAME_VCHR";
            this.LASTNAME_VCHR.ReadOnly = true;
            this.LASTNAME_VCHR.Width = 80;
            // 
            // SEX_CHR
            // 
            this.SEX_CHR.HeaderText = "性别";
            this.SEX_CHR.Name = "SEX_CHR";
            this.SEX_CHR.ReadOnly = true;
            this.SEX_CHR.Width = 60;
            // 
            // DEPTNAME_VCHR
            // 
            this.DEPTNAME_VCHR.HeaderText = "病区";
            this.DEPTNAME_VCHR.Name = "DEPTNAME_VCHR";
            this.DEPTNAME_VCHR.ReadOnly = true;
            this.DEPTNAME_VCHR.Width = 95;
            // 
            // CREATE_DAT
            // 
            this.CREATE_DAT.HeaderText = "收款日期";
            this.CREATE_DAT.Name = "CREATE_DAT";
            this.CREATE_DAT.ReadOnly = true;
            this.CREATE_DAT.Width = 140;
            // 
            // PREPAYINV_VCHR
            // 
            this.PREPAYINV_VCHR.HeaderText = "预交单号";
            this.PREPAYINV_VCHR.Name = "PREPAYINV_VCHR";
            this.PREPAYINV_VCHR.ReadOnly = true;
            // 
            // REPPRNBILLNO_VCHR
            // 
            this.REPPRNBILLNO_VCHR.HeaderText = "重打单号";
            this.REPPRNBILLNO_VCHR.Name = "REPPRNBILLNO_VCHR";
            this.REPPRNBILLNO_VCHR.ReadOnly = true;
            // 
            // MONEY_DEC
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0.00";
            this.MONEY_DEC.DefaultCellStyle = dataGridViewCellStyle3;
            this.MONEY_DEC.HeaderText = "金额";
            this.MONEY_DEC.Name = "MONEY_DEC";
            this.MONEY_DEC.ReadOnly = true;
            this.MONEY_DEC.Width = 95;
            // 
            // CUYCATE_INT
            // 
            this.CUYCATE_INT.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.CUYCATE_INT.HeaderText = "支付类型";
            this.CUYCATE_INT.Items.AddRange(new object[] {
            "现金",
            "支票",
            "银行卡",
            "微信",
            "支付宝",
            "微信2"});
            this.CUYCATE_INT.MaxDropDownItems = 5;
            this.CUYCATE_INT.Name = "CUYCATE_INT";
            this.CUYCATE_INT.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CUYCATE_INT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CUYCATE_INT.Width = 90;
            // 
            // PAYTYPE_INT
            // 
            this.PAYTYPE_INT.HeaderText = "发票状态";
            this.PAYTYPE_INT.Name = "PAYTYPE_INT";
            this.PAYTYPE_INT.ReadOnly = true;
            this.PAYTYPE_INT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // CREATER
            // 
            this.CREATER.HeaderText = "收款员";
            this.CREATER.Name = "CREATER";
            this.CREATER.ReadOnly = true;
            this.CREATER.Width = 80;
            // 
            // BALANCEFLAG_INT
            // 
            this.BALANCEFLAG_INT.HeaderText = "缴费状态";
            this.BALANCEFLAG_INT.Name = "BALANCEFLAG_INT";
            this.BALANCEFLAG_INT.ReadOnly = true;
            this.BALANCEFLAG_INT.Width = 90;
            // 
            // UPTYPE_INT
            // 
            this.UPTYPE_INT.HeaderText = "预交方式";
            this.UPTYPE_INT.Name = "UPTYPE_INT";
            // 
            // CONFIRMEMP_CHR
            // 
            this.CONFIRMEMP_CHR.HeaderText = "审核人";
            this.CONFIRMEMP_CHR.Name = "CONFIRMEMP_CHR";
            // 
            // PREPAYID_CHR
            // 
            this.PREPAYID_CHR.HeaderText = "prepayId";
            this.PREPAYID_CHR.Name = "PREPAYID_CHR";
            this.PREPAYID_CHR.ReadOnly = true;
            this.PREPAYID_CHR.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReprint);
            this.groupBox1.Controls.Add(this.cboPayType);
            this.groupBox1.Controls.Add(this.chkPayType);
            this.groupBox1.Controls.Add(this.m_buttonExit);
            this.groupBox1.Controls.Add(this.m_buttonPrint);
            this.groupBox1.Controls.Add(this.m_cmdArea);
            this.groupBox1.Controls.Add(this.m_buttonFind);
            this.groupBox1.Controls.Add(this.m_dateTimePickerTo);
            this.groupBox1.Controls.Add(this.m_dateTimePickerFrom);
            this.groupBox1.Controls.Add(this.m_textBoxCreater);
            this.groupBox1.Controls.Add(this.m_checkBoxArea);
            this.groupBox1.Controls.Add(this.m_checkBoxCreater);
            this.groupBox1.Controls.Add(this.m_textBoxInPatientId);
            this.groupBox1.Controls.Add(this.m_textBoxPrepayInv);
            this.groupBox1.Controls.Add(this.m_checkBoxInPatientId);
            this.groupBox1.Controls.Add(this.m_checkBoxPrepayInv);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.m_checkBoxDate);
            this.groupBox1.Controls.Add(this.m_labelTo);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1463, 84);
            this.groupBox1.TabIndex = 56;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // btnReprint
            // 
            this.btnReprint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnReprint.DefaultScheme = true;
            this.btnReprint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnReprint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReprint.Hint = "";
            this.btnReprint.Location = new System.Drawing.Point(876, 51);
            this.btnReprint.Name = "btnReprint";
            this.btnReprint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnReprint.Size = new System.Drawing.Size(75, 28);
            this.btnReprint.TabIndex = 67;
            this.btnReprint.Text = "重打发票";
            this.btnReprint.Click += new System.EventHandler(this.btnReprint_Click);
            // 
            // cboPayType
            // 
            this.cboPayType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPayType.FormattingEnabled = true;
            this.cboPayType.ItemHeight = 14;
            this.cboPayType.Items.AddRange(new object[] {
            "",
            "现金",
            "支票",
            "银行卡",
            "微信",
            "支付宝"});
            this.cboPayType.Location = new System.Drawing.Point(1042, 21);
            this.cboPayType.Name = "cboPayType";
            this.cboPayType.Size = new System.Drawing.Size(81, 22);
            this.cboPayType.TabIndex = 66;
            // 
            // chkPayType
            // 
            this.chkPayType.AutoSize = true;
            this.chkPayType.Location = new System.Drawing.Point(960, 24);
            this.chkPayType.Name = "chkPayType";
            this.chkPayType.Size = new System.Drawing.Size(82, 18);
            this.chkPayType.TabIndex = 65;
            this.chkPayType.Text = "支付方式";
            this.chkPayType.UseVisualStyleBackColor = true;
            // 
            // m_buttonExit
            // 
            this.m_buttonExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_buttonExit.DefaultScheme = true;
            this.m_buttonExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_buttonExit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_buttonExit.Hint = "";
            this.m_buttonExit.Location = new System.Drawing.Point(1051, 51);
            this.m_buttonExit.Name = "m_buttonExit";
            this.m_buttonExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_buttonExit.Size = new System.Drawing.Size(75, 28);
            this.m_buttonExit.TabIndex = 58;
            this.m_buttonExit.Text = "退出(&E)";
            this.m_buttonExit.Click += new System.EventHandler(this.m_buttonExit_Click);
            // 
            // m_buttonPrint
            // 
            this.m_buttonPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_buttonPrint.DefaultScheme = true;
            this.m_buttonPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_buttonPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_buttonPrint.Hint = "";
            this.m_buttonPrint.Location = new System.Drawing.Point(964, 51);
            this.m_buttonPrint.Name = "m_buttonPrint";
            this.m_buttonPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_buttonPrint.Size = new System.Drawing.Size(75, 28);
            this.m_buttonPrint.TabIndex = 57;
            this.m_buttonPrint.Text = "打印(&P)";
            this.m_buttonPrint.Click += new System.EventHandler(this.m_buttonPrint_Click);
            // 
            // m_cmdArea
            // 
            this.m_cmdArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cmdArea.DefaultScheme = true;
            this.m_cmdArea.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdArea.ForeColor = System.Drawing.Color.Blue;
            this.m_cmdArea.Hint = "";
            this.m_cmdArea.Location = new System.Drawing.Point(396, 21);
            this.m_cmdArea.Name = "m_cmdArea";
            this.m_cmdArea.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdArea.Size = new System.Drawing.Size(75, 27);
            this.m_cmdArea.TabIndex = 64;
            this.m_cmdArea.Text = "病区▼";
            this.m_cmdArea.Click += new System.EventHandler(this.m_cmdArea_Click);
            // 
            // m_buttonFind
            // 
            this.m_buttonFind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_buttonFind.DefaultScheme = true;
            this.m_buttonFind.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_buttonFind.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_buttonFind.Hint = "";
            this.m_buttonFind.Location = new System.Drawing.Point(788, 51);
            this.m_buttonFind.Name = "m_buttonFind";
            this.m_buttonFind.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_buttonFind.Size = new System.Drawing.Size(75, 28);
            this.m_buttonFind.TabIndex = 51;
            this.m_buttonFind.Text = "查询(&F)";
            this.m_buttonFind.Click += new System.EventHandler(this.m_buttonFind_Click);
            // 
            // m_dateTimePickerTo
            // 
            this.m_dateTimePickerTo.CustomFormat = "yyyy-MM-dd HH:mm";
            this.m_dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dateTimePickerTo.Location = new System.Drawing.Point(233, 22);
            this.m_dateTimePickerTo.Name = "m_dateTimePickerTo";
            this.m_dateTimePickerTo.Size = new System.Drawing.Size(155, 23);
            this.m_dateTimePickerTo.TabIndex = 47;
            // 
            // m_dateTimePickerFrom
            // 
            this.m_dateTimePickerFrom.CustomFormat = "yyyy-MM-dd HH:mm";
            this.m_dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dateTimePickerFrom.Location = new System.Drawing.Point(56, 22);
            this.m_dateTimePickerFrom.Name = "m_dateTimePickerFrom";
            this.m_dateTimePickerFrom.Size = new System.Drawing.Size(156, 23);
            this.m_dateTimePickerFrom.TabIndex = 49;
            // 
            // m_textBoxCreater
            // 
            this.m_textBoxCreater.Enabled = false;
            this.m_textBoxCreater.Location = new System.Drawing.Point(558, 20);
            this.m_textBoxCreater.Name = "m_textBoxCreater";
            this.m_textBoxCreater.Size = new System.Drawing.Size(80, 23);
            this.m_textBoxCreater.TabIndex = 60;
            // 
            // m_checkBoxArea
            // 
            this.m_checkBoxArea.AutoSize = true;
            this.m_checkBoxArea.Location = new System.Drawing.Point(506, -3);
            this.m_checkBoxArea.Name = "m_checkBoxArea";
            this.m_checkBoxArea.Size = new System.Drawing.Size(54, 18);
            this.m_checkBoxArea.TabIndex = 61;
            this.m_checkBoxArea.Text = "病区";
            this.m_checkBoxArea.UseVisualStyleBackColor = true;
            this.m_checkBoxArea.Visible = false;
            this.m_checkBoxArea.CheckedChanged += new System.EventHandler(this.m_checkBoxArea_CheckedChanged);
            // 
            // m_checkBoxCreater
            // 
            this.m_checkBoxCreater.AutoSize = true;
            this.m_checkBoxCreater.Location = new System.Drawing.Point(480, 24);
            this.m_checkBoxCreater.Name = "m_checkBoxCreater";
            this.m_checkBoxCreater.Size = new System.Drawing.Size(82, 18);
            this.m_checkBoxCreater.TabIndex = 59;
            this.m_checkBoxCreater.Text = "收款工号";
            this.m_checkBoxCreater.UseVisualStyleBackColor = true;
            this.m_checkBoxCreater.CheckedChanged += new System.EventHandler(this.m_checkBoxCreater_CheckedChanged);
            // 
            // m_textBoxInPatientId
            // 
            this.m_textBoxInPatientId.Enabled = false;
            this.m_textBoxInPatientId.Location = new System.Drawing.Point(709, 20);
            this.m_textBoxInPatientId.Name = "m_textBoxInPatientId";
            this.m_textBoxInPatientId.Size = new System.Drawing.Size(81, 23);
            this.m_textBoxInPatientId.TabIndex = 58;
            // 
            // m_textBoxPrepayInv
            // 
            this.m_textBoxPrepayInv.Enabled = false;
            this.m_textBoxPrepayInv.Location = new System.Drawing.Point(872, 20);
            this.m_textBoxPrepayInv.Name = "m_textBoxPrepayInv";
            this.m_textBoxPrepayInv.Size = new System.Drawing.Size(83, 23);
            this.m_textBoxPrepayInv.TabIndex = 54;
            // 
            // m_checkBoxInPatientId
            // 
            this.m_checkBoxInPatientId.AutoSize = true;
            this.m_checkBoxInPatientId.Location = new System.Drawing.Point(642, 24);
            this.m_checkBoxInPatientId.Name = "m_checkBoxInPatientId";
            this.m_checkBoxInPatientId.Size = new System.Drawing.Size(68, 18);
            this.m_checkBoxInPatientId.TabIndex = 55;
            this.m_checkBoxInPatientId.Text = "住院号";
            this.m_checkBoxInPatientId.UseVisualStyleBackColor = true;
            this.m_checkBoxInPatientId.CheckedChanged += new System.EventHandler(this.m_checkBoxInPatientId_CheckedChanged);
            // 
            // m_checkBoxPrepayInv
            // 
            this.m_checkBoxPrepayInv.AutoSize = true;
            this.m_checkBoxPrepayInv.Location = new System.Drawing.Point(796, 24);
            this.m_checkBoxPrepayInv.Name = "m_checkBoxPrepayInv";
            this.m_checkBoxPrepayInv.Size = new System.Drawing.Size(82, 18);
            this.m_checkBoxPrepayInv.TabIndex = 53;
            this.m_checkBoxPrepayInv.Text = "预交单号";
            this.m_checkBoxPrepayInv.UseVisualStyleBackColor = true;
            this.m_checkBoxPrepayInv.CheckedChanged += new System.EventHandler(this.m_checkBoxPrepayInv_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(86, 126);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(107, 23);
            this.textBox1.TabIndex = 57;
            // 
            // m_checkBoxDate
            // 
            this.m_checkBoxDate.AutoSize = true;
            this.m_checkBoxDate.Checked = true;
            this.m_checkBoxDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_checkBoxDate.Location = new System.Drawing.Point(5, 24);
            this.m_checkBoxDate.Name = "m_checkBoxDate";
            this.m_checkBoxDate.Size = new System.Drawing.Size(54, 18);
            this.m_checkBoxDate.TabIndex = 52;
            this.m_checkBoxDate.Text = "日期";
            this.m_checkBoxDate.UseVisualStyleBackColor = true;
            this.m_checkBoxDate.CheckedChanged += new System.EventHandler(this.m_checkBoxDate_CheckedChanged);
            // 
            // m_labelTo
            // 
            this.m_labelTo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_labelTo.Location = new System.Drawing.Point(212, 24);
            this.m_labelTo.Name = "m_labelTo";
            this.m_labelTo.Size = new System.Drawing.Size(19, 17);
            this.m_labelTo.TabIndex = 50;
            this.m_labelTo.Text = "至";
            this.m_labelTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmPrepayQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1463, 533);
            this.Controls.Add(this.panel1);
            this.Name = "frmPrepayQuery";
            this.Text = "住院预收款查询";
            this.Load += new System.EventHandler(this.frmPrepayQuery_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGridViewRs)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.DataGridView m_dataGridViewRs;
        internal System.Windows.Forms.DateTimePicker m_dateTimePickerTo;
        internal PinkieControls.ButtonXP m_buttonFind;
        private System.Windows.Forms.Label m_labelTo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        internal PinkieControls.ButtonXP m_buttonExit;
        internal PinkieControls.ButtonXP m_buttonPrint;
        internal System.Windows.Forms.CheckBox m_checkBoxPrepayInv;
        internal System.Windows.Forms.CheckBox m_checkBoxDate;
        internal System.Windows.Forms.CheckBox m_checkBoxInPatientId;
        internal System.Windows.Forms.CheckBox m_checkBoxCreater;
        internal System.Windows.Forms.DateTimePicker m_dateTimePickerFrom;
        internal System.Windows.Forms.TextBox m_textBoxInPatientId;
        internal System.Windows.Forms.TextBox m_textBoxPrepayInv;
        internal System.Windows.Forms.TextBox m_textBoxCreater;
        internal System.Windows.Forms.CheckBox m_checkBoxArea;
        private PinkieControls.ButtonXP m_cmdArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn INPATIENTID_CHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn LASTNAME_VCHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn SEX_CHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEPTNAME_VCHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn CREATE_DAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PREPAYINV_VCHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn REPPRNBILLNO_VCHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn MONEY_DEC;
        private System.Windows.Forms.DataGridViewComboBoxColumn CUYCATE_INT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PAYTYPE_INT;
        private System.Windows.Forms.DataGridViewTextBoxColumn CREATER;
        private System.Windows.Forms.DataGridViewTextBoxColumn BALANCEFLAG_INT;
        private System.Windows.Forms.DataGridViewTextBoxColumn UPTYPE_INT;
        private System.Windows.Forms.DataGridViewTextBoxColumn CONFIRMEMP_CHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn PREPAYID_CHR;
        internal System.Windows.Forms.CheckBox chkPayType;
        internal System.Windows.Forms.ComboBox cboPayType;
        internal PinkieControls.ButtonXP btnReprint;
    }
}