namespace iCare
{
    partial class frmPartogramPoint_GX
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPartogramPoint_GX));
            this.m_cmdCancel = new ExternalControlsLib.XPButton();
            this.m_cmdOK = new ExternalControlsLib.XPButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_numUtricm = new System.Windows.Forms.NumericUpDown();
            this.m_lsvU = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_mniDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.m_txtMin1 = new com.digitalwave.Controls.ctlMaskedNumber();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.m_cmdAddU = new ExternalControlsLib.XPButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_lsvDown = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_mniDelete2 = new System.Windows.Forms.ToolStripMenuItem();
            this.m_numDown = new System.Windows.Forms.NumericUpDown();
            this.m_txtMin2 = new com.digitalwave.Controls.ctlMaskedNumber();
            this.label7 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.m_cmdAddDown = new ExternalControlsLib.XPButton();
            this.m_tipMain = new System.Windows.Forms.ToolTip(this.components);
            this.lblHour = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_numUtricm)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_numDown)).BeginInit();
            this.SuspendLayout();
            // 
            // m_cmdCancel
            // 
            this.m_cmdCancel.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmdCancel.BtnShape = ExternalControlsLib.emunType.BtnShape.Rectangle;
            this.m_cmdCancel.BtnStyle = ExternalControlsLib.emunType.XPStyle.Default;
            this.m_cmdCancel.Location = new System.Drawing.Point(433, 158);
            this.m_cmdCancel.Name = "m_cmdCancel";
            this.m_cmdCancel.Size = new System.Drawing.Size(73, 30);
            this.m_cmdCancel.TabIndex = 3;
            this.m_cmdCancel.Text = "取消(&C)";
            this.m_cmdCancel.UseVisualStyleBackColor = true;
            this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
            // 
            // m_cmdOK
            // 
            this.m_cmdOK.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmdOK.BtnShape = ExternalControlsLib.emunType.BtnShape.Rectangle;
            this.m_cmdOK.BtnStyle = ExternalControlsLib.emunType.XPStyle.Default;
            this.m_cmdOK.Location = new System.Drawing.Point(290, 158);
            this.m_cmdOK.Name = "m_cmdOK";
            this.m_cmdOK.Size = new System.Drawing.Size(73, 30);
            this.m_cmdOK.TabIndex = 2;
            this.m_cmdOK.Text = "确定(&O)";
            this.m_cmdOK.UseVisualStyleBackColor = true;
            this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_numUtricm);
            this.groupBox2.Controls.Add(this.m_lsvU);
            this.groupBox2.Controls.Add(this.m_txtMin1);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.m_cmdAddU);
            this.groupBox2.Location = new System.Drawing.Point(14, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(251, 133);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "宫颈口开大:";
            // 
            // m_numUtricm
            // 
            this.m_numUtricm.DecimalPlaces = 1;
            this.m_numUtricm.Location = new System.Drawing.Point(42, 61);
            this.m_numUtricm.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.m_numUtricm.Name = "m_numUtricm";
            this.m_numUtricm.Size = new System.Drawing.Size(54, 23);
            this.m_numUtricm.TabIndex = 1;
            // 
            // m_lsvU
            // 
            this.m_lsvU.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.m_lsvU.ContextMenuStrip = this.contextMenuStrip1;
            this.m_lsvU.FullRowSelect = true;
            this.m_lsvU.GridLines = true;
            this.m_lsvU.Location = new System.Drawing.Point(115, 23);
            this.m_lsvU.Name = "m_lsvU";
            this.m_lsvU.Size = new System.Drawing.Size(125, 101);
            this.m_lsvU.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.m_lsvU.TabIndex = 3;
            this.m_lsvU.UseCompatibleStateImageBehavior = false;
            this.m_lsvU.View = System.Windows.Forms.View.Details;
            this.m_lsvU.DoubleClick += new System.EventHandler(this.m_lsvU_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "时间";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "开大(cm)";
            this.columnHeader2.Width = 70;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_mniDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(99, 26);
            // 
            // m_mniDelete
            // 
            this.m_mniDelete.Name = "m_mniDelete";
            this.m_mniDelete.Size = new System.Drawing.Size(98, 22);
            this.m_mniDelete.Text = "删除";
            this.m_mniDelete.Click += new System.EventHandler(this.m_mniDelete_Click);
            // 
            // m_txtMin1
            // 
            this.m_txtMin1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_txtMin1.Location = new System.Drawing.Point(31, 23);
            this.m_txtMin1.m_DcmInvalidNumber = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.m_txtMin1.m_DcmMaxNumber = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.m_txtMin1.m_DcmMinNumber = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.m_txtMin1.Mask = "99";
            this.m_txtMin1.Name = "m_txtMin1";
            this.m_txtMin1.PromptChar = ' ';
            this.m_txtMin1.Size = new System.Drawing.Size(35, 23);
            this.m_txtMin1.TabIndex = 0;
            this.m_txtMin1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtMin1.ValidatingType = typeof(decimal);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 66);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 14);
            this.label15.TabIndex = 10000007;
            this.label15.Text = "开大";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(93, 65);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 14);
            this.label14.TabIndex = 10000007;
            this.label14.Text = "cm";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(70, 29);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 14);
            this.label13.TabIndex = 10000007;
            this.label13.Text = "分钟 ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 28);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(21, 14);
            this.label16.TabIndex = 10000007;
            this.label16.Text = "第";
            // 
            // m_cmdAddU
            // 
            this.m_cmdAddU.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmdAddU.BtnShape = ExternalControlsLib.emunType.BtnShape.Rectangle;
            this.m_cmdAddU.BtnStyle = ExternalControlsLib.emunType.XPStyle.Default;
            this.m_cmdAddU.Location = new System.Drawing.Point(10, 99);
            this.m_cmdAddU.Name = "m_cmdAddU";
            this.m_cmdAddU.Size = new System.Drawing.Size(77, 25);
            this.m_cmdAddU.TabIndex = 2;
            this.m_cmdAddU.Text = "添加 >>";
            this.m_cmdAddU.UseVisualStyleBackColor = true;
            this.m_cmdAddU.Click += new System.EventHandler(this.m_cmdAddU_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.m_lsvDown);
            this.groupBox3.Controls.Add(this.m_numDown);
            this.groupBox3.Controls.Add(this.m_txtMin2);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.m_cmdAddDown);
            this.groupBox3.Location = new System.Drawing.Point(271, 14);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(247, 133);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "胎儿头下降:";
            // 
            // m_lsvDown
            // 
            this.m_lsvDown.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.m_lsvDown.ContextMenuStrip = this.contextMenuStrip2;
            this.m_lsvDown.FullRowSelect = true;
            this.m_lsvDown.GridLines = true;
            this.m_lsvDown.Location = new System.Drawing.Point(109, 23);
            this.m_lsvDown.Name = "m_lsvDown";
            this.m_lsvDown.Size = new System.Drawing.Size(126, 101);
            this.m_lsvDown.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.m_lsvDown.TabIndex = 3;
            this.m_lsvDown.UseCompatibleStateImageBehavior = false;
            this.m_lsvDown.View = System.Windows.Forms.View.Details;
            this.m_lsvDown.DoubleClick += new System.EventHandler(this.m_lsvDown_DoubleClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "时间";
            this.columnHeader3.Width = 40;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "下降";
            this.columnHeader4.Width = 70;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_mniDelete2});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(99, 26);
            // 
            // m_mniDelete2
            // 
            this.m_mniDelete2.Name = "m_mniDelete2";
            this.m_mniDelete2.Size = new System.Drawing.Size(98, 22);
            this.m_mniDelete2.Text = "删除";
            this.m_mniDelete2.Click += new System.EventHandler(this.m_mniDelete2_Click);
            // 
            // m_numDown
            // 
            this.m_numDown.DecimalPlaces = 1;
            this.m_numDown.Location = new System.Drawing.Point(42, 61);
            this.m_numDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.m_numDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            this.m_numDown.Name = "m_numDown";
            this.m_numDown.Size = new System.Drawing.Size(63, 23);
            this.m_numDown.TabIndex = 10000234;
            // 
            // m_txtMin2
            // 
            this.m_txtMin2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_txtMin2.Location = new System.Drawing.Point(31, 23);
            this.m_txtMin2.m_DcmInvalidNumber = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.m_txtMin2.m_DcmMaxNumber = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.m_txtMin2.m_DcmMinNumber = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.m_txtMin2.Mask = "99";
            this.m_txtMin2.Name = "m_txtMin2";
            this.m_txtMin2.PromptChar = ' ';
            this.m_txtMin2.Size = new System.Drawing.Size(35, 23);
            this.m_txtMin2.TabIndex = 0;
            this.m_txtMin2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtMin2.ValidatingType = typeof(decimal);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 14);
            this.label7.TabIndex = 10000007;
            this.label7.Text = "下降";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(70, 29);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(42, 14);
            this.label17.TabIndex = 10000007;
            this.label17.Text = "分钟 ";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(7, 28);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(21, 14);
            this.label18.TabIndex = 10000007;
            this.label18.Text = "第";
            // 
            // m_cmdAddDown
            // 
            this.m_cmdAddDown.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmdAddDown.BtnShape = ExternalControlsLib.emunType.BtnShape.Rectangle;
            this.m_cmdAddDown.BtnStyle = ExternalControlsLib.emunType.XPStyle.Default;
            this.m_cmdAddDown.Location = new System.Drawing.Point(10, 99);
            this.m_cmdAddDown.Name = "m_cmdAddDown";
            this.m_cmdAddDown.Size = new System.Drawing.Size(78, 25);
            this.m_cmdAddDown.TabIndex = 2;
            this.m_cmdAddDown.Text = "添加 >>";
            this.m_cmdAddDown.UseVisualStyleBackColor = true;
            this.m_cmdAddDown.Click += new System.EventHandler(this.m_cmdAddDown_Click);
            // 
            // m_tipMain
            // 
            this.m_tipMain.IsBalloon = true;
            this.m_tipMain.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Error;
            // 
            // lblHour
            // 
            this.lblHour.AutoSize = true;
            this.lblHour.Location = new System.Drawing.Point(16, 166);
            this.lblHour.Name = "lblHour";
            this.lblHour.Size = new System.Drawing.Size(0, 14);
            this.lblHour.TabIndex = 4;
            // 
            // frmPartogramPoint_GX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 200);
            this.Controls.Add(this.lblHour);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.m_cmdOK);
            this.Controls.Add(this.m_cmdCancel);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmPartogramPoint_GX";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "修改宫颈口开大和胎儿头下降的值";
            this.Load += new System.EventHandler(this.frmPartogramPoint_GX_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_numUtricm)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_numDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ExternalControlsLib.XPButton m_cmdCancel;
        private ExternalControlsLib.XPButton m_cmdOK;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView m_lsvU;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private com.digitalwave.Controls.ctlMaskedNumber m_txtMin1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private ExternalControlsLib.XPButton m_cmdAddU;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView m_lsvDown;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private com.digitalwave.Controls.ctlMaskedNumber m_txtMin2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private ExternalControlsLib.XPButton m_cmdAddDown;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem m_mniDelete;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem m_mniDelete2;
        private System.Windows.Forms.ToolTip m_tipMain;
        private System.Windows.Forms.Label lblHour;
        private System.Windows.Forms.NumericUpDown m_numUtricm;
        private System.Windows.Forms.NumericUpDown m_numDown;
    }
}