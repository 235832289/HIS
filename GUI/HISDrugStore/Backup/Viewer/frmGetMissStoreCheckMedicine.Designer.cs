namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmGetMissStoreCheckMedicine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGetMissStoreCheckMedicine));
            this.m_cboMediciePreptype = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtMedicineCode2 = new System.Windows.Forms.TextBox();
            this.m_txtMedicineCode1 = new System.Windows.Forms.TextBox();
            this.m_rdbMedicinePreptype = new System.Windows.Forms.RadioButton();
            this.m_rdbMedicineCode = new System.Windows.Forms.RadioButton();
            this.m_rdbMedicineType = new System.Windows.Forms.RadioButton();
            this.m_cboMedicineType = new System.Windows.Forms.ComboBox();
            this.m_cmdCheck = new System.Windows.Forms.Button();
            this.m_dgvStorageDetail = new System.Windows.Forms.DataGridView();
            this.m_cmdOK = new System.Windows.Forms.Button();
            this.m_cmdCancel = new System.Windows.Forms.Button();
            this.m_lblSelectAll = new System.Windows.Forms.Label();
            this.m_chkCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.m_dgvtxtMedicineCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedicineName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtLotNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtRealGroww = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtCallPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtWholeSalePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtRetailPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtInStorageID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvStorageDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // m_cboMediciePreptype
            // 
            this.m_cboMediciePreptype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboMediciePreptype.Enabled = false;
            this.m_cboMediciePreptype.FormattingEnabled = true;
            this.m_cboMediciePreptype.Location = new System.Drawing.Point(455, 7);
            this.m_cboMediciePreptype.Name = "m_cboMediciePreptype";
            this.m_cboMediciePreptype.Size = new System.Drawing.Size(113, 22);
            this.m_cboMediciePreptype.TabIndex = 1008;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 14);
            this.label2.TabIndex = 1001;
            this.label2.Text = "~";
            // 
            // m_txtMedicineCode2
            // 
            this.m_txtMedicineCode2.Enabled = false;
            this.m_txtMedicineCode2.Location = new System.Drawing.Point(226, 7);
            this.m_txtMedicineCode2.Name = "m_txtMedicineCode2";
            this.m_txtMedicineCode2.Size = new System.Drawing.Size(113, 23);
            this.m_txtMedicineCode2.TabIndex = 1007;
            this.m_txtMedicineCode2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtMedicineCode2_KeyDown);
            // 
            // m_txtMedicineCode1
            // 
            this.m_txtMedicineCode1.Enabled = false;
            this.m_txtMedicineCode1.Location = new System.Drawing.Point(91, 7);
            this.m_txtMedicineCode1.Name = "m_txtMedicineCode1";
            this.m_txtMedicineCode1.Size = new System.Drawing.Size(113, 23);
            this.m_txtMedicineCode1.TabIndex = 1006;
            this.m_txtMedicineCode1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtMedicineCode1_KeyDown);
            // 
            // m_rdbMedicinePreptype
            // 
            this.m_rdbMedicinePreptype.AutoSize = true;
            this.m_rdbMedicinePreptype.Location = new System.Drawing.Point(371, 9);
            this.m_rdbMedicinePreptype.Name = "m_rdbMedicinePreptype";
            this.m_rdbMedicinePreptype.Size = new System.Drawing.Size(81, 18);
            this.m_rdbMedicinePreptype.TabIndex = 1014;
            this.m_rdbMedicinePreptype.Text = "药品剂型";
            this.m_rdbMedicinePreptype.UseVisualStyleBackColor = true;
            this.m_rdbMedicinePreptype.CheckedChanged += new System.EventHandler(this.m_rdbMedicinePreptype_CheckedChanged);
            // 
            // m_rdbMedicineCode
            // 
            this.m_rdbMedicineCode.AutoSize = true;
            this.m_rdbMedicineCode.Location = new System.Drawing.Point(8, 9);
            this.m_rdbMedicineCode.Name = "m_rdbMedicineCode";
            this.m_rdbMedicineCode.Size = new System.Drawing.Size(81, 18);
            this.m_rdbMedicineCode.TabIndex = 1011;
            this.m_rdbMedicineCode.Text = "药品代码";
            this.m_rdbMedicineCode.UseVisualStyleBackColor = true;
            this.m_rdbMedicineCode.CheckedChanged += new System.EventHandler(this.m_rdbMedicineCode_CheckedChanged);
            // 
            // m_rdbMedicineType
            // 
            this.m_rdbMedicineType.AutoSize = true;
            this.m_rdbMedicineType.Location = new System.Drawing.Point(593, 9);
            this.m_rdbMedicineType.Name = "m_rdbMedicineType";
            this.m_rdbMedicineType.Size = new System.Drawing.Size(81, 18);
            this.m_rdbMedicineType.TabIndex = 1016;
            this.m_rdbMedicineType.TabStop = true;
            this.m_rdbMedicineType.Text = "药品类型";
            this.m_rdbMedicineType.UseVisualStyleBackColor = true;
            this.m_rdbMedicineType.CheckedChanged += new System.EventHandler(this.m_rdbMedicineType_CheckedChanged);
            // 
            // m_cboMedicineType
            // 
            this.m_cboMedicineType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboMedicineType.Enabled = false;
            this.m_cboMedicineType.FormattingEnabled = true;
            this.m_cboMedicineType.Location = new System.Drawing.Point(677, 7);
            this.m_cboMedicineType.Name = "m_cboMedicineType";
            this.m_cboMedicineType.Size = new System.Drawing.Size(113, 22);
            this.m_cboMedicineType.TabIndex = 1008;
            // 
            // m_cmdCheck
            // 
            this.m_cmdCheck.Location = new System.Drawing.Point(842, 3);
            this.m_cmdCheck.Name = "m_cmdCheck";
            this.m_cmdCheck.Size = new System.Drawing.Size(75, 28);
            this.m_cmdCheck.TabIndex = 1017;
            this.m_cmdCheck.Text = "检查";
            this.m_cmdCheck.UseVisualStyleBackColor = true;
            this.m_cmdCheck.Click += new System.EventHandler(this.m_cmdCheck_Click);
            // 
            // m_dgvStorageDetail
            // 
            this.m_dgvStorageDetail.AllowUserToAddRows = false;
            this.m_dgvStorageDetail.AllowUserToDeleteRows = false;
            this.m_dgvStorageDetail.AllowUserToResizeRows = false;
            this.m_dgvStorageDetail.ColumnHeadersHeight = 28;
            this.m_dgvStorageDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_chkCheck,
            this.m_dgvtxtMedicineCode,
            this.m_dgvtxtMedicineName,
            this.m_dgvtxtSpec,
            this.m_dgvtxtUnit,
            this.m_dgvtxtLotNO,
            this.m_dgvtxtRealGroww,
            this.m_dgvtxtCallPrice,
            this.m_dgvtxtWholeSalePrice,
            this.m_dgvtxtRetailPrice,
            this.m_dgvtxtInStorageID});
            this.m_dgvStorageDetail.Location = new System.Drawing.Point(2, 36);
            this.m_dgvStorageDetail.Name = "m_dgvStorageDetail";
            this.m_dgvStorageDetail.RowHeadersVisible = false;
            this.m_dgvStorageDetail.RowTemplate.Height = 23;
            this.m_dgvStorageDetail.Size = new System.Drawing.Size(936, 290);
            this.m_dgvStorageDetail.TabIndex = 1018;
            // 
            // m_cmdOK
            // 
            this.m_cmdOK.Location = new System.Drawing.Point(371, 329);
            this.m_cmdOK.Name = "m_cmdOK";
            this.m_cmdOK.Size = new System.Drawing.Size(75, 28);
            this.m_cmdOK.TabIndex = 1017;
            this.m_cmdOK.Text = "确定";
            this.m_cmdOK.UseVisualStyleBackColor = true;
            this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
            // 
            // m_cmdCancel
            // 
            this.m_cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdCancel.Location = new System.Drawing.Point(484, 329);
            this.m_cmdCancel.Name = "m_cmdCancel";
            this.m_cmdCancel.Size = new System.Drawing.Size(75, 28);
            this.m_cmdCancel.TabIndex = 1017;
            this.m_cmdCancel.Text = "取消";
            this.m_cmdCancel.UseVisualStyleBackColor = true;
            this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
            // 
            // m_lblSelectAll
            // 
            this.m_lblSelectAll.Font = new System.Drawing.Font("宋体", 9F);
            this.m_lblSelectAll.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.m_lblSelectAll.Location = new System.Drawing.Point(6, 43);
            this.m_lblSelectAll.Name = "m_lblSelectAll";
            this.m_lblSelectAll.Size = new System.Drawing.Size(29, 16);
            this.m_lblSelectAll.TabIndex = 1019;
            this.m_lblSelectAll.Text = "全选";
            this.m_lblSelectAll.Click += new System.EventHandler(this.m_lblSelectAll_Click);
            // 
            // m_chkCheck
            // 
            this.m_chkCheck.HeaderText = "";
            this.m_chkCheck.Name = "m_chkCheck";
            this.m_chkCheck.Width = 35;
            // 
            // m_dgvtxtMedicineCode
            // 
            this.m_dgvtxtMedicineCode.DataPropertyName = "assistcode_chr";
            this.m_dgvtxtMedicineCode.HeaderText = "药品代码";
            this.m_dgvtxtMedicineCode.Name = "m_dgvtxtMedicineCode";
            this.m_dgvtxtMedicineCode.ReadOnly = true;
            this.m_dgvtxtMedicineCode.Width = 90;
            // 
            // m_dgvtxtMedicineName
            // 
            this.m_dgvtxtMedicineName.DataPropertyName = "medicinename_vchr";
            this.m_dgvtxtMedicineName.HeaderText = "药品名称";
            this.m_dgvtxtMedicineName.Name = "m_dgvtxtMedicineName";
            this.m_dgvtxtMedicineName.ReadOnly = true;
            this.m_dgvtxtMedicineName.Width = 150;
            // 
            // m_dgvtxtSpec
            // 
            this.m_dgvtxtSpec.DataPropertyName = "medspec_vchr";
            this.m_dgvtxtSpec.HeaderText = "规格";
            this.m_dgvtxtSpec.Name = "m_dgvtxtSpec";
            this.m_dgvtxtSpec.ReadOnly = true;
            this.m_dgvtxtSpec.Width = 80;
            // 
            // m_dgvtxtUnit
            // 
            this.m_dgvtxtUnit.DataPropertyName = "unit_chr";
            this.m_dgvtxtUnit.HeaderText = "单位";
            this.m_dgvtxtUnit.Name = "m_dgvtxtUnit";
            this.m_dgvtxtUnit.ReadOnly = true;
            this.m_dgvtxtUnit.Width = 60;
            // 
            // m_dgvtxtLotNO
            // 
            this.m_dgvtxtLotNO.DataPropertyName = "lotno_vchr";
            this.m_dgvtxtLotNO.HeaderText = "批号";
            this.m_dgvtxtLotNO.Name = "m_dgvtxtLotNO";
            this.m_dgvtxtLotNO.ReadOnly = true;
            this.m_dgvtxtLotNO.Width = 80;
            // 
            // m_dgvtxtRealGroww
            // 
            this.m_dgvtxtRealGroww.DataPropertyName = "realgross_int";
            this.m_dgvtxtRealGroww.HeaderText = "库存数量";
            this.m_dgvtxtRealGroww.Name = "m_dgvtxtRealGroww";
            this.m_dgvtxtRealGroww.ReadOnly = true;
            this.m_dgvtxtRealGroww.Width = 80;
            // 
            // m_dgvtxtCallPrice
            // 
            this.m_dgvtxtCallPrice.DataPropertyName = "wholesaleprice_int";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.m_dgvtxtCallPrice.DefaultCellStyle = dataGridViewCellStyle1;
            this.m_dgvtxtCallPrice.HeaderText = "购入单价";
            this.m_dgvtxtCallPrice.Name = "m_dgvtxtCallPrice";
            this.m_dgvtxtCallPrice.ReadOnly = true;
            this.m_dgvtxtCallPrice.Width = 80;
            // 
            // m_dgvtxtWholeSalePrice
            // 
            this.m_dgvtxtWholeSalePrice.DataPropertyName = "wholesaleprice_int";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.m_dgvtxtWholeSalePrice.DefaultCellStyle = dataGridViewCellStyle2;
            this.m_dgvtxtWholeSalePrice.HeaderText = "批发单价";
            this.m_dgvtxtWholeSalePrice.Name = "m_dgvtxtWholeSalePrice";
            this.m_dgvtxtWholeSalePrice.ReadOnly = true;
            this.m_dgvtxtWholeSalePrice.Width = 80;
            // 
            // m_dgvtxtRetailPrice
            // 
            this.m_dgvtxtRetailPrice.DataPropertyName = "retailprice_int";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.m_dgvtxtRetailPrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.m_dgvtxtRetailPrice.HeaderText = "零售单价";
            this.m_dgvtxtRetailPrice.Name = "m_dgvtxtRetailPrice";
            this.m_dgvtxtRetailPrice.ReadOnly = true;
            this.m_dgvtxtRetailPrice.Width = 80;
            // 
            // m_dgvtxtInStorageID
            // 
            this.m_dgvtxtInStorageID.DataPropertyName = "dsinstoreid_vchr";
            this.m_dgvtxtInStorageID.HeaderText = "药房入库单号";
            this.m_dgvtxtInStorageID.Name = "m_dgvtxtInStorageID";
            this.m_dgvtxtInStorageID.ReadOnly = true;
            // 
            // frmGetMissStoreCheckMedicine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_cmdCancel;
            this.ClientSize = new System.Drawing.Size(940, 359);
            this.Controls.Add(this.m_lblSelectAll);
            this.Controls.Add(this.m_dgvStorageDetail);
            this.Controls.Add(this.m_cmdCancel);
            this.Controls.Add(this.m_cmdOK);
            this.Controls.Add(this.m_cmdCheck);
            this.Controls.Add(this.m_rdbMedicineType);
            this.Controls.Add(this.m_cboMedicineType);
            this.Controls.Add(this.m_cboMediciePreptype);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_txtMedicineCode2);
            this.Controls.Add(this.m_txtMedicineCode1);
            this.Controls.Add(this.m_rdbMedicinePreptype);
            this.Controls.Add(this.m_rdbMedicineCode);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmGetMissStoreCheckMedicine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "漏盘药品";
            this.Load += new System.EventHandler(this.frmGetMissStorageCheckMedicine_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvStorageDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox m_cboMediciePreptype;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox m_txtMedicineCode2;
        internal System.Windows.Forms.TextBox m_txtMedicineCode1;
        internal System.Windows.Forms.RadioButton m_rdbMedicinePreptype;
        internal System.Windows.Forms.RadioButton m_rdbMedicineCode;
        internal System.Windows.Forms.ComboBox m_cboMedicineType;
        private System.Windows.Forms.Button m_cmdCheck;
        private System.Windows.Forms.Button m_cmdOK;
        private System.Windows.Forms.Button m_cmdCancel;
        internal System.Windows.Forms.RadioButton m_rdbMedicineType;
        internal System.Windows.Forms.DataGridView m_dgvStorageDetail;
        private System.Windows.Forms.Label m_lblSelectAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn m_chkCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtLotNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtRealGroww;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtCallPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtWholeSalePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtRetailPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtInStorageID;
    }
}