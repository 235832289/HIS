namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmYB_F2DownLoad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmYB_F2DownLoad));
            this.btnCancel = new PinkieControls.ButtonXP();
            this.btnOk = new PinkieControls.ButtonXP();
            this.rdoDownLoad = new System.Windows.Forms.RadioButton();
            this.rdoUpLoad = new System.Windows.Forms.RadioButton();
            this.rdoDel = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DefaultScheme = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Hint = "";
            this.btnCancel.Location = new System.Drawing.Point(140, 198);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnCancel.Size = new System.Drawing.Size(76, 36);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.DefaultScheme = true;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnOk.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Hint = "";
            this.btnOk.Location = new System.Drawing.Point(36, 198);
            this.btnOk.Name = "btnOk";
            this.btnOk.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnOk.Size = new System.Drawing.Size(76, 36);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "确定(&O)";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // rdoDownLoad
            // 
            this.rdoDownLoad.Checked = true;
            this.rdoDownLoad.ForeColor = System.Drawing.Color.Black;
            this.rdoDownLoad.Location = new System.Drawing.Point(36, 22);
            this.rdoDownLoad.Name = "rdoDownLoad";
            this.rdoDownLoad.Size = new System.Drawing.Size(200, 26);
            this.rdoDownLoad.TabIndex = 8;
            this.rdoDownLoad.TabStop = true;
            this.rdoDownLoad.Text = "下载已传社保病人费用明细";
            this.rdoDownLoad.UseVisualStyleBackColor = true;
            // 
            // rdoUpLoad
            // 
            this.rdoUpLoad.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.rdoUpLoad.Location = new System.Drawing.Point(36, 130);
            this.rdoUpLoad.Name = "rdoUpLoad";
            this.rdoUpLoad.Size = new System.Drawing.Size(220, 26);
            this.rdoUpLoad.TabIndex = 9;
            this.rdoUpLoad.Text = "上传已下载社保病人费用明细";
            this.rdoUpLoad.UseVisualStyleBackColor = true;
            // 
            // rdoDel
            // 
            this.rdoDel.ForeColor = System.Drawing.Color.Red;
            this.rdoDel.Location = new System.Drawing.Point(36, 76);
            this.rdoDel.Name = "rdoDel";
            this.rdoDel.Size = new System.Drawing.Size(216, 26);
            this.rdoDel.TabIndex = 10;
            this.rdoDel.Text = "删除已下载社保病人费用明细";
            this.rdoDel.UseVisualStyleBackColor = true;
            // 
            // frmYB_F2DownLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 249);
            this.ControlBox = false;
            this.Controls.Add(this.rdoDel);
            this.Controls.Add(this.rdoUpLoad);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.rdoDownLoad);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmYB_F2DownLoad";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "2006年度医保病人处理";
            this.ResumeLayout(false);

        }

        #endregion

        internal PinkieControls.ButtonXP btnCancel;
        internal PinkieControls.ButtonXP btnOk;
        private System.Windows.Forms.RadioButton rdoDownLoad;
        private System.Windows.Forms.RadioButton rdoUpLoad;
        private System.Windows.Forms.RadioButton rdoDel;
    }
}