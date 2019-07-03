namespace iCare
{
    partial class frmMiniBooldSugar
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
            this.dgvRecords = new System.Windows.Forms.DataGridView();
            this.colRecordTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMealType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSigner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctmOperation = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmModify = new System.Windows.Forms.ToolStripMenuItem();
            this.txtDelete = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRecordDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtbRecords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).BeginInit();
            this.ctmOperation.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_dtgRecordDetail
            // 
            this.m_dtgRecordDetail.BackgroundColor = System.Drawing.Color.White;
            this.m_dtgRecordDetail.DataSource = this.m_dtbRecords;
            this.m_dtgRecordDetail.Location = new System.Drawing.Point(12, 436);
            this.m_dtgRecordDetail.SelectionBackColor = System.Drawing.SystemColors.Control;
            this.m_dtgRecordDetail.Size = new System.Drawing.Size(773, 115);
            // 
            // m_trvInPatientDate
            // 
            this.m_trvInPatientDate.BackColor = System.Drawing.Color.White;
            this.m_trvInPatientDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_trvInPatientDate.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_trvInPatientDate.LineColor = System.Drawing.Color.Black;
            this.m_trvInPatientDate.Location = new System.Drawing.Point(15, 5);
            this.m_trvInPatientDate.Size = new System.Drawing.Size(197, 58);
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Location = new System.Drawing.Point(634, 46);
            this.lblSex.Size = new System.Drawing.Size(0, 14);
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(715, 45);
            this.lblAge.Size = new System.Drawing.Size(0, 14);
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(418, 8);
            this.lblBedNoTitle.Size = new System.Drawing.Size(56, 14);
            this.lblBedNoTitle.Text = "床  号:";
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(418, 45);
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(586, 10);
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(586, 46);
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(667, 46);
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(221, 45);
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(472, 40);
            this.txtInPatientID.Size = new System.Drawing.Size(112, 23);
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(624, 7);
            this.m_txtPatientName.Size = new System.Drawing.Size(98, 23);
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(472, 6);
            this.m_txtBedNO.Size = new System.Drawing.Size(89, 23);
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(269, 41);
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(269, 5);
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(221, 13);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.m_cmdNext.Location = new System.Drawing.Point(560, 7);
            this.m_cmdNext.Visible = true;
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(122, 24);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(18, 24);
            this.m_lblForTitle.Size = new System.Drawing.Size(98, 40);
            this.m_lblForTitle.Text = "";
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(28, 21);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(728, 6);
            // 
            // dgvRecords
            // 
            this.dgvRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRecordTime,
            this.colMealType,
            this.colValue,
            this.colSigner,
            this.colDescription});
            this.dgvRecords.ContextMenuStrip = this.ctmOperation;
            this.dgvRecords.Location = new System.Drawing.Point(18, 80);
            this.dgvRecords.Name = "dgvRecords";
            this.dgvRecords.ReadOnly = true;
            this.dgvRecords.RowTemplate.Height = 23;
            this.dgvRecords.Size = new System.Drawing.Size(773, 297);
            this.dgvRecords.TabIndex = 10000005;
            // 
            // colRecordTime
            // 
            this.colRecordTime.HeaderText = "记录时间";
            this.colRecordTime.MaxInputLength = 100;
            this.colRecordTime.Name = "colRecordTime";
            this.colRecordTime.ReadOnly = true;
            this.colRecordTime.Width = 120;
            // 
            // colMealType
            // 
            this.colMealType.HeaderText = "餐时备注";
            this.colMealType.MaxInputLength = 100;
            this.colMealType.Name = "colMealType";
            this.colMealType.ReadOnly = true;
            this.colMealType.Width = 120;
            // 
            // colValue
            // 
            this.colValue.HeaderText = "微量血糖(mmol/L)";
            this.colValue.MaxInputLength = 50;
            this.colValue.Name = "colValue";
            this.colValue.ReadOnly = true;
            // 
            // colSigner
            // 
            this.colSigner.HeaderText = "检测者签名";
            this.colSigner.MaxInputLength = 50;
            this.colSigner.Name = "colSigner";
            this.colSigner.ReadOnly = true;
            this.colSigner.Width = 120;
            // 
            // colDescription
            // 
            this.colDescription.HeaderText = "备注";
            this.colDescription.MaxInputLength = 250;
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            // 
            // ctmOperation
            // 
            this.ctmOperation.AccessibleDescription = "右键菜单";
            this.ctmOperation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAdd,
            this.tsmModify,
            this.txtDelete});
            this.ctmOperation.Name = "ctmOperation";
            this.ctmOperation.Size = new System.Drawing.Size(123, 70);
            // 
            // tsmAdd
            // 
            this.tsmAdd.AccessibleDescription = "添加记录";
            this.tsmAdd.Name = "tsmAdd";
            this.tsmAdd.Size = new System.Drawing.Size(122, 22);
            this.tsmAdd.Text = "添加记录";
            this.tsmAdd.Click += new System.EventHandler(this.tsmAdd_Click);
            // 
            // tsmModify
            // 
            this.tsmModify.AccessibleDescription = "修改记录";
            this.tsmModify.Name = "tsmModify";
            this.tsmModify.Size = new System.Drawing.Size(122, 22);
            this.tsmModify.Text = "修改记录";
            this.tsmModify.Click += new System.EventHandler(this.tsmModify_Click);
            // 
            // txtDelete
            // 
            this.txtDelete.AccessibleDescription = "删除记录";
            this.txtDelete.Name = "txtDelete";
            this.txtDelete.Size = new System.Drawing.Size(122, 22);
            this.txtDelete.Text = "删除记录";
            this.txtDelete.Click += new System.EventHandler(this.txtDelete_Click);
            // 
            // frmMiniBooldSugar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 563);
            this.Controls.Add(this.dgvRecords);
            this.Name = "frmMiniBooldSugar";
            this.Text = "微量血糖检测结果记录";
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.m_dtgRecordDetail, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.dgvRecords, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.m_trvInPatientDate, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRecordDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtbRecords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).EndInit();
            this.ctmOperation.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRecords;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRecordTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMealType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSigner;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.ContextMenuStrip ctmOperation;
        private System.Windows.Forms.ToolStripMenuItem tsmAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmModify;
        private System.Windows.Forms.ToolStripMenuItem txtDelete;
    }
}