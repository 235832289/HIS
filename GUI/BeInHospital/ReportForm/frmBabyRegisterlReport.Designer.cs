namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmBabyRegisterlReport
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
            this.components = new System.ComponentModel.Container();
            this.m_dtFromTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.m_dtToTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.m_crystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.cmdOK = new PinkieControls.ButtonXP();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtAREAID_CHR = new com.digitalwave.iCare.gui.HIS.txtListView(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.cmdClose = new PinkieControls.ButtonXP();
            this.SuspendLayout();
            // 
            // m_dtFromTime
            // 
            this.m_dtFromTime.Location = new System.Drawing.Point(111, 18);
            this.m_dtFromTime.Name = "m_dtFromTime";
            this.m_dtFromTime.Size = new System.Drawing.Size(127, 23);
            this.m_dtFromTime.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "统计日期:";
            // 
            // m_dtToTime
            // 
            this.m_dtToTime.Location = new System.Drawing.Point(274, 18);
            this.m_dtToTime.Name = "m_dtToTime";
            this.m_dtToTime.Size = new System.Drawing.Size(125, 23);
            this.m_dtToTime.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(247, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "至";
            // 
            // m_crystalReportViewer
            // 
            this.m_crystalReportViewer.ActiveViewIndex = -1;
            this.m_crystalReportViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_crystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_crystalReportViewer.DisplayGroupTree = false;
            this.m_crystalReportViewer.Location = new System.Drawing.Point(4, 59);
            this.m_crystalReportViewer.Name = "m_crystalReportViewer";
            this.m_crystalReportViewer.SelectionFormula = "";
            this.m_crystalReportViewer.Size = new System.Drawing.Size(906, 419);
            this.m_crystalReportViewer.TabIndex = 5;
            this.m_crystalReportViewer.ViewTimeSelectionFormula = "";
            // 
            // cmdOK
            // 
            this.cmdOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdOK.DefaultScheme = true;
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdOK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdOK.Hint = "";
            this.cmdOK.Location = new System.Drawing.Point(693, 14);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdOK.Size = new System.Drawing.Size(80, 27);
            this.cmdOK.TabIndex = 3;
            this.cmdOK.Text = "确定(&S)";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(4, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(908, 2);
            this.label3.TabIndex = 4;
            // 
            // m_txtAREAID_CHR
            // 
            this.m_txtAREAID_CHR.findDataMode = com.digitalwave.iCare.gui.HIS.txtListView.findMode.fromListView;
            this.m_txtAREAID_CHR.Location = new System.Drawing.Point(469, 18);
            this.m_txtAREAID_CHR.m_blnDefSelect = true;
            this.m_txtAREAID_CHR.m_blnEmpty = false;
            this.m_txtAREAID_CHR.m_blnEnterShowList = true;
            this.m_txtAREAID_CHR.m_blnFirstFind = true;
            this.m_txtAREAID_CHR.m_blnFocuseShow = true;
            this.m_txtAREAID_CHR.m_blnPagination = false;
            this.m_txtAREAID_CHR.m_blnSelectItem = true;
            this.m_txtAREAID_CHR.m_dtbDataSourse = null;
            this.m_txtAREAID_CHR.m_intNowPage = 0;
            this.m_txtAREAID_CHR.m_intPageRows = 10;
            this.m_txtAREAID_CHR.m_intTotalPage = 1;
            this.m_txtAREAID_CHR.m_ListViewAlign = com.digitalwave.iCare.gui.HIS.txtListView.ListViewAlign.LeftBottom;
            this.m_txtAREAID_CHR.m_listViewLocation = new System.Drawing.Point(0, 0);
            this.m_txtAREAID_CHR.m_listViewSize = new System.Drawing.Point(200, 150);
            this.m_txtAREAID_CHR.m_objListViewColumnsArr = null;
            this.m_txtAREAID_CHR.m_strSaveField = "deptid_chr";
            this.m_txtAREAID_CHR.m_strShowField = "deptname_vchr";
            this.m_txtAREAID_CHR.m_strSQL = null;
            this.m_txtAREAID_CHR.m_strSQLPage = null;
            this.m_txtAREAID_CHR.Name = "m_txtAREAID_CHR";
            this.m_txtAREAID_CHR.Size = new System.Drawing.Size(200, 23);
            this.m_txtAREAID_CHR.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(426, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 14);
            this.label4.TabIndex = 18;
            this.label4.Text = "病区:";
            // 
            // cmdClose
            // 
            this.cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdClose.DefaultScheme = true;
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdClose.Hint = "";
            this.cmdClose.Location = new System.Drawing.Point(787, 14);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdClose.Size = new System.Drawing.Size(86, 27);
            this.cmdClose.TabIndex = 19;
            this.cmdClose.Text = "关闭(&Esc)";
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmBabyRegisterlReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 482);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.m_crystalReportViewer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_dtToTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_dtFromTime);
            this.Controls.Add(this.m_txtAREAID_CHR);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmBabyRegisterlReport";
            this.Text = "新生婴儿登记统计报表";
            this.Shown += new System.EventHandler(this.frmBabyRegisterlReport_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBabyRegisterlReport_KeyDown);
            this.Load += new System.EventHandler(this.frmBabyRegisterlReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker m_dtFromTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker m_dtToTime;
        private System.Windows.Forms.Label label2;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer m_crystalReportViewer;
        private PinkieControls.ButtonXP cmdOK;
        private System.Windows.Forms.Label label3;
        internal txtListView m_txtAREAID_CHR;
        private System.Windows.Forms.Label label4;
        private PinkieControls.ButtonXP cmdClose;
    }
}