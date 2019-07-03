namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    partial class frmQueryMedicineDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQueryMedicineDetail));
            this.cmdQuery = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cmdPrint = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.m_dtpSearchBeginDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab(this.components);
            this.m_dtpSearchEndDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtMedicine = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.m_txtMEDSPEC = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtPACKUNIT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.datWindow = new Sybase.DataWindow.DataWindowControl();
            this.m_cmdClose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdQuery
            // 
            this.cmdQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdQuery.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cmdQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdQuery.ImageIndex = 5;
            this.cmdQuery.ImageList = this.imageList1;
            this.cmdQuery.Location = new System.Drawing.Point(734, 4);
            this.cmdQuery.Name = "cmdQuery";
            this.cmdQuery.Size = new System.Drawing.Size(94, 32);
            this.cmdQuery.TabIndex = 52;
            this.cmdQuery.Text = "查询(&A)";
            this.cmdQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdQuery.UseVisualStyleBackColor = true;
            this.cmdQuery.Click += new System.EventHandler(this.cmdQuery_Click);
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
            // 
            // cmdPrint
            // 
            this.cmdPrint.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdPrint.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPrint.ImageIndex = 6;
            this.cmdPrint.ImageList = this.imageList1;
            this.cmdPrint.Location = new System.Drawing.Point(827, 4);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(94, 32);
            this.cmdPrint.TabIndex = 53;
            this.cmdPrint.TabStop = false;
            this.cmdPrint.Text = "打印(&P)";
            this.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdPrint.UseVisualStyleBackColor = false;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(185, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 14);
            this.label8.TabIndex = 10013;
            this.label8.Text = "~";
            // 
            // m_dtpSearchBeginDate
            // 
            this.m_dtpSearchBeginDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_dtpSearchBeginDate.Location = new System.Drawing.Point(60, 8);
            this.m_dtpSearchBeginDate.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日;
            this.m_dtpSearchBeginDate.Mask = "0000年90月90日";
            this.m_dtpSearchBeginDate.Name = "m_dtpSearchBeginDate";
            this.m_dtpSearchBeginDate.Size = new System.Drawing.Size(124, 23);
            this.m_dtpSearchBeginDate.TabIndex = 10014;
            this.m_dtpSearchBeginDate.ValidatingType = typeof(System.DateTime);
            // 
            // m_dtpSearchEndDate
            // 
            this.m_dtpSearchEndDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_dtpSearchEndDate.Location = new System.Drawing.Point(200, 8);
            this.m_dtpSearchEndDate.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日;
            this.m_dtpSearchEndDate.Mask = "0000年90月90日";
            this.m_dtpSearchEndDate.Name = "m_dtpSearchEndDate";
            this.m_dtpSearchEndDate.Size = new System.Drawing.Size(123, 23);
            this.m_dtpSearchEndDate.TabIndex = 10015;
            this.m_dtpSearchEndDate.ValidatingType = typeof(System.DateTime);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-4, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 10012;
            this.label1.Text = "统计日期";
            // 
            // m_txtMedicine
            // 
            this.m_txtMedicine.AccessibleDescription = "药品代码";
            this.m_txtMedicine.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtMedicine.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtMedicine.Location = new System.Drawing.Point(396, 8);
            this.m_txtMedicine.Name = "m_txtMedicine";
            this.m_txtMedicine.Size = new System.Drawing.Size(125, 23);
            this.m_txtMedicine.TabIndex = 1;
            this.m_txtMedicine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtMedicine_KeyDown);
            this.m_txtMedicine.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_txtMedicine_MouseDown);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(332, 12);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 14);
            this.label15.TabIndex = 10019;
            this.label15.Text = "药品名称";
            // 
            // m_txtMEDSPEC
            // 
            this.m_txtMEDSPEC.AccessibleDescription = "药品代码";
            this.m_txtMEDSPEC.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.m_txtMEDSPEC.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtMEDSPEC.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtMEDSPEC.Location = new System.Drawing.Point(569, 11);
            this.m_txtMEDSPEC.Name = "m_txtMEDSPEC";
            this.m_txtMEDSPEC.ReadOnly = true;
            this.m_txtMEDSPEC.Size = new System.Drawing.Size(73, 16);
            this.m_txtMEDSPEC.TabIndex = 10022;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(526, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 14);
            this.label3.TabIndex = 10023;
            this.label3.Text = "规格:";
            // 
            // m_txtPACKUNIT
            // 
            this.m_txtPACKUNIT.AccessibleDescription = "药品代码";
            this.m_txtPACKUNIT.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.m_txtPACKUNIT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtPACKUNIT.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtPACKUNIT.Location = new System.Drawing.Point(687, 11);
            this.m_txtPACKUNIT.Name = "m_txtPACKUNIT";
            this.m_txtPACKUNIT.ReadOnly = true;
            this.m_txtPACKUNIT.Size = new System.Drawing.Size(41, 16);
            this.m_txtPACKUNIT.TabIndex = 10024;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(644, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 14);
            this.label4.TabIndex = 10025;
            this.label4.Text = "单位:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.datWindow);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1028, 586);
            this.panel1.TabIndex = 10026;
            // 
            // datWindow
            // 
            this.datWindow.DataWindowObject = "";
            this.datWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datWindow.LibraryList = "";
            this.datWindow.Location = new System.Drawing.Point(0, 0);
            this.datWindow.Name = "datWindow";
            this.datWindow.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.VerticalAndHorizontalSplit;
            this.datWindow.Size = new System.Drawing.Size(1028, 586);
            this.datWindow.TabIndex = 10027;
            this.datWindow.Text = "dataWindowControl1";
            // 
            // m_cmdClose
            // 
            this.m_cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdClose.ImageIndex = 1;
            this.m_cmdClose.ImageList = this.imageList1;
            this.m_cmdClose.Location = new System.Drawing.Point(1050, 41);
            this.m_cmdClose.Name = "m_cmdClose";
            this.m_cmdClose.Size = new System.Drawing.Size(94, 31);
            this.m_cmdClose.TabIndex = 10027;
            this.m_cmdClose.Text = "退出(&Q)";
            this.m_cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdClose.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.ImageIndex = 3;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(920, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 32);
            this.button1.TabIndex = 10028;
            this.button1.TabStop = false;
            this.button1.Text = "导出(&D)";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmQueryMedicineDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 623);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.m_cmdClose);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_txtPACKUNIT);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_txtMEDSPEC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.m_dtpSearchBeginDate);
            this.Controls.Add(this.m_dtpSearchEndDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_txtMedicine);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cmdQuery);
            this.Controls.Add(this.cmdPrint);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmQueryMedicineDetail";
            this.Text = "药品出入库明细查询";
            this.Load += new System.EventHandler(this.frmQueryMedicineDetail_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button cmdPrint;
        private System.Windows.Forms.Label label8;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab m_dtpSearchBeginDate;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab m_dtpSearchEndDate;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox m_txtMedicine;
        private System.Windows.Forms.Label label15;
        internal System.Windows.Forms.TextBox m_txtMEDSPEC;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox m_txtPACKUNIT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        public Sybase.DataWindow.DataWindowControl datWindow;
        private System.Windows.Forms.Button m_cmdClose;
        internal System.Windows.Forms.Button cmdQuery;
        private System.Windows.Forms.Button button1;
    }
}