namespace com.digitalwave.iCare.gui.MedicineStore
{
    partial class frmRejectOutStorage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRejectOutStorage));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.m_cmdExit = new System.Windows.Forms.Button();
            this.m_dgvMedicineDetail = new com.digitalwave.controls.MedicineStoreControls.ctlDataGridView_EnterAsTab();
            this.m_dgvtxtSortNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedicineCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedicineName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedicineSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtLotNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtCurrentAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtRejectAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtRejectReason = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.m_dgvtxtInStorageID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtInStorageDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtVendorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtValidityPeriod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtBuyInPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtRejectBuyinMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtRetailPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtRejectRetailMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.medicineid_chr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_dtpInComeDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtIncomeBillNumber = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_cmdInsertRecord = new System.Windows.Forms.Button();
            this.m_cmdDelete = new System.Windows.Forms.Button();
            this.m_cmdNextBill = new System.Windows.Forms.Button();
            this.m_cmdSave = new System.Windows.Forms.Button();
            this.m_cmdPrint = new System.Windows.Forms.Button();
            this.m_bgwGetData = new System.ComponentModel.BackgroundWorker();
            this.m_lblBugMoney = new System.Windows.Forms.Label();
            this.m_lblSaleMoney = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvMedicineDetail)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.imageList1.Images.SetKeyName(9, "Shell32 055.ico");
            this.imageList1.Images.SetKeyName(10, "Shell32 147.ico");
            this.imageList1.Images.SetKeyName(11, "Shell32 133.ico");
            this.imageList1.Images.SetKeyName(12, "Shell32 088.ico");
            this.imageList1.Images.SetKeyName(13, "Shell32 023.ico");
            // 
            // m_cmdExit
            // 
            this.m_cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdExit.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_cmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdExit.ImageIndex = 1;
            this.m_cmdExit.ImageList = this.imageList1;
            this.m_cmdExit.Location = new System.Drawing.Point(887, 5);
            this.m_cmdExit.Name = "m_cmdExit";
            this.m_cmdExit.Size = new System.Drawing.Size(94, 28);
            this.m_cmdExit.TabIndex = 202;
            this.m_cmdExit.Text = "退出(&Q)";
            this.m_cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdExit.UseVisualStyleBackColor = true;
            this.m_cmdExit.Click += new System.EventHandler(this.m_cmdExit_Click);
            // 
            // m_dgvMedicineDetail
            // 
            this.m_dgvMedicineDetail.AllowUserToAddRows = false;
            this.m_dgvMedicineDetail.AllowUserToDeleteRows = false;
            this.m_dgvMedicineDetail.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dgvMedicineDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.m_dgvMedicineDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_dgvMedicineDetail.BackgroundColor = System.Drawing.SystemColors.Window;
            this.m_dgvMedicineDetail.ColumnHeadersHeight = 30;
            this.m_dgvMedicineDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_dgvtxtSortNum,
            this.m_dgvtxtMedicineCode,
            this.m_dgvtxtMedicineName,
            this.m_dgvtxtMedicineSpec,
            this.m_dgvtxtLotNO,
            this.m_dgvtxtCurrentAmount,
            this.m_dgvtxtRejectAmount,
            this.m_dgvtxtUnit,
            this.m_dgvtxtRejectReason,
            this.m_dgvtxtInStorageID,
            this.m_dgvtxtInStorageDate,
            this.m_dgvtxtVendorName,
            this.m_dgvtxtManufacturer,
            this.m_dgvtxtValidityPeriod,
            this.m_dgvtxtBuyInPrice,
            this.m_dgvtxtRejectBuyinMoney,
            this.m_dgvtxtRetailPrice,
            this.m_dgvtxtRejectRetailMoney,
            this.medicineid_chr});
            this.m_dgvMedicineDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.m_dgvMedicineDetail.Location = new System.Drawing.Point(0, 88);
            this.m_dgvMedicineDetail.Name = "m_dgvMedicineDetail";
            this.m_dgvMedicineDetail.RowHeadersVisible = false;
            this.m_dgvMedicineDetail.RowTemplate.Height = 23;
            this.m_dgvMedicineDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.m_dgvMedicineDetail.Size = new System.Drawing.Size(991, 553);
            this.m_dgvMedicineDetail.TabIndex = 1;
            this.m_dgvMedicineDetail.EnterKeyPress += new com.digitalwave.controls.MedicineStoreControls.EnterKeyPressInCurrentCell(this.m_dgvMedicineDetail_EnterKeyPress);
            this.m_dgvMedicineDetail.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.m_dgvMedicineDetail_RowsAdded);
            this.m_dgvMedicineDetail.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvMedicineDetail_CellEndEdit);
            this.m_dgvMedicineDetail.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.m_dgvMedicineDetail_DataError);
            this.m_dgvMedicineDetail.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.m_dgvMedicineDetail_EditingControlShowing);
            this.m_dgvMedicineDetail.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvMedicineDetail_CellEnter);
            this.m_dgvMedicineDetail.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.m_dgvMedicineDetail_RowsRemoved);
            // 
            // m_dgvtxtSortNum
            // 
            this.m_dgvtxtSortNum.DataPropertyName = "SortNum";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dgvtxtSortNum.DefaultCellStyle = dataGridViewCellStyle2;
            this.m_dgvtxtSortNum.Frozen = true;
            this.m_dgvtxtSortNum.HeaderText = "序号";
            this.m_dgvtxtSortNum.Name = "m_dgvtxtSortNum";
            this.m_dgvtxtSortNum.ReadOnly = true;
            this.m_dgvtxtSortNum.Width = 50;
            // 
            // m_dgvtxtMedicineCode
            // 
            this.m_dgvtxtMedicineCode.DataPropertyName = "assistcode_chr";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dgvtxtMedicineCode.DefaultCellStyle = dataGridViewCellStyle3;
            this.m_dgvtxtMedicineCode.HeaderText = "药品代码";
            this.m_dgvtxtMedicineCode.Name = "m_dgvtxtMedicineCode";
            this.m_dgvtxtMedicineCode.Width = 80;
            // 
            // m_dgvtxtMedicineName
            // 
            this.m_dgvtxtMedicineName.DataPropertyName = "MEDICINENAME_VCHr";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dgvtxtMedicineName.DefaultCellStyle = dataGridViewCellStyle4;
            this.m_dgvtxtMedicineName.HeaderText = "药品名称";
            this.m_dgvtxtMedicineName.Name = "m_dgvtxtMedicineName";
            this.m_dgvtxtMedicineName.ReadOnly = true;
            // 
            // m_dgvtxtMedicineSpec
            // 
            this.m_dgvtxtMedicineSpec.DataPropertyName = "MEDSPEC_VCHR";
            this.m_dgvtxtMedicineSpec.HeaderText = "规格";
            this.m_dgvtxtMedicineSpec.Name = "m_dgvtxtMedicineSpec";
            this.m_dgvtxtMedicineSpec.ReadOnly = true;
            // 
            // m_dgvtxtLotNO
            // 
            this.m_dgvtxtLotNO.DataPropertyName = "LOTNO_VCHR";
            this.m_dgvtxtLotNO.HeaderText = "批号";
            this.m_dgvtxtLotNO.Name = "m_dgvtxtLotNO";
            this.m_dgvtxtLotNO.ReadOnly = true;
            // 
            // m_dgvtxtCurrentAmount
            // 
            this.m_dgvtxtCurrentAmount.DataPropertyName = "availagross_int";
            this.m_dgvtxtCurrentAmount.HeaderText = "当前库存";
            this.m_dgvtxtCurrentAmount.Name = "m_dgvtxtCurrentAmount";
            this.m_dgvtxtCurrentAmount.ReadOnly = true;
            // 
            // m_dgvtxtRejectAmount
            // 
            this.m_dgvtxtRejectAmount.DataPropertyName = "NETAMOUNT_INT";
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.m_dgvtxtRejectAmount.DefaultCellStyle = dataGridViewCellStyle5;
            this.m_dgvtxtRejectAmount.HeaderText = "报废数量";
            this.m_dgvtxtRejectAmount.Name = "m_dgvtxtRejectAmount";
            // 
            // m_dgvtxtUnit
            // 
            this.m_dgvtxtUnit.DataPropertyName = "OPUNIT_CHR";
            this.m_dgvtxtUnit.HeaderText = "单位";
            this.m_dgvtxtUnit.Name = "m_dgvtxtUnit";
            this.m_dgvtxtUnit.ReadOnly = true;
            // 
            // m_dgvtxtRejectReason
            // 
            this.m_dgvtxtRejectReason.DataPropertyName = "REJECTREASON";
            this.m_dgvtxtRejectReason.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.m_dgvtxtRejectReason.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_dgvtxtRejectReason.HeaderText = "报废原因";
            this.m_dgvtxtRejectReason.MaxDropDownItems = 20;
            this.m_dgvtxtRejectReason.Name = "m_dgvtxtRejectReason";
            this.m_dgvtxtRejectReason.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgvtxtRejectReason.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.m_dgvtxtRejectReason.Width = 120;
            // 
            // m_dgvtxtInStorageID
            // 
            this.m_dgvtxtInStorageID.DataPropertyName = "INSTORAGEID_VCHR";
            this.m_dgvtxtInStorageID.HeaderText = "入库单号";
            this.m_dgvtxtInStorageID.Name = "m_dgvtxtInStorageID";
            this.m_dgvtxtInStorageID.ReadOnly = true;
            // 
            // m_dgvtxtInStorageDate
            // 
            this.m_dgvtxtInStorageDate.DataPropertyName = "instoragedate_dat";
            dataGridViewCellStyle6.Format = "d";
            dataGridViewCellStyle6.NullValue = null;
            this.m_dgvtxtInStorageDate.DefaultCellStyle = dataGridViewCellStyle6;
            this.m_dgvtxtInStorageDate.HeaderText = "入库日期";
            this.m_dgvtxtInStorageDate.Name = "m_dgvtxtInStorageDate";
            this.m_dgvtxtInStorageDate.ReadOnly = true;
            // 
            // m_dgvtxtVendorName
            // 
            this.m_dgvtxtVendorName.DataPropertyName = "vendorname_vchr";
            this.m_dgvtxtVendorName.HeaderText = "供应商名称";
            this.m_dgvtxtVendorName.Name = "m_dgvtxtVendorName";
            this.m_dgvtxtVendorName.ReadOnly = true;
            // 
            // m_dgvtxtManufacturer
            // 
            this.m_dgvtxtManufacturer.DataPropertyName = "productorid_chr";
            this.m_dgvtxtManufacturer.HeaderText = "生产厂家";
            this.m_dgvtxtManufacturer.Name = "m_dgvtxtManufacturer";
            this.m_dgvtxtManufacturer.ReadOnly = true;
            // 
            // m_dgvtxtValidityPeriod
            // 
            this.m_dgvtxtValidityPeriod.DataPropertyName = "validperiod_dat";
            dataGridViewCellStyle7.Format = "d";
            dataGridViewCellStyle7.NullValue = null;
            this.m_dgvtxtValidityPeriod.DefaultCellStyle = dataGridViewCellStyle7;
            this.m_dgvtxtValidityPeriod.HeaderText = "有效期";
            this.m_dgvtxtValidityPeriod.Name = "m_dgvtxtValidityPeriod";
            this.m_dgvtxtValidityPeriod.ReadOnly = true;
            // 
            // m_dgvtxtBuyInPrice
            // 
            this.m_dgvtxtBuyInPrice.DataPropertyName = "CALLPRICE_INT";
            dataGridViewCellStyle8.Format = "N4";
            dataGridViewCellStyle8.NullValue = null;
            this.m_dgvtxtBuyInPrice.DefaultCellStyle = dataGridViewCellStyle8;
            this.m_dgvtxtBuyInPrice.HeaderText = "购入价";
            this.m_dgvtxtBuyInPrice.Name = "m_dgvtxtBuyInPrice";
            this.m_dgvtxtBuyInPrice.ReadOnly = true;
            // 
            // m_dgvtxtRejectBuyinMoney
            // 
            this.m_dgvtxtRejectBuyinMoney.DataPropertyName = "inmoney";
            dataGridViewCellStyle9.Format = "N4";
            dataGridViewCellStyle9.NullValue = null;
            this.m_dgvtxtRejectBuyinMoney.DefaultCellStyle = dataGridViewCellStyle9;
            this.m_dgvtxtRejectBuyinMoney.HeaderText = "购入金额";
            this.m_dgvtxtRejectBuyinMoney.Name = "m_dgvtxtRejectBuyinMoney";
            this.m_dgvtxtRejectBuyinMoney.ReadOnly = true;
            // 
            // m_dgvtxtRetailPrice
            // 
            this.m_dgvtxtRetailPrice.DataPropertyName = "RETAILPRICE_INT";
            dataGridViewCellStyle10.Format = "N4";
            dataGridViewCellStyle10.NullValue = null;
            this.m_dgvtxtRetailPrice.DefaultCellStyle = dataGridViewCellStyle10;
            this.m_dgvtxtRetailPrice.HeaderText = "零售价";
            this.m_dgvtxtRetailPrice.Name = "m_dgvtxtRetailPrice";
            this.m_dgvtxtRetailPrice.ReadOnly = true;
            // 
            // m_dgvtxtRejectRetailMoney
            // 
            this.m_dgvtxtRejectRetailMoney.DataPropertyName = "retailmoney";
            dataGridViewCellStyle11.Format = "N4";
            dataGridViewCellStyle11.NullValue = null;
            this.m_dgvtxtRejectRetailMoney.DefaultCellStyle = dataGridViewCellStyle11;
            this.m_dgvtxtRejectRetailMoney.HeaderText = "零售金额";
            this.m_dgvtxtRejectRetailMoney.Name = "m_dgvtxtRejectRetailMoney";
            this.m_dgvtxtRejectRetailMoney.ReadOnly = true;
            // 
            // medicineid_chr
            // 
            this.medicineid_chr.DataPropertyName = "medicineid_chr";
            this.medicineid_chr.HeaderText = "药品ID";
            this.medicineid_chr.Name = "medicineid_chr";
            this.medicineid_chr.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.m_dtpInComeDate);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.m_txtIncomeBillNumber);
            this.panel2.Location = new System.Drawing.Point(2, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(989, 35);
            this.panel2.TabIndex = 5;
            this.panel2.Enter += new System.EventHandler(this.panel2_Enter);
            // 
            // m_dtpInComeDate
            // 
            this.m_dtpInComeDate.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_dtpInComeDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_dtpInComeDate.Location = new System.Drawing.Point(325, 5);
            this.m_dtpInComeDate.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日;
            this.m_dtpInComeDate.Mask = "0000年90月90日";
            this.m_dtpInComeDate.Name = "m_dtpInComeDate";
            this.m_dtpInComeDate.Size = new System.Drawing.Size(130, 23);
            this.m_dtpInComeDate.TabIndex = 15;
            this.m_dtpInComeDate.ValidatingType = typeof(System.DateTime);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(256, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 10004;
            this.label2.Text = "报废日期";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 10002;
            this.label1.Text = "报废单号";
            // 
            // m_txtIncomeBillNumber
            // 
            this.m_txtIncomeBillNumber.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtIncomeBillNumber.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtIncomeBillNumber.Location = new System.Drawing.Point(74, 5);
            this.m_txtIncomeBillNumber.Name = "m_txtIncomeBillNumber";
            this.m_txtIncomeBillNumber.ReadOnly = true;
            this.m_txtIncomeBillNumber.Size = new System.Drawing.Size(164, 23);
            this.m_txtIncomeBillNumber.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.m_cmdInsertRecord);
            this.panel1.Controls.Add(this.m_cmdDelete);
            this.panel1.Controls.Add(this.m_cmdNextBill);
            this.panel1.Controls.Add(this.m_cmdSave);
            this.panel1.Controls.Add(this.m_cmdPrint);
            this.panel1.Location = new System.Drawing.Point(1, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(492, 37);
            this.panel1.TabIndex = 171;
            // 
            // m_cmdInsertRecord
            // 
            this.m_cmdInsertRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdInsertRecord.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdInsertRecord.ImageIndex = 3;
            this.m_cmdInsertRecord.ImageList = this.imageList1;
            this.m_cmdInsertRecord.Location = new System.Drawing.Point(94, 3);
            this.m_cmdInsertRecord.Name = "m_cmdInsertRecord";
            this.m_cmdInsertRecord.Size = new System.Drawing.Size(94, 28);
            this.m_cmdInsertRecord.TabIndex = 205;
            this.m_cmdInsertRecord.Text = "插入(&I)";
            this.m_cmdInsertRecord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdInsertRecord.UseVisualStyleBackColor = true;
            this.m_cmdInsertRecord.Click += new System.EventHandler(this.m_cmdInsertRecord_Click);
            // 
            // m_cmdDelete
            // 
            this.m_cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdDelete.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdDelete.ImageIndex = 2;
            this.m_cmdDelete.ImageList = this.imageList1;
            this.m_cmdDelete.Location = new System.Drawing.Point(187, 3);
            this.m_cmdDelete.Name = "m_cmdDelete";
            this.m_cmdDelete.Size = new System.Drawing.Size(94, 28);
            this.m_cmdDelete.TabIndex = 185;
            this.m_cmdDelete.Text = "删除(&D)";
            this.m_cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdDelete.UseVisualStyleBackColor = true;
            this.m_cmdDelete.Click += new System.EventHandler(this.m_cmdDelete_Click);
            // 
            // m_cmdNextBill
            // 
            this.m_cmdNextBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdNextBill.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_cmdNextBill.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdNextBill.ImageIndex = 7;
            this.m_cmdNextBill.ImageList = this.imageList1;
            this.m_cmdNextBill.Location = new System.Drawing.Point(373, 3);
            this.m_cmdNextBill.Name = "m_cmdNextBill";
            this.m_cmdNextBill.Size = new System.Drawing.Size(112, 28);
            this.m_cmdNextBill.TabIndex = 195;
            this.m_cmdNextBill.Text = "下一张单(&N)";
            this.m_cmdNextBill.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdNextBill.UseVisualStyleBackColor = true;
            this.m_cmdNextBill.Click += new System.EventHandler(this.m_cmdNextBill_Click);
            // 
            // m_cmdSave
            // 
            this.m_cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdSave.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_cmdSave.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.m_cmdSave.ImageIndex = 0;
            this.m_cmdSave.ImageList = this.imageList1;
            this.m_cmdSave.Location = new System.Drawing.Point(1, 3);
            this.m_cmdSave.Name = "m_cmdSave";
            this.m_cmdSave.Size = new System.Drawing.Size(94, 28);
            this.m_cmdSave.TabIndex = 175;
            this.m_cmdSave.Text = "保存(&S)";
            this.m_cmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdSave.UseVisualStyleBackColor = true;
            this.m_cmdSave.Click += new System.EventHandler(this.m_cmdSave_Click);
            // 
            // m_cmdPrint
            // 
            this.m_cmdPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdPrint.ImageIndex = 6;
            this.m_cmdPrint.ImageList = this.imageList1;
            this.m_cmdPrint.Location = new System.Drawing.Point(280, 3);
            this.m_cmdPrint.Name = "m_cmdPrint";
            this.m_cmdPrint.Size = new System.Drawing.Size(94, 28);
            this.m_cmdPrint.TabIndex = 190;
            this.m_cmdPrint.Text = "打印(&P)";
            this.m_cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdPrint.UseVisualStyleBackColor = true;
            this.m_cmdPrint.Click += new System.EventHandler(this.m_cmdPrint_Click);
            // 
            // m_bgwGetData
            // 
            this.m_bgwGetData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.m_bgwGetData_DoWork);
            this.m_bgwGetData.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.m_bgwGetData_RunWorkerCompleted);
            // 
            // m_lblBugMoney
            // 
            this.m_lblBugMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblBugMoney.ForeColor = System.Drawing.Color.Red;
            this.m_lblBugMoney.Location = new System.Drawing.Point(647, 623);
            this.m_lblBugMoney.Name = "m_lblBugMoney";
            this.m_lblBugMoney.Size = new System.Drawing.Size(106, 14);
            this.m_lblBugMoney.TabIndex = 204;
            this.m_lblBugMoney.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblSaleMoney
            // 
            this.m_lblSaleMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblSaleMoney.ForeColor = System.Drawing.Color.Red;
            this.m_lblSaleMoney.Location = new System.Drawing.Point(843, 623);
            this.m_lblSaleMoney.Name = "m_lblSaleMoney";
            this.m_lblSaleMoney.Size = new System.Drawing.Size(111, 14);
            this.m_lblSaleMoney.TabIndex = 206;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(755, 622);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 16);
            this.label8.TabIndex = 205;
            this.label8.Text = "零售总金额￥";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(559, 622);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 16);
            this.label6.TabIndex = 203;
            this.label6.Text = "购入总金额￥";
            // 
            // frmRejectOutStorage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_cmdExit;
            this.ClientSize = new System.Drawing.Size(992, 646);
            this.Controls.Add(this.m_lblBugMoney);
            this.Controls.Add(this.m_lblSaleMoney);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.m_dgvMedicineDetail);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.m_cmdExit);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRejectOutStorage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "报废出库";
            this.Load += new System.EventHandler(this.frmRejectOutStorage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvMedicineDetail)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button m_cmdExit;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox m_txtIncomeBillNumber;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab m_dtpInComeDate;
        private System.Windows.Forms.Label label2;
        internal com.digitalwave.controls.MedicineStoreControls.ctlDataGridView_EnterAsTab m_dgvMedicineDetail;
        private System.Windows.Forms.ImageList imageList1;
        internal System.Windows.Forms.Button m_cmdInsertRecord;
        private System.ComponentModel.BackgroundWorker m_bgwGetData;
        internal System.Windows.Forms.Label m_lblBugMoney;
        internal System.Windows.Forms.Label m_lblSaleMoney;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Button m_cmdDelete;
        internal System.Windows.Forms.Button m_cmdNextBill;
        internal System.Windows.Forms.Button m_cmdSave;
        internal System.Windows.Forms.Button m_cmdPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtSortNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtLotNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtCurrentAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtRejectAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtUnit;
        private System.Windows.Forms.DataGridViewComboBoxColumn m_dgvtxtRejectReason;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtInStorageID;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtInStorageDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtVendorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtManufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtValidityPeriod;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtBuyInPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtRejectBuyinMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtRetailPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtRejectRetailMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn medicineid_chr;
        internal System.Windows.Forms.Panel panel2;
    }
}