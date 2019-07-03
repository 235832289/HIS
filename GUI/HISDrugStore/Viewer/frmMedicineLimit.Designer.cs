namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmMedicineLimit
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMedicineLimit));
            this.m_dgvDrugLimit = new com.digitalwave.controls.MedicineStoreControls.ctlDataGridView_EnterAsTab();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.m_cbbDrugType = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.m_txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnQuery = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtondataout = new System.Windows.Forms.ToolStripButton();
            this.m_btnExit = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvDrugLimit)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_dgvDrugLimit
            // 
            this.m_dgvDrugLimit.AllowUserToAddRows = false;
            this.m_dgvDrugLimit.AllowUserToDeleteRows = false;
            this.m_dgvDrugLimit.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.OldLace;
            this.m_dgvDrugLimit.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.m_dgvDrugLimit.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.m_dgvDrugLimit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.m_dgvDrugLimit.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.m_dgvDrugLimit.ColumnHeadersHeight = 34;
            this.m_dgvDrugLimit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.m_dgvDrugLimit.DefaultCellStyle = dataGridViewCellStyle3;
            this.m_dgvDrugLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvDrugLimit.Location = new System.Drawing.Point(0, 38);
            this.m_dgvDrugLimit.MultiSelect = false;
            this.m_dgvDrugLimit.Name = "m_dgvDrugLimit";
            this.m_dgvDrugLimit.RowHeadersVisible = false;
            this.m_dgvDrugLimit.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.m_dgvDrugLimit.RowTemplate.Height = 23;
            this.m_dgvDrugLimit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvDrugLimit.Size = new System.Drawing.Size(910, 434);
            this.m_dgvDrugLimit.TabIndex = 1;
            this.m_dgvDrugLimit.EnterKeyPress += new com.digitalwave.controls.MedicineStoreControls.EnterKeyPressInCurrentCell(this.m_dgvDrugLimit_EnterKeyPress);
            this.m_dgvDrugLimit.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.m_dgvDrugLimit_CellMouseUp);
            this.m_dgvDrugLimit.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.m_dgvDrugLimit_DataError);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.m_cbbDrugType,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this.m_txtSearch,
            this.toolStripSeparator4,
            this.m_btnQuery,
            this.toolStripSeparator6,
            this.m_btnPrint,
            this.toolStripSeparator8,
            this.m_btnSave,
            this.toolStripSeparator1,
            this.toolStripButtondataout,
            this.m_btnExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(910, 38);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(35, 35);
            this.toolStripLabel1.Text = "类型";
            // 
            // m_cbbDrugType
            // 
            this.m_cbbDrugType.Font = new System.Drawing.Font("Tahoma", 10.5F);
            this.m_cbbDrugType.Name = "m_cbbDrugType";
            this.m_cbbDrugType.Size = new System.Drawing.Size(121, 38);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(35, 35);
            this.toolStripLabel2.Text = "定位";
            // 
            // m_txtSearch
            // 
            this.m_txtSearch.Font = new System.Drawing.Font("Tahoma", 10.5F);
            this.m_txtSearch.Name = "m_txtSearch";
            this.m_txtSearch.Size = new System.Drawing.Size(200, 38);
            this.m_txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtSearch_KeyDown);
            this.m_txtSearch.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_txtSearch_MouseDown);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 38);
            // 
            // m_btnQuery
            // 
            this.m_btnQuery.AutoSize = false;
            this.m_btnQuery.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnQuery.Image = ((System.Drawing.Image)(resources.GetObject("m_btnQuery.Image")));
            this.m_btnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_btnQuery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnQuery.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_btnQuery.Name = "m_btnQuery";
            this.m_btnQuery.Size = new System.Drawing.Size(80, 33);
            this.m_btnQuery.Text = "查询(&F)";
            this.m_btnQuery.Click += new System.EventHandler(this.m_btnQuery_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 38);
            // 
            // m_btnPrint
            // 
            this.m_btnPrint.AutoSize = false;
            this.m_btnPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_btnPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnPrint.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_btnPrint.Name = "m_btnPrint";
            this.m_btnPrint.Size = new System.Drawing.Size(80, 32);
            this.m_btnPrint.Text = "打印(&P)";
            this.m_btnPrint.Visible = false;
            this.m_btnPrint.Click += new System.EventHandler(this.m_btnPrint_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 38);
            this.toolStripSeparator8.Visible = false;
            // 
            // m_btnSave
            // 
            this.m_btnSave.Image = ((System.Drawing.Image)(resources.GetObject("m_btnSave.Image")));
            this.m_btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Size = new System.Drawing.Size(76, 35);
            this.m_btnSave.Text = "保存(&S)";
            this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // toolStripButtondataout
            // 
            this.toolStripButtondataout.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripButtondataout.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtondataout.Image")));
            this.toolStripButtondataout.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripButtondataout.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtondataout.ImageTransparentColor = System.Drawing.Color.Black;
            this.toolStripButtondataout.Name = "toolStripButtondataout";
            this.toolStripButtondataout.Size = new System.Drawing.Size(76, 35);
            this.toolStripButtondataout.Text = "导出(&U)";
            this.toolStripButtondataout.Click += new System.EventHandler(this.toolStripButtondataout_Click);
            // 
            // m_btnExit
            // 
            this.m_btnExit.AutoSize = false;
            this.m_btnExit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnExit.Image = ((System.Drawing.Image)(resources.GetObject("m_btnExit.Image")));
            this.m_btnExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnExit.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_btnExit.Name = "m_btnExit";
            this.m_btnExit.Size = new System.Drawing.Size(80, 33);
            this.m_btnExit.Text = "关闭(&Q)";
            this.m_btnExit.Click += new System.EventHandler(this.m_btnExit_Click);
            // 
            // frmMedicineLimit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 472);
            this.Controls.Add(this.m_dgvDrugLimit);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMedicineLimit";
            this.Text = "药房限量设置";
            this.Load += new System.EventHandler(this.frmMedicineLimit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvDrugLimit)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton m_btnQuery;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        internal System.Windows.Forms.ToolStripButton m_btnPrint;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton m_btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton m_btnExit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        internal System.Windows.Forms.ToolStripTextBox m_txtSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        internal com.digitalwave.controls.MedicineStoreControls.ctlDataGridView_EnterAsTab m_dgvDrugLimit;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        internal System.Windows.Forms.ToolStripComboBox m_cbbDrugType;
        private System.Windows.Forms.ToolStripButton toolStripButtondataout;
    }
}