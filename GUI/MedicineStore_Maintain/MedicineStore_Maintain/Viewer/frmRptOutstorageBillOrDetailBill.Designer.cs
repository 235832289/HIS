namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    partial class frmRptOutstorageBillOrDetailBill
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptOutstorageBillOrDetailBill));
            this.dw = new Sybase.DataWindow.DataWindowControl();
            this.panel1 = new com.digitalwave.iCare.gui.MedicineStore.GradientPanel();
            this.m_cboStorageName = new com.digitalwave.iCare.gui.MedicineStore_Maintain.exComboBox();
            this.m_cboOutStorageType = new com.digitalwave.iCare.gui.MedicineStore_Maintain.exComboBox();
            this.m_txtVendor = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_dtpBeginDat = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.m_dtpEndDat = new System.Windows.Forms.DateTimePicker();
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
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
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
            this.panel1.Controls.Add(this.m_cboStorageName);
            this.panel1.Controls.Add(this.m_cboOutStorageType);
            this.panel1.Controls.Add(this.m_txtVendor);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.m_dtpBeginDat);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.m_dtpEndDat);
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
            // m_cboStorageName
            // 
            this.m_cboStorageName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboStorageName.Location = new System.Drawing.Point(352, 47);
            this.m_cboStorageName.Margin = new System.Windows.Forms.Padding(0);
            this.m_cboStorageName.Name = "m_cboStorageName";
            this.m_cboStorageName.Size = new System.Drawing.Size(166, 22);
            this.m_cboStorageName.TabIndex = 4;
            this.m_cboStorageName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_mthKeyPressToTAB);
            // 
            // m_cboOutStorageType
            // 
            this.m_cboOutStorageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboOutStorageType.Location = new System.Drawing.Point(80, 47);
            this.m_cboOutStorageType.Margin = new System.Windows.Forms.Padding(0);
            this.m_cboOutStorageType.Name = "m_cboOutStorageType";
            this.m_cboOutStorageType.Size = new System.Drawing.Size(203, 22);
            this.m_cboOutStorageType.TabIndex = 3;
            this.m_cboOutStorageType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_mthKeyPressToTAB);
            // 
            // m_txtVendor
            // 
            this.m_txtVendor.Location = new System.Drawing.Point(604, 12);
            this.m_txtVendor.Name = "m_txtVendor";
            this.m_txtVendor.Size = new System.Drawing.Size(378, 23);
            this.m_txtVendor.TabIndex = 2;
            this.m_txtVendor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtVendor_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(287, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 10053;
            this.label6.Text = "库房名称：";
            // 
            // m_dtpBeginDat
            // 
            this.m_dtpBeginDat.CustomFormat = "yyyy年MM月dd日HH时mm分ss秒";
            this.m_dtpBeginDat.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpBeginDat.Location = new System.Drawing.Point(80, 12);
            this.m_dtpBeginDat.Name = "m_dtpBeginDat";
            this.m_dtpBeginDat.Size = new System.Drawing.Size(203, 23);
            this.m_dtpBeginDat.TabIndex = 0;
            this.m_dtpBeginDat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_mthKeyPressToTAB);
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
            // m_dtpEndDat
            // 
            this.m_dtpEndDat.CustomFormat = "yyyy年MM月dd日HH时mm分ss秒";
            this.m_dtpEndDat.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpEndDat.Location = new System.Drawing.Point(313, 12);
            this.m_dtpEndDat.Name = "m_dtpEndDat";
            this.m_dtpEndDat.Size = new System.Drawing.Size(205, 23);
            this.m_dtpEndDat.TabIndex = 1;
            this.m_dtpEndDat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_mthKeyPressToTAB);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(288, 15);
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
            this.label4.Location = new System.Drawing.Point(536, 15);
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
            this.label10.Text = "出库类别：";
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
            // frmRptOutstorageBillOrDetailBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 753);
            this.Controls.Add(this.dw);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRptOutstorageBillOrDetailBill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmRptOutstorageBillOrDetailBill_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Sybase.DataWindow.DataWindowControl dw;
        internal com.digitalwave.iCare.gui.MedicineStore.GradientPanel panel1;
        internal com.digitalwave.iCare.gui.MedicineStore_Maintain.exComboBox m_cboStorageName;
        internal com.digitalwave.iCare.gui.MedicineStore_Maintain.exComboBox m_cboOutStorageType;
        internal System.Windows.Forms.TextBox m_txtVendor;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.DateTimePicker m_dtpBeginDat;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.DateTimePicker m_dtpEndDat;
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

    }
}