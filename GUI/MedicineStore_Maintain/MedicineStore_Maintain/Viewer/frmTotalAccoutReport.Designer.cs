namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    partial class frmTotalAccoutReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTotalAccoutReport));
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtAccountID = new System.Windows.Forms.TextBox();
            this.m_cmdShowAccountDate = new System.Windows.Forms.Button();
            this.m_lblAccountTime = new System.Windows.Forms.Label();
            this.m_lsvAccountIDList = new System.Windows.Forms.ListView();
            this.m_clmID = new System.Windows.Forms.ColumnHeader();
            this.datWindow = new Sybase.DataWindow.DataWindowControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.m_cmdPrint = new System.Windows.Forms.Button();
            this.m_cmdClose = new System.Windows.Forms.Button();
            this.m_bgwGetIDList = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "帐务期:";
            // 
            // m_txtAccountID
            // 
            this.m_txtAccountID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtAccountID.Location = new System.Drawing.Point(74, 7);
            this.m_txtAccountID.Name = "m_txtAccountID";
            this.m_txtAccountID.Size = new System.Drawing.Size(82, 23);
            this.m_txtAccountID.TabIndex = 2;
            this.m_txtAccountID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtAccountID_KeyDown);
            // 
            // m_cmdShowAccountDate
            // 
            this.m_cmdShowAccountDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdShowAccountDate.Location = new System.Drawing.Point(155, 7);
            this.m_cmdShowAccountDate.Name = "m_cmdShowAccountDate";
            this.m_cmdShowAccountDate.Size = new System.Drawing.Size(19, 23);
            this.m_cmdShowAccountDate.TabIndex = 3;
            this.m_cmdShowAccountDate.Text = "↓";
            this.m_cmdShowAccountDate.UseVisualStyleBackColor = true;
            this.m_cmdShowAccountDate.Click += new System.EventHandler(this.m_cmdShowAccountDate_Click);
            // 
            // m_lblAccountTime
            // 
            this.m_lblAccountTime.AutoSize = true;
            this.m_lblAccountTime.Location = new System.Drawing.Point(200, 9);
            this.m_lblAccountTime.Name = "m_lblAccountTime";
            this.m_lblAccountTime.Size = new System.Drawing.Size(35, 14);
            this.m_lblAccountTime.TabIndex = 4;
            this.m_lblAccountTime.Text = "时间";
            this.m_lblAccountTime.Visible = false;
            // 
            // m_lsvAccountIDList
            // 
            this.m_lsvAccountIDList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lsvAccountIDList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_clmID});
            this.m_lsvAccountIDList.GridLines = true;
            this.m_lsvAccountIDList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_lsvAccountIDList.HideSelection = false;
            this.m_lsvAccountIDList.Location = new System.Drawing.Point(73, 31);
            this.m_lsvAccountIDList.Name = "m_lsvAccountIDList";
            this.m_lsvAccountIDList.Size = new System.Drawing.Size(371, 97);
            this.m_lsvAccountIDList.TabIndex = 5;
            this.m_lsvAccountIDList.UseCompatibleStateImageBehavior = false;
            this.m_lsvAccountIDList.View = System.Windows.Forms.View.Details;
            this.m_lsvAccountIDList.Visible = false;
            this.m_lsvAccountIDList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_lsvAccountIDList_MouseUp);
            this.m_lsvAccountIDList.Leave += new System.EventHandler(this.m_lsvAccountIDList_Leave);
            // 
            // m_clmID
            // 
            this.m_clmID.Width = 360;
            // 
            // datWindow
            // 
            this.datWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.datWindow.DataWindowObject = "ms_account";
            this.datWindow.LibraryList = "";
            this.datWindow.Location = new System.Drawing.Point(0, 36);
            this.datWindow.Name = "datWindow";
            this.datWindow.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.VerticalAndHorizontalSplit;
            this.datWindow.Size = new System.Drawing.Size(817, 447);
            this.datWindow.TabIndex = 6;
            this.datWindow.Text = "dataWindowControl1";
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
            this.m_cmdPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdPrint.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdPrint.ImageIndex = 6;
            this.m_cmdPrint.ImageList = this.imageList1;
            this.m_cmdPrint.Location = new System.Drawing.Point(621, 4);
            this.m_cmdPrint.Name = "m_cmdPrint";
            this.m_cmdPrint.Size = new System.Drawing.Size(89, 28);
            this.m_cmdPrint.TabIndex = 61;
            this.m_cmdPrint.Text = "打印(&P)";
            this.m_cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdPrint.UseVisualStyleBackColor = true;
            this.m_cmdPrint.Click += new System.EventHandler(this.m_cmdPrint_Click);
            // 
            // m_cmdClose
            // 
            this.m_cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdClose.ImageIndex = 1;
            this.m_cmdClose.ImageList = this.imageList1;
            this.m_cmdClose.Location = new System.Drawing.Point(709, 4);
            this.m_cmdClose.Name = "m_cmdClose";
            this.m_cmdClose.Size = new System.Drawing.Size(94, 28);
            this.m_cmdClose.TabIndex = 62;
            this.m_cmdClose.Text = "退出(&Q)";
            this.m_cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdClose.UseVisualStyleBackColor = true;
            this.m_cmdClose.Click += new System.EventHandler(this.m_cmdClose_Click);
            // 
            // m_bgwGetIDList
            // 
            this.m_bgwGetIDList.DoWork += new System.ComponentModel.DoWorkEventHandler(this.m_bgwGetIDList_DoWork);
            this.m_bgwGetIDList.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.m_bgwGetIDList_RunWorkerCompleted);
            // 
            // frmTotalAccoutReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 483);
            this.Controls.Add(this.m_cmdPrint);
            this.Controls.Add(this.m_cmdClose);
            this.Controls.Add(this.m_lsvAccountIDList);
            this.Controls.Add(this.m_lblAccountTime);
            this.Controls.Add(this.m_cmdShowAccountDate);
            this.Controls.Add(this.m_txtAccountID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datWindow);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTotalAccoutReport";
            this.Text = "药库总帐";
            this.Load += new System.EventHandler(this.frmTotalAccoutReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox m_txtAccountID;
        private System.Windows.Forms.Button m_cmdShowAccountDate;
        private System.Windows.Forms.Label m_lblAccountTime;
        internal System.Windows.Forms.ListView m_lsvAccountIDList;
        private System.Windows.Forms.ColumnHeader m_clmID;
        public Sybase.DataWindow.DataWindowControl datWindow;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button m_cmdPrint;
        private System.Windows.Forms.Button m_cmdClose;
        private System.ComponentModel.BackgroundWorker m_bgwGetIDList;
    }
}