namespace com.digitalwave.iCare.gui.HIS.Reports
{
    partial class frmArrearsQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmArrearsQuery));
            this.btnQuery = new PinkieControls.ButtonXP();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClose = new PinkieControls.ButtonXP();
            this.datEndDate = new System.Windows.Forms.DateTimePicker();
            this.datStartDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPatient = new System.Windows.Forms.DataGridView();
            this.colname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colcard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colsex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colinvo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colrepice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colybcard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coldept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coltel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colfee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dwRpt = new Sybase.DataWindow.DataWindowControl();
            this.buttonXP1 = new PinkieControls.ButtonXP();
            this.btnExport = new PinkieControls.ButtonXP();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatient)).BeginInit();
            this.SuspendLayout();
            // 
            // btnQuery
            // 
            this.btnQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnQuery.DefaultScheme = true;
            this.btnQuery.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnQuery.Hint = "";
            this.btnQuery.Location = new System.Drawing.Point(521, 25);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnQuery.Size = new System.Drawing.Size(77, 28);
            this.btnQuery.TabIndex = 1;
            this.btnQuery.Text = "查 询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(992, 77);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExport);
            this.groupBox1.Controls.Add(this.buttonXP1);
            this.groupBox1.Controls.Add(this.dwRpt);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.datEndDate);
            this.groupBox1.Controls.Add(this.btnQuery);
            this.groupBox1.Controls.Add(this.datStartDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(992, 77);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnClose.DefaultScheme = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClose.Hint = "";
            this.btnClose.Location = new System.Drawing.Point(830, 27);
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnClose.Size = new System.Drawing.Size(77, 28);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "关 闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // datEndDate
            // 
            this.datEndDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.datEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datEndDate.Location = new System.Drawing.Point(327, 27);
            this.datEndDate.Name = "datEndDate";
            this.datEndDate.Size = new System.Drawing.Size(160, 23);
            this.datEndDate.TabIndex = 4;
            // 
            // datStartDate
            // 
            this.datStartDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.datStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datStartDate.Location = new System.Drawing.Point(91, 27);
            this.datStartDate.Name = "datStartDate";
            this.datStartDate.Size = new System.Drawing.Size(159, 23);
            this.datStartDate.TabIndex = 3;
            this.datStartDate.ValueChanged += new System.EventHandler(this.datStartDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "结束日期：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "开始日期：";
            // 
            // dgvPatient
            // 
            this.dgvPatient.AllowUserToAddRows = false;
            this.dgvPatient.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPatient.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPatient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colname,
            this.colcard,
            this.colsex,
            this.colinvo,
            this.colrepice,
            this.colybcard,
            this.coldept,
            this.coltel,
            this.colfee});
            this.dgvPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPatient.Location = new System.Drawing.Point(0, 77);
            this.dgvPatient.MultiSelect = false;
            this.dgvPatient.Name = "dgvPatient";
            this.dgvPatient.ReadOnly = true;
            this.dgvPatient.RowTemplate.Height = 23;
            this.dgvPatient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPatient.Size = new System.Drawing.Size(992, 489);
            this.dgvPatient.TabIndex = 1;
            // 
            // colname
            // 
            this.colname.HeaderText = "姓名";
            this.colname.Name = "colname";
            this.colname.ReadOnly = true;
            // 
            // colcard
            // 
            this.colcard.HeaderText = "卡号";
            this.colcard.Name = "colcard";
            this.colcard.ReadOnly = true;
            // 
            // colsex
            // 
            this.colsex.HeaderText = "性别";
            this.colsex.Name = "colsex";
            this.colsex.ReadOnly = true;
            // 
            // colinvo
            // 
            this.colinvo.HeaderText = "发票号";
            this.colinvo.Name = "colinvo";
            this.colinvo.ReadOnly = true;
            this.colinvo.Visible = false;
            // 
            // colrepice
            // 
            this.colrepice.HeaderText = "处方号";
            this.colrepice.Name = "colrepice";
            this.colrepice.ReadOnly = true;
            // 
            // colybcard
            // 
            this.colybcard.HeaderText = "社保卡（身份证号）";
            this.colybcard.Name = "colybcard";
            this.colybcard.ReadOnly = true;
            // 
            // coldept
            // 
            this.coldept.HeaderText = "科室";
            this.coldept.Name = "coldept";
            this.coldept.ReadOnly = true;
            // 
            // coltel
            // 
            this.coltel.HeaderText = "病人电话";
            this.coltel.Name = "coltel";
            this.coltel.ReadOnly = true;
            // 
            // colfee
            // 
            this.colfee.HeaderText = "总费用";
            this.colfee.Name = "colfee";
            this.colfee.ReadOnly = true;
            // 
            // dwRpt
            // 
            this.dwRpt.ControlBox = true;
            this.dwRpt.DataWindowObject = "";
            this.dwRpt.LibraryList = "";
            this.dwRpt.Location = new System.Drawing.Point(913, 12);
            this.dwRpt.Name = "dwRpt";
            this.dwRpt.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwRpt.Size = new System.Drawing.Size(67, 49);
            this.dwRpt.TabIndex = 22;
            this.dwRpt.Text = "dataWindowControl1";
            this.dwRpt.Visible = false;
            // 
            // buttonXP1
            // 
            this.buttonXP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.buttonXP1.DefaultScheme = true;
            this.buttonXP1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP1.Hint = "";
            this.buttonXP1.Location = new System.Drawing.Point(729, 27);
            this.buttonXP1.Name = "buttonXP1";
            this.buttonXP1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP1.Size = new System.Drawing.Size(77, 28);
            this.buttonXP1.TabIndex = 23;
            this.buttonXP1.Text = "打印";
            this.buttonXP1.Click += new System.EventHandler(this.buttonXP1_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnExport.DefaultScheme = true;
            this.btnExport.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExport.Hint = "";
            this.btnExport.Location = new System.Drawing.Point(630, 27);
            this.btnExport.Name = "btnExport";
            this.btnExport.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnExport.Size = new System.Drawing.Size(77, 28);
            this.btnExport.TabIndex = 24;
            this.btnExport.Text = "导出";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // frmArrearsQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 566);
            this.Controls.Add(this.dgvPatient);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmArrearsQuery";
            this.Text = "欠费患者查询";
            this.Load += new System.EventHandler(this.frmArrearsQuery_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmArrearsQuery_KeyPress);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmArrearsQuery_KeyDown);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatient)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.DateTimePicker datStartDate;
        internal System.Windows.Forms.DateTimePicker datEndDate;
        internal PinkieControls.ButtonXP btnQuery;
        internal System.Windows.Forms.DataGridView dgvPatient;
        internal PinkieControls.ButtonXP btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn colname;
        private System.Windows.Forms.DataGridViewTextBoxColumn colcard;
        private System.Windows.Forms.DataGridViewTextBoxColumn colsex;
        private System.Windows.Forms.DataGridViewTextBoxColumn colinvo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colrepice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colybcard;
        private System.Windows.Forms.DataGridViewTextBoxColumn coldept;
        private System.Windows.Forms.DataGridViewTextBoxColumn coltel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colfee;
        internal Sybase.DataWindow.DataWindowControl dwRpt;
        internal PinkieControls.ButtonXP btnExport;
        internal PinkieControls.ButtonXP buttonXP1;
    }
}