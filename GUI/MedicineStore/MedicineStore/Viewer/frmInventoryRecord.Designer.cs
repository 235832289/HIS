namespace com.digitalwave.iCare.gui.MedicineStore
{
    partial class frmInventoryRecord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInventoryRecord));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.m_bgwGetMedicineDetail = new System.ComponentModel.BackgroundWorker();
            this.m_pnlWaiting = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.m_cmdClose = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.m_cmdDelete = new System.Windows.Forms.Button();
            this.m_cmdInsert = new System.Windows.Forms.Button();
            this.m_cmdSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtMedicineID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtInputMan = new System.Windows.Forms.TextBox();
            this.m_txtCommitMan = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_cboCommitInfo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_cmdRefresh = new System.Windows.Forms.Button();
            this.m_cmdCommit = new System.Windows.Forms.Button();
            this.m_cmdPrint = new System.Windows.Forms.Button();
            this.m_dtgvMedicineDetail = new com.digitalwave.controls.MedicineStoreControls.ctlDataGridView_EnterAsTab();
            this.m_lblAllInMoneyTitle = new System.Windows.Forms.Label();
            this.m_lblAllInMoney = new System.Windows.Forms.Label();
            this.m_lblAllWholeSaleMoneyTitle = new System.Windows.Forms.Label();
            this.m_lblAllWholeSaleMoney = new System.Windows.Forms.Label();
            this.m_lblAllRetailMoneyTitle = new System.Windows.Forms.Label();
            this.m_lblAllRetailMoney = new System.Windows.Forms.Label();
            this.m_bgwCommit = new System.ComponentModel.BackgroundWorker();
            this.m_cmdInAccount = new System.Windows.Forms.Button();
            this.m_cmdExitAuditing = new System.Windows.Forms.Button();
            this.m_cmdExport = new System.Windows.Forms.Button();
            this.m_dgvtxtMedicineCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedicineName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedicineSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtStoreAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedicineUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtBatchNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtBugUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtWholeSaleUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtSaleUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtValidity = new com.digitalwave.controls.MedicineStoreControls.DataGridViewCalendarColumn();
            this.m_dgvtxtSupplierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtCreater = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxExamer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_pnlWaiting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgvMedicineDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // m_bgwGetMedicineDetail
            // 
            this.m_bgwGetMedicineDetail.DoWork += new System.ComponentModel.DoWorkEventHandler(this.m_bgwGetMedicineDetail_DoWork);
            this.m_bgwGetMedicineDetail.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.m_bgwGetMedicineDetail_RunWorkerCompleted);
            // 
            // m_pnlWaiting
            // 
            this.m_pnlWaiting.BackColor = System.Drawing.SystemColors.Control;
            this.m_pnlWaiting.Controls.Add(this.label14);
            this.m_pnlWaiting.Controls.Add(this.pictureBox1);
            this.m_pnlWaiting.Location = new System.Drawing.Point(366, 285);
            this.m_pnlWaiting.Name = "m_pnlWaiting";
            this.m_pnlWaiting.Size = new System.Drawing.Size(307, 71);
            this.m_pnlWaiting.TabIndex = 10000;
            this.m_pnlWaiting.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label14.Location = new System.Drawing.Point(86, 28);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(217, 14);
            this.label14.TabIndex = 1;
            this.label14.Text = "正在获取数据，请稍候..........";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 70);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // m_cmdClose
            // 
            this.m_cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdClose.ImageIndex = 1;
            this.m_cmdClose.ImageList = this.imageList1;
            this.m_cmdClose.Location = new System.Drawing.Point(917, 4);
            this.m_cmdClose.Name = "m_cmdClose";
            this.m_cmdClose.Size = new System.Drawing.Size(94, 28);
            this.m_cmdClose.TabIndex = 60;
            this.m_cmdClose.Text = "退出(&Q)";
            this.m_cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdClose.UseVisualStyleBackColor = true;
            this.m_cmdClose.Click += new System.EventHandler(this.m_cmdClose_Click);
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
            // m_cmdDelete
            // 
            this.m_cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdDelete.ImageIndex = 2;
            this.m_cmdDelete.ImageList = this.imageList1;
            this.m_cmdDelete.Location = new System.Drawing.Point(184, 4);
            this.m_cmdDelete.Name = "m_cmdDelete";
            this.m_cmdDelete.Size = new System.Drawing.Size(89, 28);
            this.m_cmdDelete.TabIndex = 30;
            this.m_cmdDelete.Text = "删除(&D)";
            this.m_cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdDelete.UseVisualStyleBackColor = true;
            this.m_cmdDelete.Click += new System.EventHandler(this.m_cmdDelete_Click);
            // 
            // m_cmdInsert
            // 
            this.m_cmdInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdInsert.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdInsert.ImageIndex = 3;
            this.m_cmdInsert.ImageList = this.imageList1;
            this.m_cmdInsert.Location = new System.Drawing.Point(96, 4);
            this.m_cmdInsert.Name = "m_cmdInsert";
            this.m_cmdInsert.Size = new System.Drawing.Size(89, 28);
            this.m_cmdInsert.TabIndex = 10;
            this.m_cmdInsert.Text = "插入(&A)";
            this.m_cmdInsert.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdInsert.UseVisualStyleBackColor = true;
            this.m_cmdInsert.Click += new System.EventHandler(this.m_cmdInsert_Click);
            // 
            // m_cmdSave
            // 
            this.m_cmdSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.m_cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdSave.ImageIndex = 0;
            this.m_cmdSave.ImageList = this.imageList1;
            this.m_cmdSave.Location = new System.Drawing.Point(8, 4);
            this.m_cmdSave.Name = "m_cmdSave";
            this.m_cmdSave.Size = new System.Drawing.Size(89, 28);
            this.m_cmdSave.TabIndex = 2;
            this.m_cmdSave.Text = "保存(&S)";
            this.m_cmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdSave.UseVisualStyleBackColor = true;
            this.m_cmdSave.Click += new System.EventHandler(this.m_cmdSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(20, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 10001;
            this.label1.Text = "药品代码";
            // 
            // m_txtMedicineID
            // 
            this.m_txtMedicineID.Location = new System.Drawing.Point(88, 54);
            this.m_txtMedicineID.Name = "m_txtMedicineID";
            this.m_txtMedicineID.Size = new System.Drawing.Size(170, 23);
            this.m_txtMedicineID.TabIndex = 10002;
            this.m_txtMedicineID.TextChanged += new System.EventHandler(this.TextFilter_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(280, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 10003;
            this.label2.Text = "录入人";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(534, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 10004;
            this.label3.Text = "审核人";
            // 
            // m_txtInputMan
            // 
            this.m_txtInputMan.Location = new System.Drawing.Point(337, 54);
            this.m_txtInputMan.Name = "m_txtInputMan";
            this.m_txtInputMan.Size = new System.Drawing.Size(170, 23);
            this.m_txtInputMan.TabIndex = 10005;
            this.m_txtInputMan.TextChanged += new System.EventHandler(this.TextFilter_TextChanged);
            // 
            // m_txtCommitMan
            // 
            this.m_txtCommitMan.Location = new System.Drawing.Point(591, 54);
            this.m_txtCommitMan.Name = "m_txtCommitMan";
            this.m_txtCommitMan.Size = new System.Drawing.Size(170, 23);
            this.m_txtCommitMan.TabIndex = 10006;
            this.m_txtCommitMan.TextChanged += new System.EventHandler(this.TextFilter_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.m_cboCommitInfo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.groupBox1.Location = new System.Drawing.Point(11, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1006, 52);
            this.groupBox1.TabIndex = 10007;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // m_cboCommitInfo
            // 
            this.m_cboCommitInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboCommitInfo.FormattingEnabled = true;
            this.m_cboCommitInfo.Items.AddRange(new object[] {
            "全部",
            "未审核",
            "已审核"});
            this.m_cboCommitInfo.Location = new System.Drawing.Point(853, 19);
            this.m_cboCommitInfo.Name = "m_cboCommitInfo";
            this.m_cboCommitInfo.Size = new System.Drawing.Size(123, 22);
            this.m_cboCommitInfo.TabIndex = 0;
            this.m_cboCommitInfo.SelectedIndexChanged += new System.EventHandler(this.m_cboCommitInfo_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(784, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 10004;
            this.label4.Text = "审核状态";
            // 
            // m_cmdRefresh
            // 
            this.m_cmdRefresh.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdRefresh.ImageIndex = 5;
            this.m_cmdRefresh.ImageList = this.imageList1;
            this.m_cmdRefresh.Location = new System.Drawing.Point(272, 4);
            this.m_cmdRefresh.Name = "m_cmdRefresh";
            this.m_cmdRefresh.Size = new System.Drawing.Size(89, 28);
            this.m_cmdRefresh.TabIndex = 40;
            this.m_cmdRefresh.Text = "刷新(&R)";
            this.m_cmdRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdRefresh.UseVisualStyleBackColor = true;
            this.m_cmdRefresh.Click += new System.EventHandler(this.m_cmdRefresh_Click);
            // 
            // m_cmdCommit
            // 
            this.m_cmdCommit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdCommit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdCommit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdCommit.ImageIndex = 4;
            this.m_cmdCommit.ImageList = this.imageList1;
            this.m_cmdCommit.Location = new System.Drawing.Point(360, 4);
            this.m_cmdCommit.Name = "m_cmdCommit";
            this.m_cmdCommit.Size = new System.Drawing.Size(89, 28);
            this.m_cmdCommit.TabIndex = 50;
            this.m_cmdCommit.Text = "审核(&C)";
            this.m_cmdCommit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdCommit.UseVisualStyleBackColor = true;
            this.m_cmdCommit.Click += new System.EventHandler(this.m_cmdCommit_Click);
            // 
            // m_cmdPrint
            // 
            this.m_cmdPrint.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdPrint.ImageIndex = 6;
            this.m_cmdPrint.ImageList = this.imageList1;
            this.m_cmdPrint.Location = new System.Drawing.Point(634, 4);
            this.m_cmdPrint.Name = "m_cmdPrint";
            this.m_cmdPrint.Size = new System.Drawing.Size(89, 28);
            this.m_cmdPrint.TabIndex = 50;
            this.m_cmdPrint.Text = "打印(&P)";
            this.m_cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdPrint.UseVisualStyleBackColor = true;
            this.m_cmdPrint.Click += new System.EventHandler(this.m_cmdPrint_Click);
            // 
            // m_dtgvMedicineDetail
            // 
            this.m_dtgvMedicineDetail.AllowUserToAddRows = false;
            this.m_dtgvMedicineDetail.AllowUserToDeleteRows = false;
            this.m_dtgvMedicineDetail.AllowUserToResizeRows = false;
            this.m_dtgvMedicineDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_dtgvMedicineDetail.BackgroundColor = System.Drawing.SystemColors.Info;
            this.m_dtgvMedicineDetail.ColumnHeadersHeight = 40;
            this.m_dtgvMedicineDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_dgvtxtMedicineCode,
            this.m_dgvtxtMedicineName,
            this.m_dgvtxtMedicineSpec,
            this.m_dgvtxtStoreAmount,
            this.m_dgvtxtMedicineUnit,
            this.m_dgvtxtBatchNumber,
            this.m_dgvtxtBugUnitPrice,
            this.m_dgvtxtWholeSaleUnitPrice,
            this.m_dgvtxtSaleUnitPrice,
            this.m_dgvtxtValidity,
            this.m_dgvtxtSupplierName,
            this.m_dgvtxtManufacturer,
            this.m_dgvtxtCreater,
            this.m_dgvtxExamer,
            this.m_dgvtxtStatus});
            this.m_dtgvMedicineDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.m_dtgvMedicineDetail.Location = new System.Drawing.Point(8, 94);
            this.m_dtgvMedicineDetail.MultiSelect = false;
            this.m_dtgvMedicineDetail.Name = "m_dtgvMedicineDetail";
            this.m_dtgvMedicineDetail.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info;
            this.m_dtgvMedicineDetail.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.m_dtgvMedicineDetail.RowTemplate.Height = 23;
            this.m_dtgvMedicineDetail.Size = new System.Drawing.Size(1008, 390);
            this.m_dtgvMedicineDetail.TabIndex = 1;
            this.m_dtgvMedicineDetail.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dtgvMedicineDetail_CellLeave);
            this.m_dtgvMedicineDetail.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.m_dtgvMedicineDetail_RowsAdded);
            this.m_dtgvMedicineDetail.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.m_dtgvMedicineDetail_DataError);
            // 
            // m_lblAllInMoneyTitle
            // 
            this.m_lblAllInMoneyTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblAllInMoneyTitle.ForeColor = System.Drawing.Color.Red;
            this.m_lblAllInMoneyTitle.Location = new System.Drawing.Point(347, 467);
            this.m_lblAllInMoneyTitle.Name = "m_lblAllInMoneyTitle";
            this.m_lblAllInMoneyTitle.Size = new System.Drawing.Size(92, 15);
            this.m_lblAllInMoneyTitle.TabIndex = 10008;
            this.m_lblAllInMoneyTitle.Text = "购入总金额￥";
            // 
            // m_lblAllInMoney
            // 
            this.m_lblAllInMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblAllInMoney.ForeColor = System.Drawing.Color.Red;
            this.m_lblAllInMoney.Location = new System.Drawing.Point(437, 467);
            this.m_lblAllInMoney.Name = "m_lblAllInMoney";
            this.m_lblAllInMoney.Size = new System.Drawing.Size(118, 15);
            this.m_lblAllInMoney.TabIndex = 10008;
            this.m_lblAllInMoney.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // m_lblAllWholeSaleMoneyTitle
            // 
            this.m_lblAllWholeSaleMoneyTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblAllWholeSaleMoneyTitle.ForeColor = System.Drawing.Color.Red;
            this.m_lblAllWholeSaleMoneyTitle.Location = new System.Drawing.Point(556, 467);
            this.m_lblAllWholeSaleMoneyTitle.Name = "m_lblAllWholeSaleMoneyTitle";
            this.m_lblAllWholeSaleMoneyTitle.Size = new System.Drawing.Size(92, 15);
            this.m_lblAllWholeSaleMoneyTitle.TabIndex = 10008;
            this.m_lblAllWholeSaleMoneyTitle.Text = "批发总金额￥";
            // 
            // m_lblAllWholeSaleMoney
            // 
            this.m_lblAllWholeSaleMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblAllWholeSaleMoney.ForeColor = System.Drawing.Color.Red;
            this.m_lblAllWholeSaleMoney.Location = new System.Drawing.Point(646, 467);
            this.m_lblAllWholeSaleMoney.Name = "m_lblAllWholeSaleMoney";
            this.m_lblAllWholeSaleMoney.Size = new System.Drawing.Size(118, 15);
            this.m_lblAllWholeSaleMoney.TabIndex = 10008;
            this.m_lblAllWholeSaleMoney.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // m_lblAllRetailMoneyTitle
            // 
            this.m_lblAllRetailMoneyTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblAllRetailMoneyTitle.ForeColor = System.Drawing.Color.Red;
            this.m_lblAllRetailMoneyTitle.Location = new System.Drawing.Point(765, 467);
            this.m_lblAllRetailMoneyTitle.Name = "m_lblAllRetailMoneyTitle";
            this.m_lblAllRetailMoneyTitle.Size = new System.Drawing.Size(92, 15);
            this.m_lblAllRetailMoneyTitle.TabIndex = 10008;
            this.m_lblAllRetailMoneyTitle.Text = "零售总金额￥";
            // 
            // m_lblAllRetailMoney
            // 
            this.m_lblAllRetailMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblAllRetailMoney.ForeColor = System.Drawing.Color.Red;
            this.m_lblAllRetailMoney.Location = new System.Drawing.Point(854, 467);
            this.m_lblAllRetailMoney.Name = "m_lblAllRetailMoney";
            this.m_lblAllRetailMoney.Size = new System.Drawing.Size(118, 15);
            this.m_lblAllRetailMoney.TabIndex = 10008;
            this.m_lblAllRetailMoney.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // m_bgwCommit
            // 
            this.m_bgwCommit.DoWork += new System.ComponentModel.DoWorkEventHandler(this.m_bgwCommit_DoWork);
            this.m_bgwCommit.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.m_bgwCommit_RunWorkerCompleted);
            // 
            // m_cmdInAccount
            // 
            this.m_cmdInAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdInAccount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdInAccount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdInAccount.ImageIndex = 11;
            this.m_cmdInAccount.ImageList = this.imageList1;
            this.m_cmdInAccount.Location = new System.Drawing.Point(541, 4);
            this.m_cmdInAccount.Name = "m_cmdInAccount";
            this.m_cmdInAccount.Size = new System.Drawing.Size(94, 28);
            this.m_cmdInAccount.TabIndex = 10010;
            this.m_cmdInAccount.Text = "入帐(&I)";
            this.m_cmdInAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdInAccount.UseVisualStyleBackColor = true;
            this.m_cmdInAccount.Click += new System.EventHandler(this.m_cmdInAccount_Click);
            // 
            // m_cmdExitAuditing
            // 
            this.m_cmdExitAuditing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdExitAuditing.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdExitAuditing.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdExitAuditing.ImageIndex = 10;
            this.m_cmdExitAuditing.ImageList = this.imageList1;
            this.m_cmdExitAuditing.Location = new System.Drawing.Point(448, 4);
            this.m_cmdExitAuditing.Name = "m_cmdExitAuditing";
            this.m_cmdExitAuditing.Size = new System.Drawing.Size(94, 28);
            this.m_cmdExitAuditing.TabIndex = 10009;
            this.m_cmdExitAuditing.Text = "退审(&R)";
            this.m_cmdExitAuditing.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdExitAuditing.UseVisualStyleBackColor = true;
            this.m_cmdExitAuditing.Click += new System.EventHandler(this.m_cmdExitAuditing_Click);
            // 
            // m_cmdExport
            // 
            this.m_cmdExport.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdExport.ImageIndex = 7;
            this.m_cmdExport.ImageList = this.imageList1;
            this.m_cmdExport.Location = new System.Drawing.Point(722, 4);
            this.m_cmdExport.Name = "m_cmdExport";
            this.m_cmdExport.Size = new System.Drawing.Size(89, 28);
            this.m_cmdExport.TabIndex = 50;
            this.m_cmdExport.Text = "导出(&E)";
            this.m_cmdExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdExport.UseVisualStyleBackColor = true;
            this.m_cmdExport.Click += new System.EventHandler(this.m_cmdExport_Click);
            // 
            // m_dgvtxtMedicineCode
            // 
            this.m_dgvtxtMedicineCode.DataPropertyName = "MedicineCode";
            this.m_dgvtxtMedicineCode.HeaderText = "代码";
            this.m_dgvtxtMedicineCode.Name = "m_dgvtxtMedicineCode";
            // 
            // m_dgvtxtMedicineName
            // 
            this.m_dgvtxtMedicineName.DataPropertyName = "MedicineName";
            this.m_dgvtxtMedicineName.HeaderText = "药品名称";
            this.m_dgvtxtMedicineName.Name = "m_dgvtxtMedicineName";
            this.m_dgvtxtMedicineName.ReadOnly = true;
            this.m_dgvtxtMedicineName.Width = 150;
            // 
            // m_dgvtxtMedicineSpec
            // 
            this.m_dgvtxtMedicineSpec.DataPropertyName = "MedicineSpec";
            this.m_dgvtxtMedicineSpec.HeaderText = "规格";
            this.m_dgvtxtMedicineSpec.Name = "m_dgvtxtMedicineSpec";
            this.m_dgvtxtMedicineSpec.ReadOnly = true;
            // 
            // m_dgvtxtStoreAmount
            // 
            this.m_dgvtxtStoreAmount.DataPropertyName = "StoreAmount";
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.m_dgvtxtStoreAmount.DefaultCellStyle = dataGridViewCellStyle1;
            this.m_dgvtxtStoreAmount.HeaderText = "库存数量";
            this.m_dgvtxtStoreAmount.Name = "m_dgvtxtStoreAmount";
            this.m_dgvtxtStoreAmount.Width = 90;
            // 
            // m_dgvtxtMedicineUnit
            // 
            this.m_dgvtxtMedicineUnit.DataPropertyName = "MedicineUnit";
            this.m_dgvtxtMedicineUnit.HeaderText = "单位";
            this.m_dgvtxtMedicineUnit.Name = "m_dgvtxtMedicineUnit";
            this.m_dgvtxtMedicineUnit.ReadOnly = true;
            this.m_dgvtxtMedicineUnit.Width = 60;
            // 
            // m_dgvtxtBatchNumber
            // 
            this.m_dgvtxtBatchNumber.DataPropertyName = "BatchNumber";
            this.m_dgvtxtBatchNumber.HeaderText = "批号";
            this.m_dgvtxtBatchNumber.MaxInputLength = 10;
            this.m_dgvtxtBatchNumber.Name = "m_dgvtxtBatchNumber";
            this.m_dgvtxtBatchNumber.Width = 80;
            // 
            // m_dgvtxtBugUnitPrice
            // 
            this.m_dgvtxtBugUnitPrice.DataPropertyName = "BugUnitPrice";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N4";
            dataGridViewCellStyle2.NullValue = null;
            this.m_dgvtxtBugUnitPrice.DefaultCellStyle = dataGridViewCellStyle2;
            this.m_dgvtxtBugUnitPrice.HeaderText = "购入单价";
            this.m_dgvtxtBugUnitPrice.Name = "m_dgvtxtBugUnitPrice";
            this.m_dgvtxtBugUnitPrice.Width = 90;
            // 
            // m_dgvtxtWholeSaleUnitPrice
            // 
            this.m_dgvtxtWholeSaleUnitPrice.DataPropertyName = "WholeSaleUnitPrice";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N4";
            dataGridViewCellStyle3.NullValue = null;
            this.m_dgvtxtWholeSaleUnitPrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.m_dgvtxtWholeSaleUnitPrice.HeaderText = "批发单价";
            this.m_dgvtxtWholeSaleUnitPrice.Name = "m_dgvtxtWholeSaleUnitPrice";
            this.m_dgvtxtWholeSaleUnitPrice.Width = 90;
            // 
            // m_dgvtxtSaleUnitPrice
            // 
            this.m_dgvtxtSaleUnitPrice.DataPropertyName = "SaleUnitPrice";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N4";
            dataGridViewCellStyle4.NullValue = null;
            this.m_dgvtxtSaleUnitPrice.DefaultCellStyle = dataGridViewCellStyle4;
            this.m_dgvtxtSaleUnitPrice.HeaderText = "零售单价";
            this.m_dgvtxtSaleUnitPrice.Name = "m_dgvtxtSaleUnitPrice";
            this.m_dgvtxtSaleUnitPrice.Width = 90;
            // 
            // m_dgvtxtValidity
            // 
            this.m_dgvtxtValidity.DataPropertyName = "Validity";
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.m_dgvtxtValidity.DefaultCellStyle = dataGridViewCellStyle5;
            this.m_dgvtxtValidity.HeaderText = "有效期";
            this.m_dgvtxtValidity.Name = "m_dgvtxtValidity";
            // 
            // m_dgvtxtSupplierName
            // 
            this.m_dgvtxtSupplierName.DataPropertyName = "SupplierName";
            this.m_dgvtxtSupplierName.HeaderText = "供应商";
            this.m_dgvtxtSupplierName.Name = "m_dgvtxtSupplierName";
            // 
            // m_dgvtxtManufacturer
            // 
            this.m_dgvtxtManufacturer.DataPropertyName = "Manufacturer";
            this.m_dgvtxtManufacturer.HeaderText = "生产厂家";
            this.m_dgvtxtManufacturer.Name = "m_dgvtxtManufacturer";
            this.m_dgvtxtManufacturer.ReadOnly = true;
            // 
            // m_dgvtxtCreater
            // 
            this.m_dgvtxtCreater.DataPropertyName = "creatername";
            this.m_dgvtxtCreater.HeaderText = "创建者";
            this.m_dgvtxtCreater.Name = "m_dgvtxtCreater";
            this.m_dgvtxtCreater.ReadOnly = true;
            // 
            // m_dgvtxExamer
            // 
            this.m_dgvtxExamer.DataPropertyName = "examername";
            this.m_dgvtxExamer.HeaderText = "审核者";
            this.m_dgvtxExamer.Name = "m_dgvtxExamer";
            this.m_dgvtxExamer.ReadOnly = true;
            // 
            // m_dgvtxtStatus
            // 
            this.m_dgvtxtStatus.DataPropertyName = "status";
            this.m_dgvtxtStatus.HeaderText = "状态";
            this.m_dgvtxtStatus.Name = "m_dgvtxtStatus";
            this.m_dgvtxtStatus.ReadOnly = true;
            this.m_dgvtxtStatus.Width = 80;
            // 
            // frmInventoryRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 491);
            this.Controls.Add(this.m_cmdInAccount);
            this.Controls.Add(this.m_cmdExitAuditing);
            this.Controls.Add(this.m_lblAllRetailMoney);
            this.Controls.Add(this.m_lblAllWholeSaleMoney);
            this.Controls.Add(this.m_lblAllInMoney);
            this.Controls.Add(this.m_lblAllRetailMoneyTitle);
            this.Controls.Add(this.m_lblAllWholeSaleMoneyTitle);
            this.Controls.Add(this.m_lblAllInMoneyTitle);
            this.Controls.Add(this.m_cmdExport);
            this.Controls.Add(this.m_cmdPrint);
            this.Controls.Add(this.m_cmdCommit);
            this.Controls.Add(this.m_cmdRefresh);
            this.Controls.Add(this.m_txtCommitMan);
            this.Controls.Add(this.m_txtInputMan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_txtMedicineID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_pnlWaiting);
            this.Controls.Add(this.m_cmdClose);
            this.Controls.Add(this.m_cmdDelete);
            this.Controls.Add(this.m_cmdInsert);
            this.Controls.Add(this.m_cmdSave);
            this.Controls.Add(this.m_dtgvMedicineDetail);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInventoryRecord";
            this.Text = "原始库存初始化";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmInventoryRecord_FormClosing);
            this.m_pnlWaiting.ResumeLayout(false);
            this.m_pnlWaiting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgvMedicineDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_cmdSave;
        private System.Windows.Forms.Button m_cmdInsert;
        private System.Windows.Forms.Button m_cmdDelete;
        private System.Windows.Forms.Button m_cmdClose;
        private System.ComponentModel.BackgroundWorker m_bgwGetMedicineDetail;
        internal com.digitalwave.controls.MedicineStoreControls.ctlDataGridView_EnterAsTab m_dtgvMedicineDetail;
        private System.Windows.Forms.Panel m_pnlWaiting;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox m_txtMedicineID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox m_txtInputMan;
        internal System.Windows.Forms.TextBox m_txtCommitMan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button m_cmdRefresh;
        private System.Windows.Forms.Button m_cmdCommit;
        internal System.Windows.Forms.ComboBox m_cboCommitInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button m_cmdPrint;
        internal System.Windows.Forms.Label m_lblAllInMoneyTitle;
        internal System.Windows.Forms.Label m_lblAllInMoney;
        internal System.Windows.Forms.Label m_lblAllWholeSaleMoneyTitle;
        internal System.Windows.Forms.Label m_lblAllWholeSaleMoney;
        internal System.Windows.Forms.Label m_lblAllRetailMoneyTitle;
        internal System.Windows.Forms.Label m_lblAllRetailMoney;
        private System.ComponentModel.BackgroundWorker m_bgwCommit;
        private System.Windows.Forms.Button m_cmdInAccount;
        private System.Windows.Forms.Button m_cmdExitAuditing;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button m_cmdExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtStoreAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtBatchNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtBugUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtWholeSaleUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtSaleUnitPrice;
        private com.digitalwave.controls.MedicineStoreControls.DataGridViewCalendarColumn m_dgvtxtValidity;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtSupplierName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtManufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtCreater;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxExamer;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtStatus;
    }
}