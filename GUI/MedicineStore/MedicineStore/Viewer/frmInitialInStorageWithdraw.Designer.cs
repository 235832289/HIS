namespace com.digitalwave.iCare.gui.MedicineStore
{
    partial class frmInitialInStorageWithdraw
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInitialInStorageWithdraw));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.m_bgwGetData = new System.ComponentModel.BackgroundWorker();
            this.m_lblBugMoney = new System.Windows.Forms.Label();
            this.m_lblSaleMoney = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_dgvInitialData = new com.digitalwave.controls.MedicineStoreControls.ctlDataGridView_EnterAsTab();
            this.m_dgvtxtSortNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedicineCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedicineName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtLotNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtCallPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtWholeSalePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtRetailPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvdtpValidPeriod = new com.digitalwave.controls.MedicineStoreControls.DataGridViewCalendarColumn();
            this.m_dgvtxtCallMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtWholeSaleMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtRetailMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtProductorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_txtVendor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtWithdrawDept = new com.digitalwave.Controls.Domain.EmrControls.ctlDeptSelected_EnterKeyActive();
            this.lblStorage = new System.Windows.Forms.Label();
            this.m_txtRemark = new System.Windows.Forms.TextBox();
            this.m_dtpTransactDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtInnerWithdrawBillNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_cmdExit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_cmdPrint = new System.Windows.Forms.Button();
            this.m_cmdDelete = new System.Windows.Forms.Button();
            this.m_cmdNextBill = new System.Windows.Forms.Button();
            this.m_cmdInsert = new System.Windows.Forms.Button();
            this.m_cmdSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvInitialData)).BeginInit();
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
            // 
            // m_bgwGetData
            // 
            this.m_bgwGetData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.m_bgwGetData_DoWork);
            // 
            // m_lblBugMoney
            // 
            this.m_lblBugMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblBugMoney.ForeColor = System.Drawing.Color.Red;
            this.m_lblBugMoney.Location = new System.Drawing.Point(598, 627);
            this.m_lblBugMoney.Name = "m_lblBugMoney";
            this.m_lblBugMoney.Size = new System.Drawing.Size(106, 14);
            this.m_lblBugMoney.TabIndex = 21;
            this.m_lblBugMoney.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblSaleMoney
            // 
            this.m_lblSaleMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblSaleMoney.ForeColor = System.Drawing.Color.Red;
            this.m_lblSaleMoney.Location = new System.Drawing.Point(794, 627);
            this.m_lblSaleMoney.Name = "m_lblSaleMoney";
            this.m_lblSaleMoney.Size = new System.Drawing.Size(111, 14);
            this.m_lblSaleMoney.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(706, 626);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 16);
            this.label8.TabIndex = 22;
            this.label8.Text = "零售总金额￥";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(510, 626);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 16);
            this.label6.TabIndex = 20;
            this.label6.Text = "购入总金额￥";
            // 
            // m_dgvInitialData
            // 
            this.m_dgvInitialData.AllowUserToAddRows = false;
            this.m_dgvInitialData.AllowUserToDeleteRows = false;
            this.m_dgvInitialData.AllowUserToResizeRows = false;
            this.m_dgvInitialData.ColumnHeadersHeight = 28;
            this.m_dgvInitialData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_dgvtxtSortNum,
            this.m_dgvtxtMedicineCode,
            this.m_dgvtxtMedicineName,
            this.m_dgvtxtSpec,
            this.m_dgvtxtUnit,
            this.m_dgvtxtLotNO,
            this.m_dgvtxtAmount,
            this.m_dgvtxtCallPrice,
            this.m_dgvtxtWholeSalePrice,
            this.m_dgvtxtRetailPrice,
            this.m_dgvdtpValidPeriod,
            this.m_dgvtxtCallMoney,
            this.m_dgvtxtWholeSaleMoney,
            this.m_dgvtxtRetailMoney,
            this.m_dgvtxtProductorID});
            this.m_dgvInitialData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.m_dgvInitialData.Location = new System.Drawing.Point(5, 116);
            this.m_dgvInitialData.MultiSelect = false;
            this.m_dgvInitialData.Name = "m_dgvInitialData";
            this.m_dgvInitialData.RowHeadersVisible = false;
            this.m_dgvInitialData.RowTemplate.Height = 23;
            this.m_dgvInitialData.Size = new System.Drawing.Size(964, 528);
            this.m_dgvInitialData.TabIndex = 12;
            this.m_dgvInitialData.EnterKeyPress += new com.digitalwave.controls.MedicineStoreControls.EnterKeyPressInCurrentCell(this.m_dgvInitialData_EnterKeyPress);
            this.m_dgvInitialData.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.m_dgvInitialData_RowsAdded);
            this.m_dgvInitialData.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.m_dgvInitialData_DataError);
            this.m_dgvInitialData.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.m_dgvInitialData_RowsRemoved);
            this.m_dgvInitialData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvInitialData_CellContentClick);
            // 
            // m_dgvtxtSortNum
            // 
            this.m_dgvtxtSortNum.Frozen = true;
            this.m_dgvtxtSortNum.HeaderText = "序号";
            this.m_dgvtxtSortNum.Name = "m_dgvtxtSortNum";
            this.m_dgvtxtSortNum.ReadOnly = true;
            this.m_dgvtxtSortNum.Width = 55;
            // 
            // m_dgvtxtMedicineCode
            // 
            this.m_dgvtxtMedicineCode.DataPropertyName = "ASSISTCODE_CHR";
            this.m_dgvtxtMedicineCode.HeaderText = "药品代码";
            this.m_dgvtxtMedicineCode.Name = "m_dgvtxtMedicineCode";
            // 
            // m_dgvtxtMedicineName
            // 
            this.m_dgvtxtMedicineName.DataPropertyName = "MEDICINENAME_VCH";
            this.m_dgvtxtMedicineName.HeaderText = "名称";
            this.m_dgvtxtMedicineName.Name = "m_dgvtxtMedicineName";
            this.m_dgvtxtMedicineName.ReadOnly = true;
            this.m_dgvtxtMedicineName.Width = 150;
            // 
            // m_dgvtxtSpec
            // 
            this.m_dgvtxtSpec.DataPropertyName = "MEDSPEC_VCHR";
            this.m_dgvtxtSpec.HeaderText = "规格";
            this.m_dgvtxtSpec.Name = "m_dgvtxtSpec";
            this.m_dgvtxtSpec.ReadOnly = true;
            // 
            // m_dgvtxtUnit
            // 
            this.m_dgvtxtUnit.DataPropertyName = "UNIT_VCHR";
            this.m_dgvtxtUnit.HeaderText = "单位";
            this.m_dgvtxtUnit.Name = "m_dgvtxtUnit";
            this.m_dgvtxtUnit.ReadOnly = true;
            this.m_dgvtxtUnit.Width = 60;
            // 
            // m_dgvtxtLotNO
            // 
            this.m_dgvtxtLotNO.DataPropertyName = "LOTNO_VCHR";
            this.m_dgvtxtLotNO.HeaderText = "批号";
            this.m_dgvtxtLotNO.MaxInputLength = 10;
            this.m_dgvtxtLotNO.Name = "m_dgvtxtLotNO";
            // 
            // m_dgvtxtAmount
            // 
            this.m_dgvtxtAmount.DataPropertyName = "AMOUNT";
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.m_dgvtxtAmount.DefaultCellStyle = dataGridViewCellStyle1;
            this.m_dgvtxtAmount.HeaderText = "退药数量";
            this.m_dgvtxtAmount.MaxInputLength = 8;
            this.m_dgvtxtAmount.Name = "m_dgvtxtAmount";
            this.m_dgvtxtAmount.Width = 80;
            // 
            // m_dgvtxtCallPrice
            // 
            this.m_dgvtxtCallPrice.DataPropertyName = "CALLPRICE_INT";
            dataGridViewCellStyle2.Format = "N4";
            dataGridViewCellStyle2.NullValue = null;
            this.m_dgvtxtCallPrice.DefaultCellStyle = dataGridViewCellStyle2;
            this.m_dgvtxtCallPrice.HeaderText = "购入单价";
            this.m_dgvtxtCallPrice.MaxInputLength = 8;
            this.m_dgvtxtCallPrice.Name = "m_dgvtxtCallPrice";
            this.m_dgvtxtCallPrice.Width = 80;
            // 
            // m_dgvtxtWholeSalePrice
            // 
            this.m_dgvtxtWholeSalePrice.DataPropertyName = "WHOLESALEPRICE_INT";
            dataGridViewCellStyle3.Format = "N4";
            dataGridViewCellStyle3.NullValue = null;
            this.m_dgvtxtWholeSalePrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.m_dgvtxtWholeSalePrice.HeaderText = "批发单价";
            this.m_dgvtxtWholeSalePrice.MaxInputLength = 8;
            this.m_dgvtxtWholeSalePrice.Name = "m_dgvtxtWholeSalePrice";
            this.m_dgvtxtWholeSalePrice.Width = 80;
            // 
            // m_dgvtxtRetailPrice
            // 
            this.m_dgvtxtRetailPrice.DataPropertyName = "RETAILPRICE_INT";
            dataGridViewCellStyle4.Format = "N4";
            dataGridViewCellStyle4.NullValue = null;
            this.m_dgvtxtRetailPrice.DefaultCellStyle = dataGridViewCellStyle4;
            this.m_dgvtxtRetailPrice.HeaderText = "零售单价";
            this.m_dgvtxtRetailPrice.MaxInputLength = 8;
            this.m_dgvtxtRetailPrice.Name = "m_dgvtxtRetailPrice";
            this.m_dgvtxtRetailPrice.Width = 80;
            // 
            // m_dgvdtpValidPeriod
            // 
            this.m_dgvdtpValidPeriod.DataPropertyName = "VALIDPERIOD_DAT";
            this.m_dgvdtpValidPeriod.HeaderText = "有效期";
            this.m_dgvdtpValidPeriod.Name = "m_dgvdtpValidPeriod";
            // 
            // m_dgvtxtCallMoney
            // 
            this.m_dgvtxtCallMoney.DataPropertyName = "CallMoney";
            this.m_dgvtxtCallMoney.HeaderText = "购入金额";
            this.m_dgvtxtCallMoney.Name = "m_dgvtxtCallMoney";
            this.m_dgvtxtCallMoney.ReadOnly = true;
            // 
            // m_dgvtxtWholeSaleMoney
            // 
            this.m_dgvtxtWholeSaleMoney.DataPropertyName = "WholeSaleMoney";
            this.m_dgvtxtWholeSaleMoney.HeaderText = "批发金额";
            this.m_dgvtxtWholeSaleMoney.Name = "m_dgvtxtWholeSaleMoney";
            this.m_dgvtxtWholeSaleMoney.ReadOnly = true;
            // 
            // m_dgvtxtRetailMoney
            // 
            this.m_dgvtxtRetailMoney.DataPropertyName = "RetailMoney";
            this.m_dgvtxtRetailMoney.HeaderText = "零售金额";
            this.m_dgvtxtRetailMoney.Name = "m_dgvtxtRetailMoney";
            this.m_dgvtxtRetailMoney.ReadOnly = true;
            // 
            // m_dgvtxtProductorID
            // 
            this.m_dgvtxtProductorID.DataPropertyName = "PRODUCTORID_CHR";
            this.m_dgvtxtProductorID.HeaderText = "生产厂家";
            this.m_dgvtxtProductorID.MaxInputLength = 100;
            this.m_dgvtxtProductorID.Name = "m_dgvtxtProductorID";
            this.m_dgvtxtProductorID.Width = 120;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.m_txtVendor);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.m_txtWithdrawDept);
            this.panel2.Controls.Add(this.lblStorage);
            this.panel2.Controls.Add(this.m_txtRemark);
            this.panel2.Controls.Add(this.m_dtpTransactDate);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.m_txtInnerWithdrawBillNo);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(2, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(967, 65);
            this.panel2.TabIndex = 1;
            // 
            // m_txtVendor
            // 
            this.m_txtVendor.Location = new System.Drawing.Point(773, 6);
            this.m_txtVendor.Name = "m_txtVendor";
            this.m_txtVendor.Size = new System.Drawing.Size(167, 23);
            this.m_txtVendor.TabIndex = 10003;
            this.m_txtVendor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtVendor_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(718, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 10002;
            this.label3.Text = "供应商";
            // 
            // m_txtWithdrawDept
            // 
            this.m_txtWithdrawDept.Location = new System.Drawing.Point(530, 6);
            this.m_txtWithdrawDept.m_objTag = null;
            this.m_txtWithdrawDept.Name = "m_txtWithdrawDept";
            this.m_txtWithdrawDept.Size = new System.Drawing.Size(155, 23);
            this.m_txtWithdrawDept.TabIndex = 2;
            this.m_txtWithdrawDept.显示类型 = com.digitalwave.Controls.Domain.EmrControls.enmDeptAttributeType.全部;
            this.m_txtWithdrawDept.FocusNextControl += new System.EventHandler(this.m_txtWithdrawDept_FocusNextControl);
            // 
            // lblStorage
            // 
            this.lblStorage.AutoSize = true;
            this.lblStorage.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStorage.Location = new System.Drawing.Point(461, 10);
            this.lblStorage.Name = "lblStorage";
            this.lblStorage.Size = new System.Drawing.Size(63, 14);
            this.lblStorage.TabIndex = 10002;
            this.lblStorage.Text = "内退单位";
            // 
            // m_txtRemark
            // 
            this.m_txtRemark.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtRemark.Location = new System.Drawing.Point(78, 35);
            this.m_txtRemark.MaxLength = 200;
            this.m_txtRemark.Name = "m_txtRemark";
            this.m_txtRemark.Size = new System.Drawing.Size(355, 23);
            this.m_txtRemark.TabIndex = 3;
            this.m_txtRemark.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtRemark_KeyDown);
            // 
            // m_dtpTransactDate
            // 
            this.m_dtpTransactDate.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_dtpTransactDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_dtpTransactDate.Location = new System.Drawing.Point(303, 6);
            this.m_dtpTransactDate.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日;
            this.m_dtpTransactDate.Mask = "0000年90月90日";
            this.m_dtpTransactDate.Name = "m_dtpTransactDate";
            this.m_dtpTransactDate.Size = new System.Drawing.Size(130, 23);
            this.m_dtpTransactDate.TabIndex = 4;
            this.m_dtpTransactDate.ValidatingType = typeof(System.DateTime);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(41, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 14);
            this.label7.TabIndex = 10000;
            this.label7.Text = "备注";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 10000;
            this.label1.Text = "内退单号";
            // 
            // m_txtInnerWithdrawBillNo
            // 
            this.m_txtInnerWithdrawBillNo.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtInnerWithdrawBillNo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtInnerWithdrawBillNo.Location = new System.Drawing.Point(78, 6);
            this.m_txtInnerWithdrawBillNo.Name = "m_txtInnerWithdrawBillNo";
            this.m_txtInnerWithdrawBillNo.ReadOnly = true;
            this.m_txtInnerWithdrawBillNo.Size = new System.Drawing.Size(130, 23);
            this.m_txtInnerWithdrawBillNo.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(234, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 10000;
            this.label2.Text = "办理日期";
            // 
            // m_cmdExit
            // 
            this.m_cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdExit.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_cmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdExit.ImageIndex = 1;
            this.m_cmdExit.ImageList = this.imageList1;
            this.m_cmdExit.Location = new System.Drawing.Point(874, 6);
            this.m_cmdExit.Name = "m_cmdExit";
            this.m_cmdExit.Size = new System.Drawing.Size(94, 32);
            this.m_cmdExit.TabIndex = 10;
            this.m_cmdExit.Text = "退出(&Q)";
            this.m_cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdExit.UseVisualStyleBackColor = true;
            this.m_cmdExit.Click += new System.EventHandler(this.m_cmdExit_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.m_cmdPrint);
            this.panel1.Controls.Add(this.m_cmdDelete);
            this.panel1.Controls.Add(this.m_cmdNextBill);
            this.panel1.Controls.Add(this.m_cmdInsert);
            this.panel1.Controls.Add(this.m_cmdSave);
            this.panel1.Location = new System.Drawing.Point(4, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(490, 37);
            this.panel1.TabIndex = 9;
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
            this.m_cmdPrint.Size = new System.Drawing.Size(94, 32);
            this.m_cmdPrint.TabIndex = 3;
            this.m_cmdPrint.Text = "打印(&P)";
            this.m_cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdPrint.UseVisualStyleBackColor = true;
            this.m_cmdPrint.Click += new System.EventHandler(this.m_cmdPrint_Click);
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
            this.m_cmdDelete.Size = new System.Drawing.Size(94, 32);
            this.m_cmdDelete.TabIndex = 1;
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
            this.m_cmdNextBill.Size = new System.Drawing.Size(112, 32);
            this.m_cmdNextBill.TabIndex = 4;
            this.m_cmdNextBill.Text = "下一张单(&N)";
            this.m_cmdNextBill.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdNextBill.UseVisualStyleBackColor = true;
            this.m_cmdNextBill.Click += new System.EventHandler(this.m_cmdNextBill_Click);
            // 
            // m_cmdInsert
            // 
            this.m_cmdInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdInsert.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_cmdInsert.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.m_cmdInsert.ImageIndex = 3;
            this.m_cmdInsert.ImageList = this.imageList1;
            this.m_cmdInsert.Location = new System.Drawing.Point(94, 3);
            this.m_cmdInsert.Name = "m_cmdInsert";
            this.m_cmdInsert.Size = new System.Drawing.Size(94, 32);
            this.m_cmdInsert.TabIndex = 0;
            this.m_cmdInsert.Text = "插入(&N)";
            this.m_cmdInsert.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdInsert.UseVisualStyleBackColor = true;
            this.m_cmdInsert.Click += new System.EventHandler(this.m_cmdInsert_Click);
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
            this.m_cmdSave.Size = new System.Drawing.Size(94, 32);
            this.m_cmdSave.TabIndex = 0;
            this.m_cmdSave.Text = "保存(&S)";
            this.m_cmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdSave.UseVisualStyleBackColor = true;
            this.m_cmdSave.Click += new System.EventHandler(this.m_cmdSave_Click);
            // 
            // frmInitialInStorageWithdraw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 648);
            this.Controls.Add(this.m_lblBugMoney);
            this.Controls.Add(this.m_lblSaleMoney);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.m_dgvInitialData);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.m_cmdExit);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmInitialInStorageWithdraw";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "内退初始化";
            this.Load += new System.EventHandler(this.frmInitialInStorageWithdraw_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvInitialData)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        internal System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button m_cmdPrint;
        private System.Windows.Forms.Button m_cmdExit;
        internal System.Windows.Forms.Panel panel2;
        internal com.digitalwave.Controls.Domain.EmrControls.ctlDeptSelected_EnterKeyActive m_txtWithdrawDept;
        private System.Windows.Forms.Label lblStorage;
        internal System.Windows.Forms.TextBox m_txtRemark;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker m_dtpTransactDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox m_txtInnerWithdrawBillNo;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker m_bgwGetData;
        internal com.digitalwave.controls.MedicineStoreControls.ctlDataGridView_EnterAsTab m_dgvInitialData;
        internal System.Windows.Forms.Label m_lblBugMoney;
        internal System.Windows.Forms.Label m_lblSaleMoney;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtSortNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtLotNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtCallPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtWholeSalePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtRetailPrice;
        private com.digitalwave.controls.MedicineStoreControls.DataGridViewCalendarColumn m_dgvdtpValidPeriod;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtCallMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtWholeSaleMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtRetailMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtProductorID;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox m_txtVendor;
        internal System.Windows.Forms.Button m_cmdDelete;
        internal System.Windows.Forms.Button m_cmdNextBill;
        internal System.Windows.Forms.Button m_cmdSave;
        internal System.Windows.Forms.Button m_cmdInsert;
    }
}