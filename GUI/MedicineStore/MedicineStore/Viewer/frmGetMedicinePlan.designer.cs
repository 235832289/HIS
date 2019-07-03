namespace com.digitalwave.iCare.gui.MedicineStore
{
    partial class frmGetMedicinePlan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGetMedicinePlan));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_dtpDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab(this.components);
            this.m_txtRequisitionDept = new System.Windows.Forms.TextBox();
            this.m_txtOutDept = new System.Windows.Forms.TextBox();
            this.m_txtRemark = new System.Windows.Forms.TextBox();
            this.m_txtMan = new System.Windows.Forms.TextBox();
            this.m_txtOrderNumber = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cmdSave = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.m_cmdDelete = new System.Windows.Forms.Button();
            this.m_cmdPrint = new System.Windows.Forms.Button();
            this.m_cmdNext = new System.Windows.Forms.Button();
            this.m_cmdExit = new System.Windows.Forms.Button();
            this.m_dgvGetMedicineInfo = new com.digitalwave.controls.MedicineStoreControls.ctlDataGridView_EnterAsTab();
            this.m_dgvtxtMedicineCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedicineName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedicineSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtGetAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtBaseUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtGetAmountUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMinUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtCurrentAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtCanUseAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtBaseUnit2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtExchangeRelation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtSalePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtBuyPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtWholeSalePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvGetMedicineInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.m_dtpDate);
            this.panel1.Controls.Add(this.m_txtRequisitionDept);
            this.panel1.Controls.Add(this.m_txtOutDept);
            this.panel1.Controls.Add(this.m_txtRemark);
            this.panel1.Controls.Add(this.m_txtMan);
            this.panel1.Controls.Add(this.m_txtOrderNumber);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(972, 80);
            this.panel1.TabIndex = 0;
            // 
            // m_dtpDate
            // 
            this.m_dtpDate.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_dtpDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_dtpDate.Location = new System.Drawing.Point(318, 12);
            this.m_dtpDate.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日;
            this.m_dtpDate.Mask = "0000年90月90日";
            this.m_dtpDate.Name = "m_dtpDate";
            this.m_dtpDate.Size = new System.Drawing.Size(130, 23);
            this.m_dtpDate.TabIndex = 21;
            this.m_dtpDate.ValidatingType = typeof(System.DateTime);
            // 
            // m_txtRequisitionDept
            // 
            this.m_txtRequisitionDept.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtRequisitionDept.Location = new System.Drawing.Point(318, 43);
            this.m_txtRequisitionDept.Name = "m_txtRequisitionDept";
            this.m_txtRequisitionDept.ReadOnly = true;
            this.m_txtRequisitionDept.Size = new System.Drawing.Size(130, 23);
            this.m_txtRequisitionDept.TabIndex = 13;
            // 
            // m_txtOutDept
            // 
            this.m_txtOutDept.Location = new System.Drawing.Point(86, 43);
            this.m_txtOutDept.Name = "m_txtOutDept";
            this.m_txtOutDept.Size = new System.Drawing.Size(141, 23);
            this.m_txtOutDept.TabIndex = 12;
            // 
            // m_txtRemark
            // 
            this.m_txtRemark.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtRemark.Location = new System.Drawing.Point(720, 12);
            this.m_txtRemark.Name = "m_txtRemark";
            this.m_txtRemark.Size = new System.Drawing.Size(229, 23);
            this.m_txtRemark.TabIndex = 11;
            // 
            // m_txtMan
            // 
            this.m_txtMan.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtMan.Location = new System.Drawing.Point(523, 12);
            this.m_txtMan.Name = "m_txtMan";
            this.m_txtMan.ReadOnly = true;
            this.m_txtMan.Size = new System.Drawing.Size(131, 23);
            this.m_txtMan.TabIndex = 10;
            // 
            // m_txtOrderNumber
            // 
            this.m_txtOrderNumber.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtOrderNumber.Location = new System.Drawing.Point(86, 12);
            this.m_txtOrderNumber.Name = "m_txtOrderNumber";
            this.m_txtOrderNumber.ReadOnly = true;
            this.m_txtOrderNumber.Size = new System.Drawing.Size(141, 23);
            this.m_txtOrderNumber.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(249, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 7;
            this.label7.Text = "申请部门";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 4;
            this.label5.Text = "出库部门";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(679, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "备注";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(468, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "制单人";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(249, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "办理日期";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "请领单号";
            // 
            // m_cmdSave
            // 
            this.m_cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdSave.ImageIndex = 0;
            this.m_cmdSave.ImageList = this.imageList1;
            this.m_cmdSave.Location = new System.Drawing.Point(2, 7);
            this.m_cmdSave.Name = "m_cmdSave";
            this.m_cmdSave.Size = new System.Drawing.Size(94, 28);
            this.m_cmdSave.TabIndex = 1;
            this.m_cmdSave.Text = "保存(&S)";
            this.m_cmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdSave.UseVisualStyleBackColor = true;
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
            // m_cmdDelete
            // 
            this.m_cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdDelete.ImageIndex = 2;
            this.m_cmdDelete.ImageList = this.imageList1;
            this.m_cmdDelete.Location = new System.Drawing.Point(95, 7);
            this.m_cmdDelete.Name = "m_cmdDelete";
            this.m_cmdDelete.Size = new System.Drawing.Size(93, 28);
            this.m_cmdDelete.TabIndex = 2;
            this.m_cmdDelete.Text = "删除(&D)";
            this.m_cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdDelete.UseVisualStyleBackColor = true;
            // 
            // m_cmdPrint
            // 
            this.m_cmdPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdPrint.ImageIndex = 6;
            this.m_cmdPrint.ImageList = this.imageList1;
            this.m_cmdPrint.Location = new System.Drawing.Point(187, 7);
            this.m_cmdPrint.Name = "m_cmdPrint";
            this.m_cmdPrint.Size = new System.Drawing.Size(93, 28);
            this.m_cmdPrint.TabIndex = 3;
            this.m_cmdPrint.Text = "打印(&P)";
            this.m_cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdPrint.UseVisualStyleBackColor = true;
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdNext.ImageIndex = 7;
            this.m_cmdNext.ImageList = this.imageList1;
            this.m_cmdNext.Location = new System.Drawing.Point(279, 7);
            this.m_cmdNext.Name = "m_cmdNext";
            this.m_cmdNext.Size = new System.Drawing.Size(113, 28);
            this.m_cmdNext.TabIndex = 4;
            this.m_cmdNext.Text = "下一张单(&N)";
            this.m_cmdNext.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdNext.UseVisualStyleBackColor = true;
            // 
            // m_cmdExit
            // 
            this.m_cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdExit.ImageIndex = 1;
            this.m_cmdExit.ImageList = this.imageList1;
            this.m_cmdExit.Location = new System.Drawing.Point(871, 7);
            this.m_cmdExit.Name = "m_cmdExit";
            this.m_cmdExit.Size = new System.Drawing.Size(93, 28);
            this.m_cmdExit.TabIndex = 5;
            this.m_cmdExit.Text = "退出(&Q)";
            this.m_cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdExit.UseVisualStyleBackColor = true;
            // 
            // m_dgvGetMedicineInfo
            // 
            this.m_dgvGetMedicineInfo.AllowUserToAddRows = false;
            this.m_dgvGetMedicineInfo.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dgvGetMedicineInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.m_dgvGetMedicineInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_dgvGetMedicineInfo.BackgroundColor = System.Drawing.SystemColors.Window;
            this.m_dgvGetMedicineInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_dgvGetMedicineInfo.ColumnHeadersHeight = 40;
            this.m_dgvGetMedicineInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgvGetMedicineInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_dgvtxtMedicineCode,
            this.m_dgvtxtMedicineName,
            this.m_dgvtxtMedicineSpec,
            this.m_dgvtxtGetAmount,
            this.m_dgvtxtBaseUnit,
            this.m_dgvtxtGetAmountUnit,
            this.m_dgvtxtMinUnit,
            this.m_dgvtxtCurrentAmount,
            this.m_dgvtxtCanUseAmount,
            this.m_dgvtxtBaseUnit2,
            this.m_dgvtxtExchangeRelation,
            this.m_dgvtxtSalePrice,
            this.m_dgvtxtBuyPrice,
            this.m_dgvtxtWholeSalePrice});
            this.m_dgvGetMedicineInfo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.m_dgvGetMedicineInfo.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.m_dgvGetMedicineInfo.Location = new System.Drawing.Point(0, 127);
            this.m_dgvGetMedicineInfo.Name = "m_dgvGetMedicineInfo";
            this.m_dgvGetMedicineInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_dgvGetMedicineInfo.RowHeadersVisible = false;
            this.m_dgvGetMedicineInfo.RowTemplate.Height = 23;
            this.m_dgvGetMedicineInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvGetMedicineInfo.Size = new System.Drawing.Size(978, 518);
            this.m_dgvGetMedicineInfo.TabIndex = 6;
            // 
            // m_dgvtxtMedicineCode
            // 
            this.m_dgvtxtMedicineCode.HeaderText = "代码";
            this.m_dgvtxtMedicineCode.Name = "m_dgvtxtMedicineCode";
            this.m_dgvtxtMedicineCode.Width = 80;
            // 
            // m_dgvtxtMedicineName
            // 
            this.m_dgvtxtMedicineName.HeaderText = "药品名称";
            this.m_dgvtxtMedicineName.Name = "m_dgvtxtMedicineName";
            // 
            // m_dgvtxtMedicineSpec
            // 
            this.m_dgvtxtMedicineSpec.HeaderText = "规格";
            this.m_dgvtxtMedicineSpec.Name = "m_dgvtxtMedicineSpec";
            this.m_dgvtxtMedicineSpec.Width = 60;
            // 
            // m_dgvtxtGetAmount
            // 
            this.m_dgvtxtGetAmount.HeaderText = " 申请数量   (基本单位)";
            this.m_dgvtxtGetAmount.Name = "m_dgvtxtGetAmount";
            // 
            // m_dgvtxtBaseUnit
            // 
            this.m_dgvtxtBaseUnit.HeaderText = "基本单位";
            this.m_dgvtxtBaseUnit.Name = "m_dgvtxtBaseUnit";
            this.m_dgvtxtBaseUnit.Width = 90;
            // 
            // m_dgvtxtGetAmountUnit
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.m_dgvtxtGetAmountUnit.DefaultCellStyle = dataGridViewCellStyle2;
            this.m_dgvtxtGetAmountUnit.HeaderText = " 申请数量   (最小单位)";
            this.m_dgvtxtGetAmountUnit.Name = "m_dgvtxtGetAmountUnit";
            // 
            // m_dgvtxtMinUnit
            // 
            this.m_dgvtxtMinUnit.HeaderText = "最小单位";
            this.m_dgvtxtMinUnit.Name = "m_dgvtxtMinUnit";
            this.m_dgvtxtMinUnit.Width = 90;
            // 
            // m_dgvtxtCurrentAmount
            // 
            this.m_dgvtxtCurrentAmount.HeaderText = "当前库存";
            this.m_dgvtxtCurrentAmount.Name = "m_dgvtxtCurrentAmount";
            this.m_dgvtxtCurrentAmount.Width = 90;
            // 
            // m_dgvtxtCanUseAmount
            // 
            this.m_dgvtxtCanUseAmount.HeaderText = "可用库存";
            this.m_dgvtxtCanUseAmount.Name = "m_dgvtxtCanUseAmount";
            this.m_dgvtxtCanUseAmount.Width = 90;
            // 
            // m_dgvtxtBaseUnit2
            // 
            this.m_dgvtxtBaseUnit2.HeaderText = "基本单位";
            this.m_dgvtxtBaseUnit2.Name = "m_dgvtxtBaseUnit2";
            this.m_dgvtxtBaseUnit2.Width = 90;
            // 
            // m_dgvtxtExchangeRelation
            // 
            this.m_dgvtxtExchangeRelation.HeaderText = "换算关系";
            this.m_dgvtxtExchangeRelation.Name = "m_dgvtxtExchangeRelation";
            this.m_dgvtxtExchangeRelation.Width = 90;
            // 
            // m_dgvtxtSalePrice
            // 
            this.m_dgvtxtSalePrice.HeaderText = " 零售单价   (基本单位)";
            this.m_dgvtxtSalePrice.Name = "m_dgvtxtSalePrice";
            // 
            // m_dgvtxtBuyPrice
            // 
            this.m_dgvtxtBuyPrice.HeaderText = " 购入单价   (基本单位)";
            this.m_dgvtxtBuyPrice.Name = "m_dgvtxtBuyPrice";
            // 
            // m_dgvtxtWholeSalePrice
            // 
            this.m_dgvtxtWholeSalePrice.HeaderText = " 批发单价   (基本单位)";
            this.m_dgvtxtWholeSalePrice.Name = "m_dgvtxtWholeSalePrice";
            // 
            // frmGetMedicinePlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_cmdExit;
            this.ClientSize = new System.Drawing.Size(973, 648);
            this.Controls.Add(this.m_dgvGetMedicineInfo);
            this.Controls.Add(this.m_cmdExit);
            this.Controls.Add(this.m_cmdNext);
            this.Controls.Add(this.m_cmdPrint);
            this.Controls.Add(this.m_cmdDelete);
            this.Controls.Add(this.m_cmdSave);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmGetMedicinePlan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "领药计划(药房新制)";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvGetMedicineInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion


        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button m_cmdSave;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button m_cmdDelete;
        private System.Windows.Forms.Button m_cmdPrint;
        private System.Windows.Forms.Button m_cmdNext;
        private System.Windows.Forms.Button m_cmdExit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox m_txtRequisitionDept;
        private System.Windows.Forms.TextBox m_txtOutDept;
        private System.Windows.Forms.TextBox m_txtRemark;
        private System.Windows.Forms.TextBox m_txtMan;
        private System.Windows.Forms.TextBox m_txtOrderNumber;
        internal com.digitalwave.controls.MedicineStoreControls.ctlDataGridView_EnterAsTab m_dgvGetMedicineInfo;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker_EnterKeyAsTab m_dtpDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtGetAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtBaseUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtGetAmountUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMinUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtCurrentAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtCanUseAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtBaseUnit2;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtExchangeRelation;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtSalePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtBuyPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtWholeSalePrice;
    }
}