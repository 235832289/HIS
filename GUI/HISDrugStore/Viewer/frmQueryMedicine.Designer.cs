namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmQueryMedicine
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQueryMedicine));
            this.m_lblHintText = new System.Windows.Forms.Label();
            this.m_cmdCancel = new System.Windows.Forms.Button();
            this.m_cmdOK = new System.Windows.Forms.Button();
            this.m_dgvQueryMedicineInfo = new com.digitalwave.controls.MedicineStoreControls.ctlDataGridView_EnterAsTab();
            this.m_ckbShowZero = new System.Windows.Forms.CheckBox();
            this.m_dgvtxtMedicineCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedicineName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedicineSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit_chr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCTORID_CHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtProduceNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.realgross_int = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtRealStorage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.availagross_int = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtCanUseStorage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wholesaleprice_int = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.callprice_int = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.retailprice_int = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.opretailprice_int = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount_int = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtOutNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.packqty_dec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtInOrderCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.opchargeflg_int = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ipchargeflg_int = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvValidDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvQueryMedicineInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // m_lblHintText
            // 
            this.m_lblHintText.AutoSize = true;
            this.m_lblHintText.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblHintText.ForeColor = System.Drawing.Color.Red;
            this.m_lblHintText.Location = new System.Drawing.Point(12, 267);
            this.m_lblHintText.Name = "m_lblHintText";
            this.m_lblHintText.Size = new System.Drawing.Size(71, 14);
            this.m_lblHintText.TabIndex = 7;
            this.m_lblHintText.Text = "HintText";
            this.m_lblHintText.Visible = false;
            // 
            // m_cmdCancel
            // 
            this.m_cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdCancel.Location = new System.Drawing.Point(450, 260);
            this.m_cmdCancel.Name = "m_cmdCancel";
            this.m_cmdCancel.Size = new System.Drawing.Size(84, 28);
            this.m_cmdCancel.TabIndex = 2;
            this.m_cmdCancel.Text = "取消(&Q)";
            this.m_cmdCancel.UseVisualStyleBackColor = true;
            this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
            // 
            // m_cmdOK
            // 
            this.m_cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdOK.Location = new System.Drawing.Point(360, 260);
            this.m_cmdOK.Name = "m_cmdOK";
            this.m_cmdOK.Size = new System.Drawing.Size(84, 28);
            this.m_cmdOK.TabIndex = 1;
            this.m_cmdOK.Text = "确定(&Y)";
            this.m_cmdOK.UseVisualStyleBackColor = true;
            this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
            // 
            // m_dgvQueryMedicineInfo
            // 
            this.m_dgvQueryMedicineInfo.AllowUserToAddRows = false;
            this.m_dgvQueryMedicineInfo.AllowUserToDeleteRows = false;
            this.m_dgvQueryMedicineInfo.BackgroundColor = System.Drawing.SystemColors.Window;
            this.m_dgvQueryMedicineInfo.ColumnHeadersHeight = 30;
            this.m_dgvQueryMedicineInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgvQueryMedicineInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_dgvtxtMedicineCode,
            this.m_dgvtxtMedicineName,
            this.m_dgvtxtMedicineSpec,
            this.unit_chr,
            this.PRODUCTORID_CHR,
            this.m_dgvtxtProduceNumber,
            this.realgross_int,
            this.m_dgvtxtRealStorage,
            this.availagross_int,
            this.m_dgvtxtCanUseStorage,
            this.wholesaleprice_int,
            this.callprice_int,
            this.retailprice_int,
            this.opretailprice_int,
            this.amount_int,
            this.m_dgvtxtOutNumber,
            this.packqty_dec,
            this.m_dgvtxtInOrderCode,
            this.opchargeflg_int,
            this.ipchargeflg_int,
            this.m_dgvValidDate});
            this.m_dgvQueryMedicineInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_dgvQueryMedicineInfo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.m_dgvQueryMedicineInfo.Location = new System.Drawing.Point(0, 0);
            this.m_dgvQueryMedicineInfo.Name = "m_dgvQueryMedicineInfo";
            this.m_dgvQueryMedicineInfo.RowHeadersVisible = false;
            this.m_dgvQueryMedicineInfo.RowTemplate.Height = 23;
            this.m_dgvQueryMedicineInfo.Size = new System.Drawing.Size(884, 254);
            this.m_dgvQueryMedicineInfo.TabIndex = 0;
            this.m_dgvQueryMedicineInfo.EnterKeyPress += new com.digitalwave.controls.MedicineStoreControls.EnterKeyPressInCurrentCell(this.m_dgvQueryMedicineInfo_EnterKeyPress);
            this.m_dgvQueryMedicineInfo.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvQueryMedicineInfo_CellEndEdit);
            this.m_dgvQueryMedicineInfo.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.m_dgvQueryMedicineInfo_DataError);
            // 
            // m_ckbShowZero
            // 
            this.m_ckbShowZero.AutoSize = true;
            this.m_ckbShowZero.Checked = true;
            this.m_ckbShowZero.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_ckbShowZero.Location = new System.Drawing.Point(246, 266);
            this.m_ckbShowZero.Name = "m_ckbShowZero";
            this.m_ckbShowZero.Size = new System.Drawing.Size(96, 18);
            this.m_ckbShowZero.TabIndex = 10;
            this.m_ckbShowZero.Text = "显示零库存";
            this.m_ckbShowZero.UseVisualStyleBackColor = true;
            this.m_ckbShowZero.CheckedChanged += new System.EventHandler(this.m_ckbShowZero_CheckedChanged);
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
            this.m_dgvtxtMedicineSpec.Width = 50;
            // 
            // unit_chr
            // 
            this.unit_chr.DataPropertyName = "unit_chr";
            this.unit_chr.HeaderText = "门诊单位";
            this.unit_chr.Name = "unit_chr";
            this.unit_chr.ReadOnly = true;
            this.unit_chr.Width = 70;
            // 
            // PRODUCTORID_CHR
            // 
            this.PRODUCTORID_CHR.DataPropertyName = "PRODUCTORID_CHR";
            this.PRODUCTORID_CHR.HeaderText = "生产厂家";
            this.PRODUCTORID_CHR.Name = "PRODUCTORID_CHR";
            this.PRODUCTORID_CHR.ReadOnly = true;
            this.PRODUCTORID_CHR.Width = 80;
            // 
            // m_dgvtxtProduceNumber
            // 
            this.m_dgvtxtProduceNumber.DataPropertyName = "lotno_vchr";
            this.m_dgvtxtProduceNumber.HeaderText = "生产批号";
            this.m_dgvtxtProduceNumber.Name = "m_dgvtxtProduceNumber";
            this.m_dgvtxtProduceNumber.ReadOnly = true;
            this.m_dgvtxtProduceNumber.Width = 70;
            // 
            // realgross_int
            // 
            this.realgross_int.DataPropertyName = "realgross_int";
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = "0";
            this.realgross_int.DefaultCellStyle = dataGridViewCellStyle1;
            this.realgross_int.HeaderText = "实际库存";
            this.realgross_int.Name = "realgross_int";
            this.realgross_int.ReadOnly = true;
            this.realgross_int.Width = 70;
            // 
            // m_dgvtxtRealStorage
            // 
            this.m_dgvtxtRealStorage.DataPropertyName = "oprealgross_int";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0";
            this.m_dgvtxtRealStorage.DefaultCellStyle = dataGridViewCellStyle2;
            this.m_dgvtxtRealStorage.HeaderText = "实际库存";
            this.m_dgvtxtRealStorage.Name = "m_dgvtxtRealStorage";
            this.m_dgvtxtRealStorage.ReadOnly = true;
            this.m_dgvtxtRealStorage.Visible = false;
            this.m_dgvtxtRealStorage.Width = 90;
            // 
            // availagross_int
            // 
            this.availagross_int.DataPropertyName = "availagross_int";
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.availagross_int.DefaultCellStyle = dataGridViewCellStyle3;
            this.availagross_int.HeaderText = "可用库存";
            this.availagross_int.Name = "availagross_int";
            this.availagross_int.ReadOnly = true;
            this.availagross_int.Width = 70;
            // 
            // m_dgvtxtCanUseStorage
            // 
            this.m_dgvtxtCanUseStorage.DataPropertyName = "opavailagross_int";
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.m_dgvtxtCanUseStorage.DefaultCellStyle = dataGridViewCellStyle4;
            this.m_dgvtxtCanUseStorage.HeaderText = "可用库存";
            this.m_dgvtxtCanUseStorage.Name = "m_dgvtxtCanUseStorage";
            this.m_dgvtxtCanUseStorage.ReadOnly = true;
            this.m_dgvtxtCanUseStorage.Visible = false;
            this.m_dgvtxtCanUseStorage.Width = 90;
            // 
            // wholesaleprice_int
            // 
            this.wholesaleprice_int.DataPropertyName = "wholesaleprice_int";
            dataGridViewCellStyle5.Format = "N4";
            dataGridViewCellStyle5.NullValue = "0";
            this.wholesaleprice_int.DefaultCellStyle = dataGridViewCellStyle5;
            this.wholesaleprice_int.HeaderText = "购入价";
            this.wholesaleprice_int.Name = "wholesaleprice_int";
            this.wholesaleprice_int.ReadOnly = true;
            this.wholesaleprice_int.Visible = false;
            this.wholesaleprice_int.Width = 70;
            // 
            // callprice_int
            // 
            this.callprice_int.DataPropertyName = "opwholesaleprice_int";
            dataGridViewCellStyle6.Format = "N4";
            dataGridViewCellStyle6.NullValue = null;
            this.callprice_int.DefaultCellStyle = dataGridViewCellStyle6;
            this.callprice_int.HeaderText = "购入价";
            this.callprice_int.Name = "callprice_int";
            this.callprice_int.ReadOnly = true;
            this.callprice_int.Visible = false;
            this.callprice_int.Width = 80;
            // 
            // retailprice_int
            // 
            this.retailprice_int.DataPropertyName = "retailprice_int";
            dataGridViewCellStyle7.Format = "N4";
            dataGridViewCellStyle7.NullValue = "0";
            this.retailprice_int.DefaultCellStyle = dataGridViewCellStyle7;
            this.retailprice_int.HeaderText = "零售价";
            this.retailprice_int.Name = "retailprice_int";
            this.retailprice_int.ReadOnly = true;
            this.retailprice_int.Width = 70;
            // 
            // opretailprice_int
            // 
            this.opretailprice_int.DataPropertyName = "opretailprice_int";
            dataGridViewCellStyle8.Format = "N4";
            dataGridViewCellStyle8.NullValue = null;
            this.opretailprice_int.DefaultCellStyle = dataGridViewCellStyle8;
            this.opretailprice_int.HeaderText = "零售价";
            this.opretailprice_int.Name = "opretailprice_int";
            this.opretailprice_int.ReadOnly = true;
            this.opretailprice_int.Visible = false;
            this.opretailprice_int.Width = 80;
            // 
            // amount_int
            // 
            this.amount_int.DataPropertyName = "amount_int";
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = "0";
            this.amount_int.DefaultCellStyle = dataGridViewCellStyle9;
            this.amount_int.HeaderText = "出库数量";
            this.amount_int.Name = "amount_int";
            this.amount_int.Width = 70;
            // 
            // m_dgvtxtOutNumber
            // 
            this.m_dgvtxtOutNumber.DataPropertyName = "NETAMOUNT_INT";
            dataGridViewCellStyle10.Format = "N2";
            dataGridViewCellStyle10.NullValue = "0";
            this.m_dgvtxtOutNumber.DefaultCellStyle = dataGridViewCellStyle10;
            this.m_dgvtxtOutNumber.HeaderText = "出库数量";
            this.m_dgvtxtOutNumber.Name = "m_dgvtxtOutNumber";
            this.m_dgvtxtOutNumber.ReadOnly = true;
            this.m_dgvtxtOutNumber.Visible = false;
            this.m_dgvtxtOutNumber.Width = 90;
            // 
            // packqty_dec
            // 
            this.packqty_dec.DataPropertyName = "packqty_dec";
            this.packqty_dec.HeaderText = "包装量";
            this.packqty_dec.Name = "packqty_dec";
            this.packqty_dec.ReadOnly = true;
            this.packqty_dec.Visible = false;
            this.packqty_dec.Width = 70;
            // 
            // m_dgvtxtInOrderCode
            // 
            this.m_dgvtxtInOrderCode.DataPropertyName = "SERIESID_INT";
            this.m_dgvtxtInOrderCode.HeaderText = "序列号";
            this.m_dgvtxtInOrderCode.Name = "m_dgvtxtInOrderCode";
            this.m_dgvtxtInOrderCode.ReadOnly = true;
            this.m_dgvtxtInOrderCode.Visible = false;
            // 
            // opchargeflg_int
            // 
            this.opchargeflg_int.DataPropertyName = "opchargeflg_int";
            this.opchargeflg_int.HeaderText = "门诊单位值";
            this.opchargeflg_int.Name = "opchargeflg_int";
            this.opchargeflg_int.ReadOnly = true;
            this.opchargeflg_int.Visible = false;
            // 
            // ipchargeflg_int
            // 
            this.ipchargeflg_int.DataPropertyName = "ipchargeflg_int";
            this.ipchargeflg_int.HeaderText = "住院单位值";
            this.ipchargeflg_int.Name = "ipchargeflg_int";
            this.ipchargeflg_int.ReadOnly = true;
            this.ipchargeflg_int.Visible = false;
            // 
            // m_dgvValidDate
            // 
            this.m_dgvValidDate.DataPropertyName = "validperiod_dat";
            dataGridViewCellStyle11.Format = "D";
            dataGridViewCellStyle11.NullValue = null;
            this.m_dgvValidDate.DefaultCellStyle = dataGridViewCellStyle11;
            this.m_dgvValidDate.HeaderText = "有效期";
            this.m_dgvValidDate.Name = "m_dgvValidDate";
            this.m_dgvValidDate.ReadOnly = true;
            this.m_dgvValidDate.Width = 120;
            // 
            // frmQueryMedicine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 291);
            this.Controls.Add(this.m_ckbShowZero);
            this.Controls.Add(this.m_dgvQueryMedicineInfo);
            this.Controls.Add(this.m_lblHintText);
            this.Controls.Add(this.m_cmdCancel);
            this.Controls.Add(this.m_cmdOK);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQueryMedicine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择出库药品";
            this.Load += new System.EventHandler(this.frmQueryMedicine_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvQueryMedicineInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label m_lblHintText;
        private System.Windows.Forms.Button m_cmdCancel;
        private System.Windows.Forms.Button m_cmdOK;
        internal com.digitalwave.controls.MedicineStoreControls.ctlDataGridView_EnterAsTab m_dgvQueryMedicineInfo;
        private System.Windows.Forms.CheckBox m_ckbShowZero;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit_chr;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCTORID_CHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtProduceNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn realgross_int;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtRealStorage;
        private System.Windows.Forms.DataGridViewTextBoxColumn availagross_int;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtCanUseStorage;
        private System.Windows.Forms.DataGridViewTextBoxColumn wholesaleprice_int;
        private System.Windows.Forms.DataGridViewTextBoxColumn callprice_int;
        private System.Windows.Forms.DataGridViewTextBoxColumn retailprice_int;
        private System.Windows.Forms.DataGridViewTextBoxColumn opretailprice_int;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount_int;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtOutNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn packqty_dec;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtInOrderCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn opchargeflg_int;
        private System.Windows.Forms.DataGridViewTextBoxColumn ipchargeflg_int;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvValidDate;

    }
}