namespace com.digitalwave.iCare.gui.MedicineStore
{
    partial class frmStockAutoGenerate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStockAutoGenerate));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_btnCancle = new System.Windows.Forms.Button();
            this.m_btnRefresh = new System.Windows.Forms.Button();
            this.m_btnGenerate = new System.Windows.Forms.Button();
            this.m_lblSelected = new System.Windows.Forms.Label();
            this.m_dgvDrugStorage = new System.Windows.Forms.DataGridView();
            this.m_cbxShowStop = new System.Windows.Forms.CheckBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvDrugStorage)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.m_cbxShowStop);
            this.splitContainer1.Panel1.Controls.Add(this.m_btnCancle);
            this.splitContainer1.Panel1.Controls.Add(this.m_btnRefresh);
            this.splitContainer1.Panel1.Controls.Add(this.m_btnGenerate);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.m_lblSelected);
            this.splitContainer1.Panel2.Controls.Add(this.m_dgvDrugStorage);
            this.splitContainer1.Size = new System.Drawing.Size(1016, 741);
            this.splitContainer1.SplitterDistance = 59;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // m_btnCancle
            // 
            this.m_btnCancle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnCancle.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_btnCancle.Image = ((System.Drawing.Image)(resources.GetObject("m_btnCancle.Image")));
            this.m_btnCancle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_btnCancle.Location = new System.Drawing.Point(897, 7);
            this.m_btnCancle.Name = "m_btnCancle";
            this.m_btnCancle.Size = new System.Drawing.Size(87, 38);
            this.m_btnCancle.TabIndex = 2;
            this.m_btnCancle.Text = "退出(&Q)";
            this.m_btnCancle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_btnCancle.UseVisualStyleBackColor = true;
            this.m_btnCancle.Click += new System.EventHandler(this.m_btnCancle_Click);
            // 
            // m_btnRefresh
            // 
            this.m_btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnRefresh.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("m_btnRefresh.Image")));
            this.m_btnRefresh.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.m_btnRefresh.Location = new System.Drawing.Point(12, 7);
            this.m_btnRefresh.Name = "m_btnRefresh";
            this.m_btnRefresh.Size = new System.Drawing.Size(87, 38);
            this.m_btnRefresh.TabIndex = 0;
            this.m_btnRefresh.Text = "刷新(&R)";
            this.m_btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_btnRefresh.UseVisualStyleBackColor = true;
            this.m_btnRefresh.Click += new System.EventHandler(this.m_btnRefresh_Click);
            // 
            // m_btnGenerate
            // 
            this.m_btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnGenerate.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_btnGenerate.Image = ((System.Drawing.Image)(resources.GetObject("m_btnGenerate.Image")));
            this.m_btnGenerate.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.m_btnGenerate.Location = new System.Drawing.Point(99, 7);
            this.m_btnGenerate.Name = "m_btnGenerate";
            this.m_btnGenerate.Size = new System.Drawing.Size(87, 38);
            this.m_btnGenerate.TabIndex = 1;
            this.m_btnGenerate.Text = "生成(&G)";
            this.m_btnGenerate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_btnGenerate.UseVisualStyleBackColor = true;
            this.m_btnGenerate.Click += new System.EventHandler(this.m_btnGenerate_Click);
            // 
            // m_lblSelected
            // 
            this.m_lblSelected.BackColor = System.Drawing.Color.Transparent;
            this.m_lblSelected.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblSelected.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.m_lblSelected.Location = new System.Drawing.Point(1, 1);
            this.m_lblSelected.Name = "m_lblSelected";
            this.m_lblSelected.Size = new System.Drawing.Size(20, 30);
            this.m_lblSelected.TabIndex = 11;
            this.m_lblSelected.Tag = "False";
            this.m_lblSelected.Text = "反选";
            this.m_lblSelected.Click += new System.EventHandler(this.m_lblSelected_Click);
            // 
            // m_dgvDrugStorage
            // 
            this.m_dgvDrugStorage.AllowUserToAddRows = false;
            this.m_dgvDrugStorage.AllowUserToDeleteRows = false;
            this.m_dgvDrugStorage.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.OldLace;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dgvDrugStorage.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.m_dgvDrugStorage.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.m_dgvDrugStorage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 10.5F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.m_dgvDrugStorage.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.m_dgvDrugStorage.ColumnHeadersHeight = 34;
            this.m_dgvDrugStorage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgvDrugStorage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvDrugStorage.Location = new System.Drawing.Point(0, 0);
            this.m_dgvDrugStorage.MultiSelect = false;
            this.m_dgvDrugStorage.Name = "m_dgvDrugStorage";
            this.m_dgvDrugStorage.RowHeadersVisible = false;
            this.m_dgvDrugStorage.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.m_dgvDrugStorage.RowTemplate.Height = 23;
            this.m_dgvDrugStorage.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvDrugStorage.Size = new System.Drawing.Size(1016, 677);
            this.m_dgvDrugStorage.StandardTab = true;
            this.m_dgvDrugStorage.TabIndex = 12;
            // 
            // m_cbxShowStop
            // 
            this.m_cbxShowStop.AutoSize = true;
            this.m_cbxShowStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cbxShowStop.Location = new System.Drawing.Point(215, 31);
            this.m_cbxShowStop.Name = "m_cbxShowStop";
            this.m_cbxShowStop.Size = new System.Drawing.Size(93, 18);
            this.m_cbxShowStop.TabIndex = 3;
            this.m_cbxShowStop.Text = "显示停用药";
            this.m_cbxShowStop.UseVisualStyleBackColor = true;
            this.m_cbxShowStop.Visible = false;
            // 
            // frmStockAutoGenerate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 741);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmStockAutoGenerate";
            this.Text = "自动生成采购单";
            this.Load += new System.EventHandler(this.frmStockAutoGenerate_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvDrugStorage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_btnGenerate;
        private System.Windows.Forms.Button m_btnCancle;
        internal System.Windows.Forms.Label m_lblSelected;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button m_btnRefresh;
        internal System.Windows.Forms.DataGridView m_dgvDrugStorage;
        private System.Windows.Forms.CheckBox m_cbxShowStop;
    }
}