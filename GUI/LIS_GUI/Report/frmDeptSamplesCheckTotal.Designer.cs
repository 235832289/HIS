namespace com.digitalwave.iCare.gui.LIS
{
    partial class frmDeptSamplesCheckTotal
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
            this.crvSamplesCheckTotal = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSamplesCheckTotal = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // crvSamplesCheckTotal
            // 
            this.crvSamplesCheckTotal.ActiveViewIndex = -1;
            this.crvSamplesCheckTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvSamplesCheckTotal.DisplayGroupTree = false;
            this.crvSamplesCheckTotal.Location = new System.Drawing.Point(-3, 37);
            this.crvSamplesCheckTotal.Name = "crvSamplesCheckTotal";
            this.crvSamplesCheckTotal.SelectionFormula = "";
            this.crvSamplesCheckTotal.Size = new System.Drawing.Size(1019, 594);
            this.crvSamplesCheckTotal.TabIndex = 0;
            this.crvSamplesCheckTotal.ViewTimeSelectionFormula = "";
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpDateFrom.Location = new System.Drawing.Point(108, 6);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(128, 23);
            this.dtpDateFrom.TabIndex = 4;
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpDateTo.Location = new System.Drawing.Point(273, 6);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(128, 23);
            this.dtpDateTo.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(28, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "日期范围";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(244, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "至";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSamplesCheckTotal);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpDateTo);
            this.panel1.Controls.Add(this.dtpDateFrom);
            this.panel1.Location = new System.Drawing.Point(-3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1019, 33);
            this.panel1.TabIndex = 1;
            // 
            // btnSamplesCheckTotal
            // 
            this.btnSamplesCheckTotal.Location = new System.Drawing.Point(438, 5);
            this.btnSamplesCheckTotal.Name = "btnSamplesCheckTotal";
            this.btnSamplesCheckTotal.Size = new System.Drawing.Size(75, 23);
            this.btnSamplesCheckTotal.TabIndex = 8;
            this.btnSamplesCheckTotal.Text = "统计";
            this.btnSamplesCheckTotal.UseVisualStyleBackColor = true;
            this.btnSamplesCheckTotal.Click += new System.EventHandler(this.btnSamplesCheckTotal_Click);
            // 
            // frmDeptSamplesCheckTotal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 643);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.crvSamplesCheckTotal);
            this.Name = "frmDeptSamplesCheckTotal";
            this.Text = "病区标本送检量";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDeptSamplesCheckTotal_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvSamplesCheckTotal;
        internal System.Windows.Forms.DateTimePicker dtpDateFrom;
        internal System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSamplesCheckTotal;
        
    }
}