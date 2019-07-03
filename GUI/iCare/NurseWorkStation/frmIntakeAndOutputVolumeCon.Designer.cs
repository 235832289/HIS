namespace iCare
{
    partial class frmIntakeAndOutputVolumeCon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIntakeAndOutputVolumeCon));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_txtOtherOutput = new com.digitalwave.controls.ctlRichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.m_txtChestFluid = new com.digitalwave.controls.ctlRichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_txtIntestinalJuice = new com.digitalwave.controls.ctlRichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtBile = new com.digitalwave.controls.ctlRichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txtGastrisJuice = new com.digitalwave.controls.ctlRichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtUrine = new com.digitalwave.controls.ctlRichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtStool = new com.digitalwave.controls.ctlRichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_txtOtherIntake = new com.digitalwave.controls.ctlRichTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.m_txtSalineWater = new com.digitalwave.controls.ctlRichTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.m_txtSugarWater = new com.digitalwave.controls.ctlRichTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.m_txtTransfusion = new com.digitalwave.controls.ctlRichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.m_txtFood = new com.digitalwave.controls.ctlRichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.m_txtDrinkingWater = new com.digitalwave.controls.ctlRichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.m_cboRecordTime = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.btnCancel = new PinkieControls.ButtonXP();
            this.btnConfirm = new PinkieControls.ButtonXP();
            this.m_cmdSign = new PinkieControls.ButtonXP();
            this.lsvSign = new System.Windows.Forms.ListView();
            this.clmEmployeeName = new System.Windows.Forms.ColumnHeader();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_trvCreateDate
            // 
            this.m_trvCreateDate.LineColor = System.Drawing.Color.Black;
            this.m_trvCreateDate.Location = new System.Drawing.Point(36, 62);
            this.m_trvCreateDate.Size = new System.Drawing.Size(247, 68);
            this.m_trvCreateDate.Visible = false;
            // 
            // lblCreateDateTitle
            // 
            this.lblCreateDateTitle.Location = new System.Drawing.Point(15, 10);
            this.lblCreateDateTitle.Size = new System.Drawing.Size(42, 14);
            this.lblCreateDateTitle.Text = "日期:";
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.CustomFormat = "yyyy年MM月dd日         ";
            this.m_dtpCreateDate.Location = new System.Drawing.Point(59, 5);
            this.m_dtpCreateDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Day;
            this.m_dtpCreateDate.Size = new System.Drawing.Size(147, 22);
            // 
            // m_dtpGetDataTime
            // 
            this.m_dtpGetDataTime.Location = new System.Drawing.Point(182, 84);
            this.m_dtpGetDataTime.Size = new System.Drawing.Size(247, 22);
            // 
            // m_lblGetDataTime
            // 
            this.m_lblGetDataTime.Location = new System.Drawing.Point(60, 84);
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(255, 125);
            this.lblSex.Size = new System.Drawing.Size(56, 22);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(368, 125);
            this.lblAge.Size = new System.Drawing.Size(61, 22);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(275, 51);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(261, 88);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(266, 117);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(199, 125);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(325, 125);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(37, 125);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(327, 79);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(135, 121);
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(327, 83);
            this.txtInPatientID.Size = new System.Drawing.Size(135, 23);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(317, 112);
            this.m_txtPatientName.Size = new System.Drawing.Size(135, 23);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(327, 46);
            this.m_txtBedNO.Size = new System.Drawing.Size(135, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(93, 121);
            this.m_cboArea.Size = new System.Drawing.Size(162, 23);
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
            this.m_cboDept.Location = new System.Drawing.Point(93, 79);
            this.m_cboDept.Size = new System.Drawing.Size(162, 23);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(37, 88);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(821, 56);
            this.m_cmdNewTemplate.Size = new System.Drawing.Size(98, 37);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Location = new System.Drawing.Point(229, 46);
            this.m_cmdNext.Size = new System.Drawing.Size(28, 24);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(182, 46);
            this.m_cmdPre.Size = new System.Drawing.Size(28, 24);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(317, 51);
            this.m_lblForTitle.Size = new System.Drawing.Size(19, 27);
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(398, 3);
            this.chkModifyWithoutMatk.Size = new System.Drawing.Size(86, 28);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(393, -33);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Location = new System.Drawing.Point(6, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(512, 231);
            this.panel1.TabIndex = 10000005;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_txtOtherOutput);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.m_txtChestFluid);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.m_txtIntestinalJuice);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.m_txtBile);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.m_txtGastrisJuice);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.m_txtUrine);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.m_txtStool);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 220);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "出量";
            // 
            // m_txtOtherOutput
            // 
            this.m_txtOtherOutput.AccessibleDescription = "其他出量";
            this.m_txtOtherOutput.BackColor = System.Drawing.Color.White;
            this.m_txtOtherOutput.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOtherOutput.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtOtherOutput.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOtherOutput.Location = new System.Drawing.Point(51, 192);
            this.m_txtOtherOutput.m_BlnIgnoreUserInfo = false;
            this.m_txtOtherOutput.m_BlnPartControl = false;
            this.m_txtOtherOutput.m_BlnReadOnly = false;
            this.m_txtOtherOutput.m_BlnUnderLineDST = false;
            this.m_txtOtherOutput.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOtherOutput.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOtherOutput.m_IntCanModifyTime = 6;
            this.m_txtOtherOutput.m_IntPartControlLength = 0;
            this.m_txtOtherOutput.m_IntPartControlStartIndex = 0;
            this.m_txtOtherOutput.m_StrUserID = "";
            this.m_txtOtherOutput.m_StrUserName = "";
            this.m_txtOtherOutput.MaxLength = 50;
            this.m_txtOtherOutput.Multiline = false;
            this.m_txtOtherOutput.Name = "m_txtOtherOutput";
            this.m_txtOtherOutput.Size = new System.Drawing.Size(176, 22);
            this.m_txtOtherOutput.TabIndex = 70;
            this.m_txtOtherOutput.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 14);
            this.label7.TabIndex = 10000027;
            this.label7.Text = "其他:";
            // 
            // m_txtChestFluid
            // 
            this.m_txtChestFluid.AccessibleDescription = "胸液";
            this.m_txtChestFluid.BackColor = System.Drawing.Color.White;
            this.m_txtChestFluid.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtChestFluid.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtChestFluid.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtChestFluid.Location = new System.Drawing.Point(51, 163);
            this.m_txtChestFluid.m_BlnIgnoreUserInfo = false;
            this.m_txtChestFluid.m_BlnPartControl = false;
            this.m_txtChestFluid.m_BlnReadOnly = false;
            this.m_txtChestFluid.m_BlnUnderLineDST = false;
            this.m_txtChestFluid.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtChestFluid.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtChestFluid.m_IntCanModifyTime = 6;
            this.m_txtChestFluid.m_IntPartControlLength = 0;
            this.m_txtChestFluid.m_IntPartControlStartIndex = 0;
            this.m_txtChestFluid.m_StrUserID = "";
            this.m_txtChestFluid.m_StrUserName = "";
            this.m_txtChestFluid.MaxLength = 50;
            this.m_txtChestFluid.Multiline = false;
            this.m_txtChestFluid.Name = "m_txtChestFluid";
            this.m_txtChestFluid.Size = new System.Drawing.Size(176, 22);
            this.m_txtChestFluid.TabIndex = 60;
            this.m_txtChestFluid.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 14);
            this.label6.TabIndex = 10000027;
            this.label6.Text = "胸液:";
            // 
            // m_txtIntestinalJuice
            // 
            this.m_txtIntestinalJuice.AccessibleDescription = "肠液";
            this.m_txtIntestinalJuice.BackColor = System.Drawing.Color.White;
            this.m_txtIntestinalJuice.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtIntestinalJuice.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtIntestinalJuice.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtIntestinalJuice.Location = new System.Drawing.Point(51, 134);
            this.m_txtIntestinalJuice.m_BlnIgnoreUserInfo = false;
            this.m_txtIntestinalJuice.m_BlnPartControl = false;
            this.m_txtIntestinalJuice.m_BlnReadOnly = false;
            this.m_txtIntestinalJuice.m_BlnUnderLineDST = false;
            this.m_txtIntestinalJuice.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtIntestinalJuice.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtIntestinalJuice.m_IntCanModifyTime = 6;
            this.m_txtIntestinalJuice.m_IntPartControlLength = 0;
            this.m_txtIntestinalJuice.m_IntPartControlStartIndex = 0;
            this.m_txtIntestinalJuice.m_StrUserID = "";
            this.m_txtIntestinalJuice.m_StrUserName = "";
            this.m_txtIntestinalJuice.MaxLength = 50;
            this.m_txtIntestinalJuice.Multiline = false;
            this.m_txtIntestinalJuice.Name = "m_txtIntestinalJuice";
            this.m_txtIntestinalJuice.Size = new System.Drawing.Size(176, 22);
            this.m_txtIntestinalJuice.TabIndex = 50;
            this.m_txtIntestinalJuice.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 14);
            this.label5.TabIndex = 10000027;
            this.label5.Text = "肠液:";
            // 
            // m_txtBile
            // 
            this.m_txtBile.AccessibleDescription = "胆汁";
            this.m_txtBile.BackColor = System.Drawing.Color.White;
            this.m_txtBile.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBile.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBile.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBile.Location = new System.Drawing.Point(51, 105);
            this.m_txtBile.m_BlnIgnoreUserInfo = false;
            this.m_txtBile.m_BlnPartControl = false;
            this.m_txtBile.m_BlnReadOnly = false;
            this.m_txtBile.m_BlnUnderLineDST = false;
            this.m_txtBile.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBile.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBile.m_IntCanModifyTime = 6;
            this.m_txtBile.m_IntPartControlLength = 0;
            this.m_txtBile.m_IntPartControlStartIndex = 0;
            this.m_txtBile.m_StrUserID = "";
            this.m_txtBile.m_StrUserName = "";
            this.m_txtBile.MaxLength = 50;
            this.m_txtBile.Multiline = false;
            this.m_txtBile.Name = "m_txtBile";
            this.m_txtBile.Size = new System.Drawing.Size(176, 22);
            this.m_txtBile.TabIndex = 40;
            this.m_txtBile.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 14);
            this.label4.TabIndex = 10000027;
            this.label4.Text = "胆汁:";
            // 
            // m_txtGastrisJuice
            // 
            this.m_txtGastrisJuice.AccessibleDescription = "胃液";
            this.m_txtGastrisJuice.BackColor = System.Drawing.Color.White;
            this.m_txtGastrisJuice.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtGastrisJuice.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtGastrisJuice.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtGastrisJuice.Location = new System.Drawing.Point(51, 76);
            this.m_txtGastrisJuice.m_BlnIgnoreUserInfo = false;
            this.m_txtGastrisJuice.m_BlnPartControl = false;
            this.m_txtGastrisJuice.m_BlnReadOnly = false;
            this.m_txtGastrisJuice.m_BlnUnderLineDST = false;
            this.m_txtGastrisJuice.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtGastrisJuice.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtGastrisJuice.m_IntCanModifyTime = 6;
            this.m_txtGastrisJuice.m_IntPartControlLength = 0;
            this.m_txtGastrisJuice.m_IntPartControlStartIndex = 0;
            this.m_txtGastrisJuice.m_StrUserID = "";
            this.m_txtGastrisJuice.m_StrUserName = "";
            this.m_txtGastrisJuice.MaxLength = 50;
            this.m_txtGastrisJuice.Multiline = false;
            this.m_txtGastrisJuice.Name = "m_txtGastrisJuice";
            this.m_txtGastrisJuice.Size = new System.Drawing.Size(176, 22);
            this.m_txtGastrisJuice.TabIndex = 30;
            this.m_txtGastrisJuice.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 14);
            this.label3.TabIndex = 10000027;
            this.label3.Text = "胃液:";
            // 
            // m_txtUrine
            // 
            this.m_txtUrine.AccessibleDescription = "小便";
            this.m_txtUrine.BackColor = System.Drawing.Color.White;
            this.m_txtUrine.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtUrine.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtUrine.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtUrine.Location = new System.Drawing.Point(51, 47);
            this.m_txtUrine.m_BlnIgnoreUserInfo = false;
            this.m_txtUrine.m_BlnPartControl = false;
            this.m_txtUrine.m_BlnReadOnly = false;
            this.m_txtUrine.m_BlnUnderLineDST = false;
            this.m_txtUrine.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtUrine.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtUrine.m_IntCanModifyTime = 6;
            this.m_txtUrine.m_IntPartControlLength = 0;
            this.m_txtUrine.m_IntPartControlStartIndex = 0;
            this.m_txtUrine.m_StrUserID = "";
            this.m_txtUrine.m_StrUserName = "";
            this.m_txtUrine.MaxLength = 50;
            this.m_txtUrine.Multiline = false;
            this.m_txtUrine.Name = "m_txtUrine";
            this.m_txtUrine.Size = new System.Drawing.Size(176, 22);
            this.m_txtUrine.TabIndex = 20;
            this.m_txtUrine.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 14);
            this.label2.TabIndex = 10000027;
            this.label2.Text = "小便:";
            // 
            // m_txtStool
            // 
            this.m_txtStool.AccessibleDescription = "大便";
            this.m_txtStool.BackColor = System.Drawing.Color.White;
            this.m_txtStool.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtStool.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtStool.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtStool.Location = new System.Drawing.Point(51, 18);
            this.m_txtStool.m_BlnIgnoreUserInfo = false;
            this.m_txtStool.m_BlnPartControl = false;
            this.m_txtStool.m_BlnReadOnly = false;
            this.m_txtStool.m_BlnUnderLineDST = false;
            this.m_txtStool.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtStool.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtStool.m_IntCanModifyTime = 6;
            this.m_txtStool.m_IntPartControlLength = 0;
            this.m_txtStool.m_IntPartControlStartIndex = 0;
            this.m_txtStool.m_StrUserID = "";
            this.m_txtStool.m_StrUserName = "";
            this.m_txtStool.MaxLength = 50;
            this.m_txtStool.Multiline = false;
            this.m_txtStool.Name = "m_txtStool";
            this.m_txtStool.Size = new System.Drawing.Size(176, 22);
            this.m_txtStool.TabIndex = 10;
            this.m_txtStool.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 10000027;
            this.label1.Text = "大便:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_txtOtherIntake);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.m_txtSalineWater);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.m_txtSugarWater);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.m_txtTransfusion);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.m_txtFood);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.m_txtDrinkingWater);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(267, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(233, 190);
            this.groupBox2.TabIndex = 80;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "入量";
            // 
            // m_txtOtherIntake
            // 
            this.m_txtOtherIntake.AccessibleDescription = "其他入量";
            this.m_txtOtherIntake.BackColor = System.Drawing.Color.White;
            this.m_txtOtherIntake.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOtherIntake.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtOtherIntake.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOtherIntake.Location = new System.Drawing.Point(51, 163);
            this.m_txtOtherIntake.m_BlnIgnoreUserInfo = false;
            this.m_txtOtherIntake.m_BlnPartControl = false;
            this.m_txtOtherIntake.m_BlnReadOnly = false;
            this.m_txtOtherIntake.m_BlnUnderLineDST = false;
            this.m_txtOtherIntake.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOtherIntake.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOtherIntake.m_IntCanModifyTime = 6;
            this.m_txtOtherIntake.m_IntPartControlLength = 0;
            this.m_txtOtherIntake.m_IntPartControlStartIndex = 0;
            this.m_txtOtherIntake.m_StrUserID = "";
            this.m_txtOtherIntake.m_StrUserName = "";
            this.m_txtOtherIntake.MaxLength = 50;
            this.m_txtOtherIntake.Multiline = false;
            this.m_txtOtherIntake.Name = "m_txtOtherIntake";
            this.m_txtOtherIntake.Size = new System.Drawing.Size(176, 22);
            this.m_txtOtherIntake.TabIndex = 140;
            this.m_txtOtherIntake.Text = "";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 167);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 14);
            this.label13.TabIndex = 10000030;
            this.label13.Text = "其他:";
            // 
            // m_txtSalineWater
            // 
            this.m_txtSalineWater.AccessibleDescription = "盐水";
            this.m_txtSalineWater.BackColor = System.Drawing.Color.White;
            this.m_txtSalineWater.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSalineWater.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtSalineWater.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSalineWater.Location = new System.Drawing.Point(51, 134);
            this.m_txtSalineWater.m_BlnIgnoreUserInfo = false;
            this.m_txtSalineWater.m_BlnPartControl = false;
            this.m_txtSalineWater.m_BlnReadOnly = false;
            this.m_txtSalineWater.m_BlnUnderLineDST = false;
            this.m_txtSalineWater.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSalineWater.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSalineWater.m_IntCanModifyTime = 6;
            this.m_txtSalineWater.m_IntPartControlLength = 0;
            this.m_txtSalineWater.m_IntPartControlStartIndex = 0;
            this.m_txtSalineWater.m_StrUserID = "";
            this.m_txtSalineWater.m_StrUserName = "";
            this.m_txtSalineWater.MaxLength = 50;
            this.m_txtSalineWater.Multiline = false;
            this.m_txtSalineWater.Name = "m_txtSalineWater";
            this.m_txtSalineWater.Size = new System.Drawing.Size(176, 22);
            this.m_txtSalineWater.TabIndex = 130;
            this.m_txtSalineWater.Text = "";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 138);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 14);
            this.label12.TabIndex = 10000028;
            this.label12.Text = "盐水:";
            // 
            // m_txtSugarWater
            // 
            this.m_txtSugarWater.AccessibleDescription = "糖水";
            this.m_txtSugarWater.BackColor = System.Drawing.Color.White;
            this.m_txtSugarWater.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSugarWater.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtSugarWater.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSugarWater.Location = new System.Drawing.Point(51, 105);
            this.m_txtSugarWater.m_BlnIgnoreUserInfo = false;
            this.m_txtSugarWater.m_BlnPartControl = false;
            this.m_txtSugarWater.m_BlnReadOnly = false;
            this.m_txtSugarWater.m_BlnUnderLineDST = false;
            this.m_txtSugarWater.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSugarWater.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSugarWater.m_IntCanModifyTime = 6;
            this.m_txtSugarWater.m_IntPartControlLength = 0;
            this.m_txtSugarWater.m_IntPartControlStartIndex = 0;
            this.m_txtSugarWater.m_StrUserID = "";
            this.m_txtSugarWater.m_StrUserName = "";
            this.m_txtSugarWater.MaxLength = 50;
            this.m_txtSugarWater.Multiline = false;
            this.m_txtSugarWater.Name = "m_txtSugarWater";
            this.m_txtSugarWater.Size = new System.Drawing.Size(176, 22);
            this.m_txtSugarWater.TabIndex = 120;
            this.m_txtSugarWater.Text = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 109);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 14);
            this.label11.TabIndex = 10000028;
            this.label11.Text = "糖水:";
            // 
            // m_txtTransfusion
            // 
            this.m_txtTransfusion.AccessibleDescription = "输血";
            this.m_txtTransfusion.BackColor = System.Drawing.Color.White;
            this.m_txtTransfusion.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtTransfusion.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtTransfusion.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtTransfusion.Location = new System.Drawing.Point(51, 76);
            this.m_txtTransfusion.m_BlnIgnoreUserInfo = false;
            this.m_txtTransfusion.m_BlnPartControl = false;
            this.m_txtTransfusion.m_BlnReadOnly = false;
            this.m_txtTransfusion.m_BlnUnderLineDST = false;
            this.m_txtTransfusion.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtTransfusion.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtTransfusion.m_IntCanModifyTime = 6;
            this.m_txtTransfusion.m_IntPartControlLength = 0;
            this.m_txtTransfusion.m_IntPartControlStartIndex = 0;
            this.m_txtTransfusion.m_StrUserID = "";
            this.m_txtTransfusion.m_StrUserName = "";
            this.m_txtTransfusion.MaxLength = 50;
            this.m_txtTransfusion.Multiline = false;
            this.m_txtTransfusion.Name = "m_txtTransfusion";
            this.m_txtTransfusion.Size = new System.Drawing.Size(176, 22);
            this.m_txtTransfusion.TabIndex = 110;
            this.m_txtTransfusion.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 14);
            this.label10.TabIndex = 10000028;
            this.label10.Text = "输血:";
            // 
            // m_txtFood
            // 
            this.m_txtFood.AccessibleDescription = "食物";
            this.m_txtFood.BackColor = System.Drawing.Color.White;
            this.m_txtFood.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtFood.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtFood.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtFood.Location = new System.Drawing.Point(51, 47);
            this.m_txtFood.m_BlnIgnoreUserInfo = false;
            this.m_txtFood.m_BlnPartControl = false;
            this.m_txtFood.m_BlnReadOnly = false;
            this.m_txtFood.m_BlnUnderLineDST = false;
            this.m_txtFood.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtFood.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtFood.m_IntCanModifyTime = 6;
            this.m_txtFood.m_IntPartControlLength = 0;
            this.m_txtFood.m_IntPartControlStartIndex = 0;
            this.m_txtFood.m_StrUserID = "";
            this.m_txtFood.m_StrUserName = "";
            this.m_txtFood.MaxLength = 50;
            this.m_txtFood.Multiline = false;
            this.m_txtFood.Name = "m_txtFood";
            this.m_txtFood.Size = new System.Drawing.Size(176, 22);
            this.m_txtFood.TabIndex = 100;
            this.m_txtFood.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 14);
            this.label9.TabIndex = 10000028;
            this.label9.Text = "食物:";
            // 
            // m_txtDrinkingWater
            // 
            this.m_txtDrinkingWater.AccessibleDescription = "饮水";
            this.m_txtDrinkingWater.BackColor = System.Drawing.Color.White;
            this.m_txtDrinkingWater.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDrinkingWater.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtDrinkingWater.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDrinkingWater.Location = new System.Drawing.Point(51, 18);
            this.m_txtDrinkingWater.m_BlnIgnoreUserInfo = false;
            this.m_txtDrinkingWater.m_BlnPartControl = false;
            this.m_txtDrinkingWater.m_BlnReadOnly = false;
            this.m_txtDrinkingWater.m_BlnUnderLineDST = false;
            this.m_txtDrinkingWater.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDrinkingWater.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDrinkingWater.m_IntCanModifyTime = 6;
            this.m_txtDrinkingWater.m_IntPartControlLength = 0;
            this.m_txtDrinkingWater.m_IntPartControlStartIndex = 0;
            this.m_txtDrinkingWater.m_StrUserID = "";
            this.m_txtDrinkingWater.m_StrUserName = "";
            this.m_txtDrinkingWater.MaxLength = 50;
            this.m_txtDrinkingWater.Multiline = false;
            this.m_txtDrinkingWater.Name = "m_txtDrinkingWater";
            this.m_txtDrinkingWater.Size = new System.Drawing.Size(176, 22);
            this.m_txtDrinkingWater.TabIndex = 90;
            this.m_txtDrinkingWater.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 14);
            this.label8.TabIndex = 10000028;
            this.label8.Text = "饮水:";
            // 
            // m_cboRecordTime
            // 
            this.m_cboRecordTime.AccessibleDescription = "登记时间";
            this.m_cboRecordTime.BackColor = System.Drawing.Color.White;
            this.m_cboRecordTime.BorderColor = System.Drawing.Color.Black;
            this.m_cboRecordTime.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboRecordTime.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboRecordTime.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboRecordTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboRecordTime.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboRecordTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboRecordTime.ForeColor = System.Drawing.Color.Black;
            this.m_cboRecordTime.ListBackColor = System.Drawing.Color.White;
            this.m_cboRecordTime.ListForeColor = System.Drawing.Color.Black;
            this.m_cboRecordTime.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboRecordTime.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboRecordTime.Location = new System.Drawing.Point(212, 6);
            this.m_cboRecordTime.m_BlnEnableItemEventMenu = false;
            this.m_cboRecordTime.Name = "m_cboRecordTime";
            this.m_cboRecordTime.SelectedIndex = -1;
            this.m_cboRecordTime.SelectedItem = null;
            this.m_cboRecordTime.SelectionStart = 0;
            this.m_cboRecordTime.Size = new System.Drawing.Size(180, 23);
            this.m_cboRecordTime.TabIndex = 10000027;
            this.m_cboRecordTime.TextBackColor = System.Drawing.Color.White;
            this.m_cboRecordTime.TextForeColor = System.Drawing.Color.Black;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnCancel.DefaultScheme = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Hint = "";
            this.btnCancel.Location = new System.Drawing.Point(458, 266);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnCancel.Size = new System.Drawing.Size(50, 28);
            this.btnCancel.TabIndex = 10000029;
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
            this.btnConfirm.Location = new System.Drawing.Point(384, 266);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnConfirm.Size = new System.Drawing.Size(50, 28);
            this.btnConfirm.TabIndex = 10000028;
            this.btnConfirm.Tag = "1";
            this.btnConfirm.Text = "确定";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // m_cmdSign
            // 
            this.m_cmdSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdSign.DefaultScheme = true;
            this.m_cmdSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdSign.ForeColor = System.Drawing.Color.Black;
            this.m_cmdSign.Hint = "";
            this.m_cmdSign.Location = new System.Drawing.Point(16, 266);
            this.m_cmdSign.Name = "m_cmdSign";
            this.m_cmdSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSign.Size = new System.Drawing.Size(48, 28);
            this.m_cmdSign.TabIndex = 10000030;
            this.m_cmdSign.Tag = "1";
            this.m_cmdSign.Text = "签名:";
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
            this.lsvSign.Location = new System.Drawing.Point(68, 266);
            this.lsvSign.Name = "lsvSign";
            this.lsvSign.Size = new System.Drawing.Size(286, 28);
            this.lsvSign.TabIndex = 10000031;
            this.lsvSign.UseCompatibleStateImageBehavior = false;
            this.lsvSign.View = System.Windows.Forms.View.SmallIcon;
            // 
            // clmEmployeeName
            // 
            this.clmEmployeeName.Width = 55;
            // 
            // frmIntakeAndOutputVolumeCon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 304);
            this.Controls.Add(this.m_cmdSign);
            this.Controls.Add(this.lsvSign);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.m_cboRecordTime);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmIntakeAndOutputVolumeCon";
            this.Text = "出入量登记表";
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.lblCreateDateTitle, 0);
            this.Controls.SetChildIndex(this.m_dtpCreateDate, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_trvCreateDate, 0);
            this.Controls.SetChildIndex(this.m_lblGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_dtpGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.m_cboRecordTime, 0);
            this.Controls.SetChildIndex(this.btnConfirm, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.lsvSign, 0);
            this.Controls.SetChildIndex(this.m_cmdSign, 0);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboRecordTime;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private com.digitalwave.controls.ctlRichTextBox m_txtOtherOutput;
        private System.Windows.Forms.Label label7;
        private com.digitalwave.controls.ctlRichTextBox m_txtChestFluid;
        private System.Windows.Forms.Label label6;
        private com.digitalwave.controls.ctlRichTextBox m_txtIntestinalJuice;
        private System.Windows.Forms.Label label5;
        private com.digitalwave.controls.ctlRichTextBox m_txtBile;
        private System.Windows.Forms.Label label4;
        private com.digitalwave.controls.ctlRichTextBox m_txtGastrisJuice;
        private System.Windows.Forms.Label label3;
        private com.digitalwave.controls.ctlRichTextBox m_txtUrine;
        private System.Windows.Forms.Label label2;
        private com.digitalwave.controls.ctlRichTextBox m_txtStool;
        private System.Windows.Forms.Label label1;
        private com.digitalwave.controls.ctlRichTextBox m_txtOtherIntake;
        private System.Windows.Forms.Label label13;
        private com.digitalwave.controls.ctlRichTextBox m_txtSalineWater;
        private System.Windows.Forms.Label label12;
        private com.digitalwave.controls.ctlRichTextBox m_txtSugarWater;
        private System.Windows.Forms.Label label11;
        private com.digitalwave.controls.ctlRichTextBox m_txtTransfusion;
        private System.Windows.Forms.Label label10;
        private com.digitalwave.controls.ctlRichTextBox m_txtFood;
        private System.Windows.Forms.Label label9;
        private com.digitalwave.controls.ctlRichTextBox m_txtDrinkingWater;
        private System.Windows.Forms.Label label8;
        private PinkieControls.ButtonXP btnCancel;
        private PinkieControls.ButtonXP btnConfirm;
        private PinkieControls.ButtonXP m_cmdSign;
        protected System.Windows.Forms.ListView lsvSign;
        private System.Windows.Forms.ColumnHeader clmEmployeeName;
    }
}