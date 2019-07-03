namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmNoteAndExpExcel
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNoteAndExpExcel));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_dgvDetail = new com.digitalwave.controls.MedicineStoreControls.ctlDataGridView_EnterAsTab();
            this.m_btnOK = new System.Windows.Forms.Button();
            this.m_btnExportToExcel = new System.Windows.Forms.Button();
            this.m_lblNote = new System.Windows.Forms.Label();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.m_dgvDetail);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.m_lblNote);
            this.splitContainer1.Panel2.Controls.Add(this.m_btnOK);
            this.splitContainer1.Panel2.Controls.Add(this.m_btnExportToExcel);
            this.splitContainer1.Size = new System.Drawing.Size(992, 381);
            this.splitContainer1.SplitterDistance = 338;
            this.splitContainer1.TabIndex = 0;
            // 
            // m_dgvDetail
            // 
            this.m_dgvDetail.AllowUserToAddRows = false;
            this.m_dgvDetail.AllowUserToDeleteRows = false;
            this.m_dgvDetail.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Linen;
            this.m_dgvDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.m_dgvDetail.BackgroundColor = System.Drawing.SystemColors.Window;
            this.m_dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.m_dgvDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.m_dgvDetail.ColumnHeadersHeight = 30;
            this.m_dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.m_dgvDetail.Location = new System.Drawing.Point(0, 0);
            this.m_dgvDetail.Name = "m_dgvDetail";
            this.m_dgvDetail.RowHeadersVisible = false;
            this.m_dgvDetail.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.m_dgvDetail.RowTemplate.Height = 24;
            this.m_dgvDetail.Size = new System.Drawing.Size(992, 338);
            this.m_dgvDetail.TabIndex = 6;
            // 
            // m_btnOK
            // 
            this.m_btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnOK.Location = new System.Drawing.Point(547, 3);
            this.m_btnOK.Name = "m_btnOK";
            this.m_btnOK.Size = new System.Drawing.Size(159, 32);
            this.m_btnOK.TabIndex = 1;
            this.m_btnOK.Text = "关闭(&C)";
            this.m_btnOK.UseVisualStyleBackColor = true;
            this.m_btnOK.Click += new System.EventHandler(this.m_btnOK_Click);
            // 
            // m_btnExportToExcel
            // 
            this.m_btnExportToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnExportToExcel.Location = new System.Drawing.Point(226, 4);
            this.m_btnExportToExcel.Name = "m_btnExportToExcel";
            this.m_btnExportToExcel.Size = new System.Drawing.Size(159, 32);
            this.m_btnExportToExcel.TabIndex = 0;
            this.m_btnExportToExcel.Text = "导出到Excel(&E)";
            this.m_btnExportToExcel.UseVisualStyleBackColor = true;
            this.m_btnExportToExcel.Click += new System.EventHandler(this.m_btnExportToExcel_Click);
            // 
            // m_lblNote
            // 
            this.m_lblNote.AutoSize = true;
            this.m_lblNote.ForeColor = System.Drawing.Color.Red;
            this.m_lblNote.Location = new System.Drawing.Point(33, 11);
            this.m_lblNote.Name = "m_lblNote";
            this.m_lblNote.Size = new System.Drawing.Size(98, 14);
            this.m_lblNote.TabIndex = 2;
            this.m_lblNote.Text = "总共有n行数据";
            // 
            // frmNoteAndExpExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 381);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNoteAndExpExcel";
            this.Text = "注意：以下药品未能出库";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button m_btnExportToExcel;
        internal com.digitalwave.controls.MedicineStoreControls.ctlDataGridView_EnterAsTab m_dgvDetail;
        private System.Windows.Forms.Button m_btnOK;
        internal System.Windows.Forms.Label m_lblNote;
    }
}