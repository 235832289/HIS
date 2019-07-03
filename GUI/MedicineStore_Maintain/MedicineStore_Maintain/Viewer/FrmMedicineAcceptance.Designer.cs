namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    partial class FrmMedicineAcceptance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMedicineAcceptance));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_dtpEndDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker();
            this.m_dtpBeginDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker();
            this.m_cmdSearch = new System.Windows.Forms.Button();
            this.m_cmdPrint = new System.Windows.Forms.Button();
            this.m_dwcData = new Sybase.DataWindow.DataWindowControl();
            this.button1 = new System.Windows.Forms.Button();
            this.m_chkStatOut = new System.Windows.Forms.CheckBox();
            this.btnToExcel = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 194;
            this.label1.Text = "入库日期";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 14);
            this.label2.TabIndex = 193;
            this.label2.Text = "~";
            // 
            // m_dtpEndDate
            // 
            this.m_dtpEndDate.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_dtpEndDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_dtpEndDate.Location = new System.Drawing.Point(257, 12);
            this.m_dtpEndDate.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日;
            this.m_dtpEndDate.Mask = "0000年90月90日";
            this.m_dtpEndDate.Name = "m_dtpEndDate";
            this.m_dtpEndDate.Size = new System.Drawing.Size(151, 23);
            this.m_dtpEndDate.TabIndex = 191;
            this.m_dtpEndDate.ValidatingType = typeof(System.DateTime);
            // 
            // m_dtpBeginDate
            // 
            this.m_dtpBeginDate.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_dtpBeginDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_dtpBeginDate.Location = new System.Drawing.Point(79, 12);
            this.m_dtpBeginDate.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日;
            this.m_dtpBeginDate.Mask = "0000年90月90日";
            this.m_dtpBeginDate.Name = "m_dtpBeginDate";
            this.m_dtpBeginDate.Size = new System.Drawing.Size(151, 23);
            this.m_dtpBeginDate.TabIndex = 192;
            this.m_dtpBeginDate.ValidatingType = typeof(System.DateTime);
            // 
            // m_cmdSearch
            // 
            this.m_cmdSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdSearch.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdSearch.ImageIndex = 13;
            this.m_cmdSearch.ImageList = this.imageList1;
            this.m_cmdSearch.Location = new System.Drawing.Point(414, 10);
            this.m_cmdSearch.Name = "m_cmdSearch";
            this.m_cmdSearch.Size = new System.Drawing.Size(94, 28);
            this.m_cmdSearch.TabIndex = 190;
            this.m_cmdSearch.Text = "查询(&F)";
            this.m_cmdSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdSearch.UseVisualStyleBackColor = true;
            this.m_cmdSearch.Click += new System.EventHandler(this.m_cmdSearch_Click);
            // 
            // m_cmdPrint
            // 
            this.m_cmdPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdPrint.ImageIndex = 6;
            this.m_cmdPrint.ImageList = this.imageList1;
            this.m_cmdPrint.Location = new System.Drawing.Point(508, 10);
            this.m_cmdPrint.Name = "m_cmdPrint";
            this.m_cmdPrint.Size = new System.Drawing.Size(94, 28);
            this.m_cmdPrint.TabIndex = 190;
            this.m_cmdPrint.Text = "打印(&P)";
            this.m_cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdPrint.UseVisualStyleBackColor = true;
            this.m_cmdPrint.Click += new System.EventHandler(this.m_cmdPrint_Click);
            // 
            // m_dwcData
            // 
            this.m_dwcData.DataWindowObject = "";
            this.m_dwcData.LibraryList = "";
            this.m_dwcData.Location = new System.Drawing.Point(12, 62);
            this.m_dwcData.Name = "m_dwcData";
            this.m_dwcData.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.m_dwcData.Size = new System.Drawing.Size(1004, 563);
            this.m_dwcData.TabIndex = 195;
            this.m_dwcData.Text = "dataWindowControl1";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.ImageIndex = 1;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(909, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 28);
            this.button1.TabIndex = 197;
            this.button1.Text = "退出(&C)";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // m_chkStatOut
            // 
            this.m_chkStatOut.AutoSize = true;
            this.m_chkStatOut.Checked = true;
            this.m_chkStatOut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkStatOut.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.m_chkStatOut.Location = new System.Drawing.Point(12, 41);
            this.m_chkStatOut.Name = "m_chkStatOut";
            this.m_chkStatOut.Size = new System.Drawing.Size(110, 18);
            this.m_chkStatOut.TabIndex = 199;
            this.m_chkStatOut.Text = "统计退药出库";
            this.m_chkStatOut.UseVisualStyleBackColor = true;
            // 
            // btnToExcel
            // 
            this.btnToExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToExcel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnToExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnToExcel.ImageIndex = 3;
            this.btnToExcel.ImageList = this.imageList1;
            this.btnToExcel.Location = new System.Drawing.Point(602, 10);
            this.btnToExcel.Name = "btnToExcel";
            this.btnToExcel.Size = new System.Drawing.Size(94, 28);
            this.btnToExcel.TabIndex = 200;
            this.btnToExcel.Text = "导出(&D)";
            this.btnToExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnToExcel.UseVisualStyleBackColor = false;
            this.btnToExcel.Click += new System.EventHandler(this.btnToExcel_Click);
            // 
            // FrmMedicineAcceptance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 625);
            this.Controls.Add(this.btnToExcel);
            this.Controls.Add(this.m_chkStatOut);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.m_dwcData);
            this.Controls.Add(this.m_cmdSearch);
            this.Controls.Add(this.m_cmdPrint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_dtpEndDate);
            this.Controls.Add(this.m_dtpBeginDate);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FrmMedicineAcceptance";
            this.Text = "中标药品入库分类汇总表";
            this.Load += new System.EventHandler(this.FrmMedicineAcceptance_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker m_dtpEndDate;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker m_dtpBeginDate;
        internal System.Windows.Forms.Button m_cmdSearch;
        private System.Windows.Forms.Button m_cmdPrint;
        internal Sybase.DataWindow.DataWindowControl m_dwcData;
        private System.Windows.Forms.Button button1;
        internal System.Windows.Forms.CheckBox m_chkStatOut;
        internal System.Windows.Forms.Button btnToExcel;
    }
}