using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using iCareData;
using HRP;
using com.digitalwave.Utility.Controls;
using System.Drawing.Printing;


namespace iCare
{
	/// <summary>
	/// 复诊记录
	/// </summary>
	public class frmOutPatientRevisitRecord : iCare.frmHRPBaseForm,PublicFunction
	{
		#region Define
		private com.digitalwave.controls.ctlRichTextBox m_txtRecordContent;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboRecordList;
		private System.Windows.Forms.Label label20;
		private PinkieControls.ButtonXP m_cmdsave;
		private PinkieControls.ButtonXP m_cmdOnDoc;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtOnDoc;
		private PinkieControls.ButtonXP m_cmdExit;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox gpbInPatientList;
		private System.Windows.Forms.NumericUpDown m_nudViewMo;
		private System.Windows.Forms.RadioButton m_rdbViewAll;
		private System.Windows.Forms.ListView m_lsvInPatientList;
		private System.Windows.Forms.RadioButton m_rdbViewPart;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		public com.digitalwave.Utility.Controls.ctlTimePicker m_dtpCreateDate;
		private System.Windows.Forms.Label label3;
		protected System.Windows.Forms.ContextMenu m_cmuRichTextBoxMenu;
		private System.Windows.Forms.MenuItem mniDoubleStrikeOutDelete;


		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private PrintTool.frmPrintPreviewDialog ppdPrintPreview;
		private System.Drawing.Printing.PrintDocument m_pdcPrintDocument;
		private clsOutPatientRevisitDomain m_objDomain;
		private clsPatient m_objSelecttPatient;

		#endregion

		public frmOutPatientRevisitRecord()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            //指明医生工作站表单
            intFormType = 1;
			m_objDomain = new clsOutPatientRevisitDomain(m_cboDept,m_cboArea,m_lsvInPatientList);
			new clsCommonUseToolCollection(this).m_mthBindEmployeeSign(new Control[]{this.m_cmdOnDoc },new Control[]{this.m_txtOnDoc},new int[]{1});
			m_mthInitilize();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.m_txtRecordContent = new com.digitalwave.controls.ctlRichTextBox();
            this.m_cmuRichTextBoxMenu = new System.Windows.Forms.ContextMenu();
            this.mniDoubleStrikeOutDelete = new System.Windows.Forms.MenuItem();
            this.m_cboRecordList = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.m_cmdsave = new PinkieControls.ButtonXP();
            this.m_cmdExit = new PinkieControls.ButtonXP();
            this.m_cmdOnDoc = new PinkieControls.ButtonXP();
            this.m_txtOnDoc = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_pdcPrintDocument = new System.Drawing.Printing.PrintDocument();
            this.m_dtpCreateDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gpbInPatientList = new System.Windows.Forms.GroupBox();
            this.m_nudViewMo = new System.Windows.Forms.NumericUpDown();
            this.m_rdbViewAll = new System.Windows.Forms.RadioButton();
            this.m_lsvInPatientList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.m_rdbViewPart = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.gpbInPatientList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudViewMo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSex
            // 
            this.lblSex.Size = new System.Drawing.Size(4, 4);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Size = new System.Drawing.Size(4, 4);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(188, 56);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.AutoSize = false;
            this.lblInHospitalNoTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(101)))), ((int)(((byte)(152)))));
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(768, 44);
            this.lblInHospitalNoTitle.Size = new System.Drawing.Size(4, 4);
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.AutoSize = false;
            this.lblNameTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(101)))), ((int)(((byte)(152)))));
            this.lblNameTitle.Location = new System.Drawing.Point(532, 44);
            this.lblNameTitle.Size = new System.Drawing.Size(4, 4);
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.AutoSize = false;
            this.lblSexTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(101)))), ((int)(((byte)(152)))));
            this.lblSexTitle.Location = new System.Drawing.Point(552, 44);
            this.lblSexTitle.Size = new System.Drawing.Size(4, 4);
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.AutoSize = false;
            this.lblAgeTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(101)))), ((int)(((byte)(152)))));
            this.lblAgeTitle.Location = new System.Drawing.Point(656, 44);
            this.lblAgeTitle.Size = new System.Drawing.Size(4, 4);
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblAreaTitle.Location = new System.Drawing.Point(256, 24);
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(880, 132);
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Enabled = false;
            this.txtInPatientID.Location = new System.Drawing.Point(840, 44);
            this.txtInPatientID.Size = new System.Drawing.Size(4, 23);
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Enabled = false;
            this.m_txtPatientName.Location = new System.Drawing.Point(544, 44);
            this.m_txtPatientName.Size = new System.Drawing.Size(4, 23);
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Enabled = false;
            this.m_txtBedNO.Location = new System.Drawing.Point(520, 44);
            this.m_txtBedNO.Size = new System.Drawing.Size(4, 23);
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(308, 20);
            this.m_cboArea.SelectedIndexChanged += new System.EventHandler(this.m_cboArea_SelectedIndexChanged);
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(476, 132);
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(336, 132);
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(68, 20);
            this.m_cboDept.SelectedIndexChanged += new System.EventHandler(this.m_cboDept_SelectedIndexChanged);
            // 
            // lblDept
            // 
            this.lblDept.BackColor = System.Drawing.SystemColors.Control;
            this.lblDept.Location = new System.Drawing.Point(16, 24);
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(101)))), ((int)(((byte)(152)))));
            this.m_cmdNewTemplate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(832, 68);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(101)))), ((int)(((byte)(152)))));
            this.m_cmdNext.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdNext.Location = new System.Drawing.Point(168, 20);
            this.m_cmdNext.UseVisualStyleBackColor = false;
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(101)))), ((int)(((byte)(152)))));
            this.m_cmdPre.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdPre.Location = new System.Drawing.Point(144, 20);
            this.m_cmdPre.UseVisualStyleBackColor = false;
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.BackColor = System.Drawing.SystemColors.Control;
            this.m_lblForTitle.Location = new System.Drawing.Point(504, 8);
            this.m_lblForTitle.Size = new System.Drawing.Size(432, 56);
            this.m_lblForTitle.Visible = true;
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(748, 18);
            // 
            // m_txtRecordContent
            // 
            this.m_txtRecordContent.AccessibleDescription = "";
            this.m_txtRecordContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtRecordContent.AutoSize = true;
            this.m_txtRecordContent.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.m_txtRecordContent.ContextMenu = this.m_cmuRichTextBoxMenu;
            this.m_txtRecordContent.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtRecordContent.ForeColor = System.Drawing.Color.Black;
            this.m_txtRecordContent.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtRecordContent.Location = new System.Drawing.Point(8, 82);
            this.m_txtRecordContent.m_BlnIgnoreUserInfo = false;
            this.m_txtRecordContent.m_BlnPartControl = false;
            this.m_txtRecordContent.m_BlnReadOnly = false;
            this.m_txtRecordContent.m_BlnUnderLineDST = false;
            this.m_txtRecordContent.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtRecordContent.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtRecordContent.m_IntCanModifyTime = 6;
            this.m_txtRecordContent.m_IntPartControlLength = 0;
            this.m_txtRecordContent.m_IntPartControlStartIndex = 0;
            this.m_txtRecordContent.m_StrUserID = "";
            this.m_txtRecordContent.m_StrUserName = "";
            this.m_txtRecordContent.MaxLength = 30000;
            this.m_txtRecordContent.Name = "m_txtRecordContent";
            this.m_txtRecordContent.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtRecordContent.Size = new System.Drawing.Size(548, 338);
            this.m_txtRecordContent.TabIndex = 10000004;
            this.m_txtRecordContent.Tag = "0";
            this.m_txtRecordContent.Text = "";
            // 
            // m_cmuRichTextBoxMenu
            // 
            this.m_cmuRichTextBoxMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mniDoubleStrikeOutDelete});
            // 
            // mniDoubleStrikeOutDelete
            // 
            this.mniDoubleStrikeOutDelete.Index = 0;
            this.mniDoubleStrikeOutDelete.Text = "双划线删除";
            // 
            // m_cboRecordList
            // 
            this.m_cboRecordList.AccessibleDescription = "";
            this.m_cboRecordList.BackColor = System.Drawing.SystemColors.Control;
            this.m_cboRecordList.BorderColor = System.Drawing.Color.Black;
            this.m_cboRecordList.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboRecordList.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboRecordList.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboRecordList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboRecordList.flatFont = new System.Drawing.Font("宋体", 10.5F);
            this.m_cboRecordList.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_cboRecordList.ForeColor = System.Drawing.Color.Black;
            this.m_cboRecordList.ListBackColor = System.Drawing.Color.White;
            this.m_cboRecordList.ListForeColor = System.Drawing.Color.Black;
            this.m_cboRecordList.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
            this.m_cboRecordList.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboRecordList.Location = new System.Drawing.Point(360, 24);
            this.m_cboRecordList.m_BlnEnableItemEventMenu = false;
            this.m_cboRecordList.Name = "m_cboRecordList";
            this.m_cboRecordList.SelectedIndex = -1;
            this.m_cboRecordList.SelectedItem = null;
            this.m_cboRecordList.SelectionStart = 0;
            this.m_cboRecordList.Size = new System.Drawing.Size(196, 23);
            this.m_cboRecordList.TabIndex = 10000003;
            this.m_cboRecordList.TextBackColor = System.Drawing.Color.White;
            this.m_cboRecordList.TextForeColor = System.Drawing.Color.Black;
            this.m_cboRecordList.SelectedIndexChanged += new System.EventHandler(this.m_cboRecordList_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(280, 28);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(70, 14);
            this.label20.TabIndex = 10000005;
            this.label20.Text = "记录列表:";
            // 
            // m_cmdsave
            // 
            this.m_cmdsave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdsave.DefaultScheme = true;
            this.m_cmdsave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdsave.Hint = "";
            this.m_cmdsave.Location = new System.Drawing.Point(692, 520);
            this.m_cmdsave.Name = "m_cmdsave";
            this.m_cmdsave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdsave.Size = new System.Drawing.Size(75, 28);
            this.m_cmdsave.TabIndex = 10000007;
            this.m_cmdsave.Text = "保  存";
            this.m_cmdsave.Click += new System.EventHandler(this.m_cmdsave_Click);
            // 
            // m_cmdExit
            // 
            this.m_cmdExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdExit.DefaultScheme = true;
            this.m_cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdExit.Hint = "";
            this.m_cmdExit.Location = new System.Drawing.Point(876, 520);
            this.m_cmdExit.Name = "m_cmdExit";
            this.m_cmdExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdExit.Size = new System.Drawing.Size(75, 28);
            this.m_cmdExit.TabIndex = 10000007;
            this.m_cmdExit.Text = "退  出";
            this.m_cmdExit.Click += new System.EventHandler(this.m_cmdExit_Click);
            // 
            // m_cmdOnDoc
            // 
            this.m_cmdOnDoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdOnDoc.DefaultScheme = true;
            this.m_cmdOnDoc.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdOnDoc.Font = new System.Drawing.Font("宋体", 12F);
            this.m_cmdOnDoc.Hint = "";
            this.m_cmdOnDoc.Location = new System.Drawing.Point(36, 520);
            this.m_cmdOnDoc.Name = "m_cmdOnDoc";
            this.m_cmdOnDoc.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdOnDoc.Size = new System.Drawing.Size(76, 28);
            this.m_cmdOnDoc.TabIndex = 10000008;
            this.m_cmdOnDoc.Text = "记录者:";
            // 
            // m_txtOnDoc
            // 
            this.m_txtOnDoc.AccessibleDescription = "住院医师签名";
            this.m_txtOnDoc.AccessibleName = "NoDefault";
            this.m_txtOnDoc.BackColor = System.Drawing.Color.White;
            this.m_txtOnDoc.BorderColor = System.Drawing.Color.Transparent;
            this.m_txtOnDoc.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtOnDoc.ForeColor = System.Drawing.Color.Black;
            this.m_txtOnDoc.Location = new System.Drawing.Point(116, 520);
            this.m_txtOnDoc.Name = "m_txtOnDoc";
            this.m_txtOnDoc.Size = new System.Drawing.Size(92, 28);
            this.m_txtOnDoc.TabIndex = 10000009;
            this.m_txtOnDoc.Tag = "1";
            // 
            // m_pdcPrintDocument
            // 
            this.m_pdcPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.m_pdcPrintDocument_PrintPage);
            this.m_pdcPrintDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_BeginPrint);
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.BackColor = System.Drawing.SystemColors.Control;
            this.m_dtpCreateDate.BorderColor = System.Drawing.Color.Black;
            this.m_dtpCreateDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpCreateDate.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_dtpCreateDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpCreateDate.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpCreateDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpCreateDate.Font = new System.Drawing.Font("宋体", 12F);
            this.m_dtpCreateDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpCreateDate.Location = new System.Drawing.Point(84, 26);
            this.m_dtpCreateDate.m_BlnOnlyTime = false;
            this.m_dtpCreateDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpCreateDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpCreateDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpCreateDate.Name = "m_dtpCreateDate";
            this.m_dtpCreateDate.ReadOnly = false;
            this.m_dtpCreateDate.Size = new System.Drawing.Size(192, 22);
            this.m_dtpCreateDate.TabIndex = 10000010;
            this.m_dtpCreateDate.TextBackColor = System.Drawing.Color.White;
            this.m_dtpCreateDate.TextForeColor = System.Drawing.Color.Black;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 10000005;
            this.label3.Text = "记录时间:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_dtpCreateDate);
            this.groupBox1.Controls.Add(this.m_txtRecordContent);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.m_cboRecordList);
            this.groupBox1.Location = new System.Drawing.Point(416, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(564, 432);
            this.groupBox1.TabIndex = 10000011;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "记录内容:";
            // 
            // gpbInPatientList
            // 
            this.gpbInPatientList.Controls.Add(this.m_nudViewMo);
            this.gpbInPatientList.Controls.Add(this.m_rdbViewAll);
            this.gpbInPatientList.Controls.Add(this.m_lsvInPatientList);
            this.gpbInPatientList.Controls.Add(this.m_rdbViewPart);
            this.gpbInPatientList.Controls.Add(this.label4);
            this.gpbInPatientList.Location = new System.Drawing.Point(16, 76);
            this.gpbInPatientList.Name = "gpbInPatientList";
            this.gpbInPatientList.Size = new System.Drawing.Size(392, 432);
            this.gpbInPatientList.TabIndex = 10000016;
            this.gpbInPatientList.TabStop = false;
            this.gpbInPatientList.Text = "出院病人一览表";
            // 
            // m_nudViewMo
            // 
            this.m_nudViewMo.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.m_nudViewMo.ForeColor = System.Drawing.Color.Black;
            this.m_nudViewMo.Location = new System.Drawing.Point(204, 28);
            this.m_nudViewMo.Maximum = new decimal(new int[] {
            36,
            0,
            0,
            0});
            this.m_nudViewMo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_nudViewMo.Name = "m_nudViewMo";
            this.m_nudViewMo.Size = new System.Drawing.Size(40, 23);
            this.m_nudViewMo.TabIndex = 97;
            this.m_nudViewMo.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.m_nudViewMo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_nudViewMo_KeyPress);
            // 
            // m_rdbViewAll
            // 
            this.m_rdbViewAll.Location = new System.Drawing.Point(8, 28);
            this.m_rdbViewAll.Name = "m_rdbViewAll";
            this.m_rdbViewAll.Size = new System.Drawing.Size(92, 20);
            this.m_rdbViewAll.TabIndex = 1;
            this.m_rdbViewAll.Text = "显示全部";
            this.m_rdbViewAll.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // m_lsvInPatientList
            // 
            this.m_lsvInPatientList.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.m_lsvInPatientList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.m_lsvInPatientList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_lsvInPatientList.ForeColor = System.Drawing.Color.Black;
            this.m_lsvInPatientList.FullRowSelect = true;
            this.m_lsvInPatientList.GridLines = true;
            this.m_lsvInPatientList.Location = new System.Drawing.Point(3, 53);
            this.m_lsvInPatientList.MultiSelect = false;
            this.m_lsvInPatientList.Name = "m_lsvInPatientList";
            this.m_lsvInPatientList.Size = new System.Drawing.Size(386, 376);
            this.m_lsvInPatientList.TabIndex = 0;
            this.m_lsvInPatientList.UseCompatibleStateImageBehavior = false;
            this.m_lsvInPatientList.View = System.Windows.Forms.View.Details;
            this.m_lsvInPatientList.SelectedIndexChanged += new System.EventHandler(this.m_lsvInPatientList_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "住 院 号";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "姓  名";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "住院日期";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 130;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "出院日期";
            this.columnHeader4.Width = 130;
            // 
            // m_rdbViewPart
            // 
            this.m_rdbViewPart.Checked = true;
            this.m_rdbViewPart.Location = new System.Drawing.Point(156, 28);
            this.m_rdbViewPart.Name = "m_rdbViewPart";
            this.m_rdbViewPart.Size = new System.Drawing.Size(224, 20);
            this.m_rdbViewPart.TabIndex = 1;
            this.m_rdbViewPart.TabStop = true;
            this.m_rdbViewPart.Text = "显示      个月内出院病人";
            this.m_rdbViewPart.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.m_rdbViewPart.CheckedChanged += new System.EventHandler(this.m_rdbViewPart_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(192, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 14);
            this.label4.TabIndex = 93;
            this.label4.Text = "个月内出院病人";
            // 
            // frmOutPatientRevisitRecord
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.m_cmdExit;
            this.ClientSize = new System.Drawing.Size(990, 583);
            this.Controls.Add(this.m_txtOnDoc);
            this.Controls.Add(this.gpbInPatientList);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_cmdOnDoc);
            this.Controls.Add(this.m_cmdsave);
            this.Controls.Add(this.m_cmdExit);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmOutPatientRevisitRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "复诊\\随访记录";
            this.Load += new System.EventHandler(this.frmOutPatientRevisitRecord_Load);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_cmdExit, 0);
            this.Controls.SetChildIndex(this.m_cmdsave, 0);
            this.Controls.SetChildIndex(this.m_cmdOnDoc, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.gpbInPatientList, 0);
            this.Controls.SetChildIndex(this.m_txtOnDoc, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpbInPatientList.ResumeLayout(false);
            this.gpbInPatientList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudViewMo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// 窗体ID，只针对允许作废重做的窗体
		/// </summary>
		public override int m_IntFormID
		{
			get
			{
				return 49;
			}
		}
		/// <summary>
		/// 获取当前表单状态
		/// </summary>
		protected override enmFormState m_EnmCurrentFormState
		{
			get
			{
				//				throw new Exception("没有实现 m_EnmCurrentFormState 函数");
				return enmFormState.NowUser;
			}
		}
		private void m_mthInitilize()
		{
			new ctlHighLightFocus(clsHRPColor.s_ClrHightLight).m_mthAddControlInContainer(m_txtRecordContent);
			m_mthResetRecordList();
			m_txtOnDoc.Text = MDIParent.strOperatorName;
			m_txtOnDoc.Tag = new clsEmployee(MDIParent.strOperatorID);
			ppdPrintPreview = new PrintTool.frmPrintPreviewDialog();
			m_objDomain.m_mthInitilize();
		}

		#region 接口
		public void Copy()
		{
			m_lngCopy();
		}

		public void Cut()
		{
			m_lngCut();
		}
		public void Verify()
		{
			//long lngRes=m_lngSignVerify(p_strFormID,p_strRecordID);
		}
		public void Delete()
		{
			long m_lngRe=m_lngSubDelete(); 
			if(m_lngRe>0)
			{	
				m_cboRecordList.SelectedIndex = 0;
				MDIParent.ShowInformationMessageBox("删除成功！");
			}
			else
				MDIParent.ShowInformationMessageBox("删除失败！");

		}

		public void Display()
		{
		
		}

		public void Display(string cardno, string sendcheckdate)
		{
		
		}

		public void Paste()
		{
			m_lngPaste();
		}

		public void Print()
		{
			m_lngSubPrint(); 
		}

		public void Redo()
		{
			if(m_txtRecordContent.CanRedo)
				m_txtRecordContent.Redo();
		}

		public void Save()
		{
			long m_lngRe=0;
			if(m_BlnIsAddNew)
				m_lngRe = m_lngSubAddNew();
			else
				m_lngRe = m_lngSubModify();
			if(m_lngRe>0)
			{
//				m_blnIsAddNew = false;
				m_txtOnDoc.Enabled = false;
				MDIParent.ShowInformationMessageBox("保存成功！");
			}
			else
				MDIParent.ShowInformationMessageBox("保存失败！");
		}


		public void Undo()
		{
			if(m_txtRecordContent.CanUndo)
			m_txtRecordContent.Undo();
		}
		#endregion 接口

		#region Save,Modify,Delete,Print
		private bool m_blnIsAddNew = true;
		/// <summary>
		/// 是否是添加新记录的操作。true，添加新记录；false,修改记录
		/// </summary>
		protected override bool m_BlnIsAddNew
		{
			get
			{
				return m_blnIsAddNew;
			}
		}
		/// <summary>
		/// 子窗体的添加操作。（注意，此操作不能被调用）
		/// </summary>
		/// <returns></returns>
		protected override long m_lngSubAddNew()
		{
			if(m_objSelecttPatient == null)
				return 0;
			clsOutPatientRevisitRecord_VO objContent = new clsOutPatientRevisitRecord_VO();
			objContent.m_StrInPatientID = m_objSelecttPatient.m_StrInPatientID;
			objContent.m_DtmCreatedDate = DateTime.Now;
			objContent.m_DtmInPatientDate = m_objSelecttPatient.m_DtmSelectedInDate;
			objContent.m_DtmInPatientEndDate = m_objSelecttPatient.m_DtmSelectedOutDate;
			objContent.m_DtmOpenDate = DateTime.Now;
			objContent.m_IntStatus = 0;
			if(m_txtOnDoc.Tag != null)
				objContent.m_StrCreatedUserID = ((clsEmployee)m_txtOnDoc.Tag).m_StrEmployeeID;
			objContent.m_StrRevisitRecord = m_txtRecordContent.Text;
			 long lngRes = m_objDomain.m_lngAddRecordContent(objContent);
			if(lngRes > 0)
			{
				m_cboRecordList.InsertItem(1,objContent);
			}
			return lngRes;
		}
		/// <summary>
		/// 修改操作。
		/// </summary>
		/// <returns></returns>
		protected override long m_lngSubModify()
		{
			if(m_cboRecordList.SelectedItem is clsOutPatientRevisitRecord_VO)
			{
				clsOutPatientRevisitRecord_VO objContent = m_cboRecordList.SelectedItem as clsOutPatientRevisitRecord_VO;
				objContent.m_DtmOpenDate = DateTime.Now;
				objContent.m_StrRevisitRecord = m_txtRecordContent.Text;
				long lngRes = m_objDomain.m_lngModifyRecordContent(objContent);
				if(objContent != null)
					m_cboRecordList.SelectedItem = objContent;
				return lngRes;
			}
			return 0;
		}
		/// <summary>
		/// 删除操作。
		/// </summary>
		/// <returns></returns>
		protected override long m_lngSubDelete()
		{
			if(m_cboRecordList.SelectedItem is clsOutPatientRevisitRecord_VO)
			{
				clsOutPatientRevisitRecord_VO objContent = m_cboRecordList.SelectedItem as clsOutPatientRevisitRecord_VO;
				objContent.m_IntStatus = 1;
				objContent.m_DtmDeActivedDate = DateTime.Now;
				objContent.m_StrDeActivedOperatorID = MDIParent.strOperatorID;
				long lngRes = m_objDomain.m_lngDeleteRecordContent(objContent);
				if(lngRes > 0)
				{
					m_cboRecordList.RemoveItem(objContent);
				}
				return lngRes;
			}
			return 0;
		}
		/// <summary>
		/// 打印操作。
		/// </summary>
		/// <returns></returns>
		protected override long m_lngSubPrint()
		{
			m_mthStartPrint();
			return 1;
		}
		private void m_mthStartPrint()
		{
			if(m_blnDirectPrint)
			{
				m_pdcPrintDocument.Print();
			}
			else
			{
				ppdPrintPreview.Document = m_pdcPrintDocument;
				ppdPrintPreview.TopLevel = true;
				ppdPrintPreview.ShowDialog();
			}
		}
		#endregion Save,Modify,Delete,Print

		private void m_rdbViewPart_CheckedChanged(object sender, System.EventArgs e)
		{
			m_nudViewMo.Enabled = m_rdbViewPart.Checked;
			m_mthDisplayPatient();
		}
		private void m_mthDisplayPatient()
		{
			this.Cursor=Cursors.WaitCursor;
			try
			{
				string strDate = "1900-01-01 00:00:00";
				if(m_rdbViewPart.Checked)
				{
					try
					{
						strDate = DateTime.Now.AddMonths(-1*Convert.ToInt32(m_nudViewMo.Value)).ToString("yyyy-MM-dd 00:00:00");}
					catch{strDate = "1900-01-01 00:00:00";}
				}
				m_objDomain.m_mthDisplayPatient(strDate,true);
			}
			catch{this.Cursor=Cursors.Default;}
			this.Cursor=Cursors.Default;
		}
		/// <summary>
		/// 清空除当前控件以外的所有窗体内容,(可覆盖提供新的实现)
		/// </summary>
		/// <param name="p_ctlControl"></param>
		/// <param name="p_blnReadOnly"></param>
		protected override void m_mthClearAllInfo(Control p_ctlControl)
		{
			m_mthClearAll();
		}
		private void m_mthClearAll()
		{
            if (m_lsvInPatientList == null) return;
			m_lsvInPatientList.Items.Clear();
			m_mthResetRecordList();
			m_mthClearRecordInfo();
		}
		private void m_mthLoadAllRecord(clsPatient p_objSelectedPatient)
		{
			if(p_objSelectedPatient == null)
				return;
			
			m_mthResetRecordList();
			m_mthClearRecordInfo();

			clsOutPatientRevisitRecord_VO[] objContentArr = null;
			m_objDomain.m_lngGetRecordContentByInPatient(p_objSelectedPatient.m_StrInPatientID,p_objSelectedPatient.m_DtmSelectedInDate,out objContentArr);
			if(objContentArr != null && objContentArr.Length > 0)
			{
				m_cboRecordList.AddRangeItems(objContentArr);
			}
		}
		/// <summary>
		/// 获取当前病人的作废内容
		/// </summary>
		/// <param name="p_dtmRecordDate">记录日期</param>
		/// <param name="p_intFormID">窗体ID</param>
		protected override void m_mthGetDeactiveContent(DateTime p_dtmRecordDate,int p_intFormID)
		{
			if(m_objSelecttPatient == null || m_objSelecttPatient.m_StrInPatientID == null || m_objSelecttPatient.m_DtmSelectedInDate==DateTime.MinValue)
				return ;
			clsOutPatientRevisitRecord_VO p_objContent = null;
			long lngRes = m_objDomain.m_lngGetDeActivedRecordContent(m_objSelecttPatient.m_StrInPatientID, m_objSelecttPatient.m_DtmSelectedInDate,p_dtmRecordDate,out p_objContent);
			if(lngRes <= 0 || p_objContent == null)
			{
				return;
			}
			m_mthClearRecordInfo();
			m_cboRecordList.SelectedIndex = 0;
			m_mthSetGUIFromContent(p_objContent);
		}
		private void m_mthClearRecordInfo()
		{
			m_dtpCreateDate.Value = DateTime.Now;
			m_txtRecordContent.Text = "";
			m_txtOnDoc.Enabled = true;
			m_txtOnDoc.Text = MDIParent.strOperatorName;
			m_txtOnDoc.Tag = new clsEmployee(MDIParent.strOperatorID);
			m_blnIsAddNew = true;
		}
		private void m_mthResetRecordList()
		{
			m_cboRecordList.ClearItem();
			m_cboRecordList.AddItem("新添");
			m_cboRecordList.SelectedIndex = 0;
		}
		private void m_mthSetGUIFromContent(clsOutPatientRevisitRecord_VO p_objContent)
		{
			if(p_objContent != null)
			{
				if(m_cboRecordList.SelectedIndex != 0)
				{
					m_dtpCreateDate.Value = p_objContent.m_DtmCreatedDate;
					if(p_objContent.m_StrCreatedUserID != null)
					{
						m_txtOnDoc.Text = new clsEmployee(p_objContent.m_StrCreatedUserID).m_StrFirstName;
						m_txtOnDoc.Tag = new clsEmployee(p_objContent.m_StrCreatedUserID);
					}
					m_blnIsAddNew = false;
				}
				m_txtRecordContent.Text = p_objContent.m_StrRevisitRecord;
			}
		}

		private void m_cboRecordList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_cboRecordList.SelectedIndex == 0)
			{
				m_mthClearRecordInfo();
				m_blnIsAddNew = true;
			}
			else if(m_cboRecordList.SelectedItem is clsOutPatientRevisitRecord_VO)
			{
				clsOutPatientRevisitRecord_VO objContent = m_cboRecordList.SelectedItem as clsOutPatientRevisitRecord_VO;
				m_mthSetGUIFromContent(objContent);
				m_blnIsAddNew = false;
			}
		}

		private void m_pdcPrintDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
		
		}

		private void m_pdcPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
//			clsOutPatientRevisitRecord_VO[] objRecordArr;
//			long lngRef = m_objDomain.m_lngGetRecordContentByInPatient(m_objCurrentPatient.m_StrInPatientID,m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate.ToString("yyyy-MM-dd HH:mm:ss"),out objRecordArr);
//			if(lngRef <=0 || objRecordArr == null)
//			{
//				ppdPrintPreview.Close();
//				return;
//			}
//
//			for(int i=0;i<objRecordArr.Length;i++)
//			{
//				if(objRecordArr[i] != null)
//					m_mthSubPrint(objRecordArr[i],e);
//			}
//			
//			m_intYPos = 180;
		}
		private void m_mthSubPrint(string p_CurrentRecord,System.Drawing.Printing.PrintPageEventArgs e)
		{
//			e.Graphics.DrawString(MDIParent.s_ObjDepartment.m_StrDeptName,m_fotSmallFont,m_slbBrush,100,m_intYPos);
//			e.Graphics.DrawString(m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName + "床" ,m_fotSmallFont,m_slbBrush,200,m_intYPos);
//			e.Graphics.DrawString(m_objCurrentPatient.m_StrName,m_fotSmallFont,m_slbBrush,300,m_intYPos);
//			m_intYPos += 30;
//			RectangleF rtgF = new RectangleF(100,m_intYPos,650,50);
//			e.Graphics.DrawString("    "+p_CurrentRecord.m_strValue,m_fotSmallFont,m_slbBrush,rtgF);
//			m_intYPos += Convert.ToInt32( rtgF.Height);
//			e.Graphics.DrawString("记录者：" + p_CurrentRecord.m_strCreateUser,m_fotSmallFont,m_slbBrush,320,m_intYPos);
//			m_intYPos += 20;
//			e.Graphics.DrawString("时间：" + p_CurrentRecord.m_dtmCreateTime.ToString("yyyy年MM月dd日"),m_fotSmallFont,m_slbBrush,320,m_intYPos);
//			m_intYPos += 40;
		}

		private void m_cmdsave_Click(object sender, System.EventArgs e)
		{
			Save();
		}

		private void m_cmdExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void m_lsvInPatientList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_lsvInPatientList.SelectedItems.Count <=0 )
				return;
			m_objSelecttPatient = m_lsvInPatientList.SelectedItems[0].Tag as clsPatient;
			m_mthLoadAllRecord(m_objSelecttPatient);
		}
		/// <summary>
		/// 设置窗体中控件的只读属性,
		/// </summary>
		/// <param name="p_ctlControl"></param>
		/// <param name="p_blnReadOnly"></param>
		protected override void m_mthSetControlReadOnly(Control p_ctlControl,bool p_blnReadOnly)
		{}
		protected override void m_mthSetOutPatientRevisitList()
		{
			m_mthDisplayPatient();
		}
		
		private void m_nudViewMo_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar == (byte)13)//回车
			{
				m_mthDisplayPatient();
			}
		}

		private void frmOutPatientRevisitRecord_Load(object sender, System.EventArgs e)
		{
			m_mthDisplayPatient();
		}

		private void m_cboDept_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.Cursor=Cursors.WaitCursor;
			m_mthClearAll();
			m_objDomain.m_thDept_SelectedIndexChanged();
			this.Cursor=Cursors.Default;
		}

		private void m_cboArea_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_cboArea.SelectedIndex < 0)
				return;
			m_mthClearAll();
			m_mthDisplayPatient();
		}
	}
}
