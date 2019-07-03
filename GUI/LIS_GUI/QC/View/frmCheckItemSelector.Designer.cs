namespace com.digitalwave.iCare.gui.LIS
{
    partial class frmCheckItemSelector
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
            this.components = new System.ComponentModel.Container();
            this.m_trvCheckItem = new com.digitalwave.iCare.gui.LIS.ctlCheckItemTree();
            this.m_pnlBottom = new System.Windows.Forms.Panel();
            this.m_cmdConfirm = new PinkieControls.ButtonXP();
            this.m_cmdCancel = new PinkieControls.ButtonXP();
            this.m_pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_trvCheckItem
            // 
            this.m_trvCheckItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_trvCheckItem.ImageIndex = 0;
            this.m_trvCheckItem.Location = new System.Drawing.Point(0, 0);
            this.m_trvCheckItem.Name = "m_trvCheckItem";
            this.m_trvCheckItem.SelectedImageIndex = 0;
            this.m_trvCheckItem.Size = new System.Drawing.Size(509, 400);
            this.m_trvCheckItem.TabIndex = 0;
            this.m_trvCheckItem.DoubleClick += new System.EventHandler(this.m_trvCheckItem_DoubleClick);
            // 
            // m_pnlBottom
            // 
            this.m_pnlBottom.Controls.Add(this.m_cmdConfirm);
            this.m_pnlBottom.Controls.Add(this.m_cmdCancel);
            this.m_pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_pnlBottom.Location = new System.Drawing.Point(0, 400);
            this.m_pnlBottom.Name = "m_pnlBottom";
            this.m_pnlBottom.Size = new System.Drawing.Size(509, 72);
            this.m_pnlBottom.TabIndex = 1;
            // 
            // m_cmdConfirm
            // 
            this.m_cmdConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdConfirm.DefaultScheme = true;
            this.m_cmdConfirm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdConfirm.Hint = "";
            this.m_cmdConfirm.Location = new System.Drawing.Point(276, 20);
            this.m_cmdConfirm.Name = "m_cmdConfirm";
            this.m_cmdConfirm.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdConfirm.Size = new System.Drawing.Size(98, 33);
            this.m_cmdConfirm.TabIndex = 19;
            this.m_cmdConfirm.Text = "确定";
            this.m_cmdConfirm.Click += new System.EventHandler(this.m_cmdConfirm_Click);
            // 
            // m_cmdCancel
            // 
            this.m_cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdCancel.DefaultScheme = true;
            this.m_cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdCancel.Hint = "";
            this.m_cmdCancel.Location = new System.Drawing.Point(388, 20);
            this.m_cmdCancel.Name = "m_cmdCancel";
            this.m_cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCancel.Size = new System.Drawing.Size(98, 33);
            this.m_cmdCancel.TabIndex = 20;
            this.m_cmdCancel.Text = "取消(ESC)";
            this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
            // 
            // frmCheckItemSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 472);
            this.Controls.Add(this.m_trvCheckItem);
            this.Controls.Add(this.m_pnlBottom);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.KeyPreview = true;
            this.Name = "frmCheckItemSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "项目选择";
            this.Load += new System.EventHandler(this.frmCheckItemSelector_Load);
            this.m_pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ctlCheckItemTree m_trvCheckItem;
        private System.Windows.Forms.Panel m_pnlBottom;
        private PinkieControls.ButtonXP m_cmdConfirm;
        private PinkieControls.ButtonXP m_cmdCancel;
    }
}