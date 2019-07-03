namespace com.digitalwave.iCare.gui.HIS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccountPeriod));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.m_bgwGetData = new System.ComponentModel.BackgroundWorker();
            this.m_bgwGenerateAccount = new System.ComponentModel.BackgroundWorker();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.m_txtRemark = new System.Windows.Forms.ToolStripTextBox();
            this.m_btnTransfer = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnClose = new System.Windows.Forms.ToolStripButton();
            this.m_dgvAccountPeriod = new System.Windows.Forms.DataGridView();
            this.m_dgvtxtSortNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtPeriodid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtBeginTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxttransfertime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtdrugstoreid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtSeriesid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvAccountPeriod)).BeginInit();
            this.SuspendLayout();
            // 
            // m_bgwGetData
            // 
            this.m_bgwGetData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.m_bgwGetData_DoWork);
            this.m_bgwGetData.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.m_bgwGetData_RunWorkerCompleted);
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.toolStrip2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator3,
            this.toolStripLabel3,
            this.m_txtRemark,
            this.m_btnTransfer,
            this.toolStripSeparator8,
            this.m_btnRefresh,
            this.toolStripSeparator4,
            this.m_btnClose});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1016, 41);
            this.toolStrip2.TabIndex = 114;
            this.toolStrip2.Text = "toolStrip1";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(0, 38);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.AutoSize = false;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(0, 44);
            this.toolStripLabel3.Text = "备注";
            this.toolStripLabel3.Visible = false;
            // 
            // m_txtRemark
            // 
            this.m_txtRemark.AutoSize = false;
            this.m_txtRemark.BackColor = System.Drawing.SystemColors.Info;
            this.m_txtRemark.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtRemark.Name = "m_txtRemark";
            this.m_txtRemark.Size = new System.Drawing.Size(0, 25);
            this.m_txtRemark.Visible = false;
            // 
            // m_btnTransfer
            // 
            this.m_btnTransfer.Image = ((System.Drawing.Image)(resources.GetObject("m_btnTransfer.Image")));
            this.m_btnTransfer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_btnTransfer.Name = "m_btnTransfer";
            this.m_btnTransfer.Size = new System.Drawing.Size(104, 38);
            this.m_btnTransfer.Text = "药房结转(&T)";
            this.m_btnTransfer.Click += new System.EventHandler(this.m_btnTransfer_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 41);
            // 
            // m_btnRefresh
            // 
            this.m_btnRefresh.AutoSize = false;
            this.m_btnRefresh.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("m_btnRefresh.Image")));
            this.m_btnRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnRefresh.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_btnRefresh.Name = "m_btnRefresh";
            this.m_btnRefresh.Size = new System.Drawing.Size(110, 44);
            this.m_btnRefresh.Text = "刷新数据(&R)";
            this.m_btnRefresh.Click += new System.EventHandler(this.m_btnRefresh_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 41);
            // 
            // m_btnClose
            // 
            this.m_btnClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnClose.Image = ((System.Drawing.Image)(resources.GetObject("m_btnClose.Image")));
            this.m_btnClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnClose.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_btnClose.Name = "m_btnClose";
            this.m_btnClose.Size = new System.Drawing.Size(104, 38);
            this.m_btnClose.Text = "关闭窗口(&Q)";
            this.m_btnClose.Click += new System.EventHandler(this.m_btnExit_Click);
            // 
            // m_dgvAccountPeriod
            // 
            this.m_dgvAccountPeriod.AllowUserToAddRows = false;
            this.m_dgvAccountPeriod.AllowUserToDeleteRows = false;
            this.m_dgvAccountPeriod.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Linen;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.m_dgvAccountPeriod.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.m_dgvAccountPeriod.BackgroundColor = System.Drawing.SystemColors.Control;
            this.m_dgvAccountPeriod.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_dgvAccountPeriod.ColumnHeadersHeight = 30;
            this.m_dgvAccountPeriod.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_dgvtxtSortNum,
            this.m_dgvtxtPeriodid,
            this.m_dgvtxtBeginTime,
            this.m_dgvtxtEndTime,
            this.m_dgvtxttransfertime,
            this.m_dgvtxtRemark,
            this.m_dgvtxtdrugstoreid,
            this.m_dgvtxtSeriesid});
            this.m_dgvAccountPeriod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvAccountPeriod.Location = new System.Drawing.Point(0, 41);
            this.m_dgvAccountPeriod.MultiSelect = false;
            this.m_dgvAccountPeriod.Name = "m_dgvAccountPeriod";
            this.m_dgvAccountPeriod.ReadOnly = true;
            this.m_dgvAccountPeriod.RowHeadersVisible = false;
            this.m_dgvAccountPeriod.RowTemplate.DefaultCellStyle.NullValue = null;
            this.m_dgvAccountPeriod.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Black;
            this.m_dgvAccountPeriod.RowTemplate.Height = 23;
            this.m_dgvAccountPeriod.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvAccountPeriod.Size = new System.Drawing.Size(1016, 366);
            this.m_dgvAccountPeriod.TabIndex = 115;
            this.m_dgvAccountPeriod.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.m_dgvAccountPeriod_RowsAdded);
            this.m_dgvAccountPeriod.DoubleClick += new System.EventHandler(this.m_dgvAccountPeriod_DoubleClick);
            this.m_dgvAccountPeriod.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.m_dgvAccountPeriod_RowsRemoved);
            // 
            // m_dgvtxtSortNum
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.m_dgvtxtSortNum.DefaultCellStyle = dataGridViewCellStyle2;
            this.m_dgvtxtSortNum.HeaderText = "No.";
            this.m_dgvtxtSortNum.Name = "m_dgvtxtSortNum";
            this.m_dgvtxtSortNum.ReadOnly = true;
            this.m_dgvtxtSortNum.Width = 35;
            // 
            // m_dgvtxtPeriodid
            // 
            this.m_dgvtxtPeriodid.DataPropertyName = "accountid_chr";
            this.m_dgvtxtPeriodid.HeaderText = "帐务期";
            this.m_dgvtxtPeriodid.Name = "m_dgvtxtPeriodid";
            this.m_dgvtxtPeriodid.ReadOnly = true;
            this.m_dgvtxtPeriodid.Width = 120;
            // 
            // m_dgvtxtBeginTime
            // 
            this.m_dgvtxtBeginTime.DataPropertyName = "starttime_dat";
            dataGridViewCellStyle3.Format = "yyyy年MM月dd日 HH:mm:ss";
            dataGridViewCellStyle3.NullValue = null;
            this.m_dgvtxtBeginTime.DefaultCellStyle = dataGridViewCellStyle3;
            this.m_dgvtxtBeginTime.HeaderText = "开始时间";
            this.m_dgvtxtBeginTime.Name = "m_dgvtxtBeginTime";
            this.m_dgvtxtBeginTime.ReadOnly = true;
            this.m_dgvtxtBeginTime.Width = 200;
            // 
            // m_dgvtxtEndTime
            // 
            this.m_dgvtxtEndTime.DataPropertyName = "endtime_dat";
            dataGridViewCellStyle4.Format = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dgvtxtEndTime.DefaultCellStyle = dataGridViewCellStyle4;
            this.m_dgvtxtEndTime.HeaderText = "结束时间";
            this.m_dgvtxtEndTime.Name = "m_dgvtxtEndTime";
            this.m_dgvtxtEndTime.ReadOnly = true;
            this.m_dgvtxtEndTime.Width = 200;
            // 
            // m_dgvtxttransfertime
            // 
            this.m_dgvtxttransfertime.DataPropertyName = "transfertime_dat";
            dataGridViewCellStyle5.Format = "yyyy年MM月dd日 HH:mm:ss";
            dataGridViewCellStyle5.NullValue = null;
            this.m_dgvtxttransfertime.DefaultCellStyle = dataGridViewCellStyle5;
            this.m_dgvtxttransfertime.HeaderText = "结转时间";
            this.m_dgvtxttransfertime.Name = "m_dgvtxttransfertime";
            this.m_dgvtxttransfertime.ReadOnly = true;
            this.m_dgvtxttransfertime.Width = 460;
            // 
            // m_dgvtxtRemark
            // 
            this.m_dgvtxtRemark.DataPropertyName = "comment_vchr";
            this.m_dgvtxtRemark.HeaderText = "备注";
            this.m_dgvtxtRemark.Name = "m_dgvtxtRemark";
            this.m_dgvtxtRemark.ReadOnly = true;
            this.m_dgvtxtRemark.Visible = false;
            this.m_dgvtxtRemark.Width = 320;
            // 
            // m_dgvtxtdrugstoreid
            // 
            this.m_dgvtxtdrugstoreid.DataPropertyName = "drugstoreid_chr";
            this.m_dgvtxtdrugstoreid.HeaderText = "药房id";
            this.m_dgvtxtdrugstoreid.Name = "m_dgvtxtdrugstoreid";
            this.m_dgvtxtdrugstoreid.ReadOnly = true;
            this.m_dgvtxtdrugstoreid.Visible = false;
            // 
            // m_dgvtxtSeriesid
            // 
            this.m_dgvtxtSeriesid.DataPropertyName = "seriesid_int";
            this.m_dgvtxtSeriesid.HeaderText = "序列号";
            this.m_dgvtxtSeriesid.Name = "m_dgvtxtSeriesid";
            this.m_dgvtxtSeriesid.ReadOnly = true;
            this.m_dgvtxtSeriesid.Visible = false;
            // 
            // frmAccountPeriod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 407);
            this.Controls.Add(this.m_dgvAccountPeriod);
            this.Controls.Add(this.toolStrip2);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAccountPeriod";
            this.Text = "药房帐务期结转";
            this.Load += new System.EventHandler(this.frmAccountPeriod_Load);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvAccountPeriod)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker m_bgwGetData;
        internal System.Windows.Forms.ToolStrip toolStrip2;
        internal System.Windows.Forms.ToolStripLabel toolStripSeparator3;
        internal System.Windows.Forms.ToolStripLabel toolStripLabel3;
        internal System.Windows.Forms.ToolStripTextBox m_txtRemark;
        internal System.Windows.Forms.ToolStripButton m_btnTransfer;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        internal System.Windows.Forms.ToolStripButton m_btnClose;
        private System.ComponentModel.BackgroundWorker m_bgwGenerateAccount;
        internal System.Windows.Forms.ToolStripButton m_btnRefresh;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        internal System.Windows.Forms.DataGridView m_dgvAccountPeriod;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtSortNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtPeriodid;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtBeginTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtEndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxttransfertime;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtdrugstoreid;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtSeriesid;
    }
}