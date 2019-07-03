namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmOPInvoiceRpt
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_endDate = new System.Windows.Forms.DateTimePicker();
            this.m_cboDeptdesc = new com.digitalwave.iCare.gui.HIS.exComboBox();
            this.labTo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btExcel = new PinkieControls.ButtonXP();
            this.btnFind = new PinkieControls.ButtonXP();
            this.m_cboCheckMan = new com.digitalwave.iCare.gui.HIS.exComboBox();
            this.m_beginDate = new System.Windows.Forms.DateTimePicker();
            this.btnPrint = new PinkieControls.ButtonXP();
            this.btnEsc = new PinkieControls.ButtonXP();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dwRpt = new Sybase.DataWindow.DataWindowControl();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_endDate);
            this.panel1.Controls.Add(this.m_cboDeptdesc);
            this.panel1.Controls.Add(this.labTo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btExcel);
            this.panel1.Controls.Add(this.btnFind);
            this.panel1.Controls.Add(this.m_cboCheckMan);
            this.panel1.Controls.Add(this.m_beginDate);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnEsc);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(894, 66);
            this.panel1.TabIndex = 0;
            // 
            // m_endDate
            // 
            this.m_endDate.CustomFormat = "yyyy年MM月dd日";
            this.m_endDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_endDate.Location = new System.Drawing.Point(229, 21);
            this.m_endDate.Name = "m_endDate";
            this.m_endDate.Size = new System.Drawing.Size(119, 23);
            this.m_endDate.TabIndex = 38;
            // 
            // m_cboDeptdesc
            // 
            this.m_cboDeptdesc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboDeptdesc.Location = new System.Drawing.Point(463, 22);
            this.m_cboDeptdesc.Name = "m_cboDeptdesc";
            this.m_cboDeptdesc.Size = new System.Drawing.Size(103, 22);
            this.m_cboDeptdesc.TabIndex = 37;
            this.m_cboDeptdesc.SelectedIndexChanged += new System.EventHandler(this.m_cboDeptdesc_SelectedIndexChanged);
            // 
            // labTo
            // 
            this.labTo.Location = new System.Drawing.Point(205, 25);
            this.labTo.Name = "labTo";
            this.labTo.Size = new System.Drawing.Size(28, 22);
            this.labTo.TabIndex = 35;
            this.labTo.Text = "到";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 22);
            this.label1.TabIndex = 34;
            this.label1.Text = "时间: 从";
            // 
            // btExcel
            // 
            this.btExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btExcel.DefaultScheme = true;
            this.btExcel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btExcel.Hint = "";
            this.btExcel.Location = new System.Drawing.Point(638, 17);
            this.btExcel.Name = "btExcel";
            this.btExcel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btExcel.Size = new System.Drawing.Size(80, 31);
            this.btExcel.TabIndex = 30;
            this.btExcel.Text = "导出（&O）";
            this.btExcel.Click += new System.EventHandler(this.btExcel_Click);
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnFind.DefaultScheme = true;
            this.btnFind.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnFind.Hint = "";
            this.btnFind.Location = new System.Drawing.Point(555, 17);
            this.btnFind.Name = "btnFind";
            this.btnFind.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnFind.Size = new System.Drawing.Size(80, 31);
            this.btnFind.TabIndex = 29;
            this.btnFind.Text = "统计（&F）";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // m_cboCheckMan
            // 
            this.m_cboCheckMan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboCheckMan.Location = new System.Drawing.Point(354, 22);
            this.m_cboCheckMan.Name = "m_cboCheckMan";
            this.m_cboCheckMan.Size = new System.Drawing.Size(105, 22);
            this.m_cboCheckMan.TabIndex = 33;
            // 
            // m_beginDate
            // 
            this.m_beginDate.CustomFormat = "yyyy年MM月dd日";
            this.m_beginDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_beginDate.Location = new System.Drawing.Point(73, 21);
            this.m_beginDate.Name = "m_beginDate";
            this.m_beginDate.Size = new System.Drawing.Size(125, 23);
            this.m_beginDate.TabIndex = 28;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnPrint.DefaultScheme = true;
            this.btnPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPrint.Hint = "";
            this.btnPrint.Location = new System.Drawing.Point(724, 17);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnPrint.Size = new System.Drawing.Size(80, 31);
            this.btnPrint.TabIndex = 31;
            this.btnPrint.Text = "打印（&P）";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnEsc
            // 
            this.btnEsc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEsc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnEsc.DefaultScheme = true;
            this.btnEsc.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnEsc.Hint = "";
            this.btnEsc.Location = new System.Drawing.Point(804, 17);
            this.btnEsc.Name = "btnEsc";
            this.btnEsc.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnEsc.Size = new System.Drawing.Size(80, 31);
            this.btnEsc.TabIndex = 32;
            this.btnEsc.Text = "退出（&E）";
            this.btnEsc.Click += new System.EventHandler(this.btnEsc_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dwRpt);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(894, 550);
            this.panel2.TabIndex = 1;
            // 
            // dwRpt
            // 
            this.dwRpt.ControlBox = true;
            this.dwRpt.DataWindowObject = "";
            this.dwRpt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwRpt.LibraryList = "";
            this.dwRpt.Location = new System.Drawing.Point(0, 0);
            this.dwRpt.Name = "dwRpt";
            this.dwRpt.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwRpt.Size = new System.Drawing.Size(894, 550);
            this.dwRpt.TabIndex = 21;
            this.dwRpt.Text = "dataWindowControl1";
            // 
            // frmOPInvoiceRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 616);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmOPInvoiceRpt";
            this.Text = "frmOPInvoiceRpt";
            this.Load += new System.EventHandler(this.frmOPInvoiceRpt_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        internal Sybase.DataWindow.DataWindowControl dwRpt;
        private System.Windows.Forms.Label label1;
        private PinkieControls.ButtonXP btExcel;
        private PinkieControls.ButtonXP btnFind;
        internal exComboBox m_cboCheckMan;
        internal System.Windows.Forms.DateTimePicker m_beginDate;
        private PinkieControls.ButtonXP btnPrint;
        private PinkieControls.ButtonXP btnEsc;
        internal System.Windows.Forms.Label labTo;
        internal exComboBox m_cboDeptdesc;
        internal System.Windows.Forms.DateTimePicker m_endDate;
    }
}