namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    partial class frmMedicintTypeSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMedicintTypeSet));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.m_cmdExit = new System.Windows.Forms.Button();
            this.m_cmdDelete = new System.Windows.Forms.Button();
            this.m_cmdSave = new System.Windows.Forms.Button();
            this.m_cmdAdd = new System.Windows.Forms.Button();
            this.m_lsvMedicineTypeSet = new System.Windows.Forms.ListView();
            this.m_colID = new System.Windows.Forms.ColumnHeader();
            this.m_colName = new System.Windows.Forms.ColumnHeader();
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
            this.m_cmdExit.Location = new System.Drawing.Point(144, 486);
            this.m_cmdExit.Name = "m_cmdExit";
            this.m_cmdExit.Size = new System.Drawing.Size(94, 32);
            this.m_cmdExit.TabIndex = 15;
            this.m_cmdExit.Text = "退出(&Q)";
            this.m_cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdExit.UseVisualStyleBackColor = true;
            this.m_cmdExit.Click += new System.EventHandler(this.m_cmdExit_Click);
            // 
            // m_cmdDelete
            // 
            this.m_cmdDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdDelete.ImageIndex = 2;
            this.m_cmdDelete.ImageList = this.imageList1;
            this.m_cmdDelete.Location = new System.Drawing.Point(144, 444);
            this.m_cmdDelete.Name = "m_cmdDelete";
            this.m_cmdDelete.Size = new System.Drawing.Size(94, 32);
            this.m_cmdDelete.TabIndex = 14;
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
            this.m_cmdSave.Location = new System.Drawing.Point(35, 486);
            this.m_cmdSave.Name = "m_cmdSave";
            this.m_cmdSave.Size = new System.Drawing.Size(94, 32);
            this.m_cmdSave.TabIndex = 13;
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
            this.m_cmdAdd.Location = new System.Drawing.Point(35, 444);
            this.m_cmdAdd.Name = "m_cmdAdd";
            this.m_cmdAdd.Size = new System.Drawing.Size(94, 32);
            this.m_cmdAdd.TabIndex = 12;
            this.m_cmdAdd.Text = "清空(&R)";
            this.m_cmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdAdd.UseVisualStyleBackColor = true;
            this.m_cmdAdd.Click += new System.EventHandler(this.m_cmdAdd_Click);
            // 
            // m_lsvMedicineTypeSet
            // 
            this.m_lsvMedicineTypeSet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lsvMedicineTypeSet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_colID,
            this.m_colName});
            this.m_lsvMedicineTypeSet.FullRowSelect = true;
            this.m_lsvMedicineTypeSet.GridLines = true;
            this.m_lsvMedicineTypeSet.HideSelection = false;
            this.m_lsvMedicineTypeSet.Location = new System.Drawing.Point(291, 10);
            this.m_lsvMedicineTypeSet.MultiSelect = false;
            this.m_lsvMedicineTypeSet.Name = "m_lsvMedicineTypeSet";
            this.m_lsvMedicineTypeSet.Size = new System.Drawing.Size(534, 509);
            this.m_lsvMedicineTypeSet.TabIndex = 11;
            this.m_lsvMedicineTypeSet.UseCompatibleStateImageBehavior = false;
            this.m_lsvMedicineTypeSet.View = System.Windows.Forms.View.Details;
            this.m_lsvMedicineTypeSet.SelectedIndexChanged += new System.EventHandler(this.m_lsvMedicineTypeSet_SelectedIndexChanged);
            // 
            // m_colID
            // 
            this.m_colID.Text = "药品类型设置ID";
            this.m_colID.Width = 119;
            // 
            // m_colName
            // 
            this.m_colName.Text = "药品类型设置名称";
            this.m_colName.Width = 285;
            // 
            // m_lsvMedicineName
            // 
            this.m_lsvMedicineName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lsvMedicineName.CheckBoxes = true;
            this.m_lsvMedicineName.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_colMedicineName1});
            this.m_lsvMedicineName.GridLines = true;
            this.m_lsvMedicineName.Location = new System.Drawing.Point(23, 54);
            this.m_lsvMedicineName.Name = "m_lsvMedicineName";
            this.m_lsvMedicineName.Size = new System.Drawing.Size(248, 375);
            this.m_lsvMedicineName.TabIndex = 10;
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
            this.m_txtMedicineStoreRoom.Location = new System.Drawing.Point(88, 12);
            this.m_txtMedicineStoreRoom.Name = "m_txtMedicineStoreRoom";
            this.m_txtMedicineStoreRoom.Size = new System.Drawing.Size(183, 23);
            this.m_txtMedicineStoreRoom.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "类型名称";
            // 
            // frmMedicintTypeSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 531);
            this.Controls.Add(this.m_cmdExit);
            this.Controls.Add(this.m_cmdDelete);
            this.Controls.Add(this.m_cmdSave);
            this.Controls.Add(this.m_cmdAdd);
            this.Controls.Add(this.m_lsvMedicineTypeSet);
            this.Controls.Add(this.m_lsvMedicineName);
            this.Controls.Add(this.m_txtMedicineStoreRoom);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMedicintTypeSet";
            this.Text = "药品类型设置";
            this.Load += new System.EventHandler(this.frmMedicintTypeSet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button m_cmdExit;
        private System.Windows.Forms.Button m_cmdDelete;
        private System.Windows.Forms.Button m_cmdSave;
        private System.Windows.Forms.Button m_cmdAdd;
        private System.Windows.Forms.ColumnHeader m_colID;
        private System.Windows.Forms.ColumnHeader m_colName;
        internal System.Windows.Forms.ListView m_lsvMedicineName;
        private System.Windows.Forms.ColumnHeader m_colMedicineName1;
        internal System.Windows.Forms.TextBox m_txtMedicineStoreRoom;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ListView m_lsvMedicineTypeSet;
    }
}