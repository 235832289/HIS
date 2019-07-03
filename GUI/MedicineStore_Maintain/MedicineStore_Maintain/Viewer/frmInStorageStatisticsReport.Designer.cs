namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    partial class frmInStorageStatisticsReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInStorageStatisticsReport));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("节点2");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("节点3");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("节点4");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("节点5");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("全部", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_cmdSearch = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.m_cmdPrint = new System.Windows.Forms.Button();
            this.m_dtpBeginDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.m_dwcData = new Sybase.DataWindow.DataWindowControl();
            this.label2 = new System.Windows.Forms.Label();
            this.m_dtpEndDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtVendor = new System.Windows.Forms.TextBox();
            this.m_cboType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_chkStatOut = new System.Windows.Forms.CheckBox();
            this.tvRoom = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.m_cmdSearch);
            this.panel1.Controls.Add(this.m_cmdPrint);
            this.panel1.Location = new System.Drawing.Point(811, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(196, 31);
            this.panel1.TabIndex = 171;
            // 
            // m_cmdSearch
            // 
            this.m_cmdSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdSearch.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdSearch.ImageIndex = 13;
            this.m_cmdSearch.ImageList = this.imageList1;
            this.m_cmdSearch.Location = new System.Drawing.Point(2, 1);
            this.m_cmdSearch.Name = "m_cmdSearch";
            this.m_cmdSearch.Size = new System.Drawing.Size(94, 28);
            this.m_cmdSearch.TabIndex = 190;
            this.m_cmdSearch.Text = "查询(&F)";
            this.m_cmdSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdSearch.UseVisualStyleBackColor = true;
            this.m_cmdSearch.Click += new System.EventHandler(this.m_cmdSearch_Click);
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
            // m_cmdPrint
            // 
            this.m_cmdPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdPrint.ImageIndex = 6;
            this.m_cmdPrint.ImageList = this.imageList1;
            this.m_cmdPrint.Location = new System.Drawing.Point(95, 1);
            this.m_cmdPrint.Name = "m_cmdPrint";
            this.m_cmdPrint.Size = new System.Drawing.Size(94, 28);
            this.m_cmdPrint.TabIndex = 190;
            this.m_cmdPrint.Text = "打印(&P)";
            this.m_cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdPrint.UseVisualStyleBackColor = true;
            this.m_cmdPrint.Click += new System.EventHandler(this.m_cmdPrint_Click);
            // 
            // m_dtpBeginDate
            // 
            this.m_dtpBeginDate.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_dtpBeginDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_dtpBeginDate.Location = new System.Drawing.Point(77, 10);
            this.m_dtpBeginDate.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日;
            this.m_dtpBeginDate.Mask = "0000年90月90日";
            this.m_dtpBeginDate.Name = "m_dtpBeginDate";
            this.m_dtpBeginDate.Size = new System.Drawing.Size(130, 23);
            this.m_dtpBeginDate.TabIndex = 172;
            this.m_dtpBeginDate.ValidatingType = typeof(System.DateTime);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 173;
            this.label1.Text = "入库日期";
            // 
            // m_dwcData
            // 
            this.m_dwcData.DataWindowObject = "ms_instoragestatisticsreport";
            this.m_dwcData.LibraryList = "";
            this.m_dwcData.Location = new System.Drawing.Point(9, 73);
            this.m_dwcData.Name = "m_dwcData";
            this.m_dwcData.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.m_dwcData.Size = new System.Drawing.Size(995, 553);
            this.m_dwcData.TabIndex = 174;
            this.m_dwcData.Text = "dataWindowControl1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 14);
            this.label2.TabIndex = 173;
            this.label2.Text = "~";
            // 
            // m_dtpEndDate
            // 
            this.m_dtpEndDate.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_dtpEndDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_dtpEndDate.Location = new System.Drawing.Point(230, 10);
            this.m_dtpEndDate.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日;
            this.m_dtpEndDate.Mask = "0000年90月90日";
            this.m_dtpEndDate.Name = "m_dtpEndDate";
            this.m_dtpEndDate.Size = new System.Drawing.Size(130, 23);
            this.m_dtpEndDate.TabIndex = 172;
            this.m_dtpEndDate.ValidatingType = typeof(System.DateTime);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(367, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 175;
            this.label3.Text = "供应商";
            // 
            // m_txtVendor
            // 
            this.m_txtVendor.Location = new System.Drawing.Point(419, 10);
            this.m_txtVendor.Name = "m_txtVendor";
            this.m_txtVendor.Size = new System.Drawing.Size(200, 23);
            this.m_txtVendor.TabIndex = 176;
            this.m_txtVendor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_txtVendor_MouseDown);
            this.m_txtVendor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtVendor_KeyDown);
            // 
            // m_cboType
            // 
            this.m_cboType.FormattingEnabled = true;
            this.m_cboType.Location = new System.Drawing.Point(671, 10);
            this.m_cboType.Name = "m_cboType";
            this.m_cboType.Size = new System.Drawing.Size(121, 22);
            this.m_cboType.TabIndex = 177;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(633, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 178;
            this.label4.Text = "类型";
            // 
            // m_chkStatOut
            // 
            this.m_chkStatOut.AutoSize = true;
            this.m_chkStatOut.Checked = true;
            this.m_chkStatOut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkStatOut.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.m_chkStatOut.Location = new System.Drawing.Point(14, 46);
            this.m_chkStatOut.Name = "m_chkStatOut";
            this.m_chkStatOut.Size = new System.Drawing.Size(110, 18);
            this.m_chkStatOut.TabIndex = 179;
            this.m_chkStatOut.Text = "统计退药出库";
            this.m_chkStatOut.UseVisualStyleBackColor = true;
            this.m_chkStatOut.CheckedChanged += new System.EventHandler(this.m_chkStatOut_CheckedChanged);
            // 
            // tvRoom
            // 
            this.tvRoom.CheckBoxes = true;
            this.tvRoom.Location = new System.Drawing.Point(130, 68);
            this.tvRoom.Name = "tvRoom";
            treeNode1.Name = "节点2";
            treeNode1.Text = "节点2";
            treeNode2.Name = "节点3";
            treeNode2.Text = "节点3";
            treeNode3.Name = "节点4";
            treeNode3.Text = "节点4";
            treeNode4.Name = "节点5";
            treeNode4.Text = "节点5";
            treeNode5.Checked = true;
            treeNode5.Name = "节点0";
            treeNode5.Text = "全部";
            this.tvRoom.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5});
            this.tvRoom.Size = new System.Drawing.Size(180, 177);
            this.tvRoom.TabIndex = 180;
            this.tvRoom.Visible = false;
            this.tvRoom.Leave += new System.EventHandler(this.tvRoom_Leave);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.ImageIndex = 4;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(130, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 28);
            this.button1.TabIndex = 191;
            this.button1.Text = "仓库选择↓";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmInStorageStatisticsReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 634);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tvRoom);
            this.Controls.Add(this.m_chkStatOut);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_cboType);
            this.Controls.Add(this.m_txtVendor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_dwcData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_dtpEndDate);
            this.Controls.Add(this.m_dtpBeginDate);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInStorageStatisticsReport";
            this.Text = "入库统计报表";
            this.Load += new System.EventHandler(this.frmInStorageStatisticsReport_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button m_cmdPrint;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker m_dtpBeginDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label2;
        internal com.digitalwave.Controls.ctlMaskedDateTimePicker m_dtpEndDate;
        private System.Windows.Forms.Label label3;
        internal Sybase.DataWindow.DataWindowControl m_dwcData;
        internal System.Windows.Forms.TextBox m_txtVendor;
        internal System.Windows.Forms.Button m_cmdSearch;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox m_cboType;
        internal System.Windows.Forms.CheckBox m_chkStatOut;
        internal System.Windows.Forms.Button button1;
        internal System.Windows.Forms.TreeView tvRoom;
    }
}