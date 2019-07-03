namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmQueryCharge_ItemSum
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQueryCharge_ItemSum));
            this.dtItem = new System.Windows.Forms.DataGridView();
            this.serno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colxmdm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colxmmc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colsl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.facttotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colgg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coldw = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colfyfl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiffCostMny = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRequiredPay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new PinkieControls.ButtonXP();
            this.btnPrint = new PinkieControls.ButtonXP();
            this.btnExport = new PinkieControls.ButtonXP();
            ((System.ComponentModel.ISupportInitialize)(this.dtItem)).BeginInit();
            this.SuspendLayout();
            // 
            // dtItem
            // 
            this.dtItem.AllowUserToAddRows = false;
            this.dtItem.AllowUserToDeleteRows = false;
            this.dtItem.AllowUserToResizeRows = false;
            this.dtItem.BackgroundColor = System.Drawing.Color.White;
            this.dtItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtItem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dtItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtItem.ColumnHeadersHeight = 22;
            this.dtItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.serno,
            this.colxmdm,
            this.colxmmc,
            this.colsl,
            this.colje,
            this.colprice,
            this.scale,
            this.facttotal,
            this.colgg,
            this.coldw,
            this.colfyfl,
            this.colDiffCostMny,
            this.colRequiredPay});
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtItem.DefaultCellStyle = dataGridViewCellStyle13;
            this.dtItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtItem.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtItem.Location = new System.Drawing.Point(0, 0);
            this.dtItem.Name = "dtItem";
            this.dtItem.RowHeadersVisible = false;
            this.dtItem.RowTemplate.Height = 23;
            this.dtItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtItem.ShowCellErrors = false;
            this.dtItem.ShowRowErrors = false;
            this.dtItem.Size = new System.Drawing.Size(944, 624);
            this.dtItem.TabIndex = 3;
            // 
            // serno
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10F);
            this.serno.DefaultCellStyle = dataGridViewCellStyle2;
            this.serno.HeaderText = "No.";
            this.serno.Name = "serno";
            this.serno.ReadOnly = true;
            this.serno.Width = 35;
            // 
            // colxmdm
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.colxmdm.DefaultCellStyle = dataGridViewCellStyle3;
            this.colxmdm.HeaderText = "项目代码";
            this.colxmdm.Name = "colxmdm";
            this.colxmdm.ReadOnly = true;
            this.colxmdm.Width = 130;
            // 
            // colxmmc
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 10F);
            this.colxmmc.DefaultCellStyle = dataGridViewCellStyle4;
            this.colxmmc.HeaderText = "项目名称";
            this.colxmmc.Name = "colxmmc";
            this.colxmmc.ReadOnly = true;
            this.colxmmc.Width = 200;
            // 
            // colsl
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 10F);
            this.colsl.DefaultCellStyle = dataGridViewCellStyle5;
            this.colsl.HeaderText = "数量";
            this.colsl.Name = "colsl";
            this.colsl.ReadOnly = true;
            this.colsl.Width = 50;
            // 
            // colje
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            this.colje.DefaultCellStyle = dataGridViewCellStyle6;
            this.colje.HeaderText = "合计金额";
            this.colje.Name = "colje";
            this.colje.ReadOnly = true;
            this.colje.Width = 80;
            // 
            // colprice
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 10F);
            this.colprice.DefaultCellStyle = dataGridViewCellStyle7;
            this.colprice.HeaderText = "单价";
            this.colprice.Name = "colprice";
            this.colprice.ReadOnly = true;
            this.colprice.Width = 65;
            // 
            // scale
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 10F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            this.scale.DefaultCellStyle = dataGridViewCellStyle8;
            this.scale.HeaderText = "自付%";
            this.scale.Name = "scale";
            this.scale.ReadOnly = true;
            this.scale.Width = 50;
            // 
            // facttotal
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 10F);
            this.facttotal.DefaultCellStyle = dataGridViewCellStyle9;
            this.facttotal.HeaderText = "应付金额";
            this.facttotal.Name = "facttotal";
            this.facttotal.ReadOnly = true;
            this.facttotal.Width = 80;
            // 
            // colgg
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 10F);
            this.colgg.DefaultCellStyle = dataGridViewCellStyle10;
            this.colgg.HeaderText = "规格";
            this.colgg.Name = "colgg";
            this.colgg.ReadOnly = true;
            // 
            // coldw
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("宋体", 10F);
            this.coldw.DefaultCellStyle = dataGridViewCellStyle11;
            this.coldw.HeaderText = "单位";
            this.coldw.Name = "coldw";
            this.coldw.ReadOnly = true;
            this.coldw.Width = 50;
            // 
            // colfyfl
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("宋体", 10F);
            this.colfyfl.DefaultCellStyle = dataGridViewCellStyle12;
            this.colfyfl.HeaderText = "费用分类";
            this.colfyfl.Name = "colfyfl";
            this.colfyfl.ReadOnly = true;
            this.colfyfl.Width = 80;
            // 
            // colDiffCostMny
            // 
            this.colDiffCostMny.HeaderText = "让利金额";
            this.colDiffCostMny.Name = "colDiffCostMny";
            // 
            // colRequiredPay
            // 
            this.colRequiredPay.HeaderText = "实付金额";
            this.colRequiredPay.Name = "colRequiredPay";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DefaultScheme = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Hint = "";
            this.btnClose.Location = new System.Drawing.Point(736, 630);
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnClose.Size = new System.Drawing.Size(103, 32);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "关闭 Esc";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.DefaultScheme = true;
            this.btnPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrint.Hint = "";
            this.btnPrint.Location = new System.Drawing.Point(312, 630);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnPrint.Size = new System.Drawing.Size(103, 32);
            this.btnPrint.TabIndex = 15;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.DefaultScheme = true;
            this.btnExport.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExport.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExport.Hint = "";
            this.btnExport.Location = new System.Drawing.Point(444, 630);
            this.btnExport.Name = "btnExport";
            this.btnExport.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnExport.Size = new System.Drawing.Size(103, 32);
            this.btnExport.TabIndex = 16;
            this.btnExport.Text = "导出(&E)";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // frmQueryCharge_ItemSum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 667);
            this.Controls.Add(this.dtItem);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmQueryCharge_ItemSum";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "项目汇总";
            this.Load += new System.EventHandler(this.frmQueryCharge_ItemSum_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmQueryCharge_ItemSum_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dtItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView dtItem;
        internal PinkieControls.ButtonXP btnClose;
        internal PinkieControls.ButtonXP btnPrint;
        internal PinkieControls.ButtonXP btnExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn serno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colxmdm;
        private System.Windows.Forms.DataGridViewTextBoxColumn colxmmc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colsl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colje;
        private System.Windows.Forms.DataGridViewTextBoxColumn colprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn scale;
        private System.Windows.Forms.DataGridViewTextBoxColumn facttotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colgg;
        private System.Windows.Forms.DataGridViewTextBoxColumn coldw;
        private System.Windows.Forms.DataGridViewTextBoxColumn colfyfl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiffCostMny;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRequiredPay;
    }
}