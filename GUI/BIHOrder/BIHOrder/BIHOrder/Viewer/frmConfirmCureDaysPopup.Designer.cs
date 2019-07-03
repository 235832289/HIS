namespace com.digitalwave.iCare.BIHOrder
{
    partial class frmConfirmCureDaysPopup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnClose = new PinkieControls.ButtonXP();
            this.btnOk = new PinkieControls.ButtonXP();
            this.dtmConfirm = new System.Windows.Forms.DateTimePicker();
            this.lblTimeSpan = new System.Windows.Forms.Label();
            this.rdo1 = new System.Windows.Forms.RadioButton();
            this.rdo2 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnClose.DefaultScheme = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Hint = "";
            this.btnClose.Location = new System.Drawing.Point(156, 176);
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnClose.Size = new System.Drawing.Size(74, 32);
            this.btnClose.TabIndex = 105;
            this.btnClose.Text = "关闭 (&C)";
            this.btnClose.TextColor = System.Drawing.Color.Black;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnOk.DefaultScheme = true;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnOk.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOk.Hint = "";
            this.btnOk.Location = new System.Drawing.Point(34, 176);
            this.btnOk.Name = "btnOk";
            this.btnOk.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnOk.Size = new System.Drawing.Size(99, 32);
            this.btnOk.TabIndex = 104;
            this.btnOk.Text = "确认(&Y)";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // dtmConfirm
            // 
            this.dtmConfirm.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtmConfirm.Font = new System.Drawing.Font("宋体", 10.5F);
            this.dtmConfirm.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmConfirm.Location = new System.Drawing.Point(92, 40);
            this.dtmConfirm.Name = "dtmConfirm";
            this.dtmConfirm.Size = new System.Drawing.Size(155, 23);
            this.dtmConfirm.TabIndex = 101;
            // 
            // lblTimeSpan
            // 
            this.lblTimeSpan.AutoSize = true;
            this.lblTimeSpan.Font = new System.Drawing.Font("宋体", 10F);
            this.lblTimeSpan.Location = new System.Drawing.Point(16, 43);
            this.lblTimeSpan.Name = "lblTimeSpan";
            this.lblTimeSpan.Size = new System.Drawing.Size(77, 14);
            this.lblTimeSpan.TabIndex = 100;
            this.lblTimeSpan.Text = "审核时间：";
            // 
            // rdo1
            // 
            this.rdo1.AutoSize = true;
            this.rdo1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdo1.ForeColor = System.Drawing.Color.Green;
            this.rdo1.Location = new System.Drawing.Point(56, 112);
            this.rdo1.Name = "rdo1";
            this.rdo1.Size = new System.Drawing.Size(55, 18);
            this.rdo1.TabIndex = 106;
            this.rdo1.TabStop = true;
            this.rdo1.Text = "通过";
            this.rdo1.UseVisualStyleBackColor = true;
            // 
            // rdo2
            // 
            this.rdo2.AutoSize = true;
            this.rdo2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdo2.ForeColor = System.Drawing.Color.Red;
            this.rdo2.Location = new System.Drawing.Point(136, 112);
            this.rdo2.Name = "rdo2";
            this.rdo2.Size = new System.Drawing.Size(70, 18);
            this.rdo2.TabIndex = 107;
            this.rdo2.TabStop = true;
            this.rdo2.Text = "不通过";
            this.rdo2.UseVisualStyleBackColor = true;
            // 
            // frmConfirmCureDaysPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 230);
            this.Controls.Add(this.rdo2);
            this.Controls.Add(this.rdo1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.dtmConfirm);
            this.Controls.Add(this.lblTimeSpan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfirmCureDaysPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "确认";
            this.Load += new System.EventHandler(this.frmConfirmCureDaysPopup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal PinkieControls.ButtonXP btnClose;
        internal PinkieControls.ButtonXP btnOk;
        internal System.Windows.Forms.DateTimePicker dtmConfirm;
        private System.Windows.Forms.Label lblTimeSpan;
        private System.Windows.Forms.RadioButton rdo1;
        private System.Windows.Forms.RadioButton rdo2;
    }
}