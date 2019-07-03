namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    partial class frmMedicineTypeVisionmSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMedicineTypeVisionmSet));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.m_cmdSaver = new System.Windows.Forms.Button();
            this.m_cmdCan = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_lblSelectAll2 = new System.Windows.Forms.Label();
            this.m_lblSelectAll = new System.Windows.Forms.Label();
            this.m_dgvTypeVisionm = new System.Windows.Forms.DataGridView();
            this.medicinetypename_vchr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOTNO_INT = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.VALIDPERIOD_INT = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.medicinetypeid_chr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvTypeVisionm)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.m_cmdSaver);
            this.panel1.Controls.Add(this.m_cmdCan);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 398);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(530, 46);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.ImageIndex = 5;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(197, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 28);
            this.button1.TabIndex = 194;
            this.button1.Text = "刷新(&F)";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.imageList1.Images.SetKeyName(9, "Shell32 023.ico");
            // 
            // m_cmdSaver
            // 
            this.m_cmdSaver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdSaver.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdSaver.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdSaver.ImageIndex = 0;
            this.m_cmdSaver.ImageList = this.imageList1;
            this.m_cmdSaver.Location = new System.Drawing.Point(104, 10);
            this.m_cmdSaver.Name = "m_cmdSaver";
            this.m_cmdSaver.Size = new System.Drawing.Size(94, 28);
            this.m_cmdSaver.TabIndex = 193;
            this.m_cmdSaver.Text = "保存(&S)";
            this.m_cmdSaver.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdSaver.UseVisualStyleBackColor = true;
            this.m_cmdSaver.Click += new System.EventHandler(this.m_cmdSaver_Click);
            // 
            // m_cmdCan
            // 
            this.m_cmdCan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdCan.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdCan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdCan.ImageIndex = 7;
            this.m_cmdCan.ImageList = this.imageList1;
            this.m_cmdCan.Location = new System.Drawing.Point(290, 10);
            this.m_cmdCan.Name = "m_cmdCan";
            this.m_cmdCan.Size = new System.Drawing.Size(94, 28);
            this.m_cmdCan.TabIndex = 192;
            this.m_cmdCan.Text = "退出(&C)";
            this.m_cmdCan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdCan.UseVisualStyleBackColor = true;
            this.m_cmdCan.Click += new System.EventHandler(this.m_cmdCan_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_lblSelectAll2);
            this.panel2.Controls.Add(this.m_lblSelectAll);
            this.panel2.Controls.Add(this.m_dgvTypeVisionm);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(530, 398);
            this.panel2.TabIndex = 2;
            // 
            // m_lblSelectAll2
            // 
            this.m_lblSelectAll2.Font = new System.Drawing.Font("宋体", 9F);
            this.m_lblSelectAll2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.m_lblSelectAll2.Location = new System.Drawing.Point(403, 4);
            this.m_lblSelectAll2.Name = "m_lblSelectAll2";
            this.m_lblSelectAll2.Size = new System.Drawing.Size(20, 25);
            this.m_lblSelectAll2.TabIndex = 10004;
            this.m_lblSelectAll2.Text = "全选";
            this.m_lblSelectAll2.Click += new System.EventHandler(this.m_lblSelectAll2_Click);
            // 
            // m_lblSelectAll
            // 
            this.m_lblSelectAll.Font = new System.Drawing.Font("宋体", 9F);
            this.m_lblSelectAll.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.m_lblSelectAll.Location = new System.Drawing.Point(245, 3);
            this.m_lblSelectAll.Name = "m_lblSelectAll";
            this.m_lblSelectAll.Size = new System.Drawing.Size(20, 25);
            this.m_lblSelectAll.TabIndex = 10003;
            this.m_lblSelectAll.Text = "全选";
            this.m_lblSelectAll.Click += new System.EventHandler(this.m_lblSelectAll_Click);
            // 
            // m_dgvTypeVisionm
            // 
            this.m_dgvTypeVisionm.AllowUserToAddRows = false;
            this.m_dgvTypeVisionm.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.PapayaWhip;
            this.m_dgvTypeVisionm.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.m_dgvTypeVisionm.ColumnHeadersHeight = 30;
            this.m_dgvTypeVisionm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.medicinetypename_vchr,
            this.LOTNO_INT,
            this.VALIDPERIOD_INT,
            this.medicinetypeid_chr});
            this.m_dgvTypeVisionm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvTypeVisionm.Location = new System.Drawing.Point(0, 0);
            this.m_dgvTypeVisionm.MultiSelect = false;
            this.m_dgvTypeVisionm.Name = "m_dgvTypeVisionm";
            this.m_dgvTypeVisionm.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.m_dgvTypeVisionm.RowHeadersVisible = false;
            this.m_dgvTypeVisionm.RowTemplate.Height = 23;
            this.m_dgvTypeVisionm.Size = new System.Drawing.Size(530, 398);
            this.m_dgvTypeVisionm.TabIndex = 1;
            // 
            // medicinetypename_vchr
            // 
            this.medicinetypename_vchr.DataPropertyName = "medicinetypename_vchr";
            this.medicinetypename_vchr.HeaderText = "类型名称";
            this.medicinetypename_vchr.Name = "medicinetypename_vchr";
            this.medicinetypename_vchr.Width = 120;
            // 
            // LOTNO_INT
            // 
            this.LOTNO_INT.DataPropertyName = "LOTNO_INT";
            this.LOTNO_INT.HeaderText = "是否需要录入批号";
            this.LOTNO_INT.Name = "LOTNO_INT";
            this.LOTNO_INT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LOTNO_INT.TrueValue = "1";
            this.LOTNO_INT.Width = 145;
            // 
            // VALIDPERIOD_INT
            // 
            this.VALIDPERIOD_INT.DataPropertyName = "VALIDPERIOD_INT";
            this.VALIDPERIOD_INT.HeaderText = "是否需要录入有效期";
            this.VALIDPERIOD_INT.Name = "VALIDPERIOD_INT";
            this.VALIDPERIOD_INT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.VALIDPERIOD_INT.TrueValue = "1";
            this.VALIDPERIOD_INT.Width = 160;
            // 
            // medicinetypeid_chr
            // 
            this.medicinetypeid_chr.DataPropertyName = "medicinetypeid_chr";
            this.medicinetypeid_chr.HeaderText = "medicinetypeid_chr";
            this.medicinetypeid_chr.Name = "medicinetypeid_chr";
            this.medicinetypeid_chr.Visible = false;
            // 
            // frmMedicineTypeVisionmSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 444);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.Name = "frmMedicineTypeVisionmSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "药品类型显示设置";
            this.Load += new System.EventHandler(this.frmMedicineTypeVisionmSet_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvTypeVisionm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Button m_cmdSaver;
        private System.Windows.Forms.Button m_cmdCan;
        private System.Windows.Forms.ImageList imageList1;
        internal System.Windows.Forms.DataGridView m_dgvTypeVisionm;
        private System.Windows.Forms.Label m_lblSelectAll;
        private System.Windows.Forms.Label m_lblSelectAll2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn medicinetypename_vchr;
        private System.Windows.Forms.DataGridViewCheckBoxColumn LOTNO_INT;
        private System.Windows.Forms.DataGridViewCheckBoxColumn VALIDPERIOD_INT;
        private System.Windows.Forms.DataGridViewTextBoxColumn medicinetypeid_chr;
    }
}