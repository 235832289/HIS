namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    partial class frmMedIcineCheckReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMedIcineCheckReport));
            this.m_cboType = new System.Windows.Forms.ComboBox();
            this.cmdQuery = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cmdPrint = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_txtProviderName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblJx = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStar = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_dwRpt = new Sybase.DataWindow.DataWindowControl();
            this.m_chkStatOut = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_cboType
            // 
            this.m_cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboType.FormattingEnabled = true;
            this.m_cboType.Location = new System.Drawing.Point(690, 12);
            this.m_cboType.Name = "m_cboType";
            this.m_cboType.Size = new System.Drawing.Size(110, 22);
            this.m_cboType.TabIndex = 32;
            // 
            // cmdQuery
            // 
            this.cmdQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdQuery.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cmdQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdQuery.ImageIndex = 13;
            this.cmdQuery.ImageList = this.imageList1;
            this.cmdQuery.Location = new System.Drawing.Point(814, 8);
            this.cmdQuery.Name = "cmdQuery";
            this.cmdQuery.Size = new System.Drawing.Size(94, 29);
            this.cmdQuery.TabIndex = 33;
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
            this.imageList1.Images.SetKeyName(9, "Shell32 055.ico");
            this.imageList1.Images.SetKeyName(10, "Shell32 147.ico");
            this.imageList1.Images.SetKeyName(11, "Shell32 133.ico");
            this.imageList1.Images.SetKeyName(12, "Shell32 088.ico");
            this.imageList1.Images.SetKeyName(13, "Shell32 023.ico");
            // 
            // cmdPrint
            // 
            this.cmdPrint.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdPrint.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPrint.ImageIndex = 6;
            this.cmdPrint.ImageList = this.imageList1;
            this.cmdPrint.Location = new System.Drawing.Point(925, 8);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(92, 29);
            this.cmdPrint.TabIndex = 34;
            this.cmdPrint.TabStop = false;
            this.cmdPrint.Text = "打印(&P)";
            this.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_chkStatOut);
            this.panel1.Controls.Add(this.m_cboType);
            this.panel1.Controls.Add(this.m_txtProviderName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblJx);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpEnd);
            this.panel1.Controls.Add(this.dtpStar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmdQuery);
            this.panel1.Controls.Add(this.cmdPrint);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1028, 62);
            this.panel1.TabIndex = 37;
            // 
            // m_txtProviderName
            // 
            this.m_txtProviderName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtProviderName.Location = new System.Drawing.Point(416, 12);
            this.m_txtProviderName.Name = "m_txtProviderName";
            this.m_txtProviderName.Size = new System.Drawing.Size(198, 23);
            this.m_txtProviderName.TabIndex = 43;
            this.m_txtProviderName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_txtProviderName_MouseDown);
            this.m_txtProviderName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtProviderName_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(202, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 14);
            this.label3.TabIndex = 42;
            this.label3.Text = "～";
            // 
            // lblJx
            // 
            this.lblJx.AutoSize = true;
            this.lblJx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblJx.Location = new System.Drawing.Point(620, 17);
            this.lblJx.Name = "lblJx";
            this.lblJx.Size = new System.Drawing.Size(77, 14);
            this.lblJx.TabIndex = 41;
            this.lblJx.Text = "药品类型：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(349, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 39;
            this.label2.Text = "供应商名：";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(224, 11);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(123, 23);
            this.dtpEnd.TabIndex = 38;
            // 
            // dtpStar
            // 
            this.dtpStar.Location = new System.Drawing.Point(76, 11);
            this.dtpStar.Name = "dtpStar";
            this.dtpStar.Size = new System.Drawing.Size(125, 23);
            this.dtpStar.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 36;
            this.label1.Text = "入库日期：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_dwRpt);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 62);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1028, 500);
            this.panel2.TabIndex = 38;
            // 
            // m_dwRpt
            // 
            this.m_dwRpt.DataWindowObject = "ms_checkreport";
            this.m_dwRpt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dwRpt.LibraryList = "";
            this.m_dwRpt.Location = new System.Drawing.Point(0, 0);
            this.m_dwRpt.Name = "m_dwRpt";
            this.m_dwRpt.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.m_dwRpt.Size = new System.Drawing.Size(1028, 500);
            this.m_dwRpt.TabIndex = 1;
            this.m_dwRpt.Text = "dataWindowControl1";
            // 
            // m_chkStatOut
            // 
            this.m_chkStatOut.AutoSize = true;
            this.m_chkStatOut.Checked = true;
            this.m_chkStatOut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkStatOut.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.m_chkStatOut.Location = new System.Drawing.Point(10, 39);
            this.m_chkStatOut.Name = "m_chkStatOut";
            this.m_chkStatOut.Size = new System.Drawing.Size(110, 18);
            this.m_chkStatOut.TabIndex = 180;
            this.m_chkStatOut.Text = "统计退药出库";
            this.m_chkStatOut.UseVisualStyleBackColor = true;
            // 
            // frmMedIcineCheckReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 562);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMedIcineCheckReport";
            this.Text = "验收单";
            this.Load += new System.EventHandler(this.frmMedIcineCheckReport_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdQuery;
        private System.Windows.Forms.Button cmdPrint;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblJx;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.DateTimePicker dtpEnd;
        public System.Windows.Forms.DateTimePicker dtpStar;
        internal Sybase.DataWindow.DataWindowControl m_dwRpt;
        public System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.TextBox m_txtProviderName;
        private System.Windows.Forms.ImageList imageList1;
        internal System.Windows.Forms.CheckBox m_chkStatOut;
        internal System.Windows.Forms.ComboBox m_cboType;
    }
}