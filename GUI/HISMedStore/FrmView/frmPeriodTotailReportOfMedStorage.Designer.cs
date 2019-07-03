namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmPeriodTotailReportOfMedStorage
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
            this.m_cboSelPeriodBegion = new com.digitalwave.iCare.gui.HIS.exComboBox();
            this.m_cboSelPeriodEnd = new com.digitalwave.iCare.gui.HIS.exComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_btnPrint = new PinkieControls.ButtonXP();
            this.m_btnQuery = new PinkieControls.ButtonXP();
            this.btnesc = new PinkieControls.ButtonXP();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dw_1 = new Sybase.DataWindow.DataWindowControl();
            this.label3 = new System.Windows.Forms.Label();
            this.exComboBox1 = new com.digitalwave.iCare.gui.HIS.exComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_cboSelPeriodBegion
            // 
            this.m_cboSelPeriodBegion.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.m_cboSelPeriodBegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboSelPeriodBegion.Location = new System.Drawing.Point(89, 14);
            this.m_cboSelPeriodBegion.Name = "m_cboSelPeriodBegion";
            this.m_cboSelPeriodBegion.Size = new System.Drawing.Size(194, 22);
            this.m_cboSelPeriodBegion.TabIndex = 62;
            this.m_cboSelPeriodBegion.SelectedIndexChanged += new System.EventHandler(this.m_cboSelPeriodBegion_SelectedIndexChanged);
            // 
            // m_cboSelPeriodEnd
            // 
            this.m_cboSelPeriodEnd.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.m_cboSelPeriodEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboSelPeriodEnd.Location = new System.Drawing.Point(375, 14);
            this.m_cboSelPeriodEnd.Name = "m_cboSelPeriodEnd";
            this.m_cboSelPeriodEnd.Size = new System.Drawing.Size(188, 22);
            this.m_cboSelPeriodEnd.TabIndex = 63;
            this.m_cboSelPeriodEnd.SelectedIndexChanged += new System.EventHandler(this.m_cboSelPeriodEnd_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.exComboBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.m_btnPrint);
            this.panel1.Controls.Add(this.m_btnQuery);
            this.panel1.Controls.Add(this.btnesc);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.m_cboSelPeriodEnd);
            this.panel1.Controls.Add(this.m_cboSelPeriodBegion);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 48);
            this.panel1.TabIndex = 64;
            // 
            // m_btnPrint
            // 
            this.m_btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnPrint.DefaultScheme = true;
            this.m_btnPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnPrint.Hint = "";
            this.m_btnPrint.Location = new System.Drawing.Point(822, 9);
            this.m_btnPrint.Name = "m_btnPrint";
            this.m_btnPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnPrint.Size = new System.Drawing.Size(80, 32);
            this.m_btnPrint.TabIndex = 67;
            this.m_btnPrint.TabStop = false;
            this.m_btnPrint.Text = "打印(&P)";
            this.m_btnPrint.Click += new System.EventHandler(this.m_btnPrint_Click);
            // 
            // m_btnQuery
            // 
            this.m_btnQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnQuery.DefaultScheme = true;
            this.m_btnQuery.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnQuery.Hint = "";
            this.m_btnQuery.Location = new System.Drawing.Point(726, 9);
            this.m_btnQuery.Name = "m_btnQuery";
            this.m_btnQuery.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnQuery.Size = new System.Drawing.Size(80, 32);
            this.m_btnQuery.TabIndex = 66;
            this.m_btnQuery.TabStop = false;
            this.m_btnQuery.Text = "统计(&S)";
            this.m_btnQuery.Click += new System.EventHandler(this.m_btnQuery_Click);
            // 
            // btnesc
            // 
            this.btnesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnesc.DefaultScheme = true;
            this.btnesc.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnesc.Hint = "";
            this.btnesc.Location = new System.Drawing.Point(917, 9);
            this.btnesc.Name = "btnesc";
            this.btnesc.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnesc.Size = new System.Drawing.Size(80, 32);
            this.btnesc.TabIndex = 65;
            this.btnesc.TabStop = false;
            this.btnesc.Text = "退出(&E)";
            this.btnesc.Click += new System.EventHandler(this.btnesc_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(284, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 14);
            this.label2.TabIndex = 64;
            this.label2.Text = "结束财务期：";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "开始财务期：";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dw_1);
            this.panel2.Location = new System.Drawing.Point(0, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1000, 471);
            this.panel2.TabIndex = 65;
            // 
            // dw_1
            // 
            this.dw_1.DataWindowObject = "d_medstorageinoutrport";
            this.dw_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dw_1.LibraryList = ".\\\\pbreport.pbl";
            this.dw_1.Location = new System.Drawing.Point(0, 0);
            this.dw_1.Name = "dw_1";
            this.dw_1.Size = new System.Drawing.Size(998, 469);
            this.dw_1.TabIndex = 1;
            this.dw_1.Text = "dataWindowControl1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(570, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 14);
            this.label3.TabIndex = 68;
            this.label3.Text = "药房:";
            // 
            // exComboBox1
            // 
            this.exComboBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.exComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.exComboBox1.Location = new System.Drawing.Point(613, 13);
            this.exComboBox1.Name = "exComboBox1";
            this.exComboBox1.Size = new System.Drawing.Size(95, 22);
            this.exComboBox1.TabIndex = 69;
            // 
            // frmPeriodTotailReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 527);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmPeriodTotailReport";
            this.Text = "药品进销存统计报表";
            this.Load += new System.EventHandler(this.frmPeriodTotailReport_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal exComboBox m_cboSelPeriodBegion;
        internal exComboBox m_cboSelPeriodEnd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        internal PinkieControls.ButtonXP m_btnQuery;
        internal PinkieControls.ButtonXP btnesc;
        private System.Windows.Forms.Panel panel2;
        private Sybase.DataWindow.DataWindowControl dw_1;
        internal PinkieControls.ButtonXP m_btnPrint;
        internal exComboBox exComboBox1;
        private System.Windows.Forms.Label label3;

    }
}