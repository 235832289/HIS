namespace com.digitalwave.iCare.gui.MedicineStore
{
    partial class frmAccountPeriod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccountPeriod));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.m_cmdExit = new System.Windows.Forms.Button();
            this.m_cmdAccount = new System.Windows.Forms.Button();
            this.m_dgvAccountData = new System.Windows.Forms.DataGridView();
            this.m_dgvtxtAccountID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtBeginDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_bgwGetData = new System.ComponentModel.BackgroundWorker();
            this.m_cmdCancel = new System.Windows.Forms.Button();
            this.m_cmdPrint = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvAccountData)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Shell32 028.ico");
            this.imageList1.Images.SetKeyName(1, "Shell32 133.ico");
            this.imageList1.Images.SetKeyName(2, "Shell32 147.ico");
            // 
            // m_cmdExit
            // 
            this.m_cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdExit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdExit.ImageIndex = 0;
            this.m_cmdExit.ImageList = this.imageList1;
            this.m_cmdExit.Location = new System.Drawing.Point(922, 12);
            this.m_cmdExit.Name = "m_cmdExit";
            this.m_cmdExit.Size = new System.Drawing.Size(94, 28);
            this.m_cmdExit.TabIndex = 97;
            this.m_cmdExit.Text = "退出(&Q)";
            this.m_cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdExit.UseVisualStyleBackColor = true;
            this.m_cmdExit.Click += new System.EventHandler(this.m_cmdExit_Click);
            // 
            // m_cmdAccount
            // 
            this.m_cmdAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdAccount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdAccount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdAccount.ImageIndex = 1;
            this.m_cmdAccount.ImageList = this.imageList1;
            this.m_cmdAccount.Location = new System.Drawing.Point(12, 12);
            this.m_cmdAccount.Name = "m_cmdAccount";
            this.m_cmdAccount.Size = new System.Drawing.Size(94, 28);
            this.m_cmdAccount.TabIndex = 96;
            this.m_cmdAccount.Text = "结转(&G)";
            this.m_cmdAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdAccount.UseVisualStyleBackColor = true;
            this.m_cmdAccount.Click += new System.EventHandler(this.m_cmdAccount_Click);
            // 
            // m_dgvAccountData
            // 
            this.m_dgvAccountData.AllowUserToAddRows = false;
            this.m_dgvAccountData.AllowUserToDeleteRows = false;
            this.m_dgvAccountData.AllowUserToResizeColumns = false;
            this.m_dgvAccountData.ColumnHeadersHeight = 28;
            this.m_dgvAccountData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_dgvtxtAccountID,
            this.m_dgvtxtBeginDate,
            this.m_dgvtxtEndDate,
            this.m_dgvtxtComment});
            this.m_dgvAccountData.Location = new System.Drawing.Point(10, 52);
            this.m_dgvAccountData.MultiSelect = false;
            this.m_dgvAccountData.Name = "m_dgvAccountData";
            this.m_dgvAccountData.RowHeadersVisible = false;
            this.m_dgvAccountData.RowTemplate.Height = 23;
            this.m_dgvAccountData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvAccountData.Size = new System.Drawing.Size(1009, 573);
            this.m_dgvAccountData.TabIndex = 98;
            this.m_dgvAccountData.DoubleClick += new System.EventHandler(this.m_dgvAccountData_DoubleClick);
            // 
            // m_dgvtxtAccountID
            // 
            this.m_dgvtxtAccountID.DataPropertyName = "accountid_chr";
            this.m_dgvtxtAccountID.HeaderText = "帐务期";
            this.m_dgvtxtAccountID.Name = "m_dgvtxtAccountID";
            this.m_dgvtxtAccountID.ReadOnly = true;
            this.m_dgvtxtAccountID.Width = 150;
            // 
            // m_dgvtxtBeginDate
            // 
            this.m_dgvtxtBeginDate.DataPropertyName = "starttime_dat";
            dataGridViewCellStyle5.Format = "F";
            dataGridViewCellStyle5.NullValue = null;
            this.m_dgvtxtBeginDate.DefaultCellStyle = dataGridViewCellStyle5;
            this.m_dgvtxtBeginDate.HeaderText = "开始时间";
            this.m_dgvtxtBeginDate.Name = "m_dgvtxtBeginDate";
            this.m_dgvtxtBeginDate.ReadOnly = true;
            this.m_dgvtxtBeginDate.Width = 180;
            // 
            // m_dgvtxtEndDate
            // 
            this.m_dgvtxtEndDate.DataPropertyName = "endtime_dat";
            dataGridViewCellStyle6.Format = "F";
            dataGridViewCellStyle6.NullValue = null;
            this.m_dgvtxtEndDate.DefaultCellStyle = dataGridViewCellStyle6;
            this.m_dgvtxtEndDate.HeaderText = "结束时间";
            this.m_dgvtxtEndDate.Name = "m_dgvtxtEndDate";
            this.m_dgvtxtEndDate.ReadOnly = true;
            this.m_dgvtxtEndDate.Width = 180;
            // 
            // m_dgvtxtComment
            // 
            this.m_dgvtxtComment.DataPropertyName = "comment_vchr";
            this.m_dgvtxtComment.HeaderText = "备注";
            this.m_dgvtxtComment.Name = "m_dgvtxtComment";
            this.m_dgvtxtComment.ReadOnly = true;
            this.m_dgvtxtComment.Width = 450;
            // 
            // m_bgwGetData
            // 
            this.m_bgwGetData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.m_bgwGetData_DoWork);
            this.m_bgwGetData.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.m_bgwGetData_RunWorkerCompleted);
            // 
            // m_cmdCancel
            // 
            this.m_cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdCancel.ImageIndex = 2;
            this.m_cmdCancel.ImageList = this.imageList1;
            this.m_cmdCancel.Location = new System.Drawing.Point(105, 12);
            this.m_cmdCancel.Name = "m_cmdCancel";
            this.m_cmdCancel.Size = new System.Drawing.Size(116, 28);
            this.m_cmdCancel.TabIndex = 96;
            this.m_cmdCancel.Text = "取消结转(&U)";
            this.m_cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdCancel.UseVisualStyleBackColor = true;
            this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
            // 
            // m_cmdPrint
            // 
            this.m_cmdPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdPrint.ImageIndex = 6;
            this.m_cmdPrint.ImageList = this.imageList2;
            this.m_cmdPrint.Location = new System.Drawing.Point(215, 12);
            this.m_cmdPrint.Name = "m_cmdPrint";
            this.m_cmdPrint.Size = new System.Drawing.Size(94, 28);
            this.m_cmdPrint.TabIndex = 99;
            this.m_cmdPrint.Text = "打印(&P)";
            this.m_cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdPrint.UseVisualStyleBackColor = true;
            this.m_cmdPrint.Click += new System.EventHandler(this.m_cmdPrint_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "Shell32 007.ico");
            this.imageList2.Images.SetKeyName(1, "Shell32 028.ico");
            this.imageList2.Images.SetKeyName(2, "Shell32 132.ico");
            this.imageList2.Images.SetKeyName(3, "Shell32 148.ico");
            this.imageList2.Images.SetKeyName(4, "Shell32 058.ico");
            this.imageList2.Images.SetKeyName(5, "m_cmdRefresh.Image.png");
            this.imageList2.Images.SetKeyName(6, "Shell32 137.ico");
            this.imageList2.Images.SetKeyName(7, "Shell32 177.ico");
            this.imageList2.Images.SetKeyName(8, "Shell32 136.ico");
            this.imageList2.Images.SetKeyName(9, "Shell32 055.ico");
            this.imageList2.Images.SetKeyName(10, "Shell32 147.ico");
            this.imageList2.Images.SetKeyName(11, "Shell32 133.ico");
            this.imageList2.Images.SetKeyName(12, "Shell32 088.ico");
            this.imageList2.Images.SetKeyName(13, "Shell32 023.ico");
            // 
            // frmAccountPeriod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 634);
            this.Controls.Add(this.m_cmdPrint);
            this.Controls.Add(this.m_dgvAccountData);
            this.Controls.Add(this.m_cmdExit);
            this.Controls.Add(this.m_cmdCancel);
            this.Controls.Add(this.m_cmdAccount);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAccountPeriod";
            this.Text = "帐务期结转";
            this.Load += new System.EventHandler(this.frmAccountPeriod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvAccountData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button m_cmdExit;
        private System.Windows.Forms.Button m_cmdAccount;
        private System.ComponentModel.BackgroundWorker m_bgwGetData;
        internal System.Windows.Forms.DataGridView m_dgvAccountData;
        private System.Windows.Forms.Button m_cmdCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtAccountID;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtBeginDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtComment;
        private System.Windows.Forms.Button m_cmdPrint;
        private System.Windows.Forms.ImageList imageList2;

    }
}