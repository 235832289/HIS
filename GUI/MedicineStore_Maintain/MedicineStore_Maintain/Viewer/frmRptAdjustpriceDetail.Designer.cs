namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    partial class frmRptAdjustpriceDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptAdjustpriceDetail));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gradientPanel2 = new com.digitalwave.iCare.gui.MedicineStore.GradientPanel();
            this.m_dtpEndDat = new com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab(this.components);
            this.m_dtpBeginDat = new com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab(this.components);
            this.m_txtMedicineName = new System.Windows.Forms.TextBox();
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
            this.m_dgvMedicine = new System.Windows.Forms.DataGridView();
            this.m_dgvtxtAssistcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtOleprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtOpNewPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtNewPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtAjustPrice_dat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtEnd_dat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxTremark_vchr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gradientPanel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvMedicine)).BeginInit();
            this.SuspendLayout();
            // 
            // gradientPanel2
            // 
            this.gradientPanel2.Controls.Add(this.m_dtpEndDat);
            this.gradientPanel2.Controls.Add(this.m_dtpBeginDat);
            this.gradientPanel2.Controls.Add(this.m_txtMedicineName);
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
            this.gradientPanel2.Size = new System.Drawing.Size(1028, 43);
            this.gradientPanel2.TabIndex = 10058;
            this.gradientPanel2.VerticalFillPercent = 100F;
            // 
            // m_dtpEndDat
            // 
            this.m_dtpEndDat.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_dtpEndDat.Location = new System.Drawing.Point(288, 11);
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
            this.m_dtpBeginDat.Location = new System.Drawing.Point(80, 11);
            this.m_dtpBeginDat.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日HHmmss;
            this.m_dtpBeginDat.Mask = "0000年90月90日 90:90:90";
            this.m_dtpBeginDat.Name = "m_dtpBeginDat";
            this.m_dtpBeginDat.Size = new System.Drawing.Size(187, 23);
            this.m_dtpBeginDat.TabIndex = 0;
            this.m_dtpBeginDat.ValidatingType = typeof(System.DateTime);
            // 
            // m_txtMedicineName
            // 
            this.m_txtMedicineName.Location = new System.Drawing.Point(742, 12);
            this.m_txtMedicineName.Name = "m_txtMedicineName";
            this.m_txtMedicineName.Size = new System.Drawing.Size(274, 23);
            this.m_txtMedicineName.TabIndex = 3;
            this.m_txtMedicineName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtMedicineName_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(676, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 14);
            this.label5.TabIndex = 10072;
            this.label5.Text = "药品名称:";
            // 
            // m_cboMedicineType
            // 
            this.m_cboMedicineType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboMedicineType.Location = new System.Drawing.Point(548, 12);
            this.m_cboMedicineType.Margin = new System.Windows.Forms.Padding(0);
            this.m_cboMedicineType.Name = "m_cboMedicineType";
            this.m_cboMedicineType.Size = new System.Drawing.Size(122, 22);
            this.m_cboMedicineType.TabIndex = 2;
            this.m_cboMedicineType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_mthEnterToTab);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(3, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 10047;
            this.label6.Text = "统计时间：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(267, 15);
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
            this.m_labExportDept.Location = new System.Drawing.Point(478, 15);
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
            this.toolStrip1.TabIndex = 10057;
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
            this.dw.TabIndex = 10059;
            this.dw.Text = "dataWindowControl1";
            // 
            // m_dgvMedicine
            // 
            this.m_dgvMedicine.AllowUserToAddRows = false;
            this.m_dgvMedicine.AllowUserToOrderColumns = true;
            this.m_dgvMedicine.BackgroundColor = System.Drawing.Color.White;
            this.m_dgvMedicine.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_dgvMedicine.ColumnHeadersHeight = 35;
            this.m_dgvMedicine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgvMedicine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_dgvtxtAssistcode,
            this.m_dgvtxtMedName,
            this.m_dgvtxtSpec,
            this.m_dgvtxtUnit,
            this.m_dgvtxtProduct,
            this.m_dgvtxtOleprice,
            this.m_dgvtxtOpNewPrice,
            this.m_dgvtxtNewPrice,
            this.m_dgvtxtAjustPrice_dat,
            this.m_dgvtxtEnd_dat,
            this.m_dgvtxTremark_vchr});
            this.m_dgvMedicine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvMedicine.Location = new System.Drawing.Point(0, 81);
            this.m_dgvMedicine.Name = "m_dgvMedicine";
            this.m_dgvMedicine.ReadOnly = true;
            this.m_dgvMedicine.RowHeadersVisible = false;
            this.m_dgvMedicine.RowTemplate.Height = 23;
            this.m_dgvMedicine.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvMedicine.Size = new System.Drawing.Size(1028, 665);
            this.m_dgvMedicine.TabIndex = 10060;
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
            this.m_dgvtxtMedName.HeaderText = "       药品名称";
            this.m_dgvtxtMedName.Name = "m_dgvtxtMedName";
            this.m_dgvtxtMedName.ReadOnly = true;
            this.m_dgvtxtMedName.Width = 180;
            // 
            // m_dgvtxtSpec
            // 
            this.m_dgvtxtSpec.DataPropertyName = "medspec_vchr";
            this.m_dgvtxtSpec.HeaderText = "  规格";
            this.m_dgvtxtSpec.Name = "m_dgvtxtSpec";
            this.m_dgvtxtSpec.ReadOnly = true;
            this.m_dgvtxtSpec.Width = 80;
            // 
            // m_dgvtxtUnit
            // 
            this.m_dgvtxtUnit.DataPropertyName = "opunit_vchr";
            this.m_dgvtxtUnit.HeaderText = "单位";
            this.m_dgvtxtUnit.Name = "m_dgvtxtUnit";
            this.m_dgvtxtUnit.ReadOnly = true;
            this.m_dgvtxtUnit.Width = 30;
            // 
            // m_dgvtxtProduct
            // 
            this.m_dgvtxtProduct.DataPropertyName = "productorid_chr";
            this.m_dgvtxtProduct.HeaderText = "   厂家";
            this.m_dgvtxtProduct.Name = "m_dgvtxtProduct";
            this.m_dgvtxtProduct.ReadOnly = true;
            // 
            // m_dgvtxtOleprice
            // 
            this.m_dgvtxtOleprice.DataPropertyName = "opoldprice_int";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N4";
            dataGridViewCellStyle1.NullValue = null;
            this.m_dgvtxtOleprice.DefaultCellStyle = dataGridViewCellStyle1;
            this.m_dgvtxtOleprice.HeaderText = " 原零售价";
            this.m_dgvtxtOleprice.Name = "m_dgvtxtOleprice";
            this.m_dgvtxtOleprice.ReadOnly = true;
            // 
            // m_dgvtxtOpNewPrice
            // 
            this.m_dgvtxtOpNewPrice.DataPropertyName = "newretailprice_int";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N4";
            dataGridViewCellStyle2.NullValue = null;
            this.m_dgvtxtOpNewPrice.DefaultCellStyle = dataGridViewCellStyle2;
            this.m_dgvtxtOpNewPrice.HeaderText = "  零售价格    (包装单位)";
            this.m_dgvtxtOpNewPrice.Name = "m_dgvtxtOpNewPrice";
            this.m_dgvtxtOpNewPrice.ReadOnly = true;
            // 
            // m_dgvtxtNewPrice
            // 
            this.m_dgvtxtNewPrice.DataPropertyName = "opnewprice_int";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N4";
            dataGridViewCellStyle3.NullValue = null;
            this.m_dgvtxtNewPrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.m_dgvtxtNewPrice.HeaderText = "  零售价格    (门诊单位)";
            this.m_dgvtxtNewPrice.Name = "m_dgvtxtNewPrice";
            this.m_dgvtxtNewPrice.ReadOnly = true;
            // 
            // m_dgvtxtAjustPrice_dat
            // 
            this.m_dgvtxtAjustPrice_dat.DataPropertyName = "adjustpricedate_dat";
            dataGridViewCellStyle4.Format = "yyyy-MM-dd HH:mm:ss";
            dataGridViewCellStyle4.NullValue = null;
            this.m_dgvtxtAjustPrice_dat.DefaultCellStyle = dataGridViewCellStyle4;
            this.m_dgvtxtAjustPrice_dat.HeaderText = "      启用日期";
            this.m_dgvtxtAjustPrice_dat.Name = "m_dgvtxtAjustPrice_dat";
            this.m_dgvtxtAjustPrice_dat.ReadOnly = true;
            this.m_dgvtxtAjustPrice_dat.Width = 150;
            // 
            // m_dgvtxtEnd_dat
            // 
            this.m_dgvtxtEnd_dat.DataPropertyName = "enddate_dat";
            dataGridViewCellStyle5.NullValue = null;
            this.m_dgvtxtEnd_dat.DefaultCellStyle = dataGridViewCellStyle5;
            this.m_dgvtxtEnd_dat.HeaderText = "      停用日期";
            this.m_dgvtxtEnd_dat.Name = "m_dgvtxtEnd_dat";
            this.m_dgvtxtEnd_dat.ReadOnly = true;
            this.m_dgvtxtEnd_dat.Width = 150;
            // 
            // m_dgvtxTremark_vchr
            // 
            this.m_dgvtxTremark_vchr.DataPropertyName = "remark_vchr";
            this.m_dgvtxTremark_vchr.HeaderText = "调价原因";
            this.m_dgvtxTremark_vchr.Name = "m_dgvtxTremark_vchr";
            this.m_dgvtxTremark_vchr.ReadOnly = true;
            this.m_dgvtxTremark_vchr.Width = 90;
            // 
            // frmRptAdjustpriceDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 746);
            this.Controls.Add(this.m_dgvMedicine);
            this.Controls.Add(this.dw);
            this.Controls.Add(this.gradientPanel2);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRptAdjustpriceDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "药品调价情况一览表";
            this.Load += new System.EventHandler(this.frmRptAdjustpriceDetail_Load);
            this.gradientPanel2.ResumeLayout(false);
            this.gradientPanel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvMedicine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private com.digitalwave.iCare.gui.MedicineStore.GradientPanel gradientPanel2;
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
        internal com.digitalwave.iCare.gui.MedicineStore_Maintain.exComboBox m_cboMedicineType;
        internal Sybase.DataWindow.DataWindowControl dw;
        internal System.Windows.Forms.DataGridView m_dgvMedicine;
        internal System.Windows.Forms.TextBox m_txtMedicineName;
        private System.Windows.Forms.Label label5;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab m_dtpEndDat;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab m_dtpBeginDat;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtAssistcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtOleprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtOpNewPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtNewPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtAjustPrice_dat;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtEnd_dat;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxTremark_vchr;
    }
}