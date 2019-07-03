namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmItem
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
            this.m_lsvList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmdOK = new PinkieControls.ButtonXP();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_lsvList);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(277, 309);
            this.panel1.TabIndex = 6;
            // 
            // m_lsvList
            // 
            this.m_lsvList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.m_lsvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvList.FullRowSelect = true;
            this.m_lsvList.GridLines = true;
            this.m_lsvList.Location = new System.Drawing.Point(0, 0);
            this.m_lsvList.MultiSelect = false;
            this.m_lsvList.Name = "m_lsvList";
            this.m_lsvList.Size = new System.Drawing.Size(277, 259);
            this.m_lsvList.TabIndex = 5;
            this.m_lsvList.UseCompatibleStateImageBehavior = false;
            this.m_lsvList.View = System.Windows.Forms.View.Details;
            this.m_lsvList.DoubleClick += new System.EventHandler(this.m_lsvList_DoubleClick);
            this.m_lsvList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_lsvList_KeyDown);
            this.m_lsvList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_lsvList_MouseDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "项目代码";
            this.columnHeader1.Width = 91;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "项目名称";
            this.columnHeader2.Width = 152;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(277, 259);
            this.panel3.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmdOK);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 259);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(277, 50);
            this.panel2.TabIndex = 4;
            // 
            // cmdOK
            // 
            this.cmdOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdOK.DefaultScheme = true;
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdOK.Hint = "";
            this.cmdOK.Location = new System.Drawing.Point(103, 6);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdOK.Size = new System.Drawing.Size(88, 37);
            this.cmdOK.TabIndex = 56;
            this.cmdOK.Text = "确定";
            this.cmdOK.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 309);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "项目列表";
            this.Load += new System.EventHandler(this.frmItem_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.ListView m_lsvList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        public PinkieControls.ButtonXP cmdOK;
    }
}