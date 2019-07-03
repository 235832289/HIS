namespace com.digitalwave.iCare.gui.MedicineStore
{
    partial class frmStorageCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStorageCheck));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_dgvMainInfo = new System.Windows.Forms.DataGridView();
            this.m_lblBalanceMoney = new System.Windows.Forms.Label();
            this.m_lblBuyInSubMoney = new System.Windows.Forms.Label();
            this.m_lblRetailSubMoney = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.m_dgvSubInfo = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MEDICINEID_CHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MEDICINENAME_VCH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MEDSPEC_VCHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOTNO_VCHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CURRENTGROSS_INT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHECKGROSS_INT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHECKRESULT_INT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_cmdInAccount = new System.Windows.Forms.Button();
            this.m_cmdExit = new System.Windows.Forms.Button();
            this.m_cmdAddNewPage1 = new System.Windows.Forms.Button();
            this.m_cmdExitPage1 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.m_cboType = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.m_txtChickID = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.m_dtpEndDatePage1 = new com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab(this.components);
            this.m_dtpBeginDatePage1 = new com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab(this.components);
            this.label27 = new System.Windows.Forms.Label();
            this.m_cmdDeletePage1 = new System.Windows.Forms.Button();
            this.m_cmdCommitPage1 = new System.Windows.Forms.Button();
            this.m_cmdModifyPage1 = new System.Windows.Forms.Button();
            this.m_cmdUnCommitPage1 = new System.Windows.Forms.Button();
            this.CHECKID_CHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkdate_dat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtCreatorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtExamerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvMainInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvSubInfo)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 79);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.m_dgvMainInfo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.m_lblBalanceMoney);
            this.splitContainer1.Panel2.Controls.Add(this.m_lblBuyInSubMoney);
            this.splitContainer1.Panel2.Controls.Add(this.m_lblRetailSubMoney);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.label9);
            this.splitContainer1.Panel2.Controls.Add(this.label13);
            this.splitContainer1.Panel2.Controls.Add(this.m_dgvSubInfo);
            this.splitContainer1.Size = new System.Drawing.Size(1028, 554);
            this.splitContainer1.SplitterDistance = 391;
            this.splitContainer1.TabIndex = 10027;
            // 
            // m_dgvMainInfo
            // 
            this.m_dgvMainInfo.AllowUserToAddRows = false;
            this.m_dgvMainInfo.AllowUserToDeleteRows = false;
            this.m_dgvMainInfo.AllowUserToResizeRows = false;
            this.m_dgvMainInfo.BackgroundColor = System.Drawing.SystemColors.Window;
            this.m_dgvMainInfo.ColumnHeadersHeight = 30;
            this.m_dgvMainInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CHECKID_CHR,
            this.m_dgvtxtStatus,
            this.checkdate_dat,
            this.m_dgvtxtCreatorName,
            this.m_dgvtxtExamerName});
            this.m_dgvMainInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvMainInfo.Location = new System.Drawing.Point(0, 0);
            this.m_dgvMainInfo.MultiSelect = false;
            this.m_dgvMainInfo.Name = "m_dgvMainInfo";
            this.m_dgvMainInfo.ReadOnly = true;
            this.m_dgvMainInfo.RowHeadersVisible = false;
            this.m_dgvMainInfo.RowTemplate.Height = 23;
            this.m_dgvMainInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvMainInfo.Size = new System.Drawing.Size(391, 554);
            this.m_dgvMainInfo.TabIndex = 4;
            this.m_dgvMainInfo.CurrentCellChanged += new System.EventHandler(this.m_dgvMainInfo_CurrentCellChanged);
            this.m_dgvMainInfo.DoubleClick += new System.EventHandler(this.m_dgvMainInfo_DoubleClick);
            // 
            // m_lblBalanceMoney
            // 
            this.m_lblBalanceMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblBalanceMoney.BackColor = System.Drawing.SystemColors.Control;
            this.m_lblBalanceMoney.ForeColor = System.Drawing.Color.Red;
            this.m_lblBalanceMoney.Location = new System.Drawing.Point(508, 536);
            this.m_lblBalanceMoney.Name = "m_lblBalanceMoney";
            this.m_lblBalanceMoney.Size = new System.Drawing.Size(97, 14);
            this.m_lblBalanceMoney.TabIndex = 10022;
            // 
            // m_lblBuyInSubMoney
            // 
            this.m_lblBuyInSubMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblBuyInSubMoney.BackColor = System.Drawing.SystemColors.Control;
            this.m_lblBuyInSubMoney.ForeColor = System.Drawing.Color.Red;
            this.m_lblBuyInSubMoney.Location = new System.Drawing.Point(159, 536);
            this.m_lblBuyInSubMoney.Name = "m_lblBuyInSubMoney";
            this.m_lblBuyInSubMoney.Size = new System.Drawing.Size(97, 14);
            this.m_lblBuyInSubMoney.TabIndex = 10023;
            // 
            // m_lblRetailSubMoney
            // 
            this.m_lblRetailSubMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblRetailSubMoney.BackColor = System.Drawing.SystemColors.Control;
            this.m_lblRetailSubMoney.ForeColor = System.Drawing.Color.Red;
            this.m_lblRetailSubMoney.Location = new System.Drawing.Point(333, 536);
            this.m_lblRetailSubMoney.Name = "m_lblRetailSubMoney";
            this.m_lblRetailSubMoney.Size = new System.Drawing.Size(97, 14);
            this.m_lblRetailSubMoney.TabIndex = 10024;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(431, 536);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 14);
            this.label7.TabIndex = 10019;
            this.label7.Text = "盈亏金额￥";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(257, 536);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 14);
            this.label9.TabIndex = 10020;
            this.label9.Text = "零售金额￥";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.BackColor = System.Drawing.SystemColors.Control;
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(84, 536);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 14);
            this.label13.TabIndex = 10021;
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
            this.dataGridViewTextBoxColumn1,
            this.MEDICINEID_CHR,
            this.MEDICINENAME_VCH,
            this.MEDSPEC_VCHR,
            this.LOTNO_VCHR,
            this.CURRENTGROSS_INT,
            this.CHECKGROSS_INT,
            this.CHECKRESULT_INT});
            this.m_dgvSubInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvSubInfo.Location = new System.Drawing.Point(0, 0);
            this.m_dgvSubInfo.Name = "m_dgvSubInfo";
            this.m_dgvSubInfo.RowHeadersVisible = false;
            this.m_dgvSubInfo.RowTemplate.Height = 23;
            this.m_dgvSubInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvSubInfo.Size = new System.Drawing.Size(633, 554);
            this.m_dgvSubInfo.TabIndex = 10018;
            this.m_dgvSubInfo.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.m_dgvSubInfo_RowsAdded);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CHECKID_CHR";
            this.dataGridViewTextBoxColumn1.HeaderText = "序号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // MEDICINEID_CHR
            // 
            this.MEDICINEID_CHR.DataPropertyName = "MEDICINEID_CHR";
            this.MEDICINEID_CHR.HeaderText = "药品代码";
            this.MEDICINEID_CHR.Name = "MEDICINEID_CHR";
            this.MEDICINEID_CHR.ReadOnly = true;
            // 
            // MEDICINENAME_VCH
            // 
            this.MEDICINENAME_VCH.DataPropertyName = "MEDICINENAME_VCH";
            this.MEDICINENAME_VCH.HeaderText = "药品名称";
            this.MEDICINENAME_VCH.Name = "MEDICINENAME_VCH";
            // 
            // MEDSPEC_VCHR
            // 
            this.MEDSPEC_VCHR.DataPropertyName = "MEDSPEC_VCHR";
            this.MEDSPEC_VCHR.HeaderText = "规格";
            this.MEDSPEC_VCHR.Name = "MEDSPEC_VCHR";
            this.MEDSPEC_VCHR.ReadOnly = true;
            // 
            // LOTNO_VCHR
            // 
            this.LOTNO_VCHR.DataPropertyName = "LOTNO_VCHR";
            this.LOTNO_VCHR.HeaderText = "批号";
            this.LOTNO_VCHR.Name = "LOTNO_VCHR";
            this.LOTNO_VCHR.ReadOnly = true;
            // 
            // CURRENTGROSS_INT
            // 
            this.CURRENTGROSS_INT.DataPropertyName = "CURRENTGROSS_INT";
            dataGridViewCellStyle1.Format = "N4";
            dataGridViewCellStyle1.NullValue = null;
            this.CURRENTGROSS_INT.DefaultCellStyle = dataGridViewCellStyle1;
            this.CURRENTGROSS_INT.HeaderText = "电脑数量";
            this.CURRENTGROSS_INT.Name = "CURRENTGROSS_INT";
            // 
            // CHECKGROSS_INT
            // 
            this.CHECKGROSS_INT.DataPropertyName = "CHECKGROSS_INT";
            dataGridViewCellStyle2.Format = "N4";
            dataGridViewCellStyle2.NullValue = null;
            this.CHECKGROSS_INT.DefaultCellStyle = dataGridViewCellStyle2;
            this.CHECKGROSS_INT.HeaderText = "实际数量";
            this.CHECKGROSS_INT.Name = "CHECKGROSS_INT";
            // 
            // CHECKRESULT_INT
            // 
            this.CHECKRESULT_INT.DataPropertyName = "CHECKRESULT_INT";
            dataGridViewCellStyle3.Format = "N4";
            dataGridViewCellStyle3.NullValue = null;
            this.CHECKRESULT_INT.DefaultCellStyle = dataGridViewCellStyle3;
            this.CHECKRESULT_INT.HeaderText = "盈亏数量";
            this.CHECKRESULT_INT.Name = "CHECKRESULT_INT";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_cmdInAccount);
            this.panel1.Controls.Add(this.m_cmdExit);
            this.panel1.Controls.Add(this.m_cmdAddNewPage1);
            this.panel1.Controls.Add(this.m_cmdExitPage1);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.m_cmdDeletePage1);
            this.panel1.Controls.Add(this.m_cmdCommitPage1);
            this.panel1.Controls.Add(this.m_cmdModifyPage1);
            this.panel1.Controls.Add(this.m_cmdUnCommitPage1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1028, 79);
            this.panel1.TabIndex = 10025;
            // 
            // m_cmdInAccount
            // 
            this.m_cmdInAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdInAccount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdInAccount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdInAccount.ImageIndex = 11;
            this.m_cmdInAccount.ImageList = this.imageList1;
            this.m_cmdInAccount.Location = new System.Drawing.Point(377, 5);
            this.m_cmdInAccount.Name = "m_cmdInAccount";
            this.m_cmdInAccount.Size = new System.Drawing.Size(94, 28);
            this.m_cmdInAccount.TabIndex = 10026;
            this.m_cmdInAccount.Text = "入帐(&I)";
            this.m_cmdInAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdInAccount.UseVisualStyleBackColor = true;
            this.m_cmdInAccount.Click += new System.EventHandler(this.m_cmdInAccount_Click);
            // 
            // m_cmdExit
            // 
            this.m_cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdExit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdExit.ImageIndex = 1;
            this.m_cmdExit.ImageList = this.imageList1;
            this.m_cmdExit.Location = new System.Drawing.Point(927, 5);
            this.m_cmdExit.Name = "m_cmdExit";
            this.m_cmdExit.Size = new System.Drawing.Size(94, 28);
            this.m_cmdExit.TabIndex = 10025;
            this.m_cmdExit.Text = "退出(&Q)";
            this.m_cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdExit.UseVisualStyleBackColor = true;
            this.m_cmdExit.Click += new System.EventHandler(this.m_cmdExit_Click);
            // 
            // m_cmdAddNewPage1
            // 
            this.m_cmdAddNewPage1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdAddNewPage1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdAddNewPage1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdAddNewPage1.ImageIndex = 9;
            this.m_cmdAddNewPage1.ImageList = this.imageList1;
            this.m_cmdAddNewPage1.Location = new System.Drawing.Point(5, 5);
            this.m_cmdAddNewPage1.Name = "m_cmdAddNewPage1";
            this.m_cmdAddNewPage1.Size = new System.Drawing.Size(94, 28);
            this.m_cmdAddNewPage1.TabIndex = 10019;
            this.m_cmdAddNewPage1.Text = "新制(&A)";
            this.m_cmdAddNewPage1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdAddNewPage1.UseVisualStyleBackColor = true;
            this.m_cmdAddNewPage1.Click += new System.EventHandler(this.m_cmdAddNewPage1_Click);
            // 
            // m_cmdExitPage1
            // 
            this.m_cmdExitPage1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdExitPage1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdExitPage1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdExitPage1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdExitPage1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdExitPage1.ImageIndex = 1;
            this.m_cmdExitPage1.ImageList = this.imageList1;
            this.m_cmdExitPage1.Location = new System.Drawing.Point(882, 109);
            this.m_cmdExitPage1.Name = "m_cmdExitPage1";
            this.m_cmdExitPage1.Size = new System.Drawing.Size(922, 28);
            this.m_cmdExitPage1.TabIndex = 10024;
            this.m_cmdExitPage1.Text = "退出(&Q)";
            this.m_cmdExitPage1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdExitPage1.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.m_cboType);
            this.panel4.Controls.Add(this.label22);
            this.panel4.Controls.Add(this.m_txtChickID);
            this.panel4.Controls.Add(this.label24);
            this.panel4.Controls.Add(this.label25);
            this.panel4.Controls.Add(this.m_dtpEndDatePage1);
            this.panel4.Controls.Add(this.m_dtpBeginDatePage1);
            this.panel4.Controls.Add(this.label27);
            this.panel4.Location = new System.Drawing.Point(3, 37);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(2063, 42);
            this.panel4.TabIndex = 10017;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.ImageIndex = 13;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(922, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 28);
            this.button1.TabIndex = 10025;
            this.button1.Text = "查询(&F)";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // m_cboType
            // 
            this.m_cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboType.FormattingEnabled = true;
            this.m_cboType.Items.AddRange(new object[] {
            "全部",
            "新制",
            "审核",
            "入帐"});
            this.m_cboType.Location = new System.Drawing.Point(683, 8);
            this.m_cboType.Name = "m_cboType";
            this.m_cboType.Size = new System.Drawing.Size(120, 22);
            this.m_cboType.TabIndex = 30;
            this.m_cboType.SelectedIndexChanged += new System.EventHandler(this.m_cboType_SelectedIndexChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(642, 12);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(35, 14);
            this.label22.TabIndex = 98;
            this.label22.Text = "状态";
            // 
            // m_txtChickID
            // 
            this.m_txtChickID.Location = new System.Drawing.Point(454, 8);
            this.m_txtChickID.Name = "m_txtChickID";
            this.m_txtChickID.Size = new System.Drawing.Size(135, 23);
            this.m_txtChickID.TabIndex = 40;
            this.m_txtChickID.TextChanged += new System.EventHandler(this.m_txtChickID_TextChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(393, 12);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(49, 14);
            this.label24.TabIndex = 96;
            this.label24.Text = "盘点号";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(4, 12);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(63, 14);
            this.label25.TabIndex = 1;
            this.label25.Text = "盘点时间";
            // 
            // m_dtpEndDatePage1
            // 
            this.m_dtpEndDatePage1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_dtpEndDatePage1.Location = new System.Drawing.Point(236, 8);
            this.m_dtpEndDatePage1.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日;
            this.m_dtpEndDatePage1.Mask = "0000年90月90日";
            this.m_dtpEndDatePage1.Name = "m_dtpEndDatePage1";
            this.m_dtpEndDatePage1.Size = new System.Drawing.Size(126, 23);
            this.m_dtpEndDatePage1.TabIndex = 15;
            this.m_dtpEndDatePage1.ValidatingType = typeof(System.DateTime);
            // 
            // m_dtpBeginDatePage1
            // 
            this.m_dtpBeginDatePage1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_dtpBeginDatePage1.Location = new System.Drawing.Point(78, 8);
            this.m_dtpBeginDatePage1.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日;
            this.m_dtpBeginDatePage1.Mask = "0000年90月90日";
            this.m_dtpBeginDatePage1.Name = "m_dtpBeginDatePage1";
            this.m_dtpBeginDatePage1.Size = new System.Drawing.Size(127, 23);
            this.m_dtpBeginDatePage1.TabIndex = 10;
            this.m_dtpBeginDatePage1.ValidatingType = typeof(System.DateTime);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(211, 17);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(14, 14);
            this.label27.TabIndex = 7;
            this.label27.Text = "~";
            // 
            // m_cmdDeletePage1
            // 
            this.m_cmdDeletePage1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdDeletePage1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdDeletePage1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdDeletePage1.ImageIndex = 2;
            this.m_cmdDeletePage1.ImageList = this.imageList1;
            this.m_cmdDeletePage1.Location = new System.Drawing.Point(191, 5);
            this.m_cmdDeletePage1.Name = "m_cmdDeletePage1";
            this.m_cmdDeletePage1.Size = new System.Drawing.Size(94, 28);
            this.m_cmdDeletePage1.TabIndex = 10021;
            this.m_cmdDeletePage1.Text = "删除(&D)";
            this.m_cmdDeletePage1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdDeletePage1.UseVisualStyleBackColor = true;
            this.m_cmdDeletePage1.Click += new System.EventHandler(this.m_cmdDeletePage1_Click);
            // 
            // m_cmdCommitPage1
            // 
            this.m_cmdCommitPage1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdCommitPage1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdCommitPage1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdCommitPage1.ImageIndex = 4;
            this.m_cmdCommitPage1.ImageList = this.imageList1;
            this.m_cmdCommitPage1.Location = new System.Drawing.Point(284, 5);
            this.m_cmdCommitPage1.Name = "m_cmdCommitPage1";
            this.m_cmdCommitPage1.Size = new System.Drawing.Size(94, 28);
            this.m_cmdCommitPage1.TabIndex = 10022;
            this.m_cmdCommitPage1.Text = "审核(&E)";
            this.m_cmdCommitPage1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdCommitPage1.UseVisualStyleBackColor = true;
            this.m_cmdCommitPage1.Click += new System.EventHandler(this.m_cmdCommitPage1_Click);
            // 
            // m_cmdModifyPage1
            // 
            this.m_cmdModifyPage1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdModifyPage1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdModifyPage1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdModifyPage1.ImageIndex = 3;
            this.m_cmdModifyPage1.ImageList = this.imageList1;
            this.m_cmdModifyPage1.Location = new System.Drawing.Point(98, 5);
            this.m_cmdModifyPage1.Name = "m_cmdModifyPage1";
            this.m_cmdModifyPage1.Size = new System.Drawing.Size(94, 28);
            this.m_cmdModifyPage1.TabIndex = 10020;
            this.m_cmdModifyPage1.Text = "修改(&C)";
            this.m_cmdModifyPage1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdModifyPage1.UseVisualStyleBackColor = true;
            this.m_cmdModifyPage1.Click += new System.EventHandler(this.m_cmdModifyPage1_Click);
            // 
            // m_cmdUnCommitPage1
            // 
            this.m_cmdUnCommitPage1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdUnCommitPage1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdUnCommitPage1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdUnCommitPage1.ImageIndex = 10;
            this.m_cmdUnCommitPage1.ImageList = this.imageList1;
            this.m_cmdUnCommitPage1.Location = new System.Drawing.Point(470, 5);
            this.m_cmdUnCommitPage1.Name = "m_cmdUnCommitPage1";
            this.m_cmdUnCommitPage1.Size = new System.Drawing.Size(94, 28);
            this.m_cmdUnCommitPage1.TabIndex = 10023;
            this.m_cmdUnCommitPage1.Text = "退审(&R)";
            this.m_cmdUnCommitPage1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdUnCommitPage1.UseVisualStyleBackColor = true;
            this.m_cmdUnCommitPage1.Visible = false;
            this.m_cmdUnCommitPage1.Click += new System.EventHandler(this.m_cmdUnCommitPage1_Click);
            // 
            // CHECKID_CHR
            // 
            this.CHECKID_CHR.DataPropertyName = "CHECKID_CHR";
            this.CHECKID_CHR.HeaderText = "盘点单号";
            this.CHECKID_CHR.Name = "CHECKID_CHR";
            this.CHECKID_CHR.ReadOnly = true;
            // 
            // m_dgvtxtStatus
            // 
            this.m_dgvtxtStatus.DataPropertyName = "statusdesc";
            this.m_dgvtxtStatus.HeaderText = "状态";
            this.m_dgvtxtStatus.Name = "m_dgvtxtStatus";
            this.m_dgvtxtStatus.ReadOnly = true;
            this.m_dgvtxtStatus.Width = 60;
            // 
            // checkdate_dat
            // 
            this.checkdate_dat.DataPropertyName = "CHECKDATE_DAT";
            this.checkdate_dat.HeaderText = "盘点时间";
            this.checkdate_dat.Name = "checkdate_dat";
            this.checkdate_dat.ReadOnly = true;
            this.checkdate_dat.Width = 150;
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
            this.m_dgvtxtExamerName.Width = 200;
            // 
            // frmStorageCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 633);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmStorageCheck";
            this.Text = "盘点（西药）";
            this.Load += new System.EventHandler(this.frmStorageCheck_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvMainInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvSubInfo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab m_dtpBeginDatePage1;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab m_dtpEndDatePage1;
        internal System.Windows.Forms.Panel panel4;
        internal System.Windows.Forms.ComboBox m_cboType;
        private System.Windows.Forms.Label label22;
        internal System.Windows.Forms.TextBox m_txtChickID;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button m_cmdExitPage1;
        private System.Windows.Forms.Button m_cmdDeletePage1;
        private System.Windows.Forms.Button m_cmdAddNewPage1;
        private System.Windows.Forms.Button m_cmdUnCommitPage1;
        private System.Windows.Forms.Button m_cmdModifyPage1;
        private System.Windows.Forms.Button m_cmdCommitPage1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button m_cmdExit;
        private System.Windows.Forms.SplitContainer splitContainer1;
        internal System.Windows.Forms.DataGridView m_dgvMainInfo;
        internal System.Windows.Forms.DataGridView m_dgvSubInfo;
        internal System.Windows.Forms.Label m_lblBalanceMoney;
        internal System.Windows.Forms.Label m_lblBuyInSubMoney;
        internal System.Windows.Forms.Label m_lblRetailSubMoney;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button m_cmdInAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MEDICINEID_CHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn MEDICINENAME_VCH;
        private System.Windows.Forms.DataGridViewTextBoxColumn MEDSPEC_VCHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOTNO_VCHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn CURRENTGROSS_INT;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHECKGROSS_INT;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHECKRESULT_INT;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHECKID_CHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkdate_dat;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtCreatorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtExamerName;

    }
}