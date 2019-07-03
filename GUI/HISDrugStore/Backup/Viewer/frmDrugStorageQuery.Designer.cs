namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmDrugStorageQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDrugStorageQuery));
            this.m_dgvDrugStorage = new System.Windows.Forms.DataGridView();
            this.gradientPanel1 = new com.digitalwave.iCare.gui.HIS.GradientPanel();
            this.m_lsbMediciePreptype = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_txtProductor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_lblRetailSum = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_datEndDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker();
            this.lblRetailSumCaption = new System.Windows.Forms.Label();
            this.m_datBeginDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker();
            this.m_cboMedicineType = new System.Windows.Forms.ComboBox();
            this.m_lblRecordNo = new System.Windows.Forms.Label();
            this.lblJx = new System.Windows.Forms.Label();
            this.lblList = new System.Windows.Forms.Label();
            this.lblAbateEndDate = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_rdbDetail = new System.Windows.Forms.RadioButton();
            this.m_rdbTotal = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_rbtAllProvide = new System.Windows.Forms.RadioButton();
            this.m_rbtCanProvide = new System.Windows.Forms.RadioButton();
            this.m_rbtNotProvide = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_rdbNotZero = new System.Windows.Forms.RadioButton();
            this.m_rbtAll = new System.Windows.Forms.RadioButton();
            this.m_rbtNegative = new System.Windows.Forms.RadioButton();
            this.m_rdbZero = new System.Windows.Forms.RadioButton();
            this.m_txtMedicineCode = new System.Windows.Forms.TextBox();
            this.lblLeechdom = new System.Windows.Forms.Label();
            this.m_chkValidDate = new System.Windows.Forms.CheckBox();
            this.m_lblWholesaleSum = new System.Windows.Forms.Label();
            this.m_lblCallSum = new System.Windows.Forms.Label();
            this.lblWholesaleSumCaption = new System.Windows.Forms.Label();
            this.lblCallSumCaption = new System.Windows.Forms.Label();
            this.m_cboStorage = new com.digitalwave.iCare.gui.HIS.exComboBox();
            this.lblStorage = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.m_btnQuery = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnLocate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnExit = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvDrugStorage)).BeginInit();
            this.gradientPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_dgvDrugStorage
            // 
            this.m_dgvDrugStorage.AllowUserToAddRows = false;
            this.m_dgvDrugStorage.AllowUserToDeleteRows = false;
            this.m_dgvDrugStorage.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.OldLace;
            this.m_dgvDrugStorage.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.m_dgvDrugStorage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_dgvDrugStorage.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.m_dgvDrugStorage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_dgvDrugStorage.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgvDrugStorage.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.m_dgvDrugStorage.ColumnHeadersHeight = 40;
            this.m_dgvDrugStorage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgvDrugStorage.Location = new System.Drawing.Point(0, 128);
            this.m_dgvDrugStorage.MultiSelect = false;
            this.m_dgvDrugStorage.Name = "m_dgvDrugStorage";
            this.m_dgvDrugStorage.RowHeadersVisible = false;
            this.m_dgvDrugStorage.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.m_dgvDrugStorage.RowTemplate.Height = 23;
            this.m_dgvDrugStorage.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvDrugStorage.Size = new System.Drawing.Size(1016, 625);
            this.m_dgvDrugStorage.StandardTab = true;
            this.m_dgvDrugStorage.TabIndex = 9;
            this.m_dgvDrugStorage.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvDrugStorage_CellClick);
            this.m_dgvDrugStorage.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvDrugStorage_RowEnter);
            this.m_dgvDrugStorage.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.m_dgvDrugStorage_RowsAdded);
            this.m_dgvDrugStorage.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.m_dgvDrugStorage_CellFormatting);
            this.m_dgvDrugStorage.Sorted += new System.EventHandler(this.m_dgvDrugStorage_Sorted);
            this.m_dgvDrugStorage.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvDrugStorage_CellValueChanged);
            this.m_dgvDrugStorage.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.m_dgvDrugStorage_CellMouseDoubleClick);
            this.m_dgvDrugStorage.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.m_dgvDrugStorage_DataError);
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Controls.Add(this.m_lsbMediciePreptype);
            this.gradientPanel1.Controls.Add(this.label1);
            this.gradientPanel1.Controls.Add(this.label2);
            this.gradientPanel1.Controls.Add(this.label5);
            this.gradientPanel1.Controls.Add(this.label6);
            this.gradientPanel1.Controls.Add(this.m_txtProductor);
            this.gradientPanel1.Controls.Add(this.label4);
            this.gradientPanel1.Controls.Add(this.m_lblRetailSum);
            this.gradientPanel1.Controls.Add(this.label3);
            this.gradientPanel1.Controls.Add(this.m_datEndDate);
            this.gradientPanel1.Controls.Add(this.lblRetailSumCaption);
            this.gradientPanel1.Controls.Add(this.m_datBeginDate);
            this.gradientPanel1.Controls.Add(this.m_cboMedicineType);
            this.gradientPanel1.Controls.Add(this.m_lblRecordNo);
            this.gradientPanel1.Controls.Add(this.lblJx);
            this.gradientPanel1.Controls.Add(this.lblList);
            this.gradientPanel1.Controls.Add(this.lblAbateEndDate);
            this.gradientPanel1.Controls.Add(this.groupBox2);
            this.gradientPanel1.Controls.Add(this.groupBox3);
            this.gradientPanel1.Controls.Add(this.groupBox1);
            this.gradientPanel1.Controls.Add(this.m_txtMedicineCode);
            this.gradientPanel1.Controls.Add(this.lblLeechdom);
            this.gradientPanel1.Controls.Add(this.m_chkValidDate);
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel1.Flip = true;
            this.gradientPanel1.FloatingImage = null;
            this.gradientPanel1.GradientAngle = 90;
            this.gradientPanel1.GradientEndColor = System.Drawing.SystemColors.Control;
            this.gradientPanel1.GradientStartColor = System.Drawing.Color.White;
            this.gradientPanel1.HorizontalFillPercent = 100F;
            this.gradientPanel1.imageXOffset = 0;
            this.gradientPanel1.imageYOffset = 0;
            this.gradientPanel1.Location = new System.Drawing.Point(0, 38);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(1016, 90);
            this.gradientPanel1.TabIndex = 3;
            this.gradientPanel1.VerticalFillPercent = 100F;
            // 
            // m_lsbMediciePreptype
            // 
            this.m_lsbMediciePreptype.FormattingEnabled = true;
            this.m_lsbMediciePreptype.ItemHeight = 14;
            this.m_lsbMediciePreptype.Location = new System.Drawing.Point(539, 9);
            this.m_lsbMediciePreptype.Name = "m_lsbMediciePreptype";
            this.m_lsbMediciePreptype.ScrollAlwaysVisible = true;
            this.m_lsbMediciePreptype.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.m_lsbMediciePreptype.Size = new System.Drawing.Size(106, 18);
            this.m_lsbMediciePreptype.TabIndex = 3;
            this.m_lsbMediciePreptype.Leave += new System.EventHandler(this.m_lsbMediciePreptype_Leave);
            this.m_lsbMediciePreptype.MouseClick += new System.Windows.Forms.MouseEventHandler(this.m_lsbMediciePreptype_MouseClick);
            this.m_lsbMediciePreptype.Enter += new System.EventHandler(this.m_lsbMediciePreptype_Enter);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(973, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 41;
            this.label1.Text = "缺药";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Olive;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(973, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 42;
            this.label2.Text = "停用";
            this.label2.Visible = false;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Olive;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label5.Location = new System.Drawing.Point(940, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 14);
            this.label5.TabIndex = 42;
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(507, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 14);
            this.label6.TabIndex = 1010;
            this.label6.Text = "剂型";
            // 
            // m_txtProductor
            // 
            this.m_txtProductor.Location = new System.Drawing.Point(404, 39);
            this.m_txtProductor.Name = "m_txtProductor";
            this.m_txtProductor.Size = new System.Drawing.Size(241, 23);
            this.m_txtProductor.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(337, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 44;
            this.label4.Text = "生产厂家";
            // 
            // m_lblRetailSum
            // 
            this.m_lblRetailSum.AutoSize = true;
            this.m_lblRetailSum.BackColor = System.Drawing.Color.Transparent;
            this.m_lblRetailSum.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblRetailSum.Location = new System.Drawing.Point(418, 68);
            this.m_lblRetailSum.Name = "m_lblRetailSum";
            this.m_lblRetailSum.Size = new System.Drawing.Size(35, 14);
            this.m_lblRetailSum.TabIndex = 39;
            this.m_lblRetailSum.Text = "0.00";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Red;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(940, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 41;
            // 
            // m_datEndDate
            // 
            this.m_datEndDate.Enabled = false;
            this.m_datEndDate.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_datEndDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_datEndDate.Location = new System.Drawing.Point(210, 7);
            this.m_datEndDate.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日;
            this.m_datEndDate.Mask = "0000年90月90日";
            this.m_datEndDate.Name = "m_datEndDate";
            this.m_datEndDate.Size = new System.Drawing.Size(123, 23);
            this.m_datEndDate.TabIndex = 1;
            this.m_datEndDate.ValidatingType = typeof(System.DateTime);
            // 
            // lblRetailSumCaption
            // 
            this.lblRetailSumCaption.AutoSize = true;
            this.lblRetailSumCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblRetailSumCaption.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRetailSumCaption.Location = new System.Drawing.Point(335, 68);
            this.lblRetailSumCaption.Name = "lblRetailSumCaption";
            this.lblRetailSumCaption.Size = new System.Drawing.Size(77, 14);
            this.lblRetailSumCaption.TabIndex = 36;
            this.lblRetailSumCaption.Text = "零售金额：";
            // 
            // m_datBeginDate
            // 
            this.m_datBeginDate.Enabled = false;
            this.m_datBeginDate.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_datBeginDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_datBeginDate.Location = new System.Drawing.Point(68, 7);
            this.m_datBeginDate.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日;
            this.m_datBeginDate.Mask = "0000年90月90日";
            this.m_datBeginDate.Name = "m_datBeginDate";
            this.m_datBeginDate.Size = new System.Drawing.Size(121, 23);
            this.m_datBeginDate.TabIndex = 0;
            this.m_datBeginDate.ValidatingType = typeof(System.DateTime);
            // 
            // m_cboMedicineType
            // 
            this.m_cboMedicineType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboMedicineType.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_cboMedicineType.FormattingEnabled = true;
            this.m_cboMedicineType.Location = new System.Drawing.Point(404, 7);
            this.m_cboMedicineType.Name = "m_cboMedicineType";
            this.m_cboMedicineType.Size = new System.Drawing.Size(103, 22);
            this.m_cboMedicineType.TabIndex = 2;
            // 
            // m_lblRecordNo
            // 
            this.m_lblRecordNo.BackColor = System.Drawing.Color.Transparent;
            this.m_lblRecordNo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblRecordNo.Location = new System.Drawing.Point(112, 67);
            this.m_lblRecordNo.Name = "m_lblRecordNo";
            this.m_lblRecordNo.Size = new System.Drawing.Size(101, 14);
            this.m_lblRecordNo.TabIndex = 34;
            this.m_lblRecordNo.Text = "０/０";
            // 
            // lblJx
            // 
            this.lblJx.AutoSize = true;
            this.lblJx.BackColor = System.Drawing.Color.Transparent;
            this.lblJx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblJx.Location = new System.Drawing.Point(339, 11);
            this.lblJx.Name = "lblJx";
            this.lblJx.Size = new System.Drawing.Size(63, 14);
            this.lblJx.TabIndex = 27;
            this.lblJx.Text = "药品分类";
            // 
            // lblList
            // 
            this.lblList.AutoSize = true;
            this.lblList.BackColor = System.Drawing.Color.Transparent;
            this.lblList.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblList.Location = new System.Drawing.Point(14, 67);
            this.lblList.Name = "lblList";
            this.lblList.Size = new System.Drawing.Size(105, 14);
            this.lblList.TabIndex = 33;
            this.lblList.Text = "药品统计列表：";
            // 
            // lblAbateEndDate
            // 
            this.lblAbateEndDate.AutoSize = true;
            this.lblAbateEndDate.BackColor = System.Drawing.Color.Transparent;
            this.lblAbateEndDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAbateEndDate.Location = new System.Drawing.Point(189, 11);
            this.lblAbateEndDate.Name = "lblAbateEndDate";
            this.lblAbateEndDate.Size = new System.Drawing.Size(21, 14);
            this.lblAbateEndDate.TabIndex = 26;
            this.lblAbateEndDate.Text = "至";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.m_rdbDetail);
            this.groupBox2.Controls.Add(this.m_rdbTotal);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 9F);
            this.groupBox2.Location = new System.Drawing.Point(648, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(79, 75);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查询类别";
            // 
            // m_rdbDetail
            // 
            this.m_rdbDetail.AutoSize = true;
            this.m_rdbDetail.Checked = true;
            this.m_rdbDetail.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_rdbDetail.Location = new System.Drawing.Point(9, 46);
            this.m_rdbDetail.Name = "m_rdbDetail";
            this.m_rdbDetail.Size = new System.Drawing.Size(53, 18);
            this.m_rdbDetail.TabIndex = 1;
            this.m_rdbDetail.TabStop = true;
            this.m_rdbDetail.Text = "明细";
            this.m_rdbDetail.UseVisualStyleBackColor = true;
            // 
            // m_rdbTotal
            // 
            this.m_rdbTotal.AutoSize = true;
            this.m_rdbTotal.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_rdbTotal.Location = new System.Drawing.Point(9, 18);
            this.m_rdbTotal.Name = "m_rdbTotal";
            this.m_rdbTotal.Size = new System.Drawing.Size(53, 18);
            this.m_rdbTotal.TabIndex = 0;
            this.m_rdbTotal.TabStop = true;
            this.m_rdbTotal.Text = "统计";
            this.m_rdbTotal.UseVisualStyleBackColor = true;
            this.m_rdbTotal.CheckedChanged += new System.EventHandler(this.m_rdbTotal_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.m_rbtAllProvide);
            this.groupBox3.Controls.Add(this.m_rbtCanProvide);
            this.groupBox3.Controls.Add(this.m_rbtNotProvide);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 9F);
            this.groupBox3.Location = new System.Drawing.Point(856, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(79, 75);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "可供情况";
            // 
            // m_rbtAllProvide
            // 
            this.m_rbtAllProvide.AutoSize = true;
            this.m_rbtAllProvide.Checked = true;
            this.m_rbtAllProvide.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_rbtAllProvide.Location = new System.Drawing.Point(6, 13);
            this.m_rbtAllProvide.Name = "m_rbtAllProvide";
            this.m_rbtAllProvide.Size = new System.Drawing.Size(53, 18);
            this.m_rbtAllProvide.TabIndex = 0;
            this.m_rbtAllProvide.TabStop = true;
            this.m_rbtAllProvide.Text = "全部";
            this.m_rbtAllProvide.UseVisualStyleBackColor = true;
            this.m_rbtAllProvide.CheckedChanged += new System.EventHandler(this.m_rdbNotZero_CheckedChanged);
            // 
            // m_rbtCanProvide
            // 
            this.m_rbtCanProvide.AutoSize = true;
            this.m_rbtCanProvide.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_rbtCanProvide.Location = new System.Drawing.Point(6, 34);
            this.m_rbtCanProvide.Name = "m_rbtCanProvide";
            this.m_rbtCanProvide.Size = new System.Drawing.Size(53, 18);
            this.m_rbtCanProvide.TabIndex = 1;
            this.m_rbtCanProvide.Text = "可供";
            this.m_rbtCanProvide.UseVisualStyleBackColor = true;
            this.m_rbtCanProvide.CheckedChanged += new System.EventHandler(this.m_rdbNotZero_CheckedChanged);
            // 
            // m_rbtNotProvide
            // 
            this.m_rbtNotProvide.AutoSize = true;
            this.m_rbtNotProvide.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_rbtNotProvide.Location = new System.Drawing.Point(6, 55);
            this.m_rbtNotProvide.Name = "m_rbtNotProvide";
            this.m_rbtNotProvide.Size = new System.Drawing.Size(67, 18);
            this.m_rbtNotProvide.TabIndex = 2;
            this.m_rbtNotProvide.Text = "不可供";
            this.m_rbtNotProvide.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.m_rdbNotZero);
            this.groupBox1.Controls.Add(this.m_rbtAll);
            this.groupBox1.Controls.Add(this.m_rbtNegative);
            this.groupBox1.Controls.Add(this.m_rdbZero);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 9F);
            this.groupBox1.Location = new System.Drawing.Point(727, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(129, 75);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "库存情况";
            // 
            // m_rdbNotZero
            // 
            this.m_rdbNotZero.AutoSize = true;
            this.m_rdbNotZero.Checked = true;
            this.m_rdbNotZero.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_rdbNotZero.Location = new System.Drawing.Point(7, 16);
            this.m_rdbNotZero.Name = "m_rdbNotZero";
            this.m_rdbNotZero.Size = new System.Drawing.Size(67, 18);
            this.m_rdbNotZero.TabIndex = 0;
            this.m_rdbNotZero.TabStop = true;
            this.m_rdbNotZero.Text = "不为零";
            this.m_rdbNotZero.UseVisualStyleBackColor = true;
            this.m_rdbNotZero.CheckedChanged += new System.EventHandler(this.m_rdbNotZero_CheckedChanged);
            // 
            // m_rbtAll
            // 
            this.m_rbtAll.AutoSize = true;
            this.m_rbtAll.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_rbtAll.Location = new System.Drawing.Point(75, 44);
            this.m_rbtAll.Name = "m_rbtAll";
            this.m_rbtAll.Size = new System.Drawing.Size(53, 18);
            this.m_rbtAll.TabIndex = 2;
            this.m_rbtAll.Text = "全部";
            this.m_rbtAll.UseVisualStyleBackColor = true;
            // 
            // m_rbtNegative
            // 
            this.m_rbtNegative.AutoSize = true;
            this.m_rbtNegative.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_rbtNegative.Location = new System.Drawing.Point(7, 44);
            this.m_rbtNegative.Name = "m_rbtNegative";
            this.m_rbtNegative.Size = new System.Drawing.Size(67, 18);
            this.m_rbtNegative.TabIndex = 2;
            this.m_rbtNegative.Text = "为负数";
            this.m_rbtNegative.UseVisualStyleBackColor = true;
            this.m_rbtNegative.CheckedChanged += new System.EventHandler(this.m_rdbNotZero_CheckedChanged);
            // 
            // m_rdbZero
            // 
            this.m_rdbZero.AutoSize = true;
            this.m_rdbZero.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_rdbZero.Location = new System.Drawing.Point(75, 16);
            this.m_rdbZero.Name = "m_rdbZero";
            this.m_rdbZero.Size = new System.Drawing.Size(53, 18);
            this.m_rdbZero.TabIndex = 1;
            this.m_rdbZero.Text = "为零";
            this.m_rdbZero.UseVisualStyleBackColor = true;
            this.m_rdbZero.CheckedChanged += new System.EventHandler(this.m_rdbNotZero_CheckedChanged);
            // 
            // m_txtMedicineCode
            // 
            this.m_txtMedicineCode.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtMedicineCode.Location = new System.Drawing.Point(66, 37);
            this.m_txtMedicineCode.Name = "m_txtMedicineCode";
            this.m_txtMedicineCode.Size = new System.Drawing.Size(265, 23);
            this.m_txtMedicineCode.TabIndex = 4;
            this.m_txtMedicineCode.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_txtMedicineCode_MouseDown);
            this.m_txtMedicineCode.TextChanged += new System.EventHandler(this.m_txtMedicineCode_TextChanged);
            this.m_txtMedicineCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtMedicineCode_KeyDown);
            // 
            // lblLeechdom
            // 
            this.lblLeechdom.AutoSize = true;
            this.lblLeechdom.BackColor = System.Drawing.Color.Transparent;
            this.lblLeechdom.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLeechdom.Location = new System.Drawing.Point(12, 41);
            this.lblLeechdom.Name = "lblLeechdom";
            this.lblLeechdom.Size = new System.Drawing.Size(35, 14);
            this.lblLeechdom.TabIndex = 23;
            this.lblLeechdom.Text = "药品";
            // 
            // m_chkValidDate
            // 
            this.m_chkValidDate.AutoSize = true;
            this.m_chkValidDate.BackColor = System.Drawing.Color.Transparent;
            this.m_chkValidDate.Location = new System.Drawing.Point(3, 9);
            this.m_chkValidDate.Name = "m_chkValidDate";
            this.m_chkValidDate.Size = new System.Drawing.Size(68, 18);
            this.m_chkValidDate.TabIndex = 0;
            this.m_chkValidDate.Text = "失效期";
            this.m_chkValidDate.UseVisualStyleBackColor = false;
            this.m_chkValidDate.CheckedChanged += new System.EventHandler(this.m_chkValidDate_CheckedChanged);
            // 
            // m_lblWholesaleSum
            // 
            this.m_lblWholesaleSum.AutoSize = true;
            this.m_lblWholesaleSum.BackColor = System.Drawing.Color.Transparent;
            this.m_lblWholesaleSum.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblWholesaleSum.Location = new System.Drawing.Point(993, 21);
            this.m_lblWholesaleSum.Name = "m_lblWholesaleSum";
            this.m_lblWholesaleSum.Size = new System.Drawing.Size(35, 14);
            this.m_lblWholesaleSum.TabIndex = 40;
            this.m_lblWholesaleSum.Text = "0.00";
            this.m_lblWholesaleSum.Visible = false;
            // 
            // m_lblCallSum
            // 
            this.m_lblCallSum.AutoSize = true;
            this.m_lblCallSum.BackColor = System.Drawing.Color.Transparent;
            this.m_lblCallSum.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblCallSum.Location = new System.Drawing.Point(982, 5);
            this.m_lblCallSum.Name = "m_lblCallSum";
            this.m_lblCallSum.Size = new System.Drawing.Size(35, 14);
            this.m_lblCallSum.TabIndex = 38;
            this.m_lblCallSum.Text = "0.00";
            this.m_lblCallSum.Visible = false;
            // 
            // lblWholesaleSumCaption
            // 
            this.lblWholesaleSumCaption.AutoSize = true;
            this.lblWholesaleSumCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblWholesaleSumCaption.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWholesaleSumCaption.Location = new System.Drawing.Point(910, 21);
            this.lblWholesaleSumCaption.Name = "lblWholesaleSumCaption";
            this.lblWholesaleSumCaption.Size = new System.Drawing.Size(77, 14);
            this.lblWholesaleSumCaption.TabIndex = 37;
            this.lblWholesaleSumCaption.Text = "批发金额：";
            this.lblWholesaleSumCaption.Visible = false;
            // 
            // lblCallSumCaption
            // 
            this.lblCallSumCaption.AutoSize = true;
            this.lblCallSumCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblCallSumCaption.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCallSumCaption.Location = new System.Drawing.Point(912, 5);
            this.lblCallSumCaption.Name = "lblCallSumCaption";
            this.lblCallSumCaption.Size = new System.Drawing.Size(77, 14);
            this.lblCallSumCaption.TabIndex = 35;
            this.lblCallSumCaption.Text = "购入金额：";
            this.lblCallSumCaption.Visible = false;
            // 
            // m_cboStorage
            // 
            this.m_cboStorage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboStorage.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_cboStorage.FormattingEnabled = true;
            this.m_cboStorage.Location = new System.Drawing.Point(654, 6);
            this.m_cboStorage.Name = "m_cboStorage";
            this.m_cboStorage.Size = new System.Drawing.Size(119, 22);
            this.m_cboStorage.TabIndex = 0;
            this.m_cboStorage.Visible = false;
            this.m_cboStorage.SelectedIndexChanged += new System.EventHandler(this.m_cboStorage_SelectedIndexChanged);
            // 
            // lblStorage
            // 
            this.lblStorage.AutoSize = true;
            this.lblStorage.BackColor = System.Drawing.Color.Transparent;
            this.lblStorage.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStorage.Location = new System.Drawing.Point(600, 9);
            this.lblStorage.Name = "lblStorage";
            this.lblStorage.Size = new System.Drawing.Size(35, 14);
            this.lblStorage.TabIndex = 21;
            this.lblStorage.Text = "药房";
            this.lblStorage.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_btnQuery,
            this.toolStripSeparator3,
            this.m_btnLocate,
            this.toolStripSeparator6,
            this.m_btnSave,
            this.toolStripSeparator2,
            this.m_btnPrint,
            this.toolStripSeparator8,
            this.m_btnExport,
            this.toolStripSeparator1,
            this.m_btnExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1016, 38);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // m_btnQuery
            // 
            this.m_btnQuery.AutoSize = false;
            this.m_btnQuery.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnQuery.Image = ((System.Drawing.Image)(resources.GetObject("m_btnQuery.Image")));
            this.m_btnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_btnQuery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnQuery.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_btnQuery.Name = "m_btnQuery";
            this.m_btnQuery.Size = new System.Drawing.Size(80, 33);
            this.m_btnQuery.Text = "查询(&F)";
            this.m_btnQuery.Click += new System.EventHandler(this.m_btnQuery_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // m_btnLocate
            // 
            this.m_btnLocate.Image = ((System.Drawing.Image)(resources.GetObject("m_btnLocate.Image")));
            this.m_btnLocate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_btnLocate.Name = "m_btnLocate";
            this.m_btnLocate.Size = new System.Drawing.Size(76, 35);
            this.m_btnLocate.Text = "定位(&L)";
            this.m_btnLocate.Click += new System.EventHandler(this.m_btnLocate_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 38);
            // 
            // m_btnSave
            // 
            this.m_btnSave.Image = ((System.Drawing.Image)(resources.GetObject("m_btnSave.Image")));
            this.m_btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Size = new System.Drawing.Size(76, 35);
            this.m_btnSave.Text = "保存(&S)";
            this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // m_btnPrint
            // 
            this.m_btnPrint.AutoSize = false;
            this.m_btnPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("m_btnPrint.Image")));
            this.m_btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_btnPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnPrint.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_btnPrint.Name = "m_btnPrint";
            this.m_btnPrint.Size = new System.Drawing.Size(80, 32);
            this.m_btnPrint.Text = "打印(&P)";
            this.m_btnPrint.Click += new System.EventHandler(this.m_btnPrint_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 38);
            // 
            // m_btnExport
            // 
            this.m_btnExport.Image = ((System.Drawing.Image)(resources.GetObject("m_btnExport.Image")));
            this.m_btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_btnExport.Name = "m_btnExport";
            this.m_btnExport.Size = new System.Drawing.Size(76, 35);
            this.m_btnExport.Text = "导出(&O)";
            this.m_btnExport.Click += new System.EventHandler(this.m_btnExport_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // m_btnExit
            // 
            this.m_btnExit.AutoSize = false;
            this.m_btnExit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnExit.Image = ((System.Drawing.Image)(resources.GetObject("m_btnExit.Image")));
            this.m_btnExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnExit.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_btnExit.Name = "m_btnExit";
            this.m_btnExit.Size = new System.Drawing.Size(80, 33);
            this.m_btnExit.Text = "关闭(&Q)";
            this.m_btnExit.Click += new System.EventHandler(this.m_btnExit_Click);
            // 
            // frmDrugStorageQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 753);
            this.Controls.Add(this.gradientPanel1);
            this.Controls.Add(this.lblStorage);
            this.Controls.Add(this.m_lblWholesaleSum);
            this.Controls.Add(this.m_lblCallSum);
            this.Controls.Add(this.m_cboStorage);
            this.Controls.Add(this.lblWholesaleSumCaption);
            this.Controls.Add(this.lblCallSumCaption);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.m_dgvDrugStorage);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDrugStorageQuery";
            this.Text = "药房库存查询";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDrugStorageQuery_FormClosed);
            this.Load += new System.EventHandler(this.frmDrugStorageQuery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvDrugStorage)).EndInit();
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        internal System.Windows.Forms.ToolStripButton m_btnPrint;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton m_btnExport;
        private System.Windows.Forms.ToolStripButton m_btnExit;
        private System.Windows.Forms.Label lblWholesaleSumCaption;
        private System.Windows.Forms.Label lblRetailSumCaption;
        private System.Windows.Forms.Label lblCallSumCaption;
        private System.Windows.Forms.Label lblJx;
        private System.Windows.Forms.Label lblList;
        private System.Windows.Forms.Label lblAbateEndDate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblStorage;
        private System.Windows.Forms.Label lblLeechdom;
        internal System.Windows.Forms.Label m_lblWholesaleSum;
        internal System.Windows.Forms.Label m_lblRetailSum;
        internal System.Windows.Forms.Label m_lblCallSum;
        internal exComboBox m_cboStorage;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker m_datEndDate;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker m_datBeginDate;
        internal System.Windows.Forms.ComboBox m_cboMedicineType;
        internal System.Windows.Forms.Label m_lblRecordNo;
        internal System.Windows.Forms.RadioButton m_rdbDetail;
        internal System.Windows.Forms.RadioButton m_rdbTotal;
        internal System.Windows.Forms.RadioButton m_rdbNotZero;
        internal System.Windows.Forms.RadioButton m_rdbZero;
        internal System.Windows.Forms.TextBox m_txtMedicineCode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        internal GradientPanel gradientPanel1;
        internal System.Windows.Forms.DataGridView m_dgvDrugStorage;
        private System.Windows.Forms.ToolStripButton m_btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton m_btnLocate;
        internal System.Windows.Forms.CheckBox m_chkValidDate;
        private System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.RadioButton m_rbtCanProvide;
        internal System.Windows.Forms.RadioButton m_rbtNotProvide;
        internal System.Windows.Forms.RadioButton m_rbtAllProvide;
        internal System.Windows.Forms.RadioButton m_rbtNegative;
        internal System.Windows.Forms.RadioButton m_rbtAll;
        internal System.Windows.Forms.TextBox m_txtProductor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.ListBox m_lsbMediciePreptype;
        internal System.Windows.Forms.ToolStripButton m_btnQuery;
    }
}