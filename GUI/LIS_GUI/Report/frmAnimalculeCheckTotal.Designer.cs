namespace com.digitalwave.iCare.gui.LIS
{
    partial class frmAnimalculeCheckTotal
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
            this.crvAnimalCuleCheckTotal = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.gbSeachCondition = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.gbSample = new System.Windows.Forms.GroupBox();
            this.clbSamples = new System.Windows.Forms.CheckedListBox();
            this.gbPatientArea = new System.Windows.Forms.GroupBox();
            this.clbPatientArea = new System.Windows.Forms.CheckedListBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.chkSample = new System.Windows.Forms.CheckBox();
            this.chkArea = new System.Windows.Forms.CheckBox();
            this.gbSeachCondition.SuspendLayout();
            this.gbSample.SuspendLayout();
            this.gbPatientArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // crvAnimalCuleCheckTotal
            // 
            this.crvAnimalCuleCheckTotal.ActiveViewIndex = -1;
            this.crvAnimalCuleCheckTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvAnimalCuleCheckTotal.DisplayGroupTree = false;
            this.crvAnimalCuleCheckTotal.Location = new System.Drawing.Point(12, 107);
            this.crvAnimalCuleCheckTotal.Name = "crvAnimalCuleCheckTotal";
            this.crvAnimalCuleCheckTotal.SelectionFormula = "";
            this.crvAnimalCuleCheckTotal.Size = new System.Drawing.Size(1019, 524);
            this.crvAnimalCuleCheckTotal.TabIndex = 2;
            this.crvAnimalCuleCheckTotal.ViewTimeSelectionFormula = "";
            // 
            // gbSeachCondition
            // 
            this.gbSeachCondition.Controls.Add(this.label2);
            this.gbSeachCondition.Controls.Add(this.label1);
            this.gbSeachCondition.Controls.Add(this.dtpDateTo);
            this.gbSeachCondition.Controls.Add(this.dtpDateFrom);
            this.gbSeachCondition.Location = new System.Drawing.Point(12, 8);
            this.gbSeachCondition.Name = "gbSeachCondition";
            this.gbSeachCondition.Size = new System.Drawing.Size(230, 89);
            this.gbSeachCondition.TabIndex = 3;
            this.gbSeachCondition.TabStop = false;
            this.gbSeachCondition.Text = "时间段";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 14;
            this.label2.Text = "截止时间";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 13;
            this.label1.Text = "起始时间";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpDateTo.Location = new System.Drawing.Point(79, 54);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(128, 23);
            this.dtpDateTo.TabIndex = 12;
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpDateFrom.Location = new System.Drawing.Point(79, 22);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(128, 23);
            this.dtpDateFrom.TabIndex = 11;
            // 
            // gbSample
            // 
            this.gbSample.Controls.Add(this.chkSample);
            this.gbSample.Controls.Add(this.clbSamples);
            this.gbSample.Location = new System.Drawing.Point(248, 8);
            this.gbSample.Name = "gbSample";
            this.gbSample.Size = new System.Drawing.Size(230, 89);
            this.gbSample.TabIndex = 4;
            this.gbSample.TabStop = false;
            this.gbSample.Text = "标 本";
            // 
            // clbSamples
            // 
            this.clbSamples.CheckOnClick = true;
            this.clbSamples.FormattingEnabled = true;
            this.clbSamples.Location = new System.Drawing.Point(6, 18);
            this.clbSamples.Name = "clbSamples";
            this.clbSamples.Size = new System.Drawing.Size(218, 68);
            this.clbSamples.TabIndex = 0;
            // 
            // gbPatientArea
            // 
            this.gbPatientArea.Controls.Add(this.chkArea);
            this.gbPatientArea.Controls.Add(this.clbPatientArea);
            this.gbPatientArea.Location = new System.Drawing.Point(484, 7);
            this.gbPatientArea.Name = "gbPatientArea";
            this.gbPatientArea.Size = new System.Drawing.Size(220, 91);
            this.gbPatientArea.TabIndex = 5;
            this.gbPatientArea.TabStop = false;
            this.gbPatientArea.Text = "病 区";
            // 
            // clbPatientArea
            // 
            this.clbPatientArea.CheckOnClick = true;
            this.clbPatientArea.FormattingEnabled = true;
            this.clbPatientArea.Location = new System.Drawing.Point(6, 18);
            this.clbPatientArea.Name = "clbPatientArea";
            this.clbPatientArea.Size = new System.Drawing.Size(209, 68);
            this.clbPatientArea.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(728, 29);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(71, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(728, 58);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(71, 23);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // chkSample
            // 
            this.chkSample.AutoSize = true;
            this.chkSample.Location = new System.Drawing.Point(43, -2);
            this.chkSample.Name = "chkSample";
            this.chkSample.Size = new System.Drawing.Size(48, 16);
            this.chkSample.TabIndex = 1;
            this.chkSample.Text = "全选";
            this.chkSample.UseVisualStyleBackColor = true;
            this.chkSample.CheckedChanged += new System.EventHandler(this.chkSample_CheckedChanged);
            // 
            // chkArea
            // 
            this.chkArea.AutoSize = true;
            this.chkArea.Location = new System.Drawing.Point(43, -2);
            this.chkArea.Name = "chkArea";
            this.chkArea.Size = new System.Drawing.Size(48, 16);
            this.chkArea.TabIndex = 2;
            this.chkArea.Text = "全选";
            this.chkArea.UseVisualStyleBackColor = true;
            this.chkArea.CheckedChanged += new System.EventHandler(this.chkArea_CheckedChanged);
            // 
            // frmAnimalculeCheckTotal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 643);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.gbPatientArea);
            this.Controls.Add(this.gbSample);
            this.Controls.Add(this.gbSeachCondition);
            this.Controls.Add(this.crvAnimalCuleCheckTotal);
            this.Name = "frmAnimalculeCheckTotal";
            this.RightToLeftLayout = true;
            this.Text = "微生物检测汇总表";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAnimalculeCheckTotal_FormClosed);
            this.Load += new System.EventHandler(this.frmAnimalculeCheckTotal_Load);
            this.gbSeachCondition.ResumeLayout(false);
            this.gbSeachCondition.PerformLayout();
            this.gbSample.ResumeLayout(false);
            this.gbSample.PerformLayout();
            this.gbPatientArea.ResumeLayout(false);
            this.gbPatientArea.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvAnimalCuleCheckTotal;
        private System.Windows.Forms.GroupBox gbSeachCondition;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.DateTimePicker dtpDateTo;
        internal System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.GroupBox gbSample;
        private System.Windows.Forms.CheckedListBox clbSamples;
        private System.Windows.Forms.GroupBox gbPatientArea;
        private System.Windows.Forms.CheckedListBox clbPatientArea;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkSample;
        private System.Windows.Forms.CheckBox chkArea;
    }
}