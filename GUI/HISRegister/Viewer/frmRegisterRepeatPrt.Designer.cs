namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmRegisterRepeatPrt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegisterRepeatPrt));
            this.txtNewNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblOldNo = new System.Windows.Forms.Label();
            this.btnCancel = new PinkieControls.ButtonXP();
            this.btnOK = new PinkieControls.ButtonXP();
            this.rdo2 = new System.Windows.Forms.RadioButton();
            this.rdo1 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // txtNewNo
            // 
            this.txtNewNo.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Bold);
            this.txtNewNo.Location = new System.Drawing.Point(136, 109);
            this.txtNewNo.Name = "txtNewNo";
            this.txtNewNo.Size = new System.Drawing.Size(212, 44);
            this.txtNewNo.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(30, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "原始发票号：";
            // 
            // lblOldNo
            // 
            this.lblOldNo.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOldNo.ForeColor = System.Drawing.Color.Red;
            this.lblOldNo.Location = new System.Drawing.Point(132, 12);
            this.lblOldNo.Name = "lblOldNo";
            this.lblOldNo.Size = new System.Drawing.Size(215, 40);
            this.lblOldNo.TabIndex = 16;
            this.lblOldNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DefaultScheme = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Hint = "";
            this.btnCancel.Location = new System.Drawing.Point(273, 170);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnCancel.Size = new System.Drawing.Size(76, 32);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.DefaultScheme = true;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnOK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Hint = "";
            this.btnOK.Location = new System.Drawing.Point(177, 170);
            this.btnOK.Name = "btnOK";
            this.btnOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnOK.Size = new System.Drawing.Size(76, 32);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // rdo2
            // 
            this.rdo2.AutoSize = true;
            this.rdo2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdo2.Location = new System.Drawing.Point(32, 119);
            this.rdo2.Name = "rdo2";
            this.rdo2.Size = new System.Drawing.Size(94, 20);
            this.rdo2.TabIndex = 14;
            this.rdo2.Text = "新号重打";
            this.rdo2.UseVisualStyleBackColor = true;
            this.rdo2.CheckedChanged += new System.EventHandler(this.rdo2_CheckedChanged);
            // 
            // rdo1
            // 
            this.rdo1.AutoSize = true;
            this.rdo1.Checked = true;
            this.rdo1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdo1.Location = new System.Drawing.Point(32, 72);
            this.rdo1.Name = "rdo1";
            this.rdo1.Size = new System.Drawing.Size(94, 20);
            this.rdo1.TabIndex = 13;
            this.rdo1.TabStop = true;
            this.rdo1.Text = "原号重打";
            this.rdo1.UseVisualStyleBackColor = true;
            this.rdo1.CheckedChanged += new System.EventHandler(this.rdo1_CheckedChanged);
            // 
            // frmRegisterRepeatPrt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 216);
            this.ControlBox = false;
            this.Controls.Add(this.txtNewNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblOldNo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.rdo2);
            this.Controls.Add(this.rdo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmRegisterRepeatPrt";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "请选择重打类型";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRegisterRepeatPrt_KeyDown);
            this.Load += new System.EventHandler(this.frmRegisterRepeatPrt_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNewNo;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label lblOldNo;
        internal PinkieControls.ButtonXP btnCancel;
        internal PinkieControls.ButtonXP btnOK;
        private System.Windows.Forms.RadioButton rdo2;
        private System.Windows.Forms.RadioButton rdo1;


    }
}