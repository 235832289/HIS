namespace com.digitalwave.iCare.gui.HIS.Reports
{
    partial class frmOPRegisterStatByInvoArrRpt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOPRegisterStatByInvoArrRpt));
            this.btnPrint = new PinkieControls.ButtonXP();
            this.dwRpt = new Sybase.DataWindow.DataWindowControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEsc = new PinkieControls.ButtonXP();
            this.labTo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_txtEndInvo = new System.Windows.Forms.TextBox();
            this.m_txtStartInvo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btExcel = new PinkieControls.ButtonXP();
            this.btnFind = new PinkieControls.ButtonXP();
            this.m_cboCheckMan = new com.digitalwave.iCare.gui.HIS.exComboBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnPrint.DefaultScheme = true;
            this.btnPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPrint.Hint = "";
            this.btnPrint.Location = new System.Drawing.Point(833, 13);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnPrint.Size = new System.Drawing.Size(90, 36);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "打印（&P）";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
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
            this.dwRpt.Size = new System.Drawing.Size(1028, 658);
            this.dwRpt.TabIndex = 21;
            this.dwRpt.Text = "dataWindowControl1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dwRpt);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 61);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1028, 658);
            this.panel2.TabIndex = 3;
            // 
            // btnEsc
            // 
            this.btnEsc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEsc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnEsc.DefaultScheme = true;
            this.btnEsc.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnEsc.Hint = "";
            this.btnEsc.Location = new System.Drawing.Point(929, 13);
            this.btnEsc.Name = "btnEsc";
            this.btnEsc.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnEsc.Size = new System.Drawing.Size(90, 36);
            this.btnEsc.TabIndex = 6;
            this.btnEsc.Text = "退出（&E）";
            this.btnEsc.Click += new System.EventHandler(this.btnEsc_Click);
            // 
            // labTo
            // 
            this.labTo.Location = new System.Drawing.Point(225, 26);
            this.labTo.Name = "labTo";
            this.labTo.Size = new System.Drawing.Size(71, 19);
            this.labTo.TabIndex = 35;
            this.labTo.Text = "截止发票:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 34;
            this.label1.Text = "起始发票:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_txtEndInvo);
            this.panel1.Controls.Add(this.m_txtStartInvo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.labTo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btExcel);
            this.panel1.Controls.Add(this.btnFind);
            this.panel1.Controls.Add(this.m_cboCheckMan);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnEsc);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1028, 61);
            this.panel1.TabIndex = 2;
            // 
            // m_txtEndInvo
            // 
            this.m_txtEndInvo.Location = new System.Drawing.Point(302, 21);
            this.m_txtEndInvo.Name = "m_txtEndInvo";
            this.m_txtEndInvo.Size = new System.Drawing.Size(135, 23);
            this.m_txtEndInvo.TabIndex = 39;
            // 
            // m_txtStartInvo
            // 
            this.m_txtStartInvo.Location = new System.Drawing.Point(84, 21);
            this.m_txtStartInvo.Name = "m_txtStartInvo";
            this.m_txtStartInvo.Size = new System.Drawing.Size(135, 23);
            this.m_txtStartInvo.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(448, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 14);
            this.label2.TabIndex = 37;
            this.label2.Text = "收费员:";
            // 
            // btExcel
            // 
            this.btExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btExcel.DefaultScheme = true;
            this.btExcel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btExcel.Hint = "";
            this.btExcel.Location = new System.Drawing.Point(737, 13);
            this.btExcel.Name = "btExcel";
            this.btExcel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btExcel.Size = new System.Drawing.Size(90, 36);
            this.btExcel.TabIndex = 4;
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
            this.btnFind.Location = new System.Drawing.Point(641, 13);
            this.btnFind.Name = "btnFind";
            this.btnFind.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnFind.Size = new System.Drawing.Size(90, 36);
            this.btnFind.TabIndex = 3;
            this.btnFind.Text = "统计（&F）";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // m_cboCheckMan
            // 
            this.m_cboCheckMan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboCheckMan.Location = new System.Drawing.Point(508, 21);
            this.m_cboCheckMan.Name = "m_cboCheckMan";
            this.m_cboCheckMan.Size = new System.Drawing.Size(102, 22);
            this.m_cboCheckMan.TabIndex = 2;
            // 
            // frmOPRegisterStatByInvoArrRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 719);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOPRegisterStatByInvoArrRpt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "挂号统计报表（发票段）";
            this.Load += new System.EventHandler(this.frmOPRegisterStatRpt_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PinkieControls.ButtonXP btnPrint;
        internal Sybase.DataWindow.DataWindowControl dwRpt;
        private System.Windows.Forms.Panel panel2;
        private PinkieControls.ButtonXP btnEsc;
        internal System.Windows.Forms.Label labTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private PinkieControls.ButtonXP btExcel;
        private PinkieControls.ButtonXP btnFind;
        private System.Windows.Forms.Label label2;
        internal exComboBox m_cboCheckMan;
        private System.Windows.Forms.TextBox m_txtEndInvo;
        private System.Windows.Forms.TextBox m_txtStartInvo;
    }
}