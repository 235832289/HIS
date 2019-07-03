namespace com.digitalwave.iCare.BIHOrder
{
    partial class frmORDERDESC
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.m_plButtons = new System.Windows.Forms.Panel();
            this.m_btnSave = new PinkieControls.ButtonXP();
            this.m_dgvORDERDESC = new com.digitalwave.iCare.BIHOrder.frmORDERDESC.MyDataGridView();
            this.m_colDESCID_INT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_colDESC_VCHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_colUSERCODE_VCHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_colWBCODE_VCHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_colPYCODE_CHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_plButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvORDERDESC)).BeginInit();
            this.SuspendLayout();
            // 
            // m_plButtons
            // 
            this.m_plButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_plButtons.Controls.Add(this.m_btnSave);
            this.m_plButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_plButtons.Location = new System.Drawing.Point(0, 504);
            this.m_plButtons.Name = "m_plButtons";
            this.m_plButtons.Size = new System.Drawing.Size(716, 44);
            this.m_plButtons.TabIndex = 1;
            // 
            // m_btnSave
            // 
            this.m_btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnSave.DefaultScheme = true;
            this.m_btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnSave.Hint = "";
            this.m_btnSave.Location = new System.Drawing.Point(299, 4);
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnSave.Size = new System.Drawing.Size(121, 33);
            this.m_btnSave.TabIndex = 44;
            this.m_btnSave.Text = "保存 ";
            this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
            // 
            // m_dgvORDERDESC
            // 
            this.m_dgvORDERDESC.AllowUserToAddRows = false;
            this.m_dgvORDERDESC.BackgroundColor = System.Drawing.Color.White;
            this.m_dgvORDERDESC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvORDERDESC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_colDESCID_INT,
            this.m_colDESC_VCHR,
            this.m_colUSERCODE_VCHR,
            this.m_colWBCODE_VCHR,
            this.m_colPYCODE_CHR});
            this.m_dgvORDERDESC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvORDERDESC.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.m_dgvORDERDESC.Location = new System.Drawing.Point(0, 0);
            this.m_dgvORDERDESC.MultiSelect = false;
            this.m_dgvORDERDESC.Name = "m_dgvORDERDESC";
            this.m_dgvORDERDESC.ReadOnly = true;
            this.m_dgvORDERDESC.RowHeadersVisible = false;
            this.m_dgvORDERDESC.RowTemplate.Height = 23;
            this.m_dgvORDERDESC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvORDERDESC.Size = new System.Drawing.Size(716, 504);
            this.m_dgvORDERDESC.TabIndex = 0;
            this.m_dgvORDERDESC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_dgvORDERDESC_KeyDown);
            this.m_dgvORDERDESC.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvORDERDESC_CellDoubleClick);
            this.m_dgvORDERDESC.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvORDERDESC_CellEndEdit);
            // 
            // m_colDESCID_INT
            // 
            this.m_colDESCID_INT.DataPropertyName = "DESCID_INT";
            this.m_colDESCID_INT.HeaderText = "嘱托ID";
            this.m_colDESCID_INT.Name = "m_colDESCID_INT";
            this.m_colDESCID_INT.ReadOnly = true;
            this.m_colDESCID_INT.Visible = false;
            // 
            // m_colDESC_VCHR
            // 
            this.m_colDESC_VCHR.DataPropertyName = "DESC_VCHR";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.m_colDESC_VCHR.DefaultCellStyle = dataGridViewCellStyle1;
            this.m_colDESC_VCHR.HeaderText = "嘱托内容";
            this.m_colDESC_VCHR.Name = "m_colDESC_VCHR";
            this.m_colDESC_VCHR.ReadOnly = true;
            this.m_colDESC_VCHR.Width = 400;
            // 
            // m_colUSERCODE_VCHR
            // 
            this.m_colUSERCODE_VCHR.DataPropertyName = "USERCODE_VCHR";
            this.m_colUSERCODE_VCHR.HeaderText = "助记码";
            this.m_colUSERCODE_VCHR.Name = "m_colUSERCODE_VCHR";
            this.m_colUSERCODE_VCHR.ReadOnly = true;
            // 
            // m_colWBCODE_VCHR
            // 
            this.m_colWBCODE_VCHR.DataPropertyName = "WBCODE_VCHR";
            this.m_colWBCODE_VCHR.HeaderText = "五笔码";
            this.m_colWBCODE_VCHR.Name = "m_colWBCODE_VCHR";
            this.m_colWBCODE_VCHR.ReadOnly = true;
            // 
            // m_colPYCODE_CHR
            // 
            this.m_colPYCODE_CHR.DataPropertyName = "PYCODE_CHR";
            this.m_colPYCODE_CHR.HeaderText = "拼音码";
            this.m_colPYCODE_CHR.Name = "m_colPYCODE_CHR";
            this.m_colPYCODE_CHR.ReadOnly = true;
            // 
            // frmORDERDESC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 548);
            this.Controls.Add(this.m_dgvORDERDESC);
            this.Controls.Add(this.m_plButtons);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KeyPreview = true;
            this.Name = "frmORDERDESC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "医嘱嘱托字典";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmORDERDESC_KeyDown);
            this.Load += new System.EventHandler(this.frmORDERDESC_Load);
            this.m_plButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvORDERDESC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public MyDataGridView m_dgvORDERDESC;
        internal System.Windows.Forms.Panel m_plButtons;
        internal PinkieControls.ButtonXP m_btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_colDESCID_INT;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_colDESC_VCHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_colUSERCODE_VCHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_colWBCODE_VCHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_colPYCODE_CHR;

    }
}