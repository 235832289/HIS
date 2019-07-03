namespace com.digitalwave.iCare.gui.MedicineStore
{
    partial class frmStorageQuery
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStorageQuery));
            this.dtgLeechdomList = new System.Windows.Forms.DataGridView();
            this.cmdExit = new System.Windows.Forms.Button();
            this.cmdPrint = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radZeroStorage = new System.Windows.Forms.RadioButton();
            this.cboStorage = new System.Windows.Forms.ComboBox();
            this.txtAbateEndDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker();
            this.txtAbateBeginDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker();
            this.cboMedicineType = new System.Windows.Forms.ComboBox();
            this.lblJx = new System.Windows.Forms.Label();
            this.lblAbateEndDate = new System.Windows.Forms.Label();
            this.lblAbateBeginDate = new System.Windows.Forms.Label();
            this.m_txtMedicineCode = new System.Windows.Forms.TextBox();
            this.lblLeechdom = new System.Windows.Forms.Label();
            this.lblStorage = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbList = new System.Windows.Forms.RadioButton();
            this.rdbStat = new System.Windows.Forms.RadioButton();
            this.lblList = new System.Windows.Forms.Label();
            this.lblRecordNo = new System.Windows.Forms.Label();
            this.cmdQuery = new System.Windows.Forms.Button();
            this.lblCallSumCaption = new System.Windows.Forms.Label();
            this.lblRetailSumCaption = new System.Windows.Forms.Label();
            this.lblWholesaleSumCaption = new System.Windows.Forms.Label();
            this.lblCallSum = new System.Windows.Forms.Label();
            this.lblRetailSum = new System.Windows.Forms.Label();
            this.lblWholesaleSum = new System.Windows.Forms.Label();
            this.m_cmdExport = new System.Windows.Forms.Button();
            this.m_btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLeechdomList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgLeechdomList
            // 
            this.dtgLeechdomList.AllowUserToAddRows = false;
            this.dtgLeechdomList.AllowUserToDeleteRows = false;
            this.dtgLeechdomList.AllowUserToResizeRows = false;
            this.dtgLeechdomList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgLeechdomList.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dtgLeechdomList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgLeechdomList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgLeechdomList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgLeechdomList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgLeechdomList.Location = new System.Drawing.Point(11, 171);
            this.dtgLeechdomList.MultiSelect = false;
            this.dtgLeechdomList.Name = "dtgLeechdomList";
            this.dtgLeechdomList.RowHeadersVisible = false;
            this.dtgLeechdomList.RowTemplate.Height = 23;
            this.dtgLeechdomList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgLeechdomList.Size = new System.Drawing.Size(1007, 523);
            this.dtgLeechdomList.StandardTab = true;
            this.dtgLeechdomList.TabIndex = 8;
            this.dtgLeechdomList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dtgLeechdomList_MouseClick);
            this.dtgLeechdomList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgLeechdomList_CellValueChanged);
            this.dtgLeechdomList.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgLeechdomList_DataError);
            this.dtgLeechdomList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dtgLeechdomList_KeyUp);
            // 
            // cmdExit
            // 
            this.cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdExit.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cmdExit.Image = ((System.Drawing.Image)(resources.GetObject("cmdExit.Image")));
            this.cmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdExit.Location = new System.Drawing.Point(919, 3);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(94, 32);
            this.cmdExit.TabIndex = 11;
            this.cmdExit.TabStop = false;
            this.cmdExit.Text = "退出(&Q)";
            this.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // cmdPrint
            // 
            this.cmdPrint.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdPrint.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPrint.ImageIndex = 6;
            this.cmdPrint.ImageList = this.imageList1;
            this.cmdPrint.Location = new System.Drawing.Point(105, 3);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(94, 32);
            this.cmdPrint.TabIndex = 10;
            this.cmdPrint.TabStop = false;
            this.cmdPrint.Text = "打印(&P)";
            this.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdPrint.UseVisualStyleBackColor = false;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Shell32 007.ico");
            this.imageList1.Images.SetKeyName(1, "Shell32 028.ico");
            this.imageList1.Images.SetKeyName(2, "Shell32 132.ico");
            this.imageList1.Images.SetKeyName(3, "Shell32 148.ico");
            this.imageList1.Images.SetKeyName(4, "Shell32 058.ico");
            this.imageList1.Images.SetKeyName(5, "m_cmdRefresh.Image.png");
            this.imageList1.Images.SetKeyName(6, "Shell32 137.ico");
            this.imageList1.Images.SetKeyName(7, "Shell32 177.ico");
            this.imageList1.Images.SetKeyName(8, "Shell32 136.ico");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radZeroStorage);
            this.groupBox1.Controls.Add(this.cboStorage);
            this.groupBox1.Controls.Add(this.txtAbateEndDate);
            this.groupBox1.Controls.Add(this.txtAbateBeginDate);
            this.groupBox1.Controls.Add(this.cboMedicineType);
            this.groupBox1.Controls.Add(this.lblJx);
            this.groupBox1.Controls.Add(this.lblAbateEndDate);
            this.groupBox1.Controls.Add(this.lblAbateBeginDate);
            this.groupBox1.Controls.Add(this.m_txtMedicineCode);
            this.groupBox1.Controls.Add(this.lblLeechdom);
            this.groupBox1.Controls.Add(this.lblStorage);
            this.groupBox1.Location = new System.Drawing.Point(12, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(810, 106);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(585, 51);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(123, 18);
            this.radioButton1.TabIndex = 30;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "当前库存不为零";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            this.radioButton1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.radioButton1_MouseUp);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(585, 75);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(179, 18);
            this.radioButton2.TabIndex = 29;
            this.radioButton2.Text = "显示当前帐务期库存为零";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            this.radioButton2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.radioButton2_MouseUp);
            // 
            // radZeroStorage
            // 
            this.radZeroStorage.AutoSize = true;
            this.radZeroStorage.Location = new System.Drawing.Point(709, 51);
            this.radZeroStorage.Name = "radZeroStorage";
            this.radZeroStorage.Size = new System.Drawing.Size(95, 18);
            this.radZeroStorage.TabIndex = 28;
            this.radZeroStorage.Text = "显示零库存";
            this.radZeroStorage.UseVisualStyleBackColor = true;
            this.radZeroStorage.CheckedChanged += new System.EventHandler(this.radZeroStorage_CheckedChanged);
            this.radZeroStorage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chkZeroStorage_MouseUp);
            // 
            // cboStorage
            // 
            this.cboStorage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStorage.FormattingEnabled = true;
            this.cboStorage.Location = new System.Drawing.Point(68, 19);
            this.cboStorage.Name = "cboStorage";
            this.cboStorage.Size = new System.Drawing.Size(215, 22);
            this.cboStorage.TabIndex = 0;
            this.cboStorage.SelectedIndexChanged += new System.EventHandler(this.cboStorage_SelectedIndexChanged);
            this.cboStorage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboStorage_KeyDown);
            // 
            // txtAbateEndDate
            // 
            this.txtAbateEndDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtAbateEndDate.Location = new System.Drawing.Point(603, 19);
            this.txtAbateEndDate.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日;
            this.txtAbateEndDate.Mask = "0000年90月90日";
            this.txtAbateEndDate.Name = "txtAbateEndDate";
            this.txtAbateEndDate.Size = new System.Drawing.Size(149, 23);
            this.txtAbateEndDate.TabIndex = 2;
            this.txtAbateEndDate.ValidatingType = typeof(System.DateTime);
            this.txtAbateEndDate.Enter += new System.EventHandler(this.txtAbateEndDate_Enter);
            this.txtAbateEndDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAbateEndDate_KeyDown);
            // 
            // txtAbateBeginDate
            // 
            this.txtAbateBeginDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtAbateBeginDate.Location = new System.Drawing.Point(388, 19);
            this.txtAbateBeginDate.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日;
            this.txtAbateBeginDate.Mask = "0000年90月90日";
            this.txtAbateBeginDate.Name = "txtAbateBeginDate";
            this.txtAbateBeginDate.Size = new System.Drawing.Size(149, 23);
            this.txtAbateBeginDate.TabIndex = 1;
            this.txtAbateBeginDate.ValidatingType = typeof(System.DateTime);
            this.txtAbateBeginDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAbateBeginDate_KeyDown);
            // 
            // cboMedicineType
            // 
            this.cboMedicineType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMedicineType.FormattingEnabled = true;
            this.cboMedicineType.Location = new System.Drawing.Point(388, 63);
            this.cboMedicineType.Name = "cboMedicineType";
            this.cboMedicineType.Size = new System.Drawing.Size(179, 22);
            this.cboMedicineType.TabIndex = 4;
            this.cboMedicineType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboMedicineType_KeyDown);
            // 
            // lblJx
            // 
            this.lblJx.AutoSize = true;
            this.lblJx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblJx.Location = new System.Drawing.Point(311, 69);
            this.lblJx.Name = "lblJx";
            this.lblJx.Size = new System.Drawing.Size(63, 14);
            this.lblJx.TabIndex = 27;
            this.lblJx.Text = "药品类型";
            // 
            // lblAbateEndDate
            // 
            this.lblAbateEndDate.AutoSize = true;
            this.lblAbateEndDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAbateEndDate.Location = new System.Drawing.Point(561, 24);
            this.lblAbateEndDate.Name = "lblAbateEndDate";
            this.lblAbateEndDate.Size = new System.Drawing.Size(21, 14);
            this.lblAbateEndDate.TabIndex = 26;
            this.lblAbateEndDate.Text = "至";
            // 
            // lblAbateBeginDate
            // 
            this.lblAbateBeginDate.AutoSize = true;
            this.lblAbateBeginDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAbateBeginDate.Location = new System.Drawing.Point(311, 24);
            this.lblAbateBeginDate.Name = "lblAbateBeginDate";
            this.lblAbateBeginDate.Size = new System.Drawing.Size(49, 14);
            this.lblAbateBeginDate.TabIndex = 25;
            this.lblAbateBeginDate.Text = "失效期";
            // 
            // m_txtMedicineCode
            // 
            this.m_txtMedicineCode.Location = new System.Drawing.Point(68, 63);
            this.m_txtMedicineCode.Name = "m_txtMedicineCode";
            this.m_txtMedicineCode.Size = new System.Drawing.Size(215, 23);
            this.m_txtMedicineCode.TabIndex = 3;
            this.m_txtMedicineCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.m_txtMedicineCode_KeyUp);
            // 
            // lblLeechdom
            // 
            this.lblLeechdom.AutoSize = true;
            this.lblLeechdom.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLeechdom.Location = new System.Drawing.Point(20, 69);
            this.lblLeechdom.Name = "lblLeechdom";
            this.lblLeechdom.Size = new System.Drawing.Size(35, 14);
            this.lblLeechdom.TabIndex = 23;
            this.lblLeechdom.Text = "药品";
            // 
            // lblStorage
            // 
            this.lblStorage.AutoSize = true;
            this.lblStorage.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStorage.Location = new System.Drawing.Point(20, 24);
            this.lblStorage.Name = "lblStorage";
            this.lblStorage.Size = new System.Drawing.Size(35, 14);
            this.lblStorage.TabIndex = 21;
            this.lblStorage.Text = "仓库";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.rdbList);
            this.groupBox2.Controls.Add(this.rdbStat);
            this.groupBox2.Location = new System.Drawing.Point(828, 37);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(185, 106);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // rdbList
            // 
            this.rdbList.AutoSize = true;
            this.rdbList.Checked = true;
            this.rdbList.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbList.Location = new System.Drawing.Point(22, 65);
            this.rdbList.Name = "rdbList";
            this.rdbList.Size = new System.Drawing.Size(53, 18);
            this.rdbList.TabIndex = 7;
            this.rdbList.TabStop = true;
            this.rdbList.Text = "明细";
            this.rdbList.UseVisualStyleBackColor = true;
            this.rdbList.CheckedChanged += new System.EventHandler(this.rdbList_CheckedChanged);
            this.rdbList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rdbList_MouseUp);
            this.rdbList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rdbList_KeyDown);
            // 
            // rdbStat
            // 
            this.rdbStat.AutoSize = true;
            this.rdbStat.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbStat.Location = new System.Drawing.Point(22, 30);
            this.rdbStat.Name = "rdbStat";
            this.rdbStat.Size = new System.Drawing.Size(53, 18);
            this.rdbStat.TabIndex = 6;
            this.rdbStat.TabStop = true;
            this.rdbStat.Text = "统计";
            this.rdbStat.UseVisualStyleBackColor = true;
            this.rdbStat.CheckedChanged += new System.EventHandler(this.rdbStat_CheckedChanged);
            this.rdbStat.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rdbStat_MouseUp);
            this.rdbStat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rdbStat_KeyDown);
            // 
            // lblList
            // 
            this.lblList.AutoSize = true;
            this.lblList.Font = new System.Drawing.Font("宋体", 10.5F);
            this.lblList.Location = new System.Drawing.Point(13, 146);
            this.lblList.Name = "lblList";
            this.lblList.Size = new System.Drawing.Size(105, 14);
            this.lblList.TabIndex = 23;
            this.lblList.Text = "药品统计列表：";
            // 
            // lblRecordNo
            // 
            this.lblRecordNo.Location = new System.Drawing.Point(121, 146);
            this.lblRecordNo.Name = "lblRecordNo";
            this.lblRecordNo.Size = new System.Drawing.Size(122, 12);
            this.lblRecordNo.TabIndex = 24;
            this.lblRecordNo.Text = "０/０";
            // 
            // cmdQuery
            // 
            this.cmdQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdQuery.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cmdQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdQuery.ImageIndex = 5;
            this.cmdQuery.ImageList = this.imageList1;
            this.cmdQuery.Location = new System.Drawing.Point(11, 3);
            this.cmdQuery.Name = "cmdQuery";
            this.cmdQuery.Size = new System.Drawing.Size(94, 32);
            this.cmdQuery.TabIndex = 9;
            this.cmdQuery.Text = "查询(&A)";
            this.cmdQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdQuery.UseVisualStyleBackColor = true;
            this.cmdQuery.Click += new System.EventHandler(this.cmdQuery_Click);
            // 
            // lblCallSumCaption
            // 
            this.lblCallSumCaption.AutoSize = true;
            this.lblCallSumCaption.Location = new System.Drawing.Point(262, 146);
            this.lblCallSumCaption.Name = "lblCallSumCaption";
            this.lblCallSumCaption.Size = new System.Drawing.Size(77, 14);
            this.lblCallSumCaption.TabIndex = 25;
            this.lblCallSumCaption.Text = "购入金额：";
            // 
            // lblRetailSumCaption
            // 
            this.lblRetailSumCaption.AutoSize = true;
            this.lblRetailSumCaption.Location = new System.Drawing.Point(495, 146);
            this.lblRetailSumCaption.Name = "lblRetailSumCaption";
            this.lblRetailSumCaption.Size = new System.Drawing.Size(77, 14);
            this.lblRetailSumCaption.TabIndex = 26;
            this.lblRetailSumCaption.Text = "零售金额：";
            // 
            // lblWholesaleSumCaption
            // 
            this.lblWholesaleSumCaption.AutoSize = true;
            this.lblWholesaleSumCaption.Location = new System.Drawing.Point(721, 146);
            this.lblWholesaleSumCaption.Name = "lblWholesaleSumCaption";
            this.lblWholesaleSumCaption.Size = new System.Drawing.Size(77, 14);
            this.lblWholesaleSumCaption.TabIndex = 27;
            this.lblWholesaleSumCaption.Text = "批发金额：";
            // 
            // lblCallSum
            // 
            this.lblCallSum.AutoSize = true;
            this.lblCallSum.Location = new System.Drawing.Point(345, 146);
            this.lblCallSum.Name = "lblCallSum";
            this.lblCallSum.Size = new System.Drawing.Size(35, 14);
            this.lblCallSum.TabIndex = 28;
            this.lblCallSum.Text = "0.00";
            // 
            // lblRetailSum
            // 
            this.lblRetailSum.AutoSize = true;
            this.lblRetailSum.Location = new System.Drawing.Point(575, 146);
            this.lblRetailSum.Name = "lblRetailSum";
            this.lblRetailSum.Size = new System.Drawing.Size(35, 14);
            this.lblRetailSum.TabIndex = 29;
            this.lblRetailSum.Text = "0.00";
            // 
            // lblWholesaleSum
            // 
            this.lblWholesaleSum.AutoSize = true;
            this.lblWholesaleSum.Location = new System.Drawing.Point(801, 146);
            this.lblWholesaleSum.Name = "lblWholesaleSum";
            this.lblWholesaleSum.Size = new System.Drawing.Size(35, 14);
            this.lblWholesaleSum.TabIndex = 30;
            this.lblWholesaleSum.Text = "0.00";
            // 
            // m_cmdExport
            // 
            this.m_cmdExport.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdExport.ImageIndex = 7;
            this.m_cmdExport.ImageList = this.imageList1;
            this.m_cmdExport.Location = new System.Drawing.Point(297, 3);
            this.m_cmdExport.Name = "m_cmdExport";
            this.m_cmdExport.Size = new System.Drawing.Size(98, 32);
            this.m_cmdExport.TabIndex = 51;
            this.m_cmdExport.Text = "导出(&E)";
            this.m_cmdExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdExport.UseVisualStyleBackColor = true;
            this.m_cmdExport.Click += new System.EventHandler(this.m_cmdExport_Click);
            // 
            // m_btnSave
            // 
            this.m_btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnSave.Image = ((System.Drawing.Image)(resources.GetObject("m_btnSave.Image")));
            this.m_btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_btnSave.Location = new System.Drawing.Point(199, 3);
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Size = new System.Drawing.Size(98, 32);
            this.m_btnSave.TabIndex = 52;
            this.m_btnSave.Text = "保存(&S)";
            this.m_btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_btnSave.UseVisualStyleBackColor = true;
            this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
            // 
            // frmStorageQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 703);
            this.Controls.Add(this.m_btnSave);
            this.Controls.Add(this.m_cmdExport);
            this.Controls.Add(this.lblWholesaleSum);
            this.Controls.Add(this.lblRetailSum);
            this.Controls.Add(this.lblCallSum);
            this.Controls.Add(this.lblWholesaleSumCaption);
            this.Controls.Add(this.lblRetailSumCaption);
            this.Controls.Add(this.lblCallSumCaption);
            this.Controls.Add(this.cmdQuery);
            this.Controls.Add(this.lblRecordNo);
            this.Controls.Add(this.lblList);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.cmdPrint);
            this.Controls.Add(this.dtgLeechdomList);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "frmStorageQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "药品库存查询";
            this.SizeChanged += new System.EventHandler(this.frmStorageQusery_SizeChanged);
            this.Shown += new System.EventHandler(this.frmStorageQusery_Shown);
            this.Load += new System.EventHandler(this.frmStorageQusery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgLeechdomList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgLeechdomList;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Button cmdPrint;
        private System.Windows.Forms.GroupBox groupBox1;
        private com.digitalwave.Controls.ctlMaskedDateTimePicker txtAbateEndDate;
        private com.digitalwave.Controls.ctlMaskedDateTimePicker txtAbateBeginDate;
        private System.Windows.Forms.ComboBox cboMedicineType;
        private System.Windows.Forms.Label lblJx;
        private System.Windows.Forms.Label lblAbateEndDate;
        private System.Windows.Forms.Label lblAbateBeginDate;
        private System.Windows.Forms.TextBox m_txtMedicineCode;
        private System.Windows.Forms.Label lblLeechdom;
        private System.Windows.Forms.Label lblStorage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbList;
        private System.Windows.Forms.RadioButton rdbStat;
        private System.Windows.Forms.Label lblList;
        private System.Windows.Forms.Label lblRecordNo;
        private System.Windows.Forms.ComboBox cboStorage;
        private System.Windows.Forms.Button cmdQuery;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblCallSumCaption;
        private System.Windows.Forms.Label lblRetailSumCaption;
        private System.Windows.Forms.Label lblWholesaleSumCaption;
        private System.Windows.Forms.Label lblCallSum;
        private System.Windows.Forms.Label lblRetailSum;
        private System.Windows.Forms.Label lblWholesaleSum;
        private System.Windows.Forms.Button m_cmdExport;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radZeroStorage;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button m_btnSave;
    }
}