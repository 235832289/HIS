namespace com.digitalwave.iCare.gui.LIS
{
    partial class frmQCBatchConcentrationSet
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
            this.m_gpbHead = new System.Windows.Forms.GroupBox();
            this.m_txtCV = new System.Windows.Forms.TextBox();
            this.m_txtSD = new System.Windows.Forms.TextBox();
            this.m_txtX = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.m_cboConcentration = new com.digitalwave.iCare.gui.LIS.ctlConcentrationCombox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtDeviceSampleID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_lsvConcentration = new System.Windows.Forms.ListView();
            this.chConcentrationID = new System.Windows.Forms.ColumnHeader();
            this.chConcentrationName = new System.Windows.Forms.ColumnHeader();
            this.chDeviceSampleID = new System.Windows.Forms.ColumnHeader();
            this.chX = new System.Windows.Forms.ColumnHeader();
            this.chSD = new System.Windows.Forms.ColumnHeader();
            this.chCV = new System.Windows.Forms.ColumnHeader();
            this.chStatus = new System.Windows.Forms.ColumnHeader();
            this.m_pnlBottom = new System.Windows.Forms.Panel();
            this.m_cmdCancelDelete = new PinkieControls.ButtonXP();
            this.m_cmdReturn = new PinkieControls.ButtonXP();
            this.m_cmdSave = new PinkieControls.ButtonXP();
            this.m_cmdNew = new PinkieControls.ButtonXP();
            this.m_cmdDelete = new PinkieControls.ButtonXP();
            this.m_gpbHead.SuspendLayout();
            this.m_pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_gpbHead
            // 
            this.m_gpbHead.Controls.Add(this.m_txtCV);
            this.m_gpbHead.Controls.Add(this.m_txtSD);
            this.m_gpbHead.Controls.Add(this.m_txtX);
            this.m_gpbHead.Controls.Add(this.label14);
            this.m_gpbHead.Controls.Add(this.label13);
            this.m_gpbHead.Controls.Add(this.label12);
            this.m_gpbHead.Controls.Add(this.m_cboConcentration);
            this.m_gpbHead.Controls.Add(this.label3);
            this.m_gpbHead.Controls.Add(this.m_txtDeviceSampleID);
            this.m_gpbHead.Controls.Add(this.label2);
            this.m_gpbHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_gpbHead.Location = new System.Drawing.Point(0, 0);
            this.m_gpbHead.Name = "m_gpbHead";
            this.m_gpbHead.Size = new System.Drawing.Size(599, 114);
            this.m_gpbHead.TabIndex = 1;
            this.m_gpbHead.TabStop = false;
            this.m_gpbHead.Enter += new System.EventHandler(this.m_gpbHead_Enter);
            // 
            // m_txtCV
            // 
            this.m_txtCV.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.m_txtCV.Location = new System.Drawing.Point(448, 44);
            this.m_txtCV.MaxLength = 5;
            this.m_txtCV.Name = "m_txtCV";
            this.m_txtCV.Size = new System.Drawing.Size(120, 23);
            this.m_txtCV.TabIndex = 26;
            this.m_txtCV.Enter += new System.EventHandler(this.m_txtCV_Enter);
            // 
            // m_txtSD
            // 
            this.m_txtSD.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.m_txtSD.Location = new System.Drawing.Point(288, 68);
            this.m_txtSD.MaxLength = 8;
            this.m_txtSD.Name = "m_txtSD";
            this.m_txtSD.Size = new System.Drawing.Size(120, 23);
            this.m_txtSD.TabIndex = 25;
            // 
            // m_txtX
            // 
            this.m_txtX.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.m_txtX.Location = new System.Drawing.Point(288, 44);
            this.m_txtX.MaxLength = 10;
            this.m_txtX.Name = "m_txtX";
            this.m_txtX.Size = new System.Drawing.Size(120, 23);
            this.m_txtX.TabIndex = 24;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(418, 48);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 14);
            this.label14.TabIndex = 29;
            this.label14.Text = "CV：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(258, 72);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 14);
            this.label13.TabIndex = 28;
            this.label13.Text = "SD：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(244, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 14);
            this.label12.TabIndex = 27;
            this.label12.Text = "真值：";
            // 
            // m_cboConcentration
            // 
            this.m_cboConcentration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboConcentration.Enabled = false;
            this.m_cboConcentration.FormattingEnabled = true;
            this.m_cboConcentration.Location = new System.Drawing.Point(108, 44);
            this.m_cboConcentration.Name = "m_cboConcentration";
            this.m_cboConcentration.Size = new System.Drawing.Size(120, 22);
            this.m_cboConcentration.TabIndex = 1;
            this.m_cboConcentration.Value = -2147483648;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "浓度:";
            // 
            // m_txtDeviceSampleID
            // 
            this.m_txtDeviceSampleID.Enabled = false;
            this.m_txtDeviceSampleID.Location = new System.Drawing.Point(108, 68);
            this.m_txtDeviceSampleID.MaxLength = 25;
            this.m_txtDeviceSampleID.Name = "m_txtDeviceSampleID";
            this.m_txtDeviceSampleID.Size = new System.Drawing.Size(120, 23);
            this.m_txtDeviceSampleID.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "仪器标本号:";
            // 
            // m_lsvConcentration
            // 
            this.m_lsvConcentration.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chConcentrationID,
            this.chConcentrationName,
            this.chDeviceSampleID,
            this.chX,
            this.chSD,
            this.chCV,
            this.chStatus});
            this.m_lsvConcentration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvConcentration.FullRowSelect = true;
            this.m_lsvConcentration.GridLines = true;
            this.m_lsvConcentration.HideSelection = false;
            this.m_lsvConcentration.Location = new System.Drawing.Point(0, 114);
            this.m_lsvConcentration.MultiSelect = false;
            this.m_lsvConcentration.Name = "m_lsvConcentration";
            this.m_lsvConcentration.Size = new System.Drawing.Size(599, 169);
            this.m_lsvConcentration.TabIndex = 6;
            this.m_lsvConcentration.UseCompatibleStateImageBehavior = false;
            this.m_lsvConcentration.View = System.Windows.Forms.View.Details;
            this.m_lsvConcentration.SelectedIndexChanged += new System.EventHandler(this.m_lsvConcentration_SelectedIndexChanged);
            // 
            // chConcentrationID
            // 
            this.chConcentrationID.Text = "浓度ID";
            this.chConcentrationID.Width = 54;
            // 
            // chConcentrationName
            // 
            this.chConcentrationName.Text = "浓度";
            this.chConcentrationName.Width = 100;
            // 
            // chDeviceSampleID
            // 
            this.chDeviceSampleID.Text = "仪器标本号";
            this.chDeviceSampleID.Width = 120;
            // 
            // chX
            // 
            this.chX.Text = "真值";
            // 
            // chSD
            // 
            this.chSD.Text = "SD";
            this.chSD.Width = 72;
            // 
            // chCV
            // 
            this.chCV.Text = "CV";
            this.chCV.Width = 70;
            // 
            // chStatus
            // 
            this.chStatus.Text = "状态";
            // 
            // m_pnlBottom
            // 
            this.m_pnlBottom.Controls.Add(this.m_cmdCancelDelete);
            this.m_pnlBottom.Controls.Add(this.m_cmdReturn);
            this.m_pnlBottom.Controls.Add(this.m_cmdSave);
            this.m_pnlBottom.Controls.Add(this.m_cmdNew);
            this.m_pnlBottom.Controls.Add(this.m_cmdDelete);
            this.m_pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_pnlBottom.Location = new System.Drawing.Point(0, 283);
            this.m_pnlBottom.Name = "m_pnlBottom";
            this.m_pnlBottom.Size = new System.Drawing.Size(599, 85);
            this.m_pnlBottom.TabIndex = 7;
            // 
            // m_cmdCancelDelete
            // 
            this.m_cmdCancelDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdCancelDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdCancelDelete.DefaultScheme = true;
            this.m_cmdCancelDelete.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdCancelDelete.Enabled = false;
            this.m_cmdCancelDelete.Hint = "";
            this.m_cmdCancelDelete.Location = new System.Drawing.Point(36, 20);
            this.m_cmdCancelDelete.Name = "m_cmdCancelDelete";
            this.m_cmdCancelDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCancelDelete.Size = new System.Drawing.Size(100, 38);
            this.m_cmdCancelDelete.TabIndex = 16;
            this.m_cmdCancelDelete.Text = "取消删除";
            this.m_cmdCancelDelete.Click += new System.EventHandler(this.m_cmdCancelDelete_Click);
            // 
            // m_cmdReturn
            // 
            this.m_cmdReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdReturn.DefaultScheme = true;
            this.m_cmdReturn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdReturn.Hint = "";
            this.m_cmdReturn.Location = new System.Drawing.Point(472, 20);
            this.m_cmdReturn.Name = "m_cmdReturn";
            this.m_cmdReturn.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdReturn.Size = new System.Drawing.Size(100, 38);
            this.m_cmdReturn.TabIndex = 15;
            this.m_cmdReturn.Text = "返回";
            this.m_cmdReturn.Click += new System.EventHandler(this.m_cmdReturn_Click);
            // 
            // m_cmdSave
            // 
            this.m_cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdSave.DefaultScheme = true;
            this.m_cmdSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSave.Enabled = false;
            this.m_cmdSave.Hint = "";
            this.m_cmdSave.Location = new System.Drawing.Point(256, 20);
            this.m_cmdSave.Name = "m_cmdSave";
            this.m_cmdSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSave.Size = new System.Drawing.Size(100, 38);
            this.m_cmdSave.TabIndex = 12;
            this.m_cmdSave.Text = "保存";
            this.m_cmdSave.Click += new System.EventHandler(this.m_cmdSave_Click);
            // 
            // m_cmdNew
            // 
            this.m_cmdNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdNew.DefaultScheme = true;
            this.m_cmdNew.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdNew.Hint = "";
            this.m_cmdNew.Location = new System.Drawing.Point(147, 20);
            this.m_cmdNew.Name = "m_cmdNew";
            this.m_cmdNew.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdNew.Size = new System.Drawing.Size(100, 38);
            this.m_cmdNew.TabIndex = 11;
            this.m_cmdNew.Text = "新增";
            this.m_cmdNew.Click += new System.EventHandler(this.m_cmdNew_Click);
            // 
            // m_cmdDelete
            // 
            this.m_cmdDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdDelete.DefaultScheme = true;
            this.m_cmdDelete.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdDelete.Enabled = false;
            this.m_cmdDelete.Hint = "";
            this.m_cmdDelete.Location = new System.Drawing.Point(363, 20);
            this.m_cmdDelete.Name = "m_cmdDelete";
            this.m_cmdDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDelete.Size = new System.Drawing.Size(100, 38);
            this.m_cmdDelete.TabIndex = 14;
            this.m_cmdDelete.Text = "删除";
            this.m_cmdDelete.Click += new System.EventHandler(this.m_cmdDelete_Click);
            // 
            // frmQCBatchConcentrationSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 368);
            this.Controls.Add(this.m_lsvConcentration);
            this.Controls.Add(this.m_pnlBottom);
            this.Controls.Add(this.m_gpbHead);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.KeyPreview = true;
            this.Name = "frmQCBatchConcentrationSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "质控批浓度设置";
            this.Load += new System.EventHandler(this.frmQCBatchConcentrationSet_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmQCBatchConcentrationSet_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmReportQuery_KeyDown);
            this.m_gpbHead.ResumeLayout(false);
            this.m_gpbHead.PerformLayout();
            this.m_pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox m_gpbHead;
        private System.Windows.Forms.TextBox m_txtDeviceSampleID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView m_lsvConcentration;
        private System.Windows.Forms.Panel m_pnlBottom;
        private PinkieControls.ButtonXP m_cmdSave;
        private PinkieControls.ButtonXP m_cmdNew;
        private PinkieControls.ButtonXP m_cmdDelete;
        private System.Windows.Forms.ColumnHeader chConcentrationID;
        private System.Windows.Forms.ColumnHeader chConcentrationName;
        private System.Windows.Forms.ColumnHeader chDeviceSampleID;
        private ctlConcentrationCombox m_cboConcentration;
        private System.Windows.Forms.Label label3;
        private PinkieControls.ButtonXP m_cmdReturn;
        private System.Windows.Forms.ColumnHeader chX;
        private PinkieControls.ButtonXP m_cmdCancelDelete;
        private System.Windows.Forms.TextBox m_txtCV;
        private System.Windows.Forms.TextBox m_txtSD;
        private System.Windows.Forms.TextBox m_txtX;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ColumnHeader chSD;
        private System.Windows.Forms.ColumnHeader chCV;
        private System.Windows.Forms.ColumnHeader chStatus;

    }
}