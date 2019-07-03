namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmOPSFindreport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOPSFindreport));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkCardno = new System.Windows.Forms.CheckBox();
            this.chkName = new System.Windows.Forms.CheckBox();
            this.chkSex = new System.Windows.Forms.CheckBox();
            this.chkDept = new System.Windows.Forms.CheckBox();
            this.chkOPSName = new System.Windows.Forms.CheckBox();
            this.chkDoctor = new System.Windows.Forms.CheckBox();
            this.chkOPSDate = new System.Windows.Forms.CheckBox();
            this.txtCardno = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cboSex = new System.Windows.Forms.ComboBox();
            this.txtOPSName = new System.Windows.Forms.TextBox();
            this.dtpBegindate = new System.Windows.Forms.DateTimePicker();
            this.dtpEnddate = new System.Windows.Forms.DateTimePicker();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rdoAnd = new System.Windows.Forms.RadioButton();
            this.rdoOr = new System.Windows.Forms.RadioButton();
            this.txtDept = new com.digitalwave.controls.ctlTextBoxFind();
            this.m_txtFinddoct = new com.digitalwave.controls.ctlTextBoxFind();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("宋体", 10F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridView.ColumnHeadersHeight = 25;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10});
            this.dataGridView.Location = new System.Drawing.Point(1, 124);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 24;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.ShowCellErrors = false;
            this.dataGridView.Size = new System.Drawing.Size(719, 556);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellDoubleClick);
            // 
            // Column1
            // 
            dataGridViewCellStyle13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle13;
            this.Column1.HeaderText = "报告单号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 70;
            // 
            // Column2
            // 
            dataGridViewCellStyle14.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Column2.DefaultCellStyle = dataGridViewCellStyle14;
            this.Column2.HeaderText = "姓名";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 60;
            // 
            // Column3
            // 
            dataGridViewCellStyle15.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Column3.DefaultCellStyle = dataGridViewCellStyle15;
            this.Column3.HeaderText = "性别";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 50;
            // 
            // Column4
            // 
            dataGridViewCellStyle16.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Column4.DefaultCellStyle = dataGridViewCellStyle16;
            this.Column4.HeaderText = "出生年月";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            dataGridViewCellStyle17.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Column5.DefaultCellStyle = dataGridViewCellStyle17;
            this.Column5.HeaderText = "诊疗卡号";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            dataGridViewCellStyle18.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Column6.DefaultCellStyle = dataGridViewCellStyle18;
            this.Column6.HeaderText = "手术科室";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            dataGridViewCellStyle19.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Column7.DefaultCellStyle = dataGridViewCellStyle19;
            this.Column7.HeaderText = "手术名称";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            dataGridViewCellStyle20.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Column8.DefaultCellStyle = dataGridViewCellStyle20;
            this.Column8.HeaderText = "手术时间";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            dataGridViewCellStyle21.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Column9.DefaultCellStyle = dataGridViewCellStyle21;
            this.Column9.HeaderText = "手术者";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 60;
            // 
            // Column10
            // 
            dataGridViewCellStyle22.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Column10.DefaultCellStyle = dataGridViewCellStyle22;
            this.Column10.HeaderText = "手术记录";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // chkCardno
            // 
            this.chkCardno.AutoSize = true;
            this.chkCardno.Checked = true;
            this.chkCardno.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCardno.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkCardno.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkCardno.Location = new System.Drawing.Point(12, 12);
            this.chkCardno.Name = "chkCardno";
            this.chkCardno.Size = new System.Drawing.Size(80, 18);
            this.chkCardno.TabIndex = 1;
            this.chkCardno.Text = "诊疗卡号";
            this.chkCardno.UseVisualStyleBackColor = true;
            this.chkCardno.CheckedChanged += new System.EventHandler(this.chkCardno_CheckedChanged);
            // 
            // chkName
            // 
            this.chkName.AutoSize = true;
            this.chkName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkName.Location = new System.Drawing.Point(219, 12);
            this.chkName.Name = "chkName";
            this.chkName.Size = new System.Drawing.Size(52, 18);
            this.chkName.TabIndex = 2;
            this.chkName.Text = "姓名";
            this.chkName.UseVisualStyleBackColor = true;
            this.chkName.CheckedChanged += new System.EventHandler(this.chkName_CheckedChanged);
            // 
            // chkSex
            // 
            this.chkSex.AutoSize = true;
            this.chkSex.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkSex.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkSex.Location = new System.Drawing.Point(356, 12);
            this.chkSex.Name = "chkSex";
            this.chkSex.Size = new System.Drawing.Size(52, 18);
            this.chkSex.TabIndex = 3;
            this.chkSex.Text = "性别";
            this.chkSex.UseVisualStyleBackColor = true;
            this.chkSex.CheckedChanged += new System.EventHandler(this.chkSex_CheckedChanged);
            // 
            // chkDept
            // 
            this.chkDept.AutoSize = true;
            this.chkDept.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkDept.Location = new System.Drawing.Point(12, 53);
            this.chkDept.Name = "chkDept";
            this.chkDept.Size = new System.Drawing.Size(80, 18);
            this.chkDept.TabIndex = 5;
            this.chkDept.Text = "手术科室";
            this.chkDept.UseVisualStyleBackColor = true;
            this.chkDept.CheckedChanged += new System.EventHandler(this.chkDept_CheckedChanged);
            // 
            // chkOPSName
            // 
            this.chkOPSName.AutoSize = true;
            this.chkOPSName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkOPSName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkOPSName.Location = new System.Drawing.Point(219, 53);
            this.chkOPSName.Name = "chkOPSName";
            this.chkOPSName.Size = new System.Drawing.Size(80, 18);
            this.chkOPSName.TabIndex = 6;
            this.chkOPSName.Text = "手术名称";
            this.chkOPSName.UseVisualStyleBackColor = true;
            this.chkOPSName.CheckedChanged += new System.EventHandler(this.chkOPSName_CheckedChanged);
            // 
            // chkDoctor
            // 
            this.chkDoctor.AutoSize = true;
            this.chkDoctor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkDoctor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkDoctor.Location = new System.Drawing.Point(473, 12);
            this.chkDoctor.Name = "chkDoctor";
            this.chkDoctor.Size = new System.Drawing.Size(66, 18);
            this.chkDoctor.TabIndex = 7;
            this.chkDoctor.Text = "手术者";
            this.chkDoctor.UseVisualStyleBackColor = true;
            this.chkDoctor.CheckedChanged += new System.EventHandler(this.chkDoctor_CheckedChanged);
            // 
            // chkOPSDate
            // 
            this.chkOPSDate.AutoSize = true;
            this.chkOPSDate.Checked = true;
            this.chkOPSDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOPSDate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkOPSDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkOPSDate.Location = new System.Drawing.Point(12, 94);
            this.chkOPSDate.Name = "chkOPSDate";
            this.chkOPSDate.Size = new System.Drawing.Size(80, 18);
            this.chkOPSDate.TabIndex = 9;
            this.chkOPSDate.Text = "手术时间";
            this.chkOPSDate.UseVisualStyleBackColor = true;
            this.chkOPSDate.CheckedChanged += new System.EventHandler(this.chkOPSDate_CheckedChanged);
            // 
            // txtCardno
            // 
            this.txtCardno.BackColor = System.Drawing.Color.White;
            this.txtCardno.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCardno.Location = new System.Drawing.Point(92, 12);
            this.txtCardno.MaxLength = 10;
            this.txtCardno.Name = "txtCardno";
            this.txtCardno.Size = new System.Drawing.Size(116, 23);
            this.txtCardno.TabIndex = 0;
            this.txtCardno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCardno_KeyDown);
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.Enabled = false;
            this.txtName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.Location = new System.Drawing.Point(272, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(72, 23);
            this.txtName.TabIndex = 12;
            // 
            // cboSex
            // 
            this.cboSex.BackColor = System.Drawing.Color.White;
            this.cboSex.Enabled = false;
            this.cboSex.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboSex.FormattingEnabled = true;
            this.cboSex.Items.AddRange(new object[] {
            "男",
            "女"});
            this.cboSex.Location = new System.Drawing.Point(408, 12);
            this.cboSex.Name = "cboSex";
            this.cboSex.Size = new System.Drawing.Size(52, 22);
            this.cboSex.TabIndex = 14;
            // 
            // txtOPSName
            // 
            this.txtOPSName.BackColor = System.Drawing.Color.White;
            this.txtOPSName.Enabled = false;
            this.txtOPSName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOPSName.Location = new System.Drawing.Point(297, 52);
            this.txtOPSName.Name = "txtOPSName";
            this.txtOPSName.Size = new System.Drawing.Size(320, 23);
            this.txtOPSName.TabIndex = 16;
            // 
            // dtpBegindate
            // 
            this.dtpBegindate.CalendarFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpBegindate.CustomFormat = "yyyy年MM月dd日";
            this.dtpBegindate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpBegindate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBegindate.Location = new System.Drawing.Point(112, 93);
            this.dtpBegindate.Name = "dtpBegindate";
            this.dtpBegindate.Size = new System.Drawing.Size(120, 23);
            this.dtpBegindate.TabIndex = 20;
            // 
            // dtpEnddate
            // 
            this.dtpEnddate.CalendarFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpEnddate.CustomFormat = "yyyy年MM月dd日";
            this.dtpEnddate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpEnddate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnddate.Location = new System.Drawing.Point(262, 93);
            this.dtpEnddate.Name = "dtpEnddate";
            this.dtpEnddate.Size = new System.Drawing.Size(120, 23);
            this.dtpEnddate.TabIndex = 21;
            // 
            // btnFind
            // 
            this.btnFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFind.Font = new System.Drawing.Font("宋体", 10F);
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFind.Location = new System.Drawing.Point(636, 9);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(76, 28);
            this.btnFind.TabIndex = 22;
            this.btnFind.Text = "查找(&F)";
            this.btnFind.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrint.Font = new System.Drawing.Font("宋体", 10F);
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(636, 48);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(76, 28);
            this.btnPrint.TabIndex = 23;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("宋体", 10F);
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(636, 86);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(76, 28);
            this.btnClose.TabIndex = 25;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(88, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 14);
            this.label1.TabIndex = 26;
            this.label1.Text = "从";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(237, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 27;
            this.label2.Text = "到";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(408, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 14);
            this.label3.TabIndex = 28;
            this.label3.Text = "条件组合关系";
            // 
            // rdoAnd
            // 
            this.rdoAnd.AutoSize = true;
            this.rdoAnd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoAnd.Location = new System.Drawing.Point(508, 96);
            this.rdoAnd.Name = "rdoAnd";
            this.rdoAnd.Size = new System.Drawing.Size(53, 18);
            this.rdoAnd.TabIndex = 29;
            this.rdoAnd.Text = "并且";
            this.rdoAnd.UseVisualStyleBackColor = true;
            // 
            // rdoOr
            // 
            this.rdoOr.AutoSize = true;
            this.rdoOr.Checked = true;
            this.rdoOr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoOr.Location = new System.Drawing.Point(568, 96);
            this.rdoOr.Name = "rdoOr";
            this.rdoOr.Size = new System.Drawing.Size(53, 18);
            this.rdoOr.TabIndex = 30;
            this.rdoOr.TabStop = true;
            this.rdoOr.Text = "或者";
            this.rdoOr.UseVisualStyleBackColor = true;
            // 
            // txtDept
            // 
            this.txtDept.Enabled = false;
            this.txtDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDept.intHeight = 200;
            this.txtDept.IsEnterShow = false;
            this.txtDept.isHide = 3;
            this.txtDept.isTxt = 1;
            this.txtDept.isUpOrDn = 0;
            this.txtDept.isValuse = 3;
            this.txtDept.Location = new System.Drawing.Point(91, 53);
            this.txtDept.m_IsHaveParent = false;
            this.txtDept.m_strParentName = "";
            this.txtDept.Name = "txtDept";
            this.txtDept.nextCtl = this.btnFind;
            this.txtDept.Size = new System.Drawing.Size(117, 23);
            this.txtDept.TabIndex = 92;
            this.txtDept.txtValuse = "";
            this.txtDept.VsLeftOrRight = 1;
            // 
            // m_txtFinddoct
            // 
            this.m_txtFinddoct.AccessibleName = "0";
            this.m_txtFinddoct.BackColor = System.Drawing.SystemColors.Control;
            this.m_txtFinddoct.Enabled = false;
            this.m_txtFinddoct.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtFinddoct.intHeight = 200;
            this.m_txtFinddoct.IsEnterShow = false;
            this.m_txtFinddoct.isHide = 3;
            this.m_txtFinddoct.isTxt = 1;
            this.m_txtFinddoct.isUpOrDn = 0;
            this.m_txtFinddoct.isValuse = 3;
            this.m_txtFinddoct.Location = new System.Drawing.Point(540, 12);
            this.m_txtFinddoct.m_IsHaveParent = false;
            this.m_txtFinddoct.m_strParentName = "";
            this.m_txtFinddoct.Name = "m_txtFinddoct";
            this.m_txtFinddoct.nextCtl = this.btnFind;
            this.m_txtFinddoct.Size = new System.Drawing.Size(77, 23);
            this.m_txtFinddoct.TabIndex = 101;
            this.m_txtFinddoct.txtValuse = "";
            this.m_txtFinddoct.VsLeftOrRight = 1;
            // 
            // frmOPSFindreport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 681);
            this.Controls.Add(this.m_txtFinddoct);
            this.Controls.Add(this.txtDept);
            this.Controls.Add(this.rdoOr);
            this.Controls.Add(this.rdoAnd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.dtpEnddate);
            this.Controls.Add(this.dtpBegindate);
            this.Controls.Add(this.txtOPSName);
            this.Controls.Add(this.cboSex);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCardno);
            this.Controls.Add(this.chkOPSDate);
            this.Controls.Add(this.chkDoctor);
            this.Controls.Add(this.chkOPSName);
            this.Controls.Add(this.chkDept);
            this.Controls.Add(this.chkSex);
            this.Controls.Add(this.chkName);
            this.Controls.Add(this.chkCardno);
            this.Controls.Add(this.dataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOPSFindreport";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "手术报告单查询窗口";
            this.Load += new System.EventHandler(this.frmOPSFindreport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        internal System.Windows.Forms.CheckBox chkCardno;
        internal System.Windows.Forms.CheckBox chkName;
        internal System.Windows.Forms.CheckBox chkSex;
        internal System.Windows.Forms.CheckBox chkDept;
        internal System.Windows.Forms.CheckBox chkOPSName;
        internal System.Windows.Forms.CheckBox chkDoctor;
        internal System.Windows.Forms.CheckBox chkOPSDate;
        internal System.Windows.Forms.TextBox txtCardno;
        internal System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cboSex;
        internal System.Windows.Forms.TextBox txtOPSName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Button btnFind;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.RadioButton rdoAnd;
        internal System.Windows.Forms.RadioButton rdoOr;
        internal System.Windows.Forms.DateTimePicker dtpBegindate;
        internal System.Windows.Forms.DateTimePicker dtpEnddate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        public com.digitalwave.controls.ctlTextBoxFind txtDept;
        public com.digitalwave.controls.ctlTextBoxFind m_txtFinddoct;
    }
}