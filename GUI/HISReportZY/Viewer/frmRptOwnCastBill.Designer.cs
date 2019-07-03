namespace com.digitalwave.iCare.gui.HIS.Reports
{
	partial class frmRptOwnCastBill
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtInpatientID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cobSelect = new System.Windows.Forms.ComboBox();
            this.buttonXP2 = new PinkieControls.ButtonXP();
            this.cmdPrint = new PinkieControls.ButtonXP();
            this.txtRegisterID = new ControlLibrary.txtListView1(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnPreview = new PinkieControls.ButtonXP();
            this.dwReport = new Sybase.DataWindow.DataWindowControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtInpatientID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cobSelect);
            this.panel1.Controls.Add(this.buttonXP2);
            this.panel1.Controls.Add(this.cmdPrint);
            this.panel1.Controls.Add(this.txtRegisterID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnPreview);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1012, 59);
            this.panel1.TabIndex = 0;
            // 
            // txtInpatientID
            // 
            this.txtInpatientID.Location = new System.Drawing.Point(275, 18);
            this.txtInpatientID.Name = "txtInpatientID";
            this.txtInpatientID.Size = new System.Drawing.Size(152, 23);
            this.txtInpatientID.TabIndex = 33;
            this.txtInpatientID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInpatientID_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "查询内容：";
            // 
            // cobSelect
            // 
            this.cobSelect.BackColor = System.Drawing.SystemColors.Control;
            this.cobSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobSelect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cobSelect.FormattingEnabled = true;
            this.cobSelect.Items.AddRange(new object[] {
            "住院号",
            "诊疗卡号"});
            this.cobSelect.Location = new System.Drawing.Point(80, 18);
            this.cobSelect.Name = "cobSelect";
            this.cobSelect.Size = new System.Drawing.Size(111, 22);
            this.cobSelect.TabIndex = 15;
            this.cobSelect.SelectionChangeCommitted += new System.EventHandler(this.cobSelect_SelectionChangeCommitted);
            this.cobSelect.SelectedIndexChanged += new System.EventHandler(this.cobSelect_SelectedIndexChanged);
            // 
            // buttonXP2
            // 
            this.buttonXP2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonXP2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonXP2.DefaultScheme = true;
            this.buttonXP2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonXP2.Hint = "";
            this.buttonXP2.Location = new System.Drawing.Point(919, 12);
            this.buttonXP2.Name = "buttonXP2";
            this.buttonXP2.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP2.Size = new System.Drawing.Size(82, 35);
            this.buttonXP2.TabIndex = 35;
            this.buttonXP2.Text = "退出(&E)";
            this.buttonXP2.Click += new System.EventHandler(this.buttonXP2_Click);
            // 
            // cmdPrint
            // 
            this.cmdPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdPrint.DefaultScheme = true;
            this.cmdPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdPrint.Hint = "";
            this.cmdPrint.Location = new System.Drawing.Point(819, 12);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdPrint.Size = new System.Drawing.Size(82, 35);
            this.cmdPrint.TabIndex = 34;
            this.cmdPrint.Text = "打印(&P)";
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // txtRegisterID
            // 
            this.txtRegisterID.AccessibleName = "5";
            this.txtRegisterID.findDataMode = ControlLibrary.txtListView1.findMode.fromDataSouse;
            this.txtRegisterID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRegisterID.Location = new System.Drawing.Point(432, 18);
            this.txtRegisterID.m_blnFocuseShow = true;
            this.txtRegisterID.m_blnPagination = false;
            this.txtRegisterID.m_dtbDataSourse = null;
            this.txtRegisterID.m_intDelayTime = 100;
            this.txtRegisterID.m_intPageRows = 10;
            this.txtRegisterID.m_ListViewAlign = ControlLibrary.txtListView1.ListViewAlign.LeftBottom;
            this.txtRegisterID.m_listViewSize = new System.Drawing.Point(275, 150);
            this.txtRegisterID.m_strFieldsArr = new string[] {
        "entcode_chr",
        "entname_vchr"};
            this.txtRegisterID.m_strSaveField = "registerid_chr";
            this.txtRegisterID.m_strShowField = "registerid_chr";
            this.txtRegisterID.m_strSQL = null;
            this.txtRegisterID.Name = "txtRegisterID";
            this.txtRegisterID.Size = new System.Drawing.Size(275, 23);
            this.txtRegisterID.TabIndex = 32;
            this.txtRegisterID.ItemSelectedOK += new ControlLibrary.txtListView1.EventItemSelectedOK(this.txtRegisterID_ItemSelectedOK);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 16;
            this.label1.Text = "查询条件：";
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnPreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreview.DefaultScheme = true;
            this.btnPreview.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPreview.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPreview.Hint = "";
            this.btnPreview.Location = new System.Drawing.Point(719, 12);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnPreview.Size = new System.Drawing.Size(82, 35);
            this.btnPreview.TabIndex = 14;
            this.btnPreview.Text = "查询(&S)";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // dwReport
            // 
            this.dwReport.DataWindowObject = "";
            this.dwReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwReport.LibraryList = "";
            this.dwReport.Location = new System.Drawing.Point(0, 59);
            this.dwReport.Name = "dwReport";
            this.dwReport.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwReport.Size = new System.Drawing.Size(1012, 609);
            this.dwReport.TabIndex = 1;
            this.dwReport.Text = "dataWindowControl1";
            // 
            // frmRptOwnCastBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 668);
            this.Controls.Add(this.dwReport);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmRptOwnCastBill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "台山市基本医疗保险住院自费项目签字单";
            this.Load += new System.EventHandler(this.frmRptOwnCastBill_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.Panel panel1;
        private Sybase.DataWindow.DataWindowControl dwReport;
        internal System.Windows.Forms.ComboBox cobSelect;
        internal PinkieControls.ButtonXP btnPreview;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtInpatientID;
        internal ControlLibrary.txtListView1 txtRegisterID;
        internal PinkieControls.ButtonXP buttonXP2;
        internal PinkieControls.ButtonXP cmdPrint;
        private System.Windows.Forms.Label label2;
	}
}