namespace com.digitalwave.iCare.BIHOrder
{
    partial class frmPretestMedRec
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
            this.dtmRec = new System.Windows.Forms.DateTimePicker();
            this.lblTimeSpan = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.btnRec = new PinkieControls.ButtonXP();
            this.btnClose = new PinkieControls.ButtonXP();
            this.SuspendLayout();
            // 
            // dtmRec
            // 
            this.dtmRec.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtmRec.Font = new System.Drawing.Font("宋体", 10.5F);
            this.dtmRec.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmRec.Location = new System.Drawing.Point(84, 24);
            this.dtmRec.Name = "dtmRec";
            this.dtmRec.Size = new System.Drawing.Size(196, 23);
            this.dtmRec.TabIndex = 95;
            // 
            // lblTimeSpan
            // 
            this.lblTimeSpan.AutoSize = true;
            this.lblTimeSpan.Font = new System.Drawing.Font("宋体", 10F);
            this.lblTimeSpan.Location = new System.Drawing.Point(8, 27);
            this.lblTimeSpan.Name = "lblTimeSpan";
            this.lblTimeSpan.Size = new System.Drawing.Size(77, 14);
            this.lblTimeSpan.TabIndex = 94;
            this.lblTimeSpan.Text = "回收时间：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F);
            this.label1.Location = new System.Drawing.Point(8, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 96;
            this.label1.Text = "回收备注：";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(84, 70);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRemark.Size = new System.Drawing.Size(196, 278);
            this.txtRemark.TabIndex = 97;
            // 
            // btnRec
            // 
            this.btnRec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnRec.DefaultScheme = true;
            this.btnRec.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnRec.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRec.Hint = "";
            this.btnRec.Location = new System.Drawing.Point(84, 368);
            this.btnRec.Name = "btnRec";
            this.btnRec.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnRec.Size = new System.Drawing.Size(99, 32);
            this.btnRec.TabIndex = 98;
            this.btnRec.Text = "确认回收(&Y)";
            this.btnRec.TextColor = System.Drawing.Color.ForestGreen;
            this.btnRec.Click += new System.EventHandler(this.btnRec_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnClose.DefaultScheme = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Hint = "";
            this.btnClose.Location = new System.Drawing.Point(206, 368);
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnClose.Size = new System.Drawing.Size(74, 32);
            this.btnClose.TabIndex = 99;
            this.btnClose.Text = "关闭 (&C)";
            this.btnClose.TextColor = System.Drawing.Color.Black;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmPretestMedRec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 416);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRec);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtmRec);
            this.Controls.Add(this.lblTimeSpan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPretestMedRec";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "预发药回收确认";
            this.Load += new System.EventHandler(this.frmPretestMedRec_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.DateTimePicker dtmRec;
        private System.Windows.Forms.Label lblTimeSpan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRemark;
        internal PinkieControls.ButtonXP btnRec;
        internal PinkieControls.ButtonXP btnClose;
    }
}