namespace com.digitalwave.iCare.BIHOrder
{
    partial class frmFeelCard
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
            this.dw_1 = new Sybase.DataWindow.DataWindowControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonXP1 = new PinkieControls.ButtonXP();
            this.m_cmdPrintFeel = new PinkieControls.ButtonXP();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dw_1
            // 
            this.dw_1.DataWindowObject = "d_bih_feelcard";
            this.dw_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dw_1.LibraryList = "D:\\icar_ver2\\Code\\bin\\Debug\\pb_new.pbl";
            this.dw_1.Location = new System.Drawing.Point(0, 0);
            this.dw_1.Name = "dw_1";
            this.dw_1.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dw_1.Size = new System.Drawing.Size(711, 523);
            this.dw_1.TabIndex = 0;
            this.dw_1.Text = "dataWindowControl1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dw_1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(711, 523);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.buttonXP1);
            this.panel2.Controls.Add(this.m_cmdPrintFeel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 523);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(711, 41);
            this.panel2.TabIndex = 2;
            // 
            // buttonXP1
            // 
            this.buttonXP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP1.DefaultScheme = true;
            this.buttonXP1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP1.Hint = "";
            this.buttonXP1.Location = new System.Drawing.Point(576, 3);
            this.buttonXP1.Name = "buttonXP1";
            this.buttonXP1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP1.Size = new System.Drawing.Size(82, 31);
            this.buttonXP1.TabIndex = 32;
            this.buttonXP1.Text = "打印";
            this.buttonXP1.Click += new System.EventHandler(this.buttonXP1_Click);
            // 
            // m_cmdPrintFeel
            // 
            this.m_cmdPrintFeel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdPrintFeel.DefaultScheme = true;
            this.m_cmdPrintFeel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdPrintFeel.Hint = "";
            this.m_cmdPrintFeel.Location = new System.Drawing.Point(473, 3);
            this.m_cmdPrintFeel.Name = "m_cmdPrintFeel";
            this.m_cmdPrintFeel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdPrintFeel.Size = new System.Drawing.Size(82, 31);
            this.m_cmdPrintFeel.TabIndex = 31;
            this.m_cmdPrintFeel.Text = "打印预览";
            this.m_cmdPrintFeel.Click += new System.EventHandler(this.m_cmdPrintFeel_Click);
            // 
            // frmFeelCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 564);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frmFeelCard";
            this.Text = "打印皮试卡";
            this.Load += new System.EventHandler(this.frmFeelCard_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sybase.DataWindow.DataWindowControl dw_1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        internal PinkieControls.ButtonXP m_cmdPrintFeel;
        internal PinkieControls.ButtonXP buttonXP1;
    }
}