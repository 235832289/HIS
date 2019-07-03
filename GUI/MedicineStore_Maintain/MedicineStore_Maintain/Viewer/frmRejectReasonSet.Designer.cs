namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    partial class frmRejectReasonSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRejectReasonSet));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_cmdDeleteItems = new System.Windows.Forms.Button();
            this.m_cmdClear = new System.Windows.Forms.Button();
            this.m_cmdSaveSort = new System.Windows.Forms.Button();
            this.m_cmdSaveToList = new System.Windows.Forms.Button();
            this.m_txtReason = new System.Windows.Forms.TextBox();
            this.m_cmdDown = new System.Windows.Forms.Button();
            this.m_cmdUp = new System.Windows.Forms.Button();
            this.m_lsvReasonList = new System.Windows.Forms.ListView();
            this.m_clmSortNum = new System.Windows.Forms.ColumnHeader();
            this.m_clmReason = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "down.bmp");
            this.imageList1.Images.SetKeyName(1, "up.bmp");
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Font = new System.Drawing.Font("宋体", 12F);
            this.panel1.Location = new System.Drawing.Point(-1, 309);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(439, 1);
            this.panel1.TabIndex = 6;
            // 
            // m_cmdDeleteItems
            // 
            this.m_cmdDeleteItems.Location = new System.Drawing.Point(110, 367);
            this.m_cmdDeleteItems.Name = "m_cmdDeleteItems";
            this.m_cmdDeleteItems.Size = new System.Drawing.Size(106, 27);
            this.m_cmdDeleteItems.TabIndex = 5;
            this.m_cmdDeleteItems.Text = "删除选定项目";
            this.m_cmdDeleteItems.UseVisualStyleBackColor = true;
            this.m_cmdDeleteItems.Click += new System.EventHandler(this.m_cmdDeleteItems_Click);
            // 
            // m_cmdClear
            // 
            this.m_cmdClear.Location = new System.Drawing.Point(325, 367);
            this.m_cmdClear.Name = "m_cmdClear";
            this.m_cmdClear.Size = new System.Drawing.Size(106, 27);
            this.m_cmdClear.TabIndex = 4;
            this.m_cmdClear.Text = "清空";
            this.m_cmdClear.UseVisualStyleBackColor = true;
            this.m_cmdClear.Click += new System.EventHandler(this.m_cmdClear_Click);
            // 
            // m_cmdSaveSort
            // 
            this.m_cmdSaveSort.Location = new System.Drawing.Point(218, 367);
            this.m_cmdSaveSort.Name = "m_cmdSaveSort";
            this.m_cmdSaveSort.Size = new System.Drawing.Size(106, 27);
            this.m_cmdSaveSort.TabIndex = 4;
            this.m_cmdSaveSort.Text = "保存顺序更改";
            this.m_cmdSaveSort.UseVisualStyleBackColor = true;
            this.m_cmdSaveSort.Click += new System.EventHandler(this.m_cmdSaveSort_Click);
            // 
            // m_cmdSaveToList
            // 
            this.m_cmdSaveToList.Location = new System.Drawing.Point(3, 367);
            this.m_cmdSaveToList.Name = "m_cmdSaveToList";
            this.m_cmdSaveToList.Size = new System.Drawing.Size(106, 27);
            this.m_cmdSaveToList.TabIndex = 4;
            this.m_cmdSaveToList.Text = "保存至列表";
            this.m_cmdSaveToList.UseVisualStyleBackColor = true;
            this.m_cmdSaveToList.Click += new System.EventHandler(this.m_cmdSaveToList_Click);
            // 
            // m_txtReason
            // 
            this.m_txtReason.Location = new System.Drawing.Point(10, 316);
            this.m_txtReason.MaxLength = 25;
            this.m_txtReason.Multiline = true;
            this.m_txtReason.Name = "m_txtReason";
            this.m_txtReason.Size = new System.Drawing.Size(419, 45);
            this.m_txtReason.TabIndex = 3;
            // 
            // m_cmdDown
            // 
            this.m_cmdDown.ImageIndex = 0;
            this.m_cmdDown.ImageList = this.imageList1;
            this.m_cmdDown.Location = new System.Drawing.Point(399, 151);
            this.m_cmdDown.Name = "m_cmdDown";
            this.m_cmdDown.Size = new System.Drawing.Size(30, 30);
            this.m_cmdDown.TabIndex = 2;
            this.m_cmdDown.UseVisualStyleBackColor = true;
            this.m_cmdDown.Click += new System.EventHandler(this.m_cmdDown_Click);
            // 
            // m_cmdUp
            // 
            this.m_cmdUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.m_cmdUp.ImageIndex = 1;
            this.m_cmdUp.ImageList = this.imageList1;
            this.m_cmdUp.Location = new System.Drawing.Point(399, 109);
            this.m_cmdUp.Name = "m_cmdUp";
            this.m_cmdUp.Size = new System.Drawing.Size(30, 30);
            this.m_cmdUp.TabIndex = 1;
            this.m_cmdUp.UseVisualStyleBackColor = true;
            this.m_cmdUp.Click += new System.EventHandler(this.m_cmdUp_Click);
            // 
            // m_lsvReasonList
            // 
            this.m_lsvReasonList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_clmSortNum,
            this.m_clmReason});
            this.m_lsvReasonList.FullRowSelect = true;
            this.m_lsvReasonList.GridLines = true;
            this.m_lsvReasonList.HideSelection = false;
            this.m_lsvReasonList.Location = new System.Drawing.Point(10, 8);
            this.m_lsvReasonList.Name = "m_lsvReasonList";
            this.m_lsvReasonList.Size = new System.Drawing.Size(386, 297);
            this.m_lsvReasonList.TabIndex = 0;
            this.m_lsvReasonList.UseCompatibleStateImageBehavior = false;
            this.m_lsvReasonList.View = System.Windows.Forms.View.Details;
            this.m_lsvReasonList.DoubleClick += new System.EventHandler(this.m_lsvReasonList_DoubleClick);
            // 
            // m_clmSortNum
            // 
            this.m_clmSortNum.Text = "序号";
            // 
            // m_clmReason
            // 
            this.m_clmReason.Text = "报废理由";
            this.m_clmReason.Width = 300;
            // 
            // frmRejectReasonSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 400);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_cmdDeleteItems);
            this.Controls.Add(this.m_cmdClear);
            this.Controls.Add(this.m_cmdSaveSort);
            this.Controls.Add(this.m_cmdSaveToList);
            this.Controls.Add(this.m_txtReason);
            this.Controls.Add(this.m_cmdDown);
            this.Controls.Add(this.m_cmdUp);
            this.Controls.Add(this.m_lsvReasonList);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(7);
            this.MaximizeBox = false;
            this.Name = "frmRejectReasonSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "药品报废原因维护";
            this.Load += new System.EventHandler(this.frmRejectReasonSet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader m_clmSortNum;
        private System.Windows.Forms.ColumnHeader m_clmReason;
        private System.Windows.Forms.Button m_cmdUp;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button m_cmdDown;
        private System.Windows.Forms.Button m_cmdSaveToList;
        private System.Windows.Forms.Button m_cmdSaveSort;
        private System.Windows.Forms.Button m_cmdDeleteItems;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button m_cmdClear;
        internal System.Windows.Forms.ListView m_lsvReasonList;
        internal System.Windows.Forms.TextBox m_txtReason;
    }
}