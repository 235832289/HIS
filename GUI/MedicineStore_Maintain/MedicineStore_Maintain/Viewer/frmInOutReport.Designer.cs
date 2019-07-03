namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    partial class frmInOutReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInOutReport));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.m_btnQuery = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnPreview = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnExit = new System.Windows.Forms.ToolStripButton();
            this.gradientPanel1 = new com.digitalwave.iCare.gui.HIS.GradientPanel();
            this.m_ckbShowNoAmount = new System.Windows.Forms.CheckBox();
            this.m_rbtInN = new System.Windows.Forms.RadioButton();
            this.m_rbtInY = new System.Windows.Forms.RadioButton();
            this.m_rbtOutN = new System.Windows.Forms.RadioButton();
            this.m_rbtOutY = new System.Windows.Forms.RadioButton();
            this.m_rbtOutAll = new System.Windows.Forms.RadioButton();
            this.m_dtpEndDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab(this.components);
            this.m_dtpBeginDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_rbtCombine = new System.Windows.Forms.RadioButton();
            this.m_rbtSingle = new System.Windows.Forms.RadioButton();
            this.m_txtMedicine = new System.Windows.Forms.TextBox();
            this.txtTypecode = new ControlLibrary.txtListView1(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_dgvInOutDetail = new System.Windows.Forms.DataGridView();
            this.medicinename_vchr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.medspec_vchr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit_chr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productorid_chr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.storageamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvSortRowNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dwcData = new Sybase.DataWindow.DataWindowControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_rbtInAll = new System.Windows.Forms.RadioButton();
            this.toolStrip1.SuspendLayout();
            this.gradientPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvInOutDetail)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // m_btnQuery
            // 
            this.m_btnQuery.AutoSize = false;
            this.m_btnQuery.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnQuery.Image = ((System.Drawing.Image)(resources.GetObject("m_btnQuery.Image")));
            this.m_btnQuery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnQuery.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_btnQuery.Name = "m_btnQuery";
            this.m_btnQuery.Size = new System.Drawing.Size(76, 35);
            this.m_btnQuery.Text = "查询(&Q)";
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
            this.m_btnPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_btnPreview.Name = "m_btnPreview";
            this.m_btnPreview.Size = new System.Drawing.Size(76, 35);
            this.m_btnPreview.Text = "预览(&V)";
            this.m_btnPreview.Click += new System.EventHandler(this.m_btnPreview_Click);
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
            this.m_btnPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_btnPrint.Name = "m_btnPrint";
            this.m_btnPrint.Size = new System.Drawing.Size(76, 35);
            this.m_btnPrint.Text = "打印(&P)";
            this.m_btnPrint.Click += new System.EventHandler(this.m_btnPrint_Click);
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
            this.m_btnExport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnExport.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_btnExport.Name = "m_btnExport";
            this.m_btnExport.Size = new System.Drawing.Size(76, 35);
            this.m_btnExport.Text = "导出(&E)";
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
            this.m_btnExit.Size = new System.Drawing.Size(76, 35);
            this.m_btnExit.Text = "关闭(&C)";
            this.m_btnExit.Click += new System.EventHandler(this.m_cmdExit_Click);
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Controls.Add(this.groupBox3);
            this.gradientPanel1.Controls.Add(this.groupBox2);
            this.gradientPanel1.Controls.Add(this.m_ckbShowNoAmount);
            this.gradientPanel1.Controls.Add(this.m_dtpEndDate);
            this.gradientPanel1.Controls.Add(this.m_dtpBeginDate);
            this.gradientPanel1.Controls.Add(this.groupBox1);
            this.gradientPanel1.Controls.Add(this.txtTypecode);
            this.gradientPanel1.Controls.Add(this.label7);
            this.gradientPanel1.Controls.Add(this.label5);
            this.gradientPanel1.Controls.Add(this.label6);
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
            // m_ckbShowNoAmount
            // 
            this.m_ckbShowNoAmount.AutoSize = true;
            this.m_ckbShowNoAmount.BackColor = System.Drawing.Color.Transparent;
            this.m_ckbShowNoAmount.Location = new System.Drawing.Point(883, 13);
            this.m_ckbShowNoAmount.Name = "m_ckbShowNoAmount";
            this.m_ckbShowNoAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.m_ckbShowNoAmount.Size = new System.Drawing.Size(96, 18);
            this.m_ckbShowNoAmount.TabIndex = 6;
            this.m_ckbShowNoAmount.Text = "显示零库存";
            this.m_ckbShowNoAmount.UseVisualStyleBackColor = false;
            // 
            // m_rbtInN
            // 
            this.m_rbtInN.AutoSize = true;
            this.m_rbtInN.BackColor = System.Drawing.Color.Transparent;
            this.m_rbtInN.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_rbtInN.ForeColor = System.Drawing.SystemColors.InfoText;
            this.m_rbtInN.Location = new System.Drawing.Point(98, 14);
            this.m_rbtInN.Name = "m_rbtInN";
            this.m_rbtInN.Size = new System.Drawing.Size(39, 18);
            this.m_rbtInN.TabIndex = 2;
            this.m_rbtInN.Text = "无";
            this.m_rbtInN.UseVisualStyleBackColor = false;
            // 
            // m_rbtInY
            // 
            this.m_rbtInY.AutoSize = true;
            this.m_rbtInY.BackColor = System.Drawing.Color.Transparent;
            this.m_rbtInY.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_rbtInY.ForeColor = System.Drawing.SystemColors.InfoText;
            this.m_rbtInY.Location = new System.Drawing.Point(59, 14);
            this.m_rbtInY.Name = "m_rbtInY";
            this.m_rbtInY.Size = new System.Drawing.Size(39, 18);
            this.m_rbtInY.TabIndex = 1;
            this.m_rbtInY.Text = "有";
            this.m_rbtInY.UseVisualStyleBackColor = false;
            // 
            // m_rbtOutN
            // 
            this.m_rbtOutN.AutoSize = true;
            this.m_rbtOutN.BackColor = System.Drawing.Color.Transparent;
            this.m_rbtOutN.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_rbtOutN.ForeColor = System.Drawing.SystemColors.InfoText;
            this.m_rbtOutN.Location = new System.Drawing.Point(98, 14);
            this.m_rbtOutN.Name = "m_rbtOutN";
            this.m_rbtOutN.Size = new System.Drawing.Size(39, 18);
            this.m_rbtOutN.TabIndex = 2;
            this.m_rbtOutN.Text = "无";
            this.m_rbtOutN.UseVisualStyleBackColor = false;
            // 
            // m_rbtOutY
            // 
            this.m_rbtOutY.AutoSize = true;
            this.m_rbtOutY.BackColor = System.Drawing.Color.Transparent;
            this.m_rbtOutY.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_rbtOutY.ForeColor = System.Drawing.SystemColors.InfoText;
            this.m_rbtOutY.Location = new System.Drawing.Point(59, 14);
            this.m_rbtOutY.Name = "m_rbtOutY";
            this.m_rbtOutY.Size = new System.Drawing.Size(39, 18);
            this.m_rbtOutY.TabIndex = 1;
            this.m_rbtOutY.Text = "有";
            this.m_rbtOutY.UseVisualStyleBackColor = false;
            // 
            // m_rbtOutAll
            // 
            this.m_rbtOutAll.AutoSize = true;
            this.m_rbtOutAll.BackColor = System.Drawing.Color.Transparent;
            this.m_rbtOutAll.Checked = true;
            this.m_rbtOutAll.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_rbtOutAll.ForeColor = System.Drawing.SystemColors.InfoText;
            this.m_rbtOutAll.Location = new System.Drawing.Point(6, 14);
            this.m_rbtOutAll.Name = "m_rbtOutAll";
            this.m_rbtOutAll.Size = new System.Drawing.Size(53, 18);
            this.m_rbtOutAll.TabIndex = 0;
            this.m_rbtOutAll.TabStop = true;
            this.m_rbtOutAll.Text = "全部";
            this.m_rbtOutAll.UseVisualStyleBackColor = false;
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
            this.groupBox1.Size = new System.Drawing.Size(499, 36);
            this.groupBox1.TabIndex = 5;
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
            this.m_txtMedicine.Size = new System.Drawing.Size(343, 23);
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(12, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 173;
            this.label5.Text = "查询日期";
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
            // m_dgvInOutDetail
            // 
            this.m_dgvInOutDetail.AllowUserToAddRows = false;
            this.m_dgvInOutDetail.AllowUserToOrderColumns = true;
            this.m_dgvInOutDetail.BackgroundColor = System.Drawing.Color.White;
            this.m_dgvInOutDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_dgvInOutDetail.ColumnHeadersHeight = 25;
            this.m_dgvInOutDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgvInOutDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.medicinename_vchr,
            this.medspec_vchr,
            this.unit_chr,
            this.productorid_chr,
            this.storageamount,
            this.inamount,
            this.outamount,
            this.outdate,
            this.m_dgvSortRowNo});
            this.m_dgvInOutDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvInOutDetail.Location = new System.Drawing.Point(0, 112);
            this.m_dgvInOutDetail.MultiSelect = false;
            this.m_dgvInOutDetail.Name = "m_dgvInOutDetail";
            this.m_dgvInOutDetail.ReadOnly = true;
            this.m_dgvInOutDetail.RowHeadersVisible = false;
            this.m_dgvInOutDetail.RowTemplate.Height = 23;
            this.m_dgvInOutDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvInOutDetail.Size = new System.Drawing.Size(1016, 496);
            this.m_dgvInOutDetail.TabIndex = 1;
            this.m_dgvInOutDetail.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.m_dgvInstorageDetail_ColumnHeaderMouseClick);
            this.m_dgvInOutDetail.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.m_dgvInstorageDetail_ColumnHeaderMouseDoubleClick);
            // 
            // medicinename_vchr
            // 
            this.medicinename_vchr.DataPropertyName = "medicinename_vchr";
            this.medicinename_vchr.HeaderText = "药品名称";
            this.medicinename_vchr.Name = "medicinename_vchr";
            this.medicinename_vchr.ReadOnly = true;
            this.medicinename_vchr.Width = 180;
            // 
            // medspec_vchr
            // 
            this.medspec_vchr.DataPropertyName = "medspec_vchr";
            this.medspec_vchr.HeaderText = "规格";
            this.medspec_vchr.Name = "medspec_vchr";
            this.medspec_vchr.ReadOnly = true;
            this.medspec_vchr.Width = 150;
            // 
            // unit_chr
            // 
            this.unit_chr.DataPropertyName = "unit_chr";
            this.unit_chr.HeaderText = "单位";
            this.unit_chr.Name = "unit_chr";
            this.unit_chr.ReadOnly = true;
            this.unit_chr.Width = 50;
            // 
            // productorid_chr
            // 
            this.productorid_chr.DataPropertyName = "productorid_chr";
            this.productorid_chr.HeaderText = "厂家";
            this.productorid_chr.Name = "productorid_chr";
            this.productorid_chr.ReadOnly = true;
            // 
            // storageamount
            // 
            this.storageamount.DataPropertyName = "storageamount";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.storageamount.DefaultCellStyle = dataGridViewCellStyle4;
            this.storageamount.HeaderText = "当前库存数量";
            this.storageamount.Name = "storageamount";
            this.storageamount.ReadOnly = true;
            this.storageamount.Width = 180;
            // 
            // inamount
            // 
            this.inamount.DataPropertyName = "inamount";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = "0";
            this.inamount.DefaultCellStyle = dataGridViewCellStyle5;
            this.inamount.HeaderText = "入库数";
            this.inamount.Name = "inamount";
            this.inamount.ReadOnly = true;
            this.inamount.Width = 170;
            // 
            // outamount
            // 
            this.outamount.DataPropertyName = "outamount";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = "0";
            this.outamount.DefaultCellStyle = dataGridViewCellStyle6;
            this.outamount.HeaderText = "出库数";
            this.outamount.Name = "outamount";
            this.outamount.ReadOnly = true;
            this.outamount.Width = 170;
            // 
            // outdate
            // 
            this.outdate.DataPropertyName = "outdate";
            this.outdate.HeaderText = "最后出库时间";
            this.outdate.Name = "outdate";
            this.outdate.ReadOnly = true;
            this.outdate.Width = 150;
            // 
            // m_dgvSortRowNo
            // 
            this.m_dgvSortRowNo.DataPropertyName = "SortRowNo";
            this.m_dgvSortRowNo.HeaderText = "序号";
            this.m_dgvSortRowNo.Name = "m_dgvSortRowNo";
            this.m_dgvSortRowNo.ReadOnly = true;
            this.m_dgvSortRowNo.Visible = false;
            // 
            // m_dwcData
            // 
            this.m_dwcData.DataWindowObject = "ms_instoragedetailreport";
            this.m_dwcData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dwcData.LibraryList = "";
            this.m_dwcData.Location = new System.Drawing.Point(0, 0);
            this.m_dwcData.Name = "m_dwcData";
            this.m_dwcData.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.m_dwcData.Size = new System.Drawing.Size(1016, 608);
            this.m_dwcData.TabIndex = 10029;
            this.m_dwcData.Text = "dataWindowControl1";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.m_rbtOutAll);
            this.groupBox2.Controls.Add(this.m_rbtOutY);
            this.groupBox2.Controls.Add(this.m_rbtOutN);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 9F);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox2.Location = new System.Drawing.Point(631, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(143, 36);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "出库";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.m_rbtInAll);
            this.groupBox3.Controls.Add(this.m_rbtInY);
            this.groupBox3.Controls.Add(this.m_rbtInN);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 9F);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox3.Location = new System.Drawing.Point(475, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(143, 36);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "入库";
            // 
            // m_rbtInAll
            // 
            this.m_rbtInAll.AutoSize = true;
            this.m_rbtInAll.BackColor = System.Drawing.Color.Transparent;
            this.m_rbtInAll.Checked = true;
            this.m_rbtInAll.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_rbtInAll.ForeColor = System.Drawing.SystemColors.InfoText;
            this.m_rbtInAll.Location = new System.Drawing.Point(6, 14);
            this.m_rbtInAll.Name = "m_rbtInAll";
            this.m_rbtInAll.Size = new System.Drawing.Size(53, 18);
            this.m_rbtInAll.TabIndex = 0;
            this.m_rbtInAll.TabStop = true;
            this.m_rbtInAll.Text = "全部";
            this.m_rbtInAll.UseVisualStyleBackColor = false;
            // 
            // frmInOutReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 608);
            this.Controls.Add(this.m_dgvInOutDetail);
            this.Controls.Add(this.gradientPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.m_dwcData);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInOutReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "药品无出入库记录查询";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmInstorageDetailReport_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvInOutDetail)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        internal System.Windows.Forms.ToolStrip toolStrip1;
        internal System.Windows.Forms.ToolStripButton m_btnQuery;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton m_btnExit;
        private com.digitalwave.iCare.gui.HIS.GradientPanel gradientPanel1;
        internal System.Windows.Forms.TextBox m_txtMedicine;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.DataGridView m_dgvInOutDetail;
        internal ControlLibrary.txtListView1 txtTypecode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.RadioButton m_rbtCombine;
        internal System.Windows.Forms.RadioButton m_rbtSingle;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab m_dtpEndDate;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab m_dtpBeginDate;
        internal System.Windows.Forms.RadioButton m_rbtInN;
        internal System.Windows.Forms.RadioButton m_rbtInY;
        internal System.Windows.Forms.RadioButton m_rbtOutN;
        internal System.Windows.Forms.RadioButton m_rbtOutY;
        internal System.Windows.Forms.RadioButton m_rbtOutAll;
        internal System.Windows.Forms.CheckBox m_ckbShowNoAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn medicinename_vchr;
        private System.Windows.Forms.DataGridViewTextBoxColumn medspec_vchr;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit_chr;
        private System.Windows.Forms.DataGridViewTextBoxColumn productorid_chr;
        private System.Windows.Forms.DataGridViewTextBoxColumn storageamount;
        private System.Windows.Forms.DataGridViewTextBoxColumn inamount;
        private System.Windows.Forms.DataGridViewTextBoxColumn outamount;
        private System.Windows.Forms.DataGridViewTextBoxColumn outdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvSortRowNo;
        private System.Windows.Forms.ToolStripButton m_btnPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        internal System.Windows.Forms.ToolStripButton m_btnExport;
        internal Sybase.DataWindow.DataWindowControl m_dwcData;
        private System.Windows.Forms.ToolStripButton m_btnPreview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.RadioButton m_rbtInAll;
    }
}