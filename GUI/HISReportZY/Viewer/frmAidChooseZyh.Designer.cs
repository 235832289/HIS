namespace com.digitalwave.iCare.gui.HIS.Reports
{
    partial class frmAidChooseZyh
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
            this.dtPat = new System.Windows.Forms.DataGridView();
            this.colzyh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colzycs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colxm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtPat)).BeginInit();
            this.SuspendLayout();
            // 
            // dtPat
            // 
            this.dtPat.AllowUserToAddRows = false;
            this.dtPat.AllowUserToDeleteRows = false;
            this.dtPat.AllowUserToResizeRows = false;
            this.dtPat.BackgroundColor = System.Drawing.Color.White;
            this.dtPat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtPat.ColumnHeadersHeight = 30;
            this.dtPat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colzyh,
            this.colzycs,
            this.colxm});
            this.dtPat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtPat.Location = new System.Drawing.Point(0, 0);
            this.dtPat.MultiSelect = false;
            this.dtPat.Name = "dtPat";
            this.dtPat.ReadOnly = true;
            this.dtPat.RowHeadersVisible = false;
            this.dtPat.RowTemplate.Height = 23;
            this.dtPat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtPat.ShowCellErrors = false;
            this.dtPat.ShowEditingIcon = false;
            this.dtPat.ShowRowErrors = false;
            this.dtPat.Size = new System.Drawing.Size(267, 366);
            this.dtPat.TabIndex = 0;
            this.dtPat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtPat_KeyDown);
            this.dtPat.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dtPat_MouseDoubleClick);
            // 
            // colzyh
            // 
            this.colzyh.HeaderText = "住院号";
            this.colzyh.Name = "colzyh";
            this.colzyh.ReadOnly = true;
            this.colzyh.Width = 80;
            // 
            // colzycs
            // 
            this.colzycs.HeaderText = "住院次数";
            this.colzycs.Name = "colzycs";
            this.colzycs.ReadOnly = true;
            this.colzycs.Width = 90;
            // 
            // colxm
            // 
            this.colxm.HeaderText = "姓名";
            this.colxm.Name = "colxm";
            this.colxm.ReadOnly = true;
            this.colxm.Width = 90;
            // 
            // frmAidChooseZyh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 366);
            this.Controls.Add(this.dtPat);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmAidChooseZyh";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "请选择";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAidChooseZyh_KeyDown);
            this.Load += new System.EventHandler(this.frmAidChooseZyh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtPat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtPat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colzyh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colzycs;
        private System.Windows.Forms.DataGridViewTextBoxColumn colxm;
    }
}