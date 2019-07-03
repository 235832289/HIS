namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmEditAvailableStorage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditAvailableStorage));
            this.m_btnSave = new PinkieControls.ButtonXP();
            this.label1 = new System.Windows.Forms.Label();
            this.m_btnClose = new PinkieControls.ButtonXP();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtMedicineName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtUnit = new System.Windows.Forms.TextBox();
            this.m_txtLotno = new System.Windows.Forms.TextBox();
            this.m_txtOldAmount = new System.Windows.Forms.TextBox();
            this.m_txtNewAmount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_btnSave
            // 
            this.m_btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnSave.DefaultScheme = true;
            this.m_btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnSave.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnSave.Hint = "";
            this.m_btnSave.Location = new System.Drawing.Point(84, 260);
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnSave.Size = new System.Drawing.Size(69, 28);
            this.m_btnSave.TabIndex = 1;
            this.m_btnSave.Text = "保存(&S)";
            this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "药品名称：";
            // 
            // m_btnClose
            // 
            this.m_btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnClose.DefaultScheme = true;
            this.m_btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnClose.Hint = "";
            this.m_btnClose.Location = new System.Drawing.Point(193, 260);
            this.m_btnClose.Name = "m_btnClose";
            this.m_btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnClose.Size = new System.Drawing.Size(69, 28);
            this.m_btnClose.TabIndex = 2;
            this.m_btnClose.Text = "关闭(&C)";
            this.m_btnClose.Click += new System.EventHandler(this.m_btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 14);
            this.label2.TabIndex = 10;
            this.label2.Text = "修改前数量：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(23, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "修改后数量：";
            // 
            // m_txtMedicineName
            // 
            this.m_txtMedicineName.BackColor = System.Drawing.SystemColors.Info;
            this.m_txtMedicineName.Location = new System.Drawing.Point(118, 30);
            this.m_txtMedicineName.Name = "m_txtMedicineName";
            this.m_txtMedicineName.ReadOnly = true;
            this.m_txtMedicineName.Size = new System.Drawing.Size(193, 23);
            this.m_txtMedicineName.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(65, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 9;
            this.label4.Text = "批号：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "单位：";
            // 
            // m_txtUnit
            // 
            this.m_txtUnit.BackColor = System.Drawing.SystemColors.Info;
            this.m_txtUnit.Location = new System.Drawing.Point(118, 73);
            this.m_txtUnit.Name = "m_txtUnit";
            this.m_txtUnit.ReadOnly = true;
            this.m_txtUnit.Size = new System.Drawing.Size(193, 23);
            this.m_txtUnit.TabIndex = 4;
            // 
            // m_txtLotno
            // 
            this.m_txtLotno.BackColor = System.Drawing.SystemColors.Info;
            this.m_txtLotno.Location = new System.Drawing.Point(118, 116);
            this.m_txtLotno.Name = "m_txtLotno";
            this.m_txtLotno.ReadOnly = true;
            this.m_txtLotno.Size = new System.Drawing.Size(193, 23);
            this.m_txtLotno.TabIndex = 5;
            // 
            // m_txtOldAmount
            // 
            this.m_txtOldAmount.BackColor = System.Drawing.SystemColors.Info;
            this.m_txtOldAmount.Location = new System.Drawing.Point(118, 159);
            this.m_txtOldAmount.Name = "m_txtOldAmount";
            this.m_txtOldAmount.ReadOnly = true;
            this.m_txtOldAmount.Size = new System.Drawing.Size(193, 23);
            this.m_txtOldAmount.TabIndex = 6;
            // 
            // m_txtNewAmount
            // 
            this.m_txtNewAmount.Location = new System.Drawing.Point(118, 202);
            this.m_txtNewAmount.Name = "m_txtNewAmount";
            this.m_txtNewAmount.Size = new System.Drawing.Size(193, 23);
            this.m_txtNewAmount.TabIndex = 0;
            this.m_txtNewAmount.Leave += new System.EventHandler(this.m_txtNewAmount_Leave);
            this.m_txtNewAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtNewAmount_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F);
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(4, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "(保留小数点后两位)";
            // 
            // frmEditAvailableStorage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_btnClose;
            this.ClientSize = new System.Drawing.Size(341, 318);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.m_txtNewAmount);
            this.Controls.Add(this.m_txtOldAmount);
            this.Controls.Add(this.m_txtLotno);
            this.Controls.Add(this.m_txtUnit);
            this.Controls.Add(this.m_txtMedicineName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_btnClose);
            this.Controls.Add(this.m_btnSave);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditAvailableStorage";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "编辑可用库存数量";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal PinkieControls.ButtonXP m_btnSave;
        private System.Windows.Forms.Label label1;
        internal PinkieControls.ButtonXP m_btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox m_txtMedicineName;
        internal System.Windows.Forms.TextBox m_txtUnit;
        internal System.Windows.Forms.TextBox m_txtLotno;
        internal System.Windows.Forms.TextBox m_txtOldAmount;
        internal System.Windows.Forms.TextBox m_txtNewAmount;
        private System.Windows.Forms.Label label6;
    }
}