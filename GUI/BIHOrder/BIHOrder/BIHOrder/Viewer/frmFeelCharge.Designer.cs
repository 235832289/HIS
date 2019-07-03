namespace com.digitalwave.iCare.BIHOrder
{
    partial class frmFeelCharge
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFeelCharge));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdCancel = new PinkieControls.ButtonXP();
            this.cmdCharge = new PinkieControls.ButtonXP();
            this.m_dtvChangeList = new System.Windows.Forms.DataGridView();
            this.chkbox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chargeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ITEMSPEC_VCHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChargeClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChargePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.get_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xuClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.excuteDept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YBClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IPNOQTYFLAG_INT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtvChangeList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.cmdCancel);
            this.panel1.Controls.Add(this.cmdCharge);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 199);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(708, 45);
            this.panel1.TabIndex = 0;
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdCancel.DefaultScheme = true;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdCancel.Hint = "";
            this.cmdCancel.Location = new System.Drawing.Point(599, 5);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdCancel.Size = new System.Drawing.Size(89, 33);
            this.cmdCancel.TabIndex = 100;
            this.cmdCancel.Text = "取消";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdCharge
            // 
            this.cmdCharge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdCharge.DefaultScheme = true;
            this.cmdCharge.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdCharge.Hint = "";
            this.cmdCharge.Location = new System.Drawing.Point(483, 5);
            this.cmdCharge.Name = "cmdCharge";
            this.cmdCharge.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdCharge.Size = new System.Drawing.Size(89, 33);
            this.cmdCharge.TabIndex = 99;
            this.cmdCharge.Text = "收取费用";
            this.cmdCharge.Click += new System.EventHandler(this.cmdCharge_Click);
            // 
            // m_dtvChangeList
            // 
            this.m_dtvChangeList.AllowUserToAddRows = false;
            this.m_dtvChangeList.AllowUserToDeleteRows = false;
            this.m_dtvChangeList.AllowUserToResizeRows = false;
            this.m_dtvChangeList.BackgroundColor = System.Drawing.Color.White;
            this.m_dtvChangeList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_dtvChangeList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.m_dtvChangeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dtvChangeList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chkbox,
            this.seq,
            this.chargeName,
            this.ITEMSPEC_VCHR,
            this.ChargeClass,
            this.ChargePrice,
            this.get_count,
            this.countSum,
            this.xuClass,
            this.excuteDept,
            this.YBClass,
            this.IPNOQTYFLAG_INT});
            this.m_dtvChangeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dtvChangeList.Location = new System.Drawing.Point(0, 0);
            this.m_dtvChangeList.Name = "m_dtvChangeList";
            this.m_dtvChangeList.RowHeadersVisible = false;
            this.m_dtvChangeList.RowTemplate.Height = 23;
            this.m_dtvChangeList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dtvChangeList.Size = new System.Drawing.Size(708, 199);
            this.m_dtvChangeList.TabIndex = 62;
            // 
            // chkbox
            // 
            this.chkbox.FalseValue = "F";
            this.chkbox.HeaderText = "";
            this.chkbox.Name = "chkbox";
            this.chkbox.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chkbox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.chkbox.TrueValue = "T";
            this.chkbox.Width = 24;
            // 
            // seq
            // 
            this.seq.HeaderText = "序";
            this.seq.Name = "seq";
            this.seq.ReadOnly = true;
            this.seq.Width = 30;
            // 
            // chargeName
            // 
            this.chargeName.HeaderText = "项目名称";
            this.chargeName.Name = "chargeName";
            this.chargeName.ReadOnly = true;
            this.chargeName.Width = 190;
            // 
            // ITEMSPEC_VCHR
            // 
            this.ITEMSPEC_VCHR.HeaderText = "规格";
            this.ITEMSPEC_VCHR.Name = "ITEMSPEC_VCHR";
            this.ITEMSPEC_VCHR.ReadOnly = true;
            // 
            // ChargeClass
            // 
            this.ChargeClass.HeaderText = "费用类型";
            this.ChargeClass.Name = "ChargeClass";
            this.ChargeClass.ReadOnly = true;
            this.ChargeClass.Width = 90;
            // 
            // ChargePrice
            // 
            this.ChargePrice.HeaderText = "单价";
            this.ChargePrice.Name = "ChargePrice";
            this.ChargePrice.ReadOnly = true;
            this.ChargePrice.Width = 80;
            // 
            // get_count
            // 
            this.get_count.HeaderText = "每次领量";
            this.get_count.Name = "get_count";
            this.get_count.ReadOnly = true;
            this.get_count.Width = 90;
            // 
            // countSum
            // 
            this.countSum.HeaderText = "合计金额";
            this.countSum.Name = "countSum";
            this.countSum.ReadOnly = true;
            this.countSum.Width = 90;
            // 
            // xuClass
            // 
            this.xuClass.HeaderText = "续用类型";
            this.xuClass.Name = "xuClass";
            this.xuClass.ReadOnly = true;
            this.xuClass.Width = 90;
            // 
            // excuteDept
            // 
            this.excuteDept.HeaderText = "执行科室";
            this.excuteDept.Name = "excuteDept";
            this.excuteDept.ReadOnly = true;
            // 
            // YBClass
            // 
            this.YBClass.HeaderText = "医保类型";
            this.YBClass.Name = "YBClass";
            this.YBClass.ReadOnly = true;
            this.YBClass.Width = 90;
            // 
            // IPNOQTYFLAG_INT
            // 
            this.IPNOQTYFLAG_INT.HeaderText = "药房";
            this.IPNOQTYFLAG_INT.Name = "IPNOQTYFLAG_INT";
            this.IPNOQTYFLAG_INT.ReadOnly = true;
            this.IPNOQTYFLAG_INT.Width = 60;
            // 
            // frmFeelCharge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 244);
            this.Controls.Add(this.m_dtvChangeList);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFeelCharge";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "皮试费用收取";
            this.Load += new System.EventHandler(this.frmFeelCharge_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dtvChangeList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.DataGridView m_dtvChangeList;
        private PinkieControls.ButtonXP cmdCancel;
        private PinkieControls.ButtonXP cmdCharge;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn seq;
        private System.Windows.Forms.DataGridViewTextBoxColumn chargeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEMSPEC_VCHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChargeClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChargePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn get_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn countSum;
        private System.Windows.Forms.DataGridViewTextBoxColumn xuClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn excuteDept;
        private System.Windows.Forms.DataGridViewTextBoxColumn YBClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPNOQTYFLAG_INT;
    }
}