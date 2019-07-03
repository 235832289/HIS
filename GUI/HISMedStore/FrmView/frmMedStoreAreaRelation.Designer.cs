namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmMedStoreAreaRelation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMedStoreAreaRelation));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_lsvAllAreas = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_btnRight = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.m_btnLeft = new System.Windows.Forms.Button();
            this.m_btnDown = new System.Windows.Forms.Button();
            this.m_btnUp = new System.Windows.Forms.Button();
            this.m_btnSave = new PinkieControls.ButtonXP();
            this.cboMedStoreType = new com.digitalwave.iCare.gui.HIS.exComboBox();
            this.m_btnRefresh = new PinkieControls.ButtonXP();
            this.buttonXP2 = new PinkieControls.ButtonXP();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_lsvCurrentArea = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_lsvAllAreas);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 509);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "所有病区";
            // 
            // m_lsvAllAreas
            // 
            this.m_lsvAllAreas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader2});
            this.m_lsvAllAreas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvAllAreas.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvAllAreas.FullRowSelect = true;
            this.m_lsvAllAreas.GridLines = true;
            this.m_lsvAllAreas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.m_lsvAllAreas.HideSelection = false;
            this.m_lsvAllAreas.Location = new System.Drawing.Point(3, 19);
            this.m_lsvAllAreas.MultiSelect = false;
            this.m_lsvAllAreas.Name = "m_lsvAllAreas";
            this.m_lsvAllAreas.Size = new System.Drawing.Size(287, 487);
            this.m_lsvAllAreas.TabIndex = 0;
            this.m_lsvAllAreas.UseCompatibleStateImageBehavior = false;
            this.m_lsvAllAreas.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "病区编号";
            this.columnHeader5.Width = 0;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "病区名称";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 280;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "顺序号";
            this.columnHeader2.Width = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_btnRight);
            this.groupBox2.Controls.Add(this.m_btnLeft);
            this.groupBox2.Controls.Add(this.m_btnDown);
            this.groupBox2.Controls.Add(this.m_btnUp);
            this.groupBox2.Controls.Add(this.m_btnSave);
            this.groupBox2.Controls.Add(this.cboMedStoreType);
            this.groupBox2.Controls.Add(this.m_btnRefresh);
            this.groupBox2.Controls.Add(this.buttonXP2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(293, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(128, 509);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // m_btnRight
            // 
            this.m_btnRight.BackColor = System.Drawing.Color.Silver;
            this.m_btnRight.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_btnRight.ImageIndex = 2;
            this.m_btnRight.ImageList = this.imageList1;
            this.m_btnRight.Location = new System.Drawing.Point(33, 380);
            this.m_btnRight.Name = "m_btnRight";
            this.m_btnRight.Size = new System.Drawing.Size(71, 24);
            this.m_btnRight.TabIndex = 45;
            this.m_btnRight.UseVisualStyleBackColor = false;
            this.m_btnRight.Click += new System.EventHandler(this.m_btnRight_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "UP.bmp");
            this.imageList1.Images.SetKeyName(1, "Down.bmp");
            this.imageList1.Images.SetKeyName(2, "Right.bmp");
            this.imageList1.Images.SetKeyName(3, "Left.bmp");
            // 
            // m_btnLeft
            // 
            this.m_btnLeft.BackColor = System.Drawing.Color.Silver;
            this.m_btnLeft.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_btnLeft.ImageIndex = 3;
            this.m_btnLeft.ImageList = this.imageList1;
            this.m_btnLeft.Location = new System.Drawing.Point(33, 344);
            this.m_btnLeft.Name = "m_btnLeft";
            this.m_btnLeft.Size = new System.Drawing.Size(71, 24);
            this.m_btnLeft.TabIndex = 44;
            this.m_btnLeft.UseVisualStyleBackColor = false;
            this.m_btnLeft.Click += new System.EventHandler(this.m_btnLeft_Click);
            // 
            // m_btnDown
            // 
            this.m_btnDown.BackColor = System.Drawing.Color.Silver;
            this.m_btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_btnDown.ImageIndex = 1;
            this.m_btnDown.ImageList = this.imageList1;
            this.m_btnDown.Location = new System.Drawing.Point(52, 221);
            this.m_btnDown.Name = "m_btnDown";
            this.m_btnDown.Size = new System.Drawing.Size(25, 40);
            this.m_btnDown.TabIndex = 43;
            this.m_btnDown.UseVisualStyleBackColor = false;
            this.m_btnDown.Click += new System.EventHandler(this.m_btnDown_Click);
            // 
            // m_btnUp
            // 
            this.m_btnUp.BackColor = System.Drawing.Color.Silver;
            this.m_btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_btnUp.ImageIndex = 0;
            this.m_btnUp.ImageList = this.imageList1;
            this.m_btnUp.Location = new System.Drawing.Point(52, 168);
            this.m_btnUp.Name = "m_btnUp";
            this.m_btnUp.Size = new System.Drawing.Size(25, 40);
            this.m_btnUp.TabIndex = 42;
            this.m_btnUp.UseVisualStyleBackColor = false;
            this.m_btnUp.Click += new System.EventHandler(this.m_btnUp_Click);
            // 
            // m_btnSave
            // 
            this.m_btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnSave.DefaultScheme = true;
            this.m_btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnSave.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnSave.Hint = "";
            this.m_btnSave.Location = new System.Drawing.Point(23, 270);
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnSave.Size = new System.Drawing.Size(85, 30);
            this.m_btnSave.TabIndex = 41;
            this.m_btnSave.Text = "保存(&S)";
            this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
            // 
            // cboMedStoreType
            // 
            this.cboMedStoreType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMedStoreType.Location = new System.Drawing.Point(8, 88);
            this.cboMedStoreType.Name = "cboMedStoreType";
            this.cboMedStoreType.Size = new System.Drawing.Size(110, 20);
            this.cboMedStoreType.TabIndex = 38;
            this.cboMedStoreType.SelectedIndexChanged += new System.EventHandler(this.cboMedStoreType_SelectedIndexChanged);
            // 
            // m_btnRefresh
            // 
            this.m_btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnRefresh.DefaultScheme = true;
            this.m_btnRefresh.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnRefresh.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnRefresh.ForeColor = System.Drawing.Color.Black;
            this.m_btnRefresh.Hint = "";
            this.m_btnRefresh.Location = new System.Drawing.Point(21, 126);
            this.m_btnRefresh.Name = "m_btnRefresh";
            this.m_btnRefresh.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnRefresh.Size = new System.Drawing.Size(85, 26);
            this.m_btnRefresh.TabIndex = 6;
            this.m_btnRefresh.Text = "刷新(&R)";
            this.m_btnRefresh.Click += new System.EventHandler(this.m_btnRefresh_Click);
            // 
            // buttonXP2
            // 
            this.buttonXP2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonXP2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP2.DefaultScheme = true;
            this.buttonXP2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonXP2.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.buttonXP2.Hint = "";
            this.buttonXP2.Location = new System.Drawing.Point(26, 441);
            this.buttonXP2.Name = "buttonXP2";
            this.buttonXP2.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP2.Size = new System.Drawing.Size(85, 30);
            this.buttonXP2.TabIndex = 5;
            this.buttonXP2.Text = "退出(&E)";
            this.buttonXP2.Click += new System.EventHandler(this.buttonXP2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.m_lsvCurrentArea);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(421, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(289, 509);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "当前住院药房管理的病区";
            // 
            // m_lsvCurrentArea
            // 
            this.m_lsvCurrentArea.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader7,
            this.columnHeader1});
            this.m_lsvCurrentArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvCurrentArea.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvCurrentArea.FullRowSelect = true;
            this.m_lsvCurrentArea.GridLines = true;
            this.m_lsvCurrentArea.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.m_lsvCurrentArea.HideSelection = false;
            this.m_lsvCurrentArea.Location = new System.Drawing.Point(3, 19);
            this.m_lsvCurrentArea.MultiSelect = false;
            this.m_lsvCurrentArea.Name = "m_lsvCurrentArea";
            this.m_lsvCurrentArea.Size = new System.Drawing.Size(283, 487);
            this.m_lsvCurrentArea.TabIndex = 0;
            this.m_lsvCurrentArea.UseCompatibleStateImageBehavior = false;
            this.m_lsvCurrentArea.View = System.Windows.Forms.View.Details;
            this.m_lsvCurrentArea.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.m_lsvCurrentArea_ItemDrag);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "病区编号";
            this.columnHeader4.Width = 0;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "病区名称";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 220;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "顺序号";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmMedStoreAreaRelation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 509);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMedStoreAreaRelation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "住院药房对应病区维护界面";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMedStoreAreaRelation_FormClosing);
            this.Load += new System.EventHandler(this.frmMedStoreAreaRelation_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        internal PinkieControls.ButtonXP buttonXP2;
        internal System.Windows.Forms.ListView m_lsvAllAreas;
        internal System.Windows.Forms.ListView m_lsvCurrentArea;
        internal PinkieControls.ButtonXP m_btnRefresh;
        internal exComboBox cboMedStoreType;
        internal PinkieControls.ButtonXP m_btnSave;
        private System.Windows.Forms.Button m_btnDown;
        private System.Windows.Forms.Button m_btnUp;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button m_btnRight;
        private System.Windows.Forms.Button m_btnLeft;
    }
}