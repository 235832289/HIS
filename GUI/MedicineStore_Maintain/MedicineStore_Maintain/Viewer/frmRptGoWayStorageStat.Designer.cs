namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    partial class frmRptGoWayStorageStat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptGoWayStorageStat));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gradientPanel1 = new com.digitalwave.iCare.gui.HIS.GradientPanel();
            this.m_dtpEndDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab(this.components);
            this.m_dtpBeginDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab(this.components);
            this.m_cboMedStorage = new com.digitalwave.iCare.gui.MedicineStore_Maintain.exComboBox();
            this.txtMedType = new ControlLibrary.txtListView1(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtReceiveDept = new com.digitalwave.Controls.Domain.EmrControls.ctlDeptSelected_EnterKeyActive();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtVendor = new System.Windows.Forms.TextBox();
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
            this.dw = new Sybase.DataWindow.DataWindowControl();
            this.m_dgvGoWayStorageStat = new System.Windows.Forms.DataGridView();
            this.m_dgvtxtdeptid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtdeptname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtallprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvGoWayMedStorageStat = new System.Windows.Forms.DataGridView();
            this.m_dgvtxtaskdept_chr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtdeptname_vchr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtoutstorageprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtretailprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtretailoutloss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvSortRowNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_lbloutstoragepriceSum = new System.Windows.Forms.Label();
            this.Label = new System.Windows.Forms.Label();
            this.m_lblretailpriceSum = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.m_lblretailoutlossSum = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.gradientPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvGoWayStorageStat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvGoWayMedStorageStat)).BeginInit();
            this.SuspendLayout();
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Controls.Add(this.m_dtpEndDate);
            this.gradientPanel1.Controls.Add(this.m_dtpBeginDate);
            this.gradientPanel1.Controls.Add(this.m_cboMedStorage);
            this.gradientPanel1.Controls.Add(this.txtMedType);
            this.gradientPanel1.Controls.Add(this.label1);
            this.gradientPanel1.Controls.Add(this.m_txtReceiveDept);
            this.gradientPanel1.Controls.Add(this.label4);
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
            this.gradientPanel1.Size = new System.Drawing.Size(1028, 46);
            this.gradientPanel1.TabIndex = 10026;
            this.gradientPanel1.VerticalFillPercent = 100F;
            // 
            // m_dtpEndDate
            // 
            this.m_dtpEndDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_dtpEndDate.Location = new System.Drawing.Point(269, 13);
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
            this.m_dtpBeginDate.Location = new System.Drawing.Point(68, 13);
            this.m_dtpBeginDate.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日HHmmss;
            this.m_dtpBeginDate.Mask = "0000年90月90日 90:90:90";
            this.m_dtpBeginDate.Name = "m_dtpBeginDate";
            this.m_dtpBeginDate.Size = new System.Drawing.Size(187, 23);
            this.m_dtpBeginDate.TabIndex = 0;
            this.m_dtpBeginDate.ValidatingType = typeof(System.DateTime);
            // 
            // m_cboMedStorage
            // 
            this.m_cboMedStorage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboMedStorage.Location = new System.Drawing.Point(517, 14);
            this.m_cboMedStorage.Margin = new System.Windows.Forms.Padding(0);
            this.m_cboMedStorage.Name = "m_cboMedStorage";
            this.m_cboMedStorage.Size = new System.Drawing.Size(111, 22);
            this.m_cboMedStorage.TabIndex = 2;
            this.m_cboMedStorage.SelectedIndexChanged += new System.EventHandler(this.m_cboMedStorage_SelectedIndexChanged);
            // 
            // txtMedType
            // 
            this.txtMedType.AccessibleName = "5";
            this.txtMedType.findDataMode = ControlLibrary.txtListView1.findMode.fromDataSouse;
            this.txtMedType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMedType.Location = new System.Drawing.Point(694, 14);
            this.txtMedType.m_blnFocuseShow = true;
            this.txtMedType.m_blnPagination = false;
            this.txtMedType.m_dtbDataSourse = null;
            this.txtMedType.m_intDelayTime = 100;
            this.txtMedType.m_intPageRows = 10;
            this.txtMedType.m_ListViewAlign = ControlLibrary.txtListView1.ListViewAlign.LeftBottom;
            this.txtMedType.m_listViewSize = new System.Drawing.Point(163, 150);
            this.txtMedType.m_strFieldsArr = new string[] {
        "entcode_chr",
        "entname_vchr"};
            this.txtMedType.m_strSaveField = "medicinetypeid_chr";
            this.txtMedType.m_strShowField = "medicinetypename_vchr";
            this.txtMedType.m_strSQL = null;
            this.txtMedType.Name = "txtMedType";
            this.txtMedType.Size = new System.Drawing.Size(114, 23);
            this.txtMedType.TabIndex = 10052;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(630, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 10053;
            this.label1.Text = "药品类别";
            // 
            // m_txtReceiveDept
            // 
            this.m_txtReceiveDept.Location = new System.Drawing.Point(876, 15);
            this.m_txtReceiveDept.m_objTag = null;
            this.m_txtReceiveDept.Name = "m_txtReceiveDept";
            this.m_txtReceiveDept.Size = new System.Drawing.Size(140, 23);
            this.m_txtReceiveDept.TabIndex = 3;
            this.m_txtReceiveDept.显示类型 = com.digitalwave.Controls.Domain.EmrControls.enmDeptAttributeType.全部;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(453, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 187;
            this.label4.Text = "药库名称";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(5, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 173;
            this.label5.Text = "统计时间";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(255, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 14);
            this.label6.TabIndex = 173;
            this.label6.Text = "~";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(813, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "领药部门";
            // 
            // m_txtVendor
            // 
            this.m_txtVendor.Location = new System.Drawing.Point(876, 15);
            this.m_txtVendor.Name = "m_txtVendor";
            this.m_txtVendor.Size = new System.Drawing.Size(140, 23);
            this.m_txtVendor.TabIndex = 3;
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
            this.toolStrip1.Size = new System.Drawing.Size(1028, 38);
            this.toolStrip1.TabIndex = 10027;
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
            this.m_btnQuery.Click += new System.EventHandler(this.m_btnQuery_Click);
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
            this.m_btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_btnExport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnExport.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_btnExport.Name = "m_btnExport";
            this.m_btnExport.Size = new System.Drawing.Size(90, 35);
            this.m_btnExport.Text = "导 出(&E)";
            this.m_btnExport.Click += new System.EventHandler(this.m_btnExport_Click);
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
            this.m_btnExit.Click += new System.EventHandler(this.m_btnExit_Click);
            // 
            // dw
            // 
            this.dw.DataWindowObject = "";
            this.dw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dw.LibraryList = "";
            this.dw.Location = new System.Drawing.Point(0, 84);
            this.dw.Name = "dw";
            this.dw.Size = new System.Drawing.Size(1028, 524);
            this.dw.TabIndex = 10028;
            this.dw.Text = "dataWindowControl1";
            // 
            // m_dgvGoWayStorageStat
            // 
            this.m_dgvGoWayStorageStat.AllowUserToAddRows = false;
            this.m_dgvGoWayStorageStat.BackgroundColor = System.Drawing.Color.White;
            this.m_dgvGoWayStorageStat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_dgvGoWayStorageStat.ColumnHeadersHeight = 25;
            this.m_dgvGoWayStorageStat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgvGoWayStorageStat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_dgvtxtdeptid,
            this.m_dgvtxtdeptname,
            this.m_dgvtxtallprice});
            this.m_dgvGoWayStorageStat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvGoWayStorageStat.Location = new System.Drawing.Point(0, 84);
            this.m_dgvGoWayStorageStat.Name = "m_dgvGoWayStorageStat";
            this.m_dgvGoWayStorageStat.ReadOnly = true;
            this.m_dgvGoWayStorageStat.RowHeadersVisible = false;
            this.m_dgvGoWayStorageStat.RowTemplate.Height = 23;
            this.m_dgvGoWayStorageStat.Size = new System.Drawing.Size(1028, 524);
            this.m_dgvGoWayStorageStat.TabIndex = 10029;
            this.m_dgvGoWayStorageStat.Visible = false;
            // 
            // m_dgvtxtdeptid
            // 
            this.m_dgvtxtdeptid.DataPropertyName = "diagdept_chr";
            this.m_dgvtxtdeptid.HeaderText = "科室id";
            this.m_dgvtxtdeptid.Name = "m_dgvtxtdeptid";
            this.m_dgvtxtdeptid.ReadOnly = true;
            this.m_dgvtxtdeptid.Visible = false;
            // 
            // m_dgvtxtdeptname
            // 
            this.m_dgvtxtdeptname.DataPropertyName = "deptname_vchr";
            this.m_dgvtxtdeptname.HeaderText = "去向";
            this.m_dgvtxtdeptname.Name = "m_dgvtxtdeptname";
            this.m_dgvtxtdeptname.ReadOnly = true;
            this.m_dgvtxtdeptname.Width = 180;
            // 
            // m_dgvtxtallprice
            // 
            this.m_dgvtxtallprice.DataPropertyName = "allprice";
            this.m_dgvtxtallprice.HeaderText = "出价金额";
            this.m_dgvtxtallprice.Name = "m_dgvtxtallprice";
            this.m_dgvtxtallprice.ReadOnly = true;
            this.m_dgvtxtallprice.Width = 150;
            // 
            // m_dgvGoWayMedStorageStat
            // 
            this.m_dgvGoWayMedStorageStat.AllowUserToAddRows = false;
            this.m_dgvGoWayMedStorageStat.AllowUserToOrderColumns = true;
            this.m_dgvGoWayMedStorageStat.BackgroundColor = System.Drawing.Color.White;
            this.m_dgvGoWayMedStorageStat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_dgvGoWayMedStorageStat.ColumnHeadersHeight = 25;
            this.m_dgvGoWayMedStorageStat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgvGoWayMedStorageStat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_dgvtxtaskdept_chr,
            this.m_dgvtxtdeptname_vchr,
            this.m_dgvtxtoutstorageprice,
            this.m_dgvtxtretailprice,
            this.m_dgvtxtretailoutloss,
            this.m_dgvSortRowNo});
            this.m_dgvGoWayMedStorageStat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvGoWayMedStorageStat.Location = new System.Drawing.Point(0, 84);
            this.m_dgvGoWayMedStorageStat.Name = "m_dgvGoWayMedStorageStat";
            this.m_dgvGoWayMedStorageStat.ReadOnly = true;
            this.m_dgvGoWayMedStorageStat.RowHeadersVisible = false;
            this.m_dgvGoWayMedStorageStat.RowTemplate.Height = 23;
            this.m_dgvGoWayMedStorageStat.Size = new System.Drawing.Size(1028, 524);
            this.m_dgvGoWayMedStorageStat.TabIndex = 10030;
            this.m_dgvGoWayMedStorageStat.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.m_dgvGoWayMedStorageStat_ColumnHeaderMouseClick);
            this.m_dgvGoWayMedStorageStat.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.m_dgvGoWayMedStorageStat_ColumnHeaderMouseDoubleClick);
            // 
            // m_dgvtxtaskdept_chr
            // 
            this.m_dgvtxtaskdept_chr.DataPropertyName = "askdept_chr";
            this.m_dgvtxtaskdept_chr.HeaderText = "去向id";
            this.m_dgvtxtaskdept_chr.Name = "m_dgvtxtaskdept_chr";
            this.m_dgvtxtaskdept_chr.ReadOnly = true;
            this.m_dgvtxtaskdept_chr.Visible = false;
            // 
            // m_dgvtxtdeptname_vchr
            // 
            this.m_dgvtxtdeptname_vchr.DataPropertyName = "deptname_vchr";
            this.m_dgvtxtdeptname_vchr.HeaderText = "                      去向";
            this.m_dgvtxtdeptname_vchr.Name = "m_dgvtxtdeptname_vchr";
            this.m_dgvtxtdeptname_vchr.ReadOnly = true;
            this.m_dgvtxtdeptname_vchr.Width = 350;
            // 
            // m_dgvtxtoutstorageprice
            // 
            this.m_dgvtxtoutstorageprice.DataPropertyName = "outstorageprice";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N4";
            this.m_dgvtxtoutstorageprice.DefaultCellStyle = dataGridViewCellStyle1;
            this.m_dgvtxtoutstorageprice.HeaderText = "         出库金额";
            this.m_dgvtxtoutstorageprice.Name = "m_dgvtxtoutstorageprice";
            this.m_dgvtxtoutstorageprice.ReadOnly = true;
            this.m_dgvtxtoutstorageprice.Width = 220;
            // 
            // m_dgvtxtretailprice
            // 
            this.m_dgvtxtretailprice.DataPropertyName = "retailprice";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N4";
            this.m_dgvtxtretailprice.DefaultCellStyle = dataGridViewCellStyle2;
            this.m_dgvtxtretailprice.HeaderText = "         零售金额";
            this.m_dgvtxtretailprice.Name = "m_dgvtxtretailprice";
            this.m_dgvtxtretailprice.ReadOnly = true;
            this.m_dgvtxtretailprice.Width = 220;
            // 
            // m_dgvtxtretailoutloss
            // 
            this.m_dgvtxtretailoutloss.DataPropertyName = "retailoutloss";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N4";
            this.m_dgvtxtretailoutloss.DefaultCellStyle = dataGridViewCellStyle3;
            this.m_dgvtxtretailoutloss.HeaderText = "         零出差价";
            this.m_dgvtxtretailoutloss.Name = "m_dgvtxtretailoutloss";
            this.m_dgvtxtretailoutloss.ReadOnly = true;
            this.m_dgvtxtretailoutloss.Width = 220;
            // 
            // m_dgvSortRowNo
            // 
            this.m_dgvSortRowNo.DataPropertyName = "SortRowNo";
            this.m_dgvSortRowNo.HeaderText = "排序号";
            this.m_dgvSortRowNo.Name = "m_dgvSortRowNo";
            this.m_dgvSortRowNo.ReadOnly = true;
            this.m_dgvSortRowNo.Visible = false;
            // 
            // m_lbloutstoragepriceSum
            // 
            this.m_lbloutstoragepriceSum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lbloutstoragepriceSum.AutoSize = true;
            this.m_lbloutstoragepriceSum.BackColor = System.Drawing.Color.Transparent;
            this.m_lbloutstoragepriceSum.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lbloutstoragepriceSum.ForeColor = System.Drawing.Color.Maroon;
            this.m_lbloutstoragepriceSum.Location = new System.Drawing.Point(381, 594);
            this.m_lbloutstoragepriceSum.Name = "m_lbloutstoragepriceSum";
            this.m_lbloutstoragepriceSum.Size = new System.Drawing.Size(46, 14);
            this.m_lbloutstoragepriceSum.TabIndex = 10078;
            this.m_lbloutstoragepriceSum.Text = "0.0元";
            this.m_lbloutstoragepriceSum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lbloutstoragepriceSum.Visible = false;
            // 
            // Label
            // 
            this.Label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Label.AutoSize = true;
            this.Label.BackColor = System.Drawing.Color.Transparent;
            this.Label.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label.ForeColor = System.Drawing.Color.Maroon;
            this.Label.Location = new System.Drawing.Point(297, 594);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(90, 14);
            this.Label.TabIndex = 10077;
            this.Label.Text = "出库金额￥:";
            this.Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Label.Visible = false;
            // 
            // m_lblretailpriceSum
            // 
            this.m_lblretailpriceSum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblretailpriceSum.AutoSize = true;
            this.m_lblretailpriceSum.BackColor = System.Drawing.Color.Transparent;
            this.m_lblretailpriceSum.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblretailpriceSum.ForeColor = System.Drawing.Color.Maroon;
            this.m_lblretailpriceSum.Location = new System.Drawing.Point(645, 594);
            this.m_lblretailpriceSum.Name = "m_lblretailpriceSum";
            this.m_lblretailpriceSum.Size = new System.Drawing.Size(46, 14);
            this.m_lblretailpriceSum.TabIndex = 10080;
            this.m_lblretailpriceSum.Text = "0.0元";
            this.m_lblretailpriceSum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lblretailpriceSum.Visible = false;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Maroon;
            this.label7.Location = new System.Drawing.Point(561, 594);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 14);
            this.label7.TabIndex = 10079;
            this.label7.Text = "零售金额￥:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Visible = false;
            // 
            // m_lblretailoutlossSum
            // 
            this.m_lblretailoutlossSum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblretailoutlossSum.AutoSize = true;
            this.m_lblretailoutlossSum.BackColor = System.Drawing.Color.Transparent;
            this.m_lblretailoutlossSum.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblretailoutlossSum.ForeColor = System.Drawing.Color.Maroon;
            this.m_lblretailoutlossSum.Location = new System.Drawing.Point(870, 594);
            this.m_lblretailoutlossSum.Name = "m_lblretailoutlossSum";
            this.m_lblretailoutlossSum.Size = new System.Drawing.Size(46, 14);
            this.m_lblretailoutlossSum.TabIndex = 10082;
            this.m_lblretailoutlossSum.Text = "0.0元";
            this.m_lblretailoutlossSum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lblretailoutlossSum.Visible = false;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.Maroon;
            this.label9.Location = new System.Drawing.Point(786, 594);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 14);
            this.label9.TabIndex = 10081;
            this.label9.Text = "零出差价￥:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.Visible = false;
            // 
            // frmRptGoWayStorageStat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 608);
            this.Controls.Add(this.m_lblretailoutlossSum);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.m_lblretailpriceSum);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.m_lbloutstoragepriceSum);
            this.Controls.Add(this.Label);
            this.Controls.Add(this.m_dgvGoWayMedStorageStat);
            this.Controls.Add(this.m_dgvGoWayStorageStat);
            this.Controls.Add(this.dw);
            this.Controls.Add(this.gradientPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRptGoWayStorageStat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "药品去向汇总统计表";
            this.Load += new System.EventHandler(this.frmRptGoWayStorageStat_Load);
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvGoWayStorageStat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvGoWayMedStorageStat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private com.digitalwave.iCare.gui.HIS.GradientPanel gradientPanel1;
        internal com.digitalwave.Controls.Domain.EmrControls.ctlDeptSelected_EnterKeyActive m_txtReceiveDept;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox m_txtVendor;
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
        internal ControlLibrary.txtListView1 txtMedType;
        private System.Windows.Forms.Label label1;
        internal Sybase.DataWindow.DataWindowControl dw;
        internal System.Windows.Forms.DataGridView m_dgvGoWayStorageStat;
        internal com.digitalwave.iCare.gui.MedicineStore_Maintain.exComboBox m_cboMedStorage;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtdeptid;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtdeptname;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtallprice;
        internal System.Windows.Forms.DataGridView m_dgvGoWayMedStorageStat;
        internal System.Windows.Forms.Label m_lbloutstoragepriceSum;
        internal System.Windows.Forms.Label Label;
        internal System.Windows.Forms.Label m_lblretailpriceSum;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label m_lblretailoutlossSum;
        internal System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtaskdept_chr;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtdeptname_vchr;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtoutstorageprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtretailprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtretailoutloss;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvSortRowNo;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab m_dtpEndDate;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab m_dtpBeginDate;
    }
}