namespace com.digitalwave.iCare.gui.HIS.Viewer
{
    partial class frmDSAccountPeriod
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDSAccountPeriod));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.m_dgvAccountData = new System.Windows.Forms.DataGridView();
            this.m_dgvtxtAccountID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtBeginDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_btnSave = new System.Windows.Forms.ToolStripButton();
            this.m_btnNext = new System.Windows.Forms.ToolStripButton();
            this.m_btnPrint = new System.Windows.Forms.ToolStripButton();
            this.m_btnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvAccountData)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_btnSave,
            this.toolStripSeparator1,
            this.m_btnNext,
            this.toolStripSeparator3,
            this.m_btnPrint,
            this.toolStripSeparator5,
            this.m_btnExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1016, 37);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 37);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 37);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 37);
            // 
            // m_dgvAccountData
            // 
            this.m_dgvAccountData.AllowUserToAddRows = false;
            this.m_dgvAccountData.AllowUserToDeleteRows = false;
            this.m_dgvAccountData.AllowUserToResizeColumns = false;
            this.m_dgvAccountData.BackgroundColor = System.Drawing.Color.White;
            this.m_dgvAccountData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_dgvAccountData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgvAccountData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.m_dgvAccountData.ColumnHeadersHeight = 28;
            this.m_dgvAccountData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgvAccountData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_dgvtxtAccountID,
            this.m_dgvtxtBeginDate,
            this.m_dgvtxtEndDate,
            this.m_dgvtxtComment});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.m_dgvAccountData.DefaultCellStyle = dataGridViewCellStyle4;
            this.m_dgvAccountData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvAccountData.Location = new System.Drawing.Point(0, 37);
            this.m_dgvAccountData.MultiSelect = false;
            this.m_dgvAccountData.Name = "m_dgvAccountData";
            this.m_dgvAccountData.RowHeadersVisible = false;
            this.m_dgvAccountData.RowTemplate.Height = 23;
            this.m_dgvAccountData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvAccountData.Size = new System.Drawing.Size(1016, 704);
            this.m_dgvAccountData.TabIndex = 99;
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
            dataGridViewCellStyle2.Format = "F";
            dataGridViewCellStyle2.NullValue = null;
            this.m_dgvtxtBeginDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.m_dgvtxtBeginDate.HeaderText = "开始时间";
            this.m_dgvtxtBeginDate.Name = "m_dgvtxtBeginDate";
            this.m_dgvtxtBeginDate.ReadOnly = true;
            this.m_dgvtxtBeginDate.Width = 180;
            // 
            // m_dgvtxtEndDate
            // 
            this.m_dgvtxtEndDate.DataPropertyName = "endtime_dat";
            dataGridViewCellStyle3.Format = "F";
            dataGridViewCellStyle3.NullValue = null;
            this.m_dgvtxtEndDate.DefaultCellStyle = dataGridViewCellStyle3;
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
            this.m_dgvtxtComment.Width = 510;
            // 
            // m_btnSave
            // 
            this.m_btnSave.AutoSize = false;
            this.m_btnSave.Image = ((System.Drawing.Image)(resources.GetObject("m_btnSave.Image")));
            this.m_btnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnSave.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Size = new System.Drawing.Size(80, 32);
            this.m_btnSave.Text = "结转(&G)";
            this.m_btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_btnNext
            // 
            this.m_btnNext.AutoSize = false;
            this.m_btnNext.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnNext.Image = ((System.Drawing.Image)(resources.GetObject("m_btnNext.Image")));
            this.m_btnNext.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnNext.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_btnNext.Name = "m_btnNext";
            this.m_btnNext.Size = new System.Drawing.Size(105, 32);
            this.m_btnNext.Text = "取消结转(&U)";
            // 
            // m_btnPrint
            // 
            this.m_btnPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("m_btnPrint.Image")));
            this.m_btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_btnPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnPrint.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_btnPrint.Name = "m_btnPrint";
            this.m_btnPrint.Size = new System.Drawing.Size(76, 34);
            this.m_btnPrint.Text = "打印(&P)";
            // 
            // m_btnExit
            // 
            this.m_btnExit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnExit.Image = ((System.Drawing.Image)(resources.GetObject("m_btnExit.Image")));
            this.m_btnExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnExit.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_btnExit.Name = "m_btnExit";
            this.m_btnExit.Size = new System.Drawing.Size(76, 34);
            this.m_btnExit.Text = "关闭(&Q)";
            // 
            // frmDSAccountPeriod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 741);
            this.Controls.Add(this.m_dgvAccountData);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDSAccountPeriod";
            this.Text = "门诊药房帐务期结转";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvAccountData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton m_btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        internal System.Windows.Forms.ToolStripButton m_btnPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        internal System.Windows.Forms.ToolStripButton m_btnNext;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton m_btnExit;
        internal System.Windows.Forms.DataGridView m_dgvAccountData;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtAccountID;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtBeginDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtComment;
    }
}