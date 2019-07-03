namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    partial class frmRptAdjustpricefullloss
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptAdjustpricefullloss));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gradientPanel2 = new com.digitalwave.iCare.gui.MedicineStore.GradientPanel();
            this.m_dtpEndDat = new com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab(this.components);
            this.m_dtpBeginDat = new com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab(this.components);
            this.m_txtMedicineCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_cboStorageName = new com.digitalwave.iCare.gui.MedicineStore_Maintain.exComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_cboMedicineType = new com.digitalwave.iCare.gui.MedicineStore_Maintain.exComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.m_labExportDept = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.m_cmdQuery = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnPreview = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_cmdPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_cmdExcel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.m_cmdClose = new System.Windows.Forms.ToolStripButton();
            this.dw = new Sybase.DataWindow.DataWindowControl();
            this.m_dgvAdjustFullloss = new System.Windows.Forms.DataGridView();
            this.m_dgvtxtStorageName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssistcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtmedicinename_vch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtmedspec_vchr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtopunit_vchr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtproductorid_chr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtcurrentgross_int = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtoldprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtnewprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtPriceFullloss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtexamdate_dat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtreason_vchr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtmedicineid_chr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SortRowNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gradientPanel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvAdjustFullloss)).BeginInit();
            this.SuspendLayout();
            // 
            // gradientPanel2
            // 
            this.gradientPanel2.Controls.Add(this.m_dtpEndDat);
            this.gradientPanel2.Controls.Add(this.m_dtpBeginDat);
            this.gradientPanel2.Controls.Add(this.m_txtMedicineCode);
            this.gradientPanel2.Controls.Add(this.label3);
            this.gradientPanel2.Controls.Add(this.m_cboStorageName);
            this.gradientPanel2.Controls.Add(this.label5);
            this.gradientPanel2.Controls.Add(this.m_cboMedicineType);
            this.gradientPanel2.Controls.Add(this.label6);
            this.gradientPanel2.Controls.Add(this.label7);
            this.gradientPanel2.Controls.Add(this.m_labExportDept);
            this.gradientPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel2.Flip = true;
            this.gradientPanel2.FloatingImage = null;
            this.gradientPanel2.GradientAngle = 90;
            this.gradientPanel2.GradientEndColor = System.Drawing.SystemColors.Control;
            this.gradientPanel2.GradientStartColor = System.Drawing.Color.White;
            this.gradientPanel2.HorizontalFillPercent = 100F;
            this.gradientPanel2.imageXOffset = 0;
            this.gradientPanel2.imageYOffset = 0;
            this.gradientPanel2.Location = new System.Drawing.Point(0, 38);
            this.gradientPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.gradientPanel2.Name = "gradientPanel2";
            this.gradientPanel2.Size = new System.Drawing.Size(1028, 71);
            this.gradientPanel2.TabIndex = 10060;
            this.gradientPanel2.VerticalFillPercent = 100F;
            // 
            // m_dtpEndDat
            // 
            this.m_dtpEndDat.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_dtpEndDat.Location = new System.Drawing.Point(292, 11);
            this.m_dtpEndDat.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日HHmmss;
            this.m_dtpEndDat.Mask = "0000年90月90日 90:90:90";
            this.m_dtpEndDat.Name = "m_dtpEndDat";
            this.m_dtpEndDat.Size = new System.Drawing.Size(187, 23);
            this.m_dtpEndDat.TabIndex = 1;
            this.m_dtpEndDat.ValidatingType = typeof(System.DateTime);
            // 
            // m_dtpBeginDat
            // 
            this.m_dtpBeginDat.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_dtpBeginDat.Location = new System.Drawing.Point(84, 11);
            this.m_dtpBeginDat.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日HHmmss;
            this.m_dtpBeginDat.Mask = "0000年90月90日 90:90:90";
            this.m_dtpBeginDat.Name = "m_dtpBeginDat";
            this.m_dtpBeginDat.Size = new System.Drawing.Size(187, 23);
            this.m_dtpBeginDat.TabIndex = 0;
            this.m_dtpBeginDat.ValidatingType = typeof(System.DateTime);
            // 
            // m_txtMedicineCode
            // 
            this.m_txtMedicineCode.AccessibleDescription = "药品代码";
            this.m_txtMedicineCode.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtMedicineCode.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtMedicineCode.Location = new System.Drawing.Point(80, 41);
            this.m_txtMedicineCode.Name = "m_txtMedicineCode";
            this.m_txtMedicineCode.Size = new System.Drawing.Size(399, 23);
            this.m_txtMedicineCode.TabIndex = 4;
            this.m_txtMedicineCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtMedicineCode_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(7, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 10072;
            this.label3.Text = "药品名称：";
            // 
            // m_cboStorageName
            // 
            this.m_cboStorageName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboStorageName.Location = new System.Drawing.Point(564, 12);
            this.m_cboStorageName.Margin = new System.Windows.Forms.Padding(0);
            this.m_cboStorageName.Name = "m_cboStorageName";
            this.m_cboStorageName.Size = new System.Drawing.Size(148, 22);
            this.m_cboStorageName.TabIndex = 2;
            this.m_cboStorageName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_mthEnterToTab);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(497, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 14);
            this.label5.TabIndex = 10070;
            this.label5.Text = "库房类型:";
            // 
            // m_cboMedicineType
            // 
            this.m_cboMedicineType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboMedicineType.Location = new System.Drawing.Point(803, 12);
            this.m_cboMedicineType.Margin = new System.Windows.Forms.Padding(0);
            this.m_cboMedicineType.Name = "m_cboMedicineType";
            this.m_cboMedicineType.Size = new System.Drawing.Size(148, 22);
            this.m_cboMedicineType.TabIndex = 3;
            this.m_cboMedicineType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_mthEnterToTab);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(7, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 10047;
            this.label6.Text = "统计时间：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(271, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 14);
            this.label7.TabIndex = 10048;
            this.label7.Text = "至";
            // 
            // m_labExportDept
            // 
            this.m_labExportDept.AutoSize = true;
            this.m_labExportDept.BackColor = System.Drawing.Color.Transparent;
            this.m_labExportDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_labExportDept.Location = new System.Drawing.Point(733, 15);
            this.m_labExportDept.Name = "m_labExportDept";
            this.m_labExportDept.Size = new System.Drawing.Size(77, 14);
            this.m_labExportDept.TabIndex = 10049;
            this.m_labExportDept.Text = "药品类型：";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_cmdQuery,
            this.toolStripSeparator4,
            this.m_btnPreview,
            this.toolStripSeparator2,
            this.m_cmdPrint,
            this.toolStripSeparator1,
            this.m_cmdExcel,
            this.toolStripSeparator3,
            this.m_cmdClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(1028, 38);
            this.toolStrip1.TabIndex = 10059;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // m_cmdQuery
            // 
            this.m_cmdQuery.AutoSize = false;
            this.m_cmdQuery.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdQuery.Image = ((System.Drawing.Image)(resources.GetObject("m_cmdQuery.Image")));
            this.m_cmdQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdQuery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_cmdQuery.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_cmdQuery.Name = "m_cmdQuery";
            this.m_cmdQuery.Size = new System.Drawing.Size(90, 35);
            this.m_cmdQuery.Text = "查 询(&Q)";
            this.m_cmdQuery.Click += new System.EventHandler(this.m_cmdQuery_Click);
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
            this.m_btnPreview.Click += new System.EventHandler(this.m_btnPreview_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // m_cmdPrint
            // 
            this.m_cmdPrint.AutoSize = false;
            this.m_cmdPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdPrint.Image = ((System.Drawing.Image)(resources.GetObject("m_cmdPrint.Image")));
            this.m_cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_cmdPrint.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_cmdPrint.Name = "m_cmdPrint";
            this.m_cmdPrint.Size = new System.Drawing.Size(90, 35);
            this.m_cmdPrint.Text = "打 印(&P)";
            this.m_cmdPrint.Click += new System.EventHandler(this.m_cmdPrint_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // m_cmdExcel
            // 
            this.m_cmdExcel.AutoSize = false;
            this.m_cmdExcel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdExcel.Image = ((System.Drawing.Image)(resources.GetObject("m_cmdExcel.Image")));
            this.m_cmdExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_cmdExcel.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_cmdExcel.Name = "m_cmdExcel";
            this.m_cmdExcel.Size = new System.Drawing.Size(90, 35);
            this.m_cmdExcel.Text = "导 出(&E)";
            this.m_cmdExcel.Click += new System.EventHandler(this.m_cmdExcel_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // m_cmdClose
            // 
            this.m_cmdClose.AutoSize = false;
            this.m_cmdClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("m_cmdClose.Image")));
            this.m_cmdClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_cmdClose.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_cmdClose.Name = "m_cmdClose";
            this.m_cmdClose.Size = new System.Drawing.Size(90, 35);
            this.m_cmdClose.Text = "关 闭(&C)";
            this.m_cmdClose.Click += new System.EventHandler(this.m_cmdClose_Click);
            // 
            // dw
            // 
            this.dw.DataWindowObject = "";
            this.dw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dw.LibraryList = "";
            this.dw.Location = new System.Drawing.Point(0, 109);
            this.dw.Margin = new System.Windows.Forms.Padding(0);
            this.dw.Name = "dw";
            this.dw.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dw.Size = new System.Drawing.Size(1028, 637);
            this.dw.TabIndex = 10061;
            this.dw.Text = "dataWindowControl1";
            // 
            // m_dgvAdjustFullloss
            // 
            this.m_dgvAdjustFullloss.AllowUserToAddRows = false;
            this.m_dgvAdjustFullloss.AllowUserToOrderColumns = true;
            this.m_dgvAdjustFullloss.BackgroundColor = System.Drawing.Color.White;
            this.m_dgvAdjustFullloss.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_dgvAdjustFullloss.ColumnHeadersHeight = 25;
            this.m_dgvAdjustFullloss.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgvAdjustFullloss.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_dgvtxtStorageName,
            this.colAssistcode,
            this.m_dgvtxtmedicinename_vch,
            this.m_dgvtxtmedspec_vchr,
            this.m_dgvtxtopunit_vchr,
            this.m_dgvtxtproductorid_chr,
            this.m_dgvtxtcurrentgross_int,
            this.m_dgvtxtoldprice,
            this.m_dgvtxtnewprice,
            this.m_dgvtxtPriceFullloss,
            this.m_dgvtxtexamdate_dat,
            this.m_dgvtxtreason_vchr,
            this.m_dgvtxtmedicineid_chr,
            this.SortRowNo});
            this.m_dgvAdjustFullloss.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvAdjustFullloss.Location = new System.Drawing.Point(0, 109);
            this.m_dgvAdjustFullloss.Name = "m_dgvAdjustFullloss";
            this.m_dgvAdjustFullloss.ReadOnly = true;
            this.m_dgvAdjustFullloss.RowHeadersVisible = false;
            this.m_dgvAdjustFullloss.RowTemplate.Height = 23;
            this.m_dgvAdjustFullloss.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvAdjustFullloss.Size = new System.Drawing.Size(1028, 637);
            this.m_dgvAdjustFullloss.TabIndex = 10062;
            this.m_dgvAdjustFullloss.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.m_dgvAdjustFullloss_ColumnHeaderMouseClick);
            this.m_dgvAdjustFullloss.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.m_dgvAdjustFullloss_ColumnHeaderMouseDoubleClick);
            // 
            // m_dgvtxtStorageName
            // 
            this.m_dgvtxtStorageName.DataPropertyName = "storagename";
            this.m_dgvtxtStorageName.HeaderText = "库存单位";
            this.m_dgvtxtStorageName.Name = "m_dgvtxtStorageName";
            this.m_dgvtxtStorageName.ReadOnly = true;
            this.m_dgvtxtStorageName.Width = 80;
            // 
            // colAssistcode
            // 
            this.colAssistcode.DataPropertyName = "assistcode_chr";
            this.colAssistcode.HeaderText = "药品编码";
            this.colAssistcode.Name = "colAssistcode";
            this.colAssistcode.ReadOnly = true;
            this.colAssistcode.Width = 88;
            // 
            // m_dgvtxtmedicinename_vch
            // 
            this.m_dgvtxtmedicinename_vch.DataPropertyName = "medicinename_vch";
            this.m_dgvtxtmedicinename_vch.HeaderText = "药品名称";
            this.m_dgvtxtmedicinename_vch.Name = "m_dgvtxtmedicinename_vch";
            this.m_dgvtxtmedicinename_vch.ReadOnly = true;
            this.m_dgvtxtmedicinename_vch.Width = 180;
            // 
            // m_dgvtxtmedspec_vchr
            // 
            this.m_dgvtxtmedspec_vchr.DataPropertyName = "medspec_vchr";
            this.m_dgvtxtmedspec_vchr.HeaderText = "规格";
            this.m_dgvtxtmedspec_vchr.Name = "m_dgvtxtmedspec_vchr";
            this.m_dgvtxtmedspec_vchr.ReadOnly = true;
            this.m_dgvtxtmedspec_vchr.Width = 70;
            // 
            // m_dgvtxtopunit_vchr
            // 
            this.m_dgvtxtopunit_vchr.DataPropertyName = "opunit_vchr";
            this.m_dgvtxtopunit_vchr.HeaderText = "单位";
            this.m_dgvtxtopunit_vchr.Name = "m_dgvtxtopunit_vchr";
            this.m_dgvtxtopunit_vchr.ReadOnly = true;
            this.m_dgvtxtopunit_vchr.Width = 45;
            // 
            // m_dgvtxtproductorid_chr
            // 
            this.m_dgvtxtproductorid_chr.DataPropertyName = "productorid_chr";
            this.m_dgvtxtproductorid_chr.HeaderText = "厂家";
            this.m_dgvtxtproductorid_chr.Name = "m_dgvtxtproductorid_chr";
            this.m_dgvtxtproductorid_chr.ReadOnly = true;
            // 
            // m_dgvtxtcurrentgross_int
            // 
            this.m_dgvtxtcurrentgross_int.DataPropertyName = "currentgross_int";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.m_dgvtxtcurrentgross_int.DefaultCellStyle = dataGridViewCellStyle1;
            this.m_dgvtxtcurrentgross_int.HeaderText = "数量";
            this.m_dgvtxtcurrentgross_int.Name = "m_dgvtxtcurrentgross_int";
            this.m_dgvtxtcurrentgross_int.ReadOnly = true;
            // 
            // m_dgvtxtoldprice
            // 
            this.m_dgvtxtoldprice.DataPropertyName = "oldprice";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N4";
            dataGridViewCellStyle2.NullValue = null;
            this.m_dgvtxtoldprice.DefaultCellStyle = dataGridViewCellStyle2;
            this.m_dgvtxtoldprice.HeaderText = "原零售价";
            this.m_dgvtxtoldprice.Name = "m_dgvtxtoldprice";
            this.m_dgvtxtoldprice.ReadOnly = true;
            // 
            // m_dgvtxtnewprice
            // 
            this.m_dgvtxtnewprice.DataPropertyName = "newprice";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N4";
            dataGridViewCellStyle3.NullValue = null;
            this.m_dgvtxtnewprice.DefaultCellStyle = dataGridViewCellStyle3;
            this.m_dgvtxtnewprice.HeaderText = "新零售价";
            this.m_dgvtxtnewprice.Name = "m_dgvtxtnewprice";
            this.m_dgvtxtnewprice.ReadOnly = true;
            // 
            // m_dgvtxtPriceFullloss
            // 
            this.m_dgvtxtPriceFullloss.DataPropertyName = "pricefullloss";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N4";
            dataGridViewCellStyle4.NullValue = null;
            this.m_dgvtxtPriceFullloss.DefaultCellStyle = dataGridViewCellStyle4;
            this.m_dgvtxtPriceFullloss.HeaderText = "零价盈亏";
            this.m_dgvtxtPriceFullloss.Name = "m_dgvtxtPriceFullloss";
            this.m_dgvtxtPriceFullloss.ReadOnly = true;
            // 
            // m_dgvtxtexamdate_dat
            // 
            this.m_dgvtxtexamdate_dat.DataPropertyName = "examdate_dat";
            dataGridViewCellStyle5.Format = "yyyy-MM-dd HH:mm:ss";
            dataGridViewCellStyle5.NullValue = null;
            this.m_dgvtxtexamdate_dat.DefaultCellStyle = dataGridViewCellStyle5;
            this.m_dgvtxtexamdate_dat.HeaderText = "执行时间";
            this.m_dgvtxtexamdate_dat.Name = "m_dgvtxtexamdate_dat";
            this.m_dgvtxtexamdate_dat.ReadOnly = true;
            this.m_dgvtxtexamdate_dat.Width = 150;
            // 
            // m_dgvtxtreason_vchr
            // 
            this.m_dgvtxtreason_vchr.DataPropertyName = "reason_vchr";
            this.m_dgvtxtreason_vchr.HeaderText = "调价原因";
            this.m_dgvtxtreason_vchr.Name = "m_dgvtxtreason_vchr";
            this.m_dgvtxtreason_vchr.ReadOnly = true;
            this.m_dgvtxtreason_vchr.Width = 80;
            // 
            // m_dgvtxtmedicineid_chr
            // 
            this.m_dgvtxtmedicineid_chr.DataPropertyName = "medicineid_chr";
            this.m_dgvtxtmedicineid_chr.HeaderText = "序列";
            this.m_dgvtxtmedicineid_chr.Name = "m_dgvtxtmedicineid_chr";
            this.m_dgvtxtmedicineid_chr.ReadOnly = true;
            this.m_dgvtxtmedicineid_chr.Visible = false;
            // 
            // SortRowNo
            // 
            this.SortRowNo.DataPropertyName = "SortRowNo";
            this.SortRowNo.HeaderText = "排列号";
            this.SortRowNo.Name = "SortRowNo";
            this.SortRowNo.ReadOnly = true;
            this.SortRowNo.Visible = false;
            // 
            // frmRptAdjustpricefullloss
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 746);
            this.Controls.Add(this.m_dgvAdjustFullloss);
            this.Controls.Add(this.dw);
            this.Controls.Add(this.gradientPanel2);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRptAdjustpricefullloss";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "调价盈亏表";
            this.Load += new System.EventHandler(this.frmRptAdjustpricefullloss_Load);
            this.gradientPanel2.ResumeLayout(false);
            this.gradientPanel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvAdjustFullloss)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private com.digitalwave.iCare.gui.MedicineStore.GradientPanel gradientPanel2;
        internal com.digitalwave.iCare.gui.MedicineStore_Maintain.exComboBox m_cboStorageName;
        private System.Windows.Forms.Label label5;
        internal com.digitalwave.iCare.gui.MedicineStore_Maintain.exComboBox m_cboMedicineType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label m_labExportDept;
        internal System.Windows.Forms.ToolStrip toolStrip1;
        internal System.Windows.Forms.ToolStripButton m_cmdQuery;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton m_btnPreview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        internal System.Windows.Forms.ToolStripButton m_cmdPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        internal System.Windows.Forms.ToolStripLabel m_cmdExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton m_cmdClose;
        internal System.Windows.Forms.TextBox m_txtMedicineCode;
        private System.Windows.Forms.Label label3;
        internal Sybase.DataWindow.DataWindowControl dw;
        internal System.Windows.Forms.DataGridView m_dgvAdjustFullloss;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab m_dtpEndDat;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab m_dtpBeginDat;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtStorageName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssistcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtmedicinename_vch;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtmedspec_vchr;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtopunit_vchr;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtproductorid_chr;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtcurrentgross_int;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtoldprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtnewprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtPriceFullloss;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtexamdate_dat;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtreason_vchr;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtmedicineid_chr;
        private System.Windows.Forms.DataGridViewTextBoxColumn SortRowNo;
    }
}