namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    partial class frmRptOutstorageStat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptOutstorageStat));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
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
            this.gradientPanel1 = new com.digitalwave.iCare.gui.MedicineStore.GradientPanel();
            this.m_txtDept = new com.digitalwave.Controls.Domain.EmrControls.ctlDeptSelected_EnterKeyActive();
            this.label26 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_cboType = new System.Windows.Forms.ComboBox();
            this.txtTypecode = new ControlLibrary.txtListView1(this.components);
            this.txtStoreroom = new ControlLibrary.txtListView1(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_dtpSearchBeginDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.m_dtpSearchEndDate = new System.Windows.Forms.DateTimePicker();
            this.m_txtMedicineCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dw = new Sybase.DataWindow.DataWindowControl();
            this.m_dgvOutstorage = new System.Windows.Forms.DataGridView();
            this.m_lblTotalAmount = new System.Windows.Forms.Label();
            this.m_lblPriceSum = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.Label = new System.Windows.Forms.Label();
            this.m_dgvtxtMedName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtRetailPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtOutstorageid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtOutdat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvSortRowNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.gradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvOutstorage)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Shell32 023.ico");
            this.imageList1.Images.SetKeyName(1, "Shell32 017.ico");
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
            this.toolStrip1.TabIndex = 10060;
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
            // gradientPanel1
            // 
            this.gradientPanel1.Controls.Add(this.m_txtDept);
            this.gradientPanel1.Controls.Add(this.label26);
            this.gradientPanel1.Controls.Add(this.label4);
            this.gradientPanel1.Controls.Add(this.m_cboType);
            this.gradientPanel1.Controls.Add(this.txtTypecode);
            this.gradientPanel1.Controls.Add(this.txtStoreroom);
            this.gradientPanel1.Controls.Add(this.label3);
            this.gradientPanel1.Controls.Add(this.label5);
            this.gradientPanel1.Controls.Add(this.m_dtpSearchBeginDate);
            this.gradientPanel1.Controls.Add(this.label6);
            this.gradientPanel1.Controls.Add(this.m_dtpSearchEndDate);
            this.gradientPanel1.Controls.Add(this.m_txtMedicineCode);
            this.gradientPanel1.Controls.Add(this.label7);
            this.gradientPanel1.Controls.Add(this.label10);
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel1.Flip = false;
            this.gradientPanel1.FloatingImage = null;
            this.gradientPanel1.GradientAngle = 90;
            this.gradientPanel1.GradientEndColor = System.Drawing.SystemColors.Control;
            this.gradientPanel1.GradientStartColor = System.Drawing.Color.White;
            this.gradientPanel1.HorizontalFillPercent = 100F;
            this.gradientPanel1.imageXOffset = 0;
            this.gradientPanel1.imageYOffset = 0;
            this.gradientPanel1.Location = new System.Drawing.Point(0, 38);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(1012, 80);
            this.gradientPanel1.TabIndex = 10061;
            this.gradientPanel1.VerticalFillPercent = 100F;
            // 
            // m_txtDept
            // 
            this.m_txtDept.Location = new System.Drawing.Point(597, 44);
            this.m_txtDept.m_objTag = null;
            this.m_txtDept.Name = "m_txtDept";
            this.m_txtDept.Size = new System.Drawing.Size(187, 23);
            this.m_txtDept.TabIndex = 10064;
            this.m_txtDept.显示类型 = com.digitalwave.Controls.Domain.EmrControls.enmDeptAttributeType.全部;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Location = new System.Drawing.Point(528, 49);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(70, 14);
            this.label26.TabIndex = 10063;
            this.label26.Text = "领用部门:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(790, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 10062;
            this.label4.Text = "出库类型:";
            // 
            // m_cboType
            // 
            this.m_cboType.FormattingEnabled = true;
            this.m_cboType.Location = new System.Drawing.Point(859, 9);
            this.m_cboType.Name = "m_cboType";
            this.m_cboType.Size = new System.Drawing.Size(121, 22);
            this.m_cboType.TabIndex = 3;
            // 
            // txtTypecode
            // 
            this.txtTypecode.AccessibleName = "5";
            this.txtTypecode.findDataMode = ControlLibrary.txtListView1.findMode.fromDataSouse;
            this.txtTypecode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTypecode.Location = new System.Drawing.Point(82, 44);
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
            this.txtTypecode.Size = new System.Drawing.Size(177, 23);
            this.txtTypecode.TabIndex = 4;
            this.txtTypecode.ItemSelectedOK += new ControlLibrary.txtListView1.EventItemSelectedOK(this.txtTypecode_ItemSelectedOK);
            // 
            // txtStoreroom
            // 
            this.txtStoreroom.AccessibleName = "5";
            this.txtStoreroom.findDataMode = ControlLibrary.txtListView1.findMode.fromDataSouse;
            this.txtStoreroom.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtStoreroom.Location = new System.Drawing.Point(597, 9);
            this.txtStoreroom.m_blnFocuseShow = true;
            this.txtStoreroom.m_blnPagination = false;
            this.txtStoreroom.m_dtbDataSourse = null;
            this.txtStoreroom.m_intDelayTime = 100;
            this.txtStoreroom.m_intPageRows = 10;
            this.txtStoreroom.m_ListViewAlign = ControlLibrary.txtListView1.ListViewAlign.LeftBottom;
            this.txtStoreroom.m_listViewSize = new System.Drawing.Point(146, 150);
            this.txtStoreroom.m_strFieldsArr = new string[] {
        "entcode_chr",
        "entname_vchr"};
            this.txtStoreroom.m_strSaveField = "medicineroomid";
            this.txtStoreroom.m_strShowField = "medicineroomname";
            this.txtStoreroom.m_strSQL = null;
            this.txtStoreroom.Name = "txtStoreroom";
            this.txtStoreroom.Size = new System.Drawing.Size(187, 23);
            this.txtStoreroom.TabIndex = 2;
            this.txtStoreroom.ItemSelectedOK += new ControlLibrary.txtListView1.EventItemSelectedOK(this.txtStoreroom_ItemSelectedOK);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(547, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 10053;
            this.label3.Text = "库房：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(265, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 14);
            this.label5.TabIndex = 10057;
            this.label5.Text = "药品：";
            // 
            // m_dtpSearchBeginDate
            // 
            this.m_dtpSearchBeginDate.CustomFormat = "yyyy年MM月dd日HH时mm分ss秒";
            this.m_dtpSearchBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpSearchBeginDate.Location = new System.Drawing.Point(82, 9);
            this.m_dtpSearchBeginDate.Name = "m_dtpSearchBeginDate";
            this.m_dtpSearchBeginDate.Size = new System.Drawing.Size(205, 23);
            this.m_dtpSearchBeginDate.TabIndex = 0;
            this.m_dtpSearchBeginDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_dtpSearchBeginDate_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(8, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 10047;
            this.label6.Text = "统计时间：";
            // 
            // m_dtpSearchEndDate
            // 
            this.m_dtpSearchEndDate.CustomFormat = "yyyy年MM月dd日HH时mm分ss秒";
            this.m_dtpSearchEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpSearchEndDate.Location = new System.Drawing.Point(313, 8);
            this.m_dtpSearchEndDate.Name = "m_dtpSearchEndDate";
            this.m_dtpSearchEndDate.Size = new System.Drawing.Size(205, 23);
            this.m_dtpSearchEndDate.TabIndex = 1;
            // 
            // m_txtMedicineCode
            // 
            this.m_txtMedicineCode.AccessibleDescription = "药品代码";
            this.m_txtMedicineCode.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtMedicineCode.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtMedicineCode.Location = new System.Drawing.Point(313, 44);
            this.m_txtMedicineCode.Name = "m_txtMedicineCode";
            this.m_txtMedicineCode.Size = new System.Drawing.Size(205, 23);
            this.m_txtMedicineCode.TabIndex = 5;
            this.m_txtMedicineCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtMedicineCode_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(293, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 14);
            this.label7.TabIndex = 10048;
            this.label7.Text = "~";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(8, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 14);
            this.label10.TabIndex = 10051;
            this.label10.Text = "药品类别：";
            // 
            // dw
            // 
            this.dw.DataWindowObject = "";
            this.dw.LibraryList = "";
            this.dw.Location = new System.Drawing.Point(0, 124);
            this.dw.Name = "dw";
            this.dw.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dw.Size = new System.Drawing.Size(1004, 542);
            this.dw.TabIndex = 10062;
            this.dw.Text = "药品出库统计";
            // 
            // m_dgvOutstorage
            // 
            this.m_dgvOutstorage.AllowUserToAddRows = false;
            this.m_dgvOutstorage.AllowUserToOrderColumns = true;
            this.m_dgvOutstorage.BackgroundColor = System.Drawing.Color.White;
            this.m_dgvOutstorage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_dgvOutstorage.ColumnHeadersHeight = 25;
            this.m_dgvOutstorage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgvOutstorage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_dgvtxtMedName,
            this.m_dgvtxtSpec,
            this.m_dgvtxtUnit,
            this.m_dgvtxtProduct,
            this.m_dgvtxtAmount,
            this.m_dgvtxtRetailPrice,
            this.m_dgvtxtOutstorageid,
            this.m_dgvtxtOutdat,
            this.m_dgvSortRowNo});
            this.m_dgvOutstorage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvOutstorage.Location = new System.Drawing.Point(0, 118);
            this.m_dgvOutstorage.Name = "m_dgvOutstorage";
            this.m_dgvOutstorage.ReadOnly = true;
            this.m_dgvOutstorage.RowHeadersVisible = false;
            this.m_dgvOutstorage.RowTemplate.Height = 23;
            this.m_dgvOutstorage.Size = new System.Drawing.Size(1012, 520);
            this.m_dgvOutstorage.TabIndex = 10063;
            this.m_dgvOutstorage.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.m_dgvOutstorage_ColumnHeaderMouseDoubleClick);
            this.m_dgvOutstorage.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.m_dgvOutstorage_ColumnHeaderMouseClick);
            // 
            // m_lblTotalAmount
            // 
            this.m_lblTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblTotalAmount.AutoSize = true;
            this.m_lblTotalAmount.BackColor = System.Drawing.Color.Transparent;
            this.m_lblTotalAmount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblTotalAmount.ForeColor = System.Drawing.Color.Maroon;
            this.m_lblTotalAmount.Location = new System.Drawing.Point(594, 621);
            this.m_lblTotalAmount.Name = "m_lblTotalAmount";
            this.m_lblTotalAmount.Size = new System.Drawing.Size(31, 14);
            this.m_lblTotalAmount.TabIndex = 10081;
            this.m_lblTotalAmount.Text = "0.0";
            this.m_lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lblTotalAmount.Visible = false;
            // 
            // m_lblPriceSum
            // 
            this.m_lblPriceSum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblPriceSum.AutoSize = true;
            this.m_lblPriceSum.BackColor = System.Drawing.Color.Transparent;
            this.m_lblPriceSum.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblPriceSum.ForeColor = System.Drawing.Color.Maroon;
            this.m_lblPriceSum.Location = new System.Drawing.Point(807, 595);
            this.m_lblPriceSum.Name = "m_lblPriceSum";
            this.m_lblPriceSum.Size = new System.Drawing.Size(46, 14);
            this.m_lblPriceSum.TabIndex = 10082;
            this.m_lblPriceSum.Text = "0.0元";
            this.m_lblPriceSum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lblPriceSum.Visible = false;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalAmount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.Maroon;
            this.lblTotalAmount.Location = new System.Drawing.Point(510, 621);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(75, 14);
            this.lblTotalAmount.TabIndex = 10079;
            this.lblTotalAmount.Text = "数量总数:";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTotalAmount.Visible = false;
            // 
            // Label
            // 
            this.Label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Label.AutoSize = true;
            this.Label.BackColor = System.Drawing.Color.Transparent;
            this.Label.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label.ForeColor = System.Drawing.Color.Maroon;
            this.Label.Location = new System.Drawing.Point(723, 595);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(90, 14);
            this.Label.TabIndex = 10080;
            this.Label.Text = "零售金额￥:";
            this.Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Label.Visible = false;
            // 
            // m_dgvtxtMedName
            // 
            this.m_dgvtxtMedName.DataPropertyName = "medicinename_vch";
            this.m_dgvtxtMedName.HeaderText = "                  药名";
            this.m_dgvtxtMedName.Name = "m_dgvtxtMedName";
            this.m_dgvtxtMedName.ReadOnly = true;
            this.m_dgvtxtMedName.Width = 295;
            // 
            // m_dgvtxtSpec
            // 
            this.m_dgvtxtSpec.DataPropertyName = "medspec_vchr";
            this.m_dgvtxtSpec.HeaderText = "  规格";
            this.m_dgvtxtSpec.Name = "m_dgvtxtSpec";
            this.m_dgvtxtSpec.ReadOnly = true;
            this.m_dgvtxtSpec.Width = 70;
            // 
            // m_dgvtxtUnit
            // 
            this.m_dgvtxtUnit.DataPropertyName = "opunit_chr";
            this.m_dgvtxtUnit.HeaderText = "单位";
            this.m_dgvtxtUnit.Name = "m_dgvtxtUnit";
            this.m_dgvtxtUnit.ReadOnly = true;
            this.m_dgvtxtUnit.Width = 45;
            // 
            // m_dgvtxtProduct
            // 
            this.m_dgvtxtProduct.DataPropertyName = "productorid_chr";
            this.m_dgvtxtProduct.HeaderText = "    厂家";
            this.m_dgvtxtProduct.Name = "m_dgvtxtProduct";
            this.m_dgvtxtProduct.ReadOnly = true;
            this.m_dgvtxtProduct.Width = 120;
            // 
            // m_dgvtxtAmount
            // 
            this.m_dgvtxtAmount.DataPropertyName = "netamount_int";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.m_dgvtxtAmount.DefaultCellStyle = dataGridViewCellStyle1;
            this.m_dgvtxtAmount.HeaderText = "    数量";
            this.m_dgvtxtAmount.Name = "m_dgvtxtAmount";
            this.m_dgvtxtAmount.ReadOnly = true;
            // 
            // m_dgvtxtRetailPrice
            // 
            this.m_dgvtxtRetailPrice.DataPropertyName = "retailsum";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N4";
            dataGridViewCellStyle2.NullValue = null;
            this.m_dgvtxtRetailPrice.DefaultCellStyle = dataGridViewCellStyle2;
            this.m_dgvtxtRetailPrice.HeaderText = "   零售金额";
            this.m_dgvtxtRetailPrice.Name = "m_dgvtxtRetailPrice";
            this.m_dgvtxtRetailPrice.ReadOnly = true;
            this.m_dgvtxtRetailPrice.Width = 120;
            // 
            // m_dgvtxtOutstorageid
            // 
            this.m_dgvtxtOutstorageid.DataPropertyName = "outstorageid_vchr";
            this.m_dgvtxtOutstorageid.HeaderText = "   单据号";
            this.m_dgvtxtOutstorageid.Name = "m_dgvtxtOutstorageid";
            this.m_dgvtxtOutstorageid.ReadOnly = true;
            // 
            // m_dgvtxtOutdat
            // 
            this.m_dgvtxtOutdat.DataPropertyName = "outstoragedate_dat";
            dataGridViewCellStyle3.Format = "yyyy-MM-dd HH:mm:ss";
            this.m_dgvtxtOutdat.DefaultCellStyle = dataGridViewCellStyle3;
            this.m_dgvtxtOutdat.HeaderText = "     出库日期";
            this.m_dgvtxtOutdat.Name = "m_dgvtxtOutdat";
            this.m_dgvtxtOutdat.ReadOnly = true;
            this.m_dgvtxtOutdat.Width = 150;
            // 
            // m_dgvSortRowNo
            // 
            this.m_dgvSortRowNo.DataPropertyName = "SortRowNo";
            this.m_dgvSortRowNo.HeaderText = "排序号";
            this.m_dgvSortRowNo.Name = "m_dgvSortRowNo";
            this.m_dgvSortRowNo.ReadOnly = true;
            this.m_dgvSortRowNo.Visible = false;
            // 
            // frmRptOutstorageStat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 638);
            this.Controls.Add(this.m_lblTotalAmount);
            this.Controls.Add(this.m_lblPriceSum);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.Label);
            this.Controls.Add(this.m_dgvOutstorage);
            this.Controls.Add(this.gradientPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dw);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRptOutstorageStat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "药品出库统计";
            this.Load += new System.EventHandler(this.frmRptOutstorageStat_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvOutstorage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
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
        private com.digitalwave.iCare.gui.MedicineStore.GradientPanel gradientPanel1;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox m_cboType;
        internal ControlLibrary.txtListView1 txtTypecode;
        internal ControlLibrary.txtListView1 txtStoreroom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.DateTimePicker m_dtpSearchBeginDate;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.DateTimePicker m_dtpSearchEndDate;
        internal System.Windows.Forms.TextBox m_txtMedicineCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        internal Sybase.DataWindow.DataWindowControl dw;
        internal System.Windows.Forms.DataGridView m_dgvOutstorage;
        internal System.Windows.Forms.Label m_lblTotalAmount;
        internal System.Windows.Forms.Label m_lblPriceSum;
        internal System.Windows.Forms.Label lblTotalAmount;
        internal System.Windows.Forms.Label Label;
        internal com.digitalwave.Controls.Domain.EmrControls.ctlDeptSelected_EnterKeyActive m_txtDept;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtRetailPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtOutstorageid;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtOutdat;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvSortRowNo;
    }
}