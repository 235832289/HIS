namespace iCare
{
    partial class frmICUNurseRecordMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICUNurseRecordMain));
            this.m_cboLIQUID5 = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboLIQUID4 = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboLIQUID3 = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboLIQUID2 = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboLIQUID1 = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.m_cboOpName = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboAfterOpDays = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_txtWeight = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.m_cboDRAIN5 = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.m_cboDRAIN4 = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboDRAIN3 = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboDRAIN2 = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboDRAIN1 = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ctmICU = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tmiNewRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiModifyRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiDeleteRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiNewContent = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiModifyContent = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiDeleteContent = new System.Windows.Forms.ToolStripMenuItem();
            this.tbMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.m_lblHint = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.m_llbSeeOtherInDept = new System.Windows.Forms.LinkLabel();
            this.m_lsvInDeptDate = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRecordDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtbRecords)).BeginInit();
            this.m_pnlNewBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.ctmICU.SuspendLayout();
            this.tbMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // m_dtgRecordDetail
            // 
            this.m_dtgRecordDetail.BackgroundColor = System.Drawing.Color.White;
            this.m_dtgRecordDetail.CaptionBackColor = System.Drawing.Color.White;
            this.m_dtgRecordDetail.DataSource = this.m_dtbRecords;
            this.m_dtgRecordDetail.Location = new System.Drawing.Point(15, 171);
            this.m_dtgRecordDetail.Size = new System.Drawing.Size(187, 18);
            this.m_dtgRecordDetail.Visible = false;
            // 
            // m_trvInPatientDate
            // 
            this.m_trvInPatientDate.BackColor = System.Drawing.Color.White;
            this.m_trvInPatientDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_trvInPatientDate.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_trvInPatientDate.LineColor = System.Drawing.Color.Black;
            this.m_trvInPatientDate.Location = new System.Drawing.Point(10, 265);
            this.m_trvInPatientDate.Size = new System.Drawing.Size(201, 62);
            this.m_trvInPatientDate.Visible = false;
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(677, 300);
            this.lblSex.Size = new System.Drawing.Size(30, 22);
            this.lblSex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(745, 300);
            this.lblAge.Size = new System.Drawing.Size(28, 22);
            this.lblAge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(426, 272);
            this.lblBedNoTitle.Size = new System.Drawing.Size(56, 14);
            this.lblBedNoTitle.Text = "床　号:";
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(426, 308);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(639, 272);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(638, 304);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(713, 304);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(213, 307);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(1027, 135);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(135, 121);
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(486, 303);
            this.txtInPatientID.Size = new System.Drawing.Size(135, 23);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(687, 269);
            this.m_txtPatientName.Size = new System.Drawing.Size(123, 23);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(486, 265);
            this.m_txtBedNO.Size = new System.Drawing.Size(106, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(254, 303);
            this.m_cboArea.Size = new System.Drawing.Size(164, 23);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(555, 401);
            this.m_lsvPatientName.Size = new System.Drawing.Size(135, 121);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(392, 401);
            this.m_lsvBedNO.Size = new System.Drawing.Size(135, 121);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(255, 269);
            this.m_cboDept.Size = new System.Drawing.Size(164, 23);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(214, 274);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(821, 56);
            this.m_cmdNewTemplate.Size = new System.Drawing.Size(98, 37);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.m_cmdNext.Location = new System.Drawing.Point(594, 265);
            this.m_cmdNext.Size = new System.Drawing.Size(28, 24);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(27, 189);
            this.m_cmdPre.Size = new System.Drawing.Size(28, 24);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(137, 170);
            this.m_lblForTitle.Size = new System.Drawing.Size(19, 27);
            this.m_lblForTitle.Visible = false;
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(632, 40);
            this.chkModifyWithoutMatk.Size = new System.Drawing.Size(103, 25);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(628, -33);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Size = new System.Drawing.Size(800, 60);
            this.m_pnlNewBase.Visible = true;
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(798, 29);
            // 
            // m_cboLIQUID5
            // 
            this.m_cboLIQUID5.AccessibleDescription = "液体设定5";
            this.m_cboLIQUID5.BackColor = System.Drawing.Color.White;
            this.m_cboLIQUID5.BorderColor = System.Drawing.Color.Black;
            this.m_cboLIQUID5.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboLIQUID5.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboLIQUID5.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboLIQUID5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboLIQUID5.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboLIQUID5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboLIQUID5.ForeColor = System.Drawing.Color.Black;
            this.m_cboLIQUID5.ListBackColor = System.Drawing.Color.White;
            this.m_cboLIQUID5.ListForeColor = System.Drawing.Color.Black;
            this.m_cboLIQUID5.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboLIQUID5.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboLIQUID5.Location = new System.Drawing.Point(680, 106);
            this.m_cboLIQUID5.m_BlnEnableItemEventMenu = true;
            this.m_cboLIQUID5.Name = "m_cboLIQUID5";
            this.m_cboLIQUID5.SelectedIndex = -1;
            this.m_cboLIQUID5.SelectedItem = null;
            this.m_cboLIQUID5.SelectionStart = 0;
            this.m_cboLIQUID5.Size = new System.Drawing.Size(128, 23);
            this.m_cboLIQUID5.TabIndex = 80;
            this.m_cboLIQUID5.Tag = "";
            this.m_cboLIQUID5.TextBackColor = System.Drawing.Color.White;
            this.m_cboLIQUID5.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboLIQUID4
            // 
            this.m_cboLIQUID4.AccessibleDescription = "液体设定4";
            this.m_cboLIQUID4.BackColor = System.Drawing.Color.White;
            this.m_cboLIQUID4.BorderColor = System.Drawing.Color.Black;
            this.m_cboLIQUID4.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboLIQUID4.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboLIQUID4.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboLIQUID4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboLIQUID4.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboLIQUID4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboLIQUID4.ForeColor = System.Drawing.Color.Black;
            this.m_cboLIQUID4.ListBackColor = System.Drawing.Color.White;
            this.m_cboLIQUID4.ListForeColor = System.Drawing.Color.Black;
            this.m_cboLIQUID4.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboLIQUID4.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboLIQUID4.Location = new System.Drawing.Point(536, 106);
            this.m_cboLIQUID4.m_BlnEnableItemEventMenu = true;
            this.m_cboLIQUID4.Name = "m_cboLIQUID4";
            this.m_cboLIQUID4.SelectedIndex = -1;
            this.m_cboLIQUID4.SelectedItem = null;
            this.m_cboLIQUID4.SelectionStart = 0;
            this.m_cboLIQUID4.Size = new System.Drawing.Size(128, 23);
            this.m_cboLIQUID4.TabIndex = 70;
            this.m_cboLIQUID4.Tag = "";
            this.m_cboLIQUID4.TextBackColor = System.Drawing.Color.White;
            this.m_cboLIQUID4.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboLIQUID3
            // 
            this.m_cboLIQUID3.AccessibleDescription = "液体设定3";
            this.m_cboLIQUID3.BackColor = System.Drawing.Color.White;
            this.m_cboLIQUID3.BorderColor = System.Drawing.Color.Black;
            this.m_cboLIQUID3.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboLIQUID3.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboLIQUID3.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboLIQUID3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboLIQUID3.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboLIQUID3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboLIQUID3.ForeColor = System.Drawing.Color.Black;
            this.m_cboLIQUID3.ListBackColor = System.Drawing.Color.White;
            this.m_cboLIQUID3.ListForeColor = System.Drawing.Color.Black;
            this.m_cboLIQUID3.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboLIQUID3.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboLIQUID3.Location = new System.Drawing.Point(392, 106);
            this.m_cboLIQUID3.m_BlnEnableItemEventMenu = true;
            this.m_cboLIQUID3.Name = "m_cboLIQUID3";
            this.m_cboLIQUID3.SelectedIndex = -1;
            this.m_cboLIQUID3.SelectedItem = null;
            this.m_cboLIQUID3.SelectionStart = 0;
            this.m_cboLIQUID3.Size = new System.Drawing.Size(128, 23);
            this.m_cboLIQUID3.TabIndex = 60;
            this.m_cboLIQUID3.Tag = "";
            this.m_cboLIQUID3.TextBackColor = System.Drawing.Color.White;
            this.m_cboLIQUID3.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboLIQUID2
            // 
            this.m_cboLIQUID2.AccessibleDescription = "液体设定2";
            this.m_cboLIQUID2.BackColor = System.Drawing.Color.White;
            this.m_cboLIQUID2.BorderColor = System.Drawing.Color.Black;
            this.m_cboLIQUID2.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboLIQUID2.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboLIQUID2.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboLIQUID2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboLIQUID2.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboLIQUID2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboLIQUID2.ForeColor = System.Drawing.Color.Black;
            this.m_cboLIQUID2.ListBackColor = System.Drawing.Color.White;
            this.m_cboLIQUID2.ListForeColor = System.Drawing.Color.Black;
            this.m_cboLIQUID2.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboLIQUID2.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboLIQUID2.Location = new System.Drawing.Point(248, 106);
            this.m_cboLIQUID2.m_BlnEnableItemEventMenu = true;
            this.m_cboLIQUID2.Name = "m_cboLIQUID2";
            this.m_cboLIQUID2.SelectedIndex = -1;
            this.m_cboLIQUID2.SelectedItem = null;
            this.m_cboLIQUID2.SelectionStart = 0;
            this.m_cboLIQUID2.Size = new System.Drawing.Size(128, 23);
            this.m_cboLIQUID2.TabIndex = 50;
            this.m_cboLIQUID2.Tag = "";
            this.m_cboLIQUID2.TextBackColor = System.Drawing.Color.White;
            this.m_cboLIQUID2.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboLIQUID1
            // 
            this.m_cboLIQUID1.AccessibleDescription = "液体设定1";
            this.m_cboLIQUID1.BackColor = System.Drawing.Color.White;
            this.m_cboLIQUID1.BorderColor = System.Drawing.Color.Black;
            this.m_cboLIQUID1.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboLIQUID1.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboLIQUID1.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboLIQUID1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboLIQUID1.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboLIQUID1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboLIQUID1.ForeColor = System.Drawing.Color.Black;
            this.m_cboLIQUID1.ListBackColor = System.Drawing.Color.White;
            this.m_cboLIQUID1.ListForeColor = System.Drawing.Color.Black;
            this.m_cboLIQUID1.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboLIQUID1.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboLIQUID1.Location = new System.Drawing.Point(104, 106);
            this.m_cboLIQUID1.m_BlnEnableItemEventMenu = true;
            this.m_cboLIQUID1.Name = "m_cboLIQUID1";
            this.m_cboLIQUID1.SelectedIndex = -1;
            this.m_cboLIQUID1.SelectedItem = null;
            this.m_cboLIQUID1.SelectionStart = 0;
            this.m_cboLIQUID1.Size = new System.Drawing.Size(128, 23);
            this.m_cboLIQUID1.TabIndex = 40;
            this.m_cboLIQUID1.Tag = "";
            this.m_cboLIQUID1.TextBackColor = System.Drawing.Color.White;
            this.m_cboLIQUID1.TextForeColor = System.Drawing.Color.Black;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(88, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 14);
            this.label6.TabIndex = 10000208;
            this.label6.Text = "1.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(232, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 14);
            this.label7.TabIndex = 10000204;
            this.label7.Text = "2.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(376, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 14);
            this.label8.TabIndex = 10000203;
            this.label8.Text = "3.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(520, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 14);
            this.label9.TabIndex = 10000205;
            this.label9.Text = "4.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(664, 106);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 14);
            this.label10.TabIndex = 10000207;
            this.label10.Text = "5.";
            // 
            // m_cboOpName
            // 
            this.m_cboOpName.AccessibleDescription = "手术名称";
            this.m_cboOpName.BackColor = System.Drawing.Color.White;
            this.m_cboOpName.BorderColor = System.Drawing.Color.Black;
            this.m_cboOpName.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboOpName.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboOpName.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboOpName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboOpName.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboOpName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboOpName.ForeColor = System.Drawing.Color.Black;
            this.m_cboOpName.ListBackColor = System.Drawing.Color.White;
            this.m_cboOpName.ListForeColor = System.Drawing.Color.Black;
            this.m_cboOpName.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboOpName.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboOpName.Location = new System.Drawing.Point(249, 79);
            this.m_cboOpName.m_BlnEnableItemEventMenu = true;
            this.m_cboOpName.Name = "m_cboOpName";
            this.m_cboOpName.SelectedIndex = -1;
            this.m_cboOpName.SelectedItem = null;
            this.m_cboOpName.SelectionStart = 0;
            this.m_cboOpName.Size = new System.Drawing.Size(271, 23);
            this.m_cboOpName.TabIndex = 20;
            this.m_cboOpName.Tag = "";
            this.m_cboOpName.TextBackColor = System.Drawing.Color.White;
            this.m_cboOpName.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboAfterOpDays
            // 
            this.m_cboAfterOpDays.AccessibleDescription = "手术后天数";
            this.m_cboAfterOpDays.BorderColor = System.Drawing.Color.Black;
            this.m_cboAfterOpDays.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboAfterOpDays.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboAfterOpDays.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboAfterOpDays.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboAfterOpDays.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboAfterOpDays.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboAfterOpDays.ListBackColor = System.Drawing.Color.White;
            this.m_cboAfterOpDays.ListForeColor = System.Drawing.Color.Black;
            this.m_cboAfterOpDays.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
            this.m_cboAfterOpDays.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
            this.m_cboAfterOpDays.Location = new System.Drawing.Point(619, 78);
            this.m_cboAfterOpDays.m_BlnEnableItemEventMenu = false;
            this.m_cboAfterOpDays.Name = "m_cboAfterOpDays";
            this.m_cboAfterOpDays.SelectedIndex = -1;
            this.m_cboAfterOpDays.SelectedItem = null;
            this.m_cboAfterOpDays.SelectionStart = 0;
            this.m_cboAfterOpDays.Size = new System.Drawing.Size(45, 23);
            this.m_cboAfterOpDays.TabIndex = 30;
            this.m_cboAfterOpDays.Tag = "";
            this.m_cboAfterOpDays.TextBackColor = System.Drawing.Color.White;
            this.m_cboAfterOpDays.TextForeColor = System.Drawing.Color.Black;
            this.m_cboAfterOpDays.Leave += new System.EventHandler(this.m_cboAfterOpDays_Leave);
            this.m_cboAfterOpDays.SelectedValueChanged += new System.EventHandler(this.m_cboAfterOpDays_SelectedValueChanged);
            // 
            // m_txtWeight
            // 
            this.m_txtWeight.AccessibleDescription = "体重";
            this.m_txtWeight.BackColor = System.Drawing.Color.White;
            this.m_txtWeight.BorderColor = System.Drawing.Color.Transparent;
            this.m_txtWeight.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtWeight.ForeColor = System.Drawing.Color.Black;
            this.m_txtWeight.Location = new System.Drawing.Point(47, 79);
            this.m_txtWeight.Name = "m_txtWeight";
            this.m_txtWeight.Size = new System.Drawing.Size(70, 23);
            this.m_txtWeight.TabIndex = 10;
            this.m_txtWeight.Leave += new System.EventHandler(this.m_txtWeight_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 10000217;
            this.label1.Text = "体重:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(530, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 14);
            this.label3.TabIndex = 10000214;
            this.label3.Text = "术后/入ICU第";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(664, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 14);
            this.label4.TabIndex = 10000215;
            this.label4.Text = "天";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(146, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 14);
            this.label5.TabIndex = 10000216;
            this.label5.Text = "诊断/手术名称:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 10000221;
            this.label2.Text = "液体设定:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 139);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 14);
            this.label11.TabIndex = 10000232;
            this.label11.Text = "引流设定:";
            // 
            // m_cboDRAIN5
            // 
            this.m_cboDRAIN5.AccessibleDescription = "引流设定5";
            this.m_cboDRAIN5.BackColor = System.Drawing.Color.White;
            this.m_cboDRAIN5.BorderColor = System.Drawing.Color.Black;
            this.m_cboDRAIN5.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboDRAIN5.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboDRAIN5.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboDRAIN5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboDRAIN5.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboDRAIN5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboDRAIN5.ForeColor = System.Drawing.Color.Black;
            this.m_cboDRAIN5.ListBackColor = System.Drawing.Color.White;
            this.m_cboDRAIN5.ListForeColor = System.Drawing.Color.Black;
            this.m_cboDRAIN5.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboDRAIN5.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboDRAIN5.Location = new System.Drawing.Point(680, 135);
            this.m_cboDRAIN5.m_BlnEnableItemEventMenu = true;
            this.m_cboDRAIN5.Name = "m_cboDRAIN5";
            this.m_cboDRAIN5.SelectedIndex = -1;
            this.m_cboDRAIN5.SelectedItem = null;
            this.m_cboDRAIN5.SelectionStart = 0;
            this.m_cboDRAIN5.Size = new System.Drawing.Size(128, 23);
            this.m_cboDRAIN5.TabIndex = 130;
            this.m_cboDRAIN5.Tag = "";
            this.m_cboDRAIN5.TextBackColor = System.Drawing.Color.White;
            this.m_cboDRAIN5.TextForeColor = System.Drawing.Color.Black;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(664, 135);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 14);
            this.label12.TabIndex = 10000225;
            this.label12.Text = "5.";
            // 
            // m_cboDRAIN4
            // 
            this.m_cboDRAIN4.AccessibleDescription = "引流设定4";
            this.m_cboDRAIN4.BackColor = System.Drawing.Color.White;
            this.m_cboDRAIN4.BorderColor = System.Drawing.Color.Black;
            this.m_cboDRAIN4.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboDRAIN4.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboDRAIN4.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboDRAIN4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboDRAIN4.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboDRAIN4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboDRAIN4.ForeColor = System.Drawing.Color.Black;
            this.m_cboDRAIN4.ListBackColor = System.Drawing.Color.White;
            this.m_cboDRAIN4.ListForeColor = System.Drawing.Color.Black;
            this.m_cboDRAIN4.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboDRAIN4.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboDRAIN4.Location = new System.Drawing.Point(536, 135);
            this.m_cboDRAIN4.m_BlnEnableItemEventMenu = true;
            this.m_cboDRAIN4.Name = "m_cboDRAIN4";
            this.m_cboDRAIN4.SelectedIndex = -1;
            this.m_cboDRAIN4.SelectedItem = null;
            this.m_cboDRAIN4.SelectionStart = 0;
            this.m_cboDRAIN4.Size = new System.Drawing.Size(128, 23);
            this.m_cboDRAIN4.TabIndex = 120;
            this.m_cboDRAIN4.Tag = "";
            this.m_cboDRAIN4.TextBackColor = System.Drawing.Color.White;
            this.m_cboDRAIN4.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboDRAIN3
            // 
            this.m_cboDRAIN3.AccessibleDescription = "引流设定3";
            this.m_cboDRAIN3.BackColor = System.Drawing.Color.White;
            this.m_cboDRAIN3.BorderColor = System.Drawing.Color.Black;
            this.m_cboDRAIN3.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboDRAIN3.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboDRAIN3.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboDRAIN3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboDRAIN3.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboDRAIN3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboDRAIN3.ForeColor = System.Drawing.Color.Black;
            this.m_cboDRAIN3.ListBackColor = System.Drawing.Color.White;
            this.m_cboDRAIN3.ListForeColor = System.Drawing.Color.Black;
            this.m_cboDRAIN3.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboDRAIN3.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboDRAIN3.Location = new System.Drawing.Point(392, 135);
            this.m_cboDRAIN3.m_BlnEnableItemEventMenu = true;
            this.m_cboDRAIN3.Name = "m_cboDRAIN3";
            this.m_cboDRAIN3.SelectedIndex = -1;
            this.m_cboDRAIN3.SelectedItem = null;
            this.m_cboDRAIN3.SelectionStart = 0;
            this.m_cboDRAIN3.Size = new System.Drawing.Size(128, 23);
            this.m_cboDRAIN3.TabIndex = 110;
            this.m_cboDRAIN3.Tag = "";
            this.m_cboDRAIN3.TextBackColor = System.Drawing.Color.White;
            this.m_cboDRAIN3.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboDRAIN2
            // 
            this.m_cboDRAIN2.AccessibleDescription = "引流设定2";
            this.m_cboDRAIN2.BackColor = System.Drawing.Color.White;
            this.m_cboDRAIN2.BorderColor = System.Drawing.Color.Black;
            this.m_cboDRAIN2.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboDRAIN2.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboDRAIN2.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboDRAIN2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboDRAIN2.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboDRAIN2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboDRAIN2.ForeColor = System.Drawing.Color.Black;
            this.m_cboDRAIN2.ListBackColor = System.Drawing.Color.White;
            this.m_cboDRAIN2.ListForeColor = System.Drawing.Color.Black;
            this.m_cboDRAIN2.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboDRAIN2.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboDRAIN2.Location = new System.Drawing.Point(248, 135);
            this.m_cboDRAIN2.m_BlnEnableItemEventMenu = true;
            this.m_cboDRAIN2.Name = "m_cboDRAIN2";
            this.m_cboDRAIN2.SelectedIndex = -1;
            this.m_cboDRAIN2.SelectedItem = null;
            this.m_cboDRAIN2.SelectionStart = 0;
            this.m_cboDRAIN2.Size = new System.Drawing.Size(128, 23);
            this.m_cboDRAIN2.TabIndex = 100;
            this.m_cboDRAIN2.Tag = "";
            this.m_cboDRAIN2.TextBackColor = System.Drawing.Color.White;
            this.m_cboDRAIN2.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboDRAIN1
            // 
            this.m_cboDRAIN1.AccessibleDescription = "引流设定1";
            this.m_cboDRAIN1.BackColor = System.Drawing.Color.White;
            this.m_cboDRAIN1.BorderColor = System.Drawing.Color.Black;
            this.m_cboDRAIN1.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboDRAIN1.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboDRAIN1.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboDRAIN1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboDRAIN1.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboDRAIN1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboDRAIN1.ForeColor = System.Drawing.Color.Black;
            this.m_cboDRAIN1.ListBackColor = System.Drawing.Color.White;
            this.m_cboDRAIN1.ListForeColor = System.Drawing.Color.Black;
            this.m_cboDRAIN1.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboDRAIN1.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboDRAIN1.Location = new System.Drawing.Point(104, 135);
            this.m_cboDRAIN1.m_BlnEnableItemEventMenu = true;
            this.m_cboDRAIN1.Name = "m_cboDRAIN1";
            this.m_cboDRAIN1.SelectedIndex = -1;
            this.m_cboDRAIN1.SelectedItem = null;
            this.m_cboDRAIN1.SelectionStart = 0;
            this.m_cboDRAIN1.Size = new System.Drawing.Size(128, 23);
            this.m_cboDRAIN1.TabIndex = 90;
            this.m_cboDRAIN1.Tag = "";
            this.m_cboDRAIN1.TextBackColor = System.Drawing.Color.White;
            this.m_cboDRAIN1.TextForeColor = System.Drawing.Color.Black;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(88, 135);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 14);
            this.label13.TabIndex = 10000226;
            this.label13.Text = "1.";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(232, 135);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 14);
            this.label14.TabIndex = 10000223;
            this.label14.Text = "2.";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(376, 135);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 14);
            this.label15.TabIndex = 10000222;
            this.label15.Text = "3.";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(520, 135);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(21, 14);
            this.label16.TabIndex = 10000224;
            this.label16.Text = "4.";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Info;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.ctmICU;
            this.dataGridView1.Location = new System.Drawing.Point(6, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(749, 366);
            this.dataGridView1.TabIndex = 10000233;
            // 
            // ctmICU
            // 
            this.ctmICU.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiNewRecord,
            this.tmiModifyRecord,
            this.tmiDeleteRecord,
            this.toolStripSeparator1,
            this.tmiNewContent,
            this.tmiModifyContent,
            this.tmiDeleteContent});
            this.ctmICU.Name = "contextMenuStrip1";
            this.ctmICU.Size = new System.Drawing.Size(147, 142);
            // 
            // tmiNewRecord
            // 
            this.tmiNewRecord.Name = "tmiNewRecord";
            this.tmiNewRecord.Size = new System.Drawing.Size(146, 22);
            this.tmiNewRecord.Text = "添加记录";
            this.tmiNewRecord.Click += new System.EventHandler(this.tmiNewRecord_Click);
            // 
            // tmiModifyRecord
            // 
            this.tmiModifyRecord.Name = "tmiModifyRecord";
            this.tmiModifyRecord.Size = new System.Drawing.Size(146, 22);
            this.tmiModifyRecord.Text = "修改记录";
            this.tmiModifyRecord.Click += new System.EventHandler(this.tmiModifyRecord_Click);
            // 
            // tmiDeleteRecord
            // 
            this.tmiDeleteRecord.Name = "tmiDeleteRecord";
            this.tmiDeleteRecord.Size = new System.Drawing.Size(146, 22);
            this.tmiDeleteRecord.Text = "删除记录";
            this.tmiDeleteRecord.Click += new System.EventHandler(this.tmiDeleteRecord_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // tmiNewContent
            // 
            this.tmiNewContent.Name = "tmiNewContent";
            this.tmiNewContent.Size = new System.Drawing.Size(146, 22);
            this.tmiNewContent.Text = "添加护理内容";
            this.tmiNewContent.Visible = false;
            this.tmiNewContent.Click += new System.EventHandler(this.tmiNewContent_Click);
            // 
            // tmiModifyContent
            // 
            this.tmiModifyContent.Name = "tmiModifyContent";
            this.tmiModifyContent.Size = new System.Drawing.Size(146, 22);
            this.tmiModifyContent.Text = "修改护理内容";
            this.tmiModifyContent.Visible = false;
            this.tmiModifyContent.Click += new System.EventHandler(this.tmiModifyContent_Click);
            // 
            // tmiDeleteContent
            // 
            this.tmiDeleteContent.Name = "tmiDeleteContent";
            this.tmiDeleteContent.Size = new System.Drawing.Size(146, 22);
            this.tmiDeleteContent.Text = "删除护理内容";
            this.tmiDeleteContent.Visible = false;
            this.tmiDeleteContent.Click += new System.EventHandler(this.tmiDeleteContent_Click);
            // 
            // tbMain
            // 
            this.tbMain.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMain.ContextMenuStrip = this.ctmICU;
            this.tbMain.Controls.Add(this.tabPage1);
            this.tbMain.Controls.Add(this.tabPage2);
            this.tbMain.Controls.Add(this.tabPage3);
            this.tbMain.Location = new System.Drawing.Point(10, 164);
            this.tbMain.Multiline = true;
            this.tbMain.Name = "tbMain";
            this.tbMain.SelectedIndex = 0;
            this.tbMain.Size = new System.Drawing.Size(793, 402);
            this.tbMain.TabIndex = 10000234;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.m_lblHint);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(25, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(764, 394);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "记录";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // m_lblHint
            // 
            this.m_lblHint.ForeColor = System.Drawing.Color.DodgerBlue;
            this.m_lblHint.Location = new System.Drawing.Point(6, 378);
            this.m_lblHint.Name = "m_lblHint";
            this.m_lblHint.Size = new System.Drawing.Size(419, 16);
            this.m_lblHint.TabIndex = 10000242;
            this.m_lblHint.Text = "当前选择入ICU时间:{0}";
            this.m_lblHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lblHint.Visible = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Location = new System.Drawing.Point(25, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(764, 394);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "呼吸机";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info;
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.ContextMenuStrip = this.ctmICU;
            this.dataGridView2.Location = new System.Drawing.Point(6, 6);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(747, 366);
            this.dataGridView2.TabIndex = 10000234;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridView3);
            this.tabPage3.Location = new System.Drawing.Point(25, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(764, 394);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "护理记录";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info;
            this.dataGridView3.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView3.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(11, 6);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowTemplate.Height = 23;
            this.dataGridView3.Size = new System.Drawing.Size(747, 366);
            this.dataGridView3.TabIndex = 10000235;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label17.Location = new System.Drawing.Point(8, 71);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(802, 2);
            this.label17.TabIndex = 10000235;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(119, 82);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(21, 14);
            this.label18.TabIndex = 10000236;
            this.label18.Text = "kg";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(392, 78);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(128, 23);
            this.dateTimePicker1.TabIndex = 10000237;
            this.dateTimePicker1.Visible = false;
            // 
            // m_llbSeeOtherInDept
            // 
            this.m_llbSeeOtherInDept.AutoSize = true;
            this.m_llbSeeOtherInDept.Location = new System.Drawing.Point(691, 82);
            this.m_llbSeeOtherInDept.Name = "m_llbSeeOtherInDept";
            this.m_llbSeeOtherInDept.Size = new System.Drawing.Size(119, 14);
            this.m_llbSeeOtherInDept.TabIndex = 10000238;
            this.m_llbSeeOtherInDept.TabStop = true;
            this.m_llbSeeOtherInDept.Text = "查看其它入科记录";
            this.m_llbSeeOtherInDept.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llbSeeOtherInDept_LinkClicked);
            // 
            // m_lsvInDeptDate
            // 
            this.m_lsvInDeptDate.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.m_lsvInDeptDate.FullRowSelect = true;
            this.m_lsvInDeptDate.GridLines = true;
            this.m_lsvInDeptDate.Location = new System.Drawing.Point(272, 199);
            this.m_lsvInDeptDate.MultiSelect = false;
            this.m_lsvInDeptDate.Name = "m_lsvInDeptDate";
            this.m_lsvInDeptDate.Size = new System.Drawing.Size(280, 165);
            this.m_lsvInDeptDate.TabIndex = 10000240;
            this.m_lsvInDeptDate.UseCompatibleStateImageBehavior = false;
            this.m_lsvInDeptDate.View = System.Windows.Forms.View.Details;
            this.m_lsvInDeptDate.Visible = false;
            this.m_lsvInDeptDate.DoubleClick += new System.EventHandler(this.m_lsvInDeptDate_DoubleClick);
            this.m_lsvInDeptDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_lsvInDeptDate_KeyDown);
            this.m_lsvInDeptDate.Leave += new System.EventHandler(this.m_lsvInDeptDate_Leave);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "入ICU日期";
            this.columnHeader1.Width = 275;
            // 
            // frmICUNurseRecordMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 595);
            this.Controls.Add(this.tbMain);
            this.Controls.Add(this.m_lsvInDeptDate);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.m_cboDRAIN5);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.m_cboDRAIN4);
            this.Controls.Add(this.m_cboDRAIN3);
            this.Controls.Add(this.m_cboDRAIN2);
            this.Controls.Add(this.m_cboDRAIN1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_txtWeight);
            this.Controls.Add(this.m_cboOpName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_llbSeeOtherInDept);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.m_cboAfterOpDays);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.m_cboLIQUID5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.m_cboLIQUID4);
            this.Controls.Add(this.m_cboLIQUID3);
            this.Controls.Add(this.m_cboLIQUID2);
            this.Controls.Add(this.m_cboLIQUID1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmICUNurseRecordMain";
            this.Text = " ICU护理记录";
            this.Load += new System.EventHandler(this.frmICUNurseRecordMain_Load);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.m_cboLIQUID1, 0);
            this.Controls.SetChildIndex(this.m_cboLIQUID2, 0);
            this.Controls.SetChildIndex(this.m_cboLIQUID3, 0);
            this.Controls.SetChildIndex(this.m_cboLIQUID4, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.m_cboLIQUID5, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.m_cboAfterOpDays, 0);
            this.Controls.SetChildIndex(this.dateTimePicker1, 0);
            this.Controls.SetChildIndex(this.m_llbSeeOtherInDept, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.m_cboOpName, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.m_txtWeight, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.m_cboDRAIN1, 0);
            this.Controls.SetChildIndex(this.m_cboDRAIN2, 0);
            this.Controls.SetChildIndex(this.m_cboDRAIN3, 0);
            this.Controls.SetChildIndex(this.m_cboDRAIN4, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.m_cboDRAIN5, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.label17, 0);
            this.Controls.SetChildIndex(this.label18, 0);
            this.Controls.SetChildIndex(this.m_dtgRecordDetail, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.m_trvInPatientDate, 0);
            this.Controls.SetChildIndex(this.m_lsvInDeptDate, 0);
            this.Controls.SetChildIndex(this.tbMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRecordDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtbRecords)).EndInit();
            this.m_pnlNewBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ctmICU.ResumeLayout(false);
            this.tbMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboLIQUID5;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboLIQUID4;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboLIQUID3;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboLIQUID2;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboLIQUID1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboOpName;
        private com.digitalwave.Utility.Controls.ctlComboBox m_cboAfterOpDays;
        protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtWeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboDRAIN5;
        private System.Windows.Forms.Label label12;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboDRAIN4;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboDRAIN3;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboDRAIN2;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboDRAIN1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabControl tbMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ContextMenuStrip ctmICU;
        private System.Windows.Forms.ToolStripMenuItem tmiNewRecord;
        private System.Windows.Forms.ToolStripMenuItem tmiModifyRecord;
        private System.Windows.Forms.ToolStripMenuItem tmiDeleteRecord;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tmiNewContent;
        private System.Windows.Forms.ToolStripMenuItem tmiModifyContent;
        private System.Windows.Forms.ToolStripMenuItem tmiDeleteContent;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.LinkLabel m_llbSeeOtherInDept;
        private System.Windows.Forms.ListView m_lsvInDeptDate;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label m_lblHint;
    }
}