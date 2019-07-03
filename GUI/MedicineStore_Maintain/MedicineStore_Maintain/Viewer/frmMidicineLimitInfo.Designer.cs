namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    partial class frmMedicineLimitInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMedicineLimitInfo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.m_btnPreview = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabelInfo = new System.Windows.Forms.ToolStripLabel();
            this.dgvMedicineInfo = new com.digitalwave.controls.MedicineStoreControls.ctlDataGridView_EnterAsTab();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.notifyIconLowMedicineNotice = new System.Windows.Forms.NotifyIcon(this.components);
            this.m_cmdRefesh = new System.Windows.Forms.Button();
            this.assistcode_chr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.medicinename_vchr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.medspec_vchr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.opunit_chr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currentgross_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.neaplimit_int = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitprice_mny = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productorid_chr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pycode_chr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wbcode_chr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicineInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(123, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.toolStripMenuItem1.Text = "显示详细";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(122, 22);
            this.toolStripMenuItem2.Text = "退出监测";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_btnPreview,
            this.toolStripTextBox1,
            this.toolStripLabelInfo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1004, 40);
            this.toolStrip1.TabIndex = 10068;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // m_btnPreview
            // 
            this.m_btnPreview.Image = ((System.Drawing.Image)(resources.GetObject("m_btnPreview.Image")));
            this.m_btnPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_btnPreview.Name = "m_btnPreview";
            this.m_btnPreview.Size = new System.Drawing.Size(83, 37);
            this.m_btnPreview.Text = "药品定位";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(120, 40);
            this.toolStripTextBox1.ToolTipText = "根据药品拼音码定位";
            this.toolStripTextBox1.TextChanged += new System.EventHandler(this.toolStripTextBox1_TextChanged);
            // 
            // toolStripLabelInfo
            // 
            this.toolStripLabelInfo.ForeColor = System.Drawing.Color.Red;
            this.toolStripLabelInfo.Name = "toolStripLabelInfo";
            this.toolStripLabelInfo.Size = new System.Drawing.Size(259, 37);
            this.toolStripLabelInfo.Text = "                                    ";
            // 
            // dgvMedicineInfo
            // 
            this.dgvMedicineInfo.AllowUserToAddRows = false;
            this.dgvMedicineInfo.AllowUserToResizeRows = false;
            this.dgvMedicineInfo.ColumnHeadersHeight = 30;
            this.dgvMedicineInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.assistcode_chr,
            this.medicinename_vchr,
            this.medspec_vchr,
            this.opunit_chr,
            this.currentgross_num,
            this.neaplimit_int,
            this.unitprice_mny,
            this.productorid_chr,
            this.pycode_chr,
            this.wbcode_chr});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMedicineInfo.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvMedicineInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMedicineInfo.Location = new System.Drawing.Point(0, 40);
            this.dgvMedicineInfo.Name = "dgvMedicineInfo";
            this.dgvMedicineInfo.RowHeadersVisible = false;
            this.dgvMedicineInfo.RowTemplate.Height = 23;
            this.dgvMedicineInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMedicineInfo.Size = new System.Drawing.Size(1004, 403);
            this.dgvMedicineInfo.TabIndex = 10069;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(766, 9);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(52, 21);
            this.numericUpDown1.TabIndex = 10070;
            this.numericUpDown1.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(712, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 10071;
            this.label1.Text = "刷新时间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(818, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 10072;
            this.label2.Text = "秒";
            // 
            // notifyIconLowMedicineNotice
            // 
            this.notifyIconLowMedicineNotice.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIconLowMedicineNotice.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconLowMedicineNotice.Icon")));
            this.notifyIconLowMedicineNotice.Text = "药品低库存通知";
            this.notifyIconLowMedicineNotice.DoubleClick += new System.EventHandler(this.notifyIconLowMedicineNotice_DoubleClick);
            // 
            // m_cmdRefesh
            // 
            this.m_cmdRefesh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_cmdRefesh.Location = new System.Drawing.Point(863, 1);
            this.m_cmdRefesh.Name = "m_cmdRefesh";
            this.m_cmdRefesh.Size = new System.Drawing.Size(75, 36);
            this.m_cmdRefesh.TabIndex = 10073;
            this.m_cmdRefesh.Text = "刷新";
            this.m_cmdRefesh.UseVisualStyleBackColor = true;
            this.m_cmdRefesh.Click += new System.EventHandler(this.m_cmdRefesh_Click);
            // 
            // assistcode_chr
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.assistcode_chr.DefaultCellStyle = dataGridViewCellStyle1;
            this.assistcode_chr.HeaderText = "药品代码";
            this.assistcode_chr.Name = "assistcode_chr";
            // 
            // medicinename_vchr
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.medicinename_vchr.DefaultCellStyle = dataGridViewCellStyle2;
            this.medicinename_vchr.HeaderText = "药品名称";
            this.medicinename_vchr.Name = "medicinename_vchr";
            this.medicinename_vchr.Width = 260;
            // 
            // medspec_vchr
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.medspec_vchr.DefaultCellStyle = dataGridViewCellStyle3;
            this.medspec_vchr.HeaderText = "规格";
            this.medspec_vchr.Name = "medspec_vchr";
            // 
            // opunit_chr
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.opunit_chr.DefaultCellStyle = dataGridViewCellStyle4;
            this.opunit_chr.HeaderText = "单位";
            this.opunit_chr.Name = "opunit_chr";
            this.opunit_chr.Width = 60;
            // 
            // currentgross_num
            // 
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = "0";
            this.currentgross_num.DefaultCellStyle = dataGridViewCellStyle5;
            this.currentgross_num.HeaderText = "可用库存";
            this.currentgross_num.Name = "currentgross_num";
            this.currentgross_num.Width = 120;
            // 
            // neaplimit_int
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neaplimit_int.DefaultCellStyle = dataGridViewCellStyle6;
            this.neaplimit_int.HeaderText = "最低限量";
            this.neaplimit_int.Name = "neaplimit_int";
            this.neaplimit_int.Width = 120;
            // 
            // unitprice_mny
            // 
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.unitprice_mny.DefaultCellStyle = dataGridViewCellStyle7;
            this.unitprice_mny.HeaderText = "零售价/元";
            this.unitprice_mny.Name = "unitprice_mny";
            // 
            // productorid_chr
            // 
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.productorid_chr.DefaultCellStyle = dataGridViewCellStyle8;
            this.productorid_chr.HeaderText = "生产厂家";
            this.productorid_chr.Name = "productorid_chr";
            this.productorid_chr.Width = 150;
            // 
            // pycode_chr
            // 
            this.pycode_chr.HeaderText = "拼音码";
            this.pycode_chr.Name = "pycode_chr";
            this.pycode_chr.Visible = false;
            // 
            // wbcode_chr
            // 
            this.wbcode_chr.HeaderText = "五笔码";
            this.wbcode_chr.Name = "wbcode_chr";
            this.wbcode_chr.Visible = false;
            // 
            // frmMedicineLimitInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 443);
            this.Controls.Add(this.m_cmdRefesh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.dgvMedicineInfo);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMedicineLimitInfo";
            this.ShowInTaskbar = false;
            this.Text = "";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMedicineLimitInfo_FormClosing);
            this.Load += new System.EventHandler(this.frmMedicineLimitInfo_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicineInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton m_btnPreview;
        internal com.digitalwave.controls.MedicineStoreControls.ctlDataGridView_EnterAsTab dgvMedicineInfo;
        internal System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ToolStripLabel toolStripLabelInfo;
        internal System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        internal System.Windows.Forms.NotifyIcon notifyIconLowMedicineNotice;
        internal System.Windows.Forms.Button m_cmdRefesh;
        private System.Windows.Forms.DataGridViewTextBoxColumn assistcode_chr;
        private System.Windows.Forms.DataGridViewTextBoxColumn medicinename_vchr;
        private System.Windows.Forms.DataGridViewTextBoxColumn medspec_vchr;
        private System.Windows.Forms.DataGridViewTextBoxColumn opunit_chr;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentgross_num;
        private System.Windows.Forms.DataGridViewTextBoxColumn neaplimit_int;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitprice_mny;
        private System.Windows.Forms.DataGridViewTextBoxColumn productorid_chr;
        private System.Windows.Forms.DataGridViewTextBoxColumn pycode_chr;
        private System.Windows.Forms.DataGridViewTextBoxColumn wbcode_chr;
    }
}