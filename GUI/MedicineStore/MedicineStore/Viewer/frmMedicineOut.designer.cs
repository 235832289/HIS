namespace com.digitalwave.iCare.gui.MedicineStore
{
    partial class frmMedicineOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMedicineOut));
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
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.m_bgwGetData = new System.ComponentModel.BackgroundWorker();
            this.m_lblBugMoney = new System.Windows.Forms.Label();
            this.m_lblSaleMoney = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_dgvMedicineOutInfo = new com.digitalwave.controls.MedicineStoreControls.ctlDataGridView_EnterAsTab();
            this.m_dgvtxtSerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedicineCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedicineName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedicineSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtProduceNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtOutAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtOutUint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtSalePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtBuyPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WHOLESALEPRICE_INT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtRealNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtCanUseNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtSaleMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtBuyMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WHOLESALEPRICE_SUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtOrderCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtInData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtProduceFactory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCEDATE_DAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtEffectData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtStorageUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtAllRealGross = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtAllAvaGross = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.medicineid_chr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oldgross_int = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_txtIPUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_txtPackQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_txtReceiptor = new System.Windows.Forms.TextBox();
            this.m_lblReceiptor = new System.Windows.Forms.Label();
            this.m_txtReceiveDept = new com.digitalwave.Controls.Domain.EmrControls.ctlDeptSelected_EnterKeyActive();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtRemark = new System.Windows.Forms.TextBox();
            this.m_dtpDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab(this.components);
            this.m_txtMan = new System.Windows.Forms.TextBox();
            this.m_txtOutputOrder = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cmdDelete = new System.Windows.Forms.Button();
            this.m_cmdInsertRecord = new System.Windows.Forms.Button();
            this.m_cmdExit = new System.Windows.Forms.Button();
            this.m_cmdNext = new System.Windows.Forms.Button();
            this.m_cmdPrint = new System.Windows.Forms.Button();
            this.m_cmdSave = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.m_lblDiffMoney = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvMedicineOutInfo)).BeginInit();
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
            // m_bgwGetData
            // 
            this.m_bgwGetData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.m_bgwGetData_DoWork);
            this.m_bgwGetData.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.m_bgwGetData_RunWorkerCompleted);
            // 
            // m_lblBugMoney
            // 
            this.m_lblBugMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblBugMoney.ForeColor = System.Drawing.Color.Red;
            this.m_lblBugMoney.Location = new System.Drawing.Point(437, 626);
            this.m_lblBugMoney.Name = "m_lblBugMoney";
            this.m_lblBugMoney.Size = new System.Drawing.Size(106, 14);
            this.m_lblBugMoney.TabIndex = 17;
            this.m_lblBugMoney.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblSaleMoney
            // 
            this.m_lblSaleMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblSaleMoney.ForeColor = System.Drawing.Color.Red;
            this.m_lblSaleMoney.Location = new System.Drawing.Point(634, 626);
            this.m_lblSaleMoney.Name = "m_lblSaleMoney";
            this.m_lblSaleMoney.Size = new System.Drawing.Size(111, 14);
            this.m_lblSaleMoney.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(543, 625);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 16);
            this.label8.TabIndex = 18;
            this.label8.Text = "零售总金额￥";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(346, 625);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 16);
            this.label6.TabIndex = 16;
            this.label6.Text = "购入总金额￥";
            // 
            // m_dgvMedicineOutInfo
            // 
            this.m_dgvMedicineOutInfo.AllowUserToAddRows = false;
            this.m_dgvMedicineOutInfo.AllowUserToDeleteRows = false;
            this.m_dgvMedicineOutInfo.AllowUserToResizeRows = false;
            this.m_dgvMedicineOutInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_dgvMedicineOutInfo.BackgroundColor = System.Drawing.SystemColors.Window;
            this.m_dgvMedicineOutInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_dgvMedicineOutInfo.ColumnHeadersHeight = 30;
            this.m_dgvMedicineOutInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgvMedicineOutInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_dgvtxtSerialNumber,
            this.m_dgvtxtMedicineCode,
            this.m_dgvtxtMedicineName,
            this.m_dgvtxtMedicineSpec,
            this.m_dgvtxtProduceNumber,
            this.m_dgvtxtOutAmount,
            this.m_dgvtxtOutUint,
            this.m_dgvtxtSalePrice,
            this.m_dgvtxtBuyPrice,
            this.WHOLESALEPRICE_INT,
            this.m_dgvtxtRealNumber,
            this.m_dgvtxtCanUseNumber,
            this.m_dgvtxtSaleMoney,
            this.m_dgvtxtBuyMoney,
            this.WHOLESALEPRICE_SUM,
            this.m_dgvtxtOrderCode,
            this.m_dgvtxtInData,
            this.m_dgvtxtProduceFactory,
            this.PRODUCEDATE_DAT,
            this.m_dgvtxtEffectData,
            this.m_dgvtxtStorageUnit,
            this.m_dgvtxtAllRealGross,
            this.m_dgvtxtAllAvaGross,
            this.medicineid_chr,
            this.oldgross_int,
            this.m_txtIPUnit,
            this.m_txtPackQty});
            this.m_dgvMedicineOutInfo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.m_dgvMedicineOutInfo.Location = new System.Drawing.Point(1, 113);
            this.m_dgvMedicineOutInfo.Name = "m_dgvMedicineOutInfo";
            this.m_dgvMedicineOutInfo.RowHeadersVisible = false;
            this.m_dgvMedicineOutInfo.RowTemplate.Height = 23;
            this.m_dgvMedicineOutInfo.Size = new System.Drawing.Size(971, 528);
            this.m_dgvMedicineOutInfo.TabIndex = 6;
            this.m_dgvMedicineOutInfo.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvMedicineOutInfo_CellLeave);
            this.m_dgvMedicineOutInfo.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.m_dgvMedicineOutInfo_ColumnHeaderMouseClick);
            this.m_dgvMedicineOutInfo.EnterKeyPress += new com.digitalwave.controls.MedicineStoreControls.EnterKeyPressInCurrentCell(this.m_dgvMedicineOutInfo_EnterKeyPress);
            this.m_dgvMedicineOutInfo.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.m_dgvMedicineOutInfo_RowPrePaint);
            this.m_dgvMedicineOutInfo.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.m_dgvMedicineOutInfo_RowsAdded);
            this.m_dgvMedicineOutInfo.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvMedicineOutInfo_CellEndEdit);
            this.m_dgvMedicineOutInfo.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvMedicineOutInfo_CellValueChanged);
            this.m_dgvMedicineOutInfo.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.m_dgvMedicineOutInfo_DataError);
            this.m_dgvMedicineOutInfo.ArriveLastColoumn += new com.digitalwave.controls.MedicineStoreControls.ArriveDataGridViewLastColoumn(this.m_dgvMedicineOutInfo_ArriveLastColoumn);
            this.m_dgvMedicineOutInfo.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvMedicineOutInfo_CellEnter);
            this.m_dgvMedicineOutInfo.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.m_dgvMedicineOutInfo_RowsRemoved);
            this.m_dgvMedicineOutInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvMedicineOutInfo_CellContentClick);
            // 
            // m_dgvtxtSerialNumber
            // 
            this.m_dgvtxtSerialNumber.Frozen = true;
            this.m_dgvtxtSerialNumber.HeaderText = "序号";
            this.m_dgvtxtSerialNumber.Name = "m_dgvtxtSerialNumber";
            this.m_dgvtxtSerialNumber.ReadOnly = true;
            this.m_dgvtxtSerialNumber.Width = 50;
            // 
            // m_dgvtxtMedicineCode
            // 
            this.m_dgvtxtMedicineCode.DataPropertyName = "assistcode_chr";
            this.m_dgvtxtMedicineCode.HeaderText = "药品代码";
            this.m_dgvtxtMedicineCode.Name = "m_dgvtxtMedicineCode";
            this.m_dgvtxtMedicineCode.Width = 80;
            // 
            // m_dgvtxtMedicineName
            // 
            this.m_dgvtxtMedicineName.DataPropertyName = "MEDICINENAME_VCHr";
            this.m_dgvtxtMedicineName.HeaderText = "药品名称";
            this.m_dgvtxtMedicineName.Name = "m_dgvtxtMedicineName";
            this.m_dgvtxtMedicineName.ReadOnly = true;
            this.m_dgvtxtMedicineName.Width = 130;
            // 
            // m_dgvtxtMedicineSpec
            // 
            this.m_dgvtxtMedicineSpec.DataPropertyName = "MEDSPEC_VCHR";
            this.m_dgvtxtMedicineSpec.HeaderText = "规格";
            this.m_dgvtxtMedicineSpec.Name = "m_dgvtxtMedicineSpec";
            this.m_dgvtxtMedicineSpec.ReadOnly = true;
            // 
            // m_dgvtxtProduceNumber
            // 
            this.m_dgvtxtProduceNumber.DataPropertyName = "LOTNO_VCHR";
            this.m_dgvtxtProduceNumber.HeaderText = "生产批号";
            this.m_dgvtxtProduceNumber.Name = "m_dgvtxtProduceNumber";
            this.m_dgvtxtProduceNumber.ReadOnly = true;
            // 
            // m_dgvtxtOutAmount
            // 
            this.m_dgvtxtOutAmount.DataPropertyName = "NETAMOUNT_INT";
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.m_dgvtxtOutAmount.DefaultCellStyle = dataGridViewCellStyle1;
            this.m_dgvtxtOutAmount.HeaderText = "出库数量";
            this.m_dgvtxtOutAmount.Name = "m_dgvtxtOutAmount";
            this.m_dgvtxtOutAmount.Width = 80;
            // 
            // m_dgvtxtOutUint
            // 
            this.m_dgvtxtOutUint.DataPropertyName = "OPUNIT_CHR";
            this.m_dgvtxtOutUint.HeaderText = "单位";
            this.m_dgvtxtOutUint.Name = "m_dgvtxtOutUint";
            this.m_dgvtxtOutUint.ReadOnly = true;
            this.m_dgvtxtOutUint.Width = 60;
            // 
            // m_dgvtxtSalePrice
            // 
            this.m_dgvtxtSalePrice.DataPropertyName = "RETAILPRICE_INT";
            dataGridViewCellStyle2.Format = "N4";
            dataGridViewCellStyle2.NullValue = null;
            this.m_dgvtxtSalePrice.DefaultCellStyle = dataGridViewCellStyle2;
            this.m_dgvtxtSalePrice.HeaderText = "零售单价";
            this.m_dgvtxtSalePrice.Name = "m_dgvtxtSalePrice";
            this.m_dgvtxtSalePrice.ReadOnly = true;
            // 
            // m_dgvtxtBuyPrice
            // 
            this.m_dgvtxtBuyPrice.DataPropertyName = "CALLPRICE_INT";
            dataGridViewCellStyle3.Format = "N4";
            dataGridViewCellStyle3.NullValue = null;
            this.m_dgvtxtBuyPrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.m_dgvtxtBuyPrice.HeaderText = "购入单价";
            this.m_dgvtxtBuyPrice.Name = "m_dgvtxtBuyPrice";
            this.m_dgvtxtBuyPrice.ReadOnly = true;
            // 
            // WHOLESALEPRICE_INT
            // 
            this.WHOLESALEPRICE_INT.DataPropertyName = "WHOLESALEPRICE_INT";
            this.WHOLESALEPRICE_INT.HeaderText = "批发单价";
            this.WHOLESALEPRICE_INT.Name = "WHOLESALEPRICE_INT";
            this.WHOLESALEPRICE_INT.ReadOnly = true;
            this.WHOLESALEPRICE_INT.Visible = false;
            // 
            // m_dgvtxtRealNumber
            // 
            this.m_dgvtxtRealNumber.DataPropertyName = "realgross_int";
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.m_dgvtxtRealNumber.DefaultCellStyle = dataGridViewCellStyle4;
            this.m_dgvtxtRealNumber.HeaderText = "实际库存";
            this.m_dgvtxtRealNumber.Name = "m_dgvtxtRealNumber";
            this.m_dgvtxtRealNumber.ReadOnly = true;
            // 
            // m_dgvtxtCanUseNumber
            // 
            this.m_dgvtxtCanUseNumber.DataPropertyName = "availagross_int";
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.m_dgvtxtCanUseNumber.DefaultCellStyle = dataGridViewCellStyle5;
            this.m_dgvtxtCanUseNumber.HeaderText = "可用库存";
            this.m_dgvtxtCanUseNumber.Name = "m_dgvtxtCanUseNumber";
            this.m_dgvtxtCanUseNumber.ReadOnly = true;
            // 
            // m_dgvtxtSaleMoney
            // 
            this.m_dgvtxtSaleMoney.DataPropertyName = "retailmoney";
            dataGridViewCellStyle6.Format = "N4";
            dataGridViewCellStyle6.NullValue = null;
            this.m_dgvtxtSaleMoney.DefaultCellStyle = dataGridViewCellStyle6;
            this.m_dgvtxtSaleMoney.HeaderText = "零售金额";
            this.m_dgvtxtSaleMoney.Name = "m_dgvtxtSaleMoney";
            this.m_dgvtxtSaleMoney.ReadOnly = true;
            // 
            // m_dgvtxtBuyMoney
            // 
            this.m_dgvtxtBuyMoney.DataPropertyName = "inmoney";
            dataGridViewCellStyle7.Format = "N4";
            dataGridViewCellStyle7.NullValue = null;
            this.m_dgvtxtBuyMoney.DefaultCellStyle = dataGridViewCellStyle7;
            this.m_dgvtxtBuyMoney.HeaderText = "购入金额";
            this.m_dgvtxtBuyMoney.Name = "m_dgvtxtBuyMoney";
            this.m_dgvtxtBuyMoney.ReadOnly = true;
            // 
            // WHOLESALEPRICE_SUM
            // 
            this.WHOLESALEPRICE_SUM.DataPropertyName = "WHOLESALEPRICE_SUM";
            this.WHOLESALEPRICE_SUM.HeaderText = "批发金额";
            this.WHOLESALEPRICE_SUM.Name = "WHOLESALEPRICE_SUM";
            this.WHOLESALEPRICE_SUM.ReadOnly = true;
            this.WHOLESALEPRICE_SUM.Visible = false;
            // 
            // m_dgvtxtOrderCode
            // 
            this.m_dgvtxtOrderCode.DataPropertyName = "INSTORAGEID_VCHR";
            this.m_dgvtxtOrderCode.HeaderText = "入库单号";
            this.m_dgvtxtOrderCode.Name = "m_dgvtxtOrderCode";
            this.m_dgvtxtOrderCode.ReadOnly = true;
            // 
            // m_dgvtxtInData
            // 
            this.m_dgvtxtInData.DataPropertyName = "instoragedate_dat";
            this.m_dgvtxtInData.HeaderText = "入库日期";
            this.m_dgvtxtInData.Name = "m_dgvtxtInData";
            this.m_dgvtxtInData.ReadOnly = true;
            // 
            // m_dgvtxtProduceFactory
            // 
            this.m_dgvtxtProduceFactory.DataPropertyName = "productorid_chr";
            this.m_dgvtxtProduceFactory.HeaderText = "生产厂家";
            this.m_dgvtxtProduceFactory.Name = "m_dgvtxtProduceFactory";
            this.m_dgvtxtProduceFactory.ReadOnly = true;
            // 
            // PRODUCEDATE_DAT
            // 
            this.PRODUCEDATE_DAT.DataPropertyName = "PRODUCEDATE_DAT";
            this.PRODUCEDATE_DAT.HeaderText = "生产日期";
            this.PRODUCEDATE_DAT.Name = "PRODUCEDATE_DAT";
            this.PRODUCEDATE_DAT.ReadOnly = true;
            // 
            // m_dgvtxtEffectData
            // 
            this.m_dgvtxtEffectData.DataPropertyName = "validperiod_dat";
            dataGridViewCellStyle8.Format = "d";
            dataGridViewCellStyle8.NullValue = null;
            this.m_dgvtxtEffectData.DefaultCellStyle = dataGridViewCellStyle8;
            this.m_dgvtxtEffectData.HeaderText = "有效期";
            this.m_dgvtxtEffectData.Name = "m_dgvtxtEffectData";
            this.m_dgvtxtEffectData.ReadOnly = true;
            // 
            // m_dgvtxtStorageUnit
            // 
            this.m_dgvtxtStorageUnit.DataPropertyName = "storageunit";
            this.m_dgvtxtStorageUnit.HeaderText = "单位";
            this.m_dgvtxtStorageUnit.Name = "m_dgvtxtStorageUnit";
            this.m_dgvtxtStorageUnit.ReadOnly = true;
            this.m_dgvtxtStorageUnit.Width = 80;
            // 
            // m_dgvtxtAllRealGross
            // 
            this.m_dgvtxtAllRealGross.DataPropertyName = "allrealgross";
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = null;
            this.m_dgvtxtAllRealGross.DefaultCellStyle = dataGridViewCellStyle9;
            this.m_dgvtxtAllRealGross.HeaderText = "总实际库存";
            this.m_dgvtxtAllRealGross.Name = "m_dgvtxtAllRealGross";
            this.m_dgvtxtAllRealGross.ReadOnly = true;
            this.m_dgvtxtAllRealGross.Width = 90;
            // 
            // m_dgvtxtAllAvaGross
            // 
            this.m_dgvtxtAllAvaGross.DataPropertyName = "allavagross";
            dataGridViewCellStyle10.Format = "N2";
            dataGridViewCellStyle10.NullValue = null;
            this.m_dgvtxtAllAvaGross.DefaultCellStyle = dataGridViewCellStyle10;
            this.m_dgvtxtAllAvaGross.HeaderText = "总可用库存";
            this.m_dgvtxtAllAvaGross.Name = "m_dgvtxtAllAvaGross";
            this.m_dgvtxtAllAvaGross.ReadOnly = true;
            this.m_dgvtxtAllAvaGross.Width = 90;
            // 
            // medicineid_chr
            // 
            this.medicineid_chr.DataPropertyName = "medicineid_chr";
            this.medicineid_chr.HeaderText = "药品ID";
            this.medicineid_chr.Name = "medicineid_chr";
            this.medicineid_chr.ReadOnly = true;
            this.medicineid_chr.Visible = false;
            // 
            // oldgross_int
            // 
            this.oldgross_int.DataPropertyName = "oldgross_int";
            this.oldgross_int.HeaderText = "制单时可用库存";
            this.oldgross_int.Name = "oldgross_int";
            this.oldgross_int.ReadOnly = true;
            // 
            // m_txtIPUnit
            // 
            this.m_txtIPUnit.DataPropertyName = "ipunit_chr";
            this.m_txtIPUnit.HeaderText = "IPUnit";
            this.m_txtIPUnit.Name = "m_txtIPUnit";
            this.m_txtIPUnit.Visible = false;
            // 
            // m_txtPackQty
            // 
            this.m_txtPackQty.DataPropertyName = "packqty_dec";
            this.m_txtPackQty.HeaderText = "PackQty";
            this.m_txtPackQty.Name = "m_txtPackQty";
            this.m_txtPackQty.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.m_txtReceiptor);
            this.panel1.Controls.Add(this.m_lblReceiptor);
            this.panel1.Controls.Add(this.m_txtReceiveDept);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.m_txtRemark);
            this.panel1.Controls.Add(this.m_dtpDate);
            this.panel1.Controls.Add(this.m_txtMan);
            this.panel1.Controls.Add(this.m_txtOutputOrder);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(971, 69);
            this.panel1.TabIndex = 1;
            // 
            // m_txtReceiptor
            // 
            this.m_txtReceiptor.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtReceiptor.Location = new System.Drawing.Point(844, 9);
            this.m_txtReceiptor.Name = "m_txtReceiptor";
            this.m_txtReceiptor.Size = new System.Drawing.Size(98, 23);
            this.m_txtReceiptor.TabIndex = 4;
            this.m_txtReceiptor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtReceiptor_KeyPress);
            // 
            // m_lblReceiptor
            // 
            this.m_lblReceiptor.AutoSize = true;
            this.m_lblReceiptor.Location = new System.Drawing.Point(789, 12);
            this.m_lblReceiptor.Name = "m_lblReceiptor";
            this.m_lblReceiptor.Size = new System.Drawing.Size(49, 14);
            this.m_lblReceiptor.TabIndex = 5001;
            this.m_lblReceiptor.Text = "领用人";
            // 
            // m_txtReceiveDept
            // 
            this.m_txtReceiveDept.Location = new System.Drawing.Point(69, 9);
            this.m_txtReceiveDept.m_objTag = null;
            this.m_txtReceiveDept.Name = "m_txtReceiveDept";
            this.m_txtReceiveDept.Size = new System.Drawing.Size(142, 23);
            this.m_txtReceiveDept.TabIndex = 0;
            this.m_txtReceiveDept.显示类型 = com.digitalwave.Controls.Domain.EmrControls.enmDeptAttributeType.全部;
            this.m_txtReceiveDept.FocusNextControl += new System.EventHandler(this.m_txtReceiveDept_FocusNextControl);
            this.m_txtReceiveDept.Leave += new System.EventHandler(this.m_txtReceiveDept_Leave);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(225, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 34);
            this.label2.TabIndex = 1;
            this.label2.Text = "出库单号";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtRemark
            // 
            this.m_txtRemark.Location = new System.Drawing.Point(69, 38);
            this.m_txtRemark.Name = "m_txtRemark";
            this.m_txtRemark.Size = new System.Drawing.Size(535, 23);
            this.m_txtRemark.TabIndex = 5;
            this.m_txtRemark.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtRemark_KeyDown);
            // 
            // m_dtpDate
            // 
            this.m_dtpDate.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_dtpDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_dtpDate.Location = new System.Drawing.Point(476, 9);
            this.m_dtpDate.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日;
            this.m_dtpDate.Mask = "0000年90月90日";
            this.m_dtpDate.Name = "m_dtpDate";
            this.m_dtpDate.Size = new System.Drawing.Size(130, 23);
            this.m_dtpDate.TabIndex = 2;
            this.m_dtpDate.ValidatingType = typeof(System.DateTime);
            // 
            // m_txtMan
            // 
            this.m_txtMan.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtMan.Location = new System.Drawing.Point(675, 9);
            this.m_txtMan.Name = "m_txtMan";
            this.m_txtMan.Size = new System.Drawing.Size(98, 23);
            this.m_txtMan.TabIndex = 3;
            this.m_txtMan.Enter += new System.EventHandler(this.m_txtMan_Enter);
            // 
            // m_txtOutputOrder
            // 
            this.m_txtOutputOrder.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtOutputOrder.Location = new System.Drawing.Point(293, 9);
            this.m_txtOutputOrder.Name = "m_txtOutputOrder";
            this.m_txtOutputOrder.ReadOnly = true;
            this.m_txtOutputOrder.Size = new System.Drawing.Size(98, 23);
            this.m_txtOutputOrder.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 4;
            this.label5.Text = "备    注";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(620, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "制单人";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(407, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "制单时间";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "领用部门";
            // 
            // m_cmdDelete
            // 
            this.m_cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdDelete.ImageIndex = 2;
            this.m_cmdDelete.ImageList = this.imageList1;
            this.m_cmdDelete.Location = new System.Drawing.Point(190, 6);
            this.m_cmdDelete.Name = "m_cmdDelete";
            this.m_cmdDelete.Size = new System.Drawing.Size(94, 28);
            this.m_cmdDelete.TabIndex = 2;
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
            this.m_cmdInsertRecord.Location = new System.Drawing.Point(97, 6);
            this.m_cmdInsertRecord.Name = "m_cmdInsertRecord";
            this.m_cmdInsertRecord.Size = new System.Drawing.Size(94, 28);
            this.m_cmdInsertRecord.TabIndex = 3;
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
            this.m_cmdExit.Location = new System.Drawing.Point(871, 6);
            this.m_cmdExit.Name = "m_cmdExit";
            this.m_cmdExit.Size = new System.Drawing.Size(93, 28);
            this.m_cmdExit.TabIndex = 5;
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
            this.m_cmdNext.Location = new System.Drawing.Point(371, 6);
            this.m_cmdNext.Name = "m_cmdNext";
            this.m_cmdNext.Size = new System.Drawing.Size(113, 28);
            this.m_cmdNext.TabIndex = 4;
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
            this.m_cmdPrint.Location = new System.Drawing.Point(283, 6);
            this.m_cmdPrint.Name = "m_cmdPrint";
            this.m_cmdPrint.Size = new System.Drawing.Size(89, 28);
            this.m_cmdPrint.TabIndex = 3;
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
            this.m_cmdSave.Location = new System.Drawing.Point(4, 6);
            this.m_cmdSave.Name = "m_cmdSave";
            this.m_cmdSave.Size = new System.Drawing.Size(94, 28);
            this.m_cmdSave.TabIndex = 2;
            this.m_cmdSave.Text = "保存(&S)";
            this.m_cmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdSave.UseVisualStyleBackColor = true;
            this.m_cmdSave.Click += new System.EventHandler(this.m_cmdSave_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(745, 624);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 16);
            this.label7.TabIndex = 18;
            this.label7.Text = "批零差额￥";
            // 
            // m_lblDiffMoney
            // 
            this.m_lblDiffMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblDiffMoney.ForeColor = System.Drawing.Color.Red;
            this.m_lblDiffMoney.Location = new System.Drawing.Point(836, 625);
            this.m_lblDiffMoney.Name = "m_lblDiffMoney";
            this.m_lblDiffMoney.Size = new System.Drawing.Size(111, 14);
            this.m_lblDiffMoney.TabIndex = 19;
            // 
            // frmMedicineOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 644);
            this.Controls.Add(this.m_lblBugMoney);
            this.Controls.Add(this.m_lblDiffMoney);
            this.Controls.Add(this.m_lblSaleMoney);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.m_dgvMedicineOutInfo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_cmdDelete);
            this.Controls.Add(this.m_cmdInsertRecord);
            this.Controls.Add(this.m_cmdExit);
            this.Controls.Add(this.m_cmdNext);
            this.Controls.Add(this.m_cmdPrint);
            this.Controls.Add(this.m_cmdSave);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMedicineOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "药库出库";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMedicineOut_FormClosing);
            this.Load += new System.EventHandler(this.frmMedicineOut_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvMedicineOutInfo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_cmdExit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ImageList imageList1;
        internal com.digitalwave.controls.MedicineStoreControls.ctlDataGridView_EnterAsTab m_dgvMedicineOutInfo;
        private System.ComponentModel.BackgroundWorker m_bgwGetData;
        internal System.Windows.Forms.TextBox m_txtMan;
        internal System.Windows.Forms.TextBox m_txtOutputOrder;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab m_dtpDate;
        internal System.Windows.Forms.TextBox m_txtRemark;
        internal System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label m_lblSaleMoney;
        internal System.Windows.Forms.Button m_cmdNext;
        internal System.Windows.Forms.Button m_cmdPrint;
        internal System.Windows.Forms.Button m_cmdSave;
        internal System.Windows.Forms.Button m_cmdInsertRecord;
        internal System.Windows.Forms.Button m_cmdDelete;
        internal com.digitalwave.Controls.Domain.EmrControls.ctlDeptSelected_EnterKeyActive m_txtReceiveDept;
        public System.Windows.Forms.Label m_lblBugMoney;
        internal System.Windows.Forms.TextBox m_txtReceiptor;
        internal System.Windows.Forms.Label m_lblReceiptor;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label m_lblDiffMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtSerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtProduceNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtOutAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtOutUint;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtSalePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtBuyPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn WHOLESALEPRICE_INT;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtRealNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtCanUseNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtSaleMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtBuyMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn WHOLESALEPRICE_SUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtOrderCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtInData;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtProduceFactory;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCEDATE_DAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtEffectData;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtStorageUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtAllRealGross;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtAllAvaGross;
        private System.Windows.Forms.DataGridViewTextBoxColumn medicineid_chr;
        private System.Windows.Forms.DataGridViewTextBoxColumn oldgross_int;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_txtIPUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_txtPackQty;
    }
}