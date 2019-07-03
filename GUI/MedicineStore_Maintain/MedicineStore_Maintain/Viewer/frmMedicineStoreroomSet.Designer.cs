namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    partial class frmMedicineStoreroomSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMedicineStoreroomSet));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.m_cmdExit = new System.Windows.Forms.Button();
            this.lblMedStoreName = new System.Windows.Forms.Label();
            this.m_txtMedStoreShortName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.m_txtDept = new com.digitalwave.Controls.Domain.EmrControls.ctlDeptSelected_EnterKeyActive();
            this.m_cmdDelete = new System.Windows.Forms.Button();
            this.m_cmdSave = new System.Windows.Forms.Button();
            this.m_cmdAdd = new System.Windows.Forms.Button();
            this.m_lsvMedicineStore = new System.Windows.Forms.ListView();
            this.m_colMedicineStoreType = new System.Windows.Forms.ColumnHeader();
            this.m_colMedicineStoreName = new System.Windows.Forms.ColumnHeader();
            this.m_colDeptName = new System.Windows.Forms.ColumnHeader();
            this.m_colMedicineStoreShortName = new System.Windows.Forms.ColumnHeader();
            this.m_lsvMedicineName = new System.Windows.Forms.ListView();
            this.m_colMedicineName1 = new System.Windows.Forms.ColumnHeader();
            this.m_txtMedicineStoreRoom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            // 
            // m_cmdExit
            // 
            this.m_cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdExit.ImageIndex = 1;
            this.m_cmdExit.ImageList = this.imageList1;
            this.m_cmdExit.Location = new System.Drawing.Point(141, 488);
            this.m_cmdExit.Name = "m_cmdExit";
            this.m_cmdExit.Size = new System.Drawing.Size(94, 32);
            this.m_cmdExit.TabIndex = 7;
            this.m_cmdExit.Text = "退出(&Q)";
            this.m_cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdExit.UseVisualStyleBackColor = true;
            this.m_cmdExit.Click += new System.EventHandler(this.m_cmdExit_Click);
            // 
            // lblMedStoreName
            // 
            this.lblMedStoreName.AutoSize = true;
            this.lblMedStoreName.Location = new System.Drawing.Point(17, 46);
            this.lblMedStoreName.Name = "lblMedStoreName";
            this.lblMedStoreName.Size = new System.Drawing.Size(63, 14);
            this.lblMedStoreName.TabIndex = 14;
            this.lblMedStoreName.Text = "仓库简码";
            // 
            // m_txtMedStoreShortName
            // 
            this.m_txtMedStoreShortName.Location = new System.Drawing.Point(84, 41);
            this.m_txtMedStoreShortName.MaxLength = 3;
            this.m_txtMedStoreShortName.Name = "m_txtMedStoreShortName";
            this.m_txtMedStoreShortName.Size = new System.Drawing.Size(183, 23);
            this.m_txtMedStoreShortName.TabIndex = 1;
            this.m_txtMedStoreShortName.TextChanged += new System.EventHandler(this.m_txtMedStoreShortName_TextChanged);
            this.m_txtMedStoreShortName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtMedStoreShortName_KeyDown);
            this.m_txtMedStoreShortName.Leave += new System.EventHandler(this.m_txtMedStoreShortName_Leave);
            this.m_txtMedStoreShortName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtMedStoreShortName_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 14);
            this.label10.TabIndex = 12;
            this.label10.Text = "对应部门";
            // 
            // m_txtDept
            // 
            this.m_txtDept.Location = new System.Drawing.Point(84, 74);
            this.m_txtDept.m_objTag = null;
            this.m_txtDept.Name = "m_txtDept";
            this.m_txtDept.Size = new System.Drawing.Size(183, 23);
            this.m_txtDept.TabIndex = 2;
            this.m_txtDept.显示类型 = com.digitalwave.Controls.Domain.EmrControls.enmDeptAttributeType.全部;
            this.m_txtDept.ItemSelectedChanged += new com.digitalwave.Controls.ItemSelectedEventHandler(this.m_txtDept_ItemSelectedChanged);
            // 
            // m_cmdDelete
            // 
            this.m_cmdDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdDelete.ImageIndex = 2;
            this.m_cmdDelete.ImageList = this.imageList1;
            this.m_cmdDelete.Location = new System.Drawing.Point(141, 446);
            this.m_cmdDelete.Name = "m_cmdDelete";
            this.m_cmdDelete.Size = new System.Drawing.Size(94, 32);
            this.m_cmdDelete.TabIndex = 5;
            this.m_cmdDelete.Text = "删除(&D)";
            this.m_cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdDelete.UseVisualStyleBackColor = true;
            this.m_cmdDelete.Click += new System.EventHandler(this.m_cmdDelete_Click);
            // 
            // m_cmdSave
            // 
            this.m_cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdSave.ImageIndex = 0;
            this.m_cmdSave.ImageList = this.imageList1;
            this.m_cmdSave.Location = new System.Drawing.Point(32, 488);
            this.m_cmdSave.Name = "m_cmdSave";
            this.m_cmdSave.Size = new System.Drawing.Size(94, 32);
            this.m_cmdSave.TabIndex = 6;
            this.m_cmdSave.Text = "保存(&S)";
            this.m_cmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdSave.UseVisualStyleBackColor = true;
            this.m_cmdSave.Click += new System.EventHandler(this.m_cmdSave_Click);
            // 
            // m_cmdAdd
            // 
            this.m_cmdAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_cmdAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdAdd.ImageIndex = 5;
            this.m_cmdAdd.ImageList = this.imageList1;
            this.m_cmdAdd.Location = new System.Drawing.Point(32, 446);
            this.m_cmdAdd.Name = "m_cmdAdd";
            this.m_cmdAdd.Size = new System.Drawing.Size(94, 32);
            this.m_cmdAdd.TabIndex = 4;
            this.m_cmdAdd.Text = "清空(&R)";
            this.m_cmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdAdd.UseVisualStyleBackColor = true;
            this.m_cmdAdd.Click += new System.EventHandler(this.m_cmdAdd_Click);
            // 
            // m_lsvMedicineStore
            // 
            this.m_lsvMedicineStore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lsvMedicineStore.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_colMedicineStoreType,
            this.m_colMedicineStoreName,
            this.m_colDeptName,
            this.m_colMedicineStoreShortName});
            this.m_lsvMedicineStore.FullRowSelect = true;
            this.m_lsvMedicineStore.GridLines = true;
            this.m_lsvMedicineStore.HideSelection = false;
            this.m_lsvMedicineStore.Location = new System.Drawing.Point(288, 9);
            this.m_lsvMedicineStore.MultiSelect = false;
            this.m_lsvMedicineStore.Name = "m_lsvMedicineStore";
            this.m_lsvMedicineStore.Size = new System.Drawing.Size(530, 505);
            this.m_lsvMedicineStore.TabIndex = 3;
            this.m_lsvMedicineStore.UseCompatibleStateImageBehavior = false;
            this.m_lsvMedicineStore.View = System.Windows.Forms.View.Details;
            this.m_lsvMedicineStore.SelectedIndexChanged += new System.EventHandler(this.m_lsvMedicineStore_SelectedIndexChanged);
            this.m_lsvMedicineStore.Click += new System.EventHandler(this.m_lsvMedicineStore_Click);
            // 
            // m_colMedicineStoreType
            // 
            this.m_colMedicineStoreType.Text = "仓库ID";
            this.m_colMedicineStoreType.Width = 94;
            // 
            // m_colMedicineStoreName
            // 
            this.m_colMedicineStoreName.Text = "仓库名称";
            this.m_colMedicineStoreName.Width = 200;
            // 
            // m_colDeptName
            // 
            this.m_colDeptName.Text = "对应部门";
            this.m_colDeptName.Width = 200;
            // 
            // m_colMedicineStoreShortName
            // 
            this.m_colMedicineStoreShortName.Text = "仓库简码";
            this.m_colMedicineStoreShortName.Width = 135;
            // 
            // m_lsvMedicineName
            // 
            this.m_lsvMedicineName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lsvMedicineName.CheckBoxes = true;
            this.m_lsvMedicineName.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_colMedicineName1});
            this.m_lsvMedicineName.GridLines = true;
            this.m_lsvMedicineName.Location = new System.Drawing.Point(20, 101);
            this.m_lsvMedicineName.Name = "m_lsvMedicineName";
            this.m_lsvMedicineName.Size = new System.Drawing.Size(248, 336);
            this.m_lsvMedicineName.TabIndex = 13;
            this.m_lsvMedicineName.UseCompatibleStateImageBehavior = false;
            this.m_lsvMedicineName.View = System.Windows.Forms.View.Details;
            // 
            // m_colMedicineName1
            // 
            this.m_colMedicineName1.Text = "药品类型";
            this.m_colMedicineName1.Width = 240;
            // 
            // m_txtMedicineStoreRoom
            // 
            this.m_txtMedicineStoreRoom.Location = new System.Drawing.Point(85, 8);
            this.m_txtMedicineStoreRoom.Name = "m_txtMedicineStoreRoom";
            this.m_txtMedicineStoreRoom.Size = new System.Drawing.Size(183, 23);
            this.m_txtMedicineStoreRoom.TabIndex = 0;
            this.m_txtMedicineStoreRoom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtMedicineStoreRoom_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "仓库名称";
            // 
            // frmMedicineStoreroomSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_cmdExit;
            this.ClientSize = new System.Drawing.Size(840, 527);
            this.Controls.Add(this.lblMedStoreName);
            this.Controls.Add(this.m_txtMedStoreShortName);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.m_txtDept);
            this.Controls.Add(this.m_cmdExit);
            this.Controls.Add(this.m_cmdDelete);
            this.Controls.Add(this.m_cmdSave);
            this.Controls.Add(this.m_cmdAdd);
            this.Controls.Add(this.m_lsvMedicineStore);
            this.Controls.Add(this.m_lsvMedicineName);
            this.Controls.Add(this.m_txtMedicineStoreRoom);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMedicineStoreroomSet";
            this.Text = "药品仓库设置";
            this.Load += new System.EventHandler(this.frmMedicineStoreroomSet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView m_lsvMedicineStore;
        private System.Windows.Forms.Button m_cmdAdd;
        private System.Windows.Forms.Button m_cmdSave;
        private System.Windows.Forms.Button m_cmdDelete;
        private System.Windows.Forms.Button m_cmdExit;
        private System.Windows.Forms.ColumnHeader m_colMedicineName1;
        private System.Windows.Forms.ColumnHeader m_colMedicineStoreType;
        private System.Windows.Forms.ColumnHeader m_colMedicineStoreName;
        internal System.Windows.Forms.ListView m_lsvMedicineName;
        internal System.Windows.Forms.TextBox m_txtMedicineStoreRoom;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ColumnHeader m_colDeptName;
        private System.Windows.Forms.Label label10;
        internal com.digitalwave.Controls.Domain.EmrControls.ctlDeptSelected_EnterKeyActive m_txtDept;
        internal System.Windows.Forms.TextBox m_txtMedStoreShortName;
        private System.Windows.Forms.Label lblMedStoreName;
        private System.Windows.Forms.ColumnHeader m_colMedicineStoreShortName;
    }
}