namespace com.digitalwave.iCare.BIHOrder
{
    partial class frmFeelCardList
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
            this.cmdSearch = new PinkieControls.ButtonXP();
            this.cmdCancel = new PinkieControls.ButtonXP();
            this.m_txtArea = new com.digitalwave.controls.ctlFindTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonXP1 = new PinkieControls.ButtonXP();
            this.m_cmdPrintFeel = new PinkieControls.ButtonXP();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dw_1
            // 
            this.dw_1.DataWindowObject = "d_bih_feelList";
            this.dw_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dw_1.LibraryList = "D:\\icar_ver2\\Code\\bin\\Debug\\pb_new.pbl";
            this.dw_1.Location = new System.Drawing.Point(0, 0);
            this.dw_1.Name = "dw_1";
            this.dw_1.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dw_1.Size = new System.Drawing.Size(1016, 573);
            this.dw_1.TabIndex = 0;
            this.dw_1.Text = "dataWindowControl1";
            this.dw_1.Click += new System.EventHandler(this.dw_1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dw_1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 573);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cmdSearch);
            this.panel2.Controls.Add(this.cmdCancel);
            this.panel2.Controls.Add(this.m_txtArea);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.buttonXP1);
            this.panel2.Controls.Add(this.m_cmdPrintFeel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 573);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1016, 41);
            this.panel2.TabIndex = 2;
            // 
            // cmdSearch
            // 
            this.cmdSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdSearch.DefaultScheme = true;
            this.cmdSearch.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdSearch.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdSearch.Hint = "";
            this.cmdSearch.Location = new System.Drawing.Point(523, 3);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdSearch.Size = new System.Drawing.Size(77, 33);
            this.cmdSearch.TabIndex = 89;
            this.cmdSearch.Text = "查询(F4)";
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdCancel.DefaultScheme = true;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdCancel.Hint = "";
            this.cmdCancel.Location = new System.Drawing.Point(782, 3);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdCancel.Size = new System.Drawing.Size(77, 33);
            this.cmdCancel.TabIndex = 88;
            this.cmdCancel.Text = "退出(ESC)";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // m_txtArea
            // 
            this.m_txtArea.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtArea.Location = new System.Drawing.Point(104, 5);
            this.m_txtArea.Name = "m_txtArea";
            this.m_txtArea.Size = new System.Drawing.Size(120, 23);
            this.m_txtArea.TabIndex = 86;
            this.m_txtArea.m_evtFindItem += new com.digitalwave.controls.EventHandler_OnFindItem(this.m_txtArea_m_evtFindItem);
            this.m_txtArea.m_evtInitListView += new com.digitalwave.controls.EventHandler_InitListView(this.m_txtArea_m_evtInitListView);
            this.m_txtArea.m_evtSelectItem += new com.digitalwave.controls.EventHandler_OnSelectItem(this.m_txtArea_m_evtSelectItem);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(26, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 87;
            this.label1.Text = "开单病区";
            // 
            // buttonXP1
            // 
            this.buttonXP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP1.DefaultScheme = true;
            this.buttonXP1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP1.Hint = "";
            this.buttonXP1.Location = new System.Drawing.Point(694, 3);
            this.buttonXP1.Name = "buttonXP1";
            this.buttonXP1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP1.Size = new System.Drawing.Size(82, 33);
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
            this.m_cmdPrintFeel.Location = new System.Drawing.Point(606, 3);
            this.m_cmdPrintFeel.Name = "m_cmdPrintFeel";
            this.m_cmdPrintFeel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdPrintFeel.Size = new System.Drawing.Size(82, 33);
            this.m_cmdPrintFeel.TabIndex = 31;
            this.m_cmdPrintFeel.Text = "打印预览";
            this.m_cmdPrintFeel.Click += new System.EventHandler(this.m_cmdPrintFeel_Click);
            // 
            // frmFeelCardList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 614);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.KeyPreview = true;
            this.Name = "frmFeelCardList";
            this.Text = "病人皮试简明卡";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmFeelCardList_KeyDown);
            this.Load += new System.EventHandler(this.frmFeelCard_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Sybase.DataWindow.DataWindowControl dw_1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        internal PinkieControls.ButtonXP m_cmdPrintFeel;
        internal PinkieControls.ButtonXP buttonXP1;
        internal com.digitalwave.controls.ctlFindTextBox m_txtArea;
        private System.Windows.Forms.Label label1;
        private PinkieControls.ButtonXP cmdSearch;
        internal PinkieControls.ButtonXP cmdCancel;
    }
}