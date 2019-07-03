namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    partial class frmCheckMedicineOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCheckMedicineOrder));
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.m_bgwGetStorageData = new System.ComponentModel.BackgroundWorker();
            this.m_bgwGetMedicineDict = new System.ComponentModel.BackgroundWorker();
            this.m_lblCheckAll = new System.Windows.Forms.Label();
            this.m_cmdDelete = new System.Windows.Forms.Button();
            this.m_cmdSave = new System.Windows.Forms.Button();
            this.m_cmdAddNew = new System.Windows.Forms.Button();
            this.m_cmdJumpToSpecRow = new System.Windows.Forms.Button();
            this.m_txtJumpToRow = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_cmdDownToLast = new System.Windows.Forms.Button();
            this.m_cmdDown = new System.Windows.Forms.Button();
            this.m_cmdUp = new System.Windows.Forms.Button();
            this.m_cmdUpToFirst = new System.Windows.Forms.Button();
            this.m_cmdClose = new System.Windows.Forms.Button();
            this.m_cmdBatchInput = new System.Windows.Forms.Button();
            this.m_dgvMedicineOrder = new com.digitalwave.controls.MedicineStoreControls.ctlDataGridView_EnterAsTab();
            this.m_dgvchkAllCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.m_dgvtxtOrderNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedicineCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedicineName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtMedicineSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvtxtUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_txtStoragePack = new System.Windows.Forms.TextBox();
            this.m_lblPack = new System.Windows.Forms.Label();
            this.m_txtStorage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvMedicineOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "Shell32 007.ico");
            this.imageList2.Images.SetKeyName(1, "Shell32 028.ico");
            this.imageList2.Images.SetKeyName(2, "Shell32 132.ico");
            this.imageList2.Images.SetKeyName(3, "Shell32 148.ico");
            this.imageList2.Images.SetKeyName(4, "Shell32 058.ico");
            this.imageList2.Images.SetKeyName(5, "m_cmdRefresh.Image.png");
            this.imageList2.Images.SetKeyName(6, "Shell32 137.ico");
            this.imageList2.Images.SetKeyName(7, "Shell32 177.ico");
            this.imageList2.Images.SetKeyName(8, "Shell32 136.ico");
            this.imageList2.Images.SetKeyName(9, "Shell32 055.ico");
            this.imageList2.Images.SetKeyName(10, "Shell32 147.ico");
            this.imageList2.Images.SetKeyName(11, "Shell32 133.ico");
            this.imageList2.Images.SetKeyName(12, "Shell32 088.ico");
            this.imageList2.Images.SetKeyName(13, "Shell32 023.ico");
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            // 
            // m_bgwGetStorageData
            // 
            this.m_bgwGetStorageData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.m_bgwGetStorageData_DoWork);
            this.m_bgwGetStorageData.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.m_bgwGetStorageData_RunWorkerCompleted);
            // 
            // m_bgwGetMedicineDict
            // 
            this.m_bgwGetMedicineDict.DoWork += new System.ComponentModel.DoWorkEventHandler(this.m_bgwGetMedicineDict_DoWork);
            // 
            // m_lblCheckAll
            // 
            this.m_lblCheckAll.Font = new System.Drawing.Font("宋体", 9F);
            this.m_lblCheckAll.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.m_lblCheckAll.Location = new System.Drawing.Point(13, 69);
            this.m_lblCheckAll.Name = "m_lblCheckAll";
            this.m_lblCheckAll.Size = new System.Drawing.Size(15, 25);
            this.m_lblCheckAll.TabIndex = 192;
            this.m_lblCheckAll.Text = "全选";
            this.m_lblCheckAll.Click += new System.EventHandler(this.m_lblCheckAll_Click);
            // 
            // m_cmdDelete
            // 
            this.m_cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdDelete.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdDelete.ImageIndex = 2;
            this.m_cmdDelete.ImageList = this.imageList2;
            this.m_cmdDelete.Location = new System.Drawing.Point(281, 3);
            this.m_cmdDelete.Name = "m_cmdDelete";
            this.m_cmdDelete.Size = new System.Drawing.Size(94, 28);
            this.m_cmdDelete.TabIndex = 191;
            this.m_cmdDelete.Text = "删除(&D)";
            this.m_cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdDelete.UseVisualStyleBackColor = true;
            this.m_cmdDelete.Click += new System.EventHandler(this.m_cmdDelete_Click);
            // 
            // m_cmdSave
            // 
            this.m_cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdSave.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdSave.ImageIndex = 0;
            this.m_cmdSave.ImageList = this.imageList2;
            this.m_cmdSave.Location = new System.Drawing.Point(188, 3);
            this.m_cmdSave.Name = "m_cmdSave";
            this.m_cmdSave.Size = new System.Drawing.Size(94, 28);
            this.m_cmdSave.TabIndex = 191;
            this.m_cmdSave.Text = "保存(&S)";
            this.m_cmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdSave.UseVisualStyleBackColor = true;
            this.m_cmdSave.Click += new System.EventHandler(this.m_cmdSave_Click);
            // 
            // m_cmdAddNew
            // 
            this.m_cmdAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdAddNew.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdAddNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdAddNew.ImageIndex = 9;
            this.m_cmdAddNew.ImageList = this.imageList2;
            this.m_cmdAddNew.Location = new System.Drawing.Point(6, 3);
            this.m_cmdAddNew.Name = "m_cmdAddNew";
            this.m_cmdAddNew.Size = new System.Drawing.Size(94, 28);
            this.m_cmdAddNew.TabIndex = 191;
            this.m_cmdAddNew.Text = "新增(&N)";
            this.m_cmdAddNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdAddNew.UseVisualStyleBackColor = true;
            this.m_cmdAddNew.Click += new System.EventHandler(this.m_cmdAddNew_Click);
            // 
            // m_cmdJumpToSpecRow
            // 
            this.m_cmdJumpToSpecRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdJumpToSpecRow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_cmdJumpToSpecRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdJumpToSpecRow.ImageIndex = 0;
            this.m_cmdJumpToSpecRow.ImageList = this.imageList1;
            this.m_cmdJumpToSpecRow.Location = new System.Drawing.Point(809, 38);
            this.m_cmdJumpToSpecRow.Name = "m_cmdJumpToSpecRow";
            this.m_cmdJumpToSpecRow.Size = new System.Drawing.Size(21, 21);
            this.m_cmdJumpToSpecRow.TabIndex = 9;
            this.m_cmdJumpToSpecRow.UseVisualStyleBackColor = true;
            this.m_cmdJumpToSpecRow.Click += new System.EventHandler(this.m_cmdJumpToSpecRow_Click);
            // 
            // m_txtJumpToRow
            // 
            this.m_txtJumpToRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtJumpToRow.Location = new System.Drawing.Point(727, 38);
            this.m_txtJumpToRow.Name = "m_txtJumpToRow";
            this.m_txtJumpToRow.Size = new System.Drawing.Size(63, 23);
            this.m_txtJumpToRow.TabIndex = 8;
            this.m_txtJumpToRow.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtJumpToRow_KeyDown);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(608, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(203, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "选定药品跳转至第          行";
            // 
            // m_cmdDownToLast
            // 
            this.m_cmdDownToLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdDownToLast.ImageIndex = 4;
            this.m_cmdDownToLast.ImageList = this.imageList1;
            this.m_cmdDownToLast.Location = new System.Drawing.Point(551, 37);
            this.m_cmdDownToLast.Name = "m_cmdDownToLast";
            this.m_cmdDownToLast.Size = new System.Drawing.Size(23, 25);
            this.m_cmdDownToLast.TabIndex = 6;
            this.m_cmdDownToLast.UseVisualStyleBackColor = true;
            this.m_cmdDownToLast.Click += new System.EventHandler(this.m_cmdDownToLast_Click);
            // 
            // m_cmdDown
            // 
            this.m_cmdDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdDown.ImageIndex = 2;
            this.m_cmdDown.ImageList = this.imageList1;
            this.m_cmdDown.Location = new System.Drawing.Point(522, 37);
            this.m_cmdDown.Name = "m_cmdDown";
            this.m_cmdDown.Size = new System.Drawing.Size(23, 25);
            this.m_cmdDown.TabIndex = 6;
            this.m_cmdDown.UseVisualStyleBackColor = true;
            this.m_cmdDown.Click += new System.EventHandler(this.m_cmdDown_Click);
            // 
            // m_cmdUp
            // 
            this.m_cmdUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdUp.ImageIndex = 1;
            this.m_cmdUp.ImageList = this.imageList1;
            this.m_cmdUp.Location = new System.Drawing.Point(493, 37);
            this.m_cmdUp.Name = "m_cmdUp";
            this.m_cmdUp.Size = new System.Drawing.Size(23, 25);
            this.m_cmdUp.TabIndex = 6;
            this.m_cmdUp.UseVisualStyleBackColor = true;
            this.m_cmdUp.Click += new System.EventHandler(this.m_cmdUp_Click);
            // 
            // m_cmdUpToFirst
            // 
            this.m_cmdUpToFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdUpToFirst.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_cmdUpToFirst.ImageIndex = 3;
            this.m_cmdUpToFirst.ImageList = this.imageList1;
            this.m_cmdUpToFirst.Location = new System.Drawing.Point(464, 37);
            this.m_cmdUpToFirst.Name = "m_cmdUpToFirst";
            this.m_cmdUpToFirst.Size = new System.Drawing.Size(23, 25);
            this.m_cmdUpToFirst.TabIndex = 6;
            this.m_cmdUpToFirst.UseVisualStyleBackColor = true;
            this.m_cmdUpToFirst.Click += new System.EventHandler(this.m_cmdUpToFirst_Click);
            // 
            // m_cmdClose
            // 
            this.m_cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdClose.ImageIndex = 1;
            this.m_cmdClose.ImageList = this.imageList2;
            this.m_cmdClose.Location = new System.Drawing.Point(735, 3);
            this.m_cmdClose.Name = "m_cmdClose";
            this.m_cmdClose.Size = new System.Drawing.Size(94, 28);
            this.m_cmdClose.TabIndex = 5;
            this.m_cmdClose.Text = "退出(&Q)";
            this.m_cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdClose.UseVisualStyleBackColor = true;
            this.m_cmdClose.Click += new System.EventHandler(this.m_cmdClose_Click);
            // 
            // m_cmdBatchInput
            // 
            this.m_cmdBatchInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdBatchInput.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdBatchInput.ImageIndex = 3;
            this.m_cmdBatchInput.ImageList = this.imageList2;
            this.m_cmdBatchInput.Location = new System.Drawing.Point(374, 3);
            this.m_cmdBatchInput.Name = "m_cmdBatchInput";
            this.m_cmdBatchInput.Size = new System.Drawing.Size(94, 28);
            this.m_cmdBatchInput.TabIndex = 5;
            this.m_cmdBatchInput.Text = "批量录入";
            this.m_cmdBatchInput.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdBatchInput.UseVisualStyleBackColor = true;
            this.m_cmdBatchInput.Click += new System.EventHandler(this.m_cmdBatchInput_Click);
            // 
            // m_dgvMedicineOrder
            // 
            this.m_dgvMedicineOrder.AllowUserToAddRows = false;
            this.m_dgvMedicineOrder.AllowUserToDeleteRows = false;
            this.m_dgvMedicineOrder.AllowUserToResizeRows = false;
            this.m_dgvMedicineOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_dgvMedicineOrder.BackgroundColor = System.Drawing.SystemColors.Info;
            this.m_dgvMedicineOrder.ColumnHeadersHeight = 30;
            this.m_dgvMedicineOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_dgvchkAllCheck,
            this.m_dgvtxtOrderNum,
            this.m_dgvtxtMedicineCode,
            this.m_dgvtxtMedicineName,
            this.m_dgvtxtMedicineSpec,
            this.m_dgvtxtUnit});
            this.m_dgvMedicineOrder.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.m_dgvMedicineOrder.Location = new System.Drawing.Point(6, 66);
            this.m_dgvMedicineOrder.Name = "m_dgvMedicineOrder";
            this.m_dgvMedicineOrder.RowHeadersVisible = false;
            this.m_dgvMedicineOrder.RowTemplate.Height = 23;
            this.m_dgvMedicineOrder.Size = new System.Drawing.Size(832, 460);
            this.m_dgvMedicineOrder.TabIndex = 4;
            this.m_dgvMedicineOrder.EnterKeyPress += new com.digitalwave.controls.MedicineStoreControls.EnterKeyPressInCurrentCell(this.m_dgvMedicineOrder_EnterKeyPress);
            // 
            // m_dgvchkAllCheck
            // 
            this.m_dgvchkAllCheck.Frozen = true;
            this.m_dgvchkAllCheck.HeaderText = "";
            this.m_dgvchkAllCheck.Name = "m_dgvchkAllCheck";
            this.m_dgvchkAllCheck.Width = 30;
            // 
            // m_dgvtxtOrderNum
            // 
            this.m_dgvtxtOrderNum.DataPropertyName = "checkmedicineorder_chr";
            this.m_dgvtxtOrderNum.HeaderText = "顺序号";
            this.m_dgvtxtOrderNum.Name = "m_dgvtxtOrderNum";
            this.m_dgvtxtOrderNum.ReadOnly = true;
            this.m_dgvtxtOrderNum.Width = 150;
            // 
            // m_dgvtxtMedicineCode
            // 
            this.m_dgvtxtMedicineCode.DataPropertyName = "assistcode_chr";
            this.m_dgvtxtMedicineCode.HeaderText = "药品代码";
            this.m_dgvtxtMedicineCode.Name = "m_dgvtxtMedicineCode";
            this.m_dgvtxtMedicineCode.Width = 150;
            // 
            // m_dgvtxtMedicineName
            // 
            this.m_dgvtxtMedicineName.DataPropertyName = "medicinename_vchr";
            this.m_dgvtxtMedicineName.HeaderText = "药品名称";
            this.m_dgvtxtMedicineName.Name = "m_dgvtxtMedicineName";
            this.m_dgvtxtMedicineName.ReadOnly = true;
            this.m_dgvtxtMedicineName.Width = 300;
            // 
            // m_dgvtxtMedicineSpec
            // 
            this.m_dgvtxtMedicineSpec.DataPropertyName = "medspec_vchr";
            this.m_dgvtxtMedicineSpec.HeaderText = "规格";
            this.m_dgvtxtMedicineSpec.Name = "m_dgvtxtMedicineSpec";
            this.m_dgvtxtMedicineSpec.ReadOnly = true;
            this.m_dgvtxtMedicineSpec.Width = 150;
            // 
            // m_dgvtxtUnit
            // 
            this.m_dgvtxtUnit.DataPropertyName = "opunit_chr";
            this.m_dgvtxtUnit.HeaderText = "单位";
            this.m_dgvtxtUnit.Name = "m_dgvtxtUnit";
            this.m_dgvtxtUnit.ReadOnly = true;
            // 
            // m_txtStoragePack
            // 
            this.m_txtStoragePack.Location = new System.Drawing.Point(268, 37);
            this.m_txtStoragePack.Name = "m_txtStoragePack";
            this.m_txtStoragePack.Size = new System.Drawing.Size(142, 23);
            this.m_txtStoragePack.TabIndex = 3;
            this.m_txtStoragePack.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtStoragePack_KeyDown);
            // 
            // m_lblPack
            // 
            this.m_lblPack.AutoSize = true;
            this.m_lblPack.Location = new System.Drawing.Point(227, 41);
            this.m_lblPack.Name = "m_lblPack";
            this.m_lblPack.Size = new System.Drawing.Size(35, 14);
            this.m_lblPack.TabIndex = 2;
            this.m_lblPack.Text = "货架";
            // 
            // m_txtStorage
            // 
            this.m_txtStorage.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtStorage.Enabled = false;
            this.m_txtStorage.Location = new System.Drawing.Point(53, 37);
            this.m_txtStorage.Name = "m_txtStorage";
            this.m_txtStorage.Size = new System.Drawing.Size(144, 23);
            this.m_txtStorage.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "仓库";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.ImageIndex = 5;
            this.button1.ImageList = this.imageList2;
            this.button1.Location = new System.Drawing.Point(99, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 28);
            this.button1.TabIndex = 193;
            this.button1.Text = "刷新(&R)";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmCheckMedicineOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 531);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.m_lblCheckAll);
            this.Controls.Add(this.m_cmdDelete);
            this.Controls.Add(this.m_cmdSave);
            this.Controls.Add(this.m_cmdAddNew);
            this.Controls.Add(this.m_cmdJumpToSpecRow);
            this.Controls.Add(this.m_txtJumpToRow);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_cmdDownToLast);
            this.Controls.Add(this.m_cmdDown);
            this.Controls.Add(this.m_cmdUp);
            this.Controls.Add(this.m_cmdUpToFirst);
            this.Controls.Add(this.m_cmdClose);
            this.Controls.Add(this.m_cmdBatchInput);
            this.Controls.Add(this.m_dgvMedicineOrder);
            this.Controls.Add(this.m_txtStoragePack);
            this.Controls.Add(this.m_lblPack);
            this.Controls.Add(this.m_txtStorage);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCheckMedicineOrder";
            this.Text = "盘点药品顺序设置";
            this.Load += new System.EventHandler(this.frmCheckMedicineOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvMedicineOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button m_cmdBatchInput;
        private System.Windows.Forms.Button m_cmdUpToFirst;
        private System.Windows.Forms.Button m_cmdUp;
        private System.Windows.Forms.Button m_cmdDown;
        private System.Windows.Forms.Button m_cmdDownToLast;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button m_cmdJumpToSpecRow;
        private System.Windows.Forms.ImageList imageList2;
        internal System.Windows.Forms.Button m_cmdAddNew;
        internal System.Windows.Forms.Button m_cmdSave;
        internal System.Windows.Forms.Button m_cmdDelete;
        private System.Windows.Forms.Button m_cmdClose;
        internal System.Windows.Forms.TextBox m_txtStorage;
        internal System.Windows.Forms.TextBox m_txtStoragePack;
        internal System.Windows.Forms.TextBox m_txtJumpToRow;
        internal com.digitalwave.controls.MedicineStoreControls.ctlDataGridView_EnterAsTab m_dgvMedicineOrder;
        internal System.Windows.Forms.Label m_lblPack;
        private System.ComponentModel.BackgroundWorker m_bgwGetStorageData;
        private System.ComponentModel.BackgroundWorker m_bgwGetMedicineDict;
        private System.Windows.Forms.DataGridViewCheckBoxColumn m_dgvchkAllCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtOrderNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtMedicineSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvtxtUnit;
        public System.Windows.Forms.Label m_lblCheckAll;
        internal System.Windows.Forms.Button button1;
    }
}