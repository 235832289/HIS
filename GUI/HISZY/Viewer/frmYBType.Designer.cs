namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmYBType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmYBType));
            this.btnCancel = new PinkieControls.ButtonXP();
            this.btnOk = new PinkieControls.ButtonXP();
            this.rdoOld = new System.Windows.Forms.RadioButton();
            this.rdoNew = new System.Windows.Forms.RadioButton();
            this.rdoDel = new System.Windows.Forms.RadioButton();
            this.rdoComplete = new System.Windows.Forms.RadioButton();
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
            // rdoOld
            // 
            this.rdoOld.AutoSize = true;
            this.rdoOld.ForeColor = System.Drawing.Color.Red;
            this.rdoOld.Location = new System.Drawing.Point(36, 28);
            this.rdoOld.Name = "rdoOld";
            this.rdoOld.Size = new System.Drawing.Size(123, 18);
            this.rdoOld.TabIndex = 7;
            this.rdoOld.Text = "2006年慧通系统";
            this.rdoOld.UseVisualStyleBackColor = true;
            this.rdoOld.Visible = false;
            // 
            // rdoNew
            // 
            this.rdoNew.AutoSize = true;
            this.rdoNew.Checked = true;
            this.rdoNew.ForeColor = System.Drawing.Color.Black;
            this.rdoNew.Location = new System.Drawing.Point(36, 26);
            this.rdoNew.Name = "rdoNew";
            this.rdoNew.Size = new System.Drawing.Size(165, 18);
            this.rdoNew.TabIndex = 8;
            this.rdoNew.TabStop = true;
            this.rdoNew.Text = "上传社保病人费用明细";
            this.rdoNew.UseVisualStyleBackColor = true;
            // 
            // rdoDel
            // 
            this.rdoDel.AutoSize = true;
            this.rdoDel.Location = new System.Drawing.Point(36, 134);
            this.rdoDel.Name = "rdoDel";
            this.rdoDel.Size = new System.Drawing.Size(109, 18);
            this.rdoDel.TabIndex = 9;
            this.rdoDel.Text = "删除已传数据";
            this.rdoDel.UseVisualStyleBackColor = true;
            // 
            // rdoComplete
            // 
            this.rdoComplete.AutoSize = true;
            this.rdoComplete.ForeColor = System.Drawing.Color.Blue;
            this.rdoComplete.Location = new System.Drawing.Point(36, 80);
            this.rdoComplete.Name = "rdoComplete";
            this.rdoComplete.Size = new System.Drawing.Size(123, 18);
            this.rdoComplete.TabIndex = 10;
            this.rdoComplete.Text = "先前已成功传送";
            this.rdoComplete.UseVisualStyleBackColor = true;
            // 
            // frmYBType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 249);
            this.ControlBox = false;
            this.Controls.Add(this.rdoComplete);
            this.Controls.Add(this.rdoDel);
            this.Controls.Add(this.rdoNew);
            this.Controls.Add(this.rdoOld);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmYBType";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "请选择操作类型";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal PinkieControls.ButtonXP btnCancel;
        internal PinkieControls.ButtonXP btnOk;
        private System.Windows.Forms.RadioButton rdoOld;
        private System.Windows.Forms.RadioButton rdoNew;
        private System.Windows.Forms.RadioButton rdoDel;
        private System.Windows.Forms.RadioButton rdoComplete;
    }
}