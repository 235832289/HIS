namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    partial class frmResultReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmResultReport));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_dgvMainInfo = new System.Windows.Forms.DataGridView();
            this.datWindow = new Sybase.DataWindow.DataWindowControl();
            this.m_cmdClose = new System.Windows.Forms.Button();
            this.m_cmdPrint = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_cmdShowAccount = new System.Windows.Forms.Button();
            this.m_txtCheckID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_dtpEndDatePage1 = new System.Windows.Forms.DateTimePicker();
            this.m_dtpBeginDatePage1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.checkid_chr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inaccountdate_dat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.askername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.examername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SERIESID_INT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdQuery = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvMainInfo)).BeginInit();
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
            // panel2
            // 
            this.panel2.Controls.Add(this.m_dgvMainInfo);
            this.panel2.Controls.Add(this.datWindow);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1028, 669);
            this.panel2.TabIndex = 69;
            // 
            // m_dgvMainInfo
            // 
            this.m_dgvMainInfo.AllowUserToAddRows = false;
            this.m_dgvMainInfo.AllowUserToDeleteRows = false;
            this.m_dgvMainInfo.AllowUserToResizeColumns = false;
            this.m_dgvMainInfo.AllowUserToResizeRows = false;
            this.m_dgvMainInfo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.m_dgvMainInfo.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.m_dgvMainInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvMainInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkid_chr,
            this.inaccountdate_dat,
            this.askername,
            this.examername,
            this.SERIESID_INT});
            this.m_dgvMainInfo.Location = new System.Drawing.Point(434, 0);
            this.m_dgvMainInfo.MultiSelect = false;
            this.m_dgvMainInfo.Name = "m_dgvMainInfo";
            this.m_dgvMainInfo.ReadOnly = true;
            this.m_dgvMainInfo.RowHeadersVisible = false;
            this.m_dgvMainInfo.RowTemplate.Height = 23;
            this.m_dgvMainInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.m_dgvMainInfo.Size = new System.Drawing.Size(446, 150);
            this.m_dgvMainInfo.TabIndex = 70;
            this.m_dgvMainInfo.Visible = false;
            this.m_dgvMainInfo.Leave += new System.EventHandler(this.m_dgvMainInfo_Leave);
            this.m_dgvMainInfo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_dgvMainInfo_MouseUp);
            // 
            // datWindow
            // 
            this.datWindow.DataWindowObject = "";
            this.datWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datWindow.LibraryList = "";
            this.datWindow.Location = new System.Drawing.Point(0, 0);
            this.datWindow.Name = "datWindow";
            this.datWindow.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.VerticalAndHorizontalSplit;
            this.datWindow.Size = new System.Drawing.Size(1028, 669);
            this.datWindow.TabIndex = 64;
            this.datWindow.Text = "dataWindowControl1";
            // 
            // m_cmdClose
            // 
            this.m_cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdClose.ImageIndex = 1;
            this.m_cmdClose.ImageList = this.imageList1;
            this.m_cmdClose.Location = new System.Drawing.Point(926, 8);
            this.m_cmdClose.Name = "m_cmdClose";
            this.m_cmdClose.Size = new System.Drawing.Size(94, 28);
            this.m_cmdClose.TabIndex = 99;
            this.m_cmdClose.Text = "退出(&Q)";
            this.m_cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdClose.UseVisualStyleBackColor = true;
            this.m_cmdClose.Click += new System.EventHandler(this.m_cmdClose_Click);
            // 
            // m_cmdPrint
            // 
            this.m_cmdPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdPrint.ImageIndex = 6;
            this.m_cmdPrint.ImageList = this.imageList1;
            this.m_cmdPrint.Location = new System.Drawing.Point(835, 8);
            this.m_cmdPrint.Name = "m_cmdPrint";
            this.m_cmdPrint.Size = new System.Drawing.Size(92, 28);
            this.m_cmdPrint.TabIndex = 88;
            this.m_cmdPrint.Text = "打印(&P)";
            this.m_cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdPrint.UseVisualStyleBackColor = true;
            this.m_cmdPrint.Click += new System.EventHandler(this.m_cmdPrint_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdQuery);
            this.panel1.Controls.Add(this.m_cmdShowAccount);
            this.panel1.Controls.Add(this.m_txtCheckID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.m_dtpEndDatePage1);
            this.panel1.Controls.Add(this.m_dtpBeginDatePage1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.m_cmdClose);
            this.panel1.Controls.Add(this.m_cmdPrint);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1028, 43);
            this.panel1.TabIndex = 68;
            // 
            // m_cmdShowAccount
            // 
            this.m_cmdShowAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdShowAccount.Location = new System.Drawing.Point(577, 12);
            this.m_cmdShowAccount.Name = "m_cmdShowAccount";
            this.m_cmdShowAccount.Size = new System.Drawing.Size(21, 23);
            this.m_cmdShowAccount.TabIndex = 73;
            this.m_cmdShowAccount.Text = "↓";
            this.m_cmdShowAccount.UseVisualStyleBackColor = true;
            this.m_cmdShowAccount.Click += new System.EventHandler(this.m_cmdShowAccount_Click);
            // 
            // m_txtCheckID
            // 
            this.m_txtCheckID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtCheckID.Location = new System.Drawing.Point(434, 12);
            this.m_txtCheckID.Name = "m_txtCheckID";
            this.m_txtCheckID.Size = new System.Drawing.Size(144, 23);
            this.m_txtCheckID.TabIndex = 72;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(379, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 71;
            this.label2.Text = "盘点单：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(204, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 14);
            this.label3.TabIndex = 70;
            this.label3.Text = "～";
            // 
            // m_dtpEndDatePage1
            // 
            this.m_dtpEndDatePage1.Location = new System.Drawing.Point(226, 12);
            this.m_dtpEndDatePage1.Name = "m_dtpEndDatePage1";
            this.m_dtpEndDatePage1.Size = new System.Drawing.Size(123, 23);
            this.m_dtpEndDatePage1.TabIndex = 69;
            this.m_dtpEndDatePage1.ValueChanged += new System.EventHandler(this.m_dtpEndDatePage1_ValueChanged);
            // 
            // m_dtpBeginDatePage1
            // 
            this.m_dtpBeginDatePage1.Location = new System.Drawing.Point(78, 12);
            this.m_dtpBeginDatePage1.Name = "m_dtpBeginDatePage1";
            this.m_dtpBeginDatePage1.Size = new System.Drawing.Size(125, 23);
            this.m_dtpBeginDatePage1.TabIndex = 68;
            this.m_dtpBeginDatePage1.ValueChanged += new System.EventHandler(this.m_dtpBeginDatePage1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 67;
            this.label1.Text = "盘点日期：";
            // 
            // checkid_chr
            // 
            this.checkid_chr.DataPropertyName = "checkid_chr";
            this.checkid_chr.HeaderText = "盘点单号";
            this.checkid_chr.Name = "checkid_chr";
            this.checkid_chr.ReadOnly = true;
            // 
            // inaccountdate_dat
            // 
            this.inaccountdate_dat.DataPropertyName = "ASKDATE_DAT";
            this.inaccountdate_dat.HeaderText = "制单日期";
            this.inaccountdate_dat.Name = "inaccountdate_dat";
            this.inaccountdate_dat.ReadOnly = true;
            this.inaccountdate_dat.Width = 140;
            // 
            // askername
            // 
            this.askername.DataPropertyName = "askername";
            this.askername.HeaderText = "制单人";
            this.askername.Name = "askername";
            this.askername.ReadOnly = true;
            // 
            // examername
            // 
            this.examername.DataPropertyName = "askername";
            this.examername.HeaderText = "审核人";
            this.examername.Name = "examername";
            this.examername.ReadOnly = true;
            // 
            // SERIESID_INT
            // 
            this.SERIESID_INT.DataPropertyName = "SERIESID_INT";
            this.SERIESID_INT.HeaderText = "序号";
            this.SERIESID_INT.Name = "SERIESID_INT";
            this.SERIESID_INT.ReadOnly = true;
            this.SERIESID_INT.Visible = false;
            // 
            // cmdQuery
            // 
            this.cmdQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdQuery.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cmdQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdQuery.ImageIndex = 13;
            this.cmdQuery.ImageList = this.imageList1;
            this.cmdQuery.Location = new System.Drawing.Point(740, 8);
            this.cmdQuery.Name = "cmdQuery";
            this.cmdQuery.Size = new System.Drawing.Size(94, 28);
            this.cmdQuery.TabIndex = 74;
            this.cmdQuery.Text = "查询(&A)";
            this.cmdQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdQuery.UseVisualStyleBackColor = true;
            this.cmdQuery.Click += new System.EventHandler(this.cmdQuery_Click_1);
            // 
            // frmResultReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 712);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmResultReport";
            this.Text = "盘点损溢明细报表";
            this.Load += new System.EventHandler(this.frmResultReport_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvMainInfo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel2;
        public Sybase.DataWindow.DataWindowControl datWindow;
        private System.Windows.Forms.Button m_cmdClose;
        private System.Windows.Forms.Button m_cmdPrint;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.DateTimePicker m_dtpEndDatePage1;
        public System.Windows.Forms.DateTimePicker m_dtpBeginDatePage1;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.DataGridView m_dgvMainInfo;
        private System.Windows.Forms.Button m_cmdShowAccount;
        internal System.Windows.Forms.TextBox m_txtCheckID;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkid_chr;
        private System.Windows.Forms.DataGridViewTextBoxColumn inaccountdate_dat;
        private System.Windows.Forms.DataGridViewTextBoxColumn askername;
        private System.Windows.Forms.DataGridViewTextBoxColumn examername;
        private System.Windows.Forms.DataGridViewTextBoxColumn SERIESID_INT;
        private System.Windows.Forms.Button cmdQuery;
    }
}