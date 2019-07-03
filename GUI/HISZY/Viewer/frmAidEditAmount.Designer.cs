namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmAidEditAmount
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAidEditAmount));
            this.labelBottom = new System.Windows.Forms.Label();
            this.dtItem = new System.Windows.Forms.DataGridView();
            this.btnOK = new PinkieControls.ButtonXP();
            this.btnCancel = new PinkieControls.ButtonXP();
            this.colxh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colzlxmmc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colxmdm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colxmmc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colkdsl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colytsl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coltksl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colpid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coldj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunitdiffprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtItem)).BeginInit();
            this.SuspendLayout();
            // 
            // labelBottom
            // 
            this.labelBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBottom.Location = new System.Drawing.Point(0, 0);
            this.labelBottom.Name = "labelBottom";
            this.labelBottom.Size = new System.Drawing.Size(876, 710);
            this.labelBottom.TabIndex = 0;
            // 
            // dtItem
            // 
            this.dtItem.AllowUserToAddRows = false;
            this.dtItem.AllowUserToDeleteRows = false;
            this.dtItem.AllowUserToResizeRows = false;
            this.dtItem.BackgroundColor = System.Drawing.Color.White;
            this.dtItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtItem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtItem.ColumnHeadersHeight = 35;
            this.dtItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colxh,
            this.colzlxmmc,
            this.colxmdm,
            this.colxmmc,
            this.colkdsl,
            this.colytsl,
            this.coltksl,
            this.colpid,
            this.coldj,
            this.colunitdiffprice});
            this.dtItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtItem.Location = new System.Drawing.Point(0, 0);
            this.dtItem.MultiSelect = false;
            this.dtItem.Name = "dtItem";
            this.dtItem.RowHeadersVisible = false;
            this.dtItem.RowTemplate.Height = 23;
            this.dtItem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dtItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtItem.Size = new System.Drawing.Size(876, 666);
            this.dtItem.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.DefaultScheme = true;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnOK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Hint = "";
            this.btnOK.Location = new System.Drawing.Point(608, 669);
            this.btnOK.Name = "btnOK";
            this.btnOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnOK.Size = new System.Drawing.Size(101, 36);
            this.btnOK.TabIndex = 17;
            this.btnOK.Text = "确定(&O)";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DefaultScheme = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Hint = "";
            this.btnCancel.Location = new System.Drawing.Point(753, 669);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnCancel.Size = new System.Drawing.Size(101, 36);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // colxh
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.colxh.DefaultCellStyle = dataGridViewCellStyle2;
            this.colxh.HeaderText = "NO";
            this.colxh.Name = "colxh";
            this.colxh.ReadOnly = true;
            this.colxh.Width = 30;
            // 
            // colzlxmmc
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.colzlxmmc.DefaultCellStyle = dataGridViewCellStyle3;
            this.colzlxmmc.HeaderText = "诊疗项目名称";
            this.colzlxmmc.Name = "colzlxmmc";
            this.colzlxmmc.ReadOnly = true;
            this.colzlxmmc.Width = 250;
            // 
            // colxmdm
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.colxmdm.DefaultCellStyle = dataGridViewCellStyle4;
            this.colxmdm.HeaderText = "项目代码";
            this.colxmdm.Name = "colxmdm";
            this.colxmdm.ReadOnly = true;
            this.colxmdm.Width = 91;
            // 
            // colxmmc
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.colxmmc.DefaultCellStyle = dataGridViewCellStyle5;
            this.colxmmc.HeaderText = "项目名称";
            this.colxmmc.Name = "colxmmc";
            this.colxmmc.ReadOnly = true;
            this.colxmmc.Width = 260;
            // 
            // colkdsl
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.colkdsl.DefaultCellStyle = dataGridViewCellStyle6;
            this.colkdsl.HeaderText = "开单数量";
            this.colkdsl.Name = "colkdsl";
            this.colkdsl.ReadOnly = true;
            this.colkdsl.Width = 70;
            // 
            // colytsl
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.colytsl.DefaultCellStyle = dataGridViewCellStyle7;
            this.colytsl.HeaderText = "已退数量";
            this.colytsl.Name = "colytsl";
            this.colytsl.ReadOnly = true;
            this.colytsl.Width = 70;
            // 
            // coltksl
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Red;
            this.coltksl.DefaultCellStyle = dataGridViewCellStyle8;
            this.coltksl.HeaderText = "退款数量";
            this.coltksl.Name = "coltksl";
            this.coltksl.Width = 70;
            // 
            // colpid
            // 
            this.colpid.HeaderText = "PID";
            this.colpid.Name = "colpid";
            this.colpid.ReadOnly = true;
            this.colpid.Visible = false;
            // 
            // coldj
            // 
            this.coldj.HeaderText = "单价";
            this.coldj.Name = "coldj";
            this.coldj.ReadOnly = true;
            this.coldj.Visible = false;
            this.coldj.Width = 5;
            // 
            // colunitdiffprice
            // 
            this.colunitdiffprice.HeaderText = "药品让利";
            this.colunitdiffprice.Name = "colunitdiffprice";
            this.colunitdiffprice.Visible = false;
            // 
            // frmAidEditAmount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 710);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dtItem);
            this.Controls.Add(this.labelBottom);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmAidEditAmount";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "编辑数量";
            this.Load += new System.EventHandler(this.frmAidEditAmount_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAidEditAmount_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dtItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelBottom;
        private System.Windows.Forms.DataGridView dtItem;
        internal PinkieControls.ButtonXP btnOK;
        internal PinkieControls.ButtonXP btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colxh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colzlxmmc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colxmdm;
        private System.Windows.Forms.DataGridViewTextBoxColumn colxmmc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colkdsl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colytsl;
        private System.Windows.Forms.DataGridViewTextBoxColumn coltksl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colpid;
        private System.Windows.Forms.DataGridViewTextBoxColumn coldj;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunitdiffprice;
    }
}