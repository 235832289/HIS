namespace com.digitalwave.iCare.BIHOrder
{
    partial class frmOrderSaveCheck
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_txtBackReason = new System.Windows.Forms.TextBox();
            this.m_txtPSW_CHR = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtEMPNO_CHR = new System.Windows.Forms.TextBox();
            this.m_cmdOK = new PinkieControls.ButtonXP();
            this.m_cmdCancel = new PinkieControls.ButtonXP();
            this.label3 = new System.Windows.Forms.Label();
            this.m_dtOrderdicList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.NAME_CHR = new System.Windows.Forms.ColumnHeader();
            this.ItemPrice = new System.Windows.Forms.ColumnHeader();
            this.get_dec = new System.Windows.Forms.ColumnHeader();
            this.pricesum = new System.Windows.Forms.ColumnHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_lbltip = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.m_dtOrderdicList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(668, 295);
            this.panel2.TabIndex = 29;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_txtBackReason);
            this.groupBox1.Controls.Add(this.m_txtPSW_CHR);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.m_txtEMPNO_CHR);
            this.groupBox1.Controls.Add(this.m_cmdOK);
            this.groupBox1.Controls.Add(this.m_cmdCancel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(396, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 293);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // m_txtBackReason
            // 
            this.m_txtBackReason.BackColor = System.Drawing.Color.Snow;
            this.m_txtBackReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtBackReason.Location = new System.Drawing.Point(13, 24);
            this.m_txtBackReason.Multiline = true;
            this.m_txtBackReason.Name = "m_txtBackReason";
            this.m_txtBackReason.ReadOnly = true;
            this.m_txtBackReason.Size = new System.Drawing.Size(243, 109);
            this.m_txtBackReason.TabIndex = 45;
            this.m_txtBackReason.TabStop = false;
            // 
            // m_txtPSW_CHR
            // 
            this.m_txtPSW_CHR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtPSW_CHR.Location = new System.Drawing.Point(74, 188);
            this.m_txtPSW_CHR.Name = "m_txtPSW_CHR";
            this.m_txtPSW_CHR.PasswordChar = '*';
            this.m_txtPSW_CHR.Size = new System.Drawing.Size(172, 21);
            this.m_txtPSW_CHR.TabIndex = 29;
            this.m_txtPSW_CHR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtPSW_CHR_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 31;
            this.label2.Text = "密码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 30;
            this.label1.Text = "工号：";
            // 
            // m_txtEMPNO_CHR
            // 
            this.m_txtEMPNO_CHR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtEMPNO_CHR.Location = new System.Drawing.Point(74, 152);
            this.m_txtEMPNO_CHR.Name = "m_txtEMPNO_CHR";
            this.m_txtEMPNO_CHR.Size = new System.Drawing.Size(172, 21);
            this.m_txtEMPNO_CHR.TabIndex = 28;
            this.m_txtEMPNO_CHR.TextChanged += new System.EventHandler(this.m_txtEMPNO_CHR_TextChanged);
            this.m_txtEMPNO_CHR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtEMPNO_CHR_KeyDown);
            // 
            // m_cmdOK
            // 
            this.m_cmdOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdOK.DefaultScheme = true;
            this.m_cmdOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdOK.Hint = "";
            this.m_cmdOK.Location = new System.Drawing.Point(65, 238);
            this.m_cmdOK.Name = "m_cmdOK";
            this.m_cmdOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdOK.Size = new System.Drawing.Size(66, 28);
            this.m_cmdOK.TabIndex = 30;
            this.m_cmdOK.Text = "确定(F1)";
            this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
            // 
            // m_cmdCancel
            // 
            this.m_cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdCancel.DefaultScheme = true;
            this.m_cmdCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdCancel.Hint = "";
            this.m_cmdCancel.Location = new System.Drawing.Point(149, 238);
            this.m_cmdCancel.Name = "m_cmdCancel";
            this.m_cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCancel.Size = new System.Drawing.Size(71, 28);
            this.m_cmdCancel.TabIndex = 31;
            this.m_cmdCancel.Text = "取消(Esc)";
            this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(443, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 12);
            this.label3.TabIndex = 1;
            // 
            // m_dtOrderdicList
            // 
            this.m_dtOrderdicList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_dtOrderdicList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.NAME_CHR,
            this.ItemPrice,
            this.get_dec,
            this.pricesum});
            this.m_dtOrderdicList.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_dtOrderdicList.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtOrderdicList.FullRowSelect = true;
            this.m_dtOrderdicList.GridLines = true;
            this.m_dtOrderdicList.Location = new System.Drawing.Point(0, 0);
            this.m_dtOrderdicList.Name = "m_dtOrderdicList";
            this.m_dtOrderdicList.Size = new System.Drawing.Size(392, 293);
            this.m_dtOrderdicList.TabIndex = 0;
            this.m_dtOrderdicList.TabStop = false;
            this.m_dtOrderdicList.UseCompatibleStateImageBehavior = false;
            this.m_dtOrderdicList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "序号";
            // 
            // NAME_CHR
            // 
            this.NAME_CHR.Text = "收费项目";
            this.NAME_CHR.Width = 116;
            // 
            // ItemPrice
            // 
            this.ItemPrice.Text = "单价";
            this.ItemPrice.Width = 56;
            // 
            // get_dec
            // 
            this.get_dec.Text = "数量";
            this.get_dec.Width = 54;
            // 
            // pricesum
            // 
            this.pricesum.Text = "金额";
            this.pricesum.Width = 74;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.m_lbltip);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(668, 40);
            this.panel1.TabIndex = 0;
            // 
            // m_lbltip
            // 
            this.m_lbltip.AutoSize = true;
            this.m_lbltip.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lbltip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_lbltip.Location = new System.Drawing.Point(12, 14);
            this.m_lbltip.Name = "m_lbltip";
            this.m_lbltip.Size = new System.Drawing.Size(16, 15);
            this.m_lbltip.TabIndex = 1;
            this.m_lbltip.Text = "?";
            // 
            // frmOrderSaveCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 347);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "frmOrderSaveCheck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "确认框";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmOrderSaveCheck_KeyDown);
            this.Load += new System.EventHandler(this.frmOrderSaveCheck_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PinkieControls.ButtonXP m_cmdCancel;
        private PinkieControls.ButtonXP m_cmdOK;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.ListView m_dtOrderdicList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader NAME_CHR;
        private System.Windows.Forms.ColumnHeader ItemPrice;
        private System.Windows.Forms.ColumnHeader get_dec;
        private System.Windows.Forms.ColumnHeader pricesum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label m_lbltip;
        internal System.Windows.Forms.TextBox m_txtBackReason;
        public System.Windows.Forms.TextBox m_txtPSW_CHR;
        public System.Windows.Forms.TextBox m_txtEMPNO_CHR;
    }
}