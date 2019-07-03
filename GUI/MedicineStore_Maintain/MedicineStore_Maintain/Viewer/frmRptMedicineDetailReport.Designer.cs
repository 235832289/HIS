namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    partial class frmRptMedicineDetailReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptMedicineDetailReport));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.m_btnQuery = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnPreview = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnExport = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnExit = new System.Windows.Forms.ToolStripButton();
            this.gradientPanel2 = new com.digitalwave.iCare.gui.HIS.GradientPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_rbtCombine = new System.Windows.Forms.RadioButton();
            this.m_rbtSingle = new System.Windows.Forms.RadioButton();
            this.m_txtMedicineCode = new System.Windows.Forms.TextBox();
            this.m_dtpSearchEndDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab(this.components);
            this.m_dtpSearchBeginDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dw = new Sybase.DataWindow.DataWindowControl();
            this.m_dgvMedDetail = new System.Windows.Forms.DataGridView();
            this.direction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typename_vchr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productorid_chr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operatedate_dat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deptname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientcardid_chr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastname_vchr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotno_vchr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.validperiod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.retailprice_int = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outsum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oldgross_int = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvSortRowNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_lblPriceSum = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.gradientPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.m_btnExport,
            this.toolStripSeparator3,
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
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
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
            this.gradientPanel2.Controls.Add(this.groupBox1);
            this.gradientPanel2.Controls.Add(this.m_dtpSearchEndDate);
            this.gradientPanel2.Controls.Add(this.m_dtpSearchBeginDate);
            this.gradientPanel2.Controls.Add(this.label1);
            this.gradientPanel2.Controls.Add(this.label8);
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
            this.gradientPanel2.Size = new System.Drawing.Size(1012, 44);
            this.gradientPanel2.TabIndex = 10059;
            this.gradientPanel2.VerticalFillPercent = 100F;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.m_rbtCombine);
            this.groupBox1.Controls.Add(this.m_rbtSingle);
            this.groupBox1.Controls.Add(this.m_txtMedicineCode);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(479, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(530, 36);
            this.groupBox1.TabIndex = 10076;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "药品";
            // 
            // m_rbtCombine
            // 
            this.m_rbtCombine.AutoSize = true;
            this.m_rbtCombine.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_rbtCombine.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.m_rbtCombine.Location = new System.Drawing.Point(81, 12);
            this.m_rbtCombine.Name = "m_rbtCombine";
            this.m_rbtCombine.Size = new System.Drawing.Size(67, 18);
            this.m_rbtCombine.TabIndex = 1;
            this.m_rbtCombine.TabStop = true;
            this.m_rbtCombine.Text = "单品种";
            this.m_rbtCombine.UseVisualStyleBackColor = true;
            this.m_rbtCombine.CheckedChanged += new System.EventHandler(this.m_rbtCombine_CheckedChanged);
            // 
            // m_rbtSingle
            // 
            this.m_rbtSingle.AutoSize = true;
            this.m_rbtSingle.Checked = true;
            this.m_rbtSingle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_rbtSingle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.m_rbtSingle.Location = new System.Drawing.Point(4, 12);
            this.m_rbtSingle.Name = "m_rbtSingle";
            this.m_rbtSingle.Size = new System.Drawing.Size(81, 18);
            this.m_rbtSingle.TabIndex = 0;
            this.m_rbtSingle.TabStop = true;
            this.m_rbtSingle.Text = "具体药品";
            this.m_rbtSingle.UseVisualStyleBackColor = true;
            // 
            // m_txtMedicineCode
            // 
            this.m_txtMedicineCode.AccessibleDescription = "药品代码";
            this.m_txtMedicineCode.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtMedicineCode.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtMedicineCode.Location = new System.Drawing.Point(151, 10);
            this.m_txtMedicineCode.Name = "m_txtMedicineCode";
            this.m_txtMedicineCode.Size = new System.Drawing.Size(376, 23);
            this.m_txtMedicineCode.TabIndex = 3;
            this.m_txtMedicineCode.TextChanged += new System.EventHandler(this.m_txtMedicineCode_TextChanged);
            this.m_txtMedicineCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtMedicineCode_KeyDown);
            // 
            // m_dtpSearchEndDate
            // 
            this.m_dtpSearchEndDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_dtpSearchEndDate.Location = new System.Drawing.Point(286, 9);
            this.m_dtpSearchEndDate.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日HHmmss;
            this.m_dtpSearchEndDate.Mask = "0000年90月90日 90:90:90";
            this.m_dtpSearchEndDate.Name = "m_dtpSearchEndDate";
            this.m_dtpSearchEndDate.Size = new System.Drawing.Size(187, 23);
            this.m_dtpSearchEndDate.TabIndex = 1;
            this.m_dtpSearchEndDate.ValidatingType = typeof(System.DateTime);
            // 
            // m_dtpSearchBeginDate
            // 
            this.m_dtpSearchBeginDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_dtpSearchBeginDate.Location = new System.Drawing.Point(85, 9);
            this.m_dtpSearchBeginDate.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日HHmmss;
            this.m_dtpSearchBeginDate.Mask = "0000年90月90日 90:90:90";
            this.m_dtpSearchBeginDate.Name = "m_dtpSearchBeginDate";
            this.m_dtpSearchBeginDate.Size = new System.Drawing.Size(187, 23);
            this.m_dtpSearchBeginDate.TabIndex = 0;
            this.m_dtpSearchBeginDate.ValidatingType = typeof(System.DateTime);
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(272, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 14);
            this.label8.TabIndex = 10048;
            this.label8.Text = "~";
            // 
            // dw
            // 
            this.dw.DataWindowObject = "";
            this.dw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dw.LibraryList = "";
            this.dw.Location = new System.Drawing.Point(0, 82);
            this.dw.Name = "dw";
            this.dw.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dw.Size = new System.Drawing.Size(1012, 586);
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
            this.direction,
            this.typename_vchr,
            this.productorid_chr,
            this.operatedate_dat,
            this.deptname,
            this.patientcardid_chr,
            this.lastname_vchr,
            this.lotno_vchr,
            this.validperiod,
            this.unit,
            this.retailprice_int,
            this.inamount,
            this.outamount,
            this.insum,
            this.outsum,
            this.oldgross_int,
            this.m_dgvSortRowNo});
            this.m_dgvMedDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvMedDetail.Location = new System.Drawing.Point(0, 82);
            this.m_dgvMedDetail.Name = "m_dgvMedDetail";
            this.m_dgvMedDetail.ReadOnly = true;
            this.m_dgvMedDetail.RowHeadersVisible = false;
            this.m_dgvMedDetail.RowTemplate.Height = 23;
            this.m_dgvMedDetail.Size = new System.Drawing.Size(1012, 586);
            this.m_dgvMedDetail.TabIndex = 10061;
            this.m_dgvMedDetail.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.m_dgvMedDetail_ColumnHeaderMouseClick);
            this.m_dgvMedDetail.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.m_dgvMedDetail_ColumnHeaderMouseDoubleClick);
            // 
            // direction
            // 
            this.direction.DataPropertyName = "direction";
            this.direction.HeaderText = "方向";
            this.direction.Name = "direction";
            this.direction.ReadOnly = true;
            this.direction.Width = 45;
            // 
            // typename_vchr
            // 
            this.typename_vchr.DataPropertyName = "typename_vchr";
            this.typename_vchr.HeaderText = "类型";
            this.typename_vchr.Name = "typename_vchr";
            this.typename_vchr.ReadOnly = true;
            this.typename_vchr.Width = 70;
            // 
            // productorid_chr
            // 
            this.productorid_chr.DataPropertyName = "productorid_chr";
            this.productorid_chr.HeaderText = "厂家";
            this.productorid_chr.Name = "productorid_chr";
            this.productorid_chr.ReadOnly = true;
            this.productorid_chr.Width = 80;
            // 
            // operatedate_dat
            // 
            this.operatedate_dat.DataPropertyName = "operatedate_dat";
            dataGridViewCellStyle1.Format = "G";
            dataGridViewCellStyle1.NullValue = null;
            this.operatedate_dat.DefaultCellStyle = dataGridViewCellStyle1;
            this.operatedate_dat.HeaderText = "时间";
            this.operatedate_dat.Name = "operatedate_dat";
            this.operatedate_dat.ReadOnly = true;
            this.operatedate_dat.Width = 150;
            // 
            // deptname
            // 
            this.deptname.DataPropertyName = "deptname";
            this.deptname.HeaderText = "科室";
            this.deptname.Name = "deptname";
            this.deptname.ReadOnly = true;
            this.deptname.Width = 80;
            // 
            // patientcardid_chr
            // 
            this.patientcardid_chr.DataPropertyName = "patientcardid_chr";
            this.patientcardid_chr.HeaderText = "病人ID";
            this.patientcardid_chr.Name = "patientcardid_chr";
            this.patientcardid_chr.ReadOnly = true;
            this.patientcardid_chr.Width = 80;
            // 
            // lastname_vchr
            // 
            this.lastname_vchr.DataPropertyName = "lastname_vchr";
            this.lastname_vchr.HeaderText = "病人姓名";
            this.lastname_vchr.Name = "lastname_vchr";
            this.lastname_vchr.ReadOnly = true;
            this.lastname_vchr.Width = 80;
            // 
            // lotno_vchr
            // 
            this.lotno_vchr.DataPropertyName = "lotno_vchr";
            this.lotno_vchr.HeaderText = "批号";
            this.lotno_vchr.Name = "lotno_vchr";
            this.lotno_vchr.ReadOnly = true;
            this.lotno_vchr.Width = 73;
            // 
            // validperiod
            // 
            this.validperiod.DataPropertyName = "validperiod";
            this.validperiod.HeaderText = "失效期";
            this.validperiod.Name = "validperiod";
            this.validperiod.ReadOnly = true;
            this.validperiod.Width = 73;
            // 
            // unit
            // 
            this.unit.DataPropertyName = "unit";
            this.unit.HeaderText = "单位";
            this.unit.Name = "unit";
            this.unit.ReadOnly = true;
            this.unit.Width = 43;
            // 
            // retailprice_int
            // 
            this.retailprice_int.DataPropertyName = "retailprice_int";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.retailprice_int.DefaultCellStyle = dataGridViewCellStyle2;
            this.retailprice_int.HeaderText = "零售价";
            this.retailprice_int.Name = "retailprice_int";
            this.retailprice_int.ReadOnly = true;
            this.retailprice_int.Width = 65;
            // 
            // inamount
            // 
            this.inamount.DataPropertyName = "inamount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.inamount.DefaultCellStyle = dataGridViewCellStyle3;
            this.inamount.HeaderText = "入库数量";
            this.inamount.Name = "inamount";
            this.inamount.ReadOnly = true;
            this.inamount.Width = 80;
            // 
            // outamount
            // 
            this.outamount.DataPropertyName = "outamount";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.outamount.DefaultCellStyle = dataGridViewCellStyle4;
            this.outamount.HeaderText = "出库数量";
            this.outamount.Name = "outamount";
            this.outamount.ReadOnly = true;
            this.outamount.Width = 80;
            // 
            // insum
            // 
            this.insum.DataPropertyName = "insum";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N4";
            dataGridViewCellStyle5.NullValue = "0";
            this.insum.DefaultCellStyle = dataGridViewCellStyle5;
            this.insum.HeaderText = "入库金额";
            this.insum.Name = "insum";
            this.insum.ReadOnly = true;
            this.insum.Width = 80;
            // 
            // outsum
            // 
            this.outsum.DataPropertyName = "outsum";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N4";
            dataGridViewCellStyle6.NullValue = "0";
            this.outsum.DefaultCellStyle = dataGridViewCellStyle6;
            this.outsum.HeaderText = "出库金额";
            this.outsum.Name = "outsum";
            this.outsum.ReadOnly = true;
            this.outsum.Width = 80;
            // 
            // oldgross_int
            // 
            this.oldgross_int.DataPropertyName = "oldgross_int";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.oldgross_int.DefaultCellStyle = dataGridViewCellStyle7;
            this.oldgross_int.HeaderText = "结存";
            this.oldgross_int.Name = "oldgross_int";
            this.oldgross_int.ReadOnly = true;
            this.oldgross_int.Width = 70;
            // 
            // m_dgvSortRowNo
            // 
            this.m_dgvSortRowNo.DataPropertyName = "SortRowNo";
            this.m_dgvSortRowNo.HeaderText = "排序";
            this.m_dgvSortRowNo.Name = "m_dgvSortRowNo";
            this.m_dgvSortRowNo.ReadOnly = true;
            this.m_dgvSortRowNo.Visible = false;
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
            // frmRptMedicineDetailReport
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
            this.Name = "frmRptMedicineDetailReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "单品种出入库帐";
            this.Load += new System.EventHandler(this.frmRptInstorageStat_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gradientPanel2.ResumeLayout(false);
            this.gradientPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.ToolStripButton m_btnExit;
        private com.digitalwave.iCare.gui.HIS.GradientPanel gradientPanel2;
        internal System.Windows.Forms.TextBox m_txtMedicineCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        internal Sybase.DataWindow.DataWindowControl dw;
        internal System.Windows.Forms.DataGridView m_dgvMedDetail;
        internal System.Windows.Forms.Label m_lblPriceSum;
        private System.Windows.Forms.Label label13;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab m_dtpSearchEndDate;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab m_dtpSearchBeginDate;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.RadioButton m_rbtCombine;
        internal System.Windows.Forms.RadioButton m_rbtSingle;
        private System.Windows.Forms.DataGridViewTextBoxColumn direction;
        private System.Windows.Forms.DataGridViewTextBoxColumn typename_vchr;
        private System.Windows.Forms.DataGridViewTextBoxColumn productorid_chr;
        private System.Windows.Forms.DataGridViewTextBoxColumn operatedate_dat;
        private System.Windows.Forms.DataGridViewTextBoxColumn deptname;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientcardid_chr;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastname_vchr;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotno_vchr;
        private System.Windows.Forms.DataGridViewTextBoxColumn validperiod;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn retailprice_int;
        private System.Windows.Forms.DataGridViewTextBoxColumn inamount;
        private System.Windows.Forms.DataGridViewTextBoxColumn outamount;
        private System.Windows.Forms.DataGridViewTextBoxColumn insum;
        private System.Windows.Forms.DataGridViewTextBoxColumn outsum;
        private System.Windows.Forms.DataGridViewTextBoxColumn oldgross_int;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvSortRowNo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;

    }
}