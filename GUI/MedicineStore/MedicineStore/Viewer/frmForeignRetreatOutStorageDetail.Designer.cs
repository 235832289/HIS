namespace com.digitalwave.iCare.gui.MedicineStore
{
    partial class frmForeignRetreatOutStorageDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmForeignRetreatOutStorageDetail));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.m_cmdDelete = new System.Windows.Forms.Button();
            this.m_cmdInsertRecord = new System.Windows.Forms.Button();
            this.m_cmdExit = new System.Windows.Forms.Button();
            this.m_cmdNext = new System.Windows.Forms.Button();
            this.m_cmdPrint = new System.Windows.Forms.Button();
            this.m_cmdSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtVendor = new System.Windows.Forms.TextBox();
            this.m_txtRemark = new System.Windows.Forms.TextBox();
            this.m_dtpDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab(this.components);
            this.m_txtOutputOrder = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_cmdGetInStorage = new System.Windows.Forms.Button();
            this.m_dgvMedicineOutInfo = new com.digitalwave.controls.MedicineStoreControls.ctlDataGridView_EnterAsTab();
            this.m_dgvtxtSortNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedicineCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedicintName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedicineSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtLotNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtOutAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtCurrentGross = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtRetailPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtBuyInPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtRetailMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtBuyInMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtInStorageID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtInStorageDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.medicineid_chr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label31 = new System.Windows.Forms.Label();
            this.m_lblSaleMoney = new System.Windows.Forms.Label();
            this.m_lblBugMoney = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.m_bgwGetData = new System.ComponentModel.BackgroundWorker();
            this.label9 = new System.Windows.Forms.Label();
            this.m_lblly = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvMedicineOutInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Shell32 007.ico");
            this.imageList1.Images.SetKeyName(1, "Shell32 028.ico");
            this.imageList1.Images.SetKeyName(2, "Shell32 132.ico");
            this.imageList1.Images.SetKeyName(3, "Shell32 148.ico");
            this.imageList1.Images.SetKeyName(4, "Shell32 058.ico");
            this.imageList1.Images.SetKeyName(5, "m_cmdRefresh.Image.png");
            this.imageList1.Images.SetKeyName(6, "Shell32 137.ico");
            this.imageList1.Images.SetKeyName(7, "Shell32 177.ico");
            this.imageList1.Images.SetKeyName(8, "Shell32 136.ico");
            // 
            // m_cmdDelete
            // 
            this.m_cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdDelete.ImageIndex = 2;
            this.m_cmdDelete.ImageList = this.imageList1;
            this.m_cmdDelete.Location = new System.Drawing.Point(192, 7);
            this.m_cmdDelete.Name = "m_cmdDelete";
            this.m_cmdDelete.Size = new System.Drawing.Size(94, 28);
            this.m_cmdDelete.TabIndex = 38;
            this.m_cmdDelete.Text = "删除(&D)";
            this.m_cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdDelete.UseVisualStyleBackColor = true;
            this.m_cmdDelete.Click += new System.EventHandler(this.m_cmdDelete_Click);
            // 
            // m_cmdInsertRecord
            // 
            this.m_cmdInsertRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdInsertRecord.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdInsertRecord.ImageIndex = 3;
            this.m_cmdInsertRecord.ImageList = this.imageList1;
            this.m_cmdInsertRecord.Location = new System.Drawing.Point(99, 7);
            this.m_cmdInsertRecord.Name = "m_cmdInsertRecord";
            this.m_cmdInsertRecord.Size = new System.Drawing.Size(94, 28);
            this.m_cmdInsertRecord.TabIndex = 37;
            this.m_cmdInsertRecord.Text = "插入(&I)";
            this.m_cmdInsertRecord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdInsertRecord.UseVisualStyleBackColor = true;
            this.m_cmdInsertRecord.Click += new System.EventHandler(this.m_cmdInsertRecord_Click);
            // 
            // m_cmdExit
            // 
            this.m_cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdExit.ImageIndex = 1;
            this.m_cmdExit.ImageList = this.imageList1;
            this.m_cmdExit.Location = new System.Drawing.Point(868, 7);
            this.m_cmdExit.Name = "m_cmdExit";
            this.m_cmdExit.Size = new System.Drawing.Size(93, 28);
            this.m_cmdExit.TabIndex = 41;
            this.m_cmdExit.Text = "退出(&Q)";
            this.m_cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdExit.UseVisualStyleBackColor = true;
            this.m_cmdExit.Click += new System.EventHandler(this.m_cmdExit_Click);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdNext.ImageIndex = 7;
            this.m_cmdNext.ImageList = this.imageList1;
            this.m_cmdNext.Location = new System.Drawing.Point(373, 7);
            this.m_cmdNext.Name = "m_cmdNext";
            this.m_cmdNext.Size = new System.Drawing.Size(113, 28);
            this.m_cmdNext.TabIndex = 40;
            this.m_cmdNext.Text = "下一张单(&N)";
            this.m_cmdNext.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdNext.UseVisualStyleBackColor = true;
            this.m_cmdNext.Click += new System.EventHandler(this.m_cmdNext_Click);
            // 
            // m_cmdPrint
            // 
            this.m_cmdPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdPrint.ImageIndex = 6;
            this.m_cmdPrint.ImageList = this.imageList1;
            this.m_cmdPrint.Location = new System.Drawing.Point(285, 7);
            this.m_cmdPrint.Name = "m_cmdPrint";
            this.m_cmdPrint.Size = new System.Drawing.Size(89, 28);
            this.m_cmdPrint.TabIndex = 39;
            this.m_cmdPrint.Text = "打印(&P)";
            this.m_cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdPrint.UseVisualStyleBackColor = true;
            this.m_cmdPrint.Click += new System.EventHandler(this.m_cmdPrint_Click);
            // 
            // m_cmdSave
            // 
            this.m_cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdSave.ImageIndex = 0;
            this.m_cmdSave.ImageList = this.imageList1;
            this.m_cmdSave.Location = new System.Drawing.Point(6, 7);
            this.m_cmdSave.Name = "m_cmdSave";
            this.m_cmdSave.Size = new System.Drawing.Size(94, 28);
            this.m_cmdSave.TabIndex = 36;
            this.m_cmdSave.Text = "保存(&S)";
            this.m_cmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdSave.UseVisualStyleBackColor = true;
            this.m_cmdSave.Click += new System.EventHandler(this.m_cmdSave_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.m_txtVendor);
            this.panel1.Controls.Add(this.m_txtRemark);
            this.panel1.Controls.Add(this.m_dtpDate);
            this.panel1.Controls.Add(this.m_txtOutputOrder);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(2, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(969, 39);
            this.panel1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(397, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 5009;
            this.label1.Text = "供应商";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 25);
            this.label2.TabIndex = 5001;
            this.label2.Text = "出库单号";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtVendor
            // 
            this.m_txtVendor.Location = new System.Drawing.Point(449, 7);
            this.m_txtVendor.Name = "m_txtVendor";
            this.m_txtVendor.Size = new System.Drawing.Size(211, 23);
            this.m_txtVendor.TabIndex = 10;
            this.m_txtVendor.TextChanged += new System.EventHandler(this.m_txtVendor_TextChanged);
            this.m_txtVendor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtVendor_KeyDown);
            // 
            // m_txtRemark
            // 
            this.m_txtRemark.Location = new System.Drawing.Point(706, 6);
            this.m_txtRemark.Name = "m_txtRemark";
            this.m_txtRemark.Size = new System.Drawing.Size(247, 23);
            this.m_txtRemark.TabIndex = 15;
            this.m_txtRemark.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtRemark_KeyDown);
            // 
            // m_dtpDate
            // 
            this.m_dtpDate.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_dtpDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_dtpDate.Location = new System.Drawing.Point(252, 6);
            this.m_dtpDate.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日;
            this.m_dtpDate.Mask = "0000年90月90日";
            this.m_dtpDate.Name = "m_dtpDate";
            this.m_dtpDate.Size = new System.Drawing.Size(130, 23);
            this.m_dtpDate.TabIndex = 20;
            this.m_dtpDate.ValidatingType = typeof(System.DateTime);
            // 
            // m_txtOutputOrder
            // 
            this.m_txtOutputOrder.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtOutputOrder.Location = new System.Drawing.Point(75, 6);
            this.m_txtOutputOrder.Name = "m_txtOutputOrder";
            this.m_txtOutputOrder.ReadOnly = true;
            this.m_txtOutputOrder.Size = new System.Drawing.Size(98, 23);
            this.m_txtOutputOrder.TabIndex = 5008;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(669, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 14);
            this.label5.TabIndex = 5004;
            this.label5.Text = "备注";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(184, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 5002;
            this.label3.Text = "办理日期";
            // 
            // m_cmdGetInStorage
            // 
            this.m_cmdGetInStorage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdGetInStorage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdGetInStorage.ImageIndex = 8;
            this.m_cmdGetInStorage.ImageList = this.imageList1;
            this.m_cmdGetInStorage.Location = new System.Drawing.Point(485, 7);
            this.m_cmdGetInStorage.Name = "m_cmdGetInStorage";
            this.m_cmdGetInStorage.Size = new System.Drawing.Size(113, 28);
            this.m_cmdGetInStorage.TabIndex = 41;
            this.m_cmdGetInStorage.Text = "调入库单(&G)";
            this.m_cmdGetInStorage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdGetInStorage.UseVisualStyleBackColor = true;
            this.m_cmdGetInStorage.Click += new System.EventHandler(this.m_cmdGetInStorage_Click);
            // 
            // m_dgvMedicineOutInfo
            // 
            this.m_dgvMedicineOutInfo.AllowUserToAddRows = false;
            this.m_dgvMedicineOutInfo.AllowUserToDeleteRows = false;
            this.m_dgvMedicineOutInfo.AllowUserToResizeRows = false;
            this.m_dgvMedicineOutInfo.ColumnHeadersHeight = 30;
            this.m_dgvMedicineOutInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_dgvtxtSortNum,
            this.m_dgvtxtMedicineCode,
            this.m_dgvtxtMedicintName,
            this.m_dgvtxtMedicineSpec,
            this.m_dgvtxtLotNO,
            this.m_dgvtxtOutAmount,
            this.m_dgvtxtUnit,
            this.m_dgvtxtCurrentGross,
            this.m_dgvtxtRetailPrice,
            this.m_dgvtxtBuyInPrice,
            this.m_dgvtxtRetailMoney,
            this.m_dgvtxtBuyInMoney,
            this.m_dgvtxtInStorageID,
            this.m_dgvtxtInStorageDate,
            this.medicineid_chr});
            this.m_dgvMedicineOutInfo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.m_dgvMedicineOutInfo.Location = new System.Drawing.Point(2, 85);
            this.m_dgvMedicineOutInfo.Name = "m_dgvMedicineOutInfo";
            this.m_dgvMedicineOutInfo.RowHeadersVisible = false;
            this.m_dgvMedicineOutInfo.RowTemplate.Height = 23;
            this.m_dgvMedicineOutInfo.Size = new System.Drawing.Size(969, 562);
            this.m_dgvMedicineOutInfo.TabIndex = 20;
            this.m_dgvMedicineOutInfo.EnterKeyPress += new com.digitalwave.controls.MedicineStoreControls.EnterKeyPressInCurrentCell(this.m_dgvOutMedicine_EnterKeyPress);
            this.m_dgvMedicineOutInfo.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.m_dgvOutMedicine_RowsAdded);
            this.m_dgvMedicineOutInfo.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvMedicineOutInfo_CellEndEdit);
            this.m_dgvMedicineOutInfo.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvMedicineOutInfo_CellEnter);
            this.m_dgvMedicineOutInfo.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.m_dgvOutMedicine_RowsRemoved);
            // 
            // m_dgvtxtSortNum
            // 
            this.m_dgvtxtSortNum.HeaderText = "序号";
            this.m_dgvtxtSortNum.Name = "m_dgvtxtSortNum";
            this.m_dgvtxtSortNum.ReadOnly = true;
            this.m_dgvtxtSortNum.Width = 50;
            // 
            // m_dgvtxtMedicineCode
            // 
            this.m_dgvtxtMedicineCode.DataPropertyName = "assistcode_chr";
            this.m_dgvtxtMedicineCode.HeaderText = "药品代码";
            this.m_dgvtxtMedicineCode.Name = "m_dgvtxtMedicineCode";
            this.m_dgvtxtMedicineCode.Width = 80;
            // 
            // m_dgvtxtMedicintName
            // 
            this.m_dgvtxtMedicintName.DataPropertyName = "medicinename_vchr";
            this.m_dgvtxtMedicintName.HeaderText = "药品名称";
            this.m_dgvtxtMedicintName.Name = "m_dgvtxtMedicintName";
            this.m_dgvtxtMedicintName.ReadOnly = true;
            // 
            // m_dgvtxtMedicineSpec
            // 
            this.m_dgvtxtMedicineSpec.DataPropertyName = "medspec_vchr";
            this.m_dgvtxtMedicineSpec.HeaderText = "规格";
            this.m_dgvtxtMedicineSpec.Name = "m_dgvtxtMedicineSpec";
            this.m_dgvtxtMedicineSpec.ReadOnly = true;
            this.m_dgvtxtMedicineSpec.Width = 80;
            // 
            // m_dgvtxtLotNO
            // 
            this.m_dgvtxtLotNO.DataPropertyName = "lotno_vchr";
            this.m_dgvtxtLotNO.HeaderText = "批号";
            this.m_dgvtxtLotNO.Name = "m_dgvtxtLotNO";
            this.m_dgvtxtLotNO.ReadOnly = true;
            // 
            // m_dgvtxtOutAmount
            // 
            this.m_dgvtxtOutAmount.DataPropertyName = "netamount_int";
            dataGridViewCellStyle29.Format = "N2";
            dataGridViewCellStyle29.NullValue = null;
            this.m_dgvtxtOutAmount.DefaultCellStyle = dataGridViewCellStyle29;
            this.m_dgvtxtOutAmount.HeaderText = "退货数量";
            this.m_dgvtxtOutAmount.Name = "m_dgvtxtOutAmount";
            // 
            // m_dgvtxtUnit
            // 
            this.m_dgvtxtUnit.DataPropertyName = "opunit_chr";
            this.m_dgvtxtUnit.HeaderText = "单位";
            this.m_dgvtxtUnit.Name = "m_dgvtxtUnit";
            this.m_dgvtxtUnit.ReadOnly = true;
            this.m_dgvtxtUnit.Width = 60;
            // 
            // m_dgvtxtCurrentGross
            // 
            this.m_dgvtxtCurrentGross.DataPropertyName = "availagross_int";
            dataGridViewCellStyle30.Format = "N2";
            dataGridViewCellStyle30.NullValue = null;
            this.m_dgvtxtCurrentGross.DefaultCellStyle = dataGridViewCellStyle30;
            this.m_dgvtxtCurrentGross.HeaderText = "当前库存";
            this.m_dgvtxtCurrentGross.Name = "m_dgvtxtCurrentGross";
            this.m_dgvtxtCurrentGross.ReadOnly = true;
            // 
            // m_dgvtxtRetailPrice
            // 
            this.m_dgvtxtRetailPrice.DataPropertyName = "retailprice_int";
            dataGridViewCellStyle31.Format = "N4";
            dataGridViewCellStyle31.NullValue = null;
            this.m_dgvtxtRetailPrice.DefaultCellStyle = dataGridViewCellStyle31;
            this.m_dgvtxtRetailPrice.HeaderText = "零售单价";
            this.m_dgvtxtRetailPrice.Name = "m_dgvtxtRetailPrice";
            this.m_dgvtxtRetailPrice.ReadOnly = true;
            // 
            // m_dgvtxtBuyInPrice
            // 
            this.m_dgvtxtBuyInPrice.DataPropertyName = "callprice_int";
            dataGridViewCellStyle32.Format = "N4";
            dataGridViewCellStyle32.NullValue = null;
            this.m_dgvtxtBuyInPrice.DefaultCellStyle = dataGridViewCellStyle32;
            this.m_dgvtxtBuyInPrice.HeaderText = "购入单价";
            this.m_dgvtxtBuyInPrice.Name = "m_dgvtxtBuyInPrice";
            this.m_dgvtxtBuyInPrice.ReadOnly = true;
            // 
            // m_dgvtxtRetailMoney
            // 
            this.m_dgvtxtRetailMoney.DataPropertyName = "retailmoney";
            dataGridViewCellStyle33.Format = "N4";
            dataGridViewCellStyle33.NullValue = null;
            this.m_dgvtxtRetailMoney.DefaultCellStyle = dataGridViewCellStyle33;
            this.m_dgvtxtRetailMoney.HeaderText = "零售金额";
            this.m_dgvtxtRetailMoney.Name = "m_dgvtxtRetailMoney";
            this.m_dgvtxtRetailMoney.ReadOnly = true;
            // 
            // m_dgvtxtBuyInMoney
            // 
            this.m_dgvtxtBuyInMoney.DataPropertyName = "inmoney";
            dataGridViewCellStyle34.Format = "N4";
            dataGridViewCellStyle34.NullValue = null;
            this.m_dgvtxtBuyInMoney.DefaultCellStyle = dataGridViewCellStyle34;
            this.m_dgvtxtBuyInMoney.HeaderText = "购入金额";
            this.m_dgvtxtBuyInMoney.Name = "m_dgvtxtBuyInMoney";
            this.m_dgvtxtBuyInMoney.ReadOnly = true;
            // 
            // m_dgvtxtInStorageID
            // 
            this.m_dgvtxtInStorageID.DataPropertyName = "instorageid_vchr";
            this.m_dgvtxtInStorageID.HeaderText = "入库单号";
            this.m_dgvtxtInStorageID.Name = "m_dgvtxtInStorageID";
            this.m_dgvtxtInStorageID.ReadOnly = true;
            // 
            // m_dgvtxtInStorageDate
            // 
            this.m_dgvtxtInStorageDate.DataPropertyName = "instoragedate_dat";
            dataGridViewCellStyle35.Format = "d";
            dataGridViewCellStyle35.NullValue = null;
            this.m_dgvtxtInStorageDate.DefaultCellStyle = dataGridViewCellStyle35;
            this.m_dgvtxtInStorageDate.HeaderText = "入库日期";
            this.m_dgvtxtInStorageDate.Name = "m_dgvtxtInStorageDate";
            this.m_dgvtxtInStorageDate.ReadOnly = true;
            // 
            // medicineid_chr
            // 
            this.medicineid_chr.DataPropertyName = "medicineid_chr";
            this.medicineid_chr.HeaderText = "药品ID";
            this.medicineid_chr.Name = "medicineid_chr";
            this.medicineid_chr.Visible = false;
            // 
            // label31
            // 
            this.label31.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label31.ForeColor = System.Drawing.Color.Red;
            this.label31.Location = new System.Drawing.Point(520, 630);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(98, 14);
            this.label31.TabIndex = 174;
            this.label31.Text = "零售总金额￥";
            // 
            // m_lblSaleMoney
            // 
            this.m_lblSaleMoney.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lblSaleMoney.ForeColor = System.Drawing.Color.Red;
            this.m_lblSaleMoney.Location = new System.Drawing.Point(620, 630);
            this.m_lblSaleMoney.Name = "m_lblSaleMoney";
            this.m_lblSaleMoney.Size = new System.Drawing.Size(100, 14);
            this.m_lblSaleMoney.TabIndex = 175;
            this.m_lblSaleMoney.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // m_lblBugMoney
            // 
            this.m_lblBugMoney.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lblBugMoney.ForeColor = System.Drawing.Color.Red;
            this.m_lblBugMoney.Location = new System.Drawing.Point(417, 630);
            this.m_lblBugMoney.Name = "m_lblBugMoney";
            this.m_lblBugMoney.Size = new System.Drawing.Size(100, 14);
            this.m_lblBugMoney.TabIndex = 176;
            this.m_lblBugMoney.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label30
            // 
            this.label30.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label30.ForeColor = System.Drawing.Color.Red;
            this.label30.Location = new System.Drawing.Point(321, 630);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(94, 14);
            this.label30.TabIndex = 173;
            this.label30.Text = "购入总金额￥";
            // 
            // m_bgwGetData
            // 
            this.m_bgwGetData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.m_bgwGetData_DoWork);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(720, 630);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 14);
            this.label9.TabIndex = 10007;
            this.label9.Text = "盈亏差额￥";
            // 
            // m_lblly
            // 
            this.m_lblly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblly.BackColor = System.Drawing.SystemColors.Control;
            this.m_lblly.ForeColor = System.Drawing.Color.Red;
            this.m_lblly.Location = new System.Drawing.Point(798, 630);
            this.m_lblly.Name = "m_lblly";
            this.m_lblly.Size = new System.Drawing.Size(131, 14);
            this.m_lblly.TabIndex = 10008;
            // 
            // frmForeignRetreatOutStorageDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 648);
            this.Controls.Add(this.m_lblly);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.m_lblSaleMoney);
            this.Controls.Add(this.m_lblBugMoney);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.m_dgvMedicineOutInfo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_cmdDelete);
            this.Controls.Add(this.m_cmdInsertRecord);
            this.Controls.Add(this.m_cmdExit);
            this.Controls.Add(this.m_cmdNext);
            this.Controls.Add(this.m_cmdGetInStorage);
            this.Controls.Add(this.m_cmdPrint);
            this.Controls.Add(this.m_cmdSave);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmForeignRetreatOutStorageDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "药品外退";
            this.Load += new System.EventHandler(this.frmForeignRetreatOutStorageDetail_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvMedicineOutInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        internal System.Windows.Forms.Button m_cmdDelete;
        internal System.Windows.Forms.Button m_cmdInsertRecord;
        private System.Windows.Forms.Button m_cmdExit;
        internal System.Windows.Forms.Button m_cmdNext;
        internal System.Windows.Forms.Button m_cmdPrint;
        internal System.Windows.Forms.Button m_cmdSave;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox m_txtRemark;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab m_dtpDate;
        internal System.Windows.Forms.TextBox m_txtOutputOrder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Button m_cmdGetInStorage;
        internal com.digitalwave.controls.MedicineStoreControls.ctlDataGridView_EnterAsTab m_dgvMedicineOutInfo;
        private System.Windows.Forms.Label label31;
        internal System.Windows.Forms.Label m_lblSaleMoney;
        internal System.Windows.Forms.Label m_lblBugMoney;
        private System.Windows.Forms.Label label30;
        private System.ComponentModel.BackgroundWorker m_bgwGetData;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox m_txtVendor;
        internal System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtSortNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicintName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtLotNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtOutAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtCurrentGross;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtRetailPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtBuyInPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtRetailMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtBuyInMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtInStorageID;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtInStorageDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn medicineid_chr;
        private System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label m_lblly;
    }
}