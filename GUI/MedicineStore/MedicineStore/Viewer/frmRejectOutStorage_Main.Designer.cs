namespace com.digitalwave.iCare.gui.MedicineStore
{
    partial class frmRejectOutStorage_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRejectOutStorage_Main));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.m_cmdDelete = new System.Windows.Forms.Button();
            this.m_cmdNewMake = new System.Windows.Forms.Button();
            this.m_cmdExit = new System.Windows.Forms.Button();
            this.m_cmdOutAccount = new System.Windows.Forms.Button();
            this.m_cmdInAccount = new System.Windows.Forms.Button();
            this.m_cmdExitAuditing = new System.Windows.Forms.Button();
            this.m_cmdModify = new System.Windows.Forms.Button();
            this.m_cmdAuditing = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.m_cboStatusPage1 = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.m_txtAskIDPage1 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.m_cmdSearch = new System.Windows.Forms.Button();
            this.m_dtpEndDatePage1 = new com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab(this.components);
            this.m_dtpBeginDatePage1 = new com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab(this.components);
            this.label27 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_lblRetailMoney = new System.Windows.Forms.Label();
            this.m_lblBuyInMoney = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.m_lblSelectAllPage1 = new System.Windows.Forms.Label();
            this.m_dgvMainInfo = new System.Windows.Forms.DataGridView();
            this.m_dgvchkCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.m_dgvtxtOutStorageID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtRejectDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtCreatorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtExamerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_lblWholeSaleSubMoney = new System.Windows.Forms.Label();
            this.m_lblBuyInSubMoney = new System.Windows.Forms.Label();
            this.m_lblRetailSubMoney = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.m_dgvSubInfo = new System.Windows.Forms.DataGridView();
            this.m_dgvtxtSortNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedicineNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedicineName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedicineSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtLotNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtRealGross = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtRejectAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtRejectReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtInStorageID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtInStorageDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_bgwGetData = new System.ComponentModel.BackgroundWorker();
            this.m_bgwCommit = new System.ComponentModel.BackgroundWorker();
            this.m_pnlWaiting = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel4.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvMainInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvSubInfo)).BeginInit();
            this.m_pnlWaiting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            // m_cmdDelete
            // 
            this.m_cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdDelete.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdDelete.ImageIndex = 2;
            this.m_cmdDelete.ImageList = this.imageList1;
            this.m_cmdDelete.Location = new System.Drawing.Point(192, 4);
            this.m_cmdDelete.Name = "m_cmdDelete";
            this.m_cmdDelete.Size = new System.Drawing.Size(94, 28);
            this.m_cmdDelete.TabIndex = 98;
            this.m_cmdDelete.Text = "删除(&D)";
            this.m_cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdDelete.UseVisualStyleBackColor = true;
            this.m_cmdDelete.Click += new System.EventHandler(this.m_cmdDelete_Click);
            // 
            // m_cmdNewMake
            // 
            this.m_cmdNewMake.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdNewMake.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdNewMake.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdNewMake.ImageIndex = 9;
            this.m_cmdNewMake.ImageList = this.imageList1;
            this.m_cmdNewMake.Location = new System.Drawing.Point(6, 4);
            this.m_cmdNewMake.Name = "m_cmdNewMake";
            this.m_cmdNewMake.Size = new System.Drawing.Size(94, 28);
            this.m_cmdNewMake.TabIndex = 96;
            this.m_cmdNewMake.Text = "新制(&A)";
            this.m_cmdNewMake.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdNewMake.UseVisualStyleBackColor = true;
            this.m_cmdNewMake.Click += new System.EventHandler(this.m_cmdNewMake_Click);
            // 
            // m_cmdExit
            // 
            this.m_cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdExit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdExit.ImageIndex = 1;
            this.m_cmdExit.ImageList = this.imageList1;
            this.m_cmdExit.Location = new System.Drawing.Point(926, 4);
            this.m_cmdExit.Name = "m_cmdExit";
            this.m_cmdExit.Size = new System.Drawing.Size(94, 28);
            this.m_cmdExit.TabIndex = 103;
            this.m_cmdExit.Text = "退出(&Q)";
            this.m_cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdExit.UseVisualStyleBackColor = true;
            this.m_cmdExit.Click += new System.EventHandler(this.m_cmdExit_Click);
            // 
            // m_cmdOutAccount
            // 
            this.m_cmdOutAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdOutAccount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdOutAccount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdOutAccount.ImageIndex = 12;
            this.m_cmdOutAccount.ImageList = this.imageList1;
            this.m_cmdOutAccount.Location = new System.Drawing.Point(564, 4);
            this.m_cmdOutAccount.Name = "m_cmdOutAccount";
            this.m_cmdOutAccount.Size = new System.Drawing.Size(94, 28);
            this.m_cmdOutAccount.TabIndex = 102;
            this.m_cmdOutAccount.Text = "退帐(&O)";
            this.m_cmdOutAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdOutAccount.UseVisualStyleBackColor = true;
            this.m_cmdOutAccount.Visible = false;
            this.m_cmdOutAccount.Click += new System.EventHandler(this.m_cmdOutAccount_Click);
            // 
            // m_cmdInAccount
            // 
            this.m_cmdInAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdInAccount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdInAccount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdInAccount.ImageIndex = 11;
            this.m_cmdInAccount.ImageList = this.imageList1;
            this.m_cmdInAccount.Location = new System.Drawing.Point(471, 4);
            this.m_cmdInAccount.Name = "m_cmdInAccount";
            this.m_cmdInAccount.Size = new System.Drawing.Size(94, 28);
            this.m_cmdInAccount.TabIndex = 101;
            this.m_cmdInAccount.Text = "入帐(&I)";
            this.m_cmdInAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdInAccount.UseVisualStyleBackColor = true;
            this.m_cmdInAccount.Click += new System.EventHandler(this.m_cmdInAccount_Click);
            // 
            // m_cmdExitAuditing
            // 
            this.m_cmdExitAuditing.Enabled = false;
            this.m_cmdExitAuditing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdExitAuditing.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdExitAuditing.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdExitAuditing.ImageIndex = 10;
            this.m_cmdExitAuditing.ImageList = this.imageList1;
            this.m_cmdExitAuditing.Location = new System.Drawing.Point(378, 4);
            this.m_cmdExitAuditing.Name = "m_cmdExitAuditing";
            this.m_cmdExitAuditing.Size = new System.Drawing.Size(94, 28);
            this.m_cmdExitAuditing.TabIndex = 100;
            this.m_cmdExitAuditing.Text = "退审(&R)";
            this.m_cmdExitAuditing.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdExitAuditing.UseVisualStyleBackColor = true;
            this.m_cmdExitAuditing.Click += new System.EventHandler(this.m_cmdExitAuditing_Click);
            // 
            // m_cmdModify
            // 
            this.m_cmdModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdModify.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdModify.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdModify.ImageIndex = 3;
            this.m_cmdModify.ImageList = this.imageList1;
            this.m_cmdModify.Location = new System.Drawing.Point(99, 4);
            this.m_cmdModify.Name = "m_cmdModify";
            this.m_cmdModify.Size = new System.Drawing.Size(94, 28);
            this.m_cmdModify.TabIndex = 97;
            this.m_cmdModify.Text = "修改(&C)";
            this.m_cmdModify.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdModify.UseVisualStyleBackColor = true;
            this.m_cmdModify.Click += new System.EventHandler(this.m_cmdModify_Click);
            // 
            // m_cmdAuditing
            // 
            this.m_cmdAuditing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdAuditing.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdAuditing.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdAuditing.ImageIndex = 4;
            this.m_cmdAuditing.ImageList = this.imageList1;
            this.m_cmdAuditing.Location = new System.Drawing.Point(285, 4);
            this.m_cmdAuditing.Name = "m_cmdAuditing";
            this.m_cmdAuditing.Size = new System.Drawing.Size(94, 28);
            this.m_cmdAuditing.TabIndex = 99;
            this.m_cmdAuditing.Text = "审核(&E)";
            this.m_cmdAuditing.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdAuditing.UseVisualStyleBackColor = true;
            this.m_cmdAuditing.Click += new System.EventHandler(this.m_cmdAuditing_Click);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.m_cboStatusPage1);
            this.panel4.Controls.Add(this.label22);
            this.panel4.Controls.Add(this.m_txtAskIDPage1);
            this.panel4.Controls.Add(this.label24);
            this.panel4.Controls.Add(this.label25);
            this.panel4.Controls.Add(this.m_cmdSearch);
            this.panel4.Controls.Add(this.m_dtpEndDatePage1);
            this.panel4.Controls.Add(this.m_dtpBeginDatePage1);
            this.panel4.Controls.Add(this.label27);
            this.panel4.Location = new System.Drawing.Point(1, 37);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1025, 41);
            this.panel4.TabIndex = 10005;
            // 
            // m_cboStatusPage1
            // 
            this.m_cboStatusPage1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboStatusPage1.FormattingEnabled = true;
            this.m_cboStatusPage1.Items.AddRange(new object[] {
            "全部",
            "新制",
            "审核",
            "入帐"});
            this.m_cboStatusPage1.Location = new System.Drawing.Point(681, 8);
            this.m_cboStatusPage1.Name = "m_cboStatusPage1";
            this.m_cboStatusPage1.Size = new System.Drawing.Size(135, 22);
            this.m_cboStatusPage1.TabIndex = 30;
            this.m_cboStatusPage1.SelectedIndexChanged += new System.EventHandler(this.m_cboStatusPage1_SelectedIndexChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(643, 12);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(35, 14);
            this.label22.TabIndex = 98;
            this.label22.Text = "状态";
            // 
            // m_txtAskIDPage1
            // 
            this.m_txtAskIDPage1.Location = new System.Drawing.Point(445, 8);
            this.m_txtAskIDPage1.Name = "m_txtAskIDPage1";
            this.m_txtAskIDPage1.Size = new System.Drawing.Size(168, 23);
            this.m_txtAskIDPage1.TabIndex = 40;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(380, 12);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(63, 14);
            this.label24.TabIndex = 96;
            this.label24.Text = "报废单号";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(2, 12);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(63, 14);
            this.label25.TabIndex = 1;
            this.label25.Text = "出库时间";
            // 
            // m_cmdSearch
            // 
            this.m_cmdSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdSearch.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdSearch.ImageIndex = 13;
            this.m_cmdSearch.ImageList = this.imageList1;
            this.m_cmdSearch.Location = new System.Drawing.Point(940, 2);
            this.m_cmdSearch.Name = "m_cmdSearch";
            this.m_cmdSearch.Size = new System.Drawing.Size(73, 32);
            this.m_cmdSearch.TabIndex = 95;
            this.m_cmdSearch.Text = "查询";
            this.m_cmdSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdSearch.UseVisualStyleBackColor = true;
            this.m_cmdSearch.Click += new System.EventHandler(this.m_cmdSearch_Click);
            // 
            // m_dtpEndDatePage1
            // 
            this.m_dtpEndDatePage1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_dtpEndDatePage1.Location = new System.Drawing.Point(220, 8);
            this.m_dtpEndDatePage1.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日;
            this.m_dtpEndDatePage1.Mask = "0000年90月90日";
            this.m_dtpEndDatePage1.Name = "m_dtpEndDatePage1";
            this.m_dtpEndDatePage1.Size = new System.Drawing.Size(130, 23);
            this.m_dtpEndDatePage1.TabIndex = 15;
            this.m_dtpEndDatePage1.ValidatingType = typeof(System.DateTime);
            // 
            // m_dtpBeginDatePage1
            // 
            this.m_dtpBeginDatePage1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_dtpBeginDatePage1.Location = new System.Drawing.Point(67, 8);
            this.m_dtpBeginDatePage1.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日;
            this.m_dtpBeginDatePage1.Mask = "0000年90月90日";
            this.m_dtpBeginDatePage1.Name = "m_dtpBeginDatePage1";
            this.m_dtpBeginDatePage1.Size = new System.Drawing.Size(130, 23);
            this.m_dtpBeginDatePage1.TabIndex = 10;
            this.m_dtpBeginDatePage1.ValidatingType = typeof(System.DateTime);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(200, 18);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(14, 14);
            this.label27.TabIndex = 7;
            this.label27.Text = "~";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(4, 86);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.m_lblRetailMoney);
            this.splitContainer1.Panel1.Controls.Add(this.m_lblBuyInMoney);
            this.splitContainer1.Panel1.Controls.Add(this.label12);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.m_lblSelectAllPage1);
            this.splitContainer1.Panel1.Controls.Add(this.m_dgvMainInfo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.m_lblWholeSaleSubMoney);
            this.splitContainer1.Panel2.Controls.Add(this.m_lblBuyInSubMoney);
            this.splitContainer1.Panel2.Controls.Add(this.m_lblRetailSubMoney);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.label9);
            this.splitContainer1.Panel2.Controls.Add(this.label13);
            this.splitContainer1.Panel2.Controls.Add(this.m_dgvSubInfo);
            this.splitContainer1.Size = new System.Drawing.Size(1019, 538);
            this.splitContainer1.SplitterDistance = 396;
            this.splitContainer1.TabIndex = 10006;
            // 
            // m_lblRetailMoney
            // 
            this.m_lblRetailMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lblRetailMoney.BackColor = System.Drawing.SystemColors.Control;
            this.m_lblRetailMoney.ForeColor = System.Drawing.Color.Red;
            this.m_lblRetailMoney.Location = new System.Drawing.Point(265, 521);
            this.m_lblRetailMoney.Name = "m_lblRetailMoney";
            this.m_lblRetailMoney.Size = new System.Drawing.Size(97, 14);
            this.m_lblRetailMoney.TabIndex = 10011;
            // 
            // m_lblBuyInMoney
            // 
            this.m_lblBuyInMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lblBuyInMoney.BackColor = System.Drawing.SystemColors.Control;
            this.m_lblBuyInMoney.ForeColor = System.Drawing.Color.Red;
            this.m_lblBuyInMoney.Location = new System.Drawing.Point(97, 521);
            this.m_lblBuyInMoney.Name = "m_lblBuyInMoney";
            this.m_lblBuyInMoney.Size = new System.Drawing.Size(97, 14);
            this.m_lblBuyInMoney.TabIndex = 10012;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(195, 521);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 14);
            this.label12.TabIndex = 10009;
            this.label12.Text = "零售金额￥";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(26, 521);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 14);
            this.label10.TabIndex = 10010;
            this.label10.Text = "购入金额￥";
            // 
            // m_lblSelectAllPage1
            // 
            this.m_lblSelectAllPage1.Font = new System.Drawing.Font("宋体", 9F);
            this.m_lblSelectAllPage1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.m_lblSelectAllPage1.Location = new System.Drawing.Point(8, 3);
            this.m_lblSelectAllPage1.Name = "m_lblSelectAllPage1";
            this.m_lblSelectAllPage1.Size = new System.Drawing.Size(20, 25);
            this.m_lblSelectAllPage1.TabIndex = 10004;
            this.m_lblSelectAllPage1.Text = "全选";
            this.m_lblSelectAllPage1.Click += new System.EventHandler(this.m_lblSelectAllPage1_Click);
            // 
            // m_dgvMainInfo
            // 
            this.m_dgvMainInfo.AllowUserToAddRows = false;
            this.m_dgvMainInfo.AllowUserToDeleteRows = false;
            this.m_dgvMainInfo.AllowUserToResizeRows = false;
            this.m_dgvMainInfo.ColumnHeadersHeight = 30;
            this.m_dgvMainInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_dgvchkCheck,
            this.m_dgvtxtOutStorageID,
            this.m_dgvtxtStatus,
            this.m_dgvtxtRejectDate,
            this.m_dgvtxtCreatorName,
            this.m_dgvtxtExamerName});
            this.m_dgvMainInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvMainInfo.Location = new System.Drawing.Point(0, 0);
            this.m_dgvMainInfo.Name = "m_dgvMainInfo";
            this.m_dgvMainInfo.RowHeadersVisible = false;
            this.m_dgvMainInfo.RowTemplate.Height = 23;
            this.m_dgvMainInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvMainInfo.Size = new System.Drawing.Size(396, 538);
            this.m_dgvMainInfo.TabIndex = 0;
            this.m_dgvMainInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvMainInfo_CellDoubleClick);
            this.m_dgvMainInfo.CurrentCellChanged += new System.EventHandler(this.m_dgvMainInfo_CurrentCellChanged);
            // 
            // m_dgvchkCheck
            // 
            this.m_dgvchkCheck.HeaderText = "";
            this.m_dgvchkCheck.Name = "m_dgvchkCheck";
            this.m_dgvchkCheck.Width = 30;
            // 
            // m_dgvtxtOutStorageID
            // 
            this.m_dgvtxtOutStorageID.DataPropertyName = "OUTSTORAGEID_VCHR";
            this.m_dgvtxtOutStorageID.HeaderText = "单据号";
            this.m_dgvtxtOutStorageID.Name = "m_dgvtxtOutStorageID";
            this.m_dgvtxtOutStorageID.ReadOnly = true;
            // 
            // m_dgvtxtStatus
            // 
            this.m_dgvtxtStatus.DataPropertyName = "statusdesc";
            this.m_dgvtxtStatus.HeaderText = "状态";
            this.m_dgvtxtStatus.Name = "m_dgvtxtStatus";
            this.m_dgvtxtStatus.ReadOnly = true;
            this.m_dgvtxtStatus.Width = 60;
            // 
            // m_dgvtxtRejectDate
            // 
            this.m_dgvtxtRejectDate.DataPropertyName = "outstoragedate_dat";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.m_dgvtxtRejectDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.m_dgvtxtRejectDate.HeaderText = "报废时间";
            this.m_dgvtxtRejectDate.Name = "m_dgvtxtRejectDate";
            this.m_dgvtxtRejectDate.ReadOnly = true;
            // 
            // m_dgvtxtCreatorName
            // 
            this.m_dgvtxtCreatorName.DataPropertyName = "askername";
            this.m_dgvtxtCreatorName.HeaderText = "制单人";
            this.m_dgvtxtCreatorName.Name = "m_dgvtxtCreatorName";
            this.m_dgvtxtCreatorName.ReadOnly = true;
            // 
            // m_dgvtxtExamerName
            // 
            this.m_dgvtxtExamerName.DataPropertyName = "examername";
            this.m_dgvtxtExamerName.HeaderText = "审核人";
            this.m_dgvtxtExamerName.Name = "m_dgvtxtExamerName";
            this.m_dgvtxtExamerName.ReadOnly = true;
            // 
            // m_lblWholeSaleSubMoney
            // 
            this.m_lblWholeSaleSubMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblWholeSaleSubMoney.BackColor = System.Drawing.SystemColors.Control;
            this.m_lblWholeSaleSubMoney.ForeColor = System.Drawing.Color.Red;
            this.m_lblWholeSaleSubMoney.Location = new System.Drawing.Point(314, 521);
            this.m_lblWholeSaleSubMoney.Name = "m_lblWholeSaleSubMoney";
            this.m_lblWholeSaleSubMoney.Size = new System.Drawing.Size(97, 14);
            this.m_lblWholeSaleSubMoney.TabIndex = 10014;
            // 
            // m_lblBuyInSubMoney
            // 
            this.m_lblBuyInSubMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblBuyInSubMoney.BackColor = System.Drawing.SystemColors.Control;
            this.m_lblBuyInSubMoney.ForeColor = System.Drawing.Color.Red;
            this.m_lblBuyInSubMoney.Location = new System.Drawing.Point(140, 521);
            this.m_lblBuyInSubMoney.Name = "m_lblBuyInSubMoney";
            this.m_lblBuyInSubMoney.Size = new System.Drawing.Size(97, 14);
            this.m_lblBuyInSubMoney.TabIndex = 10015;
            // 
            // m_lblRetailSubMoney
            // 
            this.m_lblRetailSubMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblRetailSubMoney.BackColor = System.Drawing.SystemColors.Control;
            this.m_lblRetailSubMoney.ForeColor = System.Drawing.Color.Red;
            this.m_lblRetailSubMoney.Location = new System.Drawing.Point(489, 521);
            this.m_lblRetailSubMoney.Name = "m_lblRetailSubMoney";
            this.m_lblRetailSubMoney.Size = new System.Drawing.Size(97, 14);
            this.m_lblRetailSubMoney.TabIndex = 10016;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(237, 521);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 14);
            this.label7.TabIndex = 10011;
            this.label7.Text = "批发金额￥";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(413, 521);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 14);
            this.label9.TabIndex = 10012;
            this.label9.Text = "零售金额￥";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.BackColor = System.Drawing.SystemColors.Control;
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(65, 521);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 14);
            this.label13.TabIndex = 10013;
            this.label13.Text = "购入金额￥";
            // 
            // m_dgvSubInfo
            // 
            this.m_dgvSubInfo.AllowUserToAddRows = false;
            this.m_dgvSubInfo.AllowUserToDeleteRows = false;
            this.m_dgvSubInfo.AllowUserToResizeRows = false;
            this.m_dgvSubInfo.ColumnHeadersHeight = 30;
            this.m_dgvSubInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_dgvtxtSortNum,
            this.m_dgvtxtMedicineNO,
            this.m_dgvtxtMedicineName,
            this.m_dgvtxtMedicineSpec,
            this.m_dgvtxtLotNO,
            this.m_dgvtxtRealGross,
            this.m_dgvtxtRejectAmount,
            this.m_dgvtxtUnit,
            this.m_dgvtxtRejectReason,
            this.m_dgvtxtInStorageID,
            this.m_dgvtxtInStorageDate});
            this.m_dgvSubInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvSubInfo.Location = new System.Drawing.Point(0, 0);
            this.m_dgvSubInfo.Name = "m_dgvSubInfo";
            this.m_dgvSubInfo.RowHeadersVisible = false;
            this.m_dgvSubInfo.RowTemplate.Height = 23;
            this.m_dgvSubInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvSubInfo.Size = new System.Drawing.Size(619, 538);
            this.m_dgvSubInfo.TabIndex = 0;
            this.m_dgvSubInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvSubInfo_CellDoubleClick);
            this.m_dgvSubInfo.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.m_dgvSubInfo_RowPrePaint);
            this.m_dgvSubInfo.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.m_dgvSubInfo_RowsAdded);
            this.m_dgvSubInfo.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.m_dgvSubInfo_RowsRemoved);
            // 
            // m_dgvtxtSortNum
            // 
            this.m_dgvtxtSortNum.HeaderText = "序号";
            this.m_dgvtxtSortNum.Name = "m_dgvtxtSortNum";
            this.m_dgvtxtSortNum.ReadOnly = true;
            this.m_dgvtxtSortNum.Width = 50;
            // 
            // m_dgvtxtMedicineNO
            // 
            this.m_dgvtxtMedicineNO.DataPropertyName = "assistcode_chr";
            this.m_dgvtxtMedicineNO.HeaderText = "药品代码";
            this.m_dgvtxtMedicineNO.Name = "m_dgvtxtMedicineNO";
            this.m_dgvtxtMedicineNO.ReadOnly = true;
            this.m_dgvtxtMedicineNO.Width = 80;
            // 
            // m_dgvtxtMedicineName
            // 
            this.m_dgvtxtMedicineName.DataPropertyName = "MEDICINENAME_VCH";
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
            this.m_dgvtxtMedicineSpec.Width = 80;
            // 
            // m_dgvtxtLotNO
            // 
            this.m_dgvtxtLotNO.DataPropertyName = "LOTNO_VCHR";
            this.m_dgvtxtLotNO.HeaderText = "批号";
            this.m_dgvtxtLotNO.Name = "m_dgvtxtLotNO";
            this.m_dgvtxtLotNO.ReadOnly = true;
            this.m_dgvtxtLotNO.Width = 80;
            // 
            // m_dgvtxtRealGross
            // 
            this.m_dgvtxtRealGross.DataPropertyName = "realgross_int";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.m_dgvtxtRealGross.DefaultCellStyle = dataGridViewCellStyle2;
            this.m_dgvtxtRealGross.HeaderText = "实际库存量";
            this.m_dgvtxtRealGross.Name = "m_dgvtxtRealGross";
            this.m_dgvtxtRealGross.ReadOnly = true;
            // 
            // m_dgvtxtRejectAmount
            // 
            this.m_dgvtxtRejectAmount.DataPropertyName = "NETAMOUNT_INT";
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.m_dgvtxtRejectAmount.DefaultCellStyle = dataGridViewCellStyle3;
            this.m_dgvtxtRejectAmount.HeaderText = "报废数量";
            this.m_dgvtxtRejectAmount.Name = "m_dgvtxtRejectAmount";
            this.m_dgvtxtRejectAmount.ReadOnly = true;
            // 
            // m_dgvtxtUnit
            // 
            this.m_dgvtxtUnit.DataPropertyName = "OPUNIT_CHR";
            this.m_dgvtxtUnit.HeaderText = "单位";
            this.m_dgvtxtUnit.Name = "m_dgvtxtUnit";
            this.m_dgvtxtUnit.ReadOnly = true;
            this.m_dgvtxtUnit.Width = 60;
            // 
            // m_dgvtxtRejectReason
            // 
            this.m_dgvtxtRejectReason.DataPropertyName = "rejectreason";
            this.m_dgvtxtRejectReason.HeaderText = "报废原因";
            this.m_dgvtxtRejectReason.Name = "m_dgvtxtRejectReason";
            this.m_dgvtxtRejectReason.ReadOnly = true;
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
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.m_dgvtxtInStorageDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.m_dgvtxtInStorageDate.HeaderText = "入库日期";
            this.m_dgvtxtInStorageDate.Name = "m_dgvtxtInStorageDate";
            this.m_dgvtxtInStorageDate.ReadOnly = true;
            // 
            // m_bgwGetData
            // 
            this.m_bgwGetData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.m_bgwGetData_DoWork);
            this.m_bgwGetData.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.m_bgwGetData_RunWorkerCompleted);
            // 
            // m_pnlWaiting
            // 
            this.m_pnlWaiting.BackColor = System.Drawing.SystemColors.Control;
            this.m_pnlWaiting.Controls.Add(this.label14);
            this.m_pnlWaiting.Controls.Add(this.pictureBox1);
            this.m_pnlWaiting.Location = new System.Drawing.Point(361, 282);
            this.m_pnlWaiting.Name = "m_pnlWaiting";
            this.m_pnlWaiting.Size = new System.Drawing.Size(307, 71);
            this.m_pnlWaiting.TabIndex = 10007;
            this.m_pnlWaiting.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label14.Location = new System.Drawing.Point(86, 28);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(189, 14);
            this.label14.TabIndex = 1;
            this.label14.Text = "正在审核，请稍候..........";
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
            // frmRejectOutStorage_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 634);
            this.Controls.Add(this.m_pnlWaiting);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.m_cmdDelete);
            this.Controls.Add(this.m_cmdNewMake);
            this.Controls.Add(this.m_cmdExit);
            this.Controls.Add(this.m_cmdOutAccount);
            this.Controls.Add(this.m_cmdInAccount);
            this.Controls.Add(this.m_cmdExitAuditing);
            this.Controls.Add(this.m_cmdModify);
            this.Controls.Add(this.m_cmdAuditing);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRejectOutStorage_Main";
            this.Text = "报废出库";
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvMainInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvSubInfo)).EndInit();
            this.m_pnlWaiting.ResumeLayout(false);
            this.m_pnlWaiting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button m_cmdDelete;
        private System.Windows.Forms.Button m_cmdNewMake;
        private System.Windows.Forms.Button m_cmdExit;
        private System.Windows.Forms.Button m_cmdOutAccount;
        private System.Windows.Forms.Button m_cmdInAccount;
        private System.Windows.Forms.Button m_cmdExitAuditing;
        private System.Windows.Forms.Button m_cmdModify;
        private System.Windows.Forms.Button m_cmdAuditing;
        internal System.Windows.Forms.Panel panel4;
        internal System.Windows.Forms.ComboBox m_cboStatusPage1;
        private System.Windows.Forms.Label label22;
        internal System.Windows.Forms.TextBox m_txtAskIDPage1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button m_cmdSearch;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab m_dtpEndDatePage1;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab m_dtpBeginDatePage1;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label m_lblSelectAllPage1;
        private System.ComponentModel.BackgroundWorker m_bgwGetData;
        private System.ComponentModel.BackgroundWorker m_bgwCommit;
        private System.Windows.Forms.DataGridViewCheckBoxColumn m_dgvchkCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtOutStorageID;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtRejectDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtCreatorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtExamerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtSortNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtLotNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtRealGross;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtRejectAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtRejectReason;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtInStorageID;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtInStorageDate;
        private System.Windows.Forms.Panel m_pnlWaiting;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.DataGridView m_dgvMainInfo;
        internal System.Windows.Forms.DataGridView m_dgvSubInfo;
        internal System.Windows.Forms.Label m_lblRetailMoney;
        internal System.Windows.Forms.Label m_lblBuyInMoney;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label m_lblWholeSaleSubMoney;
        internal System.Windows.Forms.Label m_lblBuyInSubMoney;
        internal System.Windows.Forms.Label m_lblRetailSubMoney;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
    }
}