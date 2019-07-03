using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using com.digitalwave.Utility.SQLConvert;
using System.Windows.Forms;
using com.digitalwave.Utility.Controls;
using iCareData;
using iCare.ICU.Evaluation;

namespace iCare
{
	public class frmRecordSearch : iCare.frmHRPBaseForm
	{
		#region Define
		internal com.digitalwave.Utility.Controls.ctlComboBox m_cboFormList;
		private System.Windows.Forms.Label label1;
		internal com.digitalwave.Utility.Controls.ctlComboBox m_cboFieldList;
		private System.Windows.Forms.GroupBox grbSearchCondition;
		internal System.Windows.Forms.Panel m_pnlNone;
		internal System.Windows.Forms.Panel m_pnlDate;
		internal com.digitalwave.Utility.Controls.ctlTimePicker m_dtpFirst;
		internal com.digitalwave.Utility.Controls.ctlTimePicker m_dtpSecond;
		internal System.Windows.Forms.Panel m_pnlNumber;
		internal System.Windows.Forms.Panel m_pnlTrueFalse;
		internal System.Windows.Forms.RadioButton m_rdbTrueFalseFalse;
		internal System.Windows.Forms.RadioButton m_rdbTrueFalseTrue;
		internal System.Windows.Forms.ListBox m_lstConditionList;
		internal System.Windows.Forms.Panel m_pnlLongText;
		internal com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtLongTextContent;
		private PinkieControls.ButtonXP m_cmdAddCondition;
		private PinkieControls.ButtonXP m_cmdSearch;
		internal System.Windows.Forms.Label m_lblInfo;
		internal com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtNumberFrom;
		internal System.Windows.Forms.Label m_lblNumberFrom;
		internal System.Windows.Forms.Label m_lblNumberTo;
		internal com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtNumberTo;
		internal System.Windows.Forms.Label m_lblDateFrom;
		internal System.Windows.Forms.Label m_lblDateTo;
		internal com.digitalwave.Utility.Controls.ctlComboBox m_cboNumberConditionType;
		internal System.Windows.Forms.Label lblNumberConditionType;
		internal com.digitalwave.Utility.Controls.ctlComboBox m_cboLongTextConditionType;
		internal System.Windows.Forms.Label lblLongTextConditionType;
		internal com.digitalwave.Utility.Controls.ctlComboBox m_cboDateConditionType;
		internal System.Windows.Forms.Label lblDateConditionType;
		private System.Windows.Forms.ContextMenu m_ctmConditionList;
		private System.Windows.Forms.MenuItem m_mniDeleteCondition;
		private System.Windows.Forms.MenuItem m_mniModifyCondition;
		private System.Windows.Forms.MenuItem m_mniClearCondition;
		private PinkieControls.ButtonXP m_cmdClearResult;
		private PinkieControls.ButtonXP m_cmdClearCondition;
		private System.Windows.Forms.ListView m_lsvPatientList;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		internal com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtPatientInfo;
		private System.Windows.Forms.Label m_lblPatientCount;
		private System.Windows.Forms.Label m_lblPatientTimesCount;
		private System.Windows.Forms.ContextMenu m_ctmExplorer;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.MenuItem menuItem14;
		private System.Windows.Forms.MenuItem menuItem15;
		private System.Windows.Forms.MenuItem menuItem16;
		private System.Windows.Forms.MenuItem menuItem17;
		private System.Windows.Forms.MenuItem menuItem18;
		private System.Windows.Forms.MenuItem menuItem19;
		private System.Windows.Forms.MenuItem menuItem20;
		private System.Windows.Forms.MenuItem menuItem21;
		private System.Windows.Forms.MenuItem menuItem22;
		private System.Windows.Forms.MenuItem menuItem23;
		private System.Windows.Forms.MenuItem menuItem24;
		private System.Windows.Forms.MenuItem menuItem25;
		private System.Windows.Forms.MenuItem menuItem26;
		private System.Windows.Forms.MenuItem mniLabAnalysisOrder;
		private System.Windows.Forms.MenuItem mniLabCheckReport;
		private System.Windows.Forms.MenuItem mniImageReport;
		private System.Windows.Forms.MenuItem mniImageBookingSearch;
		private System.Windows.Forms.MenuItem menuItem27;
		private System.Windows.Forms.MenuItem menuItem28;
		private System.Windows.Forms.MenuItem menuItem29;
		private System.Windows.Forms.MenuItem menuItem30;
		private System.Windows.Forms.MenuItem menuItem31;
		private System.Windows.Forms.MenuItem menuItem32;
		private System.Windows.Forms.MenuItem menuItem33;
		private System.Windows.Forms.MenuItem menuItem34;
		private System.Windows.Forms.MenuItem menuItem35;
		private System.Windows.Forms.MenuItem mniDirectionAnalisys;
		private System.Windows.Forms.MenuItem menuItem36;
		private System.Windows.Forms.MenuItem menuItem37;
		private System.Windows.Forms.MenuItem mniPatientInfoManage;
		private System.Windows.Forms.MenuItem menuItem38;
		private System.Windows.Forms.MenuItem menuItem39;
		private System.Windows.Forms.MenuItem menuItem40;
		private System.Windows.Forms.MenuItem menuItem41;
		private System.Windows.Forms.MenuItem menuItem42;
		private System.Windows.Forms.MenuItem menuItem43;
		private System.Windows.Forms.MenuItem mniICUTendRecord;
		private System.Windows.Forms.MenuItem menuItem44;
		private System.Windows.Forms.MenuItem menuItem45;
		private System.Windows.Forms.MenuItem menuItem46;
		private System.Windows.Forms.MenuItem mniEKGOrder;
		private System.Windows.Forms.MenuItem mniNuclearOrder;
		private System.Windows.Forms.MenuItem mniPSGOrder;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.ImageList m_imlCondition;
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TreeView m_trvCondition;
		private System.Windows.Forms.TreeView m_tvwTemplate;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox m_txtTemplateValue;
		private PinkieControls.ButtonXP m_cmdAddTemplateCondition;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox m_txtTemplateName;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.MenuItem m_mnuInPatient;

		/// <summary>
		/// 判断是否在使用新专科病历
		/// </summary>
//		private bool m_blnIsNewCase = false;

		#endregion

		public frmRecordSearch()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
			
//			m_objBorderTool = new com.digitalwave.Utility.Controls.clsBorderTool(Color.White);
//			m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{
//																			 m_lstConditionList,m_lsvPatientList
//																		 });

			m_mthInitConditionMaker();
			m_mthShowConditionInput("None");

			m_mthInitSearchInfoBuilder();
			m_objSearchInfoBuilderBase = null;

			m_mthInitPatientDetailMaker();

			m_objRecordSearchDomain = new RecordSearch.clsRecordSearchDomain();

			m_mthAddSendTabEvent(this);

			m_mthInitContextMenu();
			new clsSortTool().m_mthSetListViewSortable(m_lsvPatientList);
		}
//		private clsBorderTool m_objBorderTool;

		private RecordSearch.ConditionMaker.clsConditionMakerBase m_objConditionBase = null;
		private Hashtable m_hasConditionMakers;

		private RecordSearch.SearchInfoBuilder.clsSearchInfoBuilderBase m_objSearchInfoBuilderBase = null;
		private Hashtable m_hasSearchInfoBuilders;

		private Hashtable m_hasPatientDetailMaker;

		private RecordSearch.clsRecordSearchDomain m_objRecordSearchDomain;
		
		#region 添加控件由Enter触发SendTab功能
		/// <summary>
		/// 添加控件由Enter触发SendTab功能
		/// </summary>
		/// <param name="p_ctlContain"></param>
		private void m_mthAddSendTabEvent(Control p_ctlContain)
		{
			foreach(Control ctlChild in p_ctlContain.Controls)
			{
				if(ctlChild.Controls.Count > 0)
				{
					if(ctlChild.GetType().FullName != "com.digitalwave.Utility.Controls.ctlTimePicker")
					m_mthAddSendTabEvent(ctlChild);
				}
				else
				{
					TextBox txtInput = ctlChild as TextBox;

					if(txtInput != null && !txtInput.Multiline)
					{
						txtInput.KeyDown += new KeyEventHandler(m_mthSendTabHandler);
					}
				}
			}
		}
		private void m_mthSendTabHandler(object p_objSender,KeyEventArgs p_objArg)
		{
			if(p_objArg.KeyCode == Keys.Enter)
			{
				SendKeys.Send("{TAB}");
			}
		}
		#endregion 添加控件由Enter触发SendTab功能

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecordSearch));
            this.m_cboFormList = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cboFieldList = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.grbSearchCondition = new System.Windows.Forms.GroupBox();
            this.m_cmdClearCondition = new PinkieControls.ButtonXP();
            this.m_cmdAddCondition = new PinkieControls.ButtonXP();
            this.m_pnlNone = new System.Windows.Forms.Panel();
            this.m_lblInfo = new System.Windows.Forms.Label();
            this.m_pnlTrueFalse = new System.Windows.Forms.Panel();
            this.m_rdbTrueFalseTrue = new System.Windows.Forms.RadioButton();
            this.m_rdbTrueFalseFalse = new System.Windows.Forms.RadioButton();
            this.m_pnlNumber = new System.Windows.Forms.Panel();
            this.m_txtNumberFrom = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_lblNumberFrom = new System.Windows.Forms.Label();
            this.m_lblNumberTo = new System.Windows.Forms.Label();
            this.m_txtNumberTo = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_cboNumberConditionType = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.lblNumberConditionType = new System.Windows.Forms.Label();
            this.m_pnlLongText = new System.Windows.Forms.Panel();
            this.m_cboLongTextConditionType = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.lblLongTextConditionType = new System.Windows.Forms.Label();
            this.m_txtLongTextContent = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_pnlDate = new System.Windows.Forms.Panel();
            this.m_dtpSecond = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.m_cboDateConditionType = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.lblDateConditionType = new System.Windows.Forms.Label();
            this.m_lblDateTo = new System.Windows.Forms.Label();
            this.m_dtpFirst = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.m_lblDateFrom = new System.Windows.Forms.Label();
            this.m_lstConditionList = new System.Windows.Forms.ListBox();
            this.m_ctmConditionList = new System.Windows.Forms.ContextMenu();
            this.m_mniModifyCondition = new System.Windows.Forms.MenuItem();
            this.m_mniDeleteCondition = new System.Windows.Forms.MenuItem();
            this.m_mniClearCondition = new System.Windows.Forms.MenuItem();
            this.m_trvCondition = new System.Windows.Forms.TreeView();
            this.m_txtTemplateName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_cmdAddTemplateCondition = new PinkieControls.ButtonXP();
            this.m_txtTemplateValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_tvwTemplate = new System.Windows.Forms.TreeView();
            this.m_cmdSearch = new PinkieControls.ButtonXP();
            this.m_cmdClearResult = new PinkieControls.ButtonXP();
            this.m_lsvPatientList = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.m_txtPatientInfo = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_lblPatientCount = new System.Windows.Forms.Label();
            this.m_lblPatientTimesCount = new System.Windows.Forms.Label();
            this.m_ctmExplorer = new System.Windows.Forms.ContextMenu();
            this.m_mnuInPatient = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.menuItem16 = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem38 = new System.Windows.Forms.MenuItem();
            this.menuItem39 = new System.Windows.Forms.MenuItem();
            this.menuItem40 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuItem14 = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.menuItem17 = new System.Windows.Forms.MenuItem();
            this.menuItem18 = new System.Windows.Forms.MenuItem();
            this.menuItem19 = new System.Windows.Forms.MenuItem();
            this.menuItem22 = new System.Windows.Forms.MenuItem();
            this.menuItem23 = new System.Windows.Forms.MenuItem();
            this.menuItem24 = new System.Windows.Forms.MenuItem();
            this.menuItem20 = new System.Windows.Forms.MenuItem();
            this.menuItem21 = new System.Windows.Forms.MenuItem();
            this.menuItem25 = new System.Windows.Forms.MenuItem();
            this.menuItem26 = new System.Windows.Forms.MenuItem();
            this.mniEKGOrder = new System.Windows.Forms.MenuItem();
            this.mniNuclearOrder = new System.Windows.Forms.MenuItem();
            this.mniPSGOrder = new System.Windows.Forms.MenuItem();
            this.mniLabAnalysisOrder = new System.Windows.Forms.MenuItem();
            this.mniLabCheckReport = new System.Windows.Forms.MenuItem();
            this.mniImageReport = new System.Windows.Forms.MenuItem();
            this.mniImageBookingSearch = new System.Windows.Forms.MenuItem();
            this.menuItem27 = new System.Windows.Forms.MenuItem();
            this.menuItem28 = new System.Windows.Forms.MenuItem();
            this.menuItem29 = new System.Windows.Forms.MenuItem();
            this.menuItem30 = new System.Windows.Forms.MenuItem();
            this.menuItem31 = new System.Windows.Forms.MenuItem();
            this.menuItem32 = new System.Windows.Forms.MenuItem();
            this.menuItem33 = new System.Windows.Forms.MenuItem();
            this.menuItem34 = new System.Windows.Forms.MenuItem();
            this.menuItem35 = new System.Windows.Forms.MenuItem();
            this.mniDirectionAnalisys = new System.Windows.Forms.MenuItem();
            this.menuItem36 = new System.Windows.Forms.MenuItem();
            this.menuItem37 = new System.Windows.Forms.MenuItem();
            this.mniPatientInfoManage = new System.Windows.Forms.MenuItem();
            this.menuItem41 = new System.Windows.Forms.MenuItem();
            this.menuItem42 = new System.Windows.Forms.MenuItem();
            this.menuItem43 = new System.Windows.Forms.MenuItem();
            this.mniICUTendRecord = new System.Windows.Forms.MenuItem();
            this.menuItem44 = new System.Windows.Forms.MenuItem();
            this.menuItem45 = new System.Windows.Forms.MenuItem();
            this.menuItem46 = new System.Windows.Forms.MenuItem();
            this.m_imlCondition = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grbSearchCondition.SuspendLayout();
            this.m_pnlNone.SuspendLayout();
            this.m_pnlTrueFalse.SuspendLayout();
            this.m_pnlNumber.SuspendLayout();
            this.m_pnlLongText.SuspendLayout();
            this.m_pnlDate.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(712, 8);
            this.lblSex.Size = new System.Drawing.Size(1, 1);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(696, 16);
            this.lblAge.Size = new System.Drawing.Size(1, 1);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.AutoSize = false;
            this.lblBedNoTitle.Location = new System.Drawing.Point(396, 4);
            this.lblBedNoTitle.Size = new System.Drawing.Size(1, 1);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.AutoSize = false;
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(388, 8);
            this.lblInHospitalNoTitle.Size = new System.Drawing.Size(1, 1);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.AutoSize = false;
            this.lblNameTitle.Location = new System.Drawing.Point(504, 8);
            this.lblNameTitle.Size = new System.Drawing.Size(1, 1);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.AutoSize = false;
            this.lblSexTitle.Location = new System.Drawing.Point(664, 8);
            this.lblSexTitle.Size = new System.Drawing.Size(1, 1);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.AutoSize = false;
            this.lblAgeTitle.Location = new System.Drawing.Point(640, 16);
            this.lblAgeTitle.Size = new System.Drawing.Size(1, 1);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.AutoSize = false;
            this.lblAreaTitle.Location = new System.Drawing.Point(400, 4);
            this.lblAreaTitle.Size = new System.Drawing.Size(1, 1);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(308, 44);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(588, 8);
            this.txtInPatientID.Size = new System.Drawing.Size(1, 23);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(468, 4);
            this.m_txtPatientName.Size = new System.Drawing.Size(1, 23);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(560, 8);
            this.m_txtBedNO.Size = new System.Drawing.Size(1, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(364, 8);
            this.m_cboArea.Size = new System.Drawing.Size(1, 23);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(544, 24);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(400, 24);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(364, 4);
            this.m_cboDept.Size = new System.Drawing.Size(1, 23);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.AutoSize = false;
            this.lblDept.Location = new System.Drawing.Point(392, 8);
            this.lblDept.Size = new System.Drawing.Size(1, 1);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(272, 36);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Location = new System.Drawing.Point(460, 8);
            this.m_cmdNext.Size = new System.Drawing.Size(1, 1);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(508, 12);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(600, 12);
            this.m_lblForTitle.Size = new System.Drawing.Size(1, 1);
            this.m_lblForTitle.Text = "记 录 查 询";
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(628, -31);
            // 
            // m_cboFormList
            // 
            this.m_cboFormList.BackColor = System.Drawing.SystemColors.Control;
            this.m_cboFormList.BorderColor = System.Drawing.Color.Black;
            this.m_cboFormList.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboFormList.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboFormList.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboFormList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboFormList.flatFont = new System.Drawing.Font("宋体", 10.5F);
            this.m_cboFormList.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_cboFormList.ForeColor = System.Drawing.Color.Black;
            this.m_cboFormList.ListBackColor = System.Drawing.SystemColors.Control;
            this.m_cboFormList.ListForeColor = System.Drawing.Color.Black;
            this.m_cboFormList.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
            this.m_cboFormList.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboFormList.Location = new System.Drawing.Point(84, 13);
            this.m_cboFormList.m_BlnEnableItemEventMenu = false;
            this.m_cboFormList.Name = "m_cboFormList";
            this.m_cboFormList.SelectedIndex = -1;
            this.m_cboFormList.SelectedItem = null;
            this.m_cboFormList.SelectionStart = 0;
            this.m_cboFormList.Size = new System.Drawing.Size(268, 23);
            this.m_cboFormList.TabIndex = 100;
            this.m_cboFormList.TextBackColor = System.Drawing.Color.White;
            this.m_cboFormList.TextForeColor = System.Drawing.Color.Black;
            this.m_cboFormList.SelectedIndexChanged += new System.EventHandler(this.m_cboFormList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 10000004;
            this.label1.Text = "病历表单:";
            // 
            // m_cboFieldList
            // 
            this.m_cboFieldList.BackColor = System.Drawing.SystemColors.Control;
            this.m_cboFieldList.BorderColor = System.Drawing.Color.Black;
            this.m_cboFieldList.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboFieldList.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboFieldList.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboFieldList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboFieldList.flatFont = new System.Drawing.Font("宋体", 10.5F);
            this.m_cboFieldList.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_cboFieldList.ForeColor = System.Drawing.Color.Black;
            this.m_cboFieldList.ListBackColor = System.Drawing.Color.White;
            this.m_cboFieldList.ListForeColor = System.Drawing.SystemColors.ControlText;
            this.m_cboFieldList.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
            this.m_cboFieldList.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboFieldList.Location = new System.Drawing.Point(8, 24);
            this.m_cboFieldList.m_BlnEnableItemEventMenu = false;
            this.m_cboFieldList.Name = "m_cboFieldList";
            this.m_cboFieldList.SelectedIndex = -1;
            this.m_cboFieldList.SelectedItem = null;
            this.m_cboFieldList.SelectionStart = 0;
            this.m_cboFieldList.Size = new System.Drawing.Size(256, 23);
            this.m_cboFieldList.TabIndex = 200;
            this.m_cboFieldList.TextBackColor = System.Drawing.Color.White;
            this.m_cboFieldList.TextForeColor = System.Drawing.Color.Black;
            this.m_cboFieldList.SelectedIndexChanged += new System.EventHandler(this.m_cboFieldList_SelectedIndexChanged);
            this.m_cboFieldList.DropDown += new System.EventHandler(this.m_cboFieldList_DropDown);
            // 
            // grbSearchCondition
            // 
            this.grbSearchCondition.Controls.Add(this.m_cmdClearCondition);
            this.grbSearchCondition.Controls.Add(this.m_cmdAddCondition);
            this.grbSearchCondition.Controls.Add(this.m_cboFieldList);
            this.grbSearchCondition.Controls.Add(this.m_pnlNone);
            this.grbSearchCondition.Controls.Add(this.m_pnlTrueFalse);
            this.grbSearchCondition.Controls.Add(this.m_pnlNumber);
            this.grbSearchCondition.Controls.Add(this.m_pnlLongText);
            this.grbSearchCondition.Controls.Add(this.m_pnlDate);
            this.grbSearchCondition.Controls.Add(this.m_lstConditionList);
            this.grbSearchCondition.Controls.Add(this.m_trvCondition);
            this.grbSearchCondition.Font = new System.Drawing.Font("宋体", 10.5F);
            this.grbSearchCondition.Location = new System.Drawing.Point(8, 48);
            this.grbSearchCondition.Name = "grbSearchCondition";
            this.grbSearchCondition.Size = new System.Drawing.Size(272, 536);
            this.grbSearchCondition.TabIndex = 190;
            this.grbSearchCondition.TabStop = false;
            this.grbSearchCondition.Text = "查询条件";
            // 
            // m_cmdClearCondition
            // 
            this.m_cmdClearCondition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdClearCondition.DefaultScheme = true;
            this.m_cmdClearCondition.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdClearCondition.Hint = "";
            this.m_cmdClearCondition.Location = new System.Drawing.Point(148, 160);
            this.m_cmdClearCondition.Name = "m_cmdClearCondition";
            this.m_cmdClearCondition.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClearCondition.Size = new System.Drawing.Size(84, 32);
            this.m_cmdClearCondition.TabIndex = 1001;
            this.m_cmdClearCondition.Text = "清空条件";
            this.m_cmdClearCondition.Click += new System.EventHandler(this.m_cmdClearCondition_Click);
            // 
            // m_cmdAddCondition
            // 
            this.m_cmdAddCondition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdAddCondition.DefaultScheme = true;
            this.m_cmdAddCondition.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAddCondition.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_cmdAddCondition.Hint = "";
            this.m_cmdAddCondition.Location = new System.Drawing.Point(28, 160);
            this.m_cmdAddCondition.Name = "m_cmdAddCondition";
            this.m_cmdAddCondition.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAddCondition.Size = new System.Drawing.Size(84, 32);
            this.m_cmdAddCondition.TabIndex = 1000;
            this.m_cmdAddCondition.Text = "添加条件";
            this.m_cmdAddCondition.Click += new System.EventHandler(this.m_cmdAddCondition_Click);
            // 
            // m_pnlNone
            // 
            this.m_pnlNone.Controls.Add(this.m_lblInfo);
            this.m_pnlNone.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_pnlNone.Location = new System.Drawing.Point(12, 56);
            this.m_pnlNone.Name = "m_pnlNone";
            this.m_pnlNone.Size = new System.Drawing.Size(248, 96);
            this.m_pnlNone.TabIndex = 290;
            // 
            // m_lblInfo
            // 
            this.m_lblInfo.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lblInfo.Location = new System.Drawing.Point(12, 11);
            this.m_lblInfo.Name = "m_lblInfo";
            this.m_lblInfo.Size = new System.Drawing.Size(216, 48);
            this.m_lblInfo.TabIndex = 0;
            this.m_lblInfo.Text = "请选择需要查找的表单";
            // 
            // m_pnlTrueFalse
            // 
            this.m_pnlTrueFalse.Controls.Add(this.m_rdbTrueFalseTrue);
            this.m_pnlTrueFalse.Controls.Add(this.m_rdbTrueFalseFalse);
            this.m_pnlTrueFalse.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_pnlTrueFalse.Location = new System.Drawing.Point(16, 56);
            this.m_pnlTrueFalse.Name = "m_pnlTrueFalse";
            this.m_pnlTrueFalse.Size = new System.Drawing.Size(236, 96);
            this.m_pnlTrueFalse.TabIndex = 290;
            // 
            // m_rdbTrueFalseTrue
            // 
            this.m_rdbTrueFalseTrue.Checked = true;
            this.m_rdbTrueFalseTrue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rdbTrueFalseTrue.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_rdbTrueFalseTrue.Location = new System.Drawing.Point(8, 12);
            this.m_rdbTrueFalseTrue.Name = "m_rdbTrueFalseTrue";
            this.m_rdbTrueFalseTrue.Size = new System.Drawing.Size(96, 24);
            this.m_rdbTrueFalseTrue.TabIndex = 300;
            this.m_rdbTrueFalseTrue.TabStop = true;
            this.m_rdbTrueFalseTrue.Text = "条件成立";
            // 
            // m_rdbTrueFalseFalse
            // 
            this.m_rdbTrueFalseFalse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rdbTrueFalseFalse.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_rdbTrueFalseFalse.Location = new System.Drawing.Point(112, 12);
            this.m_rdbTrueFalseFalse.Name = "m_rdbTrueFalseFalse";
            this.m_rdbTrueFalseFalse.Size = new System.Drawing.Size(120, 24);
            this.m_rdbTrueFalseFalse.TabIndex = 400;
            this.m_rdbTrueFalseFalse.Text = "条件不成立";
            // 
            // m_pnlNumber
            // 
            this.m_pnlNumber.Controls.Add(this.m_txtNumberFrom);
            this.m_pnlNumber.Controls.Add(this.m_lblNumberFrom);
            this.m_pnlNumber.Controls.Add(this.m_lblNumberTo);
            this.m_pnlNumber.Controls.Add(this.m_txtNumberTo);
            this.m_pnlNumber.Controls.Add(this.m_cboNumberConditionType);
            this.m_pnlNumber.Controls.Add(this.lblNumberConditionType);
            this.m_pnlNumber.Font = new System.Drawing.Font("宋体", 12F);
            this.m_pnlNumber.Location = new System.Drawing.Point(12, 56);
            this.m_pnlNumber.Name = "m_pnlNumber";
            this.m_pnlNumber.Size = new System.Drawing.Size(248, 96);
            this.m_pnlNumber.TabIndex = 290;
            // 
            // m_txtNumberFrom
            // 
            this.m_txtNumberFrom.BackColor = System.Drawing.Color.White;
            this.m_txtNumberFrom.BorderColor = System.Drawing.Color.White;
            this.m_txtNumberFrom.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtNumberFrom.ForeColor = System.Drawing.Color.Black;
            this.m_txtNumberFrom.Location = new System.Drawing.Point(80, 40);
            this.m_txtNumberFrom.Name = "m_txtNumberFrom";
            this.m_txtNumberFrom.Size = new System.Drawing.Size(72, 21);
            this.m_txtNumberFrom.TabIndex = 400;
            // 
            // m_lblNumberFrom
            // 
            this.m_lblNumberFrom.AutoSize = true;
            this.m_lblNumberFrom.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lblNumberFrom.Location = new System.Drawing.Point(28, 43);
            this.m_lblNumberFrom.Name = "m_lblNumberFrom";
            this.m_lblNumberFrom.Size = new System.Drawing.Size(49, 14);
            this.m_lblNumberFrom.TabIndex = 10000004;
            this.m_lblNumberFrom.Text = "数值：";
            // 
            // m_lblNumberTo
            // 
            this.m_lblNumberTo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblNumberTo.Location = new System.Drawing.Point(156, 40);
            this.m_lblNumberTo.Name = "m_lblNumberTo";
            this.m_lblNumberTo.Size = new System.Drawing.Size(16, 24);
            this.m_lblNumberTo.TabIndex = 10000004;
            this.m_lblNumberTo.Text = "~";
            this.m_lblNumberTo.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // m_txtNumberTo
            // 
            this.m_txtNumberTo.BackColor = System.Drawing.Color.White;
            this.m_txtNumberTo.BorderColor = System.Drawing.Color.White;
            this.m_txtNumberTo.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtNumberTo.ForeColor = System.Drawing.Color.Black;
            this.m_txtNumberTo.Location = new System.Drawing.Point(176, 40);
            this.m_txtNumberTo.Name = "m_txtNumberTo";
            this.m_txtNumberTo.Size = new System.Drawing.Size(72, 21);
            this.m_txtNumberTo.TabIndex = 500;
            // 
            // m_cboNumberConditionType
            // 
            this.m_cboNumberConditionType.BackColor = System.Drawing.SystemColors.Control;
            this.m_cboNumberConditionType.BorderColor = System.Drawing.Color.Black;
            this.m_cboNumberConditionType.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboNumberConditionType.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboNumberConditionType.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboNumberConditionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboNumberConditionType.flatFont = new System.Drawing.Font("宋体", 10.5F);
            this.m_cboNumberConditionType.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_cboNumberConditionType.ForeColor = System.Drawing.Color.White;
            this.m_cboNumberConditionType.ListBackColor = System.Drawing.SystemColors.Control;
            this.m_cboNumberConditionType.ListForeColor = System.Drawing.Color.Black;
            this.m_cboNumberConditionType.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
            this.m_cboNumberConditionType.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboNumberConditionType.Location = new System.Drawing.Point(88, 8);
            this.m_cboNumberConditionType.m_BlnEnableItemEventMenu = false;
            this.m_cboNumberConditionType.Name = "m_cboNumberConditionType";
            this.m_cboNumberConditionType.SelectedIndex = -1;
            this.m_cboNumberConditionType.SelectedItem = null;
            this.m_cboNumberConditionType.SelectionStart = 0;
            this.m_cboNumberConditionType.Size = new System.Drawing.Size(159, 23);
            this.m_cboNumberConditionType.TabIndex = 300;
            this.m_cboNumberConditionType.TextBackColor = System.Drawing.Color.White;
            this.m_cboNumberConditionType.TextForeColor = System.Drawing.Color.Black;
            // 
            // lblNumberConditionType
            // 
            this.lblNumberConditionType.AutoSize = true;
            this.lblNumberConditionType.Font = new System.Drawing.Font("宋体", 10.5F);
            this.lblNumberConditionType.Location = new System.Drawing.Point(8, 12);
            this.lblNumberConditionType.Name = "lblNumberConditionType";
            this.lblNumberConditionType.Size = new System.Drawing.Size(77, 14);
            this.lblNumberConditionType.TabIndex = 10000004;
            this.lblNumberConditionType.Text = "条件类型：";
            // 
            // m_pnlLongText
            // 
            this.m_pnlLongText.Controls.Add(this.m_cboLongTextConditionType);
            this.m_pnlLongText.Controls.Add(this.lblLongTextConditionType);
            this.m_pnlLongText.Controls.Add(this.m_txtLongTextContent);
            this.m_pnlLongText.Location = new System.Drawing.Point(12, 56);
            this.m_pnlLongText.Name = "m_pnlLongText";
            this.m_pnlLongText.Size = new System.Drawing.Size(248, 96);
            this.m_pnlLongText.TabIndex = 290;
            // 
            // m_cboLongTextConditionType
            // 
            this.m_cboLongTextConditionType.BackColor = System.Drawing.SystemColors.Control;
            this.m_cboLongTextConditionType.BorderColor = System.Drawing.Color.Black;
            this.m_cboLongTextConditionType.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboLongTextConditionType.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboLongTextConditionType.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboLongTextConditionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboLongTextConditionType.flatFont = new System.Drawing.Font("宋体", 10.5F);
            this.m_cboLongTextConditionType.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_cboLongTextConditionType.ForeColor = System.Drawing.Color.White;
            this.m_cboLongTextConditionType.ListBackColor = System.Drawing.SystemColors.Control;
            this.m_cboLongTextConditionType.ListForeColor = System.Drawing.Color.Black;
            this.m_cboLongTextConditionType.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
            this.m_cboLongTextConditionType.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboLongTextConditionType.Location = new System.Drawing.Point(84, 8);
            this.m_cboLongTextConditionType.m_BlnEnableItemEventMenu = false;
            this.m_cboLongTextConditionType.Name = "m_cboLongTextConditionType";
            this.m_cboLongTextConditionType.SelectedIndex = -1;
            this.m_cboLongTextConditionType.SelectedItem = null;
            this.m_cboLongTextConditionType.SelectionStart = 0;
            this.m_cboLongTextConditionType.Size = new System.Drawing.Size(160, 23);
            this.m_cboLongTextConditionType.TabIndex = 300;
            this.m_cboLongTextConditionType.TextBackColor = System.Drawing.Color.White;
            this.m_cboLongTextConditionType.TextForeColor = System.Drawing.Color.Black;
            // 
            // lblLongTextConditionType
            // 
            this.lblLongTextConditionType.AutoSize = true;
            this.lblLongTextConditionType.Font = new System.Drawing.Font("宋体", 10.5F);
            this.lblLongTextConditionType.Location = new System.Drawing.Point(4, 12);
            this.lblLongTextConditionType.Name = "lblLongTextConditionType";
            this.lblLongTextConditionType.Size = new System.Drawing.Size(77, 14);
            this.lblLongTextConditionType.TabIndex = 10000006;
            this.lblLongTextConditionType.Text = "条件类型：";
            // 
            // m_txtLongTextContent
            // 
            this.m_txtLongTextContent.BackColor = System.Drawing.Color.White;
            this.m_txtLongTextContent.BorderColor = System.Drawing.Color.White;
            this.m_txtLongTextContent.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtLongTextContent.ForeColor = System.Drawing.Color.Black;
            this.m_txtLongTextContent.Location = new System.Drawing.Point(8, 40);
            this.m_txtLongTextContent.Name = "m_txtLongTextContent";
            this.m_txtLongTextContent.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.m_txtLongTextContent.Size = new System.Drawing.Size(236, 21);
            this.m_txtLongTextContent.TabIndex = 400;
            // 
            // m_pnlDate
            // 
            this.m_pnlDate.Controls.Add(this.m_dtpSecond);
            this.m_pnlDate.Controls.Add(this.m_cboDateConditionType);
            this.m_pnlDate.Controls.Add(this.lblDateConditionType);
            this.m_pnlDate.Controls.Add(this.m_lblDateTo);
            this.m_pnlDate.Controls.Add(this.m_dtpFirst);
            this.m_pnlDate.Controls.Add(this.m_lblDateFrom);
            this.m_pnlDate.Font = new System.Drawing.Font("宋体", 12F);
            this.m_pnlDate.Location = new System.Drawing.Point(12, 56);
            this.m_pnlDate.Name = "m_pnlDate";
            this.m_pnlDate.Size = new System.Drawing.Size(248, 96);
            this.m_pnlDate.TabIndex = 290;
            // 
            // m_dtpSecond
            // 
            this.m_dtpSecond.BorderColor = System.Drawing.Color.Black;
            this.m_dtpSecond.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpSecond.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_dtpSecond.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpSecond.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpSecond.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpSecond.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpSecond.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpSecond.Location = new System.Drawing.Point(84, 66);
            this.m_dtpSecond.m_BlnOnlyTime = false;
            this.m_dtpSecond.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpSecond.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpSecond.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpSecond.Name = "m_dtpSecond";
            this.m_dtpSecond.ReadOnly = false;
            this.m_dtpSecond.Size = new System.Drawing.Size(164, 22);
            this.m_dtpSecond.TabIndex = 500;
            this.m_dtpSecond.TextBackColor = System.Drawing.Color.White;
            this.m_dtpSecond.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboDateConditionType
            // 
            this.m_cboDateConditionType.BackColor = System.Drawing.SystemColors.Control;
            this.m_cboDateConditionType.BorderColor = System.Drawing.Color.Black;
            this.m_cboDateConditionType.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboDateConditionType.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboDateConditionType.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboDateConditionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboDateConditionType.flatFont = new System.Drawing.Font("宋体", 10.5F);
            this.m_cboDateConditionType.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_cboDateConditionType.ForeColor = System.Drawing.Color.Black;
            this.m_cboDateConditionType.ListBackColor = System.Drawing.SystemColors.Control;
            this.m_cboDateConditionType.ListForeColor = System.Drawing.Color.Black;
            this.m_cboDateConditionType.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
            this.m_cboDateConditionType.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboDateConditionType.Location = new System.Drawing.Point(84, 8);
            this.m_cboDateConditionType.m_BlnEnableItemEventMenu = false;
            this.m_cboDateConditionType.Name = "m_cboDateConditionType";
            this.m_cboDateConditionType.SelectedIndex = -1;
            this.m_cboDateConditionType.SelectedItem = null;
            this.m_cboDateConditionType.SelectionStart = 0;
            this.m_cboDateConditionType.Size = new System.Drawing.Size(164, 23);
            this.m_cboDateConditionType.TabIndex = 300;
            this.m_cboDateConditionType.TextBackColor = System.Drawing.Color.White;
            this.m_cboDateConditionType.TextForeColor = System.Drawing.Color.Black;
            // 
            // lblDateConditionType
            // 
            this.lblDateConditionType.AutoSize = true;
            this.lblDateConditionType.Font = new System.Drawing.Font("宋体", 10.5F);
            this.lblDateConditionType.Location = new System.Drawing.Point(8, 12);
            this.lblDateConditionType.Name = "lblDateConditionType";
            this.lblDateConditionType.Size = new System.Drawing.Size(77, 14);
            this.lblDateConditionType.TabIndex = 10000008;
            this.lblDateConditionType.Text = "条件类型：";
            // 
            // m_lblDateTo
            // 
            this.m_lblDateTo.AutoSize = true;
            this.m_lblDateTo.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lblDateTo.Location = new System.Drawing.Point(48, 69);
            this.m_lblDateTo.Name = "m_lblDateTo";
            this.m_lblDateTo.Size = new System.Drawing.Size(35, 14);
            this.m_lblDateTo.TabIndex = 10000004;
            this.m_lblDateTo.Text = "到：";
            // 
            // m_dtpFirst
            // 
            this.m_dtpFirst.BorderColor = System.Drawing.Color.Black;
            this.m_dtpFirst.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpFirst.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_dtpFirst.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpFirst.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpFirst.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpFirst.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpFirst.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpFirst.Location = new System.Drawing.Point(84, 40);
            this.m_dtpFirst.m_BlnOnlyTime = false;
            this.m_dtpFirst.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpFirst.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpFirst.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpFirst.Name = "m_dtpFirst";
            this.m_dtpFirst.ReadOnly = false;
            this.m_dtpFirst.Size = new System.Drawing.Size(164, 22);
            this.m_dtpFirst.TabIndex = 400;
            this.m_dtpFirst.TextBackColor = System.Drawing.Color.White;
            this.m_dtpFirst.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_lblDateFrom
            // 
            this.m_lblDateFrom.AutoSize = true;
            this.m_lblDateFrom.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lblDateFrom.Location = new System.Drawing.Point(48, 44);
            this.m_lblDateFrom.Name = "m_lblDateFrom";
            this.m_lblDateFrom.Size = new System.Drawing.Size(35, 14);
            this.m_lblDateFrom.TabIndex = 10000004;
            this.m_lblDateFrom.Text = "从：";
            // 
            // m_lstConditionList
            // 
            this.m_lstConditionList.BackColor = System.Drawing.SystemColors.Control;
            this.m_lstConditionList.ContextMenu = this.m_ctmConditionList;
            this.m_lstConditionList.ForeColor = System.Drawing.Color.Black;
            this.m_lstConditionList.HorizontalScrollbar = true;
            this.m_lstConditionList.ItemHeight = 14;
            this.m_lstConditionList.Location = new System.Drawing.Point(12, 208);
            this.m_lstConditionList.Name = "m_lstConditionList";
            this.m_lstConditionList.Size = new System.Drawing.Size(248, 312);
            this.m_lstConditionList.TabIndex = 1100;
            this.m_lstConditionList.DoubleClick += new System.EventHandler(this.m_lstConditionList_DoubleClick);
            // 
            // m_ctmConditionList
            // 
            this.m_ctmConditionList.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.m_mniModifyCondition,
            this.m_mniDeleteCondition,
            this.m_mniClearCondition});
            this.m_ctmConditionList.Popup += new System.EventHandler(this.m_ctmConditionList_Popup);
            // 
            // m_mniModifyCondition
            // 
            this.m_mniModifyCondition.Index = 0;
            this.m_mniModifyCondition.Text = "修改条件";
            this.m_mniModifyCondition.Click += new System.EventHandler(this.m_mniModifyCondition_Click);
            // 
            // m_mniDeleteCondition
            // 
            this.m_mniDeleteCondition.Index = 1;
            this.m_mniDeleteCondition.Text = "删除条件";
            this.m_mniDeleteCondition.Click += new System.EventHandler(this.m_mniDeleteCondition_Click);
            // 
            // m_mniClearCondition
            // 
            this.m_mniClearCondition.Index = 2;
            this.m_mniClearCondition.Text = "清空条件";
            this.m_mniClearCondition.Click += new System.EventHandler(this.m_mniClearCondition_Click);
            // 
            // m_trvCondition
            // 
            this.m_trvCondition.BackColor = System.Drawing.Color.White;
            this.m_trvCondition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_trvCondition.ForeColor = System.Drawing.Color.Black;
            this.m_trvCondition.Location = new System.Drawing.Point(8, 46);
            this.m_trvCondition.Name = "m_trvCondition";
            this.m_trvCondition.Size = new System.Drawing.Size(256, 378);
            this.m_trvCondition.TabIndex = 10000005;
            this.m_trvCondition.Visible = false;
            this.m_trvCondition.DoubleClick += new System.EventHandler(this.m_trvCondition_DoubleClick);
            this.m_trvCondition.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_trvCondition_AfterSelect);
            this.m_trvCondition.LostFocus += new System.EventHandler(this.m_trvCondition_LostFocus);
            // 
            // m_txtTemplateName
            // 
            this.m_txtTemplateName.Location = new System.Drawing.Point(56, 432);
            this.m_txtTemplateName.Name = "m_txtTemplateName";
            this.m_txtTemplateName.ReadOnly = true;
            this.m_txtTemplateName.Size = new System.Drawing.Size(180, 23);
            this.m_txtTemplateName.TabIndex = 10000010;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 468);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 14);
            this.label3.TabIndex = 10000009;
            this.label3.Text = "值:";
            // 
            // m_cmdAddTemplateCondition
            // 
            this.m_cmdAddTemplateCondition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdAddTemplateCondition.DefaultScheme = true;
            this.m_cmdAddTemplateCondition.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAddTemplateCondition.Hint = "";
            this.m_cmdAddTemplateCondition.Location = new System.Drawing.Point(168, 496);
            this.m_cmdAddTemplateCondition.Name = "m_cmdAddTemplateCondition";
            this.m_cmdAddTemplateCondition.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAddTemplateCondition.Size = new System.Drawing.Size(68, 28);
            this.m_cmdAddTemplateCondition.TabIndex = 10000008;
            this.m_cmdAddTemplateCondition.Text = "添  加";
            this.m_cmdAddTemplateCondition.Click += new System.EventHandler(this.m_cmdAddTemplateCondition_Click);
            // 
            // m_txtTemplateValue
            // 
            this.m_txtTemplateValue.Location = new System.Drawing.Point(56, 464);
            this.m_txtTemplateValue.Name = "m_txtTemplateValue";
            this.m_txtTemplateValue.Size = new System.Drawing.Size(180, 23);
            this.m_txtTemplateValue.TabIndex = 10000007;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 436);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 14);
            this.label2.TabIndex = 10000006;
            this.label2.Text = "条件:";
            // 
            // m_tvwTemplate
            // 
            this.m_tvwTemplate.HideSelection = false;
            this.m_tvwTemplate.Location = new System.Drawing.Point(8, 28);
            this.m_tvwTemplate.Name = "m_tvwTemplate";
            this.m_tvwTemplate.Size = new System.Drawing.Size(228, 396);
            this.m_tvwTemplate.TabIndex = 10000006;
            this.m_tvwTemplate.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_tvwTemplate_AfterSelect);
            // 
            // m_cmdSearch
            // 
            this.m_cmdSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdSearch.DefaultScheme = true;
            this.m_cmdSearch.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSearch.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_cmdSearch.Hint = "";
            this.m_cmdSearch.Location = new System.Drawing.Point(388, 11);
            this.m_cmdSearch.Name = "m_cmdSearch";
            this.m_cmdSearch.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSearch.Size = new System.Drawing.Size(60, 28);
            this.m_cmdSearch.TabIndex = 1200;
            this.m_cmdSearch.Text = "查  询";
            this.m_cmdSearch.Click += new System.EventHandler(this.m_cmdSearch_Click);
            // 
            // m_cmdClearResult
            // 
            this.m_cmdClearResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdClearResult.DefaultScheme = true;
            this.m_cmdClearResult.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdClearResult.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_cmdClearResult.Hint = "";
            this.m_cmdClearResult.Location = new System.Drawing.Point(476, 11);
            this.m_cmdClearResult.Name = "m_cmdClearResult";
            this.m_cmdClearResult.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClearResult.Size = new System.Drawing.Size(60, 28);
            this.m_cmdClearResult.TabIndex = 1200;
            this.m_cmdClearResult.Text = "清  空";
            this.m_cmdClearResult.Click += new System.EventHandler(this.m_cmdClearResult_Click);
            // 
            // m_lsvPatientList
            // 
            this.m_lsvPatientList.BackColor = System.Drawing.SystemColors.Control;
            this.m_lsvPatientList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader1,
            this.columnHeader3});
            this.m_lsvPatientList.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lsvPatientList.ForeColor = System.Drawing.Color.Black;
            this.m_lsvPatientList.FullRowSelect = true;
            this.m_lsvPatientList.HideSelection = false;
            this.m_lsvPatientList.Location = new System.Drawing.Point(529, 55);
            this.m_lsvPatientList.Name = "m_lsvPatientList";
            this.m_lsvPatientList.Size = new System.Drawing.Size(252, 356);
            this.m_lsvPatientList.TabIndex = 1300;
            this.m_lsvPatientList.UseCompatibleStateImageBehavior = false;
            this.m_lsvPatientList.View = System.Windows.Forms.View.Details;
            this.m_lsvPatientList.SelectedIndexChanged += new System.EventHandler(this.m_lsvPatientList_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "姓名";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "住院号";
            this.columnHeader1.Width = 78;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "住院日期";
            this.columnHeader3.Width = 108;
            // 
            // m_txtPatientInfo
            // 
            this.m_txtPatientInfo.BackColor = System.Drawing.SystemColors.Control;
            this.m_txtPatientInfo.BorderColor = System.Drawing.Color.Transparent;
            this.m_txtPatientInfo.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtPatientInfo.ForeColor = System.Drawing.Color.Black;
            this.m_txtPatientInfo.Location = new System.Drawing.Point(529, 416);
            this.m_txtPatientInfo.Multiline = true;
            this.m_txtPatientInfo.Name = "m_txtPatientInfo";
            this.m_txtPatientInfo.ReadOnly = true;
            this.m_txtPatientInfo.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.m_txtPatientInfo.Size = new System.Drawing.Size(252, 168);
            this.m_txtPatientInfo.TabIndex = 1400;
            // 
            // m_lblPatientCount
            // 
            this.m_lblPatientCount.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lblPatientCount.Location = new System.Drawing.Point(552, 15);
            this.m_lblPatientCount.Name = "m_lblPatientCount";
            this.m_lblPatientCount.Size = new System.Drawing.Size(104, 20);
            this.m_lblPatientCount.TabIndex = 10000005;
            this.m_lblPatientCount.Text = "人数：";
            // 
            // m_lblPatientTimesCount
            // 
            this.m_lblPatientTimesCount.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lblPatientTimesCount.Location = new System.Drawing.Point(660, 15);
            this.m_lblPatientTimesCount.Name = "m_lblPatientTimesCount";
            this.m_lblPatientTimesCount.Size = new System.Drawing.Size(104, 20);
            this.m_lblPatientTimesCount.TabIndex = 10000005;
            this.m_lblPatientTimesCount.Text = "人次：";
            // 
            // m_ctmExplorer
            // 
            this.m_ctmExplorer.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.m_mnuInPatient,
            this.menuItem9,
            this.menuItem12,
            this.menuItem13,
            this.menuItem16,
            this.menuItem1,
            this.menuItem38,
            this.menuItem39,
            this.menuItem40,
            this.menuItem2,
            this.menuItem3,
            this.menuItem37});
            this.m_ctmExplorer.Popup += new System.EventHandler(this.m_ctmExplorer_Popup);
            // 
            // m_mnuInPatient
            // 
            this.m_mnuInPatient.Index = 0;
            this.m_mnuInPatient.Text = "住院病历";
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 1;
            this.menuItem9.Text = "病程记录";
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 2;
            this.menuItem12.Text = "术前小结";
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 3;
            this.menuItem13.Text = "手术记录单";
            // 
            // menuItem16
            // 
            this.menuItem16.Index = 4;
            this.menuItem16.Text = "出院记录";
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 5;
            this.menuItem1.Text = "-";
            // 
            // menuItem38
            // 
            this.menuItem38.Index = 6;
            this.menuItem38.Text = "入院病人评估";
            // 
            // menuItem39
            // 
            this.menuItem39.Index = 7;
            this.menuItem39.Text = "三 测 表";
            // 
            // menuItem40
            // 
            this.menuItem40.Index = 8;
            this.menuItem40.Text = "一般护理记录";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 9;
            this.menuItem2.Text = "-";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 10;
            this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem6,
            this.menuItem19,
            this.menuItem27,
            this.mniDirectionAnalisys,
            this.menuItem36});
            this.menuItem3.Text = "医生工作站";
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 0;
            this.menuItem6.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem8,
            this.menuItem10,
            this.menuItem11,
            this.menuItem14,
            this.menuItem15,
            this.menuItem17,
            this.menuItem18});
            this.menuItem6.Text = "病案生成";
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 0;
            this.menuItem8.Text = "住院病历模式2";
            this.menuItem8.Visible = false;
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 1;
            this.menuItem10.Text = "会诊记录";
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 2;
            this.menuItem11.Text = "手术知情同意书";
            // 
            // menuItem14
            // 
            this.menuItem14.Index = 3;
            this.menuItem14.Text = "ICU转入记录";
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 4;
            this.menuItem15.Text = "ICU转出记录";
            // 
            // menuItem17
            // 
            this.menuItem17.Index = 5;
            this.menuItem17.Text = "住院病案首页";
            // 
            // menuItem18
            // 
            this.menuItem18.Index = 6;
            this.menuItem18.Text = "病案质量评分表";
            // 
            // menuItem19
            // 
            this.menuItem19.Index = 1;
            this.menuItem19.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem22,
            this.menuItem23,
            this.menuItem24,
            this.menuItem20,
            this.menuItem21,
            this.menuItem25,
            this.menuItem26,
            this.mniEKGOrder,
            this.mniNuclearOrder,
            this.mniPSGOrder,
            this.mniLabAnalysisOrder,
            this.mniLabCheckReport,
            this.mniImageReport,
            this.mniImageBookingSearch});
            this.menuItem19.Text = "申  请  单";
            // 
            // menuItem22
            // 
            this.menuItem22.Index = 0;
            this.menuItem22.Text = "B型超声显像检查申请单";
            // 
            // menuItem23
            // 
            this.menuItem23.Index = 1;
            this.menuItem23.Text = "CT检查申请单";
            // 
            // menuItem24
            // 
            this.menuItem24.Index = 2;
            this.menuItem24.Text = "X线申请单";
            // 
            // menuItem20
            // 
            this.menuItem20.Index = 3;
            this.menuItem20.Text = "SPECT检查申请单";
            // 
            // menuItem21
            // 
            this.menuItem21.Index = 4;
            this.menuItem21.Text = "高压氧治疗申请单";
            // 
            // menuItem25
            // 
            this.menuItem25.Index = 5;
            this.menuItem25.Text = "病理活体组织送检单";
            // 
            // menuItem26
            // 
            this.menuItem26.Index = 6;
            this.menuItem26.Text = "MRI申请单";
            // 
            // mniEKGOrder
            // 
            this.mniEKGOrder.Index = 7;
            this.mniEKGOrder.Text = "心电图申请单";
            // 
            // mniNuclearOrder
            // 
            this.mniNuclearOrder.Index = 8;
            this.mniNuclearOrder.Text = "电脑多导睡眠图检查申请单";
            // 
            // mniPSGOrder
            // 
            this.mniPSGOrder.Index = 9;
            this.mniPSGOrder.Text = "核医学检查申请单";
            // 
            // mniLabAnalysisOrder
            // 
            this.mniLabAnalysisOrder.Index = 10;
            this.mniLabAnalysisOrder.Text = "实验室检验申请单";
            this.mniLabAnalysisOrder.Visible = false;
            // 
            // mniLabCheckReport
            // 
            this.mniLabCheckReport.Index = 11;
            this.mniLabCheckReport.Text = "实验室检验报告单";
            // 
            // mniImageReport
            // 
            this.mniImageReport.Index = 12;
            this.mniImageReport.Text = "影像报告单";
            // 
            // mniImageBookingSearch
            // 
            this.mniImageBookingSearch.Index = 13;
            this.mniImageBookingSearch.Text = "影像预约查询";
            this.mniImageBookingSearch.Visible = false;
            // 
            // menuItem27
            // 
            this.menuItem27.Index = 2;
            this.menuItem27.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem28,
            this.menuItem29,
            this.menuItem30,
            this.menuItem31,
            this.menuItem32,
            this.menuItem33,
            this.menuItem34,
            this.menuItem35});
            this.menuItem27.Text = "智能评分系统";
            // 
            // menuItem28
            // 
            this.menuItem28.Index = 0;
            this.menuItem28.Text = "SIRS诊断评分";
            // 
            // menuItem29
            // 
            this.menuItem29.Index = 1;
            this.menuItem29.Text = "改良Glasgow昏迷评分";
            // 
            // menuItem30
            // 
            this.menuItem30.Index = 2;
            this.menuItem30.Text = "急性肺损伤评分";
            // 
            // menuItem31
            // 
            this.menuItem31.Index = 3;
            this.menuItem31.Text = "新生儿危重病例评分";
            // 
            // menuItem32
            // 
            this.menuItem32.Index = 4;
            this.menuItem32.Text = "小儿危重病例评分";
            // 
            // menuItem33
            // 
            this.menuItem33.Index = 5;
            this.menuItem33.Text = "APACHEII 评分";
            // 
            // menuItem34
            // 
            this.menuItem34.Index = 6;
            this.menuItem34.Text = "APACHEIII 评分";
            // 
            // menuItem35
            // 
            this.menuItem35.Index = 7;
            this.menuItem35.Text = "TISS-28评分";
            // 
            // mniDirectionAnalisys
            // 
            this.mniDirectionAnalisys.Index = 3;
            this.mniDirectionAnalisys.Text = "趋势分析";
            // 
            // menuItem36
            // 
            this.menuItem36.Index = 4;
            this.menuItem36.Text = "全套病历";
            this.menuItem36.Visible = false;
            // 
            // menuItem37
            // 
            this.menuItem37.Index = 11;
            this.menuItem37.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mniPatientInfoManage,
            this.menuItem41,
            this.menuItem42,
            this.menuItem43,
            this.mniICUTendRecord,
            this.menuItem44,
            this.menuItem45,
            this.menuItem46});
            this.menuItem37.Text = "护士工作站";
            // 
            // mniPatientInfoManage
            // 
            this.mniPatientInfoManage.Index = 0;
            this.mniPatientInfoManage.Text = "病人基本资料维护";
            // 
            // menuItem41
            // 
            this.menuItem41.Index = 1;
            this.menuItem41.Text = "观察项目记录表";
            // 
            // menuItem42
            // 
            this.menuItem42.Index = 2;
            this.menuItem42.Text = "危重患者护理记录";
            // 
            // menuItem43
            // 
            this.menuItem43.Index = 3;
            this.menuItem43.Text = "危重症监护中心特护记录单";
            // 
            // mniICUTendRecord
            // 
            this.mniICUTendRecord.Index = 4;
            this.mniICUTendRecord.Text = "ICU危重患者护理记录";
            this.mniICUTendRecord.Visible = false;
            // 
            // menuItem44
            // 
            this.menuItem44.Index = 5;
            this.menuItem44.Text = "手术护理记录";
            // 
            // menuItem45
            // 
            this.menuItem45.Index = 6;
            this.menuItem45.Text = "手术器械、敷料点数表";
            // 
            // menuItem46
            // 
            this.menuItem46.Index = 7;
            this.menuItem46.Text = "中心ICU呼吸机治疗监护记录单";
            // 
            // m_imlCondition
            // 
            this.m_imlCondition.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imlCondition.ImageStream")));
            this.m_imlCondition.TransparentColor = System.Drawing.Color.Transparent;
            this.m_imlCondition.Images.SetKeyName(0, "");
            this.m_imlCondition.Images.SetKeyName(1, "");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_tvwTemplate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.m_txtTemplateName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.m_txtTemplateValue);
            this.groupBox1.Controls.Add(this.m_cmdAddTemplateCondition);
            this.groupBox1.Location = new System.Drawing.Point(283, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 536);
            this.groupBox1.TabIndex = 10000009;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "最小元素查询";
            // 
            // frmRecordSearch
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(792, 623);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_lblPatientTimesCount);
            this.Controls.Add(this.m_lblPatientCount);
            this.Controls.Add(this.m_cmdClearResult);
            this.Controls.Add(this.m_cmdSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_txtPatientInfo);
            this.Controls.Add(this.m_lsvPatientList);
            this.Controls.Add(this.grbSearchCondition);
            this.Controls.Add(this.m_cboFormList);
            this.Name = "frmRecordSearch";
            this.Text = "记录查询";
            this.Load += new System.EventHandler(this.frmRecordSearch_Load);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_cboFormList, 0);
            this.Controls.SetChildIndex(this.grbSearchCondition, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientList, 0);
            this.Controls.SetChildIndex(this.m_txtPatientInfo, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.m_cmdSearch, 0);
            this.Controls.SetChildIndex(this.m_cmdClearResult, 0);
            this.Controls.SetChildIndex(this.m_lblPatientCount, 0);
            this.Controls.SetChildIndex(this.m_lblPatientTimesCount, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.grbSearchCondition.ResumeLayout(false);
            this.m_pnlNone.ResumeLayout(false);
            this.m_pnlTrueFalse.ResumeLayout(false);
            this.m_pnlNumber.ResumeLayout(false);
            this.m_pnlNumber.PerformLayout();
            this.m_pnlLongText.ResumeLayout(false);
            this.m_pnlLongText.PerformLayout();
            this.m_pnlDate.ResumeLayout(false);
            this.m_pnlDate.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmRecordSearch_Load(object sender, System.EventArgs e)
		{
			m_cboDept.Visible = false;
			lblDept.Visible = false;
			m_cboArea.Visible = false;
			lblAreaTitle.Visible = false;
			lblNameTitle.Visible = false;
			m_txtPatientName.Visible = false;
			lblSexTitle.Visible = false;
			lblSex.Visible = false;
			lblAgeTitle.Visible = false;
			lblAge.Visible = false;
			lblBedNoTitle.Visible = false;
			m_txtBedNO.Visible = false;
			lblInHospitalNoTitle.Visible = false;
			txtInPatientID.Visible = false;

			m_mthInitFormList();			
		}

		#region 病人详细信息
		/// <summary>
		/// 初始化病人详细信息
		/// </summary>
		private void m_mthInitPatientDetailMaker()
		{
			m_hasPatientDetailMaker = new Hashtable(4);

			RecordSearch.PatientDetailMaker.clsPatientDetailMakerBase objPatientDetailMaker = new RecordSearch.PatientDetailMaker.clsPatientDetailMakerBase();
			m_hasPatientDetailMaker.Add(objPatientDetailMaker.m_StrFormName,objPatientDetailMaker);

			objPatientDetailMaker = new RecordSearch.PatientDetailMaker.clsInHospitalMainRecordMaker();
			m_hasPatientDetailMaker.Add(objPatientDetailMaker.m_StrFormName,objPatientDetailMaker);

			objPatientDetailMaker = new RecordSearch.PatientDetailMaker.clsInHospitalHistoryRecordMaker();
			m_hasPatientDetailMaker.Add(objPatientDetailMaker.m_StrFormName,objPatientDetailMaker);

			objPatientDetailMaker = new RecordSearch.PatientDetailMaker.clsOperationDoctorRecordMaker();
			m_hasPatientDetailMaker.Add(objPatientDetailMaker.m_StrFormName,objPatientDetailMaker);
		}
		/// <summary>
		/// 获取指定类型的病人详细信息
		/// </summary>
		/// <param name="p_strFormName"></param>
		/// <returns></returns>
		private RecordSearch.PatientDetailMaker.clsPatientDetailMakerBase m_objGetPatientDetailMaker(string p_strFormName)
		{
			if(!m_hasPatientDetailMaker.Contains(p_strFormName))
				return (RecordSearch.PatientDetailMaker.clsPatientDetailMakerBase)m_hasPatientDetailMaker["none"];
			return (RecordSearch.PatientDetailMaker.clsPatientDetailMakerBase)m_hasPatientDetailMaker[p_strFormName];
		}
		#endregion

		#region 查询信息生成者
		/// <summary>
		/// 初始化查询信息生成者
		/// </summary>
		private void m_mthInitSearchInfoBuilder()
		{
			m_hasSearchInfoBuilders = new Hashtable(4);

			RecordSearch.SearchInfoBuilder.clsSearchInfoBuilderBase objSearchInfoBuilder = new RecordSearch.SearchInfoBuilder.clsSearchInfoBuilderBase();
			m_hasSearchInfoBuilders.Add(objSearchInfoBuilder.m_StrBuildType,objSearchInfoBuilder);

			objSearchInfoBuilder = new RecordSearch.SearchInfoBuilder.clsSearchInfoBuilder_And();
			m_hasSearchInfoBuilders.Add(objSearchInfoBuilder.m_StrBuildType,objSearchInfoBuilder);
		}
		/// <summary>
		/// 获取指定类型的查询信息生成者
		/// </summary>
		/// <param name="p_strSearchInfoType"></param>
		/// <returns></returns>
		private RecordSearch.SearchInfoBuilder.clsSearchInfoBuilderBase m_objGetSearchInfoBuilder(string p_strSearchInfoType)
		{
			return (RecordSearch.SearchInfoBuilder.clsSearchInfoBuilderBase)m_hasSearchInfoBuilders[p_strSearchInfoType.ToLower()];
		}
		#endregion

		#region 查询输入内容的辅助功能
		/// <summary>
		/// 初始化查询条件生成者
		/// </summary>
		private void m_mthInitConditionMaker()
		{
			m_hasConditionMakers = new Hashtable(5);

			RecordSearch.ConditionMaker.clsConditionMakerBase objConditionMaker = new RecordSearch.ConditionMaker.clsDateConditionMaker();
			objConditionMaker.m_mthSetRecordSearchForm(this);
			m_hasConditionMakers.Add("date",objConditionMaker);

			objConditionMaker = new RecordSearch.ConditionMaker.clsLongTextConditionMaker();
			objConditionMaker.m_mthSetRecordSearchForm(this);
			m_hasConditionMakers.Add("text",objConditionMaker);

			objConditionMaker = new RecordSearch.ConditionMaker.clsNumberConditionMaker();
			objConditionMaker.m_mthSetRecordSearchForm(this);
			m_hasConditionMakers.Add("number",objConditionMaker);

			objConditionMaker = new RecordSearch.ConditionMaker.clsTrueFalseConditionMaker();
			objConditionMaker.m_mthSetRecordSearchForm(this);
			m_hasConditionMakers.Add("truefalse",objConditionMaker);
		}
		/// <summary>
		/// 获取指定类型的查询条件生成者
		/// </summary>
		/// <param name="p_strConditionType"></param>
		/// <returns></returns>
		private RecordSearch.ConditionMaker.clsConditionMakerBase m_objGetConditionMaker(string p_strConditionInput)
		{
			return (RecordSearch.ConditionMaker.clsConditionMakerBase)m_hasConditionMakers[p_strConditionInput.ToLower()];
		}
		/// <summary>
		/// 显示查询条件输入
		/// </summary>
		/// <param name="p_strConditionInput"></param>
		private void m_mthShowConditionInput(string p_strConditionInput)
		{
			switch(p_strConditionInput.ToLower())
			{
				case "date":
					m_pnlDate.Visible = true;
					m_pnlLongText.Visible = false;
					m_pnlNone.Visible = false;
					m_pnlNumber.Visible = false;
					m_pnlTrueFalse.Visible = false;
					break;
				case "text":
					m_pnlDate.Visible = false;
					m_pnlLongText.Visible = true;
					m_pnlNone.Visible = false;
					m_pnlNumber.Visible = false;
					m_pnlTrueFalse.Visible = false;
					break;
				case "none":
					m_pnlDate.Visible = false;
					m_pnlLongText.Visible = false;
					m_pnlNone.Visible = true;
					m_pnlNumber.Visible = false;
					m_pnlTrueFalse.Visible = false;
					break;
				case "number":
					m_pnlDate.Visible = false;
					m_pnlLongText.Visible = false;
					m_pnlNone.Visible = false;
					m_pnlNumber.Visible = true;
					m_pnlTrueFalse.Visible = false;
					break;
				case "truefalse":
					m_pnlDate.Visible = false;
					m_pnlLongText.Visible = false;
					m_pnlNone.Visible = false;
					m_pnlNumber.Visible = false;
					m_pnlTrueFalse.Visible = true;
					break;
			}
		}
		#endregion 查询输入内容的辅助功能

		#region 初始化表单及字段信息
		/// <summary>
		/// 初始化表单信息
		/// </summary>
		private void m_mthInitFormList()
		{
			RecordSearch.clsRecordSearchDomain.clsFormInfo [] objFormInfoArr = null;
			m_objRecordSearchDomain.m_lngIMR_GetFormInfo(MDIParent.s_ObjDepartment.m_StrDeptID,out objFormInfoArr);
			if(objFormInfoArr != null)
//			{
//				m_blnIsNewCase = false;
//			}
//			else
			{
				for(int i=0;i<objFormInfoArr.Length;i++)
				{
					if(objFormInfoArr[i].m_strFormID == "frmInPatientCaseHistory")
						continue;
					objFormInfoArr[i].m_strMainSearchInfo = objFormInfoArr[i].m_strMainSearchInfo.Replace("$TypeID$","'"+ objFormInfoArr[i].m_strFormID +"'");
					objFormInfoArr[i].m_strMainSearchInfo = objFormInfoArr[i].m_strMainSearchInfo.Replace("$NULLDate$",clsDatabaseSQLConvert.s_strGetSQLInvalidDateFormat());
					objFormInfoArr[i].m_strMainSearchInfo = objFormInfoArr[i].m_strMainSearchInfo.Replace("$DeptID$","'"+MDIParent.s_ObjDepartment.m_StrDeptID+"'");
					m_cboFormList.AddItem(objFormInfoArr[i]);
				}
//				m_blnIsNewCase = true;
			}
			objFormInfoArr = m_objRecordSearchDomain.m_objGetFormInfoArr();
			if(objFormInfoArr == null)
				return;
			for(int i=0;i<objFormInfoArr.Length;i++)
			{
				objFormInfoArr[i].m_strMainSearchInfo = objFormInfoArr[i].m_strMainSearchInfo.Replace("$NULLDate$",clsDatabaseSQLConvert.s_strGetSQLInvalidDateFormat());
				objFormInfoArr[i].m_strMainSearchInfo = objFormInfoArr[i].m_strMainSearchInfo.Replace("$DeptID$","'"+MDIParent.s_ObjDepartment.m_StrDeptID+"'");
//				if(objFormInfoArr[i].m_strFormName == "住院病历" && m_blnIsNewCase == true)
//					continue;
				m_cboFormList.AddItem(objFormInfoArr[i]);
			}
		
			if(m_cboFormList.GetItemsCount() == 1)
			{
				m_cboFormList.SelectedIndex = 0;
				m_cboFieldList.Focus();
			}
			else
			{
				m_cboFormList.Focus();
			}
		}

		/// <summary>
		/// 初始化表单对应的字段
		/// </summary>
		/// <param name="p_objFormInfo"></param>
		/// <param name="p_strText"></param>
		private void m_mthInitFieldList(RecordSearch.clsRecordSearchDomain.clsFormInfo p_objFormInfo,string p_strText)
		{
			if(p_objFormInfo == null)
				return;

			m_cboFieldList.ClearItem();
			if(p_strText.Trim() == "手术记录单" || p_strText.Trim() == "住院病案首页" || p_strText.Trim() == "住院病历")
			{
				if(p_objFormInfo.m_objFieldInfoArr == null)
				{
					m_objRecordSearchDomain.m_objGetFieldInfoArr(ref p_objFormInfo);
				}
				m_cboFieldList.AddRangeItems(p_objFormInfo.m_objFieldInfoArr);
			}
			else
			{
				//新专科病历控制
				m_mthInitTreeNodes(p_objFormInfo);
			}
		}
		#endregion 初始化表单及字段信息

		private void m_cboFormList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_tvwTemplate.Nodes.Clear();
			m_txtTemplateName.Text="";
			m_txtTemplateValue.Text="";

			m_trvCondition.Visible = false;
//			m_objBorderTool.m_mthUnChangedControlBorder(m_trvCondition);
			grbSearchCondition.Refresh();
			RecordSearch.clsRecordSearchDomain.clsFormInfo objFormInfo = m_cboFormList.SelectedItem as RecordSearch.clsRecordSearchDomain.clsFormInfo;

			m_mthInitFieldList(objFormInfo,((ctlComboBox)sender).Text);

			m_cboFieldList.SelectedIndex = -1;
			m_mthShowConditionInput("None");
			m_mthClearCondition();
			m_objSearchInfoBuilderBase = m_objGetSearchInfoBuilder(objFormInfo.m_strSearchInfoType);
		}

		private void m_cboFieldList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_cboFormList.Text == "手术记录单" || m_cboFormList.Text == "住院病案首页" || m_cboFormList.Text == "住院病历")
				m_mthSetConditionBase();

			//Template
			if(m_cboFieldList.SelectedItem!=null && m_cboFieldList.SelectedItem is RecordSearch.clsRecordSearchDomain.clsFieldInfo)
			{
				m_mthAddSubNodeTemplate(m_cboFieldList.SelectedItem as RecordSearch.clsRecordSearchDomain.clsFieldInfo);
			}
		}

		private void m_cmdAddCondition_Click(object sender, System.EventArgs e)
		{
			if(m_objConditionBase != null && m_objConditionBase.m_blnCheckCondition())
			{			
				RecordSearch.ConditionMaker.clsConditionMakerBase.clsConditionStatus objConditionStatus = m_objConditionBase.m_ObjStatus;
				objConditionStatus.m_strPreDesc = m_cboFieldList.Text+":";
				objConditionStatus.m_intFieldIndex = m_cboFieldList.SelectedIndex;

				m_lstConditionList.Items.Add(objConditionStatus);	
			
				m_objConditionBase.m_mthResetConditionInput();
			}
		}

		private void m_ctmConditionList_Popup(object sender, System.EventArgs e)
		{
			bool blnEnableMenuByCount = m_lstConditionList.Items.Count > 0;

			bool blnEnableMenuBySelectedItem = m_lstConditionList.SelectedItem != null;

			m_mniModifyCondition.Enabled = blnEnableMenuBySelectedItem;
			m_mniDeleteCondition.Enabled = blnEnableMenuBySelectedItem;
			m_mniClearCondition.Enabled = blnEnableMenuByCount;
		}

		private void m_mniDeleteCondition_Click(object sender, System.EventArgs e)
		{
			if(m_lstConditionList.SelectedItem != null)
			{
				m_lstConditionList.Items.RemoveAt(m_lstConditionList.SelectedIndex);
			}
		}

		private void m_mniClearCondition_Click(object sender, System.EventArgs e)
		{
			m_mthClearCondition();
		}

		private void m_mniModifyCondition_Click(object sender, System.EventArgs e)
		{
			m_mthSetModifyCondition();
		}

		private void m_lstConditionList_DoubleClick(object sender, System.EventArgs e)
		{
			m_mthSetModifyCondition();
		}

		/// <summary>
		/// 设置条件修改
		/// </summary>
		private void m_mthSetModifyCondition()
		{
			RecordSearch.ConditionMaker.clsConditionMakerBase.clsConditionStatus objConditionStatus = m_lstConditionList.SelectedItem as RecordSearch.ConditionMaker.clsConditionMakerBase.clsConditionStatus;

			m_lstConditionList.Items.RemoveAt(m_lstConditionList.SelectedIndex);

			if(objConditionStatus != null)
			{
				m_cboFieldList.SelectedIndex = objConditionStatus.m_intFieldIndex;

				if(m_objConditionBase != null)
				{
					m_objConditionBase.m_ObjStatus = objConditionStatus;
				}
			}
		}

		private void m_cmdSearch_Click(object sender, System.EventArgs e)
		{
			m_mthClearPatientList();

			if(m_objSearchInfoBuilderBase == null)
				return;

			RecordSearch.clsRecordSearchDomain.clsFormInfo objFormInfo = m_cboFormList.SelectedItem as RecordSearch.clsRecordSearchDomain.clsFormInfo;
			if(objFormInfo == null)
				return;

			//Remove New Condition
			ArrayList arlNewCon=new ArrayList();
			if(m_lstConditionList.Items.Count>0)
			{
				int i=0;
				while(i<m_lstConditionList.Items.Count)
				{
					if(m_lstConditionList.Items[i] is clsTemplateCondition)
					{
						arlNewCon.Add(m_lstConditionList.Items[i]);
						m_lstConditionList.Items.RemoveAt(i);
					}
					else
					{
						i++;
					}
				}
			}

			//old Search
			clsRecordSearch_SearchInfo objSearchInfo = m_objSearchInfoBuilderBase.m_objBuildSearchInfo(objFormInfo,m_lstConditionList.Items.GetEnumerator());

			if(objSearchInfo == null)
				return;

			RecordSearch.clsRecordSearchDomain.clsPatientList [] objPatientList = m_objRecordSearchDomain.m_objGetPatientListArr(objSearchInfo);

			//New Search
			iCareData.clsTextTemplate[] arrNewPatient=null;
			if(arlNewCon.Count>0)
			{
				string[] arrGuiID=new string[arlNewCon.Count];
				string[] arrCtrlName=new string[arlNewCon.Count];
				string[] arrCtrlValue=new string[arlNewCon.Count];
				for(int i=0;i<arlNewCon.Count;i++)
				{
					clsTemplateCondition con=arlNewCon[i] as clsTemplateCondition;
					if(con==null)
					{
						arrGuiID[i]="";
						arrCtrlName[i]="";
						arrCtrlValue[i]="";
					}
					else
					{
						arrGuiID[i]= con.m_strGuiID.Trim();
						arrCtrlName[i]=con.m_strCtrlName.Trim();
						arrCtrlValue[i]=con.m_strCtrlValue.Trim();
					}
				}

                CustomFromService.clsMinElementColServ objService =
                    (CustomFromService.clsMinElementColServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(CustomFromService.clsMinElementColServ));

				long ret=objService.m_lngFindPatientTemplateText(arrGuiID,arrCtrlName,arrCtrlValue,out arrNewPatient);

			}

			//Process Old and New Result
			if(arlNewCon.Count>0)
			{
				ArrayList arlAll=new ArrayList();
				if(arrNewPatient!=null && arrNewPatient.Length>0 && objPatientList!=null && objPatientList.Length>0)
				{
				
					for(int i=0;i<objPatientList.Length;i++)
					{
						if(objPatientList[i]==null) continue;

						bool blnFind=false;
					
						for(int j=0;j<arrNewPatient.Length;j++)
						{
							if(arrNewPatient[j]==null) continue;

							if((objPatientList[i].m_strInPatientNO.Trim()==arrNewPatient[j].m_strInPatientID.Trim())
								&& (DateTime.Parse( objPatientList[i].m_strInPatientDate)==arrNewPatient[j].m_dtInPatientDate))
							{
								blnFind=true;
								break;
							}
						}

						if(blnFind)
						{
							arlAll.Add(objPatientList[i]);
						}
					}
					objPatientList=(iCare.RecordSearch.clsRecordSearchDomain.clsPatientList[])(arlAll.ToArray(typeof(iCare.RecordSearch.clsRecordSearchDomain.clsPatientList)));
				}
				else if((objPatientList == null || objPatientList.Length <= 0) && arrNewPatient!=null && arrNewPatient.Length>0)
				{
					objPatientList = new iCare.RecordSearch.clsRecordSearchDomain.clsPatientList[arrNewPatient.Length];
					for(int k2=0;k2<arrNewPatient.Length;k2++)
					{
						clsPatient objPatient = new clsPatient(arrNewPatient[k2].m_strInPatientID);
						iCare.RecordSearch.clsRecordSearchDomain.clsPatientList objlist = new iCare.RecordSearch.clsRecordSearchDomain.clsPatientList();
						objlist.m_strInPatientNO = objPatient.m_StrInPatientID;
						objlist.m_strInPatientDate = objPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss");
						objlist.m_strOpenDate = arrNewPatient[k2].m_dtOpenDate.ToString("yyyy-MM-dd HH:mm:ss");
						objlist.m_strSex = objPatient.m_StrSex;
						objlist.m_strFirstName = objPatient.m_StrName;
						objlist.m_strCreateUserName = "";
						objlist.m_strCreateUserID = "";
						objlist.m_strCreateDate = "";
						objlist.m_strAge = objPatient.m_ObjPeopleInfo.m_StrAge;
						objPatientList[k2] = objlist;
					}
				}
				else if(arrNewPatient == null || arrNewPatient.Length <= 0)
				{
					objPatientList = null;
				}
			}

			//Show Result
			if(objPatientList != null)
				m_mthSetPatientList(objFormInfo,objPatientList);
			
			//Add New Condition
			if(arlNewCon.Count>0)
			{
				for(int i=0;i<arlNewCon.Count;i++)
				{
					m_lstConditionList.Items.Add(arlNewCon[i]);
				}
			}
		
		}

		private void m_cmdClearResult_Click(object sender, System.EventArgs e)
		{
			m_mthClearPatientList();
		}

		private void m_cmdClearCondition_Click(object sender, System.EventArgs e)
		{
			m_mthClearCondition();
		}

		/// <summary>
		/// 清空条件列表
		/// </summary>
		private void m_mthClearCondition()
		{
			m_lstConditionList.Items.Clear();
		}

		#region 处理查询结果
		/// <summary>
		/// 设置病人列表
		/// </summary>
		/// <param name="p_objFormInfo"></param>
		/// <param name="p_objPatientList"></param>
		private void m_mthSetPatientList(RecordSearch.clsRecordSearchDomain.clsFormInfo p_objFormInfo,RecordSearch.clsRecordSearchDomain.clsPatientList[] p_objPatientList)
		{
			m_mthClearPatientList();

			int intPatientCount = 0;
			string strPreInPatientNO = "";

			if(p_objPatientList != null && p_objPatientList.Length > 0)
			{
				for(int i=0;i<p_objPatientList.Length;i++)
				{
					ListViewItem lviPatient = new ListViewItem(
						new string[]{p_objPatientList[i].m_strFirstName,p_objPatientList[i].m_strInPatientNO,DateTime.Parse(p_objPatientList[i].m_strInPatientDate).ToString("yyyy年MM月dd日")});
					lviPatient.Tag = p_objPatientList[i];

					if(p_objPatientList[i].m_strInPatientNO != strPreInPatientNO)
					{
						strPreInPatientNO = p_objPatientList[i].m_strInPatientNO;
						intPatientCount++;
					}

					m_lsvPatientList.Items.Add(lviPatient);
				}
				m_lblPatientCount.Text = "人数："+intPatientCount.ToString();
				m_lblPatientTimesCount.Text = "人次："+m_lsvPatientList.Items.Count.ToString();
				m_lsvPatientList.Tag = m_objGetPatientDetailMaker(p_objFormInfo.m_strFormName);
			}
		}
		/// <summary>
		/// 清空病人列表，及其相关信息
		/// </summary>
		private void m_mthClearPatientList()
		{
			m_lsvPatientList.Items.Clear();
			m_lsvPatientList.Tag = null;
			m_txtPatientInfo.Text = "";
			m_txtPatientInfo.Tag = null;
			m_lblPatientCount.Text = "人数：";
			m_lblPatientTimesCount.Text = "人次：";
		}
		/// <summary>
		/// 设置病人详细信息
		/// </summary>
		/// <param name="p_objPatientList"></param>
		private void m_mthSetPationDetailInfo(RecordSearch.clsRecordSearchDomain.clsPatientList p_objPatientList)
		{
			RecordSearch.PatientDetailMaker.clsPatientDetailMakerBase objPatientDetailBase = m_lsvPatientList.Tag as RecordSearch.PatientDetailMaker.clsPatientDetailMakerBase;

			if(objPatientDetailBase == null)
				return;

			
			//查新表，打开相应表单同步病人信息
			clsPatient objNew = new clsPatient(p_objPatientList.m_strInPatientNO);
			clsPatientInBedInfo objNewBed = new clsPatientInBedInfo(objNew);
			string strNewDept = "";
			string strNewArea = "";
			string strNewBed = "";
			if(objNewBed != null && objNewBed.m_ObjLastSessionInfo != null)
			{
				strNewDept = objNewBed.m_strNewDeptIDForSearch;
				strNewArea = objNewBed.m_strNewAreaIDForSearch;
				if(objNewBed.m_ObjLastRoomInfo.m_intGetBedCount() > 0)
					strNewBed = objNewBed.m_ObjLastRoomInfo.m_objGetBedByIndex(0).m_ObjBed.m_StrBedName;
			}

			clsPatient objSelectedPatient = new clsPatient(p_objPatientList.m_strInPatientNO);
			objSelectedPatient.m_strDeptNewID = strNewDept;
			objSelectedPatient.m_strAreaNewID = strNewArea;
			objSelectedPatient.m_strBedCode = strNewBed;
			m_txtPatientInfo.Tag = objSelectedPatient;
			m_txtPatientInfo.Text = objPatientDetailBase.m_strMakerPatientDetailDesc(objSelectedPatient,p_objPatientList);
		}
		#endregion

		private void m_lsvPatientList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_lsvPatientList.SelectedItems.Count <= 0)
				return;

            RecordSearch.clsRecordSearchDomain.clsPatientList objPatientList = m_lsvPatientList.SelectedItems[0].Tag as RecordSearch.clsRecordSearchDomain.clsPatientList;

			m_mthSetPationDetailInfo(objPatientList);
		}

		private void m_ctmExplorer_Popup(object sender, System.EventArgs e)
		{
			if(m_lsvPatientList.SelectedItems.Count <= 0)
			{
				m_mthSetMainMenuItem(null,m_ctmExplorer);
				return;
			}

			RecordSearch.clsRecordSearchDomain.clsPatientList objPatientList = m_lsvPatientList.SelectedItems[0].Tag as RecordSearch.clsRecordSearchDomain.clsPatientList;

			System.Data.DataTable dtbCount;
			long lngRes = m_objRecordSearchDomain.m_lngGetPatientRecordCount(((RecordSearch.clsRecordSearchDomain.clsFormInfo)m_cboFormList.SelectedItem).m_strFormID, 
				((RecordSearch.clsRecordSearchDomain.clsFormInfo)m_cboFormList.SelectedItem).m_strFormName,objPatientList.m_strInPatientNO,objPatientList.m_strInPatientDate,m_objCustomForms,out dtbCount);

			if(lngRes <= 0)
			{
				m_mthSetMainMenuItem(null,m_ctmExplorer);
				return;
			}
			if(m_cboFormList.Text != string.Empty && m_cboFormList.Text != "手术记录单" && m_cboFormList.Text != "住院病案首页")
			{
				m_mnuInPatient.Text = m_cboFormList.Text;
			}
			m_mthSetMainMenuItem(dtbCount,m_ctmExplorer);
		}
		/// <summary>
		/// 根据病人表单信息设置主菜单
		/// </summary>
		/// <param name="p_dtbCount"></param>
		/// <param name="p_mnuParent"></param>
		private void m_mthSetMainMenuItem(System.Data.DataTable p_dtbCount,System.Windows.Forms.ContextMenu p_ctmParent)
		{
			for(int i=0;i<p_ctmParent.MenuItems.Count;i++)
			{				
				m_mthSetMenuItem(p_dtbCount,p_ctmParent.MenuItems[i]);
			}
		}
		/// <summary>
		/// 根据病人表单信息设置菜单
		/// </summary>
		private void m_mthSetMenuItem(System.Data.DataTable p_dtbCount,MenuItem p_mnuParent)
		{
			
			if(p_mnuParent.MenuItems.Count > 0)
			{
				for(int i=0;i<p_mnuParent.MenuItems.Count;i++)
				{				
					m_mthSetMenuItem(p_dtbCount,p_mnuParent.MenuItems[i]);
				}					
			}
			else
			{
				if(p_dtbCount == null || p_dtbCount.Rows.Count != 1)
				{
					p_mnuParent.Enabled = false;
				}
				else
				{
					if(!p_dtbCount.Columns.Contains(p_mnuParent.Text))
					{
						p_mnuParent.Enabled = false;
					}
					else
					{
						string strCount = p_dtbCount.Rows[0][p_mnuParent.Text].ToString();

						if(strCount != "" && strCount != "0")
							p_mnuParent.Enabled = true;
						else
							p_mnuParent.Enabled = false;
					}
				}
			}
		}

//		private ContextMenu m_ctmExploer;

		/// <summary>
		/// 初始化右键表单
		/// </summary>
		private void m_mthInitContextMenu()
		{
//			m_ctmExploer = Form_HRPExplorer.s_ctmExploer;
//			m_ctmExploer.Popup -= null;
//			m_ctmExploer.Popup += new EventHandler(m_ctmExplorer_Popup);
			

			foreach(MenuItem mniSub in m_ctmExplorer.MenuItems)
				m_mthAssociateItemEvent(mniSub);

			m_lsvPatientList.ContextMenu = m_ctmExplorer;
			m_txtPatientInfo.ContextMenu = m_ctmExplorer;

			m_mthLoadCustomForms();
		}

		/// <summary>
		/// 关联事件
		/// </summary>
		/// <param name="p_mniParent"></param>
		private void m_mthAssociateItemEvent(MenuItem p_mniParent)
		{
			if(p_mniParent.MenuItems.Count == 0)
				p_mniParent.Click += new EventHandler(m_mthMenuItem_Click);

			for(int i = 0; i < p_mniParent.MenuItems.Count; i++)
			{
				m_mthAssociateItemEvent(p_mniParent.MenuItems[i]);
			}			
		}

		private void m_mthMenuItem_Click(object sender, System.EventArgs e)
		{
			Form frmRecord ;
			if(m_mnuInPatient.Text == "住院病历")
				frmRecord = m_objRecordSearchDomain.m_frmGetForm((MenuItem)sender);
			else
			{
				object obj = Activator.CreateInstance(Type.GetType("iCare." + ((RecordSearch.clsRecordSearchDomain.clsFormInfo)m_cboFormList.SelectedItem).m_strFormID));
				frmRecord = (Form)obj;
			}

			m_mthOpenForm(frmRecord);
		}

		/// <summary>
		/// 打开记录单
		/// </summary>
		/// <param name="p_frmRecord"></param>
		private void m_mthOpenForm(Form p_frmRecord)
		{
			if(m_txtPatientInfo.Tag == null)
				return;

			clsPatient objSelectPatient = (clsPatient)m_txtPatientInfo.Tag;
			objSelectPatient.m_DtmSelectedInDate = DateTime.Parse(((RecordSearch.clsRecordSearchDomain.clsPatientList)m_lsvPatientList.SelectedItems[0].Tag).m_strInPatientDate);			 

			try
			{
				this.Cursor=Cursors.WaitCursor;
				p_frmRecord.MdiParent = this.MdiParent;
				p_frmRecord.Show(); 
				frmHRPBaseForm frmRecord = p_frmRecord as frmHRPBaseForm;
				if(frmRecord != null)
				{
					frmRecord.m_mthSetPatient(objSelectPatient);
				}
				this.Cursor=Cursors.Default;
			}
			catch
			{}
		}

		/// <summary>
		/// 获取指定的窗体
		/// </summary>
		/// <param name="p_mniForm"></param>
		/// <returns></returns>
		private Form m_frmGetForm(MenuItem p_mniForm)
		{
			#region 右键菜单全部窗体
            /*
			switch(p_mniForm.Text) 
			{
				case "住院病历":
					return new frmInPatientCaseHistory();			
				case "住院病历模式2":
					return new frmInPatientCaseHistoryMode1();					
				case "病程记录":
					return new frmSubDiseaseTrack();					
				case "SPECT检查申请单":
					return new frmSPECT();					
				case "高压氧治疗申请单":
					return new frmHighOxygen();					
				case "B型超声显像检查申请单":
					return new frmBUltrasonicCheckOrder();
				case "CT检查申请单":
					return new frmCTCheckOrder();
				case "X线申请单":
					return new frmXRayCheckOrder();
				case "病理活体组织送检单":
					return new frmPathologyOrgCheckOrder();
				case "MRI申请单":
					return new frmMRIApply();
				case "实验室检验申请单":
					return new frmLabAnalysisOrder();
				case "实验室检验报告单":
					return new frmLabCheckReport();
				case "手术知情同意书":
					return new frmOperationAgreedRecord();
				case "术前小结":
					return new frmBeforeOperationSummary();
				case "手术记录单":
					return new frmOperationRecordDoctor();
				case "ICU转入记录":
					return new frmPICUShiftInForm();
				case "ICU转出记录":
					return new frmPICUShiftOutForm();
				case "SIRS诊断评分":
					return new frmSIRSEvaluation();
				case "改良Glasgow昏迷评分":
					return new frmImproveGlasgowComaEvaluation();
				case "急性肺损伤评分":
					return new frmLungInjuryEvaluation();
				case "新生儿危重病例评分":
					return new frmNewBabyInjuryCaseEvaluation();
				case "小儿危重病例评分":
					return new frmBabyInjuryCaseEvaluation();
				case "APACHEII 评分":
					return new frmAPACHEIIValuation();
				case "APACHEIII 评分":
					return new frmAPACHEIIIValuation();
				case "TISS-28评分":
					return new frmTISSValuation();
				case "趋势分析":
					return new frmICUTrend();
				case "住院病案首页":
					return new frmInHospitalMainRecord();
				case "病案质量评分表":
					return new frmQCRecord();
				case "入院病人评估":
					return new frmInPatientEvaluate();
				case "三 测 表":
					return new frmThreeMeasureRecord();
				case "一般护理记录":
					return new frmMainGeneralNurseRecord();
				case "观察项目记录表":
					return new frmWatchItemTrack();
				case "危重患者护理记录":
					return new frmIntensiveTendMain();
				case "ICU危重患者护理记录":
					return new frmICUIntensiveTendRecord();
				case "手术护理记录":
					return new frmOperationRecord();
				case "手术器械、敷料点数表":
					return new frmOperationEquipmentQty();
				case "出院记录":
					return new frmOutHospital();
				case "会诊记录":
					return new frmConsultation();
				case "危重症监护中心特护记录单":
					return new frmMainICUIntensiveTend();
				case "中心ICU呼吸机治疗监护记录单":
					return new frmMainICUBreath();
				case "影像报告单":
					return new frmImageReport();
				case "影像预约查询":
					return new frmImageBookingSearch();	
				case "心电图申请单":
					return new iCare.frmEKGOrder();
				case "电脑多导睡眠图检查申请单":
					return new iCare.frmNuclearOrder();
				case "核医学检查申请单":
					return new iCare.frmPSGOrder();
				case"病人入院评估表":
					return new frmEMR_InPatientEvaluate();
				default :
					break;
			}
            */
			#endregion 右键菜单全部窗体

			return null;
		}

		/// <summary>
		/// 不需要保存提示
		/// </summary>
		protected override void m_mthAddFormStatusForClosingSave()
		{
		}

		#region 自定义表单
		/// <summary>
		/// 自定义表单
		/// </summary>
		private clsCustom_SubmitValue[] m_objCustomForms;
		/// <summary>
		/// Load出自定义表单
		/// </summary>
		private void m_mthLoadCustomForms()
		{
			long lngRes = new iCare.CustomForm.clsCustomFormDomain().m_lngGetSubmitForms(MDIParent.OperatorID,clsSystemContext.s_ObjCurrentContext.m_ObjDepartment.m_StrDeptID,out m_objCustomForms);
			if(lngRes <= 0 || m_objCustomForms == null || m_objCustomForms.Length == 0)
				return;
			MenuItem mniRoot = new MenuItem("自定义表单");
			for(int i = 0; i < m_objCustomForms.Length; i++)
			{
				MenuItem mniCustormForm = mniRoot.MenuItems.Add(m_objCustomForms[i].m_strFormName,new EventHandler(m_mthShowCustomForm));				
			}
			m_ctmExplorer.MenuItems.Add(mniRoot);
		}

		/// <summary>
		/// 打开自定义表单
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void m_mthShowCustomForm(object sender,EventArgs e)
		{			
			if(m_txtPatientInfo.Tag == null)
				return;

			clsPatient objSelectPatient = (clsPatient)m_txtPatientInfo.Tag;
			objSelectPatient.m_DtmSelectedInDate = DateTime.Parse(((RecordSearch.clsRecordSearchDomain.clsPatientList)m_lsvPatientList.SelectedItems[0].Tag).m_strInPatientDate);

			try
			{
				this.Cursor=Cursors.WaitCursor;
				iCare.CustomForm.frmCustomFormBase frmChild = new iCare.CustomForm.frmCustomFormBase(m_objCustomForms[((MenuItem)sender).Index]);
				frmChild.MdiParent =this.MdiParent;
				frmChild.Show(); 
				frmChild.m_mthSetPatient(objSelectPatient);
				MDIParent.s_ObjCurrentPatient = objSelectPatient;
				this.Cursor=Cursors.Default;
			}
			catch
			{}
		}
		#endregion

		private void m_cboFieldList_DropDown(object sender, System.EventArgs e)
		{
			//新专科病历用
			if(m_cboFormList.Text != "手术记录单" && m_cboFormList.Text != "住院病案首页" && m_cboFormList.Text != "住院病历")
			{
				if(m_trvCondition.Visible == false)
				{
//					m_objBorderTool.m_mthChangedControlBorder(m_trvCondition);
					m_trvCondition.Visible = true;
					m_trvCondition.BringToFront();
					m_trvCondition.Focus();
					m_trvCondition.SelectedNode = null;
					if(m_trvCondition.Nodes.Count > 0)
						if(m_trvCondition.Nodes[0] != null)
							m_trvCondition.Nodes[0].Expand();
				}
				else
				{
//					m_objBorderTool.m_mthUnChangedControlBorder(m_trvCondition);
					m_trvCondition.Visible = false;
					if(m_cboFieldList.GetItemsCount() > 0)
						m_cboFieldList.SelectedIndex = 0;
					m_cmdAddCondition.Focus();
				}
				grbSearchCondition.Refresh();
			}
		}

		private void m_trvCondition_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if(e.Node.Tag == null || e.Node == null)
				return;
			if(e.Node.Nodes.Count == 0)
			{
				m_cboFieldList.ClearItem();
				m_cboFieldList.AddItem((iCare.RecordSearch.clsRecordSearchDomain.clsFieldInfo)e.Node.Tag);
				m_cboFieldList.SelectedIndex = 0;
			}
			else
				return;
			m_mthSetConditionBase();
		}
		private void m_trvCondition_DoubleClick(object sender, System.EventArgs e)
		{
			if(m_trvCondition.SelectedNode == null || m_trvCondition.SelectedNode.Tag == null)
				return;
			if(m_trvCondition.SelectedNode.Nodes.Count == 0)
			{
				m_cboFieldList.ClearItem();
				m_cboFieldList.AddItem((iCare.RecordSearch.clsRecordSearchDomain.clsFieldInfo)m_trvCondition.SelectedNode.Tag);
				m_cboFieldList.SelectedIndex = 0;
			}
			else
			{
				return;
			}
			m_trvCondition.Visible = false;
			grbSearchCondition.Refresh();

			m_mthSetConditionBase();
		}

		/// <summary>
		/// 
		/// </summary>
		private void m_mthSetConditionBase()
		{
			RecordSearch.clsRecordSearchDomain.clsFieldInfo objFieldInfo = m_cboFieldList.SelectedItem as RecordSearch.clsRecordSearchDomain.clsFieldInfo;
			m_objConditionBase = m_objGetConditionMaker(objFieldInfo.m_strConditionFieldType);
			if(m_objConditionBase != null)
			{
				m_objConditionBase.m_mthSetConditionField(objFieldInfo.m_strConditionFieldName);
				m_objConditionBase.m_mthResetConditionInput();
			}
			m_mthShowConditionInput(objFieldInfo.m_strConditionFieldType);
		}

		/// <summary>
		/// 初始化查询树
		/// </summary>
		/// <param name="p_objFormInfo"></param>
		private void m_mthInitTreeNodes(RecordSearch.clsRecordSearchDomain.clsFormInfo p_objFormInfo)
		{
			if(p_objFormInfo == null)
				return;
			if(p_objFormInfo.m_objFieldInfoArr == null)
			{
				m_objRecordSearchDomain.m_mthIMR_GetFieldInfo(ref p_objFormInfo);
			}
			if(p_objFormInfo.m_objFieldInfoArr == null)
				return;
			m_trvCondition.BeginUpdate();
			m_trvCondition.Nodes.Clear();
			TreeNode tnRoot = new TreeNode(p_objFormInfo.m_strFormName);
			tnRoot.Tag = p_objFormInfo;
			for(int i=0; i<p_objFormInfo.m_objFieldInfoArr.Length; i++)
			{
				if(p_objFormInfo.m_objFieldInfoArr[i].m_strFieldName == null)
					continue;
				m_mthAddTreeNode(p_objFormInfo.m_objFieldInfoArr[i],tnRoot,p_objFormInfo.m_objFieldInfoArr[i].m_strFieldName);
			}
			m_trvCondition.Nodes.Add(tnRoot);
			m_trvCondition.EndUpdate();
		}

		/// <summary>
		/// 递归添加树结点
		/// </summary>
		/// <param name="p_objFieldInfo">绑定叶结点Tag的Object</param>
		/// <param name="p_tnParent"></param>
		/// <param name="p_strFieldName"></param>
		private void m_mthAddTreeNode(iCare.RecordSearch.clsRecordSearchDomain.clsFieldInfo p_objFieldInfo,TreeNode p_tnParent,string p_strFieldName)
		{
			TreeNode tnSubNode = null;
			int intIndex = p_strFieldName.IndexOf(">>");
			if(intIndex > 0)
			{
				//有子项
				string strFirstItem = p_strFieldName.Substring(0,intIndex);
				p_strFieldName = p_strFieldName.Substring(intIndex+2);
				if(p_tnParent.Nodes.Count > 0)
				{
					foreach(TreeNode tn in p_tnParent.Nodes)
					{
						if(tn.Text == strFirstItem)
						{
							tnSubNode = tn;
							break;
						}
					}
					if(tnSubNode != null)
					{
						//子结点已存在
						m_mthAddTreeNode(p_objFieldInfo,tnSubNode,p_strFieldName);
					}
					else
					{
						tnSubNode = new TreeNode(strFirstItem);
						p_tnParent.Nodes.Add(tnSubNode);
						m_mthAddTreeNode(p_objFieldInfo,tnSubNode,p_strFieldName);
					}
					return;
				}
				else
				{
					//子结点为空
					tnSubNode = new TreeNode(strFirstItem);
					p_tnParent.Nodes.Add(tnSubNode);
					m_mthAddTreeNode(p_objFieldInfo,tnSubNode,p_strFieldName);
				}
				return;
			}
			else
			{
				tnSubNode = new TreeNode(p_strFieldName);
				tnSubNode.Tag = p_objFieldInfo;
			 
//				m_mthAddSubNodeTemplate(tnSubNode,p_objFieldInfo);
			 
			}
			p_tnParent.Nodes.Add(tnSubNode);
		}

		
		/// <summary>
		/// 添加
		/// </summary>
		/// <param name="objNode"></param>
		/// <param name="objFieldInfo"></param>
		private void m_mthAddSubNodeTemplate(iCare.RecordSearch.clsRecordSearchDomain.clsFieldInfo objFieldInfo)
		{
			m_tvwTemplate.Nodes.Clear();
			m_txtTemplateName.Text="";
			m_txtTemplateValue.Text="";

			if(objFieldInfo==null) return;

			TreeNode objNode=m_tvwTemplate.Nodes.Add(objFieldInfo.ToString());

			try
			{
				RecordSearch.clsRecordSearchDomain.clsFormInfo objFormInfo = m_cboFormList.SelectedItem as RecordSearch.clsRecordSearchDomain.clsFormInfo;
				if(objFormInfo == null)	return;

                CustomFromService.clsMinElementColServ objService =
                    (CustomFromService.clsMinElementColServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(CustomFromService.clsMinElementColServ));

				string str1=objFieldInfo.m_strConditionFieldName;
				int idx1=str1.IndexOf("'",0);
				int idx2=str1.IndexOf("'",idx1+1);
				if((idx1>=0) && (idx2>=0) && (idx1<idx2))
				{
					string strCtrlID=str1.Substring(idx1+1,idx2-idx1-1);
				
					clsTemplateInfo[] arrTemplate;
					long ret=objService.m_lngGetTemplates(objFormInfo.m_strFormID,strCtrlID,out arrTemplate);
					if((ret>0) && (arrTemplate!=null))
					{
						for(int i=0;i<arrTemplate.Length;i++)
						{
							TreeNode objSubNode=objNode.Nodes.Add(arrTemplate[i].m_strTEMPLATE_NAME);
							objSubNode.Tag=arrTemplate[i];
							m_mthAddSubNodeTemplateItems(objSubNode,arrTemplate[i].m_strTEMPLATE_ID);
						}
					}
				}
                //objService.Dispose();
			}
			catch(Exception err)
			{
				string strMsg=err.Message.ToString();
			}
		}

		private void m_mthAddSubNodeTemplateItems(TreeNode objNode,string strTemplateID)
		{
            CustomFromService.clsMinElementColServ objService =
                (CustomFromService.clsMinElementColServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(CustomFromService.clsMinElementColServ));

			clsTemplateControlValue[] arrItems;
			long ret=objService.m_lngGetTemplateControls(strTemplateID,out arrItems);
			if((ret>0) && (arrItems!=null))
			{
				for(int i=0;i<arrItems.Length;i++)
				{
					TreeNode objSubNode=objNode.Nodes.Add(arrItems[i].m_strCONTROL_DESC);
					objSubNode.Tag=arrItems[i];
				}
			}
            //objService.Dispose();
		}

		private void m_cmdAddTemplateCondition_Click(object sender, System.EventArgs e)
		{
			if(m_tvwTemplate.SelectedNode==null) return;
			if(m_tvwTemplate.SelectedNode==m_tvwTemplate.Nodes[0]) return;

			if(m_tvwTemplate.SelectedNode.Tag is clsTemplateControlValue)
			{
				clsTemplateControlValue objValue=m_tvwTemplate.SelectedNode.Tag as clsTemplateControlValue;
				
				clsTemplateCondition objCon=new clsTemplateCondition();
				objCon.m_strGuiID=objValue.m_strGUI_ID;
				objCon.m_strCtrlName=objValue.m_strCONTROL_ID;
				objCon.m_strCtrlValue=m_txtTemplateValue.Text.Trim();

				m_lstConditionList.Items.Add(objCon);
			}
		}

	
		private class clsTemplateCondition
		{
			public string m_strGuiID="";
			public string m_strCtrlName="";
			public string m_strCtrlValue="";

			public override string ToString()
			{
				return m_strCtrlName + "=\"" + m_strCtrlValue + "\"";
			}

		}

		private void m_trvCondition_LostFocus(object sender, EventArgs e)
		{
			m_trvCondition.Visible=false;
		}

		private void m_tvwTemplate_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			m_txtTemplateName.Text="";

			if(m_tvwTemplate.SelectedNode==null) return;
			if(m_tvwTemplate.SelectedNode==m_tvwTemplate.Nodes[0]) return;

			if(m_tvwTemplate.SelectedNode.Tag is clsTemplateControlValue)
			{
				m_txtTemplateName.Text=m_tvwTemplate.SelectedNode.Text;
			}
		}

		
	}
}

