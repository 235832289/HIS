namespace com.digitalwave.iCare.BIHOrder
{
    partial class frmAreaPutMedList
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
            this.m_dtvAreaList = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dtvAreaCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dtvAreaName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dtvfinishtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dtvAreaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_cmdClearComfirm = new PinkieControls.ButtonXP();
            this.buttonXP2 = new PinkieControls.ButtonXP();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_cmdSetAreaComfirm = new PinkieControls.ButtonXP();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtvAreaList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_dtvAreaList
            // 
            this.m_dtvAreaList.AllowUserToAddRows = false;
            this.m_dtvAreaList.BackgroundColor = System.Drawing.Color.White;
            this.m_dtvAreaList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dtvAreaList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.m_dtvAreaCode,
            this.m_dtvAreaName,
            this.m_dtvfinishtime,
            this.m_dtvAreaId});
            this.m_dtvAreaList.Location = new System.Drawing.Point(14, 14);
            this.m_dtvAreaList.MultiSelect = false;
            this.m_dtvAreaList.Name = "m_dtvAreaList";
            this.m_dtvAreaList.ReadOnly = true;
            this.m_dtvAreaList.RowHeadersWidth = 5;
            this.m_dtvAreaList.RowTemplate.Height = 23;
            this.m_dtvAreaList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dtvAreaList.Size = new System.Drawing.Size(499, 278);
            this.m_dtvAreaList.TabIndex = 62;
            // 
            // No
            // 
            this.No.HeaderText = "序号";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Width = 60;
            // 
            // m_dtvAreaCode
            // 
            this.m_dtvAreaCode.HeaderText = "病区代码";
            this.m_dtvAreaCode.Name = "m_dtvAreaCode";
            this.m_dtvAreaCode.ReadOnly = true;
            this.m_dtvAreaCode.Width = 120;
            // 
            // m_dtvAreaName
            // 
            this.m_dtvAreaName.HeaderText = "病区名称";
            this.m_dtvAreaName.Name = "m_dtvAreaName";
            this.m_dtvAreaName.ReadOnly = true;
            this.m_dtvAreaName.Width = 150;
            // 
            // m_dtvfinishtime
            // 
            this.m_dtvfinishtime.HeaderText = "发送完成时间";
            this.m_dtvfinishtime.Name = "m_dtvfinishtime";
            this.m_dtvfinishtime.ReadOnly = true;
            this.m_dtvfinishtime.Width = 160;
            // 
            // m_dtvAreaId
            // 
            this.m_dtvAreaId.HeaderText = "m_dtvAreaId";
            this.m_dtvAreaId.Name = "m_dtvAreaId";
            this.m_dtvAreaId.ReadOnly = true;
            this.m_dtvAreaId.Visible = false;
            // 
            // m_cmdClearComfirm
            // 
            this.m_cmdClearComfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdClearComfirm.DefaultScheme = true;
            this.m_cmdClearComfirm.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdClearComfirm.Hint = "";
            this.m_cmdClearComfirm.Location = new System.Drawing.Point(6, 22);
            this.m_cmdClearComfirm.Name = "m_cmdClearComfirm";
            this.m_cmdClearComfirm.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClearComfirm.Size = new System.Drawing.Size(125, 32);
            this.m_cmdClearComfirm.TabIndex = 109;
            this.m_cmdClearComfirm.Text = "清除发送标志";
            this.m_cmdClearComfirm.Click += new System.EventHandler(this.m_cmdClearComfirm_Click);
            // 
            // buttonXP2
            // 
            this.buttonXP2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP2.DefaultScheme = true;
            this.buttonXP2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP2.Hint = "";
            this.buttonXP2.Location = new System.Drawing.Point(363, 22);
            this.buttonXP2.Name = "buttonXP2";
            this.buttonXP2.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP2.Size = new System.Drawing.Size(111, 32);
            this.buttonXP2.TabIndex = 108;
            this.buttonXP2.Text = "退  出(&Esc)";
            this.buttonXP2.Click += new System.EventHandler(this.buttonXP2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_cmdSetAreaComfirm);
            this.groupBox1.Controls.Add(this.m_cmdClearComfirm);
            this.groupBox1.Controls.Add(this.buttonXP2);
            this.groupBox1.Location = new System.Drawing.Point(14, 298);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(493, 66);
            this.groupBox1.TabIndex = 110;
            this.groupBox1.TabStop = false;
            // 
            // m_cmdSetAreaComfirm
            // 
            this.m_cmdSetAreaComfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdSetAreaComfirm.DefaultScheme = true;
            this.m_cmdSetAreaComfirm.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSetAreaComfirm.Hint = "";
            this.m_cmdSetAreaComfirm.Location = new System.Drawing.Point(154, 22);
            this.m_cmdSetAreaComfirm.Name = "m_cmdSetAreaComfirm";
            this.m_cmdSetAreaComfirm.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSetAreaComfirm.Size = new System.Drawing.Size(180, 32);
            this.m_cmdSetAreaComfirm.TabIndex = 110;
            this.m_cmdSetAreaComfirm.Text = "置全区发送完毕标志";
            this.m_cmdSetAreaComfirm.Click += new System.EventHandler(this.m_cmdSetAreaComfirm_Click);
            // 
            // frmAreaPutMedList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 379);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_dtvAreaList);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAreaPutMedList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "摆药申请单发送状态查询";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAreaPutMedList_KeyDown);
            this.Load += new System.EventHandler(this.frmAreaPutMedList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_dtvAreaList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal PinkieControls.ButtonXP m_cmdClearComfirm;
        internal PinkieControls.ButtonXP buttonXP2;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.DataGridView m_dtvAreaList;
        internal PinkieControls.ButtonXP m_cmdSetAreaComfirm;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dtvAreaCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dtvAreaName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dtvfinishtime;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dtvAreaId;
    }
}