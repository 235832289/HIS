namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    partial class frmRptInstorageStat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptInstorageStat));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.gradientPanel1 = new com.digitalwave.iCare.gui.HIS.GradientPanel();
            this.m_dtpSearchEndDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab(this.components);
            this.m_dtpSearchBeginDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_rbtCombine = new System.Windows.Forms.RadioButton();
            this.m_rbtSingle = new System.Windows.Forms.RadioButton();
            this.m_txtMedicineCode = new System.Windows.Forms.TextBox();
            this.m_gbBid = new System.Windows.Forms.GroupBox();
            this.m_lblBidYear = new System.Windows.Forms.Label();
            this.m_txtBidYear = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_cboType = new System.Windows.Forms.ComboBox();
            this.m_txtReceiveDept = new com.digitalwave.Controls.Domain.EmrControls.ctlDeptSelected_EnterKeyActive();
            this.txtTypecode = new ControlLibrary.txtListView1(this.components);
            this.txtStoreroom = new ControlLibrary.txtListView1(this.components);
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_labExportDept = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.m_lblTotalAmount = new System.Windows.Forms.Label();
            this.m_lblPriceSum = new System.Windows.Forms.Label();
            this.lblTotalAmout = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dw = new Sybase.DataWindow.DataWindowControl();
            this.m_dgvInstorage = new System.Windows.Forms.DataGridView();
            this.m_txtBidYear2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_dgvtxtMedName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.callprice_int = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.callsum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtretailprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtUNITPRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diffsum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtINSTORAGEID_VCHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtInstoragedat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.standarddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.standard_int = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvSortRowNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.gradientPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.m_gbBid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvInstorage)).BeginInit();
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
            this.toolStrip1.Size = new System.Drawing.Size(1016, 38);
            this.toolStrip1.TabIndex = 4;
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
            this.gradientPanel1.Controls.Add(this.m_dtpSearchEndDate);
            this.gradientPanel1.Controls.Add(this.m_dtpSearchBeginDate);
            this.gradientPanel1.Controls.Add(this.groupBox1);
            this.gradientPanel1.Controls.Add(this.m_gbBid);
            this.gradientPanel1.Controls.Add(this.label4);
            this.gradientPanel1.Controls.Add(this.m_cboType);
            this.gradientPanel1.Controls.Add(this.m_txtReceiveDept);
            this.gradientPanel1.Controls.Add(this.txtTypecode);
            this.gradientPanel1.Controls.Add(this.txtStoreroom);
            this.gradientPanel1.Controls.Add(this.txtProduct);
            this.gradientPanel1.Controls.Add(this.label2);
            this.gradientPanel1.Controls.Add(this.label5);
            this.gradientPanel1.Controls.Add(this.label6);
            this.gradientPanel1.Controls.Add(this.m_labExportDept);
            this.gradientPanel1.Controls.Add(this.label7);
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
            this.gradientPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(1016, 110);
            this.gradientPanel1.TabIndex = 10056;
            this.gradientPanel1.VerticalFillPercent = 100F;
            // 
            // m_dtpSearchEndDate
            // 
            this.m_dtpSearchEndDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_dtpSearchEndDate.Location = new System.Drawing.Point(295, 12);
            this.m_dtpSearchEndDate.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日HHmmss;
            this.m_dtpSearchEndDate.Mask = "0000年90月90日 90:90:90";
            this.m_dtpSearchEndDate.Name = "m_dtpSearchEndDate";
            this.m_dtpSearchEndDate.Size = new System.Drawing.Size(200, 23);
            this.m_dtpSearchEndDate.TabIndex = 1;
            this.m_dtpSearchEndDate.ValidatingType = typeof(System.DateTime);
            // 
            // m_dtpSearchBeginDate
            // 
            this.m_dtpSearchBeginDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_dtpSearchBeginDate.Location = new System.Drawing.Point(70, 12);
            this.m_dtpSearchBeginDate.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日HHmmss;
            this.m_dtpSearchBeginDate.Mask = "0000年90月90日 90:90:90";
            this.m_dtpSearchBeginDate.Name = "m_dtpSearchBeginDate";
            this.m_dtpSearchBeginDate.Size = new System.Drawing.Size(200, 23);
            this.m_dtpSearchBeginDate.TabIndex = 0;
            this.m_dtpSearchBeginDate.ValidatingType = typeof(System.DateTime);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.m_rbtCombine);
            this.groupBox1.Controls.Add(this.m_rbtSingle);
            this.groupBox1.Controls.Add(this.m_txtMedicineCode);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(6, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(493, 41);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "药品";
            // 
            // m_rbtCombine
            // 
            this.m_rbtCombine.AutoSize = true;
            this.m_rbtCombine.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_rbtCombine.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.m_rbtCombine.Location = new System.Drawing.Point(81, 15);
            this.m_rbtCombine.Name = "m_rbtCombine";
            this.m_rbtCombine.Size = new System.Drawing.Size(67, 18);
            this.m_rbtCombine.TabIndex = 1;
            this.m_rbtCombine.TabStop = true;
            this.m_rbtCombine.Text = "单品种";
            this.m_rbtCombine.UseVisualStyleBackColor = true;
            // 
            // m_rbtSingle
            // 
            this.m_rbtSingle.AutoSize = true;
            this.m_rbtSingle.Checked = true;
            this.m_rbtSingle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_rbtSingle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.m_rbtSingle.Location = new System.Drawing.Point(4, 15);
            this.m_rbtSingle.Name = "m_rbtSingle";
            this.m_rbtSingle.Size = new System.Drawing.Size(81, 18);
            this.m_rbtSingle.TabIndex = 0;
            this.m_rbtSingle.TabStop = true;
            this.m_rbtSingle.Text = "具体药品";
            this.m_rbtSingle.UseVisualStyleBackColor = true;
            this.m_rbtSingle.CheckedChanged += new System.EventHandler(this.m_rbtSingle_CheckedChanged);
            // 
            // m_txtMedicineCode
            // 
            this.m_txtMedicineCode.AccessibleDescription = "药品代码";
            this.m_txtMedicineCode.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtMedicineCode.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtMedicineCode.Location = new System.Drawing.Point(154, 12);
            this.m_txtMedicineCode.Name = "m_txtMedicineCode";
            this.m_txtMedicineCode.Size = new System.Drawing.Size(333, 23);
            this.m_txtMedicineCode.TabIndex = 2;
            this.m_txtMedicineCode.TextChanged += new System.EventHandler(this.m_txtMedicineCode_TextChanged);
            this.m_txtMedicineCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtMedicineCode_KeyDown);
            // 
            // m_gbBid
            // 
            this.m_gbBid.BackColor = System.Drawing.Color.Transparent;
            this.m_gbBid.Controls.Add(this.label1);
            this.m_gbBid.Controls.Add(this.m_txtBidYear2);
            this.m_gbBid.Controls.Add(this.m_lblBidYear);
            this.m_gbBid.Controls.Add(this.m_txtBidYear);
            this.m_gbBid.Location = new System.Drawing.Point(751, 12);
            this.m_gbBid.Name = "m_gbBid";
            this.m_gbBid.Size = new System.Drawing.Size(206, 77);
            this.m_gbBid.TabIndex = 9;
            this.m_gbBid.TabStop = false;
            this.m_gbBid.Text = "中标年份";
            // 
            // m_lblBidYear
            // 
            this.m_lblBidYear.AutoSize = true;
            this.m_lblBidYear.BackColor = System.Drawing.Color.Transparent;
            this.m_lblBidYear.Location = new System.Drawing.Point(6, 19);
            this.m_lblBidYear.Name = "m_lblBidYear";
            this.m_lblBidYear.Size = new System.Drawing.Size(35, 14);
            this.m_lblBidYear.TabIndex = 10062;
            this.m_lblBidYear.Text = "包含";
            // 
            // m_txtBidYear
            // 
            this.m_txtBidYear.Location = new System.Drawing.Point(61, 18);
            this.m_txtBidYear.Name = "m_txtBidYear";
            this.m_txtBidYear.Size = new System.Drawing.Size(132, 23);
            this.m_txtBidYear.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(505, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 10060;
            this.label4.Text = "入库类型";
            // 
            // m_cboType
            // 
            this.m_cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboType.FormattingEnabled = true;
            this.m_cboType.Location = new System.Drawing.Point(568, 12);
            this.m_cboType.Name = "m_cboType";
            this.m_cboType.Size = new System.Drawing.Size(168, 22);
            this.m_cboType.TabIndex = 2;
            this.m_cboType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cboType_KeyDown);
            // 
            // m_txtReceiveDept
            // 
            this.m_txtReceiveDept.Location = new System.Drawing.Point(568, 44);
            this.m_txtReceiveDept.m_objTag = null;
            this.m_txtReceiveDept.Name = "m_txtReceiveDept";
            this.m_txtReceiveDept.Size = new System.Drawing.Size(168, 23);
            this.m_txtReceiveDept.TabIndex = 6;
            this.m_txtReceiveDept.显示类型 = com.digitalwave.Controls.Domain.EmrControls.enmDeptAttributeType.全部;
            this.m_txtReceiveDept.FocusNextControl += new System.EventHandler(this.m_txtReceiveDept_FocusNextControl);
            this.m_txtReceiveDept.Leave += new System.EventHandler(this.m_txtReceiveDept_Leave);
            // 
            // txtTypecode
            // 
            this.txtTypecode.AccessibleName = "5";
            this.txtTypecode.findDataMode = ControlLibrary.txtListView1.findMode.fromDataSouse;
            this.txtTypecode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTypecode.Location = new System.Drawing.Point(295, 42);
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
            this.txtTypecode.Size = new System.Drawing.Size(202, 23);
            this.txtTypecode.TabIndex = 4;
            this.txtTypecode.ItemSelectedOK += new ControlLibrary.txtListView1.EventItemSelectedOK(this.txtTypecode_ItemSelectedOK);
            // 
            // txtStoreroom
            // 
            this.txtStoreroom.AccessibleName = "5";
            this.txtStoreroom.findDataMode = ControlLibrary.txtListView1.findMode.fromDataSouse;
            this.txtStoreroom.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtStoreroom.Location = new System.Drawing.Point(70, 42);
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
            this.txtStoreroom.Size = new System.Drawing.Size(162, 23);
            this.txtStoreroom.TabIndex = 3;
            this.txtStoreroom.ItemSelectedOK += new ControlLibrary.txtListView1.EventItemSelectedOK(this.txtStoreroom_ItemSelectedOK);
            // 
            // txtProduct
            // 
            this.txtProduct.Location = new System.Drawing.Point(568, 44);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(168, 23);
            this.txtProduct.TabIndex = 5;
            this.txtProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProduct_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(7, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 10053;
            this.label2.Text = "库房名称";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(3, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 10047;
            this.label5.Text = "统计时间";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(273, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 14);
            this.label6.TabIndex = 10048;
            this.label6.Text = "至";
            // 
            // m_labExportDept
            // 
            this.m_labExportDept.AutoSize = true;
            this.m_labExportDept.BackColor = System.Drawing.Color.Transparent;
            this.m_labExportDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_labExportDept.Location = new System.Drawing.Point(505, 47);
            this.m_labExportDept.Name = "m_labExportDept";
            this.m_labExportDept.Size = new System.Drawing.Size(63, 14);
            this.m_labExportDept.TabIndex = 10049;
            this.m_labExportDept.Text = "来源部门";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(232, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 10051;
            this.label7.Text = "药品分类";
            // 
            // m_lblTotalAmount
            // 
            this.m_lblTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblTotalAmount.AutoSize = true;
            this.m_lblTotalAmount.BackColor = System.Drawing.Color.Transparent;
            this.m_lblTotalAmount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblTotalAmount.ForeColor = System.Drawing.Color.Maroon;
            this.m_lblTotalAmount.Location = new System.Drawing.Point(641, 9);
            this.m_lblTotalAmount.Name = "m_lblTotalAmount";
            this.m_lblTotalAmount.Size = new System.Drawing.Size(31, 14);
            this.m_lblTotalAmount.TabIndex = 10072;
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
            this.m_lblPriceSum.Location = new System.Drawing.Point(762, 9);
            this.m_lblPriceSum.Name = "m_lblPriceSum";
            this.m_lblPriceSum.Size = new System.Drawing.Size(46, 14);
            this.m_lblPriceSum.TabIndex = 10072;
            this.m_lblPriceSum.Text = "0.0元";
            this.m_lblPriceSum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lblPriceSum.Visible = false;
            // 
            // lblTotalAmout
            // 
            this.lblTotalAmout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalAmout.AutoSize = true;
            this.lblTotalAmout.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalAmout.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalAmout.ForeColor = System.Drawing.Color.Maroon;
            this.lblTotalAmout.Location = new System.Drawing.Point(566, 9);
            this.lblTotalAmout.Name = "lblTotalAmout";
            this.lblTotalAmout.Size = new System.Drawing.Size(75, 14);
            this.lblTotalAmout.TabIndex = 7;
            this.lblTotalAmout.Text = "数量总数:";
            this.lblTotalAmout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTotalAmout.Visible = false;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.Color.Maroon;
            this.label13.Location = new System.Drawing.Point(672, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 14);
            this.label13.TabIndex = 10071;
            this.label13.Text = "零售金额￥:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label13.Visible = false;
            // 
            // dw
            // 
            this.dw.DataWindowObject = "";
            this.dw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dw.LibraryList = "";
            this.dw.Location = new System.Drawing.Point(0, 148);
            this.dw.Margin = new System.Windows.Forms.Padding(0);
            this.dw.Name = "dw";
            this.dw.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dw.Size = new System.Drawing.Size(1016, 593);
            this.dw.TabIndex = 10058;
            this.dw.Text = "dataWindowControl1";
            // 
            // m_dgvInstorage
            // 
            this.m_dgvInstorage.AllowUserToAddRows = false;
            this.m_dgvInstorage.AllowUserToOrderColumns = true;
            this.m_dgvInstorage.BackgroundColor = System.Drawing.Color.White;
            this.m_dgvInstorage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_dgvInstorage.ColumnHeadersHeight = 25;
            this.m_dgvInstorage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgvInstorage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_dgvtxtMedName,
            this.m_dgvtxtMedid,
            this.m_dgvtxtSpec,
            this.m_dgvtxtUnit,
            this.m_dgvtxtProduct,
            this.m_dgvtxtamount,
            this.callprice_int,
            this.callsum,
            this.m_dgvtxtretailprice,
            this.m_dgvtxtUNITPRICE,
            this.diffsum,
            this.m_dgvtxtINSTORAGEID_VCHR,
            this.m_dgvtxtInstoragedat,
            this.standarddate,
            this.standard_int,
            this.m_dgvSortRowNo});
            this.m_dgvInstorage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvInstorage.Location = new System.Drawing.Point(0, 148);
            this.m_dgvInstorage.Name = "m_dgvInstorage";
            this.m_dgvInstorage.ReadOnly = true;
            this.m_dgvInstorage.RowHeadersVisible = false;
            this.m_dgvInstorage.RowTemplate.Height = 23;
            this.m_dgvInstorage.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvInstorage.Size = new System.Drawing.Size(1016, 593);
            this.m_dgvInstorage.TabIndex = 10060;
            this.m_dgvInstorage.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.m_dgvInstorage_ColumnHeaderMouseClick);
            this.m_dgvInstorage.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.m_dgvInstorage_ColumnHeaderMouseDoubleClick);
            this.m_dgvInstorage.DragDrop += new System.Windows.Forms.DragEventHandler(this.m_dgvInstorage_DragDrop);
            // 
            // m_txtBidYear2
            // 
            this.m_txtBidYear2.Location = new System.Drawing.Point(61, 47);
            this.m_txtBidYear2.Name = "m_txtBidYear2";
            this.m_txtBidYear2.Size = new System.Drawing.Size(132, 23);
            this.m_txtBidYear2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(6, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 10062;
            this.label1.Text = "不包含";
            // 
            // m_dgvtxtMedName
            // 
            this.m_dgvtxtMedName.DataPropertyName = "MEDICINENAME_VCH";
            this.m_dgvtxtMedName.HeaderText = "             药名";
            this.m_dgvtxtMedName.Name = "m_dgvtxtMedName";
            this.m_dgvtxtMedName.ReadOnly = true;
            this.m_dgvtxtMedName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.m_dgvtxtMedName.Width = 220;
            // 
            // m_dgvtxtMedid
            // 
            this.m_dgvtxtMedid.DataPropertyName = "MEDICINEID_CHR";
            this.m_dgvtxtMedid.HeaderText = "药品id";
            this.m_dgvtxtMedid.Name = "m_dgvtxtMedid";
            this.m_dgvtxtMedid.ReadOnly = true;
            this.m_dgvtxtMedid.Visible = false;
            // 
            // m_dgvtxtSpec
            // 
            this.m_dgvtxtSpec.DataPropertyName = "MEDSPEC_VCHR";
            this.m_dgvtxtSpec.HeaderText = "  规格";
            this.m_dgvtxtSpec.Name = "m_dgvtxtSpec";
            this.m_dgvtxtSpec.ReadOnly = true;
            this.m_dgvtxtSpec.Width = 120;
            // 
            // m_dgvtxtUnit
            // 
            this.m_dgvtxtUnit.DataPropertyName = "unit";
            this.m_dgvtxtUnit.HeaderText = "单位";
            this.m_dgvtxtUnit.Name = "m_dgvtxtUnit";
            this.m_dgvtxtUnit.ReadOnly = true;
            this.m_dgvtxtUnit.Width = 45;
            // 
            // m_dgvtxtProduct
            // 
            this.m_dgvtxtProduct.DataPropertyName = "PRODUCTORID_CHR";
            this.m_dgvtxtProduct.HeaderText = "    厂家";
            this.m_dgvtxtProduct.Name = "m_dgvtxtProduct";
            this.m_dgvtxtProduct.ReadOnly = true;
            // 
            // m_dgvtxtamount
            // 
            this.m_dgvtxtamount.DataPropertyName = "AMOUNT";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.m_dgvtxtamount.DefaultCellStyle = dataGridViewCellStyle1;
            this.m_dgvtxtamount.HeaderText = "    数量";
            this.m_dgvtxtamount.Name = "m_dgvtxtamount";
            this.m_dgvtxtamount.ReadOnly = true;
            this.m_dgvtxtamount.Width = 80;
            // 
            // callprice_int
            // 
            this.callprice_int.DataPropertyName = "callprice_int";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N4";
            dataGridViewCellStyle2.NullValue = null;
            this.callprice_int.DefaultCellStyle = dataGridViewCellStyle2;
            this.callprice_int.HeaderText = "  购入单价";
            this.callprice_int.Name = "callprice_int";
            this.callprice_int.ReadOnly = true;
            this.callprice_int.Width = 85;
            // 
            // callsum
            // 
            this.callsum.DataPropertyName = "callsum";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N4";
            dataGridViewCellStyle3.NullValue = "0";
            this.callsum.DefaultCellStyle = dataGridViewCellStyle3;
            this.callsum.HeaderText = "  购入金额";
            this.callsum.Name = "callsum";
            this.callsum.ReadOnly = true;
            // 
            // m_dgvtxtretailprice
            // 
            this.m_dgvtxtretailprice.DataPropertyName = "retailprice";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N4";
            dataGridViewCellStyle4.NullValue = null;
            this.m_dgvtxtretailprice.DefaultCellStyle = dataGridViewCellStyle4;
            this.m_dgvtxtretailprice.HeaderText = "  零售单价";
            this.m_dgvtxtretailprice.Name = "m_dgvtxtretailprice";
            this.m_dgvtxtretailprice.ReadOnly = true;
            this.m_dgvtxtretailprice.Width = 85;
            // 
            // m_dgvtxtUNITPRICE
            // 
            this.m_dgvtxtUNITPRICE.DataPropertyName = "UNITPRICE";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N4";
            dataGridViewCellStyle5.NullValue = null;
            this.m_dgvtxtUNITPRICE.DefaultCellStyle = dataGridViewCellStyle5;
            this.m_dgvtxtUNITPRICE.HeaderText = "  零售金额";
            this.m_dgvtxtUNITPRICE.Name = "m_dgvtxtUNITPRICE";
            this.m_dgvtxtUNITPRICE.ReadOnly = true;
            // 
            // diffsum
            // 
            this.diffsum.DataPropertyName = "diffsum";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N4";
            dataGridViewCellStyle6.NullValue = "0";
            this.diffsum.DefaultCellStyle = dataGridViewCellStyle6;
            this.diffsum.HeaderText = "  购零差额";
            this.diffsum.Name = "diffsum";
            this.diffsum.ReadOnly = true;
            // 
            // m_dgvtxtINSTORAGEID_VCHR
            // 
            this.m_dgvtxtINSTORAGEID_VCHR.DataPropertyName = "INSTORAGEID_VCHR";
            this.m_dgvtxtINSTORAGEID_VCHR.HeaderText = "   单据号";
            this.m_dgvtxtINSTORAGEID_VCHR.Name = "m_dgvtxtINSTORAGEID_VCHR";
            this.m_dgvtxtINSTORAGEID_VCHR.ReadOnly = true;
            // 
            // m_dgvtxtInstoragedat
            // 
            this.m_dgvtxtInstoragedat.DataPropertyName = "INSTORAGEDATE_DAT";
            dataGridViewCellStyle7.Format = "yyyy-MM-dd HH:mm:ss";
            dataGridViewCellStyle7.NullValue = null;
            this.m_dgvtxtInstoragedat.DefaultCellStyle = dataGridViewCellStyle7;
            this.m_dgvtxtInstoragedat.HeaderText = "    入库时间";
            this.m_dgvtxtInstoragedat.Name = "m_dgvtxtInstoragedat";
            this.m_dgvtxtInstoragedat.ReadOnly = true;
            this.m_dgvtxtInstoragedat.Width = 145;
            // 
            // standarddate
            // 
            this.standarddate.DataPropertyName = "standarddate";
            this.standarddate.HeaderText = "中标年份";
            this.standarddate.Name = "standarddate";
            this.standarddate.ReadOnly = true;
            this.standarddate.Width = 150;
            // 
            // standard_int
            // 
            this.standard_int.DataPropertyName = "standard_int";
            this.standard_int.HeaderText = "是否中标";
            this.standard_int.Name = "standard_int";
            this.standard_int.ReadOnly = true;
            this.standard_int.Visible = false;
            this.standard_int.Width = 85;
            // 
            // m_dgvSortRowNo
            // 
            this.m_dgvSortRowNo.DataPropertyName = "SortRowNo";
            this.m_dgvSortRowNo.HeaderText = "排序号";
            this.m_dgvSortRowNo.Name = "m_dgvSortRowNo";
            this.m_dgvSortRowNo.ReadOnly = true;
            this.m_dgvSortRowNo.Visible = false;
            // 
            // frmRptInstorageStat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 741);
            this.Controls.Add(this.m_lblTotalAmount);
            this.Controls.Add(this.m_lblPriceSum);
            this.Controls.Add(this.lblTotalAmout);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.m_dgvInstorage);
            this.Controls.Add(this.dw);
            this.Controls.Add(this.gradientPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRptInstorageStat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "药品入库统计";
            this.Load += new System.EventHandler(this.frmRptInstorageStat_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.m_gbBid.ResumeLayout(false);
            this.m_gbBid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvInstorage)).EndInit();
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
        private com.digitalwave.iCare.gui.HIS.GradientPanel gradientPanel1;
        internal ControlLibrary.txtListView1 txtTypecode;
        internal ControlLibrary.txtListView1 txtStoreroom;
        internal System.Windows.Forms.TextBox txtProduct;
        internal System.Windows.Forms.TextBox m_txtMedicineCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label m_labExportDept;
        private System.Windows.Forms.Label label7;
        internal Sybase.DataWindow.DataWindowControl dw;
        internal com.digitalwave.Controls.Domain.EmrControls.ctlDeptSelected_EnterKeyActive m_txtReceiveDept;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox m_cboType;
        internal System.Windows.Forms.DataGridView m_dgvInstorage;
        private System.Windows.Forms.Label label13;
        internal System.Windows.Forms.Label m_lblPriceSum;
        private System.Windows.Forms.Label m_lblBidYear;
        internal System.Windows.Forms.GroupBox m_gbBid;
        internal System.Windows.Forms.TextBox m_txtBidYear;
        internal System.Windows.Forms.Label m_lblTotalAmount;
        internal System.Windows.Forms.Label lblTotalAmout;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.RadioButton m_rbtCombine;
        internal System.Windows.Forms.RadioButton m_rbtSingle;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab m_dtpSearchEndDate;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab m_dtpSearchBeginDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedid;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtamount;
        private System.Windows.Forms.DataGridViewTextBoxColumn callprice_int;
        private System.Windows.Forms.DataGridViewTextBoxColumn callsum;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtretailprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtUNITPRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn diffsum;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtINSTORAGEID_VCHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtInstoragedat;
        private System.Windows.Forms.DataGridViewTextBoxColumn standarddate;
        private System.Windows.Forms.DataGridViewTextBoxColumn standard_int;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvSortRowNo;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox m_txtBidYear2;
    }
}