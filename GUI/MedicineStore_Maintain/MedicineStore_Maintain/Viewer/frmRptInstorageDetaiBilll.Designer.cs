namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    partial class frmRptInstorageDetaiBilll
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptInstorageDetaiBilll));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dw = new Sybase.DataWindow.DataWindowControl();
            this.panel1 = new com.digitalwave.iCare.gui.HIS.GradientPanel();
            this.m_dtpEndDat = new com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab(this.components);
            this.m_dtpBeginDat = new com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab(this.components);
            this.m_cboStorageName = new com.digitalwave.iCare.gui.MedicineStore_Maintain.exComboBox();
            this.m_cboInStorageType = new com.digitalwave.iCare.gui.MedicineStore_Maintain.exComboBox();
            this.m_txtVendor = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.m_cmdQuery = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnPreview = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_cmdPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_cmdExcel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.m_cmdClose = new System.Windows.Forms.ToolStripButton();
            this.m_dgvInstorageDetail = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvInstorageDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // dw
            // 
            this.dw.DataWindowObject = "";
            this.dw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dw.LibraryList = "";
            this.dw.Location = new System.Drawing.Point(0, 117);
            this.dw.Margin = new System.Windows.Forms.Padding(0);
            this.dw.Name = "dw";
            this.dw.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dw.Size = new System.Drawing.Size(1028, 636);
            this.dw.TabIndex = 10062;
            this.dw.Text = "dataWindowControl1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_dtpEndDat);
            this.panel1.Controls.Add(this.m_dtpBeginDat);
            this.panel1.Controls.Add(this.m_cboStorageName);
            this.panel1.Controls.Add(this.m_cboInStorageType);
            this.panel1.Controls.Add(this.m_txtVendor);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Flip = true;
            this.panel1.FloatingImage = null;
            this.panel1.GradientAngle = 90;
            this.panel1.GradientEndColor = System.Drawing.SystemColors.Control;
            this.panel1.GradientStartColor = System.Drawing.Color.White;
            this.panel1.HorizontalFillPercent = 100F;
            this.panel1.imageXOffset = 0;
            this.panel1.imageYOffset = 0;
            this.panel1.Location = new System.Drawing.Point(0, 38);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1028, 79);
            this.panel1.TabIndex = 10061;
            this.panel1.VerticalFillPercent = 100F;
            // 
            // m_dtpEndDat
            // 
            this.m_dtpEndDat.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_dtpEndDat.Location = new System.Drawing.Point(292, 11);
            this.m_dtpEndDat.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日HHmmss;
            this.m_dtpEndDat.Mask = "0000年90月90日 90:90:90";
            this.m_dtpEndDat.Name = "m_dtpEndDat";
            this.m_dtpEndDat.Size = new System.Drawing.Size(187, 23);
            this.m_dtpEndDat.TabIndex = 1;
            this.m_dtpEndDat.ValidatingType = typeof(System.DateTime);
            // 
            // m_dtpBeginDat
            // 
            this.m_dtpBeginDat.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_dtpBeginDat.Location = new System.Drawing.Point(81, 11);
            this.m_dtpBeginDat.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日HHmmss;
            this.m_dtpBeginDat.Mask = "0000年90月90日 90:90:90";
            this.m_dtpBeginDat.Name = "m_dtpBeginDat";
            this.m_dtpBeginDat.Size = new System.Drawing.Size(187, 23);
            this.m_dtpBeginDat.TabIndex = 0;
            this.m_dtpBeginDat.ValidatingType = typeof(System.DateTime);
            // 
            // m_cboStorageName
            // 
            this.m_cboStorageName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboStorageName.Location = new System.Drawing.Point(346, 47);
            this.m_cboStorageName.Margin = new System.Windows.Forms.Padding(0);
            this.m_cboStorageName.Name = "m_cboStorageName";
            this.m_cboStorageName.Size = new System.Drawing.Size(133, 22);
            this.m_cboStorageName.TabIndex = 4;
            this.m_cboStorageName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_cboInStorageType_KeyPress);
            // 
            // m_cboInStorageType
            // 
            this.m_cboInStorageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboInStorageType.Location = new System.Drawing.Point(80, 47);
            this.m_cboInStorageType.Margin = new System.Windows.Forms.Padding(0);
            this.m_cboInStorageType.Name = "m_cboInStorageType";
            this.m_cboInStorageType.Size = new System.Drawing.Size(191, 22);
            this.m_cboInStorageType.TabIndex = 3;
            this.m_cboInStorageType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_cboInStorageType_KeyPress);
            // 
            // m_txtVendor
            // 
            this.m_txtVendor.Location = new System.Drawing.Point(581, 12);
            this.m_txtVendor.Name = "m_txtVendor";
            this.m_txtVendor.Size = new System.Drawing.Size(378, 23);
            this.m_txtVendor.TabIndex = 2;
            this.m_txtVendor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtVendor_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(274, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 10053;
            this.label6.Text = "库房名称：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(7, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 14);
            this.label8.TabIndex = 10047;
            this.label8.Text = "统计时间：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(271, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 14);
            this.label9.TabIndex = 10048;
            this.label9.Text = "至";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(513, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 14);
            this.label4.TabIndex = 10049;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(9, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 14);
            this.label10.TabIndex = 10051;
            this.label10.Text = "入库类别：";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_cmdQuery,
            this.toolStripSeparator4,
            this.m_btnPreview,
            this.toolStripSeparator2,
            this.m_cmdPrint,
            this.toolStripSeparator1,
            this.m_cmdExcel,
            this.toolStripSeparator3,
            this.m_cmdClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(1028, 38);
            this.toolStrip1.TabIndex = 10060;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // m_cmdQuery
            // 
            this.m_cmdQuery.AutoSize = false;
            this.m_cmdQuery.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdQuery.Image = ((System.Drawing.Image)(resources.GetObject("m_cmdQuery.Image")));
            this.m_cmdQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdQuery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_cmdQuery.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_cmdQuery.Name = "m_cmdQuery";
            this.m_cmdQuery.Size = new System.Drawing.Size(90, 35);
            this.m_cmdQuery.Text = "查 询(&Q)";
            this.m_cmdQuery.Click += new System.EventHandler(this.m_cmdQuery_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 38);
            // 
            // m_btnPreview
            // 
            this.m_btnPreview.AutoSize = false;
            this.m_btnPreview.Image = ((System.Drawing.Image)(resources.GetObject("m_btnPreview.Image")));
            this.m_btnPreview.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_btnPreview.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.m_btnPreview.Name = "m_btnPreview";
            this.m_btnPreview.Size = new System.Drawing.Size(90, 35);
            this.m_btnPreview.Text = "预 览(&V)";
            this.m_btnPreview.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_btnPreview.Click += new System.EventHandler(this.m_btnPreview_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // m_cmdPrint
            // 
            this.m_cmdPrint.AutoSize = false;
            this.m_cmdPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdPrint.Image = ((System.Drawing.Image)(resources.GetObject("m_cmdPrint.Image")));
            this.m_cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_cmdPrint.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_cmdPrint.Name = "m_cmdPrint";
            this.m_cmdPrint.Size = new System.Drawing.Size(90, 35);
            this.m_cmdPrint.Text = "打 印(&P)";
            this.m_cmdPrint.Click += new System.EventHandler(this.m_cmdPrint_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // m_cmdExcel
            // 
            this.m_cmdExcel.AutoSize = false;
            this.m_cmdExcel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdExcel.Image = ((System.Drawing.Image)(resources.GetObject("m_cmdExcel.Image")));
            this.m_cmdExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_cmdExcel.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_cmdExcel.Name = "m_cmdExcel";
            this.m_cmdExcel.Size = new System.Drawing.Size(90, 35);
            this.m_cmdExcel.Text = "导 出(&E)";
            this.m_cmdExcel.Click += new System.EventHandler(this.m_cmdExcel_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // m_cmdClose
            // 
            this.m_cmdClose.AutoSize = false;
            this.m_cmdClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("m_cmdClose.Image")));
            this.m_cmdClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_cmdClose.ImageTransparentColor = System.Drawing.Color.Black;
            this.m_cmdClose.Name = "m_cmdClose";
            this.m_cmdClose.Size = new System.Drawing.Size(90, 35);
            this.m_cmdClose.Text = "关 闭(&C)";
            this.m_cmdClose.Click += new System.EventHandler(this.m_cmdClose_Click);
            // 
            // m_dgvInstorageDetail
            // 
            this.m_dgvInstorageDetail.AllowUserToAddRows = false;
            this.m_dgvInstorageDetail.AllowUserToOrderColumns = true;
            this.m_dgvInstorageDetail.BackgroundColor = System.Drawing.Color.White;
            this.m_dgvInstorageDetail.ColumnHeadersHeight = 25;
            this.m_dgvInstorageDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgvInstorageDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.m_dgvInstorageDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvInstorageDetail.Location = new System.Drawing.Point(0, 117);
            this.m_dgvInstorageDetail.Name = "m_dgvInstorageDetail";
            this.m_dgvInstorageDetail.ReadOnly = true;
            this.m_dgvInstorageDetail.RowHeadersVisible = false;
            this.m_dgvInstorageDetail.RowTemplate.Height = 23;
            this.m_dgvInstorageDetail.Size = new System.Drawing.Size(1028, 636);
            this.m_dgvInstorageDetail.TabIndex = 10063;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "medicinename_vchr";
            this.Column1.HeaderText = "药品名称";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 240;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "medspec_vchr";
            this.Column2.HeaderText = "规格";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 80;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "ipunit_chr";
            this.Column3.HeaderText = "单位";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 50;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "productorid_chr";
            this.Column4.HeaderText = "厂家";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 180;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "ipamount_int";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            this.Column5.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column5.HeaderText = "数量";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 120;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "ipretailprice_int";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N4";
            this.Column6.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column6.HeaderText = "零价";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 120;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "allprice";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N4";
            this.Column7.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column7.HeaderText = "零价金额";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 130;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "lotno_vchr";
            this.Column8.HeaderText = "批号";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // frmRptInstorageDetaiBilll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 753);
            this.Controls.Add(this.m_dgvInstorageDetail);
            this.Controls.Add(this.dw);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRptInstorageDetaiBilll";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "入库单据报表的明细表";
            this.Load += new System.EventHandler(this.frmRptInstorageDetaiBilll_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvInstorageDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Sybase.DataWindow.DataWindowControl dw;
        internal com.digitalwave.iCare.gui.HIS.GradientPanel panel1;
        internal com.digitalwave.iCare.gui.MedicineStore_Maintain.exComboBox m_cboStorageName;
        internal com.digitalwave.iCare.gui.MedicineStore_Maintain.exComboBox m_cboInStorageType;
        internal System.Windows.Forms.TextBox m_txtVendor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        internal System.Windows.Forms.ToolStrip toolStrip1;
        internal System.Windows.Forms.ToolStripButton m_cmdQuery;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton m_btnPreview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        internal System.Windows.Forms.ToolStripButton m_cmdPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        internal System.Windows.Forms.ToolStripLabel m_cmdExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton m_cmdClose;
        internal System.Windows.Forms.DataGridView m_dgvInstorageDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab m_dtpEndDat;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab m_dtpBeginDat;

    }
}