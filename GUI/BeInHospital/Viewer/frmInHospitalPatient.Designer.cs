namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmInHospitalPatient
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
            this.m_lsvPatientInfo = new System.Windows.Forms.ListView();
            this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader20 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader19 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader44 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader18 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.m_cmdCancle = new PinkieControls.ButtonXP();
            this.SuspendLayout();
            // 
            // m_lsvPatientInfo
            // 
            this.m_lsvPatientInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader15,
            this.columnHeader20,
            this.columnHeader17,
            this.columnHeader16,
            this.columnHeader19,
            this.columnHeader44,
            this.columnHeader18,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.m_lsvPatientInfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvPatientInfo.FullRowSelect = true;
            this.m_lsvPatientInfo.GridLines = true;
            this.m_lsvPatientInfo.HideSelection = false;
            this.m_lsvPatientInfo.Location = new System.Drawing.Point(8, 8);
            this.m_lsvPatientInfo.MultiSelect = false;
            this.m_lsvPatientInfo.Name = "m_lsvPatientInfo";
            this.m_lsvPatientInfo.Size = new System.Drawing.Size(885, 299);
            this.m_lsvPatientInfo.TabIndex = 1;
            this.m_lsvPatientInfo.UseCompatibleStateImageBehavior = false;
            this.m_lsvPatientInfo.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "住院号";
            this.columnHeader15.Width = 83;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "病人姓名";
            this.columnHeader20.Width = 76;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "性别";
            this.columnHeader17.Width = 49;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "年龄";
            this.columnHeader16.Width = 56;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "病情";
            this.columnHeader19.Width = 51;
            // 
            // columnHeader44
            // 
            this.columnHeader44.Text = "入院诊断";
            this.columnHeader44.Width = 102;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "入院日期";
            this.columnHeader18.Width = 146;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "次数";
            this.columnHeader1.Width = 46;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "状态";
            this.columnHeader2.Width = 76;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "联系电话";
            this.columnHeader3.Width = 86;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "家庭地址";
            this.columnHeader4.Width = 88;
            // 
            // m_cmdCancle
            // 
            this.m_cmdCancle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdCancle.DefaultScheme = true;
            this.m_cmdCancle.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdCancle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdCancle.Hint = "";
            this.m_cmdCancle.Location = new System.Drawing.Point(772, 313);
            this.m_cmdCancle.Name = "m_cmdCancle";
            this.m_cmdCancle.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCancle.Size = new System.Drawing.Size(96, 32);
            this.m_cmdCancle.TabIndex = 3;
            this.m_cmdCancle.Text = "取消(&Esc)";
            this.m_cmdCancle.Click += new System.EventHandler(this.m_cmdCancle_Click);
            // 
            // frmInHospitalPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 357);
            this.Controls.Add(this.m_cmdCancle);
            this.Controls.Add(this.m_lsvPatientInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmInHospitalPatient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "同名在院病人";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmInHospitalPatient_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ListView m_lsvPatientInfo;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader44;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        internal PinkieControls.ButtonXP m_cmdCancle;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}