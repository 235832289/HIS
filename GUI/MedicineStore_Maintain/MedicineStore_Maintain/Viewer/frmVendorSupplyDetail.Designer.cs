namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    partial class frmVendorSupplyDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVendorSupplyDetail));
            this.label4 = new System.Windows.Forms.Label();
            this.m_cboType = new System.Windows.Forms.ComboBox();
            this.m_txtVendor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_dtpEndDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker();
            this.m_dtpBeginDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_btnPrint = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.m_btnSearch = new System.Windows.Forms.Button();
            this.m_dwcData = new Sybase.DataWindow.DataWindowControl();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label4.Location = new System.Drawing.Point(590, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 186;
            this.label4.Text = "类型";
            // 
            // m_cboType
            // 
            this.m_cboType.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_cboType.FormattingEnabled = true;
            this.m_cboType.Location = new System.Drawing.Point(625, 12);
            this.m_cboType.Name = "m_cboType";
            this.m_cboType.Size = new System.Drawing.Size(121, 22);
            this.m_cboType.TabIndex = 3;
            // 
            // m_txtVendor
            // 
            this.m_txtVendor.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtVendor.Location = new System.Drawing.Point(390, 12);
            this.m_txtVendor.Name = "m_txtVendor";
            this.m_txtVendor.Size = new System.Drawing.Size(200, 23);
            this.m_txtVendor.TabIndex = 2;
            this.m_txtVendor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_txtVendor_MouseDown);
            this.m_txtVendor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtVendor_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label3.Location = new System.Drawing.Point(341, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 183;
            this.label3.Text = "供应商";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label1.Location = new System.Drawing.Point(4, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 182;
            this.label1.Text = "入库日期";
            // 
            // m_dtpEndDate
            // 
            this.m_dtpEndDate.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_dtpEndDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_dtpEndDate.Location = new System.Drawing.Point(211, 12);
            this.m_dtpEndDate.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日;
            this.m_dtpEndDate.Mask = "0000年90月90日";
            this.m_dtpEndDate.Name = "m_dtpEndDate";
            this.m_dtpEndDate.Size = new System.Drawing.Size(130, 23);
            this.m_dtpEndDate.TabIndex = 1;
            this.m_dtpEndDate.ValidatingType = typeof(System.DateTime);
            // 
            // m_dtpBeginDate
            // 
            this.m_dtpBeginDate.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_dtpBeginDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_dtpBeginDate.Location = new System.Drawing.Point(67, 12);
            this.m_dtpBeginDate.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日;
            this.m_dtpBeginDate.Mask = "0000年90月90日";
            this.m_dtpBeginDate.Name = "m_dtpBeginDate";
            this.m_dtpBeginDate.Size = new System.Drawing.Size(130, 23);
            this.m_dtpBeginDate.TabIndex = 0;
            this.m_dtpBeginDate.ValidatingType = typeof(System.DateTime);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.m_btnPrint);
            this.panel1.Controls.Add(this.m_btnSearch);
            this.panel1.Location = new System.Drawing.Point(804, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(196, 31);
            this.panel1.TabIndex = 179;
            // 
            // m_btnPrint
            // 
            this.m_btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_btnPrint.ImageIndex = 6;
            this.m_btnPrint.ImageList = this.imageList1;
            this.m_btnPrint.Location = new System.Drawing.Point(97, 0);
            this.m_btnPrint.Name = "m_btnPrint";
            this.m_btnPrint.Size = new System.Drawing.Size(94, 28);
            this.m_btnPrint.TabIndex = 1;
            this.m_btnPrint.Text = "打印(&P)";
            this.m_btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_btnPrint.UseVisualStyleBackColor = true;
            this.m_btnPrint.Click += new System.EventHandler(this.m_btnPrint_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Shell32 007.ico");
            this.imageList1.Images.SetKeyName(1, "Shell32 028.ico");
            this.imageList1.Images.SetKeyName(2, "Shell32 132.ico");
            this.imageList1.Images.SetKeyName(3, "Shell32 148.ico");
            this.imageList1.Images.SetKeyName(4, "Shell32 058.ico");
            this.imageList1.Images.SetKeyName(5, "m_cmdRefresh.Image.png");
            this.imageList1.Images.SetKeyName(6, "Shell32 137.ico");
            this.imageList1.Images.SetKeyName(7, "Shell32 177.ico");
            this.imageList1.Images.SetKeyName(8, "Shell32 136.ico");
            this.imageList1.Images.SetKeyName(9, "Shell32 055.ico");
            this.imageList1.Images.SetKeyName(10, "Shell32 147.ico");
            this.imageList1.Images.SetKeyName(11, "Shell32 133.ico");
            this.imageList1.Images.SetKeyName(12, "Shell32 088.ico");
            this.imageList1.Images.SetKeyName(13, "Shell32 023.ico");
            // 
            // m_btnSearch
            // 
            this.m_btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnSearch.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_btnSearch.ImageIndex = 13;
            this.m_btnSearch.ImageList = this.imageList1;
            this.m_btnSearch.Location = new System.Drawing.Point(3, 0);
            this.m_btnSearch.Name = "m_btnSearch";
            this.m_btnSearch.Size = new System.Drawing.Size(94, 28);
            this.m_btnSearch.TabIndex = 0;
            this.m_btnSearch.Text = "查询(&F)";
            this.m_btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_btnSearch.UseVisualStyleBackColor = true;
            this.m_btnSearch.Click += new System.EventHandler(this.m_btnSearch_Click);
            // 
            // m_dwcData
            // 
            this.m_dwcData.DataWindowObject = "ms_vendorsupplydetail_cs";
            this.m_dwcData.LibraryList = "";
            this.m_dwcData.Location = new System.Drawing.Point(6, 59);
            this.m_dwcData.Name = "m_dwcData";
            this.m_dwcData.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.m_dwcData.Size = new System.Drawing.Size(995, 535);
            this.m_dwcData.TabIndex = 5;
            this.m_dwcData.Text = "dataWindowControl1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label2.Location = new System.Drawing.Point(197, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 14);
            this.label2.TabIndex = 188;
            this.label2.Text = "~";
            // 
            // frmVendorSupplyDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 634);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_dwcData);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_cboType);
            this.Controls.Add(this.m_txtVendor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_dtpEndDate);
            this.Controls.Add(this.m_dtpBeginDate);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmVendorSupplyDetail";
            this.Text = "供药单位供药明细";
            this.Load += new System.EventHandler(this.frmVendorSupplyDetail_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox m_cboType;
        internal System.Windows.Forms.TextBox m_txtVendor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker m_dtpEndDate;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker m_dtpBeginDate;
        internal System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Button m_btnSearch;
        private System.Windows.Forms.Button m_btnPrint;
        internal Sybase.DataWindow.DataWindowControl m_dwcData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList imageList1;

    }
}