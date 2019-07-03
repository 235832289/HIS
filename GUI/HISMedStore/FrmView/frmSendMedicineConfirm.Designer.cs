namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmSendMedicineConfirm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSendMedicineConfirm));
            this.m_btnCancel = new PinkieControls.ButtonXP();
            this.m_txtSendMedID = new System.Windows.Forms.TextBox();
            this.m_txtDispenseID = new System.Windows.Forms.TextBox();
            this.m_btnConfirm = new PinkieControls.ButtonXP();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_txtServerNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.m_btnCancel.DefaultScheme = true;
            this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnCancel.Hint = "";
            this.m_btnCancel.Location = new System.Drawing.Point(148, 120);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnCancel.Size = new System.Drawing.Size(80, 28);
            this.m_btnCancel.TabIndex = 4;
            this.m_btnCancel.Text = "取消(&C)";
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // m_txtSendMedID
            // 
            this.m_txtSendMedID.Location = new System.Drawing.Point(116, 29);
            this.m_txtSendMedID.MaxLength = 4;
            this.m_txtSendMedID.Name = "m_txtSendMedID";
            this.m_txtSendMedID.Size = new System.Drawing.Size(120, 23);
            this.m_txtSendMedID.TabIndex = 1;
            this.toolTip1.SetToolTip(this.m_txtSendMedID, "请输入发药员工号！");
            this.m_txtSendMedID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtSendMedID_KeyDown);
            // 
            // m_txtDispenseID
            // 
            this.m_txtDispenseID.Enabled = false;
            this.m_txtDispenseID.Location = new System.Drawing.Point(99, 200);
            this.m_txtDispenseID.MaxLength = 2;
            this.m_txtDispenseID.Name = "m_txtDispenseID";
            this.m_txtDispenseID.Size = new System.Drawing.Size(120, 23);
            this.m_txtDispenseID.TabIndex = 0;
            this.toolTip1.SetToolTip(this.m_txtDispenseID, "请输入配药员的科室自编码！");
            this.m_txtDispenseID.Visible = false;
            this.m_txtDispenseID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtDispenseID_KeyDown);
            // 
            // m_btnConfirm
            // 
            this.m_btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.m_btnConfirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.m_btnConfirm.DefaultScheme = true;
            this.m_btnConfirm.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnConfirm.Hint = "";
            this.m_btnConfirm.Location = new System.Drawing.Point(53, 120);
            this.m_btnConfirm.Name = "m_btnConfirm";
            this.m_btnConfirm.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnConfirm.Size = new System.Drawing.Size(80, 28);
            this.m_btnConfirm.TabIndex = 3;
            this.m_btnConfirm.Text = "确定(&D)";
            this.m_btnConfirm.Click += new System.EventHandler(this.m_btnConfirm_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DimGray;
            this.groupBox1.Controls.Add(this.m_txtServerNo);
            this.groupBox1.Controls.Add(this.m_txtDispenseID);
            this.groupBox1.Controls.Add(this.m_txtSendMedID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.m_btnCancel);
            this.groupBox1.Controls.Add(this.m_btnConfirm);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 170);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // m_txtServerNo
            // 
            this.m_txtServerNo.Location = new System.Drawing.Point(116, 72);
            this.m_txtServerNo.MaxLength = 4;
            this.m_txtServerNo.Name = "m_txtServerNo";
            this.m_txtServerNo.Size = new System.Drawing.Size(120, 23);
            this.m_txtServerNo.TabIndex = 2;
            this.toolTip1.SetToolTip(this.m_txtServerNo, "请输入病人的流水号！");
            this.m_txtServerNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtServerNo_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Snow;
            this.label3.Location = new System.Drawing.Point(41, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "流水号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Snow;
            this.label2.Location = new System.Drawing.Point(41, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "发药员：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Snow;
            this.label1.Location = new System.Drawing.Point(24, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "配药员：";
            this.label1.Visible = false;
            // 
            // frmSendMedicineConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 170);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSendMedicineConfirm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "发药确认窗口";
            this.Load += new System.EventHandler(this.frmSendMedicineConfirm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal PinkieControls.ButtonXP m_btnCancel;
        internal System.Windows.Forms.TextBox m_txtSendMedID;
        internal System.Windows.Forms.TextBox m_txtDispenseID;
        internal PinkieControls.ButtonXP m_btnConfirm;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.TextBox m_txtServerNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}