namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    partial class frmRptAdjustpriceRecord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptAdjustpriceRecord));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gradientPanel2 = new com.digitalwave.iCare.gui.MedicineStore.GradientPanel();
            this.m_dtpEndDat = new com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab(this.components);
            this.m_dtpBeginDat = new com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab(this.components);
            this.m_txtMedicineCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
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
            this.m_dgvAdjustPrice = new System.Windows.Forms.DataGridView();
            this.m_cboStorageName = new com.digitalwave.iCare.gui.MedicineStore_Maintain.exComboBox();
            this.m_dgvtxtAssistcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtOpunit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtOldPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtNewPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtOpoldPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtOpnewPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRetailprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtExamdat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gradientPanel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvAdjustPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // gradientPanel2
            // 
            this.gradientPanel2.Controls.Add(this.m_dtpEndDat);
            this.gradientPanel2.Controls.Add(this.m_dtpBeginDat);
            this.gradientPanel2.Controls.Add(this.m_txtMedicineCode);
            this.gradientPanel2.Controls.Add(this.label1);
            this.gradientPanel2.Controls.Add(this.label6);
            this.gradientPanel2.Controls.Add(this.label7);
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
            this.gradientPanel2.Size = new System.Drawing.Size(1028, 43);
            this.gradientPanel2.TabIndex = 10062;
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
            this.m_txtMedicineCode.Location = new System.Drawing.Point(566, 12);
            this.m_txtMedicineCode.Name = "m_txtMedicineCode";
            this.m_txtMedicineCode.Size = new System.Drawing.Size(416, 23);
            this.m_txtMedicineCode.TabIndex = 2;
            this.m_txtMedicineCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtMedicineCode_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(493, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 10074;
            this.label1.Text = "药品名称：";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(573, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 10070;
            this.label3.Text = "库房名称：";
            this.label3.Visible = false;
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
            this.toolStrip1.TabIndex = 10061;
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
            this.dw.Location = new System.Drawing.Point(0, 81);
            this.dw.Margin = new System.Windows.Forms.Padding(0);
            this.dw.Name = "dw";
            this.dw.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dw.Size = new System.Drawing.Size(1028, 665);
            this.dw.TabIndex = 10063;
            this.dw.Text = "dataWindowControl1";
            // 
            // m_dgvAdjustPrice
            // 
            this.m_dgvAdjustPrice.AllowUserToAddRows = false;
            this.m_dgvAdjustPrice.AllowUserToOrderColumns = true;
            this.m_dgvAdjustPrice.BackgroundColor = System.Drawing.Color.White;
            this.m_dgvAdjustPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_dgvAdjustPrice.ColumnHeadersHeight = 35;
            this.m_dgvAdjustPrice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgvAdjustPrice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_dgvtxtAssistcode,
            this.m_dgvtxtMedName,
            this.m_dgvtxtMedSpec,
            this.m_dgvtxtOpunit,
            this.m_dgvtxtProduct,
            this.m_dgvtxtOldPrice,
            this.m_dgvtxtNewPrice,
            this.m_dgvtxtOpoldPrice,
            this.m_dgvtxtOpnewPrice,
            this.colRetailprice,
            this.m_dgvtxtExamdat,
            this.m_dgvtxtReason});
            this.m_dgvAdjustPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvAdjustPrice.Location = new System.Drawing.Point(0, 81);
            this.m_dgvAdjustPrice.Name = "m_dgvAdjustPrice";
            this.m_dgvAdjustPrice.ReadOnly = true;
            this.m_dgvAdjustPrice.RowHeadersVisible = false;
            this.m_dgvAdjustPrice.RowTemplate.Height = 23;
            this.m_dgvAdjustPrice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvAdjustPrice.Size = new System.Drawing.Size(1028, 665);
            this.m_dgvAdjustPrice.TabIndex = 10064;
            // 
            // m_cboStorageName
            // 
            this.m_cboStorageName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboStorageName.Location = new System.Drawing.Point(640, 9);
            this.m_cboStorageName.Margin = new System.Windows.Forms.Padding(0);
            this.m_cboStorageName.Name = "m_cboStorageName";
            this.m_cboStorageName.Size = new System.Drawing.Size(167, 22);
            this.m_cboStorageName.TabIndex = 2;
            this.m_cboStorageName.Visible = false;
            this.m_cboStorageName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_mthEnterToTab);
            // 
            // m_dgvtxtAssistcode
            // 
            this.m_dgvtxtAssistcode.DataPropertyName = "assistcode_chr";
            this.m_dgvtxtAssistcode.HeaderText = " 药品编号";
            this.m_dgvtxtAssistcode.Name = "m_dgvtxtAssistcode";
            this.m_dgvtxtAssistcode.ReadOnly = true;
            this.m_dgvtxtAssistcode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.m_dgvtxtAssistcode.Width = 88;
            // 
            // m_dgvtxtMedName
            // 
            this.m_dgvtxtMedName.DataPropertyName = "medicinename_vch";
            this.m_dgvtxtMedName.HeaderText = "      药品名称";
            this.m_dgvtxtMedName.Name = "m_dgvtxtMedName";
            this.m_dgvtxtMedName.ReadOnly = true;
            this.m_dgvtxtMedName.Width = 180;
            // 
            // m_dgvtxtMedSpec
            // 
            this.m_dgvtxtMedSpec.DataPropertyName = "medspec_vchr";
            this.m_dgvtxtMedSpec.HeaderText = "  规格";
            this.m_dgvtxtMedSpec.Name = "m_dgvtxtMedSpec";
            this.m_dgvtxtMedSpec.ReadOnly = true;
            this.m_dgvtxtMedSpec.Width = 80;
            // 
            // m_dgvtxtOpunit
            // 
            this.m_dgvtxtOpunit.DataPropertyName = "opunit_vchr";
            this.m_dgvtxtOpunit.HeaderText = "单位";
            this.m_dgvtxtOpunit.Name = "m_dgvtxtOpunit";
            this.m_dgvtxtOpunit.ReadOnly = true;
            this.m_dgvtxtOpunit.Width = 30;
            // 
            // m_dgvtxtProduct
            // 
            this.m_dgvtxtProduct.DataPropertyName = "productorid_chr";
            this.m_dgvtxtProduct.HeaderText = "    厂家";
            this.m_dgvtxtProduct.Name = "m_dgvtxtProduct";
            this.m_dgvtxtProduct.ReadOnly = true;
            // 
            // m_dgvtxtOldPrice
            // 
            this.m_dgvtxtOldPrice.DataPropertyName = "oldretailprice_int";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N4";
            dataGridViewCellStyle1.NullValue = null;
            this.m_dgvtxtOldPrice.DefaultCellStyle = dataGridViewCellStyle1;
            this.m_dgvtxtOldPrice.HeaderText = "  原零售价格    (包装单位)";
            this.m_dgvtxtOldPrice.Name = "m_dgvtxtOldPrice";
            this.m_dgvtxtOldPrice.ReadOnly = true;
            this.m_dgvtxtOldPrice.Width = 110;
            // 
            // m_dgvtxtNewPrice
            // 
            this.m_dgvtxtNewPrice.DataPropertyName = "newretailprice_int";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N4";
            dataGridViewCellStyle2.NullValue = null;
            this.m_dgvtxtNewPrice.DefaultCellStyle = dataGridViewCellStyle2;
            this.m_dgvtxtNewPrice.HeaderText = "  新零售价格    (包装单位)";
            this.m_dgvtxtNewPrice.Name = "m_dgvtxtNewPrice";
            this.m_dgvtxtNewPrice.ReadOnly = true;
            this.m_dgvtxtNewPrice.Width = 110;
            // 
            // m_dgvtxtOpoldPrice
            // 
            this.m_dgvtxtOpoldPrice.DataPropertyName = "opoldprice";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N4";
            dataGridViewCellStyle3.NullValue = null;
            this.m_dgvtxtOpoldPrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.m_dgvtxtOpoldPrice.HeaderText = "  原零售价格    (门诊单位)";
            this.m_dgvtxtOpoldPrice.Name = "m_dgvtxtOpoldPrice";
            this.m_dgvtxtOpoldPrice.ReadOnly = true;
            this.m_dgvtxtOpoldPrice.Width = 110;
            // 
            // m_dgvtxtOpnewPrice
            // 
            this.m_dgvtxtOpnewPrice.DataPropertyName = "opnewprice";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N4";
            dataGridViewCellStyle4.NullValue = null;
            this.m_dgvtxtOpnewPrice.DefaultCellStyle = dataGridViewCellStyle4;
            this.m_dgvtxtOpnewPrice.HeaderText = "  新零售价格    (门诊单位)";
            this.m_dgvtxtOpnewPrice.Name = "m_dgvtxtOpnewPrice";
            this.m_dgvtxtOpnewPrice.ReadOnly = true;
            this.m_dgvtxtOpnewPrice.Width = 110;
            // 
            // colRetailprice
            // 
            this.colRetailprice.DataPropertyName = "retailprice_int";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colRetailprice.DefaultCellStyle = dataGridViewCellStyle5;
            this.colRetailprice.HeaderText = "初始化零售价";
            this.colRetailprice.Name = "colRetailprice";
            this.colRetailprice.ReadOnly = true;
            this.colRetailprice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colRetailprice.Width = 60;
            // 
            // m_dgvtxtExamdat
            // 
            this.m_dgvtxtExamdat.DataPropertyName = "examdate_dat";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "yyyy-MM-dd";
            dataGridViewCellStyle6.NullValue = null;
            this.m_dgvtxtExamdat.DefaultCellStyle = dataGridViewCellStyle6;
            this.m_dgvtxtExamdat.HeaderText = "生效日期";
            this.m_dgvtxtExamdat.Name = "m_dgvtxtExamdat";
            this.m_dgvtxtExamdat.ReadOnly = true;
            this.m_dgvtxtExamdat.Width = 90;
            // 
            // m_dgvtxtReason
            // 
            this.m_dgvtxtReason.DataPropertyName = "reason_vchr";
            this.m_dgvtxtReason.HeaderText = "  调价依据";
            this.m_dgvtxtReason.Name = "m_dgvtxtReason";
            this.m_dgvtxtReason.ReadOnly = true;
            this.m_dgvtxtReason.Width = 106;
            // 
            // frmRptAdjustpriceRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 746);
            this.Controls.Add(this.m_cboStorageName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_dgvAdjustPrice);
            this.Controls.Add(this.dw);
            this.Controls.Add(this.gradientPanel2);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRptAdjustpriceRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "调价记录查询";
            this.Load += new System.EventHandler(this.frmRptAdjustpriceRecord_Load);
            this.gradientPanel2.ResumeLayout(false);
            this.gradientPanel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvAdjustPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private com.digitalwave.iCare.gui.MedicineStore.GradientPanel gradientPanel2;
        internal com.digitalwave.iCare.gui.MedicineStore_Maintain.exComboBox m_cboStorageName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
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
        internal Sybase.DataWindow.DataWindowControl dw;
        internal System.Windows.Forms.DataGridView m_dgvAdjustPrice;
        internal System.Windows.Forms.TextBox m_txtMedicineCode;
        private System.Windows.Forms.Label label1;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab m_dtpEndDat;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab m_dtpBeginDat;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtAssistcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtOpunit;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtOldPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtNewPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtOpoldPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtOpnewPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRetailprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtExamdat;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtReason;

    }
}