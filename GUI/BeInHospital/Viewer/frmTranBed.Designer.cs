namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmTranBed
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_cmdCancel = new PinkieControls.ButtonXP();
            this.m_cmdOk = new PinkieControls.ButtonXP();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_cmbBed = new System.Windows.Forms.ComboBox();
            this.m_lbSouBed = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.m_lbSex = new System.Windows.Forms.Label();
            this.m_lbName = new System.Windows.Forms.Label();
            this.m_lbInpatientId = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_cmdCancel);
            this.panel1.Controls.Add(this.m_cmdOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 205);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(273, 52);
            this.panel1.TabIndex = 0;
            // 
            // m_cmdCancel
            // 
            this.m_cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdCancel.DefaultScheme = true;
            this.m_cmdCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdCancel.Hint = "";
            this.m_cmdCancel.Location = new System.Drawing.Point(139, 12);
            this.m_cmdCancel.Name = "m_cmdCancel";
            this.m_cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCancel.Size = new System.Drawing.Size(73, 28);
            this.m_cmdCancel.TabIndex = 6;
            this.m_cmdCancel.Text = "取消(&C)";
            this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
            // 
            // m_cmdOk
            // 
            this.m_cmdOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdOk.DefaultScheme = true;
            this.m_cmdOk.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdOk.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdOk.Hint = "";
            this.m_cmdOk.Location = new System.Drawing.Point(44, 11);
            this.m_cmdOk.Name = "m_cmdOk";
            this.m_cmdOk.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdOk.Size = new System.Drawing.Size(73, 28);
            this.m_cmdOk.TabIndex = 5;
            this.m_cmdOk.Text = "确定(&O)";
            this.m_cmdOk.Click += new System.EventHandler(this.m_cmdOk_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_cmbBed);
            this.panel2.Controls.Add(this.m_lbSouBed);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.m_lbSex);
            this.panel2.Controls.Add(this.m_lbName);
            this.panel2.Controls.Add(this.m_lbInpatientId);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 205);
            this.panel2.TabIndex = 1;
            // 
            // m_cmbBed
            // 
            this.m_cmbBed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbBed.FormattingEnabled = true;
            this.m_cmbBed.Location = new System.Drawing.Point(85, 143);
            this.m_cmbBed.Name = "m_cmbBed";
            this.m_cmbBed.Size = new System.Drawing.Size(152, 22);
            this.m_cmbBed.TabIndex = 9;
            // 
            // m_lbSouBed
            // 
            this.m_lbSouBed.BackColor = System.Drawing.SystemColors.Info;
            this.m_lbSouBed.Location = new System.Drawing.Point(83, 113);
            this.m_lbSouBed.Name = "m_lbSouBed";
            this.m_lbSouBed.Size = new System.Drawing.Size(153, 19);
            this.m_lbSouBed.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 146);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 14);
            this.label8.TabIndex = 7;
            this.label8.Text = "新床号：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 6;
            this.label7.Text = "原床号：";
            // 
            // m_lbSex
            // 
            this.m_lbSex.BackColor = System.Drawing.SystemColors.Info;
            this.m_lbSex.Location = new System.Drawing.Point(83, 83);
            this.m_lbSex.Name = "m_lbSex";
            this.m_lbSex.Size = new System.Drawing.Size(153, 19);
            this.m_lbSex.TabIndex = 5;
            // 
            // m_lbName
            // 
            this.m_lbName.BackColor = System.Drawing.SystemColors.Info;
            this.m_lbName.Location = new System.Drawing.Point(83, 50);
            this.m_lbName.Name = "m_lbName";
            this.m_lbName.Size = new System.Drawing.Size(153, 19);
            this.m_lbName.TabIndex = 4;
            // 
            // m_lbInpatientId
            // 
            this.m_lbInpatientId.BackColor = System.Drawing.SystemColors.Info;
            this.m_lbInpatientId.Location = new System.Drawing.Point(83, 15);
            this.m_lbInpatientId.Name = "m_lbInpatientId";
            this.m_lbInpatientId.Size = new System.Drawing.Size(153, 19);
            this.m_lbInpatientId.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "住院号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "性  别：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓  名：";
            // 
            // frmTranBed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 257);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTranBed";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "转床";
            this.Load += new System.EventHandler(this.frmTranBed_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label m_lbInpatientId;
        internal System.Windows.Forms.Label m_lbName;
        internal System.Windows.Forms.Label m_lbSex;
        internal System.Windows.Forms.Label m_lbSouBed;
        internal System.Windows.Forms.ComboBox m_cmbBed;
        private PinkieControls.ButtonXP m_cmdCancel;
        private PinkieControls.ButtonXP m_cmdOk;
    }
}