namespace iCare
{
    partial class frmEMR_CesareanRecord
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
            try
            {
                if (this.objPrintTool != null)
                    this.objPrintTool.Dispose();
            }
            catch { }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEMR_CesareanRecord));
            this.txtSign = new System.Windows.Forms.TextBox();
            this.m_cmdRecorder = new PinkieControls.ButtonXP();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label44 = new System.Windows.Forms.Label();
            this.panel16 = new System.Windows.Forms.Panel();
            this.m_chkPresentatonExpulsion3 = new System.Windows.Forms.CheckBox();
            this.m_chkPresentatonExpulsion2 = new System.Windows.Forms.CheckBox();
            this.m_chkPresentatonExpulsion1 = new System.Windows.Forms.CheckBox();
            this.panel15 = new System.Windows.Forms.Panel();
            this.m_chkEngagement3 = new System.Windows.Forms.CheckBox();
            this.m_chkEngagement2 = new System.Windows.Forms.CheckBox();
            this.m_chkEngagement1 = new System.Windows.Forms.CheckBox();
            this.m_txtFetusPlace2 = new com.digitalwave.controls.ctlRichTextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.m_chkPeritoneum4 = new System.Windows.Forms.CheckBox();
            this.m_chkPeritoneum3 = new System.Windows.Forms.CheckBox();
            this.panel12 = new System.Windows.Forms.Panel();
            this.m_chkPeritoneum6 = new System.Windows.Forms.CheckBox();
            this.m_chkPeritoneum5 = new System.Windows.Forms.CheckBox();
            this.panel13 = new System.Windows.Forms.Panel();
            this.m_chkUterus2 = new System.Windows.Forms.CheckBox();
            this.m_chkUterus1 = new System.Windows.Forms.CheckBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.m_chkFascia4 = new System.Windows.Forms.CheckBox();
            this.m_chkFascia3 = new System.Windows.Forms.CheckBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.m_chkPeritoneum2 = new System.Windows.Forms.CheckBox();
            this.m_chkPeritoneum1 = new System.Windows.Forms.CheckBox();
            this.panel14 = new System.Windows.Forms.Panel();
            this.m_chkUterus4 = new System.Windows.Forms.CheckBox();
            this.m_chkUterus3 = new System.Windows.Forms.CheckBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.m_chkFascia2 = new System.Windows.Forms.CheckBox();
            this.m_chkFascia1 = new System.Windows.Forms.CheckBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.m_chkUnCheckBeforeOP = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label64 = new System.Windows.Forms.Label();
            this.panel21 = new System.Windows.Forms.Panel();
            this.chkNoSuccedaneum1 = new System.Windows.Forms.CheckBox();
            this.chkHasSuccedaneum1 = new System.Windows.Forms.CheckBox();
            this.m_txtPresentation2 = new com.digitalwave.controls.ctlRichTextBox();
            this.label95 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.m_chkAmniocentesis14 = new System.Windows.Forms.CheckBox();
            this.m_chkAmniocentesis13 = new System.Windows.Forms.CheckBox();
            this.m_chkAmniocentesis12 = new System.Windows.Forms.CheckBox();
            this.m_chkAmniocentesis11 = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.m_chkIshiumNotch3 = new System.Windows.Forms.CheckBox();
            this.m_chkIshiumNotch2 = new System.Windows.Forms.CheckBox();
            this.m_chkIshiumNotch1 = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_chkIschialSpine3 = new System.Windows.Forms.CheckBox();
            this.m_chkIschialSpine2 = new System.Windows.Forms.CheckBox();
            this.m_chkIschialSpine1 = new System.Windows.Forms.CheckBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.m_chkSkull2 = new System.Windows.Forms.CheckBox();
            this.m_chkSkull1 = new System.Windows.Forms.CheckBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.m_chkCoccyxRadian3 = new System.Windows.Forms.CheckBox();
            this.m_chkCoccyxRadian2 = new System.Windows.Forms.CheckBox();
            this.m_chkCoccyxRadian1 = new System.Windows.Forms.CheckBox();
            this.m_txtCaputSuccedaneumPlace1 = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtCaputSuccedaneumSize = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtPresentationHeight = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtFetusPlace1 = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtUterusora = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtPubicArch = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtDC = new com.digitalwave.controls.ctlRichTextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_chkLinkup3 = new System.Windows.Forms.CheckBox();
            this.m_chkLinkup2 = new System.Windows.Forms.CheckBox();
            this.m_chkLinkup1 = new System.Windows.Forms.CheckBox();
            this.m_txtPresentation1 = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtFetusWeight = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtAbdomenRound = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtUterueHeight = new com.digitalwave.controls.ctlRichTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.m_cboLayTimes = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboPregnantTimes = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_txtAnaesthetist = new System.Windows.Forms.TextBox();
            this.m_cmdAnaesthetist = new PinkieControls.ButtonXP();
            this.m_txtOPName = new com.digitalwave.controls.ctlRichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.m_txtOPIndication = new com.digitalwave.controls.ctlRichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txtAbdominalWall_H = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtAbdominalWall_V = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtAnaMode = new com.digitalwave.controls.ctlRichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_txtDiagnosisAfterOP = new com.digitalwave.controls.ctlRichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtDiagnosisBeforeOP = new com.digitalwave.controls.ctlRichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_dtpOPDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.m_lblInPatientDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel25 = new System.Windows.Forms.Panel();
            this.chkNoSuccedaneum2 = new System.Windows.Forms.CheckBox();
            this.chkHasSuccedaneum2 = new System.Windows.Forms.CheckBox();
            this.panel20 = new System.Windows.Forms.Panel();
            this.m_chkOvaryCircs2R = new System.Windows.Forms.CheckBox();
            this.m_chkOvaryCircs1R = new System.Windows.Forms.CheckBox();
            this.label63 = new System.Windows.Forms.Label();
            this.panel19 = new System.Windows.Forms.Panel();
            this.m_chkOviductCircs2R = new System.Windows.Forms.CheckBox();
            this.m_chkOviductCircs1R = new System.Windows.Forms.CheckBox();
            this.label62 = new System.Windows.Forms.Label();
            this.m_txtSumary4 = new com.digitalwave.controls.ctlRichTextBox();
            this.m_cboOPTime = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboANATime = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_lsvAssistant2 = new System.Windows.Forms.TextBox();
            this.m_lsvAssistant1 = new System.Windows.Forms.TextBox();
            this.m_txtPLACENTA = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtOperator = new System.Windows.Forms.TextBox();
            this.m_cmdOperator = new PinkieControls.ButtonXP();
            this.m_cmdAssistant2 = new PinkieControls.ButtonXP();
            this.m_cmdAssistant1 = new PinkieControls.ButtonXP();
            this.label87 = new System.Windows.Forms.Label();
            this.label88 = new System.Windows.Forms.Label();
            this.label86 = new System.Windows.Forms.Label();
            this.m_txtTransfuse = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtBleeding = new com.digitalwave.controls.ctlRichTextBox();
            this.label85 = new System.Windows.Forms.Label();
            this.m_txtPiss = new com.digitalwave.controls.ctlRichTextBox();
            this.label83 = new System.Windows.Forms.Label();
            this.label84 = new System.Windows.Forms.Label();
            this.label80 = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.label81 = new System.Windows.Forms.Label();
            this.m_txtOtherMedicine = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtOxytocinIMIv = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtSutureAbdominalWall = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtSutureUterus = new com.digitalwave.controls.ctlRichTextBox();
            this.panel24 = new System.Windows.Forms.Panel();
            this.m_chkOvaryCircs2L = new System.Windows.Forms.CheckBox();
            this.m_chkOvaryCircs1L = new System.Windows.Forms.CheckBox();
            this.panel23 = new System.Windows.Forms.Panel();
            this.m_chkOviductCircs2L = new System.Windows.Forms.CheckBox();
            this.m_chkOviductCircs1L = new System.Windows.Forms.CheckBox();
            this.label72 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.m_txtAmniocentesisBulk = new com.digitalwave.controls.ctlRichTextBox();
            this.label59 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.panel18 = new System.Windows.Forms.Panel();
            this.m_chkAmniocentesis24 = new System.Windows.Forms.CheckBox();
            this.m_chkAmniocentesis23 = new System.Windows.Forms.CheckBox();
            this.m_chkAmniocentesis22 = new System.Windows.Forms.CheckBox();
            this.m_chkAmniocentesis21 = new System.Windows.Forms.CheckBox();
            this.label56 = new System.Windows.Forms.Label();
            this.m_txtUMBILICALCORD = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtCaputSuccedaneumPlace2 = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtFetusFacies = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtApgar = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtCaputsuccedaneumSezeY = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtCaputsuccedaneumSezeX = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtBabyWeight = new com.digitalwave.controls.ctlRichTextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.panel22 = new System.Windows.Forms.Panel();
            this.m_chkEmbryolemmaCircs2 = new System.Windows.Forms.CheckBox();
            this.m_chkEmbryolemmaCircs1 = new System.Windows.Forms.CheckBox();
            this.panel17 = new System.Windows.Forms.Panel();
            this.m_chkBabySex2 = new System.Windows.Forms.CheckBox();
            this.m_chkBabySex1 = new System.Windows.Forms.CheckBox();
            this.label69 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.m_dtpExpulsionTime = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.m_pnlNewBase.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel21.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel25.SuspendLayout();
            this.panel20.SuspendLayout();
            this.panel19.SuspendLayout();
            this.panel24.SuspendLayout();
            this.panel23.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel22.SuspendLayout();
            this.panel17.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_trvCreateDate
            // 
            this.m_trvCreateDate.LineColor = System.Drawing.Color.Black;
            this.m_trvCreateDate.Location = new System.Drawing.Point(11, 37);
            this.m_trvCreateDate.Size = new System.Drawing.Size(193, 56);
            // 
            // lblCreateDateTitle
            // 
            this.lblCreateDateTitle.Location = new System.Drawing.Point(209, 73);
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.Location = new System.Drawing.Point(278, 68);
            this.m_dtpCreateDate.Size = new System.Drawing.Size(217, 22);
            // 
            // m_dtpGetDataTime
            // 
            this.m_dtpGetDataTime.Location = new System.Drawing.Point(220, 177);
            this.m_dtpGetDataTime.Size = new System.Drawing.Size(247, 22);
            // 
            // m_lblGetDataTime
            // 
            this.m_lblGetDataTime.Location = new System.Drawing.Point(289, 177);
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(337, 145);
            this.lblSex.Size = new System.Drawing.Size(56, 22);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(341, 159);
            this.lblAge.Size = new System.Drawing.Size(89, 22);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(351, 151);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(332, 167);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(358, 159);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(358, 131);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(356, 136);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(249, 172);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(310, 154);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(60, 48);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(322, 148);
            this.txtInPatientID.Size = new System.Drawing.Size(135, 23);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(292, 148);
            this.m_txtPatientName.Size = new System.Drawing.Size(135, 23);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(335, 148);
            this.m_txtBedNO.Size = new System.Drawing.Size(101, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(265, 156);
            this.m_cboArea.Size = new System.Drawing.Size(153, 23);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(258, 177);
            this.m_lsvPatientName.Size = new System.Drawing.Size(58, 44);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(288, 177);
            this.m_lsvBedNO.Size = new System.Drawing.Size(47, 44);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(266, 156);
            this.m_cboDept.Size = new System.Drawing.Size(151, 23);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(256, 165);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(244, 165);
            this.m_cmdNewTemplate.Size = new System.Drawing.Size(98, 37);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.m_cmdNext.Location = new System.Drawing.Point(310, 126);
            this.m_cmdNext.Size = new System.Drawing.Size(28, 24);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(258, 167);
            this.m_cmdPre.Size = new System.Drawing.Size(28, 24);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(262, 172);
            this.m_lblForTitle.Size = new System.Drawing.Size(19, 27);
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(87, 172);
            this.chkModifyWithoutMatk.Size = new System.Drawing.Size(103, 28);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(728, 37);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Controls.Add(this.txtSign);
            this.m_pnlNewBase.Controls.Add(this.m_cmdRecorder);
            this.m_pnlNewBase.Size = new System.Drawing.Size(805, 88);
            this.m_pnlNewBase.Visible = true;
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_ctlPatientInfo, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_cmdRecorder, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.txtSign, 0);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ctlPatientInfo.Dock = System.Windows.Forms.DockStyle.None;
            this.m_ctlPatientInfo.Location = new System.Drawing.Point(194, 29);
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(610, 58);
            // 
            // txtSign
            // 
            this.txtSign.AccessibleDescription = "记录者";
            this.txtSign.AccessibleName = "NoDefault";
            this.txtSign.BackColor = System.Drawing.Color.White;
            this.txtSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSign.ForeColor = System.Drawing.Color.Black;
            this.txtSign.Location = new System.Drawing.Point(669, 61);
            this.txtSign.Name = "txtSign";
            this.txtSign.ReadOnly = true;
            this.txtSign.Size = new System.Drawing.Size(116, 23);
            this.txtSign.TabIndex = 10000013;
            // 
            // m_cmdRecorder
            // 
            this.m_cmdRecorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdRecorder.DefaultScheme = true;
            this.m_cmdRecorder.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdRecorder.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdRecorder.ForeColor = System.Drawing.Color.Black;
            this.m_cmdRecorder.Hint = "";
            this.m_cmdRecorder.Location = new System.Drawing.Point(595, 60);
            this.m_cmdRecorder.Name = "m_cmdRecorder";
            this.m_cmdRecorder.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdRecorder.Size = new System.Drawing.Size(72, 24);
            this.m_cmdRecorder.TabIndex = 10000012;
            this.m_cmdRecorder.Text = "记录者:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(7, 99);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(808, 502);
            this.tabControl1.TabIndex = 10000014;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label44);
            this.tabPage1.Controls.Add(this.panel16);
            this.tabPage1.Controls.Add(this.panel15);
            this.tabPage1.Controls.Add(this.m_txtFetusPlace2);
            this.tabPage1.Controls.Add(this.label41);
            this.tabPage1.Controls.Add(this.panel11);
            this.tabPage1.Controls.Add(this.panel12);
            this.tabPage1.Controls.Add(this.panel13);
            this.tabPage1.Controls.Add(this.panel9);
            this.tabPage1.Controls.Add(this.panel10);
            this.tabPage1.Controls.Add(this.panel14);
            this.tabPage1.Controls.Add(this.panel8);
            this.tabPage1.Controls.Add(this.label37);
            this.tabPage1.Controls.Add(this.label36);
            this.tabPage1.Controls.Add(this.label43);
            this.tabPage1.Controls.Add(this.label38);
            this.tabPage1.Controls.Add(this.label42);
            this.tabPage1.Controls.Add(this.label39);
            this.tabPage1.Controls.Add(this.label40);
            this.tabPage1.Controls.Add(this.label35);
            this.tabPage1.Controls.Add(this.label34);
            this.tabPage1.Controls.Add(this.label33);
            this.tabPage1.Controls.Add(this.m_chkUnCheckBeforeOP);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.m_txtPresentation1);
            this.tabPage1.Controls.Add(this.m_txtFetusWeight);
            this.tabPage1.Controls.Add(this.m_txtAbdomenRound);
            this.tabPage1.Controls.Add(this.m_txtUterueHeight);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label31);
            this.tabPage1.Controls.Add(this.label30);
            this.tabPage1.Controls.Add(this.label58);
            this.tabPage1.Controls.Add(this.label57);
            this.tabPage1.Controls.Add(this.m_cboLayTimes);
            this.tabPage1.Controls.Add(this.m_cboPregnantTimes);
            this.tabPage1.Controls.Add(this.m_txtAnaesthetist);
            this.tabPage1.Controls.Add(this.m_cmdAnaesthetist);
            this.tabPage1.Controls.Add(this.m_txtOPName);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.m_txtOPIndication);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.m_txtAbdominalWall_H);
            this.tabPage1.Controls.Add(this.m_txtAbdominalWall_V);
            this.tabPage1.Controls.Add(this.m_txtAnaMode);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.m_txtDiagnosisAfterOP);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.m_txtDiagnosisBeforeOP);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.m_dtpOPDate);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.m_lblInPatientDate);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(800, 475);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "第一页";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label44
            // 
            this.label44.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label44.Location = new System.Drawing.Point(8, 462);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(791, 2);
            this.label44.TabIndex = 10000093;
            // 
            // panel16
            // 
            this.panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel16.Controls.Add(this.m_chkPresentatonExpulsion3);
            this.panel16.Controls.Add(this.m_chkPresentatonExpulsion2);
            this.panel16.Controls.Add(this.m_chkPresentatonExpulsion1);
            this.panel16.Location = new System.Drawing.Point(499, 432);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(156, 25);
            this.panel16.TabIndex = 10000092;
            // 
            // m_chkPresentatonExpulsion3
            // 
            this.m_chkPresentatonExpulsion3.AccessibleDescription = "先露娩出>>很难";
            this.m_chkPresentatonExpulsion3.AutoSize = true;
            this.m_chkPresentatonExpulsion3.Location = new System.Drawing.Point(97, 4);
            this.m_chkPresentatonExpulsion3.Name = "m_chkPresentatonExpulsion3";
            this.m_chkPresentatonExpulsion3.Size = new System.Drawing.Size(54, 18);
            this.m_chkPresentatonExpulsion3.TabIndex = 187;
            this.m_chkPresentatonExpulsion3.Text = "很难";
            this.m_chkPresentatonExpulsion3.UseVisualStyleBackColor = true;
            this.m_chkPresentatonExpulsion3.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // m_chkPresentatonExpulsion2
            // 
            this.m_chkPresentatonExpulsion2.AccessibleDescription = "先露娩出>>较难";
            this.m_chkPresentatonExpulsion2.AutoSize = true;
            this.m_chkPresentatonExpulsion2.Location = new System.Drawing.Point(41, 4);
            this.m_chkPresentatonExpulsion2.Name = "m_chkPresentatonExpulsion2";
            this.m_chkPresentatonExpulsion2.Size = new System.Drawing.Size(54, 18);
            this.m_chkPresentatonExpulsion2.TabIndex = 186;
            this.m_chkPresentatonExpulsion2.Text = "较难";
            this.m_chkPresentatonExpulsion2.UseVisualStyleBackColor = true;
            this.m_chkPresentatonExpulsion2.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // m_chkPresentatonExpulsion1
            // 
            this.m_chkPresentatonExpulsion1.AccessibleDescription = "先露娩出>>易";
            this.m_chkPresentatonExpulsion1.AutoSize = true;
            this.m_chkPresentatonExpulsion1.Location = new System.Drawing.Point(3, 4);
            this.m_chkPresentatonExpulsion1.Name = "m_chkPresentatonExpulsion1";
            this.m_chkPresentatonExpulsion1.Size = new System.Drawing.Size(40, 18);
            this.m_chkPresentatonExpulsion1.TabIndex = 185;
            this.m_chkPresentatonExpulsion1.Text = "易";
            this.m_chkPresentatonExpulsion1.UseVisualStyleBackColor = true;
            this.m_chkPresentatonExpulsion1.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // panel15
            // 
            this.panel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel15.Controls.Add(this.m_chkEngagement3);
            this.panel15.Controls.Add(this.m_chkEngagement2);
            this.panel15.Controls.Add(this.m_chkEngagement1);
            this.panel15.Location = new System.Drawing.Point(280, 433);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(126, 25);
            this.panel15.TabIndex = 10000092;
            // 
            // m_chkEngagement3
            // 
            this.m_chkEngagement3.AccessibleDescription = "入盆>>深";
            this.m_chkEngagement3.AutoSize = true;
            this.m_chkEngagement3.Location = new System.Drawing.Point(83, 4);
            this.m_chkEngagement3.Name = "m_chkEngagement3";
            this.m_chkEngagement3.Size = new System.Drawing.Size(40, 18);
            this.m_chkEngagement3.TabIndex = 182;
            this.m_chkEngagement3.Text = "深";
            this.m_chkEngagement3.UseVisualStyleBackColor = true;
            this.m_chkEngagement3.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // m_chkEngagement2
            // 
            this.m_chkEngagement2.AccessibleDescription = "入盆>>浅";
            this.m_chkEngagement2.AutoSize = true;
            this.m_chkEngagement2.Location = new System.Drawing.Point(41, 4);
            this.m_chkEngagement2.Name = "m_chkEngagement2";
            this.m_chkEngagement2.Size = new System.Drawing.Size(40, 18);
            this.m_chkEngagement2.TabIndex = 181;
            this.m_chkEngagement2.Text = "浅";
            this.m_chkEngagement2.UseVisualStyleBackColor = true;
            this.m_chkEngagement2.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // m_chkEngagement1
            // 
            this.m_chkEngagement1.AccessibleDescription = "入盆>>浮";
            this.m_chkEngagement1.AutoSize = true;
            this.m_chkEngagement1.Location = new System.Drawing.Point(3, 4);
            this.m_chkEngagement1.Name = "m_chkEngagement1";
            this.m_chkEngagement1.Size = new System.Drawing.Size(40, 18);
            this.m_chkEngagement1.TabIndex = 180;
            this.m_chkEngagement1.Text = "浮";
            this.m_chkEngagement1.UseVisualStyleBackColor = true;
            this.m_chkEngagement1.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // m_txtFetusPlace2
            // 
            this.m_txtFetusPlace2.AccessibleDescription = "手术方式>>胎方位";
            this.m_txtFetusPlace2.BackColor = System.Drawing.Color.White;
            this.m_txtFetusPlace2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtFetusPlace2.ForeColor = System.Drawing.Color.Black;
            this.m_txtFetusPlace2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtFetusPlace2.Location = new System.Drawing.Point(90, 434);
            this.m_txtFetusPlace2.m_BlnIgnoreUserInfo = false;
            this.m_txtFetusPlace2.m_BlnPartControl = false;
            this.m_txtFetusPlace2.m_BlnReadOnly = false;
            this.m_txtFetusPlace2.m_BlnUnderLineDST = false;
            this.m_txtFetusPlace2.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtFetusPlace2.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtFetusPlace2.m_IntCanModifyTime = 6;
            this.m_txtFetusPlace2.m_IntPartControlLength = 0;
            this.m_txtFetusPlace2.m_IntPartControlStartIndex = 0;
            this.m_txtFetusPlace2.m_StrUserID = "";
            this.m_txtFetusPlace2.m_StrUserName = "";
            this.m_txtFetusPlace2.MaxLength = 50;
            this.m_txtFetusPlace2.Multiline = false;
            this.m_txtFetusPlace2.Name = "m_txtFetusPlace2";
            this.m_txtFetusPlace2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtFetusPlace2.Size = new System.Drawing.Size(131, 24);
            this.m_txtFetusPlace2.TabIndex = 175;
            this.m_txtFetusPlace2.Text = "";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(36, 439);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(49, 14);
            this.label41.TabIndex = 10000090;
            this.label41.Text = "胎方位";
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.m_chkPeritoneum4);
            this.panel11.Controls.Add(this.m_chkPeritoneum3);
            this.panel11.Location = new System.Drawing.Point(165, 406);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(82, 22);
            this.panel11.TabIndex = 10000082;
            // 
            // m_chkPeritoneum4
            // 
            this.m_chkPeritoneum4.AccessibleDescription = "腹膜>>横";
            this.m_chkPeritoneum4.AutoSize = true;
            this.m_chkPeritoneum4.Location = new System.Drawing.Point(44, 2);
            this.m_chkPeritoneum4.Name = "m_chkPeritoneum4";
            this.m_chkPeritoneum4.Size = new System.Drawing.Size(40, 18);
            this.m_chkPeritoneum4.TabIndex = 163;
            this.m_chkPeritoneum4.Text = "横";
            this.m_chkPeritoneum4.UseVisualStyleBackColor = true;
            this.m_chkPeritoneum4.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // m_chkPeritoneum3
            // 
            this.m_chkPeritoneum3.AccessibleDescription = "腹膜>>纵";
            this.m_chkPeritoneum3.AutoSize = true;
            this.m_chkPeritoneum3.Location = new System.Drawing.Point(3, 2);
            this.m_chkPeritoneum3.Name = "m_chkPeritoneum3";
            this.m_chkPeritoneum3.Size = new System.Drawing.Size(40, 18);
            this.m_chkPeritoneum3.TabIndex = 162;
            this.m_chkPeritoneum3.Text = "纵";
            this.m_chkPeritoneum3.UseVisualStyleBackColor = true;
            this.m_chkPeritoneum3.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.m_chkPeritoneum6);
            this.panel12.Controls.Add(this.m_chkPeritoneum5);
            this.panel12.Location = new System.Drawing.Point(250, 406);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(112, 22);
            this.panel12.TabIndex = 10000080;
            // 
            // m_chkPeritoneum6
            // 
            this.m_chkPeritoneum6.AccessibleDescription = "腹膜>>锐性";
            this.m_chkPeritoneum6.AutoSize = true;
            this.m_chkPeritoneum6.Location = new System.Drawing.Point(58, 2);
            this.m_chkPeritoneum6.Name = "m_chkPeritoneum6";
            this.m_chkPeritoneum6.Size = new System.Drawing.Size(54, 18);
            this.m_chkPeritoneum6.TabIndex = 165;
            this.m_chkPeritoneum6.Text = "锐性";
            this.m_chkPeritoneum6.UseVisualStyleBackColor = true;
            // 
            // m_chkPeritoneum5
            // 
            this.m_chkPeritoneum5.AccessibleDescription = "腹膜>>钝性";
            this.m_chkPeritoneum5.AutoSize = true;
            this.m_chkPeritoneum5.Location = new System.Drawing.Point(4, 2);
            this.m_chkPeritoneum5.Name = "m_chkPeritoneum5";
            this.m_chkPeritoneum5.Size = new System.Drawing.Size(54, 18);
            this.m_chkPeritoneum5.TabIndex = 164;
            this.m_chkPeritoneum5.Text = "钝性";
            this.m_chkPeritoneum5.UseVisualStyleBackColor = true;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.m_chkUterus2);
            this.panel13.Controls.Add(this.m_chkUterus1);
            this.panel13.Location = new System.Drawing.Point(499, 406);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(115, 22);
            this.panel13.TabIndex = 10000080;
            // 
            // m_chkUterus2
            // 
            this.m_chkUterus2.AccessibleDescription = "子宫>>下段";
            this.m_chkUterus2.AutoSize = true;
            this.m_chkUterus2.Location = new System.Drawing.Point(58, 2);
            this.m_chkUterus2.Name = "m_chkUterus2";
            this.m_chkUterus2.Size = new System.Drawing.Size(54, 18);
            this.m_chkUterus2.TabIndex = 171;
            this.m_chkUterus2.Text = "下段";
            this.m_chkUterus2.UseVisualStyleBackColor = true;
            this.m_chkUterus2.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // m_chkUterus1
            // 
            this.m_chkUterus1.AccessibleDescription = "子宫>>体部";
            this.m_chkUterus1.AutoSize = true;
            this.m_chkUterus1.Location = new System.Drawing.Point(4, 2);
            this.m_chkUterus1.Name = "m_chkUterus1";
            this.m_chkUterus1.Size = new System.Drawing.Size(54, 18);
            this.m_chkUterus1.TabIndex = 170;
            this.m_chkUterus1.Text = "体部";
            this.m_chkUterus1.UseVisualStyleBackColor = true;
            this.m_chkUterus1.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.m_chkFascia4);
            this.panel9.Controls.Add(this.m_chkFascia3);
            this.panel9.Location = new System.Drawing.Point(656, 379);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(130, 22);
            this.panel9.TabIndex = 10000080;
            // 
            // m_chkFascia4
            // 
            this.m_chkFascia4.AccessibleDescription = "筋膜>>锐性";
            this.m_chkFascia4.AutoSize = true;
            this.m_chkFascia4.Location = new System.Drawing.Point(58, 2);
            this.m_chkFascia4.Name = "m_chkFascia4";
            this.m_chkFascia4.Size = new System.Drawing.Size(54, 18);
            this.m_chkFascia4.TabIndex = 158;
            this.m_chkFascia4.Text = "锐性";
            this.m_chkFascia4.UseVisualStyleBackColor = true;
            // 
            // m_chkFascia3
            // 
            this.m_chkFascia3.AccessibleDescription = "筋膜>>钝性";
            this.m_chkFascia3.AutoSize = true;
            this.m_chkFascia3.Location = new System.Drawing.Point(4, 2);
            this.m_chkFascia3.Name = "m_chkFascia3";
            this.m_chkFascia3.Size = new System.Drawing.Size(54, 18);
            this.m_chkFascia3.TabIndex = 157;
            this.m_chkFascia3.Text = "钝性";
            this.m_chkFascia3.UseVisualStyleBackColor = true;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.m_chkPeritoneum2);
            this.panel10.Controls.Add(this.m_chkPeritoneum1);
            this.panel10.Location = new System.Drawing.Point(78, 406);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(84, 22);
            this.panel10.TabIndex = 10000079;
            // 
            // m_chkPeritoneum2
            // 
            this.m_chkPeritoneum2.AccessibleDescription = "腹膜>>外";
            this.m_chkPeritoneum2.AutoSize = true;
            this.m_chkPeritoneum2.Location = new System.Drawing.Point(47, 2);
            this.m_chkPeritoneum2.Name = "m_chkPeritoneum2";
            this.m_chkPeritoneum2.Size = new System.Drawing.Size(40, 18);
            this.m_chkPeritoneum2.TabIndex = 161;
            this.m_chkPeritoneum2.Text = "外";
            this.m_chkPeritoneum2.UseVisualStyleBackColor = true;
            this.m_chkPeritoneum2.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // m_chkPeritoneum1
            // 
            this.m_chkPeritoneum1.AccessibleDescription = "腹膜>>内";
            this.m_chkPeritoneum1.AutoSize = true;
            this.m_chkPeritoneum1.Location = new System.Drawing.Point(6, 2);
            this.m_chkPeritoneum1.Name = "m_chkPeritoneum1";
            this.m_chkPeritoneum1.Size = new System.Drawing.Size(40, 18);
            this.m_chkPeritoneum1.TabIndex = 160;
            this.m_chkPeritoneum1.Text = "内";
            this.m_chkPeritoneum1.UseVisualStyleBackColor = true;
            this.m_chkPeritoneum1.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.m_chkUterus4);
            this.panel14.Controls.Add(this.m_chkUterus3);
            this.panel14.Location = new System.Drawing.Point(613, 406);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(91, 22);
            this.panel14.TabIndex = 10000079;
            // 
            // m_chkUterus4
            // 
            this.m_chkUterus4.AccessibleDescription = "子宫>>横";
            this.m_chkUterus4.AutoSize = true;
            this.m_chkUterus4.Location = new System.Drawing.Point(47, 2);
            this.m_chkUterus4.Name = "m_chkUterus4";
            this.m_chkUterus4.Size = new System.Drawing.Size(40, 18);
            this.m_chkUterus4.TabIndex = 173;
            this.m_chkUterus4.Text = "横";
            this.m_chkUterus4.UseVisualStyleBackColor = true;
            this.m_chkUterus4.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // m_chkUterus3
            // 
            this.m_chkUterus3.AccessibleDescription = "子宫>>纵";
            this.m_chkUterus3.AutoSize = true;
            this.m_chkUterus3.Location = new System.Drawing.Point(6, 2);
            this.m_chkUterus3.Name = "m_chkUterus3";
            this.m_chkUterus3.Size = new System.Drawing.Size(40, 18);
            this.m_chkUterus3.TabIndex = 172;
            this.m_chkUterus3.Text = "纵";
            this.m_chkUterus3.UseVisualStyleBackColor = true;
            this.m_chkUterus3.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.m_chkFascia2);
            this.panel8.Controls.Add(this.m_chkFascia1);
            this.panel8.Location = new System.Drawing.Point(568, 379);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(91, 22);
            this.panel8.TabIndex = 10000079;
            // 
            // m_chkFascia2
            // 
            this.m_chkFascia2.AccessibleDescription = "筋膜>>横";
            this.m_chkFascia2.AutoSize = true;
            this.m_chkFascia2.Location = new System.Drawing.Point(47, 2);
            this.m_chkFascia2.Name = "m_chkFascia2";
            this.m_chkFascia2.Size = new System.Drawing.Size(40, 18);
            this.m_chkFascia2.TabIndex = 156;
            this.m_chkFascia2.Text = "横";
            this.m_chkFascia2.UseVisualStyleBackColor = true;
            this.m_chkFascia2.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // m_chkFascia1
            // 
            this.m_chkFascia1.AccessibleDescription = "筋膜>>纵";
            this.m_chkFascia1.AutoSize = true;
            this.m_chkFascia1.Location = new System.Drawing.Point(6, 2);
            this.m_chkFascia1.Name = "m_chkFascia1";
            this.m_chkFascia1.Size = new System.Drawing.Size(40, 18);
            this.m_chkFascia1.TabIndex = 150;
            this.m_chkFascia1.Text = "纵";
            this.m_chkFascia1.UseVisualStyleBackColor = true;
            this.m_chkFascia1.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(296, 382);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(28, 14);
            this.label37.TabIndex = 10000078;
            this.label37.Text = "横:";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(77, 383);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(28, 14);
            this.label36.TabIndex = 10000078;
            this.label36.Text = "纵:";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(423, 438);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(70, 14);
            this.label43.TabIndex = 10000078;
            this.label43.Text = "先露娩出:";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(524, 383);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(42, 14);
            this.label38.TabIndex = 10000078;
            this.label38.Text = "筋膜:";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(238, 439);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(42, 14);
            this.label42.TabIndex = 10000078;
            this.label42.Text = "入盆:";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(35, 411);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(42, 14);
            this.label39.TabIndex = 10000078;
            this.label39.Text = "腹膜:";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(451, 411);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(42, 14);
            this.label40.TabIndex = 10000078;
            this.label40.Text = "子宫:";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(36, 383);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(42, 14);
            this.label35.TabIndex = 10000078;
            this.label35.Text = "腹壁:";
            // 
            // label34
            // 
            this.label34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label34.Location = new System.Drawing.Point(8, 374);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(26, 90);
            this.label34.TabIndex = 10000077;
            this.label34.Text = "手术方式";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label33
            // 
            this.label33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label33.Location = new System.Drawing.Point(8, 373);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(791, 2);
            this.label33.TabIndex = 10000076;
            // 
            // m_chkUnCheckBeforeOP
            // 
            this.m_chkUnCheckBeforeOP.AccessibleDescription = "术前阴查未检";
            this.m_chkUnCheckBeforeOP.AutoSize = true;
            this.m_chkUnCheckBeforeOP.Location = new System.Drawing.Point(76, 264);
            this.m_chkUnCheckBeforeOP.Name = "m_chkUnCheckBeforeOP";
            this.m_chkUnCheckBeforeOP.Size = new System.Drawing.Size(68, 18);
            this.m_chkUnCheckBeforeOP.TabIndex = 70;
            this.m_chkUnCheckBeforeOP.Text = "(未检)";
            this.m_chkUnCheckBeforeOP.UseVisualStyleBackColor = true;
            this.m_chkUnCheckBeforeOP.CheckedChanged += new System.EventHandler(this.m_chkUnCheckBeforeOP_CheckedChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 264);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(70, 14);
            this.label16.TabIndex = 10000050;
            this.label16.Text = "术前阴查:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label64);
            this.panel2.Controls.Add(this.panel21);
            this.panel2.Controls.Add(this.m_txtPresentation2);
            this.panel2.Controls.Add(this.label95);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.m_txtCaputSuccedaneumPlace1);
            this.panel2.Controls.Add(this.m_txtCaputSuccedaneumSize);
            this.panel2.Controls.Add(this.m_txtPresentationHeight);
            this.panel2.Controls.Add(this.m_txtFetusPlace1);
            this.panel2.Controls.Add(this.m_txtUterusora);
            this.panel2.Controls.Add(this.m_txtPubicArch);
            this.panel2.Controls.Add(this.m_txtDC);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Controls.Add(this.label24);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.label27);
            this.panel2.Controls.Add(this.label29);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label28);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label26);
            this.panel2.Controls.Add(this.label25);
            this.panel2.Controls.Add(this.label32);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Location = new System.Drawing.Point(39, 258);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(760, 116);
            this.panel2.TabIndex = 10000074;
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(289, 91);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(35, 14);
            this.label64.TabIndex = 10000105;
            this.label64.Text = "产瘤";
            // 
            // panel21
            // 
            this.panel21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel21.Controls.Add(this.chkNoSuccedaneum1);
            this.panel21.Controls.Add(this.chkHasSuccedaneum1);
            this.panel21.Location = new System.Drawing.Point(325, 86);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(82, 25);
            this.panel21.TabIndex = 10000104;
            // 
            // chkNoSuccedaneum1
            // 
            this.chkNoSuccedaneum1.AccessibleDescription = "产瘤>>无1";
            this.chkNoSuccedaneum1.AutoSize = true;
            this.chkNoSuccedaneum1.Checked = true;
            this.chkNoSuccedaneum1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNoSuccedaneum1.Location = new System.Drawing.Point(41, 3);
            this.chkNoSuccedaneum1.Name = "chkNoSuccedaneum1";
            this.chkNoSuccedaneum1.Size = new System.Drawing.Size(40, 18);
            this.chkNoSuccedaneum1.TabIndex = 10000103;
            this.chkNoSuccedaneum1.Text = "无";
            this.chkNoSuccedaneum1.UseVisualStyleBackColor = true;
            this.chkNoSuccedaneum1.CheckedChanged += new System.EventHandler(this.chkNoSuccedaneum1_CheckedChanged);
            // 
            // chkHasSuccedaneum1
            // 
            this.chkHasSuccedaneum1.AccessibleDescription = "产瘤>>有1";
            this.chkHasSuccedaneum1.AutoSize = true;
            this.chkHasSuccedaneum1.Location = new System.Drawing.Point(3, 3);
            this.chkHasSuccedaneum1.Name = "chkHasSuccedaneum1";
            this.chkHasSuccedaneum1.Size = new System.Drawing.Size(40, 18);
            this.chkHasSuccedaneum1.TabIndex = 10000102;
            this.chkHasSuccedaneum1.Text = "有";
            this.chkHasSuccedaneum1.UseVisualStyleBackColor = true;
            this.chkHasSuccedaneum1.CheckedChanged += new System.EventHandler(this.chkHasSuccedaneum1_CheckedChanged);
            // 
            // m_txtPresentation2
            // 
            this.m_txtPresentation2.AccessibleDescription = "术前阴查>>先露";
            this.m_txtPresentation2.BackColor = System.Drawing.Color.White;
            this.m_txtPresentation2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPresentation2.ForeColor = System.Drawing.Color.Black;
            this.m_txtPresentation2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPresentation2.Location = new System.Drawing.Point(349, 59);
            this.m_txtPresentation2.m_BlnIgnoreUserInfo = false;
            this.m_txtPresentation2.m_BlnPartControl = false;
            this.m_txtPresentation2.m_BlnReadOnly = false;
            this.m_txtPresentation2.m_BlnUnderLineDST = false;
            this.m_txtPresentation2.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPresentation2.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPresentation2.m_IntCanModifyTime = 6;
            this.m_txtPresentation2.m_IntPartControlLength = 0;
            this.m_txtPresentation2.m_IntPartControlStartIndex = 0;
            this.m_txtPresentation2.m_StrUserID = "";
            this.m_txtPresentation2.m_StrUserName = "";
            this.m_txtPresentation2.MaxLength = 50;
            this.m_txtPresentation2.Multiline = false;
            this.m_txtPresentation2.Name = "m_txtPresentation2";
            this.m_txtPresentation2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtPresentation2.Size = new System.Drawing.Size(58, 24);
            this.m_txtPresentation2.TabIndex = 10000100;
            this.m_txtPresentation2.Text = "";
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.Location = new System.Drawing.Point(315, 62);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(35, 14);
            this.label95.TabIndex = 10000101;
            this.label95.Text = "先露";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.m_chkAmniocentesis14);
            this.panel5.Controls.Add(this.m_chkAmniocentesis13);
            this.panel5.Controls.Add(this.m_chkAmniocentesis12);
            this.panel5.Controls.Add(this.m_chkAmniocentesis11);
            this.panel5.Location = new System.Drawing.Point(124, 60);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(168, 25);
            this.panel5.TabIndex = 10000097;
            // 
            // m_chkAmniocentesis14
            // 
            this.m_chkAmniocentesis14.AccessibleDescription = "术前阴检>>坐术前阴检>>羊水>>Ⅲ";
            this.m_chkAmniocentesis14.AutoSize = true;
            this.m_chkAmniocentesis14.Location = new System.Drawing.Point(123, 4);
            this.m_chkAmniocentesis14.Name = "m_chkAmniocentesis14";
            this.m_chkAmniocentesis14.Size = new System.Drawing.Size(40, 18);
            this.m_chkAmniocentesis14.TabIndex = 113;
            this.m_chkAmniocentesis14.Text = "Ⅲ";
            this.m_chkAmniocentesis14.UseVisualStyleBackColor = true;
            // 
            // m_chkAmniocentesis13
            // 
            this.m_chkAmniocentesis13.AccessibleDescription = "术前阴检>>羊水>>Ⅱ";
            this.m_chkAmniocentesis13.AutoSize = true;
            this.m_chkAmniocentesis13.Location = new System.Drawing.Point(83, 4);
            this.m_chkAmniocentesis13.Name = "m_chkAmniocentesis13";
            this.m_chkAmniocentesis13.Size = new System.Drawing.Size(40, 18);
            this.m_chkAmniocentesis13.TabIndex = 112;
            this.m_chkAmniocentesis13.Text = "Ⅱ";
            this.m_chkAmniocentesis13.UseVisualStyleBackColor = true;
            // 
            // m_chkAmniocentesis12
            // 
            this.m_chkAmniocentesis12.AccessibleDescription = "术前阴检>>羊水>>Ⅰ";
            this.m_chkAmniocentesis12.AutoSize = true;
            this.m_chkAmniocentesis12.Location = new System.Drawing.Point(43, 4);
            this.m_chkAmniocentesis12.Name = "m_chkAmniocentesis12";
            this.m_chkAmniocentesis12.Size = new System.Drawing.Size(40, 18);
            this.m_chkAmniocentesis12.TabIndex = 111;
            this.m_chkAmniocentesis12.Text = "Ⅰ";
            this.m_chkAmniocentesis12.UseVisualStyleBackColor = true;
            // 
            // m_chkAmniocentesis11
            // 
            this.m_chkAmniocentesis11.AccessibleDescription = "术前阴检>>羊水>>清";
            this.m_chkAmniocentesis11.AutoSize = true;
            this.m_chkAmniocentesis11.Location = new System.Drawing.Point(3, 4);
            this.m_chkAmniocentesis11.Name = "m_chkAmniocentesis11";
            this.m_chkAmniocentesis11.Size = new System.Drawing.Size(40, 18);
            this.m_chkAmniocentesis11.TabIndex = 110;
            this.m_chkAmniocentesis11.Text = "清";
            this.m_chkAmniocentesis11.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.m_chkIshiumNotch3);
            this.panel4.Controls.Add(this.m_chkIshiumNotch2);
            this.panel4.Controls.Add(this.m_chkIshiumNotch1);
            this.panel4.Location = new System.Drawing.Point(124, 32);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(168, 25);
            this.panel4.TabIndex = 10000096;
            // 
            // m_chkIshiumNotch3
            // 
            this.m_chkIshiumNotch3.AccessibleDescription = "术前阴检>>坐骨切迹>>小于2指";
            this.m_chkIshiumNotch3.AutoSize = true;
            this.m_chkIshiumNotch3.Location = new System.Drawing.Point(113, 4);
            this.m_chkIshiumNotch3.Name = "m_chkIshiumNotch3";
            this.m_chkIshiumNotch3.Size = new System.Drawing.Size(54, 18);
            this.m_chkIshiumNotch3.TabIndex = 87;
            this.m_chkIshiumNotch3.Text = "<2指";
            this.m_chkIshiumNotch3.UseVisualStyleBackColor = true;
            this.m_chkIshiumNotch3.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // m_chkIshiumNotch2
            // 
            this.m_chkIshiumNotch2.AccessibleDescription = "术前阴检>>坐骨切迹>>等于2指";
            this.m_chkIshiumNotch2.AutoSize = true;
            this.m_chkIshiumNotch2.Location = new System.Drawing.Point(56, 4);
            this.m_chkIshiumNotch2.Name = "m_chkIshiumNotch2";
            this.m_chkIshiumNotch2.Size = new System.Drawing.Size(54, 18);
            this.m_chkIshiumNotch2.TabIndex = 86;
            this.m_chkIshiumNotch2.Text = "=2指";
            this.m_chkIshiumNotch2.UseVisualStyleBackColor = true;
            this.m_chkIshiumNotch2.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // m_chkIshiumNotch1
            // 
            this.m_chkIshiumNotch1.AccessibleDescription = "术前阴检>>坐骨切迹>>大于2指";
            this.m_chkIshiumNotch1.AutoSize = true;
            this.m_chkIshiumNotch1.Location = new System.Drawing.Point(3, 4);
            this.m_chkIshiumNotch1.Name = "m_chkIshiumNotch1";
            this.m_chkIshiumNotch1.Size = new System.Drawing.Size(54, 18);
            this.m_chkIshiumNotch1.TabIndex = 85;
            this.m_chkIshiumNotch1.Text = ">2指";
            this.m_chkIshiumNotch1.UseVisualStyleBackColor = true;
            this.m_chkIshiumNotch1.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.m_chkIschialSpine3);
            this.panel3.Controls.Add(this.m_chkIschialSpine2);
            this.panel3.Controls.Add(this.m_chkIschialSpine1);
            this.panel3.Location = new System.Drawing.Point(155, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(166, 25);
            this.panel3.TabIndex = 10000095;
            // 
            // m_chkIschialSpine3
            // 
            this.m_chkIschialSpine3.AccessibleDescription = "术前阴检>>坐骨棘>>突出";
            this.m_chkIschialSpine3.AutoSize = true;
            this.m_chkIschialSpine3.Location = new System.Drawing.Point(113, 4);
            this.m_chkIschialSpine3.Name = "m_chkIschialSpine3";
            this.m_chkIschialSpine3.Size = new System.Drawing.Size(54, 18);
            this.m_chkIschialSpine3.TabIndex = 77;
            this.m_chkIschialSpine3.Text = "突出";
            this.m_chkIschialSpine3.UseVisualStyleBackColor = true;
            this.m_chkIschialSpine3.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // m_chkIschialSpine2
            // 
            this.m_chkIschialSpine2.AccessibleDescription = "术前阴检>>坐骨棘>>稍突";
            this.m_chkIschialSpine2.AutoSize = true;
            this.m_chkIschialSpine2.Location = new System.Drawing.Point(56, 4);
            this.m_chkIschialSpine2.Name = "m_chkIschialSpine2";
            this.m_chkIschialSpine2.Size = new System.Drawing.Size(54, 18);
            this.m_chkIschialSpine2.TabIndex = 76;
            this.m_chkIschialSpine2.Text = "稍突";
            this.m_chkIschialSpine2.UseVisualStyleBackColor = true;
            this.m_chkIschialSpine2.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // m_chkIschialSpine1
            // 
            this.m_chkIschialSpine1.AccessibleDescription = "术前阴检>>坐骨棘>>平伏";
            this.m_chkIschialSpine1.AutoSize = true;
            this.m_chkIschialSpine1.Location = new System.Drawing.Point(3, 4);
            this.m_chkIschialSpine1.Name = "m_chkIschialSpine1";
            this.m_chkIschialSpine1.Size = new System.Drawing.Size(54, 18);
            this.m_chkIschialSpine1.TabIndex = 75;
            this.m_chkIschialSpine1.Text = "平伏";
            this.m_chkIschialSpine1.UseVisualStyleBackColor = true;
            this.m_chkIschialSpine1.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.m_chkSkull2);
            this.panel6.Controls.Add(this.m_chkSkull1);
            this.panel6.Location = new System.Drawing.Point(124, 88);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(88, 25);
            this.panel6.TabIndex = 10000099;
            // 
            // m_chkSkull2
            // 
            this.m_chkSkull2.AccessibleDescription = "术前阴检>>颅骨变形>>无";
            this.m_chkSkull2.AutoSize = true;
            this.m_chkSkull2.Location = new System.Drawing.Point(41, 4);
            this.m_chkSkull2.Name = "m_chkSkull2";
            this.m_chkSkull2.Size = new System.Drawing.Size(40, 18);
            this.m_chkSkull2.TabIndex = 126;
            this.m_chkSkull2.Text = "无";
            this.m_chkSkull2.UseVisualStyleBackColor = true;
            this.m_chkSkull2.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // m_chkSkull1
            // 
            this.m_chkSkull1.AccessibleDescription = "术前阴检>>颅骨变形>>有";
            this.m_chkSkull1.AutoSize = true;
            this.m_chkSkull1.Location = new System.Drawing.Point(3, 4);
            this.m_chkSkull1.Name = "m_chkSkull1";
            this.m_chkSkull1.Size = new System.Drawing.Size(40, 18);
            this.m_chkSkull1.TabIndex = 125;
            this.m_chkSkull1.Text = "有";
            this.m_chkSkull1.UseVisualStyleBackColor = true;
            this.m_chkSkull1.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.m_chkCoccyxRadian3);
            this.panel7.Controls.Add(this.m_chkCoccyxRadian2);
            this.panel7.Controls.Add(this.m_chkCoccyxRadian1);
            this.panel7.Location = new System.Drawing.Point(474, 4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(126, 25);
            this.panel7.TabIndex = 10000098;
            // 
            // m_chkCoccyxRadian3
            // 
            this.m_chkCoccyxRadian3.AccessibleDescription = "术前阴检>>尾骨弧度>>低";
            this.m_chkCoccyxRadian3.AutoSize = true;
            this.m_chkCoccyxRadian3.Location = new System.Drawing.Point(83, 4);
            this.m_chkCoccyxRadian3.Name = "m_chkCoccyxRadian3";
            this.m_chkCoccyxRadian3.Size = new System.Drawing.Size(40, 18);
            this.m_chkCoccyxRadian3.TabIndex = 82;
            this.m_chkCoccyxRadian3.Text = "低";
            this.m_chkCoccyxRadian3.UseVisualStyleBackColor = true;
            this.m_chkCoccyxRadian3.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // m_chkCoccyxRadian2
            // 
            this.m_chkCoccyxRadian2.AccessibleDescription = "术前阴检>>尾骨弧度>>中";
            this.m_chkCoccyxRadian2.AutoSize = true;
            this.m_chkCoccyxRadian2.Location = new System.Drawing.Point(41, 4);
            this.m_chkCoccyxRadian2.Name = "m_chkCoccyxRadian2";
            this.m_chkCoccyxRadian2.Size = new System.Drawing.Size(40, 18);
            this.m_chkCoccyxRadian2.TabIndex = 81;
            this.m_chkCoccyxRadian2.Text = "中";
            this.m_chkCoccyxRadian2.UseVisualStyleBackColor = true;
            this.m_chkCoccyxRadian2.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // m_chkCoccyxRadian1
            // 
            this.m_chkCoccyxRadian1.AccessibleDescription = "术前阴检>>尾骨弧度>>高";
            this.m_chkCoccyxRadian1.AutoSize = true;
            this.m_chkCoccyxRadian1.Location = new System.Drawing.Point(3, 4);
            this.m_chkCoccyxRadian1.Name = "m_chkCoccyxRadian1";
            this.m_chkCoccyxRadian1.Size = new System.Drawing.Size(40, 18);
            this.m_chkCoccyxRadian1.TabIndex = 80;
            this.m_chkCoccyxRadian1.Text = "高";
            this.m_chkCoccyxRadian1.UseVisualStyleBackColor = true;
            this.m_chkCoccyxRadian1.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // m_txtCaputSuccedaneumPlace1
            // 
            this.m_txtCaputSuccedaneumPlace1.AccessibleDescription = "术前阴查>>产瘤位置";
            this.m_txtCaputSuccedaneumPlace1.BackColor = System.Drawing.Color.White;
            this.m_txtCaputSuccedaneumPlace1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCaputSuccedaneumPlace1.ForeColor = System.Drawing.Color.Black;
            this.m_txtCaputSuccedaneumPlace1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCaputSuccedaneumPlace1.Location = new System.Drawing.Point(619, 86);
            this.m_txtCaputSuccedaneumPlace1.m_BlnIgnoreUserInfo = false;
            this.m_txtCaputSuccedaneumPlace1.m_BlnPartControl = false;
            this.m_txtCaputSuccedaneumPlace1.m_BlnReadOnly = false;
            this.m_txtCaputSuccedaneumPlace1.m_BlnUnderLineDST = false;
            this.m_txtCaputSuccedaneumPlace1.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCaputSuccedaneumPlace1.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCaputSuccedaneumPlace1.m_IntCanModifyTime = 6;
            this.m_txtCaputSuccedaneumPlace1.m_IntPartControlLength = 0;
            this.m_txtCaputSuccedaneumPlace1.m_IntPartControlStartIndex = 0;
            this.m_txtCaputSuccedaneumPlace1.m_StrUserID = "";
            this.m_txtCaputSuccedaneumPlace1.m_StrUserName = "";
            this.m_txtCaputSuccedaneumPlace1.MaxLength = 50;
            this.m_txtCaputSuccedaneumPlace1.Multiline = false;
            this.m_txtCaputSuccedaneumPlace1.Name = "m_txtCaputSuccedaneumPlace1";
            this.m_txtCaputSuccedaneumPlace1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtCaputSuccedaneumPlace1.Size = new System.Drawing.Size(138, 24);
            this.m_txtCaputSuccedaneumPlace1.TabIndex = 135;
            this.m_txtCaputSuccedaneumPlace1.Text = "";
            // 
            // m_txtCaputSuccedaneumSize
            // 
            this.m_txtCaputSuccedaneumSize.AccessibleDescription = "术前阴查>>产瘤大小";
            this.m_txtCaputSuccedaneumSize.BackColor = System.Drawing.Color.White;
            this.m_txtCaputSuccedaneumSize.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCaputSuccedaneumSize.ForeColor = System.Drawing.Color.Black;
            this.m_txtCaputSuccedaneumSize.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCaputSuccedaneumSize.Location = new System.Drawing.Point(484, 86);
            this.m_txtCaputSuccedaneumSize.m_BlnIgnoreUserInfo = false;
            this.m_txtCaputSuccedaneumSize.m_BlnPartControl = false;
            this.m_txtCaputSuccedaneumSize.m_BlnReadOnly = false;
            this.m_txtCaputSuccedaneumSize.m_BlnUnderLineDST = false;
            this.m_txtCaputSuccedaneumSize.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCaputSuccedaneumSize.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCaputSuccedaneumSize.m_IntCanModifyTime = 6;
            this.m_txtCaputSuccedaneumSize.m_IntPartControlLength = 0;
            this.m_txtCaputSuccedaneumSize.m_IntPartControlStartIndex = 0;
            this.m_txtCaputSuccedaneumSize.m_StrUserID = "";
            this.m_txtCaputSuccedaneumSize.m_StrUserName = "";
            this.m_txtCaputSuccedaneumSize.MaxLength = 50;
            this.m_txtCaputSuccedaneumSize.Multiline = false;
            this.m_txtCaputSuccedaneumSize.Name = "m_txtCaputSuccedaneumSize";
            this.m_txtCaputSuccedaneumSize.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtCaputSuccedaneumSize.Size = new System.Drawing.Size(58, 24);
            this.m_txtCaputSuccedaneumSize.TabIndex = 130;
            this.m_txtCaputSuccedaneumSize.Text = "";
            // 
            // m_txtPresentationHeight
            // 
            this.m_txtPresentationHeight.AccessibleDescription = "术前阴查>>先露高低";
            this.m_txtPresentationHeight.BackColor = System.Drawing.Color.White;
            this.m_txtPresentationHeight.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPresentationHeight.ForeColor = System.Drawing.Color.Black;
            this.m_txtPresentationHeight.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPresentationHeight.Location = new System.Drawing.Point(619, 59);
            this.m_txtPresentationHeight.m_BlnIgnoreUserInfo = false;
            this.m_txtPresentationHeight.m_BlnPartControl = false;
            this.m_txtPresentationHeight.m_BlnReadOnly = false;
            this.m_txtPresentationHeight.m_BlnUnderLineDST = false;
            this.m_txtPresentationHeight.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPresentationHeight.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPresentationHeight.m_IntCanModifyTime = 6;
            this.m_txtPresentationHeight.m_IntPartControlLength = 0;
            this.m_txtPresentationHeight.m_IntPartControlStartIndex = 0;
            this.m_txtPresentationHeight.m_StrUserID = "";
            this.m_txtPresentationHeight.m_StrUserName = "";
            this.m_txtPresentationHeight.MaxLength = 50;
            this.m_txtPresentationHeight.Multiline = false;
            this.m_txtPresentationHeight.Name = "m_txtPresentationHeight";
            this.m_txtPresentationHeight.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtPresentationHeight.Size = new System.Drawing.Size(58, 24);
            this.m_txtPresentationHeight.TabIndex = 120;
            this.m_txtPresentationHeight.Text = "";
            // 
            // m_txtFetusPlace1
            // 
            this.m_txtFetusPlace1.AccessibleDescription = "术前阴查>>胎方位";
            this.m_txtFetusPlace1.BackColor = System.Drawing.Color.White;
            this.m_txtFetusPlace1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtFetusPlace1.ForeColor = System.Drawing.Color.Black;
            this.m_txtFetusPlace1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtFetusPlace1.Location = new System.Drawing.Point(484, 59);
            this.m_txtFetusPlace1.m_BlnIgnoreUserInfo = false;
            this.m_txtFetusPlace1.m_BlnPartControl = false;
            this.m_txtFetusPlace1.m_BlnReadOnly = false;
            this.m_txtFetusPlace1.m_BlnUnderLineDST = false;
            this.m_txtFetusPlace1.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtFetusPlace1.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtFetusPlace1.m_IntCanModifyTime = 6;
            this.m_txtFetusPlace1.m_IntPartControlLength = 0;
            this.m_txtFetusPlace1.m_IntPartControlStartIndex = 0;
            this.m_txtFetusPlace1.m_StrUserID = "";
            this.m_txtFetusPlace1.m_StrUserName = "";
            this.m_txtFetusPlace1.MaxLength = 50;
            this.m_txtFetusPlace1.Multiline = false;
            this.m_txtFetusPlace1.Name = "m_txtFetusPlace1";
            this.m_txtFetusPlace1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtFetusPlace1.Size = new System.Drawing.Size(58, 24);
            this.m_txtFetusPlace1.TabIndex = 115;
            this.m_txtFetusPlace1.Text = "";
            // 
            // m_txtUterusora
            // 
            this.m_txtUterusora.AccessibleDescription = "术有阴检>>宫口";
            this.m_txtUterusora.BackColor = System.Drawing.Color.White;
            this.m_txtUterusora.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtUterusora.ForeColor = System.Drawing.Color.Black;
            this.m_txtUterusora.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtUterusora.Location = new System.Drawing.Point(619, 32);
            this.m_txtUterusora.m_BlnIgnoreUserInfo = false;
            this.m_txtUterusora.m_BlnPartControl = false;
            this.m_txtUterusora.m_BlnReadOnly = false;
            this.m_txtUterusora.m_BlnUnderLineDST = false;
            this.m_txtUterusora.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtUterusora.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtUterusora.m_IntCanModifyTime = 6;
            this.m_txtUterusora.m_IntPartControlLength = 0;
            this.m_txtUterusora.m_IntPartControlStartIndex = 0;
            this.m_txtUterusora.m_StrUserID = "";
            this.m_txtUterusora.m_StrUserName = "";
            this.m_txtUterusora.MaxLength = 50;
            this.m_txtUterusora.Multiline = false;
            this.m_txtUterusora.Name = "m_txtUterusora";
            this.m_txtUterusora.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtUterusora.Size = new System.Drawing.Size(58, 24);
            this.m_txtUterusora.TabIndex = 105;
            this.m_txtUterusora.Text = "";
            // 
            // m_txtPubicArch
            // 
            this.m_txtPubicArch.AccessibleDescription = "术有阴检>>耻骨弓";
            this.m_txtPubicArch.BackColor = System.Drawing.Color.White;
            this.m_txtPubicArch.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPubicArch.ForeColor = System.Drawing.Color.Black;
            this.m_txtPubicArch.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPubicArch.Location = new System.Drawing.Point(349, 32);
            this.m_txtPubicArch.m_BlnIgnoreUserInfo = false;
            this.m_txtPubicArch.m_BlnPartControl = false;
            this.m_txtPubicArch.m_BlnReadOnly = false;
            this.m_txtPubicArch.m_BlnUnderLineDST = false;
            this.m_txtPubicArch.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPubicArch.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPubicArch.m_IntCanModifyTime = 6;
            this.m_txtPubicArch.m_IntPartControlLength = 0;
            this.m_txtPubicArch.m_IntPartControlStartIndex = 0;
            this.m_txtPubicArch.m_StrUserID = "";
            this.m_txtPubicArch.m_StrUserName = "";
            this.m_txtPubicArch.MaxLength = 50;
            this.m_txtPubicArch.Multiline = false;
            this.m_txtPubicArch.Name = "m_txtPubicArch";
            this.m_txtPubicArch.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtPubicArch.Size = new System.Drawing.Size(58, 24);
            this.m_txtPubicArch.TabIndex = 90;
            this.m_txtPubicArch.Text = "";
            // 
            // m_txtDC
            // 
            this.m_txtDC.AccessibleDescription = "术有阴检>>DC";
            this.m_txtDC.BackColor = System.Drawing.Color.White;
            this.m_txtDC.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDC.ForeColor = System.Drawing.Color.Black;
            this.m_txtDC.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDC.Location = new System.Drawing.Point(484, 32);
            this.m_txtDC.m_BlnIgnoreUserInfo = false;
            this.m_txtDC.m_BlnPartControl = false;
            this.m_txtDC.m_BlnReadOnly = false;
            this.m_txtDC.m_BlnUnderLineDST = false;
            this.m_txtDC.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDC.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDC.m_IntCanModifyTime = 6;
            this.m_txtDC.m_IntPartControlLength = 0;
            this.m_txtDC.m_IntPartControlStartIndex = 0;
            this.m_txtDC.m_StrUserID = "";
            this.m_txtDC.m_StrUserName = "";
            this.m_txtDC.MaxLength = 50;
            this.m_txtDC.Multiline = false;
            this.m_txtDC.Name = "m_txtDC";
            this.m_txtDC.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtDC.Size = new System.Drawing.Size(58, 24);
            this.m_txtDC.TabIndex = 100;
            this.m_txtDC.Text = "";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(682, 37);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(21, 14);
            this.label23.TabIndex = 10000087;
            this.label23.Text = "cm";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(88, 66);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(35, 14);
            this.label24.TabIndex = 10000088;
            this.label24.Text = "羊水";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(547, 37);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(21, 14);
            this.label21.TabIndex = 10000086;
            this.label21.Text = "cm";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(60, 37);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(63, 14);
            this.label19.TabIndex = 10000080;
            this.label19.Text = "坐骨切迹";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(60, 93);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(63, 14);
            this.label27.TabIndex = 10000082;
            this.label27.Text = "颅骨变形";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(555, 91);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(63, 14);
            this.label29.TabIndex = 10000081;
            this.label29.Text = "产瘤位置";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(105, 9);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(49, 14);
            this.label17.TabIndex = 10000079;
            this.label17.Text = "坐骨棘";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(408, 91);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(77, 14);
            this.label28.TabIndex = 10000077;
            this.label28.Text = "产瘤(大小)";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(415, 9);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(63, 14);
            this.label18.TabIndex = 10000076;
            this.label18.Text = "尾骨弧度";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(557, 64);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(63, 14);
            this.label26.TabIndex = 10000078;
            this.label26.Text = "先露高低";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(428, 64);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(49, 14);
            this.label25.TabIndex = 10000083;
            this.label25.Text = "胎方位";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(301, 37);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(49, 14);
            this.label32.TabIndex = 10000084;
            this.label32.Text = "耻骨弓";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(585, 37);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(35, 14);
            this.label22.TabIndex = 10000085;
            this.label22.Text = "宫口";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(456, 37);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(21, 14);
            this.label20.TabIndex = 10000084;
            this.label20.Text = "DC";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.m_chkLinkup3);
            this.panel1.Controls.Add(this.m_chkLinkup2);
            this.panel1.Controls.Add(this.m_chkLinkup1);
            this.panel1.Location = new System.Drawing.Point(513, 230);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(126, 25);
            this.panel1.TabIndex = 10000073;
            // 
            // m_chkLinkup3
            // 
            this.m_chkLinkup3.AccessibleDescription = "术前产检>>衔接>>深";
            this.m_chkLinkup3.AutoSize = true;
            this.m_chkLinkup3.Location = new System.Drawing.Point(83, 4);
            this.m_chkLinkup3.Name = "m_chkLinkup3";
            this.m_chkLinkup3.Size = new System.Drawing.Size(40, 18);
            this.m_chkLinkup3.TabIndex = 62;
            this.m_chkLinkup3.Text = "深";
            this.m_chkLinkup3.UseVisualStyleBackColor = true;
            this.m_chkLinkup3.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // m_chkLinkup2
            // 
            this.m_chkLinkup2.AccessibleDescription = "术前产检>>衔接>>浅";
            this.m_chkLinkup2.AutoSize = true;
            this.m_chkLinkup2.Location = new System.Drawing.Point(41, 4);
            this.m_chkLinkup2.Name = "m_chkLinkup2";
            this.m_chkLinkup2.Size = new System.Drawing.Size(40, 18);
            this.m_chkLinkup2.TabIndex = 61;
            this.m_chkLinkup2.Text = "浅";
            this.m_chkLinkup2.UseVisualStyleBackColor = true;
            this.m_chkLinkup2.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // m_chkLinkup1
            // 
            this.m_chkLinkup1.AccessibleDescription = "术前产检>>衔接>>未";
            this.m_chkLinkup1.AutoSize = true;
            this.m_chkLinkup1.Location = new System.Drawing.Point(3, 4);
            this.m_chkLinkup1.Name = "m_chkLinkup1";
            this.m_chkLinkup1.Size = new System.Drawing.Size(40, 18);
            this.m_chkLinkup1.TabIndex = 60;
            this.m_chkLinkup1.Text = "未";
            this.m_chkLinkup1.UseVisualStyleBackColor = true;
            this.m_chkLinkup1.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // m_txtPresentation1
            // 
            this.m_txtPresentation1.AccessibleDescription = "术前产检>>先露";
            this.m_txtPresentation1.BackColor = System.Drawing.Color.White;
            this.m_txtPresentation1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPresentation1.ForeColor = System.Drawing.Color.Black;
            this.m_txtPresentation1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPresentation1.Location = new System.Drawing.Point(399, 232);
            this.m_txtPresentation1.m_BlnIgnoreUserInfo = false;
            this.m_txtPresentation1.m_BlnPartControl = false;
            this.m_txtPresentation1.m_BlnReadOnly = false;
            this.m_txtPresentation1.m_BlnUnderLineDST = false;
            this.m_txtPresentation1.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPresentation1.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPresentation1.m_IntCanModifyTime = 6;
            this.m_txtPresentation1.m_IntPartControlLength = 0;
            this.m_txtPresentation1.m_IntPartControlStartIndex = 0;
            this.m_txtPresentation1.m_StrUserID = "";
            this.m_txtPresentation1.m_StrUserName = "";
            this.m_txtPresentation1.MaxLength = 50;
            this.m_txtPresentation1.Multiline = false;
            this.m_txtPresentation1.Name = "m_txtPresentation1";
            this.m_txtPresentation1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtPresentation1.Size = new System.Drawing.Size(58, 24);
            this.m_txtPresentation1.TabIndex = 55;
            this.m_txtPresentation1.Text = "";
            // 
            // m_txtFetusWeight
            // 
            this.m_txtFetusWeight.AccessibleDescription = "术前产检>>估计胎重";
            this.m_txtFetusWeight.BackColor = System.Drawing.Color.White;
            this.m_txtFetusWeight.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtFetusWeight.ForeColor = System.Drawing.Color.Black;
            this.m_txtFetusWeight.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtFetusWeight.Location = new System.Drawing.Point(714, 232);
            this.m_txtFetusWeight.m_BlnIgnoreUserInfo = false;
            this.m_txtFetusWeight.m_BlnPartControl = false;
            this.m_txtFetusWeight.m_BlnReadOnly = false;
            this.m_txtFetusWeight.m_BlnUnderLineDST = false;
            this.m_txtFetusWeight.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtFetusWeight.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtFetusWeight.m_IntCanModifyTime = 6;
            this.m_txtFetusWeight.m_IntPartControlLength = 0;
            this.m_txtFetusWeight.m_IntPartControlStartIndex = 0;
            this.m_txtFetusWeight.m_StrUserID = "";
            this.m_txtFetusWeight.m_StrUserName = "";
            this.m_txtFetusWeight.MaxLength = 50;
            this.m_txtFetusWeight.Multiline = false;
            this.m_txtFetusWeight.Name = "m_txtFetusWeight";
            this.m_txtFetusWeight.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtFetusWeight.Size = new System.Drawing.Size(58, 24);
            this.m_txtFetusWeight.TabIndex = 65;
            this.m_txtFetusWeight.Text = "";
            // 
            // m_txtAbdomenRound
            // 
            this.m_txtAbdomenRound.AccessibleDescription = "术前产检>>腹围";
            this.m_txtAbdomenRound.BackColor = System.Drawing.Color.White;
            this.m_txtAbdomenRound.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtAbdomenRound.ForeColor = System.Drawing.Color.Black;
            this.m_txtAbdomenRound.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtAbdomenRound.Location = new System.Drawing.Point(255, 232);
            this.m_txtAbdomenRound.m_BlnIgnoreUserInfo = false;
            this.m_txtAbdomenRound.m_BlnPartControl = false;
            this.m_txtAbdomenRound.m_BlnReadOnly = false;
            this.m_txtAbdomenRound.m_BlnUnderLineDST = false;
            this.m_txtAbdomenRound.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtAbdomenRound.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtAbdomenRound.m_IntCanModifyTime = 6;
            this.m_txtAbdomenRound.m_IntPartControlLength = 0;
            this.m_txtAbdomenRound.m_IntPartControlStartIndex = 0;
            this.m_txtAbdomenRound.m_StrUserID = "";
            this.m_txtAbdomenRound.m_StrUserName = "";
            this.m_txtAbdomenRound.MaxLength = 50;
            this.m_txtAbdomenRound.Multiline = false;
            this.m_txtAbdomenRound.Name = "m_txtAbdomenRound";
            this.m_txtAbdomenRound.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtAbdomenRound.Size = new System.Drawing.Size(58, 24);
            this.m_txtAbdomenRound.TabIndex = 50;
            this.m_txtAbdomenRound.Text = "";
            // 
            // m_txtUterueHeight
            // 
            this.m_txtUterueHeight.AccessibleDescription = "术前产检>>宫高";
            this.m_txtUterueHeight.BackColor = System.Drawing.Color.White;
            this.m_txtUterueHeight.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtUterueHeight.ForeColor = System.Drawing.Color.Black;
            this.m_txtUterueHeight.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtUterueHeight.Location = new System.Drawing.Point(111, 232);
            this.m_txtUterueHeight.m_BlnIgnoreUserInfo = false;
            this.m_txtUterueHeight.m_BlnPartControl = false;
            this.m_txtUterueHeight.m_BlnReadOnly = false;
            this.m_txtUterueHeight.m_BlnUnderLineDST = false;
            this.m_txtUterueHeight.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtUterueHeight.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtUterueHeight.m_IntCanModifyTime = 6;
            this.m_txtUterueHeight.m_IntPartControlLength = 0;
            this.m_txtUterueHeight.m_IntPartControlStartIndex = 0;
            this.m_txtUterueHeight.m_StrUserID = "";
            this.m_txtUterueHeight.m_StrUserName = "";
            this.m_txtUterueHeight.MaxLength = 50;
            this.m_txtUterueHeight.Multiline = false;
            this.m_txtUterueHeight.Name = "m_txtUterueHeight";
            this.m_txtUterueHeight.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtUterueHeight.Size = new System.Drawing.Size(58, 24);
            this.m_txtUterueHeight.TabIndex = 45;
            this.m_txtUterueHeight.Text = "";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(774, 235);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(14, 14);
            this.label15.TabIndex = 10000057;
            this.label15.Text = "g";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(318, 235);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 14);
            this.label11.TabIndex = 10000042;
            this.label11.Text = "cm";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(174, 235);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 14);
            this.label9.TabIndex = 10000039;
            this.label9.Text = "cm";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(482, 235);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 14);
            this.label13.TabIndex = 10000053;
            this.label13.Text = "衔接";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(365, 235);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 14);
            this.label12.TabIndex = 10000052;
            this.label12.Text = "先露";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(653, 235);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 14);
            this.label14.TabIndex = 10000051;
            this.label14.Text = "估计胎重";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(221, 235);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 14);
            this.label10.TabIndex = 10000048;
            this.label10.Text = "腹围";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(77, 235);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 14);
            this.label8.TabIndex = 10000047;
            this.label8.Text = "宫高";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(7, 235);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(70, 14);
            this.label31.TabIndex = 10000049;
            this.label31.Text = "术前产检:";
            // 
            // label30
            // 
            this.label30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label30.Location = new System.Drawing.Point(7, 224);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(791, 2);
            this.label30.TabIndex = 10000036;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(700, 10);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(21, 14);
            this.label58.TabIndex = 10000034;
            this.label58.Text = "产";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(599, 10);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(21, 14);
            this.label57.TabIndex = 10000035;
            this.label57.Text = "孕";
            // 
            // m_cboLayTimes
            // 
            this.m_cboLayTimes.AccessibleDescription = "产次";
            this.m_cboLayTimes.BorderColor = System.Drawing.Color.Black;
            this.m_cboLayTimes.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboLayTimes.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboLayTimes.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboLayTimes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboLayTimes.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboLayTimes.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboLayTimes.ListBackColor = System.Drawing.Color.White;
            this.m_cboLayTimes.ListForeColor = System.Drawing.Color.Black;
            this.m_cboLayTimes.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboLayTimes.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboLayTimes.Location = new System.Drawing.Point(723, 5);
            this.m_cboLayTimes.m_BlnEnableItemEventMenu = true;
            this.m_cboLayTimes.Name = "m_cboLayTimes";
            this.m_cboLayTimes.SelectedIndex = -1;
            this.m_cboLayTimes.SelectedItem = null;
            this.m_cboLayTimes.SelectionStart = 0;
            this.m_cboLayTimes.Size = new System.Drawing.Size(69, 23);
            this.m_cboLayTimes.TabIndex = 10;
            this.m_cboLayTimes.TextBackColor = System.Drawing.Color.White;
            this.m_cboLayTimes.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboPregnantTimes
            // 
            this.m_cboPregnantTimes.AccessibleDescription = "孕次";
            this.m_cboPregnantTimes.BorderColor = System.Drawing.Color.Black;
            this.m_cboPregnantTimes.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboPregnantTimes.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboPregnantTimes.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboPregnantTimes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboPregnantTimes.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboPregnantTimes.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboPregnantTimes.ListBackColor = System.Drawing.Color.White;
            this.m_cboPregnantTimes.ListForeColor = System.Drawing.Color.Black;
            this.m_cboPregnantTimes.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboPregnantTimes.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboPregnantTimes.Location = new System.Drawing.Point(624, 5);
            this.m_cboPregnantTimes.m_BlnEnableItemEventMenu = true;
            this.m_cboPregnantTimes.Name = "m_cboPregnantTimes";
            this.m_cboPregnantTimes.SelectedIndex = -1;
            this.m_cboPregnantTimes.SelectedItem = null;
            this.m_cboPregnantTimes.SelectionStart = 0;
            this.m_cboPregnantTimes.Size = new System.Drawing.Size(69, 23);
            this.m_cboPregnantTimes.TabIndex = 5;
            this.m_cboPregnantTimes.TextBackColor = System.Drawing.Color.White;
            this.m_cboPregnantTimes.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_txtAnaesthetist
            // 
            this.m_txtAnaesthetist.AccessibleDescription = "麻醉师";
            this.m_txtAnaesthetist.AccessibleName = "NoDefault";
            this.m_txtAnaesthetist.BackColor = System.Drawing.Color.White;
            this.m_txtAnaesthetist.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtAnaesthetist.ForeColor = System.Drawing.Color.Black;
            this.m_txtAnaesthetist.Location = new System.Drawing.Point(697, 197);
            this.m_txtAnaesthetist.Name = "m_txtAnaesthetist";
            this.m_txtAnaesthetist.ReadOnly = true;
            this.m_txtAnaesthetist.Size = new System.Drawing.Size(95, 23);
            this.m_txtAnaesthetist.TabIndex = 41;
            // 
            // m_cmdAnaesthetist
            // 
            this.m_cmdAnaesthetist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdAnaesthetist.DefaultScheme = true;
            this.m_cmdAnaesthetist.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAnaesthetist.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdAnaesthetist.ForeColor = System.Drawing.Color.Black;
            this.m_cmdAnaesthetist.Hint = "";
            this.m_cmdAnaesthetist.Location = new System.Drawing.Point(623, 196);
            this.m_cmdAnaesthetist.Name = "m_cmdAnaesthetist";
            this.m_cmdAnaesthetist.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAnaesthetist.Size = new System.Drawing.Size(72, 24);
            this.m_cmdAnaesthetist.TabIndex = 40;
            this.m_cmdAnaesthetist.Text = "麻醉师:";
            // 
            // m_txtOPName
            // 
            this.m_txtOPName.AccessibleDescription = "手术名称";
            this.m_txtOPName.BackColor = System.Drawing.Color.White;
            this.m_txtOPName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOPName.ForeColor = System.Drawing.Color.Black;
            this.m_txtOPName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOPName.Location = new System.Drawing.Point(80, 169);
            this.m_txtOPName.m_BlnIgnoreUserInfo = false;
            this.m_txtOPName.m_BlnPartControl = false;
            this.m_txtOPName.m_BlnReadOnly = false;
            this.m_txtOPName.m_BlnUnderLineDST = false;
            this.m_txtOPName.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOPName.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOPName.m_IntCanModifyTime = 6;
            this.m_txtOPName.m_IntPartControlLength = 0;
            this.m_txtOPName.m_IntPartControlStartIndex = 0;
            this.m_txtOPName.m_StrUserID = "";
            this.m_txtOPName.m_StrUserName = "";
            this.m_txtOPName.MaxLength = 2000;
            this.m_txtOPName.Multiline = false;
            this.m_txtOPName.Name = "m_txtOPName";
            this.m_txtOPName.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtOPName.Size = new System.Drawing.Size(712, 24);
            this.m_txtOPName.TabIndex = 30;
            this.m_txtOPName.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 14);
            this.label7.TabIndex = 10000022;
            this.label7.Text = "手术名称:";
            // 
            // m_txtOPIndication
            // 
            this.m_txtOPIndication.AccessibleDescription = "手术指征";
            this.m_txtOPIndication.BackColor = System.Drawing.Color.White;
            this.m_txtOPIndication.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOPIndication.ForeColor = System.Drawing.Color.Black;
            this.m_txtOPIndication.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOPIndication.Location = new System.Drawing.Point(80, 87);
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
            this.m_txtOPIndication.Multiline = false;
            this.m_txtOPIndication.Name = "m_txtOPIndication";
            this.m_txtOPIndication.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtOPIndication.Size = new System.Drawing.Size(712, 24);
            this.m_txtOPIndication.TabIndex = 20;
            this.m_txtOPIndication.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 10000022;
            this.label4.Text = "手术指征:";
            // 
            // m_txtAbdominalWall_H
            // 
            this.m_txtAbdominalWall_H.AccessibleDescription = "腹壁_横";
            this.m_txtAbdominalWall_H.BackColor = System.Drawing.Color.White;
            this.m_txtAbdominalWall_H.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtAbdominalWall_H.ForeColor = System.Drawing.Color.Black;
            this.m_txtAbdominalWall_H.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtAbdominalWall_H.Location = new System.Drawing.Point(324, 378);
            this.m_txtAbdominalWall_H.m_BlnIgnoreUserInfo = false;
            this.m_txtAbdominalWall_H.m_BlnPartControl = false;
            this.m_txtAbdominalWall_H.m_BlnReadOnly = false;
            this.m_txtAbdominalWall_H.m_BlnUnderLineDST = false;
            this.m_txtAbdominalWall_H.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtAbdominalWall_H.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtAbdominalWall_H.m_IntCanModifyTime = 6;
            this.m_txtAbdominalWall_H.m_IntPartControlLength = 0;
            this.m_txtAbdominalWall_H.m_IntPartControlStartIndex = 0;
            this.m_txtAbdominalWall_H.m_StrUserID = "";
            this.m_txtAbdominalWall_H.m_StrUserName = "";
            this.m_txtAbdominalWall_H.MaxLength = 2000;
            this.m_txtAbdominalWall_H.Multiline = false;
            this.m_txtAbdominalWall_H.Name = "m_txtAbdominalWall_H";
            this.m_txtAbdominalWall_H.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtAbdominalWall_H.Size = new System.Drawing.Size(183, 24);
            this.m_txtAbdominalWall_H.TabIndex = 145;
            this.m_txtAbdominalWall_H.Text = "";
            // 
            // m_txtAbdominalWall_V
            // 
            this.m_txtAbdominalWall_V.AccessibleDescription = "腹壁_纵";
            this.m_txtAbdominalWall_V.BackColor = System.Drawing.Color.White;
            this.m_txtAbdominalWall_V.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtAbdominalWall_V.ForeColor = System.Drawing.Color.Black;
            this.m_txtAbdominalWall_V.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtAbdominalWall_V.Location = new System.Drawing.Point(105, 379);
            this.m_txtAbdominalWall_V.m_BlnIgnoreUserInfo = false;
            this.m_txtAbdominalWall_V.m_BlnPartControl = false;
            this.m_txtAbdominalWall_V.m_BlnReadOnly = false;
            this.m_txtAbdominalWall_V.m_BlnUnderLineDST = false;
            this.m_txtAbdominalWall_V.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtAbdominalWall_V.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtAbdominalWall_V.m_IntCanModifyTime = 6;
            this.m_txtAbdominalWall_V.m_IntPartControlLength = 0;
            this.m_txtAbdominalWall_V.m_IntPartControlStartIndex = 0;
            this.m_txtAbdominalWall_V.m_StrUserID = "";
            this.m_txtAbdominalWall_V.m_StrUserName = "";
            this.m_txtAbdominalWall_V.MaxLength = 2000;
            this.m_txtAbdominalWall_V.Multiline = false;
            this.m_txtAbdominalWall_V.Name = "m_txtAbdominalWall_V";
            this.m_txtAbdominalWall_V.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtAbdominalWall_V.Size = new System.Drawing.Size(183, 24);
            this.m_txtAbdominalWall_V.TabIndex = 140;
            this.m_txtAbdominalWall_V.Text = "";
            // 
            // m_txtAnaMode
            // 
            this.m_txtAnaMode.AccessibleDescription = "麻醉方式";
            this.m_txtAnaMode.BackColor = System.Drawing.Color.White;
            this.m_txtAnaMode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtAnaMode.ForeColor = System.Drawing.Color.Black;
            this.m_txtAnaMode.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtAnaMode.Location = new System.Drawing.Point(80, 197);
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
            this.m_txtAnaMode.Size = new System.Drawing.Size(537, 24);
            this.m_txtAnaMode.TabIndex = 35;
            this.m_txtAnaMode.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 14);
            this.label6.TabIndex = 10000023;
            this.label6.Text = "麻醉方式:";
            // 
            // m_txtDiagnosisAfterOP
            // 
            this.m_txtDiagnosisAfterOP.AccessibleDescription = "术后诊断";
            this.m_txtDiagnosisAfterOP.BackColor = System.Drawing.Color.White;
            this.m_txtDiagnosisAfterOP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDiagnosisAfterOP.ForeColor = System.Drawing.Color.Black;
            this.m_txtDiagnosisAfterOP.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDiagnosisAfterOP.Location = new System.Drawing.Point(80, 115);
            this.m_txtDiagnosisAfterOP.m_BlnIgnoreUserInfo = false;
            this.m_txtDiagnosisAfterOP.m_BlnPartControl = false;
            this.m_txtDiagnosisAfterOP.m_BlnReadOnly = false;
            this.m_txtDiagnosisAfterOP.m_BlnUnderLineDST = false;
            this.m_txtDiagnosisAfterOP.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDiagnosisAfterOP.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDiagnosisAfterOP.m_IntCanModifyTime = 6;
            this.m_txtDiagnosisAfterOP.m_IntPartControlLength = 0;
            this.m_txtDiagnosisAfterOP.m_IntPartControlStartIndex = 0;
            this.m_txtDiagnosisAfterOP.m_StrUserID = "";
            this.m_txtDiagnosisAfterOP.m_StrUserName = "";
            this.m_txtDiagnosisAfterOP.MaxLength = 2000;
            this.m_txtDiagnosisAfterOP.Name = "m_txtDiagnosisAfterOP";
            this.m_txtDiagnosisAfterOP.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtDiagnosisAfterOP.Size = new System.Drawing.Size(712, 50);
            this.m_txtDiagnosisAfterOP.TabIndex = 25;
            this.m_txtDiagnosisAfterOP.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 14);
            this.label5.TabIndex = 10000024;
            this.label5.Text = "术后诊断:";
            // 
            // m_txtDiagnosisBeforeOP
            // 
            this.m_txtDiagnosisBeforeOP.AccessibleDescription = "术前诊断";
            this.m_txtDiagnosisBeforeOP.BackColor = System.Drawing.Color.White;
            this.m_txtDiagnosisBeforeOP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDiagnosisBeforeOP.ForeColor = System.Drawing.Color.Black;
            this.m_txtDiagnosisBeforeOP.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDiagnosisBeforeOP.Location = new System.Drawing.Point(80, 33);
            this.m_txtDiagnosisBeforeOP.m_BlnIgnoreUserInfo = false;
            this.m_txtDiagnosisBeforeOP.m_BlnPartControl = false;
            this.m_txtDiagnosisBeforeOP.m_BlnReadOnly = false;
            this.m_txtDiagnosisBeforeOP.m_BlnUnderLineDST = false;
            this.m_txtDiagnosisBeforeOP.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDiagnosisBeforeOP.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDiagnosisBeforeOP.m_IntCanModifyTime = 6;
            this.m_txtDiagnosisBeforeOP.m_IntPartControlLength = 0;
            this.m_txtDiagnosisBeforeOP.m_IntPartControlStartIndex = 0;
            this.m_txtDiagnosisBeforeOP.m_StrUserID = "";
            this.m_txtDiagnosisBeforeOP.m_StrUserName = "";
            this.m_txtDiagnosisBeforeOP.MaxLength = 2000;
            this.m_txtDiagnosisBeforeOP.Name = "m_txtDiagnosisBeforeOP";
            this.m_txtDiagnosisBeforeOP.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtDiagnosisBeforeOP.Size = new System.Drawing.Size(712, 50);
            this.m_txtDiagnosisBeforeOP.TabIndex = 15;
            this.m_txtDiagnosisBeforeOP.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 10000025;
            this.label3.Text = "术前诊断:";
            // 
            // m_dtpOPDate
            // 
            this.m_dtpOPDate.AccessibleDescription = "手术日期";
            this.m_dtpOPDate.BorderColor = System.Drawing.Color.Black;
            this.m_dtpOPDate.CustomFormat = "yyyy年MM月dd日         ";
            this.m_dtpOPDate.DropButtonBackColor = System.Drawing.Color.Gainsboro;
            this.m_dtpOPDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpOPDate.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpOPDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpOPDate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpOPDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpOPDate.Location = new System.Drawing.Point(402, 5);
            this.m_dtpOPDate.m_BlnOnlyTime = false;
            this.m_dtpOPDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Day;
            this.m_dtpOPDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpOPDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpOPDate.Name = "m_dtpOPDate";
            this.m_dtpOPDate.ReadOnly = false;
            this.m_dtpOPDate.Size = new System.Drawing.Size(138, 22);
            this.m_dtpOPDate.TabIndex = 10000021;
            this.m_dtpOPDate.TextBackColor = System.Drawing.Color.White;
            this.m_dtpOPDate.TextForeColor = System.Drawing.Color.Black;
            this.m_dtpOPDate.evtValueChanged += new System.EventHandler(this.m_dtpOPDate_evtValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(332, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 10000020;
            this.label2.Text = "手术日期:";
            // 
            // m_lblInPatientDate
            // 
            this.m_lblInPatientDate.AutoSize = true;
            this.m_lblInPatientDate.Location = new System.Drawing.Point(77, 8);
            this.m_lblInPatientDate.Name = "m_lblInPatientDate";
            this.m_lblInPatientDate.Size = new System.Drawing.Size(0, 14);
            this.m_lblInPatientDate.TabIndex = 10000019;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 10000018;
            this.label1.Text = "入院日期:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel25);
            this.tabPage2.Controls.Add(this.panel20);
            this.tabPage2.Controls.Add(this.label63);
            this.tabPage2.Controls.Add(this.panel19);
            this.tabPage2.Controls.Add(this.label62);
            this.tabPage2.Controls.Add(this.m_txtSumary4);
            this.tabPage2.Controls.Add(this.m_cboOPTime);
            this.tabPage2.Controls.Add(this.m_cboANATime);
            this.tabPage2.Controls.Add(this.m_lsvAssistant2);
            this.tabPage2.Controls.Add(this.m_lsvAssistant1);
            this.tabPage2.Controls.Add(this.m_txtPLACENTA);
            this.tabPage2.Controls.Add(this.m_txtOperator);
            this.tabPage2.Controls.Add(this.m_cmdOperator);
            this.tabPage2.Controls.Add(this.m_cmdAssistant2);
            this.tabPage2.Controls.Add(this.m_cmdAssistant1);
            this.tabPage2.Controls.Add(this.label87);
            this.tabPage2.Controls.Add(this.label88);
            this.tabPage2.Controls.Add(this.label86);
            this.tabPage2.Controls.Add(this.m_txtTransfuse);
            this.tabPage2.Controls.Add(this.m_txtBleeding);
            this.tabPage2.Controls.Add(this.label85);
            this.tabPage2.Controls.Add(this.m_txtPiss);
            this.tabPage2.Controls.Add(this.label83);
            this.tabPage2.Controls.Add(this.label84);
            this.tabPage2.Controls.Add(this.label80);
            this.tabPage2.Controls.Add(this.label82);
            this.tabPage2.Controls.Add(this.label81);
            this.tabPage2.Controls.Add(this.m_txtOtherMedicine);
            this.tabPage2.Controls.Add(this.m_txtOxytocinIMIv);
            this.tabPage2.Controls.Add(this.m_txtSutureAbdominalWall);
            this.tabPage2.Controls.Add(this.m_txtSutureUterus);
            this.tabPage2.Controls.Add(this.panel24);
            this.tabPage2.Controls.Add(this.panel23);
            this.tabPage2.Controls.Add(this.label72);
            this.tabPage2.Controls.Add(this.label75);
            this.tabPage2.Controls.Add(this.label79);
            this.tabPage2.Controls.Add(this.label74);
            this.tabPage2.Controls.Add(this.label76);
            this.tabPage2.Controls.Add(this.label73);
            this.tabPage2.Controls.Add(this.label71);
            this.tabPage2.Controls.Add(this.m_txtAmniocentesisBulk);
            this.tabPage2.Controls.Add(this.label59);
            this.tabPage2.Controls.Add(this.label60);
            this.tabPage2.Controls.Add(this.panel18);
            this.tabPage2.Controls.Add(this.label56);
            this.tabPage2.Controls.Add(this.m_txtUMBILICALCORD);
            this.tabPage2.Controls.Add(this.m_txtCaputSuccedaneumPlace2);
            this.tabPage2.Controls.Add(this.m_txtFetusFacies);
            this.tabPage2.Controls.Add(this.m_txtApgar);
            this.tabPage2.Controls.Add(this.m_txtCaputsuccedaneumSezeY);
            this.tabPage2.Controls.Add(this.m_txtCaputsuccedaneumSezeX);
            this.tabPage2.Controls.Add(this.m_txtBabyWeight);
            this.tabPage2.Controls.Add(this.label49);
            this.tabPage2.Controls.Add(this.label67);
            this.tabPage2.Controls.Add(this.label61);
            this.tabPage2.Controls.Add(this.label53);
            this.tabPage2.Controls.Add(this.label52);
            this.tabPage2.Controls.Add(this.label51);
            this.tabPage2.Controls.Add(this.label54);
            this.tabPage2.Controls.Add(this.label50);
            this.tabPage2.Controls.Add(this.panel22);
            this.tabPage2.Controls.Add(this.panel17);
            this.tabPage2.Controls.Add(this.label69);
            this.tabPage2.Controls.Add(this.label55);
            this.tabPage2.Controls.Add(this.label48);
            this.tabPage2.Controls.Add(this.label47);
            this.tabPage2.Controls.Add(this.label70);
            this.tabPage2.Controls.Add(this.label46);
            this.tabPage2.Controls.Add(this.label45);
            this.tabPage2.Controls.Add(this.m_dtpExpulsionTime);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(800, 475);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "第二页";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel25
            // 
            this.panel25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel25.Controls.Add(this.chkNoSuccedaneum2);
            this.panel25.Controls.Add(this.chkHasSuccedaneum2);
            this.panel25.Location = new System.Drawing.Point(84, 63);
            this.panel25.Name = "panel25";
            this.panel25.Size = new System.Drawing.Size(82, 25);
            this.panel25.TabIndex = 10000127;
            // 
            // chkNoSuccedaneum2
            // 
            this.chkNoSuccedaneum2.AccessibleDescription = "产瘤>>无2";
            this.chkNoSuccedaneum2.AutoSize = true;
            this.chkNoSuccedaneum2.Checked = true;
            this.chkNoSuccedaneum2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNoSuccedaneum2.Location = new System.Drawing.Point(37, 3);
            this.chkNoSuccedaneum2.Name = "chkNoSuccedaneum2";
            this.chkNoSuccedaneum2.Size = new System.Drawing.Size(40, 18);
            this.chkNoSuccedaneum2.TabIndex = 10000103;
            this.chkNoSuccedaneum2.Text = "无";
            this.chkNoSuccedaneum2.UseVisualStyleBackColor = true;
            this.chkNoSuccedaneum2.CheckedChanged += new System.EventHandler(this.chkNoSuccedaneum2_CheckedChanged);
            // 
            // chkHasSuccedaneum2
            // 
            this.chkHasSuccedaneum2.AccessibleDescription = "产瘤>>有2";
            this.chkHasSuccedaneum2.AutoSize = true;
            this.chkHasSuccedaneum2.Location = new System.Drawing.Point(3, 3);
            this.chkHasSuccedaneum2.Name = "chkHasSuccedaneum2";
            this.chkHasSuccedaneum2.Size = new System.Drawing.Size(40, 18);
            this.chkHasSuccedaneum2.TabIndex = 10000102;
            this.chkHasSuccedaneum2.Text = "有";
            this.chkHasSuccedaneum2.UseVisualStyleBackColor = true;
            this.chkHasSuccedaneum2.CheckedChanged += new System.EventHandler(this.chkHasSuccedaneum2_CheckedChanged);
            // 
            // panel20
            // 
            this.panel20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel20.Controls.Add(this.m_chkOvaryCircs2R);
            this.panel20.Controls.Add(this.m_chkOvaryCircs1R);
            this.panel20.Location = new System.Drawing.Point(681, 153);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(115, 25);
            this.panel20.TabIndex = 10000126;
            // 
            // m_chkOvaryCircs2R
            // 
            this.m_chkOvaryCircs2R.AccessibleDescription = "右卵巢>>异常";
            this.m_chkOvaryCircs2R.AutoSize = true;
            this.m_chkOvaryCircs2R.Location = new System.Drawing.Point(59, 3);
            this.m_chkOvaryCircs2R.Name = "m_chkOvaryCircs2R";
            this.m_chkOvaryCircs2R.Size = new System.Drawing.Size(54, 18);
            this.m_chkOvaryCircs2R.TabIndex = 286;
            this.m_chkOvaryCircs2R.Text = "异常";
            this.m_chkOvaryCircs2R.UseVisualStyleBackColor = true;
            this.m_chkOvaryCircs2R.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // m_chkOvaryCircs1R
            // 
            this.m_chkOvaryCircs1R.AccessibleDescription = "右卵巢>>正常";
            this.m_chkOvaryCircs1R.AutoSize = true;
            this.m_chkOvaryCircs1R.Location = new System.Drawing.Point(5, 3);
            this.m_chkOvaryCircs1R.Name = "m_chkOvaryCircs1R";
            this.m_chkOvaryCircs1R.Size = new System.Drawing.Size(54, 18);
            this.m_chkOvaryCircs1R.TabIndex = 285;
            this.m_chkOvaryCircs1R.Text = "正常";
            this.m_chkOvaryCircs1R.UseVisualStyleBackColor = true;
            this.m_chkOvaryCircs1R.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(631, 159);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(63, 14);
            this.label63.TabIndex = 10000125;
            this.label63.Text = "右卵巢：";
            // 
            // panel19
            // 
            this.panel19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel19.Controls.Add(this.m_chkOviductCircs2R);
            this.panel19.Controls.Add(this.m_chkOviductCircs1R);
            this.panel19.Location = new System.Drawing.Point(289, 152);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(115, 25);
            this.panel19.TabIndex = 10000124;
            // 
            // m_chkOviductCircs2R
            // 
            this.m_chkOviductCircs2R.AccessibleDescription = "右输卵管>>异常";
            this.m_chkOviductCircs2R.AutoSize = true;
            this.m_chkOviductCircs2R.Location = new System.Drawing.Point(59, 3);
            this.m_chkOviductCircs2R.Name = "m_chkOviductCircs2R";
            this.m_chkOviductCircs2R.Size = new System.Drawing.Size(54, 18);
            this.m_chkOviductCircs2R.TabIndex = 281;
            this.m_chkOviductCircs2R.Text = "异常";
            this.m_chkOviductCircs2R.UseVisualStyleBackColor = true;
            this.m_chkOviductCircs2R.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // m_chkOviductCircs1R
            // 
            this.m_chkOviductCircs1R.AccessibleDescription = "右输卵管>>正常";
            this.m_chkOviductCircs1R.AutoSize = true;
            this.m_chkOviductCircs1R.Location = new System.Drawing.Point(5, 3);
            this.m_chkOviductCircs1R.Name = "m_chkOviductCircs1R";
            this.m_chkOviductCircs1R.Size = new System.Drawing.Size(54, 18);
            this.m_chkOviductCircs1R.TabIndex = 280;
            this.m_chkOviductCircs1R.Text = "正常";
            this.m_chkOviductCircs1R.UseVisualStyleBackColor = true;
            this.m_chkOviductCircs1R.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(212, 159);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(77, 14);
            this.label62.TabIndex = 10000123;
            this.label62.Text = "右输卵管：";
            // 
            // m_txtSumary4
            // 
            this.m_txtSumary4.AccessibleDescription = "备注4";
            this.m_txtSumary4.BackColor = System.Drawing.Color.White;
            this.m_txtSumary4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSumary4.ForeColor = System.Drawing.Color.Black;
            this.m_txtSumary4.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSumary4.Location = new System.Drawing.Point(74, 320);
            this.m_txtSumary4.m_BlnIgnoreUserInfo = false;
            this.m_txtSumary4.m_BlnPartControl = false;
            this.m_txtSumary4.m_BlnReadOnly = false;
            this.m_txtSumary4.m_BlnUnderLineDST = false;
            this.m_txtSumary4.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSumary4.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSumary4.m_IntCanModifyTime = 6;
            this.m_txtSumary4.m_IntPartControlLength = 0;
            this.m_txtSumary4.m_IntPartControlStartIndex = 0;
            this.m_txtSumary4.m_StrUserID = "";
            this.m_txtSumary4.m_StrUserName = "";
            this.m_txtSumary4.MaxLength = 2000;
            this.m_txtSumary4.Name = "m_txtSumary4";
            this.m_txtSumary4.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtSumary4.Size = new System.Drawing.Size(724, 114);
            this.m_txtSumary4.TabIndex = 295;
            this.m_txtSumary4.Text = "";
            // 
            // m_cboOPTime
            // 
            this.m_cboOPTime.AccessibleDescription = "手术时间";
            this.m_cboOPTime.BorderColor = System.Drawing.Color.Black;
            this.m_cboOPTime.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboOPTime.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboOPTime.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboOPTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboOPTime.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboOPTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboOPTime.ListBackColor = System.Drawing.Color.White;
            this.m_cboOPTime.ListForeColor = System.Drawing.Color.Black;
            this.m_cboOPTime.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboOPTime.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboOPTime.Location = new System.Drawing.Point(443, 290);
            this.m_cboOPTime.m_BlnEnableItemEventMenu = true;
            this.m_cboOPTime.Name = "m_cboOPTime";
            this.m_cboOPTime.SelectedIndex = -1;
            this.m_cboOPTime.SelectedItem = null;
            this.m_cboOPTime.SelectionStart = 0;
            this.m_cboOPTime.Size = new System.Drawing.Size(262, 23);
            this.m_cboOPTime.TabIndex = 10000122;
            this.m_cboOPTime.TextBackColor = System.Drawing.Color.White;
            this.m_cboOPTime.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboANATime
            // 
            this.m_cboANATime.AccessibleDescription = "麻醉时间";
            this.m_cboANATime.BorderColor = System.Drawing.Color.Black;
            this.m_cboANATime.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboANATime.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboANATime.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboANATime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboANATime.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboANATime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboANATime.ListBackColor = System.Drawing.Color.White;
            this.m_cboANATime.ListForeColor = System.Drawing.Color.Black;
            this.m_cboANATime.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboANATime.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboANATime.Location = new System.Drawing.Point(74, 290);
            this.m_cboANATime.m_BlnEnableItemEventMenu = true;
            this.m_cboANATime.Name = "m_cboANATime";
            this.m_cboANATime.SelectedIndex = -1;
            this.m_cboANATime.SelectedItem = null;
            this.m_cboANATime.SelectionStart = 0;
            this.m_cboANATime.Size = new System.Drawing.Size(262, 23);
            this.m_cboANATime.TabIndex = 10000122;
            this.m_cboANATime.TextBackColor = System.Drawing.Color.White;
            this.m_cboANATime.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_lsvAssistant2
            // 
            this.m_lsvAssistant2.Location = new System.Drawing.Point(597, 440);
            this.m_lsvAssistant2.MaxLength = 100;
            this.m_lsvAssistant2.Name = "m_lsvAssistant2";
            this.m_lsvAssistant2.Size = new System.Drawing.Size(201, 23);
            this.m_lsvAssistant2.TabIndex = 10000120;
            // 
            // m_lsvAssistant1
            // 
            this.m_lsvAssistant1.Location = new System.Drawing.Point(305, 442);
            this.m_lsvAssistant1.MaxLength = 100;
            this.m_lsvAssistant1.Name = "m_lsvAssistant1";
            this.m_lsvAssistant1.Size = new System.Drawing.Size(201, 23);
            this.m_lsvAssistant1.TabIndex = 10000120;
            // 
            // m_txtPLACENTA
            // 
            this.m_txtPLACENTA.AccessibleDescription = "手术经过>>胎盘";
            this.m_txtPLACENTA.BackColor = System.Drawing.Color.White;
            this.m_txtPLACENTA.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPLACENTA.ForeColor = System.Drawing.Color.Black;
            this.m_txtPLACENTA.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPLACENTA.Location = new System.Drawing.Point(84, 92);
            this.m_txtPLACENTA.m_BlnIgnoreUserInfo = false;
            this.m_txtPLACENTA.m_BlnPartControl = false;
            this.m_txtPLACENTA.m_BlnReadOnly = false;
            this.m_txtPLACENTA.m_BlnUnderLineDST = false;
            this.m_txtPLACENTA.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPLACENTA.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPLACENTA.m_IntCanModifyTime = 6;
            this.m_txtPLACENTA.m_IntPartControlLength = 0;
            this.m_txtPLACENTA.m_IntPartControlStartIndex = 0;
            this.m_txtPLACENTA.m_StrUserID = "";
            this.m_txtPLACENTA.m_StrUserName = "";
            this.m_txtPLACENTA.MaxLength = 2000;
            this.m_txtPLACENTA.Multiline = false;
            this.m_txtPLACENTA.Name = "m_txtPLACENTA";
            this.m_txtPLACENTA.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtPLACENTA.Size = new System.Drawing.Size(714, 24);
            this.m_txtPLACENTA.TabIndex = 225;
            this.m_txtPLACENTA.Text = "";
            // 
            // m_txtOperator
            // 
            this.m_txtOperator.AccessibleDescription = "手术者";
            this.m_txtOperator.AccessibleName = "NoDefault";
            this.m_txtOperator.BackColor = System.Drawing.Color.White;
            this.m_txtOperator.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOperator.ForeColor = System.Drawing.Color.Black;
            this.m_txtOperator.Location = new System.Drawing.Point(79, 442);
            this.m_txtOperator.Name = "m_txtOperator";
            this.m_txtOperator.ReadOnly = true;
            this.m_txtOperator.Size = new System.Drawing.Size(116, 23);
            this.m_txtOperator.TabIndex = 365;
            // 
            // m_cmdOperator
            // 
            this.m_cmdOperator.AccessibleDescription = "";
            this.m_cmdOperator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdOperator.DefaultScheme = true;
            this.m_cmdOperator.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdOperator.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdOperator.ForeColor = System.Drawing.Color.Black;
            this.m_cmdOperator.Hint = "";
            this.m_cmdOperator.Location = new System.Drawing.Point(5, 441);
            this.m_cmdOperator.Name = "m_cmdOperator";
            this.m_cmdOperator.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdOperator.Size = new System.Drawing.Size(72, 24);
            this.m_cmdOperator.TabIndex = 360;
            this.m_cmdOperator.Text = "手术者:";
            // 
            // m_cmdAssistant2
            // 
            this.m_cmdAssistant2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdAssistant2.DefaultScheme = true;
            this.m_cmdAssistant2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAssistant2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdAssistant2.ForeColor = System.Drawing.Color.Black;
            this.m_cmdAssistant2.Hint = "";
            this.m_cmdAssistant2.Location = new System.Drawing.Point(521, 440);
            this.m_cmdAssistant2.Name = "m_cmdAssistant2";
            this.m_cmdAssistant2.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAssistant2.Size = new System.Drawing.Size(72, 24);
            this.m_cmdAssistant2.TabIndex = 380;
            this.m_cmdAssistant2.Text = "第二助手:";
            // 
            // m_cmdAssistant1
            // 
            this.m_cmdAssistant1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdAssistant1.DefaultScheme = true;
            this.m_cmdAssistant1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAssistant1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdAssistant1.ForeColor = System.Drawing.Color.Black;
            this.m_cmdAssistant1.Hint = "";
            this.m_cmdAssistant1.Location = new System.Drawing.Point(229, 440);
            this.m_cmdAssistant1.Name = "m_cmdAssistant1";
            this.m_cmdAssistant1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAssistant1.Size = new System.Drawing.Size(72, 24);
            this.m_cmdAssistant1.TabIndex = 370;
            this.m_cmdAssistant1.Text = "第一助手:";
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Location = new System.Drawing.Point(367, 294);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(70, 14);
            this.label87.TabIndex = 10000119;
            this.label87.Text = "手术时间:";
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.Location = new System.Drawing.Point(6, 320);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(42, 14);
            this.label88.TabIndex = 10000119;
            this.label88.Text = "备注:";
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Location = new System.Drawing.Point(6, 294);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(70, 14);
            this.label86.TabIndex = 10000119;
            this.label86.Text = "麻醉时间:";
            // 
            // m_txtTransfuse
            // 
            this.m_txtTransfuse.AccessibleDescription = "输血量";
            this.m_txtTransfuse.BackColor = System.Drawing.Color.White;
            this.m_txtTransfuse.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtTransfuse.ForeColor = System.Drawing.Color.Black;
            this.m_txtTransfuse.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtTransfuse.Location = new System.Drawing.Point(443, 263);
            this.m_txtTransfuse.m_BlnIgnoreUserInfo = false;
            this.m_txtTransfuse.m_BlnPartControl = false;
            this.m_txtTransfuse.m_BlnReadOnly = false;
            this.m_txtTransfuse.m_BlnUnderLineDST = false;
            this.m_txtTransfuse.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtTransfuse.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtTransfuse.m_IntCanModifyTime = 6;
            this.m_txtTransfuse.m_IntPartControlLength = 0;
            this.m_txtTransfuse.m_IntPartControlStartIndex = 0;
            this.m_txtTransfuse.m_StrUserID = "";
            this.m_txtTransfuse.m_StrUserName = "";
            this.m_txtTransfuse.MaxLength = 50;
            this.m_txtTransfuse.Multiline = false;
            this.m_txtTransfuse.Name = "m_txtTransfuse";
            this.m_txtTransfuse.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtTransfuse.Size = new System.Drawing.Size(61, 24);
            this.m_txtTransfuse.TabIndex = 330;
            this.m_txtTransfuse.Text = "";
            // 
            // m_txtBleeding
            // 
            this.m_txtBleeding.AccessibleDescription = "出血量";
            this.m_txtBleeding.BackColor = System.Drawing.Color.White;
            this.m_txtBleeding.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBleeding.ForeColor = System.Drawing.Color.Black;
            this.m_txtBleeding.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBleeding.Location = new System.Drawing.Point(283, 263);
            this.m_txtBleeding.m_BlnIgnoreUserInfo = false;
            this.m_txtBleeding.m_BlnPartControl = false;
            this.m_txtBleeding.m_BlnReadOnly = false;
            this.m_txtBleeding.m_BlnUnderLineDST = false;
            this.m_txtBleeding.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBleeding.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBleeding.m_IntCanModifyTime = 6;
            this.m_txtBleeding.m_IntPartControlLength = 0;
            this.m_txtBleeding.m_IntPartControlStartIndex = 0;
            this.m_txtBleeding.m_StrUserID = "";
            this.m_txtBleeding.m_StrUserName = "";
            this.m_txtBleeding.MaxLength = 50;
            this.m_txtBleeding.Multiline = false;
            this.m_txtBleeding.Name = "m_txtBleeding";
            this.m_txtBleeding.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtBleeding.Size = new System.Drawing.Size(61, 24);
            this.m_txtBleeding.TabIndex = 325;
            this.m_txtBleeding.Text = "";
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.Location = new System.Drawing.Point(507, 271);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(21, 14);
            this.label85.TabIndex = 10000117;
            this.label85.Text = "ml";
            // 
            // m_txtPiss
            // 
            this.m_txtPiss.AccessibleDescription = "尿量";
            this.m_txtPiss.BackColor = System.Drawing.Color.White;
            this.m_txtPiss.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPiss.ForeColor = System.Drawing.Color.Black;
            this.m_txtPiss.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPiss.Location = new System.Drawing.Point(127, 263);
            this.m_txtPiss.m_BlnIgnoreUserInfo = false;
            this.m_txtPiss.m_BlnPartControl = false;
            this.m_txtPiss.m_BlnReadOnly = false;
            this.m_txtPiss.m_BlnUnderLineDST = false;
            this.m_txtPiss.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPiss.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPiss.m_IntCanModifyTime = 6;
            this.m_txtPiss.m_IntPartControlLength = 0;
            this.m_txtPiss.m_IntPartControlStartIndex = 0;
            this.m_txtPiss.m_StrUserID = "";
            this.m_txtPiss.m_StrUserName = "";
            this.m_txtPiss.MaxLength = 50;
            this.m_txtPiss.Multiline = false;
            this.m_txtPiss.Name = "m_txtPiss";
            this.m_txtPiss.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtPiss.Size = new System.Drawing.Size(61, 24);
            this.m_txtPiss.TabIndex = 320;
            this.m_txtPiss.Text = "";
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Location = new System.Drawing.Point(344, 274);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(21, 14);
            this.label83.TabIndex = 10000117;
            this.label83.Text = "ml";
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Location = new System.Drawing.Point(409, 270);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(35, 14);
            this.label84.TabIndex = 10000116;
            this.label84.Text = "输血";
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.Location = new System.Drawing.Point(189, 270);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(21, 14);
            this.label80.TabIndex = 10000117;
            this.label80.Text = "ml";
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Location = new System.Drawing.Point(249, 270);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(35, 14);
            this.label82.TabIndex = 10000116;
            this.label82.Text = "出血";
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.Location = new System.Drawing.Point(91, 269);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(35, 14);
            this.label81.TabIndex = 10000116;
            this.label81.Text = "尿量";
            // 
            // m_txtOtherMedicine
            // 
            this.m_txtOtherMedicine.AccessibleDescription = "其它术中用药";
            this.m_txtOtherMedicine.BackColor = System.Drawing.Color.White;
            this.m_txtOtherMedicine.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOtherMedicine.ForeColor = System.Drawing.Color.Black;
            this.m_txtOtherMedicine.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOtherMedicine.Location = new System.Drawing.Point(511, 236);
            this.m_txtOtherMedicine.m_BlnIgnoreUserInfo = false;
            this.m_txtOtherMedicine.m_BlnPartControl = false;
            this.m_txtOtherMedicine.m_BlnReadOnly = false;
            this.m_txtOtherMedicine.m_BlnUnderLineDST = false;
            this.m_txtOtherMedicine.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOtherMedicine.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOtherMedicine.m_IntCanModifyTime = 6;
            this.m_txtOtherMedicine.m_IntPartControlLength = 0;
            this.m_txtOtherMedicine.m_IntPartControlStartIndex = 0;
            this.m_txtOtherMedicine.m_StrUserID = "";
            this.m_txtOtherMedicine.m_StrUserName = "";
            this.m_txtOtherMedicine.MaxLength = 50;
            this.m_txtOtherMedicine.Multiline = false;
            this.m_txtOtherMedicine.Name = "m_txtOtherMedicine";
            this.m_txtOtherMedicine.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtOtherMedicine.Size = new System.Drawing.Size(287, 24);
            this.m_txtOtherMedicine.TabIndex = 315;
            this.m_txtOtherMedicine.Text = "";
            // 
            // m_txtOxytocinIMIv
            // 
            this.m_txtOxytocinIMIv.AccessibleDescription = "催产素";
            this.m_txtOxytocinIMIv.BackColor = System.Drawing.Color.White;
            this.m_txtOxytocinIMIv.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOxytocinIMIv.ForeColor = System.Drawing.Color.Black;
            this.m_txtOxytocinIMIv.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOxytocinIMIv.Location = new System.Drawing.Point(128, 236);
            this.m_txtOxytocinIMIv.m_BlnIgnoreUserInfo = false;
            this.m_txtOxytocinIMIv.m_BlnPartControl = false;
            this.m_txtOxytocinIMIv.m_BlnReadOnly = false;
            this.m_txtOxytocinIMIv.m_BlnUnderLineDST = false;
            this.m_txtOxytocinIMIv.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOxytocinIMIv.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOxytocinIMIv.m_IntCanModifyTime = 6;
            this.m_txtOxytocinIMIv.m_IntPartControlLength = 0;
            this.m_txtOxytocinIMIv.m_IntPartControlStartIndex = 0;
            this.m_txtOxytocinIMIv.m_StrUserID = "";
            this.m_txtOxytocinIMIv.m_StrUserName = "";
            this.m_txtOxytocinIMIv.MaxLength = 50;
            this.m_txtOxytocinIMIv.Multiline = false;
            this.m_txtOxytocinIMIv.Name = "m_txtOxytocinIMIv";
            this.m_txtOxytocinIMIv.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtOxytocinIMIv.Size = new System.Drawing.Size(316, 24);
            this.m_txtOxytocinIMIv.TabIndex = 300;
            this.m_txtOxytocinIMIv.Text = "";
            // 
            // m_txtSutureAbdominalWall
            // 
            this.m_txtSutureAbdominalWall.AccessibleDescription = "缝合腹壁";
            this.m_txtSutureAbdominalWall.BackColor = System.Drawing.Color.White;
            this.m_txtSutureAbdominalWall.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSutureAbdominalWall.ForeColor = System.Drawing.Color.Black;
            this.m_txtSutureAbdominalWall.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSutureAbdominalWall.Location = new System.Drawing.Point(92, 207);
            this.m_txtSutureAbdominalWall.m_BlnIgnoreUserInfo = false;
            this.m_txtSutureAbdominalWall.m_BlnPartControl = false;
            this.m_txtSutureAbdominalWall.m_BlnReadOnly = false;
            this.m_txtSutureAbdominalWall.m_BlnUnderLineDST = false;
            this.m_txtSutureAbdominalWall.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSutureAbdominalWall.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSutureAbdominalWall.m_IntCanModifyTime = 6;
            this.m_txtSutureAbdominalWall.m_IntPartControlLength = 0;
            this.m_txtSutureAbdominalWall.m_IntPartControlStartIndex = 0;
            this.m_txtSutureAbdominalWall.m_StrUserID = "";
            this.m_txtSutureAbdominalWall.m_StrUserName = "";
            this.m_txtSutureAbdominalWall.MaxLength = 2000;
            this.m_txtSutureAbdominalWall.Multiline = false;
            this.m_txtSutureAbdominalWall.Name = "m_txtSutureAbdominalWall";
            this.m_txtSutureAbdominalWall.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtSutureAbdominalWall.Size = new System.Drawing.Size(706, 24);
            this.m_txtSutureAbdominalWall.TabIndex = 295;
            this.m_txtSutureAbdominalWall.Text = "";
            // 
            // m_txtSutureUterus
            // 
            this.m_txtSutureUterus.AccessibleDescription = "缝合子宫";
            this.m_txtSutureUterus.BackColor = System.Drawing.Color.White;
            this.m_txtSutureUterus.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSutureUterus.ForeColor = System.Drawing.Color.Black;
            this.m_txtSutureUterus.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSutureUterus.Location = new System.Drawing.Point(92, 179);
            this.m_txtSutureUterus.m_BlnIgnoreUserInfo = false;
            this.m_txtSutureUterus.m_BlnPartControl = false;
            this.m_txtSutureUterus.m_BlnReadOnly = false;
            this.m_txtSutureUterus.m_BlnUnderLineDST = false;
            this.m_txtSutureUterus.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSutureUterus.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSutureUterus.m_IntCanModifyTime = 6;
            this.m_txtSutureUterus.m_IntPartControlLength = 0;
            this.m_txtSutureUterus.m_IntPartControlStartIndex = 0;
            this.m_txtSutureUterus.m_StrUserID = "";
            this.m_txtSutureUterus.m_StrUserName = "";
            this.m_txtSutureUterus.MaxLength = 2000;
            this.m_txtSutureUterus.Multiline = false;
            this.m_txtSutureUterus.Name = "m_txtSutureUterus";
            this.m_txtSutureUterus.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtSutureUterus.Size = new System.Drawing.Size(706, 24);
            this.m_txtSutureUterus.TabIndex = 290;
            this.m_txtSutureUterus.Text = "";
            // 
            // panel24
            // 
            this.panel24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel24.Controls.Add(this.m_chkOvaryCircs2L);
            this.panel24.Controls.Add(this.m_chkOvaryCircs1L);
            this.panel24.Location = new System.Drawing.Point(512, 152);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(115, 25);
            this.panel24.TabIndex = 10000114;
            // 
            // m_chkOvaryCircs2L
            // 
            this.m_chkOvaryCircs2L.AccessibleDescription = "左卵巢>>异常";
            this.m_chkOvaryCircs2L.AutoSize = true;
            this.m_chkOvaryCircs2L.Location = new System.Drawing.Point(59, 3);
            this.m_chkOvaryCircs2L.Name = "m_chkOvaryCircs2L";
            this.m_chkOvaryCircs2L.Size = new System.Drawing.Size(54, 18);
            this.m_chkOvaryCircs2L.TabIndex = 286;
            this.m_chkOvaryCircs2L.Text = "异常";
            this.m_chkOvaryCircs2L.UseVisualStyleBackColor = true;
            this.m_chkOvaryCircs2L.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // m_chkOvaryCircs1L
            // 
            this.m_chkOvaryCircs1L.AccessibleDescription = "左卵巢>>正常";
            this.m_chkOvaryCircs1L.AutoSize = true;
            this.m_chkOvaryCircs1L.Location = new System.Drawing.Point(5, 3);
            this.m_chkOvaryCircs1L.Name = "m_chkOvaryCircs1L";
            this.m_chkOvaryCircs1L.Size = new System.Drawing.Size(54, 18);
            this.m_chkOvaryCircs1L.TabIndex = 285;
            this.m_chkOvaryCircs1L.Text = "正常";
            this.m_chkOvaryCircs1L.UseVisualStyleBackColor = true;
            this.m_chkOvaryCircs1L.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // panel23
            // 
            this.panel23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel23.Controls.Add(this.m_chkOviductCircs2L);
            this.panel23.Controls.Add(this.m_chkOviductCircs1L);
            this.panel23.Location = new System.Drawing.Point(92, 151);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(115, 25);
            this.panel23.TabIndex = 10000114;
            // 
            // m_chkOviductCircs2L
            // 
            this.m_chkOviductCircs2L.AccessibleDescription = "左输卵管>>异常";
            this.m_chkOviductCircs2L.AutoSize = true;
            this.m_chkOviductCircs2L.Location = new System.Drawing.Point(59, 3);
            this.m_chkOviductCircs2L.Name = "m_chkOviductCircs2L";
            this.m_chkOviductCircs2L.Size = new System.Drawing.Size(54, 18);
            this.m_chkOviductCircs2L.TabIndex = 281;
            this.m_chkOviductCircs2L.Text = "异常";
            this.m_chkOviductCircs2L.UseVisualStyleBackColor = true;
            this.m_chkOviductCircs2L.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // m_chkOviductCircs1L
            // 
            this.m_chkOviductCircs1L.AccessibleDescription = "左输卵管>>正常";
            this.m_chkOviductCircs1L.AutoSize = true;
            this.m_chkOviductCircs1L.Location = new System.Drawing.Point(5, 3);
            this.m_chkOviductCircs1L.Name = "m_chkOviductCircs1L";
            this.m_chkOviductCircs1L.Size = new System.Drawing.Size(54, 18);
            this.m_chkOviductCircs1L.TabIndex = 280;
            this.m_chkOviductCircs1L.Text = "正常";
            this.m_chkOviductCircs1L.UseVisualStyleBackColor = true;
            this.m_chkOviductCircs1L.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(462, 159);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(63, 14);
            this.label72.TabIndex = 10000113;
            this.label72.Text = "左卵巢：";
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(51, 210);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(49, 14);
            this.label75.TabIndex = 10000113;
            this.label75.Text = "腹壁：";
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Location = new System.Drawing.Point(470, 240);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(42, 14);
            this.label79.TabIndex = 10000113;
            this.label79.Text = "其它:";
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(51, 179);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(49, 14);
            this.label74.TabIndex = 10000113;
            this.label74.Text = "子宫：";
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Location = new System.Drawing.Point(6, 239);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(133, 14);
            this.label76.TabIndex = 10000113;
            this.label76.Text = "术中用药：催产素：";
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(6, 179);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(49, 14);
            this.label73.TabIndex = 10000113;
            this.label73.Text = "缝合：";
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(23, 157);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(77, 14);
            this.label71.TabIndex = 10000113;
            this.label71.Text = "左输卵管：";
            // 
            // m_txtAmniocentesisBulk
            // 
            this.m_txtAmniocentesisBulk.AccessibleDescription = "羊水量";
            this.m_txtAmniocentesisBulk.BackColor = System.Drawing.Color.White;
            this.m_txtAmniocentesisBulk.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtAmniocentesisBulk.ForeColor = System.Drawing.Color.Black;
            this.m_txtAmniocentesisBulk.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtAmniocentesisBulk.Location = new System.Drawing.Point(718, 64);
            this.m_txtAmniocentesisBulk.m_BlnIgnoreUserInfo = false;
            this.m_txtAmniocentesisBulk.m_BlnPartControl = false;
            this.m_txtAmniocentesisBulk.m_BlnReadOnly = false;
            this.m_txtAmniocentesisBulk.m_BlnUnderLineDST = false;
            this.m_txtAmniocentesisBulk.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtAmniocentesisBulk.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtAmniocentesisBulk.m_IntCanModifyTime = 6;
            this.m_txtAmniocentesisBulk.m_IntPartControlLength = 0;
            this.m_txtAmniocentesisBulk.m_IntPartControlStartIndex = 0;
            this.m_txtAmniocentesisBulk.m_StrUserID = "";
            this.m_txtAmniocentesisBulk.m_StrUserName = "";
            this.m_txtAmniocentesisBulk.MaxLength = 50;
            this.m_txtAmniocentesisBulk.Multiline = false;
            this.m_txtAmniocentesisBulk.Name = "m_txtAmniocentesisBulk";
            this.m_txtAmniocentesisBulk.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtAmniocentesisBulk.Size = new System.Drawing.Size(58, 24);
            this.m_txtAmniocentesisBulk.TabIndex = 235;
            this.m_txtAmniocentesisBulk.Text = "";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(780, 71);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(21, 14);
            this.label59.TabIndex = 10000109;
            this.label59.Text = "ml";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(683, 70);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(35, 14);
            this.label60.TabIndex = 10000108;
            this.label60.Text = "量约";
            // 
            // panel18
            // 
            this.panel18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel18.Controls.Add(this.m_chkAmniocentesis24);
            this.panel18.Controls.Add(this.m_chkAmniocentesis23);
            this.panel18.Controls.Add(this.m_chkAmniocentesis22);
            this.panel18.Controls.Add(this.m_chkAmniocentesis21);
            this.panel18.Location = new System.Drawing.Point(512, 63);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(168, 25);
            this.panel18.TabIndex = 10000107;
            // 
            // m_chkAmniocentesis24
            // 
            this.m_chkAmniocentesis24.AccessibleDescription = "术前阴检>>坐骨切迹>>小于2指";
            this.m_chkAmniocentesis24.AutoSize = true;
            this.m_chkAmniocentesis24.Location = new System.Drawing.Point(123, 4);
            this.m_chkAmniocentesis24.Name = "m_chkAmniocentesis24";
            this.m_chkAmniocentesis24.Size = new System.Drawing.Size(40, 18);
            this.m_chkAmniocentesis24.TabIndex = 233;
            this.m_chkAmniocentesis24.Text = "Ⅲ";
            this.m_chkAmniocentesis24.UseVisualStyleBackColor = true;
            this.m_chkAmniocentesis24.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // m_chkAmniocentesis23
            // 
            this.m_chkAmniocentesis23.AccessibleDescription = "术前阴检>>坐骨切迹>>小于2指";
            this.m_chkAmniocentesis23.AutoSize = true;
            this.m_chkAmniocentesis23.Location = new System.Drawing.Point(83, 4);
            this.m_chkAmniocentesis23.Name = "m_chkAmniocentesis23";
            this.m_chkAmniocentesis23.Size = new System.Drawing.Size(40, 18);
            this.m_chkAmniocentesis23.TabIndex = 232;
            this.m_chkAmniocentesis23.Text = "Ⅱ";
            this.m_chkAmniocentesis23.UseVisualStyleBackColor = true;
            this.m_chkAmniocentesis23.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // m_chkAmniocentesis22
            // 
            this.m_chkAmniocentesis22.AccessibleDescription = "术前阴检>>坐骨切迹>>等于2指";
            this.m_chkAmniocentesis22.AutoSize = true;
            this.m_chkAmniocentesis22.Location = new System.Drawing.Point(43, 4);
            this.m_chkAmniocentesis22.Name = "m_chkAmniocentesis22";
            this.m_chkAmniocentesis22.Size = new System.Drawing.Size(40, 18);
            this.m_chkAmniocentesis22.TabIndex = 231;
            this.m_chkAmniocentesis22.Text = "Ⅰ";
            this.m_chkAmniocentesis22.UseVisualStyleBackColor = true;
            this.m_chkAmniocentesis22.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // m_chkAmniocentesis21
            // 
            this.m_chkAmniocentesis21.AccessibleDescription = "术前阴检>>羊水>>清";
            this.m_chkAmniocentesis21.AutoSize = true;
            this.m_chkAmniocentesis21.Location = new System.Drawing.Point(3, 4);
            this.m_chkAmniocentesis21.Name = "m_chkAmniocentesis21";
            this.m_chkAmniocentesis21.Size = new System.Drawing.Size(40, 18);
            this.m_chkAmniocentesis21.TabIndex = 230;
            this.m_chkAmniocentesis21.Text = "清";
            this.m_chkAmniocentesis21.UseVisualStyleBackColor = true;
            this.m_chkAmniocentesis21.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(476, 69);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(35, 14);
            this.label56.TabIndex = 10000106;
            this.label56.Text = "羊水";
            // 
            // m_txtUMBILICALCORD
            // 
            this.m_txtUMBILICALCORD.AccessibleDescription = "手术经过>>脐带";
            this.m_txtUMBILICALCORD.BackColor = System.Drawing.Color.White;
            this.m_txtUMBILICALCORD.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtUMBILICALCORD.ForeColor = System.Drawing.Color.Black;
            this.m_txtUMBILICALCORD.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtUMBILICALCORD.Location = new System.Drawing.Point(84, 121);
            this.m_txtUMBILICALCORD.m_BlnIgnoreUserInfo = false;
            this.m_txtUMBILICALCORD.m_BlnPartControl = false;
            this.m_txtUMBILICALCORD.m_BlnReadOnly = false;
            this.m_txtUMBILICALCORD.m_BlnUnderLineDST = false;
            this.m_txtUMBILICALCORD.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtUMBILICALCORD.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtUMBILICALCORD.m_IntCanModifyTime = 6;
            this.m_txtUMBILICALCORD.m_IntPartControlLength = 0;
            this.m_txtUMBILICALCORD.m_IntPartControlStartIndex = 0;
            this.m_txtUMBILICALCORD.m_StrUserID = "";
            this.m_txtUMBILICALCORD.m_StrUserName = "";
            this.m_txtUMBILICALCORD.MaxLength = 2000;
            this.m_txtUMBILICALCORD.Multiline = false;
            this.m_txtUMBILICALCORD.Name = "m_txtUMBILICALCORD";
            this.m_txtUMBILICALCORD.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtUMBILICALCORD.Size = new System.Drawing.Size(381, 24);
            this.m_txtUMBILICALCORD.TabIndex = 225;
            this.m_txtUMBILICALCORD.Text = "";
            // 
            // m_txtCaputSuccedaneumPlace2
            // 
            this.m_txtCaputSuccedaneumPlace2.AccessibleDescription = "手术经过>>产瘤位置";
            this.m_txtCaputSuccedaneumPlace2.BackColor = System.Drawing.Color.White;
            this.m_txtCaputSuccedaneumPlace2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCaputSuccedaneumPlace2.ForeColor = System.Drawing.Color.Black;
            this.m_txtCaputSuccedaneumPlace2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCaputSuccedaneumPlace2.Location = new System.Drawing.Point(364, 64);
            this.m_txtCaputSuccedaneumPlace2.m_BlnIgnoreUserInfo = false;
            this.m_txtCaputSuccedaneumPlace2.m_BlnPartControl = false;
            this.m_txtCaputSuccedaneumPlace2.m_BlnReadOnly = false;
            this.m_txtCaputSuccedaneumPlace2.m_BlnUnderLineDST = false;
            this.m_txtCaputSuccedaneumPlace2.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCaputSuccedaneumPlace2.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCaputSuccedaneumPlace2.m_IntCanModifyTime = 6;
            this.m_txtCaputSuccedaneumPlace2.m_IntPartControlLength = 0;
            this.m_txtCaputSuccedaneumPlace2.m_IntPartControlStartIndex = 0;
            this.m_txtCaputSuccedaneumPlace2.m_StrUserID = "";
            this.m_txtCaputSuccedaneumPlace2.m_StrUserName = "";
            this.m_txtCaputSuccedaneumPlace2.MaxLength = 50;
            this.m_txtCaputSuccedaneumPlace2.Multiline = false;
            this.m_txtCaputSuccedaneumPlace2.Name = "m_txtCaputSuccedaneumPlace2";
            this.m_txtCaputSuccedaneumPlace2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtCaputSuccedaneumPlace2.Size = new System.Drawing.Size(101, 24);
            this.m_txtCaputSuccedaneumPlace2.TabIndex = 225;
            this.m_txtCaputSuccedaneumPlace2.Text = "";
            // 
            // m_txtFetusFacies
            // 
            this.m_txtFetusFacies.AccessibleDescription = "胎儿外观";
            this.m_txtFetusFacies.BackColor = System.Drawing.Color.White;
            this.m_txtFetusFacies.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtFetusFacies.ForeColor = System.Drawing.Color.Black;
            this.m_txtFetusFacies.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtFetusFacies.Location = new System.Drawing.Point(107, 35);
            this.m_txtFetusFacies.m_BlnIgnoreUserInfo = false;
            this.m_txtFetusFacies.m_BlnPartControl = false;
            this.m_txtFetusFacies.m_BlnReadOnly = false;
            this.m_txtFetusFacies.m_BlnUnderLineDST = false;
            this.m_txtFetusFacies.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtFetusFacies.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtFetusFacies.m_IntCanModifyTime = 6;
            this.m_txtFetusFacies.m_IntPartControlLength = 0;
            this.m_txtFetusFacies.m_IntPartControlStartIndex = 0;
            this.m_txtFetusFacies.m_StrUserID = "";
            this.m_txtFetusFacies.m_StrUserName = "";
            this.m_txtFetusFacies.MaxLength = 2000;
            this.m_txtFetusFacies.Multiline = false;
            this.m_txtFetusFacies.Name = "m_txtFetusFacies";
            this.m_txtFetusFacies.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtFetusFacies.Size = new System.Drawing.Size(691, 24);
            this.m_txtFetusFacies.TabIndex = 210;
            this.m_txtFetusFacies.Text = "";
            // 
            // m_txtApgar
            // 
            this.m_txtApgar.AccessibleDescription = "阿氏评分";
            this.m_txtApgar.BackColor = System.Drawing.Color.White;
            this.m_txtApgar.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtApgar.ForeColor = System.Drawing.Color.Black;
            this.m_txtApgar.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtApgar.Location = new System.Drawing.Point(663, 6);
            this.m_txtApgar.m_BlnIgnoreUserInfo = false;
            this.m_txtApgar.m_BlnPartControl = false;
            this.m_txtApgar.m_BlnReadOnly = false;
            this.m_txtApgar.m_BlnUnderLineDST = false;
            this.m_txtApgar.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtApgar.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtApgar.m_IntCanModifyTime = 6;
            this.m_txtApgar.m_IntPartControlLength = 0;
            this.m_txtApgar.m_IntPartControlStartIndex = 0;
            this.m_txtApgar.m_StrUserID = "";
            this.m_txtApgar.m_StrUserName = "";
            this.m_txtApgar.MaxLength = 50;
            this.m_txtApgar.Multiline = false;
            this.m_txtApgar.Name = "m_txtApgar";
            this.m_txtApgar.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtApgar.Size = new System.Drawing.Size(135, 24);
            this.m_txtApgar.TabIndex = 205;
            this.m_txtApgar.Text = "";
            // 
            // m_txtCaputsuccedaneumSezeY
            // 
            this.m_txtCaputsuccedaneumSezeY.AccessibleDescription = "产瘤>>宽";
            this.m_txtCaputsuccedaneumSezeY.BackColor = System.Drawing.Color.White;
            this.m_txtCaputsuccedaneumSezeY.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCaputsuccedaneumSezeY.ForeColor = System.Drawing.Color.Black;
            this.m_txtCaputsuccedaneumSezeY.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCaputsuccedaneumSezeY.Location = new System.Drawing.Point(229, 63);
            this.m_txtCaputsuccedaneumSezeY.m_BlnIgnoreUserInfo = false;
            this.m_txtCaputsuccedaneumSezeY.m_BlnPartControl = false;
            this.m_txtCaputsuccedaneumSezeY.m_BlnReadOnly = false;
            this.m_txtCaputsuccedaneumSezeY.m_BlnUnderLineDST = false;
            this.m_txtCaputsuccedaneumSezeY.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCaputsuccedaneumSezeY.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCaputsuccedaneumSezeY.m_IntCanModifyTime = 6;
            this.m_txtCaputsuccedaneumSezeY.m_IntPartControlLength = 0;
            this.m_txtCaputsuccedaneumSezeY.m_IntPartControlStartIndex = 0;
            this.m_txtCaputsuccedaneumSezeY.m_StrUserID = "";
            this.m_txtCaputsuccedaneumSezeY.m_StrUserName = "";
            this.m_txtCaputsuccedaneumSezeY.MaxLength = 50;
            this.m_txtCaputsuccedaneumSezeY.Multiline = false;
            this.m_txtCaputsuccedaneumSezeY.Name = "m_txtCaputsuccedaneumSezeY";
            this.m_txtCaputsuccedaneumSezeY.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtCaputsuccedaneumSezeY.Size = new System.Drawing.Size(40, 24);
            this.m_txtCaputsuccedaneumSezeY.TabIndex = 220;
            this.m_txtCaputsuccedaneumSezeY.Text = "";
            // 
            // m_txtCaputsuccedaneumSezeX
            // 
            this.m_txtCaputsuccedaneumSezeX.AccessibleDescription = "产瘤>>长";
            this.m_txtCaputsuccedaneumSezeX.BackColor = System.Drawing.Color.White;
            this.m_txtCaputsuccedaneumSezeX.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCaputsuccedaneumSezeX.ForeColor = System.Drawing.Color.Black;
            this.m_txtCaputsuccedaneumSezeX.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCaputsuccedaneumSezeX.Location = new System.Drawing.Point(172, 64);
            this.m_txtCaputsuccedaneumSezeX.m_BlnIgnoreUserInfo = false;
            this.m_txtCaputsuccedaneumSezeX.m_BlnPartControl = false;
            this.m_txtCaputsuccedaneumSezeX.m_BlnReadOnly = false;
            this.m_txtCaputsuccedaneumSezeX.m_BlnUnderLineDST = false;
            this.m_txtCaputsuccedaneumSezeX.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCaputsuccedaneumSezeX.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCaputsuccedaneumSezeX.m_IntCanModifyTime = 6;
            this.m_txtCaputsuccedaneumSezeX.m_IntPartControlLength = 0;
            this.m_txtCaputsuccedaneumSezeX.m_IntPartControlStartIndex = 0;
            this.m_txtCaputsuccedaneumSezeX.m_StrUserID = "";
            this.m_txtCaputsuccedaneumSezeX.m_StrUserName = "";
            this.m_txtCaputsuccedaneumSezeX.MaxLength = 50;
            this.m_txtCaputsuccedaneumSezeX.Multiline = false;
            this.m_txtCaputsuccedaneumSezeX.Name = "m_txtCaputsuccedaneumSezeX";
            this.m_txtCaputsuccedaneumSezeX.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtCaputsuccedaneumSezeX.Size = new System.Drawing.Size(40, 24);
            this.m_txtCaputsuccedaneumSezeX.TabIndex = 215;
            this.m_txtCaputsuccedaneumSezeX.Text = "";
            // 
            // m_txtBabyWeight
            // 
            this.m_txtBabyWeight.AccessibleDescription = "术前产检>>估计胎重";
            this.m_txtBabyWeight.BackColor = System.Drawing.Color.White;
            this.m_txtBabyWeight.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBabyWeight.ForeColor = System.Drawing.Color.Black;
            this.m_txtBabyWeight.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBabyWeight.Location = new System.Drawing.Point(514, 6);
            this.m_txtBabyWeight.m_BlnIgnoreUserInfo = false;
            this.m_txtBabyWeight.m_BlnPartControl = false;
            this.m_txtBabyWeight.m_BlnReadOnly = false;
            this.m_txtBabyWeight.m_BlnUnderLineDST = false;
            this.m_txtBabyWeight.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBabyWeight.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBabyWeight.m_IntCanModifyTime = 6;
            this.m_txtBabyWeight.m_IntPartControlLength = 0;
            this.m_txtBabyWeight.m_IntPartControlStartIndex = 0;
            this.m_txtBabyWeight.m_StrUserID = "";
            this.m_txtBabyWeight.m_StrUserName = "";
            this.m_txtBabyWeight.MaxLength = 50;
            this.m_txtBabyWeight.Multiline = false;
            this.m_txtBabyWeight.Name = "m_txtBabyWeight";
            this.m_txtBabyWeight.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtBabyWeight.Size = new System.Drawing.Size(58, 24);
            this.m_txtBabyWeight.TabIndex = 200;
            this.m_txtBabyWeight.Text = "";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(576, 14);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(14, 14);
            this.label49.TabIndex = 10000103;
            this.label49.Text = "g";
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(36, 124);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(42, 14);
            this.label67.TabIndex = 10000102;
            this.label67.Text = "脐带:";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(36, 97);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(42, 14);
            this.label61.TabIndex = 10000102;
            this.label61.Text = "胎盘:";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(36, 68);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(42, 14);
            this.label53.TabIndex = 10000102;
            this.label53.Text = "产瘤:";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(36, 40);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(70, 14);
            this.label52.TabIndex = 10000102;
            this.label52.Text = "胎儿外观:";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(600, 10);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(63, 14);
            this.label51.TabIndex = 10000102;
            this.label51.Text = "阿氏评分";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(212, 69);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(21, 14);
            this.label54.TabIndex = 10000102;
            this.label54.Text = "×";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(473, 10);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(35, 14);
            this.label50.TabIndex = 10000102;
            this.label50.Text = "体重";
            // 
            // panel22
            // 
            this.panel22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel22.Controls.Add(this.m_chkEmbryolemmaCircs2);
            this.panel22.Controls.Add(this.m_chkEmbryolemmaCircs1);
            this.panel22.Location = new System.Drawing.Point(512, 120);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(124, 25);
            this.panel22.TabIndex = 10000101;
            // 
            // m_chkEmbryolemmaCircs2
            // 
            this.m_chkEmbryolemmaCircs2.AccessibleDescription = "胎膜>>不完整";
            this.m_chkEmbryolemmaCircs2.AutoSize = true;
            this.m_chkEmbryolemmaCircs2.Location = new System.Drawing.Point(58, 3);
            this.m_chkEmbryolemmaCircs2.Name = "m_chkEmbryolemmaCircs2";
            this.m_chkEmbryolemmaCircs2.Size = new System.Drawing.Size(68, 18);
            this.m_chkEmbryolemmaCircs2.TabIndex = 276;
            this.m_chkEmbryolemmaCircs2.Text = "不完整";
            this.m_chkEmbryolemmaCircs2.UseVisualStyleBackColor = true;
            this.m_chkEmbryolemmaCircs2.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // m_chkEmbryolemmaCircs1
            // 
            this.m_chkEmbryolemmaCircs1.AccessibleDescription = "胎膜>>完整";
            this.m_chkEmbryolemmaCircs1.AutoSize = true;
            this.m_chkEmbryolemmaCircs1.Location = new System.Drawing.Point(5, 3);
            this.m_chkEmbryolemmaCircs1.Name = "m_chkEmbryolemmaCircs1";
            this.m_chkEmbryolemmaCircs1.Size = new System.Drawing.Size(54, 18);
            this.m_chkEmbryolemmaCircs1.TabIndex = 275;
            this.m_chkEmbryolemmaCircs1.Text = "完整";
            this.m_chkEmbryolemmaCircs1.UseVisualStyleBackColor = true;
            this.m_chkEmbryolemmaCircs1.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // panel17
            // 
            this.panel17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel17.Controls.Add(this.m_chkBabySex2);
            this.panel17.Controls.Add(this.m_chkBabySex1);
            this.panel17.Location = new System.Drawing.Point(364, 6);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(88, 25);
            this.panel17.TabIndex = 10000101;
            // 
            // m_chkBabySex2
            // 
            this.m_chkBabySex2.AccessibleDescription = "婴儿性别>>女";
            this.m_chkBabySex2.AutoSize = true;
            this.m_chkBabySex2.Location = new System.Drawing.Point(44, 3);
            this.m_chkBabySex2.Name = "m_chkBabySex2";
            this.m_chkBabySex2.Size = new System.Drawing.Size(40, 18);
            this.m_chkBabySex2.TabIndex = 196;
            this.m_chkBabySex2.Text = "女";
            this.m_chkBabySex2.UseVisualStyleBackColor = true;
            this.m_chkBabySex2.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // m_chkBabySex1
            // 
            this.m_chkBabySex1.AccessibleDescription = "婴儿性别>>男";
            this.m_chkBabySex1.AutoSize = true;
            this.m_chkBabySex1.Location = new System.Drawing.Point(6, 3);
            this.m_chkBabySex1.Name = "m_chkBabySex1";
            this.m_chkBabySex1.Size = new System.Drawing.Size(40, 18);
            this.m_chkBabySex1.TabIndex = 195;
            this.m_chkBabySex1.Text = "男";
            this.m_chkBabySex1.UseVisualStyleBackColor = true;
            this.m_chkBabySex1.CheckedChanged += new System.EventHandler(this.m_chkSingle_CheckedChanged);
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(476, 126);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(49, 14);
            this.label69.TabIndex = 10000100;
            this.label69.Text = "胎膜：";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(268, 69);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(91, 14);
            this.label55.TabIndex = 10000100;
            this.label55.Text = "cm，产瘤位置";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(325, 12);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(35, 14);
            this.label48.TabIndex = 10000100;
            this.label48.Text = "性别";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(36, 12);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(70, 14);
            this.label47.TabIndex = 10000080;
            this.label47.Text = "娩出时间:";
            // 
            // label70
            // 
            this.label70.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label70.Location = new System.Drawing.Point(6, 148);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(791, 2);
            this.label70.TabIndex = 10000079;
            // 
            // label46
            // 
            this.label46.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label46.Location = new System.Drawing.Point(6, 3);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(790, 2);
            this.label46.TabIndex = 10000079;
            // 
            // label45
            // 
            this.label45.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label45.Location = new System.Drawing.Point(6, 4);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(26, 145);
            this.label45.TabIndex = 10000078;
            this.label45.Text = "手术经过";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_dtpExpulsionTime
            // 
            this.m_dtpExpulsionTime.AccessibleDescription = "娩出时间";
            this.m_dtpExpulsionTime.BorderColor = System.Drawing.Color.Black;
            this.m_dtpExpulsionTime.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpExpulsionTime.DropButtonBackColor = System.Drawing.Color.Gainsboro;
            this.m_dtpExpulsionTime.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpExpulsionTime.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpExpulsionTime.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpExpulsionTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpExpulsionTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpExpulsionTime.Location = new System.Drawing.Point(107, 8);
            this.m_dtpExpulsionTime.m_BlnOnlyTime = false;
            this.m_dtpExpulsionTime.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpExpulsionTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpExpulsionTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpExpulsionTime.Name = "m_dtpExpulsionTime";
            this.m_dtpExpulsionTime.ReadOnly = false;
            this.m_dtpExpulsionTime.Size = new System.Drawing.Size(211, 22);
            this.m_dtpExpulsionTime.TabIndex = 190;
            this.m_dtpExpulsionTime.TextBackColor = System.Drawing.Color.White;
            this.m_dtpExpulsionTime.TextForeColor = System.Drawing.Color.Black;
            // 
            // checkBox3
            // 
            this.checkBox3.AccessibleDescription = "术前阴检>>尾骨弧度>>低";
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(83, 4);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(36, 16);
            this.checkBox3.TabIndex = 0;
            this.checkBox3.Text = "低";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AccessibleDescription = "术前阴检>>尾骨弧度>>中";
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(41, 4);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(36, 16);
            this.checkBox4.TabIndex = 0;
            this.checkBox4.Text = "中";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AccessibleDescription = "术前阴检>>尾骨弧度>>高";
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(3, 4);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(36, 16);
            this.checkBox5.TabIndex = 0;
            this.checkBox5.Text = "高";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // frmEMR_CesareanRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 613);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEMR_CesareanRecord";
            this.Text = "剖宫产手术记录";
            this.Load += new System.EventHandler(this.frmEMR_CesareanRecord_Load);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.lblCreateDateTitle, 0);
            this.Controls.SetChildIndex(this.m_dtpCreateDate, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_lblGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_dtpGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.m_trvCreateDate, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.m_pnlNewBase.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel21.ResumeLayout(false);
            this.panel21.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel25.ResumeLayout(false);
            this.panel25.PerformLayout();
            this.panel20.ResumeLayout(false);
            this.panel20.PerformLayout();
            this.panel19.ResumeLayout(false);
            this.panel19.PerformLayout();
            this.panel24.ResumeLayout(false);
            this.panel24.PerformLayout();
            this.panel23.ResumeLayout(false);
            this.panel23.PerformLayout();
            this.panel18.ResumeLayout(false);
            this.panel18.PerformLayout();
            this.panel22.ResumeLayout(false);
            this.panel22.PerformLayout();
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSign;
        private PinkieControls.ButtonXP m_cmdRecorder;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label57;
        private com.digitalwave.Utility.Controls.ctlComboBox m_cboLayTimes;
        private com.digitalwave.Utility.Controls.ctlComboBox m_cboPregnantTimes;
        private System.Windows.Forms.TextBox m_txtAnaesthetist;
        private PinkieControls.ButtonXP m_cmdAnaesthetist;
        private com.digitalwave.controls.ctlRichTextBox m_txtOPName;
        private System.Windows.Forms.Label label7;
        private com.digitalwave.controls.ctlRichTextBox m_txtOPIndication;
        private System.Windows.Forms.Label label4;
        private com.digitalwave.controls.ctlRichTextBox m_txtAnaMode;
        private System.Windows.Forms.Label label6;
        private com.digitalwave.controls.ctlRichTextBox m_txtDiagnosisAfterOP;
        private System.Windows.Forms.Label label5;
        private com.digitalwave.controls.ctlRichTextBox m_txtDiagnosisBeforeOP;
        private System.Windows.Forms.Label label3;
        protected com.digitalwave.Utility.Controls.ctlTimePicker m_dtpOPDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label m_lblInPatientDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox m_chkLinkup3;
        private System.Windows.Forms.CheckBox m_chkLinkup2;
        private System.Windows.Forms.CheckBox m_chkLinkup1;
        private com.digitalwave.controls.ctlRichTextBox m_txtPresentation1;
        private com.digitalwave.controls.ctlRichTextBox m_txtFetusWeight;
        private com.digitalwave.controls.ctlRichTextBox m_txtAbdomenRound;
        private com.digitalwave.controls.ctlRichTextBox m_txtUterueHeight;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckBox m_chkAmniocentesis14;
        private System.Windows.Forms.CheckBox m_chkAmniocentesis13;
        private System.Windows.Forms.CheckBox m_chkAmniocentesis12;
        private System.Windows.Forms.CheckBox m_chkAmniocentesis11;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox m_chkIshiumNotch3;
        private System.Windows.Forms.CheckBox m_chkIshiumNotch2;
        private System.Windows.Forms.CheckBox m_chkIshiumNotch1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox m_chkIschialSpine3;
        private System.Windows.Forms.CheckBox m_chkIschialSpine2;
        private System.Windows.Forms.CheckBox m_chkIschialSpine1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.CheckBox m_chkSkull2;
        private System.Windows.Forms.CheckBox m_chkSkull1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.CheckBox m_chkCoccyxRadian3;
        private System.Windows.Forms.CheckBox m_chkCoccyxRadian2;
        private System.Windows.Forms.CheckBox m_chkCoccyxRadian1;
        private com.digitalwave.controls.ctlRichTextBox m_txtCaputSuccedaneumPlace1;
        private com.digitalwave.controls.ctlRichTextBox m_txtCaputSuccedaneumSize;
        private com.digitalwave.controls.ctlRichTextBox m_txtPresentationHeight;
        private com.digitalwave.controls.ctlRichTextBox m_txtFetusPlace1;
        private com.digitalwave.controls.ctlRichTextBox m_txtUterusora;
        private com.digitalwave.controls.ctlRichTextBox m_txtDC;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox m_chkUnCheckBeforeOP;
        private com.digitalwave.controls.ctlRichTextBox m_txtPubicArch;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label35;
        private com.digitalwave.controls.ctlRichTextBox m_txtAbdominalWall_H;
        private com.digitalwave.controls.ctlRichTextBox m_txtAbdominalWall_V;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.CheckBox m_chkFascia4;
        private System.Windows.Forms.CheckBox m_chkFascia3;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.CheckBox m_chkFascia2;
        private System.Windows.Forms.CheckBox m_chkFascia1;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.CheckBox m_chkPeritoneum2;
        private System.Windows.Forms.CheckBox m_chkPeritoneum1;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.CheckBox m_chkPeritoneum4;
        private System.Windows.Forms.CheckBox m_chkPeritoneum3;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.CheckBox m_chkPeritoneum6;
        private System.Windows.Forms.CheckBox m_chkPeritoneum5;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.CheckBox m_chkUterus2;
        private System.Windows.Forms.CheckBox m_chkUterus1;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.CheckBox m_chkUterus4;
        private System.Windows.Forms.CheckBox m_chkUterus3;
        private com.digitalwave.controls.ctlRichTextBox m_txtFetusPlace2;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.CheckBox m_chkPresentatonExpulsion3;
        private System.Windows.Forms.CheckBox m_chkPresentatonExpulsion2;
        private System.Windows.Forms.CheckBox m_chkPresentatonExpulsion1;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.CheckBox m_chkEngagement3;
        private System.Windows.Forms.CheckBox m_chkEngagement2;
        private System.Windows.Forms.CheckBox m_chkEngagement1;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label45;
        protected com.digitalwave.Utility.Controls.ctlTimePicker m_dtpExpulsionTime;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.CheckBox m_chkBabySex2;
        private System.Windows.Forms.CheckBox m_chkBabySex1;
        private System.Windows.Forms.Label label48;
        private com.digitalwave.controls.ctlRichTextBox m_txtFetusFacies;
        private com.digitalwave.controls.ctlRichTextBox m_txtApgar;
        private com.digitalwave.controls.ctlRichTextBox m_txtBabyWeight;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label50;
        private com.digitalwave.controls.ctlRichTextBox m_txtCaputsuccedaneumSezeY;
        private com.digitalwave.controls.ctlRichTextBox m_txtCaputsuccedaneumSezeX;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.CheckBox m_chkAmniocentesis24;
        private System.Windows.Forms.CheckBox m_chkAmniocentesis23;
        private System.Windows.Forms.CheckBox m_chkAmniocentesis22;
        private System.Windows.Forms.CheckBox m_chkAmniocentesis21;
        private System.Windows.Forms.Label label56;
        private com.digitalwave.controls.ctlRichTextBox m_txtCaputSuccedaneumPlace2;
        private System.Windows.Forms.Label label55;
        private com.digitalwave.controls.ctlRichTextBox m_txtAmniocentesisBulk;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.Panel panel23;
        private System.Windows.Forms.CheckBox m_chkOviductCircs2L;
        private System.Windows.Forms.CheckBox m_chkOviductCircs1L;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.Panel panel22;
        private System.Windows.Forms.CheckBox m_chkEmbryolemmaCircs2;
        private System.Windows.Forms.CheckBox m_chkEmbryolemmaCircs1;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Label label70;
        private com.digitalwave.controls.ctlRichTextBox m_txtOxytocinIMIv;
        private com.digitalwave.controls.ctlRichTextBox m_txtSutureAbdominalWall;
        private com.digitalwave.controls.ctlRichTextBox m_txtSutureUterus;
        private System.Windows.Forms.Panel panel24;
        private System.Windows.Forms.CheckBox m_chkOvaryCircs2L;
        private System.Windows.Forms.CheckBox m_chkOvaryCircs1L;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.Label label73;
        private com.digitalwave.controls.ctlRichTextBox m_txtOtherMedicine;
        private System.Windows.Forms.Label label79;
        private com.digitalwave.controls.ctlRichTextBox m_txtPiss;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.Label label81;
        private com.digitalwave.controls.ctlRichTextBox m_txtTransfuse;
        private com.digitalwave.controls.ctlRichTextBox m_txtBleeding;
        private System.Windows.Forms.Label label85;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.Label label88;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.TextBox m_txtOperator;
        private PinkieControls.ButtonXP m_cmdOperator;
        private PinkieControls.ButtonXP m_cmdAssistant2;
        private PinkieControls.ButtonXP m_cmdAssistant1;
        private com.digitalwave.controls.ctlRichTextBox m_txtPresentation2;
        private System.Windows.Forms.Label label95;
        private System.Windows.Forms.TextBox m_lsvAssistant1;
        private com.digitalwave.controls.ctlRichTextBox m_txtPLACENTA;
        private com.digitalwave.controls.ctlRichTextBox m_txtUMBILICALCORD;
        private System.Windows.Forms.TextBox m_lsvAssistant2;
        private com.digitalwave.controls.ctlRichTextBox m_txtSumary4;
        private com.digitalwave.Utility.Controls.ctlComboBox m_cboOPTime;
        private com.digitalwave.Utility.Controls.ctlComboBox m_cboANATime;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.CheckBox m_chkOviductCircs2R;
        private System.Windows.Forms.CheckBox m_chkOviductCircs1R;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Panel panel20;
        private System.Windows.Forms.CheckBox m_chkOvaryCircs2R;
        private System.Windows.Forms.CheckBox m_chkOvaryCircs1R;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.CheckBox chkHasSuccedaneum1;
        private System.Windows.Forms.CheckBox chkNoSuccedaneum1;
        private System.Windows.Forms.Panel panel21;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Panel panel25;
        private System.Windows.Forms.CheckBox chkNoSuccedaneum2;
        private System.Windows.Forms.CheckBox chkHasSuccedaneum2;
    }
}