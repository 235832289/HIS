namespace iCare
{
    partial class frmEMR_SummaryBeforeOP
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lsvSign = new System.Windows.Forms.ListView();
            this.clmEmployeeName = new System.Windows.Forms.ColumnHeader();
            this.m_cmdEmployeeSign = new PinkieControls.ButtonXP();
            this.m_cmdClose = new PinkieControls.ButtonXP();
            this.cmdConfirm = new PinkieControls.ButtonXP();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtAnaMode = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtOPMode = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtPrepareBeforeOP = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtProceeding = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtOPIndication = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtDiagnosisGist = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtDiagnoseBeforeOP = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtDiseaseSummary = new com.digitalwave.controls.ctlRichTextBox();
            this.m_pnlNewBase.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_trvCreateDate
            // 
            this.m_trvCreateDate.LineColor = System.Drawing.Color.Black;
            this.m_trvCreateDate.Location = new System.Drawing.Point(194, -108);
            this.m_trvCreateDate.Size = new System.Drawing.Size(247, 102);
            this.m_trvCreateDate.Visible = false;
            // 
            // lblCreateDateTitle
            // 
            this.lblCreateDateTitle.Location = new System.Drawing.Point(23, 19);
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.Location = new System.Drawing.Point(95, 16);
            this.m_dtpCreateDate.Size = new System.Drawing.Size(215, 22);
            // 
            // m_dtpGetDataTime
            // 
            this.m_dtpGetDataTime.Location = new System.Drawing.Point(326, -62);
            this.m_dtpGetDataTime.Size = new System.Drawing.Size(247, 22);
            // 
            // m_lblGetDataTime
            // 
            this.m_lblGetDataTime.Location = new System.Drawing.Point(419, -62);
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(419, -54);
            this.lblSex.Size = new System.Drawing.Size(56, 22);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(545, -54);
            this.lblAge.Size = new System.Drawing.Size(61, 22);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(274, -29);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(615, -62);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(475, -29);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(363, -54);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(489, -54);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(391, -25);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(20, -132);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(135, 121);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(228, -29);
            this.txtInPatientID.Size = new System.Drawing.Size(135, 23);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(526, -34);
            this.m_txtPatientName.Size = new System.Drawing.Size(135, 23);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(326, -34);
            this.m_txtBedNO.Size = new System.Drawing.Size(135, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(447, -29);
            this.m_cboArea.Size = new System.Drawing.Size(168, 23);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(36, -131);
            this.m_lsvPatientName.Size = new System.Drawing.Size(135, 121);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(11, -136);
            this.m_lsvBedNO.Size = new System.Drawing.Size(135, 121);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(447, -71);
            this.m_cboDept.Size = new System.Drawing.Size(168, 23);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(391, -62);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(702, -43);
            this.m_cmdNewTemplate.Size = new System.Drawing.Size(98, 37);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Location = new System.Drawing.Point(228, -34);
            this.m_cmdNext.Size = new System.Drawing.Size(28, 24);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(181, -34);
            this.m_cmdPre.Size = new System.Drawing.Size(28, 24);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(316, -29);
            this.m_lblForTitle.Size = new System.Drawing.Size(19, 27);
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(303, -80);
            this.chkModifyWithoutMatk.Size = new System.Drawing.Size(103, 28);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(630, -36);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Location = new System.Drawing.Point(11, -79);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lsvSign);
            this.panel1.Controls.Add(this.m_cmdEmployeeSign);
            this.panel1.Controls.Add(this.m_cmdClose);
            this.panel1.Controls.Add(this.cmdConfirm);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.m_txtAnaMode);
            this.panel1.Controls.Add(this.m_txtOPMode);
            this.panel1.Controls.Add(this.m_txtPrepareBeforeOP);
            this.panel1.Controls.Add(this.m_txtProceeding);
            this.panel1.Controls.Add(this.m_txtOPIndication);
            this.panel1.Controls.Add(this.m_txtDiagnosisGist);
            this.panel1.Controls.Add(this.m_txtDiagnoseBeforeOP);
            this.panel1.Controls.Add(this.m_txtDiseaseSummary);
            this.panel1.Location = new System.Drawing.Point(12, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(853, 557);
            this.panel1.TabIndex = 10000005;
            // 
            // lsvSign
            // 
            this.lsvSign.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvSign.BackColor = System.Drawing.Color.White;
            this.lsvSign.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmEmployeeName});
            this.lsvSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvSign.ForeColor = System.Drawing.Color.Black;
            this.lsvSign.FullRowSelect = true;
            this.lsvSign.GridLines = true;
            this.lsvSign.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvSign.Location = new System.Drawing.Point(236, 526);
            this.lsvSign.Name = "lsvSign";
            this.lsvSign.Size = new System.Drawing.Size(416, 28);
            this.lsvSign.TabIndex = 10000042;
            this.lsvSign.UseCompatibleStateImageBehavior = false;
            this.lsvSign.View = System.Windows.Forms.View.SmallIcon;
            // 
            // clmEmployeeName
            // 
            this.clmEmployeeName.Width = 55;
            // 
            // m_cmdEmployeeSign
            // 
            this.m_cmdEmployeeSign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_cmdEmployeeSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdEmployeeSign.DefaultScheme = true;
            this.m_cmdEmployeeSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdEmployeeSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdEmployeeSign.Hint = "";
            this.m_cmdEmployeeSign.Location = new System.Drawing.Point(130, 524);
            this.m_cmdEmployeeSign.Name = "m_cmdEmployeeSign";
            this.m_cmdEmployeeSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdEmployeeSign.Size = new System.Drawing.Size(102, 30);
            this.m_cmdEmployeeSign.TabIndex = 10000041;
            this.m_cmdEmployeeSign.Tag = "1";
            this.m_cmdEmployeeSign.Text = "经治医师签名:";
            // 
            // m_cmdClose
            // 
            this.m_cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdClose.DefaultScheme = true;
            this.m_cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdClose.Hint = "";
            this.m_cmdClose.Location = new System.Drawing.Point(764, 524);
            this.m_cmdClose.Name = "m_cmdClose";
            this.m_cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClose.Size = new System.Drawing.Size(80, 30);
            this.m_cmdClose.TabIndex = 10000040;
            this.m_cmdClose.Text = "取消";
            this.m_cmdClose.Click += new System.EventHandler(this.m_cmdClose_Click);
            // 
            // cmdConfirm
            // 
            this.cmdConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.cmdConfirm.DefaultScheme = true;
            this.cmdConfirm.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdConfirm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdConfirm.Hint = "";
            this.cmdConfirm.Location = new System.Drawing.Point(664, 524);
            this.cmdConfirm.Name = "cmdConfirm";
            this.cmdConfirm.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdConfirm.Size = new System.Drawing.Size(80, 30);
            this.cmdConfirm.TabIndex = 10000039;
            this.cmdConfirm.Text = "确定";
            this.cmdConfirm.Click += new System.EventHandler(this.cmdConfirm_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 339);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 112;
            this.label6.Text = "麻醉方式：";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 307);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 14);
            this.label5.TabIndex = 112;
            this.label5.Text = "手术方式：";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 469);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 14);
            this.label8.TabIndex = 112;
            this.label8.Text = "术前准备：";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.Location = new System.Drawing.Point(4, 371);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 90);
            this.label7.TabIndex = 112;
            this.label7.Text = "注意事项：(术前、术中、术后)";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 112;
            this.label4.Text = "手术指征：";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 112;
            this.label3.Text = "诊断依据：";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 112;
            this.label2.Text = "术前诊断：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 112;
            this.label1.Text = "病情摘要：";
            // 
            // m_txtAnaMode
            // 
            this.m_txtAnaMode.AccessibleDescription = "麻醉方式";
            this.m_txtAnaMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtAnaMode.BackColor = System.Drawing.Color.White;
            this.m_txtAnaMode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtAnaMode.ForeColor = System.Drawing.Color.Black;
            this.m_txtAnaMode.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtAnaMode.Location = new System.Drawing.Point(83, 337);
            this.m_txtAnaMode.m_BlnIgnoreUserInfo = false;
            this.m_txtAnaMode.m_BlnPartControl = false;
            this.m_txtAnaMode.m_BlnReadOnly = false;
            this.m_txtAnaMode.m_BlnUnderLineDST = false;
            this.m_txtAnaMode.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtAnaMode.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtAnaMode.m_IntCanModifyTime = 6;
            this.m_txtAnaMode.m_IntPartControlLength = 0;
            this.m_txtAnaMode.m_IntPartControlStartIndex = 0;
            this.m_txtAnaMode.m_StrUserID = "";
            this.m_txtAnaMode.m_StrUserName = "";
            this.m_txtAnaMode.MaxLength = 2000;
            this.m_txtAnaMode.Multiline = false;
            this.m_txtAnaMode.Name = "m_txtAnaMode";
            this.m_txtAnaMode.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtAnaMode.Size = new System.Drawing.Size(767, 26);
            this.m_txtAnaMode.TabIndex = 30;
            this.m_txtAnaMode.Text = "";
            // 
            // m_txtOPMode
            // 
            this.m_txtOPMode.AccessibleDescription = "手术方式";
            this.m_txtOPMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtOPMode.BackColor = System.Drawing.Color.White;
            this.m_txtOPMode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOPMode.ForeColor = System.Drawing.Color.Black;
            this.m_txtOPMode.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOPMode.Location = new System.Drawing.Point(83, 305);
            this.m_txtOPMode.m_BlnIgnoreUserInfo = false;
            this.m_txtOPMode.m_BlnPartControl = false;
            this.m_txtOPMode.m_BlnReadOnly = false;
            this.m_txtOPMode.m_BlnUnderLineDST = false;
            this.m_txtOPMode.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOPMode.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOPMode.m_IntCanModifyTime = 6;
            this.m_txtOPMode.m_IntPartControlLength = 0;
            this.m_txtOPMode.m_IntPartControlStartIndex = 0;
            this.m_txtOPMode.m_StrUserID = "";
            this.m_txtOPMode.m_StrUserName = "";
            this.m_txtOPMode.MaxLength = 2000;
            this.m_txtOPMode.Multiline = false;
            this.m_txtOPMode.Name = "m_txtOPMode";
            this.m_txtOPMode.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtOPMode.Size = new System.Drawing.Size(767, 26);
            this.m_txtOPMode.TabIndex = 25;
            this.m_txtOPMode.Text = "";
            // 
            // m_txtPrepareBeforeOP
            // 
            this.m_txtPrepareBeforeOP.AccessibleDescription = "术前准备";
            this.m_txtPrepareBeforeOP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtPrepareBeforeOP.BackColor = System.Drawing.Color.White;
            this.m_txtPrepareBeforeOP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPrepareBeforeOP.ForeColor = System.Drawing.Color.Black;
            this.m_txtPrepareBeforeOP.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPrepareBeforeOP.Location = new System.Drawing.Point(83, 467);
            this.m_txtPrepareBeforeOP.m_BlnIgnoreUserInfo = false;
            this.m_txtPrepareBeforeOP.m_BlnPartControl = false;
            this.m_txtPrepareBeforeOP.m_BlnReadOnly = false;
            this.m_txtPrepareBeforeOP.m_BlnUnderLineDST = false;
            this.m_txtPrepareBeforeOP.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPrepareBeforeOP.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPrepareBeforeOP.m_IntCanModifyTime = 6;
            this.m_txtPrepareBeforeOP.m_IntPartControlLength = 0;
            this.m_txtPrepareBeforeOP.m_IntPartControlStartIndex = 0;
            this.m_txtPrepareBeforeOP.m_StrUserID = "";
            this.m_txtPrepareBeforeOP.m_StrUserName = "";
            this.m_txtPrepareBeforeOP.MaxLength = 2000;
            this.m_txtPrepareBeforeOP.Name = "m_txtPrepareBeforeOP";
            this.m_txtPrepareBeforeOP.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtPrepareBeforeOP.Size = new System.Drawing.Size(767, 53);
            this.m_txtPrepareBeforeOP.TabIndex = 40;
            this.m_txtPrepareBeforeOP.Text = "";
            // 
            // m_txtProceeding
            // 
            this.m_txtProceeding.AccessibleDescription = "注意事项";
            this.m_txtProceeding.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtProceeding.BackColor = System.Drawing.Color.White;
            this.m_txtProceeding.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtProceeding.ForeColor = System.Drawing.Color.Black;
            this.m_txtProceeding.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtProceeding.Location = new System.Drawing.Point(83, 369);
            this.m_txtProceeding.m_BlnIgnoreUserInfo = false;
            this.m_txtProceeding.m_BlnPartControl = false;
            this.m_txtProceeding.m_BlnReadOnly = false;
            this.m_txtProceeding.m_BlnUnderLineDST = false;
            this.m_txtProceeding.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtProceeding.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtProceeding.m_IntCanModifyTime = 6;
            this.m_txtProceeding.m_IntPartControlLength = 0;
            this.m_txtProceeding.m_IntPartControlStartIndex = 0;
            this.m_txtProceeding.m_StrUserID = "";
            this.m_txtProceeding.m_StrUserName = "";
            this.m_txtProceeding.MaxLength = 2000;
            this.m_txtProceeding.Name = "m_txtProceeding";
            this.m_txtProceeding.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtProceeding.Size = new System.Drawing.Size(767, 92);
            this.m_txtProceeding.TabIndex = 35;
            this.m_txtProceeding.Text = "";
            // 
            // m_txtOPIndication
            // 
            this.m_txtOPIndication.AccessibleDescription = "手术指征";
            this.m_txtOPIndication.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtOPIndication.BackColor = System.Drawing.Color.White;
            this.m_txtOPIndication.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOPIndication.ForeColor = System.Drawing.Color.Black;
            this.m_txtOPIndication.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOPIndication.Location = new System.Drawing.Point(83, 226);
            this.m_txtOPIndication.m_BlnIgnoreUserInfo = false;
            this.m_txtOPIndication.m_BlnPartControl = false;
            this.m_txtOPIndication.m_BlnReadOnly = false;
            this.m_txtOPIndication.m_BlnUnderLineDST = false;
            this.m_txtOPIndication.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOPIndication.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOPIndication.m_IntCanModifyTime = 6;
            this.m_txtOPIndication.m_IntPartControlLength = 0;
            this.m_txtOPIndication.m_IntPartControlStartIndex = 0;
            this.m_txtOPIndication.m_StrUserID = "";
            this.m_txtOPIndication.m_StrUserName = "";
            this.m_txtOPIndication.MaxLength = 2000;
            this.m_txtOPIndication.Name = "m_txtOPIndication";
            this.m_txtOPIndication.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtOPIndication.Size = new System.Drawing.Size(767, 73);
            this.m_txtOPIndication.TabIndex = 20;
            this.m_txtOPIndication.Text = "";
            // 
            // m_txtDiagnosisGist
            // 
            this.m_txtDiagnosisGist.AccessibleDescription = "诊断依据";
            this.m_txtDiagnosisGist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtDiagnosisGist.BackColor = System.Drawing.Color.White;
            this.m_txtDiagnosisGist.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDiagnosisGist.ForeColor = System.Drawing.Color.Black;
            this.m_txtDiagnosisGist.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDiagnosisGist.Location = new System.Drawing.Point(83, 151);
            this.m_txtDiagnosisGist.m_BlnIgnoreUserInfo = false;
            this.m_txtDiagnosisGist.m_BlnPartControl = false;
            this.m_txtDiagnosisGist.m_BlnReadOnly = false;
            this.m_txtDiagnosisGist.m_BlnUnderLineDST = false;
            this.m_txtDiagnosisGist.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDiagnosisGist.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDiagnosisGist.m_IntCanModifyTime = 6;
            this.m_txtDiagnosisGist.m_IntPartControlLength = 0;
            this.m_txtDiagnosisGist.m_IntPartControlStartIndex = 0;
            this.m_txtDiagnosisGist.m_StrUserID = "";
            this.m_txtDiagnosisGist.m_StrUserName = "";
            this.m_txtDiagnosisGist.MaxLength = 2000;
            this.m_txtDiagnosisGist.Name = "m_txtDiagnosisGist";
            this.m_txtDiagnosisGist.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtDiagnosisGist.Size = new System.Drawing.Size(767, 69);
            this.m_txtDiagnosisGist.TabIndex = 15;
            this.m_txtDiagnosisGist.Text = "";
            // 
            // m_txtDiagnoseBeforeOP
            // 
            this.m_txtDiagnoseBeforeOP.AccessibleDescription = "术前诊断";
            this.m_txtDiagnoseBeforeOP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtDiagnoseBeforeOP.BackColor = System.Drawing.Color.White;
            this.m_txtDiagnoseBeforeOP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDiagnoseBeforeOP.ForeColor = System.Drawing.Color.Black;
            this.m_txtDiagnoseBeforeOP.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDiagnoseBeforeOP.Location = new System.Drawing.Point(83, 77);
            this.m_txtDiagnoseBeforeOP.m_BlnIgnoreUserInfo = false;
            this.m_txtDiagnoseBeforeOP.m_BlnPartControl = false;
            this.m_txtDiagnoseBeforeOP.m_BlnReadOnly = false;
            this.m_txtDiagnoseBeforeOP.m_BlnUnderLineDST = false;
            this.m_txtDiagnoseBeforeOP.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDiagnoseBeforeOP.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDiagnoseBeforeOP.m_IntCanModifyTime = 6;
            this.m_txtDiagnoseBeforeOP.m_IntPartControlLength = 0;
            this.m_txtDiagnoseBeforeOP.m_IntPartControlStartIndex = 0;
            this.m_txtDiagnoseBeforeOP.m_StrUserID = "";
            this.m_txtDiagnoseBeforeOP.m_StrUserName = "";
            this.m_txtDiagnoseBeforeOP.MaxLength = 2000;
            this.m_txtDiagnoseBeforeOP.Name = "m_txtDiagnoseBeforeOP";
            this.m_txtDiagnoseBeforeOP.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtDiagnoseBeforeOP.Size = new System.Drawing.Size(767, 68);
            this.m_txtDiagnoseBeforeOP.TabIndex = 10;
            this.m_txtDiagnoseBeforeOP.Text = "";
            // 
            // m_txtDiseaseSummary
            // 
            this.m_txtDiseaseSummary.AccessibleDescription = "病情摘要";
            this.m_txtDiseaseSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtDiseaseSummary.BackColor = System.Drawing.Color.White;
            this.m_txtDiseaseSummary.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDiseaseSummary.ForeColor = System.Drawing.Color.Black;
            this.m_txtDiseaseSummary.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDiseaseSummary.Location = new System.Drawing.Point(83, 4);
            this.m_txtDiseaseSummary.m_BlnIgnoreUserInfo = false;
            this.m_txtDiseaseSummary.m_BlnPartControl = false;
            this.m_txtDiseaseSummary.m_BlnReadOnly = false;
            this.m_txtDiseaseSummary.m_BlnUnderLineDST = false;
            this.m_txtDiseaseSummary.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDiseaseSummary.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDiseaseSummary.m_IntCanModifyTime = 6;
            this.m_txtDiseaseSummary.m_IntPartControlLength = 0;
            this.m_txtDiseaseSummary.m_IntPartControlStartIndex = 0;
            this.m_txtDiseaseSummary.m_StrUserID = "";
            this.m_txtDiseaseSummary.m_StrUserName = "";
            this.m_txtDiseaseSummary.MaxLength = 2000;
            this.m_txtDiseaseSummary.Name = "m_txtDiseaseSummary";
            this.m_txtDiseaseSummary.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtDiseaseSummary.Size = new System.Drawing.Size(767, 67);
            this.m_txtDiseaseSummary.TabIndex = 5;
            this.m_txtDiseaseSummary.Text = "";
            // 
            // frmEMR_SummaryBeforeOP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 620);
            this.Controls.Add(this.panel1);
            this.Name = "frmEMR_SummaryBeforeOP";
            this.Text = "术前小结";
            this.Load += new System.EventHandler(this.frmEMR_SummaryBeforeOP_Load);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_dtpGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.m_trvCreateDate, 0);
            this.Controls.SetChildIndex(this.m_lblGetDataTime, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.lblCreateDateTitle, 0);
            this.Controls.SetChildIndex(this.m_dtpCreateDate, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private com.digitalwave.controls.ctlRichTextBox m_txtDiagnoseBeforeOP;
        private com.digitalwave.controls.ctlRichTextBox m_txtDiseaseSummary;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private com.digitalwave.controls.ctlRichTextBox m_txtOPIndication;
        private com.digitalwave.controls.ctlRichTextBox m_txtDiagnosisGist;
        private System.Windows.Forms.Label label5;
        private com.digitalwave.controls.ctlRichTextBox m_txtOPMode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private com.digitalwave.controls.ctlRichTextBox m_txtAnaMode;
        private com.digitalwave.controls.ctlRichTextBox m_txtPrepareBeforeOP;
        private com.digitalwave.controls.ctlRichTextBox m_txtProceeding;
        protected System.Windows.Forms.ListView lsvSign;
        private System.Windows.Forms.ColumnHeader clmEmployeeName;
        private PinkieControls.ButtonXP m_cmdEmployeeSign;
        private PinkieControls.ButtonXP m_cmdClose;
        private PinkieControls.ButtonXP cmdConfirm;
    }
}