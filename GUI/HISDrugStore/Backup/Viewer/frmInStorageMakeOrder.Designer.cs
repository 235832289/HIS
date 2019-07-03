namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmInStorageMakeOrder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInStorageMakeOrder));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            this.m_bgwGetData = new System.ComponentModel.BackgroundWorker();
            this.m_dgvDetail = new com.digitalwave.controls.MedicineStoreControls.ctlDataGridView_EnterAsTab();
            this.gradientPanel2 = new com.digitalwave.iCare.gui.HIS.GradientPanel();
            this.m_txtComment = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_cboStatus = new com.digitalwave.iCare.gui.HIS.exComboBox();
            this.m_txtFromDept = new com.digitalwave.Controls.Domain.EmrControls.ctlDeptSelected_EnterKeyActive();
            this.label4 = new System.Windows.Forms.Label();
            this.m_cboMedStore = new com.digitalwave.iCare.gui.HIS.exComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.m_txtMaker = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.m_datMakeDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtBillId = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.m_btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnInsert = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnExit = new System.Windows.Forms.ToolStripButton();
            this.m_datValidPeriod = new NullableDateControls.MaskDateEdit();
            this.m_lblRetail = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.m_dgvtxtSerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedicineCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedicineName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedicineSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productorid_chr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_txtLotsNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VALIDPERIOD_DAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount_int = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit_chr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtOutAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtOutUint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtInAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtInUint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WHOLESALEPRICE_INT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColOPWHOLESALEPRICE_INT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIPWHOLESALEPRICE_INT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RETAILPRICE_INT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColOPRETAILPRICE_INT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIPRETAILPRICE_INT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.retailmoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvPackDec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.medicineid_chr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_txtinstorageid_vchr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_txtinstoragedate_dat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.opchargeflg_int = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ipchargeflg_int = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvDetail)).BeginInit();
            this.gradientPanel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_bgwGetData
            // 
            this.m_bgwGetData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.m_bgwGetData_DoWork);
            this.m_bgwGetData.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.m_bgwGetData_RunWorkerCompleted);
            // 
            // m_dgvDetail
            // 
            this.m_dgvDetail.AllowUserToAddRows = false;
            this.m_dgvDetail.AllowUserToDeleteRows = false;
            this.m_dgvDetail.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Linen;
            this.m_dgvDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.m_dgvDetail.BackgroundColor = System.Drawing.SystemColors.Window;
            this.m_dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.m_dgvDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.m_dgvDetail.ColumnHeadersHeight = 30;
            this.m_dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_dgvtxtSerialNumber,
            this.m_dgvtxtMedicineCode,
            this.m_dgvtxtMedicineName,
            this.m_dgvtxtMedicineSpec,
            this.productorid_chr,
            this.m_txtLotsNo,
            this.VALIDPERIOD_DAT,
            this.amount_int,
            this.unit_chr,
            this.m_dgvtxtOutAmount,
            this.m_dgvtxtOutUint,
            this.m_dgvtxtInAmount,
            this.m_dgvtxtInUint,
            this.WHOLESALEPRICE_INT,
            this.ColOPWHOLESALEPRICE_INT,
            this.ColIPWHOLESALEPRICE_INT,
            this.RETAILPRICE_INT,
            this.ColOPRETAILPRICE_INT,
            this.ColIPRETAILPRICE_INT,
            this.retailmoney,
            this.m_dgvPackDec,
            this.Column7,
            this.medicineid_chr,
            this.m_txtinstorageid_vchr,
            this.m_txtinstoragedate_dat,
            this.opchargeflg_int,
            this.ipchargeflg_int});
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.m_dgvDetail.DefaultCellStyle = dataGridViewCellStyle18;
            this.m_dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.m_dgvDetail.Location = new System.Drawing.Point(0, 111);
            this.m_dgvDetail.Name = "m_dgvDetail";
            this.m_dgvDetail.RowHeadersVisible = false;
            this.m_dgvDetail.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.m_dgvDetail.RowTemplate.Height = 24;
            this.m_dgvDetail.Size = new System.Drawing.Size(922, 582);
            this.m_dgvDetail.TabIndex = 1;
            this.m_dgvDetail.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvDetail_CellLeave);
            this.m_dgvDetail.EnterKeyPress += new com.digitalwave.controls.MedicineStoreControls.EnterKeyPressInCurrentCell(this.m_dgvDetail_EnterKeyPress);
            this.m_dgvDetail.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.m_dgvDetail_RowsAdded);
            this.m_dgvDetail.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvDetail_CellEndEdit);
            this.m_dgvDetail.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvDetail_CellValueChanged);
            this.m_dgvDetail.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.m_dgvDetail_DataError);
            this.m_dgvDetail.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvDetail_CellEnter);
            this.m_dgvDetail.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.m_dgvDetail_RowsRemoved);
            // 
            // gradientPanel2
            // 
            this.gradientPanel2.Controls.Add(this.m_txtComment);
            this.gradientPanel2.Controls.Add(this.label2);
            this.gradientPanel2.Controls.Add(this.m_cboStatus);
            this.gradientPanel2.Controls.Add(this.m_txtFromDept);
            this.gradientPanel2.Controls.Add(this.label4);
            this.gradientPanel2.Controls.Add(this.m_cboMedStore);
            this.gradientPanel2.Controls.Add(this.label8);
            this.gradientPanel2.Controls.Add(this.m_txtMaker);
            this.gradientPanel2.Controls.Add(this.label7);
            this.gradientPanel2.Controls.Add(this.m_datMakeDate);
            this.gradientPanel2.Controls.Add(this.label3);
            this.gradientPanel2.Controls.Add(this.m_txtBillId);
            this.gradientPanel2.Controls.Add(this.label24);
            this.gradientPanel2.Controls.Add(this.label1);
            this.gradientPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel2.Flip = true;
            this.gradientPanel2.FloatingImage = null;
            this.gradientPanel2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gradientPanel2.GradientAngle = 90;
            this.gradientPanel2.GradientEndColor = System.Drawing.SystemColors.Control;
            this.gradientPanel2.GradientStartColor = System.Drawing.Color.White;
            this.gradientPanel2.HorizontalFillPercent = 100F;
            this.gradientPanel2.imageXOffset = 0;
            this.gradientPanel2.imageYOffset = 0;
            this.gradientPanel2.Location = new System.Drawing.Point(0, 35);
            this.gradientPanel2.Name = "gradientPanel2";
            this.gradientPanel2.Size = new System.Drawing.Size(922, 76);
            this.gradientPanel2.TabIndex = 0;
            this.gradientPanel2.VerticalFillPercent = 100F;
            // 
            // m_txtComment
            // 
            this.m_txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_txtComment.Location = new System.Drawing.Point(525, 42);
            this.m_txtComment.Name = "m_txtComment";
            this.m_txtComment.Size = new System.Drawing.Size(381, 23);
            this.m_txtComment.TabIndex = 5;
            this.m_txtComment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtComment_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(457, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 113;
            this.label2.Text = "单据备注";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cboStatus
            // 
            this.m_cboStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_cboStatus.FormattingEnabled = true;
            this.m_cboStatus.Location = new System.Drawing.Point(525, 14);
            this.m_cboStatus.Name = "m_cboStatus";
            this.m_cboStatus.Size = new System.Drawing.Size(144, 22);
            this.m_cboStatus.TabIndex = 1;
            this.m_cboStatus.Enter += new System.EventHandler(this.m_cboStatus_Enter);
            this.m_cboStatus.SelectedIndexChanged += new System.EventHandler(this.m_cboStatus_SelectedIndexChanged);
            this.m_cboStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cboStatus_KeyDown);
            // 
            // m_txtFromDept
            // 
            this.m_txtFromDept.Location = new System.Drawing.Point(764, 13);
            this.m_txtFromDept.m_objTag = null;
            this.m_txtFromDept.Name = "m_txtFromDept";
            this.m_txtFromDept.Size = new System.Drawing.Size(142, 23);
            this.m_txtFromDept.TabIndex = 3;
            this.m_txtFromDept.显示类型 = com.digitalwave.Controls.Domain.EmrControls.enmDeptAttributeType.全部;
            this.m_txtFromDept.FocusNextControl += new System.EventHandler(this.m_txtFromDept_FocusNextControl);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(694, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 27);
            this.label4.TabIndex = 5;
            this.label4.Text = "来源部门";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cboMedStore
            // 
            this.m_cboMedStore.Location = new System.Drawing.Point(83, 44);
            this.m_cboMedStore.Name = "m_cboMedStore";
            this.m_cboMedStore.Size = new System.Drawing.Size(126, 22);
            this.m_cboMedStore.TabIndex = 4;
            this.m_cboMedStore.Enter += new System.EventHandler(this.m_cboStatus_Enter);
            this.m_cboMedStore.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthControls_KeyDown);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(13, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 17);
            this.label8.TabIndex = 108;
            this.label8.Text = "入库药房";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtMaker
            // 
            this.m_txtMaker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_txtMaker.BackColor = System.Drawing.Color.White;
            this.m_txtMaker.Location = new System.Drawing.Point(299, 14);
            this.m_txtMaker.Name = "m_txtMaker";
            this.m_txtMaker.ReadOnly = true;
            this.m_txtMaker.Size = new System.Drawing.Size(144, 23);
            this.m_txtMaker.TabIndex = 2;
            this.m_txtMaker.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthControls_KeyDown);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(231, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 106;
            this.label7.Text = "制 单 人";
            // 
            // m_datMakeDate
            // 
            this.m_datMakeDate.CustomFormat = "yyyy年MM月dd日";
            this.m_datMakeDate.Enabled = false;
            this.m_datMakeDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_datMakeDate.Location = new System.Drawing.Point(83, 14);
            this.m_datMakeDate.Name = "m_datMakeDate";
            this.m_datMakeDate.Size = new System.Drawing.Size(126, 23);
            this.m_datMakeDate.TabIndex = 6;
            this.m_datMakeDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthControls_KeyDown);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(457, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 102;
            this.label3.Text = "入库类型";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtBillId
            // 
            this.m_txtBillId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_txtBillId.BackColor = System.Drawing.Color.White;
            this.m_txtBillId.Location = new System.Drawing.Point(299, 42);
            this.m_txtBillId.Name = "m_txtBillId";
            this.m_txtBillId.ReadOnly = true;
            this.m_txtBillId.Size = new System.Drawing.Size(144, 23);
            this.m_txtBillId.TabIndex = 6;
            this.m_txtBillId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthControls_KeyDown);
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Location = new System.Drawing.Point(231, 47);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(63, 14);
            this.label24.TabIndex = 100;
            this.label24.Text = "单 据 号";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "制单时间";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_btnSave,
            this.toolStripSeparator1,
            this.m_btnInsert,
            this.toolStripSeparator2,
            this.m_btnDelete,
            this.toolStripSeparator4,
            this.m_btnPrint,
            this.toolStripSeparator3,
            this.m_btnNext,
            this.toolStripSeparator5,
            this.m_btnExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(922, 35);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // m_btnSave
            // 
            this.m_btnSave.Image = ((System.Drawing.Image)(resources.GetObject("m_btnSave.Image")));
            this.m_btnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnSave.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Size = new System.Drawing.Size(76, 32);
            this.m_btnSave.Text = "保存(&S)";
            this.m_btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 35);
            // 
            // m_btnInsert
            // 
            this.m_btnInsert.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnInsert.Image = ((System.Drawing.Image)(resources.GetObject("m_btnInsert.Image")));
            this.m_btnInsert.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_btnInsert.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnInsert.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_btnInsert.Name = "m_btnInsert";
            this.m_btnInsert.Size = new System.Drawing.Size(76, 32);
            this.m_btnInsert.Text = "插入(&I)";
            this.m_btnInsert.Click += new System.EventHandler(this.m_btnInsert_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 35);
            // 
            // m_btnDelete
            // 
            this.m_btnDelete.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("m_btnDelete.Image")));
            this.m_btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_btnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnDelete.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_btnDelete.Name = "m_btnDelete";
            this.m_btnDelete.Size = new System.Drawing.Size(76, 32);
            this.m_btnDelete.Text = "删除(&D)";
            this.m_btnDelete.Click += new System.EventHandler(this.m_btnDelete_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 35);
            // 
            // m_btnPrint
            // 
            this.m_btnPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("m_btnPrint.Image")));
            this.m_btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_btnPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnPrint.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_btnPrint.Name = "m_btnPrint";
            this.m_btnPrint.Size = new System.Drawing.Size(76, 32);
            this.m_btnPrint.Text = "打印(&P)";
            this.m_btnPrint.Click += new System.EventHandler(this.m_btnPrint_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 35);
            // 
            // m_btnNext
            // 
            this.m_btnNext.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnNext.Image = ((System.Drawing.Image)(resources.GetObject("m_btnNext.Image")));
            this.m_btnNext.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnNext.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_btnNext.Name = "m_btnNext";
            this.m_btnNext.Size = new System.Drawing.Size(104, 32);
            this.m_btnNext.Text = "下一张单(&N)";
            this.m_btnNext.Click += new System.EventHandler(this.m_btnNext_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 35);
            // 
            // m_btnExit
            // 
            this.m_btnExit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnExit.Image = ((System.Drawing.Image)(resources.GetObject("m_btnExit.Image")));
            this.m_btnExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnExit.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_btnExit.Name = "m_btnExit";
            this.m_btnExit.Size = new System.Drawing.Size(76, 32);
            this.m_btnExit.Text = "关闭(&Q)";
            this.m_btnExit.Click += new System.EventHandler(this.m_btnExit_Click);
            // 
            // m_datValidPeriod
            // 
            this.m_datValidPeriod.BackColor = System.Drawing.SystemColors.HighlightText;
            this.m_datValidPeriod.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_datValidPeriod.Location = new System.Drawing.Point(430, 675);
            this.m_datValidPeriod.Mask = "yyyy年MM月dd日";
            this.m_datValidPeriod.Name = "m_datValidPeriod";
            this.m_datValidPeriod.Size = new System.Drawing.Size(120, 23);
            this.m_datValidPeriod.TabIndex = 10006;
            this.m_datValidPeriod.Visible = false;
            this.m_datValidPeriod.VisibleChanged += new System.EventHandler(this.m_datValidPeriod_VisibleChanged);
            this.m_datValidPeriod.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.m_datValidPeriod_PreviewKeyDown);
            this.m_datValidPeriod.Leave += new System.EventHandler(this.m_datValidPeriod_Leave);
            this.m_datValidPeriod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_datValidPeriod_KeyDown);
            // 
            // m_lblRetail
            // 
            this.m_lblRetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblRetail.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblRetail.ForeColor = System.Drawing.Color.Maroon;
            this.m_lblRetail.Location = new System.Drawing.Point(732, 678);
            this.m_lblRetail.Name = "m_lblRetail";
            this.m_lblRetail.Size = new System.Drawing.Size(171, 15);
            this.m_lblRetail.TabIndex = 10008;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.Maroon;
            this.label11.Location = new System.Drawing.Point(635, 678);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 15);
            this.label11.TabIndex = 10007;
            this.label11.Text = "零售金额￥：";
            // 
            // m_dgvtxtSerialNumber
            // 
            this.m_dgvtxtSerialNumber.Frozen = true;
            this.m_dgvtxtSerialNumber.HeaderText = "No.";
            this.m_dgvtxtSerialNumber.Name = "m_dgvtxtSerialNumber";
            this.m_dgvtxtSerialNumber.ReadOnly = true;
            this.m_dgvtxtSerialNumber.Width = 35;
            // 
            // m_dgvtxtMedicineCode
            // 
            this.m_dgvtxtMedicineCode.DataPropertyName = "assistcode_chr";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.m_dgvtxtMedicineCode.DefaultCellStyle = dataGridViewCellStyle3;
            this.m_dgvtxtMedicineCode.HeaderText = "药品代码";
            this.m_dgvtxtMedicineCode.Name = "m_dgvtxtMedicineCode";
            this.m_dgvtxtMedicineCode.Width = 80;
            // 
            // m_dgvtxtMedicineName
            // 
            this.m_dgvtxtMedicineName.DataPropertyName = "MEDICINENAME_VCHR";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.m_dgvtxtMedicineName.DefaultCellStyle = dataGridViewCellStyle4;
            this.m_dgvtxtMedicineName.HeaderText = "药品名称";
            this.m_dgvtxtMedicineName.Name = "m_dgvtxtMedicineName";
            this.m_dgvtxtMedicineName.ReadOnly = true;
            // 
            // m_dgvtxtMedicineSpec
            // 
            this.m_dgvtxtMedicineSpec.DataPropertyName = "MEDSPEC_VCHR";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.m_dgvtxtMedicineSpec.DefaultCellStyle = dataGridViewCellStyle5;
            this.m_dgvtxtMedicineSpec.HeaderText = "药品规格";
            this.m_dgvtxtMedicineSpec.Name = "m_dgvtxtMedicineSpec";
            this.m_dgvtxtMedicineSpec.ReadOnly = true;
            this.m_dgvtxtMedicineSpec.Width = 80;
            // 
            // productorid_chr
            // 
            this.productorid_chr.DataPropertyName = "productorid_chr";
            this.productorid_chr.HeaderText = "  生产厂家";
            this.productorid_chr.Name = "productorid_chr";
            this.productorid_chr.ReadOnly = true;
            this.productorid_chr.Visible = false;
            // 
            // m_txtLotsNo
            // 
            this.m_txtLotsNo.DataPropertyName = "LOTNO_VCHR";
            this.m_txtLotsNo.HeaderText = "批号";
            this.m_txtLotsNo.Name = "m_txtLotsNo";
            this.m_txtLotsNo.Width = 60;
            // 
            // VALIDPERIOD_DAT
            // 
            this.VALIDPERIOD_DAT.DataPropertyName = "VALIDPERIOD_DAT";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.VALIDPERIOD_DAT.DefaultCellStyle = dataGridViewCellStyle6;
            this.VALIDPERIOD_DAT.HeaderText = "    有效期";
            this.VALIDPERIOD_DAT.Name = "VALIDPERIOD_DAT";
            this.VALIDPERIOD_DAT.Width = 120;
            // 
            // amount_int
            // 
            this.amount_int.DataPropertyName = "amount_int";
            this.amount_int.HeaderText = "入库数量";
            this.amount_int.Name = "amount_int";
            // 
            // unit_chr
            // 
            this.unit_chr.DataPropertyName = "unit_chr";
            this.unit_chr.HeaderText = "门诊单位";
            this.unit_chr.Name = "unit_chr";
            this.unit_chr.ReadOnly = true;
            // 
            // m_dgvtxtOutAmount
            // 
            this.m_dgvtxtOutAmount.DataPropertyName = "OPAMOUNT_INT";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = "0";
            this.m_dgvtxtOutAmount.DefaultCellStyle = dataGridViewCellStyle7;
            this.m_dgvtxtOutAmount.HeaderText = "入库数量";
            this.m_dgvtxtOutAmount.Name = "m_dgvtxtOutAmount";
            this.m_dgvtxtOutAmount.Visible = false;
            this.m_dgvtxtOutAmount.Width = 80;
            // 
            // m_dgvtxtOutUint
            // 
            this.m_dgvtxtOutUint.DataPropertyName = "OPUNIT_CHR";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.m_dgvtxtOutUint.DefaultCellStyle = dataGridViewCellStyle8;
            this.m_dgvtxtOutUint.HeaderText = "单位(基本)";
            this.m_dgvtxtOutUint.Name = "m_dgvtxtOutUint";
            this.m_dgvtxtOutUint.ReadOnly = true;
            this.m_dgvtxtOutUint.Visible = false;
            this.m_dgvtxtOutUint.Width = 90;
            // 
            // m_dgvtxtInAmount
            // 
            this.m_dgvtxtInAmount.DataPropertyName = "IPAMOUNT_INT";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.m_dgvtxtInAmount.DefaultCellStyle = dataGridViewCellStyle9;
            this.m_dgvtxtInAmount.HeaderText = "入库数量";
            this.m_dgvtxtInAmount.Name = "m_dgvtxtInAmount";
            this.m_dgvtxtInAmount.ReadOnly = true;
            this.m_dgvtxtInAmount.Visible = false;
            this.m_dgvtxtInAmount.Width = 80;
            // 
            // m_dgvtxtInUint
            // 
            this.m_dgvtxtInUint.DataPropertyName = "IPUNIT_CHR";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.m_dgvtxtInUint.DefaultCellStyle = dataGridViewCellStyle10;
            this.m_dgvtxtInUint.HeaderText = "单位(最小)";
            this.m_dgvtxtInUint.Name = "m_dgvtxtInUint";
            this.m_dgvtxtInUint.ReadOnly = true;
            this.m_dgvtxtInUint.Visible = false;
            this.m_dgvtxtInUint.Width = 90;
            // 
            // WHOLESALEPRICE_INT
            // 
            this.WHOLESALEPRICE_INT.DataPropertyName = "WHOLESALEPRICE_INT";
            this.WHOLESALEPRICE_INT.HeaderText = "购入单价";
            this.WHOLESALEPRICE_INT.Name = "WHOLESALEPRICE_INT";
            this.WHOLESALEPRICE_INT.ReadOnly = true;
            this.WHOLESALEPRICE_INT.Visible = false;
            // 
            // ColOPWHOLESALEPRICE_INT
            // 
            this.ColOPWHOLESALEPRICE_INT.DataPropertyName = "OPWHOLESALEPRICE_INT";
            dataGridViewCellStyle11.Format = "N4";
            this.ColOPWHOLESALEPRICE_INT.DefaultCellStyle = dataGridViewCellStyle11;
            this.ColOPWHOLESALEPRICE_INT.HeaderText = "购入单价(基本)";
            this.ColOPWHOLESALEPRICE_INT.Name = "ColOPWHOLESALEPRICE_INT";
            this.ColOPWHOLESALEPRICE_INT.ReadOnly = true;
            this.ColOPWHOLESALEPRICE_INT.Visible = false;
            this.ColOPWHOLESALEPRICE_INT.Width = 115;
            // 
            // ColIPWHOLESALEPRICE_INT
            // 
            this.ColIPWHOLESALEPRICE_INT.DataPropertyName = "IPWHOLESALEPRICE_INT";
            dataGridViewCellStyle12.Format = "N4";
            this.ColIPWHOLESALEPRICE_INT.DefaultCellStyle = dataGridViewCellStyle12;
            this.ColIPWHOLESALEPRICE_INT.HeaderText = "购入单价(最小)";
            this.ColIPWHOLESALEPRICE_INT.Name = "ColIPWHOLESALEPRICE_INT";
            this.ColIPWHOLESALEPRICE_INT.ReadOnly = true;
            this.ColIPWHOLESALEPRICE_INT.Visible = false;
            this.ColIPWHOLESALEPRICE_INT.Width = 115;
            // 
            // RETAILPRICE_INT
            // 
            this.RETAILPRICE_INT.DataPropertyName = "RETAILPRICE_INT";
            this.RETAILPRICE_INT.HeaderText = "零售单价";
            this.RETAILPRICE_INT.Name = "RETAILPRICE_INT";
            this.RETAILPRICE_INT.ReadOnly = true;
            // 
            // ColOPRETAILPRICE_INT
            // 
            this.ColOPRETAILPRICE_INT.DataPropertyName = "OPRETAILPRICE_INT";
            dataGridViewCellStyle13.Format = "N4";
            this.ColOPRETAILPRICE_INT.DefaultCellStyle = dataGridViewCellStyle13;
            this.ColOPRETAILPRICE_INT.HeaderText = "零售单价(基本)";
            this.ColOPRETAILPRICE_INT.Name = "ColOPRETAILPRICE_INT";
            this.ColOPRETAILPRICE_INT.ReadOnly = true;
            this.ColOPRETAILPRICE_INT.Visible = false;
            this.ColOPRETAILPRICE_INT.Width = 115;
            // 
            // ColIPRETAILPRICE_INT
            // 
            this.ColIPRETAILPRICE_INT.DataPropertyName = "IPRETAILPRICE_INT";
            dataGridViewCellStyle14.Format = "N4";
            this.ColIPRETAILPRICE_INT.DefaultCellStyle = dataGridViewCellStyle14;
            this.ColIPRETAILPRICE_INT.HeaderText = "零售单价(最小)";
            this.ColIPRETAILPRICE_INT.Name = "ColIPRETAILPRICE_INT";
            this.ColIPRETAILPRICE_INT.ReadOnly = true;
            this.ColIPRETAILPRICE_INT.Visible = false;
            this.ColIPRETAILPRICE_INT.Width = 115;
            // 
            // retailmoney
            // 
            this.retailmoney.DataPropertyName = "retailmoney";
            dataGridViewCellStyle15.Format = "N4";
            dataGridViewCellStyle15.NullValue = null;
            this.retailmoney.DefaultCellStyle = dataGridViewCellStyle15;
            this.retailmoney.HeaderText = "零售金额";
            this.retailmoney.Name = "retailmoney";
            this.retailmoney.ReadOnly = true;
            // 
            // m_dgvPackDec
            // 
            this.m_dgvPackDec.DataPropertyName = "PACKQTY_DEC";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.m_dgvPackDec.DefaultCellStyle = dataGridViewCellStyle16;
            this.m_dgvPackDec.HeaderText = "包装量";
            this.m_dgvPackDec.Name = "m_dgvPackDec";
            this.m_dgvPackDec.ReadOnly = true;
            this.m_dgvPackDec.Width = 60;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "STATUS";
            this.Column7.HeaderText = "状态";
            this.Column7.Name = "Column7";
            this.Column7.Visible = false;
            // 
            // medicineid_chr
            // 
            this.medicineid_chr.DataPropertyName = "medicineid_chr";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.medicineid_chr.DefaultCellStyle = dataGridViewCellStyle17;
            this.medicineid_chr.HeaderText = "药品ID";
            this.medicineid_chr.Name = "medicineid_chr";
            this.medicineid_chr.ReadOnly = true;
            this.medicineid_chr.Visible = false;
            // 
            // m_txtinstorageid_vchr
            // 
            this.m_txtinstorageid_vchr.DataPropertyName = "instoreid_vchr";
            this.m_txtinstorageid_vchr.HeaderText = "药库入库单据号";
            this.m_txtinstorageid_vchr.Name = "m_txtinstorageid_vchr";
            this.m_txtinstorageid_vchr.Visible = false;
            // 
            // m_txtinstoragedate_dat
            // 
            this.m_txtinstoragedate_dat.DataPropertyName = "instoragedate_dat";
            this.m_txtinstoragedate_dat.HeaderText = "药库入库时间";
            this.m_txtinstoragedate_dat.Name = "m_txtinstoragedate_dat";
            this.m_txtinstoragedate_dat.Visible = false;
            // 
            // opchargeflg_int
            // 
            this.opchargeflg_int.DataPropertyName = "opchargeflg_int";
            this.opchargeflg_int.HeaderText = "门诊单位值";
            this.opchargeflg_int.Name = "opchargeflg_int";
            this.opchargeflg_int.ReadOnly = true;
            this.opchargeflg_int.Visible = false;
            // 
            // ipchargeflg_int
            // 
            this.ipchargeflg_int.DataPropertyName = "ipchargeflg_int";
            this.ipchargeflg_int.HeaderText = "住院单位值";
            this.ipchargeflg_int.Name = "ipchargeflg_int";
            this.ipchargeflg_int.ReadOnly = true;
            this.ipchargeflg_int.Visible = false;
            // 
            // frmInStorageMakeOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 693);
            this.Controls.Add(this.m_lblRetail);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.m_datValidPeriod);
            this.Controls.Add(this.m_dgvDetail);
            this.Controls.Add(this.gradientPanel2);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmInStorageMakeOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "药房入库制单";
            this.Load += new System.EventHandler(this.frmInStorageMakeOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvDetail)).EndInit();
            this.gradientPanel2.ResumeLayout(false);
            this.gradientPanel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal GradientPanel gradientPanel2;
        internal com.digitalwave.Controls.Domain.EmrControls.ctlDeptSelected_EnterKeyActive m_txtFromDept;
        internal System.Windows.Forms.Label label4;
        internal exComboBox m_cboMedStore;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox m_txtMaker;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.DateTimePicker m_datMakeDate;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox m_txtBillId;
        internal System.Windows.Forms.Label label24;
        internal System.Windows.Forms.Label label1;
        internal com.digitalwave.controls.MedicineStoreControls.ctlDataGridView_EnterAsTab m_dgvDetail;
        internal System.Windows.Forms.ToolStrip toolStrip1;
        internal System.Windows.Forms.ToolStripButton m_btnSave;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        internal System.Windows.Forms.ToolStripButton m_btnInsert;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        internal System.Windows.Forms.ToolStripButton m_btnDelete;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        internal System.Windows.Forms.ToolStripButton m_btnPrint;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        internal System.Windows.Forms.ToolStripButton m_btnNext;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        internal System.Windows.Forms.ToolStripButton m_btnExit;
        internal exComboBox m_cboStatus;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox m_txtComment;
        private System.ComponentModel.BackgroundWorker m_bgwGetData;
        internal NullableDateControls.MaskDateEdit m_datValidPeriod;
        internal System.Windows.Forms.Label m_lblRetail;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtSerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn productorid_chr;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_txtLotsNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn VALIDPERIOD_DAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount_int;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit_chr;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtOutAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtOutUint;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtInAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtInUint;
        private System.Windows.Forms.DataGridViewTextBoxColumn WHOLESALEPRICE_INT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColOPWHOLESALEPRICE_INT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIPWHOLESALEPRICE_INT;
        private System.Windows.Forms.DataGridViewTextBoxColumn RETAILPRICE_INT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColOPRETAILPRICE_INT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIPRETAILPRICE_INT;
        private System.Windows.Forms.DataGridViewTextBoxColumn retailmoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvPackDec;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn medicineid_chr;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_txtinstorageid_vchr;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_txtinstoragedate_dat;
        private System.Windows.Forms.DataGridViewTextBoxColumn opchargeflg_int;
        private System.Windows.Forms.DataGridViewTextBoxColumn ipchargeflg_int;
    }
}