namespace com.digitalwave.iCare.gui.MedicineStore
{
    partial class frmAcceptanceCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAcceptanceCheck));
            this.m_bgwGetLasteInfo = new System.ComponentModel.BackgroundWorker();
            this.m_cmdCancel = new System.Windows.Forms.Button();
            this.txtTrade = new System.Windows.Forms.TextBox();
            this.cobGMP = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.m_cmdOK = new System.Windows.Forms.Button();
            this.m_txtExamerID = new System.Windows.Forms.TextBox();
            this.m_txtApproveCode = new System.Windows.Forms.TextBox();
            this.m_txtBidCompany = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_cboExamResult = new System.Windows.Forms.ComboBox();
            this.m_cboPackQuality = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_cboApparentQuality = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_cboBid = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_bgwGetLasteInfo
            // 
            this.m_bgwGetLasteInfo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.m_bgwGetLasteInfo_DoWork);
            this.m_bgwGetLasteInfo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.m_bgwGetLasteInfo_RunWorkerCompleted);
            // 
            // m_cmdCancel
            // 
            this.m_cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdCancel.Location = new System.Drawing.Point(209, 268);
            this.m_cmdCancel.Name = "m_cmdCancel";
            this.m_cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.m_cmdCancel.TabIndex = 45;
            this.m_cmdCancel.Text = "取消";
            this.m_cmdCancel.UseVisualStyleBackColor = true;
            this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
            // 
            // txtTrade
            // 
            this.txtTrade.Location = new System.Drawing.Point(87, 232);
            this.txtTrade.Name = "txtTrade";
            this.txtTrade.Size = new System.Drawing.Size(197, 23);
            this.txtTrade.TabIndex = 1004;
            // 
            // cobGMP
            // 
            this.cobGMP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobGMP.FormattingEnabled = true;
            this.cobGMP.Items.AddRange(new object[] {
            "不符合标准",
            "符合标准"});
            this.cobGMP.Location = new System.Drawing.Point(87, 204);
            this.cobGMP.Name = "cobGMP";
            this.cobGMP.Size = new System.Drawing.Size(197, 22);
            this.cobGMP.TabIndex = 1003;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 235);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 14);
            this.label9.TabIndex = 1002;
            this.label9.Text = "注册商标:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 207);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 14);
            this.label8.TabIndex = 1001;
            this.label8.Text = "GMP 标准:";
            // 
            // m_cmdOK
            // 
            this.m_cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_cmdOK.Location = new System.Drawing.Point(122, 268);
            this.m_cmdOK.Name = "m_cmdOK";
            this.m_cmdOK.Size = new System.Drawing.Size(75, 23);
            this.m_cmdOK.TabIndex = 40;
            this.m_cmdOK.Text = "确定";
            this.m_cmdOK.UseVisualStyleBackColor = true;
            this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
            // 
            // m_txtExamerID
            // 
            this.m_txtExamerID.Location = new System.Drawing.Point(87, 175);
            this.m_txtExamerID.Name = "m_txtExamerID";
            this.m_txtExamerID.Size = new System.Drawing.Size(197, 23);
            this.m_txtExamerID.TabIndex = 35;
            this.m_txtExamerID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtExamerID_KeyDown);
            // 
            // m_txtApproveCode
            // 
            this.m_txtApproveCode.Location = new System.Drawing.Point(87, 63);
            this.m_txtApproveCode.Name = "m_txtApproveCode";
            this.m_txtApproveCode.Size = new System.Drawing.Size(197, 23);
            this.m_txtApproveCode.TabIndex = 15;
            this.m_txtApproveCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtApproveCode_KeyDown);
            // 
            // m_txtBidCompany
            // 
            this.m_txtBidCompany.Location = new System.Drawing.Point(87, 35);
            this.m_txtBidCompany.Name = "m_txtBidCompany";
            this.m_txtBidCompany.Size = new System.Drawing.Size(197, 23);
            this.m_txtBidCompany.TabIndex = 10;
            this.m_txtBidCompany.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtBidCompany_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 1000;
            this.label3.Text = "批准文号:";
            // 
            // m_cboExamResult
            // 
            this.m_cboExamResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboExamResult.FormattingEnabled = true;
            this.m_cboExamResult.Items.AddRange(new object[] {
            "不合格",
            "合格"});
            this.m_cboExamResult.Location = new System.Drawing.Point(87, 147);
            this.m_cboExamResult.Name = "m_cboExamResult";
            this.m_cboExamResult.Size = new System.Drawing.Size(197, 22);
            this.m_cboExamResult.TabIndex = 30;
            // 
            // m_cboPackQuality
            // 
            this.m_cboPackQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboPackQuality.FormattingEnabled = true;
            this.m_cboPackQuality.Items.AddRange(new object[] {
            "不合格",
            "合格"});
            this.m_cboPackQuality.Location = new System.Drawing.Point(87, 119);
            this.m_cboPackQuality.Name = "m_cboPackQuality";
            this.m_cboPackQuality.Size = new System.Drawing.Size(197, 22);
            this.m_cboPackQuality.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 14);
            this.label7.TabIndex = 1000;
            this.label7.Text = "验 货 员:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 14);
            this.label6.TabIndex = 1000;
            this.label6.Text = "验收结论:";
            // 
            // m_cboApparentQuality
            // 
            this.m_cboApparentQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboApparentQuality.FormattingEnabled = true;
            this.m_cboApparentQuality.Items.AddRange(new object[] {
            "不合格",
            "合格"});
            this.m_cboApparentQuality.Location = new System.Drawing.Point(87, 91);
            this.m_cboApparentQuality.Name = "m_cboApparentQuality";
            this.m_cboApparentQuality.Size = new System.Drawing.Size(197, 22);
            this.m_cboApparentQuality.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 14);
            this.label5.TabIndex = 1000;
            this.label5.Text = "包装质量:";
            // 
            // m_cboBid
            // 
            this.m_cboBid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboBid.FormattingEnabled = true;
            this.m_cboBid.Items.AddRange(new object[] {
            "否",
            "是"});
            this.m_cboBid.Location = new System.Drawing.Point(87, 7);
            this.m_cboBid.Name = "m_cboBid";
            this.m_cboBid.Size = new System.Drawing.Size(197, 22);
            this.m_cboBid.TabIndex = 5;
            this.m_cboBid.Enter += new System.EventHandler(this.m_cboBid_Enter);
            this.m_cboBid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cboBid_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 1000;
            this.label4.Text = "外观质量:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 1000;
            this.label2.Text = "供 应 商:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 1000;
            this.label1.Text = "是否中标:";
            // 
            // frmAcceptanceCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_cmdCancel;
            this.ClientSize = new System.Drawing.Size(293, 301);
            this.Controls.Add(this.txtTrade);
            this.Controls.Add(this.cobGMP);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.m_cmdCancel);
            this.Controls.Add(this.m_cmdOK);
            this.Controls.Add(this.m_txtExamerID);
            this.Controls.Add(this.m_txtApproveCode);
            this.Controls.Add(this.m_txtBidCompany);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_cboExamResult);
            this.Controls.Add(this.m_cboPackQuality);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.m_cboApparentQuality);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.m_cboBid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAcceptanceCheck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "验收情况";
            this.Load += new System.EventHandler(this.frmAcceptanceCheck_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button m_cmdCancel;
        internal System.Windows.Forms.ComboBox m_cboBid;
        internal System.Windows.Forms.TextBox m_txtBidCompany;
        internal System.Windows.Forms.TextBox m_txtApproveCode;
        internal System.Windows.Forms.ComboBox m_cboApparentQuality;
        internal System.Windows.Forms.ComboBox m_cboPackQuality;
        internal System.Windows.Forms.ComboBox m_cboExamResult;
        internal System.Windows.Forms.TextBox m_txtExamerID;
        internal System.Windows.Forms.Button m_cmdOK;
        private System.ComponentModel.BackgroundWorker m_bgwGetLasteInfo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        internal System.Windows.Forms.ComboBox cobGMP;
        internal System.Windows.Forms.TextBox txtTrade;
    }
}