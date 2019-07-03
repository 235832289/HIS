namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    partial class frmRptRecipeOutSumStat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptRecipeOutSumStat));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.gradientPanel2 = new com.digitalwave.iCare.gui.MedicineStore.GradientPanel();
            this.m_txtMedicineCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTypecode = new ControlLibrary.txtListView1(this.components);
            this.m_dtpSearchBeginDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.m_dtpSearchEndDate = new System.Windows.Forms.DateTimePicker();
            this.m_lblPriceSum = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.m_dgvOutSumStat = new System.Windows.Forms.DataGridView();
            this.dw = new Sybase.DataWindow.DataWindowControl();
            this.m_dgvtxtassistcode_chr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtmedicinename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtipunit_chr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtproductorid_chr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitprice_mny = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtipamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtsumprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvSortRowNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.gradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvOutSumStat)).BeginInit();
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
            this.gradientPanel2.Controls.Add(this.m_txtMedicineCode);
            this.gradientPanel2.Controls.Add(this.label1);
            this.gradientPanel2.Controls.Add(this.label15);
            this.gradientPanel2.Controls.Add(this.label8);
            this.gradientPanel2.Controls.Add(this.txtTypecode);
            this.gradientPanel2.Controls.Add(this.m_dtpSearchBeginDate);
            this.gradientPanel2.Controls.Add(this.label4);
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
            this.gradientPanel2.Size = new System.Drawing.Size(1012, 41);
            this.gradientPanel2.TabIndex = 10059;
            this.gradientPanel2.VerticalFillPercent = 100F;
            // 
            // m_txtMedicineCode
            // 
            this.m_txtMedicineCode.AccessibleDescription = "药品代码";
            this.m_txtMedicineCode.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtMedicineCode.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtMedicineCode.Location = new System.Drawing.Point(741, 9);
            this.m_txtMedicineCode.Name = "m_txtMedicineCode";
            this.m_txtMedicineCode.Size = new System.Drawing.Size(259, 23);
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
            this.label15.Location = new System.Drawing.Point(692, 13);
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
            // txtTypecode
            // 
            this.txtTypecode.AccessibleName = "5";
            this.txtTypecode.findDataMode = ControlLibrary.txtListView1.findMode.fromDataSouse;
            this.txtTypecode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTypecode.Location = new System.Drawing.Point(586, 9);
            this.txtTypecode.m_blnFocuseShow = true;
            this.txtTypecode.m_blnPagination = false;
            this.txtTypecode.m_dtbDataSourse = null;
            this.txtTypecode.m_intDelayTime = 100;
            this.txtTypecode.m_intPageRows = 10;
            this.txtTypecode.m_ListViewAlign = ControlLibrary.txtListView1.ListViewAlign.LeftBottom;
            this.txtTypecode.m_listViewSize = new System.Drawing.Point(163, 150);
            this.txtTypecode.m_strFieldsArr = new string[] {
        "entcode_chr",
        "entname_vchr"};
            this.txtTypecode.m_strSaveField = "medicinetypeid_chr";
            this.txtTypecode.m_strShowField = "medicinetypename_vchr";
            this.txtTypecode.m_strSQL = null;
            this.txtTypecode.Name = "txtTypecode";
            this.txtTypecode.Size = new System.Drawing.Size(106, 23);
            this.txtTypecode.TabIndex = 2;
            this.txtTypecode.ItemSelectedOK += new ControlLibrary.txtListView1.EventItemSelectedOK(this.txtTypecode_ItemSelectedOK);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(509, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 10051;
            this.label4.Text = "药品类别：";
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
            // m_lblPriceSum
            // 
            this.m_lblPriceSum.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_lblPriceSum.AutoSize = true;
            this.m_lblPriceSum.BackColor = System.Drawing.Color.Gainsboro;
            this.m_lblPriceSum.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblPriceSum.ForeColor = System.Drawing.Color.Maroon;
            this.m_lblPriceSum.Location = new System.Drawing.Point(636, 11);
            this.m_lblPriceSum.Name = "m_lblPriceSum";
            this.m_lblPriceSum.Size = new System.Drawing.Size(46, 14);
            this.m_lblPriceSum.TabIndex = 10074;
            this.m_lblPriceSum.Text = "0.0元";
            this.m_lblPriceSum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lblPriceSum.Visible = false;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Gainsboro;
            this.label13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.Color.Maroon;
            this.label13.Location = new System.Drawing.Point(582, 11);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 14);
            this.label13.TabIndex = 10073;
            this.label13.Text = "金额￥:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label13.Visible = false;
            // 
            // m_dgvOutSumStat
            // 
            this.m_dgvOutSumStat.AllowUserToAddRows = false;
            this.m_dgvOutSumStat.AllowUserToOrderColumns = true;
            this.m_dgvOutSumStat.BackgroundColor = System.Drawing.Color.White;
            this.m_dgvOutSumStat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_dgvOutSumStat.ColumnHeadersHeight = 25;
            this.m_dgvOutSumStat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgvOutSumStat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_dgvtxtassistcode_chr,
            this.m_dgvtxtmedicinename,
            this.m_dgvSpec,
            this.m_dgvtxtipunit_chr,
            this.m_dgvtxtproductorid_chr,
            this.unitprice_mny,
            this.m_dgvtxtipamount,
            this.m_dgvtxtsumprice,
            this.deptName,
            this.m_dgvSortRowNo});
            this.m_dgvOutSumStat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvOutSumStat.Location = new System.Drawing.Point(0, 79);
            this.m_dgvOutSumStat.Name = "m_dgvOutSumStat";
            this.m_dgvOutSumStat.ReadOnly = true;
            this.m_dgvOutSumStat.RowHeadersVisible = false;
            this.m_dgvOutSumStat.RowTemplate.Height = 23;
            this.m_dgvOutSumStat.Size = new System.Drawing.Size(1012, 662);
            this.m_dgvOutSumStat.TabIndex = 10062;
            this.m_dgvOutSumStat.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.m_dgvOutSumStat_ColumnHeaderMouseClick);
            // 
            // dw
            // 
            this.dw.DataWindowObject = "";
            this.dw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dw.LibraryList = "";
            this.dw.Location = new System.Drawing.Point(0, 79);
            this.dw.Name = "dw";
            this.dw.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dw.Size = new System.Drawing.Size(1012, 662);
            this.dw.TabIndex = 10061;
            this.dw.Text = "dataWindowControl1";
            // 
            // m_dgvtxtassistcode_chr
            // 
            this.m_dgvtxtassistcode_chr.DataPropertyName = "assistcode_chr";
            this.m_dgvtxtassistcode_chr.HeaderText = "药品编码";
            this.m_dgvtxtassistcode_chr.Name = "m_dgvtxtassistcode_chr";
            this.m_dgvtxtassistcode_chr.ReadOnly = true;
            // 
            // m_dgvtxtmedicinename
            // 
            this.m_dgvtxtmedicinename.DataPropertyName = "medicinename_vchr";
            this.m_dgvtxtmedicinename.HeaderText = "   药名";
            this.m_dgvtxtmedicinename.Name = "m_dgvtxtmedicinename";
            this.m_dgvtxtmedicinename.ReadOnly = true;
            this.m_dgvtxtmedicinename.Width = 200;
            // 
            // m_dgvSpec
            // 
            this.m_dgvSpec.DataPropertyName = "medspec_vchr";
            this.m_dgvSpec.HeaderText = "规格";
            this.m_dgvSpec.Name = "m_dgvSpec";
            this.m_dgvSpec.ReadOnly = true;
            // 
            // m_dgvtxtipunit_chr
            // 
            this.m_dgvtxtipunit_chr.DataPropertyName = "ipunit_chr";
            this.m_dgvtxtipunit_chr.HeaderText = "单位";
            this.m_dgvtxtipunit_chr.Name = "m_dgvtxtipunit_chr";
            this.m_dgvtxtipunit_chr.ReadOnly = true;
            this.m_dgvtxtipunit_chr.Width = 45;
            // 
            // m_dgvtxtproductorid_chr
            // 
            this.m_dgvtxtproductorid_chr.DataPropertyName = "productorid_chr";
            this.m_dgvtxtproductorid_chr.HeaderText = "       厂家";
            this.m_dgvtxtproductorid_chr.Name = "m_dgvtxtproductorid_chr";
            this.m_dgvtxtproductorid_chr.ReadOnly = true;
            this.m_dgvtxtproductorid_chr.Width = 170;
            // 
            // unitprice_mny
            // 
            this.unitprice_mny.DataPropertyName = "unitprice_mny";
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.unitprice_mny.DefaultCellStyle = dataGridViewCellStyle1;
            this.unitprice_mny.HeaderText = "单价";
            this.unitprice_mny.Name = "unitprice_mny";
            this.unitprice_mny.ReadOnly = true;
            this.unitprice_mny.Width = 80;
            // 
            // m_dgvtxtipamount
            // 
            this.m_dgvtxtipamount.DataPropertyName = "ipamount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.m_dgvtxtipamount.DefaultCellStyle = dataGridViewCellStyle2;
            this.m_dgvtxtipamount.HeaderText = "      数量";
            this.m_dgvtxtipamount.Name = "m_dgvtxtipamount";
            this.m_dgvtxtipamount.ReadOnly = true;
            this.m_dgvtxtipamount.Width = 130;
            // 
            // m_dgvtxtsumprice
            // 
            this.m_dgvtxtsumprice.DataPropertyName = "sumprice";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.m_dgvtxtsumprice.DefaultCellStyle = dataGridViewCellStyle3;
            this.m_dgvtxtsumprice.HeaderText = "     金额";
            this.m_dgvtxtsumprice.Name = "m_dgvtxtsumprice";
            this.m_dgvtxtsumprice.ReadOnly = true;
            this.m_dgvtxtsumprice.Width = 150;
            // 
            // deptName
            // 
            this.deptName.HeaderText = "科室";
            this.deptName.Name = "deptName";
            this.deptName.ReadOnly = true;
            this.deptName.Visible = false;
            this.deptName.Width = 80;
            // 
            // m_dgvSortRowNo
            // 
            this.m_dgvSortRowNo.DataPropertyName = "SortRowNo";
            this.m_dgvSortRowNo.HeaderText = "排序号";
            this.m_dgvSortRowNo.Name = "m_dgvSortRowNo";
            this.m_dgvSortRowNo.ReadOnly = true;
            this.m_dgvSortRowNo.Visible = false;
            // 
            // frmRptRecipeOutSumStat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 741);
            this.Controls.Add(this.m_lblPriceSum);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.m_dgvOutSumStat);
            this.Controls.Add(this.dw);
            this.Controls.Add(this.gradientPanel2);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRptRecipeOutSumStat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "处方药品消耗金额统计表";
            this.Load += new System.EventHandler(this.frmRptInstorageStat_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gradientPanel2.ResumeLayout(false);
            this.gradientPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvOutSumStat)).EndInit();
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
        internal System.Windows.Forms.Label m_lblPriceSum;
        internal System.Windows.Forms.TextBox m_txtMedicineCode;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label8;
        internal ControlLibrary.txtListView1 txtTypecode;
        internal System.Windows.Forms.DateTimePicker m_dtpSearchBeginDate;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.DateTimePicker m_dtpSearchEndDate;
        internal System.Windows.Forms.DataGridView m_dgvOutSumStat;
        internal Sybase.DataWindow.DataWindowControl dw;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtassistcode_chr;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtmedicinename;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtipunit_chr;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtproductorid_chr;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitprice_mny;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtipamount;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtsumprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn deptName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvSortRowNo;

    }
}