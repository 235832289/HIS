namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmLeftCallBack
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
            this.m_ucPatientInfo = new com.digitalwave.iCare.gui.HIS.ucPatientInfo();
            this.m_cmdRecall = new PinkieControls.ButtonXP();
            this.m_cmdCancel = new PinkieControls.ButtonXP();
            this.m_cmdFind = new PinkieControls.ButtonXP();
            this.SuspendLayout();
            // 
            // m_ucPatientInfo
            // 
            this.m_ucPatientInfo.BackColor = System.Drawing.SystemColors.Control;
            this.m_ucPatientInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_ucPatientInfo.IsChanged = false;
            this.m_ucPatientInfo.Location = new System.Drawing.Point(0, 0);
            this.m_ucPatientInfo.Name = "m_ucPatientInfo";
            this.m_ucPatientInfo.Size = new System.Drawing.Size(254, 663);
            this.m_ucPatientInfo.Status = 0;
            this.m_ucPatientInfo.TabIndex = 0;
            this.m_ucPatientInfo.ZyhChanged += new com.digitalwave.iCare.gui.HIS.TextZyhChanged(this.m_ucPatientInfo_ZyhChanged);
            // 
            // m_cmdRecall
            // 
            this.m_cmdRecall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdRecall.DefaultScheme = true;
            this.m_cmdRecall.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdRecall.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdRecall.Hint = "";
            this.m_cmdRecall.Location = new System.Drawing.Point(453, 597);
            this.m_cmdRecall.Name = "m_cmdRecall";
            this.m_cmdRecall.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdRecall.Size = new System.Drawing.Size(96, 31);
            this.m_cmdRecall.TabIndex = 42;
            this.m_cmdRecall.Text = "召回(&R)";
            this.m_cmdRecall.Click += new System.EventHandler(this.m_cmdRecall_Click);
            // 
            // m_cmdCancel
            // 
            this.m_cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdCancel.DefaultScheme = true;
            this.m_cmdCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdCancel.Hint = "";
            this.m_cmdCancel.Location = new System.Drawing.Point(657, 597);
            this.m_cmdCancel.Name = "m_cmdCancel";
            this.m_cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCancel.Size = new System.Drawing.Size(96, 31);
            this.m_cmdCancel.TabIndex = 41;
            this.m_cmdCancel.Text = "关闭(Esc)";
            this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
            // 
            // m_cmdFind
            // 
            this.m_cmdFind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdFind.DefaultScheme = true;
            this.m_cmdFind.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdFind.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdFind.Hint = "";
            this.m_cmdFind.Location = new System.Drawing.Point(555, 597);
            this.m_cmdFind.Name = "m_cmdFind";
            this.m_cmdFind.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdFind.Size = new System.Drawing.Size(96, 31);
            this.m_cmdFind.TabIndex = 43;
            this.m_cmdFind.Text = "查找(&F)";
            this.m_cmdFind.Click += new System.EventHandler(this.m_cmdFind_Click);
            // 
            // frmLeftCallBack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 663);
            this.Controls.Add(this.m_cmdFind);
            this.Controls.Add(this.m_cmdRecall);
            this.Controls.Add(this.m_cmdCancel);
            this.Controls.Add(this.m_ucPatientInfo);
            this.KeyPreview = true;
            this.Name = "frmLeftCallBack";
            this.Text = "出院召回";
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.frmLeftCallBack_Layout);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLeftCallBack_KeyDown);
            this.Load += new System.EventHandler(this.frmLeftCallBack_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private PinkieControls.ButtonXP m_cmdCancel;
        internal PinkieControls.ButtonXP m_cmdRecall;
        internal PinkieControls.ButtonXP m_cmdFind;
        internal ucPatientInfo m_ucPatientInfo;

    }
}