namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmOrderBookingAdvSearch
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
            this.m_ckbArea = new System.Windows.Forms.CheckBox();
            this.m_txtArea = new ControlLibrary.txtListView(this.components);
            this.m_ckbBedNo = new System.Windows.Forms.CheckBox();
            this.m_ckbName = new System.Windows.Forms.CheckBox();
            this.m_txtName = new System.Windows.Forms.TextBox();
            this.m_ckbSex = new System.Windows.Forms.CheckBox();
            this.m_cobSex = new System.Windows.Forms.ComboBox();
            this.m_chbInpatientId = new System.Windows.Forms.CheckBox();
            this.m_txtInpatienId = new System.Windows.Forms.TextBox();
            this.m_ckbOperateDate = new System.Windows.Forms.CheckBox();
            this.m_dtpOprBgnDate = new NullableDateControls.MaskDateEdit();
            this.m_dtpOprEndDate = new NullableDateControls.MaskDateEdit();
            this.m_lblOprTo = new System.Windows.Forms.Label();
            this.m_ckbApplyType = new System.Windows.Forms.CheckBox();
            this.m_txtApplyType = new ControlLibrary.txtListView(this.components);
            this.m_lblBookTo = new System.Windows.Forms.Label();
            this.m_dtpBookBgnDate = new NullableDateControls.MaskDateEdit();
            this.m_dtpBookEndDate = new NullableDateControls.MaskDateEdit();
            this.m_ckbBookDate = new System.Windows.Forms.CheckBox();
            this.m_cmbStatus = new System.Windows.Forms.ComboBox();
            this.m_ckbStatus = new System.Windows.Forms.CheckBox();
            this.m_cmdOk = new PinkieControls.ButtonXP();
            this.m_cmdReturn = new PinkieControls.ButtonXP();
            this.m_cmdReset = new PinkieControls.ButtonXP();
            this.m_txtBedNo = new ControlLibrary.txtListView(this.components);
            this.SuspendLayout();
            // 
            // m_ckbArea
            // 
            this.m_ckbArea.AutoSize = true;
            this.m_ckbArea.Location = new System.Drawing.Point(18, 24);
            this.m_ckbArea.Name = "m_ckbArea";
            this.m_ckbArea.Size = new System.Drawing.Size(75, 18);
            this.m_ckbArea.TabIndex = 0;
            this.m_ckbArea.Text = "病   区";
            this.m_ckbArea.UseVisualStyleBackColor = true;
            this.m_ckbArea.CheckedChanged += new System.EventHandler(this.m_ckbArea_CheckedChanged);
            // 
            // m_txtArea
            // 
            this.m_txtArea.Enabled = false;
            this.m_txtArea.findDataMode = ControlLibrary.txtListView.findMode.fromDataSouse;
            this.m_txtArea.Location = new System.Drawing.Point(92, 25);
            this.m_txtArea.m_blnFocuseShow = true;
            this.m_txtArea.m_blnPagination = false;
            this.m_txtArea.m_dtbDataSourse = null;
            this.m_txtArea.m_intDelayTime = 100;
            this.m_txtArea.m_intPageRows = 10;
            this.m_txtArea.m_ListViewAlign = ControlLibrary.txtListView.ListViewAlign.LeftBottom;
            this.m_txtArea.m_listViewSize = new System.Drawing.Point(260, 100);
            this.m_txtArea.m_strFieldsArr = new string[] {
        "code_vchr",
        "pycode_chr",
        "deptname_vchr"};
            this.m_txtArea.m_strSaveField = "deptid_chr";
            this.m_txtArea.m_strShowField = "deptname_vchr";
            this.m_txtArea.m_strSQL = null;
            this.m_txtArea.Name = "m_txtArea";
            this.m_txtArea.Size = new System.Drawing.Size(120, 23);
            this.m_txtArea.TabIndex = 3;
            this.m_txtArea.TextChanged += new System.EventHandler(this.m_txtArea_TextChanged);
            // 
            // m_ckbBedNo
            // 
            this.m_ckbBedNo.AutoSize = true;
            this.m_ckbBedNo.Location = new System.Drawing.Point(232, 24);
            this.m_ckbBedNo.Name = "m_ckbBedNo";
            this.m_ckbBedNo.Size = new System.Drawing.Size(54, 18);
            this.m_ckbBedNo.TabIndex = 4;
            this.m_ckbBedNo.Text = "床号";
            this.m_ckbBedNo.UseVisualStyleBackColor = true;
            this.m_ckbBedNo.CheckedChanged += new System.EventHandler(this.m_ckbBedNo_CheckedChanged);
            // 
            // m_ckbName
            // 
            this.m_ckbName.AutoSize = true;
            this.m_ckbName.Location = new System.Drawing.Point(367, 24);
            this.m_ckbName.Name = "m_ckbName";
            this.m_ckbName.Size = new System.Drawing.Size(54, 18);
            this.m_ckbName.TabIndex = 6;
            this.m_ckbName.Text = "姓名";
            this.m_ckbName.UseVisualStyleBackColor = true;
            this.m_ckbName.CheckedChanged += new System.EventHandler(this.m_ckbName_CheckedChanged);
            // 
            // m_txtName
            // 
            this.m_txtName.Enabled = false;
            this.m_txtName.Location = new System.Drawing.Point(415, 24);
            this.m_txtName.Name = "m_txtName";
            this.m_txtName.Size = new System.Drawing.Size(70, 23);
            this.m_txtName.TabIndex = 7;
            // 
            // m_ckbSex
            // 
            this.m_ckbSex.AutoSize = true;
            this.m_ckbSex.Location = new System.Drawing.Point(517, 23);
            this.m_ckbSex.Name = "m_ckbSex";
            this.m_ckbSex.Size = new System.Drawing.Size(54, 18);
            this.m_ckbSex.TabIndex = 8;
            this.m_ckbSex.Text = "性别";
            this.m_ckbSex.UseVisualStyleBackColor = true;
            this.m_ckbSex.CheckedChanged += new System.EventHandler(this.m_ckbSex_CheckedChanged);
            // 
            // m_cobSex
            // 
            this.m_cobSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cobSex.Enabled = false;
            this.m_cobSex.FormattingEnabled = true;
            this.m_cobSex.Items.AddRange(new object[] {
            "男",
            "女"});
            this.m_cobSex.Location = new System.Drawing.Point(568, 24);
            this.m_cobSex.Name = "m_cobSex";
            this.m_cobSex.Size = new System.Drawing.Size(56, 22);
            this.m_cobSex.TabIndex = 9;
            // 
            // m_chbInpatientId
            // 
            this.m_chbInpatientId.AutoSize = true;
            this.m_chbInpatientId.Location = new System.Drawing.Point(17, 76);
            this.m_chbInpatientId.Name = "m_chbInpatientId";
            this.m_chbInpatientId.Size = new System.Drawing.Size(89, 18);
            this.m_chbInpatientId.TabIndex = 10;
            this.m_chbInpatientId.Text = "住 院 号 ";
            this.m_chbInpatientId.UseVisualStyleBackColor = true;
            this.m_chbInpatientId.CheckedChanged += new System.EventHandler(this.m_chbInpatientId_CheckedChanged);
            // 
            // m_txtInpatienId
            // 
            this.m_txtInpatienId.Enabled = false;
            this.m_txtInpatienId.Location = new System.Drawing.Point(92, 75);
            this.m_txtInpatienId.Name = "m_txtInpatienId";
            this.m_txtInpatienId.Size = new System.Drawing.Size(120, 23);
            this.m_txtInpatienId.TabIndex = 11;
            // 
            // m_ckbOperateDate
            // 
            this.m_ckbOperateDate.AutoSize = true;
            this.m_ckbOperateDate.Location = new System.Drawing.Point(231, 76);
            this.m_ckbOperateDate.Name = "m_ckbOperateDate";
            this.m_ckbOperateDate.Size = new System.Drawing.Size(82, 18);
            this.m_ckbOperateDate.TabIndex = 12;
            this.m_ckbOperateDate.Text = "申请时间";
            this.m_ckbOperateDate.UseVisualStyleBackColor = true;
            this.m_ckbOperateDate.CheckedChanged += new System.EventHandler(this.m_ckbOperateDate_CheckedChanged);
            // 
            // m_dtpOprBgnDate
            // 
            this.m_dtpOprBgnDate.Enabled = false;
            this.m_dtpOprBgnDate.Location = new System.Drawing.Point(315, 76);
            this.m_dtpOprBgnDate.Mask = "yyyy-MM-dd HH:mm";
            this.m_dtpOprBgnDate.Name = "m_dtpOprBgnDate";
            this.m_dtpOprBgnDate.Size = new System.Drawing.Size(143, 23);
            this.m_dtpOprBgnDate.TabIndex = 13;
            // 
            // m_dtpOprEndDate
            // 
            this.m_dtpOprEndDate.Enabled = false;
            this.m_dtpOprEndDate.Location = new System.Drawing.Point(484, 76);
            this.m_dtpOprEndDate.Mask = "yyyy-MM-dd HH:mm";
            this.m_dtpOprEndDate.Name = "m_dtpOprEndDate";
            this.m_dtpOprEndDate.Size = new System.Drawing.Size(143, 23);
            this.m_dtpOprEndDate.TabIndex = 14;
            // 
            // m_lblOprTo
            // 
            this.m_lblOprTo.AutoSize = true;
            this.m_lblOprTo.Location = new System.Drawing.Point(462, 80);
            this.m_lblOprTo.Name = "m_lblOprTo";
            this.m_lblOprTo.Size = new System.Drawing.Size(21, 14);
            this.m_lblOprTo.TabIndex = 40;
            this.m_lblOprTo.Text = "至";
            // 
            // m_ckbApplyType
            // 
            this.m_ckbApplyType.AutoSize = true;
            this.m_ckbApplyType.Location = new System.Drawing.Point(17, 126);
            this.m_ckbApplyType.Name = "m_ckbApplyType";
            this.m_ckbApplyType.Size = new System.Drawing.Size(82, 18);
            this.m_ckbApplyType.TabIndex = 15;
            this.m_ckbApplyType.Text = "检查类型";
            this.m_ckbApplyType.UseVisualStyleBackColor = true;
            this.m_ckbApplyType.CheckedChanged += new System.EventHandler(this.m_chbApplyType_CheckedChanged);
            // 
            // m_txtApplyType
            // 
            this.m_txtApplyType.Enabled = false;
            this.m_txtApplyType.findDataMode = ControlLibrary.txtListView.findMode.fromDataSouse;
            this.m_txtApplyType.Location = new System.Drawing.Point(92, 126);
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
            this.m_txtApplyType.Size = new System.Drawing.Size(120, 23);
            this.m_txtApplyType.TabIndex = 16;
            // 
            // m_lblBookTo
            // 
            this.m_lblBookTo.AutoSize = true;
            this.m_lblBookTo.Location = new System.Drawing.Point(462, 131);
            this.m_lblBookTo.Name = "m_lblBookTo";
            this.m_lblBookTo.Size = new System.Drawing.Size(21, 14);
            this.m_lblBookTo.TabIndex = 46;
            this.m_lblBookTo.Text = "至";
            // 
            // m_dtpBookBgnDate
            // 
            this.m_dtpBookBgnDate.Enabled = false;
            this.m_dtpBookBgnDate.Location = new System.Drawing.Point(315, 126);
            this.m_dtpBookBgnDate.Mask = "yyyy-MM-dd HH:mm";
            this.m_dtpBookBgnDate.Name = "m_dtpBookBgnDate";
            this.m_dtpBookBgnDate.Size = new System.Drawing.Size(143, 23);
            this.m_dtpBookBgnDate.TabIndex = 18;
            // 
            // m_dtpBookEndDate
            // 
            this.m_dtpBookEndDate.Enabled = false;
            this.m_dtpBookEndDate.Location = new System.Drawing.Point(484, 126);
            this.m_dtpBookEndDate.Mask = "yyyy-MM-dd HH:mm";
            this.m_dtpBookEndDate.Name = "m_dtpBookEndDate";
            this.m_dtpBookEndDate.Size = new System.Drawing.Size(143, 23);
            this.m_dtpBookEndDate.TabIndex = 19;
            // 
            // m_ckbBookDate
            // 
            this.m_ckbBookDate.AutoSize = true;
            this.m_ckbBookDate.Location = new System.Drawing.Point(231, 126);
            this.m_ckbBookDate.Name = "m_ckbBookDate";
            this.m_ckbBookDate.Size = new System.Drawing.Size(82, 18);
            this.m_ckbBookDate.TabIndex = 17;
            this.m_ckbBookDate.Text = "预约时间";
            this.m_ckbBookDate.UseVisualStyleBackColor = true;
            this.m_ckbBookDate.CheckedChanged += new System.EventHandler(this.m_ckbBookDate_CheckedChanged);
            // 
            // m_cmbStatus
            // 
            this.m_cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbStatus.Enabled = false;
            this.m_cmbStatus.FormattingEnabled = true;
            this.m_cmbStatus.Items.AddRange(new object[] {
            "全部",
            "预约未确认",
            "预约通过",
            "预约未通过"});
            this.m_cmbStatus.Location = new System.Drawing.Point(92, 176);
            this.m_cmbStatus.Name = "m_cmbStatus";
            this.m_cmbStatus.Size = new System.Drawing.Size(120, 22);
            this.m_cmbStatus.TabIndex = 21;
            // 
            // m_ckbStatus
            // 
            this.m_ckbStatus.AutoSize = true;
            this.m_ckbStatus.Location = new System.Drawing.Point(18, 176);
            this.m_ckbStatus.Name = "m_ckbStatus";
            this.m_ckbStatus.Size = new System.Drawing.Size(75, 18);
            this.m_ckbStatus.TabIndex = 20;
            this.m_ckbStatus.Text = "状   态";
            this.m_ckbStatus.UseVisualStyleBackColor = true;
            this.m_ckbStatus.CheckedChanged += new System.EventHandler(this.m_ckbStatus_CheckedChanged);
            // 
            // m_cmdOk
            // 
            this.m_cmdOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdOk.DefaultScheme = true;
            this.m_cmdOk.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdOk.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdOk.Hint = "";
            this.m_cmdOk.Location = new System.Drawing.Point(389, 217);
            this.m_cmdOk.Name = "m_cmdOk";
            this.m_cmdOk.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdOk.Size = new System.Drawing.Size(78, 29);
            this.m_cmdOk.TabIndex = 22;
            this.m_cmdOk.Text = "确定(&O)";
            this.m_cmdOk.Click += new System.EventHandler(this.m_cmdOk_Click);
            // 
            // m_cmdReturn
            // 
            this.m_cmdReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdReturn.DefaultScheme = true;
            this.m_cmdReturn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdReturn.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdReturn.Hint = "";
            this.m_cmdReturn.Location = new System.Drawing.Point(561, 217);
            this.m_cmdReturn.Name = "m_cmdReturn";
            this.m_cmdReturn.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdReturn.Size = new System.Drawing.Size(75, 29);
            this.m_cmdReturn.TabIndex = 23;
            this.m_cmdReturn.Text = "返回(&R)";
            this.m_cmdReturn.Click += new System.EventHandler(this.m_cmdExit_Click);
            // 
            // m_cmdReset
            // 
            this.m_cmdReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdReset.DefaultScheme = true;
            this.m_cmdReset.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdReset.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdReset.Hint = "";
            this.m_cmdReset.Location = new System.Drawing.Point(477, 217);
            this.m_cmdReset.Name = "m_cmdReset";
            this.m_cmdReset.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdReset.Size = new System.Drawing.Size(78, 29);
            this.m_cmdReset.TabIndex = 24;
            this.m_cmdReset.Text = "重置(&S)";
            this.m_cmdReset.Click += new System.EventHandler(this.m_cmdReset_Click);
            // 
            // m_txtBedNo
            // 
            this.m_txtBedNo.Enabled = false;
            this.m_txtBedNo.findDataMode = ControlLibrary.txtListView.findMode.fromDataSouse;
            this.m_txtBedNo.Location = new System.Drawing.Point(282, 22);
            this.m_txtBedNo.m_blnFocuseShow = true;
            this.m_txtBedNo.m_blnPagination = false;
            this.m_txtBedNo.m_dtbDataSourse = null;
            this.m_txtBedNo.m_intDelayTime = 100;
            this.m_txtBedNo.m_intPageRows = 10;
            this.m_txtBedNo.m_ListViewAlign = ControlLibrary.txtListView.ListViewAlign.LeftBottom;
            this.m_txtBedNo.m_listViewSize = new System.Drawing.Point(260, 100);
            this.m_txtBedNo.m_strFieldsArr = new string[] {
        "code_chr"};
            this.m_txtBedNo.m_strSaveField = "bedid_chr";
            this.m_txtBedNo.m_strShowField = "code_chr";
            this.m_txtBedNo.m_strSQL = null;
            this.m_txtBedNo.Name = "m_txtBedNo";
            this.m_txtBedNo.Size = new System.Drawing.Size(73, 23);
            this.m_txtBedNo.TabIndex = 5;
            // 
            // frmOrderBookingAdvSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 269);
            this.Controls.Add(this.m_txtBedNo);
            this.Controls.Add(this.m_cmdReset);
            this.Controls.Add(this.m_txtApplyType);
            this.Controls.Add(this.m_txtInpatienId);
            this.Controls.Add(this.m_cmdOk);
            this.Controls.Add(this.m_cmdReturn);
            this.Controls.Add(this.m_ckbStatus);
            this.Controls.Add(this.m_cmbStatus);
            this.Controls.Add(this.m_lblBookTo);
            this.Controls.Add(this.m_dtpBookBgnDate);
            this.Controls.Add(this.m_dtpBookEndDate);
            this.Controls.Add(this.m_ckbBookDate);
            this.Controls.Add(this.m_ckbApplyType);
            this.Controls.Add(this.m_lblOprTo);
            this.Controls.Add(this.m_dtpOprBgnDate);
            this.Controls.Add(this.m_dtpOprEndDate);
            this.Controls.Add(this.m_ckbOperateDate);
            this.Controls.Add(this.m_chbInpatientId);
            this.Controls.Add(this.m_cobSex);
            this.Controls.Add(this.m_ckbSex);
            this.Controls.Add(this.m_txtName);
            this.Controls.Add(this.m_ckbName);
            this.Controls.Add(this.m_ckbBedNo);
            this.Controls.Add(this.m_txtArea);
            this.Controls.Add(this.m_ckbArea);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KeyPreview = true;
            this.Name = "frmOrderBookingAdvSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "高级查询";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmOrderBookingAdvSearch_KeyDown);
            this.Load += new System.EventHandler(this.frmOrderBookingAdvSearch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.CheckBox m_ckbArea;
        internal ControlLibrary.txtListView m_txtArea;
        internal System.Windows.Forms.CheckBox m_ckbBedNo;
        internal System.Windows.Forms.CheckBox m_ckbName;
        internal System.Windows.Forms.TextBox m_txtName;
        internal System.Windows.Forms.CheckBox m_ckbSex;
        internal System.Windows.Forms.ComboBox m_cobSex;
        internal System.Windows.Forms.CheckBox m_chbInpatientId;
        internal System.Windows.Forms.CheckBox m_ckbOperateDate;
        internal NullableDateControls.MaskDateEdit m_dtpOprBgnDate;
        internal NullableDateControls.MaskDateEdit m_dtpOprEndDate;
        internal System.Windows.Forms.Label m_lblOprTo;
        internal System.Windows.Forms.CheckBox m_ckbApplyType;
        internal ControlLibrary.txtListView m_txtApplyType;
        internal System.Windows.Forms.Label m_lblBookTo;
        internal NullableDateControls.MaskDateEdit m_dtpBookBgnDate;
        internal NullableDateControls.MaskDateEdit m_dtpBookEndDate;
        internal System.Windows.Forms.CheckBox m_ckbBookDate;
        internal System.Windows.Forms.ComboBox m_cmbStatus;
        internal System.Windows.Forms.CheckBox m_ckbStatus;
        private PinkieControls.ButtonXP m_cmdOk;
        private PinkieControls.ButtonXP m_cmdReturn;
        internal System.Windows.Forms.TextBox m_txtInpatienId;
        private PinkieControls.ButtonXP m_cmdReset;
        internal ControlLibrary.txtListView m_txtBedNo;
    }
}