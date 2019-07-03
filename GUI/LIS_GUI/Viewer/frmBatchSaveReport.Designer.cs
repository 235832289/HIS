namespace com.digitalwave.iCare.gui.LIS
{
    partial class frmBatchSaveReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBatchSaveReport));
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_btnSave = new PinkieControls.ButtonXP();
            this.m_btnSure = new PinkieControls.ButtonXP();
            this.m_txtCheckNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtBarcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_dgAppList = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheckNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colpatientname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheckContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApplicationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgAppList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_btnSave);
            this.panel1.Controls.Add(this.m_btnSure);
            this.panel1.Controls.Add(this.m_txtCheckNo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.m_txtBarcode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(226, 535);
            this.panel1.TabIndex = 0;
            // 
            // m_btnSave
            // 
            this.m_btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))));
            this.m_btnSave.DefaultScheme = true;
            this.m_btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnSave.Hint = "";
            this.m_btnSave.Location = new System.Drawing.Point(116, 140);
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnSave.Size = new System.Drawing.Size(92, 31);
            this.m_btnSave.TabIndex = 102;
            this.m_btnSave.Text = "保存(F1)";
            this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
            // 
            // m_btnSure
            // 
            this.m_btnSure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))));
            this.m_btnSure.DefaultScheme = true;
            this.m_btnSure.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnSure.Hint = "";
            this.m_btnSure.Location = new System.Drawing.Point(10, 140);
            this.m_btnSure.Name = "m_btnSure";
            this.m_btnSure.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnSure.Size = new System.Drawing.Size(92, 31);
            this.m_btnSure.TabIndex = 101;
            this.m_btnSure.Text = "确定(F2)";
            this.m_btnSure.Click += new System.EventHandler(this.m_btnSure_Click);
            // 
            // m_txtCheckNo
            // 
            this.m_txtCheckNo.Location = new System.Drawing.Point(76, 72);
            this.m_txtCheckNo.Name = "m_txtCheckNo";
            this.m_txtCheckNo.Size = new System.Drawing.Size(132, 23);
            this.m_txtCheckNo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "检验编号";
            // 
            // m_txtBarcode
            // 
            this.m_txtBarcode.Location = new System.Drawing.Point(78, 27);
            this.m_txtBarcode.Name = "m_txtBarcode";
            this.m_txtBarcode.Size = new System.Drawing.Size(132, 23);
            this.m_txtBarcode.TabIndex = 1;
            this.m_txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtBarcode_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "条码号";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_dgAppList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(226, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(715, 535);
            this.panel2.TabIndex = 1;
            // 
            // m_dgAppList
            // 
            this.m_dgAppList.AllowUserToAddRows = false;
            this.m_dgAppList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.m_dgAppList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.m_dgAppList.BackgroundColor = System.Drawing.Color.White;
            this.m_dgAppList.ColumnHeadersHeight = 24;
            this.m_dgAppList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheckNum,
            this.colpatientname,
            this.colCheckContent,
            this.colApplicationID});
            this.m_dgAppList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgAppList.Location = new System.Drawing.Point(0, 0);
            this.m_dgAppList.MultiSelect = false;
            this.m_dgAppList.Name = "m_dgAppList";
            this.m_dgAppList.ReadOnly = true;
            this.m_dgAppList.RowHeadersVisible = false;
            this.m_dgAppList.RowTemplate.Height = 23;
            this.m_dgAppList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgAppList.Size = new System.Drawing.Size(715, 535);
            this.m_dgAppList.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "检验编号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "病人姓名";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 120;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "检验内容";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 300;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "申请单ID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // colCheckNum
            // 
            this.colCheckNum.HeaderText = "检验编号";
            this.colCheckNum.Name = "colCheckNum";
            this.colCheckNum.ReadOnly = true;
            this.colCheckNum.Width = 120;
            // 
            // colpatientname
            // 
            this.colpatientname.HeaderText = "病人姓名";
            this.colpatientname.Name = "colpatientname";
            this.colpatientname.ReadOnly = true;
            this.colpatientname.Width = 120;
            // 
            // colCheckContent
            // 
            this.colCheckContent.HeaderText = "检验内容";
            this.colCheckContent.Name = "colCheckContent";
            this.colCheckContent.ReadOnly = true;
            this.colCheckContent.Width = 300;
            // 
            // colApplicationID
            // 
            this.colApplicationID.HeaderText = "申请单ID";
            this.colApplicationID.Name = "colApplicationID";
            this.colApplicationID.ReadOnly = true;
            this.colApplicationID.Visible = false;
            // 
            // frmBatchSaveReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 535);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBatchSaveReport";
            this.Text = "统一保存";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgAppList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        internal PinkieControls.ButtonXP m_btnSave;
        internal PinkieControls.ButtonXP m_btnSure;
        internal System.Windows.Forms.TextBox m_txtBarcode;
        internal System.Windows.Forms.TextBox m_txtCheckNo;
        internal System.Windows.Forms.DataGridView m_dgAppList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheckNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colpatientname;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheckContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApplicationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}