namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmOrderBookingRe
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
            this.dw_seach = new Sybase.DataWindow.DataWindowControl();
            this.m_txtApplyType = new ControlLibrary.txtListView(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_dtpEndDate = new NullableDateControls.MaskDateEdit();
            this.m_dtpBeginDate = new NullableDateControls.MaskDateEdit();
            this.m_cmdExit = new PinkieControls.ButtonXP();
            this.m_cmdSearch = new PinkieControls.ButtonXP();
            this.label4 = new System.Windows.Forms.Label();
            this.m_cmdRevert = new PinkieControls.ButtonXP();
            this.m_cmbStatus = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_cmdReplyForm = new PinkieControls.ButtonXP();
            this.m_cmdAdv = new PinkieControls.ButtonXP();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dw_seach);
            this.panel1.Location = new System.Drawing.Point(9, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1015, 545);
            this.panel1.TabIndex = 0;
            // 
            // dw_seach
            // 
            this.dw_seach.DataWindowObject = "";
            this.dw_seach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dw_seach.LibraryList = "";
            this.dw_seach.Location = new System.Drawing.Point(0, 0);
            this.dw_seach.Name = "dw_seach";
            this.dw_seach.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dw_seach.Size = new System.Drawing.Size(1015, 545);
            this.dw_seach.TabIndex = 28;
            this.dw_seach.RowFocusChanged += new Sybase.DataWindow.RowFocusChangedEventHandler(this.dw_seach_RowFocusChanged);
            // 
            // m_txtApplyType
            // 
            this.m_txtApplyType.findDataMode = ControlLibrary.txtListView.findMode.fromDataSouse;
            this.m_txtApplyType.Location = new System.Drawing.Point(392, 11);
            this.m_txtApplyType.m_blnFocuseShow = true;
            this.m_txtApplyType.m_blnPagination = false;
            this.m_txtApplyType.m_dtbDataSourse = null;
            this.m_txtApplyType.m_intDelayTime = 100;
            this.m_txtApplyType.m_intPageRows = 10;
            this.m_txtApplyType.m_ListViewAlign = ControlLibrary.txtListView.ListViewAlign.LeftBottom;
            this.m_txtApplyType.m_listViewSize = new System.Drawing.Point(260, 100);
            this.m_txtApplyType.m_strFieldsArr = new string[] {
        "TYPETEXT"};
            this.m_txtApplyType.m_strSaveField = "TYPEID";
            this.m_txtApplyType.m_strShowField = "TYPETEXT";
            this.m_txtApplyType.m_strSQL = null;
            this.m_txtApplyType.Name = "m_txtApplyType";
            this.m_txtApplyType.Size = new System.Drawing.Size(102, 23);
            this.m_txtApplyType.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(328, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 42;
            this.label3.Text = "检查类型：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-86, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 40;
            this.label2.Text = "从";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(165, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 14);
            this.label1.TabIndex = 39;
            this.label1.Text = "至";
            // 
            // m_dtpEndDate
            // 
            this.m_dtpEndDate.Location = new System.Drawing.Point(184, 11);
            this.m_dtpEndDate.Mask = "yyyy-MM-dd HH:mm";
            this.m_dtpEndDate.Name = "m_dtpEndDate";
            this.m_dtpEndDate.Size = new System.Drawing.Size(143, 23);
            this.m_dtpEndDate.TabIndex = 1;
            // 
            // m_dtpBeginDate
            // 
            this.m_dtpBeginDate.Location = new System.Drawing.Point(23, 11);
            this.m_dtpBeginDate.Mask = "yyyy-MM-dd HH:mm";
            this.m_dtpBeginDate.Name = "m_dtpBeginDate";
            this.m_dtpBeginDate.Size = new System.Drawing.Size(143, 23);
            this.m_dtpBeginDate.TabIndex = 0;
            // 
            // m_cmdExit
            // 
            this.m_cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdExit.DefaultScheme = true;
            this.m_cmdExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdExit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdExit.Hint = "";
            this.m_cmdExit.Location = new System.Drawing.Point(960, 9);
            this.m_cmdExit.Name = "m_cmdExit";
            this.m_cmdExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdExit.Size = new System.Drawing.Size(66, 29);
            this.m_cmdExit.TabIndex = 6;
            this.m_cmdExit.Text = "关闭(&X)";
            this.m_cmdExit.Click += new System.EventHandler(this.m_cmdExit_Click);
            // 
            // m_cmdSearch
            // 
            this.m_cmdSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdSearch.DefaultScheme = true;
            this.m_cmdSearch.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSearch.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdSearch.Hint = "";
            this.m_cmdSearch.Location = new System.Drawing.Point(684, 9);
            this.m_cmdSearch.Name = "m_cmdSearch";
            this.m_cmdSearch.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSearch.Size = new System.Drawing.Size(69, 29);
            this.m_cmdSearch.TabIndex = 4;
            this.m_cmdSearch.Text = "查询(&S)";
            this.m_cmdSearch.Click += new System.EventHandler(this.m_cmdSearch_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 14);
            this.label4.TabIndex = 43;
            this.label4.Text = "从";
            // 
            // m_cmdRevert
            // 
            this.m_cmdRevert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdRevert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdRevert.DefaultScheme = true;
            this.m_cmdRevert.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdRevert.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdRevert.Hint = "";
            this.m_cmdRevert.Location = new System.Drawing.Point(892, 9);
            this.m_cmdRevert.Name = "m_cmdRevert";
            this.m_cmdRevert.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdRevert.Size = new System.Drawing.Size(69, 29);
            this.m_cmdRevert.TabIndex = 5;
            this.m_cmdRevert.Text = "回复(&R)";
            this.m_cmdRevert.Click += new System.EventHandler(this.m_cmdRevert_Click);
            // 
            // m_cmbStatus
            // 
            this.m_cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbStatus.FormattingEnabled = true;
            this.m_cmbStatus.Items.AddRange(new object[] {
            "全部",
            "预约未确认",
            "预约通过",
            "预约未通过"});
            this.m_cmbStatus.Location = new System.Drawing.Point(537, 12);
            this.m_cmbStatus.Name = "m_cmbStatus";
            this.m_cmbStatus.Size = new System.Drawing.Size(106, 22);
            this.m_cmbStatus.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(499, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 14);
            this.label5.TabIndex = 46;
            this.label5.Text = "状态：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_cmdReplyForm);
            this.panel2.Controls.Add(this.m_cmdAdv);
            this.panel2.Controls.Add(this.m_txtApplyType);
            this.panel2.Controls.Add(this.m_cmbStatus);
            this.panel2.Controls.Add(this.m_cmdSearch);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.m_cmdExit);
            this.panel2.Controls.Add(this.m_dtpBeginDate);
            this.panel2.Controls.Add(this.m_dtpEndDate);
            this.panel2.Controls.Add(this.m_cmdRevert);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1028, 46);
            this.panel2.TabIndex = 29;
            // 
            // m_cmdReplyForm
            // 
            this.m_cmdReplyForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdReplyForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdReplyForm.DefaultScheme = true;
            this.m_cmdReplyForm.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdReplyForm.Hint = "";
            this.m_cmdReplyForm.Location = new System.Drawing.Point(820, 9);
            this.m_cmdReplyForm.Name = "m_cmdReplyForm";
            this.m_cmdReplyForm.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdReplyForm.Size = new System.Drawing.Size(72, 29);
            this.m_cmdReplyForm.TabIndex = 53;
            this.m_cmdReplyForm.Text = "申请单(&R)";
            this.m_cmdReplyForm.Click += new System.EventHandler(this.m_cmdReplyForm_Click);
            // 
            // m_cmdAdv
            // 
            this.m_cmdAdv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdAdv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdAdv.DefaultScheme = true;
            this.m_cmdAdv.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAdv.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdAdv.Hint = "";
            this.m_cmdAdv.Location = new System.Drawing.Point(752, 9);
            this.m_cmdAdv.Name = "m_cmdAdv";
            this.m_cmdAdv.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAdv.Size = new System.Drawing.Size(69, 29);
            this.m_cmdAdv.TabIndex = 5;
            this.m_cmdAdv.Text = "高级(&A)";
            this.m_cmdAdv.Click += new System.EventHandler(this.m_cmdAdv_Click);
            // 
            // frmOrderBookingRe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 611);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KeyPreview = true;
            this.Name = "frmOrderBookingRe";
            this.Text = "检查申请预约回复";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmOrderBookingRe_KeyDown);
            this.Load += new System.EventHandler(this.frmOrderBookingRe_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        internal Sybase.DataWindow.DataWindowControl dw_seach;
        internal ControlLibrary.txtListView m_txtApplyType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        internal NullableDateControls.MaskDateEdit m_dtpEndDate;
        internal NullableDateControls.MaskDateEdit m_dtpBeginDate;
        private PinkieControls.ButtonXP m_cmdExit;
        private PinkieControls.ButtonXP m_cmdSearch;
        private System.Windows.Forms.Label label4;
        internal PinkieControls.ButtonXP m_cmdRevert;
        internal System.Windows.Forms.ComboBox m_cmbStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        internal PinkieControls.ButtonXP m_cmdAdv;
        private PinkieControls.ButtonXP m_cmdReplyForm;
    }
}