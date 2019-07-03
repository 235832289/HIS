namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmRecipeTypeWarning
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecipeTypeWarning));
            this.m_dgvPatient = new System.Windows.Forms.DataGridView();
            this.serno_chr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecipeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvPatient)).BeginInit();
            this.SuspendLayout();
            // 
            // m_dgvPatient
            // 
            this.m_dgvPatient.AllowUserToAddRows = false;
            this.m_dgvPatient.BackgroundColor = System.Drawing.Color.White;
            this.m_dgvPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvPatient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.serno_chr,
            this.PatientName,
            this.RecipeType});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.m_dgvPatient.DefaultCellStyle = dataGridViewCellStyle4;
            this.m_dgvPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvPatient.Location = new System.Drawing.Point(0, 0);
            this.m_dgvPatient.Name = "m_dgvPatient";
            this.m_dgvPatient.ReadOnly = true;
            this.m_dgvPatient.RowHeadersVisible = false;
            this.m_dgvPatient.RowTemplate.Height = 23;
            this.m_dgvPatient.Size = new System.Drawing.Size(199, 385);
            this.m_dgvPatient.TabIndex = 0;
            // 
            // serno_chr
            // 
            this.serno_chr.DataPropertyName = "serno_chr";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.serno_chr.DefaultCellStyle = dataGridViewCellStyle1;
            this.serno_chr.Frozen = true;
            this.serno_chr.HeaderText = "流水号";
            this.serno_chr.MinimumWidth = 60;
            this.serno_chr.Name = "serno_chr";
            this.serno_chr.ReadOnly = true;
            this.serno_chr.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.serno_chr.Width = 74;
            // 
            // PatientName
            // 
            this.PatientName.DataPropertyName = "PATIENTNAME";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DimGray;
            this.PatientName.DefaultCellStyle = dataGridViewCellStyle2;
            this.PatientName.Frozen = true;
            this.PatientName.HeaderText = "姓名";
            this.PatientName.Name = "PatientName";
            this.PatientName.ReadOnly = true;
            this.PatientName.Width = 60;
            // 
            // RecipeType
            // 
            this.RecipeType.DataPropertyName = "typename_vchr";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.RecipeType.DefaultCellStyle = dataGridViewCellStyle3;
            this.RecipeType.HeaderText = "类型";
            this.RecipeType.Name = "RecipeType";
            this.RecipeType.ReadOnly = true;
            this.RecipeType.Width = 64;
            // 
            // frmRecipeTypeWarning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(199, 385);
            this.Controls.Add(this.m_dgvPatient);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRecipeTypeWarning";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "特殊处方提示";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRecipeTypeWarning_FormClosed);
            this.Load += new System.EventHandler(this.frmRecipeTypeWarning_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvPatient)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView m_dgvPatient;
        private System.Windows.Forms.DataGridViewTextBoxColumn serno_chr;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecipeType;
    }
}