namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmAskForMedDetail
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAskForMedDetail));
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
            this.m_dgvDetail = new com.digitalwave.controls.MedicineStoreControls.ctlDataGridView_EnterAsTab();
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
            this.gradientPanel2 = new com.digitalwave.iCare.gui.HIS.GradientPanel();
            this.m_cboAskDept = new com.digitalwave.iCare.gui.HIS.exComboBox();
            this.m_cboExportDept = new com.digitalwave.iCare.gui.HIS.exComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_datApplyDate = new System.Windows.Forms.DateTimePicker();
            this.m_txtAsker = new System.Windows.Forms.TextBox();
            this.m_txtComment = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtAskBillNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_lblRetailSubMoney = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.dataStore1 = new Sybase.DataWindow.DataStore(this.components);
            this.m_dgvtxtSerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedicineCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedicineName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedicineSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productorid_chr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requestamount_int = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requestunit_chr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtOutAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtOutUint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AMOUNT_INT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit_chr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtInAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtInUint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvPackDec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.medicineid_chr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RetailSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requestpackqty_dec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvDetail)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.gradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataStore1)).BeginInit();
            this.SuspendLayout();
            // 
            // m_dgvDetail
            // 
            this.m_dgvDetail.AllowUserToAddRows = false;
            this.m_dgvDetail.AllowUserToDeleteRows = false;
            this.m_dgvDetail.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Linen;
            this.m_dgvDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.m_dgvDetail.BackgroundColor = System.Drawing.Color.White;
            this.m_dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_dgvDetail.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgvDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.m_dgvDetail.ColumnHeadersHeight = 25;
            this.m_dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_dgvtxtSerialNumber,
            this.m_dgvtxtMedicineCode,
            this.m_dgvtxtMedicineName,
            this.m_dgvtxtMedicineSpec,
            this.productorid_chr,
            this.requestamount_int,
            this.requestunit_chr,
            this.m_dgvtxtOutAmount,
            this.m_dgvtxtOutUint,
            this.AMOUNT_INT,
            this.unit_chr,
            this.m_dgvtxtInAmount,
            this.m_dgvtxtInUint,
            this.m_dgvPackDec,
            this.medicineid_chr,
            this.m_dgvtxtUnitPrice,
            this.RetailSum,
            this.requestpackqty_dec});
            this.m_dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.m_dgvDetail.Location = new System.Drawing.Point(0, 84);
            this.m_dgvDetail.Name = "m_dgvDetail";
            this.m_dgvDetail.RowHeadersVisible = false;
            this.m_dgvDetail.RowTemplate.Height = 23;
            this.m_dgvDetail.Size = new System.Drawing.Size(1002, 589);
            this.m_dgvDetail.TabIndex = 1;
            this.m_dgvDetail.EnterKeyPress += new com.digitalwave.controls.MedicineStoreControls.EnterKeyPressInCurrentCell(this.m_dgvDetail_EnterKeyPress);
            this.m_dgvDetail.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.m_dgvDetail_RowsAdded);
            this.m_dgvDetail.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvDetail_CellEndEdit);
            this.m_dgvDetail.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.m_dgvDetail_DataError);
            this.m_dgvDetail.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvDetail_CellEnter);
            this.m_dgvDetail.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.m_dgvDetail_RowsRemoved);
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
            this.toolStrip1.Size = new System.Drawing.Size(1002, 35);
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
            // gradientPanel2
            // 
            this.gradientPanel2.Controls.Add(this.m_cboAskDept);
            this.gradientPanel2.Controls.Add(this.m_cboExportDept);
            this.gradientPanel2.Controls.Add(this.label6);
            this.gradientPanel2.Controls.Add(this.m_datApplyDate);
            this.gradientPanel2.Controls.Add(this.m_txtAsker);
            this.gradientPanel2.Controls.Add(this.m_txtComment);
            this.gradientPanel2.Controls.Add(this.label3);
            this.gradientPanel2.Controls.Add(this.label5);
            this.gradientPanel2.Controls.Add(this.m_txtAskBillNo);
            this.gradientPanel2.Controls.Add(this.label1);
            this.gradientPanel2.Controls.Add(this.label4);
            this.gradientPanel2.Controls.Add(this.label2);
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
            this.gradientPanel2.Size = new System.Drawing.Size(1002, 49);
            this.gradientPanel2.TabIndex = 0;
            this.gradientPanel2.VerticalFillPercent = 100F;
            // 
            // m_cboAskDept
            // 
            this.m_cboAskDept.Location = new System.Drawing.Point(65, 14);
            this.m_cboAskDept.Name = "m_cboAskDept";
            this.m_cboAskDept.Size = new System.Drawing.Size(100, 22);
            this.m_cboAskDept.TabIndex = 1;
            this.m_cboAskDept.Enter += new System.EventHandler(this.m_cboExportDept_Enter);
            this.m_cboAskDept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthControls_KeyDown);
            // 
            // m_cboExportDept
            // 
            this.m_cboExportDept.Location = new System.Drawing.Point(227, 14);
            this.m_cboExportDept.Name = "m_cboExportDept";
            this.m_cboExportDept.Size = new System.Drawing.Size(98, 22);
            this.m_cboExportDept.TabIndex = 2;
            this.m_cboExportDept.Enter += new System.EventHandler(this.m_cboExportDept_Enter);
            this.m_cboExportDept.SelectedIndexChanged += new System.EventHandler(this.m_cboExportDept_SelectedIndexChanged);
            this.m_cboExportDept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthControls_KeyDown);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(165, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 27);
            this.label6.TabIndex = 30;
            this.label6.Text = "出库部门";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_datApplyDate
            // 
            this.m_datApplyDate.CustomFormat = "yyyy年MM月dd日";
            this.m_datApplyDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_datApplyDate.Location = new System.Drawing.Point(561, 14);
            this.m_datApplyDate.Name = "m_datApplyDate";
            this.m_datApplyDate.Size = new System.Drawing.Size(119, 23);
            this.m_datApplyDate.TabIndex = 4;
            this.m_datApplyDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_datApplyDate_KeyDown);
            // 
            // m_txtAsker
            // 
            this.m_txtAsker.BackColor = System.Drawing.Color.White;
            this.m_txtAsker.Location = new System.Drawing.Point(732, 14);
            this.m_txtAsker.Name = "m_txtAsker";
            this.m_txtAsker.ReadOnly = true;
            this.m_txtAsker.Size = new System.Drawing.Size(85, 23);
            this.m_txtAsker.TabIndex = 5;
            // 
            // m_txtComment
            // 
            this.m_txtComment.Location = new System.Drawing.Point(858, 14);
            this.m_txtComment.Name = "m_txtComment";
            this.m_txtComment.Size = new System.Drawing.Size(138, 23);
            this.m_txtComment.TabIndex = 6;
            this.m_txtComment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtComment_KeyDown);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(822, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 27);
            this.label3.TabIndex = 28;
            this.label3.Text = "备注";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(681, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 27);
            this.label5.TabIndex = 26;
            this.label5.Text = "制单人";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtAskBillNo
            // 
            this.m_txtAskBillNo.BackColor = System.Drawing.Color.White;
            this.m_txtAskBillNo.Location = new System.Drawing.Point(389, 14);
            this.m_txtAskBillNo.Name = "m_txtAskBillNo";
            this.m_txtAskBillNo.ReadOnly = true;
            this.m_txtAskBillNo.Size = new System.Drawing.Size(106, 23);
            this.m_txtAskBillNo.TabIndex = 3;
            this.m_txtAskBillNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_datApplyDate_KeyDown);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(326, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 27);
            this.label1.TabIndex = 23;
            this.label1.Text = "请领单号";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(3, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 27);
            this.label4.TabIndex = 6;
            this.label4.Text = "请领部门";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(496, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 27);
            this.label2.TabIndex = 25;
            this.label2.Text = "请领时间";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblRetailSubMoney
            // 
            this.m_lblRetailSubMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblRetailSubMoney.BackColor = System.Drawing.SystemColors.Control;
            this.m_lblRetailSubMoney.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblRetailSubMoney.ForeColor = System.Drawing.Color.Maroon;
            this.m_lblRetailSubMoney.Location = new System.Drawing.Point(842, 658);
            this.m_lblRetailSubMoney.Name = "m_lblRetailSubMoney";
            this.m_lblRetailSubMoney.Size = new System.Drawing.Size(144, 15);
            this.m_lblRetailSubMoney.TabIndex = 10012;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.BackColor = System.Drawing.SystemColors.Control;
            this.label18.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.ForeColor = System.Drawing.Color.Maroon;
            this.label18.Location = new System.Drawing.Point(755, 658);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(99, 15);
            this.label18.TabIndex = 10011;
            this.label18.Text = "零售金额￥:";
            // 
            // dataStore1
            // 
            this.dataStore1.DataWindowObject = null;
            this.dataStore1.LibraryList = null;
            // 
            // m_dgvtxtSerialNumber
            // 
            this.m_dgvtxtSerialNumber.Frozen = true;
            this.m_dgvtxtSerialNumber.HeaderText = "No.";
            this.m_dgvtxtSerialNumber.Name = "m_dgvtxtSerialNumber";
            this.m_dgvtxtSerialNumber.ReadOnly = true;
            this.m_dgvtxtSerialNumber.Width = 40;
            // 
            // m_dgvtxtMedicineCode
            // 
            this.m_dgvtxtMedicineCode.DataPropertyName = "assistcode_chr";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.m_dgvtxtMedicineCode.DefaultCellStyle = dataGridViewCellStyle3;
            this.m_dgvtxtMedicineCode.HeaderText = "药品代码";
            this.m_dgvtxtMedicineCode.Name = "m_dgvtxtMedicineCode";
            this.m_dgvtxtMedicineCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.m_dgvtxtMedicineCode.Width = 120;
            // 
            // m_dgvtxtMedicineName
            // 
            this.m_dgvtxtMedicineName.DataPropertyName = "MEDICINENAME_VCHR";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.m_dgvtxtMedicineName.DefaultCellStyle = dataGridViewCellStyle4;
            this.m_dgvtxtMedicineName.HeaderText = "药品名称";
            this.m_dgvtxtMedicineName.Name = "m_dgvtxtMedicineName";
            this.m_dgvtxtMedicineName.ReadOnly = true;
            this.m_dgvtxtMedicineName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.m_dgvtxtMedicineName.Width = 180;
            // 
            // m_dgvtxtMedicineSpec
            // 
            this.m_dgvtxtMedicineSpec.DataPropertyName = "MEDSPEC_VCHR";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.m_dgvtxtMedicineSpec.DefaultCellStyle = dataGridViewCellStyle5;
            this.m_dgvtxtMedicineSpec.HeaderText = "药品规格";
            this.m_dgvtxtMedicineSpec.Name = "m_dgvtxtMedicineSpec";
            this.m_dgvtxtMedicineSpec.ReadOnly = true;
            this.m_dgvtxtMedicineSpec.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.m_dgvtxtMedicineSpec.Width = 140;
            // 
            // productorid_chr
            // 
            this.productorid_chr.DataPropertyName = "productorid_chr";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.productorid_chr.DefaultCellStyle = dataGridViewCellStyle6;
            this.productorid_chr.HeaderText = "生产厂家";
            this.productorid_chr.Name = "productorid_chr";
            this.productorid_chr.ReadOnly = true;
            this.productorid_chr.Visible = false;
            // 
            // requestamount_int
            // 
            this.requestamount_int.DataPropertyName = "requestamount_int";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = "0";
            this.requestamount_int.DefaultCellStyle = dataGridViewCellStyle7;
            this.requestamount_int.HeaderText = "请领数量";
            this.requestamount_int.Name = "requestamount_int";
            // 
            // requestunit_chr
            // 
            this.requestunit_chr.DataPropertyName = "requestunit_chr";
            this.requestunit_chr.HeaderText = "请领单位";
            this.requestunit_chr.Name = "requestunit_chr";
            this.requestunit_chr.ReadOnly = true;
            // 
            // m_dgvtxtOutAmount
            // 
            this.m_dgvtxtOutAmount.DataPropertyName = "OPAMOUNT_INT";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = "0";
            this.m_dgvtxtOutAmount.DefaultCellStyle = dataGridViewCellStyle8;
            this.m_dgvtxtOutAmount.HeaderText = "数量";
            this.m_dgvtxtOutAmount.Name = "m_dgvtxtOutAmount";
            this.m_dgvtxtOutAmount.ReadOnly = true;
            this.m_dgvtxtOutAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.m_dgvtxtOutAmount.Width = 110;
            // 
            // m_dgvtxtOutUint
            // 
            this.m_dgvtxtOutUint.DataPropertyName = "OPUNIT_CHR";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.m_dgvtxtOutUint.DefaultCellStyle = dataGridViewCellStyle9;
            this.m_dgvtxtOutUint.HeaderText = "包装单位";
            this.m_dgvtxtOutUint.Name = "m_dgvtxtOutUint";
            this.m_dgvtxtOutUint.ReadOnly = true;
            this.m_dgvtxtOutUint.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.m_dgvtxtOutUint.Width = 90;
            // 
            // AMOUNT_INT
            // 
            this.AMOUNT_INT.DataPropertyName = "AMOUNT_INT";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N2";
            dataGridViewCellStyle10.NullValue = "0";
            this.AMOUNT_INT.DefaultCellStyle = dataGridViewCellStyle10;
            this.AMOUNT_INT.HeaderText = "数量";
            this.AMOUNT_INT.Name = "AMOUNT_INT";
            this.AMOUNT_INT.ReadOnly = true;
            this.AMOUNT_INT.Width = 110;
            // 
            // unit_chr
            // 
            this.unit_chr.DataPropertyName = "UNIT_CHR";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.unit_chr.DefaultCellStyle = dataGridViewCellStyle11;
            this.unit_chr.HeaderText = "门诊单位";
            this.unit_chr.Name = "unit_chr";
            this.unit_chr.ReadOnly = true;
            this.unit_chr.Width = 90;
            // 
            // m_dgvtxtInAmount
            // 
            this.m_dgvtxtInAmount.DataPropertyName = "IPAMOUNT_INT";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N2";
            dataGridViewCellStyle12.NullValue = "0";
            this.m_dgvtxtInAmount.DefaultCellStyle = dataGridViewCellStyle12;
            this.m_dgvtxtInAmount.HeaderText = "数量";
            this.m_dgvtxtInAmount.Name = "m_dgvtxtInAmount";
            this.m_dgvtxtInAmount.ReadOnly = true;
            this.m_dgvtxtInAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.m_dgvtxtInAmount.Visible = false;
            this.m_dgvtxtInAmount.Width = 110;
            // 
            // m_dgvtxtInUint
            // 
            this.m_dgvtxtInUint.DataPropertyName = "IPUNIT_CHR";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.m_dgvtxtInUint.DefaultCellStyle = dataGridViewCellStyle13;
            this.m_dgvtxtInUint.HeaderText = "单位(最小)";
            this.m_dgvtxtInUint.Name = "m_dgvtxtInUint";
            this.m_dgvtxtInUint.ReadOnly = true;
            this.m_dgvtxtInUint.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.m_dgvtxtInUint.Visible = false;
            this.m_dgvtxtInUint.Width = 90;
            // 
            // m_dgvPackDec
            // 
            this.m_dgvPackDec.DataPropertyName = "PACKQTY_DEC";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.m_dgvPackDec.DefaultCellStyle = dataGridViewCellStyle14;
            this.m_dgvPackDec.HeaderText = "包装量";
            this.m_dgvPackDec.Name = "m_dgvPackDec";
            this.m_dgvPackDec.ReadOnly = true;
            this.m_dgvPackDec.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.m_dgvPackDec.Width = 120;
            // 
            // medicineid_chr
            // 
            this.medicineid_chr.DataPropertyName = "medicineid_chr";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.medicineid_chr.DefaultCellStyle = dataGridViewCellStyle15;
            this.medicineid_chr.HeaderText = "药品ID";
            this.medicineid_chr.Name = "medicineid_chr";
            this.medicineid_chr.ReadOnly = true;
            this.medicineid_chr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.medicineid_chr.Visible = false;
            // 
            // m_dgvtxtUnitPrice
            // 
            this.m_dgvtxtUnitPrice.DataPropertyName = "unitprice_mny";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.Format = "N4";
            dataGridViewCellStyle16.NullValue = null;
            this.m_dgvtxtUnitPrice.DefaultCellStyle = dataGridViewCellStyle16;
            this.m_dgvtxtUnitPrice.HeaderText = "零售单价";
            this.m_dgvtxtUnitPrice.Name = "m_dgvtxtUnitPrice";
            this.m_dgvtxtUnitPrice.ReadOnly = true;
            // 
            // RetailSum
            // 
            this.RetailSum.DataPropertyName = "retailsum";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.RetailSum.DefaultCellStyle = dataGridViewCellStyle17;
            this.RetailSum.HeaderText = "零售金额";
            this.RetailSum.Name = "RetailSum";
            this.RetailSum.ReadOnly = true;
            // 
            // requestpackqty_dec
            // 
            this.requestpackqty_dec.DataPropertyName = "requestpackqty_dec";
            this.requestpackqty_dec.HeaderText = "请领包装量";
            this.requestpackqty_dec.Name = "requestpackqty_dec";
            this.requestpackqty_dec.ReadOnly = true;
            this.requestpackqty_dec.Visible = false;
            // 
            // frmAskForMedDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 673);
            this.Controls.Add(this.m_lblRetailSubMoney);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.m_dgvDetail);
            this.Controls.Add(this.gradientPanel2);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAskForMedDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "药房请领";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAskForMedDetail_FormClosing);
            this.Load += new System.EventHandler(this.frmAskForMedDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvDetail)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gradientPanel2.ResumeLayout(false);
            this.gradientPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataStore1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton m_btnExit;
        internal com.digitalwave.iCare.gui.HIS.GradientPanel gradientPanel2;
        internal System.Windows.Forms.TextBox m_txtAsker;
        internal System.Windows.Forms.TextBox m_txtComment;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox m_txtAskBillNo;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label2;
        internal com.digitalwave.controls.MedicineStoreControls.ctlDataGridView_EnterAsTab m_dgvDetail;
        internal System.Windows.Forms.DateTimePicker m_datApplyDate;
        internal System.Windows.Forms.ToolStrip toolStrip1;
        internal System.Windows.Forms.ToolStripButton m_btnInsert;
        internal System.Windows.Forms.ToolStripButton m_btnDelete;
        internal System.Windows.Forms.ToolStripButton m_btnPrint;
        internal System.Windows.Forms.ToolStripButton m_btnNext;
        internal System.Windows.Forms.Label label6;
        internal exComboBox m_cboExportDept;
        internal exComboBox m_cboAskDept;
        internal System.Windows.Forms.Label m_lblRetailSubMoney;
        private System.Windows.Forms.Label label18;
        internal System.Windows.Forms.ToolStripButton m_btnSave;
        private Sybase.DataWindow.DataStore dataStore1;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtSerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn productorid_chr;
        private System.Windows.Forms.DataGridViewTextBoxColumn requestamount_int;
        private System.Windows.Forms.DataGridViewTextBoxColumn requestunit_chr;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtOutAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtOutUint;
        private System.Windows.Forms.DataGridViewTextBoxColumn AMOUNT_INT;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit_chr;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtInAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtInUint;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvPackDec;
        private System.Windows.Forms.DataGridViewTextBoxColumn medicineid_chr;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn RetailSum;
        private System.Windows.Forms.DataGridViewTextBoxColumn requestpackqty_dec;
    }
}