namespace iCare
{
    partial class frmPartogramRecord_GX
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
                if (this.OwnedForms != null)
                {
                    foreach (System.Windows.Forms.Form frm in this.OwnedForms)
                    {
                        frm.FormClosed -= new System.Windows.Forms.FormClosedEventHandler(frmSub_FormClosed);
                        frm.Dispose();
                    }
                }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPartogramRecord_GX));
            this.m_navBar = new System.Windows.Forms.BindingNavigator(this.components);
            this.m_bidSource = new System.Windows.Forms.BindingSource(this.components);
            this.m_lblAllPage = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.m_cboInpatientDate = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.m_cmdAddHourRec = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.m_cmdFirst = new System.Windows.Forms.ToolStripButton();
            this.m_cmdPrevPage = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.m_txtCurrentPage = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_cmdNextPage = new System.Windows.Forms.ToolStripButton();
            this.m_cmdLastPage = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_cmdAddPage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.m_txtGiveBirthTime = new com.digitalwave.Controls.ctlMaskedDateTimePicker();
            this.m_txtBreakTime = new com.digitalwave.Controls.ctlMaskedDateTimePicker();
            this.m_txtExpectDate = new com.digitalwave.Controls.ctlMaskedDateTimePicker();
            this.m_txtMenses = new com.digitalwave.Controls.ctlMaskedDateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtBorn = new com.digitalwave.Controls.ctlMaskedNumber();
            this.m_txtGravid = new com.digitalwave.Controls.ctlMaskedNumber();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.m_lsvDeliver = new System.Windows.Forms.ListView();
            this.clmEmployeeName = new System.Windows.Forms.ColumnHeader();
            this.m_cmdDeliver = new ExternalControlsLib.XPButton();
            this.m_cmdAsst = new ExternalControlsLib.XPButton();
            this.m_cboGravidWay = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_txtAllPartogram = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtThreePartogram = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtSndPartogram = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtFirstPartogram = new com.digitalwave.controls.ctlRichTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.m_txtAidUser = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtWeight = new com.digitalwave.Controls.ctlMaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.m_txtHight = new com.digitalwave.Controls.ctlMaskedTextBox();
            this.m_cboSex = new com.digitalwave.Controls.ctlComboBox();
            this.m_ctlPartogram = new com.digitalwave.Utility.Controls.ctlPartogramRecord();
            this.m_pdmPrint = new System.Drawing.Printing.PrintDocument();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_cmdAddHourRec_new = new ExternalControlsLib.XPButton();
            this.m_pnlNewBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_navBar)).BeginInit();
            this.m_navBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_bidSource)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_ctlPartogram)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(260, 248);
            this.lblSex.Size = new System.Drawing.Size(144, 19);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(261, 275);
            this.lblAge.Size = new System.Drawing.Size(144, 19);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(218, 172);
            this.lblBedNoTitle.Size = new System.Drawing.Size(56, 14);
            this.lblBedNoTitle.Text = "床  号:";
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(217, 198);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(218, 224);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(217, 250);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(217, 275);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(217, 145);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(274, 194);
            this.txtInPatientID.Size = new System.Drawing.Size(130, 23);
            this.txtInPatientID.TabIndex = 130;
            this.txtInPatientID.TabStop = false;
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(260, 220);
            this.m_txtPatientName.Size = new System.Drawing.Size(144, 23);
            this.m_txtPatientName.TabIndex = 140;
            this.m_txtPatientName.TabStop = false;
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(274, 168);
            this.m_txtBedNO.Size = new System.Drawing.Size(106, 23);
            this.m_txtBedNO.TabIndex = 120;
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(260, 141);
            this.m_cboArea.TabIndex = 110;
            this.m_cboArea.TabStop = true;
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(452, 53);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(232, 106);
            this.m_lsvBedNO.Size = new System.Drawing.Size(131, 123);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(260, 115);
            this.m_cboDept.TabIndex = 100;
            this.m_cboDept.TabStop = true;
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(218, 119);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(704, 74);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.m_cmdNext.Location = new System.Drawing.Point(381, 169);
            this.m_cmdNext.TabIndex = 125;
            this.m_cmdNext.TabStop = true;
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(67, 15);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(238, 105);
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(257, 147);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(792, 2);
            this.m_cmdModifyPatientInfo.Size = new System.Drawing.Size(67, 28);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Controls.Add(this.m_cmdAddHourRec_new);
            this.m_pnlNewBase.Location = new System.Drawing.Point(10, 1);
            this.m_pnlNewBase.Size = new System.Drawing.Size(850, 60);
            this.m_pnlNewBase.Visible = true;
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_ctlPatientInfo, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_cmdAddHourRec_new, 0);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowHomePlace = true;
            this.m_ctlPatientInfo.m_BlnIsShowOccupy = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowRace = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(848, 29);
            // 
            // m_navBar
            // 
            this.m_navBar.AddNewItem = null;
            this.m_navBar.AllowMerge = false;
            this.m_navBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_navBar.AutoSize = false;
            this.m_navBar.BindingSource = this.m_bidSource;
            this.m_navBar.CountItem = this.m_lblAllPage;
            this.m_navBar.DeleteItem = null;
            this.m_navBar.Dock = System.Windows.Forms.DockStyle.None;
            this.m_navBar.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_navBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.m_navBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.m_cboInpatientDate,
            this.toolStripSeparator3,
            this.m_cmdAddHourRec,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.toolStripSeparator4,
            this.m_cmdFirst,
            this.m_cmdPrevPage,
            this.bindingNavigatorSeparator,
            this.m_txtCurrentPage,
            this.m_lblAllPage,
            this.bindingNavigatorSeparator1,
            this.m_cmdNextPage,
            this.m_cmdLastPage,
            this.bindingNavigatorSeparator2,
            this.m_cmdAddPage,
            this.toolStripSeparator2});
            this.m_navBar.Location = new System.Drawing.Point(201, 101);
            this.m_navBar.MoveFirstItem = null;
            this.m_navBar.MoveLastItem = null;
            this.m_navBar.MoveNextItem = null;
            this.m_navBar.MovePreviousItem = null;
            this.m_navBar.Name = "m_navBar";
            this.m_navBar.PositionItem = null;
            this.m_navBar.Size = new System.Drawing.Size(669, 25);
            this.m_navBar.TabIndex = 400;
            this.m_navBar.Visible = false;
            // 
            // m_lblAllPage
            // 
            this.m_lblAllPage.Name = "m_lblAllPage";
            this.m_lblAllPage.Size = new System.Drawing.Size(42, 22);
            this.m_lblAllPage.Text = "/ {0}";
            this.m_lblAllPage.ToolTipText = "总页数";
            this.m_lblAllPage.Visible = false;
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(70, 22);
            this.toolStripLabel2.Text = "入院时间:";
            // 
            // m_cboInpatientDate
            // 
            this.m_cboInpatientDate.AutoSize = false;
            this.m_cboInpatientDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboInpatientDate.Font = new System.Drawing.Font("宋体", 10F);
            this.m_cboInpatientDate.Name = "m_cboInpatientDate";
            this.m_cboInpatientDate.Size = new System.Drawing.Size(170, 21);
            this.m_cboInpatientDate.SelectedIndexChanged += new System.EventHandler(this.m_cboInpatientDate_SelectedIndexChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // m_cmdAddHourRec
            // 
            this.m_cmdAddHourRec.AutoSize = false;
            this.m_cmdAddHourRec.Image = ((System.Drawing.Image)(resources.GetObject("m_cmdAddHourRec.Image")));
            this.m_cmdAddHourRec.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdAddHourRec.ImageTransparentColor = System.Drawing.Color.White;
            this.m_cmdAddHourRec.Name = "m_cmdAddHourRec";
            this.m_cmdAddHourRec.Size = new System.Drawing.Size(80, 22);
            this.m_cmdAddHourRec.Text = "添加记录";
            this.m_cmdAddHourRec.Click += new System.EventHandler(this.m_cmdAddHourRec_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.AutoSize = false;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(35, 22);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator4.Visible = false;
            // 
            // m_cmdFirst
            // 
            this.m_cmdFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_cmdFirst.Image = ((System.Drawing.Image)(resources.GetObject("m_cmdFirst.Image")));
            this.m_cmdFirst.Name = "m_cmdFirst";
            this.m_cmdFirst.RightToLeftAutoMirrorImage = true;
            this.m_cmdFirst.Size = new System.Drawing.Size(23, 22);
            this.m_cmdFirst.Text = "移到第一页";
            this.m_cmdFirst.ToolTipText = "移到第一页";
            this.m_cmdFirst.Visible = false;
            this.m_cmdFirst.Click += new System.EventHandler(this.m_cmdFirst_Click);
            // 
            // m_cmdPrevPage
            // 
            this.m_cmdPrevPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_cmdPrevPage.Image = ((System.Drawing.Image)(resources.GetObject("m_cmdPrevPage.Image")));
            this.m_cmdPrevPage.Name = "m_cmdPrevPage";
            this.m_cmdPrevPage.RightToLeftAutoMirrorImage = true;
            this.m_cmdPrevPage.Size = new System.Drawing.Size(23, 22);
            this.m_cmdPrevPage.Text = "移到上一页";
            this.m_cmdPrevPage.ToolTipText = "移到上一页";
            this.m_cmdPrevPage.Visible = false;
            this.m_cmdPrevPage.Click += new System.EventHandler(this.m_cmdPrevPage_Click);
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            this.bindingNavigatorSeparator.Visible = false;
            // 
            // m_txtCurrentPage
            // 
            this.m_txtCurrentPage.AccessibleName = "位置";
            this.m_txtCurrentPage.AutoSize = false;
            this.m_txtCurrentPage.Name = "m_txtCurrentPage";
            this.m_txtCurrentPage.Size = new System.Drawing.Size(50, 21);
            this.m_txtCurrentPage.Text = "0";
            this.m_txtCurrentPage.ToolTipText = "当前页";
            this.m_txtCurrentPage.Visible = false;
            this.m_txtCurrentPage.TextChanged += new System.EventHandler(this.m_txtCurrentPage_TextChanged);
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            this.bindingNavigatorSeparator1.Visible = false;
            // 
            // m_cmdNextPage
            // 
            this.m_cmdNextPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_cmdNextPage.Image = ((System.Drawing.Image)(resources.GetObject("m_cmdNextPage.Image")));
            this.m_cmdNextPage.Name = "m_cmdNextPage";
            this.m_cmdNextPage.RightToLeftAutoMirrorImage = true;
            this.m_cmdNextPage.Size = new System.Drawing.Size(23, 22);
            this.m_cmdNextPage.Text = "移到下一页";
            this.m_cmdNextPage.ToolTipText = "移到下一页";
            this.m_cmdNextPage.Visible = false;
            this.m_cmdNextPage.Click += new System.EventHandler(this.m_cmdPrevPage_Click);
            // 
            // m_cmdLastPage
            // 
            this.m_cmdLastPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_cmdLastPage.Image = ((System.Drawing.Image)(resources.GetObject("m_cmdLastPage.Image")));
            this.m_cmdLastPage.Name = "m_cmdLastPage";
            this.m_cmdLastPage.RightToLeftAutoMirrorImage = true;
            this.m_cmdLastPage.Size = new System.Drawing.Size(23, 22);
            this.m_cmdLastPage.Text = "移到最后一页";
            this.m_cmdLastPage.ToolTipText = "移到最后一页";
            this.m_cmdLastPage.Visible = false;
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            this.bindingNavigatorSeparator2.Visible = false;
            // 
            // m_cmdAddPage
            // 
            this.m_cmdAddPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_cmdAddPage.Image = ((System.Drawing.Image)(resources.GetObject("m_cmdAddPage.Image")));
            this.m_cmdAddPage.Name = "m_cmdAddPage";
            this.m_cmdAddPage.RightToLeftAutoMirrorImage = true;
            this.m_cmdAddPage.Size = new System.Drawing.Size(23, 22);
            this.m_cmdAddPage.Text = "增加下一页24小时的记录";
            this.m_cmdAddPage.ToolTipText = "增加下一页24小时的记录";
            this.m_cmdAddPage.Visible = false;
            this.m_cmdAddPage.Click += new System.EventHandler(this.m_cmdAddPage_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.m_txtGiveBirthTime);
            this.panel1.Controls.Add(this.m_txtBreakTime);
            this.panel1.Controls.Add(this.m_txtExpectDate);
            this.panel1.Controls.Add(this.m_txtMenses);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.m_txtBorn);
            this.panel1.Controls.Add(this.m_txtGravid);
            this.panel1.Location = new System.Drawing.Point(1, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(194, 167);
            this.panel1.TabIndex = 200;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Location = new System.Drawing.Point(10, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(170, 3);
            this.label9.TabIndex = 10000011;
            // 
            // m_txtGiveBirthTime
            // 
            this.m_txtGiveBirthTime.AccessibleDescription = "临产开始时间";
            this.m_txtGiveBirthTime.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_txtGiveBirthTime.Location = new System.Drawing.Point(2, 135);
            this.m_txtGiveBirthTime.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日HH时mm分;
            this.m_txtGiveBirthTime.Mask = "0000年90月90日 90时90分";
            this.m_txtGiveBirthTime.Name = "m_txtGiveBirthTime";
            this.m_txtGiveBirthTime.PromptChar = ' ';
            this.m_txtGiveBirthTime.Size = new System.Drawing.Size(186, 23);
            this.m_txtGiveBirthTime.TabIndex = 10001500;
            this.m_txtGiveBirthTime.ValidatingType = typeof(System.DateTime);
            // 
            // m_txtBreakTime
            // 
            this.m_txtBreakTime.AccessibleDescription = "破水时间";
            this.m_txtBreakTime.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_txtBreakTime.Location = new System.Drawing.Point(32, 83);
            this.m_txtBreakTime.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日HH时;
            this.m_txtBreakTime.Mask = "0000年90月90日 90时";
            this.m_txtBreakTime.Name = "m_txtBreakTime";
            this.m_txtBreakTime.PromptChar = ' ';
            this.m_txtBreakTime.Size = new System.Drawing.Size(157, 23);
            this.m_txtBreakTime.TabIndex = 10001400;
            this.m_txtBreakTime.ValidatingType = typeof(System.DateTime);
            // 
            // m_txtExpectDate
            // 
            this.m_txtExpectDate.AccessibleDescription = "预产期";
            this.m_txtExpectDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_txtExpectDate.Location = new System.Drawing.Point(68, 56);
            this.m_txtExpectDate.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日;
            this.m_txtExpectDate.Mask = "0000年90月90日";
            this.m_txtExpectDate.Name = "m_txtExpectDate";
            this.m_txtExpectDate.PromptChar = ' ';
            this.m_txtExpectDate.Size = new System.Drawing.Size(121, 23);
            this.m_txtExpectDate.TabIndex = 10001300;
            this.m_txtExpectDate.ValidatingType = typeof(System.DateTime);
            // 
            // m_txtMenses
            // 
            this.m_txtMenses.AccessibleDescription = "末次月经";
            this.m_txtMenses.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_txtMenses.Location = new System.Drawing.Point(68, 29);
            this.m_txtMenses.m_EnmDateTimeFormat = com.digitalwave.Controls.EnmDateTimeFormat.yyyy年MM月dd日;
            this.m_txtMenses.Mask = "0000年90月90日";
            this.m_txtMenses.Name = "m_txtMenses";
            this.m_txtMenses.PromptChar = ' ';
            this.m_txtMenses.Size = new System.Drawing.Size(121, 23);
            this.m_txtMenses.TabIndex = 10001200;
            this.m_txtMenses.ValidatingType = typeof(System.DateTime);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 14);
            this.label2.TabIndex = 10000011;
            this.label2.Text = "/";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("宋体", 9F);
            this.label7.Location = new System.Drawing.Point(0, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 29);
            this.label7.TabIndex = 10000011;
            this.label7.Text = "破水时间";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 14);
            this.label6.TabIndex = 10000011;
            this.label6.Text = "预 产 期:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(0, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 14);
            this.label8.TabIndex = 10000011;
            this.label8.Text = "临产开始时间:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 10000011;
            this.label4.Text = "末次月经:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 10000011;
            this.label1.Text = "妊 / 产 :";
            // 
            // m_txtBorn
            // 
            this.m_txtBorn.AccessibleDescription = "产";
            this.m_txtBorn.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_txtBorn.Location = new System.Drawing.Point(128, 3);
            this.m_txtBorn.m_DcmInvalidNumber = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.m_txtBorn.m_DcmMaxNumber = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.m_txtBorn.m_DcmMinNumber = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.m_txtBorn.Mask = "99";
            this.m_txtBorn.Name = "m_txtBorn";
            this.m_txtBorn.PromptChar = ' ';
            this.m_txtBorn.Size = new System.Drawing.Size(39, 23);
            this.m_txtBorn.TabIndex = 10001100;
            this.m_txtBorn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtBorn.ValidatingType = typeof(decimal);
            // 
            // m_txtGravid
            // 
            this.m_txtGravid.AccessibleDescription = "妊";
            this.m_txtGravid.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_txtGravid.Location = new System.Drawing.Point(73, 3);
            this.m_txtGravid.m_DcmInvalidNumber = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.m_txtGravid.m_DcmMaxNumber = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.m_txtGravid.m_DcmMinNumber = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.m_txtGravid.Mask = "99";
            this.m_txtGravid.Name = "m_txtGravid";
            this.m_txtGravid.PromptChar = ' ';
            this.m_txtGravid.Size = new System.Drawing.Size(39, 23);
            this.m_txtGravid.TabIndex = 10001000;
            this.m_txtGravid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtGravid.ValidatingType = typeof(decimal);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 14);
            this.label10.TabIndex = 10000011;
            this.label10.Text = "性别:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 51);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 14);
            this.label11.TabIndex = 10000011;
            this.label11.Text = "体重:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 79);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 14);
            this.label12.TabIndex = 10000011;
            this.label12.Text = "身长:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(113, 78);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 14);
            this.label13.TabIndex = 10000011;
            this.label13.Text = "cm";
            // 
            // m_lsvDeliver
            // 
            this.m_lsvDeliver.BackColor = System.Drawing.Color.White;
            this.m_lsvDeliver.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmEmployeeName});
            this.m_lsvDeliver.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvDeliver.ForeColor = System.Drawing.Color.Black;
            this.m_lsvDeliver.FullRowSelect = true;
            this.m_lsvDeliver.GridLines = true;
            this.m_lsvDeliver.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_lsvDeliver.Location = new System.Drawing.Point(45, 102);
            this.m_lsvDeliver.Name = "m_lsvDeliver";
            this.m_lsvDeliver.Size = new System.Drawing.Size(141, 64);
            this.m_lsvDeliver.TabIndex = 2000;
            this.m_lsvDeliver.UseCompatibleStateImageBehavior = false;
            this.m_lsvDeliver.View = System.Windows.Forms.View.Details;
            // 
            // clmEmployeeName
            // 
            this.clmEmployeeName.Width = 120;
            // 
            // m_cmdDeliver
            // 
            this.m_cmdDeliver.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmdDeliver.BtnShape = ExternalControlsLib.emunType.BtnShape.Rectangle;
            this.m_cmdDeliver.BtnStyle = ExternalControlsLib.emunType.XPStyle.Silver;
            this.m_cmdDeliver.Location = new System.Drawing.Point(5, 102);
            this.m_cmdDeliver.Name = "m_cmdDeliver";
            this.m_cmdDeliver.Size = new System.Drawing.Size(41, 64);
            this.m_cmdDeliver.TabIndex = 1900;
            this.m_cmdDeliver.Text = "接生者:";
            this.m_cmdDeliver.UseVisualStyleBackColor = true;
            // 
            // m_cmdAsst
            // 
            this.m_cmdAsst.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmdAsst.BtnShape = ExternalControlsLib.emunType.BtnShape.Rectangle;
            this.m_cmdAsst.BtnStyle = ExternalControlsLib.emunType.XPStyle.Silver;
            this.m_cmdAsst.Location = new System.Drawing.Point(5, 172);
            this.m_cmdAsst.Name = "m_cmdAsst";
            this.m_cmdAsst.Size = new System.Drawing.Size(41, 65);
            this.m_cmdAsst.TabIndex = 2100;
            this.m_cmdAsst.Text = "助手:";
            this.m_cmdAsst.UseVisualStyleBackColor = true;
            // 
            // m_cboGravidWay
            // 
            this.m_cboGravidWay.AccessibleDescription = "分娩方式";
            this.m_cboGravidWay.BorderColor = System.Drawing.Color.Black;
            this.m_cboGravidWay.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboGravidWay.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboGravidWay.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboGravidWay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboGravidWay.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboGravidWay.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboGravidWay.ListBackColor = System.Drawing.Color.White;
            this.m_cboGravidWay.ListForeColor = System.Drawing.Color.Black;
            this.m_cboGravidWay.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboGravidWay.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboGravidWay.Location = new System.Drawing.Point(7, 36);
            this.m_cboGravidWay.m_BlnEnableItemEventMenu = true;
            this.m_cboGravidWay.Name = "m_cboGravidWay";
            this.m_cboGravidWay.SelectedIndex = -1;
            this.m_cboGravidWay.SelectedItem = null;
            this.m_cboGravidWay.SelectionStart = 0;
            this.m_cboGravidWay.Size = new System.Drawing.Size(179, 23);
            this.m_cboGravidWay.TabIndex = 10000012;
            this.m_cboGravidWay.TextBackColor = System.Drawing.Color.White;
            this.m_cboGravidWay.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_txtAllPartogram
            // 
            this.m_txtAllPartogram.AccessibleDescription = "总产程";
            this.m_txtAllPartogram.BackColor = System.Drawing.Color.White;
            this.m_txtAllPartogram.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtAllPartogram.ForeColor = System.Drawing.Color.Black;
            this.m_txtAllPartogram.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtAllPartogram.Location = new System.Drawing.Point(6, 222);
            this.m_txtAllPartogram.m_BlnIgnoreUserInfo = false;
            this.m_txtAllPartogram.m_BlnPartControl = false;
            this.m_txtAllPartogram.m_BlnReadOnly = false;
            this.m_txtAllPartogram.m_BlnUnderLineDST = false;
            this.m_txtAllPartogram.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtAllPartogram.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtAllPartogram.m_IntCanModifyTime = 6;
            this.m_txtAllPartogram.m_IntPartControlLength = 0;
            this.m_txtAllPartogram.m_IntPartControlStartIndex = 0;
            this.m_txtAllPartogram.m_StrUserID = "";
            this.m_txtAllPartogram.m_StrUserName = "";
            this.m_txtAllPartogram.Name = "m_txtAllPartogram";
            this.m_txtAllPartogram.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtAllPartogram.Size = new System.Drawing.Size(180, 24);
            this.m_txtAllPartogram.TabIndex = 1500;
            this.m_txtAllPartogram.Text = "";
            // 
            // m_txtThreePartogram
            // 
            this.m_txtThreePartogram.AccessibleDescription = "第三产程";
            this.m_txtThreePartogram.BackColor = System.Drawing.Color.White;
            this.m_txtThreePartogram.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtThreePartogram.ForeColor = System.Drawing.Color.Black;
            this.m_txtThreePartogram.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtThreePartogram.Location = new System.Drawing.Point(6, 176);
            this.m_txtThreePartogram.m_BlnIgnoreUserInfo = false;
            this.m_txtThreePartogram.m_BlnPartControl = false;
            this.m_txtThreePartogram.m_BlnReadOnly = false;
            this.m_txtThreePartogram.m_BlnUnderLineDST = false;
            this.m_txtThreePartogram.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtThreePartogram.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtThreePartogram.m_IntCanModifyTime = 6;
            this.m_txtThreePartogram.m_IntPartControlLength = 0;
            this.m_txtThreePartogram.m_IntPartControlStartIndex = 0;
            this.m_txtThreePartogram.m_StrUserID = "";
            this.m_txtThreePartogram.m_StrUserName = "";
            this.m_txtThreePartogram.Name = "m_txtThreePartogram";
            this.m_txtThreePartogram.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtThreePartogram.Size = new System.Drawing.Size(180, 24);
            this.m_txtThreePartogram.TabIndex = 1400;
            this.m_txtThreePartogram.Text = "";
            // 
            // m_txtSndPartogram
            // 
            this.m_txtSndPartogram.AccessibleDescription = "第二产程";
            this.m_txtSndPartogram.BackColor = System.Drawing.Color.White;
            this.m_txtSndPartogram.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSndPartogram.ForeColor = System.Drawing.Color.Black;
            this.m_txtSndPartogram.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSndPartogram.Location = new System.Drawing.Point(6, 131);
            this.m_txtSndPartogram.m_BlnIgnoreUserInfo = false;
            this.m_txtSndPartogram.m_BlnPartControl = false;
            this.m_txtSndPartogram.m_BlnReadOnly = false;
            this.m_txtSndPartogram.m_BlnUnderLineDST = false;
            this.m_txtSndPartogram.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSndPartogram.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSndPartogram.m_IntCanModifyTime = 6;
            this.m_txtSndPartogram.m_IntPartControlLength = 0;
            this.m_txtSndPartogram.m_IntPartControlStartIndex = 0;
            this.m_txtSndPartogram.m_StrUserID = "";
            this.m_txtSndPartogram.m_StrUserName = "";
            this.m_txtSndPartogram.Name = "m_txtSndPartogram";
            this.m_txtSndPartogram.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtSndPartogram.Size = new System.Drawing.Size(180, 24);
            this.m_txtSndPartogram.TabIndex = 1300;
            this.m_txtSndPartogram.Text = "";
            // 
            // m_txtFirstPartogram
            // 
            this.m_txtFirstPartogram.AccessibleDescription = "第一产程";
            this.m_txtFirstPartogram.BackColor = System.Drawing.Color.White;
            this.m_txtFirstPartogram.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtFirstPartogram.ForeColor = System.Drawing.Color.Black;
            this.m_txtFirstPartogram.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtFirstPartogram.Location = new System.Drawing.Point(6, 84);
            this.m_txtFirstPartogram.m_BlnIgnoreUserInfo = false;
            this.m_txtFirstPartogram.m_BlnPartControl = false;
            this.m_txtFirstPartogram.m_BlnReadOnly = false;
            this.m_txtFirstPartogram.m_BlnUnderLineDST = false;
            this.m_txtFirstPartogram.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtFirstPartogram.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtFirstPartogram.m_IntCanModifyTime = 6;
            this.m_txtFirstPartogram.m_IntPartControlLength = 0;
            this.m_txtFirstPartogram.m_IntPartControlStartIndex = 0;
            this.m_txtFirstPartogram.m_StrUserID = "";
            this.m_txtFirstPartogram.m_StrUserName = "";
            this.m_txtFirstPartogram.Name = "m_txtFirstPartogram";
            this.m_txtFirstPartogram.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtFirstPartogram.Size = new System.Drawing.Size(180, 24);
            this.m_txtFirstPartogram.TabIndex = 1200;
            this.m_txtFirstPartogram.Text = "";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 205);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(56, 14);
            this.label19.TabIndex = 10000011;
            this.label19.Text = "总产程:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 159);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(70, 14);
            this.label18.TabIndex = 10000011;
            this.label18.Text = "第三产程:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 110);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(70, 14);
            this.label17.TabIndex = 10000011;
            this.label17.Text = "第二产程:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 64);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(70, 14);
            this.label16.TabIndex = 10000011;
            this.label16.Text = "第一产程:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 19);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 14);
            this.label15.TabIndex = 10000011;
            this.label15.Text = "分娩方式:";
            // 
            // m_txtAidUser
            // 
            this.m_txtAidUser.AccessibleDescription = "助手";
            this.m_txtAidUser.BackColor = System.Drawing.Color.White;
            this.m_txtAidUser.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtAidUser.ForeColor = System.Drawing.Color.Black;
            this.m_txtAidUser.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtAidUser.Location = new System.Drawing.Point(46, 172);
            this.m_txtAidUser.m_BlnIgnoreUserInfo = false;
            this.m_txtAidUser.m_BlnPartControl = false;
            this.m_txtAidUser.m_BlnReadOnly = false;
            this.m_txtAidUser.m_BlnUnderLineDST = false;
            this.m_txtAidUser.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtAidUser.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtAidUser.m_IntCanModifyTime = 6;
            this.m_txtAidUser.m_IntPartControlLength = 0;
            this.m_txtAidUser.m_IntPartControlStartIndex = 0;
            this.m_txtAidUser.m_StrUserID = "";
            this.m_txtAidUser.m_StrUserName = "";
            this.m_txtAidUser.Name = "m_txtAidUser";
            this.m_txtAidUser.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtAidUser.Size = new System.Drawing.Size(142, 65);
            this.m_txtAidUser.TabIndex = 10000012;
            this.m_txtAidUser.Text = "";
            // 
            // m_txtWeight
            // 
            this.m_txtWeight.AccessibleDescription = "胎儿>>体重";
            this.m_txtWeight.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_txtWeight.Location = new System.Drawing.Point(51, 47);
            this.m_txtWeight.Mask = "99999";
            this.m_txtWeight.Name = "m_txtWeight";
            this.m_txtWeight.PromptChar = ' ';
            this.m_txtWeight.Size = new System.Drawing.Size(59, 23);
            this.m_txtWeight.TabIndex = 1700;
            this.m_txtWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtWeight.ValidatingType = typeof(int);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(113, 51);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(14, 14);
            this.label14.TabIndex = 10000011;
            this.label14.Text = "g";
            // 
            // m_txtHight
            // 
            this.m_txtHight.AccessibleDescription = "胎儿>>身长";
            this.m_txtHight.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.m_txtHight.Location = new System.Drawing.Point(51, 75);
            this.m_txtHight.Mask = "99";
            this.m_txtHight.Name = "m_txtHight";
            this.m_txtHight.PromptChar = ' ';
            this.m_txtHight.Size = new System.Drawing.Size(59, 23);
            this.m_txtHight.TabIndex = 1800;
            this.m_txtHight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtHight.ValidatingType = typeof(int);
            // 
            // m_cboSex
            // 
            this.m_cboSex.AccessibleDescription = "胎儿>>性别";
            this.m_cboSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboSex.FormattingEnabled = true;
            this.m_cboSex.Items.AddRange(new object[] {
            "男",
            "女",
            "未知"});
            this.m_cboSex.Location = new System.Drawing.Point(51, 21);
            this.m_cboSex.m_BlnEnableItemEventMenu = false;
            this.m_cboSex.Name = "m_cboSex";
            this.m_cboSex.Size = new System.Drawing.Size(58, 22);
            this.m_cboSex.TabIndex = 1600;
            // 
            // m_ctlPartogram
            // 
            this.m_ctlPartogram.BackColor = System.Drawing.Color.White;
            this.m_ctlPartogram.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_ctlPartogram.Location = new System.Drawing.Point(197, 64);
            this.m_ctlPartogram.m_ClrBorder = System.Drawing.Color.Black;
            this.m_ctlPartogram.m_ClrDrawText = System.Drawing.Color.Black;
            this.m_ctlPartogram.m_ClrFetalHead = System.Drawing.Color.Black;
            this.m_ctlPartogram.m_ClrFetalHeadLine = System.Drawing.Color.Black;
            this.m_ctlPartogram.m_ClrGridLine = System.Drawing.Color.Black;
            this.m_ctlPartogram.m_ClrMarkLine = System.Drawing.Color.Black;
            this.m_ctlPartogram.m_ClrUterineNect = System.Drawing.Color.Red;
            this.m_ctlPartogram.m_ClrUterineNectLine = System.Drawing.Color.Black;
            this.m_ctlPartogram.m_IntSelectPageNumber = 0;
            this.m_ctlPartogram.Name = "m_ctlPartogram";
            this.m_ctlPartogram.Size = new System.Drawing.Size(663, 667);
            this.m_ctlPartogram.TabIndex = 0;
            this.m_ctlPartogram.TabStop = false;
            this.m_ctlPartogram.m_evnPartogramEveryHourMouseDown += new System.EventHandler(this.m_ctlPartogram_m_evnPartogramEveryHourMouseDown);
            // 
            // m_pdmPrint
            // 
            this.m_pdmPrint.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.m_pdmPrint_PrintPage);
            this.m_pdmPrint.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdmPrint_EndPrint);
            this.m_pdmPrint.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdmPrint_BeginPrint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_cboGravidWay);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.m_txtAllPartogram);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.m_txtThreePartogram);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.m_txtSndPartogram);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.m_txtFirstPartogram);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Location = new System.Drawing.Point(1, 234);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 250);
            this.groupBox1.TabIndex = 10000006;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "产程";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_txtAidUser);
            this.groupBox2.Controls.Add(this.m_txtWeight);
            this.groupBox2.Controls.Add(this.m_cboSex);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.m_txtHight);
            this.groupBox2.Controls.Add(this.m_lsvDeliver);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.m_cmdDeliver);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.m_cmdAsst);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Location = new System.Drawing.Point(1, 485);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(194, 245);
            this.groupBox2.TabIndex = 10000007;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "胎儿";
            // 
            // m_cmdAddHourRec_new
            // 
            this.m_cmdAddHourRec_new.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmdAddHourRec_new.BtnShape = ExternalControlsLib.emunType.BtnShape.Rectangle;
            this.m_cmdAddHourRec_new.BtnStyle = ExternalControlsLib.emunType.XPStyle.Silver;
            this.m_cmdAddHourRec_new.Location = new System.Drawing.Point(748, 29);
            this.m_cmdAddHourRec_new.Name = "m_cmdAddHourRec_new";
            this.m_cmdAddHourRec_new.Size = new System.Drawing.Size(71, 29);
            this.m_cmdAddHourRec_new.TabIndex = 10000007;
            this.m_cmdAddHourRec_new.Text = "添加记录";
            this.m_cmdAddHourRec_new.UseVisualStyleBackColor = true;
            this.m_cmdAddHourRec_new.Click += new System.EventHandler(this.m_cmdAddHourRec_Click);
            // 
            // frmPartogramRecord_GX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 746);
            this.Controls.Add(this.m_navBar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_ctlPartogram);
            this.Controls.Add(this.panel1);
            this.Name = "frmPartogramRecord_GX";
            this.Text = "孕妇产程记录";
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.m_ctlPartogram, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.m_navBar, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_navBar)).EndInit();
            this.m_navBar.ResumeLayout(false);
            this.m_navBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_bidSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_ctlPartogram)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private com.digitalwave.Utility.Controls.ctlPartogramRecord m_ctlPartogram;
        private System.Windows.Forms.BindingNavigator m_navBar;
        private System.Windows.Forms.ToolStripButton m_cmdAddPage;
        private System.Windows.Forms.ToolStripLabel m_lblAllPage;
        private System.Windows.Forms.ToolStripButton m_cmdFirst;
        private System.Windows.Forms.ToolStripButton m_cmdPrevPage;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox m_txtCurrentPage;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton m_cmdNextPage;
        private System.Windows.Forms.ToolStripButton m_cmdLastPage;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripComboBox m_cboInpatientDate;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private com.digitalwave.Controls.ctlComboBox m_cboSex;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private com.digitalwave.Controls.ctlMaskedTextBox m_txtHight;
        private com.digitalwave.Controls.ctlMaskedTextBox m_txtWeight;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ColumnHeader clmEmployeeName;
        private System.Windows.Forms.ListView m_lsvDeliver;
        private ExternalControlsLib.XPButton m_cmdAsst;
        private ExternalControlsLib.XPButton m_cmdDeliver;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private com.digitalwave.controls.ctlRichTextBox m_txtAllPartogram;
        private com.digitalwave.controls.ctlRichTextBox m_txtThreePartogram;
        private com.digitalwave.controls.ctlRichTextBox m_txtSndPartogram;
        private com.digitalwave.controls.ctlRichTextBox m_txtFirstPartogram;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.BindingSource m_bidSource;
        private System.Windows.Forms.ToolStripButton m_cmdAddHourRec;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private com.digitalwave.Controls.ctlMaskedNumber m_txtGravid;
        private com.digitalwave.Controls.ctlMaskedNumber m_txtBorn;
        private com.digitalwave.Controls.ctlMaskedDateTimePicker m_txtBreakTime;
        private com.digitalwave.Controls.ctlMaskedDateTimePicker m_txtExpectDate;
        private com.digitalwave.Controls.ctlMaskedDateTimePicker m_txtMenses;
        private com.digitalwave.Controls.ctlMaskedDateTimePicker m_txtGiveBirthTime;
        private System.Drawing.Printing.PrintDocument m_pdmPrint;
        private com.digitalwave.Utility.Controls.ctlComboBox m_cboGravidWay;
        private com.digitalwave.controls.ctlRichTextBox m_txtAidUser;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private ExternalControlsLib.XPButton m_cmdAddHourRec_new;
    }
}