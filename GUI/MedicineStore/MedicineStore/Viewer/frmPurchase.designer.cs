namespace com.digitalwave.iCare.gui.MedicineStore
{
    partial class frmPurchase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPurchase));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.m_bgwGetData = new System.ComponentModel.BackgroundWorker();
            this.m_pnlWaiting = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.m_cmdDelete = new System.Windows.Forms.Button();
            this.m_cmdNewMake = new System.Windows.Forms.Button();
            this.m_cmdExit = new System.Windows.Forms.Button();
            this.m_cmdOutAccount = new System.Windows.Forms.Button();
            this.m_cmdInAccount = new System.Windows.Forms.Button();
            this.m_cmdExitAuditing = new System.Windows.Forms.Button();
            this.m_cmdModify = new System.Windows.Forms.Button();
            this.m_cmdAuditing = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_lblRetailMoney = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.m_lblWholeSaleMoney = new System.Windows.Forms.Label();
            this.m_lblBuyInMoney = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.m_lblSelectAll = new System.Windows.Forms.Label();
            this.m_dgvMainInfo = new System.Windows.Forms.DataGridView();
            this.m_dgvchkCommit = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.m_dgvtxtStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvInDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtBillNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtProvider = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtInType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtCreator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtExamer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.m_lblly = new System.Windows.Forms.Label();
            this.m_lblWholeSaleSubMoney = new System.Windows.Forms.Label();
            this.m_lblBuyInSubMoney = new System.Windows.Forms.Label();
            this.m_lblRetailSubMoney = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.m_dgvSubInfo = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_cboInComeType = new com.digitalwave.iCare.gui.HIS.exComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cmdSearch = new System.Windows.Forms.Button();
            this.m_cboDoseType = new System.Windows.Forms.ComboBox();
            this.m_txtProviderName = new System.Windows.Forms.TextBox();
            this.m_txtBillNumber = new System.Windows.Forms.TextBox();
            this.m_txtMedicineName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_cboBillState = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_dtpSearchEndDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab(this.components);
            this.m_dtpSearchBeginDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_tmsShowNewMake = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.入即出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.m_dgvtxtSortNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedicineCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedicineName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dtvtxtMedicineSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCEDATE_DAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoicecode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoicedater = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtInAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedicineUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtLotNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtBuyPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtWholeSalePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtSalePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_pnlWaiting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvMainInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvSubInfo)).BeginInit();
            this.panel1.SuspendLayout();
            this.m_tmsShowNewMake.SuspendLayout();
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
            // m_pnlWaiting
            // 
            this.m_pnlWaiting.BackColor = System.Drawing.SystemColors.Control;
            this.m_pnlWaiting.Controls.Add(this.label14);
            this.m_pnlWaiting.Controls.Add(this.pictureBox1);
            this.m_pnlWaiting.Location = new System.Drawing.Point(363, 282);
            this.m_pnlWaiting.Name = "m_pnlWaiting";
            this.m_pnlWaiting.Size = new System.Drawing.Size(307, 71);
            this.m_pnlWaiting.TabIndex = 10001;
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
            // m_cmdDelete
            // 
            this.m_cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdDelete.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdDelete.ImageIndex = 2;
            this.m_cmdDelete.ImageList = this.imageList1;
            this.m_cmdDelete.Location = new System.Drawing.Point(191, 3);
            this.m_cmdDelete.Name = "m_cmdDelete";
            this.m_cmdDelete.Size = new System.Drawing.Size(94, 28);
            this.m_cmdDelete.TabIndex = 70;
            this.m_cmdDelete.Text = "删除(&D)";
            this.m_cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdDelete.UseVisualStyleBackColor = true;
            this.m_cmdDelete.Click += new System.EventHandler(this.m_cmdDelee_Click);
            // 
            // m_cmdNewMake
            // 
            this.m_cmdNewMake.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdNewMake.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdNewMake.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdNewMake.ImageIndex = 9;
            this.m_cmdNewMake.ImageList = this.imageList1;
            this.m_cmdNewMake.Location = new System.Drawing.Point(3, 3);
            this.m_cmdNewMake.Name = "m_cmdNewMake";
            this.m_cmdNewMake.Size = new System.Drawing.Size(91, 28);
            this.m_cmdNewMake.TabIndex = 60;
            this.m_cmdNewMake.Text = "新制(&A)";
            this.m_cmdNewMake.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdNewMake.UseVisualStyleBackColor = true;
            this.m_cmdNewMake.Click += new System.EventHandler(this.cmdNewMake_Click);
            // 
            // m_cmdExit
            // 
            this.m_cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdExit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdExit.ImageIndex = 1;
            this.m_cmdExit.ImageList = this.imageList1;
            this.m_cmdExit.Location = new System.Drawing.Point(922, 3);
            this.m_cmdExit.Name = "m_cmdExit";
            this.m_cmdExit.Size = new System.Drawing.Size(94, 28);
            this.m_cmdExit.TabIndex = 95;
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
            this.m_cmdOutAccount.Location = new System.Drawing.Point(563, 3);
            this.m_cmdOutAccount.Name = "m_cmdOutAccount";
            this.m_cmdOutAccount.Size = new System.Drawing.Size(94, 28);
            this.m_cmdOutAccount.TabIndex = 90;
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
            this.m_cmdInAccount.Location = new System.Drawing.Point(470, 3);
            this.m_cmdInAccount.Name = "m_cmdInAccount";
            this.m_cmdInAccount.Size = new System.Drawing.Size(94, 28);
            this.m_cmdInAccount.TabIndex = 85;
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
            this.m_cmdExitAuditing.Location = new System.Drawing.Point(377, 3);
            this.m_cmdExitAuditing.Name = "m_cmdExitAuditing";
            this.m_cmdExitAuditing.Size = new System.Drawing.Size(94, 28);
            this.m_cmdExitAuditing.TabIndex = 80;
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
            this.m_cmdModify.Location = new System.Drawing.Point(100, 3);
            this.m_cmdModify.Name = "m_cmdModify";
            this.m_cmdModify.Size = new System.Drawing.Size(96, 28);
            this.m_cmdModify.TabIndex = 65;
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
            this.m_cmdAuditing.Location = new System.Drawing.Point(284, 3);
            this.m_cmdAuditing.Name = "m_cmdAuditing";
            this.m_cmdAuditing.Size = new System.Drawing.Size(94, 28);
            this.m_cmdAuditing.TabIndex = 75;
            this.m_cmdAuditing.Text = "审核(&E)";
            this.m_cmdAuditing.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdAuditing.UseVisualStyleBackColor = true;
            this.m_cmdAuditing.Click += new System.EventHandler(this.m_cmdAuditing_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 105);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.m_lblRetailMoney);
            this.splitContainer1.Panel1.Controls.Add(this.label12);
            this.splitContainer1.Panel1.Controls.Add(this.m_lblWholeSaleMoney);
            this.splitContainer1.Panel1.Controls.Add(this.m_lblBuyInMoney);
            this.splitContainer1.Panel1.Controls.Add(this.label11);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.m_lblSelectAll);
            this.splitContainer1.Panel1.Controls.Add(this.m_dgvMainInfo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label9);
            this.splitContainer1.Panel2.Controls.Add(this.m_lblly);
            this.splitContainer1.Panel2.Controls.Add(this.m_lblWholeSaleSubMoney);
            this.splitContainer1.Panel2.Controls.Add(this.m_lblBuyInSubMoney);
            this.splitContainer1.Panel2.Controls.Add(this.m_lblRetailSubMoney);
            this.splitContainer1.Panel2.Controls.Add(this.label16);
            this.splitContainer1.Panel2.Controls.Add(this.label18);
            this.splitContainer1.Panel2.Controls.Add(this.label13);
            this.splitContainer1.Panel2.Controls.Add(this.m_dgvSubInfo);
            this.splitContainer1.Size = new System.Drawing.Size(1028, 517);
            this.splitContainer1.SplitterDistance = 393;
            this.splitContainer1.TabIndex = 19;
            // 
            // m_lblRetailMoney
            // 
            this.m_lblRetailMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lblRetailMoney.BackColor = System.Drawing.SystemColors.Control;
            this.m_lblRetailMoney.ForeColor = System.Drawing.Color.Red;
            this.m_lblRetailMoney.Location = new System.Drawing.Point(259, 501);
            this.m_lblRetailMoney.Name = "m_lblRetailMoney";
            this.m_lblRetailMoney.Size = new System.Drawing.Size(97, 14);
            this.m_lblRetailMoney.TabIndex = 10004;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(188, 501);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 14);
            this.label12.TabIndex = 10003;
            this.label12.Text = "零售金额￥";
            // 
            // m_lblWholeSaleMoney
            // 
            this.m_lblWholeSaleMoney.BackColor = System.Drawing.SystemColors.Window;
            this.m_lblWholeSaleMoney.ForeColor = System.Drawing.Color.Red;
            this.m_lblWholeSaleMoney.Location = new System.Drawing.Point(279, 442);
            this.m_lblWholeSaleMoney.Name = "m_lblWholeSaleMoney";
            this.m_lblWholeSaleMoney.Size = new System.Drawing.Size(97, 14);
            this.m_lblWholeSaleMoney.TabIndex = 10004;
            this.m_lblWholeSaleMoney.Visible = false;
            // 
            // m_lblBuyInMoney
            // 
            this.m_lblBuyInMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lblBuyInMoney.BackColor = System.Drawing.SystemColors.Control;
            this.m_lblBuyInMoney.ForeColor = System.Drawing.Color.Red;
            this.m_lblBuyInMoney.Location = new System.Drawing.Point(89, 501);
            this.m_lblBuyInMoney.Name = "m_lblBuyInMoney";
            this.m_lblBuyInMoney.Size = new System.Drawing.Size(97, 14);
            this.m_lblBuyInMoney.TabIndex = 10004;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.Window;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(202, 442);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 14);
            this.label11.TabIndex = 10003;
            this.label11.Text = "批发金额￥";
            this.label11.Visible = false;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(19, 501);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 14);
            this.label10.TabIndex = 10003;
            this.label10.Text = "购入金额￥";
            // 
            // m_lblSelectAll
            // 
            this.m_lblSelectAll.Font = new System.Drawing.Font("宋体", 9F);
            this.m_lblSelectAll.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.m_lblSelectAll.Location = new System.Drawing.Point(6, 3);
            this.m_lblSelectAll.Name = "m_lblSelectAll";
            this.m_lblSelectAll.Size = new System.Drawing.Size(20, 25);
            this.m_lblSelectAll.TabIndex = 10002;
            this.m_lblSelectAll.Text = "全选";
            this.m_lblSelectAll.Click += new System.EventHandler(this.m_lblSelectAll_Click);
            // 
            // m_dgvMainInfo
            // 
            this.m_dgvMainInfo.AllowUserToAddRows = false;
            this.m_dgvMainInfo.AllowUserToDeleteRows = false;
            this.m_dgvMainInfo.AllowUserToResizeRows = false;
            this.m_dgvMainInfo.BackgroundColor = System.Drawing.SystemColors.Window;
            this.m_dgvMainInfo.ColumnHeadersHeight = 30;
            this.m_dgvMainInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_dgvchkCommit,
            this.m_dgvtxtStatus,
            this.m_dgvInDate,
            this.m_dgvtxtBillNum,
            this.m_dgvtxtProvider,
            this.m_dgvtxtInType,
            this.m_dgvtxtCreator,
            this.m_dgvtxtExamer});
            this.m_dgvMainInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvMainInfo.Location = new System.Drawing.Point(0, 0);
            this.m_dgvMainInfo.MultiSelect = false;
            this.m_dgvMainInfo.Name = "m_dgvMainInfo";
            this.m_dgvMainInfo.RowHeadersVisible = false;
            this.m_dgvMainInfo.RowTemplate.Height = 23;
            this.m_dgvMainInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvMainInfo.Size = new System.Drawing.Size(393, 517);
            this.m_dgvMainInfo.TabIndex = 50;
            this.m_dgvMainInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvMainInfo_CellDoubleClick);
            this.m_dgvMainInfo.CurrentCellChanged += new System.EventHandler(this.m_dgvMainInfo_CurrentCellChanged);
            // 
            // m_dgvchkCommit
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.NullValue = false;
            this.m_dgvchkCommit.DefaultCellStyle = dataGridViewCellStyle1;
            this.m_dgvchkCommit.Frozen = true;
            this.m_dgvchkCommit.HeaderText = "";
            this.m_dgvchkCommit.Name = "m_dgvchkCommit";
            this.m_dgvchkCommit.Width = 30;
            // 
            // m_dgvtxtStatus
            // 
            this.m_dgvtxtStatus.DataPropertyName = "statedesc";
            this.m_dgvtxtStatus.HeaderText = "状态";
            this.m_dgvtxtStatus.Name = "m_dgvtxtStatus";
            this.m_dgvtxtStatus.ReadOnly = true;
            this.m_dgvtxtStatus.Width = 65;
            // 
            // m_dgvInDate
            // 
            this.m_dgvInDate.DataPropertyName = "INSTORAGEDATE_DAT";
            this.m_dgvInDate.HeaderText = "入库日期";
            this.m_dgvInDate.Name = "m_dgvInDate";
            this.m_dgvInDate.ReadOnly = true;
            // 
            // m_dgvtxtBillNum
            // 
            this.m_dgvtxtBillNum.DataPropertyName = "INSTORAGEID_VCHR";
            this.m_dgvtxtBillNum.HeaderText = "单号";
            this.m_dgvtxtBillNum.Name = "m_dgvtxtBillNum";
            this.m_dgvtxtBillNum.ReadOnly = true;
            // 
            // m_dgvtxtProvider
            // 
            this.m_dgvtxtProvider.DataPropertyName = "vendorname_vchr";
            this.m_dgvtxtProvider.HeaderText = "供应商";
            this.m_dgvtxtProvider.Name = "m_dgvtxtProvider";
            this.m_dgvtxtProvider.ReadOnly = true;
            this.m_dgvtxtProvider.Width = 145;
            // 
            // m_dgvtxtInType
            // 
            this.m_dgvtxtInType.DataPropertyName = "instoragetypedesc";
            this.m_dgvtxtInType.HeaderText = "入库类型";
            this.m_dgvtxtInType.Name = "m_dgvtxtInType";
            this.m_dgvtxtInType.ReadOnly = true;
            this.m_dgvtxtInType.Width = 90;
            // 
            // m_dgvtxtCreator
            // 
            this.m_dgvtxtCreator.DataPropertyName = "makername";
            this.m_dgvtxtCreator.HeaderText = "制单者";
            this.m_dgvtxtCreator.Name = "m_dgvtxtCreator";
            this.m_dgvtxtCreator.ReadOnly = true;
            // 
            // m_dgvtxtExamer
            // 
            this.m_dgvtxtExamer.DataPropertyName = "examername";
            this.m_dgvtxtExamer.HeaderText = "审核人";
            this.m_dgvtxtExamer.Name = "m_dgvtxtExamer";
            this.m_dgvtxtExamer.ReadOnly = true;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(467, 501);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 14);
            this.label9.TabIndex = 10005;
            this.label9.Text = "盈亏差额￥";
            // 
            // m_lblly
            // 
            this.m_lblly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblly.BackColor = System.Drawing.SystemColors.Control;
            this.m_lblly.ForeColor = System.Drawing.Color.Red;
            this.m_lblly.Location = new System.Drawing.Point(545, 501);
            this.m_lblly.Name = "m_lblly";
            this.m_lblly.Size = new System.Drawing.Size(69, 14);
            this.m_lblly.TabIndex = 10006;
            // 
            // m_lblWholeSaleSubMoney
            // 
            this.m_lblWholeSaleSubMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblWholeSaleSubMoney.BackColor = System.Drawing.SystemColors.Control;
            this.m_lblWholeSaleSubMoney.ForeColor = System.Drawing.Color.Red;
            this.m_lblWholeSaleSubMoney.Location = new System.Drawing.Point(245, 501);
            this.m_lblWholeSaleSubMoney.Name = "m_lblWholeSaleSubMoney";
            this.m_lblWholeSaleSubMoney.Size = new System.Drawing.Size(69, 14);
            this.m_lblWholeSaleSubMoney.TabIndex = 10004;
            // 
            // m_lblBuyInSubMoney
            // 
            this.m_lblBuyInSubMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblBuyInSubMoney.BackColor = System.Drawing.SystemColors.Control;
            this.m_lblBuyInSubMoney.ForeColor = System.Drawing.Color.Red;
            this.m_lblBuyInSubMoney.Location = new System.Drawing.Point(94, 501);
            this.m_lblBuyInSubMoney.Name = "m_lblBuyInSubMoney";
            this.m_lblBuyInSubMoney.Size = new System.Drawing.Size(74, 14);
            this.m_lblBuyInSubMoney.TabIndex = 10004;
            // 
            // m_lblRetailSubMoney
            // 
            this.m_lblRetailSubMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblRetailSubMoney.BackColor = System.Drawing.SystemColors.Control;
            this.m_lblRetailSubMoney.ForeColor = System.Drawing.Color.Red;
            this.m_lblRetailSubMoney.Location = new System.Drawing.Point(389, 501);
            this.m_lblRetailSubMoney.Name = "m_lblRetailSubMoney";
            this.m_lblRetailSubMoney.Size = new System.Drawing.Size(78, 14);
            this.m_lblRetailSubMoney.TabIndex = 10004;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.BackColor = System.Drawing.SystemColors.Control;
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(168, 501);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 14);
            this.label16.TabIndex = 10003;
            this.label16.Text = "批发金额￥";
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.BackColor = System.Drawing.SystemColors.Control;
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(313, 501);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(77, 14);
            this.label18.TabIndex = 10003;
            this.label18.Text = "零售金额￥";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.BackColor = System.Drawing.SystemColors.Control;
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(19, 501);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 14);
            this.label13.TabIndex = 10003;
            this.label13.Text = "购入金额￥";
            // 
            // m_dgvSubInfo
            // 
            this.m_dgvSubInfo.AllowUserToAddRows = false;
            this.m_dgvSubInfo.AllowUserToDeleteRows = false;
            this.m_dgvSubInfo.AllowUserToResizeRows = false;
            this.m_dgvSubInfo.BackgroundColor = System.Drawing.SystemColors.Window;
            this.m_dgvSubInfo.ColumnHeadersHeight = 30;
            this.m_dgvSubInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_dgvtxtSortNum,
            this.m_dgvtxtMedicineCode,
            this.m_dgvtxtMedicineName,
            this.m_dtvtxtMedicineSpec,
            this.productID,
            this.PRODUCEDATE_DAT,
            this.invoicecode,
            this.invoicedater,
            this.m_dgvtxtInAmount,
            this.m_dgvtxtMedicineUnit,
            this.m_dgvtxtLotNO,
            this.m_dgvtxtBuyPrice,
            this.m_dgvtxtWholeSalePrice,
            this.m_dgvtxtSalePrice});
            this.m_dgvSubInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvSubInfo.Location = new System.Drawing.Point(0, 0);
            this.m_dgvSubInfo.MultiSelect = false;
            this.m_dgvSubInfo.Name = "m_dgvSubInfo";
            this.m_dgvSubInfo.RowHeadersVisible = false;
            this.m_dgvSubInfo.RowTemplate.Height = 23;
            this.m_dgvSubInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvSubInfo.Size = new System.Drawing.Size(631, 517);
            this.m_dgvSubInfo.TabIndex = 55;
            this.m_dgvSubInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvSubInfo_CellDoubleClick);
            this.m_dgvSubInfo.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.m_dgvSubInfo_RowPrePaint);
            this.m_dgvSubInfo.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.m_dgvSubInfo_RowsAdded);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 105);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1028, 529);
            this.panel2.TabIndex = 18;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.m_cboInComeType);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.m_cmdSearch);
            this.panel1.Controls.Add(this.m_cboDoseType);
            this.panel1.Controls.Add(this.m_txtProviderName);
            this.panel1.Controls.Add(this.m_txtBillNumber);
            this.panel1.Controls.Add(this.m_txtMedicineName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.m_cboBillState);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.m_dtpSearchEndDate);
            this.panel1.Controls.Add(this.m_dtpSearchBeginDate);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(0, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1028, 65);
            this.panel1.TabIndex = 5;
            // 
            // m_cboInComeType
            // 
            this.m_cboInComeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboInComeType.Location = new System.Drawing.Point(753, 6);
            this.m_cboInComeType.Name = "m_cboInComeType";
            this.m_cboInComeType.Size = new System.Drawing.Size(92, 22);
            this.m_cboInComeType.TabIndex = 97;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(684, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "入库类型";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "入库时间";
            // 
            // m_cmdSearch
            // 
            this.m_cmdSearch.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdSearch.ImageIndex = 13;
            this.m_cmdSearch.ImageList = this.imageList1;
            this.m_cmdSearch.Location = new System.Drawing.Point(920, 29);
            this.m_cmdSearch.Name = "m_cmdSearch";
            this.m_cmdSearch.Size = new System.Drawing.Size(92, 25);
            this.m_cmdSearch.TabIndex = 95;
            this.m_cmdSearch.Text = "查询(&F)";
            this.m_cmdSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdSearch.UseVisualStyleBackColor = true;
            this.m_cmdSearch.Click += new System.EventHandler(this.m_cmdSearch_Click);
            // 
            // m_cboDoseType
            // 
            this.m_cboDoseType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboDoseType.FormattingEnabled = true;
            this.m_cboDoseType.Location = new System.Drawing.Point(753, 32);
            this.m_cboDoseType.Name = "m_cboDoseType";
            this.m_cboDoseType.Size = new System.Drawing.Size(92, 22);
            this.m_cboDoseType.TabIndex = 40;
            this.m_cboDoseType.SelectedIndexChanged += new System.EventHandler(this.m_cboDoseType_SelectedIndexChanged);
            // 
            // m_txtProviderName
            // 
            this.m_txtProviderName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtProviderName.Location = new System.Drawing.Point(423, 5);
            this.m_txtProviderName.Name = "m_txtProviderName";
            this.m_txtProviderName.Size = new System.Drawing.Size(255, 23);
            this.m_txtProviderName.TabIndex = 20;
            this.m_txtProviderName.TextChanged += new System.EventHandler(this.m_txtProviderName_TextChanged);
            this.m_txtProviderName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtProviderName_KeyDown);
            // 
            // m_txtBillNumber
            // 
            this.m_txtBillNumber.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBillNumber.Location = new System.Drawing.Point(423, 32);
            this.m_txtBillNumber.Name = "m_txtBillNumber";
            this.m_txtBillNumber.Size = new System.Drawing.Size(255, 23);
            this.m_txtBillNumber.TabIndex = 45;
            this.m_txtBillNumber.TextChanged += new System.EventHandler(this.m_txtBillNumber_TextChanged);
            this.m_txtBillNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtBillNumber_KeyDown);
            // 
            // m_txtMedicineName
            // 
            this.m_txtMedicineName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtMedicineName.Location = new System.Drawing.Point(67, 32);
            this.m_txtMedicineName.Name = "m_txtMedicineName";
            this.m_txtMedicineName.Size = new System.Drawing.Size(283, 23);
            this.m_txtMedicineName.TabIndex = 35;
            this.m_txtMedicineName.TextChanged += new System.EventHandler(this.m_txtMedicineName_TextChanged);
            this.m_txtMedicineName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtMedicineName_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(357, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "供应商名";
            // 
            // m_cboBillState
            // 
            this.m_cboBillState.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboBillState.FormattingEnabled = true;
            this.m_cboBillState.Items.AddRange(new object[] {
            "全部",
            "新制",
            "审核",
            "入帐"});
            this.m_cboBillState.Location = new System.Drawing.Point(920, 5);
            this.m_cboBillState.Name = "m_cboBillState";
            this.m_cboBillState.Size = new System.Drawing.Size(92, 22);
            this.m_cboBillState.TabIndex = 30;
            this.m_cboBillState.SelectedIndexChanged += new System.EventHandler(this.m_cboBillState_SelectedIndexChanged);
            this.m_cboBillState.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cboBillState_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(851, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "单据状态";
            // 
            // m_dtpSearchEndDate
            // 
            this.m_dtpSearchEndDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_dtpSearchEndDate.Location = new System.Drawing.Point(220, 5);
            this.m_dtpSearchEndDate.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日;
            this.m_dtpSearchEndDate.Mask = "0000年90月90日";
            this.m_dtpSearchEndDate.Name = "m_dtpSearchEndDate";
            this.m_dtpSearchEndDate.Size = new System.Drawing.Size(130, 23);
            this.m_dtpSearchEndDate.TabIndex = 15;
            this.m_dtpSearchEndDate.ValidatingType = typeof(System.DateTime);
            this.m_dtpSearchEndDate.Enter += new System.EventHandler(this.m_dtpSearchEndDate_Enter);
            // 
            // m_dtpSearchBeginDate
            // 
            this.m_dtpSearchBeginDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_dtpSearchBeginDate.Location = new System.Drawing.Point(67, 5);
            this.m_dtpSearchBeginDate.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日;
            this.m_dtpSearchBeginDate.Mask = "0000年90月90日";
            this.m_dtpSearchBeginDate.Name = "m_dtpSearchBeginDate";
            this.m_dtpSearchBeginDate.Size = new System.Drawing.Size(130, 23);
            this.m_dtpSearchBeginDate.TabIndex = 10;
            this.m_dtpSearchBeginDate.ValidatingType = typeof(System.DateTime);
            this.m_dtpSearchBeginDate.Enter += new System.EventHandler(this.m_dtpSearchBeginDate_Enter);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(201, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 14);
            this.label8.TabIndex = 7;
            this.label8.Text = "~";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 7;
            this.label5.Text = "药品名称";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(357, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 9;
            this.label7.Text = "入库单号";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(684, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 8;
            this.label6.Text = "药品类型";
            // 
            // m_tmsShowNewMake
            // 
            this.m_tmsShowNewMake.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_tmsShowNewMake.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.入即出ToolStripMenuItem});
            this.m_tmsShowNewMake.Name = "contextMenuStrip1";
            this.m_tmsShowNewMake.Size = new System.Drawing.Size(189, 26);
            // 
            // 入即出ToolStripMenuItem
            // 
            this.入即出ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("入即出ToolStripMenuItem.Image")));
            this.入即出ToolStripMenuItem.Name = "入即出ToolStripMenuItem";
            this.入即出ToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.入即出ToolStripMenuItem.Text = "新制（即入即出）";
            this.入即出ToolStripMenuItem.Click += new System.EventHandler(this.入即出ToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(84, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(19, 28);
            this.button1.TabIndex = 10005;
            this.button1.Text = "↓";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.m_dgvtxtMedicineCode.DataPropertyName = "MedicineCode";
            this.m_dgvtxtMedicineCode.HeaderText = "药品代码";
            this.m_dgvtxtMedicineCode.Name = "m_dgvtxtMedicineCode";
            this.m_dgvtxtMedicineCode.ReadOnly = true;
            // 
            // m_dgvtxtMedicineName
            // 
            this.m_dgvtxtMedicineName.DataPropertyName = "MEDICINENAME_VCH";
            this.m_dgvtxtMedicineName.HeaderText = "名称";
            this.m_dgvtxtMedicineName.Name = "m_dgvtxtMedicineName";
            this.m_dgvtxtMedicineName.ReadOnly = true;
            // 
            // m_dtvtxtMedicineSpec
            // 
            this.m_dtvtxtMedicineSpec.DataPropertyName = "MEDSPEC_VCHR";
            this.m_dtvtxtMedicineSpec.HeaderText = "规格";
            this.m_dtvtxtMedicineSpec.Name = "m_dtvtxtMedicineSpec";
            this.m_dtvtxtMedicineSpec.ReadOnly = true;
            // 
            // productID
            // 
            this.productID.DataPropertyName = "PRODUCTORID_CHR";
            this.productID.HeaderText = "厂家";
            this.productID.Name = "productID";
            this.productID.ReadOnly = true;
            this.productID.Width = 88;
            // 
            // PRODUCEDATE_DAT
            // 
            this.PRODUCEDATE_DAT.DataPropertyName = "PRODUCEDATE_DAT";
            this.PRODUCEDATE_DAT.HeaderText = "生产日期";
            this.PRODUCEDATE_DAT.Name = "PRODUCEDATE_DAT";
            this.PRODUCEDATE_DAT.ReadOnly = true;
            this.PRODUCEDATE_DAT.Visible = false;
            // 
            // invoicecode
            // 
            this.invoicecode.DataPropertyName = "invoicecode_vchr";
            this.invoicecode.HeaderText = "发票号";
            this.invoicecode.Name = "invoicecode";
            this.invoicecode.ReadOnly = true;
            // 
            // invoicedater
            // 
            this.invoicedater.DataPropertyName = "invoicedater_dat";
            dataGridViewCellStyle2.Format = "D";
            dataGridViewCellStyle2.NullValue = null;
            this.invoicedater.DefaultCellStyle = dataGridViewCellStyle2;
            this.invoicedater.HeaderText = "发票日期";
            this.invoicedater.Name = "invoicedater";
            this.invoicedater.ReadOnly = true;
            // 
            // m_dgvtxtInAmount
            // 
            this.m_dgvtxtInAmount.DataPropertyName = "AMOUNT";
            this.m_dgvtxtInAmount.HeaderText = "入库数量";
            this.m_dgvtxtInAmount.Name = "m_dgvtxtInAmount";
            this.m_dgvtxtInAmount.ReadOnly = true;
            // 
            // m_dgvtxtMedicineUnit
            // 
            this.m_dgvtxtMedicineUnit.DataPropertyName = "UNIT_VCHR";
            this.m_dgvtxtMedicineUnit.HeaderText = "单位";
            this.m_dgvtxtMedicineUnit.Name = "m_dgvtxtMedicineUnit";
            this.m_dgvtxtMedicineUnit.ReadOnly = true;
            // 
            // m_dgvtxtLotNO
            // 
            this.m_dgvtxtLotNO.DataPropertyName = "LOTNO_VCHR";
            this.m_dgvtxtLotNO.HeaderText = "批号";
            this.m_dgvtxtLotNO.Name = "m_dgvtxtLotNO";
            this.m_dgvtxtLotNO.ReadOnly = true;
            // 
            // m_dgvtxtBuyPrice
            // 
            this.m_dgvtxtBuyPrice.DataPropertyName = "CALLPRICE_INT";
            dataGridViewCellStyle3.Format = "N4";
            dataGridViewCellStyle3.NullValue = null;
            this.m_dgvtxtBuyPrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.m_dgvtxtBuyPrice.HeaderText = "购入价";
            this.m_dgvtxtBuyPrice.Name = "m_dgvtxtBuyPrice";
            this.m_dgvtxtBuyPrice.ReadOnly = true;
            // 
            // m_dgvtxtWholeSalePrice
            // 
            this.m_dgvtxtWholeSalePrice.DataPropertyName = "WHOLESALEPRICE_INT";
            dataGridViewCellStyle4.Format = "N4";
            dataGridViewCellStyle4.NullValue = null;
            this.m_dgvtxtWholeSalePrice.DefaultCellStyle = dataGridViewCellStyle4;
            this.m_dgvtxtWholeSalePrice.HeaderText = "批发价";
            this.m_dgvtxtWholeSalePrice.Name = "m_dgvtxtWholeSalePrice";
            this.m_dgvtxtWholeSalePrice.ReadOnly = true;
            // 
            // m_dgvtxtSalePrice
            // 
            this.m_dgvtxtSalePrice.DataPropertyName = "RETAILPRICE_INT";
            dataGridViewCellStyle5.Format = "N4";
            dataGridViewCellStyle5.NullValue = null;
            this.m_dgvtxtSalePrice.DefaultCellStyle = dataGridViewCellStyle5;
            this.m_dgvtxtSalePrice.HeaderText = "零售价";
            this.m_dgvtxtSalePrice.Name = "m_dgvtxtSalePrice";
            this.m_dgvtxtSalePrice.ReadOnly = true;
            // 
            // frmPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 634);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.m_pnlWaiting);
            this.Controls.Add(this.m_cmdDelete);
            this.Controls.Add(this.m_cmdNewMake);
            this.Controls.Add(this.m_cmdExit);
            this.Controls.Add(this.m_cmdOutAccount);
            this.Controls.Add(this.m_cmdInAccount);
            this.Controls.Add(this.m_cmdExitAuditing);
            this.Controls.Add(this.m_cmdModify);
            this.Controls.Add(this.m_cmdAuditing);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPurchase";
            this.Text = "药品入库";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPurchase_Load);
            this.m_pnlWaiting.ResumeLayout(false);
            this.m_pnlWaiting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvMainInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvSubInfo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.m_tmsShowNewMake.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button m_cmdDelete;
        private System.Windows.Forms.Button m_cmdNewMake;
        private System.Windows.Forms.Button m_cmdExitAuditing;
        private System.Windows.Forms.Button m_cmdModify;
        private System.Windows.Forms.Button m_cmdAuditing;
        private System.Windows.Forms.Button m_cmdInAccount;
        private System.Windows.Forms.Button m_cmdOutAccount;
        private System.Windows.Forms.Button m_cmdExit;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label8;
        private System.ComponentModel.BackgroundWorker m_bgwGetData;
        internal System.Windows.Forms.ComboBox m_cboDoseType;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab m_dtpSearchBeginDate;
        internal System.Windows.Forms.ComboBox m_cboBillState;
        internal System.Windows.Forms.TextBox m_txtMedicineName;
        internal System.Windows.Forms.TextBox m_txtProviderName;
        internal System.Windows.Forms.TextBox m_txtBillNumber;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab m_dtpSearchEndDate;
        internal System.Windows.Forms.DataGridView m_dgvSubInfo;
        internal System.Windows.Forms.DataGridView m_dgvMainInfo;
        internal System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button m_cmdSearch;
        private System.Windows.Forms.Panel m_pnlWaiting;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label m_lblSelectAll;
        internal System.Windows.Forms.Label m_lblRetailMoney;
        internal System.Windows.Forms.Label m_lblWholeSaleMoney;
        internal System.Windows.Forms.Label m_lblBuyInMoney;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label m_lblRetailSubMoney;
        internal System.Windows.Forms.Label m_lblWholeSaleSubMoney;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        internal System.Windows.Forms.Label m_lblBuyInSubMoney;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ToolStripMenuItem 入即出ToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn m_dgvchkCommit;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvInDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtBillNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtProvider;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtInType;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtCreator;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtExamer;
        internal System.Windows.Forms.Label m_lblly;
        private System.Windows.Forms.Label label9;
        internal System.Windows.Forms.ContextMenuStrip m_tmsShowNewMake;
        internal com.digitalwave.iCare.gui.HIS.exComboBox m_cboInComeType;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtSortNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dtvtxtMedicineSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn productID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCEDATE_DAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoicecode;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoicedater;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtInAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtLotNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtBuyPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtWholeSalePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtSalePrice;
    }
}

