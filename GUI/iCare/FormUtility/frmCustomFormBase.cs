using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using iCareData;
using System.IO;
using System.Xml;
using System.Collections.Generic;

namespace iCare.CustomForm
{
	public class frmCustomFormBase : iCare.frmHRPBaseForm,PublicFunction
	{
		#region Declare
		public System.Windows.Forms.Label lblCreateDate;
		public com.digitalwave.Utility.Controls.ctlTimePicker m_dtpCreateDate;
		private System.Windows.Forms.GroupBox m_grbEditorArea;
		private System.Windows.Forms.Panel m_pnlContainer;
		private System.Windows.Forms.Panel panel1;
		public System.Windows.Forms.Label label1;
		private System.ComponentModel.IContainer components = null;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboAllRecordTime;
		private System.Drawing.Printing.PrintDocument m_pdcPrintDocument;
		private System.Windows.Forms.TabControl m_tabContainer;
		public System.Windows.Forms.Label lblPatientID;
		private System.Windows.Forms.Panel pnlCard;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtPatientName2;
		private System.Windows.Forms.Label m_lblSex;
		private System.Windows.Forms.Label m_lblAge;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtPatientID;
		private System.Windows.Forms.Panel pnlRecordDate;
		private System.Windows.Forms.ListView m_lsvPatientID;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private com.digitalwave.iCare.ValueObject.clsDepartmentVO[] m_objCurEmpDeptArr;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem14;
		private System.Windows.Forms.MenuItem menuItem17;
		private System.Windows.Forms.MenuItem menuItem18;
		private System.Windows.Forms.MenuItem menuItem19;
		private System.Windows.Forms.MenuItem menuItem20;
		private System.Windows.Forms.MenuItem menuItem21;
		private System.Windows.Forms.MenuItem menuItem22;
		private System.Windows.Forms.MenuItem menuItem23;
		private System.Windows.Forms.MenuItem menuItem24;
		private System.Windows.Forms.MenuItem menuItem25;
		private System.Windows.Forms.MenuItem mniSave;
		private System.Windows.Forms.MenuItem mniPrintPre;
		private System.Windows.Forms.MenuItem mniPrint;
		private System.Windows.Forms.MenuItem mniExit;
		private System.Windows.Forms.MenuItem mniFiles;
		private System.Windows.Forms.MenuItem mniEdit;
		private System.Windows.Forms.MenuItem mniUndo;
		private System.Windows.Forms.MenuItem mniRedo;
		private System.Windows.Forms.MenuItem mniCut;
		private System.Windows.Forms.MenuItem mniCopy;
		private System.Windows.Forms.MenuItem mniPaste;
		private System.Windows.Forms.MenuItem mniDelete;
		private System.Windows.Forms.MenuItem mniDelRec;
		private System.Windows.Forms.MenuItem menuItem2;
        private MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem4;
        private MenuItem menuItem1;


		//		private bool m_blnCanDo = true;
		private clsCustomFormDomain m_objDomain;
		/// <summary>
		/// 表单格式
		/// </summary>
		private clsCustom_SubmitValue m_objSubmitValues;
		private clsConfigXmlTool m_objConfigXmlTool;
		private Point m_potOutPatientLocation = new Point(20,27);
		private Point m_potInPatientLocation = new Point(220,27);
		private bool m_blnIsInPatient = true;
		private int m_intForm_ID;
		private const string c_strFormBaseName = "frmCustomForm_";
		private int m_intIndex = 0;
		private int m_intInOROutPatientStatus = -1;
//		private string m_strPatientID = string.Empty;
		private string m_strPatientCardID = string.Empty;
		private System.Windows.Forms.MenuItem mniTools;
		private Form m_frmMain;
		#endregion

		public frmCustomFormBase(clsCustom_SubmitValue p_objFormFormat)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			m_mthInit(p_objFormFormat);
			m_mthInitInOROutpatient();
		}
		private bool m_blnInitPatient = false;
		public frmCustomFormBase(clsCustom_SubmitValue p_objFormFormat,bool p_blnInitPatient)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			m_mthInit(p_objFormFormat);
			m_mthInitInOROutpatient();
			m_blnInitPatient = p_blnInitPatient;
		}
		
		public frmCustomFormBase(string p_strPatientID,string p_strPatientCradID,clsCustom_SubmitValue p_objFormFormat,Form p_frmSender)
		{
			InitializeComponent();
			if(p_strPatientID != null)
			{
				m_strPatientID = p_strPatientID;
			}
			if(p_strPatientCradID != null)
			{
				m_strPatientCardID = p_strPatientCradID;
			}
			m_frmMain = p_frmSender;
			m_intInOROutPatientStatus = 0;
			m_mthInit(p_objFormFormat);
			m_mthInitInOROutpatient();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.lblCreateDate = new System.Windows.Forms.Label();
            this.m_dtpCreateDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.m_grbEditorArea = new System.Windows.Forms.GroupBox();
            this.m_pnlContainer = new System.Windows.Forms.Panel();
            this.m_tabContainer = new System.Windows.Forms.TabControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_cboAllRecordTime = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_pdcPrintDocument = new System.Drawing.Printing.PrintDocument();
            this.lblPatientID = new System.Windows.Forms.Label();
            this.m_txtPatientID = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.pnlCard = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtPatientName2 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_lblSex = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_lblAge = new System.Windows.Forms.Label();
            this.pnlRecordDate = new System.Windows.Forms.Panel();
            this.m_lsvPatientID = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.mniFiles = new System.Windows.Forms.MenuItem();
            this.mniSave = new System.Windows.Forms.MenuItem();
            this.mniDelRec = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.mniPrintPre = new System.Windows.Forms.MenuItem();
            this.mniPrint = new System.Windows.Forms.MenuItem();
            this.menuItem14 = new System.Windows.Forms.MenuItem();
            this.mniExit = new System.Windows.Forms.MenuItem();
            this.mniEdit = new System.Windows.Forms.MenuItem();
            this.mniUndo = new System.Windows.Forms.MenuItem();
            this.mniRedo = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.mniCut = new System.Windows.Forms.MenuItem();
            this.mniCopy = new System.Windows.Forms.MenuItem();
            this.mniPaste = new System.Windows.Forms.MenuItem();
            this.mniDelete = new System.Windows.Forms.MenuItem();
            this.mniTools = new System.Windows.Forms.MenuItem();
            this.menuItem17 = new System.Windows.Forms.MenuItem();
            this.menuItem19 = new System.Windows.Forms.MenuItem();
            this.menuItem18 = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem20 = new System.Windows.Forms.MenuItem();
            this.menuItem21 = new System.Windows.Forms.MenuItem();
            this.menuItem22 = new System.Windows.Forms.MenuItem();
            this.menuItem24 = new System.Windows.Forms.MenuItem();
            this.menuItem23 = new System.Windows.Forms.MenuItem();
            this.menuItem25 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();

            this.m_pnlNewBase.SuspendLayout();
            this.m_grbEditorArea.SuspendLayout();
            this.m_pnlContainer.SuspendLayout();
            this.pnlCard.SuspendLayout();
            this.pnlRecordDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(235, 207);
            this.lblSex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(187, 228);
            this.lblAge.Size = new System.Drawing.Size(48, 19);
            this.lblAge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(252, 219);
            this.lblBedNoTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(235, 233);
            this.lblInHospitalNoTitle.Size = new System.Drawing.Size(70, 14);
            this.lblInHospitalNoTitle.Text = "住 院 号:";
            this.lblInHospitalNoTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(235, 213);
            this.lblNameTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(263, 201);
            this.lblSexTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(241, 224);
            this.lblAgeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(275, 189);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(199, 189);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(92, 104);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(184, 241);
            this.txtInPatientID.Size = new System.Drawing.Size(84, 23);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(229, 212);
            this.m_txtPatientName.Size = new System.Drawing.Size(88, 23);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(227, 224);
            this.m_txtBedNO.Size = new System.Drawing.Size(64, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(242, 229);
            this.m_cboArea.Size = new System.Drawing.Size(132, 23);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(278, 189);
            this.m_lsvPatientName.Size = new System.Drawing.Size(92, 104);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(256, 178);
            this.m_lsvBedNO.Size = new System.Drawing.Size(80, 104);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(238, 219);
            this.m_cboDept.Size = new System.Drawing.Size(132, 23);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(275, 219);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(324, 248);
            this.m_cmdNewTemplate.Size = new System.Drawing.Size(4, 4);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.m_cmdNext.Location = new System.Drawing.Point(256, 210);
            this.m_cmdNext.Size = new System.Drawing.Size(24, 20);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(274, 248);
            this.m_cmdPre.Size = new System.Drawing.Size(20, 16);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(632, 24);
            this.m_lblForTitle.Size = new System.Drawing.Size(0, 0);
            this.m_lblForTitle.Text = "自定义表单父窗体";
            this.m_lblForTitle.Visible = true;
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(456, 258);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(807, 8);
            this.m_cmdModifyPatientInfo.Size = new System.Drawing.Size(69, 25);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Size = new System.Drawing.Size(868, 60);
            this.m_pnlNewBase.Visible = true;
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(866, 29);
            // 
            // lblCreateDate
            // 
            this.lblCreateDate.AutoSize = true;
            this.lblCreateDate.Font = new System.Drawing.Font("宋体", 10.5F);
            this.lblCreateDate.Location = new System.Drawing.Point(4, 8);
            this.lblCreateDate.Name = "lblCreateDate";
            this.lblCreateDate.Size = new System.Drawing.Size(70, 14);
            this.lblCreateDate.TabIndex = 10000005;
            this.lblCreateDate.Text = "记录日期:";
            this.lblCreateDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.BorderColor = System.Drawing.Color.Black;
            this.m_dtpCreateDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpCreateDate.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_dtpCreateDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpCreateDate.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpCreateDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpCreateDate.Font = new System.Drawing.Font("宋体", 12F);
            this.m_dtpCreateDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpCreateDate.Location = new System.Drawing.Point(71, 4);
            this.m_dtpCreateDate.m_BlnOnlyTime = false;
            this.m_dtpCreateDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpCreateDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpCreateDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpCreateDate.Name = "m_dtpCreateDate";
            this.m_dtpCreateDate.ReadOnly = false;
            this.m_dtpCreateDate.Size = new System.Drawing.Size(212, 22);
            this.m_dtpCreateDate.TabIndex = 10000004;
            this.m_dtpCreateDate.TextBackColor = System.Drawing.Color.White;
            this.m_dtpCreateDate.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_grbEditorArea
            // 
            this.m_grbEditorArea.Controls.Add(this.m_pnlContainer);
            this.m_grbEditorArea.Location = new System.Drawing.Point(10, 71);
            this.m_grbEditorArea.Name = "m_grbEditorArea";
            this.m_grbEditorArea.Size = new System.Drawing.Size(868, 499);
            this.m_grbEditorArea.TabIndex = 10000006;
            this.m_grbEditorArea.TabStop = false;
            this.m_grbEditorArea.Text = "表单内容";
            // 
            // m_pnlContainer
            // 
            this.m_pnlContainer.AutoScroll = true;
            this.m_pnlContainer.Controls.Add(this.m_tabContainer);
            this.m_pnlContainer.Controls.Add(this.panel1);
            this.m_pnlContainer.Location = new System.Drawing.Point(4, 20);
            this.m_pnlContainer.Name = "m_pnlContainer";
            this.m_pnlContainer.Size = new System.Drawing.Size(860, 484);
            this.m_pnlContainer.TabIndex = 29168;
            // 
            // m_tabContainer
            // 
            this.m_tabContainer.Location = new System.Drawing.Point(3, 2);
            this.m_tabContainer.Name = "m_tabContainer";
            this.m_tabContainer.SelectedIndex = 0;
            this.m_tabContainer.Size = new System.Drawing.Size(841, 1169);
            this.m_tabContainer.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(836, 192);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(0, 0);
            this.panel1.TabIndex = 2;
            // 
            // m_cboAllRecordTime
            // 
            this.m_cboAllRecordTime.AccessibleName = "NoDefault";
            this.m_cboAllRecordTime.BackColor = System.Drawing.Color.White;
            this.m_cboAllRecordTime.BorderColor = System.Drawing.Color.Black;
            this.m_cboAllRecordTime.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboAllRecordTime.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboAllRecordTime.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboAllRecordTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboAllRecordTime.flatFont = new System.Drawing.Font("宋体", 10.5F);
            this.m_cboAllRecordTime.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_cboAllRecordTime.ForeColor = System.Drawing.Color.Black;
            this.m_cboAllRecordTime.ListBackColor = System.Drawing.SystemColors.Control;
            this.m_cboAllRecordTime.ListForeColor = System.Drawing.Color.Black;
            this.m_cboAllRecordTime.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
            this.m_cboAllRecordTime.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboAllRecordTime.Location = new System.Drawing.Point(355, 4);
            this.m_cboAllRecordTime.m_BlnEnableItemEventMenu = false;
            this.m_cboAllRecordTime.Name = "m_cboAllRecordTime";
            this.m_cboAllRecordTime.SelectedIndex = -1;
            this.m_cboAllRecordTime.SelectedItem = null;
            this.m_cboAllRecordTime.SelectionStart = 0;
            this.m_cboAllRecordTime.Size = new System.Drawing.Size(182, 23);
            this.m_cboAllRecordTime.TabIndex = 10000007;
            this.m_cboAllRecordTime.TextBackColor = System.Drawing.Color.White;
            this.m_cboAllRecordTime.TextForeColor = System.Drawing.Color.Black;
            this.m_cboAllRecordTime.SelectedIndexChanged += new System.EventHandler(this.m_cboAllRecordTime_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label1.Location = new System.Drawing.Point(289, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 10000008;
            this.label1.Text = "所有记录:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_pdcPrintDocument
            // 
            this.m_pdcPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.m_pdcPrintDocument_PrintPage);
            // 
            // lblPatientID
            // 
            this.lblPatientID.AutoSize = true;
            this.lblPatientID.Font = new System.Drawing.Font("宋体", 10.5F);
            this.lblPatientID.Location = new System.Drawing.Point(4, 8);
            this.lblPatientID.Name = "lblPatientID";
            this.lblPatientID.Size = new System.Drawing.Size(70, 14);
            this.lblPatientID.TabIndex = 10000008;
            this.lblPatientID.Text = "病人卡号:";
            this.lblPatientID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtPatientID
            // 
            this.m_txtPatientID.AccessibleName = "NoDefault";
            this.m_txtPatientID.BackColor = System.Drawing.Color.White;
            this.m_txtPatientID.BorderColor = System.Drawing.Color.Transparent;
            this.m_txtPatientID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPatientID.ForeColor = System.Drawing.Color.Black;
            this.m_txtPatientID.Location = new System.Drawing.Point(76, 8);
            this.m_txtPatientID.MaxLength = 10;
            this.m_txtPatientID.Name = "m_txtPatientID";
            this.m_txtPatientID.Size = new System.Drawing.Size(84, 23);
            this.m_txtPatientID.TabIndex = 10000009;
            this.m_txtPatientID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtPatientID_KeyDown);
            // 
            // pnlCard
            // 
            this.pnlCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard.Controls.Add(this.lblPatientID);
            this.pnlCard.Controls.Add(this.m_txtPatientID);
            this.pnlCard.Controls.Add(this.label2);
            this.pnlCard.Controls.Add(this.m_txtPatientName2);
            this.pnlCard.Controls.Add(this.label3);
            this.pnlCard.Controls.Add(this.m_lblSex);
            this.pnlCard.Controls.Add(this.label5);
            this.pnlCard.Controls.Add(this.m_lblAge);
            this.pnlCard.Location = new System.Drawing.Point(10, 7);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(868, 60);
            this.pnlCard.TabIndex = 10000010;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 14);
            this.label2.TabIndex = 10000011;
            this.label2.Text = "姓名:";
            // 
            // m_txtPatientName2
            // 
            this.m_txtPatientName2.AccessibleName = "NoDefault";
            this.m_txtPatientName2.BackColor = System.Drawing.Color.White;
            this.m_txtPatientName2.BorderColor = System.Drawing.Color.Transparent;
            this.m_txtPatientName2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPatientName2.ForeColor = System.Drawing.Color.Black;
            this.m_txtPatientName2.Location = new System.Drawing.Point(232, 8);
            this.m_txtPatientName2.Name = "m_txtPatientName2";
            this.m_txtPatientName2.Size = new System.Drawing.Size(84, 23);
            this.m_txtPatientName2.TabIndex = 10000009;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(328, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 14);
            this.label3.TabIndex = 10000011;
            this.label3.Text = "性别:";
            // 
            // m_lblSex
            // 
            this.m_lblSex.Location = new System.Drawing.Point(380, 8);
            this.m_lblSex.Name = "m_lblSex";
            this.m_lblSex.Size = new System.Drawing.Size(41, 19);
            this.m_lblSex.TabIndex = 10000011;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(428, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 14);
            this.label5.TabIndex = 10000011;
            this.label5.Text = "年龄:";
            // 
            // m_lblAge
            // 
            this.m_lblAge.Location = new System.Drawing.Point(476, 8);
            this.m_lblAge.Name = "m_lblAge";
            this.m_lblAge.Size = new System.Drawing.Size(41, 19);
            this.m_lblAge.TabIndex = 10000011;
            // 
            // pnlRecordDate
            // 
            this.pnlRecordDate.Controls.Add(this.m_cboAllRecordTime);
            this.pnlRecordDate.Controls.Add(this.m_dtpCreateDate);
            this.pnlRecordDate.Controls.Add(this.lblCreateDate);
            this.pnlRecordDate.Controls.Add(this.label1);
            this.pnlRecordDate.Location = new System.Drawing.Point(335, 35);
            this.pnlRecordDate.Name = "pnlRecordDate";
            this.pnlRecordDate.Size = new System.Drawing.Size(541, 30);
            this.pnlRecordDate.TabIndex = 10000011;
            // 
            // m_lsvPatientID
            // 
            this.m_lsvPatientID.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.m_lsvPatientID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_lsvPatientID.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.m_lsvPatientID.GridLines = true;
            this.m_lsvPatientID.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_lsvPatientID.Location = new System.Drawing.Point(86, 40);
            this.m_lsvPatientID.MultiSelect = false;
            this.m_lsvPatientID.Name = "m_lsvPatientID";
            this.m_lsvPatientID.Size = new System.Drawing.Size(100, 97);
            this.m_lsvPatientID.TabIndex = 10000012;
            this.m_lsvPatientID.UseCompatibleStateImageBehavior = false;
            this.m_lsvPatientID.View = System.Windows.Forms.View.Details;
            this.m_lsvPatientID.Visible = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 100;
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mniFiles,
            this.mniEdit,
            this.mniTools});
            // 
            // mniFiles
            // 
            this.mniFiles.Index = 0;
            this.mniFiles.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mniSave,
            this.mniDelRec,
            this.menuItem2,
            this.mniPrintPre,
            this.mniPrint,
            this.menuItem14,
            this.mniExit});
            this.mniFiles.Text = "文件(F)";
            // 
            // mniSave
            // 
            this.mniSave.Index = 0;
            this.mniSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.mniSave.Text = "保存(&S)";
            this.mniSave.Click += new System.EventHandler(this.menuItem10_Click);
            // 
            // mniDelRec
            // 
            this.mniDelRec.Index = 1;
            this.mniDelRec.Shortcut = System.Windows.Forms.Shortcut.Del;
            this.mniDelRec.Text = "删除(&D)";
            this.mniDelRec.Click += new System.EventHandler(this.mniDelRec_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 2;
            this.menuItem2.Text = "-";
            // 
            // mniPrintPre
            // 
            this.mniPrintPre.Index = 3;
            this.mniPrintPre.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
            this.mniPrintPre.Text = "打印预览(&Q)";
            this.mniPrintPre.Click += new System.EventHandler(this.mniPrintPre_Click);
            // 
            // mniPrint
            // 
            this.mniPrint.Index = 4;
            this.mniPrint.Text = "打印(&P)";
            this.mniPrint.Click += new System.EventHandler(this.mniPrint_Click);
            // 
            // menuItem14
            // 
            this.menuItem14.Index = 5;
            this.menuItem14.Text = "-";
            // 
            // mniExit
            // 
            this.mniExit.Index = 6;
            this.mniExit.Shortcut = System.Windows.Forms.Shortcut.AltF4;
            this.mniExit.Text = "退出(&X)";
            this.mniExit.Click += new System.EventHandler(this.mniExit_Click);
            // 
            // mniEdit
            // 
            this.mniEdit.Index = 1;
            this.mniEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mniUndo,
            this.mniRedo,
            this.menuItem5,
            this.mniCut,
            this.mniCopy,
            this.mniPaste,
            this.mniDelete});
            this.mniEdit.Text = "编辑(E)";
            // 
            // mniUndo
            // 
            this.mniUndo.Index = 0;
            this.mniUndo.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
            this.mniUndo.Text = "撤消(&U)";
            this.mniUndo.Click += new System.EventHandler(this.mniUndo_Click);
            // 
            // mniRedo
            // 
            this.mniRedo.Index = 1;
            this.mniRedo.Text = "重复(&R)";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 2;
            this.menuItem5.Text = "-";
            // 
            // mniCut
            // 
            this.mniCut.Index = 3;
            this.mniCut.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
            this.mniCut.Text = "剪切(&T)";
            this.mniCut.Click += new System.EventHandler(this.mniCut_Click);
            // 
            // mniCopy
            // 
            this.mniCopy.Index = 4;
            this.mniCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
            this.mniCopy.Text = "复制(&C)";
            this.mniCopy.Click += new System.EventHandler(this.mniCopy_Click);
            // 
            // mniPaste
            // 
            this.mniPaste.Index = 5;
            this.mniPaste.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
            this.mniPaste.Text = "粘贴(&P)";
            this.mniPaste.Click += new System.EventHandler(this.mniPaste_Click);
            // 
            // mniDelete
            // 
            this.mniDelete.Index = 6;
            this.mniDelete.Text = "删除(&D)";
            this.mniDelete.Visible = false;
            this.mniDelete.Click += new System.EventHandler(this.mniDelete_Click);
            // 
            // mniTools
            // 
            this.mniTools.Index = 2;
            this.mniTools.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem17,
            this.menuItem19,
            this.menuItem18,
            this.menuItem1,
            this.menuItem20,
            this.menuItem21,
            this.menuItem22,
            this.menuItem24,
            this.menuItem23,
            this.menuItem25,
            this.menuItem3,
            this.menuItem4});
            this.mniTools.Text = "工具(&T)";
            // 
            // menuItem17
            // 
            this.menuItem17.Index = 0;
            this.menuItem17.Text = "删除记录查询";
            this.menuItem17.Click += new System.EventHandler(this.menuItem17_Click);
            // 
            // menuItem19
            // 
            this.menuItem19.Index = 1;
            this.menuItem19.Text = "-";
            // 
            // menuItem18
            // 
            this.menuItem18.Index = 2;
            this.menuItem18.Text = "生成模板";
            this.menuItem18.Click += new System.EventHandler(this.menuItem18_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 3;
            this.menuItem1.Text = "应用模板";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem20
            // 
            this.menuItem20.Index = 4;
            this.menuItem20.Text = "生成常用值";
            this.menuItem20.Click += new System.EventHandler(this.menuItem20_Click);
            // 
            // menuItem21
            // 
            this.menuItem21.Index = 5;
            this.menuItem21.Text = "生成默认值";
            this.menuItem21.Click += new System.EventHandler(this.menuItem21_Click);
            // 
            // menuItem22
            // 
            this.menuItem22.Index = 6;
            this.menuItem22.Text = "重置默认值";
            this.menuItem22.Click += new System.EventHandler(this.menuItem22_Click);
            // 
            // menuItem24
            // 
            this.menuItem24.Index = 7;
            this.menuItem24.Text = "-";
            // 
            // menuItem23
            // 
            this.menuItem23.Index = 8;
            this.menuItem23.Text = "审核";
            // 
            // menuItem25
            // 
            this.menuItem25.Index = 9;
            this.menuItem25.Text = "退审";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 10;
            this.menuItem3.Text = "-";
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 11;
            this.menuItem4.Text = "窗体元素关联";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // frmCustomFormBase
            // 
            this.ClientSize = new System.Drawing.Size(912, 589);
            this.Controls.Add(this.m_lsvPatientID);
            this.Controls.Add(this.pnlRecordDate);
            this.Controls.Add(this.pnlCard);
            this.Controls.Add(this.m_grbEditorArea);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Menu = this.mainMenu1;
            this.Name = "frmCustomFormBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自定义表单父窗体";
            this.Load += new System.EventHandler(this.frmCustomFormBase_Load);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_grbEditorArea, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.pnlCard, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.pnlRecordDate, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientID, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.m_grbEditorArea.ResumeLayout(false);
            this.m_pnlContainer.ResumeLayout(false);
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.pnlRecordDate.ResumeLayout(false);
            this.pnlRecordDate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region Public Function
		public void Copy()
		{
			m_lngCopy();
		}

		public void Cut()
		{
			m_lngCut();
		}

		public void Delete()
		{
			m_lngDelete();
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
//			m_lngSubPrint();
			m_lngPrint();//只有调用父类的才有提示保存
		}

		public void Redo()
		{
		
		}

		public void Save()
		{
			m_lngSave();
		}
		public void Verify()
		{
			//long lngRes=m_lngSignVerify(p_strFormID,p_strRecordID);
		}
		public void Undo()
		{
		
		}
		#endregion
		
		private void frmCustomFormBase_Load(object sender, System.EventArgs e)
		{
			if(m_strPatientCardID != null && m_strPatientCardID != string.Empty)
			{
				m_txtPatientID.Text = m_strPatientCardID;
				m_mthSetOutPatientInfo();
			}
			m_mthSetCarryData();
			m_mthAddFormStatusForClosingSave();
			
			if(m_blnInitPatient && MDIParent.s_ObjCurrentPatient != null)
			{
				this.m_mthSetPatient(MDIParent.s_ObjCurrentPatient);
			}
		}
		private void m_mthSetCarryData()
		{
			if(m_frmMain != null)
			{
				CustomForm.clsCustomSyncField[] objFields = m_objConfigXmlTool.m_objConfigSyncXmlToSyncField(m_objDomain.m_strGetSouSyncConfig(m_objSubmitValues.m_intFormID,m_frmMain.Name));
				if(objFields == null)
					return;
				for(int i=0;i<objFields.Length;i++)
				{
					try
					{
						Type type = m_frmMain.GetType();
						System.Reflection.PropertyInfo pi = type.GetProperty(objFields[i].m_strControlID);
						object obj = pi.GetValue(m_frmMain,null);
						m_mthSetDataToControl(obj,pi.DeclaringType.Name,objFields[i].m_strFieldID);
					}
					catch{continue;}
				}
			}
		}
		private void m_mthSetDataToControl(object p_objData,string p_strType,string p_strControlID)
		{
			Control ctl = m_ctlFoundControl(p_strControlID);
			if(ctl != null)
			{
				switch(ctl.GetType().Name)
				{
					case "ctlRichTextBox":
						try
						{
							((ctlRichTextBox)ctl).Text = Convert.ToString(p_objData);
						}
						catch{}
						break;
					case "ctlCheckBox":
						try
						{
							((ctlCheckBox)ctl).Checked = Convert.ToBoolean(p_objData);
						}
						catch{}
						break;
					case "ctlComboBox":
						try
						{
							((ctlComboBox)ctl).Text = Convert.ToString(p_objData);
						}
						catch{}
						break;
					case "ctlDateTimePicker":
						try
						{
							((ctlDateTimePicker)ctl).Value = Convert.ToDateTime(p_objData);
						}
						catch{}
						break;
					default :
						break;
				}
			}
		}
		private Control m_ctlFoundControl(string p_strControlID)
		{
			foreach(TabPage page in m_tabContainer.TabPages)
			{
				for(int i=0;i<page.Controls.Count;i++)
				{
					if(page.Controls[i].Name == p_strControlID)
						return page.Controls[i];
				}
			}
			return null;
		}

		/// <summary>
		/// 构造函数之后的初始化
		/// </summary>
		private void m_mthInit(clsCustom_SubmitValue p_objFormFormat)
		{
			m_intForm_ID = p_objFormFormat.m_intFormID;
			m_objConfigXmlTool = new clsConfigXmlTool();
			m_objDomain = new clsCustomFormDomain();

			m_objSubmitValues = p_objFormFormat;
			this.Text = m_objSubmitValues.m_strFormName;
			for(int i=0;i<m_objSubmitValues.m_objPagesArr.Length;i++)
			{
				TabPage tbp = new TabPage("第"+m_objSubmitValues.m_objPagesArr[i].m_intPages.ToString().Trim()+"页");
				tbp.BorderStyle = BorderStyle.FixedSingle;
				m_tabContainer.TabPages.Add(tbp);
				m_objConfigXmlTool.m_mthConfigXmlToGUI(m_objSubmitValues.m_objPagesArr[i].m_strConfiguration,tbp);
			}		
			m_cboAllRecordTime.AddItem("新添");

            this.Name = m_strGetCurFormName();
		}
		private void m_mthInitInOROutpatient()
		{
			if(m_intInOROutPatientStatus == 0)
			{
				m_mthSetVisible(true);
				return;
			}
			m_objCurEmpDeptArr = clsEMRLogin.m_ObjCurDeptOfEmpArr;
			if(m_objCurEmpDeptArr == null)
				return;
			bool blnIsOneType = true;
			for(int i=0;i<m_objCurEmpDeptArr.Length-1;i++)
			{
				if(m_objCurEmpDeptArr[i].intInPatientOrOutPatient != m_objCurEmpDeptArr[i+1].intInPatientOrOutPatient)
					blnIsOneType = false;
			}
			if(blnIsOneType)
			{
				if(m_objCurEmpDeptArr[0].intInPatientOrOutPatient == 0)
				{
					m_mthSetVisible(true);
				}
				else if(m_objCurEmpDeptArr[0].intInPatientOrOutPatient == 1)
				{
					m_mthSetVisible(false);
				}
				m_intInOROutPatientStatus = m_objCurEmpDeptArr[0].intInPatientOrOutPatient;
			}
			else
			{
				using(frmSelectDeptType frmSelect = new frmSelectDeptType())
				{
					if(frmSelect.ShowDialog() == DialogResult.OK)
						m_intInOROutPatientStatus = frmSelect.m_IntInOROutType;
				}
				if(m_intInOROutPatientStatus == 0)
					m_mthSetVisible(true);
				else if(m_intInOROutPatientStatus == 1)
					m_mthSetVisible(false);
			}
		}
		private void m_mthSetVisible(bool p_blnVisible)
		{
			mniTools.Visible = !p_blnVisible;
//			m_BlnNeedContextMenu = !p_blnVisible;
			pnlCard.Visible = p_blnVisible;
			m_blnIsInPatient = !p_blnVisible;
			pnlRecordDate.Location = (p_blnVisible?m_potOutPatientLocation:m_potInPatientLocation);
			if(p_blnVisible)
				pnlRecordDate.BringToFront();
		}
		

		protected override bool m_BlnIsAddNew
		{
			get
			{
				return m_cboAllRecordTime.SelectedIndex == 0;
			}
		}

		protected override void m_mthSetPatientFormInfo(clsPatient p_objSelectedPatient)
		{
			if(!m_blnIsInPatient)
				return;
			m_mthClear();
			m_mthLoadAllRecordContents();

			m_cboAllRecordTime.SelectedIndex = 0;//默认是新添
		}

		/// <summary>
		/// 查出所有记录内容(门诊用)
		/// </summary>
		private void m_mthLoadAllPatientRecordContents()
		{
			clsCustom_Data[] objDataArr = null;
			long lngRes = m_objDomain.m_lngGetRecByPatientID(m_strPatientID,c_strFormBaseName + m_intForm_ID.ToString(),out objDataArr);

			m_mthClearAllRecordTime();
			if(lngRes <= 0 || objDataArr == null || objDataArr.Length == 0)
				return;

			m_cboAllRecordTime.AddRangeItems(objDataArr);
		}
		
		/// <summary>
		/// 查出所有记录内容(住院用)
		/// </summary>
		private void m_mthLoadAllRecordContents()
		{
			clsCustom_Data[] objDataArr = null;
			long lngRes = m_objDomain.m_lngGetRecByInPatientInfo(m_objBaseCurrentPatient.m_StrInPatientID,m_objBaseCurrentPatient.m_DtmSelectedInDate,c_strFormBaseName + m_intForm_ID.ToString(),out objDataArr);

			m_mthClearAllRecordTime();
			if(lngRes <= 0 || objDataArr == null || objDataArr.Length == 0)
				return;
			m_cboAllRecordTime.AddRangeItems(objDataArr);
		}
		private void m_mthClearAllRecordTime()
		{
			m_cboAllRecordTime.ClearItem();
			m_cboAllRecordTime.AddItem("新添");
			m_cboAllRecordTime.SelectedIndex = 0;
		}

		private void m_cboAllRecordTime_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_mthClear();
			if(m_cboAllRecordTime.SelectedIndex == 0)
			{
				if(m_blnIsInPatient)
					m_mthSetDefaultValue(m_objBaseCurrentPatient);
				//当前处于新添记录状态
				MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.AddNew );
				m_mthAddFormStatusForClosingSave();
				return;
			}

			string strContentXml = ((clsCustom_Data)m_cboAllRecordTime.SelectedItem).m_strContent;
			m_objConfigXmlTool.m_mthReadRecoedFromXML(strContentXml,m_tabContainer);

			m_dtpCreateDate.Value = ((clsCustom_Data)m_cboAllRecordTime.SelectedItem).m_dtmCreateDate;
			m_dtpCreateDate.Enabled = false;

			//当前处于修改记录状态
			MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.Modify);
			m_mthAddFormStatusForClosingSave();
		}

		private void m_mthClear()
		{
			m_dtpCreateDate.Value = DateTime.Now;
			m_dtpCreateDate.Enabled = true;

			foreach(TabPage page in m_tabContainer.TabPages)
			{
				m_objConfigXmlTool.m_mthClearRecordContent(page);
			}
		}

		
		#region 新添、读取、修改、删除、打印
		/// <summary>
		/// 新添记录
		/// </summary>
		/// <returns></returns>
		protected override long m_lngSubAddNew()
		{
			long lngRes = 0;
			if(m_blnIsInPatient)
				lngRes = m_lngAddInPatientRecord();
			else
				lngRes = m_lngAddPatientRecord();
			if(lngRes > 0)
			{
				m_dtpCreateDate.Enabled = false;
			}
			return lngRes;
		}
		/// <summary>
		/// 住院病人提交记录
		/// </summary>
		/// <returns></returns>
		private long m_lngAddInPatientRecord()
		{
			if(m_objBaseCurrentPatient == null)
			{
				clsPublicFunction.ShowInformationMessageBox("请先选择病人！");
				return 0;
			}
			long lngRes = 0;
			clsCustom_Data objRecord = new clsCustom_Data();
			objRecord.m_intForm_ID = m_intForm_ID;
			objRecord.m_strAppForm_ID = c_strFormBaseName + m_intForm_ID.ToString();
			objRecord.m_strInPatientID = m_objBaseCurrentPatient.m_StrInPatientID;
            objRecord.m_strRegisterId = m_objBaseCurrentPatient.m_StrRegisterId;
			objRecord.m_dtmInPatientDate = m_objBaseCurrentPatient.m_DtmSelectedInDate;
			objRecord.m_strCreateUserID = MDIParent.strOperatorID;
			objRecord.m_dtmOpenDate = new clsPublicDomain().m_dtmGetServerTime();
			objRecord.m_dtmCreateDate = m_dtpCreateDate.Value;
			objRecord.m_strContent = m_objConfigXmlTool.m_strSaveRecoedToXML(m_tabContainer);
			lngRes = m_objDomain.m_lngAddNewRecord(ref objRecord);
			if(lngRes > 0)
			{
				m_mthInsertItem(objRecord);
				clsPublicFunction.ShowInformationMessageBox("保存成功!");
			}
			else
				clsPublicFunction.ShowInformationMessageBox("保存失败!");
			return lngRes;
		}
		/// <summary>
		/// 门诊病人提交记录
		/// </summary>
		/// <returns></returns>
		private long m_lngAddPatientRecord()
		{
			if(m_strPatientID == string.Empty)
			{
				clsPublicFunction.ShowInformationMessageBox("请先输入正确的病人卡号!");
				return 0;
			}
			
			long lngRes = 0;
			clsCustom_Data objRecord = new clsCustom_Data();
			objRecord.m_intForm_ID = m_intForm_ID;
			objRecord.m_strAppForm_ID = c_strFormBaseName + m_intForm_ID.ToString();
			objRecord.m_strPatientID = m_strPatientID;
			objRecord.m_strPatientCardID = m_strPatientCardID;
				objRecord.m_strCreateUserID = MDIParent.strOperatorID;
			objRecord.m_dtmCreateDate = m_dtpCreateDate.Value;
			objRecord.m_strContent = m_objConfigXmlTool.m_strSaveRecoedToXML(m_tabContainer);
			lngRes = m_objDomain.m_lngAddNewRecord(ref objRecord);
			if(lngRes > 0)
			{
				clsPublicFunction.ShowInformationMessageBox("保存成功!");
				m_mthInsertItem(objRecord);
			}
			else
				clsPublicFunction.ShowInformationMessageBox("保存失败!");
			return lngRes;
		}

		/// <summary>
		/// 修改记录
		/// </summary>
		/// <returns></returns>
		protected override long m_lngSubModify()
		{
			clsCustom_Data objRecord = m_cboAllRecordTime.SelectedItem as clsCustom_Data;
			if(objRecord == null)
				return 0;
			long lngRes = 0;
				objRecord.m_strContent = m_objConfigXmlTool.m_strSaveRecoedToXML(m_tabContainer);
				objRecord.m_dtmOpenDate = new clsPublicDomain().m_dtmGetServerTime();
				lngRes = m_objDomain.m_lngModifyRecord(objRecord);			
				if(lngRes <= 0)
				{
					clsPublicFunction.ShowInformationMessageBox("修改失败!");
					return lngRes;
				}

				((clsCustom_Data)m_cboAllRecordTime.SelectedItem).m_strContent = objRecord.m_strContent;

			clsPublicFunction.ShowInformationMessageBox("修改成功!");
			return lngRes;
		}

		/// <summary>
		/// 删除记录
		/// </summary>
		/// <returns></returns>
		protected override long m_lngSubDelete()
		{
			if(m_cboAllRecordTime.SelectedIndex <= 0)
			{
				clsPublicFunction.ShowInformationMessageBox("请先选择记录！");
				return -1;
			}
			clsCustom_Data objData = m_cboAllRecordTime.SelectedItem as clsCustom_Data;
			if(objData == null)
				return -1;
			long lngRes = m_objDomain.m_lngDeleteRecord(objData.m_intRecord_ID,MDIParent.strOperatorID);			
			if(lngRes <= 0)
				return lngRes;

			m_cboAllRecordTime.SelectedIndex--;
			m_cboAllRecordTime.RemoveItem(objData);
			m_mthClear();

			return lngRes;
		}

		/// <summary>
		/// 打印
		/// </summary>
		/// <returns></returns>
		protected override long m_lngSubPrint()
		{
			if(m_blnDirectPrint)
			{
				m_pdcPrintDocument.Print();
			}
			else
			{
				PrintTool.frmPrintPreviewDialog ppdPrintPreview = new PrintTool.frmPrintPreviewDialog();
				ppdPrintPreview.Document = m_pdcPrintDocument;
				ppdPrintPreview.ShowDialog();
			}

			return 1;
		}

		/// <summary>
		/// 打印页
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void m_pdcPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			for(;m_intIndex< m_tabContainer.TabCount;)
			{
				new clsGUIPrintTool().m_mthPrintPage(m_tabContainer.TabPages[m_intIndex],e.Graphics);
				m_intIndex++;
				if(m_intIndex == m_tabContainer.TabCount)
					break;
				e.HasMorePages = true;
				return;
			}
			e.HasMorePages = false;
			m_intIndex = 0;
		}
		#endregion

		/// <summary>
		/// 在适当位置插入项目
		/// </summary>
		/// <param name="p_objRecord"></param>
		private void m_mthInsertItem(clsCustom_Data p_objRecord)
		{
			int i = 1;//从新建后的第一条开始比较
			for(;i < m_cboAllRecordTime.GetItemsCount(); i++)
			{
				DateTime dtmItem = ((clsCustom_Data)m_cboAllRecordTime.GetItem(i)).m_dtmCreateDate;
				if(p_objRecord.m_dtmCreateDate.CompareTo(dtmItem) > 0)
					break;
			}
            m_cboAllRecordTime.InsertItem(i,p_objRecord);
			m_cboAllRecordTime.SelectedItem = p_objRecord;
		}

		protected override string m_StrCurrentOpenDate
		{
			get
			{
				if(m_cboAllRecordTime.SelectedIndex == 0)
				{
//					clsPublicFunction.ShowInformationMessageBox("请先选择记录！");
					return "";
				}
				return ((clsCustom_Data)m_cboAllRecordTime.SelectedItem).m_dtmOpenDate.ToString("yyyy年MM月dd日 HH:mm:ss");
			}
		}

		/// <summary>
		/// 获取当前自定义表单名称，因为每个自定义表单都是用这个窗体，
		/// 所以在窗体名后加上FormID，以此作为唯一标识
		/// </summary>
		/// <returns></returns>
		public string m_strGetCurFormName()
		{
			return c_strFormBaseName + m_objSubmitValues.m_intFormID.ToString();
		}

		/// <summary>
		/// 设置各种类型的默认值
		/// </summary>
		/// <param name="p_objPatient"></param>
		private void m_mthSetDefaultValue(clsPatient p_objPatient)
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
                new iCare.CustomForm.clsDefaultValueTool(m_grbEditorArea, m_strGetCurFormName(), "GZ0000001").m_mthSetDefaultValue(p_objPatient);
			}
			catch
			{this.Cursor = Cursors.Default;}
			this.Cursor = Cursors.Default;

			//自动调用关联的模板
//			m_mthSetSpecialPatientTemplateSet(p_objPatient);
//			m_mthSetSpecialPatientTemplateSet(p_objPatient,enmAssociate.Operation);			
		}

		#region 下拉框事件
		/// <summary>
		/// 绑定下拉框的项目事件
		/// </summary>
		/// <param name="p_ctlParent"></param>
		protected override void m_mthAssociateComboBoxItemEvent(Control p_ctlParent)
		{
			foreach(Control ctlChild in m_tabContainer.Controls)
			{
				m_mthAssociateItemEvent(ctlChild);
			}
		}
		private void m_mthAssociateItemEvent(Control p_ctlParent)
		{
			iCare.CustomForm.ctlComboBox cbo = p_ctlParent as iCare.CustomForm.ctlComboBox;
			if(cbo != null)
			{
				cbo.DropDown += new System.EventHandler(m_mthComboBox_DropDown);
				cbo.evtAddItem += new System.EventHandler(m_mthComboBox_Additem);
				cbo.evtModifyItem += new System.EventHandler(m_mthComboBox_Modifyitem);
				cbo.evtDelItem += new System.EventHandler(m_mthComboBox_Deleteitem);
			}
			else if(p_ctlParent.HasChildren)
			{
				foreach(Control ctlChild in p_ctlParent.Controls)
				{
					m_mthAssociateItemEvent(ctlChild);
				}
			}
		}

		/// <summary>
		/// 添加项目
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void m_mthComboBox_Additem(object sender,System.EventArgs e)
		{
			iCare.CustomForm.ctlComboBox cbo = ((MenuItem)sender).GetContextMenu().SourceControl as iCare.CustomForm.ctlComboBox;
			if(cbo == null)
				return;
			if(cbo.Text == "")
				return;
			clsComboBoxValue objValue = new clsComboBoxValue();
			objValue.m_strDeptID = MDIParent.s_ObjDepartment.m_StrDeptID;
			objValue.m_strTypeID = m_strGetCurFormName();
			objValue.m_strItemID = cbo.Name;
			objValue.m_strItemContent = cbo.Text;
			long lngRef = new clsComboBoxDomainOld().m_lngAddItemToDB(objValue);
			if(lngRef < 1)
				return;
			cbo.Items.Insert(0,objValue.m_strItemContent);
			cbo.SelectedIndex = 0;
			
		}

		/// <summary>
		/// 修改项目
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void m_mthComboBox_Modifyitem(object sender,System.EventArgs e)
		{
			iCare.CustomForm.ctlComboBox cbo = ((MenuItem)sender).GetContextMenu().SourceControl as iCare.CustomForm.ctlComboBox;
			if(cbo == null)
				return;
			if(cbo.Text == "" || cbo.SelectedItem == null)
				return;
			clsComboBoxValue objValue;
			objValue = new clsComboBoxValue();
			objValue.m_strDeptID = MDIParent.s_ObjDepartment.m_StrDeptID;
			objValue.m_strTypeID = m_strGetCurFormName();
			objValue.m_strItemID = cbo.Name;
			objValue.m_strItemContent = cbo.SelectedItem.ToString();
			long lngRef = new clsComboBoxDomainOld().m_lngModifyItem(objValue,cbo.Text);
			if(lngRef < 1)
				return;
			string strText = cbo.Text;
			cbo.Items.Remove(cbo.SelectedItem);
			cbo.Update();
			cbo.Items.Insert(0,strText);
			cbo.SelectedIndex = 0;
		}

		/// <summary>
		/// 删除项目
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void m_mthComboBox_Deleteitem(object sender,System.EventArgs e)
		{
			iCare.CustomForm.ctlComboBox cbo = ((MenuItem)sender).GetContextMenu().SourceControl as iCare.CustomForm.ctlComboBox;
			if(cbo == null)
				return;
			if(cbo.Text == "" || cbo.SelectedItem == null)
				return;
			clsComboBoxValue objValue;
			objValue = new clsComboBoxValue();
			objValue.m_strDeptID = MDIParent.s_ObjDepartment.m_StrDeptID;
			objValue.m_strTypeID = m_strGetCurFormName();
			objValue.m_strItemID = cbo.Name;
			objValue.m_strItemContent = cbo.SelectedItem.ToString();
			long lngRef = new clsComboBoxDomainOld().m_lngDeleteItem(objValue);
			if(lngRef < 1)
				return;
			cbo.Items.Remove(cbo.SelectedItem);
			cbo.Update();
		}

		/// <summary>
		/// 设置下拉项目
		/// </summary>
		/// <param name="p_cboSender"></param>
		private void m_mthSetComboBoxListItem(ctlComboBox p_cboSender)
		{
			if(p_cboSender == null)
				return;
			clsComboBoxValue[] objValueArr = null;
			new clsComboBoxDomainOld().m_lngGetAllItem(MDIParent.s_ObjDepartment.m_StrDeptID,m_strGetCurFormName(),p_cboSender.Name,out objValueArr);
			if(objValueArr == null)
				return;
			
			p_cboSender.Items.Clear();
			for(int i=0; i<objValueArr.Length; i++)
			{
				if(objValueArr[i].m_strItemContent != null && objValueArr[i].m_strItemContent != string.Empty)
					p_cboSender.Items.Add(objValueArr[i].m_strItemContent);
			}
		}

		private void m_mthComboBox_DropDown(object sender,System.EventArgs e)
		{
			m_mthSetComboBoxListItem((iCare.CustomForm.ctlComboBox)sender);
		}
		#endregion

		private void m_txtPatientID_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(m_txtPatientID.Text.Trim() == string.Empty)
				return;
			if(e.KeyCode == Keys.Enter)
			{
				m_mthSetOutPatientInfo();
			}
			m_mthAddFormStatusForClosingSave();
		}
		private void m_mthSetOutPatientInfo()
		{
			clsPatientInfo_Value objInfo = null;
			new clsForWholeHosInfoManager().m_mthGetPatientByCardID(m_txtPatientID.Text.Trim(),out objInfo);
			if(objInfo != null)
			{
				m_strPatientID = objInfo.m_StrPatientID;
				m_strPatientCardID = objInfo.m_StrPatientCardID;
				m_txtPatientName2.Text = objInfo.m_ObjPeopleInfo.m_StrFirstName;
				m_lblAge.Text = objInfo.m_ObjPeopleInfo.m_StrAge;
				m_lblSex.Text = objInfo.m_ObjPeopleInfo.m_StrSex;
			}
			else
			{
				clsPublicFunction.ShowInformationMessageBox("没有此病人!");
				m_strPatientID = string.Empty;
				m_strPatientCardID = string.Empty;
			}
			m_cboAllRecordTime.SelectedIndex = 0;
			m_mthLoadAllPatientRecordContents();
		}

		#region MenuClickEvent
		private void menuItem10_Click(object sender, System.EventArgs e)
		{
			if(m_cboAllRecordTime.SelectedIndex < 0)
				return;
			if(m_cboAllRecordTime.SelectedIndex == 0)
				m_lngSubAddNew();
			else
				m_lngSubModify();
		}

		private void mniPrintPre_Click(object sender, System.EventArgs e)
		{
			m_BlnDirectPrint = false;
			m_lngSubPrint();
		}

		private void mniPrint_Click(object sender, System.EventArgs e)
		{
			m_BlnDirectPrint = true;
			m_lngSubPrint();
		}

		private void mniExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void mniUndo_Click(object sender, System.EventArgs e)
		{
		
		}

		private void mniCut_Click(object sender, System.EventArgs e)
		{
			m_lngCut();
		}

		private void mniCopy_Click(object sender, System.EventArgs e)
		{
			m_lngCopy();
		}

		private void mniPaste_Click(object sender, System.EventArgs e)
		{
			m_lngPaste();
		}

		private void mniDelete_Click(object sender, System.EventArgs e)
		{
			
		}

		private void mniDelRec_Click(object sender, System.EventArgs e)
		{
			m_lngSubDelete();
		}

        /// <summary>
        /// 应用模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem1_Click(object sender, EventArgs e)
        {

            

                if (m_ObjTemplateClient != null && m_ObjCurrentEmrPatient != null)
                {
                    if (com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_ObjCurrentEmployee.m_strLEVEL_CHR.StartsWith("5"))//暂用此判断医生
                    {
                        m_ObjTemplateClient.m_mthUseTemplate(this.ActiveControl, m_ObjCurrentEmrPatient.m_strDEPTID_CHR);
                    }
                    else
                    {
                        m_ObjTemplateClient.m_mthUseTemplate(this.ActiveControl, m_ObjCurrentEmrPatient.m_strAREAID_CHR);
                    }
                }
            
        }

		private void menuItem17_Click(object sender, System.EventArgs e)
		{
			//m_mthSearchDeactiveInfo(); 
		}

		private void menuItem18_Click(object sender, System.EventArgs e)
		{
			m_mthNewTemplate(); 
		}

		private void menuItem20_Click(object sender, System.EventArgs e)
		{
			m_mthNewCommonUse(); 
		}

		private void menuItem21_Click(object sender, System.EventArgs e)
		{
			iCare.CustomForm.clsDefaultValueTool objTool = new iCare.CustomForm.clsDefaultValueTool(m_grbEditorArea,m_strGetCurFormName(),"GZ0000001");	

			if(objTool != null)
			{
				if(clsPublicFunction.ShowQuestionMessageBox(this,"注意！保存默认值后将会覆盖原来的默认值，这样可能会引起数据混乱，在未确定您所输入的默认值是否为正常的默认值时，请不要随便保存，是否继续？") == DialogResult.Yes)
					objTool.m_mthSaveDefaultValue();
			}
		}

		private void menuItem22_Click(object sender, System.EventArgs e)
		{
			iCare.CustomForm.clsDefaultValueTool objTool = new iCare.CustomForm.clsDefaultValueTool(m_grbEditorArea,m_strGetCurFormName(),"GZ0000001");

			if(objTool != null)
			{
				if(clsPublicFunction.ShowQuestionMessageBox(this,"是否重置默认值？") == DialogResult.Yes)
				{
					objTool.m_BlnReplaceDataShare = false;
					objTool.m_mthSetDefaultValue();
				}
			}
		}

        /// <summary>
        /// 窗体元素关联
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem4_Click(object sender, EventArgs e)
        {
            clsInpatMedRec_Type objType = new clsInpatMedRec_Type();
            objType.m_strTypeID = m_strGetCurFormName();
            objType.m_strTypeName = m_objSubmitValues.m_strFormName;

            List<clsInpatMedRec_Type_Item> objItems = new List<clsInpatMedRec_Type_Item>();
            m_mthRecursionGetFormElement(m_tabContainer, ref objItems);

            if (objItems.Count > 0)
            {
                com.digitalwave.Emr.ConfigService.clsInitFormElementService objServ =
                    (com.digitalwave.Emr.ConfigService.clsInitFormElementService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.Emr.ConfigService.clsInitFormElementService));

                long lngRes = objServ.m_lngSaveFormElement(null, objType, objItems.ToArray());
                objServ = null;
                if (lngRes > 0)
                {
                    clsEmrFormInfo_VO objFormVO = new clsEmrFormInfo_VO();
                    objFormVO.m_IntFormState = 5;
                    objFormVO.m_IntIsDeactive = 0;
                    objFormVO.m_IntPrintState = 0;
                    objFormVO.m_StrDLLName = "CustomForm.dll";
                    objFormVO.m_StrFormClassName = m_strGetCurFormName();
                    objFormVO.m_StrFormDesc = m_objSubmitValues.m_strFormName;
                    objFormVO.m_StrFormnameSpace = "iCare.CustomForm";
                    objFormVO.m_StrIsSubForm = "0";
                    objFormVO.m_StrSignFlag = "1";
                    objFormVO.m_StrUsageFlag = "0";

                    com.digitalwave.Emr.ConfigService.clsConfigService objServCon =
                    (com.digitalwave.Emr.ConfigService.clsConfigService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.Emr.ConfigService.clsConfigService));
                    lngRes = objServCon.m_lngAddFormInfo_CustomForm(objFormVO);
                    MessageBox.Show("关联成功");
                }
                else
                {
                    MessageBox.Show("关联失败");
                }
            }
        }

		#endregion
        private void m_mthRecursionGetFormElement(Control p_ctlContent, ref List<clsInpatMedRec_Type_Item> p_objItems)
        {
            if (!p_ctlContent.HasChildren || p_ctlContent is com.digitalwave.Controls.ICustomValueControl || p_ctlContent.GetType().Name == "ctlComboBox")
            {
                if (!string.IsNullOrEmpty(p_ctlContent.AccessibleDescription))
                {
                    clsInpatMedRec_Type_Item item = new clsInpatMedRec_Type_Item();
                    item.m_strItemID = p_ctlContent.Name;
                    item.m_strItemName = p_ctlContent.AccessibleDescription;
                    item.m_strItemType = p_ctlContent.GetType().Name;
                    item.m_strIndex = p_ctlContent.TabIndex.ToString();
                    if (p_ctlContent is com.digitalwave.Controls.ICustomValueControl<string> || !(p_ctlContent is com.digitalwave.Controls.ICustomValueControl))
                        item.m_blnCanTemplate = true;
                    p_objItems.Add(item);

                }
            }
            else
            {
                for (int i = 0; i < p_ctlContent.Controls.Count; i++)
                {
                    m_mthRecursionGetFormElement(p_ctlContent.Controls[i], ref p_objItems);
                }
            }
        }

	}
}

