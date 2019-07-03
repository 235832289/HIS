namespace iCare
{
    partial class frmIntakeAndOutputVolumeSummary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIntakeAndOutputVolumeSummary));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_txtAllIntake = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtAllOutput = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtSpecificGravity = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtAllUrine = new com.digitalwave.controls.ctlRichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cmdEmployeeSign = new PinkieControls.ButtonXP();
            this.lsvSign = new System.Windows.Forms.ListView();
            this.clmEmployeeName = new System.Windows.Forms.ColumnHeader();
            this.btnCancel = new PinkieControls.ButtonXP();
            this.btnConfirm = new PinkieControls.ButtonXP();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_trvCreateDate
            // 
            this.m_trvCreateDate.LineColor = System.Drawing.Color.Black;
            this.m_trvCreateDate.Location = new System.Drawing.Point(37, 68);
            this.m_trvCreateDate.Size = new System.Drawing.Size(180, 51);
            this.m_trvCreateDate.Visible = false;
            // 
            // lblCreateDateTitle
            // 
            this.lblCreateDateTitle.Location = new System.Drawing.Point(13, 12);
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.CustomFormat = "yyyy年MM月dd日         ";
            this.m_dtpCreateDate.Location = new System.Drawing.Point(87, 6);
            this.m_dtpCreateDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Day;
            this.m_dtpCreateDate.Size = new System.Drawing.Size(148, 22);
            // 
            // m_dtpGetDataTime
            // 
            this.m_dtpGetDataTime.Location = new System.Drawing.Point(106, 89);
            this.m_dtpGetDataTime.Size = new System.Drawing.Size(247, 22);
            // 
            // m_lblGetDataTime
            // 
            this.m_lblGetDataTime.Location = new System.Drawing.Point(93, 85);
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(332, 117);
            this.lblSex.Size = new System.Drawing.Size(56, 22);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(332, 131);
            this.lblAge.Size = new System.Drawing.Size(61, 22);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(75, 94);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(61, 131);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(276, 94);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(276, 117);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(276, 131);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(37, 93);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(327, 79);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(135, 121);
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(127, 126);
            this.txtInPatientID.Size = new System.Drawing.Size(135, 23);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(218, 93);
            this.m_txtPatientName.Size = new System.Drawing.Size(135, 23);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(127, 89);
            this.m_txtBedNO.Size = new System.Drawing.Size(135, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(93, 89);
            this.m_cboArea.Size = new System.Drawing.Size(168, 23);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(527, 42);
            this.m_lsvPatientName.Size = new System.Drawing.Size(135, 121);
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(327, 38);
            this.m_lsvBedNO.Size = new System.Drawing.Size(135, 121);
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(93, 47);
            this.m_cboDept.Size = new System.Drawing.Size(168, 23);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(37, 56);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(821, 56);
            this.m_cmdNewTemplate.Size = new System.Drawing.Size(98, 37);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Location = new System.Drawing.Point(337, 56);
            this.m_cmdNext.Size = new System.Drawing.Size(28, 24);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(290, 56);
            this.m_cmdPre.Size = new System.Drawing.Size(28, 24);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(117, 94);
            this.m_lblForTitle.Size = new System.Drawing.Size(19, 27);
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(315, 7);
            this.chkModifyWithoutMatk.Size = new System.Drawing.Size(103, 28);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(290, -34);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(9, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 132);
            this.panel1.TabIndex = 10000005;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.m_txtAllIntake);
            this.groupBox1.Controls.Add(this.m_txtAllOutput);
            this.groupBox1.Controls.Add(this.m_txtSpecificGravity);
            this.groupBox1.Controls.Add(this.m_txtAllUrine);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(5, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 123);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "总结";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(0, 77);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(411, 1);
            this.panel2.TabIndex = 10000;
            // 
            // m_txtAllIntake
            // 
            this.m_txtAllIntake.AccessibleDescription = "总入量";
            this.m_txtAllIntake.BackColor = System.Drawing.Color.White;
            this.m_txtAllIntake.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtAllIntake.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtAllIntake.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtAllIntake.Location = new System.Drawing.Point(64, 89);
            this.m_txtAllIntake.m_BlnIgnoreUserInfo = false;
            this.m_txtAllIntake.m_BlnPartControl = false;
            this.m_txtAllIntake.m_BlnReadOnly = false;
            this.m_txtAllIntake.m_BlnUnderLineDST = false;
            this.m_txtAllIntake.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtAllIntake.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtAllIntake.m_IntCanModifyTime = 6;
            this.m_txtAllIntake.m_IntPartControlLength = 0;
            this.m_txtAllIntake.m_IntPartControlStartIndex = 0;
            this.m_txtAllIntake.m_StrUserID = "";
            this.m_txtAllIntake.m_StrUserName = "";
            this.m_txtAllIntake.MaxLength = 50;
            this.m_txtAllIntake.Multiline = false;
            this.m_txtAllIntake.Name = "m_txtAllIntake";
            this.m_txtAllIntake.Size = new System.Drawing.Size(113, 22);
            this.m_txtAllIntake.TabIndex = 40;
            this.m_txtAllIntake.Text = "";
            // 
            // m_txtAllOutput
            // 
            this.m_txtAllOutput.AccessibleDescription = "总出量";
            this.m_txtAllOutput.BackColor = System.Drawing.Color.White;
            this.m_txtAllOutput.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtAllOutput.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtAllOutput.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtAllOutput.Location = new System.Drawing.Point(64, 45);
            this.m_txtAllOutput.m_BlnIgnoreUserInfo = false;
            this.m_txtAllOutput.m_BlnPartControl = false;
            this.m_txtAllOutput.m_BlnReadOnly = false;
            this.m_txtAllOutput.m_BlnUnderLineDST = false;
            this.m_txtAllOutput.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtAllOutput.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtAllOutput.m_IntCanModifyTime = 6;
            this.m_txtAllOutput.m_IntPartControlLength = 0;
            this.m_txtAllOutput.m_IntPartControlStartIndex = 0;
            this.m_txtAllOutput.m_StrUserID = "";
            this.m_txtAllOutput.m_StrUserName = "";
            this.m_txtAllOutput.MaxLength = 50;
            this.m_txtAllOutput.Multiline = false;
            this.m_txtAllOutput.Name = "m_txtAllOutput";
            this.m_txtAllOutput.Size = new System.Drawing.Size(113, 22);
            this.m_txtAllOutput.TabIndex = 20;
            this.m_txtAllOutput.Text = "";
            // 
            // m_txtSpecificGravity
            // 
            this.m_txtSpecificGravity.AccessibleDescription = "出量比重";
            this.m_txtSpecificGravity.BackColor = System.Drawing.Color.White;
            this.m_txtSpecificGravity.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSpecificGravity.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtSpecificGravity.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSpecificGravity.Location = new System.Drawing.Point(292, 45);
            this.m_txtSpecificGravity.m_BlnIgnoreUserInfo = false;
            this.m_txtSpecificGravity.m_BlnPartControl = false;
            this.m_txtSpecificGravity.m_BlnReadOnly = false;
            this.m_txtSpecificGravity.m_BlnUnderLineDST = false;
            this.m_txtSpecificGravity.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSpecificGravity.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSpecificGravity.m_IntCanModifyTime = 6;
            this.m_txtSpecificGravity.m_IntPartControlLength = 0;
            this.m_txtSpecificGravity.m_IntPartControlStartIndex = 0;
            this.m_txtSpecificGravity.m_StrUserID = "";
            this.m_txtSpecificGravity.m_StrUserName = "";
            this.m_txtSpecificGravity.MaxLength = 50;
            this.m_txtSpecificGravity.Multiline = false;
            this.m_txtSpecificGravity.Name = "m_txtSpecificGravity";
            this.m_txtSpecificGravity.Size = new System.Drawing.Size(112, 22);
            this.m_txtSpecificGravity.TabIndex = 30;
            this.m_txtSpecificGravity.Text = "";
            // 
            // m_txtAllUrine
            // 
            this.m_txtAllUrine.AccessibleDescription = "尿总量";
            this.m_txtAllUrine.BackColor = System.Drawing.Color.White;
            this.m_txtAllUrine.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtAllUrine.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtAllUrine.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtAllUrine.Location = new System.Drawing.Point(252, 15);
            this.m_txtAllUrine.m_BlnIgnoreUserInfo = false;
            this.m_txtAllUrine.m_BlnPartControl = false;
            this.m_txtAllUrine.m_BlnReadOnly = false;
            this.m_txtAllUrine.m_BlnUnderLineDST = false;
            this.m_txtAllUrine.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtAllUrine.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtAllUrine.m_IntCanModifyTime = 6;
            this.m_txtAllUrine.m_IntPartControlLength = 0;
            this.m_txtAllUrine.m_IntPartControlStartIndex = 0;
            this.m_txtAllUrine.m_StrUserID = "";
            this.m_txtAllUrine.m_StrUserName = "";
            this.m_txtAllUrine.MaxLength = 50;
            this.m_txtAllUrine.Multiline = false;
            this.m_txtAllUrine.Name = "m_txtAllUrine";
            this.m_txtAllUrine.Size = new System.Drawing.Size(113, 22);
            this.m_txtAllUrine.TabIndex = 10;
            this.m_txtAllUrine.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(249, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 14);
            this.label5.TabIndex = 10000;
            this.label5.Text = "比重:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(182, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 14);
            this.label7.TabIndex = 10000;
            this.label7.Text = "毫升";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(182, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 10000;
            this.label4.Text = "毫升";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 14);
            this.label6.TabIndex = 10000;
            this.label6.Text = "总入量:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(369, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 10000;
            this.label2.Text = "毫升";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 14);
            this.label3.TabIndex = 10000;
            this.label3.Text = "总出量:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(163, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 14);
            this.label1.TabIndex = 10000;
            this.label1.Text = "其中尿总量:";
            // 
            // m_cmdEmployeeSign
            // 
            this.m_cmdEmployeeSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdEmployeeSign.DefaultScheme = true;
            this.m_cmdEmployeeSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdEmployeeSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdEmployeeSign.ForeColor = System.Drawing.Color.Black;
            this.m_cmdEmployeeSign.Hint = "";
            this.m_cmdEmployeeSign.Location = new System.Drawing.Point(9, 170);
            this.m_cmdEmployeeSign.Name = "m_cmdEmployeeSign";
            this.m_cmdEmployeeSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdEmployeeSign.Size = new System.Drawing.Size(48, 28);
            this.m_cmdEmployeeSign.TabIndex = 10000034;
            this.m_cmdEmployeeSign.Tag = "1";
            this.m_cmdEmployeeSign.Text = "签名:";
            // 
            // lsvSign
            // 
            this.lsvSign.BackColor = System.Drawing.Color.White;
            this.lsvSign.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmEmployeeName});
            this.lsvSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvSign.ForeColor = System.Drawing.Color.Black;
            this.lsvSign.FullRowSelect = true;
            this.lsvSign.GridLines = true;
            this.lsvSign.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvSign.Location = new System.Drawing.Point(63, 170);
            this.lsvSign.Name = "lsvSign";
            this.lsvSign.Size = new System.Drawing.Size(225, 28);
            this.lsvSign.TabIndex = 10000035;
            this.lsvSign.UseCompatibleStateImageBehavior = false;
            this.lsvSign.View = System.Windows.Forms.View.SmallIcon;
            // 
            // clmEmployeeName
            // 
            this.clmEmployeeName.Width = 55;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnCancel.DefaultScheme = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Hint = "";
            this.btnCancel.Location = new System.Drawing.Point(378, 170);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnCancel.Size = new System.Drawing.Size(50, 28);
            this.btnCancel.TabIndex = 10000033;
            this.btnCancel.Tag = "1";
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnConfirm.DefaultScheme = true;
            this.btnConfirm.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnConfirm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.ForeColor = System.Drawing.Color.Black;
            this.btnConfirm.Hint = "";
            this.btnConfirm.Location = new System.Drawing.Point(315, 170);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnConfirm.Size = new System.Drawing.Size(50, 28);
            this.btnConfirm.TabIndex = 10000032;
            this.btnConfirm.Tag = "1";
            this.btnConfirm.Text = "确定";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // frmIntakeAndOutputVolumeSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 209);
            this.Controls.Add(this.m_cmdEmployeeSign);
            this.Controls.Add(this.lsvSign);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmIntakeAndOutputVolumeSummary";
            this.Text = "出入量登记表总结";
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.m_trvCreateDate, 0);
            this.Controls.SetChildIndex(this.m_lblGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_dtpGetDataTime, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.lblCreateDateTitle, 0);
            this.Controls.SetChildIndex(this.m_dtpCreateDate, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.btnConfirm, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.lsvSign, 0);
            this.Controls.SetChildIndex(this.m_cmdEmployeeSign, 0);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private com.digitalwave.controls.ctlRichTextBox m_txtAllOutput;
        private com.digitalwave.controls.ctlRichTextBox m_txtAllUrine;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private com.digitalwave.controls.ctlRichTextBox m_txtAllIntake;
        private com.digitalwave.controls.ctlRichTextBox m_txtSpecificGravity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private PinkieControls.ButtonXP m_cmdEmployeeSign;
        protected System.Windows.Forms.ListView lsvSign;
        private System.Windows.Forms.ColumnHeader clmEmployeeName;
        private PinkieControls.ButtonXP btnCancel;
        private PinkieControls.ButtonXP btnConfirm;
    }
}