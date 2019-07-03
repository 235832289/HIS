namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMedicineLimit));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_dgvDetailInfo = new com.digitalwave.controls.MedicineStoreControls.ctlDataGridView_EnterAsTab();
            this.assistcode_chr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.medicinename_vchr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.medspec_vchr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.opunit_chr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REALGROSS_INT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiptoplimit_int = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.neaplimit_int = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtFindBox = new System.Windows.Forms.TextBox();
            this.m_cmdExit = new System.Windows.Forms.Button();
            this.m_cmdAddNew = new System.Windows.Forms.Button();
            this.m_cmdPrint = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvDetailInfo)).BeginInit();
            this.panel2.SuspendLayout();
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
            // panel1
            // 
            this.panel1.Controls.Add(this.m_dgvDetailInfo);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(972, 562);
            this.panel1.TabIndex = 10059;
            // 
            // m_dgvDetailInfo
            // 
            this.m_dgvDetailInfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.OldLace;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.m_dgvDetailInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.m_dgvDetailInfo.ColumnHeadersHeight = 30;
            this.m_dgvDetailInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.assistcode_chr,
            this.medicinename_vchr,
            this.medspec_vchr,
            this.opunit_chr,
            this.REALGROSS_INT,
            this.tiptoplimit_int,
            this.neaplimit_int});
            this.m_dgvDetailInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvDetailInfo.Location = new System.Drawing.Point(0, 51);
            this.m_dgvDetailInfo.Name = "m_dgvDetailInfo";
            this.m_dgvDetailInfo.RowHeadersVisible = false;
            this.m_dgvDetailInfo.RowTemplate.Height = 23;
            this.m_dgvDetailInfo.Size = new System.Drawing.Size(972, 511);
            this.m_dgvDetailInfo.TabIndex = 1;
            this.m_dgvDetailInfo.EnterKeyPress += new com.digitalwave.controls.MedicineStoreControls.EnterKeyPressInCurrentCell(this.m_dgvDetailInfo_EnterKeyPress);
            this.m_dgvDetailInfo.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.m_dgvDetailInfo_DataError);
            this.m_dgvDetailInfo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_dgvDetailInfo_MouseUp);
            // 
            // assistcode_chr
            // 
            this.assistcode_chr.DataPropertyName = "assistcode_chr";
            this.assistcode_chr.HeaderText = "药品代码";
            this.assistcode_chr.Name = "assistcode_chr";
            this.assistcode_chr.ReadOnly = true;
            // 
            // medicinename_vchr
            // 
            this.medicinename_vchr.DataPropertyName = "medicinename_vchr";
            this.medicinename_vchr.HeaderText = "药品名称";
            this.medicinename_vchr.Name = "medicinename_vchr";
            this.medicinename_vchr.ReadOnly = true;
            this.medicinename_vchr.Width = 300;
            // 
            // medspec_vchr
            // 
            this.medspec_vchr.DataPropertyName = "medspec_vchr";
            this.medspec_vchr.HeaderText = "规格";
            this.medspec_vchr.Name = "medspec_vchr";
            this.medspec_vchr.ReadOnly = true;
            this.medspec_vchr.Width = 150;
            // 
            // opunit_chr
            // 
            this.opunit_chr.DataPropertyName = "opunit_chr";
            this.opunit_chr.HeaderText = "单位";
            this.opunit_chr.Name = "opunit_chr";
            this.opunit_chr.ReadOnly = true;
            // 
            // REALGROSS_INT
            // 
            this.REALGROSS_INT.DataPropertyName = "REALGROSS_INT";
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = "0";
            this.REALGROSS_INT.DefaultCellStyle = dataGridViewCellStyle2;
            this.REALGROSS_INT.HeaderText = "现在库存";
            this.REALGROSS_INT.Name = "REALGROSS_INT";
            this.REALGROSS_INT.ReadOnly = true;
            // 
            // tiptoplimit_int
            // 
            this.tiptoplimit_int.DataPropertyName = "tiptoplimit_int";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            this.tiptoplimit_int.DefaultCellStyle = dataGridViewCellStyle3;
            this.tiptoplimit_int.HeaderText = "最高限量";
            this.tiptoplimit_int.Name = "tiptoplimit_int";
            // 
            // neaplimit_int
            // 
            this.neaplimit_int.DataPropertyName = "neaplimit_int";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.neaplimit_int.DefaultCellStyle = dataGridViewCellStyle4;
            this.neaplimit_int.HeaderText = "最低限量";
            this.neaplimit_int.Name = "neaplimit_int";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.m_txtFindBox);
            this.panel2.Controls.Add(this.m_cmdExit);
            this.panel2.Controls.Add(this.m_cmdAddNew);
            this.panel2.Controls.Add(this.m_cmdPrint);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(972, 51);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(234, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 10070;
            this.label1.Text = "定位";
            // 
            // m_txtFindBox
            // 
            this.m_txtFindBox.Location = new System.Drawing.Point(275, 11);
            this.m_txtFindBox.Name = "m_txtFindBox";
            this.m_txtFindBox.Size = new System.Drawing.Size(147, 23);
            this.m_txtFindBox.TabIndex = 10069;
            this.m_txtFindBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_txtFindBox_MouseDown);
            this.m_txtFindBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtFindBox_KeyDown);
            // 
            // m_cmdExit
            // 
            this.m_cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdExit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdExit.ImageIndex = 1;
            this.m_cmdExit.ImageList = this.imageList1;
            this.m_cmdExit.Location = new System.Drawing.Point(907, 8);
            this.m_cmdExit.Name = "m_cmdExit";
            this.m_cmdExit.Size = new System.Drawing.Size(94, 28);
            this.m_cmdExit.TabIndex = 10066;
            this.m_cmdExit.Text = "退出(&Q)";
            this.m_cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdExit.UseVisualStyleBackColor = true;
            this.m_cmdExit.Click += new System.EventHandler(this.m_cmdExit_Click);
            // 
            // m_cmdAddNew
            // 
            this.m_cmdAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdAddNew.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdAddNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdAddNew.ImageIndex = 0;
            this.m_cmdAddNew.ImageList = this.imageList1;
            this.m_cmdAddNew.Location = new System.Drawing.Point(12, 8);
            this.m_cmdAddNew.Name = "m_cmdAddNew";
            this.m_cmdAddNew.Size = new System.Drawing.Size(94, 28);
            this.m_cmdAddNew.TabIndex = 10064;
            this.m_cmdAddNew.Text = "保存(&S)";
            this.m_cmdAddNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdAddNew.UseVisualStyleBackColor = true;
            this.m_cmdAddNew.Click += new System.EventHandler(this.m_cmdAddNew_Click);
            // 
            // m_cmdPrint
            // 
            this.m_cmdPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdPrint.ImageIndex = 6;
            this.m_cmdPrint.ImageList = this.imageList1;
            this.m_cmdPrint.Location = new System.Drawing.Point(112, 8);
            this.m_cmdPrint.Name = "m_cmdPrint";
            this.m_cmdPrint.Size = new System.Drawing.Size(94, 28);
            this.m_cmdPrint.TabIndex = 10065;
            this.m_cmdPrint.Text = "打印(&P)";
            this.m_cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdPrint.UseVisualStyleBackColor = true;
            this.m_cmdPrint.Click += new System.EventHandler(this.m_cmdPrint_Click);
            // 
            // frmMedicineLimit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 562);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmMedicineLimit";
            this.Text = "药品限价设置";
            this.Load += new System.EventHandler(this.frmMedicineLimit_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvDetailInfo)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button m_cmdExit;
        internal System.Windows.Forms.Button m_cmdAddNew;
        private System.Windows.Forms.Button m_cmdPrint;
        //internal System.Windows.Forms.DataGridView m_dgvDetailInfo;
        internal com.digitalwave.controls.MedicineStoreControls.ctlDataGridView_EnterAsTab m_dgvDetailInfo;
        internal System.Windows.Forms.TextBox m_txtFindBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn assistcode_chr;
        private System.Windows.Forms.DataGridViewTextBoxColumn medicinename_vchr;
        private System.Windows.Forms.DataGridViewTextBoxColumn medspec_vchr;
        private System.Windows.Forms.DataGridViewTextBoxColumn opunit_chr;
        private System.Windows.Forms.DataGridViewTextBoxColumn REALGROSS_INT;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiptoplimit_int;
        private System.Windows.Forms.DataGridViewTextBoxColumn neaplimit_int;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Panel panel2;
    }
}