namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    partial class frmQueryMedicinePrice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQueryMedicinePrice));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gradientPanel2 = new com.digitalwave.iCare.gui.MedicineStore.GradientPanel();
            this.m_txtMedicineName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_dtpBeginDat = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.m_dtpEndDat = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
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
            this.dw = new Sybase.DataWindow.DataWindowControl();
            this.m_dgvMedPrice = new System.Windows.Forms.DataGridView();
            this.m_dgvtxtmedicinename_vch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtmedspec_vchr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtopunit_vchr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtproductorid_chr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtnewretailprice_int = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtpackqty_dec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtexamdate_dat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtenddat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtreason_vchr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gradientPanel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvMedPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // gradientPanel2
            // 
            this.gradientPanel2.Controls.Add(this.m_txtMedicineName);
            this.gradientPanel2.Controls.Add(this.label5);
            this.gradientPanel2.Controls.Add(this.m_dtpBeginDat);
            this.gradientPanel2.Controls.Add(this.label6);
            this.gradientPanel2.Controls.Add(this.m_dtpEndDat);
            this.gradientPanel2.Controls.Add(this.label7);
            this.gradientPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel2.Flip = true;
            this.gradientPanel2.FloatingImage = null;
            this.gradientPanel2.GradientAngle = 90;
            this.gradientPanel2.GradientEndColor = System.Drawing.SystemColors.Control;
            this.gradientPanel2.GradientStartColor = System.Drawing.Color.White;
            this.gradientPanel2.HorizontalFillPercent = 100F;
            this.gradientPanel2.imageXOffset = 0;
            this.gradientPanel2.imageYOffset = 0;
            this.gradientPanel2.Location = new System.Drawing.Point(0, 38);
            this.gradientPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.gradientPanel2.Name = "gradientPanel2";
            this.gradientPanel2.Size = new System.Drawing.Size(1028, 43);
            this.gradientPanel2.TabIndex = 10062;
            this.gradientPanel2.VerticalFillPercent = 100F;
            // 
            // m_txtMedicineName
            // 
            this.m_txtMedicineName.Location = new System.Drawing.Point(642, 13);
            this.m_txtMedicineName.Name = "m_txtMedicineName";
            this.m_txtMedicineName.Size = new System.Drawing.Size(346, 23);
            this.m_txtMedicineName.TabIndex = 2;
            this.m_txtMedicineName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtMedicineName_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(576, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 14);
            this.label5.TabIndex = 10070;
            this.label5.Text = "药品名称:";
            // 
            // m_dtpBeginDat
            // 
            this.m_dtpBeginDat.CustomFormat = "yyyy年MM月dd日HH时mm分ss秒";
            this.m_dtpBeginDat.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpBeginDat.Location = new System.Drawing.Point(80, 12);
            this.m_dtpBeginDat.Name = "m_dtpBeginDat";
            this.m_dtpBeginDat.Size = new System.Drawing.Size(203, 23);
            this.m_dtpBeginDat.TabIndex = 0;
            this.m_dtpBeginDat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_mthEnterToTab);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(7, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 10047;
            this.label6.Text = "查询时间：";
            // 
            // m_dtpEndDat
            // 
            this.m_dtpEndDat.CustomFormat = "yyyy年MM月dd日HH时mm分ss秒";
            this.m_dtpEndDat.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpEndDat.Location = new System.Drawing.Point(313, 12);
            this.m_dtpEndDat.Name = "m_dtpEndDat";
            this.m_dtpEndDat.Size = new System.Drawing.Size(205, 23);
            this.m_dtpEndDat.TabIndex = 1;
            this.m_dtpEndDat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_mthEnterToTab);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(288, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 14);
            this.label7.TabIndex = 10048;
            this.label7.Text = "至";
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
            this.toolStrip1.TabIndex = 10061;
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
            // dw
            // 
            this.dw.DataWindowObject = "";
            this.dw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dw.LibraryList = "";
            this.dw.Location = new System.Drawing.Point(0, 81);
            this.dw.Margin = new System.Windows.Forms.Padding(0);
            this.dw.Name = "dw";
            this.dw.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dw.Size = new System.Drawing.Size(1028, 672);
            this.dw.TabIndex = 10063;
            this.dw.Text = "dataWindowControl1";
            // 
            // m_dgvMedPrice
            // 
            this.m_dgvMedPrice.AllowUserToAddRows = false;
            this.m_dgvMedPrice.AllowUserToOrderColumns = true;
            this.m_dgvMedPrice.BackgroundColor = System.Drawing.Color.White;
            this.m_dgvMedPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_dgvMedPrice.ColumnHeadersHeight = 25;
            this.m_dgvMedPrice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgvMedPrice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_dgvtxtmedicinename_vch,
            this.m_dgvtxtmedspec_vchr,
            this.m_dgvtxtopunit_vchr,
            this.m_dgvtxtproductorid_chr,
            this.m_dgvtxtnewretailprice_int,
            this.m_dgvtxtpackqty_dec,
            this.m_dgvtxtexamdate_dat,
            this.m_dgvtxtenddat,
            this.m_dgvtxtreason_vchr});
            this.m_dgvMedPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvMedPrice.Location = new System.Drawing.Point(0, 81);
            this.m_dgvMedPrice.Name = "m_dgvMedPrice";
            this.m_dgvMedPrice.ReadOnly = true;
            this.m_dgvMedPrice.RowHeadersVisible = false;
            this.m_dgvMedPrice.RowTemplate.Height = 23;
            this.m_dgvMedPrice.Size = new System.Drawing.Size(1028, 672);
            this.m_dgvMedPrice.TabIndex = 10064;
            // 
            // m_dgvtxtmedicinename_vch
            // 
            this.m_dgvtxtmedicinename_vch.DataPropertyName = "medicinename_vch";
            this.m_dgvtxtmedicinename_vch.HeaderText = "           药品名称";
            this.m_dgvtxtmedicinename_vch.Name = "m_dgvtxtmedicinename_vch";
            this.m_dgvtxtmedicinename_vch.ReadOnly = true;
            this.m_dgvtxtmedicinename_vch.Width = 230;
            // 
            // m_dgvtxtmedspec_vchr
            // 
            this.m_dgvtxtmedspec_vchr.DataPropertyName = "medspec_vchr";
            this.m_dgvtxtmedspec_vchr.HeaderText = "药品规格";
            this.m_dgvtxtmedspec_vchr.Name = "m_dgvtxtmedspec_vchr";
            this.m_dgvtxtmedspec_vchr.ReadOnly = true;
            this.m_dgvtxtmedspec_vchr.Width = 70;
            // 
            // m_dgvtxtopunit_vchr
            // 
            this.m_dgvtxtopunit_vchr.DataPropertyName = "opunit_vchr";
            this.m_dgvtxtopunit_vchr.HeaderText = "单位";
            this.m_dgvtxtopunit_vchr.Name = "m_dgvtxtopunit_vchr";
            this.m_dgvtxtopunit_vchr.ReadOnly = true;
            this.m_dgvtxtopunit_vchr.Width = 45;
            // 
            // m_dgvtxtproductorid_chr
            // 
            this.m_dgvtxtproductorid_chr.DataPropertyName = "productorid_chr";
            this.m_dgvtxtproductorid_chr.HeaderText = "    厂家";
            this.m_dgvtxtproductorid_chr.Name = "m_dgvtxtproductorid_chr";
            this.m_dgvtxtproductorid_chr.ReadOnly = true;
            // 
            // m_dgvtxtnewretailprice_int
            // 
            this.m_dgvtxtnewretailprice_int.DataPropertyName = "newretailprice_int";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N4";
            dataGridViewCellStyle1.NullValue = null;
            this.m_dgvtxtnewretailprice_int.DefaultCellStyle = dataGridViewCellStyle1;
            this.m_dgvtxtnewretailprice_int.HeaderText = "   零售价";
            this.m_dgvtxtnewretailprice_int.Name = "m_dgvtxtnewretailprice_int";
            this.m_dgvtxtnewretailprice_int.ReadOnly = true;
            // 
            // m_dgvtxtpackqty_dec
            // 
            this.m_dgvtxtpackqty_dec.DataPropertyName = "packqty_dec";
            this.m_dgvtxtpackqty_dec.HeaderText = "   包装量";
            this.m_dgvtxtpackqty_dec.Name = "m_dgvtxtpackqty_dec";
            this.m_dgvtxtpackqty_dec.ReadOnly = true;
            // 
            // m_dgvtxtexamdate_dat
            // 
            this.m_dgvtxtexamdate_dat.DataPropertyName = "examdate_dat";
            dataGridViewCellStyle2.Format = "yyyy-MM-dd HH:mm:ss";
            dataGridViewCellStyle2.NullValue = null;
            this.m_dgvtxtexamdate_dat.DefaultCellStyle = dataGridViewCellStyle2;
            this.m_dgvtxtexamdate_dat.HeaderText = "     启用日期";
            this.m_dgvtxtexamdate_dat.Name = "m_dgvtxtexamdate_dat";
            this.m_dgvtxtexamdate_dat.ReadOnly = true;
            this.m_dgvtxtexamdate_dat.Width = 150;
            // 
            // m_dgvtxtenddat
            // 
            this.m_dgvtxtenddat.DataPropertyName = "endexamdate_dat";
            dataGridViewCellStyle3.Format = "yyyy-MM-dd HH:mm:ss";
            this.m_dgvtxtenddat.DefaultCellStyle = dataGridViewCellStyle3;
            this.m_dgvtxtenddat.HeaderText = "     停止日期";
            this.m_dgvtxtenddat.Name = "m_dgvtxtenddat";
            this.m_dgvtxtenddat.ReadOnly = true;
            this.m_dgvtxtenddat.Width = 150;
            // 
            // m_dgvtxtreason_vchr
            // 
            this.m_dgvtxtreason_vchr.DataPropertyName = "reason_vchr";
            this.m_dgvtxtreason_vchr.HeaderText = "  原因";
            this.m_dgvtxtreason_vchr.Name = "m_dgvtxtreason_vchr";
            this.m_dgvtxtreason_vchr.ReadOnly = true;
            this.m_dgvtxtreason_vchr.Width = 80;
            // 
            // frmQueryMedicinePrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 753);
            this.Controls.Add(this.m_dgvMedPrice);
            this.Controls.Add(this.dw);
            this.Controls.Add(this.gradientPanel2);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmQueryMedicinePrice";
            this.Text = "药品价格查询";
            this.Load += new System.EventHandler(this.frmQueryMedicinePrice_Load);
            this.gradientPanel2.ResumeLayout(false);
            this.gradientPanel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvMedPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private com.digitalwave.iCare.gui.MedicineStore.GradientPanel gradientPanel2;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.DateTimePicker m_dtpBeginDat;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.DateTimePicker m_dtpEndDat;
        private System.Windows.Forms.Label label7;
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
        internal Sybase.DataWindow.DataWindowControl dw;
        internal System.Windows.Forms.TextBox m_txtMedicineName;
        internal System.Windows.Forms.DataGridView m_dgvMedPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtmedicinename_vch;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtmedspec_vchr;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtopunit_vchr;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtproductorid_chr;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtnewretailprice_int;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtpackqty_dec;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtexamdate_dat;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtenddat;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtreason_vchr;
    }
}