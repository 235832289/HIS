namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    partial class frmRecipeMedicineDetailReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecipeMedicineDetailReport));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.m_btnQuery = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnPreview = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnExport = new System.Windows.Forms.ToolStripLabel();
            this.m_btnExit = new System.Windows.Forms.ToolStripButton();
            this.gradientPanel2 = new com.digitalwave.iCare.gui.MedicineStore.GradientPanel();
            this.m_cboStorageName = new exComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_txtMedicineCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.m_dtpSearchBeginDate = new System.Windows.Forms.DateTimePicker();
            this.m_dtpSearchEndDate = new System.Windows.Forms.DateTimePicker();
            this.dw = new Sybase.DataWindow.DataWindowControl();
            this.m_dgvMedDetail = new System.Windows.Forms.DataGridView();
            this.m_lblPriceSum = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.m_dgvtxtoperatedate_dat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtpatientcardid_chr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtlastname_vchr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtoldgross_int = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtretailprice_int = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtsumprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtsharer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtwithdrawer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvSortRowNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.gradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvMedDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_btnQuery,
            this.toolStripSeparator4,
            this.m_btnPreview,
            this.toolStripSeparator2,
            this.m_btnPrint,
            this.toolStripSeparator1,
            this.toolStripSeparator3,
            this.m_btnExport,
            this.m_btnExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(1012, 38);
            this.toolStrip1.TabIndex = 10058;
            this.toolStrip1.Text = "toolStrip1";
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
            this.m_btnQuery.Size = new System.Drawing.Size(90, 35);
            this.m_btnQuery.Text = "查 询(&Q)";
            this.m_btnQuery.Click += new System.EventHandler(this.m_cmdSearch_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 38);
            // 
            // m_btnPreview
            // 
            this.m_btnPreview.AutoSize = false;
            this.m_btnPreview.Image = ((System.Drawing.Image)(resources.GetObject("m_btnPreview.Image")));
            this.m_btnPreview.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnPreview.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.m_btnPreview.Name = "m_btnPreview";
            this.m_btnPreview.Size = new System.Drawing.Size(90, 35);
            this.m_btnPreview.Text = "预 览(&V)";
            this.m_btnPreview.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_btnPreview.Click += new System.EventHandler(this.m_cmdPreview_Click);
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
            this.m_btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_btnPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnPrint.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_btnPrint.Name = "m_btnPrint";
            this.m_btnPrint.Size = new System.Drawing.Size(90, 35);
            this.m_btnPrint.Text = "打 印(&P)";
            this.m_btnPrint.Click += new System.EventHandler(this.m_cmdPrint_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // m_btnExport
            // 
            this.m_btnExport.AutoSize = false;
            this.m_btnExport.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnExport.Image = ((System.Drawing.Image)(resources.GetObject("m_btnExport.Image")));
            this.m_btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_btnExport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnExport.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_btnExport.Name = "m_btnExport";
            this.m_btnExport.Size = new System.Drawing.Size(90, 35);
            this.m_btnExport.Text = "导 出(&E)";
            this.m_btnExport.Click += new System.EventHandler(this.m_cmdExport_Click);
            // 
            // m_btnExit
            // 
            this.m_btnExit.AutoSize = false;
            this.m_btnExit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnExit.Image = ((System.Drawing.Image)(resources.GetObject("m_btnExit.Image")));
            this.m_btnExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnExit.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_btnExit.Name = "m_btnExit";
            this.m_btnExit.Size = new System.Drawing.Size(90, 35);
            this.m_btnExit.Text = "关 闭(&C)";
            this.m_btnExit.Click += new System.EventHandler(this.m_cmdExit_Click);
            // 
            // gradientPanel2
            // 
            this.gradientPanel2.Controls.Add(this.m_cboStorageName);
            this.gradientPanel2.Controls.Add(this.label6);
            this.gradientPanel2.Controls.Add(this.m_txtMedicineCode);
            this.gradientPanel2.Controls.Add(this.label1);
            this.gradientPanel2.Controls.Add(this.label15);
            this.gradientPanel2.Controls.Add(this.label8);
            this.gradientPanel2.Controls.Add(this.m_dtpSearchBeginDate);
            this.gradientPanel2.Controls.Add(this.m_dtpSearchEndDate);
            this.gradientPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel2.Flip = false;
            this.gradientPanel2.FloatingImage = null;
            this.gradientPanel2.GradientAngle = 90;
            this.gradientPanel2.GradientEndColor = System.Drawing.SystemColors.Control;
            this.gradientPanel2.GradientStartColor = System.Drawing.Color.White;
            this.gradientPanel2.HorizontalFillPercent = 100F;
            this.gradientPanel2.imageXOffset = 0;
            this.gradientPanel2.imageYOffset = 0;
            this.gradientPanel2.Location = new System.Drawing.Point(0, 38);
            this.gradientPanel2.Name = "gradientPanel2";
            this.gradientPanel2.Size = new System.Drawing.Size(1012, 73);
            this.gradientPanel2.TabIndex = 10059;
            this.gradientPanel2.VerticalFillPercent = 100F;
            // 
            // m_cboStorageName
            // 
            this.m_cboStorageName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboStorageName.Location = new System.Drawing.Point(592, 9);
            this.m_cboStorageName.Margin = new System.Windows.Forms.Padding(0);
            this.m_cboStorageName.Name = "m_cboStorageName";
            this.m_cboStorageName.Size = new System.Drawing.Size(156, 22);
            this.m_cboStorageName.TabIndex = 2;
            this.m_cboStorageName.SelectedIndexChanged += new System.EventHandler(this.m_cboStorageName_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(515, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 10059;
            this.label6.Text = "库房名称：";
            // 
            // m_txtMedicineCode
            // 
            this.m_txtMedicineCode.AccessibleDescription = "药品代码";
            this.m_txtMedicineCode.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtMedicineCode.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtMedicineCode.Location = new System.Drawing.Point(85, 37);
            this.m_txtMedicineCode.Name = "m_txtMedicineCode";
            this.m_txtMedicineCode.Size = new System.Drawing.Size(424, 23);
            this.m_txtMedicineCode.TabIndex = 3;
            this.m_txtMedicineCode.TextChanged += new System.EventHandler(this.m_txtMedicineCode_TextChanged);
            this.m_txtMedicineCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtMedicineCode_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 10047;
            this.label1.Text = "统计时间：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(36, 40);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 14);
            this.label15.TabIndex = 10057;
            this.label15.Text = "药品：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(290, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 14);
            this.label8.TabIndex = 10048;
            this.label8.Text = "~";
            // 
            // m_dtpSearchBeginDate
            // 
            this.m_dtpSearchBeginDate.CustomFormat = "yyyy年MM月dd日HH时mm分ss秒";
            this.m_dtpSearchBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpSearchBeginDate.Location = new System.Drawing.Point(85, 9);
            this.m_dtpSearchBeginDate.Name = "m_dtpSearchBeginDate";
            this.m_dtpSearchBeginDate.Size = new System.Drawing.Size(205, 23);
            this.m_dtpSearchBeginDate.TabIndex = 0;
            // 
            // m_dtpSearchEndDate
            // 
            this.m_dtpSearchEndDate.CustomFormat = "yyyy年MM月dd日HH时mm分ss秒";
            this.m_dtpSearchEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpSearchEndDate.Location = new System.Drawing.Point(304, 9);
            this.m_dtpSearchEndDate.Name = "m_dtpSearchEndDate";
            this.m_dtpSearchEndDate.Size = new System.Drawing.Size(205, 23);
            this.m_dtpSearchEndDate.TabIndex = 1;
            // 
            // dw
            // 
            this.dw.DataWindowObject = "";
            this.dw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dw.LibraryList = "";
            this.dw.Location = new System.Drawing.Point(0, 111);
            this.dw.Name = "dw";
            this.dw.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dw.Size = new System.Drawing.Size(1012, 557);
            this.dw.TabIndex = 10060;
            this.dw.Text = "dataWindowControl1";
            // 
            // m_dgvMedDetail
            // 
            this.m_dgvMedDetail.AllowUserToAddRows = false;
            this.m_dgvMedDetail.AllowUserToOrderColumns = true;
            this.m_dgvMedDetail.BackgroundColor = System.Drawing.Color.White;
            this.m_dgvMedDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_dgvMedDetail.ColumnHeadersHeight = 25;
            this.m_dgvMedDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgvMedDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_dgvtxtoperatedate_dat,
            this.m_dgvtxtpatientcardid_chr,
            this.m_dgvtxtlastname_vchr,
            this.m_dgvtxtAmount,
            this.m_dgvtxtUnit,
            this.m_dgvtxtoldgross_int,
            this.m_dgvtxtretailprice_int,
            this.m_dgvtxtsumprice,
            this.m_dgvtxtsharer,
            this.m_dgvtxtwithdrawer,
            this.m_dgvSortRowNo});
            this.m_dgvMedDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvMedDetail.Location = new System.Drawing.Point(0, 111);
            this.m_dgvMedDetail.Name = "m_dgvMedDetail";
            this.m_dgvMedDetail.ReadOnly = true;
            this.m_dgvMedDetail.RowHeadersVisible = false;
            this.m_dgvMedDetail.RowTemplate.Height = 23;
            this.m_dgvMedDetail.Size = new System.Drawing.Size(1012, 557);
            this.m_dgvMedDetail.TabIndex = 10061;
            this.m_dgvMedDetail.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.m_dgvMedDetail_ColumnHeaderMouseDoubleClick);
            this.m_dgvMedDetail.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.m_dgvMedDetail_ColumnHeaderMouseClick);
            // 
            // m_lblPriceSum
            // 
            this.m_lblPriceSum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblPriceSum.AutoSize = true;
            this.m_lblPriceSum.BackColor = System.Drawing.Color.Gainsboro;
            this.m_lblPriceSum.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblPriceSum.ForeColor = System.Drawing.Color.Maroon;
            this.m_lblPriceSum.Location = new System.Drawing.Point(793, 653);
            this.m_lblPriceSum.Name = "m_lblPriceSum";
            this.m_lblPriceSum.Size = new System.Drawing.Size(46, 14);
            this.m_lblPriceSum.TabIndex = 10076;
            this.m_lblPriceSum.Text = "0.0元";
            this.m_lblPriceSum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lblPriceSum.Visible = false;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Gainsboro;
            this.label13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.Color.Maroon;
            this.label13.Location = new System.Drawing.Point(739, 653);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 14);
            this.label13.TabIndex = 10075;
            this.label13.Text = "金额￥:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label13.Visible = false;
            // 
            // m_dgvtxtoperatedate_dat
            // 
            this.m_dgvtxtoperatedate_dat.DataPropertyName = "operatedate_dat";
            dataGridViewCellStyle6.Format = "yyyy-MM-dd HH:mm:ss";
            this.m_dgvtxtoperatedate_dat.DefaultCellStyle = dataGridViewCellStyle6;
            this.m_dgvtxtoperatedate_dat.HeaderText = "配药时间";
            this.m_dgvtxtoperatedate_dat.Name = "m_dgvtxtoperatedate_dat";
            this.m_dgvtxtoperatedate_dat.ReadOnly = true;
            this.m_dgvtxtoperatedate_dat.Width = 170;
            // 
            // m_dgvtxtpatientcardid_chr
            // 
            this.m_dgvtxtpatientcardid_chr.DataPropertyName = "patientcardid_chr";
            this.m_dgvtxtpatientcardid_chr.HeaderText = "诊疗卡";
            this.m_dgvtxtpatientcardid_chr.Name = "m_dgvtxtpatientcardid_chr";
            this.m_dgvtxtpatientcardid_chr.ReadOnly = true;
            // 
            // m_dgvtxtlastname_vchr
            // 
            this.m_dgvtxtlastname_vchr.DataPropertyName = "lastname_vchr";
            this.m_dgvtxtlastname_vchr.HeaderText = "姓名";
            this.m_dgvtxtlastname_vchr.Name = "m_dgvtxtlastname_vchr";
            this.m_dgvtxtlastname_vchr.ReadOnly = true;
            this.m_dgvtxtlastname_vchr.Width = 80;
            // 
            // m_dgvtxtAmount
            // 
            this.m_dgvtxtAmount.DataPropertyName = "amount_int";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            this.m_dgvtxtAmount.DefaultCellStyle = dataGridViewCellStyle7;
            this.m_dgvtxtAmount.HeaderText = "数量";
            this.m_dgvtxtAmount.Name = "m_dgvtxtAmount";
            this.m_dgvtxtAmount.ReadOnly = true;
            // 
            // m_dgvtxtUnit
            // 
            this.m_dgvtxtUnit.DataPropertyName = "unit_chr";
            this.m_dgvtxtUnit.HeaderText = "单位";
            this.m_dgvtxtUnit.Name = "m_dgvtxtUnit";
            this.m_dgvtxtUnit.ReadOnly = true;
            this.m_dgvtxtUnit.Width = 45;
            // 
            // m_dgvtxtoldgross_int
            // 
            this.m_dgvtxtoldgross_int.DataPropertyName = "oldgross_int";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            this.m_dgvtxtoldgross_int.DefaultCellStyle = dataGridViewCellStyle8;
            this.m_dgvtxtoldgross_int.HeaderText = "减后库存";
            this.m_dgvtxtoldgross_int.Name = "m_dgvtxtoldgross_int";
            this.m_dgvtxtoldgross_int.ReadOnly = true;
            // 
            // m_dgvtxtretailprice_int
            // 
            this.m_dgvtxtretailprice_int.DataPropertyName = "retailprice_int";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N4";
            this.m_dgvtxtretailprice_int.DefaultCellStyle = dataGridViewCellStyle9;
            this.m_dgvtxtretailprice_int.HeaderText = "单价";
            this.m_dgvtxtretailprice_int.Name = "m_dgvtxtretailprice_int";
            this.m_dgvtxtretailprice_int.ReadOnly = true;
            // 
            // m_dgvtxtsumprice
            // 
            this.m_dgvtxtsumprice.DataPropertyName = "sumprice";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N4";
            this.m_dgvtxtsumprice.DefaultCellStyle = dataGridViewCellStyle10;
            this.m_dgvtxtsumprice.HeaderText = "金额";
            this.m_dgvtxtsumprice.Name = "m_dgvtxtsumprice";
            this.m_dgvtxtsumprice.ReadOnly = true;
            this.m_dgvtxtsumprice.Width = 105;
            // 
            // m_dgvtxtsharer
            // 
            this.m_dgvtxtsharer.DataPropertyName = "sharer";
            this.m_dgvtxtsharer.HeaderText = "配药人";
            this.m_dgvtxtsharer.Name = "m_dgvtxtsharer";
            this.m_dgvtxtsharer.ReadOnly = true;
            // 
            // m_dgvtxtwithdrawer
            // 
            this.m_dgvtxtwithdrawer.DataPropertyName = "withdrawer";
            this.m_dgvtxtwithdrawer.HeaderText = "退药人";
            this.m_dgvtxtwithdrawer.Name = "m_dgvtxtwithdrawer";
            this.m_dgvtxtwithdrawer.ReadOnly = true;
            // 
            // m_dgvSortRowNo
            // 
            this.m_dgvSortRowNo.DataPropertyName = "SortRowNo";
            this.m_dgvSortRowNo.HeaderText = "排序号";
            this.m_dgvSortRowNo.Name = "m_dgvSortRowNo";
            this.m_dgvSortRowNo.ReadOnly = true;
            this.m_dgvSortRowNo.Visible = false;
            // 
            // frmRecipeMedicineDetailReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 668);
            this.Controls.Add(this.m_lblPriceSum);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.m_dgvMedDetail);
            this.Controls.Add(this.dw);
            this.Controls.Add(this.gradientPanel2);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRecipeMedicineDetailReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "处方药品明细查询";
            this.Load += new System.EventHandler(this.frmRptInstorageStat_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gradientPanel2.ResumeLayout(false);
            this.gradientPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvMedDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStrip toolStrip1;
        internal System.Windows.Forms.ToolStripButton m_btnQuery;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton m_btnPreview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        internal System.Windows.Forms.ToolStripButton m_btnPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        internal System.Windows.Forms.ToolStripLabel m_btnExport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton m_btnExit;
        private com.digitalwave.iCare.gui.MedicineStore.GradientPanel gradientPanel2;
        internal com.digitalwave.iCare.gui.MedicineStore_Maintain.exComboBox m_cboStorageName;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox m_txtMedicineCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.DateTimePicker m_dtpSearchBeginDate;
        internal System.Windows.Forms.DateTimePicker m_dtpSearchEndDate;
        internal Sybase.DataWindow.DataWindowControl dw;
        internal System.Windows.Forms.DataGridView m_dgvMedDetail;
        internal System.Windows.Forms.Label m_lblPriceSum;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtoperatedate_dat;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtpatientcardid_chr;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtlastname_vchr;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtoldgross_int;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtretailprice_int;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtsumprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtsharer;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtwithdrawer;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvSortRowNo;

    }
}