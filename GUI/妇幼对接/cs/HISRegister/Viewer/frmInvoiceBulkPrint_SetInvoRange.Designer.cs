namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmInvoiceBulkPrint_SetInvoRange
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInvoiceBulkPrint_SetInvoRange));
            this.label1 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtP2 = new System.Windows.Forms.TextBox();
            this.txtMinNo = new System.Windows.Forms.TextBox();
            this.txtMaxNo = new System.Windows.Forms.TextBox();
            this.lblInvoCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "收费员：";
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.ForeColor = System.Drawing.Color.Red;
            this.lblName.Location = new System.Drawing.Point(82, 21);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(156, 25);
            this.lblName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "号码前面两字母：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "最小号：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "最大号：";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnClose.Location = new System.Drawing.Point(158, 245);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnClose.Size = new System.Drawing.Size(80, 36);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "关闭 ESC";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnOK.Location = new System.Drawing.Point(46, 245);
            this.btnOK.Name = "btnOK";
            this.btnOK.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnOK.Size = new System.Drawing.Size(80, 36);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "确定 F5";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtP2
            // 
            this.txtP2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtP2.Font = new System.Drawing.Font("Arial", 21.75F);
            this.txtP2.ForeColor = System.Drawing.Color.Red;
            this.txtP2.Location = new System.Drawing.Point(158, 58);
            this.txtP2.MaxLength = 2;
            this.txtP2.Name = "txtP2";
            this.txtP2.Size = new System.Drawing.Size(90, 41);
            this.txtP2.TabIndex = 3;
            this.txtP2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtP2_KeyDown);
            // 
            // txtMinNo
            // 
            this.txtMinNo.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinNo.ForeColor = System.Drawing.Color.Red;
            this.txtMinNo.Location = new System.Drawing.Point(94, 107);
            this.txtMinNo.MaxLength = 8;
            this.txtMinNo.Name = "txtMinNo";
            this.txtMinNo.Size = new System.Drawing.Size(155, 41);
            this.txtMinNo.TabIndex = 5;
            this.txtMinNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMinNo_KeyDown);
            this.txtMinNo.Leave += new System.EventHandler(this.txtMinNo_Leave);
            // 
            // txtMaxNo
            // 
            this.txtMaxNo.Font = new System.Drawing.Font("Arial", 21.75F);
            this.txtMaxNo.ForeColor = System.Drawing.Color.Red;
            this.txtMaxNo.Location = new System.Drawing.Point(94, 156);
            this.txtMaxNo.MaxLength = 8;
            this.txtMaxNo.Name = "txtMaxNo";
            this.txtMaxNo.Size = new System.Drawing.Size(155, 41);
            this.txtMaxNo.TabIndex = 7;
            this.txtMaxNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaxNo_KeyDown);
            this.txtMaxNo.Leave += new System.EventHandler(this.txtMaxNo_Leave);
            // 
            // lblInvoCount
            // 
            this.lblInvoCount.ForeColor = System.Drawing.Color.Red;
            this.lblInvoCount.Location = new System.Drawing.Point(18, 212);
            this.lblInvoCount.Name = "lblInvoCount";
            this.lblInvoCount.Size = new System.Drawing.Size(230, 22);
            this.lblInvoCount.TabIndex = 8;
            this.lblInvoCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // frmInvoiceBulkPrint_SetInvoRange
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(266, 302);
            this.Controls.Add(this.lblInvoCount);
            this.Controls.Add(this.txtMaxNo);
            this.Controls.Add(this.txtMinNo);
            this.Controls.Add(this.txtP2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInvoiceBulkPrint_SetInvoRange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置批量打印的发票段";
            this.Load += new System.EventHandler(this.frmInvoiceBulkPrint_SetInvoRange_Load);
            this.Shown += new System.EventHandler(this.frmInvoiceBulkPrint_SetInvoRange_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmInvoiceBulkPrint_SetInvoRange_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtP2;
        private System.Windows.Forms.TextBox txtMinNo;
        private System.Windows.Forms.TextBox txtMaxNo;
        private System.Windows.Forms.Label lblInvoCount;
    }
}