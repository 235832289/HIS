namespace com.digitalwave.iCare.gui.MedicineStore
{
    partial class frmQueryMedicineInfo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQueryMedicineInfo));
            this.m_dgvQueryMedicineInfo = new com.digitalwave.controls.MedicineStoreControls.ctlDataGridView_EnterAsTab();
            this.m_dgvtxtMedicineCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedicineName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedicineSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtProduceNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtInStorageAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtRealStorage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtCanUseStorage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.callprice_int = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.retailprice_int = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtOutNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtInData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtInOrderCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.m_cmdOK = new System.Windows.Forms.Button();
            this.m_cmdCancel = new System.Windows.Forms.Button();
            this.m_lblHintText = new System.Windows.Forms.Label();
            this.m_ckbShowZero = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvQueryMedicineInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // m_dgvQueryMedicineInfo
            // 
            this.m_dgvQueryMedicineInfo.AllowUserToAddRows = false;
            this.m_dgvQueryMedicineInfo.AllowUserToDeleteRows = false;
            this.m_dgvQueryMedicineInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_dgvQueryMedicineInfo.BackgroundColor = System.Drawing.SystemColors.Window;
            this.m_dgvQueryMedicineInfo.ColumnHeadersHeight = 30;
            this.m_dgvQueryMedicineInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgvQueryMedicineInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_dgvtxtMedicineCode,
            this.m_dgvtxtMedicineName,
            this.m_dgvtxtMedicineSpec,
            this.m_dgvtxtProduceNumber,
            this.m_dgvtxtInStorageAmount,
            this.m_dgvtxtRealStorage,
            this.m_dgvtxtCanUseStorage,
            this.callprice_int,
            this.retailprice_int,
            this.m_dgvtxtOutNumber,
            this.m_dgvtxtInData,
            this.m_dgvtxtInOrderCode});
            this.m_dgvQueryMedicineInfo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.m_dgvQueryMedicineInfo.Location = new System.Drawing.Point(1, 0);
            this.m_dgvQueryMedicineInfo.Name = "m_dgvQueryMedicineInfo";
            this.m_dgvQueryMedicineInfo.RowHeadersVisible = false;
            this.m_dgvQueryMedicineInfo.RowTemplate.Height = 23;
            this.m_dgvQueryMedicineInfo.Size = new System.Drawing.Size(917, 254);
            this.m_dgvQueryMedicineInfo.TabIndex = 0;
            this.m_dgvQueryMedicineInfo.EnterKeyPress += new com.digitalwave.controls.MedicineStoreControls.EnterKeyPressInCurrentCell(this.m_dgvQueryMedicineInfo_EnterKeyPress);
            // 
            // m_dgvtxtMedicineCode
            // 
            this.m_dgvtxtMedicineCode.DataPropertyName = "assistcode_chr";
            this.m_dgvtxtMedicineCode.HeaderText = "药品代码";
            this.m_dgvtxtMedicineCode.Name = "m_dgvtxtMedicineCode";
            this.m_dgvtxtMedicineCode.ReadOnly = true;
            this.m_dgvtxtMedicineCode.Width = 80;
            // 
            // m_dgvtxtMedicineName
            // 
            this.m_dgvtxtMedicineName.DataPropertyName = "medicinename_vchr";
            this.m_dgvtxtMedicineName.HeaderText = "药品名称";
            this.m_dgvtxtMedicineName.Name = "m_dgvtxtMedicineName";
            this.m_dgvtxtMedicineName.ReadOnly = true;
            this.m_dgvtxtMedicineName.Width = 130;
            // 
            // m_dgvtxtMedicineSpec
            // 
            this.m_dgvtxtMedicineSpec.DataPropertyName = "medspec_vchr";
            this.m_dgvtxtMedicineSpec.HeaderText = "规格";
            this.m_dgvtxtMedicineSpec.Name = "m_dgvtxtMedicineSpec";
            this.m_dgvtxtMedicineSpec.ReadOnly = true;
            this.m_dgvtxtMedicineSpec.Width = 80;
            // 
            // m_dgvtxtProduceNumber
            // 
            this.m_dgvtxtProduceNumber.DataPropertyName = "lotno_vchr";
            this.m_dgvtxtProduceNumber.HeaderText = "生产批号";
            this.m_dgvtxtProduceNumber.Name = "m_dgvtxtProduceNumber";
            this.m_dgvtxtProduceNumber.ReadOnly = true;
            this.m_dgvtxtProduceNumber.Width = 90;
            // 
            // m_dgvtxtInStorageAmount
            // 
            this.m_dgvtxtInStorageAmount.DataPropertyName = "instorageamount";
            this.m_dgvtxtInStorageAmount.HeaderText = "入库数量";
            this.m_dgvtxtInStorageAmount.Name = "m_dgvtxtInStorageAmount";
            this.m_dgvtxtInStorageAmount.ReadOnly = true;
            this.m_dgvtxtInStorageAmount.Visible = false;
            this.m_dgvtxtInStorageAmount.Width = 90;
            // 
            // m_dgvtxtRealStorage
            // 
            this.m_dgvtxtRealStorage.DataPropertyName = "realgross_int";
            this.m_dgvtxtRealStorage.HeaderText = "实际库存";
            this.m_dgvtxtRealStorage.Name = "m_dgvtxtRealStorage";
            this.m_dgvtxtRealStorage.ReadOnly = true;
            this.m_dgvtxtRealStorage.Width = 90;
            // 
            // m_dgvtxtCanUseStorage
            // 
            this.m_dgvtxtCanUseStorage.DataPropertyName = "availagross_int";
            this.m_dgvtxtCanUseStorage.HeaderText = "可用库存";
            this.m_dgvtxtCanUseStorage.Name = "m_dgvtxtCanUseStorage";
            this.m_dgvtxtCanUseStorage.ReadOnly = true;
            this.m_dgvtxtCanUseStorage.Width = 90;
            // 
            // callprice_int
            // 
            this.callprice_int.DataPropertyName = "callprice_int";
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.callprice_int.DefaultCellStyle = dataGridViewCellStyle1;
            this.callprice_int.HeaderText = "购入价";
            this.callprice_int.Name = "callprice_int";
            this.callprice_int.Width = 80;
            // 
            // retailprice_int
            // 
            this.retailprice_int.DataPropertyName = "retailprice_int";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.retailprice_int.DefaultCellStyle = dataGridViewCellStyle2;
            this.retailprice_int.HeaderText = "零售价";
            this.retailprice_int.Name = "retailprice_int";
            this.retailprice_int.Width = 80;
            // 
            // m_dgvtxtOutNumber
            // 
            this.m_dgvtxtOutNumber.DataPropertyName = "NETAMOUNT_INT";
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.m_dgvtxtOutNumber.DefaultCellStyle = dataGridViewCellStyle3;
            this.m_dgvtxtOutNumber.HeaderText = "出库数量";
            this.m_dgvtxtOutNumber.Name = "m_dgvtxtOutNumber";
            this.m_dgvtxtOutNumber.Width = 90;
            // 
            // m_dgvtxtInData
            // 
            this.m_dgvtxtInData.DataPropertyName = "instoragedate_dat";
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.m_dgvtxtInData.DefaultCellStyle = dataGridViewCellStyle4;
            this.m_dgvtxtInData.HeaderText = "入库日期";
            this.m_dgvtxtInData.Name = "m_dgvtxtInData";
            this.m_dgvtxtInData.ReadOnly = true;
            // 
            // m_dgvtxtInOrderCode
            // 
            this.m_dgvtxtInOrderCode.DataPropertyName = "instorageid_vchr";
            this.m_dgvtxtInOrderCode.HeaderText = "入库单号";
            this.m_dgvtxtInOrderCode.Name = "m_dgvtxtInOrderCode";
            this.m_dgvtxtInOrderCode.ReadOnly = true;
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
            // m_cmdOK
            // 
            this.m_cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdOK.Location = new System.Drawing.Point(330, 259);
            this.m_cmdOK.Name = "m_cmdOK";
            this.m_cmdOK.Size = new System.Drawing.Size(84, 28);
            this.m_cmdOK.TabIndex = 1;
            this.m_cmdOK.Text = "确定(&Y)";
            this.m_cmdOK.UseVisualStyleBackColor = true;
            this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
            // 
            // m_cmdCancel
            // 
            this.m_cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdCancel.Location = new System.Drawing.Point(448, 259);
            this.m_cmdCancel.Name = "m_cmdCancel";
            this.m_cmdCancel.Size = new System.Drawing.Size(84, 28);
            this.m_cmdCancel.TabIndex = 5;
            this.m_cmdCancel.Text = "取消(&Q)";
            this.m_cmdCancel.UseVisualStyleBackColor = true;
            this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
            // 
            // m_lblHintText
            // 
            this.m_lblHintText.AutoSize = true;
            this.m_lblHintText.ForeColor = System.Drawing.Color.Red;
            this.m_lblHintText.Location = new System.Drawing.Point(9, 264);
            this.m_lblHintText.Name = "m_lblHintText";
            this.m_lblHintText.Size = new System.Drawing.Size(63, 14);
            this.m_lblHintText.TabIndex = 2;
            this.m_lblHintText.Text = "HintText";
            this.m_lblHintText.Visible = false;
            // 
            // m_ckbShowZero
            // 
            this.m_ckbShowZero.AutoSize = true;
            this.m_ckbShowZero.Checked = true;
            this.m_ckbShowZero.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_ckbShowZero.Location = new System.Drawing.Point(218, 264);
            this.m_ckbShowZero.Name = "m_ckbShowZero";
            this.m_ckbShowZero.Size = new System.Drawing.Size(96, 18);
            this.m_ckbShowZero.TabIndex = 10;
            this.m_ckbShowZero.Text = "显示零库存";
            this.m_ckbShowZero.UseVisualStyleBackColor = true;
            this.m_ckbShowZero.CheckedChanged += new System.EventHandler(this.m_ckbShowZero_CheckedChanged);
            // 
            // frmQueryMedicineInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 291);
            this.Controls.Add(this.m_ckbShowZero);
            this.Controls.Add(this.m_lblHintText);
            this.Controls.Add(this.m_cmdCancel);
            this.Controls.Add(this.m_cmdOK);
            this.Controls.Add(this.m_dgvQueryMedicineInfo);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(1, 1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQueryMedicineInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.Load += new System.EventHandler(this.frmQueryMedicineInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvQueryMedicineInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button m_cmdOK;
        private System.Windows.Forms.Button m_cmdCancel;
        internal System.Windows.Forms.Label m_lblHintText;
        internal com.digitalwave.controls.MedicineStoreControls.ctlDataGridView_EnterAsTab m_dgvQueryMedicineInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtProduceNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtInStorageAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtRealStorage;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtCanUseStorage;
        private System.Windows.Forms.DataGridViewTextBoxColumn callprice_int;
        private System.Windows.Forms.DataGridViewTextBoxColumn retailprice_int;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtOutNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtInData;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtInOrderCode;
        private System.Windows.Forms.CheckBox m_ckbShowZero;
    }
}