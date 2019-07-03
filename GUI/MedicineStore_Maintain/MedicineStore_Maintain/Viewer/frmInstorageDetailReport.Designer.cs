namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    partial class frmInstorageDetailReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInstorageDetailReport));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.m_bgwGetMedicine = new System.ComponentModel.BackgroundWorker();
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
            this.m_dtpEndDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab(this.components);
            this.m_dtpBeginDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_rbtCombine = new System.Windows.Forms.RadioButton();
            this.m_rbtSingle = new System.Windows.Forms.RadioButton();
            this.m_txtMedicine = new System.Windows.Forms.TextBox();
            this.txtTypecode = new ControlLibrary.txtListView1(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.m_txtReceiveDept = new com.digitalwave.Controls.Domain.EmrControls.ctlDeptSelected_EnterKeyActive();
            this.label4 = new System.Windows.Forms.Label();
            this.m_cboType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtVendor = new System.Windows.Forms.TextBox();
            this.m_dwcData = new Sybase.DataWindow.DataWindowControl();
            this.m_dgvInstorageDetail = new System.Windows.Forms.DataGridView();
            this.m_lblPriceSum = new System.Windows.Forms.Label();
            this.Label = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.m_lblTotalAmount = new System.Windows.Forms.Label();
            this.m_dgvtxtInstoragedat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtLotno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtvalidperiod_chr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtvendorname_vchr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.callprice_int = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.callsum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtretailprice_int = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtretailsum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtremain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtinvoicecode_vchr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtcomedate_vchr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtinstorageid_vchr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxttypename_vchr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtramark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvSortRowNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.gradientPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvInstorageDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Shell32 023.ico");
            this.imageList1.Images.SetKeyName(1, "Shell32 017.ico");
            // 
            // m_bgwGetMedicine
            // 
            this.m_bgwGetMedicine.DoWork += new System.ComponentModel.DoWorkEventHandler(this.m_bgwGetMedicine_DoWork);
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
            this.toolStrip1.TabIndex = 10025;
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
            this.gradientPanel1.Controls.Add(this.m_dtpEndDate);
            this.gradientPanel1.Controls.Add(this.m_dtpBeginDate);
            this.gradientPanel1.Controls.Add(this.groupBox1);
            this.gradientPanel1.Controls.Add(this.txtTypecode);
            this.gradientPanel1.Controls.Add(this.label7);
            this.gradientPanel1.Controls.Add(this.m_txtReceiveDept);
            this.gradientPanel1.Controls.Add(this.label4);
            this.gradientPanel1.Controls.Add(this.m_cboType);
            this.gradientPanel1.Controls.Add(this.label5);
            this.gradientPanel1.Controls.Add(this.label6);
            this.gradientPanel1.Controls.Add(this.label3);
            this.gradientPanel1.Controls.Add(this.m_txtVendor);
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
            this.gradientPanel1.Size = new System.Drawing.Size(1016, 74);
            this.gradientPanel1.TabIndex = 0;
            this.gradientPanel1.VerticalFillPercent = 100F;
            // 
            // m_dtpEndDate
            // 
            this.m_dtpEndDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_dtpEndDate.Location = new System.Drawing.Point(276, 13);
            this.m_dtpEndDate.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日HHmmss;
            this.m_dtpEndDate.Mask = "0000年90月90日 90:90:90";
            this.m_dtpEndDate.Name = "m_dtpEndDate";
            this.m_dtpEndDate.Size = new System.Drawing.Size(187, 23);
            this.m_dtpEndDate.TabIndex = 1;
            this.m_dtpEndDate.ValidatingType = typeof(System.DateTime);
            // 
            // m_dtpBeginDate
            // 
            this.m_dtpBeginDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_dtpBeginDate.Location = new System.Drawing.Point(75, 13);
            this.m_dtpBeginDate.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日HHmmss;
            this.m_dtpBeginDate.Mask = "0000年90月90日 90:90:90";
            this.m_dtpBeginDate.Name = "m_dtpBeginDate";
            this.m_dtpBeginDate.Size = new System.Drawing.Size(187, 23);
            this.m_dtpBeginDate.TabIndex = 0;
            this.m_dtpBeginDate.ValidatingType = typeof(System.DateTime);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.m_rbtCombine);
            this.groupBox1.Controls.Add(this.m_rbtSingle);
            this.groupBox1.Controls.Add(this.m_txtMedicine);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(275, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(447, 36);
            this.groupBox1.TabIndex = 10075;
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
            this.m_rbtSingle.CheckedChanged += new System.EventHandler(this.m_rbtSingle_CheckedChanged);
            // 
            // m_txtMedicine
            // 
            this.m_txtMedicine.AccessibleDescription = "药品代码";
            this.m_txtMedicine.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtMedicine.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtMedicine.Location = new System.Drawing.Point(150, 10);
            this.m_txtMedicine.Name = "m_txtMedicine";
            this.m_txtMedicine.Size = new System.Drawing.Size(292, 23);
            this.m_txtMedicine.TabIndex = 2;
            this.m_txtMedicine.Leave += new System.EventHandler(this.m_txtMedicine_Leave);
            this.m_txtMedicine.TextChanged += new System.EventHandler(this.m_txtMedicine_TextChanged);
            this.m_txtMedicine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtMedicine_KeyDown);
            // 
            // txtTypecode
            // 
            this.txtTypecode.AccessibleName = "5";
            this.txtTypecode.findDataMode = ControlLibrary.txtListView1.findMode.fromDataSouse;
            this.txtTypecode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTypecode.Location = new System.Drawing.Point(74, 45);
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
            this.txtTypecode.Size = new System.Drawing.Size(187, 23);
            this.txtTypecode.TabIndex = 4;
            this.txtTypecode.ItemSelectedOK += new ControlLibrary.txtListView1.EventItemSelectedOK(this.txtTypecode_ItemSelectedOK);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(12, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 10053;
            this.label7.Text = "药品分类";
            // 
            // m_txtReceiveDept
            // 
            this.m_txtReceiveDept.Location = new System.Drawing.Point(719, 13);
            this.m_txtReceiveDept.m_objTag = null;
            this.m_txtReceiveDept.Name = "m_txtReceiveDept";
            this.m_txtReceiveDept.Size = new System.Drawing.Size(246, 23);
            this.m_txtReceiveDept.TabIndex = 3;
            this.m_txtReceiveDept.显示类型 = com.digitalwave.Controls.Domain.EmrControls.enmDeptAttributeType.全部;
            this.m_txtReceiveDept.FocusNextControl += new System.EventHandler(this.m_txtReceiveDept_FocusNextControl);
            this.m_txtReceiveDept.Leave += new System.EventHandler(this.m_txtReceiveDept_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(466, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 187;
            this.label4.Text = "入库类型";
            // 
            // m_cboType
            // 
            this.m_cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboType.FormattingEnabled = true;
            this.m_cboType.Location = new System.Drawing.Point(529, 13);
            this.m_cboType.Name = "m_cboType";
            this.m_cboType.Size = new System.Drawing.Size(121, 22);
            this.m_cboType.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(12, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 173;
            this.label5.Text = "入库日期";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(262, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 14);
            this.label6.TabIndex = 173;
            this.label6.Text = "~";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(656, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "供货单位";
            // 
            // m_txtVendor
            // 
            this.m_txtVendor.Location = new System.Drawing.Point(719, 13);
            this.m_txtVendor.Name = "m_txtVendor";
            this.m_txtVendor.Size = new System.Drawing.Size(246, 23);
            this.m_txtVendor.TabIndex = 4;
            this.m_txtVendor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtVendor_KeyDown);
            // 
            // m_dwcData
            // 
            this.m_dwcData.DataWindowObject = "ms_instoragedetailreport";
            this.m_dwcData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dwcData.LibraryList = "";
            this.m_dwcData.Location = new System.Drawing.Point(0, 112);
            this.m_dwcData.Name = "m_dwcData";
            this.m_dwcData.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.m_dwcData.Size = new System.Drawing.Size(1016, 496);
            this.m_dwcData.TabIndex = 10027;
            this.m_dwcData.Text = "dataWindowControl1";
            // 
            // m_dgvInstorageDetail
            // 
            this.m_dgvInstorageDetail.AllowUserToAddRows = false;
            this.m_dgvInstorageDetail.AllowUserToOrderColumns = true;
            this.m_dgvInstorageDetail.BackgroundColor = System.Drawing.Color.White;
            this.m_dgvInstorageDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_dgvInstorageDetail.ColumnHeadersHeight = 25;
            this.m_dgvInstorageDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgvInstorageDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_dgvtxtInstoragedat,
            this.m_dgvtxtMedName,
            this.m_dgvtxtSpec,
            this.m_dgvtxtUnit,
            this.m_dgvtxtProduct,
            this.m_dgvtxtLotno,
            this.m_dgvtxtvalidperiod_chr,
            this.m_dgvtxtvendorname_vchr,
            this.m_dgvtxtamount,
            this.callprice_int,
            this.callsum,
            this.m_dgvtxtretailprice_int,
            this.m_dgvtxtretailsum,
            this.m_dgvtxtremain,
            this.m_dgvtxtinvoicecode_vchr,
            this.m_dgvtxtcomedate_vchr,
            this.m_dgvtxtinstorageid_vchr,
            this.m_dgvtxttypename_vchr,
            this.m_dgvtxtramark,
            this.m_dgvSortRowNo});
            this.m_dgvInstorageDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvInstorageDetail.Location = new System.Drawing.Point(0, 112);
            this.m_dgvInstorageDetail.Name = "m_dgvInstorageDetail";
            this.m_dgvInstorageDetail.ReadOnly = true;
            this.m_dgvInstorageDetail.RowHeadersVisible = false;
            this.m_dgvInstorageDetail.RowTemplate.Height = 23;
            this.m_dgvInstorageDetail.Size = new System.Drawing.Size(1016, 496);
            this.m_dgvInstorageDetail.TabIndex = 10028;
            this.m_dgvInstorageDetail.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.m_dgvInstorageDetail_ColumnHeaderMouseClick);
            this.m_dgvInstorageDetail.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.m_dgvInstorageDetail_ColumnHeaderMouseDoubleClick);
            // 
            // m_lblPriceSum
            // 
            this.m_lblPriceSum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblPriceSum.AutoSize = true;
            this.m_lblPriceSum.BackColor = System.Drawing.Color.Transparent;
            this.m_lblPriceSum.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblPriceSum.ForeColor = System.Drawing.Color.Maroon;
            this.m_lblPriceSum.Location = new System.Drawing.Point(823, 592);
            this.m_lblPriceSum.Name = "m_lblPriceSum";
            this.m_lblPriceSum.Size = new System.Drawing.Size(46, 14);
            this.m_lblPriceSum.TabIndex = 10078;
            this.m_lblPriceSum.Text = "0.0元";
            this.m_lblPriceSum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lblPriceSum.Visible = false;
            // 
            // Label
            // 
            this.Label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Label.AutoSize = true;
            this.Label.BackColor = System.Drawing.Color.Transparent;
            this.Label.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label.ForeColor = System.Drawing.Color.Maroon;
            this.Label.Location = new System.Drawing.Point(739, 592);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(90, 14);
            this.Label.TabIndex = 10077;
            this.Label.Text = "零售金额￥:";
            this.Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Label.Visible = false;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalAmount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.Maroon;
            this.lblTotalAmount.Location = new System.Drawing.Point(526, 592);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(75, 14);
            this.lblTotalAmount.TabIndex = 10077;
            this.lblTotalAmount.Text = "数量总数:";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTotalAmount.Visible = false;
            // 
            // m_lblTotalAmount
            // 
            this.m_lblTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblTotalAmount.AutoSize = true;
            this.m_lblTotalAmount.BackColor = System.Drawing.Color.Transparent;
            this.m_lblTotalAmount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblTotalAmount.ForeColor = System.Drawing.Color.Maroon;
            this.m_lblTotalAmount.Location = new System.Drawing.Point(610, 592);
            this.m_lblTotalAmount.Name = "m_lblTotalAmount";
            this.m_lblTotalAmount.Size = new System.Drawing.Size(31, 14);
            this.m_lblTotalAmount.TabIndex = 10078;
            this.m_lblTotalAmount.Text = "0.0";
            this.m_lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lblTotalAmount.Visible = false;
            // 
            // m_dgvtxtInstoragedat
            // 
            this.m_dgvtxtInstoragedat.DataPropertyName = "instoragedate_dat";
            dataGridViewCellStyle1.Format = "yyyy-MM-dd HH:mm:ss";
            this.m_dgvtxtInstoragedat.DefaultCellStyle = dataGridViewCellStyle1;
            this.m_dgvtxtInstoragedat.HeaderText = "入库时间";
            this.m_dgvtxtInstoragedat.Name = "m_dgvtxtInstoragedat";
            this.m_dgvtxtInstoragedat.ReadOnly = true;
            this.m_dgvtxtInstoragedat.Width = 150;
            // 
            // m_dgvtxtMedName
            // 
            this.m_dgvtxtMedName.DataPropertyName = "medicinename_vch";
            this.m_dgvtxtMedName.HeaderText = "药品名称";
            this.m_dgvtxtMedName.Name = "m_dgvtxtMedName";
            this.m_dgvtxtMedName.ReadOnly = true;
            this.m_dgvtxtMedName.Width = 150;
            // 
            // m_dgvtxtSpec
            // 
            this.m_dgvtxtSpec.DataPropertyName = "medspec_vchr";
            this.m_dgvtxtSpec.HeaderText = "规格";
            this.m_dgvtxtSpec.Name = "m_dgvtxtSpec";
            this.m_dgvtxtSpec.ReadOnly = true;
            this.m_dgvtxtSpec.Width = 70;
            // 
            // m_dgvtxtUnit
            // 
            this.m_dgvtxtUnit.DataPropertyName = "unit_vchr";
            this.m_dgvtxtUnit.HeaderText = "单位";
            this.m_dgvtxtUnit.Name = "m_dgvtxtUnit";
            this.m_dgvtxtUnit.ReadOnly = true;
            this.m_dgvtxtUnit.Width = 45;
            // 
            // m_dgvtxtProduct
            // 
            this.m_dgvtxtProduct.DataPropertyName = "productorid_chr";
            this.m_dgvtxtProduct.HeaderText = "厂家";
            this.m_dgvtxtProduct.Name = "m_dgvtxtProduct";
            this.m_dgvtxtProduct.ReadOnly = true;
            this.m_dgvtxtProduct.Width = 90;
            // 
            // m_dgvtxtLotno
            // 
            this.m_dgvtxtLotno.DataPropertyName = "lotno_vchr";
            this.m_dgvtxtLotno.HeaderText = "批号";
            this.m_dgvtxtLotno.Name = "m_dgvtxtLotno";
            this.m_dgvtxtLotno.ReadOnly = true;
            // 
            // m_dgvtxtvalidperiod_chr
            // 
            this.m_dgvtxtvalidperiod_chr.DataPropertyName = "validperiod_chr";
            this.m_dgvtxtvalidperiod_chr.HeaderText = "有效期";
            this.m_dgvtxtvalidperiod_chr.Name = "m_dgvtxtvalidperiod_chr";
            this.m_dgvtxtvalidperiod_chr.ReadOnly = true;
            this.m_dgvtxtvalidperiod_chr.Width = 90;
            // 
            // m_dgvtxtvendorname_vchr
            // 
            this.m_dgvtxtvendorname_vchr.DataPropertyName = "vendorname_vchr";
            this.m_dgvtxtvendorname_vchr.HeaderText = "供货单位";
            this.m_dgvtxtvendorname_vchr.Name = "m_dgvtxtvendorname_vchr";
            this.m_dgvtxtvendorname_vchr.ReadOnly = true;
            // 
            // m_dgvtxtamount
            // 
            this.m_dgvtxtamount.DataPropertyName = "amount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.m_dgvtxtamount.DefaultCellStyle = dataGridViewCellStyle2;
            this.m_dgvtxtamount.HeaderText = "数量";
            this.m_dgvtxtamount.Name = "m_dgvtxtamount";
            this.m_dgvtxtamount.ReadOnly = true;
            // 
            // callprice_int
            // 
            this.callprice_int.DataPropertyName = "callprice_int";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N4";
            dataGridViewCellStyle3.NullValue = null;
            this.callprice_int.DefaultCellStyle = dataGridViewCellStyle3;
            this.callprice_int.HeaderText = "购入价";
            this.callprice_int.Name = "callprice_int";
            this.callprice_int.ReadOnly = true;
            // 
            // callsum
            // 
            this.callsum.DataPropertyName = "callsum";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.callsum.DefaultCellStyle = dataGridViewCellStyle4;
            this.callsum.HeaderText = "购入金额";
            this.callsum.Name = "callsum";
            this.callsum.ReadOnly = true;
            this.callsum.Width = 120;
            // 
            // m_dgvtxtretailprice_int
            // 
            this.m_dgvtxtretailprice_int.DataPropertyName = "retailprice_int";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N4";
            this.m_dgvtxtretailprice_int.DefaultCellStyle = dataGridViewCellStyle5;
            this.m_dgvtxtretailprice_int.HeaderText = "零售价";
            this.m_dgvtxtretailprice_int.Name = "m_dgvtxtretailprice_int";
            this.m_dgvtxtretailprice_int.ReadOnly = true;
            // 
            // m_dgvtxtretailsum
            // 
            this.m_dgvtxtretailsum.DataPropertyName = "retailsum";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N4";
            this.m_dgvtxtretailsum.DefaultCellStyle = dataGridViewCellStyle6;
            this.m_dgvtxtretailsum.HeaderText = "零售金额";
            this.m_dgvtxtretailsum.Name = "m_dgvtxtretailsum";
            this.m_dgvtxtretailsum.ReadOnly = true;
            this.m_dgvtxtretailsum.Width = 120;
            // 
            // m_dgvtxtremain
            // 
            this.m_dgvtxtremain.DataPropertyName = "remain";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N4";
            this.m_dgvtxtremain.DefaultCellStyle = dataGridViewCellStyle7;
            this.m_dgvtxtremain.HeaderText = "结存";
            this.m_dgvtxtremain.Name = "m_dgvtxtremain";
            this.m_dgvtxtremain.ReadOnly = true;
            // 
            // m_dgvtxtinvoicecode_vchr
            // 
            this.m_dgvtxtinvoicecode_vchr.DataPropertyName = "invoicecode_vchr";
            this.m_dgvtxtinvoicecode_vchr.HeaderText = "来源号";
            this.m_dgvtxtinvoicecode_vchr.Name = "m_dgvtxtinvoicecode_vchr";
            this.m_dgvtxtinvoicecode_vchr.ReadOnly = true;
            // 
            // m_dgvtxtcomedate_vchr
            // 
            this.m_dgvtxtcomedate_vchr.DataPropertyName = "comedate_vchr";
            this.m_dgvtxtcomedate_vchr.HeaderText = "来源日期";
            this.m_dgvtxtcomedate_vchr.Name = "m_dgvtxtcomedate_vchr";
            this.m_dgvtxtcomedate_vchr.ReadOnly = true;
            // 
            // m_dgvtxtinstorageid_vchr
            // 
            this.m_dgvtxtinstorageid_vchr.DataPropertyName = "instorageid_vchr";
            this.m_dgvtxtinstorageid_vchr.HeaderText = "单据号";
            this.m_dgvtxtinstorageid_vchr.Name = "m_dgvtxtinstorageid_vchr";
            this.m_dgvtxtinstorageid_vchr.ReadOnly = true;
            // 
            // m_dgvtxttypename_vchr
            // 
            this.m_dgvtxttypename_vchr.DataPropertyName = "typename_vchr";
            this.m_dgvtxttypename_vchr.HeaderText = "入库类型";
            this.m_dgvtxttypename_vchr.Name = "m_dgvtxttypename_vchr";
            this.m_dgvtxttypename_vchr.ReadOnly = true;
            this.m_dgvtxttypename_vchr.Width = 70;
            // 
            // m_dgvtxtramark
            // 
            this.m_dgvtxtramark.DataPropertyName = "ramark";
            this.m_dgvtxtramark.HeaderText = "备注";
            this.m_dgvtxtramark.Name = "m_dgvtxtramark";
            this.m_dgvtxtramark.ReadOnly = true;
            // 
            // m_dgvSortRowNo
            // 
            this.m_dgvSortRowNo.DataPropertyName = "SortRowNo";
            this.m_dgvSortRowNo.HeaderText = "排序号";
            this.m_dgvSortRowNo.Name = "m_dgvSortRowNo";
            this.m_dgvSortRowNo.ReadOnly = true;
            this.m_dgvSortRowNo.Visible = false;
            // 
            // frmInstorageDetailReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 608);
            this.Controls.Add(this.m_lblTotalAmount);
            this.Controls.Add(this.m_lblPriceSum);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.Label);
            this.Controls.Add(this.m_dgvInstorageDetail);
            this.Controls.Add(this.m_dwcData);
            this.Controls.Add(this.gradientPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInstorageDetailReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "入库药品详细记录";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmInstorageDetailReport_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvInstorageDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker m_bgwGetMedicine;
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
        internal com.digitalwave.Controls.Domain.EmrControls.ctlDeptSelected_EnterKeyActive m_txtReceiveDept;
        internal System.Windows.Forms.TextBox m_txtMedicine;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox m_cboType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox m_txtVendor;
        internal Sybase.DataWindow.DataWindowControl m_dwcData;
        internal System.Windows.Forms.DataGridView m_dgvInstorageDetail;
        internal System.Windows.Forms.Label m_lblPriceSum;
        internal System.Windows.Forms.Label Label;
        internal System.Windows.Forms.Label lblTotalAmount;
        internal System.Windows.Forms.Label m_lblTotalAmount;
        internal ControlLibrary.txtListView1 txtTypecode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.RadioButton m_rbtCombine;
        internal System.Windows.Forms.RadioButton m_rbtSingle;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab m_dtpEndDate;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab m_dtpBeginDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtInstoragedat;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtLotno;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtvalidperiod_chr;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtvendorname_vchr;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtamount;
        private System.Windows.Forms.DataGridViewTextBoxColumn callprice_int;
        private System.Windows.Forms.DataGridViewTextBoxColumn callsum;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtretailprice_int;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtretailsum;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtremain;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtinvoicecode_vchr;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtcomedate_vchr;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtinstorageid_vchr;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxttypename_vchr;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtramark;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvSortRowNo;
    }
}