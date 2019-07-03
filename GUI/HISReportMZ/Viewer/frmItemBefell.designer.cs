namespace com.digitalwave.iCare.gui.HIS.Reports
{
    partial class frmItemBefell
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmItemBefell));
            this.dataWindowControl1 = new Sybase.DataWindow.DataWindowControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdClose = new PinkieControls.ButtonXP();
            this.cmdPrint = new PinkieControls.ButtonXP();
            this.m_comFind = new PinkieControls.ButtonXP();
            this.labItemName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Item = new System.Windows.Forms.TextBox();
            this.rdbDatType2 = new System.Windows.Forms.RadioButton();
            this.rdbDatType1 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_end = new System.Windows.Forms.DateTimePicker();
            this.dtp_star = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataWindowControl1
            // 
            this.dataWindowControl1.DataWindowObject = "";
            this.dataWindowControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataWindowControl1.LibraryList = "";
            this.dataWindowControl1.Location = new System.Drawing.Point(0, 0);
            this.dataWindowControl1.Name = "dataWindowControl1";
            this.dataWindowControl1.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dataWindowControl1.Size = new System.Drawing.Size(964, 482);
            this.dataWindowControl1.TabIndex = 1;
            this.dataWindowControl1.Text = "dataWindowControl1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdClose);
            this.panel1.Controls.Add(this.cmdPrint);
            this.panel1.Controls.Add(this.m_comFind);
            this.panel1.Controls.Add(this.labItemName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt_Item);
            this.panel1.Controls.Add(this.rdbDatType2);
            this.panel1.Controls.Add(this.rdbDatType1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtp_end);
            this.panel1.Controls.Add(this.dtp_star);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(964, 72);
            this.panel1.TabIndex = 2;
            // 
            // cmdClose
            // 
            this.cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.cmdClose.DefaultScheme = true;
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdClose.Hint = "";
            this.cmdClose.Location = new System.Drawing.Point(842, 35);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdClose.Size = new System.Drawing.Size(85, 31);
            this.cmdClose.TabIndex = 63;
            this.cmdClose.Text = "退出(&E)";
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdPrint
            // 
            this.cmdPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.cmdPrint.DefaultScheme = true;
            this.cmdPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdPrint.Hint = "";
            this.cmdPrint.Location = new System.Drawing.Point(749, 35);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdPrint.Size = new System.Drawing.Size(85, 31);
            this.cmdPrint.TabIndex = 62;
            this.cmdPrint.Text = "打印(&P)";
            this.cmdPrint.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // m_comFind
            // 
            this.m_comFind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_comFind.DefaultScheme = true;
            this.m_comFind.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_comFind.Hint = "";
            this.m_comFind.Location = new System.Drawing.Point(655, 35);
            this.m_comFind.Name = "m_comFind";
            this.m_comFind.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_comFind.Size = new System.Drawing.Size(85, 31);
            this.m_comFind.TabIndex = 61;
            this.m_comFind.Text = "查询(&F)";
            this.m_comFind.Click += new System.EventHandler(this.button1_Click);
            // 
            // labItemName
            // 
            this.labItemName.Location = new System.Drawing.Point(302, 16);
            this.labItemName.Name = "labItemName";
            this.labItemName.Size = new System.Drawing.Size(317, 14);
            this.labItemName.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(233, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 9;
            this.label4.Text = "项目名称：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "项目编码：";
            // 
            // txt_Item
            // 
            this.txt_Item.Location = new System.Drawing.Point(97, 13);
            this.txt_Item.Name = "txt_Item";
            this.txt_Item.Size = new System.Drawing.Size(103, 23);
            this.txt_Item.TabIndex = 7;
            this.txt_Item.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Item_KeyDown);
            // 
            // rdbDatType2
            // 
            this.rdbDatType2.AutoSize = true;
            this.rdbDatType2.Location = new System.Drawing.Point(131, 42);
            this.rdbDatType2.Name = "rdbDatType2";
            this.rdbDatType2.Size = new System.Drawing.Size(109, 18);
            this.rdbDatType2.TabIndex = 6;
            this.rdbDatType2.Text = "日结时间统计";
            this.rdbDatType2.UseVisualStyleBackColor = true;
            // 
            // rdbDatType1
            // 
            this.rdbDatType1.AutoSize = true;
            this.rdbDatType1.Checked = true;
            this.rdbDatType1.Location = new System.Drawing.Point(10, 42);
            this.rdbDatType1.Name = "rdbDatType1";
            this.rdbDatType1.Size = new System.Drawing.Size(109, 18);
            this.rdbDatType1.TabIndex = 5;
            this.rdbDatType1.TabStop = true;
            this.rdbDatType1.Text = "发票时间统计";
            this.rdbDatType1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(268, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "时间段：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(468, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "～";
            // 
            // dtp_end
            // 
            this.dtp_end.Location = new System.Drawing.Point(495, 40);
            this.dtp_end.Name = "dtp_end";
            this.dtp_end.Size = new System.Drawing.Size(126, 23);
            this.dtp_end.TabIndex = 2;
            // 
            // dtp_star
            // 
            this.dtp_star.Location = new System.Drawing.Point(333, 40);
            this.dtp_star.Name = "dtp_star";
            this.dtp_star.Size = new System.Drawing.Size(127, 23);
            this.dtp_star.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataWindowControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 72);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(964, 482);
            this.panel2.TabIndex = 3;
            // 
            // frmItemBefell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 554);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmItemBefell";
            this.Text = "项目统计发生明细报表";
            this.Load += new System.EventHandler(this.frmItemBefell_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        public Sybase.DataWindow.DataWindowControl dataWindowControl1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.DateTimePicker dtp_end;
        public System.Windows.Forms.DateTimePicker dtp_star;
        public System.Windows.Forms.RadioButton rdbDatType2;
        public System.Windows.Forms.RadioButton rdbDatType1;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txt_Item;
        public System.Windows.Forms.Label labItemName;
        public PinkieControls.ButtonXP cmdClose;
        public PinkieControls.ButtonXP cmdPrint;
        public PinkieControls.ButtonXP m_comFind;
    }
}

