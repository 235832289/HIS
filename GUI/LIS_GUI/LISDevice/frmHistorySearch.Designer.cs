namespace com.digitalwave.iCare.gui.LIS
{
    partial class frmHistorySearch
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_lstBoxBoardNo = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_cmdSubmit = new PinkieControls.ButtonXP();
            this.label2 = new System.Windows.Forms.Label();
            this.m_dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.m_dtpBeginTime = new System.Windows.Forms.DateTimePicker();
            this.m_cmdClose = new PinkieControls.ButtonXP();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.groupBox1.Controls.Add(this.m_lstBoxBoardNo);
            this.groupBox1.Location = new System.Drawing.Point(3, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(555, 290);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "微孔板编号";
            // 
            // m_lstBoxBoardNo
            // 
            this.m_lstBoxBoardNo.FormattingEnabled = true;
            this.m_lstBoxBoardNo.ItemHeight = 14;
            this.m_lstBoxBoardNo.Location = new System.Drawing.Point(24, 25);
            this.m_lstBoxBoardNo.Name = "m_lstBoxBoardNo";
            this.m_lstBoxBoardNo.Size = new System.Drawing.Size(511, 242);
            this.m_lstBoxBoardNo.TabIndex = 1;
            this.m_lstBoxBoardNo.DoubleClick += new System.EventHandler(this.m_lstBoxBoardNo_DoubleClick);
            this.m_lstBoxBoardNo.SelectedIndexChanged += new System.EventHandler(this.m_lstBoxBoardNo_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.groupBox2.Controls.Add(this.m_cmdClose);
            this.groupBox2.Controls.Add(this.m_cmdSubmit);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.m_dtpEndTime);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.m_dtpBeginTime);
            this.groupBox2.Location = new System.Drawing.Point(43, 304);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(446, 99);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            // 
            // m_cmdSubmit
            // 
            this.m_cmdSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdSubmit.DefaultScheme = true;
            this.m_cmdSubmit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSubmit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdSubmit.Hint = "";
            this.m_cmdSubmit.Location = new System.Drawing.Point(116, 60);
            this.m_cmdSubmit.Name = "m_cmdSubmit";
            this.m_cmdSubmit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSubmit.Size = new System.Drawing.Size(83, 30);
            this.m_cmdSubmit.TabIndex = 34;
            this.m_cmdSubmit.Text = "查找";
            this.m_cmdSubmit.Click += new System.EventHandler(this.m_cmdSubmit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 33;
            this.label2.Text = "到";
            // 
            // m_dtpEndTime
            // 
            this.m_dtpEndTime.Location = new System.Drawing.Point(264, 22);
            this.m_dtpEndTime.Name = "m_dtpEndTime";
            this.m_dtpEndTime.Size = new System.Drawing.Size(126, 23);
            this.m_dtpEndTime.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 14);
            this.label1.TabIndex = 31;
            this.label1.Text = "从";
            // 
            // m_dtpBeginTime
            // 
            this.m_dtpBeginTime.Location = new System.Drawing.Point(102, 22);
            this.m_dtpBeginTime.Name = "m_dtpBeginTime";
            this.m_dtpBeginTime.Size = new System.Drawing.Size(126, 23);
            this.m_dtpBeginTime.TabIndex = 30;
            // 
            // m_cmdClose
            // 
            this.m_cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdClose.DefaultScheme = true;
            this.m_cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdClose.Hint = "";
            this.m_cmdClose.Location = new System.Drawing.Point(237, 60);
            this.m_cmdClose.Name = "m_cmdClose";
            this.m_cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClose.Size = new System.Drawing.Size(83, 30);
            this.m_cmdClose.TabIndex = 35;
            this.m_cmdClose.Text = "关闭";
            // 
            // frmHistorySearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(577, 415);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Name = "frmHistorySearch";
            this.Text = "历史查询";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox m_lstBoxBoardNo;
        private System.Windows.Forms.GroupBox groupBox2;
        internal PinkieControls.ButtonXP m_cmdSubmit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker m_dtpEndTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker m_dtpBeginTime;
        internal PinkieControls.ButtonXP m_cmdClose;
    }
}